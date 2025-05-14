using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalendarioApp
{
    public partial class UcDias : UserControl
    {
        private string _dia;
        private bool _tieneEvento;
        private Color? _colorPersonalizado;
        private Color colorBaseActual = Color.FromArgb(30, 30, 40); // Color base por defecto

        public DateTime FechaCelda { get; set; }

        public UcDias()
        {
            InitializeComponent();

            this.Width = 100;
            this.Height = 80;
            this.Margin = new Padding(1);
            this.BackColor = colorBaseActual;

            if (lblDia != null)
            {
                lblDia.ForeColor = Color.White;
                lblDia.BackColor = Color.Transparent;
            }

            this.Click += new EventHandler(UcDias_Click);
            this.MouseEnter += UcDias_MouseEnter;
            this.MouseLeave += UcDias_MouseLeave;
        }

        public string Dia
        {
            get => _dia;
            set
            {
                _dia = value;
                if (lblDia != null) lblDia.Text = value;
            }
        }

        public bool TieneEvento
        {
            get => _tieneEvento;
            set
            {
                _tieneEvento = value;
                AplicarColores();
            }
        }

        public Color? ColorPersonalizado
        {
            get => _colorPersonalizado;
            set
            {
                _colorPersonalizado = value;
                AplicarColores();
            }
        }

        private void AplicarColores()
        {
            colorBaseActual = _colorPersonalizado ?? Color.FromArgb(30, 30, 40);
            this.BackColor = colorBaseActual;
            this.Invalidate();
        }

        public event EventHandler DiaClickeado;

        private void UcDias_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Dia))
            {
                DiaClickeado?.Invoke(this, e);
            }
        }

        private void lblDia_Click(object sender, EventArgs e)
        {
            UcDias_Click(sender, e);
        }

        //no tocar
        private void UcDias_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 63, 70); // color resaltado al pasar el mouse
        }

        private void UcDias_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual; // volver al color original
        }
        private void lblDia_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 63, 70); // mismo color de resaltado
        }

        private void lblDia_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual;
        }

    }
}


