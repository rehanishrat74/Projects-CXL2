﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4952
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.4952.
'
Namespace InfiniMarket
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="_DefaultSoap", [Namespace]:="http://tempuri.org/SingleSignIn/_Default")> _
<CLSCompliant(False)> Partial Public Class _Default
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private SignInOperationCompleted As System.Threading.SendOrPostCallback

        Private SignOutOperationCompleted As System.Threading.SendOrPostCallback

        Private AddUserOperationCompleted As System.Threading.SendOrPostCallback

        Private GetCustomerOperationCompleted As System.Threading.SendOrPostCallback

        Private GetDivisorOperationCompleted As System.Threading.SendOrPostCallback

        Private isCustomerExistsOperationCompleted As System.Threading.SendOrPostCallback

        Private IsLoggedInOperationCompleted As System.Threading.SendOrPostCallback

        Private ProcesOrderOperationCompleted As System.Threading.SendOrPostCallback

        Private CustomerOrderProcessOperationCompleted As System.Threading.SendOrPostCallback

        Private useDefaultCredentialsSetExplicitly As Boolean

        '''<remarks/>
        Public Sub New()
            MyBase.New()
            Me.Url = "http://service.infinimarket.com/Default.asmx"
            If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
                Me.UseDefaultCredentials = True
                Me.useDefaultCredentialsSetExplicitly = False
            Else
                Me.useDefaultCredentialsSetExplicitly = True
            End If
        End Sub

        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set(ByVal value As String)
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
                    MyBase.UseDefaultCredentials = False
                End If
                MyBase.Url = value
            End Set
        End Property

        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set(ByVal value As Boolean)
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = True
            End Set
        End Property

        '''<remarks/>
        Public Event SignInCompleted As SignInCompletedEventHandler

        '''<remarks/>
        Public Event SignOutCompleted As SignOutCompletedEventHandler

        '''<remarks/>
        Public Event AddUserCompleted As AddUserCompletedEventHandler

        '''<remarks/>
        Public Event GetCustomerCompleted As GetCustomerCompletedEventHandler

        '''<remarks/>
        Public Event GetDivisorCompleted As GetDivisorCompletedEventHandler

        '''<remarks/>
        Public Event isCustomerExistsCompleted As isCustomerExistsCompletedEventHandler

        '''<remarks/>
        Public Event IsLoggedInCompleted As IsLoggedInCompletedEventHandler

        '''<remarks/>
        Public Event ProcesOrderCompleted As ProcesOrderCompletedEventHandler

        '''<remarks/>
        Public Event CustomerOrderProcessCompleted As CustomerOrderProcessCompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/SignIn", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function SignIn(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("SignIn", New Object() {sXml})
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Function BeginSignIn(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SignIn", New Object() {sXml}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndSignIn(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Overloads Sub SignInAsync(ByVal sXml As String)
            Me.SignInAsync(sXml, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub SignInAsync(ByVal sXml As String, ByVal userState As Object)
            If (Me.SignInOperationCompleted Is Nothing) Then
                Me.SignInOperationCompleted = AddressOf Me.OnSignInOperationCompleted
            End If
            Me.InvokeAsync("SignIn", New Object() {sXml}, Me.SignInOperationCompleted, userState)
        End Sub

        Private Sub OnSignInOperationCompleted(ByVal arg As Object)
            If (Not (Me.SignInCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SignInCompleted(Me, New SignInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/SignOut", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function SignOut(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("SignOut", New Object() {sXml})
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Function BeginSignOut(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SignOut", New Object() {sXml}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndSignOut(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Overloads Sub SignOutAsync(ByVal sXml As String)
            Me.SignOutAsync(sXml, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub SignOutAsync(ByVal sXml As String, ByVal userState As Object)
            If (Me.SignOutOperationCompleted Is Nothing) Then
                Me.SignOutOperationCompleted = AddressOf Me.OnSignOutOperationCompleted
            End If
            Me.InvokeAsync("SignOut", New Object() {sXml}, Me.SignOutOperationCompleted, userState)
        End Sub

        Private Sub OnSignOutOperationCompleted(ByVal arg As Object)
            If (Not (Me.SignOutCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SignOutCompleted(Me, New SignOutCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/AddUser", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function AddUser(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("AddUser", New Object() {sXml})
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Function BeginAddUser(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("AddUser", New Object() {sXml}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndAddUser(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Overloads Sub AddUserAsync(ByVal sXml As String)
            Me.AddUserAsync(sXml, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub AddUserAsync(ByVal sXml As String, ByVal userState As Object)
            If (Me.AddUserOperationCompleted Is Nothing) Then
                Me.AddUserOperationCompleted = AddressOf Me.OnAddUserOperationCompleted
            End If
            Me.InvokeAsync("AddUser", New Object() {sXml}, Me.AddUserOperationCompleted, userState)
        End Sub

        Private Sub OnAddUserOperationCompleted(ByVal arg As Object)
            If (Not (Me.AddUserCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddUserCompleted(Me, New AddUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetCustomer", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function GetCustomer(ByVal CustomerUID As String) As Object
            Dim results() As Object = Me.Invoke("GetCustomer", New Object() {CustomerUID})
            Return CType(results(0), Object)
        End Function

        '''<remarks/>
        Public Function BeginGetCustomer(ByVal CustomerUID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomer", New Object() {CustomerUID}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndGetCustomer(ByVal asyncResult As System.IAsyncResult) As Object
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), Object)
        End Function

        '''<remarks/>
        Public Overloads Sub GetCustomerAsync(ByVal CustomerUID As String)
            Me.GetCustomerAsync(CustomerUID, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub GetCustomerAsync(ByVal CustomerUID As String, ByVal userState As Object)
            If (Me.GetCustomerOperationCompleted Is Nothing) Then
                Me.GetCustomerOperationCompleted = AddressOf Me.OnGetCustomerOperationCompleted
            End If
            Me.InvokeAsync("GetCustomer", New Object() {CustomerUID}, Me.GetCustomerOperationCompleted, userState)
        End Sub

        Private Sub OnGetCustomerOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetCustomerCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetCustomerCompleted(Me, New GetCustomerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetDivisor", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function GetDivisor() As Double
            Dim results() As Object = Me.Invoke("GetDivisor", New Object(-1) {})
            Return CType(results(0), Double)
        End Function

        '''<remarks/>
        Public Function BeginGetDivisor(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDivisor", New Object(-1) {}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndGetDivisor(ByVal asyncResult As System.IAsyncResult) As Double
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), Double)
        End Function

        '''<remarks/>
        Public Overloads Sub GetDivisorAsync()
            Me.GetDivisorAsync(Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub GetDivisorAsync(ByVal userState As Object)
            If (Me.GetDivisorOperationCompleted Is Nothing) Then
                Me.GetDivisorOperationCompleted = AddressOf Me.OnGetDivisorOperationCompleted
            End If
            Me.InvokeAsync("GetDivisor", New Object(-1) {}, Me.GetDivisorOperationCompleted, userState)
        End Sub

        Private Sub OnGetDivisorOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetDivisorCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDivisorCompleted(Me, New GetDivisorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/isCustomerExists", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function isCustomerExists(ByVal Customer_uid As String) As Boolean
            Dim results() As Object = Me.Invoke("isCustomerExists", New Object() {Customer_uid})
            Return CType(results(0), Boolean)
        End Function

        '''<remarks/>
        Public Function BeginisCustomerExists(ByVal Customer_uid As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("isCustomerExists", New Object() {Customer_uid}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndisCustomerExists(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), Boolean)
        End Function

        '''<remarks/>
        Public Overloads Sub isCustomerExistsAsync(ByVal Customer_uid As String)
            Me.isCustomerExistsAsync(Customer_uid, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub isCustomerExistsAsync(ByVal Customer_uid As String, ByVal userState As Object)
            If (Me.isCustomerExistsOperationCompleted Is Nothing) Then
                Me.isCustomerExistsOperationCompleted = AddressOf Me.OnisCustomerExistsOperationCompleted
            End If
            Me.InvokeAsync("isCustomerExists", New Object() {Customer_uid}, Me.isCustomerExistsOperationCompleted, userState)
        End Sub

        Private Sub OnisCustomerExistsOperationCompleted(ByVal arg As Object)
            If (Not (Me.isCustomerExistsCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent isCustomerExistsCompleted(Me, New isCustomerExistsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/IsLoggedIn", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function IsLoggedIn(ByVal Customer_uid As String) As Boolean
            Dim results() As Object = Me.Invoke("IsLoggedIn", New Object() {Customer_uid})
            Return CType(results(0), Boolean)
        End Function

        '''<remarks/>
        Public Function BeginIsLoggedIn(ByVal Customer_uid As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("IsLoggedIn", New Object() {Customer_uid}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndIsLoggedIn(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), Boolean)
        End Function

        '''<remarks/>
        Public Overloads Sub IsLoggedInAsync(ByVal Customer_uid As String)
            Me.IsLoggedInAsync(Customer_uid, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub IsLoggedInAsync(ByVal Customer_uid As String, ByVal userState As Object)
            If (Me.IsLoggedInOperationCompleted Is Nothing) Then
                Me.IsLoggedInOperationCompleted = AddressOf Me.OnIsLoggedInOperationCompleted
            End If
            Me.InvokeAsync("IsLoggedIn", New Object() {Customer_uid}, Me.IsLoggedInOperationCompleted, userState)
        End Sub

        Private Sub OnIsLoggedInOperationCompleted(ByVal arg As Object)
            If (Not (Me.IsLoggedInCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent IsLoggedInCompleted(Me, New IsLoggedInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/ProcesOrder", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function ProcesOrder(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("ProcesOrder", New Object() {_xml})
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Function BeginProcesOrder(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ProcesOrder", New Object() {_xml}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndProcesOrder(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Overloads Sub ProcesOrderAsync(ByVal _xml As String)
            Me.ProcesOrderAsync(_xml, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub ProcesOrderAsync(ByVal _xml As String, ByVal userState As Object)
            If (Me.ProcesOrderOperationCompleted Is Nothing) Then
                Me.ProcesOrderOperationCompleted = AddressOf Me.OnProcesOrderOperationCompleted
            End If
            Me.InvokeAsync("ProcesOrder", New Object() {_xml}, Me.ProcesOrderOperationCompleted, userState)
        End Sub

        Private Sub OnProcesOrderOperationCompleted(ByVal arg As Object)
            If (Not (Me.ProcesOrderCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ProcesOrderCompleted(Me, New ProcesOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/CustomerOrderProcess", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Function CustomerOrderProcess(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("CustomerOrderProcess", New Object() {_xml})
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Function BeginCustomerOrderProcess(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CustomerOrderProcess", New Object() {_xml}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndCustomerOrderProcess(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), String)
        End Function

        '''<remarks/>
        Public Overloads Sub CustomerOrderProcessAsync(ByVal _xml As String)
            Me.CustomerOrderProcessAsync(_xml, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub CustomerOrderProcessAsync(ByVal _xml As String, ByVal userState As Object)
            If (Me.CustomerOrderProcessOperationCompleted Is Nothing) Then
                Me.CustomerOrderProcessOperationCompleted = AddressOf Me.OnCustomerOrderProcessOperationCompleted
            End If
            Me.InvokeAsync("CustomerOrderProcess", New Object() {_xml}, Me.CustomerOrderProcessOperationCompleted, userState)
        End Sub

        Private Sub OnCustomerOrderProcessOperationCompleted(ByVal arg As Object)
            If (Not (Me.CustomerOrderProcessCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CustomerOrderProcessCompleted(Me, New CustomerOrderProcessCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub

        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing) _
                        OrElse (url Is String.Empty)) Then
                Return False
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024) _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return True
            End If
            Return False
        End Function
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub SignInCompletedEventHandler(ByVal sender As Object, ByVal e As SignInCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class SignInCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), String)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub SignOutCompletedEventHandler(ByVal sender As Object, ByVal e As SignOutCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class SignOutCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), String)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub AddUserCompletedEventHandler(ByVal sender As Object, ByVal e As AddUserCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class AddUserCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), String)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub GetCustomerCompletedEventHandler(ByVal sender As Object, ByVal e As GetCustomerCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class GetCustomerCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As Object
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), Object)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub GetDivisorCompletedEventHandler(ByVal sender As Object, ByVal e As GetDivisorCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class GetDivisorCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As Double
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), Double)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub isCustomerExistsCompletedEventHandler(ByVal sender As Object, ByVal e As isCustomerExistsCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class isCustomerExistsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), Boolean)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub IsLoggedInCompletedEventHandler(ByVal sender As Object, ByVal e As IsLoggedInCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class IsLoggedInCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), Boolean)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub ProcesOrderCompletedEventHandler(ByVal sender As Object, ByVal e As ProcesOrderCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class ProcesOrderCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), String)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")> _
    Public Delegate Sub CustomerOrderProcessCompletedEventHandler(ByVal sender As Object, ByVal e As CustomerOrderProcessCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class CustomerOrderProcessCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), String)
            End Get
        End Property
    End Class
End Namespace
