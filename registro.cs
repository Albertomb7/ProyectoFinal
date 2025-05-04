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
            persona.nombre = txt_nombre_registro.Text;

            string Pass = txt_contrasenia_registro.Text;

            persona.ePass = encrip.GetShga256(Pass);

            int registro1 = datosUsuarios.CrearUsuario(persona);
            if (registro1 == 1) {
                MessageBox.Show("Se creo el usuario con exito");
            }
            else {
                MessageBox.Show("Hubo un error al crear el usuario");
            } 

            Form registro = new login();
            registro.Show();
            this.Close();
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
    }
}
