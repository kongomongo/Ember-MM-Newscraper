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

<Serializable()>
Public Class FileItem

#Region "Fields"

    Private _bisdirectory As Boolean
    Private _directoryinfo As DirectoryInfo
    Private _fileInfo As FileInfo
    Private _strpath As String
    Private _strstackedpath As String
    Private _strstackedtitle As String

#End Region 'Fields

#Region "Constructors"

    Public Sub New(ByVal strPath As String)
        Clear()
        If strPath.StartsWith("stack://") Then
            _fileInfo = New FileInfo(FileUtils.Stacking.GetFirstStackedPath(strPath))
        Else
            _fileInfo = New FileInfo(strPath)
        End If
        _strpath = strPath
        Dim strStackedPath = FileUtils.Stacking.GetStackedPath(strPath)
        _strstackedtitle = IO.Path.GetFileNameWithoutExtension(strStackedPath)
        _strstackedpath = strStackedPath
    End Sub

    Public Sub New(ByVal tDirectoryInfo As DirectoryInfo)
        Clear()
        _directoryinfo = tDirectoryInfo
        _strpath = tDirectoryInfo.FullName
        _bisdirectory = True
        'Dim strStackedPath = FileUtils.Stacking.GetStackedPath(tDirectoryInfo.FullName)
        '_strstackedtitle = IO.Path.GetFileNameWithoutExtension(strStackedPath)
        '_strstackedpath = strStackedPath
    End Sub

    Public Sub New(ByVal tFileInfo As FileInfo)
        Clear()
        _fileInfo = tFileInfo
        _strpath = tFileInfo.FullName
        Dim strStackedPath = FileUtils.Stacking.GetStackedPath(tFileInfo.FullName)
        _strstackedtitle = IO.Path.GetFileNameWithoutExtension(strStackedPath)
        _strstackedpath = strStackedPath
    End Sub

#End Region 'Constructors

#Region "Properties"

    Public ReadOnly Property bIsBDMV() As Boolean
        Get
            Return IsBDMV()
        End Get
    End Property

    Public ReadOnly Property bIsDirectory() As Boolean
        Get
            Return _bisdirectory
        End Get
    End Property

    Public ReadOnly Property bIsDiscImage() As Boolean
        Get
            Return IsDiscImage()
        End Get
    End Property

    Public ReadOnly Property bIsDiscStub() As Boolean
        Get
            Return IsDiscStub()
        End Get
    End Property

    Public ReadOnly Property bIsOnline() As Boolean
        Get
            Return IsOnline()
        End Get
    End Property

    Public ReadOnly Property bIsRAR() As Boolean
        Get
            Return IsRAR()
        End Get
    End Property

    Public ReadOnly Property bIsStack() As Boolean
        Get
            Return IsStack()
        End Get
    End Property

    Public ReadOnly Property bIsVideoTS() As Boolean
        Get
            Return IsVideoTS()
        End Get
    End Property

    Public ReadOnly Property DirectoryInfo() As DirectoryInfo
        Get
            Return _directoryinfo
        End Get
    End Property

    Public ReadOnly Property MainPath() As DirectoryInfo
        Get
            Return GetMainPath()
        End Get
    End Property

    Public ReadOnly Property FileInfo() As FileInfo
        Get
            Return _fileInfo
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            Return _strpath
        End Get
    End Property

    Public ReadOnly Property FirstStackedPath() As String
        Get
            Return GetFirstStackedPath()
        End Get
    End Property

    Public ReadOnly Property PathList() As List(Of String)
        Get
            Return GetPathList()
        End Get
    End Property

    Public Property StackedTitle() As String
        Get
            Return _strstackedtitle
        End Get
        Set(ByVal value As String)
            _strstackedtitle = value
        End Set
    End Property

    Public Property StackedPath() As String
        Get
            Return _strstackedpath
        End Get
        Set(ByVal value As String)
            _strstackedpath = value
        End Set
    End Property

