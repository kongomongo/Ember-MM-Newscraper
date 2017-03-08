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
Imports NLog
Imports System.Windows.Forms

Public Class frmTV_GUI
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.TV
    Dim _intImageIndex As Integer = 0
    Dim _intOrder As Integer = 100
    Dim _strName As String = "TV_GUI"
    Dim _strTitle As String = "GUI"

    Private TVGeneralEpisodeListSorting As New List(Of Settings.ListSorting)
    Private TVGeneralSeasonListSorting As New List(Of Settings.ListSorting)
    Private TVGeneralShowListSorting As New List(Of Settings.ListSorting)

#End Region 'Fields

#Region "Events"

    Public Event NeedsDBClean_Movie() Implements Interfaces.MasterSettingsPanel.NeedsDBClean_Movie
    Public Event NeedsDBClean_TV() Implements Interfaces.MasterSettingsPanel.NeedsDBClean_TV
    Public Event NeedsDBUpdate_Movie() Implements Interfaces.MasterSettingsPanel.NeedsDBUpdate_Movie
    Public Event NeedsDBUpdate_TV() Implements Interfaces.MasterSettingsPanel.NeedsDBUpdate_TV
    Public Event NeedsReload_Movie() Implements Interfaces.MasterSettingsPanel.NeedsReload_Movie
    Public Event NeedsReload_MovieSet() Implements Interfaces.MasterSettingsPanel.NeedsReload_MovieSet
    Public Event NeedsReload_TVEpisode() Implements Interfaces.MasterSettingsPanel.NeedsReload_TVEpisode
    Public Event NeedsReload_TVShow() Implements Interfaces.MasterSettingsPanel.NeedsReload_TVShow
    Public Event NeedsRestart() Implements Interfaces.MasterSettingsPanel.NeedsRestart
    Public Event SettingsChanged() Implements Interfaces.MasterSettingsPanel.SettingsChanged

#End Region 'Events

#Region "Properties"

    Public ReadOnly Property Order() As Integer Implements Interfaces.MasterSettingsPanel.Order
        Get
            Return _intOrder
        End Get
    End Property

#End Region 'Properties

#Region "Handles"

    Private Sub Handle_NeedsDBClean_Movie()
        RaiseEvent NeedsDBClean_Movie()
    End Sub

    Private Sub Handle_NeedsDBClean_TV()
        RaiseEvent NeedsDBClean_TV()
    End Sub

    Private Sub Handle_NeedsDBUpdate_Movie()
        RaiseEvent NeedsDBUpdate_Movie()
    End Sub

    Private Sub Handle_NeedsDBUpdate_TV()
        RaiseEvent NeedsDBUpdate_TV()
    End Sub

    Private Sub Handle_NeedsReload_Movie()
        RaiseEvent NeedsReload_Movie()
    End Sub

    Private Sub Handle_NeedsReload_MovieSet()
        RaiseEvent NeedsReload_MovieSet()
    End Sub

    Private Sub Handle_NeedsReload_TVEpisode()
        RaiseEvent NeedsReload_TVEpisode()
    End Sub

    Private Sub Handle_NeedsReload_TVShow()
        RaiseEvent NeedsReload_TVShow()
    End Sub

    Private Sub Handle_NeedsRestart()
        RaiseEvent NeedsRestart()
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

#End Region 'Handles

#Region "Constructors"

    Public Sub New()
        InitializeComponent()
        SetUp()
    End Sub

#End Region 'Constructors 

