'Public Class frm启动试验
'    Public unitNo As Byte
'    Public pos(95) As Byte
'    Public 操作员 As String

'    Private Sub frm启动试验_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        GroupBox2.Parent = Me
'        GroupBox3.Parent = Me
'        GroupBox2.Location = GroupBox1.Location
'        GroupBox3.Location = GroupBox1.Location
'        GroupBox1.Visible = True
'        GroupBox2.Visible = False
'        GroupBox3.Visible = False

'        btnBackward.Enabled = False
'        btnOk.Enabled = False

'        For i = 0 To 95
'            pos(i) = 0
'        Next
'    End Sub


'    Private Sub btnForward_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnForward.Click
'        If GroupBox1.Visible Then
'            GroupBox1.Visible = False
'            GroupBox2.Visible = True
'            GroupBox3.Visible = False
'            btnBackward.Enabled = True
'        ElseIf GroupBox2.Visible Then
'            GroupBox1.Visible = False
'            GroupBox2.Visible = False
'            GroupBox3.Visible = True
'            btnForward.Enabled = False
'            btnOk.Enabled = True
'        End If
'    End Sub

'    Private Sub btnBackward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackward.Click
'        If GroupBox2.Visible Then
'            GroupBox1.Visible = True
'            GroupBox2.Visible = False
'            GroupBox3.Visible = False
'            btnBackward.Enabled = False
'        ElseIf GroupBox3.Visible Then
'            GroupBox1.Visible = False
'            GroupBox2.Visible = True
'            GroupBox3.Visible = False
'            btnForward.Enabled = True
'            btnOk.Enabled = False
'        End If
'    End Sub

'    Private Sub cmbUnitNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        unitNo = cmbUnitNo.SelectedIndex
'        If _unit(unitNo).座子类型 Then
'            lblWeishu.Text = "四 位"
'        Else
'            lblWeishu.Text = "一 位"
'        End If

'        lblVolt.Text = _unit(unitNo).电压规格 & " V"
'        txtMax.Text = _unit(unitNo).电压规格 + 1
'        txtMin.Text = _unit(unitNo).电压规格 - 1
'        lblChipVolt.Text = lblVolt.Text
'    End Sub

'    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
'        If cmbType.SelectedIndex <= 3 Then
'            lblChipWeishu.Text = "一 位"
'        Else
'            lblChipWeishu.Text = "四 位"
'        End If
'    End Sub

'    Private Sub lblPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPos.Click
'        If lblChipWeishu.Text = "- 位" Then
'            MsgBox("请先选择器件！")
'            Exit Sub
'        End If
'        If lblWeishu.Text = "四 位" And lblChipWeishu.Text = "二 位" Then '四位插双位
'            Dim frm As New frmPosChart2
'            frm.unitNo = unitNo
'            frm.Show()
'        End If
'        If lblWeishu.Text = "四 位" And lblChipWeishu.Text = "四 位" Then '四位插四位
'            Dim frm As New frmPosChart4
'            frm.unitNo = unitNo
'            frm.Show()
'        End If
'        If lblWeishu.Text = "一 位" And lblChipWeishu.Text = "一 位" Then '一位插一位
'            Dim frm As New frmPosChart1
'            frm.unitNo = unitNo
'            frm.Show()
'        End If
'    End Sub

'    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'        Me.Dispose()
'    End Sub

'    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
'        With _unit(unitNo)
'            .试验编号 = txt试验编号.Text
'            .产品型号 = cmbType.SelectedItem
'            .质量等级 = txt质量等级.Text
'            .标准号 = txt标准号.Text
'            .生产批号 = txt生产批号.Text
'            .操作员 = 操作员
'            .对位表 = pos
'            .上限 = float2byte(lblVolt.Text, txtMax.Text)
'            .下限 = float2byte(lblVolt.Text, txtMin.Text)
'            .开机日期 = Now.Date
'            Select Case lblChipWeishu.Text
'                Case "一 位" : .器件类型 = 0
'                Case "二 位" : .器件类型 = 1
'                Case "四 位" : .器件类型 = 2
'            End Select
'        End With

'        _commFlag.unitNo_start = unitNo
'        Select Case _unit(unitNo).Testing
'            Case &H0 : _commFlag.reboot = True
'            Case &H3 : _commFlag.startup = True
'            Case &HC : _commFlag.reboot340 = True
'            Case &H30 : _commFlag.startup = True
'        End Select
'        Me.Dispose()
'    End Sub

'    Private Function float2byte(ByVal volt As String, ByVal limit As Single) As Byte
'        Select Case volt
'            Case "21 V" : Return CByte((limit * 25600 - 387200) / 1175)
'            Case "25 V" : Return CByte((limit * 25600 - 464000) / 1375)
'            Case "28 V" : Return CByte((limit * 25600 - 521600) / 1525)
'        End Select
'    End Function


'End Class