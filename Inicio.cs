// Inicio.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CalendarioApp;
using System.Drawing.Drawing2D;
using ProyectoFinal.Calendario; 


namespace ProyectoFinal.Calendario
{
    public partial class Inicio : Form
    {
        int mes, año;
        private Form formularioLogin;
        DateTime diaActual = DateTime.Now;
        bool valorAjuste = false; // No se usa, podrías considerarlo para eliminar

        // --- Inicio de cambios para el Tema ---
        private bool isDarkMode = true;

        // (Colores de tema... sin cambios aquí)
        private readonly Color dark_FormBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_FormForeColor = Color.White;
        private readonly Color dark_LabelDayNamesColor = Color.FromArgb(200, 200, 200);
        private readonly Color dark_UcDiasEmptyBackColor = Color.FromArgb(20, 22, 28);
        private readonly Color dark_ListBoxBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_PanelConfiguracionBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_ButtonBackColor = Color.FromArgb(14, 17, 23);

        private readonly Color light_FormBackColor = SystemColors.Control;
        private readonly Color light_FormForeColor = Color.Black;
        private readonly Color light_LabelDayNamesColor = Color.FromArgb(70, 70, 70);
        private readonly Color light_UcDiasEmptyBackColor = Color.FromArgb(240, 240, 240);
        private readonly Color light_ListBoxBackColor = SystemColors.Window;
        private readonly Color light_PanelConfiguracionBackColor = SystemColors.ControlLight;
        private readonly Color light_ButtonBackColor = SystemColors.ControlLight;
        // --- Fin de cambios para el Tema ---

        public Evento EventoCreadoOModificado { get; private set; }
        public Evento EventoAEliminar { get; private set; }
        // private DateTime _fechaActual;
        // private List<Evento> _eventosExistentesEnElDia; // Se carga localmente donde se necesita
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
            DateTime hoy = DateTime.Today;
            mes = hoy.Month;
            año = hoy.Year;

            AplicarTema();

           

            ActualizarVistaEventosHoy();
            MostrarDias();

            lblUsuarioInicial.Text = SesionActual.Usuario;
            lbl_id.Text = SesionActual.IdUsuario.ToString();

            lstMostrarEventosInicio.SelectedIndex = -1;
            btnEliminar.Enabled = false;
            btnEditarEvento.Enabled = false;
        }

        // ***** NUEVO MÉTODO *****
        private void CargarEventosDelMesActual()
        {
            listaDeEventosGlobal.Clear(); // Limpiar eventos anteriores para evitar duplicados
            if (año == 0 || mes == 0) return; 

            int diasEnEsteMes = DateTime.DaysInMonth(año, mes);

            for (int dia = 1; dia <= diasEnEsteMes; dia++)
            {
                DateTime fechaDelDia = new DateTime(año, mes, dia);
                // ObtenerEventosExistentes debe devolver los eventos CON su ColorPersonalizado
                List<Evento> eventosDelDia = Evento.ObtenerEventosExistentes(fechaDelDia.Date);
                if (eventosDelDia != null && eventosDelDia.Any())
                {
                    listaDeEventosGlobal.AddRange(eventosDelDia);
                }
            }
        }

        private void ActualizarVistaEventosHoy()
        {
            if (lblFechaDelEvento != null)
            {
                lblFechaDelEvento.Text = $"{diaActual.ToString("dd")} de {diaActual.ToString("MMMM", new CultureInfo("es-ES"))} {diaActual.ToString("yyyy")}";
            }
            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.DataSource = null;
                // Usar listaDeEventosGlobal filtrada para el día actual, o volver a consultar la BD si prefieres
                // List<Evento> eventosDelDia = Evento.ObtenerEventosExistentes(diaActual.Date);
                List<Evento> eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == diaActual.Date).ToList();


