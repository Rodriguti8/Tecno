Imports datos
Imports entidad
Public Class Form1
    Dim fu As New FUsuario
    Dim eu As New EUsuario

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_ingre_Click(sender As Object, e As EventArgs) Handles btn_ingre.Click
        Try
            If txt_usuario.Text <> "" And txt_contra.Text <> "" Then
                Dim dt As New DataTable

                eu._users = txt_usuario.Text
                eu._passwords = txt_contra.Text
                dt = fu.validarusuario(eu)
                If dt.Rows.Count > 0 Then
                    Timer1.Start()

                    Dim nivel As String
                    nivel = dt.Rows(0)("nivel")
                    If nivel = "usuario" Then
                        Usuario.Show()
                    End If
                    If nivel = "administrador" Then
                        Administrador.Show()
                    End If
                    If nivel = "secretario" Then
                        Secretario.Show()
                    End If
                End If
                End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Me.Hide()
        End If
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class
