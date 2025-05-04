using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            string ePass = encrip.GetShga256(txt_contrasenia.Text);

            Persona persona = new Persona();
            persona.usuario = txt_usuario.Text;

            datosUsuarios.IniciarSesion(persona);

            if (ePass == persona.ePass)
            {
                Form login = new Inicio();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos incorrectos, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            txt_contrasenia.UseSystemPasswordChar = !txt_contrasenia.UseSystemPasswordChar;

            if(txt_contrasenia.UseSystemPasswordChar == false)
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_ocultar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña.Image = Image.FromFile(rutaImagen);
            }
            else
            {
                string rutaImagen = Path.Combine(Application.StartupPath, @"..\..\Recursos\Imagenes\icon_mostrar.png");
                rutaImagen = Path.GetFullPath(rutaImagen);
                btn_ver_contraseña.Image = Image.FromFile(rutaImagen);
            }
        }
    }
}
