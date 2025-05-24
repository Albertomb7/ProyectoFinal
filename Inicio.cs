
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CalendarioApp; // Namespace de UcDias
using System.Drawing.Drawing2D;
using ProyectoFinal.Calendario; 


namespace ProyectoFinal.Calendario
{
    public partial class Inicio : Form
    {
        int mes, año;
        private Form formularioLogin;
        DateTime diaActual = DateTime.Now;
        bool valorAjuste = false;

        // --- Inicio de cambios para el Tema ---
        private bool isDarkMode = true; // Por defecto el modo oscuro está activado

        // Colores Modo Oscuro
        private readonly Color dark_FormBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_FormForeColor = Color.White;
        private readonly Color dark_LabelDayNamesColor = Color.FromArgb(200, 200, 200);
        private readonly Color dark_UcDiasEmptyBackColor = Color.FromArgb(20, 22, 28);
        private readonly Color dark_ListBoxBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_PanelConfiguracionBackColor = Color.FromArgb(14, 17, 23);
        private readonly Color dark_ButtonBackColor = Color.FromArgb(14, 17, 23); // Para botones como el de tema

        // Colores Modo Claro
        private readonly Color light_FormBackColor = SystemColors.Control;
        private readonly Color light_FormForeColor = Color.Black;
        private readonly Color light_LabelDayNamesColor = Color.FromArgb(70, 70, 70);
        private readonly Color light_UcDiasEmptyBackColor = Color.FromArgb(240, 240, 240);
        private readonly Color light_ListBoxBackColor = SystemColors.Window;
        private readonly Color light_PanelConfiguracionBackColor = SystemColors.ControlLight;
        private readonly Color light_ButtonBackColor = SystemColors.ControlLight; // Para botones como el de tema
        // --- Fin de cambios para el Tema ---


        public Evento EventoCreadoOModificado { get; private set; }
        public Evento EventoAEliminar { get; private set; }
        private DateTime _fechaActual;
        private List<Evento> _eventosExistentesEnElDia; 
        private Evento _eventoSeleccionadoEnLista; 

        private List<Evento> listaDeEventosGlobal = new List<Evento>();

        public Inicio()
        {
            InitializeComponent();
            // Se eliminarán las configuraciones de color directas de aquí, AplicarTema() las manejará.
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

            AplicarTema(); // Aplicar el tema inicial (oscuro por defecto)

            ActualizarVistaEventosHoy(); // Muestra eventos para el día actual y actualiza la etiqueta de fecha.
            MostrarDias(); // Dibuja el calendario.
        }

        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código existente en Inicio.cs) ...

