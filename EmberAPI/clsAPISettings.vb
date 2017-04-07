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
Imports System.Xml.Serialization
Imports System.Net
Imports System.Drawing
Imports System.Windows.Forms
Imports NLog

<XmlType(AnonymousType:=True),
 XmlRoot([Namespace]:="", IsNullable:=False, ElementName:="Settings")>
Public Class Settings

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _movie As Movie
    Private _movieset As Movieset
    Private _options As Options
    Private _tv As TV
    Private _addons As List(Of AddonsManager._XMLAddonClass)

    Private _moviedatascrapersettings As List(Of ScraperSettings)
    Private _moviemetadataperfiletype As List(Of MetadataPerType)
    Private _ommdummyformat As Integer
    Private _ommdummytagline As String
    Private _ommdummytop As String
    Private _ommdummyusebackground As Boolean
    Private _ommdummyusefanart As Boolean
    Private _ommdummyuseoverlay As Boolean
    Private _ommmediastubtagline As String
    Private _tvepisodenofilter As Boolean
    Private _tvmetadataperfiletype As List(Of MetadataPerType)
    Private _tvscraperepisodegueststarstoactors As Boolean
    Private _tvscraperusedisplayseasonepisode As Boolean
    Private _tvscraperusesruntimeforep As Boolean
    Private _version As String

#End Region 'Fields

#Region "Properties"

    Public Property Options() As Options
        Get
            Return _options
        End Get
        Set(ByVal value As Options)
            _options = value
        End Set
    End Property

    Public Property Movie() As Movie
        Get
            Return _movie
        End Get
        Set(ByVal value As Movie)
            _movie = value
        End Set
    End Property

    Public Property Movieset() As Movieset
        Get
            Return _movieset
        End Get
        Set(ByVal value As Movieset)
            _movieset = value
        End Set
    End Property

    Public Property TV() As TV
        Get
            Return _tv
        End Get
        Set(ByVal value As TV)
            _tv = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    <XmlArray("Addons")>
    <XmlArrayItem("Addon")>
    Public Property Addons() As List(Of AddonsManager._XMLAddonClass)
        Get
            Return _addons
        End Get
        Set(ByVal value As List(Of AddonsManager._XMLAddonClass))
            _addons = value
        End Set
    End Property

    Public Property MovieMetadataPerFileType() As List(Of MetadataPerType)
        Get
            Return _moviemetadataperfiletype
        End Get
        Set(ByVal value As List(Of MetadataPerType))
            _moviemetadataperfiletype = value
        End Set
    End Property

    Public Property TVEpisodeNoFilter() As Boolean
        Get
            Return _tvepisodenofilter
        End Get
        Set(ByVal value As Boolean)
            _tvepisodenofilter = value
        End Set
    End Property

    Public Property OMMDummyFormat() As Integer
        Get
            Return _ommdummyformat
        End Get
        Set(ByVal value As Integer)
            _ommdummyformat = value
        End Set
    End Property

    Public Property OMMDummyTagline() As String
        Get
            Return _ommdummytagline
        End Get
        Set(ByVal value As String)
            _ommdummytagline = value
        End Set
    End Property

    Public Property OMMDummyTop() As String
        Get
            Return _ommdummytop
        End Get
        Set(ByVal value As String)
            _ommdummytop = value
        End Set
    End Property

    Public Property OMMDummyUseBackground() As Boolean
        Get
            Return _ommdummyusebackground
        End Get
        Set(ByVal value As Boolean)
            _ommdummyusebackground = value
        End Set
    End Property

    Public Property OMMDummyUseFanart() As Boolean
        Get
            Return _ommdummyusefanart
        End Get
        Set(ByVal value As Boolean)
            _ommdummyusefanart = value
        End Set
    End Property

    Public Property OMMDummyUseOverlay() As Boolean
        Get
            Return _ommdummyuseoverlay
        End Get
        Set(ByVal value As Boolean)
            _ommdummyuseoverlay = value
        End Set
    End Property

    Public Property OMMMediaStubTagline() As String
        Get
            Return _ommmediastubtagline
        End Get
        Set(ByVal value As String)
            _ommmediastubtagline = value
        End Set
    End Property

    Public Property MovieDataScraperSettings() As List(Of ScraperSettings)
        Get
            Return _moviedatascrapersettings
        End Get
        Set(ByVal value As List(Of ScraperSettings))
            _moviedatascrapersettings = value
        End Set
    End Property

    Public Property TVScraperEpisodeGuestStarsToActors() As Boolean
        Get
            Return _tvscraperepisodegueststarstoactors
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodegueststarstoactors = value
        End Set
    End Property

    Public Property TVMetadataPerFileType() As List(Of MetadataPerType)
        Get
            Return _tvmetadataperfiletype
        End Get
        Set(ByVal value As List(Of MetadataPerType))
            _tvmetadataperfiletype = value
        End Set
    End Property

    Public Property TVScraperUseDisplaySeasonEpisode() As Boolean
        Get
            Return _tvscraperusedisplayseasonepisode
        End Get
        Set(ByVal value As Boolean)
            _tvscraperusedisplayseasonepisode = value
        End Set
    End Property

    Public Property TVScraperUseSRuntimeForEp() As Boolean
        Get
            Return _tvscraperusesruntimeforep
        End Get
        Set(ByVal value As Boolean)
            _tvscraperusesruntimeforep = value
        End Set
    End Property

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub Load()
        Dim strXMLpath As String = Path.Combine(Master.SettingsPath, "Settings.xml")

        Try
            If File.Exists(strXMLpath) Then
                Dim objStreamReader As New StreamReader(strXMLpath)
                Dim xXMLSettings As New XmlSerializer([GetType])

                Master.eSettings = CType(xXMLSettings.Deserialize(objStreamReader), Settings)
                objStreamReader.Close()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
            logger.Info("An attempt is made to repair the Settings.xml")
            Try
                Using srSettings As New StreamReader(strXMLpath)
                    Dim sSettings As String = srSettings.ReadToEnd
                    'old Fanart/Poster sizes
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "PrefSize>Xlrg<", "PrefSize>Any<")
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "PrefSize>Lrg<", "PrefSize>Any<")
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "PrefSize>Mid<", "PrefSize>Any<")
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "PrefSize>Small<", "PrefSize>Any<")
                    'old Trailer Audio/Video quality
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "Qual>All<", "Qual>Any<")
                    'old allseasons/season/tvshow banner type
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "PrefType>None<", "PrefType>Any<")
                    'old seasonposter size HD1000
                    sSettings = System.Text.RegularExpressions.Regex.Replace(sSettings, "<TVSeasonPosterPrefSize>HD1000</TVSeasonPosterPrefSize>",
                                                                             "<TVSeasonPosterPrefSize>Any</TVSeasonPosterPrefSize>")

                    Dim xXMLSettings As New XmlSerializer([GetType])
                    Using reader As TextReader = New StringReader(sSettings)
                        Master.eSettings = CType(xXMLSettings.Deserialize(reader), Settings)
                    End Using
                    logger.Info("AdvancedSettings.xml successfully repaired")
                End Using
            Catch ex2 As Exception
                logger.Error(ex2, New StackFrame().GetMethod().Name)
                File.Copy(strXMLpath, String.Concat(strXMLpath, "_backup"), True)
                Master.eSettings = New Settings
            End Try
        End Try
    End Sub

    Public Sub Save()
        Try
            Dim xmlSerial As New XmlSerializer(GetType(Settings))
            Dim xmlWriter As New StreamWriter(Path.Combine(Master.SettingsPath, "Settings.xml"))
            xmlSerial.Serialize(xmlWriter, Master.eSettings)
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
        Movie = New Movie
        Movieset = New Movieset
        Options = New Options
        TV = New TV

        Addons = New List(Of AddonsManager._XMLAddonClass)
        MovieDataScraperSettings = New List(Of ScraperSettings)
        MovieMetadataPerFileType = New List(Of MetadataPerType)
        OMMDummyFormat = 0
        OMMDummyTagline = String.Empty
        OMMDummyTop = String.Empty
        OMMDummyUseBackground = True
        OMMDummyUseFanart = True
        OMMDummyUseOverlay = True
        OMMMediaStubTagline = String.Empty
        TVEpisodeNoFilter = True
        TVMetadataPerFileType = New List(Of MetadataPerType)
        TVScraperEpisodeGuestStarsToActors = False
        TVScraperUseDisplaySeasonEpisode = True
        TVScraperUseSRuntimeForEp = True
        Version = String.Empty
    End Sub

    Public Function FilenameAnyEnabled(ByVal tContentType As Enums.ContentType, ByVal tImageType As Enums.ScrapeModifierType) As Boolean
        Select Case tContentType
            Case Enums.ContentType.Movie
                With Master.eSettings.Movie.Filenaming
                    Select Case tImageType
                        Case Enums.ScrapeModifierType.MainActorThumbs
                            Return .FilenameAnyEnabled_Actorthumbs
                        Case Enums.ScrapeModifierType.MainBanner
                            Return .FilenameAnyEnabled_Banner
                        Case Enums.ScrapeModifierType.MainClearArt
                            Return .FilenameAnyEnabled_ClearArt()
                        Case Enums.ScrapeModifierType.MainClearLogo
                            Return .FilenameAnyEnabled_ClearLogo()
                        Case Enums.ScrapeModifierType.MainDiscArt
                            Return .FilenameAnyEnabled_DiscArt()
                        Case Enums.ScrapeModifierType.MainExtrafanarts
                            Return .FilenameAnyEnabled_Extrafanarts()
                        Case Enums.ScrapeModifierType.MainExtrathumbs
                            Return .FilenameAnyEnabled_Extrathumbs()
                        Case Enums.ScrapeModifierType.MainFanart
                            Return .FilenameAnyEnabled_Fanart()
                        Case Enums.ScrapeModifierType.MainLandscape
                            Return .FilenameAnyEnabled_Landscape()
                        Case Enums.ScrapeModifierType.MainNFO
                            Return .FilenameAnyEnabled_NFO()
                        Case Enums.ScrapeModifierType.MainPoster
                            Return .FilenameAnyEnabled_Poster()
                        Case Enums.ScrapeModifierType.MainTheme
                            Return .FilenameAnyEnabled_Theme()
                        Case Enums.ScrapeModifierType.MainTrailer
                            Return .FilenameAnyEnabled_Trailer()
                    End Select
                End With
            Case Enums.ContentType.Movieset
                With Master.eSettings.Movieset.Filenaming
                    Select Case tImageType
                        Case Enums.ScrapeModifierType.MainBanner
                            Return .FilenameAnyEnabled_Banner()
                        Case Enums.ScrapeModifierType.MainClearArt
                            Return .FilenameAnyEnabled_ClearArt()
                        Case Enums.ScrapeModifierType.MainClearLogo
                            Return .FilenameAnyEnabled_ClearLogo()
                        Case Enums.ScrapeModifierType.MainDiscArt
                            Return .FilenameAnyEnabled_DiscArt()
                        Case Enums.ScrapeModifierType.MainFanart
                            Return .FilenameAnyEnabled_Fanart()
                        Case Enums.ScrapeModifierType.MainLandscape
                            Return .FilenameAnyEnabled_Landscape()
                        Case Enums.ScrapeModifierType.MainNFO
                            Return .FilenameAnyEnabled_NFO()
                        Case Enums.ScrapeModifierType.MainPoster
                            Return .FilenameAnyEnabled_Poster()
                    End Select
                End With
            Case Enums.ContentType.TVEpisode
                With Master.eSettings.TV.Filenaming.TVEpisode
                    Select Case tImageType
                        Case Enums.ScrapeModifierType.EpisodeActorThumbs
                            Return .FilenameAnyEnabled_Actorthumbs()
                        Case Enums.ScrapeModifierType.EpisodeFanart
                            Return .FilenameAnyEnabled_Fanart()
                        Case Enums.ScrapeModifierType.EpisodeNFO
                            Return .FilenameAnyEnabled_NFO()
                        Case Enums.ScrapeModifierType.EpisodePoster
                            Return .FilenameAnyEnabled_Poster()
                    End Select
                End With
            Case Enums.ContentType.TVSeason
                With Master.eSettings.TV.Filenaming.TVSeason
                    Select Case tImageType
                        Case Enums.ScrapeModifierType.AllSeasonsBanner
                            Return .FilenameAnyEnabled_AllSeasonsBanner()
                        Case Enums.ScrapeModifierType.AllSeasonsFanart
                            Return .FilenameAnyEnabled_AllSeasonsFanart()
                        Case Enums.ScrapeModifierType.AllSeasonsLandscape
                            Return .FilenameAnyEnabled_AllSeasonsLandscape()
                        Case Enums.ScrapeModifierType.AllSeasonsPoster
                            Return .FilenameAnyEnabled_AllSeasonsPoster()
                        Case Enums.ScrapeModifierType.SeasonBanner
                            Return .FilenameAnyEnabled_Banner()
                        Case Enums.ScrapeModifierType.SeasonFanart
                            Return .FilenameAnyEnabled_Fanart()
                        Case Enums.ScrapeModifierType.SeasonLandscape
                            Return .FilenameAnyEnabled_Landscape()
                        Case Enums.ScrapeModifierType.SeasonPoster
                            Return .FilenameAnyEnabled_Poster()
                    End Select
                End With
            Case Enums.ContentType.TVShow
                With Master.eSettings.TV.Filenaming.TVShow
                    Select Case tImageType
                        Case Enums.ScrapeModifierType.MainActorThumbs
                            Return .FilenameAnyEnabled_Actorthumbs
                        Case Enums.ScrapeModifierType.MainBanner
                            Return .FilenameAnyEnabled_Banner()
                        Case Enums.ScrapeModifierType.MainCharacterArt
                            Return .FilenameAnyEnabled_CharacterArt()
                        Case Enums.ScrapeModifierType.MainClearArt
                            Return .FilenameAnyEnabled_ClearArt()
                        Case Enums.ScrapeModifierType.MainClearLogo
                            Return .FilenameAnyEnabled_ClearLogo()
                        Case Enums.ScrapeModifierType.MainExtrafanarts
                            Return .FilenameAnyEnabled_Extrafanarts()
                        Case Enums.ScrapeModifierType.MainFanart
                            Return .FilenameAnyEnabled_Fanart()
                        Case Enums.ScrapeModifierType.MainLandscape
                            Return .FilenameAnyEnabled_Landscape()
                        Case Enums.ScrapeModifierType.MainNFO
                            Return .FilenameAnyEnabled_NFO()
                        Case Enums.ScrapeModifierType.MainPoster
                            Return .FilenameAnyEnabled_Poster()
                        Case Enums.ScrapeModifierType.MainTheme
                            Return .FilenameAnyEnabled_Theme()
                    End Select
                End With
        End Select
        Return False
    End Function

