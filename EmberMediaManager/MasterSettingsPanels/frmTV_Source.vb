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

Imports System.Windows.Forms
Imports EmberAPI
Imports NLog

Public Class frmTV_Source
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.TV
    Dim _intImageIndex As Integer = 5
    Dim _intOrder As Integer = 200
    Dim _strName As String = "TV_Source"
    Dim _strTitle As String = Master.eLang.GetString(555, "Sources")

    Private TVShowMatching As New List(Of Settings.regexp)

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
            cbTVScraperOptionsOrdering.SelectedValue = .TVScraperOptionsOrdering
            chkTVCleanDB.Checked = .TVCleanDB
            chkTVGeneralIgnoreLastScan.Checked = .TVGeneralIgnoreLastScan
            chkTVScanOrderModify.Checked = .TVScanOrderModify
            txtTVSourcesRegexMultiPartMatching.Text = .TVMultiPartMatching
            txtTVSkipLessThan.Text = .TVSkipLessThan.ToString
            chkTVEpisodeNoFilter.Checked = .TVEpisodeNoFilter
            chkTVEpisodeProperCase.Checked = .TVEpisodeProperCase
            chkTVShowProperCase.Checked = .TVShowProperCase

            Try
                cbTVGeneralLang.Items.Clear()
                cbTVGeneralLang.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Description).ToArray)
                If cbTVGeneralLang.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(.TVGeneralLanguage) Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = .TVGeneralLanguage)
                        If tLanguage IsNot Nothing AndAlso tLanguage.Description IsNot Nothing AndAlso Not String.IsNullOrEmpty(tLanguage.Description) Then
                            cbTVGeneralLang.Text = tLanguage.Description
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.TVGeneralLanguage))
                            If tLanguage IsNot Nothing Then
                                cbTVGeneralLang.Text = tLanguage.Description
                            Else
                                cbTVGeneralLang.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = "en-US").Description
                            End If
                        End If
                    Else
                        cbTVGeneralLang.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = "en-US").Description
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            TVShowMatching.AddRange(.TVShowMatching)
            LoadTVShowMatching()
            RefreshTVSources()
            RefreshTVShowFilters()
            RefreshTVEpisodeFilters()
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings
            .TVCleanDB = chkTVCleanDB.Checked
            .TVGeneralIgnoreLastScan = chkTVGeneralIgnoreLastScan.Checked
            If Not String.IsNullOrEmpty(cbTVGeneralLang.Text) Then
                .TVGeneralLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Description = cbTVGeneralLang.Text).Abbreviation
            End If
            .TVMultiPartMatching = txtTVSourcesRegexMultiPartMatching.Text
            .TVScanOrderModify = chkTVScanOrderModify.Checked
            .TVScraperOptionsOrdering = CType(cbTVScraperOptionsOrdering.SelectedItem, KeyValuePair(Of String, Enums.EpisodeOrdering)).Value
            If Not String.IsNullOrEmpty(txtTVSkipLessThan.Text) AndAlso Integer.TryParse(txtTVSkipLessThan.Text, 0) Then
                .TVSkipLessThan = Convert.ToInt32(txtTVSkipLessThan.Text)
            Else
                .TVSkipLessThan = 0
            End If
            .TVShowMatching.Clear()
            .TVShowMatching.AddRange(TVShowMatching)
            .TVEpisodeFilterCustom.AddRange(lstTVEpisodeFilter.Items.OfType(Of String).ToList)
            If .TVEpisodeFilterCustom.Count <= 0 Then .TVEpisodeFilterCustomIsEmpty = True
            .TVEpisodeNoFilter = chkTVEpisodeNoFilter.Checked
            .TVEpisodeProperCase = chkTVEpisodeProperCase.Checked
            .TVShowFilterCustom.Clear()
            .TVShowFilterCustom.AddRange(lstTVShowFilter.Items.OfType(Of String).ToList)
            If .TVShowFilterCustom.Count <= 0 Then .TVShowFilterCustomIsEmpty = True
            .TVShowProperCase = chkTVShowProperCase.Checked
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub lstTVEpisodeFilter_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then RemoveTVEpisodeFilter()
    End Sub

    Private Sub lstTVShowFilter_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then RemoveTVShowFilter()
    End Sub

    Private Sub btnTVEpisodeFilterAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not String.IsNullOrEmpty(txtTVEpisodeFilter.Text) Then
            lstTVEpisodeFilter.Items.Add(txtTVEpisodeFilter.Text)
            txtTVEpisodeFilter.Text = String.Empty
            EnableApplyButton()
            Handle_NeedsReload_TVEpisode()
        End If

        txtTVEpisodeFilter.Focus()
    End Sub

    Private Sub btnTVShowFilterAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not String.IsNullOrEmpty(txtTVShowFilter.Text) Then
            lstTVShowFilter.Items.Add(txtTVShowFilter.Text)
            txtTVShowFilter.Text = String.Empty
            EnableApplyButton()
            Handle_NeedsReload_TVShow()
        End If

        txtTVShowFilter.Focus()
    End Sub

    Private Sub btnTVEpisodeFilterDown_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If lstTVEpisodeFilter.Items.Count > 0 AndAlso lstTVEpisodeFilter.SelectedItem IsNot Nothing AndAlso lstTVEpisodeFilter.SelectedIndex < (lstTVEpisodeFilter.Items.Count - 1) Then
                Dim iIndex As Integer = lstTVEpisodeFilter.SelectedIndices(0)
                lstTVEpisodeFilter.Items.Insert(iIndex + 2, lstTVEpisodeFilter.SelectedItems(0))
                lstTVEpisodeFilter.Items.RemoveAt(iIndex)
                lstTVEpisodeFilter.SelectedIndex = iIndex + 1
                EnableApplyButton()
                Handle_NeedsReload_TVEpisode()
                lstTVEpisodeFilter.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVShowFilterDown_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If lstTVShowFilter.Items.Count > 0 AndAlso lstTVShowFilter.SelectedItem IsNot Nothing AndAlso lstTVShowFilter.SelectedIndex < (lstTVShowFilter.Items.Count - 1) Then
                Dim iIndex As Integer = lstTVShowFilter.SelectedIndices(0)
                lstTVShowFilter.Items.Insert(iIndex + 2, lstTVShowFilter.SelectedItems(0))
                lstTVShowFilter.Items.RemoveAt(iIndex)
                lstTVShowFilter.SelectedIndex = iIndex + 1
                EnableApplyButton()
                Handle_NeedsReload_TVShow()
                lstTVShowFilter.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub chkTVEpisodeProperCase_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        EnableApplyButton()
        Handle_NeedsReload_TVEpisode()
    End Sub

    Private Sub chkTVShowProperCase_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        EnableApplyButton()
        Handle_NeedsReload_TVShow()
    End Sub

    Private Sub chkTVEpisodeNoFilter_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        EnableApplyButton()

        chkTVEpisodeProperCase.Enabled = Not chkTVEpisodeNoFilter.Checked
        lstTVEpisodeFilter.Enabled = Not chkTVEpisodeNoFilter.Checked
        txtTVEpisodeFilter.Enabled = Not chkTVEpisodeNoFilter.Checked
        btnTVEpisodeFilterAdd.Enabled = Not chkTVEpisodeNoFilter.Checked
        btnTVEpisodeFilterUp.Enabled = Not chkTVEpisodeNoFilter.Checked
        btnTVEpisodeFilterDown.Enabled = Not chkTVEpisodeNoFilter.Checked
        btnTVEpisodeFilterRemove.Enabled = Not chkTVEpisodeNoFilter.Checked
    End Sub

    Private Sub btnTVShowFilterUp_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If lstTVShowFilter.Items.Count > 0 AndAlso lstTVShowFilter.SelectedItem IsNot Nothing AndAlso lstTVShowFilter.SelectedIndex > 0 Then
                Dim iIndex As Integer = lstTVShowFilter.SelectedIndices(0)
                lstTVShowFilter.Items.Insert(iIndex - 1, lstTVShowFilter.SelectedItems(0))
                lstTVShowFilter.Items.RemoveAt(iIndex + 1)
                lstTVShowFilter.SelectedIndex = iIndex - 1
                EnableApplyButton()
                Handle_NeedsReload_TVShow()
                lstTVShowFilter.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVEpisodeFilterUp_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If lstTVEpisodeFilter.Items.Count > 0 AndAlso lstTVEpisodeFilter.SelectedItem IsNot Nothing AndAlso lstTVEpisodeFilter.SelectedIndex > 0 Then
                Dim iIndex As Integer = lstTVEpisodeFilter.SelectedIndices(0)
                lstTVEpisodeFilter.Items.Insert(iIndex - 1, lstTVEpisodeFilter.SelectedItems(0))
                lstTVEpisodeFilter.Items.RemoveAt(iIndex + 1)
                lstTVEpisodeFilter.SelectedIndex = iIndex - 1
                EnableApplyButton()
                Handle_NeedsReload_TVEpisode()
                lstTVEpisodeFilter.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnRemTVSource_Click(ByVal sender As Object, ByVal e As EventArgs)
        RemoveTVSource()
        Master.DB.Load_Sources_TVShow()
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
        RemoveTVShowMatching()
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingReset_Click(ByVal sender As Object, ByVal e As EventArgs)
        If MessageBox.Show(Master.eLang.GetString(844, "Are you sure you want to reset to the default list of show regex?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.TVShowMatching, True)
            TVShowMatching.Clear()
            TVShowMatching.AddRange(Master.eSettings.TVShowMatching)
            LoadTVShowMatching()
            EnableApplyButton()
        End If
    End Sub

    Private Sub btnTVSourceAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        Using dSource As New dlgSourceTVShow
            If dSource.ShowDialog = DialogResult.OK Then
                RefreshTVSources()
                EnableApplyButton()
                Handle_NeedsDBUpdate_TV()
            End If
        End Using
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingClear_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearTVShowMatching()
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(btnTVSourcesRegexTVShowMatchingAdd.Tag.ToString) Then
            Dim lID = (From lRegex As Settings.regexp In TVShowMatching Select lRegex.ID).Max
            TVShowMatching.Add(New Settings.regexp With {.ID = Convert.ToInt32(lID) + 1,
                                                            .Regexp = txtTVSourcesRegexTVShowMatchingRegex.Text,
                                                            .defaultSeason = If(String.IsNullOrEmpty(txtTVSourcesRegexTVShowMatchingDefaultSeason.Text) OrElse Not Integer.TryParse(txtTVSourcesRegexTVShowMatchingDefaultSeason.Text, 0), -1, CInt(txtTVSourcesRegexTVShowMatchingDefaultSeason.Text)),
                                                            .byDate = chkTVSourcesRegexTVShowMatchingByDate.Checked})
        Else
            Dim selRex = From lRegex As Settings.regexp In TVShowMatching Where lRegex.ID = Convert.ToInt32(btnTVSourcesRegexTVShowMatchingAdd.Tag)
            If selRex.Count > 0 Then
                selRex(0).Regexp = txtTVSourcesRegexTVShowMatchingRegex.Text
                selRex(0).defaultSeason = CInt(If(String.IsNullOrEmpty(txtTVSourcesRegexTVShowMatchingDefaultSeason.Text), "-1", txtTVSourcesRegexTVShowMatchingDefaultSeason.Text))
                selRex(0).byDate = chkTVSourcesRegexTVShowMatchingByDate.Checked
            End If
        End If

        ClearTVShowMatching()
        EnableApplyButton()
        LoadTVShowMatching()
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If lvTVSourcesRegexTVShowMatching.SelectedItems.Count > 0 Then EditTVShowMatching(lvTVSourcesRegexTVShowMatching.SelectedItems(0))
    End Sub

    Private Sub btnTVSourceEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If lvTVSources.SelectedItems.Count > 0 Then
            Using dTVSource As New dlgSourceTVShow
                If dTVSource.ShowDialog(Convert.ToInt32(lvTVSources.SelectedItems(0).Text)) = DialogResult.OK Then
                    RefreshTVSources()
                    Handle_NeedsReload_TVShow()
                    EnableApplyButton()
                End If
            End Using
        End If
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingUp_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If lvTVSourcesRegexTVShowMatching.Items.Count > 0 AndAlso lvTVSourcesRegexTVShowMatching.SelectedItems.Count > 0 AndAlso Not lvTVSourcesRegexTVShowMatching.SelectedItems(0).Index = 0 Then
                Dim selItem As Settings.regexp = TVShowMatching.FirstOrDefault(Function(r) r.ID = Convert.ToInt32(lvTVSourcesRegexTVShowMatching.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVSourcesRegexTVShowMatching.SuspendLayout()
                    Dim iIndex As Integer = TVShowMatching.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVSourcesRegexTVShowMatching.SelectedIndices(0)
                    TVShowMatching.Remove(selItem)
                    TVShowMatching.Insert(iIndex - 1, selItem)

                    RenumberTVShowMatching()
                    LoadTVShowMatching()

                    lvTVSourcesRegexTVShowMatching.Items(selIndex - 1).Selected = True
                    lvTVSourcesRegexTVShowMatching.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVSourcesRegexTVShowMatching.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVShowFilterReset_Click(ByVal sender As Object, ByVal e As EventArgs)
        If MessageBox.Show(Master.eLang.GetString(840, "Are you sure you want to reset to the default list of show filters?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.ShowFilters, True)
            RefreshTVShowFilters()
            EnableApplyButton()
        End If
    End Sub

    Private Sub btnTVShowFilterRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
        RemoveTVShowFilter()
    End Sub

    Private Sub btnTVEpisodeFilterRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
        RemoveTVEpisodeFilter()
    End Sub

    Private Sub btnTVEpisodeFilterReset_Click(ByVal sender As Object, ByVal e As EventArgs)
        If MessageBox.Show(Master.eLang.GetString(841, "Are you sure you want to reset to the default list of episode filters?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.EpFilters, True)
            RefreshTVEpisodeFilters()
            EnableApplyButton()
        End If
    End Sub

    Private Sub btnTVSourcesRegexTVShowMatchingDown_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If lvTVSourcesRegexTVShowMatching.Items.Count > 0 AndAlso lvTVSourcesRegexTVShowMatching.SelectedItems.Count > 0 AndAlso lvTVSourcesRegexTVShowMatching.SelectedItems(0).Index < (lvTVSourcesRegexTVShowMatching.Items.Count - 1) Then
                Dim selItem As Settings.regexp = TVShowMatching.FirstOrDefault(Function(r) r.ID = Convert.ToInt32(lvTVSourcesRegexTVShowMatching.SelectedItems(0).Text))

                If selItem IsNot Nothing Then
                    lvTVSourcesRegexTVShowMatching.SuspendLayout()
                    Dim iIndex As Integer = TVShowMatching.IndexOf(selItem)
                    Dim selIndex As Integer = lvTVSourcesRegexTVShowMatching.SelectedIndices(0)
                    TVShowMatching.Remove(selItem)
                    TVShowMatching.Insert(iIndex + 1, selItem)

                    RenumberTVShowMatching()
                    LoadTVShowMatching()

                    lvTVSourcesRegexTVShowMatching.Items(selIndex + 1).Selected = True
                    lvTVSourcesRegexTVShowMatching.ResumeLayout()
                End If

                EnableApplyButton()
                lvTVSourcesRegexTVShowMatching.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnTVSourcesRegexMultiPartMatchingReset_Click(ByVal sender As Object, ByVal e As EventArgs)
        txtTVSourcesRegexMultiPartMatching.Text = "^[-_ex]+([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)"
        EnableApplyButton()
    End Sub

    Private Sub ClearTVShowMatching()
        btnTVSourcesRegexTVShowMatchingAdd.Text = Master.eLang.GetString(115, "Add Regex")
        btnTVSourcesRegexTVShowMatchingAdd.Tag = String.Empty
        btnTVSourcesRegexTVShowMatchingAdd.Enabled = False
        txtTVSourcesRegexTVShowMatchingRegex.Text = String.Empty
        txtTVSourcesRegexTVShowMatchingDefaultSeason.Text = String.Empty
        chkTVSourcesRegexTVShowMatchingByDate.Checked = False
    End Sub

    Private Sub EditTVShowMatching(ByVal lItem As ListViewItem)
        btnTVSourcesRegexTVShowMatchingAdd.Text = Master.eLang.GetString(124, "Update Regex")
        btnTVSourcesRegexTVShowMatchingAdd.Tag = lItem.Text

        txtTVSourcesRegexTVShowMatchingRegex.Text = lItem.SubItems(1).Text.ToString
        txtTVSourcesRegexTVShowMatchingDefaultSeason.Text = If(Not lItem.SubItems(2).Text = "-1", lItem.SubItems(2).Text, String.Empty)

        Select Case lItem.SubItems(3).Text
            Case "Yes"
                chkTVSourcesRegexTVShowMatchingByDate.Checked = True
            Case "No"
                chkTVSourcesRegexTVShowMatchingByDate.Checked = False
        End Select
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub LoadTVShowMatching()
        Dim lvItem As ListViewItem
        lvTVSourcesRegexTVShowMatching.Items.Clear()
        For Each rShow As Settings.regexp In TVShowMatching
            lvItem = New ListViewItem(rShow.ID.ToString)
            lvItem.SubItems.Add(rShow.Regexp)
            lvItem.SubItems.Add(If(Not rShow.defaultSeason.ToString = "-1", rShow.defaultSeason.ToString, String.Empty))
            lvItem.SubItems.Add(If(rShow.byDate, "Yes", "No"))
            lvTVSourcesRegexTVShowMatching.Items.Add(lvItem)
        Next
    End Sub

    Private Sub LoadTVScraperOptionsOrdering()
        Dim items As New Dictionary(Of String, Enums.EpisodeOrdering)
        items.Add(Master.eLang.GetString(438, "Standard"), Enums.EpisodeOrdering.Standard)
        items.Add(Master.eLang.GetString(1067, "DVD"), Enums.EpisodeOrdering.DVD)
        items.Add(Master.eLang.GetString(839, "Absolute"), Enums.EpisodeOrdering.Absolute)
        items.Add(Master.eLang.GetString(1332, "Day Of Year"), Enums.EpisodeOrdering.DayOfYear)
        cbTVScraperOptionsOrdering.DataSource = items.ToList
        cbTVScraperOptionsOrdering.DisplayMember = "Key"
        cbTVScraperOptionsOrdering.ValueMember = "Value"
    End Sub

    Private Sub lvTVSourcesRegexTVShowMatching_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        If lvTVSourcesRegexTVShowMatching.SelectedItems.Count > 0 Then EditTVShowMatching(lvTVSourcesRegexTVShowMatching.SelectedItems(0))
    End Sub

    Private Sub lvTVSourcesRegexTVShowMatching_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then RemoveTVShowMatching()
    End Sub

    Private Sub lvTVSourcesRegexTVShowMatching_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not String.IsNullOrEmpty(btnTVSourcesRegexTVShowMatchingAdd.Tag.ToString) Then ClearTVShowMatching()
    End Sub

    Private Sub lvTVSources_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        lvTVSources.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub lvTVSources_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        If lvTVSources.SelectedItems.Count > 0 Then
            Using dTVSource As New dlgSourceTVShow
                If dTVSource.ShowDialog(Convert.ToInt32(lvTVSources.SelectedItems(0).Text)) = DialogResult.OK Then
                    RefreshTVSources()
                    Handle_NeedsReload_TVShow()
                    EnableApplyButton()
                End If
            End Using
        End If
    End Sub

    Private Sub lvTVSources_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then RemoveTVSource()
    End Sub

    Private Sub RefreshTVSources()
        Dim lvItem As ListViewItem
        lvTVSources.Items.Clear()
        Master.DB.Load_Sources_TVShow()
        For Each s As Database.DBSource In Master.TVShowSources
            lvItem = New ListViewItem(CStr(s.ID))
            lvItem.SubItems.Add(s.Name)
            lvItem.SubItems.Add(s.Path)
            lvItem.SubItems.Add(s.Language)
            lvItem.SubItems.Add(s.Ordering.ToString)
            lvItem.SubItems.Add(If(s.Exclude, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvItem.SubItems.Add(s.EpisodeSorting.ToString)
            lvItem.SubItems.Add(If(s.IsSingle, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvTVSources.Items.Add(lvItem)
        Next
    End Sub

    Private Sub RefreshTVShowFilters()
        lstTVShowFilter.Items.Clear()
        lstTVShowFilter.Items.AddRange(Master.eSettings.TVShowFilterCustom.ToArray)
    End Sub

    Private Sub RemoveTVEpisodeFilter()
        If lstTVEpisodeFilter.Items.Count > 0 AndAlso lstTVEpisodeFilter.SelectedItems.Count > 0 Then
            While lstTVEpisodeFilter.SelectedItems.Count > 0
                lstTVEpisodeFilter.Items.Remove(lstTVEpisodeFilter.SelectedItems(0))
            End While
            EnableApplyButton()
            Handle_NeedsReload_TVEpisode()
        End If
    End Sub

    Private Sub RemoveTVShowFilter()
        If lstTVShowFilter.Items.Count > 0 AndAlso lstTVShowFilter.SelectedItems.Count > 0 Then
            While lstTVShowFilter.SelectedItems.Count > 0
                lstTVShowFilter.Items.Remove(lstTVShowFilter.SelectedItems(0))
            End While
            EnableApplyButton()
            Handle_NeedsReload_TVShow()
        End If
    End Sub

    Private Sub RemoveTVShowMatching()
        Dim ID As Integer
        For Each lItem As ListViewItem In lvTVSourcesRegexTVShowMatching.SelectedItems
            ID = Convert.ToInt32(lItem.Text)
            Dim selRex = From lRegex As Settings.regexp In TVShowMatching Where lRegex.ID = ID
            If selRex.Count > 0 Then
                TVShowMatching.Remove(selRex(0))
                EnableApplyButton()
            End If
        Next
        LoadTVShowMatching()
    End Sub

    Private Sub RefreshTVEpisodeFilters()
        lstTVEpisodeFilter.Items.Clear()
        lstTVEpisodeFilter.Items.AddRange(Master.eSettings.TVEpisodeFilterCustom.ToArray)
    End Sub

    Private Sub RemoveTVSource()
        If lvTVSources.SelectedItems.Count > 0 Then
            If MessageBox.Show(Master.eLang.GetString(1033, "Are you sure you want to remove the selected sources? This will remove the tv shows from these sources from the Ember database."), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                lvTVSources.BeginUpdate()

                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                        Dim parSource As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parSource", DbType.Int64, 0, "idSource")
                        While lvTVSources.SelectedItems.Count > 0
                            parSource.Value = lvTVSources.SelectedItems(0).SubItems(0).Text
                            SQLcommand.CommandText = String.Concat("DELETE FROM tvshowsource WHERE idSource = (?);")
                            SQLcommand.ExecuteNonQuery()
                            lvTVSources.Items.Remove(lvTVSources.SelectedItems(0))
                        End While
                    End Using
                    SQLtransaction.Commit()
                End Using

                lvTVSources.Sort()
                lvTVSources.EndUpdate()
                lvTVSources.Refresh()

                EnableApplyButton()
            End If
        End If
    End Sub

    Private Sub RenumberTVShowMatching()
        For i As Integer = 0 To TVShowMatching.Count - 1
            TVShowMatching(i).ID = i
        Next
    End Sub

    Private Sub SetUp()
        lblTVSourcesDefaultsOrdering.Text = String.Concat(Master.eLang.GetString(797, "Default Episode Ordering"), ":")
        lblTVSourcesDefaultsLanguage.Text = String.Concat(Master.eLang.GetString(252, "Default Language for new Sources"), ":")
        colTVSourcesExclude.Text = Master.eLang.GetString(264, "Exclude")
        colTVSourcesLanguage.Text = Master.eLang.GetString(610, "Language")
        gbTVSourcesMiscOpts.Text = Master.eLang.GetString(429, "Miscellaneous")
        colTVSourcesName.Text = Master.eLang.GetString(232, "Name")
        colTVSourcesOrdering.Text = Master.eLang.GetString(1167, "Ordering")
        colTVSourcesPath.Text = Master.eLang.GetString(410, "Path")
        colTVSourcesSorting.Text = Master.eLang.GetString(895, "Sorting")
        btnRemTVSource.Text = Master.eLang.GetString(30, "Remove")
        btnTVSourcesRegexTVShowMatchingAdd.Tag = String.Empty
        btnTVSourcesRegexTVShowMatchingAdd.Text = Master.eLang.GetString(690, "Edit Regex")
        btnTVSourcesRegexTVShowMatchingClear.Text = Master.eLang.GetString(123, "Clear")
        btnTVSourcesRegexTVShowMatchingEdit.Text = Master.eLang.GetString(690, "Edit Regex")
        btnTVSourcesRegexTVShowMatchingRemove.Text = Master.eLang.GetString(30, "Remove")
        btnTVSourceEdit.Text = Master.eLang.GetString(535, "Edit Source")
        gbTVSourcesRegexTVShowMatching.Text = Master.eLang.GetString(691, "Show Match Regex")
        lblTVSourcesRegexTVShowMatchingByDate.Text = Master.eLang.GetString(698, "by Date")
        lblTVSourcesRegexTVShowMatchingRegex.Text = Master.eLang.GetString(699, "Regex")
        lblTVSourcesRegexTVShowMatchingDefaultSeason.Text = Master.eLang.GetString(695, "Default Season")
        tpTVSourcesGeneral.Text = Master.eLang.GetString(38, "General")
        tpTVSourcesRegex.Text = Master.eLang.GetString(699, "Regex")
        btnTVSourceAdd.Text = Master.eLang.GetString(407, "Add Source")
        chkTVCleanDB.Text = Master.eLang.GetString(668, "Clean database after updating library")
        chkTVGeneralIgnoreLastScan.Text = Master.eLang.GetString(669, "Ignore last scan time when updating library")
        chkTVScanOrderModify.Text = Master.eLang.GetString(796, "Scan in order of last write time")
        lblTVSkipLessThan.Text = Master.eLang.GetString(540, "Skip files smaller than:")
        lblTVSkipLessThanMB.Text = Master.eLang.GetString(539, "MB")
        chkTVEpisodeNoFilter.Text = Master.eLang.GetString(734, "Build Episode Title Instead of Filtering")
        gbTVEpisodeFilterOpts.Text = Master.eLang.GetString(671, "Episode Folder/File Name Filters")
        gbTVShowFilterOpts.Text = Master.eLang.GetString(670, "Show Folder/File Name Filters")
        chkTVEpisodeProperCase.Text = Master.eLang.GetString(452, "Convert Names to Proper Case")
        chkTVShowProperCase.Text = Master.eLang.GetString(452, "Convert Names to Proper Case")

        LoadTVScraperOptionsOrdering()

        lvTVSources.ListViewItemSorter = New ListViewItemComparer(1)
    End Sub

    Private Sub txtTVSourcesRegexTVShowMatchingRegex_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        ValidateTVShowMatching()
    End Sub

    Private Sub txtTVSourcesRegexTVShowMatchingDefaultSeason_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        ValidateTVShowMatching()
    End Sub

    Private Sub txtTVSkipLessThan_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub txtTVSkipLessThan_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        EnableApplyButton()
        Handle_NeedsDBClean_TV()
        Handle_NeedsDBUpdate_TV()
    End Sub

    Private Sub ValidateTVShowMatching()
        If Not String.IsNullOrEmpty(txtTVSourcesRegexTVShowMatchingRegex.Text) AndAlso (String.IsNullOrEmpty(txtTVSourcesRegexTVShowMatchingDefaultSeason.Text) OrElse Integer.TryParse(txtTVSourcesRegexTVShowMatchingDefaultSeason.Text, 0)) Then
            btnTVSourcesRegexTVShowMatchingAdd.Enabled = True
        Else
            btnTVSourcesRegexTVShowMatchingAdd.Enabled = False
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

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

#End Region 'Nested Types

End Class