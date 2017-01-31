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

Public Class Scraper

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Methods"

    Public Function Scrape_Movie(ByVal strTitle As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
        Dim nAddonResult As New Interfaces.AddonResult
        If tScrapeModifiers.MainTheme Then
            'nAddonResult.ScraperResult_Themes = YouTube.Scraper.SearchOnYouTube(String.Concat(strTitle, " ", Master.eSettings.MovieTrailerDefaultSearch))
            'For Each nTheme In nAddonResult.ScraperResult_Themes
            '    nTheme.Scraper = "YouTube"
            'Next
        End If
        If tScrapeModifiers.MainTrailer Then
            nAddonResult.ScraperResult_Trailers = EmberAPI.YouTube.Scraper.SearchOnYouTube(String.Concat(strTitle, " ", Master.eSettings.MovieTrailerDefaultSearch))
            For Each nTrailer In nAddonResult.ScraperResult_Trailers
                nTrailer.Scraper = "YouTube"
            Next
        End If
        Return nAddonResult
    End Function

    Public Function Scrape_TVShow(ByVal strTitle As String, ByVal tScrapeModifiers As Structures.ScrapeModifiers, ByVal tScrapeOptions As Structures.ScrapeOptions) As Interfaces.AddonResult
        Dim nAddonResult As New Interfaces.AddonResult
        If tScrapeModifiers.MainTheme Then
            'nAddonResult.ScraperResult_Themes = YouTube.Scraper.SearchOnYouTube(String.Concat(strTitle, " ", Master.eSettings.MovieTrailerDefaultSearch))
            'For Each nTheme In nAddonResult.ScraperResult_Themes
            '    nTheme.Scraper = "YouTube"
            'Next
        End If
        Return nAddonResult
    End Function

#End Region 'Methods

End Class