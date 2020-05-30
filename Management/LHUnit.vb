Public Class LHUnit
    Public 产品型号 As String
    Public 试验员 As String
    Public 电压流标记 As Boolean '0-电压, 1-电流
    Public 电压流规格 As Byte '0-21V,1-25V(10mA),2-28V(20mA),3-16V(30mA)，4-5.5V
    Public 生产批号 As String
    Public 试验编号 As String
    Public 开机日期 As Date
    Public 结果文件 As String
    Public 对位表(95) As Byte
    Public 座子类型 As Boolean  '0-8脚，1-16脚
    Public 上限 As Byte
    Public 下限 As Byte
    Public 器件类型 As Byte     '0-单位，1-双位，2-四位，3-独立
    Public address As Byte
    Public Testing As Byte     '单元状态：00-正常，03-请求参数，0C-340暂停，30-1000停止
    Public lastHour As Date
End Class
