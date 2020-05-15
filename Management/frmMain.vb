Imports System.IO.Ports
Imports System.Threading
Imports LeoControls

Public Class frmMain
    Dim ShowList As New ArrayList
    Dim frmInt As New frmIntegral
    Public unitTemp As New LHUnit

    Delegate Sub TextCallback(ByVal txt As TextBox, ByVal cmd() As Byte, ByVal len As Byte)
    Delegate Sub Polling_dg1(ByVal volt As Single, ByVal power As Single,
                             ByVal unitnum As Byte, ByVal cellnum As Byte, ByVal over As Boolean)
    Delegate Sub Polling_dg4(ByVal volt As Single, ByVal power As Single,
                             ByVal unitnum As Byte, ByVal cellnum As Byte, ByVal cellpos As Byte, ByVal over As Boolean)
    Delegate Sub ToolControl(ByVal obj As Object, ByVal enable As Boolean)
    Public RS485 As New LHSerialPort("COM3", 1200, Parity.Even, 8, 1)
    Dim CommThread As New Thread(AddressOf CommTask)
    Public Sub mToolControl(ByVal obj As System.Windows.Forms.Timer, ByVal enable As Boolean)
        obj.Enabled = enable
    End Sub

    Private Sub PaintShow()
        For k = 0 To 31
            Dim show As New mainShow
            With show
                .no = k
                .Parent = GroupBox1
                .Left = 5 + (k Mod 6) * 145
                .Top = 15 + (k \ 6) * 85
                .Enabled = True
                .SetResult(k + 1, _unit(k).座子类型, _unit(k).电压流规格, _unit(k).Testing, _unit(k).试验编号)
            End With
            AddHandler show.Click, AddressOf MainShowClick
            ShowList.Add(show)
        Next
    End Sub '画界面
    Private Sub MainShowClick(ByVal sender As Object, ByVal e As EventArgs)
        If _unit(sender.no).Testing = &HC Then
            Dim frm As New frm340
            frm.unitNo = sender.no
            frm.Show()
        End If
    End Sub '340继续试验
    Private Sub ThreadInit()
        _commFlag.test660 = False
        _commFlag.polling = False
        _commFlag.startup = False
        _commFlag.integral = False
        _commFlag.timeModify = False
        _commFlag.reboot340 = False
        _commFlag.reboot = False
        _commFlag.unitNo_polling = 0
        _commFlag.unitNo_start = 0
        CommThread.Start()
    End Sub '线程初始化

    Private Sub frmMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        '_integralFlag = True
        'ShowList(6).Item(5).setResult(5.5, 6.6)
        'Dim v As Single = 5.5
        'Dim mA As Single = 6.6
        'Dim i As Byte = 5
        'Dim pos As Byte = 50
        ''PollingShow(v, v * mA, i, (pos - 1) \ 4, (pos - 1) Mod 4)
        'PollingShow(v, v * mA, i + 1, (pos - 1) \ 4 + 1, (pos - 1) Mod 4)

        'OneSec.Enabled = Not OneSec.Enabled
        '_commFlag.integral = True
        '_commFlag.unitNo = 0
        '_commFlag.startup = True
        'Dim cmd As New OleDbCommand
        'cmd.Connection = _DBconn
        'cmd.CommandText = "delete * from 试验结果"
        'cmd.ExecuteNonQuery()
        'Button1.Text = "ok"
        'Dim dbcmd As New OleDbCommand
        'dbcmd.Connection = _DBconn
        'For i = 1 To 9
        '    For j = 1 To 2
        '        dbCmd.CommandText = "insert into 试验结果 values ('" _
        '                            & (i * 10).ToString & _
        '                            "' , '" & i & _
        '                            "' , '" & 1 & _
        '                            "' , '" & Now & _
        '                            "' , '28.1')"
        '        dbCmd.ExecuteNonQuery()
        '    Next
        'Next
        'OneMin.Enabled = True
        'Panel2.Enabled = False
        'Panel3.Enabled = Not Panel3.Enabled
        'cmbUnitNo.SelectedIndex = -1
        'Me.Enabled = False

        'Dim frm As New frm340
        'frm.unitNo = 10
        'frm.Show()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        _DBconn.Close()
        If CommThread.IsAlive() Then
            CommThread.Abort()
        End If
        MsgBox("haha")
        RS485.Close()
        MsgBox("hehe")
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '------遮挡
        'Dim fs As New frmRoot
        ''fs.BackColor = Color.FromArgb(204, 232, 207)
        'fs.Show()
        'fs.Label1.Text = "加载数据..."
        'fs.Refresh()

        '------设置串口
        RS485.WriteBufferSize = 2048
        RS485.ReadTimeout = 200
        RS485.ReceivedBytesThreshold = 3
        RS485.RtsEnable = True
        Try
            RS485.Open()
        Catch ex As Exception
            MsgBox("请检查串口连接后再打开程序！")
            Me.Close()

        End Try

        '------打开数据库，初始化单元对象
        _DBconn.Open()
        For i = 0 To 31
            _unit(i) = New LHUnit
        Next
        DBMethord.Initial(_DBconn, _unit)
        PaintShow()     '绘制界面
        ThreadInit()    '线程初始化
        OneSec.Enabled = True
        OneMin.Enabled = True

        '单元操作区初始化
        InitOperationZone()

        'fs.Close()
    End Sub

    Private Sub OneSec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneSec.Tick
        Static i As Byte = 0
        If frmInt.Visible = True Then frmInt.Close()
        If Now.Minute >= 1 And Now.Minute <= 58 Then
            Dim j As Byte = 0
            While _unit(i).Testing <> 0
                i = (i + 1) Mod 24
                j += 1
                If j >= 24 Then Exit Sub
            End While '跳过停止的单元
            _commFlag.unitNo_polling = i
            _commFlag.polling = True
            i = (i + 1) Mod 24
        End If
    End Sub

    Private Sub OneMin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneMin.Tick
        If Now.Minute = 54 Then _commFlag.timeModify = True
        If Now.Minute = 55 Then _commFlag.timeModify = True
        If Now.Minute = 56 Then _commFlag.timeModify = True

        If Now.Minute >= 3 Then
            If Date.Compare(Now.Date, _lastRecallTime.Date) > 0 Then
                OneSec.Enabled = False
                OneMin.Enabled = False
                _commFlag.integral = True
                frmInt.ShowDialog()
            End If
            If (Date.Compare(Now.Date, _lastRecallTime.Date) = 0) And
                Now.Hour > _lastRecallTime.Hour Then
                OneSec.Enabled = False
                OneMin.Enabled = False
                _commFlag.integral = True
                frmInt.ShowDialog()
            End If
        End If
    End Sub

    Private Sub CommTask()
        While True
            If _commFlag.integral Then
                IntegralTask()
                _commFlag.integral = False
            End If
            If _commFlag.startup Then
                StartupTask(_commFlag.unitNo_start)
                _commFlag.startup = False
            End If
            If _commFlag.polling Then
                PollingTask(_commFlag.unitNo_polling)
                _commFlag.polling = False
            End If
            If _commFlag.timeModify Then
                TimeModifyTask()
                _commFlag.timeModify = False
            End If
            If _commFlag.reboot340 Then
                Reboot340Task(_commFlag.unitNo_start)
                _commFlag.reboot340 = False
            End If
            If _commFlag.reboot Then
                RebootTask(_commFlag.unitNo_start)
                _commFlag.reboot = False
            End If
        End While
    End Sub


    Private Sub showbyte(ByVal txt As TextBox, ByVal cmd() As Byte, ByVal len As Byte)
        If txt.TextLength > 1000 Then
            txt.Text = ""
        End If
        For i = 1 To len
            txt.Text += cmd(i - 1).ToString("X2") & " "
        Next
        txt.Text += vbNewLine

    End Sub


    Private Sub txtSend_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSend.TextChanged
        txtSend.SelectionStart = txtSend.TextLength
        txtSend.ScrollToCaret()
    End Sub


    Private Sub txtRecv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecv.TextChanged
        txtRecv.SelectionStart = txtRecv.TextLength
        txtRecv.ScrollToCaret()
    End Sub



    '--------------------------------------
    '单元操作区的操作逻辑放在此处

    Private Sub cmbUnitNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnitNo.SelectedIndexChanged
        If cmbUnitNo.SelectedIndex = -1 Then Exit Sub
        Dim unitNo As Byte = cmbUnitNo.SelectedIndex

        If _unit(unitNo).Testing = 0 Then
            MsgBox("该单元正在进行测试，请确认后重新选择。",, "提醒")
            Exit Sub
        End If

        If _unit(unitNo).Testing = &HC Then
            If MsgBox("该单元正在等待340小时后续试验，是否重新开始？",
                    MsgBoxStyle.OkCancel, "提醒") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        If _unit(unitNo).座子类型 Then
            lblWeishu.Text = "四 位"
        Else
            lblWeishu.Text = "一 位"
        End If
        If _unit(unitNo).电压流标记 Then
            '电流型
            Label14.Text = "电流规格"
            Label18.Text = "临界电流"
            Select Case _unit(unitNo).电压流规格
                Case 1
                    lblVolt.Text = "10mA"
                    txtMax.Text = 10.5
                    txtMin.Text = 9.5
                Case 2
                    lblVolt.Text = "20mA"
                    txtMax.Text = 21
                    txtMin.Text = 19
                Case 3
                    lblVolt.Text = "30mA"
                    txtMax.Text = 31.5
                    txtMin.Text = 28.5
            End Select
        Else
            '电压型
            Label14.Text = "电压规格"
            Label18.Text = "临界电压"
            Select Case _unit(unitNo).电压流规格
                Case 0
                    lblVolt.Text = "21V"
                    txtMax.Text = 22
                    txtMin.Text = 20
                Case 1
                    lblVolt.Text = "25V"
                    txtMax.Text = 26
                    txtMin.Text = 24
                Case 2
                    lblVolt.Text = "28V"
                    txtMax.Text = 29
                    txtMin.Text = 27
                Case 3
                    lblVolt.Text = "16V"
                    txtMax.Text = 17
                    txtMin.Text = 15
                Case 4
                    lblVolt.Text = "5.5V"
                    txtMax.Text = 5.7
                    txtMin.Text = 5.3
            End Select
        End If

        Panel3.Enabled = True
        lblPos.Enabled = False
        Panel3.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
    End Sub

    Private Sub cmbChipWeishu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChipWeishu.SelectedIndexChanged
        If cmbChipWeishu.SelectedIndex = -1 Then Exit Sub
        lblPos.Text = "点此插放器件"
        lblPos.ForeColor = Color.Red
        lblPos.Enabled = True
    End Sub

    Private Sub lblPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPos.Click

        If cmbChipWeishu.SelectedIndex = -1 Then
            MsgBox("请先选择器件类型！",, "提醒")
            Exit Sub
        End If
        If lblPos.Text = "器件插放完成" Then
            lblPos.Text = "点此插放器件"
            lblPos.ForeColor = Color.Red
        End If

        If cmbUnitNo.SelectedIndex >= 0 And cmbUnitNo.SelectedIndex <= 7 _
            And cmbChipWeishu.SelectedIndex = 1 Then  '四位插四位
            frmPosChart4.Show()
        End If
        If cmbUnitNo.SelectedIndex >= 8 And cmbUnitNo.SelectedIndex <= 23 _
            And cmbChipWeishu.SelectedIndex = 0 Then  '一位插一位
            frmPosChart1.Show()
        End If
        If cmbUnitNo.SelectedIndex >= 24 And cmbUnitNo.SelectedIndex <= 31 _
            And cmbChipWeishu.SelectedIndex = 2 Then  '独立发光管
            frmPosChart21.Show()
        End If
        If cmbUnitNo.SelectedIndex >= 24 And cmbUnitNo.SelectedIndex <= 31 _
            And cmbChipWeishu.SelectedIndex = 3 Then  '2位发光管
            frmPosChart1.Show()
        End If
    End Sub

    Private Sub InitOperationZone()

        cmbUnitNo.SelectedIndex = -1
        lblVolt.Text = "- V"
        lblWeishu.Text = "- 位"
        Panel2.BorderStyle = Windows.Forms.BorderStyle.None
        Panel2.Enabled = True

        cmbType.SelectedIndex = -1
        cmbChipWeishu.SelectedIndex = -1
        txtMax.Text = ""
        txtMin.Text = ""
        lblPos.Text = "点此插放器件"
        lblPos.ForeColor = Color.Red
        Panel3.BorderStyle = Windows.Forms.BorderStyle.None
        Panel3.Enabled = False

        txt标准号.Text = ""
        txt生产批号.Text = ""
        txt质量等级.Text = ""
        txt试验编号.Text = ""
        Panel4.BorderStyle = Windows.Forms.BorderStyle.None
        Panel4.Enabled = False

        cmbUnitNo.Focus()
    End Sub

    Private Sub btnStartCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartCancel.Click
        InitOperationZone()
    End Sub

    Private Sub txtMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMax.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(46) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(46) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Function float2byte(ByVal volt As String, ByVal limit As Single) As Byte
        Select Case volt
            Case "21V" : Return CByte((limit * 25600 - 387200) / 1175)
            Case "25V" : Return CByte((limit * 25600 - 464000) / 1375)
            Case "28V" : Return CByte((limit * 25600 - 521600) / 1525)
            Case "16V" : Return CByte((limit * 25600 - 291200) / 925)
            Case "5.5V" : Return CByte((limit * 25600 - 105600) / 275)
            Case "10mA" : Return CByte((limit * 250 / 1000 - 2.5) / 5 * 256 * 4 + 128)
            Case "20mA" : Return CByte((limit * 125 / 1000 - 2.5) / 5 * 256 * 4 + 128)
            Case "30mA" : Return CByte((limit * 250 / 3 / 1000 - 2.5) / 5 * 256 * 4 + 128)
        End Select
    End Function

    Private Sub btnStartOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartOK.Click
        Dim pos(95) As Byte
        pos = unitTemp.对位表

        If cmbChipWeishu.SelectedIndex = 3 And cmbUnitNo.SelectedIndex >= 24 Then '发光二极管独立器件
            For i = 0 To 94 Step 2
                pos(i + 1) = pos(i)
            Next
        End If

        unitTemp = _unit(cmbUnitNo.SelectedIndex)
        With unitTemp
            .结果文件 = Application.StartupPath & "/试验结果/" &
                txt试验编号.Text & "_" & Now.Date.ToLongDateString() & ".xls"
            .对位表 = pos
            .试验编号 = txt试验编号.Text
            .产品型号 = cmbType.Text
            .质量等级 = txt质量等级.Text
            .标准号 = txt标准号.Text
            .生产批号 = txt生产批号.Text
            .上限 = float2byte(lblVolt.Text, txtMax.Text)
            .下限 = float2byte(lblVolt.Text, txtMin.Text)
            .开机日期 = Now.Date
            If cmbChipWeishu.SelectedIndex = 0 Then
                .器件类型 = 0
            ElseIf cmbChipWeishu.SelectedIndex = 1 Then
                .器件类型 = 2
            ElseIf cmbChipWeishu.SelectedIndex = 2 Then
                .器件类型 = 3
            ElseIf cmbChipWeishu.SelectedIndex = 3 Then
                .器件类型 = 1
            End If

        End With

        _unit(cmbUnitNo.SelectedIndex) = unitTemp

        _commFlag.unitNo_start = cmbUnitNo.SelectedIndex
        Select Case _unit(cmbUnitNo.SelectedIndex).Testing
            'Case &H0 : _commFlag.reboot = True
            Case &H3 : _commFlag.startup = True
            Case &HC : _commFlag.reboot340 = True
            Case &H30 : _commFlag.startup = True
        End Select

        InitOperationZone()
    End Sub


End Class
