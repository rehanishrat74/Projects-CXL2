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
Namespace ServiceActivation
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ServiceActivationSoap", [Namespace]:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation")>  _
    Partial Public Class ServiceActivation
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private EnabledServicesOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetBizInfoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://cxlrobot.accountscentre.com/CXLRobot_ServiceActivation/ServiceActivation.a"& _ 
                "smx"
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
        Public Event EnabledServicesCompleted As EnabledServicesCompletedEventHandler
        
        '''<remarks/>
        Public Event GetBizInfoCompleted As GetBizInfoCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation/EnabledServices", RequestNamespace:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation", ResponseNamespace:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function EnabledServices(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal IsOrderSuccess As Boolean, ByVal PayMode As String) As Object
            Dim results() As Object = Me.Invoke("EnabledServices", New Object() {CustomerID, OrderID, IsOrderSuccess, PayMode})
            Return CType(results(0),Object)
        End Function
        
        '''<remarks/>
        Public Function BeginEnabledServices(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal IsOrderSuccess As Boolean, ByVal PayMode As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("EnabledServices", New Object() {CustomerID, OrderID, IsOrderSuccess, PayMode}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndEnabledServices(ByVal asyncResult As System.IAsyncResult) As Object
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Object)
        End Function
        
        '''<remarks/>
        Public Overloads Sub EnabledServicesAsync(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal IsOrderSuccess As Boolean, ByVal PayMode As String)
            Me.EnabledServicesAsync(CustomerID, OrderID, IsOrderSuccess, PayMode, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub EnabledServicesAsync(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal IsOrderSuccess As Boolean, ByVal PayMode As String, ByVal userState As Object)
            If (Me.EnabledServicesOperationCompleted Is Nothing) Then
                Me.EnabledServicesOperationCompleted = AddressOf Me.OnEnabledServicesOperationCompleted
            End If
            Me.InvokeAsync("EnabledServices", New Object() {CustomerID, OrderID, IsOrderSuccess, PayMode}, Me.EnabledServicesOperationCompleted, userState)
        End Sub
        
        Private Sub OnEnabledServicesOperationCompleted(ByVal arg As Object)
            If (Not (Me.EnabledServicesCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent EnabledServicesCompleted(Me, New EnabledServicesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation/GetBizInfo", RequestNamespace:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation", ResponseNamespace:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetBizInfo(ByVal ResellerUID As Integer, ByVal OrderID As Integer, ByVal CustomerID As Integer, <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)> ByVal Product() As ProductDetail, ByVal PayStatus As String) As GetBizInfoResult
            Dim results() As Object = Me.Invoke("GetBizInfo", New Object() {ResellerUID, OrderID, CustomerID, Product, PayStatus})
            Return CType(results(0),GetBizInfoResult)
        End Function
        
        '''<remarks/>
        Public Function BeginGetBizInfo(ByVal ResellerUID As Integer, ByVal OrderID As Integer, ByVal CustomerID As Integer, ByVal Product() As ProductDetail, ByVal PayStatus As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetBizInfo", New Object() {ResellerUID, OrderID, CustomerID, Product, PayStatus}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetBizInfo(ByVal asyncResult As System.IAsyncResult) As GetBizInfoResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),GetBizInfoResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetBizInfoAsync(ByVal ResellerUID As Integer, ByVal OrderID As Integer, ByVal CustomerID As Integer, ByVal Product() As ProductDetail, ByVal PayStatus As String)
            Me.GetBizInfoAsync(ResellerUID, OrderID, CustomerID, Product, PayStatus, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetBizInfoAsync(ByVal ResellerUID As Integer, ByVal OrderID As Integer, ByVal CustomerID As Integer, ByVal Product() As ProductDetail, ByVal PayStatus As String, ByVal userState As Object)
            If (Me.GetBizInfoOperationCompleted Is Nothing) Then
                Me.GetBizInfoOperationCompleted = AddressOf Me.OnGetBizInfoOperationCompleted
            End If
            Me.InvokeAsync("GetBizInfo", New Object() {ResellerUID, OrderID, CustomerID, Product, PayStatus}, Me.GetBizInfoOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetBizInfoOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetBizInfoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetBizInfoCompleted(Me, New GetBizInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation")>  _
    Partial Public Class GetBizInfoResult
        
        Private eRRORCODEField As String
        
        Private eRRORDESCField As String
        
        '''<remarks/>
        Public Property ERRORCODE() As String
            Get
                Return Me.eRRORCODEField
            End Get
            Set
                Me.eRRORCODEField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ERRORDESC() As String
            Get
                Return Me.eRRORDESCField
            End Get
            Set
                Me.eRRORDESCField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/CXLRobot_ServiceActivation/ServiceActivation")>  _
    Partial Public Class ProductDetail
        
        Private productCodeField As String
        
        Private quantityField As String
        
        '''<remarks/>
        Public Property ProductCode() As String
            Get
                Return Me.productCodeField
            End Get
            Set
                Me.productCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Quantity() As String
            Get
                Return Me.quantityField
            End Get
            Set
                Me.quantityField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub EnabledServicesCompletedEventHandler(ByVal sender As Object, ByVal e As EnabledServicesCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class EnabledServicesCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Object
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Object)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub GetBizInfoCompletedEventHandler(ByVal sender As Object, ByVal e As GetBizInfoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetBizInfoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As GetBizInfoResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),GetBizInfoResult)
            End Get
        End Property
    End Class
End Namespace