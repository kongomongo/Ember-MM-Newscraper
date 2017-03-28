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
Imports System.Windows.Forms

Public Class frmMovieSet_Data
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movieset
    Dim _intImageIndex As Integer = 4
    Dim _intOrder As Integer = 300
    Dim _strName As String = "MovieSet_Data"
    Dim _strTitle As String = Master.eLang.GetString(556, "Data")

    Private _bDGVWidthCalculated As Boolean

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
        With Master.eSettings.Movieset.DataSettings
            chkMovieSetLockPlot.Checked = .Plot.Locked
            chkMovieSetLockTitle.Checked = .Title.Locked
            chkMovieSetScraperPlot.Checked = .Plot.Enabled
            chkMovieSetScraperTitle.Checked = .Title.Enabled

            FillMovieSetScraperTitleRenamer()
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movieset.DataSettings
            .Plot.Locked = chkMovieSetLockPlot.Checked
            .Title.Locked = chkMovieSetLockTitle.Checked
            .Plot.Enabled = chkMovieSetScraperPlot.Checked
            .Title.Enabled = chkMovieSetScraperTitle.Checked

            SaveMovieSetScraperTitleRenamer()
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub FillMovieSetScraperTitleRenamer()
        For Each sett As AdvancedSettingsSetting In clsXMLAdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("MovieSetTitleRenamer:"))
            Dim i As Integer = dgvMovieSetScraperTitleRenamer.Rows.Add(New Object() {sett.Name.Substring(21), sett.Value})
            If Not sett.DefaultValue = String.Empty Then
                dgvMovieSetScraperTitleRenamer.Rows(i).Tag = True
                dgvMovieSetScraperTitleRenamer.Rows(i).Cells(0).ReadOnly = True
                dgvMovieSetScraperTitleRenamer.Rows(i).Cells(0).Style.SelectionForeColor = Drawing.Color.Red
            Else
                dgvMovieSetScraperTitleRenamer.Rows(i).Tag = False
            End If
        Next
        dgvMovieSetScraperTitleRenamer.ClearSelection()
    End Sub

    Private Sub SaveMovieSetScraperTitleRenamer()
        Dim deleteitem As New List(Of String)
        For Each sett As AdvancedSettingsSetting In clsXMLAdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("MovieSetTitleRenamer:"))
            deleteitem.Add(sett.Name)
        Next

        Using settings = New clsXMLAdvancedSettings()
            For Each s As String In deleteitem
                settings.CleanSetting(s, "*EmberAPP")
            Next
            For Each r As DataGridViewRow In dgvMovieSetScraperTitleRenamer.Rows
                If Not String.IsNullOrEmpty(r.Cells(0).Value.ToString) AndAlso Not String.IsNullOrEmpty(r.Cells(1).Value.ToString) Then
                    settings.SetSetting(String.Concat("MovieSetTitleRenamer:", r.Cells(0).Value.ToString), r.Cells(1).Value.ToString, "*EmberAPP")
                End If
            Next
        End Using
    End Sub

    Private Sub SetUp()
        lblMovieSetScraperGlobalHeaderLock.Text = Master.eLang.GetString(24, "Lock")
        lblMovieSetScraperGlobalPlot.Text = Master.eLang.GetString(65, "Plot")
        lblMovieSetScraperGlobalTitle.Text = Master.eLang.GetString(21, "Title")
        btnMovieSetScraperTitleRenamerAdd.Text = Master.eLang.GetString(28, "Add")
        btnMovieSetScraperTitleRenamerRemove.Text = Master.eLang.GetString(30, "Remove")
        dgvMovieSetScraperTitleRenamer.Columns(0).HeaderText = Master.eLang.GetString(1277, "From")
        dgvMovieSetScraperTitleRenamer.Columns(1).HeaderText = Master.eLang.GetString(1278, "To")
        gbMovieSetScraperTitleRenamerOpts.Text = Master.eLang.GetString(1279, "Title Renamer")

        clsAPITemp.ConvertToScraperGridView(dgvPlot, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Data_Plot)))
        clsAPITemp.ConvertToScraperGridView(dgvTitle, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movieset_Data_Title)))

        clsAPITemp.ConvertToSearchEngineGridView(dgvSearchAdditional, Master.SearchEngineList.FindAll(Function(f) f.SearchMovieSet))
        clsAPITemp.ConvertToSearchEngineGridView(dgvSearchInitial, Master.SearchEngineList.FindAll(Function(f) f.SearchMovieSet))
    End Sub

    Private Sub btnMovieSetScraperTitleRenamerAdd_Click(sender As Object, e As EventArgs) Handles btnMovieSetScraperTitleRenamerAdd.Click
        Dim i As Integer = dgvMovieSetScraperTitleRenamer.Rows.Add(New Object() {String.Empty, String.Empty})
        dgvMovieSetScraperTitleRenamer.Rows(i).Tag = False
        dgvMovieSetScraperTitleRenamer.CurrentCell = dgvMovieSetScraperTitleRenamer.Rows(i).Cells(0)
        dgvMovieSetScraperTitleRenamer.BeginEdit(True)
        EnableApplyButton()
    End Sub

    Private Sub btnMovieSetScraperTitleRenamerRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieSetScraperTitleRenamerRemove.Click
        If dgvMovieSetScraperTitleRenamer.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvMovieSetScraperTitleRenamer.Rows(dgvMovieSetScraperTitleRenamer.SelectedCells(0).RowIndex).Tag) Then
            dgvMovieSetScraperTitleRenamer.Rows.RemoveAt(dgvMovieSetScraperTitleRenamer.SelectedCells(0).RowIndex)
            EnableApplyButton()
        End If
    End Sub

    Private Sub dgvMovieSetScraperTitleRenamer_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvMovieSetScraperTitleRenamer.CurrentCellDirtyStateChanged
        EnableApplyButton()
    End Sub

    Private Sub dgvMovieSetScraperMapper_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If dgvMovieSetScraperTitleRenamer.SelectedCells.Count > 0 AndAlso Not Convert.ToBoolean(dgvMovieSetScraperTitleRenamer.Rows(dgvMovieSetScraperTitleRenamer.SelectedCells(0).RowIndex).Tag) Then
            btnMovieSetScraperTitleRenamerRemove.Enabled = True
        Else
            btnMovieSetScraperTitleRenamerRemove.Enabled = False
        End If
    End Sub

    Private Sub dgvMovieSetScraperMapper_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        e.Handled = (e.KeyCode = Keys.Enter)
    End Sub
    ''' <summary>
    ''' Workaround to autosize the DGV based on column widths without change the row hights
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlSettings_VisibleChanged(sender As Object, e As EventArgs) Handles pnlSettings.VisibleChanged
        If Not _bDGVWidthCalculated AndAlso CType(sender, Panel).Visible Then
            tblScraperSettings.SuspendLayout()
            For i As Integer = 0 To tblScraperSettings.Controls.Count - 1
                Dim nType As Type = tblScraperSettings.Controls(i).GetType
                If nType.Name = "DataGridView" Then
                    Dim nDataGridView As DataGridView = CType(tblScraperSettings.Controls(i), DataGridView)
                    Dim intWidth As Integer = 0
                    For Each nColumn As DataGridViewColumn In nDataGridView.Columns
                        intWidth += nColumn.Width
                    Next
                    nDataGridView.Width = intWidth + 1
                End If
            Next
            tblScraperSettings.ResumeLayout()
            _bDGVWidthCalculated = True
        End If
    End Sub

#End Region 'Methods

End Class