#End Region 'Methods

#Region "Nested Types"

    Public Class MetadataPerType

#Region "Fields"

        Private _filetype As String
        Private _metadata As MediaContainers.Fileinfo

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        Public Property FileType() As String
            Get
                Return _filetype
            End Get
            Set(ByVal value As String)
                _filetype = value
            End Set
        End Property

        Public Property MetaData() As MediaContainers.Fileinfo
            Get
                Return _metadata
            End Get
            Set(ByVal value As MediaContainers.Fileinfo)
                _metadata = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _filetype = String.Empty
            _metadata = New MediaContainers.Fileinfo
        End Sub

#End Region 'Methods

    End Class

    Public Class ScraperSettings

#Region "Fields"

        Private _name As String
        Private _scraperitems As List(Of ScraperItem)
        Private _type As Enums.SettingsPanelType

#End Region'Fields

#Region "Properties"

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property ScraperItems() As List(Of ScraperItem)
            Get
                Return _scraperitems
            End Get
            Set(ByVal value As List(Of ScraperItem))
                _scraperitems = value
            End Set
        End Property

        Public Property Type() As Enums.SettingsPanelType
            Get
                Return _type
            End Get
            Set(ByVal value As Enums.SettingsPanelType)
                _type = value
            End Set
        End Property

#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub Clear()
            _name = String.Empty
            _scraperitems.Clear()
            _type = Nothing
        End Sub

#End Region 'Methods

    End Class

    Public Class ScraperItem

#Region "Fields"

        Private _assemblyname As String
        Private _capatibility As Enums.ScraperCapatibility
        Private _enabled As Boolean
        Private _order As Integer

#End Region'Fields

#Region "Properties"

        Public Property AssemblyName() As String
            Get
                Return _assemblyname
            End Get
            Set(ByVal value As String)
                _assemblyname = value
            End Set
        End Property

        Public Property Capatibility() As Enums.ScraperCapatibility
            Get
                Return _capatibility
            End Get
            Set(ByVal value As Enums.ScraperCapatibility)
                _capatibility = value
            End Set
        End Property

        Public Property Enabled() As Boolean
            Get
                Return _enabled
            End Get
            Set(ByVal value As Boolean)
                _enabled = value
            End Set
        End Property

        Public Property Order() As Integer
            Get
                Return _order
            End Get
            Set(ByVal value As Integer)
                _order = value
            End Set
        End Property

#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub Clear()
            _assemblyname = String.Empty
            _capatibility = Nothing
            _enabled = False
            _order = 999
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class

<Serializable()>
Public Class Movie

#Region "Properties"

    Public Property DataSettings() As DataSettings_Movie
    Public Property Filenaming As FilenamingSettings_Movie
    Public Property ImageSettings() As ImageSettings_Movie
    Public Property SourceSettings As SourceSettings_Movie
    Public Property ThemeSettings() As ThemeSettings
    Public Property TrailerSettings() As TrailerSettings

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
        DataSettings = New DataSettings_Movie
        Filenaming = New FilenamingSettings_Movie
        ImageSettings = New ImageSettings_Movie
        SourceSettings = New SourceSettings_Movie
        ThemeSettings = New ThemeSettings
        TrailerSettings = New TrailerSettings
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class Movieset

#Region "Properties"

    Public Property DataSettings As DataSettings_Movieset
    Public Property Filenaming As FilenamingSettings_Movieset
    Public Property ImageSettings() As ImageSettings_Movieset
    Public Property SourceSettings As SourceSettings_Movieset

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
        DataSettings = New DataSettings_Movieset
        Filenaming = New FilenamingSettings_Movieset
        ImageSettings = New ImageSettings_Movieset
        SourceSettings = New SourceSettings_Movieset
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class DataSettings_Movie

#Region "Properties"

    Public Property Actors() As DataSpecification_WithImageOnly
    Public Property Certifications() As DataSpecification
    Public Property CertificationsForMPAA() As Boolean
    Public Property CertificationsForMPAAFallback() As Boolean
    Public Property CertificationsOnlyValue() As Boolean
    Public Property CleanPlotAndOutline As Boolean
    Public Property ClearDisabledFields() As Boolean
    Public Property Collection As DataSpecification
    Public Property CollectionAutoAdd As Boolean
    Public Property CollectionID() As DataSpecification
    Public Property CollectionKodiExtendedInfo As Boolean
    Public Property CollectionYAMJCompatible As Boolean
    Public Property Countries() As DataSpecification
    Public Property Credits() As DataSpecification
    Public Property DetailedView As Boolean
    Public Property Directors() As DataSpecification
    Public Property DurationForRuntime As Boolean
    Public Property DurationFormat As String
    Public Property Genres() As DataSpecification
    Public Property LockAudioLanguage As Boolean
    Public Property LockVideoLanguage As Boolean
    Public Property MetaDataScan As Boolean
    Public Property MPAA() As DataSpecification
    Public Property MPAANotRatedValue As String
    <XmlIgnore()>
    Public ReadOnly Property MPAANotRatedValueSpecified() As Boolean
        Get
            Return Not String.IsNullOrEmpty(MPAANotRatedValue)
        End Get
    End Property
    Public Property OriginalTitle() As DataSpecification
    Public Property Outline() As DataSpecification
    Public Property Plot() As DataSpecification
    Public Property PlotForOutline As Boolean
    Public Property PlotForOutlineAsFallback As Boolean
    Public Property Rating() As DataSpecification
    Public Property ReleaseDate() As DataSpecification
    Public Property Runtime() As DataSpecification
    Public Property Studios() As DataSpecification
    Public Property Tagline() As DataSpecification
    Public Property Tags() As DataSpecification
    Public Property Title() As DataSpecification
    Public Property Top250() As DataSpecification
    Public Property Trailer() As DataSpecification
    Public Property TrailerKodiFormat As Boolean
    Public Property UserRating() As DataSpecification
    Public Property Year() As DataSpecification

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
    Public Overloads Sub SetDefaults()
        Actors = New DataSpecification_WithImageOnly
        Certifications = New DataSpecification
        CleanPlotAndOutline = False
        Collection = New DataSpecification
        CollectionAutoAdd = True
        CollectionKodiExtendedInfo = False
        CollectionYAMJCompatible = False
        CollectionID = New DataSpecification
        Countries = New DataSpecification
        Credits = New DataSpecification
        DetailedView = False
        Directors = New DataSpecification
        DurationFormat = "<m>"
        DurationForRuntime = True
        Genres = New DataSpecification
        LockAudioLanguage = False
        LockVideoLanguage = False
        MetaDataScan = True
        MPAA = New DataSpecification
        OriginalTitle = New DataSpecification
        Outline = New DataSpecification
        Outline.Limit = 350
        Plot = New DataSpecification
        PlotForOutline = False
        PlotForOutlineAsFallback = False
        Rating = New DataSpecification
        ReleaseDate = New DataSpecification
        Runtime = New DataSpecification
        Studios = New DataSpecification
        Tagline = New DataSpecification
        Tags = New DataSpecification
        Title = New DataSpecification
        Top250 = New DataSpecification
        Trailer = New DataSpecification
        TrailerKodiFormat = True
        UserRating = New DataSpecification
        Year = New DataSpecification
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class DataSettings_Movieset

