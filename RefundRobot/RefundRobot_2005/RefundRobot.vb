Imports System.Data.SqlClient
Imports RefundRobot.Connection
Imports InfiniLogic.AccountsCentre.common
Imports Microsoft.Win32
Imports System.Net
Imports System.IO

#Region "Sender"
'       AC = AccountsCentre
'       FH = FormationHouse
'       IN = InfiniShops
'       EX = Express
'       PR = AccountsPro
'       IR = InfinishopsReseller
'       IB = InfiniBuyer
'       IM = InfiniMarketPlace
#End Region

#Region "CXLProcessing Intake"
'   CreditCardNO
'   IssueNumber
'   TransactionAmount   <in pennies>
'   GCode               <Like GBP, USD>
'   MerchantId
'   CID                 <Customer ID>
'   OrderID
'   TransactionType     <REFUND>
'   StartDate
'   CardExpiry
'   CardType
'   Mode                <LIVE or TEST>
'   CXLResponseCode     <RETURN VALUE>
'   CXLMessage          <RETURN VALUE>
'   agentName           <CXL>
'   agentAcquirer       <General, GeneralAcquirer, AmexAcquirer>
'   rid                 <TrackId>
'   merchantloginid
'   customerloginid
'   sender
#End Region

Public Class RefundRobot

    Private DoExit As Boolean = False

    Enum LogType As Integer
        Success = 1
        Failure = 0
    End Enum

#Region " .............. Private Variables.............."

    Dim Log As String
    Dim ResponseCode_Cs As String
    Dim CsMessage As String
    Dim Status_atcs As String
    Dim Status_Msg As String


    Dim min As String = "00"
    Dim sec As String = "00"
    Dim str As String = "1:00"

    Dim MyDataSet As DataSet

    Dim DtInProcess As DataTable
    Dim drInProcess As DataRow

    Dim DtProcessed As DataTable
    Dim drProcessed As DataRow

    Dim RecordCount As Integer = 0

    
    Dim Check As Boolean = False

    'Added by Saad on 06/05/08
    Dim house_no As String = "0"
    Dim zip_code As String = "0"
    Dim request_id As Integer = 0

    Dim filename, folder, timestring, FileNameAll As String
    Public DataString As String = "Exceptions:" & vbNewLine
    Dim No_of_Refunds As Integer

#End Region

#Region ".............. DataTable Settings.............."

    Private Sub DataTableSettingForInPRocess()
        DtInProcess = New DataTable  'Seperate 

        DtInProcess.Columns.Add("MerchantID")
        DtInProcess.Columns.Add("CustomerLoginID")
        DtInProcess.Columns.Add("OrderID")
        DtInProcess.Columns.Add("TrackID")
        DtInProcess.Columns.Add("TransactionAmount")
        DtInProcess.Columns.Add("TransactionType")

        DtInProcess.Columns.Add("Sender")
        DtInProcess.Columns.Add("CID")
        DtInProcess.Columns.Add("Invoicenumber")
        DtInProcess.Columns.Add("CreditNote")

        DtInProcess.Columns.Add("StartDate")
        DtInProcess.Columns.Add("CardExpiry")

        DtInProcess.Columns.Add("ccv")
        DtInProcess.Columns.Add("IssueNumber")
        DtInProcess.Columns.Add("Mode")
        DtInProcess.Columns.Add("ByForce")

        DtInProcess.Columns.Add("CreditCardNo")
        DtInProcess.Columns.Add("MerchantLoginID")
        DtInProcess.Columns.Add("AgentName")
        DtInProcess.Columns.Add("AgentAcquirer")
        DtInProcess.Columns.Add("GCode")
        DtInProcess.Columns.Add("CardType")
        DtInProcess.Columns.Add("ReferrerID")
        DtInProcess.Columns.Add("Emp_code")
        DtInProcess.Columns.Add("ridAgainstInvoice")
        DtInProcess.Columns.Add("houseNo")
        DtInProcess.Columns.Add("zip")
        DtInProcess.Columns.Add("cardname")


    End Sub

    Private Sub DataTableSettingForPRocessed()

        DtProcessed = New DataTable

        DtProcessed.Columns.Add("MerchantID")
        DtProcessed.Columns.Add("CustomerLoginID")
        DtProcessed.Columns.Add("OrderID")
        DtProcessed.Columns.Add("TrackID")
        DtProcessed.Columns.Add("ReferrerID")
        DtProcessed.Columns.Add("CXLCode")
        DtProcessed.Columns.Add("CXLMessage")
        DtProcessed.Columns.Add("TransactionAmount")
        DtProcessed.Columns.Add("TransactionType")

        DtProcessed.Columns.Add("Sender")
        DtProcessed.Columns.Add("CID")
        DtProcessed.Columns.Add("Invoicenumber")
        DtProcessed.Columns.Add("CreditNote")

        DtProcessed.Columns.Add("Mode")
        DtProcessed.Columns.Add("ByForce")

    End Sub

    Private Sub InProcess(ByVal dt As DataTable, ByVal RowNo As Integer, ByVal Trackid As String)

        ' DtInProcess = New DataTable
        drInProcess = DtInProcess.NewRow

        drInProcess(0) = dt.Rows(RowNo).Item("MerchantID")

        drInProcess(1) = dt.Rows(RowNo).Item("CustomerLoginID")
        drInProcess(2) = dt.Rows(RowNo).Item("OrderID")
        drInProcess(3) = Trackid
        drInProcess(4) = dt.Rows(RowNo).Item("TransactionAmount")
        drInProcess(5) = dt.Rows(RowNo).Item("TransactionType")

        drInProcess(6) = dt.Rows(RowNo).Item("Sender")
        drInProcess(7) = dt.Rows(RowNo).Item("CID")
        drInProcess(8) = dt.Rows(RowNo).Item("Invoicenumber")
        drInProcess(9) = dt.Rows(RowNo).Item("CreditNote")
        drInProcess(10) = dt.Rows(RowNo).Item("StartDate")
        drInProcess(11) = dt.Rows(RowNo).Item("CardExpiry")

        drInProcess(12) = dt.Rows(RowNo).Item("ccv")
        drInProcess(13) = dt.Rows(RowNo).Item("IssueNumber")
        drInProcess(14) = dt.Rows(RowNo).Item("Mode")
        drInProcess(15) = dt.Rows(RowNo).Item("ByForce")


        drInProcess(16) = dt.Rows(RowNo).Item("CreditCardNo")
        drInProcess(17) = dt.Rows(RowNo).Item("MerchantLoginID")
        drInProcess(18) = dt.Rows(RowNo).Item("AgentName")
        drInProcess(19) = dt.Rows(RowNo).Item("AgentAcquirer")
        drInProcess(20) = dt.Rows(RowNo).Item("GCode")
        drInProcess(21) = dt.Rows(RowNo).Item("CardType")
        drInProcess(22) = dt.Rows(RowNo).Item("Referrer_Id") 'Trackid 
        drInProcess(23) = dt.Rows(RowNo).Item("Emp_code")
        drInProcess(24) = dt.Rows(RowNo).Item("ridAgainstInvoice")
        drInProcess(25) = dt.Rows(RowNo).Item("houseNo")
        drInProcess(26) = dt.Rows(RowNo).Item("zip")
        drInProcess(27) = dt.Rows(RowNo).Item("cardname")

        DtInProcess.Rows.Add(drInProcess)

        GridInProcess.DataSource = DtInProcess
    End Sub

    Private Sub Processed(ByVal dr As DataRow, ByVal CxlCode As String, ByVal CxlMessage As String)

        drProcessed = DtProcessed.NewRow

        drProcessed(0) = dr.Item("MerchantID")
        drProcessed(1) = dr.Item("CustomerLoginID")
        drProcessed(2) = dr.Item("OrderID")
        drProcessed(3) = dr.Item("TrackID")
        drProcessed(4) = dr.Item("ReferrerID")
        drProcessed(5) = CxlCode
        drProcessed(6) = CxlMessage
        drProcessed(7) = dr.Item("TransactionAmount")
        drProcessed(8) = dr.Item("TransactionType")
        drProcessed(9) = dr.Item("Sender")
        drProcessed(10) = dr.Item("CID")
        drProcessed(11) = dr.Item("Invoicenumber")
        drProcessed(12) = dr.Item("CreditNote")
        drProcessed(13) = dr.Item("Mode")
        drProcessed(14) = dr.Item("ByForce")
        'drProcessed(15) = dr.Item("ridAgainstInvoice")


        DtProcessed.Rows.Add(drProcessed)

        GridProcessed.DataSource = DtProcessed
    End Sub

