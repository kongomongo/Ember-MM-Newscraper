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

Public Class ModulesManager

#Region "Fields"
    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Public Shared AssemblyList As New List(Of AssemblyListItem)
    Public Shared VersionList As New List(Of VersionItem)

    Public _externalmodules As New List(Of ExternalModuleClass)
    Public _externalgenericmodules As New List(Of ExternalGenericModuleClass)
    Public RuntimeObjects As New EmberRuntimeObjects

    'Singleton Instace for module manager .. allways use this one
    Private Shared Singleton As ModulesManager = Nothing

    Private moduleLocation As String = Path.Combine(Functions.AppPath, "Modules")

    Friend WithEvents bwLoadModules As New System.ComponentModel.BackgroundWorker

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object))
    Event ScraperEvent_Movie(ByVal eType As Enums.ScraperEventType, ByVal Parameter As Object)
    Event ScraperEvent_MovieSet(ByVal eType As Enums.ScraperEventType, ByVal Parameter As Object)
    Event ScraperEvent_TV(ByVal eType As Enums.ScraperEventType, ByVal Parameter As Object)

#End Region 'Events

#Region "Properties"

    Public Shared ReadOnly Property Instance() As ModulesManager
        Get
            If (Singleton Is Nothing) Then
                Singleton = New ModulesManager()
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
        For Each nExternalModule As ExternalModuleClass In _externalmodules
            VersionList.Add(New VersionItem With {.Name = nExternalModule.ProcessorModule.ModuleName,
              .AssemblyFileName = nExternalModule.AssemblyFileName,
              .Version = nExternalModule.ProcessorModule.ModuleVersion})
        Next
        For Each _externalModule As ExternalGenericModuleClass In _externalgenericmodules
            VersionList.Add(New VersionItem With {.Name = _externalModule.ProcessorModule.ModuleName,
              .AssemblyFileName = _externalModule.AssemblyFileName,
              .Version = _externalModule.ProcessorModule.ModuleVersion})
        Next
    End Sub

    Private Sub bwLoadModules_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLoadModules.DoWork
        LoadModules()
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

    Public Sub Handler_ScraperEvent_Movie(ByVal eType As Enums.ScraperEventType, ByVal Parameter As Object)
        RaiseEvent ScraperEvent_Movie(eType, Parameter)
    End Sub

    Public Sub Handler_ScraperEvent_MovieSet(ByVal eType As Enums.ScraperEventType, ByVal Parameter As Object)
        RaiseEvent ScraperEvent_MovieSet(eType, Parameter)
    End Sub

    Public Sub Handler_ScraperEvent_TV(ByVal eType As Enums.ScraperEventType, ByVal Parameter As Object)
        RaiseEvent ScraperEvent_TV(eType, Parameter)
    End Sub

    Public Sub LoadAllModules()
        bwLoadModules.RunWorkerAsync()
    End Sub

    Public Sub LoadModules()
        logger.Trace("[ModulesManager] [LoadModules] [Start]")

        If Directory.Exists(moduleLocation) Then
            'add each .dll file to AssemblyList
            For Each file As String In Directory.GetFiles(moduleLocation, "*.dll")
                Dim nAssembly As Reflection.Assembly = Reflection.Assembly.LoadFile(file)
                AssemblyList.Add(New ModulesManager.AssemblyListItem With {.Assembly = nAssembly, .AssemblyName = nAssembly.GetName.Name})
            Next

            For Each tAssemblyItem As AssemblyListItem In AssemblyList
                'Loop through each of the assemeblies type
                For Each fileType As Type In tAssemblyItem.Assembly.GetTypes

                    Dim fType As Type = fileType.GetInterface("GenericModule")
                    If Not fType Is Nothing Then
                        Dim ProcessorModule As Interfaces.GenericModule 'Object
                        ProcessorModule = CType(Activator.CreateInstance(fileType), Interfaces.GenericModule)

                        Dim GenericModule As New ExternalGenericModuleClass
                        GenericModule.ProcessorModule = ProcessorModule
                        GenericModule.AssemblyName = tAssemblyItem.AssemblyName
                        GenericModule.AssemblyFileName = tAssemblyItem.Assembly.ManifestModule.Name
                        GenericModule.Type = ProcessorModule.ModuleType
                        _externalgenericmodules.Add(GenericModule)

                        GenericModule.ProcessorModule.Init(GenericModule.AssemblyName, GenericModule.AssemblyFileName)

                        Dim bFound As Boolean = False
                        For Each i In Master.eSettings.EmberModules
                            If i.AssemblyName = GenericModule.AssemblyName Then
                                GenericModule.ProcessorModule.Enabled = i.GenericEnabled
                                bFound = True
                            End If
                        Next

                        'Enable all Core Modules by default if no setting was found
                        If Not bFound AndAlso GenericModule.AssemblyFileName.Contains("generic.EmberCore") Then
                            GenericModule.ProcessorModule.Enabled = True
                        End If
                        AddHandler ProcessorModule.GenericEvent, AddressOf GenericRunCallBack
                    End If

                    fType = fileType.GetInterface("ExternalModule")
                    If Not fType Is Nothing Then
                        Dim ProcessorModule As Interfaces.ExternalModule
                        ProcessorModule = CType(Activator.CreateInstance(fileType), Interfaces.ExternalModule)

                        Dim nExternalModule As New ExternalModuleClass
                        nExternalModule.ProcessorModule = ProcessorModule
                        nExternalModule.AssemblyName = tAssemblyItem.AssemblyName
                        nExternalModule.AssemblyFileName = tAssemblyItem.Assembly.ManifestModule.Name
                        _externalmodules.Add(nExternalModule)

                        logger.Info(String.Concat("[ModulesManager] [LoadModules] Module Added: ", nExternalModule.AssemblyName))

                        nExternalModule.ProcessorModule.Init(nExternalModule.AssemblyName)

                        For Each i As _XMLEmberModuleClass In Master.eSettings.EmberModules.Where(Function(f) f.AssemblyName = nExternalModule.AssemblyName)
                            nExternalModule.ProcessorModule.Enabled = i.ModuleEnabled
                        Next
                    End If
                Next
            Next
        Else
            logger.Warn("[ModulesManager] [LoadModules] No directory ""Modules"" found!")
        End If

        logger.Trace("[ModulesManager] [LoadModules] [Done]")
    End Sub

    Function QueryAnyGenericIsBusy() As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Dim modules As IEnumerable(Of ExternalGenericModuleClass) = _externalgenericmodules.Where(Function(e) e.ProcessorModule.IsBusy)
        If modules.Count() > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function QueryScraperCapabilities_Image_Movie(ByVal tExternalModule As ExternalModuleClass, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If ScrapeModifiers.MainBanner AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainBanner, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainClearArt AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainClearArt, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainClearLogo AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainClearLogo, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainDiscArt AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainDiscArt, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainExtrafanarts AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainExtrathumbs AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainFanart AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainLandscape AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainLandscape, Enums.ContentType.Movie) Then Return True
        If ScrapeModifiers.MainPoster AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainPoster, Enums.ContentType.Movie) Then Return True

        Return False
    End Function

    Function QueryScraperCapabilities_Image_Movie(ByVal tExternalModule As ExternalModuleClass, ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Select Case ImageType
            Case Enums.ScrapeModifierType.MainExtrafanarts
                Return tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.Movie)
            Case Enums.ScrapeModifierType.MainExtrathumbs
                Return tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.Movie)
            Case Else
                Return tExternalModule.ProcessorModule.QueryScraperCapabilities(ImageType, Enums.ContentType.Movie)
        End Select

        Return False
    End Function

    Function QueryScraperCapabilities_Image_MovieSet(ByVal tExternalModule As ExternalModuleClass, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If ScrapeModifiers.MainBanner AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainBanner, Enums.ContentType.MovieSet) Then Return True
        If ScrapeModifiers.MainClearArt AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainClearArt, Enums.ContentType.MovieSet) Then Return True
        If ScrapeModifiers.MainClearLogo AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainClearLogo, Enums.ContentType.MovieSet) Then Return True
        If ScrapeModifiers.MainDiscArt AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainDiscArt, Enums.ContentType.MovieSet) Then Return True
        If ScrapeModifiers.MainFanart AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.MovieSet) Then Return True
        If ScrapeModifiers.MainLandscape AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainLandscape, Enums.ContentType.MovieSet) Then Return True
        If ScrapeModifiers.MainPoster AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainPoster, Enums.ContentType.MovieSet) Then Return True

        Return False
    End Function

    Function QueryScraperCapabilities_Image_MovieSet(ByVal tExternalModule As ExternalModuleClass, ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Return tExternalModule.ProcessorModule.QueryScraperCapabilities(ImageType, Enums.ContentType.MovieSet)

        Return False
    End Function

    Function QueryScraperCapabilities_Image_TV(ByVal tExternalModule As ExternalModuleClass, ByVal ScrapeModifiers As Structures.ScrapeModifiers) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If ScrapeModifiers.EpisodeFanart AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.EpisodeFanart, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.EpisodePoster AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.EpisodePoster, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainBanner AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainBanner, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainCharacterArt AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainCharacterArt, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainClearArt AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainClearArt, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainClearLogo AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainClearLogo, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainFanart AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainLandscape AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainLandscape, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.MainPoster AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainPoster, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.SeasonBanner AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonBanner, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.SeasonFanart AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonFanart, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.SeasonLandscape AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonLandscape, Enums.ContentType.TV) Then Return True
        If ScrapeModifiers.SeasonPoster AndAlso tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonPoster, Enums.ContentType.TV) Then Return True

        Return False
    End Function

    Function QueryScraperCapabilities_Image_TV(ByVal tExternalModule As ExternalModuleClass, ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Select Case ImageType
            Case Enums.ScrapeModifierType.AllSeasonsBanner
                If tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainBanner, Enums.ContentType.TV) OrElse
                    tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonBanner, Enums.ContentType.TV) Then Return True
            Case Enums.ScrapeModifierType.AllSeasonsFanart
                If tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.TV) OrElse
                    tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonFanart, Enums.ContentType.TV) Then Return True
            Case Enums.ScrapeModifierType.AllSeasonsLandscape
                If tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainLandscape, Enums.ContentType.TV) OrElse
                    tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonLandscape, Enums.ContentType.TV) Then Return True
            Case Enums.ScrapeModifierType.AllSeasonsPoster
                If tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainPoster, Enums.ContentType.TV) OrElse
                    tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonPoster, Enums.ContentType.TV) Then Return True
            Case Enums.ScrapeModifierType.EpisodeFanart
                If tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.TV) OrElse
                    tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.EpisodeFanart, Enums.ContentType.TV) Then Return True
            Case Enums.ScrapeModifierType.MainExtrafanarts
                Return tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.TV)
            Case Enums.ScrapeModifierType.SeasonFanart
                If tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.MainFanart, Enums.ContentType.TV) OrElse
                    tExternalModule.ProcessorModule.QueryScraperCapabilities(Enums.ScrapeModifierType.SeasonFanart, Enums.ContentType.TV) Then Return True
            Case Else
                Return tExternalModule.ProcessorModule.QueryScraperCapabilities(ImageType, Enums.ContentType.TV)
        End Select

        Return False
    End Function
    ''' <summary>
    ''' Calls all the generic modules of the supplied type (if one is defined), passing the supplied _params.
    ''' The module will do its task and return any expected results in the _refparams.
    ''' </summary>
    ''' <param name="mType">The <c>Enums.ModuleEventType</c> of module to execute.</param>
    ''' <param name="_params">Parameters to pass to the module</param>
    ''' <param name="_singleobjekt"><c>Object</c> representing the module's result (if relevant)</param>
    ''' <param name="RunOnlyOne">If <c>True</c>, allow only one module to perform the required task.</param>
    ''' <returns></returns>
    ''' <remarks>Note that if any module returns a result of breakChain, no further modules are processed</remarks>
    Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), Optional ByVal _singleobjekt As Object = Nothing, Optional ByVal RunOnlyOne As Boolean = False, Optional ByRef DBElement As Database.DBElement = Nothing) As Boolean
        logger.Trace(String.Format("[ModulesManager] [RunGeneric] [Start] <{0}>", mType.ToString))
        Dim ret As Interfaces.ModuleResult_old

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        Try
            Dim modules As IEnumerable(Of ExternalGenericModuleClass) = _externalgenericmodules.Where(Function(e) e.ProcessorModule.ModuleType.Contains(mType) AndAlso e.ProcessorModule.Enabled)
            If (modules.Count() <= 0) Then
                logger.Warn("[ModulesManager] [RunGeneric] No generic modules defined <{0}>", mType.ToString)
            Else
                For Each _externalGenericModule As ExternalGenericModuleClass In modules
                    Try
                        logger.Trace("[ModulesManager] [RunGeneric] Run generic module <{0}>", _externalGenericModule.ProcessorModule.ModuleName)
                        ret = _externalGenericModule.ProcessorModule.RunGeneric(mType, _params, _singleobjekt, DBElement)
                    Catch ex As Exception
                        logger.Error("[ModulesManager] [RunGeneric] Run generic module <{0}>", _externalGenericModule.ProcessorModule.ModuleName)
                        logger.Error(ex, New StackFrame().GetMethod().Name)
                    End Try
                    If ret.breakChain OrElse RunOnlyOne Then Exit For
                Next
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try

        Return ret.Cancelled
    End Function

    Public Sub SaveSettings()
        Dim tmpForXML As New List(Of _XMLEmberModuleClass)

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        For Each nExternalModule As ExternalGenericModuleClass In _externalgenericmodules
            Dim t As New _XMLEmberModuleClass
            t.AssemblyName = nExternalModule.AssemblyName
            t.AssemblyFileName = nExternalModule.AssemblyFileName
            t.GenericEnabled = nExternalModule.ProcessorModule.Enabled
            t.ContentType = nExternalModule.ContentType
            tmpForXML.Add(t)
        Next
        For Each nExternalModule As ExternalModuleClass In _externalmodules
            Dim t As New _XMLEmberModuleClass
            t.AssemblyName = nExternalModule.AssemblyName
            t.AssemblyFileName = nExternalModule.AssemblyFileName
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeData_Movie] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(tDBElement, bShowMessage) Then
            Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.ModuleResult
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
                logger.Warn("[ModulesManager] [ScrapeData_Movie] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[ModulesManager] [ScrapeData_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))

                    ret = _externalScraperModule.ProcessorModule.Run(oDBMovie)

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
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_Movie] [Done] {0}", tDBElement.Filename))
            Else
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_Movie] [Done] [No Scraper Results] {0}", tDBElement.Filename))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeData_Movie] [Abort] [Offline] {0}", tDBElement.Filename))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeData_MovieSet] [Start] {0}", tDBElement.MainDetails.Title))
        'If DBMovieSet.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_MovieSet(DBMovieSet, showMessage) Then
        Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.ModuleResult
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
            logger.Warn("[ModulesManager] [ScrapeData_MovieSet] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_MovieSet] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))

                ret = _externalScraperModule.ProcessorModule.Run(oDBMovieSet)

                If ret.bCancelled Then
                    logger.Trace(String.Format("[ModulesManager] [ScrapeData_MovieSet] [Cancelled] [No Scraper Results] {0}", tDBElement.MainDetails.Title))
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
            logger.Trace(String.Format("[ModulesManager] [ScrapeData_MovieSet] [Done] {0}", tDBElement.MainDetails.Title))
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeData_MovieSet] [Done] [No Scraper Results] {0}", tDBElement.MainDetails.Title))
            Return True 'TODO: need a new trigger
        End If
        Return ret.bCancelled
        'Else
        'Return True 'Cancelled
        'End If
    End Function

    Public Function ScrapeData_TVEpisode(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVEpisode] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.ModuleResult
            Dim ScrapedList As New List(Of MediaContainers.MainDetails)

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'create a clone of DBTV
            Dim oEpisode As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

            If (modules.Count() <= 0) Then
                logger.Warn("[ModulesManager] [ScrapeData_TVEpisode] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVEpisode] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))

                    ret = _externalScraperModule.ProcessorModule.Run(oEpisode)

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
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVEpisode] [Done] {0}", tDBElement.Filename))
            Else
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVEpisode] [Done] [No Scraper Results] {0}", tDBElement.Filename))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVEpisode] [Abort] [Offline] {0}", tDBElement.Filename))
            Return True 'Cancelled
        End If
    End Function

    Public Function ScrapeData_TVSeason(ByRef tDBElement As Database.DBElement, ByVal bShowMessage As Boolean) As Boolean
        logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVSeason] [Start] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.ModuleResult
            Dim ScrapedList As New List(Of MediaContainers.MainDetails)

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            'create a clone of DBTV
            Dim oSeason As Database.DBElement = CType(tDBElement.CloneDeep, Database.DBElement)

            If (modules.Count() <= 0) Then
                logger.Warn("[ModulesManager] [ScrapeData_TVSeason] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVSeason] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))

                    ret = _externalScraperModule.ProcessorModule.Run(oSeason)

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
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVSeason] [Done] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
            Else
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVSeason] [Done] [No Scraper Results] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVSeason] [Abort] [Offline] {0}: Season {1}", tDBElement.TVShowDetails.Title, tDBElement.MainDetails.Season))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVShow] [Start] {0}", tDBElement.MainDetails.Title))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.ModuleResult
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
                logger.Warn("[ModulesManager] [ScrapeData_TVShow] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVShow] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))

                    ret = _externalScraperModule.ProcessorModule.Run(oShow)

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
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVShow] [Done] {0}", tDBElement.MainDetails.Title))
            Else
                logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVShow] [Done] [No Scraper Results] {0}", tDBElement.MainDetails.Title))
                Return True 'TODO: need a new trigger
            End If
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeData_TVShow] [Abort] [Offline] {0}", tDBElement.MainDetails.Title))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeImage_Movie] [Start] {0}", tDBElement.Filename))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_Movie(tDBElement, bShowMessage) Then
            Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.ModuleResult

            While Not ModulesLoaded
                Application.DoEvents()
            End While

            If (modules.Count() <= 0) Then
                logger.Warn("[ModulesManager] [ScrapeImage_Movie] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[ModulesManager] [ScrapeImage_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))
                    If QueryScraperCapabilities_Image_Movie(_externalScraperModule, ScrapeModifiers) Then
                        ret = _externalScraperModule.ProcessorModule.Run(tDBElement)
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

            logger.Trace(String.Format("[ModulesManager] [ScrapeImage_Movie] [Done] {0}", tDBElement.Filename))
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeImage_Movie] [Abort] [Offline] {0}", tDBElement.Filename))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeImage_MovieSet] [Start] {0}", tDBElement.MainDetails.Title))
        Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.ModuleResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[ModulesManager] [ScrapeImage_MovieSet] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[ModulesManager] [ScrapeImage_MovieSet] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))
                If QueryScraperCapabilities_Image_MovieSet(_externalScraperModule, ScrapeModifiers) Then
                    ret = _externalScraperModule.ProcessorModule.Run(tDBElement)
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

        logger.Trace(String.Format("[ModulesManager] [ScrapeImage_MovieSet] [Done] {0}", tDBElement.MainDetails.Title))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeImage_TV] [Start] {0}", tDBElement.MainDetails.Title))
        If tDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus_TVShow(tDBElement, bShowMessage) Then
            Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Dim ret As Interfaces.ModuleResult

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
                logger.Warn("[ModulesManager] [ScrapeImage_TV] [Abort] No scrapers enabled")
            Else
                For Each _externalScraperModule In modules
                    logger.Trace(String.Format("[ModulesManager] [ScrapeImage_TV] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))
                    If QueryScraperCapabilities_Image_TV(_externalScraperModule, ScrapeModifiers) Then
                        ret = _externalScraperModule.ProcessorModule.Run(tDBElement)
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

            logger.Trace(String.Format("[ModulesManager] [ScrapeImage_TV] [Done] {0}", tDBElement.MainDetails.Title))
            Return ret.bCancelled
        Else
            logger.Trace(String.Format("[ModulesManager] [ScrapeImage_Movie] [Abort] [Offline] {0}", tDBElement.Filename))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeTheme_Movie] [Start] {0}", tDBElement.Filename))
        Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.ModuleResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[ModulesManager] [ScrapeTheme_Movie] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[ModulesManager] [ScrapeTheme_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))
                ret = _externalScraperModule.ProcessorModule.Run(tDBElement)
                If ret.ScraperResult_Theme IsNot Nothing Then
                    ThemeList.AddRange(ret.ScraperResult_Theme)
                End If
                If ret.bBreakChain Then Exit For
            Next
        End If
        logger.Trace(String.Format("[ModulesManager] [ScrapeTheme_Movie] [Done] {0}", tDBElement.Filename))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeTheme_TVShow] [Start] {0}", tDBElement.MainDetails.Title))
        Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.ModuleResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[ModulesManager] [ScrapeTheme_TVShow] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[ModulesManager] [ScrapeTheme_TVShow] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))
                ret = _externalScraperModule.ProcessorModule.Run(tDBElement)
                If ret.ScraperResult_Theme IsNot Nothing Then
                    ThemeList.AddRange(ret.ScraperResult_Theme)
                End If
                If ret.bBreakChain Then Exit For
            Next
        End If
        logger.Trace(String.Format("[ModulesManager] [ScrapeTheme_TVShow] [Done] {0}", tDBElement.MainDetails.Title))
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
        logger.Trace(String.Format("[ModulesManager] [ScrapeTrailer_Movie] [Start] {0}", tDBElement.Filename))
        Dim modules = _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
        Dim ret As Interfaces.ModuleResult

        While Not ModulesLoaded
            Application.DoEvents()
        End While

        If (modules.Count() <= 0) Then
            logger.Warn("[ModulesManager] [ScrapeTrailer_Movie] [Abort] No scrapers enabled")
        Else
            For Each _externalScraperModule In modules
                logger.Trace(String.Format("[ModulesManager] [ScrapeTrailer_Movie] [Using] {0}", _externalScraperModule.ProcessorModule.ModuleName))
                ret = _externalScraperModule.ProcessorModule.Run(tDBElement)
                If ret.ScraperResult_Trailer IsNot Nothing Then
                    TrailerList.AddRange(ret.ScraperResult_Trailer)
                End If
                If ret.bBreakChain Then Exit For
            Next
        End If
        logger.Trace(String.Format("[ModulesManager] [ScrapeTrailer_Movie] [Done] {0}", tDBElement.Filename))
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
        Dim ret As Boolean = False
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each _externalScraperModule As ExternalModuleClass In _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Try
                ret = QueryScraperCapabilities_Image_Movie(_externalScraperModule, ImageType)
                If ret Then Exit For
            Catch ex As Exception
            End Try
        Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Image_MovieSet(ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = False
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each _externalScraperModule As ExternalModuleClass In _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Try
                ret = QueryScraperCapabilities_Image_MovieSet(_externalScraperModule, ImageType)
                If ret Then Exit For
            Catch ex As Exception
            End Try
        Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Image_TV(ByVal ImageType As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = False
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each _externalScraperModule As ExternalModuleClass In _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Try
                ret = QueryScraperCapabilities_Image_TV(_externalScraperModule, ImageType)
                If ret Then Exit For
            Catch ex As Exception
            End Try
        Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Theme_Movie(ByVal cap As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = False
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each _externalScraperModule As ExternalModuleClass In _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Try
                ret = True 'if a theme scraper is enabled we can exit.
                Exit For
            Catch ex As Exception
            End Try
        Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Theme_TV(ByVal cap As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = False
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each _externalScraperModule As ExternalModuleClass In _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Try
                ret = True 'if a theme scraper is enabled we can exit.
                Exit For
            Catch ex As Exception
            End Try
        Next
        Return ret
    End Function

    Function ScraperWithCapabilityAnyEnabled_Trailer_Movie(ByVal cap As Enums.ScrapeModifierType) As Boolean
        Dim ret As Boolean = False
        While Not ModulesLoaded
            Application.DoEvents()
        End While
        For Each _externalScraperModule As ExternalModuleClass In _externalmodules '.Where(Function(e) e.ProcessorModule.ScraperEnabled).OrderBy(Function(e) e.ModuleOrder)
            Try
                ret = True 'if a trailer scraper is enabled we can exit.
                Exit For
            Catch ex As Exception
            End Try
        Next
        Return ret
    End Function

    ''' <summary>
    ''' Sets the enabled flag of the module identified by <paramref name="ModuleAssembly"/> to the value of <paramref name="value"/>
    ''' </summary>
    ''' <param name="ModuleAssembly"><c>String</c> representing the assembly name of the module</param>
    ''' <param name="value"><c>Boolean</c> value to set the enabled flag to</param>
    ''' <remarks></remarks>
    Public Sub SetModuleEnable_Generic(ByVal ModuleAssembly As String, ByVal value As Boolean)
        If (String.IsNullOrEmpty(ModuleAssembly)) Then
            logger.Error("[ModulesManager] [SetModuleEnable_Generic] Invalid ModuleAssembly")
            Return
        End If

        Dim modules As IEnumerable(Of ExternalGenericModuleClass) = _externalgenericmodules.Where(Function(p) p.AssemblyName = ModuleAssembly)
        If (modules.Count < 0) Then
            logger.Warn("[ModulesManager] [SetModuleEnable_Generic] No modules of type <{0}> were found", ModuleAssembly)
        Else
            For Each _externalProcessorModule As ExternalGenericModuleClass In modules
                Try
                    _externalProcessorModule.ProcessorModule.Enabled = value
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name & Convert.ToChar(Keys.Tab) & "Could not set module <" & ModuleAssembly & "> to enabled status <" & value & ">")
                End Try
            Next
        End If
    End Sub

    Private Sub GenericRunCallBack(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object))
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

    Class ExternalModuleClass

#Region "Fields"

        Public AssemblyFileName As String
        Public AssemblyName As String
        Public ProcessorModule As Interfaces.ExternalModule

#End Region 'Fields

    End Class

    Class ExternalGenericModuleClass

#Region "Fields"

        Public AssemblyFileName As String

        'Public Enabled As Boolean
        Public AssemblyName As String
        Public ModuleOrder As Integer 'TODO: not important at this point.. for 1.5
        Public ProcessorModule As Interfaces.GenericModule 'Object
        Public Type As List(Of Enums.ModuleEventType)
        Public ContentType As Enums.ContentType = Enums.ContentType.Generic

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

    <XmlRoot("EmberModule")> _
    Class _XMLEmberModuleClass

#Region "Fields"

        Public AssemblyFileName As String
        Public AssemblyName As String
        Public ContentType As Enums.ContentType
        Public GenericEnabled As Boolean
        Public ModuleEnabled As Boolean
        Public ModuleOrder As Integer

#End Region 'Fields

    End Class

#End Region 'Nested Types

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class