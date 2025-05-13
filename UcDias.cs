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


        public DateTime FechaCelda { get; set; }

        public UcDias()

        {

            InitializeComponent();

            // Tema oscuro por defecto
            this.Width = 100;
            this.Height = 80;
            this.Margin = new Padding(1);
            this.BackColor = Color.FromArgb(30, 30, 40); // Default

            if (lblDia != null)
            {
                lblDia.ForeColor = Color.White;
                lblDia.BackColor = Color.Transparent; // Para que se vea bien sobre el fondo
                lblDia.Click += (s, e) => this.OnClick(e);
            }

            this.Click += new EventHandler(UcDias_Click);

            // Eventos de mouse para resaltar al pasar sobre el día
            this.MouseEnter += (s, e) =>
            {
                IniciarTransicion(Color.FromArgb(60, 63, 70)); // Color cuando pasa el mouse
            };

            this.MouseLeave += (s, e) =>
            {
                IniciarTransicion(Color.FromArgb(30, 30, 40)); // Color original
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
            this.BackColor = Color.FromArgb(30, 30, 40); // Color oscuro por defecto SIEMPRE
            this.Invalidate(); // Forzar repintado (llama a OnPaint para mostrar el círculo si hay evento)
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
            // Delegamos el clic a la celda
            UcDias_Click(sender, e);
        }
        private void IniciarTransicion(Color destino) //trancicion de movimiento
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_tieneEvento && _colorPersonalizado.HasValue)
            {
                Graphics g = e.Graphics;
                Color color = _colorPersonalizado.Value;

                int radio = 10;
                int margen = 5;
                int x = this.Width - radio - margen;
                int y = margen;

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(brush, x, y, radio, radio);
                }
            }
        }
    }
}
