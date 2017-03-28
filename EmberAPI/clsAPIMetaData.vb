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

Imports NLog
Imports System.IO
Imports System.Text.RegularExpressions

Public Class MetaData

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Methods"

    Private Shared Function ApplyDefaults(ByVal tDBElement As Database.DBElement) As MediaContainers.Fileinfo
        Dim nFileInfo As New MediaContainers.Fileinfo
        Dim nMetadataList As New List(Of Settings.MetadataPerType)

        Select Case tDBElement.ContentType
            Case Enums.ContentType.Movie
                nMetadataList = Master.eSettings.MovieMetadataPerFileType
            Case Enums.ContentType.TVEpisode
                nMetadataList = Master.eSettings.TVMetadataPerFileType
        End Select

        For Each m As Settings.MetadataPerType In nMetadataList
            If m.FileType.ToLower = tDBElement.FileItem.FileInfo.Extension.ToLower Then
                nFileInfo = m.MetaData
                Return nFileInfo
            End If
        Next
        Return Nothing
    End Function

    Private Shared Function CleanupFileInfo(ByVal tFileInfo As MediaContainers.Fileinfo) As MediaContainers.Fileinfo
        If tFileInfo.StreamDetailsSpecified Then
            If tFileInfo.StreamDetails.VideoSpecified Then
                For i As Integer = 0 To tFileInfo.StreamDetails.Video.Count - 1
                    tFileInfo.StreamDetails.Video(i).StereoMode = ConvertVideoStereoMode(tFileInfo.StreamDetails.Video(i).MultiViewLayout)
                Next
            End If
        End If

        Return tFileInfo
    End Function

    Public Shared Function ConvertVideoStereoMode(ByVal strFormat As String) As String
        Select Case strFormat.ToLower
            Case "side by side (left eye first)"
                Return "left_right"
            Case "top-bottom (right eye first)"
                Return "bottom_top"
            Case "top-bottom (left eye first)"
                Return "bottom_top"
            Case "checkboard (right eye first)"
                Return "checkerboard_rl"
            Case "checkboard (left eye first)"
                Return "checkerboard_lr"
            Case "row interleaved (right eye first)"
                Return "row_interleaved_rl"
            Case "row interleaved (left eye first)"
                Return "row_interleaved_lr"
            Case "column interleaved (right eye first)"
                Return "col_interleaved_rl"
            Case "column interleaved (left eye first)"
                Return "col_interleaved_lr"
            Case "anaglyph (cyan/red)"
                Return "anaglyph_cyan_red"
            Case "side by side (right eye first)"
                Return "right_left"
            Case "anaglyph (green/magenta)"
                Return "anaglyph_green_magenta"
            Case "both eyes laced in one block (left eye first)"
                Return "block_lr"
            Case "both eyes laced in one block (right eye first)"
                Return "block_rl"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Shared Function FormatVideoDurationFromSeconds(ByVal strDurationInSeconds As String, ByVal strMask As String) As String
        Dim intHours As Integer = 0
        Dim intMinutes As Integer = 0
        Dim intSeconds As Integer = 0

        'new handling: only seconds as tdur
        If Integer.TryParse(strDurationInSeconds, 0) Then
            Dim ts As New TimeSpan(0, 0, Convert.ToInt32(strDurationInSeconds))
            intHours = ts.Hours
            intMinutes = ts.Minutes
            intSeconds = ts.Seconds
        End If

        If strMask.Contains("<h>") Then
            If strMask.Contains("<m>") OrElse strMask.Contains("<0m>") Then
                If strMask.Contains("<s>") OrElse strMask.Contains("<0s>") Then
                    Return strMask.Replace("<h>", intHours.ToString).Replace("<m>", intMinutes.ToString).Replace("<0m>", intMinutes.ToString("00")).Replace("<s>", intSeconds.ToString).Replace("<0s>", intSeconds.ToString("00"))
                Else
                    Return strMask.Replace("<h>", intHours.ToString).Replace("<m>", intMinutes.ToString).Replace("<0m>", intMinutes.ToString("00"))
                End If
            Else
                Dim tHDec As String = If(intMinutes > 0, Convert.ToSingle(1 / (60 / intMinutes)).ToString(".00"), String.Empty)
                Return strMask.Replace("<h>", String.Concat(intHours, tHDec))
            End If
        ElseIf strMask.Contains("<m>") Then
            If strMask.Contains("<s>") OrElse strMask.Contains("<0s>") Then
                Return strMask.Replace("<m>", ((intHours * 60) + intMinutes).ToString).Replace("<s>", intSeconds.ToString).Replace("<0s>", intSeconds.ToString("00"))
            Else
                Return strMask.Replace("<m>", ((intHours * 60) + intMinutes).ToString)
            End If
        ElseIf strMask.Contains("<s>") Then
            Return strMask.Replace("<s>", ((intHours * 60 * 60) + intMinutes * 60 + intSeconds).ToString)
        Else
            Return strMask
        End If
    End Function

    Private Shared Function ScanFileItem(ByVal tFileItem As FileItem, ByVal tContentType As Enums.ContentType) As MediaContainers.Fileinfo
        Dim nFileInfo As New MediaContainers.Fileinfo

        If Not String.IsNullOrEmpty(tFileItem.FullPath) AndAlso File.Exists(tFileItem.FirstStackedPath) Then
            Dim nStackedFiles As New List(Of MediaContainers.Fileinfo)
            Dim nMediaInfo As New MediaInfo

            'scan Main video file to get all media informations
            If tFileItem.bIsDiscImage Then
                Dim nDiscImage As New DiscImage
                nDiscImage.Mount(tFileItem.FirstStackedPath)
                If nDiscImage.IsMounted Then
                    Dim nFileItemList As New FileItemList(nDiscImage.Path, tContentType)
                    If nFileItemList.FileItems.Count > 0 Then
                        nFileInfo = ScanFileItem(nFileItemList.FileItems.Item(0), tContentType)
                        nDiscImage.Unmount()
                    End If
                End If
            Else
                nFileInfo = nMediaInfo.ScanPath(tFileItem.FirstStackedPath)
            End If

            'scan all stacked video files to get the total duration
            For Each strStackedPath In tFileItem.PathList.Where(Function(f) Not f.ToString = tFileItem.FirstStackedPath)
                If File.Exists(strStackedPath) Then
                    If tFileItem.bIsDiscImage Then
                        Dim nDiscImage As New DiscImage
                        nDiscImage.Mount(strStackedPath)
                        If nDiscImage.IsMounted Then
                            Dim nAdditionalFileInfo = nMediaInfo.ScanPath(nDiscImage.Path)
                            If nAdditionalFileInfo IsNot Nothing AndAlso nAdditionalFileInfo.StreamDetailsSpecified Then
                                nStackedFiles.Add(nAdditionalFileInfo)
                            End If
                            nDiscImage.Unmount()
                        End If
                    Else
                        Dim nAdditionalFileInfo = nMediaInfo.ScanPath(strStackedPath)
                        If nAdditionalFileInfo IsNot Nothing AndAlso nAdditionalFileInfo.StreamDetailsSpecified Then
                            nStackedFiles.Add(nAdditionalFileInfo)
                        End If
                    End If
                Else
                    logger.Error(String.Format("[MetaData] [ScanFileItem] Stacked file not found: {0} ", strStackedPath))
                End If
            Next

            'Set TotalDuration of stacked files
            If nStackedFiles.Count > 0 Then
                Dim intTotalRuntime As Integer = 0
                Integer.TryParse(nFileInfo.StreamDetails.Video(0).Duration, intTotalRuntime)
                For Each nStackedFile In nStackedFiles
                    Dim intStackTime As Integer = 0
                    If Integer.TryParse(nStackedFile.StreamDetails.Video(0).Duration, intStackTime) Then
                        intTotalRuntime += intStackTime
                    End If
                Next
                nFileInfo.StreamDetails.Video(0).Duration = (intTotalRuntime).ToString
            End If
        End If

        Return nFileInfo
    End Function

    Public Shared Sub ScanMetaData(ByRef tDBElement As Database.DBElement)
        Dim bLockAudioLanguage As Boolean
        Dim bLockVideoLanguage As Boolean
        Dim nFileInfo = New MediaContainers.Fileinfo
        Dim strRuntimeMask As String = String.Empty

        Select Case tDBElement.ContentType
            Case Enums.ContentType.Movie
                bLockAudioLanguage = Master.eSettings.Movie.DataSettings.LockAudioLanguage
                bLockVideoLanguage = Master.eSettings.Movie.DataSettings.LockVideoLanguage
                strRuntimeMask = Master.eSettings.Movie.DataSettings.DurationFormat
            Case Enums.ContentType.TVEpisode
                bLockAudioLanguage = Master.eSettings.TV.DataSettings.TVEpisode.LockAudioLanguage
                bLockVideoLanguage = Master.eSettings.TV.DataSettings.TVEpisode.LockVideoLanguage
                strRuntimeMask = Master.eSettings.TV.DataSettings.DurationFormat
        End Select

        If Not tDBElement.FileItem.bIsDiscStub AndAlso Master.CanScanDiscImage OrElse Not (tDBElement.FileItem.bIsDiscImage OrElse tDBElement.FileItem.bIsRAR) Then
            nFileInfo = ScanFileItem(tDBElement.FileItem, tDBElement.ContentType)

            If nFileInfo.StreamDetailsSpecified Then
                ' overwrite only if it get something from Mediainfo 
                If bLockAudioLanguage Then
                    'sets old language setting if setting is enabled (lock language)
                    'First make sure that there is no completely new audio source scanned of the movie --> if so (i.e. more streams) then update!
                    If nFileInfo.StreamDetails.Audio.Count = tDBElement.MainDetails.FileInfo.StreamDetails.Audio.Count Then
                        For i = 0 To nFileInfo.StreamDetails.Audio.Count - 1
                            'only preserve if language tag is filled --> else update!
                            If Not String.IsNullOrEmpty(tDBElement.MainDetails.FileInfo.StreamDetails.Audio.Item(i).LongLanguage) Then
                                nFileInfo.StreamDetails.Audio.Item(i).Language = tDBElement.MainDetails.FileInfo.StreamDetails.Audio.Item(i).Language
                                nFileInfo.StreamDetails.Audio.Item(i).LongLanguage = tDBElement.MainDetails.FileInfo.StreamDetails.Audio.Item(i).LongLanguage
                            End If
                        Next
                    End If
                End If
                If bLockVideoLanguage Then
                    'sets old language setting if setting is enabled (lock language)
                    'First make sure that there is no completely new video source scanned of the movie --> if so (i.e. more streams) then update!
                    If nFileInfo.StreamDetails.Video.Count = tDBElement.MainDetails.FileInfo.StreamDetails.Video.Count Then
                        For i = 0 To nFileInfo.StreamDetails.Video.Count - 1
                            'only preserve if language tag is filled --> else update!
                            If Not String.IsNullOrEmpty(tDBElement.MainDetails.FileInfo.StreamDetails.Video.Item(i).LongLanguage) Then
                                nFileInfo.StreamDetails.Video.Item(i).Language = tDBElement.MainDetails.FileInfo.StreamDetails.Video.Item(i).Language
                                nFileInfo.StreamDetails.Video.Item(i).LongLanguage = tDBElement.MainDetails.FileInfo.StreamDetails.Video.Item(i).LongLanguage
                            End If
                        Next
                    End If
                End If
                tDBElement.MainDetails.FileInfo = nFileInfo
            End If

            If tDBElement.MainDetails.FileInfo.StreamDetails.VideoSpecified AndAlso Master.eSettings.Movie.DataSettings.DurationForRuntime Then
                Dim tVid As MediaContainers.Video = NFO.GetBestVideo(tDBElement.MainDetails.FileInfo)
                'cocotus 29/02/2014, Added check to only save Runtime in nfo/moviedb if scraped Runtime <> 0! (=Error during Mediainfo Scan)
                If tVid.DurationSpecified AndAlso Not tVid.Duration.Trim = "0" Then
                    tDBElement.MainDetails.Runtime = FormatVideoDurationFromSeconds(tVid.Duration, strRuntimeMask)
                End If
            End If
        End If

        If Not tDBElement.MainDetails.FileInfo.StreamDetailsSpecified Then
            nFileInfo = New MediaContainers.Fileinfo
            nFileInfo = ApplyDefaults(tDBElement)
            If nFileInfo IsNot Nothing Then tDBElement.MainDetails.FileInfo = nFileInfo
        End If

        tDBElement.MainDetails.FileInfo = CleanupFileInfo(tDBElement.MainDetails.FileInfo)
    End Sub

#End Region 'Methods

End Class
