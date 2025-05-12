using System;
using System.Windows.Forms;

namespace CalendarioApp
{
    public partial class UcDias : UserControl
    {
        private string _dia;

        public UcDias()
        {
            InitializeComponent();

            // Establecer tamaño fijo del control para que encajen exactamente 7 por fila
            this.Width = 100;
            this.Height = 80;

            // Quitar márgenes para que no se desajuste el grid
            this.Margin = new Padding(0);

            // Opcional: para ver visualmente el tamaño si estás diseñando
            this.BackColor = System.Drawing.Color.Transparent;
        }

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
