Imports System.Data.OleDb
Imports System.IO.Ports
Imports System.Threading
Imports LeoControls

Public Class frmMain
    Dim ShowList(23) As ArrayList
    Dim frmInt As New frmIntegral
    Public unitTemp As New LHUnit
    
    Delegate Sub TextCallback(ByVal txt As TextBox, ByVal cmd() As Byte, ByVal len As Byte)
    Delegate Sub Polling_dg1(ByVal volt As Single, ByVal power As Single, _
                             ByVal unitnum As Byte, ByVal cellnum As Byte, ByVal over As Boolean)
    Delegate Sub Polling_dg4(ByVal volt As Single, ByVal power As Single, _
                             ByVal unitnum As Byte, ByVal cellnum As Byte, ByVal cellpos As Byte, ByVal over As Boolean)
    Delegate Sub ToolControl(ByVal obj As Object, ByVal enable As Boolean)

    Public RS485 As New LHSerialPort("COM3", 1200, Parity.Even, 8, 1)

    Dim CommThread As New Thread(AddressOf CommTask)
    Public Sub mToolControl(ByVal obj As System.Windows.Forms.Timer, ByVal enable As Boolean)
        obj.Enabled = enable
    End Sub

    Private Sub PaintShow()
        For k = 0 To 23
            ShowList(k) = New ArrayList
            If Not _unit(k).座子类型 Then       '1位器件
                Dim sshow(47) As OneShow
                For j = 0 To 3
                    For i = 0 To 11
                        sshow(j * 12 + i) = New OneShow
                        With sshow(j * 12 + i)
                            .Left = 76 * i + 14
                            .Top = 145 * j + 50
                            .ShowNum = j * 12 + i + 1
                            .Parent = TabControl1.TabPages(k)
                            .Enabled = True
                        End With
                        ShowList(k).Add(sshow(j * 12 + i))
                    Next
                Next
            Else                        '2、4位器件
                Dim sshow(23) As FourShow
                For j = 0 To 3
                    For i = 0 To 5
                        sshow(j * 6 + i) = New FourShow
                        With sshow(j * 6 + i)
                            .Left = 150 * i + 22
                            .Top = 145 * j + 50
                            .ShowNum = j * 6 + i + 1
                            .Parent = TabControl1.TabPages(k)
                            .Enabled = True
                        End With
                        ShowList(k).Add(sshow(j * 6 + i))
                    Next
                Next
            End If
            TabControl1.TabPages(k).BackColor = Color.FromArgb(204, 232, 207)
            TabControl1.TabPages(k).Show()
        Next
    End Sub '画界面

    Private Sub ThreadInit()
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
        'frm.unitNo = 0
        'frm.Show()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _DBconn.Close()
        CommThread.Abort()
        RS485.Close()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '------遮挡
        Dim fs As New frmRoot
        'fs.BackColor = Color.FromArgb(204, 232, 207)
        fs.Show()
        fs.Label1.Text = "加载数据..."
        fs.Refresh()

        '------设置串口
        RS485.WriteBufferSize = 2048
        RS485.ReadTimeout = 200
        RS485.ReceivedBytesThreshold = 3
        RS485.RtsEnable = True
        'try
        '    rs485.open()
        'catch ex as exception
        '    msgbox("请检查串口连接后再打开程序！")
        '    me.close()
        'end try

        '------打开数据库，初始化单元对象
        _DBconn.Open()
        For i = 0 To 23
            _unit(i) = New LHUnit
        Next
        DBMethord.Initial(_DBconn, _unit)

        '------查询区初始化
        Dim dbcmd As New OleDbCommand
        dbCmd.Connection = _DBconn
        dbCmd.CommandText = "select distinct 试验编号 from 试验结果"

        Dim reader As OleDbDataReader
        reader = dbCmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read
                cmbTestNo.Items.Add(reader("试验编号"))
            End While
        End If
        reader.Close()

        PaintShow()     '绘制界面
        ThreadInit()    '线程初始化
        OneSec.Enabled = True
        OneMin.Enabled = True
        ShowUnitInfo(0)

        '单元操作区初始化
        InitOperationZone()
        lblStartup.Parent = Me

        fs.Close()


    End Sub

    Public Sub PollingShow1(ByVal volt As Single, ByVal power As Single, _
                           ByVal unitnum As Byte, ByVal cellnum As Byte, ByVal over As Boolean)
        ShowList(unitnum - 1).Item(cellnum - 1).setResult(volt, power, over)
    End Sub '更新实时数据显示1位

    Public Sub PollingShow4(ByVal volt As Single, ByVal power As Single, _
                           ByVal unitnum As Byte, ByVal cellnum As Byte, ByVal cellpos As Byte, ByVal over As Boolean)
        ShowList(unitnum - 1).Item(cellnum - 1).setResult(volt, power, cellpos, over)
    End Sub '更新实时数据显示4位

    Private Sub OneSec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneSec.Tick
        Static i As Byte = 0
        If frmInt.Visible = True Then frmInt.Close()
        If Now.Minute >= 1 And Now.Minute <= 58 Then
            Dim j As Byte = 0
            While _unit(i).Testing <> 0
                i = (i + 1) Mod 24
                j += 1
                If j >= 24 Then Exit Sub
            End While
            _commFlag.unitNo_polling = i
            _commFlag.polling = True
            i = (i + 1) Mod 24
        End If
        ShowUnitInfo(TabControl1.SelectedIndex)
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
            If (Date.Compare(Now.Date, _lastRecallTime.Date) = 0) And _
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

    Private Sub PollingTask(ByVal unitNo As Byte)   '轮询任务
        For i = 0 To 2      '如果没有收到回复，重复发送三遍
            DownloadCmd.Polling(RS485, _unit(unitNo))
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 210)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = &H3 Then
                ReplyPolling()
                Exit For
            End If
        Next
    End Sub

    Private Sub StartupTask(ByVal unitNo As Byte)   '启动任务
        Dim i As Byte
        For i = 0 To 2
            DownloadCmd.Distribute(RS485, _unit(unitNo))
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 260)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdNotSame Then
                MsgBox("器件类型与老化单元不符，请检查后重新启动！")
                Exit Sub
            End If
            If cmdBack = LHSerialPort.cmdDistribute Then  '应该分340继续和正常启动两种情况
                DownloadCmd.Startup(RS485, _unit(unitNo))
                Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
                Thread.Sleep(300 + 120)
                Dim cmd As Byte = RS485.ReadUp(_readBuffer)
                If cmdBack <> &HFF Then
                    Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
                End If
                If cmd = LHSerialPort.cmdStartup Then
                    If _unit(unitNo).Testing = &HC Then
                        _unit(unitNo).Testing = 0
                        DBMethord.Update340(unitNo)
                    Else
                        With _unit(unitNo)
                            .Testing = &H0
                            .lastHour = Now.AddHours(-1)
                        End With
                        DBMethord.UpdateTest(unitNo)
                        Exit Sub
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub DistributeTask(ByVal unitNo As Byte)
        For i = 0 To 2
            DownloadCmd.Distribute(RS485, _unit(unitNo))
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 260)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdDistribute Then Exit For
        Next
    End Sub

    Private Sub IntegralTask()
        '招记录信息
        _lastRecallTime = Now
        Dim nowtime As Date = Now.Date
        Dim lastdate As Date = nowtime
        Dim thisdate As Date = nowtime
        Dim lastrecord(2) As Byte
        Dim thisrecord(2) As Byte
        Dim i As Byte
        For k = 0 To 23
            For i = 0 To 2
                DownloadCmd.Record(RS485, _unit(k))
                Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
                Thread.Sleep(300 + 260)
                Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
                If cmdBack <> &HFF Then
                    Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
                End If
                If cmdBack = LHSerialPort.cmdRecord Then
                    If _readBuffer(5) = 0 And _readBuffer(6) = 0 And _readBuffer(7) = 0 Then
                        lastdate = #1/1/2000#
                    Else
                        lastdate = lastdate.AddDays(DownloadCmd.BCD2Num(_readBuffer(5)) - lastdate.Day)
                        lastdate = lastdate.AddMonths(DownloadCmd.BCD2Num(_readBuffer(6)) - lastdate.Month)
                        lastdate = lastdate.AddYears(DownloadCmd.BCD2Num(_readBuffer(7)) - lastdate.Year + 2000)
                    End If
                    If _readBuffer(8) = 0 And _readBuffer(9) = 0 And _readBuffer(10) = 0 Then
                        thisdate = #1/1/2000#
                    Else
                        thisdate = thisdate.AddDays(DownloadCmd.BCD2Num(_readBuffer(8)) - thisdate.Day)
                        thisdate = thisdate.AddMonths(DownloadCmd.BCD2Num(_readBuffer(9)) - thisdate.Month)
                        thisdate = thisdate.AddYears(DownloadCmd.BCD2Num(_readBuffer(10)) - thisdate.Year + 2000)
                    End If
                    lastrecord(0) = _readBuffer(11)
                    lastrecord(1) = _readBuffer(12)
                    lastrecord(2) = _readBuffer(13)
                    thisrecord(0) = _readBuffer(14)
                    thisrecord(1) = _readBuffer(15)
                    thisrecord(2) = _readBuffer(16)
                    Exit For
                End If
            Next
            If i > 2 Then Continue For

            '上一日记录召回
            Select Case Date.Compare(_unit(k).lastHour.Date, lastdate.Date)
                Case 0          '上次记录日期等于上一日日期，从上次记录时间开始往后召回
                    For i = _unit(k).lastHour.Hour + 1 To 23
                        If Now.Minute >= 58 Then
                            _commFlag.integral = False
                            DBMethord.UpdateRecallTime()
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneSec, True)
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneMin, True)
                            Exit Sub
                        End If
                        If ((lastrecord(i \ 8) >> (i Mod 8)) And 1) = 0 Then    '数据无效，跳过
                            _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                            Continue For
                        End If
                        _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                        IntegralPerHour(k)
                        DBMethord.UpdateHour(k, _unit(k).lastHour)
                    Next
                Case -1         '上次记录日期小于上一日日期，召回整个上一日有效记录
                    _unit(k).lastHour = lastdate.AddHours(-1)
                    For i = 0 To 23
                        If Now.Minute >= 58 Then
                            _commFlag.integral = False
                            DBMethord.UpdateRecallTime()
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneSec, True)
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneMin, True)
                            Exit Sub
                        End If
                        If ((lastrecord(i \ 8) >> (i Mod 8)) And 1) = 0 Then    '数据无效，跳过
                            _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                            Continue For
                        End If
                        _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                        IntegralPerHour(k)
                        DBMethord.UpdateHour(k, _unit(k).lastHour)
                    Next
            End Select

            '当日记录召回
            Select Case Date.Compare(_unit(k).lastHour.Date, thisdate.Date)
                Case 0          '上次记录日期等于当日日期，从上次记录时间开始往后召回
                    For i = _unit(k).lastHour.Hour + 1 To Now.Hour
                        If Now.Minute >= 58 Then
                            _commFlag.integral = False
                            DBMethord.UpdateRecallTime()
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneSec, True)
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneMin, True)
                            Exit Sub
                        End If
                        If ((thisrecord(i \ 8) >> (i Mod 8)) And 1) = 0 Then    '数据无效，跳过
                            _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                            Continue For
                        End If
                        _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                        IntegralPerHour(k)
                        DBMethord.UpdateHour(k, _unit(k).lastHour)
                    Next
                Case -1         '上次记录日期小于上一日日期，召回整个当日有效记录
                    _unit(k).lastHour = thisdate.AddHours(-1)
                    For i = 0 To 23
                        If Now.Minute >= 58 Then
                            _commFlag.integral = False
                            DBMethord.UpdateRecallTime()
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneSec, True)
                            Me.Invoke(New ToolControl(AddressOf mToolControl), OneMin, True)
                            Exit Sub
                        End If
                        If ((thisrecord(i \ 8) >> (i Mod 8)) And 1) = 0 Then    '数据无效，跳过
                            _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                            Continue For
                        End If
                        _unit(k).lastHour = _unit(k).lastHour.AddHours(1)
                        IntegralPerHour(k)
                        DBMethord.UpdateHour(k, _unit(k).lastHour)
                    Next
            End Select
        Next k

        _commFlag.integral = False
        DBMethord.UpdateRecallTime()
        Me.Invoke(New ToolControl(AddressOf mToolControl), OneSec, True)
        Me.Invoke(New ToolControl(AddressOf mToolControl), OneMin, True)

    End Sub

    Private Sub TimeModifyTask()
        DownloadCmd.TimeModify(RS485)
        Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
    End Sub

    Private Sub RebootTask(ByVal unitNo As Byte)
        Dim i As Byte
        For i = 0 To 2
            DownloadCmd.Distribute(RS485, _unit(unitNo))
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 260)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdNotSame Then
                MsgBox("器件类型与老化单元不符，请检查后重新启动！")
                Exit Sub
            End If
            If cmdBack = LHSerialPort.cmdDistribute Then
                DownloadCmd.Reboot(RS485, _unit(unitNo))
                Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
                Thread.Sleep(300 + 120)
                Dim cmd As Byte = RS485.ReadUp(_readBuffer)
                If cmdBack <> &HFF Then
                    Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
                End If
                If cmd = LHSerialPort.cmdReboot Then
                    With _unit(unitNo)
                        .Testing = &H0
                        .lastHour = Now.AddHours(-1)
                    End With
                    MsgBox("强制重启成功！")
                    DBMethord.UpdateTest(unitNo)
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub Reboot340Task(ByVal unitNo As Byte)
        Dim i As Byte
        For i = 0 To 2
            DownloadCmd.Distribute(RS485, _unit(unitNo))
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 260)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdNotSame Then
                MsgBox("器件类型与老化单元不符，请检查后重新启动！")
                Exit Sub
            End If
            If cmdBack = LHSerialPort.cmdDistribute Then
                DownloadCmd.Reboot340(RS485, _unit(unitNo))
                Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
                Thread.Sleep(300 + 120)
                Dim cmd As Byte = RS485.ReadUp(_readBuffer)
                If cmdBack <> &HFF Then
                    Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
                End If
                If cmd = LHSerialPort.cmdReboot340 Then
                    With _unit(unitNo)
                        .Testing = &H0
                        .lastHour = Now.AddHours(-1)
                    End With
                    MsgBox("放弃340小时后试验并重启成功！")
                    '还未写回数据库
                    DBMethord.UpdateTest(unitNo)
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub IntegralPerHour(ByVal unitNo As Byte)
        For i = 0 To 2
            DownloadCmd.Integral(RS485, _unit(unitNo), 0, _unit(unitNo).lastHour.Hour)
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 320)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdIntegral Then
                ReplyIntegral()
                Exit For
            End If
        Next
        For i = 0 To 2
            DownloadCmd.Integral(RS485, _unit(unitNo), 1, _unit(unitNo).lastHour.Hour)
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 320)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdIntegral Then
                ReplyIntegral()
                Exit For
            End If
        Next

        For i = 0 To 2
            DownloadCmd.Integral(RS485, _unit(unitNo), 2, _unit(unitNo).lastHour.Hour)
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 320)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdIntegral Then
                ReplyIntegral()
                Exit For
            End If
        Next
        For i = 0 To 2
            DownloadCmd.Integral(RS485, _unit(unitNo), 3, _unit(unitNo).lastHour.Hour)
            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
            Thread.Sleep(300 + 320)
            Dim cmdBack As Byte = RS485.ReadUp(_readBuffer)
            If cmdBack <> &HFF Then
                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
            End If
            If cmdBack = LHSerialPort.cmdIntegral Then
                ReplyIntegral()
                Exit For
            End If
        Next
    End Sub

    Private Sub ReplyPolling()
        Dim datalen As Byte = _readBuffer(1)
        Dim address As Byte = _readBuffer(3)
        Dim Data(datalen - 3) As Byte
        For j = 0 To datalen - 3
            Data(j) = _readBuffer(j + 5)
        Next

        Dim status As Byte = Data(0)        '读取状态
        Dim i As Byte                       '循环变量
        Select Case status
            Case &H0    '正常
                Dim type As Byte = (Data(10) >> 4)  '读取器件位数
                Dim v_plus As Byte = Data(2)        '实测电压偏移量
                Dim pos As Byte = Data(1)           '老化位
                Dim volt As Single                  '实际电压
                Dim power As Single                 '实际功率
                Select Case (Data(10) And &H3)
                    Case 0
                        volt = (v_plus * 1175 + 387200) / 25600
                        power = 75 * volt / 21
                    Case 1
                        volt = (v_plus * 1375 + 464000) / 25600
                        power = 75 * volt / 25
                    Case 2
                        volt = (v_plus * 1525 + 521600) / 25600
                        power = 75 * volt / 28
                    Case 3 '还不对
                        volt = (v_plus * 1525 + 521600) / 25600
                        power = 75 * volt / 28
                End Select

                For i = 0 To 23
                    If _unit(i).address = address Then Exit For
                Next

                If type = 0 Then    '1位器件的显示
                    'PollingShow(v, v * mA, i + 1, pos)
                    If v_plus > _unit(i).上限 Or v_plus < _unit(i).下限 Then
                        Me.Invoke(New Polling_dg1(AddressOf PollingShow1), _
                                  volt, power, CByte(i + 1), CByte(pos / 2 + 1), True)
                    Else
                        Me.Invoke(New Polling_dg1(AddressOf PollingShow1), _
                                  volt, power, CByte(i + 1), CByte(pos / 2 + 1), False)
                    End If
                Else
                    'PollingShow(v, v * mA, i + 1, (pos - 1) \ 4 + 1, (pos - 1) Mod 4)
                    If v_plus > _unit(i).上限 Or v_plus < _unit(i).下限 Then
                        Me.Invoke(New Polling_dg4(AddressOf PollingShow4), _
                                 volt, power, CByte(i + 1), CByte((pos) \ 4 + 1), CByte((pos) Mod 4), True)
                    Else
                        Me.Invoke(New Polling_dg4(AddressOf PollingShow4), _
                                 volt, power, CByte(i + 1), CByte((pos) \ 4 + 1), CByte((pos) Mod 4), False)
                    End If
                End If
            Case &H3    '请求参数
                For i = 0 To 23
                    If _unit(i).address = address Then
                        DistributeTask(i)
                        Exit For
                    End If
                Next
            Case &HC    '340暂停
                For i = 0 To 23
                    If _unit(i).address = address Then
                        _unit(i).Testing = &HC
                        DBMethord.UpdateStates(i, _unit(i).Testing)
                        Exit For
                    End If
                Next
            Case &H30   '1000停止
                For i = 0 To 23
                    If _unit(i).address = address Then
                        _unit(i).Testing = &H30
                        DBMethord.UpdateStates(i, _unit(i).Testing)
                        Exit For
                    End If
                Next
        End Select
    End Sub

    Private Sub ReplyIntegral()
        Dim datalen As Byte = _readBuffer(1)
        Dim address As Byte = _readBuffer(3)
        Dim Data(datalen - 3) As Byte
        For j = 0 To datalen - 3
            Data(j) = _readBuffer(j + 5)
        Next

        Dim i As Byte
        For i = 0 To 23
            If address = _unit(i).address Then Exit For
        Next

        Dim part As Byte = Data(0) >> 6
        Dim hour As Byte = Data(0) And &H1F
        Dim time = _unit(i).lastHour

        If _unit(i).器件类型 = 0 Then       '1位器件的数据压入
            For k = 0 To 23
                If _unit(i).对位表(k + part * 24) Then
                    Dim volt As Single, power As Single
                    Select Case _unit(i).电压规格
                        Case 21
                            volt = (Data(k + 1) * 1175 + 387200) / 25600
                            power = 75 * volt / 21
                        Case 25
                            volt = (Data(k + 1) * 1375 + 464000) / 25600
                            power = 75 * volt / 25
                        Case 28
                            volt = (Data(k + 1) * 1525 + 521600) / 25600
                            power = 75 * volt / 28
                        Case 16 '还不对
                            volt = (Data(k + 1) * 1525 + 521600) / 25600
                            power = 75 * volt / 28
                    End Select

                    DBMethord.WriteResult(_unit(i).试验编号, _unit(i).对位表(k + part * 24), _
                                          CByte(1), time, volt)
                End If
            Next
        End If

        If _unit(i).器件类型 = 1 Then       '2位器件的数据压入
            Dim isFirst As Boolean = True
            For k = 0 To 23
                If _unit(i).对位表(k + part * 24) Then
                    Dim volt As Single, power As Single
                    Select Case _unit(i).电压规格
                        Case 21
                            volt = (Data(k + 1) * 1175 + 387200) / 25600
                            power = 75 * volt / 21
                        Case 25
                            volt = (Data(k + 1) * 1375 + 464000) / 25600
                            power = 75 * volt / 25
                        Case 28
                            volt = (Data(k + 1) * 1525 + 521600) / 25600
                            power = 75 * volt / 28
                    End Select

                    Dim subnum As Byte
                    If isFirst Then
                        subnum = 1
                    Else
                        subnum = 2
                    End If
                    DBMethord.WriteResult(_unit(i).试验编号, _unit(i).对位表(k + part * 24), _
                                          subnum, time, volt)
                    isFirst = Not isFirst
                End If
            Next
        End If

        If _unit(i).器件类型 = 2 Then       '4位器件的数据压入
            For k = 0 To 23
                If _unit(i).对位表(k + part * 24) Then
                    Dim volt As Single, power As Single
                    Select Case _unit(i).电压规格
                        Case 21
                            volt = (Data(k + 1) * 1175 + 387200) / 25600
                            power = 75 * volt / 21
                        Case 25
                            volt = (Data(k + 1) * 1375 + 464000) / 25600
                            power = 75 * volt / 25
                        Case 28
                            volt = (Data(k + 1) * 1525 + 521600) / 25600
                            power = 75 * volt / 28
                    End Select

                    DBMethord.WriteResult(_unit(i).试验编号, _unit(i).对位表(k + part * 24), _
                                          CByte((k + part * 24) Mod 4 + 1), time, volt)
                End If
            Next
        End If
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

    Private Sub TextSend_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSend.TextChanged
        txtSend.SelectionStart = txtSend.TextLength
        txtSend.ScrollToCaret()
    End Sub

    Private Sub TextRecv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecv.TextChanged
        txtRecv.SelectionStart = txtRecv.TextLength
        txtRecv.ScrollToCaret()
    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        ShowUnitInfo(TabControl1.SelectedIndex)
    End Sub

    Private Sub ShowUnitInfo(ByVal unitNo As Byte)
        lbl单元编号.Text = unitNo + 1

        With _unit(unitNo)
            lbl标准号.Text = .标准号
            lbl操作员.Text = .操作员
            lbl例试编号.Text = .试验编号
            lbl生产批号.Text = .生产批号
            lbl电压规格.Text = .电压规格 & " V"
            lbl产品型号.Text = .产品型号

            Select Case .电压规格
                Case 21
                    lblUp.Text = Format((.上限 * 1175 + 387200) / 25600, "0.0") & " V"
                    lblDown.Text = Format((.下限 * 1175 + 387200) / 25600, "0.0") & " V"
                Case 25
                    lblUp.Text = Format((.上限 * 1375 + 464000) / 25600, "0.0") & " V"
                    lblDown.Text = Format((.下限 * 1375 + 464000) / 25600, "0.0") & " V"
                Case 28
                    lblUp.Text = Format((.上限 * 1525 + 521600) / 25600, "0.0") & " V"
                    lblDown.Text = Format((.下限 * 1525 + 521600) / 25600, "0.0") & " V"
                Case 16  '还不对
                    lblUp.Text = Format((.上限 * 1525 + 521600) / 25600, "0.0") & " V"
                    lblDown.Text = Format((.下限 * 1525 + 521600) / 25600, "0.0") & " V"
            End Select
            If .座子类型 = 0 Then
                lbl座子类型.Text = "一 位"
            Else
                lbl座子类型.Text = "四 位"
            End If

            If .器件类型 = 0 Then
                lbl器件类型.Text = "一 位"
            ElseIf .器件类型 = 1 Then
                lbl器件类型.Text = "二 位"
            ElseIf .器件类型 = 2 Then
                lbl器件类型.Text = "四 位"
            End If

            Select Case .Testing
                Case 0
                    SwitchLight.TurnOnOff(True)
                    lblstatus.Text = ""
                    lblstatus.ForeColor = Color.Black
                    btnResume.Visible = False
                Case 3
                    SwitchLight.TurnOnOff(False)
                    lblstatus.Text = "缺参数"
                    lblstatus.ForeColor = Color.Red
                    btnResume.Visible = False
                Case &HC
                    SwitchLight.TurnOnOff(False)
                    lblstatus.Text = "340"
                    lblstatus.ForeColor = Color.Red
                    btnResume.Visible = True
                Case &H30
                    SwitchLight.TurnOnOff(False)
                    lblstatus.Text = "1000"
                    lblstatus.ForeColor = Color.Black
                    btnResume.Visible = False
            End Select
        End With
    End Sub

    Private Sub btnResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResume.Click
        Dim unitNo As Byte = lbl单元编号.Text - 1
        Dim frm As New frm340
        frm340.unitNo = unitNo
        frm340.ShowDialog()
    End Sub

    '--------------------------------------
    '单元操作区的操作逻辑放在此处

    Private Sub btn启动试验_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn启动试验.Click
        grp操作.Enabled = True

        Panel1.Enabled = True
        Panel2.Enabled = False
        Panel3.Enabled = False
        Panel4.Enabled = False

        Panel1.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Panel2.BorderStyle = Windows.Forms.BorderStyle.None
        Panel3.BorderStyle = Windows.Forms.BorderStyle.None
        Panel4.BorderStyle = Windows.Forms.BorderStyle.None

        txtUser.Focus()
    End Sub

    Private Sub btnLogOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogOK.Click
        Dim dbcmd As New OleDbCommand
        Dim reader As OleDbDataReader
        dbcmd.Connection = _DBconn
        dbcmd.CommandText = "select 密码 from 操作员 where 姓名 = '" & txtUser.Text & "'"
        reader = dbcmd.ExecuteReader
        If Not reader.HasRows Then
            MsgBox("姓名错误！")
            txtUser.Text = ""
            txtPwd.Text = ""
            txtUser.Focus()
        Else
            reader.Read()
            If reader("密码") = txtPwd.Text Then
                unitTemp.操作员 = txtUser.Text
                Panel2.Enabled = True
                panel2.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            Else
                MsgBox("密码错误！")
                txtUser.Text = ""
                txtPwd.Text = ""
                txtUser.Focus()
            End If
        End If
    End Sub

    Private Sub cmbUnitNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUnitNo.SelectedIndexChanged
        If cmbUnitNo.SelectedIndex = -1 Then Exit Sub
        Dim unitNo As Byte = cmbUnitNo.SelectedIndex
        If _unit(unitNo).座子类型 Then
            lblWeishu.Text = "四 位"
        Else
            lblWeishu.Text = "一 位"
        End If

        lblVolt.Text = _unit(unitNo).电压规格 & " V"
        txtMax.Text = _unit(unitNo).电压规格 + 1
        txtMin.Text = _unit(unitNo).电压规格 - 1

        Panel3.Enabled = True
        Panel3.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        lblPos.Text = "点此插放器件"
        lblPos.ForeColor = Color.Red
        If cmbType.SelectedIndex = -1 Then Exit Sub
        If cmbType.SelectedIndex <= 3 Then
            lblChipWeishu.Text = "一 位"
        Else
            lblChipWeishu.Text = "四 位"
        End If
    End Sub

    Private Sub lblPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPos.Click
        If lblChipWeishu.Text = "- 位" Then
            MsgBox("请先选择器件！")
            Exit Sub
        End If
        If lblPos.Text = "器件插放完成" Then
            lblPos.Text = "点此插放器件"
            lblPos.ForeColor = Color.Red
        End If
        If lblWeishu.Text = "四 位" And lblChipWeishu.Text = "二 位" Then '四位插双位
            frmPosChart2.Show()
        End If
        If lblWeishu.Text = "四 位" And lblChipWeishu.Text = "四 位" Then '四位插四位
            frmPosChart4.Show()
        End If
        If lblWeishu.Text = "一 位" And lblChipWeishu.Text = "一 位" Then '一位插一位
            frmPosChart1.Show()
        End If
    End Sub

    Private Sub InitOperationZone()
        txtUser.Text = ""
        txtPwd.Text = ""
        Panel1.BorderStyle = Windows.Forms.BorderStyle.None
        Panel1.Enabled = False

        cmbUnitNo.SelectedIndex = -1
        lblVolt.Text = "- V"
        lblWeishu.Text = "- 位"
        Panel2.BorderStyle = Windows.Forms.BorderStyle.None
        Panel2.Enabled = False

        cmbType.SelectedIndex = -1
        lblChipWeishu.Text = "- V"
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

        grp操作.Enabled = False
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
            Case "21 V" : Return CByte((limit * 25600 - 387200) / 1175)
            Case "25 V" : Return CByte((limit * 25600 - 464000) / 1375)
            Case "28 V" : Return CByte((limit * 25600 - 521600) / 1525)
            Case "16 V" : Return CByte((limit * 25600 - 521600) / 1525) '还不对
        End Select
    End Function

    Private Sub btnStartOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartOK.Click
        Dim pos(95) As Byte, 操作员 As String
        pos = unitTemp.对位表
        操作员 = unitTemp.操作员
        unitTemp = _unit(cmbUnitNo.SelectedIndex)
        With unitTemp
            .操作员 = 操作员
            .对位表 = pos
            .试验编号 = txt试验编号.Text
            .产品型号 = cmbType.SelectedItem
            .质量等级 = txt质量等级.Text
            .标准号 = txt标准号.Text
            .生产批号 = txt生产批号.Text
            .上限 = float2byte(lblVolt.Text, txtMax.Text)
            .下限 = float2byte(lblVolt.Text, txtMin.Text)
            .开机日期 = Now.Date
            Select Case lblChipWeishu.Text
                Case "一 位" : .器件类型 = 0
                Case "二 位" : .器件类型 = 1
                Case "四 位" : .器件类型 = 2
            End Select
        End With

        _unit(cmbUnitNo.SelectedIndex) = unitTemp

        _commFlag.unitNo_start = cmbUnitNo.SelectedIndex
        Select Case _unit(cmbUnitNo.SelectedIndex).Testing
            Case &H0 : _commFlag.reboot = True
            Case &H3 : _commFlag.startup = True
            Case &HC : _commFlag.reboot340 = True
            Case &H30 : _commFlag.startup = True
        End Select

        InitOperationZone()
    End Sub
    '--------------------------------------

    '--------------------------------------
    '-----------搜索区
    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        Dim dbCmd As New OleDbCommand
        dbCmd.Connection = _DBconn
        dbCmd.CommandText = "select 记录日期 from 试验结果 where 试验编号 = '" & cmbTestNo.SelectedItem & "' order by 记录日期"
        Dim reader As OleDbDataReader
        reader = dbCmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            lblTime.Text = reader("记录日期")
        End If

        Dim adapt As New OleDbDataAdapter _
            ("select 器件编号, 管芯号, 电压 from 试验结果 where 试验编号 = '" & cmbTestNo.SelectedItem & "'", _DBconn)
        Dim userDS As New DataSet
        adapt.Fill(userDS, "Table")

        DataGridView1.DataSource = userDS
        DataGridView1.DataMember = "Table"
    End Sub


    '--------------------------------------
    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click
        frmLogin.ShowDialog()
    End Sub

End Class
