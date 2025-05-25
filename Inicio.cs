// Inicio.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CalendarioApp; // Namespace de UcDias
using System.Drawing.Drawing2D;
// using static ProyectoFinal.datosUsuarios; // Evitar using static si no es estrictamente necesario para este archivo

namespace ProyectoFinal.Calendario
{
    public partial class Inicio : Form
    {
        int mes, año;
        private Form formularioLogin;
        DateTime diaActual = DateTime.Now;

        private bool isDarkMode; // Ya no se inicializa aquí, se carga desde SesionActual

        // Definiciones de colores para temas (sin cambios respecto a la versión anterior)
        private readonly Color dark_FormBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_FormForeColor = Color.White;
        private readonly Color dark_LabelDayNamesColor = Color.FromArgb(200, 200, 200);
        private readonly Color dark_UcDiasEmptyBackColor = Color.FromArgb(20, 22, 28);
        private readonly Color dark_ListBoxBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_PanelConfiguracionBackColor = Color.FromArgb(14, 17, 23); // Debería ser más oscuro que el form
        private readonly Color dark_ButtonBackColor = Color.FromArgb(40, 43, 50); // Un color para botones en modo oscuro

        private readonly Color light_FormBackColor = SystemColors.Control;
        private readonly Color light_FormForeColor = Color.Black;
        private readonly Color light_LabelDayNamesColor = Color.FromArgb(70, 70, 70);
        private readonly Color light_UcDiasEmptyBackColor = Color.FromArgb(240, 240, 240);
        private readonly Color light_ListBoxBackColor = SystemColors.Window;
        private readonly Color light_PanelConfiguracionBackColor = SystemColors.ControlLight;
        private readonly Color light_ButtonBackColor = SystemColors.ControlLight;



        private Evento _eventoSeleccionadoEnLista;
        private List<Evento> listaDeEventosGlobal = new List<Evento>();

        public Inicio()
        {
            InitializeComponent();
        }

        public Inicio(Form login) : this()
        {
            formularioLogin = login;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (SesionActual.IdUsuario <= 0)
            {
                MessageBox.Show("Error: No se ha iniciado sesión correctamente. Volviendo al login.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                formularioLogin?.Show();
                //this.Close(); // Cierra este formulario
                return;
            }

            // Cargar la preferencia de tema del usuario actual
            isDarkMode = SesionActual.ModoOscuroPreferido; //

            DateTime hoy = DateTime.Today;
            mes = hoy.Month;
            año = hoy.Year;
            diaActual = hoy;

            AplicarTema(); // Aplicar el tema cargado
            CargarEventosDelMesActual();
            ActualizarVistaEventosHoy();
            MostrarDias();

            if (lblUsuarioInicial != null) lblUsuarioInicial.Text = SesionActual.Usuario;
            if (lbl_id != null) lbl_id.Text = SesionActual.IdUsuario.ToString();

            if (lstMostrarEventosInicio != null) lstMostrarEventosInicio.SelectedIndex = -1;
            if (btnEliminar != null) btnEliminar.Enabled = false;
            if (btnEditarEvento != null) btnEditarEvento.Enabled = false;
        }

        private void CargarEventosDelMesActual()
        {
            listaDeEventosGlobal.Clear();
            if (año == 0 || mes == 0 || SesionActual.IdUsuario <= 0) return;

            try
            {
                listaDeEventosGlobal = Evento.ObtenerEventosDelMes(SesionActual.IdUsuario, año, mes); //
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar eventos del mes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaDeEventosGlobal.Clear();
            }
        }

        private void ActualizarVistaEventosHoy()
        {
            if (lblFechaDelEvento != null)
            {
                lblFechaDelEvento.Text = $"{diaActual:dd} de {diaActual:MMMM} de {diaActual:yyyy}";
            }

            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.DataSource = null;
                List<Evento> eventosDelDiaSeleccionado = listaDeEventosGlobal
                    .Where(ev => ev.Fecha.Date == diaActual.Date) //
                    .OrderBy(ev => ev.Hora ?? TimeSpan.MaxValue)
                    .ThenBy(ev => ev.Descripcion)
                    .ToList();

                if (eventosDelDiaSeleccionado.Any())
                {
                    lstMostrarEventosInicio.DataSource = eventosDelDiaSeleccionado;
                    // lstMostrarEventosInicio.DisplayMember = "ToString"; // Asegurar que se usa ToString() para mostrar
                }
                else
                {
                    lstMostrarEventosInicio.Items.Clear();
                    lstMostrarEventosInicio.Items.Add("No hay eventos para este día.");
                }
                lstMostrarEventosInicio.SelectedIndex = -1;
            }
        }