#End Region

    Private Sub RefundRobot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim URL As String = "http://gaterefund.infinilogic.com/Cxlrefund.asmx"
        Dim URL As String = "http://gatewayrefund.infinilogic.com/cxlRefundService.asmx"

        Dim b As Boolean = True 'ISURLValid(URL)

        Try
            If b = True Then
                DataTableSettingForPRocessed()
                QueryTimer.Interval = 10 * 1000 '10 seconds
                timerPopulate.Interval = 1000
                timerPopulate.Enabled = True
                str = TxtElapse.Text

                ' WriteElapseValueInRegistry()
            Else
                MsgBox("'gatewayrefund.infinilogic.com' is down")
                End
            End If
        Catch ex As Exception
            Log = Log & ",RefundRobot_Load, Exception: " & ex.Message & vbCrLf
        End Try
    End Sub

    Public Function ISURLValid(ByVal url As String) As Boolean
        Dim req As HttpWebRequest
        Dim res As HttpWebResponse = Nothing

        Dim r As System.IO.StreamReader = Nothing
        Dim ex As Exception     'error exeption holder 
        Dim pge As String       'page holder 
        Dim status As Boolean = False

        Try
            ' request url 
            req = WebRequest.Create(url)

            'get page 
            res = req.GetResponse()
            r = New System.IO.StreamReader(res.GetResponseStream())
            pge = r.ReadToEnd

            If (pge <> Nothing) Then
                status = True
            End If

        Catch ex
            status = False
            Log = Log & ",ISURLValid: " & url & "Exception: " & ex.Message & vbCrLf
            'InsertCallingLogIntoDatabase(Log, LogType.Failure)

        Finally
            pge = Nothing
            If Not r Is Nothing Then
                r.Close()
            End If

            If Not res Is Nothing Then
                res.Close()
            End If
        End Try

        Return status
    End Function

    '#Region ".............. Registery Entries For Elapsed Time............."

    '    Private Sub WriteElapseValueInRegistry()
    '        Dim sAns As String
    '        Dim sErr As String = ""
    '        sAns = RegValue(RegistryHive.LocalMachine, _
    '         "SOFTWARE\REFUNDROBOT", "Value", sErr)


    '        If sAns Is Nothing Then
    '            ''Create Registry
    '            Dim regKey As RegistryKey
    '            regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
    '            regKey.CreateSubKey("REFUNDROBOT")
    '            regKey.Close()
    '            regKey = Registry.LocalMachine.OpenSubKey("Software\REFUNDROBOT", True)
    '            regKey.SetValue("AppName", "REFUNDROBOT_ElapseTime")
    '            regKey.SetValue("Value", "30:00")
    '            regKey.Close()

    '        Else
    '            'Read Value and compare it if values changed then email is generated
    '            If (sAns <> "01:00") Then '"30:00") Then
    '                SendEmail("Attention The Elapsed Time of Refund Robot Is Changed", "The old Value was 30:00 and New value is = " & sAns)
    '                timerPopulate.Enabled = False
    '            Else
    '                str = sAns
    '                timerPopulate.Enabled = True

    '            End If
    '        End If

    '    End Sub

    '    Public Function RegValue(ByVal Hive As RegistryHive, ByVal Key As String, ByVal ValueName As String, Optional ByRef ErrInfo As String = "") As String

    '        Dim objParent As RegistryKey
    '        Dim objSubkey As RegistryKey
    '        Dim sAns As String
    '        Select Case Hive
    '            Case RegistryHive.ClassesRoot
    '                objParent = Registry.ClassesRoot
    '            Case RegistryHive.CurrentConfig
    '                objParent = Registry.CurrentConfig
    '            Case RegistryHive.CurrentUser
    '                objParent = Registry.CurrentUser
    '            Case RegistryHive.DynData
    '                objParent = Registry.DynData
    '            Case RegistryHive.LocalMachine
    '                objParent = Registry.LocalMachine
    '            Case RegistryHive.PerformanceData
    '                objParent = Registry.PerformanceData
    '            Case RegistryHive.Users
    '                objParent = Registry.Users

    '        End Select

    '        Try
    '            objSubkey = objParent.OpenSubKey(Key)
    '            'if can't be found, object is not initialized
    '            If Not objSubkey Is Nothing Then
    '                sAns = (objSubkey.GetValue(ValueName))
    '            End If

    '        Catch ex As Exception

    '            ErrInfo = ex.Message
    '        Finally

    '            'if no error but value is empty, populate errinfo

    '        End Try
    '        Return sAns
    '    End Function

    '#End Region
  
    Private Sub timerPopulate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPopulate.Tick
        timerPopulate.Enabled = False

        'Refund Log
        TimeString = Date.Now
        folder = "d:\Refund_Log\" & Date.Today
        folder = Replace(folder, "/", "-")
        CreateFolder(folder)

        FetchNewOrders()
    End Sub

    Private Sub FetchNewOrders()
        If DoExit = True Then
            End
        End If
        Dim BLL As New RefundRobot_BLL
        MyDataSet = New DataSet

        
        Dim Obj As New RefundRobot_BLL
        No_of_Refunds = Obj.NoOfRefundInvoicesInADay()

        Dim Refund_Limit As Integer = CInt(My.Settings.Refund_Limit)

        lblLimit.Text = CStr(No_of_Refunds) & "/" & CStr(Refund_Limit)
        lblDate.Text = Date.Now.Date

        Try

            MyDataSet = BLL.FetchDataFromRefundInvoices(RecordCount)
            Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

            gridData.DataSource = MyDataSet.Tables(0)
            Dim a As Integer = 0

            With progressRefundOrders
                .Minimum = 0
                .Maximum = RecordCount
                .Value = 0
            End With

            If (RecordCount > 0) Then
                For a = 0 To RecordCount - 1
                    With MyDataSet.Tables(0).Rows(a)
                        Log = ""
                        progressRefundOrders.Value = a + 1
                        Application.DoEvents()
                    End With
                Next
                ''Forward one of the record to 2nd Grid for processing
                DataTableSettingForInPRocess()
                InProcessOrders(MyDataSet.Tables(0), 0)
            Else
                QueryTimer.Enabled = True
            End If

        Catch ex As Exception
            Log = Log & ",FetchNewOrders, Exception: " & ex.Message & vbCrLf
            InsertCallingLogIntoDatabase(Log, LogType.Failure)
            SendEmail("Exception occurs at RefundRobot, Function: FetchNewOrders", ex.Message)
        Finally
            Log = ""
        End Try
    End Sub
  
    Private Sub InProcessOrders(ByVal dt As DataTable, ByVal RowNo As Integer)

        '' Calling For Symbol
        Dim rid As Long
        Dim Symbol As String

        filename = "Order_No - " & dt.Rows(RowNo).Item("OrderId")
        filename = folder & "\" & filename
        Log = Log & "-------------------- PROCESS START ---------------------- " & vbCrLf

        Dim Obj As New RefundRobot_BLL

        Symbol = Obj.GetCurrencySymbol(dt.Rows(RowNo).Item("CCode"), dt.Rows(RowNo).Item("GCode"))
        Log = Log & "STEP:1 ,Symbol: " & Symbol & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception
        WriteDebugInfo(Log, filename)

        If (dt.Rows(RowNo).Item("Trackid") = 0) Then
            ''Calling Collection Service For Trackid Generation Cam_ADDINVOICE

            Log = Log & "NEW TRACK ID is generating" & vbCrLf
            rid = GetTrackIDFromCOllectionService(dt.Rows(RowNo).Item("CustomerLoginId"), dt.Rows(RowNo).Item("CID"), dt.Rows(RowNo).Item("MerchantId"), dt.Rows(RowNo).Item("TransactionAmount"), rid, dt.Rows(RowNo).Item("Sender"), dt.Rows(RowNo).Item("OrderID"), "REFUND", dt.Rows(RowNo).Item("Mode"), dt.Rows(RowNo).Item("ProcessType"), dt.Rows(RowNo).Item("GCode"), dt.Rows(RowNo).Item("CCode"), dt.Rows(RowNo).Item("Processed_time"), Symbol)

            Log = Log & "STEP:2 ,Track_ID: " & rid & vbCrLf
            Log = Log & ",Exception: " & RefundRobot_BLL.Exception
            WriteDebugInfo(Log, filename)

            '' Update this Trackid in RefundCalls
            Obj.UpdateTrackid(dt.Rows(RowNo).Item("CustomerLoginId"), dt.Rows(RowNo).Item("MerchantId"), rid, dt.Rows(RowNo).Item("OrderId"), dt.Rows(RowNo).Item("InvoiceNumber"), dt.Rows(RowNo).Item("CreditNote"))
            Log = Log & "STEP:3 ,UpdateTrackid " & vbCrLf
            Log = Log & "Exception: " & RefundRobot_BLL.Exception
            WriteDebugInfo(Log, filename)

        Else
            rid = dt.Rows(RowNo).Item("Trackid")
            Log = Log & "STEP:2 ,Existing Track_ID " & rid
            WriteDebugInfo(Log, filename)
        End If

        request_id = rid
        InProcess(dt, RowNo, rid)

        Dim arr() As String
        arr = str.Split(":")
        min = arr(0)
        sec = arr(1)
        If (Len(min) = 1) Then
            min = "0" & min
        End If
        If (Len(sec) = 1) Then
            sec = "0" & sec
        End If

        lblMin.Text = CStr(min)
        lblSec.Text = CStr(sec)

        InProcessTimer.Interval = 1000 * (1 / 4) '15 sec Saad Timer
        InProcessTimer.Enabled = True

    End Sub

    Private Sub ProcessedOrders(ByVal row As DataRow, ByVal CXLResponsecode As String, ByVal CXLMessage As String)

        Processed(row, CXLResponsecode, CXLMessage)
        QueryTimer.Enabled = True
        lblMin.Text = min
        lblSec.Text = sec
    End Sub

    Private Function GetTrackIDFromCOllectionService(ByVal CustomerLoginId As String, ByVal CustID As String, ByVal MerId As String, ByVal Amt As String, ByVal Rid As Long, ByVal Sender As String, ByVal OrderID As String, ByVal TranType As String, ByVal mode As String, ByVal PaymentMode As String, ByVal Gcode As String, ByVal CCode As String, ByVal Processed_time As String, ByVal symbol As String) As Integer
        Dim obj As New RefundRobot_BLL
        Try
            'If (OrderData.Tables(0).Rows.Count > 0) Then
            Dim OrderDate As Date = Processed_time
            Dim formateddate1 As String = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim formateddate2 As String = OrderDate.ToString("MM/dd/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim Send As String = GetSender(Sender)
            Dim Del_add As String
            'If (IsDBNull(OrderData.Tables(0).Rows(0).Item("del_add"))) Then
            Del_add = ""
            'Else
            '    Del_add = OrderData.Tables(0).Rows(0).Item("del_add")
            'End If
            Dim DCamAddinvoice As DataSet = obj.GetRidFromCS(CustomerLoginId, CustID, MerId, formateddate2, Amt, "INVOICE FROM REFUND", TranType, formateddate1, "*", OrderID, UCase(PaymentMode), "CompanyName", Rid, Del_add, "*", Send, mode, Gcode, CCode, symbol)
            If (DCamAddinvoice.Tables(0).Rows.Count > 0) Then
                Return (DCamAddinvoice.Tables(0).Rows(0).Item("rid"))
            Else
                Return 0
            End If
            'Else
            'Return 0
            'End If
        Catch ex As Exception

        End Try
    End Function

    Private Function GetSender(ByVal Sender As String) As String

        Select Case Sender
            Case "AC"
                Return "AccountsCentre"

            Case "FH"
                Return "FormationHouse"
            Case "IN"
                Return "InfiniShops"
            Case "EX"
                Return "Express"
            Case "PR"
                Return "AccountsPro"
            Case "IR"
                Return "InfinishopsReseller"
            Case "IB"
                Return "InfiniBuyer"
            Case "IM"
                Return "InfiniMarketPlace"

            Case Else
                Return "Invalid Sender"
        End Select

    End Function

    Private Sub CXLCodeAction(ByVal Row As DataRow, ByVal CXLResponsecode As String, ByVal CXLMessage As String)

        If (CXLResponsecode = "0" Or CXLResponsecode = "00") Then ' CXLR_CODE="0" means Succesfull Transaction

            SuccessfulCXL(Row, CXLResponsecode, CXLMessage)

        ElseIf (CXLResponsecode = "-1") Then  'Declined the Order by CXL

            Decline(Row, CXLResponsecode, CXLMessage)

        ElseIf (CXLResponsecode = "-2") Then  'Invalid parameter passing

            ParameterMissing(Row, CXLResponsecode, CXLMessage)

        ElseIf (CXLResponsecode = "-31") Then  ' Server Down

            'Dim ToCXLRefundWebService As New Cxlrefund

            '' check CXL Service is Down or up
            'If (ToCXLRefundWebService.IfRefundLive = "LIVE" Or ToCXLRefundWebService.IfRefundLive = "Live" Or ToCXLRefundWebService.IfRefundLive = "live") Then
            SendEmail("Please Investigate Refund Order (CXLSERVER is UP @ Time: ", " Sender = " & Row.Item("sender") & " Merchant ID= " & Row.Item("MerchantId") & " OrderID= " & Row.Item("OrderID") & " Cloginid = " & Row.Item("CustomerLoginId") & " TrackId = " & Row.Item("TrackID") & " Cxl Code = " & CXLResponsecode)
            Decline(Row, CXLResponsecode, CXLMessage)

            'End If

        ElseIf (CXLResponsecode = "-32") Then  'Cxl Receive the request but didn't respond
            SendEmail("Please Investigate Refund Order @ Time: ", " Sender = " & Row.Item("sender") & " Merchant ID= " & Row.Item("MerchantId") & " OrderID= " & Row.Item("OrderID") & " Cloginid = " & Row.Item("CustomerLoginId") & " TrackId = " & Row.Item("TrackID") & " Cxl Code = " & CXLResponsecode)
            Decline(Row, CXLResponsecode, CXLMessage)

        Else
            Decline(Row, CXLResponsecode, CXLMessage)
            'Decline(Row, ResponseCode_Cs, CsMessage)
        End If

        RefundRobot_BLL.Exception = Nothing
        InsertCallingLogIntoDatabase(Log, LogType.Success)
        ProcessedOrders(Row, CXLResponsecode, CXLMessage)

    End Sub

    Private Function Decrypt(ByVal CardNo As String) As String

        Dim ObjXml As New InfiniLogic.AccountsCentre.common.ConfigReader
        Dim ObjCrypt As New rsaLibrary1.Crypt

        Dim i As Integer
        Dim En As String = CardNo
        i = En.IndexOf("p")
        Dim D As String
        Dim N As String

        'En = Ds.Tables(0).Rows(i).Item("cardno")
        En = Replace(En, "p", "+")
        D = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.D)
        N = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)
        Decrypt = ObjCrypt.Decrypt(En, D, N)

    End Function

    Private Sub SendEmail(ByVal Subject As String, ByVal Body As String)

        Dim mySMTPClient As System.Net.Mail.SmtpClient

        If My.Settings.LOCAL_Mail_Server = "TRUE" Then
            mySMTPClient = New System.Net.Mail.SmtpClient(My.Settings.SMTPServer_LOCAL)
        Else
            mySMTPClient = New System.Net.Mail.SmtpClient(My.Settings.SMTPServer)
        End If

        Dim message1 As New System.Net.Mail.MailMessage(My.Settings.Error_Email_ID_From, My.Settings.Error_Email_ID, Subject, Body)
        message1.IsBodyHtml = False

        Dim ccEmailAdd As New System.Net.Mail.MailAddress("rehan@infinilogic.com")
        Dim bccEmailAdd As New System.Net.Mail.MailAddress("shariq@infinilogic.com")
        message1.CC.Add(ccEmailAdd)
        message1.Bcc.Add(bccEmailAdd)

        'mySMTPClient.Credentials = New Net.NetworkCredential(My.Settings.Error_Email_ID, My.Settings.Error_Email_Password)

        Try
            mySMTPClient.Send(message1)
        Catch exception3 As Exception

        Finally
            message1 = Nothing
        End Try
    End Sub

    Private Sub InsertCallingLogIntoDatabase(ByVal Log As String, ByVal Type As LogType)

        Dim cmd As CommandData = Nothing

        Try
            cmd = New CommandData

            cmd.AddParameter("@Date_Time", Now)
            'cmd.AddParameter("@IPAddress", IPAddress) ' Not Required
            'cmd.AddParameter("@Referrer", Referrer) ' Not Required
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

    Private Function GetAmountInPennies(ByVal Amount As Double) As Long
        Dim V1, V2 As Long
        Dim samount As String = Amount.ToString
        If InStr(samount, ".") > 0 Then
            V1 = Microsoft.VisualBasic.Left(Amount.ToString, InStr(samount, ".") - 1)
            V2 = Microsoft.VisualBasic.Mid(samount & "00", InStr(samount, ".") + 1, 2)
            V1 = (V1 * 100) + V2
        Else
            V1 = (Amount * 100)
        End If
        Return V1
    End Function

    ' Implemented By Sadia Waleem
    Private Sub CXLPreRequisitiesAndCalling(ByVal Row As DataRow)

        Dim CXLMessage As String = ""
        Dim CXLResponseCode As String = ""
        Dim CxlUid, CxlPwd, CxlServer As String
        Dim transAmount As String = CStr(GetAmountInPennies(Row.Item("TransactionAmount")))

        Try
            Log = Log & "STEP 7: CXL CALLING :" & vbCrLf
            Log = Log & ",ByForce: " & Row.Item("ByForce") & vbCrLf

            Log = Log & ",Cardno: " & Row.Item("CreditCardno") & vbCrLf
            Log = Log & ",IssueNumber: " & Row.Item("IssueNumber") & vbCrLf
            Log = Log & ",transAmount: " & transAmount & vbCrLf
            Log = Log & ",GCode: " & Row.Item("GCode") & vbCrLf
            Log = Log & ",MerchantId: " & Row.Item("MerchantId") & vbCrLf
            Log = Log & ",CID: " & Row.Item("CID") & vbCrLf
            Log = Log & ",OrderID: " & Row.Item("OrderID") & vbCrLf
            Log = Log & ",TransactionType: " & Row.Item("TransactionType") & vbCrLf
            Log = Log & ",S_date: " & Row.Item("StartDate") & vbCrLf
            Log = Log & ",C_expire: " & Row.Item("CardExpiry") & vbCrLf
            Log = Log & ",CardType: " & Row.Item("CardType") & vbCrLf
            Log = Log & ",MODE: " & Row.Item("Mode") & vbCrLf
            Log = Log & ",CXLResponseCode: " & CXLResponseCode & vbCrLf
            Log = Log & ",CXLMessage: " & CXLMessage & vbCrLf
            Log = Log & ",AgentName: " & Row.Item("AgentName") & vbCrLf
            Log = Log & ",Trackid: " & Row.Item("Trackid") & vbCrLf
            Log = Log & ",merchantloginid: " & Row.Item("merchantloginid") & vbCrLf
            Log = Log & ",customerloginid: " & Row.Item("customerloginid") & vbCrLf
            Log = Log & ",sender: " & Row.Item("sender") & vbCrLf
            Log = Log & ",house_no: " & Row.Item("houseNo") & vbCrLf
            Log = Log & ",zip_code: " & Row.Item("zip") & vbCrLf
            Log = Log & ",ccv: " & Row.Item("ccv") & vbCrLf
            Log = Log & ",RidAgainstInvoice: " & Row.Item("ridAgainstInvoice") & vbCrLf
            Log = Log & ",Employee Code: " & Row.Item("Emp_code") & vbCrLf
            Log = Log & ",CardName: " & Row.Item("cardname") & vbCrLf

            Log = Log & ",Passing parameters to CXL"
            WriteDebugInfo(Log, filename)

            If (Row.Item("ByForce") = "N") Then

                Dim Cardno As String
                If Not IsDBNull(Row.Item("CreditCardno")) Then Cardno = Decrypt(Row.Item("CreditCardno")) Else Cardno = Nothing

                Dim IssueNumber As String
                If Not IsDBNull(Row.Item("IssueNumber")) Then IssueNumber = Decrypt(Row.Item("IssueNumber")) Else IssueNumber = Nothing

                Dim ccv As String
                If Not IsDBNull(Row.Item("ccv")) Then ccv = Decrypt(Row.Item("ccv")) Else ccv = Nothing

                Dim S_date, C_expire As String
                If Not IsDBNull(Row.Item("StartDate")) Then S_date = Format(CDate(Row.Item("StartDate")), "MM/yy") Else S_date = Nothing
                If Not IsDBNull(Row.Item("CardExpiry")) Then C_expire = Format(CDate(Row.Item("CardExpiry")), "MM/yy") Else C_expire = Nothing


                Dim obj As Object = Nothing
                Dim t1 As DateTime = Now

                Dim RidAgainstInvoice As Long = Row.Item("ridAgainstInvoice")


                Dim houseNo As String = Row.Item("houseNo")
                If houseNo = "" Then
                    houseNo = "0"
                End If

                Dim cardName As String = Row.Item("cardName")
                If cardName = "" Then
                    cardName = "0"
                End If

                Dim zip As String = Row.Item("zip")
                If zip = "" Then
                    zip = "0"
                End If

                'Dim ToCXLRefundWebService As New Cxlrefund
                'Added by saad on 05/05/08
                Dim ToCXLRefundWebService_new As New com.infinilogic.gatewayrefund.CXLRefundService
                CxlUid = ConfigReader.GetItem(ConfigVariables.CXLUserID) '"cxlUser"  
                CxlPwd = ConfigReader.GetItem(ConfigVariables.CXLPassword) '"CxlPass"  

                If My.Settings.LOCAL_Mail_Server = "FALSE" Then
                    CxlServer = ConfigReader.GetItem(ConfigVariables.CXLServerIP)
                End If
                '"CxlServer"
                'CxlServer = "192.168.4.81"

                ToCXLRefundWebService_new.Credentials = New System.Net.NetworkCredential(CxlUid, CxlPwd, CxlServer)

                'Log = Log & ",Cardno: " & Len(Cardno) & vbCrLf
                'Log = Log & ",IssueNumber: " & Len(IssueNumber) & vbCrLf
                'Log = Log & ",transAmount: " & transAmount & vbCrLf
                'Log = Log & ",GCode: " & CStr(Row.Item("GCode")) & vbCrLf
                'Log = Log & ",MerchantId: " & CStr(Row.Item("MerchantId")) & vbCrLf
                'Log = Log & ",CID: " & CStr(Row.Item("CID")) & vbCrLf
                'Log = Log & ",OrderID: " & CStr(Row.Item("OrderID")) & vbCrLf
                'Log = Log & ",TransactionType: " & CStr(Row.Item("TransactionType")) & vbCrLf
                'Log = Log & ",S_date: " & S_date & vbCrLf
                'Log = Log & ",C_expire: " & C_expire & vbCrLf
                'Log = Log & ",CardType: " & CStr(Row.Item("CardType")) & vbCrLf
                'Log = Log & ",MODE: " & CStr(Row.Item("Mode")) & vbCrLf
                'Log = Log & ",CXLResponseCode: " & CXLResponseCode & vbCrLf
                'Log = Log & ",CXLMessage: " & CXLMessage & vbCrLf
                'Log = Log & ",AgentName: " & CStr(Row.Item("AgentName")) & vbCrLf
                'Log = Log & ",Trackid: " & CInt(Row.Item("Trackid")) & vbCrLf
                'Log = Log & ",merchantloginid: " & CStr(Row.Item("merchantloginid")) & vbCrLf
                'Log = Log & ",customerloginid: " & CStr(Row.Item("customerloginid")) & vbCrLf
                'Log = Log & ",sender: " & CStr(Row.Item("sender")) & vbCrLf
                'Log = Log & ",house_no: " & houseNo & vbCrLf
                'Log = Log & ",zip_code: " & zip & vbCrLf
                'Log = Log & ",ccv: " & ccv & vbCrLf
                'Log = Log & ",RidAgainstInvoice: " & RidAgainstInvoice & vbCrLf
                'Log = Log & ",Employee Code: " & CStr(Row.Item("Emp_code")) & vbCrLf
                'WriteDebugInfo(Log, filename)


                If (Row.Item("Mode") = "TEST") Then
                    'Added by Sadia Waleem
                    'If ccv = "" Then
                    '    obj = ToCXLRefundWebService_new.CXLProcessingRefund(Cardno, IssueNumber, transAmount, CStr(Row.Item("GCode")), CStr(Row.Item("MerchantId")), CStr(Row.Item("CID")), CStr(Row.Item("OrderID")), CStr(Row.Item("TransactionType")), S_date, C_expire, CStr(Row.Item("CardType")), CStr(Row.Item("Mode")), CXLResponseCode, CXLMessage, CStr(Row.Item("AgentName")), "TEST ACCOUNT", CInt(Row.Item("Trackid")), CStr(Row.Item("merchantloginid")), CStr(Row.Item("customerloginid")), CStr(Row.Item("sender")), houseNo, zip, RidAgainstInvoice, CStr(Row.Item("Emp_code")))
                    'Else
                    '    obj = ToCXLRefundWebService_new.CXLProcessingRefund(Cardno, IssueNumber, transAmount, CStr(Row.Item("GCode")), CStr(Row.Item("MerchantId")), CStr(Row.Item("CID")), CStr(Row.Item("OrderID")), CStr(Row.Item("TransactionType")), S_date, C_expire, CStr(Row.Item("CardType")), CStr(Row.Item("Mode")), CXLResponseCode, CXLMessage, CStr(Row.Item("AgentName")), "TEST ACCOUNT", CInt(Row.Item("Trackid")), CStr(Row.Item("merchantloginid")), CStr(Row.Item("customerloginid")), CStr(Row.Item("sender")), ccv, houseNo, zip, RidAgainstInvoice, CStr(Row.Item("Emp_code")))
                    'End If

                    If ccv = "" Then
                        obj = ToCXLRefundWebService_new.CXLProcessingRefund(Cardno, IssueNumber, transAmount, Row.Item("GCode"), Row.Item("MerchantId"), Row.Item("CID"), Row.Item("OrderID"), Row.Item("TransactionType"), S_date, C_expire, Row.Item("CardType"), Row.Item("Mode"), CXLResponseCode, CXLMessage, Row.Item("AgentName"), "TEST ACCOUNT", Row.Item("Trackid"), Row.Item("merchantloginid"), Row.Item("customerloginid"), Row.Item("sender"), houseNo, zip, RidAgainstInvoice, Row.Item("Emp_code"), cardName)
                    Else
                        obj = ToCXLRefundWebService_new.CXLProcessingRefund(Cardno, IssueNumber, transAmount, Row.Item("GCode"), Row.Item("MerchantId"), Row.Item("CID"), Row.Item("OrderID"), Row.Item("TransactionType"), S_date, C_expire, Row.Item("CardType"), Row.Item("Mode"), CXLResponseCode, CXLMessage, Row.Item("AgentName"), "TEST ACCOUNT", Row.Item("Trackid"), Row.Item("merchantloginid"), Row.Item("customerloginid"), Row.Item("sender"), ccv, houseNo, zip, RidAgainstInvoice, Row.Item("Emp_code"), cardName)
                    End If

                Else
                    If ccv = "" Then
                        obj = ToCXLRefundWebService_new.CXLProcessingRefund(Cardno, IssueNumber, transAmount, CStr(Row.Item("GCode")), CStr(Row.Item("MerchantId")), CStr(Row.Item("CID")), CStr(Row.Item("OrderID")), CStr(Row.Item("TransactionType")), S_date, C_expire, CStr(Row.Item("CardType")), CStr(Row.Item("Mode")), CXLResponseCode, CXLMessage, CStr(Row.Item("AgentName")), CStr(Row.Item("AgentAcquirer")), CStr(Row.Item("Trackid")), CStr(Row.Item("merchantloginid")), CStr(Row.Item("customerloginid")), CStr(Row.Item("sender")), houseNo, zip, RidAgainstInvoice, CStr(Row.Item("Emp_code")), cardName)
                    Else
                        obj = ToCXLRefundWebService_new.CXLProcessingRefund(Cardno, IssueNumber, transAmount, CStr(Row.Item("GCode")), CStr(Row.Item("MerchantId")), CStr(Row.Item("CID")), CStr(Row.Item("OrderID")), CStr(Row.Item("TransactionType")), S_date, C_expire, CStr(Row.Item("CardType")), CStr(Row.Item("Mode")), CXLResponseCode, CXLMessage, CStr(Row.Item("AgentName")), CStr(Row.Item("AgentAcquirer")), CStr(Row.Item("Trackid")), CStr(Row.Item("merchantloginid")), CStr(Row.Item("customerloginid")), CStr(Row.Item("sender")), ccv, houseNo, zip, RidAgainstInvoice, CStr(Row.Item("Emp_code")), cardName)
                    End If
                End If

            Else
                CXLResponseCode = "0"
                CXLMessage = "Credit Card is Processed Successfully in Test Mode (Assume)"
            End If

            Log = Log & ",CXL CODE ACTION: " & vbCrLf
            Log = Log & ",CXLResponseCode: " & CXLResponseCode & vbCrLf
            Log = Log & ",CXLMessage: " & CXLMessage

            CXLCodeAction(DtInProcess.Rows(0), Trim(CXLResponseCode), CXLMessage)

            WriteDebugInfo(Log, filename)

        Catch ex As Exception
            Log = Log & ",CXLPreRequisitiesAndCalling, Exception: " & ex.Message
            WriteDebugInfo(Log, filename)
            CXLCodeAction(DtInProcess.Rows(0), Trim(CXLResponseCode), CXLMessage)

        End Try

    End Sub

