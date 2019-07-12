Imports System.Web.Services
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://sbc.accountscentre.com/")> _
Public Class CustomerDetail
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
        components = New System.ComponentModel.Container
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

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function

#Region "............Private Variable"

    Dim MerchantID As String
    Dim CLoginID As String
    Dim OrderBooked As String
    Dim CXLCode As String
    Dim CXLMessage As String
    Dim TrackID As String
    Dim Status As String
    Dim CardNo As String
    Dim ProcessType As String
    Dim Sender As String
    Dim invoice_no As String

    Dim NormalizeData As DataSet
    Dim Dt As DataTable
    Dim Data As DataRow


    Dim filename, log, folder, timestring, FileNameAll As String

#End Region

    ''' This webservice Takes A value and after that An SP is called which fetches data against that value from 
    ''' Calls_atcs table

#Region "............Folder Creation methods and log files maintain functions..........."
    Private Sub CreateFolder(ByVal vfolder)
        Try
            Dim fs, f, s
            If (Directory.Exists(vfolder) = False) Then
                fs = CreateObject("Scripting.FileSystemObject")
                f = fs.CreateFolder(vfolder)
            End If
            fs = Nothing
            f = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Sub WriteStrToFile(ByVal MyKeyString As String, ByVal strFileName As String)
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(strFileName)
            objReader.Write(MyKeyString)
            objReader.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WriteDebugInfo(ByVal sText As String, ByVal LogUniquePath As String)

        If Not System.IO.Directory.Exists(LogUniquePath) Then
            System.IO.Directory.CreateDirectory(LogUniquePath)
        End If
        Dim sw As System.IO.StreamWriter
        sw = System.IO.File.AppendText(LogUniquePath & "\CustomerDetail.asmx.vb Trace.txt")
        sw.WriteLine(Now & " -- " & sText)
        sw.Close()

    End Sub