#Region "Properties"

    Public Property ClearDisabledFields As Boolean
    Public Property Plot() As DataSpecification
    Public Property Title() As DataSpecification

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
    Public Overloads Sub SetDefaults()
        ClearDisabledFields = False
        Plot = New DataSpecification
        Title = New DataSpecification
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class DataSettings_TV

#Region "Properties"

    Public Property DurationFormat As String
    Public Property DurationForRuntime As Boolean
    Public Property MetaDataScan As Boolean
    Public Property TVEpisode() As DataSettings_TVEpisode
    Public Property TVSeason() As DataSettings_TVSeason
    Public Property TVShow() As DataSettings_TVShow

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
        DurationFormat = "<m>"
        DurationForRuntime = True
        MetaDataScan = True
        TVEpisode = New DataSettings_TVEpisode
        TVSeason = New DataSettings_TVSeason
        TVShow = New DataSettings_TVShow
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class DataSettings_TVEpisode

#Region "Properties"

    Public Property Actors() As DataSpecification_WithImageOnly
    Public Property Aired() As DataSpecification
    Public Property Credits() As DataSpecification
    Public Property Directors() As DataSpecification
    Public Property GuestStars() As DataSpecification_WithImageOnly
    Public Property LockAudioLanguage As Boolean
    Public Property LockVideoLanguage As Boolean
    Public Property Plot() As DataSpecification
    Public Property Rating() As DataSpecification
    Public Property Runtime() As DataSpecification
    Public Property Title() As DataSpecification
    Public Property UserRating() As DataSpecification

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
    Public Overloads Sub SetDefaults()
        Actors = New DataSpecification_WithImageOnly
        Aired = New DataSpecification
        Credits = New DataSpecification
        Directors = New DataSpecification
        GuestStars = New DataSpecification_WithImageOnly
        LockAudioLanguage = False
        LockVideoLanguage = False
        Plot = New DataSpecification
        Rating = New DataSpecification
        Runtime = New DataSpecification
        Title = New DataSpecification
        UserRating = New DataSpecification
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class DataSettings_TVSeason

#Region "Properties"

    Public Property Aired() As DataSpecification
    Public Property Plot() As DataSpecification
    Public Property Title() As DataSpecification

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
    Public Overloads Sub SetDefaults()
        Aired = New DataSpecification
        Plot = New DataSpecification
        Title = New DataSpecification
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class DataSettings_TVShow

#Region "Properties"

    Public Property Actors() As DataSpecification_WithImageOnly
    Public Property Certifications() As DataSpecification
    Public Property CertificationsForMPAA() As Boolean
    Public Property CertificationsForMPAAFallback() As Boolean
    Public Property CertificationsOnlyValue() As Boolean
    Public Property ClearDisabledFields() As Boolean
    Public Property Countries() As DataSpecification
    Public Property Creators() As DataSpecification
    Public Property EpisodeGuideURL() As DataSpecification
    Public Property Genres() As DataSpecification
    Public Property MPAA() As DataSpecification
    Public Property MPAANotRatedValue As String
    <XmlIgnore()>
    Public ReadOnly Property MPAANotRatedValueSpecified() As Boolean
        Get
            Return Not String.IsNullOrEmpty(MPAANotRatedValue)
        End Get
    End Property
    Public Property OriginalTitle() As DataSpecification
    Public Property Plot() As DataSpecification
    Public Property Premiered() As DataSpecification
    Public Property Rating() As DataSpecification
    Public Property Runtime() As DataSpecification
    Public Property Status As DataSpecification
    Public Property Studios() As DataSpecification
    Public Property Tags() As DataSpecification
    Public Property Title() As DataSpecification
    Public Property UserRating() As DataSpecification

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
    Public Overloads Sub SetDefaults()
        Actors = New DataSpecification_WithImageOnly
        Certifications = New DataSpecification
        Countries = New DataSpecification
        Creators = New DataSpecification
        EpisodeGuideURL = New DataSpecification With {.Enabled = False}
        Genres = New DataSpecification
        MPAA = New DataSpecification
        OriginalTitle = New DataSpecification
        Plot = New DataSpecification
        Premiered = New DataSpecification
        Rating = New DataSpecification
        Runtime = New DataSpecification
        Status = New DataSpecification
        Studios = New DataSpecification
        Tags = New DataSpecification
        Title = New DataSpecification
        UserRating = New DataSpecification
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class DataSpecification

#Region "Properties"

    Public Property Enabled() As Boolean
    Public Property Filter() As String
    <XmlIgnore()>
    Public ReadOnly Property FilterSpecified() As Boolean
        Get
            Return Not String.IsNullOrEmpty(Filter)
        End Get
    End Property
    Public Property Limit() As Integer
    <XmlIgnore()>
    Public ReadOnly Property LimitSpecified() As Boolean
        Get
            Return Limit > 0
        End Get
    End Property
    Public Property Locked() As Boolean

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
        Enabled = True
        Filter = String.Empty
        Limit = 0
        Locked = False
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class DataSpecification_WithImageOnly
    Inherits DataSpecification

#Region "Properties"

    Public Property WithImageOnly() As Boolean

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
    Public Overloads Sub SetDefaults()
        Enabled = True
        Filter = String.Empty
        Limit = 0
        Locked = False
        WithImageOnly = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class FilenamingSettings_Movie

#Region "Properties"

    Public Property ArtworkDownloader As ArtworkDownloaderSpecifications
    Public Property BackdropsAuto As Boolean
    Public Property BackdropsPath As String
    Public Property Boxee As BoxeeSpecifications
    Public Property Expert As ExpertSpecifications
    Public Property Kodi As KodiSpecifications
    Public Property KodiExtended As KodiExtendedSpecifications
    Public Property NMJ As NMJSpecifications
    Public Property TvTunes As TvTunesSpecifications
    Public Property ProtectVTSandBDMVStructure As Boolean
    Public Property XBMC As XBMCSpecifications
    Public Property YAMJ As YAMJSpecifications

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Actorthumbs() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Expert.BDMV.Actorthumbs AndAlso Not String.IsNullOrEmpty(Expert.BDMV.ActorthumbsExt)) OrElse
                (Expert.Enabled AndAlso Expert.Multi.Actorthumbs AndAlso Not String.IsNullOrEmpty(Expert.Multi.ActorthumbsExt)) OrElse
                (Expert.Enabled AndAlso Expert.Single.Actorthumbs AndAlso Not String.IsNullOrEmpty(Expert.Single.ActorthumbsExt)) OrElse
                (Expert.Enabled AndAlso Expert.VideoTS.Actorthumbs AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.ActorthumbsExt)) OrElse
                Kodi.Actorthumbs OrElse
                XBMC.Actorthumbs
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Banner() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.Banner)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.Banner)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Banner)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.Banner)) OrElse
                ArtworkDownloader.Banner OrElse
                KodiExtended.Banner OrElse
                NMJ.Banner OrElse
                YAMJ.Banner
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_ClearArt() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.ClearArt)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.ClearArt)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.ClearArt)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.ClearArt)) OrElse
                ArtworkDownloader.ClearArt OrElse
                KodiExtended.ClearArt
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_ClearLogo() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.ClearLogo)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.ClearLogo)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.ClearLogo)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.ClearLogo)) OrElse
                ArtworkDownloader.ClearLogo OrElse
                KodiExtended.ClearLogo
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_DiscArt() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.DiscArt)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.DiscArt)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.DiscArt)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.DiscArt)) OrElse
                ArtworkDownloader.DiscArt OrElse
                KodiExtended.DiscArt
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Extrafanarts() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Expert.BDMV.Extrafanarts) OrElse
                (Expert.Enabled AndAlso Expert.Single.Extrafanarts) OrElse
                (Expert.Enabled AndAlso Expert.VideoTS.Extrafanarts) OrElse
                Kodi.Extrafanarts OrElse
                XBMC.Extrafanarts
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Extrathumbs() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Expert.BDMV.Extrathumbs) OrElse
                (Expert.Enabled AndAlso Expert.Single.Extrathumbs) OrElse
                (Expert.Enabled AndAlso Expert.VideoTS.Extrathumbs) OrElse
                Kodi.Extrathumbs OrElse
                XBMC.Extrathumbs
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Fanart() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.Fanart)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.Fanart)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Fanart)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.Fanart)) OrElse
                ArtworkDownloader.Fanart OrElse
                Boxee.Fanart OrElse
                Kodi.Fanart OrElse
                NMJ.Fanart OrElse
                YAMJ.Fanart
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Landscape() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.Landscape)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.Landscape)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Landscape)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.Landscape)) OrElse
                ArtworkDownloader.Landscape OrElse
                KodiExtended.Landscape
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_NFO() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.NFO)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.NFO)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.NFO)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.NFO)) OrElse
                Boxee.NFO OrElse
                Kodi.NFO OrElse
                NMJ.NFO OrElse
                XBMC.NFO OrElse
                YAMJ.NFO
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Poster() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.Poster)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.Poster)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Poster)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.Poster)) OrElse
                ArtworkDownloader.Poster OrElse
                Boxee.Poster OrElse
                Kodi.Poster OrElse
                NMJ.Poster OrElse
                XBMC.Poster OrElse
                YAMJ.Poster
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Theme() As Boolean
        Get
            Return _
                TvTunes.Enabled AndAlso
                (TvTunes.Custom AndAlso Not String.IsNullOrEmpty(TvTunes.CustomPath)) OrElse
                TvTunes.MoviePath OrElse
                (TvTunes.Subdirectory AndAlso Not String.IsNullOrEmpty(TvTunes.SubdirectoryPath))
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Trailer() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.BDMV.Trailer)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Multi.Trailer)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Trailer)) OrElse
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.VideoTS.Trailer)) OrElse
                Kodi.Trailer OrElse
                NMJ.Trailer OrElse
                XBMC.Trailer OrElse
                YAMJ.Trailer
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
        ArtworkDownloader = New ArtworkDownloaderSpecifications
        BackdropsAuto = False
        BackdropsPath = String.Empty
        Boxee = New BoxeeSpecifications
        Expert = New ExpertSpecifications
        Kodi = New KodiSpecifications
        KodiExtended = New KodiExtendedSpecifications
        NMJ = New NMJSpecifications
        TvTunes = New TvTunesSpecifications
        ProtectVTSandBDMVStructure = False
        XBMC = New XBMCSpecifications
        YAMJ = New YAMJSpecifications
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class ArtworkDownloaderSpecifications

