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
                    If Not reader("电压规格") Is DBNull.Value Then
                        .电压规格 = reader("电压规格")
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
                    If Not reader("操作员") Is DBNull.Value Then
                        .操作员 = reader("操作员")
                    End If
                End With
            End While
        End If
        For i = 0 To 23
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

    Public Shared Sub WriteResult(ByVal testnum As String, ByVal chipnum As Byte, ByVal num As Byte, _
                                  ByVal time As Date, ByVal volt As Single)
        Dim dbcmd As New OleDbCommand
        dbcmd.Connection = _DBconn

        time = time.AddMinutes(-time.Minute)
        time = time.AddSeconds(-time.Second)

        dbcmd.CommandText = "insert into 试验结果 values('" _
                            & testnum & "'," _
                            & chipnum & "," _
                            & num & ",#" _
                            & time & "#," _
                            & Math.Floor(volt * 10) / 10 & ")"
        dbcmd.ExecuteNonQuery()
    End Sub

    Public Shared Sub UpdateHour(ByVal unitNo As Byte, ByVal time As Date)
        Dim dbcmd As New OleDbCommand
        dbcmd.Connection = _DBconn
        dbcmd.CommandText = "update 单元状态 set 最近上传时间 = #" & time & "# where 老化单元号 = " & unitNo + 1
        dbcmd.ExecuteNonQuery()
    End Sub

    Public Shared Sub UpdateTest(ByVal unitNo As Byte)
        Dim dbcmd As New OleDbCommand
        dbcmd.Connection = _DBconn
        dbcmd.CommandText = "update 单元状态 set 器件类型 = " & _unit(unitNo).器件类型 & _
                            ", 运行状态 = 0, 最近上传时间 = #" & Now & _
                            "#, 试验编号 = '" & _unit(unitNo).试验编号 & _
                            "' where 老化单元号 = " & unitNo + 1
        dbcmd.ExecuteNonQuery()
        dbcmd.CommandText = "insert into 试验记录 values('" & _unit(unitNo).试验编号 & _
                            "', '" & _unit(unitNo).产品型号 & _
                            "', '" & _unit(unitNo).生产批号 & _
                            "', '" & _unit(unitNo).标准号 & _
                            "', #" & _unit(unitNo).开机日期 & _
                            "#, '" & _unit(unitNo).操作员 & _
                            "', '" & _unit(unitNo).质量等级 & _
                            "', " & _unit(unitNo).电压规格 & _
                            ", " & _unit(unitNo).上限 & _
                            ", " & _unit(unitNo).下限 & ")"
        dbcmd.ExecuteNonQuery()
        For i = 0 To 95
            dbcmd.CommandText = "update 对位表 set 器件编号 = " & _unit(unitNo).对位表(i) & _
                                " where 老化单元号 = " & unitNo + 1 & _
                                " and 老化位号 = " & i + 1
            dbcmd.ExecuteNonQuery()
        Next
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
