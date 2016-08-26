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
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports NLog

<Serializable()> _
Public Class MediaInfo

#Region "Fields"
    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private Handle As IntPtr
    Private UseAnsi As Boolean

#End Region 'Fields

#Region "Enumerations"

    Public Enum InfoKind As UInteger
        Name
        Text
    End Enum

    Public Enum StreamKind As UInteger
        General
        Visual
        Audio
        Text
    End Enum

#End Region 'Enumerations

#Region "Methods"

    Public Shared Function ApplyDefaults(ByVal ext As String) As MediaContainers.Fileinfo
        Dim fi As New MediaContainers.Fileinfo
        For Each m As Settings.MetadataPerType In Master.eSettings.MovieMetadataPerFileType
            If m.FileType = ext Then
                fi = m.MetaData
                Return fi
            End If
        Next
        Return Nothing
    End Function

    Public Shared Function ApplyTVDefaults(ByVal ext As String) As MediaContainers.Fileinfo
        Dim fi As New MediaContainers.Fileinfo
        For Each m As Settings.MetadataPerType In Master.eSettings.TVMetadataPerFileType
            If m.FileType = ext Then
                fi = m.MetaData
                Return fi
            End If
        Next
        Return Nothing
    End Function

    Public Shared Sub UpdateMediaInfo(ByRef tDBElement As Database.DBElement)
        Try
            Dim nFileInfo = New MediaContainers.Fileinfo

            If Not tDBElement.FileItem.bIsDiscStub AndAlso Master.CanScanDiscImage OrElse Not (tDBElement.FileItem.bIsDiscImage OrElse tDBElement.FileItem.bIsRAR) Then
                Dim MI As New MediaInfo
                MI.GetMediaInfoFromFileItem(tDBElement.FileItem, nFileInfo, False)

                If nFileInfo.StreamDetails.Video.Count > 0 OrElse nFileInfo.StreamDetails.Audio.Count > 0 OrElse nFileInfo.StreamDetails.Subtitle.Count > 0 Then
                    ' overwrite only if it get something from Mediainfo 
                    If Master.eSettings.MovieLockLanguageV Then
                        'sets old language setting if setting is enabled (lock language)
                        'First make sure that there is no completely new video source scanned of the movie --> if so (i.e. more streams) then update!
                        If nFileInfo.StreamDetails.Video.Count = tDBElement.Movie.FileInfo.StreamDetails.Video.Count Then
                            For i = 0 To nFileInfo.StreamDetails.Video.Count - 1
                                'only preserve if language tag is filled --> else update!
                                If Not String.IsNullOrEmpty(tDBElement.Movie.FileInfo.StreamDetails.Video.Item(i).LongLanguage) Then
                                    nFileInfo.StreamDetails.Video.Item(i).Language = tDBElement.Movie.FileInfo.StreamDetails.Video.Item(i).Language
                                    nFileInfo.StreamDetails.Video.Item(i).LongLanguage = tDBElement.Movie.FileInfo.StreamDetails.Video.Item(i).LongLanguage
                                End If
                            Next
                        End If
                    End If
                    If Master.eSettings.MovieLockLanguageA Then
                        'sets old language setting if setting is enabled (lock language)
                        'First make sure that there is no completely new audio source scanned of the movie --> if so (i.e. more streams) then update!
                        If nFileInfo.StreamDetails.Audio.Count = tDBElement.Movie.FileInfo.StreamDetails.Audio.Count Then
                            For i = 0 To nFileInfo.StreamDetails.Audio.Count - 1
                                'only preserve if language tag is filled --> else update!
                                If Not String.IsNullOrEmpty(tDBElement.Movie.FileInfo.StreamDetails.Audio.Item(i).LongLanguage) Then
                                    nFileInfo.StreamDetails.Audio.Item(i).Language = tDBElement.Movie.FileInfo.StreamDetails.Audio.Item(i).Language
                                    nFileInfo.StreamDetails.Audio.Item(i).LongLanguage = tDBElement.Movie.FileInfo.StreamDetails.Audio.Item(i).LongLanguage
                                End If
                            Next
                        End If
                    End If
                    tDBElement.Movie.FileInfo = nFileInfo
                End If
                If tDBElement.Movie.FileInfo.StreamDetails.Video.Count > 0 AndAlso Master.eSettings.MovieScraperUseMDDuration Then
                    Dim tVid As MediaContainers.Video = NFO.GetBestVideo(tDBElement.Movie.FileInfo)
                    'cocotus 29/02/2014, Added check to only save Runtime in nfo/moviedb if scraped Runtime <> 0! (=Error during Mediainfo Scan)
                    If Not String.IsNullOrEmpty(tVid.Duration) AndAlso Not tVid.Duration.Trim = "0" Then
                        tDBElement.Movie.Runtime = FormatDuration(tVid.Duration, Master.eSettings.MovieScraperDurationRuntimeFormat)
                    End If
                End If
                MI = Nothing
            End If

            If tDBElement.Movie.FileInfo.StreamDetails.Video.Count = 0 AndAlso tDBElement.Movie.FileInfo.StreamDetails.Audio.Count = 0 AndAlso tDBElement.Movie.FileInfo.StreamDetails.Subtitle.Count = 0 Then
                nFileInfo = New MediaContainers.Fileinfo
                nFileInfo = ApplyDefaults(Path.GetExtension(tDBElement.FileItem.FirstStackedPath.ToLower))
                If nFileInfo IsNot Nothing Then tDBElement.Movie.FileInfo = nFileInfo
            End If

        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Sub UpdateTVMediaInfo(ByRef tDBElement As Database.DBElement)
        Try
            'DON't clear it out
            'miTV.TVEp.FileInfo = New MediaInfo.Fileinfo
            Dim tinfo = New MediaContainers.Fileinfo

            Dim pExt As String = Path.GetExtension(tDBElement.FileItem.FirstStackedPath).ToLower
            If Master.CanScanDiscImage OrElse Not (pExt = ".iso" OrElse
               pExt = ".img" OrElse pExt = ".bin" OrElse pExt = ".cue" OrElse pExt = ".nrg" OrElse pExt = ".rar") Then
                Dim MI As New MediaInfo
                'MI.GetMIFromPath(miTV.TVEp.FileInfo, miTV.Filename, True)
                MI.GetMediaInfoFromFileItem(tDBElement.FileItem, tinfo, True)
                If tinfo.StreamDetails.Video.Count > 0 OrElse tinfo.StreamDetails.Audio.Count > 0 OrElse tinfo.StreamDetails.Subtitle.Count > 0 Then
                    ' overwrite only if it get something from Mediainfo 

                    If Master.eSettings.TVLockEpisodeLanguageV Then
                        Try
                            'sets old language setting if setting is enabled (lock language)
                            'First make sure that there is no completely new video source scanned of the movie --> if so (i.e. more streams) then update!
                            If tinfo.StreamDetails.Video.Count = tDBElement.TVEpisode.FileInfo.StreamDetails.Video.Count Then
                                For i = 0 To tinfo.StreamDetails.Video.Count - 1
                                    'only preserve if language tag is filled --> else update!
                                    If Not String.IsNullOrEmpty(tDBElement.TVEpisode.FileInfo.StreamDetails.Video.Item(i).LongLanguage) Then
                                        tinfo.StreamDetails.Video.Item(i).Language = tDBElement.TVEpisode.FileInfo.StreamDetails.Video.Item(i).Language
                                        tinfo.StreamDetails.Video.Item(i).LongLanguage = tDBElement.TVEpisode.FileInfo.StreamDetails.Video.Item(i).LongLanguage
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            logger.Error(ex, New StackFrame().GetMethod().Name)
                        End Try
                    End If
                    If Master.eSettings.TVLockEpisodeLanguageA Then
                        Try
                            'sets old language setting if setting is enabled (lock language)
                            'First make sure that there is no completely new audio source scanned of the movie --> if so (i.e. more streams) then update!
                            If tinfo.StreamDetails.Audio.Count = tDBElement.TVEpisode.FileInfo.StreamDetails.Audio.Count Then
                                For i = 0 To tinfo.StreamDetails.Audio.Count - 1
                                    'only preserve if language tag is filled --> else update!
                                    If Not String.IsNullOrEmpty(tDBElement.TVEpisode.FileInfo.StreamDetails.Audio.Item(i).LongLanguage) Then
                                        tinfo.StreamDetails.Audio.Item(i).Language = tDBElement.TVEpisode.FileInfo.StreamDetails.Audio.Item(i).Language
                                        tinfo.StreamDetails.Audio.Item(i).LongLanguage = tDBElement.TVEpisode.FileInfo.StreamDetails.Audio.Item(i).LongLanguage
                                    End If
                                Next
                            End If

                        Catch ex As Exception
                            logger.Error(ex, New StackFrame().GetMethod().Name)
                        End Try
                    End If
                    tDBElement.TVEpisode.FileInfo = tinfo
                End If
                If tDBElement.TVEpisode.FileInfo.StreamDetails.Video.Count > 0 AndAlso Master.eSettings.TVScraperUseMDDuration Then
                    Dim tVid As MediaContainers.Video = NFO.GetBestVideo(tDBElement.TVEpisode.FileInfo)
                    'cocotus 29/02/2014, Added check to only save Runtime in nfo/moviedb if scraped Runtime <> 0! (=Error during Mediainfo Scan)
                    If Not String.IsNullOrEmpty(tVid.Duration) AndAlso Not tVid.Duration.Trim = "0" Then
                        tDBElement.TVEpisode.Runtime = MediaInfo.FormatDuration(tVid.Duration, Master.eSettings.TVScraperDurationRuntimeFormat)
                    End If
                End If
            End If
            If tDBElement.TVEpisode.FileInfo.StreamDetails.Video.Count = 0 AndAlso tDBElement.TVEpisode.FileInfo.StreamDetails.Audio.Count = 0 AndAlso tDBElement.TVEpisode.FileInfo.StreamDetails.Subtitle.Count = 0 Then
                Dim _mi As MediaContainers.Fileinfo
                _mi = ApplyTVDefaults(pExt)
                If Not _mi Is Nothing Then tDBElement.TVEpisode.FileInfo = _mi
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Sub GetMediaInfoFromFileItem(ByVal tFileItem As FileItem, ByRef fiInfo As MediaContainers.Fileinfo, ByVal isTVEpisode As Boolean)
        If Not String.IsNullOrEmpty(tFileItem.Path) AndAlso File.Exists(tFileItem.FirstStackedPath) Then

            fiInfo = ScanMI(tFileItem)




            Dim sExt As String = Path.GetExtension(tFileItem.FirstStackedPath).ToLower
            Dim fiOut As New MediaContainers.Fileinfo
            Dim miVideo As New MediaContainers.Video
            Dim miAudio As New MediaContainers.Audio
            Dim miSubtitle As New MediaContainers.Subtitle
            Dim AudioStreams As Integer
            Dim SubtitleStreams As Integer
            Dim aLang As String = String.Empty
            Dim sLang As String = String.Empty
            Dim cDVD As New DVD

            Dim ifoVideo(2) As String
            Dim ifoAudio(2) As String

            If Master.eSettings.MovieScraperMetaDataIFOScan AndAlso tFileItem.bIsVideoTS AndAlso cDVD.fctOpenIFOFile(tFileItem.FirstStackedPath) Then
                ifoVideo = cDVD.GetIFOVideo
                Dim vRes() As String = ifoVideo(1).Split(Convert.ToChar("x"))
                miVideo.Width = vRes(0)
                miVideo.Height = vRes(1)
                miVideo.Codec = ifoVideo(0)
                miVideo.Duration = cDVD.GetProgramChainPlayBackTime(1)
                miVideo.Aspect = ifoVideo(2)

                With miVideo
                    If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Duration) OrElse Not String.IsNullOrEmpty(.Aspect) OrElse
                        Not String.IsNullOrEmpty(.Height) OrElse Not String.IsNullOrEmpty(.Width) Then
                        fiOut.StreamDetails.Video.Add(miVideo)
                    End If
                End With

                AudioStreams = cDVD.GetIFOAudioNumberOfTracks
                For a As Integer = 1 To AudioStreams
                    miAudio = New MediaContainers.Audio
                    ifoAudio = cDVD.GetIFOAudio(a)
                    miAudio.Codec = ifoAudio(0)
                    miAudio.Channels = ifoAudio(2)
                    aLang = ifoAudio(1)
                    If Not String.IsNullOrEmpty(aLang) Then
                        miAudio.LongLanguage = aLang
                        If Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage) <> "" Then
                            miAudio.Language = Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)
                        End If
                    End If
                    With miAudio
                        If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Channels) OrElse Not String.IsNullOrEmpty(.Language) Then
                            fiOut.StreamDetails.Audio.Add(miAudio)
                        End If
                    End With
                Next

                SubtitleStreams = cDVD.GetIFOSubPicNumberOf
                For s As Integer = 1 To SubtitleStreams
                    miSubtitle = New MediaContainers.Subtitle
                    sLang = cDVD.GetIFOSubPic(s)
                    If Not String.IsNullOrEmpty(sLang) Then
                        miSubtitle.LongLanguage = sLang
                        If Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage) <> "" Then
                            miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                        End If
                        If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                            'miSubtitle.SubsForced = Not supported(?)
                            miSubtitle.SubsType = "Embedded"
                            fiOut.StreamDetails.Subtitle.Add(miSubtitle)
                        End If
                    End If
                Next

                cDVD.Close()
                cDVD = Nothing

                fiInfo = fiOut

            ElseIf tFileItem.bIsStack Then
                Dim oFile As String = tFileItem.StackedPath
                Dim sFile As New List(Of String)
                Dim bIsVTS As Boolean = False

                If sExt = ".ifo" OrElse sExt = ".bup" OrElse sExt = ".vob" Then
                    bIsVTS = True
                End If

                If bIsVTS Then
                    Try
                        sFile.AddRange(Directory.GetFiles(Directory.GetParent(tFileItem.FirstStackedPath).FullName, "VTS*.VOB"))
                    Catch
                    End Try
                ElseIf sExt = ".m2ts" Then
                    Try
                        sFile.AddRange(Directory.GetFiles(Directory.GetParent(tFileItem.FirstStackedPath).FullName, "*.m2ts"))
                    Catch
                    End Try
                Else
                    Try
                        sFile.AddRange(Directory.GetFiles(Directory.GetParent(tFileItem.FirstStackedPath).FullName, String.Concat(Path.GetFileNameWithoutExtension(tFileItem.StackedPath), "*")))
                    Catch
                    End Try
                End If

                Dim TotalDur As Integer = 0
                Dim tInfo As New MediaContainers.Fileinfo
                Dim tVideo As New MediaContainers.Video
                Dim tAudio As New MediaContainers.Audio

                miVideo.Width = "0"
                miAudio.Channels = "0"

                For Each File As String In sFile
                    'make sure the file is actually part of the stack
                    'handles movie.cd1.ext, movie.cd2.ext and movie.extras.ext
                    'disregards movie.extras.ext in this case
                    If bIsVTS OrElse (oFile = tFileItem.StackedPath) Then
                        tInfo = ScanMI(tFileItem)

                        tVideo = NFO.GetBestVideo(tInfo)
                        tAudio = NFO.GetBestAudio(tInfo, isTVEpisode)

                        If String.IsNullOrEmpty(miVideo.Codec) OrElse Not String.IsNullOrEmpty(tVideo.Codec) Then
                            If Not String.IsNullOrEmpty(tVideo.Width) AndAlso Convert.ToInt32(tVideo.Width) >= Convert.ToInt32(miVideo.Width) Then
                                miVideo = tVideo
                            End If
                        End If

                        If String.IsNullOrEmpty(miAudio.Codec) OrElse Not String.IsNullOrEmpty(tAudio.Codec) Then
                            If Not String.IsNullOrEmpty(tAudio.Channels) AndAlso Convert.ToInt32(tAudio.Channels) >= Convert.ToInt32(miAudio.Channels) Then
                                miAudio = tAudio
                            End If
                        End If

                        If Not String.IsNullOrEmpty(tVideo.Duration) Then TotalDur += Convert.ToInt32(DurationToSeconds(tVideo.Duration, False))

                        For Each sSub As MediaContainers.Subtitle In tInfo.StreamDetails.Subtitle
                            If Not fiOut.StreamDetails.Subtitle.Contains(sSub) Then
                                fiOut.StreamDetails.Subtitle.Add(sSub)
                            End If
                        Next
                    End If
                Next

                fiOut.StreamDetails.Video.Add(miVideo)
                fiOut.StreamDetails.Audio.Add(miAudio)
                fiOut.StreamDetails.Video(0).Duration = DurationToSeconds(TotalDur.ToString, True)

                fiInfo = fiOut
            Else
                fiInfo = ScanMI(tFileItem)
            End If

            'finally go through all the video streams and reformat the duration
            'we do this afterwards because of scanning mediainfo from stacked files... we need total
            'duration so we need to keep a consistent duration format while scanning
            'it's easier to format at the end so we don't need to bother with creating a generic
            'conversion routine
            If fiInfo.StreamDetails IsNot Nothing AndAlso fiInfo.StreamDetails.Video.Count > 0 Then
                For Each tVid As MediaContainers.Video In fiInfo.StreamDetails.Video
                    tVid.Duration = DurationToSeconds(tVid.Duration, False)
                Next
            End If
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Function MediaInfoA_Get(ByVal Handle As IntPtr, ByVal StreamKind As UIntPtr, ByVal StreamNumber As UIntPtr, ByVal Parameter As IntPtr, ByVal KindOfInfo As UIntPtr, ByVal KindOfSearch As UIntPtr) As IntPtr
    End Function

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Function MediaInfoA_Open(ByVal Handle As IntPtr, ByVal FileName As IntPtr) As UIntPtr
    End Function

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Sub MediaInfo_Close(ByVal Handle As IntPtr)
    End Sub

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Function MediaInfo_Count_Get(ByVal Handle As IntPtr, ByVal StreamKind As UIntPtr, ByVal StreamNumber As IntPtr) As Integer
    End Function

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Sub MediaInfo_Delete(ByVal Handle As IntPtr)
    End Sub

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Function MediaInfo_Get(ByVal Handle As IntPtr, ByVal StreamKind As UIntPtr, ByVal StreamNumber As UIntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal Parameter As String, ByVal KindOfInfo As UIntPtr, ByVal KindOfSearch As UIntPtr) As IntPtr
    End Function

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Function MediaInfo_New() As IntPtr
    End Function

    <DllImport("Bin\MediaInfo.DLL")>
    Private Shared Function MediaInfo_Open(ByVal Handle As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal FileName As String) As UIntPtr
    End Function

    Private Sub Close()
        MediaInfo_Close(Handle)
        MediaInfo_Delete(Handle)
        Handle = Nothing
    End Sub

    Private Function ConvertAFormat(ByVal sCodecID As String, ByVal sFormat As String, ByVal sCodecHint As String, ByVal sProfile As String) As String
        Dim tCodec As String = String.Empty
        If sFormat.ToLower.Contains("dts") AndAlso (sProfile.ToLower = "hra / core" OrElse sProfile.ToLower = "ma / core") Then
            tCodec = sProfile
        ElseIf Not String.IsNullOrEmpty(sCodecID) AndAlso Not Integer.TryParse(sCodecID, 0) AndAlso Not sCodecID.ToLower.Contains("a_pcm") AndAlso Not sCodecID.Contains("00001000-0000-0100-8000-00AA00389B71") Then
            tCodec = sCodecID
        ElseIf Not String.IsNullOrEmpty(sCodecHint) Then
            tCodec = sCodecHint
        ElseIf sFormat.ToLower.Contains("mpeg") AndAlso Not String.IsNullOrEmpty(sProfile) Then
            tCodec = String.Concat("mp", sProfile.Replace("Layer", String.Empty).Trim).Trim
        ElseIf Not String.IsNullOrEmpty(sFormat) Then
            tCodec = sFormat
        End If

        If Not String.IsNullOrEmpty(tCodec) Then
            Dim myconversions As New List(Of AdvancedSettingsComplexSettingsTableItem)
            myconversions = AdvancedSettings.GetComplexSetting("AudioFormatConverts")
            If Not myconversions Is Nothing Then
                For Each k In myconversions
                    If tCodec.ToLower = k.Name.ToLower Then
                        Return k.Value
                    End If
                Next
                Return tCodec
            Else
                Return tCodec
            End If
        Else
            Return String.Empty
        End If
    End Function

    Private Function ConvertVFormat(ByVal sCodecID As String, ByVal sFormat As String, ByVal sVersion As String) As String
        Dim tCodec As String = String.Empty

        If Not String.IsNullOrEmpty(sCodecID) AndAlso Not Integer.TryParse(sCodecID, 0) Then
            tCodec = sCodecID
        ElseIf sFormat.ToLower.Contains("mpeg") AndAlso Not String.IsNullOrEmpty(sVersion) Then
            tCodec = String.Concat("mpeg", sVersion.Replace("Version", String.Empty).Trim, "video").Trim
        ElseIf Not String.IsNullOrEmpty(sFormat) Then
            tCodec = sFormat
        End If

        If Not String.IsNullOrEmpty(tCodec) Then
            Dim myconversions As New List(Of AdvancedSettingsComplexSettingsTableItem)
            myconversions = AdvancedSettings.GetComplexSetting("VideoFormatConverts")
            If Not myconversions Is Nothing Then
                For Each k In myconversions
                    If tCodec.ToLower = k.Name.ToLower Then
                        Return k.Value
                    End If
                Next
                Return tCodec
            Else
                Return tCodec
            End If
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function ConvertVStereoMode(ByVal sFormat As String) As String
        If Not String.IsNullOrEmpty(sFormat) Then
            Dim tFormat As String = String.Empty
            Select Case sFormat.ToLower
                Case "side by side (left eye first)"
                    tFormat = "left_right"
                Case "top-bottom (right eye first)"
                    tFormat = "bottom_top"
                Case "top-bottom (left eye first)"
                    tFormat = "bottom_top"
                Case "checkboard (right eye first)"
                    tFormat = "checkerboard_rl"
                Case "checkboard (left eye first)"
                    tFormat = "checkerboard_lr"
                Case "row interleaved (right eye first)"
                    tFormat = "row_interleaved_rl"
                Case "row interleaved (left eye first)"
                    tFormat = "row_interleaved_lr"
                Case "column interleaved (right eye first)"
                    tFormat = "col_interleaved_rl"
                Case "column interleaved (left eye first)"
                    tFormat = "col_interleaved_lr"
                Case "anaglyph (cyan/red)"
                    tFormat = "anaglyph_cyan_red"
                Case "side by side (right eye first)"
                    tFormat = "right_left"
                Case "anaglyph (green/magenta)"
                    tFormat = "anaglyph_green_magenta"
                Case "both eyes laced in one block (left eye first)"
                    tFormat = "block_lr"
                Case "both eyes laced in one block (right eye first)"
                    tFormat = "block_rl"
            End Select

            Return tFormat
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function ConvertVStereoToShort(ByVal sFormat As String) As String
        If Not String.IsNullOrEmpty(sFormat) Then
            Dim tFormat As String = String.Empty
            Select Case sFormat.ToLower
                Case "bottom_top"
                    tFormat = "tab"
                Case "left_right", "right_left"
                    tFormat = "sbs"
                Case Else
                    tFormat = "unknown"
            End Select

            Return tFormat
        Else
            Return String.Empty
        End If
    End Function

    Private Function Count_Get(ByVal StreamKind As StreamKind, Optional ByVal StreamNumber As UInteger = UInteger.MaxValue) As Integer
        If StreamNumber = UInteger.MaxValue Then
            Return MediaInfo_Count_Get(Handle, CType(StreamKind, UIntPtr), CType(-1, IntPtr))
        Else
            Return MediaInfo_Count_Get(Handle, CType(StreamKind, UIntPtr), CType(StreamNumber, IntPtr))
        End If
    End Function

    Public Shared Function DurationToSeconds(ByVal Duration As String, ByVal Reverse As Boolean) As String
        If Not String.IsNullOrEmpty(Duration) Then
            If Reverse Then
                Dim ts As New TimeSpan(0, 0, Convert.ToInt32(Duration))
                Return String.Format("{0}h {1}min {2}s", ts.Hours, ts.Minutes, ts.Seconds)
            Else
                Dim sDuration As Match = Regex.Match(Duration, "(([0-9]+)h)?\s?(([0-9]+)mi?n)?\s?(([0-9]+)s)?")
                Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
                Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
                Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)
                Return ((sHour * 60 * 60) + (sMin * 60) + sSec).ToString
            End If
        End If
        Return "0"
    End Function

    Private Function Get_(ByVal StreamKind As StreamKind, ByVal StreamNumber As Integer, ByVal Parameter As String, Optional ByVal KindOfInfo As InfoKind = InfoKind.Text, Optional ByVal KindOfSearch As InfoKind = InfoKind.Name) As String
        If UseAnsi Then
            Dim Parameter_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(Parameter)
            Dim ToReturn As String = Marshal.PtrToStringAnsi(MediaInfoA_Get(Handle, CType(StreamKind, UIntPtr), CType(StreamNumber, UIntPtr), Parameter_Ptr, CType(KindOfInfo, UIntPtr), CType(KindOfSearch, UIntPtr)))
            Marshal.FreeHGlobal(Parameter_Ptr)
            Return ToReturn
        Else
            Return Marshal.PtrToStringUni(MediaInfo_Get(Handle, CType(StreamKind, UIntPtr), CType(StreamNumber, UIntPtr), Parameter, CType(KindOfInfo, UIntPtr), CType(KindOfSearch, UIntPtr)))
        End If
    End Function

    Private Sub Open(ByVal FileName As String)
        If UseAnsi Then
            Dim FileName_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(FileName)
            MediaInfoA_Open(Handle, FileName_Ptr)
            Marshal.FreeHGlobal(FileName_Ptr)
        Else
            MediaInfo_Open(Handle, FileName)
        End If
    End Sub

    ''' <summary>
    ''' Use MediaInfo.dll Scan to get subtitle and audio Stream information of file (used for scanning IFO files)
    ''' </summary>
    ''' <returns>Mediainfo-Scanresults as MediainfoFileInfoObject</returns>
    Private Function ScanLanguage(ByVal IFOPath As String) As MediaContainers.Fileinfo
        'The whole content of this function is a strip of of the "big" ScanMI function. It is used to scan IFO files of VIDEO_TS media to retrieve language info
        Dim fiOut As New MediaContainers.Fileinfo

        Handle = MediaInfo_New()

        If Master.isWindows Then
            UseAnsi = False
        Else
            UseAnsi = True
        End If

        Open(IFOPath)


        'Audio Scan
        Dim AudioStreams As Integer
        AudioStreams = Count_Get(StreamKind.Audio)
        Dim miAudio As New MediaContainers.Audio
        Dim aLang As String = String.Empty
        Dim a_Profile As String = String.Empty

        For a As Integer = 0 To AudioStreams - 1
            miAudio = New MediaContainers.Audio
            miAudio.Codec = ConvertAFormat(Get_(StreamKind.Audio, a, "CodecID"), Get_(StreamKind.Audio, a, "Format"),
                                           Get_(StreamKind.Audio, a, "CodecID/Hint"), Get_(StreamKind.Audio, a, "Format_Profile"))
            miAudio.Channels = FormatAudioChannel(Get_(StreamKind.Audio, a, "Channel(s)"))

            'cocotus, 2013/02 Added support for new MediaInfo-fields
            'Audio-Bitrate
            miAudio.Bitrate = FormatBitrate(Get_(StreamKind.Audio, a, "BitRate/String"))
            'cocotus end

            aLang = Get_(StreamKind.Audio, a, "Language/String")
            If Not String.IsNullOrEmpty(aLang) Then
                miAudio.LongLanguage = aLang
                If Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage) <> "" Then
                    miAudio.Language = Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)
                End If
            End If
            fiOut.StreamDetails.Audio.Add(miAudio)
        Next

        'Subtitle Scan
        Dim SubtitleStreams As Integer
        SubtitleStreams = Count_Get(StreamKind.Text)
        Dim miSubtitle As New MediaContainers.Subtitle

        Dim sLang As String = String.Empty
        For s As Integer = 0 To SubtitleStreams - 1
            miSubtitle = New MediaContainers.Subtitle
            sLang = Get_(StreamKind.Text, s, "Language/String")
            If Not String.IsNullOrEmpty(sLang) Then
                miSubtitle.LongLanguage = sLang
                If Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage) <> "" Then
                    miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                End If
            End If
            If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                miSubtitle.SubsForced = FormatBoolean(Get_(StreamKind.Text, s, "Forced/String"))
                miSubtitle.SubsType = "Embedded"
                fiOut.StreamDetails.Subtitle.Add(miSubtitle)
            End If
        Next

        'Video Scan
        Dim miVideo As New MediaContainers.Video
        Dim VideoStreams As Integer
        VideoStreams = Count_Get(StreamKind.Visual)
        For v As Integer = 0 To VideoStreams - 1
            miVideo = New MediaContainers.Video
            'cocotus, It's possible that duration returns empty when retrieved from videostream data - so instead use "General" section of MediaInfo.dll to read duration (is always filled!)
            'More here: http://forum.xbmc.org/showthread.php?tid=169900 
            miVideo.Duration = Get_(StreamKind.Visual, v, "Duration/String1")
            If miVideo.Duration = String.Empty Then
                miVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
            End If
            fiOut.StreamDetails.Video.Add(miVideo)
        Next


        Close()

        Return fiOut
    End Function

    ''' <summary>
    ''' Use MediaInfo to get/scan subtitle, audio Stream and video information of videofile
    ''' </summary>
    ''' <returns>Mediainfo-Scanresults as MediainfoFileInfoObject</returns>
    Private Function ScanMI(ByVal tFileItem As FileItem) As MediaContainers.Fileinfo
        Dim fiOut As New MediaContainers.Fileinfo
        Dim fiIFO As New MediaContainers.Fileinfo

        For Each nFilename In tFileItem.PathList
            If File.Exists(nFilename) Then
                Dim miVideo As New MediaContainers.Video
                Dim miAudio As New MediaContainers.Audio
                Dim miSubtitle As New MediaContainers.Subtitle
                Dim VideoStreams As Integer
                Dim AudioStreams As Integer
                Dim SubtitleStreams As Integer
                Dim vLang As String = String.Empty
                Dim aLang As String = String.Empty
                Dim sLang As String = String.Empty
                Dim a_Profile As String = String.Empty
                Dim alternativeIFOFile As String = String.Empty
                Dim strCommandUnmount As String = String.Empty

                'New ISO Handling -> Use either DAEMON Tools or VitualCloneDrive to mount ISO!
                If tFileItem.bIsDiscImage OrElse tFileItem.bIsBDMV OrElse tFileItem.bIsVideoTS Then

                    'ISO-File Scanning using either DAIMON Tools / VCDMount.exe to mount and read file!
                    If tFileItem.bIsDiscImage Then

                        Dim driveletter As String = Master.eSettings.GeneralDaemonDrive ' i.e. "F"
                        'Toolpath either VCDMOUNT.exe or DTLite.exe!
                        Dim strToolPath As String = Master.eSettings.GeneralDaemonPath

                        'Now only use DAEMON Tools to mount ISO if installed on user system
                        If Not String.IsNullOrEmpty(driveletter) AndAlso Not String.IsNullOrEmpty(strToolPath) Then

                            'Either DAEMONToolsLite or VirtualCloneDrive (http://www.slysoft.com/en/virtual-clonedrive.html)
                            If strToolPath.ToLower.Contains("vcdmount") Then
                                'Unmount, i.e "C:\Program Files\Elaborate Bytes\VirtualCloneDrive\VCDMount.exe" /u
                                strCommandUnmount = String.Concat("/u")
                                Functions.Run_Process(strToolPath, strCommandUnmount, False, True)
                                'Mount
                                'Mount ISO on virtual drive, i.e c:\Program Files (x86)\Elaborate Bytes\VirtualCloneDrive\vcdmount.exe U:\isotest\test2iso.ISO
                                Functions.Run_Process(strToolPath, """" & nFilename & """", False, True)

                                'Toolpath doesn't contain vcdmount.exe -> assume daemon tools with DS type drive!
                            Else
                                'Unmount
                                strCommandUnmount = "-unmount dt, 0"
                                Functions.Run_Process(strToolPath, strCommandUnmount, False, True)
                                'Mount
                                'Mount ISO on Daemon Tools (Lite), i.e. C:\Program Files\DAEMON Tools Lite\DTAgent.exe -mount dt, 0, "U:\isotest\test2iso.ISO"
                                Functions.Run_Process(strToolPath, String.Format("-mount dt, 0, ""{0}""", nFilename), False, True)
                            End If

                            'now check if it's bluray or dvd image/VIDEO_TS/BMDV Folder-Scanning!
                            If Directory.Exists(String.Concat(driveletter, ":\VIDEO_TS")) Then
                                nFilename = String.Concat(driveletter, ":\VIDEO_TS")
                                SetMediaInfoScanPaths(nFilename, fiIFO, alternativeIFOFile, True)
                                'get foldersize information
                            ElseIf Directory.Exists(driveletter & ":\BDMV\STREAM") Then
                                nFilename = driveletter & ":\BDMV\STREAM"
                                SetMediaInfoScanPaths(nFilename, fiIFO, alternativeIFOFile, True)
                            End If
                        End If

                        'VIDEO_TS/BMDV Folder-Scanning!
                    Else
                        If Directory.Exists(Directory.GetParent(nFilename).FullName) Then
                            SetMediaInfoScanPaths(nFilename, fiIFO, alternativeIFOFile, False)
                        End If
                    End If
                End If

                If Not nFilename = String.Empty Then
                    Handle = MediaInfo_New()

                    If Master.isWindows Then
                        UseAnsi = False
                    Else
                        UseAnsi = True
                    End If

                    Open(nFilename)

                    VideoStreams = Count_Get(StreamKind.Visual)
                    AudioStreams = Count_Get(StreamKind.Audio)
                    SubtitleStreams = Count_Get(StreamKind.Text)

                    '2014/07/05 Fix for VIDEO_TS scanning: Use second largest (=alternativeIFOFile) IFO File if largest File doesn't contain needed information (=duration)! (rare case!)
                    If nFilename.ToUpper.Contains("VIDEO_TS") Then
                        miVideo = New MediaContainers.Video
                        'IFO Scan results (used when scanning VIDEO_TS files)
                        If fiIFO.StreamDetails.Video.Count > 0 Then
                            If Not String.IsNullOrEmpty(fiIFO.StreamDetails.Video(0).Duration) Then
                                miVideo.Duration = fiIFO.StreamDetails.Video(0).Duration
                            Else
                                'cocotus, It's possible that duration returns empty when retrieved from videostream data - so instead use "General" section of MediaInfo.dll to read duration (is always filled!)
                                'More here: http://forum.xbmc.org/showthread.php?tid=169900 
                                miVideo.Duration = Get_(StreamKind.Visual, 0, "Duration/String1")
                                If miVideo.Duration = String.Empty Then
                                    miVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
                                End If
                            End If
                        Else
                            'cocotus, It's possible that duration returns empty when retrieved from videostream data - so instead use "General" section of MediaInfo.dll to read duration (is always filled!)
                            'More here: http://forum.xbmc.org/showthread.php?tid=169900 
                            miVideo.Duration = Get_(StreamKind.Visual, 0, "Duration/String1")
                            If miVideo.Duration = String.Empty Then
                                miVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
                            End If
                        End If
                        'if ms instead of hours or minutes than wrong IFO!
                        If miVideo.Duration.ToUpper.ToString.Contains("ms") Then
                            fiIFO = Nothing
                            fiIFO = ScanLanguage(alternativeIFOFile)
                        End If
                    End If

                End If

                For v As Integer = 0 To VideoStreams - 1
                    miVideo = New MediaContainers.Video
                    'cocotus, 2013/02 Added support for new MediaInfo-fields
                    'Video-Bitrate
                    miVideo.Bitrate = FormatBitrate(Get_(StreamKind.Visual, v, "BitRate/String"))
                    'MultiViewCount (Support for 3D Movie, If > 1 -> 3D Movie)
                    miVideo.MultiViewCount = Get_(StreamKind.Visual, v, "MultiView_Count")
                    'MultiViewLayout (http://matroska.org/technical/specs/index.html#StereoMode)
                    miVideo.MultiViewLayout = Get_(StreamKind.Visual, v, "MultiView_Layout")
                    'Encoder-settings
                    'miVideo.EncodedSettings = Me.Get_(StreamKind.Visual, v, "Encoded_Library_Settings")
                    'cocotus end
                    miVideo.StereoMode = ConvertVStereoMode(miVideo.MultiViewLayout)

                    miVideo.Width = Get_(StreamKind.Visual, v, "Width")
                    miVideo.Height = Get_(StreamKind.Visual, v, "Height")
                    miVideo.Codec = ConvertVFormat(Get_(StreamKind.Visual, v, "CodecID"), Get_(StreamKind.Visual, v, "Format"),
                                                       Get_(StreamKind.Visual, v, "Format_Version"))

                    'IFO Scan results (used when scanning VIDEO_TS files)
                    If fiIFO.StreamDetails.Video.Count > 0 Then
                        If Not String.IsNullOrEmpty(fiIFO.StreamDetails.Video(v).Duration) Then
                            miVideo.Duration = fiIFO.StreamDetails.Video(v).Duration
                        Else
                            'cocotus, It's possible that duration returns empty when retrieved from videostream data - so instead use "General" section of MediaInfo.dll to read duration (is always filled!)
                            'More here: http://forum.xbmc.org/showthread.php?tid=169900 
                            miVideo.Duration = Get_(StreamKind.Visual, v, "Duration/String1")
                            If miVideo.Duration = String.Empty Then
                                miVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
                            End If
                        End If
                    Else
                        'cocotus, It's possible that duration returns empty when retrieved from videostream data - so instead use "General" section of MediaInfo.dll to read duration (is always filled!)
                        'More here: http://forum.xbmc.org/showthread.php?tid=169900 
                        miVideo.Duration = Get_(StreamKind.Visual, v, "Duration/String1")
                        If miVideo.Duration = String.Empty Then
                            miVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
                        End If
                    End If


                    miVideo.Aspect = Get_(StreamKind.Visual, v, "DisplayAspectRatio")
                    miVideo.Scantype = Get_(StreamKind.Visual, v, "ScanType")

                    vLang = Get_(StreamKind.Visual, v, "Language/String")
                    If Not String.IsNullOrEmpty(vLang) Then
                        miVideo.LongLanguage = vLang
                        If Localization.ISOLangGetCode3ByLang(miVideo.LongLanguage) <> "" Then
                            miVideo.Language = Localization.ISOLangGetCode3ByLang(miVideo.LongLanguage)
                        End If
                    End If

                    If tFileItem.bIsDiscImage OrElse tFileItem.bIsBDMV OrElse tFileItem.bIsVideoTS Then
                        miVideo.Filesize = FileUtils.Common.GetFolderSize(Directory.GetParent(nFilename).FullName)
                    Else
                        miVideo.Filesize = If(Double.TryParse(Get_(StreamKind.General, 0, "FileSize"), 0), CDbl(Get_(StreamKind.General, 0, "FileSize")), 0)
                    End If

                    'With miVideo
                    '    If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Duration) OrElse Not String.IsNullOrEmpty(.Aspect) OrElse _
                    '    Not String.IsNullOrEmpty(.Height) OrElse Not String.IsNullOrEmpty(.Width) OrElse Not String.IsNullOrEmpty(.Scantype) Then
                    '        fiOut.StreamDetails.Video.Add(miVideo)
                    '    End If
                    'End With
                    fiOut.StreamDetails.Video.Add(miVideo)
                Next


                For a As Integer = 0 To AudioStreams - 1
                    miAudio = New MediaContainers.Audio
                    miAudio.Codec = ConvertAFormat(Get_(StreamKind.Audio, a, "CodecID"), Get_(StreamKind.Audio, a, "Format"),
                                                       Get_(StreamKind.Audio, a, "CodecID/Hint"), Get_(StreamKind.Audio, a, "Format_Profile"))
                    miAudio.Channels = FormatAudioChannel(Get_(StreamKind.Audio, a, "Channel(s)"))

                    'cocotus, 2013/02 Added support for new MediaInfo-fields
                    'Audio-Bitrate
                    miAudio.Bitrate = FormatBitrate(Get_(StreamKind.Audio, a, "BitRate/String"))
                    'cocotus end

                    aLang = Get_(StreamKind.Audio, a, "Language/String")
                    If Not String.IsNullOrEmpty(aLang) Then
                        miAudio.LongLanguage = aLang
                        If Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage) <> "" Then
                            miAudio.Language = Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)
                        End If
                        'IFO Scan results (used when scanning VIDEO_TS files)
                    ElseIf fiIFO.StreamDetails.Audio.Count > 0 Then
                        If Not String.IsNullOrEmpty(fiIFO.StreamDetails.Audio(a).LongLanguage) Then
                            miAudio.LongLanguage = fiIFO.StreamDetails.Audio(a).LongLanguage
                            miAudio.Language = fiIFO.StreamDetails.Audio(a).Language
                        End If
                    End If

                    'With miAudio
                    '    If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Channels) OrElse Not String.IsNullOrEmpty(.Language) Then
                    '        fiOut.StreamDetails.Audio.Add(miAudio)
                    '    End If
                    'End With
                    fiOut.StreamDetails.Audio.Add(miAudio)
                Next


                For s As Integer = 0 To SubtitleStreams - 1

                    miSubtitle = New MediaContainers.Subtitle

                    sLang = Get_(StreamKind.Text, s, "Language/String")
                    If Not String.IsNullOrEmpty(sLang) Then
                        miSubtitle.LongLanguage = sLang
                        If Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage) <> "" Then
                            miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                        End If
                        miSubtitle.SubsForced = True

                        'IFO Scan results (used when scanning VIDEO_TS files)
                    ElseIf fiIFO.StreamDetails.Subtitle.Count > 0 Then
                        If Not String.IsNullOrEmpty(fiIFO.StreamDetails.Subtitle(s).LongLanguage) Then
                            miSubtitle.LongLanguage = fiIFO.StreamDetails.Subtitle(s).LongLanguage
                            miSubtitle.Language = fiIFO.StreamDetails.Subtitle(s).Language
                        End If
                    End If

                    If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                        miSubtitle.SubsForced = FormatBoolean(Get_(StreamKind.Text, s, "Forced/String"))
                        miSubtitle.SubsType = "Embedded"
                        fiOut.StreamDetails.Subtitle.Add(miSubtitle)
                    End If
                Next

                If Not String.IsNullOrEmpty(strCommandUnmount) Then
                    Functions.Run_Process(Master.eSettings.GeneralDaemonPath, strCommandUnmount, False, True)
                End If

                Close()
            Else
                logger.Error(String.Format("File not found: {0}", nFilename))
            End If
        Next

        Return fiOut
    End Function

    Public Shared Function FormatBitrate(ByVal rawbitrate As String) As String
        'now consider bitrate number and calculate all values in KB instead of MB/KB
        If rawbitrate.ToUpper.IndexOf(" K") > 0 Then
            rawbitrate = rawbitrate.Substring(0, rawbitrate.ToUpper.IndexOf(" K"))
            Dim mystring As String = ""
            'use regex to get rid of all letters(if that ever happens just in case) and also remove spaces
            mystring = Regex.Replace(rawbitrate, "[^.0-9]", "").Trim
            rawbitrate = mystring
        ElseIf rawbitrate.ToUpper.IndexOf(" M") > 0 Then
            'can happen if video is ripped from bluray
            rawbitrate = rawbitrate.Substring(0, rawbitrate.ToUpper.IndexOf(" M"))
            Dim mystring As String = ""
            'use regex to get rid of all letters(if that ever happens just in case) and also remove spaces
            mystring = Regex.Replace(rawbitrate, "[^.0-9]", "").Trim
            Try
                rawbitrate = (CDbl(mystring) * 100).ToString
            Catch ex As Exception
            End Try
        End If
        '2014/11/07 Don't set "0" anymore
        'If rawbitrate = "" Then
        '    rawbitrate = "0"
        'End If
        Return rawbitrate
    End Function

    ''' <summary>
    ''' Convert string "x/y" to single digit number "x" (Audio Channel conversion)
    ''' </summary>
    ''' <param name="AudioChannelstring">The channelstring (as string) to clean</param>
    ''' <returns>cleaned Channelnumber, i.e  "8/6" will return as 7 </returns>
    ''' <remarks>Inputstring "x/y" will return as "x" which is highest number, i.e 8/6 -> 8 (assume: highest number always first!)
    ''' 2014/01/22 Cocotus - Since this functionality is needed on several places in Ember, I builded new function to avoid duplicate code
    '''</remarks>
    Public Shared Function FormatAudioChannel(ByVal AudioChannelstring As String) As String
        'cocotus 20130303 ChannelInfo fix
        'Channel(s)/sNumber might contain: "8 / 6" (7.1) so we must handle backslash and spaces --> XBMC/Ember only supports Number like 2,6,8...
        If AudioChannelstring.Contains("/") Then
            Dim mystring As String = ""
            'use regex to get rid of all letters(if that ever happens just in case) and also remove spaces
            mystring = Text.RegularExpressions.Regex.Replace(AudioChannelstring, "[^/.0-9]", "").Trim
            'now get channel number
            If mystring.Length > 0 Then
                ' fix for new dolby atmos stream info i.e. "ObjectBased / 8 channels"
                mystring = mystring.Replace("/", "")
                If Char.IsDigit(mystring(0)) Then
                    Try
                        'In case of "x/y" this will return x which is highest number, i.e 8/6 -> 8 (highest number always first!)
                        AudioChannelstring = CStr(mystring(0))
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
        Return AudioChannelstring
        'cocotus end
    End Function
    ''' <summary>
    ''' Converts "Yes" and "No" to boolean
    ''' </summary>
    ''' <param name="bString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatBoolean(ByVal bString As String) As Boolean
        If Not String.IsNullOrEmpty(bString) Then
            Select Case bString.ToLower
                Case "yes"
                    Return True
                Case "no"
                    Return False
            End Select
        End If
        Return False
    End Function

    Public Shared Function FormatDuration(ByVal tDur As String, ByVal sMask As String) As String
        Dim sDuration As Match = Regex.Match(tDur, "(([0-9]+)h)?\s?(([0-9]+)min)?\s?(([0-9]+)s)?")
        Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
        Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
        Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)
        'Dim sMask As String = Master.eSettings.RuntimeMask
        'Dim sRuntime As String = String.Empty

        'new handling: only seconds as tdur
        If Integer.TryParse(tDur, 0) Then
            Dim ts As New TimeSpan(0, 0, Convert.ToInt32(tDur))
            sHour = ts.Hours
            sMin = ts.Minutes
            sSec = ts.Seconds
        End If

        If sMask.Contains("<h>") Then
            If sMask.Contains("<m>") OrElse sMask.Contains("<0m>") Then
                If sMask.Contains("<s>") OrElse sMask.Contains("<0s>") Then
                    Return sMask.Replace("<h>", sHour.ToString).Replace("<m>", sMin.ToString).Replace("<0m>", sMin.ToString("00")).Replace("<s>", sSec.ToString).Replace("<0s>", sSec.ToString("00"))
                Else
                    Return sMask.Replace("<h>", sHour.ToString).Replace("<m>", sMin.ToString).Replace("<0m>", sMin.ToString("00"))
                End If
            Else
                Dim tHDec As String = If(sMin > 0, Convert.ToSingle(1 / (60 / sMin)).ToString(".00"), String.Empty)
                Return sMask.Replace("<h>", String.Concat(sHour, tHDec))
            End If
        ElseIf sMask.Contains("<m>") Then
            If sMask.Contains("<s>") OrElse sMask.Contains("<0s>") Then
                Return sMask.Replace("<m>", ((sHour * 60) + sMin).ToString).Replace("<s>", sSec.ToString).Replace("<0s>", sSec.ToString("00"))
            Else
                Return sMask.Replace("<m>", ((sHour * 60) + sMin).ToString)
            End If
        ElseIf sMask.Contains("<s>") Then
            Return sMask.Replace("<s>", ((sHour * 60 * 60) + sMin * 60 + sSec).ToString)
        Else
            Return sMask
        End If
    End Function



    ''' 
    ''' <summary>
    ''' Used to set the paths of IFO/VOB (DVD) or M2ts/CLPI (BLURAY) files for Mediainfo-Scanning
    ''' </summary>
    ''' <param name="sPath">The <c>String</c>, the path to videofile (VOB/M2TS)</param>
    ''' <param name="fiIFO"><c>MediaInfo.FileInfo</c> contains the scanned Mediainfo IFO information</param>
    ''' <param name="alternativeIFOFile"><c>String</c> path to second biggest IFO File of video - alternative to default biggest IFO file</param>
    ''' <param name="ISO"><c>Boolean</c> Source: .ISO file =True, if not = False</param>
    ''' <remarks>
    ''' 2014/07/05 Cocotus - Method created to remove duplicate code and make ScanMi function easier to read
    ''' </remarks>
    Private Sub SetMediaInfoScanPaths(ByRef sPath As String, ByRef fiIFO As MediaContainers.Fileinfo, ByRef alternativeIFOFile As String, ByVal ISO As Boolean)
        Try
            If sPath.Contains("VIDEO_TS") Then
                'DVD structure


                Dim di As New IO.DirectoryInfo(Directory.GetParent(sPath).FullName)
                If ISO Then
                    'ie. path = driveletter & "VIDEO_TS"
                    di = New DirectoryInfo(sPath)
                End If


                'Biggest IFO File! -> Get Languages out of IFO and Bitrate data out of biggest VOB file!
                Dim myFilesIFO = From file In di.GetFiles("VTS*.IFO")
                                 Order By file.Length
                                 Select file.FullName
                If Not myFilesIFO Is Nothing AndAlso myFilesIFO.Count > 0 Then
                    alternativeIFOFile = myFilesIFO(myFilesIFO.Count - 2)
                    fiIFO = ScanLanguage(myFilesIFO.Last)
                End If

                'Biggest VOB File! -> Get Languages out of IFO and Bitrate data out of biggest VOB file!
                If Not myFilesIFO Is Nothing AndAlso myFilesIFO.Count > 0 AndAlso myFilesIFO.Last.Length > 6 Then

                    Dim myFiles = From file In di.GetFiles(Path.GetFileName(myFilesIFO.Last).Substring(0, Path.GetFileName(myFilesIFO.Last).Length - 6) & "*.VOB")
                                  Order By file.Length
                                  Select file.FullName
                    If Not myFiles Is Nothing AndAlso myFiles.Count > 0 Then
                        sPath = myFiles.Last
                    Else
                        myFiles = From file In di.GetFiles("VTS*.VOB")
                                  Order By file.Length
                                  Select file.FullName
                        sPath = myFiles.Last
                    End If
                Else
                    Dim myFiles = From file In di.GetFiles("VTS*.VOB")
                                  Order By file.Length
                                  Select file.FullName
                    sPath = myFiles.Last
                End If

                'Bluray
            Else

                ' looking at the largest m2ts file within the \BDMV\STREAM folder
                Dim di As New IO.DirectoryInfo(Directory.GetParent(sPath).FullName)
                If ISO Then
                    'ie. path = driveletter & "VIDEO_TS"
                    di = New DirectoryInfo(sPath)
                End If
                Dim myFiles = From file In di.GetFiles("*.m2ts")
                              Order By file.Length
                              Select file.Name

                If Not myFiles Is Nothing AndAlso myFiles.Count > 0 Then
                    'Biggest file!
                    If ISO Then
                        sPath = sPath & "\" & myFiles.Last
                    Else
                        sPath = Directory.GetParent(sPath).FullName & "\" & myFiles.Last
                    End If

                End If
                Dim ISOSubtitleScanFile As String
                If myFiles.Last.Length > 5 Then
                    ISOSubtitleScanFile = myFiles.Last.Substring(0, myFiles.Last.Length - 5) & ".clpi"
                    Dim clipinfpath As String = ""

                    clipinfpath = Directory.GetParent(sPath).FullName.Replace("STREAM", "CLIPINF")

                    If IO.File.Exists(clipinfpath & "\" & ISOSubtitleScanFile) Then
                        fiIFO = ScanLanguage(clipinfpath & "\" & ISOSubtitleScanFile)
                    End If
                End If

            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub


#End Region 'Methods

#Region "Nested Types"

#End Region 'Nested Types

End Class