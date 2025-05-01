using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoFinal.datosUsuarios;

namespace ProyectoFinal
{
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_registro_Click(object sender, EventArgs e)
        {

        }

        private void btn_registrarse_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.usuario = txt_usuario_registro.Text;
            persona.contraseña = txt_contrasenia_registro.Text; 

            datosUsuarios.CrearUsuario(persona);
        }

        private void txt_telefono_registro_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_telefono_registro_Click(object sender, EventArgs e)
        {

        }

        private void txt_contrasenia_registro_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_contrasenia_registro_Click(object sender, EventArgs e)
        {

        }

        private void txt_usuario_registro_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_usuario_registro_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombre_registro_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_nombre_registro_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
