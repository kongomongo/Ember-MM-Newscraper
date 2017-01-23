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

Imports System.Data
Imports EmberAPI
Imports NLog

Public Class dlgSearchResults

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _WatchedList As List(Of clsAPISerienjunkies.TVShowContainer)
    Private _bsTVShows As New BindingSource
    Private _bsSearchResults As New BindingSource
    Private _bRunOnce As Boolean = True
    Private _intTVShowColumnsize(1) As Integer
    Private _lstMirrors As New List(Of MirrorContainer)

#End Region 'Fields

#Region "Constructors"

    Public Sub New(ByVal tAddonSettings As Addon.AddonSettings, ByVal tWatchedList As List(Of clsAPISerienjunkies.TVShowContainer))
        ' This call is required by the designer.
        InitializeComponent()
        scSearchResults.SplitterDistance = tAddonSettings.SearchResultsSplitterDistance
        Height = tAddonSettings.SearchResultsHeight
        Width = tAddonSettings.SearchResultsWidth
        WindowState = CType(tAddonSettings.SearchResultsWindowState, FormWindowState)
        Left = Master.AppPos.Left + (Master.AppPos.Width - Width) \ 2
        Top = Master.AppPos.Top + (Master.AppPos.Height - Height) \ 2
        StartPosition = FormStartPosition.Manual
        SetUp()
        _WatchedList = tWatchedList
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Sub cmnuDownload_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles cmnuDownload.ItemClicked
        If e.ClickedItem.Tag IsNot Nothing AndAlso Not String.IsNullOrEmpty(e.ClickedItem.Tag.ToString) Then
            Functions.Launch(e.ClickedItem.Tag.ToString)
        End If
    End Sub

    Private Sub dlgSearchResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_TVShows()
    End Sub

    Private Sub dgvSearchResults_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvSearchResults.MouseDown
        If e.Button = MouseButtons.Right And dgvSearchResults.RowCount > 0 Then
            cmnuDownload.Enabled = False
            cmnuDownload.Items.Clear()

            Dim dgvHTI As DataGridView.HitTestInfo = dgvSearchResults.HitTest(e.X, e.Y)
            If dgvHTI.Type = DataGridViewHitTestType.Cell Then
                If dgvSearchResults.SelectedRows.Count > 1 AndAlso dgvSearchResults.Rows(dgvHTI.RowIndex).Selected Then

                Else
                    If Not dgvSearchResults.Rows(dgvHTI.RowIndex).Selected Then
                        dgvSearchResults.CurrentCell = Nothing
                        dgvSearchResults.ClearSelection()
                        dgvSearchResults.Rows(dgvHTI.RowIndex).Selected = True
                        dgvSearchResults.CurrentCell = dgvSearchResults.Item("Description", dgvHTI.RowIndex)
                    Else
                        dgvSearchResults.Enabled = True
                    End If
                    Dim intID As Integer = CInt(dgvSearchResults.Item("ID", dgvHTI.RowIndex).Value)
                    For Each nMirror In _lstMirrors.Where(Function(f) f.ID = intID)
                        cmnuDownload.Items.Add(New ToolStripMenuItem With {.Text = nMirror.Hoster, .Tag = nMirror.URL})
                    Next
                End If
                cmnuDownload.Enabled = True
            Else
                cmnuDownload.Enabled = False
            End If
        End If
    End Sub

    Private Sub dgvTVShows_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTVShows.SelectionChanged
        If dgvTVShows.SelectedRows.Count = 1 Then
            Fill_SearchResults(CLng(dgvTVShows.SelectedRows(0).Cells(0).Value))
        End If
    End Sub

    Private Function GetTable_TVShows() As DataTable
        Dim dtTVShows As New DataTable

        dtTVShows.Columns.Add("ID", GetType(Long))
        dtTVShows.Columns.Add("Title", GetType(String))

        For Each nTVShow As clsAPISerienjunkies.TVShowContainer In _WatchedList
            If Not nTVShow.ID = -1 Then
                dtTVShows.Rows.Add(nTVShow.ID, nTVShow.Title)
            End If
        Next

        Return dtTVShows
    End Function

    Private Function GetTable_SearchResults(ByVal lngID As Long) As DataTable
        _lstMirrors.Clear()

        Dim dtSearchResults As New DataTable
        dtSearchResults.Columns.Add("ID", GetType(Integer))
        dtSearchResults.Columns.Add("S", GetType(Integer))
        dtSearchResults.Columns.Add("E", GetType(Integer))
        dtSearchResults.Columns.Add("SP", GetType(Boolean))
        dtSearchResults.Columns.Add("Description", GetType(String))
        dtSearchResults.Columns.Add("Language", GetType(String))
        dtSearchResults.Columns.Add("EP Description", GetType(String))
        dtSearchResults.Columns.Add("Mirrors", GetType(String))

        For Each nTVShow As clsAPISerienjunkies.TVShowContainer In _WatchedList.Where(Function(f) f.ID = lngID)
            Dim intID As Integer = 0
            For Each nEpisode In nTVShow.EpisodeList
                Dim strMirrors As String = CreateLinks(nEpisode.MirrorList)
                dtSearchResults.Rows.Add(
                    intID,
                    nEpisode.SeasonNumber,
                    If(Not nEpisode.IsSeasonPack, nEpisode.EpisodeNumber, Nothing),
                    nEpisode.IsSeasonPack,
                    nEpisode.Release,
                    nEpisode.Language,
                    nEpisode.Description,
                    strMirrors
                    )
                For Each nMirror In nEpisode.MirrorList
                    _lstMirrors.Add(New MirrorContainer With {
                                    .ID = intID,
                                    .Hoster = nMirror.Hoster,
                                    .URL = nMirror.URL
                                    })
                Next
                intID += 1
            Next
        Next

        Return dtSearchResults
    End Function

    Private Function CreateLinks(ByVal tLinkList As List(Of clsAPISerienjunkies.Mirror)) As String
        Dim strHosters As String = String.Empty

        Dim lstHoster As New List(Of String)
        For Each nLink In tLinkList
            lstHoster.Add(nLink.Hoster)
        Next

        strHosters = String.Join(" | ", lstHoster)

        Return strHosters
    End Function

    Private Sub Fill_TVShows()
        With dgvTVShows
            If Not _bRunOnce Then
                For Each c As DataGridViewColumn In .Columns
                    _intTVShowColumnsize(c.Index) = c.Width
                Next
            End If
            .DataSource = Nothing
            .Rows.Clear()
            .AutoGenerateColumns = True
            If _bRunOnce Then
                .Tag = False
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If
            _bsTVShows.DataSource = GetTable_TVShows()
            .DataSource = _bsTVShows
            .Columns(0).Visible = False
            .Columns(1).Visible = True
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            If _bRunOnce Then
                For Each c As DataGridViewColumn In .Columns
                    c.MinimumWidth = Convert.ToInt32(.Width / 5)
                Next
                .AutoResizeColumns()
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                For Each c As DataGridViewColumn In .Columns
                    c.MinimumWidth = 20
                Next
                _bRunOnce = False
            Else
                .Tag = True
                For Each c As DataGridViewColumn In .Columns
                    c.Width = _intTVShowColumnsize(c.Index)
                Next
                .Tag = False
            End If
        End With
    End Sub

    Private Sub Fill_SearchResults(ByVal lngID As Long)
        With dgvSearchResults
            If Not _bRunOnce Then
                For Each c As DataGridViewColumn In .Columns
                    ' _columnsize(c.Index) = c.Width
                Next
            End If
            .DataSource = Nothing
            .Rows.Clear()
            .AutoGenerateColumns = True
            If _bRunOnce Then
                .Tag = False
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If
            _bsSearchResults.DataSource = GetTable_SearchResults(lngID)
            .DataSource = _bsSearchResults
            .Columns(0).Visible = False
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(1).ToolTipText = "Season"
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).ToolTipText = "Episode"
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(3).ToolTipText = "Seasonpack"
            If _bRunOnce Then
                For Each c As DataGridViewColumn In .Columns
                    c.MinimumWidth = Convert.ToInt32(.Width / 5)
                Next
                .AutoResizeColumns()
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                For Each c As DataGridViewColumn In .Columns
                    c.MinimumWidth = 20
                Next
                _bRunOnce = False
            Else
                .Tag = True
                For Each c As DataGridViewColumn In .Columns
                    'c.Width = _columnsize(c.Index)
                Next
                .Tag = False
            End If
        End With
    End Sub

    Private Sub SetUp()

    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class MirrorContainer
        Public ID As Integer = -1
        Public Hoster As String = String.Empty
        Public URL As String = String.Empty
    End Class

#End Region 'Nested Types

End Class