#Region "Properties"

        Public Property Banner As Boolean
        Public Property ClearArt As Boolean
        Public Property ClearLogo As Boolean
        Public Property DiscArt As Boolean
        Public Property Extrafanarts As Boolean
        Public Property Extrathumbs As Boolean
        Public Property Fanart As Boolean
        Public Property Landscape As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            ClearArt = False
            ClearLogo = False
            DiscArt = False
            Extrafanarts = False
            Extrathumbs = False
            Fanart = False
            Landscape = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class BoxeeSpecifications

#Region "Properties"

        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Fanart = False
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class ExpertSpecifications

#Region "Properties"

        Public Property Enabled As Boolean
        Public Property BDMV As BDMVSpecifications
        Public Property Multi As MultiSpecifications
        Public Property [Single] As SingleSpecifications
        Public Property VideoTS As VideoTSSpecifications


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            BDMV = New BDMVSpecifications
            Enabled = False
            Multi = New MultiSpecifications
            [Single] = New SingleSpecifications
            VideoTS = New VideoTSSpecifications
        End Sub

#End Region 'Methods

#Region "Nested Types"

        Public Class BDMVSpecifications

#Region "Properties"

            Public Property Actorthumbs As Boolean
            Public Property ActorthumbsExt As String
            Public Property Banner As String
            Public Property ClearArt As String
            Public Property ClearLogo As String
            Public Property DiscArt As String
            Public Property Extrafanarts As Boolean
            Public Property Extrathumbs As Boolean
            Public Property Fanart As String
            Public Property Landscape As String
            Public Property NFO As String
            Public Property Poster As String
            Public Property Trailer As String


#End Region 'Properties

#Region "Constructors"

            Public Sub New()
                SetDefaults()
            End Sub

#End Region 'Constructors

#Region "Methods"

            Public Sub SetDefaults()
                Actorthumbs = False
                ActorthumbsExt = ".jpg"
                Banner = String.Empty
                ClearArt = String.Empty
                ClearLogo = String.Empty
                DiscArt = String.Empty
                Extrafanarts = False
                Extrathumbs = False
                Fanart = String.Empty
                Landscape = String.Empty
                NFO = String.Empty
                Poster = String.Empty
                Trailer = String.Empty
            End Sub

#End Region 'Methods

        End Class

        Public Class MultiSpecifications

#Region "Properties"

            Public Property Actorthumbs As Boolean
            Public Property ActorthumbsExt As String
            Public Property Banner As String
            Public Property ClearArt As String
            Public Property ClearLogo As String
            Public Property DiscArt As String
            Public Property Fanart As String
            Public Property FilenameStacking As Boolean
            Public Property FilenameUnstacking As Boolean
            Public Property Landscape As String
            Public Property NFO As String
            Public Property Poster As String
            Public Property Trailer As String


#End Region 'Properties

#Region "Constructors"

            Public Sub New()
                SetDefaults()
            End Sub

#End Region 'Constructors

#Region "Methods"

            Public Sub SetDefaults()
                Actorthumbs = False
                ActorthumbsExt = ".jpg"
                Banner = String.Empty
                ClearArt = String.Empty
                ClearLogo = String.Empty
                DiscArt = String.Empty
                Fanart = String.Empty
                FilenameStacking = False
                FilenameUnstacking = False
                Landscape = String.Empty
                NFO = String.Empty
                Poster = String.Empty
                Trailer = String.Empty
            End Sub

#End Region 'Methods

        End Class

        Public Class SingleSpecifications

#Region "Properties"

            Public Property Actorthumbs As Boolean
            Public Property ActorthumbsExt As String
            Public Property Banner As String
            Public Property ClearArt As String
            Public Property ClearLogo As String
            Public Property DiscArt As String
            Public Property Extrafanarts As Boolean
            Public Property Extrathumbs As Boolean
            Public Property Fanart As String
            Public Property FilenameStacking As Boolean
            Public Property FilenameUnstacking As Boolean
            Public Property Landscape As String
            Public Property NFO As String
            Public Property Poster As String
            Public Property Trailer As String


#End Region 'Properties

#Region "Constructors"

            Public Sub New()
                SetDefaults()
            End Sub

#End Region 'Constructors

#Region "Methods"

            Public Sub SetDefaults()
                Actorthumbs = False
                ActorthumbsExt = ".jpg"
                Banner = String.Empty
                ClearArt = String.Empty
                ClearLogo = String.Empty
                DiscArt = String.Empty
                Extrafanarts = False
                Extrathumbs = False
                Fanart = String.Empty
                FilenameStacking = False
                FilenameUnstacking = False
                Landscape = String.Empty
                NFO = String.Empty
                Poster = String.Empty
                Trailer = String.Empty
            End Sub

#End Region 'Methods

        End Class

        Public Class VideoTSSpecifications

#Region "Properties"

            Public Property Actorthumbs As Boolean
            Public Property ActorthumbsExt As String
            Public Property Banner As String
            Public Property ClearArt As String
            Public Property ClearLogo As String
            Public Property DiscArt As String
            Public Property Extrafanarts As Boolean
            Public Property Extrathumbs As Boolean
            Public Property Fanart As String
            Public Property Landscape As String
            Public Property NFO As String
            Public Property RecognizeVideoTS As Boolean
            Public Property Poster As String
            Public Property Trailer As String


#End Region 'Properties

#Region "Constructors"

            Public Sub New()
                SetDefaults()
            End Sub

#End Region 'Constructors

#Region "Methods"

            Public Sub SetDefaults()
                Actorthumbs = False
                ActorthumbsExt = ".jpg"
                Banner = String.Empty
                ClearArt = String.Empty
                ClearLogo = String.Empty
                DiscArt = String.Empty
                Extrafanarts = False
                Extrathumbs = False
                Fanart = String.Empty
                Landscape = String.Empty
                NFO = String.Empty
                RecognizeVideoTS = False
                Poster = String.Empty
                Trailer = String.Empty
            End Sub

#End Region 'Methods

        End Class

#End Region 'Nested Types

    End Class

    Public Class KodiSpecifications

#Region "Properties"

        Public Property Actorthumbs As Boolean
        Public Property Extrafanarts As Boolean
        Public Property Extrathumbs As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean
        Public Property Trailer As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Actorthumbs = False
            Extrafanarts = False
            Extrathumbs = False
            Fanart = False
            NFO = False
            Poster = False
            Trailer = False
        End Sub

#End Region 'Methods

    End Class

    Public Class KodiExtendedSpecifications

#Region "Properties"

        Public Property Banner As Boolean
        Public Property ClearArt As Boolean
        Public Property ClearLogo As Boolean
        Public Property DiscArt As Boolean
        Public Property Landscape As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            ClearArt = False
            ClearLogo = False
            DiscArt = False
            Landscape = False
        End Sub

#End Region 'Methods

    End Class

    Public Class NMJSpecifications

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean
        Public Property Trailer As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            NFO = False
            Poster = False
            Trailer = False
        End Sub

#End Region 'Methods

    End Class

    Public Class TvTunesSpecifications

#Region "Properties"

        Public Property Enabled As Boolean
        Public Property Custom As Boolean
        Public Property CustomPath As String
        Public Property MoviePath As Boolean
        Public Property Subdirectory As Boolean
        Public Property SubdirectoryPath As String


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Enabled = False
            Custom = False
            CustomPath = String.Empty
            MoviePath = False
            Subdirectory = False
            SubdirectoryPath = String.Empty
        End Sub

#End Region 'Methods

    End Class

    Public Class XBMCSpecifications

#Region "Properties"

        Public Property Actorthumbs As Boolean
        Public Property Extrafanarts As Boolean
        Public Property Extrathumbs As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean
        Public Property Trailer As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Actorthumbs = False
            Extrafanarts = False
            Extrathumbs = False
            Fanart = False
            NFO = False
            Poster = False
            Trailer = False
        End Sub

#End Region 'Methods

    End Class

    Public Class YAMJSpecifications

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean
        Public Property Trailer As Boolean
        Public Property WatchedFile As Boolean
        Public Property WatchedFilePath As String
        Public ReadOnly Property WatchedFileSpecified As Boolean
            Get
                Return WatchedFile AndAlso Not String.IsNullOrEmpty(WatchedFilePath)
            End Get
        End Property


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            NFO = False
            Poster = False
            Trailer = False
            WatchedFile = False
            WatchedFilePath = String.Empty
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class


