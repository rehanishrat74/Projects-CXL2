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
Namespace Io.InfiniShops
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ServiceActivationSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class ServiceActivation
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private EnabledServicesOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetTicketTextOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetTicketTextByTicketCodeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TicketHandlerOperationCompleted As System.Threading.SendOrPostCallback
        
        Private RepayTicketHandler_PayOnCreditOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://io.infinishops.com/services/ServiceActivation.asmx"
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
        Public Event GetTicketTextCompleted As GetTicketTextCompletedEventHandler
        
        '''<remarks/>
        Public Event GetTicketTextByTicketCodeCompleted As GetTicketTextByTicketCodeCompletedEventHandler
        
        '''<remarks/>
        Public Event TicketHandlerCompleted As TicketHandlerCompletedEventHandler
        
        '''<remarks/>
        Public Event RepayTicketHandler_PayOnCreditCompleted As RepayTicketHandler_PayOnCreditCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EnabledServices", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function EnabledServices(ByVal info As ServiceInfo) As EnabledServicesResult
            Dim results() As Object = Me.Invoke("EnabledServices", New Object() {info})
            Return CType(results(0),EnabledServicesResult)
        End Function
        
        '''<remarks/>
        Public Function BeginEnabledServices(ByVal info As ServiceInfo, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("EnabledServices", New Object() {info}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndEnabledServices(ByVal asyncResult As System.IAsyncResult) As EnabledServicesResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),EnabledServicesResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub EnabledServicesAsync(ByVal info As ServiceInfo)
            Me.EnabledServicesAsync(info, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub EnabledServicesAsync(ByVal info As ServiceInfo, ByVal userState As Object)
            If (Me.EnabledServicesOperationCompleted Is Nothing) Then
                Me.EnabledServicesOperationCompleted = AddressOf Me.OnEnabledServicesOperationCompleted
            End If
            Me.InvokeAsync("EnabledServices", New Object() {info}, Me.EnabledServicesOperationCompleted, userState)
        End Sub
        
        Private Sub OnEnabledServicesOperationCompleted(ByVal arg As Object)
            If (Not (Me.EnabledServicesCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent EnabledServicesCompleted(Me, New EnabledServicesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetTicketText", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetTicketText(ByVal info As Ticket_Info) As GetTicketTextResult
            Dim results() As Object = Me.Invoke("GetTicketText", New Object() {info})
            Return CType(results(0),GetTicketTextResult)
        End Function
        
        '''<remarks/>
        Public Function BeginGetTicketText(ByVal info As Ticket_Info, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetTicketText", New Object() {info}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetTicketText(ByVal asyncResult As System.IAsyncResult) As GetTicketTextResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),GetTicketTextResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetTicketTextAsync(ByVal info As Ticket_Info)
            Me.GetTicketTextAsync(info, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetTicketTextAsync(ByVal info As Ticket_Info, ByVal userState As Object)
            If (Me.GetTicketTextOperationCompleted Is Nothing) Then
                Me.GetTicketTextOperationCompleted = AddressOf Me.OnGetTicketTextOperationCompleted
            End If
            Me.InvokeAsync("GetTicketText", New Object() {info}, Me.GetTicketTextOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetTicketTextOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetTicketTextCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetTicketTextCompleted(Me, New GetTicketTextCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetTicketTextByTicketCode", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetTicketTextByTicketCode(ByVal info As TicketCodeParams) As GetTicketTextResult
            Dim results() As Object = Me.Invoke("GetTicketTextByTicketCode", New Object() {info})
            Return CType(results(0),GetTicketTextResult)
        End Function
        
        '''<remarks/>
        Public Function BeginGetTicketTextByTicketCode(ByVal info As TicketCodeParams, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetTicketTextByTicketCode", New Object() {info}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetTicketTextByTicketCode(ByVal asyncResult As System.IAsyncResult) As GetTicketTextResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),GetTicketTextResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetTicketTextByTicketCodeAsync(ByVal info As TicketCodeParams)
            Me.GetTicketTextByTicketCodeAsync(info, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetTicketTextByTicketCodeAsync(ByVal info As TicketCodeParams, ByVal userState As Object)
            If (Me.GetTicketTextByTicketCodeOperationCompleted Is Nothing) Then
                Me.GetTicketTextByTicketCodeOperationCompleted = AddressOf Me.OnGetTicketTextByTicketCodeOperationCompleted
            End If
            Me.InvokeAsync("GetTicketTextByTicketCode", New Object() {info}, Me.GetTicketTextByTicketCodeOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetTicketTextByTicketCodeOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetTicketTextByTicketCodeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetTicketTextByTicketCodeCompleted(Me, New GetTicketTextByTicketCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TicketHandler", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TicketHandler(ByVal info As TicketHandlerInfo) As TicketHandlerResult
            Dim results() As Object = Me.Invoke("TicketHandler", New Object() {info})
            Return CType(results(0),TicketHandlerResult)
        End Function
        
        '''<remarks/>
        Public Function BeginTicketHandler(ByVal info As TicketHandlerInfo, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("TicketHandler", New Object() {info}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndTicketHandler(ByVal asyncResult As System.IAsyncResult) As TicketHandlerResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),TicketHandlerResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TicketHandlerAsync(ByVal info As TicketHandlerInfo)
            Me.TicketHandlerAsync(info, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TicketHandlerAsync(ByVal info As TicketHandlerInfo, ByVal userState As Object)
            If (Me.TicketHandlerOperationCompleted Is Nothing) Then
                Me.TicketHandlerOperationCompleted = AddressOf Me.OnTicketHandlerOperationCompleted
            End If
            Me.InvokeAsync("TicketHandler", New Object() {info}, Me.TicketHandlerOperationCompleted, userState)
        End Sub
        
        Private Sub OnTicketHandlerOperationCompleted(ByVal arg As Object)
            If (Not (Me.TicketHandlerCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TicketHandlerCompleted(Me, New TicketHandlerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RepayTicketHandler_PayOnCredit", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RepayTicketHandler_PayOnCredit(ByVal info As ServiceInfo) As TicketHandlerResult
            Dim results() As Object = Me.Invoke("RepayTicketHandler_PayOnCredit", New Object() {info})
            Return CType(results(0),TicketHandlerResult)
        End Function
        
        '''<remarks/>
        Public Function BeginRepayTicketHandler_PayOnCredit(ByVal info As ServiceInfo, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("RepayTicketHandler_PayOnCredit", New Object() {info}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndRepayTicketHandler_PayOnCredit(ByVal asyncResult As System.IAsyncResult) As TicketHandlerResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),TicketHandlerResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub RepayTicketHandler_PayOnCreditAsync(ByVal info As ServiceInfo)
            Me.RepayTicketHandler_PayOnCreditAsync(info, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub RepayTicketHandler_PayOnCreditAsync(ByVal info As ServiceInfo, ByVal userState As Object)
            If (Me.RepayTicketHandler_PayOnCreditOperationCompleted Is Nothing) Then
                Me.RepayTicketHandler_PayOnCreditOperationCompleted = AddressOf Me.OnRepayTicketHandler_PayOnCreditOperationCompleted
            End If
            Me.InvokeAsync("RepayTicketHandler_PayOnCredit", New Object() {info}, Me.RepayTicketHandler_PayOnCreditOperationCompleted, userState)
        End Sub
        
        Private Sub OnRepayTicketHandler_PayOnCreditOperationCompleted(ByVal arg As Object)
            If (Not (Me.RepayTicketHandler_PayOnCreditCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RepayTicketHandler_PayOnCreditCompleted(Me, New RepayTicketHandler_PayOnCreditCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class ServiceInfo
        
        Private merchantIDField As String
        
        Private customerIDField As String
        
        Private orderIDField As String
        
        Private isOrderSuccessField As Boolean
        
        Private payModeField As PaymentMode
        
        Private dotNotSendDeclineEmailField As Boolean
        
        '''<remarks/>
        Public Property MerchantID() As String
            Get
                Return Me.merchantIDField
            End Get
            Set
                Me.merchantIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CustomerID() As String
            Get
                Return Me.customerIDField
            End Get
            Set
                Me.customerIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property OrderID() As String
            Get
                Return Me.orderIDField
            End Get
            Set
                Me.orderIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property IsOrderSuccess() As Boolean
            Get
                Return Me.isOrderSuccessField
            End Get
            Set
                Me.isOrderSuccessField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PayMode() As PaymentMode
            Get
                Return Me.payModeField
            End Get
            Set
                Me.payModeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property DotNotSendDeclineEmail() As Boolean
            Get
                Return Me.dotNotSendDeclineEmailField
            End Get
            Set
                Me.dotNotSendDeclineEmailField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Public Enum PaymentMode
        
        '''<remarks/>
        CC
        
        '''<remarks/>
        CB
        
        '''<remarks/>
        BP
        
        '''<remarks/>
        PA
        
        '''<remarks/>
        CR
    End Enum
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class TicketHandlerResult
        
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
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class TicketHandlerInfo
        
        Private merchantIDField As String
        
        Private customerIDField As String
        
        Private orderIDField As String
        
        Private payModeField As PaymentMode
        
        Private isRepaymentField As Boolean
        
        Private orderAmountField As Double
        
        '''<remarks/>
        Public Property MerchantID() As String
            Get
                Return Me.merchantIDField
            End Get
            Set
                Me.merchantIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CustomerID() As String
            Get
                Return Me.customerIDField
            End Get
            Set
                Me.customerIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property OrderID() As String
            Get
                Return Me.orderIDField
            End Get
            Set
                Me.orderIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PayMode() As PaymentMode
            Get
                Return Me.payModeField
            End Get
            Set
                Me.payModeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property IsRepayment() As Boolean
            Get
                Return Me.isRepaymentField
            End Get
            Set
                Me.isRepaymentField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property OrderAmount() As Double
            Get
                Return Me.orderAmountField
            End Get
            Set
                Me.orderAmountField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class TicketCodeParams
        
        Private merchantIDField As String
        
        Private ticketCodeField As String
        
        Private attributeNameField As String
        
        Private attibuteValueField As String
        
        Private requiredColorField As Short
        
        Private resellerProdCodeField As String
        
        Private totalProductCountField As String
        
        Private inactiveProductCountField As String
        
        '''<remarks/>
        Public Property MerchantID() As String
            Get
                Return Me.merchantIDField
            End Get
            Set
                Me.merchantIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TicketCode() As String
            Get
                Return Me.ticketCodeField
            End Get
            Set
                Me.ticketCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property AttributeName() As String
            Get
                Return Me.attributeNameField
            End Get
            Set
                Me.attributeNameField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property AttibuteValue() As String
            Get
                Return Me.attibuteValueField
            End Get
            Set
                Me.attibuteValueField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property RequiredColor() As Short
            Get
                Return Me.requiredColorField
            End Get
            Set
                Me.requiredColorField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ResellerProdCode() As String
            Get
                Return Me.resellerProdCodeField
            End Get
            Set
                Me.resellerProdCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TotalProductCount() As String
            Get
                Return Me.totalProductCountField
            End Get
            Set
                Me.totalProductCountField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property InactiveProductCount() As String
            Get
                Return Me.inactiveProductCountField
            End Get
            Set
                Me.inactiveProductCountField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class GetTicketTextResult
        
        Private errorCodeField As Short
        
        Private errorDescField As String
        
        Private ticketTextField As String
        
        Private ticketTitleField As String
        
        Private colorField As String
        
        Private categoryField As String
        
        '''<remarks/>
        Public Property ErrorCode() As Short
            Get
                Return Me.errorCodeField
            End Get
            Set
                Me.errorCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ErrorDesc() As String
            Get
                Return Me.errorDescField
            End Get
            Set
                Me.errorDescField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TicketText() As String
            Get
                Return Me.ticketTextField
            End Get
            Set
                Me.ticketTextField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TicketTitle() As String
            Get
                Return Me.ticketTitleField
            End Get
            Set
                Me.ticketTitleField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property color() As String
            Get
                Return Me.colorField
            End Get
            Set
                Me.colorField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property category() As String
            Get
                Return Me.categoryField
            End Get
            Set
                Me.categoryField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class Ticket_Info
        
        Private resellerIDField As String
        
        Private customerIDField As String
        
        Private orderIDField As String
        
        Private rssProdCodeField As String
        
        Private isPreActivationProductField As Boolean
        
        Private isProductActivatedField As Boolean
        
        Private isOrderPaidField As Boolean
        
        Private totalProductCountField As String
        
        Private inactiveProductCountField As String
        
        '''<remarks/>
        Public Property ResellerID() As String
            Get
                Return Me.resellerIDField
            End Get
            Set
                Me.resellerIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CustomerID() As String
            Get
                Return Me.customerIDField
            End Get
            Set
                Me.customerIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property OrderID() As String
            Get
                Return Me.orderIDField
            End Get
            Set
                Me.orderIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property RssProdCode() As String
            Get
                Return Me.rssProdCodeField
            End Get
            Set
                Me.rssProdCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property IsPreActivationProduct() As Boolean
            Get
                Return Me.isPreActivationProductField
            End Get
            Set
                Me.isPreActivationProductField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property IsProductActivated() As Boolean
            Get
                Return Me.isProductActivatedField
            End Get
            Set
                Me.isProductActivatedField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property IsOrderPaid() As Boolean
            Get
                Return Me.isOrderPaidField
            End Get
            Set
                Me.isOrderPaidField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TotalProductCount() As String
            Get
                Return Me.totalProductCountField
            End Get
            Set
                Me.totalProductCountField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property InactiveProductCount() As String
            Get
                Return Me.inactiveProductCountField
            End Get
            Set
                Me.inactiveProductCountField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class EnabledServicesResult
        
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
        Public ReadOnly Property Result() As EnabledServicesResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),EnabledServicesResult)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub GetTicketTextCompletedEventHandler(ByVal sender As Object, ByVal e As GetTicketTextCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetTicketTextCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As GetTicketTextResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),GetTicketTextResult)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub GetTicketTextByTicketCodeCompletedEventHandler(ByVal sender As Object, ByVal e As GetTicketTextByTicketCodeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetTicketTextByTicketCodeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As GetTicketTextResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),GetTicketTextResult)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub TicketHandlerCompletedEventHandler(ByVal sender As Object, ByVal e As TicketHandlerCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TicketHandlerCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As TicketHandlerResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),TicketHandlerResult)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub RepayTicketHandler_PayOnCreditCompletedEventHandler(ByVal sender As Object, ByVal e As RepayTicketHandler_PayOnCreditCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class RepayTicketHandler_PayOnCreditCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As TicketHandlerResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),TicketHandlerResult)
            End Get
        End Property
    End Class
End Namespace