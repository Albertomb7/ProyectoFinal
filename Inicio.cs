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
        DateTime diaActual = DateTime.Now; // Día seleccionado para mostrar en la lista de la derecha

        private bool isDarkMode = true;

        // Definiciones de colores para temas (sin cambios respecto a la versión anterior)
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
            if (SesionActual.IdUsuario <= 0) // Verificar si hay un usuario logueado
            {
                MessageBox.Show("Error: No se ha iniciado sesión correctamente. Volviendo al login.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                formularioLogin?.Show();
               
                return;
            }

            DateTime hoy = DateTime.Today;
            mes = hoy.Month;
            año = hoy.Year;
            diaActual = hoy; // Asegurar que diaActual está inicializado

            AplicarTema();
            CargarEventosDelMesActual(); // Carga eficiente de eventos para el mes
            ActualizarVistaEventosHoy(); // Actualiza la lista de la derecha para el día actual (hoy por defecto)
            MostrarDias(); // Dibuja el calendario completo

            lblUsuarioInicial.Text = SesionActual.Usuario;
            lbl_id.Text = SesionActual.IdUsuario.ToString();

            lstMostrarEventosInicio.SelectedIndex = -1;
            btnEliminar.Enabled = false;
            btnEditarEvento.Enabled = false;
        }

        private void CargarEventosDelMesActual()
        {
            listaDeEventosGlobal.Clear();
            if (año == 0 || mes == 0 || SesionActual.IdUsuario <= 0) return;

            // Utiliza el método optimizado que obtiene todos los eventos del mes en una sola consulta
            try
            {
                listaDeEventosGlobal = Evento.ObtenerEventosDelMes(SesionActual.IdUsuario, año, mes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar eventos del mes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Podrías querer manejar esto de forma más elegante, quizás limpiando la lista
                listaDeEventosGlobal.Clear();
            }
        }

        private void ActualizarVistaEventosHoy()
        {
            if (lblFechaDelEvento != null)
            {
                lblFechaDelEvento.Text = $"{diaActual:dd} de {diaActual:MMMM yyyy}"; //Formato más conciso
            }

            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.DataSource = null;
                // Filtra de la lista global los eventos para el 'diaActual'
                List<Evento> eventosDelDiaSeleccionado = listaDeEventosGlobal
                    .Where(ev => ev.Fecha.Date == diaActual.Date)
                    .OrderBy(ev => ev.Hora ?? TimeSpan.MaxValue) // Ordenar por hora
                    .ThenBy(ev => ev.Descripcion) // Luego por descripción
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
                lstMostrarEventosInicio.SelectedIndex = -1; // Deseleccionar
            }
        }

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

            // Labels de los días de la semana
            Control[] dayLabels = { lblLunes, lblMartes, lblMiercoles, lblJueves, lblViernes, lblSabado, lblDomingo };
            foreach (var lbl in dayLabels)
            {
                if (lbl != null) lbl.ForeColor = labelDayNamesColor;
            }

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
            if (btnCerrarSesion != null) // El color de fondo de este botón es fijo (rojo)
            {
                // Ajustar el color del texto para contraste
                btnCerrarSesion.ForeColor = isDarkMode ? Color.White : Color.White; // O Color.Black si se ve mejor en modo claro
            }


            Control[] otherButtons = { btnAjustes, btnGestionarEventosDia, btnEditarEvento, btnEliminar };
            foreach (var btn in otherButtons)
            {
                if (btn != null) btn.ForeColor = formForeColor; // Asumiendo BackColor transparente o adaptable
            }
        }

        private void btnCambioDeColorFondo_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            AplicarTema();
            MostrarDias(); // Redibujar UcDias con el nuevo tema
            ActualizarVistaEventosHoy(); // Actualizar la lista de eventos
        }

        private void MostrarDias()
        {
            if (flDays == null || lblFecha == null) return;
            if (año == 0 || mes == 0)
            {
                // Evitar error si mes/año no están inicializados, aunque Inicio_Load debería hacerlo
                lblFecha.Text = "Fecha no disponible";
                return;
            }

            flDays.SuspendLayout(); // Suspender layout para mejorar rendimiento
            flDays.Controls.Clear();

            DateTime primerDiaDelMes = new DateTime(año, mes, 1);
            int diasEnMes = DateTime.DaysInMonth(año, mes);
            int diaSemanaPrimerDia = (int)primerDiaDelMes.DayOfWeek;
            // DayOfWeek: Domingo=0, Lunes=1, ..., Sábado=6.
            // Si tu semana empieza en Lunes:
            int espaciosVacios = (diaSemanaPrimerDia == 0) ? 6 : diaSemanaPrimerDia - 1;

            lblFecha.Text = $"{primerDiaDelMes:MMMM yyyy}".ToUpper();


            int scrollBarWidthApproximation = 0;
           


            int availableWidth = flDays.ClientRectangle.Width - flDays.Padding.Horizontal - scrollBarWidthApproximation;
            int availableHeight = flDays.ClientRectangle.Height - flDays.Padding.Vertical;

            // Prevenir división por cero si flDays no tiene tamaño aún
            int cols = 7;
            int rows = (espaciosVacios + diasEnMes + cols - 1) / cols; // Calcular filas necesarias
            if (rows == 0) rows = 1; // Al menos una fila

            int anchoDia = Math.Max(20, (availableWidth / cols) - 3);
            int altoDia = Math.Max(20, (availableHeight / rows) - 3);

            // Valores por defecto si el cálculo es muy pequeño (ej. al inicio si el form no tiene tamaño)
            if (anchoDia <= 20) anchoDia = 90;
            if (altoDia <= 20) altoDia = 70;


            for (int i = 0; i < espaciosVacios; i++)
            {
                Panel panelVacio = new Panel
                {
                    Width = anchoDia,
                    Height = altoDia,
                    Margin = new Padding(1),
                    BackColor = isDarkMode ? dark_UcDiasEmptyBackColor : light_UcDiasEmptyBackColor,
                    BorderStyle = BorderStyle.FixedSingle // Opcional para verlos mejor
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

                // Redondear bordes (este código es cosmético)
                try
                {
                    GraphicsPath path = new GraphicsPath();
                    int radio = 10; // Radio más pequeño para bordes más sutiles
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
                    // Continuar sin bordes redondeados si falla
                }


                var eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == fechaActualCelda.Date).ToList();
                diaControl.CantidadEventos = eventosDelDia.Count;

                var eventoConColor = eventosDelDia.FirstOrDefault(ev => ev.ColorPersonalizado.HasValue);
                var eventoParaIndicador = eventoConColor ?? eventosDelDia.FirstOrDefault();

                if (eventoParaIndicador != null)
                {
                    diaControl.TieneEvento = true;
                    diaControl.ColorPersonalizado = eventoParaIndicador.ColorPersonalizado; // Puede ser null
                }
                else
                {
                    diaControl.TieneEvento = false;
                    diaControl.ColorPersonalizado = null;
                }

                diaControl.DiaClickeado += UcDias_DiaClickeado;
                flDays.Controls.Add(diaControl);
            }
            flDays.ResumeLayout(); // Reanudar layout
        }

        private void UcDias_DiaClickeado(object sender, EventArgs e)
        {
            if (sender is UcDias diaControlClickeado)
            {
                this.diaActual = diaControlClickeado.FechaCelda; // Actualiza el día seleccionado
                ActualizarVistaEventosHoy(); // Refresca la lista de eventos para este día
                // lstMostrarEventosInicio.SelectedIndex = -1; // Ya se hace en ActualizarVistaEventosHoy
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
            ActualizarVistaEventosHoy(); // Actualizar la lista para el día actual del nuevo mes
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
            ActualizarVistaEventosHoy(); // Actualizar la lista para el día actual del nuevo mes
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
            _eventoSeleccionadoEnLista = lstMostrarEventosInicio.SelectedItem as Evento;

            btnEditarEvento.Enabled = (_eventoSeleccionadoEnLista != null);
            btnEliminar.Enabled = (_eventoSeleccionadoEnLista != null);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de cerrar sesión?",
                                    "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                formularioLogin?.Show();
                // Considera limpiar SesionActual si es necesario
                // SesionActual.IdUsuario = 0; 
                // SesionActual.Usuario = null;
                this.Close(); // Cierra este formulario para que no quede en memoria
            }
        }

        private void btnGestionarEventosDia_Click(object sender, EventArgs e)
        {
            // Obtener los eventos para el 'diaActual' (que es el día clickeado o hoy por defecto)
           
            List<Evento> eventosParaDialogo = listaDeEventosGlobal
               .Where(ev => ev.Fecha.Date == this.diaActual.Date)
               .ToList();

            using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosParaDialogo))
            {
                DialogResult resultado = frmEvento.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    CargarEventosDelMesActual(); // Recarga todos los eventos del mes (optimizado)
                    ActualizarVistaEventosHoy(); // Actualiza la lista de la derecha
                    MostrarDias(); // Redibuja el calendario
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
                        MessageBox.Show("Evento eliminado con éxito.", "Evento Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarEventosDelMesActual();
                        ActualizarVistaEventosHoy();
                        MostrarDias();
                        // _eventoSeleccionadoEnLista se volverá null al refrescar la lista y deseleccionar
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
            // Si este es el formulario principal después del login, cerrarlo debería terminar la aplicación
            // o mostrar el login de nuevo si no se hizo desde btnCerrarSesion.
            if (formularioLogin != null && !formularioLogin.IsDisposed && !formularioLogin.Visible)
            {
                // Si el formulario de login está oculto y no se cerró desde "Cerrar Sesión",
                // podría ser un cierre de aplicación.
                Application.Exit();
            }
            else if (formularioLogin == null) // Si no hay formulario de login (Inicio es el principal)
            {
                Application.Exit();
            }
            // Si se cerró desde btnCerrarSesion, el formulario de login ya debería estar visible.
        }

        private void btnEditarEvento_Click(object sender, EventArgs e)
        {
            if (_eventoSeleccionadoEnLista != null)
            {
                List<Evento> eventosDelDiaActual = listaDeEventosGlobal
                   .Where(ev => ev.Fecha.Date == this.diaActual.Date)
                   .ToList();

                using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosDelDiaActual, _eventoSeleccionadoEnLista))
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

        // Eventos vacíos que pueden eliminarse si no se usan y no están en el Designer
        private void lblJueves_Click(object sender, EventArgs e) { }
        private void lblMiercoles_Click(object sender, EventArgs e) { }
        private void lblMartes_Click(object sender, EventArgs e) { }
        // public void lblDescripcionDelEvento_Click(object sender, EventArgs e) { } // Si es un click de un label, debe ser private
        private void lblUsuarioInicial_Click(object sender, EventArgs e) { }
        private void pnConfiguracion_Paint(object sender, PaintEventArgs e) { }
        private void lblFechaDelEvento_Click(object sender, EventArgs e) { }
        private void flDays_Paint(object sender, PaintEventArgs e) { }

    }
}
//rs