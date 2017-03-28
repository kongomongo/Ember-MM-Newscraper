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
Imports System.IO
Imports System.Xml.Serialization

<XmlType(AnonymousType:=True),
 XmlRoot([Namespace]:="", IsNullable:=False, ElementName:="Settings")>
Public Class ManagerSettings

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Properties"

    Public Property General() As New SettingsContainer_General
    Public Property Movie() As New SettingsContainer_Movie
    Public Property Movieset() As New SettingsContainer_Movieset
    Public Property TV() As New SettingsContainer_TV

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub Load()

    End Sub

    Public Sub Save()
        Try
            Dim xmlSerial As New XmlSerializer(GetType(ManagerSettings))
            Dim xmlWriter As New StreamWriter(Path.Combine(Master.SettingsPath, "Settings.xml"))
            xmlSerial.Serialize(xmlWriter, Me)
            xmlWriter.Close()
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        General = New SettingsContainer_General
        Movie = New SettingsContainer_Movie
        Movieset = New SettingsContainer_Movieset
        TV = New SettingsContainer_TV
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class CustomMarkerSpecification

#Region "Properties"

    Public Property Color() As Integer
    Public Property Name() As String

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Color = -1
        Name = String.Empty
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class CustomScrapeButtonSpecification

#Region "Properties"

    Public Property Enabled() As Boolean
    Public Property ModifierType() As Enums.ScrapeModifierType
    Public Property ScrapeType() As Enums.ScrapeType

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Enabled = False
        ModifierType = Enums.ScrapeModifierType.All
        ScrapeType = Enums.ScrapeType.NewSkip
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class FilterSettings

#Region "Properties"

    Public Property Missing() As New FilterMissingSpecification
    Public Property PanelIsRaised() As Boolean
    Public Property SortColumn As Integer
    Public Property SortOrder As Integer

#End Region 'Properties

#Region "Constructors"

    Public Sub New(ByVal tContentType As Enums.ContentType)
        SetDefaults(tContentType)
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults(ByVal tContentType As Enums.ContentType)
        Missing = New FilterMissingSpecification
        PanelIsRaised = False
        SortOrder = 0

        Select Case tContentType
            Case Enums.ContentType.Movie
                SortColumn = 3
            Case Enums.ContentType.Movieset
                SortColumn = 1
            Case Enums.ContentType.TV, Enums.ContentType.TVEpisode, Enums.ContentType.TVSeason, Enums.ContentType.TVShow
                SortColumn = 1
        End Select
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class FilterSettings_TV

#Region "Properties"

    Public Property Missing() As New FilterMissingSpecification
    Public Property PanelIsRaised() As Boolean

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Missing = New FilterMissingSpecification
        PanelIsRaised = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class FilterMissingSpecification

#Region "Properties"

    Public Property Actorthumbs() As Boolean
    Public Property Banner() As Boolean
    Public Property CharacterArt() As Boolean
    Public Property ClearArt() As Boolean
    Public Property ClearLogo() As Boolean
    Public Property DiscArt() As Boolean
    Public Property Extrafanarts() As Boolean
    Public Property Extrathumbs() As Boolean
    Public Property Fanart() As Boolean
    Public Property Landscape() As Boolean
    Public Property NFO() As Boolean
    Public Property Poster() As Boolean
    Public Property Subtitles() As Boolean
    Public Property Theme() As Boolean
    Public Property Trailer() As Boolean

    <XmlIgnore()>
    Public ReadOnly Property AnyEnabled() As Boolean
        Get
            Return _
                Actorthumbs OrElse
                Banner OrElse
                CharacterArt OrElse
                ClearArt OrElse
                ClearLogo OrElse
                DiscArt OrElse
                Extrafanarts OrElse
                Extrathumbs OrElse
                Fanart OrElse
                Landscape OrElse
                NFO OrElse
                Poster OrElse
                Subtitles OrElse
                Theme OrElse
                Trailer
        End Get
    End Property


#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Actorthumbs = False
        Banner = False
        CharacterArt = False
        ClearArt = False
        ClearLogo = False
        DiscArt = False
        Extrafanarts = False
        Extrathumbs = False
        Fanart = False
        Landscape = False
        NFO = False
        Poster = False
        Subtitles = False
        Theme = False
        Trailer = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class GUISettings

#Region "Properties"

    Public Property ClickScrape As Boolean
    Public Property ClickScrapeAsk As Boolean
    Public Property CustomMarker1 As New CustomMarkerSpecification
    Public Property CustomMarker2 As New CustomMarkerSpecification
    Public Property CustomMarker3 As New CustomMarkerSpecification
    Public Property CustomMarker4 As New CustomMarkerSpecification
    Public Property CustomScrapeButton As New CustomScrapeButtonSpecification
    Public Property InfoPanelState() As Integer
    Public Property MediaListSorting As New MediaListSortingSpecification

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        ClickScrape = False
        ClickScrapeAsk = False
        CustomMarker1 = New CustomMarkerSpecification With {.Color = -32704}
        CustomMarker2 = New CustomMarkerSpecification With {.Color = -16776961}
        CustomMarker3 = New CustomMarkerSpecification With {.Color = -12582784}
        CustomMarker4 = New CustomMarkerSpecification With {.Color = -16711681}
        CustomScrapeButton = New CustomScrapeButtonSpecification
        InfoPanelState = 200
        MediaListSorting = New MediaListSortingSpecification
    End Sub

