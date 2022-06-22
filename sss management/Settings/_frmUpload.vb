
Imports System.Net
Imports System.IO

Public Class _frmUpload

#Region " Constructors "

    Private up As New UploadFTP
    Private fType As fileType
    Private db As New ConnectionString

#End Region

    Enum fileType
        citizenCharterPdf = 1
        sssVideo
        setExe
        termsAndCondition = 5
        updaterExe = 6
    End Enum

#Region " Buttons, Radiobutons and Tabs "

    Private Sub btnsave1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim repoFolder As String = ""
        Dim fileName As String = ""

        Dim clsDialog As New OpenFileDialog
        clsDialog.Title = "Select File(s)"
        clsDialog.Multiselect = False

        Select Case fType
            Case fileType.citizenCharterPdf
                fileName = "CITIZENS_CHARTER.pdf"
                clsDialog.Filter = "Pdf Files (*.PDF)|*.PDF"
                repoFolder = "Citizen_Charter"
            Case fileType.sssVideo
                fileName = "SSS.mp4"
                clsDialog.Filter = "Mp4 Files (*.MP4)|*.MP4"
                repoFolder = "Video"
            Case fileType.setExe
                fileName = "SSIT_SERVER.exe"
                clsDialog.Filter = "Exe Files (*.EXE)|*.EXE"
                repoFolder = "Application"
            Case fileType.termsAndCondition
                fileName = "terms_and_conditions.txt"
                clsDialog.Filter = "TXT (*.pdf)|*.txt"
                repoFolder = "Terms"
            Case fileType.updaterExe
                fileName = "SSIT_UPDATER.exe"
                clsDialog.Filter = "Exe Files (*.EXE)|*.EXE"
                repoFolder = "Updater"
        End Select

        clsDialog.FileName = fileName

        If clsDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If File.Exists(clsDialog.FileName) Then
                If Path.GetFileName(clsDialog.FileName) = fileName Then
                    _frmBlock.Show()
                    _frmPassword.ShowDialog()
                    If _frmPassword.x = 1 Then
                        Try
                            up.UploadFile(clsDialog.FileName, String.Format("ftp://{0}/{1}/{2}", My.Settings.FTPIPSETTINGS, repoFolder, Path.GetFileName(clsDialog.FileName)), My.Settings.FTPUSERSETTINGS, My.Settings.FTPPASSSETTINGS)
                            _frmPassword.x = 0
                        Catch ex As Exception
                            clsDialog.Dispose()
                            Return
                        End Try

                        If db.checkExistence("Select isnull(tag,0) from SSINFOTERMUPDATE where tag = " & fType) = 0 Then
                            db.ExecuteSQLQuery(String.Format("INSERT INTO SSINFOTERMUPDATE (TAG,DATEUPDATED,TIMEUPDATED) values ({0},GETDATE(),GETDATE())", fType))
                        Else
                            db.ExecuteSQLQuery("UPDATE SSINFOTERMUPDATE set DATEUPDATED = GETDATE(), TIMEUPDATED = GETDATE() where TAG=" & fType)
                        End If
                        MsgBox("File Transfer Complete")
                        Log.SaveLog(Log.logType.setUpdateLog, String.Concat(clsDialog.FileName, " ", Now))
                    End If
                Else
                    MsgBox("Incorrect file.", MsgBoxStyle.Information)
                End If
            End If
        End If

        clsDialog.Dispose()

    End Sub

    Private Sub rbPDF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPDF.CheckedChanged
        fType = fileType.citizenCharterPdf
    End Sub

    Private Sub rbVideo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVideo.CheckedChanged
        fType = fileType.sssVideo
    End Sub

    Private Sub rbEXE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEXE.CheckedChanged
        fType = fileType.setExe
    End Sub

    Private Sub rbTerms_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTerms.CheckedChanged
        fType = fileType.termsAndCondition
    End Sub

    Private Sub rbUpdater_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUpdater.CheckedChanged
        fType = fileType.updaterExe
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        rbEXE.Checked = False
        rbPDF.Checked = False
        rbUpdater.Checked = False
        rbVideo.Checked = False
        rbTerms.Checked = False
    End Sub

#End Region


End Class