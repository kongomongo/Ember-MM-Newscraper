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

Public Class frmTV_Image
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.TV
    Dim _intImageIndex As Integer = 6
    Dim _intOrder As Integer = 500
    Dim _strName As String = "TV_Image"
    Dim _strTitle As String = Master.eLang.GetString(497, "Images")

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
        With Master.eSettings.TV.ImageSettings.TVAllSeasons
            cbTVAllSeasonsBannerPrefSize.SelectedValue = .Banner.PrefSize
            cbTVAllSeasonsFanartPrefSize.SelectedValue = .Fanart.PrefSize
            cbTVAllSeasonsLandscapePrefSize.SelectedValue = .Landscape.PrefSize
            cbTVAllSeasonsPosterPrefSize.SelectedValue = .Poster.PrefSize
            chkTVAllSeasonsBannerKeepExisting.Checked = .Banner.KeepExisting
            chkTVAllSeasonsBannerPrefSizeOnly.Checked = .Banner.PrefSizeOnly
            chkTVAllSeasonsFanartKeepExisting.Checked = .Fanart.KeepExisting
            chkTVAllSeasonsFanartPrefSizeOnly.Checked = .Fanart.PrefSizeOnly
            chkTVAllSeasonsLandscapeKeepExisting.Checked = .Landscape.KeepExisting
            chkTVAllSeasonsLandscapePrefSizeOnly.Checked = .Landscape.PrefSizeOnly
            chkTVAllSeasonsPosterKeepExisting.Checked = .Poster.KeepExisting
            chkTVAllSeasonsPosterPrefSizeOnly.Checked = .Poster.PrefSizeOnly
            txtTVAllSeasonsBannerMaxHeight.Text = .Banner.MaxHeight.ToString
            txtTVAllSeasonsBannerMaxWidth.Text = .Banner.MaxWidth.ToString
            txtTVAllSeasonsFanartMaxHeight.Text = .Fanart.MaxHeight.ToString
            txtTVAllSeasonsFanartMaxWidth.Text = .Fanart.MaxWidth.ToString
            txtTVAllSeasonsLandscapeMaxHeight.Text = .Landscape.MaxHeight.ToString
            txtTVAllSeasonsLandscapeMaxWidth.Text = .Landscape.MaxWidth.ToString
            txtTVAllSeasonsPosterMaxHeight.Text = .Poster.MaxHeight.ToString
            txtTVAllSeasonsPosterMaxWidth.Text = .Poster.MaxWidth.ToString
        End With

        With Master.eSettings.TV.ImageSettings.TVEpisode
            cbTVEpisodeFanartPrefSize.SelectedValue = .Fanart.PrefSize
            cbTVEpisodePosterPrefSize.SelectedValue = .Poster.PrefSize
            chkTVEpisodeFanartKeepExisting.Checked = .Fanart.KeepExisting
            chkTVEpisodeFanartPrefSizeOnly.Checked = .Fanart.PrefSizeOnly
            chkTVEpisodePosterKeepExisting.Checked = .Poster.KeepExisting
            chkTVEpisodePosterPrefSizeOnly.Checked = .Poster.PrefSizeOnly
            txtTVEpisodeFanartMaxHeight.Text = .Fanart.MaxHeight.ToString
            txtTVEpisodeFanartMaxWidth.Text = .Fanart.MaxWidth.ToString
            txtTVEpisodePosterMaxHeight.Text = .Poster.MaxHeight.ToString
            txtTVEpisodePosterMaxWidth.Text = .Poster.MaxWidth.ToString
        End With

        With Master.eSettings.TV.ImageSettings.TVSeason
            cbTVSeasonBannerPrefSize.SelectedValue = .Banner.PrefSize
            cbTVSeasonFanartPrefSize.SelectedValue = .Fanart.PrefSize
            cbTVSeasonLandscapePrefSize.SelectedValue = .Landscape.PrefSize
            cbTVSeasonPosterPrefSize.SelectedValue = .Poster.PrefSize
            chkTVSeasonBannerKeepExisting.Checked = .Banner.KeepExisting
            chkTVSeasonBannerPrefSizeOnly.Checked = .Banner.PrefSizeOnly
            chkTVSeasonFanartKeepExisting.Checked = .Fanart.KeepExisting
            chkTVSeasonFanartPrefSizeOnly.Checked = .Fanart.PrefSizeOnly
            chkTVSeasonLandscapeKeepExisting.Checked = .Landscape.KeepExisting
            chkTVSeasonLandscapePrefSizeOnly.Checked = .Landscape.PrefSizeOnly
            chkTVSeasonPosterKeepExisting.Checked = .Poster.KeepExisting
            chkTVSeasonPosterPrefSizeOnly.Checked = .Poster.PrefSizeOnly
            txtTVSeasonBannerMaxHeight.Text = .Banner.MaxHeight.ToString
            txtTVSeasonBannerMaxWidth.Text = .Banner.MaxWidth.ToString
            txtTVSeasonFanartMaxHeight.Text = .Fanart.MaxHeight.ToString
            txtTVSeasonFanartMaxWidth.Text = .Fanart.MaxWidth.ToString
            txtTVSeasonLandscapeMaxHeight.Text = .Landscape.MaxHeight.ToString
            txtTVSeasonLandscapeMaxWidth.Text = .Landscape.MaxWidth.ToString
            txtTVSeasonPosterMaxHeight.Text = .Poster.MaxHeight.ToString
            txtTVSeasonPosterMaxWidth.Text = .Poster.MaxWidth.ToString
        End With

        With Master.eSettings.TV.ImageSettings.TVShow
            'chkTVShowExtrafanartsPreselect.Checked = ExtrafanartsPreselect
            cbTVShowBannerPrefSize.SelectedValue = .Banner.PrefSize
            cbTVShowCharacterArtPrefSize.SelectedValue = .CharacterArt.PrefSize
            cbTVShowClearArtPrefSize.SelectedValue = .ClearArt.PrefSize
            cbTVShowClearLogoPrefSize.SelectedValue = .ClearLogo.PrefSize
            cbTVShowExtrafanartsPrefSize.SelectedValue = .Extrafanarts.PrefSize
            cbTVShowFanartPrefSize.SelectedValue = .Fanart.PrefSize
            cbTVShowLandscapePrefSize.SelectedValue = .Landscape.PrefSize
            cbTVShowPosterPrefSize.SelectedValue = .Poster.PrefSize
            chkTVShowBannerKeepExisting.Checked = .Banner.KeepExisting
            chkTVShowBannerPrefSizeOnly.Checked = .Banner.PrefSizeOnly
            chkTVShowCharacterArtKeepExisting.Checked = .CharacterArt.KeepExisting
            chkTVShowCharacterArtPrefSizeOnly.Checked = .CharacterArt.PrefSizeOnly
            chkTVShowClearArtKeepExisting.Checked = .ClearArt.KeepExisting
            chkTVShowClearArtPrefSizeOnly.Checked = .ClearArt.PrefSizeOnly
            chkTVShowClearLogoKeepExisting.Checked = .ClearLogo.KeepExisting
            chkTVShowClearLogoPrefSizeOnly.Checked = .ClearLogo.PrefSizeOnly
            chkTVShowExtrafanartsKeepExisting.Checked = .Extrafanarts.KeepExisting
            chkTVShowExtrafanartsPrefSizeOnly.Checked = .Extrafanarts.PrefSizeOnly
            chkTVShowFanartKeepExisting.Checked = .Fanart.KeepExisting
            chkTVShowFanartPrefSizeOnly.Checked = .Fanart.PrefSizeOnly
            chkTVShowLandscapeKeepExisting.Checked = .Landscape.KeepExisting
            chkTVShowLandscapePrefSizeOnly.Checked = .Landscape.PrefSizeOnly
            chkTVShowPosterKeepExisting.Checked = .Poster.KeepExisting
            chkTVShowPosterPrefSizeOnly.Checked = .Poster.PrefSizeOnly
            txtTVShowBannerMaxHeight.Text = .Banner.MaxHeight.ToString
            txtTVShowBannerMaxWidth.Text = .Banner.MaxWidth.ToString
            txtTVShowExtrafanartsLimit.Text = .Extrafanarts.Limit.ToString
            txtTVShowExtrafanartsMaxHeight.Text = .Extrafanarts.MaxHeight.ToString
            txtTVShowExtrafanartsMaxWidth.Text = .Extrafanarts.MaxWidth.ToString
            txtTVShowFanartMaxHeight.Text = .Fanart.MaxHeight.ToString
            txtTVShowFanartMaxWidth.Text = .Fanart.MaxWidth.ToString
            txtTVShowLandscapeMaxHeight.Text = .Landscape.MaxHeight.ToString
            txtTVShowLandscapeMaxWidth.Text = .Landscape.MaxWidth.ToString
            txtTVShowPosterMaxHeight.Text = .Poster.MaxHeight.ToString
            txtTVShowPosterWidth.Text = .Poster.MaxWidth.ToString
        End With

        With Master.eSettings.TV.ImageSettings
            chkTVImagesCacheEnabled.Checked = .TVShow.ImagesCacheEnabled
            chkTVImagesDisplayImageSelect.Checked = .ImagesDisplayImageSelect
            chkTVImagesForceLanguage.Checked = .Language.ForceLanguage
            If .Language.GetMediaLanguageOnly Then
                chkTVImagesMediaLanguageOnly.Checked = True
                chkTVImagesGetBlankImages.Checked = .Language.GetBlankImages
                chkTVImagesGetEnglishImages.Checked = .Language.GetEnglishImages
            End If

            Try
                cbTVImagesForcedLanguage.Items.Clear()
                cbTVImagesForcedLanguage.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Name).Distinct.ToArray)
                If cbTVImagesForcedLanguage.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(.Language.ForcedLanguage) Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = .Language.ForcedLanguage)
                        If tLanguage IsNot Nothing Then
                            cbTVImagesForcedLanguage.Text = tLanguage.Name
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.Language.ForcedLanguage))
                            If tLanguage IsNot Nothing Then
                                cbTVImagesForcedLanguage.Text = tLanguage.Name
                            Else
                                cbTVImagesForcedLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = "en").Name
                            End If
                        End If
                    Else
                        cbTVImagesForcedLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = "en").Name
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.TV.ImageSettings.TVAllSeasons
            .Banner.KeepExisting = chkTVAllSeasonsBannerKeepExisting.Checked
            .Banner.MaxHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsBannerMaxHeight.Text), Convert.ToInt32(txtTVAllSeasonsBannerMaxHeight.Text), 0)
            .Banner.MaxWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsBannerMaxWidth.Text), Convert.ToInt32(txtTVAllSeasonsBannerMaxWidth.Text), 0)
            .Banner.PrefSize = CType(cbTVAllSeasonsBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Banner.PrefSizeOnly = chkTVAllSeasonsBannerPrefSizeOnly.Checked
            .Fanart.KeepExisting = chkTVAllSeasonsFanartKeepExisting.Checked
            .Fanart.MaxHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsFanartMaxHeight.Text), Convert.ToInt32(txtTVAllSeasonsFanartMaxHeight.Text), 0)
            .Fanart.MaxWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsFanartMaxWidth.Text), Convert.ToInt32(txtTVAllSeasonsFanartMaxWidth.Text), 0)
            .Fanart.PrefSize = CType(cbTVAllSeasonsFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Fanart.PrefSizeOnly = chkTVAllSeasonsFanartPrefSizeOnly.Checked
            .Landscape.KeepExisting = chkTVAllSeasonsLandscapeKeepExisting.Checked
            .Landscape.MaxHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsLandscapeMaxHeight.Text), Convert.ToInt32(txtTVAllSeasonsLandscapeMaxHeight.Text), 0)
            .Landscape.MaxWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsLandscapeMaxWidth.Text), Convert.ToInt32(txtTVAllSeasonsLandscapeMaxWidth.Text), 0)
            .Landscape.PrefSize = CType(cbTVAllSeasonsLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Landscape.PrefSizeOnly = chkTVAllSeasonsLandscapePrefSizeOnly.Checked
            .Poster.KeepExisting = chkTVAllSeasonsPosterKeepExisting.Checked
            .Poster.MaxHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsPosterMaxHeight.Text), Convert.ToInt32(txtTVAllSeasonsPosterMaxHeight.Text), 0)
            .Poster.MaxWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsPosterMaxWidth.Text), Convert.ToInt32(txtTVAllSeasonsPosterMaxWidth.Text), 0)
            .Poster.PrefSize = CType(cbTVAllSeasonsPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Poster.PrefSizeOnly = chkTVAllSeasonsPosterPrefSizeOnly.Checked
        End With

        With Master.eSettings.TV.ImageSettings.TVEpisode
            .Fanart.KeepExisting = chkTVEpisodeFanartKeepExisting.Checked
            .Fanart.MaxHeight = If(Not String.IsNullOrEmpty(txtTVEpisodeFanartMaxHeight.Text), Convert.ToInt32(txtTVEpisodeFanartMaxHeight.Text), 0)
            .Fanart.MaxWidth = If(Not String.IsNullOrEmpty(txtTVEpisodeFanartMaxWidth.Text), Convert.ToInt32(txtTVEpisodeFanartMaxWidth.Text), 0)
            .Fanart.PrefSize = CType(cbTVEpisodeFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Fanart.PrefSizeOnly = chkTVEpisodeFanartPrefSizeOnly.Checked
            .Poster.KeepExisting = chkTVEpisodePosterKeepExisting.Checked
            .Poster.MaxHeight = If(Not String.IsNullOrEmpty(txtTVEpisodePosterMaxHeight.Text), Convert.ToInt32(txtTVEpisodePosterMaxHeight.Text), 0)
            .Poster.MaxWidth = If(Not String.IsNullOrEmpty(txtTVEpisodePosterMaxWidth.Text), Convert.ToInt32(txtTVEpisodePosterMaxWidth.Text), 0)
            .Poster.PrefSize = CType(cbTVEpisodePosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Poster.PrefSizeOnly = chkTVEpisodePosterPrefSizeOnly.Checked
        End With

        With Master.eSettings.TV.ImageSettings.TVSeason
            .Banner.KeepExisting = chkTVSeasonBannerKeepExisting.Checked
            .Banner.MaxHeight = If(Not String.IsNullOrEmpty(txtTVSeasonBannerMaxHeight.Text), Convert.ToInt32(txtTVSeasonBannerMaxHeight.Text), 0)
            .Banner.MaxWidth = If(Not String.IsNullOrEmpty(txtTVSeasonBannerMaxWidth.Text), Convert.ToInt32(txtTVSeasonBannerMaxWidth.Text), 0)
            .Banner.PrefSize = CType(cbTVSeasonBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Banner.PrefSizeOnly = chkTVSeasonBannerPrefSizeOnly.Checked
            .Fanart.KeepExisting = chkTVSeasonFanartKeepExisting.Checked
            .Fanart.MaxHeight = If(Not String.IsNullOrEmpty(txtTVSeasonFanartMaxHeight.Text), Convert.ToInt32(txtTVSeasonFanartMaxHeight.Text), 0)
            .Fanart.MaxWidth = If(Not String.IsNullOrEmpty(txtTVSeasonFanartMaxWidth.Text), Convert.ToInt32(txtTVSeasonFanartMaxWidth.Text), 0)
            .Fanart.PrefSize = CType(cbTVSeasonFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Fanart.PrefSizeOnly = chkTVSeasonFanartPrefSizeOnly.Checked
            .Landscape.KeepExisting = chkTVSeasonLandscapeKeepExisting.Checked
            .Landscape.MaxHeight = If(Not String.IsNullOrEmpty(txtTVSeasonLandscapeMaxHeight.Text), Convert.ToInt32(txtTVSeasonLandscapeMaxHeight.Text), 0)
            .Landscape.MaxWidth = If(Not String.IsNullOrEmpty(txtTVSeasonLandscapeMaxWidth.Text), Convert.ToInt32(txtTVSeasonLandscapeMaxWidth.Text), 0)
            .Landscape.PrefSize = CType(cbTVSeasonLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Landscape.PrefSizeOnly = chkTVSeasonLandscapePrefSizeOnly.Checked
            .Poster.KeepExisting = chkTVSeasonPosterKeepExisting.Checked
            .Poster.MaxHeight = If(Not String.IsNullOrEmpty(txtTVSeasonPosterMaxHeight.Text), Convert.ToInt32(txtTVSeasonPosterMaxHeight.Text), 0)
            .Poster.MaxWidth = If(Not String.IsNullOrEmpty(txtTVSeasonPosterMaxWidth.Text), Convert.ToInt32(txtTVSeasonPosterMaxWidth.Text), 0)
            .Poster.PrefSize = CType(cbTVSeasonPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Poster.PrefSizeOnly = chkTVSeasonPosterPrefSizeOnly.Checked
        End With

        With Master.eSettings.TV.ImageSettings.TVShow
            '.TVShowExtrafanartsPreselect = chkTVShowExtrafanartsPreselect.Checked
            .Banner.KeepExisting = chkTVShowBannerKeepExisting.Checked
            .Banner.MaxHeight = If(Not String.IsNullOrEmpty(txtTVShowBannerMaxHeight.Text), Convert.ToInt32(txtTVShowBannerMaxHeight.Text), 0)
            .Banner.MaxWidth = If(Not String.IsNullOrEmpty(txtTVShowBannerMaxWidth.Text), Convert.ToInt32(txtTVShowBannerMaxWidth.Text), 0)
            .Banner.PrefSize = CType(cbTVShowBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Banner.PrefSizeOnly = chkTVShowBannerPrefSizeOnly.Checked
            .CharacterArt.KeepExisting = chkTVShowCharacterArtKeepExisting.Checked
            .CharacterArt.PrefSize = CType(cbTVShowCharacterArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .CharacterArt.PrefSizeOnly = chkTVShowCharacterArtPrefSizeOnly.Checked
            .ClearArt.KeepExisting = chkTVShowClearArtKeepExisting.Checked
            .ClearArt.PrefSize = CType(cbTVShowClearArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .ClearArt.PrefSizeOnly = chkTVShowClearArtPrefSizeOnly.Checked
            .ClearLogo.KeepExisting = chkTVShowClearLogoKeepExisting.Checked
            .ClearLogo.PrefSize = CType(cbTVShowClearLogoPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .ClearLogo.PrefSizeOnly = chkTVShowClearLogoPrefSizeOnly.Checked
            .Extrafanarts.KeepExisting = chkTVShowExtrafanartsKeepExisting.Checked
            .Extrafanarts.Limit = If(Not String.IsNullOrEmpty(txtTVShowExtrafanartsLimit.Text), Convert.ToInt32(txtTVShowExtrafanartsLimit.Text), 0)
            .Extrafanarts.MaxHeight = If(Not String.IsNullOrEmpty(txtTVShowExtrafanartsMaxHeight.Text), Convert.ToInt32(txtTVShowExtrafanartsMaxHeight.Text), 0)
            .Extrafanarts.MaxWidth = If(Not String.IsNullOrEmpty(txtTVShowExtrafanartsMaxWidth.Text), Convert.ToInt32(txtTVShowExtrafanartsMaxWidth.Text), 0)
            .Extrafanarts.PrefSize = CType(cbTVShowExtrafanartsPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Extrafanarts.PrefSizeOnly = chkTVShowExtrafanartsPrefSizeOnly.Checked
            .Extrafanarts.PrefSizeOnly = chkTVShowExtrafanartsPrefSizeOnly.Checked
            .Fanart.KeepExisting = chkTVShowFanartKeepExisting.Checked
            .Fanart.MaxHeight = If(Not String.IsNullOrEmpty(txtTVShowFanartMaxHeight.Text), Convert.ToInt32(txtTVShowFanartMaxHeight.Text), 0)
            .Fanart.MaxWidth = If(Not String.IsNullOrEmpty(txtTVShowFanartMaxWidth.Text), Convert.ToInt32(txtTVShowFanartMaxWidth.Text), 0)
            .Fanart.PrefSize = CType(cbTVShowFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Fanart.PrefSizeOnly = chkTVShowFanartKeepExisting.Checked
            .Landscape.KeepExisting = chkTVShowLandscapeKeepExisting.Checked
            .Landscape.MaxHeight = If(Not String.IsNullOrEmpty(txtTVShowLandscapeMaxHeight.Text), Convert.ToInt32(txtTVShowLandscapeMaxHeight.Text), 0)
            .Landscape.MaxWidth = If(Not String.IsNullOrEmpty(txtTVShowLandscapeMaxWidth.Text), Convert.ToInt32(txtTVShowLandscapeMaxWidth.Text), 0)
            .Landscape.PrefSize = CType(cbTVShowLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Landscape.PrefSizeOnly = chkTVShowLandscapePrefSizeOnly.Checked
            .Poster.KeepExisting = chkTVShowPosterKeepExisting.Checked
            .Poster.MaxHeight = If(Not String.IsNullOrEmpty(txtTVShowPosterMaxHeight.Text), Convert.ToInt32(txtTVShowPosterMaxHeight.Text), 0)
            .Poster.MaxWidth = If(Not String.IsNullOrEmpty(txtTVShowPosterWidth.Text), Convert.ToInt32(txtTVShowPosterWidth.Text), 0)
            .Poster.PrefSize = CType(cbTVShowPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.ImageSize)).Value
            .Poster.PrefSizeOnly = chkTVShowPosterPrefSizeOnly.Checked
        End With

        With Master.eSettings.TV.ImageSettings
            .ImagesCacheEnabled = chkTVImagesCacheEnabled.Checked
            .ImagesDisplayImageSelect = chkTVImagesDisplayImageSelect.Checked
            If Not String.IsNullOrEmpty(cbTVImagesForcedLanguage.Text) Then
                .Language.ForcedLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = cbTVImagesForcedLanguage.Text).Abbrevation_MainLanguage
            End If
            .Language.ForceLanguage = chkTVImagesForceLanguage.Checked
            .Language.GetBlankImages = chkTVImagesGetBlankImages.Checked
            .Language.GetEnglishImages = chkTVImagesGetEnglishImages.Checked
            .Language.GetMediaLanguageOnly = chkTVImagesMediaLanguageOnly.Checked
        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub chkTVImagesForceLanguage_CheckedChanged(sender As Object, e As EventArgs) Handles chkTVImagesForceLanguage.CheckedChanged
        EnableApplyButton()

        cbTVImagesForcedLanguage.Enabled = chkTVImagesForceLanguage.Checked
    End Sub

    Private Sub chkTVImagesMediaLanguageOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkTVImagesMediaLanguageOnly.CheckedChanged
        EnableApplyButton()

        chkTVImagesGetBlankImages.Enabled = chkTVImagesMediaLanguageOnly.Checked
        chkTVImagesGetEnglishImages.Enabled = chkTVImagesMediaLanguageOnly.Checked

        If Not chkTVImagesMediaLanguageOnly.Checked Then
            chkTVImagesGetBlankImages.Checked = False
            chkTVImagesGetEnglishImages.Checked = False
        End If
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub LoadBannerSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x185", Enums.ImageSize.HD185)
        items.Add("758x140", Enums.ImageSize.HD140)
        cbTVAllSeasonsBannerPrefSize.DataSource = items.ToList
        cbTVAllSeasonsBannerPrefSize.DisplayMember = "Key"
        cbTVAllSeasonsBannerPrefSize.ValueMember = "Value"
        cbTVSeasonBannerPrefSize.DataSource = items.ToList
        cbTVSeasonBannerPrefSize.DisplayMember = "Key"
        cbTVSeasonBannerPrefSize.ValueMember = "Value"
        cbTVShowBannerPrefSize.DataSource = items.ToList
        cbTVShowBannerPrefSize.DisplayMember = "Key"
        cbTVShowBannerPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadCharacterArtSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("512x512", Enums.ImageSize.HD512)
        cbTVShowCharacterArtPrefSize.DataSource = items.ToList
        cbTVShowCharacterArtPrefSize.DisplayMember = "Key"
        cbTVShowCharacterArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearArtSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x562", Enums.ImageSize.HD562)
        items.Add("500x281", Enums.ImageSize.SD281)
        cbTVShowClearArtPrefSize.DataSource = items.ToList
        cbTVShowClearArtPrefSize.DisplayMember = "Key"
        cbTVShowClearArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearLogoSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("800x310", Enums.ImageSize.HD310)
        items.Add("400x155", Enums.ImageSize.SD155)
        cbTVShowClearLogoPrefSize.DataSource = items.ToList
        cbTVShowClearLogoPrefSize.DisplayMember = "Key"
        cbTVShowClearLogoPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadFanartSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("3840x2160", Enums.ImageSize.UHD2160)
        items.Add("2560x1440", Enums.ImageSize.QHD1440)
        items.Add("1920x1080", Enums.ImageSize.HD1080)
        items.Add("1280x720", Enums.ImageSize.HD720)
        cbTVAllSeasonsFanartPrefSize.DataSource = items.ToList
        cbTVAllSeasonsFanartPrefSize.DisplayMember = "Key"
        cbTVAllSeasonsFanartPrefSize.ValueMember = "Value"
        cbTVEpisodeFanartPrefSize.DataSource = items.ToList
        cbTVEpisodeFanartPrefSize.DisplayMember = "Key"
        cbTVEpisodeFanartPrefSize.ValueMember = "Value"
        cbTVSeasonFanartPrefSize.DataSource = items.ToList
        cbTVSeasonFanartPrefSize.DisplayMember = "Key"
        cbTVSeasonFanartPrefSize.ValueMember = "Value"
        cbTVShowExtrafanartsPrefSize.DataSource = items.ToList
        cbTVShowExtrafanartsPrefSize.DisplayMember = "Key"
        cbTVShowExtrafanartsPrefSize.ValueMember = "Value"
        cbTVShowFanartPrefSize.DataSource = items.ToList
        cbTVShowFanartPrefSize.DisplayMember = "Key"
        cbTVShowFanartPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadLandscapeSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("1000x562", Enums.ImageSize.HD562)
        items.Add("500x281", Enums.ImageSize.SD281)
        cbTVAllSeasonsLandscapePrefSize.DataSource = items.ToList
        cbTVAllSeasonsLandscapePrefSize.DisplayMember = "Key"
        cbTVAllSeasonsLandscapePrefSize.ValueMember = "Value"
        cbTVSeasonLandscapePrefSize.DataSource = items.ToList
        cbTVSeasonLandscapePrefSize.DisplayMember = "Key"
        cbTVSeasonLandscapePrefSize.ValueMember = "Value"
        cbTVShowLandscapePrefSize.DataSource = items.ToList
        cbTVShowLandscapePrefSize.DisplayMember = "Key"
        cbTVShowLandscapePrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadPosterSizes()
        Dim items As New Dictionary(Of String, Enums.ImageSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items.Add("2000x3000", Enums.ImageSize.UHD3000)
        items.Add("1000x1500", Enums.ImageSize.HD1500)
        items.Add("1000x1426", Enums.ImageSize.HD1426)
        items.Add("680x1000", Enums.ImageSize.HD1000)
        cbTVAllSeasonsPosterPrefSize.DataSource = items.ToList
        cbTVAllSeasonsPosterPrefSize.DisplayMember = "Key"
        cbTVAllSeasonsPosterPrefSize.ValueMember = "Value"
        cbTVShowPosterPrefSize.DataSource = items.ToList
        cbTVShowPosterPrefSize.DisplayMember = "Key"
        cbTVShowPosterPrefSize.ValueMember = "Value"

        Dim items2 As New Dictionary(Of String, Enums.ImageSize)
        items2.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items2.Add("1000x1500", Enums.ImageSize.HD1500)
        items2.Add("1000x1426", Enums.ImageSize.HD1426)
        items2.Add("400x578", Enums.ImageSize.HD578)
        cbTVSeasonPosterPrefSize.DataSource = items2.ToList
        cbTVSeasonPosterPrefSize.DisplayMember = "Key"
        cbTVSeasonPosterPrefSize.ValueMember = "Value"

        Dim items3 As New Dictionary(Of String, Enums.ImageSize)
        items3.Add(Master.eLang.GetString(745, "Any"), Enums.ImageSize.Any)
        items3.Add("3840x2160", Enums.ImageSize.UHD2160)
        items3.Add("1920x1080", Enums.ImageSize.HD1080)
        items3.Add("1280x720", Enums.ImageSize.HD720)
        items3.Add("400x225", Enums.ImageSize.SD225)
        cbTVEpisodePosterPrefSize.DataSource = items3.ToList
        cbTVEpisodePosterPrefSize.DisplayMember = "Key"
        cbTVEpisodePosterPrefSize.ValueMember = "Value"
    End Sub

    Private Sub SetUp()
        lblAllSeasons.Text = Master.eLang.GetString(1202, "All Seasons")
        chkTVImagesGetBlankImages.Text = Master.eLang.GetString(1207, "Also Get Blank Images")
        chkTVImagesGetEnglishImages.Text = Master.eLang.GetString(737, "Also Get English Images")
        lblCharacterArt_TVShow.Text = Master.eLang.GetString(1140, "CharacterArt")
        lblClearArt_TVShow.Text = Master.eLang.GetString(1096, "ClearArt")
        lblClearLogo_TVShow.Text = Master.eLang.GetString(1097, "ClearLogo")
        chkTVImagesDisplayImageSelect.Text = Master.eLang.GetString(499, "Display ""Image Select"" dialog while single scraping")
        chkTVImagesNotSaveURLToNfo.Text = Master.eLang.GetString(498, "Do not save URLs to NFO")
        chkTVImagesCacheEnabled.Text = Master.eLang.GetString(249, "Enable Image Caching")
        lblEpisode.Text = Master.eLang.GetString(727, "Episode")
        lblExtrafanarts_TVShow.Text = Master.eLang.GetString(992, "Extrafanarts")
        chkTVImagesForceLanguage.Text = Master.eLang.GetString(1034, "Force Language")
        gbTVImagesOpts.Text = Master.eLang.GetString(497, "Images")
        lblLimit.Text = Master.eLang.GetString(578, "Limit")
        chkTVImagesMediaLanguageOnly.Text = Master.eLang.GetString(736, "Only Get Images for the Media Language")
        gbTVImagesLanguageOpts.Text = Master.eLang.GetString(741, "Preferred Language")
        lblSeason.Text = Master.eLang.GetString(650, "Season")
        lblTVShow.Text = Master.eLang.GetString(700, "TV Show")
        'chkTVShowExtrafanartsPreselect.Text = Master.eLang.GetString(1023, "Preselect in ""Image Select"" dialog")
        lblPreferredSize.Text = Master.eLang.GetString(482, "Preferred Size")
        lblKeepExisting.Text = Master.eLang.GetString(971, "Keep existing")
        lblHeight.Text = Master.eLang.GetString(480, "Max Height")
        lblWidth.Text = Master.eLang.GetString(479, "Max Width")
        lblOnly.Text = Master.eLang.GetString(145, "Only")

        'Banner
        Dim strBanner As String = Master.eLang.GetString(838, "Banner")
        lblBanner_TVAllSeasons.Text = strBanner
        lblBanner_TVSeason.Text = strBanner
        lblBanner_TVShow.Text = strBanner

        'Fanart
        Dim strFanart As String = Master.eLang.GetString(149, "Fanart")
        lblFanart_TVAllSeasons.Text = strFanart
        lblFanart_TVEpisode.Text = strFanart
        lblFanart_TVSeason.Text = strFanart
        lblFanart_TVShow.Text = strFanart

        'Landscape
        Dim strLandscape As String = Master.eLang.GetString(1059, "Landscape")
        lblLandscape_TVAllSeasons.Text = strLandscape
        lblLandscape_TVSeason.Text = strLandscape
        lblLandscape_TVShow.Text = strLandscape

        'Poster
        Dim strPoster As String = Master.eLang.GetString(148, "Poster")
        lblPoster_TVAllSeasons.Text = strPoster
        lblPoster_TVEpisode.Text = strPoster
        lblPoster_TVSeason.Text = strPoster
        lblPoster_TVShow.Text = strPoster

        LoadBannerSizes()
        LoadCharacterArtSizes()
        LoadClearArtSizes()
        LoadClearLogoSizes()
        LoadFanartSizes()
        LoadLandscapeSizes()
        LoadPosterSizes()

        clsAPITemp.ConvertToScraperGridView(dgvTVAllSeasonsBanner, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Banner)))
        clsAPITemp.ConvertToScraperGridView(dgvTVAllSeasonsFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvTVAllSeasonsLandscape, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Landscape)))
        clsAPITemp.ConvertToScraperGridView(dgvTVAllSeasonsPoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Poster)))
        clsAPITemp.ConvertToScraperGridView(dgvTVEpisodeFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVEpisode_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvTVEpisodePoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVEpisode_Image_Poster)))
        clsAPITemp.ConvertToScraperGridView(dgvTVSeasonBanner, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Banner)))
        clsAPITemp.ConvertToScraperGridView(dgvTVSeasonFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvTVSeasonLandscape, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Landscape)))
        clsAPITemp.ConvertToScraperGridView(dgvTVSeasonPoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVSeason_Image_Poster)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowBanner, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_Banner)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowCharacterArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_CharacterArt)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowClearArt, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_ClearArt)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowClearLogo, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_ClearLogo)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowExtrafanarts, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowFanart, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_Fanart)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowLandscape, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_Landscape)))
        clsAPITemp.ConvertToScraperGridView(dgvTVShowPoster, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.TVShow_Image_Poster)))
    End Sub

    Private Sub NumericOnly(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _
            txtTVAllSeasonsBannerMaxHeight.KeyPress,
            txtTVAllSeasonsBannerMaxWidth.KeyPress,
            txtTVAllSeasonsFanartMaxHeight.KeyPress,
            txtTVAllSeasonsFanartMaxWidth.KeyPress,
            txtTVAllSeasonsPosterMaxHeight.KeyPress,
            txtTVAllSeasonsPosterMaxWidth.KeyPress,
            txtTVEpisodeFanartMaxHeight.KeyPress,
            txtTVEpisodeFanartMaxWidth.KeyPress,
            txtTVEpisodePosterMaxHeight.KeyPress,
            txtTVEpisodePosterMaxWidth.KeyPress,
            txtTVSeasonBannerMaxHeight.KeyPress,
            txtTVSeasonBannerMaxWidth.KeyPress,
            txtTVSeasonFanartMaxHeight.KeyPress,
            txtTVSeasonFanartMaxWidth.KeyPress,
            txtTVSeasonPosterMaxHeight.KeyPress,
            txtTVSeasonPosterMaxWidth.KeyPress,
            txtTVShowBannerMaxHeight.KeyPress,
            txtTVShowBannerMaxWidth.KeyPress,
            txtTVShowExtrafanartsMaxHeight.KeyPress,
            txtTVShowExtrafanartsLimit.KeyPress,
            txtTVShowExtrafanartsMaxWidth.KeyPress,
            txtTVShowFanartMaxHeight.KeyPress,
            txtTVShowFanartMaxWidth.KeyPress,
            txtTVShowPosterMaxHeight.KeyPress,
            txtTVShowPosterWidth.KeyPress, txtTVShowLandscapeMaxWidth.KeyPress, txtTVSeasonLandscapeMaxWidth.KeyPress, txtTVAllSeasonsLandscapeMaxWidth.KeyPress, txtTVSeasonLandscapeMaxHeight.KeyPress, txtTVAllSeasonsLandscapeMaxHeight.KeyPress, txtTVShowLandscapeMaxHeight.KeyPress

        e.Handled = StringUtils.NumericOnly(e.KeyChar)
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