#End Region 'Methods 

End Class


<Serializable()>
Public Class GUISettings_TV

#Region "Properties"

    Public Property CustomScrapeButton As New CustomScrapeButtonSpecification
    Public Property InfoPanelState() As Integer

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        CustomScrapeButton = New CustomScrapeButtonSpecification
        InfoPanelState = 200
    End Sub

#End Region 'Methods

End Class

Public Class MediaListSortingSpecification
    Inherits List(Of MediaListSortingItemSpecification)

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub SetDefaults(ByVal tContentType As Enums.ContentType, ByVal bForce As Boolean)
        Select Case tContentType
            Case Enums.ContentType.Movie
                Clear()
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 1, .Hide = True, .Column = "OriginalTitle", .LabelID = 302, .LabelText = "Original Title"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 2, .Hide = True, .Column = "Year", .LabelID = 278, .LabelText = "Year"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 3, .Hide = True, .Column = "MPAA", .LabelID = 401, .LabelText = "MPAA"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 4, .Hide = True, .Column = "Rating", .LabelID = 400, .LabelText = "Rating"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 5, .Hide = True, .Column = "Top250", .LabelID = -1, .LabelText = "Top250"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 6, .Hide = True, .Column = "IMDB", .LabelID = 61, .LabelText = "IMDB ID"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 7, .Hide = True, .Column = "TMDB", .LabelID = 933, .LabelText = "TMDB ID"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 8, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 9, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 10, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 11, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 12, .Hide = False, .Column = "DiscArtPath", .LabelID = 1098, .LabelText = "DiscArt"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 13, .Hide = False, .Column = "EFanartsPath", .LabelID = 992, .LabelText = "Extrafanarts"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 14, .Hide = False, .Column = "EThumbsPath", .LabelID = 153, .LabelText = "Extrathumbs"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 15, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 16, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 17, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 18, .Hide = False, .Column = "HasSub", .LabelID = 152, .LabelText = "Subtitles"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 19, .Hide = False, .Column = "ThemePath", .LabelID = 1118, .LabelText = "Theme"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 20, .Hide = False, .Column = "TrailerPath", .LabelID = 151, .LabelText = "Trailer"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 21, .Hide = False, .Column = "HasSet", .LabelID = 1295, .LabelText = "Part of a MovieSet"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 22, .Hide = False, .Column = "LastPlayed", .LabelID = 981, .LabelText = "Watched"})
            Case Enums.ContentType.Movieset
                Clear()
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 1, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 2, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 3, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 4, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 5, .Hide = False, .Column = "DiscArtPath", .LabelID = 1098, .LabelText = "DiscArt"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 6, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 7, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 8, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
            Case Enums.ContentType.TVEpisode
                Clear()
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 0, .Hide = False, .Column = "Title", .LabelID = 21, .LabelText = "Title"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 1, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 2, .Hide = True, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 3, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 4, .Hide = False, .Column = "HasSub", .LabelID = 152, .LabelText = "Subtitles"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 5, .Hide = False, .Column = "Playcount", .LabelID = 981, .LabelText = "Watched"})
            Case Enums.ContentType.TVSeason
                Clear()
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 0, .Hide = False, .Column = "SeasonText", .LabelID = 650, .LabelText = "Season"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 1, .Hide = True, .Column = "Episodes", .LabelID = 682, .LabelText = "Episodes"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 2, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 3, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 4, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 5, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 6, .Hide = False, .Column = "HasWatched", .LabelID = 981, .LabelText = "Watched"})
            Case Enums.ContentType.TVShow
                Clear()
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 1, .Hide = True, .Column = "OriginalTitle", .LabelID = 302, .LabelText = "Original Title"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 2, .Hide = True, .Column = "Status", .LabelID = 215, .LabelText = "Status"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 3, .Hide = True, .Column = "Episodes", .LabelID = 682, .LabelText = "Episodes"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 4, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 5, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 6, .Hide = False, .Column = "CharacterArtPath", .LabelID = 1140, .LabelText = "CharacterArt"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 7, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 8, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 9, .Hide = False, .Column = "EFanartsPath", .LabelID = 992, .LabelText = "Extrafanarts"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 10, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 11, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 12, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 13, .Hide = False, .Column = "ThemePath", .LabelID = 1118, .LabelText = "Theme"})
                Add(New MediaListSortingItemSpecification With {.DisplayIndex = 14, .Hide = False, .Column = "HasWatched", .LabelID = 981, .LabelText = "Watched"})
        End Select
    End Sub

