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
' # HD Movie Logos -> logo.png (choose this first)
' # ClearLOGOs -> logo.png (use this as a backup if no HD Logo in the lanaguage specified)
' # ClearART -> clearart.png (use this as a backup if no HD ClearArt, in the language specified)
' # HDClearART -> clearart.png (choose this first)
' # cdART -> disc.png
' # Movie Backgrounds -> Fanart (this is the only fanart.tv artwork that might overlap with 'typical' artwork scraping from IMDB/TMDB)
' # Movie Banner -> Banner (not poster - Frodo supports both now, <moviename>-poster.jpg/png and <moviename>-banner.jpg/png or poster.jpg/png and banner.jpg/png)
' # Movie Thumbs -> landscape.png
' # Special note - the Logos and ClearArts are language-specific and should be tagged with the appropriate language. Will want to have a setting allowing users to specify a language so as not to get a bunch of foreign-language artwork.
' # 1) Logo.png - to be added at a later stage, today is not possible to save
' # 2) Clearart.png - to be added at a later stage, today is not possible to save
' # 3) Disc.png - to be added at a later stage, today is not possible to save
' # 4) Landscape.png - to be added at a later stage, today is not possible to save
' # language is in image properties

Imports EmberAPI
Imports NLog
Imports System.Diagnostics

Public Class Scraper

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _AddonSettings As FanartTV.AddonSettings

#End Region 'Fields

