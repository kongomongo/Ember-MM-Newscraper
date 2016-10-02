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
Imports System.Xml.Serialization


<Serializable()>
Public Class ModuleSettings

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _settings As New ModuleSetting
    Private _xmlpath As String

#End Region 'Fields

#Region "Properties"
    Public Property Settings() As ModuleSetting
        Get
            Return _settings
        End Get
        Set(ByVal Value As ModuleSetting)
            _settings = Value
        End Set
    End Property
    Public ReadOnly Property XMLPath() As String
        Get
            Return _xmlpath
        End Get
    End Property

#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        Clear()
        _xmlpath = Path.Combine(Master.SettingsPath, Path.GetFileNameWithoutExtension(Reflection.Assembly.GetCallingAssembly().Location), "settings.xml")
    End Sub

#End Region 'Constructors

#Region "Methods"

    Public Sub Clear()
        _settings = New ModuleSetting
    End Sub

    Public Sub AddBooleanSetting(ByVal strID As String, ByVal bDefaultValue As Boolean, Optional ByVal cContent As Enums.ContentType = Enums.ContentType.None)
        Dim v = _settings.BooleanSettings.FirstOrDefault(Function(f) f.ID = strID AndAlso f.ContentType = cContent)
        If v Is Nothing Then
            _settings.BooleanSettings.Add(New BooleanSetting With {
                                          .ID = strID,
                                          .DefaultValue = bDefaultValue,
                                          .Value = bDefaultValue})
        Else
            'case if the default value has been changed on an existing setting
            _settings.BooleanSettings.FirstOrDefault(Function(f) f.ID = strID).DefaultValue = bDefaultValue
        End If
    End Sub

    Public Sub AddIntegerSetting(ByVal strID As String, ByVal iDefaultValue As Integer, Optional ByVal cContent As Enums.ContentType = Enums.ContentType.None)
        Dim v = _settings.IntegerSettings.FirstOrDefault(Function(f) f.ID = strID)
        If v Is Nothing Then
            _settings.IntegerSettings.Add(New IntegerSetting With {
                                          .ID = strID,
                                          .DefaultValue = iDefaultValue,
                                          .Value = iDefaultValue})
        Else
            'case if the default value has been changed on an existing setting
            _settings.IntegerSettings.FirstOrDefault(Function(f) f.ID = strID).DefaultValue = iDefaultValue
        End If
    End Sub

    Public Sub AddStringSetting(ByVal strID As String, ByVal strDefaultValue As String, Optional ByVal cContent As Enums.ContentType = Enums.ContentType.None)
        Dim v = _settings.StringSettings.FirstOrDefault(Function(f) f.ID = strID)
        If v Is Nothing Then
            _settings.StringSettings.Add(New StringSetting With {
                                         .ID = strID,
                                         .DefaultValue = strDefaultValue,
                                         .Value = strDefaultValue})
        Else
            'case if the default value has been changed on an existing setting
            _settings.StringSettings.FirstOrDefault(Function(f) f.ID = strID).DefaultValue = strDefaultValue
        End If
    End Sub

    Public Function GetBooleanSetting(ByVal strID As String, Optional ByVal tContent As Enums.ContentType = Enums.ContentType.None) As Boolean
        Dim v = _settings.BooleanSettings.FirstOrDefault(Function(f) f.ID = strID AndAlso f.ContentType = tContent)
        Return If(v Is Nothing, False, v.Value)
    End Function

    Public Function GetComplexSetting(ByVal strID As String) As ComplexSetting
        Try
            Dim v = _settings.ComplexSettings.FirstOrDefault(Function(f) f.ID = strID)
            Return If(v Is Nothing, Nothing, v)
        Catch ex As Exception
            logger.Warn(ex, New StackFrame().GetMethod().Name)
            Return Nothing
        End Try
    End Function

    Public Function GetIntegerSetting(ByVal strID As String, Optional ByVal tContent As Enums.ContentType = Enums.ContentType.None) As Integer
        Dim v = _settings.IntegerSettings.FirstOrDefault(Function(f) f.ID = strID AndAlso f.ContentType = tContent)
        Return If(v Is Nothing, -1, v.Value)
    End Function

    Public Function GetStringSetting(ByVal strID As String, Optional ByVal cContent As Enums.ContentType = Enums.ContentType.None) As String
        Dim v = _settings.StringSettings.FirstOrDefault(Function(f) f.ID = strID AndAlso f.ContentType = cContent)
        Return If(v Is Nothing, String.Empty, v.Value)
    End Function

    Public Sub Load()
        If File.Exists(_xmlpath) Then
            Try
                Dim objStreamReader As New StreamReader(_xmlpath)
                Dim xModuleSettings As New XmlSerializer(GetType(ModuleSetting))
                _settings = CType(xModuleSettings.Deserialize(objStreamReader), ModuleSetting)
                objStreamReader.Close()
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
                _settings = New ModuleSetting
            End Try
        Else
            _settings = New ModuleSetting
        End If
    End Sub

    Public Sub Save()
        If Not File.Exists(_xmlpath) OrElse (Not CBool(File.GetAttributes(_xmlpath) And FileAttributes.ReadOnly)) Then
            If File.Exists(_xmlpath) Then
                Dim fAtt As FileAttributes = File.GetAttributes(_xmlpath)
                Try
                    File.SetAttributes(_xmlpath, FileAttributes.Normal)
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
            End If
            If Not Directory.Exists(Directory.GetParent(_xmlpath).FullName) Then Directory.CreateDirectory(Directory.GetParent(_xmlpath).FullName)
            Using xmlSW As New StreamWriter(_xmlpath)
                Dim xmlSer As New XmlSerializer(GetType(ModuleSetting))
                xmlSer.Serialize(xmlSW, _settings)
            End Using
        End If
    End Sub

    'Public Function AddComplexSetting(ByVal strID As String, ByVal lstComplexSettings As List(Of ModuleSettingsComplexSettingsTableItem)) As Boolean
    '    Dim v = _complexsettings.FirstOrDefault(Function(f) f.Table.ID = strID)
    '    If v Is Nothing Then
    '        _complexsettings.Add(New ModuleSettingsComplexSettings With {.Table = New ModuleSettingsComplexSettingsTable With {.ID = strID, .Items = lstComplexSettings}})
    '    Else
    '        _complexsettings.FirstOrDefault(Function(f) f.Table.ID = strID).Table.Items = lstComplexSettings
    '    End If
    '    Return True
    'End Function