        private void AplicarTema()
        {
            Color formBackColor, formForeColor, labelDayNamesColor, listBoxBackColor, panelConfigBackColor, ucDiasEmptyBackColor;
            // Removido buttonBackColor ya que los botones principales tienen su propio estilo o son transparentes.

            if (isDarkMode)
            {
                formBackColor = dark_FormBackColor;
                formForeColor = dark_FormForeColor;
                labelDayNamesColor = dark_LabelDayNamesColor;
                ucDiasEmptyBackColor = dark_UcDiasEmptyBackColor; //
                listBoxBackColor = dark_ListBoxBackColor; //
                panelConfigBackColor = dark_PanelConfiguracionBackColor; //
                                                                         // buttonBackColor = dark_ButtonBackColor;
                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo Claro";
            }
            else
            {
                formBackColor = light_FormBackColor;
                formForeColor = light_FormForeColor;
                labelDayNamesColor = light_LabelDayNamesColor;
                ucDiasEmptyBackColor = light_UcDiasEmptyBackColor; //
                listBoxBackColor = light_ListBoxBackColor; //
                panelConfigBackColor = light_PanelConfiguracionBackColor; //
                                                                          // buttonBackColor = light_ButtonBackColor;
                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo Oscuro";
            }

            this.BackColor = formBackColor;
            this.ForeColor = formForeColor;

            if (lblFecha != null) lblFecha.ForeColor = formForeColor;
            if (lblFechaDelEvento != null) lblFechaDelEvento.ForeColor = formForeColor;


            Control[] labelsInfoUsuario = { lblUsuarioInicial, lbl_id, lbl_usuarioInformacion, lbl_idInformacion };
            foreach (var lbl in labelsInfoUsuario)
            {
                if (lbl != null) lbl.ForeColor = formForeColor;
            }


            Control[] dayLabels = { lblLunes, lblMartes, lblMiercoles, lblJueves, lblViernes, lblSabado, lblDomingo };
            foreach (var lbl in dayLabels)
            {
                if (lbl != null) lbl.ForeColor = labelDayNamesColor;
            }

            if (flDays != null) flDays.BackColor = formBackColor; // El fondo del flow layout panel

            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.BackColor = listBoxBackColor;
                lstMostrarEventosInicio.ForeColor = formForeColor;
            }

            if (pnConfiguracion != null)
            {
                pnConfiguracion.BackColor = panelConfigBackColor;
                // Aplicar color de texto a los labels dentro de pnConfiguracion también
                foreach (Control ctl in pnConfiguracion.Controls)
                {
                    if (ctl is Label)
                    {
                        ctl.ForeColor = formForeColor;
                    }
                }
            }

            if (btnCambioDeColorFondo != null)
            {
                // btnCambioDeColorFondo.BackColor = buttonBackColor; // Se mantiene el color de DimGray/ControlLight como antes
                btnCambioDeColorFondo.ForeColor = formForeColor;
            }
            if (btnCerrarSesion != null)
            {
                btnCerrarSesion.ForeColor = Color.White; // Siempre blanco para contraste con fondo rojo
            }

           
            Control[] imageButtons = { btnAjustes, btnGestionarEventosDia, btnEditarEvento, btnEliminar, pbAnterior, pbSiguiente };
            foreach (var btn in imageButtons)
            {
                if (btn != null)
                {
                    // Si los PictureBox de flechas necesitan cambiar su imagen para el tema:
                    if (btn == pbAnterior)
                    {
                        // pbAnterior.Image = isDarkMode ? Resources.AnteriorDark : Resources.AnteriorLight;
                    }
                    else if (btn == pbSiguiente)
                    {
                        // pbSiguiente.Image = isDarkMode ? Resources.SiguienteDark : Resources.SiguienteLight;
                    }
                    // Para otros botones, si tienen texto además de imagen, el ForeColor se aplica.
                    // Si son solo imagen, .
                    btn.ForeColor = formForeColor; 
                }
            }
        }

        private void btnCambioDeColorFondo_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            AplicarTema(); // Aplica el nuevo tema visualmente

            // Guardar la nueva preferencia en la base de datos
            try
            {
                datosUsuarios.ActualizarPreferenciasTema(SesionActual.IdUsuario, isDarkMode);
                SesionActual.ModoOscuroPreferido = isDarkMode; // Actualizar también en la sesión actual
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la preferencia de tema: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            MostrarDias(); // Redibujar UcDias con el nuevo tema y sus colores base
            ActualizarVistaEventosHoy();
        }

