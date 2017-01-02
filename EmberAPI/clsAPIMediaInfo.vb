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

<Serializable()> _
Public Class MediaInfo

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _Handle As IntPtr
    Private _UseAnsi As Boolean

#End Region 'Fields

#Region "Methods"

    Private Shared Function ApplyDefaults(ByVal tDBElement As Database.DBElement) As MediaContainers.Fileinfo
        Dim nFileInfo As New MediaContainers.Fileinfo
        Dim nMetadataList As New List(Of Settings.MetadataPerType)
        Dim strFileExtension = Path.GetExtension(tDBElement.FileItem.FirstStackedPath.ToLower)

        Select Case tDBElement.ContentType
            Case Enums.ContentType.Movie
                nMetadataList = Master.eSettings.MovieMetadataPerFileType
            Case Enums.ContentType.TVEpisode
                nMetadataList = Master.eSettings.TVMetadataPerFileType
        End Select

        For Each m As Settings.MetadataPerType In nMetadataList
            If m.FileType = strFileExtension Then
                nFileInfo = m.MetaData
                Return nFileInfo
            End If
        Next
        Return Nothing
    End Function

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
    Private Function ConvertBoolean(ByVal strBooleanAsString As String) As Boolean
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

    Private Shared Function ConvertVideoDuration(ByVal strDuration As String, ByVal strMask As String) As String
        Dim sDuration As Match = Regex.Match(strDuration, "(([0-9]+)h)?\s?(([0-9]+)min)?\s?(([0-9]+)s)?")
        Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
        Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
        Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)

        'new handling: only seconds as tdur
        If Integer.TryParse(strDuration, 0) Then
            Dim ts As New TimeSpan(0, 0, Convert.ToInt32(strDuration))
            sHour = ts.Hours
            sMin = ts.Minutes
            sSec = ts.Seconds
        End If

        If strMask.Contains("<h>") Then
            If strMask.Contains("<m>") OrElse strMask.Contains("<0m>") Then
                If strMask.Contains("<s>") OrElse strMask.Contains("<0s>") Then
                    Return strMask.Replace("<h>", sHour.ToString).Replace("<m>", sMin.ToString).Replace("<0m>", sMin.ToString("00")).Replace("<s>", sSec.ToString).Replace("<0s>", sSec.ToString("00"))
                Else
                    Return strMask.Replace("<h>", sHour.ToString).Replace("<m>", sMin.ToString).Replace("<0m>", sMin.ToString("00"))
                End If
            Else
                Dim tHDec As String = If(sMin > 0, Convert.ToSingle(1 / (60 / sMin)).ToString(".00"), String.Empty)
                Return strMask.Replace("<h>", String.Concat(sHour, tHDec))
            End If
        ElseIf strMask.Contains("<m>") Then
            If strMask.Contains("<s>") OrElse strMask.Contains("<0s>") Then
                Return strMask.Replace("<m>", ((sHour * 60) + sMin).ToString).Replace("<s>", sSec.ToString).Replace("<0s>", sSec.ToString("00"))
            Else
                Return strMask.Replace("<m>", ((sHour * 60) + sMin).ToString)
            End If
        ElseIf strMask.Contains("<s>") Then
            Return strMask.Replace("<s>", ((sHour * 60 * 60) + sMin * 60 + sSec).ToString)
        Else
            Return strMask
        End If
    End Function

    Private Function ConvertVideoDurationToSeconds(ByVal sttDuration As String, ByVal bReverse As Boolean) As String
        If Not String.IsNullOrEmpty(sttDuration) Then
            If bReverse Then
                Dim ts As New TimeSpan(0, 0, Convert.ToInt32(sttDuration))
                Return String.Format("{0}h {1}min {2}s", ts.Hours, ts.Minutes, ts.Seconds)
            Else
                Dim sDuration As Match = Regex.Match(sttDuration, "(([0-9]+)\s?h)?\s?(([0-9]+)\s?mi?n)?\s?(([0-9]+)\s?s)?")
                Dim sHour As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(2).Value), (Convert.ToInt32(sDuration.Groups(2).Value)), 0)
                Dim sMin As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(4).Value), (Convert.ToInt32(sDuration.Groups(4).Value)), 0)
                Dim sSec As Integer = If(Not String.IsNullOrEmpty(sDuration.Groups(6).Value), (Convert.ToInt32(sDuration.Groups(6).Value)), 0)
                Return ((sHour * 60 * 60) + (sMin * 60) + sSec).ToString
            End If
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

    Public Shared Function ConvertVideoStereoMode(ByVal strFormat As String) As String
        If Not String.IsNullOrEmpty(strFormat) Then
            Dim tFormat As String = String.Empty
            Select Case strFormat.ToLower
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

    Private Function ConvertVideoStereoToShort(ByVal strFormat As String) As String
        If Not String.IsNullOrEmpty(strFormat) Then
            Dim tFormat As String = String.Empty
            Select Case strFormat.ToLower
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

    Private Sub GetMediaInfoFromFileItem(ByVal tFileItem As FileItem, ByRef fiInfo As MediaContainers.Fileinfo, ByVal isTVEpisode As Boolean)
        If Not String.IsNullOrEmpty(tFileItem.FullPath) AndAlso File.Exists(tFileItem.FirstStackedPath) Then

            Dim nMainFile As New MediaContainers.Fileinfo
            Dim nStackedFiles As New List(Of MediaContainers.Fileinfo)

            'scan Main video file to get all media informations
            If tFileItem.bIsDiscImage Then
                Dim nDiscImage As New DiscImage
                If nDiscImage.Mount(tFileItem.FirstStackedPath) Then

                End If
            End If
            nMainFile = ScanMI(tFileItem.FirstStackedPath)

            'scan all stacked video files to get the total duration
            'fiInfo = ScanMI(tFileItem)




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
                        If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miAudio.LongLanguage)) Then
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
                        If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)) Then
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
                        tInfo = ScanMI(tFileItem.StackedFilename)

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

                        If Not String.IsNullOrEmpty(tVideo.Duration) Then TotalDur += Convert.ToInt32(ConvertVideoDurationToSeconds(tVideo.Duration, False))

                        For Each sSub As MediaContainers.Subtitle In tInfo.StreamDetails.Subtitle
                            If Not fiOut.StreamDetails.Subtitle.Contains(sSub) Then
                                fiOut.StreamDetails.Subtitle.Add(sSub)
                            End If
                        Next
                    End If
                Next

                fiOut.StreamDetails.Video.Add(miVideo)
                fiOut.StreamDetails.Audio.Add(miAudio)
                fiOut.StreamDetails.Video(0).Duration = ConvertVideoDurationToSeconds(TotalDur.ToString, True)

                fiInfo = fiOut
            Else
                'fiInfo = ScanMI(tFileItem)
            End If

            'finally go through all the video streams and reformat the duration
            'we do this afterwards because of scanning mediainfo from stacked files... we need total
            'duration so we need to keep a consistent duration format while scanning
            'it's easier to format at the end so we don't need to bother with creating a generic
            'conversion routine
            If fiInfo.StreamDetails IsNot Nothing AndAlso fiInfo.StreamDetails.Video.Count > 0 Then
                For Each tVid As MediaContainers.Video In fiInfo.StreamDetails.Video
                    tVid.Duration = ConvertVideoDurationToSeconds(tVid.Duration, False)
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

    Private Sub Open(ByVal strFileName As String)
        If _UseAnsi Then
            Dim FileName_Ptr As IntPtr = Marshal.StringToHGlobalAnsi(strFileName)
            MediaInfoA_Open(_Handle, FileName_Ptr)
            Marshal.FreeHGlobal(FileName_Ptr)
        Else
            MediaInfo_Open(_Handle, strFileName)
        End If
    End Sub

    ''' <summary>
    ''' Use MediaInfo.dll Scan to get subtitle and audio Stream information of file (used for scanning IFO files)
    ''' </summary>
    ''' <returns>Mediainfo-Scanresults as MediainfoFileInfoObject</returns>
    Private Function ScanLanguage(ByVal strIFOPath As String) As MediaContainers.Fileinfo
        'The whole content of this function is a strip of of the "big" ScanMI function. It is used to scan IFO files of VIDEO_TS media to retrieve language info
        Dim fiOut As New MediaContainers.Fileinfo

        _Handle = MediaInfo_New()

        If Master.isWindows Then
            _UseAnsi = False
        Else
            _UseAnsi = True
        End If

        Open(strIFOPath)


        'Audio Scan
        Dim AudioStreams As Integer
        AudioStreams = GetCount(StreamKind.Audio)
        Dim miAudio As New MediaContainers.Audio
        Dim aLang As String = String.Empty
        Dim a_Profile As String = String.Empty

        For a As Integer = 0 To AudioStreams - 1
            miAudio = New MediaContainers.Audio
            miAudio.Codec = ConvertAudioFormat(
                Get_(StreamKind.Audio, a, "CodecID"),
                Get_(StreamKind.Audio, a, "Format"),
                Get_(StreamKind.Audio, a, "CodecID/Hint"),
                Get_(StreamKind.Audio, a, "Format_Profile")
                )
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
            End If
            fiOut.StreamDetails.Audio.Add(miAudio)
        Next

        'Subtitle Scan
        Dim SubtitleStreams As Integer
        SubtitleStreams = GetCount(StreamKind.Text)
        Dim miSubtitle As New MediaContainers.Subtitle

        Dim sLang As String = String.Empty
        For s As Integer = 0 To SubtitleStreams - 1
            miSubtitle = New MediaContainers.Subtitle
            sLang = Get_(StreamKind.Text, s, "Language/String")
            If Not String.IsNullOrEmpty(sLang) Then
                miSubtitle.LongLanguage = sLang
                If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)) Then
                    miSubtitle.Language = Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)
                End If
            End If
            If Not String.IsNullOrEmpty(miSubtitle.Language) Then
                miSubtitle.SubsForced = ConvertBoolean(Get_(StreamKind.Text, s, "Forced/String"))
                miSubtitle.SubsType = "Embedded"
                fiOut.StreamDetails.Subtitle.Add(miSubtitle)
            End If
        Next

        'Video Scan
        Dim miVideo As New MediaContainers.Video
        Dim VideoStreams As Integer
        VideoStreams = GetCount(StreamKind.Visual)
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
    Private Function ScanMI(ByVal strPath As String) As MediaContainers.Fileinfo
        Dim fiOut As New MediaContainers.Fileinfo
        Dim fiIFO As New MediaContainers.Fileinfo
        Try
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
                If sExt = ".iso" OrElse FileUtils.Common.isVideoTS(strPath) OrElse FileUtils.Common.isBDRip(strPath) Then

                    'ISO-File Scanning using either DAIMON Tools / VCDMount.exe to mount and read file!
                    If sExt = ".iso" Then

                        Dim driveletter As String = Master.eSettings.GeneralDaemonDrive ' i.e. "F"
                        'Toolpath either VCDMOUNT.exe or DTLite.exe!
                        Dim ToolPath As String = Master.eSettings.GeneralDaemonPath

                        'Now only use DAEMON Tools to mount ISO if installed on user system
                        If Not String.IsNullOrEmpty(driveletter) AndAlso Not String.IsNullOrEmpty(ToolPath) Then

                            'Either DAEMONToolsLite or VirtualCloneDrive (http://www.slysoft.com/en/virtual-clonedrive.html)
                            If ToolPath.ToLower.Contains("vcdmount") Then
                                'Unmount, i.e "C:\Program Files\Elaborate Bytes\VirtualCloneDrive\VCDMount.exe" /u
                                strCommandUnmount = String.Concat("/u")
                                Functions.Run_Process(ToolPath, strCommandUnmount, False, True)
                                'Mount
                                'Mount ISO on virtual drive, i.e c:\Program Files (x86)\Elaborate Bytes\VirtualCloneDrive\vcdmount.exe U:\isotest\test2iso.ISO
                                Functions.Run_Process(ToolPath, """" & strPath & """", False, True)

                                'Toolpath doesn't contain vcdmount.exe -> assume daemon tools with DS type drive!
                            Else
                                'Unmount
                                strCommandUnmount = String.Concat("-unmount ", Regex.Replace(driveletter, ":\\", String.Empty))
                                Functions.Run_Process(ToolPath, strCommandUnmount, False, True)
                                'Mount
                                'Mount ISO on Daemon Tools (Lite), i.e. C:\Program Files\DAEMON Tools Lite\DTAgent.exe -mount dt, E, "U:\isotest\test2iso.ISO"
                                Functions.Run_Process(ToolPath, String.Concat("-mount dt, ",
                                                                              Regex.Replace(driveletter, ":\\", String.Empty),
                                                                              ", """,
                                                                              strPath,
                                                                              """"), False, True)
                            End If

                            'now check if it's bluray or dvd image/VIDEO_TS/BMDV Folder-Scanning!
                            If Directory.Exists(String.Concat(driveletter, ":\VIDEO_TS")) Then
                                strPath = String.Concat(driveletter, ":\VIDEO_TS")
                                SetMediaInfoScanPaths(strPath, fiIFO, alternativeIFOFile, True)
                                'get foldersize information
                            ElseIf Directory.Exists(driveletter & ":\BDMV\STREAM") Then
                                strPath = driveletter & ":\BDMV\STREAM"
                                SetMediaInfoScanPaths(strPath, fiIFO, alternativeIFOFile, True)
                            End If
                        End If

                        'VIDEO_TS/BMDV Folder-Scanning!
                    Else
                        If Directory.Exists(Directory.GetParent(strPath).FullName) Then
                            SetMediaInfoScanPaths(strPath, fiIFO, alternativeIFOFile, False)
                        End If
                    End If
                End If

                If Not strPath = String.Empty Then
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
                            fiIFO = ScanLanguage(alternativeIFOFile)
                        End If
                    End If

                End If

                For v As Integer = 0 To VideoStreams - 1
                    miVideo = New MediaContainers.Video
                    'cocotus, 2013/02 Added support for new MediaInfo-fields
                    'Video-Bitrate
                    miVideo.Bitrate = ConvertBitrate(Get_(StreamKind.Visual, v, "BitRate/String"))
                    'MultiViewCount (Support for 3D Movie, If > 1 -> 3D Movie)
                    miVideo.MultiViewCount = Get_(StreamKind.Visual, v, "MultiView_Count")
                    'MultiViewLayout (http://matroska.org/technical/specs/index.html#StereoMode)
                    miVideo.MultiViewLayout = Get_(StreamKind.Visual, v, "MultiView_Layout")
                    'Encoder-settings
                    'miVideo.EncodedSettings = Me.Get_(StreamKind.Visual, v, "Encoded_Library_Settings")
                    'cocotus end
                    miVideo.StereoMode = ConvertVideoStereoMode(miVideo.MultiViewLayout)

                    miVideo.Width = Get_(StreamKind.Visual, v, "Width")
                    miVideo.Height = Get_(StreamKind.Visual, v, "Height")
                    miVideo.Codec = ConvertVideoFormat(Get_(StreamKind.Visual, v, "CodecID"), Get_(StreamKind.Visual, v, "Format"),
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
                        If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miVideo.LongLanguage)) Then
                            miVideo.Language = Localization.ISOLangGetCode3ByLang(miVideo.LongLanguage)
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


                For s As Integer = 0 To SubtitleStreams - 1

                    miSubtitle = New MediaContainers.Subtitle

                    sLang = Get_(StreamKind.Text, s, "Language/String")
                    If Not String.IsNullOrEmpty(sLang) Then
                        miSubtitle.LongLanguage = sLang
                        If Not String.IsNullOrEmpty(Localization.ISOLangGetCode3ByLang(miSubtitle.LongLanguage)) Then
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
                        miSubtitle.SubsForced = ConvertBoolean(Get_(StreamKind.Text, s, "Forced/String"))
                        miSubtitle.SubsType = "Embedded"
                        fiOut.StreamDetails.Subtitle.Add(miSubtitle)
                    End If
                Next

                If Not String.IsNullOrEmpty(strCommandUnmount) Then
                    Functions.Run_Process(Master.eSettings.GeneralDaemonPath, strCommandUnmount, False, True)
                End If

                Close()
            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
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
                    tFileInfo = ScanLanguage(myFilesIFO.Last)
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
                        tFileInfo = ScanLanguage(clipinfpath & "\" & ISOSubtitleScanFile)
                    End If
                End If

            End If
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Public Shared Sub UpdateMediaInfo(ByRef tDBElement As Database.DBElement)
        Dim bLockAudioLanguage As Boolean
        Dim bLockVideoLanguage As Boolean
        Dim nFileInfo = New MediaContainers.Fileinfo
        Dim strRuntimeMask As String = String.Empty

        Select Case tDBElement.ContentType
            Case Enums.ContentType.Movie
                bLockAudioLanguage = Master.eSettings.MovieLockLanguageA
                bLockVideoLanguage = Master.eSettings.MovieLockLanguageV
                strRuntimeMask = Master.eSettings.MovieScraperDurationRuntimeFormat
            Case Enums.ContentType.TVEpisode
                bLockAudioLanguage = Master.eSettings.TVLockEpisodeLanguageA
                bLockVideoLanguage = Master.eSettings.TVLockEpisodeLanguageV
                strRuntimeMask = Master.eSettings.TVScraperDurationRuntimeFormat
        End Select

        If Not tDBElement.FileItem.bIsDiscStub AndAlso Master.CanScanDiscImage OrElse Not (tDBElement.FileItem.bIsDiscImage OrElse tDBElement.FileItem.bIsRAR) Then
            Dim MI As New MediaInfo
            MI.GetMediaInfoFromFileItem(tDBElement.FileItem, nFileInfo, False)

            If nFileInfo.StreamDetailsSpecified Then
                ' overwrite only if it get something from Mediainfo 
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
                tDBElement.MainDetails.FileInfo = nFileInfo
            End If
            If tDBElement.MainDetails.FileInfo.StreamDetails.VideoSpecified AndAlso Master.eSettings.MovieScraperUseMDDuration Then
                Dim tVid As MediaContainers.Video = NFO.GetBestVideo(tDBElement.MainDetails.FileInfo)
                'cocotus 29/02/2014, Added check to only save Runtime in nfo/moviedb if scraped Runtime <> 0! (=Error during Mediainfo Scan)
                If Not String.IsNullOrEmpty(tVid.Duration) AndAlso Not tVid.Duration.Trim = "0" Then
                    tDBElement.MainDetails.Runtime = ConvertVideoDuration(tVid.Duration, strRuntimeMask)
                End If
            End If
            MI = Nothing
        End If

        If Not tDBElement.MainDetails.FileInfo.StreamDetailsSpecified Then
            nFileInfo = New MediaContainers.Fileinfo
            nFileInfo = ApplyDefaults(tDBElement)
            If nFileInfo IsNot Nothing Then tDBElement.MainDetails.FileInfo = nFileInfo
        End If
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