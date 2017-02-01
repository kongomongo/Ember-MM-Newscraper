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
    Private _shortname As String = "Serienjunkies.org"

    Private _addonsettings As New AddonSettings
    Private _settings As New XMLAddonSettings
    Private _settingspanel As frmSettingsPanel

    Private WithEvents cmnuTVShow As New ToolStripMenuItem
    Private WithEvents cmnuTVShow_AddToWatchlist As New ToolStripMenuItem
    Private WithEvents cmnuTVShow_SearchNewEpisodes As New ToolStripMenuItem
    Private WithEvents cmnuTVShow_EditWatchlistEntry As New ToolStripMenuItem
    Private WithEvents cmnuTVShow_RemoveFromWatchlist As New ToolStripMenuItem
    Private WithEvents cmnuTrayToolsSerienjunkies As New ToolStripMenuItem
    Private WithEvents mnuMainToolsSerienjunkies As New ToolStripMenuItem

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal eType As Enums.AddonEventType, ByRef _params As List(Of Object)) Implements Interfaces.Addon.GenericEvent
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
            Return New List(Of Enums.AddonEventType)
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

    ReadOnly Property Shortname() As String Implements Interfaces.Addon.Shortname
        Get
            Return _shortname
        End Get
    End Property

    ReadOnly Property Version() As String Implements Interfaces.Addon.Version
        Get
            Return FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub cmnuTVShow_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuTVShow.DropDownOpening
        If AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows.Count = 1 Then
            Dim lngID As Long = CLng(AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows(0).Cells("idShow").Value)
            If _addonsettings.WatchList.FirstOrDefault(Function(f) f.ID = lngID) IsNot Nothing Then
                cmnuTVShow_AddToWatchlist.Enabled = False
                cmnuTVShow_EditWatchlistEntry.Enabled = True
                cmnuTVShow_RemoveFromWatchlist.Enabled = True
                cmnuTVShow_SearchNewEpisodes.Enabled = True
            Else
                cmnuTVShow_AddToWatchlist.Enabled = True
                cmnuTVShow_EditWatchlistEntry.Enabled = False
                cmnuTVShow_RemoveFromWatchlist.Enabled = False
                cmnuTVShow_SearchNewEpisodes.Enabled = False
            End If
        ElseIf AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows.Count > 1 Then
            cmnuTVShow_AddToWatchlist.Enabled = True
            cmnuTVShow_EditWatchlistEntry.Enabled = False
            cmnuTVShow_RemoveFromWatchlist.Enabled = True
            cmnuTVShow_SearchNewEpisodes.Enabled = True
        End If
    End Sub

    Private Sub cmnuTVShow_AddToWatchlist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuTVShow_AddToWatchlist.Click, cmnuTVShow_EditWatchlistEntry.Click
        Cursor.Current = Cursors.WaitCursor
        LoadSettings()
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
            Dim nDBElement As Database.DBElement = Master.DB.Load_TVShow(CLng(sRow.Cells("idShow").Value), False, False, False)
            Dim strTitle As String = nDBElement.MainDetails.Title
            Dim strURL As String = String.Empty
            Dim nWatchItem As AddonSettings.WatchItem = _addonsettings.WatchList.FirstOrDefault(Function(f) f.ID = nDBElement.ID)
            If nWatchItem IsNot Nothing Then
                strURL = nWatchItem.URL
            End If
            Using dAddTVShow As New dlgAddTVShow(strTitle, strURL)
                Select Case dAddTVShow.ShowDialog()
                    Case DialogResult.OK
                        strURL = dAddTVShow.txtURL.Text.Trim
                        If Not String.IsNullOrEmpty(strURL) AndAlso Not strURL.EndsWith("/") Then
                            strURL = String.Concat(strURL, "/")
                        End If
                        If nWatchItem Is Nothing Then
                            _addonsettings.WatchList.Add(New AddonSettings.WatchItem With {
                                                             .ID = nDBElement.ID,
                                                             .Title = nDBElement.MainDetails.Title,
                                                             .URL = strURL})
                        Else
                            nWatchItem.URL = strURL
                        End If
                    Case DialogResult.Ignore
                        Continue For
                    Case Else
                        Exit For
                End Select
            End Using
        Next
        SaveSettings()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuTVShow_RemoveFromWatchlist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuTVShow_RemoveFromWatchlist.Click
        Cursor.Current = Cursors.WaitCursor
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
            For i = _addonsettings.WatchList.Count - 1 To 0 Step -1
                If _addonsettings.WatchList(i).ID = CLng(sRow.Cells("idShow").Value) Then
                    _addonsettings.WatchList.RemoveAt(i)
                End If
            Next
        Next
        SaveSettings()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuTVShow_SearchNewEpisodes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmnuTVShow_SearchNewEpisodes.Click
        Cursor.Current = Cursors.WaitCursor
        Dim nEpisodeList As New List(Of Parser.TVShowContainer)
        For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
            Dim nWatchedItem As AddonSettings.WatchItem = _addonsettings.WatchList.FirstOrDefault(Function(f) f.ID = CLng(sRow.Cells("idShow").Value))
            If nWatchedItem IsNot Nothing Then
                nEpisodeList.Add(Parser.ParseMainPage(nWatchedItem))
            End If
        Next
        Cursor.Current = Cursors.Default
        If nEpisodeList.Count > 0 Then
            Dim dlgSearchResults As New dlgSearchResults(_addonsettings, nEpisodeList)
            dlgSearchResults.ShowDialog()
            _addonsettings.SearchResultsHeight = dlgSearchResults.Height
            _addonsettings.SearchResultsSplitterDistance = dlgSearchResults.scSearchResults.SplitterDistance
            _addonsettings.SearchResultsWidth = dlgSearchResults.Width
            _addonsettings.SearchResultsWindowState = dlgSearchResults.WindowState
            SaveSettings()
        End If
    End Sub

    Private Sub mnuMainToolsSerienjunkies_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuMainToolsSerienjunkies.Click, cmnuTrayToolsSerienjunkies.Click
        Cursor.Current = Cursors.WaitCursor
        Dim nEpisodeList As New List(Of Parser.TVShowContainer)
        For Each nWatchedItem As AddonSettings.WatchItem In _addonsettings.WatchList
            nEpisodeList.Add(Parser.ParseMainPage(nWatchedItem))
        Next
        Cursor.Current = Cursors.Default
        If nEpisodeList.Count > 0 Then
            Dim dlgSearchResults As New dlgSearchResults(_addonsettings, nEpisodeList)
            dlgSearchResults.ShowDialog()
            _addonsettings.SearchResultsHeight = dlgSearchResults.Height
            _addonsettings.SearchResultsSplitterDistance = dlgSearchResults.scSearchResults.SplitterDistance
            _addonsettings.SearchResultsWidth = dlgSearchResults.Width
            _addonsettings.SearchResultsWindowState = dlgSearchResults.WindowState
            SaveSettings()
        End If
    End Sub

    Public Sub Disable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools menu
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(mnuMainToolsSerienjunkies)

        'cmnuTrayTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(cmnuTrayToolsSerienjunkies)

        ''cmnuEpisodes
        'ToolStripItem_TVEpisodes_Remove(cmnuSep_Episodes)
        'ToolStripItem_TVEpisodes_Remove(cmnuRenamer_Episodes)

        'cmnuShows
        ToolStripItem_TVShows_Remove(cmnuTVShow)
    End Sub

    Public Sub DoDispose() Implements Interfaces.Addon.DoDispose
        RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        RemoveHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        _settingspanel.Dispose()
    End Sub

    Public Sub Enable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools menu
        mnuMainToolsSerienjunkies.Image = New Bitmap(My.Resources.logo)
        mnuMainToolsSerienjunkies.Text = "Serienjunkies.org"
        mnuMainToolsSerienjunkies.Tag = New Structures.ModulesMenus With {.ForMovies = True, .IfTabMovies = True, .ForTVShows = True, .IfTabTVShows = True}
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        ToolStripItem_Add(tsi, mnuMainToolsSerienjunkies)

        'cmnuTrayTools
        cmnuTrayToolsSerienjunkies.Image = New Bitmap(My.Resources.logo)
        cmnuTrayToolsSerienjunkies.Text = "Serienjunkies.org"
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        ToolStripItem_Add(tsi, cmnuTrayToolsSerienjunkies)

        ''cmnuEpisodes
        'cmnuRenamer_Episodes.Image = New Bitmap(My.Resources.icon)
        'cmnuRenamer_Episodes.Text = Master.eLang.GetString(257, "Rename")
        'cmnuRenamerAuto_TVEpisode.Text = Master.eLang.GetString(293, "Auto")
        'cmnuRenamerManual_TVEpisode.Text = Master.eLang.GetString(294, "Manual")
        'cmnuRenamer_Episodes.DropDownItems.Add(cmnuRenamerAuto_TVEpisode)
        'cmnuRenamer_Episodes.DropDownItems.Add(cmnuRenamerManual_TVEpisode)

        'ToolStripItem_TVEpisodes_Set(cmnuSep_Episodes)
        'ToolStripItem_TVEpisodes_Set(cmnuRenamer_Episodes)

        'cmnuShows
        cmnuTVShow.Image = New Bitmap(My.Resources.logo)
        cmnuTVShow.Text = "Serienjunkies.org"
        'Search for new episodes
        'cmnuTVShow_SearchNewEpisodes.Image = New Bitmap(My.Resources.menuAdd)
        cmnuTVShow_SearchNewEpisodes.Text = "Search for new Episodes"
        cmnuTVShow.DropDownItems.Add(cmnuTVShow_SearchNewEpisodes)
        'Separator
        cmnuTVShow.DropDownItems.Add(New ToolStripSeparator)
        'Add to WatchList
        cmnuTVShow_AddToWatchlist.Image = New Bitmap(My.Resources.menuAdd)
        cmnuTVShow_AddToWatchlist.Text = "Add to Watchlist"
        cmnuTVShow.DropDownItems.Add(cmnuTVShow_AddToWatchlist)
        'Edit WatchList entry
        cmnuTVShow_EditWatchlistEntry.Image = New Bitmap(My.Resources.menuEdit)
        cmnuTVShow.DropDownItems.Add(cmnuTVShow_EditWatchlistEntry)
        cmnuTVShow_EditWatchlistEntry.Text = "Edit Watchlist Entry"
        'Remove from WatchList
        cmnuTVShow_RemoveFromWatchlist.Image = New Bitmap(My.Resources.menuRemove)
        cmnuTVShow_RemoveFromWatchlist.Text = "Remove from Watchlist"
        cmnuTVShow.DropDownItems.Add(cmnuTVShow_RemoveFromWatchlist)

        ToolStripItem_TVShows_Set(cmnuTVShow)
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub Handle_StateChanged(ByVal bEnabled As Boolean)
        RaiseEvent StateChanged(_shortname, bEnabled)
    End Sub

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        LoadSettings()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        LoadSettings()
        Dim nSettingsPanel As New Containers.SettingsPanel
        _settingspanel = New frmSettingsPanel
        _settingspanel.chkEnabled.Checked = _enabled

        For Each nWatchItem In _addonsettings.WatchList
            _settingspanel.dgvWatchList.Rows.Add(New Object() {nWatchItem.ID, nWatchItem.Title, nWatchItem.URL})
        Next

        nSettingsPanel.ImageIndex = If(_enabled, 9, 10)
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings
        nSettingsPanel.Prefix = "Serienjunkies.org_"
        nSettingsPanel.Title = "Serienjunkies.org"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        AddHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        _addonsettings = New AddonSettings
        _addonsettings.SearchResultsHeight = _settings.GetIntegerSetting("SearchResultsHeight", 600)
        _addonsettings.SearchResultsSplitterDistance = _settings.GetIntegerSetting("SearchResultsSplitterDistance", 200)
        _addonsettings.SearchResultsWidth = _settings.GetIntegerSetting("SearchResultsWidth", 800)
        _addonsettings.SearchResultsWindowState = _settings.GetIntegerSetting("SearchResultsWindowState", 0)

        Dim nWatchList As List(Of AdvancedSettingsComplexSettingsTableItem) = _settings.GetComplexSetting("WatchList")
        If nWatchList IsNot Nothing Then
            For Each nWatchItem In nWatchList
                Dim lngID As Long = -1
                If Long.TryParse(nWatchItem.Name, lngID) Then
                    Dim nDBElement As Database.DBElement = Master.DB.Load_TVShow(lngID, False, False, False)
                    If nDBElement IsNot Nothing Then
                        _addonsettings.WatchList.Add(New AddonSettings.WatchItem With {
                                                     .ID = nDBElement.ID,
                                                     .Title = nDBElement.MainDetails.Title,
                                                     .URL = nWatchItem.Value
                                                     })
                    End If
                End If
            Next
            _addonsettings.WatchList = _addonsettings.WatchList.OrderBy(Function(f) f.Title).ToList
        End If
    End Sub

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        Return New Interfaces.AddonResult
    End Function

    Public Sub SaveSetup() Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked

        _addonsettings.WatchList.Clear()
        For Each r As DataGridViewRow In _settingspanel.dgvWatchList.Rows
            If Not String.IsNullOrEmpty(r.Cells(2).Value.ToString) AndAlso _addonsettings.WatchList.Find(Function(f) f.ID = CLng(r.Cells(0).Value)) Is Nothing Then
                _addonsettings.WatchList.Add(New AddonSettings.WatchItem With {
                                             .ID = CLng(r.Cells(0).Value),
                                             .Title = r.Cells(1).Value.ToString,
                                             .URL = r.Cells(2).Value.ToString
                                             })
            End If
        Next

        SaveSettings()
    End Sub

    Public Sub SaveSettings()
        _settings = New XMLAddonSettings
        _settings.SetIntegerSetting("SearchResultsHeight", _addonsettings.SearchResultsHeight)
        _settings.SetIntegerSetting("SearchResultsSplitterDistance", _addonsettings.SearchResultsSplitterDistance)
        _settings.SetIntegerSetting("SearchResultsWidth", _addonsettings.SearchResultsWidth)
        _settings.SetIntegerSetting("SearchResultsWindowState", _addonsettings.SearchResultsWindowState)

        Dim nWatchList As New List(Of AdvancedSettingsComplexSettingsTableItem)
        For Each nWatchItem As AddonSettings.WatchItem In _addonsettings.WatchList.OrderBy(Function(f) f.Title)
            nWatchList.Add(New AdvancedSettingsComplexSettingsTableItem With {
                           .Name = CStr(nWatchItem.ID),
                           .Value = nWatchItem.URL
                           })
        Next
        If nWatchList IsNot Nothing Then
            _settings.SetComplexSetting("WatchList", nWatchList)
        End If
        _settings.Save()
    End Sub

    Public Sub ToolStripItem_Add(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner.InvokeRequired Then
            control.Owner.Invoke(New Delegate_AddToolsStripItem(AddressOf ToolStripItem_Add), New Object() {control, value})
        Else
            control.DropDownItems.Add(value)
        End If
    End Sub

    Public Sub ToolStripItem_TVShows_Remove(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf ToolStripItem_TVShows_Remove), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Items.Remove(value)
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

    Class AddonSettings

#Region "Fields"

        Public WatchList As New List(Of WatchItem)
        Public SearchResultsHeight As Integer
        Public SearchResultsSplitterDistance As Integer
        Public SearchResultsWidth As Integer
        Public SearchResultsWindowState As Integer

#End Region 'Fields

#Region "Nested Types"

        Class WatchItem

#Region "Fields"

            Public ID As Long = -1
            Public Title As String = String.Empty
            Public URL As String = String.Empty

#End Region 'Fields

        End Class

#End Region 'Nested Types

    End Class

#End Region 'Nested Types

End Class
