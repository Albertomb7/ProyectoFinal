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
using ProyectoFinal.Calendario; // Para poder instanciar Inicio



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

        private void textBox1_TextChanged(object sender, EventArgs e) // txt_usuario_TextChanged
        {
            if (!string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                LimpiarErrores(txt_usuario, error_usuario, borde_usuario, ref valido);
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                LimpiarErrores(txt_contraseña, error_contraseña, borde_contraseña, ref valido);
            }
        }

        private void lbl_inicio_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        static bool valido = true; 
        private void button1_Click(object sender, EventArgs e) // Asumo que este es btn_iniciar_sesion_Click
        {
            valido = true; 
            LimpiarErrores(txt_usuario, error_usuario, borde_usuario, ref valido);
            LimpiarErrores(txt_contraseña, error_contraseña, borde_contraseña, ref valido);


            if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                MostrarErrores(txt_usuario, error_usuario, "Este campo es obligatorio.", borde_usuario, ref valido);
            }

            if (string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                MostrarErrores(txt_contraseña, error_contraseña, "Este campo es obligatorio.", borde_contraseña, ref valido);
            }

            if (!valido) // Si alguna validación de campos vacíos falló
            {
                return;
            }

           

            string ePassIngresada = encrip.GetShga256(txt_contraseña.Text);
            datosUsuarios.Persona personaDesdeBD = datosUsuarios.IniciarSesion(txt_usuario.Text);

            if (personaDesdeBD != null)
            {
                if (ePassIngresada == personaDesdeBD.ePass)
                {
                    SesionActual.IdUsuario = personaDesdeBD.id;
                    SesionActual.Usuario = personaDesdeBD.usuario; // El que se usó para el login
                    SesionActual.Nombre = personaDesdeBD.nombre;
                    SesionActual.Correo = personaDesdeBD.correo;
                    SesionActual.ModoOscuroPreferido = personaDesdeBD.ModoOscuro;

                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";

                    // Pasar 'this' (el formulario de login) al constructor de Inicio
                    ProyectoFinal.Calendario.Inicio FormInicio = new ProyectoFinal.Calendario.Inicio(this);
                    FormInicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_contraseña.Select();
                    MostrarErrores(txt_contraseña, error_contraseña, "Contraseña incorrecta.", borde_contraseña, ref valido);
                    // valido se pone en false por MostrarErrores
                }
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_usuario.Select();
                MostrarErrores(txt_usuario, error_usuario, "Usuario no existe.", borde_usuario, ref valido);
                // valido se pone en false por MostrarErrores
            }
        }

        private void MostrarErrores(System.Windows.Forms.TextBox txt, ErrorProvider error, string mensaje, Panel borde, ref bool validoRef)
        {
            borde.Visible = true;
            error.SetError(txt, mensaje);
            validoRef = false; // Indica que hubo un error
        }

        private void LimpiarErrores(System.Windows.Forms.TextBox txt, ErrorProvider error, Panel borde, ref bool validoRef)
        {
            
            borde.Visible = false;
            error.SetError(txt, "");
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void lbl_user_Click(object sender, EventArgs e) { }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // linklbl_registrarse_LinkClicked
        {
            registro RegistroForm = new registro();
            RegistroForm.FormClosed += (s, args) => {
              
                this.Show();
            };
            RegistroForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e) // btn_ver_contraseña_Click
        {
            txt_contraseña.UseSystemPasswordChar = !txt_contraseña.UseSystemPasswordChar;

            string basePath = AppDomain.CurrentDomain.BaseDirectory; // Directorio de ejecución
            
            string imagePath = Path.Combine(basePath, @"..\..\Recursos\Imagenes\");


            if (txt_contraseña.UseSystemPasswordChar == false)
            {
                string rutaCompleta = Path.GetFullPath(Path.Combine(imagePath, "icon_ocultar.png"));
                if (File.Exists(rutaCompleta))
                    btn_ver_contraseña.Image = Image.FromFile(rutaCompleta);
                else
                    Console.WriteLine($"Imagen no encontrada: {rutaCompleta}");
            }
            else
            {
                string rutaCompleta = Path.GetFullPath(Path.Combine(imagePath, "icon_mostrar.png"));
                if (File.Exists(rutaCompleta))
                    btn_ver_contraseña.Image = Image.FromFile(rutaCompleta);
                else
                    Console.WriteLine($"Imagen no encontrada: {rutaCompleta}");
            }
            txt_contraseña.Select();
        }

        private void btn_iniciar_sesion_KeyPress(object sender, KeyPressEventArgs e) { }
    }
}