#Region "........... Updation Based on CXL Code............"

    Private Sub ParameterMissing(ByVal Row As DataRow, ByVal CXLR_Code As String, ByVal CXL_Msg As String)

        ResponseCode_Cs = "-9"
        CsMessage = "Parameter Missing"
        Status_atcs = "D"
        Status_Msg = "Parameter Missing Problem Pass to CXL"

        Log = Log & ",STEP 8 :  ParameterMissing" & vbCrLf
        Log = Log & ",Parameter Missing Problem With CXLCODE = " & CXLR_Code & vbCrLf

        InsertCallingLogIntoDatabase(Log, LogType.Failure)

        Dim BLL As New RefundRobot_BLL

        BLL.UpdateRefundCalls(Row.Item("MerchantId"), Row.Item("CustomerLoginId"), Row.Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, ResponseCode_Cs, Status_atcs, Row.Item("InvoiceNumber"), Row.Item("CreditNote"))
        Log = Log & ",STEP 9: UpdateRefundCalls" & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        Log = Log & "-------------------- PROCESS END ---------------------- "
        WriteDebugInfo(Log, filename)

    End Sub

    Private Sub SuccessfulCXL(ByVal Row As DataRow, ByVal CXLR_Code As String, ByVal CXL_Msg As String)

        ResponseCode_Cs = "1"
        CsMessage = CXL_Msg
        Status_atcs = "Y"
        Status_Msg = "Successfull"

        Log = Log & ",STEP 8 :  SuccessfulCXL" & vbCrLf
        Log = Log & ",CreditCard Sucessfully Gets Authorize Code = " & CXLR_Code & vbCrLf

        'InsertCallingLogIntoDatabase(Log, LogType.Success)

        Log = Log & ",Calling Posting CreditNote Method Against Invoice Number  = " & Row.Item("InvoiceNumber") & " Credit Note= " & Row.Item("CreditNote") & vbCrLf

        'InsertCallingLogIntoDatabase(Log, LogType.Success)

        Dim Chk As String
        Dim BLL As New RefundRobot_BLL
        Dim Obj As New InvoicePost.AccountsProService

        Chk = Obj.RefundRobot_PostCreditInvoice(Row.Item("MerchantId"), Row.Item("CreditNote"))
        Log = Log & ",STEP 9 :  RefundRobot_PostCreditInvoice" & Chk & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        If (Chk = "0") Then
            ' Update Trackid Field of Pro
            Log = Log & ",STEP 10 :" & vbCrLf
            Log = Log & ",Invoice is posted successfully" & vbCrLf
            Log = Log & ",MerchantID: " & Row.Item("MerchantId") & vbCrLf
            'InsertCallingLogIntoDatabase(Log, LogType.Success)

        Else
            ' Update Trackid Field of Pro
            Log = Log & ",STEP 10 :" & vbCrLf
            Log = Log & ",Invoice is not posted successfully" & vbCrLf
            Log = Log & ",MerchantID: " & Row.Item("MerchantId") & vbCrLf
            'InsertCallingLogIntoDatabase(Log, LogType.Failure)

        End If

        BLL.Update_InformationToPro_RefundInvoice(Row.Item("MerchantId"), Row.Item("OrderID"), Row.Item("CreditNote"), Row.Item("ReferrerID"), Status_atcs, Status_Msg)
        Log = Log & ",STEP 11: Update_InformationToPro_RefundInvoice" & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        ' Call Merchant Transfer Sp of Collection SErvice "collection_service_automateprocessinvoice
        BLL.CSAdminAutomateProcessInvoice(Row.Item("Merchantid"), Row.Item("TransactionAmount"), request_id, Row.Item("TransactionType"), Row.Item("InvoiceNumber"))
        Log = Log & ",STEP 12: CSAdminAutomateProcessInvoice" & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        ' It Should Update the Respective Refund Table (i.e RefundCalls)
        BLL.UpdateRefundCalls(Row.Item("MerchantId"), Row.Item("CustomerLoginId"), Row.Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, ResponseCode_Cs, Status_atcs, Row.Item("InvoiceNumber"), Row.Item("CreditNote"))
        Log = Log & ",STEP 13: UpdateRefundCalls" & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        Log = Log & "-------------------- PROCESS END ---------------------- "
        WriteDebugInfo(Log, filename)

    End Sub

    Private Sub Decline(ByVal row As DataRow, ByVal CxlR_Code As String, ByVal Cxl_Msg As String)

        'ResponseCode_Cs = "-1"    ' CxlR_code = "30" '' Credit card Decline from CXL

        Status_atcs = "D"
        Status_Msg = Cxl_Msg

        Log = Log & ",STEP 8 :  Decline" & vbCrLf
        Log = Log & ",Credit Card Declined Having CXLCODE = " & CxlR_Code & vbCrLf
        'InsertCallingLogIntoDatabase(Log, LogType.Failure)

        If (Cxl_Msg = "" Or CxlR_Code = "30") Then
            'CsMessage = "CXL DECLINE CREDIT CARD"
        Else
            CsMessage = Cxl_Msg
        End If

        Dim BLL As New RefundRobot_BLL

        BLL.Update_InformationToPro_RefundInvoice(row.Item("MerchantId"), row.Item("OrderID"), row.Item("CreditNote"), row.Item("ReferrerID"), Status_atcs, Status_Msg)
        Log = Log & ",STEP 9: Update_InformationToPro_RefundInvoice" & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        BLL.UpdateRefundCalls(row.Item("MerchantId"), row.Item("CustomerLoginId"), row.Item("OrderID"), CxlR_Code, Cxl_Msg, CsMessage, ResponseCode_Cs, Status_atcs, row.Item("InvoiceNumber"), row.Item("CreditNote"))
        Log = Log & ",STEP 10: UpdateRefundCalls" & vbCrLf
        Log = Log & ",Exception: " & RefundRobot_BLL.Exception & vbCrLf

        Log = Log & "-------------------- PROCESS END ---------------------- "
        WriteDebugInfo(Log, filename)

    End Sub

