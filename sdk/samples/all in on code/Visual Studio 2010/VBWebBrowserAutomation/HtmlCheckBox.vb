﻿'*************************** Module Header ******************************'
' Module Name:  HtmlCheckBox.vb
' Project:	    VBWebBrowserAutomation
' Copyright (c) Microsoft Corporation.
' 
' This class HtmlCheckBox represents an HtmlElement with the tag "input" and its 
' type is "checkbox".
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.Security.Permissions

Public Class HtmlCheckBox
    Inherits HtmlInputElement

    Public Property Checked() As Boolean

    ''' <summary>
    ''' This parameterless constructor is used in deserialization.
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Initialize an instance of HtmlCheckBox. This constructor is used by 
    ''' HtmlInputElementFactory.
    ''' </summary>
    <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
    Public Sub New(ByVal element As HtmlElement)
        MyBase.New(element.Id)

        ' The checkbox is checked if it has the attribute "checked".
        Dim chekced As String = element.GetAttribute("checked")
        Checked = Not String.IsNullOrEmpty(chekced)
    End Sub

    ''' <summary>
    ''' Set the value of the HtmlElement.
    ''' </summary>
    <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
    Public Overrides Sub SetValue(ByVal element As HtmlElement)
        ' The checkbox is checked if it has the attribute "checked".
        If Checked Then
            element.SetAttribute("checked", "checked")
        Else
            element.SetAttribute("checked", Nothing)
        End If
    End Sub

End Class
