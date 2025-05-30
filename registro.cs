﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Options;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ProyectoFinal.datosUsuarios;

namespace ProyectoFinal
{
    public partial class registro : Form
    {
   

        public registro()
        {
            InitializeComponent();
            this.AcceptButton = btn_registrarse;
        }

        public string TextoNombre => txt_nombre_registro.Text;
        public string TextoUsuario => txt_usuario_registro.Text;
        public string TextoCorreo => txt_correo_registro.Text;
        public string TextoContraseña => txt_contraseña_registro.Text;

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

        static bool valido = true;
        private void btn_registrarse_Click(object sender, EventArgs e)
        {
            

            //Limpia todos los errores
            LimpiarErrores(txt_nombre_registro, lbl_informacion_nombre, error_provider_nombre, borde_nombre, ref valido);
            LimpiarErrores(txt_usuario_registro, lbl_informacion_usuario, error_provider_usuario, borde_usuario, ref valido);
            LimpiarErrores(txt_contraseña_registro, lbl_informacion_contraseña, error_provider_contraseña, borde_contraseña, ref valido);
            LimpiarErrores(txt_correo_registro, lbl_informacion_correo, error_provider_correo, borde_correo, ref valido);
            bool CorreoValido = VerificarCorreo(txt_correo_registro.Text);

            //Validacion de espacios en blanco en el nombre
            if (string.IsNullOrWhiteSpace(txt_nombre_registro.Text))
            {
                MostrarErrores(txt_nombre_registro, lbl_informacion_nombre, error_provider_nombre, "Este campo es obligatorio.", borde_nombre, ref valido);              
                
            }


            //Validacion espacio en blanco en el usuario 
            if (string.IsNullOrWhiteSpace(txt_usuario_registro.Text))
            {
                MostrarErrores(txt_usuario_registro, lbl_informacion_usuario, error_provider_usuario, "Este campo es obligatorio.", borde_usuario, ref valido);
                
            }

            //Validacion de espacios en blanco en contraseña
            if (string.IsNullOrWhiteSpace(txt_contraseña_registro.Text))
            {
                MostrarErrores(txt_contraseña_registro, lbl_informacion_contraseña, error_provider_contraseña, "Este campo es obligatorio.", borde_contraseña, ref valido);

            }

            //Validacion de espacios en blanco en el telefono
            if (string.IsNullOrWhiteSpace(txt_correo_registro.Text))
            {
                MostrarErrores(txt_correo_registro, lbl_informacion_correo, error_provider_correo, "Este campo es obligatorio.", borde_correo, ref valido);

            }

            else if (CorreoValido == false)
            {
                MostrarErrores(txt_correo_registro, lbl_informacion_correo, error_provider_correo, "Direccion de correo invalida.", borde_correo, ref valido);
            }

            //Se cumple cuando pasa todas las validaciones y envia el codigo al correo ingresado
            else if (valido)
            {
                Persona persona = new Persona();

                persona.usuario = txt_usuario_registro.Text;
                persona.correo = txt_correo_registro.Text;

                int UsuarioExistente = VerificarUsuarioExistente(persona);
                int CorreoExistente = VerificarCorreoExistente(persona);

                if (UsuarioExistente == 1 && CorreoExistente == 1)
                {

                    enviarCodigo.EnviarCodigo(txt_correo_registro.Text);

                    //Abre el formulario de verificacion
                    codigoDeVerificacion formVerificacion = new codigoDeVerificacion(this);
                    formVerificacion.Show();
                    this.Hide();

                   
                    formVerificacion.FormClosed += (s, args) => this.Show();
                    this.Hide();
                }
                if(UsuarioExistente == 0)
                {
                     MostrarErrores(txt_usuario_registro, lbl_informacion_usuario, error_provider_usuario, "El usuario ya existe, ingrese uno diferente.", borde_usuario, ref valido);
                }
                if(CorreoExistente == 0){
                    MostrarErrores(txt_correo_registro, lbl_informacion_correo, error_provider_correo, "El correo electronico ya esta registrado, ingrese uno diferente.", borde_correo, ref valido);
                }
            }

        }

        
        private bool VerificarCorreo(string correo)
        {
            try
            {
                var direccion = new MailAddress(correo);
                return true;
            }
            catch { 
                return false;
            }
        }


        //Funcion para mostrar errores en los datos ingresados 
        private void MostrarErrores(System.Windows.Forms.TextBox txt, Label lbl, ErrorProvider error, string mensaje, Panel borde, ref bool valido)
        {
            lbl.Text = mensaje;
            lbl.Visible = true; 
            borde.Visible = true;
            error.SetError(txt, "error");
            AjustarLabel(lbl);
            valido = false;
        }

        //Funcion para ocultar la informacion de los errores 
        private void LimpiarErrores(System.Windows.Forms.TextBox txt, Label lbl, ErrorProvider error, Panel borde, ref bool valido)
        {
            lbl.Visible = false;
            borde.Visible = false;
            error.SetError(txt, "");
            valido = true;
        }


