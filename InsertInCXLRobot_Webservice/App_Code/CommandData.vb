Option Strict On
Option Explicit On 

#Region "IMPORTS LIBARAY"

Imports System.Data
Imports System.Data.SqlClient

#End Region

Public Class CommandData

    '    Dim Except As String

    '#Region "...................Properties..................."

    '    Public Property GetExcept() As String
    '        Get
    '            Return Except
    '        End Get
    '        Set(ByVal Value As String)
    '            '    MID = Value
    '        End Set
    '    End Property

    '#End Region


#Region " Protected Variables "

    Protected _blnIsNotTransaction As Boolean = True
    Protected _cmd As SqlCommand
    Protected _conn As SqlConnection
    Protected _strConnStr As String
    Protected _cmdText As String
    Protected _cmdType As CommandType = CommandType.StoredProcedure
    Protected _sqlTransaction As SqlTransaction
    Protected _blnIsConnectionClosed As Boolean
    Protected _blnIsDistributedTransaction As Boolean
    Protected _intTimeout As Integer = 30

#End Region

#Region " Constructors() "
    Public Sub New(Optional ByVal CustomerID As Integer = 0, Optional ByVal connType As Integer = 0)
        _cmd = New SqlCommand

        If CustomerID = 0 Then
            _strConnStr = Connection.GetConnectionString()   'Prepare connection with DBGATEWAY SERVER6

        ElseIf CustomerID = -1 Then
            _strConnStr = Connection.GetConnectionString(CustomerID, -1) 'Prepare connection with CXL Server

        Else
            _strConnStr = Connection.GetConnectionString(CustomerID, connType) 'If conntype=0 then Connection to particular DB 

        End If
    End Sub
    'Public Sub New(ByVal ServerName As String, Optional ByVal CustomerID As Integer = 0)
    '    _cmd = New SqlCommand
    '    If CustomerID = 0 Then                              'for particular DB
    '        _strConnStr = Connection.GetConnectionString()

    '    Else
    '        _strConnStr = Connection.GetConnectionString(ServerName, CustomerID)
    '    End If
    'End Sub


#End Region


#Region " Public Function "
    ''' function should be used for Input Parameters only
    Public Sub AddParameter(ByVal name As String, ByVal value As Object, Optional ByVal direction As Data.ParameterDirection = ParameterDirection.Input)
        Dim _sqlParameter As New SqlParameter(name, value)

        _sqlParameter.Direction = direction

        _cmd.Parameters.Add(_sqlParameter)

    End Sub

    ''' Function should be used for Output and InputOutput Parameters
    Public Sub AddParameter(ByVal name As String, ByVal value As Object, ByVal ParamType As SqlDbType, ByVal size As Integer, Optional ByVal direction As ParameterDirection = ParameterDirection.Input)
        Dim _sqlParameter As New SqlParameter(name, ParamType)
        With _sqlParameter
            .Size = size
            .Direction = direction
            .Value = value
        End With
        _cmd.Parameters.Add(_sqlParameter)
    End Sub

    Public Sub ClearParameters()
        _cmd.Parameters.Clear()
    End Sub

    Private Sub SetConnection()

        Try


            _conn = New SqlConnection(_strConnStr & ";Connect Timeout=" & _intTimeout)
            _conn.Open()
            _cmd.Connection = _conn
            _blnIsConnectionClosed = False
            ' Catch ex As SqlException

            '  Except = ex.Message

        Catch e As Exception

            '  Except = e.Message

        End Try
    End Sub

    Protected Sub SetParameters()

        With _cmd
            .CommandText = _cmdText
            .CommandType = _cmdType
        End With
    End Sub

