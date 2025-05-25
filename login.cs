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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            this.AcceptButton = btn_iniciar_sesion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Limpia los errores si ya no existen
            if (!string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                LimpiarErrores(txt_usuario, error_usuario, borde_usuario, ref valido);
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            //Limpia los errores si ya no existen
            if (!string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                LimpiarErrores(txt_contraseña, error_contraseña, borde_contraseña, ref valido);
            }
        }

        private void lbl_inicio_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        static bool valido = true;
        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarErrores(txt_usuario, error_usuario, borde_usuario, ref valido);
            LimpiarErrores(txt_contraseña, error_contraseña, borde_contraseña, ref valido);


            //Validacion espacio en blanco en el usuario 
            if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                MostrarErrores(txt_usuario, error_usuario, "Este campo es obligatorio.", borde_usuario, ref valido);

            }

            //Validacion de espacios en blanco en contraseña
            if (string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                MostrarErrores(txt_contraseña, error_contraseña, "Este campo es obligatorio.", borde_contraseña, ref valido);

            }


            else if (valido)
            {
                //Hashea la contraseña ingresada
                string ePass = encrip.GetShga256(txt_contraseña.Text);

                Persona persona = new Persona();
                persona.usuario = txt_usuario.Text;

                //Obtiene el valor que retorna la funcion para verificar el usuario existente
                int UsuarioExistente = VerificarUsuarioExistente(persona);


                //Si el usuario si existe permite continuar
                if (UsuarioExistente == 0)
                {

                    datosUsuarios.IniciarSesion(persona);


                    if (ePass == persona.ePass)
                    {
                        //Obtiene el id y el usuario para saber que usuario va agregar eventos
                        int id = ObtenerIdSesionActual(txt_usuario.Text);
                        

                        SesionActual.IdUsuario = id;
                        SesionActual.Usuario = txt_usuario.Text;

                        //Limpia los campos de texto 
                        txt_usuario.Text = "";
                        txt_contraseña.Text = "";

                        Form FormInicio = new Calendario.Inicio(this);
                        FormInicio.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_contraseña.Select();
                    }
                }

                //Si el usuario no existe muestra el mensaje de error 
                else
                {
                    MessageBox.Show("El usuario ingresado no existe, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_usuario.Select();
                }
            }
        }

        private void MostrarErrores(System.Windows.Forms.TextBox txt, ErrorProvider error, string mensaje, Panel borde, ref bool valido)
        {
            borde.Visible = true;
            error.SetError(txt, mensaje);
            valido = false;
        }

        //Funcion para ocultar la informacion de los errores 
        private void LimpiarErrores(System.Windows.Forms.TextBox txt, ErrorProvider error, Panel borde, ref bool valido)
        {
            borde.Visible = false;
            error.SetError(txt, "");
            valido = true;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_user_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registro RegistroForm = new registro();  
            RegistroForm.Show();                   
            this.Hide();

            RegistroForm.FormClosed += (s, args) => this.Show();
            this.Hide();       
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txt_contraseña.UseSystemPasswordChar = !txt_contraseña.UseSystemPasswordChar;

            if(txt_contraseña.UseSystemPasswordChar == false)
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_ocultar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña.Image = Image.FromFile(rutaImagen);
                txt_contraseña.Select();
            }
            else
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_mostrar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña.Image = Image.FromFile(rutaImagen);
                txt_contraseña.Select();
            }
        }

        private void btn_iniciar_sesion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
