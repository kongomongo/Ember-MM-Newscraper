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

    Public Shared Function Run(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[Scraper] [Run] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(tDBElement, bShowMessage) Then
            If tDBElement.MainDetails.AnyUniqueIDSpecified Then
                Dim nSearchResults As AddonsManager.ScrapeResults = AddonsManager.Instance.Search(tDBElement)
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

#End Region 'Nested Types

End Class