        private void MostrarDias()
        {
            if (flDays == null || lblFecha == null) return;
            if (año == 0 || mes == 0)
            {
                lblFecha.Text = "Fecha no disponible";
                return;
            }

            flDays.SuspendLayout();
            flDays.Controls.Clear();

            DateTime primerDiaDelMes = new DateTime(año, mes, 1);
            int diasEnMes = DateTime.DaysInMonth(año, mes);
            int diaSemanaPrimerDia = (int)primerDiaDelMes.DayOfWeek;
            int espaciosVacios = (diaSemanaPrimerDia == 0) ? 6 : diaSemanaPrimerDia - 1;

            lblFecha.Text = $"{primerDiaDelMes:MMMM yyyy}".ToUpper();


            int scrollBarWidthApproximation = SystemInformation.VerticalScrollBarWidth; // Para mayor precisión
            if (!flDays.VerticalScroll.Visible) // Solo restar si la barra no está visible (pero se espera que aparezca)
            {
                
                scrollBarWidthApproximation = 0;
            }


            int availableWidth = flDays.ClientSize.Width - flDays.Padding.Horizontal; // Usar ClientSize
            int availableHeight = flDays.ClientSize.Height - flDays.Padding.Vertical;

            int cols = 7;
            
            int rowsNeeded = (int)Math.Ceiling((double)(espaciosVacios + diasEnMes) / cols);


            int anchoDia = Math.Max(20, (availableWidth / cols) - (flDays.Margin.Horizontal / cols)); // Ajuste por márgenes si los hay
            int altoDia = 90; // O calcular basado en availableHeight / rowsNeeded si no hay scroll

            
            if (anchoDia <= 20) anchoDia = 100; // Aumentado para mejor apariencia
            if (altoDia <= 20) altoDia = 80; // Aumentado

            Color ucDiasEmptyBackColor = isDarkMode ? dark_UcDiasEmptyBackColor : light_UcDiasEmptyBackColor;

            for (int i = 0; i < espaciosVacios; i++)
            {
                Panel panelVacio = new Panel
                {
                    Width = anchoDia,
                    Height = altoDia,
                    Margin = new Padding(1), // Margen entre celdas
                    BackColor = ucDiasEmptyBackColor, // Color de tema para celdas vacías
                    // BorderStyle = BorderStyle.FixedSingle // Opcional
                };
                flDays.Controls.Add(panelVacio);
            }

            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                UcDias diaControl = new UcDias();
                DateTime fechaActualCelda = new DateTime(año, mes, dia);

                diaControl.Dia = dia.ToString();
                diaControl.FechaCelda = fechaActualCelda;
                diaControl.Width = anchoDia;
                diaControl.Height = altoDia;

                diaControl.AplicarTema(isDarkMode); //  Aplicar tema a cada UcDias


                // Redondear bordes (este código es cosmético) BHUAAAAAA XD
                try
                {
                    GraphicsPath path = new GraphicsPath();
                    int radio = 8;
                    path.AddArc(0, 0, radio, radio, 180, 90);
                    path.AddArc(diaControl.Width - radio, 0, radio, radio, 270, 90);
                    path.AddArc(diaControl.Width - radio, diaControl.Height - radio, radio, radio, 0, 90);
                    path.AddArc(0, diaControl.Height - radio, radio, radio, 90, 90);
                    path.CloseFigure();
                    diaControl.Region = new Region(path);
                }
                catch (Exception exRegion)
                {
                    Console.WriteLine("Error aplicando región a UcDias: " + exRegion.Message);
                }


                var eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == fechaActualCelda.Date).ToList(); //
                diaControl.CantidadEventos = eventosDelDia.Count; //

                var eventoConColor = eventosDelDia.FirstOrDefault(ev => ev.ColorPersonalizado.HasValue); //
                var eventoParaIndicador = eventoConColor ?? eventosDelDia.FirstOrDefault(); //

                if (eventoParaIndicador != null)
                {
                    diaControl.TieneEvento = true; //
                    diaControl.ColorPersonalizado = eventoParaIndicador.ColorPersonalizado; //
                }
                else
                {
                    diaControl.TieneEvento = false; //
                    diaControl.ColorPersonalizado = null; //
                }