#End Region

#Region "..............Timer Events........................"


    Private Sub QueryTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles QueryTimer.Tick
        QueryTimer.Enabled = False
        FetchNewOrders()
    End Sub

    Private Sub InProcessTimer_Tick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles InProcessTimer.Tick

        If CInt(min) > 0 Then
            min = CInt(min) - 1
            If (min = 0) Then
                InProcessTimer.Interval = 1000
                sec = 15
                sec = CInt(sec) - 1
            End If
        ElseIf sec > 0 Then
            sec = CInt(sec) - 1

        ElseIf (min = 0 And sec = 0) Then
            InProcessTimer.Enabled = False

            Dim Allow As Boolean = True
            Log = Log & ",InProcessTimer_Tick1: "
            WriteDebugInfo(Log, filename)

            'Dim No_of_Refunds As Integer
            Dim dtmerchantAllow As DataSet
            Dim Obj As New RefundRobot_BLL

            Try
                No_of_Refunds = Obj.NoOfRefundInvoicesInADay()
                Log = Log & ",STEP 4: No_of_Refunds " & No_of_Refunds & vbCrLf
                Log = Log & ",Exception: " & RefundRobot_BLL.Exception
                WriteDebugInfo(Log, filename)

                dtmerchantAllow = Obj.IsMerchantAllowed(CInt(DtInProcess.Rows(0).Item("MerchantID")))
                Log = Log & ",STEP 5: IsMerchantAllowed: " & DtInProcess.Rows(0).Item("MerchantID") & vbCrLf
                Log = Log & ",IsMerchantAllowed (Y/N)(1/0): " & dtmerchantAllow.Tables(0).Rows.Count & vbCrLf
                Log = Log & ",Exception: " & RefundRobot_BLL.Exception
                WriteDebugInfo(Log, filename)

                Dim Refund_Limit As Integer = CInt(My.Settings.Refund_Limit)
                Log = Log & ",STEP 6: Refund_Limit: " & Refund_Limit & vbCrLf
                Log = Log & ",Exception: " & RefundRobot_BLL.Exception
                WriteDebugInfo(Log, filename)

                lblLimit.Text = CStr(No_of_Refunds) & "/" & CStr(Refund_Limit)

                If No_of_Refunds > Refund_Limit Then 'No of Refunds in same day
                    'CXLResponseCode = "-700"
                    'CXLMessage = "Refunds Expired"
                    ResponseCode_Cs = "-700"
                    CsMessage = "Refund Limit Expired: Max no. of limits"
                    Allow = False

                ElseIf DtInProcess.Rows(0).Item("Emp_code") = "0" Then
                    'CXLResponseCode = "-2"
                    'CXLMessage = "Employee Code is missing"
                    ResponseCode_Cs = "-2"
                    CsMessage = "Employee Code is missing"
                    Allow = False

                ElseIf dtmerchantAllow.Tables(0).Rows(0).Item("Control_Refund") = "N" Then
                    'CXLResponseCode = "-500"
                    'CXLMessage = "Restricted Merchant"

                    ResponseCode_Cs = "-500"
                    CsMessage = "Restricted Merchant"
                    Allow = False
                End If

                Log = Log & ",ResponseCode_Cs: " & ResponseCode_Cs & vbCrLf
                Log = Log & ",CsMessage: " & CsMessage & vbCrLf
                Log = Log & ",Allow: " & Allow
                WriteDebugInfo(Log, filename)


            Catch ex As Exception
                Log = Log & "Exception at: " & ex.Message
                WriteDebugInfo(Log, filename)
            End Try

            If Allow = True Then
                Check = CheckAmountValidation(DtInProcess.Rows(0))
                Log = Log & "CheckAmountValidation " & Check
                WriteDebugInfo(Log, filename)

                If (Check = True) Then
                    btnExit.Enabled = False
                    BtnCancellAll.Enabled = False
                    BtnCancel.Enabled = False
                    BtnOk.Enabled = False
                    TxtElapse.Enabled = False
                    CXLPreRequisitiesAndCalling(DtInProcess.Rows(0))
                    btnExit.Enabled = True
                    BtnCancellAll.Enabled = True
                    BtnCancel.Enabled = True
                    BtnOk.Enabled = True
                    TxtElapse.Enabled = True
                Else

                    ResponseCode_Cs = "-600"
                    CsMessage = "Refunded Amount Is Greater Than Actual Order Amount"

                    CXLCodeAction(DtInProcess.Rows(0), Trim(ResponseCode_Cs), CsMessage)

                    Log = Log & ",Check: " & Check & vbCrLf
                    Log = Log & ",ResponseCode_Cs: " & ResponseCode_Cs & vbCrLf
                    Log = Log & ",CsMessage: " & CsMessage
                    WriteDebugInfo(Log, filename)

                End If
                'Else
                '    CXLCodeAction(DtInProcess.Rows(0), Trim(ResponseCode_Cs), CsMessage)
            End If

            DtInProcess = Nothing
            GridInProcess.DataSource = DtInProcess

        End If

        If (Len(min) = 1) Then
            min = "0" & min
        End If
        If (Len(sec) = 1) Then
            sec = "0" & sec
        End If
        lblMin.Text = CStr(min)
        lblSec.Text = CStr(sec)

    End Sub
