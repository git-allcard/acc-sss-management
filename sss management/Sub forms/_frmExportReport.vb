Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class _frmExportReport
    Dim getFileName As String
    Public int1 As Integer
    Public Sub CheckChange()
        Select Case chkRename.Checked

            Case True
                Try
                    If txtFile.Text = Nothing Then
                        MsgBox("File name is empty.")
                    Else
                        If rbPdf.Checked = False And rbExcel.Checked = False Then
                            MsgBox("Please choose a file format.")
                        Else
                            If rbPdf.Checked = True Then
                                Dim getdate As String = Date.Today.ToShortDateString
                                Dim gettime As String = TimeOfDay
                                getdate = getdate.Replace("/", "-")
                                gettime = gettime.Replace(":", ".")
                                Dim test As New FolderBrowserDialog
                                Dim filepath As String
                                If test.ShowDialog = DialogResult.OK Then

                                    filepath = test.SelectedPath
                                    filepath = filepath & "\"
                                    Try
                                        Dim CrExportOptions As ExportOptions
                                        Dim CrDiskFileDestinationOptions As New _
                                        DiskFileDestinationOptions()
                                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                                        CrDiskFileDestinationOptions.DiskFileName =
                                                                    filepath & getFileName & " " & getdate & " " & gettime & ".pdf"
                                        Select Case int1

                                            Case 0

                                                CrExportOptions = _frmViewReports.cryRpt.ExportOptions
                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.PortableDocFormat
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions
                                                End With
                                                _frmViewReports.cryRpt.Export()
                                                MsgBox("Successfully saved.")

                                            Case 1

                                                CrExportOptions = _frmFBK.cryRpt.ExportOptions
                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.PortableDocFormat
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions
                                                End With
                                                _frmFBK.cryRpt.Export()
                                                MsgBox("Successfully saved.")

                                        End Select
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try

                                End If
                            ElseIf rbExcel.Checked = True Then
                                Dim getdate As String = Date.Today.ToShortDateString
                                Dim gettime As String = TimeOfDay
                                getdate = getdate.Replace("/", "-")
                                gettime = gettime.Replace(":", ".")
                                Dim test As New FolderBrowserDialog
                                Dim filepath As String
                                If test.ShowDialog = DialogResult.OK Then

                                    filepath = test.SelectedPath
                                    filepath = filepath & "\"
                                    Try
                                        Dim CrExportOptions As ExportOptions
                                        Dim CrDiskFileDestinationOptions As New _
                               DiskFileDestinationOptions()
                                        Dim CrFormatTypeOptions As New ExcelFormatOptions
                                        CrFormatTypeOptions.ExcelUseConstantColumnWidth = True
                                        CrFormatTypeOptions.ExcelConstantColumnWidth = 2000
                                        CrFormatTypeOptions.ShowGridLines = True
                                        CrDiskFileDestinationOptions.DiskFileName =
                                                                    filepath & getFileName & " " & getdate & " " & gettime & ".xls"
                                        Select Case int1

                                            Case 0
                                                CrExportOptions = _frmViewReports.cryRpt.ExportOptions
                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.Excel
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions
                                                End With
                                                _frmViewReports.cryRpt.Export()
                                                MsgBox("Successfully saved.")

                                            Case 1
                                                CrExportOptions = _frmFBK.cryRpt.ExportOptions
                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.Excel
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions
                                                End With
                                                _frmFBK.cryRpt.Export()
                                                MsgBox("Successfully saved.")

                                        End Select
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try

                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Case False
                txtFile.Enabled = True
                Try
                    If txtFile.Text = Nothing Then
                        MsgBox("File name is empty.")
                    Else
                        If rbPdf.Checked = False And rbExcel.Checked = False Then
                            MsgBox("Please choose a file format.")
                        Else
                            If rbPdf.Checked = True Then
                                Dim getdate As String = Date.Today.ToShortDateString
                                Dim gettime As String = TimeOfDay
                                getdate = getdate.Replace("/", "-")
                                gettime = gettime.Replace(":", ".")
                                Dim test As New FolderBrowserDialog
                                Dim filepath As String
                                If test.ShowDialog = DialogResult.OK Then

                                    filepath = test.SelectedPath
                                    filepath = filepath & "\"
                                    Try
                                        Dim CrExportOptions As ExportOptions
                                        Dim CrDiskFileDestinationOptions As New _
                                        DiskFileDestinationOptions()
                                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                                        CrDiskFileDestinationOptions.DiskFileName =
                                                                    filepath & txtFile.Text & " " & getdate & " " & gettime & ".pdf"

                                        Select Case int1

                                            Case 0
                                                CrExportOptions = _frmViewReports.cryRpt.ExportOptions


                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.PortableDocFormat
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions

                                                End With
                                                _frmViewReports.cryRpt.Export()
                                                MsgBox("Successfully saved.")

                                            Case 1

                                                CrExportOptions = _frmFBK.cryRpt.ExportOptions


                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.PortableDocFormat
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions

                                                End With
                                                _frmFBK.cryRpt.Export()
                                                MsgBox("Successfully saved.")


                                        End Select
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try

                                End If
                            ElseIf rbExcel.Checked = True Then
                                Dim getdate As String = Date.Today.ToShortDateString
                                Dim gettime As String = TimeOfDay
                                getdate = getdate.Replace("/", "-")
                                gettime = gettime.Replace(":", ".")
                                Dim test As New FolderBrowserDialog
                                Dim filepath As String
                                If test.ShowDialog = DialogResult.OK Then
                                    filepath = test.SelectedPath
                                    filepath = filepath & "\"
                                    Try
                                        Dim CrExportOptions As ExportOptions
                                        Dim CrDiskFileDestinationOptions As New _
                               DiskFileDestinationOptions()
                                        Dim CrFormatTypeOptions As New ExcelFormatOptions
                                        CrFormatTypeOptions.ExcelUseConstantColumnWidth = True
                                        CrFormatTypeOptions.ExcelConstantColumnWidth = 2000
                                        CrFormatTypeOptions.ShowGridLines = True
                                        CrDiskFileDestinationOptions.DiskFileName =
                                                                    filepath & txtFile.Text & " " & getdate & " " & gettime & ".xls"

                                        Select Case int1

                                            Case 0
                                                CrExportOptions = _frmViewReports.cryRpt.ExportOptions

                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.Excel

                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions
                                                End With
                                                _frmViewReports.cryRpt.Export()
                                                MsgBox("Successfully saved.")

                                            Case 1
                                                CrExportOptions = _frmFBK.cryRpt.ExportOptions

                                                With CrExportOptions
                                                    .ExportDestinationType = ExportDestinationType.DiskFile
                                                    .ExportFormatType = ExportFormatType.Excel
                                                    .DestinationOptions = CrDiskFileDestinationOptions
                                                    .FormatOptions = CrFormatTypeOptions
                                                End With
                                                _frmFBK.cryRpt.Export()
                                                MsgBox("Successfully saved.")
                                        End Select
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try

                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select
    End Sub

    Private Function GetFilePath() As String
        Dim filePath As String = ""
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            filePath = fbd.SelectedPath & "\"
        End If
        fbd.Dispose()
        fbd = Nothing

        Return filePath
    End Function

    Public Sub SaveReport(Optional ByVal isPdfFormat As Boolean = True, Optional ByVal filePath As String = "")
        Try
            If txtFile.Text = Nothing Then
                MsgBox("File name is empty.")
            Else

                If isPdfFormat Then
                    Dim getdate As String = Date.Today.ToShortDateString
                    Dim gettime As String = TimeOfDay
                    getdate = getdate.Replace("/", "-")
                    gettime = gettime.Replace(":", ".")
                    'Dim test As New FolderBrowserDialog
                    'Dim filepath As String
                    If filePath <> "" Then
                        Try
                            Dim CrExportOptions As ExportOptions
                            Dim CrDiskFileDestinationOptions As New _
                                        DiskFileDestinationOptions()
                            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                            CrDiskFileDestinationOptions.DiskFileName =
                                                                    filePath & getFileName & " " & getdate & " " & gettime & ".pdf"
                            Select Case int1

                                Case 0

                                    CrExportOptions = _frmViewReports.cryRpt.ExportOptions
                                    With CrExportOptions
                                        .ExportDestinationType = ExportDestinationType.DiskFile
                                        .ExportFormatType = ExportFormatType.PortableDocFormat
                                        .DestinationOptions = CrDiskFileDestinationOptions
                                        .FormatOptions = CrFormatTypeOptions
                                    End With
                                    _frmViewReports.cryRpt.Export()
                                    'MessageBox.Show("Successfully saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Case 1

                                    CrExportOptions = _frmFBK.cryRpt.ExportOptions
                                    With CrExportOptions
                                        .ExportDestinationType = ExportDestinationType.DiskFile
                                        .ExportFormatType = ExportFormatType.PortableDocFormat
                                        .DestinationOptions = CrDiskFileDestinationOptions
                                        .FormatOptions = CrFormatTypeOptions
                                    End With
                                    _frmFBK.cryRpt.Export()
                                    '.Show("Successfully saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End Select
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try

                    End If
                ElseIf Not isPdfFormat Then
                    Dim getdate As String = Date.Today.ToShortDateString
                    Dim gettime As String = TimeOfDay
                    getdate = getdate.Replace("/", "-")
                    gettime = gettime.Replace(":", ".")
                    'Dim test As New FolderBrowserDialog
                    'Dim filepath As String
                    If filePath <> "" Then
                        'filePath = test.SelectedPath
                        'filePath = filePath & "\"
                        Try
                            Dim CrExportOptions As ExportOptions
                            Dim CrDiskFileDestinationOptions As New _
                               DiskFileDestinationOptions()
                            Dim CrFormatTypeOptions As New ExcelFormatOptions
                            CrFormatTypeOptions.ExcelUseConstantColumnWidth = True
                            CrFormatTypeOptions.ExcelConstantColumnWidth = 2000
                            CrFormatTypeOptions.ShowGridLines = True
                            CrDiskFileDestinationOptions.DiskFileName =
                                                                    filePath & getFileName & " " & getdate & " " & gettime & ".xls"
                            Select Case int1

                                Case 0
                                    CrExportOptions = _frmViewReports.cryRpt.ExportOptions
                                    With CrExportOptions
                                        .ExportDestinationType = ExportDestinationType.DiskFile
                                        .ExportFormatType = ExportFormatType.Excel
                                        .DestinationOptions = CrDiskFileDestinationOptions
                                        .FormatOptions = CrFormatTypeOptions
                                    End With
                                    _frmViewReports.cryRpt.Export()
                                   'MessageBox.Show("Successfully saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Case 1
                                    CrExportOptions = _frmFBK.cryRpt.ExportOptions
                                    With CrExportOptions
                                        .ExportDestinationType = ExportDestinationType.DiskFile
                                        .ExportFormatType = ExportFormatType.Excel
                                        .DestinationOptions = CrDiskFileDestinationOptions
                                        .FormatOptions = CrFormatTypeOptions
                                    End With
                                    _frmFBK.cryRpt.Export()
                                    'MessageBox.Show("Successfully saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End Select
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try

                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SavePDFandExcel()
        Dim filePath As String = GetFilePath()
        SaveReport(True, filePath)
        SaveReport(False, filePath)
    End Sub

    Private Sub _frmExportReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        CheckChange()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.dispose
        _frmBlock.Close()
    End Sub

    Private Sub chkRename_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRename.CheckedChanged
        Select Case chkRename.Checked

            Case True
                txtFile.Text = _frmViewReports.GetName
                getFileName = _frmViewReports.GetName
                txtFile.Enabled = False

            Case False
                txtFile.Enabled = True
                txtFile.Text = Nothing
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        chkRename.Checked = True
        SavePDFandExcel()

        Me.Dispose()
        _frmBlock.Close()
    End Sub

End Class