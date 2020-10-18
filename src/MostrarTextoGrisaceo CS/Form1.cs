//-----------------------------------------------------------------------------
// Mostrar efecto grisáceo (deshabilitado) en las cajas de texto    (18/Oct/20)
//
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class Form1 : Form
{

    #region La definición de los controles del formulario y void Main()

    /// <summary>
    /// Punto de entrada principal para la aplicación.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }


    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexto.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTexto.Location = new System.Drawing.Point(12, 14);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(295, 20);
            this.txtTexto.TabIndex = 4;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.txtTexto.Enter += new System.EventHandler(this.txtTexto_Enter);
            this.txtTexto.Leave += new System.EventHandler(this.txtTexto_Leave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.Location = new System.Drawing.Point(313, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Saludar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(313, 106);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(12, 50);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(129, 13);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "<Escribe algo en el texto>";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 141);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelInfo);
            this.Name = "Form1";
            this.Text = "Form1 C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private System.Windows.Forms.TextBox txtTexto;
    private System.Windows.Forms.Button btnAceptar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Label labelInfo;

    #endregion

    private void Form1_Load(object sender, EventArgs e)
    {
        this.CenterToScreen();

        txtTexto.Text = textVacio;
        txtTexto.SelectionStart = 0; //txtTexto.Text.Length;
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        if( txtTexto.Text == textVacio)
            labelInfo.Text = "¡Hola amigo!";
        else
            labelInfo.Text = $"¡Hola {txtTexto.Text}!";
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    // 
    // Lo que necesitamos para hacer el efecto
    // 

    private const string textVacio = "<Escribe tu nombre>";
    private string textAnterior = textVacio;
    private bool inicializando;

    private void txtTexto_Enter(object sender, EventArgs e)
    {
        if (txtTexto.Text != textVacio)
            txtTexto.ForeColor = SystemColors.ControlText;
    }

    private void txtTexto_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtTexto.Text))
        {
            this.txtTexto.ForeColor = SystemColors.GrayText;
            this.txtTexto.Text = textVacio;
        }
    }

    private void txtTexto_TextChanged(object sender, EventArgs e)
    {
        if (inicializando)
            return;
        if (txtTexto.Text == "" || txtTexto.Text == textVacio)
        {
            txtTexto.ForeColor = SystemColors.GrayText;
            inicializando = true;
            txtTexto.Text = textVacio;
            inicializando = false;
        }
        else
        {
            if (textAnterior == textVacio)
            {
                inicializando = true;
                txtTexto.Text = QuitarPredeterminado(txtTexto.Text, textVacio);
                inicializando = false;

                txtTexto.SelectionStart = txtTexto.Text.Length;
            }
            txtTexto.ForeColor = SystemColors.ControlText;
        }
        textAnterior = txtTexto.Text;
    }

    /// <summary>
    /// Quitar de una cadena un texto indicado (que será el predeterminado cuando está vacío).
    /// Por ejemplo si el texto grisáceo es Buscar... y
    /// se empezó a escribir en medio del texto (o en cualquier parte)
    /// BuscarL... se quitará Buscar... y se dejará L.
    /// </summary>
    /// <param name="texto">El texto en el que se hará la sustitución.</param>
    /// <param name="predeterminado">El texto a quitar.</param>
    /// <returns>Una cadena con el texto predeterminado quitado.</returns>
    /// <remarks>18/Oct/2020</remarks>
    private string QuitarPredeterminado(string texto, string predeterminado)
    {
        for (var i = 0; i < predeterminado.Length; i++)
        {
            var j = texto.IndexOf(predeterminado[i]);
            if (j == -1)
                continue;
            if (j == 0)
                texto = texto.Substring(j + 1);
            else
                texto = texto.Substring(0, j) + texto.Substring(j + 1);
        }
        return texto;
    }
}
