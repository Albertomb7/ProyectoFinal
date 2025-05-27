using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader; // Puedes quitarlo si no lo usas
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using static ProyectoFinal.datosUsuarios; // Quita esta línea si no la necesitas específicamente. Es mejor llamar a los métodos estáticos con el nombre de la clase: datosUsuarios.Metodo()

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
            // Puedes dejar este método vacío si no necesitas realizar acciones al cargar el formulario.
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Asumo que es txt_usuario_TextChanged
        {
            // Limpia los errores si ya no existen
            if (!string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                // La variable 'valido' se maneja principalmente en el click del botón.
                // Aquí solo limpiamos el aspecto visual del error.
                LimpiarErroresVisuales(txt_usuario, error_usuario, borde_usuario);
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            // Limpia los errores si ya no existen
            if (!string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                // La variable 'valido' se maneja principalmente en el click del botón.
                // Aquí solo limpiamos el aspecto visual del error.
                LimpiarErroresVisuales(txt_contraseña, error_contraseña, borde_contraseña);
            }
        }

        private void lbl_inicio_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // Esta variable 'valido' debería ser una variable de instancia si se refiere al estado de validación del formulario,
        // o una variable local dentro de button1_Click.
        // Si es para la lógica de validación del botón, es mejor que sea local al método.
        // static bool valido = true; // Considera hacerlo una variable local en button1_Click

        private void button1_Click(object sender, EventArgs e) // Este es btn_iniciar_sesion_Click
        {
            bool esValidoEsteIntento = true; // Variable local para la validación de este clic

            // Limpiar errores visuales previos de este intento
            LimpiarErroresVisuales(txt_usuario, error_usuario, borde_usuario);
            LimpiarErroresVisuales(txt_contraseña, error_contraseña, borde_contraseña);

            // Validacion espacio en blanco en el usuario 
            if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                MostrarErroresVisuales(txt_usuario, error_usuario, "Este campo es obligatorio.", borde_usuario);
                esValidoEsteIntento = false;
            }

            // Validacion de espacios en blanco en contraseña
            if (string.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                MostrarErroresVisuales(txt_contraseña, error_contraseña, "Este campo es obligatorio.", borde_contraseña);
                esValidoEsteIntento = false;
            }

            // Si alguno de los campos está vacío, no continuar
            if (!esValidoEsteIntento)
            {
                return;
            }

            // Si las validaciones de campos vacíos pasaron, proceder con la autenticación
            // Hashea la contraseña ingresada
            string ePassIngresada = encrip.GetShga256(txt_contraseña.Text);

            // --- INICIO DE LA SOLUCIÓN INTEGRADA ---
            // Llamar a IniciarSesion que devuelve un objeto Persona completo
            // Asegúrate que tu clase 'datosUsuarios' tenga un using para 'ProyectoFinal' si 'Persona' está allí,
            // o que 'Persona' sea accesible. Si 'Persona' es una clase interna de 'datosUsuarios', la llamada es correcta.
            datosUsuarios.Persona personaDesdeBD = datosUsuarios.IniciarSesion(txt_usuario.Text);

            if (personaDesdeBD != null) // Verifica si el usuario existe
            {
                if (ePassIngresada == personaDesdeBD.ePass) // Verifica la contraseña
                {
                    // El usuario y contraseña son correctos.
                    // Poblar SesionActual con los datos de personaDesdeBD
                    SesionActual.IdUsuario = personaDesdeBD.id;
                    SesionActual.Usuario = personaDesdeBD.usuario; // Usar el nombre de usuario de la BD para consistencia
                    SesionActual.Nombre = personaDesdeBD.nombre;
                    SesionActual.Correo = personaDesdeBD.correo;
                    SesionActual.ModoOscuroPreferido = personaDesdeBD.ModoOscuro; // Obtener la preferencia de tema directamente

                    // Limpiar campos del formulario de login
                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";

                    // Abrir el formulario principal (Inicio)
                    // Asegúrate que el namespace Calendario sea correcto o que Inicio sea accesible.
                    ProyectoFinal.Calendario.Inicio FormInicio = new ProyectoFinal.Calendario.Inicio(this);
                    FormInicio.Show();
                    this.Hide(); // Ocultar el formulario de login
                }
                else
                {
                    // Contraseña incorrecta
                    MessageBox.Show("Contraseña incorrecta, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_contraseña.Select(); // Poner el foco en el campo de contraseña
                    MostrarErroresVisuales(txt_contraseña, error_contraseña, "Contraseña incorrecta.", borde_contraseña);
                    // esValidoEsteIntento ya sería false si se usa el ref bool, o no es necesario aquí si solo mostramos el error.
                }
            }
            else
            {
                // El usuario no existe
                MessageBox.Show("El usuario ingresado no existe, intente nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_usuario.Select(); // Poner el foco en el campo de usuario
                MostrarErroresVisuales(txt_usuario, error_usuario, "Usuario no existe.", borde_usuario);
            }
            // --- FIN DE LA SOLUCIÓN INTEGRADA ---
        }

        // Modificado para no depender de la variable 'valido' de la clase, ya que su manejo era confuso.
        // Esta función ahora solo se encarga del aspecto visual.
        private void MostrarErroresVisuales(System.Windows.Forms.TextBox txt, ErrorProvider error, string mensaje, Panel borde)
        {
            borde.Visible = true;
            error.SetError(txt, mensaje);
        }

        // Modificado para no depender de la variable 'valido' de la clase.
        private void LimpiarErroresVisuales(System.Windows.Forms.TextBox txt, ErrorProvider error, Panel borde)
        {
            borde.Visible = false;
            error.SetError(txt, "");
        }


        // ---- MÉTODOS ANTIGUOS CON 'ref bool valido' (si decides mantener la variable de clase 'valido') ----
        // Si prefieres el sistema anterior con 'static bool valido', puedes descomentar estos
        // y comentar los MostrarErroresVisuales/LimpiarErroresVisuales de arriba.
        // Y también descomentar 'static bool valido = true;'
        /*
        private void MostrarErrores(System.Windows.Forms.TextBox txt, ErrorProvider error, string mensaje, Panel borde, ref bool validoRef)
        {
            borde.Visible = true;
            error.SetError(txt, mensaje);
            validoRef = false;
        }

        private void LimpiarErrores(System.Windows.Forms.TextBox txt, ErrorProvider error, Panel borde, ref bool validoRef)
        {
            borde.Visible = false;
            error.SetError(txt, "");
            // No se cambia validoRef a true aquí generalmente, se resetea al inicio del intento de validación.
            // Pero tu código original lo ponía a true:
            // validoRef = true;
        }
        */
        // ---- FIN DE MÉTODOS ANTIGUOS ----


        private void label1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void lbl_user_Click(object sender, EventArgs e) { }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Asumo que es linklbl_registrarse_LinkClicked
        {
            registro RegistroForm = new registro();
            // Manejo mejorado para mostrar el formulario de login cuando registro se cierra
            this.Hide(); // Oculta login ANTES de mostrar registro
            RegistroForm.FormClosed += (s, args) => {
                // Verificar si el formulario de login fue dispuesto (por ejemplo, si la aplicación se cerró)
                if (!this.IsDisposed)
                {
                    this.Show();
                }
            };
            RegistroForm.Show();
            // No necesitas this.Hide() de nuevo aquí.
        }

        private void button1_Click_1(object sender, EventArgs e) // Asumo que es btn_ver_contraseña_Click
        {
            txt_contraseña.UseSystemPasswordChar = !txt_contraseña.UseSystemPasswordChar;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imageFolderPath = Path.Combine(basePath, @"..\..\Recursos\Imagenes\");

            string imageName = txt_contraseña.UseSystemPasswordChar ? "icon_mostrar.png" : "icon_ocultar.png";
            string rutaImagenCompleta = Path.GetFullPath(Path.Combine(imageFolderPath, imageName));

            if (File.Exists(rutaImagenCompleta))
            {
                btn_ver_contraseña.Image = Image.FromFile(rutaImagenCompleta);
            }
            else
            {
                Console.WriteLine($"Imagen no encontrada: {rutaImagenCompleta}");
                // Considera mostrar un MessageBox o usar una imagen por defecto si no se encuentra.
            }
            txt_contraseña.Select();
        }

        private void btn_iniciar_sesion_KeyPress(object sender, KeyPressEventArgs e) { }
    }
}