#Region "Interface Methodes"

    Public Sub DoDispose() Implements Interfaces.MasterSettingsPanel.DoDispose
        Dispose()
    End Sub

    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.MasterSettingsPanel.InjectSettingsPanel
        LoadSettings()

        Dim nSettingsPanel As New Containers.SettingsPanel With {
            .ImageIndex = _intImageIndex,
            .Name = _strName,
            .Order = _intOrder,
            .Panel = pnlSettings,
            .Prefix = _strName,
            .Title = _strTitle,
            .Type = _ePanelType
        }

        Return nSettingsPanel
    End Function

    Public Sub LoadSettings()
        With Master.eSettings
            cbTVGeneralCustomScrapeButtonModifierType.SelectedValue = .TVGeneralCustomScrapeButtonModifierType
            cbTVGeneralCustomScrapeButtonScrapeType.SelectedValue = .TVGeneralCustomScrapeButtonScrapeType

            chkTVGeneralClickScrapeAsk.Enabled = chkTVGeneralClickScrape.Checked
            chkTVDisplayMissingEpisodes.Checked = .TVDisplayMissingEpisodes
            chkTVGeneralClickScrape.Checked = .TVGeneralClickScrape
            chkTVGeneralClickScrapeAsk.Checked = .TVGeneralClickScrapeask
            If .TVGeneralCustomScrapeButtonEnabled Then
                rbTVGeneralCustomScrapeButtonEnabled.Checked = True
            Else
                rbTVGeneralCustomScrapeButtonDisabled.Checked = True
            End If
            cbTVLanguageOverlay.SelectedItem = If(String.IsNullOrEmpty(.TVGeneralFlagLang), Master.eLang.Disabled, .TVGeneralFlagLang)

            TVGeneralEpisodeListSorting.AddRange(.TVGeneralEpisodeListSorting)
            LoadListSorting(Enums.ContentType.TVEpisode)

            TVGeneralSeasonListSorting.AddRange(.TVGeneralSeasonListSorting)
            LoadListSorting(Enums.ContentType.TVSeason)

            TVGeneralShowListSorting.AddRange(.TVGeneralShowListSorting)
            LoadListSorting(Enums.ContentType.TVShow)

            RefreshTVSortTokens()
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings
            .TVDisplayMissingEpisodes = chkTVDisplayMissingEpisodes.Checked
            .TVGeneralEpisodeListSorting.Clear()
            .TVGeneralEpisodeListSorting.AddRange(TVGeneralEpisodeListSorting)
            .TVGeneralClickScrape = chkTVGeneralClickScrape.Checked
            .TVGeneralClickScrapeask = chkTVGeneralClickScrapeAsk.Checked
            .TVGeneralCustomScrapeButtonEnabled = rbTVGeneralCustomScrapeButtonEnabled.Checked
            .TVGeneralCustomScrapeButtonModifierType = CType(cbTVGeneralCustomScrapeButtonModifierType.SelectedItem, KeyValuePair(Of String, Enums.ScrapeModifierType)).Value
            .TVGeneralCustomScrapeButtonScrapeType = CType(cbTVGeneralCustomScrapeButtonScrapeType.SelectedItem, KeyValuePair(Of String, Enums.ScrapeType)).Value
            .TVGeneralSeasonListSorting.Clear()
            .TVGeneralSeasonListSorting.AddRange(TVGeneralSeasonListSorting)
            .TVGeneralShowListSorting.Clear()
            .TVGeneralShowListSorting.AddRange(TVGeneralShowListSorting)
            .TVGeneralFlagLang = If(cbTVLanguageOverlay.Text = Master.eLang.Disabled, String.Empty, cbTVLanguageOverlay.Text)
            .TVSortTokens.Clear()
            .TVSortTokens.AddRange(lstTVSortTokens.Items.OfType(Of String).ToList)
            If .TVSortTokens.Count <= 0 Then .TVSortTokensIsEmpty = True
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub LoadLangs()
        cbTVLanguageOverlay.Items.Add(Master.eLang.Disabled)
        cbTVLanguageOverlay.Items.AddRange(Localization.ISOLangGetLanguagesList.ToArray)
    End Sub

    Private Sub LoadListSorting(ByVal tContentType As Enums.ContentType)
        Dim lvItem As ListViewItem
        Dim nListSorting As New List(Of Settings.ListSorting)
        Dim nListView As New ListView

        Select Case tContentType
            Case Enums.ContentType.TVEpisode
                nListSorting = TVGeneralEpisodeListSorting
                nListView = lvTVGeneralEpisodeListSorting
            Case Enums.ContentType.TVSeason
                nListSorting = TVGeneralSeasonListSorting
                nListView = lvTVGeneralSeasonListSorting
            Case Enums.ContentType.TVShow
                nListSorting = TVGeneralShowListSorting
                nListView = lvTVGeneralShowListSorting
        End Select

        nListView.Items.Clear()
        For Each rColumn As Settings.ListSorting In nListSorting.OrderBy(Function(f) f.DisplayIndex)
            lvItem = New ListViewItem(rColumn.DisplayIndex.ToString)
            lvItem.SubItems.Add(rColumn.Column)
            lvItem.SubItems.Add(Master.eLang.GetString(rColumn.LabelID, rColumn.LabelText))
            lvItem.SubItems.Add(If(rColumn.Hide, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            nListView.Items.Add(lvItem)
        Next
    End Sub

    Private Sub LoadCustomScraperButtonModifierTypes_TV()
        Dim items As New Dictionary(Of String, Enums.ScrapeModifierType)
        items.Add(Master.eLang.GetString(70, "All Items"), Enums.ScrapeModifierType.All)
        items.Add(Master.eLang.GetString(973, "Actor Thumbs Only"), Enums.ScrapeModifierType.MainActorThumbs)
        items.Add(Master.eLang.GetString(1060, "Banner Only"), Enums.ScrapeModifierType.MainBanner)
        items.Add(Master.eLang.GetString(1121, "CharacterArt Only"), Enums.ScrapeModifierType.MainCharacterArt)
        items.Add(Master.eLang.GetString(1122, "ClearArt Only"), Enums.ScrapeModifierType.MainClearArt)
        items.Add(Master.eLang.GetString(1123, "ClearLogo Only"), Enums.ScrapeModifierType.MainClearLogo)
        items.Add(Master.eLang.GetString(975, "Extrafanarts Only"), Enums.ScrapeModifierType.MainExtrafanarts)
        items.Add(Master.eLang.GetString(73, "Fanart Only"), Enums.ScrapeModifierType.MainFanart)
        items.Add(Master.eLang.GetString(1061, "Landscape Only"), Enums.ScrapeModifierType.MainLandscape)
        items.Add(Master.eLang.GetString(71, "NFO Only"), Enums.ScrapeModifierType.MainNFO)
        items.Add(Master.eLang.GetString(72, "Poster Only"), Enums.ScrapeModifierType.MainPoster)
        items.Add(Master.eLang.GetString(1125, "Theme Only"), Enums.ScrapeModifierType.MainTheme)
        cbTVGeneralCustomScrapeButtonModifierType.DataSource = items.ToList
        cbTVGeneralCustomScrapeButtonModifierType.DisplayMember = "Key"
        cbTVGeneralCustomScrapeButtonModifierType.ValueMember = "Value"
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
        cbTVGeneralCustomScrapeButtonScrapeType.DataSource = items.ToList
        cbTVGeneralCustomScrapeButtonScrapeType.DisplayMember = "Key"
        cbTVGeneralCustomScrapeButtonScrapeType.ValueMember = "Value"
    End Sub

    Private Sub lsttvSortTokens_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstTVSortTokens.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveTVSortToken()
    End Sub

    Private Sub btnTVSortTokenAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVSortTokenAdd.Click
        If Not String.IsNullOrEmpty(txtTVSortToken.Text) Then
            If Not lstTVSortTokens.Items.Contains(txtTVSortToken.Text) Then
                lstTVSortTokens.Items.Add(txtTVSortToken.Text)
                Handle_NeedsReload_TVShow()
                EnableApplyButton()
                txtTVSortToken.Text = String.Empty
                txtTVSortToken.Focus()
            End If
        End If
    End Sub

    Private Sub RefreshTVSortTokens()
        lstTVSortTokens.Items.Clear()
        lstTVSortTokens.Items.AddRange(Master.eSettings.TVSortTokens.ToArray)
    End Sub

    Private Sub RemoveTVSortToken()
        If lstTVSortTokens.Items.Count > 0 AndAlso lstTVSortTokens.SelectedItems.Count > 0 Then
            While lstTVSortTokens.SelectedItems.Count > 0
                lstTVSortTokens.Items.Remove(lstTVSortTokens.SelectedItems(0))
            End While
            Handle_NeedsReload_TVShow()
            EnableApplyButton()
        End If
    End Sub

    Private Sub RenumberMediaListSorting(ByVal lstListSorting As List(Of Settings.ListSorting))
        For i As Integer = 0 To lstListSorting.Count - 1
            lstListSorting(i).DisplayIndex = i
        Next
    End Sub

    Private Sub btnTVGeneralEpisodeListSortingUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralEpisodeListSortingUp.Click
        Try
            If lvTVGeneralEpisodeListSorting.Items.Count > 0 AndAlso lvTVGeneralEpisodeListSorting.SelectedItems.Count > 0 AndAlso Not lvTVGeneralEpisodeListSorting.SelectedItems(0).Index = 0 Then
                Dim selItem As Settings.ListSorting = TVGeneralEpisodeListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralEpisodeListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVGeneralEpisodeListSorting.SuspendLayout()
                    Dim iIndex As Integer = TVGeneralEpisodeListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVGeneralEpisodeListSorting.SelectedIndices(0)
                    TVGeneralEpisodeListSorting.Remove(selItem)
                    TVGeneralEpisodeListSorting.Insert(iIndex - 1, selItem)

                    RenumberMediaListSorting(TVGeneralEpisodeListSorting)
                    LoadListSorting(Enums.ContentType.TVEpisode)

                    If Not selIndex - 3 < 0 Then
                        lvTVGeneralEpisodeListSorting.TopItem = lvTVGeneralEpisodeListSorting.Items(selIndex - 3)
                    End If
                    lvTVGeneralEpisodeListSorting.Items(selIndex - 1).Selected = True
                    lvTVGeneralEpisodeListSorting.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVGeneralEpisodeListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVGeneralSeasonListSortingUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralSeasonListSortingUp.Click
        Try
            If lvTVGeneralSeasonListSorting.Items.Count > 0 AndAlso lvTVGeneralSeasonListSorting.SelectedItems.Count > 0 AndAlso Not lvTVGeneralSeasonListSorting.SelectedItems(0).Index = 0 Then
                Dim selItem As Settings.ListSorting = TVGeneralSeasonListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralSeasonListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVGeneralSeasonListSorting.SuspendLayout()
                    Dim iIndex As Integer = TVGeneralSeasonListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVGeneralSeasonListSorting.SelectedIndices(0)
                    TVGeneralSeasonListSorting.Remove(selItem)
                    TVGeneralSeasonListSorting.Insert(iIndex - 1, selItem)

                    RenumberMediaListSorting(TVGeneralSeasonListSorting)
                    LoadListSorting(Enums.ContentType.TVSeason)

                    If Not selIndex - 3 < 0 Then
                        lvTVGeneralSeasonListSorting.TopItem = lvTVGeneralSeasonListSorting.Items(selIndex - 3)
                    End If
                    lvTVGeneralSeasonListSorting.Items(selIndex - 1).Selected = True
                    lvTVGeneralSeasonListSorting.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVGeneralSeasonListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVGeneralShowListSortingUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralShowListSortingUp.Click
        Try
            If lvTVGeneralShowListSorting.Items.Count > 0 AndAlso lvTVGeneralShowListSorting.SelectedItems.Count > 0 AndAlso Not lvTVGeneralShowListSorting.SelectedItems(0).Index = 0 Then
                Dim selItem As Settings.ListSorting = TVGeneralShowListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralShowListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVGeneralShowListSorting.SuspendLayout()
                    Dim iIndex As Integer = TVGeneralShowListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVGeneralShowListSorting.SelectedIndices(0)
                    TVGeneralShowListSorting.Remove(selItem)
                    TVGeneralShowListSorting.Insert(iIndex - 1, selItem)

                    RenumberMediaListSorting(TVGeneralShowListSorting)
                    LoadListSorting(Enums.ContentType.TVShow)

                    If Not selIndex - 3 < 0 Then
                        lvTVGeneralShowListSorting.TopItem = lvTVGeneralShowListSorting.Items(selIndex - 3)
                    End If
                    lvTVGeneralShowListSorting.Items(selIndex - 1).Selected = True
                    lvTVGeneralShowListSorting.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVGeneralShowListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVGeneralEpisodeListSortingDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralEpisodeListSortingDown.Click
        Try
            If lvTVGeneralEpisodeListSorting.Items.Count > 0 AndAlso lvTVGeneralEpisodeListSorting.SelectedItems.Count > 0 AndAlso lvTVGeneralEpisodeListSorting.SelectedItems(0).Index < (lvTVGeneralEpisodeListSorting.Items.Count - 1) Then
                Dim selItem As Settings.ListSorting = TVGeneralEpisodeListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralEpisodeListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVGeneralEpisodeListSorting.SuspendLayout()
                    Dim iIndex As Integer = TVGeneralEpisodeListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVGeneralEpisodeListSorting.SelectedIndices(0)
                    TVGeneralEpisodeListSorting.Remove(selItem)
                    TVGeneralEpisodeListSorting.Insert(iIndex + 1, selItem)

                    RenumberMediaListSorting(TVGeneralEpisodeListSorting)
                    LoadListSorting(Enums.ContentType.TVEpisode)

                    If Not selIndex - 2 < 0 Then
                        lvTVGeneralEpisodeListSorting.TopItem = lvTVGeneralEpisodeListSorting.Items(selIndex - 2)
                    End If
                    lvTVGeneralEpisodeListSorting.Items(selIndex + 1).Selected = True
                    lvTVGeneralEpisodeListSorting.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVGeneralEpisodeListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVGeneralSeasonListSortingDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralSeasonListSortingDown.Click
        Try
            If lvTVGeneralSeasonListSorting.Items.Count > 0 AndAlso lvTVGeneralSeasonListSorting.SelectedItems.Count > 0 AndAlso lvTVGeneralSeasonListSorting.SelectedItems(0).Index < (lvTVGeneralSeasonListSorting.Items.Count - 1) Then
                Dim selItem As Settings.ListSorting = TVGeneralSeasonListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralSeasonListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVGeneralSeasonListSorting.SuspendLayout()
                    Dim iIndex As Integer = TVGeneralSeasonListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVGeneralSeasonListSorting.SelectedIndices(0)
                    TVGeneralSeasonListSorting.Remove(selItem)
                    TVGeneralSeasonListSorting.Insert(iIndex + 1, selItem)

                    RenumberMediaListSorting(TVGeneralSeasonListSorting)
                    LoadListSorting(Enums.ContentType.TVSeason)

                    If Not selIndex - 2 < 0 Then
                        lvTVGeneralSeasonListSorting.TopItem = lvTVGeneralSeasonListSorting.Items(selIndex - 2)
                    End If
                    lvTVGeneralSeasonListSorting.Items(selIndex + 1).Selected = True
                    lvTVGeneralSeasonListSorting.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVGeneralSeasonListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVGeneralShowListSortingDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralShowListSortingDown.Click
        Try
            If lvTVGeneralShowListSorting.Items.Count > 0 AndAlso lvTVGeneralShowListSorting.SelectedItems.Count > 0 AndAlso lvTVGeneralShowListSorting.SelectedItems(0).Index < (lvTVGeneralShowListSorting.Items.Count - 1) Then
                Dim selItem As Settings.ListSorting = TVGeneralShowListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralShowListSorting.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVGeneralShowListSorting.SuspendLayout()
                    Dim iIndex As Integer = TVGeneralShowListSorting.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVGeneralShowListSorting.SelectedIndices(0)
                    TVGeneralShowListSorting.Remove(selItem)
                    TVGeneralShowListSorting.Insert(iIndex + 1, selItem)

                    RenumberMediaListSorting(TVGeneralShowListSorting)
                    LoadListSorting(Enums.ContentType.TVShow)

                    If Not selIndex - 2 < 0 Then
                        lvTVGeneralShowListSorting.TopItem = lvTVGeneralShowListSorting.Items(selIndex - 2)
                    End If
                    lvTVGeneralShowListSorting.Items(selIndex + 1).Selected = True
                    lvTVGeneralShowListSorting.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVGeneralShowListSorting.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub lvTVGeneralEpisodeListSorting_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTVGeneralEpisodeListSorting.MouseDoubleClick
        If lvTVGeneralEpisodeListSorting.Items.Count > 0 AndAlso lvTVGeneralEpisodeListSorting.SelectedItems.Count > 0 Then
            Dim selItem As Settings.ListSorting = TVGeneralEpisodeListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralEpisodeListSorting.SelectedItems(0).Text))

            If selItem IsNot Nothing Then
                lvTVGeneralEpisodeListSorting.SuspendLayout()
                selItem.Hide = Not selItem.Hide
                Dim topIndex As Integer = lvTVGeneralEpisodeListSorting.TopItem.Index
                Dim selIndex As Integer = lvTVGeneralEpisodeListSorting.SelectedIndices(0)

                LoadListSorting(Enums.ContentType.TVEpisode)

                lvTVGeneralEpisodeListSorting.TopItem = lvTVGeneralEpisodeListSorting.Items(topIndex)
                lvTVGeneralEpisodeListSorting.Items(selIndex).Selected = True
                lvTVGeneralEpisodeListSorting.ResumeLayout()
            End If

            EnableApplyButton()
            lvTVGeneralEpisodeListSorting.Focus()
        End If
    End Sub

    Private Sub lvTVGeneralSeasonListSorting_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTVGeneralSeasonListSorting.MouseDoubleClick
        If lvTVGeneralSeasonListSorting.Items.Count > 0 AndAlso lvTVGeneralSeasonListSorting.SelectedItems.Count > 0 Then
            Dim selItem As Settings.ListSorting = TVGeneralSeasonListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralSeasonListSorting.SelectedItems(0).Text))

            If selItem IsNot Nothing Then
                lvTVGeneralSeasonListSorting.SuspendLayout()
                selItem.Hide = Not selItem.Hide
                Dim topIndex As Integer = lvTVGeneralSeasonListSorting.TopItem.Index
                Dim selIndex As Integer = lvTVGeneralSeasonListSorting.SelectedIndices(0)

                LoadListSorting(Enums.ContentType.TVSeason)

                lvTVGeneralSeasonListSorting.TopItem = lvTVGeneralSeasonListSorting.Items(topIndex)
                lvTVGeneralSeasonListSorting.Items(selIndex).Selected = True
                lvTVGeneralSeasonListSorting.ResumeLayout()
            End If

            EnableApplyButton()
            lvTVGeneralSeasonListSorting.Focus()
        End If
    End Sub

    Private Sub lvTVGeneralShowListSorting_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTVGeneralShowListSorting.MouseDoubleClick
        If lvTVGeneralShowListSorting.Items.Count > 0 AndAlso lvTVGeneralShowListSorting.SelectedItems.Count > 0 Then
            Dim selItem As Settings.ListSorting = TVGeneralShowListSorting.FirstOrDefault(Function(r) r.DisplayIndex = Convert.ToInt32(lvTVGeneralShowListSorting.SelectedItems(0).Text))

            If selItem IsNot Nothing Then
                lvTVGeneralShowListSorting.SuspendLayout()
                selItem.Hide = Not selItem.Hide
                Dim topIndex As Integer = lvTVGeneralShowListSorting.TopItem.Index
                Dim selIndex As Integer = lvTVGeneralShowListSorting.SelectedIndices(0)

                LoadListSorting(Enums.ContentType.TVShow)

                lvTVGeneralShowListSorting.TopItem = lvTVGeneralShowListSorting.Items(topIndex)
                lvTVGeneralShowListSorting.Items(selIndex).Selected = True
                lvTVGeneralShowListSorting.ResumeLayout()
            End If

            EnableApplyButton()
            lvTVGeneralShowListSorting.Focus()
        End If
    End Sub

    Private Sub btnTVEpisodeGeneralMediaListSortingReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralEpisodeListSortingReset.Click
        Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.TVEpisodeListSorting, True)
        TVGeneralEpisodeListSorting.Clear()
        TVGeneralEpisodeListSorting.AddRange(Master.eSettings.TVGeneralEpisodeListSorting)
        LoadListSorting(Enums.ContentType.TVEpisode)
        EnableApplyButton()
    End Sub

    Private Sub btnTVSeasonGeneralMediaListSortingReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralSeasonListSortingReset.Click
        Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.TVSeasonListSorting, True)
        TVGeneralSeasonListSorting.Clear()
        TVGeneralSeasonListSorting.AddRange(Master.eSettings.TVGeneralSeasonListSorting)
        LoadListSorting(Enums.ContentType.TVSeason)
        EnableApplyButton()
    End Sub

    Private Sub btnTVGeneralShowListSortingReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVGeneralShowListSortingReset.Click
        Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.TVShowListSorting, True)
        TVGeneralShowListSorting.Clear()
        TVGeneralShowListSorting.AddRange(Master.eSettings.TVGeneralShowListSorting)
        LoadListSorting(Enums.ContentType.TVShow)
        EnableApplyButton()
    End Sub

    Private Sub btnTVSortTokenRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVSortTokenRemove.Click
        RemoveTVSortToken()
    End Sub

    Private Sub btnTVSortTokenReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTVSortTokenReset.Click
        Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.TVSortTokens, True)
        RefreshTVSortTokens()
        Handle_NeedsReload_TVShow()
        EnableApplyButton()
    End Sub

    Private Sub chkTVGeneralClickScrape_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTVGeneralClickScrape.CheckedChanged
        chkTVGeneralClickScrapeAsk.Enabled = chkTVGeneralClickScrape.Checked
        EnableApplyButton()
    End Sub

    Private Sub rbTVGeneralCustomScrapeButtonDisabled_CheckedChanged(sender As Object, e As EventArgs) Handles rbTVGeneralCustomScrapeButtonDisabled.CheckedChanged
        If rbTVGeneralCustomScrapeButtonDisabled.Checked Then
            cbTVGeneralCustomScrapeButtonModifierType.Enabled = False
            cbTVGeneralCustomScrapeButtonScrapeType.Enabled = False
            txtTVGeneralCustomScrapeButtonModifierType.Enabled = False
            txtTVGeneralCustomScrapeButtonScrapeType.Enabled = False
        End If
        EnableApplyButton()
    End Sub

    Private Sub rbTVGeneralCustomScrapeButtonEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles rbTVGeneralCustomScrapeButtonEnabled.CheckedChanged
        If rbTVGeneralCustomScrapeButtonEnabled.Checked Then
            cbTVGeneralCustomScrapeButtonModifierType.Enabled = True
            cbTVGeneralCustomScrapeButtonScrapeType.Enabled = True
            txtTVGeneralCustomScrapeButtonModifierType.Enabled = True
            txtTVGeneralCustomScrapeButtonScrapeType.Enabled = True
        End If
        EnableApplyButton()
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub SetUp()
        lblTVLanguageOverlay.Text = String.Concat(Master.eLang.GetString(436, "Display best Audio Stream with the following Language"), ":")
        chkTVGeneralClickScrape.Text = Master.eLang.GetString(849, "Enable Click Scrape")
        gbTVGeneralEpisodeListSorting.Text = Master.eLang.GetString(494, "Episode List Sorting")
        gbTVGeneralMiscOpts.Text = Master.eLang.GetString(429, "Miscellaneous")
        gbTVGeneralSeasonListSortingOpts.Text = Master.eLang.GetString(493, "Season List Sorting")
        gbTVGeneralShowListSortingOpts.Text = Master.eLang.GetString(492, "Show List Sorting")
        gbTVGeneralMediaListSortTokensOpts.Text = Master.eLang.GetString(463, "Sort Tokens to Ignore")
        chkTVDisplayMissingEpisodes.Text = Master.eLang.GetString(733, "Display Missing Episodes")
        chkTVGeneralClickScrapeAsk.Text = Master.eLang.GetString(852, "Ask On Click Scrape")

        'Column
        Dim strColumn As String = Master.eLang.GetString(1331, "Column")
        colTVGeneralEpisodeListSortingLabel.Text = strColumn
        colTVGeneralSeasonListSortingLabel.Text = strColumn
        colTVGeneralShowListSortingLabel.Text = strColumn

        'Hide
        Dim strHide As String = Master.eLang.GetString(465, "Hide")
        colTVGeneralEpisodeListSortingHide.Text = strHide
        colTVGeneralSeasonListSortingHide.Text = strHide
        colTVGeneralShowListSortingHide.Text = strHide

        LoadCustomScraperButtonModifierTypes_TV()
        LoadCustomScraperButtonScrapeTypes()
        LoadLangs()
    End Sub

#End Region 'Methods

End Class