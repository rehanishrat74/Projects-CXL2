Imports System.Data
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports System.Web.Security
Imports InfiniLogic.AccountsCentre.Common
Imports System.Xml

<WebService(Namespace:="http://www.InsertInCXLV2.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class InsertInCXLV2
    Inherits System.Web.Services.WebService

    Public Structure InsertOrderResult
        Public ERRORCODE As String
        Public ERRORDESC As String
        Public STATUS As String
    End Structure

    Dim filename, log, folder, timestring As String
    Dim SuccessCriteria As Boolean = False
    Dim count As Integer
    '<WebMethod(MessageName:="InsertOrder")> _
    '    Public Overloads Function InsertOrder(ByVal Merchantid As Integer, _
    '                                            ByVal Cloginid As String, _
    '                                            ByVal orderbooked As Integer, _
    '                                            ByVal Amount As Double, _
    '                                            ByVal status As String, _
    '                                            ByVal cardno As String, _
    '                                            ByVal cardtype As String, _
    '                                            ByVal cardname As String, _
    '                                            ByVal cardaddress As String, _
    '                                            ByVal cardexpire As Date, _
    '                                            ByVal securitycode As String, _
    '                                            ByVal issueno As String, _
    '                                            ByVal processtype As String, _
    '                                            ByVal genericcode As String, _
    '                                            ByVal currencycode As String, _
    '                                            ByVal StartDate As String, _
    '                                            ByVal sender As String, _
    '                                            ByVal Trackid As Integer, _
    '                                            ByVal IpAddress As String, _
    '                                            ByVal eci As String, _
    '                                            ByVal AcsURL As String, _
    '                                            ByVal vts As String, _
    '                                            ByVal cavv As String, _
    '                                            ByVal xid As String, _
    '                                            ByVal vav As String, _
    '                                            ByVal MPI_SessionID As String, _
    '                                            ByVal hn As String, _
    '                                            ByVal zp As String, _
    '                                            ByVal AcceptCard As String, _
    '                                            ByVal ThreeD_Discription As String) As InsertOrderResult


    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData

    '    Try
    '        System.Web.HttpContext.Current.Trace.Warn("In InsertOrder")
    '        System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
    '        System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
    '        System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
    '        System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
    '        System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
    '        System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
    '        System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
    '        System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
    '        System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
    '        System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
    '        System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
    '        System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
    '        System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
    '        System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
    '        System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
    '        System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
    '        System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
    '        System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
    '        System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
    '        System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
    '        System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
    '        System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
    '        System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
    '        System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
    '        System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
    '        System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
    '        System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))

    '        MakeLog()
    '        filename = "Order-ID - " & orderbooked
    '        filename = folder & "\" & filename

    '        log = ". @Merchantid= " & Merchantid & vbCrLf
    '        log = log & ". @CLoginid= " & Cloginid & vbCrLf
    '        log = log & ". @Orderbooked= " & orderbooked & vbCrLf
    '        log = log & ". @OrderAmount= " & Amount & vbCrLf
    '        log = log & ". @Sender= " & sender & vbCrLf

    '        Dim Referer, Remote_add As String

    '        Remote_add = Me.Context.Request.UserHostAddress
    '        If Me.Context.Request.UrlReferrer Is Nothing Then
    '            Referer = ""
    '        Else
    '            Referer = Me.Context.Request.UrlReferrer.Host
    '        End If

    '        log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
    '        log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
    '        WriteDebugInfo(log, filename)

    '        Dim IsValidSender As Boolean = ValidSender(sender)
    '        System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
    '        If IsValidSender = False Then
    '            Result.ERRORCODE = -10
    '            Result.ERRORDESC = "Sender is not Authentic"
    '            Return Result
    '            Exit Function
    '        End If

    '        ' Call this services before inserting data into CXLTransaction DB
    '        If UCase(sender) = "IR" Then
    '            Dim objReseller As New reseller.webservices.IShopOrderHander

    '            System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
    '            objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
    '            System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
    '        Result.ERRORCODE = "0"
    '        Result.ERRORDESC = "Operation Completed successfully"

    '        'Encrypting credit card information (by Saad 19/02/08)/////////////////////
    '        Dim i As Integer
    '        Dim ECard As String = cardno
    '        Dim EIssueNum As String = issueno
    '        Dim ESecurityCode As String = securitycode
    '        Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
    '        i = cardno.IndexOf("p")

    '        System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
    '        If UCase(Encryption) = "ON" Then
    '            System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

    '            If (cardno <> "" And i = -1) Then
    '                ECard = Encrypt(cardno)
    '                If (issueno <> "") Then
    '                    EIssueNum = Encrypt(issueno)
    '                End If
    '                If (securitycode <> "") Then
    '                    ESecurityCode = Encrypt(securitycode)
    '                End If
    '            End If
    '        End If
    '        System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
    '        '///////////////////////////////////////////////////////////////////////////

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

    '        cmd = New CommandData(Merchantid)

    '        cmd.AddParameter("@MIdentity", Merchantid)
    '        cmd.AddParameter("@Cloginid", Cloginid)
    '        cmd.AddParameter("@orderbooked", orderbooked)
    '        cmd.AddParameter("@Amount", Amount)
    '        cmd.AddParameter("@status", status)
    '        cmd.AddParameter("@cardno", ECard)
    '        cmd.AddParameter("@cardtype", cardtype)
    '        cmd.AddParameter("@cardname", cardname)
    '        cmd.AddParameter("@cardaddress", cardaddress)
    '        cmd.AddParameter("@cardexpire", cardexpire)
    '        cmd.AddParameter("@securitycode", ESecurityCode)
    '        cmd.AddParameter("@issueno", EIssueNum)
    '        cmd.AddParameter("@processtype", processtype)
    '        cmd.AddParameter("@genericcode", genericcode)
    '        cmd.AddParameter("@currencycode", currencycode)
    '        cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)
    '        cmd.AddParameter("@eci", eci)
    '        cmd.AddParameter("@AcsURL", AcsURL)
    '        cmd.AddParameter("@vts", vts)
    '        cmd.AddParameter("@cavv", cavv)
    '        cmd.AddParameter("@xid", xid)
    '        cmd.AddParameter("@vav", vav)
    '        cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
    '        cmd.AddParameter("@hn", hn)
    '        cmd.AddParameter("@zp", zp)

    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTSQLDATA_SECURE_MERCHANT")
    '        cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_MERCHANT"


    '        Dim dataSetMerchant As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
    '        If dataSetMerchant.Tables(0).Rows.Count > 0 Then

    '            System.Web.HttpContext.Current.Trace.Warn("Order Information has been found in Merchant")

    '            cmd.ClearParameters()
    '            cmd = Nothing

    '            cmd = New CommandData(-1)

    '            cmd.CmdText = "SET XACT_ABORT ON"
    '            cmd.CmdType = CommandType.Text
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.BeginTransaction(True)


    '            cmd.AddParameter("@MIdentity", Merchantid)
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@status", status)
    '            cmd.AddParameter("@cardno", ECard)
    '            cmd.AddParameter("@cardtype", cardtype)
    '            cmd.AddParameter("@cardname", cardname)
    '            cmd.AddParameter("@cardaddress", cardaddress)
    '            cmd.AddParameter("@cardexpire", cardexpire)
    '            cmd.AddParameter("@securitycode", ESecurityCode)
    '            cmd.AddParameter("@issueno", EIssueNum)
    '            cmd.AddParameter("@processtype", processtype)
    '            cmd.AddParameter("@genericcode", genericcode)
    '            cmd.AddParameter("@currencycode", currencycode)
    '            cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@IPAddress", IpAddress)
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@ECI", eci)
    '            cmd.AddParameter("@AcsURL", AcsURL)
    '            cmd.AddParameter("@VTS", vts)
    '            cmd.AddParameter("@CAVV", cavv)
    '            cmd.AddParameter("@XID", xid)
    '            cmd.AddParameter("@VAV", vav)
    '            cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
    '            cmd.AddParameter("@hn", hn)
    '            cmd.AddParameter("@zp", zp)

    '            If UCase(AcceptCard) = "Y" And UCase(ThreeD_Discription) <> CStr(ConfigurationManager.AppSettings("Description_td")) Then
    '                System.Web.HttpContext.Current.Trace.Warn("Order qualify for CALLS MODE")
    '                cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_CXLT"
    '            Else
    '                System.Web.HttpContext.Current.Trace.Warn("Order qualify for SUSPEND MODE")
    '                cmd.AddParameter("@AcceptCard", AcceptCard)
    '                cmd.AddParameter("@ThreeD_Desc", ThreeD_Discription)
    '                cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_SUSPEND_CXLT"

    '                'If Trackid <> 0 Then
    '                '    cmd.ClearParameters()
    '                '    cmd.AddParameter("@rid", Trackid)
    '                '    cmd.AddParameter("@resposeCode", "30")
    '                '    cmd.AddParameter("@responseMsg", "CARD SUSPENDED")
    '                '    cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_UPDATE_RESPONSE_IN_REQUEST"
    '                '    cmd.Execute(ExecutionType.ExecuteNonQuery)
    '                'End If
    '            End If

    '            cmd.CmdType = CommandType.StoredProcedure
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.Commit()
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

    '        log = log & ". Calling webservices.reseller.com Service " & vbCrLf
    '        log = log & ". Having Parameters= " & vbCrLf
    '        log = log & ". @ResellerID= " & Merchantid & vbCrLf
    '        log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
    '        log = log & ". @SerialNumber= " & orderbooked
    '        WriteDebugInfo(log, filename)

    '        Return Result

    '    Catch ex As Exception
    '        cmd.RollBack()
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

    '        Result.ERRORCODE = "-1"
    '        Result.ERRORDESC = "EXCEPTION: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
    '    End Try
    'End Function

    <WebMethod(MessageName:="Insert_DeclineOrders_With_RealTImeResponse")> _
       Public Overloads Function Insert_DeclineOrders_With_RealTImeResponse(ByVal Merchantid As Integer, _
                                               ByVal Cloginid As String, _
                                               ByVal orderbooked As Integer, _
                                               ByVal Amount As Double, _
                                               ByVal status As String, _
                                               ByVal cardno As String, _
                                               ByVal cardtype As String, _
                                               ByVal cardname As String, _
                                               ByVal cardaddress As String, _
                                               ByVal cardexpire As Date, _
                                               ByVal securitycode As String, _
                                               ByVal issueno As String, _
                                               ByVal processtype As String, _
                                               ByVal genericcode As String, _
                                               ByVal currencycode As String, _
                                               ByVal StartDate As String, _
                                               ByVal sender As String, _
                                               ByVal Trackid As Integer, _
                                               ByVal IpAddress As String, _
                                               ByVal eci As String, _
                                               ByVal AcsURL As String, _
                                               ByVal vts As String, _
                                               ByVal cavv As String, _
                                               ByVal xid As String, _
                                               ByVal vav As String, _
                                               ByVal MPI_SessionID As String, _
                                               ByVal hn As String, _
                                               ByVal zp As String, _
                                               ByVal AcceptCard As String, _
                                               ByVal ThreeD_Discription As String, ByVal RealTime_ResponseCode As String, ByVal RealTime_ResponseMsg As String) As InsertOrderResult


        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In Insert_DeclineOrders_With_RealTImeResponse")
            System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
            System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
            System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
            System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
            System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
            System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
            System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
            System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
            System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
            System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
            System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
            System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
            System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
            System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
            System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
            System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
            System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
            System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
            System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
            System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
            System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
            System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
            System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
            System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
            System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
            System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
            System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
            System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
            System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
            System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
            System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))

            System.Web.HttpContext.Current.Trace.Warn("    ResponseCode = " & RealTime_ResponseCode)
            System.Web.HttpContext.Current.Trace.Warn("    ResponseMsg = " & RealTime_ResponseMsg)
            System.Web.HttpContext.Current.Trace.Warn("    RealTime_ResponseStatus = Y")


            If issueno = "0" Then issueno = ""
            System.Web.HttpContext.Current.Trace.Warn("  reformed  issueno=" & issueno)

            MakeLog()
            filename = "Order-ID - " & orderbooked
            filename = folder & "\" & filename

            log = ". @Merchantid= " & Merchantid & vbCrLf
            log = log & ". @CLoginid= " & Cloginid & vbCrLf
            log = log & ". @Orderbooked= " & orderbooked & vbCrLf
            log = log & ". @OrderAmount= " & Amount & vbCrLf
            log = log & ". @Sender= " & sender & vbCrLf

            Dim Referer, Remote_add As String

            Remote_add = Me.Context.Request.UserHostAddress
            If Me.Context.Request.UrlReferrer Is Nothing Then
                Referer = ""
            Else
                Referer = Me.Context.Request.UrlReferrer.Host
            End If

            log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
            log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
            WriteDebugInfo(log, filename)

            Dim IsValidSender As Boolean = ValidSender(sender)
            System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
            If IsValidSender = False Then
                Result.ERRORCODE = -10
                Result.ERRORDESC = "Sender is not Authentic"
                Return Result
                Exit Function
            End If

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"

            Dim i As Integer
            Dim ECard As String = cardno
            Dim EIssueNum As String = issueno
            Dim ESecurityCode As String = securitycode
            Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
            i = cardno.IndexOf("p")

            System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
            If UCase(Encryption) = "ON" Then
                System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

                If (cardno <> "" And i = -1) Then
                    ECard = Encrypt(cardno)
                    If (issueno <> "") Then
                        EIssueNum = Encrypt(issueno)
                    End If
                    If (securitycode <> "") Then
                        ESecurityCode = Encrypt(securitycode)
                    End If
                End If
            End If
            System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            cmd.AddParameter("@Amount", Amount)
            cmd.AddParameter("@status", status)
            cmd.AddParameter("@cardno", ECard)
            cmd.AddParameter("@cardtype", cardtype)
            cmd.AddParameter("@cardname", cardname)
            cmd.AddParameter("@cardaddress", cardaddress)
            cmd.AddParameter("@cardexpire", cardexpire)
            cmd.AddParameter("@securitycode", ESecurityCode)
            cmd.AddParameter("@issueno", EIssueNum)
            cmd.AddParameter("@processtype", processtype)
            cmd.AddParameter("@genericcode", genericcode)
            cmd.AddParameter("@currencycode", currencycode)
            cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@eci", eci)
            cmd.AddParameter("@AcsURL", AcsURL)
            cmd.AddParameter("@vts", vts)
            cmd.AddParameter("@cavv", cavv)
            cmd.AddParameter("@xid", xid)
            cmd.AddParameter("@vav", vav)
            cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
            cmd.AddParameter("@hn", hn)
            cmd.AddParameter("@zp", zp)

            cmd.AddParameter("@cxlCode", RealTime_ResponseCode)
            cmd.AddParameter("@cxlMsg", RealTime_ResponseMsg)
            cmd.AddParameter("@RealTimeStatus", "Y")

            System.Web.HttpContext.Current.Trace.Warn("Order qualify for CALLS MODE")
            cmd.CmdText = "CXLROBO_DECLINE_INSERTDATA"
            cmd.Execute(ExecutionType.ExecuteNonQuery)

            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)
            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)

            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try
    End Function

    <WebMethod(MessageName:="InsertOrder_With_RealTImeResponse")> _
        Public Overloads Function InsertOrder_With_RealTImeResponse(ByVal Merchantid As Integer, _
                                                ByVal Cloginid As String, _
                                                ByVal orderbooked As Integer, _
                                                ByVal Amount As Double, _
                                                ByVal status As String, _
                                                ByVal cardno As String, _
                                                ByVal cardtype As String, _
                                                ByVal cardname As String, _
                                                ByVal cardaddress As String, _
                                                ByVal cardexpire As Date, _
                                                ByVal securitycode As String, _
                                                ByVal issueno As String, _
                                                ByVal processtype As String, _
                                                ByVal genericcode As String, _
                                                ByVal currencycode As String, _
                                                ByVal StartDate As String, _
                                                ByVal sender As String, _
                                                ByVal Trackid As Integer, _
                                                ByVal IpAddress As String, _
                                                ByVal eci As String, _
                                                ByVal AcsURL As String, _
                                                ByVal vts As String, _
                                                ByVal cavv As String, _
                                                ByVal xid As String, _
                                                ByVal vav As String, _
                                                ByVal MPI_SessionID As String, _
                                                ByVal hn As String, _
                                                ByVal zp As String, _
                                                ByVal AcceptCard As String, _
                                                ByVal ThreeD_Discription As String, ByVal RealTime_ResponseCode As String, ByVal RealTime_ResponseMsg As String) As InsertOrderResult


        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertOrder_With_RealTImeResponse")
            System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
            System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
            System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
            System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
            System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
            System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
            System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
            System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
            System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
            System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
            System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
            System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
            System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
            System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
            System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
            System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
            System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
            System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
            System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
            System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
            System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
            System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
            System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
            System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
            System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
            System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
            System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
            System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
            System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
            System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
            System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))
            System.Web.HttpContext.Current.Trace.Warn("    ResponseCode = " & RealTime_ResponseCode)
            System.Web.HttpContext.Current.Trace.Warn("    ResponseMsg = " & RealTime_ResponseMsg)
            System.Web.HttpContext.Current.Trace.Warn("    RealTime_ResponseStatus = Y")


            If issueno = "0" Then issueno = ""
            System.Web.HttpContext.Current.Trace.Warn("  reformed  issueno=" & issueno)

            MakeLog()
            filename = "Order-ID - " & orderbooked
            filename = folder & "\" & filename

            log = ". @Merchantid= " & Merchantid & vbCrLf
            log = log & ". @CLoginid= " & Cloginid & vbCrLf
            log = log & ". @Orderbooked= " & orderbooked & vbCrLf
            log = log & ". @OrderAmount= " & Amount & vbCrLf
            log = log & ". @Sender= " & sender & vbCrLf

            Dim Referer, Remote_add As String

            Remote_add = Me.Context.Request.UserHostAddress
            If Me.Context.Request.UrlReferrer Is Nothing Then
                Referer = ""
            Else
                Referer = Me.Context.Request.UrlReferrer.Host
            End If

            log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
            log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
            WriteDebugInfo(log, filename)

            Dim IsValidSender As Boolean = ValidSender(sender)
            System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
            If IsValidSender = False Then
                Result.ERRORCODE = -10
                Result.ERRORDESC = "Sender is not Authentic"
                Return Result
                Exit Function
            End If

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"

            'Encrypting Credit Fard Information 
            '++++++++++++++++++++++++++++++++++++++++++++
            Dim i As Integer
            Dim ECard As String = cardno
            Dim EIssueNum As String = issueno
            Dim ESecurityCode As String = securitycode
            Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
            i = cardno.IndexOf("p")

            System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
            If UCase(Encryption) = "ON" Then
                System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

                If (cardno <> "" And i = -1) Then
                    ECard = Encrypt(cardno)
                    If (issueno <> "") Then
                        EIssueNum = Encrypt(issueno)
                    End If
                    If (securitycode <> "") Then
                        ESecurityCode = Encrypt(securitycode)
                    End If
                End If
            End If
            System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
            '++++++++++++++++++++++++++++++++++++++++++++

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            cmd.AddParameter("@Amount", Amount)
            cmd.AddParameter("@status", status)
            cmd.AddParameter("@cardno", ECard)
            cmd.AddParameter("@cardtype", cardtype)
            cmd.AddParameter("@cardname", cardname)
            cmd.AddParameter("@cardaddress", cardaddress)
            cmd.AddParameter("@cardexpire", cardexpire)
            cmd.AddParameter("@securitycode", ESecurityCode)
            cmd.AddParameter("@issueno", EIssueNum)
            cmd.AddParameter("@processtype", processtype)
            cmd.AddParameter("@genericcode", genericcode)
            cmd.AddParameter("@currencycode", currencycode)
            cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@eci", eci)
            cmd.AddParameter("@AcsURL", AcsURL)
            cmd.AddParameter("@vts", vts)
            cmd.AddParameter("@cavv", cavv)
            cmd.AddParameter("@xid", xid)
            cmd.AddParameter("@vav", vav)
            cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
            cmd.AddParameter("@hn", hn)
            cmd.AddParameter("@zp", zp)

            cmd.AddParameter("@cxlCode", RealTime_ResponseCode)
            cmd.AddParameter("@cxlMsg", RealTime_ResponseMsg)
            cmd.AddParameter("@RealTimeStatus", "Y")


            System.Web.HttpContext.Current.Trace.Warn("Order qualify for CALLS MODE")
            cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE"
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)

            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try
    End Function


    <WebMethod(MessageName:="InsertOrderTNS_With_RealTImeResponse")> _
        Public Overloads Function InsertOrderTNS_With_RealTImeResponse(ByVal Merchantid As Integer, _
                                                ByVal Cloginid As String, _
                                                ByVal orderbooked As Integer, _
                                                ByVal Amount As Double, _
                                                ByVal status As String, _
                                                ByVal cardno As String, _
                                                ByVal cardtype As String, _
                                                ByVal cardname As String, _
                                                ByVal cardaddress As String, _
                                                ByVal cardexpire As Date, _
                                                ByVal securitycode As String, _
                                                ByVal issueno As String, _
                                                ByVal processtype As String, _
                                                ByVal genericcode As String, _
                                                ByVal currencycode As String, _
                                                ByVal StartDate As String, _
                                                ByVal sender As String, _
                                                ByVal Trackid As Integer, _
                                                ByVal IpAddress As String, _
                                                ByVal eci As String, _
                                                ByVal AcsURL As String, _
                                                ByVal vts As String, _
                                                ByVal cavv As String, _
                                                ByVal xid As String, _
                                                ByVal vav As String, _
                                                ByVal MPI_SessionID As String, _
                                                ByVal hn As String, _
                                                ByVal zp As String, _
                                                ByVal AcceptCard As String, _
                                                ByVal ThreeD_Discription As String, ByVal RealTime_ResponseCode As String, ByVal RealTime_ResponseMsg As String, _
                                                ByVal GateWay_ResponseCode As String, _
                                                ByVal GateWay_ResponseMsg As String) As InsertOrderResult


        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertOrderTNS_With_RealTImeResponse")
            System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
            System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
            System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
            System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
            System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
            System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
            System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
            System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
            System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
            System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
            System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
            System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
            System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
            System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
            System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
            System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
            System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
            System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
            System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
            System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
            System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
            System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
            System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
            System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
            System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
            System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
            System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
            System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
            System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
            System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
            System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))
            System.Web.HttpContext.Current.Trace.Warn("    ResponseCode = " & RealTime_ResponseCode)
            System.Web.HttpContext.Current.Trace.Warn("    ResponseMsg = " & RealTime_ResponseMsg)
            System.Web.HttpContext.Current.Trace.Warn("    RealTime_ResponseStatus = Y")
            System.Web.HttpContext.Current.Trace.Warn("    GateWayResponseCode = " & GateWay_ResponseCode)
            System.Web.HttpContext.Current.Trace.Warn("    GateWayResponseMsg = " & GateWay_ResponseMsg)


            If issueno = "0" Then issueno = ""
            System.Web.HttpContext.Current.Trace.Warn("  reformed  issueno=" & issueno)

            MakeLog()
            filename = "Order-ID - " & orderbooked
            filename = folder & "\" & filename

            log = ". @Merchantid= " & Merchantid & vbCrLf
            log = log & ". @CLoginid= " & Cloginid & vbCrLf
            log = log & ". @Orderbooked= " & orderbooked & vbCrLf
            log = log & ". @OrderAmount= " & Amount & vbCrLf
            log = log & ". @Sender= " & sender & vbCrLf

            Dim Referer, Remote_add As String

            Remote_add = Me.Context.Request.UserHostAddress
            If Me.Context.Request.UrlReferrer Is Nothing Then
                Referer = ""
            Else
                Referer = Me.Context.Request.UrlReferrer.Host
            End If

            log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
            log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
            WriteDebugInfo(log, filename)

            Dim IsValidSender As Boolean = ValidSender(sender)
            System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
            If IsValidSender = False Then
                Result.ERRORCODE = -10
                Result.ERRORDESC = "Sender is not Authentic"
                Return Result
                Exit Function
            End If

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"

            'Encrypting Credit Fard Information 
            '++++++++++++++++++++++++++++++++++++++++++++
            Dim i As Integer
            Dim ECard As String = cardno
            Dim EIssueNum As String = issueno
            Dim ESecurityCode As String = securitycode
            Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
            i = cardno.IndexOf("p")

            System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
            If UCase(Encryption) = "ON" Then
                System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

                If (cardno <> "" And i = -1) Then
                    ECard = Encrypt(cardno)
                    If (issueno <> "") Then
                        EIssueNum = Encrypt(issueno)
                    End If
                    If (securitycode <> "") Then
                        ESecurityCode = Encrypt(securitycode)
                    End If
                End If
            End If
            System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
            '++++++++++++++++++++++++++++++++++++++++++++

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            cmd.AddParameter("@Amount", Amount)
            cmd.AddParameter("@status", status)
            cmd.AddParameter("@cardno", ECard)
            cmd.AddParameter("@cardtype", cardtype)
            cmd.AddParameter("@cardname", cardname)
            cmd.AddParameter("@cardaddress", cardaddress)
            cmd.AddParameter("@cardexpire", cardexpire)
            cmd.AddParameter("@securitycode", ESecurityCode)
            cmd.AddParameter("@issueno", EIssueNum)
            cmd.AddParameter("@processtype", processtype)
            cmd.AddParameter("@genericcode", genericcode)
            cmd.AddParameter("@currencycode", currencycode)
            cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@eci", eci)
            cmd.AddParameter("@AcsURL", AcsURL)
            cmd.AddParameter("@vts", vts)
            cmd.AddParameter("@cavv", cavv)
            cmd.AddParameter("@xid", xid)
            cmd.AddParameter("@vav", vav)
            cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
            cmd.AddParameter("@hn", hn)
            cmd.AddParameter("@zp", zp)

            cmd.AddParameter("@cxlCode", RealTime_ResponseCode)
            cmd.AddParameter("@cxlMsg", RealTime_ResponseMsg)
            cmd.AddParameter("@RealTimeStatus", "Y")
            cmd.AddParameter("@GateWayResponseCode", GateWay_ResponseCode)
            cmd.AddParameter("@GateWayMessage", GateWay_ResponseMsg)

            System.Web.HttpContext.Current.Trace.Warn("Order qualify for CALLS MODE")
            cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE"
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)

            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try
    End Function


    <WebMethod(MessageName:="InsertOrder")> _
        Public Overloads Function InsertOrder(ByVal Merchantid As Integer, _
                                                ByVal Cloginid As String, _
                                                ByVal orderbooked As Integer, _
                                                ByVal Amount As Double, _
                                                ByVal status As String, _
                                                ByVal cardno As String, _
                                                ByVal cardtype As String, _
                                                ByVal cardname As String, _
                                                ByVal cardaddress As String, _
                                                ByVal cardexpire As Date, _
                                                ByVal securitycode As String, _
                                                ByVal issueno As String, _
                                                ByVal processtype As String, _
                                                ByVal genericcode As String, _
                                                ByVal currencycode As String, _
                                                ByVal StartDate As String, _
                                                ByVal sender As String, _
                                                ByVal Trackid As Integer, _
                                                ByVal IpAddress As String, _
                                                ByVal eci As String, _
                                                ByVal AcsURL As String, _
                                                ByVal vts As String, _
                                                ByVal cavv As String, _
                                                ByVal xid As String, _
                                                ByVal vav As String, _
                                                ByVal MPI_SessionID As String, _
                                                ByVal hn As String, _
                                                ByVal zp As String, _
                                                ByVal AcceptCard As String, _
                                                ByVal ThreeD_Discription As String) As InsertOrderResult


        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In AC/FH BackEnd InsertOrder")
            System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
            System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
            System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
            System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
            System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
            System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
            System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
            System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
            System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
            System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
            System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
            System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
            System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
            System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
            System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
            System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
            System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
            System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
            System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
            System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
            System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
            System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
            System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
            System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
            System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
            System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
            System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
            System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
            System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
            System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
            System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))

            'System.Web.HttpContext.Current.Trace.Warn("    ResponseCode = " & ResponseCode)
            'System.Web.HttpContext.Current.Trace.Warn("    ResponseMsg = " & ResponseMsg)


            If issueno = "0" Then issueno = ""
            System.Web.HttpContext.Current.Trace.Warn("  reformed  issueno=" & issueno)

            MakeLog()
            filename = "Order-ID - " & orderbooked
            filename = folder & "\" & filename

            log = ". @Merchantid= " & Merchantid & vbCrLf
            log = log & ". @CLoginid= " & Cloginid & vbCrLf
            log = log & ". @Orderbooked= " & orderbooked & vbCrLf
            log = log & ". @OrderAmount= " & Amount & vbCrLf
            log = log & ". @Sender= " & sender & vbCrLf

            Dim Referer, Remote_add As String

            Remote_add = Me.Context.Request.UserHostAddress
            If Me.Context.Request.UrlReferrer Is Nothing Then
                Referer = ""
            Else
                Referer = Me.Context.Request.UrlReferrer.Host
            End If

            log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
            log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
            WriteDebugInfo(log, filename)

            Dim IsValidSender As Boolean = ValidSender(sender)
            System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
            If IsValidSender = False Then
                Result.ERRORCODE = -10
                Result.ERRORDESC = "Sender is not Authentic"
                Return Result
                Exit Function
            End If

            ' Call this services before inserting data into CXLTransaction DB
            'If UCase(sender) = "IR" Then
            '    Dim objReseller As New reseller.webservices.IShopOrderHander

            '    System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
            '    objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
            '    System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            'End If

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"

            'Encrypting credit card information (by Saad 19/02/08)/////////////////////
            Dim i As Integer
            Dim ECard As String = cardno
            Dim EIssueNum As String = issueno
            Dim ESecurityCode As String = securitycode
            Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
            i = cardno.IndexOf("p")

            System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
            If UCase(Encryption) = "ON" Then
                System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

                If (cardno <> "" And i = -1) Then
                    ECard = Encrypt(cardno)
                    If (issueno <> "") Then
                        EIssueNum = Encrypt(issueno)
                    End If
                    If (securitycode <> "") Then
                        ESecurityCode = Encrypt(securitycode)
                    End If
                End If
            End If
            System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
            '///////////////////////////////////////////////////////////////////////////

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            cmd.AddParameter("@Amount", Amount)
            cmd.AddParameter("@status", status)
            cmd.AddParameter("@cardno", ECard)
            cmd.AddParameter("@cardtype", cardtype)
            cmd.AddParameter("@cardname", cardname)
            cmd.AddParameter("@cardaddress", cardaddress)
            cmd.AddParameter("@cardexpire", cardexpire)
            cmd.AddParameter("@securitycode", ESecurityCode)
            cmd.AddParameter("@issueno", EIssueNum)
            cmd.AddParameter("@processtype", processtype)
            cmd.AddParameter("@genericcode", genericcode)
            cmd.AddParameter("@currencycode", currencycode)
            cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@eci", eci)
            cmd.AddParameter("@AcsURL", AcsURL)
            cmd.AddParameter("@vts", vts)
            cmd.AddParameter("@cavv", cavv)
            cmd.AddParameter("@xid", xid)
            cmd.AddParameter("@vav", vav)
            cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
            cmd.AddParameter("@hn", hn)
            cmd.AddParameter("@zp", zp)

            'cmd.AddParameter("@cxlCode", ResponseCode)
            'cmd.AddParameter("@cxlMsg", ResponseMsg)


            ' ''If UCase(AcceptCard) = "Y" And UCase(ThreeD_Discription) <> CStr(ConfigurationManager.AppSettings("Description_td")) OrElse processtype = "CB" Then
            System.Web.HttpContext.Current.Trace.Warn("Order qualify for CALLS MODE")
            cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE"
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            ' ''Else
            ' ''    System.Web.HttpContext.Current.Trace.Warn("Order qualify for SUSPEND MODE")
            ' ''    cmd.AddParameter("@AcceptCard", AcceptCard)
            ' ''    cmd.AddParameter("@ThreeD_Desc", ThreeD_Discription)
            ' ''    cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_SUSPEND"
            ' ''    cmd.Execute(ExecutionType.ExecuteNonQuery)

            ' ''    'If Trackid <> 0 Then
            ' ''    '    cmd.ClearParameters()
            ' ''    '    cmd.AddParameter("@rid", Trackid)
            ' ''    '    cmd.AddParameter("@resposeCode", "30")
            ' ''    '    cmd.AddParameter("@responseMsg", "CARD SUSPENDED")
            ' ''    '    cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_UPDATE_RESPONSE_IN_REQUEST"
            ' ''    '    cmd.Execute(ExecutionType.ExecuteNonQuery)
            ' ''    'End If
            ' ''End If


            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)

            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try
    End Function

    '<WebMethod(MessageName:="InsertSuspendedOrder")> _
    '    Public Overloads Function InsertSuspendedOrder(ByVal Merchantid As Integer, _
    '                                            ByVal Cloginid As String, _
    '                                            ByVal orderbooked As Integer, _
    '                                            ByVal Amount As Double, _
    '                                            ByVal status As String, _
    '                                            ByVal cardno As String, _
    '                                            ByVal cardtype As String, _
    '                                            ByVal cardname As String, _
    '                                            ByVal cardaddress As String, _
    '                                            ByVal cardexpire As Date, _
    '                                            ByVal securitycode As String, _
    '                                            ByVal issueno As String, _
    '                                            ByVal processtype As String, _
    '                                            ByVal genericcode As String, _
    '                                            ByVal currencycode As String, _
    '                                            ByVal StartDate As String, _
    '                                            ByVal sender As String, _
    '                                            ByVal Trackid As Integer, _
    '                                            ByVal IpAddress As String, _
    '                                            ByVal eci As String, _
    '                                            ByVal AcsURL As String, _
    '                                            ByVal vts As String, _
    '                                            ByVal cavv As String, _
    '                                            ByVal xid As String, _
    '                                            ByVal vav As String, _
    '                                            ByVal MPI_SessionID As String, _
    '                                            ByVal hn As String, _
    '                                            ByVal zp As String, _
    '                                            ByVal AcceptCard As String, _
    '                                            ByVal ThreeD_Discription As String) As InsertOrderResult


    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData

    '    Try
    '        System.Web.HttpContext.Current.Trace.Warn("In InsertSuspendedOrder")
    '        System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
    '        System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
    '        System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
    '        System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
    '        System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
    '        System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
    '        System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
    '        System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
    '        System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
    '        System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
    '        System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
    '        System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
    '        System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
    '        System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
    '        System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
    '        System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
    '        System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
    '        System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
    '        System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
    '        System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
    '        System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
    '        System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
    '        System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
    '        System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
    '        System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
    '        System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
    '        System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
    '        System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))

    '        MakeLog()
    '        filename = "Order-ID - " & orderbooked
    '        filename = folder & "\" & filename

    '        log = ". @Merchantid= " & Merchantid & vbCrLf
    '        log = log & ". @CLoginid= " & Cloginid & vbCrLf
    '        log = log & ". @Orderbooked= " & orderbooked & vbCrLf
    '        log = log & ". @OrderAmount= " & Amount & vbCrLf
    '        log = log & ". @Sender= " & sender & vbCrLf

    '        Dim Referer, Remote_add As String

    '        Remote_add = Me.Context.Request.UserHostAddress
    '        If Me.Context.Request.UrlReferrer Is Nothing Then
    '            Referer = ""
    '        Else
    '            Referer = Me.Context.Request.UrlReferrer.Host
    '        End If

    '        log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
    '        log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
    '        WriteDebugInfo(log, filename)

    '        Dim IsValidSender As Boolean = ValidSender(sender)
    '        System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
    '        If IsValidSender = False Then
    '            Result.ERRORCODE = -10
    '            Result.ERRORDESC = "Sender is not Authentic"
    '            Return Result
    '            Exit Function
    '        End If

    '        ' Call this services before inserting data into CXLTransaction DB
    '        If UCase(sender) = "IR" Then
    '            Dim objReseller As New reseller.webservices.IShopOrderHander

    '            System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
    '            objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
    '            System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
    '        Result.ERRORCODE = "0"
    '        Result.ERRORDESC = "Operation Completed successfully"

    '        'Encrypting credit card information (by Saad 19/02/08)/////////////////////
    '        Dim i As Integer
    '        Dim ECard As String = cardno
    '        Dim EIssueNum As String = issueno
    '        Dim ESecurityCode As String = securitycode
    '        Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
    '        i = cardno.IndexOf("p")

    '        System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
    '        If UCase(Encryption) = "ON" Then
    '            System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

    '            If (cardno <> "" And i = -1) Then
    '                ECard = Encrypt(cardno)
    '                If (issueno <> "") Then
    '                    EIssueNum = Encrypt(issueno)
    '                End If
    '                If (securitycode <> "") Then
    '                    ESecurityCode = Encrypt(securitycode)
    '                End If
    '            End If
    '        End If
    '        System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
    '        '///////////////////////////////////////////////////////////////////////////

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

    '        cmd = New CommandData(Merchantid)

    '        cmd.AddParameter("@MIdentity", Merchantid)
    '        cmd.AddParameter("@Cloginid", Cloginid)
    '        cmd.AddParameter("@orderbooked", orderbooked)
    '        cmd.AddParameter("@Amount", Amount)
    '        cmd.AddParameter("@status", status)
    '        cmd.AddParameter("@cardno", ECard)
    '        cmd.AddParameter("@cardtype", cardtype)
    '        cmd.AddParameter("@cardname", cardname)
    '        cmd.AddParameter("@cardaddress", cardaddress)
    '        cmd.AddParameter("@cardexpire", cardexpire)
    '        cmd.AddParameter("@securitycode", ESecurityCode)
    '        cmd.AddParameter("@issueno", EIssueNum)
    '        cmd.AddParameter("@processtype", processtype)
    '        cmd.AddParameter("@genericcode", genericcode)
    '        cmd.AddParameter("@currencycode", currencycode)
    '        cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)
    '        cmd.AddParameter("@eci", eci)
    '        cmd.AddParameter("@AcsURL", AcsURL)
    '        cmd.AddParameter("@vts", vts)
    '        cmd.AddParameter("@cavv", cavv)
    '        cmd.AddParameter("@xid", xid)
    '        cmd.AddParameter("@vav", vav)
    '        cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
    '        cmd.AddParameter("@hn", hn)
    '        cmd.AddParameter("@zp", zp)


    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTSQLDATA_SECURE_MERCHANT")
    '        cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_MERCHANT"


    '        Dim dataSetMerchant As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
    '        If dataSetMerchant.Tables(0).Rows.Count > 0 Then

    '            System.Web.HttpContext.Current.Trace.Warn("Order Information has been found in Merchant")

    '            cmd.ClearParameters()
    '            cmd = Nothing

    '            cmd = New CommandData(-1)

    '            cmd.CmdText = "SET XACT_ABORT ON"
    '            cmd.CmdType = CommandType.Text
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.BeginTransaction(True)


    '            cmd.AddParameter("@MIdentity", Merchantid)
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@status", status)
    '            cmd.AddParameter("@cardno", ECard)
    '            cmd.AddParameter("@cardtype", cardtype)
    '            cmd.AddParameter("@cardname", cardname)
    '            cmd.AddParameter("@cardaddress", cardaddress)
    '            cmd.AddParameter("@cardexpire", cardexpire)
    '            cmd.AddParameter("@securitycode", ESecurityCode)
    '            cmd.AddParameter("@issueno", EIssueNum)
    '            cmd.AddParameter("@processtype", processtype)
    '            cmd.AddParameter("@genericcode", genericcode)
    '            cmd.AddParameter("@currencycode", currencycode)
    '            cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@IPAddress", IpAddress)
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@ECI", eci)
    '            cmd.AddParameter("@AcsURL", AcsURL)
    '            cmd.AddParameter("@VTS", vts)
    '            cmd.AddParameter("@CAVV", cavv)
    '            cmd.AddParameter("@XID", xid)
    '            cmd.AddParameter("@VAV", vav)
    '            cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
    '            cmd.AddParameter("@hn", hn)
    '            cmd.AddParameter("@zp", zp)
    '            cmd.AddParameter("@AcceptCard", AcceptCard)
    '            cmd.AddParameter("@ThreeD_Desc", ThreeD_Discription)
    '            cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_SUSPEND_CXLT"

    '            'If Trackid <> 0 Then
    '            '    cmd.ClearParameters()
    '            '    cmd.AddParameter("@rid", Trackid)
    '            '    cmd.AddParameter("@resposeCode", "30")
    '            '    cmd.AddParameter("@responseMsg", "CARD SUSPENDED")
    '            '    cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_UPDATE_RESPONSE_IN_REQUEST"
    '            '    cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            'End If

    '            cmd.CmdType = CommandType.StoredProcedure
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.Commit()
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)
    '        Return Result

    '    Catch ex As Exception
    '        cmd.RollBack()
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

    '        Result.ERRORCODE = "-1"
    '        Result.ERRORDESC = "EXCEPTION: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("InsertSuspendedOrder End")
    '    End Try
    'End Function

    <WebMethod(MessageName:="InsertSuspendedOrder")> _
        Public Overloads Function InsertSuspendedOrder(ByVal Merchantid As Integer, _
                                                ByVal Cloginid As String, _
                                                ByVal orderbooked As Integer, _
                                                ByVal Amount As Double, _
                                                ByVal status As String, _
                                                ByVal cardno As String, _
                                                ByVal cardtype As String, _
                                                ByVal cardname As String, _
                                                ByVal cardaddress As String, _
                                                ByVal cardexpire As Date, _
                                                ByVal securitycode As String, _
                                                ByVal issueno As String, _
                                                ByVal processtype As String, _
                                                ByVal genericcode As String, _
                                                ByVal currencycode As String, _
                                                ByVal StartDate As String, _
                                                ByVal sender As String, _
                                                ByVal Trackid As Integer, _
                                                ByVal IpAddress As String, _
                                                ByVal eci As String, _
                                                ByVal AcsURL As String, _
                                                ByVal vts As String, _
                                                ByVal cavv As String, _
                                                ByVal xid As String, _
                                                ByVal vav As String, _
                                                ByVal MPI_SessionID As String, _
                                                ByVal hn As String, _
                                                ByVal zp As String, _
                                                ByVal AcceptCard As String, _
                                                ByVal ThreeD_Discription As String) As InsertOrderResult


        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertSuspendedOrder")
            System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
            System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Cloginid)
            System.Web.HttpContext.Current.Trace.Warn("    orderbooked=" & orderbooked)
            System.Web.HttpContext.Current.Trace.Warn("    Amount=" & Amount)
            System.Web.HttpContext.Current.Trace.Warn("    status=" & status)
            System.Web.HttpContext.Current.Trace.Warn("    cardno=" & Len(cardno))
            System.Web.HttpContext.Current.Trace.Warn("    cardtype=" & cardtype)
            System.Web.HttpContext.Current.Trace.Warn("    cardname=" & cardname)
            System.Web.HttpContext.Current.Trace.Warn("    cardaddress=" & cardaddress)
            System.Web.HttpContext.Current.Trace.Warn("    cardexpire=" & cardexpire)
            System.Web.HttpContext.Current.Trace.Warn("    securitycode=" & securitycode)
            System.Web.HttpContext.Current.Trace.Warn("    issueno=" & issueno)
            System.Web.HttpContext.Current.Trace.Warn("    processtype=" & processtype)
            System.Web.HttpContext.Current.Trace.Warn("    genericcode=" & genericcode)
            System.Web.HttpContext.Current.Trace.Warn("    currencycode=" & currencycode)
            System.Web.HttpContext.Current.Trace.Warn("    StartDate=" & StartDate)
            System.Web.HttpContext.Current.Trace.Warn("    sender=" & sender)
            System.Web.HttpContext.Current.Trace.Warn("    Trackid=" & Trackid)
            System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)
            System.Web.HttpContext.Current.Trace.Warn("    eci=" & eci)
            System.Web.HttpContext.Current.Trace.Warn("    AcsURL=" & AcsURL)
            System.Web.HttpContext.Current.Trace.Warn("    vts=" & vts)
            System.Web.HttpContext.Current.Trace.Warn("    cavv=" & cavv)
            System.Web.HttpContext.Current.Trace.Warn("    xid=" & xid)
            System.Web.HttpContext.Current.Trace.Warn("    vav=" & vav)
            System.Web.HttpContext.Current.Trace.Warn("    MPI_SessionID=" & MPI_SessionID)
            System.Web.HttpContext.Current.Trace.Warn("    hn=" & hn)
            System.Web.HttpContext.Current.Trace.Warn("    zp=" & zp)
            System.Web.HttpContext.Current.Trace.Warn("    AcceptCard=" & AcceptCard)
            System.Web.HttpContext.Current.Trace.Warn("    ThreeD_Discription=" & ThreeD_Discription)
            System.Web.HttpContext.Current.Trace.Warn("    Fixed Discription=" & CStr(ConfigurationManager.AppSettings("Description_td")))

            If issueno = "0" Then issueno = ""
            System.Web.HttpContext.Current.Trace.Warn("  reformed  issueno=" & issueno)

            MakeLog()
            filename = "Order-ID - " & orderbooked
            filename = folder & "\" & filename

            log = ". @Merchantid= " & Merchantid & vbCrLf
            log = log & ". @CLoginid= " & Cloginid & vbCrLf
            log = log & ". @Orderbooked= " & orderbooked & vbCrLf
            log = log & ". @OrderAmount= " & Amount & vbCrLf
            log = log & ". @Sender= " & sender & vbCrLf

            Dim Referer, Remote_add As String

            Remote_add = Me.Context.Request.UserHostAddress
            If Me.Context.Request.UrlReferrer Is Nothing Then
                Referer = ""
            Else
                Referer = Me.Context.Request.UrlReferrer.Host
            End If

            log = log & ". @HTTP_REFERER= " & Referer & vbCrLf
            log = log & ". @REMOTE_ADDR= " & Remote_add & vbCrLf
            WriteDebugInfo(log, filename)

            Dim IsValidSender As Boolean = ValidSender(sender)
            System.Web.HttpContext.Current.Trace.Warn("IsValidSender = " & IsValidSender)
            If IsValidSender = False Then
                Result.ERRORCODE = -10
                Result.ERRORDESC = "Sender is not Authentic"
                Return Result
                Exit Function
            End If

            ' Call this services before inserting data into CXLTransaction DB
            'If UCase(sender) = "IR" Then
            '    Dim objReseller As New reseller.webservices.IShopOrderHander

            '    System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
            '    objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
            '    System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            'End If

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"

            'Encrypting credit card information (by Saad 19/02/08)/////////////////////
            Dim i As Integer
            Dim ECard As String = cardno
            Dim EIssueNum As String = issueno
            Dim ESecurityCode As String = securitycode
            Dim Encryption As String = CStr(ConfigurationManager.AppSettings("Encryption"))
            i = cardno.IndexOf("p")

            System.Web.HttpContext.Current.Trace.Warn("Encryption = " & Encryption)
            If UCase(Encryption) = "ON" Then
                System.Web.HttpContext.Current.Trace.Warn("Encrypting Information Started")

                If (cardno <> "" And i = -1) Then
                    ECard = Encrypt(cardno)
                    If (issueno <> "") Then
                        EIssueNum = Encrypt(issueno)
                    End If
                    If (securitycode <> "") Then
                        ESecurityCode = Encrypt(securitycode)
                    End If
                End If
            End If
            System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))
            '///////////////////////////////////////////////////////////////////////////



            System.Web.HttpContext.Current.Trace.Warn("    EnCardNo=" & Len(ECard))

                '////////////////////////////////////////////////////////////////////////
                System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

                cmd.AddParameter("@MIdentity", Merchantid)
                cmd.AddParameter("@Cloginid", Cloginid)
                cmd.AddParameter("@orderbooked", orderbooked)
                cmd.AddParameter("@Amount", Amount)
                cmd.AddParameter("@status", status)
                cmd.AddParameter("@cardno", ECard)
                cmd.AddParameter("@cardtype", cardtype)
                cmd.AddParameter("@cardname", cardname)
                cmd.AddParameter("@cardaddress", cardaddress)
                cmd.AddParameter("@cardexpire", cardexpire)
                cmd.AddParameter("@securitycode", ESecurityCode)
                cmd.AddParameter("@issueno", EIssueNum)
                cmd.AddParameter("@processtype", processtype)
                cmd.AddParameter("@genericcode", genericcode)
                cmd.AddParameter("@currencycode", currencycode)
                cmd.AddParameter("@StartDate", IIf(Len(StartDate) = 0, StartDate, CDate(StartDate)))
                cmd.AddParameter("@Sender", sender)
                cmd.AddParameter("@trackid", Trackid)
                cmd.AddParameter("@IPAddress", IpAddress)
                cmd.AddParameter("@eci", eci)
                cmd.AddParameter("@AcsURL", AcsURL)
                cmd.AddParameter("@vts", vts)
                cmd.AddParameter("@cavv", cavv)
                cmd.AddParameter("@xid", xid)
                cmd.AddParameter("@vav", vav)
                cmd.AddParameter("@MPI_SessionID", MPI_SessionID)
                cmd.AddParameter("@hn", hn)
            cmd.AddParameter("@zp", zp)
            cmd.AddParameter("@AcceptCard", AcceptCard)

            cmd.AddParameter("@ThreeD_Desc", ThreeD_Discription)
            cmd.CmdText = "CXLROBO_INSERTSQLDATA_SECURE_SUSPEND"
            cmd.Execute(ExecutionType.ExecuteNonQuery)

            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            If (AcceptCard = "N" AndAlso ThreeD_Discription = "TNSAuthRequest rejected : Request rejected") OrElse UCase(AcceptCard) = "A" OrElse UCase(AcceptCard) = "U" Then

                If Merchantid = 2 Then
                    System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

                    If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

                        'Counting the no. of successful transactions through following details
                        System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
                        System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

                        Try
                            System.Web.HttpContext.Current.Trace.Warn("MIdentity" & Merchantid)
                            System.Web.HttpContext.Current.Trace.Warn("Cloginid" & Cloginid)
                            System.Web.HttpContext.Current.Trace.Warn("cardno" & ECard)

                            cmd.ClearParameters()

                            cmd.AddParameter("@MIdentity", Merchantid)
                            cmd.AddParameter("@Cloginid", Cloginid)
                            cmd.AddParameter("@cardno", ECard)

                            cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_COUNT_TRANSACTION"
                            count = cmd.Execute(ExecutionType.ExecuteScalar)

                            If count >= CInt(ConfigurationManager.AppSettings("SuccessCriteria")) Then
                                SuccessCriteria = True
                            End If

                        Catch ex As Exception
                            System.Web.HttpContext.Current.Trace.Warn("Exception at SuccessCriteria : " & ex.Message)
                        End Try

                        System.Web.HttpContext.Current.Trace.Warn("No. of Successful transactions : " & count)
                        System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria : " & SuccessCriteria)

                        cmd.ClearParameters()
                        '////////////////////////////////////////////////////////////////////
                    End If

                    If SuccessCriteria = True Then
                        If Is_Qualify_For_BlockRules(ECard) = True Then
                            SuccessCriteria = False
                        Else
                            SuccessCriteria = True
                        End If
                    End If

                    If SuccessCriteria = True Then
                        cmd.ClearParameters()
                        cmd.AddParameter("@MIdentity", Merchantid)
                        cmd.AddParameter("@Cloginid", Cloginid)
                        cmd.AddParameter("@orderbooked", orderbooked)
                        cmd.AddParameter("@requesttime", Now)
                        cmd.AddParameter("@ResponseIPAddress", IpAddress)

                        cmd.CmdText = "DBSERVER.cxltransaction.dbo.CAM_CXLROBO_INSERT_SUSPENDDATA_ForM2"
                        cmd.Execute(ExecutionType.ExecuteDataSet)
                    Else
                        EmailtoSupport(Merchantid, orderbooked, Cloginid, sender)
                    End If

                End If
            Else
                EmailtoSupport(Merchantid, orderbooked, Cloginid, sender)
            End If
            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertSuspendedOrder End")
        End Try
    End Function

    Private Sub MakeLog()

        timestring = Date.Now
        folder = "d:\Log_InsertInCxlV2\" & Date.Today
        folder = Replace(folder, "/", "-")
        CreateFolder(folder)

    End Sub

