﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
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
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.42.
'
Namespace com.infinilogic.gaterefund
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="CxlrefundSoap", [Namespace]:="http://tempuri.org/CxlRefund/Cxlrefund")>  _
    Partial Public Class Cxlrefund
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private RefundProcessingOperationCompleted As System.Threading.SendOrPostCallback
        
        Private RefundProcessing1OperationCompleted As System.Threading.SendOrPostCallback
        
        Private IfRefundLiveOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.RefundRobot.My.MySettings.Default.RefundRobot_2005_com_infinilogic_gaterefund_Cxlrefund
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
        Public Event RefundProcessingCompleted As RefundProcessingCompletedEventHandler
        
        '''<remarks/>
        Public Event RefundProcessing1Completed As RefundProcessing1CompletedEventHandler
        
        '''<remarks/>
        Public Event IfRefundLiveCompleted As IfRefundLiveCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CxlRefund/Cxlrefund/RefundProcessingWithCcv", RequestElementName:="RefundProcessingWithCcv", RequestNamespace:="http://tempuri.org/CxlRefund/Cxlrefund", ResponseElementName:="RefundProcessingWithCcvResponse", ResponseNamespace:="http://tempuri.org/CxlRefund/Cxlrefund", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Overloads Function RefundProcessing( _
                    ByVal CreditCardNO As String,  _
                    ByVal IssueNumber As String,  _
                    ByVal TransactionAmount As String,  _
                    ByVal GCode As String,  _
                    ByVal MerchantId As String,  _
                    ByVal CID As String,  _
                    ByVal OrderID As String,  _
                    ByVal TransactionType As String,  _
                    ByVal StartDate As String,  _
                    ByVal CardExpiry As String,  _
                    ByVal CardType As String,  _
                    ByVal Mode As String,  _
                    ByRef CXLResponseCode As String,  _
                    ByRef CXLMessage As String,  _
                    ByVal agentName As String,  _
                    ByVal agentAcquirer As String,  _
                    ByVal rid As Long,  _
                    ByVal merchantloginid As String,  _
                    ByVal customerloginid As String,  _
                    ByVal sender As String,  _
                    ByVal ccv As String) As <System.Xml.Serialization.XmlElementAttribute("RefundProcessingWithCcvResult")> Object
            Dim results() As Object = Me.Invoke("RefundProcessing", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv})
            CXLResponseCode = CType(results(1),String)
            CXLMessage = CType(results(2),String)
            Return CType(results(0),Object)
        End Function
        
        '''<remarks/>
        Public Overloads Sub RefundProcessingAsync( _
                    ByVal CreditCardNO As String,  _
                    ByVal IssueNumber As String,  _
                    ByVal TransactionAmount As String,  _
                    ByVal GCode As String,  _
                    ByVal MerchantId As String,  _
                    ByVal CID As String,  _
                    ByVal OrderID As String,  _
                    ByVal TransactionType As String,  _
                    ByVal StartDate As String,  _
                    ByVal CardExpiry As String,  _
                    ByVal CardType As String,  _
                    ByVal Mode As String,  _
                    ByVal CXLResponseCode As String,  _
                    ByVal CXLMessage As String,  _
                    ByVal agentName As String,  _
                    ByVal agentAcquirer As String,  _
                    ByVal rid As Long,  _
                    ByVal merchantloginid As String,  _
                    ByVal customerloginid As String,  _
                    ByVal sender As String,  _
                    ByVal ccv As String)
            Me.RefundProcessingAsync(CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub RefundProcessingAsync( _
                    ByVal CreditCardNO As String,  _
                    ByVal IssueNumber As String,  _
                    ByVal TransactionAmount As String,  _
                    ByVal GCode As String,  _
                    ByVal MerchantId As String,  _
                    ByVal CID As String,  _
                    ByVal OrderID As String,  _
                    ByVal TransactionType As String,  _
                    ByVal StartDate As String,  _
                    ByVal CardExpiry As String,  _
                    ByVal CardType As String,  _
                    ByVal Mode As String,  _
                    ByVal CXLResponseCode As String,  _
                    ByVal CXLMessage As String,  _
                    ByVal agentName As String,  _
                    ByVal agentAcquirer As String,  _
                    ByVal rid As Long,  _
                    ByVal merchantloginid As String,  _
                    ByVal customerloginid As String,  _
                    ByVal sender As String,  _
                    ByVal ccv As String,  _
                    ByVal userState As Object)
            If (Me.RefundProcessingOperationCompleted Is Nothing) Then
                Me.RefundProcessingOperationCompleted = AddressOf Me.OnRefundProcessingOperationCompleted
            End If
            Me.InvokeAsync("RefundProcessing", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv}, Me.RefundProcessingOperationCompleted, userState)
        End Sub
        
        Private Sub OnRefundProcessingOperationCompleted(ByVal arg As Object)
            If (Not (Me.RefundProcessingCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RefundProcessingCompleted(Me, New RefundProcessingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.WebMethodAttribute(MessageName:="RefundProcessing1"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CxlRefund/Cxlrefund/RefundProcessing", RequestElementName:="RefundProcessing", RequestNamespace:="http://tempuri.org/CxlRefund/Cxlrefund", ResponseElementName:="RefundProcessingResponse", ResponseNamespace:="http://tempuri.org/CxlRefund/Cxlrefund", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Overloads Function RefundProcessing( _
                    ByVal CreditCardNO As String,  _
                    ByVal IssueNumber As String,  _
                    ByVal TransactionAmount As String,  _
                    ByVal GCode As String,  _
                    ByVal MerchantId As String,  _
                    ByVal CID As String,  _
                    ByVal OrderID As String,  _
                    ByVal TransactionType As String,  _
                    ByVal StartDate As String,  _
                    ByVal CardExpiry As String,  _
                    ByVal CardType As String,  _
                    ByVal Mode As String,  _
                    ByRef CXLResponseCode As String,  _
                    ByRef CXLMessage As String,  _
                    ByVal agentName As String,  _
                    ByVal agentAcquirer As String,  _
                    ByVal rid As Long,  _
                    ByVal merchantloginid As String,  _
                    ByVal customerloginid As String,  _
                    ByVal sender As String) As <System.Xml.Serialization.XmlElementAttribute("RefundProcessingResult")> Object
            Dim results() As Object = Me.Invoke("RefundProcessing1", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender})
            CXLResponseCode = CType(results(1),String)
            CXLMessage = CType(results(2),String)
            Return CType(results(0),Object)
        End Function
        
        '''<remarks/>
        Public Overloads Sub RefundProcessing1Async( _
                    ByVal CreditCardNO As String,  _
                    ByVal IssueNumber As String,  _
                    ByVal TransactionAmount As String,  _
                    ByVal GCode As String,  _
                    ByVal MerchantId As String,  _
                    ByVal CID As String,  _
                    ByVal OrderID As String,  _
                    ByVal TransactionType As String,  _
                    ByVal StartDate As String,  _
                    ByVal CardExpiry As String,  _
                    ByVal CardType As String,  _
                    ByVal Mode As String,  _
                    ByVal CXLResponseCode As String,  _
                    ByVal CXLMessage As String,  _
                    ByVal agentName As String,  _
                    ByVal agentAcquirer As String,  _
                    ByVal rid As Long,  _
                    ByVal merchantloginid As String,  _
                    ByVal customerloginid As String,  _
                    ByVal sender As String)
            Me.RefundProcessing1Async(CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub RefundProcessing1Async( _
                    ByVal CreditCardNO As String,  _
                    ByVal IssueNumber As String,  _
                    ByVal TransactionAmount As String,  _
                    ByVal GCode As String,  _
                    ByVal MerchantId As String,  _
                    ByVal CID As String,  _
                    ByVal OrderID As String,  _
                    ByVal TransactionType As String,  _
                    ByVal StartDate As String,  _
                    ByVal CardExpiry As String,  _
                    ByVal CardType As String,  _
                    ByVal Mode As String,  _
                    ByVal CXLResponseCode As String,  _
                    ByVal CXLMessage As String,  _
                    ByVal agentName As String,  _
                    ByVal agentAcquirer As String,  _
                    ByVal rid As Long,  _
                    ByVal merchantloginid As String,  _
                    ByVal customerloginid As String,  _
                    ByVal sender As String,  _
                    ByVal userState As Object)
            If (Me.RefundProcessing1OperationCompleted Is Nothing) Then
                Me.RefundProcessing1OperationCompleted = AddressOf Me.OnRefundProcessing1OperationCompleted
            End If
            Me.InvokeAsync("RefundProcessing1", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender}, Me.RefundProcessing1OperationCompleted, userState)
        End Sub
        
        Private Sub OnRefundProcessing1OperationCompleted(ByVal arg As Object)
            If (Not (Me.RefundProcessing1CompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RefundProcessing1Completed(Me, New RefundProcessing1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CxlRefund/Cxlrefund/RefundLiveTest", RequestElementName:="RefundLiveTest", RequestNamespace:="http://tempuri.org/CxlRefund/Cxlrefund", ResponseElementName:="RefundLiveTestResponse", ResponseNamespace:="http://tempuri.org/CxlRefund/Cxlrefund", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function IfRefundLive() As <System.Xml.Serialization.XmlElementAttribute("RefundLiveTestResult")> String
            Dim results() As Object = Me.Invoke("IfRefundLive", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub IfRefundLiveAsync()
            Me.IfRefundLiveAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub IfRefundLiveAsync(ByVal userState As Object)
            If (Me.IfRefundLiveOperationCompleted Is Nothing) Then
                Me.IfRefundLiveOperationCompleted = AddressOf Me.OnIfRefundLiveOperationCompleted
            End If
            Me.InvokeAsync("IfRefundLive", New Object(-1) {}, Me.IfRefundLiveOperationCompleted, userState)
        End Sub
        
        Private Sub OnIfRefundLiveOperationCompleted(ByVal arg As Object)
            If (Not (Me.IfRefundLiveCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent IfRefundLiveCompleted(Me, New IfRefundLiveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub RefundProcessingCompletedEventHandler(ByVal sender As Object, ByVal e As RefundProcessingCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class RefundProcessingCompletedEventArgs
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
        
        '''<remarks/>
        Public ReadOnly Property CXLResponseCode() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property CXLMessage() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(2),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub RefundProcessing1CompletedEventHandler(ByVal sender As Object, ByVal e As RefundProcessing1CompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class RefundProcessing1CompletedEventArgs
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
        
        '''<remarks/>
        Public ReadOnly Property CXLResponseCode() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property CXLMessage() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(2),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub IfRefundLiveCompletedEventHandler(ByVal sender As Object, ByVal e As IfRefundLiveCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class IfRefundLiveCompletedEventArgs
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
