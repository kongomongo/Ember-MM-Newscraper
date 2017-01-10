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

    Private _cleandotfanartjpg As Boolean
    Private _cleanextrathumbs As Boolean
    Private _cleanfanartjpg As Boolean
    Private _cleanfolderjpg As Boolean
    Private _cleanmoviefanartjpg As Boolean
    Private _cleanmoviejpg As Boolean
    Private _cleanmovienamejpg As Boolean
    Private _cleanmovienfo As Boolean
    Private _cleanmovienfob As Boolean
    Private _cleanmovietbn As Boolean
    Private _cleanmovietbnb As Boolean
    Private _cleanposterjpg As Boolean
    Private _cleanpostertbn As Boolean
    Private _addond As List(Of AddonsManager._XMLAddonClass)
    Private _filesystemcleanerwhitelist As Boolean
    Private _filesystemcleanerwhitelistexts As List(Of String)
    Private _filesystemexpertcleaner As Boolean
    Private _filesystemnostackexts As List(Of String)
    Private _filesystemvalidexts As List(Of String)
    Private _filesystemvalidsubtitlesexts As List(Of String)
    Private _filesystemvalidthemeexts As List(Of String)
    Private _generalcheckupdates As Boolean
    Private _generaldaemondrive As String
    Private _generaldaemonpath As String
    Private _generaldateaddedignorenfo As Boolean
    Private _generaldatetime As Enums.DateTime
    Private _generaldigitgrpsymbolvotes As Boolean
    Private _generaldisplaybanner As Boolean
    Private _generaldisplaycharacterart As Boolean
    Private _generaldisplayclearart As Boolean
    Private _generaldisplayclearlogo As Boolean
    Private _generaldisplaydiscart As Boolean
    Private _generaldisplayfanart As Boolean
    Private _generaldisplayfanartsmall As Boolean
    Private _generaldisplaylandscape As Boolean
    Private _generaldisplayposter As Boolean
    Private _generaldoubleclickscrape As Boolean
    Private _generalfilterpanelisraisedmovie As Boolean
    Private _generalfilterpanelisraisedmovieset As Boolean
    Private _generalfilterpanelisraisedtvshow As Boolean
    Private _generalimagefilter As Boolean
    Private _generalimagefilterautoscraper As Boolean
    Private _generalimagefilterfanart As Boolean
    Private _generalimagefilterfanartmatchtolerance As Integer
    Private _generalimagefilterimagedialog As Boolean
    Private _generalimagefilterposter As Boolean
    Private _generalimagefilterpostermatchtolerance As Integer
    Private _generalimagesglassoverlay As Boolean
    Private _generalinfopanelstatemovie As Integer
    Private _generalinfopanelstatemovieset As Integer
    Private _generalinfopanelstatetvshow As Integer
    Private _generallanguage As String
    Private _generalmainfiltersortcolumn_movies As Integer
    Private _generalmainfiltersortcolumn_moviesets As Integer
    Private _generalmainfiltersortcolumn_shows As Integer
    Private _generalmainfiltersortorder_movies As Integer
    Private _generalmainfiltersortorder_moviesets As Integer
    Private _generalmainfiltersortorder_shows As Integer
    Private _generalmoviesettheme As String
    Private _generalmovietheme As String
    Private _generaloverwritenfo As Boolean
    Private _generalshowgenrestext As Boolean
    Private _generalshowimgdims As Boolean
    Private _generalshowimgnames As Boolean
    Private _generalshowlangflags As Boolean
    Private _generalsourcefromfolder As Boolean
    Private _generalsplitterdistancemain As Integer
    Private _generalsplitterdistancetvseason As Integer
    Private _generalsplitterdistancetvshow As Integer
    Private _generaltvepisodetheme As String
    Private _generaltvshowtheme As String
    Private _generalwindowloc As New Point
    Private _generalwindowsize As New Size
    Private _generalwindowstate As FormWindowState
    Private _movieactorthumbskeepexisting As Boolean
    Private _moviebackdropsauto As Boolean
    Private _moviebackdropspath As String
    Private _moviebannerheight As Integer
    Private _moviebannerkeepexisting As Boolean
    Private _moviebannerprefsize As Enums.MovieBannerSize
    Private _moviebannerprefsizeonly As Boolean
    Private _moviebannerresize As Boolean
    Private _moviebannerwidth As Integer
    Private _moviecleandb As Boolean
    Private _movieclearartkeepexisting As Boolean
    Private _movieclearartprefsize As Enums.MovieClearArtSize
    Private _movieclearartprefsizeonly As Boolean
    Private _movieclearlogokeepexisting As Boolean
    Private _movieclearlogoprefsize As Enums.MovieClearLogoSize
    Private _movieclearlogoprefsizeonly As Boolean
    Private _movieclickscrape As Boolean
    Private _movieclickscrapeask As Boolean
    Private _moviediscartkeepexisting As Boolean
    Private _moviediscartprefsize As Enums.MovieDiscArtSize
    Private _moviediscartprefsizeonly As Boolean
    Private _moviedisplayyear As Boolean
    Private _movieextrafanartsheight As Integer
    Private _movieextrafanartskeepexisting As Boolean
    Private _movieextrafanartslimit As Integer
    Private _movieextrafanartsprefsize As Enums.MovieFanartSize
    Private _movieextrafanartsprefsizeonly As Boolean
    Private _movieextrafanartspreselect As Boolean
    Private _movieextrafanartsresize As Boolean
    Private _movieextrafanartswidth As Integer
    Private _movieextrathumbscreatorautothumbs As Boolean
    Private _movieextrathumbscreatornoblackbars As Boolean
    Private _movieextrathumbscreatornospoilers As Boolean
    Private _movieextrathumbscreatoruseetasfa As Boolean
    Private _movieextrathumbsheight As Integer
    Private _movieextrathumbskeepexisting As Boolean
    Private _movieextrathumbslimit As Integer
    Private _movieextrathumbsprefsize As Enums.MovieFanartSize
    Private _movieextrathumbsprefsizeonly As Boolean
    Private _movieextrathumbspreselect As Boolean
    Private _movieextrathumbsresize As Boolean
    Private _movieextrathumbswidth As Integer
    Private _moviefanartheight As Integer
    Private _moviefanartkeepexisting As Boolean
    Private _moviefanartprefsize As Enums.MovieFanartSize
    Private _moviefanartprefsizeonly As Boolean
    Private _moviefanartresize As Boolean
    Private _moviefanartwidth As Integer
    Private _moviefiltercustom As List(Of String)
    Private _moviefiltercustomisempty As Boolean
    Private _moviegeneralcustommarker1color As Integer
    Private _moviegeneralcustommarker1name As String
    Private _moviegeneralcustommarker2color As Integer
    Private _moviegeneralcustommarker2name As String
    Private _moviegeneralcustommarker3color As Integer
    Private _moviegeneralcustommarker3name As String
    Private _moviegeneralcustommarker4color As Integer
    Private _moviegeneralcustommarker4name As String
    Private _moviegeneralcustomscrapebuttonenabled As Boolean
    Private _moviegeneralcustomscrapebuttonmodifiertype As Enums.ScrapeModifierType
    Private _moviegeneralcustomscrapebuttonscrapetype As Enums.ScrapeType
    Private _moviegeneralflaglang As String
    Private _moviegeneralignorelastscan As Boolean
    Private _moviegenerallanguage As String
    Private _moviegeneralmarknew As Boolean
    Private _moviegeneralmedialistsorting As List(Of ListSorting)
    Private _movieimagescacheenabled As Boolean
    Private _movieimagesdisplayimageselect As Boolean
    Private _movieimagesforcedlanguage As String
    Private _movieimagesforcelanguage As Boolean
    Private _movieimagesgetblankimages As Boolean
    Private _movieimagesgetenglishimages As Boolean
    Private _movieimagesmedialanguageonly As Boolean
    Private _movieimagesnotsaveurltonfo As Boolean
    Private _movieimdburl As String
    Private _movielandscapekeepexisting As Boolean
    Private _movielandscapeprefsize As Enums.MovieLandscapeSize
    Private _movielandscapeprefsizeonly As Boolean
    Private _movielevtolerance As Integer
    Private _movielockactors As Boolean
    Private _movielockcert As Boolean
    Private _movielockcollectionid As Boolean
    Private _movielockcollections As Boolean
    Private _movielockcountry As Boolean
    Private _movielockcredits As Boolean
    Private _movielockdirector As Boolean
    Private _movielockgenre As Boolean
    Private _movielocklanguagea As Boolean
    Private _movielocklanguagev As Boolean
    Private _movielockmpaa As Boolean
    Private _movielockoriginaltitle As Boolean
    Private _movielockoutline As Boolean
    Private _movielockplot As Boolean
    Private _movielockrating As Boolean
    Private _movielockreleasedate As Boolean
    Private _movielockruntime As Boolean
    Private _movielockstudio As Boolean
    Private _movielocktagline As Boolean
    Private _movielocktags As Boolean
    Private _movielocktitle As Boolean
    Private _movielocktop250 As Boolean
    Private _movielocktrailer As Boolean
    Private _movielockuserrating As Boolean
    Private _movielockyear As Boolean
    Private _moviemetadataperfiletype As List(Of MetadataPerType)
    Private _moviemissingbanner As Boolean
    Private _moviemissingclearart As Boolean
    Private _moviemissingclearlogo As Boolean
    Private _moviemissingdiscart As Boolean
    Private _moviemissingextrafanarts As Boolean
    Private _moviemissingextrathumbs As Boolean
    Private _moviemissingfanart As Boolean
    Private _moviemissinglandscape As Boolean
    Private _moviemissingnfo As Boolean
    Private _moviemissingposter As Boolean
    Private _moviemissingsubtitles As Boolean
    Private _moviemissingtheme As Boolean
    Private _moviemissingtrailer As Boolean
    Private _movieposterheight As Integer
    Private _movieposterkeepexisting As Boolean
    Private _movieposterprefsize As Enums.MoviePosterSize
    Private _movieposterprefsizeonly As Boolean
    Private _movieposterresize As Boolean
    Private _movieposterwidth As Integer
    Private _moviepropercase As Boolean
    Private _moviescanordermodify As Boolean
    Private _moviescrapercast As Boolean
    Private _moviescrapercastlimit As Integer
    Private _moviescrapercastwithimgonly As Boolean
    Private _moviescrapercert As Boolean
    Private _moviescrapercertformpaa As Boolean
    Private _moviescrapercertformpaafallback As Boolean
    Private _moviescrapercertfsk As Boolean
    Private _moviescrapercertlang As String
    Private _moviescrapercertonlyvalue As Boolean
    Private _moviescrapercleanfields As Boolean
    Private _moviescrapercleanplotoutline As Boolean
    Private _moviescrapercollectionid As Boolean
    Private _moviescrapercollectionsauto As Boolean
    Private _moviescrapercollectionsextendedinfo As Boolean
    Private _moviescrapercollectionsyamjcompatiblesets As Boolean
    Private _moviescrapercountry As Boolean
    Private _moviescrapercredits As Boolean
    Private _moviescraperdirector As Boolean
    Private _moviescraperdurationruntimeformat As String
    Private _moviescrapergenre As Boolean
    Private _moviescrapergenrelimit As Integer
    Private _moviescrapermetadataifoscan As Boolean
    Private _moviescrapermetadatascan As Boolean
    Private _moviescrapermpaa As Boolean
    Private _moviescrapermpaanotrated As String
    Private _moviescraperoriginaltitle As Boolean
    Private _moviescraperoutline As Boolean
    Private _moviescraperoutlinelimit As Integer
    Private _moviescraperplot As Boolean
    Private _moviescraperplotforoutline As Boolean
    Private _moviescraperplotforoutlineifempty As Boolean
    Private _moviescraperrating As Boolean
    Private _moviescraperrelease As Boolean
    Private _moviescraperruntime As Boolean
    Private _moviescraperstudio As Boolean
    Private _moviescraperstudiolimit As Integer
    Private _moviescraperstudiowithimgonly As Boolean
    Private _moviescrapertagline As Boolean
    Private _moviescrapertitle As Boolean
    Private _moviescrapertop250 As Boolean
    Private _moviescrapertrailer As Boolean
    Private _moviescraperusedetailview As Boolean
    Private _moviescraperusemdduration As Boolean
    Private _moviescraperuserrating As Boolean
    Private _moviescraperxbmctrailerformat As Boolean
    Private _moviescraperyear As Boolean
    Private _moviesetbannerheight As Integer
    Private _moviesetbannerkeepexisting As Boolean
    Private _moviesetbannerprefsize As Enums.MovieBannerSize
    Private _moviesetbannerprefsizeonly As Boolean
    Private _moviesetbannerresize As Boolean
    Private _moviesetbannerwidth As Integer
    Private _moviesetcleandb As Boolean
    Private _moviesetcleanfiles As Boolean
    Private _moviesetclearartkeepexisting As Boolean
    Private _moviesetclearartprefsize As Enums.MovieClearArtSize
    Private _moviesetclearartprefsizeonly As Boolean
    Private _moviesetclearlogokeepexisting As Boolean
    Private _moviesetclearlogoprefsize As Enums.MovieClearLogoSize
    Private _moviesetclearlogoprefsizeonly As Boolean
    Private _moviesetclickscrape As Boolean
    Private _moviesetclickscrapeask As Boolean
    Private _moviesetdiscartkeepexisting As Boolean
    Private _moviesetdiscartprefsize As Enums.MovieDiscArtSize
    Private _moviesetdiscartprefsizeonly As Boolean
    Private _moviesetfanartheight As Integer
    Private _moviesetfanartkeepexisting As Boolean
    Private _moviesetfanartprefsize As Enums.MovieFanartSize
    Private _moviesetfanartprefsizeonly As Boolean
    Private _moviesetfanartresize As Boolean
    Private _moviesetfanartwidth As Integer
    Private _moviesetgeneralcustomscrapebuttonenabled As Boolean
    Private _moviesetgeneralcustomscrapebuttonmodifiertype As Enums.ScrapeModifierType
    Private _moviesetgeneralcustomscrapebuttonscrapetype As Enums.ScrapeType
    Private _moviesetgeneralmarknew As Boolean
    Private _moviesetgeneralmedialistsorting As List(Of ListSorting)
    Private _moviesetimagescacheenabled As Boolean
    Private _moviesetimagesdisplayimageselect As Boolean
    Private _moviesetimagesforcedlanguage As String
    Private _moviesetimagesforcelanguage As Boolean
    Private _moviesetimagesgetblankimages As Boolean
    Private _moviesetimagesgetenglishimages As Boolean
    Private _moviesetimagesmedialanguageonly As Boolean
    Private _moviesetlandscapekeepexisting As Boolean
    Private _moviesetlandscapeprefsize As Enums.MovieLandscapeSize
    Private _moviesetlandscapeprefsizeonly As Boolean
    Private _moviesetlockplot As Boolean
    Private _moviesetlocktitle As Boolean
    Private _moviesetmissingbanner As Boolean
    Private _moviesetmissingclearart As Boolean
    Private _moviesetmissingclearlogo As Boolean
    Private _moviesetmissingdiscart As Boolean
    Private _moviesetmissingfanart As Boolean
    Private _moviesetmissinglandscape As Boolean
    Private _moviesetmissingnfo As Boolean
    Private _moviesetmissingposter As Boolean
    Private _moviesetposterheight As Integer
    Private _moviesetposterkeepexisting As Boolean
    Private _moviesetposterprefsize As Enums.MoviePosterSize
    Private _moviesetposterprefsizeonly As Boolean
    Private _moviesetposterresize As Boolean
    Private _moviesetposterwidth As Integer
    Private _moviesetscraperplot As Boolean
    Private _moviesetscrapertitle As Boolean
    Private _moviesetsorttokens As List(Of String)
    Private _moviesetsorttokensisempty As Boolean
    Private _movieskiplessthan As Integer
    Private _movieskipstackedsizecheck As Boolean
    Private _moviesortbeforescan As Boolean
    Private _moviesorttokens As List(Of String)
    Private _moviesorttokensisempty As Boolean
    Private _moviethemekeepexisting As Boolean
    Private _movietrailerdefaultsearch As String
    Private _movietrailerkeepexisting As Boolean
    Private _movietrailerminvideoqual As Enums.TrailerVideoQuality
    Private _movietrailerprefvideoqual As Enums.TrailerVideoQuality
    Private _ommdummyformat As Integer
    Private _ommdummytagline As String
    Private _ommdummytop As String
    Private _ommdummyusebackground As Boolean
    Private _ommdummyusefanart As Boolean
    Private _ommdummyuseoverlay As Boolean
    Private _ommmediastubtagline As String
    Private _password As String
    Private _proxycredentials As NetworkCredential
    Private _proxyport As Integer
    Private _proxyuri As String
    Private _sortpath As String
    Private _tvallseasonsbannerheight As Integer
    Private _tvallseasonsbannerkeepexisting As Boolean
    Private _tvallseasonsbannerprefsize As Enums.TVBannerSize
    Private _tvallseasonsbannerprefsizeonly As Boolean
    Private _tvallseasonsbannerpreftype As Enums.TVBannerType
    Private _tvallseasonsbannerresize As Boolean
    Private _tvallseasonsbannerwidth As Integer
    Private _tvallseasonsfanartheight As Integer
    Private _tvallseasonsfanartkeepexisting As Boolean
    Private _tvallseasonsfanartprefsize As Enums.TVFanartSize
    Private _tvallseasonsfanartprefsizeonly As Boolean
    Private _tvallseasonsfanartresize As Boolean
    Private _tvallseasonsfanartwidth As Integer
    Private _tvallseasonslandscapekeepexisting As Boolean
    Private _tvallseasonslandscapeprefsize As Enums.TVLandscapeSize
    Private _tvallseasonslandscapeprefsizeonly As Boolean
    Private _tvallseasonsposterheight As Integer
    Private _tvallseasonsposterkeepexisting As Boolean
    Private _tvallseasonsposterprefsize As Enums.TVPosterSize
    Private _tvallseasonsposterprefsizeonly As Boolean
    Private _tvallseasonsposterresize As Boolean
    Private _tvallseasonsposterwidth As Integer
    Private _tvcleandb As Boolean
    Private _tvdisplaymissingepisodes As Boolean
    Private _tvdisplaystatus As Boolean
    Private _tvepisodeactorthumbskeepexisting As Boolean
    Private _tvepisodefanartheight As Integer
    Private _tvepisodefanartkeepexisting As Boolean
    Private _tvepisodefanartprefsize As Enums.TVFanartSize
    Private _tvepisodefanartprefsizeonly As Boolean
    Private _tvepisodefanartresize As Boolean
    Private _tvepisodefanartwidth As Integer
    Private _tvepisodefiltercustom As List(Of String)
    Private _tvepisodefiltercustomisempty As Boolean
    Private _tvepisodemissingfanart As Boolean
    Private _tvepisodemissingnfo As Boolean
    Private _tvepisodemissingposter As Boolean
    Private _tvepisodenofilter As Boolean
    Private _tvepisodeposterheight As Integer
    Private _tvepisodeposterkeepexisting As Boolean
    Private _tvepisodeposterprefsize As Enums.TVEpisodePosterSize
    Private _tvepisodeposterprefsizeonly As Boolean
    Private _tvepisodeposterresize As Boolean
    Private _tvepisodeposterwidth As Integer
    Private _tvepisodepropercase As Boolean
    Private _tvgeneralclickscrape As Boolean
    Private _tvgeneralclickscrapeask As Boolean
    Private _tvgeneralcustomscrapebuttonenabled As Boolean
    Private _tvgeneralcustomscrapebuttonmodifiertype As Enums.ScrapeModifierType
    Private _tvgeneralcustomscrapebuttonscrapetype As Enums.ScrapeType
    Private _tvgeneralepisodelistsorting As List(Of ListSorting)
    Private _tvgeneralflaglang As String
    Private _tvgeneralignorelastscan As Boolean
    Private _tvgenerallanguage As String
    Private _tvgeneralmarknewepisodes As Boolean
    Private _tvgeneralmarknewshows As Boolean
    Private _tvgeneralseasonlistsorting As List(Of ListSorting)
    Private _tvgeneralshowlistsorting As List(Of ListSorting)
    Private _tvimagescacheenabled As Boolean
    Private _tvimagesdisplayimageselect As Boolean
    Private _tvimagesforcedlanguage As String
    Private _tvimagesforcelanguage As Boolean
    Private _tvimagesgetblankimages As Boolean
    Private _tvimagesgetenglishimages As Boolean
    Private _tvimagesmedialanguageonly As Boolean
    Private _tvlockepisodeactors As Boolean
    Private _tvlockepisodeaired As Boolean
    Private _tvlockepisodecredits As Boolean
    Private _tvlockepisodedirector As Boolean
    Private _tvlockepisodegueststars As Boolean
    Private _tvlockepisodelanguagea As Boolean
    Private _tvlockepisodelanguagev As Boolean
    Private _tvlockepisodeplot As Boolean
    Private _tvlockepisoderating As Boolean
    Private _tvlockepisoderuntime As Boolean
    Private _tvlockepisodetitle As Boolean
    Private _tvlockepisodeuserrating As Boolean
    Private _tvlockseasonplot As Boolean
    Private _tvlockseasontitle As Boolean
    Private _tvlockshowactors As Boolean
    Private _tvlockshowcert As Boolean
    Private _tvlockshowcountry As Boolean
    Private _tvlockshowcreators As Boolean
    Private _tvlockshowgenre As Boolean
    Private _tvlockshowmpaa As Boolean
    Private _tvlockshoworiginaltitle As Boolean
    Private _tvlockshowplot As Boolean
    Private _tvlockshowpremiered As Boolean
    Private _tvlockshowrating As Boolean
    Private _tvlockshowruntime As Boolean
    Private _tvlockshowstatus As Boolean
    Private _tvlockshowstudio As Boolean
    Private _tvlockshowtitle As Boolean
    Private _tvlockshowuserrating As Boolean
    Private _tvmetadataperfiletype As List(Of MetadataPerType)
    Private _tvmultipartmatching As String
    Private _tvscanordermodify As Boolean
    Private _tvscrapercleanfields As Boolean
    Private _tvscraperdurationruntimeformat As String
    Private _tvscraperepisodeactors As Boolean
    Private _tvscraperepisodeaired As Boolean
    Private _tvscraperepisodecredits As Boolean
    Private _tvscraperepisodedirector As Boolean
    Private _tvscraperepisodegueststars As Boolean
    Private _tvscraperepisodegueststarstoactors As Boolean
    Private _tvscraperepisodeplot As Boolean
    Private _tvscraperepisoderating As Boolean
    Private _tvscraperepisoderuntime As Boolean
    Private _tvscraperepisodetitle As Boolean
    Private _tvscraperepisodeuserrating As Boolean
    Private _tvscrapermetadatascan As Boolean
    Private _tvscraperoptionsordering As Enums.EpisodeOrdering
    Private _tvscraperseasonaired As Boolean
    Private _tvscraperseasonplot As Boolean
    Private _tvscraperseasontitle As Boolean
    Private _tvscrapershowactors As Boolean
    Private _tvscrapershowcert As Boolean
    Private _tvscrapershowcertformpaa As Boolean
    Private _tvscrapershowcertformpaafallback As Boolean
    Private _tvscrapershowcertfsk As Boolean
    Private _tvscrapershowcertlang As String
    Private _tvscrapershowcertonlyvalue As Boolean
    Private _tvscrapershowcountry As Boolean
    Private _tvscrapershowcreators As Boolean
    Private _tvscrapershowepiguideurl As Boolean
    Private _tvscrapershowgenre As Boolean
    Private _tvscrapershowmpaa As Boolean
    Private _tvscrapershowmpaanotrated As String
    Private _tvscrapershoworiginaltitle As Boolean
    Private _tvscrapershowplot As Boolean
    Private _tvscrapershowpremiered As Boolean
    Private _tvscrapershowrating As Boolean
    Private _tvscrapershowruntime As Boolean
    Private _tvscrapershowstatus As Boolean
    Private _tvscrapershowstudio As Boolean
    Private _tvscrapershowtitle As Boolean
    Private _tvscrapershowuserrating As Boolean
    Private _tvscraperusedisplayseasonepisode As Boolean
    Private _tvscraperusemdduration As Boolean
    Private _tvscraperusesruntimeforep As Boolean
    Private _tvseasonbannerheight As Integer
    Private _tvseasonbannerkeepexisting As Boolean
    Private _tvseasonbannerprefsize As Enums.TVBannerSize
    Private _tvseasonbannerprefsizeonly As Boolean
    Private _tvseasonbannerpreftype As Enums.TVBannerType
    Private _tvseasonbannerresize As Boolean
    Private _tvseasonbannerwidth As Integer
    Private _tvseasonfanartheight As Integer
    Private _tvseasonfanartkeepexisting As Boolean
    Private _tvseasonfanartprefsize As Enums.TVFanartSize
    Private _tvseasonfanartprefsizeonly As Boolean
    Private _tvseasonfanartresize As Boolean
    Private _tvseasonfanartwidth As Integer
    Private _tvseasonlandscapekeepexisting As Boolean
    Private _tvseasonlandscapeprefsize As Enums.TVLandscapeSize
    Private _tvseasonlandscapeprefsizeonly As Boolean
    Private _tvseasonmissingbanner As Boolean
    Private _tvseasonmissingfanart As Boolean
    Private _tvseasonmissinglandscape As Boolean
    Private _tvseasonmissingposter As Boolean
    Private _tvseasonposterheight As Integer
    Private _tvseasonposterkeepexisting As Boolean
    Private _tvseasonposterprefsize As Enums.TVSeasonPosterSize
    Private _tvseasonposterprefsizeonly As Boolean
    Private _tvseasonposterresize As Boolean
    Private _tvseasonposterwidth As Integer
    Private _tvshowactorthumbskeepexisting As Boolean
    Private _tvshowbannerheight As Integer
    Private _tvshowbannerkeepexisting As Boolean
    Private _tvshowbannerprefsize As Enums.TVBannerSize
    Private _tvshowbannerprefsizeonly As Boolean
    Private _tvshowbannerpreftype As Enums.TVBannerType
    Private _tvshowbannerresize As Boolean
    Private _tvshowbannerwidth As Integer
    Private _tvshowcharacterartkeepexisting As Boolean
    Private _tvshowcharacterartprefsize As Enums.TVCharacterArtSize
    Private _tvshowcharacterartprefsizeonly As Boolean
    Private _tvshowclearartkeepexisting As Boolean
    Private _tvshowclearartprefsize As Enums.TVClearArtSize
    Private _tvshowclearartprefsizeonly As Boolean
    Private _tvshowclearlogokeepexisting As Boolean
    Private _tvshowclearlogoprefsize As Enums.TVClearLogoSize
    Private _tvshowclearlogoprefsizeonly As Boolean
    Private _tvshowextrafanartsheight As Integer
    Private _tvshowextrafanartskeepexisting As Boolean
    Private _tvshowextrafanartslimit As Integer
    Private _tvshowextrafanartsprefsize As Enums.TVFanartSize
    Private _tvshowextrafanartsprefsizeonly As Boolean
    Private _tvshowextrafanartspreselect As Boolean
    Private _tvshowextrafanartsresize As Boolean
    Private _tvshowextrafanartswidth As Integer
    Private _tvshowfanartheight As Integer
    Private _tvshowfanartkeepexisting As Boolean
    Private _tvshowfanartprefsize As Enums.TVFanartSize
    Private _tvshowfanartprefsizeonly As Boolean
    Private _tvshowfanartresize As Boolean
    Private _tvshowfanartwidth As Integer
    Private _tvshowfiltercustom As List(Of String)
    Private _tvshowfiltercustomisempty As Boolean
    Private _tvshowlandscapekeepexisting As Boolean
    Private _tvshowlandscapeprefsize As Enums.TVLandscapeSize
    Private _tvshowlandscapeprefsizeonly As Boolean
    Private _tvshowmatching As List(Of regexp)
    Private _tvshowmissingbanner As Boolean
    Private _tvshowmissingcharacterart As Boolean
    Private _tvshowmissingclearart As Boolean
    Private _tvshowmissingclearlogo As Boolean
    Private _tvshowmissingextrafanarts As Boolean
    Private _tvshowmissingfanart As Boolean
    Private _tvshowmissinglandscape As Boolean
    Private _tvshowmissingnfo As Boolean
    Private _tvshowmissingposter As Boolean
    Private _tvshowmissingtheme As Boolean
    Private _tvshowposterheight As Integer
    Private _tvshowposterkeepexisting As Boolean
    Private _tvshowposterprefsize As Enums.TVPosterSize
    Private _tvshowposterprefsizeonly As Boolean
    Private _tvshowposterresize As Boolean
    Private _tvshowposterwidth As Integer
    Private _tvshowpropercase As Boolean
    Private _tvshowthemekeepexisting As Boolean
    Private _tvskiplessthan As Integer
    Private _tvsorttokens As List(Of String)
    Private _tvsorttokensisempty As Boolean
    Private _username As String
    Private _version As String


    '***************************************************
    '******************* Movie Part ********************
    '***************************************************

    '*************** Kodi Frodo settings ***************
    Private _movieusefrodo As Boolean
    Private _movieactorthumbsfrodo As Boolean
    Private _movieextrafanartsfrodo As Boolean
    Private _movieextrathumbsfrodo As Boolean
    Private _moviefanartfrodo As Boolean
    Private _movienfofrodo As Boolean
    Private _movieposterfrodo As Boolean
    Private _movietrailerfrodo As Boolean

    '*************** Kodi Eden settings ***************
    Private _movieuseeden As Boolean
    Private _movieactorthumbseden As Boolean
    Private _movieextrafanartseden As Boolean
    Private _movieextrathumbseden As Boolean
    Private _moviefanarteden As Boolean
    Private _movienfoeden As Boolean
    Private _moviepostereden As Boolean
    Private _movietrailereden As Boolean

    '******** Kodi ArtworkDownloader settings *********
    Private _movieusead As Boolean
    Private _moviebannerad As Boolean
    Private _movieclearartad As Boolean
    Private _movieclearlogoad As Boolean
    Private _moviediscartad As Boolean
    Private _movielandscapead As Boolean

    '********* Kodi Extended Images settings **********
    Private _movieuseextended As Boolean
    Private _moviebannerextended As Boolean
    Private _movieclearartextended As Boolean
    Private _movieclearlogoextended As Boolean
    Private _moviediscartextended As Boolean
    Private _movielandscapeextended As Boolean

    '************* Kodi optional settings *************
    Private _moviexbmcprotectvtsbdmv As Boolean

    '*************** Kodi TvTunes settings ***************
    Private _moviethemetvtunesenable As Boolean
    Private _moviethemetvtunescustom As Boolean
    Private _moviethemetvtunescustompath As String
    Private _moviethemetvtunesmoviepath As Boolean
    Private _moviethemetvtunessub As Boolean
    Private _moviethemetvtunessubdir As String

    '****************** YAMJ settings *****************
    Private _movieuseyamj As Boolean
    Private _movieactorthumbsyamj As Boolean
    Private _moviebanneryamj As Boolean
    Private _movieclearartyamj As Boolean
    Private _movieclearlogoyamj As Boolean
    Private _moviediscartyamj As Boolean
    Private _movieextrafanartsyamj As Boolean
    Private _movieextrathumbsyamj As Boolean
    Private _moviefanartyamj As Boolean
    Private _movielandscapeyamj As Boolean
    Private _movienfoyamj As Boolean
    Private _movieposteryamj As Boolean
    Private _movietraileryamj As Boolean
    Private _movieyamjwatchedfile As Boolean
    Private _movieyamjwatchedfolder As String

    '****************** NMJ settings ******************
    Private _movieusenmj As Boolean
    Private _movieactorthumbsnmj As Boolean
    Private _moviebannernmj As Boolean
    Private _movieclearartnmj As Boolean
    Private _movieclearlogonmj As Boolean
    Private _moviediscartnmj As Boolean
    Private _movieextrafanartsnmj As Boolean
    Private _movieextrathumbsnmj As Boolean
    Private _moviefanartnmj As Boolean
    Private _movielandscapenmj As Boolean
    Private _movienfonmj As Boolean
    Private _movieposternmj As Boolean
    Private _movietrailernmj As Boolean

    '***************** Boxee settings ******************
    Private _movieuseboxee As Boolean
    Private _moviefanartboxee As Boolean
    Private _movienfoboxee As Boolean
    Private _movieposterboxee As Boolean

    '***************** Expert settings ****************
    Private _movieuseexpert As Boolean

    '***************** Expert Single ****************
    Private _movieactorthumbsexpertsingle As Boolean
    Private _movieactorthumbsextexpertsingle As String
    Private _moviebannerexpertsingle As String
    Private _movieclearartexpertsingle As String
    Private _movieclearlogoexpertsingle As String
    Private _moviediscartexpertsingle As String
    Private _movieextrafanartsexpertsingle As Boolean
    Private _movieextrathumbsexpertsingle As Boolean
    Private _moviefanartexpertsingle As String
    Private _movielandscapeexpertsingle As String
    Private _movienfoexpertsingle As String
    Private _movieposterexpertsingle As String
    Private _moviestackexpertsingle As Boolean
    Private _movietrailerexpertsingle As String
    Private _movieunstackexpertsingle As Boolean

    '***************** Expert Multi ****************
    Private _movieactorthumbsexpertmulti As Boolean
    Private _movieactorthumbsextexpertmulti As String
    Private _moviebannerexpertmulti As String
    Private _movieclearartexpertmulti As String
    Private _movieclearlogoexpertmulti As String
    Private _moviediscartexpertmulti As String
    Private _moviefanartexpertmulti As String
    Private _movielandscapeexpertmulti As String
    Private _movienfoexpertmulti As String
    Private _movieposterexpertmulti As String
    Private _moviestackexpertmulti As Boolean
    Private _movietrailerexpertmulti As String
    Private _movieunstackexpertmulti As Boolean

    '***************** Expert VTS ****************
    Private _movieactorthumbsexpertvts As Boolean
    Private _movieactorthumbsextexpertvts As String
    Private _moviebannerexpertvts As String
    Private _movieclearartexpertvts As String
    Private _movieclearlogoexpertvts As String
    Private _moviediscartexpertvts As String
    Private _movieextrafanartsexpertvts As Boolean
    Private _movieextrathumbsexpertvts As Boolean
    Private _moviefanartexpertvts As String
    Private _movielandscapeexpertvts As String
    Private _movienfoexpertvts As String
    Private _movieposterexpertvts As String
    Private _movierecognizevtsexpertvts As Boolean
    Private _movietrailerexpertvts As String
    Private _movieusebasedirectoryexpertvts As Boolean

    '***************** Expert BDMV ****************
    Private _movieactorthumbsexpertbdmv As Boolean
    Private _movieactorthumbsextexpertbdmv As String
    Private _moviebannerexpertbdmv As String
    Private _movieclearartexpertbdmv As String
    Private _movieclearlogoexpertbdmv As String
    Private _moviediscartexpertbdmv As String
    Private _movieextrafanartsexpertbdmv As Boolean
    Private _movieextrathumbsexpertbdmv As Boolean
    Private _moviefanartexpertbdmv As String
    Private _movielandscapeexpertbdmv As String
    Private _movienfoexpertbdmv As String
    Private _movieposterexpertbdmv As String
    Private _movietrailerexpertbdmv As String
    Private _movieusebasedirectoryexpertbdmv As Boolean


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
    Private _moviesetbannerexpertparent As String
    Private _moviesetbannerexpertsingle As String
    Private _moviesetclearartexpertparent As String
    Private _moviesetclearartexpertsingle As String
    Private _moviesetclearlogoexpertparent As String
    Private _moviesetclearlogoexpertsingle As String
    Private _moviesetdiscartexpertparent As String
    Private _moviesetdiscartexpertsingle As String
    Private _moviesetfanartexpertparent As String
    Private _moviesetfanartexpertsingle As String
    Private _moviesetlandscapeexpertparent As String
    Private _moviesetlandscapeexpertsingle As String
    Private _moviesetnfoexpertparent As String
    Private _moviesetnfoexpertsingle As String
    Private _moviesetpathexpertsingle As String
    Private _moviesetposterexpertparent As String
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

    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    Public Property MovieActorThumbsNMJ() As Boolean
        Get
            Return _movieactorthumbsnmj
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsnmj = value
        End Set
    End Property

    Public Property MovieActorThumbsYAMJ() As Boolean
        Get
            Return _movieactorthumbsyamj
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsyamj = value
        End Set
    End Property

    Public Property MovieClearArtNMJ() As Boolean
        Get
            Return _movieclearartnmj
        End Get
        Set(ByVal value As Boolean)
            _movieclearartnmj = value
        End Set
    End Property

    Public Property MovieClearArtYAMJ() As Boolean
        Get
            Return _movieclearartyamj
        End Get
        Set(ByVal value As Boolean)
            _movieclearartyamj = value
        End Set
    End Property

    Public Property MovieClearLogoNMJ() As Boolean
        Get
            Return _movieclearlogonmj
        End Get
        Set(ByVal value As Boolean)
            _movieclearlogonmj = value
        End Set
    End Property

    Public Property MovieClearLogoYAMJ() As Boolean
        Get
            Return _movieclearlogoyamj
        End Get
        Set(ByVal value As Boolean)
            _movieclearlogoyamj = value
        End Set
    End Property

    Public Property MovieDiscArtNMJ() As Boolean
        Get
            Return _moviediscartnmj
        End Get
        Set(ByVal value As Boolean)
            _moviediscartnmj = value
        End Set
    End Property

    Public Property MovieDiscArtYAMJ() As Boolean
        Get
            Return _moviediscartyamj
        End Get
        Set(ByVal value As Boolean)
            _moviediscartyamj = value
        End Set
    End Property

    Public Property MovieExtrafanartsNMJ() As Boolean
        Get
            Return _movieextrafanartsnmj
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsnmj = value
        End Set
    End Property

    Public Property MovieExtrafanartsYAMJ() As Boolean
        Get
            Return _movieextrafanartsyamj
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsyamj = value
        End Set
    End Property

    Public Property MovieExtrathumbsNMJ() As Boolean
        Get
            Return _movieextrathumbsnmj
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsnmj = value
        End Set
    End Property

    Public Property MovieExtrathumbsYAMJ() As Boolean
        Get
            Return _movieextrathumbsyamj
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsyamj = value
        End Set
    End Property

    Public Property MovieLandscapeNMJ() As Boolean
        Get
            Return _movielandscapenmj
        End Get
        Set(ByVal value As Boolean)
            _movielandscapenmj = value
        End Set
    End Property

    Public Property MovieLandscapeYAMJ() As Boolean
        Get
            Return _movielandscapeyamj
        End Get
        Set(ByVal value As Boolean)
            _movielandscapeyamj = value
        End Set
    End Property

    Public Property ProxyCredentials() As NetworkCredential
        Get
            Return _proxycredentials
        End Get
        Set(ByVal value As NetworkCredential)
            _proxycredentials = value
        End Set
    End Property

    Public Property MovieScraperCastLimit() As Integer
        Get
            Return _moviescrapercastlimit
        End Get
        Set(ByVal value As Integer)
            _moviescrapercastlimit = value
        End Set
    End Property

    Public Property MovieActorThumbsKeepExisting() As Boolean
        Get
            Return _movieactorthumbskeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbskeepexisting = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterHeight() As Integer
        Get
            Return _tvallseasonsposterheight
        End Get
        Set(ByVal value As Integer)
            _tvallseasonsposterheight = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterWidth() As Integer
        Get
            Return _tvallseasonsposterwidth
        End Get
        Set(ByVal value As Integer)
            _tvallseasonsposterwidth = value
        End Set
    End Property

    Public Property GeneralShowGenresText() As Boolean
        Get
            Return _generalshowgenrestext
        End Get
        Set(ByVal value As Boolean)
            _generalshowgenrestext = value
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

    Public Property MovieClickScrape() As Boolean
        Get
            Return _movieclickscrape
        End Get
        Set(ByVal value As Boolean)
            _movieclickscrape = value
        End Set
    End Property

    Public Property MovieClickScrapeAsk() As Boolean
        Get
            Return _movieclickscrapeask
        End Get
        Set(ByVal value As Boolean)
            _movieclickscrapeask = value
        End Set
    End Property

    Public Property MovieBackdropsAuto() As Boolean
        Get
            Return _moviebackdropsauto
        End Get
        Set(ByVal value As Boolean)
            _moviebackdropsauto = value
        End Set
    End Property

    Public Property MovieIMDBURL() As String
        Get
            Return _movieimdburl
        End Get
        Set(ByVal value As String)
            _movieimdburl = value
        End Set
    End Property

    Public Property MovieBackdropsPath() As String
        Get
            Return _moviebackdropspath
        End Get
        Set(ByVal value As String)
            _moviebackdropspath = value
        End Set
    End Property

    Public Property MovieScraperCastWithImgOnly() As Boolean
        Get
            Return _moviescrapercastwithimgonly
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercastwithimgonly = value
        End Set
    End Property

    Public Property MovieScraperCertLang() As String
        Get
            Return _moviescrapercertlang
        End Get
        Set(ByVal value As String)
            _moviescrapercertlang = value
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

    Public Property CleanDotFanartJPG() As Boolean
        Get
            Return _cleandotfanartjpg
        End Get
        Set(ByVal value As Boolean)
            _cleandotfanartjpg = value
        End Set
    End Property

    Public Property CleanExtrathumbs() As Boolean
        Get
            Return _cleanextrathumbs
        End Get
        Set(ByVal value As Boolean)
            _cleanextrathumbs = value
        End Set
    End Property

    Public Property CleanFanartJPG() As Boolean
        Get
            Return _cleanfanartjpg
        End Get
        Set(ByVal value As Boolean)
            _cleanfanartjpg = value
        End Set
    End Property

    Public Property CleanFolderJPG() As Boolean
        Get
            Return _cleanfolderjpg
        End Get
        Set(ByVal value As Boolean)
            _cleanfolderjpg = value
        End Set
    End Property

    Public Property CleanMovieFanartJPG() As Boolean
        Get
            Return _cleanmoviefanartjpg
        End Get
        Set(ByVal value As Boolean)
            _cleanmoviefanartjpg = value
        End Set
    End Property

    Public Property CleanMovieJPG() As Boolean
        Get
            Return _cleanmoviejpg
        End Get
        Set(ByVal value As Boolean)
            _cleanmoviejpg = value
        End Set
    End Property

    Public Property CleanMovieNameJPG() As Boolean
        Get
            Return _cleanmovienamejpg
        End Get
        Set(ByVal value As Boolean)
            _cleanmovienamejpg = value
        End Set
    End Property

    Public Property CleanMovieNFO() As Boolean
        Get
            Return _cleanmovienfo
        End Get
        Set(ByVal value As Boolean)
            _cleanmovienfo = value
        End Set
    End Property

    Public Property CleanMovieNFOB() As Boolean
        Get
            Return _cleanmovienfob
        End Get
        Set(ByVal value As Boolean)
            _cleanmovienfob = value
        End Set
    End Property

    Public Property CleanMovieTBN() As Boolean
        Get
            Return _cleanmovietbn
        End Get
        Set(ByVal value As Boolean)
            _cleanmovietbn = value
        End Set
    End Property

    Public Property CleanMovieTBNB() As Boolean
        Get
            Return _cleanmovietbnb
        End Get
        Set(ByVal value As Boolean)
            _cleanmovietbnb = value
        End Set
    End Property

    Public Property CleanPosterJPG() As Boolean
        Get
            Return _cleanposterjpg
        End Get
        Set(ByVal value As Boolean)
            _cleanposterjpg = value
        End Set
    End Property

    Public Property CleanPosterTBN() As Boolean
        Get
            Return _cleanpostertbn
        End Get
        Set(ByVal value As Boolean)
            _cleanpostertbn = value
        End Set
    End Property

    Public Property FileSystemCleanerWhitelistExts() As List(Of String)
        Get
            Return _filesystemcleanerwhitelistexts
        End Get
        Set(ByVal value As List(Of String))
            _filesystemcleanerwhitelistexts = value
        End Set
    End Property

    Public Property FileSystemCleanerWhitelist() As Boolean
        Get
            Return _filesystemcleanerwhitelist
        End Get
        Set(ByVal value As Boolean)
            _filesystemcleanerwhitelist = value
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

    Public Property TVDisplayStatus() As Boolean
        Get
            Return _tvdisplaystatus
        End Get
        Set(ByVal value As Boolean)
            _tvdisplaystatus = value
        End Set
    End Property

    Public Property MovieImagesCacheEnabled() As Boolean
        Get
            Return _movieimagescacheenabled
        End Get
        Set(ByVal value As Boolean)
            _movieimagescacheenabled = value
        End Set
    End Property

    Public Property MovieSetImagesCacheEnabled() As Boolean
        Get
            Return _moviesetimagescacheenabled
        End Get
        Set(ByVal value As Boolean)
            _moviesetimagescacheenabled = value
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

    Public Property MovieImagesDisplayImageSelect() As Boolean
        Get
            Return _movieimagesdisplayimageselect
        End Get
        Set(ByVal value As Boolean)
            _movieimagesdisplayimageselect = value
        End Set
    End Property

    Public Property MovieSetImagesDisplayImageSelect() As Boolean
        Get
            Return _moviesetimagesdisplayimageselect
        End Get
        Set(ByVal value As Boolean)
            _moviesetimagesdisplayimageselect = value
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

    Public Property MovieDisplayYear() As Boolean
        Get
            Return _moviedisplayyear
        End Get
        Set(ByVal value As Boolean)
            _moviedisplayyear = value
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
            Return _addond
        End Get
        Set(ByVal value As List(Of AddonsManager._XMLAddonClass))
            _addond = value
        End Set
    End Property

    Public Property MovieScraperMetaDataIFOScan() As Boolean
        Get
            Return _moviescrapermetadataifoscan
        End Get
        Set(ByVal value As Boolean)
            _moviescrapermetadataifoscan = value
        End Set
    End Property

    Public Property TVEpisodeFanartHeight() As Integer
        Get
            Return _tvepisodefanartheight
        End Get
        Set(ByVal value As Integer)
            _tvepisodefanartheight = value
        End Set
    End Property

    Public Property TVEpisodeFanartWidth() As Integer
        Get
            Return _tvepisodefanartwidth
        End Get
        Set(ByVal value As Integer)
            _tvepisodefanartwidth = value
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

    Public Property TVLockEpisodeLanguageA() As Boolean
        Get
            Return _tvlockepisodelanguagea
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodelanguagea = value
        End Set
    End Property

    Public Property TVLockEpisodeLanguageV() As Boolean
        Get
            Return _tvlockepisodelanguagev
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodelanguagev = value
        End Set
    End Property

    Public Property TVLockEpisodeActors() As Boolean
        Get
            Return _tvlockepisodeactors
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodeactors = value
        End Set
    End Property

    Public Property TVLockEpisodeAired() As Boolean
        Get
            Return _tvlockepisodeaired
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodeaired = value
        End Set
    End Property

    Public Property TVLockEpisodeCredits() As Boolean
        Get
            Return _tvlockepisodecredits
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodecredits = value
        End Set
    End Property

    Public Property TVLockEpisodeDirector() As Boolean
        Get
            Return _tvlockepisodedirector
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodedirector = value
        End Set
    End Property

    Public Property TVLockEpisodeGuestStars() As Boolean
        Get
            Return _tvlockepisodegueststars
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodegueststars = value
        End Set
    End Property

    Public Property TVLockEpisodePlot() As Boolean
        Get
            Return _tvlockepisodeplot
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodeplot = value
        End Set
    End Property

    Public Property TVLockEpisodeRating() As Boolean
        Get
            Return _tvlockepisoderating
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisoderating = value
        End Set
    End Property

    Public Property TVLockEpisodeUserRating() As Boolean
        Get
            Return _tvlockepisodeuserrating
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodeuserrating = value
        End Set
    End Property

    Public Property TVLockEpisodeRuntime() As Boolean
        Get
            Return _tvlockepisoderuntime
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisoderuntime = value
        End Set
    End Property

    Public Property TVLockEpisodeTitle() As Boolean
        Get
            Return _tvlockepisodetitle
        End Get
        Set(ByVal value As Boolean)
            _tvlockepisodetitle = value
        End Set
    End Property

    Public Property TVEpisodePosterHeight() As Integer
        Get
            Return _tvepisodeposterheight
        End Get
        Set(ByVal value As Integer)
            _tvepisodeposterheight = value
        End Set
    End Property

    Public Property TVEpisodePosterWidth() As Integer
        Get
            Return _tvepisodeposterwidth
        End Get
        Set(ByVal value As Integer)
            _tvepisodeposterwidth = value
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

    Public Property FileSystemExpertCleaner() As Boolean
        Get
            Return _filesystemexpertcleaner
        End Get
        Set(ByVal value As Boolean)
            _filesystemexpertcleaner = value
        End Set
    End Property

    Public Property TVShowExtrafanartsHeight() As Integer
        Get
            Return _tvshowextrafanartsheight
        End Get
        Set(ByVal value As Integer)
            _tvshowextrafanartsheight = value
        End Set
    End Property

    Public Property MovieExtrafanartsHeight() As Integer
        Get
            Return _movieextrafanartsheight
        End Get
        Set(ByVal value As Integer)
            _movieextrafanartsheight = value
        End Set
    End Property

    Public Property MovieExtrathumbsHeight() As Integer
        Get
            Return _movieextrathumbsheight
        End Get
        Set(ByVal value As Integer)
            _movieextrathumbsheight = value
        End Set
    End Property

    Public Property MovieExtrathumbsLimit() As Integer
        Get
            Return _movieextrathumbslimit
        End Get
        Set(ByVal value As Integer)
            _movieextrathumbslimit = value
        End Set
    End Property

    Public Property TVShowExtrafanartsLimit() As Integer
        Get
            Return _tvshowextrafanartslimit
        End Get
        Set(ByVal value As Integer)
            _tvshowextrafanartslimit = value
        End Set
    End Property

    Public Property MovieExtrafanartsLimit() As Integer
        Get
            Return _movieextrafanartslimit
        End Get
        Set(ByVal value As Integer)
            _movieextrafanartslimit = value
        End Set
    End Property

    Public Property MovieFanartHeight() As Integer
        Get
            Return _moviefanartheight
        End Get
        Set(ByVal value As Integer)
            _moviefanartheight = value
        End Set
    End Property

    Public Property MovieSetFanartHeight() As Integer
        Get
            Return _moviesetfanartheight
        End Get
        Set(ByVal value As Integer)
            _moviesetfanartheight = value
        End Set
    End Property

    Public Property MovieExtrafanartsPrefSizeOnly() As Boolean
        Get
            Return _movieextrafanartsprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsprefsizeonly = value
        End Set
    End Property

    Public Property MovieExtrathumbsCreatorAutoThumbs() As Boolean
        Get
            Return _movieextrathumbscreatorautothumbs
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbscreatorautothumbs = value
        End Set
    End Property

    Public Property MovieExtrathumbsCreatorNoBlackBars() As Boolean
        Get
            Return _movieextrathumbscreatornoblackbars
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbscreatornoblackbars = value
        End Set
    End Property

    Public Property MovieExtrathumbsCreatorNoSpoilers() As Boolean
        Get
            Return _movieextrathumbscreatornospoilers
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbscreatornospoilers = value
        End Set
    End Property

    Public Property MovieExtrathumbsCreatorUseETasFA() As Boolean
        Get
            Return _movieextrathumbscreatoruseetasfa
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbscreatoruseetasfa = value
        End Set
    End Property

    Public Property MovieExtrathumbsPrefSizeOnly() As Boolean
        Get
            Return _movieextrathumbsprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsprefsizeonly = value
        End Set
    End Property

    Public Property MovieFanartPrefSizeOnly() As Boolean
        Get
            Return _moviefanartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviefanartprefsizeonly = value
        End Set
    End Property

    Public Property TVShowExtrafanartsWidth() As Integer
        Get
            Return _tvshowextrafanartswidth
        End Get
        Set(ByVal value As Integer)
            _tvshowextrafanartswidth = value
        End Set
    End Property

    Public Property MovieExtrafanartsWidth() As Integer
        Get
            Return _movieextrafanartswidth
        End Get
        Set(ByVal value As Integer)
            _movieextrafanartswidth = value
        End Set
    End Property

    Public Property MovieExtrathumbsWidth() As Integer
        Get
            Return _movieextrathumbswidth
        End Get
        Set(ByVal value As Integer)
            _movieextrathumbswidth = value
        End Set
    End Property

    Public Property MovieFanartWidth() As Integer
        Get
            Return _moviefanartwidth
        End Get
        Set(ByVal value As Integer)
            _moviefanartwidth = value
        End Set
    End Property

    Public Property MovieSetFanartWidth() As Integer
        Get
            Return _moviesetfanartwidth
        End Get
        Set(ByVal value As Integer)
            _moviesetfanartwidth = value
        End Set
    End Property

    Public Property MovieScraperTop250() As Boolean
        Get
            Return _moviescrapertop250
        End Get
        Set(ByVal value As Boolean)
            _moviescrapertop250 = value
        End Set
    End Property

    Public Property MovieScraperCollectionID() As Boolean
        Get
            Return _moviescrapercollectionid
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercollectionid = value
        End Set
    End Property

    Public Property MovieScraperCollectionsAuto() As Boolean
        Get
            Return _moviescrapercollectionsauto
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercollectionsauto = value
        End Set
    End Property

    Public Property MovieScraperCollectionsExtendedInfo() As Boolean
        Get
            Return _moviescrapercollectionsextendedinfo
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercollectionsextendedinfo = value
        End Set
    End Property

    Public Property MovieScraperCountry() As Boolean
        Get
            Return _moviescrapercountry
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercountry = value
        End Set
    End Property

    Public Property MovieScraperCast() As Boolean
        Get
            Return _moviescrapercast
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercast = value
        End Set
    End Property

    Public Property MovieScraperCert() As Boolean
        Get
            Return _moviescrapercert
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercert = value
        End Set
    End Property

    Public Property MovieScraperMPAA() As Boolean
        Get
            Return _moviescrapermpaa
        End Get
        Set(ByVal value As Boolean)
            _moviescrapermpaa = value
        End Set
    End Property

    Public Property MovieScraperMPAANotRated() As String
        Get
            Return _moviescrapermpaanotrated
        End Get
        Set(ByVal value As String)
            _moviescrapermpaanotrated = value
        End Set
    End Property

    Public Property MovieScraperDirector() As Boolean
        Get
            Return _moviescraperdirector
        End Get
        Set(ByVal value As Boolean)
            _moviescraperdirector = value
        End Set
    End Property

    Public Property MovieScraperGenre() As Boolean
        Get
            Return _moviescrapergenre
        End Get
        Set(ByVal value As Boolean)
            _moviescrapergenre = value
        End Set
    End Property

    Public Property MovieScraperOriginalTitle() As Boolean
        Get
            Return _moviescraperoriginaltitle
        End Get
        Set(ByVal value As Boolean)
            _moviescraperoriginaltitle = value
        End Set
    End Property

    Public Property MovieScraperOutline() As Boolean
        Get
            Return _moviescraperoutline
        End Get
        Set(ByVal value As Boolean)
            _moviescraperoutline = value
        End Set
    End Property

    Public Property MovieScraperPlot() As Boolean
        Get
            Return _moviescraperplot
        End Get
        Set(ByVal value As Boolean)
            _moviescraperplot = value
        End Set
    End Property

    Public Property MovieScraperRating() As Boolean
        Get
            Return _moviescraperrating
        End Get
        Set(ByVal value As Boolean)
            _moviescraperrating = value
        End Set
    End Property

    Public Property MovieScraperUserRating() As Boolean
        Get
            Return _moviescraperuserrating
        End Get
        Set(ByVal value As Boolean)
            _moviescraperuserrating = value
        End Set
    End Property

    Public Property MovieScraperRelease() As Boolean
        Get
            Return _moviescraperrelease
        End Get
        Set(ByVal value As Boolean)
            _moviescraperrelease = value
        End Set
    End Property

    Public Property MovieScraperRuntime() As Boolean
        Get
            Return _moviescraperruntime
        End Get
        Set(ByVal value As Boolean)
            _moviescraperruntime = value
        End Set
    End Property

    Public Property MovieScraperStudio() As Boolean
        Get
            Return _moviescraperstudio
        End Get
        Set(ByVal value As Boolean)
            _moviescraperstudio = value
        End Set
    End Property

    Public Property MovieScraperStudioLimit() As Integer
        Get
            Return _moviescraperstudiolimit
        End Get
        Set(ByVal value As Integer)
            _moviescraperstudiolimit = value
        End Set
    End Property

    Public Property MovieScraperStudioWithImgOnly() As Boolean
        Get
            Return _moviescraperstudiowithimgonly
        End Get
        Set(ByVal value As Boolean)
            _moviescraperstudiowithimgonly = value
        End Set
    End Property

    Public Property MovieScraperTagline() As Boolean
        Get
            Return _moviescrapertagline
        End Get
        Set(ByVal value As Boolean)
            _moviescrapertagline = value
        End Set
    End Property

    Public Property MovieScraperTitle() As Boolean
        Get
            Return _moviescrapertitle
        End Get
        Set(ByVal value As Boolean)
            _moviescrapertitle = value
        End Set
    End Property

    Public Property MovieScraperTrailer() As Boolean
        Get
            Return _moviescrapertrailer
        End Get
        Set(ByVal value As Boolean)
            _moviescrapertrailer = value
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

    Public Property MovieScraperCredits() As Boolean
        Get
            Return _moviescrapercredits
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercredits = value
        End Set
    End Property

    Public Property MovieScraperYear() As Boolean
        Get
            Return _moviescraperyear
        End Get
        Set(ByVal value As Boolean)
            _moviescraperyear = value
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

    Public Property GeneralFilterPanelIsRaisedMovie() As Boolean
        Get
            Return _generalfilterpanelisraisedmovie
        End Get
        Set(ByVal value As Boolean)
            _generalfilterpanelisraisedmovie = value
        End Set
    End Property

    Public Property GeneralFilterPanelIsRaisedMovieSet() As Boolean
        Get
            Return _generalfilterpanelisraisedmovieset
        End Get
        Set(ByVal value As Boolean)
            _generalfilterpanelisraisedmovieset = value
        End Set
    End Property

    Public Property GeneralFilterPanelIsRaisedTVShow() As Boolean
        Get
            Return _generalfilterpanelisraisedtvshow
        End Get
        Set(ByVal value As Boolean)
            _generalfilterpanelisraisedtvshow = value
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

    Public Property MovieScraperCleanFields() As Boolean
        Get
            Return _moviescrapercleanfields
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercleanfields = value
        End Set
    End Property

    Public Property TVScraperCleanFields() As Boolean
        Get
            Return _tvscrapercleanfields
        End Get
        Set(ByVal value As Boolean)
            _tvscrapercleanfields = value
        End Set
    End Property

    Public Property MovieScraperCleanPlotOutline() As Boolean
        Get
            Return _moviescrapercleanplotoutline
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercleanplotoutline = value
        End Set
    End Property

    Public Property MovieScraperGenreLimit() As Integer
        Get
            Return _moviescrapergenrelimit
        End Get
        Set(ByVal value As Integer)
            _moviescrapergenrelimit = value
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

    Public Property GeneralInfoPanelStateMovie() As Integer
        Get
            Return _generalinfopanelstatemovie
        End Get
        Set(ByVal value As Integer)
            _generalinfopanelstatemovie = value
        End Set
    End Property

    Public Property GeneralInfoPanelStateMovieSet() As Integer
        Get
            Return _generalinfopanelstatemovieset
        End Get
        Set(ByVal value As Integer)
            _generalinfopanelstatemovieset = value
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

    Public Property MovieLockActors() As Boolean
        Get
            Return _movielockactors
        End Get
        Set(ByVal value As Boolean)
            _movielockactors = value
        End Set
    End Property

    Public Property MovieLockCollectionID() As Boolean
        Get
            Return _movielockcollectionid
        End Get
        Set(ByVal value As Boolean)
            _movielockcollectionid = value
        End Set
    End Property

    Public Property MovieLockCollections() As Boolean
        Get
            Return _movielockcollections
        End Get
        Set(ByVal value As Boolean)
            _movielockcollections = value
        End Set
    End Property

    Public Property MovieLockCountry() As Boolean
        Get
            Return _movielockcountry
        End Get
        Set(ByVal value As Boolean)
            _movielockcountry = value
        End Set
    End Property

    Public Property MovieLockDirector() As Boolean
        Get
            Return _movielockdirector
        End Get
        Set(ByVal value As Boolean)
            _movielockdirector = value
        End Set
    End Property

    Public Property MovieLockGenre() As Boolean
        Get
            Return _movielockgenre
        End Get
        Set(ByVal value As Boolean)
            _movielockgenre = value
        End Set
    End Property

    Public Property MovieLockOutline() As Boolean
        Get
            Return _movielockoutline
        End Get
        Set(ByVal value As Boolean)
            _movielockoutline = value
        End Set
    End Property

    Public Property MovieLockPlot() As Boolean
        Get
            Return _movielockplot
        End Get
        Set(ByVal value As Boolean)
            _movielockplot = value
        End Set
    End Property

    Public Property MovieLockRating() As Boolean
        Get
            Return _movielockrating
        End Get
        Set(ByVal value As Boolean)
            _movielockrating = value
        End Set
    End Property

    Public Property MovieLockUserRating() As Boolean
        Get
            Return _movielockuserrating
        End Get
        Set(ByVal value As Boolean)
            _movielockuserrating = value
        End Set
    End Property

    Public Property MovieLockLanguageV() As Boolean
        Get
            Return _movielocklanguagev
        End Get
        Set(ByVal value As Boolean)
            _movielocklanguagev = value
        End Set
    End Property

    Public Property MovieLockLanguageA() As Boolean
        Get
            Return _movielocklanguagea
        End Get
        Set(ByVal value As Boolean)
            _movielocklanguagea = value
        End Set
    End Property

    Public Property MovieLockMPAA() As Boolean
        Get
            Return _movielockmpaa
        End Get
        Set(ByVal value As Boolean)
            _movielockmpaa = value
        End Set
    End Property

    Public Property MovieLockCert() As Boolean
        Get
            Return _movielockcert
        End Get
        Set(ByVal value As Boolean)
            _movielockcert = value
        End Set
    End Property

    Public Property MovieLockReleaseDate() As Boolean
        Get
            Return _movielockreleasedate
        End Get
        Set(ByVal value As Boolean)
            _movielockreleasedate = value
        End Set
    End Property

    Public Property MovieLockRuntime() As Boolean
        Get
            Return _movielockruntime
        End Get
        Set(ByVal value As Boolean)
            _movielockruntime = value
        End Set
    End Property
    Public Property MovieLockTags() As Boolean
        Get
            Return _movielocktags
        End Get
        Set(ByVal value As Boolean)
            _movielocktags = value
        End Set
    End Property

    Public Property MovieLockTop250() As Boolean
        Get
            Return _movielocktop250
        End Get
        Set(ByVal value As Boolean)
            _movielocktop250 = value
        End Set
    End Property

    Public Property MovieLockCredits() As Boolean
        Get
            Return _movielockcredits
        End Get
        Set(ByVal value As Boolean)
            _movielockcredits = value
        End Set
    End Property

    Public Property MovieLockYear() As Boolean
        Get
            Return _movielockyear
        End Get
        Set(ByVal value As Boolean)
            _movielockyear = value
        End Set
    End Property

    Public Property MovieScraperCertFSK() As Boolean
        Get
            Return _moviescrapercertfsk
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercertfsk = value
        End Set
    End Property

    Public Property TVScraperShowCertFSK() As Boolean
        Get
            Return _tvscrapershowcertfsk
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcertfsk = value
        End Set
    End Property
    Public Property MovieLockStudio() As Boolean
        Get
            Return _movielockstudio
        End Get
        Set(ByVal value As Boolean)
            _movielockstudio = value
        End Set
    End Property

    Public Property MovieLockTagline() As Boolean
        Get
            Return _movielocktagline
        End Get
        Set(ByVal value As Boolean)
            _movielocktagline = value
        End Set
    End Property

    Public Property MovieLockTitle() As Boolean
        Get
            Return _movielocktitle
        End Get
        Set(ByVal value As Boolean)
            _movielocktitle = value
        End Set
    End Property
    Public Property MovieLockOriginalTitle() As Boolean
        Get
            Return _movielockoriginaltitle
        End Get
        Set(ByVal value As Boolean)
            _movielockoriginaltitle = value
        End Set
    End Property
    Public Property MovieLockTrailer() As Boolean
        Get
            Return _movielocktrailer
        End Get
        Set(ByVal value As Boolean)
            _movielocktrailer = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker1Color() As Integer
        Get
            Return _moviegeneralcustommarker1color
        End Get
        Set(ByVal value As Integer)
            _moviegeneralcustommarker1color = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker2Color() As Integer
        Get
            Return _moviegeneralcustommarker2color
        End Get
        Set(ByVal value As Integer)
            _moviegeneralcustommarker2color = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker3Color() As Integer
        Get
            Return _moviegeneralcustommarker3color
        End Get
        Set(ByVal value As Integer)
            _moviegeneralcustommarker3color = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker4Color() As Integer
        Get
            Return _moviegeneralcustommarker4color
        End Get
        Set(ByVal value As Integer)
            _moviegeneralcustommarker4color = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker1Name() As String
        Get
            Return _moviegeneralcustommarker1name
        End Get
        Set(ByVal value As String)
            _moviegeneralcustommarker1name = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker2Name() As String
        Get
            Return _moviegeneralcustommarker2name
        End Get
        Set(ByVal value As String)
            _moviegeneralcustommarker2name = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker3Name() As String
        Get
            Return _moviegeneralcustommarker3name
        End Get
        Set(ByVal value As String)
            _moviegeneralcustommarker3name = value
        End Set
    End Property

    Public Property MovieGeneralCustomMarker4Name() As String
        Get
            Return _moviegeneralcustommarker4name
        End Get
        Set(ByVal value As String)
            _moviegeneralcustommarker4name = value
        End Set
    End Property

    Public Property MovieGeneralCustomScrapeButtonEnabled() As Boolean
        Get
            Return _moviegeneralcustomscrapebuttonenabled
        End Get
        Set(ByVal value As Boolean)
            _moviegeneralcustomscrapebuttonenabled = value
        End Set
    End Property

    Public Property MovieGeneralCustomScrapeButtonModifierType() As Enums.ScrapeModifierType
        Get
            Return _moviegeneralcustomscrapebuttonmodifiertype
        End Get
        Set(ByVal value As Enums.ScrapeModifierType)
            _moviegeneralcustomscrapebuttonmodifiertype = value
        End Set
    End Property

    Public Property MovieGeneralCustomScrapeButtonScrapeType() As Enums.ScrapeType
        Get
            Return _moviegeneralcustomscrapebuttonscrapetype
        End Get
        Set(ByVal value As Enums.ScrapeType)
            _moviegeneralcustomscrapebuttonscrapetype = value
        End Set
    End Property

    Public Property MovieSetGeneralCustomScrapeButtonEnabled() As Boolean
        Get
            Return _moviesetgeneralcustomscrapebuttonenabled
        End Get
        Set(ByVal value As Boolean)
            _moviesetgeneralcustomscrapebuttonenabled = value
        End Set
    End Property

    Public Property MovieSetGeneralCustomScrapeButtonModifierType() As Enums.ScrapeModifierType
        Get
            Return _moviesetgeneralcustomscrapebuttonmodifiertype
        End Get
        Set(ByVal value As Enums.ScrapeModifierType)
            _moviesetgeneralcustomscrapebuttonmodifiertype = value
        End Set
    End Property

    Public Property MovieSetGeneralCustomScrapeButtonScrapeType() As Enums.ScrapeType
        Get
            Return _moviesetgeneralcustomscrapebuttonscrapetype
        End Get
        Set(ByVal value As Enums.ScrapeType)
            _moviesetgeneralcustomscrapebuttonscrapetype = value
        End Set
    End Property

    Public Property TVGeneralCustomScrapeButtonEnabled() As Boolean
        Get
            Return _tvgeneralcustomscrapebuttonenabled
        End Get
        Set(ByVal value As Boolean)
            _tvgeneralcustomscrapebuttonenabled = value
        End Set
    End Property

    Public Property TVGeneralCustomScrapeButtonModifierType() As Enums.ScrapeModifierType
        Get
            Return _tvgeneralcustomscrapebuttonmodifiertype
        End Get
        Set(ByVal value As Enums.ScrapeModifierType)
            _tvgeneralcustomscrapebuttonmodifiertype = value
        End Set
    End Property

    Public Property TVGeneralCustomScrapeButtonScrapeType() As Enums.ScrapeType
        Get
            Return _tvgeneralcustomscrapebuttonscrapetype
        End Get
        Set(ByVal value As Enums.ScrapeType)
            _tvgeneralcustomscrapebuttonscrapetype = value
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

    Public Property MovieMissingBanner() As Boolean
        Get
            Return _moviemissingbanner
        End Get
        Set(ByVal value As Boolean)
            _moviemissingbanner = value
        End Set
    End Property

    Public Property MovieMissingClearArt() As Boolean
        Get
            Return _moviemissingclearart
        End Get
        Set(ByVal value As Boolean)
            _moviemissingclearart = value
        End Set
    End Property

    Public Property MovieMissingClearLogo() As Boolean
        Get
            Return _moviemissingclearlogo
        End Get
        Set(ByVal value As Boolean)
            _moviemissingclearlogo = value
        End Set
    End Property

    Public Property MovieMissingDiscArt() As Boolean
        Get
            Return _moviemissingdiscart
        End Get
        Set(ByVal value As Boolean)
            _moviemissingdiscart = value
        End Set
    End Property

    Public Property MovieMissingExtrathumbs() As Boolean
        Get
            Return _moviemissingextrathumbs
        End Get
        Set(ByVal value As Boolean)
            _moviemissingextrathumbs = value
        End Set
    End Property

    Public Property MovieMissingExtrafanarts() As Boolean
        Get
            Return _moviemissingextrafanarts
        End Get
        Set(ByVal value As Boolean)
            _moviemissingextrafanarts = value
        End Set
    End Property

    Public Property MovieMissingFanart() As Boolean
        Get
            Return _moviemissingfanart
        End Get
        Set(ByVal value As Boolean)
            _moviemissingfanart = value
        End Set
    End Property

    Public Property MovieMissingLandscape() As Boolean
        Get
            Return _moviemissinglandscape
        End Get
        Set(ByVal value As Boolean)
            _moviemissinglandscape = value
        End Set
    End Property

    Public Property MovieMissingNFO() As Boolean
        Get
            Return _moviemissingnfo
        End Get
        Set(ByVal value As Boolean)
            _moviemissingnfo = value
        End Set
    End Property

    Public Property MovieMissingPoster() As Boolean
        Get
            Return _moviemissingposter
        End Get
        Set(ByVal value As Boolean)
            _moviemissingposter = value
        End Set
    End Property

    Public Property MovieMissingSubtitles() As Boolean
        Get
            Return _moviemissingsubtitles
        End Get
        Set(ByVal value As Boolean)
            _moviemissingsubtitles = value
        End Set
    End Property

    Public Property MovieMissingTheme() As Boolean
        Get
            Return _moviemissingtheme
        End Get
        Set(ByVal value As Boolean)
            _moviemissingtheme = value
        End Set
    End Property

    Public Property MovieMissingTrailer() As Boolean
        Get
            Return _moviemissingtrailer
        End Get
        Set(ByVal value As Boolean)
            _moviemissingtrailer = value
        End Set
    End Property

    Public Property MovieSetBannerPrefSizeOnly() As Boolean
        Get
            Return _moviesetbannerprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetbannerprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetBannerResize() As Boolean
        Get
            Return _moviesetbannerresize
        End Get
        Set(ByVal value As Boolean)
            _moviesetbannerresize = value
        End Set
    End Property

    Public Property MovieSetFanartPrefSizeOnly() As Boolean
        Get
            Return _moviesetfanartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetfanartprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetFanartResize() As Boolean
        Get
            Return _moviesetfanartresize
        End Get
        Set(ByVal value As Boolean)
            _moviesetfanartresize = value
        End Set
    End Property

    Public Property MovieSetPosterPrefSizeOnly() As Boolean
        Get
            Return _moviesetposterprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetposterprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetPosterResize() As Boolean
        Get
            Return _moviesetposterresize
        End Get
        Set(ByVal value As Boolean)
            _moviesetposterresize = value
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

    Public Property MovieSetLockPlot() As Boolean
        Get
            Return _moviesetlockplot
        End Get
        Set(ByVal value As Boolean)
            _moviesetlockplot = value
        End Set
    End Property

    Public Property MovieSetLockTitle() As Boolean
        Get
            Return _moviesetlocktitle
        End Get
        Set(ByVal value As Boolean)
            _moviesetlocktitle = value
        End Set
    End Property

    Public Property MovieSetScraperPlot() As Boolean
        Get
            Return _moviesetscraperplot
        End Get
        Set(ByVal value As Boolean)
            _moviesetscraperplot = value
        End Set
    End Property

    Public Property MovieSetScraperTitle() As Boolean
        Get
            Return _moviesetscrapertitle
        End Get
        Set(ByVal value As Boolean)
            _moviesetscrapertitle = value
        End Set
    End Property

    Public Property MovieSetMissingBanner() As Boolean
        Get
            Return _moviesetmissingbanner
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingbanner = value
        End Set
    End Property

    Public Property MovieSetMissingClearArt() As Boolean
        Get
            Return _moviesetmissingclearart
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingclearart = value
        End Set
    End Property

    Public Property MovieSetMissingClearLogo() As Boolean
        Get
            Return _moviesetmissingclearlogo
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingclearlogo = value
        End Set
    End Property

    Public Property MovieSetMissingDiscArt() As Boolean
        Get
            Return _moviesetmissingdiscart
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingdiscart = value
        End Set
    End Property

    Public Property MovieSetMissingFanart() As Boolean
        Get
            Return _moviesetmissingfanart
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingfanart = value
        End Set
    End Property

    Public Property MovieSetMissingLandscape() As Boolean
        Get
            Return _moviesetmissinglandscape
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissinglandscape = value
        End Set
    End Property

    Public Property MovieSetMissingNFO() As Boolean
        Get
            Return _moviesetmissingnfo
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingnfo = value
        End Set
    End Property

    Public Property MovieSetMissingPoster() As Boolean
        Get
            Return _moviesetmissingposter
        End Get
        Set(ByVal value As Boolean)
            _moviesetmissingposter = value
        End Set
    End Property

    Public Property GeneralMovieTheme() As String
        Get
            Return _generalmovietheme
        End Get
        Set(ByVal value As String)
            _generalmovietheme = value
        End Set
    End Property

    Public Property GeneralMovieSetTheme() As String
        Get
            Return _generalmoviesettheme
        End Get
        Set(ByVal value As String)
            _generalmoviesettheme = value
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

    Public Property GeneralDoubleClickScrape() As Boolean
        Get
            Return _generaldoubleclickscrape
        End Get
        Set(ByVal value As Boolean)
            _generaldoubleclickscrape = value
        End Set
    End Property

    Public Property MovieTrailerDefaultSearch() As String
        Get
            Return _movietrailerdefaultsearch
        End Get
        Set(ByVal value As String)
            _movietrailerdefaultsearch = value
        End Set
    End Property

    Public Property GeneralDisplayBanner() As Boolean
        Get
            Return _generaldisplaybanner
        End Get
        Set(ByVal value As Boolean)
            _generaldisplaybanner = value
        End Set
    End Property

    Public Property GeneralDisplayCharacterArt() As Boolean
        Get
            Return _generaldisplaycharacterart
        End Get
        Set(ByVal value As Boolean)
            _generaldisplaycharacterart = value
        End Set
    End Property

    Public Property GeneralDisplayClearArt() As Boolean
        Get
            Return _generaldisplayclearart
        End Get
        Set(ByVal value As Boolean)
            _generaldisplayclearart = value
        End Set
    End Property

    Public Property GeneralDisplayClearLogo() As Boolean
        Get
            Return _generaldisplayclearlogo
        End Get
        Set(ByVal value As Boolean)
            _generaldisplayclearlogo = value
        End Set
    End Property

    Public Property GeneralDisplayDiscArt() As Boolean
        Get
            Return _generaldisplaydiscart
        End Get
        Set(ByVal value As Boolean)
            _generaldisplaydiscart = value
        End Set
    End Property

    Public Property GeneralDisplayFanart() As Boolean
        Get
            Return _generaldisplayfanart
        End Get
        Set(ByVal value As Boolean)
            _generaldisplayfanart = value
        End Set
    End Property

    Public Property GeneralDisplayFanartSmall() As Boolean
        Get
            Return _generaldisplayfanartsmall
        End Get
        Set(ByVal value As Boolean)
            _generaldisplayfanartsmall = value
        End Set
    End Property

    Public Property GeneralDisplayLandscape() As Boolean
        Get
            Return _generaldisplaylandscape
        End Get
        Set(ByVal value As Boolean)
            _generaldisplaylandscape = value
        End Set
    End Property

    Public Property GeneralDisplayPoster() As Boolean
        Get
            Return _generaldisplayposter
        End Get
        Set(ByVal value As Boolean)
            _generaldisplayposter = value
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

    Public Property MovieImagesNotSaveURLToNfo() As Boolean
        Get
            Return _movieimagesnotsaveurltonfo
        End Get
        Set(ByVal value As Boolean)
            _movieimagesnotsaveurltonfo = value
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

    Public Property FileSystemNoStackExts() As List(Of String)
        Get
            Return _filesystemnostackexts
        End Get
        Set(ByVal value As List(Of String))
            _filesystemnostackexts = value
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

    Public Property MovieScraperCertOnlyValue() As Boolean
        Get
            Return _moviescrapercertonlyvalue
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercertonlyvalue = value
        End Set
    End Property

    Public Property TVScraperShowCertOnlyValue() As Boolean
        Get
            Return _tvscrapershowcertonlyvalue
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcertonlyvalue = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerKeepExisting() As Boolean
        Get
            Return _tvallseasonsbannerkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsbannerkeepexisting = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartKeepExisting() As Boolean
        Get
            Return _tvallseasonsfanartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsfanartkeepexisting = value
        End Set
    End Property

    Public Property TVAllSeasonsLandscapeKeepExisting() As Boolean
        Get
            Return _tvallseasonslandscapekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonslandscapekeepexisting = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterKeepExisting() As Boolean
        Get
            Return _tvallseasonsposterkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsposterkeepexisting = value
        End Set
    End Property

    Public Property TVEpisodeFanartKeepExisting() As Boolean
        Get
            Return _tvepisodefanartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvepisodefanartkeepexisting = value
        End Set
    End Property

    Public Property TVEpisodePosterKeepExisting() As Boolean
        Get
            Return _tvepisodeposterkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeposterkeepexisting = value
        End Set
    End Property

    Public Property TVShowExtrafanartsKeepExisting() As Boolean
        Get
            Return _tvshowextrafanartskeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowextrafanartskeepexisting = value
        End Set
    End Property

    Public Property MovieExtrafanartsKeepExisting() As Boolean
        Get
            Return _movieextrafanartskeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartskeepexisting = value
        End Set
    End Property

    Public Property MovieExtrathumbsKeepExisting() As Boolean
        Get
            Return _movieextrathumbskeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbskeepexisting = value
        End Set
    End Property

    Public Property MovieFanartKeepExisting() As Boolean
        Get
            Return _moviefanartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviefanartkeepexisting = value
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

    Public Property MoviePosterKeepExisting() As Boolean
        Get
            Return _movieposterkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movieposterkeepexisting = value
        End Set
    End Property

    Public Property TVSeasonBannerKeepExisting() As Boolean
        Get
            Return _tvseasonbannerkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvseasonbannerkeepexisting = value
        End Set
    End Property

    Public Property TVShowCharacterArtKeepExisting() As Boolean
        Get
            Return _tvshowcharacterartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowcharacterartkeepexisting = value
        End Set
    End Property

    Public Property TVShowClearArtKeepExisting() As Boolean
        Get
            Return _tvshowclearartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearartkeepexisting = value
        End Set
    End Property

    Public Property TVShowClearLogoKeepExisting() As Boolean
        Get
            Return _tvshowclearlogokeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearlogokeepexisting = value
        End Set
    End Property

    Public Property TVSeasonLandscapeKeepExisting() As Boolean
        Get
            Return _tvseasonlandscapekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvseasonlandscapekeepexisting = value
        End Set
    End Property

    Public Property TVShowLandscapeKeepExisting() As Boolean
        Get
            Return _tvshowlandscapekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowlandscapekeepexisting = value
        End Set
    End Property

    Public Property TVSeasonFanartKeepExisting() As Boolean
        Get
            Return _tvseasonfanartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvseasonfanartkeepexisting = value
        End Set
    End Property

    Public Property TVSeasonPosterKeepExisting() As Boolean
        Get
            Return _tvseasonposterkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvseasonposterkeepexisting = value
        End Set
    End Property

    Public Property TVShowBannerKeepExisting() As Boolean
        Get
            Return _tvshowbannerkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowbannerkeepexisting = value
        End Set
    End Property

    Public Property TVShowFanartKeepExisting() As Boolean
        Get
            Return _tvshowfanartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowfanartkeepexisting = value
        End Set
    End Property

    Public Property TVShowPosterKeepExisting() As Boolean
        Get
            Return _tvshowposterkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowposterkeepexisting = value
        End Set
    End Property

    Public Property MovieBannerKeepExisting() As Boolean
        Get
            Return _moviebannerkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviebannerkeepexisting = value
        End Set
    End Property

    Public Property MovieDiscArtKeepExisting() As Boolean
        Get
            Return _moviediscartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviediscartkeepexisting = value
        End Set
    End Property

    Public Property MovieLandscapeKeepExisting() As Boolean
        Get
            Return _movielandscapekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movielandscapekeepexisting = value
        End Set
    End Property

    Public Property MovieClearArtKeepExisting() As Boolean
        Get
            Return _movieclearartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movieclearartkeepexisting = value
        End Set
    End Property

    Public Property MovieClearArtPrefSize() As Enums.MovieClearArtSize
        Get
            Return _movieclearartprefsize
        End Get
        Set(ByVal value As Enums.MovieClearArtSize)
            _movieclearartprefsize = value
        End Set
    End Property

    Public Property MovieClearArtPrefSizeOnly() As Boolean
        Get
            Return _movieclearartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _movieclearartprefsizeonly = value
        End Set
    End Property

    Public Property MovieClearLogoKeepExisting() As Boolean
        Get
            Return _movieclearlogokeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movieclearlogokeepexisting = value
        End Set
    End Property

    Public Property MovieClearLogoPrefSize() As Enums.MovieClearLogoSize
        Get
            Return _movieclearlogoprefsize
        End Get
        Set(ByVal value As Enums.MovieClearLogoSize)
            _movieclearlogoprefsize = value
        End Set
    End Property

    Public Property MovieClearLogoPrefSizeOnly() As Boolean
        Get
            Return _movieclearlogoprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _movieclearlogoprefsizeonly = value
        End Set
    End Property

    Public Property MovieDiscArtPrefSize() As Enums.MovieDiscArtSize
        Get
            Return _moviediscartprefsize
        End Get
        Set(ByVal value As Enums.MovieDiscArtSize)
            _moviediscartprefsize = value
        End Set
    End Property

    Public Property MovieDiscArtPrefSizeOnly() As Boolean
        Get
            Return _moviediscartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviediscartprefsizeonly = value
        End Set
    End Property

    Public Property MovieLandscapePrefSize() As Enums.MovieLandscapeSize
        Get
            Return _movielandscapeprefsize
        End Get
        Set(ByVal value As Enums.MovieLandscapeSize)
            _movielandscapeprefsize = value
        End Set
    End Property

    Public Property MovieLandscapePrefSizeOnly() As Boolean
        Get
            Return _movielandscapeprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _movielandscapeprefsizeonly = value
        End Set
    End Property

    Public Property TVShowCharacterArtPrefSize() As Enums.TVCharacterArtSize
        Get
            Return _tvshowcharacterartprefsize
        End Get
        Set(ByVal value As Enums.TVCharacterArtSize)
            _tvshowcharacterartprefsize = value
        End Set
    End Property

    Public Property TVShowCharacterArtPrefSizeOnly() As Boolean
        Get
            Return _tvshowcharacterartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowcharacterartprefsizeonly = value
        End Set
    End Property

    Public Property TVShowClearArtPrefSize() As Enums.TVClearArtSize
        Get
            Return _tvshowclearartprefsize
        End Get
        Set(ByVal value As Enums.TVClearArtSize)
            _tvshowclearartprefsize = value
        End Set
    End Property

    Public Property TVShowClearArtPrefSizeOnly() As Boolean
        Get
            Return _tvshowclearartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearartprefsizeonly = value
        End Set
    End Property

    Public Property TVShowClearLogoPrefSize() As Enums.TVClearLogoSize
        Get
            Return _tvshowclearlogoprefsize
        End Get
        Set(ByVal value As Enums.TVClearLogoSize)
            _tvshowclearlogoprefsize = value
        End Set
    End Property

    Public Property TVShowClearLogoPrefSizeOnly() As Boolean
        Get
            Return _tvshowclearlogoprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowclearlogoprefsizeonly = value
        End Set
    End Property

    Public Property TVShowLandscapePrefSize() As Enums.TVLandscapeSize
        Get
            Return _tvshowlandscapeprefsize
        End Get
        Set(ByVal value As Enums.TVLandscapeSize)
            _tvshowlandscapeprefsize = value
        End Set
    End Property

    Public Property TVShowLandscapePrefSizeOnly() As Boolean
        Get
            Return _tvshowlandscapeprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowlandscapeprefsizeonly = value
        End Set
    End Property

    Public Property TVSeasonLandscapePrefSize() As Enums.TVLandscapeSize
        Get
            Return _tvseasonlandscapeprefsize
        End Get
        Set(ByVal value As Enums.TVLandscapeSize)
            _tvseasonlandscapeprefsize = value
        End Set
    End Property

    Public Property TVSeasonLandscapePrefSizeOnly() As Boolean
        Get
            Return _tvseasonlandscapeprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvseasonlandscapeprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetClearArtPrefSize() As Enums.MovieClearArtSize
        Get
            Return _moviesetclearartprefsize
        End Get
        Set(ByVal value As Enums.MovieClearArtSize)
            _moviesetclearartprefsize = value
        End Set
    End Property

    Public Property MovieSetClearArtPrefSizeOnly() As Boolean
        Get
            Return _moviesetclearartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearartprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetClearLogoPrefSize() As Enums.MovieClearLogoSize
        Get
            Return _moviesetclearlogoprefsize
        End Get
        Set(ByVal value As Enums.MovieClearLogoSize)
            _moviesetclearlogoprefsize = value
        End Set
    End Property

    Public Property MovieSetClearLogoPrefSizeOnly() As Boolean
        Get
            Return _moviesetclearlogoprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearlogoprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetDiscArtPrefSize() As Enums.MovieDiscArtSize
        Get
            Return _moviesetdiscartprefsize
        End Get
        Set(ByVal value As Enums.MovieDiscArtSize)
            _moviesetdiscartprefsize = value
        End Set
    End Property

    Public Property MovieSetDiscArtPrefSizeOnly() As Boolean
        Get
            Return _moviesetdiscartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetdiscartprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetLandscapePrefSize() As Enums.MovieLandscapeSize
        Get
            Return _moviesetlandscapeprefsize
        End Get
        Set(ByVal value As Enums.MovieLandscapeSize)
            _moviesetlandscapeprefsize = value
        End Set
    End Property

    Public Property MovieSetLandscapePrefSizeOnly() As Boolean
        Get
            Return _moviesetlandscapeprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetlandscapeprefsizeonly = value
        End Set
    End Property

    Public Property MovieSetBannerKeepExisting() As Boolean
        Get
            Return _moviesetbannerkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetbannerkeepexisting = value
        End Set
    End Property

    Public Property MovieSetClearArtKeepExisting() As Boolean
        Get
            Return _moviesetclearartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearartkeepexisting = value
        End Set
    End Property

    Public Property MovieSetClearLogoKeepExisting() As Boolean
        Get
            Return _moviesetclearlogokeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetclearlogokeepexisting = value
        End Set
    End Property

    Public Property MovieSetDiscArtKeepExisting() As Boolean
        Get
            Return _moviesetdiscartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetdiscartkeepexisting = value
        End Set
    End Property

    Public Property MovieSetFanartKeepExisting() As Boolean
        Get
            Return _moviesetfanartkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetfanartkeepexisting = value
        End Set
    End Property

    Public Property MovieSetLandscapeKeepExisting() As Boolean
        Get
            Return _moviesetlandscapekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetlandscapekeepexisting = value
        End Set
    End Property

    Public Property MovieSetPosterKeepExisting() As Boolean
        Get
            Return _moviesetposterkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviesetposterkeepexisting = value
        End Set
    End Property

    Public Property MovieBannerPrefSizeOnly() As Boolean
        Get
            Return _moviebannerprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _moviebannerprefsizeonly = value
        End Set
    End Property

    Public Property MovieBannerResize() As Boolean
        Get
            Return _moviebannerresize
        End Get
        Set(ByVal value As Boolean)
            _moviebannerresize = value
        End Set
    End Property

    Public Property MovieTrailerKeepExisting() As Boolean
        Get
            Return _movietrailerkeepexisting
        End Get
        Set(ByVal value As Boolean)
            _movietrailerkeepexisting = value
        End Set
    End Property

    Public Property MovieThemeKeepExisting() As Boolean
        Get
            Return _moviethemekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _moviethemekeepexisting = value
        End Set
    End Property

    Public Property TVShowThemeKeepExisting() As Boolean
        Get
            Return _tvshowthemekeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowthemekeepexisting = value
        End Set
    End Property

    Public Property MovieScraperPlotForOutline() As Boolean
        Get
            Return _moviescraperplotforoutline
        End Get
        Set(ByVal value As Boolean)
            _moviescraperplotforoutline = value
        End Set
    End Property

    Public Property MovieScraperPlotForOutlineIfEmpty() As Boolean
        Get
            Return _moviescraperplotforoutlineifempty
        End Get
        Set(ByVal value As Boolean)
            _moviescraperplotforoutlineifempty = value
        End Set
    End Property

    Public Property MovieScraperOutlineLimit() As Integer
        Get
            Return _moviescraperoutlinelimit
        End Get
        Set(ByVal value As Integer)
            _moviescraperoutlinelimit = value
        End Set
    End Property

    Public Property GeneralImagesGlassOverlay() As Boolean
        Get
            Return _generalimagesglassoverlay
        End Get
        Set(ByVal value As Boolean)
            _generalimagesglassoverlay = value
        End Set
    End Property

    Public Property MoviePosterHeight() As Integer
        Get
            Return _movieposterheight
        End Get
        Set(ByVal value As Integer)
            _movieposterheight = value
        End Set
    End Property

    Public Property MovieSetPosterHeight() As Integer
        Get
            Return _moviesetposterheight
        End Get
        Set(ByVal value As Integer)
            _moviesetposterheight = value
        End Set
    End Property

    Public Property MoviePosterPrefSizeOnly() As Boolean
        Get
            Return _movieposterprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _movieposterprefsizeonly = value
        End Set
    End Property

    Public Property MoviePosterWidth() As Integer
        Get
            Return _movieposterwidth
        End Get
        Set(ByVal value As Integer)
            _movieposterwidth = value
        End Set
    End Property

    Public Property MovieSetPosterWidth() As Integer
        Get
            Return _moviesetposterwidth
        End Get
        Set(ByVal value As Integer)
            _moviesetposterwidth = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterPrefSize() As Enums.TVPosterSize
        Get
            Return _tvallseasonsposterprefsize
        End Get
        Set(ByVal value As Enums.TVPosterSize)
            _tvallseasonsposterprefsize = value
        End Set
    End Property

    Public Property TVEpisodeFanartPrefSize() As Enums.TVFanartSize
        Get
            Return _tvepisodefanartprefsize
        End Get
        Set(ByVal value As Enums.TVFanartSize)
            _tvepisodefanartprefsize = value
        End Set
    End Property

    Public Property MovieFanartPrefSize() As Enums.MovieFanartSize
        Get
            Return _moviefanartprefsize
        End Get
        Set(ByVal value As Enums.MovieFanartSize)
            _moviefanartprefsize = value
        End Set
    End Property

    Public Property MovieSetFanartPrefSize() As Enums.MovieFanartSize
        Get
            Return _moviesetfanartprefsize
        End Get
        Set(ByVal value As Enums.MovieFanartSize)
            _moviesetfanartprefsize = value
        End Set
    End Property

    Public Property MovieExtrafanartsPrefSize() As Enums.MovieFanartSize
        Get
            Return _movieextrafanartsprefsize
        End Get
        Set(ByVal value As Enums.MovieFanartSize)
            _movieextrafanartsprefsize = value
        End Set
    End Property

    Public Property MovieExtrathumbsPrefSize() As Enums.MovieFanartSize
        Get
            Return _movieextrathumbsprefsize
        End Get
        Set(ByVal value As Enums.MovieFanartSize)
            _movieextrathumbsprefsize = value
        End Set
    End Property

    Public Property MoviePosterPrefSize() As Enums.MoviePosterSize
        Get
            Return _movieposterprefsize
        End Get
        Set(ByVal value As Enums.MoviePosterSize)
            _movieposterprefsize = value
        End Set
    End Property

    Public Property MovieSetPosterPrefSize() As Enums.MoviePosterSize
        Get
            Return _moviesetposterprefsize
        End Get
        Set(ByVal value As Enums.MoviePosterSize)
            _moviesetposterprefsize = value
        End Set
    End Property

    Public Property TVSeasonFanartPrefSize() As Enums.TVFanartSize
        Get
            Return _tvseasonfanartprefsize
        End Get
        Set(ByVal value As Enums.TVFanartSize)
            _tvseasonfanartprefsize = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartPrefSize() As Enums.TVFanartSize
        Get
            Return _tvallseasonsfanartprefsize
        End Get
        Set(ByVal value As Enums.TVFanartSize)
            _tvallseasonsfanartprefsize = value
        End Set
    End Property

    Public Property TVAllSeasonsLandscapePrefSize() As Enums.TVLandscapeSize
        Get
            Return _tvallseasonslandscapeprefsize
        End Get
        Set(ByVal value As Enums.TVLandscapeSize)
            _tvallseasonslandscapeprefsize = value
        End Set
    End Property

    Public Property TVAllSeasonsLandscapePrefSizeOnly() As Boolean
        Get
            Return _tvallseasonslandscapeprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonslandscapeprefsizeonly = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerPrefSizeOnly() As Boolean
        Get
            Return _tvallseasonsbannerprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsbannerprefsizeonly = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartPrefSizeOnly() As Boolean
        Get
            Return _tvallseasonsfanartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsfanartprefsizeonly = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterPrefSizeOnly() As Boolean
        Get
            Return _tvallseasonsposterprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsposterprefsizeonly = value
        End Set
    End Property

    Public Property TVEpisodeFanartPrefSizeOnly() As Boolean
        Get
            Return _tvepisodefanartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvepisodefanartprefsizeonly = value
        End Set
    End Property

    Public Property TVEpisodePosterPrefSizeOnly() As Boolean
        Get
            Return _tvepisodeposterprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeposterprefsizeonly = value
        End Set
    End Property

    Public Property TVSeasonBannerPrefSizeOnly() As Boolean
        Get
            Return _tvseasonbannerprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvseasonbannerprefsizeonly = value
        End Set
    End Property

    Public Property TVSeasonFanartPrefSizeOnly() As Boolean
        Get
            Return _tvseasonfanartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvseasonfanartprefsizeonly = value
        End Set
    End Property

    Public Property TVSeasonPosterPrefSizeOnly() As Boolean
        Get
            Return _tvseasonposterprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvseasonposterprefsizeonly = value
        End Set
    End Property

    Public Property TVShowBannerPrefSizeOnly() As Boolean
        Get
            Return _tvshowbannerprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowbannerprefsizeonly = value
        End Set
    End Property

    Public Property TVShowExtrafanartsPrefSizeOnly() As Boolean
        Get
            Return _tvshowextrafanartsprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowextrafanartsprefsizeonly = value
        End Set
    End Property

    Public Property TVShowFanartPrefSizeOnly() As Boolean
        Get
            Return _tvshowfanartprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowfanartprefsizeonly = value
        End Set
    End Property

    Public Property TVShowPosterPrefSizeOnly() As Boolean
        Get
            Return _tvshowposterprefsizeonly
        End Get
        Set(ByVal value As Boolean)
            _tvshowposterprefsizeonly = value
        End Set
    End Property

    Public Property TVEpisodePosterPrefSize() As Enums.TVEpisodePosterSize

        Get
            Return _tvepisodeposterprefsize
        End Get
        Set(ByVal value As Enums.TVEpisodePosterSize)
            _tvepisodeposterprefsize = value
        End Set
    End Property

    Public Property TVSeasonPosterPrefSize() As Enums.TVSeasonPosterSize
        Get
            Return _tvseasonposterprefsize
        End Get
        Set(ByVal value As Enums.TVSeasonPosterSize)
            _tvseasonposterprefsize = value
        End Set
    End Property

    Public Property TVShowBannerPrefSize() As Enums.TVBannerSize
        Get
            Return _tvshowbannerprefsize
        End Get
        Set(ByVal value As Enums.TVBannerSize)
            _tvshowbannerprefsize = value
        End Set
    End Property

    Public Property TVShowBannerPrefType() As Enums.TVBannerType
        Get
            Return _tvshowbannerpreftype
        End Get
        Set(ByVal value As Enums.TVBannerType)
            _tvshowbannerpreftype = value
        End Set
    End Property

    Public Property MovieBannerPrefSize() As Enums.MovieBannerSize
        Get
            Return _moviebannerprefsize
        End Get
        Set(ByVal value As Enums.MovieBannerSize)
            _moviebannerprefsize = value
        End Set
    End Property

    Public Property MovieSetBannerPrefSize() As Enums.MovieBannerSize
        Get
            Return _moviesetbannerprefsize
        End Get
        Set(ByVal value As Enums.MovieBannerSize)
            _moviesetbannerprefsize = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerPrefSize() As Enums.TVBannerSize
        Get
            Return _tvallseasonsbannerprefsize
        End Get
        Set(ByVal value As Enums.TVBannerSize)
            _tvallseasonsbannerprefsize = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerPrefType() As Enums.TVBannerType
        Get
            Return _tvallseasonsbannerpreftype
        End Get
        Set(ByVal value As Enums.TVBannerType)
            _tvallseasonsbannerpreftype = value
        End Set
    End Property

    Public Property TVSeasonBannerPrefSize() As Enums.TVBannerSize
        Get
            Return _tvseasonbannerprefsize
        End Get
        Set(ByVal value As Enums.TVBannerSize)
            _tvseasonbannerprefsize = value
        End Set
    End Property

    Public Property TVSeasonBannerPrefType() As Enums.TVBannerType
        Get
            Return _tvseasonbannerpreftype
        End Get
        Set(ByVal value As Enums.TVBannerType)
            _tvseasonbannerpreftype = value
        End Set
    End Property

    Public Property TVShowExtrafanartsPrefSize() As Enums.TVFanartSize
        Get
            Return _tvshowextrafanartsprefsize
        End Get
        Set(ByVal value As Enums.TVFanartSize)
            _tvshowextrafanartsprefsize = value
        End Set
    End Property

    Public Property TVShowFanartPrefSize() As Enums.TVFanartSize
        Get
            Return _tvshowfanartprefsize
        End Get
        Set(ByVal value As Enums.TVFanartSize)
            _tvshowfanartprefsize = value
        End Set
    End Property

    Public Property TVShowPosterPrefSize() As Enums.TVPosterSize
        Get
            Return _tvshowposterprefsize
        End Get
        Set(ByVal value As Enums.TVPosterSize)
            _tvshowposterprefsize = value
        End Set
    End Property

    Public Property MovieTrailerMinVideoQual() As Enums.TrailerVideoQuality
        Get
            Return _movietrailerminvideoqual
        End Get
        Set(ByVal value As Enums.TrailerVideoQuality)
            _movietrailerminvideoqual = value
        End Set
    End Property

    Public Property MovieTrailerPrefVideoQual() As Enums.TrailerVideoQuality
        Get
            Return _movietrailerprefvideoqual
        End Get
        Set(ByVal value As Enums.TrailerVideoQuality)
            _movietrailerprefvideoqual = value
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

    Public Property ProxyCreds() As NetworkCredential
        Get
            Return _proxycredentials
        End Get
        Set(ByVal value As NetworkCredential)
            _proxycredentials = value
        End Set
    End Property

    Public Property ProxyPort() As Integer
        Get
            Return _proxyport
        End Get
        Set(ByVal value As Integer)
            _proxyport = value
        End Set
    End Property

    Public Property ProxyURI() As String
        Get
            Return _proxyuri
        End Get
        Set(ByVal value As String)
            _proxyuri = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerResize() As Boolean
        Get
            Return _tvallseasonsbannerresize
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsbannerresize = value
        End Set
    End Property

    Public Property TVAllSeasonsPosterResize() As Boolean
        Get
            Return _tvallseasonsposterresize
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsposterresize = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartResize() As Boolean
        Get
            Return _tvallseasonsfanartresize
        End Get
        Set(ByVal value As Boolean)
            _tvallseasonsfanartresize = value
        End Set
    End Property

    Public Property TVEpisodeFanartResize() As Boolean
        Get
            Return _tvepisodefanartresize
        End Get
        Set(ByVal value As Boolean)
            _tvepisodefanartresize = value
        End Set
    End Property

    Public Property TVEpisodePosterResize() As Boolean
        Get
            Return _tvepisodeposterresize
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeposterresize = value
        End Set
    End Property

    Public Property TVShowExtrafanartsResize() As Boolean
        Get
            Return _tvshowextrafanartsresize
        End Get
        Set(ByVal value As Boolean)
            _tvshowextrafanartsresize = value
        End Set
    End Property

    Public Property MovieExtrafanartsResize() As Boolean
        Get
            Return _movieextrafanartsresize
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsresize = value
        End Set
    End Property

    Public Property MovieExtrathumbsResize() As Boolean
        Get
            Return _movieextrathumbsresize
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsresize = value
        End Set
    End Property

    Public Property MovieFanartResize() As Boolean
        Get
            Return _moviefanartresize
        End Get
        Set(ByVal value As Boolean)
            _moviefanartresize = value
        End Set
    End Property

    Public Property MoviePosterResize() As Boolean
        Get
            Return _movieposterresize
        End Get
        Set(ByVal value As Boolean)
            _movieposterresize = value
        End Set
    End Property

    Public Property TVSeasonBannerResize() As Boolean
        Get
            Return _tvseasonbannerresize
        End Get
        Set(ByVal value As Boolean)
            _tvseasonbannerresize = value
        End Set
    End Property

    Public Property TVSeasonFanartResize() As Boolean
        Get
            Return _tvseasonfanartresize
        End Get
        Set(ByVal value As Boolean)
            _tvseasonfanartresize = value
        End Set
    End Property

    Public Property TVSeasonPosterResize() As Boolean
        Get
            Return _tvseasonposterresize
        End Get
        Set(ByVal value As Boolean)
            _tvseasonposterresize = value
        End Set
    End Property

    Public Property TVShowBannerResize() As Boolean
        Get
            Return _tvshowbannerresize
        End Get
        Set(ByVal value As Boolean)
            _tvshowbannerresize = value
        End Set
    End Property

    Public Property TVShowFanartResize() As Boolean
        Get
            Return _tvshowfanartresize
        End Get
        Set(ByVal value As Boolean)
            _tvshowfanartresize = value
        End Set
    End Property

    Public Property TVShowPosterResize() As Boolean
        Get
            Return _tvshowposterresize
        End Get
        Set(ByVal value As Boolean)
            _tvshowposterresize = value
        End Set
    End Property

    Public Property MovieScraperDurationRuntimeFormat() As String
        Get
            Return _moviescraperdurationruntimeformat
        End Get
        Set(ByVal value As String)
            _moviescraperdurationruntimeformat = value
        End Set
    End Property

    Public Property TVScraperDurationRuntimeFormat() As String
        Get
            Return _tvscraperdurationruntimeformat
        End Get
        Set(ByVal value As String)
            _tvscraperdurationruntimeformat = value
        End Set
    End Property

    Public Property MovieScraperMetaDataScan() As Boolean
        Get
            Return _moviescrapermetadatascan
        End Get
        Set(ByVal value As Boolean)
            _moviescrapermetadatascan = value
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

    Public Property TVScraperMetaDataScan() As Boolean
        Get
            Return _tvscrapermetadatascan
        End Get
        Set(ByVal value As Boolean)
            _tvscrapermetadatascan = value
        End Set
    End Property

    Public Property TVScraperEpisodeActors() As Boolean
        Get
            Return _tvscraperepisodeactors
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodeactors = value
        End Set
    End Property

    Public Property TVScraperEpisodeAired() As Boolean
        Get
            Return _tvscraperepisodeaired
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodeaired = value
        End Set
    End Property

    Public Property TVScraperEpisodeCredits() As Boolean
        Get
            Return _tvscraperepisodecredits
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodecredits = value
        End Set
    End Property

    Public Property TVScraperEpisodeDirector() As Boolean
        Get
            Return _tvscraperepisodedirector
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodedirector = value
        End Set
    End Property

    Public Property TVScraperEpisodeGuestStars() As Boolean
        Get
            Return _tvscraperepisodegueststars
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodegueststars = value
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

    Public Property TVScraperEpisodePlot() As Boolean
        Get
            Return _tvscraperepisodeplot
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodeplot = value
        End Set
    End Property

    Public Property TVScraperEpisodeRating() As Boolean
        Get
            Return _tvscraperepisoderating
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisoderating = value
        End Set
    End Property

    Public Property TVScraperEpisodeUserRating() As Boolean
        Get
            Return _tvscraperepisodeuserrating
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodeuserrating = value
        End Set
    End Property

    Public Property TVScraperEpisodeRuntime() As Boolean
        Get
            Return _tvscraperepisoderuntime
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisoderuntime = value
        End Set
    End Property

    Public Property TVScraperEpisodeTitle() As Boolean
        Get
            Return _tvscraperepisodetitle
        End Get
        Set(ByVal value As Boolean)
            _tvscraperepisodetitle = value
        End Set
    End Property

    Public Property TVScraperSeasonAired() As Boolean
        Get
            Return _tvscraperseasonaired
        End Get
        Set(ByVal value As Boolean)
            _tvscraperseasonaired = value
        End Set
    End Property

    Public Property TVScraperSeasonPlot() As Boolean
        Get
            Return _tvscraperseasonplot
        End Get
        Set(ByVal value As Boolean)
            _tvscraperseasonplot = value
        End Set
    End Property

    Public Property TVScraperSeasonTitle() As Boolean
        Get
            Return _tvscraperseasontitle
        End Get
        Set(ByVal value As Boolean)
            _tvscraperseasontitle = value
        End Set
    End Property

    Public Property TVScraperShowActors() As Boolean
        Get
            Return _tvscrapershowactors
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowactors = value
        End Set
    End Property

    Public Property TVScraperShowCreators() As Boolean
        Get
            Return _tvscrapershowcreators
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcreators = value
        End Set
    End Property

    Public Property TVScraperShowCountry() As Boolean
        Get
            Return _tvscrapershowcountry
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcountry = value
        End Set
    End Property

    Public Property TVScraperShowEpiGuideURL() As Boolean
        Get
            Return _tvscrapershowepiguideurl
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowepiguideurl = value
        End Set
    End Property

    Public Property TVScraperShowGenre() As Boolean
        Get
            Return _tvscrapershowgenre
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowgenre = value
        End Set
    End Property

    Public Property TVScraperShowMPAA() As Boolean
        Get
            Return _tvscrapershowmpaa
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowmpaa = value
        End Set
    End Property

    Public Property TVScraperShowOriginalTitle() As Boolean
        Get
            Return _tvscrapershoworiginaltitle
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershoworiginaltitle = value
        End Set
    End Property

    Public Property TVScraperShowCert() As Boolean
        Get
            Return _tvscrapershowcert
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcert = value
        End Set
    End Property

    Public Property TVScraperShowCertLang() As String
        Get
            Return _tvscrapershowcertlang
        End Get
        Set(ByVal value As String)
            _tvscrapershowcertlang = value
        End Set
    End Property

    Public Property TVScraperShowMPAANotRated() As String
        Get
            Return _tvscrapershowmpaanotrated
        End Get
        Set(ByVal value As String)
            _tvscrapershowmpaanotrated = value
        End Set
    End Property

    Public Property TVScraperShowPlot() As Boolean
        Get
            Return _tvscrapershowplot
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowplot = value
        End Set
    End Property

    Public Property TVScraperShowPremiered() As Boolean
        Get
            Return _tvscrapershowpremiered
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowpremiered = value
        End Set
    End Property

    Public Property TVScraperShowRating() As Boolean
        Get
            Return _tvscrapershowrating
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowrating = value
        End Set
    End Property

    Public Property TVScraperShowUserRating() As Boolean
        Get
            Return _tvscrapershowuserrating
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowuserrating = value
        End Set
    End Property

    Public Property TVScraperShowRuntime() As Boolean
        Get
            Return _tvscrapershowruntime
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowruntime = value
        End Set
    End Property

    Public Property TVScraperShowStatus() As Boolean
        Get
            Return _tvscrapershowstatus
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowstatus = value
        End Set
    End Property

    Public Property TVScraperShowStudio() As Boolean
        Get
            Return _tvscrapershowstudio
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowstudio = value
        End Set
    End Property

    Public Property TVScraperShowTitle() As Boolean
        Get
            Return _tvscrapershowtitle
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowtitle = value
        End Set
    End Property

    Public Property TVSeasonFanartHeight() As Integer
        Get
            Return _tvseasonfanartheight
        End Get
        Set(ByVal value As Integer)
            _tvseasonfanartheight = value
        End Set
    End Property

    Public Property TVSeasonFanartWidth() As Integer
        Get
            Return _tvseasonfanartwidth
        End Get
        Set(ByVal value As Integer)
            _tvseasonfanartwidth = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerWidth() As Integer
        Get
            Return _tvallseasonsbannerwidth
        End Get
        Set(ByVal value As Integer)
            _tvallseasonsbannerwidth = value
        End Set
    End Property

    Public Property TVSeasonBannerWidth() As Integer
        Get
            Return _tvseasonbannerwidth
        End Get
        Set(ByVal value As Integer)
            _tvseasonbannerwidth = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartWidth() As Integer
        Get
            Return _tvallseasonsfanartwidth
        End Get
        Set(ByVal value As Integer)
            _tvallseasonsfanartwidth = value
        End Set
    End Property

    Public Property TVShowBannerWidth() As Integer
        Get
            Return _tvshowbannerwidth
        End Get
        Set(ByVal value As Integer)
            _tvshowbannerwidth = value
        End Set
    End Property

    Public Property MovieBannerWidth() As Integer
        Get
            Return _moviebannerwidth
        End Get
        Set(ByVal value As Integer)
            _moviebannerwidth = value
        End Set
    End Property

    Public Property MovieSetBannerWidth() As Integer
        Get
            Return _moviesetbannerwidth
        End Get
        Set(ByVal value As Integer)
            _moviesetbannerwidth = value
        End Set
    End Property

    Public Property TVAllSeasonsBannerHeight() As Integer
        Get
            Return _tvallseasonsbannerheight
        End Get
        Set(ByVal value As Integer)
            _tvallseasonsbannerheight = value
        End Set
    End Property

    Public Property TVSeasonBannerHeight() As Integer
        Get
            Return _tvseasonbannerheight
        End Get
        Set(ByVal value As Integer)
            _tvseasonbannerheight = value
        End Set
    End Property

    Public Property TVAllSeasonsFanartHeight() As Integer
        Get
            Return _tvallseasonsfanartheight
        End Get
        Set(ByVal value As Integer)
            _tvallseasonsfanartheight = value
        End Set
    End Property

    Public Property TVShowActorThumbsKeepExisting() As Boolean
        Get
            Return _tvshowactorthumbskeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvshowactorthumbskeepexisting = value
        End Set
    End Property

    Public Property TVShowBannerHeight() As Integer
        Get
            Return _tvshowbannerheight
        End Get
        Set(ByVal value As Integer)
            _tvshowbannerheight = value
        End Set
    End Property

    Public Property MovieBannerHeight() As Integer
        Get
            Return _moviebannerheight
        End Get
        Set(ByVal value As Integer)
            _moviebannerheight = value
        End Set
    End Property

    Public Property MovieSetBannerHeight() As Integer
        Get
            Return _moviesetbannerheight
        End Get
        Set(ByVal value As Integer)
            _moviesetbannerheight = value
        End Set
    End Property

    Public Property TVSeasonPosterHeight() As Integer
        Get
            Return _tvseasonposterheight
        End Get
        Set(ByVal value As Integer)
            _tvseasonposterheight = value
        End Set
    End Property

    Public Property TVSeasonPosterWidth() As Integer
        Get
            Return _tvseasonposterwidth
        End Get
        Set(ByVal value As Integer)
            _tvseasonposterwidth = value
        End Set
    End Property

    Public Property GeneralShowLangFlags() As Boolean
        Get
            Return _generalshowlangflags
        End Get
        Set(ByVal value As Boolean)
            _generalshowlangflags = value
        End Set
    End Property

    Public Property GeneralShowImgDims() As Boolean
        Get
            Return _generalshowimgdims
        End Get
        Set(ByVal value As Boolean)
            _generalshowimgdims = value
        End Set
    End Property

    Public Property GeneralShowImgNames() As Boolean
        Get
            Return _generalshowimgnames
        End Get
        Set(ByVal value As Boolean)
            _generalshowimgnames = value
        End Set
    End Property

    Public Property TVShowFanartHeight() As Integer
        Get
            Return _tvshowfanartheight
        End Get
        Set(ByVal value As Integer)
            _tvshowfanartheight = value
        End Set
    End Property

    Public Property TVShowFanartWidth() As Integer
        Get
            Return _tvshowfanartwidth
        End Get
        Set(ByVal value As Integer)
            _tvshowfanartwidth = value
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

    Public Property GeneralInfoPanelStateTVShow() As Integer
        Get
            Return _generalinfopanelstatetvshow
        End Get
        Set(ByVal value As Integer)
            _generalinfopanelstatetvshow = value
        End Set
    End Property

    Public Property TVLockShowGenre() As Boolean
        Get
            Return _tvlockshowgenre
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowgenre = value
        End Set
    End Property

    Public Property TVLockShowOriginalTitle() As Boolean
        Get
            Return _tvlockshoworiginaltitle
        End Get
        Set(ByVal value As Boolean)
            _tvlockshoworiginaltitle = value
        End Set
    End Property

    Public Property TVLockShowPlot() As Boolean
        Get
            Return _tvlockshowplot
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowplot = value
        End Set
    End Property

    Public Property TVLockSeasonPlot() As Boolean
        Get
            Return _tvlockseasonplot
        End Get
        Set(ByVal value As Boolean)
            _tvlockseasonplot = value
        End Set
    End Property

    Public Property TVLockSeasonTitle() As Boolean
        Get
            Return _tvlockseasontitle
        End Get
        Set(ByVal value As Boolean)
            _tvlockseasontitle = value
        End Set
    End Property

    Public Property TVLockShowRating() As Boolean
        Get
            Return _tvlockshowrating
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowrating = value
        End Set
    End Property

    Public Property TVLockShowUserRating() As Boolean
        Get
            Return _tvlockshowuserrating
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowuserrating = value
        End Set
    End Property

    Public Property TVLockShowRuntime() As Boolean
        Get
            Return _tvlockshowruntime
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowruntime = value
        End Set
    End Property

    Public Property TVLockShowStatus() As Boolean
        Get
            Return _tvlockshowstatus
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowstatus = value
        End Set
    End Property

    Public Property TVLockShowStudio() As Boolean
        Get
            Return _tvlockshowstudio
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowstudio = value
        End Set
    End Property

    Public Property TVLockShowTitle() As Boolean
        Get
            Return _tvlockshowtitle
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowtitle = value
        End Set
    End Property

    Public Property TVLockShowMPAA() As Boolean
        Get
            Return _tvlockshowmpaa
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowmpaa = value
        End Set
    End Property

    Public Property TVLockShowPremiered() As Boolean
        Get
            Return _tvlockshowpremiered
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowpremiered = value
        End Set
    End Property

    Public Property TVLockShowActors() As Boolean
        Get
            Return _tvlockshowactors
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowactors = value
        End Set
    End Property

    Public Property TVLockShowCountry() As Boolean
        Get
            Return _tvlockshowcountry
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowcountry = value
        End Set
    End Property

    Public Property TVLockShowCert() As Boolean
        Get
            Return _tvlockshowcert
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowcert = value
        End Set
    End Property

    Public Property TVLockShowCreators() As Boolean
        Get
            Return _tvlockshowcreators
        End Get
        Set(ByVal value As Boolean)
            _tvlockshowcreators = value
        End Set
    End Property

    Public Property TVShowPosterHeight() As Integer
        Get
            Return _tvshowposterheight
        End Get
        Set(ByVal value As Integer)
            _tvshowposterheight = value
        End Set
    End Property

    Public Property TVShowPosterWidth() As Integer
        Get
            Return _tvshowposterwidth
        End Get
        Set(ByVal value As Integer)
            _tvshowposterwidth = value
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

    Public Property GeneralSplitterDistanceMain() As Integer
        Get
            Return _generalsplitterdistancemain
        End Get
        Set(ByVal value As Integer)
            _generalsplitterdistancemain = value
        End Set
    End Property

    Public Property GeneralSplitterDistanceTVShow() As Integer
        Get
            Return _generalsplitterdistancetvshow
        End Get
        Set(ByVal value As Integer)
            _generalsplitterdistancetvshow = value
        End Set
    End Property

    Public Property GeneralSplitterDistanceTVSeason() As Integer
        Get
            Return _generalsplitterdistancetvseason
        End Get
        Set(ByVal value As Integer)
            _generalsplitterdistancetvseason = value
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

    Public Property GeneralMainFilterSortColumn_Movies() As Integer
        Get
            Return _generalmainfiltersortcolumn_movies
        End Get
        Set(ByVal value As Integer)
            _generalmainfiltersortcolumn_movies = value
        End Set
    End Property

    Public Property GeneralMainFilterSortColumn_MovieSets() As Integer
        Get
            Return _generalmainfiltersortcolumn_moviesets
        End Get
        Set(ByVal value As Integer)
            _generalmainfiltersortcolumn_moviesets = value
        End Set
    End Property

    Public Property GeneralMainFilterSortColumn_Shows() As Integer
        Get
            Return _generalmainfiltersortcolumn_shows
        End Get
        Set(ByVal value As Integer)
            _generalmainfiltersortcolumn_shows = value
        End Set
    End Property

    Public Property GeneralMainFilterSortOrder_Movies() As Integer
        Get
            Return _generalmainfiltersortorder_movies
        End Get
        Set(ByVal value As Integer)
            _generalmainfiltersortorder_movies = value
        End Set
    End Property

    Public Property GeneralMainFilterSortOrder_MovieSets() As Integer
        Get
            Return _generalmainfiltersortorder_moviesets
        End Get
        Set(ByVal value As Integer)
            _generalmainfiltersortorder_moviesets = value
        End Set
    End Property

    Public Property GeneralMainFilterSortOrder_Shows() As Integer
        Get
            Return _generalmainfiltersortorder_shows
        End Get
        Set(ByVal value As Integer)
            _generalmainfiltersortorder_shows = value
        End Set
    End Property

    Public Property GeneralTVEpisodeTheme() As String
        Get
            Return _generaltvepisodetheme
        End Get
        Set(ByVal value As String)
            _generaltvepisodetheme = value
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

    Public Property MovieGeneralMediaListSorting() As List(Of ListSorting)
        Get
            Return _moviegeneralmedialistsorting
        End Get
        Set(ByVal value As List(Of ListSorting))
            _moviegeneralmedialistsorting = value
        End Set
    End Property

    Public Property MovieSetGeneralMediaListSorting() As List(Of ListSorting)
        Get
            Return _moviesetgeneralmedialistsorting
        End Get
        Set(ByVal value As List(Of ListSorting))
            _moviesetgeneralmedialistsorting = value
        End Set
    End Property

    Public Property TVGeneralEpisodeListSorting() As List(Of ListSorting)
        Get
            Return _tvgeneralepisodelistsorting
        End Get
        Set(ByVal value As List(Of ListSorting))
            _tvgeneralepisodelistsorting = value
        End Set
    End Property

    Public Property TVGeneralSeasonListSorting() As List(Of ListSorting)
        Get
            Return _tvgeneralseasonlistsorting
        End Get
        Set(ByVal value As List(Of ListSorting))
            _tvgeneralseasonlistsorting = value
        End Set
    End Property

    Public Property TVGeneralShowListSorting() As List(Of ListSorting)
        Get
            Return _tvgeneralshowlistsorting
        End Get
        Set(ByVal value As List(Of ListSorting))
            _tvgeneralshowlistsorting = value
        End Set
    End Property

    Public Property GeneralTVShowTheme() As String
        Get
            Return _generaltvshowtheme
        End Get
        Set(ByVal value As String)
            _generaltvshowtheme = value
        End Set
    End Property

    Public Property MovieScraperCertForMPAA() As Boolean
        Get
            Return _moviescrapercertformpaa
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercertformpaa = value
        End Set
    End Property

    Public Property TVScraperShowCertForMPAA() As Boolean
        Get
            Return _tvscrapershowcertformpaa
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcertformpaa = value
        End Set
    End Property

    Public Property MovieScraperCertForMPAAFallback() As Boolean
        Get
            Return _moviescrapercertformpaafallback
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercertformpaafallback = value
        End Set
    End Property

    Public Property TVScraperShowCertForMPAAFallback() As Boolean
        Get
            Return _tvscrapershowcertformpaafallback
        End Get
        Set(ByVal value As Boolean)
            _tvscrapershowcertformpaafallback = value
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

    Public Property MovieScraperUseMDDuration() As Boolean
        Get
            Return _moviescraperusemdduration
        End Get
        Set(ByVal value As Boolean)
            _moviescraperusemdduration = value
        End Set
    End Property

    Public Property TVScraperUseMDDuration() As Boolean
        Get
            Return _tvscraperusemdduration
        End Get
        Set(ByVal value As Boolean)
            _tvscraperusemdduration = value
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

    Public Property FileSystemValidExts() As List(Of String)
        Get
            Return _filesystemvalidexts
        End Get
        Set(ByVal value As List(Of String))
            _filesystemvalidexts = value
        End Set
    End Property

    Public Property FileSystemValidSubtitlesExts() As List(Of String)
        Get
            Return _filesystemvalidsubtitlesexts
        End Get
        Set(ByVal value As List(Of String))
            _filesystemvalidsubtitlesexts = value
        End Set
    End Property

    Public Property FileSystemValidThemeExts() As List(Of String)
        Get
            Return _filesystemvalidthemeexts
        End Get
        Set(ByVal value As List(Of String))
            _filesystemvalidthemeexts = value
        End Set
    End Property

    Public Property GeneralWindowLoc() As Point
        Get
            Return _generalwindowloc
        End Get
        Set(ByVal value As Point)
            _generalwindowloc = value
        End Set
    End Property

    Public Property GeneralWindowSize() As Size
        Get
            Return _generalwindowsize
        End Get
        Set(ByVal value As Size)
            _generalwindowsize = value
        End Set
    End Property

    Public Property GeneralWindowState() As FormWindowState
        Get
            Return _generalwindowstate
        End Get
        Set(ByVal value As FormWindowState)
            _generalwindowstate = value
        End Set
    End Property

    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
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

    Public Property MovieUseAD() As Boolean
        Get
            Return _movieusead
        End Get
        Set(ByVal value As Boolean)
            _movieusead = value
        End Set
    End Property

    Public Property MovieUseExtended() As Boolean
        Get
            Return _movieuseextended
        End Get
        Set(ByVal value As Boolean)
            _movieuseextended = value
        End Set
    End Property

    Public Property MovieUseFrodo() As Boolean
        Get
            Return _movieusefrodo
        End Get
        Set(ByVal value As Boolean)
            _movieusefrodo = value
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

    Public Property MovieSetBannerExpertParent() As String
        Get
            Return _moviesetbannerexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetbannerexpertparent = value
        End Set
    End Property

    Public Property MovieSetClearArtExpertParent() As String
        Get
            Return _moviesetclearartexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetclearartexpertparent = value
        End Set
    End Property

    Public Property MovieSetClearLogoExpertParent() As String
        Get
            Return _moviesetclearlogoexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetclearlogoexpertparent = value
        End Set
    End Property

    Public Property MovieSetDiscArtExpertParent() As String
        Get
            Return _moviesetdiscartexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetdiscartexpertparent = value
        End Set
    End Property

    Public Property MovieSetFanartExpertParent() As String
        Get
            Return _moviesetfanartexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetfanartexpertparent = value
        End Set
    End Property

    Public Property MovieSetLandscapeExpertParent() As String
        Get
            Return _moviesetlandscapeexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetlandscapeexpertparent = value
        End Set
    End Property

    Public Property MovieSetNFOExpertParent() As String
        Get
            Return _moviesetnfoexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetnfoexpertparent = value
        End Set
    End Property

    Public Property MovieSetPosterExpertParent() As String
        Get
            Return _moviesetposterexpertparent
        End Get
        Set(ByVal value As String)
            _moviesetposterexpertparent = value
        End Set
    End Property

    Public Property MovieActorThumbsFrodo() As Boolean
        Get
            Return _movieactorthumbsfrodo
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsfrodo = value
        End Set
    End Property

    Public Property MovieBannerAD() As Boolean
        Get
            Return _moviebannerad
        End Get
        Set(ByVal value As Boolean)
            _moviebannerad = value
        End Set
    End Property

    Public Property MovieBannerExtended() As Boolean
        Get
            Return _moviebannerextended
        End Get
        Set(ByVal value As Boolean)
            _moviebannerextended = value
        End Set
    End Property

    Public Property MovieClearArtAD() As Boolean
        Get
            Return _movieclearartad
        End Get
        Set(ByVal value As Boolean)
            _movieclearartad = value
        End Set
    End Property

    Public Property MovieClearArtExtended() As Boolean
        Get
            Return _movieclearartextended
        End Get
        Set(ByVal value As Boolean)
            _movieclearartextended = value
        End Set
    End Property

    Public Property MovieClearLogoAD() As Boolean
        Get
            Return _movieclearlogoad
        End Get
        Set(ByVal value As Boolean)
            _movieclearlogoad = value
        End Set
    End Property

    Public Property MovieClearLogoExtended() As Boolean
        Get
            Return _movieclearlogoextended
        End Get
        Set(ByVal value As Boolean)
            _movieclearlogoextended = value
        End Set
    End Property

    Public Property MovieDiscArtAD() As Boolean
        Get
            Return _moviediscartad
        End Get
        Set(ByVal value As Boolean)
            _moviediscartad = value
        End Set
    End Property

    Public Property MovieDiscArtExtended() As Boolean
        Get
            Return _moviediscartextended
        End Get
        Set(ByVal value As Boolean)
            _moviediscartextended = value
        End Set
    End Property

    Public Property MovieExtrafanartsFrodo() As Boolean
        Get
            Return _movieextrafanartsfrodo
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsfrodo = value
        End Set
    End Property

    Public Property MovieExtrathumbsFrodo() As Boolean
        Get
            Return _movieextrathumbsfrodo
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsfrodo = value
        End Set
    End Property

    Public Property MovieFanartFrodo() As Boolean
        Get
            Return _moviefanartfrodo
        End Get
        Set(ByVal value As Boolean)
            _moviefanartfrodo = value
        End Set
    End Property

    Public Property MovieLandscapeAD() As Boolean
        Get
            Return _movielandscapead
        End Get
        Set(ByVal value As Boolean)
            _movielandscapead = value
        End Set
    End Property

    Public Property MovieLandscapeExtended() As Boolean
        Get
            Return _movielandscapeextended
        End Get
        Set(ByVal value As Boolean)
            _movielandscapeextended = value
        End Set
    End Property

    Public Property MovieNFOFrodo() As Boolean
        Get
            Return _movienfofrodo
        End Get
        Set(ByVal value As Boolean)
            _movienfofrodo = value
        End Set
    End Property

    Public Property MoviePosterFrodo() As Boolean
        Get
            Return _movieposterfrodo
        End Get
        Set(ByVal value As Boolean)
            _movieposterfrodo = value
        End Set
    End Property

    Public Property MovieTrailerFrodo() As Boolean
        Get
            Return _movietrailerfrodo
        End Get
        Set(ByVal value As Boolean)
            _movietrailerfrodo = value
        End Set
    End Property

    Public Property MovieUseEden() As Boolean
        Get
            Return _movieuseeden
        End Get
        Set(ByVal value As Boolean)
            _movieuseeden = value
        End Set
    End Property

    Public Property MovieActorThumbsEden() As Boolean
        Get
            Return _movieactorthumbseden
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbseden = value
        End Set
    End Property

    Public Property MovieExtrafanartsEden() As Boolean
        Get
            Return _movieextrafanartseden
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartseden = value
        End Set
    End Property

    Public Property MovieExtrathumbsEden() As Boolean
        Get
            Return _movieextrathumbseden
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbseden = value
        End Set
    End Property

    Public Property MovieFanartEden() As Boolean
        Get
            Return _moviefanarteden
        End Get
        Set(ByVal value As Boolean)
            _moviefanarteden = value
        End Set
    End Property

    Public Property MovieNFOEden() As Boolean
        Get
            Return _movienfoeden
        End Get
        Set(ByVal value As Boolean)
            _movienfoeden = value
        End Set
    End Property

    Public Property MoviePosterEden() As Boolean
        Get
            Return _moviepostereden
        End Get
        Set(ByVal value As Boolean)
            _moviepostereden = value
        End Set
    End Property

    Public Property MovieTrailerEden() As Boolean
        Get
            Return _movietrailereden
        End Get
        Set(ByVal value As Boolean)
            _movietrailereden = value
        End Set
    End Property

    Public Property MovieThemeTvTunesEnable() As Boolean
        Get
            Return _moviethemetvtunesenable
        End Get
        Set(ByVal value As Boolean)
            _moviethemetvtunesenable = value
        End Set
    End Property

    Public Property MovieThemeTvTunesCustom() As Boolean
        Get
            Return _moviethemetvtunescustom
        End Get
        Set(ByVal value As Boolean)
            _moviethemetvtunescustom = value
        End Set
    End Property

    Public Property MovieThemeTvTunesCustomPath() As String
        Get
            Return _moviethemetvtunescustompath
        End Get
        Set(ByVal value As String)
            _moviethemetvtunescustompath = value
        End Set
    End Property

    Public Property MovieThemeTvTunesMoviePath() As Boolean
        Get
            Return _moviethemetvtunesmoviepath
        End Get
        Set(ByVal value As Boolean)
            _moviethemetvtunesmoviepath = value
        End Set
    End Property

    Public Property MovieThemeTvTunesSub() As Boolean
        Get
            Return _moviethemetvtunessub
        End Get
        Set(ByVal value As Boolean)
            _moviethemetvtunessub = value
        End Set
    End Property

    Public Property MovieThemeTvTunesSubDir() As String
        Get
            Return _moviethemetvtunessubdir
        End Get
        Set(ByVal value As String)
            _moviethemetvtunessubdir = value
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

    Public Property MovieScraperXBMCTrailerFormat() As Boolean
        Get
            Return _moviescraperxbmctrailerformat
        End Get
        Set(ByVal value As Boolean)
            _moviescraperxbmctrailerformat = value
        End Set
    End Property

    Public Property MovieXBMCProtectVTSBDMV() As Boolean
        Get
            Return _moviexbmcprotectvtsbdmv
        End Get
        Set(ByVal value As Boolean)
            _moviexbmcprotectvtsbdmv = value
        End Set
    End Property

    Public Property MovieUseYAMJ() As Boolean
        Get
            Return _movieuseyamj
        End Get
        Set(ByVal value As Boolean)
            _movieuseyamj = value
        End Set
    End Property

    Public Property MovieBannerYAMJ() As Boolean
        Get
            Return _moviebanneryamj
        End Get
        Set(ByVal value As Boolean)
            _moviebanneryamj = value
        End Set
    End Property

    Public Property MovieFanartYAMJ() As Boolean
        Get
            Return _moviefanartyamj
        End Get
        Set(ByVal value As Boolean)
            _moviefanartyamj = value
        End Set
    End Property

    Public Property MovieNFOYAMJ() As Boolean
        Get
            Return _movienfoyamj
        End Get
        Set(ByVal value As Boolean)
            _movienfoyamj = value
        End Set
    End Property

    Public Property MoviePosterYAMJ() As Boolean
        Get
            Return _movieposteryamj
        End Get
        Set(ByVal value As Boolean)
            _movieposteryamj = value
        End Set
    End Property

    Public Property MovieTrailerYAMJ() As Boolean
        Get
            Return _movietraileryamj
        End Get
        Set(ByVal value As Boolean)
            _movietraileryamj = value
        End Set
    End Property

    Public Property MovieScraperCollectionsYAMJCompatibleSets() As Boolean
        Get
            Return _moviescrapercollectionsyamjcompatiblesets
        End Get
        Set(ByVal value As Boolean)
            _moviescrapercollectionsyamjcompatiblesets = value
        End Set
    End Property

    Public Property MovieYAMJWatchedFile() As Boolean
        Get
            Return _movieyamjwatchedfile
        End Get
        Set(ByVal value As Boolean)
            _movieyamjwatchedfile = value
        End Set
    End Property

    Public Property MovieYAMJWatchedFolder() As String
        Get
            Return _movieyamjwatchedfolder
        End Get
        Set(ByVal value As String)
            _movieyamjwatchedfolder = value
        End Set
    End Property

    Public Property MovieUseNMJ() As Boolean
        Get
            Return _movieusenmj
        End Get
        Set(ByVal value As Boolean)
            _movieusenmj = value
        End Set
    End Property

    Public Property MovieBannerNMJ() As Boolean
        Get
            Return _moviebannernmj
        End Get
        Set(ByVal value As Boolean)
            _moviebannernmj = value
        End Set
    End Property

    Public Property MovieFanartNMJ() As Boolean
        Get
            Return _moviefanartnmj
        End Get
        Set(ByVal value As Boolean)
            _moviefanartnmj = value
        End Set
    End Property

    Public Property MovieNFONMJ() As Boolean
        Get
            Return _movienfonmj
        End Get
        Set(ByVal value As Boolean)
            _movienfonmj = value
        End Set
    End Property

    Public Property MoviePosterNMJ() As Boolean
        Get
            Return _movieposternmj
        End Get
        Set(ByVal value As Boolean)
            _movieposternmj = value
        End Set
    End Property

    Public Property MovieTrailerNMJ() As Boolean
        Get
            Return _movietrailernmj
        End Get
        Set(ByVal value As Boolean)
            _movietrailernmj = value
        End Set
    End Property

    Public Property MovieUseBoxee() As Boolean
        Get
            Return _movieuseboxee
        End Get
        Set(ByVal value As Boolean)
            _movieuseboxee = value
        End Set
    End Property

    Public Property MovieFanartBoxee() As Boolean
        Get
            Return _moviefanartboxee
        End Get
        Set(ByVal value As Boolean)
            _moviefanartboxee = value
        End Set
    End Property

    Public Property MovieNFOBoxee() As Boolean
        Get
            Return _movienfoboxee
        End Get
        Set(ByVal value As Boolean)
            _movienfoboxee = value
        End Set
    End Property

    Public Property MoviePosterBoxee() As Boolean
        Get
            Return _movieposterboxee
        End Get
        Set(ByVal value As Boolean)
            _movieposterboxee = value
        End Set
    End Property

    Public Property MovieUseExpert() As Boolean
        Get
            Return _movieuseexpert
        End Get
        Set(ByVal value As Boolean)
            _movieuseexpert = value
        End Set
    End Property

    Public Property MovieActorThumbsExpertSingle() As Boolean
        Get
            Return _movieactorthumbsexpertsingle
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsexpertsingle = value
        End Set
    End Property

    Public Property MovieActorThumbsExtExpertSingle() As String
        Get
            Return _movieactorthumbsextexpertsingle
        End Get
        Set(ByVal value As String)
            _movieactorthumbsextexpertsingle = value
        End Set
    End Property

    Public Property MovieBannerExpertSingle() As String
        Get
            Return _moviebannerexpertsingle
        End Get
        Set(ByVal value As String)
            _moviebannerexpertsingle = value
        End Set
    End Property

    Public Property MovieClearArtExpertSingle() As String
        Get
            Return _movieclearartexpertsingle
        End Get
        Set(ByVal value As String)
            _movieclearartexpertsingle = value
        End Set
    End Property

    Public Property MovieClearLogoExpertSingle() As String
        Get
            Return _movieclearlogoexpertsingle
        End Get
        Set(ByVal value As String)
            _movieclearlogoexpertsingle = value
        End Set
    End Property

    Public Property MovieDiscArtExpertSingle() As String
        Get
            Return _moviediscartexpertsingle
        End Get
        Set(ByVal value As String)
            _moviediscartexpertsingle = value
        End Set
    End Property

    Public Property MovieExtrafanartsExpertSingle() As Boolean
        Get
            Return _movieextrafanartsexpertsingle
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsexpertsingle = value
        End Set
    End Property

    Public Property MovieExtrathumbsExpertSingle() As Boolean
        Get
            Return _movieextrathumbsexpertsingle
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsexpertsingle = value
        End Set
    End Property

    Public Property MovieFanartExpertSingle() As String
        Get
            Return _moviefanartexpertsingle
        End Get
        Set(ByVal value As String)
            _moviefanartexpertsingle = value
        End Set
    End Property

    Public Property MovieLandscapeExpertSingle() As String
        Get
            Return _movielandscapeexpertsingle
        End Get
        Set(ByVal value As String)
            _movielandscapeexpertsingle = value
        End Set
    End Property

    Public Property MovieNFOExpertSingle() As String
        Get
            Return _movienfoexpertsingle
        End Get
        Set(ByVal value As String)
            _movienfoexpertsingle = value
        End Set
    End Property

    Public Property MoviePosterExpertSingle() As String
        Get
            Return _movieposterexpertsingle
        End Get
        Set(ByVal value As String)
            _movieposterexpertsingle = value
        End Set
    End Property

    Public Property MovieStackExpertSingle() As Boolean
        Get
            Return _moviestackexpertsingle
        End Get
        Set(ByVal value As Boolean)
            _moviestackexpertsingle = value
        End Set
    End Property

    Public Property MovieTrailerExpertSingle() As String
        Get
            Return _movietrailerexpertsingle
        End Get
        Set(ByVal value As String)
            _movietrailerexpertsingle = value
        End Set
    End Property

    Public Property MovieUnstackExpertSingle() As Boolean
        Get
            Return _movieunstackexpertsingle
        End Get
        Set(ByVal value As Boolean)
            _movieunstackexpertsingle = value
        End Set
    End Property

    Public Property MovieActorThumbsExpertMulti() As Boolean
        Get
            Return _movieactorthumbsexpertmulti
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsexpertmulti = value
        End Set
    End Property

    Public Property MovieActorThumbsExtExpertMulti() As String
        Get
            Return _movieactorthumbsextexpertmulti
        End Get
        Set(ByVal value As String)
            _movieactorthumbsextexpertmulti = value
        End Set
    End Property

    Public Property MovieBannerExpertMulti() As String
        Get
            Return _moviebannerexpertmulti
        End Get
        Set(ByVal value As String)
            _moviebannerexpertmulti = value
        End Set
    End Property

    Public Property MovieClearArtExpertMulti() As String
        Get
            Return _movieclearartexpertmulti
        End Get
        Set(ByVal value As String)
            _movieclearartexpertmulti = value
        End Set
    End Property

    Public Property MovieClearLogoExpertMulti() As String
        Get
            Return _movieclearlogoexpertmulti
        End Get
        Set(ByVal value As String)
            _movieclearlogoexpertmulti = value
        End Set
    End Property

    Public Property MovieDiscArtExpertMulti() As String
        Get
            Return _moviediscartexpertmulti
        End Get
        Set(ByVal value As String)
            _moviediscartexpertmulti = value
        End Set
    End Property

    Public Property MovieFanartExpertMulti() As String
        Get
            Return _moviefanartexpertmulti
        End Get
        Set(ByVal value As String)
            _moviefanartexpertmulti = value
        End Set
    End Property

    Public Property MovieImagesGetBlankImages() As Boolean
        Get
            Return _movieimagesgetblankimages
        End Get
        Set(ByVal value As Boolean)
            _movieimagesgetblankimages = value
        End Set
    End Property

    Public Property MovieImagesGetEnglishImages() As Boolean
        Get
            Return _movieimagesgetenglishimages
        End Get
        Set(ByVal value As Boolean)
            _movieimagesgetenglishimages = value
        End Set
    End Property

    Public Property MovieImagesForcedLanguage() As String
        Get
            Return _movieimagesforcedlanguage
        End Get
        Set(ByVal value As String)
            _movieimagesforcedlanguage = value
        End Set
    End Property

    Public Property MovieImagesForceLanguage() As Boolean
        Get
            Return _movieimagesforcelanguage
        End Get
        Set(ByVal value As Boolean)
            _movieimagesforcelanguage = value
        End Set
    End Property

    Public Property MovieSetImagesForcedLanguage() As String
        Get
            Return _moviesetimagesforcedlanguage
        End Get
        Set(ByVal value As String)
            _moviesetimagesforcedlanguage = value
        End Set
    End Property

    Public Property MovieSetImagesForceLanguage() As Boolean
        Get
            Return _moviesetimagesforcelanguage
        End Get
        Set(ByVal value As Boolean)
            _moviesetimagesforcelanguage = value
        End Set
    End Property

    Public Property MovieImagesMediaLanguageOnly() As Boolean
        Get
            Return _movieimagesmedialanguageonly
        End Get
        Set(ByVal value As Boolean)
            _movieimagesmedialanguageonly = value
        End Set
    End Property

    Public Property MovieSetImagesGetBlankImages() As Boolean
        Get
            Return _moviesetimagesgetblankimages
        End Get
        Set(ByVal value As Boolean)
            _moviesetimagesgetblankimages = value
        End Set
    End Property

    Public Property MovieSetImagesGetEnglishImages() As Boolean
        Get
            Return _moviesetimagesgetenglishimages
        End Get
        Set(ByVal value As Boolean)
            _moviesetimagesgetenglishimages = value
        End Set
    End Property

    Public Property MovieSetImagesMediaLanguageOnly() As Boolean
        Get
            Return _moviesetimagesmedialanguageonly
        End Get
        Set(ByVal value As Boolean)
            _moviesetimagesmedialanguageonly = value
        End Set
    End Property

    Public Property TVImagesGetBlankImages() As Boolean
        Get
            Return _tvimagesgetblankimages
        End Get
        Set(ByVal value As Boolean)
            _tvimagesgetblankimages = value
        End Set
    End Property

    Public Property TVImagesGetEnglishImages() As Boolean
        Get
            Return _tvimagesgetenglishimages
        End Get
        Set(ByVal value As Boolean)
            _tvimagesgetenglishimages = value
        End Set
    End Property

    Public Property TVImagesForcedLanguage() As String
        Get
            Return _tvimagesforcedlanguage
        End Get
        Set(ByVal value As String)
            _tvimagesforcedlanguage = value
        End Set
    End Property

    Public Property TVImagesForceLanguage() As Boolean
        Get
            Return _tvimagesforcelanguage
        End Get
        Set(ByVal value As Boolean)
            _tvimagesforcelanguage = value
        End Set
    End Property

    Public Property TVImagesMediaLanguageOnly() As Boolean
        Get
            Return _tvimagesmedialanguageonly
        End Get
        Set(ByVal value As Boolean)
            _tvimagesmedialanguageonly = value
        End Set
    End Property

    Public Property MovieLandscapeExpertMulti() As String
        Get
            Return _movielandscapeexpertmulti
        End Get
        Set(ByVal value As String)
            _movielandscapeexpertmulti = value
        End Set
    End Property

    Public Property MovieNFOExpertMulti() As String
        Get
            Return _movienfoexpertmulti
        End Get
        Set(ByVal value As String)
            _movienfoexpertmulti = value
        End Set
    End Property

    Public Property MoviePosterExpertMulti() As String
        Get
            Return _movieposterexpertmulti
        End Get
        Set(ByVal value As String)
            _movieposterexpertmulti = value
        End Set
    End Property

    Public Property MovieStackExpertMulti() As Boolean
        Get
            Return _moviestackexpertmulti
        End Get
        Set(ByVal value As Boolean)
            _moviestackexpertmulti = value
        End Set
    End Property

    Public Property MovieTrailerExpertMulti() As String
        Get
            Return _movietrailerexpertmulti
        End Get
        Set(ByVal value As String)
            _movietrailerexpertmulti = value
        End Set
    End Property

    Public Property MovieUnstackExpertMulti() As Boolean
        Get
            Return _movieunstackexpertmulti
        End Get
        Set(ByVal value As Boolean)
            _movieunstackexpertmulti = value
        End Set
    End Property

    Public Property MovieActorThumbsExpertVTS() As Boolean
        Get
            Return _movieactorthumbsexpertvts
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsexpertvts = value
        End Set
    End Property

    Public Property MovieActorThumbsExtExpertVTS() As String
        Get
            Return _movieactorthumbsextexpertvts
        End Get
        Set(ByVal value As String)
            _movieactorthumbsextexpertvts = value
        End Set
    End Property

    Public Property MovieBannerExpertVTS() As String
        Get
            Return _moviebannerexpertvts
        End Get
        Set(ByVal value As String)
            _moviebannerexpertvts = value
        End Set
    End Property

    Public Property MovieClearArtExpertVTS() As String
        Get
            Return _movieclearartexpertvts
        End Get
        Set(ByVal value As String)
            _movieclearartexpertvts = value
        End Set
    End Property

    Public Property MovieClearLogoExpertVTS() As String
        Get
            Return _movieclearlogoexpertvts
        End Get
        Set(ByVal value As String)
            _movieclearlogoexpertvts = value
        End Set
    End Property

    Public Property MovieDiscArtExpertVTS() As String
        Get
            Return _moviediscartexpertvts
        End Get
        Set(ByVal value As String)
            _moviediscartexpertvts = value
        End Set
    End Property

    Public Property MovieExtrafanartsExpertVTS() As Boolean
        Get
            Return _movieextrafanartsexpertvts
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsexpertvts = value
        End Set
    End Property

    Public Property MovieExtrathumbsExpertVTS() As Boolean
        Get
            Return _movieextrathumbsexpertvts
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsexpertvts = value
        End Set
    End Property

    Public Property MovieFanartExpertVTS() As String
        Get
            Return _moviefanartexpertvts
        End Get
        Set(ByVal value As String)
            _moviefanartexpertvts = value
        End Set
    End Property

    Public Property MovieLandscapeExpertVTS() As String
        Get
            Return _movielandscapeexpertvts
        End Get
        Set(ByVal value As String)
            _movielandscapeexpertvts = value
        End Set
    End Property

    Public Property MovieNFOExpertVTS() As String
        Get
            Return _movienfoexpertvts
        End Get
        Set(ByVal value As String)
            _movienfoexpertvts = value
        End Set
    End Property

    Public Property MoviePosterExpertVTS() As String
        Get
            Return _movieposterexpertvts
        End Get
        Set(ByVal value As String)
            _movieposterexpertvts = value
        End Set
    End Property

    Public Property MovieRecognizeVTSExpertVTS() As Boolean
        Get
            Return _movierecognizevtsexpertvts
        End Get
        Set(ByVal value As Boolean)
            _movierecognizevtsexpertvts = value
        End Set
    End Property

    Public Property MovieTrailerExpertVTS() As String
        Get
            Return _movietrailerexpertvts
        End Get
        Set(ByVal value As String)
            _movietrailerexpertvts = value
        End Set
    End Property

    Public Property MovieUseBaseDirectoryExpertVTS() As Boolean
        Get
            Return _movieusebasedirectoryexpertvts
        End Get
        Set(ByVal value As Boolean)
            _movieusebasedirectoryexpertvts = value
        End Set
    End Property

    Public Property MovieActorThumbsExpertBDMV() As Boolean
        Get
            Return _movieactorthumbsexpertbdmv
        End Get
        Set(ByVal value As Boolean)
            _movieactorthumbsexpertbdmv = value
        End Set
    End Property

    Public Property MovieActorThumbsExtExpertBDMV() As String
        Get
            Return _movieactorthumbsextexpertbdmv
        End Get
        Set(ByVal value As String)
            _movieactorthumbsextexpertbdmv = value
        End Set
    End Property

    Public Property MovieBannerExpertBDMV() As String
        Get
            Return _moviebannerexpertbdmv
        End Get
        Set(ByVal value As String)
            _moviebannerexpertbdmv = value
        End Set
    End Property

    Public Property MovieClearArtExpertBDMV() As String
        Get
            Return _movieclearartexpertbdmv
        End Get
        Set(ByVal value As String)
            _movieclearartexpertbdmv = value
        End Set
    End Property

    Public Property MovieClearLogoExpertBDMV() As String
        Get
            Return _movieclearlogoexpertbdmv
        End Get
        Set(ByVal value As String)
            _movieclearlogoexpertbdmv = value
        End Set
    End Property

    Public Property MovieDiscArtExpertBDMV() As String
        Get
            Return _moviediscartexpertbdmv
        End Get
        Set(ByVal value As String)
            _moviediscartexpertbdmv = value
        End Set
    End Property

    Public Property MovieExtrafanartsExpertBDMV() As Boolean
        Get
            Return _movieextrafanartsexpertbdmv
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartsexpertbdmv = value
        End Set
    End Property

    Public Property MovieExtrathumbsExpertBDMV() As Boolean
        Get
            Return _movieextrathumbsexpertbdmv
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbsexpertbdmv = value
        End Set
    End Property

    Public Property MovieFanartExpertBDMV() As String
        Get
            Return _moviefanartexpertbdmv
        End Get
        Set(ByVal value As String)
            _moviefanartexpertbdmv = value
        End Set
    End Property

    Public Property MovieLandscapeExpertBDMV() As String
        Get
            Return _movielandscapeexpertbdmv
        End Get
        Set(ByVal value As String)
            _movielandscapeexpertbdmv = value
        End Set
    End Property

    Public Property MovieNFOExpertBDMV() As String
        Get
            Return _movienfoexpertbdmv
        End Get
        Set(ByVal value As String)
            _movienfoexpertbdmv = value
        End Set
    End Property

    Public Property MoviePosterExpertBDMV() As String
        Get
            Return _movieposterexpertbdmv
        End Get
        Set(ByVal value As String)
            _movieposterexpertbdmv = value
        End Set
    End Property

    Public Property MovieTrailerExpertBDMV() As String
        Get
            Return _movietrailerexpertbdmv
        End Get
        Set(ByVal value As String)
            _movietrailerexpertbdmv = value
        End Set
    End Property

    Public Property MovieUseBaseDirectoryExpertBDMV() As Boolean
        Get
            Return _movieusebasedirectoryexpertbdmv
        End Get
        Set(ByVal value As Boolean)
            _movieusebasedirectoryexpertbdmv = value
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

    Public Property TVEpisodeActorThumbsKeepExisting() As Boolean
        Get
            Return _tvepisodeactorthumbskeepexisting
        End Get
        Set(ByVal value As Boolean)
            _tvepisodeactorthumbskeepexisting = value
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

    Public Property TVShowMissingBanner() As Boolean
        Get
            Return _tvshowmissingbanner
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingbanner = value
        End Set
    End Property

    Public Property TVSeasonMissingBanner() As Boolean
        Get
            Return _tvseasonmissingbanner
        End Get
        Set(ByVal value As Boolean)
            _tvseasonmissingbanner = value
        End Set
    End Property

    Public Property TVShowMissingCharacterArt() As Boolean
        Get
            Return _tvshowmissingclearart
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingclearart = value
        End Set
    End Property

    Public Property TVShowMissingClearArt() As Boolean
        Get
            Return _tvshowmissingclearart
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingclearart = value
        End Set
    End Property

    Public Property TVShowMissingClearLogo() As Boolean
        Get
            Return _tvshowmissingclearlogo
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingclearlogo = value
        End Set
    End Property

    Public Property TVShowMissingExtrafanarts() As Boolean
        Get
            Return _tvshowmissingextrafanarts
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingextrafanarts = value
        End Set
    End Property

    Public Property TVShowMissingFanart() As Boolean
        Get
            Return _tvshowmissingfanart
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingfanart = value
        End Set
    End Property

    Public Property TVSeasonMissingFanart() As Boolean
        Get
            Return _tvseasonmissingfanart
        End Get
        Set(ByVal value As Boolean)
            _tvseasonmissingfanart = value
        End Set
    End Property

    Public Property TVEpisodeMissingFanart() As Boolean
        Get
            Return _tvepisodemissingfanart
        End Get
        Set(ByVal value As Boolean)
            _tvepisodemissingfanart = value
        End Set
    End Property

    Public Property TVShowMissingLandscape() As Boolean
        Get
            Return _tvshowmissinglandscape
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissinglandscape = value
        End Set
    End Property

    Public Property TVSeasonMissingLandscape() As Boolean
        Get
            Return _tvseasonmissinglandscape
        End Get
        Set(ByVal value As Boolean)
            _tvseasonmissinglandscape = value
        End Set
    End Property

    Public Property TVShowMissingNFO() As Boolean
        Get
            Return _tvshowmissingnfo
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingnfo = value
        End Set
    End Property

    Public Property TVEpisodeMissingNFO() As Boolean
        Get
            Return _tvepisodemissingnfo
        End Get
        Set(ByVal value As Boolean)
            _tvepisodemissingnfo = value
        End Set
    End Property

    Public Property TVShowMissingPoster() As Boolean
        Get
            Return _tvshowmissingposter
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingposter = value
        End Set
    End Property

    Public Property TVSeasonMissingPoster() As Boolean
        Get
            Return _tvseasonmissingposter
        End Get
        Set(ByVal value As Boolean)
            _tvseasonmissingposter = value
        End Set
    End Property

    Public Property TVEpisodeMissingPoster() As Boolean
        Get
            Return _tvepisodemissingposter
        End Get
        Set(ByVal value As Boolean)
            _tvepisodemissingposter = value
        End Set
    End Property

    Public Property TVShowMissingTheme() As Boolean
        Get
            Return _tvshowmissingtheme
        End Get
        Set(ByVal value As Boolean)
            _tvshowmissingtheme = value
        End Set
    End Property

    Public Property MovieExtrafanartsPreselect() As Boolean
        Get
            Return _movieextrafanartspreselect
        End Get
        Set(ByVal value As Boolean)
            _movieextrafanartspreselect = value
        End Set
    End Property

    Public Property MovieExtrathumbsPreselect() As Boolean
        Get
            Return _movieextrathumbspreselect
        End Get
        Set(ByVal value As Boolean)
            _movieextrathumbspreselect = value
        End Set
    End Property

    Public Property TVShowExtrafanartsPreselect() As Boolean
        Get
            Return _tvshowextrafanartspreselect
        End Get
        Set(ByVal value As Boolean)
            _tvshowextrafanartspreselect = value
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

        ' Fix added to avoid to have no movie NFO saved
        If Not (Master.eSettings.MovieUseBoxee Or Master.eSettings.MovieUseEden Or Master.eSettings.MovieUseExpert Or Master.eSettings.MovieUseFrodo Or Master.eSettings.MovieUseNMJ Or Master.eSettings.MovieUseYAMJ) Then
            Master.eSettings.MovieUseFrodo = True
            Master.eSettings.MovieActorThumbsFrodo = True
            Master.eSettings.MovieExtrafanartsFrodo = True
            Master.eSettings.MovieExtrathumbsFrodo = True
            Master.eSettings.MovieFanartFrodo = True
            Master.eSettings.MovieNFOFrodo = True
            Master.eSettings.MoviePosterFrodo = True
            Master.eSettings.MovieThemeTvTunesEnable = True
            Master.eSettings.MovieThemeTvTunesMoviePath = True
            Master.eSettings.MovieTrailerFrodo = True
            Master.eSettings.MovieScraperXBMCTrailerFormat = True
        End If

        ' Fix added to avoid to have no tv show NFO saved
        If Not (Master.eSettings.TVUseBoxee OrElse Master.eSettings.TVUseEden OrElse Master.eSettings.TVUseExpert OrElse Master.eSettings.TVUseFrodo OrElse Master.eSettings.TVUseYAMJ) Then
            Master.eSettings.TVUseFrodo = True
            Master.eSettings.TVEpisodeActorThumbsFrodo = True
            Master.eSettings.TVEpisodeNFOFrodo = True
            Master.eSettings.TVEpisodePosterFrodo = True
            Master.eSettings.TVSeasonBannerFrodo = True
            Master.eSettings.TVSeasonFanartFrodo = True
            Master.eSettings.TVSeasonPosterFrodo = True
            Master.eSettings.TVShowActorThumbsFrodo = True
            Master.eSettings.TVShowBannerFrodo = True
            Master.eSettings.TVShowExtrafanartsFrodo = True
            Master.eSettings.TVShowFanartFrodo = True
            Master.eSettings.TVShowNFOFrodo = True
            Master.eSettings.TVShowPosterFrodo = True
        End If
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
        CleanDotFanartJPG = False
        CleanExtrathumbs = False
        CleanFanartJPG = False
        CleanFolderJPG = False
        CleanMovieJPG = False
        CleanMovieNFO = False
        CleanMovieNFOB = False
        CleanMovieTBN = False
        CleanMovieTBNB = False
        CleanMovieFanartJPG = False
        CleanMovieNameJPG = False
        CleanPosterJPG = False
        CleanPosterTBN = False
        Addons = New List(Of AddonsManager._XMLAddonClass)
        FileSystemCleanerWhitelist = False
        FileSystemCleanerWhitelistExts = New List(Of String)
        FileSystemExpertCleaner = False
        FileSystemNoStackExts = New List(Of String)
        FileSystemValidExts = New List(Of String)
        FileSystemValidSubtitlesExts = New List(Of String)
        FileSystemValidThemeExts = New List(Of String)
        GeneralCheckUpdates = False
        GeneralDaemonDrive = String.Empty
        GeneralDaemonPath = String.Empty
        GeneralDateAddedIgnoreNFO = False
        GeneralDateTime = Enums.DateTime.Now
        GeneralDigitGrpSymbolVotes = False
        GeneralDisplayBanner = True
        GeneralDisplayCharacterArt = True
        GeneralDisplayClearArt = True
        GeneralDisplayClearLogo = True
        GeneralDisplayDiscArt = True
        GeneralDisplayFanart = True
        GeneralDisplayFanartSmall = True
        GeneralDisplayLandscape = True
        GeneralDisplayPoster = True
        GeneralDoubleClickScrape = False
        GeneralFilterPanelIsRaisedMovie = False
        GeneralFilterPanelIsRaisedMovieSet = False
        GeneralFilterPanelIsRaisedTVShow = False
        GeneralImageFilter = True
        GeneralImageFilterAutoscraper = True
        GeneralImageFilterFanart = True
        GeneralImageFilterFanartMatchTolerance = 4
        GeneralImageFilterImagedialog = False
        GeneralImageFilterPoster = False
        GeneralImageFilterPosterMatchTolerance = 1
        GeneralImagesGlassOverlay = False
        GeneralInfoPanelStateMovie = 200
        GeneralInfoPanelStateMovieSet = 200
        GeneralInfoPanelStateTVShow = 200
        GeneralLanguage = "English_(en_US)"
        GeneralMainFilterSortColumn_MovieSets = 1
        GeneralMainFilterSortColumn_Movies = 3
        GeneralMainFilterSortColumn_Shows = 1
        GeneralMainFilterSortOrder_MovieSets = 0
        GeneralMainFilterSortOrder_Movies = 0
        GeneralMainFilterSortOrder_Shows = 0
        GeneralMovieSetTheme = "Default"
        GeneralMovieTheme = "Default"
        GeneralOverwriteNfo = False
        GeneralShowGenresText = True
        GeneralShowImgDims = True
        GeneralShowImgNames = True
        GeneralShowLangFlags = True
        GeneralSourceFromFolder = False
        GeneralSplitterDistanceMain = 550
        GeneralSplitterDistanceTVSeason = 200
        GeneralSplitterDistanceTVShow = 200
        GeneralTVEpisodeTheme = "Default"
        GeneralTVShowTheme = "Default"
        GeneralWindowLoc = New Point(10, 10)
        GeneralWindowSize = New Size(1024, 768)
        GeneralWindowState = FormWindowState.Maximized
        MovieActorThumbsExtExpertBDMV = ".jpg"
        MovieActorThumbsExtExpertMulti = ".jpg"
        MovieActorThumbsExtExpertSingle = ".jpg"
        MovieActorThumbsExtExpertVTS = ".jpg"
        MovieActorThumbsKeepExisting = False
        MovieBackdropsAuto = False
        MovieBackdropsPath = String.Empty
        MovieBannerHeight = 0
        MovieBannerKeepExisting = False
        MovieBannerPrefSizeOnly = False
        MovieBannerPrefSize = Enums.MovieBannerSize.Any
        MovieBannerResize = False
        MovieBannerWidth = 0
        MovieCleanDB = False
        MovieClearArtKeepExisting = False
        MovieClearArtPrefSize = Enums.MovieClearArtSize.Any
        MovieClearArtPrefSizeOnly = False
        MovieClearLogoKeepExisting = False
        MovieClearLogoPrefSize = Enums.MovieClearLogoSize.Any
        MovieClearLogoPrefSizeOnly = False
        MovieClickScrape = False
        MovieClickScrapeAsk = False
        MovieDiscArtKeepExisting = False
        MovieDiscArtPrefSize = Enums.MovieDiscArtSize.Any
        MovieDiscArtPrefSizeOnly = False
        MovieDisplayYear = False
        MovieExtrafanartsHeight = 0
        MovieExtrafanartsLimit = 4
        MovieExtrafanartsKeepExisting = False
        MovieExtrafanartsPrefSizeOnly = False
        MovieExtrafanartsPrefSize = Enums.MovieFanartSize.Any
        MovieExtrafanartsPreselect = True
        MovieExtrafanartsResize = False
        MovieExtrafanartsWidth = 0
        MovieExtrathumbsCreatorAutoThumbs = False
        MovieExtrathumbsCreatorNoBlackBars = False
        MovieExtrathumbsCreatorNoSpoilers = False
        MovieExtrathumbsCreatorUseETasFA = False
        MovieExtrathumbsHeight = 0
        MovieExtrathumbsLimit = 4
        MovieExtrathumbsKeepExisting = False
        MovieExtrathumbsPrefSizeOnly = False
        MovieExtrathumbsPrefSize = 0
        MovieExtrathumbsPreselect = True
        MovieExtrathumbsResize = False
        MovieExtrathumbsWidth = 0
        MovieFanartHeight = 0
        MovieFanartKeepExisting = False
        MovieFanartPrefSizeOnly = False
        MovieFanartPrefSize = Enums.MovieFanartSize.Any
        MovieFanartResize = False
        MovieFanartWidth = 0
        MovieFilterCustom = New List(Of String)
        MovieFilterCustomIsEmpty = False
        MovieGeneralCustomMarker1Color = -32704
        MovieGeneralCustomMarker2Color = -16776961
        MovieGeneralCustomMarker3Color = -12582784
        MovieGeneralCustomMarker4Color = -16711681
        MovieGeneralCustomMarker1Name = String.Empty
        MovieGeneralCustomMarker2Name = String.Empty
        MovieGeneralCustomMarker3Name = String.Empty
        MovieGeneralCustomMarker4Name = String.Empty
        MovieGeneralCustomScrapeButtonEnabled = False
        MovieGeneralCustomScrapeButtonModifierType = Enums.ScrapeModifierType.All
        MovieGeneralCustomScrapeButtonScrapeType = Enums.ScrapeType.NewSkip
        MovieGeneralFlagLang = String.Empty
        MovieGeneralIgnoreLastScan = True
        MovieGeneralLanguage = "en-US"
        MovieGeneralMarkNew = False
        MovieGeneralMediaListSorting = New List(Of ListSorting)
        MovieImagesCacheEnabled = False
        MovieImagesDisplayImageSelect = True
        MovieImagesForcedLanguage = "en"
        MovieImagesForceLanguage = False
        MovieImagesGetBlankImages = False
        MovieImagesGetEnglishImages = False
        MovieImagesMediaLanguageOnly = False
        MovieImagesNotSaveURLToNfo = False
        MovieIMDBURL = String.Empty
        MovieLandscapeKeepExisting = False
        MovieLandscapePrefSize = Enums.MovieLandscapeSize.Any
        MovieLandscapePrefSizeOnly = False
        MovieLevTolerance = 0
        MovieLockActors = False
        MovieLockCert = False
        MovieLockCollectionID = False
        MovieLockCollections = False
        MovieLockCountry = False
        MovieLockDirector = False
        MovieLockGenre = False
        MovieLockLanguageA = False
        MovieLockLanguageV = False
        MovieLockMPAA = False
        MovieLockOriginalTitle = False
        MovieLockOutline = False
        MovieLockPlot = False
        MovieLockRating = False
        MovieLockReleaseDate = False
        MovieLockRuntime = False
        MovieLockStudio = False
        MovieLockTags = False
        MovieLockTagline = False
        MovieLockTitle = False
        MovieLockTop250 = False
        MovieLockTrailer = False
        MovieLockUserRating = False
        MovieLockCredits = False
        MovieLockYear = False
        MovieMetadataPerFileType = New List(Of MetadataPerType)
        MovieMissingBanner = False
        MovieMissingClearArt = False
        MovieMissingClearLogo = False
        MovieMissingDiscArt = False
        MovieMissingExtrafanarts = False
        MovieMissingExtrathumbs = False
        MovieMissingFanart = False
        MovieMissingLandscape = False
        MovieMissingNFO = False
        MovieMissingPoster = False
        MovieMissingSubtitles = False
        MovieMissingTheme = False
        MovieMissingTrailer = False
        MoviePosterHeight = 0
        MoviePosterKeepExisting = False
        MoviePosterPrefSizeOnly = False
        MoviePosterPrefSize = Enums.MoviePosterSize.Any
        MoviePosterResize = False
        MoviePosterWidth = 0
        MovieProperCase = True
        MovieScanOrderModify = False
        MovieScraperCast = True
        MovieScraperCastLimit = 0
        MovieScraperCastWithImgOnly = False
        MovieScraperCertForMPAA = False
        MovieScraperCertForMPAAFallback = False
        MovieScraperCert = False
        MovieScraperCertLang = String.Empty
        MovieScraperCleanFields = False
        MovieScraperCleanPlotOutline = False
        MovieScraperCollectionID = True
        MovieScraperCollectionsAuto = True
        MovieScraperCollectionsExtendedInfo = False
        MovieScraperCollectionsYAMJCompatibleSets = False
        MovieScraperCountry = True
        MovieScraperDirector = True
        MovieScraperDurationRuntimeFormat = "<m>"
        MovieScraperGenre = True
        MovieScraperGenreLimit = 0
        MovieScraperMetaDataIFOScan = True
        MovieScraperMetaDataScan = True
        MovieScraperMPAA = True
        MovieScraperMPAANotRated = String.Empty
        MovieScraperOriginalTitle = True
        MovieScraperCertOnlyValue = False
        MovieScraperOutline = True
        MovieScraperOutlineLimit = 350
        MovieScraperPlot = True
        MovieScraperPlotForOutline = False
        MovieScraperPlotForOutlineIfEmpty = False
        MovieScraperRating = True
        MovieScraperRelease = True
        MovieScraperRuntime = True
        MovieScraperStudio = True
        MovieScraperStudioLimit = 0
        MovieScraperStudioWithImgOnly = False
        MovieScraperTagline = True
        MovieScraperTitle = True
        MovieScraperTop250 = True
        MovieScraperTrailer = True
        MovieScraperUseDetailView = False
        MovieScraperUseMDDuration = True
        MovieScraperUserRating = True
        MovieScraperCertFSK = False
        MovieScraperCredits = True
        MovieScraperXBMCTrailerFormat = False
        MovieScraperYear = True
        MovieSetBannerHeight = 0
        MovieSetBannerKeepExisting = False
        MovieSetBannerPrefSizeOnly = False
        MovieSetBannerPrefSize = Enums.MovieBannerSize.Any
        MovieSetBannerResize = False
        MovieSetBannerWidth = 0
        MovieSetCleanDB = False
        MovieSetCleanFiles = False
        MovieSetClearArtKeepExisting = False
        MovieSetClearArtPrefSize = Enums.MovieClearArtSize.Any
        MovieSetClearArtPrefSizeOnly = False
        MovieSetClearLogoKeepExisting = False
        MovieSetClearLogoPrefSize = Enums.MovieClearLogoSize.Any
        MovieSetClearLogoPrefSizeOnly = False
        MovieSetClickScrape = False
        MovieSetClickScrapeAsk = False
        MovieSetDiscArtKeepExisting = False
        MovieSetDiscArtPrefSize = Enums.MovieDiscArtSize.Any
        MovieSetDiscArtPrefSizeOnly = False
        MovieSetFanartHeight = 0
        MovieSetFanartKeepExisting = False
        MovieSetFanartPrefSizeOnly = False
        MovieSetFanartPrefSize = Enums.MovieFanartSize.Any
        MovieSetFanartResize = False
        MovieSetFanartWidth = 0
        MovieSetGeneralCustomScrapeButtonEnabled = False
        MovieSetGeneralCustomScrapeButtonModifierType = Enums.ScrapeModifierType.All
        MovieSetGeneralCustomScrapeButtonScrapeType = Enums.ScrapeType.NewSkip
        MovieSetGeneralMarkNew = False
        MovieSetGeneralMediaListSorting = New List(Of ListSorting)
        MovieSetImagesCacheEnabled = False
        MovieSetImagesDisplayImageSelect = True
        MovieSetImagesForcedLanguage = "en"
        MovieSetImagesForceLanguage = False
        MovieSetImagesGetBlankImages = False
        MovieSetImagesGetEnglishImages = False
        MovieSetImagesMediaLanguageOnly = False
        MovieSetLandscapeKeepExisting = False
        MovieSetLandscapePrefSize = Enums.MovieLandscapeSize.Any
        MovieSetLandscapePrefSizeOnly = False
        MovieSetLockPlot = False
        MovieSetLockTitle = False
        MovieSetMissingBanner = False
        MovieSetMissingClearArt = False
        MovieSetMissingClearLogo = False
        MovieSetMissingDiscArt = False
        MovieSetMissingFanart = False
        MovieSetMissingLandscape = False
        MovieSetMissingNFO = False
        MovieSetMissingPoster = False
        MovieSetPosterHeight = 0
        MovieSetPosterKeepExisting = False
        MovieSetPosterPrefSizeOnly = False
        MovieSetPosterPrefSize = Enums.MoviePosterSize.Any
        MovieSetPosterResize = False
        MovieSetPosterWidth = 0
        MovieSetScraperPlot = True
        MovieSetScraperTitle = True
        MovieSkipLessThan = 0
        MovieSkipStackedSizeCheck = False
        MovieSortBeforeScan = False
        MovieSortTokens = New List(Of String)
        MovieSetSortTokens = New List(Of String)
        MovieSortTokensIsEmpty = False
        MovieSetSortTokensIsEmpty = False
        MovieThemeTvTunesEnable = True
        MovieThemeKeepExisting = False
        MovieTrailerDefaultSearch = "trailer"
        MovieTrailerKeepExisting = False
        MovieTrailerMinVideoQual = Enums.TrailerVideoQuality.Any
        MovieTrailerPrefVideoQual = Enums.TrailerVideoQuality.Any
        OMMDummyFormat = 0
        OMMDummyTagline = String.Empty
        OMMDummyTop = String.Empty
        OMMDummyUseBackground = True
        OMMDummyUseFanart = True
        OMMDummyUseOverlay = True
        OMMMediaStubTagline = String.Empty
        Password = String.Empty
        ProxyCredentials = New NetworkCredential
        ProxyPort = 0
        ProxyURI = String.Empty
        SortPath = String.Empty
        TVAllSeasonsBannerHeight = 0
        TVAllSeasonsBannerKeepExisting = False
        TVAllSeasonsBannerPrefSize = Enums.TVBannerSize.Any
        TVAllSeasonsBannerPrefSizeOnly = False
        TVAllSeasonsBannerPrefType = Enums.TVBannerType.Any
        TVAllSeasonsBannerResize = False
        TVAllSeasonsBannerWidth = 0
        TVAllSeasonsFanartHeight = 0
        TVAllSeasonsFanartKeepExisting = False
        TVAllSeasonsFanartPrefSize = Enums.TVFanartSize.Any
        TVAllSeasonsFanartPrefSizeOnly = False
        TVAllSeasonsFanartResize = False
        TVAllSeasonsFanartWidth = 0
        TVAllSeasonsLandscapeKeepExisting = False
        TVAllSeasonsLandscapePrefSize = Enums.TVLandscapeSize.Any
        TVAllSeasonsLandscapePrefSizeOnly = False
        TVAllSeasonsPosterHeight = 0
        TVAllSeasonsPosterKeepExisting = False
        TVAllSeasonsPosterPrefSize = Enums.TVPosterSize.Any
        TVAllSeasonsPosterPrefSizeOnly = False
        TVAllSeasonsPosterResize = False
        TVAllSeasonsPosterWidth = 0
        TVCleanDB = False
        TVDisplayMissingEpisodes = True
        TVDisplayStatus = False
        TVEpisodeActorThumbsExtExpert = ".jpg"
        TVEpisodeActorThumbsKeepExisting = False
        TVEpisodeFanartHeight = 0
        TVEpisodeFanartKeepExisting = False
        TVEpisodeFanartPrefSize = Enums.TVFanartSize.Any
        TVEpisodeFanartPrefSizeOnly = False
        TVEpisodeFanartResize = False
        TVEpisodeFanartWidth = 0
        TVEpisodeFilterCustom = New List(Of String)
        TVEpisodeFilterCustomIsEmpty = False
        TVEpisodeMissingFanart = False
        TVEpisodeMissingNFO = False
        TVEpisodeMissingPoster = False
        TVEpisodeNoFilter = True
        TVEpisodePosterHeight = 0
        TVEpisodePosterKeepExisting = False
        TVEpisodePosterPrefSize = Enums.TVEpisodePosterSize.Any
        TVEpisodePosterPrefSizeOnly = False
        TVEpisodePosterResize = False
        TVEpisodePosterWidth = 0
        TVEpisodeProperCase = True
        TVGeneralClickScrape = False
        TVGeneralClickScrapeask = False
        TVGeneralCustomScrapeButtonEnabled = False
        TVGeneralCustomScrapeButtonModifierType = Enums.ScrapeModifierType.All
        TVGeneralCustomScrapeButtonScrapeType = Enums.ScrapeType.NewSkip
        TVGeneralEpisodeListSorting = New List(Of ListSorting)
        TVGeneralFlagLang = String.Empty
        TVGeneralIgnoreLastScan = True
        TVGeneralLanguage = "en-US"
        TVGeneralMarkNewEpisodes = False
        TVGeneralMarkNewShows = False
        TVGeneralSeasonListSorting = New List(Of ListSorting)
        TVGeneralShowListSorting = New List(Of ListSorting)
        TVImagesCacheEnabled = True
        TVImagesDisplayImageSelect = True
        TVImagesForcedLanguage = "en"
        TVImagesForceLanguage = False
        TVImagesGetBlankImages = False
        TVImagesGetEnglishImages = False
        TVImagesMediaLanguageOnly = False
        TVLockEpisodeActors = False
        TVLockEpisodeAired = False
        TVLockEpisodeCredits = False
        TVLockEpisodeDirector = False
        TVLockEpisodeGuestStars = False
        TVLockEpisodeLanguageA = False
        TVLockEpisodeLanguageV = False
        TVLockEpisodePlot = False
        TVLockEpisodeRating = False
        TVLockEpisodeRuntime = False
        TVLockEpisodeTitle = False
        TVLockEpisodeUserRating = False
        TVLockSeasonPlot = False
        TVLockSeasonTitle = False
        TVLockShowActors = False
        TVLockShowCert = False
        TVLockShowCreators = False
        TVLockShowCountry = False
        TVLockShowGenre = False
        TVLockShowMPAA = False
        TVLockShowOriginalTitle = False
        TVLockShowPlot = False
        TVLockShowPremiered = False
        TVLockShowRating = False
        TVLockShowRuntime = False
        TVLockShowStatus = False
        TVLockShowStudio = False
        TVLockShowTitle = False
        TVLockShowUserRating = False
        TVMetadataPerFileType = New List(Of MetadataPerType)
        TVMultiPartMatching = "^[-_ex]+([0-9]+(?:(?:[a-i]|\.[1-9])(?![0-9]))?)"
        TVScanOrderModify = False
        TVScraperCleanFields = False
        TVScraperDurationRuntimeFormat = "<m>"
        TVScraperEpisodeActors = True
        TVScraperEpisodeAired = True
        TVScraperEpisodeCredits = True
        TVScraperEpisodeDirector = True
        TVScraperEpisodeGuestStars = True
        TVScraperEpisodeGuestStarsToActors = False
        TVScraperEpisodePlot = True
        TVScraperEpisodeRating = True
        TVScraperEpisodeRuntime = True
        TVScraperEpisodeTitle = True
        TVScraperEpisodeUserRating = True
        TVScraperMetaDataScan = True
        TVScraperOptionsOrdering = Enums.EpisodeOrdering.Standard
        TVScraperSeasonAired = True
        TVScraperSeasonPlot = True
        TVScraperSeasonTitle = False
        TVScraperShowActors = True
        TVScraperShowCert = False
        TVScraperShowCertForMPAA = False
        TVScraperShowCertForMPAAFallback = False
        TVScraperShowCertFSK = False
        TVScraperShowCertLang = String.Empty
        TVScraperShowCertOnlyValue = False
        TVScraperShowCreators = True
        TVScraperShowCountry = True
        TVScraperShowEpiGuideURL = False
        TVScraperShowGenre = True
        TVScraperShowMPAA = True
        TVScraperShowMPAANotRated = String.Empty
        TVScraperShowOriginalTitle = True
        TVScraperShowPlot = True
        TVScraperShowPremiered = True
        TVScraperShowRating = True
        TVScraperShowRuntime = True
        TVScraperShowStatus = True
        TVScraperShowStudio = True
        TVScraperShowTitle = True
        TVScraperShowUserRating = True
        TVScraperUseDisplaySeasonEpisode = True
        TVScraperUseMDDuration = True
        TVScraperUseSRuntimeForEp = True
        TVSeasonBannerHeight = 0
        TVSeasonBannerKeepExisting = False
        TVSeasonBannerPrefSize = Enums.TVBannerSize.Any
        TVSeasonBannerPrefSizeOnly = False
        TVSeasonBannerPrefType = Enums.TVBannerType.Any
        TVSeasonBannerResize = False
        TVSeasonBannerWidth = 0
        TVSeasonFanartHeight = 0
        TVSeasonFanartKeepExisting = False
        TVSeasonFanartPrefSize = Enums.TVFanartSize.Any
        TVSeasonFanartPrefSizeOnly = False
        TVSeasonFanartPrefSizeOnly = False
        TVSeasonFanartResize = False
        TVSeasonFanartWidth = 0
        TVSeasonLandscapeKeepExisting = False
        TVSeasonLandscapePrefSize = Enums.TVLandscapeSize.Any
        TVSeasonLandscapePrefSizeOnly = False
        TVSeasonMissingBanner = False
        TVSeasonMissingFanart = False
        TVSeasonMissingLandscape = False
        TVSeasonMissingPoster = False
        TVSeasonPosterHeight = 0
        TVSeasonPosterKeepExisting = False
        TVSeasonPosterPrefSize = Enums.TVSeasonPosterSize.Any
        TVSeasonPosterPrefSizeOnly = False
        TVSeasonPosterPrefSizeOnly = False
        TVSeasonPosterResize = False
        TVSeasonPosterWidth = 0
        TVShowActorThumbsExtExpert = ".jpg"
        TVShowActorThumbsKeepExisting = False
        TVShowBannerHeight = 0
        TVShowBannerKeepExisting = False
        TVShowBannerPrefSize = Enums.TVBannerSize.Any
        TVShowBannerPrefSizeOnly = False
        TVShowBannerPrefType = Enums.TVBannerType.Any
        TVShowBannerResize = False
        TVShowBannerWidth = 0
        TVShowCharacterArtKeepExisting = False
        TVShowCharacterArtPrefSize = Enums.TVCharacterArtSize.Any
        TVShowCharacterArtPrefSizeOnly = False
        TVShowClearArtKeepExisting = False
        TVShowClearArtPrefSize = Enums.TVClearArtSize.Any
        TVShowClearArtPrefSizeOnly = False
        TVShowClearLogoKeepExisting = False
        TVShowClearLogoPrefSize = Enums.TVClearLogoSize.Any
        TVShowClearLogoPrefSizeOnly = False
        TVShowExtrafanartsLimit = 4
        TVShowExtrafanartsKeepExisting = False
        TVShowExtrafanartsPrefSizeOnly = False
        TVShowExtrafanartsPrefSize = Enums.TVFanartSize.Any
        TVShowExtrafanartsPrefSizeOnly = False
        TVShowExtrafanartsPreselect = True
        TVShowExtrafanartsResize = False
        TVShowExtrafanartsHeight = 0
        TVShowExtrafanartsWidth = 0
        TVShowFanartHeight = 0
        TVShowFanartKeepExisting = False
        TVShowFanartPrefSize = Enums.TVFanartSize.Any
        TVShowFanartPrefSizeOnly = False
        TVShowFanartResize = False
        TVShowFanartWidth = 0
        TVShowFilterCustom = New List(Of String)
        TVShowFilterCustomIsEmpty = False
        TVShowLandscapeKeepExisting = False
        TVShowLandscapePrefSize = Enums.TVLandscapeSize.Any
        TVShowLandscapePrefSizeOnly = False
        TVShowMatching = New List(Of regexp)
        TVShowMissingBanner = False
        TVShowMissingCharacterArt = False
        TVShowMissingClearArt = False
        TVShowMissingClearLogo = False
        TVShowMissingExtrafanarts = False
        TVShowMissingFanart = False
        TVShowMissingLandscape = False
        TVShowMissingNFO = False
        TVShowMissingPoster = False
        TVShowMissingTheme = False
        TVShowPosterHeight = 0
        TVShowPosterKeepExisting = False
        TVShowPosterPrefSize = Enums.TVPosterSize.Any
        TVShowPosterPrefSizeOnly = False
        TVShowPosterResize = False
        TVShowPosterWidth = 0
        TVShowProperCase = True
        TVShowThemeKeepExisting = False
        TVSkipLessThan = 0
        TVSortTokens = New List(Of String)
        TVSortTokensIsEmpty = False
        Username = String.Empty
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
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MovieSetSortTokens) AndAlso (Force OrElse (Master.eSettings.MovieSetSortTokens.Count <= 0 AndAlso Not Master.eSettings.MovieSetSortTokensIsEmpty)) Then
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

        'ValidExts
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidExts) AndAlso (Force OrElse Master.eSettings.FileSystemValidExts.Count <= 0) Then
            Master.eSettings.FileSystemValidExts.Clear()
            Master.eSettings.FileSystemValidExts.AddRange(".avi,.divx,.mkv,.iso,.mpg,.mp4,.mpeg,.wmv,.wma,.mov,.mts,.m2t,.img,.dat,.bin,.cue,.ifo,.dvb,.evo,.asf,.asx,.avs,.nsv,.ram,.ogg,.ogm,.ogv,.flv,.swf,.nut,.viv,.rar,.m2ts,.dvr-ms,.ts,.m4v,.rmvb,.webm,.disc,.3gpp".Split(","c))
        End If

        'ValidSubtitleExts
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidSubtitleExts) AndAlso (Force OrElse Master.eSettings.FileSystemValidSubtitlesExts.Count <= 0) Then
            Master.eSettings.FileSystemValidSubtitlesExts.Clear()
            Master.eSettings.FileSystemValidSubtitlesExts.AddRange(".sst,.srt,.sub,.ssa,.aqt,.smi,.sami,.jss,.mpl,.rt,.idx,.ass".Split(","c))
        End If

        'ValidThemeExts
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.ValidThemeExts) AndAlso (Force OrElse Master.eSettings.FileSystemValidThemeExts.Count <= 0) Then
            Master.eSettings.FileSystemValidThemeExts.Clear()
            Master.eSettings.FileSystemValidThemeExts.AddRange(".flac,.m4a,.mp3,.wav,.wma".Split(","c))
        End If

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
        End If

        'MovieListSorting
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MovieListSorting) AndAlso (Force OrElse Master.eSettings.MovieGeneralMediaListSorting.Count <= 0) Then
            Master.eSettings.MovieGeneralMediaListSorting.Clear()
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = True, .Column = "OriginalTitle", .LabelID = 302, .LabelText = "Original Title"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = True, .Column = "Year", .LabelID = 278, .LabelText = "Year"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = True, .Column = "MPAA", .LabelID = 401, .LabelText = "MPAA"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = True, .Column = "Rating", .LabelID = 400, .LabelText = "Rating"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = True, .Column = "Top250", .LabelID = -1, .LabelText = "Top250"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = True, .Column = "IMDB", .LabelID = 61, .LabelText = "IMDB ID"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 7, .Hide = True, .Column = "TMDB", .LabelID = 933, .LabelText = "TMDB ID"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 8, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 9, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 10, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 11, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 12, .Hide = False, .Column = "DiscArtPath", .LabelID = 1098, .LabelText = "DiscArt"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 13, .Hide = False, .Column = "EFanartsPath", .LabelID = 992, .LabelText = "Extrafanarts"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 14, .Hide = False, .Column = "EThumbsPath", .LabelID = 153, .LabelText = "Extrathumbs"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 15, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 16, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 17, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 18, .Hide = False, .Column = "HasSub", .LabelID = 152, .LabelText = "Subtitles"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 19, .Hide = False, .Column = "ThemePath", .LabelID = 1118, .LabelText = "Theme"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 20, .Hide = False, .Column = "TrailerPath", .LabelID = 151, .LabelText = "Trailer"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 21, .Hide = False, .Column = "HasSet", .LabelID = 1295, .LabelText = "Part of a MovieSet"})
            Master.eSettings.MovieGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 22, .Hide = False, .Column = "LastPlayed", .LabelID = 981, .LabelText = "Watched"})
        End If

        'MovieSetListSorting
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.MovieSetListSorting) AndAlso (Force OrElse Master.eSettings.MovieSetGeneralMediaListSorting.Count <= 0) Then
            Master.eSettings.MovieSetGeneralMediaListSorting.Clear()
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "DiscArtPath", .LabelID = 1098, .LabelText = "DiscArt"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 7, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
            Master.eSettings.MovieSetGeneralMediaListSorting.Add(New ListSorting With {.DisplayIndex = 8, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
        End If

        'TVEpisodeListSorting
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVEpisodeListSorting) AndAlso (Force OrElse Master.eSettings.TVGeneralEpisodeListSorting.Count <= 0) Then
            Master.eSettings.TVGeneralEpisodeListSorting.Clear()
            Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "Title", .LabelID = 21, .LabelText = "Title"})
            Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
            Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = True, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
            Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
            Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "HasSub", .LabelID = 152, .LabelText = "Subtitles"})
            Master.eSettings.TVGeneralEpisodeListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "Playcount", .LabelID = 981, .LabelText = "Watched"})
        End If

        'TVSeasonListSorting
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVSeasonListSorting) AndAlso (Force OrElse Master.eSettings.TVGeneralSeasonListSorting.Count <= 0) Then
            Master.eSettings.TVGeneralSeasonListSorting.Clear()
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "SeasonText", .LabelID = 650, .LabelText = "Season"})
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = True, .Column = "Episodes", .LabelID = 682, .LabelText = "Episodes"})
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
            Master.eSettings.TVGeneralSeasonListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = False, .Column = "HasWatched", .LabelID = 981, .LabelText = "Watched"})
        End If

        'TVShowListSorting
        If (Type = Enums.DefaultSettingType.All OrElse Type = Enums.DefaultSettingType.TVShowListSorting) AndAlso (Force OrElse Master.eSettings.TVGeneralShowListSorting.Count <= 0) Then
            Master.eSettings.TVGeneralShowListSorting.Clear()
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 0, .Hide = False, .Column = "ListTitle", .LabelID = 21, .LabelText = "Title"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 1, .Hide = True, .Column = "OriginalTitle", .LabelID = 302, .LabelText = "Original Title"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 2, .Hide = True, .Column = "Status", .LabelID = 215, .LabelText = "Status"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 3, .Hide = True, .Column = "Episodes", .LabelID = 682, .LabelText = "Episodes"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 4, .Hide = False, .Column = "NfoPath", .LabelID = 150, .LabelText = "NFO"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 5, .Hide = False, .Column = "BannerPath", .LabelID = 838, .LabelText = "Banner"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 6, .Hide = False, .Column = "CharacterArtPath", .LabelID = 1140, .LabelText = "CharacterArt"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 7, .Hide = False, .Column = "ClearArtPath", .LabelID = 1096, .LabelText = "ClearArt"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 8, .Hide = False, .Column = "ClearLogoPath", .LabelID = 1097, .LabelText = "ClearLogo"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 9, .Hide = False, .Column = "EFanartsPath", .LabelID = 992, .LabelText = "Extrafanarts"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 10, .Hide = False, .Column = "FanartPath", .LabelID = 149, .LabelText = "Fanart"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 11, .Hide = False, .Column = "LandscapePath", .LabelID = 1035, .LabelText = "Landscape"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 12, .Hide = False, .Column = "PosterPath", .LabelID = 148, .LabelText = "Poster"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 13, .Hide = False, .Column = "ThemePath", .LabelID = 1118, .LabelText = "Theme"})
            Master.eSettings.TVGeneralShowListSorting.Add(New ListSorting With {.DisplayIndex = 14, .Hide = False, .Column = "HasWatched", .LabelID = 981, .LabelText = "Watched"})
        End If
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
                Select Case tImageType
                    Case Enums.ScrapeModifierType.MainActorThumbs
                        Return FilenameAnyEnabled_Movie_Actorthumbs()
                    Case Enums.ScrapeModifierType.MainBanner
                        Return FilenameAnyEnabled_Movie_Banner()
                    Case Enums.ScrapeModifierType.MainClearArt
                        Return FilenameAnyEnabled_Movie_ClearArt()
                    Case Enums.ScrapeModifierType.MainClearLogo
                        Return FilenameAnyEnabled_Movie_ClearLogo()
                    Case Enums.ScrapeModifierType.MainDiscArt
                        Return FilenameAnyEnabled_Movie_DiscArt()
                    Case Enums.ScrapeModifierType.MainExtrafanarts
                        Return FilenameAnyEnabled_Movie_Extrafanarts()
                    Case Enums.ScrapeModifierType.MainExtrathumbs
                        Return FilenameAnyEnabled_Movie_Extrathumbs()
                    Case Enums.ScrapeModifierType.MainFanart
                        Return FilenameAnyEnabled_Movie_Fanart()
                    Case Enums.ScrapeModifierType.MainLandscape
                        Return FilenameAnyEnabled_Movie_Landscape()
                    Case Enums.ScrapeModifierType.MainNFO
                        Return FilenameAnyEnabled_Movie_NFO()
                    Case Enums.ScrapeModifierType.MainPoster
                        Return FilenameAnyEnabled_Movie_Poster()
                    Case Enums.ScrapeModifierType.MainTheme
                        Return FilenameAnyEnabled_Movie_Theme()
                    Case Enums.ScrapeModifierType.MainTrailer
                        Return FilenameAnyEnabled_Movie_Trailer()
                End Select
            Case Enums.ContentType.MovieSet
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

    Public Function FilenameAnyEnabled_Movie_Actorthumbs() As Boolean
        Return _
            MovieActorThumbsEden OrElse
            MovieActorThumbsFrodo OrElse
            (MovieUseExpert AndAlso ((MovieActorThumbsExpertBDMV AndAlso Not String.IsNullOrEmpty(MovieActorThumbsExtExpertBDMV)) OrElse (MovieActorThumbsExpertMulti AndAlso Not String.IsNullOrEmpty(MovieActorThumbsExtExpertMulti)) OrElse (MovieActorThumbsExpertSingle AndAlso Not String.IsNullOrEmpty(MovieActorThumbsExtExpertSingle)) OrElse (MovieActorThumbsExpertVTS AndAlso Not String.IsNullOrEmpty(MovieActorThumbsExtExpertVTS))))
    End Function

    Public Function FilenameAnyEnabled_Movie_Banner() As Boolean
        Return _
            MovieBannerAD OrElse
            MovieBannerExtended OrElse
            MovieBannerNMJ OrElse
            MovieBannerYAMJ OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieBannerExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieBannerExpertMulti) OrElse Not String.IsNullOrEmpty(MovieBannerExpertSingle) OrElse Not String.IsNullOrEmpty(MovieBannerExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_ClearArt() As Boolean
        Return _
            MovieClearArtAD OrElse
            MovieClearArtExtended OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieClearArtExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieClearArtExpertMulti) OrElse Not String.IsNullOrEmpty(MovieClearArtExpertSingle) OrElse Not String.IsNullOrEmpty(MovieClearArtExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_ClearLogo() As Boolean
        Return _
            MovieClearLogoAD OrElse
            MovieClearLogoExtended OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieClearLogoExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieClearLogoExpertMulti) OrElse Not String.IsNullOrEmpty(MovieClearLogoExpertSingle) OrElse Not String.IsNullOrEmpty(MovieClearLogoExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_DiscArt() As Boolean
        Return _
            MovieDiscArtAD OrElse
            MovieDiscArtExtended OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieDiscArtExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieDiscArtExpertMulti) OrElse Not String.IsNullOrEmpty(MovieDiscArtExpertSingle) OrElse Not String.IsNullOrEmpty(MovieDiscArtExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_Extrafanarts() As Boolean
        Return _
            MovieExtrafanartsEden OrElse
            MovieExtrafanartsFrodo OrElse
            (MovieUseExpert AndAlso (MovieExtrafanartsExpertBDMV OrElse MovieExtrafanartsExpertSingle OrElse MovieExtrafanartsExpertVTS))
    End Function

    Public Function FilenameAnyEnabled_Movie_Extrathumbs() As Boolean
        Return _
            MovieExtrathumbsEden OrElse
            MovieExtrathumbsFrodo OrElse
            (MovieUseExpert AndAlso (MovieExtrathumbsExpertBDMV OrElse MovieExtrathumbsExpertSingle OrElse MovieExtrathumbsExpertVTS))
    End Function

    Public Function FilenameAnyEnabled_Movie_Fanart() As Boolean
        Return _
            MovieFanartBoxee OrElse
            MovieFanartEden OrElse
            MovieFanartFrodo OrElse
            MovieFanartNMJ OrElse
            MovieFanartYAMJ OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieFanartExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieFanartExpertMulti) OrElse Not String.IsNullOrEmpty(MovieFanartExpertSingle) OrElse Not String.IsNullOrEmpty(MovieFanartExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_Landscape() As Boolean
        Return _
            MovieLandscapeAD OrElse
            MovieLandscapeExtended OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieLandscapeExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieLandscapeExpertMulti) OrElse Not String.IsNullOrEmpty(MovieLandscapeExpertSingle) OrElse Not String.IsNullOrEmpty(MovieLandscapeExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_NFO() As Boolean
        Return _
            MovieNFOBoxee OrElse
            MovieNFOEden OrElse
            MovieNFOFrodo OrElse
            MovieNFONMJ OrElse
            MovieNFOYAMJ OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieNFOExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieNFOExpertMulti) OrElse Not String.IsNullOrEmpty(MovieNFOExpertSingle) OrElse Not String.IsNullOrEmpty(MovieNFOExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_Poster() As Boolean
        Return _
            MoviePosterBoxee OrElse
            MoviePosterEden OrElse
            MoviePosterFrodo OrElse
            MoviePosterNMJ OrElse
            MoviePosterYAMJ OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MoviePosterExpertBDMV) OrElse Not String.IsNullOrEmpty(MoviePosterExpertMulti) OrElse Not String.IsNullOrEmpty(MoviePosterExpertSingle) OrElse Not String.IsNullOrEmpty(MoviePosterExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_Movie_Theme() As Boolean
        Return _
            MovieThemeTvTunesEnable AndAlso (MovieThemeTvTunesMoviePath OrElse (MovieThemeTvTunesCustom AndAlso Not String.IsNullOrEmpty(MovieThemeTvTunesCustomPath) OrElse (MovieThemeTvTunesSub AndAlso Not String.IsNullOrEmpty(MovieThemeTvTunesSubDir))))
    End Function

    Public Function FilenameAnyEnabled_Movie_Trailer() As Boolean
        Return _
            MovieTrailerEden OrElse
            MovieTrailerFrodo OrElse
            MovieTrailerNMJ OrElse
            MovieTrailerYAMJ OrElse
            (MovieUseExpert AndAlso (Not String.IsNullOrEmpty(MovieTrailerExpertBDMV) OrElse Not String.IsNullOrEmpty(MovieTrailerExpertMulti) OrElse Not String.IsNullOrEmpty(MovieTrailerExpertSingle) OrElse Not String.IsNullOrEmpty(MovieTrailerExpertVTS)))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Banner() As Boolean
        Return _
            (MovieSetBannerExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetBannerMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPosterExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetPosterExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_ClearArt() As Boolean
        Return _
            (MovieSetClearArtExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetClearArtMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetClearArtExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetClearArtExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_ClearLogo() As Boolean
        Return _
            (MovieSetClearLogoExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetClearLogoMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetClearLogoExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetClearLogoExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_DiscArt() As Boolean
        Return _
            (MovieSetDiscArtExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetDiscArtExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetDiscArtExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Fanart() As Boolean
        Return _
            (MovieSetFanartExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetFanartMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetFanartExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetFanartExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Landscape() As Boolean
        Return _
            (MovieSetLandscapeExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetLandscapeMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetLandscapeExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetLandscapeExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_NFO() As Boolean
        Return _
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetNFOExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetNFOExpertSingle))))
    End Function

    Public Function FilenameAnyEnabled_MovieSet_Poster() As Boolean
        Return _
            (MovieSetPosterExtended AndAlso Not String.IsNullOrEmpty(MovieSetPathExtended)) OrElse
            (MovieSetPosterMSAA AndAlso Not String.IsNullOrEmpty(MovieSetPathMSAA)) OrElse
            (MovieSetUseExpert AndAlso (Not String.IsNullOrEmpty(MovieSetPosterExpertParent) OrElse (Not String.IsNullOrEmpty(MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(MovieSetPosterExpertSingle))))
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

    Public Function MissingItemsAnyEnabled_Movie() As Boolean
        Return _
            MovieMissingBanner OrElse
            MovieMissingClearArt OrElse
            MovieMissingClearLogo OrElse
            MovieMissingDiscArt OrElse
            MovieMissingExtrafanarts OrElse
            MovieMissingExtrathumbs OrElse
            MovieMissingFanart OrElse
            MovieMissingLandscape OrElse
            MovieMissingNFO OrElse
            MovieMissingPoster OrElse
            MovieMissingSubtitles OrElse
            MovieMissingTheme OrElse
            MovieMissingTrailer
    End Function

    Public Function MissingItemsAnyEnabled_MovieSet() As Boolean
        Return _
            MovieSetMissingBanner OrElse
            MovieSetMissingClearArt OrElse
            MovieSetMissingClearLogo OrElse
            MovieSetMissingDiscArt OrElse
            MovieSetMissingFanart OrElse
            MovieSetMissingLandscape OrElse
            MovieSetMissingNFO OrElse
            MovieSetMissingPoster
    End Function

    Public Function MissingItemsAnyEnabled_TVEpisode() As Boolean
        Return _
            TVEpisodeMissingFanart OrElse
            TVEpisodeMissingNFO OrElse
            TVEpisodeMissingPoster
    End Function

    Public Function MissingItemsAnyEnabled_TVSeason() As Boolean
        Return _
            TVSeasonMissingBanner OrElse 
            TVSeasonMissingFanart OrElse 
            TVSeasonMissingLandscape OrElse 
            TVSeasonMissingPoster
    End Function

    Public Function MissingItemsAnyEnabled_TVShow() As Boolean
        Return _
            TVShowMissingBanner OrElse
            TVShowMissingCharacterArt OrElse
            TVShowMissingClearArt OrElse
            TVShowMissingClearLogo OrElse
            TVShowMissingExtrafanarts OrElse
            TVShowMissingFanart OrElse
            TVShowMissingLandscape OrElse
            TVShowMissingNFO OrElse
            TVShowMissingPoster OrElse
            TVShowMissingTheme
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

    Public Class ListSorting

#Region "Fields"

        Private _column As String
        Private _displayindex As Integer
        Private _hide As Boolean
        Private _labelid As Integer
        Private _labeltext As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clear()
        End Sub

#End Region 'Constructors

#Region "Properties"
        ''' <summary>
        ''' Column name in database (need to be exactly like column name in DB)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Column() As String
            Get
                Return _column
            End Get
            Set(ByVal value As String)
                _column = value
            End Set
        End Property

        Public Property DisplayIndex() As Integer
            Get
                Return _displayindex
            End Get
            Set(ByVal value As Integer)
                _displayindex = value
            End Set
        End Property
        ''' <summary>
        ''' Hide or show column in media lists
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Hide() As Boolean
            Get
                Return _hide
            End Get
            Set(ByVal value As Boolean)
                _hide = value
            End Set
        End Property
        ''' <summary>
        ''' ID of string in Master.eLangs.GetString
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LabelID() As Integer
            Get
                Return _labelid
            End Get
            Set(ByVal value As Integer)
                _labelid = value
            End Set
        End Property
        ''' <summary>
        ''' Default text for the LabelID in Master.eLangs.GetString
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LabelText() As String
            Get
                Return _labeltext
            End Get
            Set(ByVal value As String)
                _labeltext = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clear()
            _column = String.Empty
            _displayindex = -1
            _hide = False
            _labelid = 1
            _labeltext = String.Empty
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

#End Region 'Nested Types

End Class