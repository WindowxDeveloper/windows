﻿'****************************** Module Header ******************************'
' Module Name:  MainModule.vb
' Project:      VBAutomatePowerPoint
' Copyright (c) Microsoft Corporation.
' 
' The VBAutomatePowerPoint example demonstrates the use of VB.NET code to  
' create a Microsoft PowerPoint instance, add a new presentation, insert a 
' new slide, add some texts to the slide, save the presentation, quit 
' PowerPoint and clean up unmanaged COM resources.
' 
' Office automation is based on Component Object Model (COM). When you call a 
' COM object of Office from managed code, a Runtime Callable Wrapper (RCW) is 
' automatically created. The RCW marshals calls between the .NET application 
' and the COM object. The RCW keeps a reference count on the COM object. If 
' all references have not been released on the RCW, the COM object of Office 
' does not quit and may cause the Office application not to quit after your 
' automation. In order to make sure that the Office application quits cleanly, 
' the sample demonstrates two solutions.
' 
' Solution1.AutomatePowerPoint demonstrates automating Microsoft PowerPoint 
' application by using Microsoft PowerPoint Primary Interop Assembly (PIA) 
' and explicitly assigning each COM accessor object to a new varaible that 
' you would explicitly call Marshal.FinalReleaseComObject to release it at 
' the end. 
' 
' Solution2.AutomatePowerPoint demonstrates automating Microsoft PowerPoint 
' application by using Microsoft PowerPoint PIA and forcing a garbage 
' collection as soon as the automation function is off the stack (at which 
' point the RCW objects are no longer rooted) to clean up RCWs and release 
' COM objects.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************'


Module MainModule

    <STAThread()> _
    Sub Main()

        ' Solution1.AutomatePowerPoint demonstrates automating Microsoft 
        ' PowerPoint application by using Microsoft PowerPoint PIA and 
        ' explicitly assigning each COM accessor object to a new varaible 
        ' that you would explicitly call Marshal.FinalReleaseComObject to 
        ' release it at the end. 
        Solution1.AutomatePowerPoint()

        Console.WriteLine()

        ' Solution2.AutomatePowerPoint demonstrates automating Microsoft 
        ' PowerPoint application by using Microsoft PowerPoint PIA and 
        ' forcing a garbage collection as soon as the automation function is 
        ' off the stack (at which point the RCW objects are no longer rooted) 
        ' to clean up RCWs and release COM objects.
        Solution2.AutomatePowerPoint()

    End Sub

End Module
