Imports MySql.Data.MySqlClient
Imports System.IO
Imports InfiniLogic.AccountsCentre.common

Namespace CXL

    Public Class CXLTRANSACTION

        Dim Except As String

        Dim DB_NAME As String
        Dim threeDSecureTransSession As String = ""
#Region "...................Properties..................."

        Public Property GetExcept() As String
            Get
                Return Except
            End Get
            Set(ByVal Value As String)
                Except = Value
            End Set
        End Property

#End Region

        Sub New()

            '  configreader.GetItem(

        End Sub

#Region "..................Procedures...................."

        Public Sub UpdateResponse_New(ByVal MerchantId As String, ByVal CustLoginId As String, ByVal OrderID As String, ByVal Status As String, ByVal Cs_MSG As String, ByVal ResponseCode_Cs As String, ByVal Invoice_no As Integer, ByVal Rid As Long, ByVal CxlIdentity As Integer, Optional ByVal MPI_Session As String = "", Optional ByVal CxlCode As String = "NULL", Optional ByVal CxlMsg As String = "NULL")

            Dim cmd As New CommandData

            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@CLOGINID", CustLoginId)
                cmd.AddParameter("@ORDERID", CInt(OrderID))
                cmd.AddParameter("@Trackid", Rid)
                cmd.AddParameter("@CXLCODE", CxlCode)
                cmd.AddParameter("@CXLMESSAGE", CxlMsg)
                cmd.AddParameter("@CS_MESSAGE", Cs_MSG)
                cmd.AddParameter("@ResponseCode_Cs", ResponseCode_Cs)
                cmd.AddParameter("@Status_atcs", Status)
                cmd.AddParameter("@ProcessedTime", DateTime.Now)
                cmd.AddParameter("@Inv_no", Invoice_no)
                cmd.AddParameter("@cxlIdentity", CxlIdentity)

                cmd.CmdText = "DBSERVER.CXLTransaction.dbo.CXLROBO_UPDATEDATA"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

                'Update record for 3D Security by Saad 22/04/08
                If MPI_Session <> "" Then
                    If CxlCode = "" Then CxlCode = "-1"
                    If CInt(CxlCode) >= 0 Then
                        UpdateStatusFor3DSecurity(CInt(MPI_Session), CInt(OrderID), CInt(CxlCode), CxlMsg)
                    Else
                        UpdateStatusFor3DSecurity(CInt(MPI_Session), CInt(OrderID), CInt(ResponseCode_Cs), Cs_MSG)
                    End If
                End If
                '////////////////////////////////////////////////////

            Catch ex As Exception
                Except = "UpdateResponse Method : " & ex.Message
            Finally
                cmd = Nothing
                threeDSecureTransSession = ""
            End Try
        End Sub
        Public Sub UpdateResponse(ByVal MerchantId As String, ByVal CustLoginId As String, ByVal OrderID As String, ByVal Status As String, ByVal Cs_MSG As String, ByVal ResponseCode_Cs As String, ByVal Invoice_no As Integer, ByVal Rid As Long, ByVal CxlIdentity As Integer, Optional ByVal MPI_Session As String = "", Optional ByVal CxlCode As String = "NULL", Optional ByVal CxlMsg As String = "NULL")

            Dim cmd As New CommandData(-1)

            cmd.CmdText = "SET XACT_ABORT ON"
            cmd.CmdType = CommandType.Text
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.BeginTransaction(True)

            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@CLOGINID", CustLoginId)
                cmd.AddParameter("@ORDERID", CInt(OrderID))
                cmd.AddParameter("@Trackid", Rid)
                cmd.AddParameter("@CXLCODE", CxlCode)
                cmd.AddParameter("@CXLMESSAGE", CxlMsg)
                cmd.AddParameter("@CS_MESSAGE", Cs_MSG)
                cmd.AddParameter("@ResponseCode_Cs", ResponseCode_Cs)
                cmd.AddParameter("@Status_atcs", Status)
                cmd.AddParameter("@ProcessedTime", DateTime.Now)
                cmd.AddParameter("@Inv_no", Invoice_no)
                cmd.AddParameter("@cxlIdentity", CxlIdentity)

                cmd.CmdText = "CXLROBO_UPDATEDATA"
                cmd.CmdType = CommandType.StoredProcedure
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd.Commit()

                'Update record for 3D Security by Saad 22/04/08
                If MPI_Session <> "" Then
                    If CxlCode = "" Then CxlCode = "-1"
                    If CInt(CxlCode) >= 0 Then
                        UpdateStatusFor3DSecurity(CInt(MPI_Session), CInt(OrderID), CInt(CxlCode), CxlMsg)
                    Else
                        UpdateStatusFor3DSecurity(CInt(MPI_Session), CInt(OrderID), CInt(ResponseCode_Cs), Cs_MSG)
                    End If
                End If
                '////////////////////////////////////////////////////

            Catch ex As Exception
                cmd.RollBack()
                Except = "UpdateResponse Method : " & ex.Message

            Finally
                cmd.CmdText = "SET XACT_ABORT OFF"
                cmd.CmdType = CommandType.Text
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd = Nothing

                threeDSecureTransSession = ""
            End Try
        End Sub
        Public Function GetmerchantInfoPaypal(ByVal Customer_id As String) As DataSet

            Dim cmd As New CommandData
            Try
                cmd.AddParameter("@cart_customer_uid", Customer_id)
                cmd.CmdText = "DBSERVER.INFINISHOPMAINDB.dbo.INFINISHOPS_MERCHANT_GETINFO"
                GetmerchantInfoPaypal = cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "GetmerchantInfoPaypal Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Sub UpdateStatusFor3DSecurity(ByVal SessionId As Integer, ByVal OrderId As Integer, ByVal CXLProcessedErrorCode As Integer, ByVal CXLProcessedErrorDescription As String)

            Dim cmd As New CommandData
            Try

                cmd.AddParameter("@SessionId", SessionId)
                cmd.AddParameter("@OrderId", OrderId)
                cmd.AddParameter("@CXLProcessedErrorCode", CXLProcessedErrorCode)
                cmd.AddParameter("@CXLProcessedErrorDescription", CXLProcessedErrorDescription)

                'Modified by: Muhammad Furqan Khan 30 MAR 2010
                'PS: MPI database changed to CxlTransaction on request of Greesh Bhai
                'cmd.CmdText = "DBSERVER.MPI.DBO.MPI_UpdateMPILogForCXLProcessedOrder"
                cmd.CmdText = "DBSERVER.CxlTransaction.DBO.MPI_UpdateMPILogForCXLProcessedOrder"

                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateStatusFor3DSecurity Method : " & ex.Message

            Finally
                cmd = Nothing
            End Try
        End Sub
        'SZ:BP
        Public Sub UpdateResponseForBP_New(ByVal MerchantId As String, ByVal CustLoginId As String, ByVal OrderID As String, ByVal Status As String, ByVal Cs_MSG As String, ByVal ResponseCode_Cs As String, ByVal Invoice_no As Integer, ByVal Rid As Long, Optional ByVal CxlCode As String = "NULL", Optional ByVal CxlMsg As String = "NULL")
            Dim cmd As New CommandData(MerchantId)

            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@CLOGINID", CustLoginId)
                cmd.AddParameter("@ORDERID", CInt(OrderID))
                cmd.AddParameter("@Trackid", Rid)
                cmd.AddParameter("@CXLCODE", CxlCode)
                cmd.AddParameter("@CXLMESSAGE", CxlMsg)
                cmd.AddParameter("@CS_MESSAGE", Cs_MSG)
                cmd.AddParameter("@ResponseCode_Cs", ResponseCode_Cs)
                cmd.AddParameter("@Status_atcs", Status)
                cmd.AddParameter("@ProcessedTime", DateTime.Now)
                cmd.AddParameter("@Inv_no", Invoice_no)

                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_UPDATEDATA_FOR_BP"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "CXLROBO_UPDATEDATA_FOR_BP Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Sub UpdateResponseForBP(ByVal MerchantId As String, ByVal CustLoginId As String, ByVal OrderID As String, ByVal Status As String, ByVal Cs_MSG As String, ByVal ResponseCode_Cs As String, ByVal Invoice_no As Integer, ByVal Rid As Long, Optional ByVal CxlCode As String = "NULL", Optional ByVal CxlMsg As String = "NULL")
            Dim cmd As New CommandData(-1)
            cmd.CmdText = "SET XACT_ABORT ON"
            cmd.CmdType = CommandType.Text
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.BeginTransaction(True)
            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@CLOGINID", CustLoginId)
                cmd.AddParameter("@ORDERID", CInt(OrderID))
                cmd.AddParameter("@Trackid", Rid)
                cmd.AddParameter("@CXLCODE", CxlCode)
                cmd.AddParameter("@CXLMESSAGE", CxlMsg)
                cmd.AddParameter("@CS_MESSAGE", Cs_MSG)
                cmd.AddParameter("@ResponseCode_Cs", ResponseCode_Cs)
                cmd.AddParameter("@Status_atcs", Status)
                cmd.AddParameter("@ProcessedTime", DateTime.Now)
                cmd.AddParameter("@Inv_no", Invoice_no)

                cmd.CmdText = "CXLROBO_UPDATEDATA_FOR_BP"
                cmd.CmdType = CommandType.StoredProcedure
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd.Commit()

            Catch ex As Exception
                cmd.RollBack()
                Except = "CXLROBO_UPDATEDATA_FOR_BP Method : " & ex.Message
            Finally
                cmd.CmdText = "SET XACT_ABORT OFF"
                cmd.CmdType = CommandType.Text
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpdateTrackid_New(ByVal CustLoginId As String, ByVal MerchantId As String, ByVal Trackid As Integer, ByVal OrderID As String, ByVal cxlIdentity As Integer, Optional ByVal inv_no As String = "0")

            Dim cmd As New CommandData
            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@CLOGINID", CustLoginId)
                cmd.AddParameter("@O_ID", CInt(OrderID))
                cmd.AddParameter("@Rid", Trackid)
                cmd.AddParameter("@INv_no", inv_no)
                cmd.AddParameter("@cxlidentity", cxlIdentity)

                cmd.CmdText = "DBSERVER.CXLTransaction.dbo.CXLROBO_UPDATETRACKID"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateTrackid Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Sub UpdateTrackid(ByVal CustLoginId As String, ByVal MerchantId As String, ByVal Trackid As Integer, ByVal OrderID As String, ByVal cxlIdentity As Integer, Optional ByVal inv_no As String = "0")

            Dim cmd As New CommandData(-1)
            cmd.CmdText = "SET XACT_ABORT ON"
            cmd.CmdType = CommandType.Text
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.BeginTransaction(True)

            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@CLOGINID", CustLoginId)
                cmd.AddParameter("@O_ID", CInt(OrderID))
                cmd.AddParameter("@Rid", Trackid)
                cmd.AddParameter("@INv_no", inv_no)
                cmd.AddParameter("@cxlidentity", cxlIdentity)

                cmd.CmdText = "CXLROBO_UPDATETRACKID"
                cmd.CmdType = CommandType.StoredProcedure
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd.Commit()

            Catch ex As Exception
                cmd.RollBack()
                Except = "UpdateTrackid Method : " & ex.Message
            Finally
                cmd.CmdText = "SET XACT_ABORT OFF"
                cmd.CmdType = CommandType.Text
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd = Nothing
            End Try
        End Sub
        Public Function GetTrackFromMledger_New(ByVal track_id As Integer) As DataSet

            Dim cmd As New CommandData
            Try
                cmd.AddParameter("@track_id", track_id)
                cmd.CmdText = "DBSERVER.CXLTransaction.dbo.CXLRobo_Get_Mledger_By_Track"
                GetTrackFromMledger_New = cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "UpdateTrackid Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GetTrackFromMledger(ByVal track_id As Integer) As DataSet

            Dim cmd As New CommandData(-1)
            Try
                cmd.AddParameter("@track_id", track_id)
                cmd.CmdText = "CXLRobo_Get_Mledger_By_Track"
                GetTrackFromMledger = cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "GetTrackFromMledger_New Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Sub UpdatePaymentProcessor(ByVal Trackid As Integer, ByVal PaymentProcessr As String)

            Dim cmd As New CommandData
            Try

                cmd.AddParameter("@rid", Trackid)
                cmd.AddParameter("@pyamentprocessor", PaymentProcessr)

                cmd.CmdText = "DBSERVER.INFINISHOPMAINDB.dbo.CAM_Update_PaymentProcessor"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdatePaymentProcessor Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Sub UpdateTrackidInPro_invoiceForPRO(ByVal MerchantId As String, ByVal CustLoginId As String, ByVal Trackid As Integer, ByVal inv_no As String)

            Dim cmd As New CommandData(MerchantId) 'Customer Dbgateway connection 
            Try
                cmd.AddParameter("@MID", CInt(MerchantId))
                cmd.AddParameter("@ac", CustLoginId)
                cmd.AddParameter("@Inv_NO", inv_no)
                cmd.AddParameter("@TrackId", Trackid)

                cmd.CmdText = "CXLROBO_UPDATE_TRACKID_IN_PRO_INVOICE"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateTrackidInPro_invoiceForPRO For PRo Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpDatePayAmount(ByVal MerchantId As String, ByVal OrderID As Integer, ByVal PaidAmount As Double, ByVal CC_Status As String)

            Dim cmd As New CommandData(MerchantId)
            Try
                cmd.AddParameter("@Order_Id", OrderID)
                cmd.AddParameter("@pay_amt", PaidAmount)
                cmd.AddParameter("@ccStatus", CC_Status)
                cmd.CmdText = "INFINISHOPS_ORDER_UPDATE_PAYAMOUNT_ORDER_STATUS"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpDatePayAmount Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Sub UpDatePayAmountProInvoice(ByVal MerchantId As String, ByVal inv_no As Integer, ByVal pay_amt As Double)

            Dim cmd As New CommandData(MerchantId)
            Try
                cmd.AddParameter("@MIdentity", MerchantId) 'Added by Saad 10/01/08
                cmd.AddParameter("@inv_no", inv_no)
                cmd.AddParameter("@pay_amt", pay_amt)

                cmd.CmdText = "CXLROBO_UPADATE_PAY_AMT_PRO_INVOICE"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpDatePayAmountProInvoice Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub

        'Public Sub UpdateCreditCardDetail(ByVal MerchantID As String, ByVal CustomerID As String, ByVal rid As Long, ByVal CxlMessage As String, ByVal cardno As String, ByVal cardnam As String, ByVal cardtype As String, ByVal CardExpiry As Date, ByVal cardaddress As String, ByVal TransactionStatus As String, ByVal OrderID As Integer, ByVal SecurityCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IssueNumber As String)

        '    Dim cmd As New CommandData(MerchantID)
        '    Try
        '        cmd.AddParameter("@mid", MerchantID)
        '        cmd.AddParameter("@cid", CustomerID)
        '        cmd.AddParameter("@rid", rid)
        '        cmd.AddParameter("@fDetails", CxlMessage)
        '        cmd.AddParameter("@fDateTime", DateTime.Now)
        '        cmd.AddParameter("@cardNo", cardno)
        '        cmd.AddParameter("@cardName", cardnam)
        '        cmd.AddParameter("@cardType", cardtype)
        '        cmd.AddParameter("@cardExp", CardExpiry)
        '        cmd.AddParameter("@cardAdd", cardaddress)
        '        cmd.AddParameter("@vAuth", TransactionStatus)
        '        cmd.AddParameter("@order_id", OrderID)
        '        cmd.AddParameter("@securitycode", SecurityCode)
        '        cmd.AddParameter("@startdate", StartDate)
        '        cmd.AddParameter("@enddate", EndDate)
        '        cmd.AddParameter("@issue_no", IssueNumber)

        '        '  cmd.CmdText = "M" & MerchantID & ".dbo.CAM_CreditCardDetails"
        '        cmd.CmdText = "CAM_CreditCardDetails"
        '        cmd.Execute(ExecutionType.ExecuteNonQuery)

        '    Catch ex As Exception
        '        cmd = Nothing
        '        Except = "UpdateCreditCardDetail Method : " & ex.Message
        '    Finally
        '        cmd = Nothing
        '    End Try
        'End Sub
        Public Sub UpdateCreditCardDetail(ByVal MerchantID As String, ByVal CustomerID As String, ByVal rid As Long, ByVal CxlMessage As String, ByVal cardno As String, ByVal cardnam As String, ByVal cardtype As String, ByVal CardExpiry As Date, ByVal cardaddress As String, ByVal TransactionStatus As String, ByVal OrderID As Integer, ByVal SecurityCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IssueNumber As String, ByVal Key As String)

            Dim cmd As New CommandData(MerchantID)
            Try
                If (SecurityCode = "" Or IssueNumber = "") Then
                    SecurityCode = 0
                    IssueNumber = 0
                End If

                cmd.AddParameter("@mid", MerchantID)
                cmd.AddParameter("@cid", CustomerID)
                cmd.AddParameter("@rid", rid)
                cmd.AddParameter("@fDetails", CxlMessage)
                cmd.AddParameter("@fDateTime", DateTime.Now)
                cmd.AddParameter("@cardNo", cardno)
                cmd.AddParameter("@cardName", cardnam)
                cmd.AddParameter("@cardType", cardtype)
                cmd.AddParameter("@cardExp", CardExpiry)
                cmd.AddParameter("@cardAdd", cardaddress)
                cmd.AddParameter("@vAuth", TransactionStatus)
                cmd.AddParameter("@order_id", OrderID)
                cmd.AddParameter("@securitycode", SecurityCode)
                cmd.AddParameter("@startdate", StartDate)
                cmd.AddParameter("@enddate", EndDate)
                cmd.AddParameter("@issue_no", IssueNumber)
                cmd.AddParameter("@key", Key)


                cmd.CmdText = "CollectionService_Administration_CreditCardDetails"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception

                Except = "UpdateCreditCardDetail Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Sub UpdateCreditCardDetailAndCXLMsgInInvoice(ByVal MerchantID As String, ByVal CustomerID As String, ByVal CXL_Digit As String, ByVal cardno As String, ByVal cardnam As String, ByVal cardtype As String, ByVal CardExpiry As Date, ByVal cardaddress As String, ByVal OrderID As Integer, ByVal SecurityCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IssueNumber As String, ByVal Key As String, ByVal CurrencyCode As String, ByVal GenericCode As String, ByVal Account As String)

            Dim cmd As New CommandData(MerchantID)
            Try
                cmd.AddParameter("@Midentity", MerchantID)
                cmd.AddParameter("@cid", CustomerID)
                cmd.AddParameter("@cardNo", cardno)
                cmd.AddParameter("@cardName", cardnam)
                cmd.AddParameter("@cardType", cardtype)
                cmd.AddParameter("@cardExp", CardExpiry)
                cmd.AddParameter("@cardAdd", cardaddress)
                cmd.AddParameter("@order_id", OrderID)
                cmd.AddParameter("@securitycode", SecurityCode)
                cmd.AddParameter("@startdate", StartDate)
                cmd.AddParameter("@enddate", EndDate)
                cmd.AddParameter("@issue_no", IssueNumber)
                cmd.AddParameter("@key", Key)
                cmd.AddParameter("@CurrencyCode", CurrencyCode)
                cmd.AddParameter("@GenericCode", GenericCode)
                cmd.AddParameter("@Account", Account)
                cmd.AddParameter("@CXLDigit", CXL_Digit)

                'cmd.AddParameter("@Dbname", GetDBName(MerchantID)) 'Comment by Saad 10/01/08

                cmd.CmdText = "CXLROBO_UpdateCreditCardDetails"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateCreditCardDetailAndCXLMsgInInvoice Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Sub UpdateDetailAndCXLMsgInInvoice(ByVal MerchantID As String, ByVal CustomerID As String, ByVal CXL_Digit As String, ByVal cardno As String, ByVal cardnam As String, ByVal cardtype As String, ByVal CardExpiry As Date, ByVal cardaddress As String, ByVal OrderID As Integer, ByVal SecurityCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IssueNumber As String, ByVal Key As String, ByVal CurrencyCode As String, ByVal GenericCode As String, ByVal Account As String)

            Dim cmd As New CommandData(MerchantID)
            Try
                cmd.AddParameter("@Midentity", MerchantID)
                cmd.AddParameter("@cid", CustomerID)
                cmd.AddParameter("@order_id", OrderID)
                cmd.AddParameter("@issue_no", IssueNumber)
                cmd.AddParameter("@Account", Account)
                cmd.AddParameter("@CXLDigit", CXL_Digit)

                'cmd.AddParameter("@Dbname", GetDBName(MerchantID)) 'Comment by Saad 10/01/08

                cmd.CmdText = "CXLROBO_UpdateDetailsInInvoice"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateDetailAndCXLMsgInInvoice Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Function GetMCKEY(ByVal MerchantID As String, ByVal Customerid As String) As String

            Dim cmd As New CommandData(MerchantID)
            Try
                cmd.AddParameter("@Midentity", MerchantID)
                'cmd.AddParameter("@Mid", MerchantID)
                cmd.AddParameter("@Cid", Customerid)


                cmd.CmdText = "CXLROBO_GETMCKEY"
                Dim ds As DataSet
                ds = cmd.Execute(ExecutionType.ExecuteDataSet)

                Return (ds.Tables(0).Rows(0).Item("logkey"))

            Catch ex As Exception

                Except = "GetMCKEY Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Sub UpdateCreditCard(ByVal MerchantID As String, ByVal rid As Long, ByVal CxlMessage As String, ByVal TranStatus As String)

            Dim cmd As New CommandData(MerchantID)
            Try
                cmd.AddParameter("@MerchantID", MerchantID)
                cmd.AddParameter("@RequestID", rid)
                cmd.AddParameter("@Status", TranStatus)
                cmd.AddParameter("@FollowupDetails", CxlMessage)

                '   cmd.CmdText = "M" & MerchantID & ".dbo.CAM_UpdateCreditCard"
                cmd.CmdText = "CAM_UpdateCreditCard"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateCreditCard Method : " & ex.Message

            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpdateCustomerType(ByVal Cust_id As String, ByVal m_id As String)

            Dim cmd As New CommandData(m_id)   ' For making connection to customer server_name and its DBGATEWAY
            Try

                cmd.AddParameter("@Customer_id", Cust_id)
                'cmd.AddParameter("@mid", m_id)
                cmd.AddParameter("@Midentity", m_id)

                cmd.CmdText = "CXLROBO_UPDATECUSTOMERTYPE"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateCustomerType Method : " & ex.Message

            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpdateInvoiceStatus(ByVal MerchantID As String, ByVal rid As Long, ByVal InvoiceStatus As String, ByVal CXLResponse As String, ByVal CxlMessage As String, ByVal PaymentMode As String, ByVal OrderID As Integer)

            If (CXLResponse = "") Then
                CXLResponse = "-1"
            End If
            Dim cmd As New CommandData(MerchantID)
            Try

                cmd.AddParameter("@MerchantID", CInt(MerchantID))
                cmd.AddParameter("@RequestID", rid)
                cmd.AddParameter("@RequestStatus", InvoiceStatus)
                cmd.AddParameter("@CXLCode", CXLResponse)
                cmd.AddParameter("@CXLMessage", CxlMessage)
                cmd.AddParameter("@PaymentMode", UCase(PaymentMode))
                cmd.AddParameter("@Order_id", OrderID)
                'cmd.AddParameter("@MIdentity", CInt(MerchantID))

                '   cmd.CmdText = "M" & MerchantID & ".dbo.CAM_UpdateInvoiceStatus"
                cmd.CmdText = "CAM_UpdateInvoiceStatus"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateInvoiceStatus Method : " & ex.Message


            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpdateInvoiceTable(ByVal Merchant_id As String, ByVal OID As String, ByVal CxlMessage As String, ByVal CxlCode As String, ByVal rid As String, ByVal PayProcessBy As String, ByVal CCstatus As String)

            Dim cmd As New CommandData(Merchant_id)
            Try
                cmd.AddParameter("@Midentity", CInt(Merchant_id))
                cmd.AddParameter("@Order_id", OID)
                cmd.AddParameter("@CXLMessage", CxlMessage)
                cmd.AddParameter("@CXLCode", CxlCode)
                cmd.AddParameter("@RequestID", rid)
                cmd.AddParameter("@payProcessBy", PayProcessBy)
                cmd.AddParameter("@CCStatus", CCstatus)
                'cmd.AddParameter("@Dbname", GetDBName(Merchant_id))

                cmd.CmdText = "CXLROBO_UPDATE_INVOICE"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "UpdateInvoiceTable Method : " & ex.Message

            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub CSAdminAutomateProcessInvoice(ByVal MID As String, ByVal Amount As Double, ByVal rid As Long, ByVal TransactionType As String, Optional ByVal Inv_no As String = "0")

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
                Except = "CSAdminAutomateProcessInvoice Method : " & ex.Message
                cmd.RollBack()
            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Function GetRefferalOrder(ByVal MID As Integer, ByVal customer_id As Integer, ByVal order_id As Integer) As DataSet

            'Dim cmd As New CommandData(MID)
            ''Dim ds As DataSet

            'Try

            '    cmd.AddParameter("@merchant_id", MID)
            '    cmd.AddParameter("@order_id", order_id)

            '    cmd.CmdText = "REFERRAL_MERCHANT_GETREFERRALORDER"
            '    GetRefferalOrder = cmd.Execute(ExecutionType.ExecuteDataSet)


            'Catch ex As Exception
            '    Except = "GetRefferalOrder Method : " & ex.Message
            'Finally
            '    cmd = Nothing
            'End Try


            Dim ds As DataSet
            Dim NewMerchantID As Integer
            Dim NewCustomerID As Integer

            Dim cmd As New CommandData(MID)
            Try
                cmd.AddParameter("@MerchantID", MID)
                cmd.AddParameter("@CustomerID", customer_id)
                cmd.AddParameter("@Order_Id", order_id)

                cmd.CmdText = "Coupon_GetMerchantCustomerID"
                ds = cmd.Execute(ExecutionType.ExecuteDataSet)

                If IsNothing(ds) = False Then
                    If ds.Tables(0).Rows.Count > 0 And IsDBNull(ds.Tables(0).Rows(0).Item("MerchantID")) = False Then
                        NewMerchantID = IIf(CStr(ds.Tables(0).Rows(0).Item("MerchantID")) = "", 0, CInt(ds.Tables(0).Rows(0).Item("MerchantID")))
                        NewCustomerID = IIf(CStr(ds.Tables(0).Rows(0).Item("CustomerID")) = "", 0, CInt(ds.Tables(0).Rows(0).Item("CustomerID")))
                    End If
                End If

            Catch ex As Exception
                Except = "Coupon_GetMerchantCustomerID Method : " & ex.Message

            Finally
                cmd.ClearParameters()
                ds = Nothing
            End Try

            '///////////////////////////////////////////////////////////////////////////

            If NewMerchantID > 0 Then
                cmd = New CommandData(NewMerchantID)

                Try
                    cmd.AddParameter("@merchant_id", NewMerchantID)
                    cmd.AddParameter("@order_id", order_id)

                    cmd.CmdText = "REFERRAL_MERCHANT_GETREFERRALORDER"
                    ds = cmd.Execute(ExecutionType.ExecuteDataSet)

                    '---------------------------------------------------------------------
                    If Not ds Is Nothing Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            REFERRAL_PAYCOMMISSION(NewMerchantID, NewCustomerID, order_id)
                        End If
                    End If
                    '---------------------------------------------------------------------
                Catch ex As Exception
                    Except = "GetRefferalOrder Method : " & ex.Message
                Finally
                    cmd = Nothing
                End Try
            End If

        End Function
        Public Function GetMerchantRefferalOrder(ByVal MID As Integer, ByVal customer_id As Integer, ByVal order_id As Integer) As DataSet

            'Dim cmd As New CommandData(MID)
            ''Dim ds As DataSet

            'Try

            '    cmd.AddParameter("@merchant_id", MID)
            '    cmd.AddParameter("@order_id", order_id)

            '    cmd.CmdText = "REFERRAL_MERCHANT_GETREFERRALORDER"
            '    GetRefferalOrder = cmd.Execute(ExecutionType.ExecuteDataSet)


            'Catch ex As Exception
            '    Except = "GetRefferalOrder Method : " & ex.Message
            'Finally
            '    cmd = Nothing
            'End Try


            Dim ds As DataSet
            'Dim NewMerchantID As Integer
            'Dim NewCustomerID As Integer

            Dim cmd As New CommandData(MID)

            'Try
            '    cmd.AddParameter("@MerchantID", MID)
            '    cmd.AddParameter("@CustomerID", customer_id)
            '    cmd.AddParameter("@Order_Id", order_id)

            '    cmd.CmdText = "Coupon_GetMerchantCustomerID"
            '    ds = cmd.Execute(ExecutionType.ExecuteDataSet)

            '    If IsNothing(ds) = False Then
            '        If ds.Tables(0).Rows.Count > 0 And IsDBNull(ds.Tables(0).Rows(0).Item("MerchantID")) = False Then
            '            NewMerchantID = IIf(CStr(ds.Tables(0).Rows(0).Item("MerchantID")) = "", 0, CInt(ds.Tables(0).Rows(0).Item("MerchantID")))
            '            NewCustomerID = IIf(CStr(ds.Tables(0).Rows(0).Item("CustomerID")) = "", 0, CInt(ds.Tables(0).Rows(0).Item("CustomerID")))
            '        End If
            '    End If

            'Catch ex As Exception
            '    Except = "Coupon_GetMerchantCustomerID Method : " & ex.Message

            'Finally
            '    cmd.ClearParameters()
            '    ds = Nothing
            'End Try

            '///////////////////////////////////////////////////////////////////////////

            'If NewMerchantID > 0 Then
            '    cmd = New CommandData(NewMerchantID)

            Try
                cmd.AddParameter("@merchant_id", MID)
                cmd.AddParameter("@order_id", order_id)

                cmd.CmdText = "REFERRAL_MERCHANT_GETREFERRALORDER"
                GetMerchantRefferalOrder = cmd.Execute(ExecutionType.ExecuteDataSet)

                '---------------------------------------------------------------------
                'If Not ds Is Nothing Then
                '    If ds.Tables(0).Rows.Count > 0 Then
                '        REFERRAL_PAYCOMMISSION(MID, customer_id, order_id)
                '    End If
                'End If
                '---------------------------------------------------------------------
            Catch ex As Exception
                Except = "GetRefferalOrder Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try

            'End If

        End Function

        Public Function REFERRAL_PAYCOMMISSION(ByVal MID As Integer, ByVal customer_id As Integer, ByVal order_id As Integer) As DataSet

            Dim cmd As New CommandData(MID)
            Try

                cmd.AddParameter("@merchant_id", MID)
                cmd.AddParameter("@customer_id", customer_id)
                cmd.AddParameter("@order_id", order_id)

                cmd.CmdText = "REFERRAL_MERCHANT_PAYCOMMISSION"
                REFERRAL_PAYCOMMISSION = cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "REFERRAL_PAYCOMMISSION Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function REFERRAL_ATTRIBUTE(ByVal MID As Integer, ByVal order_id As Integer, ByVal attributeKey As String, ByVal attributeValue As String) As DataSet

            Dim cmd As New CommandData(MID)
            Try

                cmd.AddParameter("@MIdentity", MID)
                cmd.AddParameter("@orderID", order_id)
                cmd.AddParameter("@AttributeKey", attributeKey)
                cmd.AddParameter("@AttributeValue", attributeValue)

                cmd.CmdText = "IO_GetOrderDetail_Attribute"
                REFERRAL_ATTRIBUTE = cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "REFERRAL_ATTRIBUTE Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function REFERRAL_PAYCOMMISSION_For_DC2(ByVal MID As Integer, ByVal customer_id As Integer, ByVal order_id As Integer) As DataSet

            Dim cmd As New CommandData(MID)
            Try

                cmd.AddParameter("@merchant_id", MID)
                cmd.AddParameter("@customer_id", customer_id)
                cmd.AddParameter("@order_id", order_id)

                cmd.CmdText = "REFERRAL_MERCHANT_PAYCOMMISSIONForDC2"
                REFERRAL_PAYCOMMISSION_For_DC2 = cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "REFERRAL_PAYCOMMISSION_For_DC2 Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Sub InsertMySqlDataInSqlServer_New(ByVal Cloginid As String, ByVal orderbooked As Integer, ByVal Amount As Double, ByVal requesttime As String, ByVal Timestamp1 As String, ByVal status As String, ByVal cardno As String, ByVal cardtype As String, ByVal cardname As String, ByVal cardaddress As String, ByVal cardexpire As Date, ByVal securitycode As String, ByVal issueno As String, ByVal processtype As String, ByVal genericcode As String, ByVal currencycode As String, ByVal StartDate As Date, ByVal Trackid As Integer, ByVal createinvoice As String, ByVal nocxl As Integer, ByVal authorize As Integer)

            'Dim cmd As New CommandData     ---- Comment by Saad on 02/01/08(Reason: Invalid object name 'M2.dbo.customer',its making connection with Server6.DBGateway)
            Dim cmd As New CommandData(2)  '--- Added by Saad on 02/01/08

            Try
                cmd.AddParameter("@MIdentity", 2)
                ' cmd.AddParameter("@MLoginID", 26)
                cmd.AddParameter("@Cloginid", Cloginid)
                cmd.AddParameter("@orderbooked", orderbooked)
                cmd.AddParameter("@Amount", Amount)

                ' cmd.AddParameter("@requesttime", requesttime)
                '  cmd.AddParameter("@timestamp1 ", Timestamp1)
                cmd.AddParameter("@status", status)
                cmd.AddParameter("@cardno", cardno)
                cmd.AddParameter("@cardtype", cardtype)
                cmd.AddParameter("@cardname", cardname)
                cmd.AddParameter("@cardaddress", cardaddress)
                cmd.AddParameter("@cardexpire", cardexpire)
                cmd.AddParameter("@securitycode", securitycode)
                cmd.AddParameter("@issueno", issueno)
                cmd.AddParameter("@processtype", processtype)
                cmd.AddParameter("@genericcode", genericcode)
                cmd.AddParameter("@currencycode", currencycode)
                cmd.AddParameter("@StartDate", StartDate)
                cmd.AddParameter("@Sender", "FH")
                cmd.AddParameter("@trackid", Trackid)
                cmd.AddParameter("@Create_invoice", createinvoice)
                cmd.AddParameter("@Nocxl", nocxl)
                cmd.AddParameter("@Authorized", authorize)

                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "InsertMySqlDataInSqlServer Method : " & ex.Message

            Finally
                cmd = Nothing
            End Try
        End Sub
        Public Function MPI_ResselerAndActivationData(ByVal order_id As Integer, ByVal merchant_id As Integer, ByVal MLoginID As Integer, ByVal customerID As Integer, ByVal isOrderSuccess As String, ByVal paystatus As String, ByVal paymode As String)

            Dim cmd As New CommandData

            Try
                cmd.AddParameter("@order_id", order_id)
                cmd.AddParameter("@merchant_id", merchant_id)
                cmd.AddParameter("@MLoginID", MLoginID)
                cmd.AddParameter("@CustomerID", customerID)
                cmd.AddParameter("@isOrderSuccess", isOrderSuccess)
                cmd.AddParameter("@payStatus", paystatus)
                cmd.AddParameter("@Paymode", paymode)


                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_INSERTDATA_MPI_ResellerAndActivationData"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "MPI_ResselerAndActivationData Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Sub InsertMySqlDataInSqlServer(ByVal Cloginid As String, ByVal orderbooked As Integer, ByVal Amount As Double, ByVal requesttime As String, ByVal Timestamp1 As String, ByVal status As String, ByVal cardno As String, ByVal cardtype As String, ByVal cardname As String, ByVal cardaddress As String, ByVal cardexpire As Date, ByVal securitycode As String, ByVal issueno As String, ByVal processtype As String, ByVal genericcode As String, ByVal currencycode As String, ByVal StartDate As Date, ByVal Trackid As Integer, ByVal createinvoice As String, ByVal nocxl As Integer, ByVal authorize As Integer)

            'Dim cmd As New CommandData     ---- Comment by Saad on 02/01/08(Reason: Invalid object name 'M2.dbo.customer',its making connection with Server6.DBGateway)
            Dim cmd As New CommandData(2)  '--- Added by Saad on 02/01/08

            Try
                cmd.AddParameter("@MIdentity", 2)
                ' cmd.AddParameter("@MLoginID", 26)
                cmd.AddParameter("@Cloginid", Cloginid)
                cmd.AddParameter("@orderbooked", orderbooked)
                cmd.AddParameter("@Amount", Amount)

                ' cmd.AddParameter("@requesttime", requesttime)
                '  cmd.AddParameter("@timestamp1 ", Timestamp1)
                cmd.AddParameter("@status", status)
                cmd.AddParameter("@cardno", cardno)
                cmd.AddParameter("@cardtype", cardtype)
                cmd.AddParameter("@cardname", cardname)
                cmd.AddParameter("@cardaddress", cardaddress)
                cmd.AddParameter("@cardexpire", cardexpire)
                cmd.AddParameter("@securitycode", securitycode)
                cmd.AddParameter("@issueno", issueno)
                cmd.AddParameter("@processtype", processtype)
                cmd.AddParameter("@genericcode", genericcode)
                cmd.AddParameter("@currencycode", currencycode)
                cmd.AddParameter("@StartDate", StartDate)
                cmd.AddParameter("@Sender", "FH")
                cmd.AddParameter("@trackid", Trackid)
                cmd.AddParameter("@Create_invoice", createinvoice)
                cmd.AddParameter("@Nocxl", nocxl)
                cmd.AddParameter("@Authorized", authorize)

                cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_MERCHANT"
                Dim dataSetMerchant As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)

                If dataSetMerchant.Tables(0).Rows.Count > 0 Then

                    System.Web.HttpContext.Current.Trace.Warn("Order Information has been found in Merchant")

                    cmd.ClearParameters()
                    cmd = Nothing

                    cmd = New CommandData(-1)

                    cmd.CmdText = "SET XACT_ABORT ON"
                    cmd.CmdType = CommandType.Text
                    cmd.Execute(ExecutionType.ExecuteNonQuery)
                    cmd.BeginTransaction(True)

                    cmd.AddParameter("@MIdentity", 2)
                    cmd.AddParameter("@Cloginid", Cloginid)
                    cmd.AddParameter("@orderbooked", orderbooked)
                    cmd.AddParameter("@Amount", Amount)
                    cmd.AddParameter("@status", status)
                    cmd.AddParameter("@cardno", cardno)
                    cmd.AddParameter("@cardtype", cardtype)
                    cmd.AddParameter("@cardname", cardname)
                    cmd.AddParameter("@cardaddress", cardaddress)
                    cmd.AddParameter("@cardexpire", cardexpire)
                    cmd.AddParameter("@securitycode", securitycode)
                    cmd.AddParameter("@issueno", issueno)
                    cmd.AddParameter("@processtype", processtype)
                    cmd.AddParameter("@genericcode", genericcode)
                    cmd.AddParameter("@currencycode", currencycode)
                    cmd.AddParameter("@StartDate", StartDate)
                    cmd.AddParameter("@Sender", "FH")
                    cmd.AddParameter("@trackid", Trackid)
                    cmd.AddParameter("@inv_no", dataSetMerchant.Tables(0).Rows(0).Item("inv_no"))
                    cmd.AddParameter("@Create_invoice", dataSetMerchant.Tables(0).Rows(0).Item("Create_invoice"))
                    cmd.AddParameter("@Nocxl", dataSetMerchant.Tables(0).Rows(0).Item("Nocxl"))
                    cmd.AddParameter("@Authorized", dataSetMerchant.Tables(0).Rows(0).Item("Authorized"))
                    cmd.AddParameter("@IPAddress", dataSetMerchant.Tables(0).Rows(0).Item("IpAddress"))
                    cmd.AddParameter("@houseNo", dataSetMerchant.Tables(0).Rows(0).Item("houseNo"))
                    cmd.AddParameter("@zip", dataSetMerchant.Tables(0).Rows(0).Item("zip"))
                    cmd.AddParameter("@callCentre", dataSetMerchant.Tables(0).Rows(0).Item("callCentre"))
                    cmd.AddParameter("@PaymentProcessor", dataSetMerchant.Tables(0).Rows(0).Item("PaymentProcessor"))
                    cmd.AddParameter("@MTS", dataSetMerchant.Tables(0).Rows(0).Item("MTS"))
                    cmd.AddParameter("@MLoginID", dataSetMerchant.Tables(0).Rows(0).Item("MLoginID"))
                    cmd.AddParameter("@dbname", dataSetMerchant.Tables(0).Rows(0).Item("dbname"))
                    cmd.AddParameter("@CustomerID", dataSetMerchant.Tables(0).Rows(0).Item("CustomerID"))
                    cmd.AddParameter("@AgentName", dataSetMerchant.Tables(0).Rows(0).Item("AgentName"))
                    cmd.AddParameter("@Mode", dataSetMerchant.Tables(0).Rows(0).Item("Mode"))
                    cmd.AddParameter("@ByForce", dataSetMerchant.Tables(0).Rows(0).Item("ByForce"))
                    cmd.AddParameter("@requesttime", dataSetMerchant.Tables(0).Rows(0).Item("requesttime"))
                    cmd.AddParameter("@timestamp1", dataSetMerchant.Tables(0).Rows(0).Item("timestamp1"))
                    cmd.AddParameter("@AgentAcquirer", dataSetMerchant.Tables(0).Rows(0).Item("AgentAcquirer"))
                    cmd.AddParameter("@ServerName", dataSetMerchant.Tables(0).Rows(0).Item("ServerName"))

                    cmd.CmdText = "CXLROBO_INSERTMYSQLDATA_CXLT"

                    cmd.CmdType = CommandType.StoredProcedure
                    cmd.Execute(ExecutionType.ExecuteNonQuery)
                    cmd.Commit()
                End If


            Catch ex As Exception
                cmd.RollBack()
                cmd = Nothing
                Except = "InsertMySqlDataInSqlServer Method : " & ex.Message

            Finally
                cmd.CmdText = "SET XACT_ABORT OFF"
                cmd.CmdType = CommandType.Text
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd = Nothing
            End Try
        End Sub
        '''Implemented on 19th Sept 2006
        Public Sub UpDateInvoiceNoInCledger(ByVal Mid As String, ByVal o_id As Integer, ByVal Rid As Integer, ByVal InvNo As Double)

            Dim cmd As New CommandData(Mid)
            Try
                'cmd.AddParameter("@Mid", Mid)
                cmd.AddParameter("@Midentity", Mid)
                cmd.AddParameter("@order_id", o_id)
                cmd.AddParameter("@rid", Rid)
                cmd.AddParameter("@inv_no", InvNo)

                cmd.CmdText = "CXLROBO_UPDATEINVOICENUMBERINCLEDGER"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception

                Except = "UpDateInvoiceNoInCledger Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub OrderAddDetail(ByVal Mid As String, ByVal o_id As Integer, ByVal OrderNo As String, ByVal Prod_id As Integer, ByVal Prod_code As String, ByVal Qty As Double, ByVal Amount As Double, ByVal Tax As String, ByVal Rate As Double, ByVal UnitPrice As Double, ByVal Inv_Type As String)

            Dim cmd As New CommandData(Mid)

            Try
                cmd.AddParameter("@OrderID", o_id)
                cmd.AddParameter("@OrderNo", OrderNo)
                cmd.AddParameter("@ProductID", Prod_id)
                cmd.AddParameter("@ProductCode", Prod_code)
                cmd.AddParameter("@Qty", Qty)
                cmd.AddParameter("@ProductSalePrice", Amount)
                cmd.AddParameter("@ProductTaxCode", Tax)
                cmd.AddParameter("@TaxCodeRate", Rate)
                cmd.AddParameter("@UnitPrice", UnitPrice)
                cmd.AddParameter("@inv_type", Inv_Type)

                '     cmd.CmdText = "M" & Mid & ".dbo.INFINISHOPS_ORDER_ADDDETAILS"
                cmd.CmdText = "INFINISHOPS_ORDER_ADDDETAILS"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception
                Except = "OrderAddDetail Method : " & ex.Message

            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpDateInvoiceNo(ByVal Mid As String, ByVal o_id As Integer, ByVal InvNo As Double)

            Dim cmd As New CommandData(Mid)
            Try
                cmd.AddParameter("@order_id", o_id)
                cmd.AddParameter("@inv_no", InvNo)

                '  cmd.CmdText = "M" & Mid & ".dbo.INFINISHOPS_ORDER_UPDATE_INVOICE_NO"
                cmd.CmdText = "INFINISHOPS_ORDER_UPDATE_INVOICE_NO"
                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception

                Except = "UpDateInvoiceNo Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub InsertProdMasterDetail(ByVal Mid As String, ByVal InvNo As Integer, ByVal PCode As String, ByVal nc As String, ByVal tc As String, ByVal TCrate As Double, ByVal detail As String, ByVal price As Double, ByVal qty As Double, ByVal net As Double, ByVal vat As Double, ByVal Inv_type As String, ByVal discountAmt As Double, ByVal discountPer As Double)

            Dim cmd As New CommandData(Mid)
            Try
                cmd.AddParameter("@inv_no", InvNo)
                cmd.AddParameter("@prodCode", PCode)
                cmd.AddParameter("@nc", nc)
                cmd.AddParameter("@tc", tc)
                cmd.AddParameter("@tcrate", TCrate)
                cmd.AddParameter("@details", detail)
                cmd.AddParameter("@price", price)
                cmd.AddParameter("@qty", qty)
                cmd.AddParameter("@net", net)
                cmd.AddParameter("@vat", vat)
                cmd.AddParameter("@inv_type", Inv_type)
                cmd.AddParameter("@discAmt", discountAmt)
                cmd.AddParameter("@discPer", discountPer)
                cmd.AddParameter("@MIdentity", Mid)


                'cmd.CmdText = "M" & Mid & ".dbo.ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS"
                cmd.CmdText = "ACCOUNTSPRO_INSERTPRODUCTMASTERDETAILS"

                cmd.Execute(ExecutionType.ExecuteNonQuery)

            Catch ex As Exception

                Except = "InsertProdMasterDetail Method : " & ex.Message
            Finally
                cmd = Nothing
            End Try
        End Sub
        'Public Sub UpdateCustomerFloorLimit(ByVal Cust_id As String, ByVal m_id As String)

        '    Dim cmd As New CommandData(Cust_id, 1)   ' For making connection to customer server_name and its DBGATEWAY
        '    Try

        '        cmd.AddParameter("@Custid", Cust_id)
        '        cmd.AddParameter("@mid", m_id)
        '        cmd.CmdText = "CXLROBO_UPDATECUSTOMERFLOORLIMIT"
        '        cmd.Execute(ExecutionType.ExecuteNonQuery)

        '    Catch ex As Exception
        '        Except = "UpdateCustomerFloorLimit Method : " & ex.Message

        '    Finally
        '        cmd = Nothing
        '    End Try
        'End Sub
        '''Implemented on 19th Sept 2006
        Public Function GetOriginalSender(ByVal M As Integer, ByVal Trackid As Integer) As String

            Dim cmd As New CommandData(M)

            Dim Sender As String
            Try
                cmd.AddParameter("@Mid", M)
                cmd.AddParameter("@Rid", Trackid)

                cmd.CmdText = "CXLROBO_FETCHSENDERFROMCLEDGER"
                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Sender = ds.Tables(0).Rows(0).Item("Sender")

                Return Sender

            Catch ex As Exception
                Except = "GetOriginalSender Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try

        End Function
        Public Function GetCustomerOrderInfo(ByVal Customer_id As String, ByVal M_Id As String, ByVal OrderID As String) As DataSet

            Dim cmd As New CommandData(M_Id)

            Try
                cmd.AddParameter("@MIdentity", M_Id)
                cmd.AddParameter("@orderId", OrderID)
                cmd.AddParameter("@customer_id", Customer_id)

                cmd.CmdText = "CXLROBO_GETCUSTOMERORDERINFO"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception

                Except = "GetCustomerOrderInfo Method : " & ex.Message
                cmd = Nothing

            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GetCustomerOrderInfoMerchantDB(ByVal Customer_id As String, ByVal M_Id As String, ByVal OrderID As String) As DataSet

            Dim cmd As New CommandData(M_Id)

            Try
                cmd.AddParameter("@MIdentity", M_Id)
                cmd.AddParameter("@orderId", OrderID)
                cmd.AddParameter("@customer_id", Customer_id)

                cmd.CmdText = "CXLROBO_GETCUSTOMERORDERINFO_MERCHANTDB"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception

                Except = "GetCustomerOrderInfoMerchantDB Method : " & ex.Message
                cmd = Nothing

            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GetCustomerOrderInfoCXLT(ByVal Customer_id As String, ByVal M_Id As String, ByVal OrderID As String) As DataSet

            Dim cmd As New CommandData(-1)

            Try
                cmd.AddParameter("@MIdentity", M_Id)
                cmd.AddParameter("@orderId", OrderID)
                cmd.AddParameter("@customer_id", Customer_id)

                cmd.CmdText = "CXLROBO_GETCUSTOMERORDERINFO_CXLT"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception

                Except = "GetCustomerOrderInfoCXLT Method : " & ex.Message
                cmd = Nothing

            Finally
                cmd = Nothing
            End Try
        End Function
        '''Implemented on 28th Feb 2007
        Public Function IsRuleBlockbyM2_New(ByVal Curr_Merchant As Integer) As DataSet

            Dim cmd As New CommandData

            Dim Sender As String
            Try

                cmd.AddParameter("@Merchant", Curr_Merchant)

                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_CHECKBLOCKRULEPRESENT"

                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)


                Return (ds)

            Catch ex As Exception
                Except = "IsRuleBlockbyM2 Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try

        End Function

        Public Function IsRuleBlockbyM2(ByVal Curr_Merchant As Integer) As DataSet

            Dim cmd As New CommandData(-1)

            Dim Sender As String
            Try

                cmd.AddParameter("@Merchant", Curr_Merchant)
                cmd.CmdText = "CXLROBO_CHECKBLOCKRULEPRESENT"
                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Return (ds)

            Catch ex As Exception
                Except = "IsRuleBlockbyM2 Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try

        End Function
#End Region

#Region "...................Functions...................."

        Public Sub GETRESPONSEFROMCXL(ByVal CreditCardNo As String, _
        ByVal IssueNumber As String, _
        ByVal TransactionAmount As String, _
        ByVal GCode As String, _
        ByVal MerchantId As String, _
        ByVal CID As String, _
        ByVal OrderID As String, _
        ByVal TransactionType As String, _
        ByVal StartDate As String, _
        ByVal CardExpiry As String, _
        ByVal CardType As String, _
        ByVal Mode As String, _
        ByRef Response As String, _
        ByRef Message As String, _
        ByVal AgentName As String, _
        ByVal AgentAcquirer As String, _
        ByVal rid As Long, _
        ByVal MerchantLoginId As String, _
        ByVal CustomerLoginId As String, _
        ByVal Sender As String, _
        ByVal SecurityCode As String, _
        ByVal CardName As String, _
        Optional ByVal eci As String = "", _
        Optional ByVal xid As String = "", _
        Optional ByVal vts As String = "", _
        Optional ByVal vav As String = "", _
        Optional ByVal MPI_SessionID As String = "", _
        Optional ByVal hn As String = "0", _
        Optional ByVal zp As String = "0", _
        Optional ByVal callcentre As String = "0")


            Dim aa As String

            'Dim CXLOBJ As New CXLWEB.CXLService
            Dim cxlInfini As New com.infini.cxl.Service

            Dim Obj As Object
            Dim CxlUid, CxlPwd, CxlServer As String
            Dim StartDat, CardExpir As Date
            Dim S_date, C_expire As String
            StartDat = StartDate
            CardExpir = CardExpiry

            S_date = Format(StartDat, "MM/yy")
            C_expire = Format(CardExpir, "MM/yy")

            Try
                CxlUid = ConfigReader.GetItem(ConfigVariables.CXLUserID) '"cxlUser"  
                CxlPwd = ConfigReader.GetItem(ConfigVariables.CXLPassword) '"CxlPass"  
                CxlServer = ConfigReader.GetItem(ConfigVariables.CXLServerIP) '"CxlServer"

                cxlInfini.Credentials = New System.Net.NetworkCredential(CxlUid, CxlPwd, CxlServer)

                'Obj = CXL.CXLProcessing("7475", "123",l "4", "826", "2", "7475", "10", "REFUND", "1/1/2005", "12/12/2006", "CType", "TEST", Resp, Msg, "TEST ACCOUNT", "STREAMLINE", 12345678, "26", "7576", "mine")
                'Obj = CXLOBJ.CXLProcessing("7475", "123", "4", "826", "2", "7475", "10", "INVOICE", "1/1/2005", "12/12/2006", "CType", "LIVE", Resp, Msg, "CXL", "AMERICAN EXPRESS", 12345678, "26", "7576", "mine")

                'If eci <> 0 Or xid <> "" Or vts <> "" Or vav <> "" Or MPI_SessionID <> "" Then

                If MPI_SessionID <> "" Then '3D Secure order
                    threeDSecureTransSession = MPI_SessionID
                    'Obj = CXLOBJ.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, SecurityCode, eci, xid, vts, vav, MPI_SessionID, hn, zp, CardName)
                    Obj = cxlInfini.CXLProcessing43DS(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, SecurityCode, eci, xid, vts, vav, MPI_SessionID, hn, zp, CardName, callcentre)

                Else
                    If (SecurityCode = "") Then
                        'Obj = CXLOBJ.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, hn, zp, CardName, callcentre)
                        Obj = cxlInfini.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, "0", hn, zp, CardName, callcentre)
                    Else
                        If (Len(SecurityCode) = 4 And UCase(CardType) = "AMEX CARD") Then
                            'Obj = CXLOBJ.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, SecurityCode, hn, zp, CardName, callcentre)
                            Obj = cxlInfini.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, SecurityCode, hn, zp, CardName, callcentre)
                        ElseIf (Len(SecurityCode) = 3 And Not UCase(CardType) = "AMEX CARD") Then  '(CardType = "Visa Card" Or CardType = "Master Card/Euro Card" Or CardType = "Diners Club / Carte Balanche" Or CardType = "Debit Card" Or CardType = "JCB" Or CardType = "Switch Card" Or CardType = "enRoute" Or CardType = "Discover")) Then
                            'Obj = CXLOBJ.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, SecurityCode, hn, zp, CardName, callcentre)
                            Obj = cxlInfini.CXLProcessing(CreditCardNo, IssueNumber, TransactionAmount, GCode, MerchantId, CID, OrderID, TransactionType, S_date, C_expire, CardType, Mode, Response, Message, AgentName, AgentAcquirer, rid, MerchantLoginId, CustomerLoginId, Sender, SecurityCode, hn, zp, CardName, callcentre)
                        Else
                            Response = "-5"
                            Message = "Wrong Security Card Length"
                        End If
                    End If
                End If

            Catch ex As Exception
                Except = "GETRESPONSEFROMCXL Method : " & ex.Message
                ' Obj = Nothing
            Finally
                Obj = Nothing
                'CXLOBJ.Dispose()
                'CXLOBJ = Nothing

                cxlInfini.Dispose()
                cxlInfini = Nothing

                eci = Nothing
                xid = Nothing
                vts = Nothing
                vav = Nothing
                MPI_SessionID = Nothing
                hn = Nothing
                zp = Nothing
                callcentre = Nothing

            End Try
        End Sub
        Public Function CheckingValidityOfCallcentre_New(ByVal order_id As Integer, ByVal MerchantId As Integer, Optional ByVal response_code As String = "0") As DataSet
            Dim cmd As New CommandData

            Try
                cmd.AddParameter("@orderbooked", order_id)
                cmd.AddParameter("@mid", MerchantId)
                cmd.AddParameter("@responsecode_cs", response_code)
                'cmd.AddParameter("@csmessage", csmessage)

                cmd.CmdText = "DBSERVER.CXLTransaction.dbo.CXLROBO_CHECKVALIDCALLCENTRE"
                CheckingValidityOfCallcentre_New = cmd.Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Except = "CheckingValidityOfCallcentre Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function CheckingValidityOfCallcentre(ByVal order_id As Integer, ByVal MerchantId As Integer, Optional ByVal response_code As String = "0") As DataSet
            Dim cmd As New CommandData(-1)

            Try
                cmd.AddParameter("@orderbooked", order_id)
                cmd.AddParameter("@mid", MerchantId)
                cmd.AddParameter("@responsecode_cs", response_code)
                'cmd.AddParameter("@csmessage", csmessage)

                cmd.CmdText = "CXLROBO_CHECKVALIDCALLCENTRE"
                CheckingValidityOfCallcentre = cmd.Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Except = "CheckingValidityOfCallcentre Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function IsCXLUp() As String

            'Dim CXLOBJ As New CXLWEB.CXLService
            Dim CXLOBJ As New com.infini.cxl.Service

            Dim CxlUid, CxlPwd, CxlServer As String
            Dim Status As String

            Try
                CxlUid = ConfigReader.GetItem(ConfigVariables.CXLUserID) '"cxlUser"  
                CxlPwd = ConfigReader.GetItem(ConfigVariables.CXLPassword) '"CxlPass"  
                CxlServer = ConfigReader.GetItem(ConfigVariables.CXLServerIP) '"CxlServer"
                ''''' CXLOBJ.Credentials = New System.Net.NetworkCredential("Rehan", "Rehan", "192.168.4.81")

                CXLOBJ.Credentials = New System.Net.NetworkCredential(CxlUid, CxlPwd, CxlServer)

                Status = CXLOBJ.IfCXLLive()

                Return Status

            Catch ex As Exception
                Except = "IsCXLUp Method : " & ex.Message
                ' Obj = Nothing
            Finally
                CXLOBJ.Dispose()
                CXLOBJ = Nothing

            End Try
        End Function
        Public Sub GETRESPONSEFROMPAYPAL(ByVal PaypalId As String, ByVal PaypalPassword As String, ByVal Environment As String, ByVal CreditCardNo As String, ByVal CardType As String, ByVal SecurityCode As String, ByVal CardExpiry As String, ByVal TotalAmount As String, ByVal MoneyType As String, ByVal MId As String, ByVal OID As String, ByVal Rid As String, ByRef Code As String, ByRef Response As String)

            Dim PAYPALOBJ As New InfiniPayPal.InfiniPayPalWebService

            Dim EndMonth, EndYear As Integer

            EndMonth = CInt(CDate(CardExpiry).Month)
            EndYear = CInt(CDate(CardExpiry).Year)

            If (Len(EndMonth) = 1) Then
                EndMonth = "0" & EndMonth
            End If
            Try
                'CxlUid = ConfigReader.GetItem(ConfigVariables.CXLUserID) '"cxlUser"  
                'CxlPwd = ConfigReader.GetItem(ConfigVariables.CXLPassword) '"CxlPass"  
                'CxlServer = ConfigReader.GetItem(ConfigVariables.CXLServerIP) '"CxlServer"
                '  CXLOBJ.Credentials = New System.Net.NetworkCredential(CxlUid, CxlPwd, CxlServer)
                Dim InvoiceID As String
                InvoiceID = "T" & Rid & "-O" & OID & "-M" & MId

                PAYPALOBJ.MakeTransaction(Trim(PaypalId), Trim(PaypalPassword), Environment, CreditCardNo, GetCardEquivalentNumber(CardType), SecurityCode, CStr(EndMonth), CStr(EndYear), TotalAmount, MoneyType, InvoiceID, Code, Response)


            Catch ex As Exception
                Except = "GETRESPONSEFROMPAYPAL Method : " & ex.Message
            Finally
                'PAYPALOBJ.Dispose()
                'PAYPALOBJ = Nothing
            End Try
        End Sub
        Private Function GetCardEquivalentNumber(ByVal Cardtype As String) As Integer
            Select Case Cardtype

                Case "Visa Card"
                    Return 0
                Case "Master Card"
                    Return 1
                Case "Discover"
                    Return 2
                Case "AmericanExpress"
                    Return 3
                Case "Switch"
                    Return 4
                Case "Solo"
                    Return 5

            End Select



        End Function
        Public Function GETDataFromDB_New(ByVal Identity As String) As DataSet
            Dim cmd As New CommandData
            Try
                cmd.AddParameter("@DataCentreType", Identity)
                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_FETCHDATA"
                Return cmd.Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Except = "GETDataFromDB Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GETDataFromDB(ByVal Identity As String) As DataSet
            Dim cmd As New CommandData(-1)
            Try
                cmd.AddParameter("@DataCentreType", Identity)
                cmd.CmdText = "CXLROBO_FETCHDATA"
                Return cmd.Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Except = "GETDataFromDB Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Function CheckServiceEnable(ByVal Mid As String, ByVal Pcode As String) As Boolean
            Dim cmd As New CommandData
            Dim ds As DataSet
            Try
                cmd.AddParameter("@CustomerId", CInt(Mid))
                cmd.AddParameter("@ProductCode", Pcode)
                'cmd.CmdText = "CXLROBO_EXECUTE_INFINISHOPS_ISHOPSWEBSERVICES_CHECK_IS_SERVICE_ENABLE"
                cmd.CmdText = "DBSERVER.infinishopmainDB.dbo.INFINISHOPS_ISHOPSWEBSERVICES_CHECK_IS_SERVICE_ENABLE"
                ds = cmd.Execute(ExecutionType.ExecuteDataSet)
                If (ds.Tables(0).Rows.Count > 0) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Except = "CheckServiceEnable Method : " & ex.Message
                cmd = Nothing
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
                Except = "GetRidFromCS Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function BlockTrackID(ByVal MerchantId As String, ByVal trackID As String, ByVal status As String)

            Dim cmd As New CommandData(MerchantId)
            'Dim cmd As New CommandData

            Try
                cmd.AddParameter("@MerchantID", MerchantId)
                cmd.AddParameter("@RequestID", trackID)
                cmd.AddParameter("@RequestStatus", status)

                cmd.CmdText = "CAM_UpdateRequestStatus"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception

                Except = "BlockTrackID Method : " & ex.Message & " Connection String " & cmd.ConnectionString
                cmd = Nothing

            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GetRidFromCSFORPro(ByVal ac As String, ByVal CustID As String, ByVal MerchantId As String, ByVal formateddate2 As String, ByVal Amount As Double, ByVal invoiceDetail As String, ByVal Invoice As String, ByVal formateddate1 As String, ByVal invoiceStatus As String, ByVal invoice_no As Integer, ByVal paymentmode As String, ByVal sCompanyName As String, ByVal Rid As String, ByVal del_add As String, ByVal InvoiceStat As String, ByVal Sender As String, ByVal TranMode As String, ByVal GCode As String, ByVal CCode As String, ByVal Symbol As String) As DataSet

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
                cmd.AddParameter("@order_id", 0)
                cmd.AddParameter("@desref", 0)
                cmd.AddParameter("@paymentMode", paymentmode)
                cmd.AddParameter("@sCompanyName", sCompanyName)
                cmd.AddParameter("@sTrackingNo", Rid)
                cmd.AddParameter("@deliveryAddress", del_add)
                cmd.AddParameter("@requestStatus", InvoiceStat)
                cmd.AddParameter("@sender", Sender)
                cmd.AddParameter("@transactionMode", TranMode)
                cmd.AddParameter("@Invoice_no", invoice_no)
                cmd.AddParameter("@Currency_no", GCode)
                cmd.AddParameter("@Currency_Code", CCode)
                cmd.AddParameter("@Currency_symbol", Symbol)

                ' cmd.AddParameter("@MIdentity", MerchantId)

                'cmd.CmdText = "M" & MerchantId & ".dbo.CAM_ADDINVOICE"
                cmd.CmdText = "CAM_ADDINVOICE"
                Return cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "GetRidFromCSFORPro Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try


        End Function

        Public Function GetOrderInfo(ByVal DBName As String, ByVal M_Id As String, ByVal OrderID As String) As DataSet

            Dim cmd As New CommandData(M_Id)
            'Dim cmd As New CommandData

            Try
                cmd.AddParameter("@MIdentity", M_Id)
                'cmd.AddParameter("@CustomerID", M_Id)
                'cmd.AddParameter("@DBName", DBName)
                cmd.AddParameter("@OrderID", OrderID)

                cmd.CmdText = "CXLROBO_GETORDERINFO"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception

                Except = "GetOrderInfo Method : " & ex.Message & " Connection String " & cmd.ConnectionString
                cmd = Nothing

            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GetCorporateOrderInfo(ByVal M_Id As Integer, ByVal OrderID As Integer, ByVal trackID As Integer) As DataSet

            Dim cmd As New CommandData(M_Id)

            Try
                cmd.AddParameter("@MIdentity", M_Id)
                cmd.AddParameter("@Order_ID", OrderID)
                cmd.AddParameter("@trackID", trackID)

                cmd.CmdText = "CXLROBO_GETCORPORATE_REQUEST"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception
                Except = "GetCorporateOrderInfo Method : " & ex.Message & " Connection String " & cmd.ConnectionString
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function GetManualOrderInfo(ByVal DBName As String, ByVal M_Id As String, ByVal OrderID As String) As DataSet

            Dim cmd As New CommandData(M_Id)

            Try
                cmd.AddParameter("@MIdentity", M_Id)
                cmd.AddParameter("@OrderID", OrderID)

                cmd.CmdText = "CXLROBO_GETMANUALORDERINFO"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception

                Except = "GetManualOrderInfo Method : " & ex.Message & " Connection String " & cmd.ConnectionString
                cmd = Nothing

            Finally
                cmd = Nothing
            End Try
        End Function
        '(SZ:RC)
        Public Function UpdateStatusAsDeclinedOnRetry_New(ByVal order_id As Integer, ByVal MerchantId As Integer, ByVal cxlIdentity As Integer, Optional ByVal response_code As String = "0", Optional ByVal csmessage As String = "")
            Dim cmd As New CommandData
            Try
                cmd.AddParameter("@orderbooked", order_id)
                cmd.AddParameter("@mid", MerchantId)
                cmd.AddParameter("@responsecode_cs", response_code)
                cmd.AddParameter("@csmessage", csmessage)
                cmd.AddParameter("@cxlIdentity", cxlIdentity)

                cmd.CmdText = "DBSERVER.CXLTransaction.dbo.CXLROBO_UPDATESTATUSONRETRY"
                cmd.Execute(ExecutionType.ExecuteNonQuery)
            Catch ex As Exception
                Except = "UpdateStatusAsDeclinedOnRetry Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function UpdateStatusAsDeclinedOnRetry(ByVal order_id As Integer, ByVal MerchantId As Integer, ByVal cxlIdentity As Integer, Optional ByVal response_code As String = "0", Optional ByVal csmessage As String = "")
            Dim cmd As New CommandData(-1)
            cmd.CmdText = "SET XACT_ABORT ON"
            cmd.CmdType = CommandType.Text
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            cmd.BeginTransaction(True)

            Try
                cmd.AddParameter("@orderbooked", order_id)
                cmd.AddParameter("@mid", MerchantId)
                cmd.AddParameter("@responsecode_cs", response_code)
                cmd.AddParameter("@csmessage", csmessage)
                cmd.AddParameter("@cxlIdentity", cxlIdentity)

                cmd.CmdText = "CXLROBO_UPDATESTATUSONRETRY"
                cmd.CmdType = CommandType.StoredProcedure
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd.Commit()

            Catch ex As Exception
                cmd.RollBack()
                Except = "UpdateStatusAsDeclinedOnRetry Method : " & ex.Message

            Finally
                cmd.CmdText = "SET XACT_ABORT OFF"
                cmd.CmdType = CommandType.Text
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                cmd = Nothing
            End Try
        End Function
        Public Function GetOrderInfo4_ProInvoice(ByVal DBName As String, ByVal MerchantId As String, ByVal Inv_no As String, ByVal Cid As String) As DataSet

            Dim cmd As New CommandData(MerchantId)
            Try

                'cmd.AddParameter("@DBName", DBName)
                cmd.AddParameter("@Inv_no", Inv_no)
                cmd.AddParameter("@Cust_id", Cid)
                cmd.AddParameter("@MIdentity", MerchantId)

                cmd.CmdText = "CXLROBO_GETINVOICEINFO"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception
                Except = "GetOrderInfo4_ProInvoice Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Function GetLedgerNC(ByVal M_Id As String, ByVal Bank As String) As String

            Dim cmd As New CommandData(M_Id)

            Try
                cmd.AddParameter("@names", Bank)
                '    cmd.CmdText = "M" & M_Id & ".dbo.INFINISHOPS_ISHOPS_GET_LEDGER_NC"
                cmd.CmdText = "INFINISHOPS_ISHOPS_GET_LEDGER_NC"

                Dim D As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Return (D.Tables(0).Rows(0).Item("nc"))

            Catch ex As Exception
                Except = "GetLedgerNC Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Function GetValidTranDrCr(ByVal mid As Integer, ByVal Dbname As String, ByVal Rid As Long) As DataTable
            Dim cmd As New CommandData(mid)
            Try
                'cmd.AddParameter("@DBName", Dbname)
                cmd.AddParameter("@MIdentity", mid)
                cmd.AddParameter("@TrackId", CStr(Rid))

                cmd.CmdText = "CXLROBO_GET_TRANSACTION_CR_DR"
                Dim Ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Return (Ds.Tables(0))

            Catch ex As Exception
                Except = "GetValidTranDrCr Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Function GetDBName(ByVal M_ID As String) As String
            Dim cmd As New CommandData
            Try
                cmd.AddParameter("@MERCHANTID", M_ID)
                cmd.CmdText = "CXLROBO_GETDBNAME"
                Dim Ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Return (Ds.Tables(0).Rows(0).Item("db_name"))

            Catch ex As Exception
                Except = "GetDBName Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try

        End Function


        'Public Function GetCustomerIDFromMerchantDB(ByVal M_ID As String, ByVal C_id As String) As String
        '    Dim Str As String
        '    Dim cmd As New CommandData
        '    Try
        '        cmd.AddParameter("@mid", M_ID)
        '        cmd.AddParameter("@ac", "@" & C_id)
        '        cmd.CmdText = "CXLROBO_GETCUSTIDFORINFINISHOPS"
        '        Dim Ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)

        '        Str = Ds.Tables(0).Rows(0).Item("customer_id")
        '        Return Str

        '    Catch ex As Exception
        '        Except = "GetCustomerIDFromMerchantDB Method : " & ex.Message
        '        cmd = Nothing
        '    Finally
        '        cmd = Nothing
        '    End Try

        ' End Function
        Public Function GetOrderDetail(ByVal Mid As String, ByVal O_id As Integer) As DataSet
            Dim cmd As New CommandData(Mid)

            Try
                cmd.AddParameter("@OrderID", O_id)
                'cmd.CmdText = "M" & Mid & ".dbo.INFINISHOPS_ORDER_GETDETAIL"

                cmd.CmdText = "INFINISHOPS_ORDER_GETDETAIL"
                Return (cmd.Execute(ExecutionType.ExecuteDataSet))

            Catch ex As Exception
                Except = "GetOrderDetail Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function RestrictedOrders(ByVal Mid As Integer, ByVal Product_code As String, ByVal card_no As String) As DataSet

            'Dim cmd As New CommandData(Mid, 1)
            Dim cmd As New CommandData(Mid)

            Try
                cmd.AddParameter("@card_no", card_no)
                cmd.AddParameter("@Product_code", Product_code)
                cmd.AddParameter("@Midentity", Mid)

                cmd.CmdText = "CXLROBO_RESTRICT_ORDER"
                Return cmd.Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                Except = "RestrictedOrder Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Function InsertProInvoice(ByVal Mid As Integer, ByVal o_id As String, ByVal InvNo As String, ByVal Inv_date As DateTime, ByVal Cust_det As String, ByVal Car_tc As String, ByVal Car_TCrate As Double, ByVal Global_Tc As String, ByVal Global_Tcrate As Double, ByVal Bank_acc As String, ByVal carnc As String, ByVal Inv_Type As String, ByVal Car_net As Double, ByVal Car_Vat As Double, ByVal Pay_amt As Double, ByVal ac As String, ByVal Pay_type As String, ByVal PaymentType As String) As String

            Dim cmd As New CommandData(Mid)

            Try
                cmd.AddParameter("@Ord_ID", o_id)
                cmd.AddParameter("@inv_no", CInt(InvNo), ParameterDirection.Output)
                cmd.AddParameter("@inv_date", Inv_date)
                cmd.AddParameter("@Cust_Det", Cust_det)
                cmd.AddParameter("@Car_Tc", Car_tc)
                cmd.AddParameter("@Car_Tcrate", Car_TCrate)
                cmd.AddParameter("@Global_Tc", Global_Tc)
                cmd.AddParameter("@Global_Tcrate", Global_Tcrate)
                cmd.AddParameter("@Bank_Acc", Bank_acc)
                cmd.AddParameter("@carnc", carnc)
                cmd.AddParameter("@Inv_Type", Inv_Type)
                cmd.AddParameter("@Car_net", Car_net)
                cmd.AddParameter("@Car_vat", Car_Vat)
                cmd.AddParameter("@pay_Amt", Pay_amt)
                cmd.AddParameter("@ac", ac)
                cmd.AddParameter("@PayType", Pay_type)
                cmd.AddParameter("@Midentity", Mid) 'Added by Saad on 21/02/08 as per the recomendation of Zahid bhai 
                cmd.AddParameter("@PaymentType", PaymentType)

                If UCase(PaymentType) = "CR" Then
                    cmd.AddParameter("@CorpRequest", "CR")
                End If

                'cmd.CmdText = "M" & Mid & ".dbo.ACCOUNTSPRO_UPDATEPROINVOICE"
                cmd.CmdText = "ACCOUNTSPRO_UPDATEPROINVOICE"
                cmd.Execute(ExecutionType.ExecuteNonQuery)
                Return (cmd.Item("@inv_no"))

            Catch ex As Exception
                Except = "InsertProInvoice Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function
        Public Sub UpdateE_CardInSQLServer_New(ByVal Order As String, ByVal ECard As String, ByVal TimeStamp1 As String, Optional ByVal EIssueNum As String = "", Optional ByVal ESecurityCode As String = "")

            Dim cmd As New CommandData

            Try
                cmd.AddParameter("@Ord_ID", CInt(Order))
                cmd.AddParameter("@ECard", ECard)
                cmd.AddParameter("@TimeStamp1", TimeStamp1)
                cmd.AddParameter("@EIssueNum", EIssueNum)
                cmd.AddParameter("@ESecurityCode", ESecurityCode)

                'cmd.CmdText = "CXLROBO_UPDATE_ENCRPTCARD"
                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_UPDATE_ENCRPTCARD"
                cmd.Execute(ExecutionType.ExecuteNonQuery)
            Catch ex As Exception
                Except = "UpdateE_CardInSQLServer Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Sub UpdateE_CardInSQLServer(ByVal Order As String, ByVal ECard As String, ByVal TimeStamp1 As String, Optional ByVal EIssueNum As String = "", Optional ByVal ESecurityCode As String = "")

            Dim cmd As New CommandData

            Try
                cmd.AddParameter("@Ord_ID", CInt(Order))
                cmd.AddParameter("@ECard", ECard)
                cmd.AddParameter("@TimeStamp1", TimeStamp1)
                cmd.AddParameter("@EIssueNum", EIssueNum)
                cmd.AddParameter("@ESecurityCode", ESecurityCode)

                'cmd.CmdText = "CXLROBO_UPDATE_ENCRPTCARD"
                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_UPDATE_ENCRPTCARD"
                cmd.Execute(ExecutionType.ExecuteNonQuery)
            Catch ex As Exception
                Except = "UpdateE_CardInSQLServer Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Sub

        Public Function GetCurrencySymbol_New(ByVal CCode As String, ByVal GCode As String) As String

            Dim cmd As New CommandData

            Dim Symbol As String
            Try
                cmd.AddParameter("@CurrencyCode", CCode)
                cmd.AddParameter("@GenericCode", GCode)

                cmd.CmdText = "DBSERVER.CXLTRANSACTION.dbo.CXLROBO_FETCHCURRENCYSYMBOL"
                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Symbol = ds.Tables(0).Rows(0).Item("sign")

                Return Symbol

            Catch ex As Exception
                Except = "GetCurrencySymbol Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

        Public Function GetCurrencySymbol(ByVal CCode As String, ByVal GCode As String) As String

            Dim cmd As New CommandData(-1)

            Dim Symbol As String
            Try
                cmd.AddParameter("@CurrencyCode", CCode)
                cmd.AddParameter("@GenericCode", GCode)

                cmd.CmdText = "CXLROBO_FETCHCURRENCYSYMBOL"
                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Symbol = ds.Tables(0).Rows(0).Item("sign")

                Return Symbol

            Catch ex As Exception
                Except = "GetCurrencySymbol Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

        'Created by M. Furqan Khan on 03 FEB 2010
        Public Function GetCallBackInfo(ByVal MIdentity As Int64, ByVal OrderID As Int64, ByRef IsCallBackAllowed As Boolean) As DataSet
            Dim cmd As New CommandData(MIdentity)

            Try
                cmd.CmdText = "CXLROBO_GetCallBackInfo"
                cmd.AddParameter("@MIDENTITY", MIdentity)
                cmd.AddParameter("@ORDERID", OrderID)
                cmd.AddParameter("@ISCALLBACKALLOWED", IsCallBackAllowed, SqlDbType.Bit, 1, ParameterDirection.Output)
                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Dim returnValue As Object = cmd.Item("@ISCALLBACKALLOWED")
                If returnValue Is DBNull.Value Then
                    Throw New Exception("Value for ISCALLBACKALLOWED could not be identified.")
                Else
                    IsCallBackAllowed = returnValue
                    Return ds
                End If
            Catch ex As Exception
                Except = "GetCallBackInfo Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

