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
Imports System.Windows.Forms
Imports System.Drawing
Imports NLog

Public Class AddonsManager

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Public Shared AssemblyList As New List(Of AssemblyListItem)
    Public Shared VersionList As New List(Of VersionItem)

    Public Addons As New List(Of AddonClass)
    Public RuntimeObjects As New EmberRuntimeObjects

    'Singleton Instace for module manager .. allways use this one
    Private Shared Singleton As AddonsManager = Nothing

    Private strAddonsPath As String = Path.Combine(Functions.AppPath, "Addons")

    Friend WithEvents bwLoadModules As New System.ComponentModel.BackgroundWorker

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object))

#End Region 'Events

#Region "Properties"

    Public Shared ReadOnly Property Instance() As AddonsManager
        Get
            If (Singleton Is Nothing) Then
                Singleton = New AddonsManager()
            End If
            Return Singleton
        End Get
    End Property

    Public ReadOnly Property ModulesLoaded() As Boolean
        Get
            Return Not bwLoadModules.IsBusy
        End Get
    End Property
#End Region 'Properties

#Region "Methods"

    Private Sub BuildVersionList()
        VersionList.Clear()
        VersionList.Add(New VersionItem With {.AssemblyFileName = "*EmberAPP", .Name = "Ember Application", .Version = My.Application.Info.Version.ToString()})
        VersionList.Add(New VersionItem With {.AssemblyFileName = "*EmberAPI", .Name = "Ember API", .Version = Functions.EmberAPIVersion()})
        For Each nExternalModule As AddonClass In Addons
            VersionList.Add(New VersionItem With {.Name = nExternalModule.ProcessorModule.Name,
              .AssemblyFileName = nExternalModule.AssemblyFileName,
              .Version = nExternalModule.ProcessorModule.Version})
        Next
    End Sub

    Private Sub bwLoadModules_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLoadModules.DoWork
        LoadAddons()
    End Sub

    Private Sub bwLoadModules_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoadModules.RunWorkerCompleted
        BuildVersionList()
    End Sub

    Public Sub GetVersions()
        Dim dlgVersions As New dlgVersions
        Dim li As ListViewItem
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each v As VersionItem In VersionList
            li = dlgVersions.lstVersions.Items.Add(v.Name)
            li.SubItems.Add(v.Version)
        Next
        dlgVersions.ShowDialog()
    End Sub

    Public Sub LoadAllAddons()
        bwLoadModules.RunWorkerAsync()
    End Sub

    Public Sub LoadAddons()
        logger.Trace("[AddonsManager] [LoadAddons] [Start]")

        If Directory.Exists(strAddonsPath) Then
            'add each .dll file to AssemblyList
            For Each file As String In Directory.GetFiles(strAddonsPath, "*.dll")
                Dim nAssembly As Reflection.Assembly = Reflection.Assembly.LoadFile(file)
                AssemblyList.Add(New AddonsManager.AssemblyListItem With {.Assembly = nAssembly, .AssemblyName = nAssembly.GetName.Name})
            Next

            For Each tAssemblyItem As AssemblyListItem In AssemblyList
                'Loop through each of the assemeblies type
                For Each fileType As Type In tAssemblyItem.Assembly.GetTypes
                    Dim fType As Type = fileType.GetInterface("Addon")
                    If Not fType Is Nothing Then
                        Dim ProcessorModule As Interfaces.Addon
                        ProcessorModule = CType(Activator.CreateInstance(fileType), Interfaces.Addon)

                        Dim nExternalModule As New AddonClass
                        nExternalModule.ProcessorModule = ProcessorModule
                        nExternalModule.AssemblyName = tAssemblyItem.AssemblyName
                        nExternalModule.AssemblyFileName = tAssemblyItem.Assembly.ManifestModule.Name
                        Addons.Add(nExternalModule)

                        logger.Info(String.Concat("[AddonsManager] [LoadAddons] Addon loaded: ", nExternalModule.AssemblyName))

                        nExternalModule.ProcessorModule.Init(nExternalModule.AssemblyName)

                        For Each i As _XMLAddonClass In Master.eSettings.EmberModules.Where(Function(f) f.strAssemblyName = nExternalModule.AssemblyName)
                            nExternalModule.ProcessorModule.Enabled = i.bEnabled
                        Next
                        AddHandler ProcessorModule.GenericEvent, AddressOf GenericRunCallBack
                    End If
                Next
            Next
        Else
            logger.Warn("[AddonsManager] [LoadAddons] No directory ""Addons"" found!")
        End If

        logger.Trace("[AddonsManager] [LoadAddons] [Done]")
    End Sub

    Function QueryAnyAddonIsBusy() As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Dim modules As IEnumerable(Of AddonClass) = Addons.Where(Function(e) e.ProcessorModule.IsBusy)
        If modules.Count() > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function QueryScraperCapabilities_Image_Movie(ByVal tExternalModule As AddonClass, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If ScrapeModifiers.MainBanner AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_Banner) Then Return True
        If ScrapeModifiers.MainClearArt AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_ClearArt) Then Return True
        If ScrapeModifiers.MainClearLogo AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_ClearLogo) Then Return True
        If ScrapeModifiers.MainDiscArt AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_DiscArt) Then Return True
        If ScrapeModifiers.MainExtrafanarts AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_Fanart) Then Return True
        If ScrapeModifiers.MainExtrathumbs AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_Fanart) Then Return True
        If ScrapeModifiers.MainFanart AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_Fanart) Then Return True
        If ScrapeModifiers.MainLandscape AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_Landscape) Then Return True
        If ScrapeModifiers.MainPoster AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.Movie_Image_Poster) Then Return True

        Return False
    End Function

    Function QueryScraperCapabilities_Image_MovieSet(ByVal tExternalModule As AddonClass, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If ScrapeModifiers.MainBanner AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_Banner) Then Return True
        If ScrapeModifiers.MainClearArt AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_ClearArt) Then Return True
        If ScrapeModifiers.MainClearLogo AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_ClearLogo) Then Return True
        If ScrapeModifiers.MainDiscArt AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_DiscArt) Then Return True
        If ScrapeModifiers.MainFanart AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_Fanart) Then Return True
        If ScrapeModifiers.MainLandscape AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_Landscape) Then Return True
        If ScrapeModifiers.MainPoster AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.MovieSet_Image_Poster) Then Return True

        Return False
    End Function

    Function QueryScraperCapabilities_Image_TV(ByVal tExternalModule As AddonClass, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If ScrapeModifiers.EpisodeFanart AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVEpisode_Image_Fanart) Then Return True
        If ScrapeModifiers.EpisodePoster AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVEpisode_Image_Poster) Then Return True
        If ScrapeModifiers.MainBanner AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_Banner) Then Return True
        If ScrapeModifiers.MainCharacterArt AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_CharacterArt) Then Return True
        If ScrapeModifiers.MainClearArt AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_ClearArt) Then Return True
        If ScrapeModifiers.MainClearLogo AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_ClearLogo) Then Return True
        If ScrapeModifiers.MainFanart AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_Fanart) Then Return True
        If ScrapeModifiers.MainLandscape AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_Landscape) Then Return True
        If ScrapeModifiers.MainPoster AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVShow_Image_Poster) Then Return True
        If ScrapeModifiers.SeasonBanner AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVSeason_Image_Banner) Then Return True
        If ScrapeModifiers.SeasonFanart AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVSeason_Image_Fanart) Then Return True
        If ScrapeModifiers.SeasonLandscape AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVSeason_Image_Landscape) Then Return True
        If ScrapeModifiers.SeasonPoster AndAlso tExternalModule.ProcessorModule.Capabilities_ScraperCapatibility.Contains(Enums.ScraperCapatibility.TVSeason_Image_Poster) Then Return True

        Return False
    End Function
    ''' <summary>
    ''' Calls all the generic modules of the supplied type (if one is defined), passing the supplied _params.
    ''' The module will do its task and return any expected results in the _refparams.
    ''' </summary>
    ''' <param name="eModuleEventType">The <c>Enums.ModuleEventType</c> of module to execute.</param>
    ''' <param name="_params">Parameters to pass to the module</param>
    ''' <param name="_singleobjekt"><c>Object</c> representing the module's result (if relevant)</param>
    ''' <param name="RunOnlyOne">If <c>True</c>, allow only one module to perform the required task.</param>
    ''' <returns></returns>
    ''' <remarks>Note that if any module returns a result of breakChain, no further modules are processed</remarks>
    Public Function RunGeneric(ByVal eModuleEventType As Enums.AddonEventType, ByRef _params As List(Of Object), Optional ByVal _singleobjekt As Object = Nothing, Optional ByVal RunOnlyOne As Boolean = False, Optional ByRef DBElement As Database.DBElement = Nothing) As Boolean
        logger.Trace(String.Format("[AddonsManager] [RunGeneric] [Start] <{0}>", eModuleEventType.ToString))
        Dim ret As Interfaces.AddonResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Try
            Dim nAddons = Addons.Where(Function(e) e.ProcessorModule.Capabilities_AddonEventTypes.Contains(eModuleEventType) AndAlso e.ProcessorModule.Enabled)
            If (nAddons.Count() <= 0) Then
                logger.Warn("[AddonsManager] [RunGeneric] No generic modules defined <{0}>", eModuleEventType.ToString)
            Else
                For Each nAddon In nAddons
                    Try
                        logger.Trace("[AddonsManager] [RunGeneric] Run generic module <{0}>", nAddon.ProcessorModule.Name)
                        ret = nAddon.ProcessorModule.Run(DBElement, eModuleEventType, _params)
                    Catch ex As Exception
                        logger.Error("[AddonsManager] [RunGeneric] Run generic module <{0}>", nAddon.ProcessorModule.Name)
                        logger.Error(ex, New StackFrame().GetMethod().Name)
                    End Try
                    If ret.bBreakChain OrElse RunOnlyOne Then Exit For
                Next
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        Return ret.bCancelled
    End Function

    Public Sub SaveSettings()
        Dim tmpForXML As New List(Of _XMLAddonClass)

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        For Each nExternalModule As AddonClass In Addons
            Dim t As New _XMLAddonClass
            t.strAssemblyName = nExternalModule.AssemblyName
            t.strAssemblyFileName = nExternalModule.AssemblyFileName
            t.bEnabled = nExternalModule.ProcessorModule.Enabled
            tmpForXML.Add(t)
        Next

        Master.eSettings.EmberModules = tmpForXML
        Master.eSettings.Save()
    End Sub

    ''' <summary>
    ''' Request that enabled movie scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">Movie to be scraped</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks>Note that if no movie scrapers are enabled, a silent warning is generated.</remarks>
    Public Function ScrapeData_Movie(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeData_Movie] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(tDBElement, bShowMessage) Then
            Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.AddonResult
            Dim ScrapedList As New List(Of MediaContainers.MainDetails)

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'clean DBMovie if the movie is to be changed. For this, all existing (incorrect) information must be deleted and the images triggers set to remove.
            If (tDBElement.ScrapeType = Enums.ScrapeType.SingleScrape OrElse tDBElement.ScrapeType = Enums.ScrapeType.SingleAuto) AndAlso tDBElement.ScrapeModifiers.DoSearch Then
                tDBElement.ImagesContainer = New MediaContainers.ImagesContainer
                tDBElement.MainDetails = New MediaContainers.MainDetails

                tDBElement.MainDetails.Title = StringUtils.FilterTitleFromPath_Movie(tDBElement.Filename, tDBElement.IsSingle, tDBElement.Source.UseFolderName)
                tDBElement.MainDetails.Year = StringUtils.FilterYearFromPath_Movie(tDBElement.Filename, tDBElement.IsSingle, tDBElement.Source.UseFolderName)
            End If

            'create a clone of DBMovie
            Dim oDBMovie As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

            If (modules.Count() <= 0) Then
                logger.Warn("[AddonsManager] [ScrapeData_Movie] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[AddonsManager] [ScrapeData_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.Name))

                    ret = _externalScraperModule.ProcessorModule.Run(oDBMovie, Enums.AddonEventType.Scrape_Movie, Nothing)

                    If ret.bCancelled Then Return ret.bCancelled

                    If ret.ScraperResult_Data IsNot Nothing Then
                        ScrapedList.Add(ret.ScraperResult_Data)

                        'set new informations for following scrapers
                        If ret.ScraperResult_Data.IMDBSpecified Then
                            oDBMovie.MainDetails.IMDB = ret.ScraperResult_Data.IMDB
                        End If
                        If ret.ScraperResult_Data.OriginalTitleSpecified Then
                            oDBMovie.MainDetails.OriginalTitle = ret.ScraperResult_Data.OriginalTitle
                        End If
                        If ret.ScraperResult_Data.TitleSpecified Then
                            oDBMovie.MainDetails.Title = ret.ScraperResult_Data.Title
                        End If
                        If ret.ScraperResult_Data.TMDBSpecified Then
                            oDBMovie.MainDetails.TMDB = ret.ScraperResult_Data.TMDB
                        End If
                        If ret.ScraperResult_Data.YearSpecified Then
                            oDBMovie.MainDetails.Year = ret.ScraperResult_Data.Year
                        End If
                    End If
                    If ret.bBreakChain Then Exit For
                Next

                'Merge scraperresults considering global datascraper settings
                tDBElement = NFO.MergeDataScraperResults_Movie(tDBElement, ScrapedList)

                'create cache paths for Actor Thumbs
                tDBElement.MainDetails.CreateCachePaths_ActorsThumbs()
            End If

            If ScrapedList.Count > 0 Then
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_Movie] [Done] {0}", tDBElement.Filename))
            Else
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_Movie] [Done] [No Scraper Results] {0}", tDBElement.Filename))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeData_Movie] [Abort] [Offline] {0}", tDBElement.Filename))
            Return True 'Cancelled
        End If
    End Function
    ''' <summary>
    ''' Request that enabled movie scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">MovieSet to be scraped. Scraper will directly manipulate this structure</param> 
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks>Note that if no movie set scrapers are enabled, a silent warning is generated.</remarks>
    Public Function ScrapeData_MovieSet(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeData_MovieSet] [Start] {0}", tDBElement.MainDetails.Title))
        'If DBMovieSet.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_MovieSet(DBMovieSet, showMessage) Then
        Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.AddonResult
        Dim ScrapedList As New List(Of MediaContainers.MainDetails)

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        'clean DBMovie if the movie is to be changed. For this, all existing (incorrect) information must be deleted and the images triggers set to remove.
        If (tDBElement.ScrapeType = Enums.ScrapeType.SingleScrape OrElse tDBElement.ScrapeType = Enums.ScrapeType.SingleAuto) AndAlso tDBElement.ScrapeModifiers.DoSearch Then
            Dim tmpTitle As String = tDBElement.MainDetails.Title

            tDBElement.ImagesContainer = New MediaContainers.ImagesContainer
            tDBElement.MainDetails = New MediaContainers.MainDetails

            tDBElement.MainDetails.Title = tmpTitle
        End If

        'create a clone of DBMovieSet
        Dim oDBMovieSet As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

        If (modules.Count() <= 0) Then
            logger.Warn("[AddonsManager] [ScrapeData_MovieSet] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_MovieSet] [Using] {0}", _externalScraperModule.ProcessorModule.Name))

                ret = _externalScraperModule.ProcessorModule.Run(oDBMovieSet, Enums.AddonEventType.Scrape_MovieSet, Nothing)

                If ret.bCancelled Then
                    logger.Trace(String.Format("[AddonsManager] [ScrapeData_MovieSet] [Cancelled] [No Scraper Results] {0}", tDBElement.MainDetails.Title))
                    Return ret.bCancelled
                End If

                If ret.ScraperResult_Data IsNot Nothing Then
                    ScrapedList.Add(ret.ScraperResult_Data)

                    'set new informations for following scrapers
                    If ret.ScraperResult_Data.TitleSpecified Then
                        oDBMovieSet.MainDetails.Title = ret.ScraperResult_Data.Title
                    End If
                    If ret.ScraperResult_Data.TMDBSpecified Then
                        oDBMovieSet.MainDetails.TMDB = ret.ScraperResult_Data.TMDB
                    End If
                End If
                If ret.bBreakChain Then Exit For
            Next

            'Merge scraperresults considering global datascraper settings
            tDBElement = NFO.MergeDataScraperResults_MovieSet(tDBElement, ScrapedList)
        End If

        If ScrapedList.Count > 0 Then
            logger.Trace(String.Format("[AddonsManager] [ScrapeData_MovieSet] [Done] {0}", tDBElement.MainDetails.Title))
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeData_MovieSet] [Done] [No Scraper Results] {0}", tDBElement.MainDetails.Title))
            Return True 'TODO: need a new trigger
        End If
        Return ret.bCancelled
        'Else
        'Return True 'Cancelled
        'End If
    End Function

    Public Function ScrapeData_TVEpisode(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVEpisode] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.AddonResult
            Dim ScrapedList As New List(Of MediaContainers.MainDetails)

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'create a clone of DBTV
            Dim oEpisode As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

            If (modules.Count() <= 0) Then
                logger.Warn("[AddonsManager] [ScrapeData_TVEpisode] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVEpisode] [Using] {0}", _externalScraperModule.ProcessorModule.Name))

                    ret = _externalScraperModule.ProcessorModule.Run(oEpisode, Enums.AddonEventType.Scrape_TVEpisode, Nothing)

                    If ret.bCancelled Then Return ret.bCancelled

                    If ret.ScraperResult_Data IsNot Nothing Then
                        ScrapedList.Add(ret.ScraperResult_Data)

                        'set new informations for following scrapers
                        If ret.ScraperResult_Data.AiredSpecified Then
                            oEpisode.MainDetails.Aired = ret.ScraperResult_Data.Aired
                        End If
                        If ret.ScraperResult_Data.EpisodeSpecified Then
                            oEpisode.MainDetails.Episode = ret.ScraperResult_Data.Episode
                        End If
                        If ret.ScraperResult_Data.IMDBSpecified Then
                            oEpisode.MainDetails.IMDB = ret.ScraperResult_Data.IMDB
                        End If
                        If ret.ScraperResult_Data.SeasonSpecified Then
                            oEpisode.MainDetails.Season = ret.ScraperResult_Data.Season
                        End If
                        If ret.ScraperResult_Data.TitleSpecified Then
                            oEpisode.MainDetails.Title = ret.ScraperResult_Data.Title
                        End If
                        If ret.ScraperResult_Data.TMDBSpecified Then
                            oEpisode.MainDetails.TMDB = ret.ScraperResult_Data.TMDB
                        End If
                        If ret.ScraperResult_Data.TVDBSpecified Then
                            oEpisode.MainDetails.TVDB = ret.ScraperResult_Data.TVDB
                        End If
                    End If
                    If ret.bBreakChain Then Exit For
                Next

                'Merge scraperresults considering global datascraper settings
                tDBElement = NFO.MergeDataScraperResults_TVEpisode_Single(tDBElement, ScrapedList)

                'create cache paths for Actor Thumbs
                tDBElement.MainDetails.CreateCachePaths_ActorsThumbs()
            End If

            If ScrapedList.Count > 0 Then
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVEpisode] [Done] {0}", tDBElement.Filename))
            Else
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVEpisode] [Done] [No Scraper Results] {0}", tDBElement.Filename))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVEpisode] [Abort] [Offline] {0}", tDBElement.Filename))
            Return True 'Cancelled
        End If
    End Function

    Public Function ScrapeData_TVSeason(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVSeason] [Start] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.AddonResult
            Dim ScrapedList As New List(Of MediaContainers.MainDetails)

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'create a clone of DBTV
            Dim oSeason As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

            If (modules.Count() <= 0) Then
                logger.Warn("[AddonsManager] [ScrapeData_TVSeason] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVSeason] [Using] {0}", _externalScraperModule.ProcessorModule.Name))

                    ret = _externalScraperModule.ProcessorModule.Run(oSeason, Enums.AddonEventType.Scrape_TVSeason, Nothing)

                    If ret.bCancelled Then Return ret.bCancelled

                    If ret.ScraperResult_Data IsNot Nothing Then
                        ScrapedList.Add(ret.ScraperResult_Data)

                        'set new informations for following scrapers
                        If ret.ScraperResult_Data.TMDBSpecified Then
                            oSeason.MainDetails.TMDB = ret.ScraperResult_Data.TMDB
                        End If
                        If ret.ScraperResult_Data.TVDBSpecified Then
                            oSeason.MainDetails.TVDB = ret.ScraperResult_Data.TVDB
                        End If
                    End If
                    If ret.bBreakChain Then Exit For
                Next

                'Merge scraperresults considering global datascraper settings
                tDBElement = NFO.MergeDataScraperResults_TVSeason(tDBElement, ScrapedList)
            End If

            If ScrapedList.Count > 0 Then
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVSeason] [Done] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
            Else
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVSeason] [Done] [No Scraper Results] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVSeason] [Abort] [Offline] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
            Return True 'Cancelled
        End If
    End Function
    ''' <summary>
    ''' Request that enabled movie scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">Show to be scraped</param> 
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks>Note that if no movie scrapers are enabled, a silent warning is generated.</remarks>
    Public Function ScrapeData_TVShow(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVShow] [Start] {0}", tDBElement.MainDetails.Title))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.AddonResult
            Dim ScrapedList As New List(Of MediaContainers.MainDetails)

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'clean DBTV if the tv show is to be changed. For this, all existing (incorrect) information must be deleted and the images triggers set to remove.
            If (tDBElement.ScrapeType = Enums.ScrapeType.SingleScrape OrElse tDBElement.ScrapeType = Enums.ScrapeType.SingleAuto) AndAlso tDBElement.ScrapeModifiers.DoSearch Then
                tDBElement.ExtrafanartsPath = String.Empty
                tDBElement.ImagesContainer = New MediaContainers.ImagesContainer
                tDBElement.NfoPath = String.Empty
                tDBElement.Seasons.Clear()
                tDBElement.Theme = New MediaContainers.Theme
                tDBElement.MainDetails = New MediaContainers.MainDetails

                tDBElement.MainDetails.Title = StringUtils.FilterTitleFromPath_TVShow(tDBElement.ShowPath)

                For Each sEpisode As Database.DBElement In tDBElement.Episodes
                    Dim iEpisode As Integer = sEpisode.MainDetails.Episode
                    Dim iSeason As Integer = sEpisode.MainDetails.Season
                    Dim strAired As String = sEpisode.MainDetails.Aired
                    sEpisode.ImagesContainer = New MediaContainers.ImagesContainer
                    sEpisode.NfoPath = String.Empty
                    sEpisode.MainDetails = New MediaContainers.MainDetails With {.Aired = strAired, .Episode = iEpisode, .Season = iSeason}
                Next
            End If

            'create a clone of DBTV
            Dim oShow As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

            If (modules.Count() <= 0) Then
                logger.Warn("[AddonsManager] [ScrapeData_TVShow] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVShow] [Using] {0}", _externalScraperModule.ProcessorModule.Name))

                    ret = _externalScraperModule.ProcessorModule.Run(oShow, Enums.AddonEventType.Scrape_TVShow, Nothing)

                    If ret.bCancelled Then Return ret.bCancelled

                    If ret.ScraperResult_Data IsNot Nothing Then
                        ScrapedList.Add(ret.ScraperResult_Data)

                        'set new informations for following scrapers
                        If ret.ScraperResult_Data.IMDBSpecified Then
                            oShow.MainDetails.IMDB = ret.ScraperResult_Data.IMDB
                        End If
                        If ret.ScraperResult_Data.OriginalTitleSpecified Then
                            oShow.MainDetails.OriginalTitle = ret.ScraperResult_Data.OriginalTitle
                        End If
                        If ret.ScraperResult_Data.TitleSpecified Then
                            oShow.MainDetails.Title = ret.ScraperResult_Data.Title
                        End If
                        If ret.ScraperResult_Data.TMDBSpecified Then
                            oShow.MainDetails.TMDB = ret.ScraperResult_Data.TMDB
                        End If
                        If ret.ScraperResult_Data.TVDBSpecified Then
                            oShow.MainDetails.TVDB = ret.ScraperResult_Data.TVDB
                        End If
                    End If
                    If ret.bBreakChain Then Exit For
                Next

                'Merge scraperresults considering global datascraper settings
                tDBElement = NFO.MergeDataScraperResults_TV(tDBElement, ScrapedList)

                'create cache paths for Actor Thumbs
                tDBElement.MainDetails.CreateCachePaths_ActorsThumbs()
                If tDBElement.ScrapeModifiers.withEpisodes Then
                    For Each tEpisode As Database.DBElement In tDBElement.Episodes
                        tEpisode.MainDetails.CreateCachePaths_ActorsThumbs()
                    Next
                End If
            End If

            If ScrapedList.Count > 0 Then
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVShow] [Done] {0}", tDBElement.MainDetails.Title))
            Else
                logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVShow] [Done] [No Scraper Results] {0}", tDBElement.MainDetails.Title))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeData_TVShow] [Abort] [Offline] {0}", tDBElement.MainDetails.Title))
            Return True 'Cancelled
        End If
    End Function
    ''' <summary>
    ''' Request that enabled movie image scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">Movie to be scraped. Scraper will directly manipulate this structure</param>
    ''' <param name="ImagesContainer">Container of images that the scraper should add to</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks>Note that if no movie scrapers are enabled, a silent warning is generated.</remarks>
    Public Function ScrapeImage_Movie(ByRef tDBElement As Database.DBElement, ByRef ImagesContainer As MediaContainers.SearchResultsContainer, ByVal ScrapeModifiers As Structures.ScrapeModifiers, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeImage_Movie] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(tDBElement, bShowMessage) Then
            Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.AddonResult

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            If (modules.Count() <= 0) Then
                logger.Warn("[AddonsManager] [ScrapeImage_Movie] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[AddonsManager] [ScrapeImage_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.Name))
                    If QueryScraperCapabilities_Image_Movie(_externalScraperModule, ScrapeModifiers) Then
                        ret = _externalScraperModule.ProcessorModule.Run(tDBElement, Enums.AddonEventType.Scrape_Movie, Nothing)
                        If ret.ScraperResult_Image IsNot Nothing Then
                            ImagesContainer.MainBanners.AddRange(ret.ScraperResult_Image.MainBanners)
                            ImagesContainer.MainCharacterArts.AddRange(ret.ScraperResult_Image.MainCharacterArts)
                            ImagesContainer.MainClearArts.AddRange(ret.ScraperResult_Image.MainClearArts)
                            ImagesContainer.MainClearLogos.AddRange(ret.ScraperResult_Image.MainClearLogos)
                            ImagesContainer.MainDiscArts.AddRange(ret.ScraperResult_Image.MainDiscArts)
                            ImagesContainer.MainFanarts.AddRange(ret.ScraperResult_Image.MainFanarts)
                            ImagesContainer.MainLandscapes.AddRange(ret.ScraperResult_Image.MainLandscapes)
                            ImagesContainer.MainPosters.AddRange(ret.ScraperResult_Image.MainPosters)
                        End If
                        If ret.bBreakChain Then Exit For
                    End If
                Next

                'sorting
                ImagesContainer.SortAndFilter(tDBElement)

                'create cache paths
                ImagesContainer.CreateCachePaths(tDBElement)
            End If

            logger.Trace(String.Format("[AddonsManager] [ScrapeImage_Movie] [Done] {0}", tDBElement.Filename))
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeImage_Movie] [Abort] [Offline] {0}", tDBElement.Filename))
            Return True 'Cancelled
        End If
    End Function
    ''' <summary>
    ''' Request that enabled movieset image scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">Movieset to be scraped. Scraper will directly manipulate this structure</param>
    ''' <param name="ImagesContainer">Container of images that the scraper should add to</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks>Note that if no movie scrapers are enabled, a silent warning is generated.</remarks>
    Public Function ScrapeImage_MovieSet(ByRef tDBElement As Database.DBElement, ByRef ImagesContainer As MediaContainers.SearchResultsContainer, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeImage_MovieSet] [Start] {0}", tDBElement.MainDetails.Title))
        Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.AddonResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[AddonsManager] [ScrapeImage_MovieSet] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[AddonsManager] [ScrapeImage_MovieSet] [Using] {0}", _externalScraperModule.ProcessorModule.Name))
                If QueryScraperCapabilities_Image_MovieSet(_externalScraperModule, ScrapeModifiers) Then
                    ret = _externalScraperModule.ProcessorModule.Run(tDBElement, Enums.AddonEventType.Scrape_MovieSet, Nothing)
                    If ret.ScraperResult_Image IsNot Nothing Then
                        ImagesContainer.MainBanners.AddRange(ret.ScraperResult_Image.MainBanners)
                        ImagesContainer.MainCharacterArts.AddRange(ret.ScraperResult_Image.MainCharacterArts)
                        ImagesContainer.MainClearArts.AddRange(ret.ScraperResult_Image.MainClearArts)
                        ImagesContainer.MainClearLogos.AddRange(ret.ScraperResult_Image.MainClearLogos)
                        ImagesContainer.MainDiscArts.AddRange(ret.ScraperResult_Image.MainDiscArts)
                        ImagesContainer.MainFanarts.AddRange(ret.ScraperResult_Image.MainFanarts)
                        ImagesContainer.MainLandscapes.AddRange(ret.ScraperResult_Image.MainLandscapes)
                        ImagesContainer.MainPosters.AddRange(ret.ScraperResult_Image.MainPosters)
                    End If
                    If ret.bBreakChain Then Exit For
                End If
            Next

            'sorting
            ImagesContainer.SortAndFilter(tDBElement)

            'create cache paths
            ImagesContainer.CreateCachePaths(tDBElement)
        End If

        logger.Trace(String.Format("[AddonsManager] [ScrapeImage_MovieSet] [Done] {0}", tDBElement.MainDetails.Title))
        Return ret.bCancelled
    End Function
    ''' <summary>
    ''' Request that enabled tv image scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">TV Show to be scraped. Scraper will directly manipulate this structure</param>
    ''' <param name="ScrapeModifiers">What kind of image is being scraped (poster, fanart, etc)</param>
    ''' <param name="ImagesContainer">Container of images that the scraper should add to</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks>Note that if no movie scrapers are enabled, a silent warning is generated.</remarks>
    Public Function ScrapeImage_TV(ByRef tDBElement As Database.DBElement, ByRef ImagesContainer As MediaContainers.SearchResultsContainer, ByVal ScrapeModifiers As Structures.ScrapeModifiers, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeImage_TV] [Start] {0}", tDBElement.MainDetails.Title))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.AddonResult

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'workaround to get MainFanarts for AllSeasonsFanarts, EpisodeFanarts and SeasonFanarts,
            'also get MainBanners, MainLandscapes and MainPosters for AllSeasonsBanners, AllSeasonsLandscapes and AllSeasonsPosters
            If ScrapeModifiers.AllSeasonsBanner Then
                ScrapeModifiers.MainBanner = True
                ScrapeModifiers.SeasonBanner = True
            End If
            If ScrapeModifiers.AllSeasonsFanart Then
                ScrapeModifiers.MainFanart = True
                ScrapeModifiers.SeasonFanart = True
            End If
            If ScrapeModifiers.AllSeasonsLandscape Then
                ScrapeModifiers.MainLandscape = True
                ScrapeModifiers.SeasonLandscape = True
            End If
            If ScrapeModifiers.AllSeasonsPoster Then
                ScrapeModifiers.MainPoster = True
                ScrapeModifiers.SeasonPoster = True
            End If
            If ScrapeModifiers.EpisodeFanart Then
                ScrapeModifiers.MainFanart = True
            End If
            If ScrapeModifiers.MainExtrafanarts Then
                ScrapeModifiers.MainFanart = True
            End If
            If ScrapeModifiers.MainExtrathumbs Then
                ScrapeModifiers.MainFanart = True
            End If
            If ScrapeModifiers.SeasonFanart Then
                ScrapeModifiers.MainFanart = True
            End If

            If (modules.Count() <= 0) Then
                logger.Warn("[AddonsManager] [ScrapeImage_TV] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[AddonsManager] [ScrapeImage_TV] [Using] {0}", _externalScraperModule.ProcessorModule.Name))
                    If QueryScraperCapabilities_Image_TV(_externalScraperModule, ScrapeModifiers) Then
                        ret = _externalScraperModule.ProcessorModule.Run(tDBElement, Enums.AddonEventType.Scrape_TVShow, Nothing)
                        If ret.ScraperResult_Image IsNot Nothing Then
                            ImagesContainer.EpisodeFanarts.AddRange(ret.ScraperResult_Image.EpisodeFanarts)
                            ImagesContainer.EpisodePosters.AddRange(ret.ScraperResult_Image.EpisodePosters)
                            ImagesContainer.SeasonBanners.AddRange(ret.ScraperResult_Image.SeasonBanners)
                            ImagesContainer.SeasonFanarts.AddRange(ret.ScraperResult_Image.SeasonFanarts)
                            ImagesContainer.SeasonLandscapes.AddRange(ret.ScraperResult_Image.SeasonLandscapes)
                            ImagesContainer.SeasonPosters.AddRange(ret.ScraperResult_Image.SeasonPosters)
                            ImagesContainer.MainBanners.AddRange(ret.ScraperResult_Image.MainBanners)
                            ImagesContainer.MainCharacterArts.AddRange(ret.ScraperResult_Image.MainCharacterArts)
                            ImagesContainer.MainClearArts.AddRange(ret.ScraperResult_Image.MainClearArts)
                            ImagesContainer.MainClearLogos.AddRange(ret.ScraperResult_Image.MainClearLogos)
                            ImagesContainer.MainFanarts.AddRange(ret.ScraperResult_Image.MainFanarts)
                            ImagesContainer.MainLandscapes.AddRange(ret.ScraperResult_Image.MainLandscapes)
                            ImagesContainer.MainPosters.AddRange(ret.ScraperResult_Image.MainPosters)
                        End If
                        If ret.bBreakChain Then Exit For
                    End If
                Next

                'sorting
                ImagesContainer.SortAndFilter(tDBElement)

                'create cache paths
                ImagesContainer.CreateCachePaths(tDBElement)
            End If

            logger.Trace(String.Format("[AddonsManager] [ScrapeImage_TV] [Done] {0}", tDBElement.MainDetails.Title))
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[AddonsManager] [ScrapeImage_Movie] [Abort] [Offline] {0}", tDBElement.Filename))
            Return True 'Cancelled
        End If
    End Function
    ''' <summary>
    ''' Request that enabled movie theme scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">Movie to be scraped. Scraper will directly manipulate this structure</param>
    ''' <param name="Type">NOT ACTUALLY USED!</param>
    ''' <param name="ThemeList">List of Theme objects that the scraper will append to.</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks></remarks>
    Public Function ScrapeTheme_Movie(ByRef tDBElement As Database.DBElement, ByVal Type As Enums.ScrapeModifierType, ByRef ThemeList As List(Of MediaContainers.Theme)) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeTheme_Movie] [Start] {0}", tDBElement.Filename))
        Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.AddonResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[AddonsManager] [ScrapeTheme_Movie] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[AddonsManager] [ScrapeTheme_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.Name))
                ret = _externalScraperModule.ProcessorModule.Run(tDBElement, Enums.AddonEventType.Scrape_Movie, Nothing)
                If ret.ScraperResult_Theme IsNot Nothing Then
                    ThemeList.AddRange(ret.ScraperResult_Theme)
                End If
                If ret.bBreakChain Then Exit For
            Next
        End If
        logger.Trace(String.Format("[AddonsManager] [ScrapeTheme_Movie] [Done] {0}", tDBElement.Filename))
        Return ret.bCancelled
    End Function
    ''' <summary>
    ''' Request that enabled tvshow theme scrapers perform their functions on the supplied tv show
    ''' </summary>
    ''' <param name="tDBElement">TV Show to be scraped. Scraper will directly manipulate this structure</param>
    ''' <param name="Type">NOT ACTUALLY USED!</param>
    ''' <param name="ThemeList">List of Theme objects that the scraper will append to.</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks></remarks>
    Public Function ScrapeTheme_TVShow(ByRef tDBElement As Database.DBElement, ByVal Type As Enums.ScrapeModifierType, ByRef ThemeList As List(Of MediaContainers.Theme)) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeTheme_TVShow] [Start] {0}", tDBElement.MainDetails.Title))
        Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.AddonResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[AddonsManager] [ScrapeTheme_TVShow] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[AddonsManager] [ScrapeTheme_TVShow] [Using] {0}", _externalScraperModule.ProcessorModule.Name))
                ret = _externalScraperModule.ProcessorModule.Run(tDBElement, Enums.AddonEventType.Scrape_TVShow, Nothing)
                If ret.ScraperResult_Theme IsNot Nothing Then
                    ThemeList.AddRange(ret.ScraperResult_Theme)
                End If
                If ret.bBreakChain Then Exit For
            Next
        End If
        logger.Trace(String.Format("[AddonsManager] [ScrapeTheme_TVShow] [Done] {0}", tDBElement.MainDetails.Title))
        Return ret.bCancelled
    End Function
    ''' <summary>
    ''' Request that enabled movie trailer scrapers perform their functions on the supplied movie
    ''' </summary>
    ''' <param name="tDBElement">Movie to be scraped. Scraper will directly manipulate this structure</param>
    ''' <param name="Type">NOT ACTUALLY USED!</param>
    ''' <param name="TrailerList">List of Trailer objects that the scraper will append to. Note that only the URL is returned, 
    ''' not the full content of the trailer</param>
    ''' <returns><c>True</c> if one of the scrapers was cancelled</returns>
    ''' <remarks></remarks>
    Public Function ScrapeTrailer_Movie(ByRef tDBElement As Database.DBElement, ByVal Type As Enums.ScrapeModifierType, ByRef TrailerList As List(Of MediaContainers.Trailer)) As Boolean
        logger.Trace(String.Format("[AddonsManager] [ScrapeTrailer_Movie] [Start] {0}", tDBElement.Filename))
        Dim modules = Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.AddonResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[AddonsManager] [ScrapeTrailer_Movie] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[AddonsManager] [ScrapeTrailer_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.Name))
                ret = _externalScraperModule.ProcessorModule.Run(tDBElement, Enums.AddonEventType.Scrape_Movie, Nothing)
                If ret.ScraperResult_Trailer IsNot Nothing Then
                    TrailerList.AddRange(ret.ScraperResult_Trailer)
                End If
                If ret.bBreakChain Then Exit For
            Next
        End If
        logger.Trace(String.Format("[AddonsManager] [ScrapeTrailer_Movie] [Done] {0}", tDBElement.Filename))
        Return ret.bCancelled
    End Function

    Function ScraperWithCapabilityAnyEnabled(ByVal tContentType As Enums.ContentType, ByVal tImageType As Enums.ScrapeModifierType) As Boolean
        Dim bResult As Boolean
        Select Case tContentType
            Case Enums.ContentType.Movie
                Return ScraperWithCapabilityAnyEnabled_Image_Movie(tImageType)
            Case Enums.ContentType.MovieSet
                Return ScraperWithCapabilityAnyEnabled_Image_MovieSet(tImageType)
            Case Enums.ContentType.TV, Enums.ContentType.TVEpisode, Enums.ContentType.TVSeason, Enums.ContentType.TVShow
                Return ScraperWithCapabilityAnyEnabled_Image_TV(tImageType)
        End Select
        Return bResult
    End Function

    Function ScraperWithCapabilityAnyEnabled_Image_Movie(ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = True 'TODO: fix
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        'For Each _externalScraperModule As AddonClass In Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        '    Try
        '        ret = QueryScraperCapabilities_Image_Movie(_externalScraperModule, ImageType)
        '        If ret Then Exit For
        '    Catch ex As Exception
        '    End Try
        'Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Image_MovieSet(ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = True 'TODO: fix
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        'For Each _externalScraperModule As AddonClass In Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        '    Try
        '        ret = QueryScraperCapabilities_Image_MovieSet(_externalScraperModule, ImageType)
        '        If ret Then Exit For
        '    Catch ex As Exception
        '    End Try
        'Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Image_TV(ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = True 'TODO: fix
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        'For Each _externalScraperModule As AddonClass In Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        '    Try
        '        ret = QueryScraperCapabilities_Image_TV(_externalScraperModule, ImageType)
        '        If ret Then Exit For
        '    Catch ex As Exception
        '    End Try
        'Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Theme_Movie(ByVal cap As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = True 'TODO: fix
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        'For Each _externalScraperModule As AddonClass In Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        '    Try
        '        ret = True 'if a theme scraper is enabled we can exit.
        '        Exit For
        '    Catch ex As Exception
        '    End Try
        'Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Theme_TV(ByVal cap As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = True 'TODO: fix
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        'For Each _externalScraperModule As AddonClass In Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        '    Try
        '        ret = True 'if a theme scraper is enabled we can exit.
        '        Exit For
        '    Catch ex As Exception
        '    End Try
        'Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Trailer_Movie(ByVal cap As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = True 'TODO: fix
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        'For Each _externalScraperModule As AddonClass In Addons '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        '    Try
        '        ret = True 'if a trailer scraper is enabled we can exit.
        '        Exit For
        '    Catch ex As Exception
        '    End Try
        'Next
        Return ret
    End Function

    Private Sub GenericRunCallBack(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object))
        RaiseEvent GenericEvent(mType, _params)
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure AssemblyListItem

#Region "Fields"

        Public Assembly As System.Reflection.Assembly
        Public AssemblyName As String

#End Region 'Fields

    End Structure

    Structure VersionItem

#Region "Fields"

        Public AssemblyFileName As String
        Public Name As String
        Public NeedUpdate As Boolean
        Public Version As String

#End Region 'Fields

    End Structure

    Class EmberRuntimeObjects

#Region "Fields"

        Private _ContextMenuMovieList As ContextMenuStrip
        Private _ContextMenuMovieSetList As ContextMenuStrip
        Private _ContextMenuTVEpisodeList As ContextMenuStrip
        Private _ContextMenuTVSeasonList As ContextMenuStrip
        Private _ContextMenuTVShowList As ContextMenuStrip
        Private _FilterMovies As String
        Private _FilterMoviesSearch As String
        Private _FilterMoviesType As String
        Private _FilterTVShows As String
        Private _FilterTVShowsSearch As String
        Private _FilterTVShowsType As String
        Private _ListMovieSets As String
        Private _ListMovies As String
        Private _ListTVShows As String
        Private _LoadMedia As LoadMedia
        Private _MainMenu As MenuStrip
        Private _MainTabControl As TabControl
        Private _MainToolStrip As ToolStrip
        Private _MediaListMovieSets As DataGridView
        Private _MediaListMovies As DataGridView
        Private _MediaListTVEpisodes As DataGridView
        Private _MediaListTVSeasons As DataGridView
        Private _MediaListTVShows As DataGridView
        Private _MediaTabSelected As Structures.MainTabType
        Private _OpenImageViewer As OpenImageViewer
        Private _TrayMenu As ContextMenuStrip


#End Region 'Fields

#Region "Delegates"

        Delegate Sub LoadMedia(ByVal Scan As Structures.ScanOrClean, ByVal SourceID As Long)

        'all runtime object including Function (delegate) that need to be exposed to Modules
        Delegate Sub OpenImageViewer(ByVal _Image As Image)

#End Region 'Delegates

#Region "Properties"

        Public Property ListMovies() As String
            Get
                Return If(_ListMovies IsNot Nothing, _ListMovies, "movielist")
            End Get
            Set(ByVal value As String)
                _ListMovies = value
            End Set
        End Property

        Public Property ListMovieSets() As String
            Get
                Return If(_ListMovieSets IsNot Nothing, _ListMovieSets, "setslist")
            End Get
            Set(ByVal value As String)
                _ListMovieSets = value
            End Set
        End Property

        Public Property ListTVShows() As String
            Get
                Return If(_ListTVShows IsNot Nothing, _ListTVShows, "tvshowlist")
            End Get
            Set(ByVal value As String)
                _ListTVShows = value
            End Set
        End Property

        Public Property FilterMovies() As String
            Get
                Return _FilterMovies
            End Get
            Set(ByVal value As String)
                _FilterMovies = value
            End Set
        End Property

        Public Property FilterMoviesSearch() As String
            Get
                Return _FilterMoviesSearch
            End Get
            Set(ByVal value As String)
                _FilterMoviesSearch = value
            End Set
        End Property

        Public Property FilterMoviesType() As String
            Get
                Return _FilterMoviesType
            End Get
            Set(ByVal value As String)
                _FilterMoviesType = value
            End Set
        End Property
        Public Property FilterTVShows() As String
            Get
                Return _FilterTVShows
            End Get
            Set(ByVal value As String)
                _FilterTVShows = value
            End Set
        End Property

        Public Property FilterTVShowsSearch() As String
            Get
                Return _FilterTVShowsSearch
            End Get
            Set(ByVal value As String)
                _FilterTVShowsSearch = value
            End Set
        End Property

        Public Property FilterTVShowsType() As String
            Get
                Return _FilterTVShowsType
            End Get
            Set(ByVal value As String)
                _FilterTVShowsType = value
            End Set
        End Property

        Public Property MediaTabSelected() As Structures.MainTabType
            Get
                Return _MediaTabSelected
            End Get
            Set(ByVal value As Structures.MainTabType)
                _MediaTabSelected = value
            End Set
        End Property

        Public Property MainToolStrip() As ToolStrip
            Get
                Return _MainToolStrip
            End Get
            Set(ByVal value As ToolStrip)
                _MainToolStrip = value
            End Set
        End Property

        Public Property MediaListMovies() As DataGridView
            Get
                Return _MediaListMovies
            End Get
            Set(ByVal value As DataGridView)
                _MediaListMovies = value
            End Set
        End Property

        Public Property MediaListMovieSets() As DataGridView
            Get
                Return _MediaListMovieSets
            End Get
            Set(ByVal value As DataGridView)
                _MediaListMovieSets = value
            End Set
        End Property

        Public Property MediaListTVEpisodes() As DataGridView
            Get
                Return _MediaListTVEpisodes
            End Get
            Set(ByVal value As DataGridView)
                _MediaListTVEpisodes = value
            End Set
        End Property

        Public Property MediaListTVSeasons() As DataGridView
            Get
                Return _MediaListTVSeasons
            End Get
            Set(ByVal value As DataGridView)
                _MediaListTVSeasons = value
            End Set
        End Property

        Public Property MediaListTVShows() As DataGridView
            Get
                Return _MediaListTVShows
            End Get
            Set(ByVal value As DataGridView)
                _MediaListTVShows = value
            End Set
        End Property

        Public Property ContextMenuMovieList() As ContextMenuStrip
            Get
                Return _ContextMenuMovieList
            End Get
            Set(ByVal value As ContextMenuStrip)
                _ContextMenuMovieList = value
            End Set
        End Property

        Public Property ContextMenuMovieSetList() As ContextMenuStrip
            Get
                Return _ContextMenuMovieSetList
            End Get
            Set(ByVal value As ContextMenuStrip)
                _ContextMenuMovieSetList = value
            End Set
        End Property

        Public Property ContextMenuTVEpisodeList() As ContextMenuStrip
            Get
                Return _ContextMenuTVEpisodeList
            End Get
            Set(ByVal value As ContextMenuStrip)
                _ContextMenuTVEpisodeList = value
            End Set
        End Property

        Public Property ContextMenuTVSeasonList() As ContextMenuStrip
            Get
                Return _ContextMenuTVSeasonList
            End Get
            Set(ByVal value As ContextMenuStrip)
                _ContextMenuTVSeasonList = value
            End Set
        End Property

        Public Property ContextMenuTVShowList() As ContextMenuStrip
            Get
                Return _ContextMenuTVShowList
            End Get
            Set(ByVal value As ContextMenuStrip)
                _ContextMenuTVShowList = value
            End Set
        End Property

        Public Property MainMenu() As MenuStrip
            Get
                Return _MainMenu
            End Get
            Set(ByVal value As MenuStrip)
                _MainMenu = value
            End Set
        End Property

        Public Property TrayMenu() As ContextMenuStrip
            Get
                Return _TrayMenu
            End Get
            Set(ByVal value As ContextMenuStrip)
                _TrayMenu = value
            End Set
        End Property

        Public Property MainTabControl() As TabControl
            Get
                Return _MainTabControl
            End Get
            Set(ByVal value As TabControl)
                _MainTabControl = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub DelegateLoadMedia(ByRef lm As LoadMedia)
            'Setup from EmberAPP
            _LoadMedia = lm
        End Sub

        Public Sub DelegateOpenImageViewer(ByRef IV As OpenImageViewer)
            _OpenImageViewer = IV
        End Sub

        Public Sub InvokeLoadMedia(ByVal Scan As Structures.ScanOrClean, Optional ByVal SourceID As Long = -1)
            'Invoked from Modules
            _LoadMedia.Invoke(Scan, SourceID)
        End Sub

        Public Sub InvokeOpenImageViewer(ByRef _image As Image)
            _OpenImageViewer.Invoke(_image)
        End Sub

#End Region 'Methods

    End Class

    Class AddonClass

#Region "Fields"

        Public AssemblyFileName As String
        Public AssemblyName As String
        Public ProcessorModule As Interfaces.Addon
        'Public Type As List(Of Enums.ModuleEventType)

#End Region 'Fields

    End Class

    '    Class _externalScraperModuleClass_Data_Movie

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Data_Movie 'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.Movie

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Data_MovieSet

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Data_MovieSet 'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.MovieSet

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Data_TV

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Data_TV 'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.TV

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Image_Movie

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Image_Movie  'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.Movie

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Image_MovieSet

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Image_MovieSet  'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.MovieSet

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Image_TV

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Image_TV  'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.TV

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Theme_Movie

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Theme_Movie     'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.Movie

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Theme_TV

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Theme_TV  'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.TV

    '#End Region 'Fields

    '    End Class

    '    Class _externalScraperModuleClass_Trailer_Movie

    '#Region "Fields"

    '        Public AssemblyFileName As String
    '        Public AssemblyName As String
    '        Public ProcessorModule As Interfaces.ScraperModule_Trailer_Movie     'Object
    '        Public ModuleOrder As Integer
    '        Public ContentType As Enums.ContentType = Enums.ContentType.Movie

    '#End Region 'Fields

    '    End Class

    <XmlRoot("Addon")>
    Class _XMLAddonClass

#Region "Fields"

        Public strAssemblyFileName As String
        Public strAssemblyName As String
        Public bEnabled As Boolean

#End Region 'Fields

    End Class

#End Region 'Nested Types

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class