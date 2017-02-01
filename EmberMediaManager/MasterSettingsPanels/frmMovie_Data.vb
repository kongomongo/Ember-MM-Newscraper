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

Public Class frmMovie_Data
    Implements Interfaces.MasterSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Dim _ePanelType As Enums.SettingsPanelType = Enums.SettingsPanelType.Movie
    Dim _intImageIndex As Integer = 4
    Dim _intOrder As Integer = 400
    Dim _strName As String = "Movie_Data"
    Dim _strTitle As String = Master.eLang.GetString(556, "Data")

    Private MovieMeta As New List(Of Settings.MetadataPerType)

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
            chkMovieLockActors.Checked = .MovieLockActors
            chkMovieLockCert.Checked = .MovieLockCert
            chkMovieLockCountry.Checked = .MovieLockCountry
            chkMovieLockCollectionID.Checked = .MovieLockCollectionID
            chkMovieLockCollections.Checked = .MovieLockCollections
            chkMovieLockDirector.Checked = .MovieLockDirector
            chkMovieLockGenre.Checked = .MovieLockGenre
            chkMovieLockLanguageA.Checked = .MovieLockLanguageA
            chkMovieLockLanguageV.Checked = .MovieLockLanguageV
            chkMovieLockMPAA.Checked = .MovieLockMPAA
            chkMovieLockOriginalTitle.Checked = .MovieLockOriginalTitle
            chkMovieLockOutline.Checked = .MovieLockOutline
            chkMovieLockPlot.Checked = .MovieLockPlot
            chkMovieLockRating.Checked = .MovieLockRating
            chkMovieLockReleaseDate.Checked = .MovieLockReleaseDate
            chkMovieLockRuntime.Checked = .MovieLockRuntime
            chkMovieLockStudio.Checked = .MovieLockStudio
            chkMovieLockTagline.Checked = .MovieLockTagline
            chkMovieLockTags.Checked = .MovieLockTags
            chkMovieLockTitle.Checked = .MovieLockTitle
            chkMovieLockTop250.Checked = .MovieLockTop250
            chkMovieLockTrailer.Checked = .MovieLockTrailer
            chkMovieLockUserRating.Checked = .MovieLockUserRating
            chkMovieLockCredits.Checked = .MovieLockCredits
            chkMovieLockYear.Checked = .MovieLockYear
            chkMovieScraperCast.Checked = .MovieScraperCast
            chkMovieScraperCastWithImg.Checked = .MovieScraperCastWithImgOnly
            chkMovieScraperCert.Checked = .MovieScraperCert
            chkMovieScraperCertForMPAA.Checked = .MovieScraperCertForMPAA
            chkMovieScraperCertForMPAAFallback.Checked = .MovieScraperCertForMPAAFallback
            chkMovieScraperCertFSK.Checked = .MovieScraperCertFSK
            chkMovieScraperCertOnlyValue.Checked = .MovieScraperCertOnlyValue
            chkMovieScraperCleanFields.Checked = .MovieScraperCleanFields
            chkMovieScraperCleanPlotOutline.Checked = .MovieScraperCleanPlotOutline
            chkMovieScraperCollectionID.Checked = .MovieScraperCollectionID
            chkMovieScraperCollectionsAuto.Checked = .MovieScraperCollectionsAuto
            chkMovieScraperCollectionsExtendedInfo.Checked = .MovieScraperCollectionsExtendedInfo
            chkMovieScraperCollectionsYAMJCompatibleSets.Checked = .MovieScraperCollectionsYAMJCompatibleSets
            chkMovieScraperCountry.Checked = .MovieScraperCountry
            chkMovieScraperDirector.Checked = .MovieScraperDirector
            chkMovieScraperGenre.Checked = .MovieScraperGenre
            chkMovieScraperMetaDataIFOScan.Checked = .MovieScraperMetaDataIFOScan
            chkMovieScraperMetaDataScan.Checked = .MovieScraperMetaDataScan
            chkMovieScraperMPAA.Checked = .MovieScraperMPAA
            chkMovieScraperOriginalTitle.Checked = .MovieScraperOriginalTitle
            chkMovieScraperDetailView.Checked = .MovieScraperUseDetailView
            chkMovieScraperOutline.Checked = .MovieScraperOutline
            chkMovieScraperPlot.Checked = .MovieScraperPlot
            chkMovieScraperPlotForOutline.Checked = .MovieScraperPlotForOutline
            chkMovieScraperPlotForOutlineIfEmpty.Checked = .MovieScraperPlotForOutlineIfEmpty
            chkMovieScraperRating.Checked = .MovieScraperRating
            chkMovieScraperRelease.Checked = .MovieScraperRelease
            chkMovieScraperRuntime.Checked = .MovieScraperRuntime
            chkMovieScraperStudio.Checked = .MovieScraperStudio
            chkMovieScraperStudioWithImg.Checked = .MovieScraperStudioWithImgOnly
            chkMovieScraperTagline.Checked = .MovieScraperTagline
            chkMovieScraperTitle.Checked = .MovieScraperTitle
            chkMovieScraperTop250.Checked = .MovieScraperTop250
            chkMovieScraperTrailer.Checked = .MovieScraperTrailer
            chkMovieScraperUseMDDuration.Checked = .MovieScraperUseMDDuration
            chkMovieScraperUserRating.Checked = .MovieScraperUserRating
            chkMovieScraperCredits.Checked = .MovieScraperCredits
            chkMovieScraperXBMCTrailerFormat.Checked = .MovieScraperXBMCTrailerFormat
            chkMovieScraperYear.Checked = .MovieScraperYear
            txtMovieScraperCastLimit.Text = .MovieScraperCastLimit.ToString
            txtMovieScraperDurationRuntimeFormat.Text = .MovieScraperDurationRuntimeFormat
            txtMovieScraperGenreLimit.Text = .MovieScraperGenreLimit.ToString
            txtMovieScraperMPAANotRated.Text = .MovieScraperMPAANotRated
            txtMovieScraperOutlineLimit.Text = .MovieScraperOutlineLimit.ToString
            txtMovieScraperStudioLimit.Text = .MovieScraperStudioLimit.ToString
            txtMovieScraperDurationRuntimeFormat.Enabled = .MovieScraperUseMDDuration

            Try
                cbMovieScraperCertLang.Items.Clear()
                cbMovieScraperCertLang.Items.Add(Master.eLang.All)
                cbMovieScraperCertLang.Items.AddRange((From lLang In APIXML.CertLanguagesXML.Language Select lLang.name).ToArray)
                If cbMovieScraperCertLang.Items.Count > 0 Then
                    If .MovieScraperCertLang = Master.eLang.All Then
                        cbMovieScraperCertLang.SelectedIndex = 0
                    ElseIf Not String.IsNullOrEmpty(.MovieScraperCertLang) Then
                        Dim tLanguage As CertLanguages = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = .MovieScraperCertLang)
                        If tLanguage IsNot Nothing AndAlso tLanguage.name IsNot Nothing AndAlso Not String.IsNullOrEmpty(tLanguage.name) Then
                            cbMovieScraperCertLang.Text = tLanguage.name
                        Else
                            cbMovieScraperCertLang.SelectedIndex = 0
                        End If
                    Else
                        cbMovieScraperCertLang.SelectedIndex = 0
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            MovieMeta.AddRange(.MovieMetadataPerFileType)
            LoadMovieMetadata()

            clsAPITemp.ConvertToScraperGridView(dgvActors)
            clsAPITemp.ConvertToScraperGridView(dgvCertifications)
            clsAPITemp.ConvertToScraperGridView(dgvCollectionID)
            clsAPITemp.ConvertToScraperGridView(dgvCollections)
            clsAPITemp.ConvertToScraperGridView(dgvCoutries)
            clsAPITemp.ConvertToScraperGridView(dgvCredits)
            clsAPITemp.ConvertToScraperGridView(dgvDirectors)
            clsAPITemp.ConvertToScraperGridView(dgvGenres)
            clsAPITemp.ConvertToScraperGridView(dgvMPAA)
            clsAPITemp.ConvertToScraperGridView(dgvOriginalTitle)
            clsAPITemp.ConvertToScraperGridView(dgvOutline)
            clsAPITemp.ConvertToScraperGridView(dgvPlot)
            clsAPITemp.ConvertToScraperGridView(dgvRating)
            clsAPITemp.ConvertToScraperGridView(dgvReleaseDate)
            clsAPITemp.ConvertToScraperGridView(dgvRuntime)
            clsAPITemp.ConvertToScraperGridView(dgvStudios)
            clsAPITemp.ConvertToScraperGridView(dgvTagline)
            clsAPITemp.ConvertToScraperGridView(dgvTags)
            clsAPITemp.ConvertToScraperGridView(dgvTitle)
            clsAPITemp.ConvertToScraperGridView(dgvTop250)
            clsAPITemp.ConvertToScraperGridView(dgvTrailer)
            clsAPITemp.ConvertToScraperGridView(dgvUserRating)
            clsAPITemp.ConvertToScraperGridView(dgvYear)
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings
            .MovieLockActors = chkMovieLockActors.Checked
            .MovieLockCert = chkMovieLockCert.Checked
            .MovieLockCollectionID = chkMovieLockCollectionID.Checked
            .MovieLockCollections = chkMovieLockCollections.Checked
            .MovieLockCountry = chkMovieLockCountry.Checked
            .MovieLockDirector = chkMovieLockDirector.Checked
            .MovieLockGenre = chkMovieLockGenre.Checked
            .MovieLockLanguageA = chkMovieLockLanguageA.Checked
            .MovieLockLanguageV = chkMovieLockLanguageV.Checked
            .MovieLockMPAA = chkMovieLockMPAA.Checked
            .MovieLockOutline = chkMovieLockOutline.Checked
            .MovieLockPlot = chkMovieLockPlot.Checked
            .MovieLockRating = chkMovieLockRating.Checked
            .MovieLockReleaseDate = chkMovieLockReleaseDate.Checked
            .MovieLockRuntime = chkMovieLockRuntime.Checked
            .MovieLockStudio = chkMovieLockStudio.Checked
            .MovieLockTags = chkMovieLockTags.Checked
            .MovieLockTagline = chkMovieLockTagline.Checked
            .MovieLockOriginalTitle = chkMovieLockOriginalTitle.Checked
            .MovieLockTitle = chkMovieLockTitle.Checked
            .MovieLockTop250 = chkMovieLockTop250.Checked
            .MovieLockTrailer = chkMovieLockTrailer.Checked
            .MovieLockUserRating = chkMovieLockUserRating.Checked
            .MovieLockCredits = chkMovieLockCredits.Checked
            .MovieLockYear = chkMovieLockYear.Checked
            .MovieMetadataPerFileType.Clear()
            .MovieMetadataPerFileType.AddRange(MovieMeta)
            .MovieScraperCast = chkMovieScraperCast.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperCastLimit.Text) Then
                .MovieScraperCastLimit = Convert.ToInt32(txtMovieScraperCastLimit.Text)
            Else
                .MovieScraperCastLimit = 0
            End If
            .MovieScraperCastWithImgOnly = chkMovieScraperCastWithImg.Checked
            .MovieScraperCert = chkMovieScraperCert.Checked
            .MovieScraperCertForMPAA = chkMovieScraperCertForMPAA.Checked
            .MovieScraperCertForMPAAFallback = chkMovieScraperCertForMPAAFallback.Checked
            .MovieScraperCertFSK = chkMovieScraperCertFSK.Checked
            .MovieScraperCertOnlyValue = chkMovieScraperCertOnlyValue.Checked
            If Not String.IsNullOrEmpty(cbMovieScraperCertLang.Text) Then
                If cbMovieScraperCertLang.SelectedIndex = 0 Then
                    .MovieScraperCertLang = Master.eLang.All
                Else
                    .MovieScraperCertLang = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.name = cbMovieScraperCertLang.Text).abbreviation
                End If
            End If
            .MovieScraperCleanFields = chkMovieScraperCleanFields.Checked
            .MovieScraperCleanPlotOutline = chkMovieScraperCleanPlotOutline.Checked
            .MovieScraperCollectionID = chkMovieScraperCollectionID.Checked
            .MovieScraperCollectionsAuto = chkMovieScraperCollectionsAuto.Checked
            .MovieScraperCollectionsExtendedInfo = chkMovieScraperCollectionsExtendedInfo.Checked
            .MovieScraperCollectionsYAMJCompatibleSets = chkMovieScraperCollectionsYAMJCompatibleSets.Checked
            .MovieScraperCountry = chkMovieScraperCountry.Checked
            .MovieScraperDirector = chkMovieScraperDirector.Checked
            .MovieScraperDurationRuntimeFormat = txtMovieScraperDurationRuntimeFormat.Text
            .MovieScraperGenre = chkMovieScraperGenre.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperGenreLimit.Text) Then
                .MovieScraperGenreLimit = Convert.ToInt32(txtMovieScraperGenreLimit.Text)
            Else
                .MovieScraperGenreLimit = 0
            End If
            .MovieScraperMetaDataIFOScan = chkMovieScraperMetaDataIFOScan.Checked
            .MovieScraperMetaDataScan = chkMovieScraperMetaDataScan.Checked
            .MovieScraperMPAA = chkMovieScraperMPAA.Checked
            .MovieScraperMPAANotRated = txtMovieScraperMPAANotRated.Text
            .MovieScraperOriginalTitle = chkMovieScraperOriginalTitle.Checked
            .MovieScraperOutline = chkMovieScraperOutline.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperOutlineLimit.Text) Then
                .MovieScraperOutlineLimit = Convert.ToInt32(txtMovieScraperOutlineLimit.Text)
            Else
                .MovieScraperOutlineLimit = 0
            End If
            .MovieScraperPlot = chkMovieScraperPlot.Checked
            .MovieScraperPlotForOutline = chkMovieScraperPlotForOutline.Checked
            .MovieScraperPlotForOutlineIfEmpty = chkMovieScraperPlotForOutlineIfEmpty.Checked
            .MovieScraperRating = chkMovieScraperRating.Checked
            .MovieScraperRelease = chkMovieScraperRelease.Checked
            .MovieScraperRuntime = chkMovieScraperRuntime.Checked
            .MovieScraperStudio = chkMovieScraperStudio.Checked
            .MovieScraperStudioWithImgOnly = chkMovieScraperStudioWithImg.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperStudioLimit.Text) Then
                .MovieScraperStudioLimit = Convert.ToInt32(txtMovieScraperStudioLimit.Text)
            Else
                .MovieScraperStudioLimit = 0
            End If
            .MovieScraperTagline = chkMovieScraperTagline.Checked
            .MovieScraperTitle = chkMovieScraperTitle.Checked
            .MovieScraperTop250 = chkMovieScraperTop250.Checked
            .MovieScraperTrailer = chkMovieScraperTrailer.Checked
            .MovieScraperUseDetailView = chkMovieScraperDetailView.Checked
            .MovieScraperUseMDDuration = chkMovieScraperUseMDDuration.Checked
            .MovieScraperUserRating = chkMovieScraperUserRating.Checked
            .MovieScraperCredits = chkMovieScraperCredits.Checked
            .MovieScraperXBMCTrailerFormat = chkMovieScraperXBMCTrailerFormat.Checked
            .MovieScraperYear = chkMovieScraperYear.Checked

        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub btnMovieScraperDefFIExtEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieScraperDefFIExtEdit.Click
        Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.Movie), False)
            Dim fi As New MediaContainers.Fileinfo
            For Each x As Settings.MetadataPerType In MovieMeta
                If x.FileType = lstMovieScraperDefFIExt.SelectedItems(0).ToString Then
                    fi = dEditMeta.ShowDialog(x.MetaData, False)
                    If Not fi Is Nothing Then
                        MovieMeta.Remove(x)
                        Dim m As New Settings.MetadataPerType
                        m.FileType = x.FileType
                        m.MetaData = New MediaContainers.Fileinfo
                        m.MetaData = fi
                        MovieMeta.Add(m)
                        LoadMovieMetadata()
                        EnableApplyButton()
                    End If
                    Exit For
                End If
            Next
        End Using
    End Sub

    Private Sub btnMovieScraperDefFIExtAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieScraperDefFIExtAdd.Click
        If Not txtMovieScraperDefFIExt.Text.StartsWith(".") Then txtMovieScraperDefFIExt.Text = String.Concat(".", txtMovieScraperDefFIExt.Text)
        Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.Movie), False)
            Dim fi As New MediaContainers.Fileinfo
            fi = dEditMeta.ShowDialog(fi, False)
            If Not fi Is Nothing Then
                Dim m As New Settings.MetadataPerType
                m.FileType = txtMovieScraperDefFIExt.Text
                m.MetaData = New MediaContainers.Fileinfo
                m.MetaData = fi
                MovieMeta.Add(m)
                LoadMovieMetadata()
                EnableApplyButton()
                txtMovieScraperDefFIExt.Text = String.Empty
                txtMovieScraperDefFIExt.Focus()
            End If
        End Using
    End Sub

    Private Sub btnMovieScraperDefFIExtRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieScraperDefFIExtRemove.Click
        RemoveMovieMetaData()
    End Sub

    Private Sub chkMovieScraperStudio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperStudio.CheckedChanged
        EnableApplyButton()
        chkMovieScraperStudioWithImg.Enabled = chkMovieScraperStudio.Checked
        txtMovieScraperStudioLimit.Enabled = chkMovieScraperStudio.Checked
        If Not chkMovieScraperStudio.Checked Then
            chkMovieScraperStudioWithImg.Checked = False
            txtMovieScraperStudioLimit.Text = "0"
        End If
    End Sub
    Private Sub chkMovieScraperCast_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperCast.CheckedChanged
        EnableApplyButton()

        chkMovieScraperCastWithImg.Enabled = chkMovieScraperCast.Checked
        txtMovieScraperCastLimit.Enabled = chkMovieScraperCast.Checked

        If Not chkMovieScraperCast.Checked Then
            chkMovieScraperCastWithImg.Checked = False
            txtMovieScraperCastLimit.Text = "0"
        End If
    End Sub

    Private Sub chkMovieScraperCert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperCert.CheckedChanged
        EnableApplyButton()

        If Not chkMovieScraperCert.Checked Then
            cbMovieScraperCertLang.Enabled = False
            cbMovieScraperCertLang.SelectedIndex = 0
            chkMovieScraperCertForMPAA.Enabled = False
            chkMovieScraperCertForMPAA.Checked = False
            chkMovieScraperCertFSK.Enabled = False
            chkMovieScraperCertFSK.Checked = False
            chkMovieScraperCertOnlyValue.Enabled = False
            chkMovieScraperCertOnlyValue.Checked = False
        Else
            cbMovieScraperCertLang.Enabled = True
            cbMovieScraperCertLang.SelectedIndex = 0
            chkMovieScraperCertForMPAA.Enabled = True
            chkMovieScraperCertFSK.Enabled = True
            chkMovieScraperCertOnlyValue.Enabled = True
        End If
    End Sub

    Private Sub chkMovieScraperCertForMPAA_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperCertForMPAA.CheckedChanged
        EnableApplyButton()

        If Not chkMovieScraperCertForMPAA.Checked Then
            chkMovieScraperCertForMPAAFallback.Enabled = False
            chkMovieScraperCertForMPAAFallback.Checked = False
        Else
            chkMovieScraperCertForMPAAFallback.Enabled = True
        End If
    End Sub


    Private Sub chkMovieScraperGenre_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperGenre.CheckedChanged
        EnableApplyButton()

        txtMovieScraperGenreLimit.Enabled = chkMovieScraperGenre.Checked

        If Not chkMovieScraperGenre.Checked Then txtMovieScraperGenreLimit.Text = "0"
    End Sub

    Private Sub chkMovieScraperPlotForOutline_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperPlotForOutline.CheckedChanged
        EnableApplyButton()

        txtMovieScraperOutlineLimit.Enabled = chkMovieScraperPlotForOutline.Checked
        chkMovieScraperPlotForOutlineIfEmpty.Enabled = chkMovieScraperPlotForOutline.Checked
        If Not chkMovieScraperPlotForOutline.Checked Then
            txtMovieScraperOutlineLimit.Enabled = False
            chkMovieScraperPlotForOutlineIfEmpty.Checked = False
            chkMovieScraperPlotForOutlineIfEmpty.Enabled = False
        End If
    End Sub

    Private Sub chkMovieScraperPlot_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperPlot.CheckedChanged
        EnableApplyButton()

        chkMovieScraperPlotForOutline.Enabled = chkMovieScraperPlot.Checked
        If Not chkMovieScraperPlot.Checked Then
            chkMovieScraperPlotForOutline.Checked = False
            txtMovieScraperOutlineLimit.Enabled = False
        End If
    End Sub

    Private Sub chkMovieScraperCollectionID_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperCollectionID.CheckedChanged
        EnableApplyButton()

        chkMovieScraperCollectionsAuto.Enabled = chkMovieScraperCollectionID.Checked
        If Not chkMovieScraperCollectionID.Checked Then
            chkMovieScraperCollectionsAuto.Checked = False
        End If
    End Sub

    Private Sub chkMovieScraperUseMDDuration_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMovieScraperUseMDDuration.CheckedChanged
        txtMovieScraperDurationRuntimeFormat.Enabled = chkMovieScraperUseMDDuration.Checked
        EnableApplyButton()
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub LoadMovieMetadata()
        lstMovieScraperDefFIExt.Items.Clear()
        For Each x As Settings.MetadataPerType In MovieMeta
            lstMovieScraperDefFIExt.Items.Add(x.FileType)
        Next
    End Sub

    Private Sub lstMovieScraperDefFIExt_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lstMovieScraperDefFIExt.DoubleClick
        If lstMovieScraperDefFIExt.SelectedItems.Count > 0 Then
            Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.Movie), False)
                Dim fi As New MediaContainers.Fileinfo
                For Each x As Settings.MetadataPerType In MovieMeta
                    If x.FileType = lstMovieScraperDefFIExt.SelectedItems(0).ToString Then
                        fi = dEditMeta.ShowDialog(x.MetaData, False)
                        If Not fi Is Nothing Then
                            MovieMeta.Remove(x)
                            Dim m As New Settings.MetadataPerType
                            m.FileType = x.FileType
                            m.MetaData = New MediaContainers.Fileinfo
                            m.MetaData = fi
                            MovieMeta.Add(m)
                            LoadMovieMetadata()
                            EnableApplyButton()
                        End If
                        Exit For
                    End If
                Next
            End Using
        End If
    End Sub

    Private Sub lstMovieScraperDefFIExt_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lstMovieScraperDefFIExt.KeyDown
        If e.KeyCode = Keys.Delete Then RemoveMovieMetaData()
    End Sub

    Private Sub lstMovieScraperDefFIExt_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstMovieScraperDefFIExt.SelectedIndexChanged
        If lstMovieScraperDefFIExt.SelectedItems.Count > 0 Then
            btnMovieScraperDefFIExtEdit.Enabled = True
            btnMovieScraperDefFIExtRemove.Enabled = True
            txtMovieScraperDefFIExt.Text = String.Empty
        Else
            btnMovieScraperDefFIExtEdit.Enabled = False
            btnMovieScraperDefFIExtRemove.Enabled = False
        End If
    End Sub

    Private Sub RemoveMovieMetaData()
        If lstMovieScraperDefFIExt.SelectedItems.Count > 0 Then
            For Each x As Settings.MetadataPerType In MovieMeta
                If x.FileType = lstMovieScraperDefFIExt.SelectedItems(0).ToString Then
                    MovieMeta.Remove(x)
                    LoadMovieMetadata()
                    EnableApplyButton()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub SetUp()
        lblMovieScraperGlobalActors.Text = Master.eLang.GetString(231, "Actors")
        chkMovieScraperCleanFields.Text = Master.eLang.GetString(125, "Cleanup disabled fields")
        lblMovieScraperGlobalCollectionID.Text = Master.eLang.GetString(1135, "Collection ID")
        lblMovieScraperGlobalCollections.Text = Master.eLang.GetString(424, "Collections")
        lblMovieScraperGlobalCountries.Text = Master.eLang.GetString(237, "Countries")
        gbMovieScraperDefFIExtOpts.Text = Master.eLang.GetString(625, "Defaults by File Type")
        lblMovieScraperGlobalDirectors.Text = Master.eLang.GetString(940, "Directors")
        gbMovieScraperDurationFormatOpts.Text = Master.eLang.GetString(515, "Duration Format")
        lblMovieScraperDurationRuntimeFormat.Text = String.Format(Master.eLang.GetString(732, "<h>=Hours{0}<m>=Minutes{0}<s>=Seconds"), Environment.NewLine)
        lblMovieScraperDefFIExt.Text = String.Concat(Master.eLang.GetString(626, "File Type"), ":")
        lblMovieScraperGlobalGenres.Text = Master.eLang.GetString(725, "Genres")
        lblMovieScraperGlobalLanguageA.Text = Master.eLang.GetString(431, "Language (Audio)")
        lblMovieScraperGlobalLanguageV.Text = Master.eLang.GetString(435, "Language (Video)")
        lblMovieScraperGlobalHeaderLock.Text = Master.eLang.GetString(24, "Lock")
        gbMovieScraperMetaDataOpts.Text = Master.eLang.GetString(59, "Meta Data")
        gbMovieScraperMiscOpts.Text = Master.eLang.GetString(429, "Miscellaneous")
        lblMovieScraperGlobalMPAA.Text = Master.eLang.GetString(401, "MPAA")
        chkMovieScraperCertForMPAAFallback.Text = Master.eLang.GetString(1293, "Only if no MPAA is found")
        chkMovieScraperCertOnlyValue.Text = Master.eLang.GetString(835, "Only Save the Value to NFO")
        lblMovieScraperGlobalOriginalTitle.Text = Master.eLang.GetString(302, "Original Title")
        lblMovieScraperGlobalPlot.Text = Master.eLang.GetString(65, "Plot")
        lblMovieScraperGlobalOutline.Text = Master.eLang.GetString(64, "Plot Outline")
        lblMovieScraperGlobalReleaseDate.Text = Master.eLang.GetString(57, "Release Date")
        lblMovieScraperGlobalRating.Text = Master.eLang.GetString(400, "Rating")
        lblMovieScraperGlobalRuntime.Text = Master.eLang.GetString(396, "Runtime")
        chkMovieScraperCollectionsExtendedInfo.Text = Master.eLang.GetString(1075, "Save extended Collection information to NFO (Kodi 16.0 ""Jarvis"" and newer)")
        chkMovieScraperCastWithImg.Text = Master.eLang.GetString(510, "Scrape Only Actors With Images")
        gbMovieScraperGlobalOpts.Text = Master.eLang.GetString(577, "Scraper Fields - Global")
        lblMovieScraperGlobalStudios.Text = Master.eLang.GetString(226, "Studios")
        lblMovieScraperGlobalTagline.Text = Master.eLang.GetString(397, "Tagline")
        lblMovieScraperGlobalTitle.Text = Master.eLang.GetString(21, "Title")
        lblMovieScraperGlobalTop250.Text = Master.eLang.GetString(591, "Top 250")
        lblMovieScraperGlobalTrailer.Text = Master.eLang.GetString(151, "Trailer")
        chkMovieScraperCertForMPAA.Text = Master.eLang.GetString(511, "Use Certification for MPAA")
        chkMovieScraperCertFSK.Text = Master.eLang.GetString(882, "Use MPAA as Fallback for FSK Rating")
        lblMovieScraperGlobalUserRating.Text = Master.eLang.GetString(1464, "User Rating")
        lblMovieScraperGlobalCredits.Text = Master.eLang.GetString(394, "Writers")
        lblMovieScraperGlobalYear.Text = Master.eLang.GetString(278, "Year")
        chkMovieScraperCleanPlotOutline.Text = Master.eLang.GetString(985, "Clean Plot/Outline")
        chkMovieScraperCollectionsAuto.Text = Master.eLang.GetString(1266, "Add Movie automatically to Collections")
        chkMovieScraperDetailView.Text = Master.eLang.GetString(1249, "Show scraped results in detailed view")
        chkMovieScraperMetaDataIFOScan.Text = Master.eLang.GetString(628, "Enable IFO Parsing")
        chkMovieScraperMetaDataScan.Text = Master.eLang.GetString(517, "Scan Meta Data")
        chkMovieScraperPlotForOutline.Text = Master.eLang.GetString(965, "Use Plot for Plot Outline")
        chkMovieScraperPlotForOutlineIfEmpty.Text = Master.eLang.GetString(958, "Only if Plot Outline is empty")
        chkMovieScraperStudioWithImg.Text = Master.eLang.GetString(1280, "Scrape Only Studios With Images")
        chkMovieScraperUseMDDuration.Text = Master.eLang.GetString(516, "Use Duration for Runtime")
        chkMovieScraperXBMCTrailerFormat.Text = Master.eLang.GetString(1187, "Save YouTube-Trailer-Links in XBMC compatible format")
        chkMovieScraperCollectionsYAMJCompatibleSets.Text = Master.eLang.GetString(561, "Save YAMJ Compatible Sets to NFO")
        gbMovieScraperDefFIExtOpts.Text = Master.eLang.GetString(625, "Defaults by File Type")
        lblMovieScraperDurationRuntimeFormat.Text = String.Format(Master.eLang.GetString(732, "<h>=Hours{0}<m>=Minutes{0}<s>=Seconds"), Environment.NewLine)
        lblMovieScraperMPAANotRated.Text = String.Concat(Master.eLang.GetString(832, "MPAA value if no rating is available"), ":")


        'Certifications
        Dim strCertifications As String = Master.eLang.GetString(56, "Certifications")
        gbMovieScraperCertificationOpts.Text = strCertifications
        lblMovieScraperGlobalCertifications.Text = strCertifications

        'Limit
        Dim strLimit As String = Master.eLang.GetString(578, "Limit")
        lblMovieScraperGlobalHeaderLimit.Text = strLimit
        lblMovieScraperOutlineLimit.Text = String.Concat(strLimit, ":")
    End Sub

    Private Sub txtMovieScraperCastLimit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMovieScraperCastLimit.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub txtMovieScraperDefFIExt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMovieScraperDefFIExt.TextChanged
        btnMovieScraperDefFIExtAdd.Enabled = Not String.IsNullOrEmpty(txtMovieScraperDefFIExt.Text) AndAlso Not lstMovieScraperDefFIExt.Items.Contains(If(txtMovieScraperDefFIExt.Text.StartsWith("."), txtMovieScraperDefFIExt.Text, String.Concat(".", txtMovieScraperDefFIExt.Text)))
        If btnMovieScraperDefFIExtAdd.Enabled Then
            btnMovieScraperDefFIExtEdit.Enabled = False
            btnMovieScraperDefFIExtRemove.Enabled = False
        End If
    End Sub

    Private Sub txtMovieScraperGenreLimit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMovieScraperGenreLimit.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub txtMovieScraperOutlineLimit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMovieScraperOutlineLimit.KeyPress
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

#End Region 'Methods

End Class