#End Region

#Region " PAYPAL FUNCTIONS"
        Public Function GetPassword(ByVal Mid As Integer) As String
            Dim cmd As New CommandData

            Try
                cmd.AddParameter("@MerchantID", Mid)

                cmd.CmdText = "PAYPAL_GETINFO"
                Dim ds As DataSet = cmd.Execute(ExecutionType.ExecuteDataSet)
                Return ds.Tables(0).Rows(0).Item("PayPalPassword")


            Catch ex As Exception
                Except = "GetPassword For PAYPAL Method : " & ex.Message
                cmd = Nothing
            Finally
                cmd = Nothing
            End Try
        End Function

#End Region



#Region ".................... MYSQL Functions........................"

        Public Function GetMySqlData(ByVal strQuery As String, ByRef str As String) As DataSet

            Dim conn = New MySqlConnection
            Dim cmd As MySqlCommand
            Dim da As MySqlDataAdapter

            Dim mysqlUserID, mysqlPassword, mysqlDataBase, mysqlServer As String

            '' Following values will come from the component.
            mysqlUserID = ConfigReader.GetItem(ConfigVariables.MySqlUserID) '"mysqlUser"  
            mysqlPassword = ConfigReader.GetItem(ConfigVariables.MYSQLPassword) ' 
            mysqlDataBase = ConfigReader.GetItem(ConfigVariables.MYSQLDB) '"DataBase"
            mysqlServer = ConfigReader.GetItem(ConfigVariables.MYSQLServerIP) 'mysql Server

            Dim ds As New DataSet

            '''' conn.ConnectionString = "server=192.168.1.4;uid=cartuser;pwd=abc123;database=shoppingcart;"
            conn.ConnectionString = "server=" & mysqlServer & ";uid=" & mysqlUserID & ";pwd=" & mysqlPassword & ";database=" & mysqlDataBase
            str = "server=" & mysqlServer & ";uid=" & mysqlUserID & ";pwd=" & mysqlPassword & ";database=" & mysqlDataBase
            Try
                conn.Open()
                cmd = New MySqlCommand(strQuery, conn)
                da = New MySqlDataAdapter(cmd)
                da.Fill(ds)
                conn.close()
                Return ds

            Catch myerror As MySqlException
                Except = "error in mysql connection: GetMySqlData Method : " & myerror.Message
                ' conn.Dispose()
            Finally
                conn.Dispose()
            End Try

        End Function

        Public Function UpdateMySqlData(ByVal strQuery As String)

            Dim conn = New MySqlConnection
            Dim cmd As MySqlCommand
            Dim da As MySqlDataAdapter

            Dim mysqlUserID, mysqlPassword, mysqlDataBase, mysqlServer As String

            '' Following values will come from the component.
            mysqlUserID = ConfigReader.GetItem(ConfigVariables.MySqlUserID) '"mysqlUser"  
            mysqlPassword = ConfigReader.GetItem(ConfigVariables.MYSQLPassword) ' 
            mysqlDataBase = ConfigReader.GetItem(ConfigVariables.MYSQLDB) '"DataBase"
            mysqlServer = ConfigReader.GetItem(ConfigVariables.MYSQLServerIP) 'mysql Server

            ''' conn.ConnectionString = "server=192.168.1.4;uid=cartuser;pwd=abc123;database=shoppingcart;"
            conn.ConnectionString = "server=" & mysqlServer & ";uid=" & mysqlUserID & ";pwd=" & mysqlPassword & ";database=" & mysqlDataBase

            Try
                conn.Open()
                cmd = New MySqlCommand(strQuery, conn)
                cmd.ExecuteNonQuery()
                conn.close()

            Catch myerror As MySqlException
                Except = "UpdateMySqlData Method : " & myerror.Message
                ' conn.Dispose()
            Finally
                conn.Dispose()
            End Try

        End Function

#End Region

       
    End Class
End Namespace