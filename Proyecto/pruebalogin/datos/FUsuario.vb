Imports System.Data.SqlClient
Imports entidad
Public Class FUsuario
    Inherits conexion
    Public Function validarusuario(ByVal dts As EUsuario) As DataTable

        conectado()
        cmd = New SqlCommand("_iniciosesion")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = con

        cmd.Parameters.AddWithValue("@users", dts._users)
        cmd.Parameters.AddWithValue("@passwords", dts._passwords)

        If cmd.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing

        End If
    End Function
End Class
