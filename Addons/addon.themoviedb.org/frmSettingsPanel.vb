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

Public Class frmSettingsPanel

#Region "Events"

    Public Event NeedsRestart()
    Public Event SettingsChanged()

#End Region 'Events

#Region "Methods"

    Public Sub New()
        InitializeComponent()
        SetUp()
    End Sub

    Private Sub Apply(ByVal sender As Object, ByVal e As EventArgs) Handles _
            chkFallBackToEng_Movie.CheckedChanged,
            chkFallBackToEng_MovieSet.CheckedChanged,
            chkFallBackToEng_TV.CheckedChanged,
            chkIncludeAdultItems_Movie.CheckedChanged,
            chkIncludeAdultItems_MovieSet.CheckedChanged,
            chkIncludeAdultItems_TV.CheckedChanged,
            chkSearchDeviant_Movie.CheckedChanged,
            txtApiKey.TextChanged

        RaiseEvent SettingsChanged()
    End Sub

    Private Sub pbApiKeyInfo_Click(sender As Object, e As EventArgs) Handles pbApiKeyInfo.Click
        Functions.Launch(My.Resources.urlAPIKey)
    End Sub

    Private Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click
        Functions.Launch(My.Resources.urlWebsite)
    End Sub

    Private Sub SetUp()
        chkFallBackToEng_Movie.Text = Master.eLang.GetString(922, "Fallback to english")
        chkFallBackToEng_MovieSet.Text = chkFallBackToEng_Movie.Text
        chkFallBackToEng_TV.Text = chkFallBackToEng_Movie.Text
        chkIncludeAdultItems_Movie.Text = Master.eLang.GetString(1046, "Include Adult Items")
        chkIncludeAdultItems_MovieSet.Text = chkIncludeAdultItems_Movie.Text
        chkIncludeAdultItems_TV.Text = chkIncludeAdultItems_Movie.Text
        chkSearchDeviant_Movie.Text = Master.eLang.GetString(98, "Search -/+ 1 year if no search result was found")
        gbGlobal.Text = Master.eLang.GetString(172, "Global")
        gbMovie.Text = Master.eLang.GetString(1379, "Movie")
        gbMovieSet.Text = Master.eLang.GetString(1381, "MovieSet")
        gbTVShow.Text = Master.eLang.GetString(700, "TV Show")
        lblApiKey.Text = String.Concat(Master.eLang.GetString(870, "TMDB API Key"), ":")
        txtApiKey.WatermarkText = Master.eLang.GetString(1189, "Ember Media Manager Embedded API Key")
    End Sub

#End Region 'Methods

End Class