        private void registro_Load(object sender, EventArgs e)
        {
            //Carga de eventos
            this.txt_usuario_registro.KeyPress += new KeyPressEventHandler(txt_usuario_registro_KeyPress);
            this.txt_usuario_registro.KeyPress += new KeyPressEventHandler(txt_usuario_registro_TextChanged);

            this.txt_contraseña_registro.KeyPress += new KeyPressEventHandler(txt_contrasenia_registro_KeyPress);
            this.txt_contraseña_registro.KeyPress += new KeyPressEventHandler(txt_contraseña_registro_TextChanged);

            this.txt_correo_registro.KeyPress += new KeyPressEventHandler(txt_correo_registro_KeyPress);
            this.txt_correo_registro.KeyPress += new KeyPressEventHandler(txt_correo_registro_TextChanged);
        }

        private void txt_correo_registro_TextChanged(object sender, EventArgs e)
        {
            //Bloquea espacios en blanco que se pegan

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            int pos = textBox.SelectionStart;

            string sinEspacios = textBox.Text.Replace(" ", "");

            if (textBox.Text != sinEspacios)
            {
                textBox.Text = sinEspacios;
                textBox.SelectionStart = pos > 0 ? pos - 1 : 0;
            }


            bool CorreoValido = VerificarCorreo(txt_correo_registro.Text); 

            //Limpia los errores si ya no existen
            if(txt_correo_registro.Text.Any(ch => char.IsDigit(ch) && char.IsWhiteSpace(ch)))
            {
                LimpiarErrores(txt_correo_registro, lbl_informacion_correo, error_provider_correo, borde_correo, ref valido);
            }

            if(CorreoValido == true)
            {
                LimpiarErrores(txt_correo_registro, lbl_informacion_correo, error_provider_correo, borde_correo, ref valido);
            }

            

        }


        private void txt_correo_registro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bloquea los espacios en blanco escritos desde el teclado 

            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void lbl_correo_registro_Click(object sender, EventArgs e)
        {

        }



        private void txt_contraseña_registro_TextChanged(object sender, EventArgs e)
        {
            //Bloquea espacios en blanco que se pegan

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            int pos = textBox.SelectionStart;

            string sinEspacios = textBox.Text.Replace(" ", "");

            if (textBox.Text != sinEspacios)
            {
                textBox.Text = sinEspacios;
                textBox.SelectionStart = pos > 0 ? pos - 1 : 0;
            }
            //Validar longitud de la contraseña
            if (txt_contraseña_registro.Text.Length < 7)
            {
                MostrarErrores(txt_contraseña_registro, lbl_informacion_contraseña, error_provider_contraseña, "Contraseña insegura.", borde_contraseña, ref valido);

            }
            //Limpia los errores si ya no existen
            if (!string.IsNullOrWhiteSpace(txt_contraseña_registro.Text) && txt_contraseña_registro.Text.Length > 8)
            {
                LimpiarErrores(txt_contraseña_registro, lbl_informacion_contraseña, error_provider_contraseña, borde_contraseña, ref valido);
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

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            int pos = textBox.SelectionStart;

            string sinEspacios = textBox.Text.Replace(" ", "");

            if (textBox.Text != sinEspacios)
            {
                textBox.Text = sinEspacios;
                textBox.SelectionStart = pos > 0 ? pos - 1 : 0;
            }

            //Limpia errores
            if(!string.IsNullOrWhiteSpace(txt_usuario_registro.Text) && txt_usuario_registro.Text.Length < 10) { 
            LimpiarErrores(txt_usuario_registro, lbl_informacion_usuario, error_provider_usuario, borde_usuario, ref valido);
            }

            //Validacion de cantidad de caracteres del nombre de usuario
            if (txt_usuario_registro.Text.Length > 10)
            {
                MostrarErrores(txt_usuario_registro, lbl_informacion_usuario, error_provider_usuario, "Usuario demasiado largo, maximo 10 caracteres.", borde_usuario, ref valido);

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
            //Validacion los caracteres especiaales en el nombre
            if (txt_nombre_registro.Text.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
            {
                MostrarErrores(txt_nombre_registro, lbl_informacion_nombre, error_provider_nombre, "El nombre solo puede contener letras.", borde_nombre, ref valido);


            }


            if (!string.IsNullOrWhiteSpace(txt_nombre_registro.Text) && txt_nombre_registro.Text.All(ch => char.IsLetter(ch) || char.IsWhiteSpace(ch) && !char.IsDigit(ch)))
            {
                LimpiarErrores(txt_nombre_registro, lbl_informacion_nombre, error_provider_nombre, borde_nombre, ref valido);
            }
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
        private void AjustarLabel(Label lbl)
        {
            int Ubicacion_centrar = 205; 
            lbl.AutoSize = true; 
            lbl.Left = Ubicacion_centrar - (lbl.Width / 2);
        }

        private void btn_ver_contraseña_Click(object sender, EventArgs e)
        {
            txt_contraseña_registro.UseSystemPasswordChar = !txt_contraseña_registro.UseSystemPasswordChar;

            if (txt_contraseña_registro.UseSystemPasswordChar == false)
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_ocultar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña_registro.Image = Image.FromFile(rutaImagen);
                txt_contraseña_registro.Select();
            }
            else
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_mostrar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña_registro.Image = Image.FromFile(rutaImagen);
                txt_contraseña_registro.Select();
            }
        }

        private void registro_Load_1(object sender, EventArgs e)
        {

        }
    }
}
