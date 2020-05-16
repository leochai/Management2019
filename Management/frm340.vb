Public Class frm340
    Public unitNo As Byte
    Private lblpos As New ArrayList


    Private Sub frm340_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = "老化单元-" & unitNo + 1 & "器件插放情况"
        If _unit(unitNo).座子类型 Then   '四位
            Me.Width = 470
            Me.Height = 300
            Label1.Left = (Me.Width - Label1.Width) / 2
            btnOk.Left = 300
            btnCancel.Left = 370
            For j = 0 To 3
                For i = 0 To 5
                    Dim lbl As New Label
                    With lbl
                        .Width = 60
                        .Height = 40
                        .Left = 60 * i + 50
                        .Top = 40 * j + 50
                        .TabIndex = j * 6 + i
                        .BorderStyle = BorderStyle.FixedSingle
                        .Parent = Me
                        .TextAlign = ContentAlignment.MiddleCenter
                        If _unit(unitNo).对位表((j * 6 + i) * 4) <> 0 Then
                            .Text = _unit(unitNo).对位表((j * 6 + i) * 4)
                        Else
                            .Text = ""
                        End If
                        .ForeColor = Color.Blue
                        .Font = New Font("微软雅黑", 12)
                    End With
                    AddHandler lbl.Click, AddressOf LblControlArrayClick
                    lblpos.Add(lbl)
                Next
            Next
        ElseIf _unit(unitNo).器件类型 = 3 And unitNo >= 24 Then '独立器件
            Me.Width = 1550
            Me.Height = 300
            Label1.Left = (Me.Width - Label1.Width) / 2
            btnOk.Left = 1380
            btnCancel.Left = 1450
            For j = 0 To 3
                For i = 0 To 23
                    Dim lbl As New Label
                    With lbl
                        .Width = 60
                        .Height = 40
                        .Left = 60 * i + 50
                        .Top = 40 * j + 50
                        .TabIndex = j * 12 + i
                        .BorderStyle = BorderStyle.FixedSingle
                        .Parent = Me
                        .TextAlign = ContentAlignment.MiddleCenter
                        If _unit(unitNo).对位表(j * 24 + i) <> 0 Then
                            .Text = _unit(unitNo).对位表(j * 12 + i)
                        Else
                            .Text = ""
                        End If
                        .ForeColor = Color.Blue
                        .Font = New Font("微软雅黑", 12)
                    End With
                    AddHandler lbl.Click, AddressOf LblControlArrayClick
                    lblpos.Add(lbl)
                Next
            Next
        Else '单位器件
            Me.Width = 830
            Me.Height = 300
            Label1.Left = (Me.Width - Label1.Width) / 2
            btnOk.Left = 660
            btnCancel.Left = 730
            For j = 0 To 3
                For i = 0 To 11
                    Dim lbl As New Label
                    With lbl
                        .Width = 60
                        .Height = 40
                        .Left = 60 * i + 50
                        .Top = 40 * j + 50
                        .TabIndex = j * 12 + i
                        .BorderStyle = BorderStyle.FixedSingle
                        .Parent = Me
                        .TextAlign = ContentAlignment.MiddleCenter
                        If _unit(unitNo).对位表((j * 12 + i) * 2) <> 0 Then
                            .Text = _unit(unitNo).对位表((j * 12 + i) * 2)
                        Else
                            .Text = ""
                        End If
                        .ForeColor = Color.Blue
                        .Font = New Font("微软雅黑", 12)
                    End With
                    AddHandler lbl.Click, AddressOf LblControlArrayClick
                    lblpos.Add(lbl)
                Next
            Next
        End If
    End Sub

    Private Sub LblControlArrayClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim no As Integer
        no = CType(sender, Label).TabIndex
        If lblpos(no).Text = "" Then
            Exit Sub
        End If

        If lblpos(no).forecolor = Color.Blue Then
            lblpos(no).Forecolor = Color.Red
            lblpos(no).Font = New Font("微软雅黑", 12, FontStyle.Strikeout)
        Else
            lblpos(no).Forecolor = Color.Blue
            lblpos(no).Font = New Font("微软雅黑", 12, FontStyle.Regular)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If _unit(unitNo).座子类型 Then
            For i = 0 To 23
                If lblpos(i).Forecolor = Color.Red Then
                    _unit(unitNo).对位表(i * 4) = 0
                    _unit(unitNo).对位表(i * 4 + 1) = 0
                    _unit(unitNo).对位表(i * 4 + 2) = 0
                    _unit(unitNo).对位表(i * 4 + 3) = 0
                End If
            Next
        ElseIf _unit(unitNo).器件类型 = 3 And unitNo >= 24 Then
            For i = 0 To 95
                If lblpos(i).Forecolor = Color.Red Then
                    _unit(unitNo).对位表(i) = 0
                End If
            Next
        Else
            For i = 0 To 47
                If lblpos(i).Forecolor = Color.Red Then
                    _unit(unitNo).对位表(i * 2) = 0
                End If
            Next
        End If
        _commFlag.unitNo_start = unitNo
        _commFlag.startup = True
        me.Dispose
    End Sub
End Class