#Region "......Folder Creation methods and log files maintain functions........."

    Private Sub CreateFolder(ByVal vfolder)
        Try

            If (Directory.Exists(vfolder) = False) Then
                Dim fs, f
                fs = CreateObject("Scripting.FileSystemObject")
                f = fs.CreateFolder(vfolder)
                fs = Nothing
                f = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub WriteDebugInfo(ByVal sText As String, ByVal LogUniquePath As String)

        Try
            If Not System.IO.Directory.Exists(LogUniquePath) Then
                System.IO.Directory.CreateDirectory(LogUniquePath)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(LogUniquePath & "\InsertInCXLV2.vb Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Function ValidSender(ByVal Sender As String) As Boolean

        If Application("Senders") Is Nothing Then
            Application("Senders") = ConfigurationManager.AppSettings("Senders")
        End If

        Dim Sender_String As String = Application("Senders")
        Dim i As Integer
        Dim Sender_List() As String

        Sender_List = Sender_String.Split(",")

        For i = 0 To Sender_List.Length - 1
            If Sender = Sender_List(i) Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Function Encrypt(ByVal Info As String) As String

        Dim ObjCrypt As New rsaLibrary1.Crypt
        Dim En As String = Info
        Dim E As String
        Dim N As String

        E = ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.E)
        N = ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)

        En = ObjCrypt.Encrypt(En, E, N)
        En = Replace(En, "+", "p")
        Return En

    End Function

    Private Function EmailtoSupport(ByVal MerchantID As String, ByVal OrderID As String, ByVal CloginID As String, ByVal sender As String)
        Try
            HttpContext.Current.Trace.Warn("EmailsList", System.Configuration.ConfigurationSettings.AppSettings("EmailsList"))
            Dim EmailsList As String = System.Configuration.ConfigurationSettings.AppSettings("EmailsList")
            'Dim ErrorEmailListArray() As String = EmailsList.Split(New Char() {","})
            Dim strbuilder As String
            Dim objReader As StreamReader
            HttpContext.Current.Trace.Warn("Path template", Me.Server.MapPath("SuspendTemplate.htm"))
            objReader = New StreamReader(Me.Server.MapPath("SuspendTemplate.htm"))
            strbuilder = objReader.ReadToEnd()
            objReader.Close()


            strbuilder = strbuilder.Replace("[OrderID]", OrderID).Replace("[merchantid]", MerchantID).Replace("[cloginid]", CloginID).Replace("[sender]", sender)

            Dim Str As String = "<br> Merchant:- " & MerchantID & " OrderID:-" & OrderID & " Customer Login ID:-" & CloginID & " Sender:-" & sender & ""
            'For Each Item As String In ErrorEmailListArray
            HttpContext.Current.Trace.Warn(ConfigReader.GetItem(ConfigVariables.SMTPUserID))
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), EmailsList, "Order Suspended, Please check", strbuilder, Mail.MailFormat.Html)
            HttpContext.Current.Trace.Warn("Email send")

            'Next
        Catch exe As Exception
            HttpContext.Current.Trace.Warn("Exception at SendExceptionEmail", exe.Message)
        End Try

    End Function

    Private Function Is_Qualify_For_BlockRules(ByVal ECard As String) As Boolean
        Dim RuleType As String = "", Rule As String = ""
        HttpContext.Current.Trace.Warn("Start Is_Qualify_For_BlockRules")
        Dim ObjBool As Boolean = False
        Dim Ds2 As DataSet = IsRuleBlockbyM2_New(2)
        If (Ds2.Tables(0).Rows.Count > 0) Then

            For Count2 As Integer = 0 To Ds2.Tables(0).Rows.Count - 1
                If (CheckBlockRule(Ds2.Tables(0).Rows(Count2).Item("RuleType"), Trim(Ds2.Tables(0).Rows(Count2).Item("Rule")), ECard) = True) Then
                    ObjBool = True

                    RuleType = Ds2.Tables(0).Rows(Count2).Item("RuleType")
                    Rule = Ds2.Tables(0).Rows(Count2).Item("Rule")
                    Exit For
                Else
                    ObjBool = False
                End If
            Next
        End If
        Return ObjBool
        HttpContext.Current.Trace.Warn("End Is_Qualify_For_BlockRules", ObjBool)

    End Function

    Private Function CheckBlockRule(ByVal RuleType As Integer, ByVal Rule As String, ByVal ECard As String) As Boolean

        HttpContext.Current.Trace.Warn("RuleType", RuleType)
        If RuleType = 0 Then
            If (ECard = Rule) Then
                HttpContext.Current.Trace.Warn("Card no is qualify for blocked, so transaction still in suspend")

                Return True
            Else
                HttpContext.Current.Trace.Warn("Card not qualify for blocked, so transaction can through in calls at cs")

                Return False
            End If
        End If
    End Function

    Public Function IsRuleBlockbyM2_New(ByVal Curr_Merchant As Integer) As DataSet

        Dim cmd As New CommandData

        ' Dim Sender As String
        Try

            cmd.AddParameter("@Merchant", Curr_Merchant)

            cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_CHECKBLOCKRULEPRESENT"

            Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)


            Return (ds)

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception at IsRuleBlockbyM2_New", ex.Message)

            cmd = Nothing
        Finally
            cmd = Nothing
        End Try

    End Function

End Class