<Serializable()>
Public Class FilenamingSettings_Movieset

#Region "Properties"

    Public Property Expert As ExpertSpecifications_Movieset
    Public Property KodiExtended As KodiExtendedSpecifications_Movieset
    Public Property MovieSetArtworkAutomator As MovieSetArtworkAutomatorSpecifications

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Banner() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Banner)) OrElse
                KodiExtended.Banner OrElse
                MovieSetArtworkAutomator.Banner
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_ClearArt() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.ClearArt)) OrElse
                KodiExtended.ClearArt OrElse
                MovieSetArtworkAutomator.ClearArt
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_ClearLogo() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.ClearLogo)) OrElse
                KodiExtended.ClearLogo OrElse
                MovieSetArtworkAutomator.ClearLogo
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_DiscArt() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.DiscArt)) OrElse
                KodiExtended.DiscArt
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Fanart() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Fanart)) OrElse
                KodiExtended.Fanart OrElse
                MovieSetArtworkAutomator.Fanart
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Landscape() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Landscape)) OrElse
                KodiExtended.Landscape OrElse
                MovieSetArtworkAutomator.Landscape
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_NFO() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.NFO))
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Poster() As Boolean
        Get
            Return _
                (Expert.Enabled AndAlso Not String.IsNullOrEmpty(Expert.Single.Poster)) OrElse
                KodiExtended.Poster OrElse
                MovieSetArtworkAutomator.Poster
        End Get
    End Property


#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        SetDefaults()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Function GetAllPaths() As List(Of String)
        Dim lstPaths As New List(Of String)
        If Not String.IsNullOrEmpty(Expert.Single.Path) Then lstPaths.Add(Expert.Single.Path)
        If Not String.IsNullOrEmpty(KodiExtended.Path) Then lstPaths.Add(KodiExtended.Path)
        If Not String.IsNullOrEmpty(MovieSetArtworkAutomator.Path) Then lstPaths.Add(MovieSetArtworkAutomator.Path)
        lstPaths = lstPaths.Distinct().ToList() 'remove double entries
        Return lstPaths
    End Function

    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaults()
        Expert = New ExpertSpecifications_Movieset
        KodiExtended = New KodiExtendedSpecifications_Movieset
        MovieSetArtworkAutomator = New MovieSetArtworkAutomatorSpecifications
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class MovieSetArtworkAutomatorSpecifications

#Region "Properties"

        Public Property Banner As Boolean
        Public Property ClearArt As Boolean
        Public Property ClearLogo As Boolean
        Public Property Fanart As Boolean
        Public Property Landscape As Boolean
        Public Property Path As String
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            ClearArt = False
            ClearLogo = False
            Fanart = False
            Landscape = False
            Path = String.Empty
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class ExpertSpecifications_Movieset

#Region "Properties"

        Public Property Enabled As Boolean
        Public Property [Single] As SingleSpecifications_Movieset


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Enabled = False
            [Single] = New SingleSpecifications_Movieset
        End Sub

#End Region 'Methods

#Region "Nested Types"

        Public Class SingleSpecifications_Movieset

#Region "Properties"

            Public Property Banner As String
            Public Property ClearArt As String
            Public Property ClearLogo As String
            Public Property DiscArt As String
            Public Property Fanart As String
            Public Property Landscape As String
            Public Property NFO As String
            Public Property Path As String
            Public Property Poster As String


#End Region 'Properties

#Region "Constructors"

            Public Sub New()
                SetDefaults()
            End Sub

#End Region 'Constructors

#Region "Methods"

            Public Sub SetDefaults()
                Banner = String.Empty
                ClearArt = String.Empty
                ClearLogo = String.Empty
                DiscArt = String.Empty
                Fanart = String.Empty
                Landscape = String.Empty
                NFO = String.Empty
                Path = String.Empty
                Poster = String.Empty
            End Sub

#End Region 'Methods

        End Class

#End Region 'Nested Types

    End Class

    Public Class KodiExtendedSpecifications_Movieset

#Region "Properties"

        Public Property Banner As Boolean
        Public Property ClearArt As Boolean
        Public Property ClearLogo As Boolean
        Public Property DiscArt As Boolean
        Public Property Fanart As Boolean
        Public Property Landscape As Boolean
        Public Property Path As String
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            ClearArt = False
            ClearLogo = False
            DiscArt = False
            Fanart = False
            Landscape = False
            Path = String.Empty
            Poster = False
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class

<Serializable()>
Public Class FilenamingSettings_TV

#Region "Properties"

    Public Property BackdropsAuto As Boolean
    Public Property BackdropsPath As String
    Public Property ProtectVTSandBDMVStructure As Boolean
    Public Property TVEpisode As FilenamingSettings_TVEpisode
    Public Property TVSeason As FilenamingSettings_TVSeason
    Public Property TVShow As FilenamingSettings_TVShow

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
        BackdropsAuto = False
        BackdropsPath = String.Empty
        ProtectVTSandBDMVStructure = False
        TVEpisode = New FilenamingSettings_TVEpisode
        TVSeason = New FilenamingSettings_TVSeason
        TVShow = New FilenamingSettings_TVShow
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class FilenamingSettings_TVEpisode

#Region "Properties"

    Public Property Boxee As BoxeeSpecifications_TVEpisode
    Public Property Expert As ExpertSpecifications_TVEpisode
    Public Property Kodi As KodiSpecifications_TVEpisode
    Public Property KodiExtended As KodiExtendedSpecifications_TVEpisode
    Public Property NMJ As NMJSpecifications_TVEpisode
    Public Property YAMJ As YAMJSpecifications_TVEpisode

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Actorthumbs() As Boolean
        Get
            Return _
                (Expert.Actorthumbs AndAlso Not String.IsNullOrEmpty(Expert.ActorthumbsExt)) OrElse
                Kodi.Actorthumbs
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Fanart() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Fanart) OrElse
                KodiExtended.Fanart
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_NFO() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.NFO) OrElse
                Boxee.NFO OrElse
                Kodi.NFO OrElse
                NMJ.NFO OrElse
                YAMJ.NFO
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Poster() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Poster) OrElse
                Boxee.Poster OrElse
                Kodi.Poster OrElse
                NMJ.Poster OrElse
                YAMJ.Poster
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
        Boxee = New BoxeeSpecifications_TVEpisode
        Expert = New ExpertSpecifications_TVEpisode
        Kodi = New KodiSpecifications_TVEpisode
        KodiExtended = New KodiExtendedSpecifications_TVEpisode
        NMJ = New NMJSpecifications_TVEpisode
        YAMJ = New YAMJSpecifications_TVEpisode
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class BoxeeSpecifications_TVEpisode

#Region "Properties"

        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class ExpertSpecifications_TVEpisode

#Region "Properties"

        Public Property Actorthumbs As Boolean
        Public Property ActorthumbsExt As String
        Public Property Fanart As String
        Public Property NFO As String
        Public Property Poster As String


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Actorthumbs = False
            ActorthumbsExt = ".jpg"
            Fanart = String.Empty
            NFO = String.Empty
            Poster = String.Empty
        End Sub

#End Region 'Methods 

    End Class

    Public Class KodiSpecifications_TVEpisode

#Region "Properties"

        Public Property Actorthumbs As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Actorthumbs = False
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class KodiExtendedSpecifications_TVEpisode

#Region "Properties"

        Public Property Fanart As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Fanart = False
        End Sub

#End Region 'Methods

    End Class

    Public Class NMJSpecifications_TVEpisode

#Region "Properties"

        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class YAMJSpecifications_TVEpisode

#Region "Properties"

        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class

<Serializable()>
Public Class FilenamingSettings_TVSeason

#Region "Properties"

    Public Property ArtworkDownloader As ArtworkDownloaderSpecifications_TVSeason
    Public Property Boxee As BoxeeSpecifications_TVSeason
    Public Property Expert As ExpertSpecifications_TVSeason
    Public Property Kodi As KodiSpecifications_TVSeason
    Public Property KodiExtended As KodiExtendedSpecifications_TVSeason
    Public Property NMJ As NMJSpecifications_TVSeason
    Public Property YAMJ As YAMJSpecifications_TVSeason

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_AllSeasonsBanner() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.AllSeasonsBanner) OrElse
                ArtworkDownloader.Banner OrElse
                Kodi.Banner
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_AllSeasonsFanart() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.AllSeasonsFanart) OrElse
                ArtworkDownloader.Fanart OrElse
                Kodi.Fanart
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_AllSeasonsLandscape() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.AllSeasonsLandscape) OrElse
                ArtworkDownloader.Landscape OrElse
                KodiExtended.Landscape
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_AllSeasonsPoster() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.AllSeasonsPoster) OrElse
                ArtworkDownloader.Poster OrElse
                Kodi.Poster
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Banner() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Banner) OrElse
                Kodi.Banner OrElse
                NMJ.Banner OrElse
                YAMJ.Banner
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Fanart() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Fanart) OrElse
                NMJ.Fanart OrElse
                Kodi.Fanart OrElse
                YAMJ.Fanart
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Landscape() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Landscape) OrElse
                ArtworkDownloader.Landscape OrElse
                KodiExtended.Landscape
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Poster() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Poster) OrElse
                Boxee.Poster OrElse
                Kodi.Poster OrElse
                NMJ.Poster OrElse
                YAMJ.Poster
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
        ArtworkDownloader = New ArtworkDownloaderSpecifications_TVSeason
        Boxee = New BoxeeSpecifications_TVSeason
        Expert = New ExpertSpecifications_TVSeason
        Kodi = New KodiSpecifications_TVSeason
        KodiExtended = New KodiExtendedSpecifications_TVSeason
        NMJ = New NMJSpecifications_TVSeason
        YAMJ = New YAMJSpecifications_TVSeason
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class ArtworkDownloaderSpecifications_TVSeason

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property Landscape As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            Landscape = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class BoxeeSpecifications_TVSeason

#Region "Properties"

        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class ExpertSpecifications_TVSeason