#End Region 'Properties

#Region "Methods"

    Public Sub Clear()
        _bisdirectory = False
        _directoryinfo = Nothing
        _fileInfo = Nothing
        _strpath = String.Empty
        _strstackedpath = String.Empty
        _strstackedtitle = String.Empty
    End Sub

    Private Function GetPathList() As List(Of String)
        Return FileUtils.Stacking.GetPathList(_strpath)
    End Function

    Private Function GetFirstStackedPath() As String
        If bIsStack Then
            Return FileUtils.Stacking.GetFirstStackedPath(_strpath)
        Else
            Return _strpath
        End If
    End Function
    ''' <summary>
    ''' Returned the main folder that contains the file
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMainPath() As DirectoryInfo
        If Not _bisdirectory Then
            If IsBDMV() Then
                Return Directory.GetParent(Directory.GetParent(_fileInfo.FullName).FullName)
            ElseIf IsVideoTS AndAlso Directory.GetParent(_fileInfo.FullName).Name = "VIDEO_TS" Then
                Return Directory.GetParent(Directory.GetParent(_fileInfo.FullName).FullName)
            ElseIf IsVideoTS Then
                Return Directory.GetParent(_fileInfo.FullName)
            Else
                Return Directory.GetParent(_fileInfo.FullName)
            End If
        Else
            Return _directoryinfo
        End If
    End Function

    Private Function IsBDMV() As Boolean
        If Not _bisdirectory Then
            Dim strFileName As String = _fileInfo.Name.ToLower
            Return strFileName = "index.bdmv" OrElse strFileName = "moviembject.bdmv"
        End If
        Return False
    End Function

    Private Function IsDiscImage() As Boolean
        If Not _bisdirectory Then
            Dim strImageExtension() As String = {".bin", ".img", ".iso", ".nrg"}
            If strImageExtension.Contains(_fileInfo.Extension.ToLower) Then Return True
        End If
        Return False
    End Function

    Private Function IsOnline() As Boolean
        If Not _bisdirectory Then
            If Not String.IsNullOrEmpty(GetFirstStackedPath) Then
                If File.Exists(_strpath) Then Return True
            End If
        Else
            If Directory.Exists(GetFirstStackedPath) Then Return True
        End If
        Return False
    End Function

    Private Function IsRAR() As Boolean
        If Not _bisdirectory Then
            Dim strImageExtension() As String = {".rar"}
            If strImageExtension.Contains(_fileInfo.Extension.ToLower) Then Return True
        End If
        Return False
    End Function

    Private Function IsDiscStub() As Boolean
        If Not _bisdirectory Then
            Dim strFileExtension As String = _fileInfo.Extension.ToLower
            If strFileExtension = ".disc" Then Return True
        End If
        Return False
    End Function

    Private Function IsStack() As Boolean
        If _strpath.StartsWith("stack://") Then Return True
        Return False
    End Function

    Private Function IsVideoTS() As Boolean
        If Not _bisdirectory Then
            Dim strFileName As String = _fileInfo.Name.ToLower
            If strFileName = "video_ts.ifo" Then Return True
            If strFileName.StartsWith("vts_") AndAlso strFileName.EndsWith("_0.ifo") AndAlso strFileName.Length = 12 Then Return True
        End If
        Return False
    End Function

    Public Sub SetPath(strPath As String)
        _strpath = strPath
    End Sub

#End Region 'Methods

End Class

Public Class FileItemList

#Region "Fields"

    Private _bismultipath As Boolean
    Private _fileitemlist As New List(Of FileItem)

