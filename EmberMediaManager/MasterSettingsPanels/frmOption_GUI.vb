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
Imports System.IO
Imports NLog
Imports System.Windows.Forms

Public Class frmOption_GUI
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Options
    Dim _intImageIndex As Integer = 0
    Dim _intOrder As Integer = 100
    Dim _strName As String = "Option_GUI"
    Dim _strTitle As String = "GUI"

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
        With Manager.mSettings.General
            cbGeneralDaemonDrive.SelectedItem = .GeneralDaemonDrive
            cbGeneralDateTime.SelectedValue = .GeneralDateTime
            cbGeneralLanguage.SelectedItem = .GeneralLanguage
            cbGeneralMovieTheme.SelectedItem = .ThemeMovie
            cbGeneralMovieSetTheme.SelectedItem = .ThemeMovieset
            cbGeneralTVEpisodeTheme.SelectedItem = .ThemeTVEpisode
            cbGeneralTVShowTheme.SelectedItem = .ThemeTVShow
            chkGeneralCheckUpdates.Checked = .GeneralCheckUpdates
            chkGeneralDateAddedIgnoreNFO.Checked = .GeneralDateAddedIgnoreNFO
            chkGeneralDigitGrpSymbolVotes.Checked = .GeneralDigitGrpSymbolVotes
            chkGeneralImageFilter.Checked = .GeneralImageFilter
            chkGeneralImageFilterAutoscraper.Checked = .GeneralImageFilterAutoscraper
            txtGeneralImageFilterFanartMatchRate.Enabled = .GeneralImageFilterFanart
            chkGeneralImageFilterFanart.Checked = .GeneralImageFilterFanart
            chkGeneralImageFilterImagedialog.Checked = .GeneralImageFilterImagedialog
            chkGeneralImageFilterPoster.Checked = .GeneralImageFilterPoster
            txtGeneralImageFilterPosterMatchRate.Enabled = .GeneralImageFilterPoster
            chkGeneralDoubleClickScrape.Checked = .DoubleClickScrape
            chkGeneralDisplayBanner.Checked = .DisplayBanner
            chkGeneralDisplayCharacterArt.Checked = .DisplayCharacterArt
            chkGeneralDisplayClearArt.Checked = .DisplayClearArt
            chkGeneralDisplayClearLogo.Checked = .DisplayClearLogo
            chkGeneralDisplayDiscArt.Checked = .DisplayDiscArt
            chkGeneralDisplayFanart.Checked = .DisplayFanart
            chkGeneralDisplayFanartSmall.Checked = .DisplayFanartSmall
            chkGeneralDisplayLandscape.Checked = .DisplayLandscape
            chkGeneralDisplayPoster.Checked = .DisplayPoster
            chkGeneralOverwriteNfo.Checked = .GeneralOverwriteNfo
            chkGeneralDisplayGenresText.Checked = .DisplayGenreText
            chkGeneralDisplayLangFlags.Checked = .DisplayLanguageFlags
            chkGeneralDisplayImgDims.Checked = .DisplayImageDimensions
            chkGeneralDisplayImgNames.Checked = .DisplayImageNames
            chkGeneralSourceFromFolder.Checked = .GeneralSourceFromFolder
            txtGeneralImageFilterPosterMatchRate.Text = .GeneralImageFilterPosterMatchTolerance.ToString
            txtGeneralImageFilterFanartMatchRate.Text = .GeneralImageFilterFanartMatchTolerance.ToString
            txtGeneralDaemonPath.Text = .GeneralDaemonPath.ToString
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Manager.mSettings.General
            .GeneralCheckUpdates = chkGeneralCheckUpdates.Checked
            .GeneralDateAddedIgnoreNFO = chkGeneralDateAddedIgnoreNFO.Checked
            .GeneralDigitGrpSymbolVotes = chkGeneralDigitGrpSymbolVotes.Checked
            .GeneralDateTime = CType(cbGeneralDateTime.SelectedItem, KeyValuePair(Of String, Enums.DateTime)).Value
            .DoubleClickScrape = chkGeneralDoubleClickScrape.Checked
            .GeneralDaemonDrive = cbGeneralDaemonDrive.Text
            .GeneralDaemonPath = txtGeneralDaemonPath.Text
            .DisplayBanner = chkGeneralDisplayBanner.Checked
            .DisplayCharacterArt = chkGeneralDisplayCharacterArt.Checked
            .DisplayClearArt = chkGeneralDisplayClearArt.Checked
            .DisplayClearLogo = chkGeneralDisplayClearLogo.Checked
            .DisplayDiscArt = chkGeneralDisplayDiscArt.Checked
            .DisplayFanart = chkGeneralDisplayFanart.Checked
            .DisplayFanartSmall = chkGeneralDisplayFanartSmall.Checked
            .DisplayLandscape = chkGeneralDisplayLandscape.Checked
            .DisplayPoster = chkGeneralDisplayPoster.Checked
            .GeneralImageFilter = chkGeneralImageFilter.Checked
            .GeneralImageFilterAutoscraper = chkGeneralImageFilterAutoscraper.Checked
            .GeneralImageFilterFanart = chkGeneralImageFilterFanart.Checked
            .GeneralImageFilterImagedialog = chkGeneralImageFilterImagedialog.Checked
            .GeneralImageFilterPoster = chkGeneralImageFilterPoster.Checked
            If Not String.IsNullOrEmpty(txtGeneralImageFilterFanartMatchRate.Text) AndAlso Integer.TryParse(txtGeneralImageFilterFanartMatchRate.Text, 4) Then
                .GeneralImageFilterFanartMatchTolerance = Convert.ToInt32(txtGeneralImageFilterFanartMatchRate.Text)
            Else
                .GeneralImageFilterFanartMatchTolerance = 4
            End If
            If Not String.IsNullOrEmpty(txtGeneralImageFilterPosterMatchRate.Text) AndAlso Integer.TryParse(txtGeneralImageFilterPosterMatchRate.Text, 1) Then
                .GeneralImageFilterPosterMatchTolerance = Convert.ToInt32(txtGeneralImageFilterPosterMatchRate.Text)
            Else
                .GeneralImageFilterPosterMatchTolerance = 1
            End If
            .GeneralLanguage = cbGeneralLanguage.Text
            .ThemeMovie = cbGeneralMovieTheme.Text
            .ThemeMovieset = cbGeneralMovieSetTheme.Text
            .GeneralOverwriteNfo = chkGeneralOverwriteNfo.Checked
            .DisplayGenreText = chkGeneralDisplayGenresText.Checked
            .DisplayLanguageFlags = chkGeneralDisplayLangFlags.Checked
            .DisplayImageDimensions = chkGeneralDisplayImgDims.Checked
            .DisplayImageNames = chkGeneralDisplayImgNames.Checked
            .GeneralSourceFromFolder = chkGeneralSourceFromFolder.Checked
            .ThemeTVEpisode = cbGeneralTVEpisodeTheme.Text
            .ThemeTVShow = cbGeneralTVShowTheme.Text

        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub LoadGeneralDateTime()
        Dim items As New Dictionary(Of String, Enums.DateTime)
        items.Add(Master.eLang.GetString(1210, "Current DateTime when adding"), Enums.DateTime.Now)
        items.Add(Master.eLang.GetString(1227, "ctime (fallback to mtime)"), Enums.DateTime.ctime)
        items.Add(Master.eLang.GetString(1211, "mtime (fallback to ctime)"), Enums.DateTime.mtime)
        items.Add(Master.eLang.GetString(1212, "Newer of mtime and ctime"), Enums.DateTime.Newer)
        cbGeneralDateTime.DataSource = items.ToList
        cbGeneralDateTime.DisplayMember = "Key"
        cbGeneralDateTime.ValueMember = "Value"
    End Sub

    Private Sub LoadIntLangs()
        cbGeneralLanguage.Items.Clear()
        If Directory.Exists(Path.Combine(Functions.AppPath, "Langs")) Then
            Dim alL As New List(Of String)
            Dim alLangs As New List(Of String)
            Try
                alL.AddRange(Directory.GetFiles(Path.Combine(Functions.AppPath, "Langs"), "*).xml"))
            Catch
            End Try
            alLangs.AddRange(alL.Cast(Of String)().Select(Function(AL) Path.GetFileNameWithoutExtension(AL)).ToList)
            cbGeneralLanguage.Items.AddRange(alLangs.ToArray)
        End If
    End Sub

    Private Sub LoadThemes()
        cbGeneralMovieTheme.Items.Clear()
        cbGeneralMovieSetTheme.Items.Clear()
        cbGeneralTVShowTheme.Items.Clear()
        cbGeneralTVEpisodeTheme.Items.Clear()
        If Directory.Exists(Path.Combine(Functions.AppPath, "Themes")) Then
            Dim mT As New List(Of String)
            Dim msT As New List(Of String)
            Dim sT As New List(Of String)
            Dim eT As New List(Of String)
            Try
                mT.AddRange(Directory.GetFiles(Path.Combine(Functions.AppPath, "Themes"), "movie-*.xml"))
            Catch
            End Try
            cbGeneralMovieTheme.Items.AddRange(mT.Cast(Of String)().Select(Function(AL) Path.GetFileNameWithoutExtension(AL).Replace("movie-", String.Empty)).ToArray)
            Try
                msT.AddRange(Directory.GetFiles(Path.Combine(Functions.AppPath, "Themes"), "movieset-*.xml"))
            Catch
            End Try
            cbGeneralMovieSetTheme.Items.AddRange(msT.Cast(Of String)().Select(Function(AL) Path.GetFileNameWithoutExtension(AL).Replace("movieset-", String.Empty)).ToArray)
            Try
                sT.AddRange(Directory.GetFiles(Path.Combine(Functions.AppPath, "Themes"), "tvshow-*.xml"))
            Catch
            End Try
            cbGeneralTVShowTheme.Items.AddRange(sT.Cast(Of String)().Select(Function(AL) Path.GetFileNameWithoutExtension(AL).Replace("tvshow-", String.Empty)).ToArray)
            Try
                eT.AddRange(Directory.GetFiles(Path.Combine(Functions.AppPath, "Themes"), "tvep-*.xml"))
            Catch
            End Try
            cbGeneralTVEpisodeTheme.Items.AddRange(eT.Cast(Of String)().Select(Function(AL) Path.GetFileNameWithoutExtension(AL).Replace("tvep-", String.Empty)).ToArray)
        End If
    End Sub

    Private Sub btnGeneralDaemonPathBrowse_Click(sender As Object, e As EventArgs) Handles btnGeneralDaemonPathBrowse.Click
        Try
            With fileBrowse
                .Filter = "Virtual Drive|DTAgent.exe;VCDMount.exe"
                If .ShowDialog = DialogResult.OK Then
                    If Not String.IsNullOrEmpty(.FileName) Then
                        txtGeneralDaemonPath.Text = .FileName
                        EnableApplyButton()
                    End If
                End If
            End With
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnGeneralDigitGrpSymbolSettings_Click(sender As Object, e As EventArgs) Handles btnGeneralDigitGrpSymbolSettings.Click
        Try
            Process.Start("INTL.CPL")
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub cbGeneralLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbGeneralLanguage.SelectedIndexChanged
        If Not cbGeneralLanguage.SelectedItem.ToString = Master.eSettings.GeneralLanguage Then
            Handle_NeedsRestart()
        End If
        EnableApplyButton()
    End Sub

    Private Sub CheckHideSettings()
        If chkGeneralDisplayBanner.Checked OrElse chkGeneralDisplayCharacterArt.Checked OrElse chkGeneralDisplayClearArt.Checked OrElse chkGeneralDisplayClearLogo.Checked OrElse
              chkGeneralDisplayDiscArt.Checked OrElse chkGeneralDisplayFanart.Checked OrElse chkGeneralDisplayFanartSmall.Checked OrElse chkGeneralDisplayLandscape.Checked OrElse chkGeneralDisplayPoster.Checked Then
            chkGeneralDisplayImgDims.Enabled = True
            chkGeneralDisplayImgNames.Enabled = True
        Else
            chkGeneralDisplayImgDims.Enabled = False
            chkGeneralDisplayImgNames.Enabled = False
        End If
    End Sub

    Private Sub chkGeneralDisplayBanner_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayBanner.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayCharacterArt_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayCharacterArt.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayClearArt_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayClearArt.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayClearLogo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayClearLogo.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayDiscArt_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayDiscArt.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayFanart_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayFanart.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayLandscape_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayLandscape.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayPoster_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayPoster.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralDisplayFanartSmall_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGeneralDisplayFanartSmall.CheckedChanged
        EnableApplyButton()
        CheckHideSettings()
    End Sub

    Private Sub chkGeneralImageFilter_CheckedChanged(sender As Object, e As EventArgs)
        EnableApplyButton()
        chkGeneralImageFilterAutoscraper.Enabled = chkGeneralImageFilter.Checked
        chkGeneralImageFilterFanart.Enabled = chkGeneralImageFilter.Checked
        chkGeneralImageFilterImagedialog.Enabled = chkGeneralImageFilter.Checked
        chkGeneralImageFilterPoster.Enabled = chkGeneralImageFilter.Checked
        lblGeneralImageFilterFanartMatchRate.Enabled = chkGeneralImageFilter.Checked
        lblGeneralImageFilterPosterMatchRate.Enabled = chkGeneralImageFilter.Checked
        txtGeneralImageFilterFanartMatchRate.Enabled = chkGeneralImageFilter.Checked
        txtGeneralImageFilterPosterMatchRate.Enabled = chkGeneralImageFilter.Checked
    End Sub

    Private Sub chkGeneralImageFilterAutoscraperImagedialog_CheckedChanged(sender As Object, e As EventArgs)
        EnableApplyButton()
        If chkGeneralImageFilterImagedialog.Checked = False AndAlso chkGeneralImageFilterAutoscraper.Checked = False Then
            chkGeneralImageFilterPoster.Enabled = False
            chkGeneralImageFilterFanart.Enabled = False
        Else
            chkGeneralImageFilterPoster.Enabled = True
            chkGeneralImageFilterFanart.Enabled = True
        End If
    End Sub
    Private Sub chkGeneralImageFilterPoster_CheckedChanged(sender As Object, e As EventArgs)
        EnableApplyButton()
        lblGeneralImageFilterPosterMatchRate.Enabled = chkGeneralImageFilterPoster.Checked
        txtGeneralImageFilterPosterMatchRate.Enabled = chkGeneralImageFilterPoster.Checked
    End Sub
    Private Sub chkGeneralImageFilterFanart_CheckedChanged(sender As Object, e As EventArgs)
        EnableApplyButton()
        lblGeneralImageFilterFanartMatchRate.Enabled = chkGeneralImageFilterFanart.Checked
        txtGeneralImageFilterFanartMatchRate.Enabled = chkGeneralImageFilterFanart.Checked
    End Sub

    Private Sub txtGeneralImageFilterMatchRate_TextChanged(sender As Object, e As EventArgs)
        If chkGeneralImageFilter.Checked Then
            Dim txtbox As TextBox = CType(sender, TextBox)
            Dim matchfactor As Integer = 0
            Dim NotGood As Boolean = False
            If Integer.TryParse(txtbox.Text, matchfactor) Then
                If matchfactor < 0 OrElse matchfactor > 10 Then
                    NotGood = True
                End If
            Else
                NotGood = True
            End If
            If NotGood Then
                txtbox.Text = String.Empty
                MessageBox.Show(Master.eLang.GetString(1460, "Match Tolerance should be between 0 - 10 | 0 = 100% identical images, 10= different images"), Master.eLang.GetString(356, "Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub EnableApplyButton() Handles _
        chkGeneralImageFilterAutoscraper.CheckedChanged,
        chkGeneralImageFilterFanart.CheckedChanged,
        chkGeneralImageFilterImagedialog.CheckedChanged,
        chkGeneralImageFilterPoster.CheckedChanged

        Handle_SettingsChanged()
    End Sub

    Private Sub SetUp()
        gbGeneralMainWindowOpts.Text = Master.eLang.GetString(1152, "Main Window")
        gbGeneralMiscOpts.Text = Master.eLang.GetString(429, "Miscellaneous")
        btnGeneralDigitGrpSymbolSettings.Text = Master.eLang.GetString(420, "Settings")
        chkGeneralCheckUpdates.Text = Master.eLang.GetString(432, "Check for Updates")
        chkGeneralDateAddedIgnoreNFO.Text = Master.eLang.GetString(1209, "Ignore <dateadded> from NFO")
        chkGeneralDigitGrpSymbolVotes.Text = Master.eLang.GetString(1387, "Use digit grouping symbol for Votes count")
        chkGeneralDoubleClickScrape.Text = Master.eLang.GetString(1198, "Enable Image Scrape On Double Right Click")
        chkGeneralDisplayBanner.Text = Master.eLang.GetString(1146, "Display Banner")
        chkGeneralDisplayCharacterArt.Text = Master.eLang.GetString(1147, "Display CharacterArt")
        chkGeneralDisplayClearArt.Text = Master.eLang.GetString(1148, "Display ClearArt")
        chkGeneralDisplayClearLogo.Text = Master.eLang.GetString(1149, "Display ClearLogo")
        chkGeneralDisplayDiscArt.Text = Master.eLang.GetString(1150, "Display DiscArt")
        chkGeneralDisplayFanart.Text = Master.eLang.GetString(455, "Display Fanart")
        chkGeneralDisplayFanartSmall.Text = Master.eLang.GetString(967, "Display Small Fanart")
        chkGeneralDisplayLandscape.Text = Master.eLang.GetString(1151, "Display Landscape")
        chkGeneralDisplayPoster.Text = Master.eLang.GetString(456, "Display Poster")
        chkGeneralImageFilter.Text = Master.eLang.GetString(1459, "Activate ImageFilter to avoid duplicate images")
        chkGeneralImageFilterAutoscraper.Text = Master.eLang.GetString(1457, "Autoscraper")
        chkGeneralImageFilterFanart.Text = Master.eLang.GetString(149, "Fanart")
        chkGeneralImageFilterImagedialog.Text = Master.eLang.GetString(1458, "Imagedialog")
        chkGeneralImageFilterPoster.Text = Master.eLang.GetString(148, "Poster")
        chkGeneralOverwriteNfo.Text = Master.eLang.GetString(433, "Overwrite Non-conforming nfos")
        chkGeneralDisplayGenresText.Text = Master.eLang.GetString(453, "Always Display Genre Text")
        chkGeneralDisplayLangFlags.Text = Master.eLang.GetString(489, "Display Language Flags")
        chkGeneralDisplayImgDims.Text = Master.eLang.GetString(457, "Display Image Dimensions")
        chkGeneralDisplayImgNames.Text = Master.eLang.GetString(1255, "Display Image Names")
        chkGeneralSourceFromFolder.Text = Master.eLang.GetString(711, "Include Folder Name in Source Type Check")
        gbGeneralDaemon.Text = Master.eLang.GetString(1261, "Configuration ISO Filescanning")
        gbGeneralDateAdded.Text = Master.eLang.GetString(792, "Adding Date")
        gbGeneralInterface.Text = Master.eLang.GetString(795, "Interface")
        gbGeneralThemes.Text = Master.eLang.GetString(629, "GUI Themes")
        lblGeneralDaemonDrive.Text = Master.eLang.GetString(989, "Driveletter")
        lblGeneralDaemonPath.Text = Master.eLang.GetString(990, "Path to DTAgent.exe/VCDMount.exe")
        lblGeneralImageFilterPosterMatchRate.Text = Master.eLang.GetString(148, "Poster") & " " & Master.eLang.GetString(461, "Mismatch Tolerance:")
        lblGeneralImageFilterFanartMatchRate.Text = Master.eLang.GetString(149, "Fanart") & " " & Master.eLang.GetString(461, "Mismatch Tolerance:")
        lblGeneralMovieSetTheme.Text = String.Concat(Master.eLang.GetString(1155, "MovieSet Theme"), ":")
        lblGeneralMovieTheme.Text = String.Concat(Master.eLang.GetString(620, "Movie Theme"), ":")
        lblGeneralOverwriteNfo.Text = Master.eLang.GetString(434, "(If unchecked, non-conforming nfos will be renamed to <filename>.info)")
        lblGeneralTVEpisodeTheme.Text = String.Concat(Master.eLang.GetString(667, "Episode Theme"), ":")
        lblGeneralTVShowTheme.Text = String.Concat(Master.eLang.GetString(666, "TV Show Theme"), ":")
        lblGeneralntLang.Text = Master.eLang.GetString(430, "Interface Language:")

        LoadGeneralDateTime()
        LoadIntLangs()
        LoadThemes()
    End Sub

#End Region 'Methods

End Class