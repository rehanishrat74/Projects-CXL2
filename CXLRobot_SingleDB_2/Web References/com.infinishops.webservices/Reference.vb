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
Namespace com.infinishops.webservices
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="webservicesSoap", [Namespace]:="http://www.infinishops.com")>  _
    Partial Public Class webservices
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GenerateInvoiceForOrderOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.WindowsGateWayCreditCard.My.MySettings.Default.WindowsGateWayCreditCard_Single_DB__com_infinishops_webservices_webservices
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event GenerateInvoiceForOrderCompleted As GenerateInvoiceForOrderCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.infinishops.com/GenerateInvoiceForOrder", RequestNamespace:="http://www.infinishops.com", ResponseNamespace:="http://www.infinishops.com", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GenerateInvoiceForOrder(ByVal OrderInformationXML As String) As String
            Dim results() As Object = Me.Invoke("GenerateInvoiceForOrder", New Object() {OrderInformationXML})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGenerateInvoiceForOrder(ByVal OrderInformationXML As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GenerateInvoiceForOrder", New Object() {OrderInformationXML}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGenerateInvoiceForOrder(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GenerateInvoiceForOrderAsync(ByVal OrderInformationXML As String)
            Me.GenerateInvoiceForOrderAsync(OrderInformationXML, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GenerateInvoiceForOrderAsync(ByVal OrderInformationXML As String, ByVal userState As Object)
            If (Me.GenerateInvoiceForOrderOperationCompleted Is Nothing) Then
                Me.GenerateInvoiceForOrderOperationCompleted = AddressOf Me.OnGenerateInvoiceForOrderOperationCompleted
            End If
            Me.InvokeAsync("GenerateInvoiceForOrder", New Object() {OrderInformationXML}, Me.GenerateInvoiceForOrderOperationCompleted, userState)
        End Sub
        
        Private Sub OnGenerateInvoiceForOrderOperationCompleted(ByVal arg As Object)
            If (Not (Me.GenerateInvoiceForOrderCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GenerateInvoiceForOrderCompleted(Me, New GenerateInvoiceForOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub GenerateInvoiceForOrderCompletedEventHandler(ByVal sender As Object, ByVal e As GenerateInvoiceForOrderCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GenerateInvoiceForOrderCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
