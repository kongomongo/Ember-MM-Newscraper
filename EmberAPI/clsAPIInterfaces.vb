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

Public Class Interfaces

    Public Interface Addon

#Region "Events"

        Event GenericEvent(ByVal eType As Enums.AddonEventType, ByRef _params As List(Of Object))
        Event NeedsRestart()
        Event SettingsChanged()
        Event StateChanged(ByVal strName As String, ByVal bEnabled As Boolean)

#End Region 'Events

#Region "Properties"

        ReadOnly Property Capabilities_AddonEventTypes() As List(Of Enums.AddonEventType)
        ReadOnly Property Capabilities_ScraperCapatibilities() As List(Of Enums.ScraperCapatibility)
        Property Enabled() As Boolean
        ReadOnly Property IsBusy() As Boolean
        ReadOnly Property Shortname() As String
        ReadOnly Property Version() As String

#End Region 'Properties

#Region "Methods"

        Sub Init(ByVal strAssemblyName As String)
        Function InjectSettingsPanel() As Containers.SettingsPanel
        Function Run(ByRef tDBElement As Database.DBElement, ByVal eAddonEventType As Enums.AddonEventType, ByVal lstCommandLineParams As List(Of Object)) As AddonResult
        Sub SaveSetup(ByVal bDoDispose As Boolean)

#End Region 'Methods

    End Interface

    Public Interface MasterSettingsPanel

#Region "Events"

        Event NeedsDBClean_Movie()
        Event NeedsDBClean_TV()
        Event NeedsDBUpdate_Movie()
        Event NeedsDBUpdate_TV()
        Event NeedsReload_Movie()
        Event NeedsReload_MovieSet()
        Event NeedsReload_TVEpisode()
        Event NeedsReload_TVShow()
        Event NeedsRestart()
        Event SettingsChanged()

#End Region 'Events

#Region "Properties"

        ReadOnly Property Order() As Integer

#End Region 'Properties

#Region "Methods"

        Function InjectSettingsPanel() As Containers.SettingsPanel

        Sub DoDispose()

        Sub SaveSetup()

#End Region 'Methods

    End Interface

    '    ' Interfaces for external Modules
    '    Public Interface GenericModule

    '#Region "Events"

    '        Event ModuleSettingsChanged()
    '        Event SetupNeedsRestart()
    '        Event ModuleSetupChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer)

    '#End Region 'Events

    '#Region "Properties"

    '        Property Enabled() As Boolean
    '        ReadOnly Property IsBusy() As Boolean
    '        ReadOnly Property ModuleName() As String
    '        ReadOnly Property ModuleType() As List(Of Enums.ModuleEventType)
    '        ReadOnly Property ModuleVersion() As String

    '#End Region 'Properties

    '#Region "Methods"

    '        Sub Init(ByVal sAssemblyName As String, ByVal sExecutable As String)
    '        Function InjectSetup() As Containers.SettingsPanel
    '        Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _singleobjekt As Object, ByRef _dbelement As Database.DBElement) As ModuleResult_old
    '        Sub SaveSetup(ByVal DoDispose As Boolean)

    '#End Region 'Methods

    '    End Interface

#Region "Nested Types"

    Public Class AddonResult

#Region "Fields"

        Public bBreakChain As Boolean
        Public bCancelled As Boolean
        Public ScraperResult_Data As New MediaContainers.MainDetails
        Public ScraperResult_ImageContainer As New MediaContainers.SearchResultsContainer
        Public ScraperResult_Themes As New List(Of MediaContainers.Theme)
        Public ScraperResult_Trailers As New List(Of MediaContainers.Trailer)
        Public SearchResults As New List(Of MediaContainers.MainDetails)

#End Region 'Fields

    End Class

#End Region 'Nested Types

End Class