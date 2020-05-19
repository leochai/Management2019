Public Class DownloadCmd
    Shared lock As New Object

    Public Shared Sub Polling(ByVal com As LHSerialPort, ByVal unit As LHUnit)
        '轮询命令
        SyncLock lock
            com.WriteOrdinary(unit.address)
        End SyncLock
    End Sub

    Public Shared Sub Integral(ByVal com As LHSerialPort, ByVal unit As LHUnit, _
                               ByVal part As Byte, ByVal time As Byte)
        '整点召回
        SyncLock lock
            com.WriteIntegral(unit.address, part, time)
        End SyncLock
    End Sub

    Public Shared Sub Distribute(ByVal com As LHSerialPort, ByVal unit As LHUnit)
        '参数下发
        SyncLock lock
            Dim param As New prmDistribute
            If unit.电压流标记 Then
                '电流型单元
                param.type = (unit.电压流规格 << 6) + (&H3 << 4) + 7
            Else
                '电压型单元
                param.type = (unit.器件类型 << 4) + unit.电压流规格
            End If
            param.max = unit.上限
            param.mini = unit.下限
            param.hour = Num2BCD(Now.Hour)
            param.minute = Num2BCD(Now.Minute)
            param.second = Num2BCD(Now.Second)
            param.week = Num2BCD(Now.DayOfWeek)
            If param.week = 0 Then param.week = 7
            param.day = Num2BCD(Now.Day)
            param.month = Num2BCD(Now.Month)
            param.year = Num2BCD(Now.Year - 2000)
            For i = 0 To 11
                For j = 0 To 7
                    If unit.对位表(i * 8 + j) <> 0 Then
                        param.pos(i) += &H1 << j
                    End If
                Next
            Next
            com.WriteDistribute(unit.address, param)
        End SyncLock
    End Sub

    Public Shared Sub Startup(ByVal com As LHSerialPort, ByVal unit As LHUnit)
        '启动单元
        SyncLock lock
            com.WriteStartup(unit.address)
        End SyncLock
    End Sub

    Public Shared Sub Reboot340(ByVal com As LHSerialPort, ByVal unit As LHUnit)
        '340状态重启单元
        SyncLock lock
            com.WriteReboot340(unit.address)
        End SyncLock
    End Sub

    Public Shared Sub Reboot(ByVal com As LHSerialPort, ByVal unit As LHUnit)
        '强制重启单元
        SyncLock lock
            com.WriteReboot(unit.address)
        End SyncLock
    End Sub

    Public Shared Sub TimeModify(ByVal com As LHSerialPort)
        '对时
        Dim hour As Byte = Num2BCD(Now.Hour)
        Dim minute As Byte = Num2BCD(Now.Minute)
        dim second As Byte = Num2BCD(now.Second)
        SyncLock lock
            com.WriteTimeModify(&H3F, second, minute, hour)
        End SyncLock
    End Sub

    Public Shared Sub LHTimeModify(ByVal com As LHSerialPort, ByVal unit As LHUnit, _
                                 ByVal second As Byte, ByVal minute As Byte, ByVal hour As Integer)

        '老化时间对时
        Dim lhour As Byte = hour Mod 256
        Dim hhour As Byte = hour \ 256
        Dim second1 As Byte = Num2BCD(second)
        Dim minute1 As Byte = Num2BCD(minute)

        SyncLock lock
            com.WriteLHTimeModify(unit.address, second1, minute1, lhour, hhour)
        End SyncLock
    End Sub

    Public Shared Sub Record(ByVal com As LHSerialPort, ByVal unit As LHUnit)
        '招记录信息
        SyncLock lock
            com.WriteRecord(unit.address)
        End SyncLock
    End Sub

    Public Shared Function Num2BCD(ByVal num As Byte) As Byte
        '数字转换为8421BCD码
        Return (num Mod 10) + ((num \ 10) << 4)
    End Function

    Public Shared Function BCD2Num(ByVal bcd As Byte) As Byte
        '8421BCD码转换为数字
        Return (bcd And &HF) + ((bcd >> 4) * 10)
    End Function
End Class