#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(strPath As String)
        Clear()
        Dim diPath As DirectoryInfo = New DirectoryInfo(strPath)

        'get all paths
        Dim lstDirectories = diPath.GetDirectories
        For Each nDirectoryInfo In lstDirectories
            _fileitemlist.Add(New FileItem(nDirectoryInfo))
        Next

        'get all files
        Dim lstFiles = diPath.GetFiles.Where(
            Function(f) Master.eSettings.FileSystemValidExts.Contains(f.Extension.ToLower) AndAlso
            Not Regex.IsMatch(f.Name, String.Concat("[^\w\s]\s?(", AdvancedSettings.GetSetting("NotValidFileContains", "trailer|sample"), ")"), RegexOptions.IgnoreCase) AndAlso
            ((Not Convert.ToInt32(Master.eSettings.MovieSkipLessThan) > 0 OrElse f.Length >= Master.eSettings.MovieSkipLessThan * 1048576))
            ).OrderBy(Function(f) f.FullName)
        For Each nFileInfo In lstFiles
            _fileitemlist.Add(New FileItem(nFileInfo))
        Next
    End Sub

#End Region 'Constructors

#Region "Properties"

    Public ReadOnly Property FileItems() As List(Of FileItem)
        Get
            Return _fileitemlist
        End Get
    End Property


    Public Property bMultiPath() As Boolean
        Get
            Return _bismultipath
        End Get
        Set(value As Boolean)
            _bismultipath = value
        End Set
    End Property

#End Region 'Properties