                if (eventosDelDia.Any())
                {
                    lstMostrarEventosInicio.DataSource = eventosDelDia;
                }
                else
                {
                    lstMostrarEventosInicio.DataSource = null;
                    lstMostrarEventosInicio.Items.Clear();
                    lstMostrarEventosInicio.Items.Add("No hay eventos para este día.");
                }
            }
        }

        // (AplicarTema y btnCambioDeColorFondo_Click sin cambios)
        private void AplicarTema()
        {
            Color formBackColor, formForeColor, labelDayNamesColor, listBoxBackColor, panelConfigBackColor, buttonBackColor;

            if (isDarkMode)
            {
                formBackColor = dark_FormBackColor;
                formForeColor = dark_FormForeColor;
                labelDayNamesColor = dark_LabelDayNamesColor;
                listBoxBackColor = dark_ListBoxBackColor;
                panelConfigBackColor = dark_PanelConfiguracionBackColor;
                buttonBackColor = dark_ButtonBackColor;

                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo claro";
            }
            else
            {
                formBackColor = light_FormBackColor;
                formForeColor = light_FormForeColor;
                labelDayNamesColor = light_LabelDayNamesColor;
                listBoxBackColor = light_ListBoxBackColor;
                panelConfigBackColor = light_PanelConfiguracionBackColor;
                buttonBackColor = light_ButtonBackColor;

                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo oscuro";
            }

            this.BackColor = formBackColor;
            this.ForeColor = formForeColor;

            if (lblFecha != null) lblFecha.ForeColor = formForeColor;
            if (lblFechaDelEvento != null) lblFechaDelEvento.ForeColor = formForeColor;
            if (lblUsuarioInicial != null) lblUsuarioInicial.ForeColor = formForeColor;

            if (lblLunes != null) lblLunes.ForeColor = labelDayNamesColor;
            if (lblMartes != null) lblMartes.ForeColor = labelDayNamesColor;
            if (lblMiercoles != null) lblMiercoles.ForeColor = labelDayNamesColor;
            if (lblJueves != null) lblJueves.ForeColor = labelDayNamesColor;
            if (lblViernes != null) lblViernes.ForeColor = labelDayNamesColor;
            if (lblSabado != null) lblSabado.ForeColor = labelDayNamesColor;
            if (lblDomingo != null) lblDomingo.ForeColor = labelDayNamesColor;

            if (flDays != null) flDays.BackColor = formBackColor;

            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.BackColor = listBoxBackColor;
                lstMostrarEventosInicio.ForeColor = formForeColor;
            }

            if (pnConfiguracion != null)
            {
                pnConfiguracion.BackColor = panelConfigBackColor;
            }

            if (btnCambioDeColorFondo != null)
            {
                btnCambioDeColorFondo.BackColor = buttonBackColor;
                btnCambioDeColorFondo.ForeColor = formForeColor;
            }
            if (btnCerrarSesion != null)
            {
                btnCerrarSesion.ForeColor = isDarkMode ? Color.Black : Color.White;
            }

            if (btnAjustes != null) btnAjustes.ForeColor = formForeColor;
            if (btnGestionarEventosDia != null) btnGestionarEventosDia.ForeColor = formForeColor;

             
        }

        private void btnCambioDeColorFondo_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            AplicarTema();
            // * CAMBIO IMPORTANTE AL CARGAR LOS EVENTOS *
         
            MostrarDias();
            ActualizarVistaEventosHoy(); // Y la lista de eventos también
        }


        private void MostrarDias()
        {
            if (flDays == null || lblFecha == null) return;

            flDays.Controls.Clear();

            DateTime primerDiaDelMes = new DateTime(año, mes, 1);
            int diasEnMes = DateTime.DaysInMonth(año, mes);
            int diaSemanaPrimerDia = (int)primerDiaDelMes.DayOfWeek;
            int espaciosVacios = (diaSemanaPrimerDia == 0) ? 6 : diaSemanaPrimerDia - 1;

            lblFecha.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes).ToUpper() + " " + año;

            int scrollBarWidthApproximation = 0;
            if (flDays.Controls.Count > (flDays.Height / 80) * 7)
            {
                scrollBarWidthApproximation = SystemInformation.VerticalScrollBarWidth + 5;
            }

            int availableWidth = flDays.ClientRectangle.Width - flDays.Padding.Horizontal - scrollBarWidthApproximation;
            int availableHeight = flDays.ClientRectangle.Height - flDays.Padding.Vertical;

            int anchoDia = Math.Max(10, availableWidth / 7 - 3);
            int altoDia = Math.Max(10, availableHeight / 6 - 3);

            if (anchoDia <= 10) anchoDia = 90;
            if (altoDia <= 10) altoDia = 70;

            for (int i = 0; i < espaciosVacios; i++)
            {
                Panel panelVacio = new Panel
                {
                    Width = anchoDia,
                    Height = altoDia,
                    Margin = new Padding(1),
                    BackColor = isDarkMode ? dark_UcDiasEmptyBackColor : light_UcDiasEmptyBackColor
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
                diaControl.AplicarTema(isDarkMode);


                GraphicsPath path = new GraphicsPath();
                int radio = 15;
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(anchoDia - radio, 0, radio, radio, 270, 90);
                path.AddArc(anchoDia - radio, altoDia - radio, radio, radio, 0, 90);
                path.AddArc(0, altoDia - radio, radio, radio, 90, 90);
                path.CloseFigure();
                diaControl.Region = new Region(path);

                // Lógica para obtener el color del evento para el día IGAUL ABAJO UWU
                var eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == fechaActualCelda.Date).ToList();
                diaControl.CantidadEventos = eventosDelDia.Count;

                
                var eventoConColor = eventosDelDia.FirstOrDefault(ev => ev.ColorPersonalizado.HasValue);
                var eventoParaIndicador = eventoConColor ?? eventosDelDia.FirstOrDefault(); 

                if (eventoParaIndicador != null) // Si hay algún evento este día
                {
                    diaControl.TieneEvento = true;
                    if (eventoParaIndicador.ColorPersonalizado.HasValue) 
                    {
                        diaControl.ColorPersonalizado = eventoParaIndicador.ColorPersonalizado.Value;
                    }
                    else
                    {
                        diaControl.ColorPersonalizado = null; 
                    }
                }
                else
                {
                    diaControl.TieneEvento = false;
                    diaControl.ColorPersonalizado = null; 
                }

                diaControl.DiaClickeado += UcDias_DiaClickeado;
                flDays.Controls.Add(diaControl);
            }
        }


        private void UcDias_DiaClickeado(object sender, EventArgs e)
        {
            if (sender is UcDias diaControlClickeado)
            {
                DateTime fechaSeleccionada = diaControlClickeado.FechaCelda;
                this.diaActual = fechaSeleccionada;
                ActualizarVistaEventosHoy();
                lstMostrarEventosInicio.SelectedIndex = -1;
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
            // ***** CAMBIO IMPORTANTE *****UWU
            CargarEventosDelMesActual(); // Recargar eventos para el nuevo mes
            MostrarDias();
        }

        private void pbSiguiente_Click(object sender, EventArgs e)
        {
            mes++;
            if (mes > 12)
            {
                mes = 1;
                año++;
            }
            // ***** CAMBIO IMPORTANTE *****UWU
            CargarEventosDelMesActual(); // Recargar eventos para el nuevo mes
            MostrarDias();
        }

        
        private void btnAjustes_Click(object sender, EventArgs e)
        {
            if (pnConfiguracion != null)
            {
                pnConfiguracion.Visible = !pnConfiguracion.Visible;
            }
        }

        private void lblJueves_Click(object sender, EventArgs e) { }
        private void lblMiercoles_Click(object sender, EventArgs e) { }
        private void lblMartes_Click(object sender, EventArgs e) { }
        public void lblDescripcionDelEvento_Click(object sender, EventArgs e) { }

        private void lstMostrarEventosInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMostrarEventosInicio.SelectedItem is Evento)
            {
                btnEditarEvento.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditarEvento.Enabled = false;
                btnEliminar.Enabled = false;
            }

            if (lstMostrarEventosInicio != null && lstMostrarEventosInicio.SelectedItem is Evento evento)
            {
                _eventoSeleccionadoEnLista = evento;
            }
        }

        private void lblUsuarioInicial_Click(object sender, EventArgs e) { }
        private void pnConfiguracion_Paint(object sender, PaintEventArgs e) { }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Estas seguro de cerrar sesion?",
                                    "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                formularioLogin?.Show();
            }
        }
        private void lblFechaDelEvento_Click(object sender, EventArgs e) { }
        private void flDays_Paint(object sender, PaintEventArgs e) { }

        private void btnGestionarEventosDia_Click(object sender, EventArgs e)
        {
            List<Evento> eventosParaDialogo = Evento.ObtenerEventosExistentes(this.diaActual.Date);

            using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosParaDialogo))
            {
                DialogResult resultado = frmEvento.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    // ***** CAMBIO IMPORTANTE ***** PQ te des cuenta bebeto
                    // Recargar TODOS los eventos del mes actual, ya que un evento pudo haber cambiado de día o color
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
                    int resultadoEliminacion = Evento.EliminarEvento(_eventoSeleccionadoEnLista);
                    if (resultadoEliminacion > 0)
                    {
                        MessageBox.Show("Evento eliminado con exito.", "Evento eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ***** CAMBIO IMPORTANTE *****
                        CargarEventosDelMesActual(); // Recargar eventos
                        ActualizarVistaEventosHoy();
                        MostrarDias();

                        btnEliminar.Enabled = false;
                        lstMostrarEventosInicio.SelectedIndex = -1;
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
            Application.Exit();
        }

        private void btnEditarEvento_Click(object sender, EventArgs e)
        {
            if (lstMostrarEventosInicio.SelectedItem is Evento eventoSeleccionado)
            {
                List<Evento> eventosDelDiaActual = Evento.ObtenerEventosExistentes(this.diaActual.Date);

                using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosDelDiaActual, eventoSeleccionado))
                {
                    DialogResult resultado = frmEvento.ShowDialog(this);

                    if (resultado == DialogResult.OK)
                    {
                        // ***** CAMBIO IMPORTANTE *****
                        CargarEventosDelMesActual(); // Recargar todos los eventos
                        ActualizarVistaEventosHoy();
                        MostrarDias();

                        btnEditarEvento.Enabled = false;
                        lstMostrarEventosInicio.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Querido cliente agrege un evento para editarlo.", "Ningún evento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}