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

Public Class frmMovie_Source
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movie
    Dim _intImageIndex As Integer = 5
    Dim _intOrder As Integer = 200
    Dim _strName As String = "Movie_Source"
    Dim _strTitle As String = Master.eLang.GetString(555, "Sources")

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

#Region "Interface Methods"

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
            chkMovieGeneralMarkNew.Checked = .MovieGeneralMarkNew
            chkMovieProperCase.Checked = .MovieProperCase
            chkMovieCleanDB.Checked = .MovieCleanDB
            chkMovieGeneralIgnoreLastScan.Checked = .MovieGeneralIgnoreLastScan
            chkMovieScanOrderModify.Checked = .MovieScanOrderModify
            chkMovieSkipStackedSizeCheck.Checked = .MovieSkipStackedSizeCheck
            chkMovieSortBeforeScan.Checked = .MovieSortBeforeScan
            txtMovieSkipLessThan.Text = .MovieSkipLessThan.ToString

            If .MovieLevTolerance > 0 Then
                chkMovieLevTolerance.Checked = True
                txtMovieLevTolerance.Enabled = True
                txtMovieLevTolerance.Text = .MovieLevTolerance.ToString
            End If

            Try
                cbMovieGeneralLang.Items.Clear()
                cbMovieGeneralLang.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Description).ToArray)
                If cbMovieGeneralLang.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(.MovieGeneralLanguage) Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = .MovieGeneralLanguage)
                        If tLanguage IsNot Nothing Then
                            cbMovieGeneralLang.Text = tLanguage.Description
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.MovieGeneralLanguage))
                            If tLanguage IsNot Nothing Then
                                cbMovieGeneralLang.Text = tLanguage.Description
                            Else
                                cbMovieGeneralLang.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = "en-US").Description
                            End If
                        End If
                    Else
                        cbMovieGeneralLang.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = "en-US").Description
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

        End With

        RefreshMovieFilters()
        RefreshMovieSources()
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings
            .MovieFilterCustom.Clear()
            .MovieFilterCustom.AddRange(lstMovieFilters.Items.OfType(Of String).ToList)
            If .MovieFilterCustom.Count <= 0 Then .MovieFilterCustomIsEmpty = True
            .MovieGeneralMarkNew = chkMovieGeneralMarkNew.Checked
            .MovieLevTolerance = If(Not String.IsNullOrEmpty(txtMovieLevTolerance.Text), Convert.ToInt32(txtMovieLevTolerance.Text), 0)
            .MovieProperCase = chkMovieProperCase.Checked
            .MovieCleanDB = chkMovieCleanDB.Checked
            .MovieGeneralIgnoreLastScan = chkMovieGeneralIgnoreLastScan.Checked
            If Not String.IsNullOrEmpty(cbMovieGeneralLang.Text) Then
                .MovieGeneralLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Description = cbMovieGeneralLang.Text).Abbreviation
            End If
            If Not String.IsNullOrEmpty(txtMovieSkipLessThan.Text) AndAlso Integer.TryParse(txtMovieSkipLessThan.Text, 0) Then
                .MovieSkipLessThan = Convert.ToInt32(txtMovieSkipLessThan.Text)
            Else
                .MovieSkipLessThan = 0
            End If
            .MovieSkipStackedSizeCheck = chkMovieSkipStackedSizeCheck.Checked
            .MovieSortBeforeScan = chkMovieSortBeforeScan.Checked
            .MovieScanOrderModify = chkMovieScanOrderModify.Checked

        End With
    End Sub

#End Region 'Interface Methods

