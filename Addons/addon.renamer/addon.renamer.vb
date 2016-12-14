' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports EmberAPI

Public Class Addon
    Implements Interfaces.Addon

#Region "Delegates"

    Public Delegate Sub Delegate_SetToolsStripItem(value As ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolsStripItem(value As ToolStripItem)
    Public Delegate Sub Delegate_AddToolsStripItem(tsi As ToolStripMenuItem, value As ToolStripMenuItem)

#End Region 'Delegates

#Region "Fields"

    Private _assemblyname As String = String.Empty
    Private _enabled As Boolean = False
    Private _name As String = "Renamer"
    Private _settingspanel As frmSettingsPanel


    Private _AddonSettings As New AddonSettings
    Private cmnuRenamer_Movies As New ToolStripMenuItem
    Private cmnuRenamer_Episodes As New ToolStripMenuItem
    Private cmnuRenamer_Shows As New ToolStripMenuItem
    Private cmnuSep_Movies As New ToolStripSeparator
    Private cmnuSep_Episodes As New ToolStripSeparator
    Private cmnuSep_Shows As New ToolStripSeparator
    Private WithEvents cmnuRenamerAuto_Movie As New ToolStripMenuItem
    Private WithEvents cmnuRenamerManual_Movie As New ToolStripMenuItem
    Private WithEvents cmnuRenamerAuto_TVEpisode As New ToolStripMenuItem
    Private WithEvents cmnuRenamerManual_TVEpisode As New ToolStripMenuItem
    Private WithEvents cmnuRenamerAuto_TVShow As New ToolStripMenuItem
    Private WithEvents cmnuRenamerManual_TVShows As New ToolStripMenuItem
    Private WithEvents cmnuTrayToolsRenamer As New ToolStripMenuItem
    Private WithEvents mnuMainToolsRenamer As New ToolStripMenuItem

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object)) Implements Interfaces.Addon.GenericEvent
    Public Event NeedsRestart() Implements Interfaces.Addon.NeedsRestart
    Public Event SettingsChanged() Implements Interfaces.Addon.SettingsChanged
    Public Event StateChanged(ByVal strName As String, ByVal bEnabled As Boolean) Implements Interfaces.Addon.StateChanged

#End Region 'Events

