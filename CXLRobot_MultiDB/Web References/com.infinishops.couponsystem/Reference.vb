﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
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
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
'
Namespace com.infinishops.couponsystem
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="EmailCouponSoap", [Namespace]:="http://tempuri.org/couponsystem.infinishops.com/EmailCoupon")>  _
    Public Class EmailCoupon
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://couponsystem.infinishops.com/EmailCoupon.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/couponsystem.infinishops.com/EmailCoupon/EmailToCustomer", RequestNamespace:="http://tempuri.org/couponsystem.infinishops.com/EmailCoupon", ResponseNamespace:="http://tempuri.org/couponsystem.infinishops.com/EmailCoupon", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function EmailToCustomer(ByVal MerchantID As Integer, ByVal CustomerID As Integer, ByVal OrderId As Integer) As ErrorCodesInfo
            Dim results() As Object = Me.Invoke("EmailToCustomer", New Object() {MerchantID, CustomerID, OrderId})
            Return CType(results(0),ErrorCodesInfo)
        End Function
        
        '<remarks/>
        Public Function BeginEmailToCustomer(ByVal MerchantID As Integer, ByVal CustomerID As Integer, ByVal OrderId As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("EmailToCustomer", New Object() {MerchantID, CustomerID, OrderId}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndEmailToCustomer(ByVal asyncResult As System.IAsyncResult) As ErrorCodesInfo
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),ErrorCodesInfo)
        End Function
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/couponsystem.infinishops.com/EmailCoupon")>  _
    Public Class ErrorCodesInfo
        
        '<remarks/>
        Public ErrorCode As Integer
        
        '<remarks/>
        Public ErrorDescription As String
    End Class
End Namespace
