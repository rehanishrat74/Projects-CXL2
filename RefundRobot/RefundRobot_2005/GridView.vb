Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.String

Public Class GridView

    Inherits DataGridTextBoxColumn

    Public Sub New()
        'Warning: Implementation not found
    End Sub
    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

        ' the idea is to conditionally set the foreBrush and/or backbrush
        ' depending upon some crireria on the cell value
        ' Here, we color anything that contains ":"
        Try
            Dim o As Object
            If (IsDBNull(Me.GetColumnValueAtRow(source, rowNum)) = True) Then
                o = Nothing
            Else
                o = Me.GetColumnValueAtRow(source, rowNum)

            End If

            If (Not (o) Is Nothing) Then

                Dim c As String

                If (IsDBNull(CType(o, String)) = True) Then
                    c = ""
                Else
                    c = CType(o, String)
                End If

                ' Dim i As Integer = c.LastIndexOf(":")

                ' If (i <> -1) Then
                backBrush = New SolidBrush(Color.Red)
                foreBrush = New SolidBrush(Color.Red)

                'End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            ' make sure the base class gets called to do the drawing with
            ' the possibly changed brushes
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        End Try

    End Sub


End Class