#Region "Properties"

        Public Property AllSeasonsBanner As String
        Public Property AllSeasonsFanart As String
        Public Property AllSeasonsLandscape As String
        Public Property AllSeasonsPoster As String
        Public Property Banner As String
        Public Property Fanart As String
        Public Property Landscape As String
        Public Property Poster As String


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            AllSeasonsBanner = String.Empty
            AllSeasonsFanart = String.Empty
            AllSeasonsLandscape = String.Empty
            AllSeasonsPoster = String.Empty
            Banner = String.Empty
            Fanart = String.Empty
            Landscape = String.Empty
            Poster = String.Empty
        End Sub

#End Region 'Methods 

    End Class

    Public Class KodiSpecifications_TVSeason

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class KodiExtendedSpecifications_TVSeason

#Region "Properties"

        Public Property Landscape As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Landscape = False
        End Sub

#End Region 'Methods

    End Class

    Public Class NMJSpecifications_TVSeason

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class YAMJSpecifications_TVSeason

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class

<Serializable()>
Public Class FilenamingSettings_TVShow

#Region "Properties"

    Public Property ArtworkDownloader As ArtworkDownloaderSpecifications_TVShow
    Public Property Boxee As BoxeeSpecifications_TVShow
    Public Property Expert As ExpertSpecifications_TVShow
    Public Property Kodi As KodiSpecifications_TVShow
    Public Property KodiExtended As KodiExtendedSpecifications_TVShow
    Public Property NMJ As NMJSpecifications_TVShow
    Public Property TvTunes As TvTunesSpecifications_TVShow
    Public Property YAMJ As YAMJSpecifications_TVShow

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Actorthumbs() As Boolean
        Get
            Return _
                (Expert.Actorthumbs AndAlso Not String.IsNullOrEmpty(Expert.ActorthumbsExt)) OrElse
                Kodi.Actorthumbs
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Banner() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Banner) OrElse
                ArtworkDownloader.Banner OrElse
                Kodi.Banner OrElse
                NMJ.Banner OrElse
                YAMJ.Banner
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_CharacterArt() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.CharacterArt) OrElse
                ArtworkDownloader.CharacterArt OrElse
                KodiExtended.CharacterArt
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_ClearArt() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.ClearArt) OrElse
                ArtworkDownloader.ClearArt OrElse
                KodiExtended.ClearArt
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_ClearLogo() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.ClearLogo) OrElse
                ArtworkDownloader.ClearLogo OrElse
                KodiExtended.ClearLogo
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Extrafanarts() As Boolean
        Get
            Return _
                Expert.Extrafanarts OrElse
                Kodi.Extrafanarts
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Fanart() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Fanart) OrElse
                ArtworkDownloader.Fanart OrElse
                Boxee.Fanart OrElse
                Kodi.Fanart OrElse
                NMJ.Fanart OrElse
                YAMJ.Fanart
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Landscape() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Landscape) OrElse
                ArtworkDownloader.Landscape OrElse
                KodiExtended.Landscape
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_NFO() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.NFO) OrElse
                Boxee.NFO OrElse
                Kodi.NFO OrElse
                NMJ.NFO OrElse
                YAMJ.NFO
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Poster() As Boolean
        Get
            Return _
                Not String.IsNullOrEmpty(Expert.Poster) OrElse
                ArtworkDownloader.Poster OrElse
                Boxee.Poster OrElse
                Kodi.Poster OrElse
                NMJ.Poster OrElse
                YAMJ.Poster
        End Get
    End Property

    <XmlIgnore()>
    Public ReadOnly Property FilenameAnyEnabled_Theme() As Boolean
        Get
            Return _
                TvTunes.Enabled AndAlso
                (TvTunes.Custom AndAlso Not String.IsNullOrEmpty(TvTunes.CustomPath)) OrElse
                TvTunes.TVShowPath OrElse
                (TvTunes.Subdirectory AndAlso Not String.IsNullOrEmpty(TvTunes.SubdirectoryPath))
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
        ArtworkDownloader = New ArtworkDownloaderSpecifications_TVShow
        Boxee = New BoxeeSpecifications_TVShow
        Expert = New ExpertSpecifications_TVShow
        Kodi = New KodiSpecifications_TVShow
        KodiExtended = New KodiExtendedSpecifications_TVShow
        NMJ = New NMJSpecifications_TVShow
        TvTunes = New TvTunesSpecifications_TVShow
        YAMJ = New YAMJSpecifications_TVShow
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class ArtworkDownloaderSpecifications_TVShow

#Region "Properties"

        Public Property Banner As Boolean
        Public Property CharacterArt As Boolean
        Public Property ClearArt As Boolean
        Public Property ClearLogo As Boolean
        Public Property Extrafanarts As Boolean
        Public Property Fanart As Boolean
        Public Property Landscape As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            CharacterArt = False
            ClearArt = False
            ClearLogo = False
            Extrafanarts = False
            Fanart = False
            Landscape = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class BoxeeSpecifications_TVShow

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class ExpertSpecifications_TVShow

#Region "Properties"

        Public Property Actorthumbs As Boolean
        Public Property ActorthumbsExt As String
        Public Property AllSeasonsBanner As String
        Public Property AllSeasonsFanart As String
        Public Property AllSeasonsLandscape As String
        Public Property AllSeasonsPoster As String
        Public Property Banner As String
        Public Property CharacterArt As String
        Public Property ClearArt As String
        Public Property ClearLogo As String
        Public Property Extrafanarts As Boolean
        Public Property Fanart As String
        Public Property Landscape As String
        Public Property NFO As String
        Public Property Poster As String


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Actorthumbs = False
            ActorthumbsExt = ".jpg"
            AllSeasonsBanner = String.Empty
            AllSeasonsFanart = String.Empty
            AllSeasonsLandscape = String.Empty
            AllSeasonsPoster = String.Empty
            Banner = String.Empty
            CharacterArt = String.Empty
            ClearArt = String.Empty
            ClearLogo = String.Empty
            Extrafanarts = False
            Fanart = String.Empty
            Landscape = String.Empty
            NFO = String.Empty
            Poster = String.Empty
        End Sub

#End Region 'Methods 

    End Class

    Public Class KodiSpecifications_TVShow

#Region "Properties"

        Public Property Actorthumbs As Boolean
        Public Property Banner As Boolean
        Public Property Extrafanarts As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Actorthumbs = False
            Banner = False
            Extrafanarts = False
            Fanart = False
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class KodiExtendedSpecifications_TVShow

#Region "Properties"

        Public Property CharacterArt As Boolean
        Public Property ClearArt As Boolean
        Public Property ClearLogo As Boolean
        Public Property Landscape As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            CharacterArt = False
            ClearArt = False
            ClearLogo = False
            Landscape = False
        End Sub

#End Region 'Methods

    End Class

    Public Class NMJSpecifications_TVShow

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean
        Public Property Trailer As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            NFO = False
            Poster = False
            Trailer = False
        End Sub

#End Region 'Methods

    End Class

    Public Class TvTunesSpecifications_TVShow

#Region "Properties"

        Public Property Enabled As Boolean
        Public Property Custom As Boolean
        Public Property CustomPath As String
        Public Property Subdirectory As Boolean
        Public Property SubdirectoryPath As String
        Public Property TVShowPath As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Enabled = False
            Custom = False
            CustomPath = String.Empty
            Subdirectory = False
            SubdirectoryPath = String.Empty
            TVShowPath = False
        End Sub

#End Region 'Methods

    End Class

    Public Class YAMJSpecifications_TVShow

#Region "Properties"

        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Fanart = False
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class

<Serializable()>
Public Class FilesystemSettings

#Region "Properties"

    Public Property NoStackExts() As List(Of String)
    Public Property SortPath As String
    Public Property ValidSubtitleExts() As List(Of String)
    Public Property ValidThemeExts() As List(Of String)
    Public Property ValidVideoExts() As List(Of String)
    Public Property VirtualDriveAppPath As String
    Public Property VirtualDriveDriveLetter As String

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

#End Region 'Constructors

#Region "Methods"
    ''' <summary>
    ''' Defines all default settings for a new installation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        NoStackExts = New List(Of String)
        SortPath = String.Empty
        ValidSubtitleExts = New List(Of String)
        ValidThemeExts = New List(Of String)
        ValidVideoExts = New List(Of String)
        VirtualDriveAppPath = String.Empty
        VirtualDriveDriveLetter = String.Empty
    End Sub

    Public Sub SetDefaults(ByVal Type As Enums.DefaultSettingType, ByVal Force As Boolean)
        'ValidSubtitleExts
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidSubtitleExts) AndAlso (Force OrElse ValidSubtitleExts.Count = 0) Then
            ValidSubtitleExts.Clear()
            ValidSubtitleExts.AddRange(".sst,.srt,.sub,.ssa,.aqt,.smi,.sami,.jss,.mpl,.rt,.idx,.ass".Split(","c))
        End If

        'ValidThemeExts
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidThemeExts) AndAlso (Force OrElse ValidThemeExts.Count = 0) Then
            ValidThemeExts.Clear()
            ValidThemeExts.AddRange(".flac,.m4a,.mp3,.wav,.wma".Split(","c))
        End If

        'ValidVideoExts
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidVideoExts) AndAlso (Force OrElse ValidVideoExts.Count = 0) Then
            ValidVideoExts.Clear()
            ValidVideoExts.AddRange(".avi,.divx,.mkv,.iso,.mpg,.mp4,.mpeg,.wmv,.wma,.mov,.mts,.m2t,.img,.dat,.bin,.cue,.ifo,.dvb,.evo,.asf,.asx,.avs,.nsv,.ram,.ogg,.ogm,.ogv,.flv,.swf,.nut,.viv,.rar,.m2ts,.dvr-ms,.ts,.m4v,.rmvb,.webm,.disc,.3gpp".Split(","c))
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

#End Region

End Class


<Serializable()>
Public Class GlobalSettings

#Region "Properties"

    Public Property CheckForUpdates() As Boolean
    Public Property DateAddedIgnoreNFO() As Boolean
    Public Property DateAdded() As Enums.DateTime
    Public Property DigitGrpSymbolVotes As Boolean
    Public Property ImageFilter As ImageFilterSpecification
    Public Property Language As String
    Public Property OverwriteNFO As Boolean
    Public Property SortTokens As String

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
        CheckForUpdates = True
        DateAdded = Enums.DateTime.Now
        DateAddedIgnoreNFO = False
        DigitGrpSymbolVotes = False
        ImageFilter = New ImageFilterSpecification
        Language = "English_(en_US)"
        OverwriteNFO = False
        SortTokens = "a,an,the,der,die,das"
    End Sub

