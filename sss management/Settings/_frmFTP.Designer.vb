<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _frmFTP
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtFTPName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNewSettings = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cbSettings = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbFtime = New System.Windows.Forms.ComboBox()
        Me.FTP = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.label222 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.FTPPASS = New System.Windows.Forms.TextBox()
        Me.FTPUN = New System.Windows.Forms.TextBox()
        Me.FTPIP = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(858, 653)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.btnTest)
        Me.Panel5.Controls.Add(Me.txtFTPName)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.btnNewSettings)
        Me.Panel5.Controls.Add(Me.btnRemove)
        Me.Panel5.Controls.Add(Me.cbSettings)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Label26)
        Me.Panel5.Controls.Add(Me.Label25)
        Me.Panel5.Controls.Add(Me.cbFtime)
        Me.Panel5.Controls.Add(Me.FTP)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.label222)
        Me.Panel5.Controls.Add(Me.btnSave)
        Me.Panel5.Controls.Add(Me.FTPPASS)
        Me.Panel5.Controls.Add(Me.FTPUN)
        Me.Panel5.Controls.Add(Me.FTPIP)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(858, 653)
        Me.Panel5.TabIndex = 32
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnTest.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTest.Location = New System.Drawing.Point(184, 529)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(241, 92)
        Me.btnTest.TabIndex = 35
        Me.btnTest.Text = "Test connection"
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'txtFTPName
        '
        Me.txtFTPName.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFTPName.Location = New System.Drawing.Point(245, 213)
        Me.txtFTPName.Name = "txtFTPName"
        Me.txtFTPName.Size = New System.Drawing.Size(455, 35)
        Me.txtFTPName.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(155, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 30)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "NAME :"
        '
        'btnNewSettings
        '
        Me.btnNewSettings.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNewSettings.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewSettings.Location = New System.Drawing.Point(305, 431)
        Me.btnNewSettings.Name = "btnNewSettings"
        Me.btnNewSettings.Size = New System.Drawing.Size(241, 92)
        Me.btnNewSettings.TabIndex = 32
        Me.btnNewSettings.Text = "New Settings"
        Me.btnNewSettings.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRemove.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(646, 157)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(184, 50)
        Me.btnRemove.TabIndex = 29
        Me.btnRemove.Text = "Remove Settings"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'cbSettings
        '
        Me.cbSettings.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSettings.FormattingEnabled = True
        Me.cbSettings.Location = New System.Drawing.Point(243, 166)
        Me.cbSettings.Name = "cbSettings"
        Me.cbSettings.Size = New System.Drawing.Size(397, 38)
        Me.cbSettings.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 30)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "NAME SETTINGS :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(56, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(710, 42)
        Me.Label26.TabIndex = 18
        Me.Label26.Text = "FTP FILE TRANSFER CONFIGURATION"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(34, 390)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(208, 30)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "TIME TO TRANSFER :"
        '
        'cbFtime
        '
        Me.cbFtime.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbFtime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbFtime.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFtime.ForeColor = System.Drawing.SystemColors.InfoText
        Me.cbFtime.FormattingEnabled = True
        Me.cbFtime.Items.AddRange(New Object() {"1:00:00 AM", "1:30:00 AM", "2:00:00 AM", "2:30:00 AM", "3:00:00 AM", "3:30:00 AM", "4:00:00 AM", "4:30:00 AM", "5:00:00 AM", "5:30:00 AM", "6:00:00 AM", "6:30:00 AM", "7:00:00 AM", "7:30:00 AM", "8:00:00 AM", "8:30:00 AM", "9:00:00 AM", "9:30:00 AM", "10:00:00 AM", "10:30:00 AM", "11:00:00 AM", "11:30:00 AM", "12:00:00 AM", "12:30:00 AM", "1:00:00 PM", "1:30:00 PM", "2:00:00 PM", "2:30:00 PM", "3:00:00 PM", "3:30:00 PM", "4:00:00 AM", "4:30:00 PM", "5:00:00 PM", "5:30:00 PM", "6:00:00 PM", "6:30:00 PM", "7:00:00 PM", "7:30:00 PM", "8:00:00 PM", "8:30:00 PM", "9:00:00 PM", "9:30:00 PM", "10:00:00 PM", "10:30:00 PM", "11:00:00 PM", "11:30:00 PM", "12:00:00 PM", "12:30:00 PM"})
        Me.cbFtime.Location = New System.Drawing.Point(245, 387)
        Me.cbFtime.Name = "cbFtime"
        Me.cbFtime.Size = New System.Drawing.Size(180, 38)
        Me.cbFtime.TabIndex = 24
        '
        'FTP
        '
        Me.FTP.AutoSize = True
        Me.FTP.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FTP.Location = New System.Drawing.Point(66, 342)
        Me.FTP.Name = "FTP"
        Me.FTP.Size = New System.Drawing.Size(177, 30)
        Me.FTP.TabIndex = 23
        Me.FTP.Text = "FTP IP ADDRESS :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(102, 260)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(139, 30)
        Me.Label24.TabIndex = 18
        Me.Label24.Text = "USER NAME :"
        '
        'label222
        '
        Me.label222.AutoSize = True
        Me.label222.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label222.Location = New System.Drawing.Point(106, 301)
        Me.label222.Name = "label222"
        Me.label222.Size = New System.Drawing.Size(135, 30)
        Me.label222.TabIndex = 18
        Me.label222.Text = "PASSWORD :"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(431, 529)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(241, 92)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save Settings"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'FTPPASS
        '
        Me.FTPPASS.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FTPPASS.Location = New System.Drawing.Point(245, 298)
        Me.FTPPASS.Name = "FTPPASS"
        Me.FTPPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.FTPPASS.Size = New System.Drawing.Size(455, 35)
        Me.FTPPASS.TabIndex = 22
        '
        'FTPUN
        '
        Me.FTPUN.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FTPUN.Location = New System.Drawing.Point(245, 257)
        Me.FTPUN.Name = "FTPUN"
        Me.FTPUN.Size = New System.Drawing.Size(455, 35)
        Me.FTPUN.TabIndex = 20
        '
        'FTPIP
        '
        Me.FTPIP.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FTPIP.Location = New System.Drawing.Point(245, 339)
        Me.FTPIP.Name = "FTPIP"
        Me.FTPIP.Size = New System.Drawing.Size(455, 35)
        Me.FTPIP.TabIndex = 21
        '
        '_frmFTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 653)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "_frmFTP"
        Me.Text = "MetroForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cbFtime As System.Windows.Forms.ComboBox
    Friend WithEvents FTP As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents label222 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents FTPPASS As System.Windows.Forms.TextBox
    Friend WithEvents FTPUN As System.Windows.Forms.TextBox
    Friend WithEvents FTPIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents cbSettings As System.Windows.Forms.ComboBox
    Friend WithEvents btnNewSettings As System.Windows.Forms.Button
    Friend WithEvents txtFTPName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTest As System.Windows.Forms.Button
End Class
