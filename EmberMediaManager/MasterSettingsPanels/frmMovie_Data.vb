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

    Private _lstMovieMeta As New List(Of Settings.MetadataPerType)
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
        With Master.eSettings.Movie.DataSettings
            chkMovieLockActors.Checked = .Actors.Locked
            chkMovieLockCert.Checked = .Certifications.Locked
            chkMovieLockCountry.Checked = .Countries.Locked
            chkMovieLockCollectionID.Checked = .CollectionID.Locked
            chkMovieLockCollections.Checked = .Collection.Locked
            chkMovieLockDirector.Checked = .Directors.Locked
            chkMovieLockGenre.Checked = .Genres.Locked
            chkMovieLockLanguageA.Checked = .LockAudioLanguage
            chkMovieLockLanguageV.Checked = .LockVideoLanguage
            chkMovieLockMPAA.Checked = .MPAA.Locked
            chkMovieLockOriginalTitle.Checked = .OriginalTitle.Locked
            chkMovieLockOutline.Checked = .Outline.Locked
            chkMovieLockPlot.Checked = .Plot.Locked
            chkMovieLockRating.Checked = .Rating.Locked
            chkMovieLockReleaseDate.Checked = .ReleaseDate.Locked
            chkMovieLockRuntime.Checked = .Runtime.Locked
            chkMovieLockStudio.Checked = .Studios.Locked
            chkMovieLockTagline.Checked = .Tagline.Locked
            chkMovieLockTags.Checked = .Tags.Locked
            chkMovieLockTitle.Checked = .Title.Locked
            chkMovieLockTop250.Checked = .Top250.Locked
            chkMovieLockTrailer.Checked = .Trailer.Locked
            chkMovieLockUserRating.Checked = .UserRating.Locked
            chkMovieLockCredits.Checked = .Credits.Locked
            chkMovieLockYear.Checked = .Year.Locked
            chkMovieScraperCast.Checked = .Actors.Enabled
            chkMovieScraperCastWithImg.Checked = .ActorsWithImageOnly
            chkMovieScraperCert.Checked = .Certifications.Enabled
            chkMovieScraperCertForMPAA.Checked = .CertificationsForMPAA
            chkMovieScraperCertForMPAAFallback.Checked = .CertificationsForMPAAFallback
            chkMovieScraperCertOnlyValue.Checked = .CertificationsOnlyValue
            chkMovieScraperCleanFields.Checked = .ClearDisabledFields
            chkMovieScraperCleanPlotOutline.Checked = .CleanPlotAndOutline
            chkMovieScraperCollectionID.Checked = .CollectionID.Enabled
            chkMovieScraperCollectionsAuto.Checked = .CollectionAutoAdd
            chkMovieScraperCollectionsExtendedInfo.Checked = .CollectionKodiExtendedInfo
            chkMovieScraperCollectionsYAMJCompatibleSets.Checked = .CollectionYAMJCompatible
            chkMovieScraperCountry.Checked = .Countries.Enabled
            chkMovieScraperDirector.Checked = .Directors.Enabled
            chkMovieScraperGenre.Checked = .Genres.Enabled
            chkMovieScraperMetaDataScan.Checked = .MetaDataScan
            chkMovieScraperMPAA.Checked = .MPAA.Enabled
            chkMovieScraperOriginalTitle.Checked = .OriginalTitle.Enabled
            chkMovieScraperDetailView.Checked = Master.eSettings.MovieScraperUseDetailView
            chkMovieScraperOutline.Checked = .Outline.Enabled
            chkMovieScraperPlot.Checked = .Plot.Enabled
            chkMovieScraperPlotForOutline.Checked = .PlotForOutline
            chkMovieScraperPlotForOutlineIfEmpty.Checked = .PlotForOutlineAsFallback
            chkMovieScraperRating.Checked = .Rating.Enabled
            chkMovieScraperRelease.Checked = .ReleaseDate.Enabled
            chkMovieScraperRuntime.Checked = .Runtime.Enabled
            chkMovieScraperStudio.Checked = .Studios.Enabled
            chkMovieScraperStudioWithImg.Checked = .StudiosWithImageOnly
            chkMovieScraperTagline.Checked = .Tagline.Enabled
            chkMovieScraperTitle.Checked = .Title.Enabled
            chkMovieScraperTop250.Checked = .Top250.Enabled
            chkMovieScraperTrailer.Checked = .Trailer.Enabled
            chkDurationForRuntime.Checked = .DurationForRuntime
            chkMovieScraperUserRating.Checked = .UserRating.Enabled
            chkMovieScraperCredits.Checked = .Credits.Enabled
            chkMovieScraperTrailerKodiFormat.Checked = .TrailerKodiFormat
            chkMovieScraperYear.Checked = .Year.Enabled
            txtMovieScraperCastLimit.Text = .Actors.Limit.ToString
            txtDurationFormat.Text = .DurationFormat
            txtMovieScraperGenreLimit.Text = .Genres.Limit.ToString
            txtMovieScraperMPAANotRated.Text = .MPAANotRatedValue
            txtMovieScraperOutlineLimit.Text = .Outline.Limit.ToString
            txtMovieScraperStudioLimit.Text = .Studios.Limit.ToString

            Try
                cbMovieScraperCertLang.Items.Clear()
                cbMovieScraperCertLang.Items.Add(Master.eLang.All)
                cbMovieScraperCertLang.Items.AddRange((From lLang In APIXML.CertLanguagesXML.Language Select lLang.name).ToArray)
                If cbMovieScraperCertLang.Items.Count > 0 Then
                    If .Certifications.Filter = Master.eLang.All Then
                        cbMovieScraperCertLang.SelectedIndex = 0
                    ElseIf .Certifications.FilterSpecified Then
                        Dim tLanguage As CertLanguages = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = .Certifications.Filter)
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

            _lstMovieMeta.AddRange(Master.eSettings.MovieMetadataPerFileType)
            LoadMovieMetadata()
        End With
    End Sub

    Public Sub SaveSetup() Implements Interfaces.MasterSettingsPanel.SaveSetup
        With Master.eSettings.Movie.DataSettings
            .Actors.Locked = chkMovieLockActors.Checked
            .Certifications.Locked = chkMovieLockCert.Checked
            .Collection.Locked = chkMovieLockCollections.Checked
            .CollectionID.Locked = chkMovieLockCollectionID.Checked
            .Countries.Locked = chkMovieLockCountry.Checked
            .Directors.Locked = chkMovieLockDirector.Checked
            .Genres.Locked = chkMovieLockGenre.Checked
            .LockAudioLanguage = chkMovieLockLanguageA.Checked
            .LockVideoLanguage = chkMovieLockLanguageV.Checked
            .MPAA.Locked = chkMovieLockMPAA.Checked
            .Outline.Locked = chkMovieLockOutline.Checked
            .Plot.Locked = chkMovieLockPlot.Checked
            .Rating.Locked = chkMovieLockRating.Checked
            .ReleaseDate.Locked = chkMovieLockReleaseDate.Checked
            .Runtime.Locked = chkMovieLockRuntime.Checked
            .Studios.Locked = chkMovieLockStudio.Checked
            .Tags.Locked = chkMovieLockTags.Checked
            .Tagline.Locked = chkMovieLockTagline.Checked
            .OriginalTitle.Locked = chkMovieLockOriginalTitle.Checked
            .Title.Locked = chkMovieLockTitle.Checked
            .Top250.Locked = chkMovieLockTop250.Checked
            .Trailer.Locked = chkMovieLockTrailer.Checked
            .UserRating.Locked = chkMovieLockUserRating.Checked
            .Credits.Locked = chkMovieLockCredits.Checked
            .Year.Locked = chkMovieLockYear.Checked
            Master.eSettings.MovieMetadataPerFileType.Clear()
            Master.eSettings.MovieMetadataPerFileType.AddRange(_lstMovieMeta)
            .Actors.Enabled = chkMovieScraperCast.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperCastLimit.Text) Then
                .Actors.Limit = Convert.ToInt32(txtMovieScraperCastLimit.Text)
            Else
                .Actors.Limit = 0
            End If
            .ActorsWithImageOnly = chkMovieScraperCastWithImg.Checked
            .Certifications.Enabled = chkMovieScraperCert.Checked
            .CertificationsForMPAA = chkMovieScraperCertForMPAA.Checked
            .CertificationsForMPAAFallback = chkMovieScraperCertForMPAAFallback.Checked
            .CertificationsOnlyValue = chkMovieScraperCertOnlyValue.Checked
            If Not String.IsNullOrEmpty(cbMovieScraperCertLang.Text) Then
                If cbMovieScraperCertLang.SelectedIndex = 0 Then
                    .Certifications.Filter = Master.eLang.All
                Else
                    .Certifications.Filter = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.name = cbMovieScraperCertLang.Text).abbreviation
                End If
            End If
            .ClearDisabledFields = chkMovieScraperCleanFields.Checked
            .CleanPlotAndOutline = chkMovieScraperCleanPlotOutline.Checked
            .CollectionID.Enabled = chkMovieScraperCollectionID.Checked
            .CollectionAutoAdd = chkMovieScraperCollectionsAuto.Checked
            .CollectionKodiExtendedInfo = chkMovieScraperCollectionsExtendedInfo.Checked
            .CollectionYAMJCompatible = chkMovieScraperCollectionsYAMJCompatibleSets.Checked
            .Countries.Enabled = chkMovieScraperCountry.Checked
            .Directors.Enabled = chkMovieScraperDirector.Checked
            .DurationFormat = txtDurationFormat.Text
            .Genres.Enabled = chkMovieScraperGenre.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperGenreLimit.Text) Then
                .Genres.Limit = Convert.ToInt32(txtMovieScraperGenreLimit.Text)
            Else
                .Genres.Limit = 0
            End If
            .MetaDataScan = chkMovieScraperMetaDataScan.Checked
            .MPAA.Enabled = chkMovieScraperMPAA.Checked
            .MPAANotRatedValue = txtMovieScraperMPAANotRated.Text
            .OriginalTitle.Enabled = chkMovieScraperOriginalTitle.Checked
            .Outline.Enabled = chkMovieScraperOutline.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperOutlineLimit.Text) Then
                .Outline.Limit = Convert.ToInt32(txtMovieScraperOutlineLimit.Text)
            Else
                .Outline.Limit = 0
            End If
            .Plot.Enabled = chkMovieScraperPlot.Checked
            .PlotForOutline = chkMovieScraperPlotForOutline.Checked
            .PlotForOutlineAsFallback = chkMovieScraperPlotForOutlineIfEmpty.Checked
            .Rating.Enabled = chkMovieScraperRating.Checked
            .ReleaseDate.Enabled = chkMovieScraperRelease.Checked
            .Runtime.Enabled = chkMovieScraperRuntime.Checked
            .Studios.Enabled = chkMovieScraperStudio.Checked
            .StudiosWithImageOnly = chkMovieScraperStudioWithImg.Checked
            If Not String.IsNullOrEmpty(txtMovieScraperStudioLimit.Text) Then
                .Studios.Limit = Convert.ToInt32(txtMovieScraperStudioLimit.Text)
            Else
                .Studios.Limit = 0
            End If
            .Tagline.Enabled = chkMovieScraperTagline.Checked
            .Title.Enabled = chkMovieScraperTitle.Checked
            .Top250.Enabled = chkMovieScraperTop250.Checked
            .Trailer.Enabled = chkMovieScraperTrailer.Checked
            Master.eSettings.MovieScraperUseDetailView = chkMovieScraperDetailView.Checked
            .DurationForRuntime = chkDurationForRuntime.Checked
            .UserRating.Enabled = chkMovieScraperUserRating.Checked
            .Credits.Enabled = chkMovieScraperCredits.Checked
            .TrailerKodiFormat = chkMovieScraperTrailerKodiFormat.Checked
            .Year.Enabled = chkMovieScraperYear.Checked

        End With
    End Sub