#Region "Methods"

    Public Sub New(ByVal SpecialSettings As FanartTV.AddonSettings)
        Try
            _AddonSettings = SpecialSettings

            Global.FanartTv.API.Key = "ea68f9d0847c1b7643813c70cbfc0196"
            Global.FanartTv.API.cKey = SpecialSettings.APIKey

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Function GetImages_Movie_MovieSet(ByVal strTMDB_IMDB As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers) As MediaContainers.SearchResultsContainer
        Dim nImagesContainer As New MediaContainers.SearchResultsContainer

        Try
            Dim Results = New Global.FanartTv.Movies.Movie(strTMDB_IMDB)
            If Results Is Nothing OrElse Global.FanartTv.API.ErrorOccurred Then
                If Global.FanartTv.API.ErrorMessage IsNot Nothing Then
                    logger.Error(Global.FanartTv.API.ErrorMessage)
                End If
                Return Nothing
            End If

            'Banner
            If tScrapeModifiers.MainBanner AndAlso Results.List.Moviebanner IsNot Nothing Then
                For Each image In Results.List.Moviebanner
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "185",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.MainBanners.Add(tmpPoster)
                Next
            End If

            'ClearArt
            If tScrapeModifiers.MainClearArt Then
                If Results.List.Hdmovieclearart IsNot Nothing Then
                    For Each image In Results.List.Hdmovieclearart
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "562",
                                .Likes = CInt(image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = image.Lang,
                                .URLOriginal = image.Url,
                                .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "1000"}

                        nImagesContainer.MainClearArts.Add(tmpPoster)
                    Next
                End If
                If Results.List.Movieart IsNot Nothing Then
                    For Each image In Results.List.Movieart
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "281",
                                .Likes = CInt(image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = image.Lang,
                                .URLOriginal = image.Url,
                                .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "500"}

                        nImagesContainer.MainClearArts.Add(tmpPoster)
                    Next
                End If
            End If

            'ClearLogo
            If tScrapeModifiers.MainClearLogo Then
                If Results.List.Hdmovielogo IsNot Nothing Then
                    For Each image In Results.List.Hdmovielogo
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "310",
                                .Likes = CInt(image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = image.Lang,
                                .URLOriginal = image.Url,
                                .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "800"}

                        nImagesContainer.MainClearLogos.Add(tmpPoster)
                    Next
                End If
                If Results.List.Movielogo IsNot Nothing Then
                    For Each image In Results.List.Movielogo
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "155",
                                .Likes = CInt(image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = image.Lang,
                                .URLOriginal = image.Url,
                                .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "400"}

                        nImagesContainer.MainClearLogos.Add(tmpPoster)
                    Next
                End If
            End If

            'DiscArt
            If tScrapeModifiers.MainDiscArt AndAlso Results.List.Moviedisc IsNot Nothing Then
                For Each image In Results.List.Moviedisc
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Disc = CInt(image.Disc),
                            .DiscType = image.DiscType,
                            .Height = "1000",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.MainDiscArts.Add(tmpPoster)
                Next
            End If

            'Fanart
            If (tScrapeModifiers.MainExtrafanarts OrElse tScrapeModifiers.MainExtrathumbs OrElse tScrapeModifiers.MainFanart) AndAlso Results.List.Moviebackground IsNot Nothing Then
                For Each image In Results.List.Moviebackground
                    nImagesContainer.MainFanarts.Add(New MediaContainers.Image With {.URLOriginal = image.Url, .URLThumb = image.Url.Replace("/fanart/", "/preview/"), .Width = "1920", .Height = "1080", .Scraper = "Fanart.tv", .ShortLang = image.Lang, .LongLang = If(String.IsNullOrEmpty(image.Lang), "", Localization.ISOGetLangByCode2(image.Lang)), .Likes = CInt(image.Likes)})
                Next
            End If

            'Landscape
            If tScrapeModifiers.MainLandscape AndAlso Results.List.Moviethumb IsNot Nothing Then
                For Each image In Results.List.Moviethumb
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "562",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.MainLandscapes.Add(tmpPoster)
                Next
            End If

            'Poster
            If tScrapeModifiers.MainPoster AndAlso Results.List.Movieposter IsNot Nothing Then
                For Each image In Results.List.Movieposter
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "1426",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.MainPosters.Add(tmpPoster)
                Next
            End If

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        Return nImagesContainer
    End Function

    Public Function GetImages_TV(ByVal strTVDB As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers) As MediaContainers.SearchResultsContainer
        Dim nImagesContainer As New MediaContainers.SearchResultsContainer

        Try
            Dim Results = New Global.FanartTv.TV.Show(strTVDB)
            If Results Is Nothing OrElse Global.FanartTv.API.ErrorOccurred Then
                If Global.FanartTv.API.ErrorMessage IsNot Nothing Then
                    logger.Error(Global.FanartTv.API.ErrorMessage)
                End If
                Return Nothing
            End If

            'MainBanner
            If tScrapeModifiers.MainBanner AndAlso Results.List.Tvbanner IsNot Nothing Then
                For Each image In Results.List.Tvbanner
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "185",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .TVBannerType = Enums.TVBannerType.Any,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.MainBanners.Add(tmpPoster)
                Next
            End If

            'MainCharacterArt
            If tScrapeModifiers.MainCharacterArt AndAlso Results.List.Characterart IsNot Nothing Then
                For Each image In Results.List.Characterart
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "512",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "512"}

                    nImagesContainer.MainCharacterArts.Add(tmpPoster)
                Next
            End If

            'MainClearArt
            If tScrapeModifiers.MainClearArt Then
                If Results.List.Hdclearart IsNot Nothing Then
                    For Each image In Results.List.Hdclearart
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "562",
                                .Likes = CInt(image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = image.Lang,
                                .URLOriginal = image.Url,
                                .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "1000"}

                        nImagesContainer.MainClearArts.Add(tmpPoster)
                    Next
                End If
                If Results.List.Clearart IsNot Nothing Then
                    For Each image In Results.List.Clearart
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "281",
                                .Likes = CInt(image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = image.Lang,
                                .URLOriginal = image.Url,
                                .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "500"}

                        nImagesContainer.MainClearArts.Add(tmpPoster)
                    Next
                End If
            End If

            'MainClearLogo
            If tScrapeModifiers.MainClearLogo Then
                If Results.List.HdTListvlogo IsNot Nothing Then
                    For Each Image In Results.List.HdTListvlogo
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "310",
                                .Likes = CInt(Image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(Image.Lang), String.Empty, Localization.ISOGetLangByCode2(Image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = Image.Lang,
                                .URLOriginal = Image.Url,
                                .URLThumb = Image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "800"}

                        nImagesContainer.MainClearLogos.Add(tmpPoster)
                    Next
                End If
                If Results.List.Clearlogo IsNot Nothing Then
                    For Each Image In Results.List.Clearlogo
                        Dim tmpPoster As New MediaContainers.Image With {
                                .Height = "155",
                                .Likes = CInt(Image.Likes),
                                .LongLang = If(String.IsNullOrEmpty(Image.Lang), String.Empty, Localization.ISOGetLangByCode2(Image.Lang)),
                                .Scraper = "Fanart.tv",
                                .ShortLang = Image.Lang,
                                .URLOriginal = Image.Url,
                                .URLThumb = Image.Url.Replace("/fanart/", "/preview/"),
                                .Width = "400"}

                        nImagesContainer.MainClearLogos.Add(tmpPoster)
                    Next
                End If
            End If

            'MainFanart
            If tScrapeModifiers.MainFanart AndAlso Results.List.Showbackground IsNot Nothing Then
                For Each image In Results.List.Showbackground
                    nImagesContainer.MainFanarts.Add(New MediaContainers.Image With {.URLOriginal = image.Url, .Width = "1920", .Height = "1080", .URLThumb = image.Url.Replace("/fanart/", "/preview/"), .Scraper = "Fanart.tv", .ShortLang = image.Lang, .LongLang = If(String.IsNullOrEmpty(image.Lang), "", Localization.ISOGetLangByCode2(image.Lang)), .Likes = CInt(image.Likes)})
                Next
            End If

            'MainLandscape
            If tScrapeModifiers.MainLandscape AndAlso Results.List.Tvthumb IsNot Nothing Then
                For Each Image In Results.List.Tvthumb
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "281",
                            .Likes = CInt(Image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(Image.Lang), String.Empty, Localization.ISOGetLangByCode2(Image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = Image.Lang,
                            .URLOriginal = Image.Url,
                            .URLThumb = Image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "500"}

                    nImagesContainer.MainLandscapes.Add(tmpPoster)
                Next
            End If

            'MainPoster
            If tScrapeModifiers.MainPoster AndAlso Results.List.Tvposter IsNot Nothing Then
                For Each image In Results.List.Tvposter
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "1426",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .ShortLang = image.Lang,
                            .TVBannerType = Enums.TVBannerType.Any,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.MainPosters.Add(tmpPoster)
                Next
            End If

            'SeasonBanner
            If tScrapeModifiers.SeasonBanner AndAlso Results.List.Seasonbanner IsNot Nothing Then
                For Each image In Results.List.Seasonbanner
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "185",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .Season = If(image.Season = "all", 999, CInt(image.Season)),
                            .ShortLang = image.Lang,
                            .TVBannerType = Enums.TVBannerType.Any,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.SeasonBanners.Add(tmpPoster)
                Next
            End If

            'SeasonLandscape
            If tScrapeModifiers.SeasonLandscape AndAlso Results.List.Seasonthumb IsNot Nothing Then
                For Each Image In Results.List.Seasonthumb
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "281",
                            .Likes = CInt(Image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(Image.Lang), String.Empty, Localization.ISOGetLangByCode2(Image.Lang)),
                            .Scraper = "Fanart.tv",
                            .Season = If(Image.Season = "all", 999, CInt(Image.Season)),
                            .ShortLang = Image.Lang,
                            .TVBannerType = Enums.TVBannerType.Any,
                            .URLOriginal = Image.Url,
                            .URLThumb = Image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "500"}

                    nImagesContainer.SeasonLandscapes.Add(tmpPoster)
                Next
            End If

            'SeasonPoster
            If tScrapeModifiers.SeasonPoster AndAlso Results.List.Seasonposter IsNot Nothing Then
                For Each image In Results.List.Seasonposter
                    Dim tmpPoster As New MediaContainers.Image With {
                            .Height = "1426",
                            .Likes = CInt(image.Likes),
                            .LongLang = If(String.IsNullOrEmpty(image.Lang), String.Empty, Localization.ISOGetLangByCode2(image.Lang)),
                            .Scraper = "Fanart.tv",
                            .Season = If(image.Season = "all", 999, CInt(image.Season)),
                            .ShortLang = image.Lang,
                            .TVBannerType = Enums.TVBannerType.Any,
                            .URLOriginal = image.Url,
                            .URLThumb = image.Url.Replace("/fanart/", "/preview/"),
                            .Width = "1000"}

                    nImagesContainer.SeasonPosters.Add(tmpPoster)
                Next
            End If

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        Return nImagesContainer
    End Function


#End Region 'Methods

#Region "Nested Types"

    Private Structure Arguments

#Region "Fields"

        Dim Parameter As String
        Dim sType As String

#End Region 'Fields

    End Structure

    Private Structure Results

#Region "Fields"

        Dim Result As Object
        Dim ResultList As List(Of MediaContainers.Image)

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class