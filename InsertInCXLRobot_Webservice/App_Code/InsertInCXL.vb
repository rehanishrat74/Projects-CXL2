Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports System.Web.Security
Imports InfiniLogic.AccountsCentre.Common
Imports System.Xml
Imports System.Data

<WebService(Namespace:="http://www.InsertInCXLRobot.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class InsertInCXL
    Inherits System.Web.Services.WebService

    Public Structure InsertOrderResult
        Public ERRORCODE As String
        Public ERRORDESC As String
        Public STATUS As String
    End Structure

    Dim filename, log, folder, timestring As String
    Dim SuccessCriteria As Boolean = False
    Dim count As Integer

    '<WebMethod(MessageName:="InsertOrder_Updated")> _
    'Public Overloads Function InsertOrder(ByVal Merchantid As Integer, _
    '                                        ByVal Cloginid As String, _
    '                                        ByVal orderbooked As Integer, _
    '                                        ByVal Amount As Double, _
    '                                        ByVal status As String, _
    '                                        ByVal cardno As String, _
    '                                        ByVal cardtype As String, _
    '                                        ByVal cardname As String, _
    '                                        ByVal cardaddress As String, _
    '                                        ByVal cardexpire As Date, _
    '                                        ByVal securitycode As String, _
    '                                        ByVal issueno As String, _
    '                                        ByVal processtype As String, _
    '                                        ByVal genericcode As String, _
    '                                        ByVal currencycode As String, _
    '                                        ByVal StartDate As Date, _
    '                                        ByVal sender As String, _
    '                                        ByVal Trackid As Integer, _
    '                                        ByVal IpAddress As String, _
    '                                        ByVal houseNo As String, _
    '                                        ByVal zip As String) As InsertOrderResult

    '    ' For normal Case
    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData

    '    Try
    '        System.Web.HttpContext.Current.Trace.Warn("In InsertOrder_Updated")
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
    '        System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
    '        System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)


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
    '        System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))


    '        If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

    '            'Counting the no. of successful transactions through following details
    '            System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
    '            System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

    '            Try
    '                'cmd = New CommandData(Merchantid)
    '                cmd = New CommandData(-1)

    '                cmd.AddParameter("@MIdentity", Merchantid)
    '                cmd.AddParameter("@Cloginid", Cloginid)
    '                cmd.AddParameter("@cardno", ECard)

    '                'cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_COUNT_TRANSACTION"
    '                cmd.CmdText = "CXLROBO_COUNT_TRANSACTION"
    '                count = cmd.Execute(ExecutionType.ExecuteScalar)

    '                If count >= CInt(ConfigurationManager.AppSettings("SuccessCriteria")) Then
    '                    SuccessCriteria = True
    '                End If

    '            Catch ex As Exception
    '                System.Web.HttpContext.Current.Trace.Warn("Exception at SuccessCriteria : " & ex.Message)
    '            End Try

    '            System.Web.HttpContext.Current.Trace.Warn("No. of Successful transactions : " & count)
    '            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria : " & SuccessCriteria)

    '            cmd.ClearParameters()
    '            cmd = Nothing
    '            '////////////////////////////////////////////////////////////////////
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

    '        cmd = New CommandData(Merchantid)

    '        cmd.AddParameter("@MIdentity", Merchantid)
    '        cmd.AddParameter("@Cloginid", Cloginid)
    '        cmd.AddParameter("@orderbooked", orderbooked)
    '        'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
    '        cmd.AddParameter("@StartDate", StartDate)
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)
    '        cmd.AddParameter("@houseNo", houseNo)
    '        cmd.AddParameter("@zip", zip)

    '        'If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTMYSQLDATA_MERCHANT")
    '        'cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
    '        cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"
    '        'Else
    '        'System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTDATAINSUSPEND_ATCS_MERCHANT")
    '        'cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"


    '        'End If

    '        'cmd.Execute(ExecutionType.ExecuteNonQuery)

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
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
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
    '            cmd.AddParameter("@StartDate", StartDate)
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IPAddress"))
    '            cmd.AddParameter("@houseNo", dataSetMerchant.Tables(0).Rows(0).Item("houseNo"))
    '            cmd.AddParameter("@zip", dataSetMerchant.Tables(0).Rows(0).Item("zip"))
    '            cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
    '            cmd.AddParameter("@PaymentProcessor", dataSetMerchant.Tables(0).Rows(0).Item("PaymentProcessor"))
    '            cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))


    '            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
    '                System.Web.HttpContext.Current.Trace.Warn("Order in Calls Mode")
    '                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"
    '            Else
    '                System.Web.HttpContext.Current.Trace.Warn("Order in Suspend Mode")
    '                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS_CXLT"

    '                If ValidEmailSender(UCase(sender)) = True Then
    '                    Try
    '                        Dim sendEmail As New com.reseller.webservices.SendEmail
    '                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
    '                    Catch ex As Exception
    '                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
    '                    End Try
    '                End If

    '            End If

    '            cmd.CmdType = CommandType.StoredProcedure
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.Commit()
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)
    '        'log = log & ". Calling webservices.reseller.com Service " & vbCrLf
    '        'log = log & ". Having Parameters= " & vbCrLf
    '        'log = log & ". @ResellerID= " & Merchantid & vbCrLf
    '        'log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
    '        'log = log & ". @SerialNumber= " & orderbooked & vbCrLf
    '        'WriteDebugInfo(log, filename)

    '        Return Result

    '    Catch ex As Exception
    '        cmd.RollBack()
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

    '        Result.ERRORCODE = "-1"
    '        Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("InsertOrder_Updated End")
    '    End Try

    'End Function
    <WebMethod(MessageName:="InsertOrder_Updated")> _
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
                                            ByVal StartDate As Date, _
                                            ByVal sender As String, _
                                            ByVal Trackid As Integer, _
                                            ByVal IpAddress As String, _
                                            ByVal houseNo As String, _
                                            ByVal zip As String) As InsertOrderResult

        ' For normal Case
        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertOrder")
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
            System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
            System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)


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

            If UCase(sender) = "IR" Then
                Dim objReseller As New reseller.webservices.IShopOrderHander

                System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
                objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
                System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            End If


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
            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

            If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

                'Counting the no. of successful transactions through following details
                System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
                System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

                Try
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

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            'If (UCase(status) = "R" And Trackid <> 0) Or (UCase(status) = "N" And Trackid = 0) Then
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@houseNo", houseNo)
            cmd.AddParameter("@zip", zip)

            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
                System.Web.HttpContext.Current.Trace.Warn("Order is in CALLS MODE")
                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
            Else
                System.Web.HttpContext.Current.Trace.Warn("Order is in SUSPEND MODE")
                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"

                If ValidEmailSender(UCase(sender)) = True Then
                    Try
                        Dim sendEmail As New com.reseller.webservices.SendEmail
                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
                    Catch ex As Exception
                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
                    End Try
                End If

            End If
            cmd.Execute(ExecutionType.ExecuteNonQuery)

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"


            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)


            Return Result

            'Else
            'Result.ERRORCODE = -11
            'Result.ERRORDESC = "Invalid Trackid Supplied With respected Status"
            'Return Result
            'End If

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try


    End Function
    '<WebMethod(MessageName:="InsertOrder_PayProcessor")> _
    'Public Overloads Function InsertOrder(ByVal Merchantid As Integer, _
    '                                        ByVal Cloginid As String, _
    '                                        ByVal orderbooked As Integer, _
    '                                        ByVal Amount As Double, _
    '                                        ByVal status As String, _
    '                                        ByVal cardno As String, _
    '                                        ByVal cardtype As String, _
    '                                        ByVal cardname As String, _
    '                                        ByVal cardaddress As String, _
    '                                        ByVal cardexpire As Date, _
    '                                        ByVal securitycode As String, _
    '                                        ByVal issueno As String, _
    '                                        ByVal processtype As String, _
    '                                        ByVal genericcode As String, _
    '                                        ByVal currencycode As String, _
    '                                        ByVal StartDate As Date, _
    '                                        ByVal sender As String, _
    '                                        ByVal Trackid As Integer, _
    '                                        ByVal IpAddress As String, _
    '                                        ByVal houseNo As String, _
    '                                        ByVal zip As String, _
    '                                        ByVal PaymentProcessor As String) As InsertOrderResult

    '    ' For normal Case
    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData

    '    Try
    '        System.Web.HttpContext.Current.Trace.Warn("In InsertOrder_PayProcessor")
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
    '        System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
    '        System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)
    '        System.Web.HttpContext.Current.Trace.Warn("    PaymentProcessor=" & PaymentProcessor)


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
    '        System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

    '        If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

    '            'Counting the no. of successful transactions through following details
    '            System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
    '            System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

    '            Try
    '                'cmd = New CommandData(Merchantid)
    '                cmd = New CommandData(-1)

    '                cmd.AddParameter("@MIdentity", Merchantid)
    '                cmd.AddParameter("@Cloginid", Cloginid)
    '                cmd.AddParameter("@cardno", ECard)

    '                'cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_COUNT_TRANSACTION"
    '                cmd.CmdText = "CXLROBO_COUNT_TRANSACTION"
    '                count = cmd.Execute(ExecutionType.ExecuteScalar)

    '                If count >= CInt(ConfigurationManager.AppSettings("SuccessCriteria")) Then
    '                    SuccessCriteria = True
    '                End If

    '            Catch ex As Exception
    '                System.Web.HttpContext.Current.Trace.Warn("Exception at SuccessCriteria : " & ex.Message)
    '            End Try

    '            System.Web.HttpContext.Current.Trace.Warn("No. of Successful transactions : " & count)
    '            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria : " & SuccessCriteria)

    '            cmd.ClearParameters()
    '            cmd = Nothing
    '            '////////////////////////////////////////////////////////////////////
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

    '        cmd = New CommandData(Merchantid)

    '        cmd.AddParameter("@MIdentity", Merchantid)
    '        cmd.AddParameter("@Cloginid", Cloginid)
    '        cmd.AddParameter("@orderbooked", orderbooked)
    '        'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
    '        cmd.AddParameter("@StartDate", StartDate)
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)
    '        cmd.AddParameter("@houseNo", houseNo)
    '        cmd.AddParameter("@zip", zip)
    '        cmd.AddParameter("@PaymentProcessor", PaymentProcessor)

    '        'If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTMYSQLDATA_MERCHANT")
    '        'cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
    '        cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"
    '        'Else
    '        'System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTDATAINSUSPEND_ATCS_MERCHANT")
    '        'cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"

    '        'End If

    '        'cmd.Execute(ExecutionType.ExecuteNonQuery)

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
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
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
    '            cmd.AddParameter("@StartDate", StartDate)
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IPAddress"))
    '            cmd.AddParameter("@houseNo", dataSetMerchant.Tables(0).Rows(0).Item("houseNo"))
    '            cmd.AddParameter("@zip", dataSetMerchant.Tables(0).Rows(0).Item("zip"))
    '            cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
    '            cmd.AddParameter("@PaymentProcessor", PaymentProcessor)
    '            cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))


    '            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
    '                System.Web.HttpContext.Current.Trace.Warn("Order in Calls Mode")
    '                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"
    '            Else
    '                System.Web.HttpContext.Current.Trace.Warn("Order in Suspend Mode")
    '                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS_CXLT"

    '                If ValidEmailSender(UCase(sender)) = True Then
    '                    Try
    '                        Dim sendEmail As New com.reseller.webservices.SendEmail
    '                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
    '                    Catch ex As Exception
    '                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
    '                    End Try
    '                End If

    '            End If

    '            cmd.CmdType = CommandType.StoredProcedure
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.Commit()
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)
    '        'log = log & ". Calling webservices.reseller.com Service " & vbCrLf
    '        'log = log & ". Having Parameters= " & vbCrLf
    '        'log = log & ". @ResellerID= " & Merchantid & vbCrLf
    '        'log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
    '        'log = log & ". @SerialNumber= " & orderbooked & vbCrLf
    '        'WriteDebugInfo(log, filename)

    '        Return Result

    '    Catch ex As Exception
    '        cmd.RollBack()
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

    '        Result.ERRORCODE = "-1"
    '        Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
    '    End Try


    'End Function
    <WebMethod(MessageName:="InsertOrder_PayProcessor")> _
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
                                            ByVal StartDate As Date, _
                                            ByVal sender As String, _
                                            ByVal Trackid As Integer, _
                                            ByVal IpAddress As String, _
                                            ByVal houseNo As String, _
                                            ByVal zip As String, _
                                            ByVal PaymentProcessor As String) As InsertOrderResult

        ' For normal Case
        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertOrder")
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
            System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
            System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)
            System.Web.HttpContext.Current.Trace.Warn("    PaymentProcessor=" & PaymentProcessor)


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

            If UCase(sender) = "IR" Then
                Dim objReseller As New reseller.webservices.IShopOrderHander

                System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
                objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
                System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            End If

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
            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

            If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

                'Counting the no. of successful transactions through following details
                System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
                System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

                Try
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

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            'If (UCase(status) = "R" And Trackid <> 0) Or (UCase(status) = "N" And Trackid = 0) Then
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@houseNo", houseNo)
            cmd.AddParameter("@zip", zip)
            cmd.AddParameter("@PaymentProcessor", PaymentProcessor)

            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or UCase(PaymentProcessor) = "PP" Or SuccessCriteria = True Then
                System.Web.HttpContext.Current.Trace.Warn("Order is in CALLS MODE")
                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
            Else
                System.Web.HttpContext.Current.Trace.Warn("Order is in SUSPEND MODE")
                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"

                If ValidEmailSender(UCase(sender)) = True Then
                    Try
                        Dim sendEmail As New com.reseller.webservices.SendEmail
                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
                    Catch ex As Exception
                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
                    End Try
                End If

            End If
            cmd.Execute(ExecutionType.ExecuteNonQuery)


            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)


            Return Result

            'Else
            'Result.ERRORCODE = -11
            'Result.ERRORDESC = "Invalid Trackid Supplied With respected Status"
            'Return Result
            'End If

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try


    End Function
    '<WebMethod(MessageName:="InsertOrder")> _
    'Public Overloads Function InsertOrder(ByVal Merchantid As Integer, _
    '                                        ByVal Cloginid As String, _
    '                                        ByVal orderbooked As Integer, _
    '                                        ByVal Amount As Double, _
    '                                        ByVal status As String, _
    '                                        ByVal cardno As String, _
    '                                        ByVal cardtype As String, _
    '                                        ByVal cardname As String, _
    '                                        ByVal cardaddress As String, _
    '                                        ByVal cardexpire As Date, _
    '                                        ByVal securitycode As String, _
    '                                        ByVal issueno As String, _
    '                                        ByVal processtype As String, _
    '                                        ByVal genericcode As String, _
    '                                        ByVal currencycode As String, _
    '                                        ByVal StartDate As Date, _
    '                                        ByVal sender As String, _
    '                                        ByVal Trackid As Integer, _
    '                                        ByVal IpAddress As String) As InsertOrderResult

    '    ' For normal Case
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
    '        System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))


    '        If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

    '            'Counting the no. of successful transactions through following details
    '            System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
    '            System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

    '            Try
    '                'cmd = New CommandData(Merchantid)
    '                cmd = New CommandData(-1)

    '                cmd.AddParameter("@MIdentity", Merchantid)
    '                cmd.AddParameter("@Cloginid", Cloginid)
    '                cmd.AddParameter("@cardno", ECard)

    '                'cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_COUNT_TRANSACTION"
    '                cmd.CmdText = "CXLROBO_COUNT_TRANSACTION"
    '                count = cmd.Execute(ExecutionType.ExecuteScalar)

    '                If count >= CInt(ConfigurationManager.AppSettings("SuccessCriteria")) Then
    '                    SuccessCriteria = True
    '                End If

    '            Catch ex As Exception
    '                System.Web.HttpContext.Current.Trace.Warn("Exception at SuccessCriteria : " & ex.Message)
    '            End Try

    '            System.Web.HttpContext.Current.Trace.Warn("No. of Successful transactions : " & count)
    '            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria : " & SuccessCriteria)

    '            cmd.ClearParameters()
    '            cmd = Nothing
    '            '////////////////////////////////////////////////////////////////////
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

    '        cmd = New CommandData(Merchantid)

    '        cmd.AddParameter("@MIdentity", Merchantid)
    '        cmd.AddParameter("@Cloginid", Cloginid)
    '        cmd.AddParameter("@orderbooked", orderbooked)
    '        'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
    '        cmd.AddParameter("@StartDate", StartDate)
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)


    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTMYSQLDATA_MERCHANT")
    '        cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"


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
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
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
    '            cmd.AddParameter("@StartDate", StartDate)
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IpAddress"))
    '            cmd.AddParameter("@houseNo", dataSetMerchant.Tables(0).Rows(0).Item("houseNo"))
    '            cmd.AddParameter("@zip", dataSetMerchant.Tables(0).Rows(0).Item("zip"))
    '            cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
    '            cmd.AddParameter("@PaymentProcessor", dataSetMerchant.Tables(0).Rows(0).Item("PaymentProcessor"))
    '            cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))


    '            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
    '                System.Web.HttpContext.Current.Trace.Warn("Order in Calls Mode")
    '                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"
    '            Else
    '                System.Web.HttpContext.Current.Trace.Warn("Order in Suspend Mode")
    '                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS_CXLT"

    '                If ValidEmailSender(UCase(sender)) = True Then
    '                    Try
    '                        Dim sendEmail As New com.reseller.webservices.SendEmail
    '                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
    '                    Catch ex As Exception
    '                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
    '                    End Try
    '                End If
    '            End If

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
    '        Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
    '    End Try

    'End Function
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
                                                ByVal StartDate As Date, _
                                                ByVal sender As String, _
                                                ByVal Trackid As Integer, _
                                                ByVal IpAddress As String) As InsertOrderResult

        ' For normal Case
        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertOrder")
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

            If UCase(sender) = "IR" Then
                Dim objReseller As New reseller.webservices.IShopOrderHander

                System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
                objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
                System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            End If

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
            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

            If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

                'Counting the no. of successful transactions through following details
                System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
                System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

                Try
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

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            'If (UCase(status) = "R" And Trackid <> 0) Or (UCase(status) = "N" And Trackid = 0) Then
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)

            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
                System.Web.HttpContext.Current.Trace.Warn("Order is in CALLS MODE")
                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
            Else
                System.Web.HttpContext.Current.Trace.Warn("Order is in SUSPEND MODE")
                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"

                If ValidEmailSender(UCase(sender)) = True Then
                    Try
                        Dim sendEmail As New com.reseller.webservices.SendEmail
                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
                    Catch ex As Exception
                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
                    End Try
                End If

            End If
            cmd.Execute(ExecutionType.ExecuteNonQuery)


            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            log = log & ". Calling webservices.reseller.com Service " & vbCrLf
            log = log & ". Having Parameters= " & vbCrLf
            log = log & ". @ResellerID= " & Merchantid & vbCrLf
            log = log & ". @ResellerCustomerUID= " & Cloginid & vbCrLf
            log = log & ". @SerialNumber= " & orderbooked & vbCrLf
            WriteDebugInfo(log, filename)


            Return Result

            'Else
            'Result.ERRORCODE = -11
            'Result.ERRORDESC = "Invalid Trackid Supplied With respected Status"
            'Return Result
            'End If

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrder End")
        End Try


    End Function
    '<WebMethod(MessageName:="InsertInvoice")> _
    'Public Overloads Function InsertInvoice(ByVal Merchantid As Integer, _
    '                                        ByVal Cloginid As String, _
    '                                        ByVal orderbooked As Integer, _
    '                                        ByVal Amount As Double, _
    '                                        ByVal status As String, _
    '                                        ByVal cardno As String, _
    '                                        ByVal cardtype As String, _
    '                                        ByVal cardname As String, _
    '                                        ByVal cardaddress As String, _
    '                                        ByVal cardexpire As Date, _
    '                                        ByVal securitycode As String, _
    '                                        ByVal issueno As String, _
    '                                        ByVal processtype As String, _
    '                                        ByVal genericcode As String, _
    '                                        ByVal currencycode As String, _
    '                                        ByVal StartDate As Date, _
    '                                        ByVal sender As String, _
    '                                        ByVal Trackid As Integer, _
    '                                        ByVal Invoice_number As Integer, _
    '                                        ByVal IpAddress As String) As InsertOrderResult

    '    ' For Accountspro and Express Case normal case
    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData

    '    Try

    '        System.Web.HttpContext.Current.Trace.Warn("In InsertInvoice")
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
    '        System.Web.HttpContext.Current.Trace.Warn("    Invoice_number=" & Invoice_number)
    '        System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)

    '        MakeLog()
    '        filename = "InvoiceNo - " & Invoice_number
    '        filename = folder & "\" & filename

    '        log = ". @Merchantid= " & Merchantid & vbCrLf
    '        log = log & ". @CLoginid= " & Cloginid & vbCrLf
    '        log = log & ". @InvoiceNumber= " & Invoice_number & vbCrLf
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
    '        cmd.AddParameter("@StartDate", StartDate)
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@Inv_no", Invoice_number)
    '        cmd.AddParameter("@IPAddress", "")


    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTMYSQLDATA_MERCHANT")
    '        cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"

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
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
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
    '            cmd.AddParameter("@StartDate", StartDate)
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@inv_no", Invoice_number)
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IpAddress"))
    '            cmd.AddParameter("@houseNo", 0)
    '            cmd.AddParameter("@zip", 0)
    '            cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
    '            cmd.AddParameter("@PaymentProcessor", dataSetMerchant.Tables(0).Rows(0).Item("PaymentProcessor"))
    '            cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))



    '            System.Web.HttpContext.Current.Trace.Warn("Order in Calls Mode")
    '            cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"

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
    '        Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
    '        Return Result


    '    Finally
    '        If Not cmd Is Nothing Then
    '            cmd.CmdText = "SET XACT_ABORT OFF"
    '            cmd.CmdType = CommandType.Text
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd = Nothing
    '        End If
    '    End Try

    'End Function
    <WebMethod(MessageName:="InsertInvoice")> _
        Public Overloads Function InsertInvoice(ByVal Merchantid As Integer, _
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
                                                ByVal StartDate As Date, _
                                                ByVal sender As String, _
                                                ByVal Trackid As Integer, _
                                                ByVal Invoice_number As Integer, _
                                                ByVal IpAddress As String) As InsertOrderResult

        ' For Accountspro and Express Case normal case
        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try

            System.Web.HttpContext.Current.Trace.Warn("In InsertInvoice")
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
            System.Web.HttpContext.Current.Trace.Warn("    Invoice_number=" & Invoice_number)
            System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IpAddress)

            MakeLog()
            filename = "InvoiceNo - " & Invoice_number
            filename = folder & "\" & filename

            log = ". @Merchantid= " & Merchantid & vbCrLf
            log = log & ". @CLoginid= " & Cloginid & vbCrLf
            log = log & ". @InvoiceNumber= " & Invoice_number & vbCrLf
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

            If ValidSender(sender) = False Then
                Result.ERRORCODE = -10
                Result.ERRORDESC = "Sender is not Authentic"
                Return Result
                Exit Function
            End If

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

            'If (UCase(status) = "R" And Trackid <> 0) Or (UCase(status) = "N" And Trackid = 0) Then
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
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@Inv_no", Invoice_number)
            cmd.AddParameter("@IPAddress", IpAddress)

            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Then
                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
            Else
                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"
            End If

            cmd.Execute(ExecutionType.ExecuteNonQuery)
            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"
            Return Result
            'Else
            'Result.ERRORCODE = -11
            'Result.ERRORDESC = "Trackid is Invalid With respected Status"
            'Return Result
            'End If

        Catch ex As Exception
            ' MsgBox("Error:" & ex.Message())
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
            Return Result


        Finally
            cmd = Nothing
        End Try


    End Function
    Private Sub MakeLog()

        timestring = Date.Now
        folder = "d:\Log_InsertInCxl\" & Date.Today
        folder = Replace(folder, "/", "-")
        CreateFolder(folder)

    End Sub

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
            sw = System.IO.File.AppendText(LogUniquePath & "\InsertInCXL.vb Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        Catch ex As Exception

        End Try
    End Sub

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

    Private Function ValidEmailSender(ByVal Sender As String) As Boolean

        If Application("SuspendEmailSenders") Is Nothing Then
            Application("SuspendEmailSenders") = ConfigurationManager.AppSettings("SuspendEmailSenders")
        End If

        Dim Sender_String As String = Application("SuspendEmailSenders")
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

        'Dim ObjXml As New InfiniLogic.AccountsCentre.common.ConfigReader
        Dim ObjCrypt As New rsaLibrary1.Crypt
        Dim En As String = Info
        Dim E As String
        Dim N As String

        'E = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.E)
        'N = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)

        E = ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.E)
        N = ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)

        En = ObjCrypt.Encrypt(En, E, N)
        En = Replace(En, "+", "p")
        Return En

    End Function

    '<WebMethod(MessageName:="AdminInsertOrderForCallcentre")> _
    'Public Function AdminInsertOrderForCallcentre(ByVal Merchantid As Integer, _
    '                                        ByVal Cloginid As String, _
    '                                        ByVal orderbooked As Integer, _
    '                                        ByVal Amount As Double, _
    '                                        ByVal status As String, _
    '                                        ByVal cardno As String, _
    '                                        ByVal cardtype As String, _
    '                                        ByVal cardname As String, _
    '                                        ByVal cardaddress As String, _
    '                                        ByVal cardexpire As Date, _
    '                                        ByVal securitycode As String, _
    '                                        ByVal issueno As String, _
    '                                        ByVal processtype As String, _
    '                                        ByVal genericcode As String, _
    '                                        ByVal currencycode As String, _
    '                                        ByVal StartDate As Date, _
    '                                        ByVal sender As String, _
    '                                        ByVal Trackid As Integer, _
    '                                        ByVal IpAddress As String, _
    '                                        ByVal houseNo As String, _
    '                                        ByVal zip As String, _
    '                                        ByVal callCentre As String) As InsertOrderResult

    '    ' For normal Case
    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData

    '    Try
    '        System.Web.HttpContext.Current.Trace.Warn("In AdminInsertOrderForCallcentre")
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
    '        System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
    '        System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)
    '        System.Web.HttpContext.Current.Trace.Warn("    callCentre=" & callCentre)


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
    '        System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

    '        If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

    '            'Counting the no. of successful transactions through following details
    '            System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
    '            System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

    '            Try
    '                'cmd = New CommandData(Merchantid)
    '                cmd = New CommandData(-1)

    '                cmd.AddParameter("@MIdentity", Merchantid)
    '                cmd.AddParameter("@Cloginid", Cloginid)
    '                cmd.AddParameter("@cardno", ECard)

    '                'cmd.CmdText = "DBSERVER.cxltransaction.dbo.CXLROBO_COUNT_TRANSACTION"
    '                cmd.CmdText = "CXLROBO_COUNT_TRANSACTION"
    '                count = cmd.Execute(ExecutionType.ExecuteScalar)

    '                If count >= CInt(ConfigurationManager.AppSettings("SuccessCriteria")) Then
    '                    SuccessCriteria = True
    '                End If

    '            Catch ex As Exception
    '                System.Web.HttpContext.Current.Trace.Warn("Exception at SuccessCriteria : " & ex.Message)
    '            End Try

    '            System.Web.HttpContext.Current.Trace.Warn("No. of Successful transactions : " & count)
    '            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria : " & SuccessCriteria)

    '            cmd.ClearParameters()
    '            cmd = Nothing
    '            '////////////////////////////////////////////////////////////////////
    '        End If

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)

    '        cmd = New CommandData(Merchantid)

    '        cmd.AddParameter("@MIdentity", Merchantid)
    '        cmd.AddParameter("@Cloginid", Cloginid)
    '        cmd.AddParameter("@orderbooked", orderbooked)
    '        'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
    '        cmd.AddParameter("@StartDate", StartDate)
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)
    '        cmd.AddParameter("@houseNo", houseNo)
    '        cmd.AddParameter("@zip", zip)
    '        cmd.AddParameter("@callCentre", callCentre)

    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTMYSQLDATA_MERCHANT")
    '        cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"

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
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
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
    '            cmd.AddParameter("@StartDate", StartDate)
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IpAddress"))
    '            cmd.AddParameter("@houseNo", dataSetMerchant.Tables(0).Rows(0).Item("houseNo"))
    '            cmd.AddParameter("@zip", dataSetMerchant.Tables(0).Rows(0).Item("zip"))
    '            cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
    '            cmd.AddParameter("@PaymentProcessor", dataSetMerchant.Tables(0).Rows(0).Item("PaymentProcessor"))
    '            cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))

    '            System.Web.HttpContext.Current.Trace.Warn("Order in Calls Mode")
    '            cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"

    '            cmd.CmdType = CommandType.StoredProcedure
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.Commit()
    '        End If

    '        cmd.Execute(ExecutionType.ExecuteNonQuery)

    '        System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

    '        Return Result

    '    Catch ex As Exception
    '        cmd.RollBack()
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

    '        Result.ERRORCODE = "-1"
    '        Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("AdminInsertOrderForCallcentre End")
    '    End Try

    'End Function
    <WebMethod(MessageName:="AdminInsertOrderForCallcentre")> _
    Public Function AdminInsertOrderForCallcentre(ByVal Merchantid As Integer, _
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
                                            ByVal StartDate As Date, _
                                            ByVal sender As String, _
                                            ByVal Trackid As Integer, _
                                            ByVal IpAddress As String, _
                                            ByVal houseNo As String, _
                                            ByVal zip As String, _
                                            ByVal callCentre As String) As InsertOrderResult

        ' For normal Case
        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In AdminInsertOrderForCallcentre")
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
            System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
            System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)
            System.Web.HttpContext.Current.Trace.Warn("    callCentre=" & callCentre)


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

            If UCase(sender) = "IR" Then
                Dim objReseller As New reseller.webservices.IShopOrderHander

                System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
                objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
                System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            End If

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
            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

            If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

                'Counting the no. of successful transactions through following details
                System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
                System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

                Try
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

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            'If (UCase(status) = "R" And Trackid <> 0) Or (UCase(status) = "N" And Trackid = 0) Then
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@houseNo", houseNo)
            cmd.AddParameter("@zip", zip)
            cmd.AddParameter("@callCentre", callCentre)


            System.Web.HttpContext.Current.Trace.Warn("Order is in CALLS MODE")
            cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"


            cmd.Execute(ExecutionType.ExecuteNonQuery)

            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)

            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("AdminInsertOrderForCallcentre End")
        End Try

    End Function
    '<WebMethod(MessageName:="InsertOrderForMTS")> _
    'Public Overloads Function InsertOrderForMTS(ByVal Merchantid As Integer, _
    '                                        ByVal Cloginid As String, _
    '                                        ByVal orderbooked As Integer, _
    '                                        ByVal Amount As Double, _
    '                                        ByVal status As String, _
    '                                        ByVal cardno As String, _
    '                                        ByVal cardtype As String, _
    '                                        ByVal cardname As String, _
    '                                        ByVal cardaddress As String, _
    '                                        ByVal cardexpire As Date, _
    '                                        ByVal securitycode As String, _
    '                                        ByVal issueno As String, _
    '                                        ByVal processtype As String, _
    '                                        ByVal genericcode As String, _
    '                                        ByVal currencycode As String, _
    '                                        ByVal StartDate As Date, _
    '                                        ByVal sender As String, _
    '                                        ByVal Trackid As Integer, _
    '                                        ByVal IpAddress As String, _
    '                                        ByVal houseNo As String, _
    '                                        ByVal zip As String, _
    '                                        ByVal MTS As String, _
    '                                        ByVal CreateInvoice As String) As InsertOrderResult

    '    ' For normal Case
    '    Dim Result As New InsertOrderResult
    '    Dim cmd As CommandData      ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB

    '    Try
    '        System.Web.HttpContext.Current.Trace.Warn("In InsertOrderForMTS")
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
    '        System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
    '        System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)
    '        System.Web.HttpContext.Current.Trace.Warn("    MTS=" & MTS)
    '        System.Web.HttpContext.Current.Trace.Warn("    CreateInvoice=" & CreateInvoice)


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
    '        cmd.AddParameter("@StartDate", StartDate)
    '        cmd.AddParameter("@Sender", sender)
    '        cmd.AddParameter("@trackid", Trackid)
    '        cmd.AddParameter("@IPAddress", IpAddress)
    '        cmd.AddParameter("@houseNo", houseNo)
    '        cmd.AddParameter("@zip", zip)
    '        cmd.AddParameter("@MTS", MTS)
    '        cmd.AddParameter("@Create_invoice", CreateInvoice)

    '        'If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
    '        '    System.Web.HttpContext.Current.Trace.Warn("Order is in CALLS MODE")
    '        System.Web.HttpContext.Current.Trace.Warn("calling CXLROBO_INSERTMYSQLDATA_MERCHANT")
    '        cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"

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
    '            cmd.AddParameter("@Cloginid", Cloginid)
    '            cmd.AddParameter("@orderbooked", orderbooked)
    '            cmd.AddParameter("@Amount", Amount)
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
    '            cmd.AddParameter("@StartDate", StartDate)
    '            cmd.AddParameter("@Sender", sender)
    '            cmd.AddParameter("@trackid", Trackid)
    '            cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
    '            cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("CreateInvoice"))
    '            cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
    '            cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
    '            cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IpAddress"))
    '            cmd.AddParameter("@houseNo", dataSetMerchant.Tables(0).Rows(0).Item("houseNo"))
    '            cmd.AddParameter("@zip", dataSetMerchant.Tables(0).Rows(0).Item("zip"))
    '            cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
    '            cmd.AddParameter("@PaymentProcessor", dataSetMerchant.Tables(0).Rows(0).Item("PaymentProcessor"))
    '            cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
    '            cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
    '            cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
    '            cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
    '            cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
    '            cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
    '            cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
    '            cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
    '            cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
    '            cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
    '            cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))

    '            System.Web.HttpContext.Current.Trace.Warn("Order in Calls Mode")
    '            cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"

    '            cmd.CmdType = CommandType.StoredProcedure
    '            cmd.Execute(ExecutionType.ExecuteNonQuery)
    '            cmd.Commit()
    '        End If


    '        System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)
    '        WriteDebugInfo(log, filename)
    '        Return Result

    '    Catch ex As Exception
    '        cmd.RollBack()
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

    '        Result.ERRORCODE = "-1"
    '        Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
    '        Return Result

    '    Finally
    '        cmd.CmdText = "SET XACT_ABORT OFF"
    '        cmd.CmdType = CommandType.Text
    '        cmd.Execute(ExecutionType.ExecuteNonQuery)
    '        cmd = Nothing
    '        System.Web.HttpContext.Current.Trace.Warn("InsertOrderForMTS End")
    '    End Try
    'End Function
    <WebMethod(MessageName:="InsertOrderForMTS")> _
    Public Overloads Function InsertOrderForMTS(ByVal Merchantid As Integer, _
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
                                            ByVal StartDate As Date, _
                                            ByVal sender As String, _
                                            ByVal Trackid As Integer, _
                                            ByVal IpAddress As String, _
                                            ByVal houseNo As String, _
                                            ByVal zip As String, _
                                            ByVal MTS As String, _
                                            ByVal CreateInvoice As String) As InsertOrderResult

        ' For normal Case
        Dim Result As New InsertOrderResult

        Dim cmd As New CommandData(Merchantid)       ' 1 Shows Connect With default database, 0 Shows Connect with MerchantDB
        Try
            System.Web.HttpContext.Current.Trace.Warn("In InsertOrderForMTS")
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
            System.Web.HttpContext.Current.Trace.Warn("    houseNo=" & houseNo)
            System.Web.HttpContext.Current.Trace.Warn("    zip=" & zip)
            System.Web.HttpContext.Current.Trace.Warn("    MTS=" & MTS)
            System.Web.HttpContext.Current.Trace.Warn("    CreateInvoice=" & CreateInvoice)


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

            If UCase(sender) = "IR" Then
                Dim objReseller As New reseller.webservices.IShopOrderHander

                System.Web.HttpContext.Current.Trace.Warn("Calling AddMainDBOrder")
                objReseller.AddMainDBOrder(Merchantid, Cloginid, orderbooked)
                System.Web.HttpContext.Current.Trace.Warn("AddMainDBOrder is ok!")
            End If

            

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
            System.Web.HttpContext.Current.Trace.Warn("SuccessCriteria_Implementation : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")))

            If CStr(ConfigurationManager.AppSettings("SuccessCriteria_Implementation")) = "ON" Then

                'Counting the no. of successful transactions through following details
                System.Web.HttpContext.Current.Trace.Warn("Checking no. of successful transactions")
                System.Web.HttpContext.Current.Trace.Warn("Minimum successful transactions set to : " & CStr(ConfigurationManager.AppSettings("SuccessCriteria")))

                Try
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

            System.Web.HttpContext.Current.Trace.Warn("Insertion Started on" & DateTime.Now)
            'If (UCase(status) = "R" And Trackid <> 0) Or (UCase(status) = "N" And Trackid = 0) Then
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@Cloginid", Cloginid)
            cmd.AddParameter("@orderbooked", orderbooked)
            'cmd.AddParameter("@Amount", CDbl(Format(Amount, "0.00")))
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
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@Sender", sender)
            cmd.AddParameter("@trackid", Trackid)
            cmd.AddParameter("@IPAddress", IpAddress)
            cmd.AddParameter("@houseNo", houseNo)
            cmd.AddParameter("@zip", zip)
            cmd.AddParameter("@MTS", MTS)
            cmd.AddParameter("@Create_invoice", CreateInvoice)

            If Merchantid = 2 Or UCase(processtype) = "CB" Or UCase(processtype) = "BP" Or SuccessCriteria = True Then
                System.Web.HttpContext.Current.Trace.Warn("Order is in CALLS MODE")
                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"

                Result.STATUS = "CALLS"
            Else

                System.Web.HttpContext.Current.Trace.Warn("Order is in SUSPEND MODE")
                cmd.CmdText = "CXLROBO_INSERTDATAINSUSPEND_ATCS"

                Result.STATUS = "SUSPEND"
                If ValidEmailSender(UCase(sender)) = True Then
                    Try
                        Dim sendEmail As New com.reseller.webservices.SendEmail
                        sendEmail.SendEmail_SCCO(Merchantid, Cloginid, orderbooked)
                    Catch ex As Exception
                        System.Web.HttpContext.Current.Trace.Warn("Exception at reseller.webservices.SendEmail: " & ex.Message)
                    End Try
                End If

            End If
            cmd.Execute(ExecutionType.ExecuteNonQuery)

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
            Result.ERRORCODE = "0"
            Result.ERRORDESC = "Operation Completed successfully"

            System.Web.HttpContext.Current.Trace.Warn("Insertion completed on" & DateTime.Now)
            WriteDebugInfo(log, filename)
            Return Result

        Catch ex As Exception
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

            Result.ERRORCODE = "-1"
            Result.ERRORDESC = "EXCEPTIOM: " & ex.Message
            Return Result

        Finally
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("InsertOrderForMTS End")
        End Try

    End Function
End Class

