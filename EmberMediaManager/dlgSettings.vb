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

Public Class dlgSettings

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _currpanel As New Panel
    Private _currbutton As New ButtonTag
    Private dHelp As New Dictionary(Of String, String)
    Private didApply As Boolean = False
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
              .Tag = New ButtonTag With {.ePanelType = Enums.SettingsPanelType.Movieset, .iIndex = 300, .strTitle = Master.eLang.GetString(1203, "MovieSets")}}
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
             .Name = "pnlTVData",
             .Title = Master.eLang.GetString(556, "Data"),
             .ImageIndex = 3,
             .Type = Enums.SettingsPanelType.TV,
             .Panel = pnlTVScraper,
             .Order = 400})

        _lstMasterSettingsPanels.Add(frmMovie_Data)
        _lstMasterSettingsPanels.Add(frmMovie_FileNaming)
        _lstMasterSettingsPanels.Add(frmMovie_GUI)
        _lstMasterSettingsPanels.Add(frmMovie_Image)
        _lstMasterSettingsPanels.Add(frmMovie_Theme)
        _lstMasterSettingsPanels.Add(frmMovie_Trailer)
        _lstMasterSettingsPanels.Add(frmMovie_Source)
        _lstMasterSettingsPanels.Add(frmMovieSet_Data)
        _lstMasterSettingsPanels.Add(frmMovieSet_FileNaming)
        _lstMasterSettingsPanels.Add(frmMovieSet_GUI)
        _lstMasterSettingsPanels.Add(frmMovieSet_Image)
        _lstMasterSettingsPanels.Add(frmOption_FileSystem)
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

    Private Sub btnTVScraperDefFIExtRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVScraperDefFIExtRemove.Click
        RemoveTVMetaData()
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
            chkTVScraperEpisodeGuestStarsToActors.Checked = .TVScraperEpisodeGuestStarsToActors
            With Master.eSettings.TV.DataSettings
                chkTVScraperMetaDataScan.Checked = .MetaDataScan
                txtTVScraperDurationRuntimeFormat.Text = .DurationFormat
                chkTVScraperUseMDDuration.Checked = .DurationForRuntime
            End With
            With Master.eSettings.TV.DataSettings.TVEpisode
                chkTVLockEpisodeLanguageA.Checked = .LockAudioLanguage
                chkTVLockEpisodeLanguageV.Checked = .LockVideoLanguage
                chkTVLockEpisodePlot.Checked = .Plot.Locked
                chkTVLockEpisodeRating.Checked = .Rating.Locked
                chkTVLockEpisodeRuntime.Checked = .Runtime.Locked
                chkTVLockEpisodeTitle.Checked = .Title.Locked
                chkTVLockEpisodeUserRating.Checked = .UserRating.Locked
                chkTVScraperEpisodeActors.Checked = .Actors.Enabled
                chkTVScraperEpisodeAired.Checked = .Aired.Enabled
                chkTVScraperEpisodeCredits.Checked = .Credits.Enabled
                chkTVScraperEpisodeDirector.Checked = .Directors.Enabled
                chkTVScraperEpisodeGuestStars.Checked = .GuestStars.Enabled
                chkTVScraperEpisodePlot.Checked = .Plot.Enabled
                chkTVScraperEpisodeRating.Checked = .Rating.Enabled
                chkTVScraperEpisodeRuntime.Checked = .Runtime.Enabled
                chkTVScraperEpisodeTitle.Checked = .Title.Enabled
                chkTVScraperEpisodeUserRating.Checked = .UserRating.Enabled
            End With
            With Master.eSettings.TV.DataSettings.TVSeason
                chkTVLockSeasonPlot.Checked = .Plot.Locked
                chkTVLockSeasonTitle.Checked = .Title.Locked
                chkTVScraperSeasonAired.Checked = .Aired.Enabled
                chkTVScraperSeasonPlot.Checked = .Plot.Enabled
                chkTVScraperSeasonTitle.Checked = .Title.Enabled
            End With
            With Master.eSettings.TV.DataSettings.TVShow
                chkTVScraperCleanFields.Checked = .ClearDisabledFields
                chkTVLockShowCert.Checked = .Certifications.Locked
                chkTVLockShowCreators.Checked = .Creators.Locked
                chkTVLockShowGenre.Checked = .Genres.Locked
                chkTVLockShowMPAA.Checked = .MPAA.Locked
                chkTVLockShowOriginalTitle.Checked = .OriginalTitle.Locked
                chkTVLockShowPlot.Checked = .Plot.Locked
                chkTVLockShowRating.Checked = .Rating.Locked
                chkTVLockShowRuntime.Checked = .Runtime.Locked
                chkTVLockShowStatus.Checked = .Status.Locked
                chkTVLockShowStudio.Checked = .Status.Locked
                chkTVLockShowTitle.Checked = .Title.Locked
                chkTVLockShowUserRating.Checked = .UserRating.Locked
                chkTVScraperShowActors.Checked = .Actors.Enabled
                chkTVScraperShowCert.Checked = .Certifications.Enabled
                chkTVScraperShowCreators.Checked = .Creators.Enabled
                chkTVScraperShowEpiGuideURL.Checked = .EpisodeGuideURL.Enabled
                chkTVScraperShowGenre.Checked = .Genres.Enabled
                chkTVScraperShowMPAA.Checked = .MPAA.Enabled
                chkTVScraperShowOriginalTitle.Checked = .OriginalTitle.Enabled
                chkTVScraperShowPlot.Checked = .Plot.Enabled
                chkTVScraperShowPremiered.Checked = .Premiered.Enabled
                chkTVScraperShowRating.Checked = .Rating.Enabled
                chkTVScraperShowRuntime.Checked = .Runtime.Enabled
                chkTVScraperShowStatus.Checked = .Status.Enabled
                chkTVScraperShowStudio.Checked = .Studios.Enabled
                chkTVScraperShowTitle.Checked = .Tags.Enabled
                chkTVScraperShowUserRating.Checked = .UserRating.Enabled
                txtTVScraperShowMPAANotRated.Text = .MPAANotRatedValue
                chkTVScraperShowCertForMPAA.Checked = .CertificationsForMPAA
                chkTVScraperShowCertForMPAAFallback.Checked = .CertificationsForMPAAFallback
                chkTVScraperShowCertOnlyValue.Checked = .CertificationsOnlyValue
                chkTVScraperCastWithImg.Checked = .ActorsWithImageOnly

                Try
                    cbTVScraperShowCertLang.Items.Clear()
                    cbTVScraperShowCertLang.Items.Add(Master.eLang.All)
                    cbTVScraperShowCertLang.Items.AddRange((From lLang In APIXML.CertLanguagesXML.Language Select lLang.name).ToArray)
                    If cbTVScraperShowCertLang.Items.Count > 0 Then
                        If .Certifications.Filter = Master.eLang.All Then
                            cbTVScraperShowCertLang.SelectedIndex = 0
                        ElseIf Not String.IsNullOrEmpty(.Certifications.Filter) Then
                            Dim tLanguage As CertLanguages = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = .Certifications.Filter)
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
            End With
            chkTVScraperUseDisplaySeasonEpisode.Checked = .TVScraperUseDisplaySeasonEpisode
            chkTVScraperUseSRuntimeForEp.Checked = .TVScraperUseSRuntimeForEp

            TVMeta.AddRange(.TVMetadataPerFileType)
            LoadTVMetadata()
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

    Private Sub LoadTVMetadata()
        lstTVScraperDefFIExt.Items.Clear()
        For Each x As Settings.MetadataPerType In TVMeta
            lstTVScraperDefFIExt.Items.Add(x.FileType)
        Next
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

    Private Sub RemoveCurrPanel()
        If pnlSettingsMain.Controls.Count > 0 Then
            pnlSettingsMain.Controls.Remove(_currpanel)
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

    Private Sub SaveSettings(ByVal bIsApply As Boolean)
        With Master.eSettings.TV.DataSettings
            .DurationForRuntime = chkTVScraperUseMDDuration.Checked
            .DurationFormat = txtTVScraperDurationRuntimeFormat.Text
            .MetaDataScan = chkTVScraperMetaDataScan.Checked
        End With
        With Master.eSettings.TV.DataSettings.TVEpisode
            .Actors.Enabled = chkTVScraperEpisodeActors.Checked
            .Aired.Enabled = chkTVScraperEpisodeAired.Checked
            .Credits.Enabled = chkTVScraperEpisodeCredits.Checked
            .Directors.Enabled = chkTVScraperEpisodeDirector.Checked
            .GuestStars.Enabled = chkTVScraperEpisodeGuestStars.Checked
            .LockAudioLanguage = chkTVLockEpisodeLanguageA.Checked
            .LockVideoLanguage = chkTVLockEpisodeLanguageV.Checked
            .Plot.Enabled = chkTVScraperEpisodePlot.Checked
            .Plot.Locked = chkTVLockEpisodePlot.Checked
            .Rating.Enabled = chkTVScraperEpisodeRating.Checked
            .Rating.Locked = chkTVLockEpisodeRating.Checked
            .Runtime.Enabled = chkTVScraperEpisodeRuntime.Checked
            .Runtime.Locked = chkTVLockEpisodeRuntime.Checked
            .Title.Enabled = chkTVScraperEpisodeTitle.Checked
            .Title.Locked = chkTVLockEpisodeTitle.Checked
            .UserRating.Enabled = chkTVScraperEpisodeUserRating.Checked
            .UserRating.Locked = chkTVLockEpisodeUserRating.Checked
        End With
        With Master.eSettings.TV.DataSettings.TVSeason
            .Aired.Enabled = chkTVScraperSeasonAired.Checked
            .Plot.Enabled = chkTVScraperSeasonPlot.Checked
            .Plot.Locked = chkTVLockSeasonPlot.Checked
            .Title.Enabled = chkTVScraperSeasonTitle.Checked
            .Title.Locked = chkTVLockSeasonTitle.Checked
        End With
        With Master.eSettings.TV.DataSettings.TVShow
            .ClearDisabledFields = chkTVScraperCleanFields.Checked
            .Actors.Enabled = chkTVScraperShowActors.Checked
            .ActorsWithImageOnly = chkTVScraperCastWithImg.Checked
            .Certifications.Enabled = chkTVScraperShowCert.Checked
            .Certifications.Locked = chkTVLockShowCert.Checked
            If Not String.IsNullOrEmpty(cbTVScraperShowCertLang.Text) Then
                If cbTVScraperShowCertLang.SelectedIndex = 0 Then
                    .Certifications.Filter = Master.eLang.All
                Else
                    .Certifications.Filter = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.name = cbTVScraperShowCertLang.Text).abbreviation
                End If
            End If
            .CertificationsForMPAA = chkTVScraperShowCertForMPAA.Checked
            .CertificationsForMPAAFallback = chkTVScraperShowCertForMPAAFallback.Checked
            .CertificationsOnlyValue = chkTVScraperShowCertOnlyValue.Checked
            .Creators.Enabled = chkTVScraperShowCreators.Checked
            .Creators.Locked = chkTVLockShowCreators.Checked
            .EpisodeGuideURL.Enabled = chkTVScraperShowEpiGuideURL.Checked
            .Genres.Enabled = chkTVScraperShowGenre.Checked
            .Genres.Locked = chkTVLockShowGenre.Checked
            .MPAA.Enabled = chkTVScraperShowMPAA.Checked
            .MPAA.Locked = chkTVLockShowMPAA.Checked
            .MPAANotRatedValue = txtTVScraperShowMPAANotRated.Text
            .OriginalTitle.Enabled = chkTVScraperShowOriginalTitle.Checked
            .OriginalTitle.Locked = chkTVLockShowOriginalTitle.Checked
            .Plot.Enabled = chkTVScraperShowPlot.Checked
            .Plot.Locked = chkTVLockShowPlot.Checked
            .Premiered.Enabled = chkTVScraperShowPremiered.Checked
            .Rating.Enabled = chkTVScraperShowRating.Checked
            .Rating.Locked = chkTVLockShowRating.Checked
            .Runtime.Enabled = chkTVScraperShowRuntime.Checked
            .Runtime.Locked = chkTVLockShowRuntime.Checked
            .Status.Enabled = chkTVScraperShowStatus.Checked
            .Status.Enabled = chkTVScraperShowStudio.Checked
            .Status.Locked = chkTVLockShowStatus.Checked
            .Studios.Locked = chkTVLockShowStudio.Checked
            .Title.Enabled = chkTVScraperShowTitle.Checked
            .Title.Locked = chkTVLockShowTitle.Checked
            .UserRating.Enabled = chkTVScraperShowUserRating.Checked
            .UserRating.Locked = chkTVLockShowUserRating.Checked
        End With
        With Master.eSettings
            .TVScraperEpisodeGuestStarsToActors = chkTVScraperEpisodeGuestStarsToActors.Checked
            .TVMetadataPerFileType.Clear()
            .TVMetadataPerFileType.AddRange(TVMeta)
            .TVScraperUseDisplaySeasonEpisode = chkTVScraperUseDisplaySeasonEpisode.Checked
            .TVScraperUseSRuntimeForEp = chkTVScraperUseSRuntimeForEp.Checked
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

        'Certifications
        Dim strCertifications As String = Master.eLang.GetString(56, "Certifications")
        gbTVScraperCertificationOpts.Text = strCertifications
        lblTVScraperGlobalCertifications.Text = strCertifications

        'Cleanup disabled fields
        Dim strCleanUpDisabledFileds As String = Master.eLang.GetString(125, "Cleanup disabled fields")
        chkTVScraperCleanFields.Text = strCleanUpDisabledFileds

        'Column
        Dim strColumn As String = Master.eLang.GetString(1331, "Column")

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
        chkTVScraperEpisodeGuestStarsToActors.Text = Master.eLang.GetString(974, "Add Episode Guest Stars to Actors list")
        chkTVScraperUseMDDuration.Text = Master.eLang.GetString(516, "Use Duration for Runtime")
        chkTVScraperUseSRuntimeForEp.Text = Master.eLang.GetString(1262, "Use Show Runtime for Episodes if no Episode Runtime can be found")
        gbSettingsHelp.Text = String.Concat("     ", Master.eLang.GetString(458, "Help"))
        gbTVScraperDurationFormatOpts.Text = Master.eLang.GetString(515, "Duration Format")
        lblTVScraperGlobalGuestStars.Text = Master.eLang.GetString(508, "Guest Stars")

        'items with text from other items
        chkTVScraperMetaDataScan.Text = Master.eLang.GetString(517, "Scan Meta Data")
        gbTVScraperDefFIExtOpts.Text = gbTVScraperDefFIExtOpts.Text
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

    Private Sub EnableApplyButton(ByVal sender As Object, ByVal e As EventArgs) Handles _
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