#End Region 'Interface Methodes

#Region "Methods"

    Private Sub btnMovieScraperDefFIExtEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieScraperDefFIExtEdit.Click
        Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.Movie), False)
            Dim fi As New MediaContainers.Fileinfo
            For Each x As Settings.MetadataPerType In _lstMovieMeta
                If x.FileType = lstMovieScraperDefFIExt.SelectedItems(0).ToString Then
                    fi = dEditMeta.ShowDialog(x.MetaData, False)
                    If Not fi Is Nothing Then
                        _lstMovieMeta.Remove(x)
                        Dim m As New Settings.MetadataPerType
                        m.FileType = x.FileType
                        m.MetaData = New MediaContainers.Fileinfo
                        m.MetaData = fi
                        _lstMovieMeta.Add(m)
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
                _lstMovieMeta.Add(m)
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
            chkMovieScraperCertOnlyValue.Enabled = False
            chkMovieScraperCertOnlyValue.Checked = False
        Else
            cbMovieScraperCertLang.Enabled = True
            cbMovieScraperCertLang.SelectedIndex = 0
            chkMovieScraperCertForMPAA.Enabled = True
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

    Private Sub chkMovieScraperUseMDDuration_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDurationForRuntime.CheckedChanged
        txtDurationFormat.Enabled = chkDurationForRuntime.Checked
        EnableApplyButton()
    End Sub

    Private Sub EnableApplyButton()

        Handle_SettingsChanged()
    End Sub

    Private Sub LoadMovieMetadata()
        lstMovieScraperDefFIExt.Items.Clear()
        For Each x As Settings.MetadataPerType In _lstMovieMeta
            lstMovieScraperDefFIExt.Items.Add(x.FileType)
        Next
    End Sub

    Private Sub LoadScraperSettings(ByVal strName As String)

    End Sub

    Private Sub lstMovieScraperDefFIExt_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lstMovieScraperDefFIExt.DoubleClick
        If lstMovieScraperDefFIExt.SelectedItems.Count > 0 Then
            Using dEditMeta As New dlgFileInfo(New Database.DBElement(Enums.ContentType.Movie), False)
                Dim fi As New MediaContainers.Fileinfo
                For Each x As Settings.MetadataPerType In _lstMovieMeta
                    If x.FileType = lstMovieScraperDefFIExt.SelectedItems(0).ToString Then
                        fi = dEditMeta.ShowDialog(x.MetaData, False)
                        If Not fi Is Nothing Then
                            _lstMovieMeta.Remove(x)
                            Dim m As New Settings.MetadataPerType
                            m.FileType = x.FileType
                            m.MetaData = New MediaContainers.Fileinfo
                            m.MetaData = fi
                            _lstMovieMeta.Add(m)
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
            For Each x As Settings.MetadataPerType In _lstMovieMeta
                If x.FileType = lstMovieScraperDefFIExt.SelectedItems(0).ToString Then
                    _lstMovieMeta.Remove(x)
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
        lblMovieScraperGlobalStudios.Text = Master.eLang.GetString(226, "Studios")
        lblMovieScraperGlobalTagline.Text = Master.eLang.GetString(397, "Tagline")
        lblMovieScraperGlobalTitle.Text = Master.eLang.GetString(21, "Title")
        lblMovieScraperGlobalTop250.Text = Master.eLang.GetString(591, "Top 250")
        lblMovieScraperGlobalTrailer.Text = Master.eLang.GetString(151, "Trailer")
        chkMovieScraperCertForMPAA.Text = Master.eLang.GetString(511, "Use Certification for MPAA")
        lblMovieScraperGlobalUserRating.Text = Master.eLang.GetString(1464, "User Rating")
        lblMovieScraperGlobalCredits.Text = Master.eLang.GetString(394, "Writers")
        lblMovieScraperGlobalYear.Text = Master.eLang.GetString(278, "Year")
        chkMovieScraperCleanPlotOutline.Text = Master.eLang.GetString(985, "Clean Plot/Outline")
        chkMovieScraperCollectionsAuto.Text = Master.eLang.GetString(1266, "Add Movie automatically to Collections")
        chkMovieScraperDetailView.Text = Master.eLang.GetString(1249, "Show scraped results in detailed view")
        chkMovieScraperMetaDataScan.Text = Master.eLang.GetString(517, "Scan Meta Data")
        chkMovieScraperPlotForOutline.Text = Master.eLang.GetString(965, "Use Plot for Plot Outline")
        chkMovieScraperPlotForOutlineIfEmpty.Text = Master.eLang.GetString(958, "Only if Plot Outline is empty")
        chkMovieScraperStudioWithImg.Text = Master.eLang.GetString(1280, "Scrape Only Studios With Images")
        chkDurationForRuntime.Text = Master.eLang.GetString(516, "Use Duration for Runtime")
        chkMovieScraperTrailerKodiFormat.Text = Master.eLang.GetString(1187, "Save YouTube-Trailer-Links in XBMC compatible format")
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

        clsAPITemp.ConvertToScraperGridView(dgvActors, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Actors)))
        clsAPITemp.ConvertToScraperGridView(dgvCertifications, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Certifications)))
        clsAPITemp.ConvertToScraperGridView(dgvCollectionID, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_CollectionID)))
        clsAPITemp.ConvertToScraperGridView(dgvCoutries, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Countries)))
        clsAPITemp.ConvertToScraperGridView(dgvCredits, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Writers)))
        clsAPITemp.ConvertToScraperGridView(dgvDirectors, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Directors)))
        clsAPITemp.ConvertToScraperGridView(dgvGenres, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Genres)))
        clsAPITemp.ConvertToScraperGridView(dgvMPAA, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_MPAA)))
        clsAPITemp.ConvertToScraperGridView(dgvOriginalTitle, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_OriginalTitle)))
        clsAPITemp.ConvertToScraperGridView(dgvOutline, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Outline)))
        clsAPITemp.ConvertToScraperGridView(dgvPlot, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Plot)))
        clsAPITemp.ConvertToScraperGridView(dgvRating, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Rating)))
        clsAPITemp.ConvertToScraperGridView(dgvReleaseDate, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_ReleaseDate)))
        clsAPITemp.ConvertToScraperGridView(dgvRuntime, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Runtime)))
        clsAPITemp.ConvertToScraperGridView(dgvStudios, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Studios)))
        clsAPITemp.ConvertToScraperGridView(dgvTagline, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Tagline)))
        clsAPITemp.ConvertToScraperGridView(dgvTags, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Tags)))
        clsAPITemp.ConvertToScraperGridView(dgvTitle, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Title)))
        clsAPITemp.ConvertToScraperGridView(dgvTop250, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Top250)))
        clsAPITemp.ConvertToScraperGridView(dgvTrailer, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Trailer)))
        clsAPITemp.ConvertToScraperGridView(dgvUserRating, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_UserRating)))
        clsAPITemp.ConvertToScraperGridView(dgvYear, Master.ScraperList.FindAll(Function(f) f.ScraperCapatibilities.Contains(Enums.ScraperCapatibility.Movie_Data_Year)))

        clsAPITemp.ConvertToSearchEngineGridView(dgvSearchAdditional, Master.SearchEngineList.FindAll(Function(f) f.SearchMovie))
        clsAPITemp.ConvertToSearchEngineGridView(dgvSearchInitial, Master.SearchEngineList.FindAll(Function(f) f.SearchMovie))
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

    Private Sub cbSelectSetting_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelectSetting.SelectedIndexChanged
        LoadScraperSettings("Default")
    End Sub
    ''' <summary>
    ''' Workaround to autosize the DGV based on column widths without change the row hights
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlSettings_VisibleChanged(sender As Object, e As EventArgs) Handles pnlSettings.VisibleChanged
        If Not _bDGVWidthCalculated AndAlso CType(sender, Panel).Visible Then
            tblMovieScraperGlobalOpts.SuspendLayout()
            For i As Integer = 0 To tblMovieScraperGlobalOpts.Controls.Count - 1
                Dim nType As Type = tblMovieScraperGlobalOpts.Controls(i).GetType
                If nType.Name = "DataGridView" Then
                    Dim nDataGridView As DataGridView = CType(tblMovieScraperGlobalOpts.Controls(i), DataGridView)
                    Dim intWidth As Integer = 0
                    For Each nColumn As DataGridViewColumn In nDataGridView.Columns
                        intWidth += nColumn.Width
                    Next
                    nDataGridView.Width = intWidth + 1
                End If
            Next
            tblMovieScraperGlobalOpts.ResumeLayout()
            _bDGVWidthCalculated = True
        End If
    End Sub

#End Region 'Methods

End Class