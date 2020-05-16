Imports LeoControls

Public Class frmPosChart1
    Dim cell(47) As OneCell
    Public unitNo As Byte
    Public pos(95) As Byte

    Private Sub frmPosChart1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For j = 0 To 3
            For i = 0 To 11
                cell(12 * j + i) = New OneCell
                cell(12 * j + i).Left = 30 + 100 * i
                cell(12 * j + i).Top = 40 + 140 * j
                cell(12 * j + i).Parent = Me
                cell(12 * j + i).CellLabel = (12 * j + i + 1).ToString
            Next
        Next

        For i = 0 To 95
            pos(i) = 0
        Next
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        For i = 0 To 47
            cell(i).Reset()
        Next
    End Sub

    Private Sub btnAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        Dim a As String

        For i = 0 To 47
            If cell(i).isUsed Then
                If cell(i).CellNum = "" Then
                    a = 1
                Else
                    a = cell(i).CellNum
                End If
                Exit For
            End If
        Next

        For i = 0 To 47
            If cell(i).isUsed Then
                cell(i).CellNum = a
                a += 1
            End If
        Next
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        For i = 0 To 47
            If cell(i).isUsed And cell(i).CellNum = "" Then
                MsgBox("有未编号器件，请点击自动编号",, "提醒")
                Exit Sub
            End If
        Next
        For i = 0 To 47
            If cell(i).isUsed Then
                pos(i * 2) = cell(i).CellNum
            End If
        Next
        For i = 0 To 95
            If pos(i) <> 0 Then
                For j = 0 To 95
                    frmMain.unitTemp.对位表(j) = pos(j)
                Next
                frmMain.lblPos.Text = "器件插放完成"
                frmMain.lblPos.ForeColor = Color.Blue
                frmMain.Panel4.Enabled = True
                frmMain.Panel4.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                Exit For
            End If
        Next

        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click
        For i = 0 To 47
            cell(i).SetTrue()
        Next
    End Sub
End Class