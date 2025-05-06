using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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
            bool valido = true;

            //Validacion de espacios en blanco
            if (string.IsNullOrWhiteSpace(txt_nombre_registro.Text) || string.IsNullOrWhiteSpace(txt_usuario_registro.Text) || string.IsNullOrWhiteSpace(txt_contraseña_registro.Text) || string.IsNullOrWhiteSpace(txt_telefono_registro.Text))
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "Los campos no pueden estar vacios";
                AjustarLabel();
                valido = false;
            }

            //Validacion los caracteres especiaales en el nombre
            else if (txt_nombre_registro.Text.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "El nombre solo puede contener letras";
                AjustarLabel();
                valido = false;
            }

            //Validacion de cantidad de caracteres del nombre de usuario
            else if (txt_usuario_registro.Text.Length > 10)
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "Nombre de usuario demasiado largo";
                AjustarLabel();
                valido = false;
            }

            //Validar longitud de la contraseña
            else if(txt_contraseña_registro.Text.Length < 8){
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "La contraseña debe contener minimo 8 caracteres";
                AjustarLabel();
                valido = false;
            }

            //Validacion de los caracteres especiales en los numeros de telefono
            else if (txt_telefono_registro.Text.Any(ch => !char.IsDigit(ch) && !char.IsWhiteSpace(ch)))
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "El telefono solo puede contener numeros";
                AjustarLabel();
                valido = false;
            }

            //Validacion de la longitud del numero de telefono
            else if(txt_telefono_registro.Text.Length != 8) 
            {
                lbl_informacion.Visible = true;
                lbl_informacion.Text = "El numero debe contener 8 caracteres";
                AjustarLabel();
                valido = false;
            }


            //Se cumple cuando pasa todas las validaciones
            else if (valido)
            {
                lbl_informacion.Visible = false;

                Persona persona = new Persona();

                persona.usuario = txt_usuario_registro.Text;

                persona.nombre = txt_nombre_registro.Text;

                string Pass = txt_contraseña_registro.Text;

                persona.ePass = encrip.GetShga256(Pass);

                int UsuarioExistente = VerificarUsuarioExistente(persona);

                if (UsuarioExistente == 1)
                {
                    int registro1 = datosUsuarios.CrearUsuario(persona);
                    if (registro1 == 1)
                    {
                        MessageBox.Show("Usuario registrado con exito", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form registro = new login();
                        registro.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al crear el usuario");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado ya existe, ingrese uno diferente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_usuario_registro.Select();
                }
            }

            
        }

        private void registro_Load(object sender, EventArgs e)
        {
            //Carga de eventos
            this.txt_usuario_registro.KeyPress += new KeyPressEventHandler(txt_usuario_registro_KeyPress);
            this.txt_usuario_registro.KeyPress += new KeyPressEventHandler(txt_usuario_registro_TextChanged);

            this.txt_contraseña_registro.KeyPress += new KeyPressEventHandler(txt_contrasenia_registro_KeyPress);
            this.txt_contraseña_registro.KeyPress += new KeyPressEventHandler(txt_contrasenia_registro_TextChanged);

            this.txt_telefono_registro.KeyPress += new KeyPressEventHandler(txt_telefono_registro_KeyPress);
            this.txt_telefono_registro.KeyPress += new KeyPressEventHandler(txt_telefono_registro_TextChanged);
        }

        private void txt_telefono_registro_TextChanged(object sender, EventArgs e)
        {
            //Bloquea espacios en blanco que se pegan

            TextBox textBox = (TextBox)sender;
            int pos = textBox.SelectionStart;

            string sinEspacios = textBox.Text.Replace(" ", "");

            if (textBox.Text != sinEspacios)
            {
                textBox.Text = sinEspacios;
                textBox.SelectionStart = pos > 0 ? pos - 1 : 0;
            }
        }


        private void txt_telefono_registro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bloquea los espacios en blanco escritos desde el teclado

            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void lbl_telefono_registro_Click(object sender, EventArgs e)
        {

        }



        private void txt_contrasenia_registro_TextChanged(object sender, EventArgs e)
        {
            //Bloquea espacios en blanco que se pegan

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
            //Bloquea los espacios en blanco escritos desde el teclado

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
            //Bloquea espacios en blanco que se pegan

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
            //Bloquea los espacios en blanco escritos desde el teclado

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

        //Funcion para centrar el label de informacion
        private void AjustarLabel()
        {
            int Ubicacion_centrar = 218; 
            lbl_informacion.AutoSize = true; 
            lbl_informacion.Left = Ubicacion_centrar - (lbl_informacion.Width / 2);
        }

        private void btn_ver_contraseña_Click(object sender, EventArgs e)
        {
            txt_contraseña_registro.UseSystemPasswordChar = !txt_contraseña_registro.UseSystemPasswordChar;

            if (txt_contraseña_registro.UseSystemPasswordChar == false)
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_ocultar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña_registro.Image = Image.FromFile(rutaImagen);
            }
            else
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_mostrar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña_registro.Image = Image.FromFile(rutaImagen);
            }
        }
    }
}