#End Region

    <WebMethod()> _
       Public Function GetInformation(ByVal CardNo As Long) As DataSet

        folder = "d:\sbc.AccountsCentre.com.Log\" & Date.Today
        folder = Replace(folder, "/", "-")
        CreateFolder(folder)

        filename = "Log"
        filename = folder & "\" & filename

        log = ""
        log = " . Calling Encryption Function. " & vbCrLf
        WriteDebugInfo(log, filename)

        Dim DsRecord As DataSet
        Try

           
            Dim EncryptedValue As String = EnCrypt(CardNo)

            log = " . Encrypted value  " & EncryptedValue & vbCrLf
            WriteDebugInfo(log, filename)

            DsRecord = New DataSet

            NormalizeData = New DataSet

            log = " . Getting Value From DB . " & vbCrLf
            log = log & " Calling CXLROBO_GETLIST" & vbCrLf
            WriteDebugInfo(log, filename)

            DsRecord = GetRecords(Trim(EncryptedValue))

            RecordsFetch(DsRecord)
            '  Dim Arr As New ArrayList

            'If (NormalizeData.Tables(0).Rows.Count > 1) Then
            '    Dim I As Integer
            '    For I = 0 To NormalizeData.Tables(0).Rows.Count - 1
            '        Arr = New ArrayList

            '        Arr.Add(DsRecord.Tables(0).Rows(I).Item(""))

            '    Next
            'End If
            'Return Arr
            Return NormalizeData

        Catch ex As Exception
            log = ""
            log = " . Execpetion . " & ex.Message & vbCrLf
            WriteDebugInfo(log, filename)


        Finally

            NormalizeData = Nothing


        End Try

    End Function

    <WebMethod()> _
     Public Function GetInformationByTrackId(ByVal TrackId As Long) As DataSet


        Dim DsRecord As DataSet
        Try
            DsRecord = New DataSet
            NormalizeData = New DataSet

            DsRecord = GetRecordsByTrackId(TrackId)

            RecordsFetchForRId(DsRecord)
            Return NormalizeData

        Catch ex As Exception

        Finally
            NormalizeData = Nothing

        End Try

    End Function

    <WebMethod()> _
       Public Function BlockRules(ByVal Merchant_Id As Integer, ByVal Rule_Type As Integer, ByVal Rule_Value As String, ByVal EnableBlock As Boolean) As String

        If (Rule_Type > "5" Or Rule_Value = "" Or Merchant_Id = "0") Then

            Return " RuleValue and MerchantID should not be Empty or NULL And Allowable Rule_type Value is Less than 5"

        Else

            If (InsertInBlockRules(Merchant_Id, Rule_Type, Rule_Value, EnableBlock) = True) Then

                Return "Successful"
            Else
                Return "Unsuccessful"
            End If

        End If


    End Function

    <WebMethod()> _
      Public Function GetBlockRules(ByVal Merchant_Id As Integer, ByVal Rule_Type As Integer) As DataSet


        Dim DsRecord As DataSet
        Try

            DsRecord = New DataSet

            DsRecord = GetBlockRule(Merchant_Id, Rule_Type)

            NormalizeData = New DataSet

            Fetch(DsRecord)
            Return NormalizeData


        Catch ex As Exception
            ' MsgBox("Error:" & ex.Message())

        Finally

            NormalizeData = Nothing


        End Try



    End Function

    Private Function InsertInBlockRules(ByVal Mid As Integer, ByVal RuleType As Integer, ByVal RuleValue As String, ByVal Enabled As Boolean) As Boolean

        Dim cmd As New CommandData(-1)

        Try
            cmd.CmdText = "SET XACT_ABORT ON"
            cmd.CmdType = CommandType.Text
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.BeginTransaction(True)


            cmd.AddParameter("@MerchantID", Mid)
            cmd.AddParameter("@Rule_Type", RuleType)

            If RuleType = 0 And Enabled = True Then
                RuleValue = EnCrypt(RuleValue)
            End If
            cmd.AddParameter("@Rule", RuleValue)

            If Enabled = True Then
                cmd.AddParameter("@Enabled", "Y")
            Else
                cmd.AddParameter("@Enabled ", "N")
            End If

            cmd.CmdText = "CXLROBO_INSERTINBLOCKRULES"
            cmd.CmdType = CommandType.StoredProcedure
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.Commit()
            Return True

        Catch ex As Exception
            'Return False
            cmd.RollBack()
            cmd = Nothing
            Throw New Exception(ex.Message)

        Finally
            cmd.CmdText = "SET XACT_ABORT OFF"
            cmd.CmdType = CommandType.Text
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd = Nothing
        End Try

    End Function


    Private Function EnCrypt(ByVal ValueToEncrypt As Long) As String

        Try


            Dim ObjConfig As New InfiniLogic.AccountsCentre.common.ConfigReader
            Dim ObjCrypt As New rsaLibrary1.Crypt
            Dim ValueEncrypted As String

            'log = " . Start Reading InitLoc XML File . " & vbCrLf
            'WriteDebugInfo(log, filename)

            Dim E, N As String
            E = ObjConfig.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.E)
            N = ObjConfig.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)

            'log = " . End Reading InitLoc XML File . " & vbCrLf
            'log = " . Value of E " & E & " Value of N " & N & vbCrLf
            'WriteDebugInfo(log, filename)

            ValueEncrypted = ObjCrypt.Encrypt(ValueToEncrypt, E, N)
            ValueEncrypted = Replace(ValueEncrypted, "+", "p")
            Return ValueEncrypted

        Catch ex As Exception

        End Try
    End Function

    Private Function GetRecords(ByVal EncryptedValue As String) As DataSet

        Dim ObjCmd As New CommandData(-1)
        Dim Ds As New DataSet
        Try
            ObjCmd.AddParameter("@En_Card", EncryptedValue)

            ObjCmd.CmdText = "CXLROBO_GETLIST"

            Ds = ObjCmd.Execute(ExecutionType.ExecuteDataSet)
            Return Ds

        Catch ex As Exception
            '  Except = "UpdateResponse Method : " & ex.Message
        Finally
            ObjCmd = Nothing
            Ds = Nothing
        End Try
    End Function
    Private Function GetBlockRule(ByVal MID As Integer, ByVal RuleType As Integer) As DataSet

        Dim ObjCmd As New CommandData(-1)
        Dim Ds As New DataSet
        Try
            ObjCmd.AddParameter("@Merchant_Id", MID)
            ObjCmd.AddParameter("@RuleType", RuleType)

            ObjCmd.CmdText = "CXLROBO_GETBLOCKLIST"

            Ds = ObjCmd.Execute(ExecutionType.ExecuteDataSet)
            Return Ds

        Catch ex As Exception
            '  Except = "UpdateResponse Method : " & ex.Message
        Finally
            ObjCmd = Nothing
            Ds = Nothing
        End Try
    End Function

    Private Sub RecordsFetch(ByVal DsRecord As DataSet)

        Try
            DataTableSetting()

            If (DsRecord.Tables(0).Rows.Count > 0) Then
                Dim I As Integer
                For I = 0 To DsRecord.Tables(0).Rows.Count - 1
                    Data = Dt.NewRow()

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("MID")) Then
                        Data(0) = ""
                    Else
                        Data(0) = DsRecord.Tables(0).Rows(I).Item("MID")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CLoginID")) Then
                        Data(1) = ""
                    Else
                        Data(1) = DsRecord.Tables(0).Rows(I).Item("CLoginID")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("OrderBooked")) Then
                        Data(2) = ""
                    Else

                        Data(2) = DsRecord.Tables(0).Rows(I).Item("OrderBooked")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CXLCode")) Then
                        Data(3) = ""
                    Else
                        Data(3) = DsRecord.Tables(0).Rows(I).Item("CXLCode")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CXLMessage")) Then
                        Data(4) = ""
                    Else
                        Data(4) = DsRecord.Tables(0).Rows(I).Item("CXLMessage")
                    End If


                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("TrackID_atcs")) Then
                        Data(5) = ""
                    Else
                        Data(5) = DsRecord.Tables(0).Rows(I).Item("TrackID_atcs")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("Status_atcs")) Then
                        Data(6) = ""
                    Else
                        Data(6) = MakeStatus(DsRecord.Tables(0).Rows(I).Item("Status_atcs"))

                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CardNo")) Then
                        Data(7) = ""
                    Else
                        Data(7) = DsRecord.Tables(0).Rows(I).Item("CardNo")

                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("ProcessType")) Then
                        Data(8) = ""
                    Else
                        Data(8) = DsRecord.Tables(0).Rows(I).Item("ProcessType")
                    End If


                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("Sender")) Then
                        Data(9) = ""
                    Else
                        Data(9) = GetSender(DsRecord.Tables(0).Rows(I).Item("Sender"))
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("invoice_no")) Then
                        Data(10) = "0"
                    Else
                        Data(10) = DsRecord.Tables(0).Rows(I).Item("invoice_no")
                    End If


                    'log = " . Value of Merchant Id " & Data(0) & vbCrLf
                    'log = " . Value of Customer Login Id " & Data(1) & vbCrLf
                    'log = " . Value of Order Booked " & Data(2) & vbCrLf
                    'log = " . Value of CXLCode " & Data(3) & vbCrLf
                    'log = " . Value of CXLMessage " & Data(4) & vbCrLf
                    'log = " . Value of TrackID_atcs " & Data(5) & vbCrLf
                    'log = " . Value of Status_atcs " & Data(6) & vbCrLf
                    '' log = " . Value of Track Id " & Data(7) & vbCrLf
                    'log = " . Value of ProcessType " & Data(8) & vbCrLf
                    'log = " . Value of Sender " & Data(9) & vbCrLf
                    'log = " . Value of invoice_no" & Data(10) & vbCrLf

                    '  WriteDebugInfo(log, filename)

                    Dt.Rows.Add(Data)
                Next
                log = " . Record Has Found in CALLS_ATCS TABLE  " & vbCrLf
                WriteDebugInfo(log, filename)

                NormalizeData.Tables.Add(Dt)

            Else
                'Data = Dt.NewRow()
                'Data(0) = "No Data Found"
                'Data(1) = "No Data Found"
                'Data(2) = "No Data Found"
                'Data(3) = "No Data Found"
                'Data(3) = "No Data Found"
                'Data(4) = "No Data Found"
                'Data(5) = "No Data Found"
                'Data(6) = "No Data Found"
                'Data(7) = "No Data Found"
                'Data(8) = "No Data Found"
                'Data(9) = "No Data Found"
                'Data(10) = "No Data Found"

                'Dt.Rows.Add(Data)
                'NormalizeData.Tables.Add(Dt)
                log = " . No Record Found in CALLS_ATCS TABLE  " & vbCrLf
                WriteDebugInfo(log, filename)
                NormalizeData = Nothing

            End If

        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Function MakeStatus(ByVal Status As String) As String
        Select Case Status

            Case "D"
                Return "Declined"

            Case "S"
                Return "Declined"

            Case "Y"
                Return "Processed"

            Case "I"
                Return "Declined"

            Case "X"
                Return "Not Processed"

        End Select
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

            Case "0"
                Return ""

        End Select
    End Function

    Private Sub DataTableSetting()


        Dt = New DataTable  'Seperate transactions 

        Dt.Columns.Add("MerchantID")
        Dt.Columns.Add("CLoginID")
        Dt.Columns.Add("OrderBooked")
        Dt.Columns.Add("CXLCode")
        Dt.Columns.Add("CXLMessage")
        Dt.Columns.Add("TrackID")
        Dt.Columns.Add("Status")
        Dt.Columns.Add("CardNo")
        Dt.Columns.Add("ProcessType")
        Dt.Columns.Add("Sender")
        Dt.Columns.Add("invoice_no")


    End Sub

    Private Function GetRecordsByTrackId(ByVal Trackid As Long) As DataSet

        Dim ObjCmd As New CommandData(-1)
        Dim Ds As New DataSet
        Try
            ObjCmd.AddParameter("@RID", Trackid)

            ObjCmd.CmdText = "CXLROBO_GETLISTBYRID"

            Ds = ObjCmd.Execute(ExecutionType.ExecuteDataSet)
            Return Ds

        Catch ex As Exception

        Finally
            ObjCmd = Nothing
            Ds = Nothing
        End Try
    End Function
    Private Function DeCrypt(ByVal ValueToDecrypt As String) As String

        Try

            Dim ObjConfig As New InfiniLogic.AccountsCentre.common.ConfigReader
            Dim ObjCrypt As New rsaLibrary1.Crypt
            Dim ValueEncrypted As String

            Dim D, N As String
            D = ObjConfig.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.D)
            N = ObjConfig.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)

            ValueToDecrypt = Replace(ValueToDecrypt, "p", "+")

            ValueToDecrypt = ObjCrypt.Decrypt(ValueToDecrypt, D, N)

            Return ValueToDecrypt

        Catch ex As Exception

        End Try
    End Function
    Private Sub DataTableSettingForRID()


        Dt = New DataTable  'Seperate transactions 

        Dt.Columns.Add("MerchantID")
        Dt.Columns.Add("CLoginID")
        Dt.Columns.Add("CustomerID")
        Dt.Columns.Add("OrderBooked")
        Dt.Columns.Add("CXLCode")
        Dt.Columns.Add("CXLMessage")
        Dt.Columns.Add("TrackID")
        Dt.Columns.Add("Status")
        Dt.Columns.Add("CardNo")
        Dt.Columns.Add("CardName")
        Dt.Columns.Add("CardType")
        Dt.Columns.Add("StartDate")
        Dt.Columns.Add("CardExpire")
        Dt.Columns.Add("CardAddress")
        Dt.Columns.Add("IssueNo")
        Dt.Columns.Add("SecurityCode")
        Dt.Columns.Add("ProcessType")
        Dt.Columns.Add("Sender")



    End Sub
    Private Sub RecordsFetchForRId(ByVal DsRecord As DataSet)

        Try
            DataTableSettingForRID()

            If (DsRecord.Tables(0).Rows.Count > 0) Then
                Dim I As Integer
                For I = 0 To DsRecord.Tables(0).Rows.Count - 1
                    Data = Dt.NewRow()

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("MID")) Then
                        Data(0) = ""
                    Else
                        Data(0) = DsRecord.Tables(0).Rows(I).Item("MID")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CLoginID")) Then
                        Data(1) = ""
                    Else

                        Data(1) = DsRecord.Tables(0).Rows(I).Item("CLoginID")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CustomerID")) Then
                        Data(2) = ""
                    Else
                        Data(2) = DsRecord.Tables(0).Rows(I).Item("CustomerID")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("OrderBooked")) Then
                        Data(3) = ""
                    Else
                        Data(3) = DsRecord.Tables(0).Rows(I).Item("OrderBooked")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CXLCode")) Then
                        Data(4) = ""
                    Else
                        Data(4) = DsRecord.Tables(0).Rows(I).Item("CXLCode")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CXLMessage")) Then
                        Data(5) = ""
                    Else
                        Data(5) = DsRecord.Tables(0).Rows(I).Item("CXLMessage")
                    End If


                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("TrackID_atcs")) Then
                        Data(6) = ""
                    Else
                        Data(6) = DsRecord.Tables(0).Rows(I).Item("TrackID_atcs")
                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("Status_atcs")) Then
                        Data(7) = ""
                    Else
                        Data(7) = MakeStatus(DsRecord.Tables(0).Rows(I).Item("Status_atcs"))
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CardNo")) Then
                        Data(8) = ""
                    Else
                        Data(8) = DeCrypt(DsRecord.Tables(0).Rows(I).Item("CardNo"))

                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CardName")) Then
                        Data(9) = ""
                    Else
                        Data(9) = DsRecord.Tables(0).Rows(I).Item("CardName")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CardType")) Then
                        Data(10) = ""
                    Else
                        Data(10) = DsRecord.Tables(0).Rows(I).Item("CardType")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("StartDate")) Then
                        Data(11) = ""
                    Else
                        Data(11) = DsRecord.Tables(0).Rows(I).Item("StartDate")
                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CardExpire")) Then
                        Data(12) = ""
                    Else
                        Data(12) = DsRecord.Tables(0).Rows(I).Item("CardExpire")
                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("CardAddress")) Then
                        Data(13) = ""
                    Else
                        Data(13) = DsRecord.Tables(0).Rows(I).Item("CardAddress")
                    End If

                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("IssueNo")) Then
                        Data(14) = ""
                    Else
                        Data(14) = DeCrypt(DsRecord.Tables(0).Rows(I).Item("IssueNo"))
                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("SecurityCode")) Then
                        Data(15) = ""
                    Else
                        Data(15) = DeCrypt(DsRecord.Tables(0).Rows(I).Item("SecurityCode"))
                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("ProcessType")) Then
                        Data(16) = ""
                    Else
                        Data(16) = DsRecord.Tables(0).Rows(I).Item("ProcessType")
                    End If
                    If IsDBNull(DsRecord.Tables(0).Rows(I).Item("Sender")) Then
                        Data(17) = ""
                    Else
                        'Data(17) = GetSender(DsRecord.Tables(0).Rows(I).Item("Sender"))
                        Data(17) = DsRecord.Tables(0).Rows(I).Item("Sender")
                    End If

                    Dt.Rows.Add(Data)
                Next
                log = " . Record Has Found in CALLS_ATCS TABLE  " & vbCrLf
                'WriteDebugInfo(log, filename)

                NormalizeData.Tables.Add(Dt)
            Else
                '    Data = Dt.NewRow()
                '    Data(0) = "No Data Found"
                '    Data(1) = "No Data Found"
                '    Data(2) = "No Data Found"
                '    Data(3) = "No Data Found"
                '    Data(4) = "No Data Found"
                '    Data(5) = "No Data Found"
                '    Data(6) = "No Data Found"
                '    Data(7) = "No Data Found"
                '    Data(8) = "No Data Found"
                '    Data(9) = "No Data Found"
                '    Data(10) = "No Data Found"
                '    Data(11) = "No Data Found"
                '    Data(12) = "No Data Found"
                '    Data(13) = "No Data Found"
                '    Data(14) = "No Data Found"
                '    Data(15) = "No Data Found"
                '    Data(16) = "No Data Found"
                '    Data(17) = "No Data Found"

                'Dt.Rows.Add(Data)
                'NormalizeData.Tables.Add(Dt)
                log = " . Record Has Found in CALLS_ATCS TABLE  " & vbCrLf
                'WriteDebugInfo(log, filename)

                'NormalizeData = Nothing
                'NormalizeData.Tables.Add(Dt)
            End If


        Catch ex As Exception
            '  Except = "UpdateResponse Method : " & ex.Message
        Finally

        End Try
    End Sub
    Private Sub Fetch(ByVal DsRecord As DataSet)

        Try
            DataTableSettingForGettingRecords()
            Dim TempRule As String


            If (DsRecord.Tables(0).Rows.Count > 0) Then
                Dim I As Integer
                For I = 0 To DsRecord.Tables(0).Rows.Count - 1
                    Data = Dt.NewRow()
                    Data(0) = DsRecord.Tables(0).Rows(I).Item("MERCHANTID")
                    Data(1) = DsRecord.Tables(0).Rows(I).Item("RuleType")

                    If (DsRecord.Tables(0).Rows(I).Item("RuleType") = "0") Then
                        TempRule = DsRecord.Tables(0).Rows(I).Item("Rule")

                        Data(4) = TempRule 'Added by Saad on 21/04/08

                        TempRule = DeCrypt(TempRule)
                       
                        'Added by Saad on 21/04/08
                        Dim x As String = "xxxxxxxxxxxx"
                        Dim tempo As String = TempRule.Substring(0, 12)
                        TempRule = Replace(TempRule, tempo, x)
                        '////////////////////
                    Else
                            TempRule = DsRecord.Tables(0).Rows(I).Item("Rule")
                    End If

                    Data(2) = TempRule
                    Data(3) = DsRecord.Tables(0).Rows(I).Item("Blocked")
                    Dt.Rows.Add(Data)
                Next
                NormalizeData.Tables.Add(Dt)

            Else
                'Data = Dt.NewRow()
                'Data(0) = "No Data Found"
                'Data(1) = "No Data Found"
                'Data(2) = "No Data Found"
                'Data(3) = "No Data Found"
                'Dt.Rows.Add(Data)
                'NormalizeData.Tables.Add(Dt)
                NormalizeData = Nothing
            End If

        Catch ex As Exception

        Finally

        End Try
    End Sub
    Private Sub DataTableSettingForGettingRecords()


        Dt = New DataTable  'Seperate transactions 

        Dt.Columns.Add("MerchantID")
        Dt.Columns.Add("RuleType")
        Dt.Columns.Add("Rule")
        Dt.Columns.Add("Blocked")

        'Added by Saad on 21/04/08
        Dt.Columns.Add("RuleEncrypt")

    End Sub
End Class


