Imports System.Data.OleDb

Public Class DBMethord
    Public Shared Sub Initial(ByRef db As OleDbConnection, ByRef unit() As LHUnit)
        Dim dbcom As New OleDbCommand
        dbcom.Connection = db
        dbcom.CommandText = "select * from 单元状态 left join 试验记录 on 单元状态.试验编号 = 试验记录.试验编号"
        Dim reader As OleDbDataReader = dbcom.ExecuteReader()
        If reader.HasRows Then
            While reader.Read
                With unit(reader("老化单元号") - 1)
                    If Not reader("器件类型") Is DBNull.Value Then
                        .器件类型 = reader("器件类型")
                    End If
                    If Not reader("运行状态") Is DBNull.Value Then
                        .Testing = reader("运行状态")
                    End If
                    If Not reader("单元地址") Is DBNull.Value Then
                        .address = reader("单元地址")
                    End If
                    If Not reader("最近上传时间") Is DBNull.Value Then
                        .lastHour = reader("最近上传时间")
                    End If
                    If Not reader("座子类型") Is DBNull.Value Then
                        .座子类型 = reader("座子类型")
                    End If
                    If Not reader("电压流标记") Is DBNull.Value Then
                        .电压流标记 = reader("电压流标记")
                    End If
                    If Not reader("电压流规格") Is DBNull.Value Then
                        .电压流规格 = reader("电压流规格")
                    End If
                    If Not reader("上限") Is DBNull.Value Then
                        .上限 = reader("上限")
                    End If
                    If Not reader("下限") Is DBNull.Value Then
                        .下限 = reader("下限")
                    End If
                    If Not reader("质量等级") Is DBNull.Value Then
                        .质量等级 = reader("质量等级")
                    End If
                    If Not reader("生产批号") Is DBNull.Value Then
                        .生产批号 = reader("生产批号")
                    End If
                    If Not reader("标准号") Is DBNull.Value Then
                        .标准号 = reader("标准号")
                    End If
                    If Not reader("单元状态.试验编号") Is DBNull.Value Then
                        .试验编号 = reader("单元状态.试验编号")
                    End If
                    If Not reader("产品型号") Is DBNull.Value Then
                        .产品型号 = reader("产品型号")
                    End If
                    If Not reader("开机日期") Is DBNull.Value Then
                        .开机日期 = reader("开机日期")
                    End If
                    If Not reader("结果文件") Is DBNull.Value Then
                        .结果文件 = reader("结果文件")
                    End If
                End With
            End While
        End If
        For i = 0 To 23 '读对位表
            dbcom.CommandText = "select 老化位号,器件编号 from 对位表 where 老化单元号 = " & i + 1
            reader.Close()
            reader = dbcom.ExecuteReader()
            While reader.Read
                unit(i).对位表(reader("老化位号") - 1) = reader("器件编号")
            End While
        Next
        dbcom.CommandText = "select 时间 from 最近召回时间"
        reader.Close()
        reader = dbcom.ExecuteReader
        reader.Read()
        _lastRecallTime = reader("时间")
        reader.Close
    End Sub

    'Public Shared Sub WriteResult(ByVal testnum As String, ByVal chipnum As Byte, ByVal num As Byte, _
    '                              ByVal time As Date, ByVal volt As Single)
    '    Dim cn As New OleDbConnection()
    '    Dim dbcmd As New OleDbCommand
    '    dbcmd.Connection = _DBconn

    '    time = time.AddMinutes(-time.Minute)
    '    time = time.AddSeconds(-time.Second)

    '    
    'End Sub

    Public Shared Sub WriteResult(ByVal unitNo As Byte, ByVal chippos As Byte, ByVal AD As Byte， AD1 As Byte)
        If _unit(unitNo).结果文件 = "" Then Exit Sub

        Dim cn As New OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=" _
            & _unit(unitNo).结果文件 & ";Extended Properties='Excel 8.0'")
        Dim dbcmd As New OleDbCommand
        Dim time As Date
        Dim volt As Double, current As Double, power As Double
        dbcmd.Connection = cn
        time = _unit(unitNo).lastHour
        time = time.AddSeconds(-time.Second)
        time = time.AddMinutes(-time.Minute)


        cn.Open()

        If _unit(unitNo).座子类型 Then '16脚座子，只有21 25 28三种额定电压
            Select Case _unit(unitNo).电压流规格
                Case 0
                    volt = (AD * 1175 + 387200) / 25600
                    power = 75 * volt / 21
                Case 1
                    volt = (AD * 1375 + 464000) / 25600
                    power = 75 * volt / 25
                Case 2
                    volt = (AD * 1525 + 521600) / 25600
                    power = 75 * volt / 28
            End Select
            dbcmd.CommandText = "insert into 试验结果 values(" _
                                    & _unit(unitNo).对位表(chippos) & "," _
                                    & CByte(chippos Mod 4 + 1) & ",#" _
                                    & time & "#," _
                                    & Math.Floor(volt * 100) / 100 & "," _
                                    & Math.Floor(power * 100) / 100 & ")"
        End If

        If _unit(unitNo).器件类型 = 0 And Not _unit(unitNo).电压流标记 Then '单位电压型
            Select Case _unit(unitNo).电压流规格
                Case 0 '21V
                    volt = (AD * 1175 + 387200) / 25600
                    power = 75 * volt / 21
                Case 1 '25V
                    volt = (AD * 1375 + 464000) / 25600
                    power = 75 * volt / 25
                    current = (AD1 * 125 + 48000) / 25600 * 1000 / 62.5 'GHB302
                Case 2 '28V
                    volt = (AD * 1525 + 521600) / 25600
                    power = 75 * volt / 28
                Case 3 '16V GO11
                    volt = (AD * 925 + 291200) / 25600
                    power = 100 * volt / 16
                    current = (AD1 * 125 + 48000) / 2560
                Case 4 '5.5V GH137
                    volt = (AD * 275 + 105600) / 25600
                    power = 75 * volt / 5.5
                    current = (AD1 * 125 + 48000) / 25600 * 1000 / (250 / 3)
            End Select
            If unitNo <= 15 Then 'GH302
                dbcmd.CommandText = "insert into 试验结果 values(" _
                                    & _unit(unitNo).对位表(chippos) & "," _
                                    & CByte(1) & ",#" _
                                    & time & "#," _
                                    & Math.Floor(volt * 100) / 100 & "," _
                                    & Math.Floor(power * 100) / 100 & ")"
            ElseIf unitNo <= 23 Then 'GO11 GHB302 GH137
                dbcmd.CommandText = "insert into 试验结果 values(" _
                                    & _unit(unitNo).对位表(chippos) & "," _
                                    & CByte(1) & ",#" _
                                    & time & "#," _
                                    & Math.Floor(volt * 100) / 100 & "," _
                                    & Math.Floor(power * 100) / 100 & "," _
                                    & Math.Floor(current * 100) / 100 & ")"

            End If

        ElseIf _unit(unitNo).器件类型 = 0 And _unit(unitNo).电压流标记 Then '单位发光管
            Select Case _unit(unitNo).电压流规格
                Case 1 '10mA
                    current = ((AD - 128) / 4 / 256 * 5 + 2.5) * 1000 / 250
                Case 2 '20mA
                    current = ((AD - 128) / 4 / 256 * 5 + 2.5) * 1000 / 125
                Case 3 '30mA
                    current = ((AD - 128) / 4 / 256 * 5 + 2.5) * 1000 / (250 / 3)
            End Select
            '共阴AD测量值大于128修正
            If (unitNo = 24 Or unitNo = 25 Or unitNo = 28 Or
                unitNo = 29 Or unitNo = 30 Or unitNo = 31) And AD > 128 Then
                current = current * 125 / 126
            End If
            dbcmd.CommandText = "insert into 试验结果 values(" _
                              & _unit(unitNo).对位表(chippos) & "," _
                              & CByte(chippos Mod 2 + 1) & ",#" _
                              & time & "#," _
                              & Math.Floor(current * 100) / 100 & ")"

        ElseIf _unit(unitNo).器件类型 = 3 And _unit(unitNo).电压流标记 Then '独立发光管
            Select Case _unit(unitNo).电压流规格
                Case 1 '10mA
                    current = ((AD - 128) / 4 / 256 * 5 + 2.5) * 1000 / 250
                Case 2 '20mA
                    current = ((AD - 128) / 4 / 256 * 5 + 2.5) * 1000 / 125
                Case 3 '30mA
                    current = ((AD - 128) / 4 / 256 * 5 + 2.5) * 1000 / (250 / 3)
            End Select
            '共阴AD测量值大于128修正
            If (unitNo = 24 Or unitNo = 25 Or unitNo = 28 Or
                unitNo = 29 Or unitNo = 30 Or unitNo = 31) And AD > 128 Then
                current = current * 125 / 126
            End If
            dbcmd.CommandText = "insert into 试验结果 values(" _
                              & _unit(unitNo).对位表(chippos) & "," _
                              & CByte(1) & ",#" _
                              & time & "#," _
                              & Math.Floor(current * 100) / 100 & ")"
        End If

        dbcmd.ExecuteNonQuery()

        cn.Close()
    End Sub

    Public Shared Sub UpdateHour(ByVal unitNo As Byte, ByVal time As Date)
        Dim dbcmd As New OleDbCommand
        dbcmd.Connection = _DBconn
        dbcmd.CommandText = "update 单元状态 set 最近上传时间 = #" & time & "# where 老化单元号 = " & unitNo + 1
        dbcmd.ExecuteNonQuery()
    End Sub

    Public Shared Sub UpdateTest(ByVal unitNo As Byte)
        Dim dbcmd As New OleDbCommand
        Dim cnstr As String = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" _
            & _unit(unitNo).结果文件 & ";Extended Properties='Excel 8.0'"
        Dim cn As New OleDbConnection(cnstr)
        dbcmd.Connection = _DBconn
        dbcmd.CommandText = "update 单元状态 set 器件类型 = " & _unit(unitNo).器件类型 & _
                            ", 运行状态 = 0, 最近上传时间 = #" & Now & _
                            "#, 试验编号 = '" & _unit(unitNo).试验编号 & _
                            "' where 老化单元号 = " & unitNo + 1
        dbcmd.ExecuteNonQuery()
        Dim vc As String = ""
        If _unit(unitNo).电压流标记 Then
            Select Case _unit(unitNo).电压流规格
                Case 1
                    vc = "10mA"
                Case 2
                    vc = "20mA"
                Case 3
                    vc = "30mA"
            End Select
        Else
            Select Case _unit(unitNo).电压流规格
                Case 0
                    vc = "21V"
                Case 1
                    vc = "25V"
                Case 2
                    vc = "28V"
                Case 3
                    vc = "16V"
                Case 4
                    vc = "5.5V"
            End Select
        End If
        dbcmd.CommandText = "insert into 试验记录 values('" & _unit(unitNo).试验编号 &
                            "', '" & _unit(unitNo).产品型号 &
                            "', '" & _unit(unitNo).生产批号 &
                            "', '" & _unit(unitNo).标准号 &
                            "', #" & _unit(unitNo).开机日期 &
                            "#, '" & _unit(unitNo).结果文件 &
                            "', '" & _unit(unitNo).质量等级 &
                            "', '" & vc &
                            "', " & _unit(unitNo).上限 &
                            ", " & _unit(unitNo).下限 & ")"
        dbcmd.ExecuteNonQuery()
        For i = 0 To 95
            dbcmd.CommandText = "update 对位表 set 器件编号 = " & _unit(unitNo).对位表(i) &
                                " where 老化单元号 = " & unitNo + 1 &
                                " and 老化位号 = " & i + 1
            dbcmd.ExecuteNonQuery()
        Next

        cn.Open()
        dbcmd.Connection = cn
        dbcmd.CommandText =
            "CREATE TABLE 试验信息 ([试验编号] VarChar,[产品型号] VarChar,[生产批号] VarChar, [质量等级] VarChar, [标准号] VarChar, [开机时间] DATE, [测试单元号] INTEGER)"
        dbcmd.ExecuteNonQuery()
        dbcmd.CommandText = "insert into 试验信息 values('" _
                            & _unit(unitNo).试验编号 & "','" _
                            & _unit(unitNo).产品型号 & "','" _
                            & _unit(unitNo).生产批号 & "','" _
                            & _unit(unitNo).质量等级 & "','" _
                            & _unit(unitNo).标准号 & "',#" _
                            & _unit(unitNo).开机日期 & "#," _
                            & _unit(unitNo).address & ")"
        dbcmd.ExecuteNonQuery()
        If _unit(unitNo).电压流标记 Then
            dbcmd.CommandText =
                "CREATE TABLE 试验结果 ([器件编号] integer,[管芯号] integer,[记录时间] date, [电流/mA] double)"
        Else
            If unitNo <= 15 Then
                dbcmd.CommandText =
                    "CREATE TABLE 试验结果 ([器件编号] integer,[管芯号] integer,[记录时间] date, [电压/V] double, [功率] double)"
            ElseIf unitNo <= 23 Then
                dbcmd.CommandText =
                    "CREATE TABLE 试验结果 ([器件编号] integer,[管芯号] integer,[记录时间] date, [电压/V] double, [功率] double, [电流/mA] double)"
            End If
        End If
            dbcmd.ExecuteNonQuery()
        cn.Close()
    End Sub
	
    Public Shared Sub UpdateRecallTime()
        Dim dbcmd As New OleDbCommand
        dbcmd.Connection = _DBconn
        _lastRecallTime = Now
        dbcmd.CommandText = "update 最近召回时间 set 时间 = #" & _lastRecallTime & "# where id = 1"
        dbcmd.ExecuteNonQuery()
    End Sub

    Public Shared Sub UpdateStates(ByVal unitNo As Byte, ByVal state As Byte)
        If state = 0 Or state = 3 Or state = &HC Or state = &H30 Then
            Dim dbcmd As New OleDbCommand
            dbcmd.Connection = _DBconn
            dbcmd.CommandText = "update 单元状态 set 运行状态 = " & state & " where 老化单元号 = " & unitNo + 1
            dbcmd.ExecuteNonQuery()
        End If
    End Sub

    Public Shared Sub Update340(ByVal unitNo As Byte)
        Dim dbcmd As New OleDbCommand
        dbcmd.Connection = _DBconn
        dbcmd.CommandText = "update 单元状态 set 运行状态 = 0 where 老化单元号 = " & unitNo + 1
        dbcmd.ExecuteNonQuery()
        For i = 0 To 95
            dbcmd.CommandText = "update 对位表 set 器件编号 = " & _unit(unitNo).对位表(i) & _
                                " where 老化单元号 = " & unitNo + 1 & _
                                " and 老化位号 = " & i + 1
            dbcmd.ExecuteNonQuery()
        Next
    End Sub
End Class
