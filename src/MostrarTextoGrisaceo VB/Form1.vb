'------------------------------------------------------------------------------
' Mostrar efecto grisáceo (deshabilitado) en las cajas de texto     (18/Oct/20)
'
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
'Imports System.Data
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Text
Imports System.Linq

Public Class Form1
    Inherits Form

#Region " Definición de los controles y Sub Main() "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent call

    End Sub

    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub

    '    'Form overrides dispose to clean up the component list.
    '    Public Overrides Sub Dispose()
    '        MyBase.Dispose()
    '        If Not (components Is Nothing) Then
    '            components.Dispose()
    '        End If
    '    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.labelInfo = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTexto
        '
        Me.txtTexto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTexto.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtTexto.Location = New System.Drawing.Point(12, 14)
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Size = New System.Drawing.Size(295, 20)
        Me.txtTexto.TabIndex = 0
        '
        'labelInfo
        '
        Me.labelInfo.AutoSize = True
        Me.labelInfo.Location = New System.Drawing.Point(12, 50)
        Me.labelInfo.Name = "labelInfo"
        Me.labelInfo.Size = New System.Drawing.Size(129, 13)
        Me.labelInfo.TabIndex = 3
        Me.labelInfo.Text = "<Escribe algo en el texto>"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.AutoSize = True
        Me.btnAceptar.Location = New System.Drawing.Point(313, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Saludar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.AutoSize = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(313, 106)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(400, 141)
        Me.Controls.Add(Me.txtTexto)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.labelInfo)
        Me.Name = "Form1"
        Me.Text = "Form1 VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    '
    ' Declaración de los controles
    '
    Private WithEvents txtTexto As TextBox
    Private labelInfo As Label
    Private WithEvents btnAceptar As Button
    Private WithEvents btnCancelar As Button

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Centrar en la pantalla
        Me.CenterToScreen()

        ' Aceptar comprobaci n de teclas
        Me.KeyPreview = True

        txtTexto.Text = textVacio
        txtTexto.SelectionStart = 0 'txtTexto.Text.Length
    End Sub

    Private Sub Form1_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Cuando se cierra el formulario

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Detectar teclas

    End Sub

    Private Sub btnAceptar_Click() Handles btnAceptar.Click
        If txtTexto.Text = textVacio Then
            labelInfo.Text = "¡Hola amigo!"
        Else
            labelInfo.Text = $"¡Hola {txtTexto.Text}!"
        End If
    End Sub

    Private Sub btnCancelar_Click() Handles btnCancelar.Click
        Me.Close()
    End Sub

    '
    ' Lo que necesitamos para hacer el efecto
    '

    Private Const textVacio As String = "<Escribe tu nombre>"
    Private textAnterior As String = textVacio
    Private inicializando As Boolean

    Private Sub txtTexto_Enter(sender As Object, e As EventArgs) Handles txtTexto.Enter
        If txtTexto.Text <> textVacio Then
            txtTexto.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtTexto_Leave(sender As Object, e As EventArgs) Handles txtTexto.Leave
        If String.IsNullOrEmpty(Me.txtTexto.Text) Then '
            Me.txtTexto.ForeColor = SystemColors.GrayText
            Me.txtTexto.Text = textVacio
        End If
    End Sub

    Private Sub txtTexto_TextChanged(sender As Object,
                                           e As EventArgs) Handles txtTexto.TextChanged
        If inicializando Then Return
        If txtTexto.Text = "" OrElse txtTexto.Text = textVacio Then
            txtTexto.ForeColor = SystemColors.GrayText
            inicializando = True
            txtTexto.Text = textVacio
            inicializando = False
        Else
            If textAnterior = textVacio Then
                inicializando = True
                txtTexto.Text = QuitarPredeterminado(txtTexto.Text, textVacio)
                inicializando = False

                txtTexto.SelectionStart = txtTexto.Text.Length

            End If
            txtTexto.ForeColor = SystemColors.ControlText
        End If
        textAnterior = txtTexto.Text
    End Sub

    ''' <summary>
    ''' Quitar de una cadena un texto indicado (que será el predeterminado cuando está vacío).
    ''' Por ejemplo si el texto grisáceo es Buscar... y
    ''' se empezó a escribir en medio del texto (o en cualquier parte)
    ''' BuscarL... se quitará Buscar... y se dejará L.
    ''' Antes de hacer cambios se comprueba si el texto predeterminado está al completo 
    ''' en el texto en el que se hará el cambio.
    ''' </summary>
    ''' <param name="texto">El texto en el que se hará la sustitución.</param>
    ''' <param name="predeterminado">El texto a quitar.</param>
    ''' <returns>Una cadena con el texto predeterminado quitado.</returns>
    ''' <remarks>18/Oct/2020 actualizado 24/Oct/2020</remarks>
    Public Function QuitarPredeterminado(texto As String, predeterminado As String) As String
        Dim cuantos = predeterminado.Length
        Dim k = 0

        For i = 0 To predeterminado.Length - 1
            Dim j = texto.IndexOf(predeterminado(i))
            If j = -1 Then Continue For
            k += 1
        Next
        ' si k es distinto de cuantos es que no están todos lo caracteres a quitar
        If k <> cuantos Then
            Return texto
        End If

        For i = 0 To predeterminado.Length - 1
            Dim j = texto.IndexOf(predeterminado(i))
            If j = -1 Then Continue For
            If j = 0 Then
                texto = texto.Substring(j + 1)
            Else
                texto = texto.Substring(0, j) & texto.Substring(j + 1)
            End If
        Next

        Return texto
    End Function

End Class