#Region "Methods"

    Public Sub AddItem(strPath As String)
        _fileitemlist.Add(New FileItem(strPath))
    End Sub

    Public Sub AddItem(tFileInfo As FileInfo)
        _fileitemlist.Add(New FileItem(tFileInfo))
    End Sub

    Public Sub AddItem(tFileItem As FileItem)
        _fileitemlist.Add(tFileItem)
    End Sub

    Public Sub AddItems(tFileItems As IEnumerable(Of FileInfo))
        For i As Integer = 0 To tFileItems.Count - 1
            _fileitemlist.Add(New FileItem(tFileItems(i)))
        Next
    End Sub

    Public Sub Clear()
        _bismultipath = False
        _fileitemlist.Clear()
    End Sub

    Public Function GetItem(iItem As Integer) As FileItem
        If iItem > -1 AndAlso iItem < _fileitemlist.Count Then
            Return _fileitemlist(iItem)
        Else
            Return Nothing
        End If
    End Function

    Public Sub RemoveItem(iFileItem As Integer)
        _fileitemlist.RemoveAt(iFileItem)
    End Sub

    Public Sub RemoveItem(tFileItem As FileItem)
        _fileitemlist.Remove(tFileItem)
    End Sub

    Public Sub Stack()
        StackFolders()
        StackFiles()
    End Sub

    Public Sub StackFolders()
        Dim strFolderStackingPattern As String = AdvancedSettings.GetSetting("FolderStacking", "((cd|dvd|dis[ck])[0-9]+)$")

        'stack folders
        Dim i As Integer = 0
        While i < _fileitemlist.Count
            If _fileitemlist(i).bIsDirectory Then
                Dim tFileItem1 As FileItem = GetItem(i)
                'folder stacking is disabled, does not work in Kodi
                'we only check for VIDEO_TS and BDMV structure

                'check if VIDEO_TS
                Dim strPath As String = Path.Combine(tFileItem1.FirstStackedPath, "VIDEO_TS.IFO")
                If File.Exists(strPath) Then
                    'VIDEO_TS structure found, change folder to file
                    _fileitemlist(i) = New FileItem(strPath)
                Else
                    strPath = Path.Combine(tFileItem1.FirstStackedPath, "VIDEO_TS")
                    strPath = Path.Combine(strPath, "VIDEO_TS.IFO")
                    If File.Exists(strPath) Then
                        'VIDEO_TS structure found, change folder to file
                        _fileitemlist(i) = New FileItem(strPath)
                    End If
                    'check if BDMV
                    strPath = Path.Combine(tFileItem1.FirstStackedPath, "index.bdmv")
                    If File.Exists(strPath) Then
                        'BDMV structure found, change folder to file
                        _fileitemlist(i) = New FileItem(strPath)
                    Else
                        strPath = Path.Combine(tFileItem1.FirstStackedPath, "BDMV")
                        strPath = Path.Combine(strPath, "index.bdmv")
                        If File.Exists(strPath) Then
                            'BDMV structure found, change folder to file
                            _fileitemlist(i) = New FileItem(strPath)
                        End If
                    End If
                End If
            End If
            i += 1
        End While
    End Sub

    Public Sub StackFiles()
        Dim strFileStackingPattern As String = AdvancedSettings.GetSetting("FileStacking", "(.*?)([ _.-]*(?:cd|dvd|p(?:ar)?t|dis[ck])[ _.-]*[0-9]+)(.*?)(\.[^.]+)$")

        'now stack the files, some of which may be from the previous stack iteration
        Dim i As Integer = 0
        While i < _fileitemlist.Count
            If Not _fileitemlist(i).bIsDirectory AndAlso Not _fileitemlist(i).bIsBDMV AndAlso Not _fileitemlist(i).bIsVideoTS Then
                Dim iStack As New List(Of Integer)
                Dim lngSize As Long = 0
                Dim strStackName As String = String.Empty
                Dim tFileItem1 As FileItem = GetItem(i)

                Dim rResultFileItem1 As Match = Regex.Match(tFileItem1.FileInfo.Name, strFileStackingPattern, RegexOptions.IgnoreCase)
                If rResultFileItem1.Success Then
                    Dim strTitle1 As String = rResultFileItem1.Groups(1).Value
                    Dim strVolume1 As String = rResultFileItem1.Groups(2).Value
                    Dim strIgnore1 As String = rResultFileItem1.Groups(3).Value
                    Dim strExtension1 As String = rResultFileItem1.Groups(4).Value

                    Dim j As Integer = i + 1
                    While j < _fileitemlist.Count
                        Dim tFileItem2 As FileItem = GetItem(j)

                        Dim rResultFileItem2 As Match = Regex.Match(tFileItem2.FileInfo.Name, strFileStackingPattern, RegexOptions.IgnoreCase)
                        If rResultFileItem2.Success Then
                            Dim strTitle2 As String = rResultFileItem2.Groups(1).Value
                            Dim strVolume2 As String = rResultFileItem2.Groups(2).Value
                            Dim strIgnore2 As String = rResultFileItem2.Groups(3).Value
                            Dim strExtension2 As String = rResultFileItem2.Groups(4).Value

                            If strTitle1.ToLower = strTitle2.ToLower Then
                                If Not strVolume1.ToLower = strVolume2.ToLower Then
                                    If strIgnore1.ToLower = strIgnore2.ToLower AndAlso strExtension1.ToLower = strExtension2.ToLower Then
                                        If iStack.Count = 0 Then
                                            strStackName = String.Concat(strTitle1, strIgnore1, strExtension1)
                                            iStack.Add(i)
                                            lngSize = tFileItem1.FileInfo.Length
                                        End If
                                        iStack.Add(j)
                                        lngSize = tFileItem2.FileInfo.Length
                                    Else 'Sequel
                                        Exit While
                                    End If
                                Else 'False positive, try again with offset
                                    Exit While
                                End If
                            Else 'Title mismatch
                                Exit While
                            End If
                        End If
                        j += 1
                    End While
                End If

                If iStack.Count > 1 Then
                    'have a stack, remove the items And add the stacked item
                    'dont actually stack a multipart rar set, just remove all items but the first
                    Dim strStackedPath As String = FileUtils.Stacking.ConstructStackPath(Me, iStack)
                    tFileItem1.SetPath(strStackedPath)

                    'clean up list
                    Dim k As Integer = 1
                    While k < iStack.Count
                        RemoveItem(i + 1)
                        k += 1
                    End While

                    tFileItem1.StackedTitle = Path.GetFileNameWithoutExtension(strStackName)
                End If
            End If
            i += 1
        End While
    End Sub

#End Region 'Methods

End Class
