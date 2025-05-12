using System;
using System.Globalization;
using System.Windows.Forms;
using CalendarioApp;

namespace ProyectoFinal.Calendario
{
    public partial class Inicio : Form
    {
        int mes, año;
        private Form formularioLogin;

        public Inicio()
        {
            InitializeComponent();
        }

        public Inicio(Form login)
        {
            InitializeComponent();
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
            flDays.Controls.Clear();

            DateTime primerDiaDelMes = new DateTime(año, mes, 1);
            int diasEnMes = DateTime.DaysInMonth(año, mes);
            int diaSemana = (int)primerDiaDelMes.DayOfWeek;

            // Ajustar para que lunes sea 0 y domingo 6
            diaSemana = diaSemana == 0 ? 6 : diaSemana - 1;

            lblFecha.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes).ToUpper() + " " + año;

            int anchoDia = flDays.Width / 7; // Asegura 7 columnas
            int altoDia = 80; // Altura fija

            // Espacios vacíos antes del primer día
            for (int i = 0; i < diaSemana; i++)
            {
                UcDias espacio = new UcDias();
                espacio.Dia = "";
                espacio.Width = anchoDia;
                espacio.Height = altoDia;
                flDays.Controls.Add(espacio);
            }

            // Días del mes
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                UcDias diaControl = new UcDias();
                diaControl.Dia = dia.ToString();
                diaControl.Width = anchoDia;
                diaControl.Height = altoDia;
                flDays.Controls.Add(diaControl);
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

        private void lblJueves_Click(object sender, EventArgs e)
        {

        }

        private void lblMiercoles_Click(object sender, EventArgs e)
        {

        }

        private void lblMartes_Click(object sender, EventArgs e)
        {
            // Puedes eliminar este método si no se usa
        }
    }
}
