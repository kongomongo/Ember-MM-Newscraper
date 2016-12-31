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

Imports EmberAPI
Imports NLog
Imports System.Text.RegularExpressions

Public Class frmSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Private _stations As List(Of String)

#End Region 'Fields

#Region "Events"

    Public Event NeedsRestart()
    Public Event SettingsChanged()
    Public Event StateChanged(ByVal bEnabled As Boolean)

#End Region 'Events

#Region "Properties"

    Public Property Stations() As List(Of String)
        Get
            Return _stations
        End Get
        Set(value As List(Of String))
            _stations = value
        End Set
    End Property


#End Region 'Properties

#Region "Constructors"

    Public Sub New()
        InitializeComponent()
        SetUp()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Sub btnGetAllStations_Click(sender As Object, e As EventArgs) Handles btnGetAllStations.Click
        Dim nResult = clsFernsehserienDE.GetAllStations
        If nResult.Count > 0 Then
            _stations = nResult
        Else
            System.Windows.Forms.MessageBox.Show("text", "title", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRegexTest_Click(sender As Object, e As EventArgs) Handles btnRegexTest.Click
        If Not String.IsNullOrEmpty(txtRegexFilename.Text.Trim) AndAlso Not String.IsNullOrEmpty(txtRegexTestExampleFilename.Text.Trim) Then
            Try
                Dim rTestResults = Regex.Match(txtRegexTestExampleFilename.Text.Trim, txtRegexFilename.Text.Trim, RegexOptions.IgnoreCase)
                If rTestResults.Success Then
                    SetRegexTestResult_Successful()
                    SetValueLabel(rTestResults, RegexGroup.Day)
                    SetValueLabel(rTestResults, RegexGroup.Hour)
                    SetValueLabel(rTestResults, RegexGroup.Minute)
                    SetValueLabel(rTestResults, RegexGroup.Month)
                    SetValueLabel(rTestResults, RegexGroup.Station)
                    SetValueLabel(rTestResults, RegexGroup.Year)
                Else
                    SetRegexTestResult_Failed()
                End If
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
                SetRegexTestResult_Failed()
            End Try
        Else
            SetRegexTestResult_Empty()
        End If
    End Sub

    Private Sub chkEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkEnabled.CheckedChanged
        RaiseEvent StateChanged(chkEnabled.Checked)
    End Sub

    Private Sub SetRegexTestResult_Empty()
        lblRegexTestResultValue.Text = "Empty regex or file name"
        lblRegexTestResultValue.ForeColor = Drawing.Color.Red
        SetValueLabel_NotTested(lblRegexTestDayValue)
        SetValueLabel_NotTested(lblRegexTestHourValue)
        SetValueLabel_NotTested(lblRegexTestMinuteValue)
        SetValueLabel_NotTested(lblRegexTestMonthValue)
        SetValueLabel_NotTested(lblRegexTestStationValue)
        SetValueLabel_NotTested(lblRegexTestYearValue)
    End Sub

    Private Sub SetRegexTestResult_Failed()
        lblRegexTestResultValue.Text = "Failed"
        lblRegexTestResultValue.ForeColor = Drawing.Color.Red
        SetValueLabel_NotTested(lblRegexTestDayValue)
        SetValueLabel_NotTested(lblRegexTestHourValue)
        SetValueLabel_NotTested(lblRegexTestMinuteValue)
        SetValueLabel_NotTested(lblRegexTestMonthValue)
        SetValueLabel_NotTested(lblRegexTestStationValue)
        SetValueLabel_NotTested(lblRegexTestYearValue)
    End Sub

    Private Sub SetRegexTestResult_Successful()
        lblRegexTestResultValue.Text = "Successful"
        lblRegexTestResultValue.ForeColor = Drawing.Color.Green
    End Sub

    Private Sub SetValueLabel(ByVal rTestResult As Match, ByVal eGroup As RegexGroup)
        Dim nLabel As System.Windows.Forms.Label = Nothing
        Dim strValue As String = rTestResult.Groups(eGroup.ToString.ToUpper).Value

        Select Case eGroup
            Case RegexGroup.Day
                nLabel = lblRegexTestDayValue
            Case RegexGroup.Hour
                nLabel = lblRegexTestHourValue
            Case RegexGroup.Minute
                nLabel = lblRegexTestMinuteValue
            Case RegexGroup.Month
                nLabel = lblRegexTestMonthValue
            Case RegexGroup.Station
                nLabel = lblRegexTestStationValue
            Case RegexGroup.Year
                nLabel = lblRegexTestYearValue
        End Select

        If nLabel IsNot Nothing Then
            If Not String.IsNullOrEmpty(strValue.Trim) Then
                SetValueLabel_Succsessful(nLabel, strValue.Trim)
            Else
                SetValueLabel_NoResult(nLabel)
            End If
        End If
    End Sub

    Private Sub SetValueLabel_NoResult(ByVal tLabel As System.Windows.Forms.Label)
        tLabel.Text = "empty result or group not found"
        tLabel.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub SetValueLabel_NotTested(ByVal tLabel As System.Windows.Forms.Label)
        tLabel.Text = "not tested"
        tLabel.ForeColor = Drawing.Color.Black
    End Sub

    Private Sub SetValueLabel_Succsessful(ByVal tLabel As System.Windows.Forms.Label, ByVal strValue As String)
        tLabel.Text = strValue
        tLabel.ForeColor = Drawing.Color.Green
    End Sub

    Private Sub SetUp()

    End Sub

#End Region 'Methods

#Region "Nested Types"

    Private Enum RegexGroup
        Day = 0
        Hour = 1
        Minute = 2
        Month = 3
        Station = 4
        Year = 5
    End Enum

#End Region 'Nested Types

End Class