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
    public partial class codigoDeVerificacion : Form
    {
        
        private registro _registro;

        public codigoDeVerificacion(registro registro)
        {
            InitializeComponent();
            _registro = registro;           
        }


        public codigoDeVerificacion()
        {
            InitializeComponent();
        }
         

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (txt1.Text.Any(ch => char.IsDigit(ch))) {
                txt2.Focus();
            }
                
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (txt2.Text.Any(ch => char.IsDigit(ch)))
            {
                txt3.Focus();
            }
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (txt3.Text.Any(ch => char.IsDigit(ch)))
            {
                txt4.Focus();
            }
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            if (txt1.Text.Any(ch => char.IsDigit(ch)))
            {
                btn_verificar.Focus();
            }
        }


        private void btn_verificar_Click(object sender, EventArgs e)
        {

            //Codigo ingresado en las cajas de texto
            string codigo = txt1.Text + txt2.Text + txt3.Text + txt4.Text;

            //Codigo generado aleatoreamente
            string CodigoEnviado = enviarCodigo.CodigoEnviado;
            
           //Compara si son los mismos codigos
            if (codigo == CodigoEnviado)
            {

                Persona persona = new Persona();

                persona.usuario = _registro.TextoUsuario;

                persona.nombre = _registro.TextoNombre;

                persona.correo = _registro.TextoCorreo;

                string Pass = _registro.TextoContraseña;

                persona.ePass = encrip.GetShga256(Pass);

                int UsuarioExistente = VerificarUsuarioExistente(persona);

                if (UsuarioExistente == 1)
                {
                    int registro1 = datosUsuarios.CrearUsuario(persona);
                    if (registro1 == 1)
                    {
                        MessageBox.Show("Usuario registrado con exito", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form login = new login();
                        login.Show();
                        this.Close();
                        _registro.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al crear el usuario");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado ya existe, ingrese uno diferente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            else
            {
                MessageBox.Show("el codigo ingresado no coincide", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
