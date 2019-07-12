Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Mail
Imports System.Configuration


<System.Web.Services.WebService(Namespace := "http://tempuri.org/refundcomponent.accountscentre.com/RefundInvoices")> _
Public Class RefundInvoices
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    Enum LogType As Integer
        Success = 1
        Failure = 0
    End Enum

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '

    Public Structure InsertRefundOrderResult
        Public ERRORCODE As String
        Public ERRORDESC As String
    End Structure

    Dim Result As New InsertRefundOrderResult

    <WebMethod(MessageName:="RefundInvoice")> _
        Public Function RefundInvoice(ByVal Merchant_Id As Integer, ByVal Customer_Login_ID As String, ByVal Invoice_No As Integer, ByVal CreditNote_No As Integer, ByVal RefundAmount As Double, ByVal Emp_Code As String, ByVal IP_Address As String, ByVal RidAgainstInvoice As String) As InsertRefundOrderResult
        InsertRefundIntoDatabase(Merchant_Id, Customer_Login_ID, Invoice_No, CreditNote_No, RefundAmount, Emp_Code, IP_Address, RidAgainstInvoice)
        Return Result

    End Function

    Private Sub InsertCallingLogIntoDatabase(ByVal IPAddress As String, ByVal Referrer As String, ByVal Log As String, ByVal Type As LogType)

        Dim cmd As CommandData

        Try
            cmd = New CommandData

            cmd.AddParameter("@Date_Time", Now)
            cmd.AddParameter("@IPAddress", IPAddress)
            cmd.AddParameter("@Referrer", Referrer)
            If Type = LogType.Success Then
                cmd.AddParameter("@SuccessLog", Log)
                cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_INSERTSUCCESSLOG"
            ElseIf Type = LogType.Failure Then
                cmd.AddParameter("@ErrorLog", Log)
                cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_INSERTERRORLOG"
            End If

            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As Exception
            SendEmail("[Logging Error]", ex.ToString)
        Finally
            If cmd._Connection.State = ConnectionState.Open Then
                cmd.CloseConnection()
            End If
            cmd = Nothing
        End Try
    End Sub

    Private Sub InsertRefundIntoDatabase(ByVal Merchantid As Integer, ByVal Customer_Login_ID As String, ByVal Invoice_No As Integer, ByVal CreditNote_No As Integer, ByVal RefundAmount As Double, ByVal Emp_Code As String, ByVal IP_Address As String, ByVal ridAgainstInvoice As Long)

        System.Web.HttpContext.Current.Trace.Warn("PROCESS START ")
        System.Web.HttpContext.Current.Trace.Warn("    Merchantid=" & Merchantid)
        System.Web.HttpContext.Current.Trace.Warn("    Cloginid=" & Customer_Login_ID)
        System.Web.HttpContext.Current.Trace.Warn("    Invoice_No=" & Invoice_No)
        System.Web.HttpContext.Current.Trace.Warn("    CreditNote_No=" & CreditNote_No)
        System.Web.HttpContext.Current.Trace.Warn("    RefundAmount=" & RefundAmount)
        System.Web.HttpContext.Current.Trace.Warn("    Emp_Code=" & Emp_Code)
        System.Web.HttpContext.Current.Trace.Warn("    IpAddress=" & IP_Address)
        System.Web.HttpContext.Current.Trace.Warn("    ridAgainstInvoice=" & ridAgainstInvoice)

        'Dim IPAddress As String = Me.Context.Request.UserHostAddress
        Dim ToLog As LogType

        'If InStr("," & IPAddress & ",", ConfigurationSettings.AppSettings.Item("Allowed_IPAddress")) Then
        '    InsertCallingLogIntoDatabase(IPAddress, Me.Context.Request.UrlReferrer.Host, "You are not allowed to call this method.", LogType.Failure)
        '    SendEmail("[IP Blocked]", Me.Context.Request.UrlReferrer.Host & vbCrLf & IPAddress & vbCrLf & "You are not allowed to call this method.")
        '    Result.ERRORCODE = "-2"
        '    Result.ERRORDESC = "[This " & IPAddress & "IP Is Blocked]"
        '    Exit Sub
        'End If

        Dim Log As String
        Dim ReturnValue As String
        Dim cmd As CommandData
        Try
            cmd = New CommandData(Merchantid)
            cmd.AddParameter("@MIdentity", Merchantid)
            cmd.AddParameter("@CustomerLoginID", Customer_Login_ID)
            cmd.AddParameter("@InvoiceNo", Invoice_No)
            cmd.AddParameter("@CreditNoteNo", CreditNote_No)
            cmd.AddParameter("@RefundAmount", RefundAmount)
            cmd.AddParameter("@Emp_Code", Emp_Code)
            cmd.AddParameter("@Ip_Address", IP_Address)
            cmd.AddParameter("@ridAgainstInvoice", ridAgainstInvoice)
            cmd.AddParameter("@Return", 0, ParameterDirection.ReturnValue)
            cmd.CmdText = "REFUND_INSERTREFUNDDATA"

            System.Web.HttpContext.Current.Trace.Warn("    CALLING SP:: REFUND_INSERTREFUNDDATA")
            System.Web.HttpContext.Current.Trace.Warn("    Connection String:" & cmd.ConnectionString)

            Log = Log & "[Connection String]" & vbCrLf
            'Log = Log & cmd.ConnectionString & vbCrLf & vbCrLf

            Log = Log & "[Stored Procedure Call]" & vbCrLf
            Log = Log & "exec REFUND_INSERTREFUNDDATA" & vbCrLf
            Log = Log & "  @MIdentity = " & Merchantid & vbCrLf
            Log = Log & ", @CustomerLoginID = '" & Customer_Login_ID & "'" & vbCrLf
            Log = Log & ", @InvoiceNo = " & Invoice_No & vbCrLf
            Log = Log & ", @CreditNoteNo = " & CreditNote_No & vbCrLf
            Log = Log & ", @RefundAmount = " & RefundAmount & vbCrLf

            cmd.Execute(ExecutionType.ExecuteNonQuery)
            ReturnValue = cmd.Item("@Return")

            System.Web.HttpContext.Current.Trace.Warn("    ReturnValue :" & ReturnValue)

            If ReturnValue = 0 Then
                Log = Log & "[Record Not Found]" & vbCrLf & vbCrLf
                ToLog = LogType.Failure
                SendEmail("[Record Not Found]", Log)
                Result.ERRORCODE = "-1"
                Result.ERRORDESC = "[Record Not Found in Calls_atcs]"
            Else
                Log = Log & "[Success]"
                ToLog = LogType.Success
                Result.ERRORCODE = "0"
                Result.ERRORDESC = "Operation Completed successfully"
            End If

            System.Web.HttpContext.Current.Trace.Warn("    ERRORCODE :" & Result.ERRORCODE)
            System.Web.HttpContext.Current.Trace.Warn("    ERRORDESC :" & Result.ERRORDESC)

        Catch ex As Exception
            ToLog = LogType.Failure
            Log = Log & "[Failure]" & vbCrLf & vbCrLf
            Log = Log & "[Exception]" & ex.ToString

            System.Web.HttpContext.Current.Trace.Warn("    EXCEPTION :" & ex.ToString)
            SendEmail("[Database Error]", Log)

        Finally
            If cmd._Connection.State = ConnectionState.Open Then
                cmd.CloseConnection()
            End If
            cmd = Nothing
            System.Web.HttpContext.Current.Trace.Warn("    PROCESS END")

            'If Me.Context.Request.UrlReferrer Is Nothing Then
            '    InsertCallingLogIntoDatabase(IPAddress, IPAddress, Log, ToLog)
            'Else
            '    InsertCallingLogIntoDatabase(IPAddress, Me.Context.Request.UrlReferrer.Host, Log, ToLog)
            'End If

            'InsertCallingLogIntoDatabase(IPAddress, Me.Context.Request.UrlReferrer.Host, Log, ToLog)
        End Try
    End Sub

    Private Sub SendEmail(ByVal Subject As String, ByVal Body As String)
        If UCase(ConfigurationSettings.AppSettings.Item("LOCAL")) = "TRUE" Then
            SmtpMail.SmtpServer = ConfigurationSettings.AppSettings.Item("SMTPServer_LOCAL")
        Else
            SmtpMail.SmtpServer = ConfigurationSettings.AppSettings.Item("SMTPServer_LIVE")
        End If

        Dim message1 As New MailMessage
        message1.To = ConfigurationSettings.AppSettings.Item("Error_Email_ID_TO")
        message1.From = ConfigurationSettings.AppSettings.Item("Error_Email_ID_FROM")
        ' Password = ErrRefund
        message1.Subject = Subject
        message1.Body = Body
        message1.BodyFormat = MailFormat.Text

        'If ConfigReader.GetItem(ConfigVariables.SMTP_Authentication) = "1" Then

        'message1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
        'message1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "refund.errors@accountscentre.com")
        'message1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "ErrRefund")

        'End If
        Try
            SmtpMail.Send(message1)
        Catch exception3 As Exception

        Finally
            message1 = Nothing
        End Try
    End Sub

End Class
