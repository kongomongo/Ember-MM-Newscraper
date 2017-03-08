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
' #
' # Dialog size: 1230; 900
' # Move the panels (pnl*) from 900;900 to 0;0 to edit. Move it back after editing.

Imports EmberAPI
Imports NLog
Imports System.IO

Public Class dlgSettings

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _currpanel As New Panel
    Private _currbutton As New ButtonTag
    Private dHelp As New Dictionary(Of String, String)
    Private didApply As Boolean = False
    Private MovieSetGeneralMediaListSorting As New List(Of Settings.ListSorting)
    Private NoUpdate As Boolean = True
    Private _SettingsPanels As New List(Of Containers.SettingsPanel)
    Private _lstMasterSettingsPanels As New List(Of Interfaces.MasterSettingsPanel)
    Private sResult As New Structures.SettingsResult
    Private TVMeta As New List(Of Settings.MetadataPerType)
    Public Event LoadEnd()

#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Left = Master.AppPos.Left + (Master.AppPos.Width - Width) \ 2
        Top = Master.AppPos.Top + (Master.AppPos.Height - Height) \ 2
        StartPosition = FormStartPosition.Manual
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Overloads Function ShowDialog() As Structures.SettingsResult
        MyBase.ShowDialog()
        Return sResult
    End Function

    Private Sub dlgSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveSettingsPanels()
    End Sub

    Private Sub dlgSettings_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Dim iBackground As New Bitmap(pnlSettingsCurrent.Width, pnlSettingsCurrent.Height)
        Using b As Graphics = Graphics.FromImage(iBackground)
            b.FillRectangle(New Drawing2D.LinearGradientBrush(pnlSettingsCurrent.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlSettingsCurrent.ClientRectangle)
            pnlSettingsCurrent.BackgroundImage = iBackground
        End Using

        If tsSettingsTopMenu.Items.Count > 0 Then
            Dim ButtonsWidth As Integer = 0
            Dim ButtonsCount As Integer = 0
            Dim sLength As Integer = 0
            Dim sRest As Double = 0
            Dim sSpacer As String = String.Empty

            'calculate the buttons width and count
            For Each item As ToolStripItem In tsSettingsTopMenu.Items
                If TypeOf item Is ToolStripButton Then
                    ButtonsWidth += item.Width
                    ButtonsCount += 1
                End If
            Next

            sRest = (tsSettingsTopMenu.Width - ButtonsWidth - 1) / (ButtonsCount + 1)

            'formula to calculate the count of spaces to reach the label.width
            'spaces (x) to width (y) in px: 1 = 10, 2 = 13, 3 = 16, 4 = 19, 5 = 22
            'x = 10 + ((y - 1) * 3) or
            'y = (x - 10) / 3 + 1
            sLength = Convert.ToInt32((sRest - 10) / 3 + 1)

            If Not sRest < 10 Then
                sSpacer = New String(Convert.ToChar(" "), sLength)
            Else
                sSpacer = New String(Convert.ToChar(" "), 1)
            End If

            For Each item As ToolStripItem In tsSettingsTopMenu.Items
                If item.Tag IsNot Nothing AndAlso item.Tag.ToString = "spacer" Then
                    item.Text = sSpacer
                End If
            Next
        End If
    End Sub

    Private Sub AddButtons()
        Dim TSBs As New List(Of ToolStripButton)
        Dim TSB As ToolStripButton

        tsSettingsTopMenu.Items.Clear()

        'first create all the buttons so we can get their size to calculate the spacer
        TSB = New ToolStripButton With {
              .Text = Master.eLang.GetString(390, "Options"),
              .Image = My.Resources.General,
              .TextImageRelation = TextImageRelation.ImageAboveText,
              .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
              .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.Options, .iIndex = 100, .strTitle = Master.eLang.GetString(390, "Options")}}
        AddHandler TSB.Click, AddressOf ToolStripButton_Click
        TSBs.Add(TSB)
        TSB = New ToolStripButton With {
              .Text = Master.eLang.GetString(36, "Movies"),
              .Image = My.Resources.Movie,
              .TextImageRelation = TextImageRelation.ImageAboveText,
              .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
              .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.Movie, .iIndex = 200, .strTitle = Master.eLang.GetString(36, "Movies")}}
        AddHandler TSB.Click, AddressOf ToolStripButton_Click
        TSBs.Add(TSB)
        TSB = New ToolStripButton With {
              .Text = Master.eLang.GetString(1203, "MovieSets"),
              .Image = My.Resources.MovieSet,
              .TextImageRelation = TextImageRelation.ImageAboveText,
              .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
              .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.MovieSet, .iIndex = 300, .strTitle = Master.eLang.GetString(1203, "MovieSets")}}
        AddHandler TSB.Click, AddressOf ToolStripButton_Click
        TSBs.Add(TSB)
        TSB = New ToolStripButton With {
              .Text = Master.eLang.GetString(653, "TV Shows"),
              .Image = My.Resources.TVShows,
              .TextImageRelation = TextImageRelation.ImageAboveText,
              .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
              .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.TV, .iIndex = 400, .strTitle = Master.eLang.GetString(653, "TV Shows")}}
        AddHandler TSB.Click, AddressOf ToolStripButton_Click
        TSBs.Add(TSB)
        TSB = New ToolStripButton With {
              .Text = Master.eLang.GetString(802, "Addons"),
              .Image = My.Resources.modules,
              .TextImageRelation = TextImageRelation.ImageAboveText,
              .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
              .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.Addon, .iIndex = 500, .strTitle = Master.eLang.GetString(802, "Addons")}}
        AddHandler TSB.Click, AddressOf ToolStripButton_Click
        TSBs.Add(TSB)
        TSB = New ToolStripButton With {
            .Text = Master.eLang.GetString(429, "Miscellaneous"),
            .Image = My.Resources.Miscellaneous,
            .TextImageRelation = TextImageRelation.ImageAboveText,
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
            .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.Core, .iIndex = 600, .strTitle = Master.eLang.GetString(429, "Miscellaneous")}}
        AddHandler TSB.Click, AddressOf ToolStripButton_Click
        TSBs.Add(TSB)

        If TSBs.Count > 0 Then
            Dim ButtonsWidth As Integer = 0
            Dim ButtonsCount As Integer = 0
            Dim sLength As Integer = 0
            Dim sRest As Double = 0
            Dim sSpacer As String = String.Empty

            'add it all
            For Each tButton As ToolStripButton In TSBs.OrderBy(Function(b) Convert.ToInt32(DirectCast(b.Tag, ButtonTag).iIndex))
                tsSettingsTopMenu.Items.Add(New ToolStripLabel With {.Text = String.Empty, .Tag = "spacer"})
                tsSettingsTopMenu.Items.Add(tButton)
            Next

            'calculate the buttons width and count
            For Each item As ToolStripItem In tsSettingsTopMenu.Items
                If TypeOf item Is ToolStripButton Then
                    ButtonsWidth += item.Width
                    ButtonsCount += 1
                End If
            Next

            sRest = (tsSettingsTopMenu.Width - ButtonsWidth - 1) / (ButtonsCount + 1)

            'formula to calculate the count of spaces to reach the label.width
            'spaces (x) to width (y) in px: 1 = 10, 2 = 13, 3 = 16, 4 = 19, 5 = 22
            'x = 10 + ((y - 1) * 3) or
            'y = (x - 10) / 3 + 1
            sLength = Convert.ToInt32((sRest - 10) / 3 + 1)

            If Not sRest < 10 Then
                sSpacer = New String(Convert.ToChar(" "), sLength)
            Else
                sSpacer = New String(Convert.ToChar(" "), 1)
            End If

            For Each item As ToolStripItem In tsSettingsTopMenu.Items
                If item.Tag IsNot Nothing AndAlso item.Tag.ToString = "spacer" Then
                    item.Text = sSpacer
                End If
            Next

            'set default page
            _currbutton = DirectCast(TSBs.Item(0).Tag, ButtonTag)
            FillList(DirectCast(TSBs.Item(0).Tag, ButtonTag).ePanelType)
        End If
    End Sub

    Private Sub AddHelpHandlers(ByVal Parent As Control, ByVal Prefix As String)
        Dim pfName As String = String.Empty

        For Each ctrl As Control In Parent.Controls
            If Not TypeOf ctrl Is GroupBox AndAlso Not TypeOf ctrl Is Panel AndAlso Not TypeOf ctrl Is Label AndAlso
            Not TypeOf ctrl Is TreeView AndAlso Not TypeOf ctrl Is ToolStrip AndAlso Not TypeOf ctrl Is PictureBox AndAlso
            Not TypeOf ctrl Is TabControl Then
                pfName = String.Concat(Prefix, ctrl.Name)
                ctrl.AccessibleDescription = pfName
                If dHelp.ContainsKey(pfName) Then
                    dHelp.Item(pfName) = Master.eLang.GetHelpString(pfName)
                Else
                    AddHandler ctrl.MouseEnter, AddressOf HelpMouseEnter
                    AddHandler ctrl.MouseLeave, AddressOf HelpMouseLeave
                    dHelp.Add(pfName, Master.eLang.GetHelpString(pfName))
                End If
            End If
            If ctrl.HasChildren Then
                AddHelpHandlers(ctrl, Prefix)
            End If
        Next
    End Sub

    Private Sub AddSettingsPanels()

        _SettingsPanels.Add(New Containers.SettingsPanel With {
             .Name = "pnlMovieSets",
             .Title = Master.eLang.GetString(38, "General"),
             .ImageIndex = 2,
             .Type = Enums.SettingsPanelType.MovieSet,
             .Panel = pnlMovieSetGeneral,
             .Order = 100})
        _SettingsPanels.Add(New Containers.SettingsPanel With {
             .Name = "pnlTVData",
             .Title = Master.eLang.GetString(556, "Data"),
             .ImageIndex = 3,
             .Type = Enums.SettingsPanelType.TV,
             .Panel = pnlTVScraper,
             .Order = 400})
        _SettingsPanels.Add(New Containers.SettingsPanel With {
             .Name = "pnlExtensions",
             .Title = Master.eLang.GetString(553, "File System"),
             .ImageIndex = 4,
             .Type = Enums.SettingsPanelType.Options,
             .Panel = pnlFileSystem,
             .Order = 200})

        _lstMasterSettingsPanels.Add(frmMovie_Data)
        _lstMasterSettingsPanels.Add(frmMovie_FileNaming)
        _lstMasterSettingsPanels.Add(frmMovie_GUI)
        _lstMasterSettingsPanels.Add(frmMovie_Image)
        _lstMasterSettingsPanels.Add(frmMovie_Theme)
        _lstMasterSettingsPanels.Add(frmMovie_Trailer)
        _lstMasterSettingsPanels.Add(frmMovie_Source)
        _lstMasterSettingsPanels.Add(frmMovieSet_Data)
        _lstMasterSettingsPanels.Add(frmMovieSet_FileNaming)
        _lstMasterSettingsPanels.Add(frmMovieSet_Image)
        _lstMasterSettingsPanels.Add(frmOption_GUI)
        _lstMasterSettingsPanels.Add(frmOption_Proxy)
        _lstMasterSettingsPanels.Add(frmTV_FileNaming)
        _lstMasterSettingsPanels.Add(frmTV_GUI)
        _lstMasterSettingsPanels.Add(frmTV_Image)
        _lstMasterSettingsPanels.Add(frmTV_Source)
        _lstMasterSettingsPanels.Add(frmTV_Theme)

        For Each s As Interfaces.MasterSettingsPanel In _lstMasterSettingsPanels.OrderBy(Function(f) f.Order)
            Dim nPanel As Containers.SettingsPanel = s.InjectSettingsPanel
            If nPanel IsNot Nothing Then
                _SettingsPanels.Add(nPanel)
                AddHandler s.NeedsDBClean_Movie, AddressOf Handle_NeedsDBClean_Movie
                AddHandler s.NeedsDBClean_TV, AddressOf Handle_NeedsDBClean_TV
                AddHandler s.NeedsDBUpdate_Movie, AddressOf Handle_NeedsDBUpdate_Movie
                AddHandler s.NeedsDBUpdate_TV, AddressOf Handle_NeedsDBUpdate_TV
                AddHandler s.NeedsReload_Movie, AddressOf Handle_NeedsReload_Movie
                AddHandler s.NeedsReload_MovieSet, AddressOf Handle_NeedsReload_MovieSet
                AddHandler s.NeedsReload_TVEpisode, AddressOf Handle_NeedsReload_TVEpisode
                AddHandler s.NeedsReload_TVShow, AddressOf Handle_NeedsReload_TVShow
                AddHandler s.NeedsRestart, AddressOf Handle_NeedsRestart
                AddHandler s.SettingsChanged, AddressOf Handle_SettingsChanged
                AddHelpHandlers(nPanel.Panel, nPanel.Prefix)
            End If
        Next
    End Sub

    Sub AddAddonSettingsPanels()
        For Each s As AddonsManager.AddonClass In AddonsManager.Instance.Addons.OrderBy(Function(f) f.AssemblyName)
            Dim nPanel As Containers.SettingsPanel = s.Addon.InjectSettingsPanel
            If nPanel IsNot Nothing Then
                If nPanel.ImageIndex = -1 AndAlso nPanel.Image IsNot Nothing Then
                    ilSettings.Images.Add(String.Concat(s.AssemblyName, nPanel.Name), nPanel.Image)
                    nPanel.ImageIndex = ilSettings.Images.IndexOfKey(String.Concat(s.AssemblyName, nPanel.Name))
                ElseIf nPanel.ImageIndex = -1 Then
                    nPanel.ImageIndex = 9
                End If
                _SettingsPanels.Add(nPanel)
                AddHandler s.Addon.NeedsRestart, AddressOf Handle_NeedsRestart
                AddHandler s.Addon.SettingsChanged, AddressOf Handle_SettingsChanged
                AddHandler s.Addon.StateChanged, AddressOf Handle_StateChanged
                AddHelpHandlers(nPanel.Panel, nPanel.Prefix)
            End If
        Next
    End Sub

    Sub RemoveSettingsPanels()
        'SettingsPanels
        For Each s As Interfaces.MasterSettingsPanel In _lstMasterSettingsPanels.OrderBy(Function(f) f.Order)
            RemoveHandler s.NeedsDBClean_Movie, AddressOf Handle_NeedsDBClean_Movie
            RemoveHandler s.NeedsDBClean_TV, AddressOf Handle_NeedsDBClean_TV
            RemoveHandler s.NeedsDBUpdate_Movie, AddressOf Handle_NeedsDBUpdate_Movie
            RemoveHandler s.NeedsDBUpdate_TV, AddressOf Handle_NeedsDBUpdate_TV
            RemoveHandler s.NeedsReload_Movie, AddressOf Handle_NeedsReload_Movie
            RemoveHandler s.NeedsReload_MovieSet, AddressOf Handle_NeedsReload_MovieSet
            RemoveHandler s.NeedsReload_TVEpisode, AddressOf Handle_NeedsReload_TVEpisode
            RemoveHandler s.NeedsReload_TVShow, AddressOf Handle_NeedsReload_TVShow
            RemoveHandler s.NeedsRestart, AddressOf Handle_NeedsRestart
            RemoveHandler s.SettingsChanged, AddressOf Handle_SettingsChanged
            s.DoDispose()
        Next

        'AddonSettingsPanels
        For Each s As AddonsManager.AddonClass In AddonsManager.Instance.Addons.OrderBy(Function(f) f.AssemblyName)
            RemoveHandler s.Addon.NeedsRestart, AddressOf Handle_NeedsRestart
            RemoveHandler s.Addon.SettingsChanged, AddressOf Handle_SettingsChanged
            RemoveHandler s.Addon.StateChanged, AddressOf Handle_StateChanged
            s.Addon.DoDispose()
        Next
    End Sub

    Private Sub btnFileSystemExcludedDirsAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemExcludedDirsAdd.Click
        If Not String.IsNullOrEmpty(txtFileSystemExcludedDirs.Text) Then
            If Not lstFileSystemExcludedDirs.Items.Contains(txtFileSystemExcludedDirs.Text.ToLower) Then
                AddExcludedDir(txtFileSystemExcludedDirs.Text)
                RefreshFileSystemExcludeDirs()
                txtFileSystemExcludedDirs.Text = String.Empty
                txtFileSystemExcludedDirs.Focus()
            End If
        End If
    End Sub

    Private Sub btnFileSystemExcludedDirsRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemExcludedDirsRemove.Click
        RemoveExcludeDir()
        RefreshFileSystemExcludeDirs()
    End Sub

    Private Sub lstFileSystemExcludedDirs_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstFileSystemExcludedDirs.KeyDown
        If e.KeyCode = Keys.Delete Then
            RemoveExcludeDir()
            RefreshFileSystemExcludeDirs()
        End If
    End Sub

    Private Sub AddExcludedDir(ByVal Path As String)
        Try
            Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                    SQLcommand.CommandText = "INSERT OR REPLACE INTO ExcludeDir (Dirname) VALUES (?);"

                    Dim parDirname As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parDirname", DbType.String, 0, "Dirname")
                    parDirname.Value = Path

                    SQLcommand.ExecuteNonQuery()
                End Using
                SQLtransaction.Commit()
            End Using

            SetApplyButton(True)
            sResult.NeedsDBClean_Movie = True
            sResult.NeedsDBClean_TV = True
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        Finally
            Master.DB.Load_ExcludeDirs()
        End Try
    End Sub

    Private Sub RemoveExcludeDir()
        Try
            If lstFileSystemExcludedDirs.SelectedItems.Count > 0 Then
                lstFileSystemExcludedDirs.BeginUpdate()

                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                        Dim parDirname As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parDirname", DbType.String, 0, "Dirname")
                        While lstFileSystemExcludedDirs.SelectedItems.Count > 0
                            parDirname.Value = lstFileSystemExcludedDirs.SelectedItems(0).ToString
                            SQLcommand.CommandText = String.Concat("DELETE FROM ExcludeDir WHERE Dirname = (?);")
                            SQLcommand.ExecuteNonQuery()
                            lstFileSystemExcludedDirs.Items.Remove(lstFileSystemExcludedDirs.SelectedItems(0))
                        End While
                    End Using
                    SQLtransaction.Commit()
                End Using

                lstFileSystemExcludedDirs.EndUpdate()
                lstFileSystemExcludedDirs.Refresh()

                SetApplyButton(True)
                sResult.NeedsDBUpdate_Movie = True
                sResult.NeedsDBUpdate_TV = True
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        Finally
            Master.DB.Load_ExcludeDirs()
        End Try
    End Sub

    Private Sub btnFileSystemValidVideoExtsAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidVideoExtsAdd.Click
        If Not String.IsNullOrEmpty(txtFileSystemValidVideoExts.Text) Then
            If Not txtFileSystemValidVideoExts.Text.Substring(0, 1) = "." Then txtFileSystemValidVideoExts.Text = String.Concat(".", txtFileSystemValidVideoExts.Text)
            If Not lstFileSystemValidVideoExts.Items.Contains(txtFileSystemValidVideoExts.Text.ToLower) Then
                lstFileSystemValidVideoExts.Items.Add(txtFileSystemValidVideoExts.Text.ToLower)
                SetApplyButton(True)
                sResult.NeedsDBUpdate_Movie = True
                sResult.NeedsDBUpdate_TV = True
                txtFileSystemValidVideoExts.Text = String.Empty
                txtFileSystemValidVideoExts.Focus()
            End If
        End If
    End Sub

    Private Sub btnFileSystemValidSubtitlesExtsAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidSubtitlesExtsAdd.Click
        If Not String.IsNullOrEmpty(txtFileSystemValidSubtitlesExts.Text) Then
            If Not txtFileSystemValidSubtitlesExts.Text.Substring(0, 1) = "." Then txtFileSystemValidSubtitlesExts.Text = String.Concat(".", txtFileSystemValidSubtitlesExts.Text)
            If Not lstFileSystemValidSubtitlesExts.Items.Contains(txtFileSystemValidSubtitlesExts.Text.ToLower) Then
                lstFileSystemValidSubtitlesExts.Items.Add(txtFileSystemValidSubtitlesExts.Text.ToLower)
                SetApplyButton(True)
                sResult.NeedsReload_Movie = True
                sResult.NeedsReload_TVEpisode = True
                txtFileSystemValidSubtitlesExts.Text = String.Empty
                txtFileSystemValidSubtitlesExts.Focus()
            End If
        End If
    End Sub

    Private Sub btnFileSystemValidThemeExtsAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidThemeExtsAdd.Click
        If Not String.IsNullOrEmpty(txtFileSystemValidThemeExts.Text) Then
            If Not txtFileSystemValidThemeExts.Text.Substring(0, 1) = "." Then txtFileSystemValidThemeExts.Text = String.Concat(".", txtFileSystemValidThemeExts.Text)
            If Not lstFileSystemValidThemeExts.Items.Contains(txtFileSystemValidThemeExts.Text.ToLower) Then
                lstFileSystemValidThemeExts.Items.Add(txtFileSystemValidThemeExts.Text.ToLower)
                SetApplyButton(True)
                sResult.NeedsReload_Movie = True
                sResult.NeedsReload_TVShow = True
                txtFileSystemValidThemeExts.Text = String.Empty
                txtFileSystemValidThemeExts.Focus()
            End If
        End If
    End Sub

    Private Sub btnFileSystemNoStackExtsAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemNoStackExtsAdd.Click
        If Not String.IsNullOrEmpty(txtFileSystemNoStackExts.Text) Then
            If Not txtFileSystemNoStackExts.Text.Substring(0, 1) = "." Then txtFileSystemNoStackExts.Text = String.Concat(".", txtFileSystemNoStackExts.Text)
            If Not lstFileSystemNoStackExts.Items.Contains(txtFileSystemNoStackExts.Text) Then
                lstFileSystemNoStackExts.Items.Add(txtFileSystemNoStackExts.Text)
                SetApplyButton(True)
                sResult.NeedsDBUpdate_Movie = True
                sResult.NeedsDBUpdate_TV = True
                txtFileSystemNoStackExts.Text = String.Empty
                txtFileSystemNoStackExts.Focus()
            End If
        End If
    End Sub

    Private Sub btnMovieSetSortTokenAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetSortTokenAdd.Click
        If Not String.IsNullOrEmpty(txtMovieSetSortToken.Text) Then
            If Not lstMovieSetSortTokens.Items.Contains(txtMovieSetSortToken.Text) Then
                lstMovieSetSortTokens.Items.Add(txtMovieSetSortToken.Text)
                sResult.NeedsReload_MovieSet = True
                SetApplyButton(True)
                txtMovieSetSortToken.Text = String.Empty
                txtMovieSetSortToken.Focus()
            End If
        End If
    End Sub

    Private Sub btnFileSystemCleanerWhitelistAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemCleanerWhitelistAdd.Click
        If Not String.IsNullOrEmpty(txtFileSystemCleanerWhitelist.Text) Then
            If Not txtFileSystemCleanerWhitelist.Text.Substring(0, 1) = "." Then txtFileSystemCleanerWhitelist.Text = String.Concat(".", txtFileSystemCleanerWhitelist.Text)
            If Not lstFileSystemCleanerWhitelist.Items.Contains(txtFileSystemCleanerWhitelist.Text.ToLower) Then
                lstFileSystemCleanerWhitelist.Items.Add(txtFileSystemCleanerWhitelist.Text.ToLower)
                SetApplyButton(True)
                txtFileSystemCleanerWhitelist.Text = String.Empty
                txtFileSystemCleanerWhitelist.Focus()
            End If
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApply.Click
        SaveSettings(True)
        SetApplyButton(False)
        If sResult.NeedsDBClean_Movie OrElse
            sResult.NeedsDBClean_TV OrElse
            sResult.NeedsDBUpdate_Movie OrElse
            sResult.NeedsDBUpdate_TV OrElse
            sResult.NeedsReload_Movie OrElse
            sResult.NeedsReload_MovieSet OrElse
            sResult.NeedsReload_TVShow Then _
            didApply = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        If Not didApply Then sResult.DidCancel = True
        Close()
    End Sub

    Private Sub btnTVScraperDefFIExtEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVScraperDefFIExtEdit.Click
        Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.TVEpisode), True)
            Dim fi As New MediaContainers.Fileinfo
            For Each x As Settings.MetadataPerType In TVMeta
                If x.FileType = lstTVScraperDefFIExt.SelectedItems(0).ToString Then
                    fi = dEditMeta.ShowDialog(x.MetaData, True)
                    If Not fi Is Nothing Then
                        TVMeta.Remove(x)
                        Dim m As New Settings.MetadataPerType
                        m.FileType = x.FileType
                        m.MetaData = New MediaContainers.Fileinfo
                        m.MetaData = fi
                        TVMeta.Add(m)
                        LoadTVMetadata()
                        SetApplyButton(True)
                    End If
                    Exit For
                End If
            Next
        End Using
    End Sub

    Private Sub btnTVScraperDefFIExtAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVScraperDefFIExtAdd.Click
        If Not txtTVScraperDefFIExt.Text.StartsWith(".") Then txtTVScraperDefFIExt.Text = String.Concat(".", txtTVScraperDefFIExt.Text)
        Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.TVEpisode), True)
            Dim fi As New MediaContainers.Fileinfo
            fi = dEditMeta.ShowDialog(fi, True)
            If Not fi Is Nothing Then
                Dim m As New Settings.MetadataPerType
                m.FileType = txtTVScraperDefFIExt.Text
                m.MetaData = New MediaContainers.Fileinfo
                m.MetaData = fi
                TVMeta.Add(m)
                LoadTVMetadata()
                SetApplyButton(True)
                txtTVScraperDefFIExt.Text = String.Empty
                txtTVScraperDefFIExt.Focus()
            End If
        End Using
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
        NoUpdate = True
        SaveSettings(False)
        Close()
    End Sub

    Private Sub btnMovieSetGeneralMediaListSortingUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetGeneralMediaListSortingUp.Click
        Try
            If lvMovieSetGeneralMediaListSorting.Items.Count > 0 AndAlso lvMovieSetGeneralMediaListSorting.SelectedItems.Count > 0 AndAlso Not lvMovieSetGeneralMediaListSorting.SelectedItems(0).Index = 0 Then
                Dim selItem As Settings.ListSorting = MovieSetGeneralMediaListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvMovieSetGeneralMediaListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvMovieSetGeneralMediaListSorting.SuspendLayout()
                    Dim iIndex As Integer = MovieSetGeneralMediaListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvMovieSetGeneralMediaListSorting.SelectedIndices(0)
                    MovieSetGeneralMediaListSorting.Remove(selItem)
                    MovieSetGeneralMediaListSorting.Insert(iIndex - 1, selItem)

                    RenumberMovieSetGeneralMediaListSorting()
                    LoadMovieSetGeneralMediaListSorting()

                    If Not selIndex - 3 < 0 Then
                        lvMovieSetGeneralMediaListSorting.TopItem = lvMovieSetGeneralMediaListSorting.Items(selIndex - 3)
                    End If
                    lvMovieSetGeneralMediaListSorting.Items(selIndex - 1).Selected = True
                    lvMovieSetGeneralMediaListSorting.ResumeLayout()
                End If

                SetApplyButton(True)
                lvMovieSetGeneralMediaListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnMovieSetGeneralMediaListSortingDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetGeneralMediaListSortingDown.Click
        Try
            If lvMovieSetGeneralMediaListSorting.Items.Count > 0 AndAlso lvMovieSetGeneralMediaListSorting.SelectedItems.Count > 0 AndAlso lvMovieSetGeneralMediaListSorting.SelectedItems(0).Index < (lvMovieSetGeneralMediaListSorting.Items.Count - 1) Then
                Dim selItem As Settings.ListSorting = MovieSetGeneralMediaListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvMovieSetGeneralMediaListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvMovieSetGeneralMediaListSorting.SuspendLayout()
                    Dim iIndex As Integer = MovieSetGeneralMediaListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvMovieSetGeneralMediaListSorting.SelectedIndices(0)
                    MovieSetGeneralMediaListSorting.Remove(selItem)
                    MovieSetGeneralMediaListSorting.Insert(iIndex + 1, selItem)

                    RenumberMovieSetGeneralMediaListSorting()
                    LoadMovieSetGeneralMediaListSorting()

                    If Not selIndex - 2 < 0 Then
                        lvMovieSetGeneralMediaListSorting.TopItem = lvMovieSetGeneralMediaListSorting.Items(selIndex - 2)
                    End If
                    lvMovieSetGeneralMediaListSorting.Items(selIndex + 1).Selected = True
                    lvMovieSetGeneralMediaListSorting.ResumeLayout()
                End If

                SetApplyButton(True)
                lvMovieSetGeneralMediaListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub lvMovieSetGeneralMediaListSorting_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvMovieSetGeneralMediaListSorting.MouseDoubleClick
        If lvMovieSetGeneralMediaListSorting.Items.Count > 0 AndAlso lvMovieSetGeneralMediaListSorting.SelectedItems.Count > 0 Then
            Dim selItem As Settings.ListSorting = MovieSetGeneralMediaListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvMovieSetGeneralMediaListSorting.SelectedItems(0).Text))

            If selItem IsNot Nothing Then
                lvMovieSetGeneralMediaListSorting.SuspendLayout()
                selItem.Hide = Not selItem.Hide
                Dim topIndex As Integer = lvMovieSetGeneralMediaListSorting.TopItem.Index
                Dim selIndex As Integer = lvMovieSetGeneralMediaListSorting.SelectedIndices(0)

                LoadMovieSetGeneralMediaListSorting()

                lvMovieSetGeneralMediaListSorting.TopItem = lvMovieSetGeneralMediaListSorting.Items(topIndex)
                lvMovieSetGeneralMediaListSorting.Items(selIndex).Selected = True
                lvMovieSetGeneralMediaListSorting.ResumeLayout()
            End If

            SetApplyButton(True)
            lvMovieSetGeneralMediaListSorting.Focus()
        End If
    End Sub

    Private Sub btnFileSystemValidVideoExtsReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidVideoExtsReset.Click
        If MessageBox.Show(Master.eLang.GetString(843, "Are you sure you want to reset to the default list of valid video extensions?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.ValidExts, True)
            RefreshFileSystemValidExts()
            SetApplyButton(True)
        End If
    End Sub

    Private Sub btnFileSystemValidSubtitlesExtsReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidSubtitlesExtsReset.Click
        If MessageBox.Show(Master.eLang.GetString(1283, "Are you sure you want to reset to the default list of valid subtitle extensions?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.ValidSubtitleExts, True)
            RefreshFileSystemValidSubtitlesExts()
            SetApplyButton(True)
        End If
    End Sub

    Private Sub btnFileSystemValidThemeExtsReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidThemeExtsReset.Click
        If MessageBox.Show(Master.eLang.GetString(1080, "Are you sure you want to reset to the default list of valid theme extensions?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.ValidThemeExts, True)
            RefreshFileSystemValidThemeExts()
            SetApplyButton(True)
        End If
    End Sub

    Private Sub btnMovieSetGeneralMediaListSortingReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetGeneralMediaListSortingReset.Click
        Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.MovieSetListSorting, True)
        MovieSetGeneralMediaListSorting.Clear()
        MovieSetGeneralMediaListSorting.AddRange(Master.eSettings.MovieSetGeneralMediaListSorting)
        LoadMovieSetGeneralMediaListSorting()
        SetApplyButton(True)
    End Sub

    Private Sub btnFileSystemValidExtsRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidVideoExtsRemove.Click
        RemoveFileSystemValidExts()
    End Sub

    Private Sub btnFileSystemValidSubtitlesExtsRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidSubtitlesExtsRemove.Click
        RemoveFileSystemValidSubtitlesExts()
    End Sub

    Private Sub btnFileSystemValidThemeExtsRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemValidThemeExtsRemove.Click
        RemoveFileSystemValidThemeExts()
    End Sub

    Private Sub btnFileSystemNoStackExtsRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemNoStackExtsRemove.Click
        RemoveFileSystemNoStackExts()
    End Sub

    Private Sub btnMovieSetSortTokenRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetSortTokenRemove.Click
        RemoveMovieSetSortToken()
    End Sub

    Private Sub btnMovieSetSortTokenReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetSortTokenReset.Click
        Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.MovieSetSortTokens, True)
        RefreshMovieSetSortTokens()
        sResult.NeedsReload_MovieSet = True
        SetApplyButton(True)
    End Sub

    Private Sub btnTVScraperDefFIExtRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVScraperDefFIExtRemove.Click
        RemoveTVMetaData()
    End Sub

    Private Sub btnFileSystemCleanerWhitelistRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFileSystemCleanerWhitelistRemove.Click
        If lstFileSystemCleanerWhitelist.Items.Count > 0 AndAlso lstFileSystemCleanerWhitelist.SelectedItems.Count > 0 Then
            While lstFileSystemCleanerWhitelist.SelectedItems.Count > 0
                lstFileSystemCleanerWhitelist.Items.Remove(lstFileSystemCleanerWhitelist.SelectedItems(0))
            End While
            SetApplyButton(True)
        End If
    End Sub

    Private Sub chkTVScraperShowCert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVScraperShowCert.CheckedChanged
        SetApplyButton(True)

        If Not chkTVScraperShowCert.Checked Then
            cbTVScraperShowCertLang.Enabled = False
            cbTVScraperShowCertLang.SelectedIndex = 0
            chkTVScraperShowCertForMPAA.Enabled = False
            chkTVScraperShowCertForMPAA.Checked = False
            chkTVScraperShowCertFSK.Enabled = False
            chkTVScraperShowCertFSK.Checked = False
            chkTVScraperShowCertOnlyValue.Enabled = False
            chkTVScraperShowCertOnlyValue.Checked = False
        Else
            cbTVScraperShowCertLang.Enabled = True
            cbTVScraperShowCertLang.SelectedIndex = 0
            chkTVScraperShowCertForMPAA.Enabled = True
            chkTVScraperShowCertFSK.Enabled = True
            chkTVScraperShowCertOnlyValue.Enabled = True
        End If
    End Sub

    Private Sub chkTVScraperShowCertForMPAA_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVScraperShowCertForMPAA.CheckedChanged
        SetApplyButton(True)

        If Not chkTVScraperShowCertForMPAA.Checked Then
            chkTVScraperShowCertForMPAAFallback.Enabled = False
            chkTVScraperShowCertForMPAAFallback.Checked = False
        Else
            chkTVScraperShowCertForMPAAFallback.Enabled = True
        End If
    End Sub

    Private Sub chkTVScraperShowRuntime_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVScraperShowRuntime.CheckedChanged
        chkTVScraperUseSRuntimeForEp.Enabled = chkTVScraperShowRuntime.Checked
        If Not chkTVScraperShowRuntime.Checked Then
            chkTVScraperUseSRuntimeForEp.Checked = False
        End If
        SetApplyButton(True)
    End Sub

    Private Sub chkTVScraperUseMDDuration_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVScraperUseMDDuration.CheckedChanged
        txtTVScraperDurationRuntimeFormat.Enabled = chkTVScraperUseMDDuration.Checked
        SetApplyButton(True)
    End Sub

    Private Sub dlgSettings_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        Activate()
    End Sub

    Private Sub FillList(ByVal ePanelType As Enums.SettingsPanelType)
        Dim pNode As New TreeNode
        Dim cNode As New TreeNode

        tvSettingsList.Nodes.Clear()
        RemoveCurrPanel()

        For Each pPanel As Containers.SettingsPanel In _SettingsPanels.Where(Function(s) s.Type = ePanelType AndAlso String.IsNullOrEmpty(s.Parent)).OrderBy(Function(s) s.Order)
            pNode = New TreeNode(pPanel.Title, pPanel.ImageIndex, pPanel.ImageIndex)
            pNode.Name = pPanel.Name
            For Each cPanel As Containers.SettingsPanel In _SettingsPanels.Where(Function(p) p.Type = ePanelType AndAlso p.Parent = pNode.Name).OrderBy(Function(s) s.Order)
                cNode = New TreeNode(cPanel.Title, cPanel.ImageIndex, cPanel.ImageIndex)
                cNode.Name = cPanel.Name
                pNode.Nodes.Add(cNode)
            Next
            tvSettingsList.Nodes.Add(pNode)
        Next

        If tvSettingsList.Nodes.Count > 0 Then
            tvSettingsList.ExpandAll()
            tvSettingsList.SelectedNode = tvSettingsList.Nodes(0)
        Else
            pbSettingsCurrent.Image = Nothing
            lblSettingsCurrent.Text = String.Empty
        End If
    End Sub

    Private Sub FillSettings()


        With Master.eSettings
            cbMovieSetGeneralCustomScrapeButtonModifierType.SelectedValue = .MovieSetGeneralCustomScrapeButtonModifierType
            cbMovieSetGeneralCustomScrapeButtonScrapeType.SelectedValue = .MovieSetGeneralCustomScrapeButtonScrapeType
            chkCleanDotFanartJPG.Checked = .CleanDotFanartJPG
            chkCleanExtrathumbs.Checked = .CleanExtrathumbs
            chkCleanFanartJPG.Checked = .CleanFanartJPG
            chkCleanFolderJPG.Checked = .CleanFolderJPG
            chkCleanMovieFanartJPG.Checked = .CleanMovieFanartJPG
            chkCleanMovieJPG.Checked = .CleanMovieJPG
            chkCleanMovieNFO.Checked = .CleanMovieNFO
            chkCleanMovieNFOb.Checked = .CleanMovieNFOB
            chkCleanMovieNameJPG.Checked = .CleanMovieNameJPG
            chkCleanMovieTBN.Checked = .CleanMovieTBN
            chkCleanMovieTBNb.Checked = .CleanMovieTBNB
            chkCleanPosterJPG.Checked = .CleanPosterJPG
            chkCleanPosterTBN.Checked = .CleanPosterTBN
            chkFileSystemCleanerWhitelist.Checked = .FileSystemCleanerWhitelist
            chkMovieSetClickScrape.Checked = .MovieSetClickScrape
            chkMovieSetClickScrapeAsk.Checked = .MovieSetClickScrapeAsk
            chkMovieSetGeneralMarkNew.Checked = .MovieSetGeneralMarkNew
            chkTVLockEpisodeLanguageA.Checked = .TVLockEpisodeLanguageA
            chkTVLockEpisodeLanguageV.Checked = .TVLockEpisodeLanguageV
            chkTVLockEpisodePlot.Checked = .TVLockEpisodePlot
            chkTVLockEpisodeRating.Checked = .TVLockEpisodeRating
            chkTVLockEpisodeRuntime.Checked = .TVLockEpisodeRuntime
            chkTVLockEpisodeTitle.Checked = .TVLockEpisodeTitle
            chkTVLockEpisodeUserRating.Checked = .TVLockEpisodeUserRating
            chkTVLockSeasonPlot.Checked = .TVLockSeasonPlot
            chkTVLockSeasonTitle.Checked = .TVLockSeasonTitle
            chkTVLockShowCert.Checked = .TVLockShowCert
            chkTVLockShowCreators.Checked = .TVLockShowCreators
            chkTVLockShowGenre.Checked = .TVLockShowGenre
            chkTVLockShowMPAA.Checked = .TVLockShowMPAA
            chkTVLockShowOriginalTitle.Checked = .TVLockShowOriginalTitle
            chkTVLockShowPlot.Checked = .TVLockShowPlot
            chkTVLockShowRating.Checked = .TVLockShowRating
            chkTVLockShowRuntime.Checked = .TVLockShowRuntime
            chkTVLockShowStatus.Checked = .TVLockShowStatus
            chkTVLockShowStudio.Checked = .TVLockShowStudio
            chkTVLockShowTitle.Checked = .TVLockShowTitle
            chkTVLockShowUserRating.Checked = .TVLockShowUserRating
            chkTVScraperCastWithImg.Checked = .TVScraperShowCastWithImgOnly
            chkTVScraperCleanFields.Checked = .TVScraperCleanFields
            chkTVScraperEpisodeActors.Checked = .TVScraperEpisodeActors
            chkTVScraperEpisodeAired.Checked = .TVScraperEpisodeAired
            chkTVScraperEpisodeCredits.Checked = .TVScraperEpisodeCredits
            chkTVScraperEpisodeDirector.Checked = .TVScraperEpisodeDirector
            chkTVScraperEpisodeGuestStars.Checked = .TVScraperEpisodeGuestStars
            chkTVScraperEpisodeGuestStarsToActors.Checked = .TVScraperEpisodeGuestStarsToActors
            chkTVScraperEpisodePlot.Checked = .TVScraperEpisodePlot
            chkTVScraperEpisodeRating.Checked = .TVScraperEpisodeRating
            chkTVScraperEpisodeRuntime.Checked = .TVScraperEpisodeRuntime
            chkTVScraperEpisodeTitle.Checked = .TVScraperEpisodeTitle
            chkTVScraperEpisodeUserRating.Checked = .TVScraperEpisodeUserRating
            chkTVScraperMetaDataScan.Checked = .TVScraperMetaDataScan
            chkTVScraperSeasonAired.Checked = .TVScraperSeasonAired
            chkTVScraperSeasonPlot.Checked = .TVScraperSeasonPlot
            chkTVScraperSeasonTitle.Checked = .TVScraperSeasonTitle
            chkTVScraperShowActors.Checked = .TVScraperShowActors
            chkTVScraperShowCert.Checked = .TVScraperShowCert
            chkTVScraperShowCreators.Checked = .TVScraperShowCreators
            chkTVScraperShowCertForMPAA.Checked = .TVScraperShowCertForMPAA
            chkTVScraperShowCertForMPAAFallback.Checked = .TVScraperShowCertForMPAAFallback
            chkTVScraperShowCertFSK.Checked = .TVScraperShowCertFSK
            chkTVScraperShowCertOnlyValue.Checked = .TVScraperShowCertOnlyValue
            chkTVScraperShowEpiGuideURL.Checked = .TVScraperShowEpiGuideURL
            chkTVScraperShowGenre.Checked = .TVScraperShowGenre
            chkTVScraperShowMPAA.Checked = .TVScraperShowMPAA
            chkTVScraperShowOriginalTitle.Checked = .TVScraperShowOriginalTitle
            chkTVScraperShowPlot.Checked = .TVScraperShowPlot
            chkTVScraperShowPremiered.Checked = .TVScraperShowPremiered
            chkTVScraperShowRating.Checked = .TVScraperShowRating
            chkTVScraperShowRuntime.Checked = .TVScraperShowRuntime
            chkTVScraperShowStatus.Checked = .TVScraperShowStatus
            chkTVScraperShowStudio.Checked = .TVScraperShowStudio
            chkTVScraperShowTitle.Checked = .TVScraperShowTitle
            chkTVScraperShowUserRating.Checked = .TVScraperShowUserRating
            chkTVScraperUseDisplaySeasonEpisode.Checked = .TVScraperUseDisplaySeasonEpisode
            chkTVScraperUseMDDuration.Checked = .TVScraperUseMDDuration
            chkTVScraperUseSRuntimeForEp.Checked = .TVScraperUseSRuntimeForEp
            lstFileSystemCleanerWhitelist.Items.AddRange(.FileSystemCleanerWhitelistExts.ToArray)
            lstFileSystemNoStackExts.Items.AddRange(.FileSystemNoStackExts.ToArray)
            If .MovieSetGeneralCustomScrapeButtonEnabled Then
                rbMovieSetGeneralCustomScrapeButtonEnabled.Checked = True
            Else
                rbMovieSetGeneralCustomScrapeButtonDisabled.Checked = True
            End If
            tcFileSystemCleaner.SelectedTab = If(.FileSystemExpertCleaner, tpFileSystemCleanerExpert, tpFileSystemCleanerStandard)
            txtTVScraperDurationRuntimeFormat.Text = .TVScraperDurationRuntimeFormat.ToString
            txtTVScraperShowMPAANotRated.Text = .TVScraperShowMPAANotRated

            MovieSetGeneralMediaListSorting.AddRange(.MovieSetGeneralMediaListSorting)
            LoadMovieSetGeneralMediaListSorting()

            TVMeta.AddRange(.TVMetadataPerFileType)
            LoadTVMetadata()

            Try
                cbTVScraperShowCertLang.Items.Clear()
                cbTVScraperShowCertLang.Items.Add(Master.eLang.All)
                cbTVScraperShowCertLang.Items.AddRange((From lLang In APIXML.CertLanguagesXML.Language Select lLang.name).ToArray)
                If cbTVScraperShowCertLang.Items.Count > 0 Then
                    If .TVScraperShowCertLang = Master.eLang.All Then
                        cbTVScraperShowCertLang.SelectedIndex = 0
                    ElseIf Not String.IsNullOrEmpty(.TVScraperShowCertLang) Then
                        Dim tLanguage As CertLanguages = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = .TVScraperShowCertLang)
                        If tLanguage IsNot Nothing AndAlso tLanguage.name IsNot Nothing AndAlso Not String.IsNullOrEmpty(tLanguage.name) Then
                            cbTVScraperShowCertLang.Text = tLanguage.name
                        Else
                            cbTVScraperShowCertLang.SelectedIndex = 0
                        End If
                    Else
                        cbTVScraperShowCertLang.SelectedIndex = 0
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try


            chkMovieSetClickScrapeAsk.Enabled = chkMovieSetClickScrape.Checked
            txtTVScraperDurationRuntimeFormat.Enabled = .TVScraperUseMDDuration

            RefreshMovieSetSortTokens()
            RefreshFileSystemExcludeDirs()
            RefreshFileSystemValidExts()
            RefreshFileSystemValidSubtitlesExts()
            RefreshFileSystemValidThemeExts()
        End With
    End Sub

    Private Sub frmSettings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Functions.PNLDoubleBuffer(pnlSettingsMain)
        SetUp()
        _SettingsPanels.Clear()
        AddSettingsPanels()
        AddAddonSettingsPanels()
        AddButtons()
        AddHelpHandlers(Me, "Core_")

        'get optimal panel size
        Dim pWidth As Integer = Width
        Dim pHeight As Integer = Height
        If My.Computer.Screen.WorkingArea.Width < 1120 Then
            pWidth = My.Computer.Screen.WorkingArea.Width
        End If
        If My.Computer.Screen.WorkingArea.Height < 900 Then
            pHeight = My.Computer.Screen.WorkingArea.Height
        End If
        Size = New Size(pWidth, pHeight)
        Dim pLeft As Integer
        Dim pTop As Integer
        pLeft = CInt((My.Computer.Screen.WorkingArea.Width - pWidth) / 2)
        pTop = CInt((My.Computer.Screen.WorkingArea.Height - pHeight) / 2)
        Location = New Point(pLeft, pTop)

        Dim iBackground As New Bitmap(pnlSettingsCurrent.Width, pnlSettingsCurrent.Height)
        Using b As Graphics = Graphics.FromImage(iBackground)
            b.FillRectangle(New Drawing2D.LinearGradientBrush(pnlSettingsCurrent.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlSettingsCurrent.ClientRectangle)
            pnlSettingsCurrent.BackgroundImage = iBackground
        End Using

        FillSettings()
        sResult.NeedsDBClean_Movie = False
        sResult.NeedsDBClean_TV = False
        sResult.NeedsDBUpdate_Movie = False
        sResult.NeedsDBUpdate_TV = False
        sResult.NeedsReload_Movie = False
        sResult.NeedsReload_MovieSet = False
        sResult.NeedsReload_TVEpisode = False
        sResult.NeedsReload_TVShow = False
        sResult.DidCancel = False
        didApply = False
        NoUpdate = False
        RaiseEvent LoadEnd()
    End Sub

    Private Sub Handle_StateChanged(ByVal strAssemblyName As String, ByVal bEnabled As Boolean)
        If Name = "!#RELOAD" Then
            FillSettings()
            Return
        End If
        Dim nSettingsPanel As Containers.SettingsPanel
        SuspendLayout()
        nSettingsPanel = _SettingsPanels.FirstOrDefault(Function(s) s.Name = strAssemblyName)

        If nSettingsPanel IsNot Nothing Then
            nSettingsPanel.ImageIndex = If(bEnabled, 9, 10)
            Dim t() As TreeNode = tvSettingsList.Nodes.Find(strAssemblyName, True)

            If t.Count > 0 Then
                t(0).ImageIndex = If(bEnabled, 9, 10)
                t(0).SelectedImageIndex = If(bEnabled, 9, 10)
                pbSettingsCurrent.Image = ilSettings.Images(If(bEnabled, 9, 10))
            End If
        End If
        ResumeLayout()
        SetApplyButton(True)
    End Sub

    Private Sub Handle_NeedsDBClean_Movie()
        sResult.NeedsDBClean_Movie = True
    End Sub

    Private Sub Handle_NeedsDBClean_TV()
        sResult.NeedsDBClean_TV = True
    End Sub

    Private Sub Handle_NeedsDBUpdate_Movie()
        sResult.NeedsDBUpdate_Movie = True
    End Sub

    Private Sub Handle_NeedsDBUpdate_TV()
        sResult.NeedsDBUpdate_TV = True
    End Sub

    Private Sub Handle_NeedsReload_Movie()
        sResult.NeedsReload_Movie = True
    End Sub

    Private Sub Handle_NeedsReload_MovieSet()
        sResult.NeedsReload_MovieSet = True
    End Sub

    Private Sub Handle_NeedsReload_TVEpisode()
        sResult.NeedsReload_TVEpisode = True
    End Sub

    Private Sub Handle_NeedsReload_TVShow()
        sResult.NeedsReload_TVShow = True
    End Sub

    Private Sub Handle_NeedsRestart()
        sResult.NeedsRestart = True
    End Sub

    Private Sub Handle_SettingsChanged()
        SetApplyButton(True)
    End Sub

    Private Sub HelpMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        lblHelp.Text = dHelp.Item(DirectCast(sender, Control).AccessibleDescription)
    End Sub

    Private Sub HelpMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        lblHelp.Text = String.Empty
    End Sub

    Private Sub LoadMovieSetGeneralMediaListSorting()
        Dim lvItem As ListViewItem
        lvMovieSetGeneralMediaListSorting.Items.Clear()
        For Each rColumn As Settings.ListSorting In MovieSetGeneralMediaListSorting.OrderBy(Function(f) f.DisplayIndex)
            lvItem = New ListViewItem(rColumn.DisplayIndex.ToString)
            lvItem.SubItems.Add(rColumn.Column)
            lvItem.SubItems.Add(Master.eLang.GetString(rColumn.LabelID, rColumn.LabelText))
            lvItem.SubItems.Add(If(rColumn.Hide, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvMovieSetGeneralMediaListSorting.Items.Add(lvItem)
        Next
    End Sub

    Private Sub LoadCustomScraperButtonModifierTypes_MovieSet()
        Dim items As New Dictionary(Of String, Enums.ScrapeModifierType)
        items.Add(Master.eLang.GetString(70, "All Items"), Enums.ScrapeModifierType.All)
        items.Add(Master.eLang.GetString(1060, "Banner Only"), Enums.ScrapeModifierType.MainBanner)
        items.Add(Master.eLang.GetString(1122, "ClearArt Only"), Enums.ScrapeModifierType.MainClearArt)
        items.Add(Master.eLang.GetString(1123, "ClearLogo Only"), Enums.ScrapeModifierType.MainClearLogo)
        items.Add(Master.eLang.GetString(1124, "DiscArt Only"), Enums.ScrapeModifierType.MainDiscArt)
        items.Add(Master.eLang.GetString(73, "Fanart Only"), Enums.ScrapeModifierType.MainFanart)
        items.Add(Master.eLang.GetString(1061, "Landscape Only"), Enums.ScrapeModifierType.MainLandscape)
        items.Add(Master.eLang.GetString(71, "NFO Only"), Enums.ScrapeModifierType.MainNFO)
        items.Add(Master.eLang.GetString(72, "Poster Only"), Enums.ScrapeModifierType.MainPoster)
        cbMovieSetGeneralCustomScrapeButtonModifierType.DataSource = items.ToList
        cbMovieSetGeneralCustomScrapeButtonModifierType.DisplayMember = "Key"
        cbMovieSetGeneralCustomScrapeButtonModifierType.ValueMember = "Value"
    End Sub

    Private Sub LoadCustomScraperButtonScrapeTypes()
        Dim strAll As String = Master.eLang.GetString(68, "All")
        Dim strFilter As String = Master.eLang.GetString(624, "Current Filter")
        Dim strMarked As String = Master.eLang.GetString(48, "Marked")
        Dim strMissing As String = Master.eLang.GetString(40, "Missing Items")
        Dim strNew As String = Master.eLang.GetString(47, "New")

        Dim strAsk As String = Master.eLang.GetString(77, "Ask (Require Input If No Exact Match)")
        Dim strAuto As String = Master.eLang.GetString(69, "Automatic (Force Best Match)")
        Dim strSkip As String = Master.eLang.GetString(1041, "Skip (Skip If More Than One Match)")

        Dim items As New Dictionary(Of String, Enums.ScrapeType)
        items.Add(String.Concat(strAll, " - ", strAuto), Enums.ScrapeType.AllAuto)
        items.Add(String.Concat(strAll, " - ", strAsk), Enums.ScrapeType.AllAsk)
        items.Add(String.Concat(strAll, " - ", strSkip), Enums.ScrapeType.AllSkip)
        items.Add(String.Concat(strMissing, " - ", strAuto), Enums.ScrapeType.MissingAuto)
        items.Add(String.Concat(strMissing, " - ", strAsk), Enums.ScrapeType.MissingAsk)
        items.Add(String.Concat(strMissing, " - ", strSkip), Enums.ScrapeType.MissingSkip)
        items.Add(String.Concat(strNew, " - ", strAuto), Enums.ScrapeType.NewAuto)
        items.Add(String.Concat(strNew, " - ", strAsk), Enums.ScrapeType.NewAsk)
        items.Add(String.Concat(strNew, " - ", strSkip), Enums.ScrapeType.NewSkip)
        items.Add(String.Concat(strMarked, " - ", strAuto), Enums.ScrapeType.MarkedAuto)
        items.Add(String.Concat(strMarked, " - ", strAsk), Enums.ScrapeType.MarkedAsk)
        items.Add(String.Concat(strMarked, " - ", strSkip), Enums.ScrapeType.MarkedSkip)
        items.Add(String.Concat(strFilter, " - ", strAuto), Enums.ScrapeType.FilterAuto)
        items.Add(String.Concat(strFilter, " - ", strAsk), Enums.ScrapeType.FilterAsk)
        items.Add(String.Concat(strFilter, " - ", strSkip), Enums.ScrapeType.FilterSkip)
        cbMovieSetGeneralCustomScrapeButtonScrapeType.DataSource = items.ToList
        cbMovieSetGeneralCustomScrapeButtonScrapeType.DisplayMember = "Key"
        cbMovieSetGeneralCustomScrapeButtonScrapeType.ValueMember = "Value"
    End Sub

    Private Sub LoadTVMetadata()
        lstTVScraperDefFIExt.Items.Clear()
        For Each x As Settings.MetadataPerType In TVMeta
            lstTVScraperDefFIExt.Items.Add(x.FileType)
        Next
    End Sub

    Private Sub lstFileSystemValidExts_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstFileSystemValidVideoExts.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveFileSystemValidExts()
    End Sub

    Private Sub lstFileSystemValidSubtitlesExts_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstFileSystemValidSubtitlesExts.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveFileSystemValidSubtitlesExts()
    End Sub

    Private Sub lstFileSystemValidThemeExts_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstFileSystemValidThemeExts.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveFileSystemValidThemeExts()
    End Sub

    Private Sub lstFileSystemNoStackExts_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstFileSystemNoStackExts.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveFileSystemNoStackExts()
    End Sub

    Private Sub lstMovieSetSortTokens_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstMovieSetSortTokens.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveMovieSetSortToken()
    End Sub

    Private Sub lstTVScraperDefFIExt_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lstTVScraperDefFIExt.DoubleClick
        If lstTVScraperDefFIExt.SelectedItems.Count > 0 Then
            Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.TVEpisode), True)
                Dim fi As New MediaContainers.Fileinfo
                For Each x As Settings.MetadataPerType In TVMeta
                    If x.FileType = lstTVScraperDefFIExt.SelectedItems(0).ToString Then
                        fi = dEditMeta.ShowDialog(x.MetaData, True)
                        If Not fi Is Nothing Then
                            TVMeta.Remove(x)
                            Dim m As New Settings.MetadataPerType
                            m.FileType = x.FileType
                            m.MetaData = New MediaContainers.Fileinfo
                            m.MetaData = fi
                            TVMeta.Add(m)
                            LoadTVMetadata()
                            SetApplyButton(True)
                        End If
                        Exit For
                    End If
                Next
            End Using
        End If
    End Sub

    Private Sub lstTVScraperDefFIExt_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstTVScraperDefFIExt.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveTVMetaData()
    End Sub

    Private Sub lstTVScraperDefFIExt_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstTVScraperDefFIExt.SelectedIndexChanged
        If lstTVScraperDefFIExt.SelectedItems.Count > 0 Then
            btnTVScraperDefFIExtEdit.Enabled = True
            btnTVScraperDefFIExtRemove.Enabled = True
            txtTVScraperDefFIExt.Text = String.Empty
        Else
            btnTVScraperDefFIExtEdit.Enabled = False
            btnTVScraperDefFIExtRemove.Enabled = False
        End If
    End Sub

    Private Sub RefreshHelpStrings(ByVal Language As String)
        For Each sKey As String In dHelp.Keys
            dHelp.Item(sKey) = Master.eLang.GetHelpString(sKey)
        Next
    End Sub

    Private Sub RefreshMovieSetSortTokens()
        lstMovieSetSortTokens.Items.Clear()
        lstMovieSetSortTokens.Items.AddRange(Master.eSettings.MovieSetSortTokens.ToArray)
    End Sub

    Private Sub RefreshFileSystemExcludeDirs()
        lstFileSystemExcludedDirs.Items.Clear()
        lstFileSystemExcludedDirs.Items.AddRange(Master.ExcludedDirs.ToArray)
    End Sub

    Private Sub RefreshFileSystemValidExts()
        lstFileSystemValidVideoExts.Items.Clear()
        lstFileSystemValidVideoExts.Items.AddRange(Master.eSettings.FileSystemValidExts.ToArray)
    End Sub

    Private Sub RefreshFileSystemValidSubtitlesExts()
        lstFileSystemValidSubtitlesExts.Items.Clear()
        lstFileSystemValidSubtitlesExts.Items.AddRange(Master.eSettings.FileSystemValidSubtitlesExts.ToArray)
    End Sub

    Private Sub RefreshFileSystemValidThemeExts()
        lstFileSystemValidThemeExts.Items.Clear()
        lstFileSystemValidThemeExts.Items.AddRange(Master.eSettings.FileSystemValidThemeExts.ToArray)
    End Sub

    Private Sub RemoveCurrPanel()
        If pnlSettingsMain.Controls.Count > 0 Then
            pnlSettingsMain.Controls.Remove(_currpanel)
        End If
    End Sub

    Private Sub RemoveFileSystemValidExts()
        If lstFileSystemValidVideoExts.Items.Count > 0 AndAlso lstFileSystemValidVideoExts.SelectedItems.Count > 0 Then
            While lstFileSystemValidVideoExts.SelectedItems.Count > 0
                lstFileSystemValidVideoExts.Items.Remove(lstFileSystemValidVideoExts.SelectedItems(0))
            End While
            SetApplyButton(True)
            sResult.NeedsDBClean_Movie = True
            sResult.NeedsDBClean_TV = True
        End If
    End Sub

    Private Sub RemoveFileSystemValidSubtitlesExts()
        If lstFileSystemValidSubtitlesExts.Items.Count > 0 AndAlso lstFileSystemValidSubtitlesExts.SelectedItems.Count > 0 Then
            While lstFileSystemValidSubtitlesExts.SelectedItems.Count > 0
                lstFileSystemValidSubtitlesExts.Items.Remove(lstFileSystemValidSubtitlesExts.SelectedItems(0))
            End While
            SetApplyButton(True)
            sResult.NeedsReload_Movie = True
            sResult.NeedsReload_TVEpisode = True
        End If
    End Sub

    Private Sub RemoveFileSystemValidThemeExts()
        If lstFileSystemValidThemeExts.Items.Count > 0 AndAlso lstFileSystemValidThemeExts.SelectedItems.Count > 0 Then
            While lstFileSystemValidThemeExts.SelectedItems.Count > 0
                lstFileSystemValidThemeExts.Items.Remove(lstFileSystemValidThemeExts.SelectedItems(0))
            End While
            SetApplyButton(True)
            sResult.NeedsReload_Movie = True
            sResult.NeedsReload_TVEpisode = True
        End If
    End Sub

    Private Sub RemoveFileSystemNoStackExts()
        If lstFileSystemNoStackExts.Items.Count > 0 AndAlso lstFileSystemNoStackExts.SelectedItems.Count > 0 Then
            While lstFileSystemNoStackExts.SelectedItems.Count > 0
                lstFileSystemNoStackExts.Items.Remove(lstFileSystemNoStackExts.SelectedItems(0))
            End While
            SetApplyButton(True)
            sResult.NeedsDBUpdate_Movie = True
            sResult.NeedsDBUpdate_TV = True
        End If
    End Sub

    Private Sub RemoveMovieSetSortToken()
        If lstMovieSetSortTokens.Items.Count > 0 AndAlso lstMovieSetSortTokens.SelectedItems.Count > 0 Then
            While lstMovieSetSortTokens.SelectedItems.Count > 0
                lstMovieSetSortTokens.Items.Remove(lstMovieSetSortTokens.SelectedItems(0))
            End While
            sResult.NeedsReload_MovieSet = True
            SetApplyButton(True)
        End If
    End Sub

    Private Sub RemoveTVMetaData()
        If lstTVScraperDefFIExt.SelectedItems.Count > 0 Then
            For Each x As Settings.MetadataPerType In TVMeta
                If x.FileType = lstTVScraperDefFIExt.SelectedItems(0).ToString Then
                    TVMeta.Remove(x)
                    LoadTVMetadata()
                    SetApplyButton(True)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub RenumberMovieSetGeneralMediaListSorting()
        For i As Integer = 0 To MovieSetGeneralMediaListSorting.Count - 1
            MovieSetGeneralMediaListSorting(i).DisplayIndex = i
        Next
    End Sub

    Private Sub SaveSettings(ByVal bIsApply As Boolean)
        With Master.eSettings
            .FileSystemNoStackExts.Clear()
            .FileSystemNoStackExts.AddRange(lstFileSystemNoStackExts.Items.OfType(Of String).ToList)
            .FileSystemValidExts.Clear()
            .FileSystemValidExts.AddRange(lstFileSystemValidVideoExts.Items.OfType(Of String).ToList)
            .FileSystemValidSubtitlesExts.Clear()
            .FileSystemValidSubtitlesExts.AddRange(lstFileSystemValidSubtitlesExts.Items.OfType(Of String).ToList)
            .FileSystemValidThemeExts.Clear()
            .FileSystemValidThemeExts.AddRange(lstFileSystemValidThemeExts.Items.OfType(Of String).ToList)
            .MovieSetClickScrape = chkMovieSetClickScrape.Checked
            .MovieSetClickScrapeAsk = chkMovieSetClickScrapeAsk.Checked
            .MovieSetGeneralCustomScrapeButtonEnabled = rbMovieSetGeneralCustomScrapeButtonEnabled.Checked
            .MovieSetGeneralCustomScrapeButtonModifierType = CType(cbMovieSetGeneralCustomScrapeButtonModifierType.SelectedItem, KeyValuePair(Of String, Enums.ScrapeModifierType)).Value
            .MovieSetGeneralCustomScrapeButtonScrapeType = CType(cbMovieSetGeneralCustomScrapeButtonScrapeType.SelectedItem, KeyValuePair(Of String, Enums.ScrapeType)).Value
            .MovieSetGeneralMarkNew = chkMovieSetGeneralMarkNew.Checked
            .MovieSetGeneralMediaListSorting.Clear()
            .MovieSetGeneralMediaListSorting.AddRange(MovieSetGeneralMediaListSorting)
            .MovieSetSortTokens.Clear()
            .MovieSetSortTokens.AddRange(lstMovieSetSortTokens.Items.OfType(Of String).ToList)
            If .MovieSetSortTokens.Count <= 0 Then .MovieSetSortTokensIsEmpty = True
            .TVLockEpisodeLanguageA = chkTVLockEpisodeLanguageA.Checked
            .TVLockEpisodeLanguageV = chkTVLockEpisodeLanguageV.Checked
            .TVLockEpisodePlot = chkTVLockEpisodePlot.Checked
            .TVLockEpisodeRating = chkTVLockEpisodeRating.Checked
            .TVLockEpisodeRuntime = chkTVLockEpisodeRuntime.Checked
            .TVLockEpisodeTitle = chkTVLockEpisodeTitle.Checked
            .TVLockEpisodeUserRating = chkTVLockEpisodeUserRating.Checked
            .TVLockSeasonPlot = chkTVLockSeasonPlot.Checked
            .TVLockSeasonTitle = chkTVLockSeasonTitle.Checked
            .TVLockShowCert = chkTVLockShowCert.Checked
            .TVLockShowCreators = chkTVLockShowCreators.Checked
            .TVLockShowGenre = chkTVLockShowGenre.Checked
            .TVLockShowMPAA = chkTVLockShowMPAA.Checked
            .TVLockShowOriginalTitle = chkTVLockShowOriginalTitle.Checked
            .TVLockShowPlot = chkTVLockShowPlot.Checked
            .TVLockShowRating = chkTVLockShowRating.Checked
            .TVLockShowRuntime = chkTVLockShowRuntime.Checked
            .TVLockShowStatus = chkTVLockShowStatus.Checked
            .TVLockShowStudio = chkTVLockShowStudio.Checked
            .TVLockShowTitle = chkTVLockShowTitle.Checked
            .TVLockShowUserRating = chkTVLockShowUserRating.Checked
            .TVMetadataPerFileType.Clear()
            .TVMetadataPerFileType.AddRange(TVMeta)
            .TVScraperShowCastWithImgOnly = chkTVScraperCastWithImg.Checked
            .TVScraperCleanFields = chkTVScraperCleanFields.Checked
            .TVScraperDurationRuntimeFormat = txtTVScraperDurationRuntimeFormat.Text
            .TVScraperEpisodeActors = chkTVScraperEpisodeActors.Checked
            .TVScraperEpisodeAired = chkTVScraperEpisodeAired.Checked
            .TVScraperEpisodeCredits = chkTVScraperEpisodeCredits.Checked
            .TVScraperEpisodeDirector = chkTVScraperEpisodeDirector.Checked
            .TVScraperEpisodeGuestStars = chkTVScraperEpisodeGuestStars.Checked
            .TVScraperEpisodeGuestStarsToActors = chkTVScraperEpisodeGuestStarsToActors.Checked
            .TVScraperEpisodePlot = chkTVScraperEpisodePlot.Checked
            .TVScraperEpisodeRating = chkTVScraperEpisodeRating.Checked
            .TVScraperEpisodeRuntime = chkTVScraperEpisodeRuntime.Checked
            .TVScraperEpisodeTitle = chkTVScraperEpisodeTitle.Checked
            .TVScraperEpisodeUserRating = chkTVScraperEpisodeUserRating.Checked
            .TVScraperMetaDataScan = chkTVScraperMetaDataScan.Checked
            .TVScraperSeasonAired = chkTVScraperSeasonAired.Checked
            .TVScraperSeasonPlot = chkTVScraperSeasonPlot.Checked
            .TVScraperSeasonTitle = chkTVScraperSeasonTitle.Checked
            .TVScraperShowActors = chkTVScraperShowActors.Checked
            .TVScraperShowCert = chkTVScraperShowCert.Checked
            .TVScraperShowCreators = chkTVScraperShowCreators.Checked
            .TVScraperShowCertForMPAA = chkTVScraperShowCertForMPAA.Checked
            .TVScraperShowCertForMPAAFallback = chkTVScraperShowCertForMPAAFallback.Checked
            .TVScraperShowCertFSK = chkTVScraperShowCertFSK.Checked
            .TVScraperShowCertOnlyValue = chkTVScraperShowCertOnlyValue.Checked
            If Not String.IsNullOrEmpty(cbTVScraperShowCertLang.Text) Then
                If cbTVScraperShowCertLang.SelectedIndex = 0 Then
                    .TVScraperShowCertLang = Master.eLang.All
                Else
                    .TVScraperShowCertLang = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.name = cbTVScraperShowCertLang.Text).abbreviation
                End If
            End If
            .TVScraperShowEpiGuideURL = chkTVScraperShowEpiGuideURL.Checked
            .TVScraperShowGenre = chkTVScraperShowGenre.Checked
            .TVScraperShowMPAA = chkTVScraperShowMPAA.Checked
            .TVScraperShowOriginalTitle = chkTVScraperShowOriginalTitle.Checked
            .TVScraperShowMPAANotRated = txtTVScraperShowMPAANotRated.Text
            .TVScraperShowPlot = chkTVScraperShowPlot.Checked
            .TVScraperShowPremiered = chkTVScraperShowPremiered.Checked
            .TVScraperShowRating = chkTVScraperShowRating.Checked
            .TVScraperShowRuntime = chkTVScraperShowRuntime.Checked
            .TVScraperShowStatus = chkTVScraperShowStatus.Checked
            .TVScraperShowStudio = chkTVScraperShowStudio.Checked
            .TVScraperShowTitle = chkTVScraperShowTitle.Checked
            .TVScraperShowUserRating = chkTVScraperShowUserRating.Checked
            .TVScraperUseDisplaySeasonEpisode = chkTVScraperUseDisplaySeasonEpisode.Checked
            .TVScraperUseMDDuration = chkTVScraperUseMDDuration.Checked
            .TVScraperUseSRuntimeForEp = chkTVScraperUseSRuntimeForEp.Checked

            If tcFileSystemCleaner.SelectedTab.Name = "tpFileSystemCleanerExpert" Then
                .FileSystemExpertCleaner = True
                .CleanFolderJPG = False
                .CleanMovieTBN = False
                .CleanMovieTBNB = False
                .CleanFanartJPG = False
                .CleanMovieFanartJPG = False
                .CleanMovieNFO = False
                .CleanMovieNFOB = False
                .CleanPosterTBN = False
                .CleanPosterJPG = False
                .CleanMovieJPG = False
                .CleanMovieNameJPG = False
                .CleanDotFanartJPG = False
                .CleanExtrathumbs = False
                .FileSystemCleanerWhitelist = chkFileSystemCleanerWhitelist.Checked
                .FileSystemCleanerWhitelistExts.Clear()
                .FileSystemCleanerWhitelistExts.AddRange(lstFileSystemCleanerWhitelist.Items.OfType(Of String).ToList)
            Else
                .FileSystemExpertCleaner = False
                .CleanFolderJPG = chkCleanFolderJPG.Checked
                .CleanMovieTBN = chkCleanMovieTBN.Checked
                .CleanMovieTBNB = chkCleanMovieTBNb.Checked
                .CleanFanartJPG = chkCleanFanartJPG.Checked
                .CleanMovieFanartJPG = chkCleanMovieFanartJPG.Checked
                .CleanMovieNFO = chkCleanMovieNFO.Checked
                .CleanMovieNFOB = chkCleanMovieNFOb.Checked
                .CleanPosterTBN = chkCleanPosterTBN.Checked
                .CleanPosterJPG = chkCleanPosterJPG.Checked
                .CleanMovieJPG = chkCleanMovieJPG.Checked
                .CleanMovieNameJPG = chkCleanMovieNameJPG.Checked
                .CleanDotFanartJPG = chkCleanDotFanartJPG.Checked
                .CleanExtrathumbs = chkCleanExtrathumbs.Checked
                .FileSystemCleanerWhitelist = False
                .FileSystemCleanerWhitelistExts.Clear()
            End If
        End With

        'SettingsPanels 
        For Each s As Interfaces.MasterSettingsPanel In _lstMasterSettingsPanels.OrderBy(Function(f) f.Order)
            Try
                s.SaveSetup()
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        Next

        'AddonSettingsPanels
        For Each s As AddonsManager.AddonClass In AddonsManager.Instance.Addons
            Try
                s.Addon.SaveSetup()
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        Next
        AddonsManager.Instance.SaveSettings()
        Functions.CreateDefaultOptions()
    End Sub

    Private Sub SetApplyButton(ByVal v As Boolean)
        If Not NoUpdate Then btnApply.Enabled = v
    End Sub

    Private Sub SetUp()

        'Actors
        Dim strActors As String = Master.eLang.GetString(231, "Actors")
        lblTVScraperGlobalActors.Text = strActors

        'Add Episode Guest Stars to Actors list
        Dim strAddEPGuestStars As String = Master.eLang.GetString(974, "Add Episode Guest Stars to Actors list")
        chkTVScraperEpisodeGuestStarsToActors.Text = strAddEPGuestStars

        'Add <displayseason> and <displayepisode> to special episodes
        Dim strAddDisplaySE As String = Master.eLang.GetString(976, "Add <displayseason> and <displayepisode> to special episodes")
        chkTVScraperUseDisplaySeasonEpisode.Text = strAddDisplaySE

        'Aired
        Dim strAired As String = Master.eLang.GetString(728, "Aired")
        lblTVScraperGlobalAired.Text = strAired

        'Also Get Blank Images
        Dim strAlsoGetBlankImages As String = Master.eLang.GetString(1207, "Also Get Blank Images")

        'Also Get English Images
        Dim strAlsoGetEnglishImages As String = Master.eLang.GetString(737, "Also Get English Images")

        'Ask On Click Scrape
        Dim strAskOnClickScrape As String = Master.eLang.GetString(852, "Ask On Click Scrape")
        chkMovieSetClickScrapeAsk.Text = strAskOnClickScrape

        'Certifications
        Dim strCertifications As String = Master.eLang.GetString(56, "Certifications")
        gbTVScraperCertificationOpts.Text = strCertifications
        lblTVScraperGlobalCertifications.Text = strCertifications

        'Cleanup disabled fields
        Dim strCleanUpDisabledFileds As String = Master.eLang.GetString(125, "Cleanup disabled fields")
        chkTVScraperCleanFields.Text = strCleanUpDisabledFileds

        'Column
        Dim strColumn As String = Master.eLang.GetString(1331, "Column")
        colMovieSetGeneralMediaListSortingLabel.Text = strColumn

        'Creators
        Dim strCreators As String = Master.eLang.GetString(744, "Creators")
        lblTVScraperGlobalCreators.Text = strCreators

        'Defaults by File Type
        Dim strDefaultsByFileType As String = Master.eLang.GetString(625, "Defaults by File Type")
        gbTVScraperDefFIExtOpts.Text = strDefaultsByFileType

        'Directors
        Dim strDirectors As String = Master.eLang.GetString(940, "Directors")
        lblTVScraperGlobalDirectors.Text = strDirectors

        'DiscArt
        Dim strDiscArt As String = Master.eLang.GetString(1098, "DiscArt")

        'Duration Format
        Dim strDurationFormat As String = Master.eLang.GetString(515, "Duration Format")
        gbTVScraperDurationFormatOpts.Text = strDurationFormat

        'Duration Runtime Format
        Dim strDurationRuntimeFormat As String = String.Format(Master.eLang.GetString(732, "<h>=Hours{0}<m>=Minutes{0}<s>=Seconds"), Environment.NewLine)
        lblTVScraperDurationRuntimeFormat.Text = strDurationRuntimeFormat

        'Enabled Click Scrape
        Dim strEnabledClickScrape As String = Master.eLang.GetString(849, "Enable Click Scrape")
        chkMovieSetClickScrape.Text = strEnabledClickScrape

        'Episode Guide URL
        Dim strEpisodeGuideURL As String = Master.eLang.GetString(723, "Episode Guide URL")
        lblTVScraperGlobalEpisodeGuideURL.Text = strEpisodeGuideURL

        'Episodes
        Dim strEpisodes As String = Master.eLang.GetString(682, "Episodes")
        lblTVScraperGlobalHeaderEpisodes.Text = strEpisodes

        'File Type
        Dim strFileType As String = String.Concat(Master.eLang.GetString(626, "File Type"), ":")
        lblTVScraperDefFIExt.Text = strFileType

        'Genres
        Dim strGenres As String = Master.eLang.GetString(725, "Genres")
        lblTVScraperGlobalGenres.Text = strGenres

        'Hide
        Dim strHide As String = Master.eLang.GetString(465, "Hide")
        colMovieSetGeneralMediaListSortingHide.Text = strHide

        'Language (Audio)
        Dim strLanguageAudio As String = Master.eLang.GetString(431, "Language (Audio)")
        lblTVScraperGlobalLanguageA.Text = strLanguageAudio

        'Language (Video)
        Dim strLanguageVideo As String = Master.eLang.GetString(435, "Language (Video)")
        lblTVScraperGlobalLanguageV.Text = strLanguageVideo

        'Lock
        Dim strLock As String = Master.eLang.GetString(24, "Lock")
        lblTVScraperGlobalHeaderEpisodesLock.Text = strLock
        lblTVScraperGlobalHeaderSeasonsLock.Text = strLock
        lblTVScraperGlobalHeaderShowsLock.Text = strLock

        'Meta Data
        Dim strMetaData As String = Master.eLang.GetString(59, "Meta Data")
        gbTVScraperMetaDataOpts.Text = strMetaData

        'Miscellaneous
        Dim strMiscellaneous As String = Master.eLang.GetString(429, "Miscellaneous")
        gbMovieSetGeneralMiscOpts.Text = strMiscellaneous
        gbTVScraperMiscOpts.Text = strMiscellaneous

        'Missing
        Dim strMissing As String = Master.eLang.GetString(582, "Missing")

        'MPAA
        Dim strMPAA As String = Master.eLang.GetString(401, "MPAA")
        lblTVScraperGlobalMPAA.Text = strMPAA

        'MPAA value if no rating is available
        Dim strMPAANotRated As String = Master.eLang.GetString(832, "MPAA value if no rating is available")
        lblTVScraperShowMPAANotRated.Text = strMPAANotRated

        'MovieSet List Sorting
        Dim strMovieSetListSorting As String = Master.eLang.GetString(491, "MovieSet List Sorting")
        gbMovieSetGeneralMediaListSorting.Text = strMovieSetListSorting

        'Only if no MPAA is found
        Dim strOnlyIfNoMPAA As String = Master.eLang.GetString(1293, "Only if no MPAA is found")
        chkTVScraperShowCertForMPAAFallback.Text = strOnlyIfNoMPAA

        'Only Save the Value to NFO
        Dim strOnlySaveValueToNFO As String = Master.eLang.GetString(835, "Only Save the Value to NFO")
        chkTVScraperShowCertOnlyValue.Text = strOnlySaveValueToNFO

        'Part of a MovieSet
        Dim strPartOfAMovieSet As String = Master.eLang.GetString(1295, "Part of a MovieSet")

        'Plot
        Dim strPlot As String = Master.eLang.GetString(65, "Plot")
        lblTVScraperGlobalPlot.Text = strPlot

        'Premiered
        Dim strPremiered As String = Master.eLang.GetString(724, "Premiered")
        lblTVScraperGlobalPremiered.Text = strPremiered

        'Rating
        Dim strRating As String = Master.eLang.GetString(400, "Rating")
        lblTVScraperGlobalRating.Text = strRating

        'Runtime
        Dim strRuntime As String = Master.eLang.GetString(396, "Runtime")
        lblTVScraperGlobalRuntime.Text = strRuntime

        'Scrape Only Actors With Images
        Dim strScraperCastWithImg As String = Master.eLang.GetString(510, "Scrape Only Actors With Images")
        chkTVScraperCastWithImg.Text = strScraperCastWithImg

        'Seasons
        Dim strSeasons As String = Master.eLang.GetString(681, "Seasons")
        lblTVScraperGlobalHeaderSeasons.Text = strSeasons


        'Shows
        Dim strShows As String = Master.eLang.GetString(680, "Shows")
        lblTVScraperGlobalHeaderShows.Text = strShows

        'Sort Tokens to Ignore
        Dim strSortTokens As String = Master.eLang.GetString(463, "Sort Tokens to Ignore")
        gbMovieSetGeneralMediaListSortTokensOpts.Text = strSortTokens

        'Status
        Dim strStatus As String = Master.eLang.GetString(215, "Status")
        lblTVScraperGlobalStatus.Text = strStatus

        'Studios
        Dim strStudio As String = Master.eLang.GetString(226, "Studios")
        lblTVScraperGlobalStudios.Text = strStudio

        'Subtitles
        Dim strSubtitles As String = Master.eLang.GetString(152, "Subtitles")

        'Theme
        Dim strTheme As String = Master.eLang.GetString(1118, "Theme")

        'Title
        Dim strTitle As String = Master.eLang.GetString(21, "Title")
        lblTVScraperGlobalTitle.Text = strTitle

        'Use
        Dim strUse As String = Master.eLang.GetString(872, "Use")

        'Use Certification for MPAA
        Dim strUseCertForMPAA As String = Master.eLang.GetString(511, "Use Certification for MPAA")
        chkTVScraperShowCertForMPAA.Text = strUseCertForMPAA

        Dim strUserRating As String = Master.eLang.GetString(1464, "User Rating")
        lblTVScraperGlobalUserRating.Text = strUserRating

        'Watched
        Dim strWatched As String = Master.eLang.GetString(981, "Watched")

        'Writers
        Dim strWriters As String = Master.eLang.GetString(394, "Writers")
        lblTVScraperGlobalCredits.Text = strWriters

        'Year
        Dim strYear As String = Master.eLang.GetString(278, "Year")

        Text = Master.eLang.GetString(420, "Settings")
        btnApply.Text = Master.eLang.GetString(276, "Apply")
        btnCancel.Text = Master.eLang.GetString(167, "Cancel")
        btnOK.Text = Master.eLang.GetString(179, "OK")
        chkFileSystemCleanerWhitelist.Text = Master.eLang.GetString(440, "Whitelist Video Extensions")
        chkMovieSetGeneralMarkNew.Text = Master.eLang.GetString(1301, "Mark New MovieSets")
        chkTVScraperEpisodeGuestStarsToActors.Text = Master.eLang.GetString(974, "Add Episode Guest Stars to Actors list")
        chkTVScraperUseMDDuration.Text = Master.eLang.GetString(516, "Use Duration for Runtime")
        chkTVScraperUseSRuntimeForEp.Text = Master.eLang.GetString(1262, "Use Show Runtime for Episodes if no Episode Runtime can be found")
        gbFileSystemExcludedDirs.Text = Master.eLang.GetString(1273, "Excluded Directories")
        gbFileSystemCleanFiles.Text = Master.eLang.GetString(437, "Clean Files")
        gbFileSystemNoStackExts.Text = Master.eLang.GetString(530, "No Stack Extensions")
        gbFileSystemValidVideoExts.Text = Master.eLang.GetString(534, "Valid Video Extensions")
        gbFileSystemValidSubtitlesExts.Text = Master.eLang.GetString(1284, "Valid Subtitles Extensions")
        gbFileSystemValidThemeExts.Text = Master.eLang.GetString(1081, "Valid Theme Extensions")
        gbSettingsHelp.Text = String.Concat("     ", Master.eLang.GetString(458, "Help"))
        gbTVScraperDurationFormatOpts.Text = Master.eLang.GetString(515, "Duration Format")
        lblFileSystemCleanerWarning.Text = Master.eLang.GetString(442, "WARNING: Using the Expert Mode Cleaner could potentially delete wanted files. Take care when using this tool.")
        lblFileSystemCleanerWhitelist.Text = Master.eLang.GetString(441, "Whitelisted Extensions:")
        lblTVScraperGlobalGuestStars.Text = Master.eLang.GetString(508, "Guest Stars")
        tpFileSystemCleanerExpert.Text = Master.eLang.GetString(439, "Expert")
        tpFileSystemCleanerStandard.Text = Master.eLang.GetString(438, "Standard")

        'items with text from other items
        chkTVScraperMetaDataScan.Text = Master.eLang.GetString(517, "Scan Meta Data")
        gbMovieSetGeneralMediaListOpts.Text = Master.eLang.GetString(460, "Media List Options")
        gbTVScraperDefFIExtOpts.Text = gbTVScraperDefFIExtOpts.Text

        LoadCustomScraperButtonModifierTypes_MovieSet()
        LoadCustomScraperButtonScrapeTypes()
    End Sub

    Private Sub ToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        _currbutton = DirectCast(DirectCast(sender, ToolStripButton).Tag, ButtonTag)
        FillList(_currbutton.ePanelType)
    End Sub

    Private Sub tvSettingsList_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvSettingsList.AfterSelect
        If Not tvSettingsList.SelectedNode.ImageIndex = -1 Then
            pbSettingsCurrent.Image = ilSettings.Images(tvSettingsList.SelectedNode.ImageIndex)
        Else
            pbSettingsCurrent.Image = Nothing
        End If
        lblSettingsCurrent.Text = String.Format("{0} - {1}", _currbutton.strTitle, tvSettingsList.SelectedNode.Text)

        RemoveCurrPanel()

        _currpanel = _SettingsPanels.FirstOrDefault(Function(p) p.Name = tvSettingsList.SelectedNode.Name).Panel
        _currpanel.Location = New Point(0, 0)
        _currpanel.Dock = DockStyle.Fill
        pnlSettingsMain.Controls.Add(_currpanel)
        _currpanel.Visible = True
        pnlSettingsMain.Refresh()
    End Sub

    Private Sub txtTVScraperDefFIExt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTVScraperDefFIExt.TextChanged
        btnTVScraperDefFIExtAdd.Enabled = Not String.IsNullOrEmpty(txtTVScraperDefFIExt.Text) AndAlso Not lstTVScraperDefFIExt.Items.Contains(If(txtTVScraperDefFIExt.Text.StartsWith("."), txtTVScraperDefFIExt.Text, String.Concat(".", txtTVScraperDefFIExt.Text)))
        If btnTVScraperDefFIExtAdd.Enabled Then
            btnTVScraperDefFIExtEdit.Enabled = False
            btnTVScraperDefFIExtRemove.Enabled = False
        End If
    End Sub

    Class ListViewItemComparer
        Implements IComparer
        Private col As Integer

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End Function
    End Class

    Private Sub chkMovieSetClickScrape_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieSetClickScrape.CheckedChanged
        chkMovieSetClickScrapeAsk.Enabled = chkMovieSetClickScrape.Checked
        SetApplyButton(True)
    End Sub

    Private Sub rbMovieSetGeneralCustomScrapeButtonDisabled_CheckedChanged(sender As Object, e As EventArgs) Handles rbMovieSetGeneralCustomScrapeButtonDisabled.CheckedChanged
        If rbMovieSetGeneralCustomScrapeButtonDisabled.Checked Then
            cbMovieSetGeneralCustomScrapeButtonModifierType.Enabled = False
            cbMovieSetGeneralCustomScrapeButtonScrapeType.Enabled = False
            txtMovieSetGeneralCustomScrapeButtonModifierType.Enabled = False
            txtMovieSetGeneralCustomScrapeButtonScrapeType.Enabled = False
        End If
        SetApplyButton(True)
    End Sub

    Private Sub rbMovieSetGeneralCustomScrapeButtonEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles rbMovieSetGeneralCustomScrapeButtonEnabled.CheckedChanged
        If rbMovieSetGeneralCustomScrapeButtonEnabled.Checked Then
            cbMovieSetGeneralCustomScrapeButtonModifierType.Enabled = True
            cbMovieSetGeneralCustomScrapeButtonScrapeType.Enabled = True
            txtMovieSetGeneralCustomScrapeButtonModifierType.Enabled = True
            txtMovieSetGeneralCustomScrapeButtonScrapeType.Enabled = True
        End If
        SetApplyButton(True)
    End Sub

    Private Sub EnableApplyButton(ByVal sender As Object, ByVal e As EventArgs) Handles _
        cbMovieSetGeneralCustomScrapeButtonModifierType.SelectedIndexChanged,
        cbMovieSetGeneralCustomScrapeButtonScrapeType.SelectedIndexChanged,
        chkCleanDotFanartJPG.CheckedChanged,
        chkCleanExtrathumbs.CheckedChanged,
        chkCleanFanartJPG.CheckedChanged,
        chkCleanFolderJPG.CheckedChanged,
        chkCleanMovieFanartJPG.CheckedChanged,
        chkCleanMovieJPG.CheckedChanged,
        chkCleanMovieNFO.CheckedChanged,
        chkCleanMovieNFOb.CheckedChanged,
        chkCleanMovieNameJPG.CheckedChanged,
        chkCleanMovieTBN.CheckedChanged,
        chkCleanMovieTBNb.CheckedChanged,
        chkCleanPosterJPG.CheckedChanged,
        chkCleanPosterTBN.CheckedChanged,
        chkFileSystemCleanerWhitelist.CheckedChanged,
        chkMovieSetClickScrapeAsk.CheckedChanged,
        chkMovieSetGeneralMarkNew.CheckedChanged,
        chkTVLockEpisodeLanguageA.CheckedChanged,
        chkTVLockEpisodeLanguageV.CheckedChanged,
        chkTVLockEpisodePlot.CheckedChanged,
        chkTVLockEpisodeRating.CheckedChanged,
        chkTVLockEpisodeRuntime.CheckedChanged,
        chkTVLockEpisodeTitle.CheckedChanged,
        chkTVLockEpisodeUserRating.CheckedChanged,
        chkTVLockSeasonPlot.CheckedChanged,
        chkTVLockSeasonTitle.CheckedChanged,
        chkTVLockShowCert.CheckedChanged,
        chkTVLockShowCreators.CheckedChanged,
        chkTVLockShowGenre.CheckedChanged,
        chkTVLockShowMPAA.CheckedChanged,
        chkTVLockShowOriginalTitle.CheckedChanged,
        chkTVLockShowPlot.CheckedChanged,
        chkTVLockShowRating.CheckedChanged,
        chkTVLockShowRuntime.CheckedChanged,
        chkTVLockShowStatus.CheckedChanged,
        chkTVLockShowStudio.CheckedChanged,
        chkTVLockShowTitle.CheckedChanged,
        chkTVLockShowUserRating.CheckedChanged,
        chkTVScraperCleanFields.CheckedChanged,
        chkTVScraperEpisodeActors.CheckedChanged,
        chkTVScraperEpisodeAired.CheckedChanged,
        chkTVScraperEpisodeCredits.CheckedChanged,
        chkTVScraperEpisodeDirector.CheckedChanged,
        chkTVScraperEpisodeGuestStars.CheckedChanged,
        chkTVScraperEpisodeGuestStarsToActors.CheckedChanged,
        chkTVScraperEpisodePlot.CheckedChanged,
        chkTVScraperEpisodeRating.CheckedChanged,
        chkTVScraperEpisodeRuntime.CheckedChanged,
        chkTVScraperEpisodeTitle.CheckedChanged,
        chkTVScraperEpisodeUserRating.CheckedChanged,
        chkTVScraperSeasonAired.CheckedChanged,
        chkTVScraperSeasonPlot.CheckedChanged,
        chkTVScraperSeasonTitle.CheckedChanged,
        chkTVScraperShowActors.CheckedChanged,
        chkTVScraperShowCreators.CheckedChanged,
        chkTVScraperShowEpiGuideURL.CheckedChanged,
        chkTVScraperShowGenre.CheckedChanged,
        chkTVScraperShowMPAA.CheckedChanged,
        chkTVScraperShowOriginalTitle.CheckedChanged,
        chkTVScraperShowPlot.CheckedChanged,
        chkTVScraperShowPremiered.CheckedChanged,
        chkTVScraperShowRating.CheckedChanged,
        chkTVScraperShowStatus.CheckedChanged,
        chkTVScraperShowStudio.CheckedChanged,
        chkTVScraperShowTitle.CheckedChanged,
        chkTVScraperShowUserRating.CheckedChanged,
        chkTVScraperUseDisplaySeasonEpisode.CheckedChanged,
        chkTVScraperUseSRuntimeForEp.CheckedChanged,
        tcFileSystemCleaner.SelectedIndexChanged,
        txtTVScraperDurationRuntimeFormat.TextChanged, chkTVScraperCastWithImg.CheckedChanged

        SetApplyButton(True)
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Private Structure ButtonTag

        Dim iIndex As Integer
        Dim strTitle As String
        Dim ePanelType As Enums.SettingsPanelType

    End Structure

#End Region 'Nested Types

End Class