<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosChart21
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAuto = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAll
        '
        Me.btnAll.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnAll.Location = New System.Drawing.Point(1208, 1074)
        Me.btnAll.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(154, 47)
        Me.btnAll.TabIndex = 54
        Me.btnAll.Text = "全   选"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnExit.Location = New System.Drawing.Point(2072, 1074)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(154, 47)
        Me.btnExit.TabIndex = 50
        Me.btnExit.Text = "退   出"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnOK.Location = New System.Drawing.Point(1887, 1074)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(154, 47)
        Me.btnOK.TabIndex = 51
        Me.btnOK.Text = "确   定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnReset.Location = New System.Drawing.Point(1573, 1074)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(154, 47)
        Me.btnReset.TabIndex = 52
        Me.btnReset.Text = "重   置"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAuto
        '
        Me.btnAuto.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnAuto.Location = New System.Drawing.Point(1393, 1074)
        Me.btnAuto.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(154, 47)
        Me.btnAuto.TabIndex = 53
        Me.btnAuto.Text = "自动编码"
        Me.btnAuto.UseVisualStyleBackColor = True
        '
        'frmPosChart21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2317, 1194)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnAuto)
        Me.Name = "frmPosChart21"
        Me.Text = "frmPosChart21"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAll As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnAuto As Button
End Class
