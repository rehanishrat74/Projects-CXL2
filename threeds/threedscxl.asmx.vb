Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
<System.Web.Services.WebService(Namespace:="http://tempuri.org/threeds/Service1")> Public Class threedscxl
    Inherits System.Web.Services.WebService
    Private conn As SqlConnection
    Private d As Double
    Private e As Double
    Private n As Double
    Private ObjRSA As rsaLibrary1.Crypt
#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()
        Me.d = 57780047
        Me.n = 58114487
        Me.e = 25399103
        Me.ObjRSA = New rsaLibrary1.Crypt
        'Add your own initialization code after the InitializeComponent() call
        Dim str2 As String = "data" 'ConfigurationSettings.AppSettings.Get("ServerName")
        'note: remove "data" and restore config settings when going live.
        If Me.Server.MachineName = "VINPC2" Then
            Me.conn = New SqlConnection(String.Concat(New String() {"server=", str2, ";User ID=sa; pwd=tinGBGaMitMoG=pk; Initial Catalog=KeyCode;Data Source=", str2, ""}))
        Else
            Me.conn = New SqlConnection(String.Concat(New String() {"server=", str2, ";User ID=cxpvt; pwd=57xYb9u2vqRG6; Initial Catalog=KeyCode;Data Source=", str2, ""}))
        End If
        If ConfigurationSettings.AppSettings.Get("Log") = "True" Then
            Me.Context.Trace.Write(Me.conn.ConnectionString)
        End If

        Try
            Me.Context.Trace.Write("opening connection")
            Me.conn.Open()
        Catch ex As Exception
            Me.Context.Trace.Write("errr in new ")
            Context.Trace.Warn("error :" & ex.Message)
        End Try

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

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
    
    Private Function doDecrypt(ByVal encstring As String) As String

        Me.Context.Trace.Warn("i m in dodecrypt")
        Try
            encstring = Strings.Replace(encstring, "P", "+", 1, -1, CompareMethod.Binary)
            Return Me.ObjRSA.Decrypt(encstring, Me.d, Me.n)
        Catch ex1 As Exception
            Me.Context.Trace.Write("error in decrypting=" & ex1.Message)
        End Try
    End Function
    Private Sub GetInstallId4ListMerchants(ByVal MerchantId As String, ByVal AccountName As String, ByVal Acquirer As String, ByVal gcode As String, ByRef CXLResponseCode As String, ByRef CXLMessage As String, ByRef MerchantNo As String, ByRef DSPassword As String, ByRef AcqBin As String)
        Context.Trace.Write("-------------------------------------")
        Context.Trace.Write("In SP")
        Me.Context.Trace.Write("merchantid=" & MerchantId)
        Me.Context.Trace.Write("accountname=" & AccountName)
        Me.Context.Trace.Write("Acquirer=" & Acquirer)
        Me.Context.Trace.Write("gcode=" & gcode)
        Me.Context.Trace.Write("cxlresposecode=" & CXLResponseCode)
        Me.Context.Trace.Write("cxlmessage=" & CXLMessage)
        Me.Context.Trace.Write("merchantno=" & MerchantNo)
        Me.Context.Trace.Write("dspassword=" & DSPassword)
        Me.Context.Trace.Write("bin=" & AcqBin)


        Try

            Dim command As New SqlCommand
            Me.Context.Trace.Warn("i m in GetinstallId. Calling CXL_GetInstallid")
            command.CommandType = CommandType.StoredProcedure
            command.Connection = Me.conn
            command.CommandText = "CXL_GetInstallid4ListMerchants"
            command.Parameters.Add(New SqlParameter("@AccountName", SqlDbType.VarChar, 100))
            command.Parameters.Item("@AccountName").Value = AccountName
            command.Parameters.Add(New SqlParameter("@Acquirer", SqlDbType.VarChar, &HFF))
            command.Parameters.Item("@Acquirer").Value = Acquirer

            command.Parameters.Add(New SqlParameter("@gcode", SqlDbType.VarChar, 3))
            command.Parameters.Item("@gcode").Value = gcode
            command.Parameters.Add(New SqlParameter("@mid", SqlDbType.Int, 4))
            command.Parameters.Item("@mid").Value = MerchantId
            Dim reader As SqlDataReader = command.ExecuteReader
            If reader.Read Then
                Me.Context.Trace.Write("calling acquirer id")
                Dim encstring As String = reader.Item("Acquirerid").ToString
                Me.Context.Trace.Warn("acquirerid=" & encstring)

                Me.Context.Trace.Write("dec acquirer id")
                MerchantNo = doDecrypt(encstring)
                Me.Context.Trace.Write("merchant no=" & MerchantNo)

                encstring = ""
                encstring = reader.Item("DSPassword").ToString
                Context.Trace.Write("dspassword=" & encstring)

                If Len(encstring) > 0 Then
                    Context.Trace.Write("decrypt ds password")
                    DSPassword = doDecrypt(encstring)

                End If

                encstring = ""
                encstring = reader.Item("AcquirerBin").ToString
                Me.Context.Trace.Write(" bin=" & encstring)

                If Len(encstring) > 0 Then
                    Me.Context.Trace.Write("decrypt acqbin")
                    AcqBin = doDecrypt(encstring)
                    Me.Context.Trace.Write("acqbin=" & AcqBin)
                End If
                encstring = ""

                Me.Context.Trace.Write("vid =" & reader.Item("vid").ToString)
                Me.Context.Trace.Write(" currency=" & reader.Item("gcode").ToString)
            End If
            reader.Close()
            reader = Nothing
            command.Dispose()
            Me.Context.Trace.Warn("Get installid ends successfully.")
            CXLResponseCode = "0"
            CXLMessage = "Success"

        Catch ex1 As Exception
            CXLResponseCode = "-1"
            CXLMessage = ex1.Message
            Me.Context.Trace.Write("error in getinstallid4merchants")
        End Try

    End Sub
    Private Function IsEmptyCheck(ByVal GCode As String, ByVal MerchantId As String, ByVal CardType As String, ByRef CXLResponseCode As String, ByRef CXLMessage As String) As Long
        Me.Context.Trace.Warn("i m in isemptycheck.")

        If (String.Compare(GCode, "", False) = 0) Then
            CXLResponseCode = "-2"
            CXLMessage = "NAK; Country code 0 length."
            Return -1
        End If

        If (String.Compare(MerchantId, "", False) = 0) Then
            CXLResponseCode = "-2"
            CXLMessage = "NAK; merchantid 0 length."
            Return -1
        End If
        If (String.Compare(CardType, "", False) = 0) Then
            CXLResponseCode = "-2"
            CXLMessage = "NAK; card type 0 length."
            Return -1
        End If

        Return 0

    End Function
    Private Function IsNullCheck(ByVal GCode As String, ByVal MerchantId As String, ByVal CardType As String, ByRef CXLResponseCode As String, ByRef CXLMessage As String) As Long
        Me.Context.Trace.Warn("I m in isnullcheck.")
        If (GCode Is Nothing) Then
            CXLResponseCode = "-2"
            CXLMessage = "NAK; Country not supplied. [NULL]"
            Return -1
        End If

        If (MerchantId Is Nothing) Then
            CXLResponseCode = "-2"
            CXLMessage = "NAK; Merchant id not supplied. [NULL]"
            Return -1
        End If

        If (CardType Is Nothing) Then
            CXLResponseCode = "-2"
            CXLMessage = "NAK; Credit card type not supplied. [NULL]"
            Return -1
        End If

        Return 0

    End Function
    <WebMethod(MessageName:="GetMerchantNumber")> _
    Public Sub GetMerchantNumber(ByVal GCode As String, ByVal MerchantId As String, ByVal CardType As String, ByRef MerchantNo As String, ByRef DSPassword As String, ByRef AcqBin As String, ByRef CXLResponseCode As String, ByRef CXLMessage As String)
        Dim agentAcquirer As String
        Me.Context.Trace.Write("Inputs")
        Me.Context.Trace.Write("Gcode=" & GCode)
        Me.Context.Trace.Write("merchantid=" & MerchantId)
        Me.Context.Trace.Write("cardtype=" & CardType)
        Me.Context.Trace.Write("merchantno=" & MerchantNo)
        Me.Context.Trace.Write("dspwd=" & DSPassword)
        Me.Context.Trace.Write("acqbin=" & AcqBin)
        Me.Context.Trace.Write("responsecode=" & CXLResponseCode)
        Me.Context.Trace.Write("cxlmsg=" & CXLMessage)

        If IsNullCheck(GCode, MerchantId, CardType, CXLResponseCode, CXLMessage) <> 0 Then
            Me.Context.Trace.Warn("null parameters")
            Exit Sub
        End If
        If IsEmptyCheck(GCode, MerchantId, CardType, CXLResponseCode, CXLMessage) <> 0 Then
            Me.Context.Trace.Warn("empty paramters")
            Exit Sub
        End If

        If (GCode <> "826") And (GCode <> "840") And (GCode <> "978") Then
            Me.Context.Trace.Warn("unsupported currency")
            CXLResponseCode = "-1"
            CXLMessage = ("NAK; Unsupported currency=" & GCode)
            Me.Context.Trace.Warn("invalid currency")
            Exit Sub
        End If

        Try
            CardType = CardType.ToUpper
            If CardType.StartsWith("AMEX") Then
                Me.Context.Trace.Write("SETTING ACQUIRERES-AMERICAN EXPRESS")
                agentAcquirer = "AMERICAN EXPRESS"
            Else
                agentAcquirer = "STREAMLINE"
                Me.Context.Trace.Write("SETTING ACQUIRERES-STREAMLINE")
            End If

            Me.Context.Trace.Write("Agent acq=" & agentAcquirer)
            Me.Context.Trace.Warn("calling GetInstallId")

            GetInstallId4ListMerchants(MerchantId, "CXL", agentAcquirer, GCode, CXLResponseCode, CXLMessage, MerchantNo, DSPassword, AcqBin)

            Me.Context.Trace.Write("Outputs")
            Me.Context.Trace.Write("Gcode=" & GCode)
            Me.Context.Trace.Write("merchantid=" & MerchantId)
            Me.Context.Trace.Write("cardtype=" & CardType)
            Me.Context.Trace.Write("merchantno=" & MerchantNo)
            Me.Context.Trace.Write("dspwd=" & DSPassword)
            Me.Context.Trace.Write("acqbin=" & AcqBin)
            Me.Context.Trace.Write("responsecode=" & CXLResponseCode)
            Me.Context.Trace.Write("cxlmsg=" & CXLMessage)

        Catch exception1 As Exception
            Me.Context.Trace.Warn("in exception" & exception1.Message)

        Finally
            Me.Context.Trace.Warn("in finally")
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        Me.conn.Close()
        Me.conn.Dispose()
        Me.conn = Nothing
        ObjRSA = Nothing
        MyBase.Finalize()
    End Sub
End Class
