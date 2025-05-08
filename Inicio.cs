using System;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Inicio : Form
    {
        int mes, año;

        public Inicio()
        {
            InitializeComponent();
            mes = DateTime.Now.Month;
            año = DateTime.Now.Year;
            MostrarDiasDelMes(mes, año);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            fLDias.Controls.Clear();
            mes--;

            if (mes < 1)
            {
                mes = 12;
                año--;
            }

            MostrarDiasDelMes(mes, año);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            fLDias.Controls.Clear();
            mes++;

            if (mes > 12)
            {
                mes = 1;
                año++;
            }

            MostrarDiasDelMes(mes, año);
        }

        private void MostrarDiasDelMes(int mes, int año)
        {
            DateTime primerDiaDelMes = new DateTime(año, mes, 1);
            int diasEnElMes = DateTime.DaysInMonth(año, mes);
            int diaDeLaSemana = (int)primerDiaDelMes.DayOfWeek;

            for (int i = 0; i < diaDeLaSemana; i++)
            {
                Panel panel = new Panel();
                panel.Width = 100;
                panel.Height = 80;
                fLDias.Controls.Add(panel);
            }

            for (int dia = 1; dia <= diasEnElMes; dia++)
            {
                UcDias diaControl = new UcDias();
                diaControl.Dia = dia.ToString();  // Corrección aquí
                fLDias.Controls.Add(diaControl);
            }
        }
    }
}
