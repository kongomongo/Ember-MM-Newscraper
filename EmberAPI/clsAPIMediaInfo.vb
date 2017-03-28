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
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class MediaInfo

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _Handle As IntPtr
    Private _UseAnsi As Boolean

#End Region 'Fields

#Region "Methods"

    Private Sub Close()
        MediaInfo_Close(_Handle)
        MediaInfo_Delete(_Handle)
        _Handle = Nothing
    End Sub
    ''' <summary>
    ''' Convert string "x/y" to single digit number "x" (Audio Channel conversion)
    ''' </summary>
    ''' <param name="strAudioChannelstring">The channelstring (as string) to clean</param>
    ''' <returns>cleaned Channelnumber, i.e  "8/6" will return as 7 </returns>
    ''' <remarks>Inputstring "x/y" will return as "x" which is highest number, i.e 8/6 -> 8 (assume: highest number always first!)
    ''' 2014/01/22 Cocotus - Since this functionality is needed on several places in Ember, I builded new function to avoid duplicate code
    '''</remarks>
    Public Shared Function ConvertAudioChannel(ByVal strAudioChannelstring As String) As String
        'cocotus 20130303 ChannelInfo fix
        'Channel(s)/sNumber might contain: "8 / 6" (7.1) so we must handle backslash and spaces --> XBMC/Ember only supports Number like 2,6,8...
        If strAudioChannelstring.Contains("/") Then
            Dim mystring As String = String.Empty
            'use regex to get rid of all letters(if that ever happens just in case) and also remove spaces
            mystring = Regex.Replace(strAudioChannelstring, "[^/.0-9]", "").Trim
            'now get channel number
            If mystring.Length > 0 Then
                ' fix for new dolby atmos stream info i.e. "ObjectBased / 8 channels"
                mystring = mystring.Replace("/", "")
                If Char.IsDigit(mystring(0)) Then
                    Try
                        'In case of "x/y" this will return x which is highest number, i.e 8/6 -> 8 (highest number always first!)
                        strAudioChannelstring = mystring(0)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
        Return strAudioChannelstring
        'cocotus end
    End Function

    Private Function ConvertAudioFormat(ByVal strCodecID As String, ByVal strFormat As String, ByVal strCodecHint As String, ByVal strProfile As String) As String
        Dim tCodec As String = String.Empty
        If strFormat.ToLower.Contains("dts") AndAlso (strProfile.ToLower = "hra / core" OrElse strProfile.ToLower = "ma / core") Then
            tCodec = strProfile
        ElseIf Not String.IsNullOrEmpty(strCodecID) AndAlso Not Integer.TryParse(strCodecID, 0) AndAlso Not strCodecID.ToLower.Contains("a_pcm") AndAlso Not strCodecID.Contains("00001000-0000-0100-8000-00AA00389B71") Then
            tCodec = strCodecID
        ElseIf Not String.IsNullOrEmpty(strCodecHint) Then
            tCodec = strCodecHint
        ElseIf strFormat.ToLower.Contains("mpeg") AndAlso Not String.IsNullOrEmpty(strProfile) Then
            tCodec = String.Concat("mp", strProfile.Replace("Layer", String.Empty).Trim).Trim
        ElseIf Not String.IsNullOrEmpty(strFormat) Then
            tCodec = strFormat
        End If

        If Not String.IsNullOrEmpty(tCodec) Then
            Dim myconversions As New List(Of AdvancedSettingsComplexSettingsTableItem)
            myconversions = clsXMLAdvancedSettings.GetComplexSetting("AudioFormatConverts")
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

    Private Function ConvertBitrate(ByVal strRAWBitrate As String) As String
        'now consider bitrate number and calculate all values in KB instead of MB/KB
        If strRAWBitrate.ToUpper.IndexOf(" K") > 0 Then
            strRAWBitrate = strRAWBitrate.Substring(0, strRAWBitrate.ToUpper.IndexOf(" K"))
            Dim mystring As String = String.Empty
            'use regex to get rid of all letters(if that ever happens just in case) and also remove spaces
            mystring = Regex.Replace(strRAWBitrate, "[^.0-9]", "").Trim
            strRAWBitrate = mystring
        ElseIf strRAWBitrate.ToUpper.IndexOf(" M") > 0 Then
            'can happen if video is ripped from bluray
            strRAWBitrate = strRAWBitrate.Substring(0, strRAWBitrate.ToUpper.IndexOf(" M"))
            Dim mystring As String = String.Empty
            'use regex to get rid of all letters(if that ever happens just in case) and also remove spaces
            mystring = Regex.Replace(strRAWBitrate, "[^.0-9]", "").Trim
            Try
                strRAWBitrate = (CDbl(mystring) * 100).ToString
            Catch ex As Exception
            End Try
        End If
        Return strRAWBitrate
    End Function
    ''' <summary>
    ''' Converts "Yes" and "No" to boolean
    ''' </summary>
    ''' <param name="strBooleanAsString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertToBoolean(ByVal strBooleanAsString As String) As Boolean
        If Not String.IsNullOrEmpty(strBooleanAsString) Then
            Select Case strBooleanAsString.ToLower
                Case "yes"
                    Return True
                Case "no"
                    Return False
            End Select
        End If
        Return False
    End Function

    Private Function ConvertDurationToSeconds(ByVal strDuration As String) As String
        If Not String.IsNullOrEmpty(strDuration) Then
            Dim sDuration As Match = Regex.Match(strDuration, "(([0-9]+)\s?h)?\s?(([0-9]+)\s?mi?n)?\s?(([0-9]+)\s?s)?")
            Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
            Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
            Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)
            Return ((sHour * 60 * 60) + (sMin * 60) + sSec).ToString
        End If
        Return "0"
    End Function

    Private Function ConvertVideoFormat(ByVal strCodecID As String, ByVal strFormat As String, ByVal strVersion As String) As String
        Dim tCodec As String = String.Empty

        If Not String.IsNullOrEmpty(strCodecID) AndAlso Not Integer.TryParse(strCodecID, 0) Then
            tCodec = strCodecID
        ElseIf strFormat.ToLower.Contains("mpeg") AndAlso Not String.IsNullOrEmpty(strVersion) Then
            tCodec = String.Concat("mpeg", strVersion.Replace("Version", String.Empty).Trim, "video").Trim
        ElseIf Not String.IsNullOrEmpty(strFormat) Then
            tCodec = strFormat
        End If

        If Not String.IsNullOrEmpty(tCodec) Then
            Dim myconversions As New List(Of AdvancedSettingsComplexSettingsTableItem)
            myconversions = clsXMLAdvancedSettings.GetComplexSetting("VideoFormatConverts")
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

    Private Function Get_(ByVal tStreamKind As StreamKind, ByVal intStreamNumber As Integer, ByVal strParameter As String, Optional ByVal tKindOfInfo As InfoKind = InfoKind.Text, Optional ByVal tKindOfSearch As InfoKind = InfoKind.Name) As String
        If _UseAnsi Then
            Dim Parameter_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(strParameter)
            Dim ToReturn As String = Marshal.PtrToStringAnsi(MediaInfoA_Get(_Handle, CType(tStreamKind, UIntPtr), CType(intStreamNumber, UIntPtr), Parameter_Ptr, CType(tKindOfInfo, UIntPtr), CType(tKindOfSearch, UIntPtr)))
            Marshal.FreeHGlobal(Parameter_Ptr)
            Return ToReturn
        Else
            Return Marshal.PtrToStringUni(MediaInfo_Get(_Handle, CType(tStreamKind, UIntPtr), CType(intStreamNumber, UIntPtr), strParameter, CType(tKindOfInfo, UIntPtr), CType(tKindOfSearch, UIntPtr)))
        End If
    End Function

    Private Function GetCount(ByVal tStreamKind As StreamKind, Optional ByVal uintStreamNumber As UInteger = UInteger.MaxValue) As Integer
        If uintStreamNumber = UInteger.MaxValue Then
            Return MediaInfo_Count_Get(_Handle, CType(tStreamKind, UIntPtr), CType(-1, IntPtr))
        Else
            Return MediaInfo_Count_Get(_Handle, CType(tStreamKind, UIntPtr), CType(uintStreamNumber, IntPtr))
        End If
    End Function

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

    Private Sub Open(ByVal strFileName As String)
        If _UseAnsi Then
            Dim FileName_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(strFileName)
            MediaInfoA_Open(_Handle, FileName_Ptr)
            Marshal.FreeHGlobal(FileName_Ptr)
        Else
            MediaInfo_Open(_Handle, strFileName)
        End If
    End Sub

    Private Function ScanFileItem(ByVal tFileItem As FileItem, ByVal tContentType As Enums.ContentType) As MediaContainers.Fileinfo
        Dim nFileinfo As New MediaContainers.Fileinfo
        Dim sExt As String = Path.GetExtension(tFileItem.FirstStackedPath).ToLower
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

        If tFileItem.bIsVideoTS AndAlso cDVD.fctOpenIFOFile(tFileItem.FirstStackedPath) Then
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
                    nFileinfo.StreamDetails.Video.Add(miVideo)
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
                    If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)) Then
                        miAudio.Language = Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)
                    End If
                End If
                With miAudio
                    If Not String.IsNullOrEmpty(.Codec) OrElse Not String.IsNullOrEmpty(.Channels) OrElse Not String.IsNullOrEmpty(.Language) Then
                        nFileinfo.StreamDetails.Audio.Add(miAudio)
                    End If
                End With
            Next

            SubtitleStreams = cDVD.GetIFOSubPicNumberOf
            For s As Integer = 1 To SubtitleStreams
                miSubtitle = New MediaContainers.Subtitle
                sLang = cDVD.GetIFOSubPic(s)
                If Not String.IsNullOrEmpty(sLang) Then
                    miSubtitle.LongLanguage = sLang
                    If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)) Then
                        miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                    End If
                    If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                        'miSubtitle.SubsForced = Not supported(?)
                        miSubtitle.SubsType = "Embedded"
                        nFileinfo.StreamDetails.Subtitle.Add(miSubtitle)
                    End If
                End If
            Next

            cDVD.Close()
            cDVD = Nothing

        ElseIf tFileItem.bIsStack Then
            Dim oFile As String = tFileItem.StackedFilename
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
                    sFile.AddRange(Directory.GetFiles(Directory.GetParent(tFileItem.FirstStackedPath).FullName, String.Concat(Path.GetFileNameWithoutExtension(tFileItem.StackedFilename), "*")))
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
                If bIsVTS OrElse (oFile = tFileItem.StackedFilename) Then
                    tInfo = ScanPath(tFileItem.StackedFilename)

                    tVideo = NFO.GetBestVideo(tInfo)
                    tAudio = NFO.GetBestAudio(tInfo, tContentType = Enums.ContentType.TVEpisode)

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

                    If Not String.IsNullOrEmpty(tVideo.Duration) Then TotalDur += Convert.ToInt32(ConvertDurationToSeconds(tVideo.Duration))

                    For Each sSub As MediaContainers.Subtitle In tInfo.StreamDetails.Subtitle
                        If Not nFileinfo.StreamDetails.Subtitle.Contains(sSub) Then
                            nFileinfo.StreamDetails.Subtitle.Add(sSub)
                        End If
                    Next
                End If
            Next

            nFileinfo.StreamDetails.Video.Add(miVideo)
            nFileinfo.StreamDetails.Audio.Add(miAudio)
            nFileinfo.StreamDetails.Video(0).Duration = TotalDur.ToString


        Else
            'fiInfo = ScanMI(tFileItem)
        End If

        'finally go through all the video streams and reformat the duration
        'we do this afterwards because of scanning mediainfo from stacked files... we need total
        'duration so we need to keep a consistent duration format while scanning
        'it's easier to format at the end so we don't need to bother with creating a generic
        'conversion routine
        If nFileinfo.StreamDetails IsNot Nothing AndAlso nFileinfo.StreamDetails.Video.Count > 0 Then
            For Each tVid As MediaContainers.Video In nFileinfo.StreamDetails.Video
                tVid.Duration = ConvertDurationToSeconds(tVid.Duration)
            Next
        End If

        Return nFileinfo
    End Function
    ''' <summary>
    ''' Use MediaInfo.dll to get/scan audio, stubtitle and video streams of videofile
    ''' </summary>
    ''' <returns>Mediainfo-Scanresults as MediainfoFileInfoObject</returns>
    Public Function ScanPath(ByVal strPath As String) As MediaContainers.Fileinfo
        Dim nFileInfo As New MediaContainers.Fileinfo

        If Not String.IsNullOrEmpty(strPath) Then
            _Handle = MediaInfo_New()
            _UseAnsi = Not Master.isWindows

            Open(strPath)

            'Audio Streams
            Dim intAudioStreamsCount = GetCount(StreamKind.Audio)
            For intCurrStream As Integer = 0 To intAudioStreamsCount - 1
                Dim nAudio As New MediaContainers.Audio

                'Audio General
                nAudio.Bitrate = ConvertBitrate(Get_(StreamKind.Audio, intCurrStream, "BitRate/String"))
                nAudio.Channels = ConvertAudioChannel(Get_(StreamKind.Audio, intCurrStream, "Channel(s)"))
                nAudio.Codec = ConvertAudioFormat(
                    Get_(StreamKind.Audio, intCurrStream, "CodecID"),
                    Get_(StreamKind.Audio, intCurrStream, "Format"),
                    Get_(StreamKind.Audio, intCurrStream, "CodecID/Hint"),
                    Get_(StreamKind.Audio, intCurrStream, "Format_Profile")
                    )

                'Audio Language
                Dim strLanguage = Get_(StreamKind.Audio, intCurrStream, "Language/String")
                If Not String.IsNullOrEmpty(strLanguage) Then
                    nAudio.LongLanguage = strLanguage
                    nAudio.Language = Localization.ISOLangGetCode3ByLang(nAudio.LongLanguage)
                End If

                nFileInfo.StreamDetails.Audio.Add(nAudio)
            Next

            'Subtitle Streams
            Dim intSubtitleStreamsCount As Integer = GetCount(StreamKind.Text)
            For intCurrStream As Integer = 0 To intSubtitleStreamsCount - 1
                Dim nSubtitle = New MediaContainers.Subtitle

                'Subtitle Language
                Dim strLanguage = Get_(StreamKind.Text, intCurrStream, "Language/String")
                If Not String.IsNullOrEmpty(strLanguage) Then
                    nSubtitle.LongLanguage = strLanguage
                    nSubtitle.Language = Localization.ISOLangGetCode3ByLang(nSubtitle.LongLanguage)
                    nSubtitle.SubsForced = ConvertToBoolean(Get_(StreamKind.Text, intCurrStream, "Forced/String"))
                    nSubtitle.SubsType = "Embedded"
                    nFileInfo.StreamDetails.Subtitle.Add(nSubtitle)
                End If
            Next

            'Video Streams
            Dim intVideoStreamsCount As Integer = GetCount(StreamKind.Visual)
            For intCurrentStream As Integer = 0 To intVideoStreamsCount - 1
                Dim nVideo As New MediaContainers.Video
                'Video General
                nVideo.Aspect = Get_(StreamKind.Visual, intCurrentStream, "DisplayAspectRatio")
                nVideo.Bitrate = ConvertBitrate(Get_(StreamKind.Visual, intCurrentStream, "BitRate/String"))
                nVideo.Codec = ConvertVideoFormat(
                    Get_(StreamKind.Visual, intCurrentStream, "CodecID"),
                    Get_(StreamKind.Visual, intCurrentStream, "Format"),
                    Get_(StreamKind.Visual, intCurrentStream, "Format_Version")
                    )
                nVideo.Height = Get_(StreamKind.Visual, intCurrentStream, "Height")
                nVideo.MultiViewCount = Get_(StreamKind.Visual, intCurrentStream, "MultiView_Count")
                nVideo.MultiViewLayout = Get_(StreamKind.Visual, intCurrentStream, "MultiView_Layout") 'see: http://matroska.org/technical/specs/index.html#StereoMode
                nVideo.Scantype = Get_(StreamKind.Visual, intCurrentStream, "ScanType")
                nVideo.Width = Get_(StreamKind.Visual, intCurrentStream, "Width")

                'Video Duration
                nVideo.Duration = Get_(StreamKind.Visual, intCurrentStream, "Duration/String1")
                If String.IsNullOrEmpty(nVideo.Duration) Then
                    'It's possible that duration returns empty when retrieved from videostream data
                    'so instead use "General" section of MediaInfo.dll to read duration (Is always filled!)
                    'More here: http://forum.xbmc.org/showthread.php?tid=169900
                    nVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
                End If
                nVideo.Duration = ConvertDurationToSeconds(nVideo.Duration)

                'Video Language
                Dim strLanguage = Get_(StreamKind.Visual, intCurrentStream, "Language/String")
                If Not String.IsNullOrEmpty(strLanguage) Then
                    nVideo.LongLanguage = strLanguage
                    nVideo.Language = Localization.ISOLangGetCode3ByLang(nVideo.LongLanguage)
                End If

                nFileInfo.StreamDetails.Video.Add(nVideo)
            Next

            Close()
        End If

        Return nFileInfo

        Dim fiOut As New MediaContainers.Fileinfo
        Dim fiIFO As New MediaContainers.Fileinfo

        If Not String.IsNullOrEmpty(strPath) Then
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
            Dim sExt As String = Path.GetExtension(strPath).ToLower
            Dim alternativeIFOFile As String = String.Empty
            Dim strCommandUnmount As String = String.Empty

            'New ISO Handling -> Use either DAEMON Tools or VitualCloneDrive to mount ISO!
            If FileUtils.Common.isVideoTS(strPath) OrElse FileUtils.Common.isBDRip(strPath) Then
                If Directory.Exists(Directory.GetParent(strPath).FullName) Then
                    SetMediaInfoScanPaths(strPath, fiIFO, alternativeIFOFile, False)
                End If
            End If

            If Not String.IsNullOrEmpty(strPath) Then
                _Handle = MediaInfo_New()

                If Master.isWindows Then
                    _UseAnsi = False
                Else
                    _UseAnsi = True
                End If

                Open(strPath)

                VideoStreams = GetCount(StreamKind.Visual)
                AudioStreams = GetCount(StreamKind.Audio)
                SubtitleStreams = GetCount(StreamKind.Text)

                '2014/07/05 Fix for VIDEO_TS scanning: Use second largest (=alternativeIFOFile) IFO File if largest File doesn't contain needed information (=duration)! (rare case!)
                If strPath.ToUpper.Contains("VIDEO_TS") Then
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
                        'fiIFO = ScanLanguage(alternativeIFOFile)
                    End If
                End If
            End If

            For v As Integer = 0 To VideoStreams - 1
                miVideo = New MediaContainers.Video

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
                    If String.IsNullOrEmpty(miVideo.Duration) Then
                        miVideo.Duration = Get_(StreamKind.General, 0, "Duration/String1")
                    End If
                End If




                If sExt = ".iso" OrElse FileUtils.Common.isVideoTS(strPath) OrElse FileUtils.Common.isBDRip(strPath) Then
                    miVideo.Filesize = FileUtils.Common.GetFolderSize(Directory.GetParent(strPath).FullName)
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
                miAudio.Codec = ConvertAudioFormat(Get_(StreamKind.Audio, a, "CodecID"), Get_(StreamKind.Audio, a, "Format"),
                                                   Get_(StreamKind.Audio, a, "CodecID/Hint"), Get_(StreamKind.Audio, a, "Format_Profile"))
                miAudio.Channels = ConvertAudioChannel(Get_(StreamKind.Audio, a, "Channel(s)"))

                'cocotus, 2013/02 Added support for new MediaInfo-fields
                'Audio-Bitrate
                miAudio.Bitrate = ConvertBitrate(Get_(StreamKind.Audio, a, "BitRate/String"))
                'cocotus end

                aLang = Get_(StreamKind.Audio, a, "Language/String")
                If Not String.IsNullOrEmpty(aLang) Then
                    miAudio.LongLanguage = aLang
                    If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)) Then
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
        End If

        Return fiOut
    End Function
    ''' 
    ''' <summary>
    ''' Used to set the paths of IFO/VOB (DVD) or M2ts/CLPI (BLURAY) files for Mediainfo-Scanning
    ''' </summary>
    ''' <param name="strPath">The <c>String</c>, the path to videofile (VOB/M2TS)</param>
    ''' <param name="tFileInfo"><c>MediaInfo.FileInfo</c> contains the scanned Mediainfo IFO information</param>
    ''' <param name="strAlternativeIFOFile"><c>String</c> path to second biggest IFO File of video - alternative to default biggest IFO file</param>
    ''' <param name="bISO"><c>Boolean</c> Source: .ISO file =True, if not = False</param>
    ''' <remarks>
    ''' 2014/07/05 Cocotus - Method created to remove duplicate code and make ScanMi function easier to read
    ''' </remarks>
    Private Sub SetMediaInfoScanPaths(ByRef strPath As String, ByRef tFileInfo As MediaContainers.Fileinfo, ByRef strAlternativeIFOFile As String, ByVal bISO As Boolean)
        Try
            If strPath.Contains("VIDEO_TS") Then
                'DVD structure


                Dim di As New DirectoryInfo(Directory.GetParent(strPath).FullName)
                If bISO Then
                    'ie. path = driveletter & "VIDEO_TS"
                    di = New DirectoryInfo(strPath)
                End If


                'Biggest IFO File! -> Get Languages out of IFO and Bitrate data out of biggest VOB file!
                Dim myFilesIFO = From file In di.GetFiles("VTS*.IFO")
                                 Order By file.Length
                                 Select file.FullName
                If Not myFilesIFO Is Nothing AndAlso myFilesIFO.Count > 0 Then
                    strAlternativeIFOFile = myFilesIFO(myFilesIFO.Count - 2)
                    'tFileInfo = ScanLanguage(myFilesIFO.Last)
                End If

                'Biggest VOB File! -> Get Languages out of IFO and Bitrate data out of biggest VOB file!
                If Not myFilesIFO Is Nothing AndAlso myFilesIFO.Count > 0 AndAlso myFilesIFO.Last.Length > 6 Then

                    Dim myFiles = From file In di.GetFiles(Path.GetFileName(myFilesIFO.Last).Substring(0, Path.GetFileName(myFilesIFO.Last).Length - 6) & "*.VOB")
                                  Order By file.Length
                                  Select file.FullName
                    If Not myFiles Is Nothing AndAlso myFiles.Count > 0 Then
                        strPath = myFiles.Last
                    Else
                        myFiles = From file In di.GetFiles("VTS*.VOB")
                                  Order By file.Length
                                  Select file.FullName
                        strPath = myFiles.Last
                    End If
                Else
                    Dim myFiles = From file In di.GetFiles("VTS*.VOB")
                                  Order By file.Length
                                  Select file.FullName
                    strPath = myFiles.Last
                End If

                'Bluray
            Else

                ' looking at the largest m2ts file within the \BDMV\STREAM folder
                Dim di As New DirectoryInfo(Directory.GetParent(strPath).FullName)
                If bISO Then
                    'ie. path = driveletter & "VIDEO_TS"
                    di = New DirectoryInfo(strPath)
                End If
                Dim myFiles = From file In di.GetFiles("*.m2ts")
                              Order By file.Length
                              Select file.Name

                If Not myFiles Is Nothing AndAlso myFiles.Count > 0 Then
                    'Biggest file!
                    If bISO Then
                        strPath = strPath & "\" & myFiles.Last
                    Else
                        strPath = Directory.GetParent(strPath).FullName & "\" & myFiles.Last
                    End If

                End If
                Dim ISOSubtitleScanFile As String
                If myFiles.Last.Length > 5 Then
                    ISOSubtitleScanFile = myFiles.Last.Substring(0, myFiles.Last.Length - 5) & ".clpi"
                    Dim clipinfpath As String = String.Empty

                    clipinfpath = Directory.GetParent(strPath).FullName.Replace("STREAM", "CLIPINF")

                    If File.Exists(clipinfpath & "\" & ISOSubtitleScanFile) Then
                        'tFileInfo = ScanLanguage(clipinfpath & "\" & ISOSubtitleScanFile)
                    End If
                End If

            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub


#End Region 'Methods

#Region "Nested Types"

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

#End Region 'Nested Types

End Class