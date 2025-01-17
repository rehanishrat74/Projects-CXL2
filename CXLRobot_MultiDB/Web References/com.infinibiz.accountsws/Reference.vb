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
Namespace com.infinibiz.accountsws
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="AccountsProServiceSoap", [Namespace]:="http://tempuri.org/AccountsProWS/Service1")>  _
    Public Class AccountsProService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://accountsws.infinibiz.com/AccountsProService.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AccountsProWS/Service1/GetBOM", RequestNamespace:="http://tempuri.org/AccountsProWS/Service1", ResponseNamespace:="http://tempuri.org/AccountsProWS/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetBOM(ByVal ResellerID As Integer, ByVal PackagesList As String, ByVal OrderID As String) As PackagesListResponse
            Dim results() As Object = Me.Invoke("GetBOM", New Object() {ResellerID, PackagesList, OrderID})
            Return CType(results(0),PackagesListResponse)
        End Function
        
        '<remarks/>
        Public Function BeginGetBOM(ByVal ResellerID As Integer, ByVal PackagesList As String, ByVal OrderID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetBOM", New Object() {ResellerID, PackagesList, OrderID}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetBOM(ByVal asyncResult As System.IAsyncResult) As PackagesListResponse
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PackagesListResponse)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AccountsProWS/Service1/SetHTMLandLOGO", RequestNamespace:="http://tempuri.org/AccountsProWS/Service1", ResponseNamespace:="http://tempuri.org/AccountsProWS/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SetHTMLandLOGO(ByVal html As String, ByVal logo As String, ByVal sid As String, ByVal CustomerId As String) As ClassUser
            Dim results() As Object = Me.Invoke("SetHTMLandLOGO", New Object() {html, logo, sid, CustomerId})
            Return CType(results(0),ClassUser)
        End Function
        
        '<remarks/>
        Public Function BeginSetHTMLandLOGO(ByVal html As String, ByVal logo As String, ByVal sid As String, ByVal CustomerId As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SetHTMLandLOGO", New Object() {html, logo, sid, CustomerId}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndSetHTMLandLOGO(ByVal asyncResult As System.IAsyncResult) As ClassUser
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),ClassUser)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AccountsProWS/Service1/SetHTMLandLogoPayment", RequestNamespace:="http://tempuri.org/AccountsProWS/Service1", ResponseNamespace:="http://tempuri.org/AccountsProWS/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SetHTMLandLogoPayment(ByVal CustomerId As String, ByVal Paid As Integer) As ClassUser
            Dim results() As Object = Me.Invoke("SetHTMLandLogoPayment", New Object() {CustomerId, Paid})
            Return CType(results(0),ClassUser)
        End Function
        
        '<remarks/>
        Public Function BeginSetHTMLandLogoPayment(ByVal CustomerId As String, ByVal Paid As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SetHTMLandLogoPayment", New Object() {CustomerId, Paid}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndSetHTMLandLogoPayment(ByVal asyncResult As System.IAsyncResult) As ClassUser
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),ClassUser)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AccountsProWS/Service1/CreateSalesOrder", RequestNamespace:="http://tempuri.org/AccountsProWS/Service1", ResponseNamespace:="http://tempuri.org/AccountsProWS/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CreateSalesOrder(ByVal OrderId As String, ByVal trackId As Integer, ByVal MerchantId As String) As Boolean
            Dim results() As Object = Me.Invoke("CreateSalesOrder", New Object() {OrderId, trackId, MerchantId})
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginCreateSalesOrder(ByVal OrderId As String, ByVal trackId As Integer, ByVal MerchantId As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CreateSalesOrder", New Object() {OrderId, trackId, MerchantId}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndCreateSalesOrder(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/AccountsProWS/Service1")>  _
    Public Class PackagesListResponse
        
        '<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public PackageInfo() As PackagesBOMList
        
        '<remarks/>
        Public ErrorCode As String
        
        '<remarks/>
        Public ErrorDesc As String
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/AccountsProWS/Service1")>  _
    Public Class PackagesBOMList
        
        '<remarks/>
        Public IsPackage As String
        
        '<remarks/>
        Public PackageCode As String
        
        '<remarks/>
        Public ItemCode() As String
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/AccountsProWS/Service1")>  _
    Public Class ClassUser
        
        '<remarks/>
        Public ERRORCODE As String
        
        '<remarks/>
        Public ERRORDESC As String
    End Class
End Namespace
