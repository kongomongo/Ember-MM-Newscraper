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

#Region "Nested Interfaces"

    Public Interface ExternalModule

#Region "Events"

        Event NeedsRestart()
        Event SettingsChanged()

#End Region 'Events

#Region "Properties"

        ReadOnly Property Capabilities_Modifier() As List(Of Enums.ScrapeModifierType)
        ReadOnly Property Capabilities_ScrapeOptions() As Structures.ScrapeOptions
        Property Enabled() As Boolean
        ReadOnly Property IsBusy() As Boolean
        ReadOnly Property ModuleName() As String
        ReadOnly Property ModuleEventType() As List(Of Enums.ModuleEventType)
        ReadOnly Property ModuleVersion() As String

#End Region 'Properties

#Region "Methods"

        Sub Init(ByVal strAssemblyName As String)
        Function InjectSettingsPanel() As Containers.SettingsPanel
        Function QueryScraperCapabilities(ByVal tScrapeModifierType As Enums.ScrapeModifierType, ByVal tContentType As Enums.ContentType) As Boolean
        Function Run(ByRef tDBElement As Database.DBElement) As ModuleResult
        Sub SaveSetup(ByVal bDoDispose As Boolean)

#End Region 'Methods

    End Interface

    ' Interfaces for external Modules
    Public Interface GenericModule

#Region "Events"

        Event GenericEvent(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object))
        Event ModuleSettingsChanged()
        Event SetupNeedsRestart()
        Event ModuleSetupChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer)

#End Region 'Events

#Region "Properties"

        Property Enabled() As Boolean
        ReadOnly Property IsBusy() As Boolean
        ReadOnly Property ModuleName() As String
        ReadOnly Property ModuleType() As List(Of Enums.ModuleEventType)
        ReadOnly Property ModuleVersion() As String

#End Region 'Properties

#Region "Methods"

        Sub Init(ByVal sAssemblyName As String, ByVal sExecutable As String)
        Function InjectSetup() As Containers.SettingsPanel
        Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _singleobjekt As Object, ByRef _dbelement As Database.DBElement) As ModuleResult_old
        Sub SaveSetup(ByVal DoDispose As Boolean)

#End Region 'Methods

    End Interface

#End Region 'Nested Interfaces

#Region "Nested Types"

    Public Structure ModuleResult

#Region "Fields"

        Public bBreakChain As Boolean
        Public bCancelled As Boolean
        Public ScraperResult_Data As MediaContainers.MainDetails
        Public ScraperResult_Image As MediaContainers.SearchResultsContainer
        Public ScraperResult_Theme As List(Of MediaContainers.Theme)
        Public ScraperResult_Trailer As List(Of MediaContainers.Trailer)
        Public SearchResults As List(Of MediaContainers.MainDetails)

#End Region 'Fields

    End Structure
    ''' <summary>
    ''' This structure is returned by most scraper interfaces to represent the
    ''' status of the operation that was requested
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure ModuleResult_old

#Region "Fields"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public breakChain As Boolean
        ''' <summary>
        ''' An error has occurred in the module, and its operation has been cancelled. 
        ''' </summary>
        ''' <remarks></remarks>
        Public Cancelled As Boolean

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class