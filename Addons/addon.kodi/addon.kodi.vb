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
Imports System.IO
Imports NLog
Imports System.Xml.Serialization


Public Class Addon
    Implements Interfaces.Addon

#Region "Delegates"

    Public Delegate Sub Delegate_SetToolStripItem(ts As ToolStrip, value As ToolStripItem)
    Public Delegate Sub Delegate_AddToolStripMenuItem(tsi As ToolStripMenuItem, value As ToolStripMenuItem)
    Public Delegate Sub Delegate_AddToolStripItem(value As ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolStripItem(value As ToolStripItem)

    Public Delegate Sub Delegate_ChangeTaskManagerStatus(control As ToolStripLabel, value As String)
    Public Delegate Sub Delegate_ChangeTaskManagerProgressBar(control As ToolStripProgressBar, value As ProgressBarStyle)

#End Region 'Delegates

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _assemblyname As String = String.Empty
    Private _enabled As Boolean = False
    Private _shortname As String = "KodiInterface"

    Private _settingspanel As frmSettingsPanel

    'reflects the current host(s) settings/setup configured in settings, will be filled at module startup from XML settings (and is used to write changes of settings back into XML)
    Private _addonsettings As New AddonSettings
    Private _xmlSettingsPath As String = Path.Combine(Master.SettingsPath, "Interface.Kodi.xml")
    Private cmnuKodi_MovieSets As New ToolStripMenuItem
    Private cmnuKodi_Movies As New ToolStripMenuItem
    Private cmnuKodi_TVEpisodes As New ToolStripMenuItem
    Private cmnuKodi_TVSeasons As New ToolStripMenuItem
    Private cmnuKodi_TVShows As New ToolStripMenuItem
    Private cmnuSep_MovieSets As New ToolStripSeparator
    Private cmnuSep_Movies As New ToolStripSeparator
    Private cmnuSep_TVEpisodes As New ToolStripSeparator
    Private cmnuSep_TVSeasons As New ToolStripSeparator
    Private cmnuSep_TVShows As New ToolStripSeparator
    Private mnuMainToolsKodi As New ToolStripMenuItem
    Private mnuTrayToolsKodi As New ToolStripMenuItem

    Private lblTaskManagerStatus As New ToolStripLabel With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private lblTaskManagerTitle As New ToolStripLabel With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tspTaskManager As New ToolStripProgressBar With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager1 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager2 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager3 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager4 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager5 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager6 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager7 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}
    Private tssTaskManager8 As New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right, .Visible = True}

    ''' <summary>
    ''' pool of Update tasks for KodiInterface (can be filled extremely fast when updating whole tvshow at once)
    ''' </summary>
    ''' <remarks></remarks>
    Private TaskList As New Queue(Of KodiTask)
    ''' <summary>
    ''' control variable: true=Ready to start tmrRunTasks-Timer and work through items of tasklist, false= Timer already tickting, executing tasks
    ''' </summary>
    ''' <remarks></remarks>
    Private TasksDone As Boolean = True

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal eType As Enums.AddonEventType, ByRef _params As List(Of Object)) Implements Interfaces.Addon.GenericEvent
    Public Event NeedsRestart() Implements Interfaces.Addon.NeedsRestart
    Public Event SettingsChanged() Implements Interfaces.Addon.SettingsChanged
    Public Event StateChanged(ByVal strName As String, ByVal bEnabled As Boolean) Implements Interfaces.Addon.StateChanged

#End Region 'Events

