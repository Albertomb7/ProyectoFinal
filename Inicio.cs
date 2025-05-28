// Inicio.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CalendarioApp; // Namespace de UcDias
using System.Drawing.Drawing2D;

namespace ProyectoFinal.Calendario
{
    public partial class Inicio : Form
    {
        int mes, año;
        private Form formularioLogin;
        DateTime diaActual = DateTime.Now;

        private bool isDarkMode;

        // Colores Tema Oscuro
        private readonly Color dark_FormBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_FormForeColor = Color.White;
        private readonly Color dark_LabelDayNamesColor = Color.FromArgb(200, 200, 200);
        private readonly Color dark_UcDiasEmptyBackColor = Color.FromArgb(20, 22, 28);
        
        private readonly Color dark_PanelConfiguracionResaltadoBackColor = Color.FromArgb(28, 32, 40); // Para resaltar panel config

        // Colores Tema Claro
        private readonly Color light_FormBackColor = SystemColors.Control;
        private readonly Color light_FormForeColor = Color.Black;
        private readonly Color light_LabelDayNamesColor = Color.FromArgb(70, 70, 70);
        private readonly Color light_UcDiasEmptyBackColor = Color.FromArgb(240, 240, 240);
        
        private readonly Color light_PanelConfiguracionBackColor = SystemColors.ControlLight;

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
                return;
            }

            isDarkMode = SesionActual.ModoOscuroPreferido;

            DateTime hoy = DateTime.Today;
            mes = hoy.Month;
            año = hoy.Year;
            diaActual = hoy;

            AplicarTema();
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
                listaDeEventosGlobal = Evento.ObtenerEventosDelMes(SesionActual.IdUsuario, año, mes);
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
                    .Where(ev => ev.Fecha.Date == diaActual.Date)
                    .OrderBy(ev => ev.Hora ?? TimeSpan.MaxValue)
                    .ThenBy(ev => ev.Descripcion)
                    .ToList();
                if (eventosDelDiaSeleccionado.Any())
                {
                    lstMostrarEventosInicio.DataSource = eventosDelDiaSeleccionado;
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
            Color formBackColor, formForeColor, labelDayNamesColor, panelConfigBackColor, ucDiasEmptyBackColor;

            if (isDarkMode)
            {
                formBackColor = dark_FormBackColor;
                formForeColor = dark_FormForeColor;
                labelDayNamesColor = dark_LabelDayNamesColor;
                ucDiasEmptyBackColor = dark_UcDiasEmptyBackColor;
                panelConfigBackColor = dark_PanelConfiguracionResaltadoBackColor;
                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo Claro";
            }
            else
            {
                formBackColor = light_FormBackColor;
                formForeColor = light_FormForeColor;
                labelDayNamesColor = light_LabelDayNamesColor;
                ucDiasEmptyBackColor = light_UcDiasEmptyBackColor;
                panelConfigBackColor = light_PanelConfiguracionBackColor;
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

            if (flDays != null) flDays.BackColor = formBackColor;

            // --- INICIO DE MODIFICACIÓN PARA LISTBOX ---
            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.BackColor = formBackColor; // Usar el color de fondo del formulario
                lstMostrarEventosInicio.ForeColor = formForeColor; // Mantener el color del texto del formulario
                lstMostrarEventosInicio.BorderStyle = BorderStyle.None; // Quitar el borde para que se funda
            }
            // --- FIN DE MODIFICACIÓN PARA LISTBOX ---

            if (pnConfiguracion != null)
            {
                pnConfiguracion.BackColor = panelConfigBackColor;
                foreach (Control ctl in pnConfiguracion.Controls)
                {
                    if (ctl is Label) ctl.ForeColor = formForeColor;
                }
            }

            if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.ForeColor = formForeColor;
            if (btnCerrarSesion != null) btnCerrarSesion.ForeColor = Color.White;

            // --- INICIO DE MODIFICACIÓN PARA BOTONES DE ÍCONOS TRANSPARENTES ---
            Button[] imageActionButtons = { btnGestionarEventosDia, btnEditarEvento, btnEliminar };
            foreach (Button btn in imageActionButtons)
            {
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.Transparent;        // Fondo del botón transparente
                    btn.FlatAppearance.BorderSize = 0;       // Sin borde
                    btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // Sin cambio de color al pasar el mouse
                    btn.FlatAppearance.MouseDownBackColor = Color.Transparent; // Sin cambio de color al hacer clic
                    
                }
            }

