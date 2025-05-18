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
        private Color colorBaseActual = Color.FromArgb(30, 30, 40); // Color base oscuro predeterminado // R,S. Estilo visual uniforme

        public DateTime FechaCelda { get; set; }

        // NUEVA propiedad para saber cuántos eventos tiene un día // R,S.
        public int CantidadEventos { get; set; } = 0; // R,S. Nos permite mostrar un número de eventos si hay más de uno

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
            // Siempre usar fondo base oscuro, no sobrescribir con color del evento // R,S. Mantiene la estética uniforme del calendario
            colorBaseActual = Color.FromArgb(30, 30, 40); // R,S.
            this.BackColor = colorBaseActual; // R,S.
            this.Invalidate(); // Redibuja el control para que se muestre el círculo de evento // R,S.
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
            this.BackColor = Color.FromArgb(60, 63, 70); // Color más claro al hacer hover
        }

        private void UcDias_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual; // Restaurar color original del control
        }

        private void lblDia_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 63, 70); // Hover sobre el número del día
        }

        private void lblDia_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual;
        }

        // PERSONALIZACIÓN: Dibuja círculo superior derecho si el día tiene evento // R,S.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (TieneEvento && ColorPersonalizado.HasValue) // Validamos si se debe dibujar // R,S.
            {
                int tamañoCirculo = 14; // Tamaño del círculo visual // R,S.
                int margen = 6; // Separación del borde // R,S.
                Color colorCirculo = ColorPersonalizado.Value;

                int x = this.Width - tamañoCirculo - margen;
                int y = margen; // Parte superior (antes era parte inferior) // R,S.

                using (SolidBrush brush = new SolidBrush(colorCirculo))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(brush, x, y, tamañoCirculo, tamañoCirculo); // Dibujar el círculo de notificación // R,S.
                }

                // Si hay más de un evento, mostramos un número dentro del círculo // R,S.
                if (CantidadEventos > 1)
                {
                    using (Font fuente = new Font("Segoe UI", 7, FontStyle.Bold))
                    using (Brush textoBrush = new SolidBrush(Color.White))
                    {
                        string texto = CantidadEventos.ToString();
                        SizeF tamañoTexto = e.Graphics.MeasureString(texto, fuente);

                        float textoX = x + (tamañoCirculo - tamañoTexto.Width) / 2;
                        float textoY = y + (tamañoCirculo - tamañoTexto.Height) / 2;

                        e.Graphics.DrawString(texto, fuente, textoBrush, textoX, textoY); // Número centrado dentro del círculo // R,S.
                    }
                }
            }
        }
    }
}
