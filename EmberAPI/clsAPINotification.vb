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

Public Class Notifications

#Region "Fields"

#End Region 'Fields

#Region "Events"

#End Region 'Events

#Region "Properties"

#End Region 'Properties

#Region "Methods"

    Public Shared Sub Show(ByVal tNotification As Notification)

    End Sub

#End Region 'Methods

#Region "Nested Types"

    Public Class Notification

#Region "Fields"

        Private _eNotificationType As Enums.NotificationType
        Private _imgIcon As Drawing.Image
        Private _strMessage As String
        Private _strTitle As String

#End Region 'Fields

#Region "Events"

#End Region 'Events

#Region "Properties"

        Public Property NotificationType() As Enums.NotificationType
            Get
                Return _eNotificationType
            End Get
            Set(ByVal value As Enums.NotificationType)
                _eNotificationType = value
            End Set
        End Property

        Public Property Icon() As Drawing.Image
            Get
                Return _imgIcon
            End Get
            Set(ByVal value As Drawing.Image)
                _imgIcon = value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return _strMessage
            End Get
            Set(ByVal value As String)
                _strMessage = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return _strTitle
            End Get
            Set(ByVal value As String)
                _strTitle = value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub New(ByVal eNotificationType As Enums.NotificationType, ByVal strTitle As String, ByVal strMessage As String)
            _eNotificationType = eNotificationType
            _strMessage = strMessage
            _strTitle = strTitle
            _imgIcon = Nothing
        End Sub

        Public Sub New(ByVal eNotificationType As Enums.NotificationType, ByVal strTitle As String, ByVal strMessage As String, ByVal imgIcon As Drawing.Image)
            _eNotificationType = eNotificationType
            _strMessage = strMessage
            _strTitle = strTitle
            _imgIcon = imgIcon
        End Sub

#End Region 'Methods

#Region "Nested Types"

#End Region 'Nested Types

    End Class

#End Region 'Nested Types

End Class