#Region " Import Libraries "
Imports System
Imports System.Collections.Specialized
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports InfiniLogic.AccountsCentre.common
Imports System.Data
Imports System.Data.SqlClient

#End Region

Public Class Connection

#Region " Declarations"
    Public Const DEFAULT_DATABASE As String = "DBGateWay"
    Private Shared _strDatabaseName As String
    Private Shared _strServerName As String
    Private Shared _blnIsEncrypted As Boolean
    Private _isAdministrator As Boolean
    Private _sqlUserID As String
    Private _sqlPassword As String
    Private _sqlDataSource As String
    Private _sqlInitialCatalog As String

#End Region

    Private Sub New()
    End Sub ' New

#Region " Class Properties"
    Public Enum DBUsers
        DBAdmin = 0
        SQLUser = 1
    End Enum

    Public Shared Property DatabaseName() As String
        Get
            Return _strDatabaseName
        End Get
        Set(ByVal Value As String)
            _strDatabaseName = Value
        End Set
    End Property 'DatabaseName

   
#End Region

#Region " Class Functions/Methods"

    '*******************************************************************
    'Synopsis   :  Provides the connection string of the default database i.e. "DBGateway".
    'Inputs       :  None
    'Assume     :  Database name has given. If it is not given then get the 
    '                   Default_Database constant value.
    'Returns    :   Complete connection string. 
    '*******************************************************************
    Public Overloads Shared Function GetConnectionString() As String
        GetConnectionString = PrepareConnectionString(DEFAULT_DATABASE)
    End Function

    Public Overloads Shared Function GetConnectionString(ByVal dataBaseName As String) As String
        ' Synopsis: Get the complete connection string of the provided database name
        GetConnectionString = PrepareConnectionString(dataBaseName)
    End Function

    Public Overloads Shared Function GetConnectionString(ByVal employerID As Int32, Optional ByVal ConnType As Integer = 0) As String
        If (ConnType = 0) Then
            GetConnectionString = PrepareConnectionString(GetServerName(employerID), GetDataBaseName(employerID)) ' connect to particular server with particular DB
        ElseIf (ConnType = 1) Then
            GetConnectionString = PrepareConnectionString(GetServerName(employerID), DEFAULT_DATABASE) 'connect to particular server with DBGATEWAY of that server
        ElseIf (ConnType = -1) Then
            GetConnectionString = PrepareConnectionStringForCXLT("win-saad", "CXLTransaction") 'connect to particular server with DBGATEWAY of that server
        End If
    End Function


    Private Shared Function GetServerName(ByVal customerid As Integer) As String
        Try


            Dim ConnectionString As String = PrepareConnectionString(DEFAULT_DATABASE)

            Dim _conn As New SqlConnection(ConnectionString & ";Connect Timeout=" & 60) 'Old value 30
            Dim _cmd As New SqlCommand
            _conn.Open()
            _cmd.Connection = _conn
            _cmd.CommandText = "CXLROBO_GETDBNAME"
            _cmd.CommandType = CommandType.StoredProcedure

            Dim _sqlParameter As New SqlParameter("@MERCHANTID", customerid)
            _cmd.Parameters.Add(_sqlParameter)
            Dim ds As New DataSet
            Dim da As SqlDataAdapter
            da = New SqlDataAdapter(_cmd)
            da.Fill(ds)

            Dim Servername As String = ds.Tables(0).Rows(0).Item("server_name")

            Return Servername

        Catch ex As Exception

        End Try

    End Function
    Public Overloads Shared Function GetConnectionString(ByVal isAdministrator As Boolean) As String
        If isAdministrator = True Then

            'GetConnectionString = "User ID =" & GetAdminUserID() & ";Password=" & GetAdminPassword() & ";Data Source=DataCentre;Initial Catalog=DBGateway"
            'GetConnectionString = "User ID =dbadmin;Password=jb7T9fLS;Data Source=DataCentre;Initial Catalog=DBGateway"
            GetConnectionString = "User ID =" & ConfigReader.GetItem(ConfigVariables.SQLAdminID) & ";Password=" & ConfigReader.GetItem(ConfigVariables.SQLAdminPassword) & ";Data Source=" & ConfigReader.GetItem(ConfigVariables.DataSource) & ";Initial Catalog=" & ConfigReader.GetItem(ConfigVariables.InitialCatalog)
        End If

    End Function

    Private Overloads Shared Function GetDataBaseName(ByVal employerID As String) As String
        ' Get the default conneciton string
        '  SqlHelper.ConnectionString = GetConnectionString()
        '  GetDataBaseName = SqlHelper.ExecuteScalar("PAY_GetEmployerDBName", employerID)
        'GetDataBaseName = "Payroll"

        ''''  GetDataBaseName = "M" & employerID


        Try


            Dim ConnectionString As String = PrepareConnectionString(DEFAULT_DATABASE)

            Dim _conn As New SqlConnection(ConnectionString & ";Connect Timeout=" & 30)
            Dim _cmd As New SqlCommand
            _conn.Open()
            _cmd.Connection = _conn
            _cmd.CommandText = "CXLROBO_GETDBNAME"
            _cmd.CommandType = CommandType.StoredProcedure

            Dim _sqlParameter As New SqlParameter("@MERCHANTID", employerID)
            _cmd.Parameters.Add(_sqlParameter)
            Dim ds As New DataSet
            Dim da As SqlDataAdapter
            da = New SqlDataAdapter(_cmd)
            da.Fill(ds)

            Dim Dbname As String = ds.Tables(0).Rows(0).Item("db_name")

            Return Dbname

        Catch ex As Exception

        End Try
    End Function
    '____________________________________________________________________________

    Private Shared Function PrepareConnectionString(ByVal dataBaseName As String) As String
        '   Dim _ReadXML As New pwdsqlsrvdotnet.clspassword
        ' Synopsis: Call the 3rd party COM component ("pwdSqlSrv.clsPassword"), which provides the user id, password, server name/ip 
        '                 of the SQL Server and attached them with provided dataBase name.         '
        ' Input:       Data base name string        '
        ' Return:     connectionString as string

        Try


            Dim sqlUserID, sqlPassword, sqlDataSource As String

            ' Following values will come from the component.
            sqlUserID = ConfigReader.GetItem(ConfigVariables.SQLUserID) '"sqlUser"  'GetSQLUserID()
            sqlPassword = ConfigReader.GetItem(ConfigVariables.SQLPassword) '"D8kjhy"  'GetSQLPassword()
            sqlDataSource = ConfigReader.GetItem(ConfigVariables.DataSource) '"DataCentre"

            'Prepare all values and return
            PrepareConnectionString = "User ID=" & sqlUserID & ";Password=" & sqlPassword & ";Data Source=" & sqlDataSource & ";Initial Catalog=" & dataBaseName
            'User ID=sqluser;Password=D3sxx;Data Source=192.168.199.2
            'Configuration.ConfigurationSettings.AppSettings("DBGatweyCnnString")
        Catch ex As Exception


        End Try
    End Function

    Private Shared Function PrepareConnectionString(ByVal servername As String, ByVal dataBaseName As String) As String
        '   Dim _ReadXML As New pwdsqlsrvdotnet.clspassword
        ' Synopsis: Call the 3rd party COM component ("pwdSqlSrv.clsPassword"), which provides the user id, password, server name/ip 
        '                 of the SQL Server and attached them with provided dataBase name.         '
        ' Input:       Data base name string        '
        ' Return:     connectionString as string

        Dim sqlUserID, sqlPassword, sqlDataSource As String

        ' Following values will come from the component.
        sqlUserID = ConfigReader.GetItem(ConfigVariables.SQLUserID) '"sqlUser"  'GetSQLUserID()
        sqlPassword = ConfigReader.GetItem(ConfigVariables.SQLPassword) '"D8kjhy"  'GetSQLPassword()
        sqlDataSource = servername

        'Prepare all values and return
        PrepareConnectionString = "User ID=" & sqlUserID & ";Password=" & sqlPassword & ";Data Source=" & sqlDataSource & ";Initial Catalog=" & dataBaseName      
    End Function

    Private Shared Function PrepareConnectionStringForCXLT(ByVal servername As String, ByVal dataBaseName As String) As String

        Dim sqlUserID, sqlPassword, sqlDataSource As String

        ' Following values will come from the component.
        sqlUserID = "cxluser" '"sqlUser"  'GetSQLUserID()
        sqlPassword = "D8kjhy" '"D8kjhy"  'GetSQLPassword()
        sqlDataSource = servername

        'Prepare all values and return
        PrepareConnectionStringForCXLT = "User ID=" & sqlUserID & ";Password=" & sqlPassword & ";Data Source=" & sqlDataSource & ";Initial Catalog=" & dataBaseName

    End Function
#End Region

End Class

#Region " Class Decrypt "
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Class Decrypt

#Region " Shared Variables "

    Private Shared Key As Byte() = New Byte(15) {226, 252, 113, 76, 71, 39, 238, 147, 149, 243, 36, 205, 46, 127, 51, 31}
    Private Shared IV As Byte() = New Byte(7) {240, 3, 45, 219, 0, 176, 173, 59}

#End Region

    Public Shared Function decrypt(ByVal strEncryptedString As String) As String
        Try
            ' SetParameters()
            Dim buffer As Byte() = Convert.FromBase64String(strEncryptedString)
            Dim objDES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
            objDES.Key = md5.ComputeHash(Key)
            objDES.IV = IV
            Return Encoding.ASCII.GetString(objDES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch e As CryptographicException
            Throw New InvalidDataException
        Catch fe As FormatException
            Throw New InvalidDataException

        End Try

    End Function

End Class

#End Region

#Region " Class InvalidDataException "

Class InvalidDataException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

End Class

#End Region
