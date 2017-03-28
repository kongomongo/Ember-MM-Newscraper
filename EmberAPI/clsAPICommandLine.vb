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
Imports NLog


Public Class CommandLine

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Events"

    Public Event TaskEvent(ByVal mType As Enums.AddonEventType, ByRef _params As List(Of Object))

    'Singleton Instace for CommandLine manager .. allways use this one
    Private Shared Singleton As CommandLine = Nothing

#End Region 'Events

#Region "Properties"

    Public Shared ReadOnly Property Instance() As CommandLine
        Get
            If (Singleton Is Nothing) Then
                Singleton = New CommandLine()
            End If
            Return Singleton
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Sub RunCommandLine(ByVal Args() As String)
        If Args.Count = 0 Then Return

        logger.Trace("Call CommandLine")

        Dim MoviePath As String = String.Empty
        Dim isSingle As Boolean = False
        Dim clExport As Boolean = False
        Dim clExportResizePoster As Integer = 0
        Dim clExportTemplate As String = "template"
        Dim nowindow As Boolean = False
        Dim RunModule As Boolean = False
        Dim ModuleName As String = String.Empty

        For i As Integer = 0 To Args.Count - 1

            Select Case Args(i).ToLower
                Case "-addmoviesource"
                    If Args.Count - 1 > i Then
                        If Directory.Exists(Args(i + 1).Replace("""", String.Empty)) Then
                            RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"addmoviesource", Args(i + 1).Replace("""", String.Empty)}))
                            i += 1
                        End If
                    Else
                        logger.Warn("[CommandLine] No path or invalid path specified for -addmoviesource command")
                    End If
                Case "-addtvshowsource"
                    If Args.Count - 1 > i Then
                        If Directory.Exists(Args(i + 1).Replace("""", String.Empty)) Then
                            RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"addtvshowsource", Args(i + 1).Replace("""", String.Empty)}))
                            i += 1
                        End If
                    Else
                        logger.Warn("[CommandLine] No path or invalid path specified for -addtvshowsource command")
                    End If
                Case "-cleanvideodb"
                    RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"cleanvideodb"}))
                Case "-run"
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        Dim strModuleName As String = Args(i + 1)
                        i += 1
                        Dim sParams As List(Of Object) = Nothing
                        i = SetModuleParameters(Args, i, sParams)
                        RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"run", strModuleName, sParams}))
                    Else
                        logger.Warn("[CommandLine] Missing module name for command ""-run""")
                    End If
                Case "-scanfolder"
                    If Args.Count - 1 > i Then
                        If Directory.Exists(Args(i + 1).Replace("""", String.Empty)) Then
                            RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.SpecificFolder = True}, -1, Args(i + 1).Replace("""", String.Empty)}))
                            i += 1
                        End If
                    Else
                        logger.Warn("[CommandLine] No path or invalid path specified for command ""-scanfolder""")
                    End If
                Case "-scrapemovies"
                    Dim nContentType As Enums.ContentType = Enums.ContentType.Movie
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        i += 1
                        Dim ScrapeType As String = Args(i)
                        Select Case ScrapeType
                            Case "allask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.AllAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "allauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.AllAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "allskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.AllSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.MarkedAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.MarkedAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.MarkedSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.MissingAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.MissingAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.MissingSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.NewAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.NewAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.NewSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case Else
                                logger.Warn("[CommandLine] Invalid ScrapeType specified for command ""-scrapemovies""")
                        End Select
                    Else
                        logger.Warn("[CommandLine] No ScrapeType specified for command ""-scrapemovies""")
                    End If
                Case "-scrapemoviesets"
                    Dim nContentType As Enums.ContentType = Enums.ContentType.Movieset
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        i += 1
                        Dim ScrapeType As String = Args(i)
                        Select Case ScrapeType
                            Case "allask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.AllAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "allauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.AllAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "allskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.AllSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.MarkedAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.MarkedAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.MarkedSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.MissingAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.MissingAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.MissingSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemoviesets", Enums.ScrapeType.NewAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.NewAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapemovies", Enums.ScrapeType.NewSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case Else
                                logger.Warn("[CommandLine] Invalid ScrapeType specified for command ""-scrapemoviesets""")
                        End Select
                    Else
                        logger.Warn("[CommandLine] No ScrapeType specified for command ""-scrapemoviesets""")
                    End If
                Case "-scrapetvshows"
                    Dim nContentType As Enums.ContentType = Enums.ContentType.TVShow
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        i += 1
                        Dim ScrapeType As String = Args(i)
                        Select Case ScrapeType
                            Case "allask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.AllAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "allauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.AllAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "allskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.AllSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.MarkedAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.MarkedAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "markedskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.MarkedSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.MissingAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.MissingAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "missingskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.MissingSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newask"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.NewAsk, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newauto"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.NewAuto, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case "newskip"
                                Dim CustomScrapeModifiers As New Structures.ScrapeModifiers
                                Dim CustomScrapeOptions As New Structures.ScrapeOptions
                                i = SetScraperModAndOpt(Args, i, CustomScrapeModifiers, CustomScrapeOptions, nContentType)
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine, New List(Of Object)(New Object() {"scrapetvshows", Enums.ScrapeType.NewSkip, CustomScrapeModifiers, CustomScrapeOptions}))
                            Case Else
                                logger.Warn("[CommandLine] Invalid ScrapeType specified for command ""-scrapemovies""")
                        End Select
                    Else
                        logger.Warn("[CommandLine] No ScrapeType specified for command ""-scrapemovies""")
                    End If
                Case "--verbose"
                Case "-nowindow"
                    Master.fLoading.Hide()
                Case "-updatemovies"
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        Dim clArg As String = Args(i + 1).Replace("""", String.Empty)
                        Dim sSource As Database.DBSource = Master.MovieSources.FirstOrDefault(Function(f) f.Name.ToLower = clArg.ToLower)
                        If sSource IsNot Nothing Then
                            RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.Movies = True}, sSource.ID, String.Empty}))
                            i += 1
                        Else
                            sSource = Master.MovieSources.FirstOrDefault(Function(f) f.Path.ToLower = clArg.ToLower)
                            If sSource IsNot Nothing Then
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                        New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.Movies = True}, sSource.ID, String.Empty}))
                                i += 1
                            Else
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.Movies = True}, -1, String.Empty}))
                            End If
                        End If
                    Else
                        RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.Movies = True}, -1, String.Empty}))
                    End If
                Case "-updatetvshows"
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        Dim clArg As String = Args(i + 1).Replace("""", String.Empty)
                        Dim sSource As Database.DBSource = Master.TVShowSources.FirstOrDefault(Function(f) f.Name.ToLower = clArg.ToLower)
                        If sSource IsNot Nothing Then
                            RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.TV = True}, sSource.ID, String.Empty}))
                            i += 1
                        Else
                            sSource = Master.TVShowSources.FirstOrDefault(Function(f) f.Path.ToLower = clArg.ToLower)
                            If sSource IsNot Nothing Then
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                        New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.TV = True}, sSource.ID, String.Empty}))
                                i += 1
                            Else
                                RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.TV = True}, -1, String.Empty}))
                            End If
                        End If
                    Else
                        RaiseEvent TaskEvent(Enums.AddonEventType.CommandLine,
                                                    New List(Of Object)(New Object() {"loadmedia", New Structures.ScanOrClean With {.TV = True}, -1, String.Empty}))
                    End If
                Case "-profile"
                    'has been handled in ApplicationEvents.vb
                    If Args.Count - 1 > i AndAlso Not Args(i + 1).StartsWith("-") Then
                        'skip profile name
                        i += 1
                    End If
                Case Else
                    logger.Warn(String.Concat("[CommandLine] Invalid command: ", Args(i)))
            End Select
        Next
    End Sub

    Private Function SetModuleParameters(ByVal Args() As String, ByVal iStartPos As Integer, ByRef Parameters As List(Of Object)) As Integer
        Dim iEndPos As Integer = iStartPos

        For i As Integer = iStartPos + 1 To Args.Count - 1
            If Not Args(i).StartsWith("-") Then
                If Parameters Is Nothing Then Parameters = New List(Of Object)
                Parameters.Add(Args(i))
            Else
                Return i - 1
            End If
            iEndPos = i
        Next

        Return iEndPos
    End Function

    Private Function SetScraperModAndOpt(ByVal Args() As String,
                                         ByVal iStartPos As Integer,
                                         ByRef tScrapeModifiers As Structures.ScrapeModifiers,
                                         ByRef tScrapeOptions As Structures.ScrapeOptions,
                                         ByVal tContentType As Enums.ContentType) As Integer
        Dim iEndPos As Integer = iStartPos

        For i As Integer = iStartPos + 1 To Args.Count - 1
            Select Case Args(i).ToLower
                'ScrapeModifiers
                Case "all"
                    tScrapeModifiers.AllSeasonsBanner = True
                    tScrapeModifiers.AllSeasonsFanart = True
                    tScrapeModifiers.AllSeasonsLandscape = True
                    tScrapeModifiers.AllSeasonsPoster = True
                    tScrapeModifiers.EpisodeActorThumbs = True
                    tScrapeModifiers.EpisodeFanart = True
                    tScrapeModifiers.EpisodeMeta = True
                    tScrapeModifiers.EpisodeNFO = True
                    tScrapeModifiers.EpisodePoster = True
                    tScrapeModifiers.MainActorthumbs = True
                    tScrapeModifiers.MainBanner = True
                    tScrapeModifiers.MainCharacterArt = True
                    tScrapeModifiers.MainClearArt = True
                    tScrapeModifiers.MainClearLogo = True
                    tScrapeModifiers.MainDiscArt = True
                    tScrapeModifiers.MainExtrafanarts = True
                    tScrapeModifiers.MainExtrathumbs = True
                    tScrapeModifiers.MainFanart = True
                    tScrapeModifiers.MainLandscape = True
                    tScrapeModifiers.MainMeta = True
                    tScrapeModifiers.MainNFO = True
                    tScrapeModifiers.MainPoster = True
                    tScrapeModifiers.MainSubtitles = True
                    tScrapeModifiers.MainTheme = True
                    tScrapeModifiers.MainTrailer = True
                    tScrapeModifiers.SeasonBanner = True
                    tScrapeModifiers.SeasonFanart = True
                    tScrapeModifiers.SeasonLandscape = True
                    tScrapeModifiers.SeasonNFO = True
                    tScrapeModifiers.SeasonPoster = True
                    tScrapeModifiers.withEpisodes = True
                    tScrapeModifiers.withSeasons = True
                    tScrapeOptions = Functions.ScrapeOptionsAllEnabled
                Case "episodeall"
                    tScrapeModifiers.EpisodeActorThumbs = True
                    tScrapeModifiers.EpisodeFanart = True
                    tScrapeModifiers.EpisodeMeta = True
                    tScrapeModifiers.EpisodeNFO = True
                    tScrapeModifiers.EpisodePoster = True
                    tScrapeModifiers.withEpisodes = True
                    tScrapeOptions = Functions.ScrapeOptionsAllEnabled
                Case "episodeactorthumbs"
                    tScrapeModifiers.EpisodeActorThumbs = True
                    tScrapeModifiers.withEpisodes = True
                Case "episodefanart"
                    tScrapeModifiers.EpisodeFanart = True
                    tScrapeModifiers.withEpisodes = True
                Case "episodemeta"
                    tScrapeModifiers.EpisodeMeta = True
                    tScrapeModifiers.withEpisodes = True
                Case "episodenfo"
                    tScrapeModifiers.EpisodeNFO = True
                    tScrapeModifiers.withEpisodes = True
                Case "episodeposter"
                    tScrapeModifiers.EpisodePoster = True
                    tScrapeModifiers.withEpisodes = True
                Case "actorthumbs"
                    tScrapeModifiers.MainActorthumbs = True
                Case "banner"
                    tScrapeModifiers.MainBanner = True
                Case "characterart"
                    tScrapeModifiers.MainCharacterArt = True
                Case "clearart"
                    tScrapeModifiers.MainClearArt = True
                Case "clearlogo"
                    tScrapeModifiers.MainClearLogo = True
                Case "discart"
                    tScrapeModifiers.MainDiscArt = True
                Case "extrafanarts"
                    tScrapeModifiers.MainExtrafanarts = True
                Case "extrathumbs"
                    tScrapeModifiers.MainExtrathumbs = True
                Case "fanart"
                    tScrapeModifiers.MainFanart = True
                Case "landscape"
                    tScrapeModifiers.MainLandscape = True
                Case "meta"
                    tScrapeModifiers.MainMeta = True
                Case "nfo"
                    tScrapeModifiers.MainNFO = True
                    tScrapeOptions = Functions.ScrapeOptionsAllEnabled
                Case "poster"
                    tScrapeModifiers.MainPoster = True
                Case "subtitles"
                    tScrapeModifiers.MainSubtitles = True
                Case "theme"
                    tScrapeModifiers.MainTheme = True
                Case "trailer"
                    tScrapeModifiers.MainTrailer = True
                Case "seasonall"
                    tScrapeModifiers.SeasonBanner = True
                    tScrapeModifiers.SeasonFanart = True
                    tScrapeModifiers.SeasonLandscape = True
                    tScrapeModifiers.SeasonNFO = True
                    tScrapeModifiers.SeasonPoster = True
                    tScrapeModifiers.withSeasons = True
                    tScrapeOptions = Functions.ScrapeOptionsAllEnabled
                Case "seasonbanner"
                    tScrapeModifiers.SeasonBanner = True
                    tScrapeModifiers.withSeasons = True
                Case "seasonfanart"
                    tScrapeModifiers.SeasonFanart = True
                    tScrapeModifiers.withSeasons = True
                Case "seasonlandscape"
                    tScrapeModifiers.SeasonLandscape = True
                    tScrapeModifiers.withSeasons = True
                Case "seasonnfo"
                    tScrapeModifiers.SeasonNFO = True
                    tScrapeModifiers.withSeasons = True
                Case "seasonposter"
                    tScrapeModifiers.SeasonPoster = True
                    tScrapeModifiers.withSeasons = True

                'ScrapeOptions
                'TVEpisode specific
                Case "episodeactors"
                    tScrapeOptions.bEpisodeActors = True
                Case "episodeaired"
                    tScrapeOptions.bEpisodeAired = True
                Case "episodecredits"
                    tScrapeOptions.bEpisodeCredits = True
                Case "episodedirectors"
                    tScrapeOptions.bEpisodeDirectors = True
                Case "episodegueststars"
                    tScrapeOptions.bEpisodeGuestStars = True
                Case "episodeplot"
                    tScrapeOptions.bEpisodePlot = True
                Case "episoderating"
                    tScrapeOptions.bEpisodeRating = True
                Case "episoderuntime"
                    tScrapeOptions.bEpisodeRuntime = True
                Case "episodetitle"
                    tScrapeOptions.bEpisodeTitle = True
                Case "episodeuserrating"
                    tScrapeOptions.bEpisodeUserRating = True

                'MainDetails
                Case "actors"
                    tScrapeOptions.bMainActors = True
                Case "certifications"
                    tScrapeOptions.bMainCertifications = True
                    tScrapeOptions.bMainMPAA = True
                Case "collectionid"
                    tScrapeOptions.bMainCollectionID = True
                Case "countries"
                    tScrapeOptions.bMainCountries = True
                Case "creators"
                    tScrapeOptions.bMainCreators = True
                Case "directors"
                    tScrapeOptions.bMainDirectors = True
                Case "episodeguide"
                    tScrapeOptions.bMainEpisodeGuide = True
                Case "genres"
                    tScrapeOptions.bMainGenres = True
                Case "mpaa"
                    tScrapeOptions.bMainMPAA = True
                    tScrapeOptions.bMainCertifications = True
                Case "originaltitle"
                    tScrapeOptions.bMainOriginalTitle = True
                Case "outline"
                    tScrapeOptions.bMainOutline = True
                Case "plot"
                    tScrapeOptions.bMainPlot = True
                Case "premiered"
                    tScrapeOptions.bMainPremiered = True
                Case "rating"
                    tScrapeOptions.bMainRating = True
                Case "release"
                    tScrapeOptions.bMainRelease = True
                Case "runtime"
                    tScrapeOptions.bMainRuntime = True
                Case "status"
                    tScrapeOptions.bMainStatus = True
                Case "tagline"
                    tScrapeOptions.bMainTagline = True
                Case "title"
                    tScrapeOptions.bMainTitle = True
                Case "top250"
                    tScrapeOptions.bMainTop250 = True
                Case "trailer"
                    tScrapeOptions.bMainTrailer = True
                Case "rating"
                    tScrapeOptions.bMainUserRating = True
                Case "writers"
                    tScrapeOptions.bMainWriters = True
                Case "year"
                    tScrapeOptions.bMainYear = True

                'Season specified
                Case "seasonaired"
                    tScrapeOptions.bSeasonAired = True
                Case "seasonplot"
                    tScrapeOptions.bSeasonPlot = True
                Case "seasontitle"
                    tScrapeOptions.bSeasonTitle = True

                    'go back
                Case Else
                    Return i - 1
            End Select
            iEndPos = i
        Next

        Return iEndPos
    End Function

#End Region 'Methods

End Class
