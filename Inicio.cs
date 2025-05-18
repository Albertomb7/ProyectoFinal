// Inicio.cs  son las 3 de la mañana y no tengo sueño

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

        // Lista para almacenar todos los eventos de la aplicación
        private List<Evento> listaDeEventosGlobal = new List<Evento>();

        public Inicio()
        {
            InitializeComponent(); // Llama al código en Inicio.Designer.cs

            // Personalización de colores para el tema oscuro como el tuyo @roman xd
            this.BackColor = Color.FromArgb(14, 17, 23);

            if (lblFecha != null) lblFecha.ForeColor = Color.White;
            if (lblLunes != null) lblLunes.ForeColor = Color.FromArgb(200, 200, 200);
            if (lblMartes != null) lblMartes.ForeColor = Color.FromArgb(200, 200, 200);
            if (lblMiercoles != null) lblMiercoles.ForeColor = Color.FromArgb(200, 200, 200);
            if (lblJueves != null) lblJueves.ForeColor = Color.FromArgb(200, 200, 200);
            if (lblViernes != null) lblViernes.ForeColor = Color.FromArgb(200, 200, 200);
            if (lblSabado != null) lblSabado.ForeColor = Color.FromArgb(200, 200, 200);
            if (lblDomingo != null) lblDomingo.ForeColor = Color.FromArgb(200, 200, 200);
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
            MostrarDias();
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

            int anchoDia = availableWidth / 7 - 3;
            int altoDia = availableHeight / 6 - 3;

            if (anchoDia <= 10) anchoDia = 90;
            if (altoDia <= 10) altoDia = 70;

            // Espacios vacíos antes del primer día
            for (int i = 0; i < espaciosVacios; i++)
            {
                Panel panelVacio = new Panel
                {
                    Width = anchoDia,
                    Height = altoDia,
                    Margin = new Padding(1),
                    BackColor = Color.FromArgb(20, 22, 28)
                };
                flDays.Controls.Add(panelVacio);
            }

            // Días del mes y año xd. Modifiqué esto para que se vea más redondeado los bordes
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                UcDias diaControl = new UcDias();
                DateTime fechaActualCelda = new DateTime(año, mes, dia);

                diaControl.Dia = dia.ToString();
                diaControl.FechaCelda = fechaActualCelda;
                diaControl.Width = anchoDia;
                diaControl.Height = altoDia;

                // Redondear bordes del control
                GraphicsPath path = new GraphicsPath();
                int radio = 15;
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(anchoDia - radio, 0, radio, radio, 270, 90);
                path.AddArc(anchoDia - radio, altoDia - radio, radio, radio, 0, 90);
                path.AddArc(0, altoDia - radio, radio, radio, 90, 90);
                path.CloseFigure();
                diaControl.Region = new Region(path);
                diaControl.BackColor = Color.FromArgb(40, 43, 50);  // Color de fondo para los días

                // Verificar si el día tiene eventos
                var eventosDelDia = listaDeEventosGlobal.Where(ev => ev.Fecha.Date == fechaActualCelda.Date).ToList(); // R,S. Recolecta todos los eventos de ese día
                diaControl.CantidadEventos = eventosDelDia.Count; // R,S. Guarda la cantidad de eventos para mostrar el número si es necesario

                var eventoDelDia = eventosDelDia.FirstOrDefault(); // R,S. Se usa solo uno para tomar su color

                if (eventoDelDia != null)
                {
                    diaControl.TieneEvento = true;

                    if (eventoDelDia.ColorPersonalizado.HasValue)
                    {
                        diaControl.ColorPersonalizado = eventoDelDia.ColorPersonalizado.Value; // se usó la propiedad — razón por la que no guardaba el color
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

        private void UcDias_DiaClickeado(object sender, EventArgs e)
        {
            if (sender is UcDias diaControlClickeado)
            {
                DateTime fechaSeleccionada = diaControlClickeado.FechaCelda;

                List<Evento> eventosDelDiaSeleccionado = listaDeEventosGlobal
                    .Where(ev => ev.Fecha.Date == fechaSeleccionada.Date)
                    .ToList(); // Crea una nueva lista con los eventos filtrados para ese día y la noche

                using (FormularioEvento frmEvento = new FormularioEvento(fechaSeleccionada, eventosDelDiaSeleccionado))
                {
                    DialogResult resultado = frmEvento.ShowDialog(this);

                    if (resultado == DialogResult.OK)
                    {
                        if (frmEvento.EventoAEliminar != null)
                        {
                            // Eliminar el evento de la lista
                            listaDeEventosGlobal.Remove(frmEvento.EventoAEliminar);
                        }
                        else if (frmEvento.EventoCreadoOModificado != null)
                        {
                            if (!listaDeEventosGlobal.Contains(frmEvento.EventoCreadoOModificado))
                            {
                                listaDeEventosGlobal.Add(frmEvento.EventoCreadoOModificado);
                            }
                        }

                        MostrarDias(); // Refrescar el calendario pa estar fachero perro xd
                    }
                }
            }
        }

        // 9 DE LA MAÑANA XD
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

        // tuuuuu ere mi papa?  Abajo conjuntos vacíos xd
        private void lblJueves_Click(object sender, EventArgs e) { }
        private void lblMiercoles_Click(object sender, EventArgs e) { }
        private void lblMartes_Click(object sender, EventArgs e) { }
        private void flDays_Paint(object sender, PaintEventArgs e) { }
    }
}
