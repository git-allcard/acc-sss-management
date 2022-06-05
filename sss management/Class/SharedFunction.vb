Public Class SharedFunction

    Public Shared Sub PopulateCombobox(ByVal dt As DataTable, ByRef cb As ComboBox)
        cb.Items.Clear()

        cb.DataSource = dt
        cb.DisplayMember = dt.Columns(0).ColumnName
        cb.ValueMember = dt.Columns(0).ColumnName

        If cb.Items.Count > 0 Then cb.SelectedIndex = 0
    End Sub

End Class
