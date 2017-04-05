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

Imports NLog
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization

Public Class NFO

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region

#Region "Methods"
    ''' <summary>
    ''' Returns the "merged" result of each data scraper results
    ''' </summary>
    ''' <param name="tDBElement">Movie to be scraped</param>
    ''' <param name="ScrapedList"><c>List(Of MediaContainers.Movie)</c> which contains unfiltered results of each data scraper</param>
    ''' <returns>The scrape result of movie (after applying various global scraper settings here)</returns>
    ''' <remarks>
    ''' This is used to determine the result of data scraping by going through all scraperesults of every data scraper and applying global data scraper settings here!
    ''' 
    ''' 2014/09/01 Cocotus - First implementation: Moved all global lock settings in various data scrapers to this function, only apply them once and not in every data scraper module! Should be more maintainable!
    ''' </remarks>
    Public Shared Function MergeDataScraperResults_Movie(ByVal tDBElement As Database.DBElement, ByVal ScrapedList As List(Of MediaContainers.MainDetails)) As Database.DBElement

        'protects the first scraped result against overwriting
        Dim new_Actors As Boolean = False
        Dim new_Certification As Boolean = False
        Dim new_CollectionID As Boolean = False
        Dim new_Collections As Boolean = False
        Dim new_Countries As Boolean = False
        Dim new_Credits As Boolean = False
        Dim new_Directors As Boolean = False
        Dim new_Genres As Boolean = False
        Dim new_MPAA As Boolean = False
        Dim new_OriginalTitle As Boolean = False
        Dim new_Outline As Boolean = False
        Dim new_Plot As Boolean = False
        Dim new_Rating As Boolean = False
        Dim new_ReleaseDate As Boolean = False
        Dim new_Runtime As Boolean = False
        Dim new_Studio As Boolean = False
        Dim new_Tagline As Boolean = False
        Dim new_Title As Boolean = False
        Dim new_Top250 As Boolean = False
        Dim new_Trailer As Boolean = False
        Dim new_UserRating As Boolean = False
        Dim new_Year As Boolean = False

        With Master.eSettings.Movie.DataSettings
            For Each scrapedmovie In ScrapedList

                'IDs
                If scrapedmovie.IMDBSpecified Then
                    tDBElement.MainDetails.IMDB = scrapedmovie.IMDB
                End If
                If scrapedmovie.TMDBSpecified Then
                    tDBElement.MainDetails.TMDB = scrapedmovie.TMDB
                End If

                'Actors
                If (Not tDBElement.MainDetails.ActorsSpecified OrElse Not .Actors.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainActors AndAlso
                    scrapedmovie.ActorsSpecified AndAlso
                    .Actors.Enabled AndAlso
                    Not new_Actors Then
                    If .Actors.WithImageOnly Then
                        For i = scrapedmovie.Actors.Count - 1 To 0 Step -1
                            If Not scrapedmovie.Actors(i).URLOriginalSpecified Then
                                scrapedmovie.Actors.RemoveAt(i)
                            End If
                        Next
                    End If

                    If .Actors.LimitSpecified AndAlso
                        scrapedmovie.Actors.Count > .Actors.Limit Then
                        scrapedmovie.Actors.RemoveRange(.Actors.Limit, scrapedmovie.Actors.Count - .Actors.Limit)
                    End If

                    tDBElement.MainDetails.Actors = scrapedmovie.Actors
                    'added check if there's any actors left to add, if not then try with results of following scraper...
                    If scrapedmovie.ActorsSpecified Then
                        new_Actors = True
                        'add numbers for ordering
                        Dim iOrder As Integer = 0
                        For Each actor In scrapedmovie.Actors
                            actor.Order = iOrder
                            iOrder += 1
                        Next
                    End If

                ElseIf .ClearDisabledFields AndAlso
                    Not .Actors.Enabled AndAlso
                    Not .Actors.Locked Then
                    tDBElement.MainDetails.Actors.Clear()
                End If

                'Certification
                If (Not tDBElement.MainDetails.CertificationsSpecified OrElse Not .Certifications.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainCertifications AndAlso
                    scrapedmovie.CertificationsSpecified AndAlso
                    .Certifications.Enabled AndAlso
                    Not new_Certification Then
                    If .Certifications.Filter = Master.eLang.All Then
                        tDBElement.MainDetails.Certifications = scrapedmovie.Certifications
                        new_Certification = True
                    Else
                        Dim CertificationLanguage = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = .Certifications.Filter)
                        If CertificationLanguage IsNot Nothing AndAlso CertificationLanguage.name IsNot Nothing AndAlso Not String.IsNullOrEmpty(CertificationLanguage.name) Then
                            For Each tCert In scrapedmovie.Certifications
                                If tCert.StartsWith(CertificationLanguage.name) Then
                                    tDBElement.MainDetails.Certifications.Clear()
                                    tDBElement.MainDetails.Certifications.Add(tCert)
                                    new_Certification = True
                                    Exit For
                                End If
                            Next
                        Else
                            logger.Error("Movie Certification Language (Limit) not found. Please check your settings!")
                        End If
                    End If
                ElseIf .ClearDisabledFields AndAlso
                    Not .Certifications.Enabled AndAlso
                    Not .Certifications.Locked Then
                    tDBElement.MainDetails.Certifications.Clear()
                End If

                'Credits
                If (Not tDBElement.MainDetails.CreditsSpecified OrElse Not .Credits.Locked) AndAlso
                    scrapedmovie.CreditsSpecified AndAlso
                    .Credits.Enabled AndAlso
                    Not new_Credits Then
                    tDBElement.MainDetails.Credits = scrapedmovie.Credits
                    new_Credits = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Credits.Enabled AndAlso
                    Not .Credits.Locked Then
                    tDBElement.MainDetails.Credits.Clear()
                End If

                'Collection ID
                If (Not tDBElement.MainDetails.TMDBColIDSpecified OrElse Not .CollectionID.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainCollectionID AndAlso
                    scrapedmovie.TMDBColIDSpecified AndAlso
                    .CollectionID.Enabled AndAlso
                    Not new_CollectionID Then
                    tDBElement.MainDetails.TMDBColID = scrapedmovie.TMDBColID
                    new_CollectionID = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .CollectionID.Enabled AndAlso
                    Not .CollectionID.Locked Then
                    tDBElement.MainDetails.TMDBColID = -1
                End If

                'Collections
                If (Not tDBElement.MainDetails.SetsSpecified OrElse Not .Collection.Locked) AndAlso
                    scrapedmovie.SetsSpecified AndAlso
                    .Collection.Enabled AndAlso
                    Not new_Collections Then
                    tDBElement.MainDetails.Sets.Clear()
                    For Each movieset In scrapedmovie.Sets
                        If Not String.IsNullOrEmpty(movieset.Title) Then
                            For Each sett As AdvancedSettingsSetting In clsXMLAdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("MovieSetTitleRenamer:"))
                                movieset.Title = movieset.Title.Replace(sett.Name.Substring(21), sett.Value)
                            Next
                        End If
                    Next
                    tDBElement.MainDetails.Sets.AddRange(scrapedmovie.Sets)
                    new_Collections = True
                End If

                'Countries
                If (Not tDBElement.MainDetails.CountriesSpecified OrElse Not .Countries.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainCountries AndAlso
                    scrapedmovie.CountriesSpecified AndAlso
                    .Countries.Enabled AndAlso
                    Not new_Countries Then
                    tDBElement.MainDetails.Countries = scrapedmovie.Countries
                    new_Countries = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Countries.Enabled AndAlso
                    Not .Countries.Locked Then
                    tDBElement.MainDetails.Countries.Clear()
                End If

                'Directors
                If (Not tDBElement.MainDetails.DirectorsSpecified OrElse Not .Directors.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainDirectors AndAlso
                    scrapedmovie.DirectorsSpecified AndAlso
                    .Directors.Enabled AndAlso
                    Not new_Directors Then
                    tDBElement.MainDetails.Directors = scrapedmovie.Directors
                    new_Directors = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Directors.Enabled AndAlso
                    Not .Directors.Locked Then
                    tDBElement.MainDetails.Directors.Clear()
                End If

                'Genres
                If (Not tDBElement.MainDetails.GenresSpecified OrElse Not .Genres.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainGenres AndAlso
                    scrapedmovie.GenresSpecified AndAlso
                    .Genres.Enabled AndAlso
                    Not new_Genres Then
                    StringUtils.GenreFilter(scrapedmovie.Genres)
                    If .Genres.LimitSpecified AndAlso
                        .Genres.Limit < scrapedmovie.Genres.Count AndAlso
                        scrapedmovie.Genres.Count > 0 Then
                        scrapedmovie.Genres.RemoveRange(.Genres.Limit, scrapedmovie.Genres.Count - .Genres.Limit)
                    End If
                    tDBElement.MainDetails.Genres = scrapedmovie.Genres
                    new_Genres = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Genres.Enabled AndAlso
                    Not .Genres.Locked Then
                    tDBElement.MainDetails.Genres.Clear()
                End If

                'MPAA
                If (Not tDBElement.MainDetails.MPAASpecified OrElse Not .MPAA.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainMPAA AndAlso
                    scrapedmovie.MPAASpecified AndAlso
                    .MPAA.Enabled AndAlso
                    Not new_MPAA Then
                    tDBElement.MainDetails.MPAA = scrapedmovie.MPAA
                    new_MPAA = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .MPAA.Enabled AndAlso
                    Not .MPAA.Locked Then
                    tDBElement.MainDetails.MPAA = String.Empty
                End If

                'Originaltitle
                If (Not tDBElement.MainDetails.OriginalTitleSpecified OrElse Not .OriginalTitle.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainOriginalTitle AndAlso
                    scrapedmovie.OriginalTitleSpecified AndAlso
                    .OriginalTitle.Enabled AndAlso
                    Not new_OriginalTitle Then
                    tDBElement.MainDetails.OriginalTitle = scrapedmovie.OriginalTitle
                    new_OriginalTitle = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .OriginalTitle.Enabled AndAlso
                    Not .OriginalTitle.Locked Then
                    tDBElement.MainDetails.OriginalTitle = String.Empty
                End If

                'Outline
                If (Not tDBElement.MainDetails.OutlineSpecified OrElse Not .Outline.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainOutline AndAlso
                    scrapedmovie.OutlineSpecified AndAlso
                    .Outline.Enabled AndAlso
                    Not new_Outline Then
                    tDBElement.MainDetails.Outline = scrapedmovie.Outline
                    new_Outline = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Outline.Enabled AndAlso
                    Not .Outline.Locked Then
                    tDBElement.MainDetails.Outline = String.Empty
                End If
                'check if brackets should be removed...
                If .CleanPlotAndOutline Then
                    tDBElement.MainDetails.Outline = StringUtils.RemoveBrackets(tDBElement.MainDetails.Outline)
                End If

                'Plot
                If (Not tDBElement.MainDetails.PlotSpecified OrElse Not .Plot.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainPlot AndAlso
                    scrapedmovie.PlotSpecified AndAlso
                    .Plot.Enabled AndAlso
                    Not new_Plot Then
                    tDBElement.MainDetails.Plot = scrapedmovie.Plot
                    new_Plot = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Plot.Enabled AndAlso
                    Not .Plot.Locked Then
                    tDBElement.MainDetails.Plot = String.Empty
                End If
                'check if brackets should be removed...
                If .CleanPlotAndOutline Then
                    tDBElement.MainDetails.Plot = StringUtils.RemoveBrackets(tDBElement.MainDetails.Plot)
                End If

                'Rating/Votes
                If (Not tDBElement.MainDetails.RatingSpecified OrElse Not .Rating.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainRating AndAlso
                    scrapedmovie.RatingSpecified AndAlso
                    .Rating.Enabled AndAlso
                    Not new_Rating Then
                    tDBElement.MainDetails.Rating = scrapedmovie.Rating
                    tDBElement.MainDetails.Votes = NumUtils.CleanVotes(scrapedmovie.Votes)
                    new_Rating = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Rating.Enabled AndAlso
                    Not .Rating.Locked Then
                    tDBElement.MainDetails.Rating = String.Empty
                    tDBElement.MainDetails.Votes = String.Empty
                End If

                'ReleaseDate
                If (Not tDBElement.MainDetails.ReleaseDateSpecified OrElse Not .ReleaseDate.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainRelease AndAlso
                    scrapedmovie.ReleaseDateSpecified AndAlso
                    .ReleaseDate.Enabled AndAlso
                    Not new_ReleaseDate Then
                    tDBElement.MainDetails.ReleaseDate = NumUtils.DateToISO8601Date(scrapedmovie.ReleaseDate)
                    new_ReleaseDate = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .ReleaseDate.Enabled AndAlso
                    Not .ReleaseDate.Locked Then
                    tDBElement.MainDetails.ReleaseDate = String.Empty
                End If

                'Studios
                If (Not tDBElement.MainDetails.StudiosSpecified OrElse Not .Studios.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainStudios AndAlso
                    scrapedmovie.StudiosSpecified AndAlso
                    .Studios.Enabled AndAlso
                    Not new_Studio Then
                    tDBElement.MainDetails.Studios.Clear()

                    Dim _studios As New List(Of String)
                    _studios.AddRange(scrapedmovie.Studios)

                    If .Studios.LimitSpecified AndAlso
                        .Studios.Limit < _studios.Count AndAlso
                        _studios.Count > 0 Then
                        _studios.RemoveRange(.Studios.Limit, _studios.Count - .Studios.Limit)
                    End If
                    tDBElement.MainDetails.Studios.AddRange(_studios)
                    'added check if there's any studios left to add, if not then try with results of following scraper...
                    If _studios.Count > 0 Then
                        new_Studio = True
                    End If
                ElseIf .ClearDisabledFields AndAlso
                    Not .Studios.Enabled AndAlso
                    Not .Studios.Locked Then
                    tDBElement.MainDetails.Studios.Clear()
                End If

                'Tagline
                If (Not tDBElement.MainDetails.TaglineSpecified OrElse Not .Tagline.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainTagline AndAlso
                    scrapedmovie.TaglineSpecified AndAlso
                    .Tagline.Enabled AndAlso
                    Not new_Tagline Then
                    tDBElement.MainDetails.Tagline = scrapedmovie.Tagline
                    new_Tagline = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Tagline.Enabled AndAlso
                    Not .Tagline.Locked Then
                    tDBElement.MainDetails.Tagline = String.Empty
                End If

                'Title
                If (Not tDBElement.MainDetails.TitleSpecified OrElse Not .Title.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainTitle AndAlso
                    scrapedmovie.TitleSpecified AndAlso
                    .Title.Enabled AndAlso
                    Not new_Title Then
                    tDBElement.MainDetails.Title = scrapedmovie.Title
                    new_Title = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Title.Enabled AndAlso
                    Not .Title.Locked Then
                    tDBElement.MainDetails.Title = String.Empty
                End If

                'Top250 (special handling: no check if "scrapedmovie.Top250Specified" and only set "new_Top250 = True" if a value over 0 has been set)
                If (Not tDBElement.MainDetails.Top250Specified OrElse Not .Top250.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainTop250 AndAlso
                    .Top250.Enabled AndAlso
                    Not new_Top250 Then
                    tDBElement.MainDetails.Top250 = scrapedmovie.Top250
                    new_Top250 = If(scrapedmovie.Top250Specified, True, False)
                ElseIf .ClearDisabledFields AndAlso
                    Not .Top250.Enabled AndAlso
                    Not .Top250.Locked Then
                    tDBElement.MainDetails.Top250 = 0
                End If

                'Trailer
                If (Not tDBElement.MainDetails.TrailerSpecified OrElse Not .Trailer.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainTrailer AndAlso
                    scrapedmovie.TrailerSpecified AndAlso
                    .Trailer.Enabled AndAlso
                    Not new_Trailer Then
                    If .TrailerKodiFormat AndAlso YouTube.UrlUtils.IsYouTubeURL(scrapedmovie.Trailer) Then
                        tDBElement.MainDetails.Trailer = StringUtils.ConvertFromYouTubeURLToKodiTrailerFormat(scrapedmovie.Trailer)
                    Else
                        tDBElement.MainDetails.Trailer = scrapedmovie.Trailer
                    End If
                    new_Trailer = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Trailer.Enabled AndAlso
                    Not .Trailer.Locked Then
                    tDBElement.MainDetails.Trailer = String.Empty
                End If

                'UserRating
                If (Not tDBElement.MainDetails.UserRatingSpecified OrElse Not .UserRating.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainUserRating AndAlso
                    scrapedmovie.UserRatingSpecified AndAlso
                    .UserRating.Enabled AndAlso
                    Not new_UserRating Then
                    tDBElement.MainDetails.UserRating = scrapedmovie.UserRating
                    new_Rating = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .UserRating.Enabled AndAlso
                    Not .UserRating.Locked Then
                    tDBElement.MainDetails.UserRating = 0
                End If

                'Year
                If (Not tDBElement.MainDetails.YearSpecified OrElse Not .Year.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainYear AndAlso
                    scrapedmovie.YearSpecified AndAlso
                    .Year.Enabled AndAlso
                    Not new_Year Then
                    tDBElement.MainDetails.Year = scrapedmovie.Year
                    new_Year = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Year.Enabled AndAlso
                    Not .Year.Locked Then
                    tDBElement.MainDetails.Year = String.Empty
                End If

                'Runtime
                If (Not tDBElement.MainDetails.RuntimeSpecified OrElse Not .Runtime.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainRuntime AndAlso
                    scrapedmovie.RuntimeSpecified AndAlso
                    .Runtime.Enabled AndAlso
                    Not new_Runtime Then
                    tDBElement.MainDetails.Runtime = scrapedmovie.Runtime
                    new_Runtime = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Runtime.Enabled AndAlso
                    Not .Runtime.Locked Then
                    tDBElement.MainDetails.Runtime = String.Empty
                End If

            Next

            'Certification for MPAA
            If tDBElement.MainDetails.CertificationsSpecified AndAlso
                .CertificationsForMPAA AndAlso
                (Not .CertificationsForMPAAFallback AndAlso
                (Not tDBElement.MainDetails.MPAASpecified OrElse Not .MPAA.Locked) OrElse
                 Not new_MPAA AndAlso (Not tDBElement.MainDetails.MPAASpecified OrElse Not .MPAA.Locked)) Then

                Dim tmpstring As String = String.Empty
                tmpstring = If(.Certifications.Filter = "us", StringUtils.USACertToMPAA(String.Join(" / ", tDBElement.MainDetails.Certifications.ToArray)), If(.CertificationsOnlyValue, String.Join(" / ", tDBElement.MainDetails.Certifications.ToArray).Split(Convert.ToChar(":"))(1), String.Join(" / ", tDBElement.MainDetails.Certifications.ToArray)))
                'only update DBMovie if scraped result is not empty/nothing!
                If Not String.IsNullOrEmpty(tmpstring) Then
                    tDBElement.MainDetails.MPAA = tmpstring
                End If
            End If

            'MPAA value if MPAA is not available
            If Not tDBElement.MainDetails.MPAASpecified AndAlso .MPAANotRatedValueSpecified Then
                tDBElement.MainDetails.MPAA = .MPAANotRatedValue
            End If

            'Plot for Outline
            If ((Not tDBElement.MainDetails.OutlineSpecified OrElse Not .Outline.Locked) AndAlso
                .PlotForOutline AndAlso Not .PlotForOutlineAsFallback) OrElse
                (Not tDBElement.MainDetails.OutlineSpecified AndAlso .PlotForOutline AndAlso
                .PlotForOutlineAsFallback) Then
                tDBElement.MainDetails.Outline = StringUtils.ShortenOutline(tDBElement.MainDetails.Plot, .Outline.Limit)
            End If

            'set ListTitle at the end of merging
            If tDBElement.MainDetails.TitleSpecified Then
                tDBElement.ListTitle = StringUtils.SortTokens_Movie(tDBElement.MainDetails.Title)
            Else
                tDBElement.ListTitle = StringUtils.FilterTitleFromPath_Movie(tDBElement.FileItem, tDBElement.IsSingle, tDBElement.Source.UseFolderName)
            End If
        End With

        Return tDBElement
    End Function

    Public Shared Function MergeDataScraperResults_MovieSet(ByVal tDBElement As Database.DBElement, ByVal ScrapedList As List(Of MediaContainers.MainDetails)) As Database.DBElement

        'protects the first scraped result against overwriting
        Dim new_Plot As Boolean = False
        Dim new_Title As Boolean = False

        For Each scrapedmovieset In ScrapedList

            'IDs
            If scrapedmovieset.TMDBSpecified Then
                tDBElement.MainDetails.TMDB = scrapedmovieset.TMDB
            End If

            'Plot
            If (Not tDBElement.MainDetails.PlotSpecified OrElse Not Master.eSettings.Movieset.DataSettings.Plot.Locked) AndAlso
                tDBElement.ScrapeOptions.bMainPlot AndAlso
                scrapedmovieset.PlotSpecified AndAlso
                Master.eSettings.Movieset.DataSettings.Plot.Enabled AndAlso
                Not new_Plot Then
                tDBElement.MainDetails.Plot = scrapedmovieset.Plot
                new_Plot = True
            ElseIf Master.eSettings.Movieset.DataSettings.ClearDisabledFields AndAlso
                Not Master.eSettings.Movieset.DataSettings.Plot.Enabled AndAlso
                Not Master.eSettings.Movieset.DataSettings.Plot.Locked Then
                tDBElement.MainDetails.Plot = String.Empty
            End If

            'Title
            If (Not tDBElement.MainDetails.TitleSpecified OrElse Not Master.eSettings.Movieset.DataSettings.Title.Locked) AndAlso
                tDBElement.ScrapeOptions.bMainTitle AndAlso
                 scrapedmovieset.TitleSpecified AndAlso
                 Master.eSettings.Movieset.DataSettings.Title.Enabled AndAlso
                 Not new_Title Then
                tDBElement.MainDetails.Title = scrapedmovieset.Title
                new_Title = True
                'ElseIf Master.eSettings.MovieSetScraperCleanFields AndAlso Not Master.eSettings.MovieSetScraperTitle AndAlso Not Master.eSettings.MovieSetLockTitle Then
                '    DBMovieSet.MovieSet.Title = String.Empty
            End If
        Next

        'set Title
        For Each sett As AdvancedSettingsSetting In clsXMLAdvancedSettings.GetAllSettings.Where(Function(y) y.Name.StartsWith("MovieSetTitleRenamer:"))
            tDBElement.MainDetails.Title = tDBElement.MainDetails.Title.Replace(sett.Name.Substring(21), sett.Value)
        Next

        'set ListTitle at the end of merging
        If tDBElement.MainDetails.TitleSpecified Then
            Dim tTitle As String = StringUtils.SortTokens_MovieSet(tDBElement.MainDetails.Title)
            tDBElement.ListTitle = tTitle
        Else
            'If FileUtils.Common.isVideoTS(DBMovie.Filename) Then
            '    DBMovie.ListTitle = StringUtils.FilterName_Movie(Directory.GetParent(Directory.GetParent(DBMovie.Filename).FullName).Name)
            'ElseIf FileUtils.Common.isBDRip(DBMovie.Filename) Then
            '    DBMovie.ListTitle = StringUtils.FilterName_Movie(Directory.GetParent(Directory.GetParent(Directory.GetParent(DBMovie.Filename).FullName).FullName).Name)
            'Else
            '    If DBMovie.UseFolder AndAlso DBMovie.IsSingle Then
            '        DBMovie.ListTitle = StringUtils.FilterName_Movie(Directory.GetParent(DBMovie.Filename).Name)
            '    Else
            '        DBMovie.ListTitle = StringUtils.FilterName_Movie(Path.GetFileNameWithoutExtension(DBMovie.Filename))
            '    End If
            'End If
        End If

        Return tDBElement
    End Function
    ''' <summary>
    ''' Returns the "merged" result of each data scraper results
    ''' </summary>
    ''' <param name="tDBElement">TV Show to be scraped</param>
    ''' <param name="ScrapedList"><c>List(Of MediaContainers.MainDetails)</c> which contains unfiltered results of each data scraper</param>
    ''' <returns>The scrape result of movie (after applying various global scraper settings here)</returns>
    ''' <remarks>
    ''' This is used to determine the result of data scraping by going through all scraperesults of every data scraper and applying global data scraper settings here!
    ''' 
    ''' 2014/09/01 Cocotus - First implementation: Moved all global lock settings in various data scrapers to this function, only apply them once and not in every data scraper module! Should be more maintainable!
    ''' </remarks>
    Public Shared Function MergeDataScraperResults_TV(ByVal tDBElement As Database.DBElement, ByVal ScrapedList As List(Of MediaContainers.MainDetails)) As Database.DBElement

        'protects the first scraped result against overwriting
        Dim new_Actors As Boolean = False
        Dim new_Certification As Boolean = False
        Dim new_Collections As Boolean = False
        Dim new_Creators As Boolean = False
        Dim new_Credits As Boolean = False
        Dim new_Directors As Boolean = False
        Dim new_Genres As Boolean = False
        Dim new_MPAA As Boolean = False
        Dim new_OriginalTitle As Boolean = False
        Dim new_Outline As Boolean = False
        Dim new_Plot As Boolean = False
        Dim new_Premiered As Boolean = False
        Dim new_Rating As Boolean = False
        Dim new_Runtime As Boolean = False
        Dim new_ShowCountries As Boolean = False
        Dim new_Status As Boolean = False
        Dim new_Studio As Boolean = False
        Dim new_Tagline As Boolean = False
        Dim new_Title As Boolean = False
        Dim new_Trailer As Boolean = False
        Dim new_UserRating As Boolean = False

        Dim KnownEpisodesIndex As New List(Of KnownEpisode)
        Dim KnownSeasonsIndex As New List(Of Integer)

        ''If "Use Preview Datascraperresults" option is enabled, a preview window which displays all datascraperresults will be opened before showing the Edit Movie page!
        'If (ScrapeType = Enums.ScrapeType_Movie_MovieSet_TV.SingleScrape OrElse ScrapeType = Enums.ScrapeType_Movie_MovieSet_TV.SingleField) AndAlso Master.eSettings.MovieScraperUseDetailView AndAlso ScrapedList.Count > 0 Then
        '    PreviewDataScraperResults(ScrapedList)
        'End If

        With Master.eSettings.TV.DataSettings.TVShow
            For Each scrapedshow In ScrapedList

                'IDs
                If scrapedshow.TVDBSpecified Then
                    tDBElement.MainDetails.TVDB = scrapedshow.TVDB
                End If
                If scrapedshow.IMDBSpecified Then
                    tDBElement.MainDetails.IMDB = scrapedshow.IMDB
                End If
                If scrapedshow.TMDBSpecified Then
                    tDBElement.MainDetails.TMDB = scrapedshow.TMDB
                End If

                'Actors
                If (Not tDBElement.MainDetails.ActorsSpecified OrElse Not .Actors.Locked) AndAlso
                tDBElement.ScrapeOptions.bMainActors AndAlso
                scrapedshow.ActorsSpecified AndAlso
                 .Actors.Enabled AndAlso
                Not new_Actors Then
                    If .Actors.WithImageOnly Then
                        For i = scrapedshow.Actors.Count - 1 To 0 Step -1
                            If Not scrapedshow.Actors(i).URLOriginalSpecified Then
                                scrapedshow.Actors.RemoveAt(i)
                            End If
                        Next
                    End If

                    If .Actors.LimitSpecified AndAlso
                    scrapedshow.Actors.Count > .Actors.Limit Then
                        scrapedshow.Actors.RemoveRange(.Actors.Limit, scrapedshow.Actors.Count - .Actors.Limit)
                    End If

                    tDBElement.MainDetails.Actors = scrapedshow.Actors
                    'added check if there's any actors left to add, if not then try with results of following scraper...
                    If scrapedshow.ActorsSpecified Then
                        new_Actors = True
                        'add numbers for ordering
                        Dim iOrder As Integer = 0
                        For Each actor In scrapedshow.Actors
                            actor.Order = iOrder
                            iOrder += 1
                        Next
                    End If
                ElseIf .ClearDisabledFields AndAlso
                    Not .Actors.Enabled AndAlso
                    Not .Actors.Locked Then
                    tDBElement.MainDetails.Actors.Clear()
                End If

                'Certification
                If (Not tDBElement.MainDetails.CertificationsSpecified OrElse Not .Certifications.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainCertifications AndAlso
                    scrapedshow.CertificationsSpecified AndAlso
                    .Certifications.Enabled AndAlso
                    Not new_Certification Then
                    If .Certifications.Filter = Master.eLang.All Then
                        tDBElement.MainDetails.Certifications = scrapedshow.Certifications
                        new_Certification = True
                    Else
                        Dim CertificationLanguage = APIXML.CertLanguagesXML.Language.FirstOrDefault(Function(l) l.abbreviation = .Certifications.Filter)
                        If CertificationLanguage IsNot Nothing AndAlso CertificationLanguage.name IsNot Nothing AndAlso Not String.IsNullOrEmpty(CertificationLanguage.name) Then
                            For Each tCert In scrapedshow.Certifications
                                If tCert.StartsWith(CertificationLanguage.name) Then
                                    tDBElement.MainDetails.Certifications.Clear()
                                    tDBElement.MainDetails.Certifications.Add(tCert)
                                    new_Certification = True
                                    Exit For
                                End If
                            Next
                        Else
                            logger.Error("TV Show Certification Language (Limit) not found. Please check your settings!")
                        End If
                    End If
                ElseIf .ClearDisabledFields AndAlso
                    Not .Certifications.Enabled AndAlso
                    Not .Certifications.Locked Then
                    tDBElement.MainDetails.Certifications.Clear()
                End If

                'Creators
                If (Not tDBElement.MainDetails.CreatorsSpecified OrElse Not .Creators.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainCreators AndAlso
                    scrapedshow.CreatorsSpecified AndAlso
                    .Creators.Enabled AndAlso
                    Not new_Creators Then
                    tDBElement.MainDetails.Creators = scrapedshow.Creators
                ElseIf .ClearDisabledFields AndAlso
                    Not .Creators.Enabled AndAlso
                    Not .Creators.Locked Then
                    tDBElement.MainDetails.Creators.Clear()
                End If

                'Countries
                If (Not tDBElement.MainDetails.CountriesSpecified OrElse Not .Countries.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainCountries AndAlso
                    scrapedshow.CountriesSpecified AndAlso
                    .Countries.Enabled AndAlso
                    Not new_ShowCountries Then
                    tDBElement.MainDetails.Countries = scrapedshow.Countries
                    new_ShowCountries = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Countries.Enabled AndAlso
                    Not .Countries.Locked Then
                    tDBElement.MainDetails.Countries.Clear()
                End If

                'EpisodeGuideURL
                If tDBElement.ScrapeOptions.bMainEpisodeGuide AndAlso
                    scrapedshow.EpisodeGuideSpecified AndAlso
                    .EpisodeGuideURL.Enabled Then
                    tDBElement.MainDetails.EpisodeGuide = scrapedshow.EpisodeGuide
                ElseIf .ClearDisabledFields AndAlso
                    Not .EpisodeGuideURL.Enabled Then
                    tDBElement.MainDetails.EpisodeGuide.Clear()
                End If

                'Genres
                If (Not tDBElement.MainDetails.GenresSpecified OrElse Not .Genres.Locked) AndAlso
                tDBElement.ScrapeOptions.bMainGenres AndAlso
                scrapedshow.GenresSpecified AndAlso
                 .Genres.Enabled AndAlso
                Not new_Genres Then
                    StringUtils.GenreFilter(scrapedshow.Genres)
                    If .Genres.LimitSpecified AndAlso
                     .Genres.Limit < scrapedshow.Genres.Count AndAlso
                    scrapedshow.Genres.Count > 0 Then
                        scrapedshow.Genres.RemoveRange(.Genres.Limit, scrapedshow.Genres.Count - .Genres.Limit)
                    End If
                    tDBElement.MainDetails.Genres = scrapedshow.Genres
                    new_Genres = True
                ElseIf .ClearDisabledFields AndAlso
                Not .Genres.Enabled AndAlso
                Not .Genres.Locked Then
                    tDBElement.MainDetails.Genres.Clear()
                End If

                'MPAA
                If (Not tDBElement.MainDetails.MPAASpecified OrElse Not .MPAA.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainMPAA AndAlso
                  scrapedshow.MPAASpecified AndAlso
                  .MPAA.Enabled AndAlso
                  Not new_MPAA Then
                    tDBElement.MainDetails.MPAA = scrapedshow.MPAA
                    new_MPAA = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .MPAA.Enabled AndAlso
                    Not .MPAA.Locked Then
                    tDBElement.MainDetails.MPAA = String.Empty
                End If

                'Originaltitle
                If (Not tDBElement.MainDetails.OriginalTitleSpecified OrElse Not .OriginalTitle.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainOriginalTitle AndAlso
                    scrapedshow.OriginalTitleSpecified AndAlso
                    .OriginalTitle.Enabled AndAlso
                    Not new_OriginalTitle Then
                    tDBElement.MainDetails.OriginalTitle = scrapedshow.OriginalTitle
                    new_OriginalTitle = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .OriginalTitle.Enabled AndAlso
                    Not .OriginalTitle.Locked Then
                    tDBElement.MainDetails.OriginalTitle = String.Empty
                End If

                'Plot
                If (Not tDBElement.MainDetails.PlotSpecified OrElse Not .Plot.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainPlot AndAlso
                     scrapedshow.PlotSpecified AndAlso
                     .Plot.Enabled AndAlso
                     Not new_Plot Then
                    tDBElement.MainDetails.Plot = scrapedshow.Plot
                    new_Plot = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Plot.Enabled AndAlso
                    Not .Plot.Locked Then
                    tDBElement.MainDetails.Plot = String.Empty
                End If

                'Premiered
                If (Not tDBElement.MainDetails.PremieredSpecified OrElse Not .Premiered.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainPremiered AndAlso
                    scrapedshow.PremieredSpecified AndAlso
                    .Premiered.Enabled AndAlso
                    Not new_Premiered Then
                    tDBElement.MainDetails.Premiered = NumUtils.DateToISO8601Date(scrapedshow.Premiered)
                    new_Premiered = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Premiered.Enabled AndAlso
                    Not .Premiered.Locked Then
                    tDBElement.MainDetails.Premiered = String.Empty
                End If

                'Rating/Votes
                If (Not tDBElement.MainDetails.RatingSpecified OrElse Not .Rating.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainRating AndAlso
                    scrapedshow.RatingSpecified AndAlso
                    .Rating.Enabled AndAlso
                    Not new_Rating Then
                    tDBElement.MainDetails.Rating = scrapedshow.Rating
                    tDBElement.MainDetails.Votes = NumUtils.CleanVotes(scrapedshow.Votes)
                    new_Rating = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Rating.Enabled AndAlso
                    Not .Rating.Locked Then
                    tDBElement.MainDetails.Rating = String.Empty
                    tDBElement.MainDetails.Votes = String.Empty
                End If

                'Runtime
                If (Not tDBElement.MainDetails.RuntimeSpecified OrElse Not .Runtime.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainRuntime AndAlso
                    scrapedshow.RuntimeSpecified AndAlso
                    .Runtime.Enabled AndAlso
                    Not new_Runtime Then
                    tDBElement.MainDetails.Runtime = scrapedshow.Runtime
                    new_Runtime = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Runtime.Enabled AndAlso
                    Not .Runtime.Locked Then
                    tDBElement.MainDetails.Runtime = String.Empty
                End If

                'Status
                If (tDBElement.MainDetails.StatusSpecified OrElse Not .Status.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainStatus AndAlso
                    scrapedshow.StatusSpecified AndAlso
                    .Status.Enabled AndAlso
                    Not new_Status Then
                    tDBElement.MainDetails.Status = scrapedshow.Status
                    new_Status = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Status.Enabled AndAlso
                    Not .Status.Locked Then
                    tDBElement.MainDetails.Status = String.Empty
                End If

                'Studios
                If (Not tDBElement.MainDetails.StudiosSpecified OrElse Not .Studios.Locked) AndAlso
                tDBElement.ScrapeOptions.bMainStudios AndAlso
                scrapedshow.StudiosSpecified AndAlso
                 .Studios.Enabled AndAlso
                Not new_Studio Then
                    tDBElement.MainDetails.Studios.Clear()

                    Dim _studios As New List(Of String)
                    _studios.AddRange(scrapedshow.Studios)

                    If .Studios.LimitSpecified AndAlso
                     .Studios.Limit < _studios.Count AndAlso
                    _studios.Count > 0 Then
                        _studios.RemoveRange(.Studios.Limit, _studios.Count - .Studios.Limit)
                    End If
                    tDBElement.MainDetails.Studios.AddRange(_studios)
                    'added check if there's any studios left to add, if not then try with results of following scraper...
                    If _studios.Count > 0 Then
                        new_Studio = True
                    End If
                ElseIf .ClearDisabledFields AndAlso
                Not .Studios.Enabled AndAlso
                Not .Studios.Locked Then
                    tDBElement.MainDetails.Studios.Clear()
                End If

                'Title
                If (Not tDBElement.MainDetails.TitleSpecified OrElse Not .Title.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainTitle AndAlso
                    scrapedshow.TitleSpecified AndAlso
                    .Title.Enabled AndAlso
                    Not new_Title Then
                    tDBElement.MainDetails.Title = scrapedshow.Title
                    new_Title = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .Title.Enabled AndAlso
                    Not .Title.Locked Then
                    tDBElement.MainDetails.Title = String.Empty
                End If

                'UserRating
                If (Not tDBElement.MainDetails.UserRatingSpecified OrElse Not .UserRating.Locked) AndAlso
                    tDBElement.ScrapeOptions.bMainUserRating AndAlso
                    scrapedshow.UserRatingSpecified AndAlso
                    .UserRating.Enabled AndAlso
                    Not new_UserRating Then
                    tDBElement.MainDetails.UserRating = scrapedshow.UserRating
                    new_UserRating = True
                ElseIf .ClearDisabledFields AndAlso
                    Not .UserRating.Enabled AndAlso
                    Not .UserRating.Locked Then
                    tDBElement.MainDetails.UserRating = 0
                End If

                '    'Credits
                '    If (DBTV.Movie.Credits.Count < 1 OrElse Not Master.eSettings.MovieLockCredits) AndAlso _
                '        scrapedmovie.Credits.Count > 0 AndAlso Master.eSettings.MovieScraperCredits AndAlso Not new_Credits Then
                '        DBTV.Movie.Credits.Clear()
                '        DBTV.Movie.Credits.AddRange(scrapedmovie.Credits)
                '        new_Credits = True
                '    ElseIf Master.eSettings.MovieScraperCleanFields AndAlso Not Master.eSettings.MovieScraperCredits AndAlso Not Master.eSettings.MovieLockCredits Then
                '        DBTV.Movie.Credits.Clear()
                '    End If

                'Create KnowSeasons index
                For Each kSeason As MediaContainers.MainDetails In scrapedshow.KnownSeasons
                    If Not KnownSeasonsIndex.Contains(kSeason.Season) Then
                        KnownSeasonsIndex.Add(kSeason.Season)
                    End If
                Next

                'Create KnownEpisodes index (season and episode number)
                If tDBElement.ScrapeModifiers.withEpisodes Then
                    For Each kEpisode As MediaContainers.MainDetails In scrapedshow.KnownEpisodes
                        Dim nKnownEpisode As New KnownEpisode With {.AiredDate = kEpisode.Aired,
                                                                    .Episode = kEpisode.Episode,
                                                                    .EpisodeAbsolute = kEpisode.EpisodeAbsolute,
                                                                    .EpisodeCombined = kEpisode.EpisodeCombined,
                                                                    .EpisodeDVD = kEpisode.EpisodeDVD,
                                                                    .Season = kEpisode.Season,
                                                                    .SeasonCombined = kEpisode.SeasonCombined,
                                                                    .SeasonDVD = kEpisode.SeasonDVD}
                        If KnownEpisodesIndex.Where(Function(f) f.Episode = nKnownEpisode.Episode AndAlso f.Season = nKnownEpisode.Season).Count = 0 Then
                            KnownEpisodesIndex.Add(nKnownEpisode)

                            'try to get an episode information with more numbers
                        ElseIf KnownEpisodesIndex.Where(Function(f) f.Episode = nKnownEpisode.Episode AndAlso f.Season = nKnownEpisode.Season AndAlso
                                    ((nKnownEpisode.EpisodeAbsolute > -1 AndAlso Not f.EpisodeAbsolute = nKnownEpisode.EpisodeAbsolute) OrElse
                                     (nKnownEpisode.EpisodeCombined > -1 AndAlso Not f.EpisodeCombined = nKnownEpisode.EpisodeCombined) OrElse
                                     (nKnownEpisode.EpisodeDVD > -1 AndAlso Not f.EpisodeDVD = nKnownEpisode.EpisodeDVD) OrElse
                                     (nKnownEpisode.SeasonCombined > -1 AndAlso Not f.SeasonCombined = nKnownEpisode.SeasonCombined) OrElse
                                     (nKnownEpisode.SeasonDVD > -1 AndAlso Not f.SeasonDVD = nKnownEpisode.SeasonDVD))).Count = 1 Then
                            Dim toRemove As KnownEpisode = KnownEpisodesIndex.FirstOrDefault(Function(f) f.Episode = nKnownEpisode.Episode AndAlso f.Season = nKnownEpisode.Season)
                            KnownEpisodesIndex.Remove(toRemove)
                            KnownEpisodesIndex.Add(nKnownEpisode)
                        End If
                    Next
                End If
            Next

            'Certification for MPAA
            If tDBElement.MainDetails.CertificationsSpecified AndAlso .CertificationsForMPAA AndAlso
            (Not .CertificationsForMPAAFallback AndAlso (Not tDBElement.MainDetails.MPAASpecified OrElse Not .MPAA.Locked) OrElse
             Not new_MPAA AndAlso (Not tDBElement.MainDetails.MPAASpecified OrElse Not .MPAA.Locked)) Then

                Dim tmpstring As String = String.Empty
                tmpstring = If(.Certifications.Filter = "us", StringUtils.USACertToMPAA(String.Join(" / ", tDBElement.MainDetails.Certifications.ToArray)), If(.CertificationsOnlyValue, String.Join(" / ", tDBElement.MainDetails.Certifications.ToArray).Split(Convert.ToChar(":"))(1), String.Join(" / ", tDBElement.MainDetails.Certifications.ToArray)))
                'only update DBMovie if scraped result is not empty/nothing!
                If Not String.IsNullOrEmpty(tmpstring) Then
                    tDBElement.MainDetails.MPAA = tmpstring
                End If
            End If

            'MPAA value if MPAA is not available
            If Not tDBElement.MainDetails.MPAASpecified AndAlso .MPAANotRatedValueSpecified Then
                tDBElement.MainDetails.MPAA = .MPAANotRatedValue
            End If

            'set ListTitle at the end of merging
            If tDBElement.MainDetails.TitleSpecified Then
                tDBElement.ListTitle = StringUtils.SortTokens_TV(tDBElement.MainDetails.Title)
            End If
        End With


        'Seasons
        For Each aKnownSeason As Integer In KnownSeasonsIndex
            'create a list of specified episode informations from all scrapers
            Dim ScrapedSeasonList As New List(Of MediaContainers.MainDetails)
            For Each nShow As MediaContainers.MainDetails In ScrapedList
                For Each nSeasonDetails As MediaContainers.MainDetails In nShow.KnownSeasons.Where(Function(f) f.Season = aKnownSeason)
                    ScrapedSeasonList.Add(nSeasonDetails)
                Next
            Next
            'check if we have already saved season information for this scraped season
            Dim lSeasonList = tDBElement.Seasons.Where(Function(f) f.MainDetails.Season = aKnownSeason)

            If lSeasonList IsNot Nothing AndAlso lSeasonList.Count > 0 Then
                For Each nSeason As Database.DBElement In lSeasonList
                    MergeDataScraperResults_TVSeason(nSeason, ScrapedSeasonList)
                Next
            Else
                'no existing season found -> add it as "missing" season
                Dim mSeason As New Database.DBElement(Enums.ContentType.TVSeason) With {.MainDetails = New MediaContainers.MainDetails With {.Season = aKnownSeason}}
                mSeason = Master.DB.AddTVShowInfoToDBElement(mSeason, tDBElement)
                tDBElement.Seasons.Add(MergeDataScraperResults_TVSeason(mSeason, ScrapedSeasonList))
            End If
        Next
        'add all season informations to TVShow (for saving season informations to tv show NFO)
        tDBElement.MainDetails.Seasons.Seasons.Clear()
        For Each kSeason As Database.DBElement In tDBElement.Seasons.OrderBy(Function(f) f.MainDetails.Season)
            tDBElement.MainDetails.Seasons.Seasons.Add(kSeason.MainDetails)
        Next

        'Episodes
        If tDBElement.ScrapeModifiers.withEpisodes Then
            'update the tvshow information for each local episode
            For Each lEpisode In tDBElement.Episodes
                lEpisode = Master.DB.AddTVShowInfoToDBElement(lEpisode, tDBElement)
                lEpisode.ScrapeModifiers = tDBElement.ScrapeModifiers
                lEpisode.ScrapeOptions = tDBElement.ScrapeOptions
            Next

            For Each aKnownEpisode As KnownEpisode In KnownEpisodesIndex.OrderBy(Function(f) f.Episode).OrderBy(Function(f) f.Season)

                'convert the episode and season number if needed
                Dim iEpisode As Integer = -1
                Dim iSeason As Integer = -1
                Dim strAiredDate As String = aKnownEpisode.AiredDate
                If tDBElement.Ordering = Enums.EpisodeOrdering.Absolute Then
                    iEpisode = aKnownEpisode.EpisodeAbsolute
                    iSeason = 1
                ElseIf tDBElement.Ordering = Enums.EpisodeOrdering.DVD Then
                    iEpisode = CInt(aKnownEpisode.EpisodeDVD)
                    iSeason = aKnownEpisode.SeasonDVD
                ElseIf tDBElement.Ordering = Enums.EpisodeOrdering.Standard Then
                    iEpisode = aKnownEpisode.Episode
                    iSeason = aKnownEpisode.Season
                End If

                If Not iEpisode = -1 AndAlso Not iSeason = -1 Then
                    'create a list of specified episode informations from all scrapers
                    Dim ScrapedEpisodeList As New List(Of MediaContainers.MainDetails)
                    For Each nShow As MediaContainers.MainDetails In ScrapedList
                        For Each nEpisodeDetails As MediaContainers.MainDetails In nShow.KnownEpisodes.Where(Function(f) f.Episode = aKnownEpisode.Episode AndAlso f.Season = aKnownEpisode.Season)
                            ScrapedEpisodeList.Add(nEpisodeDetails)
                        Next
                    Next

                    'check if we have a local episode file for this scraped episode
                    Dim lEpisodeList = tDBElement.Episodes.Where(Function(f) f.FilenameSpecified AndAlso f.MainDetails.Episode = iEpisode AndAlso f.MainDetails.Season = iSeason)

                    If lEpisodeList IsNot Nothing AndAlso lEpisodeList.Count > 0 Then
                        For Each nEpisode As Database.DBElement In lEpisodeList
                            MergeDataScraperResults_TVEpisode(nEpisode, ScrapedEpisodeList)
                        Next
                    Else
                        'try to get the episode by AiredDate
                        Dim dEpisodeList = tDBElement.Episodes.Where(Function(f) f.FilenameSpecified AndAlso
                                                                   f.MainDetails.Episode = -1 AndAlso
                                                                   f.MainDetails.AiredSpecified AndAlso
                                                                   f.MainDetails.Aired = strAiredDate)

                        If dEpisodeList IsNot Nothing AndAlso dEpisodeList.Count > 0 Then
                            For Each nEpisode As Database.DBElement In dEpisodeList
                                MergeDataScraperResults_TVEpisode(nEpisode, ScrapedEpisodeList)
                                'we have to add the proper season and episode number if the episode was found by AiredDate
                                nEpisode.MainDetails.Episode = iEpisode
                                nEpisode.MainDetails.Season = iSeason
                            Next
                        Else
                            'no local episode found -> add it as "missing" episode
                            Dim mEpisode As New Database.DBElement(Enums.ContentType.TVEpisode) With {.MainDetails = New MediaContainers.MainDetails With {.Episode = iEpisode, .Season = iSeason}}
                            mEpisode = Master.DB.AddTVShowInfoToDBElement(mEpisode, tDBElement)
                            MergeDataScraperResults_TVEpisode(mEpisode, ScrapedEpisodeList)
                            If mEpisode.MainDetails.TitleSpecified Then
                                tDBElement.Episodes.Add(mEpisode)
                            Else
                                logger.Warn(String.Format("Missing Episode Ignored | {0} - S{1}E{2} | No Episode Title found", mEpisode.TVShowDetails.Title, mEpisode.MainDetails.Season, mEpisode.MainDetails.Episode))
                            End If
                        End If
                    End If
                Else
                    logger.Warn("No valid episode or season number found")
                End If
            Next
        End If

        'create the "* All Seasons" entry if needed
        Dim tmpAllSeasons As Database.DBElement = tDBElement.Seasons.FirstOrDefault(Function(f) f.MainDetails.Season = 999)
        If tmpAllSeasons Is Nothing OrElse tmpAllSeasons.MainDetails Is Nothing Then
            tmpAllSeasons = New Database.DBElement(Enums.ContentType.TVSeason)
            tmpAllSeasons.MainDetails = New MediaContainers.MainDetails With {.Season = 999}
            tmpAllSeasons = Master.DB.AddTVShowInfoToDBElement(tmpAllSeasons, tDBElement)
            tDBElement.Seasons.Add(tmpAllSeasons)
        End If

        'cleanup seasons they don't have any episode
        Dim iIndex As Integer = 0
        While iIndex <= tDBElement.Seasons.Count - 1
            Dim iSeason As Integer = tDBElement.Seasons.Item(iIndex).MainDetails.Season
            If Not iSeason = 999 AndAlso tDBElement.Episodes.Where(Function(f) f.MainDetails.Season = iSeason).Count = 0 Then
                tDBElement.Seasons.RemoveAt(iIndex)
            Else
                iIndex += 1
            End If
        End While

        Return tDBElement
    End Function

    Public Shared Function MergeDataScraperResults_TVSeason(ByRef tDBElement As Database.DBElement, ByVal ScrapedList As List(Of MediaContainers.MainDetails)) As Database.DBElement

        'protects the first scraped result against overwriting
        Dim new_Aired As Boolean = False
        Dim new_Plot As Boolean = False
        Dim new_Season As Boolean = False
        Dim new_Title As Boolean = False

        With Master.eSettings.TV.DataSettings.TVSeason
            For Each scrapedseason In ScrapedList

                'IDs
                If scrapedseason.TMDBSpecified Then
                    tDBElement.MainDetails.TMDB = scrapedseason.TMDB
                End If
                If scrapedseason.TVDBSpecified Then
                    tDBElement.MainDetails.TVDB = scrapedseason.TVDB
                End If

                'Season number
                If scrapedseason.SeasonSpecified AndAlso Not new_Season Then
                    tDBElement.MainDetails.Season = scrapedseason.Season
                    new_Season = True
                End If

                'Aired
                If (Not tDBElement.MainDetails.AiredSpecified OrElse Not .Aired.Locked) AndAlso
                    tDBElement.ScrapeOptions.bSeasonAired AndAlso
                scrapedseason.AiredSpecified AndAlso
                .Aired.Enabled AndAlso
                Not new_Aired Then
                    tDBElement.MainDetails.Aired = scrapedseason.Aired
                    new_Aired = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Aired.Enabled AndAlso
                                        Not .Aired.Locked Then
                    tDBElement.MainDetails.Aired = String.Empty
                End If

                'Plot
                If (Not tDBElement.MainDetails.PlotSpecified OrElse Not .Plot.Locked) AndAlso
                    tDBElement.ScrapeOptions.bSeasonPlot AndAlso
                scrapedseason.PlotSpecified AndAlso
                .Plot.Enabled AndAlso
                Not new_Plot Then
                    tDBElement.MainDetails.Plot = scrapedseason.Plot
                    new_Plot = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Plot.Enabled AndAlso
                    Not .Plot.Locked Then
                    tDBElement.MainDetails.Plot = String.Empty
                End If

                'Title
                If (Not tDBElement.MainDetails.TitleSpecified OrElse Not .Title.Locked) AndAlso
                    tDBElement.ScrapeOptions.bSeasonTitle AndAlso
                scrapedseason.TitleSpecified AndAlso
                .Title.Enabled AndAlso
                Not new_Title Then
                    tDBElement.MainDetails.Title = scrapedseason.Title
                    new_Title = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Title.Enabled AndAlso
                    Not .Title.Locked Then
                    tDBElement.MainDetails.Title = String.Empty
                End If
            Next
        End With

        Return tDBElement
    End Function
    ''' <summary>
    ''' Returns the "merged" result of each data scraper results
    ''' </summary>
    ''' <param name="DBTVEpisode">Episode to be scraped</param>
    ''' <param name="ScrapedList"><c>List(Of MediaContainers.EpisodeDetails)</c> which contains unfiltered results of each data scraper</param>
    ''' <returns>The scrape result of episode (after applying various global scraper settings here)</returns>
    ''' <remarks>
    ''' This is used to determine the result of data scraping by going through all scraperesults of every data scraper and applying global data scraper settings here!
    ''' 
    ''' 2014/09/01 Cocotus - First implementation: Moved all global lock settings in various data scrapers to this function, only apply them once and not in every data scraper module! Should be more maintainable!
    ''' </remarks>
    Private Shared Function MergeDataScraperResults_TVEpisode(ByRef DBTVEpisode As Database.DBElement, ByVal ScrapedList As List(Of MediaContainers.MainDetails)) As Database.DBElement

        'protects the first scraped result against overwriting
        Dim new_Actors As Boolean = False
        Dim new_Aired As Boolean = False
        Dim new_Countries As Boolean = False
        Dim new_Credits As Boolean = False
        Dim new_Directors As Boolean = False
        Dim new_Episode As Boolean = False
        Dim new_GuestStars As Boolean = False
        Dim new_OriginalTitle As Boolean = False
        Dim new_Plot As Boolean = False
        Dim new_Rating As Boolean = False
        Dim new_Runtime As Boolean = False
        Dim new_Season As Boolean = False
        Dim new_ThumbPoster As Boolean = False
        Dim new_Title As Boolean = False
        Dim new_UserRating As Boolean = False

        ''If "Use Preview Datascraperresults" option is enabled, a preview window which displays all datascraperresults will be opened before showing the Edit Movie page!
        'If (ScrapeType = Enums.ScrapeType_Movie_MovieSet_TV.SingleScrape OrElse ScrapeType = Enums.ScrapeType_Movie_MovieSet_TV.SingleField) AndAlso Master.eSettings.MovieScraperUseDetailView AndAlso ScrapedList.Count > 0 Then
        '    PreviewDataScraperResults(ScrapedList)
        'End If

        With Master.eSettings.TV.DataSettings.TVEpisode
            For Each scrapedepisode In ScrapedList

                'IDs
                If scrapedepisode.IMDBSpecified Then
                    DBTVEpisode.MainDetails.IMDB = scrapedepisode.IMDB
                End If
                If scrapedepisode.TMDBSpecified Then
                    DBTVEpisode.MainDetails.TMDB = scrapedepisode.TMDB
                End If
                If scrapedepisode.TVDBSpecified Then
                    DBTVEpisode.MainDetails.TVDB = scrapedepisode.TVDB
                End If

                'DisplayEpisode
                If scrapedepisode.DisplayEpisodeSpecified Then
                    DBTVEpisode.MainDetails.DisplayEpisode = scrapedepisode.DisplayEpisode
                End If

                'DisplaySeason
                If scrapedepisode.DisplaySeasonSpecified Then
                    DBTVEpisode.MainDetails.DisplaySeason = scrapedepisode.DisplaySeason
                End If

                'Actors
                If (Not DBTVEpisode.MainDetails.ActorsSpecified OrElse Not .Actors.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeActors AndAlso
                    scrapedepisode.ActorsSpecified AndAlso
                    .Actors.Enabled AndAlso
                    Not new_Actors Then

                    If .Actors.WithImageOnly Then
                        For i = scrapedepisode.Actors.Count - 1 To 0 Step -1
                            If Not scrapedepisode.Actors(i).URLOriginalSpecified Then
                                scrapedepisode.Actors.RemoveAt(i)
                            End If
                        Next
                    End If

                    'If Master.eSettings.TVScraperEpisodeCastLimit > 0 AndAlso scrapedepisode.Actors.Count > Master.eSettings.TVScraperEpisodeCastLimit Then
                    '    scrapedepisode.Actors.RemoveRange(Master.eSettings.TVScraperEpisodeCastLimit, scrapedepisode.Actors.Count - Master.eSettings.TVScraperEpisodeCastLimit)
                    'End If

                    DBTVEpisode.MainDetails.Actors = scrapedepisode.Actors
                    'added check if there's any actors left to add, if not then try with results of following scraper...
                    If scrapedepisode.ActorsSpecified Then
                        new_Actors = True
                        'add numbers for ordering
                        Dim iOrder As Integer = 0
                        For Each actor In scrapedepisode.Actors
                            actor.Order = iOrder
                            iOrder += 1
                        Next
                    End If

                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Actors.Enabled AndAlso
                    Not .Actors.Enabled Then
                    DBTVEpisode.MainDetails.Actors.Clear()
                End If

                'Aired
                If (Not DBTVEpisode.MainDetails.AiredSpecified OrElse Not .Aired.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeAired AndAlso
                    scrapedepisode.AiredSpecified AndAlso
                    .Aired.Enabled AndAlso
                    Not new_Aired Then
                    DBTVEpisode.MainDetails.Aired = NumUtils.DateToISO8601Date(scrapedepisode.Aired)
                    new_Aired = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Aired.Enabled AndAlso
                    Not .Aired.Locked Then
                    DBTVEpisode.MainDetails.Aired = String.Empty
                End If

                'Credits
                If (Not DBTVEpisode.MainDetails.CreditsSpecified OrElse Not .Credits.Locked) AndAlso
                    scrapedepisode.CreditsSpecified AndAlso
                    .Credits.Enabled AndAlso
                    Not new_Credits Then
                    DBTVEpisode.MainDetails.Credits = scrapedepisode.Credits
                    new_Credits = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Credits.Enabled AndAlso
                    Not .Credits.Locked Then
                    DBTVEpisode.MainDetails.Credits.Clear()
                End If

                'Directors
                If (Not DBTVEpisode.MainDetails.DirectorsSpecified OrElse Not .Directors.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeDirectors AndAlso
                    scrapedepisode.DirectorsSpecified AndAlso
                    .Directors.Enabled AndAlso
                    Not new_Directors Then
                    DBTVEpisode.MainDetails.Directors = scrapedepisode.Directors
                    new_Directors = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Directors.Enabled AndAlso
                    Not .Directors.Locked Then
                    DBTVEpisode.MainDetails.Directors.Clear()
                End If

                'GuestStars
                If (Not DBTVEpisode.MainDetails.GuestStarsSpecified OrElse Not .GuestStars.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeGuestStars AndAlso
                    scrapedepisode.GuestStarsSpecified AndAlso
                    .GuestStars.Enabled AndAlso
                    Not new_GuestStars Then

                    If .GuestStars.WithImageOnly Then
                        For i = scrapedepisode.GuestStars.Count - 1 To 0 Step -1
                            If Not scrapedepisode.GuestStars(i).URLOriginalSpecified Then
                                scrapedepisode.GuestStars.RemoveAt(i)
                            End If
                        Next
                    End If

                    'If Master.eSettings.TVScraperEpisodeCastLimit > 0 AndAlso scrapedepisode.Actors.Count > Master.eSettings.TVScraperEpisodeCastLimit Then
                    '    scrapedepisode.Actors.RemoveRange(Master.eSettings.TVScraperEpisodeCastLimit, scrapedepisode.Actors.Count - Master.eSettings.TVScraperEpisodeCastLimit)
                    'End If

                    DBTVEpisode.MainDetails.GuestStars = scrapedepisode.GuestStars
                    'added check if there's any actors left to add, if not then try with results of following scraper...
                    If scrapedepisode.GuestStarsSpecified Then
                        new_GuestStars = True
                        'add numbers for ordering
                        Dim iOrder As Integer = 0
                        For Each aGuestStar In scrapedepisode.GuestStars
                            aGuestStar.Order = iOrder
                            iOrder += 1
                        Next
                    End If

                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .GuestStars.Enabled AndAlso
                    Not .GuestStars.Locked Then
                    DBTVEpisode.MainDetails.GuestStars.Clear()
                End If

                'Plot
                If (Not DBTVEpisode.MainDetails.PlotSpecified OrElse Not .Plot.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodePlot AndAlso
                    scrapedepisode.PlotSpecified AndAlso
                    .Plot.Enabled AndAlso
                    Not new_Plot Then
                    DBTVEpisode.MainDetails.Plot = scrapedepisode.Plot
                    new_Plot = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Plot.Enabled AndAlso
                    Not .Plot.Locked Then
                    DBTVEpisode.MainDetails.Plot = String.Empty
                End If

                'Rating/Votes
                If (Not DBTVEpisode.MainDetails.RatingSpecified OrElse Not .Rating.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeRating AndAlso
                    scrapedepisode.RatingSpecified AndAlso
                    .Rating.Enabled AndAlso
                    Not new_Rating Then
                    DBTVEpisode.MainDetails.Rating = scrapedepisode.Rating
                    DBTVEpisode.MainDetails.Votes = NumUtils.CleanVotes(scrapedepisode.Votes)
                    new_Rating = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Rating.Enabled AndAlso
                    Not .Rating.Locked Then
                    DBTVEpisode.MainDetails.Rating = String.Empty
                    DBTVEpisode.MainDetails.Votes = String.Empty
                End If

                'Runtime
                If (Not DBTVEpisode.MainDetails.RuntimeSpecified OrElse Not .Runtime.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeRuntime AndAlso
                    scrapedepisode.RuntimeSpecified AndAlso
                    .Runtime.Enabled AndAlso
                    Not new_Runtime Then
                    DBTVEpisode.MainDetails.Runtime = scrapedepisode.Runtime
                    new_Runtime = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Runtime.Enabled AndAlso
                    Not .Runtime.Locked Then
                    DBTVEpisode.MainDetails.Runtime = String.Empty
                End If

                'ThumbPoster
                If (Not String.IsNullOrEmpty(scrapedepisode.ThumbPoster.URLOriginal) OrElse Not String.IsNullOrEmpty(scrapedepisode.ThumbPoster.URLThumb)) AndAlso Not new_ThumbPoster Then
                    DBTVEpisode.MainDetails.ThumbPoster = scrapedepisode.ThumbPoster
                    new_ThumbPoster = True
                End If

                'Title
                If (Not DBTVEpisode.MainDetails.TitleSpecified OrElse Not .Title.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeTitle AndAlso
                   scrapedepisode.TitleSpecified AndAlso
                   .Title.Enabled AndAlso
                   Not new_Title Then
                    DBTVEpisode.MainDetails.Title = scrapedepisode.Title
                    new_Title = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .Title.Enabled AndAlso
                    Not .Title.Locked Then
                    DBTVEpisode.MainDetails.Title = String.Empty
                End If

                'USerRating
                If (Not DBTVEpisode.MainDetails.UserRatingSpecified OrElse Not .UserRating.Locked) AndAlso
                    DBTVEpisode.ScrapeOptions.bEpisodeUserRating AndAlso
                    scrapedepisode.UserRatingSpecified AndAlso
                    .UserRating.Enabled AndAlso
                    Not new_UserRating Then
                    DBTVEpisode.MainDetails.UserRating = scrapedepisode.UserRating
                    new_UserRating = True
                ElseIf Master.eSettings.TV.DataSettings.TVShow.ClearDisabledFields AndAlso
                    Not .UserRating.Enabled AndAlso
                    Not .UserRating.Locked Then
                    DBTVEpisode.MainDetails.UserRating = 0
                End If
            Next

            'Add GuestStars to Actors
            If DBTVEpisode.MainDetails.GuestStarsSpecified AndAlso
                Master.eSettings.TVScraperEpisodeGuestStarsToActors AndAlso
                Not .Actors.Locked Then
                DBTVEpisode.MainDetails.Actors.AddRange(DBTVEpisode.MainDetails.GuestStars)
            End If

            'TV Show Runtime for Episode Runtime
            If Not DBTVEpisode.MainDetails.RuntimeSpecified AndAlso
                Master.eSettings.TVScraperUseSRuntimeForEp AndAlso
                DBTVEpisode.TVShowDetails.RuntimeSpecified Then
                DBTVEpisode.MainDetails.Runtime = DBTVEpisode.TVShowDetails.Runtime
            End If
        End With

        Return DBTVEpisode
    End Function

    Public Shared Function MergeDataScraperResults_TVEpisode_Single(ByRef tDBElement As Database.DBElement, ByVal ScrapedList As List(Of MediaContainers.MainDetails)) As Database.DBElement
        Dim KnownEpisodesIndex As New List(Of KnownEpisode)

        For Each kEpisode As MediaContainers.MainDetails In ScrapedList
            Dim nKnownEpisode As New KnownEpisode With {.AiredDate = kEpisode.Aired,
                                                        .Episode = kEpisode.Episode,
                                                        .EpisodeAbsolute = kEpisode.EpisodeAbsolute,
                                                        .EpisodeCombined = kEpisode.EpisodeCombined,
                                                        .EpisodeDVD = kEpisode.EpisodeDVD,
                                                        .Season = kEpisode.Season,
                                                        .SeasonCombined = kEpisode.SeasonCombined,
                                                        .SeasonDVD = kEpisode.SeasonDVD}
            If KnownEpisodesIndex.Where(Function(f) f.Episode = nKnownEpisode.Episode AndAlso f.Season = nKnownEpisode.Season).Count = 0 Then
                KnownEpisodesIndex.Add(nKnownEpisode)

                'try to get an episode information with more numbers
            ElseIf KnownEpisodesIndex.Where(Function(f) f.Episode = nKnownEpisode.Episode AndAlso f.Season = nKnownEpisode.Season AndAlso
                        ((nKnownEpisode.EpisodeAbsolute > -1 AndAlso Not f.EpisodeAbsolute = nKnownEpisode.EpisodeAbsolute) OrElse
                         (nKnownEpisode.EpisodeCombined > -1 AndAlso Not f.EpisodeCombined = nKnownEpisode.EpisodeCombined) OrElse
                         (nKnownEpisode.EpisodeDVD > -1 AndAlso Not f.EpisodeDVD = nKnownEpisode.EpisodeDVD) OrElse
                         (nKnownEpisode.SeasonCombined > -1 AndAlso Not f.SeasonCombined = nKnownEpisode.SeasonCombined) OrElse
                         (nKnownEpisode.SeasonDVD > -1 AndAlso Not f.SeasonDVD = nKnownEpisode.SeasonDVD))).Count = 1 Then
                Dim toRemove As KnownEpisode = KnownEpisodesIndex.FirstOrDefault(Function(f) f.Episode = nKnownEpisode.Episode AndAlso f.Season = nKnownEpisode.Season)
                KnownEpisodesIndex.Remove(toRemove)
                KnownEpisodesIndex.Add(nKnownEpisode)
            End If
        Next

        If KnownEpisodesIndex.Count = 1 Then
            'convert the episode and season number if needed
            Dim iEpisode As Integer = -1
            Dim iSeason As Integer = -1
            Dim strAiredDate As String = KnownEpisodesIndex.Item(0).AiredDate
            If tDBElement.Ordering = Enums.EpisodeOrdering.Absolute Then
                iEpisode = KnownEpisodesIndex.Item(0).EpisodeAbsolute
                iSeason = 1
            ElseIf tDBElement.Ordering = Enums.EpisodeOrdering.DVD Then
                iEpisode = CInt(KnownEpisodesIndex.Item(0).EpisodeDVD)
                iSeason = KnownEpisodesIndex.Item(0).SeasonDVD
            ElseIf tDBElement.Ordering = Enums.EpisodeOrdering.Standard Then
                iEpisode = KnownEpisodesIndex.Item(0).Episode
                iSeason = KnownEpisodesIndex.Item(0).Season
            End If

            If Not iEpisode = -1 AndAlso Not iSeason = -1 Then
                MergeDataScraperResults_TVEpisode(tDBElement, ScrapedList)
                If tDBElement.MainDetails.Episode = -1 Then tDBElement.MainDetails.Episode = iEpisode
                If tDBElement.MainDetails.Season = -1 Then tDBElement.MainDetails.Season = iSeason
            Else
                logger.Warn("No valid episode or season number found")
            End If
        Else
            logger.Warn("Episode could not be clearly determined.")
        End If

        Return tDBElement
    End Function

    Public Shared Function CleanNFO_Movies(ByVal mNFO As MediaContainers.MainDetails) As MediaContainers.MainDetails
        If mNFO IsNot Nothing Then
            mNFO.Outline = mNFO.Outline.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            mNFO.Plot = mNFO.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            mNFO.ReleaseDate = NumUtils.DateToISO8601Date(mNFO.ReleaseDate)
            mNFO.Votes = NumUtils.CleanVotes(mNFO.Votes)
            If mNFO.FileInfoSpecified Then
                If mNFO.FileInfo.StreamDetails.AudioSpecified Then
                    For Each aStream In mNFO.FileInfo.StreamDetails.Audio.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                        aStream.LongLanguage = Localization.ISOGetLangByCode3(aStream.Language)
                    Next
                End If
                If mNFO.FileInfo.StreamDetails.SubtitleSpecified Then
                    For Each sStream In mNFO.FileInfo.StreamDetails.Subtitle.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                        sStream.LongLanguage = Localization.ISOGetLangByCode3(sStream.Language)
                    Next
                End If
            End If
            If mNFO.SetsSpecified Then
                For i = mNFO.Sets.Count - 1 To 0 Step -1
                    If Not mNFO.Sets(i).TitleSpecified Then
                        mNFO.Sets.RemoveAt(i)
                    End If
                Next
            End If

            'changes a LongLanguage to Alpha2 code
            If mNFO.LanguageSpecified Then
                Dim Language = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = mNFO.Language)
                If Language IsNot Nothing Then
                    mNFO.Language = Language.Abbreviation
                Else
                    'check if it's a valid Alpha2 code or remove the information the use the source default language
                    Dim ShortLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = mNFO.Language)
                    If ShortLanguage Is Nothing Then
                        mNFO.Language = String.Empty
                    End If
                End If
            End If

            Return mNFO
        Else
            Return mNFO
        End If
    End Function

    Public Shared Function CleanNFO_TVEpisodes(ByVal eNFO As MediaContainers.MainDetails) As MediaContainers.MainDetails
        If eNFO IsNot Nothing Then
            eNFO.Aired = NumUtils.DateToISO8601Date(eNFO.Aired)
            eNFO.Votes = NumUtils.CleanVotes(eNFO.Votes)
            If eNFO.FileInfoSpecified Then
                If eNFO.FileInfo.StreamDetails.AudioSpecified Then
                    For Each aStream In eNFO.FileInfo.StreamDetails.Audio.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                        aStream.LongLanguage = Localization.ISOGetLangByCode3(aStream.Language)
                    Next
                End If
                If eNFO.FileInfo.StreamDetails.SubtitleSpecified Then
                    For Each sStream In eNFO.FileInfo.StreamDetails.Subtitle.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                        sStream.LongLanguage = Localization.ISOGetLangByCode3(sStream.Language)
                    Next
                End If
            End If
            Return eNFO
        Else
            Return eNFO
        End If
    End Function

    Public Shared Function CleanNFO_TVShow(ByVal mNFO As MediaContainers.MainDetails) As MediaContainers.MainDetails
        If mNFO IsNot Nothing Then
            mNFO.Plot = mNFO.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            mNFO.Premiered = NumUtils.DateToISO8601Date(mNFO.Premiered)
            mNFO.Votes = NumUtils.CleanVotes(mNFO.Votes)

            'changes a LongLanguage to Alpha2 code
            If mNFO.LanguageSpecified Then
                Dim Language = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Name = mNFO.Language)
                If Language IsNot Nothing Then
                    mNFO.Language = Language.Abbreviation
                Else
                    'check if it's a valid Alpha2 code or remove the information the use the source default language
                    Dim ShortLanguage = APIXML.ScraperLanguagesXML.Languages.FirstOrDefault(Function(l) l.Abbreviation = mNFO.Language)
                    If ShortLanguage Is Nothing Then
                        mNFO.Language = String.Empty
                    End If
                End If
            End If

            'Boxee support
            If Master.eSettings.TV.Filenaming.TVShow.Boxee.NFO Then
                If mNFO.BoxeeTvDbSpecified AndAlso Not mNFO.TVDBSpecified Then
                    mNFO.TVDB = CInt(mNFO.BoxeeTvDb)
                    mNFO.BlankBoxeeId()
                End If
            End If

            Return mNFO
        Else
            Return mNFO
        End If
    End Function
    ''' <summary>
    ''' Delete all movie NFOs
    ''' </summary>
    ''' <param name="DBMovie"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteNFO_Movie(ByVal DBMovie As Database.DBElement, ByVal ForceFileCleanup As Boolean)
        If Not DBMovie.FilenameSpecified Then Return

        Try
            For Each a In FileUtils.GetFilenameList.Movie(DBMovie, Enums.ScrapeModifierType.MainNFO, ForceFileCleanup)
                If File.Exists(a) Then
                    File.Delete(a)
                End If
            Next
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub
    ''' <summary>
    ''' Delete all movie NFOs
    ''' </summary>
    ''' <param name="DBMovieSet"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteNFO_MovieSet(ByVal DBMovieSet As Database.DBElement, ByVal ForceFileCleanup As Boolean, Optional bForceOldTitle As Boolean = False)
        If Not DBMovieSet.MainDetails.TitleSpecified Then Return

        Try
            For Each a In FileUtils.GetFilenameList.MovieSet(DBMovieSet, Enums.ScrapeModifierType.MainNFO, bForceOldTitle)
                If File.Exists(a) Then
                    File.Delete(a)
                End If
            Next
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Function FIToString(ByVal miFI As MediaContainers.Fileinfo, ByVal isTV As Boolean) As String
        '//
        ' Convert Fileinfo into a string to be displayed in the GUI
        '\\

        Dim strOutput As New StringBuilder
        Dim iVS As Integer = 1
        Dim iAS As Integer = 1
        Dim iSS As Integer = 1

        Try
            If miFI IsNot Nothing Then

                If miFI.StreamDetails IsNot Nothing Then
                    If miFI.StreamDetails.VideoSpecified Then strOutput.AppendFormat("{0}: {1}{2}", Master.eLang.GetString(595, "Video Streams"), miFI.StreamDetails.Video.Count.ToString, Environment.NewLine)
                    If miFI.StreamDetails.AudioSpecified Then strOutput.AppendFormat("{0}: {1}{2}", Master.eLang.GetString(596, "Audio Streams"), miFI.StreamDetails.Audio.Count.ToString, Environment.NewLine)
                    If miFI.StreamDetails.SubtitleSpecified Then strOutput.AppendFormat("{0}: {1}{2}", Master.eLang.GetString(597, "Subtitle  Streams"), miFI.StreamDetails.Subtitle.Count.ToString, Environment.NewLine)
                    For Each miVideo As MediaContainers.Video In miFI.StreamDetails.Video
                        strOutput.AppendFormat("{0}{1} {2}{0}", Environment.NewLine, Master.eLang.GetString(617, "Video Stream"), iVS)
                        If miVideo.WidthSpecified AndAlso miVideo.HeightSpecified Then strOutput.AppendFormat("- {0}{1}", String.Format(Master.eLang.GetString(269, "Size: {0}x{1}"), miVideo.Width, miVideo.Height), Environment.NewLine)
                        If miVideo.AspectSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(614, "Aspect Ratio"), miVideo.Aspect, Environment.NewLine)
                        If miVideo.ScantypeSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(605, "Scan Type"), miVideo.Scantype, Environment.NewLine)
                        If miVideo.CodecSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(604, "Codec"), miVideo.Codec, Environment.NewLine)
                        If miVideo.BitrateSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", "Bitrate", miVideo.Bitrate, Environment.NewLine)
                        If miVideo.DurationSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(609, "Duration"), miVideo.Duration, Environment.NewLine)
                        'for now return filesize in mbytes instead of bytes(default)
                        If miVideo.Filesize > 0 Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(1455, "Filesize [MB]"), CStr(NumUtils.ConvertBytesTo(CLng(miVideo.Filesize), NumUtils.FileSizeUnit.Megabyte, 0)), Environment.NewLine)
                        If miVideo.LongLanguageSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(610, "Language"), miVideo.LongLanguage, Environment.NewLine)
                        If miVideo.MultiViewCountSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(1156, "MultiView Count"), miVideo.MultiViewCount, Environment.NewLine)
                        If miVideo.MultiViewLayoutSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(1157, "MultiView Layout"), miVideo.MultiViewLayout, Environment.NewLine)
                        If miVideo.StereoModeSpecified Then strOutput.AppendFormat("- {0}: {1} ({2})", Master.eLang.GetString(1286, "StereoMode"), miVideo.StereoMode, miVideo.ShortStereoMode)
                        iVS += 1
                    Next

                    strOutput.Append(Environment.NewLine)

                    For Each miAudio As MediaContainers.Audio In miFI.StreamDetails.Audio
                        'audio
                        strOutput.AppendFormat("{0}{1} {2}{0}", Environment.NewLine, Master.eLang.GetString(618, "Audio Stream"), iAS.ToString)
                        If miAudio.CodecSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(604, "Codec"), miAudio.Codec, Environment.NewLine)
                        If miAudio.ChannelsSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", Master.eLang.GetString(611, "Channels"), miAudio.Channels, Environment.NewLine)
                        If miAudio.BitrateSpecified Then strOutput.AppendFormat("- {0}: {1}{2}", "Bitrate", miAudio.Bitrate, Environment.NewLine)
                        If miAudio.LongLanguageSpecified Then strOutput.AppendFormat("- {0}: {1}", Master.eLang.GetString(610, "Language"), miAudio.LongLanguage)
                        iAS += 1
                    Next

                    strOutput.Append(Environment.NewLine)

                    For Each miSub As MediaContainers.Subtitle In miFI.StreamDetails.Subtitle
                        'subtitles
                        strOutput.AppendFormat("{0}{1} {2}{0}", Environment.NewLine, Master.eLang.GetString(619, "Subtitle Stream"), iSS.ToString)
                        If miSub.LongLanguageSpecified Then strOutput.AppendFormat("- {0}: {1}", Master.eLang.GetString(610, "Language"), miSub.LongLanguage)
                        iSS += 1
                    Next
                End If
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        If strOutput.ToString.Trim.Length > 0 Then
            Return strOutput.ToString
        Else
            If isTV Then
                Return Master.eLang.GetString(504, "Meta Data is not available for this episode. Try rescanning.")
            Else
                Return Master.eLang.GetString(419, "Meta Data is not available for this movie. Try rescanning.")
            End If
        End If
    End Function

    ''' <summary>
    ''' Return the "best" or the "prefered language" audio stream of the videofile
    ''' </summary>
    ''' <param name="tFileInfo"><c>MediaInfo.Fileinfo</c> The Mediafile-container of the videofile</param>
    ''' <returns>The best <c>MediaInfo.Audio</c> stream information of the videofile</returns>
    ''' <remarks>
    ''' This is used to determine which audio stream information should be displayed in Ember main view (icon display)
    ''' The audiostream with most channels will be returned - if there are 2 or more streams which have the same "highest" channelcount then either the "DTSHD" stream or the one with highest bitrate will be returned
    ''' 
    ''' 2014/08/12 cocotus - Should work better: If there's more than one audiostream which highest channelcount, the one with highest bitrate or the DTSHD stream will be returned
    ''' </remarks>
    Public Shared Function GetBestAudio(ByVal tFileInfo As MediaContainers.Fileinfo, ByVal ForTV As Boolean, Optional strLanguage As String = "") As MediaContainers.Audio
        Dim nFileInfo As New MediaContainers.Audio

        Dim cmiFIA As New MediaContainers.Fileinfo

        Dim getPrefLanguage As Boolean = False
        Dim hasPrefLanguage As Boolean = False
        Dim prefLanguage As String = String.Empty
        Dim sinMostChannels As Single = 0
        Dim sinChans As Single = 0
        Dim sinMostBitrate As Single = 0
        Dim sinBitrate As Single = 0
        Dim sinCodec As String = String.Empty
        nFileInfo.Codec = String.Empty
        nFileInfo.Channels = String.Empty
        nFileInfo.Language = String.Empty
        nFileInfo.LongLanguage = String.Empty
        nFileInfo.Bitrate = String.Empty

        If ForTV Then
            If Not String.IsNullOrEmpty(strLanguage) Then
                getPrefLanguage = True
                prefLanguage = strLanguage.ToLower
            End If
        Else
            If Not String.IsNullOrEmpty(strLanguage) Then
                getPrefLanguage = True
                prefLanguage = strLanguage.ToLower
            End If
        End If

        If getPrefLanguage AndAlso tFileInfo.StreamDetails.Audio.Where(Function(f) f.LongLanguage.ToLower = prefLanguage).Count > 0 Then
            For Each Stream As MediaContainers.Audio In tFileInfo.StreamDetails.Audio
                If Stream.LongLanguage.ToLower = prefLanguage Then
                    cmiFIA.StreamDetails.Audio.Add(Stream)
                End If
            Next
        Else
            cmiFIA.StreamDetails.Audio.AddRange(tFileInfo.StreamDetails.Audio)
        End If

        For Each miAudio As MediaContainers.Audio In cmiFIA.StreamDetails.Audio
            If Not String.IsNullOrEmpty(miAudio.Channels) Then
                sinChans = NumUtils.ConvertToSingle(MediaInfo.ConvertAudioChannel(miAudio.Channels))
                sinBitrate = 0
                If Integer.TryParse(miAudio.Bitrate, 0) Then
                    sinBitrate = CInt(miAudio.Bitrate)
                End If
                If sinChans >= sinMostChannels AndAlso (sinBitrate > sinMostBitrate OrElse miAudio.Codec.ToLower.Contains("dtshd") OrElse sinBitrate = 0) Then
                    If Integer.TryParse(miAudio.Bitrate, 0) Then
                        sinMostBitrate = CInt(miAudio.Bitrate)
                    End If
                    sinMostChannels = sinChans
                    nFileInfo.Bitrate = miAudio.Bitrate
                    nFileInfo.Channels = sinChans.ToString
                    nFileInfo.Codec = miAudio.Codec
                    nFileInfo.Language = miAudio.Language
                    nFileInfo.LongLanguage = miAudio.LongLanguage
                End If
            End If

            If ForTV Then
                If Not String.IsNullOrEmpty(strLanguage) AndAlso miAudio.LongLanguage.ToLower = strLanguage.ToLower Then nFileInfo.HasPreferred = True
            Else
                If Not String.IsNullOrEmpty(strLanguage) AndAlso miAudio.LongLanguage.ToLower = strLanguage.ToLower Then nFileInfo.HasPreferred = True
            End If
        Next

        Return nFileInfo
    End Function

    Public Shared Function GetBestVideo(ByVal tFileInfo As MediaContainers.Fileinfo) As MediaContainers.Video
        Dim nFileInfo As New MediaContainers.Video

        Dim iWidest As Integer = 0
        Dim iWidth As Integer = 0

        For Each miVideo As MediaContainers.Video In tFileInfo.StreamDetails.Video
            If Not String.IsNullOrEmpty(miVideo.Width) Then
                If Integer.TryParse(miVideo.Width, 0) Then
                    iWidth = Convert.ToInt32(miVideo.Width)
                Else
                    logger.Warn("[GetBestVideo] Invalid width(not a number!) of videostream: " & miVideo.Width)
                End If
                If iWidth > iWidest Then
                    iWidest = iWidth
                    nFileInfo.Width = miVideo.Width
                    nFileInfo.Height = miVideo.Height
                    nFileInfo.Aspect = miVideo.Aspect
                    nFileInfo.Codec = miVideo.Codec
                    nFileInfo.Duration = miVideo.Duration
                    nFileInfo.Scantype = miVideo.Scantype
                    nFileInfo.Language = miVideo.Language

                    'cocotus, 2013/02 Added support for new MediaInfo-fields

                    'MultiViewCount (3D) handling, simply map field
                    nFileInfo.MultiViewCount = miVideo.MultiViewCount

                    'MultiViewLayout (3D) handling, simply map field
                    nFileInfo.MultiViewLayout = miVideo.MultiViewLayout

                    'FileSize handling, simply map field
                    nFileInfo.Filesize = miVideo.Filesize

                    'Bitrate handling, simply map field
                    nFileInfo.Bitrate = miVideo.Bitrate
                    'cocotus end

                End If
            End If
        Next

        Return nFileInfo
    End Function

    Public Shared Function GetDimensionsFromVideo(ByVal fiRes As MediaContainers.Video) As String
        '//
        ' Get the dimension values of the video from the information provided by MediaInfo.dll
        '\\

        Dim result As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(fiRes.Width) AndAlso Not String.IsNullOrEmpty(fiRes.Height) AndAlso Not String.IsNullOrEmpty(fiRes.Aspect) Then
                Dim iWidth As Integer = Convert.ToInt32(fiRes.Width)
                Dim iHeight As Integer = Convert.ToInt32(fiRes.Height)
                Dim sinADR As Single = NumUtils.ConvertToSingle(fiRes.Aspect)

                result = String.Format("{0}x{1} ({2})", iWidth, iHeight, sinADR.ToString("0.00"))
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        Return result
    End Function

    Public Shared Function GetIMDBFromNonConf(ByVal sPath As String, ByVal isSingle As Boolean) As NonConf
        Dim tNonConf As New NonConf
        Dim dirPath As String = Directory.GetParent(sPath).FullName
        Dim lFiles As New List(Of String)

        If isSingle Then
            Try
                lFiles.AddRange(Directory.GetFiles(dirPath, "*.nfo"))
            Catch
            End Try
            Try
                lFiles.AddRange(Directory.GetFiles(dirPath, "*.info"))
            Catch
            End Try
        Else
            Dim fName As String = Path.GetFileNameWithoutExtension(FileUtils.Common.RemoveStackingMarkers(sPath)).ToLower
            Dim oName As String = Path.GetFileNameWithoutExtension(sPath)
            fName = If(fName.EndsWith("*"), fName, String.Concat(fName, "*"))
            oName = If(oName.EndsWith("*"), oName, String.Concat(oName, "*"))

            Try
                lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(fName, ".nfo")))
            Catch
            End Try
            Try
                lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(oName, ".nfo")))
            Catch
            End Try
            Try
                lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(fName, ".info")))
            Catch
            End Try
            Try
                lFiles.AddRange(Directory.GetFiles(dirPath, String.Concat(oName, ".info")))
            Catch
            End Try
        End If

        For Each sFile As String In lFiles
            Using srInfo As New StreamReader(sFile)
                Dim sInfo As String = srInfo.ReadToEnd
                Dim sIMDBID As String = Regex.Match(sInfo, "tt\d\d\d\d\d\d\d*", RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).ToString

                If Not String.IsNullOrEmpty(sIMDBID) Then
                    tNonConf.IMDBID = sIMDBID
                    'now lets try to see if the rest of the file is a proper nfo
                    If sInfo.ToLower.Contains("</movie>") Then
                        tNonConf.Text = APIXML.XMLToLowerCase(sInfo.Substring(0, sInfo.ToLower.IndexOf("</movie>") + 8))
                    End If
                    Exit For
                Else
                    sIMDBID = Regex.Match(sPath, "tt\d\d\d\d\d\d\d*", RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).ToString
                    If Not String.IsNullOrEmpty(sIMDBID) Then
                        tNonConf.IMDBID = sIMDBID
                    End If
                End If
            End Using
        Next
        Return tNonConf
    End Function

    Public Shared Function GetNfoPath_MovieSet(ByVal DBElement As Database.DBElement) As String
        For Each a In FileUtils.GetFilenameList.MovieSet(DBElement, Enums.ScrapeModifierType.MainNFO)
            If File.Exists(a) Then
                Return a
            End If
        Next

        Return String.Empty
    End Function
    ''' <summary>
    ''' Get the resolution of the video from the dimensions provided by MediaInfo.dll
    ''' </summary>
    ''' <param name="fiRes"></param>
    ''' <returns></returns>
    Public Shared Function GetResFromDimensions(ByVal fiRes As MediaContainers.Video) As String
        Dim resOut As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(fiRes.Width) AndAlso Not String.IsNullOrEmpty(fiRes.Height) AndAlso Not String.IsNullOrEmpty(fiRes.Aspect) Then
                Dim iWidth As Integer = Convert.ToInt32(fiRes.Width)
                Dim iHeight As Integer = Convert.ToInt32(fiRes.Height)
                Dim sinADR As Single = NumUtils.ConvertToSingle(fiRes.Aspect)

                Select Case True
                    Case iWidth < 640
                        resOut = "SD"
                    'exact
                    Case (iWidth = 3840 AndAlso iHeight = 2160) OrElse (iWidth = 3996 AndAlso iHeight = 2160) OrElse (iWidth = 4096 AndAlso iHeight = 2160) OrElse (iWidth = 5120 AndAlso iHeight = 2160)
                        resOut = "2160"
                    Case (iWidth = 2560 AndAlso iHeight = 1440)
                        resOut = "1440"
                    Case (iWidth = 1920 AndAlso (iHeight = 1080 OrElse iHeight = 800)) OrElse (iWidth = 1440 AndAlso iHeight = 1080) OrElse (iWidth = 1280 AndAlso iHeight = 1080)
                        resOut = "1080"
                    Case (iWidth = 1366 AndAlso iHeight = 768) OrElse (iWidth = 1024 AndAlso iHeight = 768)
                        resOut = "768"
                    Case (iWidth = 960 AndAlso iHeight = 720) OrElse (iWidth = 1280 AndAlso (iHeight = 720 OrElse iHeight = 544))
                        resOut = "720"
                    Case (iWidth = 1024 AndAlso iHeight = 576) OrElse (iWidth = 720 AndAlso iHeight = 576)
                        resOut = "576"
                    Case (iWidth = 720 OrElse iWidth = 960) AndAlso iHeight = 540
                        resOut = "540"
                    Case (iWidth = 852 OrElse iWidth = 720 OrElse iWidth = 704 OrElse iWidth = 640) AndAlso iHeight = 480
                        resOut = "480"
                    'by ADR
                    Case sinADR >= 1.4 AndAlso iWidth = 3840
                        resOut = "2160"
                    Case sinADR >= 1.4 AndAlso iWidth = 2560
                        resOut = "1440"
                    Case sinADR >= 1.4 AndAlso iWidth = 1920
                        resOut = "1080"
                    Case sinADR >= 1.4 AndAlso iWidth = 1366
                        resOut = "768"
                    Case sinADR >= 1.4 AndAlso iWidth = 1280
                        resOut = "720"
                    Case sinADR >= 1.4 AndAlso iWidth = 1024
                        resOut = "576"
                    Case sinADR >= 1.4 AndAlso iWidth = 960
                        resOut = "540"
                    Case sinADR >= 1.4 AndAlso iWidth = 852
                        resOut = "480"
                    'loose
                    Case iWidth > 2560 AndAlso iHeight > 1440
                        resOut = "2160"
                    Case iWidth > 1920 AndAlso iHeight > 1080
                        resOut = "1440"
                    Case iWidth >= 1200 AndAlso iHeight > 768
                        resOut = "1080"
                    Case iWidth >= 1000 AndAlso iHeight > 720
                        resOut = "768"
                    Case iWidth >= 1000 AndAlso iHeight > 500
                        resOut = "720"
                    Case iWidth >= 700 AndAlso iHeight > 540
                        resOut = "576"
                    Case iWidth >= 700 AndAlso iHeight > 480
                        resOut = "540"
                    Case Else
                        resOut = "480"
                End Select
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        If Not String.IsNullOrEmpty(resOut) Then
            If String.IsNullOrEmpty(fiRes.Scantype) Then
                Return String.Concat(resOut)
            Else
                Return String.Concat(resOut, If(fiRes.Scantype.ToLower = "progressive", "p", "i"))
            End If
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function IsConformingNFO_Movie(ByVal sPath As String) As Boolean
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "movie"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)

        Try
            If File.Exists(sPath) Then
                Using testSR As StreamReader = New StreamReader(sPath)
                    Dim testMovie As MediaContainers.MainDetails = DirectCast(xmlSer.Deserialize(testSR), MediaContainers.MainDetails)
                End Using
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Public Shared Function IsConformingNFO_TVEpisode(ByVal sPath As String) As Boolean
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "episodedetails"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
        Dim nTVEpisode As New MediaContainers.MainDetails

        Try
            If File.Exists(sPath) Then
                Using xmlSR As StreamReader = New StreamReader(sPath)
                    Dim xmlStr As String = xmlSR.ReadToEnd
                    Dim rMatches As MatchCollection = Regex.Matches(xmlStr, "<episodedetails.*?>.*?</episodedetails>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.IgnorePatternWhitespace)
                    If rMatches.Count = 1 Then
                        Using xmlRead As StringReader = New StringReader(rMatches(0).Value)
                            nTVEpisode = DirectCast(xmlSer.Deserialize(xmlRead), MediaContainers.MainDetails)
                        End Using
                        Return True
                    ElseIf rMatches.Count > 1 Then
                        'read them all... if one fails, the entire nfo is non conforming
                        For Each xmlReg As Match In rMatches
                            Using xmlRead As StringReader = New StringReader(xmlReg.Value)
                                nTVEpisode = DirectCast(xmlSer.Deserialize(xmlRead), MediaContainers.MainDetails)
                                nTVEpisode = Nothing
                            End Using
                        Next
                        Return True
                    Else
                        Return False
                    End If
                End Using
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Public Shared Function IsConformingNFO_TVShow(ByVal sPath As String) As Boolean
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "tvshow"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)

        Try
            If File.Exists(sPath) Then
                Using testSR As StreamReader = New StreamReader(sPath)
                    Dim testShow As MediaContainers.MainDetails = DirectCast(xmlSer.Deserialize(testSR), MediaContainers.MainDetails)
                End Using
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Public Shared Function LoadFromNFO_Movie(ByVal sPath As String, ByVal isSingle As Boolean) As MediaContainers.MainDetails
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "movie"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
        Dim nMovie As New MediaContainers.MainDetails

        If Not String.IsNullOrEmpty(sPath) Then
            Try
                If File.Exists(sPath) Then
                    Using xmlSR As StreamReader = New StreamReader(sPath)
                        nMovie = DirectCast(xmlSer.Deserialize(xmlSR), MediaContainers.MainDetails)
                        nMovie = CleanNFO_Movies(nMovie)
                    End Using
                Else
                    If Not String.IsNullOrEmpty(sPath) Then
                        Dim sReturn As New NonConf
                        sReturn = GetIMDBFromNonConf(sPath, isSingle)
                        nMovie.IMDB = sReturn.IMDBID
                        Try
                            If Not String.IsNullOrEmpty(sReturn.Text) Then
                                Using xmlSTR As StringReader = New StringReader(sReturn.Text)
                                    xmlSer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
                                    nMovie = DirectCast(xmlSer.Deserialize(xmlSTR), MediaContainers.MainDetails)
                                    nMovie.IMDB = sReturn.IMDBID
                                    nMovie = CleanNFO_Movies(nMovie)
                                End Using
                            End If
                        Catch
                        End Try
                    End If
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)

                nMovie.Clear()
                If Not String.IsNullOrEmpty(sPath) Then

                    'go ahead and rename it now, will still be picked up in getimdbfromnonconf
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_Movie(sPath, True)
                    End If

                    Dim sReturn As New NonConf
                    sReturn = GetIMDBFromNonConf(sPath, isSingle)
                    nMovie.IMDB = sReturn.IMDBID
                    Try
                        If Not String.IsNullOrEmpty(sReturn.Text) Then
                            Using xmlSTR As StringReader = New StringReader(sReturn.Text)
                                xmlSer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
                                nMovie = DirectCast(xmlSer.Deserialize(xmlSTR), MediaContainers.MainDetails)
                                nMovie.IMDB = sReturn.IMDBID
                                nMovie = CleanNFO_Movies(nMovie)
                            End Using
                        End If
                    Catch
                    End Try
                End If
            End Try

            If xmlSer IsNot Nothing Then
                xmlSer = Nothing
            End If
        End If

        Return nMovie
    End Function

    Public Shared Function LoadFromNFO_MovieSet(ByVal sPath As String) As MediaContainers.MainDetails
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "movieset"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
        Dim nMovieSet As New MediaContainers.MainDetails

        If Not String.IsNullOrEmpty(sPath) Then
            Try
                If File.Exists(sPath) Then
                    Using xmlSR As StreamReader = New StreamReader(sPath)
                        nMovieSet = DirectCast(xmlSer.Deserialize(xmlSR), MediaContainers.MainDetails)
                        nMovieSet.Plot = nMovieSet.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                    End Using
                    'Else
                    '    If Not String.IsNullOrEmpty(sPath) Then
                    '        Dim sReturn As New NonConf
                    '        sReturn = GetIMDBFromNonConf(sPath, isSingle)
                    '        xmlMov.IMDBID = sReturn.IMDBID
                    '        Try
                    '            If Not String.IsNullOrEmpty(sReturn.Text) Then
                    '                Using xmlSTR As StringReader = New StringReader(sReturn.Text)
                    '                    xmlSer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
                    '                    xmlMov = DirectCast(xmlSer.Deserialize(xmlSTR), MediaContainers.Movie)
                    '                    xmlMov.Genre = Strings.Join(xmlMov.LGenre.ToArray, " / ")
                    '                    xmlMov.Outline = xmlMov.Outline.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                    '                    xmlMovSet.Plot = xmlMovSet.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                    '                    xmlMov.IMDBID = sReturn.IMDBID
                    '                End Using
                    '            End If
                    '        Catch
                    '        End Try
                    '    End If
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)

                nMovieSet.Clear()
                'If Not String.IsNullOrEmpty(sPath) Then

                '    'go ahead and rename it now, will still be picked up in getimdbfromnonconf
                '    If Not Master.eSettings.GeneralOverwriteNfo Then
                '        RenameNonConfNfo(sPath, True)
                '    End If

                '    Dim sReturn As New NonConf
                '    sReturn = GetIMDBFromNonConf(sPath, isSingle)
                '    xmlMov.IMDBID = sReturn.IMDBID
                '    Try
                '        If Not String.IsNullOrEmpty(sReturn.Text) Then
                '            Using xmlSTR As StringReader = New StringReader(sReturn.Text)
                '                xmlSer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
                '                xmlMov = DirectCast(xmlSer.Deserialize(xmlSTR), MediaContainers.Movie)
                '                xmlMov.Genre = Strings.Join(xmlMov.LGenre.ToArray, " / ")
                '                xmlMov.Outline = xmlMov.Outline.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                '                xmlMovSet.Plot = xmlMovSet.Plot.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                '                xmlMov.IMDBID = sReturn.IMDBID
                '            End Using
                '        End If
                '    Catch
                '    End Try
                'End If
            End Try

            If xmlSer IsNot Nothing Then
                xmlSer = Nothing
            End If
        End If

        Return nMovieSet
    End Function

    Public Shared Function LoadFromNFO_TVEpisode(ByVal sPath As String, ByVal SeasonNumber As Integer, ByVal EpisodeNumber As Integer) As MediaContainers.MainDetails
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "episodedetails"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
        Dim nTVEpisode As New MediaContainers.MainDetails

        If Not String.IsNullOrEmpty(sPath) AndAlso SeasonNumber >= -1 Then
            Try
                If File.Exists(sPath) Then
                    'better way to read multi-root xml??
                    Using xmlSR As StreamReader = New StreamReader(sPath)
                        Dim xmlStr As String = xmlSR.ReadToEnd
                        Dim rMatches As MatchCollection = Regex.Matches(xmlStr, "<episodedetails.*?>.*?</episodedetails>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.IgnorePatternWhitespace)
                        If rMatches.Count = 1 Then
                            'only one episodedetail... assume it's the proper one
                            Using xmlRead As StringReader = New StringReader(rMatches(0).Value)
                                nTVEpisode = DirectCast(xmlSer.Deserialize(xmlRead), MediaContainers.MainDetails)
                                nTVEpisode = CleanNFO_TVEpisodes(nTVEpisode)
                                xmlSer = Nothing
                                If nTVEpisode.FileInfoSpecified Then
                                    If nTVEpisode.FileInfo.StreamDetails.AudioSpecified Then
                                        For Each aStream In nTVEpisode.FileInfo.StreamDetails.Audio.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                                            aStream.LongLanguage = Localization.ISOGetLangByCode3(aStream.Language)
                                        Next
                                    End If
                                    If nTVEpisode.FileInfo.StreamDetails.SubtitleSpecified Then
                                        For Each sStream In nTVEpisode.FileInfo.StreamDetails.Subtitle.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                                            sStream.LongLanguage = Localization.ISOGetLangByCode3(sStream.Language)
                                        Next
                                    End If
                                End If
                                Return nTVEpisode
                            End Using
                        ElseIf rMatches.Count > 1 Then
                            For Each xmlReg As Match In rMatches
                                Using xmlRead As StringReader = New StringReader(xmlReg.Value)
                                    nTVEpisode = DirectCast(xmlSer.Deserialize(xmlRead), MediaContainers.MainDetails)
                                    nTVEpisode = CleanNFO_TVEpisodes(nTVEpisode)
                                    If nTVEpisode.Episode = EpisodeNumber AndAlso nTVEpisode.Season = SeasonNumber Then
                                        xmlSer = Nothing
                                        Return nTVEpisode
                                    End If
                                End Using
                            Next
                        End If
                    End Using

                Else
                    'not really anything else to do with non-conforming nfos aside from rename them
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_TVEpisode(sPath, True)
                    End If
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)

                'not really anything else to do with non-conforming nfos aside from rename them
                If Not Master.eSettings.Options.Global.OverwriteNFO Then
                    RenameNonConfNFO_TVEpisode(sPath, True)
                End If
            End Try
        End If

        Return New MediaContainers.MainDetails
    End Function

    Public Shared Function LoadFromNFO_TVEpisode(ByVal sPath As String, ByVal SeasonNumber As Integer, ByVal Aired As String) As MediaContainers.MainDetails
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "episodedetails"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
        Dim nTVEpisode As New MediaContainers.MainDetails

        If Not String.IsNullOrEmpty(sPath) AndAlso SeasonNumber >= -1 Then
            Try
                If File.Exists(sPath) Then
                    'better way to read multi-root xml??
                    Using xmlSR As StreamReader = New StreamReader(sPath)
                        Dim xmlStr As String = xmlSR.ReadToEnd
                        Dim rMatches As MatchCollection = Regex.Matches(xmlStr, "<episodedetails.*?>.*?</episodedetails>", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.IgnorePatternWhitespace)
                        If rMatches.Count = 1 Then
                            'only one episodedetail... assume it's the proper one
                            Using xmlRead As StringReader = New StringReader(rMatches(0).Value)
                                nTVEpisode = DirectCast(xmlSer.Deserialize(xmlRead), MediaContainers.MainDetails)
                                nTVEpisode = CleanNFO_TVEpisodes(nTVEpisode)
                                xmlSer = Nothing
                                If nTVEpisode.FileInfoSpecified Then
                                    If nTVEpisode.FileInfo.StreamDetails.AudioSpecified Then
                                        For Each aStream In nTVEpisode.FileInfo.StreamDetails.Audio.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                                            aStream.LongLanguage = Localization.ISOGetLangByCode3(aStream.Language)
                                        Next
                                    End If
                                    If nTVEpisode.FileInfo.StreamDetails.SubtitleSpecified Then
                                        For Each sStream In nTVEpisode.FileInfo.StreamDetails.Subtitle.Where(Function(f) f.LanguageSpecified AndAlso Not f.LongLanguageSpecified)
                                            sStream.LongLanguage = Localization.ISOGetLangByCode3(sStream.Language)
                                        Next
                                    End If
                                End If
                                Return nTVEpisode
                            End Using
                        ElseIf rMatches.Count > 1 Then
                            For Each xmlReg As Match In rMatches
                                Using xmlRead As StringReader = New StringReader(xmlReg.Value)
                                    nTVEpisode = DirectCast(xmlSer.Deserialize(xmlRead), MediaContainers.MainDetails)
                                    nTVEpisode = CleanNFO_TVEpisodes(nTVEpisode)
                                    If nTVEpisode.Aired = Aired AndAlso nTVEpisode.Season = SeasonNumber Then
                                        xmlSer = Nothing
                                        Return nTVEpisode
                                    End If
                                End Using
                            Next
                        End If
                    End Using

                Else
                    'not really anything else to do with non-conforming nfos aside from rename them
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_TVEpisode(sPath, True)
                    End If
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)

                'not really anything else to do with non-conforming nfos aside from rename them
                If Not Master.eSettings.Options.Global.OverwriteNFO Then
                    RenameNonConfNFO_TVEpisode(sPath, True)
                End If
            End Try
        End If

        Return New MediaContainers.MainDetails
    End Function

    Public Shared Function LoadFromNFO_TVShow(ByVal sPath As String) As MediaContainers.MainDetails
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "tvshow"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)
        Dim nShow As New MediaContainers.MainDetails

        If Not String.IsNullOrEmpty(sPath) Then
            Try
                If File.Exists(sPath) Then
                    Using xmlSR As StreamReader = New StreamReader(sPath)
                        nShow = DirectCast(xmlSer.Deserialize(xmlSR), MediaContainers.MainDetails)
                        nShow = CleanNFO_TVShow(nShow)
                    End Using
                Else
                    'not really anything else to do with non-conforming nfos aside from rename them
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_TVShow(sPath)
                    End If
                End If

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)

                'not really anything else to do with non-conforming nfos aside from rename them
                If Not Master.eSettings.Options.Global.OverwriteNFO Then
                    RenameNonConfNFO_TVShow(sPath)
                End If
            End Try

            Try
                Dim params As New List(Of Object)(New Object() {nShow})
                Dim doContinue As Boolean = True
                'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.OnNFORead_TVShow, params, doContinue, False)

            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            If xmlSer IsNot Nothing Then
                xmlSer = Nothing
            End If
        End If

        Return nShow
    End Function

    Private Shared Sub RenameNonConfNFO_Movie(ByVal sPath As String, ByVal isChecked As Boolean)
        'test if current nfo is non-conforming... rename per setting

        Try
            If isChecked OrElse Not IsConformingNFO_Movie(sPath) Then
                If isChecked OrElse File.Exists(sPath) Then
                    RenameToInfo(sPath)
                End If
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Shared Sub RenameNonConfNFO_TVEpisode(ByVal sPath As String, ByVal isChecked As Boolean)
        'test if current nfo is non-conforming... rename per setting

        Try
            If File.Exists(sPath) AndAlso Not IsConformingNFO_TVEpisode(sPath) Then
                RenameToInfo(sPath)
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Shared Sub RenameNonConfNFO_TVShow(ByVal sPath As String)
        'test if current nfo is non-conforming... rename per setting

        Try
            If File.Exists(sPath) AndAlso Not IsConformingNFO_TVShow(sPath) Then
                RenameToInfo(sPath)
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Shared Sub RenameToInfo(ByVal sPath As String)
        Try
            Dim i As Integer = 1
            Dim strNewName As String = String.Concat(FileUtils.Common.RemoveExtFromPath(sPath), ".info")
            'in case there is already a .info file
            If File.Exists(strNewName) Then
                Do
                    strNewName = String.Format("{0}({1}).info", FileUtils.Common.RemoveExtFromPath(sPath), i)
                    i += 1
                Loop While File.Exists(strNewName)
                strNewName = String.Format("{0}({1}).info", FileUtils.Common.RemoveExtFromPath(sPath), i)
            End If
            My.Computer.FileSystem.RenameFile(sPath, Path.GetFileName(strNewName))
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Sub SaveToNFO_Movie(ByRef tDBElement As Database.DBElement, ByVal ForceFileCleanup As Boolean)
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "movie"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)

        Try
            Try
                Dim params As New List(Of Object)(New Object() {tDBElement})
                Dim doContinue As Boolean = True
                'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.OnNFOSave_Movie, params, doContinue, False)
                If Not doContinue Then Return
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            If tDBElement.FilenameSpecified Then
                'cleanup old NFOs if needed
                If ForceFileCleanup Then DeleteNFO_Movie(tDBElement, ForceFileCleanup)

                'Create a clone of MediaContainer to prevent changes on database data that only needed in NFO
                Dim tMovie As MediaContainers.MainDetails = CType(tDBElement.MainDetails.CloneDeep, MediaContainers.MainDetails)

                Dim doesExist As Boolean = False
                Dim fAtt As New FileAttributes
                Dim fAttWritable As Boolean = True

                'YAMJ support
                If Master.eSettings.Movie.Filenaming.YAMJ.NFO Then
                    If tMovie.TMDBSpecified Then
                        tMovie.TMDB = -1
                    End If
                End If

                'digit grouping symbol for Votes count
                If Master.eSettings.Options.Global.DigitGrpSymbolVotes Then
                    If tMovie.VotesSpecified Then
                        Dim vote As String = Double.Parse(tMovie.Votes, Globalization.CultureInfo.InvariantCulture).ToString("N0", Globalization.CultureInfo.CurrentCulture)
                        If vote IsNot Nothing Then tMovie.Votes = vote
                    End If
                End If

                For Each a In FileUtils.GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainNFO)
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_Movie(a, False)
                    End If

                    doesExist = File.Exists(a)
                    If Not doesExist OrElse (Not CBool(File.GetAttributes(a) And FileAttributes.ReadOnly)) Then
                        If doesExist Then
                            fAtt = File.GetAttributes(a)
                            Try
                                File.SetAttributes(a, FileAttributes.Normal)
                            Catch ex As Exception
                                fAttWritable = False
                            End Try
                        End If
                        Using xmlSW As New StreamWriter(a)
                            tDBElement.NfoPath = a
                            xmlSer.Serialize(xmlSW, tMovie)
                        End Using
                        If doesExist And fAttWritable Then File.SetAttributes(a, fAtt)
                    End If
                Next
            End If

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Sub SaveToNFO_MovieSet(ByRef tDBElement As Database.DBElement)
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "movieset"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)

        Try
            'Try
            '    Dim params As New List(Of Object)(New Object() {moviesetToSave})
            '    Dim doContinue As Boolean = True
            '    ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.OnMovieSetNFOSave, params, doContinue, False)
            '    If Not doContinue Then Return
            'Catch ex As Exception
            'End Try

            If Not String.IsNullOrEmpty(tDBElement.MainDetails.Title) Then
                If tDBElement.MainDetails.TitleHasChanged Then DeleteNFO_MovieSet(tDBElement, False, True)

                Dim doesExist As Boolean = False
                Dim fAtt As New FileAttributes
                Dim fAttWritable As Boolean = True

                For Each a In FileUtils.GetFilenameList.MovieSet(tDBElement, Enums.ScrapeModifierType.MainNFO)
                    'If Not Master.eSettings.GeneralOverwriteNfo Then
                    '    RenameNonConfNfo(a, False)
                    'End If

                    doesExist = File.Exists(a)
                    If Not doesExist OrElse (Not CBool(File.GetAttributes(a) And FileAttributes.ReadOnly)) Then
                        If doesExist Then
                            fAtt = File.GetAttributes(a)
                            Try
                                File.SetAttributes(a, FileAttributes.Normal)
                            Catch ex As Exception
                                fAttWritable = False
                            End Try
                        End If
                        Using xmlSW As New StreamWriter(a)
                            tDBElement.NfoPath = a
                            xmlSer.Serialize(xmlSW, tDBElement.MainDetails)
                        End Using
                        If doesExist And fAttWritable Then File.SetAttributes(a, fAtt)
                    End If
                Next
            End If

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Sub SaveToNFO_TVEpisode(ByRef tDBElement As Database.DBElement)
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "episodedetails"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)

        Try
            If tDBElement.FilenameSpecified Then
                'Create a clone of MediaContainer to prevent changes on database data that only needed in NFO
                Dim tTVEpisode As MediaContainers.MainDetails = CType(tDBElement.MainDetails.CloneDeep, MediaContainers.MainDetails)

                Dim doesExist As Boolean = False
                Dim fAtt As New FileAttributes
                Dim fAttWritable As Boolean = True
                Dim EpList As New List(Of MediaContainers.MainDetails)
                Dim sBuilder As New StringBuilder

                For Each a In FileUtils.GetFilenameList.TVEpisode(tDBElement, Enums.ScrapeModifierType.EpisodeNFO)
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_TVEpisode(a, False)
                    End If

                    doesExist = File.Exists(a)
                    If Not doesExist OrElse (Not CBool(File.GetAttributes(a) And FileAttributes.ReadOnly)) Then

                        If doesExist Then
                            fAtt = File.GetAttributes(a)
                            Try
                                File.SetAttributes(a, FileAttributes.Normal)
                            Catch ex As Exception
                                fAttWritable = False
                            End Try
                        End If

                        Using SQLCommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                            SQLCommand.CommandText = "SELECT idEpisode FROM episode WHERE idEpisode <> (?) AND idFile IN (SELECT idFile FROM files WHERE strFilename = (?)) ORDER BY Episode"
                            Dim parID As SQLite.SQLiteParameter = SQLCommand.Parameters.Add("parID", DbType.Int64, 0, "idEpisode")
                            Dim parFilename As SQLite.SQLiteParameter = SQLCommand.Parameters.Add("parFilename", DbType.String, 0, "strFilename")

                            parID.Value = tDBElement.ID
                            parFilename.Value = tDBElement.FileItem.FullPath

                            Using SQLreader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader
                                While SQLreader.Read
                                    EpList.Add(Master.DB.Load_TVEpisode(Convert.ToInt64(SQLreader("idEpisode")), False).MainDetails)
                                End While
                            End Using

                            EpList.Add(tTVEpisode)

                            Dim NS As New XmlSerializerNamespaces
                            NS.Add(String.Empty, String.Empty)

                            For Each tvEp As MediaContainers.MainDetails In EpList.OrderBy(Function(s) s.Season).OrderBy(Function(e) e.Episode)

                                'digit grouping symbol for Votes count
                                If Master.eSettings.Options.Global.DigitGrpSymbolVotes Then
                                    If tvEp.VotesSpecified Then
                                        Dim vote As String = Double.Parse(tvEp.Votes, Globalization.CultureInfo.InvariantCulture).ToString("N0", Globalization.CultureInfo.CurrentCulture)
                                        If vote IsNot Nothing Then tvEp.Votes = vote
                                    End If
                                End If

                                'removing <displayepisode> and <displayseason> if disabled
                                If Not Master.eSettings.TVScraperUseDisplaySeasonEpisode Then
                                    tvEp.DisplayEpisode = -1
                                    tvEp.DisplaySeason = -1
                                End If

                                Using xmlSW As New Utf8StringWriter
                                    xmlSer.Serialize(xmlSW, tvEp, NS)
                                    If sBuilder.Length > 0 Then
                                        sBuilder.Append(Environment.NewLine)
                                        xmlSW.GetStringBuilder.Remove(0, xmlSW.GetStringBuilder.ToString.IndexOf(Environment.NewLine) + 1)
                                    End If
                                    sBuilder.Append(xmlSW.ToString)
                                End Using
                            Next

                            tDBElement.NfoPath = a

                            If sBuilder.Length > 0 Then
                                Using fSW As New StreamWriter(a)
                                    fSW.Write(sBuilder.ToString)
                                End Using
                            End If
                        End Using
                        If doesExist And fAttWritable Then File.SetAttributes(a, fAtt)
                    End If
                Next
            End If

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Sub SaveToNFO_TVShow(ByRef tDBElement As Database.DBElement)
        Dim xmlRootAtt As New XmlRootAttribute With {.ElementName = "tvshow"}
        Dim xmlSer As XmlSerializer = New XmlSerializer(GetType(MediaContainers.MainDetails), xmlRootAtt)

        Try
            Dim params As New List(Of Object)(New Object() {tDBElement})
            Dim doContinue As Boolean = True
            'AddonsManager.Instance.RunGeneric(Enums.AddonEventType.OnNFOSave_TVShow, params, doContinue, False)
            If Not doContinue Then Return
        Catch ex As Exception
        End Try

        Try
            If tDBElement.ShowPathSpecified Then
                'Create a clone of MediaContainer to prevent changes on database data that only needed in NFO
                Dim tTVShow As MediaContainers.MainDetails = CType(tDBElement.MainDetails.CloneDeep, MediaContainers.MainDetails)

                Dim doesExist As Boolean = False
                Dim fAtt As New FileAttributes
                Dim fAttWritable As Boolean = True

                'Boxee support
                If Master.eSettings.TV.Filenaming.TVShow.Boxee.NFO Then
                    If tTVShow.TVDBSpecified() Then
                        tTVShow.BoxeeTvDb = CStr(tTVShow.TVDB)
                        tTVShow.BlankId()
                    End If
                End If

                'digit grouping symbol for Votes count
                If Master.eSettings.Options.Global.DigitGrpSymbolVotes Then
                    If tTVShow.VotesSpecified Then
                        Dim vote As String = Double.Parse(tTVShow.Votes, Globalization.CultureInfo.InvariantCulture).ToString("N0", Globalization.CultureInfo.CurrentCulture)
                        If vote IsNot Nothing Then tTVShow.Votes = vote
                    End If
                End If

                For Each a In FileUtils.GetFilenameList.TVShow(tDBElement, Enums.ScrapeModifierType.MainNFO)
                    If Not Master.eSettings.Options.Global.OverwriteNFO Then
                        RenameNonConfNFO_TVShow(a)
                    End If

                    doesExist = File.Exists(a)
                    If Not doesExist OrElse (Not CBool(File.GetAttributes(a) And FileAttributes.ReadOnly)) Then

                        If doesExist Then
                            fAtt = File.GetAttributes(a)
                            Try
                                File.SetAttributes(a, FileAttributes.Normal)
                            Catch ex As Exception
                                fAttWritable = False
                            End Try
                        End If

                        Using xmlSW As New StreamWriter(a)
                            tDBElement.NfoPath = a
                            xmlSer.Serialize(xmlSW, tTVShow)
                        End Using

                        If doesExist And fAttWritable Then File.SetAttributes(a, fAtt)
                    End If
                Next
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class NonConf

#Region "Fields"

        Private _imdbid As String
        Private _text As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        Public Property IMDBID() As String
            Get
                Return _imdbid
            End Get
            Set(ByVal value As String)
                _imdbid = value
            End Set
        End Property

        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _imdbid = String.Empty
            _text = String.Empty
        End Sub

#End Region 'Methods

    End Class

    Public Class KnownEpisode

#Region "Fields"

        Private _aireddate As String
        Private _episode As Integer
        Private _episodeabsolute As Integer
        Private _episodecombined As Double
        Private _episodedvd As Double
        Private _season As Integer
        Private _seasoncombined As Integer
        Private _seasondvd As Integer

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        Public Property AiredDate() As String
            Get
                Return _aireddate
            End Get
            Set(ByVal value As String)
                _aireddate = value
            End Set
        End Property

        Public Property Episode() As Integer
            Get
                Return _episode
            End Get
            Set(ByVal value As Integer)
                _episode = value
            End Set
        End Property

        Public Property EpisodeAbsolute() As Integer
            Get
                Return _episodeabsolute
            End Get
            Set(ByVal value As Integer)
                _episodeabsolute = value
            End Set
        End Property

        Public Property EpisodeCombined() As Double
            Get
                Return _episodecombined
            End Get
            Set(ByVal value As Double)
                _episodecombined = value
            End Set
        End Property

        Public Property EpisodeDVD() As Double
            Get
                Return _episodedvd
            End Get
            Set(ByVal value As Double)
                _episodedvd = value
            End Set
        End Property

        Public Property Season() As Integer
            Get
                Return _season
            End Get
            Set(ByVal value As Integer)
                _season = value
            End Set
        End Property

        Public Property SeasonCombined() As Integer
            Get
                Return _seasoncombined
            End Get
            Set(ByVal value As Integer)
                _seasoncombined = value
            End Set
        End Property

        Public Property SeasonDVD() As Integer
            Get
                Return _seasondvd
            End Get
            Set(ByVal value As Integer)
                _seasondvd = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _aireddate = String.Empty
            _episode = -1
            _episodeabsolute = -1
            _episodecombined = -1
            _episodedvd = -1
            _season = -1
            _seasoncombined = -1
            _seasondvd = -1
        End Sub

#End Region 'Methods

    End Class

    Public NotInheritable Class Utf8StringWriter
        Inherits StringWriter
        Public Overloads Overrides ReadOnly Property Encoding() As Encoding
            Get
                Return Encoding.UTF8
            End Get
        End Property
    End Class

#End Region 'Nested Types

End Class