        private void ActualizarVistaEventosHoy()
        {
            if (lblFechaDelEvento != null)
            {
                lblFechaDelEvento.Text = $"{diaActual.ToString("dd")} de {diaActual.ToString("MMMM", new CultureInfo("es-ES"))} {diaActual.ToString("yyyy")}";
            }
            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.DataSource = null; // Limpiar DataSource anterior
                List<Evento> eventosDelDia = Evento.ObtenerEventosExistentes(diaActual.Date); //

                if (eventosDelDia.Any()) // Verifica si hay algún evento en la lista
                {
                    lstMostrarEventosInicio.DataSource = eventosDelDia;
                    
                }
                else
                {
                    // Si no hay eventos, limpiar la lista y mostrar un mensaje.
                    lstMostrarEventosInicio.DataSource = null; // Asegurar que no hay fuente de datos
                    lstMostrarEventosInicio.Items.Clear();    // Limpiar cualquier ítem manual
                    lstMostrarEventosInicio.Items.Add("No hay eventos para este día.");
                }
            }
        }

        // ... (resto del código de Inicio.cs) ...

        // --- Inicio de cambios para el Tema ---
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

                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo: Oscuro";
            }
            else
            {
                formBackColor = light_FormBackColor;
                formForeColor = light_FormForeColor;
                labelDayNamesColor = light_LabelDayNamesColor;
                listBoxBackColor = light_ListBoxBackColor;
                panelConfigBackColor = light_PanelConfiguracionBackColor;
                buttonBackColor = light_ButtonBackColor;

                if (btnCambioDeColorFondo != null) btnCambioDeColorFondo.Text = "Modo: Claro";
            }

            // Aplicar colores al Formulario Principal
            this.BackColor = formBackColor;
            this.ForeColor = formForeColor; // Color de texto por defecto para controles sin ForeColor específico

            // Labels principales
            if (lblFecha != null) lblFecha.ForeColor = formForeColor;
            if (lblFechaDelEvento != null) lblFechaDelEvento.ForeColor = formForeColor;
            if (lblUsuarioInicial != null) lblUsuarioInicial.ForeColor = formForeColor; // Dentro del panel de configuración

            // Labels de los días de la semana
            if (lblLunes != null) lblLunes.ForeColor = labelDayNamesColor;
            if (lblMartes != null) lblMartes.ForeColor = labelDayNamesColor;
            if (lblMiercoles != null) lblMiercoles.ForeColor = labelDayNamesColor;
            if (lblJueves != null) lblJueves.ForeColor = labelDayNamesColor;
            if (lblViernes != null) lblViernes.ForeColor = labelDayNamesColor;
            if (lblSabado != null) lblSabado.ForeColor = labelDayNamesColor;
            if (lblDomingo != null) lblDomingo.ForeColor = labelDayNamesColor;

            // FlowLayoutPanel para los días (el fondo de los días en sí se maneja en UcDias)
            if (flDays != null) flDays.BackColor = formBackColor; 

            // ListBox para mostrar eventos
            if (lstMostrarEventosInicio != null)
            {
                lstMostrarEventosInicio.BackColor = listBoxBackColor;
                lstMostrarEventosInicio.ForeColor = formForeColor;
            }

            // Panel de Configuración
            if (pnConfiguracion != null)
            {
                pnConfiguracion.BackColor = panelConfigBackColor;
            }

            // Botones dentro del Panel de Configuración
            if (btnCambioDeColorFondo != null)
            {
                btnCambioDeColorFondo.BackColor = buttonBackColor; 
                btnCambioDeColorFondo.ForeColor = formForeColor;
            }
            // btnCerrarSesion tiene un color de fondo roj, solo ajustE el ForeColor si es necesario.
            if (btnCerrarSesion != null)
            {
                btnCerrarSesion.ForeColor = isDarkMode ? Color.Black : Color.White; // Texto negro sobre rojo en oscuro, blanco sobre rojo en claro
            }

            // Otros botones principales
            if (btnAjustes != null) btnAjustes.ForeColor = formForeColor; // Asumiendo que su BackColor es transparente o se adapta
            if (btnGestionarEventosDia != null) btnGestionarEventosDia.ForeColor = formForeColor; // Idem

            // Actualizar controles que dependen del tema
            MostrarDias(); // Para que los UcDias y paneles vacíos se redibujen con el nuevo tema
            ActualizarVistaEventosHoy(); // Para refrescar la lista de eventos con los nuevos colores de texto/fondo
        }

        private void btnCambioDeColorFondo_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode; // Alternar el estado del tema
            AplicarTema();
        }
        // --- Fin de cambios para el Tema ---


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

            int anchoDia = Math.Max(10, availableWidth / 7 - 3); // Asegurar un ancho mínimo
            int altoDia = Math.Max(10, availableHeight / 6 - 3); // Asegurar un alto mínimo

            if (anchoDia <= 10) anchoDia = 90; // Valores por defecto si el cálculo es muy pequeño
            if (altoDia <= 10) altoDia = 70;

            // Espacios vacíos antes del primer día
            for (int i = 0; i < espaciosVacios; i++)
            {
                Panel panelVacio = new Panel
                {
                    Width = anchoDia,
                    Height = altoDia,
                    Margin = new Padding(1),
                    // --- Inicio de cambios para el Tema ---
                    BackColor = isDarkMode ? dark_UcDiasEmptyBackColor : light_UcDiasEmptyBackColor
                    // --- Fin de cambios para el Tema ---
                };
                flDays.Controls.Add(panelVacio);
            }

            // Días del mes
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                UcDias diaControl = new UcDias();
                DateTime fechaActualCelda = new DateTime(año, mes, dia);

                diaControl.Dia = dia.ToString();
                diaControl.FechaCelda = fechaActualCelda;
                diaControl.Width = anchoDia;
                diaControl.Height = altoDia;

                // --- Inicio de cambios para el Tema ---
                diaControl.AplicarTema(isDarkMode); // Aplicar el tema al control UcDias
                // --- Fin de cambios para el Tema ---


                // Redondear bordes (esto es independiente del tema)
                GraphicsPath path = new GraphicsPath();
                int radio = 15;
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(anchoDia - radio, 0, radio, radio, 270, 90);
                path.AddArc(anchoDia - radio, altoDia - radio, radio, radio, 0, 90);
                path.AddArc(0, altoDia - radio, radio, radio, 90, 90);
                path.CloseFigure();
                diaControl.Region = new Region(path);
                // El BackColor base de UcDias ahora se establece mediante diaControl.AplicarTema()

                var eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == fechaActualCelda.Date).ToList();
                diaControl.CantidadEventos = eventosDelDia.Count;
                var eventoDelDia = eventosDelDia.FirstOrDefault();

                if (eventoDelDia != null)
                {
                    diaControl.TieneEvento = true;
                    if (eventoDelDia.ColorPersonalizado.HasValue)
                    {
                        diaControl.ColorPersonalizado = eventoDelDia.ColorPersonalizado.Value;
                    }
                }
                else
                {
                    diaControl.TieneEvento = false;
                }

                diaControl.DiaClickeado += UcDias_DiaClickeado;
                flDays.Controls.Add(diaControl);
            }
        }

        // Este método va dentro de la clase Inicio en tu archivo Inicio.cs NO LO TOQUEN

        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código existente en Inicio.cs) ...

        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código de tu clase Inicio) ...

        private void UcDias_DiaClickeado(object sender, EventArgs e)
        {
            if (sender is UcDias diaControlClickeado)
            {
                DateTime fechaSeleccionada = diaControlClickeado.FechaCelda;

                // 1. Actualizar 'diaActual' para que refleje el día en el que se hizo clic.
                this.diaActual = fechaSeleccionada;

                // 2. Actualizar la lista de la derecha (lstMostrarEventosInicio) y 
                //    la etiqueta de fecha (lblFechaDelEvento).
                //    El método ActualizarVistaEventosHoy() usa this.diaActual y
                //    ya obtiene los eventos de la BD. Si no hay eventos, mostrará la lista vacía.
                ActualizarVistaEventosHoy(); //

                // Ya NO abrimos FormularioEvento aquí.
            }
        }


        // ... (otro código de tu clase Inicio) ...
        // ... (resto del código de Inicio.cs) ...
        private void pbAnterior_Click(object sender, EventArgs e)
        {
            mes--;
            if (mes < 1)
            {
                mes = 12;
                año--;
            }
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
            MostrarDias();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            if (pnConfiguracion != null)
            {
                pnConfiguracion.Visible = !pnConfiguracion.Visible; // Alternar visibilidad directamente
            }
        }

        // Eventos vacíos que pueden eliminarse si no se usan
        private void lblJueves_Click(object sender, EventArgs e) { }
        private void lblMiercoles_Click(object sender, EventArgs e) { }
        private void lblMartes_Click(object sender, EventArgs e) { }
        public void lblDescripcionDelEvento_Click(object sender, EventArgs e) { }
        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código de tu clase Inicio)

        private void lstMostrarEventosInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar el botón Editar solo si un evento real está seleccionado
            // y no el mensaje "No hay eventos para este día."
            if (lstMostrarEventosInicio.SelectedItem is Evento) // Verifica que el ítem seleccionado sea un objeto Evento
            {
                btnEditarEvento.Enabled = true;
            }
            else
            {
                btnEditarEvento.Enabled = false;
            }
        }

        // ... (otro código de tu clase Inicio)
        private void lblUsuarioInicial_Click(object sender, EventArgs e) { }
        private void pnConfiguracion_Paint(object sender, PaintEventArgs e) { }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Lógica para cerrar sesión
            this.Close(); // Cierra el formulario actual (Inicio)
            formularioLogin?.Show(); // Muestra el formulario de login si existe
        }
        private void lblFechaDelEvento_Click(object sender, EventArgs e) { }
        private void flDays_Paint(object sender, PaintEventArgs e) { }

        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código de tu clase Inicio)

        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código existente en Inicio.cs) ...

        private void btnGestionarEventosDia_Click(object sender, EventArgs e)
        {
            // Usamos this.diaActual, que debería estar actualizado con el último día
            // en el que el usuario hizo clic en el calendario, o el día de hoy por defecto.

            // 1. Obtener los eventos para el día actual (this.diaActual) para pasarlos al diálogo.
            List<Evento> eventosParaDialogo = Evento.ObtenerEventosExistentes(this.diaActual.Date); //

            // 2. Abrir el FormularioEvento.
            using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosParaDialogo)) //
            {
                DialogResult resultado = frmEvento.ShowDialog(this);

                // 3. Procesar el resultado si se hicieron cambios en FormularioEvento.
                if (resultado == DialogResult.OK)
                {
                    // Actualizar 'listaDeEventosGlobal' para que los indicadores del calendario sean correctos.
                    listaDeEventosGlobal.RemoveAll(ev => ev.Fecha.Date == this.diaActual.Date);
                    List<Evento> eventosActualizadosDelDia = Evento.ObtenerEventosExistentes(this.diaActual.Date); //
                    listaDeEventosGlobal.AddRange(eventosActualizadosDelDia);

                    ActualizarVistaEventosHoy(); //
                    MostrarDias(); //
                }
            }
        }

        // {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/Inicio.cs}}
        // ... (otro código existente)

        private void btnEditarEvento_Click(object sender, EventArgs e)
        {
            if (lstMostrarEventosInicio.SelectedItem is Evento eventoSeleccionado)
            {
                // 'this.diaActual' ya debería corresponder al día de los eventos mostrados en la lista.
                // Pasamos el eventoSeleccionado directamente o su información al FormularioEvento.
                // FormularioEvento ya tiene lógica para cargar un evento si se le pasa uno.

                // FormularioEvento espera una lista de eventos del día para su ListBox interna.
                // Podemos pasar la lista actual de eventos del día.
                List<Evento> eventosDelDiaActual = Evento.ObtenerEventosExistentes(this.diaActual.Date); //

                // Para que FormularioEvento sepa qué evento editar y lo cargue en los campos,
                // necesitarás pasar el 'eventoSeleccionado' y modificar FormularioEvento
                // para que, si recibe un evento específico, lo cargue.
                // Actualmente, FormularioEvento carga el primer evento de la lista o ninguno.
                // Vamos a modificar FormularioEvento para que acepte un evento a editar.

                using (FormularioEvento frmEvento = new FormularioEvento(this.diaActual, eventosDelDiaActual, eventoSeleccionado)) // NUEVO: pasamos eventoSeleccionado
                {
                    DialogResult resultado = frmEvento.ShowDialog(this);

                    if (resultado == DialogResult.OK)
                    {
                        // Refrescar la vista, igual que después de agregar un nuevo evento
                        listaDeEventosGlobal.RemoveAll(ev => ev.Fecha.Date == this.diaActual.Date);
                        List<Evento> eventosActualizadosDelDia = Evento.ObtenerEventosExistentes(this.diaActual.Date); //
                        listaDeEventosGlobal.AddRange(eventosActualizadosDelDia);

                        ActualizarVistaEventosHoy();
                        MostrarDias();

                        // Después de editar, es bueno deshabilitar el botón de editar hasta nueva selección
                        btnEditarEvento.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Querido cliene agrege un evento para editarlo.", "Ningún evento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
      
        

    }

}