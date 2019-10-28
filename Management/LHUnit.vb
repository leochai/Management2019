﻿Public Class LHUnit
    Public 产品型号 As String
    Public 质量等级 As String
    Public 标准号 As String
    Private m电压规格 As Byte   '0-21V,1-25V,2-28V,3-16V，4-5.5V
    Public 生产批号 As String
    Public 试验编号 As String
    Public 开机日期 As Date
    Public 操作员 As String
    Public 对位表(95) As Byte
    Public 座子类型 As Boolean  '0-单位，1-四位
    Public 上限 As Byte
    Public 下限 As Byte
    Public 器件类型 As Byte     '0-单位，1-双位，2-四位，3-独立
    Public address As Byte
    Public Testing As Byte     '单元状态：00-正常，03-请求参数，0C-340暂停，30-1000停止
    Public lastHour As Date

    Property 电压规格()
        Get
            Return m电压规格
        End Get
        Set(ByVal value)
            Select Case value
                Case 0 : m电压规格 = 21
                Case 1 : m电压规格 = 25
                Case 2 : m电压规格 = 28
                Case 3 : m电压规格 = 16
                Case 4 : m电压规格 = 5.5
            End Select
        End Set
    End Property
End Class
