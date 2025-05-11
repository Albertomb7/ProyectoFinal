using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Inicio : Form
    {
        private login _login;
        public Inicio(login login)
        {
            InitializeComponent();
            _login = login;

    

           
        }

        private void Calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start;
            MessageBox.Show("Seleccionaste: " + fechaSeleccionada.ToShortDateString());
        }

        

        private void Inicio_Load(object sender, EventArgs e)
        {
            _login.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
