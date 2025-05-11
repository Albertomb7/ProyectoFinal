using System;
using System.Globalization;
using System.Windows.Forms;
using CalendarioApp;

namespace ProyectoFinal.Calendario
{
    public partial class Inicio : Form
    {
        int mes, año;
        private Form formularioLogin; // Almacena el formulario login

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

            // Ajustar para que lunes sea el primer día (0 = lunes, ..., 6 = domingo)
            diaSemana = diaSemana == 0 ? 6 : diaSemana - 1;

            lblFecha.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes).ToUpper() + " " + año;

            // Espacios vacíos antes del primer día del mes
            for (int i = 0; i < diaSemana; i++)
            {
                UcDias espacio = new UcDias();
                espacio.Dia = "";
                espacio.Width = 90; // Ajusta estos valores a tu diseño
                espacio.Height = 80;
                flDays.Controls.Add(espacio);
            }

            // Agregar los días reales del mes
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                UcDias diaControl = new UcDias();
                diaControl.Dia = dia.ToString();
                diaControl.Width = 90;  // Asegúrate que el tamaño sea consistente
                diaControl.Height = 80;
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

        private void lblMartes_Click(object sender, EventArgs e)
        {

        }
    }
}