#Region "Properties"

    Public Property Enabled() As Boolean Implements Interfaces.Addon.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            If _enabled = value Then Return
            _enabled = value
            If _enabled Then
                Enable()
            Else
                Disable()
            End If
        End Set
    End Property

    Public ReadOnly Property Capabilities_AddonEventTypes() As List(Of Enums.AddonEventType) Implements Interfaces.Addon.Capabilities_AddonEventTypes
        Get
            Return New List(Of Enums.AddonEventType)(New Enums.AddonEventType() {
                                                      Enums.AddonEventType.BeforeEdit_Movie,
                                                      Enums.AddonEventType.BeforeEdit_TVEpisode,
                                                      Enums.AddonEventType.Remove_Movie,
                                                      Enums.AddonEventType.Remove_TVEpisode,
                                                      Enums.AddonEventType.Remove_TVShow,
                                                      Enums.AddonEventType.DuringScrapingMulti_Movie,
                                                      Enums.AddonEventType.DuringScrapingMulti_TVEpisode,
                                                      Enums.AddonEventType.DuringScrapingMulti_TVSeason,
                                                      Enums.AddonEventType.DuringScrapingMulti_TVShow,
                                                      Enums.AddonEventType.DuringScrapingSingle_Movie,
                                                      Enums.AddonEventType.DuringScrapingSingle_TVEpisode,
                                                      Enums.AddonEventType.DuringScrapingSingle_TVSeason,
                                                      Enums.AddonEventType.DuringScrapingSingle_TVShow,
                                                      Enums.AddonEventType.Sync_Movie,
                                                      Enums.AddonEventType.Sync_MovieSet,
                                                      Enums.AddonEventType.Sync_TVEpisode,
                                                      Enums.AddonEventType.Sync_TVSeason,
                                                      Enums.AddonEventType.Sync_TVShow})
        End Get
    End Property

    ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility) Implements Interfaces.Addon.Capabilities_ScraperCapatibilities
        Get
            Return New List(Of Enums.ScraperCapatibility)
        End Get
    End Property

    ReadOnly Property IsBusy() As Boolean Implements Interfaces.Addon.IsBusy
        Get
            Return Not TasksDone
        End Get
    End Property

    ReadOnly Property Shortname() As String Implements Interfaces.Addon.Shortname
        Get
            Return _shortname
        End Get
    End Property

    ReadOnly Property Version() As String Implements Interfaces.Addon.Version
        Get
            Return FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"
    ''' <summary>
    ''' Implementation of Realtime Sync, triggered outside of this module i.e after finishing edits of a movie (=Enums.ModuleEventType.Sync_Movie)
    ''' </summary>
    ''' <remarks>
    ''' 2015/06/26 Cocotus - First implementation, code prepared by DanCooper
    ''' this works through listening to various Enums.ModuleEventTypes, i.e Enums.ModuleEventType.Sync_Movie which will be triggered whenever movie details were changed
    ''' TODO, 2015/07/06 Cocotus  
    ''' - RunGeneric is a synched function, so we can't use Await in conjunction with async KodiAPI here (which is preferred). For Ember 1.5 I suggest to change RunGeneric to Public Async Function
    ''' - As soon as RunGeneric is Async, switch all API calling subs/function in here to async to so we can use await and enable result notification in Ember (see commented code below)
    ''' 2015/08/18 Cocotus  
    ''' For now we use concept of storing pool of API tasks in list (="TaskList") and use a timer object and its tick-event to get the work done
    ''' Timer tick event is async so we can queue with await all API tasks
    ''' </remarks>
    Public Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstParams As List(Of Object)) As Interfaces.AddonResult Implements Interfaces.Addon.Run
        If Not Master.isCL AndAlso (
                eAddonEventType = Enums.AddonEventType.Remove_Movie OrElse
                eAddonEventType = Enums.AddonEventType.Remove_TVEpisode OrElse
                eAddonEventType = Enums.AddonEventType.Remove_TVShow OrElse
                eAddonEventType = Enums.AddonEventType.Sync_Movie OrElse
                eAddonEventType = Enums.AddonEventType.Sync_MovieSet OrElse
                eAddonEventType = Enums.AddonEventType.Sync_TVEpisode OrElse
                eAddonEventType = Enums.AddonEventType.Sync_TVSeason OrElse
                eAddonEventType = Enums.AddonEventType.Sync_TVShow) Then
            'add job to tasklist and get everything done
            AddTask(New KodiTask With {.mType = eAddonEventType, .mDBElement = tDBElement})
            Return New Interfaces.AddonResult
        Else
            Select Case eAddonEventType
                Case Enums.AddonEventType.BeforeEdit_Movie
                    If Not _addonsettings.GetWatchedState OrElse Not _addonsettings.GetWatchedStateBeforeEdit_Movie Then
                        Return New Interfaces.AddonResult
                    End If
                Case Enums.AddonEventType.BeforeEdit_TVEpisode
                    If Not _addonsettings.GetWatchedState OrElse Not _addonsettings.GetWatchedStateBeforeEdit_TVEpisode Then
                        Return New Interfaces.AddonResult
                    End If
                Case Enums.AddonEventType.DuringScrapingMulti_Movie
                    If Not _addonsettings.GetWatchedState OrElse Not _addonsettings.GetWatchedStateScraperMulti_Movie Then
                        Return New Interfaces.AddonResult
                    End If
                Case Enums.AddonEventType.DuringScrapingMulti_TVEpisode, Enums.AddonEventType.DuringScrapingMulti_TVSeason, Enums.AddonEventType.DuringScrapingMulti_TVShow
                    If Not _addonsettings.GetWatchedState OrElse Not _addonsettings.GetWatchedStateScraperMulti_TVEpisode Then
                        Return New Interfaces.AddonResult
                    End If
                Case Enums.AddonEventType.DuringScrapingSingle_Movie
                    If Not _addonsettings.GetWatchedState OrElse Not _addonsettings.GetWatchedStateScraperSingle_Movie Then
                        Return New Interfaces.AddonResult
                    End If
                Case Enums.AddonEventType.DuringScrapingSingle_TVEpisode, Enums.AddonEventType.DuringScrapingSingle_TVSeason, Enums.AddonEventType.DuringScrapingSingle_TVShow
                    If Not _addonsettings.GetWatchedState OrElse Not _addonsettings.GetWatchedStateScraperSingle_TVEpisode Then
                        Return New Interfaces.AddonResult
                    End If
            End Select

            Dim mDBElement As Database.DBElement = tDBElement
            Dim tTask As Task(Of Boolean) = Task.Run(Function() DoCommandLine(eAddonEventType, mDBElement))
            While Not tTask.IsCompleted
                Threading.Thread.Sleep(50)
            End While
        End If

        Return New Interfaces.AddonResult
    End Function

    Private Async Function DoCommandLine(ByVal mType As Enums.AddonEventType, ByVal mDBElement As Database.DBElement) As Task(Of Boolean)
        Dim GenericEventActionAsync As New Action(Of GenericEventCallBackAsync)(AddressOf Handle_GenericEventAsync)
        Dim GenericEventProgressAsync = New Progress(Of GenericEventCallBackAsync)(GenericEventActionAsync)
        Return Await Task.Run(Function() GenericRunCallBack(mType, mDBElement, GenericEventProgressAsync))
    End Function

    Private Sub AddTask(ByRef nTask As KodiTask)
        TaskList.Enqueue(nTask)
        If TasksDone Then
            RunTasks()
        Else
            ChangeTaskManagerStatus(lblTaskManagerStatus, String.Concat("Pending Tasks: ", (TaskList.Count + 1).ToString))
        End If
    End Sub

    Private Async Sub RunTasks()
        Dim getError As Boolean = False
        Dim GenericEventActionAsync As New Action(Of GenericEventCallBackAsync)(AddressOf Handle_GenericEventAsync)
        Dim GenericEventProgressAsync = New Progress(Of GenericEventCallBackAsync)(GenericEventActionAsync)

        TasksDone = False
        'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"info", Nothing, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(1439, "Run Tasks"), New Bitmap(My.Resources.logo)}))
        While TaskList.Count > 0
            ChangeTaskManagerStatus(lblTaskManagerStatus, String.Concat("Pending Tasks: ", TaskList.Count.ToString))
            ChangeTaskManagerProgressBar(tspTaskManager, ProgressBarStyle.Marquee)
            Dim kTask As KodiTask = TaskList.Dequeue()
            If Not Await GenericRunCallBack(kTask.mType, kTask.mDBElement, GenericEventProgressAsync, kTask.mHost, kTask.mInternalType) Then
                getError = True
            End If
        End While
        TasksDone = True
        ChangeTaskManagerProgressBar(tspTaskManager, ProgressBarStyle.Continuous)
        ChangeTaskManagerStatus(lblTaskManagerStatus, "No Pending Tasks")
        If Not getError Then
            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"info", Nothing, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(251, "All Tasks Done"), New Bitmap(My.Resources.logo)}))
        Else
            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, Master.eLang.GetString(1422, "Kodi Interface"), String.Format(Master.eLang.GetString(969, "One or more Task(s) failed.{0}Please check log for more informations"), Environment.NewLine), Nothing}))
        End If
    End Sub

    Sub Handle_GenericEvent(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object))
        RaiseEvent GenericEvent(mType, _params)
    End Sub

    Sub Handle_GenericEventAsync(ByVal mGenericEventCallBack As GenericEventCallBackAsync)
        RaiseEvent GenericEvent(mGenericEventCallBack.tEventType, mGenericEventCallBack.tParams)
    End Sub

    Sub Handle_GenericSubEventAsync(ByVal mGenericSubEventCallBack As GenericSubEventCallBackAsync)
        mGenericSubEventCallBack.tProgress.Report(mGenericSubEventCallBack.tGenericEventCallBackAsync)
    End Sub
    ''' <summary>
    ''' This is a generic callback function to handle all realtime-sync work for KODI-Api
    ''' </summary>
    ''' <param name="mType"></param>
    ''' <remarks>
    ''' Worker function used to handle all ApiTaks in List(of KodiTask)
    ''' Made async to await async Kodi API
    ''' </remarks>
    Private Async Function GenericRunCallBack(ByVal mType As Enums.AddonEventType, ByVal mDBElement As Database.DBElement, ByVal GenericEventProcess As IProgress(Of GenericEventCallBackAsync), Optional mHost As Host = Nothing, Optional mInternalType As InternalType = Nothing) As Task(Of Boolean)
        Dim getError As Boolean = False
        Dim GenericSubEventActionAsync As New Action(Of GenericSubEventCallBackAsync)(AddressOf Handle_GenericSubEventAsync)
        Dim GenericSubEventProgressAsync = New Progress(Of GenericSubEventCallBackAsync)(GenericSubEventActionAsync)

        'check if at least one host is configured, else skip
        If _addonsettings.Hosts.Count > 0 Then
            Select Case mType

                'Before Edit Movie / Scraper Multi Movie / Scraper Single Movie
                Case Enums.AddonEventType.BeforeEdit_Movie, Enums.AddonEventType.DuringScrapingMulti_Movie, Enums.AddonEventType.DuringScrapingSingle_Movie
                    If mDBElement IsNot Nothing AndAlso Not String.IsNullOrEmpty(_addonsettings.GetWatchedStateHost) Then
                        mHost = _addonsettings.Hosts.FirstOrDefault(Function(f) f.Label = _addonsettings.GetWatchedStateHost)
                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                                    If mDBElement.NfoPathSpecified Then
                                        'run task
                                        Dim Result = Await Task.Run(Function() _APIKodi.GetPlaycount_Movie(mDBElement, GenericSubEventProgressAsync, GenericEventProcess))
                                        If Result IsNot Nothing Then
                                            mDBElement.MainDetails.LastPlayed = Result.LastPlayed
                                            mDBElement.MainDetails.PlayCount = Result.PlayCount
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                        Else
                                            logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                            getError = True
                                        End If
                                    Else
                                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                                        'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                                        getError = True
                                    End If
                                Else
                                    logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                                    getError = True
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            logger.Warn(String.Format("[KodiInterface] [GenericRunCallBack]: Hostname ({0}) not found in host list!", _addonsettings.GetWatchedStateHost))
                        End If
                    End If

                'Before Edit TVEpisode / Scraper Multi TVEpisode / Scraper Single TVEpisode
                Case Enums.AddonEventType.BeforeEdit_TVEpisode, Enums.AddonEventType.DuringScrapingMulti_TVEpisode, Enums.AddonEventType.DuringScrapingSingle_TVEpisode
                    If mDBElement IsNot Nothing AndAlso Not String.IsNullOrEmpty(_addonsettings.GetWatchedStateHost) Then
                        mHost = _addonsettings.Hosts.FirstOrDefault(Function(f) f.Label = _addonsettings.GetWatchedStateHost)
                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                                    If mDBElement.NfoPathSpecified Then
                                        'run task
                                        Dim Result = Await Task.Run(Function() _APIKodi.GetPlaycount_TVEpisode(mDBElement, GenericSubEventProgressAsync, GenericEventProcess))
                                        If Result IsNot Nothing Then
                                            mDBElement.MainDetails.LastPlayed = Result.LastPlayed
                                            mDBElement.MainDetails.PlayCount = Result.PlayCount
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                        Else
                                            logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                            getError = True
                                        End If
                                    Else
                                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                                        'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                                        getError = True
                                    End If
                                Else
                                    logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                                    getError = True
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            logger.Warn(String.Format("[KodiInterface] [GenericRunCallBack]: Hostname ({0}) not found in host list!", _addonsettings.GetWatchedStateHost))
                        End If
                    End If

                Case Enums.AddonEventType.DuringScrapingMulti_TVSeason, Enums.AddonEventType.DuringScrapingMulti_TVShow, Enums.AddonEventType.DuringScrapingSingle_TVSeason, Enums.AddonEventType.DuringScrapingSingle_TVShow
                    If mDBElement IsNot Nothing AndAlso Not String.IsNullOrEmpty(_addonsettings.GetWatchedStateHost) Then
                        mHost = _addonsettings.Hosts.FirstOrDefault(Function(f) f.Label = _addonsettings.GetWatchedStateHost)
                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                If mDBElement.Episodes IsNot Nothing Then
                                    For Each tEpisode In mDBElement.Episodes.Where(Function(f) f.FilenameSpecified)
                                        If tEpisode.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(tEpisode, True) Then
                                            If tEpisode.NfoPathSpecified Then
                                                'run task
                                                Dim Result = Await Task.Run(Function() _APIKodi.GetPlaycount_TVEpisode(tEpisode, GenericSubEventProgressAsync, GenericEventProcess))
                                                If Result IsNot Nothing Then
                                                    tEpisode.MainDetails.LastPlayed = Result.LastPlayed
                                                    tEpisode.MainDetails.PlayCount = Result.PlayCount
                                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", tEpisode.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                                Else
                                                    logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", tEpisode.MainDetails.Title))
                                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", tEpisode.MainDetails.Title)))
                                                    getError = True
                                                End If
                                            Else
                                                logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                                                'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                                                getError = True
                                            End If
                                        Else
                                            logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                                            getError = True
                                        End If
                                    Next
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            logger.Warn(String.Format("[KodiInterface] [GenericRunCallBack]: Hostname ({0}) not found in host list!", _addonsettings.GetWatchedStateHost))
                        End If
                    End If

                'Remove Movie
                Case Enums.AddonEventType.Remove_Movie
                    If mDBElement.FilenameSpecified Then
                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                'run task
                                If Await Task.Run(Function() _APIKodi.Remove_Movie(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1031, "Removal OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                Else
                                    logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Removal failed:  ", mDBElement.MainDetails.Title))
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1032, "Removal failed"), ": ", mDBElement.MainDetails.Title)))
                                    getError = True
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            For Each tHost As Host In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.Movie).Count > 0)
                                Dim _APIKodi As New Kodi.APIKodi(tHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.Remove_Movie(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1031, "Removal OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Removal failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1032, "Removal failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Next
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: No file name specified")
                    End If

                'Remove TVEpisode
                Case Enums.AddonEventType.Remove_TVEpisode
                    If mDBElement.FilenameSpecified Then

                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                'run task
                                If Await Task.Run(Function() _APIKodi.Remove_TVEpisode(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1031, "Removal OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                Else
                                    logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Removal failed:  ", mDBElement.MainDetails.Title))
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1032, "Removal failed"), ": ", mDBElement.MainDetails.Title)))
                                    getError = True
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            For Each tHost In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.TV).Count > 0)
                                Dim _APIKodi As New Kodi.APIKodi(tHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.Remove_TVEpisode(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1031, "Removal OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Removal failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1032, "Removal failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Next
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: No file name specified")
                    End If

                    'Remove TVShow
                Case Enums.AddonEventType.Remove_TVShow
                    If mDBElement.ShowPathSpecified Then
                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                'run task
                                If Await Task.Run(Function() _APIKodi.Remove_TVShow(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1031, "Removal OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                Else
                                    logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Removal failed:  ", mDBElement.MainDetails.Title))
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1032, "Removal failed"), ": ", mDBElement.MainDetails.Title)))
                                    getError = True
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            For Each tHost In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.TV).Count > 0)
                                Dim _APIKodi As New Kodi.APIKodi(tHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.Remove_TVShow(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1031, "Removal OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Removal failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1032, "Removal failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Next
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: No tvshow path specified")
                    End If

                'Sync Movie
                Case Enums.AddonEventType.Sync_Movie
                    If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                        If mDBElement.NfoPathSpecified Then
                            If mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.UpdateInfo_Movie(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Else
                                For Each tHost As Host In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.Movie).Count > 0)
                                    Dim _APIKodi As New Kodi.APIKodi(tHost)

                                    'connection test
                                    If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                        'run task
                                        If Await Task.Run(Function() _APIKodi.UpdateInfo_Movie(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                        Else
                                            logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                            getError = True
                                        End If
                                    Else
                                        getError = True
                                    End If
                                Next
                            End If
                        Else
                            logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                            getError = True
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                        getError = True
                    End If

                    'Sync MovieSet
                Case Enums.AddonEventType.Sync_MovieSet
                    If mDBElement.MoviesInSetSpecified Then
                        If mHost IsNot Nothing Then
                            Dim _APIKodi As New Kodi.APIKodi(mHost)

                            'connection test
                            If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                'run task
                                If Await Task.Run(Function() _APIKodi.UpdateInfo_MovieSet(mDBElement, _addonsettings.SendNotifications)) Then
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                Else
                                    logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                    getError = True
                                End If
                            Else
                                getError = True
                            End If
                        Else
                            For Each tHost In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso Not String.IsNullOrEmpty(f.MovieSetArtworksPath))
                                Dim _APIKodi As New Kodi.APIKodi(tHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.UpdateInfo_MovieSet(mDBElement, _addonsettings.SendNotifications)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Next
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: No movies in set!")
                        getError = True
                    End If

                    'Sync TVEpisode
                Case Enums.AddonEventType.Sync_TVEpisode
                    If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                        If mDBElement.NfoPathSpecified Then
                            If mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.UpdateInfo_TVEpisode(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Else
                                For Each tHost In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.TV).Count > 0)
                                    Dim _APIKodi As New Kodi.APIKodi(tHost)

                                    'connection test
                                    If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                        'run task
                                        If Await Task.Run(Function() _APIKodi.UpdateInfo_TVEpisode(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                        Else
                                            logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                            getError = True
                                        End If
                                    Else
                                        getError = True
                                    End If
                                Next
                            End If
                        Else
                            logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                            getError = True
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                        getError = True
                    End If

                    'Sync TVSeason
                Case Enums.AddonEventType.Sync_TVSeason
                    If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                        If mDBElement.IDSpecified Then
                            If mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.UpdateInfo_TVSeason(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Else
                                For Each tHost In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.TV).Count > 0)
                                    Dim _APIKodi As New Kodi.APIKodi(tHost)

                                    'connection test
                                    If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                        'run task
                                        If Await Task.Run(Function() _APIKodi.UpdateInfo_TVSeason(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                        Else
                                            logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                            getError = True
                                        End If
                                    Else
                                        getError = True
                                    End If
                                Next
                            End If
                        Else
                            logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                            getError = True
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                        getError = True
                    End If

                    'Sync TVShow
                Case Enums.AddonEventType.Sync_TVShow
                    If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                        If mDBElement.NfoPathSpecified Then
                            If mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    'run task
                                    If Await Task.Run(Function() _APIKodi.UpdateInfo_TVShow(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                    Else
                                        logger.Warn(String.Concat("[KodiInterface] [", mHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                        getError = True
                                    End If
                                Else
                                    getError = True
                                End If
                            Else
                                For Each tHost In _addonsettings.Hosts.Where(Function(f) f.RealTimeSync AndAlso f.Sources.Where(Function(c) c.ContentType = Enums.ContentType.TV).Count > 0)
                                    Dim _APIKodi As New Kodi.APIKodi(tHost)

                                    'connection test
                                    If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                        'run task
                                        If Await Task.Run(Function() _APIKodi.UpdateInfo_TVShow(mDBElement, _addonsettings.SendNotifications, GenericSubEventProgressAsync, GenericEventProcess)) Then
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                        Else
                                            logger.Warn(String.Concat("[KodiInterface] [", tHost.Label, "] [GenericRunCallBack] | Sync Failed:  ", mDBElement.MainDetails.Title))
                                            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", String.Concat(tHost.Label, " | ", Master.eLang.GetString(1445, "Sync Failed"), ": ", mDBElement.MainDetails.Title)))
                                            getError = True
                                        End If
                                    Else
                                        getError = True
                                    End If
                                Next
                            End If
                        Else
                            logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(1442, "Please Scrape In Ember First!"), Nothing}))
                            getError = True
                        End If
                    Else
                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                        getError = True
                    End If

                    'General Tasks
                Case Enums.AddonEventType.Task
                    Select Case mInternalType

                        'Get Playcount
                        Case InternalType.GetPlaycount
                            If mDBElement IsNot Nothing AndAlso mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)

                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    Select Case mDBElement.ContentType

                                        'Get Movie Playcount
                                        Case Enums.ContentType.Movie
                                            If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                                                If mDBElement.NfoPathSpecified Then
                                                    'run task
                                                    Dim Result = Await Task.Run(Function() _APIKodi.GetPlaycount_Movie(mDBElement, GenericSubEventProgressAsync, GenericEventProcess))
                                                    If Result IsNot Nothing Then
                                                        mDBElement.MainDetails.LastPlayed = Result.LastPlayed
                                                        mDBElement.MainDetails.PlayCount = Result.PlayCount
                                                        Master.DB.Save_Movie(mDBElement, False, True, False, True, False)
                                                        RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_Movie, New List(Of Object)(New Object() {mDBElement.ID}))
                                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                                    End If
                                                Else
                                                    logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                                                    'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                                                    getError = True
                                                End If
                                            Else
                                                logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                                                getError = True
                                            End If

                                        'Get TVEpisode Playcount
                                        Case Enums.ContentType.TVEpisode
                                            If mDBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(mDBElement, True) Then
                                                If mDBElement.NfoPathSpecified Then
                                                    'run task
                                                    Dim Result = Await Task.Run(Function() _APIKodi.GetPlaycount_TVEpisode(mDBElement, GenericSubEventProgressAsync, GenericEventProcess))
                                                    If Result IsNot Nothing Then
                                                        mDBElement.MainDetails.LastPlayed = Result.LastPlayed
                                                        mDBElement.MainDetails.PlayCount = Result.PlayCount
                                                        Master.DB.Save_TVEpisode(mDBElement, False, True, False, False, True)
                                                        RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {mDBElement.ID}))
                                                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", mDBElement.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                                    End If
                                                Else
                                                    logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                                                    'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                                                    getError = True
                                                End If
                                            Else
                                                logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                                                getError = True
                                            End If

                                        'Get TVSeason / TVShow Playcount
                                        Case Enums.ContentType.TVSeason, Enums.ContentType.TVShow
                                            If mDBElement.Episodes IsNot Nothing Then
                                                For Each tEpisode In mDBElement.Episodes
                                                    If tEpisode.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(tEpisode, True) Then
                                                        If tEpisode.NfoPathSpecified Then
                                                            'run task
                                                            Dim Result = Await Task.Run(Function() _APIKodi.GetPlaycount_TVEpisode(tEpisode, GenericSubEventProgressAsync, GenericEventProcess))
                                                            If Result IsNot Nothing Then
                                                                tEpisode.MainDetails.LastPlayed = Result.LastPlayed
                                                                tEpisode.MainDetails.PlayCount = Result.PlayCount
                                                                Master.DB.Save_TVEpisode(tEpisode, False, True, False, False, True)
                                                                RaiseEvent GenericEvent(Enums.AddonEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {tEpisode.ID}))
                                                                Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", String.Concat(mHost.Label, " | ", Master.eLang.GetString(1444, "Sync OK"), ": ", tEpisode.MainDetails.Title), New Bitmap(My.Resources.logo)))
                                                            End If
                                                        Else
                                                            logger.Warn("[KodiInterface] [GenericRunCallBack]: Please Scrape In Ember First!")
                                                            'ModulesManager.Instance.RunGeneric(Enums.ModuleEventType.Notification, New List(Of Object)(New Object() {"error", 1, Master.eLang.GetString(1422, "Kodi Interface"), Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                                                            getError = True
                                                        End If
                                                    Else
                                                        logger.Warn("[KodiInterface] [GenericRunCallBack]: Not online!")
                                                        getError = True
                                                    End If
                                                Next
                                            End If
                                    End Select
                                Else
                                    getError = True
                                End If
                            End If

                            'Clean Video Library
                        Case InternalType.VideoLibrary_Clean
                            If mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)
                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    Await _APIKodi.VideoLibrary_Clean.ConfigureAwait(False)
                                    While Await _APIKodi.IsScanningVideo()
                                        Threading.Thread.Sleep(1000)
                                    End While
                                Else
                                    getError = True
                                End If
                            End If

                            'Update Video Library
                        Case InternalType.VideoLibrary_Update
                            If mHost IsNot Nothing Then
                                Dim _APIKodi As New Kodi.APIKodi(mHost)
                                'connection test
                                If Await Task.Run(Function() _APIKodi.TestConnectionToHost) Then
                                    Await _APIKodi.VideoLibrary_ScanState.ConfigureAwait(False)
                                    While Await _APIKodi.IsScanningVideo()
                                        Threading.Thread.Sleep(1000)
                                    End While
                                Else
                                    getError = True
                                End If
                            End If
                    End Select
            End Select
        Else
            logger.Warn("[KodiInterface] [GenericRunCallBack]: No Host Configured!")
            getError = True
        End If

        If Not getError Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Init(ByVal strAssemblyName As String) Implements Interfaces.Addon.Init
        _assemblyname = strAssemblyName
        LoadSettings()
    End Sub
    ''' <summary>
    ''' Load module settings
    ''' </summary>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation
    ''' Used at module startup(=Ember startup) to load Kodi Hosts and also set other module settings
    Sub LoadSettings()
        _addonsettings.Clear()
        If File.Exists(_xmlSettingsPath) Then
            Dim xmlSer As XmlSerializer = Nothing
            Using xmlSR As StreamReader = New StreamReader(_xmlSettingsPath)
                xmlSer = New XmlSerializer(GetType(AddonSettings))
                _addonsettings = DirectCast(xmlSer.Deserialize(xmlSR), AddonSettings)
            End Using
        End If
    End Sub

    Private Sub CreateContextMenu(ByRef tMenu As ToolStripMenuItem, ByVal tContentType As Enums.ContentType)
        'Single Host
        If _addonsettings.Hosts IsNot Nothing AndAlso _addonsettings.Hosts.Count = 1 Then
            Dim mnuHostSyncItem As New ToolStripMenuItem
            mnuHostSyncItem.Image = New Bitmap(My.Resources.menuSync)
            mnuHostSyncItem.Tag = _addonsettings.Hosts(0)
            mnuHostSyncItem.Text = Master.eLang.GetString(1446, "Sync")
            Select Case tContentType
                Case Enums.ContentType.Movie
                    AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_Movie_Click
                Case Enums.ContentType.MovieSet
                    AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_MovieSet_Click
                Case Enums.ContentType.TVEpisode
                    AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_TVEpisode_Click
                Case Enums.ContentType.TVSeason
                    AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_TVSeason_Click
                Case Enums.ContentType.TVShow
                    AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_TVShow_Click
            End Select
            tMenu.DropDownItems.Add(mnuHostSyncItem)
            If tContentType = Enums.ContentType.TVSeason OrElse tContentType = Enums.ContentType.TVShow Then
                Dim mnuHostSyncFullItem As New ToolStripMenuItem
                mnuHostSyncFullItem.Image = New Bitmap(My.Resources.menuSync)
                mnuHostSyncFullItem.Tag = _addonsettings.Hosts(0)
                mnuHostSyncFullItem.Text = Master.eLang.GetString(1008, "Sync Full")
                Select Case tContentType
                    Case Enums.ContentType.TVSeason
                        AddHandler mnuHostSyncFullItem.Click, AddressOf cmnuHostSyncFullItem_TVSeason_Click
                    Case Enums.ContentType.TVShow
                        AddHandler mnuHostSyncFullItem.Click, AddressOf cmnuHostSyncFullItem_TVShow_Click
                End Select
                tMenu.DropDownItems.Add(mnuHostSyncFullItem)
            End If
            If tContentType = Enums.ContentType.Movie OrElse tContentType = Enums.ContentType.TVEpisode OrElse tContentType = Enums.ContentType.TVSeason OrElse tContentType = Enums.ContentType.TVShow Then
                If _addonsettings.GetWatchedState AndAlso Not String.IsNullOrEmpty(_addonsettings.GetWatchedStateHost) Then
                    Dim mHost As Host = _addonsettings.Hosts.FirstOrDefault(Function(f) f.Label = _addonsettings.GetWatchedStateHost)
                    If mHost IsNot Nothing Then
                        Dim mnuHostGetPlaycount As New ToolStripMenuItem
                        mnuHostGetPlaycount.Image = New Bitmap(My.Resources.menuWatchedState)
                        mnuHostGetPlaycount.Tag = mHost
                        mnuHostGetPlaycount.Text = Master.eLang.GetString(1070, "Get Watched State")
                        Select Case tContentType
                            Case Enums.ContentType.Movie
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_Movie_Click
                            Case Enums.ContentType.TVEpisode
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_TVEpisode_Click
                            Case Enums.ContentType.TVSeason
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_TVSeason_Click
                            Case Enums.ContentType.TVShow
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_TVShow_Click
                        End Select
                        tMenu.DropDownItems.Add(mnuHostGetPlaycount)
                    End If
                End If
            End If
            If tContentType = Enums.ContentType.Movie OrElse tContentType = Enums.ContentType.TVEpisode OrElse tContentType = Enums.ContentType.TVShow Then
                Dim mnuHostRemoveItem As New ToolStripMenuItem
                mnuHostRemoveItem.Image = New Bitmap(My.Resources.menuRemove)
                mnuHostRemoveItem.Tag = _addonsettings.Hosts(0)
                mnuHostRemoveItem.Text = Master.eLang.GetString(30, "Remove")
                Select Case tContentType
                    Case Enums.ContentType.Movie
                        AddHandler mnuHostRemoveItem.Click, AddressOf cmnuHostRemoveItem_Movie_Click
                    Case Enums.ContentType.TVEpisode
                        AddHandler mnuHostRemoveItem.Click, AddressOf cmnuHostRemoveItem_TVEpisode_Click
                    Case Enums.ContentType.TVShow
                        AddHandler mnuHostRemoveItem.Click, AddressOf cmnuHostRemoveItem_TVShow_Click
                End Select
                tMenu.DropDownItems.Add(mnuHostRemoveItem)
            End If

            'Multiple Hosts
        ElseIf _addonsettings.Hosts IsNot Nothing AndAlso _addonsettings.Hosts.Count > 1 Then
            For Each kHost As Host In _addonsettings.Hosts
                Dim mnuHost As New ToolStripMenuItem
                mnuHost.Image = New Bitmap(My.Resources.icon)
                mnuHost.Text = kHost.Label
                Dim mnuHostSyncItem As New ToolStripMenuItem
                mnuHostSyncItem.Image = New Bitmap(My.Resources.menuSync)
                mnuHostSyncItem.Tag = kHost
                mnuHostSyncItem.Text = Master.eLang.GetString(1446, "Sync")
                Select Case tContentType
                    Case Enums.ContentType.Movie
                        AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_Movie_Click
                    Case Enums.ContentType.MovieSet
                        AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_MovieSet_Click
                    Case Enums.ContentType.TVEpisode
                        AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_TVEpisode_Click
                    Case Enums.ContentType.TVSeason
                        AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_TVSeason_Click
                    Case Enums.ContentType.TVShow
                        AddHandler mnuHostSyncItem.Click, AddressOf cmnuHostSyncItem_TVShow_Click
                End Select
                mnuHost.DropDownItems.Add(mnuHostSyncItem)
                If tContentType = Enums.ContentType.TVSeason OrElse tContentType = Enums.ContentType.TVShow Then
                    Dim mnuHostSyncFullItem As New ToolStripMenuItem
                    mnuHostSyncFullItem.Image = New Bitmap(My.Resources.menuSync)
                    mnuHostSyncFullItem.Tag = kHost
                    mnuHostSyncFullItem.Text = Master.eLang.GetString(1008, "Sync Full")
                    Select Case tContentType
                        Case Enums.ContentType.TVSeason
                            AddHandler mnuHostSyncFullItem.Click, AddressOf cmnuHostSyncFullItem_TVSeason_Click
                        Case Enums.ContentType.TVShow
                            AddHandler mnuHostSyncFullItem.Click, AddressOf cmnuHostSyncFullItem_TVShow_Click
                    End Select
                    mnuHost.DropDownItems.Add(mnuHostSyncFullItem)
                End If
                If tContentType = Enums.ContentType.Movie OrElse tContentType = Enums.ContentType.TVEpisode OrElse tContentType = Enums.ContentType.TVShow Then
                    Dim mnuHostRemoveItem As New ToolStripMenuItem
                    mnuHostRemoveItem.Image = New Bitmap(My.Resources.menuRemove)
                    mnuHostRemoveItem.Tag = kHost
                    mnuHostRemoveItem.Text = Master.eLang.GetString(30, "Remove")
                    Select Case tContentType
                        Case Enums.ContentType.Movie
                            AddHandler mnuHostRemoveItem.Click, AddressOf cmnuHostRemoveItem_Movie_Click
                        Case Enums.ContentType.TVEpisode
                            AddHandler mnuHostRemoveItem.Click, AddressOf cmnuHostRemoveItem_TVEpisode_Click
                        Case Enums.ContentType.TVShow
                            AddHandler mnuHostRemoveItem.Click, AddressOf cmnuHostRemoveItem_TVShow_Click
                    End Select
                    mnuHost.DropDownItems.Add(mnuHostRemoveItem)
                End If
                tMenu.DropDownItems.Add(mnuHost)
            Next
            If tContentType = Enums.ContentType.Movie OrElse tContentType = Enums.ContentType.TVEpisode OrElse tContentType = Enums.ContentType.TVSeason OrElse tContentType = Enums.ContentType.TVShow Then
                If _addonsettings.GetWatchedState AndAlso Not String.IsNullOrEmpty(_addonsettings.GetWatchedStateHost) Then
                    Dim mHost As Host = _addonsettings.Hosts.FirstOrDefault(Function(f) f.Label = _addonsettings.GetWatchedStateHost)
                    If mHost IsNot Nothing Then
                        Dim mnuHostGetPlaycount As New ToolStripMenuItem
                        mnuHostGetPlaycount.Image = New Bitmap(My.Resources.menuWatchedState)
                        mnuHostGetPlaycount.Tag = mHost
                        mnuHostGetPlaycount.Text = String.Format("{0} ({1})", Master.eLang.GetString(1070, "Get Watched State"), _addonsettings.GetWatchedStateHost)
                        Select Case tContentType
                            Case Enums.ContentType.Movie
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_Movie_Click
                            Case Enums.ContentType.TVEpisode
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_TVEpisode_Click
                            Case Enums.ContentType.TVSeason
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_TVSeason_Click
                            Case Enums.ContentType.TVShow
                                AddHandler mnuHostGetPlaycount.Click, AddressOf cmnuHostGetPlaycount_TVShow_Click
                        End Select
                        tMenu.DropDownItems.Add(mnuHostGetPlaycount)
                    End If
                End If
            End If
        Else
            Dim mnuDummy As New ToolStripMenuItem
            mnuDummy.Enabled = False
            mnuDummy.Text = Master.eLang.GetString(1447, "No Host Configured!")
            tMenu.DropDownItems.Add(mnuDummy)
        End If
    End Sub

    Private Sub CreateToolsMenu(ByRef tMenu As ToolStripMenuItem)
        Dim mnuHostSyncPlaycounts As New ToolStripMenuItem
        mnuHostSyncPlaycounts.Text = "Sync Playcount"
        If _addonsettings.Hosts IsNot Nothing AndAlso _addonsettings.Hosts.Count = 1 Then
            Dim mnuHostScanVideoLibrary As New ToolStripMenuItem
            mnuHostScanVideoLibrary.Image = New Bitmap(My.Resources.menuSync)
            mnuHostScanVideoLibrary.Tag = _addonsettings.Hosts(0)
            mnuHostScanVideoLibrary.Text = Master.eLang.GetString(82, "Update Library")
            AddHandler mnuHostScanVideoLibrary.Click, AddressOf mnuHostScanVideoLibrary_Click
            tMenu.DropDownItems.Add(mnuHostScanVideoLibrary)
            Dim mnuHostCleanVideoLibrary As New ToolStripMenuItem
            mnuHostCleanVideoLibrary.Image = New Bitmap(My.Resources.menuClean)
            mnuHostCleanVideoLibrary.Tag = _addonsettings.Hosts(0)
            mnuHostCleanVideoLibrary.Text = Master.eLang.GetString(709, "Clean Database")
            AddHandler mnuHostCleanVideoLibrary.Click, AddressOf mnuHostCleanVideoLibrary_Click
            tMenu.DropDownItems.Add(mnuHostCleanVideoLibrary)
        ElseIf _addonsettings.Hosts IsNot Nothing AndAlso _addonsettings.Hosts.Count > 1 Then
            For Each kHost As Host In _addonsettings.Hosts
                Dim mnuHost As New ToolStripMenuItem
                mnuHost.Image = New Bitmap(My.Resources.icon)
                mnuHost.Text = kHost.Label
                Dim mnuHostScanVideoLibrary As New ToolStripMenuItem
                mnuHostScanVideoLibrary.Image = New Bitmap(My.Resources.menuSync)
                mnuHostScanVideoLibrary.Tag = kHost
                mnuHostScanVideoLibrary.Text = Master.eLang.GetString(82, "Update Library")
                AddHandler mnuHostScanVideoLibrary.Click, AddressOf mnuHostScanVideoLibrary_Click
                mnuHost.DropDownItems.Add(mnuHostScanVideoLibrary)
                Dim mnuHostCleanVideoLibrary As New ToolStripMenuItem
                mnuHostCleanVideoLibrary.Image = New Bitmap(My.Resources.menuClean)
                mnuHostCleanVideoLibrary.Tag = kHost
                mnuHostCleanVideoLibrary.Text = Master.eLang.GetString(709, "Clean Database")
                AddHandler mnuHostCleanVideoLibrary.Click, AddressOf mnuHostCleanVideoLibrary_Click
                mnuHost.DropDownItems.Add(mnuHostCleanVideoLibrary)
                tMenu.DropDownItems.Add(mnuHost)
            Next
        Else
            Dim mnuDummy As New ToolStripMenuItem
            mnuDummy.Enabled = False
            mnuDummy.Text = Master.eLang.GetString(1447, "No Host Configured!")
            tMenu.DropDownItems.Add(mnuDummy)
        End If
    End Sub

    Private Sub PopulateMenus()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools menu
        mnuMainToolsKodi.DropDownItems.Clear()
        mnuMainToolsKodi.Image = New Bitmap(My.Resources.icon)
        mnuMainToolsKodi.Text = "Kodi Interface"
        mnuMainToolsKodi.Tag = New Structures.ModulesMenus With {.ForMovies = True, .IfTabMovies = True, .ForMovieSets = True, .IfTabMovieSets = True, .ForTVShows = True, .IfTabTVShows = True}
        CreateToolsMenu(mnuMainToolsKodi)
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        AddToolStripItem(tsi, mnuMainToolsKodi)

        'mnuTrayTools
        mnuTrayToolsKodi.DropDownItems.Clear()
        mnuTrayToolsKodi.Image = New Bitmap(My.Resources.icon)
        mnuTrayToolsKodi.Text = "Kodi Interface"
        CreateToolsMenu(mnuTrayToolsKodi)
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        AddToolStripItem(tsi, mnuTrayToolsKodi)

        'cmnuMovies
        cmnuKodi_Movies.DropDownItems.Clear()
        cmnuKodi_Movies.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_Movies.Text = "Kodi Interface"
        CreateContextMenu(cmnuKodi_Movies, Enums.ContentType.Movie)
        SetToolStripItem_Movies(cmnuSep_Movies)
        SetToolStripItem_Movies(cmnuKodi_Movies)

        'cmnuMovieSets
        cmnuKodi_MovieSets.DropDownItems.Clear()
        cmnuKodi_MovieSets.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_MovieSets.Text = "Kodi Interface"
        CreateContextMenu(cmnuKodi_MovieSets, Enums.ContentType.MovieSet)
        AddToolStripItem_MovieSets(cmnuSep_MovieSets)
        AddToolStripItem_MovieSets(cmnuKodi_MovieSets)

        'cmnuTVEpisodes
        cmnuKodi_TVEpisodes.DropDownItems.Clear()
        cmnuKodi_TVEpisodes.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_TVEpisodes.Text = "Kodi Interface"
        CreateContextMenu(cmnuKodi_TVEpisodes, Enums.ContentType.TVEpisode)
        AddToolStripItem_TVEpisodes(cmnuSep_TVEpisodes)
        AddToolStripItem_TVEpisodes(cmnuKodi_TVEpisodes)

        'cmnuTVSeasons
        cmnuKodi_TVSeasons.DropDownItems.Clear()
        cmnuKodi_TVSeasons.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_TVSeasons.Text = "Kodi Interface"
        CreateContextMenu(cmnuKodi_TVSeasons, Enums.ContentType.TVSeason)
        AddToolStripItem_TVSeasons(cmnuSep_TVSeasons)
        AddToolStripItem_TVSeasons(cmnuKodi_TVSeasons)

        'cmnuTVShows
        cmnuKodi_TVShows.DropDownItems.Clear()
        cmnuKodi_TVShows.Image = New Bitmap(My.Resources.icon)
        cmnuKodi_TVShows.Text = "Kodi Interface"
        CreateContextMenu(cmnuKodi_TVShows, Enums.ContentType.TVShow)
        AddToolStripItem_TVShows(cmnuSep_TVShows)
        AddToolStripItem_TVShows(cmnuKodi_TVShows)

        'Task Manager
        lblTaskManagerStatus.Text = "No Pending Tasks"
        lblTaskManagerTitle.Text = "Kodi Interface Task Manager"
        Dim ts As ToolStrip = AddonsManager.Instance.RuntimeObjects.MainToolStrip
        AddToolStripItem(ts, tssTaskManager1)
        AddToolStripItem(ts, tssTaskManager2)
        AddToolStripItem(ts, tspTaskManager)
        AddToolStripItem(ts, tssTaskManager3)
        AddToolStripItem(ts, tssTaskManager4)
        AddToolStripItem(ts, lblTaskManagerStatus)
        AddToolStripItem(ts, tssTaskManager5)
        AddToolStripItem(ts, tssTaskManager6)
        AddToolStripItem(ts, lblTaskManagerTitle)
        AddToolStripItem(ts, tssTaskManager7)
        AddToolStripItem(ts, tssTaskManager8)
    End Sub

    ''' <summary>
    ''' Actions on module startup (Ember startup) and runtime if module is enabled
    ''' </summary>
    ''' <remarks></remarks>
    Sub Enable()
        PopulateMenus()
    End Sub
    ''' <summary>
    '''  Actions on module startup (Ember startup) and runtime if module is disabled
    ''' </summary>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation, prepared by DanCooper
    ''' Used at module startup(=Ember startup) and during runtime to hide menu buttons of module in Ember
    Sub Disable()
        Dim tsi As New ToolStripMenuItem

        'mnuMainTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.MainMenu.Items("mnuMainTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(mnuMainToolsKodi)

        'cmnuTrayTools
        tsi = DirectCast(AddonsManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(mnuTrayToolsKodi)

        'cmnuMovies
        RemoveToolStripItem_Movies(cmnuSep_Movies)
        RemoveToolStripItem_Movies(cmnuKodi_Movies)
        'cmnuEpisodes
        RemoveToolStripItem_TVEpisodes(cmnuSep_TVEpisodes)
        RemoveToolStripItem_TVEpisodes(cmnuKodi_TVEpisodes)
        'cmnuShows
        RemoveToolStripItem_TVShows(cmnuSep_TVShows)
        RemoveToolStripItem_TVShows(cmnuKodi_TVShows)
        'cmnuSeasons
        RemoveToolStripItem_TVSeasons(cmnuSep_TVSeasons)
        RemoveToolStripItem_TVSeasons(cmnuKodi_TVSeasons)
        'cmnuSets
        RemoveToolStripItem_MovieSets(cmnuSep_MovieSets)
        RemoveToolStripItem_MovieSets(cmnuKodi_MovieSets)

        'Task Manager
        Dim ts As ToolStrip = AddonsManager.Instance.RuntimeObjects.MainToolStrip
        ts.Items.Remove(lblTaskManagerStatus)
        ts.Items.Remove(lblTaskManagerTitle)
        ts.Items.Remove(tspTaskManager)
        ts.Items.Remove(tssTaskManager1)
        ts.Items.Remove(tssTaskManager2)
        ts.Items.Remove(tssTaskManager3)
        ts.Items.Remove(tssTaskManager4)
        ts.Items.Remove(tssTaskManager5)
        ts.Items.Remove(tssTaskManager6)
    End Sub
    ''' <summary>
    ''' Load and fill controls of settings page of module
    ''' </summary>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation, prepared by DanCooper
    ''' Triggered when user enters settings in Ember
    Public Function InjectSettingsPanel() As Containers.SettingsPanel Implements Interfaces.Addon.InjectSettingsPanel
        LoadSettings()
        Dim nSettingsPanel As New Containers.SettingsPanel

        _settingspanel = New frmSettingsPanel
        _settingspanel.chkEnabled.Checked = _enabled
        _settingspanel.chkGetWatchedState.Checked = _addonsettings.GetWatchedState
        _settingspanel.chkGetWatchedStateBeforeEdit_Movie.Checked = _addonsettings.GetWatchedStateBeforeEdit_Movie
        _settingspanel.chkGetWatchedStateBeforeEdit_TVEpisode.Checked = _addonsettings.GetWatchedStateBeforeEdit_TVEpisode
        _settingspanel.chkGetWatchedStateScraperMulti_Movie.Checked = _addonsettings.GetWatchedStateScraperMulti_Movie
        _settingspanel.chkGetWatchedStateScraperMulti_TVEpisode.Checked = _addonsettings.GetWatchedStateScraperMulti_TVEpisode
        _settingspanel.chkGetWatchedStateScraperSingle_Movie.Checked = _addonsettings.GetWatchedStateScraperSingle_Movie
        _settingspanel.chkGetWatchedStateScraperSingle_TVEpisode.Checked = _addonsettings.GetWatchedStateScraperSingle_TVEpisode
        _settingspanel.chkNotification.Checked = _addonsettings.SendNotifications
        If _addonsettings.GetWatchedState Then
            _settingspanel.cbGetWatchedStateHost.Enabled = True
        Else
            _settingspanel.cbGetWatchedStateHost.Enabled = False
        End If
        _settingspanel.HostList = _addonsettings.Hosts
        _settingspanel.lbHosts.Items.Clear()
        For Each tHost As Host In _settingspanel.HostList
            _settingspanel.cbGetWatchedStateHost.Items.Add(tHost.Label)
            _settingspanel.lbHosts.Items.Add(tHost.Label)
        Next
        _settingspanel.cbGetWatchedStateHost.SelectedIndex = _settingspanel.cbGetWatchedStateHost.FindStringExact(_addonsettings.GetWatchedStateHost)

        nSettingsPanel.ImageIndex = If(_enabled, 9, 10)
        nSettingsPanel.Name = _shortname
        nSettingsPanel.Panel = _settingspanel.pnlSettings()
        nSettingsPanel.Prefix = "KodiInterface_"
        nSettingsPanel.Title = "Kodi Interface"
        nSettingsPanel.Type = Enums.SettingsPanelType.Addon

        AddHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
        AddHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
        Return nSettingsPanel
    End Function

    Public Sub SaveSetup(ByVal bDoDispose As Boolean) Implements Interfaces.Addon.SaveSetup
        Enabled = _settingspanel.chkEnabled.Checked
        _addonsettings.SendNotifications = _settingspanel.chkNotification.Checked
        _addonsettings.GetWatchedState = _settingspanel.chkGetWatchedState.Checked AndAlso _settingspanel.cbGetWatchedStateHost.SelectedItem IsNot Nothing
        _addonsettings.GetWatchedStateBeforeEdit_Movie = _settingspanel.chkGetWatchedStateBeforeEdit_Movie.Checked
        _addonsettings.GetWatchedStateBeforeEdit_TVEpisode = _settingspanel.chkGetWatchedStateBeforeEdit_TVEpisode.Checked
        _addonsettings.GetWatchedStateScraperMulti_Movie = _settingspanel.chkGetWatchedStateScraperMulti_Movie.Checked
        _addonsettings.GetWatchedStateScraperMulti_TVEpisode = _settingspanel.chkGetWatchedStateScraperMulti_TVEpisode.Checked
        _addonsettings.GetWatchedStateScraperSingle_Movie = _settingspanel.chkGetWatchedStateScraperSingle_Movie.Checked
        _addonsettings.GetWatchedStateScraperSingle_TVEpisode = _settingspanel.chkGetWatchedStateScraperSingle_TVEpisode.Checked
        _addonsettings.GetWatchedStateHost = If(_settingspanel.cbGetWatchedStateHost.SelectedItem IsNot Nothing, _settingspanel.cbGetWatchedStateHost.SelectedItem.ToString(), String.Empty)

        SaveSettings()

        If Enabled Then PopulateMenus()
        If bDoDispose Then
            RemoveHandler _settingspanel.SettingsChanged, AddressOf Handle_SettingsChanged
            RemoveHandler _settingspanel.StateChanged, AddressOf Handle_StateChanged
            _settingspanel.Dispose()
        End If
    End Sub

    Sub SaveSettings()
        If Not File.Exists(_xmlSettingsPath) OrElse (Not CBool(File.GetAttributes(_xmlSettingsPath) And FileAttributes.ReadOnly)) Then
            If File.Exists(_xmlSettingsPath) Then
                Dim fAtt As FileAttributes = File.GetAttributes(_xmlSettingsPath)
                Try
                    File.SetAttributes(_xmlSettingsPath, FileAttributes.Normal)
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
            End If
            Using xmlSW As New StreamWriter(_xmlSettingsPath)
                Dim xmlSer As New XmlSerializer(GetType(AddonSettings))
                xmlSer.Serialize(xmlSW, _addonsettings)
            End Using
        End If
    End Sub
    ''' <summary>
    ''' Get movie playcount from Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Get Movie Playcount"</param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmnuHostGetPlaycount_Movie_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim mHost As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If mHost IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idMovie").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_Movie(ID)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = mHost, .mInternalType = InternalType.GetPlaycount, .mType = Enums.AddonEventType.Task})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Get episode playcount on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Get TVEpisode Playcount"</param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmnuHostGetPlaycount_TVEpisode_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVEpisodes.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idEpisode").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVEpisode(ID, True)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mInternalType = InternalType.GetPlaycount, .mType = Enums.AddonEventType.Task})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Get episodes playcount for whole season on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Get TVSeason Playcount"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation
    ''' Update details of season in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostGetPlaycount_TVSeason_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVSeasons.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idSeason").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVSeason(ID, True, True)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    'add job to tasklist and get everything done
                    AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mInternalType = InternalType.GetPlaycount, .mType = Enums.AddonEventType.Task})
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Get episodes playcount for whole tv show on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Get Tvshow Playcount"</param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmnuHostGetPlaycount_TVShow_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idShow").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVShow(ID, True, True)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mInternalType = InternalType.GetPlaycount, .mType = Enums.AddonEventType.Task})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Remove movie details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Remove Movie"</param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmnuHostRemoveItem_Movie_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idMovie").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_Movie(ID)
                'add job to tasklist and get everything done
                AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Remove_Movie})
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Remove tvepisode details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Remove TVEpisode"</param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmnuHostRemoveItem_TVEpisode_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVEpisodes.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idEpisode").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVEpisode(ID, True)
                'add job to tasklist and get everything done
                AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Remove_TVEpisode})
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Remove details of tvshow on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Remove Tvshow"</param>
    ''' <remarks>
    ''' </remarks>
    Private Sub cmnuHostRemoveItem_TVShow_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idShow").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVShow(ID, False, False)
                'add job to tasklist and get everything done
                AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Remove_TVShow})
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update movie details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync Movie"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation, prepared by DanCooper
    ''' Update details of movie in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncItem_Movie_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idMovie").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_Movie(ID)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_Movie})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update movieset details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync Movieset"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation
    ''' Update details of movieset in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncItem_MovieSet_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListMovieSets.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idSet").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_MovieSet(ID)
                If DBElement.MainDetails.TitleSpecified Then
                    'add job to tasklist and get everything done
                    AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_MovieSet})
                Else
                    Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update episode details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync TVEpisode"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation, prepared by DanCooper
    ''' Update details of episode in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncItem_TVEpisode_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVEpisodes.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idEpisode").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVEpisode(ID, True)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_TVEpisode})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update season details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync TVSeason"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation
    ''' Update details of season in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncItem_TVSeason_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVSeasons.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idSeason").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVSeason(ID, True, False)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    'add job to tasklist and get everything done
                    AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_TVSeason})
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update season and episodes details on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync TVSeason"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation
    ''' Update details of season in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncFullItem_TVSeason_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVSeasons.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idSeason").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVSeason(ID, True, True)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    'add job to tasklist and get everything done
                    AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_TVSeason})
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update details of tvshow on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync Tvshow"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation, prepared by DanCooper
    ''' Update details of tvshow in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncItem_TVShow_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idShow").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVShow(ID, False, False)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_TVShow})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    ''' Update details of tvshow, seasons and episodes on Host DB
    ''' </summary>
    ''' <param name="sender">context menu "Sync Tvshow"</param>
    ''' <remarks>
    ''' 2015/06/27 Cocotus - First implementation, prepared by DanCooper
    ''' Update details of tvshow in Kodi DB
    ''' </remarks>
    Private Sub cmnuHostSyncFullItem_TVShow_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            For Each sRow As DataGridViewRow In AddonsManager.Instance.RuntimeObjects.MediaListTVShows.SelectedRows
                Dim ID As Long = Convert.ToInt64(sRow.Cells("idShow").Value)
                Dim DBElement As Database.DBElement = Master.DB.Load_TVShow(ID, True, True)
                If DBElement.IsOnline OrElse FileUtils.Common.CheckOnlineStatus(DBElement, True) Then
                    If DBElement.NfoPathSpecified Then
                        'add job to tasklist and get everything done
                        AddTask(New KodiTask With {.mDBElement = DBElement, .mHost = Host, .mType = Enums.AddonEventType.Sync_TVShow})
                    Else
                        Notifications.Show(New Notifications.Notification(Enums.NotificationType.Error, "Kodi Interface", Master.eLang.GetString(1442, "Please Scrape In Ember First!")))
                    End If
                End If
            Next
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    '''  Clean video library of submitted host
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub mnuHostCleanVideoLibrary_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            Dim _APIKodi As New Kodi.APIKodi(Host)
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Host.Label & " | " & Master.eLang.GetString(1450, "Cleaning Video Library..."), New Bitmap(My.Resources.logo)))

            'add job to tasklist and get everything done
            AddTask(New KodiTask With {.mHost = Host, .mInternalType = InternalType.VideoLibrary_Clean, .mType = Enums.AddonEventType.Task})
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    '''  Scan video library of submitted host
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub mnuHostScanVideoLibrary_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            Dim _APIKodi As New Kodi.APIKodi(Host)
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Host.Label & " | " & Master.eLang.GetString(1448, "Updating Video Library..."), New Bitmap(My.Resources.logo)))

            'add job to tasklist and get everything done
            AddTask(New KodiTask With {.mHost = Host, .mInternalType = InternalType.VideoLibrary_Update, .mType = Enums.AddonEventType.Task})
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub
    ''' <summary>
    '''  Scan video library of submitted host
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub mnuHostGetPlaycount_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Host As Host = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Host)
        If Host IsNot Nothing Then
            Dim _APIKodi As New Kodi.APIKodi(Host)
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Host.Label & " | " & Master.eLang.GetString(1448, "Updating Video Library..."), New Bitmap(My.Resources.logo)))

            'add job to tasklist and get everything done
            AddTask(New KodiTask With {.mHost = Host, .mInternalType = InternalType.GetPlaycount, .mType = Enums.AddonEventType.Task})
        Else
            Notifications.Show(New Notifications.Notification(Enums.NotificationType.Info, "Kodi Interface", Master.eLang.GetString(1447, "No Host Configured!")))
        End If
    End Sub

    Public Sub AddToolStripItem(control As ToolStripMenuItem, value As ToolStripItem)
        If control.Owner IsNot Nothing Then
            If control.Owner.InvokeRequired Then
                control.Owner.Invoke(New Delegate_AddToolStripMenuItem(AddressOf AddToolStripItem), New Object() {control, value})
            Else
                control.DropDownItems.Add(value)
            End If
        End If
    End Sub

    Public Sub AddToolStripItem(control As ToolStrip, value As ToolStripItem)
        If control.InvokeRequired Then
            control.Invoke(New Delegate_SetToolStripItem(AddressOf AddToolStripItem), New Object() {control, value})
        Else
            control.Items.Add(value)
        End If
    End Sub

    Public Sub ChangeTaskManagerStatus(control As ToolStripLabel, value As String)
        If control.Owner.InvokeRequired Then
            control.Owner.BeginInvoke(New Delegate_ChangeTaskManagerStatus(AddressOf ChangeTaskManagerStatus), New Object() {control, value})
        Else
            control.Text = value
        End If
    End Sub

    Public Sub ChangeTaskManagerProgressBar(control As ToolStripProgressBar, value As ProgressBarStyle)
        If control.Owner.InvokeRequired Then
            control.Owner.BeginInvoke(New Delegate_ChangeTaskManagerProgressBar(AddressOf ChangeTaskManagerProgressBar), New Object() {control, value})
        Else
            control.Style = value
        End If
    End Sub

    Public Sub RemoveToolStripItem_Movies(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Invoke(New Delegate_RemoveToolStripItem(AddressOf RemoveToolStripItem_Movies), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Items.Remove(value)
        End If
    End Sub

    Public Sub RemoveToolStripItem_MovieSets(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuMovieSetList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieSetList.Invoke(New Delegate_RemoveToolStripItem(AddressOf RemoveToolStripItem_MovieSets), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieSetList.Items.Remove(value)
        End If
    End Sub

    Public Sub RemoveToolStripItem_TVEpisodes(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Invoke(New Delegate_RemoveToolStripItem(AddressOf RemoveToolStripItem_TVEpisodes), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Items.Remove(value)
        End If
    End Sub

    Public Sub RemoveToolStripItem_TVSeasons(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVSeasonList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVSeasonList.Invoke(New Delegate_RemoveToolStripItem(AddressOf RemoveToolStripItem_TVSeasons), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVSeasonList.Items.Remove(value)
        End If
    End Sub

    Public Sub RemoveToolStripItem_TVShows(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Invoke(New Delegate_RemoveToolStripItem(AddressOf RemoveToolStripItem_TVShows), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Items.Remove(value)
        End If
    End Sub

    Public Sub SetToolStripItem_Movies(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Invoke(New Delegate_AddToolStripItem(AddressOf SetToolStripItem_Movies), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieList.Items.Add(value)
        End If
    End Sub

    Public Sub AddToolStripItem_MovieSets(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuMovieSetList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieSetList.Invoke(New Delegate_AddToolStripItem(AddressOf AddToolStripItem_MovieSets), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuMovieSetList.Items.Add(value)
        End If
    End Sub

    Public Sub AddToolStripItem_TVEpisodes(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Invoke(New Delegate_AddToolStripItem(AddressOf AddToolStripItem_TVEpisodes), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVEpisodeList.Items.Add(value)
        End If
    End Sub

    Public Sub AddToolStripItem_TVSeasons(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVSeasonList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVSeasonList.Invoke(New Delegate_AddToolStripItem(AddressOf AddToolStripItem_TVSeasons), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVSeasonList.Items.Add(value)
        End If
    End Sub

    Public Sub AddToolStripItem_TVShows(value As ToolStripItem)
        If AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.InvokeRequired Then
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Invoke(New Delegate_AddToolStripItem(AddressOf AddToolStripItem_TVShows), New Object() {value})
        Else
            AddonsManager.Instance.RuntimeObjects.ContextMenuTVShowList.Items.Add(value)
        End If
    End Sub

    Private Sub Handle_SettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub Handle_StateChanged(ByVal bEnabled As Boolean)
        RaiseEvent StateChanged(_shortname, bEnabled)
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Structure GenericEventCallBackAsync

        Dim tEventType As Enums.AddonEventType
        Dim tParams As List(Of Object)

    End Structure

    Public Structure GenericSubEventCallBackAsync

        Dim tGenericEventCallBackAsync As GenericEventCallBackAsync
        Dim tProgress As IProgress(Of GenericEventCallBackAsync)

    End Structure

    Private Enum InternalType

        None = 0
        GetPlaycount = 1
        VideoLibrary_Clean = 2
        VideoLibrary_Update = 3

    End Enum
    ''' <summary>
    ''' structure used to store Update Movie/TV/Movieset-Tasks for Kodi Interface
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure KodiTask

        Dim mDBElement As Database.DBElement
        Dim mHost As Host
        Dim mInternalType As InternalType
        Dim mType As Enums.AddonEventType

    End Structure

    <Serializable()>
    <XmlRoot("interface.kodi")>
    Class AddonSettings

#Region "Fields"

        Private _hosts As New List(Of Host)
        Private _sendnotifications As Boolean
        Private _getwatchedstate As Boolean
        Private _getwatchedstatebeforeedit_movie As Boolean
        Private _getwatchedstatebeforeedit_tvepisode As Boolean
        Private _getwatchedstatescrapermulti_movie As Boolean
        Private _getwatchedstatescrapermulti_tvepisode As Boolean
        Private _getwatchedstatescrapersingle_movie As Boolean
        Private _getwatchedstatescrapersingle_tvepisode As Boolean
        Private _getwatchedstatehost As String

#End Region 'Fields

#Region "Properties"

        <XmlElement("getwatchedstate")>
        Public Property GetWatchedState() As Boolean
            Get
                Return _getwatchedstate
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstate = value
            End Set
        End Property

        <XmlElement("getwatchedstatebeforeedit_movie")>
        Public Property GetWatchedStateBeforeEdit_Movie() As Boolean
            Get
                Return _getwatchedstatebeforeedit_movie
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatebeforeedit_movie = value
            End Set
        End Property

        <XmlElement("getwatchedstatebeforeedit_tvepisode")>
        Public Property GetWatchedStateBeforeEdit_TVEpisode() As Boolean
            Get
                Return _getwatchedstatebeforeedit_tvepisode
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatebeforeedit_tvepisode = value
            End Set
        End Property

        <XmlElement("getwatchedstatehost")>
        Public Property GetWatchedStateHost() As String
            Get
                Return _getwatchedstatehost
            End Get
            Set(ByVal value As String)
                _getwatchedstatehost = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapermulti_movie")>
        Public Property GetWatchedStateScraperMulti_Movie() As Boolean
            Get
                Return _getwatchedstatescrapermulti_movie
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapermulti_movie = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapermulti_tvepisode")>
        Public Property GetWatchedStateScraperMulti_TVEpisode() As Boolean
            Get
                Return _getwatchedstatescrapermulti_tvepisode
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapermulti_tvepisode = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapersingle_movie")>
        Public Property GetWatchedStateScraperSingle_Movie() As Boolean
            Get
                Return _getwatchedstatescrapersingle_movie
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapersingle_movie = value
            End Set
        End Property

        <XmlElement("getwatchedstatescrapersingle_tvepisode")>
        Public Property GetWatchedStateScraperSingle_TVEpisode() As Boolean
            Get
                Return _getwatchedstatescrapersingle_tvepisode
            End Get
            Set(ByVal value As Boolean)
                _getwatchedstatescrapersingle_tvepisode = value
            End Set
        End Property

        <XmlElement("host")>
        Public Property Hosts() As List(Of Host)
            Get
                Return _hosts
            End Get
            Set(ByVal value As List(Of Host))
                _hosts = value
            End Set
        End Property

        <XmlElement("sendnotifications")>
        Public Property SendNotifications() As Boolean
            Get
                Return _sendnotifications
            End Get
            Set(ByVal value As Boolean)
                _sendnotifications = value
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
            _hosts.Clear()
            _sendnotifications = False
            _getwatchedstate = False
            _getwatchedstatebeforeedit_movie = False
            _getwatchedstatebeforeedit_tvepisode = False
            _getwatchedstatehost = String.Empty
            _getwatchedstatescrapermulti_movie = False
            _getwatchedstatescrapermulti_tvepisode = False
            _getwatchedstatescrapersingle_movie = False
            _getwatchedstatescrapersingle_tvepisode = False
        End Sub

#End Region 'Methods

    End Class

    <Serializable()>
    Class Host

#Region "Fields"

        Private _address As String
        Private _label As String
        Private _moviesetartworkspath As String
        Private _password As String
        Private _port As Integer
        Private _realtimesync As Boolean
        Private _sources As New List(Of Source)
        Private _username As String

#End Region 'Fields

#Region "Properties"

        <XmlElement("label")>
        Public Property Label() As String
            Get
                Return _label
            End Get
            Set(ByVal value As String)
                _label = value
            End Set
        End Property

        <XmlElement("address")>
        Public Property Address() As String
            Get
                Return _address
            End Get
            Set(ByVal value As String)
                _address = value
            End Set
        End Property

        <XmlElement("port")>
        Public Property Port() As Integer
            Get
                Return _port
            End Get
            Set(ByVal value As Integer)
                _port = value
            End Set
        End Property

        <XmlElement("username")>
        Public Property Username() As String
            Get
                Return _username
            End Get
            Set(ByVal value As String)
                _username = value
            End Set
        End Property

        <XmlElement("password")>
        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                _password = value
            End Set
        End Property

        <XmlElement("realtimesync")>
        Public Property RealTimeSync() As Boolean
            Get
                Return _realtimesync
            End Get
            Set(ByVal value As Boolean)
                _realtimesync = value
            End Set
        End Property

        <XmlElement("moviesetartworkspath")>
        Public Property MovieSetArtworksPath() As String
            Get
                Return _moviesetartworkspath
            End Get
            Set(ByVal value As String)
                _moviesetartworkspath = value
            End Set
        End Property

        <XmlElement("source")>
        Public Property Sources() As List(Of Source)
            Get
                Return _sources
            End Get
            Set(ByVal value As List(Of Source))
                _sources = value
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
            _address = "localhost"
            _moviesetartworkspath = String.Empty
            _label = "New Host"
            _password = String.Empty
            _port = 80
            _realtimesync = False
            _sources.Clear()
            _username = "kodi"
        End Sub

#End Region 'Methods

    End Class


    <Serializable()>
    Class Source


#Region "Fields"

        Private _contenttype As Enums.ContentType
        Private _localpath As String
        Private _remotepath As String

#End Region 'Fields

#Region "Properties"

        <XmlElement("contenttype")>
        Public Property ContentType() As Enums.ContentType
            Get
                Return _contenttype
            End Get
            Set(ByVal value As Enums.ContentType)
                _contenttype = value
            End Set
        End Property

        <XmlElement("localpath")>
        Public Property LocalPath() As String
            Get
                Return _localpath
            End Get
            Set(ByVal value As String)
                _localpath = value
            End Set
        End Property

        <XmlElement("remotepath")>
        Public Property RemotePath() As String
            Get
                Return _remotepath
            End Get
            Set(ByVal value As String)
                _remotepath = value
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
            _contenttype = Enums.ContentType.Movie
            _localpath = String.Empty
            _remotepath = String.Empty
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class
