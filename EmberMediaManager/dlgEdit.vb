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

Imports System.IO
Imports System.Text.RegularExpressions
Imports EmberAPI
Imports NLog

Public Class dlgEdit

#Region "Events"

#End Region 'Events

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _tmpDBElement As Database.DBElement

    Private fResults As New Containers.ImgResult
    Private lvwActorSorter As ListViewColumnSorter
    Private pResults As New Containers.ImgResult
    Private AnyThemePlayerEnabled As Boolean = False
    Private AnyTrailerPlayerEnabled As Boolean = False

    'Extrafanarts
    Private iEFLeft As Integer = 1
    Private iEFTop As Integer = 1
    Private pbExtrafanartsImage() As PictureBox
    Private pnlExtrafanartsImage() As Panel

    'Extrathumbs
    Private iETLeft As Integer = 1
    Private iETTop As Integer = 1
    Private pbExtrathumbsImage() As PictureBox
    Private pnlExtrathumbsImage() As Panel
    Private currExtrathumbImage As New MediaContainers.Image

#End Region 'Fields

#Region "Properties"

    Public ReadOnly Property Result As Database.DBElement
        Get
            Return _tmpDBElement
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Left = Master.AppPos.Left + (Master.AppPos.Width - Width) \ 2
        Top = Master.AppPos.Top + (Master.AppPos.Height - Height) \ 2
        StartPosition = FormStartPosition.Manual
    End Sub

    Public Overloads Function ShowDialog(ByVal tDBElement As Database.DBElement) As DialogResult
        _tmpDBElement = tDBElement
        Return ShowDialog()
    End Function

    Private Sub ActorEdit()
        If lvActors.SelectedItems.Count > 0 Then
            Dim lvwItem As ListViewItem = lvActors.SelectedItems(0)
            Dim eActor As MediaContainers.Person = DirectCast(lvwItem.Tag, MediaContainers.Person)
            Using dAddEditActor As New dlgAddEditActor
                If dAddEditActor.ShowDialog(eActor) = DialogResult.OK Then
                    eActor = dAddEditActor.Result
                    lvwItem.Text = eActor.ID.ToString
                    lvwItem.Tag = eActor
                    lvwItem.SubItems(1).Text = eActor.Name
                    lvwItem.SubItems(2).Text = eActor.Role
                    lvwItem.SubItems(3).Text = eActor.URLOriginal
                    lvwItem.Selected = True
                    lvwItem.EnsureVisible()
                End If
            End Using
        End If
    End Sub

    Private Sub ActorRemove()
        If lvActors.Items.Count > 0 Then
            While lvActors.SelectedItems.Count > 0
                lvActors.Items.Remove(lvActors.SelectedItems(0))
            End While
        End If
    End Sub

    Private Sub AddExtrafanartImage(ByVal sDescription As String, ByVal iIndex As Integer, tImage As MediaContainers.Image)
        Try
            If tImage.ImageOriginal.Image Is Nothing Then
                tImage.LoadAndCache(Enums.ContentType.Movie, True, True)
            End If

            ReDim Preserve pnlExtrafanartsImage(iIndex)
            ReDim Preserve pbExtrafanartsImage(iIndex)
            pnlExtrafanartsImage(iIndex) = New Panel()
            pbExtrafanartsImage(iIndex) = New PictureBox()
            pbExtrafanartsImage(iIndex).Name = iIndex.ToString
            pnlExtrafanartsImage(iIndex).Name = iIndex.ToString
            pnlExtrafanartsImage(iIndex).Size = New Size(128, 72)
            pbExtrafanartsImage(iIndex).Size = New Size(128, 72)
            pnlExtrafanartsImage(iIndex).BackColor = Color.White
            pnlExtrafanartsImage(iIndex).BorderStyle = BorderStyle.FixedSingle
            pbExtrafanartsImage(iIndex).SizeMode = PictureBoxSizeMode.Zoom
            pnlExtrafanartsImage(iIndex).Tag = tImage
            pbExtrafanartsImage(iIndex).Tag = tImage
            pbExtrafanartsImage(iIndex).Image = tImage.ImageOriginal.Image
            pnlExtrafanartsImage(iIndex).Left = iEFLeft
            pbExtrafanartsImage(iIndex).Left = 0
            pnlExtrafanartsImage(iIndex).Top = iEFTop
            pbExtrafanartsImage(iIndex).Top = 0
            pnlExtrafanarts.Controls.Add(pnlExtrafanartsImage(iIndex))
            pnlExtrafanartsImage(iIndex).Controls.Add(pbExtrafanartsImage(iIndex))
            pnlExtrafanartsImage(iIndex).BringToFront()
            AddHandler pbExtrafanartsImage(iIndex).Click, AddressOf pbExtrafanartsImage_Click
            AddHandler pnlExtrafanartsImage(iIndex).Click, AddressOf pnlExtrafanartsImage_Click
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        iEFTop += 74

    End Sub

    Private Sub AddExtrathumbImage(ByVal sDescription As String, ByVal iIndex As Integer, tImage As MediaContainers.Image)
        Try
            If tImage.ImageOriginal.Image Is Nothing Then
                tImage.LoadAndCache(Enums.ContentType.Movie, True, True)
            End If

            ReDim Preserve pnlExtrathumbsImage(iIndex)
            ReDim Preserve pbExtrathumbsImage(iIndex)
            pnlExtrathumbsImage(iIndex) = New Panel()
            pbExtrathumbsImage(iIndex) = New PictureBox()
            pbExtrathumbsImage(iIndex).Name = iIndex.ToString
            pnlExtrathumbsImage(iIndex).Name = iIndex.ToString
            pnlExtrathumbsImage(iIndex).Size = New Size(128, 72)
            pbExtrathumbsImage(iIndex).Size = New Size(128, 72)
            pnlExtrathumbsImage(iIndex).BackColor = Color.White
            pnlExtrathumbsImage(iIndex).BorderStyle = BorderStyle.FixedSingle
            pbExtrathumbsImage(iIndex).SizeMode = PictureBoxSizeMode.Zoom
            pnlExtrathumbsImage(iIndex).Tag = tImage
            pbExtrathumbsImage(iIndex).Tag = tImage
            pbExtrathumbsImage(iIndex).Image = tImage.ImageOriginal.Image
            pnlExtrathumbsImage(iIndex).Left = iETLeft
            pbExtrathumbsImage(iIndex).Left = 0
            pnlExtrathumbsImage(iIndex).Top = iETTop
            pbExtrathumbsImage(iIndex).Top = 0
            pnlExtrathumbs.Controls.Add(pnlExtrathumbsImage(iIndex))
            pnlExtrathumbsImage(iIndex).Controls.Add(pbExtrathumbsImage(iIndex))
            pnlExtrathumbsImage(iIndex).BringToFront()
            AddHandler pbExtrathumbsImage(iIndex).Click, AddressOf pbExtrathumbsImage_Click
            AddHandler pnlExtrathumbsImage(iIndex).Click, AddressOf pnlExtrathumbsImage_Click
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        iETTop += 74

    End Sub

    Private Sub DoSelectExtrafanart(ByVal iIndex As Integer, tImg As MediaContainers.Image)
        pbExtrafanarts.Image = tImg.ImageOriginal.Image
        pbExtrafanarts.Tag = tImg
        btnExtrafanartsSetAsFanart.Enabled = True
        lblExtrafanartsSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbExtrafanarts.Image.Width, pbExtrafanarts.Image.Height)
        lblExtrafanartsSize.Visible = True
    End Sub

    Private Sub DoSelectExtrathumb(ByVal iIndex As Integer, tImg As MediaContainers.Image)
        currExtrathumbImage = tImg

        pbExtrathumbs.Image = tImg.ImageOriginal.Image
        pbExtrathumbs.Tag = tImg
        btnExtrathumbsSetAsFanart.Enabled = True
        lblExtrathumbsSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbExtrathumbs.Image.Width, pbExtrathumbs.Image.Height)
        lblExtrathumbsSize.Visible = True

        If tImg.Index > 0 Then
            btnExtrathumbsUp.Enabled = True
        Else
            btnExtrathumbsUp.Enabled = False
        End If
        If tImg.Index < _tmpDBElement.ImagesContainer.Extrathumbs.Count - 1 Then
            btnExtrathumbsDown.Enabled = True
        Else
            btnExtrathumbsDown.Enabled = False
        End If
    End Sub

    Private Sub btnActorAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd_Actor.Click, btnAdd_SpecialGuest.Click
        Using dAddEditActor As New dlgAddEditActor
            If dAddEditActor.ShowDialog() = DialogResult.OK Then
                Dim nActor As MediaContainers.Person = dAddEditActor.Result
                Dim lvItem As ListViewItem = lvActors.Items.Add(nActor.ID.ToString)
                lvItem.Tag = nActor
                lvItem.SubItems.Add(nActor.Name)
                lvItem.SubItems.Add(nActor.Role)
                lvItem.SubItems.Add(nActor.URLOriginal)
            End If
        End Using
    End Sub

    Private Sub btnActorDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown_Actor.Click, btnDown_SpecialGuest.Click
        If lvActors.SelectedItems.Count > 0 AndAlso lvActors.SelectedItems(0) IsNot Nothing AndAlso lvActors.SelectedIndices(0) < (lvActors.Items.Count - 1) Then
            Dim iIndex As Integer = lvActors.SelectedIndices(0)
            lvActors.Items.Insert(iIndex + 2, DirectCast(lvActors.SelectedItems(0).Clone, ListViewItem))
            lvActors.Items.RemoveAt(iIndex)
            lvActors.Items(iIndex + 1).Selected = True
            lvActors.Select()
        End If
    End Sub

    Private Sub btnActorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit_Actor.Click, btnEdit_SpecialGuest.Click
        ActorEdit()
    End Sub

    Private Sub btnActorRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove_Actor.Click, btnRemove_SpecialGuest.Click
        ActorRemove()
    End Sub

    Private Sub btnActorUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp_Actor.Click, btnUp_SpecialGuest.Click
        If lvActors.SelectedItems.Count > 0 AndAlso lvActors.SelectedItems(0) IsNot Nothing AndAlso lvActors.SelectedIndices(0) > 0 Then
            Dim iIndex As Integer = lvActors.SelectedIndices(0)
            lvActors.Items.Insert(iIndex - 1, DirectCast(lvActors.SelectedItems(0).Clone, ListViewItem))
            lvActors.Items.RemoveAt(iIndex + 1)
            lvActors.Items(iIndex - 1).Selected = True
            lvActors.Select()
        End If
    End Sub

    Private Sub btnChangeMovie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        ThemeStop()
        TrailerStop()
        CleanUp()
        DialogResult = DialogResult.Abort
    End Sub

    Private Sub btnDLTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim aUrlList As New List(Of Themes)
        'Dim tURL As String = String.Empty
        'If Not ModulesManager.Instance.ScrapeTheme_Movie(tmpDBMovie, aUrlList) Then
        '    Using dThemeSelect As New dlgThemeSelect()
        '        MovieTheme = dThemeSelect.ShowDialog(tmpDBMovie, aUrlList)
        '    End Using
        'End If

        'If Not String.IsNullOrEmpty(MovieTheme.URL) Then
        '    'btnPlayTheme.Enabled = True
        'End If
    End Sub

    Private Sub btnDLTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd_Trailer.Click
        Dim tResults As New MediaContainers.Trailer
        Dim dlgTrlS As dlgTrailerSelect
        Dim tList As New List(Of MediaContainers.Trailer)
        Dim tURL As String = String.Empty

        Try
            dlgTrlS = New dlgTrailerSelect()
            If dlgTrlS.ShowDialog(_tmpDBElement, tList, True, True, True) = DialogResult.OK Then
                tURL = dlgTrlS.Result.URLWebsite
            End If

            If Not String.IsNullOrEmpty(tURL) Then
                btnPlay_Trailer.Enabled = True
                txtTrailer.Text = tURL
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Sub btnExtrathumbsDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrathumbsDown.Click
        If _tmpDBElement.ImagesContainer.Extrathumbs.Count > 0 AndAlso currExtrathumbImage.Index < _tmpDBElement.ImagesContainer.Extrathumbs.Count - 1 Then
            Dim iIndex As Integer = currExtrathumbImage.Index
            _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex).Index = _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex).Index + 1
            _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex + 1).Index = _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex + 1).Index - 1
            RefreshExtrathumbs()
            DoSelectExtrathumb(iIndex + 1, CType(pnlExtrathumbsImage(iIndex + 1).Tag, MediaContainers.Image))
        End If
    End Sub

    Private Sub btnExtrathumbsUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrathumbsUp.Click
        If _tmpDBElement.ImagesContainer.Extrathumbs.Count > 0 AndAlso currExtrathumbImage.Index > 0 Then
            Dim iIndex As Integer = currExtrathumbImage.Index
            _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex).Index = _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex).Index - 1
            _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex - 1).Index = _tmpDBElement.ImagesContainer.Extrathumbs.Item(iIndex - 1).Index + 1
            RefreshExtrathumbs()
            DoSelectExtrathumb(iIndex - 1, CType(pnlExtrathumbsImage(iIndex - 1).Tag, MediaContainers.Image))
        End If
    End Sub

    Private Sub btnPlayTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay_Trailer.Click
        'TODO 2013/12/18 Dekker500 - This should be re-factored to use Functions.Launch. Why is the URL different for non-windows??? Need to test first before editing
        Try

            Dim tPath As String = String.Empty

            If Not String.IsNullOrEmpty(txtTrailer.Text) Then
                tPath = String.Concat("""", txtTrailer.Text, """")
            End If

            If Not String.IsNullOrEmpty(tPath) Then
                If Master.isWindows Then
                    If Regex.IsMatch(tPath, "plugin:\/\/plugin\.video\.youtube\/\?action=play_video&videoid=") Then
                        tPath = tPath.Replace("plugin://plugin.video.youtube/?action=play_video&videoid=", "http://www.youtube.com/watch?v=")
                    End If
                    Process.Start(tPath)
                Else
                    Using Explorer As New Process
                        Explorer.StartInfo.FileName = "xdg-open"
                        Explorer.StartInfo.Arguments = tPath
                        Explorer.Start()
                    End Using
                End If
            End If

        Catch
            MessageBox.Show(Master.eLang.GetString(270, "The trailer could not be played. This could be due to an invalid URI or you do not have the proper player to play the trailer type."), Master.eLang.GetString(271, "Error Playing Trailer"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnPlayTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TODO 2013/12/18 Dekker500 - This should be re-factored to use Functions.Launch. Why is the URL different for non-windows??? Need to test first before editing
        Try

            Dim tPath As String = String.Empty

            If Not String.IsNullOrEmpty(_tmpDBElement.Theme.LocalFilePath) Then
                tPath = String.Concat("""", _tmpDBElement.Theme.LocalFilePath, """")
            End If

            If Not String.IsNullOrEmpty(tPath) Then
                If Master.isWindows Then
                    Process.Start(tPath)
                Else
                    Using Explorer As New Process
                        Explorer.StartInfo.FileName = "xdg-open"
                        Explorer.StartInfo.Arguments = tPath
                        Explorer.Start()
                    End Using
                End If
            End If

        Catch
            MessageBox.Show(Master.eLang.GetString(1078, "The theme could not be played. This could due be you don't have the proper player to play the theme type."), Master.eLang.GetString(1079, "Error Playing Theme"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnRemoveBanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBanner.Click
        pbBanner.Image = Nothing
        pbBanner.Tag = Nothing
        lblBannerSize.Text = String.Empty
        lblBannerSize.Visible = False
        _tmpDBElement.ImagesContainer.Banner = New MediaContainers.Image
    End Sub

    Private Sub btnRemoveClearArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveClearArt.Click
        pbClearArt.Image = Nothing
        pbClearArt.Tag = Nothing
        lblClearArtSize.Text = String.Empty
        lblClearArtSize.Visible = False
        _tmpDBElement.ImagesContainer.ClearArt = New MediaContainers.Image
    End Sub

    Private Sub btnRemoveClearLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveClearLogo.Click
        pbClearLogo.Image = Nothing
        pbClearLogo.Tag = Nothing
        lblClearLogoSize.Text = String.Empty
        lblClearLogoSize.Visible = False
        _tmpDBElement.ImagesContainer.ClearLogo = New MediaContainers.Image
    End Sub

    Private Sub btnRemoveDiscArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveDiscArt.Click
        pbDiscArt.Image = Nothing
        pbDiscArt.Tag = Nothing
        lblDiscArtSize.Text = String.Empty
        lblDiscArtSize.Visible = False
        _tmpDBElement.ImagesContainer.DiscArt = New MediaContainers.Image
    End Sub

    Private Sub btnRemoveFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFanart.Click
        pbFanart.Image = Nothing
        pbFanart.Tag = Nothing
        lblFanartSize.Text = String.Empty
        lblFanartSize.Visible = False
        _tmpDBElement.ImagesContainer.Fanart = New MediaContainers.Image
    End Sub

    Private Sub btnRemoveLandscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveLandscape.Click
        pbLandscape.Image = Nothing
        pbLandscape.Tag = Nothing
        lblLandscapeSize.Text = String.Empty
        lblLandscapeSize.Visible = False
        _tmpDBElement.ImagesContainer.Landscape = New MediaContainers.Image
    End Sub

    Private Sub btnRemovePoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemovePoster.Click
        pbPoster.Image = Nothing
        pbPoster.Tag = Nothing
        lblPosterSize.Text = String.Empty
        lblPosterSize.Visible = False
        _tmpDBElement.ImagesContainer.Poster = New MediaContainers.Image
    End Sub

    Private Sub btnRemoveSubtitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSubtitle.Click
        DeleteSubtitle()
    End Sub

    Private Sub btnRemoveTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTheme.Click
        ThemeStop()
        'axVLCTheme.playlist.items.clear()
        _tmpDBElement.Theme = New MediaContainers.Theme
        txtLocalTheme.Text = String.Empty
    End Sub

    Private Sub btnRemoveTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTrailer.Click
        TrailerStop()
        TrailerPlaylistClear()
        _tmpDBElement.Trailer = New MediaContainers.Trailer
        txtLocalTrailer.Text = String.Empty
    End Sub

    Private Sub btnExtrafanartsRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrafanartsRemove.Click
        RemoveExtrafanart()
    End Sub

    Private Sub btnExtrathumbsRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrathumbsRemove.Click
        RemoveExtrathumb()
    End Sub

    Private Sub RemoveExtrafanart()
        If pbExtrafanarts.Tag IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Extrafanarts.Remove(DirectCast(pbExtrafanarts.Tag, MediaContainers.Image))
            RefreshExtrafanarts()
            lblExtrafanartsSize.Text = String.Empty
            lblExtrafanartsSize.Visible = False
        End If
    End Sub

    Private Sub RemoveExtrathumb()
        If pbExtrathumbs.Tag IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Extrathumbs.Remove(DirectCast(pbExtrathumbs.Tag, MediaContainers.Image))
            RefreshExtrathumbs()
            lblExtrafanartsSize.Text = String.Empty
            lblExtrafanartsSize.Visible = False
        End If
    End Sub

    Private Sub btnRescrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRescrape.Click
        ThemeStop()
        TrailerStop()
        CleanUp()
        DialogResult = DialogResult.Retry
    End Sub

    Private Sub btnSetBannerDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBannerDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.Banner = tImage
                    pbBanner.Image = _tmpDBElement.ImagesContainer.Banner.ImageOriginal.Image
                    pbBanner.Tag = _tmpDBElement.ImagesContainer.Banner

                    lblBannerSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbBanner.Image.Width, pbBanner.Image.Height)
                    lblBannerSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetBannerScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBannerScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainBanner, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainBanners.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.Banner = dlgImgS.Result.ImagesContainer.Banner
                    If _tmpDBElement.ImagesContainer.Banner.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.Banner.ImageOriginal.LoadFromMemoryStream Then
                        pbBanner.Image = _tmpDBElement.ImagesContainer.Banner.ImageOriginal.Image
                        lblBannerSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbBanner.Image.Width, pbBanner.Image.Height)
                        lblBannerSize.Visible = True
                    Else
                        pbBanner.Image = Nothing
                        pbBanner.Tag = Nothing
                        lblBannerSize.Text = String.Empty
                        lblBannerSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(1363, "No Banners found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetBannerLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBannerLocal.Click
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.jpg;*.png"
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.Banner.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbBanner.Image = _tmpDBElement.ImagesContainer.Banner.ImageOriginal.Image
            pbBanner.Tag = _tmpDBElement.ImagesContainer.Banner

            lblBannerSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbBanner.Image.Width, pbBanner.Image.Height)
            lblBannerSize.Visible = True
        End If
    End Sub

    Private Sub btnSetClearArtDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClearArtDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.ClearArt = tImage
                    pbClearArt.Image = _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.Image
                    pbClearArt.Tag = _tmpDBElement.ImagesContainer.ClearArt

                    lblClearArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearArt.Image.Width, pbClearArt.Image.Height)
                    lblClearArtSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetClearArtScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClearArtScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainClearArt, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainClearArts.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.ClearArt = dlgImgS.Result.ImagesContainer.ClearArt
                    If _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.LoadFromMemoryStream Then
                        pbClearArt.Image = _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.Image
                        lblClearArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearArt.Image.Width, pbClearArt.Image.Height)
                        lblClearArtSize.Visible = True
                    Else
                        pbClearArt.Image = Nothing
                        pbClearArt.Tag = Nothing
                        lblClearArtSize.Text = String.Empty
                        lblClearArtSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(1102, "No ClearArts found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetClearArtLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClearArtLocal.Click
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.png"
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbClearArt.Image = _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.Image
            pbClearArt.Tag = _tmpDBElement.ImagesContainer.ClearArt

            lblClearArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearArt.Image.Width, pbClearArt.Image.Height)
            lblClearArtSize.Visible = True
        End If
    End Sub

    Private Sub btnSetClearLogoDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClearLogoDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.ClearLogo = tImage
                    pbClearLogo.Image = _tmpDBElement.ImagesContainer.ClearLogo.ImageOriginal.Image
                    pbClearLogo.Tag = _tmpDBElement.ImagesContainer.ClearLogo

                    lblClearLogoSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearLogo.Image.Width, pbClearLogo.Image.Height)
                    lblClearLogoSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetClearLogoScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClearLogoScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainClearLogo, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainClearLogos.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.ClearLogo = dlgImgS.Result.ImagesContainer.ClearLogo
                    If dlgImgS.Result.ImagesContainer.ClearLogo.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.ClearLogo.ImageOriginal.LoadFromMemoryStream Then
                        pbClearLogo.Image = _tmpDBElement.ImagesContainer.ClearLogo.ImageOriginal.Image
                        lblClearLogoSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearLogo.Image.Width, pbClearLogo.Image.Height)
                        lblClearLogoSize.Visible = True
                    Else
                        pbClearLogo.Image = Nothing
                        pbClearLogo.Tag = Nothing
                        lblClearLogoSize.Text = String.Empty
                        lblClearLogoSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(1103, "No ClearLogos found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetClearLogoLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetClearLogoLocal.Click
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.png"
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.ClearLogo.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbClearLogo.Image = _tmpDBElement.ImagesContainer.ClearLogo.ImageOriginal.Image
            pbClearLogo.Tag = _tmpDBElement.ImagesContainer.ClearLogo

            lblClearLogoSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearLogo.Image.Width, pbClearLogo.Image.Height)
            lblClearLogoSize.Visible = True
        End If
    End Sub

    Private Sub btnSetDiscArtDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDiscArtDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.DiscArt = tImage
                    pbDiscArt.Image = _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.Image
                    pbDiscArt.Tag = _tmpDBElement.ImagesContainer.DiscArt

                    lblDiscArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbDiscArt.Image.Width, pbDiscArt.Image.Height)
                    lblDiscArtSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetDiscArtScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDiscArtScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainDiscArt, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainDiscArts.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.DiscArt = dlgImgS.Result.ImagesContainer.DiscArt
                    If _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.LoadFromMemoryStream Then
                        pbDiscArt.Image = _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.Image
                        lblDiscArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbDiscArt.Image.Width, pbDiscArt.Image.Height)
                        lblDiscArtSize.Visible = True
                    Else
                        pbDiscArt.Image = Nothing
                        pbDiscArt.Tag = Nothing
                        lblDiscArtSize.Text = String.Empty
                        lblDiscArtSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(1104, "No DiscArts found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetDiscArtLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDiscArtLocal.Click

        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.png"
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbDiscArt.Image = _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.Image
            pbDiscArt.Tag = _tmpDBElement.ImagesContainer.DiscArt

            lblDiscArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbDiscArt.Image.Width, pbDiscArt.Image.Height)
            lblDiscArtSize.Visible = True
        End If
    End Sub

    Private Sub btnExtrafanartsSetAsFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrafanartsSetAsFanart.Click
        If pbExtrafanarts.Tag IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Fanart = DirectCast(pbExtrafanarts.Tag, MediaContainers.Image)
            pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
            pbFanart.Tag = _tmpDBElement.ImagesContainer.Fanart

            lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
            lblFanartSize.Visible = True
        End If
    End Sub

    Private Sub btnExtrathumbsSetAsFanart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrathumbsSetAsFanart.Click
        If pbExtrathumbs.Tag IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Fanart = DirectCast(pbExtrathumbs.Tag, MediaContainers.Image)
            pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
            pbFanart.Tag = _tmpDBElement.ImagesContainer.Fanart

            lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
            lblFanartSize.Visible = True
        End If
    End Sub

    Private Sub btnSetExtrafanartsScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetExtrafanartsScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainExtrafanarts, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainFanarts.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.Extrafanarts = dlgImgS.Result.ImagesContainer.Extrafanarts
                    RefreshExtrafanarts()
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(970, "No Fanarts found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetExtrathumbsScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetExtrathumbsScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainExtrathumbs, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainFanarts.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.Extrathumbs = dlgImgS.Result.ImagesContainer.Extrathumbs
                    RefreshExtrathumbs()
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(970, "No Fanarts found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetFanartDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanartDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.Fanart = tImage
                    pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
                    pbFanart.Tag = _tmpDBElement.ImagesContainer.Fanart

                    lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
                    lblFanartSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetFanartScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanartScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainFanart, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainFanarts.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.Fanart = dlgImgS.Result.ImagesContainer.Fanart
                    If _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.LoadFromMemoryStream Then
                        pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
                        lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
                        lblFanartSize.Visible = True
                    Else
                        pbFanart.Image = Nothing
                        pbFanart.Tag = Nothing
                        lblFanartSize.Text = String.Empty
                        lblFanartSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(970, "No Fanarts found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetFanartLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFanartLocal.Click
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.jpg;*.png"
            .FilterIndex = 4
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
            pbFanart.Tag = _tmpDBElement.ImagesContainer.Fanart

            lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
            lblFanartSize.Visible = True
        End If
    End Sub

    Private Sub btnSetLandscapeDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetLandscapeDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.Landscape = tImage
                    pbLandscape.Image = _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.Image
                    pbLandscape.Tag = _tmpDBElement.ImagesContainer.Landscape

                    lblLandscapeSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbLandscape.Image.Width, pbLandscape.Image.Height)
                    lblLandscapeSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetLandscapeScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetLandscapeScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainLandscape, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainLandscapes.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.Landscape = dlgImgS.Result.ImagesContainer.Landscape
                    If _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.LoadFromMemoryStream Then
                        pbLandscape.Image = _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.Image
                        lblLandscapeSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbLandscape.Image.Width, pbLandscape.Image.Height)
                        lblLandscapeSize.Visible = True
                    Else
                        pbLandscape.Image = Nothing
                        pbLandscape.Tag = Nothing
                        lblLandscapeSize.Text = String.Empty
                        lblLandscapeSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(1197, "No Landscapes found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetLandscapeLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetLandscapeLocal.Click
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.jpg;*.png"
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbLandscape.Image = _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.Image
            pbLandscape.Tag = _tmpDBElement.ImagesContainer.Landscape

            lblLandscapeSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbLandscape.Image.Width, pbLandscape.Image.Height)
            lblLandscapeSize.Visible = True
        End If
    End Sub

    Private Sub btnSetPosterDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPosterDL.Click
        Using dImgManual As New dlgImgManual
            Dim tImage As MediaContainers.Image
            If dImgManual.ShowDialog() = DialogResult.OK Then
                tImage = dImgManual.Results
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    _tmpDBElement.ImagesContainer.Poster = tImage
                    pbPoster.Image = _tmpDBElement.ImagesContainer.Poster.ImageOriginal.Image
                    pbPoster.Tag = _tmpDBElement.ImagesContainer.Poster

                    lblPosterSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnSetPosterScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPosterScrape.Click
        Dim aContainer As New MediaContainers.SearchResultsContainer
        Dim ScrapeModifiers As New Structures.ScrapeModifiers

        Cursor = Cursors.WaitCursor
        Functions.SetScrapeModifiers(ScrapeModifiers, Enums.ScrapeModifierType.MainPoster, True)
        If AddonsManager.Instance.ScrapeImage_Movie(_tmpDBElement, aContainer, ScrapeModifiers, True) Then
            If aContainer.MainPosters.Count > 0 Then
                Dim dlgImgS = New dlgImgSelect()
                If dlgImgS.ShowDialog(_tmpDBElement, aContainer, ScrapeModifiers) = DialogResult.OK Then
                    _tmpDBElement.ImagesContainer.Poster = dlgImgS.Result.ImagesContainer.Poster
                    If _tmpDBElement.ImagesContainer.Poster.ImageOriginal.Image IsNot Nothing OrElse _tmpDBElement.ImagesContainer.Poster.ImageOriginal.LoadFromMemoryStream Then
                        pbPoster.Image = _tmpDBElement.ImagesContainer.Poster.ImageOriginal.Image
                        lblPosterSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbPoster.Image.Width, pbPoster.Image.Height)
                        lblPosterSize.Visible = True
                    Else
                        pbPoster.Image = Nothing
                        pbPoster.Tag = Nothing
                        lblPosterSize.Text = String.Empty
                        lblPosterSize.Visible = False
                    End If
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(972, "No Posters found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSetPosterLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPosterLocal.Click
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = Master.eLang.GetString(497, "Images") + "|*.jpg;*.png"
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.ImagesContainer.Poster.ImageOriginal.LoadFromFile(ofdLocalFiles.FileName, True)
            pbPoster.Image = _tmpDBElement.ImagesContainer.Poster.ImageOriginal.Image
            pbPoster.Tag = _tmpDBElement.ImagesContainer.Poster

            lblPosterSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbPoster.Image.Width, pbPoster.Image.Height)
            lblPosterSize.Visible = True
        End If
    End Sub

    'Private Sub btnSetMovieThemeDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetMovieThemeDL.Click
    '    Dim tResults As New MediaContainers.Theme
    '    Dim dlgTheS As dlgThemeSelect
    '    Dim tList As New List(Of Themes)

    '    Try
    '        ThemeStop()
    '        dlgTheS = New dlgThemeSelect()
    '        If dlgTheS.ShowDialog(tmpDBMovie, tList) = Windows.Forms.DialogResult.OK Then
    '            tResults = dlgTheS.Results
    '            MovieTheme = dlgTheS.WebTheme
    '            ThemeAddToPlayer(MovieTheme)
    '        End If
    '    Catch ex As Exception
    '        logger.Error(ex, New StackFrame().GetMethod().Name)
    '    End Try
    'End Sub

    Private Sub btnSetThemeScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetThemeScrape.Click
        Dim dThemeSelect As dlgThemeSelect
        Dim tList As New List(Of MediaContainers.Theme)

        ThemeStop()
        If AddonsManager.Instance.ScrapeTheme_Movie(_tmpDBElement, Enums.ScrapeModifierType.MainTheme, tList) Then
            If tList.Count > 0 Then
                dThemeSelect = New dlgThemeSelect()
                If dThemeSelect.ShowDialog(_tmpDBElement, tList, True) = DialogResult.OK Then
                    _tmpDBElement.Theme = dThemeSelect.Result
                    LoadTheme(_tmpDBElement.Theme)
                End If
            Else
                MessageBox.Show(Master.eLang.GetString(1163, "No Themes found"), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnSetThemeLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetThemeLocal.Click
        ThemeStop()
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = FileUtils.Common.GetOpenFileDialogFilter_Theme()
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.Theme = New MediaContainers.Theme With {.LocalFilePath = ofdLocalFiles.FileName}
            _tmpDBElement.Theme.LoadAndCache()
            LoadTheme(_tmpDBElement.Theme)
        End If
    End Sub

    Private Sub btnSetTrailerDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetTrailerDL.Click
        Dim tResults As New MediaContainers.Trailer
        Dim dlgTrlS As dlgTrailerSelect
        Dim tList As New List(Of MediaContainers.Trailer)

        TrailerStop()
        dlgTrlS = New dlgTrailerSelect()
        If dlgTrlS.ShowDialog(_tmpDBElement, tList, False, True, True) = DialogResult.OK Then
            tResults = dlgTrlS.Result
            _tmpDBElement.Trailer = tResults
            LoadTrailer(_tmpDBElement.Trailer)
        End If
    End Sub

    Private Sub btnSetTrailerScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetTrailerScrape.Click
        Dim dlgTrlS As dlgTrailerSelect
        Dim tList As New List(Of MediaContainers.Trailer)

        TrailerStop()
        dlgTrlS = New dlgTrailerSelect()
        If dlgTrlS.ShowDialog(_tmpDBElement, tList, False, True, True) = DialogResult.OK Then
            _tmpDBElement.Trailer = dlgTrlS.Result
            LoadTrailer(_tmpDBElement.Trailer)
        End If
    End Sub

    Private Sub btnSetTrailerLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetTrailerLocal.Click
        TrailerStop()
        Dim strValidExtesions As String() = Master.eSettings.Options.Filesystem.ValidVideoExts.ToArray
        With ofdLocalFiles
            .InitialDirectory = _tmpDBElement.FileItem.MainPath.FullName
            .Filter = FileUtils.Common.GetOpenFileDialogFilter_Video(Master.eLang.GetString(1195, "Trailers"))
            .FilterIndex = 0
        End With

        If ofdLocalFiles.ShowDialog() = DialogResult.OK Then
            _tmpDBElement.Trailer = New MediaContainers.Trailer With {.LocalFilePath = ofdLocalFiles.FileName}
            _tmpDBElement.Trailer.LoadAndCache()
            LoadTrailer(_tmpDBElement.Trailer)
        End If
    End Sub

    Private Sub btnExtrafanartsRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrafanartsRefresh.Click
        RefreshExtrafanarts()
    End Sub

    Private Sub btnExtrathumbsRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtrathumbsRefresh.Click
        RefreshExtrathumbs()
    End Sub

    Private Sub ThemeStart()
        'If axVLCTheme.playlist.isPlaying Then
        '    axVLCTheme.playlist.togglePause()
        '    btnThemePlay.Text = "Play"
        'Else
        '    axVLCTheme.playlist.play()
        '    btnThemePlay.Text = "Pause"
        'End If
    End Sub

    Private Sub ThemeStop()
        'axVLCTheme.playlist.stop()
        'btnThemePlay.Text = "Play"
    End Sub

    Private Sub LoadTheme(ByVal Theme As MediaContainers.Theme)
        txtLocalTheme.Text =
            If(Theme.LocalFilePathSpecified, Theme.LocalFilePath,
            If(Theme.URLAudioStreamSpecified, Theme.URLAudioStream,
            If(Theme.URLWebsiteSpecified, Theme.URLWebsite, String.Empty)))
    End Sub

    Private Sub LoadTrailer(ByVal Trailer As MediaContainers.Trailer)
        txtLocalTrailer.Text =
            If(Trailer.LocalFilePathSpecified, Trailer.LocalFilePath,
            If(Trailer.URLVideoStreamSpecified, Trailer.URLVideoStream,
            If(Trailer.URLWebsiteSpecified, Trailer.URLWebsite, String.Empty)))
        If AnyTrailerPlayerEnabled Then
            Dim paramsTrailerPreview As New List(Of Object)(New String() {Trailer.URLVideoStream})
            'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.MediaPlayerPlaylistAdd_Video, paramsTrailerPreview, Nothing, True)
        End If
    End Sub

    Private Sub TrailerPlaylistClear()
        If AnyTrailerPlayerEnabled Then
            Dim paramsTrailerPreview As New List(Of Object)
            'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.MediaPlayerPlaylistClear_Video, Nothing, Nothing, True)
        End If
    End Sub

    Private Sub TrailerStop()
        If AnyTrailerPlayerEnabled Then
            Dim paramsTrailerPreview As New List(Of Object)
            'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.MediaPlayerStop_Video, Nothing, Nothing, True)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ThemeStop()
        TrailerStop()
        CleanUp()
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub CleanUp()
        If File.Exists(Path.Combine(Master.TempPath, "frame.jpg")) Then
            File.Delete(Path.Combine(Master.TempPath, "frame.jpg"))
        End If

        If Directory.Exists(Path.Combine(Master.TempPath, "extrathumbs")) Then
            FileUtils.Delete.DeleteDirectory(Path.Combine(Master.TempPath, "extrathumbs"))
        End If

        If Directory.Exists(Path.Combine(Master.TempPath, "extrafanarts")) Then
            FileUtils.Delete.DeleteDirectory(Path.Combine(Master.TempPath, "extrafanarts"))
        End If

        If Directory.Exists(Path.Combine(Master.TempPath, "DashTrailer")) Then
            FileUtils.Delete.DeleteDirectory(Path.Combine(Master.TempPath, "DashTrailer"))
        End If
    End Sub

    Private Sub DelayTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDelay.Tick
        tmrDelay.Stop()
        'GrabTheFrame()
    End Sub

    Private Sub dlgEditMovie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbBanner.AllowDrop = True
        pbClearArt.AllowDrop = True
        pbClearLogo.AllowDrop = True
        pbDiscArt.AllowDrop = True
        pbFanart.AllowDrop = True
        pbLandscape.AllowDrop = True
        pbPoster.AllowDrop = True

        SetUp()
        lvwActorSorter = New ListViewColumnSorter()
        lvActors.ListViewItemSorter = lvwActorSorter
        'lvwExtrathumbsSorter = New ListViewColumnSorter() With {.SortByText = True, .Order = SortOrder.Ascending, .NumericSort = True}
        'lvExtrathumbs.ListViewItemSorter = lvwExtrathumbsSorter
        'lvwExtrafanartsSorter = New ListViewColumnSorter() With {.SortByText = True, .Order = SortOrder.Ascending, .NumericSort = True}
        'lvExtrafanarts.ListViewItemSorter = lvwExtrafanartsSorter

        Dim iBackground As New Bitmap(pnlEditTop.Width, pnlEditTop.Height)
        Using g As Graphics = Graphics.FromImage(iBackground)
            g.FillRectangle(New Drawing2D.LinearGradientBrush(pnlEditTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlEditTop.ClientRectangle)
            pnlEditTop.BackgroundImage = iBackground
        End Using

        Dim dFileInfoEdit As New dlgFileInfo(_tmpDBElement, False)
        dFileInfoEdit.TopLevel = False
        dFileInfoEdit.FormBorderStyle = FormBorderStyle.None
        dFileInfoEdit.BackColor = Color.White
        dFileInfoEdit.btnClose.Visible = False
        pnlFileInfo.Controls.Add(dFileInfoEdit)
        Dim oldwidth As Integer = dFileInfoEdit.Width
        dFileInfoEdit.Width = pnlFileInfo.Width
        dFileInfoEdit.Height = pnlFileInfo.Height
        dFileInfoEdit.Show()

        LoadGenres()
        LoadMovieSets()
        LoadRatings()
        LoadShowLinks()
        LoadTags()

        'Dim paramsFrameExtractor As New List(Of Object)(New Object() {New Panel})
        'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.FrameExtrator_Movie, paramsFrameExtractor, Nothing, True, _tmpDBElement)
        'pnlFrameExtrator.Controls.Add(DirectCast(paramsFrameExtractor(0), Panel))
        'If String.IsNullOrEmpty(pnlFrameExtrator.Controls.Item(0).Name) Then
        '    tcEdit.TabPages.Remove(tpFrameExtraction)
        'End If

        Dim paramsThemePreview As New List(Of Object)(New Object() {New Panel})
        AddonsManager.Instance.RunGeneric(Enums.AddonEventType.MediaPlayer_Audio, paramsThemePreview, Nothing, True)
        pnlThemePreview.Controls.Add(DirectCast(paramsThemePreview(0), Panel))
        If Not String.IsNullOrEmpty(pnlThemePreview.Controls.Item(1).Name) Then
            AnyThemePlayerEnabled = True
            pnlThemePreviewNoPlayer.Visible = False
        End If

        Dim paramsTrailerPreview As New List(Of Object)(New Object() {New Panel})
        AddonsManager.Instance.RunGeneric(Enums.AddonEventType.MediaPlayer_Video, paramsTrailerPreview, Nothing, True)
        pnlTrailerPreview.Controls.Add(DirectCast(paramsTrailerPreview(0), Panel))
        If Not String.IsNullOrEmpty(pnlTrailerPreview.Controls.Item(1).Name) Then
            AnyTrailerPlayerEnabled = True
            pnlTrailerPreviewNoPlayer.Visible = False
        End If

        LoadDetails()
        LoadImages()
        LoadSubtitles()
    End Sub

    Private Sub dlgEditMovie_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Activate()
    End Sub

    Private Sub LoadDetails()
        Select Case _tmpDBElement.ContentType
            Case Enums.ContentType.Movie
                'hide not used controls
                cbEpisodeSorting.Visible = False
                cbOrdering.Visible = False
                lblEpisode.Visible = False
                lblEpisodeSorting.Visible = False
                lblSeason.Visible = False
                lblStatus.Visible = False
                lblTVDB.Visible = False
                tcCrew.TabPages.Remove(tpSpecialGuests)
                txtEpisode.Visible = False
                txtSeason.Visible = False
                txtStatus.Visible = False
                txtTVDB.Visible = False

                txtReleaseDate.Text = _tmpDBElement.MainDetails.ReleaseDate

            Case Enums.ContentType.Movieset
                'hide not used controls
                cbEpisodeSorting.Visible = False
                cbOrdering.Visible = False
                lblEpisode.Visible = False
                lblEpisodeSorting.Visible = False
                lblSeason.Visible = False
                lblStatus.Visible = False
                lblTVDB.Visible = False
                tcCrew.TabPages.Remove(tpSpecialGuests)
                txtEpisode.Visible = False
                txtSeason.Visible = False
                txtStatus.Visible = False
                txtTVDB.Visible = False

            Case Enums.ContentType.TVShow
                'hide not used controls
                btnAdd_Collection.Visible = False
                btnAdd_Trailer.Visible = False
                btnPlay_Trailer.Visible = False
                cbCollection.Visible = False
                clbTVShowLinks.Visible = False
                lblCollection.Visible = False
                lblEpisode.Visible = False
                lblOutline.Visible = False
                lblSeason.Visible = False
                lblTMDBCollection.Visible = False
                lblTVShowLinks.Visible = False
                lblTagline.Visible = False
                lblTop250.Visible = False
                lblTrailerURL.Visible = False
                lblVideoSource.Visible = False
                tcCrew.TabPages.Remove(tpSpecialGuests)
                tcEdit.TabPages.Remove(tpMetaData)
                tcEdit.TabPages.Remove(tpSubtitles)
                tcEdit.TabPages.Remove(tpTrailer)
                txtEpisode.Visible = False
                txtOutline.Visible = False
                txtSeason.Visible = False
                txtTMDBCollection.Visible = False
                txtTagline.Visible = False
                txtTop250.Visible = False
                txtTrailer.Visible = False
                txtVideoSource.Visible = False

                txtReleaseDate.Text = _tmpDBElement.MainDetails.Premiered
        End Select

        If cbLanguage.Items.Count > 0 Then
            Dim tLanguage As languageProperty = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = _tmpDBElement.Language)
            If tLanguage IsNot Nothing Then
                cbLanguage.Text = tLanguage.Description
            Else
                tLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation.StartsWith(_tmpDBElement.Language_Main))
                If tLanguage IsNot Nothing Then
                    cbLanguage.Text = tLanguage.Description
                Else
                    cbLanguage.Text = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = "en-US").Description
                End If
            End If
        End If

        chkLocked.Checked = _tmpDBElement.IsLock
        chkMarked.Checked = _tmpDBElement.IsMark

        If _tmpDBElement.MainDetails.PlayCountSpecified Then
            chkWatched.Checked = True
        Else
            chkWatched.Checked = False
        End If

        cbEpisodeSorting.SelectedIndex = _tmpDBElement.EpisodeSorting
        cbOrdering.SelectedIndex = _tmpDBElement.Ordering
        cbUserRating.Text = _tmpDBElement.MainDetails.UserRating.ToString
        lbCertifications.Items.AddRange(_tmpDBElement.MainDetails.Certifications.ToArray)
        lbCountries.Items.AddRange(_tmpDBElement.MainDetails.Countries.ToArray)
        lbCreditsCreators.Items.AddRange(_tmpDBElement.MainDetails.Credits.ToArray)
        lbDirectors.Items.AddRange(_tmpDBElement.MainDetails.Directors.ToArray)
        lbStudios.Items.AddRange(_tmpDBElement.MainDetails.Studios.ToArray)
        txtIMDB.Text = _tmpDBElement.MainDetails.IMDB
        txtOriginalTitle.Text = _tmpDBElement.MainDetails.OriginalTitle
        txtOutline.Text = _tmpDBElement.MainDetails.Outline
        txtPlot.Text = _tmpDBElement.MainDetails.Plot
        txtRating.Text = _tmpDBElement.MainDetails.Rating
        txtRuntime.Text = _tmpDBElement.MainDetails.Runtime
        txtSortTitle.Text = _tmpDBElement.MainDetails.SortTitle
        txtStatus.Text = _tmpDBElement.MainDetails.Status
        txtTMDB.Text = If(_tmpDBElement.MainDetails.TMDBSpecified, CStr(_tmpDBElement.MainDetails.TMDBSpecified), String.Empty)
        txtTMDBCollection.Text = If(_tmpDBElement.MainDetails.TMDBColIDSpecified, CStr(_tmpDBElement.MainDetails.TMDBColID), String.Empty)
        txtTVDB.Text = If(_tmpDBElement.MainDetails.TVDBSpecified, CStr(_tmpDBElement.MainDetails.TVDB), String.Empty)
        txtTagline.Text = _tmpDBElement.MainDetails.Tagline
        txtTitle.Text = _tmpDBElement.MainDetails.Title
        txtTop250.Text = _tmpDBElement.MainDetails.Top250.ToString
        txtVideoSource.Text = _tmpDBElement.MainDetails.VideoSource
        txtVotes.Text = _tmpDBElement.MainDetails.Votes
        txtYear.Text = _tmpDBElement.MainDetails.Year

        If _tmpDBElement.MainDetails.LastPlayedSpecified Then
            Dim timecode As Double = 0
            Double.TryParse(_tmpDBElement.MainDetails.LastPlayed, timecode)
            If timecode > 0 Then
                txtLastPlayed.Text = Functions.ConvertFromUnixTimestamp(timecode).ToString("yyyy-MM-dd HH:mm:ss")
            Else
                txtLastPlayed.Text = _tmpDBElement.MainDetails.LastPlayed
            End If
        End If

        SelectMPAA()

        If _tmpDBElement.MainDetails.TrailerSpecified Then
            txtTrailer.Text = _tmpDBElement.MainDetails.Trailer
            btnPlay_Trailer.Enabled = True
        Else
            btnPlay_Trailer.Enabled = False
        End If

        btnAdd_Trailer.Enabled = Master.DefaultOptions_Movie.bMainTrailer

        'Presect Genres
        For i As Integer = 0 To clbGenres.Items.Count - 1
            clbGenres.SetItemChecked(i, False)
        Next
        If _tmpDBElement.MainDetails.GenresSpecified Then
            For g As Integer = 0 To _tmpDBElement.MainDetails.Genres.Count - 1
                If clbGenres.FindString(_tmpDBElement.MainDetails.Genres(g).Trim) > 0 Then
                    clbGenres.SetItemChecked(clbGenres.FindString(_tmpDBElement.MainDetails.Genres(g).Trim), True)
                End If
            Next

            If clbGenres.CheckedItems.Count = 0 Then
                clbGenres.SetItemChecked(0, True)
            End If
        Else
            clbGenres.SetItemChecked(0, True)
        End If

        'Presect MovieSet
        If _tmpDBElement.MainDetails.SetsSpecified Then
            cbCollection.SelectedValue = _tmpDBElement.MainDetails.Sets(0)

            If cbCollection.SelectedIndex = -1 Then
                cbCollection.SelectedIndex = 0
            End If
        Else
            cbCollection.SelectedIndex = 0
        End If

        'Presect ShowLinks
        For i As Integer = 0 To clbTVShowLinks.Items.Count - 1
            clbTVShowLinks.SetItemChecked(i, False)
        Next
        If _tmpDBElement.MainDetails.ShowLinksSpecified Then
            For g As Integer = 0 To _tmpDBElement.MainDetails.ShowLinks.Count - 1
                If clbTVShowLinks.FindString(_tmpDBElement.MainDetails.ShowLinks(g).Trim) > 0 Then
                    clbTVShowLinks.SetItemChecked(clbTVShowLinks.FindString(_tmpDBElement.MainDetails.ShowLinks(g).Trim), True)
                End If
            Next

            If clbTVShowLinks.CheckedItems.Count = 0 Then
                clbTVShowLinks.SetItemChecked(0, True)
            End If
        Else
            clbTVShowLinks.SetItemChecked(0, True)
        End If

        'Presect Tags
        For i As Integer = 0 To clbTags.Items.Count - 1
            clbTags.SetItemChecked(i, False)
        Next
        If _tmpDBElement.MainDetails.TagsSpecified Then
            For g As Integer = 0 To _tmpDBElement.MainDetails.Tags.Count - 1
                If clbTags.FindString(_tmpDBElement.MainDetails.Tags(g).Trim) > 0 Then
                    clbTags.SetItemChecked(clbTags.FindString(_tmpDBElement.MainDetails.Tags(g).Trim), True)
                End If
            Next

            If clbTags.CheckedItems.Count = 0 Then
                clbTags.SetItemChecked(0, True)
            End If
        Else
            clbTags.SetItemChecked(0, True)
        End If

        'Actors
        Dim lvActorItem As ListViewItem
        lvActors.Items.Clear()
        For Each nActor As MediaContainers.Person In _tmpDBElement.MainDetails.Actors
            lvActorItem = lvActors.Items.Add(nActor.ID.ToString)
            lvActorItem.Tag = nActor
            lvActorItem.SubItems.Add(nActor.Name)
            lvActorItem.SubItems.Add(nActor.Role)
            lvActorItem.SubItems.Add(nActor.URLOriginal)
        Next

        If _tmpDBElement.FilenameSpecified AndAlso String.IsNullOrEmpty(_tmpDBElement.MainDetails.VideoSource) Then
            Dim vSource As String = APIXML.GetVideoSource(_tmpDBElement.FileItem, False)
            If Not String.IsNullOrEmpty(vSource) Then
                _tmpDBElement.VideoSource = vSource
                _tmpDBElement.MainDetails.VideoSource = _tmpDBElement.VideoSource
            ElseIf String.IsNullOrEmpty(_tmpDBElement.VideoSource) AndAlso clsXMLAdvancedSettings.GetBooleanSetting("MediaSourcesByExtension", False, "*EmberAPP") Then
                _tmpDBElement.VideoSource = clsXMLAdvancedSettings.GetSetting(String.Concat("MediaSourcesByExtension:", Path.GetExtension(_tmpDBElement.FileItem.FirstStackedPath)), String.Empty, "*EmberAPP")
                _tmpDBElement.MainDetails.VideoSource = _tmpDBElement.VideoSource
            ElseIf Not String.IsNullOrEmpty(_tmpDBElement.MainDetails.VideoSource) Then
                _tmpDBElement.VideoSource = _tmpDBElement.MainDetails.VideoSource
            End If
        End If

        If _tmpDBElement.FileItemSpecified AndAlso
            (_tmpDBElement.FileItem.bIsDiscImage OrElse
            _tmpDBElement.FileItem.bIsDiscStub OrElse
            _tmpDBElement.FileItem.bIsRAR OrElse
            Path.GetExtension(_tmpDBElement.FileItem.FirstStackedPath).ToLower = ".cue" OrElse
            Path.GetExtension(_tmpDBElement.FileItem.FirstStackedPath).ToLower = ".dat") Then
            tcEdit.TabPages.Remove(tpFrameExtraction)
        Else
            If Not _tmpDBElement.FileItemSpecified OrElse Not _tmpDBElement.FileItem.bIsDiscStub Then
                tcEdit.TabPages.Remove(tpMediaStub)
            End If
        End If

        'Theme
        If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainTheme) Then
            If Not String.IsNullOrEmpty(_tmpDBElement.Theme.LocalFilePath) OrElse Not String.IsNullOrEmpty(_tmpDBElement.Theme.URLAudioStream) Then
                LoadTheme(_tmpDBElement.Theme)
            End If
        Else
            tcEdit.TabPages.Remove(tpTheme)
        End If

        'Trailer
        If Master.eSettings.Movie.Filenaming.FilenameAnyEnabled_Trailer Then
            If Not String.IsNullOrEmpty(_tmpDBElement.Trailer.LocalFilePath) OrElse Not String.IsNullOrEmpty(_tmpDBElement.Trailer.URLVideoStream) Then
                LoadTrailer(_tmpDBElement.Trailer)
            End If
        Else
            tcEdit.TabPages.Remove(tpTrailer)
        End If

        'DiscStub
        If _tmpDBElement.FileItemSpecified AndAlso _tmpDBElement.FileItem.bIsDiscStub Then
            Dim DiscStub As New MediaStub.DiscStub
            DiscStub = MediaStub.LoadDiscStub(_tmpDBElement.FileItem.FirstStackedPath)
            txtMediaStubTitle.Text = DiscStub.Title
            txtMediaStubMessage.Text = DiscStub.Message
        End If
    End Sub

    Private Sub LoadImages()
        With _tmpDBElement.ImagesContainer

            'Load all images to MemoryStream and Bitmap
            _tmpDBElement.LoadAllImages(True, True)

            'Banner
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainBanner) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainBanner) Then
                    btnSetBannerScrape.Enabled = False
                End If
                If .Banner.ImageOriginal.Image IsNot Nothing Then
                    pbBanner.Image = .Banner.ImageOriginal.Image
                    pbBanner.Tag = .Banner

                    lblBannerSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbBanner.Image.Width, pbBanner.Image.Height)
                    lblBannerSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpBanner)
            End If

            ''CharacterArt
            'If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ModifierType.MainCharacterArt) Then
            '    If Not ModulesManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ModifierType.MainCharacterArt) Then
            '        btnSetCharacterArtScrape.Enabled = False
            '    End If
            '    If .CharacterArt.ImageOriginal.Image IsNot Nothing Then
            '        pbCharacterArt.Image = .CharacterArt.ImageOriginal.Image
            '        pbCharacterArt.Tag = .CharacterArt

            '        lblCharacterArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbCharacterArt.Image.Width, pbCharacterArt.Image.Height)
            '        lblCharacterArtSize.Visible = True
            '    End If
            'Else
            '    tcEdit.TabPages.Remove(tpCharacterArt)
            'End If

            'ClearArt
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainClearArt) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainClearArt) Then
                    btnSetClearArtScrape.Enabled = False
                End If
                If .ClearArt.ImageOriginal.Image IsNot Nothing Then
                    pbClearArt.Image = .ClearArt.ImageOriginal.Image
                    pbClearArt.Tag = .ClearArt

                    lblClearArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearArt.Image.Width, pbClearArt.Image.Height)
                    lblClearArtSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpClearArt)
            End If

            'ClearLogo
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainClearLogo) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainClearLogo) Then
                    btnSetClearLogoScrape.Enabled = False
                End If
                If .ClearLogo.ImageOriginal.Image IsNot Nothing Then
                    pbClearLogo.Image = .ClearLogo.ImageOriginal.Image
                    pbClearLogo.Tag = .ClearLogo

                    lblClearLogoSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearLogo.Image.Width, pbClearLogo.Image.Height)
                    lblClearLogoSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpClearLogo)
            End If

            'DiscArt
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainDiscArt) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainDiscArt) Then
                    btnSetDiscArtScrape.Enabled = False
                End If
                If .DiscArt.ImageOriginal.Image IsNot Nothing Then
                    pbDiscArt.Image = .DiscArt.ImageOriginal.Image
                    pbDiscArt.Tag = .DiscArt

                    lblDiscArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbDiscArt.Image.Width, pbDiscArt.Image.Height)
                    lblDiscArtSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpDiscArt)
            End If

            'Extrafanarts
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainExtrafanarts) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainFanart) Then
                    btnSetFanartScrape.Enabled = False
                End If
                If .Extrafanarts.Count > 0 Then
                    Dim iIndex As Integer = 0
                    For Each tImg As MediaContainers.Image In .Extrafanarts
                        AddExtrafanartImage(String.Concat(tImg.Width, " x ", tImg.Height), iIndex, tImg)
                        iIndex += 1
                    Next
                End If
            Else
                tcEdit.TabPages.Remove(tpExtrafanarts)
            End If

            'Extrathumbs
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainExtrathumbs) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainFanart) Then
                    btnSetFanartScrape.Enabled = False
                End If
                If .Extrathumbs.Count > 0 Then
                    Dim iIndex As Integer = 0
                    For Each tImg As MediaContainers.Image In .Extrathumbs.OrderBy(Function(f) f.Index)
                        AddExtrathumbImage(String.Concat(tImg.Width, " x ", tImg.Height), iIndex, tImg)
                        iIndex += 1
                    Next
                End If
            Else
                tcEdit.TabPages.Remove(tpExtrathumbs)
            End If

            'Fanart
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainFanart) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainFanart) Then
                    btnSetFanartScrape.Enabled = False
                End If
                If .Fanart.ImageOriginal.Image IsNot Nothing Then
                    pbFanart.Image = .Fanart.ImageOriginal.Image
                    pbFanart.Tag = .Fanart

                    lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
                    lblFanartSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpFanart)
            End If

            'Landscape
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainLandscape) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainLandscape) Then
                    btnSetLandscapeScrape.Enabled = False
                End If
                If .Landscape.ImageOriginal.Image IsNot Nothing Then
                    pbLandscape.Image = .Landscape.ImageOriginal.Image
                    pbLandscape.Tag = .Landscape

                    lblLandscapeSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbLandscape.Image.Width, pbLandscape.Image.Height)
                    lblLandscapeSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpLandscape)
            End If

            'Poster
            If Master.eSettings.FilenameAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainPoster) Then
                If Not AddonsManager.Instance.ScraperWithCapabilityAnyEnabled(_tmpDBElement.ContentType, Enums.ScrapeModifierType.MainPoster) Then
                    btnSetPosterScrape.Enabled = False
                End If
                If .Poster.ImageOriginal.Image IsNot Nothing Then
                    pbPoster.Image = .Poster.ImageOriginal.Image
                    pbPoster.Tag = .Poster

                    lblPosterSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbPoster.Image.Width, pbPoster.Image.Height)
                    lblPosterSize.Visible = True
                End If
            Else
                tcEdit.TabPages.Remove(tpPoster)
            End If
        End With
    End Sub

    Private Sub clbGenre_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbGenres.ItemCheck
        If e.Index = 0 Then
            For i As Integer = 1 To clbGenres.Items.Count - 1
                clbGenres.SetItemChecked(i, False)
            Next
        Else
            clbGenres.SetItemChecked(0, False)
        End If
    End Sub

    Private Sub clbTags_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbTags.ItemCheck
        If e.Index = 0 Then
            For i As Integer = 1 To clbTags.Items.Count - 1
                clbTags.SetItemChecked(i, False)
            Next
        Else
            clbTags.SetItemChecked(0, False)
        End If
    End Sub

    Private Sub clbShowLinks_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbTVShowLinks.ItemCheck
        If e.Index = 0 Then
            For i As Integer = 1 To clbTVShowLinks.Items.Count - 1
                clbTVShowLinks.SetItemChecked(i, False)
            Next
        Else
            clbTVShowLinks.SetItemChecked(0, False)
        End If
    End Sub

    Private Sub lbMPAA_DoubleClick(sender As Object, e As EventArgs) Handles lbMPAA.DoubleClick
        If lbMPAA.SelectedItems.Count = 1 Then
            If lbMPAA.SelectedIndex = 0 Then
                txtMPAA.Text = String.Empty
            Else
                txtMPAA.Text = lbMPAA.SelectedItem.ToString
            End If
        End If
    End Sub

    Private Sub lbCertifications_DoubleClick(sender As Object, e As EventArgs) Handles lbCertifications.DoubleClick
        If lbCertifications.SelectedItems.Count = 1 Then
            txtMPAA.Text = lbCertifications.SelectedItem.ToString
        End If
    End Sub

    Private Sub LoadGenres()
        clbGenres.Items.Add(Master.eLang.None)
        clbGenres.Items.AddRange(APIXML.GetGenreList)
    End Sub

    Private Sub LoadMovieSets()
        Dim lstSetDetails = Master.DB.GetAll_MovieSetDetails
        Dim items As New Dictionary(Of String, MediaContainers.SetDetails)
        'add empty MovieSet
        items.Add(Master.eLang.None, New MediaContainers.SetDetails)
        'add scraped MovieSet
        If _tmpDBElement.MainDetails.SetsSpecified Then
            For Each mSet In _tmpDBElement.MainDetails.Sets
                Dim eSetDetail = lstSetDetails.Where(Function(f) f.Title = mSet.Title OrElse
                                                         ((f.TMDBSpecified OrElse mSet.TMDBSpecified) AndAlso f.TMDB = mSet.TMDB))
                If eSetDetail.Count = 0 Then
                    items.Add(mSet.Title, mSet)
                Else
                    items.Add(mSet.Title, mSet)
                    For i As Integer = 0 To eSetDetail.Count - 1
                        lstSetDetails.Remove(eSetDetail(i))
                    Next
                End If
            Next
        End If
        'add existing MovieSets
        For Each nSetDetail In lstSetDetails
            items.Add(nSetDetail.Title, nSetDetail)
        Next
        cbCollection.DataSource = items.ToList
        cbCollection.DisplayMember = "Key"
        cbCollection.ValueMember = "Value"
    End Sub

    Private Sub LoadRatings()
        lbMPAA.Items.Add(Master.eLang.None)
        If Not String.IsNullOrEmpty(Master.eSettings.Movie.DataSettings.MPAANotRatedValue) Then lbMPAA.Items.Add(Master.eSettings.Movie.DataSettings.MPAANotRatedValue)
        lbMPAA.Items.AddRange(APIXML.GetRatingList_Movie)
    End Sub

    Private Sub LoadShowLinks()
        clbTVShowLinks.Items.Add(Master.eLang.None)
        clbTVShowLinks.Items.AddRange(Master.DB.GetAll_TVShowTitles)
    End Sub

    Private Sub LoadTags()
        clbTags.Items.Add(Master.eLang.None)
        clbTags.Items.AddRange(Master.DB.GetAll_Tags)
    End Sub

    Private Sub lvActors_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvActors.ColumnClick, lvSpecialGuests.ColumnClick
        ' Determine if the clicked column is already the column that is
        ' being sorted.

        If (e.Column = lvwActorSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwActorSorter.Order = SortOrder.Ascending) Then
                lvwActorSorter.Order = SortOrder.Descending
            Else
                lvwActorSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwActorSorter.SortColumn = e.Column
            lvwActorSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        lvActors.Sort()
    End Sub

    Private Sub lvActors_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvActors.DoubleClick, lvSpecialGuests.DoubleClick
        ActorEdit()
    End Sub

    Private Sub lvActors_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvActors.KeyDown, lvSpecialGuests.KeyDown
        If e.KeyCode = Keys.Delete Then ActorRemove()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ThemeStop()
        TrailerStop()

        SetInfo()
        CleanUp()

        DialogResult = DialogResult.OK
    End Sub

    Private Sub pbExtrafanartsImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DoSelectExtrafanart(Convert.ToInt32(DirectCast(sender, PictureBox).Name), DirectCast(DirectCast(sender, PictureBox).Tag, MediaContainers.Image))
    End Sub

    Private Sub pbExtrathumbsImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DoSelectExtrathumb(Convert.ToInt32(DirectCast(sender, PictureBox).Name), DirectCast(DirectCast(sender, PictureBox).Tag, MediaContainers.Image))
    End Sub

    Private Sub pnlExtrafanartsImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DoSelectExtrafanart(Convert.ToInt32(DirectCast(sender, Panel).Name), DirectCast(DirectCast(sender, Panel).Tag, MediaContainers.Image))
    End Sub

    Private Sub pnlExtrathumbsImage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DoSelectExtrathumb(Convert.ToInt32(DirectCast(sender, Panel).Name), DirectCast(DirectCast(sender, Panel).Tag, MediaContainers.Image))
    End Sub

    Private Sub pbBanner_DragDrop(sender As Object, e As DragEventArgs) Handles pbBanner.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Banner = tImage
            pbBanner.Image = _tmpDBElement.ImagesContainer.Banner.ImageOriginal.Image
            pbBanner.Tag = _tmpDBElement.ImagesContainer.Banner
            lblBannerSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbBanner.Image.Width, pbBanner.Image.Height)
            lblBannerSize.Visible = True
        End If
    End Sub

    Private Sub pbBanner_DragEnter(sender As Object, e As DragEventArgs) Handles pbBanner.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pbClearArt_DragDrop(sender As Object, e As DragEventArgs) Handles pbClearArt.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.ClearArt = tImage
            pbClearArt.Image = _tmpDBElement.ImagesContainer.ClearArt.ImageOriginal.Image
            pbClearArt.Tag = _tmpDBElement.ImagesContainer.ClearArt
            lblClearArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearArt.Image.Width, pbClearArt.Image.Height)
            lblClearArtSize.Visible = True
        End If
    End Sub

    Private Sub pbClearArt_DragEnter(sender As Object, e As DragEventArgs) Handles pbClearArt.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pbClearLogo_DragDrop(sender As Object, e As DragEventArgs) Handles pbClearLogo.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.ClearLogo = tImage
            pbClearLogo.Image = _tmpDBElement.ImagesContainer.ClearLogo.ImageOriginal.Image
            pbClearLogo.Tag = _tmpDBElement.ImagesContainer.ClearLogo
            lblClearLogoSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbClearLogo.Image.Width, pbClearLogo.Image.Height)
            lblClearLogoSize.Visible = True
        End If
    End Sub

    Private Sub pbClearLogo_DragEnter(sender As Object, e As DragEventArgs) Handles pbClearLogo.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pbDiscArt_DragDrop(sender As Object, e As DragEventArgs) Handles pbDiscArt.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.DiscArt = tImage
            pbDiscArt.Image = _tmpDBElement.ImagesContainer.DiscArt.ImageOriginal.Image
            pbDiscArt.Tag = _tmpDBElement.ImagesContainer.DiscArt
            lblDiscArtSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbDiscArt.Image.Width, pbDiscArt.Image.Height)
            lblDiscArtSize.Visible = True
        End If
    End Sub

    Private Sub pbDiscArt_DragEnter(sender As Object, e As DragEventArgs) Handles pbDiscArt.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pbFanart_DragDrop(sender As Object, e As DragEventArgs) Handles pbFanart.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Fanart = tImage
            pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
            pbFanart.Tag = _tmpDBElement.ImagesContainer.Fanart
            lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
            lblFanartSize.Visible = True
        End If
    End Sub

    Private Sub pbFanart_DragEnter(sender As Object, e As DragEventArgs) Handles pbFanart.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pbLandscape_DragDrop(sender As Object, e As DragEventArgs) Handles pbLandscape.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Landscape = tImage
            pbLandscape.Image = _tmpDBElement.ImagesContainer.Landscape.ImageOriginal.Image
            pbLandscape.Tag = _tmpDBElement.ImagesContainer.Landscape
            lblLandscapeSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbLandscape.Image.Width, pbLandscape.Image.Height)
            lblLandscapeSize.Visible = True
        End If
    End Sub

    Private Sub pbLandscape_DragEnter(sender As Object, e As DragEventArgs) Handles pbLandscape.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pbPoster_DragDrop(sender As Object, e As DragEventArgs) Handles pbPoster.DragDrop
        Dim tImage As MediaContainers.Image = FileUtils.DragAndDrop.GetDoppedImage(e)
        If tImage.ImageOriginal.Image IsNot Nothing Then
            _tmpDBElement.ImagesContainer.Poster = tImage
            pbPoster.Image = _tmpDBElement.ImagesContainer.Poster.ImageOriginal.Image
            pbPoster.Tag = _tmpDBElement.ImagesContainer.Poster
            lblPosterSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbPoster.Image.Width, pbPoster.Image.Height)
            lblPosterSize.Visible = True
        End If
    End Sub

    Private Sub pbPoster_DragEnter(sender As Object, e As DragEventArgs) Handles pbPoster.DragEnter
        If FileUtils.DragAndDrop.CheckDroppedImage(e) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub RefreshExtrafanarts()
        'pnlExtrafanarts.AutoScrollPosition = New Point(0, 0)
        iEFTop = 1
        While pnlExtrafanarts.Controls.Count > 0
            pnlExtrafanarts.Controls(0).Dispose()
        End While

        If _tmpDBElement.ImagesContainer.Extrafanarts.Count > 0 Then
            Dim iIndex As Integer = 0
            For Each img As MediaContainers.Image In _tmpDBElement.ImagesContainer.Extrafanarts
                AddExtrafanartImage(String.Concat(img.Width, " x ", img.Height), iIndex, img)
                iIndex += 1
            Next
        End If
    End Sub

    Private Sub RefreshExtrathumbs()
        'pnlExtrathumbs.AutoScrollPosition = New Point(0, 0)
        iETTop = 1
        While pnlExtrathumbs.Controls.Count > 0
            pnlExtrathumbs.Controls(0).Dispose()
        End While

        If _tmpDBElement.ImagesContainer.Extrathumbs.Count > 0 Then
            _tmpDBElement.ImagesContainer.SortExtrathumbs()
            Dim iIndex As Integer = 0
            For Each img As MediaContainers.Image In _tmpDBElement.ImagesContainer.Extrathumbs.OrderBy(Function(f) f.Index)
                img.Index = iIndex
                AddExtrathumbImage(String.Concat(img.Width, " x ", img.Height), iIndex, img)
                iIndex += 1
            Next
        End If
    End Sub

    Private Sub SelectMPAA()
        If Not String.IsNullOrEmpty(_tmpDBElement.MainDetails.MPAA) Then
            If Master.eSettings.Movie.DataSettings.CertificationsOnlyValue Then
                Dim sItem As String = String.Empty
                For i As Integer = 0 To lbMPAA.Items.Count - 1
                    sItem = lbMPAA.Items(i).ToString
                    If sItem.Contains(":") AndAlso sItem.Split(Convert.ToChar(":"))(1) = _tmpDBElement.MainDetails.MPAA Then
                        lbMPAA.SelectedIndex = i
                        lbMPAA.TopIndex = i
                        Exit For
                    End If
                Next
            Else
                Dim i As Integer = 0
                For ctr As Integer = 0 To lbMPAA.Items.Count - 1
                    If _tmpDBElement.MainDetails.MPAA.ToLower.StartsWith(lbMPAA.Items.Item(ctr).ToString.ToLower) Then
                        i = ctr
                        Exit For
                    End If
                Next
                lbMPAA.SelectedIndex = i
                lbMPAA.TopIndex = i

                Dim strMPAA As String = String.Empty
                Dim strMPAADesc As String = String.Empty
                If i > 0 Then
                    strMPAA = lbMPAA.Items.Item(i).ToString
                    strMPAADesc = _tmpDBElement.MainDetails.MPAA.Replace(strMPAA, String.Empty).Trim
                    txtMPAA.Text = strMPAA
                    txtMPAADesc.Text = strMPAADesc
                Else
                    txtMPAA.Text = _tmpDBElement.MainDetails.MPAA
                End If
            End If
        End If

        If lbMPAA.SelectedItems.Count = 0 Then
            lbMPAA.SelectedIndex = 0
            lbMPAA.TopIndex = 0
        End If
    End Sub

    Private Sub SetInfo()
        btnOK.Enabled = False
        btnCancel.Enabled = False
        btnRescrape.Enabled = False
        btnChange.Enabled = False

        If Not String.IsNullOrEmpty(cbLanguage.Text) Then
            _tmpDBElement.Language = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Description = cbLanguage.Text).Abbreviation
            _tmpDBElement.MainDetails.Language = _tmpDBElement.Language
        Else
            _tmpDBElement.Language = "en-US"
            _tmpDBElement.MainDetails.Language = _tmpDBElement.Language
        End If

        _tmpDBElement.IsMark = chkMarked.Checked

        _tmpDBElement.ListTitle = StringUtils.SortTokens_Movie(txtTitle.Text)
        _tmpDBElement.MainDetails.Certifications = lbCertifications.Items.Cast(Of Object).Select(Function(f) lbCertifications.GetItemText(f)).ToList
        _tmpDBElement.MainDetails.Countries = lbCountries.Items.Cast(Of Object).Select(Function(f) lbCountries.GetItemText(f)).ToList
        _tmpDBElement.MainDetails.Credits = lbCreditsCreators.Items.Cast(Of Object).Select(Function(f) lbCreditsCreators.GetItemText(f)).ToList
        _tmpDBElement.MainDetails.Directors = lbDirectors.Items.Cast(Of Object).Select(Function(f) lbDirectors.GetItemText(f)).ToList
        _tmpDBElement.MainDetails.Studios = lbStudios.Items.Cast(Of Object).Select(Function(f) lbStudios.GetItemText(f)).ToList
        _tmpDBElement.MainDetails.MPAA = String.Concat(txtMPAA.Text, " ", txtMPAADesc.Text).Trim
        _tmpDBElement.MainDetails.OriginalTitle = txtOriginalTitle.Text.Trim
        _tmpDBElement.MainDetails.Outline = txtOutline.Text.Trim
        _tmpDBElement.MainDetails.Plot = txtPlot.Text.Trim
        _tmpDBElement.MainDetails.Rating = txtRating.Text.Trim
        _tmpDBElement.MainDetails.ReleaseDate = txtReleaseDate.Text.Trim
        _tmpDBElement.MainDetails.Runtime = txtRuntime.Text.Trim
        _tmpDBElement.MainDetails.SortTitle = txtSortTitle.Text.Trim
        _tmpDBElement.MainDetails.Tagline = txtTagline.Text.Trim
        _tmpDBElement.MainDetails.Title = txtTitle.Text.Trim
        _tmpDBElement.MainDetails.Top250 = If(Integer.TryParse(txtTop250.Text.Trim, 0), CInt(txtTop250.Text.Trim), 0)
        _tmpDBElement.MainDetails.Trailer = txtTrailer.Text.Trim
        _tmpDBElement.MainDetails.UserRating = If(Integer.TryParse(cbUserRating.Text.Trim, 0), CInt(cbUserRating.Text.Trim), 0)
        _tmpDBElement.MainDetails.VideoSource = txtVideoSource.Text.Trim
        _tmpDBElement.MainDetails.Votes = txtVotes.Text.Trim
        _tmpDBElement.MainDetails.Year = txtYear.Text.Trim
        _tmpDBElement.VideoSource = txtVideoSource.Text.Trim

        'cocotus, 2013/02 Playcount/Watched state support added
        'if watched-checkbox is checked -> save Playcount=1 in nfo
        If chkWatched.Checked Then
            'Only set to 1 if field was empty before (otherwise it would overwrite Playcount everytime which is not desirable)
            If Not _tmpDBElement.MainDetails.PlayCountSpecified Then
                _tmpDBElement.MainDetails.PlayCount = 1
                _tmpDBElement.MainDetails.LastPlayed = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
            End If
        Else
            'Unchecked Watched State -> Set Playcount back to 0, but only if it was filled before (check could save time)
            If _tmpDBElement.MainDetails.PlayCountSpecified Then
                _tmpDBElement.MainDetails.PlayCount = 0
                _tmpDBElement.MainDetails.LastPlayed = String.Empty
            End If
        End If
        'cocotus End

        'Actors
        _tmpDBElement.MainDetails.Actors.Clear()
        If lvActors.Items.Count > 0 Then
            Dim iOrder As Integer = 0
            For Each lviActor As ListViewItem In lvActors.Items
                Dim addActor As MediaContainers.Person = DirectCast(lviActor.Tag, MediaContainers.Person)
                addActor.Order = iOrder
                iOrder += 1
                _tmpDBElement.MainDetails.Actors.Add(addActor)
            Next
        End If

        'Genres
        If clbGenres.CheckedItems.Count = 0 OrElse clbGenres.CheckedIndices.Contains(0) Then
            _tmpDBElement.MainDetails.Genres.Clear()
        Else
            _tmpDBElement.MainDetails.Genres = clbGenres.CheckedItems.Cast(Of Object).Select(Function(f) clbGenres.GetItemText(f)).ToList
        End If

        'MovieSet
        If cbCollection.SelectedIndex <= 0 Then
            _tmpDBElement.MainDetails.Sets.Clear()
        Else
            _tmpDBElement.MainDetails.Sets.Clear()
            _tmpDBElement.MainDetails.Sets.Add(CType(cbCollection.SelectedItem, KeyValuePair(Of String, MediaContainers.SetDetails)).Value)
        End If

        'ShowLinks
        If clbTVShowLinks.CheckedItems.Count = 0 OrElse clbTVShowLinks.CheckedIndices.Contains(0) Then
            _tmpDBElement.MainDetails.ShowLinks.Clear()
        Else
            _tmpDBElement.MainDetails.ShowLinks = clbTVShowLinks.CheckedItems.Cast(Of Object).Select(Function(f) clbTVShowLinks.GetItemText(f)).ToList
        End If

        'Tags
        If clbTags.CheckedItems.Count = 0 OrElse clbTags.CheckedIndices.Contains(0) Then
            _tmpDBElement.MainDetails.Tags.Clear()
        Else
            _tmpDBElement.MainDetails.Tags = clbTags.CheckedItems.Cast(Of Object).Select(Function(f) clbTags.GetItemText(f)).ToList
        End If

        If _tmpDBElement.FileItemSpecified AndAlso _tmpDBElement.FileItem.bIsDiscStub Then
            Dim StubFile As String = _tmpDBElement.FileItem.FirstStackedPath
            Dim Title As String = txtMediaStubTitle.Text
            Dim Message As String = txtMediaStubMessage.Text
            MediaStub.SaveDiscStub(StubFile, Title, Message)
        End If

        Select Case _tmpDBElement.ContentType
            Case Enums.ContentType.Movie
                If Not Master.eSettings.Movie.ImageSettings.ImagesNotSaveURLToNfo AndAlso pResults.Posters.Count > 0 Then _tmpDBElement.MainDetails.Thumb = pResults.Posters
                If Not Master.eSettings.Movie.ImageSettings.ImagesNotSaveURLToNfo AndAlso fResults.Fanart.Thumb.Count > 0 Then _tmpDBElement.MainDetails.Fanart = pResults.Fanart
            Case Enums.ContentType.TVShow
                If Not Master.eSettings.TV.ImageSettings.ImagesNotSaveURLToNfo AndAlso pResults.Posters.Count > 0 Then _tmpDBElement.MainDetails.Thumb = pResults.Posters
                If Not Master.eSettings.TV.ImageSettings.ImagesNotSaveURLToNfo AndAlso fResults.Fanart.Thumb.Count > 0 Then _tmpDBElement.MainDetails.Fanart = pResults.Fanart
        End Select

        Dim removeSubtitles As New List(Of MediaContainers.Subtitle)
        For Each Subtitle In _tmpDBElement.Subtitles
            If Subtitle.toRemove Then
                removeSubtitles.Add(Subtitle)
            End If
        Next
        For Each Subtitle In removeSubtitles
            If File.Exists(Subtitle.SubsPath) Then
                File.Delete(Subtitle.SubsPath)
            End If
            _tmpDBElement.Subtitles.Remove(Subtitle)
        Next
    End Sub

    Private Sub SetUp()
        lblMPAAPreview.Text = String.Empty

        'Download
        Dim strDownload As String = Master.eLang.GetString(373, "Download")
        btnSetBannerDL.Text = strDownload
        btnSetClearArtDL.Text = strDownload
        btnSetClearLogoDL.Text = strDownload
        btnSetDiscArtDL.Text = strDownload
        btnSetFanartDL.Text = strDownload
        btnSetLandscapeDL.Text = strDownload
        btnSetPosterDL.Text = strDownload
        btnSetSubtitleDL.Text = strDownload
        btnSetThemeDL.Text = strDownload
        btnSetTrailerDL.Text = strDownload

        'Loacal Browse
        Dim strLocalBrowse As String = Master.eLang.GetString(78, "Local Browse")
        btnSetBannerLocal.Text = strLocalBrowse
        btnSetClearArtLocal.Text = strLocalBrowse
        btnSetClearLogoLocal.Text = strLocalBrowse
        btnSetDiscArtLocal.Text = strLocalBrowse
        btnSetFanartLocal.Text = strLocalBrowse
        btnSetLandscapeLocal.Text = strLocalBrowse
        btnSetPosterLocal.Text = strLocalBrowse
        btnSetSubtitleLocal.Text = strLocalBrowse
        btnSetThemeLocal.Text = strLocalBrowse
        btnSetTrailerLocal.Text = strLocalBrowse

        'Remove
        Dim strRemove As String = Master.eLang.GetString(30, "Remove")
        btnRemoveBanner.Text = strRemove
        btnRemoveClearArt.Text = strRemove
        btnRemoveClearLogo.Text = strRemove
        btnRemoveDiscArt.Text = strRemove
        btnRemoveFanart.Text = strRemove
        btnRemoveLandscape.Text = strRemove
        btnRemovePoster.Text = strRemove
        btnRemoveSubtitle.Text = strRemove
        btnRemoveTheme.Text = strRemove
        btnRemoveTrailer.Text = strRemove

        'Scrape
        Dim strScrape As String = Master.eLang.GetString(79, "Scrape")
        btnSetBannerScrape.Text = strScrape
        btnSetClearArtScrape.Text = strScrape
        btnSetClearLogoScrape.Text = strScrape
        btnSetDiscArtScrape.Text = strScrape
        btnSetFanartScrape.Text = strScrape
        btnSetLandscapeScrape.Text = strScrape
        btnSetPosterScrape.Text = strScrape
        btnSetSubtitleScrape.Text = strScrape
        btnSetThemeScrape.Text = strScrape
        btnSetTrailerScrape.Text = strScrape

        Dim strTitle As String = _tmpDBElement.MainDetails.Title
        Select Case _tmpDBElement.ContentType
            Case Enums.ContentType.Movie
                Text = String.Concat(Master.eLang.GetString(25, "Edit Movie"), If(String.IsNullOrEmpty(strTitle), String.Empty, String.Concat(" - ", strTitle)))
                tsFilename.Text = _tmpDBElement.FileItem.FullPath
            Case Enums.ContentType.Movieset
                Text = String.Concat(Master.eLang.GetString(207, "Edit MovieSet"), If(String.IsNullOrEmpty(strTitle), String.Empty, String.Concat(" - ", strTitle)))
                tsFilename.Text = String.Empty
            Case Enums.ContentType.TVEpisode
                Text = String.Concat(Master.eLang.GetString(769, "Edit Season"), If(String.IsNullOrEmpty(strTitle), String.Empty, String.Concat(" - ", strTitle)))
                tsFilename.Text = String.Empty
            Case Enums.ContentType.TVSeason, Enums.ContentType.TVShow
                Text = String.Concat(Master.eLang.GetString(663, "Edit Show"), If(String.IsNullOrEmpty(strTitle), String.Empty, String.Concat(" - ", strTitle)))
                tsFilename.Text = _tmpDBElement.ShowPath
        End Select
        btnCancel.Text = Master.eLang.GetString(167, "Cancel")
        btnOK.Text = Master.eLang.GetString(179, "OK")
        btnChange.Text = Master.eLang.GetString(32, "Change Movie")
        btnExtrafanartsSetAsFanart.Text = btnExtrathumbsSetAsFanart.Text
        btnExtrathumbsSetAsFanart.Text = Master.eLang.GetString(255, "Set As Fanart")
        btnRescrape.Text = Master.eLang.GetString(716, "Re-Scrape")
        chkMarked.Text = Master.eLang.GetString(48, "Marked")
        chkWatched.Text = Master.eLang.GetString(981, "Watched")
        colName.Text = Master.eLang.GetString(232, "Name")
        colRole.Text = Master.eLang.GetString(233, "Role")
        colThumb.Text = Master.eLang.GetString(234, "Thumb")
        tpActors.Text = String.Concat(Master.eLang.GetString(231, "Actors"), ":")
        lblCertifications.Text = String.Concat(Master.eLang.GetString(56, "Certifications"), ":")
        lblCountries.Text = String.Concat(Master.eLang.GetString(237, "Countries"), ":")
        lblCreditsCreators.Text = Master.eLang.GetString(228, "Credits:")
        lblDirectors.Text = String.Concat(Master.eLang.GetString(940, "Directors"), ":")
        lblVideoSource.Text = String.Concat(Master.eLang.GetString(824, "Video Source"), ":")
        lblGenres.Text = Master.eLang.GetString(51, "Genre(s):")
        lblLanguage.Text = Master.eLang.GetString(610, "Language")
        lblMPAARating.Text = Master.eLang.GetString(235, "MPAA Rating:")
        lblMPAADescription.Text = String.Concat(Master.eLang.GetString(979, "Description"), ":")
        lblOriginalTitle.Text = String.Concat(Master.eLang.GetString(302, "Original Title"), ":")
        lblOutline.Text = Master.eLang.GetString(242, "Plot Outline:")
        lblPlot.Text = Master.eLang.GetString(241, "Plot:")
        lblRating.Text = Master.eLang.GetString(245, "Rating:")
        lblReleaseDate.Text = Master.eLang.GetString(236, "Release Date:")
        lblRuntime.Text = Master.eLang.GetString(238, "Runtime:")
        lblSortTilte.Text = String.Concat(Master.eLang.GetString(642, "Sort Title"), ":")
        lblStudio.Text = String.Concat(Master.eLang.GetString(395, "Studio"), ":")
        lblTagline.Text = Master.eLang.GetString(243, "Tagline:")
        lblTitle.Text = Master.eLang.GetString(246, "Title:")
        lblTop250.Text = Master.eLang.GetString(240, "Top 250:")
        lblTopDetails.Text = Master.eLang.GetString(224, "Edit the details for the selected movie.")
        lblTopTitle.Text = Master.eLang.GetString(25, "Edit Movie")
        lblTrailerURL.Text = String.Concat(Master.eLang.GetString(227, "Trailer URL"), ":")
        lblVotes.Text = Master.eLang.GetString(244, "Votes:")
        lblYear.Text = Master.eLang.GetString(49, "Year:")
        tpBanner.Text = Master.eLang.GetString(838, "Banner")
        tpClearArt.Text = Master.eLang.GetString(1096, "ClearArt")
        tpClearLogo.Text = Master.eLang.GetString(1097, "ClearLogo")
        tpDetails.Text = Master.eLang.GetString(1098, "DiscArt")
        tpDetails.Text = Master.eLang.GetString(26, "Details")
        tpExtrafanarts.Text = Master.eLang.GetString(992, "Extrafanarts")
        tpExtrathumbs.Text = Master.eLang.GetString(153, "Extrathumbs")
        tpFanart.Text = Master.eLang.GetString(149, "Fanart")
        tpFrameExtraction.Text = Master.eLang.GetString(256, "Frame Extraction")
        tpLandscape.Text = Master.eLang.GetString(1059, "Landscape")
        tpMetaData.Text = Master.eLang.GetString(866, "Metadata")
        tpPoster.Text = Master.eLang.GetString(148, "Poster")

        cbEpisodeSorting.Items.Clear()
        cbEpisodeSorting.Items.AddRange(New String() {Master.eLang.GetString(755, "Episode #"), Master.eLang.GetString(728, "Aired")})

        cbLanguage.Items.Clear()
        cbLanguage.Items.AddRange((From lLang In APIXML.ScraperLanguagesXML.Languages Select lLang.Description).ToArray)

        cbOrdering.Items.Clear()
        cbOrdering.Items.AddRange(New String() {Master.eLang.GetString(438, "Standard"), Master.eLang.GetString(1067, "DVD"), Master.eLang.GetString(839, "Absolute"), Master.eLang.GetString(1332, "Day Of Year")})
    End Sub

    Private Sub tcEditMovie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcEdit.SelectedIndexChanged
        lvSubtitles.SelectedItems.Clear()
        ThemeStop()
        TrailerStop()
    End Sub

    Private Sub txtTop250_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = StringUtils.NumericOnly(e.KeyChar)
    End Sub

    Private Sub txtTrailer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrailer.TextChanged
        If StringUtils.isValidURL(txtTrailer.Text) Then
            btnPlay_Trailer.Enabled = True
        Else
            btnPlay_Trailer.Enabled = False
        End If
    End Sub

    Sub GenericRunCallBack(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object))
        'If mType = Enums.AddonEventType.FrameExtrator_Movie AndAlso _params IsNot Nothing Then
        '    If _params(0).ToString = "FanartToSave" Then
        '        _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.LoadFromFile(Path.Combine(Master.TempPath, "frame.jpg"), True)
        '        If _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image IsNot Nothing Then
        '            pbFanart.Image = _tmpDBElement.ImagesContainer.Fanart.ImageOriginal.Image
        '            pbFanart.Tag = _tmpDBElement.ImagesContainer.Fanart

        '            lblFanartSize.Text = String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), pbFanart.Image.Width, pbFanart.Image.Height)
        '            lblFanartSize.Visible = True
        '        End If
        '    ElseIf _params(0).ToString = "ExtrafanartToSave" Then
        '        Dim fPath As String = _params(1).ToString
        '        If Not String.IsNullOrEmpty(fPath) AndAlso File.Exists(fPath) Then
        '            Dim eImg As New MediaContainers.Image
        '            eImg.ImageOriginal.LoadFromFile(fPath, True)
        '            _tmpDBElement.ImagesContainer.Extrafanarts.Add(eImg)
        '            RefreshExtrafanarts()
        '        End If
        '    ElseIf _params(0).ToString = "ExtrathumbToSave" Then
        '        Dim fPath As String = _params(1).ToString
        '        If Not String.IsNullOrEmpty(fPath) AndAlso File.Exists(fPath) Then
        '            Dim eImg As New MediaContainers.Image
        '            eImg.ImageOriginal.LoadFromFile(fPath, True)
        '            _tmpDBElement.ImagesContainer.Extrathumbs.Add(eImg)
        '            RefreshExtrathumbs()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub txtOutline_KeyDown(ByVal sender As Object, e As KeyEventArgs) Handles txtOutline.KeyDown
        If e.KeyData = (Keys.Control Or Keys.A) Then
            txtOutline.SelectAll()
        End If
    End Sub

    Private Sub txtPlot_KeyDown(ByVal sender As Object, e As KeyEventArgs) Handles txtPlot.KeyDown
        If e.KeyData = (Keys.Control Or Keys.A) Then
            txtPlot.SelectAll()
        End If
    End Sub

    Private Sub lvSubtitles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvSubtitles.KeyDown
        If e.KeyCode = Keys.Delete Then DeleteSubtitle()
    End Sub

    Private Sub lvSubtitles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSubtitles.DoubleClick
        If lvSubtitles.SelectedItems.Count > 0 Then
            If lvSubtitles.SelectedItems.Item(0).Tag.ToString <> "Header" Then
                EditSubtitle()
            End If
        End If
    End Sub

    Private Sub lvSubtitles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSubtitles.SelectedIndexChanged
        If lvSubtitles.SelectedItems.Count > 0 Then
            If lvSubtitles.SelectedItems.Item(0).Tag.ToString = "Header" Then
                lvSubtitles.SelectedItems.Clear()
                btnRemoveSubtitle.Enabled = False
                txtSubtitlesPreview.Clear()
            Else
                btnRemoveSubtitle.Enabled = True
                txtSubtitlesPreview.Text = ReadSubtitle(lvSubtitles.SelectedItems.Item(0).SubItems(1).Text.ToString)
            End If
        Else
            btnRemoveSubtitle.Enabled = False
            txtSubtitlesPreview.Clear()
        End If
    End Sub

    Private Function ReadSubtitle(ByVal sPath As String) As String
        Dim sText As String = String.Empty

        If Not String.IsNullOrEmpty(sPath) AndAlso File.Exists(sPath) Then
            Dim objReader As New StreamReader(sPath)

            sText = objReader.ReadToEnd

            objReader.Close()

            Return sText
        End If

        Return String.Empty
    End Function

    Private Sub EditSubtitle()
        If lvSubtitles.SelectedItems.Count > 0 Then
            Dim i As ListViewItem = lvSubtitles.SelectedItems(0)
            Dim tmpFileInfo As New MediaContainers.Fileinfo
            tmpFileInfo.StreamDetails.Subtitle.AddRange(_tmpDBElement.Subtitles)
            Using dEditStream As New dlgFIStreamEditor
                Dim stream As Object = dEditStream.ShowDialog(i.Tag.ToString, tmpFileInfo, Convert.ToInt16(i.Text))
                If Not stream Is Nothing Then
                    If i.Tag.ToString = Master.eLang.GetString(597, "Subtitle Stream") Then
                        _tmpDBElement.Subtitles(Convert.ToInt16(i.Text)) = DirectCast(stream, MediaContainers.Subtitle)
                    End If
                    'NeedToRefresh = True
                    LoadSubtitles()
                End If
            End Using
        End If
    End Sub

    Private Sub DeleteSubtitle()
        If lvSubtitles.SelectedItems.Count > 0 Then
            Dim i As ListViewItem = lvSubtitles.SelectedItems(0)
            If i.Tag.ToString = Master.eLang.GetString(597, "Subtitle Stream") Then
                _tmpDBElement.Subtitles(Convert.ToInt16(i.Text)).toRemove = True
            End If
            'NeedToRefresh = True
            LoadSubtitles()
        End If
    End Sub

    Private Sub LoadSubtitles()
        Dim c As Integer
        Dim g As New ListViewGroup
        Dim i As New ListViewItem
        lvSubtitles.Groups.Clear()
        lvSubtitles.Items.Clear()

        If _tmpDBElement.Subtitles.Count > 0 Then
            g = New ListViewGroup
            g.Header = Master.eLang.GetString(597, "Subtitle Stream")
            lvSubtitles.Groups.Add(g)
            c = 1
            ' Fake Group Header
            i = New ListViewItem
            'i.UseItemStyleForSubItems = False
            i.ForeColor = Color.DarkBlue
            i.Tag = "Header"
            i.Text = String.Empty
            i.SubItems.Add(Master.eLang.GetString(60, "File Path"))
            i.SubItems.Add(Master.eLang.GetString(610, "Language"))
            i.SubItems.Add(Master.eLang.GetString(1288, "Type"))
            i.SubItems.Add(Master.eLang.GetString(1287, "Forced"))

            g.Items.Add(i)
            lvSubtitles.Items.Add(i)
            Dim s As MediaContainers.Subtitle
            For c = 0 To _tmpDBElement.Subtitles.Count - 1
                s = _tmpDBElement.Subtitles(c)
                If Not s Is Nothing Then
                    i = New ListViewItem
                    i.Tag = Master.eLang.GetString(597, "Subtitle Stream")
                    i.Text = c.ToString
                    i.SubItems.Add(s.SubsPath)
                    i.SubItems.Add(s.LongLanguage)
                    i.SubItems.Add(s.SubsType)
                    i.SubItems.Add(If(s.SubsForced, Master.eLang.GetString(300, "Yes"), Master.eLang.GetString(720, "No")))

                    If s.toRemove Then
                        i.ForeColor = Color.Red
                    End If

                    g.Items.Add(i)
                    lvSubtitles.Items.Add(i)
                End If
            Next
        End If
    End Sub

    Private Sub btnLocalThemePlay_Click(sender As Object, e As EventArgs) Handles btnLocalThemePlay.Click
        Try
            Dim tPath As String = String.Empty

            If Not String.IsNullOrEmpty(txtLocalTheme.Text) Then
                tPath = String.Concat("""", txtLocalTheme.Text, """")
            End If

            If Not String.IsNullOrEmpty(tPath) Then
                If Master.isWindows Then
                    Process.Start(tPath)
                Else
                    Using Explorer As New Process
                        Explorer.StartInfo.FileName = "xdg-open"
                        Explorer.StartInfo.Arguments = tPath
                        Explorer.Start()
                    End Using
                End If
            End If
        Catch
            MessageBox.Show(Master.eLang.GetString(270, "The trailer could not be played. This could be due to an invalid URI or you do not have the proper player to play the trailer type."), Master.eLang.GetString(271, "Error Playing Trailer"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnLocalTrailerPlay_Click(sender As Object, e As EventArgs) Handles btnLocalTrailerPlay.Click
        Try
            Dim tPath As String = String.Empty

            If Not String.IsNullOrEmpty(txtLocalTrailer.Text) Then
                tPath = String.Concat("""", txtLocalTrailer.Text, """")
            End If

            If Not String.IsNullOrEmpty(tPath) Then
                If Master.isWindows Then
                    Process.Start(tPath)
                Else
                    Using Explorer As New Process
                        Explorer.StartInfo.FileName = "xdg-open"
                        Explorer.StartInfo.Arguments = tPath
                        Explorer.Start()
                    End Using
                End If
            End If
        Catch
            MessageBox.Show(Master.eLang.GetString(270, "The trailer could not be played. This could be due to an invalid URI or you do not have the proper player to play the trailer type."), Master.eLang.GetString(271, "Error Playing Trailer"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub txtLocalTheme_TextChanged(sender As Object, e As EventArgs) Handles txtLocalTheme.TextChanged
        btnLocalThemePlay.Enabled = Not String.IsNullOrEmpty(txtLocalTheme.Text)
    End Sub

    Private Sub txtLocalTrailer_TextChanged(sender As Object, e As EventArgs) Handles txtLocalTrailer.TextChanged
        btnLocalTrailerPlay.Enabled = Not String.IsNullOrEmpty(txtLocalTrailer.Text)
    End Sub

    Private Sub CreateMPAAPreview(sender As Object, e As EventArgs) Handles txtMPAA.TextChanged, txtMPAADesc.TextChanged
        lblMPAAPreview.Text = String.Format("{0} {1}", txtMPAA.Text, txtMPAADesc.Text).Trim
    End Sub

#End Region 'Methods

#Region "Nested Types"

#End Region 'Nested Types

End Class