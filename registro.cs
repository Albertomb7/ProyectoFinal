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
            bool valido = false;

            //Validacion de espacios en blanco
            if (string.IsNullOrWhiteSpace(txt_nombre_registro.Text) || string.IsNullOrWhiteSpace(txt_usuario_registro.Text) || string.IsNullOrWhiteSpace(txt_contraseña_registro.Text) || string.IsNullOrWhiteSpace(txt_telefono_registro.Text))
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "Los campos no pueden estar vacios";
                valido = false;
            }
            //Validacion de cantidad de caracteres del nombre de usuario
            else if (txt_usuario_registro.Text.Length > 10)
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "Nombre de usuario demasiado largo";
                valido = false;
            }
            //Validacion de la longitud del numero de telefono
            else if(txt_telefono_registro.Text.Length != 8) 
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "El numero debe contener 8 caracteres";
                valido = false;
            }

            

            else if (valido == true)
            {
                Persona persona = new Persona();

                persona.usuario = txt_usuario_registro.Text;
                persona.nombre = txt_nombre_registro.Text;

                string Pass = txt_contraseña_registro.Text;

                persona.ePass = encrip.GetShga256(Pass);

                int registro1 = datosUsuarios.CrearUsuario(persona);
                if (registro1 == 1)
                {
                    MessageBox.Show("Se creo el usuario con exito");
                }
                else
                {
                    MessageBox.Show("Hubo un error al crear el usuario");
                }

                Form registro = new login();
                registro.Show();
                this.Close();
            }

            
        }

        private void txt_telefono_registro_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_telefono_registro_Click(object sender, EventArgs e)
        {

        }

        private void registro_Load(object sender, EventArgs e)
        {
            this.txt_usuario_registro.KeyPress += new KeyPressEventHandler(txt_usuario_registro_KeyPress);
            this.txt_usuario_registro.KeyPress += new KeyPressEventHandler(txt_usuario_registro_TextChanged);

            this.txt_contraseña_registro.KeyPress += new KeyPressEventHandler(txt_contrasenia_registro_KeyPress);
            this.txt_contraseña_registro.KeyPress += new KeyPressEventHandler(txt_contrasenia_registro_TextChanged);
        }


        private void txt_contrasenia_registro_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int pos = textBox.SelectionStart;

            string sinEspacios = textBox.Text.Replace(" ", "");

            if (textBox.Text != sinEspacios)
            {
                textBox.Text = sinEspacios;
                textBox.SelectionStart = pos > 0 ? pos - 1 : 0;
            }
        }

        private void txt_contrasenia_registro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        private void lbl_contrasenia_registro_Click(object sender, EventArgs e)
        {

        }

        private void txt_usuario_registro_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int pos = textBox.SelectionStart;

            string sinEspacios = textBox.Text.Replace(" ", "");

            if (textBox.Text != sinEspacios)
            {
                textBox.Text = sinEspacios;
                textBox.SelectionStart = pos > 0 ? pos - 1 : 0;
            }
        }

        private void txt_usuario_registro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