#Region "Properties"

    Public Property Enabled() As Boolean Implements Interfaces.Addon.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            If _enabled = value Then Return
            _enabled = value
            If _enabled Then
                Enable()
            Else
                Disable()
            End If
        End Set
    End Property

    Public ReadOnly Property Capabilities_AddonEventTypes() As List(Of Enums.AddonEventType) Implements Interfaces.Addon.Capabilities_AddonEventTypes
        Get
            Return New List(Of Enums.AddonEventType)(New Enums.AddonEventType() {
                                                     Enums.AddonEventType.AfterEdit_Movie,
                                                     Enums.AddonEventType.AfterEdit_TVEpisode,
                                                     Enums.AddonEventType.AfterEdit_TVShow,
                                                     Enums.AddonEventType.DuringScrapingMulti_Movie,
                                                     Enums.AddonEventType.DuringScrapingMulti_TVEpisode,
                                                     Enums.AddonEventType.DuringScrapingMulti_TVShow,
                                                     Enums.AddonEventType.DuringScrapingSingle_Movie,
                                                     Enums.AddonEventType.DuringScrapingSingle_TVEpisode,
                                                     Enums.AddonEventType.DuringScrapingSingle_TVShow,
                                                     Enums.AddonEventType.DuringUpdateDB_TV})
        End Get
    End Property

    ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)
        End Get
    End Property

    ReadOnly Property IsBusy() As Boolean Implements Interfaces.Addon.IsBusy
        Get
            Return False
        End Get
    End Property

    ReadOnly Property Name() As String Implements Interfaces.Addon.Name
        Get
            Return _name
        End Get
    End Property

    ReadOnly Property Version() As String Implements Interfaces.Addon.Version
        Get
            Return FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub cmnuRenamerAuto_Movie_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuRenamerAuto_Movie.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows
            Dim DBElement As Database.DBElement = Master.DB.Load_Movie(Convert.ToInt64(sRow.Cells("idMovie").Value))
            If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                FileFolderRenamer.RenameSingle_Movie(DBElement, _AddonSettings.FoldersPattern_Movies, _AddonSettings.FilesPattern_Movies, False, True, True)
                RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_Movie, New List(Of Object)(New Object() {Convert.ToInt64(sRow.Cells("idMovie").Value)}))
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerAuto_TVEpisode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuRenamerAuto_TVEpisode.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVEpisodes.SelectedRows
            Dim DBElement As Database.DBElement = Master.DB.Load_TVEpisode(Convert.ToInt64(sRow.Cells("idEpisode").Value), True)
            If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                FileFolderRenamer.RenameSingle_TVEpisode(DBElement, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, True, True)
                RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {Convert.ToInt64(sRow.Cells("idEpisode").Value)})) 'TODO: should be idFile (MultiEpisode handling)
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerAuto_TVShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuRenamerAuto_TVShow.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
            Dim DBElement As Database.DBElement = Master.DB.Load_TVShow(Convert.ToInt64(sRow.Cells("idShow").Value), True, True, True)
            If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                FileFolderRenamer.RenameSingle_TVShow(DBElement, _AddonSettings.FoldersPattern_Shows, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, True, True)
                RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_TVShow, New List(Of Object)(New Object() {Convert.ToInt64(sRow.Cells("idShow").Value)}))
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerManual_Movie_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuRenamerManual_Movie.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows
            Dim DBElement As Database.DBElement = Master.DB.Load_Movie(Convert.ToInt64(sRow.Cells("idMovie").Value))
            If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                Using dRenameManual As New dlgRenameManual_Movie(DBElement)
                    Select Case dRenameManual.ShowDialog()
                        Case DialogResult.OK
                            RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_Movie, New List(Of Object)(New Object() {Convert.ToInt64(sRow.Cells("idMovie").Value)}))
                    End Select
                End Using
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerManual_TVEpisode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuRenamerManual_TVEpisode.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVEpisodes.SelectedRows
            Dim DBElement As Database.DBElement = Master.DB.Load_TVEpisode(Convert.ToInt64(sRow.Cells("idEpisode").Value), True)
            If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                Using dRenameManual As New dlgRenameManual_TVEpisode(DBElement)
                    Select Case dRenameManual.ShowDialog()
                        Case DialogResult.OK
                            RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {Convert.ToInt64(sRow.Cells("idEpisode").Value)}))
                    End Select
                End Using
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerManual_TVShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuRenamerManual_TVShows.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
            Dim DBElement As Database.DBElement = Master.DB.Load_TVShow(Convert.ToInt64(sRow.Cells("idShow").Value), True, True, True)
            If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                Using dRenameManual As New dlgRenameManual_TVShow(DBElement)
                    Select Case dRenameManual.ShowDialog()
                        Case DialogResult.OK
                            RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_TVShow, New List(Of Object)(New Object() {Convert.ToInt64(sRow.Cells("idShow").Value)}))
                    End Select
                End Using
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub Disable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools menu
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(mnuMainToolsRenamer)

        'cmnuTrayTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(cmnuTrayToolsRenamer)

        'cmnuMovies
        ToolStripItem_Movies_Remove(cmnuSep_Movies)
        ToolStripItem_Movies_Remove(cmnuRenamer_Movies)

        'cmnuEpisodes
        ToolStripItem_TVEpisodes_Remove(cmnuSep_Episodes)
        ToolStripItem_TVEpisodes_Remove(cmnuRenamer_Episodes)

        'cmnuShows
        ToolStripItem_TVShows_Remove(cmnuSep_Shows)
        ToolStripItem_TVShows_Remove(cmnuRenamer_Shows)
    End Sub

    Public Sub Enable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools menu
        mnuMainToolsRenamer.Image = New Bitmap(My.Resources.icon)
        mnuMainToolsRenamer.Text = Master.eLang.GetString(291, "Bulk &Renamer")
        mnuMainToolsRenamer.Tag = New Structures.ModulesMenus With {.ForMovies = True, .IfTabMovies = True, .ForTVShows = True, .IfTabTVShows = True}
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        ToolStripItem_Add(tsi, mnuMainToolsRenamer)

        'cmnuTrayTools
        cmnuTrayToolsRenamer.Image = New Bitmap(My.Resources.icon)
        cmnuTrayToolsRenamer.Text = Master.eLang.GetString(291, "Bulk &Renamer")
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        ToolStripItem_Add(tsi, cmnuTrayToolsRenamer)

        'cmnuMovies
        cmnuRenamer_Movies.Image = New Bitmap(My.Resources.icon)
        cmnuRenamer_Movies.Text = Master.eLang.GetString(257, "Rename")
        cmnuRenamer_Movies.ShortcutKeys = CType((Keys.Control Or Keys.R), Keys)
        cmnuRenamerAuto_Movie.Text = Master.eLang.GetString(293, "Auto")
        cmnuRenamerManual_Movie.Text = Master.eLang.GetString(294, "Manual")
        cmnuRenamer_Movies.DropDownItems.Add(cmnuRenamerAuto_Movie)
        cmnuRenamer_Movies.DropDownItems.Add(cmnuRenamerManual_Movie)

        ToolStripItem_Movies_Set(cmnuSep_Movies)
        ToolStripItem_Movies_Set(cmnuRenamer_Movies)

        'cmnuEpisodes
        cmnuRenamer_Episodes.Image = New Bitmap(My.Resources.icon)
        cmnuRenamer_Episodes.Text = Master.eLang.GetString(257, "Rename")
        cmnuRenamer_Episodes.ShortcutKeys = CType((Keys.Control Or Keys.R), Keys)
        cmnuRenamerAuto_TVEpisode.Text = Master.eLang.GetString(293, "Auto")
        cmnuRenamerManual_TVEpisode.Text = Master.eLang.GetString(294, "Manual")
        cmnuRenamer_Episodes.DropDownItems.Add(cmnuRenamerAuto_TVEpisode)
        cmnuRenamer_Episodes.DropDownItems.Add(cmnuRenamerManual_TVEpisode)

        ToolStripItem_TVEpisodes_Set(cmnuSep_Episodes)
        ToolStripItem_TVEpisodes_Set(cmnuRenamer_Episodes)

        'cmnuShows
        cmnuRenamer_Shows.Image = New Bitmap(My.Resources.icon)
        cmnuRenamer_Shows.Text = Master.eLang.GetString(257, "Rename")
        cmnuRenamer_Shows.ShortcutKeys = CType((Keys.Control Or Keys.R), Keys)
        cmnuRenamerAuto_TVShow.Text = Master.eLang.GetString(293, "Auto")
        cmnuRenamerManual_TVShows.Text = Master.eLang.GetString(294, "Manual")
        cmnuRenamer_Shows.DropDownItems.Add(cmnuRenamerAuto_TVShow)
        cmnuRenamer_Shows.DropDownItems.Add(cmnuRenamerManual_TVShows)

        ToolStripItem_TVShows_Set(cmnuSep_Shows)
        ToolStripItem_TVShows_Set(cmnuRenamer_Shows)
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub Handle_StateChanged(ByVal bEnabled As Boolean)
        RaiseEvent StateChanged(_name, bEnabled)
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        LoadSettings()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        LoadSettings()
        Dim SPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel
        _settingspanel.chkEnabled.Checked = _enabled
        _settingspanel.txtFolderPatternMovies.Text = _AddonSettings.FoldersPattern_Movies
        _settingspanel.txtFolderPatternSeasons.Text = _AddonSettings.FoldersPattern_Seasons
        _settingspanel.txtFolderPatternShows.Text = _AddonSettings.FoldersPattern_Shows
        _settingspanel.txtFilePatternEpisodes.Text = _AddonSettings.FilesPattern_Episodes
        _settingspanel.txtFilePatternMovies.Text = _AddonSettings.FilesPattern_Movies
        _settingspanel.chkRenameEditMovies.Checked = _AddonSettings.RenameEdit_Movies
        _settingspanel.chkRenameEditEpisodes.Checked = _AddonSettings.RenameEdit_Episodes
        _settingspanel.chkRenameMultiMovies.Checked = _AddonSettings.RenameMulti_Movies
        _settingspanel.chkRenameMultiShows.Checked = _AddonSettings.RenameMulti_Shows
        _settingspanel.chkRenameSingleMovies.Checked = _AddonSettings.RenameSingle_Movies
        _settingspanel.chkRenameSingleShows.Checked = _AddonSettings.RenameSingle_Shows
        _settingspanel.chkRenameUpdateEpisodes.Checked = _AddonSettings.RenameUpdate_Episodes

        SPanel.ImageIndex = If(_enabled, 9, 10)
        SPanel.Name = _name
        SPanel.Panel = _settingspanel.pnlSettings
        SPanel.Prefix = "Renamer_"
        SPanel.Text = Master.eLang.GetString(295, "Renamer")
        SPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        AddHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        Return SPanel
    End Function

    Public Sub LoadSettings()
        _AddonSettings.FoldersPattern_Movies = clsXMLAdvancedSettings.GetSetting("FoldersPattern", "$T {($Y)}", , Enums.ContentType.Movie)
        _AddonSettings.FoldersPattern_Seasons = clsXMLAdvancedSettings.GetSetting("FoldersPattern", "Season $K2_?", , Enums.ContentType.TVSeason)
        _AddonSettings.FoldersPattern_Shows = clsXMLAdvancedSettings.GetSetting("FoldersPattern", "$Z", , Enums.ContentType.TVShow)
        _AddonSettings.FilesPattern_Episodes = clsXMLAdvancedSettings.GetSetting("FilesPattern", "$Z - $W2_S?2E?{ - $T}", , Enums.ContentType.TVEpisode)
        _AddonSettings.FilesPattern_Movies = clsXMLAdvancedSettings.GetSetting("FilesPattern", "$T{.$S}", , Enums.ContentType.Movie)
        _AddonSettings.RenameEdit_Movies = clsXMLAdvancedSettings.GetBooleanSetting("RenameEdit", False, , Enums.ContentType.Movie)
        _AddonSettings.RenameEdit_Episodes = clsXMLAdvancedSettings.GetBooleanSetting("RenameEdit", False, , Enums.ContentType.TVShow)
        _AddonSettings.RenameMulti_Movies = clsXMLAdvancedSettings.GetBooleanSetting("RenameMulti", False, , Enums.ContentType.Movie)
        _AddonSettings.RenameMulti_Shows = clsXMLAdvancedSettings.GetBooleanSetting("RenameMulti", False, , Enums.ContentType.TVShow)
        _AddonSettings.RenameSingle_Movies = clsXMLAdvancedSettings.GetBooleanSetting("RenameSingle", False, , Enums.ContentType.Movie)
        _AddonSettings.RenameSingle_Shows = clsXMLAdvancedSettings.GetBooleanSetting("RenameSingle", False, , Enums.ContentType.TVShow)
        _AddonSettings.RenameUpdate_Episodes = clsXMLAdvancedSettings.GetBooleanSetting("RenameUpdate", False, , Enums.ContentType.TVEpisode)
    End Sub

    Private Sub mnuMainToolsRenamer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuMainToolsRenamer.Click, cmnuTrayToolsRenamer.Click
        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", False}))
        Select Case AddonsManager.Instance.RuntimeObjects.MediaTabSelected.ContentType
            Case Enums.ContentType.Movie
                Using dBulkRename As New dlgBulkRenamer_Movie
                    dBulkRename.FilterMovies = AddonsManager.Instance.RuntimeObjects.FilterMovies
                    dBulkRename.FilterMoviesSearch = AddonsManager.Instance.RuntimeObjects.FilterMoviesSearch
                    dBulkRename.FilterMoviesType = AddonsManager.Instance.RuntimeObjects.FilterMoviesType
                    dBulkRename.ListMovies = AddonsManager.Instance.RuntimeObjects.ListMovies
                    dBulkRename.txtFilePattern.Text = _AddonSettings.FilesPattern_Movies
                    dBulkRename.txtFolderPattern.Text = _AddonSettings.FoldersPattern_Movies
                    dBulkRename.ShowDialog()
                End Using
            Case Enums.ContentType.TV
                Using dBulkRename As New dlgBulkRenamer_TV
                    dBulkRename.FilterShows = AddonsManager.Instance.RuntimeObjects.FilterTVShows
                    dBulkRename.FilterShowsSearch = AddonsManager.Instance.RuntimeObjects.FilterTVShowsSearch
                    dBulkRename.FilterShowsType = AddonsManager.Instance.RuntimeObjects.FilterTVShowsType
                    dBulkRename.ListShows = AddonsManager.Instance.RuntimeObjects.ListTVShows
                    dBulkRename.txtFilePatternEpisodes.Text = _AddonSettings.FilesPattern_Episodes
                    dBulkRename.txtFolderPatternSeasons.Text = _AddonSettings.FoldersPattern_Seasons
                    dBulkRename.txtFolderPatternShows.Text = _AddonSettings.FoldersPattern_Shows
                    dBulkRename.ShowDialog()
                End Using
        End Select
        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", True}))
        RaiseEvent GenericEvent(Enums.AddonEventType.Generic, New List(Of Object)(New Object() {"filllist", True, True, True}))
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        Select Case eAddonEventType
            Case Enums.AddonEventType.AfterEdit_Movie
                If _AddonSettings.RenameEdit_Movies AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Movies) Then
                    FileFolderRenamer.RenameSingle_Movie(tDBElement, _AddonSettings.FoldersPattern_Movies, _AddonSettings.FilesPattern_Movies, False, False, False)
                End If
            Case Enums.AddonEventType.AfterEdit_TVEpisode
                If _AddonSettings.RenameEdit_Episodes AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Episodes) Then
                    FileFolderRenamer.RenameSingle_TVEpisode(tDBElement, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, False, False)
                End If
            Case Enums.AddonEventType.DuringUpdateDB_TV
                If tDBElement.NfoPathSpecified AndAlso _AddonSettings.RenameUpdate_Episodes AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Episodes) Then
                    FileFolderRenamer.RenameSingle_TVEpisode(tDBElement, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, True, False, False)
                End If
            Case Enums.AddonEventType.DuringScrapingMulti_Movie
                If _AddonSettings.RenameMulti_Movies AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Movies) Then
                    FileFolderRenamer.RenameSingle_Movie(tDBElement, _AddonSettings.FoldersPattern_Movies, _AddonSettings.FilesPattern_Movies, False, False, False)
                End If
            Case Enums.AddonEventType.DuringScrapingMulti_TVEpisode
                If _AddonSettings.RenameMulti_Shows AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Episodes) Then
                    FileFolderRenamer.RenameSingle_TVEpisode(tDBElement, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, False, False)
                End If
            Case Enums.AddonEventType.DuringScrapingMulti_TVShow
                If _AddonSettings.RenameMulti_Shows AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Shows) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Seasons) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Episodes) Then
                    FileFolderRenamer.RenameSingle_TVShow(tDBElement, _AddonSettings.FoldersPattern_Shows, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, False, False)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_Movie
                If _AddonSettings.RenameSingle_Movies AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Movies) Then
                    FileFolderRenamer.RenameSingle_Movie(tDBElement, _AddonSettings.FoldersPattern_Movies, _AddonSettings.FilesPattern_Movies, False, False, False)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_TVEpisode
                If _AddonSettings.RenameSingle_Shows AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Episodes) Then
                    FileFolderRenamer.RenameSingle_TVEpisode(tDBElement, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, False, False)
                End If
            Case Enums.AddonEventType.DuringScrapingSingle_TVShow
                If _AddonSettings.RenameSingle_Shows AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Shows) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FoldersPattern_Seasons) AndAlso Not String.IsNullOrEmpty(_AddonSettings.FilesPattern_Episodes) Then
                    FileFolderRenamer.RenameSingle_TVShow(tDBElement, _AddonSettings.FoldersPattern_Shows, _AddonSettings.FoldersPattern_Seasons, _AddonSettings.FilesPattern_Episodes, False, False, False)
                End If
        End Select
        Return New Interfaces.AddonResult
    End Function

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked
        _AddonSettings.FoldersPattern_Movies = _settingspanel.txtFolderPatternMovies.Text
        _AddonSettings.FoldersPattern_Seasons = _settingspanel.txtFolderPatternSeasons.Text
        _AddonSettings.FoldersPattern_Shows = _settingspanel.txtFolderPatternShows.Text
        _AddonSettings.FilesPattern_Episodes = _settingspanel.txtFilePatternEpisodes.Text
        _AddonSettings.FilesPattern_Movies = _settingspanel.txtFilePatternMovies.Text
        _AddonSettings.RenameEdit_Movies = _settingspanel.chkRenameEditMovies.Checked
        _AddonSettings.RenameEdit_Episodes = _settingspanel.chkRenameEditEpisodes.Checked
        _AddonSettings.RenameMulti_Movies = _settingspanel.chkRenameMultiMovies.Checked
        _AddonSettings.RenameMulti_Shows = _settingspanel.chkRenameMultiShows.Checked
        _AddonSettings.RenameSingle_Movies = _settingspanel.chkRenameSingleMovies.Checked
        _AddonSettings.RenameSingle_Shows = _settingspanel.chkRenameSingleShows.Checked
        _AddonSettings.RenameUpdate_Episodes = _settingspanel.chkRenameUpdateEpisodes.Checked
        SaveSettings()
        If bDoDispose Then
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            RemoveHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
            _settingspanel.Dispose()
        End If
    End Sub

    Public Sub SaveSettings()
        Using settings = New clsXMLAdvancedSettings()
            settings.SetSetting("FoldersPattern", _AddonSettings.FoldersPattern_Movies, , , Enums.ContentType.Movie)
            settings.SetSetting("FoldersPattern", _AddonSettings.FoldersPattern_Seasons, , , Enums.ContentType.TVSeason)
            settings.SetSetting("FoldersPattern", _AddonSettings.FoldersPattern_Shows, , , Enums.ContentType.TVShow)
            settings.SetSetting("FilesPattern", _AddonSettings.FilesPattern_Episodes, , , Enums.ContentType.TVEpisode)
            settings.SetSetting("FilesPattern", _AddonSettings.FilesPattern_Movies, , , Enums.ContentType.Movie)
            settings.SetBooleanSetting("RenameEdit", _AddonSettings.RenameEdit_Movies, , , Enums.ContentType.Movie)
            settings.SetBooleanSetting("RenameEdit", _AddonSettings.RenameEdit_Episodes, , , Enums.ContentType.TVShow)
            settings.SetBooleanSetting("RenameMulti", _AddonSettings.RenameMulti_Movies, , , Enums.ContentType.Movie)
            settings.SetBooleanSetting("RenameMulti", _AddonSettings.RenameMulti_Shows, , , Enums.ContentType.TVShow)
            settings.SetBooleanSetting("RenameSingle", _AddonSettings.RenameSingle_Movies, , , Enums.ContentType.Movie)
            settings.SetBooleanSetting("RenameSingle", _AddonSettings.RenameSingle_Shows, , , Enums.ContentType.TVShow)
            settings.SetBooleanSetting("RenameUpdate", _AddonSettings.RenameUpdate_Episodes, , , Enums.ContentType.TVEpisode)
        End Using
    End Sub

    Public Sub ToolStripItem_Add(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner.InvokeRequired Then
            control.Owner.Invoke(New Delegate_AddToolsStripItem(AddressOf ToolStripItem_Add), New Object() {control, value})
        Else
            control.DropDownItems.Add(value)
        End If
    End Sub

    Public Sub ToolStripItem_Movies_Remove(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf ToolStripItem_Movies_Remove), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Items.Remove(value)
        End If
    End Sub

    Public Sub ToolStripItem_TVEpisodes_Remove(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf ToolStripItem_TVEpisodes_Remove), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Items.Remove(value)
        End If
    End Sub

    Public Sub ToolStripItem_TVShows_Remove(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf ToolStripItem_TVShows_Remove), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Items.Remove(value)
        End If
    End Sub

    Public Sub ToolStripItem_Movies_Set(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Invoke(New Delegate_SetToolsStripItem(AddressOf ToolStripItem_Movies_Set), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Items.Add(value)
        End If
    End Sub

    Public Sub ToolStripItem_TVEpisodes_Set(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Invoke(New Delegate_SetToolsStripItem(AddressOf ToolStripItem_TVEpisodes_Set), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Items.Add(value)
        End If
    End Sub

    Public Sub ToolStripItem_TVShows_Set(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Invoke(New Delegate_SetToolsStripItem(AddressOf ToolStripItem_TVShows_Set), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Items.Add(value)
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure AddonSettings

#Region "Fields"

        Dim FilesPattern_Episodes As String
        Dim FilesPattern_Movies As String
        Dim FoldersPattern_Movies As String
        Dim FoldersPattern_Seasons As String
        Dim FoldersPattern_Shows As String
        Dim RenameEdit_Movies As Boolean
        Dim RenameEdit_Episodes As Boolean
        Dim RenameMulti_Movies As Boolean
        Dim RenameMulti_Shows As Boolean
        Dim RenameSingle_Movies As Boolean
        Dim RenameSingle_Shows As Boolean
        Dim RenameUpdate_Episodes As Boolean

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class