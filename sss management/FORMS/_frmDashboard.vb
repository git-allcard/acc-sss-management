
#Region " Imports "

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Threading

#End Region

Public Class _frmDashboard

#Region " Constructors "

    Dim db As New ConnectionString
    Dim getAutoGenID As String
    Dim trd As Thread

#End Region

    Private Sub _frmDashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        ''If MessageBox.Show("Loading of dashboard data may take time. Do you want to continue?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        ''Timer1.Start()

        StartThread()
        ''End If
    End Sub
    Public Sub loadDetailslvList()
        Try
            RefreshDb()
            Dim ipadd As String = lvList.SelectedItems(0).SubItems(1).Text
            _frmMonitoring.lblKname.Text = db.putSingleValuev2("Select KIOSK_NM FROM SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lblKIP.Text = db.putSingleValuev2("Select BRANCH_IP FROM SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lblKbranch.Text = db.putSingleValuev2("Select SSINFOTERMBR.BRANCH_NM FROM SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lblStatus.Text = db.putSingleValuev2("Select DISTINCT STATUS FROM SSMONITORING where DATESTAMP = (select MAX(DATESTAMP) from SSMONITORING WHERE BRANCH_IP = '" & ipadd & "')")
            _frmMonitoring.lblCluster.Text = db.putSingleValuev2("Select SSINFOTERMCLSTR.CLSTR_NM FROM SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD inner join SSINFOTERMCLSTR on SSINFOTERMKIOSK.CLSTR = SSINFOTERMCLSTR.CLSTR_CD where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lblGroup.Text = db.putSingleValuev2("Select SSINFOTERMGROUP.GROUP_NM FROM SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD INNER JOIN SSINFOTERMGROUP on SSINFOTERMGROUP.GROUP_CD = SSINFOTERMKIOSK.DIVSN where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.LASTONLINE.Text = db.putSingleValuev2("Select max(ONLINE_DT) FROM SSMONITORING where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.LASTOFFLINE.Text = db.putSingleValuev2("Select max(OFFLINE_DT) FROM SSMONITORING where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lbldate.Text = db.putSingleValuev2("Select ENCODE_DT from SSINFOTERMKIOSK where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lblSerial.Text = db.putSingleValuev2("Select SERIALNUM FROM SSINFOTERMKIOSK WHERE BRANCH_IP = '" & ipadd & "'")
            Dim getId As String = db.putSingleValuev2("Select KIOSK_ID from SSINFOTERMKIOSK where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.lblTrans.Text = db.putSingleValuev2("SELECT COUNT(REF_NUM) from SSINFOTERMACCESS where KIOSK_ID = '" & getId & "' and REF_NUM <>'' ")
            _frmMonitoring.OpStart1.Text = db.putSingleValuev2("Select OP_START from SSINFOTERMKIOSK where BRANCH_IP = '" & ipadd & "'")
            _frmMonitoring.OpEnd1.Text = db.putSingleValuev2("Select OP_END from SSINFOTERMKIOSK where BRANCH_IP = '" & ipadd & "'")

            If IsDate(_frmMonitoring.LASTOFFLINE.Text) Then
                Dim date1 As DateTime =
      System.Convert.ToDateTime(_frmMonitoring.LASTOFFLINE.Text)

                Dim date2 As DateTime =
             System.Convert.ToDateTime(DateAndTime.Now)

                Dim ts As New TimeSpan()

                ts = date2.Subtract(date1)

                _frmMonitoring.lblOD.Text = ts.Days & " Day(s) " &
              ts.Hours & " Hr(s) " & ts.Minutes & " Min(s) " & ts.Seconds &
            " Sec(s) Ago"


                db.FillDataGridView("select unpvt.value, case when unpvt.attribute = 'OFFLINE_DT' then '*** OFFLINE ***' else 'ONLINE' end as [STATUS] FROM SSMONITORING c UNPIVOT ( value for attribute in (ONLINE_DT,OFFLINE_DT) )unpvt INNER JOIN SSINFOTERMKIOSK ON SSINFOTERMKIOSK.BRANCH_IP = unpvt.BRANCH_IP where cast(unpvt.[value] as date) BETWEEN '" & Today & "' and '" & Today & "' and SSINFOTERMKIOSK.BRANCH_IP = '" & ipadd & "' UNION SELECT GETDATE() AS VALUE, 'ONLINE' AS STATUS  FROM SSINFOTERMKIOSK INNER JOIN SSMONITORING ON SSMONITORING.BRANCH_IP = SSINFOTERMKIOSK.BRANCH_IP WHERE SSINFOTERMKIOSK.BRANCH_IP NOT IN(SELECT SSMONITORING.BRANCH_IP FROM SSMONITORING where cast(DATESTAMP as date) = '" & Today & "') and SSINFOTERMKIOSK.BRANCH_IP = '" & ipadd & "' ORDER BY unpvt.value", _frmMonitoring.dgvLogs)

                Exit Sub
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RefreshDb()
        If db Is Nothing Then db = New ConnectionString
    End Sub

    Public Sub fillKioskNum()
        Try
            RefreshDb()
            lblTot.Text = "0"
            lblOnline.Text = "0"
            lblOffline.Text = "0"
            lblSO.Text = "0"
            'lblOffline.Text = db.putSingleValuev2("SELECT COUNT(DISTINCT SSINFOTERMKIOSK.KIOSK_ID) FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD INNER JOIN SSMONITORING ON SSINFOTERMKIOSK.BRANCH_IP=SSMONITORING.BRANCH_IP WHERE SSMONITORING.STATUS = 1 AND " & dateStampFiltering(Today.ToString("yyyy-MM-dd")) & " and isvpn = 0", lblOffline.Text)
            'lblOnline.Text = db.putSingleValuev2("SELECT COUNT(DISTINCT SSINFOTERMKIOSK.KIOSK_ID) FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD WHERE (SSINFOTERMKIOSK.BRANCH_IP NOT IN(SELECT BRANCH_IP FROM SSMONITORING) OR BRANCH_IP NOT IN(SELECT DISTINCT BRANCH_IP FROM SSMONITORING WHERE STATUS=1 AND " & dateStampFiltering(Today.ToString("yyyy-MM-dd")) & " )) and isvpn = 0", lblOnline.Text)
            'lblSO.Text = db.putSingleValuev2("SELECT COUNT(DISTINCT SSINFOTERMKIOSK.KIOSK_ID) FROM SSINFOTERMKIOSK WHERE isvpn = 1")
            Dim i As Integer = lblOnline.Text
            Dim x As Integer = lblOffline.Text
            Dim z As Integer = lblSO.Text
            lbltotal.Text = i + x + z

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub fillListview()
        Try
            RefreshDb()

            lvDiv.Items.Clear()
            lvGroup.Items.Clear()
            db.FillListView(db.ExecuteSQLQuery("Select DISTINCT SSINFOTERMGROUP.GROUP_NM as 'GROUP' from SSINFOTERMKIOSK INNER JOIN SSINFOTERMGROUP ON SSINFOTERMGROUP.GROUP_CD = SSINFOTERMKIOSK.DIVSN  WHERE  TAG = 1 and isVPN = 'false' order by SSINFOTERMGROUP.GROUP_NM"), lvDivsn)
            'db.RemoveDup(lvDivsn)
            db.FillListView(db.ExecuteSQLQuery("Select DISTINCT SSINFOTERMCLSTR.CLSTR_NM as 'DIVISION' from SSINFOTERMKIOSK inner join SSINFOTERMCLSTR on SSINFOTERMKIOSK.CLSTR = SSINFOTERMCLSTR.CLSTR_CD where TAG = 1 and isVPN = 'false' order by SSINFOTERMCLSTR.CLSTR_NM"), lvGroup)
            'db.RemoveDup(lvGroup)
            db.FillListView(db.ExecuteSQLQuery("Select DISTINCT SSINFOTERMBR.BRANCH_NM as 'BRANCH' from SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD where TAG = 1 and isVPN = 'false' order by SSINFOTERMBR.BRANCH_NM"), lvDiv)
            'db.RemoveDup(lvDiv)
            'db.FillListView(db.ExecuteSQLQuery("SELECT DISTINCT SSINFOTERMKIOSK.KIOSK_ID,SSINFOTERMKIOSK.BRANCH_IP,SSINFOTERMBR.BRANCH_NM, '' AS OFFLINE_DT, TAG = 'ONLINE' FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD WHERE (SSINFOTERMKIOSK.BRANCH_IP NOT IN(SELECT BRANCH_IP FROM SSMONITORING) OR BRANCH_IP NOT IN(SELECT DISTINCT BRANCH_IP FROM SSMONITORING WHERE STATUS=1 AND CAST(DATESTAMP AS DATE) = '" & Today & "')) and SSINFOTERMKIOSK.isVPN= 0 UNION SELECT DISTINCT SSINFOTERMKIOSK.KIOSK_ID,SSINFOTERMKIOSK.BRANCH_IP,SSINFOTERMBR.BRANCH_NM,cast(SSMONITORING.OFFLINE_DT as varchar), TAG = 'OFFLINE' FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD INNER JOIN SSMONITORING ON SSINFOTERMKIOSK.BRANCH_IP=SSMONITORING.BRANCH_IP WHERE SSMONITORING.STATUS = 1 AND CAST(DATESTAMP AS DATE) = '" & Today & "'  ORDER BY KIOSK_ID "), lvList)
            'db.FillListView(db.ExecuteSQLQuery("SELECT DISTINCT SSINFOTERMKIOSK.KIOSK_ID,SSINFOTERMKIOSK.BRANCH_IP,SSINFOTERMBR.BRANCH_NM, '' AS OFFLINE_DT, TAG = 'ONLINE' FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD WHERE (SSINFOTERMKIOSK.BRANCH_IP NOT IN(SELECT BRANCH_IP FROM SSMONITORING) OR BRANCH_IP NOT IN(SELECT DISTINCT BRANCH_IP FROM SSMONITORING WHERE STATUS=1 AND " & dateStampFiltering(Today.ToString("yyyy-MM-dd")) & ")) and SSINFOTERMKIOSK.isVPN= 0 UNION SELECT DISTINCT SSINFOTERMKIOSK.KIOSK_ID,SSINFOTERMKIOSK.BRANCH_IP,SSINFOTERMBR.BRANCH_NM,cast(SSMONITORING.OFFLINE_DT as varchar), TAG = 'OFFLINE' FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD INNER JOIN SSMONITORING ON SSINFOTERMKIOSK.BRANCH_IP=SSMONITORING.BRANCH_IP WHERE SSMONITORING.STATUS = 1 AND " & dateStampFiltering(Today.ToString("yyyy-MM-dd")) & " ORDER BY KIOSK_ID "), lvList)
            PopulateLVList()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub PopulateLVList()
        Dim dal As New DAL_Mssql
        'Dim reportDate As String = Now.ToString("yyyy-MM-dd")
        Dim reportDate As String = "2022-04-16"
        Try
            Dim sb As New System.Text.StringBuilder
            sb.Append("Select DISTINCT SSINFOTERMKIOSK.KIOSK_ID,SSINFOTERMKIOSK.BRANCH_IP,SSINFOTERMBR.BRANCH_NM, sm.OFFLINE_DT, Case When sm.OFFLINE_DT Is null Then 'ONLINE' ELSE 'OFFLINE' end TAG, SSINFOTERMKIOSK.isVPN ")
            sb.Append("From SSINFOTERMKIOSK INNER Join SSINFOTERMBR On SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD LEFT OUTER JOIN ")
            sb.Append(String.Format("(Select BRANCH_IP, OFFLINE_DT From SSMONITORING Where STATUS = 1 And DATESTAMP BETWEEN '{0} 00:00:00' AND '{0} 23:59:59') sm on sm.branch_ip = SSINFOTERMKIOSK.BRANCH_IP ", reportDate))
            sb.Append("where SSINFOTERMKIOSK.BRANCH_CD <> '' ") 'and SSINFOTERMKIOSK.isVPN = 0 ")
            sb.Append("ORDER BY SSINFOTERMKIOSK.KIOSK_ID ")

            If dal.SelectQuery(sb.ToString) Then
                Dim dtMain As DataTable = dal.TableResult
                Dim dtWithIP As DataTable = GetOnlineOfflineDataWithIP(dtMain)

                If Not dtWithIP Is Nothing Then
                    Dim dtOnlineOffline As DataTable = GetOnlineOfflineData(2, "isVPN", 0, dtWithIP)
                    If Not dtOnlineOffline Is Nothing Then
                        dtOnlineOffline.Columns.Remove("isVPN")
                        db.FillListView(dtOnlineOffline, lvList)
                    End If

                    lblOnline.Text = dtOnlineOffline.Select("TAG='ONLINE'").Length.ToString()
                    lblOffline.Text = dtOnlineOffline.Select("TAG='OFFLINE'").Length.ToString()
                End If

                lblSO.Text = dtMain.Select("isVPN=1").Length.ToString()
                lbltotal.Text = dtMain.DefaultView.Count.ToString()
            End If
        Catch ex As Exception

        Finally
            dal.Dispose()
            dal = Nothing
        End Try
    End Sub

    Private Function GetOnlineOfflineData(ByVal type As Short, ByVal field As String, ByVal value As String, ByVal dt As DataTable) As DataTable
        Try
            'type: 1=string, 2=boolean
            If type = 1 Then
                Return dt.AsEnumerable().Where(Function(r) r.Field(Of String)(field) = value).CopyToDataTable
            ElseIf type = 2 Then
                Return dt.AsEnumerable().Where(Function(r) r.Field(Of Boolean)(field) = value).CopyToDataTable
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Function GetOnlineOfflineDataWithIP(ByVal dt As DataTable) As DataTable
        Try
            Return dt.AsEnumerable().Where(Function(r) r.Field(Of String)("BRANCH_IP") <> "").CopyToDataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Function dateStampFiltering(ByVal reportDate As String) As String
        Return String.Format(" DATESTAMP BETWEEN '{0} 00:00:00' AND '{0} 23:59:59'", reportDate)
    End Function

    Public Sub putDataBranch()
        Try
            lblOnline1.Text = db.putSingleValuev2("SELECT COUNT(DISTINCT SSINFOTERMKIOSK.KIOSK_ID) FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD WHERE (SSINFOTERMKIOSK.BRANCH_IP NOT IN(SELECT BRANCH_IP FROM SSMONITORING) OR BRANCH_IP NOT IN(SELECT DISTINCT BRANCH_IP FROM SSMONITORING WHERE STATUS=1 AND CAST(DATESTAMP AS DATE) = '" & Today & "')) AND SSINFOTERMBR.BRANCH_NM='" & lvDiv.SelectedItems(0).Text & "'", lblOffline.Text)
            lblOffline1.Text = db.putSingleValuev2("SELECT COUNT(distinct SSMONITORING.BRANCH_IP) FROM SSINFOTERMKIOSK INNER JOIN SSMONITORING ON SSMONITORING.BRANCH_IP = SSINFOTERMKIOSK.BRANCH_IP INNER JOIN SSINFOTERMBR ON SSINFOTERMBR.BRANCH_CD = SSMONITORING.BRANCH_CD where SSMONITORING.STATUS = 1 and cast(DATESTAMP as date) = '" & Today & "' and SSINFOTERMBR.BRANCH_NM = '" & lvDiv.SelectedItems(0).Text & "'", lblOffline.Text)
            Dim i As Integer = lblOnline1.Text
            Dim y As Integer = lblOffline1.Text
            lblTot.Text = i + y
            lblBranch.Text = lvDiv.SelectedItems(0).Text
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub fillData()
        Try
            If lvList.Columns.Count > 0 Then
                For Each lvi As ListViewItem In lvList.Items
                    If lvi.SubItems(4).Text = "ONLINE" Then
                        lvi.UseItemStyleForSubItems = False
                        For i As Integer = 0 To 2
                            'Dim ip As String = lvi.SubItems(2).Text
                            'If My.Computer.Network.Ping(ip) Then
                            lvi.SubItems(0).ForeColor = Color.Green
                            lvi.SubItems(1).ForeColor = Color.Green
                            lvi.SubItems(2).ForeColor = Color.Green
                            lvi.SubItems(3).ForeColor = Color.Green
                            lvi.SubItems(4).ForeColor = Color.Green
                        Next
                    Else

                        lvi.SubItems(0).ForeColor = Color.Red
                        lvi.SubItems(1).ForeColor = Color.Red
                        lvi.SubItems(2).ForeColor = Color.Red
                        lvi.SubItems(3).ForeColor = Color.Red
                        lvi.SubItems(4).ForeColor = Color.Red
                        'lvi.SubItems(5).ForeColor = Color.Red
                    End If
                Next
                lvList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize)
                lvList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)

                lvList.Columns(4).Width = 0
            End If

            If lvGroup.Columns.Count > 0 Then
                lvGroup.Columns(0).Width = -2
                lvDiv.Columns(0).Width = -2
                lvDivsn.Columns(0).Width = -2
                lvDivsn.Enabled = True
                lvDiv.Enabled = True
                lvGroup.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub fillData1()
        For Each lvi As ListViewItem In lvList.Items
            If lvi.SubItems(4).Text = "ONLINE" Then
                lvi.UseItemStyleForSubItems = False
                For i As Integer = 0 To 2
                    'Dim ip As String = lvi.SubItems(2).Text
                    'If My.Computer.Network.Ping(ip) Then
                    lvi.SubItems(0).ForeColor = Color.Green
                    lvi.SubItems(1).ForeColor = Color.Green
                    lvi.SubItems(2).ForeColor = Color.Green
                    lvi.SubItems(3).ForeColor = Color.Green
                    lvi.SubItems(4).ForeColor = Color.Green
                Next
            Else

                lvi.SubItems(0).ForeColor = Color.Red
                lvi.SubItems(1).ForeColor = Color.Red
                lvi.SubItems(2).ForeColor = Color.Red
                lvi.SubItems(3).ForeColor = Color.Red
                lvi.SubItems(4).ForeColor = Color.Red
                ' lvi.SubItems(5).ForeColor = Color.Red
            End If
        Next
        lvList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize)
        lvList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)

        'lvList.Columns(3).Width = 0
        lvList.Columns(4).Width = 0
    End Sub


    Private Delegate Sub dlgtPopulateData()

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim del As New dlgtPopulateData(AddressOf PopulateData)
        'del.Invoke()
    End Sub

    Private _thread As Thread

    Private Sub StartThread()
        Dim objNewThread As New Thread(AddressOf ThreadProcess)
        objNewThread.Start()
        _thread = objNewThread
    End Sub

    Private Sub ThreadProcess()
        Do While True
            Dim del As New dlgtPopulateData(AddressOf PopulateData)
            del.Invoke()
            del = Nothing
            System.Threading.Thread.Sleep(1000 * 600)
        Loop
    End Sub

    Private Delegate Sub dlgtfillKioskNum()

    Private Sub PopulateData()
        lvDivsn.Enabled = False
        lvDiv.Enabled = False
        lvGroup.Enabled = False
        Try
            'SplitContainer1.Panel2.Controls.Clear()
            '_frmLoading.TopLevel = False
            '_frmLoading.Parent = SplitContainer1.Panel2
            '_frmLoading.Dock = DockStyle.Fill
            '_frmLoading.Show()
            Dim delfillKioskNum As New dlgtfillKioskNum(AddressOf fillKioskNum)
            Dim delfillListview As New dlgtfillKioskNum(AddressOf fillListview)
            Dim delfillData As New dlgtfillKioskNum(AddressOf fillData)
            delfillKioskNum.Invoke()
            delfillListview.Invoke()
            delfillData.Invoke()

            ''fillKioskNum()
            ''fillListview()
            ''fillData()

            'lvGroup.Columns(0).Width = -2
            'lvDiv.Columns(0).Width = -2
            'lvDivsn.Columns(0).Width = -2
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'lvDivsn.Enabled = True
        'lvDiv.Enabled = True
        'lvGroup.Enabled = True
        '_frmLoading.Dispose()
        'lvList.Show()
        'lvDiv.Show()
        'lvGroup.Show()
        'lvList.Visible = True
        'lvGroup.Visible = True
        'lvDiv.Visible = True
        'lvDiv.Parent = SplitContainer3.Panel2
        'lvGroup.Parent = SplitContainer3.Panel1
        'lvList.Parent = Panel3
        'lvDiv.Dock = DockStyle.Fill
        'lvGroup.Dock = DockStyle.Fill
        'lvList.Dock = DockStyle.Fill
        'Timer1.Interval = (1000 * 300)
    End Sub

    Private Sub lvDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDiv.Click
        Dim del As New dlgtlvDivsn(AddressOf lvDiv_Click)
        del.Invoke()
    End Sub

    Private Delegate Sub dlgtlvDiv()

    Private Sub lvDiv_Click()
        Try
            lvList.Items.Clear()
            db.FillListView(db.ExecuteSQLQuery("SELECT DISTINCT SSINFOTERMKIOSK.KIOSK_ID as 'Terminal ID',SSINFOTERMKIOSK.BRANCH_IP 'Terminal IP',SSINFOTERMBR.BRANCH_NM as 'Branch Name', '' AS OFFLINE_DT, TAG = 'ONLINE' FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD WHERE (SSINFOTERMKIOSK.BRANCH_IP NOT IN(SELECT BRANCH_IP FROM SSMONITORING) OR BRANCH_IP NOT IN(SELECT DISTINCT BRANCH_IP FROM SSMONITORING WHERE STATUS=1 AND CAST(DATESTAMP AS DATE) = '" & Today & "')) AND SSINFOTERMBR.BRANCH_NM= '" & lvDiv.SelectedItems(0).Text & "' UNION SELECT DISTINCT SSINFOTERMKIOSK.KIOSK_ID,SSINFOTERMKIOSK.BRANCH_IP,SSINFOTERMBR.BRANCH_NM, cast(SSMONITORING.OFFLINE_DT as varchar), TAG = 'OFFLINE' FROM SSINFOTERMKIOSK INNER JOIN SSINFOTERMBR ON SSINFOTERMKIOSK.BRANCH_CD=SSINFOTERMBR.BRANCH_CD INNER JOIN SSMONITORING ON SSINFOTERMKIOSK.BRANCH_IP=SSMONITORING.BRANCH_IP WHERE (SSMONITORING.STATUS = 1 AND CAST(DATESTAMP AS DATE) = '" & Today & "') AND SSINFOTERMBR.BRANCH_NM= '" & lvDiv.SelectedItems(0).Text & "' ORDER BY KIOSK_ID"), lvList)
            putDataBranch()
            fillData1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub lvGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvGroup.Click
        Dim del As New dlgtlvDivsn(AddressOf lvGroup_Click)
        del.Invoke()
    End Sub

    Private Delegate Sub dlgtlvGroup()

    Private Sub lvGroup_Click()
        Try
            lblTot.Text = Nothing
            lblOnline1.Text = Nothing
            lblOffline1.Text = Nothing
            lblBranch.Text = Nothing
            lvList.Clear()
            lvDiv.Clear()
            lvDiv.Items.Clear()
            db.FillListView(db.ExecuteSQLQuery("Select DISTINCT SSINFOTERMBR.BRANCH_NM as 'Branch Name' from SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD INNER JOIN SSINFOTERMCLSTR on SSINFOTERMKIOSK.CLSTR = SSINFOTERMCLSTR.CLSTR_CD where SSINFOTERMCLSTR.CLSTR_NM = '" & lvGroup.SelectedItems(0).Text & "'and TAG = 1 and isVPN = 'false' order by SSINFOTERMBR.BRANCH_NM"), lvDiv)
            'db.RemoveDup(lvDiv)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub lvList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.Click
        Try
            loadDetailslvList()
            _frmMain.SplitContainer1.Panel2.Controls.Clear()
            _frmMonitoring.TopLevel = False
            _frmMonitoring.Parent = _frmMain.SplitContainer1.Panel2
            _frmMonitoring.Dock = DockStyle.Fill
            _frmMonitoring.Show()
            _frmMonitoring.lvList.Size = New System.Drawing.Size(521, 99)
            _frmMonitoring.lvPC.Size = New System.Drawing.Size(544, 99)
            _frmMonitoring.dgvLogs.Visible = True
            _frmMonitoring.btnBack.Visible = True
            _frmMain.btnDash.BackColor = Color.White
            _frmMain.btnDash.FlatStyle = FlatStyle.Standard
            _frmMain.btnDash.ForeColor = Color.Black
            _frmMain.btnMonitoring.FlatStyle = FlatStyle.Flat
            _frmMain.btnMonitoring.BackColor = Color.Blue
            _frmMain.btnMonitoring.ForeColor = Color.White
            _frmMonitoring.DURATION.Text = "OFFLINE DURATION"
            _frmMonitoring.dgvLogs.Visible = True
            _frmMonitoring.gbKioskHistory.Visible = True
            _frmMonitoring.lblFilter.Visible = True
            _frmMonitoring.dtpFrom.Visible = True
            _frmMonitoring.dtpTo.Visible = True
            Select Case _frmMonitoring.lblStatus.Text

                Case "True"
                    _frmMonitoring.lblStatus.Text = "OFFLINE"
                    _frmMonitoring.lblStatus.ForeColor = Color.Red
                    _frmMonitoring.lblLastOnline.Visible = True
                    _frmMonitoring.LASTOFFLINE.Visible = False
                    _frmMonitoring.lblOffline.Visible = False
                    _frmMonitoring.LASTONLINE.Visible = True

                Case "False"
                    _frmMonitoring.lblStatus.Text = "ONLINE"
                    _frmMonitoring.lblStatus.ForeColor = Color.Green
                    _frmMonitoring.lblLastOnline.Visible = False
                    _frmMonitoring.LASTOFFLINE.Visible = True
                    _frmMonitoring.lblOffline.Visible = True
                    _frmMonitoring.LASTONLINE.Visible = False

            End Select
            Dim DateFrom As Date = _frmMonitoring.dtpFrom.Value
            Dim DateTo As Date = _frmMonitoring.dtpTo.Value

        Catch ex As Exception
            MsgBox("The SET has no record yet")
        End Try
    End Sub

    Private Sub lvDivsn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDivsn.Click
        Dim del As New dlgtlvDivsn(AddressOf lvDivsn_Click)
        del.Invoke()
    End Sub

    Private Delegate Sub dlgtlvDivsn()

    Private Sub lvDivsn_Click()
        Try
            lblOnline1.Text = Nothing
            lblOffline1.Text = Nothing
            lblBranch.Text = Nothing
            lvList.Clear()
            lvDiv.Clear()
            lvGroup.Clear()
            lvGroup.Items.Clear()
            db.FillListView(db.ExecuteSQLQuery("Select DISTINCT SSINFOTERMCLSTR.CLSTR_NM as 'Division' FROM SSINFOTERMKIOSK inner join SSINFOTERMBR on SSINFOTERMKIOSK.BRANCH_CD = SSINFOTERMBR.BRANCH_CD INNER JOIN SSINFOTERMCLSTR on SSINFOTERMKIOSK.CLSTR = SSINFOTERMCLSTR.CLSTR_CD INNER JOIN SSINFOTERMGROUP ON SSINFOTERMGROUP.GROUP_CD = SSINFOTERMKIOSK.DIVSN WHERE SSINFOTERMGROUP.GROUP_NM = '" & lvDivsn.SelectedItems(0).Text & "' and TAG = 1 and isVPN = 'false' order by SSINFOTERMCLSTR.CLSTR_NM asc"), lvGroup)
            'db.RemoveDup(lvGroup)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub lbltotal_Click(sender As Object, e As EventArgs) Handles lbltotal.Click

    End Sub

    Private Sub lblSO_Click(sender As Object, e As EventArgs) Handles lblSO.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class