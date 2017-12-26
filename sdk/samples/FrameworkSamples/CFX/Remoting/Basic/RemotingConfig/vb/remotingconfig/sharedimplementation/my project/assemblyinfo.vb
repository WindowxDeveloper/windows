 '---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Security.Permissions


' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

<assembly: AssemblyTitle("SharedInterface")>

<assembly: AssemblyDescription("")>

<assembly: AssemblyConfiguration("")>

<assembly: AssemblyCompany("Microsoft")>

<assembly: AssemblyProduct("SharedInterface")>

<Assembly: AssemblyCopyright("Copyright @ Microsoft")> 

<assembly: AssemblyTrademark("")>

<assembly: AssemblyCulture("")> 
'/  Setting ComVisible to false makes the types in this assembly not visible 
'/  to COM componenets.  If you need to access a type in this assembly from 
'/  COM, set the ComVisible attribute to true on that type.

<assembly: ComVisible(False)> 
' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Revision and Build Numbers 
' by using the '*' as shown below:

<assembly: AssemblyVersion("1.0.*")>

<assembly: CLSCompliant(True)>

<assembly: PermissionSet(SecurityAction.RequestMinimum, Name := "FullTrust")>
