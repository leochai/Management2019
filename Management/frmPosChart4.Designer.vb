<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosChart4
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAuto = New System.Windows.Forms.Button()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnExit.Location = New System.Drawing.Point(1101, 617)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(84, 27)
        Me.btnExit.TabIndex = 51
        Me.btnExit.Text = "退   出"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnOK.Location = New System.Drawing.Point(1000, 617)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(84, 27)
        Me.btnOK.TabIndex = 52
        Me.btnOK.Text = "确   定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnReset.Location = New System.Drawing.Point(831, 617)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(84, 27)
        Me.btnReset.TabIndex = 49
        Me.btnReset.Text = "重   置"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAuto
        '
        Me.btnAuto.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnAuto.Location = New System.Drawing.Point(731, 617)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(84, 27)
        Me.btnAuto.TabIndex = 50
        Me.btnAuto.Text = "自动编码"
        Me.btnAuto.UseVisualStyleBackColor = True
        '
        'btnAll
        '
        Me.btnAll.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnAll.Location = New System.Drawing.Point(627, 617)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(84, 27)
        Me.btnAll.TabIndex = 53
        Me.btnAll.Text = "全   选"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn1.Location = New System.Drawing.Point(321, 617)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(51, 27)
        Me.btn1.TabIndex = 66
        Me.btn1.Text = "第1行"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn2.Location = New System.Drawing.Point(378, 617)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(51, 27)
        Me.btn2.TabIndex = 65
        Me.btn2.Text = "第2行"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn3.Location = New System.Drawing.Point(435, 617)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(51, 27)
        Me.btn3.TabIndex = 64
        Me.btn3.Text = "第3行"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn4.Location = New System.Drawing.Point(492, 617)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(51, 27)
        Me.btn4.TabIndex = 63
        Me.btn4.Text = "第4行"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'frmPosChart4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 682)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnAuto)
        Me.Name = "frmPosChart4"
        Me.Text = "插放器件"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAuto As System.Windows.Forms.Button
    Friend WithEvents btnAll As System.Windows.Forms.Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn4 As Button
End Class