#End Region 'Methods

#Region "Nested Types"

    <Serializable()>
    <XmlRoot("settings")>
    Public Class ModuleSetting

#Region "Fields"

        Private _booleansettings As New List(Of BooleanSetting)
        Private _complexsettings As New List(Of ComplexSetting)
        Private _integersettings As New List(Of IntegerSetting)
        Private _stringsettings As New List(Of StringSetting)

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlElement("booleansetting")>
        Public Property BooleanSettings() As List(Of BooleanSetting)
            Get
                Return _booleansettings
            End Get
            Set(ByVal Value As List(Of BooleanSetting))
                _booleansettings = Value
            End Set
        End Property

        <XmlElement("integersetting")>
        Public Property IntegerSettings() As List(Of IntegerSetting)
            Get
                Return _integersettings
            End Get
            Set(ByVal Value As List(Of IntegerSetting))
                _integersettings = Value
            End Set
        End Property

        <XmlElement("stringsetting")>
        Public Property StringSettings() As List(Of StringSetting)
            Get
                Return _stringsettings
            End Get
            Set(ByVal Value As List(Of StringSetting))
                _stringsettings = Value
            End Set
        End Property

        <XmlElement("complexsetting")>
        Public Property ComplexSettings() As List(Of ComplexSetting)
            Get
                Return _complexsettings
            End Get
            Set(ByVal Value As List(Of ComplexSetting))
                _complexsettings = Value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            _booleansettings = New List(Of BooleanSetting)
            _complexsettings = New List(Of ComplexSetting)
            _integersettings = New List(Of IntegerSetting)
            _stringsettings = New List(Of StringSetting)
        End Sub

#End Region 'Methods

    End Class

    <Serializable()>
    Public Class BooleanSetting

