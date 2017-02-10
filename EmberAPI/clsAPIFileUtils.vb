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
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports NLog

Namespace FileUtils

    Public Class CleanUp

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Delegates"

        Public Delegate Function ReportProgress(ByVal iProgress As Integer, ByVal strMessage As String) As Boolean

#End Region 'Delegates

#Region "Methods"

        Public Shared Function DoCleanUp(Optional ByVal sfunction As ReportProgress = Nothing) As Boolean
            Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MyVideosDBConn.BeginTransaction()
                Using SQLCommand As SQLite.SQLiteCommand = Master.DB.MyVideosDBConn.CreateCommand()
                    SQLCommand.CommandText = String.Format("SELECT idMovie FROM movie ORDER BY Title ASC;")
                    Using SQLReader As SQLite.SQLiteDataReader = SQLCommand.ExecuteReader()
                        While SQLReader.Read()
                            Dim tmpMovie As Database.DBElement = Master.DB.Load_Movie(Convert.ToInt32(SQLReader("idMovie")))
                            Dim fScanner As New Scanner
                            fScanner.GetFolderContents_Movie(tmpMovie, True)
                            Master.DB.Save_Movie(tmpMovie, True, True, True, True, True)
                        End While
                    End Using
                End Using
                SQLtransaction.Commit()
            End Using

            Return True
        End Function

