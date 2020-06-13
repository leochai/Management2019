Imports LeoControls

Public Class frmPosChart4
    Dim cell(23) As FourCell
    Public unitNo As Byte
    Public pos(95) As Byte

    Private Sub frmPosChart4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For j = 0 To 3
            For i = 0 To 5
                cell(6 * j + i) = New FourCell
                cell(6 * j + i).Left = 30 + 200 * i
                cell(6 * j + i).Top = 40 + 140 * j
                cell(6 * j + i).Parent = Me
                cell(6 * j + i).CellLabel = (6 * j + i + 1).ToString
            Next
        Next
        For i = 0 To 95
            pos(i) = 0
        Next
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        For i = 0 To 23
            cell(i).Reset()
        Next
    End Sub

    Private Sub btnAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        autonum()
    End Sub

    Private Sub autonum()
        Dim a As String

        For i = 0 To 23
            If cell(i).isUsed Then
                If cell(i).CellNum = "" Then
                    a = 1
                Else
                    a = cell(i).CellNum
                End If
                Exit For
            End If
        Next

        For i = 0 To 23
            If cell(i).isUsed Then
                cell(i).CellNum = a
                a += 1
            End If
        Next
    End Sub
    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        For i = 0 To 23
            If cell(i).isUsed And cell(i).CellNum = "" Then
                MsgBox("有未编号器件，请点击自动编号",, "提醒")
                Exit Sub
            End If
        Next
        For i = 0 To 23
            For j = 0 To 3
                If cell(i).isUsed Then
                    pos(i * 4 + j) = cell(i).CellNum
                End If
            Next
        Next
        For i = 0 To 95
            If pos(i) <> 0 Then
                frmMain.unitTemp.对位表 = pos
                frmMain.lblPos.Text = "器件插放完成"
                frmMain.lblPos.ForeColor = Color.Blue
                frmMain.Panel4.Enabled = True
                frmMain.Panel4.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                Exit For
            End If
        Next

        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click
        For i = 0 To 23
            cell(i).SetTrue()
        Next
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        For i = 0 To 5
            cell(i).SetTrue()
        Next
    End Sub
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        For i = 6 To 11
            cell(i).SetTrue()
        Next
    End Sub
    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        For i = 12 To 17
            cell(i).SetTrue()
        Next
    End Sub
    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        For i = 18 To 23
            cell(i).SetTrue()
        Next
    End Sub
End Class