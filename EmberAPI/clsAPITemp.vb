
Imports System.Drawing
Imports System.Windows.Forms

Public Class clsAPITemp

    Public Shared Sub ConvertToScraperGridView(ByRef tDataGridView As DataGridView)
        tDataGridView.AllowUserToAddRows = False
        tDataGridView.AllowUserToDeleteRows = False
        tDataGridView.AllowUserToOrderColumns = True
        tDataGridView.AllowUserToResizeColumns = False
        tDataGridView.AllowUserToResizeRows = False
        tDataGridView.Anchor = AnchorStyles.Left
        tDataGridView.BackgroundColor = Color.White
        tDataGridView.BorderStyle = BorderStyle.None
        tDataGridView.Height = 23
        tDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        tDataGridView.ColumnHeadersVisible = False
        tDataGridView.Margin = New Padding(0)
        tDataGridView.MultiSelect = False
        tDataGridView.RowHeadersVisible = False
        tDataGridView.ScrollBars = ScrollBars.None
        tDataGridView.Width = 250

        '*********** Test
        Dim lstScrapers As New List(Of String)
        lstScrapers.Add("IMDB")
        lstScrapers.Add("TMDB")
        lstScrapers.Add("Moviepilot")
        lstScrapers.Add("OFDB")

        For Each nScraper In lstScrapers
            Dim nButtonColumn As New DataGridViewButtonColumn
            nButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            nButtonColumn.FlatStyle = FlatStyle.Popup
            nButtonColumn.Name = nScraper
            nButtonColumn.Text = nScraper
            nButtonColumn.DefaultCellStyle = New DataGridViewCellStyle With {
                .ForeColor = Color.White,
                .SelectionForeColor = Color.White
            }
            tDataGridView.Columns.Add(nButtonColumn)
        Next

        tDataGridView.Rows.Add(lstScrapers.ToArray)

        Dim bEnabled As Boolean = True
        For i As Integer = 0 To lstScrapers.Count - 1
            tDataGridView.Rows(0).Cells(i).Tag = bEnabled
            bEnabled = Not bEnabled
        Next

        'calculate size based on columns
        Dim intWidth As Integer = 0
        'For Each nColumn As DataGridViewColumn In tDataGridView.Columns
        '    intWidth += nColumn.Width
        'Next
        'tDataGridView.Width = intWidth + 1

        AddHandler tDataGridView.CellContentClick, AddressOf CellContentClick
        AddHandler tDataGridView.CellPainting, AddressOf CellPainting
        AddHandler tDataGridView.MouseClick, AddressOf MouseClick
    End Sub

    Public Shared Sub CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim tDataGridView As DataGridView = CType(sender, DataGridView)
        If e.RowIndex >= 0 Then
            tDataGridView.Item(e.ColumnIndex, e.RowIndex).Tag = Not CType(tDataGridView.Item(e.ColumnIndex, e.RowIndex).Tag, Boolean)
        End If
    End Sub

    Public Shared Sub CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        Dim tDataGridView As DataGridView = CType(sender, DataGridView)
        Dim colName As String = tDataGridView.Columns(e.ColumnIndex).Name
        If String.IsNullOrEmpty(colName) Then
            Return
        End If

        If e.RowIndex >= 0 AndAlso Not tDataGridView.Item(e.ColumnIndex, e.RowIndex).Displayed Then
            e.Handled = True
            Return
        End If

        If e.RowIndex >= 0 Then
            If Convert.ToBoolean(tDataGridView.Item(e.ColumnIndex, e.RowIndex).Tag) Then
                e.CellStyle.BackColor = Color.Green
                e.CellStyle.SelectionBackColor = Color.Green
            Else
                e.CellStyle.BackColor = Color.Gray
                e.CellStyle.SelectionBackColor = Color.Gray
            End If
        End If
    End Sub

    Public Shared Sub MouseClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim tDataGridView As DataGridView = CType(sender, DataGridView)
            tDataGridView.ColumnHeadersVisible = Not tDataGridView.ColumnHeadersVisible
        End If
    End Sub
End Class