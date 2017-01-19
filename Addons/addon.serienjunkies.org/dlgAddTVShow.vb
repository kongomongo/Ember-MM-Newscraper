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
Imports System.Web

Public Class dlgAddTVShow

#Region "Constructors"

    Public Sub New(ByVal strTitle As String, ByVal strURL As String)
        ' This call is required by the designer.
        InitializeComponent()
        Left = Master.AppPos.Left + (Master.AppPos.Width - Width) \ 2
        Top = Master.AppPos.Top + (Master.AppPos.Height - Height) \ 2
        StartPosition = FormStartPosition.Manual
        SetUp()
        txtTitle.Text = strTitle
        txtURL.Text = strURL
    End Sub

#End Region 'Constructors

#Region "Methodes"

    Private Sub dlgAddTVShow_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtURL.Focus()
    End Sub

    Private Sub btnOpenURL_Click(sender As Object, e As EventArgs) Handles btnOpenURL.Click
        Functions.Launch(txtURL.Text.Trim)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Functions.Launch(String.Concat(My.Resources.urlDefaultOverview, HttpUtility.UrlEncode(txtTitle.Text).Replace("+", "-").ToLower, "/"))
        txtURL.Focus()
    End Sub

    Private Sub SetUp()
        btnAdd.Text = Master.eLang.GetString(28, "Add")
        btnCancel.Text = Master.eLang.GetString(167, "Cancel")
        btnOpenURL.Text = Master.eLang.GetString(328, "Open")
        btnSearch.Text = Master.eLang.GetString(977, "Search")
        btnSkip.Text = Master.eLang.GetString(336, "Skip")
        lblTitle.Text = Master.eLang.GetString(21, "Title")
        lblURL.Text = Master.eLang.GetString(1323, "URL")
    End Sub

    Private Sub txtURL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtURL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged
        btnOpenURL.Enabled = Not String.IsNullOrEmpty(txtURL.Text.Trim)
    End Sub

#End Region 'Methodes

End Class