#End Region

    Private Function CheckAmountValidation(ByVal D As DataRow) As Boolean

        Dim Bll As New RefundRobot_BLL

        Dim Calls_atcs_OrderAmount As Double
        Dim Refund_Calls_OrderAmount As Double

        Dim Temp_ds As DataSet

        Temp_ds = Bll.GetAmountFromCalls_ATCS(D.Item("MerchantID"), D.Item("CustomerLoginid"), D.Item("OrderID"), D.Item("InvoiceNumber"), D.Item("Trackid"))
        Log = Log & ",Exception :" & RefundRobot_BLL.Exception & vbCrLf

        Calls_atcs_OrderAmount = CDbl(Temp_ds.Tables(0).Rows(0).Item("Amount"))

        Dim J As Integer
        For J = 0 To Temp_ds.Tables(1).Rows.Count - 1
            Refund_Calls_OrderAmount = Refund_Calls_OrderAmount + CDbl(Temp_ds.Tables(1).Rows(J).Item("RefundAmount"))
        Next

        If Format(Calls_atcs_OrderAmount, "0.00") >= Format(Refund_Calls_OrderAmount, "0.00") Then
            Return True
        Else
            Return False
        End If

    End Function

#Region "............. Buttton Events......................"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        If (CInt(min) > 0 Or CInt(sec) > 0) Then
            '' Cancel the Order
            Dim BLL As New RefundRobot_BLL
            BLL.CanCelOrder(DtInProcess.Rows(0))
            min = "01"
            sec = "00"

            lblMin.Text = min
            lblSec.Text = sec

            If (InProcessTimer.Enabled = True) Then
                InProcessTimer.Enabled = False
            End If
            DtInProcess = Nothing
            GridInProcess.DataSource = DtInProcess
            QueryTimer.Enabled = True
        End If
    End Sub

    Private Sub BtnCancellAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancellAll.Click
        If (CInt(min) > 0 Or CInt(sec) > 0) Then
            '' Cancel the Order
            Dim x As Integer
            For x = 0 To MyDataSet.Tables(0).Rows.Count - 1
                Dim BLL As New RefundRobot_BLL
                BLL.CanCelOrder(MyDataSet.Tables(0).Rows(x))
                'MyDataSet.Tables(0).Rows.Remove(MyDataSet.Tables(0).Rows(0))
            Next

            MyDataSet = Nothing
            DtInProcess = Nothing
            GridInProcess.DataSource = DtInProcess
            gridData.DataSource = Nothing
            min = "01"
            sec = "00"
            lblMin.Text = min
            lblSec.Text = sec
            If (InProcessTimer.Enabled = True) Then
                InProcessTimer.Enabled = False
            End If
            QueryTimer.Enabled = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        If (CInt(min) > 0 Or CInt(sec) > 0) Then
            If Not (DtInProcess Is Nothing) And (DtInProcess.Rows.Count = 0) Then
                '' Cancel the Order
                DataTableSettingForInPRocess()
                If (DtInProcess.Rows.Count > 0) Then
                    Dim BLL As New RefundRobot_BLL
                    BLL.CanCelOrder(DtInProcess.Rows(0))
                End If
                DoExit = True
                FetchNewOrders()
            End If
        ElseIf (CInt(min = 0) Or CInt(sec) = 0) Then
            If Not (MyDataSet Is Nothing) And (MyDataSet.Tables(0).Rows.Count = 0) Then
                If Not (DtInProcess Is Nothing) Then
                    If DtInProcess.Rows.Count = 0 Then
                        DoExit = True
                    End If
                ElseIf DtInProcess Is Nothing Then
                    DoExit = True
                End If
            Else
                DoExit = False
            End If
        Else

            DoExit = False
        End If

    End Sub

    Private Sub BtnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        '' generate email
        SendEmail("Attention The Elapsed Time of Refund Robot Is Changed", "The old Value was = " & str & " and New value is = " & TxtElapse.Text)
        'timerPopulate.Enabled = False
        'QueryTimer.Enabled = False
        InProcessTimer.Enabled = False
        str = TxtElapse.Text
        Dim Temp As String = TxtElapse.Text
        Dim s() As String = Temp.Split(":")
        lblMin.Text = s(0)
        lblSec.Text = s(1)
        min = s(0)
        sec = s(1)
        InProcessTimer.Interval = 1000 * 60 '1min
        InProcessTimer.Enabled = True


    End Sub

    Private Sub GridInProcess_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GridInProcess.RowsAdded
        gridData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Blue
        gridData.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White

    End Sub

    'Private Sub GridProcessed_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GridProcessed.RowsAdded
    '    gridData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green
    '    gridData.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
    'End Sub
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
            Log = Log & ex.Message & "Create Folder" & vbNewLine
            InsertCallingLogIntoDatabase(Log, LogType.Failure)
        End Try
    End Sub

    Private Sub WriteDebugInfo(ByVal sText As String, ByVal LogUniquePath As String)

        Try
            If Not System.IO.Directory.Exists(LogUniquePath) Then
                System.IO.Directory.CreateDirectory(LogUniquePath)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(LogUniquePath & "\REFUND_ROBOT.vb Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()

            ''(SZ:RC) Added by Saad on 03/01/08 for counting no. of retries per order
            'Dim sr As System.IO.StreamReader
            'sr = System.IO.File.OpenText(LogUniquePath & "\CXLROBOT.vb Trace.txt")
            'Dim str As String = sr.ReadToEnd
            'sr.Close()
            'Dim counts As String() = Split(str, "CXLROBO_GETORDERINFO")
            'retryCount = counts.Length - 1
            ''(SZ)           

            log = ""
        Catch ex As Exception
            Log = Log & ex.Message & "WriteDebugInfo Method" & vbNewLine
            InsertCallingLogIntoDatabase(Log, LogType.Failure)
        End Try
    End Sub
#End Region

    Private Sub lblDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDate.Click

    End Sub
End Class