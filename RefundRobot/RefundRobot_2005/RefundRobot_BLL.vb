Imports System.Data.SqlClient

Public Class RefundRobot_BLL

    Public Shared Exception As String = ""

    Public Function FetchDataFromRefundInvoices(Optional ByRef RecordCount As Integer = 0) As DataSet
        Try
            Dim cmd As New CommandData

            cmd.AddParameter("@Return_Value", 0, ParameterDirection.ReturnValue)
            cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_FETCHDATA"
            cmd.CmdType = CommandType.StoredProcedure
            FetchDataFromRefundInvoices = cmd.Execute(ExecutionType.ExecuteDataSet)
            RecordCount = cmd.Item("@Return_value")
        Catch ex As Exception
            Exception = " FetchDataFromRefundInvoices: " & ex.Message

            FetchDataFromRefundInvoices = Nothing
        End Try
    End Function

    Public Function NoOfRefundInvoicesInADay() As Integer
        Try
            Dim cmd As New CommandData

            'cmd.AddParameter("@Return_Value", 0, ParameterDirection.ReturnValue)
            cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_No_OF_Transactions"
            cmd.CmdType = CommandType.StoredProcedure
            NoOfRefundInvoicesInADay = cmd.Execute(ExecutionType.ExecuteScalar)
            'RecordCount = cmd.Item("@Return_value")
            'Return RecordCount

        Catch ex As Exception
            Exception = " NoOfRefundInvoicesInADay: " & ex.Message
            NoOfRefundInvoicesInADay = 4
        End Try
    End Function

    Public Function IsMerchantAllowed(ByVal merchant_id As Integer) As DataSet
        Try
            Dim cmd As New CommandData

            cmd.AddParameter("@Mid", merchant_id)
            cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_MERCHANT_MANAGE"
            cmd.CmdType = CommandType.StoredProcedure
            IsMerchantAllowed = cmd.Execute(ExecutionType.ExecuteDataSet)

        Catch ex As Exception
            Exception = " IsMerchantAllowed: " & ex.Message
            IsMerchantAllowed = Nothing
        End Try
    End Function

    Public Sub Update_InformationToPro_RefundInvoice(ByVal Merchant_ID As String, ByVal Order_ID As Integer, ByVal Invoice_No As Integer, ByVal TrackID As Integer, ByVal Status As String, ByVal Status_Msg As String)

        Try

            Dim cmd As New CommandData(Merchant_ID)

            ' List Of Parameters
            ' @Mid as varchar(10),
            '@Order_id as Varchar(10),
            '@Invoice_no as varchar(20),
            '@TrackID as varchar(10)

            cmd.AddParameter("@Mid", Merchant_ID)
            cmd.AddParameter("@Order_id", Order_ID)
            cmd.AddParameter("@Invoice_no", Invoice_No)
            cmd.AddParameter("@TrackID", TrackID)
            cmd.AddParameter("@Status", Status)
            cmd.AddParameter("@Status_Msg", Status_Msg)

            cmd.CmdText = "REFUND_UPDATETRACKID"
            cmd.CmdType = CommandType.StoredProcedure
            cmd.Execute(ExecutionType.ExecuteNonQuery)
        Catch ex As Exception
            Exception = " Update_InformationToPro_RefundInvoice: " & ex.Message
        End Try
    End Sub

    Public Sub UpdateRefundCalls(ByVal Merchant_ID As String, ByVal CustomerLoginId As String, ByVal Order_ID As Integer, ByVal CXLCode As String, ByVal CxlMessage As String, ByVal CSMessage As String, ByVal ResponseCode As String, ByVal Status_atcs As String, ByVal Invoice_No As Integer, ByVal CreditNote As Integer)

        Try

            Dim cmd As New CommandData


            ' List Of Parameters
            '@MID as integer,
            '@CLOGINID as varchar(50),
            '@ORDERID as Integer,
            '@CXLCODE as varchar(50),
            '@CXLMESSAGE as varchar(100),
            '@CS_MESSAGE as varchar(300),
            '@ResponseCode_Cs as varchar(50),
            '@Status_atcs as varchar(1),
            '@ProcessedTime as datetime,
            '@Inv_no as numeric

            cmd.AddParameter("@MID", Merchant_ID)
            cmd.AddParameter("@CLOGINID", CustomerLoginId)
            cmd.AddParameter("@ORDERID", Order_ID)
            cmd.AddParameter("@CXLCODE", CXLCode)
            cmd.AddParameter("@CXLMESSAGE", CxlMessage)
            cmd.AddParameter("@CS_MESSAGE", CSMessage)
            cmd.AddParameter("@ResponseCode_Cs", ResponseCode)
            cmd.AddParameter("@Status_atcs", Status_atcs)
            cmd.AddParameter("@ProcessedTime", Date.Now)
            cmd.AddParameter("@Inv_no", Invoice_No)
            'cmd.AddParameter("@CreditNote", CreditNote)
            cmd.CmdText = "dbServer.refundinvoices.dbo.REFUND_UPDATEREFUNDCALLS"
            cmd.CmdType = CommandType.StoredProcedure
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As Exception
            Exception = " UpdateRefundCalls: " & ex.Message
        End Try
    End Sub

    Public Sub CanCelOrder(ByVal Dr As DataRow)

        Try
            Dim cmd As New CommandData

            cmd.AddParameter("@MIdentity", Dr.Item("MerchantId"))
            cmd.AddParameter("@CustomerLoginID", Dr.Item("CustomerLoginID"))
            cmd.AddParameter("@InvoiceNo", Dr.Item("InvoiceNumber"))
            cmd.AddParameter("@CreditNoteNo", Dr.Item("CreditNote"))

            cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_UPDATECANCELORDER"
            cmd.CmdType = CommandType.StoredProcedure
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As Exception
            Exception = " CanCelOrder: " & ex.Message

        End Try

    End Sub

    Public Function GetCurrencySymbol(ByVal CCode As String, ByVal GCode As String) As String

        Dim cmd As New CommandData

        Dim Symbol As String
        Try
            cmd.AddParameter("@CurrencyCode", CCode)
            cmd.AddParameter("@GenericCode", GCode)
            cmd.CmdText = "DBSERVER.InfinishopmainDb.dbo.CXLROBO_FETCHCURRENCYSYMBOL"
            Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
            Symbol = ds.Tables(0).Rows(0).Item("sign")

            Return Symbol

        Catch ex As Exception
            cmd = Nothing
            GetCurrencySymbol = Nothing
            Exception = " GetCurrencySymbol: " & ex.Message

        Finally
            cmd = Nothing
        End Try
    End Function

    Public Function GetRidFromCS(ByVal ac As String, ByVal CustID As String, ByVal MerchantId As String, ByVal formateddate2 As String, ByVal Amount As Double, ByVal invoiceDetail As String, ByVal Invoice As String, ByVal formateddate1 As String, ByVal invoiceStatus As String, ByVal OrderID As Integer, ByVal paymentmode As String, ByVal sCompanyName As String, ByVal Rid As String, ByVal del_add As String, ByVal InvoiceStat As String, ByVal Sender As String, ByVal TranMode As String, ByVal GCode As String, ByVal CCode As String, ByVal Symbol As String) As DataSet
        Dim cmd As New CommandData(MerchantId)
        Try
            cmd.AddParameter("@ac", ac)
            cmd.AddParameter("@customerID", CustID)
            cmd.AddParameter("@merchantID", CInt(MerchantId))
            cmd.AddParameter("@invoiceDate", formateddate2)
            cmd.AddParameter("@invoiceAmount", Amount)
            cmd.AddParameter("@invoiceDetail", invoiceDetail)
            cmd.AddParameter("@invoiceType", Invoice)
            cmd.AddParameter("@invoiceReq", 0)
            cmd.AddParameter("@invoiceTime", formateddate1)
            cmd.AddParameter("@creditStatus", invoiceStatus)
            cmd.AddParameter("@order_id", OrderID)
            cmd.AddParameter("@desref", 0)
            cmd.AddParameter("@paymentMode", paymentmode)
            cmd.AddParameter("@sCompanyName", sCompanyName)
            cmd.AddParameter("@sTrackingNo", Rid)
            cmd.AddParameter("@deliveryAddress", del_add)
            cmd.AddParameter("@requestStatus", InvoiceStat)
            cmd.AddParameter("@sender", Sender)
            cmd.AddParameter("@transactionMode", TranMode)
            cmd.AddParameter("@Currency_no", GCode)
            cmd.AddParameter("@Currency_Code", CCode)
            cmd.AddParameter("@Currency_symbol", Symbol)
            'cmd.CmdText = "M" & MerchantId & ".dbo.CAM_ADDINVOICE"
            cmd.CmdText = "CAM_ADDINVOICE"
            Return cmd.Execute(ExecutionType.ExecuteDataSet)

        Catch ex As Exception
            Exception = " GetRidFromCS: " & ex.Message

            cmd = Nothing
            GetRidFromCS = Nothing
        Finally
            cmd = Nothing
        End Try
    End Function
    Public Sub UpdateTrackid(ByVal CustLoginId As String, ByVal MerchantId As String, ByVal Trackid As Integer, ByVal OrderID As String, ByVal inv_no As String, ByVal CreditNote As String)

        Dim cmd As New CommandData
        Try
            cmd.AddParameter("@MIdentity", CInt(MerchantId))
            cmd.AddParameter("@CustomerLoginID", CustLoginId)
            cmd.AddParameter("@Orderbooked", CInt(OrderID))
            cmd.AddParameter("@Trackid_atcs", Trackid)
            cmd.AddParameter("@Invoice_no", inv_no)
            cmd.AddParameter("@CreditNoteNo", CreditNote)

            cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_UPDATENEWTRACKID"
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As Exception
            Exception = " UpdateTrackid: " & ex.Message

        Finally
            cmd = Nothing
        End Try
    End Sub

    Public Sub CSAdminAutomateProcessInvoice(ByVal MID As String, ByVal Amount As Double, ByVal rid As Long, ByVal TransactionType As String, ByVal Inv_no As String)

        Dim cmd As New CommandData(MID)

        Try
            cmd.BeginTransaction(True)
            cmd.AddParameter("@mid", MID)
            cmd.AddParameter("@amt", Amount)
            cmd.AddParameter("@rid", rid)
            cmd.AddParameter("@InvoiceType", TransactionType)
            cmd.AddParameter("@invNo", CInt(Inv_no)) 'Optional Parameter

            cmd.CmdText = "collectionService_Administration_AutomateProcessInvoice"
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.Commit()

        Catch ex As Exception
            Exception = " CSAdminAutomateProcessInvoice: " & ex.Message

            cmd.RollBack()
        Finally
            cmd = Nothing
        End Try
    End Sub

    Public Function GetAmountFromCalls_ATCS(ByVal MID As String, ByVal Cloginid As String, ByVal oid As String, ByVal Inv_No As String, ByVal Old_trackid As String) As DataSet

        Dim cmd As New CommandData()

        Try

            cmd.AddParameter("@Mid", MID)
            cmd.AddParameter("@CLoginId", Cloginid)
            cmd.AddParameter("@OrderID", oid)
            cmd.AddParameter("@InvNo", CInt(Inv_No)) 'Optional Parameter
            cmd.AddParameter("@OldTrackid", Old_trackid)

            cmd.CmdText = "DBSERVER.REFUNDINVOICES.dbo.REFUND_GETCALLS_ATCSAMOUNT"
            Return (cmd.Execute(ExecutionType.ExecuteDataSet))


        Catch ex As Exception
            Exception = " GetAmountFromCalls_ATCS: " & ex.Message

            cmd = Nothing
            GetAmountFromCalls_ATCS = Nothing
        Finally
            cmd = Nothing
        End Try
    End Function
End Class
