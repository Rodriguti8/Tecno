Imports System.Data.SqlClient
Public Class Administrador
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

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Sentencia = "Delete From crud where id = '" + txt_id.Text + "'"
        Mensaje = "Registro Eliminado correctamente."
        ejecutarsql(Sentencia, Mensaje)
        Try
            Dim da As New SqlDataAdapter("Select *From crud", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DTGV_admin.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_mostrar_Click(sender As Object, e As EventArgs) Handles btn_mostrar.Click
        Try
            Dim da As New SqlDataAdapter("Select *From crud", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DTGV_admin.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Dim da As New SqlDataAdapter("Select *From crud Where ID = '" + txt_buscar.Text + "'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        Me.DTGV_admin.DataSource = ds.Tables(0)
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Hide()
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Sentencia = "Insert into crud VALUES ('" + txt_id.Text + "','" + txt_nombre.Text + "','" + txt_apellido.Text + "','" + txt_tel.Text + "')"
        Mensaje = "Datos Insertados correctamente."
        ejecutarsql(Sentencia, Mensaje)
        Try
            Dim da As New SqlDataAdapter("Select *From crud", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DTGV_admin.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class