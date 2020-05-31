Imports System.Threading

Partial Public Class frmMain
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
                'Dim type As Byte = (Data(10) >> 4)  '读取器件位数
                'Dim v_plus As Byte = Data(2)        '实测电压偏移量
                'Dim pos As Byte = Data(1)           '老化位
                'Dim volt As Single                  '实际电压
                'Dim power As Single                 '实际功率
                'Select Case (Data(10) And &H3)
                '    Case 0
                '        volt = (v_plus * 1175 + 387200) / 25600
                '        power = 75 * volt / 21
                '    Case 1
                '        volt = (v_plus * 1375 + 464000) / 25600
                '        power = 75 * volt / 25
                '    Case 2
                '        volt = (v_plus * 1525 + 521600) / 25600
                '        power = 75 * volt / 28
                '    Case 3 '还不对
                '        volt = (v_plus * 1525 + 521600) / 25600
                '        power = 75 * volt / 28
                'End Select

                'For i = 0 To 31
                '    If _unit(i).address = address Then Exit For
                'Next

            Case &H3    '请求参数
                For i = 0 To 31
                    If _unit(i).address = address Then
                        DistributeTask(i)
                        Exit For
                    End If
                Next
            Case &HC    '340暂停
                For i = 0 To 31
                    If _unit(i).address = address Then
                        _unit(i).Testing = &HC
                        DBMethord.UpdateStates(i, _unit(i).Testing)
                        Me.Invoke(New RefreshShow(AddressOf mRefreshShow), i)
                        Exit For
                    End If
                Next
            Case &H30   '1000停止
                For i = 0 To 31
                    If _unit(i).address = address Then
                        _unit(i).Testing = &H30
                        DBMethord.UpdateStates(i, _unit(i).Testing)
                        Me.Invoke(New RefreshShow(AddressOf mRefreshShow), i)
                        Exit For
                    End If
                Next
        End Select
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
                MsgBox("器件类型与老化单元不符，请检查后重新启动！",, "提醒")
                Exit Sub
            End If
            If cmdBack = LHSerialPort.cmdDistribute Then  '应该分340继续和正常启动两种情况
                DownloadCmd.Startup(RS485, _unit(unitNo))
                Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
                Thread.Sleep(300 + 120)
                Dim cmd As Byte = RS485.ReadUp(_readBuffer)
                If cmd <> &HFF Then
                    Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
                End If
                If cmd = LHSerialPort.cmdStartup Then
                    If _unit(unitNo).Testing = &HC Then '340继续
                        _unit(unitNo).Testing = 0
                        DBMethord.Update340(unitNo)
                        Me.Invoke(New RefreshShow(AddressOf mRefreshShow), unitNo)
                        Exit For
                    Else                                '1000启动
                        With _unit(unitNo)
                            .Testing = &H0
                            .lastHour = Now.AddHours(-1)
                        End With
                        If _commFlag.test660 Then
                            DownloadCmd.LHTimeModify(RS485, _unit(unitNo), 10, 0, 340)
                            Me.Invoke(New TextCallback(AddressOf showbyte), txtSend, RS485.outputbuffer, RS485.outputlength)
                            Thread.Sleep(300 + 120)
                            Dim cmd1 As Byte = RS485.ReadUp(_readBuffer)
                            If cmd1 <> &HFF Then
                                Me.Invoke(New TextCallback(AddressOf showbyte), txtRecv, _readBuffer, CByte(_readBuffer(1) + 5))
                            End If
                            If cmd1 = LHSerialPort.cmdLHTimeModify Then
                                _commFlag.test660 = False
                            End If
                        End If
                        DBMethord.UpdateTest(unitNo)
                        Me.Invoke(New RefreshShow(AddressOf mRefreshShow), unitNo)
                        Exit For
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
        For k = 0 To 31
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

    Private Sub ReplyIntegral()
        Dim datalen As Byte = _readBuffer(1)
        Dim address As Byte = _readBuffer(3)
        Dim Data(datalen - 3) As Byte
        For j = 0 To datalen - 3
            Data(j) = _readBuffer(j + 5)
        Next

        Dim i As Byte
        For i = 0 To 31
            If address = _unit(i).address Then Exit For
        Next

        Dim part As Byte = Data(0) >> 6
        Dim hour As Byte = Data(0) And &H1F
        'Dim time = _unit(i).lastHour

        For k = 0 To 23
            If _unit(i).对位表(k + part * 24) Then
                Dim AD As Byte = Data(k + 1)
                Dim AD1 As Byte = 0
                If i >= 16 And i <= 23 Then
                    AD1 = Data(k + 2)
                End If
                Dim pos As Byte = k + part * 24
                DBMethord.WriteResult(i, pos, AD, AD1)
            End If
        Next

        'If _unit(i).器件类型 = 0 Then       '1位器件的数据压入
        '    For k = 0 To 23
        '        If _unit(i).对位表(k + part * 24) Then
        '            Dim volt As Single, power As Single
        '            Select Case _unit(i).电压规格
        '                Case 21
        '                    volt = (Data(k + 1) * 1175 + 387200) / 25600
        '                    power = 75 * volt / 21
        '                Case 25
        '                    volt = (Data(k + 1) * 1375 + 464000) / 25600
        '                    power = 75 * volt / 25
        '                Case 28
        '                    volt = (Data(k + 1) * 1525 + 521600) / 25600
        '                    power = 75 * volt / 28
        '                Case 16
        '                    volt = (Data(k + 1) * 925 + 291200) / 25600
        '                    power = 75 * volt / 16
        '            End Select
        '            DBMethord.WriteResult(_unit(i).试验编号, _unit(i).对位表(k + part * 24),
        '                              CByte(1), time, volt)
        '        End If
        '    Next
        'End If

        'If _unit(i).器件类型 = 1 Then       '2位器件的数据压入
        '    Dim isFirst As Boolean = True
        '    For k = 0 To 23
        '        If _unit(i).对位表(k + part * 24) Then
        '            Dim volt As Single, power As Single
        '            Select Case _unit(i).电压规格
        '                Case 21
        '                    volt = (Data(k + 1) * 1175 + 387200) / 25600
        '                    power = 75 * volt / 21
        '                Case 25
        '                    volt = (Data(k + 1) * 1375 + 464000) / 25600
        '                    power = 75 * volt / 25
        '                Case 28
        '                    volt = (Data(k + 1) * 1525 + 521600) / 25600
        '                    power = 75 * volt / 28
        '            End Select

        '            Dim subnum As Byte
        '            If isFirst Then
        '                subnum = 1
        '            Else
        '                subnum = 2
        '            End If
        '            DBMethord.WriteResult(_unit(i).试验编号, _unit(i).对位表(k + part * 24),
        '                                  subnum, time, volt)
        '            isFirst = Not isFirst
        '        End If
        '    Next
        'End If

        'If _unit(i).座子类型 = 1 Then       '4位器件的数据压入

        'End If
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
                MsgBox("器件类型与老化单元不符，请检查后重新启动！",, "提醒")
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
                    MsgBox("强制重启成功！",, "提醒")
                    DBMethord.UpdateTest(unitNo)
                    Me.Invoke(New RefreshShow(AddressOf mRefreshShow), unitNo)
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
                MsgBox("器件类型与老化单元不符，请检查后重新启动！",, "提醒")
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
                    MsgBox("放弃340小时后试验并重启成功！",, "提醒")
                    DBMethord.UpdateTest(unitNo)
                    Me.Invoke(New RefreshShow(AddressOf mRefreshShow), unitNo)
                    Exit Sub
                End If
            End If
        Next
    End Sub

End Class