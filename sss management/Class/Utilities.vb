Public Class Utilities

    Public Shared MSG_HEADER As String = "SET MANAGEMENT SERVER"

    Public Shared Sub ShowInfoMessageBox(ByVal msg As String)
        MessageBox.Show(msg, MSG_HEADER, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub ShowWarningMessageBox(ByVal msg As String)
        MessageBox.Show(msg, MSG_HEADER, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Shared Sub ShowErrorMessageBox(ByVal msg As String)
        MessageBox.Show(msg, MSG_HEADER, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Function ShowQuestionMessageBox(ByVal msg As String) As DialogResult
        Return MessageBox.Show(msg, MSG_HEADER, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function


End Class
