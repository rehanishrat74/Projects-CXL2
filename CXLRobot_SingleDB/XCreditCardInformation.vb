
Namespace CXL

    Public Class CreditCardInformation

        Private CreditCardNo As String
        Private IssueNumber As String
        Private TransactionAmount As String
        Private GCode As String
        Private MerchantId As String
        Private CID As String
        Private OrderID As String
        Private TransactionType As String
        Private StartDate As String
        Private CardExpiry As String
        Private CardType As String
        Private Mode As String
        Private CXLResponseCode As String
        Private CXLMessage As String
        Private AgentName As String
        Private AgentAcquirer As String
        Private rid As Long
        Private MerchantLoginId As String
        Private CustomerLoginId As String
        Private Sender As String

        ' Private IssueNumber As String
        Private CardNam As String
        Private CardAddres As String

        Private Security_code As String
        Private CCStatus As String
        Private PaymentMode As String

        Private End_date As String
        Private TranStatus As String


#Region "Properties"

        Public Property CreditCard() As String
            Get
                Return CreditCard
            End Get
            Set(ByVal Value As String)
                CreditCard = Value
            End Set
        End Property
        Public Property IssueNum() As String
            Get
                Return IssueNumber
            End Get
            Set(ByVal Value As String)
                IssueNumber = Value
            End Set
        End Property
        Public Property TransacAmount() As String
            Get
                Return TransactionAmount
            End Get
            Set(ByVal Value As String)
                TransactionAmount = Value
            End Set

        End Property
        Public Property GenCode() As String
            Get
                Return GCode
            End Get
            Set(ByVal Value As String)
                GCode = Value
            End Set
        End Property

        Public Property MId() As String
            Get
                Return MerchantId
            End Get
            Set(ByVal Value As String)
                MerchantId = Value
            End Set
        End Property
        Public Property CustID() As String
            Get
                Return CID
            End Get
            Set(ByVal Value As String)
                CID = Value
            End Set
        End Property
        Public Property Order_ID() As String
            Get
                Return OrderID
            End Get
            Set(ByVal Value As String)
                OrderID = Value
            End Set
        End Property
        Public Property TranType() As String
            Get
                Return TransactionType
            End Get
            Set(ByVal Value As String)
                TransactionType = Value
            End Set
        End Property

        Public Property Start_Date() As String
            Get
                Return StartDate
            End Get
            Set(ByVal Value As String)
                StartDate = Value
            End Set
        End Property
        Public Property Card_Expiry() As String
            Get
                Return CardExpiry
            End Get
            Set(ByVal Value As String)
                CardExpiry = Value
            End Set
        End Property

        Public Property Card_Type() As String
            Get
                Return CardType
            End Get
            Set(ByVal Value As String)
                CardType = Value
            End Set
        End Property
        Public Property Modes() As String
            Get
                Return Mode
            End Get
            Set(ByVal Value As String)
                Mode = Value
            End Set
        End Property


        Public Property CXLCode() As String
            Get
                Return CXLResponseCode
            End Get
            Set(ByVal Value As String)
                CXLResponseCode = Value
            End Set
        End Property
        Public Property CXLMsg() As String
            Get
                Return CXLMessage
            End Get
            Set(ByVal Value As String)
                CXLMessage = Value
            End Set
        End Property

        Public Property Agent_Name() As String
            Get
                Return AgentName
            End Get
            Set(ByVal Value As String)
                AgentName = Value
            End Set
        End Property
        Public Property AgentAcq() As String
            Get
                Return AgentAcquirer
            End Get
            Set(ByVal Value As String)
                AgentAcquirer = Value
            End Set
        End Property
        Public Property R_id() As Long
            Get
                Return rid
            End Get
            Set(ByVal Value As Long)
                rid = Value
            End Set
        End Property

        Public Property MLoginId() As Long
            Get
                Return MerchantLoginId
            End Get
            Set(ByVal Value As Long)
                MerchantLoginId = Value
            End Set
        End Property
        Public Property CLoginId() As Long
            Get
                Return CustomerLoginId
            End Get
            Set(ByVal Value As Long)
                CustomerLoginId = Value
            End Set
        End Property
        Public Property Senders() As Long
            Get
                Return Sender
            End Get
            Set(ByVal Value As Long)
                Sender = Value
            End Set
        End Property
        Public Property CardName() As Long
            Get
                Return CardNam
            End Get
            Set(ByVal Value As Long)
                CardName = Value
            End Set
        End Property
        Public Property CardAddress() As Long
            Get
                Return CardAddres
            End Get
            Set(ByVal Value As Long)
                CardAddres = Value
            End Set
        End Property
        Public Property Tran_status() As Long
            Get
                Return TranStatus
            End Get
            Set(ByVal Value As Long)
                TranStatus = Value
            End Set
        End Property


        Public Property EndDate() As Date
            Get
                Return End_date
            End Get
            Set(ByVal Value As Date)
                End_date = Value
            End Set
        End Property

        Public Property SecurityCode() As Long
            Get
                Return Security_code
            End Get
            Set(ByVal Value As Long)
                Security_code = Value
            End Set
        End Property

        Public Property Payment_mode() As Long
            Get
                Return PaymentMode
            End Get
            Set(ByVal Value As Long)
                PaymentMode = Value
            End Set
        End Property

        Public Property CC_Status() As Long
            Get
                Return CCStatus
            End Get
            Set(ByVal Value As Long)
                CCStatus = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
