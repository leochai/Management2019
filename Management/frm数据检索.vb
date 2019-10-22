'Imports System.data.OleDb

'Public Class frm数据检索
'    Private dbCmd As New OleDbCommand

'    Private Sub frm数据检索_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
'        For i = 1 To 9
'            For j = 1 To 2
'                dbCmd.CommandText = "insert into 试验结果 values ('" _
'                                    & (i * 10).ToString & _
'                                    "' , '" & i & _
'                                    "' , '" & 1 & _
'                                    "' , '" & Now & _
'                                    "' , '28.1')"
'                dbCmd.ExecuteNonQuery()
'            Next
'        Next
'    End Sub

'    Private Sub frm数据检索_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        
'    End Sub

'    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        
'    End Sub
'End Class