Imports System.IO
Imports System.Web.Mail
Imports System.Threading
Imports System.Text
Imports System.Net
Imports System.Text.Encoding
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Security.Cryptography


Namespace CXL

    Public Class CXLROBOT

        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            If UBound(Diagnostics.Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
                MsgBox("Already CXL Robot instance is running")
                End
            End If

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
        Friend WithEvents Exception As System.Windows.Forms.Label
        Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
        Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
        Friend WithEvents LstException As System.Windows.Forms.ListBox
        Friend WithEvents ChkLog As System.Windows.Forms.CheckBox
        Friend WithEvents LblResponse As System.Windows.Forms.Label
        Friend WithEvents LblValidity As System.Windows.Forms.Label
        Friend WithEvents LblPopulate As System.Windows.Forms.Label
        Friend WithEvents Pic3 As System.Windows.Forms.PictureBox
        Friend WithEvents Pic2 As System.Windows.Forms.PictureBox
        Friend WithEvents Pic1 As System.Windows.Forms.PictureBox
        Friend WithEvents BtnExit As System.Windows.Forms.Button
        Friend WithEvents TimerPopulate As System.Windows.Forms.Timer
        Friend WithEvents TimerGetResponse As System.Windows.Forms.Timer
        Friend WithEvents TimerChkValidity As System.Windows.Forms.Timer
        Friend WithEvents DGData As System.Windows.Forms.DataGrid
        Friend WithEvents pic4 As System.Windows.Forms.PictureBox
        Friend WithEvents Label1 As System.Windows.Forms.Label

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblStatusResponse As System.Windows.Forms.Label
        Friend WithEvents lblStatusValid As System.Windows.Forms.Label
        Friend WithEvents txtValid As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtInvalid As System.Windows.Forms.TextBox
        Friend WithEvents txtBank As System.Windows.Forms.TextBox
        Friend WithEvents txtCredit As System.Windows.Forms.TextBox
        Friend WithEvents txtCxlCode As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnMinimize As System.Windows.Forms.Button
        Friend WithEvents ClearEX As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.Exception = New System.Windows.Forms.Label
            Me.MenuItem1 = New System.Windows.Forms.MenuItem
            Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
            Me.LstException = New System.Windows.Forms.ListBox
            Me.ChkLog = New System.Windows.Forms.CheckBox
            Me.LblResponse = New System.Windows.Forms.Label
            Me.LblValidity = New System.Windows.Forms.Label
            Me.LblPopulate = New System.Windows.Forms.Label
            Me.Pic3 = New System.Windows.Forms.PictureBox
            Me.Pic2 = New System.Windows.Forms.PictureBox
            Me.Pic1 = New System.Windows.Forms.PictureBox
            Me.BtnExit = New System.Windows.Forms.Button
            Me.TimerPopulate = New System.Windows.Forms.Timer(Me.components)
            Me.TimerGetResponse = New System.Windows.Forms.Timer(Me.components)
            Me.TimerChkValidity = New System.Windows.Forms.Timer(Me.components)
            Me.DGData = New System.Windows.Forms.DataGrid
            Me.pic4 = New System.Windows.Forms.PictureBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtInvalid = New System.Windows.Forms.TextBox
            Me.txtValid = New System.Windows.Forms.TextBox
            Me.lblStatusResponse = New System.Windows.Forms.Label
            Me.lblStatusValid = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.txtBank = New System.Windows.Forms.TextBox
            Me.txtCredit = New System.Windows.Forms.TextBox
            Me.txtCxlCode = New System.Windows.Forms.TextBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.btnMinimize = New System.Windows.Forms.Button
            Me.ClearEX = New System.Windows.Forms.Button
            CType(Me.DGData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Exception
            '
            Me.Exception.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Exception.Location = New System.Drawing.Point(56, 424)
            Me.Exception.Name = "Exception"
            Me.Exception.TabIndex = 10
            Me.Exception.Text = "Exceptions:"
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 0
            Me.MenuItem1.Text = "Copy To Clip Board"
            '
            'ContextMenu1
            '
            Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
            '
            'LstException
            '
            Me.LstException.ContextMenu = Me.ContextMenu1
            Me.LstException.ImeMode = System.Windows.Forms.ImeMode.On
            Me.LstException.Location = New System.Drawing.Point(176, 392)
            Me.LstException.Name = "LstException"
            Me.LstException.Size = New System.Drawing.Size(600, 69)
            Me.LstException.TabIndex = 9
            '
            'ChkLog
            '
            Me.ChkLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ChkLog.Location = New System.Drawing.Point(48, 112)
            Me.ChkLog.Name = "ChkLog"
            Me.ChkLog.Size = New System.Drawing.Size(88, 32)
            Me.ChkLog.TabIndex = 8
            Me.ChkLog.Text = "Disable Log"
            '
            'LblResponse
            '
            Me.LblResponse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblResponse.Location = New System.Drawing.Point(16, 80)
            Me.LblResponse.Name = "LblResponse"
            Me.LblResponse.Size = New System.Drawing.Size(80, 24)
            Me.LblResponse.TabIndex = 7
            Me.LblResponse.Text = "Response"
            '
            'LblValidity
            '
            Me.LblValidity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblValidity.Location = New System.Drawing.Point(8, 56)
            Me.LblValidity.Name = "LblValidity"
            Me.LblValidity.Size = New System.Drawing.Size(104, 24)
            Me.LblValidity.TabIndex = 6
            Me.LblValidity.Text = "Checking Validity"
            '
            'LblPopulate
            '
            Me.LblPopulate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblPopulate.Location = New System.Drawing.Point(8, 24)
            Me.LblPopulate.Name = "LblPopulate"
            Me.LblPopulate.Size = New System.Drawing.Size(88, 24)
            Me.LblPopulate.TabIndex = 5
            Me.LblPopulate.Text = "Populate Data"
            '
            'Pic3
            '
            Me.Pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Pic3.Location = New System.Drawing.Point(120, 80)
            Me.Pic3.Name = "Pic3"
            Me.Pic3.Size = New System.Drawing.Size(40, 24)
            Me.Pic3.TabIndex = 4
            Me.Pic3.TabStop = False
            '
            'Pic2
            '
            Me.Pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Pic2.Location = New System.Drawing.Point(120, 48)
            Me.Pic2.Name = "Pic2"
            Me.Pic2.Size = New System.Drawing.Size(40, 24)
            Me.Pic2.TabIndex = 3
            Me.Pic2.TabStop = False
            '
            'Pic1
            '
            Me.Pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Pic1.Location = New System.Drawing.Point(120, 16)
            Me.Pic1.Name = "Pic1"
            Me.Pic1.Size = New System.Drawing.Size(40, 24)
            Me.Pic1.TabIndex = 2
            Me.Pic1.TabStop = False
            '
            'BtnExit
            '
            Me.BtnExit.Location = New System.Drawing.Point(8, 152)
            Me.BtnExit.Name = "BtnExit"
            Me.BtnExit.Size = New System.Drawing.Size(56, 23)
            Me.BtnExit.TabIndex = 1
            Me.BtnExit.Text = "Exit"
            '
            'TimerPopulate
            '
            Me.TimerPopulate.Interval = 20000
            '
            'TimerGetResponse
            '
            Me.TimerGetResponse.Interval = 5000
            '
            'TimerChkValidity
            '
            Me.TimerChkValidity.Interval = 1000
            '
            'DGData
            '
            Me.DGData.DataMember = ""
            Me.DGData.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DGData.Location = New System.Drawing.Point(176, 16)
            Me.DGData.Name = "DGData"
            Me.DGData.Size = New System.Drawing.Size(600, 344)
            Me.DGData.TabIndex = 0
            '
            'pic4
            '
            Me.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pic4.Location = New System.Drawing.Point(120, 184)
            Me.pic4.Name = "pic4"
            Me.pic4.Size = New System.Drawing.Size(40, 24)
            Me.pic4.TabIndex = 11
            Me.pic4.TabStop = False
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(24, 184)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 24)
            Me.Label1.TabIndex = 12
            Me.Label1.Text = "Retry State"
            '
            'txtInvalid
            '
            Me.txtInvalid.Location = New System.Drawing.Point(120, 296)
            Me.txtInvalid.Name = "txtInvalid"
            Me.txtInvalid.ReadOnly = True
            Me.txtInvalid.Size = New System.Drawing.Size(48, 20)
            Me.txtInvalid.TabIndex = 20
            Me.txtInvalid.Text = ""
            '
            'txtValid
            '
            Me.txtValid.Location = New System.Drawing.Point(120, 232)
            Me.txtValid.Name = "txtValid"
            Me.txtValid.ReadOnly = True
            Me.txtValid.Size = New System.Drawing.Size(48, 20)
            Me.txtValid.TabIndex = 19
            Me.txtValid.Text = ""
            '
            'lblStatusResponse
            '
            Me.lblStatusResponse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatusResponse.Location = New System.Drawing.Point(32, 264)
            Me.lblStatusResponse.Name = "lblStatusResponse"
            Me.lblStatusResponse.Size = New System.Drawing.Size(112, 23)
            Me.lblStatusResponse.TabIndex = 17
            Me.lblStatusResponse.Text = "Status @ Response"
            '
            'lblStatusValid
            '
            Me.lblStatusValid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatusValid.Location = New System.Drawing.Point(8, 232)
            Me.lblStatusValid.Name = "lblStatusValid"
            Me.lblStatusValid.Size = New System.Drawing.Size(96, 23)
            Me.lblStatusValid.TabIndex = 18
            Me.lblStatusValid.Text = "Status @ Validity"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(8, 296)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(112, 23)
            Me.Label2.TabIndex = 21
            Me.Label2.Text = "Status Invalid Order"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(0, 360)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 23)
            Me.Label3.TabIndex = 22
            Me.Label3.Text = "Status Credit Orders"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(8, 328)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 23)
            Me.Label4.TabIndex = 23
            Me.Label4.Text = "Status Bank Orders"
            '
            'txtBank
            '
            Me.txtBank.Location = New System.Drawing.Point(120, 328)
            Me.txtBank.Name = "txtBank"
            Me.txtBank.ReadOnly = True
            Me.txtBank.Size = New System.Drawing.Size(48, 20)
            Me.txtBank.TabIndex = 24
            Me.txtBank.Text = ""
            '
            'txtCredit
            '
            Me.txtCredit.Location = New System.Drawing.Point(120, 360)
            Me.txtCredit.Name = "txtCredit"
            Me.txtCredit.ReadOnly = True
            Me.txtCredit.Size = New System.Drawing.Size(48, 20)
            Me.txtCredit.TabIndex = 25
            Me.txtCredit.Text = ""
            '
            'txtCxlCode
            '
            Me.txtCxlCode.Location = New System.Drawing.Point(120, 392)
            Me.txtCxlCode.Name = "txtCxlCode"
            Me.txtCxlCode.ReadOnly = True
            Me.txtCxlCode.Size = New System.Drawing.Size(48, 20)
            Me.txtCxlCode.TabIndex = 38
            Me.txtCxlCode.Text = ""
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.Location = New System.Drawing.Point(16, 392)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(64, 23)
            Me.Label9.TabIndex = 37
            Me.Label9.Text = "CXLCode"
            '
            'btnMinimize
            '
            Me.btnMinimize.Location = New System.Drawing.Point(96, 152)
            Me.btnMinimize.Name = "btnMinimize"
            Me.btnMinimize.Size = New System.Drawing.Size(64, 23)
            Me.btnMinimize.TabIndex = 39
            Me.btnMinimize.Text = "Minimize"
            '
            'ClearEX
            '
            Me.ClearEX.Location = New System.Drawing.Point(56, 448)
            Me.ClearEX.Name = "ClearEX"
            Me.ClearEX.TabIndex = 41
            Me.ClearEX.Text = "Clear Ex:"
            '
            'CXLROBOT
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(784, 477)
            Me.ControlBox = False
            Me.Controls.Add(Me.ClearEX)
            Me.Controls.Add(Me.btnMinimize)
            Me.Controls.Add(Me.txtCxlCode)
            Me.Controls.Add(Me.txtCredit)
            Me.Controls.Add(Me.txtBank)
            Me.Controls.Add(Me.txtInvalid)
            Me.Controls.Add(Me.txtValid)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.lblStatusResponse)
            Me.Controls.Add(Me.lblStatusValid)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.pic4)
            Me.Controls.Add(Me.Exception)
            Me.Controls.Add(Me.LstException)
            Me.Controls.Add(Me.ChkLog)
            Me.Controls.Add(Me.LblResponse)
            Me.Controls.Add(Me.LblValidity)
            Me.Controls.Add(Me.LblPopulate)
            Me.Controls.Add(Me.Pic3)
            Me.Controls.Add(Me.Pic2)
            Me.Controls.Add(Me.Pic1)
            Me.Controls.Add(Me.BtnExit)
            Me.Controls.Add(Me.DGData)
            Me.ImeMode = System.Windows.Forms.ImeMode.On
            Me.Name = "CXLROBOT"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "CXL ROBOT 30.03.10"
            CType(Me.DGData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "..................... Public Variable............................."


        ' This is Local Class Object
        Public obj As New CXL.CXLTRANSACTION

        ' This is Serviceactivation for InfiniReSellers' orders

        Public ObjIo As Io.InfiniShops.ServiceActivation

        'This is ServiceActivation for AccountsCentres' Orders
        Public ObjService As ServiceActivation.ServiceActivation

        'These are Local Class Objects
        Dim ObjXml As InfiniLogic.AccountsCentre.common.ConfigReader
        Dim ObjCrypt As rsaLibrary1.Crypt

        'This is ServiceActivation for InfiniBuyers' Orders
        Public ObjBuyer As BPtsPayment.InfiniBPPay

        'This is ServiceActivation for InfiniMerkets' Orders
        Public ObjInifiniMarketPlace As InfiniMarket._Default

        'This is For Paypal
        Public objPayPal As InfiniPayPal.InfiniPayPalWebService

        'This is for IR Orders
        Public ResellerService As com.reseller.webservices.IShopOrderHander

        'This is to Append All Exception in a string
        Public DataString As String = "Exceptions:" & vbNewLine

        'This is for saving last tempProcessID created
        Public Shared ProcID As Integer = 0

        'This is for counting the no. of calls for distinct orders (SZ)
        Dim retryCount As Integer

#End Region


#Region "........GLobal Variables......."


        Dim FwdToCXL As Integer = 1
        Dim WaitForServer As Integer = 1
        Dim Ds As DataSet
        Dim OrderData As New DataSet
        Dim InvoiceDataForPRO As New DataSet
        Dim Dt As DataTable

        Dim DtByBank As DataTable
        Dim DtByCreditCard As DataTable
        Dim DtBPoint As DataTable 'Added By Saad 09/01/08
        Dim DtByCR As DataTable 'Added By Saad 12/03/09
        Dim DtError As DataTable

        Dim DataByBank As DataRow
        Dim DataByCreditCard As DataRow
        Dim DataByBP As DataRow 'Added By Saad 09/01/08
        Dim DataByCR As DataRow 'Added By Saad 12/03/09
        Dim DataError As DataRow
        Dim NormalizeData As DataSet

        Dim filename, log, folder, timestring, FileNameAll As String

        Dim WaitToComplete As Boolean = False
        Dim StatusResponse As Long

#End Region

#Region ".......Private Variables......."

        Dim CreditCardNo As String
        Dim EncryptCreditCardNo As String
        Dim IssueNumber As String
        Dim TransactionAmount As String
        Dim GCode As String
        Dim MerchantId As String
        Dim CLoginID As String
        Dim Cust_ID As Integer
        Dim OrderID As String
        Dim TransactionType As String
        Dim StartDate As String
        Dim CardExpiry As String
        Dim CardType As String
        Dim MerchantLoginId As String
        Dim Sender As String
        Dim Mode As String
        Dim AgentName As String
        Dim AgentAcquirer As String
        Dim CustomerID As String
        Dim customer_Email As String
        Dim CxlIdentity As String

        Dim ECI As String
        Dim AcsURL As String
        Dim VTS As String
        Dim CAVV As String
        Dim XID As String
        Dim VAV As String
        Dim MPI_SessionID As String
        Dim hn As String = "0"
        Dim zp As String = "0"
        Dim callCentre As String = "0"
        Dim PaymentProcessor As String = "CXL"

        Dim rid As Long
        Dim status As String

        Dim CardName As String
        Dim CardAddress As String

        Dim CsMessage As String
        Dim ProcessType As String

        ''''' For order information
        Dim SecurityCode As String
        Dim End_Date As String
        Dim ccStatus As String
        Dim TranStatus As String
        Dim PaidAmount As Double
        Dim Amount As Double
        Dim ResponseCode_Cs As String
        Dim Invoice_no As String

        Dim CurrencyCode As String
        Dim CreateInvoice As String

        Dim NOCXL As String
        Dim Authorized As String

        Dim Byforce As String

        Dim Check As Boolean = True
        Dim Symbol As String
        Dim Dbname As String

        '''' For Impossing rules
        Dim Blocked As Boolean = True
        Dim BlockCountry As String
        Dim BlockCard As String
        Dim CountryCode As String
        Dim IPAddress As String

        ''''''''''''''''''''''''''''''
        Dim CallCentreDecline As Boolean

        ''' For Paypal
        Dim PayPalID As String
        Dim PayPalPassword As String
        Dim PayPalCertificate As String
        Dim MTS As String

#End Region

#Region " ........... Data Table Definitions .........."

        Private Sub DataTableSetting()

            DtError = New DataTable  'Seperate invalid transactions 
            DtByBank = New DataTable  ' separate by bank transactions
            DtByCreditCard = New DataTable  'separate by credit card transactions
            DtBPoint = New DataTable 'separate by buyerpoint transaction
            DtByCR = New DataTable 'Pay on Credit

            DtByBank.Columns.Add("MerchantID")
            DtByBank.Columns.Add("CLoginID")
            DtByBank.Columns.Add("TrackID")
            DtByBank.Columns.Add("TransactionType")
            DtByBank.Columns.Add("OrderID")
            DtByBank.Columns.Add("ccStatus")
            DtByBank.Columns.Add("ProcessType")
            DtByBank.Columns.Add("Sender")
            DtByBank.Columns.Add("Customer_id")
            DtByBank.Columns.Add("invoice_no")
            DtByBank.Columns.Add("MerchantLoginID")
            DtByBank.Columns.Add("CreateInvoice")
            DtByBank.Columns.Add("PaidAmount")
            DtByBank.Columns.Add("Amount")
            DtByBank.Columns.Add("TranStatus")
            DtByBank.Columns.Add("GCode")

            DtBPoint.Columns.Add("MerchantID")
            DtBPoint.Columns.Add("CLoginID")
            DtBPoint.Columns.Add("TrackID")
            DtBPoint.Columns.Add("TransactionType")
            DtBPoint.Columns.Add("OrderID")
            DtBPoint.Columns.Add("ccStatus")
            DtBPoint.Columns.Add("ProcessType")
            DtBPoint.Columns.Add("Sender")
            DtBPoint.Columns.Add("Customer_id")
            DtBPoint.Columns.Add("invoice_no")
            DtBPoint.Columns.Add("MerchantLoginID")
            DtBPoint.Columns.Add("CreateInvoice")
            DtBPoint.Columns.Add("PaidAmount")
            DtBPoint.Columns.Add("Amount")
            DtBPoint.Columns.Add("TranStatus")

            DtByCreditCard.Columns.Add("CreditCardNo")
            DtByCreditCard.Columns.Add("IssueNo")
            DtByCreditCard.Columns.Add("TransactionAmount")
            DtByCreditCard.Columns.Add("GCode")
            DtByCreditCard.Columns.Add("MerchantID")
            DtByCreditCard.Columns.Add("CLoginID")
            DtByCreditCard.Columns.Add("OrderID")
            DtByCreditCard.Columns.Add("TransactionType")
            DtByCreditCard.Columns.Add("StartDate")
            DtByCreditCard.Columns.Add("CardExpiry")
            DtByCreditCard.Columns.Add("CardType")
            DtByCreditCard.Columns.Add("Mode")
            DtByCreditCard.Columns.Add("AgentName")
            DtByCreditCard.Columns.Add("AgentAcquirer")
            DtByCreditCard.Columns.Add("TrackID")
            DtByCreditCard.Columns.Add("MerchantLoginID")
            DtByCreditCard.Columns.Add("Sender")

            DtByCreditCard.Columns.Add("ProcessType")
            DtByCreditCard.Columns.Add("TranStatus")
            DtByCreditCard.Columns.Add("CardAddress")
            DtByCreditCard.Columns.Add("CardName")
            DtByCreditCard.Columns.Add("SecurityCode")
            DtByCreditCard.Columns.Add("EndDate")
            DtByCreditCard.Columns.Add("ccStatus")
            DtByCreditCard.Columns.Add("PaidAmount")
            DtByCreditCard.Columns.Add("Amount")
            DtByCreditCard.Columns.Add("ByForce")
            DtByCreditCard.Columns.Add("Customer_id")
            DtByCreditCard.Columns.Add("invoice_no")
            DtByCreditCard.Columns.Add("CreateInvoice")
            DtByCreditCard.Columns.Add("Nocxl")
            DtByCreditCard.Columns.Add("CurrencyCode")

            DtByCreditCard.Columns.Add("PayPalID")
            DtByCreditCard.Columns.Add("PayPalPassword")
            DtByCreditCard.Columns.Add("PayPalCertificate")


            DtByCR.Columns.Add("CreditCardNo")
            DtByCR.Columns.Add("IssueNo")
            DtByCR.Columns.Add("TransactionAmount")
            DtByCR.Columns.Add("GCode")
            DtByCR.Columns.Add("MerchantID")
            DtByCR.Columns.Add("CLoginID")
            DtByCR.Columns.Add("OrderID")
            DtByCR.Columns.Add("TransactionType")
            DtByCR.Columns.Add("StartDate")
            DtByCR.Columns.Add("CardExpiry")
            DtByCR.Columns.Add("CardType")
            DtByCR.Columns.Add("Mode")
            DtByCR.Columns.Add("AgentName")
            DtByCR.Columns.Add("AgentAcquirer")
            DtByCR.Columns.Add("TrackID")
            DtByCR.Columns.Add("MerchantLoginID")
            DtByCR.Columns.Add("Sender")
            DtByCR.Columns.Add("ProcessType")
            DtByCR.Columns.Add("TranStatus")
            DtByCR.Columns.Add("CardAddress")
            DtByCR.Columns.Add("CardName")
            DtByCR.Columns.Add("SecurityCode")
            DtByCR.Columns.Add("EndDate")
            DtByCR.Columns.Add("ccStatus")
            DtByCR.Columns.Add("PaidAmount")
            DtByCR.Columns.Add("Amount")
            DtByCR.Columns.Add("ByForce")
            DtByCR.Columns.Add("Customer_id")
            DtByCR.Columns.Add("invoice_no")
            DtByCR.Columns.Add("CreateInvoice")
            DtByCR.Columns.Add("Nocxl")
            DtByCR.Columns.Add("CurrencyCode")
            DtByCR.Columns.Add("PayPalID")
            DtByCR.Columns.Add("PayPalPassword")
            DtByCR.Columns.Add("PayPalCertificate")


            DtError.Columns.Add("MerchantID")
            DtError.Columns.Add("CLoginID")
            DtError.Columns.Add("TrackID")
            DtError.Columns.Add("OrderID")
            DtError.Columns.Add("TransactionType")
            DtError.Columns.Add("Sender")
            DtError.Columns.Add("ResponseCode_Cs")
            DtError.Columns.Add("CsMessage")
            DtError.Columns.Add("ProcessType")
            DtError.Columns.Add("Customer_id")
            DtError.Columns.Add("invoice_no")
            DtError.Columns.Add("MerchantLoginID")
            DtError.Columns.Add("Amount")

        End Sub

#End Region

        Dim IDENTITY As ArrayList

        Private Sub CXLROBOT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.BelowNormal
            System.Net.ServicePointManager.CertificatePolicy = New CertificateValidation


            Dim DataCentres As String = System.Configuration.ConfigurationSettings.AppSettings("DATACENTRES")
            Dim DataCentresArray As String() = DataCentres.Split(",")

            IDENTITY = New ArrayList

            For i As Integer = 0 To DataCentresArray.Length - 1
                IDENTITY.Add(DataCentresArray(i))
            Next

            'IDENTITY.Add("DATACENTRE")
            'IDENTITY.Add("DATACENTRE3")

            LstException.Items.Add("Double CLick Text To View EX in NotePad:")

            Try
                TimerPopulate.Enabled = True

            Catch ex As Exception
                DataString = DataString & ex.Message & "On Form Loading" & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & "On Form Loading")
                SendEmail(ex.Message & " : On Form Loading")
            End Try
        End Sub

#Region " .... MYSQL fetching Data and inserting into Sql SERVER and updating MYSQL Status after getting Cxl Code...."

        Private Sub MySqlData()
            '' GET DATA FROM MYSQL ON THE BASIS OF STATUS='N' & STATUSFROMCS='N' THEN INSERT IN CALLS_ATCS TABLE OF CXL TRANSACTION DB & UPDATE THE STATUSFROM BIT OF MYSQL CALLS_ATCS TABLE TO 'I'
            '' SO THAT NEXT TIME WE CAN'T PROCESS IT

            Dim i As Integer

            Dim loginid As String
            Dim orderbooked As String
            Dim Amount As String
            Dim trackid_atcs As String
            Dim requesttime As String
            Dim Timestamp1 As String
            Dim status As String
            Dim cardno As String
            Dim cardtype As String
            Dim cardname As String
            Dim cardaddress As String
            Dim cardexpire As String
            Dim cardstart As String
            Dim securitycode As String
            Dim issueno As String
            Dim processtype As String
            Dim genericcode As String
            Dim currencycode As String
            Dim CreateInvoice As String
            Dim authorize As String
            Dim nocxl As String

            Try

                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()


                Dim mysqlds As New DataSet
                Dim str As String

                mysqlds = obj.GetMySqlData("select loginid,orderbooked,amount,date_format(request_time,'%d/%m/%Y') as request_time,timestamp1,status,cardno,cardtype,cardname,date_format(cardexpire,'%d/%m/%Y') as cardexpire, date_format(cardstart,'%d/%m/%Y') as cardstart,cardaddress,securitycode,issueno,processtype,genericcode,currencycode,trackid_atcs,createinvoice,nocxl,authorized from calls_atcs where ((status = 'n' or status = 'r' or status is null ) and (statusfromcs = 'n' or statusfromcs is null))", str)

                If (mysqlds.Tables(0).Rows.Count > 0) Then

                    For i = 0 To mysqlds.Tables(0).Rows.Count - 1

                        loginid = mysqlds.Tables(0).Rows(i).Item("loginid")
                        orderbooked = mysqlds.Tables(0).Rows(i).Item("orderbooked")
                        Amount = mysqlds.Tables(0).Rows(i).Item("Amount")

                        Timestamp1 = mysqlds.Tables(0).Rows(i).Item("Timestamp1")
                        status = mysqlds.Tables(0).Rows(i).Item("status")
                        cardno = mysqlds.Tables(0).Rows(i).Item("cardno")
                        cardtype = mysqlds.Tables(0).Rows(i).Item("cardtype")
                        cardname = mysqlds.Tables(0).Rows(i).Item("cardname")
                        cardaddress = mysqlds.Tables(0).Rows(i).Item("cardaddress")
                        CreateInvoice = mysqlds.Tables(0).Rows(i).Item("createinvoice")
                        nocxl = mysqlds.Tables(0).Rows(i).Item("nocxl")
                        authorize = mysqlds.Tables(0).Rows(i).Item("authorized")

                        ' THIS METHOD IS USED TO CONTROL VALID DATE B/C FROM MYSQL BYBANK TRANSACTION HAS CARDEXPIRE 
                        ' FILED "00/00/0000" THATS INVALID 
                        Dim CardExpir As Date
                        Dim CardStar As Date
                        If (mysqlds.Tables(0).Rows(i).Item("cardexpire") = "00/00/0000") Then
                            cardexpire = Now.Date
                        Else
                            cardexpire = (mysqlds.Tables(0).Rows(i).Item("cardexpire"))
                        End If

                        If (mysqlds.Tables(0).Rows(i).Item("cardstart") = "00/00/0000") Then
                            cardstart = Now.Date
                        Else
                            cardstart = (mysqlds.Tables(0).Rows(i).Item("cardstart"))
                        End If

                        If (mysqlds.Tables(0).Rows(i).Item("request_time") = "00/00/0000") Then
                            requesttime = Now.Date
                        Else
                            requesttime = mysqlds.Tables(0).Rows(i).Item("request_time")
                        End If

                        CardExpir = CDate(cardexpire)
                        CardStar = CDate(cardstart)
                        If IsDBNull(mysqlds.Tables(0).Rows(i).Item("securitycode")) Then
                            securitycode = ""
                        Else
                            securitycode = mysqlds.Tables(0).Rows(i).Item("securitycode")
                        End If

                        If IsDBNull(mysqlds.Tables(0).Rows(i).Item("issueno")) Then

                        Else
                            issueno = mysqlds.Tables(0).Rows(i).Item("issueno")

                        End If

                        If mysqlds.Tables(0).Rows(i).Item("processtype") = "" Then
                            processtype = "cc"
                        Else
                            processtype = mysqlds.Tables(0).Rows(i).Item("processtype")
                        End If

                        If mysqlds.Tables(0).Rows(i).Item("trackid_atcs") = 0 Then
                            trackid_atcs = "0"
                        Else
                            trackid_atcs = mysqlds.Tables(0).Rows(i).Item("trackid_atcs")
                        End If
                        genericcode = mysqlds.Tables(0).Rows(i).Item("genericcode")
                        currencycode = mysqlds.Tables(0).Rows(i).Item("currencycode")
                        ' IPAddress = Trim(mysqlds.Tables(0).Rows(i).Item("ip"))

                        'Insert Required data into SQLSERVER DB 
                        Try
                            obj.InsertMySqlDataInSqlServer_New(loginid, orderbooked, Amount, requesttime, Timestamp1, status, cardno, cardtype, cardname, cardaddress, CardExpir, securitycode, issueno, processtype, genericcode, currencycode, CardStar, trackid_atcs, CreateInvoice, nocxl, authorize)

                        Catch ex As Exception
                            DataString = DataString & ex.Message & " insert my sql data in sql server" & obj.GetExcept & vbNewLine
                            LstException.Items.Add(DateTime.Now & " " & ex.Message & " insert my sql data in sql server" & obj.GetExcept)

                            If Not UCase(System.Configuration.ConfigurationSettings.AppSettings("emailFrom")) = "LOCAL" Then
                                SendEmail(ex.Message & " insert my sql data in sql server: " & obj.GetExcept)
                            End If

                        End Try

                        Try
                            obj.UpdateMySqlData("UPDATE calls_atcs SET STATUSFROMCS='I' WHERE ORDERBOOKED=" & orderbooked & " and (Status='r' or status='n') ")
                        Catch ex As Exception
                            DataString = DataString & ex.Message & " Update my sql data " & obj.GetExcept & vbNewLine
                            LstException.Items.Add(DateTime.Now & " " & ex.Message & " Update my sql data " & obj.GetExcept)
                            If Not UCase(System.Configuration.ConfigurationSettings.AppSettings("emailFrom")) = "LOCAL" Then
                                SendEmail(ex.Message & " Update my sql data: " & obj.GetExcept)
                            End If

                        End Try

                    Next
                End If
            Catch ex As Exception
                DataString = DataString & ex.Message & " Fetch My sql data into Sql Server" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Fetch My sql data into Sql Server" & obj.GetExcept)
                If Not UCase(System.Configuration.ConfigurationSettings.AppSettings("emailFrom")) = "LOCAL" Then
                    SendEmail(ex.Message & " Fetch My sql data into Sql Server: " & obj.GetExcept)
                End If

            End Try

        End Sub
        Private Sub UpdateMySqlStatus(ByVal C_id As String, ByVal O_id As String, ByVal Cxl_code As String, ByVal Cxl_msg As String, ByVal Cs_msg As String, ByVal T_id As String, ByVal StatusFromCs As String, ByVal Responsecode_cs As String, Optional ByVal Inv_no As String = "NULL")
            Try
                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()
                Dim currTime As DateTime = DateTime.Now

                Dim a As String
                a = Format(currTime, "yyyy-M-dd hh:mm:ss")

                currTime = Format(currTime, "yyyy-MM-dd hh:mm:ss")

                'obj.UpdateMySqlData("UPDATE calls_atcs SET Cxlcode='" & Cxl_code & "',cxlmessage= '" & Cxl_msg & "',csmessage='" & Cs_msg & "',trackid_atcs= " & T_id & ",statusfromcs='" & StatusFromCs & "' ,Responsecode_cs=" & Responsecode_cs & " ,Processed_time='" & a & "',Invoiceno='" & Inv_no & "' WHERE ORDERBOOKED=" & O_id & " And loginid='" & C_id & "' And (statusfromCs='I' or statusfromcs='P')")
                obj.UpdateMySqlData("UPDATE calls_atcs SET Cxlcode='" & Cxl_code & "',cxlmessage= '" & Cxl_msg & "',csmessage='" & Cs_msg & "',trackid_atcs= " & T_id & ",statusfromcs='" & StatusFromCs & "' ,Responsecode_cs=" & Responsecode_cs & " ,Processed_time='" & a & "',Invoiceno='" & Inv_no & "' WHERE ORDERBOOKED=" & O_id & " And loginid='" & C_id & "' And (statusfromCs='I' or statusfromcs='P' or statusfromcs='3D' or statusfromcs='S')")


            Catch ex As Exception
                DataString = DataString & ex.Message & "Updating Mysql Status Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & "Updating Mysql Status Function" & obj.GetExcept)
                If Not UCase(System.Configuration.ConfigurationSettings.AppSettings("emailFrom")) = "LOCAL" Then
                    SendEmail(ex.Message & "Updating Mysql Status Function: " & obj.GetExcept)
                End If

            End Try
        End Sub

#End Region

        Private Sub BindGrid()
            Try

                'StatusResponse = StatusResponse + 1
                'lblStatusResponse.Text = StatusResponse
                'Application.DoEvents()

                ' Encryption of Cardno, issue number and security code
                EncryptData()
                Ds = New DataSet
                Dim dstemp As New DataSet
                Dim count As Integer
                For count = 0 To IDENTITY.Count - 1

                    dstemp = obj.GETDataFromDB_New(IDENTITY(count))
                    Ds.Merge(dstemp.Tables(0))
                Next
                DGData.DataSource = Ds.Tables(0)

            Catch ex As Exception
                DataString = DataString & ex.Message & "exception on BindGrid" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & "exception on BindGrid" & obj.GetExcept)
                SendEmail(ex.Message & " exception on BindGrid: " & obj.GetExcept)
            End Try
        End Sub


#Region "................. Validity Checking Functionality......................"

        Private Sub CheckValidity() 'Step 1

            DataTableSetting()   ' MAKE 4 DATATABLE 1 FOR ERRORNOUS DATA ,2 FOR BY BANK TRANSACTION ,3 FOR BY CREDIT CARD TRANSACTION, 4 FOR BUYER POINT TRANSACTION

            Dim D As String
            Dim N As String
            Dim i As Integer
            NormalizeData = New DataSet

            'lblStatusResponse.Text = "Step: 1/3"
            'Application.DoEvents()

            Try


                If (Ds.Tables(0).Rows.Count > 0) Then

                    For i = 0 To Ds.Tables(0).Rows.Count - 1

                        StatusResponse = StatusResponse + 1
                        lblStatusResponse.Text = StatusResponse
                        Application.DoEvents()

                        txtValid.Text = CStr(i + 1) & " / " & Ds.Tables(0).Rows.Count
                        OrderID = Ds.Tables(0).Rows(i).Item("orderbooked")
                        MerchantId = Ds.Tables(0).Rows(i).Item("mid")

                        'New Paramerters  added by Saad on 08/04/08 on request of Greesh and Rehan 
                        If UCase(System.Configuration.ConfigurationSettings.AppSettings("ThreeDSecure")) = "ON" Then
                            Try
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("ECI")) Then ECI = Ds.Tables(0).Rows(i).Item("ECI") Else ECI = Nothing
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("AcsURL")) Then AcsURL = Ds.Tables(0).Rows(i).Item("AcsURL") Else AcsURL = Nothing
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("VTS")) Then VTS = Ds.Tables(0).Rows(i).Item("VTS") Else VTS = Nothing
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("CAVV")) Then CAVV = Ds.Tables(0).Rows(i).Item("CAVV") Else CAVV = Nothing
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("XID")) Then XID = Ds.Tables(0).Rows(i).Item("XID") Else XID = Nothing
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("VAV")) Then VAV = Ds.Tables(0).Rows(i).Item("VAV") Else VAV = Nothing
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("MPI_SessionID")) Then MPI_SessionID = CStr(Ds.Tables(0).Rows(i).Item("MPI_SessionID")) Else MPI_SessionID = Nothing

                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("hn")) Then
                                    If Ds.Tables(0).Rows(i).Item("hn") <> "" Then hn = CStr(Ds.Tables(0).Rows(i).Item("hn")) Else hn = "0"
                                End If

                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("zp")) Then
                                    If Ds.Tables(0).Rows(i).Item("zp") <> "" Then zp = CStr(Ds.Tables(0).Rows(i).Item("zp")) Else zp = "0"
                                End If

                                CallCentreDecline = True
                                If Not IsDBNull(Ds.Tables(0).Rows(i).Item("callCentre")) Then
                                    If Ds.Tables(0).Rows(i).Item("callCentre") <> "" Then
                                        callCentre = CStr(Ds.Tables(0).Rows(i).Item("callCentre"))
                                        Dim dt As DataSet = obj.CheckingValidityOfCallcentre_New(Ds.Tables(0).Rows(i).Item("orderbooked"), Ds.Tables(0).Rows(i).Item("mid"), "02")
                                        If dt.Tables(0).Rows.Count > 0 Then
                                            CallCentreDecline = False
                                        End If
                                    End If
                                End If

                            Catch ex As Exception
                                log = ". Exception on 3D Security: " & ex.Message
                                WriteDebugInfo(log, filename)
                            End Try
                        End If
                        'ECI = IIf(IsDBNull(Ds.Tables(0).Rows(i).Item("ECI")), 0, Ds.Tables(0).Rows(i).Item("ECI"))
                        '///////////////////////////////////////////

                        CsMessage = ""
                        ResponseCode_Cs = ""

                        'Temporary Commented
                        If IsDBNull(Ds.Tables(0).Rows(i).Item("PaymentProcessor")) Then
                            PaymentProcessor = "CXL"
                        Else
                            PaymentProcessor = Ds.Tables(0).Rows(i).Item("PaymentProcessor")
                        End If


                        If IsDBNull(Ds.Tables(0).Rows(i).Item("Invoice_no")) Then
                            Invoice_no = "0"
                        Else
                            Invoice_no = Ds.Tables(0).Rows(i).Item("Invoice_no")
                        End If

                        If ChkLog.Checked = False Then
                            If (OrderID = "0" And Invoice_no <> "0") Then
                                filename = "InvoiceNo - " & Invoice_no & "-" & MerchantId
                                filename = folder & "\" & filename
                            ElseIf (OrderID <> "0") Then
                                filename = "OrderID - " & OrderID & "-" & MerchantId
                                filename = folder & "\" & filename
                            End If

                            log = ":: CXL MDB, ver:260809"
                            WriteDebugInfo(log, filename)


                        End If
                        If IsDBNull(Ds.Tables(0).Rows(i).Item("cardno")) Then
                            CreditCardNo = ""
                        Else
                            CreditCardNo = Ds.Tables(0).Rows(i).Item("cardno")
                            If (CreditCardNo <> "" And CreditCardNo <> "0" And (Not IsNumeric(CreditCardNo))) Then
                                If ChkLog.Checked = False Then

                                    If (OrderID = "0" And Invoice_no <> "0") Then
                                        log = ". Decrypting Data CardNo of invoice " & Invoice_no
                                        WriteDebugInfo(log, filename)
                                    ElseIf (OrderID <> "0") Then
                                        log = ". Decrypting Data CardNo of order " & OrderID
                                        WriteDebugInfo(log, filename)
                                    End If

                                End If
                                CreditCardNo = Ds.Tables(0).Rows(i).Item("cardno")
                                EncryptCreditCardNo = Ds.Tables(0).Rows(i).Item("cardno")
                                CreditCardNo = Replace(CreditCardNo, "p", "+")
                                D = InfiniLogic.AccountsCentre.common.ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.D)
                                N = InfiniLogic.AccountsCentre.common.ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)
                                ObjCrypt = New rsaLibrary1.Crypt
                                CreditCardNo = ObjCrypt.Decrypt(CreditCardNo, D, N)
                            End If
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("cardname")) Then
                            CardName = ""
                        Else
                            CardName = Ds.Tables(0).Rows(i).Item("cardname")
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("cardaddress")) Then
                            CardAddress = ""
                        Else
                            CardAddress = Ds.Tables(0).Rows(i).Item("cardaddress")
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("CustomerID")) Then
                            CustomerID = ""
                        Else
                            CustomerID = Ds.Tables(0).Rows(i).Item("CustomerID")
                        End If

                        customer_Email = ""

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("IPaddress")) Then
                            IPAddress = ""
                        Else
                            IPAddress = Ds.Tables(0).Rows(i).Item("IPaddress")
                        End If
                        IssueNumber = Ds.Tables(0).Rows(i).Item("issueno")

                        If (IssueNumber <> "" And IssueNumber <> "0" And (Not IsNumeric(IssueNumber))) Then

                            If ChkLog.Checked = False Then
                                log = ". Decrypting Data IssueNo "
                                WriteDebugInfo(log, filename)
                            End If

                            IssueNumber = Replace(IssueNumber, "p", "+")
                            D = InfiniLogic.AccountsCentre.common.ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.D)
                            N = InfiniLogic.AccountsCentre.common.ConfigReader.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)
                            ObjCrypt = New rsaLibrary1.Crypt
                            IssueNumber = ObjCrypt.Decrypt(IssueNumber, D, N)
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("securitycode")) Then
                            SecurityCode = ""
                        Else
                            SecurityCode = Ds.Tables(0).Rows(i).Item("securitycode")
                        End If

                        If (SecurityCode <> "" And SecurityCode <> "0" And (Not IsNumeric(SecurityCode))) Then
                            If ChkLog.Checked = False Then
                                log = ". Decrypting Data securitycode "
                                WriteDebugInfo(log, filename)
                            End If
                            SecurityCode = Replace(SecurityCode, "p", "+")
                            ObjXml = New InfiniLogic.AccountsCentre.common.ConfigReader
                            D = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.D)
                            N = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)
                            ObjCrypt = New rsaLibrary1.Crypt
                            SecurityCode = ObjCrypt.Decrypt(SecurityCode, D, N)

                        End If

                        status = ""
                        status = Ds.Tables(0).Rows(i).Item("status")

                        MTS = ""
                        MTS = Ds.Tables(0).Rows(i).Item("MTS")

                        TransactionAmount = Ds.Tables(0).Rows(i).Item("Amount")
                        Amount = Ds.Tables(0).Rows(i).Item("Amount")

                        CxlIdentity = Ds.Tables(0).Rows(i).Item("CXLIdentity")

                        ' CONVERT AMOUNT INTO PENNIES
                        Dim AmountInPenny As Long
                        AmountInPenny = GetAmountInPenni(CDbl(TransactionAmount))
                        TransactionAmount = CStr(AmountInPenny)

                        GCode = Ds.Tables(0).Rows(i).Item("genericcode")
                        CurrencyCode = Ds.Tables(0).Rows(i).Item("CurrencyCode")

                        

                        '   CountryCode = Ds.Tables(0).Rows(i).Item("Country_code")

                        ' HERE SENDER MAY B DIFFERENT
                        Sender = Ds.Tables(0).Rows(i).Item("sender")

                        CreateInvoice = Ds.Tables(0).Rows(i).Item("createinvoice")
                        NOCXL = Ds.Tables(0).Rows(i).Item("nocxl")
                        Authorized = Ds.Tables(0).Rows(i).Item("authorized")

                        ' MerchantId = Ds.Tables(0).Rows(i).Item("mid")

                        CLoginID = Ds.Tables(0).Rows(i).Item("cloginid")

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("PayPalID")) Then
                            PayPalID = ""
                        Else
                            PayPalID = Ds.Tables(0).Rows(i).Item("PayPalID")
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("PayPalPassword")) Then
                            PayPalPassword = ""
                        Else
                            PayPalPassword = Ds.Tables(0).Rows(i).Item("PayPalPassword")
                        End If


                        If IsDBNull(Ds.Tables(0).Rows(i).Item("PayPalCertificate")) Then

                            ' PayPalCertificate = "0"
                        Else
                            PayPalCertificate = Ds.Tables(0).Rows(i).Item("PayPalCertificate") 'Encoding.UTF8.GetString(Ds.Tables(0).Rows(i).Item("PayPalCertificate"))


                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("transactiontype")) Then
                            TransactionType = "INVOICE"
                        Else
                            TransactionType = Ds.Tables(0).Rows(i).Item("transactiontype")
                        End If

                        If (TransactionType = "INVOICE") Then

                            TranStatus = "Y"
                        Else
                            TranStatus = "N"
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("startdate")) Then
                            StartDate = ""
                        Else
                            StartDate = Ds.Tables(0).Rows(i).Item("startdate")
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("cardexpire")) Then
                            CardExpiry = ""
                        Else
                            CardExpiry = Ds.Tables(0).Rows(i).Item("cardexpire")
                        End If

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("cardtype")) Then
                            CardType = ""
                        Else
                            CardType = Ds.Tables(0).Rows(i).Item("cardtype")
                        End If
                        MerchantLoginId = Ds.Tables(0).Rows(i).Item("mloginid")

                        If IsDBNull(Ds.Tables(0).Rows(i).Item("trackid_atcs")) Then

                            rid = 0
                        Else
                            rid = Ds.Tables(0).Rows(i).Item("trackid_atcs")
                        End If

                        Dim CSAvailable As Integer = Ds.Tables(0).Rows(i).Item("SERVICEAVAILABLE")

                        If (CSAvailable <> 0) Then

                            ' Dim Amount As Double = Ds.Tables(0).Rows(i).Item("amount")
                            ProcessType = Ds.Tables(0).Rows(i).Item("Processtype")

                            If (Ds.Tables(0).Rows(i).Item("mode") = "Y") Then
                                Mode = "TEST"
                            Else
                                Mode = "LIVE"
                            End If

                            'If (IsDBNull(Ds.Tables(0).Rows(i).Item("accountname"))) Then
                            '    AgentName = ""
                            'Else
                            '    AgentName = Ds.Tables(0).Rows(i).Item("accountname")
                            'End If

                            If (IsDBNull(Ds.Tables(0).Rows(i).Item("AgentName"))) Then
                                AgentName = ""
                            Else
                                'condition added by M. Furqan Khan on 04 FEB 2010 after consulting Saad.
                                If Ds.Tables(0).Rows(i).Item("AgentName").ToString.ToUpper = "PAYPAL" Then
                                    AgentName = "PP"
                                Else
                                    AgentName = Ds.Tables(0).Rows(i).Item("AgentName")
                                End If
                            End If


                            If (IsDBNull(Ds.Tables(0).Rows(i).Item("AgentAcquirer"))) Then
                                AgentAcquirer = "Test Account"
                            Else
                                AgentAcquirer = Ds.Tables(0).Rows(i).Item("AgentAcquirer")
                            End If

                            'If (CardType = "AMEX Card") Then

                            '    If (IsDBNull(Ds.Tables(0).Rows(i).Item("amexacquirer"))) Then
                            '        AgentAcquirer = ""
                            '    Else
                            '        AgentAcquirer = Ds.Tables(0).Rows(i).Item("amexacquirer")
                            '    End If
                            'Else

                            '    If (IsDBNull(Ds.Tables(0).Rows(i).Item("generalacquirer"))) Then
                            '        AgentAcquirer = ""
                            '    Else
                            '        AgentAcquirer = Ds.Tables(0).Rows(i).Item("generalacquirer")
                            '    End If
                            'End If


                            If (IsDBNull(Ds.Tables(0).Rows(i).Item("byforce"))) Then
                                Byforce = "Y"
                            Else
                                Byforce = Ds.Tables(0).Rows(i).Item("byforce")
                            End If

                            Dim Check As Boolean = True


                            If (Sender = "CS") Then

                                Dim Original_Sender As String = GetOriginalSender(MerchantId, rid)

                                Sender = Original_Sender

                                ''' 
                                FurtherProcessing()

                            Else
                                FurtherProcessing()

                            End If

                            '''''''''''''''''''''' Implement on Date: 1st Feb 2007'''''''''''''''
                            '''''''''''''''''''''' Revisited on Date: 28th Feb 2007''''''''''''''' 
                            Dim RuleType, Rule As String

                            Try
                                Dim Ds2 As DataSet = CheckRuleBlockedbyM2(2)
                                If (Ds2.Tables(0).Rows.Count > 0) Then

                                    For Count2 As Integer = 0 To Ds2.Tables(0).Rows.Count - 1
                                        If (CheckBlockRule(Ds2.Tables(0).Rows(Count2).Item("RuleType"), Trim(Ds2.Tables(0).Rows(Count2).Item("Rule"))) = True) Then
                                            Blocked = False

                                            RuleType = Ds2.Tables(0).Rows(Count2).Item("RuleType")
                                            Rule = Ds2.Tables(0).Rows(Count2).Item("Rule")
                                            Exit For
                                        Else
                                            Blocked = True
                                        End If
                                    Next
                                End If

                                If Blocked = True Then
                                    Dim ExistRule As DataSet = CheckRuleBlockedbyM2(MerchantId)
                                    If ExistRule.Tables(0).Rows.Count > 0 Then
                                        For Count As Integer = 0 To ExistRule.Tables(0).Rows.Count - 1
                                            If (CheckBlockRule(ExistRule.Tables(0).Rows(Count).Item("RuleType"), Trim(ExistRule.Tables(0).Rows(Count).Item("Rule"))) = True) Then
                                                Blocked = False
                                                RuleType = ExistRule.Tables(0).Rows(Count).Item("RuleType")
                                                Rule = ExistRule.Tables(0).Rows(Count).Item("Rule")
                                                Exit For
                                            Else
                                                Blocked = True
                                            End If
                                        Next
                                    End If
                                End If

                            Catch ex As Exception
                                log = "Block Rule fails: " & ex.Message
                                WriteDebugInfo(log, filename)
                            End Try


                            If Blocked = False Then
                                log = "Changing 'CC' to 'CB' as order has been qualified for block rule where DBName = " & Dbname & "and MerchantId = " & MerchantId & "and orderID = " & OrderID & "ProcessType = " & ProcessType & "Rule = " & Rule & " RuleType = " & RuleType
                                WriteDebugInfo(log, filename)
                                ProcessType = "cb"
                            End If

                            If (Check = True) Then
                                ' If (Check = True) Then

                                If (UCase(ProcessType) = "CC") Then
                                    ' Save CREDIT CARD DATA
                                    If ChkLog.Checked = False Then
                                        If (OrderID = "0" And Invoice_no <> "0") Then
                                            log = ". Save Data(CREDIT CARD) in Data Table Of Invoice " & Invoice_no
                                            WriteDebugInfo(log, filename)
                                        ElseIf (OrderID <> "0") Then
                                            log = ". Save Data(CREDIT CARD) in Data Table Of Order " & OrderID
                                            WriteDebugInfo(log, filename)
                                        End If
                                    End If

                                    DataByCreditCard = DtByCreditCard.NewRow()

                                    DataByCreditCard(0) = CreditCardNo
                                    DataByCreditCard(1) = IssueNumber
                                    DataByCreditCard(2) = TransactionAmount
                                    DataByCreditCard(3) = GCode
                                    DataByCreditCard(4) = MerchantId
                                    DataByCreditCard(5) = CLoginID
                                    DataByCreditCard(6) = OrderID
                                    DataByCreditCard(7) = TransactionType
                                    DataByCreditCard(8) = StartDate
                                    DataByCreditCard(9) = CardExpiry
                                    DataByCreditCard(10) = CardType
                                    DataByCreditCard(11) = Mode
                                    DataByCreditCard(12) = AgentName
                                    DataByCreditCard(13) = AgentAcquirer
                                    DataByCreditCard(14) = rid
                                    DataByCreditCard(15) = MerchantLoginId
                                    DataByCreditCard(16) = Sender

                                    DataByCreditCard(17) = ProcessType
                                    DataByCreditCard(18) = TranStatus
                                    DataByCreditCard(19) = CardAddress
                                    DataByCreditCard(20) = CardName
                                    DataByCreditCard(21) = SecurityCode
                                    DataByCreditCard(22) = End_Date
                                    DataByCreditCard(23) = ccStatus

                                    DataByCreditCard(24) = PaidAmount
                                    DataByCreditCard(25) = Amount
                                    DataByCreditCard(26) = Byforce
                                    DataByCreditCard(27) = Cust_ID
                                    DataByCreditCard(28) = Invoice_no
                                    DataByCreditCard(29) = CreateInvoice
                                    DataByCreditCard(30) = NOCXL
                                    DataByCreditCard(31) = CurrencyCode
                                    DataByCreditCard(32) = PayPalID
                                    DataByCreditCard(33) = PayPalPassword
                                    DataByCreditCard(34) = PayPalCertificate


                                    DtByCreditCard.Rows.Add(DataByCreditCard)

                                ElseIf (UCase(ProcessType) = "CB") Then
                                    'SAVE BYBANK TRANSACTION DATA
                                    If ChkLog.Checked = False Then
                                        If (OrderID = "0" And Invoice_no <> "0") Then
                                            log = ". Save Data(BANKD) in Data Table of Invoice. " & Invoice_no
                                            WriteDebugInfo(log, filename)
                                        ElseIf (OrderID <> "0") Then
                                            log = ". Save Data(BANKD) in Data Table of Order. " & OrderID
                                            WriteDebugInfo(log, filename)
                                        End If

                                    End If

                                    DataByBank = DtByBank.NewRow()
                                    DataByBank(0) = MerchantId
                                    DataByBank(1) = CLoginID
                                    DataByBank(2) = rid
                                    DataByBank(3) = TransactionType
                                    DataByBank(4) = OrderID
                                    DataByBank(5) = ccStatus
                                    DataByBank(6) = ProcessType
                                    DataByBank(7) = Sender
                                    DataByBank(8) = Cust_ID
                                    DataByBank(9) = Invoice_no
                                    DataByBank(10) = MerchantLoginId
                                    DataByBank(11) = CreateInvoice
                                    DataByBank(12) = PaidAmount
                                    DataByBank(13) = Amount
                                    DataByBank(14) = TranStatus
                                    DataByBank(15) = GCode
                                    DtByBank.Rows.Add(DataByBank)


                                    'Added by Saad 09/01/08 (SZ:BP)
                                ElseIf (UCase(ProcessType) = "BP" Or UCase(ProcessType) = "PA") Then

                                    'SAVE BUYERPOINT TRANSACTION DATA
                                    If ChkLog.Checked = False Then
                                        If (OrderID = "0" And Invoice_no <> "0") Then
                                            log = ". Save Data(BUYERPOINT) in Data Table of Invoice. " & Invoice_no
                                            WriteDebugInfo(log, filename)
                                        ElseIf (OrderID <> "0") Then
                                            log = ". Save Data(BUYERPOINT) in Data Table of Order. " & OrderID
                                            WriteDebugInfo(log, filename)
                                        End If

                                    End If

                                    DataByBP = DtBPoint.NewRow()
                                    DataByBP(0) = MerchantId
                                    DataByBP(1) = CLoginID
                                    DataByBP(2) = rid
                                    DataByBP(3) = TransactionType
                                    DataByBP(4) = OrderID
                                    DataByBP(5) = ccStatus
                                    DataByBP(6) = ProcessType
                                    DataByBP(7) = Sender
                                    DataByBP(8) = Cust_ID
                                    DataByBP(9) = Invoice_no
                                    DataByBP(10) = MerchantLoginId
                                    DataByBP(11) = CreateInvoice
                                    DataByBP(12) = PaidAmount
                                    DataByBP(13) = Amount
                                    DataByBP(14) = TranStatus
                                    DtBPoint.Rows.Add(DataByBP)

                                ElseIf (UCase(ProcessType) = "CR") Then

                                    DataByCR = DtByCR.NewRow()

                                    DataByCR(0) = CreditCardNo
                                    DataByCR(1) = IssueNumber
                                    DataByCR(2) = TransactionAmount
                                    DataByCR(3) = GCode
                                    DataByCR(4) = MerchantId
                                    DataByCR(5) = CLoginID
                                    DataByCR(6) = OrderID
                                    DataByCR(7) = TransactionType
                                    DataByCR(8) = StartDate
                                    DataByCR(9) = CardExpiry
                                    DataByCR(10) = CardType
                                    DataByCR(11) = Mode
                                    DataByCR(12) = AgentName
                                    DataByCR(13) = AgentAcquirer
                                    DataByCR(14) = rid
                                    DataByCR(15) = MerchantLoginId
                                    DataByCR(16) = Sender

                                    DataByCR(17) = ProcessType
                                    DataByCR(18) = TranStatus
                                    DataByCR(19) = CardAddress
                                    DataByCR(20) = CardName
                                    DataByCR(21) = SecurityCode
                                    DataByCR(22) = End_Date
                                    DataByCR(23) = ccStatus

                                    DataByCR(24) = PaidAmount
                                    DataByCR(25) = Amount
                                    DataByCR(26) = Byforce
                                    DataByCR(27) = Cust_ID
                                    DataByCR(28) = Invoice_no
                                    DataByCR(29) = CreateInvoice
                                    DataByCR(30) = NOCXL
                                    DataByCR(31) = CurrencyCode
                                    DataByCR(32) = PayPalID
                                    DataByCR(33) = PayPalPassword
                                    DataByCR(34) = PayPalCertificate


                                    DtByCR.Rows.Add(DataByCR)

                                End If

                            Else
                                'SAVE ERRORNOUS DATA
                                If ChkLog.Checked = False Then
                                    If (OrderID = "0" And Invoice_no <> "0") Then
                                        log = ".  Start Save Data(InValid data) in Data Table Of Invoice. " & Invoice_no
                                        WriteDebugInfo(log, filename)
                                    ElseIf (OrderID <> "0") Then
                                        log = ". Start Save Data(InValid data) in Data Table Of Order. " & OrderID
                                        WriteDebugInfo(log, filename)
                                    End If

                                End If
                                DataError = DtError.NewRow()
                                DataError(0) = MerchantId
                                DataError(1) = CLoginID
                                DataError(2) = rid
                                DataError(3) = OrderID
                                DataError(4) = TransactionType
                                DataError(5) = Sender
                                DataError(6) = ResponseCode_Cs
                                DataError(7) = CsMessage
                                DataError(8) = ProcessType
                                DataError(9) = Cust_ID
                                DataError(10) = Invoice_no
                                DataError(11) = MerchantLoginId
                                DataError(12) = Amount


                                DtError.Rows.Add(DataError)
                            End If
                        Else
                            log = "Service Not Available"
                            WriteDebugInfo(log, filename)
                            SendEmail("Service Not Available for Sender:" & Sender & " and Order ID =" & OrderID)
                            Exit Sub
                        End If

                    Next

                    NormalizeData.Tables.Add(DtError)
                    NormalizeData.Tables.Add(DtByBank)
                    NormalizeData.Tables.Add(DtByCreditCard)
                    NormalizeData.Tables.Add(DtBPoint) 'Added by Saad 09/01/08 (SZ:BP)
                    NormalizeData.Tables.Add(DtByCR) 'Added by Saad 12/03/09 (SZ:BP)

                End If
            Catch ex As Exception
                DataString = DataString & ex.Message & " Checking validity Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Checking validity Function" & obj.GetExcept)
                SendEmail(ex.Message & " Checking validity Function: " & obj.GetExcept)
            End Try
        End Sub

#End Region


Private Sub GetResponse()

StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

            Try
                

                If (NormalizeData.Tables(0).Rows.Count > 0) Then
                    If ChkLog.Checked = False Then
                        log = ". Invalid Data updation start (Order Declined b4 pass to CXL) Now. "
                        log = log & ". Testing" & vbCrLf & vbTab
                        log = log & "............................................................"
                        WriteDebugInfo(log, filename)
                    End If
                    SetStatusForInvalidData()
                End If


                If (NormalizeData.Tables(1).Rows.Count > 0) Then
                    If ChkLog.Checked = False Then
                        log = "............................................................" & vbCrLf
                        log = log & ". Bank Transaction Updation Start Now. "
                        WriteDebugInfo(log, filename)
                    End If
                    SetBankTransactionStatus()
                End If

                If (NormalizeData.Tables(4).Rows.Count > 0) Then
                    If ChkLog.Checked = False Then
                        log = ". Pay on Credit Updation Start Now. "
                        WriteDebugInfo(log, filename)
                    End If
                    PayOnCreditStatusUpdation()
                End If

                'Added by Saad 09/01/08 (SZ)
                If (NormalizeData.Tables(3).Rows.Count > 0) Then
                    If ChkLog.Checked = False Then
                        log = "............................................................" & vbCrLf
                        log = log & ". BuyerPoint Transaction Updation Start Now. "
                        WriteDebugInfo(log, filename)
                    End If
                    SetBuyerPointTransactionStatus()
                End If

                '...........

                If (NormalizeData.Tables(2).Rows.Count > 0) Then
                    'For Cxl PROCESSING AND UPDATING TABLES
                    If ChkLog.Checked = False Then
                        log = "............................................................" & vbCrLf
                        log = log & ". Credit Card Responses and Updation Start Now . "
                        WriteDebugInfo(log, filename)
                    End If
                    CreditCardStatusUpdation()
                End If

                BindGrid()

            Catch ex As Exception
                DataString = DataString & ex.Message & "Response Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & "Response Function" & obj.GetExcept)
                SendEmail(ex.Message & "Response Function" & obj.GetExcept)
            End Try

        End Sub

#Region "....................... Errornous Data Updating Status................."

        Public Sub SetStatusForInvalidData()
            'CXLRESPONSECODE =500 for this case 
            If (NormalizeData.Tables(0).Rows.Count > 0) Then
                ' FOR TRANSACTION HAVING ERRORS OR INVALID 
                Dim L As Integer

                For L = 0 To NormalizeData.Tables(0).Rows.Count - 1
                    Try
                        'obj.GetExcept = ""
                        StatusResponse = StatusResponse + 1
                        lblStatusResponse.Text = StatusResponse
                        Application.DoEvents()

                        txtInvalid.Text = CStr(L + 1) & " / " & NormalizeData.Tables(0).Rows.Count
                        If (NormalizeData.Tables(0).Rows(L).Item("sender") = "FH") Then

                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". Sender. " & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)

                            End If
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "D" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf

                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(0).Rows(L).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "D" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            obj.UpdateInvoiceStatus(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), "D", 500, "NULL", NormalizeData.Tables(0).Rows(L).Item("ProcessType"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))
                            obj.UpdateInvoiceTable(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "NULL", "500", NormalizeData.Tables(0).Rows(L).Item("trackid"), NormalizeData.Tables(0).Rows(L).Item("sender"), "D")

                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) To MYSQL " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @CloginId= " & NormalizeData.Tables(0).Rows(L).Item("CloginId") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @CsMessage= " & NormalizeData.Tables(0).Rows(L).Item("CsMessage") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @StatusFromCs= " & "S" & vbCrLf
                                log = log & ". @ResponseCode_Cs= " & NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs")
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If

                            UpdateMySqlStatus(NormalizeData.Tables(0).Rows(L).Item("CloginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "500", "NULL", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("trackid"), "S", NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"))

                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), 0, NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)

                        ElseIf ((NormalizeData.Tables(0).Rows(L).Item("sender") = "PR" Or NormalizeData.Tables(0).Rows(L).Item("Sender") = "EX") And NormalizeData.Tables(0).Rows(L).Item("OrderID") > 0) Then

                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". Sender. " & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)

                            End If

                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "D" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID")
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateInvoiceStatus(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), "D", 500, "NULL", NormalizeData.Tables(0).Rows(L).Item("ProcessType"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))

                            If ChkLog.Checked = False Then
                                log = ". Update Trackid in PRO_INVOICE TABLE by Sp CXLROBO_UPDATE_TRACKID_IN_PRO_INVOICE " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @CloginId= " & NormalizeData.Tables(0).Rows(L).Item("CloginId") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @invoice_no= " & NormalizeData.Tables(0).Rows(L).Item("invoice_no")
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If

                            obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CloginId"), NormalizeData.Tables(0).Rows(L).Item("trackid"), NormalizeData.Tables(0).Rows(L).Item("invoice_no"))

                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) to sqlserver by SP:CXLROBO_UPDATEDATA."
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), NormalizeData.Tables(0).Rows(L).Item("invoice_no"), NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)

                        ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "AC") Then

                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". Sender. " & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)

                            End If
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "D" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf

                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(0).Rows(L).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "D" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            obj.UpdateInvoiceStatus(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), "D", 500, "NULL", NormalizeData.Tables(0).Rows(L).Item("ProcessType"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))
                            obj.UpdateInvoiceTable(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "NULL", "500", NormalizeData.Tables(0).Rows(L).Item("trackid"), NormalizeData.Tables(0).Rows(L).Item("sender"), "D")

                            If ChkLog.Checked = False Then
                                log = ". Calling EnabledServices Method For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender")
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @Customer_Id= " & NormalizeData.Tables(0).Rows(L).Item("Customer_Id") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @IsOrderProcess= " & "False" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType")
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            ObjService = New ServiceActivation.ServiceActivation
                            Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(0).Rows(L).Item("Customer_Id"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), False, NormalizeData.Tables(0).Rows(L).Item("ProcessType"))

                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If

                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), 0, NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)


                        ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "IR" Or NormalizeData.Tables(0).Rows(L).Item("sender") = "IN") Then


                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". Sender. " & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)

                            End If
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "D" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf

                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(0).Rows(L).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "D" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            obj.UpdateInvoiceStatus(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), "D", 500, "NULL", NormalizeData.Tables(0).Rows(L).Item("ProcessType"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))
                            obj.UpdateInvoiceTable(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "NULL", "500", NormalizeData.Tables(0).Rows(L).Item("trackid"), NormalizeData.Tables(0).Rows(L).Item("sender"), "D")

                            If (NormalizeData.Tables(0).Rows(L).Item("sender") = "IR") Then

                                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))


                                ''Infinishop webservice
                                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                                'info.CustomerID = NormalizeData.Tables(0).Rows(L).Item("Customer_Id")
                                'info.IsOrderSuccess = False
                                'info.MerchantID = NormalizeData.Tables(0).Rows(L).Item("MerchantID")
                                'info.OrderID = NormalizeData.Tables(0).Rows(L).Item("OrderID")

                                'If CType(NormalizeData.Tables(0).Rows(L).Item("ProcessType"), String).ToUpper = "CC" Then
                                '    info.PayMode = Io.InfiniShops.PaymentMode.CC
                                'Else
                                '    info.PayMode = Io.InfiniShops.PaymentMode.CB
                                'End If
                                'If ChkLog.Checked = False Then
                                '    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender")
                                '    WriteDebugInfo(log, filename)
                                'End If

                                'Dim Result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult
                                'ObjIo = New Io.InfiniShops.ServiceActivation
                                'Result = ObjIo.EnabledServices(info)
                                ''------------


                                ''Reseller Webservice
                                'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail 'ServiceActivation.ProductDetail
                                'Dim count As Integer
                                'For count = 0 To DataS.Tables(0).Rows.Count - 1
                                '    Product(count) = New com.reseller.webservices.ProductDetail
                                '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                                '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                                '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                                'Next
                                'If ChkLog.Checked = False Then
                                '    log = ". calling Web service GETBIZINFO method for(invalid data) For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender") & vbCrLf
                                '    log = log & ". Having Parameters: " & vbCrLf
                                '    log = log & ". @MerchantLoginID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantLoginID") & vbCrLf
                                '    log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                '    log = log & ". @Customer_id= " & NormalizeData.Tables(0).Rows(L).Item("Customer_id") & vbCrLf
                                '    'log = log & ". @Product= " & Product & vbCrLf
                                '    log = log & ". @PayStatus=" & "N"
                                '    WriteDebugInfo(log, filename)
                                'End If
                                'ResellerService = New com.reseller.webservices.IShopOrderHander
                                'ResellerService.Timeout = 4 * 60 * 1000

                                'ResellerService.GetBizInfo(NormalizeData.Tables(0).Rows(L).Item("MerchantLoginID"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), NormalizeData.Tables(0).Rows(L).Item("Customer_id"), Product, "N")
                                ''-----------

                                Try
                                    Dim PayModeMPI As String
                                    If CType(NormalizeData.Tables(0).Rows(L).Item("ProcessType"), String).ToUpper = "CC" Then
                                        PayModeMPI = "CC"
                                    Else
                                        PayModeMPI = "CB"
                                    End If

                                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(0).Rows(L).Item("OrderID"), NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("MerchantLoginID"), NormalizeData.Tables(0).Rows(L).Item("Customer_Id"), "N", "N", PayModeMPI)
                                    If ChkLog.Checked = False Then
                                        log = ". Dumping data for MPI Reseller" & vbCrLf
                                        log = log & "Exception:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                    End If
                                Catch ex As Exception
                                    log = ". Dumping data for MPI Reseller" & vbCrLf
                                    log = log & "Exception:" & ex.Message
                                    WriteDebugInfo(log, filename)
                                End Try


                            ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "IN") Then

                                'Commented by Saad on 28/01/08 on request of Yousuf
                                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo

                                info.CustomerID = NormalizeData.Tables(0).Rows(L).Item("Customer_Id")
                                info.IsOrderSuccess = False
                                info.MerchantID = NormalizeData.Tables(0).Rows(L).Item("MerchantID")
                                info.OrderID = NormalizeData.Tables(0).Rows(L).Item("OrderID")

                                If CType(NormalizeData.Tables(0).Rows(L).Item("ProcessType"), String).ToUpper = "CC" Then
                                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                                Else
                                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                                End If

                                If ChkLog.Checked = False Then
                                    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender")
                                    WriteDebugInfo(log, filename)
                                End If

                                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                                'Commented by Saad on 28/01/08 on request of Yousuf
                                'Dim Result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult
                                'ObjIo = New Io.InfiniShops.ServiceActivation
                                'Result = ObjIo.EnabledServices(info)

                            End If
                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), 0, NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)


                        ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "IB") Then
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". Sender. " & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)

                            End If
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "D" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf

                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(0).Rows(L).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "D" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            obj.UpdateInvoiceStatus(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), "D", 500, "NULL", NormalizeData.Tables(0).Rows(L).Item("ProcessType"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))
                            obj.UpdateInvoiceTable(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "NULL", "500", NormalizeData.Tables(0).Rows(L).Item("trackid"), NormalizeData.Tables(0).Rows(L).Item("sender"), "D")


                            If ChkLog.Checked = False Then
                                log = ". Calling Infinibuyer Component method UpdateBuyerPointStatus For invalid Data For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender")
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @trackid= " & NormalizeData.Tables(0).Rows(L).Item("trackid") & vbCrLf
                                log = log & ". @Status= " & "False"
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            ObjBuyer = New BPtsPayment.InfiniBPPay
                            ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(0).Rows(L).Item("trackid"), False)

                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), 0, NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)

                        ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "IM") Then

                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) "
                                log = log & ". Sender. " & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)

                            End If
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status of Invalid Data (Order Declined b4 passing to CXL) " & vbCrLf
                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "D" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(0).Rows(L).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf

                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(0).Rows(L).Item("MerchantID") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & vbCrLf
                                log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                log = log & ". @CXLCode= " & 500 & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(0).Rows(L).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "D" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If
                            obj.UpdateInvoiceStatus(NormalizeData.Tables(0).Rows(L).Item("MerchantID"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), "D", 500, "NULL", NormalizeData.Tables(0).Rows(L).Item("ProcessType"), NormalizeData.Tables(0).Rows(L).Item("OrderID"))
                            obj.UpdateInvoiceTable(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "NULL", "500", NormalizeData.Tables(0).Rows(L).Item("trackid"), NormalizeData.Tables(0).Rows(L).Item("sender"), "D")


                            If ChkLog.Checked = False Then
                                log = log & ". Calling Web service CustomerOrderProcess method for decline case(invalid data) .For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)
                            End If
                            Dim IM_Xml As String
                            IM_Xml = "<CustomerOrderInfo>" & _
                                     "<CustomerID>" & NormalizeData.Tables(0).Rows(L).Item("Customer_id") & "</CustomerID>" & _
                                     "<CustomerUID>" & NormalizeData.Tables(0).Rows(L).Item("CloginId") & "</CustomerUID>" & _
                                     "<MerchantID>" & NormalizeData.Tables(0).Rows(L).Item("MerchantId") & "</MerchantID>" & _
                                     "<MerchantUID>" & NormalizeData.Tables(0).Rows(L).Item("MerchantLoginId") & "</MerchantUID>" & _
                                     "<OrderAmount>" & NormalizeData.Tables(0).Rows(L).Item("Amount") & "</OrderAmount>" & _
                                     "<OrderStatus> Declined </OrderStatus>" & _
                                     "<OrderID>" & NormalizeData.Tables(0).Rows(L).Item("OrderID") & "</OrderID>" & _
                                     "<TrackID>" & NormalizeData.Tables(0).Rows(L).Item("Trackid") & "</TrackID>" & _
                                    "</CustomerOrderInfo>"

                            Dim T As String
                            'ObjInfiniMarketPlace=new InfiniMarket._Default
                            ' T = ObjInifiniMarketPlace.CustomerOrderProcess(IM_Xml)

                            Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                            info.CustomerID = NormalizeData.Tables(0).Rows(L).Item("Customer_Id")
                            info.IsOrderSuccess = False
                            info.MerchantID = NormalizeData.Tables(0).Rows(L).Item("MerchantID")
                            info.OrderID = NormalizeData.Tables(0).Rows(L).Item("OrderID")
                            If CType(NormalizeData.Tables(0).Rows(L).Item("ProcessType"), String).ToUpper = "CC" Then
                                info.PayMode = Io.InfiniShops.PaymentMode.CC
                            Else
                                info.PayMode = Io.InfiniShops.PaymentMode.CB
                            End If

                            If ChkLog.Checked = False Then
                                log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(0).Rows(L).Item("sender")
                                WriteDebugInfo(log, filename)
                            End If

                            Dim objIShop As New com.infinishops.io.IShopServiceActivation
                            Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)


                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid Data (Order Declined b4 passing to CXL) to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), 0, NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)

                        Else
                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid SENDER by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "S", NormalizeData.Tables(0).Rows(L).Item("CsMessage"), NormalizeData.Tables(0).Rows(L).Item("ResponseCode_Cs"), 0, NormalizeData.Tables(0).Rows(L).Item("trackid"), CxlIdentity)



                        End If

                    Catch ex As Exception
                        If ChkLog.Checked = False Then
                            log = ". Exception Occured and updating status_atcs=I For Invalid Transaction. " & ex.Message
                            WriteDebugInfo(log, filename)
                        End If

                        ResponseCode_Cs = "-6"    ' Credit card not posted to cxl bcoz of any failure
                        CsMessage = "Transaction Can't Processed B/C" & ex.Message

                        SendEmail("Sender = " & NormalizeData.Tables(0).Rows(L).Item("sender") & " OrderID= " & NormalizeData.Tables(0).Rows(L).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(0).Rows(L).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(0).Rows(L).Item("TrackID") & " Exception= " & ex.Message)
                        DataString = DataString & ex.Message & "Errornous Function" & obj.GetExcept & vbNewLine
                        LstException.Items.Add(DateTime.Now & " " & ex.Message & "Errornous Function" & obj.GetExcept)

                        If (NormalizeData.Tables(0).Rows(L).Item("sender") = "PR" Or NormalizeData.Tables(0).Rows(L).Item("Sender") = "EX") Then
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, NormalizeData.Tables(0).Rows(L).Item("invoice_no"), NormalizeData.Tables(0).Rows(L).Item("TrackID"), CxlIdentity)
                        ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "FH") Then
                            UpdateMySqlStatus(NormalizeData.Tables(0).Rows(L).Item("CloginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "", "NULL", CsMessage, NormalizeData.Tables(0).Rows(L).Item("TrackID"), "I", ResponseCode_Cs)
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(0).Rows(L).Item("TrackID"), CxlIdentity)

                        ElseIf (NormalizeData.Tables(0).Rows(L).Item("sender") = "AC" Or NormalizeData.Tables(0).Rows(L).Item("Sender") = "IN" Or NormalizeData.Tables(0).Rows(L).Item("Sender") = "IR" Or NormalizeData.Tables(0).Rows(L).Item("Sender") = "IM" Or NormalizeData.Tables(0).Rows(L).Item("Sender") = "IB") Then
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(0).Rows(L).Item("TrackID"), CxlIdentity)
                        Else
                            obj.UpdateResponse_New(NormalizeData.Tables(0).Rows(L).Item("MerchantId"), NormalizeData.Tables(0).Rows(L).Item("CLoginId"), NormalizeData.Tables(0).Rows(L).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(0).Rows(L).Item("TrackID"), CxlIdentity)

                        End If
                    End Try
                Next


            End If
        End Sub
#End Region

#Region "........... Updating Status for Sucessfull Bank Transaction ..........."

        Public Sub SetBankTransactionStatus()

            Dim K As Integer
            'ResponseCode_Cs = ""
            'CsMessage = ""
            If (NormalizeData.Tables(1).Rows.Count > 0) Then
                ' FOR BANK TRANSACTION ''''UPDATING TABLES

                For K = 0 To NormalizeData.Tables(1).Rows.Count - 1
                    Try
                        'obj.GetExcept = ""
                        StatusResponse = StatusResponse + 1
                        lblStatusResponse.Text = StatusResponse
                        Application.DoEvents()

                        ResponseCode_Cs = "0"
                        CsMessage = "Bank Transaction is Tested Successfully Invoice Will Create"

                        txtBank.Text = CStr(K + 1) & " / " & NormalizeData.Tables(1).Rows.Count

                        If (NormalizeData.Tables(1).Rows(K).Item("sender") = "FH") Then

                            If (NormalizeData.Tables(1).Rows(K).Item("createinvoice") = "N" Or NormalizeData.Tables(1).Rows(K).Item("createinvoice") = "n") Then
                                If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then ''' that means full payment
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of Bank " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "N" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "*", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                                Else
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of Bank Data " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "N" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                                End If
                                If ChkLog.Checked = False Then
                                    log = ". Update Status of  Bank Data To MYSQL " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @CloginId= " & NormalizeData.Tables(1).Rows(K).Item("CloginId") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLCode= " & 0 & vbCrLf
                                    log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                    log = log & ". @CsMessage= " & CsMessage & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @StatusFromCs= " & "Y" & vbCrLf
                                    log = log & ". @ResponseCode_Cs= " & ResponseCode_Cs
                                    WriteDebugInfo(log, filename)
                                End If
                                UpdateMySqlStatus(NormalizeData.Tables(1).Rows(K).Item("CloginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "0", "NULL", CsMessage, NormalizeData.Tables(1).Rows(K).Item("TrackID"), "Y", ResponseCode_Cs, )
                                If ChkLog.Checked = False Then
                                    log = ". Update Status of to sqlserver by SP:CXLROBO_UPDATEDATA."
                                    WriteDebugInfo(log, filename)
                                End If
                                obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                            Else
                                ResponseCode_Cs = "2"
                                CsMessage = "Invoice is Created"
                                ''' For this case invoice should be created only For Formation house case when Createinvoice='Y'
                                '..................start  Update Invoice Table ..............." 
                                If ChkLog.Checked = False Then
                                    log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS For Bank (CreateInvoice=Y) For Sender=. " & NormalizeData.Tables(1).Rows(K).Item("Sender") & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @PaidAmount= " & NormalizeData.Tables(1).Rows(K).Item("PaidAmount") & vbCrLf
                                    log = log & ". @ccStatus= " & NormalizeData.Tables(1).Rows(K).Item("ccStatus")
                                    WriteDebugInfo(log, filename)
                                End If
                                obj.UpDatePayAmount(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("PaidAmount"), NormalizeData.Tables(1).Rows(K).Item("ccStatus"))
                                '............... End Start Update Invoice Table pay_amt field etc...................."
                                Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))

                                If ChkLog.Checked = False Then
                                    log = ". Getting Order Detail by SP :INFINISHOPS_ORDER_ADDDETAILS For Bank For FH (CreateInvoice=Y). "
                                    WriteDebugInfo(log, filename)
                                End If
                                ' ...............start. Insert order details in inv_det table............."
                                Dim X As Integer
                                For X = 0 To DataS.Tables(0).Rows.Count - 1
                                    obj.OrderAddDetail(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "@ORD" + NormalizeData.Tables(1).Rows(K).Item("OrderID"), DataS.Tables(0).Rows(X).Item("Product_ID"), DataS.Tables(0).Rows(X).Item("prod_code"), DataS.Tables(0).Rows(X).Item("Qty"), DataS.Tables(0).Rows(X).Item("product_sale_price"), DataS.Tables(0).Rows(X).Item("product_tax_code"), DataS.Tables(0).Rows(X).Item("tax_code_rate"), DataS.Tables(0).Rows(X).Item("unitprice"), "S")
                                    If ChkLog.Checked = False Then
                                        log = ". Adding Order Detail . "
                                        WriteDebugInfo(log, filename)
                                    End If
                                Next
                                ' ............... end Insert order details in inv_det table..........."
                                Dim Copy2ProWeb As Boolean = False

                                Dim inv_no As Integer
                                If (obj.CheckServiceEnable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), "118") = True Or obj.CheckServiceEnable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), "232") = True) Then

                                    ''''............... Sttart Insert in pro_invoice  to get invoice #..............."
                                    Dim defaultBack_nc As String = obj.GetLedgerNC(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), "Default Bank")
                                    Dim deliveryExpences_nc As String = obj.GetLedgerNC(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), "Delivery Expenses")
                                    If ChkLog.Checked = False Then
                                        log = ". Invoice Creation in Pro_invoice by SP:ACCOUNTSPRO_UPDATEPROINVOICE For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(1).Rows(K).Item("Sender")
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @InvoiceNumber= " & "0" & vbCrLf
                                        log = log & ". @Inv_date=" & Date.Now() & vbCrLf
                                        log = log & ". @Cust_det=" & "" & vbCrLf
                                        log = log & ". @product_tax_code=" & DataS.Tables(0).Rows(0).Item("product_tax_code") & vbCrLf
                                        log = log & ". @tax_Code_rate=" & DataS.Tables(0).Rows(0).Item("tax_Code_rate") & vbCrLf
                                        log = log & ". @GlobalTC= " & "T9" & vbCrLf
                                        log = log & ". @GlobalTCrate= " & "0" & vbCrLf
                                        log = log & ". @defaultBack_nc= " & defaultBack_nc & vbCrLf
                                        log = log & ". @deliveryExpences_nc= " & deliveryExpences_nc & vbCrLf
                                        log = log & ". @Inv_type= " & "Inv" & vbCrLf
                                        log = log & ". @Car_net= " & "0" & vbCrLf
                                        log = log & ". @Car_vat= " & "0" & vbCrLf
                                        log = log & ". @PaidAmount= " & NormalizeData.Tables(1).Rows(K).Item("PaidAmount") & vbCrLf
                                        log = log & ". @CloginID= " & NormalizeData.Tables(1).Rows(K).Item("CloginID") & vbCrLf
                                        log = log & ". @Pay_type= " & "Invoice"
                                        WriteDebugInfo(log, filename)
                                    End If
                                    inv_no = obj.InsertProInvoice(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "0", Date.Now(), "", DataS.Tables(0).Rows(0).Item("product_tax_code"), DataS.Tables(0).Rows(0).Item("tax_Code_rate"), "T9", "0", defaultBack_nc, deliveryExpences_nc, "Inv", 0, 0, NormalizeData.Tables(1).Rows(K).Item("PaidAmount"), NormalizeData.Tables(1).Rows(K).Item("CloginID"), "Invoice", "cb")
                                    ''.........End .............Insert in pro_invoice  to get invoice #...
                                    ''
                                    ''............. Start Insert in pro_inv_det  .............."

                                    Dim i As Integer = 0
                                    Dim ODetail As DataSet
                                    ODetail = obj.GetOrderDetail(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    For i = 0 To ODetail.Tables(0).Rows.Count - 1
                                        With ODetail.Tables(0).Rows(i)
                                            '  Dim _tempnet As String = FormatNumber(.Item("product_sale_price") * .Item("Qty"), 2, , , TriState.False)
                                            'Dim _tempnet As String = FormatNumber(.Item("unitprice") * .Item("Qty"), 2, , , TriState.False)
                                            Dim _tempvat As String = FormatNumber(.Item("Tax_amount"), 2, , , TriState.False)

                                            Dim discountAmount As Double = .Item("Discount")
                                            Dim product_sale_price As Double = (.Item("product_sale_price"))
                                            Dim discountPer As Double '= .Item("product_sale_price") / discountAmount


                                            Dim _tempnet As String = FormatNumber(product_sale_price * .Item("Qty"), 2, , , TriState.False)
                                            Dim nc As String
                                            If IsDBNull(.Item("nc")) Then
                                                nc = "10000"
                                            Else
                                                nc = .Item("nc")
                                            End If
                                            If ChkLog.Checked = False Then
                                                log = ". Inserting Order Detail by SP: ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS For Bank(CreateInvoice=Y) For Sender. " & NormalizeData.Tables(1).Rows(K).Item("Sender") & vbCrLf
                                                log = log & ". Having Parameters: " & vbCrLf
                                                log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                                log = log & ". @inv_no= " & inv_no & vbCrLf
                                                log = log & ". @prod_code= " & .Item("prod_code") & vbCrLf
                                                log = log & ". @prod_name= " & .Item("cart_product_name") & vbCrLf
                                                log = log & ". @nc=" & nc & vbCrLf
                                                log = log & ". @product_tax_code=" & .Item("product_tax_code") & vbCrLf
                                                log = log & ". @tax_code_rate=" & .Item("tax_code_rate") & vbCrLf
                                                log = log & ". @Detail= " & "" & vbCrLf
                                                log = log & ". @product_sale_price= " & .Item("product_sale_price") & vbCrLf
                                                log = log & ". @Qty= " & .Item("Qty") & vbCrLf
                                                log = log & ". @_tempnet= " & _tempnet & vbCrLf
                                                log = log & ". @_tempvat= " & _tempvat & vbCrLf
                                                log = log & ". @Inv_type= " & "Inv"
                                                WriteDebugInfo(log, filename)
                                            End If
                                            obj.InsertProdMasterDetail(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), inv_no, .Item("prod_code"), nc, .Item("product_tax_code"), .Item("tax_code_rate"), .Item("cart_product_name"), product_sale_price, .Item("Qty"), _tempnet, _tempvat, "Inv", discountAmount, discountPer)

                                        End With
                                    Next
                                    ' .....End Insert in pro_inv_det..................."
                                    ' 
                                    '........ start  Updating invoice # in Invoice Table.........."
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Number by SP :INFINISHOPS_ORDER_UPDATE_INVOICE_NO For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(1).Rows(K).Item("Sender")
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @inv_no= " & inv_no
                                        WriteDebugInfo(log, filename)
                                    End If

                                    obj.UpDateInvoiceNo(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), inv_no)
                                    '..........End   start  Updating invoice # in Invoice Table.........."
                                    '

                                    '........ start  Updating invoice # in CLEDGER Table.........."
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Number by SP :CXLROBO_UPDATEINVOICENUMBERINCLEDGER. For Bank (CreateInvoice=Y) "
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @inv_no= " & inv_no
                                        WriteDebugInfo(log, filename)
                                    End If

                                    obj.UpDateInvoiceNoInCledger(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), inv_no)
                                    ' ..........End   start  Updating invoice # in CLEDGER Table.........."
                                    '' 
                                End If
                                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                                If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then '' that means full payment
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of Bank  " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                                        log = log & ". @CXLCode= " & "" & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & "" & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "Y" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If

                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "C", "", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "Y")

                                Else
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of Bank  " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                        log = log & ". @CXLCode= " & "" & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & "" & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "P" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "P")

                                End If
                                ' ...End................... Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment............"
                                ' 



                                If (NormalizeData.Tables(1).Rows(K).Item("ProcessType") = "cc" Or NormalizeData.Tables(1).Rows(K).Item("ProcessType") = "CC") Then
                                    If ChkLog.Checked = False Then
                                        log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard  For Bank  (CreateInvoice=Y). "
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @CxlMessage= " & "BYBANK" & vbCrLf
                                        log = log & ". @TranStatus= " & "Y"
                                        WriteDebugInfo(log, filename)
                                    End If
                                    obj.UpdateCreditCard(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "BYBANK", "Y")
                                    ' ...... end Update Credit card in RFollowUp table.......................
                                    ' 
                                    If (NormalizeData.Tables(1).Rows(K).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
                                        If ChkLog.Checked = False Then
                                            log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
                                            log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For Bank (CreateInvoice=Y). "
                                            log = log & ". Having Parameters: " & vbCrLf
                                            log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                            log = log & ". @Amount= " & NormalizeData.Tables(1).Rows(K).Item("Amount") & vbCrLf
                                            log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                            log = log & ". @TransactionType= " & NormalizeData.Tables(1).Rows(K).Item("TransactionType") & vbCrLf
                                            log = log & ". @Inv_no= " & inv_no
                                            WriteDebugInfo(log, filename)
                                        End If
                                        '''' ....start update infinishopmainDB Mledger table................
                                        obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Amount"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), NormalizeData.Tables(1).Rows(K).Item("TransactionType"), inv_no)
                                        ' End ............update infinishopmainDB Mledger table.......


                                    End If
                                End If
                                If ChkLog.Checked = False Then
                                    log = ". Update Status of Bank To MYSQL " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @CloginId= " & NormalizeData.Tables(1).Rows(K).Item("CloginId") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLCode= " & 0 & vbCrLf
                                    log = log & ". @CXLMessage= " & "NULL" & vbCrLf
                                    log = log & ". @CsMessage= " & CsMessage & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @StatusFromCs= " & "Y" & vbCrLf
                                    log = log & ". @ResponseCode_Cs= " & ResponseCode_Cs
                                    WriteDebugInfo(log, filename)
                                End If
                                UpdateMySqlStatus(NormalizeData.Tables(1).Rows(K).Item("CloginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "0", "NULL", CsMessage, NormalizeData.Tables(1).Rows(K).Item("TrackID"), "Y", ResponseCode_Cs, inv_no)

                                If ChkLog.Checked = False Then
                                    log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA."
                                    WriteDebugInfo(log, filename)
                                End If
                                obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, inv_no, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                                Dim Post As New InvoicePostWS.AccountsProService

                                If ChkLog.Checked = False Then
                                    log = ". Invoices To Post of Inv No: For Bank (CreateInvoice=Y). " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @inv_no= " & inv_no
                                    WriteDebugInfo(log, filename)
                                End If
                                Dim b As String = Post.CXLRobot_PostInvoice(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), inv_no)
                                If ChkLog.Checked = False Then
                                    log = ". End of Invoices To Post of Inv No: For Bank (CreateInvoice=Y). " & vbCrLf
                                    log = log & ". Having Return Code: " & b
                                    WriteDebugInfo(log, filename)
                                End If

                            End If

                        ElseIf ((NormalizeData.Tables(1).Rows(K).Item("sender") = "PR" Or NormalizeData.Tables(1).Rows(K).Item("Sender") = "EX") And NormalizeData.Tables(1).Rows(K).Item("OrderID") = 0) Then

                            If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then ''' that means full payment
                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of bank " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If
                                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "*", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                            Else
                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of Bank " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If
                                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                            End If

                            obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CloginId"), NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("invoice_no"))

                            If ChkLog.Checked = False Then
                                log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(1).Rows(K).Item("invoice_no"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                        ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "AC") Then

                            If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then ''' that means full payment
                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of Bank " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If
                                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "*", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                            Else
                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of Bank " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If
                                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                            End If

                            If ChkLog.Checked = False Then
                                log = ". Calling EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender")
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @Customer_Id= " & NormalizeData.Tables(1).Rows(K).Item("Customer_Id") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                log = log & ". @IsOrderProcess= " & "True" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType")
                                WriteDebugInfo(log, filename)
                            End If
                            ObjService = New ServiceActivation.ServiceActivation

                            Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(1).Rows(K).Item("Customer_Id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), True, NormalizeData.Tables(1).Rows(K).Item("ProcessType"))

                            If ChkLog.Checked = False Then
                                log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)


                        ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "IR" Or NormalizeData.Tables(1).Rows(K).Item("sender") = "IN" Or NormalizeData.Tables(1).Rows(K).Item("sender") = "PR") Then

                            'SZ:ZA
                            'Created by Saad 29/01/08 on request of Asher
                            If ChkLog.Checked = False Then
                                log = ". Calling WebService COM.WEBSERVICES.ISHOPS (Zero Amount Orders )." & vbCrLf
                                log = log & "Permission = " & System.Configuration.ConfigurationSettings.AppSettings("ZeroAmountWebservice")
                                WriteDebugInfo(log, filename)
                            End If

                            Dim strCreateInv As String = "FALSE"
                            If UCase(System.Configuration.ConfigurationSettings.AppSettings("ZeroAmountWebservice")) = "ON" Then

                                Dim xmlCreateInv As String
                                Dim iShopWS As com.webservices.ishops.OrderProcessing

                                If NormalizeData.Tables(1).Rows(K).Item("amount") = 0 Then

                                    If ChkLog.Checked = False Then
                                        log = ". Calling WebService COM.WEBSERVICES.ISHOPS (Zero Amount Orders )."
                                        WriteDebugInfo(log, filename)
                                    End If

                                    Try
                                        '-----------------------------------------------
                                        iShopWS = New com.webservices.ishops.OrderProcessing
                                        Dim key As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
                                        Dim userid As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
                                        Dim pwd As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
                                        Dim domain As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)

                                        iShopWS.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)

                                        '------------------------------------------------

                                        'Dim iShopWS As New com.webservices.ishops.OrderProcessing
                                        xmlCreateInv = "<OrderInformation>" & _
                                                                    "<MerchantID>" & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & "</MerchantID>" & _
                                                                    "<MerchantUID>" & NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID") & "</MerchantUID>" & _
                                                                   "<CustomerID>" & NormalizeData.Tables(1).Rows(K).Item("Customer_id") & "</CustomerID>" & _
                                                                    "<CustomerUID>" & NormalizeData.Tables(1).Rows(K).Item("cloginid") & "</CustomerUID>" & _
                                                                    "<OrderID>" & NormalizeData.Tables(1).Rows(K).Item("OrderID") & "</OrderID>" & _
                                                                    "<OrderAmount>" & NormalizeData.Tables(1).Rows(K).Item("amount") & "</OrderAmount>" & _
                                                                "</OrderInformation>"
                                        strCreateInv = iShopWS.GenerateInvoiceForOrder(xmlCreateInv)

                                        If ChkLog.Checked = False Then
                                            log = "SERVICE URL = " & iShopWS.Url & vbCrLf
                                            log = log & "XML = " & xmlCreateInv & vbCrLf
                                            log = log & ". strCreateInv. = " & strCreateInv
                                            WriteDebugInfo(log, filename)
                                        End If

                                    Catch ex As Exception
                                        log = "SERVICE URL = " & iShopWS.Url & vbCrLf
                                        log = log & "XML = " & xmlCreateInv & vbCrLf
                                        log = log & "Except: on calling ZERO AMOUNT WEBSERVICE = " & ex.Message
                                        WriteDebugInfo(log, filename)
                                    End Try

                                End If
                            End If

                            If UCase(strCreateInv) = "TRUE" Or (NormalizeData.Tables(1).Rows(K).Item("CreateInvoice") = "Y" And UCase(MTS) = "Y") Then
                                CreateInvoiceByBank(K)
                            Else
                                'SZ:ZA

                                If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then ''' that means full payment
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of bank " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "N" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "*", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                                Else
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of bank " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "N" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                                End If
                            End If

                            If (NormalizeData.Tables(1).Rows(K).Item("sender") = "IR") Then

                                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))

                                ''Infinishop webservice
                                'Try
                                '    Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                                '    info.CustomerID = NormalizeData.Tables(1).Rows(K).Item("Customer_Id")

                                '    'SZ:ZA
                                '    If UCase(strCreateInv) = "TRUE" Then
                                '        info.IsOrderSuccess = True
                                '    Else
                                '        info.IsOrderSuccess = False
                                '    End If

                                '    info.MerchantID = NormalizeData.Tables(1).Rows(K).Item("MerchantID")
                                '    info.OrderID = NormalizeData.Tables(1).Rows(K).Item("OrderID")
                                '    If CType(NormalizeData.Tables(1).Rows(K).Item("ProcessType"), String).ToUpper = "CC" Then
                                '        info.PayMode = Io.InfiniShops.PaymentMode.CC
                                '    Else
                                '        info.PayMode = Io.InfiniShops.PaymentMode.CB
                                '    End If

                                '    If ChkLog.Checked = False Then
                                '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender")
                                '        WriteDebugInfo(log, filename)
                                '    End If
                                '    ObjIo = New Io.InfiniShops.ServiceActivation
                                '    Dim Result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                                '    If ChkLog.Checked = False Then
                                '        log = ". calling their Web service ENABLED SERVICES for Bank .ErrorCode= " & Result.ERRORCODE & " ResultDesciption=" & Result.ERRORDESC
                                '        WriteDebugInfo(log, filename)
                                '    End If

                                'Catch ex As Exception
                                '    log = "Except:. Calling InfiniShops.EnabledServices:" & ex.Message & " , MerchantID = " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & " , Order ID =" & NormalizeData.Tables(1).Rows(K).Item("OrderID")
                                '    WriteDebugInfo(log, filename)
                                '    SendEmail("Exception:. Calling InfiniShops.EnabledServices:" & ex.Message & " , MerchantID = " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & " , Order ID =" & NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                'End Try
                                ''----------

                                ''Reseller Webservice
                                'Try
                                '    Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail 'ServiceActivation.ProductDetail
                                '    Dim count As Integer
                                '    For count = 0 To DataS.Tables(0).Rows.Count - 1
                                '        Product(count) = New com.reseller.webservices.ProductDetail
                                '        Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                                '        Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                                '        Product(count).OrderType = datas.Tables(0).Rows(count).Item("OrderType")
                                '    Next
                                '    If ChkLog.Checked = False Then
                                '        log = ". calling Web service GETBIZINFO method for Bank For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                '        log = log & ". Having Parameters: " & vbCrLf
                                '        log = log & ". @MerchantLoginID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID") & vbCrLf
                                '        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                '        log = log & ". @Customer_id= " & NormalizeData.Tables(1).Rows(K).Item("Customer_id") & vbCrLf
                                '        'log = log & ". @Product= " & Product & vbCrLf
                                '        log = log & ". @PayStatus=" & "N"
                                '        WriteDebugInfo(log, filename)

                                '    End If
                                '    ResellerService = New com.reseller.webservices.IShopOrderHander

                                '    'SZ:ZA
                                '    If UCase(strCreateInv) = "TRUE" Then
                                '        ResellerService.GetBizInfo(NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("Customer_id"), Product, "Y")
                                '    Else
                                '        ResellerService.GetBizInfo(NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("Customer_id"), Product, "N")
                                '    End If

                                'Catch ex As Exception
                                '    log = "Except:. Reseller Webservice. Getbizinfo:" & ex.Message & " , Merchant Login ID = " & NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID") & " , Order ID =" & NormalizeData.Tables(1).Rows(K).Item("OrderID")
                                '    WriteDebugInfo(log, filename)
                                '    SendEmail("Exception:. Reseller Webservice. Getbizinfo:" & ex.Message & " , Merchant Login ID = " & NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID") & " , Order ID =" & NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                'End Try
                                ''----------


                                Try
                                    Dim strCreateInvMPI As String
                                    If UCase(strCreateInv) = "TRUE" Then
                                        strCreateInvMPI = "Y"
                                    Else
                                        strCreateInvMPI = "N"
                                    End If

                                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(K).Item("Customer_Id"), strCreateInvMPI, strCreateInvMPI, "CB")
                                    If ChkLog.Checked = False Then
                                        log = ". Dumping data for MPI Reseller" & vbCrLf
                                        log = log & "Exception:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                    End If
                                Catch ex As Exception
                                    log = ". Dumping data for MPI Reseller" & vbCrLf
                                    log = log & "Exception:" & ex.Message
                                    WriteDebugInfo(log, filename)
                                End Try

                                'Checking Referral Order (by Saad on request of Greesh 23/09/2008)
                                Try
                                    log = ". Checking Referral Order" & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    'Dim ds As DataSet = obj.GetRefferalOrder(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Customer_Id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    log = log & "Exception :" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                    'If Not ds Is Nothing Then
                                    '    If ds.Tables(0).Rows.Count > 0 Then
                                    '        log = log & ". Paying Commision: " & vbCrLf
                                    '        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    '        log = log & ". @CustomerID= " & NormalizeData.Tables(1).Rows(K).Item("Customer_Id") & vbCrLf
                                    '        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    '        obj.REFERRAL_PAYCOMMISSION(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Customer_Id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    '        log = log & "Exception :" & obj.GetExcept
                                    '        WriteDebugInfo(log, filename)
                                    '    End If
                                    'End If
                                Catch ex As Exception
                                    log = log & "Exception Checking Referral Order: " & ex.Message & vbCrLf
                                    WriteDebugInfo(log, filename)
                                End Try

                                '////////////////////////////////////////////



                                'Added by Saad 03/07/2008
                                'If UCase(strCreateInv) = "TRUE" Then
                                '    If ChkLog.Checked = False Then
                                '        log = ". calling COUPON Service For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                '        log = log & ". Having Parameters: " & vbCrLf
                                '        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                '        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                '        log = log & ". @Customer_id= " & NormalizeData.Tables(1).Rows(K).Item("Customer_id") & vbCrLf
                                '        WriteDebugInfo(log, filename)
                                '    End If

                                '    Dim couponService As New com.infinishops.couponsystem.EmailCoupon
                                '    Dim couponServiceResult As com.infinishops.couponsystem.ErrorCodesInfo = couponService.EmailToCustomer(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Customer_id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))

                                '    If ChkLog.Checked = False Then
                                '        log = ". Afer calling COUPON Service For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                '        log = log & ". Having Parameters: " & vbCrLf
                                '        log = log & ". @ErrorCode= " & couponServiceResult.ErrorCode & vbCrLf
                                '        log = log & ". @ErrorDescription= " & couponServiceResult.ErrorDescription & vbCrLf
                                '        WriteDebugInfo(log, filename)
                                '    End If
                                '    '---------------------------------------
                                'End If

                            ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "IN") Then


                                'Commented by Saad on 28/01/08 on request of Yousuf
                                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo

                                'infiniShops Webservice
                                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                                info.CustomerID = NormalizeData.Tables(1).Rows(K).Item("Customer_Id")

                                'SZ:ZA
                                If UCase(strCreateInv) = "TRUE" Then
                                    info.IsOrderSuccess = True
                                Else
                                    info.IsOrderSuccess = False
                                End If

                                info.MerchantID = NormalizeData.Tables(1).Rows(K).Item("MerchantID")
                                info.OrderID = NormalizeData.Tables(1).Rows(K).Item("OrderID")
                                If CType(NormalizeData.Tables(1).Rows(K).Item("ProcessType"), String).ToUpper = "CC" Then
                                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                                Else
                                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                                End If

                                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                                If ChkLog.Checked = False Then
                                    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender")
                                    WriteDebugInfo(log, filename)
                                End If
                                '----------------

                                'Added by Saad 03/07/2008
                                'If UCase(strCreateInv) = "TRUE" Then
                                '    If ChkLog.Checked = False Then
                                '        log = ". calling COUPON Service For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                '        log = log & ". Having Parameters: " & vbCrLf
                                '        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                '        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                '        log = log & ". @Customer_id= " & NormalizeData.Tables(1).Rows(K).Item("Customer_id") & vbCrLf
                                '        WriteDebugInfo(log, filename)
                                '    End If

                                '    Dim couponService As New com.infinishops.couponsystem.EmailCoupon
                                '    Dim couponServiceResult As com.infinishops.couponsystem.ErrorCodesInfo = couponService.EmailToCustomer(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Customer_id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))

                                '    If ChkLog.Checked = False Then
                                '        log = ". Afer calling COUPON Service For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                '        log = log & ". Having Parameters: " & vbCrLf
                                '        log = log & ". @ErrorCode= " & couponServiceResult.ErrorCode & vbCrLf
                                '        log = log & ". @ErrorDescription= " & couponServiceResult.ErrorDescription & vbCrLf
                                '        WriteDebugInfo(log, filename)
                                '    End If
                                '    '---------------------------------------
                                'End If

                                'Checking Referral Order (by Saad on request of Greesh 23/09/2008)
                                log = ". Checking Referral Order" & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                Try
                                    'Dim ds As DataSet = obj.GetRefferalOrder(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Customer_Id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    log = log & "Exception :" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                    'If Not ds Is Nothing Then
                                    '    If ds.Tables(0).Rows.Count > 0 Then
                                    '        log = log & ". Paying Commision: " & vbCrLf
                                    '        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    '        log = log & ". @CustomerID= " & NormalizeData.Tables(1).Rows(K).Item("Customer_Id") & vbCrLf
                                    '        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    '        obj.REFERRAL_PAYCOMMISSION(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("Customer_Id"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    '        log = log & "Exception :" & obj.GetExcept
                                    '        WriteDebugInfo(log, filename)
                                    '    End If
                                    'End If
                                Catch ex As Exception
                                    log = log & "Exception Checking Referral Order: " & ex.Message & vbCrLf
                                    WriteDebugInfo(log, filename)
                                End Try

                                '////////////////////////////////////////////

                            End If


                            If ChkLog.Checked = False Then
                                log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)


                        ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "IB") Then
                            If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then ''' that means full payment
                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of bank " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If
                                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "*", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                            Else
                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of bank " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                    log = log & ". @CXLCode= " & 100 & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If
                                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                            End If  '  If ChkLog.Checked = False Then


                            If ChkLog.Checked = False Then
                                log = ". Update Status of to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                        ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "IM") Then

                            'SZ:ZA
                            'Created by Saad 29/01/08 on request of Asher
                            If ChkLog.Checked = False Then
                                log = ". Calling WebService COM.WEBSERVICES.ISHOPS (Zero Amount Orders )." & vbCrLf
                                log = log & "Permission = " & System.Configuration.ConfigurationSettings.AppSettings("ZeroAmountWebservice")
                                WriteDebugInfo(log, filename)
                            End If

                            Dim strCreateInv As String = "FALSE"
                            If UCase(System.Configuration.ConfigurationSettings.AppSettings("ZeroAmountWebservice")) = "ON" Then

                                Dim xmlCreateInv As String
                                Dim iShopWS As com.webservices.ishops.OrderProcessing

                                If NormalizeData.Tables(1).Rows(K).Item("amount") = 0 Then

                                    If ChkLog.Checked = False Then
                                        log = ". Calling WebService COM.WEBSERVICES.ISHOPS (Zero Amount Orders )."
                                        WriteDebugInfo(log, filename)
                                    End If

                                    Try
                                        '-----------------------------------------------
                                        iShopWS = New com.webservices.ishops.OrderProcessing
                                        Dim key As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
                                        Dim userid As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
                                        Dim pwd As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
                                        Dim domain As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
                                        iShopWS.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
                                        '------------------------------------------------

                                        'Dim iShopWS As New com.webservices.ishops.OrderProcessing
                                        xmlCreateInv = "<OrderInformation>" & _
                                                                    "<MerchantID>" & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & "</MerchantID>" & _
                                                                    "<MerchantUID>" & NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID") & "</MerchantUID>" & _
                                                                   "<CustomerID>" & NormalizeData.Tables(1).Rows(K).Item("Customer_id") & "</CustomerID>" & _
                                                                    "<CustomerUID>" & NormalizeData.Tables(1).Rows(K).Item("cloginid") & "</CustomerUID>" & _
                                                                    "<OrderID>" & NormalizeData.Tables(1).Rows(K).Item("OrderID") & "</OrderID>" & _
                                                                    "<OrderAmount>" & NormalizeData.Tables(1).Rows(K).Item("amount") & "</OrderAmount>" & _
                                                                "</OrderInformation>"
                                        strCreateInv = iShopWS.GenerateInvoiceForOrder(xmlCreateInv)

                                        If ChkLog.Checked = False Then
                                            log = "SERVICE URL = " & iShopWS.Url & vbCrLf
                                            log = log & "XML = " & xmlCreateInv & vbCrLf
                                            log = log & ". strCreateInv. = " & strCreateInv
                                            WriteDebugInfo(log, filename)
                                        End If

                                    Catch ex As Exception
                                        log = "SERVICE URL = " & iShopWS.Url & vbCrLf
                                        log = log & "XML = " & xmlCreateInv & vbCrLf
                                        log = log & "Except: on calling ZERO AMOUNT WEBSERVICE = " & ex.Message
                                        WriteDebugInfo(log, filename)
                                    End Try

                                End If
                            End If

                            If UCase(strCreateInv) = "TRUE" Then
                                CreateInvoiceByBank(K)
                            Else
                                'SZ:ZA
                                If (NormalizeData.Tables(1).Rows(K).Item("ccstatus") = "Y") Then ''' that means full payment
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of bank " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "N" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "*", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                                    'Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                                    'info.CustomerID = NormalizeData.Tables(1).Rows(K).Item("Customer_Id")
                                    ''SZ:ZA
                                    'If UCase(strCreateInv) = "TRUE" Then
                                    '    info.IsOrderSuccess = True
                                    'Else
                                    '    info.IsOrderSuccess = False
                                    'End If

                                    'info.MerchantID = NormalizeData.Tables(1).Rows(K).Item("MerchantID")
                                    'info.OrderID = NormalizeData.Tables(1).Rows(K).Item("OrderID")
                                    'If CType(NormalizeData.Tables(1).Rows(K).Item("ProcessType"), String).ToUpper = "CC" Then
                                    '    info.PayMode = Io.InfiniShops.PaymentMode.CC
                                    'Else
                                    '    info.PayMode = Io.InfiniShops.PaymentMode.CB
                                    'End If

                                    'If ChkLog.Checked = False Then
                                    '    log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender")
                                    '    WriteDebugInfo(log, filename)
                                    'End If

                                    'Dim objIShop As New com.infinishops.io.IShopServiceActivation
                                    'Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)


                                Else
                                    If ChkLog.Checked = False Then
                                        log = ". Update Invoice Status of bank " & vbCrLf
                                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(K).Item("ProcessType") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf

                                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                        log = log & ". Having Parameters: " & vbCrLf
                                        log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(K).Item("MerchantID") & vbCrLf
                                        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & vbCrLf
                                        log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                                        log = log & ". @CXLCode= " & 100 & vbCrLf
                                        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & vbCrLf
                                        log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(K).Item("sender") & vbCrLf
                                        log = log & ". @CCStatus= " & "N" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), "P", "100", "BY BANK", NormalizeData.Tables(1).Rows(K).Item("ProcessType"), NormalizeData.Tables(1).Rows(K).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(K).Item("MerchantID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(K).Item("trackid"), NormalizeData.Tables(1).Rows(K).Item("sender"), "N")

                                End If
                            End If

                            Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                            info.CustomerID = NormalizeData.Tables(1).Rows(K).Item("Customer_Id")

                            'SZ:ZA
                            If strCreateInv = "TRUE" Then
                                info.IsOrderSuccess = True
                            Else
                                info.IsOrderSuccess = False
                            End If
                            info.MerchantID = NormalizeData.Tables(1).Rows(K).Item("MerchantID")
                            info.OrderID = NormalizeData.Tables(1).Rows(K).Item("OrderID")
                            If CType(NormalizeData.Tables(1).Rows(K).Item("ProcessType"), String).ToUpper = "CC" Then
                                info.PayMode = Io.InfiniShops.PaymentMode.CC
                            Else
                                info.PayMode = Io.InfiniShops.PaymentMode.CB
                            End If

                            If ChkLog.Checked = False Then
                                log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(K).Item("sender")
                                WriteDebugInfo(log, filename)
                            End If

                            Dim objIShop As New com.infinishops.io.IShopServiceActivation
                            Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                            If ChkLog.Checked = False Then
                                log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "X", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)
                        Else
                            If ChkLog.Checked = False Then
                                log = ". Update Status of Invalid SENDER by SP:CXLROBO_UPDATEDATA."
                                WriteDebugInfo(log, filename)
                            End If
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("trackid"), CxlIdentity)

                        End If

                        'Following code was added by M. Furqan Khan on 10 FEB 2009
                        With NormalizeData.Tables(1).Rows(K)
                            PostCallBackData(.Item("MerchantId"), .Item("OrderID"), .Item("GCode"), .Item("Amount"), .Item("TrackID"), True, True)
                        End With

                    Catch ex As Exception
                        If ChkLog.Checked = False Then
                            log = ". Exception Occured and updating status_atcs=I For Bank Transaction . " & ex.Message
                            WriteDebugInfo(log, filename)
                        End If

                        ResponseCode_Cs = "-6"    ' Credit card not posted to cxl bcoz of any failure
                        CsMessage = "Bank Transaction Can't Processed B/C" & ex.Message

                        SendEmail("Sender = " & NormalizeData.Tables(1).Rows(K).Item("sender") & " OrderID= " & NormalizeData.Tables(1).Rows(K).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(1).Rows(K).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(1).Rows(K).Item("TrackID") & " Exception= " & ex.Message)
                        DataString = DataString & ex.Message & "Bank Function" & obj.GetExcept & vbNewLine
                        LstException.Items.Add(DateTime.Now & " " & ex.Message & "Bank Function" & obj.GetExcept)

                        If (NormalizeData.Tables(1).Rows(K).Item("sender") = "PR" Or NormalizeData.Tables(1).Rows(K).Item("Sender") = "EX") Then
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, NormalizeData.Tables(1).Rows(K).Item("invoice_no"), NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)
                        ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "FH") Then
                            UpdateMySqlStatus(NormalizeData.Tables(1).Rows(K).Item("CloginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "", "By Bank", CsMessage, NormalizeData.Tables(1).Rows(K).Item("TrackID"), "I", ResponseCode_Cs)
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                        ElseIf (NormalizeData.Tables(1).Rows(K).Item("sender") = "AC" Or NormalizeData.Tables(1).Rows(K).Item("Sender") = "IN" Or NormalizeData.Tables(1).Rows(K).Item("Sender") = "IR" Or NormalizeData.Tables(1).Rows(K).Item("Sender") = "IM" Or NormalizeData.Tables(1).Rows(K).Item("Sender") = "IB") Then
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                        Else
                            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(K).Item("MerchantId"), NormalizeData.Tables(1).Rows(K).Item("CLoginId"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(1).Rows(K).Item("TrackID"), CxlIdentity)

                        End If

                    End Try

                Next

            End If
        End Sub

        'Created by Saad 29/01/08
        Public Sub CreateInvoiceByBank(ByVal k As Integer)
            'When CreateInvoice = Yes
            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            ResponseCode_Cs = "2"
            CsMessage = "Zero Amount Order,Invoice has been created."
            '..................start  Update Invoice Table ..............." 
            If ChkLog.Checked = False Then
                log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS For Bank (CreateInvoice=Y) For Sender=. " & NormalizeData.Tables(1).Rows(k).Item("Sender") & vbCrLf
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf
                log = log & ". @PaidAmount= " & NormalizeData.Tables(1).Rows(k).Item("PaidAmount") & vbCrLf
                log = log & ". @ccStatus= " & NormalizeData.Tables(1).Rows(k).Item("ccStatus")
                WriteDebugInfo(log, filename)
            End If
            obj.UpDatePayAmount(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), NormalizeData.Tables(1).Rows(k).Item("PaidAmount"), NormalizeData.Tables(1).Rows(k).Item("ccStatus"))
            '............... End Start Update Invoice Table pay_amt field etc...................."
            Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"))

            If ChkLog.Checked = False Then
                log = ". Getting Order Detail by SP :INFINISHOPS_ORDER_ADDDETAILS For Bank . "
                WriteDebugInfo(log, filename)
            End If
            ' ...............start. Insert order details in inv_det table............."
            Dim X As Integer
            For X = 0 To DataS.Tables(0).Rows.Count - 1
                obj.OrderAddDetail(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), "@ORD" + NormalizeData.Tables(1).Rows(k).Item("OrderID"), DataS.Tables(0).Rows(X).Item("Product_ID"), DataS.Tables(0).Rows(X).Item("prod_code"), DataS.Tables(0).Rows(X).Item("Qty"), DataS.Tables(0).Rows(X).Item("product_sale_price"), DataS.Tables(0).Rows(X).Item("product_tax_code"), DataS.Tables(0).Rows(X).Item("tax_code_rate"), DataS.Tables(0).Rows(X).Item("unitprice"), "S")
                If ChkLog.Checked = False Then
                    log = ". Adding Order Detail . "
                    WriteDebugInfo(log, filename)
                End If
            Next
            ' ............... end Insert order details in inv_det table..........."
            Dim Copy2ProWeb As Boolean = False

            Dim inv_no As Integer
            If (obj.CheckServiceEnable(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), "118") = True Or obj.CheckServiceEnable(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), "232") = True) Then

                ''''............... Sttart Insert in pro_invoice  to get invoice #..............."
                Dim defaultBack_nc As String = obj.GetLedgerNC(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), "Default Bank")
                Dim deliveryExpences_nc As String = obj.GetLedgerNC(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), "Delivery Expenses")
                If ChkLog.Checked = False Then
                    log = ". Invoice Creation in Pro_invoice by SP:ACCOUNTSPRO_UPDATEPROINVOICE For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(1).Rows(k).Item("Sender")
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf
                    log = log & ". @InvoiceNumber= " & "0" & vbCrLf
                    log = log & ". @Inv_date=" & Date.Now() & vbCrLf
                    log = log & ". @Cust_det=" & "" & vbCrLf
                    log = log & ". @product_tax_code=" & DataS.Tables(0).Rows(0).Item("product_tax_code") & vbCrLf
                    log = log & ". @tax_Code_rate=" & DataS.Tables(0).Rows(0).Item("tax_Code_rate") & vbCrLf
                    log = log & ". @GlobalTC= " & "T9" & vbCrLf
                    log = log & ". @GlobalTCrate= " & "0" & vbCrLf
                    log = log & ". @defaultBack_nc= " & defaultBack_nc & vbCrLf
                    log = log & ". @deliveryExpences_nc= " & deliveryExpences_nc & vbCrLf
                    log = log & ". @Inv_type= " & "Inv" & vbCrLf
                    log = log & ". @Car_net= " & "0" & vbCrLf
                    log = log & ". @Car_vat= " & "0" & vbCrLf
                    log = log & ". @PaidAmount= " & NormalizeData.Tables(1).Rows(k).Item("PaidAmount") & vbCrLf
                    log = log & ". @CloginID= " & NormalizeData.Tables(1).Rows(k).Item("CloginID") & vbCrLf
                    log = log & ". @Pay_type= " & "Invoice"
                    WriteDebugInfo(log, filename)
                End If
                inv_no = obj.InsertProInvoice(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), "0", Date.Now(), "", DataS.Tables(0).Rows(0).Item("product_tax_code"), DataS.Tables(0).Rows(0).Item("tax_Code_rate"), "T9", "0", defaultBack_nc, deliveryExpences_nc, "Inv", 0, 0, NormalizeData.Tables(1).Rows(k).Item("PaidAmount"), NormalizeData.Tables(1).Rows(k).Item("CloginID"), "Invoice", "cb")
                ''.........End .............Insert in pro_invoice  to get invoice #...
                ''
                ''............. Start Insert in pro_inv_det  .............."

                Dim i As Integer = 0
                Dim ODetail As DataSet
                ODetail = obj.GetOrderDetail(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"))
                For i = 0 To ODetail.Tables(0).Rows.Count - 1
                    With ODetail.Tables(0).Rows(i)
                        ' Dim _tempnet As String = FormatNumber(.Item("product_sale_price") * .Item("Qty"), 2, , , TriState.False)
                        'Dim _tempnet As String = FormatNumber(.Item("unitprice") * .Item("Qty"), 2, , , TriState.False)
                        Dim _tempvat As String = FormatNumber(.Item("Tax_amount"), 2, , , TriState.False)

                        Dim discountAmount As Double = .Item("Discount")
                        Dim product_sale_price As Double = (.Item("product_sale_price"))
                        Dim discountPer As Double '= .Item("product_sale_price") / discountAmount

                        Dim _tempnet As String = FormatNumber(product_sale_price * .Item("Qty"), 2, , , TriState.False)
                        Dim nc As String
                        If IsDBNull(.Item("nc")) Then
                            nc = "10000"
                        Else
                            nc = .Item("nc")
                        End If
                        If ChkLog.Checked = False Then
                            log = ". Inserting Order Detail by SP: ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS For Bank(CreateInvoice=Y) For Sender. " & NormalizeData.Tables(1).Rows(k).Item("Sender") & vbCrLf
                            log = log & ". Having Parameters: " & vbCrLf
                            log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                            log = log & ". @inv_no= " & inv_no & vbCrLf
                            log = log & ". @prod_code= " & .Item("prod_code") & vbCrLf
                            log = log & ". @prod_name= " & .Item("cart_product_name") & vbCrLf
                            log = log & ". @nc=" & nc & vbCrLf
                            log = log & ". @product_tax_code=" & .Item("product_tax_code") & vbCrLf
                            log = log & ". @tax_code_rate=" & .Item("tax_code_rate") & vbCrLf
                            log = log & ". @Detail= " & "" & vbCrLf
                            log = log & ". @product_sale_price= " & .Item("product_sale_price") & vbCrLf
                            log = log & ". @Qty= " & .Item("Qty") & vbCrLf
                            log = log & ". @_tempnet= " & _tempnet & vbCrLf
                            log = log & ". @_tempvat= " & _tempvat & vbCrLf
                            log = log & ". @Inv_type= " & "Inv"
                            WriteDebugInfo(log, filename)
                        End If
                        obj.InsertProdMasterDetail(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), inv_no, .Item("prod_code"), nc, .Item("product_tax_code"), .Item("tax_code_rate"), .Item("cart_product_name"), product_sale_price, .Item("Qty"), _tempnet, _tempvat, "Inv", discountAmount, discountPer)

                    End With
                Next
                ' .....End Insert in pro_inv_det..................."
                ' 
                '........ start  Updating invoice # in Invoice Table.........."
                If ChkLog.Checked = False Then
                    log = ". Update Invoice Number by SP :INFINISHOPS_ORDER_UPDATE_INVOICE_NO For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(1).Rows(k).Item("Sender")
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf
                    log = log & ". @inv_no= " & inv_no
                    WriteDebugInfo(log, filename)
                End If

                obj.UpDateInvoiceNo(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), inv_no)
                '..........End   start  Updating invoice # in Invoice Table.........."
                '

                '........ start  Updating invoice # in CLEDGER Table.........."
                If ChkLog.Checked = False Then
                    log = ". Update Invoice Number by SP :CXLROBO_UPDATEINVOICENUMBERINCLEDGER. For Bank (CreateInvoice=Y) "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(k).Item("TrackID") & vbCrLf
                    log = log & ". @inv_no= " & inv_no
                    WriteDebugInfo(log, filename)
                End If

                obj.UpDateInvoiceNoInCledger(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), NormalizeData.Tables(1).Rows(k).Item("TrackID"), inv_no)
                ' ..........End   start  Updating invoice # in CLEDGER Table.........."
                '' 
            End If
            '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
            If (NormalizeData.Tables(1).Rows(k).Item("ccstatus") = "Y") Then '' that means full payment
                If ChkLog.Checked = False Then
                    log = ". Update Invoice Status of Bank  " & vbCrLf
                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(k).Item("TrackID") & vbCrLf
                    log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                    log = log & ". @CXLCode= " & "" & vbCrLf
                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(k).Item("ProcessType") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf

                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf
                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                    log = log & ". @CXLCode= " & "" & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(k).Item("TrackID") & vbCrLf
                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(k).Item("sender") & vbCrLf
                    log = log & ". @CCStatus= " & "Y" & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If

                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("TrackID"), "C", "", "BY BANK", NormalizeData.Tables(1).Rows(k).Item("ProcessType"), NormalizeData.Tables(1).Rows(k).Item("OrderID"))
                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(k).Item("MerchantId"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(k).Item("trackid"), NormalizeData.Tables(1).Rows(k).Item("sender"), "Y")

            Else
                If ChkLog.Checked = False Then
                    log = ". Update Invoice Status of Bank  " & vbCrLf
                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(k).Item("TrackID") & vbCrLf
                    log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                    log = log & ". @CXLCode= " & "" & vbCrLf
                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                    log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(k).Item("ProcessType") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf

                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & vbCrLf
                    log = log & ". @CXLMessage= " & "BY BANK" & vbCrLf
                    log = log & ". @CXLCode= " & "" & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(k).Item("TrackID") & vbCrLf
                    log = log & ". @Sender= " & NormalizeData.Tables(1).Rows(k).Item("sender") & vbCrLf
                    log = log & ". @CCStatus= " & "P" & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
                obj.UpdateInvoiceStatus(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("TrackID"), "P", "", "BY BANK", NormalizeData.Tables(1).Rows(k).Item("ProcessType"), NormalizeData.Tables(1).Rows(k).Item("OrderID"))
                obj.UpdateInvoiceTable(NormalizeData.Tables(1).Rows(k).Item("MerchantId"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), "BY BANK", "", NormalizeData.Tables(1).Rows(k).Item("trackid"), NormalizeData.Tables(1).Rows(k).Item("sender"), "P")

            End If
            ' ...End................... Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment............"

            If (NormalizeData.Tables(1).Rows(k).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
                If ChkLog.Checked = False Then
                    log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
                    log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For Bank (CreateInvoice=Y). "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                    log = log & ". @Amount= " & NormalizeData.Tables(1).Rows(k).Item("Amount") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(k).Item("TrackID") & vbCrLf
                    log = log & ". @TransactionType= " & NormalizeData.Tables(1).Rows(k).Item("TransactionType") & vbCrLf
                    log = log & ". @Inv_no= " & inv_no
                    WriteDebugInfo(log, filename)
                End If
                '''' ....start update infinishopmainDB Mledger table................
                obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), NormalizeData.Tables(1).Rows(k).Item("Amount"), NormalizeData.Tables(1).Rows(k).Item("TrackID"), NormalizeData.Tables(1).Rows(k).Item("TransactionType"), inv_no)
                ' End ............update infinishopmainDB Mledger table.......
            End If

            ' ........ start .....Posting Invoice ............... 
            Dim Post As New InvoicePostWS.AccountsProService
            Post.Timeout = 3 * 60 * 1000

            If ChkLog.Checked = False Then
                log = ". Invoices To Post of Inv No: For Bank (CreateInvoice=Y). " & vbCrLf
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & vbCrLf
                log = log & ". @inv_no= " & inv_no
                WriteDebugInfo(log, filename)
            End If
            Dim b As String = Post.CXLRobot_PostInvoice(NormalizeData.Tables(1).Rows(k).Item("MerchantID"), inv_no)

            If b <> "0" Then
                SendEmail("Merchant ID: " & NormalizeData.Tables(1).Rows(k).Item("MerchantID") & ", Order ID: " & NormalizeData.Tables(1).Rows(k).Item("OrderID") & ", Invoice no: " & inv_no & ", Response from Post Invoice: " & b)
            End If

            If ChkLog.Checked = False Then
                log = ". End of Invoices To Post of Inv No: For Bank (CreateInvoice=Y). " & vbCrLf
                log = log & ". Having Return Code: " & b
                WriteDebugInfo(log, filename)
            End If
            ' ........ end .....Posting Invoice ............... 

            If ChkLog.Checked = False Then
                log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA."
                WriteDebugInfo(log, filename)
            End If
            obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(k).Item("MerchantId"), NormalizeData.Tables(1).Rows(k).Item("CLoginId"), NormalizeData.Tables(1).Rows(k).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, inv_no, NormalizeData.Tables(1).Rows(k).Item("TrackID"), CxlIdentity)

        End Sub
#End Region

#Region "........... Updating Status for Sucessfull BuyerPoint Transaction ..........."

        Public Sub SetBuyerPointTransactionStatus()

            Dim PaymentType As String
            Dim K As Integer
            'ResponseCode_Cs = ""
            'CsMessage = ""
            Dim CXLR_Code As String = "0"
            Dim CXL_Msg As String '= "Buyerpoint Processed"

            If (NormalizeData.Tables(3).Rows.Count > 0) Then
                ' FOR BuyerPoint TRANSACTION ''''UPDATING TABLES

                For K = 0 To NormalizeData.Tables(3).Rows.Count - 1
                    Try

                        StatusResponse = StatusResponse + 1
                        lblStatusResponse.Text = StatusResponse
                        Application.DoEvents()

                        PaymentType = NormalizeData.Tables(3).Rows(K).Item("ProcessType")
                        If UCase(PaymentType) = "PA" Then
                            SetPATransactionStatus()
                            Exit Sub
                        End If

                        obj.GetExcept = ""
                        ResponseCode_Cs = "0"
                        CsMessage = "BuyerPoint Transaction is Tested Successfully Invoice Will Create"
                        txtBank.Text = CStr(K + 1) & " / " & NormalizeData.Tables(3).Rows.Count

                        'If (NormalizeData.Tables(3).Rows(K).Item("sender") = "IR" Or NormalizeData.Tables(3).Rows(K).Item("sender") = "IN") Then

                        If (NormalizeData.Tables(3).Rows(K).Item("ccstatus") = "Y") Then
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status  " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(K).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(K).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                log = log & ". @CXLCode= " & 100 & vbCrLf
                                log = log & ". @CXLMessage= " & "By BP" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(K).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(K).Item("OrderID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(K).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(3).Rows(K).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "Y" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If

                            SuccessfulCXLFOR_BP(K, CXLR_Code, "Buyerpoint Processed")

                        End If

                        If (NormalizeData.Tables(3).Rows(K).Item("sender") = "IR") Then

                            'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(K).Item("MerchantID"), NormalizeData.Tables(3).Rows(K).Item("OrderID"))


                            ''Infinishop webservice
                            'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                            'info.CustomerID = NormalizeData.Tables(3).Rows(K).Item("Customer_Id")
                            'info.IsOrderSuccess = True
                            'info.MerchantID = NormalizeData.Tables(3).Rows(K).Item("MerchantID")
                            'info.OrderID = NormalizeData.Tables(3).Rows(K).Item("OrderID")
                            'info.PayMode = Io.InfiniShops.PaymentMode.BP

                            'If ChkLog.Checked = False Then
                            '    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender")
                            '    WriteDebugInfo(log, filename)
                            'End If
                            'ObjIo = New Io.InfiniShops.ServiceActivation

                            'Dim Result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                            'If ChkLog.Checked = False Then
                            '    log = ". calling their Web service ENABLED SERVICES for Bank .ErrorCode= " & Result.ERRORCODE & " ResultDesciption=" & Result.ERRORDESC
                            '    WriteDebugInfo(log, filename)
                            'End If
                            ''--------


                            ''Reseller webservice
                            'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail
                            'Dim count As Integer
                            'For count = 0 To DataS.Tables(0).Rows.Count - 1
                            '    Product(count) = New com.reseller.webservices.ProductDetail
                            '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                            '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                            '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                            'Next
                            'If ChkLog.Checked = False Then
                            '    log = ". calling Web service GETBIZINFO method for(invalid data) For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender") & vbCrLf
                            '    log = log & ". Having Parameters: " & vbCrLf
                            '    log = log & ". @MerchantLoginID= " & NormalizeData.Tables(3).Rows(K).Item("MerchantLoginID") & vbCrLf
                            '    log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(K).Item("OrderID") & vbCrLf
                            '    log = log & ". @Customer_id= " & NormalizeData.Tables(3).Rows(K).Item("Customer_id") & vbCrLf
                            '    'log = log & ". @Product= " & Product & vbCrLf
                            '    log = log & ". @PayStatus=" & "Y"
                            '    WriteDebugInfo(log, filename)

                            'End If

                            '' ObjService.GetBizInfo(NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("Customer_id"), Product, "N")
                            'ResellerService = New com.reseller.webservices.IShopOrderHander
                            'ResellerService.Timeout = 4 * 60 * 1000
                            'ResellerService.GetBizInfo(NormalizeData.Tables(3).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), NormalizeData.Tables(3).Rows(K).Item("Customer_id"), Product, "Y")
                            ''--------

                            Try
                                obj.MPI_ResselerAndActivationData(NormalizeData.Tables(3).Rows(K).Item("OrderID"), NormalizeData.Tables(3).Rows(K).Item("MerchantID"), NormalizeData.Tables(3).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(K).Item("Customer_Id"), "Y", "Y", "BP")
                                If ChkLog.Checked = False Then
                                    log = ". Dumping data for MPI Reseller" & vbCrLf
                                    log = log & "Exception:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                End If
                            Catch ex As Exception
                                log = ". Dumping data for MPI Reseller" & vbCrLf
                                log = log & "Exception:" & ex.Message
                                WriteDebugInfo(log, filename)
                            End Try


                        ElseIf (NormalizeData.Tables(3).Rows(K).Item("sender") = "IM") Then

                            Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo

                            info.CustomerID = NormalizeData.Tables(3).Rows(K).Item("Customer_Id")
                            info.IsOrderSuccess = True
                            info.MerchantID = NormalizeData.Tables(3).Rows(K).Item("MerchantID")
                            info.OrderID = NormalizeData.Tables(3).Rows(K).Item("OrderID")
                            info.PayMode = Io.InfiniShops.PaymentMode.BP

                            Dim objIShop As New com.infinishops.io.IShopServiceActivation
                            Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                            If ChkLog.Checked = False Then
                                log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender")
                                WriteDebugInfo(log, filename)
                            End If

                        ElseIf (NormalizeData.Tables(3).Rows(K).Item("sender") = "IN") Then

                            Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo

                            info.CustomerID = NormalizeData.Tables(3).Rows(K).Item("Customer_Id")
                            info.IsOrderSuccess = True
                            info.MerchantID = NormalizeData.Tables(3).Rows(K).Item("MerchantID")
                            info.OrderID = NormalizeData.Tables(3).Rows(K).Item("OrderID")
                            info.PayMode = Io.InfiniShops.PaymentMode.BP

                            Dim objIShop As New com.infinishops.io.IShopServiceActivation
                            Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                            If ChkLog.Checked = False Then
                                log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender")
                                WriteDebugInfo(log, filename)
                            End If

                        End If

                        If ChkLog.Checked = False Then
                            log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA_FOR_BP."
                            WriteDebugInfo(log, filename)
                        End If
                        'obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(K).Item("TrackID"))
                        obj.UpdateResponseForBP_New(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(3).Rows(K).Item("invoice_no"), NormalizeData.Tables(3).Rows(K).Item("TrackID"))
                        'End If

                    Catch ex As Exception

                        If ChkLog.Checked = False Then
                            log = ". Exception Occured and updating status_atcs=I For BuyerPoint Transaction . " & ex.Message
                            WriteDebugInfo(log, filename)
                        End If

                        ResponseCode_Cs = "-6"    ' Credit card not posted to cxl bcoz of any failure
                        CsMessage = "BuyerPoint Transaction Can't Processed B/C" & ex.Message

                        SendEmail("Sender = " & NormalizeData.Tables(3).Rows(K).Item("sender") & " OrderID= " & NormalizeData.Tables(3).Rows(K).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(3).Rows(K).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(3).Rows(K).Item("TrackID") & " Exception= " & ex.Message)
                        DataString = DataString & ex.Message & "BP Function" & obj.GetExcept & vbNewLine
                        LstException.Items.Add(DateTime.Now & " " & ex.Message & "BP Function" & obj.GetExcept)

                        If (NormalizeData.Tables(3).Rows(K).Item("sender") = "AC" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IN" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IR" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IM" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IB") Then
                            obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(K).Item("TrackID"), CxlIdentity)
                        Else
                            obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(K).Item("TrackID"), CxlIdentity)

                        End If

                    End Try

                Next

            End If
        End Sub

        Public Sub SetPATransactionStatus()

            Dim K As Integer
            'ResponseCode_Cs = ""
            'CsMessage = ""
            Dim CXLR_Code As String = "0"
            Dim CXL_Msg As String '= "Buyerpoint Processed"
            Dim PaymentType As String
            Dim PAamount As Double

            If (NormalizeData.Tables(3).Rows.Count > 0) Then
                ' FOR BuyerPoint TRANSACTION ''''UPDATING TABLES

                For K = 0 To NormalizeData.Tables(3).Rows.Count - 1
                    Try

                        StatusResponse = StatusResponse + 1
                        lblStatusResponse.Text = StatusResponse
                        Application.DoEvents()


                        obj.GetExcept = ""
                        ResponseCode_Cs = "0"

                        PaymentType = NormalizeData.Tables(3).Rows(K).Item("ProcessType")

                        CsMessage = "Pay On Account Transaction is Tested Successfully Invoice Will Create"

                        txtBank.Text = CStr(K + 1) & " / " & NormalizeData.Tables(3).Rows.Count

                        'If (NormalizeData.Tables(3).Rows(K).Item("sender") = "IR" Or NormalizeData.Tables(3).Rows(K).Item("sender") = "IN") Then

                        If (NormalizeData.Tables(3).Rows(K).Item("ccstatus") = "Y") Then
                            If ChkLog.Checked = False Then
                                log = ". Update Invoice Status  " & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(K).Item("MerchantID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(K).Item("TrackID") & vbCrLf
                                log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                log = log & ". @CXLCode= " & 100 & vbCrLf
                                log = log & ". @CXLMessage= " & "By BP" & vbCrLf
                                log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(K).Item("ProcessType") & vbCrLf
                                log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(K).Item("OrderID") & vbCrLf
                                log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(K).Item("TrackID") & vbCrLf
                                log = log & ". @Sender= " & NormalizeData.Tables(3).Rows(K).Item("sender") & vbCrLf
                                log = log & ". @CCStatus= " & "Y" & vbCrLf
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)
                                obj.GetExcept = ""
                            End If

                            Dim invPost As New InvoicePost.WalletTransactions
                            PAamount = invPost.GetWalletAmount(NormalizeData.Tables(3).Rows(K).Item("MerchantID"), NormalizeData.Tables(3).Rows(K).Item("CLoginID"))

                            If PAamount > 0 Then
                                SuccessfulCXLFOR_PA(K, CXLR_Code, "Pay On Account Processed")
                            Else
                                DeclineForPA(K, "", "Pay on Account Declined")
                            End If


                        End If

                        'If (NormalizeData.Tables(3).Rows(K).Item("sender") = "IR") Then

                        '    Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(K).Item("MerchantID"), NormalizeData.Tables(3).Rows(K).Item("OrderID"))


                        '    'Infinishop webservice
                        '    Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                        '    info.CustomerID = NormalizeData.Tables(3).Rows(K).Item("Customer_Id")

                        '    If OrderSucess = True Then
                        '        info.IsOrderSuccess = True
                        '    Else
                        '        info.IsOrderSuccess = False
                        '    End If

                        '    info.MerchantID = NormalizeData.Tables(3).Rows(K).Item("MerchantID")
                        '    info.OrderID = NormalizeData.Tables(3).Rows(K).Item("OrderID")
                        '    info.PayMode = Io.InfiniShops.PaymentMode.BP

                        '    If ChkLog.Checked = False Then
                        '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender")
                        '        WriteDebugInfo(log, filename)
                        '    End If
                        '    ObjIo = New Io.InfiniShops.ServiceActivation

                        '    Dim Result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                        '    If ChkLog.Checked = False Then
                        '        log = ". calling their Web service ENABLED SERVICES .ErrorCode= " & Result.ERRORCODE & " ResultDesciption=" & Result.ERRORDESC
                        '        WriteDebugInfo(log, filename)
                        '    End If
                        '    '--------

                        '    'Reseller webservice
                        '    Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail
                        '    Dim count As Integer
                        '    For count = 0 To DataS.Tables(0).Rows.Count - 1
                        '        Product(count) = New com.reseller.webservices.ProductDetail
                        '        Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                        '        Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                        '        Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                        '    Next
                        '    If ChkLog.Checked = False Then
                        '        log = ". calling Web service GETBIZINFO method for(invalid data) For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender") & vbCrLf
                        '        log = log & ". Having Parameters: " & vbCrLf
                        '        log = log & ". @MerchantLoginID= " & NormalizeData.Tables(3).Rows(K).Item("MerchantLoginID") & vbCrLf
                        '        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(K).Item("OrderID") & vbCrLf
                        '        log = log & ". @Customer_id= " & NormalizeData.Tables(3).Rows(K).Item("Customer_id") & vbCrLf
                        '        'log = log & ". @Product= " & Product & vbCrLf
                        '        log = log & ". @PayStatus=" & "Y"
                        '        WriteDebugInfo(log, filename)

                        '    End If

                        '    ' ObjService.GetBizInfo(NormalizeData.Tables(1).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(K).Item("OrderID"), NormalizeData.Tables(1).Rows(K).Item("Customer_id"), Product, "N")
                        '    ResellerService = New com.reseller.webservices.IShopOrderHander
                        '    ResellerService.Timeout = 4 * 60 * 1000
                        '    ResellerService.GetBizInfo(NormalizeData.Tables(3).Rows(K).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), NormalizeData.Tables(3).Rows(K).Item("Customer_id"), Product, "Y")
                        '    '--------


                        'ElseIf (NormalizeData.Tables(3).Rows(K).Item("sender") = "IM") Then

                        '    Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo

                        '    info.CustomerID = NormalizeData.Tables(3).Rows(K).Item("Customer_Id")
                        '    info.IsOrderSuccess = True
                        '    info.MerchantID = NormalizeData.Tables(3).Rows(K).Item("MerchantID")
                        '    info.OrderID = NormalizeData.Tables(3).Rows(K).Item("OrderID")
                        '    info.PayMode = Io.InfiniShops.PaymentMode.BP

                        '    Dim objIShop As New com.infinishops.io.IShopServiceActivation
                        '    Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                        '    If ChkLog.Checked = False Then
                        '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender")
                        '        WriteDebugInfo(log, filename)
                        '    End If

                        'ElseIf (NormalizeData.Tables(3).Rows(K).Item("sender") = "IN") Then

                        '    Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo

                        '    info.CustomerID = NormalizeData.Tables(3).Rows(K).Item("Customer_Id")
                        '    info.IsOrderSuccess = True
                        '    info.MerchantID = NormalizeData.Tables(3).Rows(K).Item("MerchantID")
                        '    info.OrderID = NormalizeData.Tables(3).Rows(K).Item("OrderID")
                        '    info.PayMode = Io.InfiniShops.PaymentMode.BP

                        '    Dim objIShop As New com.infinishops.io.IShopServiceActivation
                        '    Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                        '    If ChkLog.Checked = False Then
                        '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(K).Item("sender")
                        '        WriteDebugInfo(log, filename)
                        '    End If

                        'End If

                        'If ChkLog.Checked = False Then
                        '    log = ". Update Status to sqlserver by SP:CXLROBO_UPDATEDATA_FOR_BP."
                        '    WriteDebugInfo(log, filename)
                        'End If
                        'obj.UpdateResponseForBP(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(3).Rows(K).Item("invoice_no"), NormalizeData.Tables(3).Rows(K).Item("TrackID"))


                    Catch ex As Exception

                        If ChkLog.Checked = False Then
                            log = ". Exception Occured and updating status_atcs=I For PA Transaction . " & ex.Message
                            WriteDebugInfo(log, filename)
                        End If

                        ResponseCode_Cs = "-6"
                        CsMessage = "PA Transaction Can't Processed B/C" & ex.Message

                        SendEmail("Sender = " & NormalizeData.Tables(3).Rows(K).Item("sender") & " OrderID= " & NormalizeData.Tables(3).Rows(K).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(3).Rows(K).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(3).Rows(K).Item("TrackID") & " Exception= " & ex.Message)
                        'DataString = DataString & ex.Message & "BP Function" & obj.GetExcept & vbNewLine
                        LstException.Items.Add(DateTime.Now & " " & ex.Message & "PA Function" & obj.GetExcept)

                        If (NormalizeData.Tables(3).Rows(K).Item("sender") = "AC" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IN" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IR" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IM" Or NormalizeData.Tables(3).Rows(K).Item("Sender") = "IB") Then
                            obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(K).Item("TrackID"), CxlIdentity)
                        Else
                            obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(K).Item("MerchantId"), NormalizeData.Tables(3).Rows(K).Item("CLoginId"), NormalizeData.Tables(3).Rows(K).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(K).Item("TrackID"), CxlIdentity)

                        End If

                    End Try

                Next

            End If
        End Sub
#End Region
#Region ".................... Credit Card Transaction .........................."

        Public Sub CreditCardStatusUpdation()
            Dim CxlR_code, Cxl_Msg As String
            Dim Cs_Msg As String
            Dim j As Integer
            Dim Cs_Status As String

            CxlR_code = ""
            Cxl_Msg = ""
            'CsMessage = ""
            'ResponseCode_Cs = ""

            For j = 0 To NormalizeData.Tables(2).Rows.Count - 1
                Try
                    'obj.GetExcept = ""
                    StatusResponse = StatusResponse + 1
                    lblStatusResponse.Text = StatusResponse
                    Application.DoEvents()

                    If (FwdToCXL = 1) Then
                        txtCredit.Text = CStr(j + 1) & " / " & NormalizeData.Tables(2).Rows.Count
                        ' .....................start Calling CXL WEBSERVICE................"

                        Dim Account As String = NormalizeData.Tables(2).Rows(j).Item("AgentName")

                        If PaymentProcessor <> "" Then
                            Account = UCase(PaymentProcessor)
                        End If

                        'Declined order when VAT is ordered multiple on same date by same credit card number (by Saad 10/03/08)
                        Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("OrderID"))
                        Dim product_id As String = DataS.Tables(0).Rows(0).Item("Product_ID")
                        Dim product_code As String = DataS.Tables(0).Rows(0).Item("prod_code")
                        Dim tempNo As Integer
                        Dim M2prod_code As String
                        Dim dstemp As DataSet

                        log = "product_id: " & product_id & vbCrLf
                        log = log & "product_code: " & product_code & vbCrLf
                        log = log & "Reseller UID: " & MerchantLoginId
                        WriteDebugInfo(log, filename)

                        'Webservice calling
                        Try
                            Dim prod_code_ws As New WindowsGateWayCreditCard.com.infinibiz.webservices.resellerproductcode
                            prod_code_ws.reselleruid = MerchantLoginId
                            prod_code_ws.codes = New String() {product_code}
                            Dim ws_infniBiz As New com.infinibiz.webservices.IBZservices
                            Dim prod_code_ws_ret As WindowsGateWayCreditCard.com.infinibiz.webservices.returnResellerProducts = ws_infniBiz.getResellerM2Product(prod_code_ws)

                            If prod_code_ws_ret.products.Length > 0 Then
                                M2prod_code = prod_code_ws_ret.products(0).code
                            ElseIf prod_code_ws_ret.products.Length = 0 Then
                                M2prod_code = product_code
                            End If

                            log = "M2_product_code: " & M2prod_code
                            WriteDebugInfo(log, filename)

                            If UCase(M2prod_code) = "CP6" Then  'Product Code of VAT Registeration on M2
                                dstemp = obj.RestrictedOrders(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), product_code, EncryptCreditCardNo)
                                tempNo = dstemp.Tables(0).Rows.Count()
                            End If

                        Catch ex As Exception
                            tempNo = 0
                            log = "Exception occurred at Restrict Order: " & ex.Message
                            WriteDebugInfo(log, filename)
                        End Try
                        '////////////////////////////////////////////////////////////////

                        Select Case Account

                            Case "CXL"

                                If (NormalizeData.Tables(2).Rows(j).Item("NoCXL") = "0") Then

                                    If (NormalizeData.Tables(2).Rows(j).Item("Createinvoice") = "Y" Or NormalizeData.Tables(2).Rows(j).Item("Createinvoice") = "y") Then

                                        If ChkLog.Checked = False Then
                                            log = ". Getting Response From CXL WHEN Mode= " & NormalizeData.Tables(2).Rows(j).Item("Mode") & " And BYFORCE Bit is = " & NormalizeData.Tables(2).Rows(j).Item("ByForce") & vbCrLf
                                            log = log & "ECI: " & ECI & vbCrLf
                                            log = log & "XID: " & XID & vbCrLf
                                            log = log & "VTS: " & VTS & vbCrLf
                                            log = log & "VAV: " & VAV & vbCrLf
                                            log = log & "MPI_SESSIONID: " & MPI_SessionID & vbCrLf
                                            log = log & "hn: " & hn & vbCrLf
                                            log = log & "zp: " & zp & vbCrLf
                                            log = log & "callcentre: " & callCentre
                                            WriteDebugInfo(log, filename)
                                        End If

                                        If tempNo = 0 Then

                                            If (NormalizeData.Tables(2).Rows(j).Item("CreditCardNo") = "4444333322221111") Then

                                                CxlR_code = "0"
                                                Cxl_Msg = "Test Card Processed"

                                            ElseIf (NormalizeData.Tables(2).Rows(j).Item("CreditCardNo") = "4111111111111111") Then
                                                CxlR_code = "05"
                                                Cxl_Msg = "Test Card Declined"

                                                'ElseIf (tempNo > 1) Then
                                                '    CxlR_code = "07"
                                                '    Cxl_Msg = "Multiple VAT orders"

                                            ElseIf CallCentreDecline = True And callCentre <> "" And callCentre <> "0" Then
                                                CxlR_code = "92"
                                                Cxl_Msg = "RC: 02/92; NAK"

                                            Else
                                                If (CheckValidParameter(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("IssueNo"), NormalizeData.Tables(2).Rows(j).Item("TransactionAmount"), NormalizeData.Tables(2).Rows(j).Item("GCode"), NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("Customer_ID"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("TransactionType"), NormalizeData.Tables(2).Rows(j).Item("StartDate"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("Mode"), CxlR_code, Cxl_Msg, NormalizeData.Tables(2).Rows(j).Item("AgentName"), NormalizeData.Tables(2).Rows(j).Item("AgentAcquirer"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), NormalizeData.Tables(2).Rows(j).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(j).Item("CLoginID"), NormalizeData.Tables(2).Rows(j).Item("Sender"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode")) = True) Then
                                                    obj.GETRESPONSEFROMCXL(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("IssueNo"), NormalizeData.Tables(2).Rows(j).Item("TransactionAmount"), NormalizeData.Tables(2).Rows(j).Item("GCode"), NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("Customer_ID"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("TransactionType"), NormalizeData.Tables(2).Rows(j).Item("StartDate"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("Mode"), CxlR_code, Cxl_Msg, NormalizeData.Tables(2).Rows(j).Item("AgentName"), NormalizeData.Tables(2).Rows(j).Item("AgentAcquirer"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), NormalizeData.Tables(2).Rows(j).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(j).Item("CLoginID"), NormalizeData.Tables(2).Rows(j).Item("Sender"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("CardName"), ECI, XID, VTS, VAV, MPI_SessionID, hn, zp, callCentre)
                                                End If
                                            End If

                                        Else
                                            CxlR_code = "07"
                                            Cxl_Msg = "Multiple VAT orders"

                                        End If

                                        CxlR_code = Trim(CxlR_code)

                                        If (CxlR_code = "30" And Cxl_Msg = "UNKNOWN MERCHANT") Then
                                            Dim newAgent As String
                                            newAgent = NormalizeData.Tables(2).Rows(j).Item("AgentAcquirer")
                                            If (newAgent = "STREAMLINE") Then
                                                newAgent = "AMERICAN EXPRESS"
                                            ElseIf (newAgent = "AMERICAN EXPRESS") Then

                                                newAgent = "STREAMLINE"
                                            End If
                                            If ChkLog.Checked = False Then
                                                log = ". Getting Response WHEN UNKNOWN MERCHANT From CXL WHEN Mode= " & NormalizeData.Tables(2).Rows(j).Item("Mode") & " And BYFORCE Bit is = " & NormalizeData.Tables(2).Rows(j).Item("ByForce") & vbCrLf
                                                log = log & "ECI: " & ECI & vbCrLf
                                                log = log & "XID: " & XID & vbCrLf
                                                log = log & "VTS: " & VTS & vbCrLf
                                                log = log & "VAV: " & VAV & vbCrLf
                                                log = log & "MPI_SESSIONID: " & MPI_SessionID & vbCrLf
                                                log = log & "hn: " & hn & vbCrLf
                                                log = log & "zp: " & zp & vbCrLf
                                                log = log & "callcentre: " & callCentre
                                                WriteDebugInfo(log, filename)
                                            End If
                                            obj.GETRESPONSEFROMCXL(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("IssueNo"), NormalizeData.Tables(2).Rows(j).Item("TransactionAmount"), NormalizeData.Tables(2).Rows(j).Item("GCode"), NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("Customer_ID"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("TransactionType"), NormalizeData.Tables(2).Rows(j).Item("StartDate"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("Mode"), CxlR_code, Cxl_Msg, NormalizeData.Tables(2).Rows(j).Item("AgentName"), newAgent, NormalizeData.Tables(2).Rows(j).Item("TrackID"), NormalizeData.Tables(2).Rows(j).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(j).Item("CLoginID"), NormalizeData.Tables(2).Rows(j).Item("Sender"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("CardName"), ECI, XID, VTS, VAV, MPI_SessionID, hn, zp)
                                        End If


                                        If (NormalizeData.Tables(2).Rows(j).Item("Mode") = "TEST" And NormalizeData.Tables(2).Rows(j).Item("CreditCardNo") = "4444333344441010") Then
                                            If ChkLog.Checked = False Then
                                                log = ". Getting Response From CXL WHEN Test Mode . "
                                                WriteDebugInfo(log, filename)
                                            End If
                                            CxlR_code = "0"
                                            Cxl_Msg = "Test Card Processed Mode is Test"

                                            CxlR_code = Trim(CxlR_code)
                                        End If
                                    Else
                                        ' Exit Sub
                                        If (NormalizeData.Tables(2).Rows(j).Item("ccstatus") = "Y") Then ' that means full payment
                                            If ChkLog.Checked = False Then
                                                log = ". Update Invoice Status of CreditCard " & vbCrLf
                                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                                log = log & ". Having Parameters: " & vbCrLf
                                                log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                                log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(j).Item("ProcessType") & vbCrLf
                                                log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf

                                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                                log = log & ". Having Parameters: " & vbCrLf
                                                log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                                                log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                log = log & ". @Sender= " & NormalizeData.Tables(2).Rows(j).Item("sender") & vbCrLf
                                                log = log & ". @CCStatus= " & "N" & vbCrLf
                                                log = log & ". Except:" & obj.GetExcept
                                                WriteDebugInfo(log, filename)
                                                obj.GetExcept = ""
                                            End If
                                            obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), "*", CxlR_code, "CreateInvoice(NO)", NormalizeData.Tables(2).Rows(j).Item("ProcessType"), NormalizeData.Tables(2).Rows(j).Item("OrderID"))
                                            obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "CreateInvoice(NO)", CxlR_code, NormalizeData.Tables(2).Rows(j).Item("trackid"), NormalizeData.Tables(2).Rows(j).Item("sender"), "N")

                                        Else
                                            If ChkLog.Checked = False Then
                                                log = ". Update Invoice Status of CreditCard " & vbCrLf
                                                log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                                log = log & ". Having Parameters: " & vbCrLf
                                                log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                                log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(j).Item("ProcessType") & vbCrLf
                                                log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf

                                                log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                                log = log & ". Having Parameters: " & vbCrLf
                                                log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                                                log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                log = log & ". @Sender= " & NormalizeData.Tables(2).Rows(j).Item("sender") & vbCrLf
                                                log = log & ". @CCStatus= " & "N" & vbCrLf
                                                log = log & ". Except:" & obj.GetExcept
                                                WriteDebugInfo(log, filename)
                                                obj.GetExcept = ""
                                            End If
                                            obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), "P", CxlR_code, "CreateInvoice(NO)", NormalizeData.Tables(2).Rows(j).Item("ProcessType"), NormalizeData.Tables(2).Rows(j).Item("OrderID"))
                                            obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "CreateInvoice(NO)", CxlR_code, NormalizeData.Tables(2).Rows(j).Item("trackid"), NormalizeData.Tables(2).Rows(j).Item("sender"), "N")

                                        End If

                                        '' UPDATE  RESPONSE
                                        If ChkLog.Checked = False Then
                                            log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA For Create INVOICE = N case(CXL) "
                                            WriteDebugInfo(log, filename)
                                        End If
                                        CsMessage = "Invoice will not create"
                                        ResponseCode_Cs = "-7"
                                        CxlR_code = "-200"
                                        Cxl_Msg = "Invoice will not create"
                                        obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_code, Cxl_Msg)

                                    End If

                                    'Else
                                    '    If ChkLog.Checked = False Then
                                    '        log = ". Getting Response From PAYPAL WHEN TEST Mode  But BYFORCE BIT IS N (CXL). "
                                    '        WriteDebugInfo(log, filename)
                                    '    End If

                                    '    CxlR_code = "0"
                                    '    Cxl_Msg = "Credit Card is Processed Successfully in Test Mode (Assume)"

                                    'End If

                                Else
                                    If ChkLog.Checked = False Then
                                        log = ". NOT FORWARD TO CXL (WHEN NO CXL Bit is 1)(CXL) "
                                        WriteDebugInfo(log, filename)
                                    End If

                                    CxlR_code = "0"
                                    Cxl_Msg = "Credit Card is Processed Successfully NoCXL bit=1"

                                End If

                                '  CxlR_code = "-31"
                                txtCxlCode.Text = CxlR_code

                                'CxlR_code = "0"
                                'Cxl_Msg = "Credit Card is Processed Successfully"

                            Case "PP"
                                ''' Case pay pal
                                '
                                ' check is certificate installed or not
                                ' if not then call certificate installed method other wise direct call pay
                                'pal webservice

                                '''''''''

                                ''''''''''''Pay pal Environment '''''''''''''''''
                                Dim dsmerchantPaypal As DataSet = obj.GetmerchantInfoPaypal(NormalizeData.Tables(2).Rows(j).Item("MerchantLoginId"))
                                Dim paypalEnvironmant As String = ""
                                Dim paypalEnvironmantType As String = ""

                                log = ". Getting Merchant Info. for paypal "
                                log = log & ". Except:" & obj.GetExcept
                                WriteDebugInfo(log, filename)

                                If dsmerchantPaypal.Tables(0).Rows.Count > 0 Then
                                    paypalEnvironmant = dsmerchantPaypal.Tables(0).Rows(0).Item("PayPalEnvironment")
                                    log = ". Pay Pal Environment for Merchant UID :" & NormalizeData.Tables(2).Rows(j).Item("MerchantLoginId") & " is " & paypalEnvironmant & vbCrLf
                                End If

                                If paypalEnvironmant = "True" Then
                                    paypalEnvironmantType = "Live"
                                Else
                                    paypalEnvironmantType = "sandbox"
                                End If

                                log = log & ". Pay Pal Environment :" & paypalEnvironmantType
                                WriteDebugInfo(log, filename)
                                ''''''''''''''''''''''''''''''


                                If (NormalizeData.Tables(2).Rows(j).Item("NoCXL") = "0") Then

                                    If (NormalizeData.Tables(2).Rows(j).Item("ByForce") = "N") Then

                                        If (NormalizeData.Tables(2).Rows(j).Item("Createinvoice") = "Y" Or NormalizeData.Tables(2).Rows(j).Item("Createinvoice") = "y") Then

                                            If (NormalizeData.Tables(2).Rows(j).Item("Mode") = "TEST" And NormalizeData.Tables(2).Rows(j).Item("CreditCardNo") = "4444333344441010") Then
                                                If ChkLog.Checked = False Then
                                                    log = ". Getting Data For PAYPAL From Merchant Table WHEN Test Mode And BYFORCE Bit is " & NormalizeData.Tables(2).Rows(j).Item("ByForce")
                                                    WriteDebugInfo(log, filename)
                                                End If

                                                CxlR_code = "0"
                                                Cxl_Msg = "PayPal Test Card Processed Mode is Test"

                                                ' check is certificate installed or not
                                                ' if not then call certificate installed method other wise direct call pay
                                                ' pal webservice

                                                'Dim IsInstalled As String

                                                'Dim P_P_Password As String

                                                'P_P_Password = obj.GetPassword(NormalizeData.Tables(2).Rows(j).Item("MerchantID"))

                                                'Dim PayPalCert As String
                                                'PayPalCert = NormalizeData.Tables(2).Rows(j).Item("PayPalCertificate")
                                                'Dim Reader(PayPalCert.Length - 1) As Byte

                                                'Reader = Encoding.UTF8.GetBytes(PayPalCert)

                                                'If (objPayPal.ISCertInstalled(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, "sandbox") <> 1) Then
                                                '    IsInstalled = objPayPal.InstallCertificate(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, reader)

                                                '    If (IsInstalled = "1") Then

                                                '        obj.GETRESPONSEFROMPAYPAL(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, "sandbox", NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("Amount"), NormalizeData.Tables(2).Rows(j).Item("CurrencyCode"), CxlR_code, Cxl_Msg)
                                                '    Else
                                                '        CxlR_code = "-10"
                                                '        Cxl_Msg = "Credit Card is Declined Because Certificate is not Installed"
                                                '    End If
                                                'Else
                                                '    obj.GETRESPONSEFROMPAYPAL(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, "sandbox", NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("Amount"), NormalizeData.Tables(2).Rows(j).Item("CurrencyCode"), CxlR_code, Cxl_Msg)

                                                'End If

                                                CxlR_code = Trim(CxlR_code)
                                            Else
                                                If ChkLog.Checked = False Then
                                                    log = ". Getting DATA For PAYPAL From Merchant Table WHEN Live Mode And BYFORCE Bit is YES. "
                                                    WriteDebugInfo(log, filename)
                                                End If

                                                Dim IsInstalled As String

                                                Dim P_P_Password As String

                                                P_P_Password = obj.GetPassword(NormalizeData.Tables(2).Rows(j).Item("MerchantID"))

                                                Dim PayPalCert As String
                                                PayPalCert = NormalizeData.Tables(2).Rows(j).Item("PayPalCertificate")
                                                Dim Reader(PayPalCert.Length - 1) As Byte

                                                Reader = Encoding.UTF8.GetBytes(PayPalCert)
                                                objPayPal = New InfiniPayPal.InfiniPayPalWebService

                                                If ChkLog.Checked = False Then
                                                    log = ". Calling PAYPAL ISCERTIFICATEINSTALLED routine. "
                                                    WriteDebugInfo(log, filename)
                                                End If

                                                If (objPayPal.ISCertInstalled(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, paypalEnvironmantType) <> 1) Then
                                                    If ChkLog.Checked = False Then
                                                        log = ". Calling PAYPAL INSTALLCERTIFICATE routine. "
                                                        WriteDebugInfo(log, filename)
                                                    End If
                                                    IsInstalled = objPayPal.InstallCertificate(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, Reader)

                                                    If ChkLog.Checked = False Then
                                                        log = ". End PAYPAL INSTALLCERTIFICATE routine. Response bit Isinstalled is = " & IsInstalled
                                                        WriteDebugInfo(log, filename)
                                                    End If

                                                    If (IsInstalled = "1") Then

                                                        If ChkLog.Checked = False Then
                                                            log = ". Calling PAYPAL MAKETRANSACTION routine. Parameters Are:" & vbCrLf
                                                            log = log & "@PAYPALID = " & NormalizeData.Tables(2).Rows(j).Item("PayPalID") & vbCrLf
                                                            log = log & "@Password = " & Len(P_P_Password) & vbCrLf
                                                            log = log & "@CreditCardNo = " & Len(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo")) & vbCrLf
                                                            log = log & "@CardType" & NormalizeData.Tables(2).Rows(j).Item("CardType") & vbCrLf
                                                            log = log & "@SecurityCode = " & NormalizeData.Tables(2).Rows(j).Item("SecurityCode") & vbCrLf
                                                            log = log & "@CardExpiry = " & NormalizeData.Tables(2).Rows(j).Item("CardExpiry") & vbCrLf
                                                            log = log & "@Amount" & NormalizeData.Tables(2).Rows(j).Item("Amount") & vbCrLf
                                                            log = log & "@CurrencyCode = " & NormalizeData.Tables(2).Rows(j).Item("CurrencyCode") & vbCrLf
                                                            log = log & "@MerchantID" & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf

                                                            log = log & "@OrderID = " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                                                            log = log & "@TrackID" & NormalizeData.Tables(2).Rows(j).Item("TrackID")
                                                            WriteDebugInfo(log, filename)
                                                        End If
                                                        obj.GETRESPONSEFROMPAYPAL(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, paypalEnvironmantType, NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("Amount"), NormalizeData.Tables(2).Rows(j).Item("CurrencyCode"), NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlR_code, Cxl_Msg)
                                                    Else
                                                        CxlR_code = "-10"
                                                        Cxl_Msg = "Credit Card is Declined Because Certificate is not Installed"
                                                    End If

                                                Else
                                                    If ChkLog.Checked = False Then
                                                        log = ". Calling PAYPAL MAKETRANSACTION routine. Parameters Are:" & vbCrLf
                                                        log = log & "@PAYPALID = " & NormalizeData.Tables(2).Rows(j).Item("PayPalID") & vbCrLf
                                                        log = log & "@Password = " & Len(P_P_Password) & vbCrLf
                                                        log = log & "@CreditCardNo = " & Len(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo")) & vbCrLf
                                                        log = log & "@CardType= " & NormalizeData.Tables(2).Rows(j).Item("CardType") & vbCrLf
                                                        log = log & "@SecurityCode = " & NormalizeData.Tables(2).Rows(j).Item("SecurityCode") & vbCrLf
                                                        log = log & "@CardExpiry = " & NormalizeData.Tables(2).Rows(j).Item("CardExpiry") & vbCrLf
                                                        log = log & "@Amount= " & NormalizeData.Tables(2).Rows(j).Item("Amount") & vbCrLf
                                                        log = log & "@CurrencyCode = " & NormalizeData.Tables(2).Rows(j).Item("CurrencyCode") & vbCrLf
                                                        log = log & "@MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf

                                                        log = log & "@OrderID = " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                                                        log = log & "@TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID")
                                                        WriteDebugInfo(log, filename)
                                                    End If

                                                    obj.GETRESPONSEFROMPAYPAL(NormalizeData.Tables(2).Rows(j).Item("PayPalID"), P_P_Password, paypalEnvironmantType, NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("Amount"), NormalizeData.Tables(2).Rows(j).Item("CurrencyCode"), NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlR_code, Cxl_Msg)
                                                    'CxlR_code = "0"
                                                    'Cxl_Msg = "Transaction processed successfully."
                                                End If

                                                CxlR_code = Trim(CxlR_code)
                                            End If
                                        Else

                                            If (NormalizeData.Tables(2).Rows(j).Item("ccstatus") = "Y") Then ' that means full payment
                                                If ChkLog.Checked = False Then
                                                    log = ". Update Invoice Status of CreditCard " & vbCrLf
                                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                                    log = log & ". Having Parameters: " & vbCrLf
                                                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                    log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                                    log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                    log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                    log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(j).Item("ProcessType") & vbCrLf
                                                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf

                                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                                    log = log & ". Having Parameters: " & vbCrLf
                                                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                                                    log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                    log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                    log = log & ". @Sender= " & NormalizeData.Tables(2).Rows(j).Item("sender") & vbCrLf
                                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                                    log = log & ". Except:" & obj.GetExcept
                                                    WriteDebugInfo(log, filename)
                                                    obj.GetExcept = ""
                                                End If
                                                obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), "*", CxlR_code, "CreateInvoice(NO)", NormalizeData.Tables(2).Rows(j).Item("ProcessType"), NormalizeData.Tables(2).Rows(j).Item("OrderID"))
                                                obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "CreateInvoice(NO)", CxlR_code, NormalizeData.Tables(2).Rows(j).Item("trackid"), NormalizeData.Tables(2).Rows(j).Item("sender"), "N")

                                            Else
                                                If ChkLog.Checked = False Then
                                                    log = ". Update Invoice Status of CreditCard " & vbCrLf
                                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                                    log = log & ". Having Parameters: " & vbCrLf
                                                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                    log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                                    log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                    log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                    log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(j).Item("ProcessType") & vbCrLf
                                                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf

                                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                                    log = log & ". Having Parameters: " & vbCrLf
                                                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                                                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                                                    log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                                    log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                                                    log = log & ". @Sender= " & NormalizeData.Tables(2).Rows(j).Item("sender") & vbCrLf
                                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                                    log = log & ". Except:" & obj.GetExcept
                                                    WriteDebugInfo(log, filename)
                                                    obj.GetExcept = ""
                                                End If
                                                obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), "P", CxlR_code, "CreateInvoice(NO)", NormalizeData.Tables(2).Rows(j).Item("ProcessType"), NormalizeData.Tables(2).Rows(j).Item("OrderID"))
                                                obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "CreateInvoice(NO)", CxlR_code, NormalizeData.Tables(2).Rows(j).Item("trackid"), NormalizeData.Tables(2).Rows(j).Item("sender"), "N")

                                            End If

                                            '' UPDATE  RESPONSE
                                            If ChkLog.Checked = False Then
                                                log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA For Create INVOICE = N case(PAYPAL) "
                                                WriteDebugInfo(log, filename)
                                            End If
                                            CsMessage = "Invoice will not create"
                                            ResponseCode_Cs = "-7"
                                            CxlR_code = "-200"
                                            Cxl_Msg = "Invoice will not create"
                                            obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_code, Cxl_Msg)

                                        End If

                                    Else
                                        If ChkLog.Checked = False Then
                                            log = ". Getting Response From PAYPAL WHEN TEST Mode  But BYFORCE BIT IS N (PAYPAL). "
                                            WriteDebugInfo(log, filename)
                                        End If

                                        CxlR_code = "0"
                                        Cxl_Msg = "Credit Card is Processed Successfully in Test Mode (Assume)"

                                    End If

                                Else
                                    If ChkLog.Checked = False Then
                                        log = ". NOT FORWARD TO PAYPAL (WHEN NO CXL Bit is 1)(PAYPAL) "
                                        WriteDebugInfo(log, filename)
                                    End If

                                    CxlR_code = "0"
                                    Cxl_Msg = "Credit Card is Processed Successfully NoCXL bit=1"

                                End If

                                txtCxlCode.Text = CxlR_code
                        End Select

                        'CxlR_code = "0" '''''' forcefully
                        'Cxl_Msg = "Credit Card is Processed Successfully in Test Mode (Assume)"

                        ''''''''''''''''''''............................ end  Calling CXL WEBSERVICE ..........."
                        CxlR_code = Trim(CxlR_code)

                        If ChkLog.Checked = False Then
                            log = ". CXL CODE" & CxlR_code & "CXL RESPONSE " & Cxl_Msg
                            WriteDebugInfo(log, filename)
                        End If

                        ' here first get the logkey from respective MCKEY table of the merchant 
                        ' then pass it to updatecreditcarddetail function as a @Salt parameter

                        Dim Key As String
                        Key = obj.GetMCKEY(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("Customer_ID"))

                        If ChkLog.Checked = False Then
                            log = ". Update Credit Card Details by SP:CAM_CreditCardDetails. "
                            log = ". Update Credit Card Details by SP:UpdateCreditCardDetailAndCXLMsgInInvoice. "
                            log = log & ". Having Parameters: " & vbCrLf
                            log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                            log = log & ". @Customer_ID= " & NormalizeData.Tables(2).Rows(j).Item("Customer_ID") & vbCrLf
                            log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & vbCrLf
                            log = log & ". @Cxl_Msg= " & Cxl_Msg & vbCrLf
                            log = log & ". @Account= " & Account & vbCrLf
                            log = log & ". @CreditCardNo= " & Len(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo")) & vbCrLf
                            log = log & ". @CardName= " & NormalizeData.Tables(2).Rows(j).Item("CardName") & vbCrLf
                            log = log & ". @CardType= " & NormalizeData.Tables(2).Rows(j).Item("CardType") & vbCrLf
                            log = log & ". @CardExpiry= " & NormalizeData.Tables(2).Rows(j).Item("CardExpiry") & vbCrLf
                            log = log & ". @CardAddress= " & NormalizeData.Tables(2).Rows(j).Item("CardAddress") & vbCrLf
                            log = log & ". @TranStatus= " & NormalizeData.Tables(2).Rows(j).Item("TranStatus") & vbCrLf
                            log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                            log = log & ". @SecurityCode= " & NormalizeData.Tables(2).Rows(j).Item("SecurityCode") & vbCrLf
                            log = log & ". @StartDate= " & NormalizeData.Tables(2).Rows(j).Item("StartDate") & vbCrLf
                            log = log & ". @EndDate= " & NormalizeData.Tables(2).Rows(j).Item("EndDate") & vbCrLf
                            log = log & ". @IssueNo= " & NormalizeData.Tables(2).Rows(j).Item("IssueNo") & vbCrLf
                            log = log & ". @Key= " & Key
                            WriteDebugInfo(log, filename)
                        End If
                        obj.UpdateCreditCardDetail(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("Customer_ID"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), Cxl_Msg, NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("CardName"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("CardAddress"), NormalizeData.Tables(2).Rows(j).Item("TranStatus"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("StartDate"), NormalizeData.Tables(2).Rows(j).Item("EndDate"), NormalizeData.Tables(2).Rows(j).Item("IssueNo"), Key)

                        If ChkLog.Checked = False Then
                            log = ". Update Credit Card Details by SP:UpdateCreditCardDetailAndCXLMsgInInvoice. "
                            log = log & ". Having Parameters: " & vbCrLf
                            log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantID") & vbCrLf
                            log = log & ". @Customer_ID= " & NormalizeData.Tables(2).Rows(j).Item("Customer_ID") & vbCrLf
                            log = log & ". @Cxl_Msg= " & Cxl_Msg & vbCrLf
                            log = log & ". @Account= " & Account & vbCrLf
                            log = log & ". @CreditCardNo= " & Len(NormalizeData.Tables(2).Rows(j).Item("CreditCardNo")) & vbCrLf
                            log = log & ". @CardName= " & NormalizeData.Tables(2).Rows(j).Item("CardName") & vbCrLf
                            log = log & ". @CardType= " & NormalizeData.Tables(2).Rows(j).Item("CardType") & vbCrLf
                            log = log & ". @CardExpiry= " & NormalizeData.Tables(2).Rows(j).Item("CardExpiry") & vbCrLf
                            log = log & ". @CardAddress= " & NormalizeData.Tables(2).Rows(j).Item("CardAddress") & vbCrLf
                            log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & vbCrLf
                            log = log & ". @SecurityCode= " & NormalizeData.Tables(2).Rows(j).Item("SecurityCode") & vbCrLf
                            log = log & ". @StartDate= " & NormalizeData.Tables(2).Rows(j).Item("StartDate") & vbCrLf
                            log = log & ". @EndDate= " & NormalizeData.Tables(2).Rows(j).Item("EndDate") & vbCrLf
                            log = log & ". @IssueNo= " & NormalizeData.Tables(2).Rows(j).Item("IssueNo") & vbCrLf
                            log = log & ". @Key= " & Key & vbCrLf
                            log = log & ". @CurrencyCode= " & NormalizeData.Tables(2).Rows(j).Item("CurrencyCode") & vbCrLf
                            log = log & ". @GCode= " & NormalizeData.Tables(2).Rows(j).Item("GCode")
                            WriteDebugInfo(log, filename)
                        End If

                        Dim CXL_Digit As String
                        Dim splitter() As String

                        'Cxl_Msg = """AUTH CODE:050237"" ,vid =3 , currency=826,AVS:200800 ,DELT"
                        'Cxl_Msg = "4PD67976VJ457042A Success"

                        If Account = "CXL" Then
                            CXL_Digit = Replace(Cxl_Msg, """AUTH CODE:", "")
                            splitter = CXL_Digit.Split("""")
                        ElseIf Account = "PP" Then
                            CXL_Digit = Cxl_Msg
                            splitter = CXL_Digit.Split(" ")
                        End If

                        CXL_Digit = splitter(0)
                        obj.UpdateDetailAndCXLMsgInInvoice(NormalizeData.Tables(2).Rows(j).Item("MerchantID"), NormalizeData.Tables(2).Rows(j).Item("Customer_ID"), CXL_Digit, NormalizeData.Tables(2).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(2).Rows(j).Item("CardName"), NormalizeData.Tables(2).Rows(j).Item("CardType"), NormalizeData.Tables(2).Rows(j).Item("CardExpiry"), NormalizeData.Tables(2).Rows(j).Item("CardAddress"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), NormalizeData.Tables(2).Rows(j).Item("SecurityCode"), NormalizeData.Tables(2).Rows(j).Item("StartDate"), NormalizeData.Tables(2).Rows(j).Item("EndDate"), NormalizeData.Tables(2).Rows(j).Item("IssueNo"), Key, NormalizeData.Tables(2).Rows(j).Item("CurrencyCode"), NormalizeData.Tables(2).Rows(j).Item("GCode"), Account)

                        Dim IsOrderSuccess As Boolean = False
                        If ChkLog.Checked = False Then
                            log = ".  Calling Routine on the basis of CXLCODE =" & CxlR_code
                            log = log & ". Except:" & obj.GetExcept
                            WriteDebugInfo(log, filename)
                            obj.GetExcept = ""
                        End If
                        If (CxlR_code = "0" Or CxlR_code = "00") Then ' CXLR_CODE="0" means Succesfull Transaction

                            If ChkLog.Checked = False Then
                                log = ". For Successful Response From CXL . "
                                WriteDebugInfo(log, filename)
                            End If
                            SuccessfulCXL(j, CxlR_code, Cxl_Msg)
                            IsOrderSuccess = True

                        ElseIf (InStr(UCase(Cxl_Msg), "BAD FORMAT") > 0 And MPI_SessionID <> "") Then  'Suspend Order by if MPI CXL
                            If ChkLog.Checked = False Then
                                log = ". For Suspend Orders From CXL "
                                WriteDebugInfo(log, filename)
                            End If
                            Suspend(j, CxlR_code, Cxl_Msg)

                        ElseIf (CxlR_code = "-1") Then  'Declined the Order by CXL
                            If ChkLog.Checked = False Then
                                log = ". For UnSuccessful/Decline Response From CXL . "
                                WriteDebugInfo(log, filename)
                            End If
                            Decline(j, CxlR_code, Cxl_Msg)

                        ElseIf (CxlR_code = "-2") Then  'Invalid parameter passing
                            If ChkLog.Checked = False Then
                                log = ". For UnSuccessful Response From CXL Parameter Missing . "
                                WriteDebugInfo(log, filename)
                            End If
                            ParameterMissing(j, CxlR_code, Cxl_Msg)

                        ElseIf (CxlR_code = "-31") Then  'Eith Server Down

                            '' check CXL Service is Down or up
                            If (obj.IsCXLUp() = "LIVE" Or obj.IsCXLUp() = "Live" Or obj.IsCXLUp() = "live") Then
                                If ChkLog.Checked = False Then
                                    log = ". For Un Successful Response From CXL (Server Error) Email Sending. "
                                    WriteDebugInfo(log, filename)
                                End If
                                SendEmail(" Sender = " & NormalizeData.Tables(2).Rows(j).Item("sender") & " Merchant ID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantId") & " OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(2).Rows(j).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & " Cxl Code = " & CxlR_code, "Please Investigate CXL Order (Local Server)  Eith Server Down @ Time: ")
                            Else

                                If ChkLog.Checked = False Then
                                    log = ". For Un Successful Response From CXL (Server Error) Retries. "
                                    WriteDebugInfo(log, filename)
                                End If
                                'FwdToCXL = 0 '' Retries
                            End If


                        ElseIf (CxlR_code = "-32") Then  'Cxl Receive the request but didn't respond

                            If ChkLog.Checked = False Then
                                log = ". For Un Successful Response From CXL (Cxl Receive the request but didn't respond). "
                                WriteDebugInfo(log, filename)
                            End If
                            SendEmail(" Sender = " & NormalizeData.Tables(2).Rows(j).Item("sender") & " Merchant ID= " & NormalizeData.Tables(2).Rows(j).Item("MerchantId") & " OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(2).Rows(j).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & " Cxl Code = " & CxlR_code, "Please Investigate CXL Order (Local Server) Cxl Receive the request but didn't respond @ Time: ")
                            obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "P", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_code, Cxl_Msg)


                        ElseIf (CxlR_code = "") Then

                            obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "P", CsMessage, "-11", 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_code, Cxl_Msg)

                            If (NormalizeData.Tables(2).Rows(j).Item("sender") = "FH") Then
                                If ChkLog.Checked = False Then
                                    'log = log & vbNewLine & Now & ".Update my sql status . "
                                    log = ". Update my sql status . "
                                    WriteDebugInfo(log, filename)
                                End If
                                UpdateMySqlStatus(NormalizeData.Tables(2).Rows(j).Item("CloginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), CxlR_code, Cxl_Msg, CsMessage, NormalizeData.Tables(2).Rows(j).Item("TrackID"), "P", "-11")
                            End If

                        Else
                            Decline(j, CxlR_code, Cxl_Msg)
                        End If

                        'Following code was added by M. Furqan Khan on 03 FEB 2009
                        With NormalizeData.Tables(2).Rows(j)
                            PostCallBackData(.Item("MerchantId"), .Item("OrderID"), .Item("GCode"), .Item("Amount"), .Item("TrackID"), IsOrderSuccess, False)
                        End With
                    Else
                        ' If (WaitForServer = 240) Then 'Here time is activated each after 5 sec so v retry the order each after 10mins i.e 5*2400=1200 sec=20 mins
                        If (WaitForServer = 240) Then
                            FwdToCXL = 1
                            WaitForServer = 1
                            pic4.BackColor = Color.Gray

                        Else
                            WaitForServer = WaitForServer + 1  '240 times it run
                            pic4.BackColor = Color.BlueViolet
                        End If

                        log = log & "Order NOT PROCESSED, FwdToCXL :" & FwdToCXL
                        WriteDebugInfo(log, filename)

                    End If

                Catch ex As Exception
                    If ChkLog.Checked = False Then
                        log = ". Exception Occured and updating status_atcs=I For Credit Card Transaction . " & ex.Message
                        WriteDebugInfo(log, filename)
                        log = "Trace = " & ex.StackTrace
                        WriteDebugInfo(log, filename)
                    End If

                    ResponseCode_Cs = "-6"    ' Credit card not posted to cxl bcoz of any failure
                    CsMessage = "Transaction is Not Forwarded to CXL B/C" & ex.Message

                    SendEmail("Sender = " & NormalizeData.Tables(2).Rows(j).Item("sender") & " OrderID= " & NormalizeData.Tables(2).Rows(j).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(2).Rows(j).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(2).Rows(j).Item("TrackID") & " Exception= " & ex.Message)
                    DataString = DataString & ex.Message & "CreditCard Function" & obj.GetExcept & vbNewLine
                    LstException.Items.Add(DateTime.Now & " " & ex.Message & "CreditCard Function" & obj.GetExcept)

                    If (NormalizeData.Tables(2).Rows(j).Item("sender") = "PR" Or NormalizeData.Tables(2).Rows(j).Item("Sender") = "EX") Then
                        obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, NormalizeData.Tables(2).Rows(j).Item("invoice_no"), NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID)
                    ElseIf (NormalizeData.Tables(2).Rows(j).Item("sender") = "FH") Then
                        UpdateMySqlStatus(NormalizeData.Tables(2).Rows(j).Item("CloginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), CxlR_code, Cxl_Msg, CsMessage, NormalizeData.Tables(2).Rows(j).Item("TrackID"), "I", ResponseCode_Cs)
                        obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID)

                    ElseIf (NormalizeData.Tables(2).Rows(j).Item("sender") = "AC" Or NormalizeData.Tables(2).Rows(j).Item("Sender") = "IN" Or NormalizeData.Tables(2).Rows(j).Item("Sender") = "IR" Or NormalizeData.Tables(2).Rows(j).Item("Sender") = "IM" Or NormalizeData.Tables(2).Rows(j).Item("Sender") = "IB") Then
                        obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID)

                    Else
                        obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(j).Item("MerchantId"), NormalizeData.Tables(2).Rows(j).Item("CLoginId"), NormalizeData.Tables(2).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID)

                    End If

                End Try

            Next

        End Sub

        Public Sub PayOnCreditStatusUpdation()
            Dim CxlR_code, Cxl_Msg As String
            Dim Cs_Msg As String
            Dim j As Integer
            Dim Cs_Status As String

            CxlR_code = ""
            Cxl_Msg = ""
            'CsMessage = ""
            'ResponseCode_Cs = ""

            For j = 0 To NormalizeData.Tables(4).Rows.Count - 1

                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

                Try
                    obj.GetExcept = ""
                    txtCredit.Text = CStr(j + 1) & " / " & NormalizeData.Tables(2).Rows.Count
                    ' .....................start Calling CXL WEBSERVICE................"

                    Dim Account As String = NormalizeData.Tables(4).Rows(j).Item("AgentName")
                    If PaymentProcessor <> "" Then
                        Account = UCase(PaymentProcessor)
                    End If

                    Dim DataS As DataSet
                    DataS = obj.GetOrderDetail(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), NormalizeData.Tables(4).Rows(j).Item("OrderID"))

                    Dim product_id As String = DataS.Tables(0).Rows(0).Item("Product_ID")
                    Dim product_code As String = DataS.Tables(0).Rows(0).Item("prod_code")
                    Dim tempNo As Integer
                    Dim M2prod_code As String
                    Dim dstemp As DataSet

                    'Webservice calling
                    Try
                        Dim prod_code_ws As New WindowsGateWayCreditCard.com.infinibiz.webservices.resellerproductcode
                        prod_code_ws.reselleruid = MerchantLoginId
                        prod_code_ws.codes = New String() {product_code}
                        Dim ws_infniBiz As New com.infinibiz.webservices.IBZservices
                        Dim prod_code_ws_ret As WindowsGateWayCreditCard.com.infinibiz.webservices.returnResellerProducts = ws_infniBiz.getResellerM2Product(prod_code_ws)

                        If prod_code_ws_ret.products.Length > 0 Then
                            M2prod_code = prod_code_ws_ret.products(0).code
                        ElseIf prod_code_ws_ret.products.Length = 0 Then
                            M2prod_code = product_code
                        End If

                        If M2prod_code = "CP6" Then 'Product Code of VAT Registeration on M2
                            dstemp = obj.RestrictedOrders(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), product_code, EncryptCreditCardNo)
                            tempNo = dstemp.Tables(0).Rows.Count()
                        End If

                    Catch ex As Exception
                        tempNo = 0
                        log = "Exception occurred at Restrict Order: " & ex.Message
                        WriteDebugInfo(log, filename)
                    End Try
                    '////////////////////////////////////////////////////////////////


                    Select Case Account
                        Case "CXL"

                            If (NormalizeData.Tables(4).Rows(j).Item("NoCXL") = "0") Then

                                CxlR_code = "0"
                                Cxl_Msg = "Pay on Credit Processing"

                                If ChkLog.Checked = False Then
                                    log = ". CxlR_code= " & CxlR_code & vbCrLf
                                    log = log & ". Cxl_Msg= " & Cxl_Msg & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept

                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If

                            Else

                                If ChkLog.Checked = False Then
                                    log = ". Update Invoice Status of CreditCard " & vbCrLf
                                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(j).Item("MerchantID") & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(j).Item("TrackID") & vbCrLf
                                    log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                    log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                    log = log & ". @ProcessType= " & NormalizeData.Tables(4).Rows(j).Item("ProcessType") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(j).Item("OrderID") & vbCrLf

                                    log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                                    log = log & ". Having Parameters: " & vbCrLf
                                    log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(j).Item("MerchantID") & vbCrLf
                                    log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(j).Item("OrderID") & vbCrLf
                                    log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                                    log = log & ". @CXLCode= " & CxlR_code & vbCrLf
                                    log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(j).Item("TrackID") & vbCrLf
                                    log = log & ". @Sender= " & NormalizeData.Tables(4).Rows(j).Item("sender") & vbCrLf
                                    log = log & ". @CCStatus= " & "N" & vbCrLf
                                    log = log & ". Except:" & obj.GetExcept
                                    WriteDebugInfo(log, filename)
                                    obj.GetExcept = ""
                                End If

                                If (NormalizeData.Tables(4).Rows(j).Item("ccstatus") = "Y") Then ' that means full payment
                                    If ChkLog.Checked = False Then
                                        log = log & ". @InvoiceStatus= " & "*" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), NormalizeData.Tables(4).Rows(j).Item("TrackID"), "*", CxlR_code, "CreateInvoice(NO)", NormalizeData.Tables(4).Rows(j).Item("ProcessType"), NormalizeData.Tables(4).Rows(j).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "CreateInvoice(NO)", CxlR_code, NormalizeData.Tables(4).Rows(j).Item("trackid"), NormalizeData.Tables(4).Rows(j).Item("sender"), "N")
                                Else
                                    If ChkLog.Checked = False Then
                                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                                        log = log & ". Except:" & obj.GetExcept
                                        WriteDebugInfo(log, filename)
                                        obj.GetExcept = ""
                                    End If
                                    obj.UpdateInvoiceStatus(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), NormalizeData.Tables(4).Rows(j).Item("TrackID"), "P", CxlR_code, "CreateInvoice(NO)", NormalizeData.Tables(4).Rows(j).Item("ProcessType"), NormalizeData.Tables(4).Rows(j).Item("OrderID"))
                                    obj.UpdateInvoiceTable(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "CreateInvoice(NO)", CxlR_code, NormalizeData.Tables(4).Rows(j).Item("trackid"), NormalizeData.Tables(4).Rows(j).Item("sender"), "N")
                                End If

                                'UPDATE  RESPONSE
                                If ChkLog.Checked = False Then
                                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA For Create INVOICE = N case(CXL) "
                                    WriteDebugInfo(log, filename)
                                End If
                                CsMessage = "Invoice will not create"
                                ResponseCode_Cs = "-7"
                                CxlR_code = "-200"
                                Cxl_Msg = "Invoice will not create"
                                obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("CLoginId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(4).Rows(j).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_code, Cxl_Msg)

                            End If
                            txtCxlCode.Text = CxlR_code

                    End Select

                    '............................ end  Calling CXL WEBSERVICE ..........."

                    Dim Key As String
                    Key = obj.GetMCKEY(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), NormalizeData.Tables(4).Rows(j).Item("Customer_ID"))

                    If ChkLog.Checked = False Then
                        log = ". Update Credit Card Details by SP:CAM_CreditCardDetails. " & vbCrLf
                        log = log & ". @Key= " & Key
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateCreditCardDetail(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), NormalizeData.Tables(4).Rows(j).Item("Customer_ID"), NormalizeData.Tables(4).Rows(j).Item("TrackID"), Cxl_Msg, NormalizeData.Tables(4).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(4).Rows(j).Item("CardName"), NormalizeData.Tables(4).Rows(j).Item("CardType"), NormalizeData.Tables(4).Rows(j).Item("CardExpiry"), NormalizeData.Tables(4).Rows(j).Item("CardAddress"), NormalizeData.Tables(4).Rows(j).Item("TranStatus"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), NormalizeData.Tables(4).Rows(j).Item("SecurityCode"), NormalizeData.Tables(4).Rows(j).Item("StartDate"), NormalizeData.Tables(4).Rows(j).Item("EndDate"), NormalizeData.Tables(4).Rows(j).Item("IssueNo"), Key)

                    If ChkLog.Checked = False Then
                        log = ". Update Credit Card Details by SP:UpdateCreditCardDetailAndCXLMsgInInvoice. "
                        WriteDebugInfo(log, filename)
                    End If

                    Dim CXL_Digit As String
                    Dim splitter() As String

                    If Account = "CXL" Then
                        CXL_Digit = Replace(Cxl_Msg, """AUTH CODE:", "")
                        splitter = CXL_Digit.Split("""")
                    ElseIf Account = "PP" Then
                        CXL_Digit = Cxl_Msg
                        splitter = CXL_Digit.Split(" ")
                    End If

                    CXL_Digit = splitter(0)
                    obj.UpdateDetailAndCXLMsgInInvoice(NormalizeData.Tables(4).Rows(j).Item("MerchantID"), NormalizeData.Tables(4).Rows(j).Item("Customer_ID"), CXL_Digit, NormalizeData.Tables(4).Rows(j).Item("CreditCardNo"), NormalizeData.Tables(4).Rows(j).Item("CardName"), NormalizeData.Tables(4).Rows(j).Item("CardType"), NormalizeData.Tables(4).Rows(j).Item("CardExpiry"), NormalizeData.Tables(4).Rows(j).Item("CardAddress"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), NormalizeData.Tables(4).Rows(j).Item("SecurityCode"), NormalizeData.Tables(4).Rows(j).Item("StartDate"), NormalizeData.Tables(4).Rows(j).Item("EndDate"), NormalizeData.Tables(4).Rows(j).Item("IssueNo"), Key, NormalizeData.Tables(4).Rows(j).Item("CurrencyCode"), NormalizeData.Tables(4).Rows(j).Item("GCode"), Account)

                    '------------------------------------------------------------

                    If (CxlR_code = "0" Or CxlR_code = "00") Then ' CXLR_CODE="0" means Succesfull Transaction
                        If ChkLog.Checked = False Then
                            log = ". For Successful Response From CXL . "
                            WriteDebugInfo(log, filename)
                        End If
                        SuccessfulPayOnCredit(j, CxlR_code, Cxl_Msg)

                    ElseIf (CxlR_code = "-2") Then  'Invalid parameter passing
                        If ChkLog.Checked = False Then
                            log = ". For UnSuccessful Response From CXL Parameter Missing . "
                            WriteDebugInfo(log, filename)
                        End If
                        ParameterMissing(j, CxlR_code, Cxl_Msg)

                    Else
                        If ChkLog.Checked = False Then
                            log = ". For UnSuccessful/Decline Response From CXL . "
                            WriteDebugInfo(log, filename)
                        End If
                        Decline(j, CxlR_code, Cxl_Msg)
                    End If

                Catch ex As Exception
                    If ChkLog.Checked = False Then
                        log = ". Exception Occured and updating status_atcs=I For Credit Card Transaction . " & ex.Message
                        WriteDebugInfo(log, filename)
                    End If

                    ResponseCode_Cs = "-6"    ' Credit card not posted to cxl bcoz of any failure
                    CsMessage = "Transaction is Not Forwarded to CXL B/C" & ex.Message

                    SendEmail("Sender = " & NormalizeData.Tables(4).Rows(j).Item("sender") & " OrderID= " & NormalizeData.Tables(4).Rows(j).Item("OrderID") & " Cloginid = " & NormalizeData.Tables(4).Rows(j).Item("CLoginId") & " TrackId = " & NormalizeData.Tables(4).Rows(j).Item("TrackID") & " Exception= " & ex.Message)
                    LstException.Items.Add(DateTime.Now & " " & ex.Message & "CreditCard Function" & obj.GetExcept)

                    If (NormalizeData.Tables(4).Rows(j).Item("sender") = "PR" Or NormalizeData.Tables(4).Rows(j).Item("Sender") = "EX") Then
                        obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("CLoginId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, NormalizeData.Tables(4).Rows(j).Item("invoice_no"), NormalizeData.Tables(4).Rows(j).Item("TrackID"), CxlIdentity)
                    ElseIf (NormalizeData.Tables(4).Rows(j).Item("sender") = "FH") Then
                        UpdateMySqlStatus(NormalizeData.Tables(4).Rows(j).Item("CloginId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), CxlR_code, Cxl_Msg, CsMessage, NormalizeData.Tables(4).Rows(j).Item("TrackID"), "I", ResponseCode_Cs)
                        obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("CLoginId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(4).Rows(j).Item("TrackID"), CxlIdentity)

                    ElseIf (NormalizeData.Tables(4).Rows(j).Item("sender") = "AC" Or NormalizeData.Tables(4).Rows(j).Item("Sender") = "IN" Or NormalizeData.Tables(4).Rows(j).Item("Sender") = "IR" Or NormalizeData.Tables(4).Rows(j).Item("Sender") = "IM" Or NormalizeData.Tables(4).Rows(j).Item("Sender") = "IB") Then
                        obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("CLoginId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(4).Rows(j).Item("TrackID"), CxlIdentity)
                    Else
                        obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(j).Item("MerchantId"), NormalizeData.Tables(4).Rows(j).Item("CLoginId"), NormalizeData.Tables(4).Rows(j).Item("OrderID"), "I", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(4).Rows(j).Item("TrackID"), CxlIdentity)
                    End If

                End Try

            Next

        End Sub

        'Created by M. Furqan Khan on 03 FEB 2010
        Private Sub PostCallBackData(ByVal MIdentity As Int64, ByVal OrderID As Int64, ByVal GenericCode As String, ByVal Amount As Double, _
                                    ByVal TrackID As Int64, ByVal IsOrderSuccess As Boolean, ByVal IsOrderByBank As Boolean)
            Dim CallBackInfoXML As New StringBuilder
            Try
                log = "In procedure PostCallBackData"
                WriteDebugInfo(log, filename)

                Dim objCallBackWs As New com.accountscentre.callback.CallBackService
                Dim callBackWsResult As com.accountscentre.callback.ServiceResponse = objCallBackWs.PostCallBackData(MIdentity, OrderID, _
                                                                                        GenericCode, Amount, TrackID, IsOrderSuccess, IsOrderByBank)
                log = "callBackWsResult.ErrorCode = " & callBackWsResult.ErrorCode & vbNewLine & _
                      "callBackWsResult.ErrorMsg = " & callBackWsResult.ErrorMsg
                WriteDebugInfo(log, filename)

                log = "Exit procedure PostCallBackData"
                WriteDebugInfo(log, filename)
            Catch ex As Exception
                Throw
            End Try

        End Sub
#End Region


#Region "................... Rules Blocked by Merchant.........................."

        Private Function CheckRuleBlockedbyM2(ByVal Curr_Merchant As Integer) As DataSet
            Return (obj.IsRuleBlockbyM2_New(Curr_Merchant))

        End Function

        Private Function CheckBlockRule(ByVal RuleType As Integer, ByVal Rule As String) As Boolean
            Dim Temp As Boolean

            Select Case RuleType

                Case 0 ''Credit Card
                    If UCase(ProcessType) = "CC" Then
                        If (EncryptCreditCardNo = Rule) Then
                            ResponseCode_Cs = "-95"
                            CsMessage = "Credit Card is Blocked"
                            Temp = True
                        Else
                            Temp = False
                        End If
                    End If

                Case 1 '' CountryCode
                    If UCase(ProcessType) = "CC" Then
                        If (CountryCode = Rule) Then
                            Temp = True
                            ResponseCode_Cs = "-96"
                            CsMessage = "Country Code is Blocked"
                        Else
                            Temp = False
                        End If
                    End If

                Case 2 '' Customerid
                    If UCase(ProcessType) = "CC" Then
                        If (Cust_ID = Rule) Then
                            ResponseCode_Cs = "-97"
                            CsMessage = "Customer Id is Blocked"
                            Temp = True

                        Else
                            Temp = False
                        End If
                    End If

                Case 3 ''IpAddress
                    If UCase(ProcessType) = "CC" Then
                        If (IPAddress = Rule) Then
                            ResponseCode_Cs = "-98"
                            CsMessage = "IP Address is Blocked"
                            Temp = True

                        Else
                            Temp = False
                        End If
                    End If

                Case 4 ''Block Keyword

                    If UCase(ProcessType) = "CC" Then
                        log = "Checking order for Block Rule that can change the payment mode"
                        WriteDebugInfo(log, filename)

                        Dim OrderInfoMerchantInvoice As DataSet = obj.GetCustomerOrderInfo(CustomerID, MerchantId, OrderID)

                        'Dim OrderInfoMerchantInvoiceMerchantDB As DataSet = obj.GetCustomerOrderInfoMerchantDB(CustomerID, MerchantId, OrderID)
                        'Dim OrderInfoMerchantInvoiceCXLT As DataSet = obj.GetCustomerOrderInfoCXLT(CustomerID, MerchantId, OrderID)


                        If Not OrderInfoMerchantInvoice Is Nothing Then
                            If OrderInfoMerchantInvoice.Tables(1).Rows.Count > 0 Then
                                If CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("Decrypt_cart_invoice_cardname")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("Decrypt_cart_invoice_cardname"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("Decrypt_cart_invoice_cardaddress")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("Decrypt_cart_invoice_cardaddress"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("del_add")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("del_add"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("name")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("name"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("cont_name")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("cont_name"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("street")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("street"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("town")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("town"))).IndexOf(Rule)) <> -1 Then
                                    ResponseCode_Cs = "-94"
                                    CsMessage = "Keyword :" & Rule & " is Blocked"
                                    Temp = True
                                Else
                                    Temp = False
                                End If
                            End If
                        End If


                        'If Not OrderInfoMerchantInvoiceMerchantDB Is Nothing And Not OrderInfoMerchantInvoiceCXLT Is Nothing Then
                        '    If OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows.Count > 0 And OrderInfoMerchantInvoiceCXLT.Tables(0).Rows.Count > 0 Then
                        '        If CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceCXLT.Tables(0).Rows(0).Item("cardname")), "", OrderInfoMerchantInvoiceCXLT.Tables(0).Rows(0).Item("cardname"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceCXLT.Tables(0).Rows(0).Item("cardaddress")), "", OrderInfoMerchantInvoiceCXLT.Tables(0).Rows(0).Item("cardaddress"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("del_add")), "", OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("del_add"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("name")), "", OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("name"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("cont_name")), "", OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("cont_name"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("street")), "", OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("street"))).IndexOf(Rule)) <> -1 Or CInt(CStr(IIf(IsDBNull(OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("town")), "", OrderInfoMerchantInvoiceMerchantDB.Tables(0).Rows(0).Item("town"))).IndexOf(Rule)) <> -1 Then
                        '            ResponseCode_Cs = "-94"
                        '            CsMessage = "Keyword is Blocked"
                        '            Temp = True
                        '        Else
                        '            Temp = False
                        '        End If
                        '    End If
                        'End If

                    End If

                Case 5 ''Block Email

                    If UCase(ProcessType) = "CC" Then
                        Dim OrderInfoMerchantInvoice As DataSet = obj.GetCustomerOrderInfo(CustomerID, MerchantId, OrderID)
                        If Not OrderInfoMerchantInvoice Is Nothing Then
                            If OrderInfoMerchantInvoice.Tables(1).Rows.Count > 0 Then
                                If CStr(IIf(IsDBNull(OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("cart_customer_email")), "", OrderInfoMerchantInvoice.Tables(1).Rows(0).Item("cart_customer_email"))) = Rule Then
                                    Temp = True
                                Else
                                    Temp = False
                                End If
                            End If
                        End If
                    End If

                Case Else

                    Temp = False

            End Select

            Return Temp


        End Function
#End Region

#Region ".....................Processing For Validity..........................."

        Private Sub FurtherProcessing()

            Dim dtLedger As DataSet
            Dim dtledgerCheck As Boolean
            Dim invoice_track As Integer = 0

            obj.GetExcept = ""
            Dbname = obj.GetDBName(MerchantId)

            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            If (OrderID > 0 And (Sender = "AC" Or Sender = "IN" Or Sender = "FH" Or Sender = "IR" Or Sender = "IB" Or Sender = "IM" Or Sender = "PR")) Then 'it is orderbooked
                If ChkLog.Checked = False Then
                    log = ". Get Order Information by SP: CXLROBO_GETORDERINFO. " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @Dbname= " & Dbname & vbCrLf
                    log = log & ". @MerchantID= " & MerchantId & vbCrLf
                    log = log & ". @OrderID= " & OrderID & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If

                '(SZ:RC)
                Dim _doc As New XmlDocument
                _doc.Load("Robot.xml")
                Dim counter As String = _doc.SelectSingleNode("Robot/RetryCount").InnerText

                If MPI_SessionID Is Nothing Then
                    If retryCount >= CInt(counter) - 1 Then 'Added by Saad for counting the number of calls fro particular order (03/01/08)
                        obj.UpdateStatusAsDeclinedOnRetry_New(OrderID, MerchantId, CxlIdentity, ResponseCode_Cs, CsMessage)
                        log = log & "---- Order has been declined after " & retryCount + 1 & " number of calls" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                        SendEmail("Order ID: " & OrderID & " and Merchant ID: " & MerchantId & " has been declined after " & retryCount + 1 & " number of calls")
                    End If
                Else
                    If retryCount > 1 Then
                        obj.UpdateStatusAsDeclinedOnRetry_New(OrderID, MerchantId, CxlIdentity, "", "")
                        log = log & "---- 3D Secure Order has been declined after " & retryCount & " number of calls" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                        'SendEmail("3D Secure Order ID: " & OrderID & " and Merchant ID" & MerchantId & " has been declined after " & retryCount & " number of calls")
                    End If
                End If
                '(SZ:RC)

                OrderData = obj.GetOrderInfo(Dbname, MerchantId, OrderID) ' Get Order information of particular customer

                If (OrderData.Tables(0).Rows.Count > 0) Then
                    If (IsDBNull(OrderData.Tables(0).Rows(0).Item("End_date"))) Then
                        End_Date = ""
                    Else
                        End_Date = OrderData.Tables(0).Rows(0).Item("End_date")
                    End If

                    Cust_ID = OrderData.Tables(0).Rows(0).Item("customer_id")

                    'CHECK PAYMENT STATUS 
                    Dim ChkPayment As Boolean
                    If ChkLog.Checked = False Then
                        log = ". Checking Payment is Partial or Full of Order= " & OrderID & vbCrLf
                        log = log & ". for Sender= " & Sender & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantId= " & MerchantId & vbCrLf
                        log = log & ". @Amount= " & Amount & vbCrLf
                        'log = log & ". @PaidAmount= " & PaidAmount & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If

                    'Added by Saad 08/01/08 (SZ:BP)
                    If UCase(ProcessType) = "BP" Or UCase(ProcessType) = "PA" Then
                        ChkPayment = True
                    Else
                        ChkPayment = CheckPaymentIsFullOrPartial(MerchantId, OrderID, Amount, PaidAmount) ''Checking payment for an order is full or partial
                    End If
                    '//////////////////////////////////////////////////


                    If (ChkPayment = True) Then
                        ccStatus = "Y"
                    Else
                        ccStatus = "P"
                    End If

                    invoice_track = IIf(IsDBNull(OrderData.Tables(0).Rows(0).Item("trackID")), 0, OrderData.Tables(0).Rows(0).Item("trackID"))
                End If



                ' CONTROLLING BYFORCE BIT OF PARTICULAR MERCHANT IS NOT "Y"
                ' IF BYFORCE BIT IS "Y" THEN WE CAN'T CALL CXL WEBSERVICE
                '
                ' IF TRACK ID IS 0 OR NULL THEN GET IT FROM COLLECTION SERVICE & UPDATE IT ON CALLS_ATCS TABLE OF CXL TRANSACTION
                ''Dim invoice_InvoiceNo As Integer = IIf(IsDBNull(OrderData.Tables(0).Rows(0).Item("InvoiceNo")), 0, OrderData.Tables(0).Rows(0).Item("InvoiceNo"))

                If rid = 0 And invoice_track <> 0 And UCase(status) <> "U" Then
                    rid = invoice_track
                    obj.UpdateTrackid_New(CLoginID, MerchantId, rid, OrderID, CxlIdentity)
                    dtLedger = obj.GetTrackFromMledger_New(rid)
                    If dtLedger.Tables(0).Rows.Count > 0 Then
                        dtledgerCheck = True
                    End If
                Else
                    dtledgerCheck = False
                End If

                If (rid = 0) Then
                    If ChkLog.Checked = False Then
                        log = ". Getting CurrencySymbol SP:CXLROBO_FETCHCURRENCYSYMBOL. " & vbCrLf
                        log = log & ". Of Sender= " & Sender & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @CurrencyCode= " & CurrencyCode & vbCrLf
                        log = log & ". @GCode= " & GCode
                        WriteDebugInfo(log, filename)
                    End If
                    Symbol = obj.GetCurrencySymbol_New(CurrencyCode, GCode)

                    If ChkLog.Checked = False Then
                        log = ". Getting TrackId From Collection Service by SP:CAM_ADDINVOICE. " & vbCrLf
                        log = log & ". For Sender= " & Sender & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @Cust_ID= " & Cust_ID & vbCrLf
                        log = log & ". @MerchantId= " & MerchantId & vbCrLf
                        log = log & ". @amount= " & Amount & vbCrLf
                        log = log & ". @rid= " & rid & vbCrLf
                        log = log & ". @Sender= " & Sender & vbCrLf
                        log = log & ". @OrderID= " & OrderID & vbCrLf
                        log = log & ". @TransactionType= " & TransactionType & vbCrLf
                        log = log & ". @Mode= " & Mode & vbCrLf
                        log = log & ". @ProcessType= " & ProcessType & vbCrLf
                        log = log & ". @GCode= " & GCode & vbCrLf
                        log = log & ". @CurrencyCode= " & CurrencyCode & vbCrLf
                        log = log & ". @Symbol= " & Symbol & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If

                    Dim rid_count As Integer = 0
                    While (rid = 0 And rid_count < 3)
                        rid = GetTrackIDFromCOllectionService(Cust_ID, MerchantId, Amount, rid, Sender, OrderID, TransactionType, Mode, ProcessType, GCode, CurrencyCode, Symbol)
                        rid_count = rid_count + 1
                    End While

                    If ChkLog.Checked = False Then
                        log = ". Update that Trackid by SP:CXLROBO_UPDATETRACKID" & vbCrLf
                        log = log & ". Trackid= " & rid & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateTrackid_New(CLoginID, MerchantId, rid, OrderID, CxlIdentity)   'Update Trackid field in sql server db
                    obj.UpdateInvoiceTable(MerchantId, OrderID, "", "", rid, Sender, ccStatus)

                    'Calling Suresh's SPs on 13/08/2008
                    obj.UpdatePaymentProcessor(rid, PaymentProcessor)
                    log = ". Calling SP:DBSERVER.INFINISHOPMAINDB.dbo.CAM_Update_PaymentProcessor" & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    obj.GetExcept = ""
                    '---------------
                ElseIf rid <> 0 And UCase(status) = "U" Then
                    log = ". Retry order: Blocking Old Track " & vbCrLf
                    log = log & ". Status= " & status & vbCrLf
                    log = log & ". For Sender= " & Sender & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @Cust_ID= " & Cust_ID & vbCrLf
                    log = log & ". @MerchantId= " & MerchantId & vbCrLf
                    log = log & ". @amount= " & Amount & vbCrLf
                    log = log & ". @Old rid= " & rid & vbCrLf
                    log = log & ". @OrderID= " & OrderID & vbCrLf
                    log = log & ". @TransactionType= " & TransactionType & vbCrLf
                    log = log & ". @Mode= " & Mode & vbCrLf
                    log = log & ". @ProcessType= " & ProcessType & vbCrLf
                    log = log & ". @GCode= " & GCode & vbCrLf
                    log = log & ". @CurrencyCode= " & CurrencyCode & vbCrLf
                    log = log & ". @Symbol= " & Symbol & vbCrLf
                    log = log & ". Block Track ID= YES" & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""

                    obj.BlockTrackID(MerchantId, rid, "D")

                    log = ". Except:" & obj.GetExcept
                    log = log & ". Generating New Track ID " & vbCrLf
                    WriteDebugInfo(log, filename)

                    Symbol = obj.GetCurrencySymbol_New(CurrencyCode, GCode)

                    rid = 0

                    Dim rid_count As Integer = 0
                    While (rid = 0 And rid_count < 3)
                        rid = GetTrackIDFromCOllectionService(Cust_ID, MerchantId, Amount, rid, Sender, OrderID, TransactionType, Mode, ProcessType, GCode, CurrencyCode, Symbol)
                        rid_count = rid_count + 1
                    End While

                    If ChkLog.Checked = False Then
                        log = ". Update that Trackid by SP:CXLROBO_UPDATETRACKID" & vbCrLf
                        log = log & ". Trackid= " & rid & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateTrackid_New(CLoginID, MerchantId, rid, OrderID, CxlIdentity)   'Update Trackid field in sql server db
                    obj.UpdateInvoiceTable(MerchantId, OrderID, "", "", rid, Sender, ccStatus)

                End If

                'Added by Saad 08/01/08 (SZ:BP)
                If UCase(ProcessType) = "BP" Then
                    Check = True
                ElseIf dtledgerCheck = True Then
                    Check = False
                Else
                    Check = CheckValidityOfAmount(Dbname, Amount, rid, OrderID, ProcessType, Authorized)
                End If
                '////////////////////////////////////


            Else

                If ChkLog.Checked = False Then
                    log = ". Get Invoice Information by SP: CXLROBO_GETORDERINFO." & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @Dbname= " & Dbname & vbCrLf
                    log = log & ". @MerchantID= " & MerchantId & vbCrLf
                    log = log & ". @Invoice_no= " & Invoice_no & vbCrLf
                    log = log & ". @CLoginID= " & CLoginID & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If


                InvoiceDataForPRO = obj.GetOrderInfo4_ProInvoice(Dbname, MerchantId, Invoice_no, CLoginID) 'check against order_id field in cledger
                Check = True
                If (InvoiceDataForPRO.Tables(0).Rows.Count > 0) Then

                    End_Date = InvoiceDataForPRO.Tables(0).Rows(0).Item("Enddate")
                    Cust_ID = InvoiceDataForPRO.Tables(0).Rows(0).Item("custid")

                    'CHECK PAYMENT STATUS 
                    Dim ChkPayment As Boolean
                    If ChkLog.Checked = False Then
                        log = ". Checking Payment is Partial or Full of Invoice_no= " & Invoice_no & vbCrLf
                        log = log & ". for Sender= " & Sender & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantId= " & MerchantId & vbCrLf
                        log = log & ". @Amount= " & Amount & vbCrLf
                        log = log & ". @PaidAmount= " & PaidAmount & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If

                    'SZ:BP
                    If UCase(ProcessType) <> "BP" Then
                        ChkPayment = CheckPaymentIsFullOrPartialForPro(MerchantId, Invoice_no, Amount, PaidAmount) 'Checking payment for an order is full or partial
                    Else
                        ChkPayment = True
                    End If
                    'SZ:BP

                    If (ChkPayment = True) Then
                        ccStatus = "Y"
                    Else
                        ccStatus = "P"
                    End If
                End If
                ' IF TRACK ID IS 0 OR NULL THEN GET IT FROM COLLECTION SERVICE & UPDATE IT ON CALLS_ATCS TABLE OF CXL TRANSACTION

                If (rid = 0) Then
                    If ChkLog.Checked = False Then
                        log = ". Getting CurrencySymbol SP:CXLROBO_FETCHCURRENCYSYMBOL. " & vbCrLf
                        log = log & ". Of Sender= " & Sender & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @CurrencyCode= " & CurrencyCode & vbCrLf
                        log = log & ". @GCode= " & GCode
                        WriteDebugInfo(log, filename)

                    End If

                    Symbol = obj.GetCurrencySymbol_New(CurrencyCode, GCode)
                    If ChkLog.Checked = False Then
                        log = ". Getting TrackId From Collection Service by SP:CAM_ADDINVOICE. " & vbCrLf
                        log = log & ". For Sender= " & Sender & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @Cust_ID= " & Cust_ID & vbCrLf
                        log = log & ". @MerchantId= " & MerchantId & vbCrLf
                        log = log & ". @amount= " & Amount & vbCrLf
                        log = log & ". @rid= " & rid & vbCrLf
                        log = log & ". @Sender= " & Sender & vbCrLf
                        log = log & ". @OrderID= " & OrderID & vbCrLf
                        log = log & ". @TransactionType= " & TransactionType & vbCrLf
                        log = log & ". @Mode= " & Mode & vbCrLf
                        log = log & ". @ProcessType= " & ProcessType & vbCrLf
                        log = log & ". @GCode= " & GCode & vbCrLf
                        log = log & ". @CurrencyCode= " & CurrencyCode & vbCrLf
                        log = log & ". @Symbol= " & Symbol & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    Dim rid_count As Integer
                    While (rid = 0 And rid_count < 3)
                        rid = GetTrackIDFromCOllectionServiceForPRO(Cust_ID, MerchantId, Amount, rid, Sender, Invoice_no, TransactionType, Mode, ProcessType, GCode, CurrencyCode, Symbol)
                        rid_count = rid_count + 1
                    End While
                    If ChkLog.Checked = False Then
                        log = ". Update that Trackid by SP:CXLROBO_UPDATETRACKID" & vbCrLf
                        log = log & ". Trackid= " & rid & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateTrackid_New(CLoginID, MerchantId, rid, OrderID, Invoice_no)  'Update Trackid field in sql server db
                    obj.UpdateInvoiceTable(MerchantId, OrderID, "", "", rid, Sender, ccStatus)

                End If
            End If
            ' CHECK THE VALIDITY OF GIVEN AMOUNT 
            If ChkLog.Checked = False Then
                If (OrderID = "0" And Invoice_no <> "0") Then
                    log = ". Checking Validity of Amount of Invoice= " & Invoice_no & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @Dbname= " & Dbname & vbCrLf
                    log = log & ". @Amount= " & Amount & vbCrLf
                    log = log & ". @rid= " & rid & vbCrLf
                    log = log & ". @OrderID= " & OrderID & vbCrLf
                    log = log & ". @ProcessType= " & ProcessType & vbCrLf
                    log = log & ". @Authorized= " & Authorized & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                ElseIf (OrderID <> "0") Then
                    log = ". Checking Validity of Amount of Order =" & OrderID & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @Dbname= " & Dbname & vbCrLf
                    log = log & ". @Amount= " & Amount & vbCrLf
                    log = log & ". @rid= " & rid & vbCrLf
                    log = log & ". @OrderID= " & OrderID & vbCrLf
                    log = log & ". @ProcessType= " & ProcessType & vbCrLf
                    log = log & ". @Authorized= " & Authorized & vbCrLf
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
            End If

        End Sub
#End Region

#Region "........ Checking Validity Of Amount of a Particular Customer ........."

        Private Function CheckValidityOfAmount(ByVal Dbname As String, ByVal Amt As Double, ByVal Rid As Long, ByVal OrderID As String, ByVal ProcessType As String, ByVal auth As Integer) As Boolean

            '' 1)CHECKING FOR VALID AMOUNT I.E: AMOUNT<= BALANCE
            '' 2)CHECKING FOR CUSTOMER FLOOR LIMIT I.E: AMOUNT<=FLOORLIMIT
            '' 3)CHECKING FOR MAX # OF TRANSACTION I.E: MAX#OF TRAN < (SOME VALUE SHOULD BE IN A TEXT FILE)
            '' 4)CHECKING FOR REMAIN BALANCE < = AMOUNT

            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            Dim Balance As Double
            Dim FloorLimit As Double
            Dim MaxNumOfTran As Integer
            Dim RemainBalance As Double
            'OrderInfo = obj.CheckAmount(Dbname, CustomerLoginID, Rid, OrderID, "11/24/2005")
            Try
                If (OrderData.Tables(0).Rows.Count > 0) Then
                    Balance = OrderData.Tables(0).Rows(0).Item("Balance")
                    FloorLimit = OrderData.Tables(0).Rows(0).Item("FloorLimit")
                    MaxNumOfTran = OrderData.Tables(0).Rows.Count
                End If

                Dim DTab As DataTable = obj.GetValidTranDrCr(MerchantId, Dbname, Rid)
                If DTab.Rows.Count > 0 Then
                    RemainBalance = CDbl(DTab.Rows(0).Item("cDebit") - DTab.Rows(0).Item("Lcredit"))
                End If
                If (ProcessType = "cc" Or ProcessType = "CC") Then

                    If (auth = 0) Then

                        If (Amt > Balance) Then
                            ResponseCode_Cs = "-2"
                            CsMessage = "Amount is Greater than Balance of Customer"

                        ElseIf (Amt > FloorLimit) Then
                            ResponseCode_Cs = "-3"
                            CsMessage = "Amount is Greater than Floor Limit of Customer"
                        ElseIf (MaxNumOfTran > 10) Then
                            ResponseCode_Cs = "-4"
                            CsMessage = "Customer made Max Number of Transaction Greater Than its limit"
                        ElseIf (RemainBalance > Amt) Then
                            ResponseCode_Cs = "-5"
                            CsMessage = "Amount is Less than Remaining Balance of Customer"
                        ElseIf (Amt = 0.0) Then
                            ResponseCode_Cs = "-8"
                            CsMessage = "Amount 0.00 not applicable "
                        End If


                    Else
                        If (Amt > Balance) Then
                            ResponseCode_Cs = "-2"
                            CsMessage = "Amount is Greater than Balance of Customer"

                        ElseIf (MaxNumOfTran > 10) Then
                            ResponseCode_Cs = "-4"
                            CsMessage = "Customer made Max Number of Transaction Greater Than its limit"
                        ElseIf (RemainBalance > Amt) Then
                            ResponseCode_Cs = "-5"
                            CsMessage = "Amount is Less than Remaining Balance of Customer"
                        ElseIf (Amt = 0.0) Then
                            ResponseCode_Cs = "-8"
                            CsMessage = "Amount 0.00 not applicable "
                        End If
                    End If

                Else
                    If (Amt > Balance) Then
                        ResponseCode_Cs = "-2"
                        CsMessage = "Amount is Greater than Balance of Customer"

                    ElseIf (RemainBalance > Amt) Then
                        ResponseCode_Cs = "-5"
                        CsMessage = "Amount is Less than Remaining Balance of Customer"

                        'ElseIf (Amt = 0.0) Then
                        '    ResponseCode_Cs = ""
                        '    CsMessage = "NULL"

                    End If
                End If
                'HERE MAXNUMOFTRAN COMPAIR TO THAT VALUE WHICH HAS TO B PLACED IN SEPARATE FILE (LIKE WEB.CONFIG)
                ' SO THAT V REPLACED ONLY FILE'S VALUE NOT THE CODE

                If (ProcessType = "cc" Or ProcessType = "CC") Then
                    If (Amt <= Balance And Amt <= FloorLimit And MaxNumOfTran < 10 And RemainBalance <= Amt And Balance <> 0.0 And FloorLimit <> 0.0 And MaxNumOfTran <> 0 And auth = 0) Then
                        Return True
                    ElseIf (Amt <= Balance And MaxNumOfTran < 10 And RemainBalance <= Amt And Balance <> 0.0 And FloorLimit <> 0.0 And MaxNumOfTran <> 0 And auth = 1) Then
                        Return True
                    Else
                        Return False
                    End If

                Else
                    If (Amt <= Balance And RemainBalance <= Amt) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Catch ex As Exception
                DataString = DataString & ex.Message & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & obj.GetExcept)
                SendEmail("Check Validity of Amount : " & ex.Message & " : " & obj.GetExcept)
            End Try
        End Function


#End Region

#Region "........................ Convert Amount into Pennies..................."

        Private Function GetAmountInPenni(ByVal Amount As Double) As Long
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

#End Region

#Region " ............ Encryption of Cards,Security # and Issue #..............."

        Private Sub EncryptData()

            Dim EnDs As New DataSet
            Dim count As Integer
            Dim TempDs As New DataSet
            For count = 0 To IDENTITY.Count - 1
                'Ds = obj.GETDataFromDB(IDENTITY(count))
                TempDs = obj.GETDataFromDB_New(IDENTITY(count))
                EnDs.Merge(TempDs.Tables(0))
            Next

            Dim i, p As Integer
            Dim ECard As String = ""
            Dim EIssueNum As String = ""
            Dim ESecurityCode As String = ""

            If (EnDs.Tables(0).Rows.Count > 0) Then

                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

                For p = 0 To EnDs.Tables(0).Rows.Count - 1
                    Dim Order As String = EnDs.Tables(0).Rows(p).Item("orderbooked")
                    Dim Cardno As String = EnDs.Tables(0).Rows(p).Item("Cardno")
                    Dim securityCode As String = EnDs.Tables(0).Rows(p).Item("securityCode")
                    Dim IssueNum As String = EnDs.Tables(0).Rows(p).Item("issueno")
                    Dim TimeStamp1 As String = EnDs.Tables(0).Rows(p).Item("Timestamp1")
                    i = Cardno.IndexOf("p")

                    If (Cardno <> "" And i = -1) Then
                        ECard = Encrypt(Cardno)
                        If (IssueNum <> "") Then
                            EIssueNum = Encrypt(IssueNum)
                        End If
                        If (securityCode <> "") Then
                            ESecurityCode = Encrypt(securityCode)
                        End If
                        obj.UpdateE_CardInSQLServer_New(Order, ECard, TimeStamp1, EIssueNum, ESecurityCode)
                    End If


                Next
            End If

        End Sub
        Private Function Encrypt(ByVal Info As String) As String

            Dim ObjXml As New InfiniLogic.AccountsCentre.common.ConfigReader
            Dim ObjCrypt As New rsaLibrary1.Crypt
            Dim En As String = Info
            Dim E As String
            Dim N As String

            E = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.E)
            N = ObjXml.GetItem(InfiniLogic.AccountsCentre.common.ConfigVariables.N)
            En = ObjCrypt.Encrypt(En, E, N)
            En = Replace(En, "+", "p")
            Return En

        End Function
#End Region

#Region ".............. Function For Payment is Full OR Partial................."

        Private Function CheckPaymentIsFullOrPartial(ByVal mid As String, ByVal orderid As String, ByVal PayAmount As Double, ByRef PaidAmount As Double) As Boolean
            Try

                log = log & ""

                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

                Dim PreviousPaidAmount As Double
                If IsDBNull(OrderData.Tables(0).Rows(0).Item("pay_amt")) Then
                    PreviousPaidAmount = 0
                Else
                    PreviousPaidAmount = OrderData.Tables(0).Rows(0).Item("pay_amt")
                End If
                Dim DiscountAmount As Double = OrderData.Tables(0).Rows(0).Item("discount")

                'CALCULATE THE TOTAL SHIPMENT CHARGES
                Dim CarriageNet As Double = OrderData.Tables(0).Rows(0).Item("Carriage")
                Dim CarriageTaxRate As Double = OrderData.Tables(0).Rows(0).Item("car_tax_rate")
                Dim SumCarriageCharges As Double = CarriageNet + ((CarriageNet * CarriageTaxRate) / 100)

                Dim ODetail As DataSet = obj.GetOrderDetail(mid, orderid)
                Dim SumProductsAmount As Double = 0.0
                Dim count As Integer
                For count = 0 To ODetail.Tables(0).Rows.Count - 1
                    Dim netProductAmount As Double = ODetail.Tables(0).Rows(count).Item("Amount") - ODetail.Tables(0).Rows(count).Item("Discount") 'Added on request of Greesh
                    netProductAmount = Format(CDbl(netProductAmount), "0.00")
                    SumProductsAmount = SumProductsAmount + netProductAmount

                    log = "CheckPaymentIsFullOrPartial - Amount : " & ODetail.Tables(0).Rows(count).Item("Amount") & vbCrLf
                    log = log & "Discount : " & ODetail.Tables(0).Rows(count).Item("Discount") & vbCrLf
                    log = log & "netProductAmount : " & netProductAmount
                    WriteDebugInfo(log, filename)
                Next
                ' SUM SHIPMENT AMOUNT 
                Dim SumCartOrderAmount As Double = (SumProductsAmount + SumCarriageCharges) - DiscountAmount

                If SumCartOrderAmount >= (PayAmount + PreviousPaidAmount) Then
                    Dim isFullPayment As Boolean
                    Dim Pay_amount As Double
                    If SumCartOrderAmount = (Format(CDbl(PayAmount), "0.00") + PreviousPaidAmount) Then isFullPayment = True

                    If IsDBNull(OrderData.Tables(0).Rows(0).Item("pay_amt")) Then
                        Pay_amount = 0
                    Else
                        Pay_amount = OrderData.Tables(0).Rows(0).Item("pay_amt")
                    End If
                    Dim NewPaidAmount As String = CDbl(Pay_amount) + CDbl(PayAmount)
                    PaidAmount = NewPaidAmount
                    Return isFullPayment
                End If
            Catch ex As Exception
                DataString = DataString & ex.Message & " Check Payment is full Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Check Payment is full Function" & obj.GetExcept)
                SendEmail(ex.Message & " Check Payment is full Function" & obj.GetExcept)
            End Try
        End Function

        Private Function CheckPaymentIsFullOrPartialForPro(ByVal mid As String, ByVal Inv_no As String, ByVal PayAmount As Double, ByRef PaidAmt As Double) As Boolean
            Try

                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

                Dim SumProductsAmount As Double = 0.0
                SumProductsAmount = InvoiceDataForPRO.Tables(0).Rows(0).Item("Invtotal")
                Dim isFullPayment As Boolean
                If SumProductsAmount >= (PayAmount) Then
                    isFullPayment = True
                Else
                    isFullPayment = False
                End If
                Return isFullPayment
            Catch ex As Exception
                DataString = DataString & ex.Message & " Check Payment is full Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Check Payment is full Function" & obj.GetExcept)
                SendEmail(ex.Message & " Check Payment is full Function" & obj.GetExcept)
            End Try
        End Function

#End Region

#Region ".................Getting Trackid For Collection Service................"

        Private Function GetTrackIDFromCOllectionService(ByVal CustID As String, ByVal MerId As String, ByVal Amt As String, ByVal Rid As Long, ByVal Sender As String, ByVal OrderID As String, ByVal TranType As String, ByVal mode As String, ByVal PaymentMode As String, ByVal Gcode As String, ByVal CCode As String, ByVal symbol As String) As Integer

            Try
                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

                If (OrderData.Tables(0).Rows.Count > 0) Then
                    Dim OrderDate As Date = OrderData.Tables(0).Rows(0).Item("cart_invoice_orderDate")
                    Dim formateddate1 As String = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim formateddate2 As String = OrderDate.ToString("MM/dd/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim Send As String = GetSender(Sender)
                    Dim Del_add As String
                    If (IsDBNull(OrderData.Tables(0).Rows(0).Item("del_add"))) Then
                        Del_add = ""
                    Else
                        Del_add = OrderData.Tables(0).Rows(0).Item("del_add")
                    End If
                    Dim DCamAddinvoice As DataSet = obj.GetRidFromCS(OrderData.Tables(0).Rows(0).Item("ac"), CustID, MerId, formateddate2, Amt, "INVOICE FROM CXL", TranType, formateddate1, "*", OrderID, UCase(PaymentMode), "CompanyName", Rid, Del_add, "*", Send, mode, Gcode, CCode, symbol)
                    If (DCamAddinvoice.Tables(0).Rows.Count > 0) Then
                        Return (DCamAddinvoice.Tables(0).Rows(0).Item("rid"))
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Catch ex As Exception
                DataString = DataString & ex.Message & " Get Rid Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Get Rid Function" & obj.GetExcept)

            End Try
        End Function

        Private Function GetTrackIDFromCOllectionServiceForPRO(ByVal CustID As String, ByVal MerId As String, ByVal Amt As String, ByVal Rid As Long, ByVal Sender As String, ByVal inv_no As String, ByVal TranType As String, ByVal mode As String, ByVal PaymentMode As String, ByVal Gcode As String, ByVal CCode As String, ByVal symbol As String) As Integer
            Try
                StatusResponse = StatusResponse + 1
                lblStatusResponse.Text = StatusResponse
                Application.DoEvents()

                If (InvoiceDataForPRO.Tables(0).Rows.Count > 0) Then
                    Dim InvoiceDate As Date = InvoiceDataForPRO.Tables(0).Rows(0).Item("orderDate")
                    Dim formateddate1 As String = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim formateddate2 As String = InvoiceDate.ToString("MM/dd/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim Send As String = GetSender(Sender)
                    Dim DCamAddinvoice As DataSet = obj.GetRidFromCSFORPro(InvoiceDataForPRO.Tables(0).Rows(0).Item("customerid"), CustID, MerId, formateddate2, Amt, "INVOICE FROM CXL", TranType, formateddate1, "*", inv_no, UCase(PaymentMode), "CompanyName", Rid, InvoiceDataForPRO.Tables(0).Rows(0).Item("deliveryaddress"), "*", Send, mode, Gcode, CCode, symbol)
                    If (DCamAddinvoice.Tables(0).Rows.Count > 0) Then
                        Return (DCamAddinvoice.Tables(0).Rows(0).Item("rid"))
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Catch ex As Exception
                DataString = DataString & ex.Message & " Get Rid Function" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Get Rid Function" & obj.GetExcept)
                ' SendEmail(ex.Message & " Get Rid Function" & obj.GetExcept)
            End Try
        End Function

#End Region

#Region "........................... Select Senders............................."

        Private Function GetSender(ByVal Sender As String) As String

            Select Case Sender
                Case "AC"
                    Return "AccountsCentre"

                Case "FH"
                    Return "FormationHouse"
                Case "IN" ' Modified by Shariq, previous value was IS.
                    Return "InfiniShops"
                Case "EX"
                    Return "Express"
                Case "PR"
                    Return "AccountsPro"
                Case "IR"
                    Return "InfinishopsReseller"
                Case "IB"
                    Return "InfiniBuyer"     'implemented on 13thsept 2006 
                Case "IM"
                    Return "InfiniMarketPlace" 'Implemented on 27th Sept 2006

                Case Else
                    Return "Invalid Sender"
            End Select

        End Function

        Private Function GetOriginalSender(ByVal Mid As Integer, ByVal Rid As Integer) As String

            Dim Str As String = obj.GetOriginalSender(Mid, Rid)

            Select Case Str
                Case "AccountsCentre"
                    Return "AC"
                Case "FormationHouse"
                    Return "FH"
                Case "InfiniShops"
                    Return "IN"
                Case "Express"
                    Return "EX"
                Case "AccountsPro"
                    Return "PR"
                Case "InfinishopsReseller"
                    Return "IR"
                Case "InfiniBuyer"
                    Return "IB"
                Case "InfiniMarketPlace"
                    Return "IM" 'Implemented on 27th Sept 2006
                Case Else
                    Return Str

            End Select

        End Function

#End Region

#Region " ........................Timer Functions.............................. "

        '''Slaves Timers 
        Private Sub TimerPopulate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerPopulate.Tick

            If (WaitToComplete = False) Then

                Try

                    Pic1.BackColor = Color.Blue

                    If ChkLog.Checked = False Then
                        timestring = Date.Now
                        folder = "d:\Log\" & Date.Today
                        folder = Replace(folder, "/", "-")
                        CreateFolder(folder)

                    End If

                    MySqlData()

                Catch ex As Exception
                    DataString = DataString & ex.Message & " Timer Populate MySqlData method :" & obj.GetExcept & vbNewLine
                    LstException.Items.Add(DateTime.Now & " " & ex.Message & " Timer Populate MySqlData method :" & obj.GetExcept)
                End Try


                Try
                    If UCase(System.Configuration.ConfigurationSettings.AppSettings("PostInfinishop")) = "ON" Then
                        Dim PostInfiniShop As com.infinishops.postservices.Service
                        'Calling webservice of Greesh on 10th June, 2009
                        PostInfiniShop = New com.infinishops.postservices.Service
                        Try
                            PostInfiniShop.Timeout = 1 * 60 * 1000
                            PostInfiniShop.MainServiceMethod()
                        Catch ex As Exception
                            LstException.Items.Add(DateTime.Now & " " & ex.Message & " :postservices.infinishops.com.service")
                        Finally
                            PostInfiniShop = Nothing
                        End Try
                    End If
                Catch ex As Exception
                    'SendEmail("infinishops.postservice.com.service: " & " Exception= " & ex.Message)
                    LstException.Items.Add(DateTime.Now & " " & ex.Message & " :infinishops.postservice.com.service")
                End Try


                Try
                    BindGrid()

                    If (DGData.VisibleRowCount > 1) Then
                        TimerPopulate.Enabled = False
                        Pic1.BackColor = Color.Gray
                        Pic2.BackColor = Color.Green
                        TimerChkValidity.Enabled = True
                        ChkLog.Checked = False
                    Else
                        ChkLog.Checked = True
                        txtValid.Text = ""
                        txtInvalid.Text = ""
                        txtBank.Text = ""
                        txtCredit.Text = ""
                    End If

                Catch ex As Exception
                    DataString = DataString & ex.Message & "Populate Timer Function Bind Grid " & obj.GetExcept & vbNewLine
                    LstException.Items.Add(DateTime.Now & " " & ex.Message & "Populate Timer Function Bind Grid " & obj.GetExcept)

                End Try
            Else
                End

            End If
        End Sub

        Private Sub TimerChkValidity_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerChkValidity.Tick
            Try

                TimerChkValidity.Enabled = False
                Pic2.BackColor = Color.Gray

                CheckValidity()
                TimerGetResponse.Enabled = True
                Pic3.BackColor = Color.Orange

            Catch ex As Exception
                DataString = DataString & ex.Message & " Checking Validity Timer" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Checking Validity Timer" & obj.GetExcept)
            End Try
        End Sub

        Private Sub TimerGetResponse_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGetResponse.Tick
            Try
                TimerGetResponse.Enabled = False
                Pic3.BackColor = Color.Gray
                GetResponse()
                TimerPopulate.Enabled = True

            Catch ex As Exception
                DataString = DataString & ex.Message & " Getting response Timer" & obj.GetExcept & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & " Getting response Timer" & obj.GetExcept)
            End Try
        End Sub


#End Region

#Region "......Folder Creation methods and log files maintain functions........."

        Private Sub CreateFolder(ByVal vfolder)
            Try

                If (Directory.Exists(vfolder) = False) Then
                    Dim fs, f, s
                    fs = CreateObject("Scripting.FileSystemObject")
                    f = fs.CreateFolder(vfolder)
                    fs = Nothing
                    f = Nothing
                End If

            Catch ex As Exception
                DataString = DataString & ex.Message & "Create Folder" & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & "Create Folder")
            End Try
        End Sub

        'Sub WriteStrToFile(ByVal MyKeyString As String, ByVal strFileName As String)

        '    Dim objReader As StreamWriter
        '    Try
        '        objReader = New StreamWriter(strFileName)
        '        objReader.Write(MyKeyString)
        '        objReader.Close()
        '    Catch ex As Exception
        '        LstException.Items.Add(ex.Message & "Write to File Function")
        '    End Try
        'End Sub

        Private Sub WriteDebugInfo(ByVal sText As String, ByVal LogUniquePath As String)

            Try
                If Not System.IO.Directory.Exists(LogUniquePath) Then
                    System.IO.Directory.CreateDirectory(LogUniquePath)
                End If
                Dim sw As System.IO.StreamWriter
                sw = System.IO.File.AppendText(LogUniquePath & "\CXLROBOT.vb Trace.txt")
                sw.WriteLine(Now & " -- " & sText)
                sw.Close()

                '(SZ:RC) Added by Saad on 03/01/08 for counting no. of retries per order
                Dim sr As System.IO.StreamReader
                sr = System.IO.File.OpenText(LogUniquePath & "\CXLROBOT.vb Trace.txt")
                Dim str As String = sr.ReadToEnd
                sr.Close()
                Dim counts As String() = Split(str, "CXLROBO_GETORDERINFO")
                retryCount = counts.Length - 1
                '...............

                log = ""
            Catch ex As Exception
                DataString = DataString & ex.Message & "WriteDebugInfo Method" & vbNewLine
                LstException.Items.Add(DateTime.Now & " " & ex.Message & "WriteDebugInfo Method")
            End Try
        End Sub
#End Region

#Region "..................... Sending Error Email ............................."

        Private Sub SendEmail(ByVal msg As String, Optional ByVal Subject As String = "Exception From Cxl Occured (LIVE SERVER) @ Time :")

            Dim objmail As New MailMessage

            Dim email_to As String = System.Configuration.ConfigurationSettings.AppSettings("email_to")

            objmail.From = "errors@cxl.com"

            'objmail.To = "rehan@infinilogic.com"       '"sadiawaleem@infinilogic.com"
            'objmail.Cc = "shariq@infinilogic.com"
            'objmail.Bcc = "saad@infinilogic.com"

            objmail.To = email_to

            If UCase(System.Configuration.ConfigurationSettings.AppSettings("emailFrom")) = "LOCAL" Then
                objmail.To = "saad@infinilogic.com"
                objmail.Subject = "Exception occured (LOCAL SERVER-MULTIPLE DB)@ Time : " & Now
                SmtpMail.SmtpServer = "192.168.1.66"  'Local Server
            Else
                objmail.Subject = "Exception occured (LIVE SERVER-MULTIPLE DB)@ Time : " & Now
                SmtpMail.SmtpServer = "10.0.0.42"  'Live Server"
            End If

            'objmail.Subject = "Exception occured (LIVE SERVER)@ Time : " & Now
            objmail.Body = msg
            'SmtpMail.SmtpServer = "10.0.0.42" ' ' "192.168.1.66" 'Live Server= "10.0.0.42" ' LOCAL server="213.86.130.41"
            Try
                SmtpMail.Send(objmail)
            Catch ex As Exception
                DataString = DataString & "The following exception occurred: " + ex.ToString() & vbNewLine
                LstException.Items.Add((DateTime.Now & " " & "The following exception occurred: " + ex.ToString()))
                'check the InnerException
                While Not (ex.InnerException Is Nothing)
                    DataString = DataString & "The following InnerException reported: " + ex.InnerException.ToString() & vbNewLine
                    LstException.Items.Add((DateTime.Now & " " & "The following InnerException reported: " + ex.InnerException.ToString()))
                    ex = ex.InnerException
                End While
            End Try
        End Sub


#End Region

        Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
            WaitToComplete = True
        End Sub

#Region "................. List Exception Selected Text Methods................."

        'Private Sub LstException_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstException.MouseUp
        '    HandleMouseUp(LstException, e)
        'End Sub
        Private Sub HandleMouseUp(ByVal Control As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

            If e.Button = MouseButtons.Left Then
                ContextHandler(Control, e)
                Control.ContextMenu.Show(Control, New Point(e.X, e.Y))

            End If
        End Sub
        Protected Sub ContextHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

            'ListView Menu Captions
            Const LVW_COPY = "&Copy To Clip Board"
            Const LIST_BOX_NAME = "LstException"

            ' Clear all previously added MenuItems.
            ContextMenu1.MenuItems.Clear()

            If sender.name = LIST_BOX_NAME Then
                'ContextMenu1.SourceControl is

                'Define the MenuItem object to display for the ListView1.

                Dim menuItem1 As New MenuItem(LVW_COPY)

                ' Add MenuItems to display for the TextBox.
                ContextMenu1.MenuItems.Add(menuItem1)

                '' Copy ListBox Text to clipboard
                Dim datobj As New System.Windows.Forms.DataObject

                datobj.SetData(System.Windows.Forms.DataFormats.Text, LstException.SelectedItem)
                System.Windows.Forms.Clipboard.SetDataObject(datobj)

            End If
        End Sub
#End Region

#Region ".................Check paremeter before pass to CXL...................."

        Private Function CheckValidParameter(ByVal CreditCardNo As String, ByVal IssueNumber As String, ByVal TransactionAmount As String, ByVal GCode As String, ByVal MerchantId As String, ByVal CID As String, ByVal OrderID As String, ByVal TransactionType As String, ByVal StartDate As String, ByVal CardExpiry As String, ByVal CardType As String, ByVal Mode As String, ByRef Response As String, ByRef Message As String, ByVal AgentName As String, ByVal AgentAcquirer As String, ByVal rid As String, ByVal MerchantLoginId As String, ByVal CustomerLoginId As String, ByVal Sender As String, ByVal SecurityCode As String) As Boolean
            Dim B As Boolean

            If (CreditCardNo = "" Or CreditCardNo Is Nothing) Then

                Response = "501"
                Message = "CreditCard [0] length"
                B = False
                'ElseIf (IssueNumber = "") Then

                '    Response = "502"
                '    Message = "IssueNumber [0] length"
                '    B = False
            ElseIf (TransactionAmount = "" Or TransactionAmount Is Nothing) Then
                Response = "503"
                Message = "TransactionAmount [0] length"
                B = False
            ElseIf (GCode = "" Or GCode Is Nothing) Then
                Response = "504"
                Message = "GenericCode [0] length"
                B = False
            ElseIf (MerchantId = "" Or MerchantId Is Nothing) Then
                Response = "505"
                Message = "MerchantId [0] length"
                B = False
            ElseIf (CID = "" Or CID Is Nothing) Then

                Response = "506"
                Message = "CustomerID [0] length"
                B = False
            ElseIf (OrderID = "" Or OrderID Is Nothing) Then

                Response = "507"
                Message = "OrderID [0] length"
                B = False
            ElseIf (TransactionType = "" Or TransactionType Is Nothing) Then
                Response = "508"
                Message = "TransactionType [0] length"
                B = False
            ElseIf (StartDate = "" Or StartDate Is Nothing) Then
                Response = "509"
                Message = "StartDate [0] length"
                B = False
            ElseIf (CardExpiry = "" Or CardExpiry Is Nothing) Then
                Response = "510"
                Message = "CardExpiry [0] length"
                B = False
            ElseIf (CardType = "" Or CardType Is Nothing) Then
                Response = "511"
                Message = "CardType [0] length"
                B = False
            ElseIf (Mode = "" Or Mode Is Nothing) Then
                Response = "512"
                Message = "Mode [0] length"
                B = False
            ElseIf (AgentName = "" Or AgentName Is Nothing) Then
                Response = "513"
                Message = "AgentName [0] length"
                B = False
            ElseIf (AgentAcquirer = "" Or AgentAcquirer Is Nothing) Then
                Response = "514"
                Message = "AgentAcquirer [0] length"
                B = False
            ElseIf (rid = "" Or rid Is Nothing) Then
                Response = "515"
                Message = "Trackid [0] length"
                B = False
            ElseIf (MerchantLoginId = "" Or MerchantLoginId Is Nothing) Then
                Response = "516"
                Message = "MerchantLoginId [0] length"
                B = False
            ElseIf (CustomerLoginId = "" Or CustomerLoginId Is Nothing) Then
                Response = "517"
                Message = "CustomerLoginId [0] length"
                B = False
            ElseIf (Sender = "" Or Sender Is Nothing) Then
                Response = "518"
                Message = "Sender [0] length"
                B = False
                'ElseIf (Len(SecurityCode) > 3 And CardType = "AMEX Card") Then
                '    Response = "519"
                '    Message = "SecurityCode [0] More than 3 digit"
                '    B = False

            Else
                Response = ""
                Message = ""
                B = True
            End If

            Return B

        End Function


#End Region

#Region "................ Updation on the basis Of CXL Code....................."

        Private Sub ParameterMissing(ByVal J As Integer, ByVal CXLR_Code As String, ByVal CXL_Msg As String)
            ResponseCode_Cs = "-9"
            CsMessage = "Parameter Missing"

            If (NormalizeData.Tables(2).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    log = ". Update my sql status For Parameter Passing . "
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", ResponseCode_Cs)
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, NormalizeData.Tables(2).Rows(J).Item("invoice_no"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)

            Else
                If ChkLog.Checked = False Then
                    log = ". Update sql status For Parameter Passing . "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, NormalizeData.Tables(2).Rows(J).Item("invoice_no"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)
            End If

        End Sub

        Private Sub SuccessfulCXL(ByVal J As Integer, ByVal CXLR_Code As String, ByVal CXL_Msg As String)

            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            ResponseCode_Cs = "1"
            CsMessage = CXL_Msg

            Dim Inv_no As String

            Dim ODetail As DataSet

            ' ........... start Update Customer Type in Customer Table.........."
            If ChkLog.Checked = False Then
                log = ". For Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
                log = ". Update Customer Type By SP: CXLROBO_UPDATECUSTOMERTYPE. "
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @Customer_ID= " & NormalizeData.Tables(2).Rows(J).Item("Customer_ID") & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                WriteDebugInfo(log, filename)
            End If
            obj.UpdateCustomerType(NormalizeData.Tables(2).Rows(J).Item("Customer_ID"), NormalizeData.Tables(2).Rows(J).Item("MerchantID"))
            '................. End Customer type updation..............."

            Dim CorporateOrder As Boolean = False
            Dim dtCorp As DataSet = obj.GetCorporateOrderInfo(CInt(NormalizeData.Tables(2).Rows(J).Item("MerchantID")), CInt(NormalizeData.Tables(2).Rows(J).Item("OrderID")), CInt(NormalizeData.Tables(2).Rows(J).Item("TrackID")))
            If Not dtCorp Is Nothing Then
                If dtCorp.Tables(0).Rows.Count > 0 Then
                    CorporateOrder = True
                    Inv_no = dtCorp.Tables(0).Rows(0).Item("InvoiceNo")
                End If
            End If

            If ((NormalizeData.Tables(2).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(2).Rows(J).Item("Sender") = "EX") And NormalizeData.Tables(2).Rows(J).Item("OrderID") = 0) Then
                ' ......Start  Cledger and Request Table  on full and partial payment"........
                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                End If
                '......... End Cledger and Request Table  on full and partial payment"............. 
                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(2).Rows(J).Item("invoice_no"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)

            ElseIf (CorporateOrder = True) Then

                If ChkLog.Checked = False Then
                    log = ". Update Invoice Status of CreditCard " & vbCrLf
                    log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                    log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                    log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                    WriteDebugInfo(log, filename)
                End If

                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                    WriteDebugInfo(log, filename)
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                Else
                    log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                    WriteDebugInfo(log, filename)
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                End If

                If ChkLog.Checked = False Then
                    log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS. "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID" & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID" & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @PaidAmount" & NormalizeData.Tables(2).Rows(J).Item("PaidAmount") & vbCrLf
                    log = log & ". @ccStatus" & NormalizeData.Tables(2).Rows(J).Item("ccStatus")
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
                obj.UpDatePayAmount(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("PaidAmount"), NormalizeData.Tables(2).Rows(J).Item("ccStatus"))
                obj.UpDatePayAmountProInvoice(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), Inv_no, NormalizeData.Tables(2).Rows(J).Item("PaidAmount"))


                '......... End Cledger and Request Table  on full and partial payment"............. 
                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)


                'Infinishops Webservice in case of Repay
                Try
                    Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                    info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                    info.IsOrderSuccess = True
                    info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                    info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                    If ChkLog.Checked = False Then
                        log = ". Calling InfiniShops.EnabledServices for Repayment Method For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjIo = New Io.InfiniShops.ServiceActivation
                    Dim result As WindowsGateWayCreditCard.Io.InfiniShops.TicketHandlerResult = ObjIo.RepayTicketHandler_PayOnCredit(info)
                    If ChkLog.Checked = False Then
                        log = "Result Error Code :" & result.ERRORCODE & vbCrLf
                        log = "Result Error Description :" & result.ERRORDESC & vbCrLf
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Calling InfiniShops.EnabledServices:" & ex.Message & " , Merchant ID =" & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & ", Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Calling InfiniShops.EnabledServices:" & ex.Message & " , Merchant ID =" & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & ", Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                End Try
                '---------------

            Else

                '''''''''''''''' For FH ,IN,AC,IB,IM,IR .............

                '..................start  Update Invoice Table ..............." 
                If ChkLog.Checked = False Then
                    log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS. "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID" & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID" & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @PaidAmount" & NormalizeData.Tables(2).Rows(J).Item("PaidAmount") & vbCrLf
                    log = log & ". @ccStatus" & NormalizeData.Tables(2).Rows(J).Item("ccStatus")
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
                obj.UpDatePayAmount(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("PaidAmount"), NormalizeData.Tables(2).Rows(J).Item("ccStatus"))
                '............... End Start Update Invoice Table pay_amt field etc...................."
                Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                If ChkLog.Checked = False Then
                    log = ". Getting Order Detail by SP :INFINISHOPS_ORDER_ADDDETAILS . "
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
                ' ...............start. Insert order details in inv_det table............."
                Dim X As Integer
                For X = 0 To DataS.Tables(0).Rows.Count - 1
                    obj.OrderAddDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "@ORD" + NormalizeData.Tables(2).Rows(J).Item("OrderID"), DataS.Tables(0).Rows(X).Item("Product_ID"), DataS.Tables(0).Rows(X).Item("prod_code"), DataS.Tables(0).Rows(X).Item("Qty"), DataS.Tables(0).Rows(X).Item("product_sale_price"), DataS.Tables(0).Rows(X).Item("product_tax_code"), DataS.Tables(0).Rows(X).Item("tax_code_rate"), DataS.Tables(0).Rows(X).Item("unitprice"), "S")
                    If ChkLog.Checked = False Then
                        log = ". Adding Order Detail . "
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Next
                ' ............... end Insert order details in inv_det table..........."
                Dim Copy2ProWeb As Boolean = False

                If (obj.CheckServiceEnable(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), "118") = True Or obj.CheckServiceEnable(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), "232") = True) Then

                    ''''............... Sttart Insert in pro_invoice  to get invoice #..............."
                    Dim defaultBack_nc As String = obj.GetLedgerNC(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), "Default Bank")
                    Dim deliveryExpences_nc As String = obj.GetLedgerNC(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), "Delivery Expenses")
                    If ChkLog.Checked = False Then
                        log = ". Invoice Creation in Pro_invoice by SP:ACCOUNTSPRO_UPDATEPROINVOICE For " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & " (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(2).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @InvoiceNumber= " & "0" & vbCrLf
                        log = log & ". @Inv_date=" & Date.Now() & vbCrLf
                        log = log & ". @Cust_det=" & "" & vbCrLf
                        log = log & ". @product_tax_code=" & DataS.Tables(0).Rows(0).Item("product_tax_code") & vbCrLf
                        log = log & ". @tax_Code_rate=" & DataS.Tables(0).Rows(0).Item("tax_Code_rate") & vbCrLf
                        log = log & ". @GlobalTC= " & "T9" & vbCrLf
                        log = log & ". @GlobalTCrate= " & "0" & vbCrLf
                        log = log & ". @defaultBack_nc= " & defaultBack_nc & vbCrLf
                        log = log & ". @deliveryExpences_nc= " & deliveryExpences_nc & vbCrLf
                        log = log & ". @Inv_type= " & "Inv" & vbCrLf
                        log = log & ". @Car_net= " & "0" & vbCrLf
                        log = log & ". @Car_vat= " & "0" & vbCrLf
                        log = log & ". @PaidAmount= " & NormalizeData.Tables(2).Rows(J).Item("PaidAmount") & vbCrLf
                        log = log & ". @CloginID= " & NormalizeData.Tables(2).Rows(J).Item("CloginID") & vbCrLf
                        log = log & ". @Pay_type= " & "Invoice"
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    Inv_no = obj.InsertProInvoice(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "0", Date.Now(), "", DataS.Tables(0).Rows(0).Item("product_tax_code"), DataS.Tables(0).Rows(0).Item("tax_Code_rate"), "T9", "0", defaultBack_nc, deliveryExpences_nc, "Inv", 0, 0, NormalizeData.Tables(2).Rows(J).Item("PaidAmount"), NormalizeData.Tables(2).Rows(J).Item("CloginID"), "Invoice", "cc")
                    ''.........End .............Insert in pro_invoice  to get invoice #...
                    ''
                    ''............. Sttart Insert in pro_inv_det  .............."

                    Dim i As Integer = 0
                    ODetail = obj.GetOrderDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    For i = 0 To ODetail.Tables(0).Rows.Count - 1
                        With ODetail.Tables(0).Rows(i)
                            'Dim _tempnet As String = FormatNumber(.Item("product_sale_price") * .Item("Qty"), 2, , , TriState.False)
                            'Dim _tempnet As String = FormatNumber(.Item("unitprice") * .Item("Qty"), 2, , , TriState.False)
                            Dim _tempvat As String = FormatNumber(.Item("Tax_amount"), 2, , , TriState.False)

                            Dim discountAmount As Double = .Item("Discount")
                            Dim product_sale_price As Double = .Item("product_sale_price")
                            Dim discountPer As Double '= .Item("product_sale_price") / discountAmount

                            Dim _tempnet As String = FormatNumber(product_sale_price * .Item("Qty"), 2, , , TriState.False)
                            Dim nc As String
                            If IsDBNull(.Item("nc")) Then
                                nc = "10000"
                            Else
                                nc = .Item("nc")
                            End If
                            If ChkLog.Checked = False Then
                                log = ". Inserting Order Detail by SP: ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS For " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & " (CreateInvoice=Y) For Sender. " & NormalizeData.Tables(2).Rows(J).Item("Sender") & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                                log = log & ". @inv_no= " & Inv_no & vbCrLf
                                log = log & ". @prod_code= " & .Item("prod_code") & vbCrLf
                                log = log & ". @prod_name= " & .Item("cart_product_name") & vbCrLf
                                log = log & ". @nc=" & nc & vbCrLf
                                log = log & ". @product_tax_code=" & .Item("product_tax_code") & vbCrLf
                                log = log & ". @tax_code_rate=" & .Item("tax_code_rate") & vbCrLf
                                log = log & ". @Detail= " & "" & vbCrLf
                                log = log & ". @product_sale_price= " & .Item("product_sale_price") & vbCrLf
                                log = log & ". @Qty= " & .Item("Qty") & vbCrLf
                                log = log & ". @_tempnet= " & _tempnet & vbCrLf
                                log = log & ". @_tempvat= " & _tempvat & vbCrLf
                                log = log & ". @Inv_type= " & "Inv"
                                WriteDebugInfo(log, filename)
                            End If
                            obj.InsertProdMasterDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), Inv_no, .Item("prod_code"), nc, .Item("product_tax_code"), .Item("tax_code_rate"), .Item("cart_product_name"), product_sale_price, .Item("Qty"), _tempnet, _tempvat, "Inv", discountAmount, discountPer)

                        End With
                    Next
                    ' .....End Insert in pro_inv_det..................."
                    ' 
                    '........ start  Updating invoice # in Invoice Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :INFINISHOPS_ORDER_UPDATE_INVOICE_NO For CC (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(2).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If

                    obj.UpDateInvoiceNo(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Inv_no)
                    '..........End   start  Updating invoice # in Invoice Table.........."
                    '

                    '........ start  Updating invoice # in CLEDGER Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :CXLROBO_UPDATEINVOICENUMBERINCLEDGER. For " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & " (CreateInvoice=Y) "
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If

                    obj.UpDateInvoiceNoInCledger(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), Inv_no)
                    ' ..........End   start  Updating invoice # in CLEDGER Table.........."
                    '' 
                End If
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then '' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "Y" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "Y")

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "P" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "P")

                End If
                ' ...End................... Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment............"
                ' 
                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)
                log = ". Except: " & obj.GetExcept
                WriteDebugInfo(log, filename)
            End If


            ' 
            '...... start Update Credit card in RFollowUp table.......................
            If (UCase(NormalizeData.Tables(2).Rows(J).Item("ProcessType")) = "CC") Then
                If ChkLog.Checked = False Then
                    log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard  For " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & "  (CreateInvoice=Y). "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @CxlMessage= " & CXL_Msg & vbCrLf
                    log = log & ". @TranStatus= " & "Y"
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateCreditCard(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), CXL_Msg, "Y")
                ' ...... end Update Credit card in RFollowUp table.......................
                ' 
                If (NormalizeData.Tables(2).Rows(J).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
                    If ChkLog.Checked = False Then
                        log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
                        log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For " & NormalizeData.Tables(2).Rows(J).Item("ProcessType") & " Credit Card(CreateInvoice=Y). "
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @Amount= " & NormalizeData.Tables(2).Rows(J).Item("Amount") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @TransactionType= " & NormalizeData.Tables(2).Rows(J).Item("TransactionType") & vbCrLf
                        log = log & ". @Inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If
                    '''' ....start update infinishopmainDB Mledger table................
                    obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Amount"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), NormalizeData.Tables(2).Rows(J).Item("TransactionType"), Inv_no)
                End If
                ' ........ start .....Posting Invoice ............... 
                Dim Post As New InvoicePostWS.AccountsProService
                Post.Timeout = 3 * 60 * 1000

                If ChkLog.Checked = False Then
                    log = ". Invoices To Post of Inv No: For SuccessFull CreditCard " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @inv_no= " & Inv_no & vbCrLf
                    log = log & ". MTS= " & MTS
                    WriteDebugInfo(log, filename)
                End If
                Dim b As String = Post.CXLRobot_PostInvoice(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), Inv_no)
                If b <> "0" Then
                    SendEmail("Merchant ID: " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & ", Order ID: " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & ", Invoice no: " & Inv_no & ", Response from Post Invoice: " & b)
                End If
                If ChkLog.Checked = False Then
                    log = ". End of Invoices To Post of Inv No: For SuccessFull CreditCard " & vbCrLf
                    log = log & ". Having Code Return: " & b
                    WriteDebugInfo(log, filename)
                End If
                ' ........ end .....Posting Invoice ............... 

                'Calling accountsWS in case of MTS
                If UCase(MTS) = "Y" Then
                    Dim accountsws As New com.infinibiz.accountsws.AccountsProService
                    Dim bol As Boolean
                    If ChkLog.Checked = False Then
                        log = ". Callng MTS "
                        WriteDebugInfo(log, filename)
                    End If
                    Try
                        bol = accountsws.CreateSalesOrder(NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), NormalizeData.Tables(2).Rows(J).Item("MerchantID"))
                    Catch ex As Exception
                        log = ". Exception at MTS :" & ex.Message
                        WriteDebugInfo(log, filename)
                    End Try
                    If ChkLog.Checked = False Then
                        log = ". Response from MTS :" & bol
                        WriteDebugInfo(log, filename)
                    End If
                End If
                '....................................
            End If

            'Checking Referral Order (by Saad on request of Ashuar 14/07/2008)
            log = ". Checking Referral Order"
            log = log & ". Having Parameters: " & vbCrLf
            log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
            log = log & ". @Customer_Id= " & NormalizeData.Tables(2).Rows(J).Item("Customer_Id") & vbCrLf
            log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf

            'Dim ds As DataSet = obj.GetRefferalOrder(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
            '////////////////////////////////////////////
            Dim ds As DataSet = obj.GetMerchantRefferalOrder(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    log = log & ". RECORD FOUND while checking Referral Order" & vbCrLf
                Else
                    log = log & ". Record Not found while checking Referral Order" & vbCrLf
                End If
            Else
                log = log & ". Record Not found while checking Referral Order" & vbCrLf
            End If

            log = log & "Exception :" & obj.GetExcept
            WriteDebugInfo(log, filename)
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    log = log & ". Paying Commision: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @CustomerID= " & NormalizeData.Tables(2).Rows(J).Item("Customer_Id") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                    Try
                        Dim dsReferal As DataSet = obj.REFERRAL_ATTRIBUTE(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "DC2", "1")
                        If dsReferal.Tables(0).Rows.Count > 0 Then
                            Dim dsPay As DataSet = obj.REFERRAL_PAYCOMMISSION_For_DC2(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                            log = log & "PayCommission Message ID For DC2: " & dsPay.Tables(0).Rows(0).Item("MessageID") & vbCrLf
                            log = log & "PayCommission Message Text For DC2: " & dsPay.Tables(0).Rows(0).Item("MessageText")
                        Else
                            Dim dsPay As DataSet = obj.REFERRAL_PAYCOMMISSION(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                            log = log & "PayCommission Message ID: " & dsPay.Tables(0).Rows(0).Item("MessageID") & vbCrLf
                            log = log & "PayCommission Message Text: " & dsPay.Tables(0).Rows(0).Item("MessageText")
                        End If
                    Catch ex As Exception
                        log = log & "Paying Commision - Exception :" & ex.Message & vbCrLf
                    End Try
                    log = log & "Exception :" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                End If
            End If
            '////////////////////////////////////////////

            If (NormalizeData.Tables(2).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    log = ". Update Status of MYSQL " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @CloginId= " & NormalizeData.Tables(2).Rows(J).Item("CloginId") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                    log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                    log = log & ". @CsMessage= " & CsMessage & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @StatusFromCs= " & "Y" & vbCrLf
                    log = log & ". @ResponseCode_Cs= " & ResponseCode_Cs
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, NormalizeData.Tables(2).Rows(J).Item("TrackID"), "Y", ResponseCode_Cs, Inv_no)

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "AC" And CorporateOrder = False) Then

                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then
                    If ChkLog.Checked = False Then
                        log = ". Calling EnabledServices Method For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @Customer_Id= " & NormalizeData.Tables(2).Rows(J).Item("Customer_Id") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @IsOrderProcess= " & "True" & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(2).Rows(J).Item("ProcessType")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjService = New ServiceActivation.ServiceActivation
                    Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), True, NormalizeData.Tables(2).Rows(J).Item("ProcessType"))

                End If

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IR" And CorporateOrder = False) Then

                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                ''Infinishops Webservice
                'Try
                '    Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                '    info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                '    info.IsOrderSuccess = True
                '    info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                '    info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                '    If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                '        info.PayMode = Io.InfiniShops.PaymentMode.CC
                '    Else
                '        info.PayMode = Io.InfiniShops.PaymentMode.CB
                '    End If
                '    If ChkLog.Checked = False Then
                '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender")
                '        WriteDebugInfo(log, filename)
                '    End If
                '    ObjIo = New Io.InfiniShops.ServiceActivation
                '    Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)
                'Catch ex As Exception
                '    log = log & "Except:. Calling InfiniShops.EnabledServices:" & ex.Message & " , Merchant ID =" & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & ", Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                '    WriteDebugInfo(log, filename)
                '    SendEmail("Exception:. Calling InfiniShops.EnabledServices:" & ex.Message & " , Merchant ID =" & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & ", Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                'End Try
                ''---------------


                ''Reseller Webservice
                'Try
                '    Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail ' ServiceActivation.ProductDetail
                '    Dim count As Integer
                '    For count = 0 To DataS.Tables(0).Rows.Count - 1
                '        Product(count) = New com.reseller.webservices.ProductDetail
                '        Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                '        Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                '        Product(count).OrderType = Datas.Tables(0).Rows(count).Item("OrderType")
                '    Next
                '    If ChkLog.Checked = False Then
                '        log = ". calling Web service GETBIZINFO method for Credit Card For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                '        log = log & ". Having Parameters: " & vbCrLf
                '        log = log & ". @MerchantLoginID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID") & vbCrLf
                '        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                '        log = log & ". @Customer_id= " & NormalizeData.Tables(2).Rows(J).Item("Customer_id") & vbCrLf
                '        'log = log & ". @Product= " & Product & vbCrLf
                '        log = log & ". @PayStatus=" & "Y"
                '        WriteDebugInfo(log, filename)
                '    End If
                '    ResellerService = New com.reseller.webservices.IShopOrderHander
                '    ResellerService.GetBizInfo(NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("Customer_id"), Product, "Y")
                'Catch ex As Exception
                '    log = log & "Except:. Reseller Webservice. Getbizinfo:" & ex.Message & " , Merchant Login ID = " & NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID") & " , Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                '    WriteDebugInfo(log, filename)
                '    SendEmail("Exception:. Reseller Webservice. Getbizinfo:" & ex.Message & " , Merchant Login ID = " & NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID") & " , Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                'End Try
                ''----------------

                Try
                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), "Y", "Y", "CC")
                    If ChkLog.Checked = False Then
                        log = ". Dumping data for MPI Reseller" & vbCrLf
                        log = log & "Exception:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = ". Dumping data for MPI Reseller" & vbCrLf
                    log = log & "Exception:" & ex.Message
                    WriteDebugInfo(log, filename)
                End Try

                'Coupon webservice 'Added by Saad 03/07/2008
                Try
                    If ChkLog.Checked = False Then
                        log = ". calling COUPON Service For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @Customer_id= " & NormalizeData.Tables(2).Rows(J).Item("Customer_id")
                        WriteDebugInfo(log, filename)
                    End If

                    Dim couponService As New com.infinishops.couponsystem.EmailCoupon
                    Dim couponServiceResult As com.infinishops.couponsystem.ErrorCodesInfo = couponService.EmailToCustomer(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Customer_id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                    If ChkLog.Checked = False Then
                        log = ". Afer calling COUPON Service For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @ErrorCode= " & couponServiceResult.ErrorCode & vbCrLf
                        log = log & ". @ErrorDescription= " & couponServiceResult.ErrorDescription
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Coupon Webservice:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                    WriteDebugInfo(log, filename)
                    SendEmail(log)
                End Try

                '---------------------------------------

                'Add Supplier Webservice
                Try
                    If ChkLog.Checked = False Then
                        log = ". calling ADD SUPPLIER Service For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(2).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @Customer_id= " & NormalizeData.Tables(2).Rows(J).Item("Customer_id")
                        WriteDebugInfo(log, filename)
                    End If

                    Dim addSupplier As New com.infinishops.addsupplier.AddSupplier
                    Dim addSupplierResult As com.infinishops.addsupplier.ErrorCodesInfo = addSupplier.AddSupplier(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("Customer_id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                    If ChkLog.Checked = False Then
                        log = ". Afer calling ADD SUPPLIER Service For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @ErrorCode= " & addSupplierResult.ErrorCode & vbCrLf
                        log = log & ". @ErrorDescription= " & addSupplierResult.ErrorDescription
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Add Supplier:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Add Supplier:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                End Try
                '---------------------------


            ElseIf ((NormalizeData.Tables(2).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(2).Rows(J).Item("Sender") = "EX") And NormalizeData.Tables(2).Rows(J).Item("OrderID") = 0) Then

                obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("invoice_no"))


            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IB") Then

                If ChkLog.Checked = False Then
                    log = ". calling their Web service method UpdateBuyerPointStatus Place  For Sender " & NormalizeData.Tables(2).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                ObjBuyer = New BPtsPayment.InfiniBPPay
                ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(2).Rows(J).Item("TrackID"), True, Inv_no)

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IM" And CorporateOrder = False) Then

                If ChkLog.Checked = False Then
                    log = ". calling their Web service InfiniMarket Place  For IM "
                    WriteDebugInfo(log, filename)
                End If
                Dim IM_Xml As String
                IM_Xml = "<CustomerOrderInfo>" & _
                         "<CustomerID>" & NormalizeData.Tables(2).Rows(J).Item("Customer_id") & "</CustomerID>" & _
                         "<CustomerUID>" & NormalizeData.Tables(2).Rows(J).Item("CloginId") & "</CustomerUID>" & _
                         "<MerchantID>" & NormalizeData.Tables(2).Rows(J).Item("MerchantId") & "</MerchantID>" & _
                         "<MerchantUID>" & NormalizeData.Tables(2).Rows(J).Item("MerchantLoginId") & "</MerchantUID>" & _
                         "<OrderAmount>" & NormalizeData.Tables(2).Rows(J).Item("Amount") & "</OrderAmount>" & _
                         "<OrderStatus> Processed </OrderStatus>" & _
                         "<OrderID>" & NormalizeData.Tables(2).Rows(J).Item("OrderID") & "</OrderID>" & _
                         "<TrackID>" & NormalizeData.Tables(2).Rows(J).Item("Trackid") & "</TrackID>" & _
                        "</CustomerOrderInfo>"

                'Dim T As String
                'ObjInfiniMarketPlace=new InfiniMarket._Default
                ''  T = ObjInifiniMarketPlace.CustomerOrderProcess(IM_Xml)

                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = True
                info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                End If

                If ChkLog.Checked = False Then
                    log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                'Else
                '    If ChkLog.Checked = False Then
                '        log = ". Update Status of Invalid  SENDER by SP:CXLROBO_UPDATEDATA."
                '        WriteDebugInfo(log, filename)
                '    End If
                '    obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(2).Rows(J).Item("trackid"))


            End If
        End Sub

        Private Sub SuccessfulPayOnCredit(ByVal J As Integer, ByVal CXLR_Code As String, ByVal CXL_Msg As String)

            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()


            ResponseCode_Cs = "1"
            CsMessage = CXL_Msg

            Dim Inv_no As String

            Dim ODetail As DataSet

            ' ........... start Update Customer Type in Customer Table.........."
            If ChkLog.Checked = False Then
                log = ". For Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
                log = ". Update Customer Type By SP: CXLROBO_UPDATECUSTOMERTYPE. "
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @Customer_ID= " & NormalizeData.Tables(4).Rows(J).Item("Customer_ID") & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID")
                WriteDebugInfo(log, filename)
            End If
            obj.UpdateCustomerType(NormalizeData.Tables(4).Rows(J).Item("Customer_ID"), NormalizeData.Tables(4).Rows(J).Item("MerchantID"))
            '................. End Customer type updation..............."

            If ((NormalizeData.Tables(4).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(4).Rows(J).Item("Sender") = "EX") And NormalizeData.Tables(4).Rows(J).Item("OrderID") = 0) Then
                ' ......Start  Cledger and Request Table  on full and partial payment"........
                If (NormalizeData.Tables(4).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(4).Rows(J).Item("ProcessType"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(4).Rows(J).Item("ProcessType"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                End If
                '......... End Cledger and Request Table  on full and partial payment"............. 
                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(J).Item("MerchantId"), NormalizeData.Tables(4).Rows(J).Item("CLoginId"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(4).Rows(J).Item("invoice_no"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)

            Else

                '''''''''''''''' For FH ,IN,AC,IB,IM,IR .............

                '..................start  Update Invoice Table ..............." 
                If ChkLog.Checked = False Then
                    log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS. "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID" & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID" & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @PaidAmount" & NormalizeData.Tables(4).Rows(J).Item("PaidAmount") & vbCrLf
                    log = log & ". @ccStatus" & NormalizeData.Tables(4).Rows(J).Item("ccStatus")
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
                obj.UpDatePayAmount(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), 0, NormalizeData.Tables(4).Rows(J).Item("ccStatus"))
                '............... End Start Update Invoice Table pay_amt field etc...................."
                Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                If ChkLog.Checked = False Then
                    log = ". Getting Order Detail by SP :INFINISHOPS_ORDER_ADDDETAILS . "
                    log = log & ". Except:" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                    obj.GetExcept = ""
                End If
                ' ...............start. Insert order details in inv_det table............."
                Dim X As Integer
                For X = 0 To DataS.Tables(0).Rows.Count - 1
                    obj.OrderAddDetail(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), "@ORD" + NormalizeData.Tables(4).Rows(J).Item("OrderID"), DataS.Tables(0).Rows(X).Item("Product_ID"), DataS.Tables(0).Rows(X).Item("prod_code"), DataS.Tables(0).Rows(X).Item("Qty"), DataS.Tables(0).Rows(X).Item("product_sale_price"), DataS.Tables(0).Rows(X).Item("product_tax_code"), DataS.Tables(0).Rows(X).Item("tax_code_rate"), DataS.Tables(0).Rows(X).Item("unitprice"), "S")
                    If ChkLog.Checked = False Then
                        log = ". Adding Order Detail . "
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Next
                ' ............... end Insert order details in inv_det table..........."
                Dim Copy2ProWeb As Boolean = False

                If (obj.CheckServiceEnable(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), "118") = True Or obj.CheckServiceEnable(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), "232") = True) Then

                    ''''............... Sttart Insert in pro_invoice  to get invoice #..............."
                    Dim defaultBack_nc As String = obj.GetLedgerNC(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), "Default Bank")
                    Dim deliveryExpences_nc As String = obj.GetLedgerNC(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), "Delivery Expenses")
                    If ChkLog.Checked = False Then
                        log = ". Invoice Creation in Pro_invoice by SP:ACCOUNTSPRO_UPDATEPROINVOICE For " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & " (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(4).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @InvoiceNumber= " & "0" & vbCrLf
                        log = log & ". @Inv_date=" & Date.Now() & vbCrLf
                        log = log & ". @Cust_det=" & "" & vbCrLf
                        log = log & ". @product_tax_code=" & DataS.Tables(0).Rows(0).Item("product_tax_code") & vbCrLf
                        log = log & ". @tax_Code_rate=" & DataS.Tables(0).Rows(0).Item("tax_Code_rate") & vbCrLf
                        log = log & ". @GlobalTC= " & "T9" & vbCrLf
                        log = log & ". @GlobalTCrate= " & "0" & vbCrLf
                        log = log & ". @defaultBack_nc= " & defaultBack_nc & vbCrLf
                        log = log & ". @deliveryExpences_nc= " & deliveryExpences_nc & vbCrLf
                        log = log & ". @Inv_type= " & "Inv" & vbCrLf
                        log = log & ". @Car_net= " & "0" & vbCrLf
                        log = log & ". @Car_vat= " & "0" & vbCrLf
                        log = log & ". @PaidAmount= " & NormalizeData.Tables(4).Rows(J).Item("PaidAmount") & vbCrLf
                        log = log & ". @CloginID= " & NormalizeData.Tables(4).Rows(J).Item("CloginID") & vbCrLf
                        log = log & ". @Pay_type= " & "Invoice"
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    Inv_no = obj.InsertProInvoice(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), "0", Date.Now(), "", DataS.Tables(0).Rows(0).Item("product_tax_code"), DataS.Tables(0).Rows(0).Item("tax_Code_rate"), "T9", "0", defaultBack_nc, deliveryExpences_nc, "Inv", 0, 0, 0, NormalizeData.Tables(4).Rows(J).Item("CloginID"), "Invoice", "CR")

                    Dim i As Integer = 0
                    ODetail = obj.GetOrderDetail(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                    For i = 0 To ODetail.Tables(0).Rows.Count - 1
                        With ODetail.Tables(0).Rows(i)
                            Dim _tempvat As String = FormatNumber(.Item("Tax_amount"), 2, , , TriState.False)

                            Dim discountAmount As Double = .Item("Discount")
                            Dim product_sale_price As Double = (.Item("product_sale_price"))
                            Dim discountPer As Double '= .Item("product_sale_price") / discountAmount

                            Dim _tempnet As String = FormatNumber(product_sale_price * .Item("Qty"), 2, , , TriState.False)

                            Dim nc As String
                            If IsDBNull(.Item("nc")) Then
                                nc = "10000"
                            Else
                                nc = .Item("nc")
                            End If
                            If ChkLog.Checked = False Then
                                log = ". Inserting Order Detail by SP: ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS For " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & " (CreateInvoice=Y) For Sender. " & NormalizeData.Tables(4).Rows(J).Item("Sender") & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                                log = log & ". @inv_no= " & Inv_no & vbCrLf
                                log = log & ". @prod_code= " & .Item("prod_code") & vbCrLf
                                log = log & ". @prod_name= " & .Item("cart_product_name") & vbCrLf
                                log = log & ". @nc=" & nc & vbCrLf
                                log = log & ". @product_tax_code=" & .Item("product_tax_code") & vbCrLf
                                log = log & ". @tax_code_rate=" & .Item("tax_code_rate") & vbCrLf
                                log = log & ". @Detail= " & "" & vbCrLf
                                log = log & ". @product_sale_price= " & .Item("product_sale_price") & vbCrLf
                                log = log & ". @Qty= " & .Item("Qty") & vbCrLf
                                log = log & ". @_tempnet= " & _tempnet & vbCrLf
                                log = log & ". @_tempvat= " & _tempvat & vbCrLf
                                log = log & ". @Inv_type= " & "Inv"
                                WriteDebugInfo(log, filename)
                            End If
                            obj.InsertProdMasterDetail(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), Inv_no, .Item("prod_code"), nc, .Item("product_tax_code"), .Item("tax_code_rate"), .Item("cart_product_name"), product_sale_price, .Item("Qty"), _tempnet, _tempvat, "Inv", discountAmount, discountPer)

                        End With
                    Next
                    ' .....End Insert in pro_inv_det..................."
                    ' 
                    '........ start  Updating invoice # in Invoice Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :INFINISHOPS_ORDER_UPDATE_INVOICE_NO For CC (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(4).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If

                    obj.UpDateInvoiceNo(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), Inv_no)
                    '..........End   start  Updating invoice # in Invoice Table.........."
                    '

                    '........ start  Updating invoice # in CLEDGER Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :CXLROBO_UPDATEINVOICENUMBERINCLEDGER. For " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & " (CreateInvoice=Y) "
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If

                    obj.UpDateInvoiceNoInCledger(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), Inv_no)
                    ' ..........End   start  Updating invoice # in CLEDGER Table.........."
                    '' 
                End If
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(4).Rows(J).Item("ccstatus") = "Y") Then '' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "Y" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), "*", CXLR_Code, CXL_Msg, NormalizeData.Tables(4).Rows(J).Item("ProcessType"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(4).Rows(J).Item("MerchantId"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(4).Rows(J).Item("trackid"), NormalizeData.Tables(4).Rows(J).Item("sender"), "Y")

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "P" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(4).Rows(J).Item("ProcessType"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(4).Rows(J).Item("MerchantId"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(4).Rows(J).Item("trackid"), NormalizeData.Tables(4).Rows(J).Item("sender"), "P")

                End If
                ' ...End................... Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment............"
                ' 
                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(J).Item("MerchantId"), NormalizeData.Tables(4).Rows(J).Item("CLoginId"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(4).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)

            End If

            '...... start Update Credit card in RFollowUp table.......................
            'If ChkLog.Checked = False Then
            '    log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard  For " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & "  (CreateInvoice=Y). "
            '    log = log & ". Having Parameters: " & vbCrLf
            '    log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
            '    log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
            '    log = log & ". @CxlMessage= " & CXL_Msg & vbCrLf
            '    log = log & ". @TranStatus= " & "Y"
            '    WriteDebugInfo(log, filename)
            'End If
            'obj.UpdateCreditCard(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), CXL_Msg, "Y")
            ' ...... end Update Credit card in RFollowUp table.......................
            ' 
            'If (NormalizeData.Tables(4).Rows(J).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
            '    If ChkLog.Checked = False Then
            '        log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
            '        log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For " & NormalizeData.Tables(4).Rows(J).Item("ProcessType") & " Credit Card(CreateInvoice=Y). "
            '        log = log & ". Having Parameters: " & vbCrLf
            '        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
            '        log = log & ". @Amount= " & NormalizeData.Tables(4).Rows(J).Item("Amount") & vbCrLf
            '        log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
            '        log = log & ". @TransactionType= " & NormalizeData.Tables(4).Rows(J).Item("TransactionType") & vbCrLf
            '        log = log & ". @Inv_no= " & Inv_no
            '        WriteDebugInfo(log, filename)
            '    End If
            '    ' ....start update infinishopmainDB Mledger table................
            '    obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Amount"), NormalizeData.Tables(4).Rows(J).Item("TrackID"), NormalizeData.Tables(4).Rows(J).Item("TransactionType"), Inv_no)
            'End If

            ' ........ start .....Posting Invoice ............... 
            'Dim Post As New InvoicePostWS.AccountsProService
            'Post.Timeout = 3 * 60 * 1000
            'If ChkLog.Checked = False Then
            '    log = ". Invoices To Post of Inv No: For SuccessFull CreditCard " & vbCrLf
            '    log = log & ". Having Parameters: " & vbCrLf
            '    log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
            '    log = log & ". @inv_no= " & Inv_no & vbCrLf
            '    log = log & ". MTS= " & MTS
            '    WriteDebugInfo(log, filename)
            'End If
            'Dim b As String = Post.CXLRobot_PostInvoice(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), Inv_no)
            'If b <> "0" Then
            '    SendEmail("Merchant ID: " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & ", Order ID: " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & ", Invoice no: " & Inv_no & ", Response from Post Invoice: " & b)
            'End If
            'If ChkLog.Checked = False Then
            '    log = ". End of Invoices To Post of Inv No: For SuccessFull CreditCard " & vbCrLf
            '    log = log & ". Having Code Return: " & b
            '    WriteDebugInfo(log, filename)
            'End If
            ' ........ end .....Posting Invoice ............... 

            'Checking Referral Order (by Saad on request of Ashuar 14/07/2008)
            log = ". Checking Referral Order"
            log = log & ". Having Parameters: " & vbCrLf
            log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
            log = log & ". @Customer_Id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_Id") & vbCrLf
            log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf

            Dim ds As DataSet = obj.GetMerchantRefferalOrder(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Customer_Id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    log = log & ". RECORD FOUND while checking Referral Order" & vbCrLf
                Else
                    log = log & ". Record Not found while checking Referral Order" & vbCrLf
                End If
            Else
                log = log & ". Record Not found while checking Referral Order" & vbCrLf
            End If

            log = log & "Exception :" & obj.GetExcept
            WriteDebugInfo(log, filename)
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    log = log & ". Paying Commision: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @CustomerID= " & NormalizeData.Tables(4).Rows(J).Item("Customer_Id") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                    Try
                        Dim dsPay As DataSet = obj.REFERRAL_PAYCOMMISSION(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Customer_Id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                        log = log & "PayCommission Message ID: " & dsPay.Tables(0).Rows(0).Item("MessageID")
                        log = log & "PayCommission Message Text: " & dsPay.Tables(0).Rows(0).Item("MessageText")
                    Catch ex As Exception
                        log = log & "Paying Commision - Exception :" & ex.Message & vbCrLf
                    End Try
                    log = log & "Exception :" & obj.GetExcept
                    WriteDebugInfo(log, filename)
                End If
            End If

            If (NormalizeData.Tables(4).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    log = ". Update Status of MYSQL " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @CloginId= " & NormalizeData.Tables(4).Rows(J).Item("CloginId") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                    log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                    log = log & ". @CsMessage= " & CsMessage & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(4).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @StatusFromCs= " & "Y" & vbCrLf
                    log = log & ". @ResponseCode_Cs= " & ResponseCode_Cs
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(4).Rows(J).Item("CloginId"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, NormalizeData.Tables(4).Rows(J).Item("TrackID"), "Y", ResponseCode_Cs, Inv_no)

            ElseIf (NormalizeData.Tables(4).Rows(J).Item("sender") = "AC") Then

                If (NormalizeData.Tables(4).Rows(J).Item("ccstatus") = "Y") Then
                    If ChkLog.Checked = False Then
                        log = ". Calling EnabledServices Method For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @Customer_Id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_Id") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @IsOrderProcess= " & "True" & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(4).Rows(J).Item("ProcessType")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjService = New ServiceActivation.ServiceActivation
                    Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(4).Rows(J).Item("Customer_Id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), True, NormalizeData.Tables(4).Rows(J).Item("ProcessType"))

                End If

            ElseIf (NormalizeData.Tables(4).Rows(J).Item("sender") = "IR") Then

                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                ''Infinishops Webservice
                'Try
                '    Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                '    info.CustomerID = NormalizeData.Tables(4).Rows(J).Item("Customer_Id")
                '    info.IsOrderSuccess = True
                '    info.MerchantID = NormalizeData.Tables(4).Rows(J).Item("MerchantID")
                '    info.OrderID = NormalizeData.Tables(4).Rows(J).Item("OrderID")
                '    'If CType(NormalizeData.Tables(4).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                '    info.PayMode = Io.InfiniShops.PaymentMode.CR
                '    'Else
                '    '    info.PayMode = Io.InfiniShops.PaymentMode.CB
                '    'End If
                '    If ChkLog.Checked = False Then
                '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender")
                '        WriteDebugInfo(log, filename)
                '    End If
                '    ObjIo = New Io.InfiniShops.ServiceActivation
                '    Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)
                'Catch ex As Exception
                '    log = log & "Except:. Calling InfiniShops.EnabledServices:" & ex.Message & " , Merchant ID =" & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & ", Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID")
                '    WriteDebugInfo(log, filename)
                '    SendEmail("Exception:. Calling InfiniShops.EnabledServices:" & ex.Message & " , Merchant ID =" & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & ", Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                'End Try
                ''---------------


                ''Reseller Webservice
                'Try
                '    Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail ' ServiceActivation.ProductDetail
                '    Dim count As Integer
                '    For count = 0 To DataS.Tables(0).Rows.Count - 1
                '        Product(count) = New com.reseller.webservices.ProductDetail
                '        Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                '        Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                '        Product(count).OrderType = Datas.Tables(0).Rows(count).Item("OrderType")
                '    Next
                '    If ChkLog.Checked = False Then
                '        log = ". calling Web service GETBIZINFO method for Credit Card For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                '        log = log & ". Having Parameters: " & vbCrLf
                '        log = log & ". @MerchantLoginID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantLoginID") & vbCrLf
                '        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                '        log = log & ". @Customer_id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_id") & vbCrLf
                '        'log = log & ". @Product= " & Product & vbCrLf
                '        log = log & ". @PayStatus=" & "Y"
                '        WriteDebugInfo(log, filename)
                '    End If
                '    ResellerService = New com.reseller.webservices.IShopOrderHander
                '    ResellerService.GetBizInfo(NormalizeData.Tables(4).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), NormalizeData.Tables(4).Rows(J).Item("Customer_id"), Product, "Y")
                'Catch ex As Exception
                '    log = log & "Except:. Reseller Webservice. Getbizinfo:" & ex.Message & " , Merchant Login ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantLoginID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID")
                '    WriteDebugInfo(log, filename)
                '    SendEmail("Exception:. Reseller Webservice. Getbizinfo:" & ex.Message & " , Merchant Login ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantLoginID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                'End Try
                ''----------------

                Try
                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(4).Rows(J).Item("OrderID"), NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(4).Rows(J).Item("Customer_Id"), "Y", "Y", "CR")
                    If ChkLog.Checked = False Then
                        log = ". Dumping data for MPI Reseller" & vbCrLf
                        log = log & "Exception:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = ". Dumping data for MPI Reseller" & vbCrLf
                    log = log & "Exception:" & ex.Message
                    WriteDebugInfo(log, filename)
                End Try

                'Added by Saad 03/07/2008
                'Coupon webservice 'Added by Saad 03/07/2008
                Try
                    If ChkLog.Checked = False Then
                        log = ". calling COUPON Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @Customer_id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_id")
                        WriteDebugInfo(log, filename)
                    End If

                    Dim couponService As New com.infinishops.couponsystem.EmailCoupon
                    Dim couponServiceResult As com.infinishops.couponsystem.ErrorCodesInfo = couponService.EmailToCustomer(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Customer_id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                    If ChkLog.Checked = False Then
                        log = ". Afer calling COUPON Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @ErrorCode= " & couponServiceResult.ErrorCode & vbCrLf
                        log = log & ". @ErrorDescription= " & couponServiceResult.ErrorDescription
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Coupon Webservice:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID")

                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Coupon Webservice:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                End Try
                '---------------------------------------

                'Add Supplier Webservice
                Try
                    If ChkLog.Checked = False Then
                        log = ". calling ADD SUPPLIER Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @Customer_id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_id")
                        WriteDebugInfo(log, filename)
                    End If

                    Dim addSupplier As New com.infinishops.addsupplier.AddSupplier
                    Dim addSupplierResult As com.infinishops.addsupplier.ErrorCodesInfo = addSupplier.AddSupplier(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Customer_id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                    If ChkLog.Checked = False Then
                        log = ". Afer calling ADD SUPPLIER Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @ErrorCode= " & addSupplierResult.ErrorCode & vbCrLf
                        log = log & ". @ErrorDescription= " & addSupplierResult.ErrorDescription
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Add Supplier:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID")

                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Add Supplier:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                End Try
                '---------------------------

            ElseIf (NormalizeData.Tables(4).Rows(J).Item("sender") = "IN") Then

                'Commented by saad 28/01/08 on request of Yousuf
                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                'Infinishops Webservice
                Try
                    Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                    info.CustomerID = NormalizeData.Tables(4).Rows(J).Item("Customer_Id")
                    info.IsOrderSuccess = True
                    info.MerchantID = NormalizeData.Tables(4).Rows(J).Item("MerchantID")
                    info.OrderID = NormalizeData.Tables(4).Rows(J).Item("OrderID")
                    'If CType(NormalizeData.Tables(4).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    '    info.PayMode = Io.InfiniShops.PaymentMode.CC
                    'Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CR
                    'End If
                    If ChkLog.Checked = False Then
                        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender")
                        WriteDebugInfo(log, filename)
                    End If

                    Dim objIShop As New com.infinishops.io.IShopServiceActivation
                    Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

                    If ChkLog.Checked = False Then
                        log = ". calling their Web service ENABLED SERVICES for Bank .ErrorCode= " & Result.ERRORCODE & " ResultDesciption=" & Result.ERRORDESC
                        WriteDebugInfo(log, filename)
                    End If

                Catch ex As Exception
                    log = log & "Except:. Infinishops Webservice:" & ex.Message
                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Infinishops Webservice:" & ex.Message)
                End Try
                '----------------


                'Added by Saad 03/07/2008
                'Coupon Webservice
                If ChkLog.Checked = False Then
                    log = ". calling COUPON Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @Customer_id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_id")
                    WriteDebugInfo(log, filename)
                End If
                Try
                    Dim couponService As New com.infinishops.couponsystem.EmailCoupon
                    Dim couponServiceResult As com.infinishops.couponsystem.ErrorCodesInfo = couponService.EmailToCustomer(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Customer_id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                    If ChkLog.Checked = False Then
                        log = ". Afer calling COUPON Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @ErrorCode= " & couponServiceResult.ErrorCode & vbCrLf
                        log = log & ". @ErrorDescription= " & couponServiceResult.ErrorDescription
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Coupon Webservice:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID")
                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Coupon Webservice:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                End Try

                '---------------------------------------

                'Add Supplier Webservice
                Try
                    If ChkLog.Checked = False Then
                        log = ". calling ADD SUPPLIER Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(4).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @Customer_id= " & NormalizeData.Tables(4).Rows(J).Item("Customer_id")
                        WriteDebugInfo(log, filename)
                    End If

                    Dim addSupplier As New com.infinishops.addsupplier.AddSupplier
                    Dim addSupplierResult As com.infinishops.addsupplier.ErrorCodesInfo = addSupplier.AddSupplier(NormalizeData.Tables(4).Rows(J).Item("MerchantID"), NormalizeData.Tables(4).Rows(J).Item("Customer_id"), NormalizeData.Tables(4).Rows(J).Item("OrderID"))

                    If ChkLog.Checked = False Then
                        log = ". Afer calling ADD SUPPLIER Service For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender") & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @ErrorCode= " & addSupplierResult.ErrorCode & vbCrLf
                        log = log & ". @ErrorDescription= " & addSupplierResult.ErrorDescription
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = log & "Except:. Add Supplier:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID")
                    WriteDebugInfo(log, filename)
                    SendEmail("Exception:. Add Supplier:" & ex.Message & " , Merchant ID = " & NormalizeData.Tables(4).Rows(J).Item("MerchantID") & " , Order ID = " & NormalizeData.Tables(4).Rows(J).Item("OrderID"))
                End Try

                '---------------------------

            ElseIf ((NormalizeData.Tables(4).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(4).Rows(J).Item("Sender") = "EX") And NormalizeData.Tables(4).Rows(J).Item("OrderID") = 0) Then

                obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(4).Rows(J).Item("MerchantId"), NormalizeData.Tables(4).Rows(J).Item("CloginId"), NormalizeData.Tables(4).Rows(J).Item("trackid"), NormalizeData.Tables(4).Rows(J).Item("invoice_no"))


            ElseIf (NormalizeData.Tables(4).Rows(J).Item("sender") = "IB") Then

                If ChkLog.Checked = False Then
                    log = ". calling their Web service method UpdateBuyerPointStatus Place  For Sender " & NormalizeData.Tables(4).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                ObjBuyer = New BPtsPayment.InfiniBPPay
                ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(4).Rows(J).Item("TrackID"), True, Inv_no)

            ElseIf (NormalizeData.Tables(4).Rows(J).Item("sender") = "IM") Then

                If ChkLog.Checked = False Then
                    log = ". calling their Web service InfiniMarket Place  For IM "
                    WriteDebugInfo(log, filename)
                End If
                Dim IM_Xml As String
                IM_Xml = "<CustomerOrderInfo>" & _
                         "<CustomerID>" & NormalizeData.Tables(4).Rows(J).Item("Customer_id") & "</CustomerID>" & _
                         "<CustomerUID>" & NormalizeData.Tables(4).Rows(J).Item("CloginId") & "</CustomerUID>" & _
                         "<MerchantID>" & NormalizeData.Tables(4).Rows(J).Item("MerchantId") & "</MerchantID>" & _
                         "<MerchantUID>" & NormalizeData.Tables(4).Rows(J).Item("MerchantLoginId") & "</MerchantUID>" & _
                         "<OrderAmount>" & NormalizeData.Tables(4).Rows(J).Item("Amount") & "</OrderAmount>" & _
                         "<OrderStatus> Processed </OrderStatus>" & _
                         "<OrderID>" & NormalizeData.Tables(4).Rows(J).Item("OrderID") & "</OrderID>" & _
                         "<TrackID>" & NormalizeData.Tables(4).Rows(J).Item("Trackid") & "</TrackID>" & _
                        "</CustomerOrderInfo>"

                'Dim T As String
                'ObjInfiniMarketPlace=new InfiniMarket._Default
                ''  T = ObjInifiniMarketPlace.CustomerOrderProcess(IM_Xml)

                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                info.CustomerID = NormalizeData.Tables(4).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = True
                info.MerchantID = NormalizeData.Tables(4).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(4).Rows(J).Item("OrderID")
                'If CType(NormalizeData.Tables(4).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                '    info.PayMode = Io.InfiniShops.PaymentMode.CC
                'Else
                info.PayMode = Io.InfiniShops.PaymentMode.CR
                'End If

                If ChkLog.Checked = False Then
                    log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(4).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)
                '---------------------

                'Else
                '    If ChkLog.Checked = False Then
                '        log = ". Update Status of Invalid  SENDER by SP:CXLROBO_UPDATEDATA."
                '        WriteDebugInfo(log, filename)
                '    End If
                '    obj.UpdateResponse_New(NormalizeData.Tables(4).Rows(J).Item("MerchantId"), NormalizeData.Tables(4).Rows(J).Item("CLoginId"), NormalizeData.Tables(4).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(4).Rows(J).Item("trackid"))


            End If
        End Sub

        Private Sub Suspend(ByVal J As Integer, ByVal CxlR_Code As String, ByVal Cxl_Msg As String)


            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            If ChkLog.Checked = False Then
                log = ". For Un Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
            End If
            ResponseCode_Cs = "-1"    ' CxlR_code = "30" '' Credit card Decline from CXL
            If (Cxl_Msg = "" Or CxlR_Code = "30") Then

                CsMessage = "CXL DECLINE CREDIT CARD"
            Else
                CsMessage = Cxl_Msg
            End If

            ' ...... start Update Credit card in RFollowUp table.......................
            If (NormalizeData.Tables(2).Rows(J).Item("ProcessType") = "cc" Or NormalizeData.Tables(2).Rows(J).Item("ProcessType") = "CC") Then
                If ChkLog.Checked = False Then
                    log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard . "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @CxlMessage= " & Cxl_Msg & vbCrLf
                    log = log & ". @TranStatus= " & "n"
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateCreditCard(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), Cxl_Msg, "N")
                '...... end Update Credit card in RFollowUp table.......................
            End If

            If (NormalizeData.Tables(2).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(2).Rows(J).Item("Sender") = "EX") Then

                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then ' that means full payment
                    '......Start Cledger and Request Table  on full and partial payment........."
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                Else
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    '......end Cledger and Request Table  on full and partial payment........."
                End If
                If ChkLog.Checked = False Then
                    '   log = log & vbNewLine & Now & ".Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA for unsuccessfull credit card . For PR,EX "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, NormalizeData.Tables(2).Rows(J).Item("invoice_no"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_Code, Cxl_Msg)

            Else
                'FOR IN,AC,FH,IM,IR 
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "D")

                Else
                    If ChkLog.Checked = False Then
                        '   log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "P")

                End If
                '......end  Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If ChkLog.Checked = False Then
                    '       log = log & vbNewLine & Now & ".Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_Code, Cxl_Msg)
            End If

            If (NormalizeData.Tables(2).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    'log = log & vbNewLine & Now & ".Update my sql status . "
                    log = ". Update my sql status . "
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), CxlR_Code, Cxl_Msg, CsMessage, NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", ResponseCode_Cs)

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "AC") Then
                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then
                    If ChkLog.Checked = False Then
                        log = ". Calling Enable Services (UnSuccesfull Cxl Transaction) . against custid=" & NormalizeData.Tables(2).Rows(J).Item("Customer_Id") & "and order_id" & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjService = New ServiceActivation.ServiceActivation
                    Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), False, NormalizeData.Tables(2).Rows(J).Item("ProcessType"))

                End If

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IR") Then

                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                ''Infinishop webservice
                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                'info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                'info.IsOrderSuccess = False
                'info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                'info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                'info.DotNotSendDeclineEmail = True
                'If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                '    info.PayMode = Io.InfiniShops.PaymentMode.CC
                'Else
                '    info.PayMode = Io.InfiniShops.PaymentMode.CB
                'End If
                'ObjIo = New Io.InfiniShops.ServiceActivation
                'Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                'If ChkLog.Checked = False Then
                '    ' log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case(invalid data) . For IR "
                '    log = ". calling their Web service ENABLED SERVICES for UnSuccessfull CreditCard . For IR Result ErroeCode= " & result.ERRORCODE & " ResultDesciption=" & result.ERRORDESC
                '    WriteDebugInfo(log, filename)
                'End If
                ''-----------


                ''Reseller Webservice
                'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail 'ServiceActivation.ProductDetail
                'Dim count As Integer
                'For count = 0 To DataS.Tables(0).Rows.Count - 1
                '    Product(count) = New com.reseller.webservices.ProductDetail
                '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                'Next
                'If ChkLog.Checked = False Then
                '    '   log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case . For IR "
                '    log = ". calling their Web service GET BIZ info method for decline case . For IR "
                '    WriteDebugInfo(log, filename)
                'End If
                'ResellerService = New com.reseller.webservices.IShopOrderHander
                'ResellerService.Timeout = 4 * 60 * 1000
                'ResellerService.GetBizInfo(NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("Customer_id"), Product, "N")
                ''-----------

                Try
                    Dim PayModeMPI As String
                    If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                        PayModeMPI = "CC"
                    Else
                        PayModeMPI = "CB"
                    End If

                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), "N", "N", PayModeMPI)
                    If ChkLog.Checked = False Then
                        log = ". Dumping data for MPI Reseller" & vbCrLf
                        log = log & "Exception:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = ". Dumping data for MPI Reseller" & vbCrLf
                    log = log & "Exception:" & ex.Message
                    WriteDebugInfo(log, filename)
                End Try


            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IN") Then

                Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = False
                info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                info.DotNotSendDeclineEmail = True
                If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                End If
                ObjIo = New Io.InfiniShops.ServiceActivation
                Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                If ChkLog.Checked = False Then
                    log = ". calling their Web service ENABLED SERVICES for UnSuccessfull CreditCard . For IN Result ErroeCode= " & result.ERRORCODE & " ResultDesciption=" & result.ERRORDESC
                    WriteDebugInfo(log, filename)
                End If
            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(2).Rows(J).Item("Sender") = "EX") Then

                obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("invoice_no"))

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IB") Then
                ObjBuyer = New BPtsPayment.InfiniBPPay
                ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(2).Rows(J).Item("trackid"), False)

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IM") Then

                If ChkLog.Checked = False Then
                    log = log & vbNewLine & Now & ". calling their Web service InfiniMarket Place  For IM "
                    WriteDebugInfo(log, filename)
                End If
                Dim IM_Xml As String
                IM_Xml = "<CustomerOrderInfo>" & _
                         "<CustomerID>" & NormalizeData.Tables(2).Rows(J).Item("Customer_id") & "</CustomerID>" & _
                         "<CustomerUID>" & NormalizeData.Tables(2).Rows(J).Item("CloginId") & "</CustomerUID>" & _
                         "<MerchantID>" & NormalizeData.Tables(2).Rows(J).Item("MerchantId") & "</MerchantID>" & _
                         "<MerchantUID>" & NormalizeData.Tables(2).Rows(J).Item("MerchantLoginId") & "</MerchantUID>" & _
                         "<OrderAmount>" & NormalizeData.Tables(2).Rows(J).Item("Amount") & "</OrderAmount>" & _
                         "<OrderStatus> Declined </OrderStatus>" & _
                         "<OrderID>" & NormalizeData.Tables(2).Rows(J).Item("OrderID") & "</OrderID>" & _
                         "<TrackID>" & NormalizeData.Tables(2).Rows(J).Item("Trackid") & "</TrackID>" & _
                        "</CustomerOrderInfo>"

                '    Dim T As String
                'ObjInfiniMarketPlace=new InfiniMarket._Default
                '    T = ObjInifiniMarketPlace.CustomerOrderProcess(IM_Xml)

                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = False
                info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                info.DotNotSendDeclineEmail = True

                If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                End If

                If ChkLog.Checked = False Then
                    log = ". Calling IShopServiceActivation.EnabledServices Method for UnSuccessfull CreditCard For sender=" & NormalizeData.Tables(2).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

            Else
                If ChkLog.Checked = False Then
                    log = ". Update Status of Invalid SENDER by SP:CXLROBO_UPDATEDATA."
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(J).Item("trackid"), CxlIdentity, MPI_SessionID)


            End If
        End Sub

        Private Sub SuccessfulCXLFOR_BP(ByVal J As Integer, ByVal CXLR_Code As String, ByVal CXL_Msg As String)

            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            ResponseCode_Cs = "0"
            CsMessage = CXL_Msg

            Dim Inv_no As String

            Dim ODetail As DataSet

            ' ........... start Update Customer Type in Customer Table.........."
            If ChkLog.Checked = False Then
                log = ". For Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
                log = ". Update Customer Type By SP: CXLROBO_UPDATECUSTOMERTYPE. "
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @Customer_ID= " & NormalizeData.Tables(3).Rows(J).Item("Customer_ID") & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                WriteDebugInfo(log, filename)
            End If
            obj.UpdateCustomerType(NormalizeData.Tables(3).Rows(J).Item("Customer_ID"), NormalizeData.Tables(3).Rows(J).Item("MerchantID"))
            '................. End Customer type updation..............."

            'If (NormalizeData.Tables(3).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(3).Rows(J).Item("Sender") = "EX" Or UCase(ProcessType) = "BP") Then
            If (UCase(ProcessType) = "BP") Then
                ' ......Start  Cledger and Request Table  on full and partial payment"........
                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "Y")

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "Y")

                End If
                '......... End Cledger and Request Table  on full and partial payment"............. 
                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                'obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(3).Rows(J).Item("invoice_no"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), CXLR_Code, CXL_Msg)

            Else

                '''''''''''''''' For FH ,IN,AC,IB,IM,IR .............

                '..................start  Update Invoice Table ..............." 
                If ChkLog.Checked = False Then
                    log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS. "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID" & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID" & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @PaidAmount" & NormalizeData.Tables(3).Rows(J).Item("PaidAmount") & vbCrLf
                    log = log & ". @ccStatus" & NormalizeData.Tables(3).Rows(J).Item("ccStatus")
                    WriteDebugInfo(log, filename)
                End If
                obj.UpDatePayAmount(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("Amount"), NormalizeData.Tables(3).Rows(J).Item("ccStatus"))
                '............... End Start Update Invoice Table pay_amt field etc...................."
                Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))

                If ChkLog.Checked = False Then
                    log = ". Getting Order Detail by SP :INFINISHOPS_ORDER_ADDDETAILS . "
                    WriteDebugInfo(log, filename)
                End If
                ' ...............start. Insert order details in inv_det table............."
                'Dim X As Integer
                'For X = 0 To DataS.Tables(0).Rows.Count - 1
                '    obj.OrderAddDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "@ORD" + NormalizeData.Tables(3).Rows(J).Item("OrderID"), DataS.Tables(0).Rows(X).Item("Product_ID"), DataS.Tables(0).Rows(X).Item("prod_code"), DataS.Tables(0).Rows(X).Item("Qty"), DataS.Tables(0).Rows(X).Item("product_sale_price"), DataS.Tables(0).Rows(X).Item("product_tax_code"), DataS.Tables(0).Rows(X).Item("tax_code_rate"), DataS.Tables(0).Rows(X).Item("unitprice"), "S")
                '    If ChkLog.Checked = False Then
                '        log = ". Adding Order Detail . "
                '        WriteDebugInfo(log, filename)
                '    End If
                'Next
                ' ............... end Insert order details in inv_det table..........."
                Dim Copy2ProWeb As Boolean = False

                If (obj.CheckServiceEnable(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "118") = True Or obj.CheckServiceEnable(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "232") = True) Then

                    ''''............... Sttart Insert in pro_invoice  to get invoice #..............."
                    Dim defaultBack_nc As String = obj.GetLedgerNC(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "Default Bank")
                    Dim deliveryExpences_nc As String = obj.GetLedgerNC(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "Delivery Expenses")
                    If ChkLog.Checked = False Then
                        log = ". Invoice Creation in Pro_invoice by SP:ACCOUNTSPRO_UPDATEPROINVOICE For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(3).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @InvoiceNumber= " & "0" & vbCrLf
                        log = log & ". @Inv_date=" & Date.Now() & vbCrLf
                        log = log & ". @Cust_det=" & "" & vbCrLf
                        log = log & ". @product_tax_code=" & DataS.Tables(0).Rows(0).Item("product_tax_code") & vbCrLf
                        log = log & ". @tax_Code_rate=" & DataS.Tables(0).Rows(0).Item("tax_Code_rate") & vbCrLf
                        log = log & ". @GlobalTC= " & "T9" & vbCrLf
                        log = log & ". @GlobalTCrate= " & "0" & vbCrLf
                        log = log & ". @defaultBack_nc= " & defaultBack_nc & vbCrLf
                        log = log & ". @deliveryExpences_nc= " & deliveryExpences_nc & vbCrLf
                        log = log & ". @Inv_type= " & "Inv" & vbCrLf
                        log = log & ". @Car_net= " & "0" & vbCrLf
                        log = log & ". @Car_vat= " & "0" & vbCrLf
                        log = log & ". @PaidAmount= " & NormalizeData.Tables(3).Rows(J).Item("PaidAmount") & vbCrLf
                        log = log & ". @CloginID= " & NormalizeData.Tables(3).Rows(J).Item("CloginID") & vbCrLf
                        log = log & ". @Pay_type= " & "Invoice"
                        WriteDebugInfo(log, filename)
                    End If
                    Inv_no = obj.InsertProInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "0", Date.Now(), "", DataS.Tables(0).Rows(0).Item("product_tax_code"), DataS.Tables(0).Rows(0).Item("tax_Code_rate"), "T9", "0", defaultBack_nc, deliveryExpences_nc, "Inv", 0, 0, NormalizeData.Tables(3).Rows(J).Item("PaidAmount"), NormalizeData.Tables(3).Rows(J).Item("CloginID"), "Invoice", "bp")
                    ''.........End .............Insert in pro_invoice  to get invoice #...
                    ''
                    ''............. Sttart Insert in pro_inv_det  .............."

                    Dim i As Integer = 0
                    ODetail = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    For i = 0 To ODetail.Tables(0).Rows.Count - 1
                        With ODetail.Tables(0).Rows(i)
                            ' Dim _tempnet As String = FormatNumber(.Item("product_sale_price") * .Item("Qty"), 2, , , TriState.False)
                            'Dim _tempnet As String = FormatNumber(.Item("unitprice") * .Item("Qty"), 2, , , TriState.False)
                            Dim _tempvat As String = FormatNumber(.Item("Tax_amount"), 2, , , TriState.False)

                            Dim discountAmount As Double = .Item("Discount")
                            Dim product_sale_price As Double = (.Item("product_sale_price"))
                            Dim discountPer As Double '= .Item("product_sale_price") / discountAmount

                            Dim _tempnet As String = FormatNumber(product_sale_price * .Item("Qty"), 2, , , TriState.False)

                            Dim nc As String
                            If IsDBNull(.Item("nc")) Then
                                nc = "10000"
                            Else
                                nc = .Item("nc")
                            End If
                            If ChkLog.Checked = False Then
                                log = ". Inserting Order Detail by SP: ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS For Bank(CreateInvoice=Y) For Sender. " & NormalizeData.Tables(3).Rows(J).Item("Sender") & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                                log = log & ". @inv_no= " & Inv_no & vbCrLf
                                log = log & ". @prod_code= " & .Item("prod_code") & vbCrLf
                                log = log & ". @prod_name= " & .Item("cart_product_name") & vbCrLf
                                log = log & ". @nc=" & nc & vbCrLf
                                log = log & ". @product_tax_code=" & .Item("product_tax_code") & vbCrLf
                                log = log & ". @tax_code_rate=" & .Item("tax_code_rate") & vbCrLf
                                log = log & ". @Detail= " & "" & vbCrLf
                                log = log & ". @product_sale_price= " & .Item("product_sale_price") & vbCrLf
                                log = log & ". @Qty= " & .Item("Qty") & vbCrLf
                                log = log & ". @_tempnet= " & _tempnet & vbCrLf
                                log = log & ". @_tempvat= " & _tempvat & vbCrLf
                                log = log & ". @Inv_type= " & "Inv"
                                WriteDebugInfo(log, filename)
                            End If
                            obj.InsertProdMasterDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), Inv_no, .Item("prod_code"), nc, .Item("product_tax_code"), .Item("tax_code_rate"), .Item("cart_product_name"), product_sale_price, .Item("Qty"), _tempnet, _tempvat, "Inv", discountAmount, discountPer)

                        End With
                    Next
                    ' .....End Insert in pro_inv_det..................."
                    ' 
                    '........ start  Updating invoice # in Invoice Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :INFINISHOPS_ORDER_UPDATE_INVOICE_NO For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(3).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If

                    obj.UpDateInvoiceNo(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), Inv_no)
                    '..........End   start  Updating invoice # in Invoice Table.........."
                    '

                    '........ start  Updating invoice # in CLEDGER Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :CXLROBO_UPDATEINVOICENUMBERINCLEDGER. For Bank (CreateInvoice=Y) "
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If

                    obj.UpDateInvoiceNoInCledger(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), Inv_no)
                    ' ..........End   start  Updating invoice # in CLEDGER Table.........."
                    '' 
                End If
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then '' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(3).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "Y" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "Y")

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status of CreditCard " & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(3).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "P" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "P")

                End If
                ' ...End................... Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment............"
                ' 

                'If ChkLog.Checked = False Then
                '    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                '    WriteDebugInfo(log, filename)
                'End If
                'obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(1).Rows(J).Item("CLoginId"), NormalizeData.Tables(1).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(1).Rows(J).Item("TrackID"), CXLR_Code, CXL_Msg)

            End If

            '...... start Update Credit card in RFollowUp table.......................
            'If (NormalizeData.Tables(3).Rows(J).Item("ProcessType") = "cc" Or NormalizeData.Tables(3).Rows(J).Item("ProcessType") = "CC") Then
            '    If ChkLog.Checked = False Then
            '        log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard  For CreditCard(CreateInvoice=Y). "
            '        log = log & ". Having Parameters: " & vbCrLf
            '        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
            '        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
            '        log = log & ". @CxlMessage= " & CXL_Msg & vbCrLf
            '        log = log & ". @TranStatus= " & "Y"
            '        WriteDebugInfo(log, filename)
            '    End If
            '    obj.UpdateCreditCard(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), CXL_Msg, "Y")
            '    ' ...... end Update Credit card in RFollowUp table.......................
            '    ' 
            '    If (NormalizeData.Tables(3).Rows(J).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
            '        If ChkLog.Checked = False Then
            '            log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
            '            log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For Credit Card(CreateInvoice=Y). "
            '            log = log & ". Having Parameters: " & vbCrLf
            '            log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
            '            log = log & ". @Amount= " & NormalizeData.Tables(3).Rows(J).Item("Amount") & vbCrLf
            '            log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
            '            log = log & ". @TransactionType= " & NormalizeData.Tables(3).Rows(J).Item("TransactionType") & vbCrLf
            '            log = log & ". @Inv_no= " & Inv_no
            '            WriteDebugInfo(log, filename)
            '        End If
            '        '''' ....start update infinishopmainDB Mledger table................
            '        obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("Amount"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), NormalizeData.Tables(3).Rows(J).Item("TransactionType"), Inv_no)
            '    End If

            'End If

            If (NormalizeData.Tables(3).Rows(J).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
                If ChkLog.Checked = False Then
                    log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
                    log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For Credit Card(CreateInvoice=Y). "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @Amount= " & NormalizeData.Tables(3).Rows(J).Item("Amount") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @TransactionType= " & NormalizeData.Tables(3).Rows(J).Item("TransactionType") & vbCrLf
                    log = log & ". @Inv_no= " & Inv_no
                    WriteDebugInfo(log, filename)
                End If
                '''' ....start update infinishopmainDB Mledger table................
                obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("Amount"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), NormalizeData.Tables(3).Rows(J).Item("TransactionType"), Inv_no)
            End If

            'If (NormalizeData.Tables(1).Rows(J).Item("sender") = "FH") Then
            '    If ChkLog.Checked = False Then
            '        log = ". Update Status of MYSQL " & vbCrLf
            '        log = log & ". Having Parameters: " & vbCrLf
            '        log = log & ". @CloginId= " & NormalizeData.Tables(1).Rows(J).Item("CloginId") & vbCrLf
            '        log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(J).Item("OrderID") & vbCrLf
            '        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
            '        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
            '        log = log & ". @CsMessage= " & CsMessage & vbCrLf
            '        log = log & ". @TrackID= " & NormalizeData.Tables(1).Rows(J).Item("TrackID") & vbCrLf
            '        log = log & ". @StatusFromCs= " & "Y" & vbCrLf
            '        log = log & ". @ResponseCode_Cs= " & ResponseCode_Cs
            '        WriteDebugInfo(log, filename)
            '    End If
            '    UpdateMySqlStatus(NormalizeData.Tables(1).Rows(J).Item("CloginId"), NormalizeData.Tables(1).Rows(J).Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, NormalizeData.Tables(1).Rows(J).Item("TrackID"), "Y", ResponseCode_Cs, Inv_no)

            'ElseIf (NormalizeData.Tables(1).Rows(J).Item("sender") = "AC") Then

            '    If (NormalizeData.Tables(1).Rows(J).Item("ccstatus") = "Y") Then
            '        If ChkLog.Checked = False Then
            '            log = ". Calling EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(J).Item("sender")
            '            log = log & ". Having Parameters: " & vbCrLf
            '            log = log & ". @Customer_Id= " & NormalizeData.Tables(1).Rows(J).Item("Customer_Id") & vbCrLf
            '            log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(J).Item("OrderID") & vbCrLf
            '            log = log & ". @IsOrderProcess= " & "True" & vbCrLf
            '            log = log & ". @ProcessType= " & NormalizeData.Tables(1).Rows(J).Item("ProcessType")
            '            WriteDebugInfo(log, filename)
            '        End If
            '        ObjService = New ServiceActivation.ServiceActivation
            '        Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(1).Rows(J).Item("Customer_Id"), NormalizeData.Tables(1).Rows(J).Item("OrderID"), True, NormalizeData.Tables(1).Rows(J).Item("ProcessType"))

            '    End If

            'ElseIf (NormalizeData.Tables(1).Rows(J).Item("sender") = "IR") Then

            '    'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(1).Rows(J).Item("MerchantID"), NormalizeData.Tables(1).Rows(J).Item("OrderID"))
            '    'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail
            '    'Dim count As Integer
            '    'For count = 0 To DataS.Tables(0).Rows.Count - 1
            '    '    Product(count) = New com.reseller.webservices.ProductDetail
            '    '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
            '    '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
            '    '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
            '    'Next
            '    'If ChkLog.Checked = False Then
            '    '    log = ". calling Web service GETBIZINFO method for(invalid data) For sender=" & NormalizeData.Tables(1).Rows(J).Item("sender") & vbCrLf
            '    '    log = log & ". Having Parameters: " & vbCrLf
            '    '    log = log & ". @MerchantLoginID= " & NormalizeData.Tables(1).Rows(J).Item("MerchantLoginID") & vbCrLf
            '    '    log = log & ". @OrderID= " & NormalizeData.Tables(1).Rows(J).Item("OrderID") & vbCrLf
            '    '    log = log & ". @Customer_id= " & NormalizeData.Tables(1).Rows(J).Item("Customer_id") & vbCrLf
            '    '    'log = log & ". @Product= " & Product & vbCrLf
            '    '    log = log & ". @PayStatus=" & "Y"
            '    '    WriteDebugInfo(log, filename)

            '    'End If
            '    'ResellerService = New com.reseller.webservices.IShopOrderHander
            '    '' ObjService.GetBizInfo(NormalizeData.Tables(1).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(J).Item("OrderID"), NormalizeData.Tables(1).Rows(J).Item("Customer_id"), Product, "Y")
            '    'ResellerService.GetBizInfo(NormalizeData.Tables(1).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(1).Rows(J).Item("OrderID"), NormalizeData.Tables(1).Rows(J).Item("Customer_id"), Product, "Y")
            '    'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
            '    'info.CustomerID = NormalizeData.Tables(1).Rows(J).Item("Customer_Id")
            '    'info.IsOrderSuccess = True
            '    'info.MerchantID = NormalizeData.Tables(1).Rows(J).Item("MerchantID")
            '    'info.OrderID = NormalizeData.Tables(1).Rows(J).Item("OrderID")
            '    'If CType(NormalizeData.Tables(1).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
            '    '    info.PayMode = Io.InfiniShops.PaymentMode.CC
            '    'Else
            '    '    info.PayMode = Io.InfiniShops.PaymentMode.CB
            '    'End If

            '    'If ChkLog.Checked = False Then
            '    '    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(J).Item("sender")
            '    '    WriteDebugInfo(log, filename)
            '    'End If
            '    'ObjIo = New Io.InfiniShops.ServiceActivation
            '    'Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)


            'ElseIf (NormalizeData.Tables(1).Rows(J).Item("sender") = "IN") Then

            '    Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
            '    info.CustomerID = NormalizeData.Tables(1).Rows(J).Item("Customer_Id")
            '    info.IsOrderSuccess = True
            '    info.MerchantID = NormalizeData.Tables(1).Rows(J).Item("MerchantID")
            '    info.OrderID = NormalizeData.Tables(1).Rows(J).Item("OrderID")
            '    If CType(NormalizeData.Tables(1).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
            '        info.PayMode = Io.InfiniShops.PaymentMode.CC
            '    Else
            '        info.PayMode = Io.InfiniShops.PaymentMode.CB
            '    End If
            '    If ChkLog.Checked = False Then
            '        log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(J).Item("sender")
            '        WriteDebugInfo(log, filename)
            '    End If
            '    ObjIo = New Io.InfiniShops.ServiceActivation
            '    Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)


            '    If ChkLog.Checked = False Then
            '        log = ". calling their Web service ENABLED SERVICES for Bank .ErrorCode= " & Result.ERRORCODE & " ResultDesciption=" & Result.ERRORDESC
            '        WriteDebugInfo(log, filename)
            '    End If
            'ElseIf (NormalizeData.Tables(1).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(1).Rows(J).Item("Sender") = "EX") Then

            '    obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(1).Rows(J).Item("MerchantId"), NormalizeData.Tables(1).Rows(J).Item("CloginId"), NormalizeData.Tables(1).Rows(J).Item("trackid"), NormalizeData.Tables(1).Rows(J).Item("invoice_no"))


            'ElseIf (NormalizeData.Tables(1).Rows(J).Item("sender") = "IB") Then

            '    If ChkLog.Checked = False Then
            '        log = ". calling their Web service method UpdateBuyerPointStatus Place  For Sender " & NormalizeData.Tables(1).Rows(J).Item("sender")
            '        WriteDebugInfo(log, filename)
            '    End If
            '    ObjBuyer = New BPtsPayment.InfiniBPPay

            '    ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(1).Rows(J).Item("TrackID"), True, Inv_no)

            'ElseIf (NormalizeData.Tables(1).Rows(J).Item("sender") = "IM") Then

            '    If ChkLog.Checked = False Then
            '        log = ". calling their Web service InfiniMarket Place  For IM "
            '        WriteDebugInfo(log, filename)
            '    End If
            '    Dim IM_Xml As String
            '    IM_Xml = "<CustomerOrderInfo>" & _
            '             "<CustomerID>" & NormalizeData.Tables(1).Rows(J).Item("Customer_id") & "</CustomerID>" & _
            '             "<CustomerUID>" & NormalizeData.Tables(1).Rows(J).Item("CloginId") & "</CustomerUID>" & _
            '             "<MerchantID>" & NormalizeData.Tables(1).Rows(J).Item("MerchantId") & "</MerchantID>" & _
            '             "<MerchantUID>" & NormalizeData.Tables(1).Rows(J).Item("MerchantLoginId") & "</MerchantUID>" & _
            '             "<OrderAmount>" & NormalizeData.Tables(1).Rows(J).Item("Amount") & "</OrderAmount>" & _
            '             "<OrderStatus> Processed </OrderStatus>" & _
            '             "<OrderID>" & NormalizeData.Tables(1).Rows(J).Item("OrderID") & "</OrderID>" & _
            '             "<TrackID>" & NormalizeData.Tables(1).Rows(J).Item("Trackid") & "</TrackID>" & _
            '            "</CustomerOrderInfo>"

            '    'Dim T As String
            '    ' ObjInifiniMarketPlace = New InfiniMarket._Default
            '    '  T = ObjInifiniMarketPlace.UpdateCustomerInfo(IM_Xml)

            '    Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
            '    info.CustomerID = NormalizeData.Tables(1).Rows(J).Item("Customer_Id")
            '    info.IsOrderSuccess = True
            '    info.MerchantID = NormalizeData.Tables(1).Rows(J).Item("MerchantID")
            '    info.OrderID = NormalizeData.Tables(1).Rows(J).Item("OrderID")
            '    If CType(NormalizeData.Tables(1).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
            '        info.PayMode = Io.InfiniShops.PaymentMode.CC
            '    Else
            '        info.PayMode = Io.InfiniShops.PaymentMode.CB
            '    End If

            '    If ChkLog.Checked = False Then
            '        log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(1).Rows(J).Item("sender")
            '        WriteDebugInfo(log, filename)
            '    End If

            '    Dim objIShop As New com.infinishops.io.IShopServiceActivation
            '    Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

            'Else
            '    If ChkLog.Checked = False Then
            '        log = ". Update Status of Invalid  SENDER by SP:CXLROBO_UPDATEDATA."
            '        WriteDebugInfo(log, filename)
            '    End If
            '    obj.UpdateResponse_New(NormalizeData.Tables(1).Rows(J).Item("MerchantId"), NormalizeData.Tables(1).Rows(J).Item("CLoginId"), NormalizeData.Tables(1).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(1).Rows(J).Item("trackid"))


            'End If
        End Sub

        Private Sub SuccessfulCXLFOR_PA(ByVal J As Integer, ByVal CXLR_Code As String, ByVal CXL_Msg As String)


            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            ResponseCode_Cs = "0"
            CsMessage = CXL_Msg

            Dim Inv_no As String

            Dim ODetail As DataSet

            ' ........... start Update Customer Type in Customer Table.........."
            If ChkLog.Checked = False Then
                log = ". For Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
                log = ". Update Customer Type By SP: CXLROBO_UPDATECUSTOMERTYPE. "
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @Customer_ID= " & NormalizeData.Tables(3).Rows(J).Item("Customer_ID") & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                WriteDebugInfo(log, filename)
            End If
            obj.UpdateCustomerType(NormalizeData.Tables(3).Rows(J).Item("Customer_ID"), NormalizeData.Tables(3).Rows(J).Item("MerchantID"))
            '................. End Customer type updation..............."

            'If (NormalizeData.Tables(3).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(3).Rows(J).Item("Sender") = "EX" Or UCase(ProcessType) = "BP") Then
            'If (UCase(ProcessType) = "PA") Then
            '    ' ......Start  Cledger and Request Table  on full and partial payment"........
            '    If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
            '        If ChkLog.Checked = False Then
            '            log = ". Update Invoice Status " & vbCrLf
            '            log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
            '            log = log & ". Having Parameters: " & vbCrLf
            '            log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
            '            log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
            '            log = log & ". @InvoiceStatus= " & "C" & vbCrLf
            '            log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
            '            log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
            '            log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
            '            log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID")
            '            WriteDebugInfo(log, filename)
            '        End If
            '        obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
            '        obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "Y")

            '    Else
            '        If ChkLog.Checked = False Then
            '            log = ". Update Invoice Status of CreditCard " & vbCrLf
            '            log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
            '            log = log & ". Having Parameters: " & vbCrLf
            '            log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
            '            log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
            '            log = log & ". @InvoiceStatus= " & "P" & vbCrLf
            '            log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
            '            log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
            '            log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
            '            log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID")
            '            WriteDebugInfo(log, filename)
            '        End If
            '        obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
            '        obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "Y")

            '    End If
            '    '......... End Cledger and Request Table  on full and partial payment"............. 
            '    If ChkLog.Checked = False Then
            '        log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
            '        WriteDebugInfo(log, filename)
            '    End If
            '    'obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, NormalizeData.Tables(3).Rows(J).Item("invoice_no"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), CXLR_Code, CXL_Msg)

            If (UCase(ProcessType) = "PA") Then

                If ChkLog.Checked = False Then
                    log = ". Update Payment Amount by SP:INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS. "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID" & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @OrderID" & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @PaidAmount" & NormalizeData.Tables(3).Rows(J).Item("PaidAmount") & vbCrLf
                    log = log & ". @ccStatus" & NormalizeData.Tables(3).Rows(J).Item("ccStatus")
                    WriteDebugInfo(log, filename)
                End If
                obj.UpDatePayAmount(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("Amount"), NormalizeData.Tables(3).Rows(J).Item("ccStatus"))
                '............... End Start Update Invoice Table pay_amt field etc...................."
                Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))

                If ChkLog.Checked = False Then
                    log = ". Getting Order Detail by SP :INFINISHOPS_ORDER_ADDDETAILS . "
                    WriteDebugInfo(log, filename)
                End If
                ' ...............start. Insert order details in inv_det table............."
                'Dim X As Integer
                'For X = 0 To DataS.Tables(0).Rows.Count - 1
                '    obj.OrderAddDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "@ORD" + NormalizeData.Tables(3).Rows(J).Item("OrderID"), DataS.Tables(0).Rows(X).Item("Product_ID"), DataS.Tables(0).Rows(X).Item("prod_code"), DataS.Tables(0).Rows(X).Item("Qty"), DataS.Tables(0).Rows(X).Item("product_sale_price"), DataS.Tables(0).Rows(X).Item("product_tax_code"), DataS.Tables(0).Rows(X).Item("tax_code_rate"), DataS.Tables(0).Rows(X).Item("unitprice"), "S")
                '    If ChkLog.Checked = False Then
                '        log = ". Adding Order Detail . "
                '        WriteDebugInfo(log, filename)
                '    End If
                'Next
                ' ............... end Insert order details in inv_det table..........."
                Dim Copy2ProWeb As Boolean = False

                If (obj.CheckServiceEnable(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "118") = True Or obj.CheckServiceEnable(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "232") = True) Then

                    ''''............... Sttart Insert in pro_invoice  to get invoice #..............."
                    Dim defaultBack_nc As String = obj.GetLedgerNC(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "Default Bank")
                    Dim deliveryExpences_nc As String = obj.GetLedgerNC(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), "Delivery Expenses")
                    If ChkLog.Checked = False Then
                        log = ". Invoice Creation in Pro_invoice by SP:ACCOUNTSPRO_UPDATEPROINVOICE For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(3).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @InvoiceNumber= " & "0" & vbCrLf
                        log = log & ". @Inv_date=" & Date.Now() & vbCrLf
                        log = log & ". @Cust_det=" & "" & vbCrLf
                        log = log & ". @product_tax_code=" & DataS.Tables(0).Rows(0).Item("product_tax_code") & vbCrLf
                        log = log & ". @tax_Code_rate=" & DataS.Tables(0).Rows(0).Item("tax_Code_rate") & vbCrLf
                        log = log & ". @GlobalTC= " & "T9" & vbCrLf
                        log = log & ". @GlobalTCrate= " & "0" & vbCrLf
                        log = log & ". @defaultBack_nc= " & defaultBack_nc & vbCrLf
                        log = log & ". @deliveryExpences_nc= " & deliveryExpences_nc & vbCrLf
                        log = log & ". @Inv_type= " & "Inv" & vbCrLf
                        log = log & ". @Car_net= " & "0" & vbCrLf
                        log = log & ". @Car_vat= " & "0" & vbCrLf
                        log = log & ". @PaidAmount= " & NormalizeData.Tables(3).Rows(J).Item("PaidAmount") & vbCrLf
                        log = log & ". @CloginID= " & NormalizeData.Tables(3).Rows(J).Item("CloginID") & vbCrLf
                        log = log & ". @Pay_type= " & "Invoice"
                        WriteDebugInfo(log, filename)
                    End If
                    Inv_no = obj.InsertProInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "0", Date.Now(), "", DataS.Tables(0).Rows(0).Item("product_tax_code"), DataS.Tables(0).Rows(0).Item("tax_Code_rate"), "T9", "0", defaultBack_nc, deliveryExpences_nc, "Inv", 0, 0, 0, NormalizeData.Tables(3).Rows(J).Item("CloginID"), "Invoice", "pa")
                    ''.........End .............Insert in pro_invoice  to get invoice #...
                    ''
                    ''............. Sttart Insert in pro_inv_det  .............."

                    Dim i As Integer = 0
                    ODetail = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    For i = 0 To ODetail.Tables(0).Rows.Count - 1
                        With ODetail.Tables(0).Rows(i)
                            ' Dim _tempnet As String = FormatNumber(.Item("product_sale_price") * .Item("Qty"), 2, , , TriState.False)
                            'Dim _tempnet As String = FormatNumber(.Item("unitprice") * .Item("Qty"), 2, , , TriState.False)
                            Dim _tempvat As String = FormatNumber(.Item("Tax_amount"), 2, , , TriState.False)

                            Dim discountAmount As Double = .Item("Discount")
                            Dim product_sale_price As Double = (.Item("product_sale_price"))
                            Dim discountPer As Double '= .Item("product_sale_price") / discountAmount

                            Dim _tempnet As String = FormatNumber(product_sale_price * .Item("Qty"), 2, , , TriState.False)

                            Dim nc As String
                            If IsDBNull(.Item("nc")) Then
                                nc = "10000"
                            Else
                                nc = .Item("nc")
                            End If
                            If ChkLog.Checked = False Then
                                log = ". Inserting Order Detail by SP: ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS For Bank(CreateInvoice=Y) For Sender. " & NormalizeData.Tables(3).Rows(J).Item("Sender") & vbCrLf
                                log = log & ". Having Parameters: " & vbCrLf
                                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                                log = log & ". @inv_no= " & Inv_no & vbCrLf
                                log = log & ". @prod_code= " & .Item("prod_code") & vbCrLf
                                log = log & ". @prod_name= " & .Item("cart_product_name") & vbCrLf
                                log = log & ". @nc=" & nc & vbCrLf
                                log = log & ". @product_tax_code=" & .Item("product_tax_code") & vbCrLf
                                log = log & ". @tax_code_rate=" & .Item("tax_code_rate") & vbCrLf
                                log = log & ". @Detail= " & "" & vbCrLf
                                log = log & ". @product_sale_price= " & .Item("product_sale_price") & vbCrLf
                                log = log & ". @Qty= " & .Item("Qty") & vbCrLf
                                log = log & ". @_tempnet= " & _tempnet & vbCrLf
                                log = log & ". @_tempvat= " & _tempvat & vbCrLf
                                log = log & ". @Inv_type= " & "Inv"
                                WriteDebugInfo(log, filename)
                            End If
                            obj.InsertProdMasterDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), Inv_no, .Item("prod_code"), nc, .Item("product_tax_code"), .Item("tax_code_rate"), .Item("cart_product_name"), product_sale_price, .Item("Qty"), _tempnet, _tempvat, "Inv", discountAmount, discountPer)

                        End With
                    Next
                    ' .....End Insert in pro_inv_det..................."
                    ' 
                    '........ start  Updating invoice # in Invoice Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :INFINISHOPS_ORDER_UPDATE_INVOICE_NO For Bank (CreateInvoice=Y) For Sender= " & NormalizeData.Tables(3).Rows(J).Item("Sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If

                    obj.UpDateInvoiceNo(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), Inv_no)
                    '..........End   start  Updating invoice # in Invoice Table.........."
                    '

                    '........ start  Updating invoice # in CLEDGER Table.........."
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Number by SP :CXLROBO_UPDATEINVOICENUMBERINCLEDGER. For Bank (CreateInvoice=Y) "
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @inv_no= " & Inv_no
                        WriteDebugInfo(log, filename)
                    End If

                    obj.UpDateInvoiceNoInCledger(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), Inv_no)
                    ' ..........End   start  Updating invoice # in CLEDGER Table.........."
                    '' 
                End If
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then '' that means full payment
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status" & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "C" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(3).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "Y" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "C", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "Y")

                Else
                    If ChkLog.Checked = False Then
                        log = ". Update Invoice Status" & vbCrLf
                        log = log & ". by SP: CAM_UpdateInvoiceStatus . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @InvoiceStatus= " & "P" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf

                        log = log & ". by SP:  CXLROBO_UPDATE_INVOICE . " & vbCrLf
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @CXLMessage= " & "CreateInvoice(NO)" & vbCrLf
                        log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                        log = log & ". @Sender= " & NormalizeData.Tables(3).Rows(J).Item("sender") & vbCrLf
                        log = log & ". @CCStatus= " & "P" & vbCrLf
                        log = log & ". Except:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                        obj.GetExcept = ""
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "P", CXLR_Code, CXL_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXL_Msg, CXLR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "P")

                End If
                ' ...End................... Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment............"
                ' 

                If ChkLog.Checked = False Then
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "Y", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(3).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CXLR_Code, CXL_Msg)

            End If

            '...... start Update Credit card in RFollowUp table.......................
            'If (NormalizeData.Tables(3).Rows(J).Item("ProcessType") = "cc" Or NormalizeData.Tables(3).Rows(J).Item("ProcessType") = "CC") Then
            '    If ChkLog.Checked = False Then
            '        log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard  For CreditCard(CreateInvoice=Y). "
            '        log = log & ". Having Parameters: " & vbCrLf
            '        log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
            '        log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
            '        log = log & ". @CxlMessage= " & CXL_Msg & vbCrLf
            '        log = log & ". @TranStatus= " & "Y"
            '        WriteDebugInfo(log, filename)
            '    End If
            '    obj.UpdateCreditCard(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), CXL_Msg, "Y")
            '    ' ...... end Update Credit card in RFollowUp table.......................
            '    ' 
            '    If (NormalizeData.Tables(3).Rows(J).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
            '        If ChkLog.Checked = False Then
            '            log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
            '            log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For Credit Card(CreateInvoice=Y). "
            '            log = log & ". Having Parameters: " & vbCrLf
            '            log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
            '            log = log & ". @Amount= " & NormalizeData.Tables(3).Rows(J).Item("Amount") & vbCrLf
            '            log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
            '            log = log & ". @TransactionType= " & NormalizeData.Tables(3).Rows(J).Item("TransactionType") & vbCrLf
            '            log = log & ". @Inv_no= " & Inv_no
            '            WriteDebugInfo(log, filename)
            '        End If
            '        '''' ....start update infinishopmainDB Mledger table................
            '        obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("Amount"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), NormalizeData.Tables(3).Rows(J).Item("TransactionType"), Inv_no)
            '    End If

            'End If

            If (NormalizeData.Tables(3).Rows(J).Item("TranStatus") = "Y") Then ' and Refund<>"TRUE" 
                If ChkLog.Checked = False Then
                    log = ". updation in Rfollowup,Cledger and request Table " & vbCrLf
                    log = log & ". by SP:collectionService_Administration_AutomateProcessInvoice For Credit Card(CreateInvoice=Y). "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @Amount= " & NormalizeData.Tables(3).Rows(J).Item("Amount") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @TransactionType= " & NormalizeData.Tables(3).Rows(J).Item("TransactionType") & vbCrLf
                    log = log & ". @Inv_no= " & Inv_no
                    WriteDebugInfo(log, filename)
                End If
                '''' ....start update infinishopmainDB Mledger table................
                obj.CSAdminAutomateProcessInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("Amount"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), NormalizeData.Tables(3).Rows(J).Item("TransactionType"), Inv_no)
            End If


            Dim Post As New InvoicePostWS.AccountsProService
            Post.Timeout = 3 * 60 * 1000

            If ChkLog.Checked = False Then
                log = ". Invoices To Post of Inv No: For SuccessFull CreditCard " & vbCrLf
                log = log & ". Having Parameters: " & vbCrLf
                log = log & ". @MerchantID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & vbCrLf
                log = log & ". @inv_no= " & Inv_no
                WriteDebugInfo(log, filename)
            End If
            Dim b As String = Post.CXLRobot_PostInvoice(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), Inv_no)
            If b <> "0" Then
                SendEmail("Merchant ID: " & NormalizeData.Tables(3).Rows(J).Item("MerchantID") & ", Order ID: " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & ", Invoice no: " & Inv_no & ", Response from Post Invoice: " & b)
            End If
            If ChkLog.Checked = False Then
                log = ". End of Invoices To Post of Inv No: For SuccessFull CreditCard " & vbCrLf
                log = log & ". Having Code Return: " & b
                WriteDebugInfo(log, filename)
            End If


            If (NormalizeData.Tables(3).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    log = ". Update Status of MYSQL " & vbCrLf
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @CloginId= " & NormalizeData.Tables(3).Rows(J).Item("CloginId") & vbCrLf
                    log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                    log = log & ". @CXLCode= " & CXLR_Code & vbCrLf
                    log = log & ". @CXLMessage= " & CXL_Msg & vbCrLf
                    log = log & ". @CsMessage= " & CsMessage & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(3).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @StatusFromCs= " & "Y" & vbCrLf
                    log = log & ". @ResponseCode_Cs= " & ResponseCode_Cs
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(3).Rows(J).Item("CloginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CXLR_Code, CXL_Msg, CsMessage, NormalizeData.Tables(3).Rows(J).Item("TrackID"), "Y", ResponseCode_Cs, Inv_no)

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "AC") Then

                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then
                    If ChkLog.Checked = False Then
                        log = ". Calling EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(J).Item("sender")
                        log = log & ". Having Parameters: " & vbCrLf
                        log = log & ". @Customer_Id= " & NormalizeData.Tables(3).Rows(J).Item("Customer_Id") & vbCrLf
                        log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                        log = log & ". @IsOrderProcess= " & "True" & vbCrLf
                        log = log & ". @ProcessType= " & NormalizeData.Tables(3).Rows(J).Item("ProcessType")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjService = New ServiceActivation.ServiceActivation
                    Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(3).Rows(J).Item("Customer_Id"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), True, NormalizeData.Tables(3).Rows(J).Item("ProcessType"))

                End If

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IR") Then

                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail
                'Dim count As Integer
                'For count = 0 To DataS.Tables(0).Rows.Count - 1
                '    Product(count) = New com.reseller.webservices.ProductDetail
                '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                'Next
                'If ChkLog.Checked = False Then
                '    log = ". calling Web service GETBIZINFO method for(invalid data) For sender=" & NormalizeData.Tables(3).Rows(J).Item("sender") & vbCrLf
                '    log = log & ". Having Parameters: " & vbCrLf
                '    log = log & ". @MerchantLoginID= " & NormalizeData.Tables(3).Rows(J).Item("MerchantLoginID") & vbCrLf
                '    log = log & ". @OrderID= " & NormalizeData.Tables(3).Rows(J).Item("OrderID") & vbCrLf
                '    log = log & ". @Customer_id= " & NormalizeData.Tables(3).Rows(J).Item("Customer_id") & vbCrLf
                '    'log = log & ". @Product= " & Product & vbCrLf
                '    log = log & ". @PayStatus=" & "Y"
                '    WriteDebugInfo(log, filename)

                'End If
                'ResellerService = New com.reseller.webservices.IShopOrderHander
                '' ObjService.GetBizInfo(NormalizeData.Tables(3).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("Customer_id"), Product, "Y")
                'ResellerService.GetBizInfo(NormalizeData.Tables(3).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("Customer_id"), Product, "Y")
                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                'info.CustomerID = NormalizeData.Tables(3).Rows(J).Item("Customer_Id")
                'info.IsOrderSuccess = True
                'info.MerchantID = NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                'info.OrderID = NormalizeData.Tables(3).Rows(J).Item("OrderID")
                'info.PayMode = Io.InfiniShops.PaymentMode.PA


                'If ChkLog.Checked = False Then
                '    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(J).Item("sender")
                '    WriteDebugInfo(log, filename)
                'End If
                'ObjIo = New Io.InfiniShops.ServiceActivation
                'Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                Try
                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(J).Item("Customer_Id"), "Y", "Y", "PA")
                    If ChkLog.Checked = False Then
                        log = ". Dumping data for MPI Reseller" & vbCrLf
                        log = log & "Exception:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = ". Dumping data for MPI Reseller" & vbCrLf
                    log = log & "Exception:" & ex.Message
                    WriteDebugInfo(log, filename)
                End Try


            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IN") Then

                Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                info.CustomerID = NormalizeData.Tables(3).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = True
                info.MerchantID = NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(3).Rows(J).Item("OrderID")
                info.PayMode = Io.InfiniShops.PaymentMode.PA

                If ChkLog.Checked = False Then
                    log = ". Calling InfiniShops.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If
                ObjIo = New Io.InfiniShops.ServiceActivation
                Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)


                If ChkLog.Checked = False Then
                    log = ". calling their Web service ENABLED SERVICES for Bank .ErrorCode= " & Result.ERRORCODE & " ResultDesciption=" & Result.ERRORDESC
                    WriteDebugInfo(log, filename)
                End If

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(3).Rows(J).Item("Sender") = "EX") Then

                obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CloginId"), NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("invoice_no"))

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IB") Then

                If ChkLog.Checked = False Then
                    log = ". calling their Web service method UpdateBuyerPointStatus Place  For Sender " & NormalizeData.Tables(3).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If
                ObjBuyer = New BPtsPayment.InfiniBPPay

                ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(3).Rows(J).Item("TrackID"), True, Inv_no)

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IM") Then

                If ChkLog.Checked = False Then
                    log = ". calling their Web service InfiniMarket Place  For IM "
                    WriteDebugInfo(log, filename)
                End If
                Dim IM_Xml As String
                IM_Xml = "<CustomerOrderInfo>" & _
                         "<CustomerID>" & NormalizeData.Tables(3).Rows(J).Item("Customer_id") & "</CustomerID>" & _
                         "<CustomerUID>" & NormalizeData.Tables(3).Rows(J).Item("CloginId") & "</CustomerUID>" & _
                         "<MerchantID>" & NormalizeData.Tables(3).Rows(J).Item("MerchantId") & "</MerchantID>" & _
                         "<MerchantUID>" & NormalizeData.Tables(3).Rows(J).Item("MerchantLoginId") & "</MerchantUID>" & _
                         "<OrderAmount>" & NormalizeData.Tables(3).Rows(J).Item("Amount") & "</OrderAmount>" & _
                         "<OrderStatus> Processed </OrderStatus>" & _
                         "<OrderID>" & NormalizeData.Tables(3).Rows(J).Item("OrderID") & "</OrderID>" & _
                         "<TrackID>" & NormalizeData.Tables(3).Rows(J).Item("Trackid") & "</TrackID>" & _
                        "</CustomerOrderInfo>"

                'Dim T As String
                ' ObjInifiniMarketPlace = New InfiniMarket._Default
                '  T = ObjInifiniMarketPlace.UpdateCustomerInfo(IM_Xml)

                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                info.CustomerID = NormalizeData.Tables(3).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = True
                info.MerchantID = NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(3).Rows(J).Item("OrderID")
                If CType(NormalizeData.Tables(3).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                End If

                If ChkLog.Checked = False Then
                    log = ". Calling IShopServiceActivation.EnabledServices Method For sender=" & NormalizeData.Tables(3).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

            Else
                If ChkLog.Checked = False Then
                    log = ". Update Status of Invalid  SENDER by SP:CXLROBO_UPDATEDATA."
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, Inv_no, NormalizeData.Tables(3).Rows(J).Item("trackid"), CxlIdentity)

            End If
        End Sub

        Private Sub Decline(ByVal J As Integer, ByVal CxlR_Code As String, ByVal Cxl_Msg As String)


            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            If ChkLog.Checked = False Then
                log = ". For Un Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
            End If
            ResponseCode_Cs = "-1"    ' CxlR_code = "30" '' Credit card Decline from CXL
            If (Cxl_Msg = "" Or CxlR_Code = "30") Then

                CsMessage = "CXL DECLINE CREDIT CARD"
            Else
                CsMessage = Cxl_Msg
            End If

            ' ...... start Update Credit card in RFollowUp table.......................
            If (NormalizeData.Tables(2).Rows(J).Item("ProcessType") = "cc" Or NormalizeData.Tables(2).Rows(J).Item("ProcessType") = "CC") Then
                If ChkLog.Checked = False Then
                    log = ". Update Credit Card in encrypted Form by SP:CAM_UpdateCreditCard . "
                    log = log & ". Having Parameters: " & vbCrLf
                    log = log & ". @MerchantID= " & NormalizeData.Tables(2).Rows(J).Item("MerchantID") & vbCrLf
                    log = log & ". @TrackID= " & NormalizeData.Tables(2).Rows(J).Item("TrackID") & vbCrLf
                    log = log & ". @CxlMessage= " & Cxl_Msg & vbCrLf
                    log = log & ". @TranStatus= " & "n"
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateCreditCard(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), Cxl_Msg, "N")
                '...... end Update Credit card in RFollowUp table.......................
            End If
            If (NormalizeData.Tables(2).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(2).Rows(J).Item("Sender") = "EX") Then

                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then ' that means full payment
                    '......Start Cledger and Request Table  on full and partial payment........."
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "D")


                Else
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "D")

                    '......end Cledger and Request Table  on full and partial payment........."
                End If
                If ChkLog.Checked = False Then
                    '   log = log & vbNewLine & Now & ".Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For PR,EX "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, NormalizeData.Tables(2).Rows(J).Item("invoice_no"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_Code, Cxl_Msg)

            Else
                'FOR IN,AC,FH,IM,IR 
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "D")

                Else
                    If ChkLog.Checked = False Then
                        '   log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(2).Rows(J).Item("ProcessType"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("sender"), "P")

                End If
                '......end  Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If ChkLog.Checked = False Then
                    '       log = log & vbNewLine & Now & ".Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_Code, Cxl_Msg)
            End If

            If (NormalizeData.Tables(2).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    'log = log & vbNewLine & Now & ".Update my sql status . "
                    log = ". Update my sql status . "
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), CxlR_Code, Cxl_Msg, CsMessage, NormalizeData.Tables(2).Rows(J).Item("TrackID"), "D", ResponseCode_Cs)

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "AC") Then
                If (NormalizeData.Tables(2).Rows(J).Item("ccstatus") = "Y") Then
                    If ChkLog.Checked = False Then
                        'log = log & vbNewLine & Now & ".Calling Enable Services (UnSuccesfull Cxl Transaction) . against custid=" & NormalizeData.Tables(2).Rows(j).Item("Customer_Id") & "and order_id" & NormalizeData.Tables(2).Rows(j).Item("OrderID")
                        log = ". Calling Enable Services (UnSuccesfull Cxl Transaction) . against custid=" & NormalizeData.Tables(2).Rows(J).Item("Customer_Id") & "and order_id" & NormalizeData.Tables(2).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjService = New ServiceActivation.ServiceActivation
                    Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), False, NormalizeData.Tables(2).Rows(J).Item("ProcessType"))

                End If

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IR") Then

                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"))

                ''Infinishop Webservice
                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                'info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                'info.IsOrderSuccess = False
                'info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                'info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                'If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                '    info.PayMode = Io.InfiniShops.PaymentMode.CC
                'Else
                '    info.PayMode = Io.InfiniShops.PaymentMode.CB
                'End If
                'ObjIo = New Io.InfiniShops.ServiceActivation
                'Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                'If ChkLog.Checked = False Then
                '    ' log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case(invalid data) . For IR "
                '    log = ". calling their Web service ENABLED SERVICES for UnSuccessfull CreditCard . For IR Result ErroeCode= " & result.ERRORCODE & " ResultDesciption=" & result.ERRORDESC
                '    WriteDebugInfo(log, filename)
                'End If
                ''-------------


                ''Reseller Webservice
                'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail 'ServiceActivation.ProductDetail
                'Dim count As Integer
                'For count = 0 To DataS.Tables(0).Rows.Count - 1
                '    Product(count) = New com.reseller.webservices.ProductDetail
                '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                'Next
                'If ChkLog.Checked = False Then
                '    '   log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case . For IR "
                '    log = ". calling their Web service GET BIZ info method for decline case . For IR "
                '    WriteDebugInfo(log, filename)
                'End If
                'ResellerService = New com.reseller.webservices.IShopOrderHander
                'ResellerService.Timeout = 4 * 60 * 1000
                'ResellerService.GetBizInfo(NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("Customer_id"), Product, "N")
                ''---------

                Try
                    Dim PayModeMPI As String
                    If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                        PayModeMPI = "CC"
                    Else
                        PayModeMPI = "CB"
                    End If
                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(2).Rows(J).Item("OrderID"), NormalizeData.Tables(2).Rows(J).Item("MerchantID"), NormalizeData.Tables(2).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(2).Rows(J).Item("Customer_Id"), "N", "N", PayModeMPI)
                    If ChkLog.Checked = False Then
                        log = ". Dumping data for MPI Reseller" & vbCrLf
                        log = log & "Exception:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = ". Dumping data for MPI Reseller" & vbCrLf
                    log = log & "Exception:" & ex.Message
                    WriteDebugInfo(log, filename)
                End Try


            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IN") Then

                Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                info.CustomerID = NormalizeData.Tables(2).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = False
                info.MerchantID = NormalizeData.Tables(2).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(2).Rows(J).Item("OrderID")
                If CType(NormalizeData.Tables(2).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                End If
                ObjIo = New Io.InfiniShops.ServiceActivation
                Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                If ChkLog.Checked = False Then
                    ' log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case(invalid data) . For IR "
                    log = ". calling their Web service ENABLED SERVICES for UnSuccessfull CreditCard . For IN Result ErroeCode= " & result.ERRORCODE & " ResultDesciption=" & result.ERRORDESC
                    WriteDebugInfo(log, filename)
                End If
            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(2).Rows(J).Item("Sender") = "EX") Then

                obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CloginId"), NormalizeData.Tables(2).Rows(J).Item("trackid"), NormalizeData.Tables(2).Rows(J).Item("invoice_no"))

            ElseIf (NormalizeData.Tables(2).Rows(J).Item("sender") = "IB") Then
                ObjBuyer = New BPtsPayment.InfiniBPPay
                ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(2).Rows(J).Item("trackid"), False)

                'ElseIf (NormalizeData.Tables(2).Rows(j).Item("sender") = "IM") Then

                '    If ChkLog.Checked = False Then
                '        log = log & vbNewLine & Now & ". calling their Web service InfiniMarket Place  For IM "
                '        WriteDebugInfo(log, filename)
                '    End If
                '    Dim IM_Xml As String
                '    IM_Xml = "<CustomerOrderInfo>" & _
                '             "<CustomerID>" & NormalizeData.Tables(2).Rows(j).Item("Customer_id") & "</CustomerID>" & _
                '             "<CustomerUID>" & NormalizeData.Tables(2).Rows(j).Item("CloginId") & "</CustomerUID>" & _
                '             "<MerchantID>" & NormalizeData.Tables(2).Rows(j).Item("MerchantId") & "</MerchantID>" & _
                '             "<MerchantUID>" & NormalizeData.Tables(2).Rows(j).Item("MerchantLoginId") & "</MerchantUID>" & _
                '             "<OrderAmount>" & NormalizeData.Tables(2).Rows(j).Item("Amount") & "</OrderAmount>" & _
                '             "<OrderStatus> Declined </OrderStatus>" & _
                '             "<OrderID>" & NormalizeData.Tables(2).Rows(j).Item("OrderID") & "</OrderID>" & _
                '             "<TrackID>" & NormalizeData.Tables(2).Rows(j).Item("Trackid") & "</TrackID>" & _
                '            "</CustomerOrderInfo>"

                '    Dim T As String
                'ObjInfiniMarketPlace=new InfiniMarket._Default
                '    T = ObjInifiniMarketPlace.CustomerOrderProcess(IM_Xml)

            Else
                If ChkLog.Checked = False Then
                    log = ". Update Status of Invalid SENDER by SP:CXLROBO_UPDATEDATA."
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(2).Rows(J).Item("MerchantId"), NormalizeData.Tables(2).Rows(J).Item("CLoginId"), NormalizeData.Tables(2).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(2).Rows(J).Item("trackid"), CxlIdentity, MPI_SessionID)


            End If
        End Sub
        Private Sub DeclineForPA(ByVal J As Integer, ByVal CxlR_Code As String, ByVal Cxl_Msg As String)


            StatusResponse = StatusResponse + 1
            lblStatusResponse.Text = StatusResponse
            Application.DoEvents()

            If ChkLog.Checked = False Then
                log = ". For Un Successful Response From CXL (either Test or Live). "
                WriteDebugInfo(log, filename)
            End If
            ResponseCode_Cs = "-1"    ' CxlR_code = "30" '' Credit card Decline from CXL
            If (Cxl_Msg = "" Or CxlR_Code = "30") Then

                CsMessage = "CXL DECLINE PA"
            Else
                CsMessage = Cxl_Msg
            End If

            ' ...... start Update Credit card in RFollowUp table.......................

            If (NormalizeData.Tables(3).Rows(J).Item("Sender") = "PR" Or NormalizeData.Tables(3).Rows(J).Item("Sender") = "EX") Then

                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then ' that means full payment
                    '......Start Cledger and Request Table  on full and partial payment........."
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))

                Else
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    '......end Cledger and Request Table  on full and partial payment........."
                End If
                If ChkLog.Checked = False Then
                    '   log = log & vbNewLine & Now & ".Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA for unsuccessfull credit card . For PR,EX "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, NormalizeData.Tables(3).Rows(J).Item("invoice_no"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_Code, Cxl_Msg)

            Else
                'FOR IN,AC,FH,IM,IR 
                '......Start Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then ''' that means full payment
                    If ChkLog.Checked = False Then
                        '  log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is full by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response). "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "D")

                Else
                    If ChkLog.Checked = False Then
                        '   log = log & vbNewLine & Now & ".Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        log = ". Update Invoice Status of Credit Card Transaction if payment is partial by SP:CAM_UpdateInvoiceStatus  and CXLROBO_UPDATE_INVOICE (unsuccessfull response. "
                        WriteDebugInfo(log, filename)
                    End If
                    obj.UpdateInvoiceStatus(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("TrackID"), "D", CxlR_Code, Cxl_Msg, NormalizeData.Tables(3).Rows(J).Item("ProcessType"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))
                    obj.UpdateInvoiceTable(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), Cxl_Msg, CxlR_Code, NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("sender"), "P")

                End If
                '......end  Cledger and Request Table and  Invoice Status in pro_invoice table and In Invoice Table on full and partial payment........."
                If ChkLog.Checked = False Then
                    '       log = log & vbNewLine & Now & ".Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    log = ". Update reponses to sql server by SP: CXLROBO_UPDATEDATA for successfull credit card . For AC ,FH,IS "
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "D", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(J).Item("TrackID"), CxlIdentity, MPI_SessionID, CxlR_Code, Cxl_Msg)
            End If

            If (NormalizeData.Tables(3).Rows(J).Item("sender") = "FH") Then
                If ChkLog.Checked = False Then
                    'log = log & vbNewLine & Now & ".Update my sql status . "
                    log = ". Update my sql status . "
                    WriteDebugInfo(log, filename)
                End If
                UpdateMySqlStatus(NormalizeData.Tables(3).Rows(J).Item("CloginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), CxlR_Code, Cxl_Msg, CsMessage, NormalizeData.Tables(3).Rows(J).Item("TrackID"), "D", ResponseCode_Cs)

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "AC") Then
                If (NormalizeData.Tables(3).Rows(J).Item("ccstatus") = "Y") Then
                    If ChkLog.Checked = False Then
                        'log = log & vbNewLine & Now & ".Calling Enable Services (UnSuccesfull Cxl Transaction) . against custid=" & NormalizeData.Tables(3).Rows(j).Item("Customer_Id") & "and order_id" & NormalizeData.Tables(3).Rows(j).Item("OrderID")
                        log = ". Calling Enable Services (UnSuccesfull Cxl Transaction) . against custid=" & NormalizeData.Tables(3).Rows(J).Item("Customer_Id") & "and order_id" & NormalizeData.Tables(3).Rows(J).Item("OrderID")
                        WriteDebugInfo(log, filename)
                    End If
                    ObjService = New ServiceActivation.ServiceActivation
                    Dim chkservice As Boolean = ObjService.EnabledServices(NormalizeData.Tables(3).Rows(J).Item("Customer_Id"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), False, NormalizeData.Tables(3).Rows(J).Item("ProcessType"))

                End If

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IR") Then

                'Dim DataS As DataSet = obj.GetOrderDetail(NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"))

                ''Infinishop webservice
                'Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                'info.CustomerID = NormalizeData.Tables(3).Rows(J).Item("Customer_Id")
                'info.IsOrderSuccess = False
                'info.MerchantID = NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                'info.OrderID = NormalizeData.Tables(3).Rows(J).Item("OrderID")
                'info.PayMode = Io.InfiniShops.PaymentMode.PA


                'ObjIo = New Io.InfiniShops.ServiceActivation
                'Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                'If ChkLog.Checked = False Then
                '    ' log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case(invalid data) . For IR "
                '    log = ". calling their Web service ENABLED SERVICES for UnSuccessfull CreditCard . For IR Result ErroeCode= " & result.ERRORCODE & " ResultDesciption=" & result.ERRORDESC
                '    WriteDebugInfo(log, filename)
                'End If
                ''-----------


                ''Reseller Webservice
                'Dim Product(DataS.Tables(0).Rows.Count - 1) As com.reseller.webservices.ProductDetail 'ServiceActivation.ProductDetail
                'Dim count As Integer
                'For count = 0 To DataS.Tables(0).Rows.Count - 1
                '    Product(count) = New com.reseller.webservices.ProductDetail
                '    Product(count).ProductCode = DataS.Tables(0).Rows(count).Item("prod_code")
                '    Product(count).Quantity = DataS.Tables(0).Rows(count).Item("Qty")
                '    Product(count).OrderType = DataS.Tables(0).Rows(count).Item("OrderType")
                'Next
                'If ChkLog.Checked = False Then
                '    '   log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case . For IR "
                '    log = ". calling their Web service GET BIZ info method for decline case . For IR "
                '    WriteDebugInfo(log, filename)
                'End If
                'ResellerService = New com.reseller.webservices.IShopOrderHander
                'ResellerService.Timeout = 4 * 60 * 1000
                'ResellerService.GetBizInfo(NormalizeData.Tables(3).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("Customer_id"), Product, "N")
                ''-----------

                Try
                    obj.MPI_ResselerAndActivationData(NormalizeData.Tables(3).Rows(J).Item("OrderID"), NormalizeData.Tables(3).Rows(J).Item("MerchantID"), NormalizeData.Tables(3).Rows(J).Item("MerchantLoginID"), NormalizeData.Tables(3).Rows(J).Item("Customer_Id"), "N", "N", "PA")
                    If ChkLog.Checked = False Then
                        log = ". Dumping data for MPI Reseller" & vbCrLf
                        log = log & "Exception:" & obj.GetExcept
                        WriteDebugInfo(log, filename)
                    End If
                Catch ex As Exception
                    log = ". Dumping data for MPI Reseller" & vbCrLf
                    log = log & "Exception:" & ex.Message
                    WriteDebugInfo(log, filename)
                End Try


            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IN") Then

                Dim info As New WindowsGateWayCreditCard.Io.InfiniShops.ServiceInfo
                info.CustomerID = NormalizeData.Tables(3).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = False
                info.MerchantID = NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(3).Rows(J).Item("OrderID")

                info.PayMode = Io.InfiniShops.PaymentMode.BP

                ObjIo = New Io.InfiniShops.ServiceActivation
                Dim result As WindowsGateWayCreditCard.Io.InfiniShops.EnabledServicesResult = ObjIo.EnabledServices(info)

                If ChkLog.Checked = False Then
                    ' log = log & vbNewLine & Now & ". calling their Web service GET BIZ info method for decline case(invalid data) . For IR "
                    log = ". calling their Web service ENABLED SERVICES for UnSuccessfull CreditCard . For IN Result ErroeCode= " & result.ERRORCODE & " ResultDesciption=" & result.ERRORDESC
                    WriteDebugInfo(log, filename)
                End If
            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "PR" Or NormalizeData.Tables(3).Rows(J).Item("Sender") = "EX") Then

                obj.UpdateTrackidInPro_invoiceForPRO(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CloginId"), NormalizeData.Tables(3).Rows(J).Item("trackid"), NormalizeData.Tables(3).Rows(J).Item("invoice_no"))

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IB") Then
                ObjBuyer = New BPtsPayment.InfiniBPPay
                ObjBuyer.UpdateBuyerPointStatus(NormalizeData.Tables(3).Rows(J).Item("trackid"), False)

            ElseIf (NormalizeData.Tables(3).Rows(J).Item("sender") = "IM") Then

                If ChkLog.Checked = False Then
                    log = log & vbNewLine & Now & ". calling their Web service InfiniMarket Place  For IM "
                    WriteDebugInfo(log, filename)
                End If
                Dim IM_Xml As String
                IM_Xml = "<CustomerOrderInfo>" & _
                         "<CustomerID>" & NormalizeData.Tables(3).Rows(J).Item("Customer_id") & "</CustomerID>" & _
                         "<CustomerUID>" & NormalizeData.Tables(3).Rows(J).Item("CloginId") & "</CustomerUID>" & _
                         "<MerchantID>" & NormalizeData.Tables(3).Rows(J).Item("MerchantId") & "</MerchantID>" & _
                         "<MerchantUID>" & NormalizeData.Tables(3).Rows(J).Item("MerchantLoginId") & "</MerchantUID>" & _
                         "<OrderAmount>" & NormalizeData.Tables(3).Rows(J).Item("Amount") & "</OrderAmount>" & _
                         "<OrderStatus> Declined </OrderStatus>" & _
                         "<OrderID>" & NormalizeData.Tables(3).Rows(J).Item("OrderID") & "</OrderID>" & _
                         "<TrackID>" & NormalizeData.Tables(3).Rows(J).Item("Trackid") & "</TrackID>" & _
                        "</CustomerOrderInfo>"

                '    Dim T As String
                'ObjInfiniMarketPlace=new InfiniMarket._Default
                '    T = ObjInifiniMarketPlace.CustomerOrderProcess(IM_Xml)

                Dim info As New WindowsGateWayCreditCard.com.infinishops.io.ServiceInfo
                info.CustomerID = NormalizeData.Tables(3).Rows(J).Item("Customer_Id")
                info.IsOrderSuccess = False
                info.MerchantID = NormalizeData.Tables(3).Rows(J).Item("MerchantID")
                info.OrderID = NormalizeData.Tables(3).Rows(J).Item("OrderID")
                If CType(NormalizeData.Tables(3).Rows(J).Item("ProcessType"), String).ToUpper = "CC" Then
                    info.PayMode = Io.InfiniShops.PaymentMode.CC
                Else
                    info.PayMode = Io.InfiniShops.PaymentMode.CB
                End If

                If ChkLog.Checked = False Then
                    log = ". Calling IShopServiceActivation.EnabledServices Method for UnSuccessfull CreditCard For sender=" & NormalizeData.Tables(3).Rows(J).Item("sender")
                    WriteDebugInfo(log, filename)
                End If

                Dim objIShop As New com.infinishops.io.IShopServiceActivation
                Dim result As WindowsGateWayCreditCard.com.infinishops.io.EnabledServicesResult = objIShop.EnabledServices(info)

            Else
                If ChkLog.Checked = False Then
                    log = ". Update Status of Invalid SENDER by SP:CXLROBO_UPDATEDATA."
                    WriteDebugInfo(log, filename)
                End If
                obj.UpdateResponse_New(NormalizeData.Tables(3).Rows(J).Item("MerchantId"), NormalizeData.Tables(3).Rows(J).Item("CLoginId"), NormalizeData.Tables(3).Rows(J).Item("OrderID"), "S", CsMessage, ResponseCode_Cs, 0, NormalizeData.Tables(3).Rows(J).Item("trackid"), CxlIdentity)


            End If
        End Sub
#End Region


        Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
            Me.WindowState = FormWindowState.Minimized
        End Sub

        Private Sub ClearEX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearEX.Click
            LstException.Items.Clear()
            LstException.Items.Add("Double CLick Text To View EX in NotePad:")
            DataString = ""
        End Sub
        Function tempfilename() As String

            If ProcID = 0 Then
                Dim tempPath As String = Path.GetTempPath
                Dim tempFile As String = Path.GetTempFileName

                Dim AE As New System.Text.UTF8Encoding

                Dim ByteArray As Byte() = AE.GetBytes(DataString)

                Dim fileObj As System.IO.FileStream = File.OpenWrite(tempFile)
                fileObj.Write(ByteArray, 0, ByteArray.GetLength(0))
                fileObj.Flush()
                fileObj.Close()

                Dim p As Process = Process.Start("Notepad", tempFile)
                Me.ProcID = p.Id
                Dim ObjProcessManager As ProcessManager = New ProcessManager(p.Id, tempFile)
                ProcID = 1
            End If

            ' AppActivate(p.Id)
            'Kill(tempFile)
        End Function

        Class ProcessManager

            Dim WorkerThread As Thread
            Dim ProcessID As Integer, TempFileName As String

            Public Sub New(ByVal ProcessID As Integer, ByVal TempFileName As String)
                Me.ProcessID = ProcessID
                Me.TempFileName = TempFileName
                WorkerThread = New Thread(AddressOf CheckProcessAliveOrKilled)
                WorkerThread.Start()
            End Sub

            Public Sub CheckProcessAliveOrKilled()
                Dim Check As Boolean = True
                Dim proc As Process, alive As Boolean = False

                While Check

                    For Each proc In Process.GetProcesses
                        If proc.Id = ProcessID Then
                            alive = True
                        End If
                    Next

                    If alive = False Then
                        Kill(TempFileName)
                        Check = False
                        ProcID = 0
                    Else
                        alive = False
                    End If
                    'If CType(Process.GetProcessById(ProcessID), Process) Is Nothing Then
                    '    Kill(TempFileName)
                    '    Check = False
                    'End If

                End While
                ' WorkerThread.Abort()
            End Sub
        End Class

        Private Sub LstException_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstException.DoubleClick
            tempfilename()
        End Sub

    End Class

    Public Class CertificateValidation
        Implements System.Net.ICertificatePolicy

        'This class handles problems with certificates if ssl (https) is used

        Public Function CheckValidationResult(ByVal srvPoint As ServicePoint, _
        ByVal cert As X509Certificate, ByVal request As WebRequest, ByVal problem As Integer) _
           As Boolean Implements ICertificatePolicy.CheckValidationResult
            Return True
        End Function
    End Class
    Public Class EncryptionDecryption

        Public Shared Function EncryptString128Bit(ByVal vstrTextToBeEncrypted As String, ByVal vstrEncryptionKey As String) As String

            Dim bytValue() As Byte
            Dim bytKey() As Byte
            Dim bytEncoded() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim intLength As Integer
            Dim intRemaining As Integer
            Dim objMemoryStream As New MemoryStream
            Dim objCryptoStream As CryptoStream
            Dim objRijndaelManaged As RijndaelManaged


            '   **********************************************************************
            '   ******  Strip any null character from string to be encrypted    ******
            '   **********************************************************************

            vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

            '   **********************************************************************
            '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
            '   **********************************************************************

            bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

            intLength = Len(vstrEncryptionKey)

            '   ********************************************************************
            '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
            '   ******   If it is longer than 32 bytes it will be truncated.  ******
            '   ******   If it is shorter than 32 bytes it will be padded     ******
            '   ******   with upper-case Xs.                                  ****** 
            '   ********************************************************************

            If intLength >= 32 Then
                vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
            Else
                intLength = Len(vstrEncryptionKey)
                intRemaining = 32 - intLength
                vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

            objRijndaelManaged = New RijndaelManaged

            '   ***********************************************************************
            '   ******  Create the encryptor and write value to it after it is   ******
            '   ******  converted into a byte array                              ******
            '   ***********************************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, _
                  objRijndaelManaged.CreateEncryptor(bytKey, bytIV), _
                  CryptoStreamMode.Write)
                objCryptoStream.Write(bytValue, 0, bytValue.Length)

                objCryptoStream.FlushFinalBlock()

                bytEncoded = objMemoryStream.ToArray
                objMemoryStream.Close()
                objCryptoStream.Close()
            Catch



            End Try

            '   ***********************************************************************
            '   ******   Return encryptes value (converted from  byte Array to   ******
            '   ******   a base64 string).  Base64 is MIME encoding)             ******
            '   ***********************************************************************

            Return System.Convert.ToBase64String(bytEncoded)

        End Function

        Public Shared Function DecryptString128Bit(ByVal vstrStringToBeDecrypted As String, _
                                            ByVal vstrDecryptionKey As String) As String

            Dim bytDataToBeDecrypted() As Byte
            Dim bytTemp() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim objRijndaelManaged As New RijndaelManaged
            Dim objMemoryStream As MemoryStream
            Dim objCryptoStream As CryptoStream
            Dim bytDecryptionKey() As Byte

            Dim intLength As Integer
            Dim intRemaining As Integer
            Dim intCtr As Integer
            Dim strReturnString As String = String.Empty
            Dim achrCharacterArray() As Char
            Dim intIndex As Integer

            '   *****************************************************************
            '   ******   Convert base64 encrypted value to byte array      ******
            '   *****************************************************************

            bytDataToBeDecrypted = System.Convert.FromBase64String(vstrStringToBeDecrypted)

            '   ********************************************************************
            '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
            '   ******   If it is longer than 32 bytes it will be truncated.  ******
            '   ******   If it is shorter than 32 bytes it will be padded     ******
            '   ******   with upper-case Xs.                                  ****** 
            '   ********************************************************************

            intLength = Len(vstrDecryptionKey)

            If intLength >= 32 Then
                vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
            Else
                intLength = Len(vstrDecryptionKey)
                intRemaining = 32 - intLength
                vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

            ReDim bytTemp(bytDataToBeDecrypted.Length)

            objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

            '   ***********************************************************************
            '   ******  Create the decryptor and write value to it after it is   ******
            '   ******  converted into a byte array                              ******
            '   ***********************************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, _
                   objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
                   CryptoStreamMode.Read)

                objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

                objCryptoStream.FlushFinalBlock()
                objMemoryStream.Close()
                objCryptoStream.Close()

            Catch

            End Try

            '   *****************************************
            '   ******   Return decypted value     ******
            '   *****************************************

            Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))

        End Function

        Private Shared Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

            Dim intPosition As Integer
            Dim strStringWithOutNulls As String

            intPosition = 1
            strStringWithOutNulls = vstrStringWithNulls

            Do While intPosition > 0
                intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

                If intPosition > 0 Then
                    strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                      Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
                End If

                If intPosition > strStringWithOutNulls.Length Then
                    Exit Do
                End If
            Loop

            Return strStringWithOutNulls
        End Function

    End Class
End Namespace
