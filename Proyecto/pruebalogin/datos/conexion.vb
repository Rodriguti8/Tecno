﻿Imports System.Data.SqlClient
Public Class conexion
    Public con As New SqlConnection
    Public cmd As New SqlCommand

    Public Function conectado()

        Try
            con = New SqlConnection(My.Settings.inicio)
            con.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