#Region "Fields"

        Private _contenttype As Enums.ContentType
        Private _defaultvalue As Boolean
        Private _id As String
        Private _value As Boolean

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlAttribute("id")>
        Public Property ID() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        <XmlAttribute("contenttype")>
        Public Property ContentType() As Enums.ContentType
            Get
                Return _contenttype
            End Get
            Set(ByVal Value As Enums.ContentType)
                _contenttype = Value
            End Set
        End Property

        <XmlAttribute("defaultvalue")>
        Public Property DefaultValue() As Boolean
            Get
                Return _defaultvalue
            End Get
            Set(ByVal Value As Boolean)
                _defaultvalue = Value
            End Set
        End Property

        <XmlText()>
        Public Property Value() As Boolean
            Get
                Return _value
            End Get
            Set(ByVal Value As Boolean)
                _value = Value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            _contenttype = Enums.ContentType.None
            _defaultvalue = False
            _id = String.Empty
            _value = False
        End Sub

#End Region 'Methods

    End Class

    <Serializable()>
    Public Class ComplexSetting

#Region "Fields"

        Private _booleansettings As New List(Of BooleanSetting)
        Private _id As String
        Private _integersettings As New List(Of IntegerSetting)
        Private _stringsettings As New List(Of StringSetting)

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlAttribute("id")>
        Public Property ID() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        <XmlElement("booleansettings")>
        Public Property BooleanSettings() As List(Of BooleanSetting)
            Get
                Return _booleansettings
            End Get
            Set(ByVal Value As List(Of BooleanSetting))
                _booleansettings = Value
            End Set
        End Property

        <XmlElement("integersettings")>
        Public Property IntegerSettings() As List(Of IntegerSetting)
            Get
                Return _integersettings
            End Get
            Set(ByVal Value As List(Of IntegerSetting))
                _integersettings = Value
            End Set
        End Property

        <XmlElement("stringsettings")>
        Public Property stringSettings() As List(Of StringSetting)
            Get
                Return _stringsettings
            End Get
            Set(ByVal Value As List(Of StringSetting))
                _stringsettings = Value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            _booleansettings = New List(Of BooleanSetting)
            _id = String.Empty
            _integersettings = New List(Of IntegerSetting)
            _stringsettings = New List(Of StringSetting)
        End Sub

#End Region 'Methods

    End Class

    <Serializable()>
    Public Class IntegerSetting

#Region "Fields"

        Private _contenttype As Enums.ContentType
        Private _defaultvalue As Integer
        Private _id As String
        Private _value As Integer

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlAttribute("id")>
        Public Property ID() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        <XmlAttribute("contenttype")>
        Public Property ContentType() As Enums.ContentType
            Get
                Return _contenttype
            End Get
            Set(ByVal Value As Enums.ContentType)
                _contenttype = Value
            End Set
        End Property

        <XmlAttribute("defaultvalue")>
        Public Property DefaultValue() As Integer
            Get
                Return _defaultvalue
            End Get
            Set(ByVal Value As Integer)
                _defaultvalue = Value
            End Set
        End Property

        <XmlText()>
        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal Value As Integer)
                _value = Value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            _contenttype = Enums.ContentType.None
            _defaultvalue = -1
            _id = String.Empty
            _value = -1
        End Sub

#End Region 'Methods

    End Class

    <Serializable()>
    Public Class StringSetting

#Region "Fields"

        Private _contenttype As Enums.ContentType
        Private _defaultvalue As String
        Private _id As String
        Private _value As String

#End Region 'Fields

#Region "Constructors"

        Public Sub New()
            Clean()
        End Sub

#End Region 'Constructors

#Region "Properties"

        <XmlAttribute("id")>
        Public Property ID() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        <XmlAttribute("contenttype")>
        Public Property ContentType() As Enums.ContentType
            Get
                Return _contenttype
            End Get
            Set(ByVal Value As Enums.ContentType)
                _contenttype = Value
            End Set
        End Property

        <XmlAttribute("defaultvalue")>
        Public Property DefaultValue() As String
            Get
                Return _defaultvalue
            End Get
            Set(ByVal Value As String)
                _defaultvalue = Value
            End Set
        End Property

        <XmlText()>
        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal Value As String)
                _value = Value
            End Set
        End Property

#End Region 'Properties

#Region "Methods"

        Public Sub Clean()
            _contenttype = Enums.ContentType.None
            _defaultvalue = String.Empty
            _id = String.Empty
            _value = String.Empty
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class
