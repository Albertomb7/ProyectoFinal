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

        private void Inicio_Load(object sender, EventArgs e)
        {
            _login.Hide();  
        }
    }
}
