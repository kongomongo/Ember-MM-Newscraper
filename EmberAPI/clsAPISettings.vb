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

    Private _movie As New Movie
    Private _movieset As New Movieset
    Private _options As New Options
    Private _tv As New TV

    Private _addons As List(Of AddonsManager._XMLAddonClass)
    Private _generalcheckupdates As Boolean
    Private _generaldaemondrive As String
    Private _generaldaemonpath As String
    Private _generaldateaddedignorenfo As Boolean
    Private _generaldatetime As Enums.DateTime
    Private _generaldigitgrpsymbolvotes As Boolean
    Private _generalimagefilter As Boolean
    Private _generalimagefilterautoscraper As Boolean
    Private _generalimagefilterfanart As Boolean
    Private _generalimagefilterfanartmatchtolerance As Integer
    Private _generalimagefilterimagedialog As Boolean
    Private _generalimagefilterposter As Boolean
    Private _generalimagefilterpostermatchtolerance As Integer
    Private _generallanguage As String
    Private _generaloverwritenfo As Boolean
    Private _generalsourcefromfolder As Boolean
    Private _moviecleandb As Boolean
    Private _moviedatascrapersettings As List(Of ScraperSettings)
    Private _moviefiltercustom As List(Of String)
    Private _moviefiltercustomisempty As Boolean
    Private _moviegeneralflaglang As String
    Private _moviegeneralignorelastscan As Boolean
    Private _moviegenerallanguage As String
    Private _moviegeneralmarknew As Boolean
    Private _movielevtolerance As Integer
    Private _moviemetadataperfiletype As List(Of MetadataPerType)
    Private _moviepropercase As Boolean
    Private _moviescanordermodify As Boolean
    Private _moviescraperusedetailview As Boolean
    Private _moviesetcleandb As Boolean
    Private _moviesetcleanfiles As Boolean
    Private _moviesetclickscrape As Boolean
    Private _moviesetclickscrapeask As Boolean
    Private _moviesetgeneralmarknew As Boolean
    Private _moviesetsorttokens As List(Of String)
    Private _moviesetsorttokensisempty As Boolean
    Private _movieskiplessthan As Integer
    Private _movieskipstackedsizecheck As Boolean
    Private _moviesortbeforescan As Boolean
    Private _moviesorttokens As List(Of String)
    Private _moviesorttokensisempty As Boolean
    Private _ommdummyformat As Integer
    Private _ommdummytagline As String
    Private _ommdummytop As String
    Private _ommdummyusebackground As Boolean
    Private _ommdummyusefanart As Boolean
    Private _ommdummyuseoverlay As Boolean
    Private _ommmediastubtagline As String
    Private _sortpath As String
    Private _tvcleandb As Boolean
    Private _tvdisplaymissingepisodes As Boolean
    Private _tvepisodefiltercustom As List(Of String)
    Private _tvepisodefiltercustomisempty As Boolean
    Private _tvepisodenofilter As Boolean
    Private _tvepisodepropercase As Boolean
    Private _tvgeneralclickscrape As Boolean
    Private _tvgeneralclickscrapeask As Boolean
    Private _tvgeneralflaglang As String
    Private _tvgeneralignorelastscan As Boolean
    Private _tvgenerallanguage As String
    Private _tvgeneralmarknewepisodes As Boolean
    Private _tvgeneralmarknewshows As Boolean
    Private _tvimagescacheenabled As Boolean
    Private _tvimagesdisplayimageselect As Boolean
    Private _tvmetadataperfiletype As List(Of MetadataPerType)
    Private _tvmultipartmatching As String
    Private _tvscanordermodify As Boolean
    Private _tvscraperepisodecastwithimgonly As Boolean
    Private _tvscraperepisodegueststarstoactors As Boolean
    Private _tvscraperoptionsordering As Enums.EpisodeOrdering
    Private _tvscraperusedisplayseasonepisode As Boolean
    Private _tvscraperusesruntimeforep As Boolean
    Private _tvshowfiltercustom As List(Of String)
    Private _tvshowfiltercustomisempty As Boolean
    Private _tvshowmatching As List(Of regexp)
    Private _tvshowpropercase As Boolean
    Private _tvskiplessthan As Integer
    Private _tvsorttokens As List(Of String)
    Private _tvsorttokensisempty As Boolean
    Private _version As String


    '***************************************************
    '***************** MovieSet Part *******************
    '***************************************************

    '*************** Kodi Extended settings ***************
    Private _moviesetuseextended As Boolean
    Private _moviesetbannerextended As Boolean
    Private _moviesetclearartextended As Boolean
    Private _moviesetclearlogoextended As Boolean
    Private _moviesetdiscartextended As Boolean
    Private _moviesetfanartextended As Boolean
    Private _moviesetlandscapeextended As Boolean
    Private _moviesetpathextended As String
    Private _moviesetposterextended As Boolean

    '*************** Kodi MSAA settings ***************
    Private _moviesetusemsaa As Boolean
    Private _moviesetbannermsaa As Boolean
    Private _moviesetclearartmsaa As Boolean
    Private _moviesetclearlogomsaa As Boolean
    Private _moviesetfanartmsaa As Boolean
    Private _moviesetlandscapemsaa As Boolean
    Private _moviesetpathmsaa As String
    Private _moviesetpostermsaa As Boolean

    '***************** Expert settings *****************
    Private _moviesetuseexpert As Boolean
    Private _moviesetbannerexpertsingle As String
    Private _moviesetclearartexpertsingle As String
    Private _moviesetclearlogoexpertsingle As String
    Private _moviesetdiscartexpertsingle As String
    Private _moviesetfanartexpertsingle As String
    Private _moviesetlandscapeexpertsingle As String
    Private _moviesetnfoexpertsingle As String
    Private _moviesetpathexpertsingle As String
    Private _moviesetposterexpertsingle As String


    '***************************************************
    '****************** TV Show Part *******************
    '***************************************************

    '*************** Kodi Frodo settings ***************
    Private _tvusefrodo As Boolean
    Private _tvepisodeactorthumbsfrodo As Boolean
    Private _tvepisodenfofrodo As Boolean
    Private _tvepisodeposterfrodo As Boolean
    Private _tvseasonbannerfrodo As Boolean
    Private _tvseasonfanartfrodo As Boolean
    Private _tvseasonposterfrodo As Boolean
    Private _tvshowactorthumbsfrodo As Boolean
    Private _tvshowbannerfrodo As Boolean
    Private _tvshowextrafanartsfrodo As Boolean
    Private _tvshowfanartfrodo As Boolean
    Private _tvshownfofrodo As Boolean
    Private _tvshowposterfrodo As Boolean

    '*************** Kodi Eden settings ****************
    Private _tvuseeden As Boolean

    '******** Kodi ArtworkDownloader settings **********
    Private _tvusead As Boolean
    Private _tvseasonlandscapead As Boolean
    Private _tvshowcharacterartad As Boolean
    Private _tvshowclearartad As Boolean
    Private _tvshowclearlogoad As Boolean
    Private _tvshowlandscapead As Boolean

    '********* Kodi Extended Images settings **********
    Private _tvuseextended As Boolean
    Private _tvseasonlandscapeextended As Boolean
    Private _tvshowcharacterartextended As Boolean
    Private _tvshowclearartextended As Boolean
    Private _tvshowclearlogoextended As Boolean
    Private _tvshowlandscapeextended As Boolean

    '*************** Kodi TvTunes settings ***************
    Private _tvshowthemetvtunesenable As Boolean
    Private _tvshowthemetvtunescustom As Boolean
    Private _tvshowthemetvtunescustompath As String
    Private _tvshowthemetvtunesshowpath As Boolean
    Private _tvshowthemetvtunessub As Boolean
    Private _tvshowthemetvtunessubdir As String

    '****************** YAMJ settings ******************
    Private _tvuseyamj As Boolean
    Private _tvepisodenfoyamj As Boolean
    Private _tvepisodeposteryamj As Boolean
    Private _tvseasonbanneryamj As Boolean
    Private _tvseasonfanartyamj As Boolean
    Private _tvseasonposteryamj As Boolean
    Private _tvshowbanneryamj As Boolean
    Private _tvshowfanartyamj As Boolean
    Private _tvshownfoyamj As Boolean
    Private _tvshowposteryamj As Boolean

    '****************** NMJ settings *******************

    '************** NMT optional settings **************

    '***************** Boxee settings ******************
    Private _tvuseboxee As Boolean
    Private _tvepisodenfoboxee As Boolean
    Private _tvepisodeposterboxee As Boolean
    Private _tvseasonposterboxee As Boolean
    Private _tvshowbannerboxee As Boolean
    Private _tvshowfanartboxee As Boolean
    Private _tvshownfoboxee As Boolean
    Private _tvshowposterboxee As Boolean

    '***************** Expert settings *****************
    Private _tvuseexpert As Boolean

    '***************** Expert AllSeasons ***************
    Private _tvallseasonsbannerexpert As String
    Private _tvallseasonsfanartexpert As String
    Private _tvallseasonslandscapeexpert As String
    Private _tvallseasonsposterexpert As String

    '***************** Expert Episode ******************
    Private _tvepisodeactorthumbsexpert As Boolean
    Private _tvepisodeactorthumbsextexpert As String
    Private _tvepisodefanartexpert As String
    Private _tvepisodenfoexpert As String
    Private _tvepisodeposterexpert As String

    '***************** Expert Season *******************
    Private _tvseasonbannerexpert As String
    Private _tvseasonfanartexpert As String
    Private _tvseasonlandscapeexpert As String
    Private _tvseasonposterexpert As String

    '***************** Expert Show *********************
    Private _tvshowactorthumbsexpert As Boolean
    Private _tvshowactorthumbsextexpert As String
    Private _tvshowbannerexpert As String
    Private _tvshowcharacterartexpert As String
    Private _tvshowclearartexpert As String
    Private _tvshowclearlogoexpert As String
    Private _tvshowextrafanartsexpert As Boolean
    Private _tvshowfanartexpert As String
    Private _tvshowlandscapeexpert As String
    Private _tvshownfoexpert As String
    Private _tvshowposterexpert As String

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

    Public Property MovieGeneralLanguage() As String
        Get
            Return _moviegenerallanguage
        End Get
        Set(ByVal value As String)
            _moviegenerallanguage = If(String.IsNullOrEmpty(value), "en-US", value)
        End Set
    End Property

    Public Property TVGeneralLanguage() As String
        Get
            Return _tvgenerallanguage
        End Get
        Set(ByVal value As String)
            _tvgenerallanguage = If(String.IsNullOrEmpty(value), "en-US", value)
        End Set
    End Property

    Public Property TVScraperEpisodeCastWithImgOnly() As Boolean
        Get
            Return _tvscraperepisodecastwithimgonly
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodecastwithimgonly = value
        End Set
    End Property

    Public Property GeneralCheckUpdates() As Boolean
        Get
            Return _generalcheckupdates
        End Get
        Set(ByVal value As Boolean)
            _generalcheckupdates = value
        End Set
    End Property

    Public Property MovieCleanDB() As Boolean
        Get
            Return _moviecleandb
        End Get
        Set(ByVal value As Boolean)
            _moviecleandb = value
        End Set
    End Property

    Public Property MovieSetCleanDB() As Boolean
        Get
            Return _moviesetcleandb
        End Get
        Set(ByVal value As Boolean)
            _moviesetcleandb = value
        End Set
    End Property

    Public Property MovieSetCleanFiles() As Boolean
        Get
            Return _moviesetcleanfiles
        End Get
        Set(ByVal value As Boolean)
            _moviesetcleanfiles = value
        End Set
    End Property

    Public Property TVDisplayMissingEpisodes() As Boolean
        Get
            Return _tvdisplaymissingepisodes
        End Get
        Set(ByVal value As Boolean)
            _tvdisplaymissingepisodes = value
        End Set
    End Property

    Public Property TVImagesCacheEnabled() As Boolean
        Get
            Return _tvimagescacheenabled
        End Get
        Set(ByVal value As Boolean)
            _tvimagescacheenabled = value
        End Set
    End Property

    Public Property TVImagesDisplayImageSelect() As Boolean
        Get
            Return _tvimagesdisplayimageselect
        End Get
        Set(ByVal value As Boolean)
            _tvimagesdisplayimageselect = value
        End Set
    End Property

    Public Property TVScraperOptionsOrdering() As Enums.EpisodeOrdering
        Get
            Return _tvscraperoptionsordering
        End Get
        Set(ByVal value As Enums.EpisodeOrdering)
            _tvscraperoptionsordering = value
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

    Public Property TVEpisodeFilterCustom() As List(Of String)
        Get
            Return _tvepisodefiltercustom
        End Get
        Set(ByVal value As List(Of String))
            _tvepisodefiltercustom = value
        End Set
    End Property

    Public Property TVEpisodeProperCase() As Boolean
        Get
            Return _tvepisodepropercase
        End Get
        Set(ByVal value As Boolean)
            _tvepisodepropercase = value
        End Set
    End Property

    Public Property MovieScraperUseDetailView() As Boolean
        Get
            Return _moviescraperusedetailview
        End Get
        Set(ByVal value As Boolean)
            _moviescraperusedetailview = value
        End Set
    End Property

    Public Property MovieFilterCustom() As List(Of String)
        Get
            Return _moviefiltercustom
        End Get
        Set(ByVal value As List(Of String))
            _moviefiltercustom = value
        End Set
    End Property

    Public Property GeneralImageFilter() As Boolean
        Get
            Return _generalimagefilter
        End Get
        Set(ByVal value As Boolean)
            _generalimagefilter = value
        End Set
    End Property

    Public Property GeneralImageFilterAutoscraper() As Boolean
        Get
            Return _generalimagefilterautoscraper
        End Get
        Set(ByVal value As Boolean)
            _generalimagefilterautoscraper = value
        End Set
    End Property

    Public Property GeneralImageFilterImagedialog() As Boolean
        Get
            Return _generalimagefilterimagedialog
        End Get
        Set(ByVal value As Boolean)
            _generalimagefilterimagedialog = value
        End Set
    End Property

    Public Property GeneralImageFilterFanart() As Boolean
        Get
            Return _generalimagefilterfanart
        End Get
        Set(ByVal value As Boolean)
            _generalimagefilterfanart = value
        End Set
    End Property

    Public Property GeneralImageFilterPoster() As Boolean
        Get
            Return _generalimagefilterposter
        End Get
        Set(ByVal value As Boolean)
            _generalimagefilterposter = value
        End Set
    End Property

    Public Property GeneralImageFilterPosterMatchTolerance() As Integer
        Get
            Return _generalimagefilterpostermatchtolerance
        End Get
        Set(ByVal value As Integer)
            _generalimagefilterpostermatchtolerance = value
        End Set
    End Property
    Public Property GeneralImageFilterFanartMatchTolerance() As Integer
        Get
            Return _generalimagefilterfanartmatchtolerance
        End Get
        Set(ByVal value As Integer)
            _generalimagefilterfanartmatchtolerance = value
        End Set
    End Property

    Public Property MovieGeneralFlagLang() As String
        Get
            Return _moviegeneralflaglang
        End Get
        Set(ByVal value As String)
            _moviegeneralflaglang = value
        End Set
    End Property

    Public Property MovieGeneralIgnoreLastScan() As Boolean
        Get
            Return _moviegeneralignorelastscan
        End Get
        Set(ByVal value As Boolean)
            _moviegeneralignorelastscan = value
        End Set
    End Property

    Public Property GeneralLanguage() As String
        Get
            Return _generallanguage
        End Get
        Set(ByVal value As String)
            _generallanguage = value
        End Set
    End Property

    Public Property MovieLevTolerance() As Integer
        Get
            Return _movielevtolerance
        End Get
        Set(ByVal value As Integer)
            _movielevtolerance = value
        End Set
    End Property

    Public Property MovieGeneralMarkNew() As Boolean
        Get
            Return _moviegeneralmarknew
        End Get
        Set(ByVal value As Boolean)
            _moviegeneralmarknew = value
        End Set
    End Property

    Public Property MovieSetGeneralMarkNew() As Boolean
        Get
            Return _moviesetgeneralmarknew
        End Get
        Set(ByVal value As Boolean)
            _moviesetgeneralmarknew = value
        End Set
    End Property

    Public Property TVGeneralClickScrape() As Boolean
        Get
            Return _tvgeneralclickscrape
        End Get
        Set(ByVal value As Boolean)
            _tvgeneralclickscrape = value
        End Set
    End Property

    Public Property TVGeneralClickScrapeask() As Boolean
        Get
            Return _tvgeneralclickscrapeask
        End Get
        Set(ByVal value As Boolean)
            _tvgeneralclickscrapeask = value
        End Set
    End Property

    Public Property TVGeneralMarkNewEpisodes() As Boolean
        Get
            Return _tvgeneralmarknewepisodes
        End Get
        Set(ByVal value As Boolean)
            _tvgeneralmarknewepisodes = value
        End Set
    End Property

    Public Property TVGeneralMarkNewShows() As Boolean
        Get
            Return _tvgeneralmarknewshows
        End Get
        Set(ByVal value As Boolean)
            _tvgeneralmarknewshows = value
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

    Public Property MovieSetClickScrape() As Boolean
        Get
            Return _moviesetclickscrape
        End Get
        Set(ByVal value As Boolean)
            _moviesetclickscrape = value
        End Set
    End Property

    Public Property MovieSetClickScrapeAsk() As Boolean
        Get
            Return _moviesetclickscrapeask
        End Get
        Set(ByVal value As Boolean)
            _moviesetclickscrapeask = value
        End Set
    End Property

    Public Property GeneralDaemonPath() As String
        Get
            Return _generaldaemonpath
        End Get
        Set(ByVal value As String)
            _generaldaemonpath = value
        End Set
    End Property

    Public Property GeneralDaemonDrive() As String
        Get
            Return _generaldaemondrive
        End Get
        Set(ByVal value As String)
            _generaldaemondrive = value
        End Set
    End Property

    Public Property TVEpisodeFilterCustomIsEmpty() As Boolean
        Get
            Return _tvepisodefiltercustomisempty
        End Get
        Set(ByVal value As Boolean)
            _tvepisodefiltercustomisempty = value
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

    Public Property MovieFilterCustomIsEmpty() As Boolean
        Get
            Return _moviefiltercustomisempty
        End Get
        Set(ByVal value As Boolean)
            _moviefiltercustomisempty = value
        End Set
    End Property

    Public Property TVShowFilterCustomIsEmpty() As Boolean
        Get
            Return _tvshowfiltercustomisempty
        End Get
        Set(ByVal value As Boolean)
            _tvshowfiltercustomisempty = value
        End Set
    End Property

    Public Property MovieSortTokensIsEmpty() As Boolean
        Get
            Return _moviesorttokensisempty
        End Get
        Set(ByVal value As Boolean)
            _moviesorttokensisempty = value
        End Set
    End Property

    Public Property MovieSetSortTokensIsEmpty() As Boolean
        Get
            Return _moviesetsorttokensisempty
        End Get
        Set(ByVal value As Boolean)
            _moviesetsorttokensisempty = value
        End Set
    End Property

    Public Property TVSortTokensIsEmpty() As Boolean
        Get
            Return _tvsorttokensisempty
        End Get
        Set(ByVal value As Boolean)
            _tvsorttokensisempty = value
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

    Public Property GeneralOverwriteNfo() As Boolean
        Get
            Return _generaloverwritenfo
        End Get
        Set(ByVal value As Boolean)
            _generaloverwritenfo = value
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

    Public Property MovieProperCase() As Boolean
        Get
            Return _moviepropercase
        End Get
        Set(ByVal value As Boolean)
            _moviepropercase = value
        End Set
    End Property

    Public Property MovieScanOrderModify() As Boolean
        Get
            Return _moviescanordermodify
        End Get
        Set(ByVal value As Boolean)
            _moviescanordermodify = value
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

    Public Property TVShowFilterCustom() As List(Of String)
        Get
            Return _tvshowfiltercustom
        End Get
        Set(ByVal value As List(Of String))
            _tvshowfiltercustom = value
        End Set
    End Property

    Public Property TVShowProperCase() As Boolean
        Get
            Return _tvshowpropercase
        End Get
        Set(ByVal value As Boolean)
            _tvshowpropercase = value
        End Set
    End Property

    Public Property MovieSkipLessThan() As Integer
        Get
            Return _movieskiplessthan
        End Get
        Set(ByVal value As Integer)
            _movieskiplessthan = value
        End Set
    End Property

    Public Property MovieSkipStackedSizeCheck() As Boolean
        Get
            Return _movieskipstackedsizecheck
        End Get
        Set(ByVal value As Boolean)
            _movieskipstackedsizecheck = value
        End Set
    End Property

    Public Property TVSkipLessThan() As Integer
        Get
            Return _tvskiplessthan
        End Get
        Set(ByVal value As Integer)
            _tvskiplessthan = value
        End Set
    End Property

    Public Property MovieSortBeforeScan() As Boolean
        Get
            Return _moviesortbeforescan
        End Get
        Set(ByVal value As Boolean)
            _moviesortbeforescan = value
        End Set
    End Property

    Public Property SortPath() As String
        Get
            Return _sortpath
        End Get
        Set(ByVal value As String)
            _sortpath = value
        End Set
    End Property

    Public Property MovieSortTokens() As List(Of String)
        Get
            Return _moviesorttokens
        End Get
        Set(ByVal value As List(Of String))
            _moviesorttokens = value
        End Set
    End Property

    Public Property MovieSetSortTokens() As List(Of String)
        Get
            Return _moviesetsorttokens
        End Get
        Set(ByVal value As List(Of String))
            _moviesetsorttokens = value
        End Set
    End Property

    Public Property TVSortTokens() As List(Of String)
        Get
            Return _tvsorttokens
        End Get
        Set(ByVal value As List(Of String))
            _tvsorttokens = value
        End Set
    End Property

    Public Property GeneralSourceFromFolder() As Boolean
        Get
            Return _generalsourcefromfolder
        End Get
        Set(ByVal value As Boolean)
            _generalsourcefromfolder = value
        End Set
    End Property

    Public Property TVCleanDB() As Boolean
        Get
            Return _tvcleandb
        End Get
        Set(ByVal value As Boolean)
            _tvcleandb = value
        End Set
    End Property

    Public Property TVGeneralFlagLang() As String
        Get
            Return _tvgeneralflaglang
        End Get
        Set(ByVal value As String)
            _tvgeneralflaglang = value
        End Set
    End Property

    Public Property TVGeneralIgnoreLastScan() As Boolean
        Get
            Return _tvgeneralignorelastscan
        End Get
        Set(ByVal value As Boolean)
            _tvgeneralignorelastscan = value
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

    Public Property TVScanOrderModify() As Boolean
        Get
            Return _tvscanordermodify
        End Get
        Set(ByVal value As Boolean)
            _tvscanordermodify = value
        End Set
    End Property

    Public Property TVMultiPartMatching() As String
        Get
            Return _tvmultipartmatching
        End Get
        Set(ByVal value As String)
            _tvmultipartmatching = value
        End Set
    End Property

    Public Property TVShowMatching() As List(Of regexp)
        Get
            Return _tvshowmatching
        End Get
        Set(ByVal value As List(Of regexp))
            _tvshowmatching = value
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

    Public Property GeneralDateTime() As Enums.DateTime
        Get
            Return _generaldatetime
        End Get
        Set(ByVal value As Enums.DateTime)
            _generaldatetime = value
        End Set
    End Property

    Public Property GeneralDateAddedIgnoreNFO() As Boolean
        Get
            Return _generaldateaddedignorenfo
        End Get
        Set(ByVal value As Boolean)
            _generaldateaddedignorenfo = value
        End Set
    End Property

    Public Property GeneralDigitGrpSymbolVotes() As Boolean
        Get
            Return _generaldigitgrpsymbolvotes
        End Get
        Set(ByVal value As Boolean)
            _generaldigitgrpsymbolvotes = value
        End Set
    End Property

    Public Property MovieSetBannerExtended() As Boolean
        Get
            Return _moviesetbannerextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetbannerextended = value
        End Set
    End Property

    Public Property MovieSetClearArtExtended() As Boolean
        Get
            Return _moviesetclearartextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearartextended = value
        End Set
    End Property

    Public Property MovieSetClearLogoExtended() As Boolean
        Get
            Return _moviesetclearlogoextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearlogoextended = value
        End Set
    End Property

    Public Property MovieSetDiscArtExtended() As Boolean
        Get
            Return _moviesetdiscartextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetdiscartextended = value
        End Set
    End Property

    Public Property MovieSetFanartExtended() As Boolean
        Get
            Return _moviesetfanartextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetfanartextended = value
        End Set
    End Property

    Public Property MovieSetLandscapeExtended() As Boolean
        Get
            Return _moviesetlandscapeextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetlandscapeextended = value
        End Set
    End Property

    Public Property MovieSetPathExtended() As String
        Get
            Return _moviesetpathextended
        End Get
        Set(ByVal value As String)
            _moviesetpathextended = value
        End Set
    End Property

    Public Property MovieSetPosterExtended() As Boolean
        Get
            Return _moviesetposterextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetposterextended = value
        End Set
    End Property

    Public Property MovieSetUseExtended() As Boolean
        Get
            Return _moviesetuseextended
        End Get
        Set(ByVal value As Boolean)
            _moviesetuseextended = value
        End Set
    End Property

    Public Property MovieSetUseMSAA() As Boolean
        Get
            Return _moviesetusemsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetusemsaa = value
        End Set
    End Property

    Public Property MovieSetBannerMSAA() As Boolean
        Get
            Return _moviesetbannermsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetbannermsaa = value
        End Set
    End Property

    Public Property MovieSetClearArtMSAA() As Boolean
        Get
            Return _moviesetclearartmsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearartmsaa = value
        End Set
    End Property

    Public Property MovieSetClearLogoMSAA() As Boolean
        Get
            Return _moviesetclearlogomsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearlogomsaa = value
        End Set
    End Property

    Public Property MovieSetFanartMSAA() As Boolean
        Get
            Return _moviesetfanartmsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetfanartmsaa = value
        End Set
    End Property

    Public Property MovieSetLandscapeMSAA() As Boolean
        Get
            Return _moviesetlandscapemsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetlandscapemsaa = value
        End Set
    End Property

    Public Property MovieSetPathMSAA() As String
        Get
            Return _moviesetpathmsaa
        End Get
        Set(ByVal value As String)
            _moviesetpathmsaa = value
        End Set
    End Property

    Public Property MovieSetPosterMSAA() As Boolean
        Get
            Return _moviesetpostermsaa
        End Get
        Set(ByVal value As Boolean)
            _moviesetpostermsaa = value
        End Set
    End Property

    Public Property MovieSetUseExpert() As Boolean
        Get
            Return _moviesetuseexpert
        End Get
        Set(ByVal value As Boolean)
            _moviesetuseexpert = value
        End Set
    End Property

    Public Property MovieSetBannerExpertSingle() As String
        Get
            Return _moviesetbannerexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetbannerexpertsingle = value
        End Set
    End Property

    Public Property MovieSetClearArtExpertSingle() As String
        Get
            Return _moviesetclearartexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetclearartexpertsingle = value
        End Set
    End Property

    Public Property MovieSetClearLogoExpertSingle() As String
        Get
            Return _moviesetclearlogoexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetclearlogoexpertsingle = value
        End Set
    End Property

    Public Property MovieSetDiscArtExpertSingle() As String
        Get
            Return _moviesetdiscartexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetdiscartexpertsingle = value
        End Set
    End Property

    Public Property MovieSetFanartExpertSingle() As String
        Get
            Return _moviesetfanartexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetfanartexpertsingle = value
        End Set
    End Property

    Public Property MovieSetLandscapeExpertSingle() As String
        Get
            Return _moviesetlandscapeexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetlandscapeexpertsingle = value
        End Set
    End Property

    Public Property MovieSetNFOExpertSingle() As String
        Get
            Return _moviesetnfoexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetnfoexpertsingle = value
        End Set
    End Property

    Public Property MovieSetPathExpertSingle() As String
        Get
            Return _moviesetpathexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetpathexpertsingle = value
        End Set
    End Property

    Public Property MovieSetPosterExpertSingle() As String
        Get
            Return _moviesetposterexpertsingle
        End Get
        Set(ByVal value As String)
            _moviesetposterexpertsingle = value
        End Set
    End Property

    Public Property TVShowThemeTvTunesEnable() As Boolean
        Get
            Return _tvshowthemetvtunesenable
        End Get
        Set(ByVal value As Boolean)
            _tvshowthemetvtunesenable = value
        End Set
    End Property

    Public Property TVShowThemeTvTunesCustom() As Boolean
        Get
            Return _tvshowthemetvtunescustom
        End Get
        Set(ByVal value As Boolean)
            _tvshowthemetvtunescustom = value
        End Set
    End Property

    Public Property TVShowThemeTvTunesCustomPath() As String
        Get
            Return _tvshowthemetvtunescustompath
        End Get
        Set(ByVal value As String)
            _tvshowthemetvtunescustompath = value
        End Set
    End Property

    Public Property TVShowThemeTvTunesShowPath() As Boolean
        Get
            Return _tvshowthemetvtunesshowpath
        End Get
        Set(ByVal value As Boolean)
            _tvshowthemetvtunesshowpath = value
        End Set
    End Property

    Public Property TVShowThemeTvTunesSub() As Boolean
        Get
            Return _tvshowthemetvtunessub
        End Get
        Set(ByVal value As Boolean)
            _tvshowthemetvtunessub = value
        End Set
    End Property

    Public Property TVShowThemeTvTunesSubDir() As String
        Get
            Return _tvshowthemetvtunessubdir
        End Get
        Set(ByVal value As String)
            _tvshowthemetvtunessubdir = value
        End Set
    End Property

    Public Property TVUseBoxee() As Boolean
        Get
            Return _tvuseboxee
        End Get
        Set(ByVal value As Boolean)
            _tvuseboxee = value
        End Set
    End Property

    Public Property TVUseEden() As Boolean
        Get
            Return _tvuseeden
        End Get
        Set(ByVal value As Boolean)
            _tvuseeden = value
        End Set
    End Property

    Public Property TVUseExpert() As Boolean
        Get
            Return _tvuseexpert
        End Get
        Set(ByVal value As Boolean)
            _tvuseexpert = value
        End Set
    End Property

    Public Property TVUseAD() As Boolean
        Get
            Return _tvusead
        End Get
        Set(ByVal value As Boolean)
            _tvusead = value
        End Set
    End Property

    Public Property TVUseExtended() As Boolean
        Get
            Return _tvuseextended
        End Get
        Set(ByVal value As Boolean)
            _tvuseextended = value
        End Set
    End Property

    Public Property TVUseFrodo() As Boolean
        Get
            Return _tvusefrodo
        End Get
        Set(ByVal value As Boolean)
            _tvusefrodo = value
        End Set
    End Property

    Public Property TVUseYAMJ() As Boolean
        Get
            Return _tvuseyamj
        End Get
        Set(ByVal value As Boolean)
            _tvuseyamj = value
        End Set
    End Property

    Public Property TVShowActorThumbsExpert() As Boolean
        Get
            Return _tvshowactorthumbsexpert
        End Get
        Set(ByVal value As Boolean)
            _tvshowactorthumbsexpert = value
        End Set
    End Property

    Public Property TVShowActorThumbsExtExpert() As String
        Get
            Return _tvshowactorthumbsextexpert
        End Get
        Set(ByVal value As String)
            _tvshowactorthumbsextexpert = value
        End Set
    End Property

    Public Property TVShowActorThumbsFrodo() As Boolean
        Get
            Return _tvshowactorthumbsfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvshowactorthumbsfrodo = value
        End Set
    End Property

    Public Property TVShowBannerBoxee() As Boolean
        Get
            Return _tvshowbannerboxee
        End Get
        Set(ByVal value As Boolean)
            _tvshowbannerboxee = value
        End Set
    End Property

    Public Property TVShowBannerExpert() As String
        Get
            Return _tvshowbannerexpert
        End Get
        Set(ByVal value As String)
            _tvshowbannerexpert = value
        End Set
    End Property

    Public Property TVShowBannerFrodo() As Boolean
        Get
            Return _tvshowbannerfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvshowbannerfrodo = value
        End Set
    End Property

    Public Property TVShowBannerYAMJ() As Boolean
        Get
            Return _tvshowbanneryamj
        End Get
        Set(ByVal value As Boolean)
            _tvshowbanneryamj = value
        End Set
    End Property

    Public Property TVShowCharacterArtExpert() As String
        Get
            Return _tvshowcharacterartexpert
        End Get
        Set(ByVal value As String)
            _tvshowcharacterartexpert = value
        End Set
    End Property

    Public Property TVShowClearArtExpert() As String
        Get
            Return _tvshowclearartexpert
        End Get
        Set(ByVal value As String)
            _tvshowclearartexpert = value
        End Set
    End Property

    Public Property TVShowClearLogoExpert() As String
        Get
            Return _tvshowclearlogoexpert
        End Get
        Set(ByVal value As String)
            _tvshowclearlogoexpert = value
        End Set
    End Property

    Public Property TVShowExtrafanartsExpert() As Boolean
        Get
            Return _tvshowextrafanartsexpert
        End Get
        Set(ByVal value As Boolean)
            _tvshowextrafanartsexpert = value
        End Set
    End Property

    Public Property TVShowExtrafanartsFrodo() As Boolean
        Get
            Return _tvshowextrafanartsfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvshowextrafanartsfrodo = value
        End Set
    End Property

    Public Property TVShowFanartBoxee() As Boolean
        Get
            Return _tvshowfanartboxee
        End Get
        Set(ByVal value As Boolean)
            _tvshowfanartboxee = value
        End Set
    End Property

    Public Property TVShowFanartExpert() As String
        Get
            Return _tvshowfanartexpert
        End Get
        Set(ByVal value As String)
            _tvshowfanartexpert = value
        End Set
    End Property

    Public Property TVShowFanartFrodo() As Boolean
        Get
            Return _tvshowfanartfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvshowfanartfrodo = value
        End Set
    End Property

    Public Property TVShowFanartYAMJ() As Boolean
        Get
            Return _tvshowfanartyamj
        End Get
        Set(ByVal value As Boolean)
            _tvshowfanartyamj = value
        End Set
    End Property

    Public Property TVShowLandscapeExpert() As String
        Get
            Return _tvshowlandscapeexpert
        End Get
        Set(ByVal value As String)
            _tvshowlandscapeexpert = value
        End Set
    End Property

    Public Property TVShowNFOExpert() As String
        Get
            Return _tvshownfoexpert
        End Get
        Set(ByVal value As String)
            _tvshownfoexpert = value
        End Set
    End Property

    Public Property TVShowNFOBoxee() As Boolean
        Get
            Return _tvshownfoboxee
        End Get
        Set(ByVal value As Boolean)
            _tvshownfoboxee = value
        End Set
    End Property

    Public Property TVShowPosterBoxee() As Boolean
        Get
            Return _tvshowposterboxee
        End Get
        Set(ByVal value As Boolean)
            _tvshowposterboxee = value
        End Set
    End Property

    Public Property TVShowPosterExpert() As String
        Get
            Return _tvshowposterexpert
        End Get
        Set(ByVal value As String)
            _tvshowposterexpert = value
        End Set
    End Property

    Public Property TVShowNFOFrodo() As Boolean
        Get
            Return _tvshownfofrodo
        End Get
        Set(ByVal value As Boolean)
            _tvshownfofrodo = value
        End Set
    End Property

    Public Property TVShowPosterFrodo() As Boolean
        Get
            Return _tvshowposterfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvshowposterfrodo = value
        End Set
    End Property

    Public Property TVShowNFOYAMJ() As Boolean
        Get
            Return _tvshownfoyamj
        End Get
        Set(ByVal value As Boolean)
            _tvshownfoyamj = value
        End Set
    End Property

    Public Property TVShowPosterYAMJ() As Boolean
        Get
            Return _tvshowposteryamj
        End Get
        Set(ByVal value As Boolean)
            _tvshowposteryamj = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerExpert() As String
        Get
            Return _tvallseasonsbannerexpert
        End Get
        Set(ByVal value As String)
            _tvallseasonsbannerexpert = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartExpert() As String
        Get
            Return _tvallseasonsfanartexpert
        End Get
        Set(ByVal value As String)
            _tvallseasonsfanartexpert = value
        End Set
    End Property

    Public Property TVAllSeasonsLandscapeExpert() As String
        Get
            Return _tvallseasonslandscapeexpert
        End Get
        Set(ByVal value As String)
            _tvallseasonslandscapeexpert = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterExpert() As String
        Get
            Return _tvallseasonsposterexpert
        End Get
        Set(ByVal value As String)
            _tvallseasonsposterexpert = value
        End Set
    End Property

    Public Property TVSeasonBannerExpert() As String
        Get
            Return _tvseasonbannerexpert
        End Get
        Set(ByVal value As String)
            _tvseasonbannerexpert = value
        End Set
    End Property

    Public Property TVSeasonBannerFrodo() As Boolean
        Get
            Return _tvseasonbannerfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvseasonbannerfrodo = value
        End Set
    End Property

    Public Property TVSeasonBannerYAMJ() As Boolean
        Get
            Return _tvseasonbanneryamj
        End Get
        Set(ByVal value As Boolean)
            _tvseasonbanneryamj = value
        End Set
    End Property

    Public Property TVSeasonFanartExpert() As String
        Get
            Return _tvseasonfanartexpert
        End Get
        Set(ByVal value As String)
            _tvseasonfanartexpert = value
        End Set
    End Property

    Public Property TVSeasonFanartFrodo() As Boolean
        Get
            Return _tvseasonfanartfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvseasonfanartfrodo = value
        End Set
    End Property

    Public Property TVSeasonFanartYAMJ() As Boolean
        Get
            Return _tvseasonfanartyamj
        End Get
        Set(ByVal value As Boolean)
            _tvseasonfanartyamj = value
        End Set
    End Property

    Public Property TVSeasonLandscapeExpert() As String
        Get
            Return _tvseasonlandscapeexpert
        End Get
        Set(ByVal value As String)
            _tvseasonlandscapeexpert = value
        End Set
    End Property

    Public Property TVSeasonPosterBoxee() As Boolean
        Get
            Return _tvseasonposterboxee
        End Get
        Set(ByVal value As Boolean)
            _tvseasonposterboxee = value
        End Set
    End Property

    Public Property TVSeasonPosterExpert() As String
        Get
            Return _tvseasonposterexpert
        End Get
        Set(ByVal value As String)
            _tvseasonposterexpert = value
        End Set
    End Property

    Public Property TVSeasonPosterFrodo() As Boolean
        Get
            Return _tvseasonposterfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvseasonposterfrodo = value
        End Set
    End Property

    Public Property TVSeasonPosterYAMJ() As Boolean
        Get
            Return _tvseasonposteryamj
        End Get
        Set(ByVal value As Boolean)
            _tvseasonposteryamj = value
        End Set
    End Property

    Public Property TVEpisodeActorThumbsExpert() As Boolean
        Get
            Return _tvepisodeactorthumbsexpert
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeactorthumbsexpert = value
        End Set
    End Property

    Public Property TVEpisodeActorThumbsExtExpert() As String
        Get
            Return _tvepisodeactorthumbsextexpert
        End Get
        Set(ByVal value As String)
            _tvepisodeactorthumbsextexpert = value
        End Set
    End Property

    Public Property TVEpisodeActorThumbsFrodo() As Boolean
        Get
            Return _tvepisodeactorthumbsfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeactorthumbsfrodo = value
        End Set
    End Property

    Public Property TVEpisodeFanartExpert() As String
        Get
            Return _tvepisodefanartexpert
        End Get
        Set(ByVal value As String)
            _tvepisodefanartexpert = value
        End Set
    End Property

    Public Property TVEpisodeNFOExpert() As String
        Get
            Return _tvepisodenfoexpert
        End Get
        Set(ByVal value As String)
            _tvepisodenfoexpert = value
        End Set
    End Property

    Public Property TVEpisodeNFOBoxee() As Boolean
        Get
            Return _tvepisodenfoboxee
        End Get
        Set(ByVal value As Boolean)
            _tvepisodenfoboxee = value
        End Set
    End Property

    Public Property TVEpisodePosterBoxee() As Boolean
        Get
            Return _tvepisodeposterboxee
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeposterboxee = value
        End Set
    End Property

    Public Property TVEpisodePosterExpert() As String
        Get
            Return _tvepisodeposterexpert
        End Get
        Set(ByVal value As String)
            _tvepisodeposterexpert = value
        End Set
    End Property

    Public Property TVEpisodeNFOFrodo() As Boolean
        Get
            Return _tvepisodenfofrodo
        End Get
        Set(ByVal value As Boolean)
            _tvepisodenfofrodo = value
        End Set
    End Property

    Public Property TVEpisodePosterFrodo() As Boolean
        Get
            Return _tvepisodeposterfrodo
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeposterfrodo = value
        End Set
    End Property

    Public Property TVEpisodeNFOYAMJ() As Boolean
        Get
            Return _tvepisodenfoyamj
        End Get
        Set(ByVal value As Boolean)
            _tvepisodenfoyamj = value
        End Set
    End Property

    Public Property TVEpisodePosterYAMJ() As Boolean
        Get
            Return _tvepisodeposteryamj
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeposteryamj = value
        End Set
    End Property

    Public Property TVShowClearLogoAD() As Boolean
        Get
            Return _tvshowclearlogoad
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearlogoad = value
        End Set
    End Property

    Public Property TVShowClearLogoExtended() As Boolean
        Get
            Return _tvshowclearlogoextended
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearlogoextended = value
        End Set
    End Property

    Public Property TVShowClearArtAD() As Boolean
        Get
            Return _tvshowclearartad
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearartad = value
        End Set
    End Property

    Public Property TVShowClearArtExtended() As Boolean
        Get
            Return _tvshowclearartextended
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearartextended = value
        End Set
    End Property

    Public Property TVShowCharacterArtAD() As Boolean
        Get
            Return _tvshowcharacterartad
        End Get
        Set(ByVal value As Boolean)
            _tvshowcharacterartad = value
        End Set
    End Property

    Public Property TVShowCharacterArtExtended() As Boolean
        Get
            Return _tvshowcharacterartextended
        End Get
        Set(ByVal value As Boolean)
            _tvshowcharacterartextended = value
        End Set
    End Property

    Public Property TVShowLandscapeAD() As Boolean
        Get
            Return _tvshowlandscapead
        End Get
        Set(ByVal value As Boolean)
            _tvshowlandscapead = value
        End Set
    End Property

    Public Property TVShowLandscapeExtended() As Boolean
        Get
            Return _tvshowlandscapeextended
        End Get
        Set(ByVal value As Boolean)
            _tvshowlandscapeextended = value
        End Set
    End Property

    Public Property TVSeasonLandscapeAD() As Boolean
        Get
            Return _tvseasonlandscapead
        End Get
        Set(ByVal value As Boolean)
            _tvseasonlandscapead = value
        End Set
    End Property

    Public Property TVSeasonLandscapeExtended() As Boolean
        Get
            Return _tvseasonlandscapeextended
        End Get
        Set(ByVal value As Boolean)
            _tvseasonlandscapeextended = value
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
        'Cocotus, Load from central "Settings" folder if it exists!
        Dim configpath As String = Path.Combine(Master.SettingsPath, "Settings.xml")

        Try
            If File.Exists(configpath) Then
                Dim objStreamReader As New StreamReader(configpath)
                Dim xXMLSettings As New XmlSerializer([GetType])

                Master.eSettings = CType(xXMLSettings.Deserialize(objStreamReader), Settings)
                objStreamReader.Close()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
            logger.Info("An attempt is made to repair the Settings.xml")
            Try
                Using srSettings As New StreamReader(configpath)
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
                File.Copy(configpath, String.Concat(configpath, "_backup"), True)
                Master.eSettings = New Settings
            End Try
        End Try

        SetDefaultsForLists(Enums.DefaultSettingType.All, False)
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
        TV = New TV

        Addons = New List(Of AddonsManager._XMLAddonClass)
        GeneralCheckUpdates = False
        GeneralDaemonDrive = String.Empty
        GeneralDaemonPath = String.Empty
        GeneralDateAddedIgnoreNFO = False
        GeneralDateTime = Enums.DateTime.Now
        GeneralDigitGrpSymbolVotes = False
        GeneralImageFilter = False
        GeneralImageFilterAutoscraper = False
        GeneralImageFilterFanart = False
        GeneralImageFilterFanartMatchTolerance = 4
        GeneralImageFilterImagedialog = False
        GeneralImageFilterPoster = False
        GeneralImageFilterPosterMatchTolerance = 1
        GeneralLanguage = "English_(en_US)"
        GeneralOverwriteNfo = False
        GeneralSourceFromFolder = False
        MovieCleanDB = False
        MovieDataScraperSettings = New List(Of ScraperSettings)
        MovieFilterCustom = New List(Of String)
        MovieFilterCustomIsEmpty = False
        MovieGeneralFlagLang = String.Empty
        MovieGeneralIgnoreLastScan = True
        MovieGeneralLanguage = "en-US"
        MovieGeneralMarkNew = False
        MovieLevTolerance = 0
        MovieMetadataPerFileType = New List(Of MetadataPerType)
        MovieProperCase = True
        MovieScanOrderModify = False
        MovieScraperUseDetailView = False
        MovieSetCleanDB = False
        MovieSetCleanFiles = False
        MovieSetClickScrape = False
        MovieSetClickScrapeAsk = False
        MovieSetGeneralMarkNew = False
        MovieSkipLessThan = 0
        MovieSkipStackedSizeCheck = False
        MovieSortBeforeScan = False
        MovieSortTokens = New List(Of String)
        MovieSetSortTokens = New List(Of String)
        MovieSortTokensIsEmpty = False
        MovieSetSortTokensIsEmpty = False
        OMMDummyFormat = 0
        OMMDummyTagline = String.Empty
        OMMDummyTop = String.Empty
        OMMDummyUseBackground = True
        OMMDummyUseFanart = True
        OMMDummyUseOverlay = True
        OMMMediaStubTagline = String.Empty
        SortPath = String.Empty
        TVCleanDB = False
        TVDisplayMissingEpisodes = True
        TVEpisodeActorThumbsExtExpert = ".jpg"
        TVEpisodeFilterCustom = New List(Of String)
        TVEpisodeFilterCustomIsEmpty = False
        TVEpisodeNoFilter = True
        TVEpisodeProperCase = True
        TVGeneralClickScrape = False
        TVGeneralClickScrapeask = False
        TVGeneralFlagLang = String.Empty
        TVGeneralIgnoreLastScan = True
        TVGeneralLanguage = "en-US"
        TVGeneralMarkNewEpisodes = False
        TVGeneralMarkNewShows = False
        TVImagesCacheEnabled = True
        TVImagesDisplayImageSelect = True
        TVMetadataPerFileType = New List(Of MetadataPerType)
        TVMultiPartMatching = "^[-_ex]+([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)"
        TVScanOrderModify = False
        TVScraperEpisodeCastWithImgOnly = False
        TVScraperEpisodeGuestStarsToActors = False
        TVScraperOptionsOrdering = Enums.EpisodeOrdering.Standard
        TVScraperUseDisplaySeasonEpisode = True
        TVScraperUseSRuntimeForEp = True
        TVShowActorThumbsExtExpert = ".jpg"
        TVShowFilterCustom = New List(Of String)
        TVShowFilterCustomIsEmpty = False
        TVShowMatching = New List(Of regexp)
        TVShowProperCase = True
        TVSkipLessThan = 0
        TVSortTokens = New List(Of String)
        TVSortTokensIsEmpty = False
        Version = String.Empty
    End Sub

    Public Sub SetDefaultsForLists(ByVal Type As Enums.DefaultSettingType, ByVal Force As Boolean)
        'MovieFilters
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MovieFilters) AndAlso (Force OrElse (Master.eSettings.MovieFilterCustom.Count <= 0 AndAlso Not Master.eSettings.MovieFilterCustomIsEmpty)) Then
            Master.eSettings.MovieFilterCustom.Clear()
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]\(?\d{4}\)?.*")    'year in brakets
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]tt\d*")            'IMDB ID
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]blu[\W_]?ray.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]bd[\W_]?rip.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]3d.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]dvd.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]720.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]1080.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]1440.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]2160.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]4k.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]ac3.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]dts.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]divx.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]xvid.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]dc[\W_]?.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]extended.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]hd(tv)?.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]unrated.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]uncut.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]german.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]\[offline\].*")
            Master.eSettings.MovieFilterCustom.Add("(?i)[\W_]ntsc.*")
            Master.eSettings.MovieFilterCustom.Add("[\W_]PAL[\W_]?.*")
            Master.eSettings.MovieFilterCustom.Add("\.[->] ")                   'convert dots to space
            Master.eSettings.MovieFilterCustom.Add("_[->] ")                    'convert underscore to space
        End If

        'TVShowFilters
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ShowFilters) AndAlso (Force OrElse (Master.eSettings.TVShowFilterCustom.Count <= 0 AndAlso Not Master.eSettings.TVShowFilterCustomIsEmpty)) Then
            Master.eSettings.TVShowFilterCustom.Clear()
            Master.eSettings.TVShowFilterCustom.Add("[\W_]\(?\d{4}\)?.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]blu[\W_]?ray.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]bd[\W_]?rip.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]dvd.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]720.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]1080.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]1440.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]2160.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]4k.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]ac3.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]dts.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]divx.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]xvid.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]dc[\W_]?.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]extended.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]hd(tv)?.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]unrated.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]uncut.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]\[offline\].*")
            Master.eSettings.TVShowFilterCustom.Add("(?i)[\W_]ntsc.*")
            Master.eSettings.TVShowFilterCustom.Add("[\W_]PAL[\W_]?.*")
            Master.eSettings.TVShowFilterCustom.Add("\.[->] ")                  'convert dots to space
            Master.eSettings.TVShowFilterCustom.Add("_[->] ")                   'convert underscore to space
        End If

        'TVEpisodeFilters
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.EpFilters) AndAlso (Force OrElse (Master.eSettings.TVEpisodeFilterCustom.Count <= 0 AndAlso Not Master.eSettings.TVEpisodeFilterCustomIsEmpty)) Then
            Master.eSettings.TVEpisodeFilterCustom.Clear()
            Master.eSettings.TVEpisodeFilterCustom.Add("[\W_]\(?\d{4}\)?.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)([\W_]+\s?)?s[0-9]+[\W_]*([-e][0-9]+)+(\])*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)([\W_]+\s?)?[0-9]+([-x][0-9]+)+(\])*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)([\W_]+\s?)?s(eason)?[\W_]*[0-9]+(\])*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)([\W_]+\s?)?e(pisode)?[\W_]*[0-9]+(\])*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]blu[\W_]?ray.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]bd[\W_]?rip.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]dvd.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]720.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]1080.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]1440.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]2160.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]4k.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]ac3.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]dts.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]divx.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]xvid.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]dc[\W_]?.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]dir(ector'?s?)?\s?cut.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]extended.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]hd(tv)?.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]unrated.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]uncut.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]([a-z]{3}|multi)[sd]ub.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]\[offline\].*")
            Master.eSettings.TVEpisodeFilterCustom.Add("(?i)[\W_]ntsc.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("[\W_]PAL[\W_]?.*")
            Master.eSettings.TVEpisodeFilterCustom.Add("\.[->] ")               'convert dots to space
            Master.eSettings.TVEpisodeFilterCustom.Add("_[->] ")                'convert underscore to space
            Master.eSettings.TVEpisodeFilterCustom.Add(" - [->] ")              'convert space-minus-space to space
        End If

        'MovieSortTokens
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MovieSortTokens) AndAlso (Force OrElse (Master.eSettings.MovieSortTokens.Count <= 0 AndAlso Not Master.eSettings.MovieSortTokensIsEmpty)) Then
            Master.eSettings.MovieSortTokens.Clear()
            Master.eSettings.MovieSortTokens.Add("the[\W_]")
            Master.eSettings.MovieSortTokens.Add("a[\W_]")
            Master.eSettings.MovieSortTokens.Add("an[\W_]")
            Master.eSettings.MovieSortTokens.Add("der[\W_]")
            Master.eSettings.MovieSortTokens.Add("die[\W_]")
            Master.eSettings.MovieSortTokens.Add("das[\W_]")
        End If

        'MovieSetSortTokens
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MoviesetSortTokens) AndAlso (Force OrElse (Master.eSettings.MovieSetSortTokens.Count <= 0 AndAlso Not Master.eSettings.MovieSetSortTokensIsEmpty)) Then
            Master.eSettings.MovieSetSortTokens.Clear()
            Master.eSettings.MovieSetSortTokens.Add("the[\W_]")
            Master.eSettings.MovieSetSortTokens.Add("a[\W_]")
            Master.eSettings.MovieSetSortTokens.Add("an[\W_]")
            Master.eSettings.MovieSetSortTokens.Add("der[\W_]")
            Master.eSettings.MovieSetSortTokens.Add("die[\W_]")
            Master.eSettings.MovieSetSortTokens.Add("das[\W_]")
        End If

        'TVSortTokens
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVSortTokens) AndAlso (Force OrElse (Master.eSettings.TVSortTokens.Count <= 0 AndAlso Not Master.eSettings.TVSortTokensIsEmpty)) Then
            Master.eSettings.TVSortTokens.Clear()
            Master.eSettings.TVSortTokens.Add("the[\W_]")
            Master.eSettings.TVSortTokens.Add("a[\W_]")
            Master.eSettings.TVSortTokens.Add("an[\W_]")
            Master.eSettings.TVSortTokens.Add("der[\W_]")
            Master.eSettings.TVSortTokens.Add("die[\W_]")
            Master.eSettings.TVSortTokens.Add("das[\W_]")
        End If

        'ValidSubtitleExts / ValidThemeExts / ValidVideoExts
        Master.eSettings.Options.Filesystem.SetDefaults(Type, Force)

        'TVShowMatching
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVShowMatching) AndAlso (Force OrElse Master.eSettings.TVShowMatching.Count <= 0) Then
            Master.eSettings.TVShowMatching.Clear()
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 0, .byDate = False, .defaultSeason = -1, .Regexp = "s([0-9]+)[ ._-]*e([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)([^\\\/]*)$"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 1, .byDate = False, .defaultSeason = 1, .Regexp = "[\\._ -]()e(?:p[ ._-]?)?([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)([^\\\/]*)$"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 2, .byDate = True, .defaultSeason = -1, .Regexp = "([0-9]{4})[.-]([0-9]{2})[.-]([0-9]{2})"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 3, .byDate = True, .defaultSeason = -1, .Regexp = "([0-9]{2})[.-]([0-9]{2})[.-]([0-9]{4})"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 4, .byDate = False, .defaultSeason = -1, .Regexp = "[\\\/._ \[\(-]([0-9]+)x([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)([^\\\/]*)$"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 5, .byDate = False, .defaultSeason = -1, .Regexp = "[\\\/._ -]([0-9]+)([0-9][0-9](?:(?:[a-i]|\.[1-9])(?![0-9]))?)([._ -][^\\\/]*)$"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 6, .byDate = False, .defaultSeason = 1, .Regexp = "[\\\/._ -]p(?:ar)?t[_. -]()([ivx]+|[0-9]+)([._ -][^\\\/]*)$"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 7, .byDate = False, .defaultSeason = -1, .Regexp = "[Ss]([0-9]+)[ ._-]*[Ee]([0-9]+)([^\\/]*)(?:(?:[\\/]VIDEO_TS)?[\\/]VIDEO_TS\.IFO)$"})
            Master.eSettings.TVShowMatching.Add(New regexp With {.ID = 8, .byDate = False, .defaultSeason = -1, .Regexp = "[Ss]([0-9]+)[ ._-]*[Ee]([0-9]+)([^\\/]*)(?:(?:[\\/]bdmv)?[\\/]index\.bdmv)$"})
        End If

        'MovieListSorting
        'If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MovieListSorting) AndAlso (Force OrElse Master.eSettings.MovieGeneralMediaListSorting.Count <= 0) Then
        'TODO: 
        'Master.eSettings.MovieGeneralMediaListSorting.Clear()
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = True, .Column = "OriginalTitle", .LabelID = 302, .LabelText = "Original Title"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = True, .Column = "Year", .LabelID = 278, .LabelText = "Year"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = True, .Column = "MPAA", .LabelID = 401, .LabelText = "MPAA"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = True, .Column = "Rating", .LabelID = 400, .LabelText = "Rating"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = True, .Column = "Top250", .LabelID = -1, .LabelText = "Top250"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = True, .Column = "IMDB", .LabelID = 61, .LabelText = "IMDB ID"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 7, .Hide = True, .Column = "TMDB", .LabelID = 933, .LabelText = "TMDB ID"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 8, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 9, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 10, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 11, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 12, .Hide = False, .Column = "DiscArtPath", .LabelID = 1098, .LabelText = "DiscArt"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 13, .Hide = False, .Column = "EFanartsPath", .LabelID = 992, .LabelText = "Extrafanarts"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 14, .Hide = False, .Column = "EThumbsPath", .LabelID = 153, .LabelText = "Extrathumbs"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 15, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 16, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 17, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 18, .Hide = False, .Column = "HasSub", .LabelID = 152, .LabelText = "Subtitles"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 19, .Hide = False, .Column = "ThemePath", .LabelID = 1118, .LabelText = "Theme"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 20, .Hide = False, .Column = "TrailerPath", .LabelID = 151, .LabelText = "Trailer"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 21, .Hide = False, .Column = "HasSet", .LabelID = 1295, .LabelText = "Part of a MovieSet"})
        'Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 22, .Hide = False, .Column = "LastPlayed", .LabelID = 981, .LabelText = "Watched"})
        ' End If

        'MovieSetListSorting
        'If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MoviesetListSorting) AndAlso (Force OrElse Master.eSettings.MovieSetGeneralMediaListSorting.Count <= 0) Then
        'TODO:
        'Master.eSettings.MovieSetGeneralMediaListSorting.Clear()
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "DiscArtPath", .LabelID = 1098, .LabelText = "DiscArt"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 7, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
        'Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 8, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
        'End If

        'TVEpisodeListSorting
        'If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVEpisodeListSorting) AndAlso (Force OrElse Master.eSettings.TVGeneralEpisodeListSorting.Count <= 0) Then
        'TODO:
        'Master.eSettings.TVGeneralEpisodeListSorting.Clear()
        'Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "Title", .LabelID = 21, .LabelText = "Title"})
        'Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
        'Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = True, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
        'Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
        'Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "HasSub", .LabelID = 152, .LabelText = "Subtitles"})
        'Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "Playcount", .LabelID = 981, .LabelText = "Watched"})
        ' End If

        'TVSeasonListSorting
        ' If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVSeasonListSorting) AndAlso (Force OrElse Master.eSettings.TVGeneralSeasonListSorting.Count <= 0) Then
        'TODO:
        'Master.eSettings.TVGeneralSeasonListSorting.Clear()
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "SeasonText", .LabelID = 650, .LabelText = "Season"})
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = True, .Column = "Episodes", .LabelID = 682, .LabelText = "Episodes"})
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
        'Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = False, .Column = "HasWatched", .LabelID = 981, .LabelText = "Watched"})
        ' End If

        'TVShowListSorting
        ' If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVShowListSorting) AndAlso (Force OrElse Master.eSettings.TVGeneralShowListSorting.Count <= 0) Then
        'TODO:
        'Master.eSettings.TVGeneralShowListSorting.Clear()
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = True, .Column = "OriginalTitle", .LabelID = 302, .LabelText = "Original Title"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = True, .Column = "Status", .LabelID = 215, .LabelText = "Status"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = True, .Column = "Episodes", .LabelID = 682, .LabelText = "Episodes"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = False, .Column = "CharacterArtPath", .LabelID = 1140, .LabelText = "CharacterArt"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 7, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 8, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 9, .Hide = False, .Column = "EFanartsPath", .LabelID = 992, .LabelText = "Extrafanarts"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 10, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 11, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 12, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 13, .Hide = False, .Column = "ThemePath", .LabelID = 1118, .LabelText = "Theme"})
        'Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 14, .Hide = False, .Column = "HasWatched", .LabelID = 981, .LabelText = "Watched"})
        'End If
    End Sub

    Public Function GetMovieSetsArtworkPaths() As List(Of String)
        Dim Paths As New List(Of String)
        If Not String.IsNullOrEmpty(MovieSetPathExpertSingle) Then Paths.Add(MovieSetPathExpertSingle)
        If Not String.IsNullOrEmpty(MovieSetPathExtended) Then Paths.Add(MovieSetPathExtended)
        If Not String.IsNullOrEmpty(MovieSetPathMSAA) Then Paths.Add(MovieSetPathMSAA)
        Paths = Paths.Distinct().ToList() 'remove double entries
        Return Paths
    End Function

    Public Function FilenameAnyEnabled(ByVal tContentType As Enums.ContentType, ByVal tImageType As Enums.ScrapeModifierType) As Boolean
        Dim bResult As Boolean
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
                Select Case tImageType
                    Case Enums.ScrapeModifierType.MainBanner
                        Return FilenameAnyEnabled_MovieSet_Banner()
                    Case Enums.ScrapeModifierType.MainClearArt
                        Return FilenameAnyEnabled_MovieSet_ClearArt()
                    Case Enums.ScrapeModifierType.MainClearLogo
                        Return FilenameAnyEnabled_MovieSet_ClearLogo()
                    Case Enums.ScrapeModifierType.MainDiscArt
                        Return FilenameAnyEnabled_MovieSet_DiscArt()
                    Case Enums.ScrapeModifierType.MainFanart
                        Return FilenameAnyEnabled_MovieSet_Fanart()
                    Case Enums.ScrapeModifierType.MainLandscape
                        Return FilenameAnyEnabled_MovieSet_Landscape()
                    Case Enums.ScrapeModifierType.MainNFO
                        Return FilenameAnyEnabled_MovieSet_NFO()
                    Case Enums.ScrapeModifierType.MainPoster
                        Return FilenameAnyEnabled_MovieSet_Poster()
                End Select
            Case Enums.ContentType.TVEpisode
                Select Case tImageType
                    Case Enums.ScrapeModifierType.EpisodeActorThumbs
                        Return FilenameAnyEnabled_TVEpisode_ActorThumbs()
                    Case Enums.ScrapeModifierType.EpisodeFanart
                        Return FilenameAnyEnabled_TVEpisode_Fanart()
                    Case Enums.ScrapeModifierType.EpisodeNFO
                        Return FilenameAnyEnabled_TVEpisode_NFO()
                    Case Enums.ScrapeModifierType.EpisodePoster
                        Return FilenameAnyEnabled_TVEpisode_Poster()
                End Select
            Case Enums.ContentType.TVSeason
                Select Case tImageType
                    Case Enums.ScrapeModifierType.AllSeasonsBanner
                        Return FilenameAnyEnabled_TVAllSeasons_Banner()
                    Case Enums.ScrapeModifierType.AllSeasonsFanart
                        Return FilenameAnyEnabled_TVAllSeasons_Fanart()
                    Case Enums.ScrapeModifierType.AllSeasonsLandscape
                        Return FilenameAnyEnabled_TVAllSeasons_Landscape()
                    Case Enums.ScrapeModifierType.AllSeasonsPoster
                        Return FilenameAnyEnabled_TVAllSeasons_Poster()
                    Case Enums.ScrapeModifierType.SeasonBanner
                        Return FilenameAnyEnabled_TVSeason_Banner()
                    Case Enums.ScrapeModifierType.SeasonFanart
                        Return FilenameAnyEnabled_TVSeason_Fanart()
                    Case Enums.ScrapeModifierType.SeasonLandscape
                        Return FilenameAnyEnabled_TVSeason_Landscape()
                    Case Enums.ScrapeModifierType.SeasonPoster
                        Return FilenameAnyEnabled_TVSeason_Poster()
                End Select
            Case Enums.ContentType.TVShow
                Select Case tImageType
                    Case Enums.ScrapeModifierType.MainActorThumbs
                        Return FilenameAnyEnabled_TVShow_ActorTumbs()
                    Case Enums.ScrapeModifierType.MainBanner
                        Return FilenameAnyEnabled_TVShow_Banner()
                    Case Enums.ScrapeModifierType.MainCharacterArt
                        Return FilenameAnyEnabled_TVShow_CharacterArt()
                    Case Enums.ScrapeModifierType.MainClearArt
                        Return FilenameAnyEnabled_TVShow_ClearArt()
                    Case Enums.ScrapeModifierType.MainClearLogo
                        Return FilenameAnyEnabled_TVShow_ClearLogo()
                    Case Enums.ScrapeModifierType.MainExtrafanarts
                        Return FilenameAnyEnabled_TVShow_Extrafanarts()
                    Case Enums.ScrapeModifierType.MainFanart
                        Return FilenameAnyEnabled_TVShow_Fanart()
                    Case Enums.ScrapeModifierType.MainLandscape
                        Return FilenameAnyEnabled_TVShow_Landscape()
                    Case Enums.ScrapeModifierType.MainNFO
                        Return FilenameAnyEnabled_TVShow_NFO()
                    Case Enums.ScrapeModifierType.MainPoster
                        Return FilenameAnyEnabled_TVShow_Poster()
                    Case Enums.ScrapeModifierType.MainTheme
                        Return FilenameAnyEnabled_TVShow_Theme()
                End Select
        End Select
        Return bResult
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Banner() As Boolean
        Return _
            (MovieSetBannerExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetBannerMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetPosterExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_ClearArt() As Boolean
        Return _
            (MovieSetClearArtExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetClearArtMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetClearArtExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_ClearLogo() As Boolean
        Return _
            (MovieSetClearLogoExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetClearLogoMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetClearLogoExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_DiscArt() As Boolean
        Return _
            (MovieSetDiscArtExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetDiscArtExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Fanart() As Boolean
        Return _
            (MovieSetFanartExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetFanartMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetFanartExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Landscape() As Boolean
        Return _
            (MovieSetLandscapeExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetLandscapeMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetLandscapeExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_NFO() As Boolean
        Return _
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetNFOExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Poster() As Boolean
        Return _
            (MovieSetPosterExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetPosterMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetPosterExpertSingle)))
    End Function

    Public Function FilenameAnyEnabled_TVAllSeasons_Banner() As Boolean
        Return _
            TVSeasonBannerFrodo OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVAllSeasonsBannerExpert))
    End Function

    Public Function FilenameAnyEnabled_TVAllSeasons_Fanart() As Boolean
        Return _
            TVSeasonFanartFrodo OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVAllSeasonsFanartExpert))
    End Function

    Public Function FilenameAnyEnabled_TVAllSeasons_Landscape() As Boolean
        Return _
            TVSeasonLandscapeAD OrElse
            TVSeasonLandscapeExtended OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVAllSeasonsLandscapeExpert))
    End Function

    Public Function FilenameAnyEnabled_TVAllSeasons_Poster() As Boolean
        Return _
            TVSeasonPosterFrodo OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVAllSeasonsPosterExpert))
    End Function

    Public Function FilenameAnyEnabled_TVEpisode_ActorThumbs() As Boolean
        Return _
            TVEpisodeActorThumbsFrodo OrElse
            (TVUseExpert AndAlso TVEpisodeActorThumbsExpert AndAlso Not String.IsNullOrEmpty(TVEpisodeActorThumbsExtExpert))
    End Function

    Public Function FilenameAnyEnabled_TVEpisode_Fanart() As Boolean
        Return (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVEpisodeFanartExpert))
    End Function

    Public Function FilenameAnyEnabled_TVEpisode_NFO() As Boolean
        Return _
            TVEpisodeNFOBoxee OrElse
            TVEpisodeNFOFrodo OrElse
            TVEpisodeNFOYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVEpisodeNFOExpert))
    End Function

    Public Function FilenameAnyEnabled_TVEpisode_Poster() As Boolean
        Return _
            TVEpisodePosterBoxee OrElse
            TVEpisodePosterFrodo OrElse
            TVEpisodePosterYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVEpisodePosterExpert))
    End Function

    Public Function FilenameAnyEnabled_TVSeason_Banner() As Boolean
        Return _
            TVSeasonBannerFrodo OrElse
            TVSeasonBannerYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVSeasonBannerExpert))
    End Function

    Public Function FilenameAnyEnabled_TVSeason_Fanart() As Boolean
        Return _
            TVSeasonFanartFrodo OrElse
            TVSeasonFanartYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVSeasonFanartExpert))
    End Function

    Public Function FilenameAnyEnabled_TVSeason_Landscape() As Boolean
        Return _
            TVSeasonLandscapeAD OrElse
            TVSeasonLandscapeExtended OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVSeasonLandscapeExpert))
    End Function

    Public Function FilenameAnyEnabled_TVSeason_Poster() As Boolean
        Return _
            TVSeasonPosterBoxee OrElse
            TVSeasonPosterFrodo OrElse
            TVSeasonPosterYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVSeasonPosterExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_ActorTumbs() As Boolean
        Return _
            TVShowActorThumbsFrodo OrElse
            (TVUseExpert AndAlso TVShowActorThumbsExpert AndAlso Not String.IsNullOrEmpty(TVShowActorThumbsExtExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_Banner() As Boolean
        Return _
            TVShowBannerBoxee OrElse
            TVShowBannerFrodo OrElse
            TVShowBannerYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowBannerExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_CharacterArt() As Boolean
        Return _
            TVShowCharacterArtAD OrElse
            TVShowCharacterArtExtended OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowCharacterArtExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_ClearArt() As Boolean
        Return _
            TVShowClearArtAD OrElse
            TVShowClearArtExtended OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowClearArtExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_ClearLogo() As Boolean
        Return _
            TVShowClearLogoAD OrElse
            TVShowClearLogoExtended OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowClearLogoExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_Extrafanarts() As Boolean
        Return _
            TVShowExtrafanartsFrodo OrElse
            (TVUseExpert AndAlso TVShowExtrafanartsExpert)
    End Function

    Public Function FilenameAnyEnabled_TVShow_Fanart() As Boolean
        Return _
            TVShowFanartBoxee OrElse
            TVShowFanartFrodo OrElse
            TVShowFanartYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowFanartExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_Landscape() As Boolean
        Return _
            TVShowLandscapeAD OrElse
            TVShowLandscapeExtended OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowLandscapeExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_NFO() As Boolean
        Return _
            TVShowNFOBoxee OrElse
            TVShowNFOFrodo OrElse
            TVShowNFOYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowNFOExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_Poster() As Boolean
        Return _
            TVShowPosterBoxee OrElse
            TVShowPosterFrodo OrElse
            TVShowPosterYAMJ OrElse
            (TVUseExpert AndAlso Not String.IsNullOrEmpty(TVShowPosterExpert))
    End Function

    Public Function FilenameAnyEnabled_TVShow_Theme() As Boolean
        Return TVShowThemeTvTunesEnable AndAlso (TVShowThemeTvTunesShowPath OrElse (TVShowThemeTvTunesCustom AndAlso Not String.IsNullOrEmpty(TVShowThemeTvTunesCustomPath) OrElse (TVShowThemeTvTunesSub AndAlso Not String.IsNullOrEmpty(TVShowThemeTvTunesSubDir))))
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

    Public Class regexp

#Region "Fields"

        Private _bydate As Boolean
        Private _defaultSeason As Integer
        Private _id As Integer
        Private _regexp As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"

        Public Property byDate() As Boolean
            Get
                Return _bydate
            End Get
            Set(ByVal value As Boolean)
                _bydate = value
            End Set
        End Property

        Public Property defaultSeason() As Integer
            Get
                Return _defaultSeason
            End Get
            Set(ByVal value As Integer)
                _defaultSeason = value
            End Set
        End Property

        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Regexp() As String
            Get
                Return _regexp
            End Get
            Set(ByVal value As String)
                _regexp = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _bydate = False
            _defaultSeason = -1
            _id = -1
            _regexp = String.Empty
        End Sub

#End Region 'Methods

    End Class

    Public Class ScraperSettings

#Region "Fields"

        Private _name As String
        Private _scraperitems As New List(Of ScraperItem)
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

    Public Property DataSettings() As New DataSettings
    Public Property Filenaming As New FilenamingSettings_Movie
    Public Property ImageSettings() As New ImageSettings_Movie
    Public Property ThemeSettings() As New ThemeSettings
    Public Property TrailerSettings() As New TrailerSettings

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
        DataSettings = New DataSettings
        Filenaming = New FilenamingSettings_Movie
        ImageSettings = New ImageSettings_Movie
        ThemeSettings = New ThemeSettings
        TrailerSettings = New TrailerSettings
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class Movieset

#Region "Properties"

    Public Property DataSettings As DataSettings
    Public Property ImageSettings() As ImageSettings_Movieset

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
        DataSettings = New DataSettings
        ImageSettings = New ImageSettings_Movieset
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class DataSettings

#Region "Properties"

    Public Property Actors() As New DataSpecification
    Public Property ActorsWithImageOnly As Boolean
    Public Property Certifications() As New DataSpecification
    Public Property CertificationsForMPAA() As Boolean
    Public Property CertificationsForMPAAFallback() As Boolean
    Public Property CertificationsOnlyValue() As Boolean
    Public Property CleanPlotAndOutline As Boolean
    Public Property ClearDisabledFields() As Boolean
    Public Property Collection As New DataSpecification
    Public Property CollectionAutoAdd As Boolean
    Public Property CollectionID() As New DataSpecification
    Public Property CollectionKodiExtendedInfo As Boolean
    Public Property CollectionYAMJCompatible As Boolean
    Public Property Countries() As New DataSpecification
    Public Property Credits() As New DataSpecification
    Public Property Directors() As New DataSpecification
    Public Property DurationForRuntime As Boolean
    Public Property DurationFormat As String
    Public Property Genres() As New DataSpecification
    Public Property LockAudioLanguage As Boolean
    Public Property LockVideoLanguage As Boolean
    Public Property MetaDataScan As Boolean
    Public Property MPAA() As New DataSpecification
    Public Property MPAANotRatedValue As String
    <XmlIgnore()>
    Public ReadOnly Property MPAANotRatedValueSpecified() As Boolean
        Get
            Return Not String.IsNullOrEmpty(MPAANotRatedValue)
        End Get
    End Property
    Public Property OriginalTitle() As New DataSpecification
    Public Property Outline() As New DataSpecification
    Public Property Plot() As New DataSpecification
    Public Property PlotForOutline As Boolean
    Public Property PlotForOutlineAsFallback As Boolean
    Public Property Rating() As New DataSpecification
    Public Property ReleaseDate() As New DataSpecification
    Public Property Runtime() As New DataSpecification
    Public Property Studios() As New DataSpecification
    Public Property StudiosWithImageOnly As Boolean
    Public Property Tagline() As New DataSpecification
    Public Property Tags() As New DataSpecification
    Public Property Title() As New DataSpecification
    Public Property Top250() As New DataSpecification
    Public Property Trailer() As New DataSpecification
    Public Property TrailerKodiFormat As Boolean
    Public Property UserRating() As New DataSpecification
    Public Property Year() As New DataSpecification

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
        Actors = New DataSpecification
        Certifications = New DataSpecification
        CleanPlotAndOutline = False
        Collection = New DataSpecification
        CollectionAutoAdd = True
        CollectionKodiExtendedInfo = False
        CollectionYAMJCompatible = False
        CollectionID = New DataSpecification
        Countries = New DataSpecification
        Credits = New DataSpecification
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
Public Class DataSettings_TV

#Region "Properties"

    Public Property DurationFormat As String
    Public Property DurationForRuntime As Boolean
    Public Property MetaDataScan As Boolean
    Public Property TVEpisode() As New DataSettings_TVEpisode
    Public Property TVSeason() As New DataSettings_TVSeason
    Public Property TVShow() As New DataSettings_TVShow

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

    Public Property Actors() As New DataSpecification
    Public Property Aired() As New DataSpecification
    Public Property Credits() As New DataSpecification
    Public Property Directors() As New DataSpecification
    Public Property GuestStars() As New DataSpecification
    Public Property LockAudioLanguage As Boolean
    Public Property LockVideoLanguage As Boolean
    Public Property Plot() As New DataSpecification
    Public Property Rating() As New DataSpecification
    Public Property Runtime() As New DataSpecification
    Public Property Title() As New DataSpecification
    Public Property UserRating() As New DataSpecification

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
        Actors = New DataSpecification
        Aired = New DataSpecification
        Credits = New DataSpecification
        Directors = New DataSpecification
        GuestStars = New DataSpecification
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

    Public Property Aired() As New DataSpecification
    Public Property Plot() As New DataSpecification
    Public Property Title() As New DataSpecification

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

    Public Property Actors() As New DataSpecification
    Public Property ActorsWithImageOnly As Boolean
    Public Property Certifications() As New DataSpecification
    Public Property CertificationsForMPAA() As Boolean
    Public Property CertificationsForMPAAFallback() As Boolean
    Public Property CertificationsOnlyValue() As Boolean
    Public Property ClearDisabledFields() As Boolean
    Public Property Countries() As New DataSpecification
    Public Property Creators() As New DataSpecification
    Public Property EpisodeGuideURL() As New DataSpecification
    Public Property Genres() As New DataSpecification
    Public Property MPAA() As New DataSpecification
    Public Property MPAANotRatedValue As String
    <XmlIgnore()>
    Public ReadOnly Property MPAANotRatedValueSpecified() As Boolean
        Get
            Return Not String.IsNullOrEmpty(MPAANotRatedValue)
        End Get
    End Property
    Public Property OriginalTitle() As New DataSpecification
    Public Property Plot() As New DataSpecification
    Public Property Premiered() As New DataSpecification
    Public Property Rating() As New DataSpecification
    Public Property Runtime() As New DataSpecification
    Public Property Status As New DataSpecification
    Public Property Studios() As New DataSpecification
    Public Property StudiosWithImageOnly As Boolean
    Public Property Tags() As New DataSpecification
    Public Property Title() As New DataSpecification
    Public Property UserRating() As New DataSpecification

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
        Actors = New DataSpecification
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
    Public Property Limit() As Integer
    Public Property Locked() As Boolean

    <XmlIgnore()>
    Public ReadOnly Property FilterSpecified() As Boolean
        Get
            Return Not String.IsNullOrEmpty(Filter)
        End Get
    End Property

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
    Public Sub SetDefaults()
        Enabled = True
        Filter = String.Empty
        Limit = 0
        Locked = False
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class FilenamingSettings_Movie

#Region "Properties"

    Public Property ArtworkDownloader As New ArtworkDownloaderSpecifications
    Public Property BackdropsAuto As Boolean
    Public Property BackdropsPath As String
    Public Property Boxee As New BoxeeSpecifications
    Public Property Expert As New ExpertSpecifications
    Public Property Kodi As New KodiSpecifications
    Public Property KodiExtended As New KodiExtendedSpecifications
    Public Property NMJ As New NMJSpecifications
    Public Property TvTunes As New TvTunesSpecifications
    Public Property ProtectVTSandBDMVStructure As Boolean
    Public Property XBMC As New XBMCSpecifications
    Public Property YAMJ As New YAMJSpecifications

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

        Public Property Enabled As Boolean
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
            Enabled = False
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

        Public Property Enabled As Boolean
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
            Enabled = False
            Fanart = False
            NFO = False
            Poster = False
        End Sub

#End Region 'Methods

    End Class

    Public Class ExpertSpecifications

#Region "Properties"

        Public Property Enabled As Boolean
        Public Property BDMV As New BDMVSpecifications
        Public Property Multi As New MultiSpecifications
        Public Property [Single] As New SingleSpecifications
        Public Property VideoTS As New VideoTSSpecifications


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

        Public Property Enabled As Boolean
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
            Enabled = False
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
        Public Property Enabled As Boolean
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
            Enabled = False
            Landscape = False
        End Sub

#End Region 'Methods

    End Class

    Public Class NMJSpecifications

#Region "Properties"

        Public Property Enabled As Boolean
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
            Enabled = False
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
            Custom = False
            CustomPath = String.Empty
            Enabled = False
            MoviePath = False
            Subdirectory = False
            SubdirectoryPath = String.Empty
        End Sub

#End Region 'Methods

    End Class

    Public Class XBMCSpecifications

#Region "Properties"

        Public Property Enabled As Boolean
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
            Enabled = False
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

        Public Property Enabled As Boolean
        Public Property Banner As Boolean
        Public Property Fanart As Boolean
        Public Property NFO As Boolean
        Public Property Poster As Boolean
        Public Property Trailer As Boolean
        Public Property WatchedFile As Boolean
        Public Property WatchedFilePath As String


#End Region 'Properties

#Region "Constructors"

        Public Sub New()
            SetDefaults()
        End Sub

#End Region 'Constructors

#Region "Methods"

        Public Sub SetDefaults()
            Banner = False
            Enabled = False
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
Public Class FilesystemSettings

#Region "Properties"

    Public Property NoStackExts() As List(Of String)
    Public Property ValidSubtitleExts() As List(Of String)
    Public Property ValidThemeExts() As List(Of String)
    Public Property ValidVideoExts() As List(Of String)

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
        ValidSubtitleExts = New List(Of String)
        ValidThemeExts = New List(Of String)
        ValidVideoExts = New List(Of String)
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
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidExts) AndAlso (Force OrElse ValidVideoExts.Count = 0) Then
            ValidVideoExts.Clear()
            ValidVideoExts.AddRange(".avi,.divx,.mkv,.iso,.mpg,.mp4,.mpeg,.wmv,.wma,.mov,.mts,.m2t,.img,.dat,.bin,.cue,.ifo,.dvb,.evo,.asf,.asx,.avs,.nsv,.ram,.ogg,.ogm,.ogv,.flv,.swf,.nut,.viv,.rar,.m2ts,.dvr-ms,.ts,.m4v,.rmvb,.webm,.disc,.3gpp".Split(","c))
        End If
    End Sub

#End Region 'Methods

#Region "Nested Types"

#End Region

End Class


<Serializable()>
Public Class ImageSettings

#Region "Properties"

    Public Property ImagesCacheEnabled() As Boolean
    Public Property ImagesDisplayImageSelect() As Boolean
    Public Property ImagesNotSaveURLToNfo() As Boolean

    Public Property Language As New ImageSettings_Language

    Public Property ActorThumbsKeepExisting() As Boolean
    Public Property Banner() As New ImageSpecification_Resize
    Public Property ClearArt() As New ImageSpecification
    Public Property ClearLogo() As New ImageSpecification
    Public Property Extrafanarts() As New ImageSpecification_Extra
    Public Property ExtrafanartsLimit() As Integer
    Public Property ExtrafanartsPreselect() As Boolean
    Public Property ExtrathumbsCreatorUseETasFA() As Boolean
    Public Property ExtrathumbsPreselect() As Boolean
    Public Property Fanart() As New ImageSpecification_Resize
    Public Property Landscape() As New ImageSpecification_Resize
    Public Property Poster() As New ImageSpecification_Resize

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
        ImagesCacheEnabled = False
        ImagesDisplayImageSelect = True
        ImagesNotSaveURLToNfo = False

        Language = New ImageSettings_Language

        ActorThumbsKeepExisting = False
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        ExtrafanartsPreselect = True
        ExtrathumbsPreselect = True
        Fanart = New ImageSpecification_Resize
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_Language

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
Public Class ImageSettings_Movie
    Inherits ImageSettings

#Region "Properties"

    Public Property DiscArt() As New ImageSpecification
    Public Property Extrathumbs() As New ImageSpecification_Extra

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
        ImagesCacheEnabled = False
        ImagesDisplayImageSelect = True
        ImagesNotSaveURLToNfo = False
        Language = New ImageSettings_Language

        ActorThumbsKeepExisting = False
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        DiscArt = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        ExtrafanartsPreselect = True
        Extrathumbs = New ImageSpecification_Extra
        ExtrathumbsCreatorUseETasFA = False
        ExtrathumbsPreselect = True
        Fanart = New ImageSpecification_Resize
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_Movieset
    Inherits ImageSettings

#Region "Properties"

    Public Property DiscArt() As New ImageSpecification

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
        ImagesCacheEnabled = False
        ImagesDisplayImageSelect = True
        ImagesNotSaveURLToNfo = False
        Language = New ImageSettings_Language

        ActorThumbsKeepExisting = False
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        DiscArt = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        ExtrafanartsPreselect = True
        ExtrathumbsCreatorUseETasFA = False
        ExtrathumbsPreselect = True
        Fanart = New ImageSpecification_Resize
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_TV
    Inherits ImageSettings

#Region "Properties"

    Public Property TVAllSeasons() As New ImageSettings_TVSeason
    Public Property TVEpisode() As New ImageSettings_TVEpisode
    Public Property TVSeason() As New ImageSettings_TVSeason
    Public Property TVShow() As New ImageSettings_TVShow

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

        ImagesCacheEnabled = False
        ImagesDisplayImageSelect = True
        ImagesNotSaveURLToNfo = False

        Language = New ImageSettings_Language

        ActorThumbsKeepExisting = False
        Banner = New ImageSpecification_Resize
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        ExtrafanartsPreselect = True
        ExtrathumbsPreselect = True
        Fanart = New ImageSpecification_Resize
        Landscape = New ImageSpecification_Resize
        Poster = New ImageSpecification_Resize
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ImageSettings_TVEpisode

#Region "Properties"

    Public Property ActorThumbsKeepExisting() As Boolean
    Public Property Fanart() As New ImageSpecification_Resize
    Public Property Poster() As New ImageSpecification_Resize

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

    Public Property Banner() As New ImageSpecification_Resize
    Public Property Fanart() As New ImageSpecification_Resize
    Public Property Landscape() As New ImageSpecification_Resize
    Public Property Poster() As New ImageSpecification_Resize

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

    Public Property CharacterArt() As New ImageSpecification

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
        ActorThumbsKeepExisting = False
        Banner = New ImageSpecification_Resize
        CharacterArt = New ImageSpecification
        ClearArt = New ImageSpecification
        ClearLogo = New ImageSpecification
        Extrafanarts = New ImageSpecification_Extra
        ExtrafanartsLimit = 4
        ExtrafanartsPreselect = True
        ExtrathumbsPreselect = True
        Fanart = New ImageSpecification_Resize
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
    Inherits ImageSpecification

#Region "Properties"

    Public Property CreatorAuto() As Boolean
    Public Property CreatorNoBlackBars() As Boolean
    Public Property CreatorNoSpoilers() As Boolean
    Public Property Limit() As Integer
    Public Property MaxHeight() As Integer
    Public Property MaxWidth() As Integer

    <XmlIgnore()>
    Public ReadOnly Property LimitSpecified() As Boolean
        Get
            Return Limit > 0
        End Get
    End Property

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
        CreatorAuto = False
        CreatorNoBlackBars = True
        CreatorNoSpoilers = True
        Limit = 4
        MaxHeight = 0
        MaxWidth = 0
        KeepExisting = False
        PrefSize = Enums.ImageSize.Any
        PrefSizeOnly = False
    End Sub

#End Region 'Methods

End Class

<Serializable()>
Public Class ImageSpecification_Resize
    Inherits ImageSpecification

#Region "Properties"
    Public Property MaxHeight() As Integer
    Public Property MaxWidth() As Integer

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

    Public Property Filesystem As New FilesystemSettings
    Public Property Proxy As New ProxySettings

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
        Proxy = New ProxySettings
    End Sub

#End Region 'Methods

End Class


<Serializable()>
Public Class ProxySettings

#Region "Properties"

    Public Property Credentials() As New NetworkCredential
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

#Region "Nested Types"

#End Region

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
    Public Property ImageSettings() As ImageSettings_TV
    Public Property ThemeSettings() As New ThemeSettings

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
        ImageSettings = New ImageSettings_TV
        ThemeSettings = New ThemeSettings

        ImageSettings.TVShow.ImagesCacheEnabled = True
    End Sub

#End Region 'Methods

End Class