#End Region 'Methods 

End Class

<Serializable()>
Public Class ImageFilterSpecification

#Region "Properties"

    Public Property Enabled() As Boolean
    Public Property AutoScraper() As Boolean
    Public Property Fanart() As Boolean
    Public Property FanartMatchTolerance() As Integer
    Public Property ImageSelectDialog() As Boolean
    Public Property Poster() As Boolean
    Public Property PosterMatchTolerance() As Integer

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
        AutoScraper = False
        Fanart = False
        FanartMatchTolerance = 4
        ImageSelectDialog = False
        Poster = False
        PosterMatchTolerance = 1
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageLanguageSpecification

#Region "Properties"

    Public Property ForcedLanguage() As String
    Public Property ForceLanguage() As Boolean
    Public Property GetBlankImages() As Boolean
    Public Property GetEnglishImages() As Boolean
    Public Property GetMediaLanguageOnly() As Boolean

    <XmlIgnore()>
    Public ReadOnly Property ForceLanguageSpecified() As Boolean
        Get
            Return ForceLanguage AndAlso Not String.IsNullOrEmpty(ForcedLanguage)
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
        ForcedLanguage = "en"
        ForceLanguage = False
        GetBlankImages = True
        GetEnglishImages = True
        GetMediaLanguageOnly = True
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings

#Region "Properties"

    Public Property CacheEnabled() As Boolean
    Public Property DisplayImageSelectDialog() As Boolean
    Public Property NotSaveURLToNfo() As Boolean

    Public Property Language As ImageLanguageSpecification

    Public Property Actorthumbs() As ImageSpecification_Resize
    Public Property Banner() As ImageSpecification_Resize
    Public Property ClearArt() As ImageSpecification
    Public Property ClearLogo() As ImageSpecification
    Public Property Extrafanarts() As ImageSpecification_Extra
    Public Property Fanart() As ImageSpecification_Extra
    Public Property Landscape() As ImageSpecification_Resize
    Public Property Poster() As ImageSpecification_Resize

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
        CacheEnabled = False
        DisplayImageSelectDialog = True
        NotSaveURLToNfo = False

        Language = New ImageLanguageSpecification

        Actorthumbs = New ImageSpecification_Resize
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        Fanart = New ImageSpecification_Extra
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_Movie
    Inherits ImageSettings

#Region "Properties"

    Public Property DiscArt() As ImageSpecification
    Public Property Extrathumbs() As ImageSpecification_Extra

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
    Public Overloads Sub SetDefaults()
        CacheEnabled = False
        DisplayImageSelectDialog = True
        NotSaveURLToNfo = False
        Language = New ImageLanguageSpecification

        Actorthumbs = New ImageSpecification_Resize
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        DiscArt = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        Extrathumbs = New ImageSpecification_Extra
        Fanart = New ImageSpecification_Extra
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_Movieset
    Inherits ImageSettings

#Region "Properties"

    Public Property DiscArt() As ImageSpecification

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
    Public Overloads Sub SetDefaults()
        CacheEnabled = False
        DisplayImageSelectDialog = True
        NotSaveURLToNfo = False
        Language = New ImageLanguageSpecification

        Actorthumbs = New ImageSpecification_Resize
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        DiscArt = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        Fanart = New ImageSpecification_Extra
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_TV
    Inherits ImageSettings

#Region "Properties"

    Public Property TVAllSeasons() As ImageSettings_TVSeason
    Public Property TVEpisode() As ImageSettings_TVEpisode
    Public Property TVSeason() As ImageSettings_TVSeason
    Public Property TVShow() As ImageSettings_TVShow

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
    Public Overloads Sub SetDefaults()
        TVAllSeasons = New ImageSettings_TVSeason
        TVEpisode = New ImageSettings_TVEpisode
        TVSeason = New ImageSettings_TVSeason
        TVShow = New ImageSettings_TVShow

        CacheEnabled = False
        DisplayImageSelectDialog = True
        NotSaveURLToNfo = False

        Language = New ImageLanguageSpecification

        Actorthumbs = New ImageSpecification_Resize
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        Fanart = New ImageSpecification_Extra
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_TVEpisode

#Region "Properties"

    Public Property ActorThumbsKeepExisting() As Boolean
    Public Property Fanart() As ImageSpecification_Resize
    Public Property Poster() As ImageSpecification_Resize

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
        ActorThumbsKeepExisting = False
        Fanart = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_TVSeason

#Region "Properties"

    Public Property Banner() As ImageSpecification_Resize
    Public Property Fanart() As ImageSpecification_Resize
    Public Property Landscape() As ImageSpecification_Resize
    Public Property Poster() As ImageSpecification_Resize

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
        Banner = New ImageSpecification_Resize
        Fanart = New ImageSpecification_Resize
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_TVShow
    Inherits ImageSettings

#Region "Properties"

    Public Property CharacterArt() As ImageSpecification

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
    Public Overloads Sub SetDefaults()
        Actorthumbs = New ImageSpecification_Resize
        Banner = New ImageSpecification_Resize
        CharacterArt = New ImageSpecification
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        Fanart = New ImageSpecification_Extra
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class ImageSpecification

#Region "Properties"

    Public Property KeepExisting() As Boolean
    Public Property PrefSize() As Enums.ImageSize
    Public Property PrefSizeOnly() As Boolean

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
        KeepExisting = False
        PrefSize = Enums.ImageSize.Any
        PrefSizeOnly = False
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class ImageSpecification_Extra
    Inherits ImageSpecification_Resize

#Region "Properties"

    Public Property Creator As Boolean
    Public Property CreatorAsFallback As Boolean
    Public Property CreatorNoBlackBars As Boolean
    Public Property CreatorNoSpoilers As Boolean
    Public Property Limit As Integer
    Public Property Preselect As Boolean

    <XmlIgnore()>
    Public ReadOnly Property LimitSpecified() As Boolean
        Get
            Return Limit > 0
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
    Public Overloads Sub SetDefaults()
        Creator = False
        CreatorAsFallback = True
        CreatorNoBlackBars = True
        CreatorNoSpoilers = True
        FixedSize = False
        Limit = 4
        MaxHeight = 0
        MaxWidth = 0
        KeepExisting = False
        PrefSize = Enums.ImageSize.Any
        PrefSizeOnly = False
        Preselect = True
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class ImageSpecification_Resize
    Inherits ImageSpecification

#Region "Properties"

    Public Property FixedSize As Boolean
    Public Property MaxHeight As Integer
    Public Property MaxWidth As Integer

    <XmlIgnore()>
    Public ReadOnly Property ResizeSpecified() As Boolean
        Get
            Return MaxHeight > 0 OrElse MaxWidth > 0
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
    Public Overloads Sub SetDefaults()
        FixedSize = False
        MaxHeight = 0
        MaxWidth = 0
        KeepExisting = False
        PrefSize = Enums.ImageSize.Any
        PrefSizeOnly = False
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class Options

#Region "Properties"

    Public Property Filesystem As FilesystemSettings
    Public Property [Global] As GlobalSettings
    Public Property Proxy As ProxySettings

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
        Filesystem = New FilesystemSettings
        Filesystem.SetDefaults(Enums.DefaultSettingType.All, True)
        [Global] = New GlobalSettings
        Proxy = New ProxySettings
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ProxySettings

#Region "Properties"

    Public Property Credentials() As NetworkCredential
    Public Property Port() As Integer
    Public Property URI() As String

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
        Credentials = New NetworkCredential
        Port = 0
        URI = String.Empty
    End Sub

#End Region 'Methods 

End Class

<Serializable()>
Public Class RegexEpisodeSpecification
    Inherits List(Of RegexEpisodeItemSpecification)

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub SetDefaults()
        Clear()
        Add(New RegexEpisodeItemSpecification With {.ID = 0, .ByDate = False, .DefaultSeason = -1, .Regexp = "s([0-9]+)[ ._-]*e([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)([^\\\/]*)$"})
        Add(New RegexEpisodeItemSpecification With {.ID = 1, .ByDate = False, .DefaultSeason = 1, .Regexp = "[\\._ -]()e(?:p[ ._-]?)?([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)([^\\\/]*)$"})
        Add(New RegexEpisodeItemSpecification With {.ID = 2, .ByDate = True, .DefaultSeason = -1, .Regexp = "([0-9]{4})[.-]([0-9]{2})[.-]([0-9]{2})"})
        Add(New RegexEpisodeItemSpecification With {.ID = 3, .ByDate = True, .DefaultSeason = -1, .Regexp = "([0-9]{2})[.-]([0-9]{2})[.-]([0-9]{4})"})
        Add(New RegexEpisodeItemSpecification With {.ID = 4, .ByDate = False, .DefaultSeason = -1, .Regexp = "[\\\/._ \[\(-]([0-9]+)x([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)([^\\\/]*)$"})
        Add(New RegexEpisodeItemSpecification With {.ID = 5, .ByDate = False, .DefaultSeason = -1, .Regexp = "[\\\/._ -]([0-9]+)([0-9][0-9](?:(?:[a-i]|\.[1-9])(?![0-9]))?)([._ -][^\\\/]*)$"})
        Add(New RegexEpisodeItemSpecification With {.ID = 6, .ByDate = False, .DefaultSeason = 1, .Regexp = "[\\\/._ -]p(?:ar)?t[_. -]()([ivx]+|[0-9]+)([._ -][^\\\/]*)$"})
        Add(New RegexEpisodeItemSpecification With {.ID = 7, .ByDate = False, .DefaultSeason = -1, .Regexp = "[Ss]([0-9]+)[ ._-]*[Ee]([0-9]+)([^\\/]*)(?:(?:[\\/]VIDEO_TS)?[\\/]VIDEO_TS\.IFO)$"})
        Add(New RegexEpisodeItemSpecification With {.ID = 8, .ByDate = False, .DefaultSeason = -1, .Regexp = "[Ss]([0-9]+)[ ._-]*[Ee]([0-9]+)([^\\/]*)(?:(?:[\\/]bdmv)?[\\/]index\.bdmv)$"})
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class RegexEpisodeItemSpecification

