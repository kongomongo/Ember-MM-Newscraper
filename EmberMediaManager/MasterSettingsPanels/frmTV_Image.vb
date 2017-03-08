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
        With Master.eSettings
            cbTVAllSeasonsBannerPrefSize.SelectedValue = .TVAllSeasonsBannerPrefSize
            cbTVAllSeasonsFanartPrefSize.SelectedValue = .TVAllSeasonsFanartPrefSize
            cbTVAllSeasonsLandscapePrefSize.SelectedValue = .TVAllSeasonsLandscapePrefSize
            cbTVAllSeasonsPosterPrefSize.SelectedValue = .TVAllSeasonsPosterPrefSize
            cbTVEpisodeFanartPrefSize.SelectedValue = .TVEpisodeFanartPrefSize
            cbTVEpisodePosterPrefSize.SelectedValue = .TVEpisodePosterPrefSize
            cbTVSeasonBannerPrefSize.SelectedValue = .TVSeasonBannerPrefSize
            cbTVSeasonFanartPrefSize.SelectedValue = .TVSeasonFanartPrefSize
            cbTVSeasonLandscapePrefSize.SelectedValue = .TVSeasonLandscapePrefSize
            cbTVSeasonPosterPrefSize.SelectedValue = .TVSeasonPosterPrefSize
            cbTVShowBannerPrefSize.SelectedValue = .TVShowBannerPrefSize
            cbTVShowCharacterArtPrefSize.SelectedValue = .TVShowCharacterArtPrefSize
            cbTVShowClearArtPrefSize.SelectedValue = .TVShowClearArtPrefSize
            cbTVShowClearLogoPrefSize.SelectedValue = .TVShowClearLogoPrefSize
            cbTVShowExtrafanartsPrefSize.SelectedValue = .TVShowExtrafanartsPrefSize
            cbTVShowFanartPrefSize.SelectedValue = .TVShowFanartPrefSize
            cbTVShowLandscapePrefSize.SelectedValue = .TVShowLandscapePrefSize
            cbTVShowPosterPrefSize.SelectedValue = .TVShowPosterPrefSize
            chkTVAllSeasonsBannerKeepExisting.Checked = .TVAllSeasonsBannerKeepExisting
            chkTVAllSeasonsBannerPrefSizeOnly.Checked = .TVAllSeasonsBannerPrefSizeOnly
            txtTVAllSeasonsBannerHeight.Text = .TVAllSeasonsBannerHeight.ToString
            txtTVAllSeasonsBannerWidth.Text = .TVAllSeasonsBannerWidth.ToString
            chkTVAllSeasonsFanartKeepExisting.Checked = .TVAllSeasonsFanartKeepExisting
            chkTVAllSeasonsFanartPrefSizeOnly.Checked = .TVAllSeasonsFanartPrefSizeOnly
            txtTVAllSeasonsFanartHeight.Text = .TVAllSeasonsFanartHeight.ToString
            txtTVAllSeasonsFanartWidth.Text = .TVAllSeasonsFanartWidth.ToString
            chkTVAllSeasonsLandscapeKeepExisting.Checked = .TVAllSeasonsLandscapeKeepExisting
            chkTVAllSeasonsLandscapePrefSizeOnly.Checked = .TVAllSeasonsLandscapePrefSizeOnly
            chkTVAllSeasonsPosterKeepExisting.Checked = .TVAllSeasonsPosterKeepExisting
            chkTVAllSeasonsPosterPrefSizeOnly.Checked = .TVAllSeasonsPosterPrefSizeOnly
            txtTVAllSeasonsPosterHeight.Text = .TVAllSeasonsPosterHeight.ToString
            txtTVAllSeasonsPosterWidth.Text = .TVAllSeasonsPosterWidth.ToString
            chkTVEpisodeFanartKeepExisting.Checked = .TVEpisodeFanartKeepExisting
            chkTVEpisodeFanartPrefSizeOnly.Checked = .TVEpisodeFanartPrefSizeOnly
            txtTVEpisodeFanartHeight.Text = .TVEpisodeFanartHeight.ToString
            txtTVEpisodeFanartWidth.Text = .TVEpisodeFanartWidth.ToString
            chkTVEpisodePosterKeepExisting.Checked = .TVEpisodePosterKeepExisting
            chkTVEpisodePosterPrefSizeOnly.Checked = .TVEpisodePosterPrefSizeOnly
            txtTVEpisodePosterHeight.Text = .TVEpisodePosterHeight.ToString
            txtTVEpisodePosterWidth.Text = .TVEpisodePosterWidth.ToString
            chkTVImagesCacheEnabled.Checked = .TVImagesCacheEnabled
            chkTVImagesDisplayImageSelect.Checked = .TVImagesDisplayImageSelect
            chkTVImagesForceLanguage.Checked = .TVImagesForceLanguage
            If .TVImagesMediaLanguageOnly Then
                chkTVImagesMediaLanguageOnly.Checked = True
                chkTVImagesGetBlankImages.Checked = .TVImagesGetBlankImages
                chkTVImagesGetEnglishImages.Checked = .TVImagesGetEnglishImages
            End If
            chkTVSeasonBannerKeepExisting.Checked = .TVSeasonBannerKeepExisting
            chkTVSeasonBannerPrefSizeOnly.Checked = .TVSeasonBannerPrefSizeOnly
            txtTVSeasonBannerHeight.Text = .TVSeasonBannerHeight.ToString
            txtTVSeasonBannerWidth.Text = .TVSeasonBannerWidth.ToString
            chkTVSeasonFanartKeepExisting.Checked = .TVSeasonFanartKeepExisting
            chkTVSeasonFanartPrefSizeOnly.Checked = .TVSeasonFanartPrefSizeOnly
            txtTVSeasonFanartHeight.Text = .TVSeasonFanartHeight.ToString
            txtTVSeasonFanartWidth.Text = .TVSeasonFanartWidth.ToString
            chkTVSeasonLandscapeKeepExisting.Checked = .TVSeasonLandscapeKeepExisting
            chkTVSeasonLandscapePrefSizeOnly.Checked = .TVSeasonLandscapePrefSizeOnly
            chkTVSeasonPosterKeepExisting.Checked = .TVSeasonPosterKeepExisting
            chkTVSeasonPosterPrefSizeOnly.Checked = .TVSeasonPosterPrefSizeOnly
            txtTVSeasonPosterHeight.Text = .TVSeasonPosterHeight.ToString
            txtTVSeasonPosterWidth.Text = .TVSeasonPosterWidth.ToString
            chkTVShowBannerKeepExisting.Checked = .TVShowBannerKeepExisting
            chkTVShowBannerPrefSizeOnly.Checked = .TVShowBannerPrefSizeOnly
            txtTVShowBannerHeight.Text = .TVShowBannerHeight.ToString
            txtTVShowBannerWidth.Text = .TVShowBannerWidth.ToString
            chkTVShowCharacterArtKeepExisting.Checked = .TVShowCharacterArtKeepExisting
            chkTVShowCharacterArtPrefSizeOnly.Checked = .TVShowCharacterArtPrefSizeOnly
            chkTVShowClearArtKeepExisting.Checked = .TVShowClearArtKeepExisting
            chkTVShowClearArtPrefSizeOnly.Checked = .TVShowClearArtPrefSizeOnly
            chkTVShowClearLogoKeepExisting.Checked = .TVShowClearLogoKeepExisting
            chkTVShowClearLogoPrefSizeOnly.Checked = .TVShowClearLogoPrefSizeOnly
            chkTVShowExtrafanartsKeepExisting.Checked = .TVShowExtrafanartsKeepExisting
            chkTVShowExtrafanartsPrefSizeOnly.Checked = .TVShowExtrafanartsPrefSizeOnly
            'chkTVShowExtrafanartsPreselect.Checked = .TVShowExtrafanartsPreselect
            txtTVShowExtrafanartsHeight.Text = .TVShowExtrafanartsHeight.ToString
            txtTVShowExtrafanartsWidth.Text = .TVShowExtrafanartsWidth.ToString
            chkTVShowFanartKeepExisting.Checked = .TVShowFanartKeepExisting
            chkTVShowFanartPrefSizeOnly.Checked = .TVShowFanartPrefSizeOnly
            txtTVShowFanartHeight.Text = .TVShowFanartHeight.ToString
            txtTVShowFanartWidth.Text = .TVShowFanartWidth.ToString
            chkTVShowLandscapeKeepExisting.Checked = .TVShowLandscapeKeepExisting
            chkTVShowLandscapePrefSizeOnly.Checked = .TVShowLandscapePrefSizeOnly
            chkTVShowPosterKeepExisting.Checked = .TVShowPosterKeepExisting
            chkTVShowPosterPrefSizeOnly.Checked = .TVShowPosterPrefSizeOnly
            txtTVShowPosterHeight.Text = .TVShowPosterHeight.ToString
            txtTVShowPosterWidth.Text = .TVShowPosterWidth.ToString
            txtTVShowExtrafanartsLimit.Text = .TVShowExtrafanartsLimit.ToString

            Try
                cbTVImagesForcedLanguage.Items.Clear()
                cbTVImagesForcedLanguage.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Name).Distinct.ToArray)
                If cbTVImagesForcedLanguage.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(.TVImagesForcedLanguage) Then
                        Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbrevation_MainLanguage = .TVImagesForcedLanguage)
                        If tLanguage IsNot Nothing Then
                            cbTVImagesForcedLanguage.Text = tLanguage.Name
                        Else
                            tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(.TVImagesForcedLanguage))
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
        With Master.eSettings
            .TVAllSeasonsBannerHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsBannerHeight.Text), Convert.ToInt32(txtTVAllSeasonsBannerHeight.Text), 0)
            .TVAllSeasonsBannerKeepExisting = chkTVAllSeasonsBannerKeepExisting.Checked
            .TVAllSeasonsBannerPrefSize = CType(cbTVAllSeasonsBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVBannerSize)).Value
            .TVAllSeasonsBannerPrefSizeOnly = chkTVAllSeasonsBannerPrefSizeOnly.Checked
            .TVAllSeasonsBannerWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsBannerWidth.Text), Convert.ToInt32(txtTVAllSeasonsBannerWidth.Text), 0)
            .TVAllSeasonsFanartHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsFanartHeight.Text), Convert.ToInt32(txtTVAllSeasonsFanartHeight.Text), 0)
            .TVAllSeasonsFanartKeepExisting = chkTVAllSeasonsFanartKeepExisting.Checked
            .TVAllSeasonsFanartPrefSize = CType(cbTVAllSeasonsFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVFanartSize)).Value
            .TVAllSeasonsFanartPrefSizeOnly = chkTVAllSeasonsFanartPrefSizeOnly.Checked
            .TVAllSeasonsFanartWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsFanartWidth.Text), Convert.ToInt32(txtTVAllSeasonsFanartWidth.Text), 0)
            .TVAllSeasonsLandscapeKeepExisting = chkTVAllSeasonsLandscapeKeepExisting.Checked
            .TVAllSeasonsLandscapePrefSize = CType(cbTVAllSeasonsLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVLandscapeSize)).Value
            .TVAllSeasonsLandscapePrefSizeOnly = chkTVAllSeasonsLandscapePrefSizeOnly.Checked
            .TVAllSeasonsPosterHeight = If(Not String.IsNullOrEmpty(txtTVAllSeasonsPosterHeight.Text), Convert.ToInt32(txtTVAllSeasonsPosterHeight.Text), 0)
            .TVAllSeasonsPosterKeepExisting = chkTVAllSeasonsPosterKeepExisting.Checked
            .TVAllSeasonsPosterPrefSize = CType(cbTVAllSeasonsPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVPosterSize)).Value
            .TVAllSeasonsPosterPrefSizeOnly = chkTVAllSeasonsPosterPrefSizeOnly.Checked
            .TVAllSeasonsPosterWidth = If(Not String.IsNullOrEmpty(txtTVAllSeasonsPosterWidth.Text), Convert.ToInt32(txtTVAllSeasonsPosterWidth.Text), 0)

            .TVEpisodeFanartHeight = If(Not String.IsNullOrEmpty(txtTVEpisodeFanartHeight.Text), Convert.ToInt32(txtTVEpisodeFanartHeight.Text), 0)
            .TVEpisodeFanartKeepExisting = chkTVEpisodeFanartKeepExisting.Checked
            .TVEpisodeFanartPrefSize = CType(cbTVEpisodeFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVFanartSize)).Value
            .TVEpisodeFanartPrefSizeOnly = chkTVEpisodeFanartPrefSizeOnly.Checked
            .TVEpisodeFanartWidth = If(Not String.IsNullOrEmpty(txtTVEpisodeFanartWidth.Text), Convert.ToInt32(txtTVEpisodeFanartWidth.Text), 0)
            .TVEpisodePosterHeight = If(Not String.IsNullOrEmpty(txtTVEpisodePosterHeight.Text), Convert.ToInt32(txtTVEpisodePosterHeight.Text), 0)
            .TVEpisodePosterKeepExisting = chkTVEpisodePosterKeepExisting.Checked
            .TVEpisodePosterPrefSize = CType(cbTVEpisodePosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVEpisodePosterSize)).Value
            .TVEpisodePosterPrefSizeOnly = chkTVEpisodePosterPrefSizeOnly.Checked
            .TVEpisodePosterWidth = If(Not String.IsNullOrEmpty(txtTVEpisodePosterWidth.Text), Convert.ToInt32(txtTVEpisodePosterWidth.Text), 0)
            .TVImagesCacheEnabled = chkTVImagesCacheEnabled.Checked
            .TVImagesDisplayImageSelect = chkTVImagesDisplayImageSelect.Checked
            If Not String.IsNullOrEmpty(cbTVImagesForcedLanguage.Text) Then
                .TVImagesForcedLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = cbTVImagesForcedLanguage.Text).Abbrevation_MainLanguage
            End If
            .TVImagesForceLanguage = chkTVImagesForceLanguage.Checked
            .TVImagesGetBlankImages = chkTVImagesGetBlankImages.Checked
            .TVImagesGetEnglishImages = chkTVImagesGetEnglishImages.Checked
            .TVImagesMediaLanguageOnly = chkTVImagesMediaLanguageOnly.Checked
            .TVSeasonBannerHeight = If(Not String.IsNullOrEmpty(txtTVSeasonBannerHeight.Text), Convert.ToInt32(txtTVSeasonBannerHeight.Text), 0)
            .TVSeasonBannerKeepExisting = chkTVSeasonBannerKeepExisting.Checked
            .TVSeasonBannerPrefSize = CType(cbTVSeasonBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVBannerSize)).Value
            .TVSeasonBannerPrefSizeOnly = chkTVSeasonBannerPrefSizeOnly.Checked
            .TVSeasonBannerWidth = If(Not String.IsNullOrEmpty(txtTVSeasonBannerWidth.Text), Convert.ToInt32(txtTVSeasonBannerWidth.Text), 0)
            .TVSeasonFanartHeight = If(Not String.IsNullOrEmpty(txtTVSeasonFanartHeight.Text), Convert.ToInt32(txtTVSeasonFanartHeight.Text), 0)
            .TVSeasonFanartKeepExisting = chkTVSeasonFanartKeepExisting.Checked
            .TVSeasonFanartPrefSize = CType(cbTVSeasonFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVFanartSize)).Value
            .TVSeasonFanartPrefSizeOnly = chkTVSeasonFanartPrefSizeOnly.Checked
            .TVSeasonFanartWidth = If(Not String.IsNullOrEmpty(txtTVSeasonFanartWidth.Text), Convert.ToInt32(txtTVSeasonFanartWidth.Text), 0)
            .TVSeasonLandscapeKeepExisting = chkTVSeasonLandscapeKeepExisting.Checked
            .TVSeasonLandscapePrefSize = CType(cbTVSeasonLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVLandscapeSize)).Value
            .TVSeasonLandscapePrefSizeOnly = chkTVSeasonLandscapePrefSizeOnly.Checked
            .TVSeasonPosterHeight = If(Not String.IsNullOrEmpty(txtTVSeasonPosterHeight.Text), Convert.ToInt32(txtTVSeasonPosterHeight.Text), 0)
            .TVSeasonPosterKeepExisting = chkTVSeasonPosterKeepExisting.Checked
            .TVSeasonPosterPrefSize = CType(cbTVSeasonPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVSeasonPosterSize)).Value
            .TVSeasonPosterPrefSizeOnly = chkTVSeasonPosterPrefSizeOnly.Checked
            .TVSeasonPosterWidth = If(Not String.IsNullOrEmpty(txtTVSeasonPosterWidth.Text), Convert.ToInt32(txtTVSeasonPosterWidth.Text), 0)
            .TVShowBannerHeight = If(Not String.IsNullOrEmpty(txtTVShowBannerHeight.Text), Convert.ToInt32(txtTVShowBannerHeight.Text), 0)
            .TVShowBannerKeepExisting = chkTVShowBannerKeepExisting.Checked
            .TVShowBannerPrefSize = CType(cbTVShowBannerPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVBannerSize)).Value
            .TVShowBannerPrefSizeOnly = chkTVShowBannerPrefSizeOnly.Checked
            .TVShowBannerWidth = If(Not String.IsNullOrEmpty(txtTVShowBannerWidth.Text), Convert.ToInt32(txtTVShowBannerWidth.Text), 0)
            .TVShowCharacterArtKeepExisting = chkTVShowCharacterArtKeepExisting.Checked
            .TVShowCharacterArtPrefSize = CType(cbTVShowCharacterArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.CharacterArtSize)).Value
            .TVShowCharacterArtPrefSizeOnly = chkTVShowCharacterArtPrefSizeOnly.Checked
            .TVShowClearArtKeepExisting = chkTVShowClearArtKeepExisting.Checked
            .TVShowClearArtPrefSize = CType(cbTVShowClearArtPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVClearArtSize)).Value
            .TVShowClearArtPrefSizeOnly = chkTVShowClearArtPrefSizeOnly.Checked
            .TVShowClearLogoKeepExisting = chkTVShowClearLogoKeepExisting.Checked
            .TVShowClearLogoPrefSize = CType(cbTVShowClearLogoPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVClearLogoSize)).Value
            .TVShowClearLogoPrefSizeOnly = chkTVShowClearLogoPrefSizeOnly.Checked
            .TVShowExtrafanartsHeight = If(Not String.IsNullOrEmpty(txtTVShowExtrafanartsHeight.Text), Convert.ToInt32(txtTVShowExtrafanartsHeight.Text), 0)
            .TVShowExtrafanartsLimit = If(Not String.IsNullOrEmpty(txtTVShowExtrafanartsLimit.Text), Convert.ToInt32(txtTVShowExtrafanartsLimit.Text), 0)
            .TVShowExtrafanartsKeepExisting = chkTVShowExtrafanartsKeepExisting.Checked
            .TVShowExtrafanartsPrefSizeOnly = chkTVShowExtrafanartsPrefSizeOnly.Checked
            .TVShowExtrafanartsPrefSize = CType(cbTVShowExtrafanartsPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVFanartSize)).Value
            .TVShowExtrafanartsPrefSizeOnly = chkTVShowExtrafanartsPrefSizeOnly.Checked
            '.TVShowExtrafanartsPreselect = chkTVShowExtrafanartsPreselect.Checked
            .TVShowExtrafanartsWidth = If(Not String.IsNullOrEmpty(txtTVShowExtrafanartsWidth.Text), Convert.ToInt32(txtTVShowExtrafanartsWidth.Text), 0)
            .TVShowFanartHeight = If(Not String.IsNullOrEmpty(txtTVShowFanartHeight.Text), Convert.ToInt32(txtTVShowFanartHeight.Text), 0)
            .TVShowFanartKeepExisting = chkTVShowFanartKeepExisting.Checked
            .TVShowFanartPrefSize = CType(cbTVShowFanartPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVFanartSize)).Value
            .TVShowFanartPrefSizeOnly = chkTVShowFanartKeepExisting.Checked
            .TVShowFanartWidth = If(Not String.IsNullOrEmpty(txtTVShowFanartWidth.Text), Convert.ToInt32(txtTVShowFanartWidth.Text), 0)
            .TVShowLandscapeKeepExisting = chkTVShowLandscapeKeepExisting.Checked
            .TVShowLandscapePrefSize = CType(cbTVShowLandscapePrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVLandscapeSize)).Value
            .TVShowLandscapePrefSizeOnly = chkTVShowLandscapePrefSizeOnly.Checked
            .TVShowPosterHeight = If(Not String.IsNullOrEmpty(txtTVShowPosterHeight.Text), Convert.ToInt32(txtTVShowPosterHeight.Text), 0)
            .TVShowPosterKeepExisting = chkTVShowPosterKeepExisting.Checked
            .TVShowPosterPrefSize = CType(cbTVShowPosterPrefSize.SelectedItem, KeyValuePair(Of String, Enums.TVPosterSize)).Value
            .TVShowPosterPrefSizeOnly = chkTVShowPosterPrefSizeOnly.Checked
            .TVShowPosterWidth = If(Not String.IsNullOrEmpty(txtTVShowPosterWidth.Text), Convert.ToInt32(txtTVShowPosterWidth.Text), 0)
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
        Dim items As New Dictionary(Of String, Enums.TVBannerSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TVBannerSize.Any)
        items.Add("1000x185", Enums.TVBannerSize.HD185)
        items.Add("758x140", Enums.TVBannerSize.HD140)
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
        Dim items As New Dictionary(Of String, Enums.CharacterArtSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.CharacterArtSize.Any)
        items.Add("512x512", Enums.CharacterArtSize.HD512)
        cbTVShowCharacterArtPrefSize.DataSource = items.ToList
        cbTVShowCharacterArtPrefSize.DisplayMember = "Key"
        cbTVShowCharacterArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearArtSizes()
        Dim items As New Dictionary(Of String, Enums.TVClearArtSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TVClearArtSize.Any)
        items.Add("1000x562", Enums.TVClearArtSize.HD562)
        items.Add("500x281", Enums.TVClearArtSize.SD281)
        cbTVShowClearArtPrefSize.DataSource = items.ToList
        cbTVShowClearArtPrefSize.DisplayMember = "Key"
        cbTVShowClearArtPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadClearLogoSizes()
        Dim items As New Dictionary(Of String, Enums.TVClearLogoSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TVClearLogoSize.Any)
        items.Add("800x310", Enums.TVClearLogoSize.HD310)
        items.Add("400x155", Enums.TVClearLogoSize.SD155)
        cbTVShowClearLogoPrefSize.DataSource = items.ToList
        cbTVShowClearLogoPrefSize.DisplayMember = "Key"
        cbTVShowClearLogoPrefSize.ValueMember = "Value"
    End Sub

    Private Sub LoadFanartSizes()
        Dim items As New Dictionary(Of String, Enums.TVFanartSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TVFanartSize.Any)
        items.Add("3840x2160", Enums.TVFanartSize.UHD2160)
        items.Add("2560x1440", Enums.TVFanartSize.QHD1440)
        items.Add("1920x1080", Enums.TVFanartSize.HD1080)
        items.Add("1280x720", Enums.TVFanartSize.HD720)
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
        Dim items As New Dictionary(Of String, Enums.TVLandscapeSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TVLandscapeSize.Any)
        items.Add("1000x562", Enums.TVLandscapeSize.HD562)
        items.Add("500x281", Enums.TVLandscapeSize.SD281)
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
        Dim items As New Dictionary(Of String, Enums.TVPosterSize)
        items.Add(Master.eLang.GetString(745, "Any"), Enums.TVPosterSize.Any)
        items.Add("2000x3000", Enums.TVPosterSize.HD3000)
        items.Add("1000x1500", Enums.TVPosterSize.HD1500)
        items.Add("1000x1426", Enums.TVPosterSize.HD1426)
        items.Add("680x1000", Enums.TVPosterSize.HD1000)
        cbTVAllSeasonsPosterPrefSize.DataSource = items.ToList
        cbTVAllSeasonsPosterPrefSize.DisplayMember = "Key"
        cbTVAllSeasonsPosterPrefSize.ValueMember = "Value"
        cbTVShowPosterPrefSize.DataSource = items.ToList
        cbTVShowPosterPrefSize.DisplayMember = "Key"
        cbTVShowPosterPrefSize.ValueMember = "Value"

        Dim items2 As New Dictionary(Of String, Enums.TVSeasonPosterSize)
        items2.Add(Master.eLang.GetString(745, "Any"), Enums.TVSeasonPosterSize.Any)
        items2.Add("1000x1500", Enums.TVSeasonPosterSize.HD1500)
        items2.Add("1000x1426", Enums.TVSeasonPosterSize.HD1426)
        items2.Add("400x578", Enums.TVSeasonPosterSize.HD578)
        cbTVSeasonPosterPrefSize.DataSource = items2.ToList
        cbTVSeasonPosterPrefSize.DisplayMember = "Key"
        cbTVSeasonPosterPrefSize.ValueMember = "Value"

        Dim items3 As New Dictionary(Of String, Enums.TVEpisodePosterSize)
        items3.Add(Master.eLang.GetString(745, "Any"), Enums.TVEpisodePosterSize.Any)
        items3.Add("3840x2160", Enums.TVEpisodePosterSize.UHD2160)
        items3.Add("1920x1080", Enums.TVEpisodePosterSize.HD1080)
        items3.Add("1280x720", Enums.TVEpisodePosterSize.HD720)
        items3.Add("400x225", Enums.TVEpisodePosterSize.SD225)
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
            txtTVAllSeasonsBannerHeight.KeyPress,
            txtTVAllSeasonsBannerWidth.KeyPress,
            txtTVAllSeasonsFanartHeight.KeyPress,
            txtTVAllSeasonsFanartWidth.KeyPress,
            txtTVAllSeasonsPosterHeight.KeyPress,
            txtTVAllSeasonsPosterWidth.KeyPress,
            txtTVEpisodeFanartHeight.KeyPress,
            txtTVEpisodeFanartWidth.KeyPress,
            txtTVEpisodePosterHeight.KeyPress,
            txtTVEpisodePosterWidth.KeyPress,
            txtTVSeasonBannerHeight.KeyPress,
            txtTVSeasonBannerWidth.KeyPress,
            txtTVSeasonFanartHeight.KeyPress,
            txtTVSeasonFanartWidth.KeyPress,
            txtTVSeasonPosterHeight.KeyPress,
            txtTVSeasonPosterWidth.KeyPress,
            txtTVShowBannerHeight.KeyPress,
            txtTVShowBannerWidth.KeyPress,
            txtTVShowExtrafanartsHeight.KeyPress,
            txtTVShowExtrafanartsLimit.KeyPress,
            txtTVShowExtrafanartsWidth.KeyPress,
            txtTVShowFanartHeight.KeyPress,
            txtTVShowFanartWidth.KeyPress,
            txtTVShowPosterHeight.KeyPress,
            txtTVShowPosterWidth.KeyPress

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