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
        private Color colorBaseActual = Color.FromArgb(30, 30, 40); // Color base por defecto // R,S.

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
            // Siempre usamos el fondo oscuro, sin pintar por el evento // R,S.
            colorBaseActual = Color.FromArgb(30, 30, 40); // R,S.
            this.BackColor = colorBaseActual; // R,S.
            this.Invalidate(); // Para que se dibuje el círculo si tiene evento // R,S.
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

        private void UcDias_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 63, 70); // solo cambia visualmente
        }

        private void UcDias_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual; // restaura el color personalizado
        }

        private void lblDia_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 63, 70); // efecto hover
        }

        private void lblDia_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual; // vuelve al color original
        }

        //NUEVO MÉTODO: Dibuja un círculo en la esquina si el día tiene evento // R,S.
        protected override void OnPaint(PaintEventArgs e) 
        {
            base.OnPaint(e); // R,S.

            if (TieneEvento && ColorPersonalizado.HasValue) 
            {
                int tamañoCirculo = 12; 
                int margen = 6; 
                Color colorCirculo = ColorPersonalizado.Value; 

                using (SolidBrush brush = new SolidBrush(colorCirculo)) 
                {
                    int x = this.Width - tamañoCirculo - margen;
                    int y = margen; //Esto coloca en la parte superior el punto// R,S.
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; 
                    e.Graphics.FillEllipse(brush, x, y, tamañoCirculo, tamañoCirculo); 
                }
            }
        }
    }
}