#Region "Properties"

    Public Property ByDate() As Boolean
    Public Property DefaultSeason() As Integer
    Public Property ID() As Integer
    Public Property Regexp() As String

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub Clear()
        ByDate = False
        DefaultSeason = -1
        ID = -1
        Regexp = String.Empty
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class SourceSettings_Movie

#Region "Properties"

    Public Property CleanDB() As Boolean
    Public Property DefaultLanguage As String
    Public Property IgnoreLastScan As Boolean
    Public Property LevTolerance() As Integer
    <XmlIgnore()>
    Public ReadOnly Property LevToleranceSpecified() As Boolean
        Get
            Return LevTolerance > 0
        End Get
    End Property
    Public Property MarkNew As Boolean
    Public Property ScanOrderModify As Boolean
    Public Property SkipLessThan As Integer
    Public Property SkipStackedSizeCheck As Boolean
    Public Property SortBeforeScan() As Boolean
    Public Property TitleFilter As TitleFilterSpecification
    Public Property TitleFilterIsEmpty As Boolean
    Public Property TitleProperCase As Boolean
    Public Property VideoSourceFromFolder As Boolean

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
        CleanDB = False
        DefaultLanguage = "en-US"
        IgnoreLastScan = True
        LevTolerance = 0
        MarkNew = False
        ScanOrderModify = False
        SkipLessThan = 0
        SkipStackedSizeCheck = False
        SortBeforeScan = False
        TitleFilter = New TitleFilterSpecification
        TitleFilter.SetDefaults(Enums.ContentType.Movie, True)
        TitleFilterIsEmpty = False
        TitleProperCase = True
        VideoSourceFromFolder = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class SourceSettings_Movieset

#Region "Properties"

    Public Property CleanDB() As Boolean
    Public Property MarkNew As Boolean
    Public Property RemoveFiles As Boolean

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
        CleanDB = False
        RemoveFiles = False
        MarkNew = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class SourceSettings_TV

#Region "Properties"

    Public Property CleanDB() As Boolean
    Public Property DefaultEpisodeOrdering() As Enums.EpisodeOrdering
    Public Property DefaultLanguage As String
    Public Property IgnoreLastScan As Boolean
    Public Property MultiPartMatching As String
    Public Property TVShowMatching As RegexEpisodeSpecification
    Public Property ScanOrderModify As Boolean
    Public Property SkipLessThan As Integer
    Public Property SkipStackedSizeCheck As Boolean
    Public Property TVEpisode As SourceSettings_TVEpisode
    Public Property TVShow As SourceSettings_TVShow

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
        CleanDB = False
        DefaultEpisodeOrdering = Enums.EpisodeOrdering.Standard
        DefaultLanguage = "en-US"
        IgnoreLastScan = True
        MultiPartMatching = "^[-_ex]+([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)"
        TVShowMatching = New RegexEpisodeSpecification
        TVShowMatching.SetDefaults()
        ScanOrderModify = False
        SkipLessThan = 0
        SkipStackedSizeCheck = False
        TVEpisode = New SourceSettings_TVEpisode
        TVShow = New SourceSettings_TVShow
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class SourceSettings_TVEpisode

#Region "Properties"

    Public Property MarkNew As Boolean
    Public Property TitleFilter As TitleFilterSpecification
    Public Property TitleFilterIsDisabled As Boolean
    Public Property TitleFilterIsEmpty As Boolean
    Public Property TitleProperCase As Boolean
    Public Property VideoSourceFromFolder As Boolean

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
        MarkNew = False
        TitleFilter = New TitleFilterSpecification
        TitleFilter.SetDefaults(Enums.ContentType.TVEpisode, True)
        TitleFilterIsDisabled = True
        TitleFilterIsEmpty = False
        TitleProperCase = True
        VideoSourceFromFolder = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class SourceSettings_TVShow

#Region "Properties"

    Public Property MarkNew As Boolean
    Public Property TitleFilter As TitleFilterSpecification
    Public Property TitleFilterIsEmpty As Boolean
    Public Property TitleProperCase As Boolean

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
        MarkNew = False
        TitleFilter = New TitleFilterSpecification
        TitleFilter.SetDefaults(Enums.ContentType.TVShow, True)
        TitleFilterIsEmpty = False
        TitleProperCase = True
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ThemeSettings

#Region "Properties"
    Public Property DefaultSearch() As String
    Public Property KeepExisting() As Boolean

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
        DefaultSearch = "theme"
        KeepExisting = False
    End Sub

#End Region 'Methods

End Class

Public Class TitleFilterSpecification
    Inherits List(Of String)

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
                Add("(?i)[\W_]\(?\d{4}\)?.*")    'year in brakets
                Add("(?i)[\W_]tt\d*")            'IMDB ID
                Add("(?i)[\W_]blu[\W_]?ray.*")
                Add("(?i)[\W_]bd[\W_]?rip.*")
                Add("(?i)[\W_]3d.*")
                Add("(?i)[\W_]dvd.*")
                Add("(?i)[\W_]720.*")
                Add("(?i)[\W_]1080.*")
                Add("(?i)[\W_]1440.*")
                Add("(?i)[\W_]2160.*")
                Add("(?i)[\W_]4k.*")
                Add("(?i)[\W_]ac3.*")
                Add("(?i)[\W_]dts.*")
                Add("(?i)[\W_]divx.*")
                Add("(?i)[\W_]xvid.*")
                Add("(?i)[\W_]dc[\W_]?.*")
                Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
                Add("(?i)[\W_]extended.*")
                Add("(?i)[\W_]hd(tv)?.*")
                Add("(?i)[\W_]unrated.*")
                Add("(?i)[\W_]uncut.*")
                Add("(?i)[\W_]german.*")
                Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
                Add("(?i)[\W_]\[offline\].*")
                Add("(?i)[\W_]ntsc.*")
                Add("[\W_]PAL[\W_]?.*")
                Add("\.[->] ")                   'convert dots to space
                Add("_[->] ")                    'convert underscore to space
            Case Enums.ContentType.TVEpisode
                Clear()
                Add("[\W_]\(?\d{4}\)?.*")
                Add("(?i)([\W_]+\s?)?s[0-9]+[\W_]*([-e][0-9]+)+(\])*")
                Add("(?i)([\W_]+\s?)?[0-9]+([-x][0-9]+)+(\])*")
                Add("(?i)([\W_]+\s?)?s(eason)?[\W_]*[0-9]+(\])*")
                Add("(?i)([\W_]+\s?)?e(pisode)?[\W_]*[0-9]+(\])*")
                Add("(?i)[\W_]blu[\W_]?ray.*")
                Add("(?i)[\W_]bd[\W_]?rip.*")
                Add("(?i)[\W_]dvd.*")
                Add("(?i)[\W_]720.*")
                Add("(?i)[\W_]1080.*")
                Add("(?i)[\W_]1440.*")
                Add("(?i)[\W_]2160.*")
                Add("(?i)[\W_]4k.*")
                Add("(?i)[\W_]ac3.*")
                Add("(?i)[\W_]dts.*")
                Add("(?i)[\W_]divx.*")
                Add("(?i)[\W_]xvid.*")
                Add("(?i)[\W_]dc[\W_]?.*")
                Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
                Add("(?i)[\W_]extended.*")
                Add("(?i)[\W_]hd(tv)?.*")
                Add("(?i)[\W_]unrated.*")
                Add("(?i)[\W_]uncut.*")
                Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
                Add("(?i)[\W_]\[offline\].*")
                Add("(?i)[\W_]ntsc.*")
                Add("[\W_]PAL[\W_]?.*")
                Add("\.[->] ")               'convert dots to space
                Add("_[->] ")                'convert underscore to space
                Add(" - [->] ")              'convert space-minus-space to space
            Case Enums.ContentType.TVShow
                Clear()
                Add("[\W_]\(?\d{4}\)?.*")
                Add("(?i)[\W_]blu[\W_]?ray.*")
                Add("(?i)[\W_]bd[\W_]?rip.*")
                Add("(?i)[\W_]dvd.*")
                Add("(?i)[\W_]720.*")
                Add("(?i)[\W_]1080.*")
                Add("(?i)[\W_]1440.*")
                Add("(?i)[\W_]2160.*")
                Add("(?i)[\W_]4k.*")
                Add("(?i)[\W_]ac3.*")
                Add("(?i)[\W_]dts.*")
                Add("(?i)[\W_]divx.*")
                Add("(?i)[\W_]xvid.*")
                Add("(?i)[\W_]dc[\W_]?.*")
                Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
                Add("(?i)[\W_]extended.*")
                Add("(?i)[\W_]hd(tv)?.*")
                Add("(?i)[\W_]unrated.*")
                Add("(?i)[\W_]uncut.*")
                Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
                Add("(?i)[\W_]\[offline\].*")
                Add("(?i)[\W_]ntsc.*")
                Add("[\W_]PAL[\W_]?.*")
                Add("\.[->] ")                  'convert dots to space
                Add("_[->] ")                   'convert underscore to space
        End Select
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class TrailerSettings

#Region "Properties"
    Public Property DefaultSearch() As String
    Public Property KeepExisting() As Boolean
    Public Property MinVideoQuality() As Enums.TrailerVideoQuality
    Public Property PrefVideoQuality() As Enums.TrailerVideoQuality

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
        DefaultSearch = "trailer"
        KeepExisting = False
        MinVideoQuality = Enums.TrailerVideoQuality.Any
        PrefVideoQuality = Enums.TrailerVideoQuality.Any
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class TV

#Region "Properties"

    Public Property DataSettings As DataSettings_TV
    Public Property Filenaming As FilenamingSettings_TV
    Public Property ImageSettings() As ImageSettings_TV
    Public Property SourceSettings As SourceSettings_TV
    Public Property ThemeSettings() As ThemeSettings

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
        DataSettings = New DataSettings_TV
        Filenaming = New FilenamingSettings_TV
        ImageSettings = New ImageSettings_TV
        SourceSettings = New SourceSettings_TV
        ThemeSettings = New ThemeSettings

        ImageSettings.TVShow.CacheEnabled = True
    End Sub

#End Region 'Methods

End Class