#End Region 'Methods

End Class

Public Class MediaListSortingItemSpecification

#Region "Properties"
    ''' <summary>
    ''' Column name in database (need to be exactly like column name in DB)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Column() As String

    Public Property DisplayIndex() As Integer
    ''' <summary>
    ''' Hide or show column in media lists
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hide() As Boolean
    ''' <summary>
    ''' ID of string in Master.eLangs.GetString
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LabelID() As Integer
    ''' <summary>
    ''' Default text for the LabelID in Master.eLangs.GetString
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LabelText() As String

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub Clear()
        Column = String.Empty
        DisplayIndex = -1
        Hide = False
        LabelID = 1
        LabelText = String.Empty
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_General

#Region "Properties"

    Public Property DisplayBanner() As Boolean
    Public Property DisplayCharacterArt() As Boolean
    Public Property DisplayClearArt() As Boolean
    Public Property DisplayClearLogo() As Boolean
    Public Property DisplayDiscArt() As Boolean
    Public Property DisplayFanart() As Boolean
    Public Property DisplayFanartSmall() As Boolean
    Public Property DisplayGenreText As Boolean
    Public Property DisplayImageDimensions As Boolean
    Public Property DisplayImageNames As Boolean
    Public Property DisplayLandscape() As Boolean
    Public Property DisplayLanguageFlags As Boolean
    Public Property DisplayPoster() As Boolean
    Public Property DoubleClickScrape As Boolean
    Public Property SplitterDistanceMain() As Integer
    Public Property SplitterDistanceTVSeason() As Integer
    Public Property SplitterDistanceTVShow() As Integer
    Public Property ThemeMovie As String
    Public Property ThemeMovieset As String
    Public Property ThemeTVEpisode As String
    Public Property ThemeTVShow As String
    Public Property WindowLocation() As Point
    Public Property WindowSize As Size
    Public Property WindowState As FormWindowState

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        DisplayBanner = True
        DisplayCharacterArt = True
        DisplayClearArt = True
        DisplayClearLogo = True
        DisplayDiscArt = True
        DisplayFanart = True
        DisplayFanartSmall = True
        DisplayGenreText = True
        DisplayImageDimensions = True
        DisplayImageNames = True
        DisplayLandscape = True
        DisplayLanguageFlags = True
        DisplayPoster = True
        DoubleClickScrape = False
        SplitterDistanceMain = 550
        SplitterDistanceTVSeason = 200
        SplitterDistanceTVShow = 200
        ThemeMovie = "Default"
        ThemeMovieset = "Default"
        ThemeTVEpisode = "Default"
        ThemeTVShow = "Default"
        WindowLocation = New Point(10, 10)
        WindowSize = New Size(1024, 768)
        WindowState = FormWindowState.Maximized
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_Movie

#Region "Properties"

    Public Property Filter() As New FilterSettings(Enums.ContentType.Movie)
    Public Property GUI() As New GUISettings

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Filter = New FilterSettings(Enums.ContentType.Movie)
        GUI = New GUISettings
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_Movieset

#Region "Properties"

    Public Property Filter() As New FilterSettings(Enums.ContentType.Movieset)
    Public Property GUI() As New GUISettings

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Filter = New FilterSettings(Enums.ContentType.Movieset)
        GUI = New GUISettings
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_TV

#Region "Properties"

    Public Property Filter As New FilterSettings_TV
    Public Property GUI As New GUISettings_TV
    Public Property TVEpisode As New SettingsContainer_TVEpisode
    Public Property TVSeason As New SettingsContainer_TVSeason
    Public Property TVShow As New SettingsContainer_TVShow

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Filter = New FilterSettings_TV
        TVEpisode = New SettingsContainer_TVEpisode
        TVSeason = New SettingsContainer_TVSeason
        TVShow = New SettingsContainer_TVShow
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_TVEpisode

#Region "Properties"

    Public Property Filter() As New FilterSettings(Enums.ContentType.TVEpisode)
    Public Property GUI() As New GUISettings

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Filter = New FilterSettings(Enums.ContentType.TVEpisode)
        GUI = New GUISettings
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_TVSeason

#Region "Properties"

    Public Property Filter() As New FilterSettings(Enums.ContentType.TVSeason)
    Public Property GUI() As New GUISettings

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Filter = New FilterSettings(Enums.ContentType.TVSeason)
        GUI = New GUISettings
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class SettingsContainer_TVShow

#Region "Properties"

    Public Property Filter() As New FilterSettings(Enums.ContentType.TVShow)
    Public Property GUI() As New GUISettings

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Filter = New FilterSettings(Enums.ContentType.TVShow)
        GUI = New GUISettings
    End Sub

#End Region 'Methods

End Class