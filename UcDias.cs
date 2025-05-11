using System;
using System.Windows.Forms;

namespace CalendarioApp
{
    public partial class UcDias : UserControl
    {
        public UcDias()
        {
            InitializeComponent();
        }

        private string _dia;
        public string Dia
        {
            get { return _dia; }
            set
            {
                _dia = value;
                lblDia.Text = value;
            }
        }

        private void lblDia_Click(object sender, EventArgs e)
        {
            // Aquí puedes manejar eventos si quieres hacer algo al hacer clic
        }
    }
}
