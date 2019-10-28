<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblDown = New System.Windows.Forms.Label()
        Me.lblUp = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.SwitchLight = New LeoControls.SwitchLight()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.lbl操作员 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn启动试验 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl例试编号 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl标准号 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl生产批号 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl器件类型 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl产品型号 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl座子类型 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl电压规格 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl单元编号 = New System.Windows.Forms.Label()
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
        Me.lblStartup = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblPos = New System.Windows.Forms.Label()
        Me.lblChipWeishu = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
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
        Me.OneSec = New System.Windows.Forms.Timer(Me.components)
        Me.OneMin = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNexthour = New System.Windows.Forms.Button()
        Me.btnlasthour = New System.Windows.Forms.Button()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.cmbTestNo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.grp操作.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.grp操作)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(45, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 743)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "状态显示区"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.lblstatus)
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Controls.Add(Me.lblDown)
        Me.Panel5.Controls.Add(Me.lblUp)
        Me.Panel5.Controls.Add(Me.Label31)
        Me.Panel5.Controls.Add(Me.Label30)
        Me.Panel5.Controls.Add(Me.SwitchLight)
        Me.Panel5.Controls.Add(Me.btnResume)
        Me.Panel5.Controls.Add(Me.lbl操作员)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.btn启动试验)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.lbl例试编号)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.lbl标准号)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.lbl生产批号)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.lbl器件类型)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.lbl产品型号)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lbl座子类型)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.lbl电压规格)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.lbl单元编号)
        Me.Panel5.Location = New System.Drawing.Point(13, 22)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(189, 710)
        Me.Panel5.TabIndex = 41
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblstatus.Location = New System.Drawing.Point(126, 20)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(68, 21)
        Me.lblstatus.TabIndex = 48
        Me.lblstatus.Text = "Label12"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label32.Location = New System.Drawing.Point(5, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(74, 21)
        Me.Label32.TabIndex = 47
        Me.Label32.Text = "运行状态"
        '
        'lblDown
        '
        Me.lblDown.AutoSize = True
        Me.lblDown.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblDown.Location = New System.Drawing.Point(85, 420)
        Me.lblDown.Name = "lblDown"
        Me.lblDown.Size = New System.Drawing.Size(68, 21)
        Me.lblDown.TabIndex = 46
        Me.lblDown.Text = "Label16"
        '
        'lblUp
        '
        Me.lblUp.AutoSize = True
        Me.lblUp.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblUp.Location = New System.Drawing.Point(85, 370)
        Me.lblUp.Name = "lblUp"
        Me.lblUp.Size = New System.Drawing.Size(68, 21)
        Me.lblUp.TabIndex = 45
        Me.lblUp.Text = "Label16"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label31.Location = New System.Drawing.Point(5, 620)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 21)
        Me.Label31.TabIndex = 44
        Me.Label31.Text = "操作员"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label30.Location = New System.Drawing.Point(5, 570)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(74, 21)
        Me.Label30.TabIndex = 43
        Me.Label30.Text = "例试编号"
        '
        'SwitchLight
        '
        Me.SwitchLight.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SwitchLight.Location = New System.Drawing.Point(84, 9)
        Me.SwitchLight.Margin = New System.Windows.Forms.Padding(6)
        Me.SwitchLight.Name = "SwitchLight"
        Me.SwitchLight.Size = New System.Drawing.Size(40, 40)
        Me.SwitchLight.TabIndex = 42
        '
        'btnResume
        '
        Me.btnResume.Location = New System.Drawing.Point(98, 661)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(86, 27)
        Me.btnResume.TabIndex = 41
        Me.btnResume.Text = "继续试验"
        Me.btnResume.UseVisualStyleBackColor = True
        '
        'lbl操作员
        '
        Me.lbl操作员.AutoSize = True
        Me.lbl操作员.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl操作员.Location = New System.Drawing.Point(85, 620)
        Me.lbl操作员.Name = "lbl操作员"
        Me.lbl操作员.Size = New System.Drawing.Size(68, 21)
        Me.lbl操作员.TabIndex = 37
        Me.lbl操作员.Text = "Label20"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 21)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "光电耦合器"
        '
        'btn启动试验
        '
        Me.btn启动试验.Location = New System.Drawing.Point(3, 661)
        Me.btn启动试验.Name = "btn启动试验"
        Me.btn启动试验.Size = New System.Drawing.Size(86, 27)
        Me.btn启动试验.TabIndex = 39
        Me.btn启动试验.Text = "启动试验"
        Me.btn启动试验.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 21)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "产品名称"
        '
        'lbl例试编号
        '
        Me.lbl例试编号.AutoSize = True
        Me.lbl例试编号.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl例试编号.Location = New System.Drawing.Point(85, 570)
        Me.lbl例试编号.Name = "lbl例试编号"
        Me.lbl例试编号.Size = New System.Drawing.Size(68, 21)
        Me.lbl例试编号.TabIndex = 36
        Me.lbl例试编号.Text = "Label19"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 270)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 21)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "产品型号"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 21)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "电压规格"
        '
        'lbl标准号
        '
        Me.lbl标准号.AutoSize = True
        Me.lbl标准号.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl标准号.Location = New System.Drawing.Point(85, 520)
        Me.lbl标准号.Name = "lbl标准号"
        Me.lbl标准号.Size = New System.Drawing.Size(68, 21)
        Me.lbl标准号.TabIndex = 35
        Me.lbl标准号.Text = "Label18"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 21)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "器件类型"
        '
        'lbl生产批号
        '
        Me.lbl生产批号.AutoSize = True
        Me.lbl生产批号.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl生产批号.Location = New System.Drawing.Point(85, 470)
        Me.lbl生产批号.Name = "lbl生产批号"
        Me.lbl生产批号.Size = New System.Drawing.Size(68, 21)
        Me.lbl生产批号.TabIndex = 34
        Me.lbl生产批号.Text = "Label17"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 370)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 21)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "电压上限"
        '
        'lbl器件类型
        '
        Me.lbl器件类型.AutoSize = True
        Me.lbl器件类型.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl器件类型.Location = New System.Drawing.Point(85, 320)
        Me.lbl器件类型.Name = "lbl器件类型"
        Me.lbl器件类型.Size = New System.Drawing.Size(68, 21)
        Me.lbl器件类型.TabIndex = 33
        Me.lbl器件类型.Text = "Label16"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 420)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 21)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "电压下限"
        '
        'lbl产品型号
        '
        Me.lbl产品型号.AutoSize = True
        Me.lbl产品型号.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl产品型号.Location = New System.Drawing.Point(85, 270)
        Me.lbl产品型号.Name = "lbl产品型号"
        Me.lbl产品型号.Size = New System.Drawing.Size(68, 21)
        Me.lbl产品型号.TabIndex = 32
        Me.lbl产品型号.Text = "Label15"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 470)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 21)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "生产批号"
        '
        'lbl座子类型
        '
        Me.lbl座子类型.AutoSize = True
        Me.lbl座子类型.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl座子类型.Location = New System.Drawing.Point(85, 170)
        Me.lbl座子类型.Name = "lbl座子类型"
        Me.lbl座子类型.Size = New System.Drawing.Size(68, 21)
        Me.lbl座子类型.TabIndex = 31
        Me.lbl座子类型.Text = "Label14"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 21)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "单元编号"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 21)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "座子类型"
        '
        'lbl电压规格
        '
        Me.lbl电压规格.AutoSize = True
        Me.lbl电压规格.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl电压规格.Location = New System.Drawing.Point(85, 120)
        Me.lbl电压规格.Name = "lbl电压规格"
        Me.lbl电压规格.Size = New System.Drawing.Size(68, 21)
        Me.lbl电压规格.TabIndex = 30
        Me.lbl电压规格.Text = "Label13"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 520)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 21)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "标准号"
        '
        'lbl单元编号
        '
        Me.lbl单元编号.AutoSize = True
        Me.lbl单元编号.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl单元编号.Location = New System.Drawing.Point(85, 70)
        Me.lbl单元编号.Name = "lbl单元编号"
        Me.lbl单元编号.Size = New System.Drawing.Size(68, 21)
        Me.lbl单元编号.TabIndex = 29
        Me.lbl单元编号.Text = "Label12"
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
        Me.grp操作.Location = New System.Drawing.Point(241, 559)
        Me.grp操作.Name = "grp操作"
        Me.grp操作.Size = New System.Drawing.Size(727, 173)
        Me.grp操作.TabIndex = 41
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
        Me.Panel4.Location = New System.Drawing.Point(979, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(265, 131)
        Me.Panel4.TabIndex = 26
        '
        'txt质量等级
        '
        Me.txt质量等级.Location = New System.Drawing.Point(109, 102)
        Me.txt质量等级.Name = "txt质量等级"
        Me.txt质量等级.Size = New System.Drawing.Size(133, 23)
        Me.txt质量等级.TabIndex = 16
        '
        'txt生产批号
        '
        Me.txt生产批号.Location = New System.Drawing.Point(109, 38)
        Me.txt生产批号.Name = "txt生产批号"
        Me.txt生产批号.Size = New System.Drawing.Size(133, 23)
        Me.txt生产批号.TabIndex = 15
        '
        'txt标准号
        '
        Me.txt标准号.Location = New System.Drawing.Point(109, 71)
        Me.txt标准号.Name = "txt标准号"
        Me.txt标准号.Size = New System.Drawing.Size(133, 23)
        Me.txt标准号.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(22, 105)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 14)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "质量等级"
        '
        'txt试验编号
        '
        Me.txt试验编号.Location = New System.Drawing.Point(109, 7)
        Me.txt试验编号.Name = "txt试验编号"
        Me.txt试验编号.Size = New System.Drawing.Size(133, 23)
        Me.txt试验编号.TabIndex = 12
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(22, 74)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 14)
        Me.Label23.TabIndex = 11
        Me.Label23.Text = "标准号"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(22, 41)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 14)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "生产批号"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(22, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 14)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "试验编号"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblStartup)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txtMin)
        Me.Panel3.Controls.Add(Me.txtMax)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.lblPos)
        Me.Panel3.Controls.Add(Me.lblChipWeishu)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.cmbType)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Location = New System.Drawing.Point(427, 30)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(265, 131)
        Me.Panel3.TabIndex = 12
        '
        'lblStartup
        '
        Me.lblStartup.Font = New System.Drawing.Font("微软雅黑", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblStartup.Location = New System.Drawing.Point(-206, 39)
        Me.lblStartup.Name = "lblStartup"
        Me.lblStartup.Size = New System.Drawing.Size(354, 58)
        Me.lblStartup.TabIndex = 43
        Me.lblStartup.Text = "开 始 新 试 验"
        Me.lblStartup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(177, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 14)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "MIN"
        '
        'txtMin
        '
        Me.txtMin.Location = New System.Drawing.Point(207, 70)
        Me.txtMin.MaxLength = 4
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(46, 23)
        Me.txtMin.TabIndex = 24
        Me.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(121, 70)
        Me.txtMax.MaxLength = 4
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(46, 23)
        Me.txtMax.TabIndex = 23
        Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(91, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 14)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "MAX"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 76)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 14)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "临界电压"
        '
        'lblPos
        '
        Me.lblPos.AutoSize = True
        Me.lblPos.ForeColor = System.Drawing.Color.Red
        Me.lblPos.Location = New System.Drawing.Point(87, 107)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(91, 14)
        Me.lblPos.TabIndex = 18
        Me.lblPos.Text = "点此插放器件"
        '
        'lblChipWeishu
        '
        Me.lblChipWeishu.AutoSize = True
        Me.lblChipWeishu.Location = New System.Drawing.Point(93, 47)
        Me.lblChipWeishu.Name = "lblChipWeishu"
        Me.lblChipWeishu.Size = New System.Drawing.Size(42, 14)
        Me.lblChipWeishu.TabIndex = 17
        Me.lblChipWeishu.Text = "-  位"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 107)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 14)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "插放器件"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 14)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "器件位数"
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"GH302", "GHB302", "GO11", "GH137", "4GH302", "4GO213"})
        Me.cmbType.Location = New System.Drawing.Point(96, 13)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(129, 22)
        Me.cmbType.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 14)
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
        Me.Panel2.Location = New System.Drawing.Point(126, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(190, 131)
        Me.Panel2.TabIndex = 0
        '
        'lblWeishu
        '
        Me.lblWeishu.AutoSize = True
        Me.lblWeishu.Location = New System.Drawing.Point(98, 103)
        Me.lblWeishu.Name = "lblWeishu"
        Me.lblWeishu.Size = New System.Drawing.Size(42, 14)
        Me.lblWeishu.TabIndex = 11
        Me.lblWeishu.Text = "-  位"
        '
        'lblVolt
        '
        Me.lblVolt.AutoSize = True
        Me.lblVolt.Location = New System.Drawing.Point(98, 61)
        Me.lblVolt.Name = "lblVolt"
        Me.lblVolt.Size = New System.Drawing.Size(35, 14)
        Me.lblVolt.TabIndex = 10
        Me.lblVolt.Text = "-  V"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 14)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "插座位数"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 14)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "电压规格"
        '
        'cmbUnitNo
        '
        Me.cmbUnitNo.FormattingEnabled = True
        Me.cmbUnitNo.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbUnitNo.Location = New System.Drawing.Point(95, 12)
        Me.cmbUnitNo.Name = "cmbUnitNo"
        Me.cmbUnitNo.Size = New System.Drawing.Size(79, 22)
        Me.cmbUnitNo.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 14)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "单元编号"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(908, 68)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(70, 78)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "第四步：填写试验信息"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(351, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 50)
        Me.Label27.TabIndex = 28
        Me.Label27.Text = "第三步：确定试验产品参数"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(36, 59)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 50)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "第二步：选择寿命试验单元"
        '
        'btnStartCancel
        '
        Me.btnStartCancel.Location = New System.Drawing.Point(1265, 130)
        Me.btnStartCancel.Name = "btnStartCancel"
        Me.btnStartCancel.Size = New System.Drawing.Size(67, 28)
        Me.btnStartCancel.TabIndex = 32
        Me.btnStartCancel.Text = "取 消"
        Me.btnStartCancel.UseVisualStyleBackColor = True
        '
        'btnStartOK
        '
        Me.btnStartOK.Location = New System.Drawing.Point(1265, 91)
        Me.btnStartOK.Name = "btnStartOK"
        Me.btnStartOK.Size = New System.Drawing.Size(67, 28)
        Me.btnStartOK.TabIndex = 31
        Me.btnStartOK.Text = "开 始"
        Me.btnStartOK.UseVisualStyleBackColor = True
        '
        'OneSec
        '
        Me.OneSec.Interval = 1300
        '
        'OneMin
        '
        Me.OneMin.Interval = 60000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNexthour)
        Me.GroupBox2.Controls.Add(Me.btnlasthour)
        Me.GroupBox2.Controls.Add(Me.lblTime)
        Me.GroupBox2.Controls.Add(Me.btnCheck)
        Me.GroupBox2.Controls.Add(Me.cmbTestNo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1389, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(500, 934)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "数据查询区"
        '
        'btnNexthour
        '
        Me.btnNexthour.Location = New System.Drawing.Point(337, 98)
        Me.btnNexthour.Name = "btnNexthour"
        Me.btnNexthour.Size = New System.Drawing.Size(32, 25)
        Me.btnNexthour.TabIndex = 25
        Me.btnNexthour.Text = ">"
        Me.btnNexthour.UseVisualStyleBackColor = True
        '
        'btnlasthour
        '
        Me.btnlasthour.Location = New System.Drawing.Point(110, 98)
        Me.btnlasthour.Name = "btnlasthour"
        Me.btnlasthour.Size = New System.Drawing.Size(32, 25)
        Me.btnlasthour.TabIndex = 24
        Me.btnlasthour.Text = "<"
        Me.btnlasthour.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(212, 103)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(56, 14)
        Me.lblTime.TabIndex = 23
        Me.lblTime.Text = "Label36"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(295, 49)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(103, 25)
        Me.btnCheck.TabIndex = 22
        Me.btnCheck.Text = "检  索"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'cmbTestNo
        '
        Me.cmbTestNo.FormattingEnabled = True
        Me.cmbTestNo.Location = New System.Drawing.Point(98, 49)
        Me.cmbTestNo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTestNo.Name = "cmbTestNo"
        Me.cmbTestNo.Size = New System.Drawing.Size(107, 22)
        Me.cmbTestNo.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 54)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 14)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "试验编号"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 135)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(486, 792)
        Me.DataGridView1.TabIndex = 19
        '
        'Label35
        '
        Me.Label35.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label35.Font = New System.Drawing.Font("隶书", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(0, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(1098, 54)
        Me.Label35.TabIndex = 42
        Me.Label35.Text = "苏 州 半 导 体 总 厂 — 光 电 耦 合 器 寿 命 台 管 理 软 件"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1098, 881)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "光电耦合器寿命台管理软件"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.grp操作.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OneSec As System.Windows.Forms.Timer
    Friend WithEvents OneMin As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbl操作员 As System.Windows.Forms.Label
    Friend WithEvents lbl例试编号 As System.Windows.Forms.Label
    Friend WithEvents lbl标准号 As System.Windows.Forms.Label
    Friend WithEvents lbl生产批号 As System.Windows.Forms.Label
    Friend WithEvents lbl器件类型 As System.Windows.Forms.Label
    Friend WithEvents lbl产品型号 As System.Windows.Forms.Label
    Friend WithEvents lbl座子类型 As System.Windows.Forms.Label
    Friend WithEvents lbl电压规格 As System.Windows.Forms.Label
    Friend WithEvents lbl单元编号 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents cmbTestNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn启动试验 As System.Windows.Forms.Button
    Friend WithEvents grp操作 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblWeishu As System.Windows.Forms.Label
    Friend WithEvents lblVolt As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbUnitNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents txtMax As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblPos As System.Windows.Forms.Label
    Friend WithEvents lblChipWeishu As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txt质量等级 As System.Windows.Forms.TextBox
    Friend WithEvents txt生产批号 As System.Windows.Forms.TextBox
    Friend WithEvents txt标准号 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt试验编号 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnStartCancel As System.Windows.Forms.Button
    Friend WithEvents btnStartOK As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnResume As System.Windows.Forms.Button
    Friend WithEvents SwitchLight As LeoControls.SwitchLight
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblDown As System.Windows.Forms.Label
    Friend WithEvents lblUp As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblStartup As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents btnlasthour As System.Windows.Forms.Button
    Friend WithEvents btnNexthour As System.Windows.Forms.Button

End Class
