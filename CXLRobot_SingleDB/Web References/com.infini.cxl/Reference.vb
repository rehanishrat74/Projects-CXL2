﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.2379
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
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
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2379.
'
Namespace com.infini.cxl
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ServiceSoap", [Namespace]:="http://cxl.infini.com")>  _
    Public Class Service
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://cxl.infini.com/Service.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cxl.infini.com/HelloWorld", RequestNamespace:="http://cxl.infini.com", ResponseNamespace:="http://cxl.infini.com", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function HelloWorld() As String
            Dim results() As Object = Me.Invoke("HelloWorld", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginHelloWorld(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("HelloWorld", New Object(-1) {}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndHelloWorld(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cxl.infini.com/CxlLiveTest", RequestElementName:="CxlLiveTest", RequestNamespace:="http://cxl.infini.com", ResponseElementName:="CxlLiveTestResponse", ResponseNamespace:="http://cxl.infini.com", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function IfCXLLive() As <System.Xml.Serialization.XmlElementAttribute("CxlLiveTestResult")> String
            Dim results() As Object = Me.Invoke("IfCXLLive", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginIfCXLLive(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("IfCXLLive", New Object(-1) {}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndIfCXLLive(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cxl.infini.com/CXLProcessingWith3dsecure", RequestElementName:="CXLProcessingWith3dsecure", RequestNamespace:="http://cxl.infini.com", ResponseElementName:="CXLProcessingWith3dsecureResponse", ResponseNamespace:="http://cxl.infini.com", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CXLProcessing43DS( _
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
                    ByVal ccv As String,  _
                    ByVal eci As String,  _
                    ByVal sid As String,  _
                    ByVal vts As String,  _
                    ByVal vav As String,  _
                    ByVal threeid As String,  _
                    ByVal hn As String,  _
                    ByVal zp As String,  _
                    ByVal cardname As String,  _
                    ByVal callCentre As String) As <System.Xml.Serialization.XmlElementAttribute("CXLProcessingWith3dsecureResult")> Object
            Dim results() As Object = Me.Invoke("CXLProcessing43DS", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv, eci, sid, vts, vav, threeid, hn, zp, cardname, callCentre})
            CXLResponseCode = CType(results(1),String)
            CXLMessage = CType(results(2),String)
            Return CType(results(0),Object)
        End Function
        
        '<remarks/>
        Public Function BeginCXLProcessing43DS( _
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
                    ByVal eci As String,  _
                    ByVal sid As String,  _
                    ByVal vts As String,  _
                    ByVal vav As String,  _
                    ByVal threeid As String,  _
                    ByVal hn As String,  _
                    ByVal zp As String,  _
                    ByVal cardname As String,  _
                    ByVal callCentre As String,  _
                    ByVal callback As System.AsyncCallback,  _
                    ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CXLProcessing43DS", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv, eci, sid, vts, vav, threeid, hn, zp, cardname, callCentre}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndCXLProcessing43DS(ByVal asyncResult As System.IAsyncResult, ByRef CXLResponseCode As String, ByRef CXLMessage As String) As Object
            Dim results() As Object = Me.EndInvoke(asyncResult)
            CXLResponseCode = CType(results(1),String)
            CXLMessage = CType(results(2),String)
            Return CType(results(0),Object)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cxl.infini.com/CXLProcessingWithCcvUpgrade", RequestElementName:="CXLProcessingWithCcvUpgrade", RequestNamespace:="http://cxl.infini.com", ResponseElementName:="CXLProcessingWithCcvUpgradeResponse", ResponseNamespace:="http://cxl.infini.com", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CXLProcessing( _
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
                    ByVal ccv As String,  _
                    ByVal hn As String,  _
                    ByVal zp As String,  _
                    ByVal cardname As String,  _
                    ByVal callCentre As String) As <System.Xml.Serialization.XmlElementAttribute("CXLProcessingWithCcvUpgradeResult")> Object
            Dim results() As Object = Me.Invoke("CXLProcessing", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv, hn, zp, cardname, callCentre})
            CXLResponseCode = CType(results(1),String)
            CXLMessage = CType(results(2),String)
            Return CType(results(0),Object)
        End Function
        
        '<remarks/>
        Public Function BeginCXLProcessing( _
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
                    ByVal hn As String,  _
                    ByVal zp As String,  _
                    ByVal cardname As String,  _
                    ByVal callCentre As String,  _
                    ByVal callback As System.AsyncCallback,  _
                    ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CXLProcessing", New Object() {CreditCardNO, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, StartDate, CardExpiry, CardType, Mode, CXLResponseCode, CXLMessage, agentName, agentAcquirer, rid, merchantloginid, customerloginid, sender, ccv, hn, zp, cardname, callCentre}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndCXLProcessing(ByVal asyncResult As System.IAsyncResult, ByRef CXLResponseCode As String, ByRef CXLMessage As String) As Object
            Dim results() As Object = Me.EndInvoke(asyncResult)
            CXLResponseCode = CType(results(1),String)
            CXLMessage = CType(results(2),String)
            Return CType(results(0),Object)
        End Function
    End Class
End Namespace
