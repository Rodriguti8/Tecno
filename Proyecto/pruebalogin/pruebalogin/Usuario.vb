Imports System.Data.SqlClient
Public Class Usuario
    Public con As New SqlConnection(My.Settings.conexion)
    Public Sentencia, Mensaje As String
    Sub ejecutarsql(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New SqlCommand(sql, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Hide()
    End Sub

    Private Sub btn_mostrar_Click(sender As Object, e As EventArgs) Handles btn_mostrar.Click
        Try
            Dim da As New SqlDataAdapter("Select *From crud", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DTGV_usuario.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Dim da As New SqlDataAdapter("Select *From admin Where ID = '" + txt_buscar.Text + "'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        Me.DTGV_usuario.DataSource = ds.Tables(0)
    End Sub
End Class