                diaControl.DiaClickeado += UcDias_DiaClickeado; //
                flDays.Controls.Add(diaControl);
            }
            flDays.ResumeLayout();
        }

        private void UcDias_DiaClickeado(object sender, EventArgs e)
        {
            if (sender is UcDias diaControlClickeado)
            {
                this.diaActual = diaControlClickeado.FechaCelda; //
                ActualizarVistaEventosHoy();
                if (lstMostrarEventosInicio != null) lstMostrarEventosInicio.SelectedIndex = -1; // Deseleccionar
                if (btnEliminar != null) btnEliminar.Enabled = false;
                if (btnEditarEvento != null) btnEditarEvento.Enabled = false;
            }
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            mes--;
            if (mes < 1)
            {
                mes = 12;
                año--;
            }
            CargarEventosDelMesActual();
            MostrarDias();
           
            ActualizarVistaEventosHoy(); // Para el diaActual que esté seleccionado
        }

        private void pbSiguiente_Click(object sender, EventArgs e)
        {
            mes++;
            if (mes > 12)
            {
                mes = 1;
                año++;
            }
            CargarEventosDelMesActual();
            MostrarDias();
            ActualizarVistaEventosHoy();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            if (pnConfiguracion != null)
            {
                pnConfiguracion.Visible = !pnConfiguracion.Visible;
            }
        }

        private void lstMostrarEventosInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventoSeleccionadoEnLista = lstMostrarEventosInicio.SelectedItem as Evento; //

            if (btnEditarEvento != null) btnEditarEvento.Enabled = (_eventoSeleccionadoEnLista != null);
            if (btnEliminar != null) btnEliminar.Enabled = (_eventoSeleccionadoEnLista != null);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de cerrar sesión?",
                                    "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionActual.LimpiarSesion(); // Limpiar los datos de la sesión
                this.Hide();
                formularioLogin?.Show();
                this.Close(); // Cierra este formulario para que no quede en memoria
            }
        }

        private void btnGestionarEventosDia_Click(object sender, EventArgs e)
        {
            List<Evento> eventosParaDialogo = listaDeEventosGlobal
               .Where(ev => ev.Fecha.Date == this.diaActual.Date) //
               .ToList();

            using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosParaDialogo)) //
            {
                DialogResult resultado = frmEvento.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    CargarEventosDelMesActual();
                    ActualizarVistaEventosHoy();
                    MostrarDias();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_eventoSeleccionadoEnLista != null)
            {
                if (MessageBox.Show($"¿Seguro que quieres eliminar el evento: '{_eventoSeleccionadoEnLista.Descripcion}'?",
                                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultadoEliminacion = Evento.EliminarEvento(_eventoSeleccionadoEnLista); //
                    if (resultadoEliminacion > 0)
                    {
                        MessageBox.Show("Evento eliminado con éxito.", "Evento Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarEventosDelMesActual();
                        ActualizarVistaEventosHoy();
                        MostrarDias();
                       
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si el formulario de login está visible, no salgas de la aplicación.
            if (formularioLogin != null && formularioLogin.Visible)
            {
                return;
            }

            if ((formularioLogin == null || !formularioLogin.Visible))
            {
                // Verificar si el cierre fue intencional o por error de sesión
                if (SesionActual.IdUsuario > 0) // Si hay sesión activa, es probable que sea un cierre de la app
                {
                    Application.Exit();
                }
                
            }
        }

        private void btnEditarEvento_Click(object sender, EventArgs e)
        {
            if (_eventoSeleccionadoEnLista != null)
            {
                List<Evento> eventosDelDiaActual = listaDeEventosGlobal
                   .Where(ev => ev.Fecha.Date == this.diaActual.Date) //
                   .ToList();

                // Usar el constructor que acepta un evento para editar
                using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosDelDiaActual, _eventoSeleccionadoEnLista)) //
                {
                    DialogResult resultado = frmEvento.ShowDialog(this);
                    if (resultado == DialogResult.OK)
                    {
                        CargarEventosDelMesActual();
                        ActualizarVistaEventosHoy();
                        MostrarDias();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un evento de la lista para editarlo.", "Ningún Evento Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Eventos vacíos que pueden eliminarse si no se usan y no están en el Designer Da  igual si se borran 
        private void lblJueves_Click(object sender, EventArgs e) { }
        private void lblMiercoles_Click(object sender, EventArgs e) { }
        private void lblMartes_Click(object sender, EventArgs e) { }
        private void lblUsuarioInicial_Click(object sender, EventArgs e) { }
        private void pnConfiguracion_Paint(object sender, PaintEventArgs e) { }
        private void lblFechaDelEvento_Click(object sender, EventArgs e) { }
        private void flDays_Paint(object sender, PaintEventArgs e) { }

    }
}