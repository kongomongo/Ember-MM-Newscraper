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

Public Class Scraper

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Events"

    Public Event ScraperProgressUpdate(ByVal eProgressValue As ProgressValue)

#End Region 'Events

#Region "Properties"

#End Region 'Properties

#Region "Methods"

    'Public Function Search(ByRef tDBElement As Database.DBElement) As Boolean
    '    logger.Trace(String.Format("[Scraper] [Search] [Start] {0}", tDBElement.Filename))
    '    If tDBElement.IsOnline Then

    '    End If
    '    logger.Trace(String.Format("[Scraper] [Search] [Done] {0}", tDBElement.Filename))
    'End Function

    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[Scraper] [Run] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(tDBElement, bShowMessage) Then
            If tDBElement.MainDetails.AnyUniqueIDSpecified Then
                'Dim nSearchResults As AddonsManager.ScrapeResults = AddonsManager.Instance.Search(tDBElement)
                Dim nScrapeResults As AddonsManager.ScrapeResults = AddonsManager.Instance.Scrape(tDBElement)
                If Not nScrapeResults.bCancelled AndAlso Not nScrapeResults.bError Then

                    'If "Use Preview Datascraperresults" option is enabled, a preview window which displays all datascraperresults will be opened before showing the Edit Movie page!
                    If (tDBElement.ScrapeType = Enums.ScrapeType.SingleScrape OrElse tDBElement.ScrapeType = Enums.ScrapeType.SingleField) AndAlso Master.eSettings.MovieScraperUseDetailView AndAlso nScrapeResults.lstData.Count > 0 Then
                        PreviewDataScraperResults_Movie(nScrapeResults.lstData)
                    End If

                    'Merge scraperresults considering global datascraper settings
                    tDBElement = NFO.MergeDataScraperResults_Movie(tDBElement, nScrapeResults.lstData)

                    'Sort images
                    nScrapeResults.lstImages.SortAndFilter(tDBElement)

                    'Create cache paths
                    tDBElement.MainDetails.CreateCachePaths_ActorsThumbs()
                    nScrapeResults.lstImages.CreateCachePaths(tDBElement)
                    RaiseEvent ScraperProgressUpdate(New ProgressValue With {.DBElement = tDBElement, .EventType = Enums.ScraperEventType.ShowScrapeResults})
                Else

                End If
            End If
        Else
            logger.Trace(String.Format("[Scraper] [Run] [Abort] [Offline] {0}", tDBElement.Filename))
            Return False
        End If

        logger.Trace(String.Format("[Scraper] [Run] [Done] {0}", tDBElement.Filename))
        Return True
    End Function

    ''' <summary>
    ''' Open MovieDataScraperPreview Window
    ''' </summary>
    ''' <param name="ScrapedList"><c>List(Of MediaContainers.Movie)</c> which contains unfiltered results of each data scraper</param>
    ''' <remarks>
    ''' 2014/09/13 Cocotus - First implementation: Display all scrapedresults in preview window, so that user can select the information which should be used
    ''' </remarks>
    Public Shared Sub PreviewDataScraperResults_Movie(ByRef ScrapedList As List(Of MediaContainers.MainDetails))
        Try
            'Open/Show preview window
            Using dlgMovieDataScraperPreview As New dlgMovieDataScraperPreview(ScrapedList)
                Select Case dlgMovieDataScraperPreview.ShowDialog()
                    Case Windows.Forms.DialogResult.OK
                        'For now nothing here
                End Select
            End Using
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Structure ProgressValue

#Region "Fields"

        Dim DBElement As Database.DBElement
        Dim EventType As Enums.ScraperEventType
        Dim ID As Long
        Dim Message As String

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class

Public Class ScraperProperties

#Region "Fields"

    Private _lstScraperCapatibilities As New List(Of Enums.ScraperCapatibility)
    Private _strAssemblyName As String
    Private _strName As String

#End Region 'Fields

#Region "Properties"

    Public Property AssemblyName() As String
        Get
            Return _strAssemblyName
        End Get
        Set(ByVal value As String)
            _strAssemblyName = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _strName
        End Get
        Set(ByVal value As String)
            _strName = value
        End Set
    End Property

    Public Property ScraperCapatibilities() As List(Of Enums.ScraperCapatibility)
        Get
            Return _lstScraperCapatibilities
        End Get
        Set(ByVal value As List(Of Enums.ScraperCapatibility))
            _lstScraperCapatibilities = value
        End Set
    End Property

#End Region 'Properties

#Region "Constructors"

    Public Sub New(ByVal strAssemblyName As String, ByVal strName As String, ByVal lstScraperCapatibilities As List(Of Enums.ScraperCapatibility))
        _lstScraperCapatibilities = lstScraperCapatibilities
        _strAssemblyName = strAssemblyName
        _strName = strName
    End Sub

#End Region 'Constructors

#Region "Methods"

#End Region 'Methods

End Class

Public Class SearchEngineProperties

#Region "Fields"

    Private _bSearchMovie As Boolean
    Private _bSearchMovieset As Boolean
    Private _bSearchTVEpisode As Boolean
    Private _bSearchTVSeason As Boolean
    Private _bSearchTVShow As Boolean
    Private _strAssemblyName As String
    Private _strName As String

#End Region 'Fields

#Region "Properties"

    Public Property AssemblyName() As String
        Get
            Return _strAssemblyName
        End Get
        Set(ByVal value As String)
            _strAssemblyName = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _strName
        End Get
        Set(ByVal value As String)
            _strName = value
        End Set
    End Property

    Public Property SearchMovie() As Boolean
        Get
            Return _bSearchMovie
        End Get
        Set(ByVal value As Boolean)
            _bSearchMovie = value
        End Set
    End Property

    Public Property SearchMovieSet() As Boolean
        Get
            Return _bSearchMovieset
        End Get
        Set(ByVal value As Boolean)
            _bSearchMovieset = value
        End Set
    End Property

    Public Property SearchTVEpisode() As Boolean
        Get
            Return _bSearchTVEpisode
        End Get
        Set(ByVal value As Boolean)
            _bSearchTVEpisode = value
        End Set
    End Property

    Public Property SearchTVSeason() As Boolean
        Get
            Return _bSearchTVSeason
        End Get
        Set(ByVal value As Boolean)
            _bSearchTVSeason = value
        End Set
    End Property

    Public Property SearchTVShow() As Boolean
        Get
            Return _bSearchTVShow
        End Get
        Set(ByVal value As Boolean)
            _bSearchTVShow = value
        End Set
    End Property

#End Region 'Properties

#Region "Constructors"

    Public Sub New(ByVal strAssemblyName As String, ByVal strName As String, ByVal lstSearchEngineCapatibilities As List(Of Enums.AddonEventType))
        If lstSearchEngineCapatibilities.Contains(Enums.AddonEventType.Search_Movie) Then _bSearchMovie = True
        If lstSearchEngineCapatibilities.Contains(Enums.AddonEventType.Search_MovieSet) Then _bSearchMovieset = True
        If lstSearchEngineCapatibilities.Contains(Enums.AddonEventType.Search_TVEpisode) Then _bSearchTVEpisode = True
        If lstSearchEngineCapatibilities.Contains(Enums.AddonEventType.Search_TVSeason) Then _bSearchTVSeason = True
        If lstSearchEngineCapatibilities.Contains(Enums.AddonEventType.Search_TVShow) Then _bSearchTVShow = True
        _strAssemblyName = strAssemblyName
        _strName = strName
    End Sub

#End Region 'Constructors

#Region "Methods"

#End Region 'Methods

End Class