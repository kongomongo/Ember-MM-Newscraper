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

Public Class DiscImage

#Region "Fields"

    Private _bismounted As Boolean
    Private _strcommandunmount As String
    Private _strDriveLetter As String

#End Region  'Fields

#Region "Constructors"

    Public Sub New()
        Clear()
    End Sub

#End Region 'Constructors

#Region "Properties"

    Public ReadOnly Property IsMounted() As Boolean
        Get
            Return Not String.IsNullOrEmpty(_strDriveLetter)
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            If Not String.IsNullOrEmpty(_strDriveLetter) Then
                Return String.Concat(_strDriveLetter, ":\")
            Else
                Return String.Empty
            End If
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Sub Clear()
        _bismounted = False
        _strcommandunmount = String.Empty
        _strDriveLetter = String.Empty
    End Sub

    Public Sub Mount(ByVal strPath As String)
        'ISO-File Scanning using either DAIMON Tools / VCDMount.exe to mount and read file!
        Dim driveletter As String = Master.eSettings.Options.Filesystem.VirtualDriveDriveLetter ' i.e. "F"
        'Toolpath either VCDMOUNT.exe or DTLite.exe!
        Dim strToolPath As String = Master.eSettings.Options.Filesystem.VirtualDriveAppPath

        'Now only use DAEMON Tools to mount ISO if installed on user system
        If Not String.IsNullOrEmpty(driveletter) AndAlso Not String.IsNullOrEmpty(strToolPath) Then

            'Either DAEMONToolsLite or VirtualCloneDrive (http://www.slysoft.com/en/virtual-clonedrive.html)
            If strToolPath.ToLower.Contains("vcdmount") Then
                'Unmount, i.e "C:\Program Files\Elaborate Bytes\VirtualCloneDrive\VCDMount.exe" /u
                _strcommandunmount = String.Concat("/u")
                Functions.Run_Process(strToolPath, _strcommandunmount, False, True)
                'Mount
                'Mount ISO on virtual drive, i.e c:\Program Files (x86)\Elaborate Bytes\VirtualCloneDrive\vcdmount.exe U:\isotest\test2iso.ISO
                Functions.Run_Process(strToolPath, """" & strPath & """", False, True)
                _strDriveLetter = driveletter

                'Toolpath doesn't contain vcdmount.exe -> assume daemon tools with DS type drive!
            Else
                'Unmount
                _strcommandunmount = "-unmount dt, 0"
                Functions.Run_Process(strToolPath, _strcommandunmount, False, True)
                'Mount
                'Mount ISO on Daemon Tools (Lite), i.e. C:\Program Files\DAEMON Tools Lite\DTAgent.exe -mount dt, 0, "U:\isotest\test2iso.ISO"
                Functions.Run_Process(strToolPath, String.Format("-mount dt, 0, ""{0}""", strPath), False, True)
                _strDriveLetter = driveletter
            End If
        End If
    End Sub

    Public Sub Unmount()
        If Not String.IsNullOrEmpty(_strcommandunmount) Then
            Functions.Run_Process(Master.eSettings.Options.Filesystem.VirtualDriveAppPath, _strcommandunmount, False, True)
            _strDriveLetter = String.Empty
        End If
    End Sub

#End Region 'Methods

End Class