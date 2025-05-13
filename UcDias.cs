// UcDias.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalendarioApp 
{                         // Gay el que revise esto xdddddddddddd
    public partial class UcDias : UserControl
    {
        private string _dia;
        public DateTime FechaCelda { get; set; }
        private bool _tieneEvento;

        public UcDias()
        {
            InitializeComponent(); // Esta línea llama al código en UcDias.Designer.cs

            // Configuraciones  para el tema oscuro:
            this.Width = 100; // Ancho que usas en Inicio.cs
            this.Height = 80; // Alto que usas en Inicio.cs
            this.Margin = new Padding(1);
            this.BackColor = Color.FromArgb(30, 30, 40);
            if (lblDia != null) // lblDia se crea en InitializeComponent()
            {
                lblDia.ForeColor = Color.White;
                
                this.lblDia.Click += (s, e) => this.OnClick(e);
            }

            this.Click += new EventHandler(UcDias_Click);
        }

        public string Dia
        {
            get { return _dia; }
            set
            {
                _dia = value;
                if (lblDia != null) lblDia.Text = value;
            }
        }

        public bool TieneEvento
        {
            get { return _tieneEvento; }
            set
            {
                _tieneEvento = value;
                this.BackColor = _tieneEvento ? Color.FromArgb(70, 90, 120) : Color.FromArgb(30, 30, 40);
            }
        }

        public event EventHandler DiaClickeado;

        private void UcDias_Click(object sender, EventArgs e)
        {
            // Solo invocar si el día no está vacío 
            if (!string.IsNullOrEmpty(this.Dia))
            {
                DiaClickeado?.Invoke(this, e);
            }
        }

        private void lblDia_Click(object sender, EventArgs e)
        {

        }

       // tu ere mi papa ?
    }
}