            //Estas dos linea de codigo cambian el color a la hora de usar el Cambio de tema
            pbSiguiente.Image = isDarkMode ? Properties.Resources.Flecha_blanca_derecha : Properties.Resources.Flecha_Negra_Derecha;
            pbAnterior.Image = isDarkMode ? Properties.Resources.Flecha_blanca_Izquierda : Properties.Resources.Flecha_Negra_Izquierda;

            // --- FIN DE MODIFICACIÓN PARA BOTONES DE ÍCONOS ---

            Control[] allImageControls = { btnAjustes, btnGestionarEventosDia, btnEditarEvento, btnEliminar, pbAnterior, pbSiguiente };
            foreach (var ctrl in allImageControls)
            {
                if (ctrl != null) ctrl.ForeColor = formForeColor;
            }
        }

        private void btnCambioDeColorFondo_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            AplicarTema();
            SesionActual.ModoOscuroPreferido = isDarkMode;
            try
            {
                datosUsuarios.ActualizarPreferenciasTema(SesionActual.IdUsuario, isDarkMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la preferencia de tema en la base de datos: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MostrarDias();
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
            lblFecha.Text = $"{primerDiaDelMes:MMMM yyyy}".ToUpper(); // CORREGIDO
            int availableWidth = flDays.ClientSize.Width - flDays.Padding.Horizontal;
            int cols = 7;
            int anchoDia = Math.Max(20, (availableWidth / cols) - (flDays.Margin.Horizontal / cols) - 2);
            int altoDia = Math.Max(20, (flDays.ClientSize.Height / ((espaciosVacios + diasEnMes + cols - 1) / cols)) - 6);
            if (altoDia < 60) altoDia = 80;
            if (anchoDia < 60) anchoDia = (flDays.ClientSize.Width / cols) - 6;

            Color ucDiasEmptyBackColorToUse = isDarkMode ? dark_UcDiasEmptyBackColor : light_UcDiasEmptyBackColor;
            for (int i = 0; i < espaciosVacios; i++)
            {
                Panel panelVacio = new Panel { Width = anchoDia, Height = altoDia, Margin = new Padding(1), BackColor = ucDiasEmptyBackColorToUse };
                flDays.Controls.Add(panelVacio);
            }
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                UcDias diaControl = new UcDias { Dia = dia.ToString(), FechaCelda = new DateTime(año, mes, dia), Width = anchoDia, Height = altoDia };
                diaControl.AplicarTema(isDarkMode);
                try
                {
                    GraphicsPath path = new GraphicsPath(); int radio = 8;
                    path.AddArc(0, 0, radio, radio, 180, 90); path.AddArc(diaControl.Width - radio, 0, radio, radio, 270, 90);
                    path.AddArc(diaControl.Width - radio, diaControl.Height - radio, radio, radio, 0, 90); path.AddArc(0, diaControl.Height - radio, radio, radio, 90, 90);
                    path.CloseFigure(); diaControl.Region = new Region(path);
                }
                catch (Exception exRegion) { Console.WriteLine("Error aplicando región a UcDias: " + exRegion.Message); }
                var eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == diaControl.FechaCelda.Date).ToList();
                diaControl.CantidadEventos = eventosDelDia.Count;
                var eventoParaIndicador = eventosDelDia.FirstOrDefault(ev => ev.ColorPersonalizado.HasValue) ?? eventosDelDia.FirstOrDefault();
                if (eventoParaIndicador != null) { diaControl.TieneEvento = true; diaControl.ColorPersonalizado = eventoParaIndicador.ColorPersonalizado; }
                else { diaControl.TieneEvento = false; diaControl.ColorPersonalizado = null; }
                diaControl.DiaClickeado += UcDias_DiaClickeado;
                flDays.Controls.Add(diaControl);
            }
            flDays.ResumeLayout();
        }

        private void UcDias_DiaClickeado(object sender, EventArgs e)
        {
            if (sender is UcDias diaControlClickeado)
            {
                this.diaActual = diaControlClickeado.FechaCelda;
                ActualizarVistaEventosHoy();
                if (lstMostrarEventosInicio != null) lstMostrarEventosInicio.SelectedIndex = -1;
                if (btnEliminar != null) btnEliminar.Enabled = false;
                if (btnEditarEvento != null) btnEditarEvento.Enabled = false;

                if (pnConfiguracion != null && pnConfiguracion.Visible)
                {
                    pnConfiguracion.Visible = false;
                }
            }
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            mes--; if (mes < 1) { mes = 12; año--; }
            CargarEventosDelMesActual(); MostrarDias(); ActualizarVistaEventosHoy();
        }

        private void pbSiguiente_Click(object sender, EventArgs e)
        {
            mes++; if (mes > 12) { mes = 1; año++; }
            CargarEventosDelMesActual(); MostrarDias(); ActualizarVistaEventosHoy();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            if (pnConfiguracion != null) pnConfiguracion.Visible = !pnConfiguracion.Visible;
        }

        private void lstMostrarEventosInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventoSeleccionadoEnLista = lstMostrarEventosInicio.SelectedItem as Evento;
            if (btnEditarEvento != null) btnEditarEvento.Enabled = (_eventoSeleccionadoEnLista != null);
            if (btnEliminar != null) btnEliminar.Enabled = (_eventoSeleccionadoEnLista != null);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionActual.LimpiarSesion(); this.Hide(); formularioLogin?.Show(); this.Close();
            }
        }

        private void btnGestionarEventosDia_Click(object sender, EventArgs e)
        {
            List<Evento> eventosParaDialogo = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == this.diaActual.Date).ToList();
            using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosParaDialogo))
            {
                if (frmEvento.ShowDialog(this) == DialogResult.OK)
                { CargarEventosDelMesActual(); ActualizarVistaEventosHoy(); MostrarDias(); }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_eventoSeleccionadoEnLista != null && MessageBox.Show($"¿Seguro que quieres eliminar el evento: '{_eventoSeleccionadoEnLista.Descripcion}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Evento.EliminarEvento(_eventoSeleccionadoEnLista) > 0)
                {
                    MessageBox.Show("Evento eliminado con éxito.", "Evento Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEventosDelMesActual(); ActualizarVistaEventosHoy(); MostrarDias();
                }
                else { MessageBox.Show("Error al eliminar el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formularioLogin != null && formularioLogin.Visible) return;
            if ((formularioLogin == null || !formularioLogin.Visible) && SesionActual.IdUsuario > 0) Application.Exit();
        }

        private void btnEditarEvento_Click(object sender, EventArgs e)
        {
            if (_eventoSeleccionadoEnLista != null)
            {
                List<Evento> eventosDelDiaActual = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == this.diaActual.Date).ToList();
                using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosDelDiaActual, _eventoSeleccionadoEnLista))
                {
                    if (frmEvento.ShowDialog(this) == DialogResult.OK)
                    { CargarEventosDelMesActual(); ActualizarVistaEventosHoy(); MostrarDias(); }
                }
            }
            else { MessageBox.Show("Selecciona un evento de la lista para editarlo.", "Ningún Evento Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        // Eventos vacíos que puedes eliminar si no se usan y no están en el Designer
        private void lblJueves_Click(object sender, EventArgs e) { }
        private void lblMiercoles_Click(object sender, EventArgs e) { }
        private void lblMartes_Click(object sender, EventArgs e) { }
        private void lblUsuarioInicial_Click(object sender, EventArgs e) { }
        private void pnConfiguracion_Paint(object sender, PaintEventArgs e) { }
        private void lblFechaDelEvento_Click(object sender, EventArgs e) { }
        private void flDays_Paint(object sender, PaintEventArgs e) { }
    }
}