#Region " Execute() "

    Public Function Execute(ByVal Exectype As ExecutionType) As Object
        With _cmd
            SetParameters()
            If _blnIsNotTransaction OrElse _blnIsConnectionClosed Then SetConnection()

            Select Case Exectype
                Case ExecutionType.ExecuteReader
                    If _blnIsNotTransaction Then
                        Return .ExecuteReader(CommandBehavior.CloseConnection)
                    Else
                        Return .ExecuteReader()
                    End If
                Case ExecutionType.ExecuteNonQuery
                    Return .ExecuteNonQuery()
                Case ExecutionType.ExecuteDataSet
                    Try
                        Dim ds As New DataSet
                        Dim da As SqlDataAdapter
                        da = New SqlDataAdapter(_cmd)
                        da.Fill(ds)
                        Return ds
                    Catch E As Exception
                        Throw E
                    Finally
                        If _blnIsNotTransaction Then _conn.Dispose()
                    End Try

                Case ExecutionType.ExecuteScalar
                    Return .ExecuteScalar()
            End Select
        End With

    End Function

#End Region

#Region " Transaction Functions "

    Public Sub BeginTransaction(ByVal strTransactionName As String, Optional ByVal IsDistributedTransaction As Boolean = False, Optional ByVal IsoLevel As IsolationLevel = IsolationLevel.ReadCommitted)
        SetConnection()
        CheckDisTributedTransaction(IsDistributedTransaction)
        _sqlTransaction = _conn.BeginTransaction(strTransactionName)
        _cmd.Transaction = _sqlTransaction
        _blnIsNotTransaction = False
    End Sub


    Public Sub BeginTransaction(Optional ByVal IsDistributedTransaction As Boolean = False, Optional ByVal IsoLevel As IsolationLevel = IsolationLevel.ReadCommitted)
        SetConnection()
        CheckDisTributedTransaction(IsDistributedTransaction)
        _sqlTransaction = _conn.BeginTransaction(IsoLevel)
        _cmd.Transaction = _sqlTransaction
        _blnIsNotTransaction = False
    End Sub

    Public Sub Commit()
        ReCheckDistributedTransaction()
        _sqlTransaction.Commit()
        CloseConnection()
        _blnIsNotTransaction = True
    End Sub

    Public Sub Save(ByVal strTransactionName As String)
        _sqlTransaction.Save(strTransactionName)

    End Sub

    Public Sub RollBack(Optional ByVal strTransactionName As String = "")
        ReCheckDistributedTransaction()
        If strTransactionName <> "" Then
            _sqlTransaction.Rollback(strTransactionName)
        Else
            _sqlTransaction.Rollback()
        End If
        CloseConnection()
        _blnIsNotTransaction = True
    End Sub

    Public Sub CloseConnection()
        If _conn.State <> ConnectionState.Closed Then
            _blnIsDistributedTransaction = False
            _conn.Close()
            _blnIsConnectionClosed = True
        End If
    End Sub

    Protected Sub CheckDisTributedTransaction(ByVal IsDistributedTransaction As Boolean)
        If IsDistributedTransaction Then
            _blnIsDistributedTransaction = IsDistributedTransaction
            With _cmd
                .CommandText = "set XACT_ABORT on"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        End If
    End Sub

    Protected Sub ReCheckDistributedTransaction()
        _blnIsDistributedTransaction = False
    End Sub

#End Region

#End Region

#Region " Public Properties "


    Public ReadOnly Property Item(ByVal name As String) As Object
        Get
            Return _cmd.Parameters.Item(name).Value
        End Get
    End Property

    Public WriteOnly Property CmdText() As String
        Set(ByVal Value As String)
            _cmdText = Value
        End Set
    End Property

    Public WriteOnly Property CmdType() As CommandType

        Set(ByVal Value As CommandType)
            _cmdType = Value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return _strConnStr
        End Get
        Set(ByVal Value As String)
            _strConnStr = Value
        End Set
    End Property

    Public ReadOnly Property _Connection() As SqlConnection
        Get
            Return _conn
        End Get

    End Property

    Public Property _Transaction() As SqlTransaction
        Get
            Return _sqlTransaction
        End Get
        Set(ByVal Value As SqlTransaction)
            _sqlTransaction = Value
        End Set
    End Property
    Public Property ConnectionTimeOut() As Integer
        Get
            Return _intTimeout
        End Get
        Set(ByVal Value As Integer)
            _intTimeout = Value
        End Set
    End Property

#End Region

End Class

Public Enum ExecutionType
    ExecuteReader
    ExecuteNonQuery
    ExecuteDataSet
    ExecuteScalar
End Enum
