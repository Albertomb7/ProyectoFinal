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
        private Timer hoverTimer;
        private Color colorInicio;
        private Color colorDestino;
        private int pasoAnimacion;
        private const int pasosTotales = 10;
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
                //linea hija ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd xd
            }

            this.Click += new EventHandler(UcDias_Click);

            this.MouseEnter += (s, e) =>
            {
                IniciarTransicion(Color.FromArgb(60, 63, 70)); // Hover
            };

            this.MouseLeave += (s, e) =>
            {
                IniciarTransicion(colorBaseActual); // Vuelve al color base (puede ser personalizado)
            };
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

        private void IniciarTransicion(Color destino)
        {
            colorInicio = this.BackColor;
            colorDestino = destino;
            pasoAnimacion = 0;

            if (hoverTimer == null)
            {
                hoverTimer = new Timer();
                hoverTimer.Interval = 15;
                hoverTimer.Tick += (s, e) =>
                {
                    pasoAnimacion++;
                    float progreso = pasoAnimacion / (float)pasosTotales;

                    int r = (int)(colorInicio.R + (colorDestino.R - colorInicio.R) * progreso);
                    int g = (int)(colorInicio.G + (colorDestino.G - colorInicio.G) * progreso);
                    int b = (int)(colorInicio.B + (colorDestino.B - colorInicio.B) * progreso);

                    this.BackColor = Color.FromArgb(r, g, b);

                    if (pasoAnimacion >= pasosTotales)
                    {
                        hoverTimer.Stop();
                    }
                };
            }

            hoverTimer.Start();
        }
    }
}