#End Region 'Methods

    End Class

    Public Class Common

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Methods"

        Public Shared Sub CopyFanartToBackdropsPath(ByVal strSourceFilename As String, ByVal ContentType As Enums.ContentType)
            If Not String.IsNullOrEmpty(strSourceFilename) AndAlso File.Exists(strSourceFilename) Then
                Dim strDestinationFilename As String = String.Empty
                Select Case ContentType
                    Case Enums.ContentType.Movie
                        If String.IsNullOrEmpty(Master.eSettings.MovieBackdropsPath) Then Return

                        If isVideoTS(strSourceFilename) Then
                            strDestinationFilename = Path.Combine(Master.eSettings.MovieBackdropsPath, String.Concat(Path.Combine(GetMainPath(strSourceFilename).FullName, GetMainPath(strSourceFilename).Name), "-fanart.jpg"))
                        ElseIf isBDRip(strSourceFilename) Then
                            strDestinationFilename = Path.Combine(Master.eSettings.MovieBackdropsPath, String.Concat(GetMainPath(strSourceFilename).Name, "-fanart.jpg"))
                        Else
                            strDestinationFilename = Path.Combine(Master.eSettings.MovieBackdropsPath, String.Concat(GetMainPath(strSourceFilename).Name, "-fanart.jpg"))
                        End If
                End Select

                If Not String.IsNullOrEmpty(strDestinationFilename) Then
                    Try
                        If Not Directory.Exists(Directory.GetParent(strDestinationFilename).FullName) Then
                            Directory.CreateDirectory(Directory.GetParent(strDestinationFilename).FullName)
                        End If
                        File.Copy(strSourceFilename, strDestinationFilename, True)
                    Catch ex As Exception
                        logger.Error(ex, New StackFrame().GetMethod().Name)
                    End Try
                End If
            End If
        End Sub

        Public Shared Sub DirectoryCopy(
                                       ByVal strSourceDir As String,
                                       ByVal strDestinationDir As String,
                                       ByVal withSubDirs As Boolean,
                                       ByVal overwriteFiles As Boolean)

            If Not Directory.Exists(strSourceDir) Then
                logger.Error(String.Concat("Source directory does not exist: ", strSourceDir))
                Exit Sub
            End If

            ' Get the subdirectories for the specified directory.
            Dim dir As DirectoryInfo = New DirectoryInfo(strSourceDir)
            Dim subdirs As DirectoryInfo() = dir.GetDirectories()

            ' If the destination directory doesn't exist, create it.
            If Not Directory.Exists(strDestinationDir) Then
                Directory.CreateDirectory(strDestinationDir)
            End If

            ' Get the files in the directory and copy them to the new location.
            Dim files As FileInfo() = dir.GetFiles()
            For Each cFile In files
                Dim temppath As String = Path.Combine(strDestinationDir, cFile.Name)
                If Not File.Exists(temppath) OrElse overwriteFiles Then
                    cFile.CopyTo(temppath, overwriteFiles)
                End If
            Next cFile

            ' If copying subdirectories, copy them and their contents to new location.
            If withSubDirs Then
                For Each subdir In subdirs
                    Dim temppath As String = Path.Combine(strDestinationDir, subdir.Name)
                    DirectoryCopy(subdir.FullName, temppath, withSubDirs, overwriteFiles)
                Next subdir
            End If
        End Sub

        Public Shared Sub DirectoryMove(
                                       ByVal strSourceDir As String,
                                       ByVal strDestinationDir As String,
                                       ByVal withSubDirs As Boolean,
                                       ByVal overwriteFiles As Boolean)

            If Not Directory.Exists(strSourceDir) Then
                logger.Error(String.Concat("Source directory does not exist: ", strSourceDir))
                Exit Sub
            End If

            If Path.GetPathRoot(strSourceDir).ToLower = Path.GetPathRoot(strDestinationDir).ToLower AndAlso withSubDirs Then
                If Not Directory.Exists(Directory.GetParent(strDestinationDir).FullName) Then Directory.CreateDirectory(Directory.GetParent(strDestinationDir).FullName)
                Directory.Move(strSourceDir, strDestinationDir)
            Else
                ' Get the subdirectories for the specified directory.
                Dim dir As DirectoryInfo = New DirectoryInfo(strSourceDir)
                Dim subdirs As DirectoryInfo() = dir.GetDirectories()

                ' If the destination directory doesn't exist, create it.
                If Not Directory.Exists(strDestinationDir) Then
                    Directory.CreateDirectory(strDestinationDir)
                End If

                ' Get the files in the directory and move them to the new location.
                Dim files As FileInfo() = dir.GetFiles()
                For Each cFile In files
                    Dim temppath As String = Path.Combine(strDestinationDir, cFile.Name)
                    If Not File.Exists(temppath) OrElse overwriteFiles Then
                        If File.Exists(temppath) Then File.Delete(temppath)
                        cFile.MoveTo(temppath)
                    End If
                Next

                ' If copying subdirectories, copy them and their contents to new location.
                If withSubDirs Then
                    For Each subdir In subdirs
                        Dim temppath As String = Path.Combine(strDestinationDir, subdir.Name)
                        DirectoryMove(subdir.FullName, temppath, withSubDirs, overwriteFiles)
                    Next subdir
                End If

                If dir.GetFiles.Count = 0 AndAlso dir.GetDirectories.Count = 0 Then
                    Directory.Delete(dir.FullName)
                End If
            End If
        End Sub

        Public Shared Function GetAllItemsOfDBElement(ByVal tDBElement As Database.DBElement) As List(Of FileSystemInfo)
            Dim lstItems As New List(Of FileSystemInfo)

            Select Case tDBElement.ContentType
                Case Enums.ContentType.Movie, Enums.ContentType.TVEpisode
                    If tDBElement.FileItemSpecified Then
                        With tDBElement.FileItem
                            If tDBElement.IsSingle OrElse .bIsBDMV OrElse .bIsVideoTS Then
                                lstItems.Add(.MainPath)
                            Else
                                Select Case tDBElement.ContentType
                                    Case Enums.ContentType.Movie
                                        For Each nFileItem In .PathList
                                            lstItems.Add(New FileInfo(nFileItem))
                                            Dim lstFiles As New List(Of String)
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainBanner))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainCharacterArt))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainClearArt))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainClearLogo))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainDiscArt))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainFanart))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainLandscape))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainNFO))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainPoster))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainTheme))
                                            lstFiles.AddRange(GetFilenameList.Movie(tDBElement, Enums.ScrapeModifierType.MainTrailer))
                                            lstFiles = lstFiles.Distinct().ToList()  'remove double entries
                                            lstFiles.Sort()
                                            For Each nFile In lstFiles
                                                Dim nFileinfo As New FileInfo(nFile)
                                                If nFileinfo.Exists Then lstItems.Add(nFileinfo)
                                            Next
                                        Next

                                    Case Enums.ContentType.TVEpisode
                                        For Each nFileItem In .PathList
                                            lstItems.Add(New FileInfo(nFileItem))
                                            Dim lstFiles As New List(Of String)
                                            lstFiles.AddRange(GetFilenameList.TVEpisode(tDBElement, Enums.ScrapeModifierType.EpisodeFanart))
                                            lstFiles.AddRange(GetFilenameList.TVEpisode(tDBElement, Enums.ScrapeModifierType.EpisodeNFO))
                                            lstFiles.AddRange(GetFilenameList.TVEpisode(tDBElement, Enums.ScrapeModifierType.EpisodePoster))
                                            lstFiles = lstFiles.Distinct().ToList()  'remove double entries
                                            lstFiles.Sort()
                                            For Each nFile In lstFiles
                                                Dim nFileinfo As New FileInfo(nFile)
                                                If nFileinfo.Exists Then lstItems.Add(nFileinfo)
                                            Next
                                        Next
                                End Select
                            End If
                        End With
                    End If
                Case Enums.ContentType.TVSeason
                    For Each nEpisode In tDBElement.Episodes
                        lstItems.AddRange(GetAllItemsOfDBElement(nEpisode))
                    Next
                    Dim lstFiles As New List(Of String)
                    If tDBElement.MainDetails.Season = 999 Then
                        lstFiles.AddRange(GetFilenameList.TVShow(tDBElement, Enums.ScrapeModifierType.AllSeasonsBanner))
                        lstFiles.AddRange(GetFilenameList.TVShow(tDBElement, Enums.ScrapeModifierType.AllSeasonsFanart))
                        lstFiles.AddRange(GetFilenameList.TVShow(tDBElement, Enums.ScrapeModifierType.AllSeasonsLandscape))
                        lstFiles.AddRange(GetFilenameList.TVShow(tDBElement, Enums.ScrapeModifierType.AllSeasonsPoster))
                        lstFiles = lstFiles.Distinct().ToList()  'remove double entries
                        lstFiles.Sort()
                    Else
                        lstFiles.AddRange(GetFilenameList.TVSeason(tDBElement, Enums.ScrapeModifierType.SeasonBanner))
                        lstFiles.AddRange(GetFilenameList.TVSeason(tDBElement, Enums.ScrapeModifierType.SeasonFanart))
                        lstFiles.AddRange(GetFilenameList.TVSeason(tDBElement, Enums.ScrapeModifierType.SeasonLandscape))
                        lstFiles.AddRange(GetFilenameList.TVSeason(tDBElement, Enums.ScrapeModifierType.SeasonNFO))
                        lstFiles.AddRange(GetFilenameList.TVSeason(tDBElement, Enums.ScrapeModifierType.SeasonPoster))
                        lstFiles = lstFiles.Distinct().ToList()  'remove double entries
                        lstFiles.Sort()
                    End If
                    For Each nFile In lstFiles
                        Dim nFileinfo As New FileInfo(nFile)
                        If nFileinfo.Exists Then lstItems.Add(nFileinfo)
                    Next

                Case Enums.ContentType.TVShow
                    lstItems.Add(New DirectoryInfo(tDBElement.ShowPath))
            End Select



            'Try
            '    Dim MovieFile As New FileInfo(mMovie.Filename)
            '    Dim MovieDir As DirectoryInfo = MovieFile.Directory
            '    'TODO: check VIDEO_TS parent
            '    If Common.isVideoTS(MovieDir.FullName) Then
            '        dPath = String.Concat(Path.Combine(MovieDir.Parent.FullName, MovieDir.Parent.Name), ".ext")
            '    ElseIf Common.isBDRip(MovieDir.FullName) Then
            '        dPath = String.Concat(Path.Combine(MovieDir.Parent.Parent.FullName, MovieDir.Parent.Parent.Name), ".ext")
            '    Else
            '        dPath = mMovie.Filename
            '    End If

            '    Dim sOrName As String = Path.GetFileNameWithoutExtension(Common.RemoveStackingMarkers(dPath))
            '    Dim sPathShort As String = Directory.GetParent(dPath).FullName
            '    Dim sPathNoExt As String = Common.RemoveExtFromPath(dPath)

            '    Dim dirInfo As New DirectoryInfo(sPathShort)
            '    Dim ioFi As New List(Of FileSystemInfo)

            '    Try
            '        ioFi.AddRange(dirInfo.GetFiles())
            '    Catch
            '    End Try

            '    If isCleaner AndAlso Master.eSettings.FileSystemExpertCleaner Then

            '        For Each sFile As FileInfo In ioFi
            '            If Not Master.eSettings.FileSystemCleanerWhitelistExts.Contains(sFile.Extension.ToLower) AndAlso ((Master.eSettings.FileSystemCleanerWhitelist AndAlso Not Master.eSettings.FileSystemValidExts.Contains(sFile.Extension.ToLower)) OrElse Not Master.eSettings.FileSystemCleanerWhitelist) Then
            '                sFile.Delete()
            '            End If
            '        Next

            '    Else

            '        If Not isCleaner Then
            '            'cleanup backdrops
            '            Dim fPath As String = mMovie.ImagesContainer.Fanart.LocalFilePath
            '            Dim tPath As String = String.Empty
            '            If Not String.IsNullOrEmpty(fPath) AndAlso File.Exists(fPath) Then
            '                If Common.isVideoTS(fPath) Then
            '                    tPath = Path.Combine(Master.eSettings.MovieBackdropsPath, String.Concat(Path.Combine(Common.GetMainPath(fPath).FullName, Common.GetMainPath(fPath).Name), "-fanart.jpg"))
            '                ElseIf Common.isBDRip(fPath) Then
            '                    tPath = Path.Combine(Master.eSettings.MovieBackdropsPath, String.Concat(Common.GetMainPath(fPath).Name, "-fanart.jpg"))
            '                Else
            '                    tPath = Path.Combine(Master.eSettings.MovieBackdropsPath, String.Concat(Common.GetMainPath(fPath).Name, "-fanart.jpg"))
            '                End If
            '            End If
            '            If Not String.IsNullOrEmpty(tPath) Then
            '                If IO.File.Exists(tPath) Then
            '                    ItemsToDelete.Add(New FileInfo(tPath))
            '                End If
            '            End If
            '        End If

            '        If Not isCleaner AndAlso mMovie.IsSingle AndAlso Not Master.SourcesList.Contains(MovieDir.Parent.ToString) Then
            '            If Common.isVideoTS(MovieDir.FullName) Then
            '                ItemsToDelete.Add(MovieDir.Parent)
            '            ElseIf Common.isBDRip(MovieDir.FullName) Then
            '                ItemsToDelete.Add(MovieDir.Parent.Parent)
            '            Else
            '                'check if there are other folders with movies in them
            '                If Not fScanner.SubDirsHaveMovies(MovieDir) Then
            '                    'no movies in sub dirs... delete the whole thing
            '                    ItemsToDelete.Add(MovieDir)
            '                Else
            '                    'just delete the movie file itself
            '                    ItemsToDelete.Add(New FileInfo(mMovie.Filename))
            '                End If
            '            End If
            '        Else
            '            For Each lFI As FileInfo In ioFi
            '                If isCleaner Then
            '                    If (Master.eSettings.CleanFolderJPG AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "folder.jpg")) _
            '                        OrElse (Master.eSettings.CleanFanartJPG AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "fanart.jpg")) _
            '                        OrElse (Master.eSettings.CleanMovieTBN AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "movie.tbn")) _
            '                        OrElse (Master.eSettings.CleanMovieNFO AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "movie.nfo")) _
            '                        OrElse (Master.eSettings.CleanPosterTBN AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "poster.tbn")) _
            '                        OrElse (Master.eSettings.CleanPosterJPG AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "poster.jpg")) _
            '                        OrElse (Master.eSettings.CleanMovieJPG AndAlso lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "movie.jpg")) Then
            '                        File.Delete(lFI.FullName)
            '                        Continue For
            '                    End If
            '                End If

            '                If (Master.eSettings.CleanMovieTBNB AndAlso isCleaner) OrElse (Not isCleaner) Then
            '                    If lFI.FullName.ToLower = String.Concat(sPathNoExt.ToLower, ".tbn") _
            '                    OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "video_ts.tbn") _
            '                    OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "index.tbn") _
            '                    OrElse lFI.FullName.ToLower = String.Concat(Path.Combine(sPathShort.ToLower, sOrName.ToLower), ".tbn") Then
            '                        If isCleaner Then
            '                            File.Delete(lFI.FullName)
            '                        Else
            '                            ItemsToDelete.Add(lFI)
            '                        End If
            '                        Continue For
            '                    End If
            '                End If

            '                If (Master.eSettings.CleanMovieFanartJPG AndAlso isCleaner) OrElse (Not isCleaner) Then
            '                    If lFI.FullName.ToLower = String.Concat(sPathNoExt.ToLower, "-fanart.jpg") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "video_ts-fanart.jpg") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "index-fanart.jpg") _
            '                        OrElse lFI.FullName.ToLower = String.Concat(Path.Combine(sPathShort.ToLower, sOrName.ToLower), "-fanart.jpg") Then
            '                        If isCleaner Then
            '                            File.Delete(lFI.FullName)
            '                        Else
            '                            ItemsToDelete.Add(lFI)
            '                        End If
            '                        Continue For
            '                    End If
            '                End If

            '                If (Master.eSettings.CleanMovieNFOB AndAlso isCleaner) OrElse (Not isCleaner) Then
            '                    If lFI.FullName.ToLower = String.Concat(sPathNoExt.ToLower, ".nfo") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "video_ts.nfo") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "index.nfo") _
            '                        OrElse lFI.FullName.ToLower = String.Concat(Path.Combine(sPathShort.ToLower, sOrName.ToLower), ".nfo") Then
            '                        If isCleaner Then
            '                            File.Delete(lFI.FullName)
            '                        Else
            '                            ItemsToDelete.Add(lFI)
            '                        End If
            '                        Continue For
            '                    End If
            '                End If

            '                If (Master.eSettings.CleanDotFanartJPG AndAlso isCleaner) OrElse (Not isCleaner) Then
            '                    If lFI.FullName.ToLower = String.Concat(sPathNoExt.ToLower, ".fanart.jpg") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "video_ts.fanart.jpg") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "index.fanart.jpg") _
            '                        OrElse lFI.FullName.ToLower = String.Concat(Path.Combine(sPathShort.ToLower, sOrName.ToLower), ".fanart.jpg") Then
            '                        If isCleaner Then
            '                            File.Delete(lFI.FullName)
            '                        Else
            '                            ItemsToDelete.Add(lFI)
            '                        End If
            '                        Continue For
            '                    End If
            '                End If

            '                If (Master.eSettings.CleanMovieNameJPG AndAlso isCleaner) OrElse (Not isCleaner) Then
            '                    If lFI.FullName.ToLower = String.Concat(sPathNoExt.ToLower, ".jpg") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "video_ts.jpg") _
            '                        OrElse lFI.FullName.ToLower = Path.Combine(sPathShort.ToLower, "index.jpg") _
            '                        OrElse lFI.FullName.ToLower = String.Concat(Path.Combine(sPathShort.ToLower, sOrName.ToLower), ".jpg") Then
            '                        If isCleaner Then
            '                            File.Delete(lFI.FullName)
            '                        Else
            '                            ItemsToDelete.Add(lFI)
            '                        End If
            '                        Continue For
            '                    End If
            '                End If
            '            Next

            '            If Not isCleaner Then

            '                ioFi.Clear()
            '                Try
            '                    If mMovie.IsSingle Then ioFi.AddRange(dirInfo.GetFiles(String.Concat(sOrName, "*.*")))
            '                Catch
            '                End Try

            '                Try
            '                    ioFi.AddRange(dirInfo.GetFiles(String.Concat(Path.GetFileNameWithoutExtension(mMovie.Filename), ".*")))
            '                Catch
            '                End Try

            '                ItemsToDelete.AddRange(ioFi)

            '            End If

            '            If Master.eSettings.CleanExtrathumbs Then
            '                If Directory.Exists(Path.Combine(sPathShort, "extrathumbs")) Then
            '                    If isCleaner Then
            '                        DeleteDirectory(Path.Combine(sPathShort, "extrathumbs"))
            '                    Else
            '                        Dim dir As New DirectoryInfo(Path.Combine(sPathShort, "extrathumbs"))
            '                        If dir.Exists Then
            '                            ItemsToDelete.Add(dir)
            '                        End If
            '                    End If
            '                End If
            '            End If

            '        End If
            '    End If

            '    ioFi = Nothing
            '    dirInfo = Nothing
            'Catch ex As Exception
            '    logger.Error(ex, New StackFrame().GetMethod().Name)
            'End Try
            Return lstItems
        End Function
        ''' <summary>
        ''' Determine the lowest-level directory from the supplied path string. 
        ''' </summary>
        ''' <param name="sPath">The path string to parse</param>
        ''' <returns>String containing a directory name, or String.Empty if no valid directory name was found</returns>
        ''' <remarks>Passing a path to a filename will treat that filename as a path. </remarks>
        Public Shared Function GetDirectory(ByVal sPath As String) As String
            'TODO Need to evaluate more actual EMM uses of this method. I'm not confident in my understanding of what it is actually trying to accomplish. It seems overly complex for such a simple role
            'Why not .split on DirectorySeparatorChar and use the last non-Empty string?
            Try
                If String.IsNullOrEmpty(sPath) Then Return String.Empty
                If sPath.EndsWith(Path.DirectorySeparatorChar) Then sPath = sPath.Substring(0, sPath.Length - 1)
                If Not String.IsNullOrEmpty(Path.GetDirectoryName(sPath)) AndAlso sPath.StartsWith(Path.GetDirectoryName(sPath)) Then sPath = sPath.Replace(Path.GetDirectoryName(sPath), String.Empty).Trim
                If sPath.StartsWith(Path.DirectorySeparatorChar) Then sPath = sPath.Substring(1)
                'it could be just a drive letter at this point. Check ending chars again
                If sPath.EndsWith(Path.DirectorySeparatorChar) Then sPath = sPath.Substring(0, sPath.Length - 1)
                If sPath.EndsWith(":") Then sPath = sPath.Substring(0, sPath.Length - 1)
                Return sPath
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function
        ''' <summary>
        ''' Given a path, determine whether it is a Blu-Ray or DVD folder. Find the respective media files within, and return the
        ''' largest one that is over 1 GB, or String.Empty otherwise.
        ''' </summary>
        ''' <param name="sPath">Path to Blu-Ray or DVD files.</param>
        ''' <param name="ForceBDMV">Assume path holds Blu-Ray files if <c>True</c></param>
        ''' <returns>Path/filename to the largest media file for the detected video type</returns>
        ''' <remarks>
        '''  2016/01/26  Cocotus - Remove 1GB limit from query
        ''' </remarks>
        Public Shared Function GetLongestFromRip(ByVal sPath As String, Optional ByVal ForceBDMV As Boolean = False) As String
            'TODO Needs error handling for when largest file is under 1GB. No default is set. Also, should error if path is not DVD or BR. Also, if ForceBDMV, complain if no files found
            Dim lFileList As New List(Of FileInfo)
            Select Case True
                Case isBDRip(sPath) OrElse ForceBDMV
                    lFileList.AddRange(New DirectoryInfo(Directory.GetParent(sPath).FullName).GetFiles("*.m2ts"))
                Case isVideoTS(sPath)
                    lFileList.AddRange(New DirectoryInfo(Directory.GetParent(sPath).FullName).GetFiles("*.vob"))
            End Select
            'Return filename/path of the largest file
            Return lFileList.OrderByDescending(Function(s) s.Length).Select(Function(s) s.FullName).FirstOrDefault
        End Function
        ''' <summary>
        ''' Returned the main folder that contains the file
        ''' </summary>
        ''' <param name="strFilenameFullPath">File name with full path</param>
        ''' <returns></returns>
        Public Shared Function GetMainPath(ByVal strFilenameFullPath As String) As DirectoryInfo
            If isBDRip(strFilenameFullPath) Then
                Return Directory.GetParent(Directory.GetParent(Directory.GetParent(strFilenameFullPath).FullName).FullName)
            ElseIf isVideoTS(strFilenameFullPath) Then
                Return Directory.GetParent(Directory.GetParent(strFilenameFullPath).FullName)
            Else
                Return Directory.GetParent(strFilenameFullPath)
            End If
        End Function

        Public Shared Function GetOpenFileDialogFilter_Theme() As String
            Dim lstValidExtensions As New List(Of String)

            For Each nExtension In Master.eSettings.FileSystemValidThemeExts
                lstValidExtensions.Add(String.Concat("*", nExtension))
            Next

            Return String.Concat(Master.eLang.GetString(1285, "Themes"), "|", String.Join(";", lstValidExtensions.ToArray))
        End Function

        Public Shared Function GetOpenFileDialogFilter_Video(ByVal strDescription As String) As String
            Dim lstValidExtensions As New List(Of String)

            For Each nExtension In Master.eSettings.FileSystemValidExts
                lstValidExtensions.Add(String.Concat("*", nExtension))
            Next

            Return String.Concat(strDescription, "|", String.Join(";", lstValidExtensions.ToArray))
        End Function

        Public Shared Function GetTotalLengt(ByRef tFileItem As FileItem) As Long
            If tFileItem IsNot Nothing AndAlso Not tFileItem.bIsDirectory AndAlso tFileItem.bIsOnline Then
                Try
                    Dim lngTotalLength As Long = 0
                    If tFileItem.bIsBDMV OrElse tFileItem.bIsVideoTS Then 'TODO: cleanup result from trailers and other files
                        For Each nFile In Directory.GetFiles(tFileItem.MainPath.FullName, "*.*", SearchOption.AllDirectories)
                            lngTotalLength += New FileInfo(nFile).Length
                        Next
                        Return lngTotalLength
                    Else
                        For Each nFile In tFileItem.PathList
                            lngTotalLength += New FileInfo(nFile).Length
                        Next
                        Return lngTotalLength
                    End If
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
            End If
            Return -1
        End Function

        ''' <summary>
        ''' Determine whether the path provided contains a Blu-Ray image
        ''' </summary>
        ''' <param name="strPath">Path to be evaluated</param>
        ''' <returns><c>True</c> if the supplied path is determined to be a Blu-Ray path. <c>False</c> otherwise</returns>
        ''' <remarks>Two tests are performed. If the supplied path has an extension (such as if a .m2ts file was provided), check 
        ''' that the parent directory is "stream" and its parent is "bdmv"</remarks>
        Public Shared Function isBDRip(ByVal strPath As String) As Boolean
            'TODO Kludge. Consider FileSystemInfo.Attributes to detect if path is a file or directory, and proceed from there
            If String.IsNullOrEmpty(strPath) Then Return False
            If strPath.EndsWith(Path.DirectorySeparatorChar) OrElse strPath.EndsWith(Path.AltDirectorySeparatorChar) Then
                'The current/parent directory comparisons can't handle paths ending with a directory separator. Therefore, strip them out
                Return isBDRip(strPath.Substring(0, strPath.Length - 1))
            End If
            If Path.HasExtension(strPath) Then
                Return Directory.GetParent(strPath).Name.ToLower = "stream" AndAlso Directory.GetParent(Directory.GetParent(strPath).FullName).Name.ToLower = "bdmv"
            Else
                Return GetDirectory(strPath).ToLower = "stream" AndAlso Directory.GetParent(strPath).Name.ToLower = "bdmv"
            End If
        End Function
        ''' <summary>
        ''' Determine whether the given string represents a file that needs to be treated as if it is stacked (single media in multiple files)
        ''' If the system setting "DisableMultiPartMedia" is False, then always return False
        ''' </summary>
        ''' <param name="strPath"><c>String</c> to evaluate</param>
        ''' <returns><c>True</c> if the string represents a stacked file, or <c>False</c> otherwise</returns>
        ''' <remarks></remarks>
        Public Shared Function isStacked(ByVal strPath As String) As Boolean
            If Not strPath = RemoveStackingMarkers(strPath) Then
                Return True
            Else
                Return False
            End If
        End Function
        ''' <summary>
        ''' Check if we should scan the directory.
        ''' </summary>
        ''' <param name="dInfo">DirectoryInfo to check</param>
        ''' <returns>True if directory is valid, false if not.</returns>
        Public Shared Function IsValidDir(ByVal dInfo As DirectoryInfo, ByVal tContentType As Enums.ContentType) As Boolean
            Try
                For Each s As String In Master.ExcludedDirs
                    If dInfo.FullName.ToLower = s.ToLower Then
                        logger.Info(String.Format("[FileUtils] [IsValidDir] [ExcludeDirs] Path ""{0}"" has been skipped (path is in ""exclude directory"" list)", dInfo.FullName, s))
                        Return False
                    End If
                Next
                If (tContentType = Enums.ContentType.Movie AndAlso dInfo.Name.ToLower = "extras") OrElse
                    If(dInfo.FullName.IndexOf("\") >= 0, dInfo.FullName.Remove(0, dInfo.FullName.IndexOf("\")).Contains(":"), False) Then
                    Return False
                End If
                For Each s As String In clsXMLAdvancedSettings.GetSetting("NotValidDirIs", ".actors|extrafanart|extrathumbs|audio_ts|recycler|subs|subtitles|.trashes").Split(New String() {"|"}, StringSplitOptions.RemoveEmptyEntries)
                    If dInfo.Name.ToLower = s Then
                        logger.Info(String.Format("[FileUtils] [IsValidDir] [NotValidDirIs] Path ""{0}"" has been skipped (path name is ""{1}"")", dInfo.FullName, s))
                        Return False
                    End If
                Next
                For Each s As String In clsXMLAdvancedSettings.GetSetting("NotValidDirContains", "-trailer|[trailer|temporary files|(noscan)|$recycle.bin|lost+found|system volume information|sample").Split(New String() {"|"}, StringSplitOptions.RemoveEmptyEntries)
                    If dInfo.Name.ToLower.Contains(s) Then
                        logger.Info(String.Format("[FileUtils] [IsValidDir] [NotValidDirContains] Path ""{0}"" has been skipped (path contains ""{1}"")", dInfo.FullName, s))
                        Return False
                    End If
                Next

            Catch ex As Exception
                logger.Error(String.Format("[FileUtils] [IsValidDir] Path ""{0}"" has been skipped ({1})", dInfo.Name, ex.Message))
                Return False
            End Try
            Return True
        End Function
        ''' <summary>
        ''' Deermine whether the path provided contains a DVD image
        ''' </summary>
        ''' <param name="strPath">Path to be evaluated</param>
        ''' <returns><c>True</c> if the supplied path is determined to be a Blu-Ray path. <c>False</c> otherwise</returns>
        ''' <remarks>If the path is a file, check if parent is video_ts. Otherwise, it should be a directory, so see if it is video_ts</remarks>
        Public Shared Function isVideoTS(ByVal strPath As String) As Boolean
            'TODO Kludge. Consider FileSystemInfo.Attributes to detect if path is a file or directory, and proceed from there
            If String.IsNullOrEmpty(strPath) Then Return False
            If Path.HasExtension(strPath) Then
                Return Directory.GetParent(strPath).Name.ToLower = "video_ts"
            Else
                Return GetDirectory(strPath).ToLower = "video_ts"
            End If
        End Function
        ''' <summary>
        ''' Get the entire path and filename of a file, but without the extension
        ''' </summary>
        ''' <param name="strPath">Full path to file.</param>
        ''' <returns>Path and filename of a file, without the extension</returns>
        ''' <remarks>No validation is made on whether the path/file actually exists.</remarks>
        Public Shared Function RemoveExtFromPath(ByVal strPath As String) As String
            'TODO Dekker500 This method needs serious work. Invalid paths are not consistently handled. Need analysis on how to handle these properly
            If String.IsNullOrEmpty(strPath) Then Return String.Empty
            Try
                'If the path has no directories (only the root), short-circuit the routine and just return
                If strPath.Equals(Directory.GetDirectoryRoot(strPath)) Then Return strPath
                Return Path.Combine(Path.GetDirectoryName(strPath), Path.GetFileNameWithoutExtension(strPath))
                'Return Path.Combine(Directory.GetParent(sPath).FullName, Path.GetFileNameWithoutExtension(sPath))
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name & Convert.ToChar(Windows.Forms.Keys.Tab) & "Source: <" & strPath & ">")
                Return String.Empty
            End Try
        End Function
        ''' <summary>
        ''' Takes the supplied filename and replaces any invalid characters with suitable substitutions.
        ''' </summary>
        ''' <param name="filename">String intended to represent a filename, without any path.</param>
        ''' <returns>A String that has had any invalid characters substituted with acceptable alternatives.</returns>
        ''' <remarks>No validation is done as to whether the filename actually exists</remarks>
        Public Shared Function MakeValidFilename(ByVal filename As String) As String
            'TODO Should look into Path.GetInvalidFileNameChars and Path.GetInvalidPathChars
            filename = filename.Replace(":", " -")
            filename = filename.Replace("/", String.Empty)
            'pattern = pattern.Replace("\", String.Empty)
            filename = filename.Replace("|", String.Empty)
            filename = filename.Replace("<", String.Empty)
            filename = filename.Replace(">", String.Empty)
            filename = filename.Replace("?", String.Empty)
            filename = filename.Replace("*", String.Empty)
            filename = filename.Replace("  ", " ")
            Return filename
        End Function

        Public Shared Function ReturnSettingsFile(Dir As String, Name As String) As String
            'Cocotus, Load from central Dir folder if it exists!
            Dim configpath As String = String.Concat(Functions.AppPath, Dir, Path.DirectorySeparatorChar, Name)

            'AdvancedSettings.xml is still at old place (root) -> move to new place if there's no AdvancedSettings.xml !
            If Not File.Exists(configpath) AndAlso File.Exists(Path.Combine(Functions.AppPath, Name)) AndAlso Directory.Exists(String.Concat(Functions.AppPath, Dir, Path.DirectorySeparatorChar)) Then
                File.Move(Path.Combine(Functions.AppPath, Name), String.Concat(Functions.AppPath, Dir, Path.DirectorySeparatorChar, Name))
                'New Settings folder doesn't exist -> do it the old way...
            ElseIf Not Directory.Exists(String.Concat(Functions.AppPath, Dir, Path.DirectorySeparatorChar)) Then
                configpath = Path.Combine(Functions.AppPath, Name)
            End If

            Return configpath
        End Function

        Public Shared Sub InstallNewFiles(ByVal fname As String)
            Dim _cmds As Containers.InstallCommands = Containers.InstallCommands.Load(fname)
            For Each _cmd As Containers.CommandsNoTransactionCommand In _cmds.noTransaction
                Try
                    Select Case _cmd.type
                        Case "FILE.Move"
                            Dim s() As String = _cmd.execute.Split("|"c)
                            If s.Count >= 2 Then
                                If File.Exists(s(1)) Then File.Delete(s(1))
                                If Not Directory.Exists(Path.GetDirectoryName(s(1))) Then
                                    Directory.CreateDirectory(Path.GetDirectoryName(s(1)))
                                End If
                                File.Move(s(0), s(1))
                            End If
                        Case "FILE.Delete"
                            If File.Exists(_cmd.execute) Then File.Delete(_cmd.execute)
                    End Select
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
            Next
            Dim destPath As String = Path.Combine(Functions.AppPath, "InstalledTasks_" & Format(Date.Now, "YYYYMMDD") & Format(Date.Now, "HHMMSS") & ".xml")
            Try
                File.Move(fname, destPath)
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End Sub

        Public Shared Function CheckOnlineStatus(ByRef tDBElement As Database.DBElement, ByVal showMessage As Boolean) As Boolean
            Select Case tDBElement.ContentType
                Case Enums.ContentType.Movie, Enums.ContentType.TVEpisode
                    While Not File.Exists(tDBElement.FileItem.FirstStackedPath)
                        If showMessage Then
                            If MessageBox.Show(String.Concat(Master.eLang.GetString(587, "This file is no longer available"), ".",
                                                             Environment.NewLine,
                                                             Master.eLang.GetString(630, "Reconnect the source and press Retry"), ".",
                                                             Environment.NewLine,
                                                             Environment.NewLine,
                                                             tDBElement.FileItem.FirstStackedPath),
                                               String.Empty,
                                               MessageBoxButtons.RetryCancel,
                                               MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Return False
                        Else
                            Return False
                        End If
                    End While
                    tDBElement.IsOnline = True
                    Return True

                Case Enums.ContentType.TVShow, Enums.ContentType.TVSeason
                    While Not Directory.Exists(tDBElement.ShowPath)
                        If showMessage Then
                            If MessageBox.Show(String.Concat(Master.eLang.GetString(719, "This path is no longer available"), ".",
                                                             Environment.NewLine,
                                                             Master.eLang.GetString(630, "Reconnect the source and press Retry"), ".",
                                                             Environment.NewLine,
                                                             Environment.NewLine,
                                                             tDBElement.ShowPath),
                                               String.Empty,
                                               MessageBoxButtons.RetryCancel,
                                               MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Return False
                        Else
                            Return False
                        End If
                    End While
                    tDBElement.IsOnline = True
                    Return True
                Case Else
                    Return False
            End Select
        End Function

        ''' <summary>
        ''' Gets total size in bytes for given subtree specified by directory path
        ''' </summary>
        ''' <param name="spathDirectory">Path represented the location of the directory</param>
        ''' <returns>Total size in bytes for the given folder</returns>
        ''' <remarks></remarks>
        Public Shared Function GetFolderSize(ByVal spathDirectory As String) As Long
            Dim size As Long = 0
            If System.IO.Directory.Exists(spathDirectory) Then
                ' Take a snapshot of the file system.
                Dim dir As New DirectoryInfo(spathDirectory)
                ' This method assumes that the application has discovery permissions
                ' for all folders under the specified path.
                Dim fileList As IEnumerable(Of FileInfo) = dir.GetFiles("*.*", SearchOption.AllDirectories)

                For Each fi As FileInfo In fileList
                    size += GetFileLength(fi)
                Next
            Else
                logger.Debug("Can't calculate foldersize! Not a valid directory: ", spathDirectory)
            End If
            'Return the size of the smallest file
            Return size
        End Function

        ''' <summary>
        ''' Get filename of largest file for given subtree specified by directory path
        ''' </summary>
        ''' <param name="spathDirectory">Path represented the location of the directory</param>
        ''' <returns>Filename of largest file for the given folder</returns>
        ''' <remarks></remarks>
        Public Shared Function GetLargestFilePathFromDir(spathDirectory As String) As String
            ' Take a snapshot of the file system.
            Dim dir As New DirectoryInfo(spathDirectory)
            ' This method assumes that the application has discovery permissions
            ' for all folders under the specified path.
            Dim fileList As IEnumerable(Of FileInfo) = dir.GetFiles("*.*", SearchOption.AllDirectories)
            'Return the size of the largest file
            Dim maxSize As Long = (From file In fileList Let len = GetFileLength(file) Select len).Max()
            logger.Debug("The length of the largest file under {0} is {1}", spathDirectory, maxSize)
            ' Return the FileInfo object for the largest file
            ' by sorting and selecting from beginning of list
            Dim longestFile As FileInfo = (From file In fileList Let len = GetFileLength(file) Where len > 0 Order By len Descending Select file).First()
            logger.Debug("The largest file under {0} is {1} with a length of {2} bytes", spathDirectory, longestFile.FullName, longestFile.Length)
            Return longestFile.FullName
        End Function

        ''' <summary>
        ''' Get filename of smallest file for given subtree specified by directory path
        ''' </summary>
        ''' <param name="spathDirectory">Path represented the location of the directory</param>
        ''' <returns>Filename of smallest file for the given folder</returns>
        ''' <remarks></remarks>
        Public Shared Function GetSmallestFilePathFromDir(spathDirectory As String) As String
            ' Take a snapshot of the file system.
            Dim dir As New DirectoryInfo(spathDirectory)
            ' This method assumes that the application has discovery permissions
            ' for all folders under the specified path.
            Dim fileList As IEnumerable(Of FileInfo) = dir.GetFiles("*.*", SearchOption.AllDirectories)
            'Return the FileInfo of the smallest file
            Dim smallestFile As FileInfo = (From file In fileList Let len = GetFileLength(file) Where len > 0 Order By len Ascending Select file).First()
            logger.Debug("The smallest file under {0} is {1} with a length of {2} bytes", spathDirectory, smallestFile.FullName, smallestFile.Length)
            Return smallestFile.FullName
        End Function

        ''' <summary>
        ''' Helper: Get filesize of specific file, handling exception
        ''' </summary>
        ''' <param name="fi">FileInfo of specific file</param>
        ''' <returns>FileSize of the given file</returns>
        ''' <remarks>
        ''' ' This method is used to swallow the possible exception
        ''' ' that can be raised when accessing the FileInfo.Length property.
        ''' ' In this particular case, it is safe to swallow the exception.
        ''' </remarks>
        Private Shared Function GetFileLength(ByVal fi As FileInfo) As Long
            Dim retval As Long
            Try
                retval = fi.Length
            Catch ex As FileNotFoundException
                ' If a file is no longer present,
                ' just add zero bytes to the total.
                logger.Error(String.Concat("Specific file is no longer present!", ex))
                retval = 0
            End Try
            Return retval
        End Function
        ''' <summary>
        ''' When given a valid path to a video/media file, return the path but without stacking markers.
        ''' </summary>
        ''' <param name="strPath"><c>String</c> full file path (including file extension) to clean</param>
        ''' <returns>The <c>String</c> path with the stacking markers removed</returns>
        ''' <remarks>The following are default stacking extensions that can be added to file names These are for video file names that are in the same folder:
        ''' # can be 1 through 9. No spaces between the extension and number. 
        ''' <list>
        '''   <item>part#​</item>
        '''   <item>cd#​</item>
        '''   <item>dvd#</item>
        '''   <item>pt#</item>
        '''   <item>disk#</item>
        '''   <item>disc#</item>
        ''' </list>
        ''' Note that text after the stacking marker are left untouched.
        ''' </remarks>
        Public Shared Function RemoveStackingMarkers(ByVal strPath As String) As String
            'Don't do anything if DisableMultiPartMedia is True or strPath is String.Empty
            If clsXMLAdvancedSettings.GetBooleanSetting("DisableMultiPartMedia", False) OrElse String.IsNullOrEmpty(strPath) Then Return strPath

            Dim FilePattern As String = clsXMLAdvancedSettings.GetSetting("FileStacking", "(.*?)([ _.-]*(?:cd|dvd|p(?:ar)?t|dis[ck])[ _.-]*[0-9]+)(.*?)(\.[^.]+)$")
            Dim FolderPattern As String = clsXMLAdvancedSettings.GetSetting("FolderStacking", "((cd|dvd|dis[ck])[0-9]+)$")

            Dim FileStacking = Regex.Match(strPath, FilePattern, RegexOptions.IgnoreCase)
            If FileStacking.Success Then
                Dim strPathCleaned As String = strPath.Replace(FileStacking.Groups(2).Value, String.Empty)
                Return strPathCleaned
            Else
                Return strPath
            End If
        End Function

#End Region 'Methods

    End Class

    Public Class Delete

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Methods"

        Public Shared Sub Cache_All()
            If MessageBox.Show(Master.eLang.GetString(104, "Are you sure?"), Master.eLang.GetString(565, "Clear Cache"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Directory.Exists(Master.TempPath) Then
                    Try
                        Dim dInfo As New DirectoryInfo(Master.TempPath)
                        Dim dList As IEnumerable(Of DirectoryInfo)
                        Dim fList As New List(Of FileInfo)
                        dList = dInfo.GetDirectories
                        fList.AddRange(dInfo.GetFiles())
                        For Each inDir As DirectoryInfo In dList
                            Directory.Delete(inDir.FullName, True)
                        Next
                        For Each fFile As FileInfo In fList
                            File.Delete(fFile.FullName)
                        Next
                    Catch ex As Exception
                        logger.Error(ex, New StackFrame().GetMethod().Name)
                    End Try
                End If
            End If
        End Sub

        Public Shared Sub Cache_Show(ByVal TVDBIDs As List(Of String), ByVal cData As Boolean, ByVal cImages As Boolean)
            If TVDBIDs IsNot Nothing AndAlso TVDBIDs.Count > 0 Then
                If MessageBox.Show(Master.eLang.GetString(104, "Are you sure?"), Master.eLang.GetString(565, "Clear Cache"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For Each id As String In TVDBIDs
                        Try
                            Dim basePath As String = Path.Combine(Master.TempPath, String.Concat("Shows", Path.DirectorySeparatorChar, id))
                            If Directory.Exists(basePath) Then
                                If cData AndAlso cImages Then
                                    Directory.Delete(basePath, True)
                                ElseIf cData Then
                                    Dim dInfo As New DirectoryInfo(basePath)
                                    Dim fList As New List(Of FileInfo)
                                    fList.AddRange(dInfo.GetFiles("*.zip"))
                                    For Each fFile As FileInfo In fList
                                        File.Delete(fFile.FullName)
                                    Next
                                ElseIf cImages Then
                                    Dim dInfo As New DirectoryInfo(basePath)
                                    Dim dList As IEnumerable(Of DirectoryInfo)
                                    dList = dInfo.GetDirectories
                                    For Each inDir As DirectoryInfo In dList
                                        Directory.Delete(inDir.FullName, True)
                                    Next
                                End If
                            End If
                        Catch ex As Exception
                            logger.Error(ex, New StackFrame().GetMethod().Name)
                        End Try
                    Next
                End If
            End If
        End Sub
        ''' <summary>
        ''' Safer method of deleting a diretory and all it's contents
        ''' </summary>
        ''' <param name="sPath">Full path of directory to delete</param>
        ''' <remarks>This method deletes the supplied path by recursively deleting its child directories, 
        ''' then deleting its file contents before deleting itself.</remarks>
        Public Shared Sub DeleteDirectory(ByVal sPath As String)
            'TODO The calls to Directory.Exists may return a false negative if the user does not have read access. If this happens
            'TODO during a recursive call, orphan folders may be left behind, causing the final Delete to fail. Should give better
            'TODO error messages so the log can be easier to interpret.
            Try
                If String.IsNullOrEmpty(sPath) Then Return

                If Directory.Exists(sPath) Then

                    Dim Dirs As New List(Of String)

                    Try
                        Dirs.AddRange(Directory.GetDirectories(sPath))
                    Catch
                    End Try

                    For Each inDir As String In Dirs
                        DeleteDirectory(inDir)
                    Next

                    Dim fFiles As New List(Of String)

                    Try
                        fFiles.AddRange(Directory.GetFiles(sPath))
                    Catch
                    End Try

                    For Each fFile As String In fFiles
                        Try
                            File.Delete(fFile)
                        Catch
                        End Try
                    Next

                    Directory.Delete(sPath, True)
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End Sub

#End Region 'Methods

    End Class

    Public Class DragAndDrop

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Methods"

        Public Shared Function CheckDroppedImage(ByVal e As DragEventArgs) As Boolean
            Dim strFile() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If strFile IsNot Nothing Then
                Dim fi As New FileInfo(strFile(0))
                If fi.Extension = ".gif" Or fi.Extension = ".bmp" Or fi.Extension = ".jpg" Or fi.Extension = ".jpeg" Or fi.Extension = ".png" Then
                    Return True
                End If
            End If

            Return False
        End Function

        Public Shared Function GetDoppedImage(ByVal e As DragEventArgs) As MediaContainers.Image
            Dim tImage As New MediaContainers.Image
            If e.Data.GetDataPresent("HTML FORMAT") Then
                Dim clipboardHtml As String = CStr(e.Data.GetData("HTML Format"))
                Dim htmlFragment As String = getHtmlFragment(clipboardHtml)
                Dim imageSrc As String = parseImageSrc(htmlFragment)
                Dim baseURL As String = parseBaseURL(clipboardHtml)

                If (imageSrc.ToLower().IndexOf("http://") = 0) Or (imageSrc.ToLower().IndexOf("https://") = 0) Then
                    tImage.ImageOriginal.LoadFromWeb(imageSrc, True)
                    If tImage.ImageOriginal.Image IsNot Nothing Then
                        Return tImage
                    End If
                Else
                    tImage.ImageOriginal.LoadFromWeb(baseURL + imageSrc.Substring(1), True)
                    If tImage.ImageOriginal.Image IsNot Nothing Then
                        Return tImage
                    End If
                End If
            ElseIf e.Data.GetDataPresent(DataFormats.FileDrop, False) Then
                Dim localImage() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
                tImage.ImageOriginal.LoadFromFile(localImage(0).ToString, True)
                If tImage.ImageOriginal.Image IsNot Nothing Then
                    Return tImage
                End If
            End If

            Return tImage
        End Function
        Public Shared Function getHtmlFragment(ByVal html As String) As String
            Dim fragStartPos As Integer
            Dim fragEndPos As Integer

            fragStartPos = Integer.Parse(Regex.Match(html, "^StartFragment:(\d+)", RegexOptions.Multiline).Groups(1).Value)
            fragEndPos = Integer.Parse(Regex.Match(html, "^EndFragment:(\d+)", RegexOptions.Multiline).Groups(1).Value)

            Return html.Substring(fragStartPos, fragEndPos - fragStartPos)
        End Function

        Public Shared Function parseBaseURL(ByVal html As String) As String
            Return Regex.Match(html, "http(s)?://.*?/", RegexOptions.IgnoreCase).Groups(0).Value
        End Function

        Public Shared Function parseImageSrc(ByVal html As String) As String
            Return Regex.Match(html, "<img.*?src=[""""'](.*?)[""""'].*>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Groups(1).Value
        End Function

#End Region 'Methods

    End Class

    Public Class GetFilenameList

#Region "Fields"

        Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Methods"
        ''' <summary>
        ''' Creates a list of filenames to save or read movie content
        ''' </summary>
        ''' <param name="mType"></param>
        ''' <param name="bForced">Enable ALL known file naming schemas. Should only be used to search files and not to save files!</param>
        ''' <returns><c>List(Of String)</c> all filenames with full path</returns>
        ''' <remarks></remarks>
        Public Shared Function Movie(ByVal tDBElement As Database.DBElement, ByVal mType As Enums.ScrapeModifierType, Optional ByVal bForced As Boolean = False) As List(Of String)
            Dim FilenameList As New List(Of String)

            If String.IsNullOrEmpty(tDBElement.FileItem.FullPath) Then Return FilenameList

            Dim strMainPath As String = tDBElement.FileItem.MainPath.FullName
            Dim strPath As String = tDBElement.FileItem.FirstStackedPath
            Dim strFileName As String = Path.GetFileNameWithoutExtension(strPath) 'TODO: looks wrong
            Dim strStackedFilename As String = Path.GetFileNameWithoutExtension(tDBElement.FileItem.StackedFilename)
            Dim strFilePath As String = Path.Combine(Directory.GetParent(strPath).FullName, strFileName)
            Dim strStackedFilePath As String = Path.Combine(Directory.GetParent(strPath).FullName, strStackedFilename)
            Dim strFileParentPath As String = Directory.GetParent(tDBElement.FileItem.FirstStackedPath).FullName

            Dim bIsSingle As Boolean = tDBElement.IsSingle
            Dim bIsBDMV As Boolean = tDBElement.FileItem.bIsBDMV
            Dim bIsVideoTS As Boolean = tDBElement.FileItem.bIsVideoTS
            Dim bIsVideoTSFile As Boolean = strFileName.ToLower = "video_ts"

            Select Case mType
                Case Enums.ScrapeModifierType.MainActorThumbs
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieActorThumbsFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieActorThumbsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.tbn"))
                            If .MovieUseExpert AndAlso .MovieActorThumbsExpertVTS AndAlso Not String.IsNullOrEmpty(.MovieActorThumbsExtExpertVTS) Then
                                If .MovieUseBaseDirectoryExpertVTS Then
                                    FilenameList.Add(Path.Combine(strMainPath, ".actors", "!placeholder!", .MovieActorThumbsExtExpertVTS))
                                Else
                                    FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!", .MovieActorThumbsExtExpertVTS))
                                End If
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieActorThumbsFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieActorThumbsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.tbn"))
                            If .MovieUseExpert AndAlso .MovieActorThumbsExpertBDMV AndAlso Not String.IsNullOrEmpty(.MovieActorThumbsExtExpertBDMV) Then
                                If .MovieUseBaseDirectoryExpertBDMV Then
                                    FilenameList.Add(Path.Combine(strMainPath, ".actors", String.Concat("!placeholder!", .MovieActorThumbsExtExpertBDMV)))
                                Else
                                    FilenameList.Add(Path.Combine(strFileParentPath, ".actors", String.Concat("!placeholder!", .MovieActorThumbsExtExpertBDMV)))
                                End If
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieActorThumbsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieActorThumbsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.tbn"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS AndAlso .MovieActorThumbsExpertVTS AndAlso Not String.IsNullOrEmpty(.MovieActorThumbsExtExpertVTS) Then
                                FilenameList.Add(Path.Combine(strFileParentPath, ".actors", String.Concat("!placeholder!", .MovieActorThumbsExtExpertVTS)))
                            ElseIf .MovieUseExpert AndAlso .MovieActorThumbsExpertSingle AndAlso Not String.IsNullOrEmpty(.MovieActorThumbsExtExpertSingle) Then
                                FilenameList.Add(Path.Combine(strFileParentPath, ".actors", String.Concat("!placeholder!", .MovieActorThumbsExtExpertSingle)))
                            End If
                        Else
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieActorThumbsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                            If .MovieUseExpert AndAlso .MovieActorThumbsExpertMulti AndAlso Not String.IsNullOrEmpty(.MovieActorThumbsExtExpertMulti) Then
                                FilenameList.Add(Path.Combine(strFileParentPath, ".actors", String.Concat("!placeholder!", .MovieActorThumbsExtExpertMulti)))
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainBanner
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieBannerAD) Then FilenameList.Add(Path.Combine(strMainPath, "banner.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieBannerExtended) Then FilenameList.Add(Path.Combine(strMainPath, "banner.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieBannerNMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Directory.GetParent(strFileParentPath).Name), ".banner.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieBannerYAMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(strFileParentPath).FullName, Directory.GetParent(strFileParentPath).Name), ".banner.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieBannerExpertVTS) Then
                                For Each a In .MovieBannerExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieBannerAD) Then FilenameList.Add(Path.Combine(strMainPath, "banner.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieBannerExtended) Then FilenameList.Add(Path.Combine(strMainPath, "banner.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieBannerNMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName).FullName, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".banner.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieBannerYAMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".banner.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieBannerExpertBDMV) Then
                                For Each a In .MovieBannerExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieBannerAD) Then FilenameList.Add(Path.Combine(strFileParentPath, "banner.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso bIsVideoTSFile AndAlso .MovieBannerExtended) Then FilenameList.Add(Path.Combine(strFileParentPath, "banner.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso Not bIsVideoTSFile AndAlso .MovieBannerExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-banner.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieBannerNMJ) Then FilenameList.Add(String.Concat(strStackedFilePath, ".banner.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieBannerYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".banner.jpg"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieBannerExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieBannerExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieBannerExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieBannerExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieBannerExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-banner.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieBannerNMJ) Then FilenameList.Add(String.Concat(strStackedFilePath, ".banner.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieBannerYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".banner.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieBannerExpertMulti) Then
                                For Each a In .MovieBannerExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainClearArt
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieClearArtAD) Then FilenameList.Add(Path.Combine(strMainPath, "clearart.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieClearArtExtended) Then FilenameList.Add(Path.Combine(strMainPath, "clearart.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearArtExpertVTS) Then
                                For Each a In .MovieClearArtExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieClearArtAD) Then FilenameList.Add(Path.Combine(strMainPath, "clearart.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieClearArtExtended) Then FilenameList.Add(Path.Combine(strMainPath, "clearart.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearArtExpertBDMV) Then
                                For Each a In .MovieClearArtExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieClearArtAD) Then FilenameList.Add(Path.Combine(strFileParentPath, "clearart.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso bIsVideoTSFile AndAlso .MovieClearArtExtended) Then FilenameList.Add(Path.Combine(strFileParentPath, "clearart.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso Not bIsVideoTSFile AndAlso .MovieClearArtExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-clearart.png"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieClearArtExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearArtExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieClearArtExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieClearArtExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieClearArtExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-clearart.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearArtExpertMulti) Then
                                For Each a In .MovieClearArtExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainClearLogo
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieClearLogoAD) Then FilenameList.Add(Path.Combine(strMainPath, "logo.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieClearLogoExtended) Then FilenameList.Add(Path.Combine(strMainPath, "clearlogo.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearLogoExpertVTS) Then
                                For Each a In .MovieClearLogoExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieClearLogoAD) Then FilenameList.Add(Path.Combine(strMainPath, "logo.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieClearLogoExtended) Then FilenameList.Add(Path.Combine(strMainPath, "clearlogo.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearLogoExpertBDMV) Then
                                For Each a In .MovieClearLogoExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieClearLogoAD) Then FilenameList.Add(Path.Combine(strFileParentPath, "logo.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso bIsVideoTSFile AndAlso .MovieClearLogoExtended) Then FilenameList.Add(Path.Combine(strFileParentPath, "clearlogo.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso Not bIsVideoTSFile AndAlso .MovieClearLogoExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-clearlogo.png"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieClearLogoExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearLogoExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieClearLogoExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieClearLogoExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieClearLogoExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-clearlogo.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieClearLogoExpertMulti) Then
                                For Each a In .MovieClearLogoExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainDiscArt
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieDiscArtAD) Then FilenameList.Add(Path.Combine(strMainPath, "disc.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieDiscArtExtended) Then FilenameList.Add(Path.Combine(strMainPath, "discart.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieDiscArtExpertVTS) Then
                                For Each a In .MovieDiscArtExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieDiscArtAD) Then FilenameList.Add(Path.Combine(strMainPath, "disc.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieDiscArtExtended) Then FilenameList.Add(Path.Combine(strMainPath, "discart.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieDiscArtExpertBDMV) Then
                                For Each a In .MovieDiscArtExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieDiscArtAD) Then FilenameList.Add(Path.Combine(strFileParentPath, "disc.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso bIsVideoTSFile AndAlso .MovieDiscArtExtended) Then FilenameList.Add(Path.Combine(strFileParentPath, "discart.png"))
                            If bForced OrElse (.MovieUseExtended AndAlso Not bIsVideoTSFile AndAlso .MovieDiscArtExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-discart.png"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieDiscArtExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieDiscArtExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieDiscArtExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieDiscArtExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieDiscArtExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-discart.png"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieDiscArtExpertMulti) Then
                                For Each a In .MovieDiscArtExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainExtrafanarts
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieExtrafanartsFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieExtrafanartsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            If .MovieUseExpert AndAlso .MovieExtrafanartsExpertVTS Then
                                If .MovieUseBaseDirectoryExpertVTS Then
                                    FilenameList.Add(Path.Combine(strMainPath, "extrafanart"))
                                Else
                                    FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                                End If
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieExtrafanartsFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieExtrafanartsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            If .MovieUseExpert AndAlso .MovieExtrafanartsExpertBDMV Then
                                If .MovieUseBaseDirectoryExpertBDMV Then
                                    FilenameList.Add(Path.Combine(strMainPath, "extrafanart"))
                                Else
                                    FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                                End If
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieExtrafanartsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieExtrafanartsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS AndAlso .MovieExtrafanartsExpertVTS Then
                                FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            ElseIf .MovieUseExpert AndAlso .MovieExtrafanartsExpertSingle Then
                                FilenameList.Add(Path.Combine(strFileParentPath, "extrafanart"))
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainExtrathumbs
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieExtrathumbsFrodo) AndAlso Not .MovieXBMCProtectVTSBDMV Then FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieExtrathumbsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            If .MovieUseExpert AndAlso .MovieExtrathumbsExpertVTS Then
                                If .MovieUseBaseDirectoryExpertVTS Then
                                    FilenameList.Add(Path.Combine(strMainPath, "extrathumbs"))
                                Else
                                    FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                                End If
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieExtrathumbsFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieExtrathumbsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            If .MovieUseExpert AndAlso .MovieExtrathumbsExpertBDMV Then
                                If .MovieUseBaseDirectoryExpertBDMV Then
                                    FilenameList.Add(Path.Combine(strMainPath, "extrathumbs"))
                                Else
                                    FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                                End If
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieExtrathumbsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieExtrathumbsEden) Then FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS AndAlso .MovieExtrathumbsExpertVTS Then
                                FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            ElseIf .MovieUseExpert AndAlso .MovieExtrathumbsExpertSingle Then
                                FilenameList.Add(Path.Combine(strFileParentPath, "extrathumbs"))
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainFanart
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseBoxee AndAlso .MovieFanartBoxee) Then FilenameList.Add(Path.Combine(strMainPath, "fanart.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieFanartEden) Then FilenameList.Add(String.Concat(strFilePath, "-fanart.jpg"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieFanartFrodo) Then FilenameList.Add(Path.Combine(strMainPath, "fanart.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieFanartNMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Directory.GetParent(strFileParentPath).Name), ".fanart.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieFanartYAMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(strFileParentPath).FullName, Directory.GetParent(strFileParentPath).Name), ".fanart.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieFanartExpertVTS) Then
                                For Each a In .MovieFanartExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseEden AndAlso .MovieFanartEden) Then FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, "index-fanart.jpg"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieFanartFrodo) Then FilenameList.Add(Path.Combine(strMainPath, "fanart.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieFanartNMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName).FullName, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".fanart.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieFanartYAMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".fanart.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieFanartExpertBDMV) Then
                                For Each a In .MovieFanartExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseBoxee AndAlso .MovieFanartBoxee) Then FilenameList.Add(Path.Combine(strFileParentPath, "fanart.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieFanartEden) Then FilenameList.Add(String.Concat(strFilePath, "-fanart.jpg"))
                            If bForced OrElse (.MovieUseFrodo AndAlso bIsVideoTSFile AndAlso .MovieFanartFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, "fanart.jpg"))
                            If bForced OrElse (.MovieUseFrodo AndAlso Not bIsVideoTSFile AndAlso .MovieFanartFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, "-fanart.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieFanartNMJ) Then FilenameList.Add(String.Concat(strStackedFilePath, ".fanart.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieFanartYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".fanart.jpg"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieFanartExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieFanartExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieFanartExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieFanartExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseEden AndAlso .MovieFanartEden) Then FilenameList.Add(String.Concat(strFilePath, "-fanart.jpg"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieFanartFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, "-fanart.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieFanartNMJ) Then FilenameList.Add(String.Concat(strStackedFilePath, ".fanart.jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieFanartYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".fanart.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieFanartExpertMulti) Then
                                For Each a In .MovieFanartExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainLandscape
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieLandscapeAD) Then FilenameList.Add(Path.Combine(strMainPath, "landscape.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieLandscapeExtended) Then FilenameList.Add(Path.Combine(strMainPath, "landscape.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieLandscapeExpertVTS) Then
                                For Each a In .MovieLandscapeExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseAD AndAlso .MovieLandscapeAD) Then FilenameList.Add(Path.Combine(strMainPath, "landscape.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieLandscapeExtended) Then FilenameList.Add(Path.Combine(strMainPath, "landscape.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieLandscapeExpertBDMV) Then
                                For Each a In .MovieLandscapeExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseAD AndAlso bIsVideoTSFile AndAlso .MovieLandscapeAD) Then FilenameList.Add(Path.Combine(strFileParentPath, "landscape.jpg"))
                            If bForced OrElse (.MovieUseAD AndAlso Not bIsVideoTSFile AndAlso .MovieLandscapeAD) Then FilenameList.Add(Path.Combine(strFileParentPath, "landscape.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso bIsVideoTSFile AndAlso .MovieLandscapeExtended) Then FilenameList.Add(Path.Combine(strFileParentPath, "landscape.jpg"))
                            If bForced OrElse (.MovieUseExtended AndAlso Not bIsVideoTSFile AndAlso .MovieLandscapeExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-landscape.jpg"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieLandscapeExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieLandscapeExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieLandscapeExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieLandscapeExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseExtended AndAlso .MovieLandscapeExtended) Then FilenameList.Add(String.Concat(strStackedFilePath, "-landscape.jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieLandscapeExpertMulti) Then
                                For Each a In .MovieLandscapeExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainNFO
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseBoxee AndAlso .MovieNFOBoxee) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieNFOEden) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo AndAlso .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strMainPath, "movie.nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieNFONMJ) Then FilenameList.Add(String.Concat(Directory.GetParent(strFileParentPath).FullName, Path.DirectorySeparatorChar, Directory.GetParent(strFileParentPath).Name, ".nfo"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieNFOYAMJ) Then FilenameList.Add(String.Concat(Directory.GetParent(strFileParentPath).FullName, Path.DirectorySeparatorChar, Directory.GetParent(strFileParentPath).Name, ".nfo"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieNFOExpertVTS) Then
                                For Each a In .MovieNFOExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseEden AndAlso .MovieNFOEden) Then FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, "index.nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo AndAlso .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strMainPath, "movie.nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, "index.nfo"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieNFONMJ) Then FilenameList.Add(String.Concat(Directory.GetParent(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName).FullName, Path.DirectorySeparatorChar, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name, ".nfo"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieNFOYAMJ) Then FilenameList.Add(String.Concat(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Path.DirectorySeparatorChar, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name, ".nfo"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieNFOExpertBDMV) Then
                                For Each a In .MovieNFOExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseBoxee AndAlso .MovieNFOBoxee AndAlso bIsVideoTSFile) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseBoxee AndAlso .MovieNFOBoxee AndAlso Not bIsVideoTSFile) Then FilenameList.Add(Path.Combine(strFileParentPath, "movie.nfo"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieNFOEden) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo AndAlso bIsVideoTSFile) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo AndAlso Not bIsVideoTSFile) Then FilenameList.Add(String.Concat(strStackedFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieNFONMJ) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieNFOYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                If Not String.IsNullOrEmpty(.MovieNFOExpertVTS) Then
                                    For Each a In .MovieNFOExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieNFOExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieNFOExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieNFOExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseEden AndAlso .MovieNFOEden) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieNFOFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieNFONMJ) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieNFOYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieNFOExpertMulti) Then
                                For Each a In .MovieNFOExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainPoster
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseBoxee AndAlso .MoviePosterBoxee) Then FilenameList.Add(Path.Combine(strMainPath, "folder.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MoviePosterEden) Then FilenameList.Add(String.Concat(strFilePath, ".tbn"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MoviePosterFrodo) Then FilenameList.Add(Path.Combine(strMainPath, "poster.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MoviePosterNMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Directory.GetParent(strFileParentPath).Name), ".jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MoviePosterYAMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(strFileParentPath).FullName, Directory.GetParent(strFileParentPath).Name), ".jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MoviePosterExpertVTS) Then
                                For Each a In .MoviePosterExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseEden AndAlso .MoviePosterEden) Then FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, "index.tbn"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MoviePosterFrodo) Then FilenameList.Add(Path.Combine(strMainPath, "poster.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MoviePosterNMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName).FullName, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MoviePosterYAMJ) Then FilenameList.Add(String.Concat(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".jpg"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MoviePosterExpertBDMV) Then
                                For Each a In .MoviePosterExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseBoxee AndAlso .MoviePosterBoxee) Then FilenameList.Add(Path.Combine(strFileParentPath, "folder.jpg"))
                            If bForced OrElse (.MovieUseEden AndAlso .MoviePosterEden) Then FilenameList.Add(String.Concat(strFilePath, ".tbn"))
                            If bForced OrElse (.MovieUseFrodo AndAlso bIsVideoTSFile AndAlso .MoviePosterFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, "poster.jpg"))
                            If bForced OrElse (.MovieUseFrodo AndAlso Not bIsVideoTSFile AndAlso .MoviePosterFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, "-poster.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MoviePosterNMJ) Then FilenameList.Add(String.Concat(strStackedFilePath, ".jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MoviePosterYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".jpg"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MoviePosterExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MoviePosterExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MoviePosterExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MoviePosterExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseBoxee AndAlso .MoviePosterBoxee) Then FilenameList.Add(Path.Combine(strFilePath, ".tbn"))
                            If bForced OrElse (.MovieUseEden AndAlso .MovieFanartEden) Then FilenameList.Add(String.Concat(strFilePath, ".tbn"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieFanartFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, "-poster.jpg"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieFanartNMJ) Then FilenameList.Add(String.Concat(strStackedFilePath, ".jpg"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieFanartYAMJ) Then FilenameList.Add(String.Concat(String.Concat(strFilePath, ".jpg")))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MoviePosterExpertMulti) Then
                                For Each a In .MoviePosterExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainSubtitle
                    With Master.eSettings
                        If bIsVideoTS Then
                            FilenameList.Add(Path.Combine(strMainPath, "subs"))
                        ElseIf bIsBDMV Then
                            FilenameList.Add(Path.Combine(strMainPath, "subs"))
                        ElseIf bIsSingle Then
                            FilenameList.Add(Path.Combine(strFileParentPath, "subs"))
                            FilenameList.Add(strFileParentPath)
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainTheme
                    With Master.eSettings
                        If bIsVideoTS Then
                            If .MovieThemeTvTunesEnable Then
                                If .MovieThemeTvTunesMoviePath Then FilenameList.Add(Path.Combine(strMainPath, "theme"))
                                If .MovieThemeTvTunesCustom AndAlso Not String.IsNullOrEmpty(.MovieThemeTvTunesCustomPath) Then FilenameList.Add(Path.Combine(.MovieThemeTvTunesCustomPath, "theme"))
                                If .MovieThemeTvTunesSub AndAlso Not String.IsNullOrEmpty(.MovieThemeTvTunesSubDir) Then FilenameList.Add(String.Concat(strMainPath, Path.DirectorySeparatorChar, .MovieThemeTvTunesSubDir, Path.DirectorySeparatorChar, "theme"))
                            End If
                        ElseIf bIsBDMV Then
                            If .MovieThemeTvTunesEnable Then
                                If .MovieThemeTvTunesMoviePath Then FilenameList.Add(Path.Combine(strMainPath, "theme"))
                                If .MovieThemeTvTunesCustom AndAlso Not String.IsNullOrEmpty(.MovieThemeTvTunesCustomPath) Then FilenameList.Add(Path.Combine(.MovieThemeTvTunesCustomPath, "theme"))
                                If .MovieThemeTvTunesSub AndAlso Not String.IsNullOrEmpty(.MovieThemeTvTunesSubDir) Then FilenameList.Add(String.Concat(strMainPath, Path.DirectorySeparatorChar, .MovieThemeTvTunesSubDir, Path.DirectorySeparatorChar, "theme"))
                            End If
                        Else
                            If .MovieThemeTvTunesEnable Then
                                If .MovieThemeTvTunesMoviePath Then FilenameList.Add(Path.Combine(strFileParentPath, "theme"))
                                If .MovieThemeTvTunesCustom AndAlso Not String.IsNullOrEmpty(.MovieThemeTvTunesCustomPath) Then FilenameList.Add(Path.Combine(.MovieThemeTvTunesCustomPath, "theme"))
                                If .MovieThemeTvTunesSub AndAlso Not String.IsNullOrEmpty(.MovieThemeTvTunesSubDir) Then FilenameList.Add(String.Concat(strFileParentPath, Path.DirectorySeparatorChar, .MovieThemeTvTunesSubDir, Path.DirectorySeparatorChar, "theme"))
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainTrailer
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.MovieUseEden AndAlso .MovieTrailerEden) Then FilenameList.Add(String.Concat(strFilePath, "-trailer"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieTrailerFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(String.Concat(strFilePath, "-trailer"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieTrailerNMJ) Then FilenameList.Add(String.Concat(strMainPath, Path.DirectorySeparatorChar, Directory.GetParent(strFileParentPath).Name, ".[trailer]"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieTrailerYAMJ) Then FilenameList.Add(String.Concat(strMainPath, Path.DirectorySeparatorChar, Directory.GetParent(strFileParentPath).Name, ".[trailer]"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieTrailerExpertVTS) Then
                                For Each a In .MovieTrailerExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertVTS Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(strFileParentPath).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.MovieUseEden AndAlso .MovieTrailerEden) Then FilenameList.Add(String.Concat(Directory.GetParent(strFileParentPath).FullName, Path.DirectorySeparatorChar, "index-trailer"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieTrailerFrodo AndAlso Not .MovieXBMCProtectVTSBDMV) Then FilenameList.Add(Path.Combine(strFileParentPath, "index-trailer"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieTrailerNMJ) Then FilenameList.Add(String.Concat(strMainPath, Path.DirectorySeparatorChar, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name, ".[trailer]"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieTrailerYAMJ) Then FilenameList.Add(String.Concat(strMainPath, Path.DirectorySeparatorChar, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name, ".[trailer]"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieTrailerExpertBDMV) Then
                                For Each a In .MovieTrailerExpertBDMV.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieUseBaseDirectoryExpertBDMV Then
                                        FilenameList.Add(Path.Combine(Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).FullName, a.Replace("<filename>", strFileName)))
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        ElseIf bIsSingle Then
                            If bForced OrElse (.MovieUseEden AndAlso .MovieTrailerEden) Then FilenameList.Add(String.Concat(strFilePath, "-trailer"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieTrailerFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, "-trailer"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieTrailerNMJ) Then FilenameList.Add(String.Concat(strFilePath, ".[trailer]"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieTrailerYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".[trailer]"))
                            If .MovieUseExpert AndAlso bIsVideoTSFile AndAlso .MovieRecognizeVTSExpertVTS Then
                                For Each a In .MovieTrailerExpertVTS.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            ElseIf .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieTrailerExpertSingle) Then
                                If .MovieStackExpertSingle Then
                                    For Each a In .MovieTrailerExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertSingle Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Next
                                Else
                                    For Each a In .MovieTrailerExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    Next
                                End If
                            End If
                        Else
                            If bForced OrElse (.MovieUseEden AndAlso .MovieTrailerEden) Then FilenameList.Add(String.Concat(strFilePath, "-trailer"))
                            If bForced OrElse (.MovieUseFrodo AndAlso .MovieTrailerFrodo) Then FilenameList.Add(String.Concat(strStackedFilePath, "-trailer"))
                            If bForced OrElse (.MovieUseNMJ AndAlso .MovieTrailerNMJ) Then FilenameList.Add(String.Concat(strFilePath, ".[trailer]"))
                            If bForced OrElse (.MovieUseYAMJ AndAlso .MovieTrailerYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".[trailer]"))
                            If .MovieUseExpert AndAlso Not String.IsNullOrEmpty(.MovieTrailerExpertMulti) Then
                                For Each a In .MovieTrailerExpertMulti.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If .MovieStackExpertMulti Then
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strStackedFilename)))

                                        If .MovieUnstackExpertMulti Then
                                            FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                        End If
                                    Else
                                        FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainWatchedFile
                    With Master.eSettings
                        If bIsVideoTS Then
                            If .MovieUseYAMJ AndAlso .MovieYAMJWatchedFile AndAlso String.IsNullOrEmpty(.MovieYAMJWatchedFolder) Then FilenameList.Add(String.Concat(Path.Combine(strMainPath, Directory.GetParent(strFileParentPath).Name), ".watched"))
                            If .MovieUseYAMJ AndAlso .MovieYAMJWatchedFile AndAlso Not String.IsNullOrEmpty(.MovieYAMJWatchedFolder) Then FilenameList.Add(String.Concat(Path.Combine(.MovieYAMJWatchedFolder, Directory.GetParent(strFileParentPath).Name), ".watched"))
                        ElseIf bIsBDMV Then
                            If .MovieUseYAMJ AndAlso .MovieYAMJWatchedFile AndAlso String.IsNullOrEmpty(.MovieYAMJWatchedFolder) Then FilenameList.Add(String.Concat(Path.Combine(strMainPath, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".watched"))
                            If .MovieUseYAMJ AndAlso .MovieYAMJWatchedFile AndAlso Not String.IsNullOrEmpty(.MovieYAMJWatchedFolder) Then FilenameList.Add(String.Concat(Path.Combine(.MovieYAMJWatchedFolder, Directory.GetParent(Directory.GetParent(strFileParentPath).FullName).Name), ".watched"))
                        Else
                            If .MovieUseYAMJ AndAlso .MovieYAMJWatchedFile AndAlso String.IsNullOrEmpty(.MovieYAMJWatchedFolder) Then FilenameList.Add(String.Concat(strPath, ".watched"))
                            If .MovieUseYAMJ AndAlso .MovieYAMJWatchedFile AndAlso Not String.IsNullOrEmpty(.MovieYAMJWatchedFolder) Then FilenameList.Add(String.Concat(Path.Combine(.MovieYAMJWatchedFolder, String.Concat(Path.GetFileName(strPath), ".watched"))))
                        End If
                    End With
            End Select

            FilenameList = FilenameList.Distinct().ToList() 'remove double entries
            Return FilenameList
        End Function
        ''' <summary>
        ''' Creates a list of filenames to save or read movieset content
        ''' </summary>
        ''' <param name="mType"></param>
        ''' <returns><c>List(Of String)</c> all filenames with full path</returns>
        ''' <remarks></remarks>
        Public Shared Function MovieSet(ByVal DBElement As Database.DBElement, ByVal mType As Enums.ScrapeModifierType, Optional ByVal bForceOldTitle As Boolean = False) As List(Of String)
            Dim FilenameList As New List(Of String)

            If String.IsNullOrEmpty(DBElement.MainDetails.Title) Then Return FilenameList

            Dim fSetTitle As String = If(bForceOldTitle, DBElement.MainDetails.OldTitle, DBElement.MainDetails.Title)
            For Each Invalid As Char In Path.GetInvalidFileNameChars
                fSetTitle = fSetTitle.Replace(Invalid, "-")
            Next

            Select Case mType
                Case Enums.ScrapeModifierType.MainBanner
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetBannerExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-banner.jpg")))
                        If .MovieSetUseMSAA AndAlso .MovieSetBannerMSAA AndAlso Not String.IsNullOrEmpty(.MovieSetPathMSAA) Then FilenameList.Add(Path.Combine(.MovieSetPathMSAA, String.Concat(fSetTitle, "-banner.jpg")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetBannerExpertSingle) Then
                            For Each a In .MovieSetBannerExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainClearArt
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetClearArtExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-clearart.png")))
                        If .MovieSetUseMSAA AndAlso .MovieSetClearArtMSAA AndAlso Not String.IsNullOrEmpty(.MovieSetPathMSAA) Then FilenameList.Add(Path.Combine(.MovieSetPathMSAA, String.Concat(fSetTitle, "-clearart.png")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetClearArtExpertSingle) Then
                            For Each a In .MovieSetClearArtExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainClearLogo
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetClearLogoExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-clearlogo.png")))
                        If .MovieSetUseMSAA AndAlso .MovieSetClearLogoMSAA AndAlso Not String.IsNullOrEmpty(.MovieSetPathMSAA) Then FilenameList.Add(Path.Combine(.MovieSetPathMSAA, String.Concat(fSetTitle, "-logo.png")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetClearLogoExpertSingle) Then
                            For Each a In .MovieSetClearLogoExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainDiscArt
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetDiscArtExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-discart.png")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetDiscArtExpertSingle) Then
                            For Each a In .MovieSetDiscArtExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainFanart
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetFanartExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-fanart.jpg")))
                        If .MovieSetUseMSAA AndAlso .MovieSetFanartMSAA AndAlso Not String.IsNullOrEmpty(.MovieSetPathMSAA) Then FilenameList.Add(Path.Combine(.MovieSetPathMSAA, String.Concat(fSetTitle, "-fanart.jpg")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetFanartExpertSingle) Then
                            For Each a In .MovieSetFanartExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainLandscape
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetLandscapeExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-landscape.jpg")))
                        If .MovieSetUseMSAA AndAlso .MovieSetLandscapeMSAA AndAlso Not String.IsNullOrEmpty(.MovieSetPathMSAA) Then FilenameList.Add(Path.Combine(.MovieSetPathMSAA, String.Concat(fSetTitle, "-landscape.jpg")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetLandscapeExpertSingle) Then
                            For Each a In .MovieSetLandscapeExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainNFO
                    With Master.eSettings
                        'If .MovieSetUseMSAA AndAlso .MovieSetNFOMSAA Then FilenameList.Add(Path.Combine(fPath, String.Concat(fSetName, ".nfo")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetNFOExpertSingle) Then
                            For Each a In .MovieSetNFOExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainPoster
                    With Master.eSettings
                        If .MovieSetUseExtended AndAlso .MovieSetPosterExtended AndAlso Not String.IsNullOrEmpty(.MovieSetPathExtended) Then FilenameList.Add(Path.Combine(.MovieSetPathExtended, String.Concat(fSetTitle, "-poster.jpg")))
                        If .MovieSetUseMSAA AndAlso .MovieSetPosterMSAA AndAlso Not String.IsNullOrEmpty(.MovieSetPathMSAA) Then FilenameList.Add(Path.Combine(.MovieSetPathMSAA, String.Concat(fSetTitle, "-poster.jpg")))
                        If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPathExpertSingle) AndAlso Not String.IsNullOrEmpty(.MovieSetPosterExpertSingle) Then
                            For Each a In .MovieSetPosterExpertSingle.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetTitle)))
                            Next
                        End If
                        'If .MovieSetUseExpert AndAlso Not String.IsNullOrEmpty(.MovieSetPosterExpertParent) Then
                        '    For Each a In .MovieSetPosterExpertParent.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                        '        FilenameList.Add(Path.Combine(.MovieSetPathExpertSingle, a.Replace("<settitle>", fSetName)))
                        '    Next
                        'End If
                    End With
            End Select

            FilenameList = FilenameList.Distinct().ToList() 'remove double entries
            Return FilenameList
        End Function

        Public Shared Function TVEpisode(ByVal tDBElement As Database.DBElement, ByVal mType As Enums.ScrapeModifierType, Optional ByVal bForced As Boolean = False) As List(Of String)
            Dim FilenameList As New List(Of String)

            If Not tDBElement.FilenameSpecified Then Return FilenameList

            Dim strMainPath As String = tDBElement.FileItem.MainPath.FullName
            Dim strFileName As String = Path.GetFileNameWithoutExtension(tDBElement.FileItem.FirstStackedPath)
            Dim strFileParentPath As String = Directory.GetParent(tDBElement.FileItem.FirstStackedPath).FullName
            Dim strFilePath As String = Common.RemoveExtFromPath(tDBElement.FileItem.FirstStackedPath)

            Dim bIsBDMV As Boolean = tDBElement.FileItem.bIsBDMV
            Dim bIsVideoTS As Boolean = tDBElement.FileItem.bIsVideoTS
            Dim bIsVideoTSFile As Boolean = strFileName.ToLower = "video_ts"

            Select Case mType
                Case Enums.ScrapeModifierType.EpisodeActorThumbs
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodeActorThumbsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodeActorThumbsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                        Else
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodeActorThumbsFrodo) Then FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!.jpg"))
                            If .TVUseExpert AndAlso .TVEpisodeActorThumbsExpert AndAlso Not String.IsNullOrEmpty(.TVEpisodeActorThumbsExtExpert) Then
                                FilenameList.Add(Path.Combine(strFileParentPath, ".actors", "!placeholder!", .TVEpisodeActorThumbsExtExpert))
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.EpisodeFanart
                    With Master.eSettings
                        If bIsVideoTS Then
                            'TODO
                        ElseIf bIsBDMV Then
                            'TODO
                        Else
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVEpisodeFanartExpert) Then
                                For Each a In .TVEpisodeFanartExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.EpisodeNFO
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodeNFOFrodo) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodeNFOFrodo) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                        Else
                            If bForced OrElse (.TVUseBoxee AndAlso .TVEpisodeNFOBoxee) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.TVUseEden) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodeNFOFrodo) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If bForced OrElse (.TVUseYAMJ AndAlso .TVEpisodeNFOYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".nfo"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVEpisodeNFOExpert) Then
                                For Each a In .TVEpisodeNFOExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.EpisodePoster
                    With Master.eSettings
                        If bIsVideoTS Then
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodePosterFrodo) Then FilenameList.Add(Path.Combine(strMainPath, "thumb.jpg"))
                        ElseIf bIsBDMV Then
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodePosterFrodo) Then FilenameList.Add(Path.Combine(strMainPath, "thumb.jpg"))
                        Else
                            If bForced OrElse (.TVUseBoxee AndAlso .TVEpisodePosterBoxee) Then FilenameList.Add(String.Concat(strFilePath, ".tbn"))
                            If bForced OrElse (.TVUseFrodo AndAlso .TVEpisodePosterFrodo) Then FilenameList.Add(String.Concat(strFilePath, "-thumb.jpg"))
                            If bForced OrElse (.TVUseYAMJ AndAlso .TVEpisodePosterYAMJ) Then FilenameList.Add(String.Concat(strFilePath, ".videoimage.jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVEpisodePosterExpert) Then
                                For Each a In .TVEpisodePosterExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    FilenameList.Add(Path.Combine(strFileParentPath, a.Replace("<filename>", strFileName)))
                                Next
                            End If
                        End If
                    End With
            End Select

            FilenameList = FilenameList.Distinct().ToList() 'remove double entries
            Return FilenameList
        End Function

        Public Shared Function TVSeason(ByVal DBElement As Database.DBElement, ByVal mType As Enums.ScrapeModifierType) As List(Of String)
            Dim FilenameList As New List(Of String)
            Dim bInside As Boolean = False

            If String.IsNullOrEmpty(DBElement.ShowPath) Then Return FilenameList

            Dim fEpisodePath As String = String.Empty
            Dim fSeasonPath As String = Functions.GetSeasonDirectoryFromShowPath(DBElement.ShowPath, DBElement.MainDetails.Season)
            Dim fShowPath As String = DBElement.ShowPath
            Dim sSeason As String = DBElement.MainDetails.Season.ToString.PadLeft(2, Convert.ToChar("0"))
            Dim fSeasonFolder As String = Path.GetFileName(fSeasonPath)

            'checks if there are separate season folders
            If Not String.IsNullOrEmpty(fSeasonPath) AndAlso Not fSeasonPath = fShowPath Then
                bInside = True
            End If

            'get first episode of season (YAMJ need that for episodes without separate season folders)
            Try
                If Master.eSettings.TVUseYAMJ AndAlso Not bInside Then
                    Dim dtEpisodes As New DataTable
                    Master.DB.FillDataTable(dtEpisodes, String.Concat("SELECT * FROM episode INNER JOIN files ON (files.idFile = episode.idFile) WHERE idShow = ", DBElement.ShowID, " AND Season = ", DBElement.MainDetails.Season, " ORDER BY Episode;"))
                    If dtEpisodes.Rows.Count > 0 Then
                        fEpisodePath = dtEpisodes.Rows(0).Item("strFilename").ToString
                        If Not String.IsNullOrEmpty(fEpisodePath) Then
                            fEpisodePath = Path.Combine(Directory.GetParent(fEpisodePath).FullName, Path.GetFileNameWithoutExtension(fEpisodePath))
                        End If
                    End If
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try

            Select Case mType
                Case Enums.ScrapeModifierType.SeasonBanner
                    With Master.eSettings
                        If DBElement.MainDetails.Season = 0 Then 'season specials
                            If .TVUseFrodo AndAlso .TVSeasonFanartFrodo Then FilenameList.Add(Path.Combine(fShowPath, "season-specials-banner.jpg"))
                            If .TVUseYAMJ AndAlso .TVSeasonBannerYAMJ AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, String.Concat(fSeasonFolder, ".banner.jpg")))
                            If .TVUseYAMJ AndAlso .TVSeasonBannerYAMJ AndAlso Not bInside AndAlso Not String.IsNullOrEmpty(fEpisodePath) Then FilenameList.Add(String.Concat(fEpisodePath, ".banner.jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonBannerExpert) Then
                                For Each a In .TVSeasonBannerExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        Else
                            If .TVUseFrodo AndAlso .TVSeasonBannerFrodo Then FilenameList.Add(Path.Combine(fShowPath, String.Format("season{0}-banner.jpg", sSeason)))
                            If .TVUseYAMJ AndAlso .TVSeasonBannerYAMJ AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, String.Concat(fSeasonFolder, ".banner.jpg")))
                            If .TVUseYAMJ AndAlso .TVSeasonBannerYAMJ AndAlso Not bInside AndAlso Not String.IsNullOrEmpty(fEpisodePath) Then FilenameList.Add(String.Concat(fEpisodePath, ".banner.jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonBannerExpert) Then
                                For Each a In .TVSeasonBannerExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.SeasonFanart
                    With Master.eSettings
                        If DBElement.MainDetails.Season = 0 Then 'season specials
                            If .TVUseFrodo AndAlso .TVSeasonFanartFrodo Then FilenameList.Add(Path.Combine(fShowPath, "season-specials-fanart.jpg"))
                            If .TVUseYAMJ AndAlso .TVSeasonFanartYAMJ AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, String.Concat(fSeasonFolder, ".fanart.jpg")))
                            If .TVUseYAMJ AndAlso .TVSeasonFanartYAMJ AndAlso Not bInside AndAlso Not String.IsNullOrEmpty(fEpisodePath) Then FilenameList.Add(String.Concat(fEpisodePath, ".fanart.jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonFanartExpert) Then
                                For Each a In .TVSeasonFanartExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        Else
                            If .TVUseFrodo AndAlso .TVSeasonFanartFrodo Then FilenameList.Add(Path.Combine(fShowPath, String.Format("season{0}-fanart.jpg", sSeason)))
                            If .TVUseYAMJ AndAlso .TVSeasonFanartYAMJ AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, String.Concat(fSeasonFolder, ".fanart.jpg")))
                            If .TVUseYAMJ AndAlso .TVSeasonFanartYAMJ AndAlso Not bInside AndAlso Not String.IsNullOrEmpty(fEpisodePath) Then FilenameList.Add(String.Concat(fEpisodePath, ".fanart.jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonFanartExpert) Then
                                For Each a In .TVSeasonFanartExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.SeasonLandscape
                    With Master.eSettings
                        If DBElement.MainDetails.Season = 0 Then 'season specials
                            If .TVUseAD AndAlso .TVSeasonLandscapeAD Then FilenameList.Add(Path.Combine(fShowPath, "season-specials-landscape.jpg"))
                            If .TVUseExtended AndAlso .TVSeasonLandscapeExtended Then FilenameList.Add(Path.Combine(fShowPath, "season-specials-landscape.jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonLandscapeExpert) Then
                                For Each a In .TVSeasonLandscapeExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        Else
                            If .TVUseAD AndAlso .TVSeasonLandscapeAD Then FilenameList.Add(Path.Combine(fShowPath, String.Format("season{0}-landscape.jpg", sSeason)))
                            If .TVUseExtended AndAlso .TVSeasonLandscapeExtended Then FilenameList.Add(Path.Combine(fShowPath, String.Format("season{0}-landscape.jpg", sSeason)))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonLandscapeExpert) Then
                                For Each a In .TVSeasonLandscapeExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        End If
                    End With

                Case Enums.ScrapeModifierType.SeasonPoster
                    With Master.eSettings
                        If DBElement.MainDetails.Season = 0 Then 'season specials
                            If .TVUseBoxee AndAlso .TVSeasonPosterBoxee AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, "poster.jpg"))
                            If .TVUseFrodo AndAlso .TVSeasonPosterFrodo Then FilenameList.Add(Path.Combine(fShowPath, "season-specials-poster.jpg"))
                            If .TVUseYAMJ AndAlso .TVSeasonPosterYAMJ AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, String.Concat(fSeasonFolder, ".jpg")))
                            If .TVUseYAMJ AndAlso .TVSeasonPosterYAMJ AndAlso Not bInside AndAlso Not String.IsNullOrEmpty(fEpisodePath) Then FilenameList.Add(String.Concat(fEpisodePath, ".jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonPosterExpert) Then
                                For Each a In .TVSeasonPosterExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        Else
                            If .TVUseBoxee AndAlso .TVSeasonPosterBoxee AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, "poster.jpg"))
                            If .TVUseFrodo AndAlso .TVSeasonPosterFrodo Then FilenameList.Add(Path.Combine(fShowPath, String.Format("season{0}-poster.jpg", sSeason)))
                            If .TVUseYAMJ AndAlso .TVSeasonPosterYAMJ AndAlso bInside Then FilenameList.Add(Path.Combine(fSeasonPath, String.Concat(fSeasonFolder, ".jpg")))
                            If .TVUseYAMJ AndAlso .TVSeasonPosterYAMJ AndAlso Not bInside AndAlso Not String.IsNullOrEmpty(fEpisodePath) Then FilenameList.Add(String.Concat(fEpisodePath, ".jpg"))
                            If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVSeasonPosterExpert) Then
                                For Each a In .TVSeasonPosterExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                    If Not (a.Contains("<seasonpath>") AndAlso Not bInside) Then
                                        Dim sPath As String = a.Replace("<seasonpath>", fSeasonPath)
                                        sPath = String.Format(sPath, sSeason, DBElement.MainDetails.Season, sSeason) 'Season# padding: {0} = 01; {1} = 1; {2} = 01
                                        FilenameList.Add(Path.Combine(fShowPath, sPath))
                                    End If
                                Next
                            End If
                        End If
                    End With
            End Select

            FilenameList = FilenameList.Distinct().ToList() 'remove double entries
            Return FilenameList
        End Function

        Public Shared Function TVShow(ByVal DBElement As Database.DBElement, ByVal mType As Enums.ScrapeModifierType) As List(Of String)
            Dim FilenameList As New List(Of String)

            If String.IsNullOrEmpty(DBElement.ShowPath) Then Return FilenameList

            Dim fShowPath As String = DBElement.ShowPath
            Dim fShowFolder As String = Path.GetFileName(fShowPath)

            Select Case mType
                Case Enums.ScrapeModifierType.MainActorThumbs
                    With Master.eSettings
                        If .TVUseFrodo AndAlso .TVShowActorThumbsFrodo Then FilenameList.Add(String.Concat(fShowPath, "\.actors", "\<placeholder>.jpg"))
                        If .TVUseExpert AndAlso .TVShowActorThumbsExpert AndAlso Not String.IsNullOrEmpty(.TVShowActorThumbsExtExpert) Then
                            FilenameList.Add(String.Concat(fShowPath, "\.actors", "\<placeholder>", .TVShowActorThumbsExtExpert))
                        End If
                    End With

                Case Enums.ScrapeModifierType.AllSeasonsBanner
                    With Master.eSettings
                        If .TVUseFrodo AndAlso .TVSeasonBannerFrodo Then FilenameList.Add(Path.Combine(fShowPath, "season-all-banner.jpg"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVAllSeasonsBannerExpert) Then
                            For Each a In .TVAllSeasonsBannerExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.AllSeasonsFanart
                    With Master.eSettings
                        If .TVUseFrodo AndAlso .TVSeasonFanartFrodo Then FilenameList.Add(Path.Combine(fShowPath, "season-all-fanart.jpg"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVAllSeasonsFanartExpert) Then
                            For Each a In .TVAllSeasonsFanartExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.AllSeasonsLandscape
                    With Master.eSettings
                        If .TVUseAD AndAlso .TVSeasonLandscapeAD Then FilenameList.Add(Path.Combine(fShowPath, "season-all-landscape.jpg"))
                        If .TVUseExtended AndAlso .TVSeasonLandscapeExtended Then FilenameList.Add(Path.Combine(fShowPath, "season-all-landscape.jpg"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVAllSeasonsLandscapeExpert) Then
                            For Each a In .TVAllSeasonsLandscapeExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.AllSeasonsPoster
                    With Master.eSettings
                        If .TVUseFrodo AndAlso .TVSeasonPosterFrodo Then FilenameList.Add(Path.Combine(fShowPath, "season-all-poster.jpg"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVAllSeasonsPosterExpert) Then
                            For Each a In .TVAllSeasonsPosterExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainBanner
                    With Master.eSettings
                        If .TVUseBoxee AndAlso .TVShowBannerBoxee Then FilenameList.Add(Path.Combine(fShowPath, "banner.jpg"))
                        If .TVUseFrodo AndAlso .TVShowBannerFrodo Then FilenameList.Add(Path.Combine(fShowPath, "banner.jpg"))
                        If .TVUseYAMJ AndAlso .TVShowBannerYAMJ Then FilenameList.Add(Path.Combine(fShowPath, String.Concat(fShowFolder, ".banner.jpg")))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowBannerExpert) Then
                            For Each a In .TVShowBannerExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainCharacterArt
                    With Master.eSettings
                        If .TVUseAD AndAlso .TVShowCharacterArtAD Then FilenameList.Add(Path.Combine(fShowPath, "character.png"))
                        If .TVUseExtended AndAlso .TVShowCharacterArtExtended Then FilenameList.Add(Path.Combine(fShowPath, "characterart.png"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowCharacterArtExpert) Then
                            For Each a In .TVShowCharacterArtExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainClearArt
                    With Master.eSettings
                        If .TVUseAD AndAlso .TVShowClearArtAD Then FilenameList.Add(Path.Combine(fShowPath, "clearart.png"))
                        If .TVUseExtended AndAlso .TVShowClearArtExtended Then FilenameList.Add(Path.Combine(fShowPath, "clearart.png"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowClearArtExpert) Then
                            For Each a In .TVShowClearArtExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainClearLogo
                    With Master.eSettings
                        If .TVUseAD AndAlso .TVShowClearLogoAD Then FilenameList.Add(Path.Combine(fShowPath, "logo.png"))
                        If .TVUseExtended AndAlso .TVShowClearLogoExtended Then FilenameList.Add(Path.Combine(fShowPath, "clearlogo.png"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowClearLogoExpert) Then
                            For Each a In .TVShowClearLogoExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainExtrafanarts
                    With Master.eSettings
                        If .TVUseEden AndAlso .TVShowExtrafanartsFrodo Then FilenameList.Add(Path.Combine(fShowPath, "extrafanart"))
                        If .TVUseExpert AndAlso .TVShowExtrafanartsExpert Then FilenameList.Add(Path.Combine(fShowPath, "extrafanart"))
                        If .TVUseFrodo AndAlso .TVShowExtrafanartsFrodo Then FilenameList.Add(Path.Combine(fShowPath, "extrafanart"))
                    End With

                Case Enums.ScrapeModifierType.MainFanart
                    With Master.eSettings
                        If .TVUseBoxee AndAlso .TVShowFanartBoxee Then FilenameList.Add(Path.Combine(fShowPath, "fanart.jpg"))
                        If .TVUseFrodo AndAlso .TVShowFanartFrodo Then FilenameList.Add(Path.Combine(fShowPath, "fanart.jpg"))
                        If .TVUseYAMJ AndAlso .TVShowFanartYAMJ Then FilenameList.Add(Path.Combine(fShowPath, String.Concat(fShowFolder, ".fanart.jpg")))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowFanartExpert) Then
                            For Each a In .TVShowFanartExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainLandscape
                    With Master.eSettings
                        If .TVUseAD AndAlso .TVShowLandscapeAD Then FilenameList.Add(Path.Combine(fShowPath, "landscape.jpg"))
                        If .TVUseExtended AndAlso .TVShowLandscapeExtended Then FilenameList.Add(Path.Combine(fShowPath, "landscape.jpg"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowLandscapeExpert) Then
                            For Each a In .TVShowLandscapeExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainNFO
                    With Master.eSettings
                        If .TVUseBoxee AndAlso .TVShowNFOBoxee Then FilenameList.Add(Path.Combine(fShowPath, "tvshow.nfo"))
                        If .TVUseFrodo AndAlso .TVShowNFOFrodo Then FilenameList.Add(Path.Combine(fShowPath, "tvshow.nfo"))
                        If .TVUseYAMJ AndAlso .TVShowNFOYAMJ Then FilenameList.Add(Path.Combine(fShowPath, "tvshow.nfo"))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowNFOExpert) Then
                            For Each a In .TVShowNFOExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainPoster
                    With Master.eSettings
                        If .TVUseBoxee AndAlso .TVShowPosterBoxee Then FilenameList.Add(Path.Combine(fShowPath, "folder.jpg"))
                        If .TVUseFrodo AndAlso .TVShowPosterFrodo Then FilenameList.Add(Path.Combine(fShowPath, "poster.jpg"))
                        If .TVUseYAMJ AndAlso .TVShowPosterYAMJ Then FilenameList.Add(Path.Combine(fShowPath, String.Concat(fShowFolder, ".jpg")))
                        If .TVUseExpert AndAlso Not String.IsNullOrEmpty(.TVShowPosterExpert) Then
                            For Each a In .TVShowPosterExpert.Split(New String() {","c}, StringSplitOptions.RemoveEmptyEntries)
                                FilenameList.Add(Path.Combine(fShowPath, a))
                            Next
                        End If
                    End With

                Case Enums.ScrapeModifierType.MainTheme
                    With Master.eSettings
                        If .TVShowThemeTvTunesEnable Then
                            If .TVShowThemeTvTunesShowPath Then FilenameList.Add(Path.Combine(fShowPath, "theme"))
                            If .TVShowThemeTvTunesCustom AndAlso Not String.IsNullOrEmpty(.TVShowThemeTvTunesCustomPath) Then FilenameList.Add(Path.Combine(.TVShowThemeTvTunesCustomPath, "theme"))
                            If .TVShowThemeTvTunesSub AndAlso Not String.IsNullOrEmpty(.TVShowThemeTvTunesSubDir) Then FilenameList.Add(String.Concat(fShowPath, Path.DirectorySeparatorChar, .TVShowThemeTvTunesSubDir, Path.DirectorySeparatorChar, "theme"))
                        End If
                    End With
            End Select

            FilenameList = FilenameList.Distinct().ToList() 'remove double entries
            Return FilenameList
        End Function

#End Region 'Methods

    End Class

    Public Class Stacking

#Region "Methods"

        Public Shared Function ConstructStackPath(tItemList As FileItemList, iStack As List(Of Integer)) As String
            Dim strStackedPath As String = "stack://"
            Dim strFilename As String = tItemList.GetItem(iStack(0)).FileInfo.FullName
            'double escape any occurence of commas
            strFilename = strFilename.Replace(",", ",,")
            strStackedPath += strFilename

            Dim i As Integer = 1
            While i < iStack.Count
                strStackedPath += " , "
                strFilename = tItemList.GetItem(iStack(i)).FileInfo.FullName

                'double escape any occurence of commas
                strFilename = strFilename.Replace(",", ",,")
                strStackedPath += strFilename
                i += 1
            End While

            Return strStackedPath
        End Function

        Public Shared Function ConstructStackPath(tPaths As List(Of String)) As String
            If tPaths.Count = 0 Then Return String.Empty
            If Not tPaths.Count > 1 Then Return tPaths(0)

            Dim strStackedPath As String = "stack://"
            Dim strFilename As String = tPaths(0)
            'double escape any occurence of commas
            strFilename = strFilename.Replace(",", ",,")
            strStackedPath += strFilename

            Dim i As Integer = 1
            While i < tPaths.Count
                strStackedPath += " , "
                strFilename = tPaths(i)

                'double escape any occurence of commas
                strFilename = strFilename.Replace(",", ",,")
                strStackedPath += strFilename
                i += 1
            End While

            Return strStackedPath
        End Function

        Public Shared Function GetFirstStackedPath(strFilename As String) As String
            Dim strFirstFilename As String = String.Empty
            If strFilename.Contains(" , ") Then
                strFirstFilename = strFilename.Substring(0, strFilename.IndexOf(" , "))
            Else 'single filed stacks - should really not happen
                strFirstFilename = strFilename
            End If

            'remove "stack://" from the folder
            strFirstFilename = strFirstFilename.Replace("stack://", String.Empty)
            strFirstFilename = strFirstFilename.Replace(",,", ",")

            Return strFirstFilename
        End Function

        Public Shared Function GetPathList(strFilename As String) As List(Of String)
            Dim lstPaths As New List(Of String)
            'format Is:
            'stack://file1 , file2 , file3 , file4
            'filenames with commas are double escaped (ie replaced with ,,), thus the " , " separator used.

            'remove stack:// from the beginning
            strFilename = strFilename.Replace("stack://", String.Empty)

            lstPaths = Regex.Split(strFilename, " , ").ToList
            For Each nPath In lstPaths
                nPath = nPath.Replace(",,", ",")
            Next

            Return lstPaths
        End Function

        Public Shared Function GetStackedPath(strPath As String) As String
            If String.IsNullOrEmpty(strPath) Then Return String.Empty

            If strPath.StartsWith("stack://") Then
                Dim strFirstStackedFile As String = GetFirstStackedPath(strPath)
                Dim strFileStackingPattern As String = clsXMLAdvancedSettings.GetSetting("FileStacking", "(.*?)([ _.-]*(?:cd|dvd|p(?:ar)?t|dis[ck])[ _.-]*[0-9]+)(.*?)(\.[^.]+)$")
                Dim rResultFileItem1 As Match = Regex.Match(strFirstStackedFile, strFileStackingPattern, RegexOptions.IgnoreCase)
                If rResultFileItem1.Success Then
                    Dim strTitle1 As String = rResultFileItem1.Groups(1).Value
                    Dim strVolume1 As String = rResultFileItem1.Groups(2).Value
                    Dim strIgnore1 As String = rResultFileItem1.Groups(3).Value
                    Dim strExtension1 As String = rResultFileItem1.Groups(4).Value

                    Return String.Concat(strTitle1, strIgnore1, strExtension1)
                End If
            End If
            Return strPath
        End Function

#End Region 'Methods

    End Class
    ''' <summary>
    ''' This module is a convenience library for sorting files into respective subdirectories.
    ''' This module does NOT need to be instantiated!
    ''' </summary>
    ''' <remarks></remarks>
    Public Module FileSorter

#Region "Fields"

        Dim logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Events"
        ''' <summary>
        ''' Event that is raised when SortFiles desires the progress indicator to be updated
        ''' </summary>
        ''' <param name="iPercent">Percentage complete</param>
        ''' <param name="sStatus">Message to be displayed alongside the progress indicator</param>
        ''' <remarks></remarks>
        Public Event ProgressUpdated(ByVal iPercent As Integer, ByVal sStatus As String)

#End Region 'Events

#Region "Methods"
        ''' <summary>
        ''' Reorganize the media files in the given folder into subfolders.
        ''' </summary>
        ''' <param name="strSourcePath">Path to be sorted</param>
        ''' <remarks>Occasionally a directory will contain multiple media files (and meta-files) and 
        ''' this method will walk through the files in that directory and move each to its own unique subdirectory.
        ''' This will move all files with the same core name, without extension or fanart/trailer endings.</remarks>
        Public Sub SortFiles(ByVal strSourcePath As String)
            'TODO Need to test what happens if sPath points to an existing FILE (And Not just a directory)
            Dim iCount As Integer = 0

            Try
                If Directory.Exists(strSourcePath) Then
                    'Get information about files in the directory
                    Dim nFileItemList As New FileItemList(strSourcePath, Enums.ContentType.Movie)

                    'For each valid file in the directory...
                    For Each nFileItem As FileItem In nFileItemList.FileItems.Where(Function(f) Not f.bIsDirectory AndAlso Not f.bIsBDMV AndAlso Not f.bIsVideoTS)
                        Dim nMovie As New Database.DBElement(Enums.ContentType.Movie) With {.FileItem = nFileItem, .IsSingle = False}
                        RaiseEvent ProgressUpdated((iCount \ nFileItemList.FileItems.Count), String.Concat(Master.eLang.GetString(219, "Moving "), nFileItem.FirstStackedPath))

                        'create a new directory for the movie
                        Dim strNewPath As String = Path.Combine(strSourcePath, Path.GetFileNameWithoutExtension(nMovie.FileItem.StackedFilename))
                        If Not Directory.Exists(strNewPath) Then
                            Directory.CreateDirectory(strNewPath)
                        End If

                        'move movie to the new directory
                        For Each nFile As String In nFileItem.PathList
                            File.Move(nFile, Path.Combine(strNewPath, Path.GetFileName(nFile)))
                        Next

                        'search for files that belong to this movie
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainBanner, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainCharacterArt, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainClearArt, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainClearLogo, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainDiscArt, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainFanart, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainLandscape, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainNFO, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainPoster, True)
                            If File.Exists(a) Then File.Move(a, Path.Combine(strNewPath, Path.GetFileName(a)))
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainTheme, True)
                            For Each t As String In Master.eSettings.FileSystemValidThemeExts
                                If File.Exists(String.Concat(a, t)) Then File.Move(String.Concat(a, t), Path.Combine(strNewPath, Path.GetFileName(String.Concat(a, t))))
                            Next
                        Next
                        For Each a In GetFilenameList.Movie(nMovie, Enums.ScrapeModifierType.MainTrailer, True)
                            For Each t As String In Master.eSettings.FileSystemValidExts
                                If File.Exists(String.Concat(a, t)) Then File.Move(String.Concat(a, t), Path.Combine(strNewPath, Path.GetFileName(String.Concat(a, t))))
                            Next
                        Next
                        iCount += 1
                    Next

                    RaiseEvent ProgressUpdated((iCount \ nFileItemList.FileItems.Where(Function(f) Not f.bIsDirectory AndAlso Not f.bIsBDMV AndAlso Not f.bIsVideoTS).Count), Master.eLang.GetString(362, "Done "))
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        End Sub

#End Region 'Methods

    End Module

End Namespace

