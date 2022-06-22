
Imports System.Net
Public Class _frmFTP

#Region " Constructors "

    Dim db As New ConnectionString
    Dim isConnected As Boolean

#End Region

    Private Sub _frmFTP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateFTPConnections()
    End Sub


#Region " Buttons, Dropdowns and Checkboxes "

    Private Sub btnNewSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSettings.Click
        ResetForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        _frmBlock.Show()
        _frmPassword.ShowDialog()
        If _frmPassword.x = 1 Then

            If db.checkExistence("Select NAME from SSINFOTERMFTP where Name = '" & cbSettings.Text & "'") = True Then
                If MsgBox("Do you want to Update '" & cbSettings.Text & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    db.ExecuteSQLQuery(String.Format("UPDATE SSINFOTERMFTP SET FTPIP = '{0}', FTPUSER = '{1}', FTPPASS = '{2}', FTPTIME = '{3}' where NAME = '{4}'", FTPIP.Text, FTPUN.Text, FTPPASS.Text, cbFtime.Text, cbSettings.Text))
                    My.Settings.FTPIPSETTINGS = FTPIP.Text
                    My.Settings.FTPUSERSETTINGS = FTPUN.Text
                    My.Settings.FTPPASSSETTINGS = FTPPASS.Text

                    My.Settings.Save()
                    My.Settings.Reload()

                    MsgBox("Successfully saved.", MsgBoxStyle.Information)
                End If
            Else
                db.ExecuteSQLQuery(String.Format("INSERT INTO SSINFOTERMFTP (NAME,FTPUSER,FTPPASS,FTPIP,FTPTIME) values ('{0}','{1}','{2}','{3}','{4}')", txtFTPName.Text, FTPUN.Text, FTPPASS.Text, FTPIP.Text, cbFtime.Text))
                My.Settings.FTPIPSETTINGS = FTPIP.Text
                My.Settings.FTPUSERSETTINGS = FTPUN.Text
                My.Settings.FTPPASSSETTINGS = FTPPASS.Text

                My.Settings.Save()
                My.Settings.Reload()
                MsgBox("New settings has been saved.", MsgBoxStyle.Information)
                PopulateFTPConnections()
            End If
        End If

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            If cbSettings.Text = Nothing Then
                MsgBox("Please Choose settings you want to remove.", MsgBoxStyle.Information, MsgBoxStyle.Information)
            Else
                _frmBlock.Show()
                _frmPassword.ShowDialog()
                If _frmPassword.x = 1 Then
                    If MsgBox("Are you sure you want to remove " & cbSettings.Text & "?", MsgBoxStyle.Information, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        db.ExecuteSQLQuery("Delete From SSINFOTERMFTP where Name = '" & cbSettings.Text & "'")
                        PopulateFTPConnections()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        If FTPIP.Text = "" Then
            MsgBox("FTP IP address is empty.", MsgBoxStyle.Information)
        ElseIf FTPPASS.Text = "" Then
            MsgBox("FTP Password is empty.", MsgBoxStyle.Information)
        ElseIf FTPUN.Text = "" Then
            MsgBox("FTP Username is empty. ", MsgBoxStyle.Information)
        Else
            checkCredentials()
            If isConnected = True Then
                btnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub cbSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSettings.SelectedIndexChanged
        cbFtime.Text = Nothing
        Try
            Dim dt As DataTable = db.getDataTable("Select * from SSINFOTERMFTP where NAME = '" & cbSettings.Text & "'", "")
            If Not dt Is Nothing Then
                FTPUN.Text = dt.Rows(0)("FTPUSER")
                FTPPASS.Text = dt.Rows(0)("FTPPASS")
                FTPIP.Text = dt.Rows(0)("FTPIP")
                cbFtime.Text = dt.Rows(0)("FTPTIME")
                txtFTPName.Text = dt.Rows(0)("NAME")
            Else
                FTPUN.Text = ""
                FTPPASS.Text = ""
                FTPIP.Text = ""
                cbFtime.Text = ""
                txtFTPName.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbPDF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbFtime.Enabled = True
        cbFtime.Text = Nothing
    End Sub

    Private Sub rbOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbFtime.Enabled = False
        cbFtime.Text = Nothing
    End Sub

#End Region

    Private Sub ResetForm()
        cbSettings.Text = ""
        FTPUN.Clear()
        FTPPASS.Clear()
        FTPIP.Clear()
        cbFtime.Text = ""
        txtFTPName.Clear()
    End Sub

    Private Sub PopulateFTPConnections()
        db.fillComboBox(db.ExecuteSQLQuery("SELECT NAME FROM SSINFOTERMFTP"), cbSettings)
    End Sub

    Private Function checkCredentials()
        Try
            Dim request = DirectCast(WebRequest.Create("ftp://" + FTPIP.Text + "/"), FtpWebRequest)

            request.Credentials =
            New NetworkCredential(FTPUN.Text, FTPPASS.Text)
            request.Method = WebRequestMethods.Ftp.ListDirectory

            Dim response As FtpWebResponse =
            DirectCast(request.GetResponse(), FtpWebResponse)
            ' Folder exists here

            ' If response.StatusCode = FtpStatusCode.OpeningData Then
            MsgBox("Connected to FTP Server.", vbInformation, "Information")
            isConnected = True
            '  End If

        Catch ex As WebException
            Dim response As FtpWebResponse =
            DirectCast(ex.Response, FtpWebResponse)
            'Does not exist
            If response.StatusCode =
            FtpStatusCode.ActionNotTakenFileUnavailable Then
                MsgBox("Unable to connect. Please check your parameters.", vbInformation, "Information")
            ElseIf response.StatusCode = FtpStatusCode.ServiceTemporarilyNotAvailable Then
                MsgBox("Can't connect to FTP server.", vbInformation, "Information")
            ElseIf response.StatusCode = FtpStatusCode.SendPasswordCommand Then
                MsgBox("Incorrect password.", vbInformation, "Information")
            ElseIf response.StatusCode = FtpStatusCode.NotLoggedIn Then
                MsgBox("Unable to connect. Please check your parameters.", vbInformation, "Information")
            ElseIf response.StatusCode = FtpStatusCode.ServiceNotAvailable Then
                MsgBox("Can't connect to FTP server.", vbInformation, "Information")
            Else
                MsgBox("Invalid permission.", vbInformation, "Information")
                ' MsgBox(ex.ToString, vbInformation, "Information")

            End If
            isConnected = False

        End Try

        Return isConnected

    End Function

End Class