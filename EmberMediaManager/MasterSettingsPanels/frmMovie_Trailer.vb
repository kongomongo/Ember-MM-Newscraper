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

Public Class frmMovie_Trailer
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movie
    Dim _intImageIndex As Integer = 8
    Dim _intOrder As Integer = 600
    Dim _strName As String = "Movie_Trailer"
    Dim _strTitle As String = Master.eLang.GetString(1195, "Trailers")

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
        With Master.eSettings.Movie.TrailerSettings
            cbMinVideoQual.SelectedValue = .MinVideoQuality
            cbPrefVideoQual.SelectedValue = .PrefVideoQuality
            chkKeepExisting.Checked = .KeepExisting
            txtDefaultSearch.Text = .DefaultSearch.ToString
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movie.TrailerSettings
            .DefaultSearch = txtDefaultSearch.Text
            .KeepExisting = chkKeepExisting.Checked
            .MinVideoQuality = CType(cbMinVideoQual.SelectedItem, KeyValuePair(Of String, Enums.TrailerVideoQuality)).Value
            .PrefVideoQuality = CType(cbPrefVideoQual.SelectedItem, KeyValuePair(Of String, Enums.TrailerVideoQuality)).Value
        End With
    End Sub

#End Region 'Interface Methods

#Region "Methods"

    Private Sub cbMovieTrailerPrefVideoQual_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        EnableApplyButton()

        If CType(cbPrefVideoQual.SelectedItem, KeyValuePair(Of String, Enums.TrailerVideoQuality)).Value = Enums.TrailerVideoQuality.Any Then
            cbMinVideoQual.Enabled = False
        Else
            cbMinVideoQual.Enabled = True
        End If
    End Sub

    Private Sub EnableApplyButton() Handles _
        cbMinVideoQual.SelectedValueChanged,
        cbPrefVideoQual.SelectedValueChanged,
        chkKeepExisting.CheckedChanged,
        txtDefaultSearch.TextChanged

        Handle_SettingsChanged()
    End Sub

    Private Sub LoadMovieTrailerQualities()
        Dim items As New Dictionary(Of String, Enums.TrailerVideoQuality)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TrailerVideoQuality.Any)
        items.Add("2160p 60fps", Enums.TrailerVideoQuality.HD2160p60fps)
        items.Add("2160p", Enums.TrailerVideoQuality.HD2160p)
        items.Add("1440p", Enums.TrailerVideoQuality.HD1440p)
        items.Add("1080p 60fps", Enums.TrailerVideoQuality.HD1080p60fps)
        items.Add("1080p", Enums.TrailerVideoQuality.HD1080p)
        items.Add("720p 60fps", Enums.TrailerVideoQuality.HD720p60fps)
        items.Add("720p", Enums.TrailerVideoQuality.HD720p)
        items.Add("480p", Enums.TrailerVideoQuality.HQ480p)
        items.Add("360p", Enums.TrailerVideoQuality.SQ360p)
        items.Add("240p", Enums.TrailerVideoQuality.SQ240p)
        items.Add("144p", Enums.TrailerVideoQuality.SQ144p)
        items.Add("144p 15fps", Enums.TrailerVideoQuality.SQ144p15fps)
        cbMinVideoQual.DataSource = items.ToList
        cbMinVideoQual.DisplayMember = "Key"
        cbMinVideoQual.ValueMember = "Value"
        cbPrefVideoQual.DataSource = items.ToList
        cbPrefVideoQual.DisplayMember = "Key"
        cbPrefVideoQual.ValueMember = "Value"
    End Sub

    Private Sub SetUp()
        LoadMovieTrailerQualities()

        chkKeepExisting.Text = Master.eLang.GetString(971, "Keep existing")
        lblDefaultSearch.Text = Master.eLang.GetString(1172, "Default Search Parameter:")
        lblMinQual.Text = Master.eLang.GetString(1027, "Minimum Quality")
        lblPrefQual.Text = Master.eLang.GetString(800, "Preferred Quality")

        clsAPITemp.ConvertToScraperGridView(dgvTrailer, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Trailer)))
    End Sub
    ''' <summary>
    ''' Workaround to autosize the DGV based on column widths without change the row hights
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlSettings_VisibleChanged(sender As Object, e As EventArgs) Handles pnlSettings.VisibleChanged
        If Not _bDGVWidthCalculated AndAlso CType(sender, Panel).Visible Then
            tblTrailer.SuspendLayout()
            For i As Integer = 0 To tblTrailer.Controls.Count - 1
                Dim nType As Type = tblTrailer.Controls(i).GetType
                If nType.Name = "DataGridView" Then
                    Dim nDataGridView As DataGridView = CType(tblTrailer.Controls(i), DataGridView)
                    Dim intWidth As Integer = 0
                    For Each nColumn As DataGridViewColumn In nDataGridView.Columns
                        intWidth += nColumn.Width
                    Next
                    nDataGridView.Width = intWidth + 1
                End If
            Next
            tblTrailer.ResumeLayout()
            _bDGVWidthCalculated = True
        End If
    End Sub

#End Region 'Methods

End Class