﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OneSec = New System.Windows.Forms.Timer(Me.components)
        Me.OneMin = New System.Windows.Forms.Timer(Me.components)
        Me.Label35 = New System.Windows.Forms.Label()
        Me.grp操作 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txt质量等级 = New System.Windows.Forms.TextBox()
        Me.txt生产批号 = New System.Windows.Forms.TextBox()
        Me.txt标准号 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt试验编号 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblPos = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblWeishu = New System.Windows.Forms.Label()
        Me.lblVolt = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbUnitNo = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnStartCancel = New System.Windows.Forms.Button()
        Me.btnStartOK = New System.Windows.Forms.Button()
        Me.txtRecv = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.cmbChipWeishu = New System.Windows.Forms.ComboBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.grp操作.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OneSec
        '
        Me.OneSec.Interval = 1300
        '
        'OneMin
        '
        Me.OneMin.Interval = 60000
        '
        'Label35
        '
        Me.Label35.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label35.Font = New System.Drawing.Font("隶书", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(0, 0)
        Me.Label35.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(2504, 94)
        Me.Label35.TabIndex = 42
        Me.Label35.Text = "苏州半导体总厂—光电耦合器寿命台管理软件"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp操作
        '
        Me.grp操作.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.grp操作.Controls.Add(Me.Panel4)
        Me.grp操作.Controls.Add(Me.Panel3)
        Me.grp操作.Controls.Add(Me.Panel2)
        Me.grp操作.Controls.Add(Me.Label28)
        Me.grp操作.Controls.Add(Me.Label27)
        Me.grp操作.Controls.Add(Me.Label26)
        Me.grp操作.Controls.Add(Me.btnStartCancel)
        Me.grp操作.Controls.Add(Me.btnStartOK)
        Me.grp操作.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.grp操作.Location = New System.Drawing.Point(1736, 108)
        Me.grp操作.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.grp操作.Name = "grp操作"
        Me.grp操作.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.grp操作.Size = New System.Drawing.Size(765, 912)
        Me.grp操作.TabIndex = 43
        Me.grp操作.TabStop = False
        Me.grp操作.Text = "试验操作区"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txt质量等级)
        Me.Panel4.Controls.Add(Me.txt生产批号)
        Me.Panel4.Controls.Add(Me.txt标准号)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.txt试验编号)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Location = New System.Drawing.Point(220, 597)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(486, 229)
        Me.Panel4.TabIndex = 26
        '
        'txt质量等级
        '
        Me.txt质量等级.Location = New System.Drawing.Point(200, 178)
        Me.txt质量等级.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt质量等级.Name = "txt质量等级"
        Me.txt质量等级.Size = New System.Drawing.Size(241, 35)
        Me.txt质量等级.TabIndex = 16
        '
        'txt生产批号
        '
        Me.txt生产批号.Location = New System.Drawing.Point(200, 66)
        Me.txt生产批号.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt生产批号.Name = "txt生产批号"
        Me.txt生产批号.Size = New System.Drawing.Size(241, 35)
        Me.txt生产批号.TabIndex = 15
        '
        'txt标准号
        '
        Me.txt标准号.Location = New System.Drawing.Point(200, 124)
        Me.txt标准号.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt标准号.Name = "txt标准号"
        Me.txt标准号.Size = New System.Drawing.Size(241, 35)
        Me.txt标准号.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(40, 184)
        Me.Label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 25)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "质量等级"
        '
        'txt试验编号
        '
        Me.txt试验编号.Location = New System.Drawing.Point(200, 12)
        Me.txt试验编号.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt试验编号.Name = "txt试验编号"
        Me.txt试验编号.Size = New System.Drawing.Size(241, 35)
        Me.txt试验编号.TabIndex = 12
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(40, 130)
        Me.Label23.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(87, 25)
        Me.Label23.TabIndex = 11
        Me.Label23.Text = "标准号"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(40, 72)
        Me.Label24.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 25)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "生产批号"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(40, 16)
        Me.Label25.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 25)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "试验编号"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmbType)
        Me.Panel3.Controls.Add(Me.cmbChipWeishu)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txtMin)
        Me.Panel3.Controls.Add(Me.txtMax)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.lblPos)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Location = New System.Drawing.Point(220, 327)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(486, 229)
        Me.Panel3.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(325, 133)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 25)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "MIN"
        '
        'txtMin
        '
        Me.txtMin.Location = New System.Drawing.Point(380, 122)
        Me.txtMin.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtMin.MaxLength = 4
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(81, 35)
        Me.txtMin.TabIndex = 24
        Me.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(222, 122)
        Me.txtMax.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtMax.MaxLength = 4
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(81, 35)
        Me.txtMax.TabIndex = 23
        Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(167, 133)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 25)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "MAX"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 133)
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 25)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "临界电压"
        '
        'lblPos
        '
        Me.lblPos.AutoSize = True
        Me.lblPos.ForeColor = System.Drawing.Color.Red
        Me.lblPos.Location = New System.Drawing.Point(160, 187)
        Me.lblPos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(162, 25)
        Me.lblPos.TabIndex = 18
        Me.lblPos.Text = "点此插放器件"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 187)
        Me.Label20.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 25)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "插放器件"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 82)
        Me.Label21.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 25)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "器件类型"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 28)
        Me.Label22.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 25)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "器件型号"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblWeishu)
        Me.Panel2.Controls.Add(Me.lblVolt)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.cmbUnitNo)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Location = New System.Drawing.Point(220, 52)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(348, 229)
        Me.Panel2.TabIndex = 0
        '
        'lblWeishu
        '
        Me.lblWeishu.AutoSize = True
        Me.lblWeishu.Location = New System.Drawing.Point(180, 180)
        Me.lblWeishu.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblWeishu.Name = "lblWeishu"
        Me.lblWeishu.Size = New System.Drawing.Size(76, 25)
        Me.lblWeishu.TabIndex = 11
        Me.lblWeishu.Text = "-  位"
        '
        'lblVolt
        '
        Me.lblVolt.AutoSize = True
        Me.lblVolt.Location = New System.Drawing.Point(180, 107)
        Me.lblVolt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblVolt.Name = "lblVolt"
        Me.lblVolt.Size = New System.Drawing.Size(64, 25)
        Me.lblVolt.TabIndex = 10
        Me.lblVolt.Text = "-  V"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 180)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 25)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "插座位数"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 107)
        Me.Label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 25)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "电压规格"
        '
        'cmbUnitNo
        '
        Me.cmbUnitNo.FormattingEnabled = True
        Me.cmbUnitNo.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbUnitNo.Location = New System.Drawing.Point(174, 21)
        Me.cmbUnitNo.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmbUnitNo.Name = "cmbUnitNo"
        Me.cmbUnitNo.Size = New System.Drawing.Size(142, 32)
        Me.cmbUnitNo.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 26)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 25)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "单元编号"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(64, 668)
        Me.Label28.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 93)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "第三步：填写试验信息"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(64, 397)
        Me.Label27.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(128, 88)
        Me.Label27.TabIndex = 28
        Me.Label27.Text = "第二步：确定试验产品参数"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(64, 119)
        Me.Label26.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 88)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "第一步：选择寿命试验单元"
        '
        'btnStartCancel
        '
        Me.btnStartCancel.Location = New System.Drawing.Point(583, 852)
        Me.btnStartCancel.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnStartCancel.Name = "btnStartCancel"
        Me.btnStartCancel.Size = New System.Drawing.Size(123, 49)
        Me.btnStartCancel.TabIndex = 32
        Me.btnStartCancel.Text = "取 消"
        Me.btnStartCancel.UseVisualStyleBackColor = True
        '
        'btnStartOK
        '
        Me.btnStartOK.Location = New System.Drawing.Point(405, 852)
        Me.btnStartOK.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnStartOK.Name = "btnStartOK"
        Me.btnStartOK.Size = New System.Drawing.Size(123, 49)
        Me.btnStartOK.TabIndex = 31
        Me.btnStartOK.Text = "开 始"
        Me.btnStartOK.UseVisualStyleBackColor = True
        '
        'txtRecv
        '
        Me.txtRecv.Location = New System.Drawing.Point(132, 70)
        Me.txtRecv.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtRecv.Multiline = True
        Me.txtRecv.Name = "txtRecv"
        Me.txtRecv.ReadOnly = True
        Me.txtRecv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRecv.Size = New System.Drawing.Size(341, 608)
        Me.txtRecv.TabIndex = 45
        Me.txtRecv.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtRecv)
        Me.GroupBox1.Controls.Add(Me.txtSend)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(51, 108)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1604, 919)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "测试单元状态"
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(557, 70)
        Me.txtSend.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.ReadOnly = True
        Me.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSend.Size = New System.Drawing.Size(341, 608)
        Me.txtSend.TabIndex = 46
        Me.txtSend.Visible = False
        '
        'cmbChipWeishu
        '
        Me.cmbChipWeishu.FormattingEnabled = True
        Me.cmbChipWeishu.Items.AddRange(New Object() {"8 脚一芯", "8 脚二芯", "16脚四芯", "4 脚一芯"})
        Me.cmbChipWeishu.Location = New System.Drawing.Point(165, 75)
        Me.cmbChipWeishu.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmbChipWeishu.Name = "cmbChipWeishu"
        Me.cmbChipWeishu.Size = New System.Drawing.Size(142, 32)
        Me.cmbChipWeishu.TabIndex = 12
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"GH302", "4GH302", "GHB302", "GH137", "GO11"})
        Me.cmbType.Location = New System.Drawing.Point(163, 21)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(167, 32)
        Me.cmbType.TabIndex = 26
        Me.cmbType.Text = "选择或输入"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2504, 1055)
        Me.Controls.Add(Me.grp操作)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "光电耦合器寿命台管理软件"
        Me.grp操作.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OneSec As System.Windows.Forms.Timer
    Friend WithEvents OneMin As System.Windows.Forms.Timer
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents grp操作 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txt质量等级 As TextBox
    Friend WithEvents txt生产批号 As TextBox
    Friend WithEvents txt标准号 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txt试验编号 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMin As TextBox
    Friend WithEvents txtMax As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblPos As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblWeishu As Label
    Friend WithEvents lblVolt As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbUnitNo As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents btnStartCancel As Button
    Friend WithEvents btnStartOK As Button
    Friend WithEvents txtRecv As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtSend As TextBox
    Friend WithEvents cmbChipWeishu As ComboBox
    Friend WithEvents cmbType As ComboBox
End Class
