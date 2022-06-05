
Imports System.Data.SqlClient

Public Class DAL_Mssql
    Implements IDisposable

    Private ConStr As String = "Server='" & My.Settings.db_Server & "';Database='" & My.Settings.db_Name & "';Uid= '" & My.Settings.db_UName & "' ;Pwd= '" & My.Settings.db_Pass & "';"
    'Private ConStr As String = "Server=10.0.202.95;Database=SSIT_SERVER;Uid=sa;Pwd=password2013;"

    Private dtResult As DataTable
    Private objResult As Object
    Private strErrorMessage As String

    Private con As SqlConnection
    Private cmd As SqlCommand
    Private da As SqlDataAdapter

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return strErrorMessage
        End Get
    End Property

    Public ReadOnly Property TableResult() As DataTable
        Get
            Return dtResult
        End Get
    End Property

    Public ReadOnly Property ObjectResult() As Object
        Get
            Return objResult
        End Get
    End Property


    Private Sub OpenConnection()
        con = New SqlConnection(ConStr)
    End Sub

    Private Sub OpenConnection(ByVal strConStr As String)
        con = New SqlConnection(strConStr)
    End Sub

    Private Sub CloseConnection()
        If Not cmd Is Nothing Then cmd.Dispose()
        If Not da Is Nothing Then da.Dispose()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub ExecuteNonQuery(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ExecuteScalar(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        con.Open()
        Dim _obj As Object
        _obj = cmd.ExecuteScalar()
        con.Close()

        objResult = _obj
    End Sub

    Private Sub FillDataAdapter(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType
        da = New SqlDataAdapter(cmd)
        Dim _dt As New DataTable
        da.Fill(_dt)
        dtResult = _dt
    End Sub

    Public Function IsConnectionOK(Optional ByVal strConString As String = "") As Boolean
        Try
            If strConString <> "" Then
                OpenConnection(strConString)
            Else
                OpenConnection()
            End If

            con.Open()
            con.Close()

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function IsConnectionOKv2(Optional ByVal strConString As String = "") As Boolean
        If strConString <> "" Then
            OpenConnection(strConString)
        Else
            OpenConnection()
        End If

        Dim task = System.Threading.Tasks.Task.Factory.StartNew(Function()

                                                                    Try
                                                                        con.Open()
                                                                        con.Close()
                                                                        Return True
                                                                    Catch
                                                                        Return False
                                                                    End Try
                                                                End Function)

        If Not (task.Wait(5 * 1000) AndAlso task.Result) Then
            'Throw New Exception("No response")
            strErrorMessage = "Connection timeout"
            Return False
        End If

        Return True
    End Function

    Public Function ExecuteQuery(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(strQuery, con)

            ExecuteNonQuery(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function Add_mgmt_errorlogs(ByVal ip As String, ByVal id As String, ByVal name As String, ByVal branch As String, ByVal errDesc As String,
                                 ByVal moduleDesc As String, ByVal affectedTable As String) As Boolean
        Try
            OpenConnection()
            If errDesc.Length > 1000 Then errDesc = errDesc.Substring(0, 1000)

            cmd = New SqlCommand("INSERT INTO tbl_mgmt_errorlogs (ipaddress, mgmtserverID, mgmtServername, mgmtserverbranch, errorlogs, module, affected_table, datelog, timelog) VALUES (@ipaddress, @mgmtserverID, @mgmtServername, @mgmtserverbranch, @errorlogs, @module, @affected_table, GETDATE(), GETDATE())", con)
            cmd.Parameters.AddWithValue("@ipaddress", ip)
            cmd.Parameters.AddWithValue("@mgmtserverID", id)
            cmd.Parameters.AddWithValue("@mgmtServername", name)
            cmd.Parameters.AddWithValue("@mgmtserverbranch", branch)
            cmd.Parameters.AddWithValue("@errorlogs", errDesc)
            cmd.Parameters.AddWithValue("@module", moduleDesc)
            cmd.Parameters.AddWithValue("@affected_table", affectedTable)

            ExecuteNonQuery(CommandType.Text)
            'MessageBox.Show(cmd.CommandText)
            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            'MessageBox.Show(ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function ExecuteQuery_Scalar(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(strQuery, con)

            cmd.CommandTimeout = 0
            ExecuteScalar(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function SelectQuery(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(strQuery, con)

            cmd.CommandTimeout = 0
            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            cmd = Nothing
            da = Nothing
            con = Nothing

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