#Region "Methods"

    Private Sub btnMovieSourceEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSourceEdit.Click
        If lvMovieSources.SelectedItems.Count > 0 Then
            Using dMovieSource As New dlgSourceMovie
                If dMovieSource.ShowDialog(Convert.ToInt32(lvMovieSources.SelectedItems(0).Text)) = DialogResult.OK Then
                    RefreshMovieSources()
                    Handle_NeedsReload_Movie()  'TODO: Check if we have to use Reload or DBUpdate
                    EnableApplyButton()
                End If
            End Using
        End If
    End Sub

    Private Sub btnMovieFilterAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieFilterAdd.Click
        If Not String.IsNullOrEmpty(txtMovieFilter.Text) Then
            lstMovieFilters.Items.Add(txtMovieFilter.Text)
            txtMovieFilter.Text = String.Empty
            EnableApplyButton()
            Handle_NeedsReload_Movie()
        End If

        txtMovieFilter.Focus()
    End Sub

    Private Sub btnMovieFilterDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieFilterDown.Click
        Try
            If lstMovieFilters.Items.Count > 0 AndAlso lstMovieFilters.SelectedItem IsNot Nothing AndAlso lstMovieFilters.SelectedIndex < (lstMovieFilters.Items.Count - 1) Then
                Dim iIndex As Integer = lstMovieFilters.SelectedIndices(0)
                lstMovieFilters.Items.Insert(iIndex + 2, lstMovieFilters.SelectedItems(0))
                lstMovieFilters.Items.RemoveAt(iIndex)
                lstMovieFilters.SelectedIndex = iIndex + 1
                EnableApplyButton()
                Handle_NeedsReload_Movie()
                lstMovieFilters.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnMovieFilterUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieFilterUp.Click
        Try
            If lstMovieFilters.Items.Count > 0 AndAlso lstMovieFilters.SelectedItem IsNot Nothing AndAlso lstMovieFilters.SelectedIndex > 0 Then
                Dim iIndex As Integer = lstMovieFilters.SelectedIndices(0)
                lstMovieFilters.Items.Insert(iIndex - 1, lstMovieFilters.SelectedItems(0))
                lstMovieFilters.Items.RemoveAt(iIndex + 1)
                lstMovieFilters.SelectedIndex = iIndex - 1
                EnableApplyButton()
                Handle_NeedsReload_Movie()
                lstMovieFilters.Focus()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnMovieFilterReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieFilterReset.Click
        If MessageBox.Show(Master.eLang.GetString(842, "Are you sure you want to reset to the default list of movie filters?"), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Master.eSettings.SetDefaultsForLists(Enums.DefaultSettingType.MovieFilters, True)
            RefreshMovieFilters()
            EnableApplyButton()
        End If
    End Sub

    Private Sub btnMovieFilterRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieFilterRemove.Click
        RemoveMovieFilter()
    End Sub

    Private Sub btnMovieSourceAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSourceAdd.Click
        Using dSource As New dlgSourceMovie
            If dSource.ShowDialog = DialogResult.OK Then
                RefreshMovieSources()
                EnableApplyButton()
                Handle_NeedsDBUpdate_Movie()
            End If
        End Using
    End Sub

    Private Sub btnMovieSourceRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSourceRemove.Click
        RemoveMovieSource()
        Master.DB.Load_Sources_Movie()
    End Sub

    Private Sub cbMovieGeneralLang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMovieGeneralLang.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cbMovieGeneralLang.Text) Then
            Master.eSettings.MovieGeneralLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Description = cbMovieGeneralLang.Text).Abbreviation
        End If
    End Sub

    Private Sub chkMovieLevTolerance_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieLevTolerance.CheckedChanged
        EnableApplyButton()

        txtMovieLevTolerance.Enabled = chkMovieLevTolerance.Checked
        If Not chkMovieLevTolerance.Checked Then txtMovieLevTolerance.Text = String.Empty
    End Sub

    Private Sub chkMovieProperCase_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieProperCase.CheckedChanged
        EnableApplyButton()
        Handle_NeedsReload_Movie()
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub lstMovieFilters_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstMovieFilters.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveMovieFilter()
    End Sub

    Private Sub lvMovieSources_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovieSources.ColumnClick
        lvMovieSources.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub lvMovieSources_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvMovieSources.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveMovieSource()
    End Sub

    Private Sub lvMovieSources_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvMovieSources.DoubleClick
        If lvMovieSources.SelectedItems.Count > 0 Then
            Using dMovieSource As New dlgSourceMovie
                If dMovieSource.ShowDialog(Convert.ToInt32(lvMovieSources.SelectedItems(0).Text)) = DialogResult.OK Then
                    RefreshMovieSources()
                    Handle_NeedsReload_Movie()  'TODO: Check if we have to use Reload or DBUpdate
                    EnableApplyButton()
                End If
            End Using
        End If
    End Sub

    Private Sub RefreshMovieFilters()
        lstMovieFilters.Items.Clear()
        lstMovieFilters.Items.AddRange(Master.eSettings.MovieFilterCustom.ToArray)
    End Sub

    Private Sub RefreshMovieSources()
        Dim lvItem As ListViewItem
        lvMovieSources.Items.Clear()
        Master.DB.Load_Sources_Movie()
        For Each s As Database.DBSource In Master.MovieSources
            lvItem = New ListViewItem(CStr(s.ID))
            lvItem.SubItems.Add(s.Name)
            lvItem.SubItems.Add(s.Path)
            lvItem.SubItems.Add(s.Language)
            lvItem.SubItems.Add(If(s.Recursive, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvItem.SubItems.Add(If(s.UseFolderName, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvItem.SubItems.Add(If(s.IsSingle, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvItem.SubItems.Add(If(s.Exclude, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvItem.SubItems.Add(If(s.GetYear, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))
            lvMovieSources.Items.Add(lvItem)
        Next
    End Sub

    Private Sub RemoveMovieFilter()
        If lstMovieFilters.Items.Count > 0 AndAlso lstMovieFilters.SelectedItems.Count > 0 Then
            While lstMovieFilters.SelectedItems.Count > 0
                lstMovieFilters.Items.Remove(lstMovieFilters.SelectedItems(0))
            End While
            EnableApplyButton()
            Handle_NeedsReload_Movie()
        End If
    End Sub

    Private Sub RemoveMovieSource()
        If lvMovieSources.SelectedItems.Count > 0 Then
            If MessageBox.Show(Master.eLang.GetString(418, "Are you sure you want to remove the selected sources? This will remove the movies from these sources from the Ember database."), Master.eLang.GetString(104, "Are You Sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                lvMovieSources.BeginUpdate()

                Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                        Dim parSource As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parSource", DbType.String, 0, "idSource")
                        While lvMovieSources.SelectedItems.Count > 0
                            parSource.Value = lvMovieSources.SelectedItems(0).SubItems(0).Text
                            SQLcommand.CommandText = String.Concat("DELETE FROM moviesource WHERE idSource = (?);")
                            SQLcommand.ExecuteNonQuery()
                            lvMovieSources.Items.Remove(lvMovieSources.SelectedItems(0))
                        End While
                    End Using
                    SQLtransaction.Commit()
                End Using

                lvMovieSources.Sort()
                lvMovieSources.EndUpdate()
                lvMovieSources.Refresh()

                Functions.GetListOfSources()

                EnableApplyButton()
            End If
        End If
    End Sub

    Private Sub SetUp()
        chkMovieGeneralMarkNew.Text = Master.eLang.GetString(459, "Mark New Movies")
        chkMovieLevTolerance.Text = Master.eLang.GetString(462, "Check Title Match Confidence")
        chkMovieProperCase.Text = Master.eLang.GetString(452, "Convert Names to Proper Case")
        gbMovieGeneralFiltersOpts.Text = Master.eLang.GetString(451, "Folder/File Name Filters")
        lblMovieLevTolerance.Text = Master.eLang.GetString(461, "Mismatch Tolerance:")
        lblMovieSourcesDefaultsLanguage.Text = String.Concat(Master.eLang.GetString(252, "Default Language for new Sources"), ":")
        gbSources.Text = Master.eLang.GetString(555, "Sources")
        colMovieSourcesExclude.Text = Master.eLang.GetString(264, "Exclude")
        colMovieSourcesGetYear.Text = Master.eLang.GetString(586, "Get Year")
        colMovieSourcesLanguage.Text = Master.eLang.GetString(610, "Language")
        gbMovieSourcesMiscOpts.Text = Master.eLang.GetString(429, "Miscellaneous")
        colMovieSourcesName.Text = Master.eLang.GetString(232, "Name")
        colMovieSourcesPath.Text = Master.eLang.GetString(410, "Path")
        colMovieSourcesRecur.Text = Master.eLang.GetString(411, "Recursive")
        colMovieSourcesSingle.Text = Master.eLang.GetString(413, "Single Video")
        colMovieSourcesFolder.Text = Master.eLang.GetString(412, "Use Folder Name")
        btnMovieSourceAdd.Text = Master.eLang.GetString(407, "Add Source")
        btnMovieSourceEdit.Text = Master.eLang.GetString(535, "Edit Source")
        btnMovieSourceRemove.Text = Master.eLang.GetString(30, "Remove")
        chkMovieCleanDB.Text = Master.eLang.GetString(668, "Clean database after updating library")
        chkMovieGeneralIgnoreLastScan.Text = Master.eLang.GetString(669, "Ignore last scan time when updating library")
        chkMovieScanOrderModify.Text = Master.eLang.GetString(796, "Scan in order of last write time")
        chkMovieSkipStackedSizeCheck.Text = Master.eLang.GetString(538, "Skip Size Check of Stacked Files")
        chkMovieSortBeforeScan.Text = Master.eLang.GetString(712, "Sort files into folder before each library update")
        lblMovieSkipLessThan.Text = Master.eLang.GetString(540, "Skip files smaller than:")
        lblMovieSkipLessThanMB.Text = Master.eLang.GetString(539, "MB")

        lvMovieSources.ListViewItemSorter = New ListViewItemComparer(1)
    End Sub

    Private Sub txtMovieSkipLessThan_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMovieSkipLessThan.TextChanged
        EnableApplyButton()
        Handle_NeedsDBClean_Movie()
        Handle_NeedsDBUpdate_Movie()
    End Sub

    Private Sub txtMovieSkipLessThan_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMovieSkipLessThan.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub txtMovieLevTolerance_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMovieLevTolerance.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
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