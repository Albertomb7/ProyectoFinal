
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // Para SmoothingMode

namespace CalendarioApp
{
    public partial class UcDias : UserControl
    {
        private string _dia;
        private bool _tieneEvento;
        private Color? _colorPersonalizado;

        // --- Inicio de cambios para el Tema ---
        private bool isCurrentlyDark = true; // Estado del tema para este control
        internal Color colorBaseActual; // Color de fondo base según el tema

        // Colores Modo Oscuro para UcDias
        private readonly Color dark_BackColor = Color.FromArgb(40, 43, 50);
        private readonly Color dark_ForeColor = Color.White;
        private readonly Color dark_HoverColor = Color.FromArgb(60, 63, 70);

        // Colores Modo Claro para UcDias
        private readonly Color light_BackColor = Color.FromArgb(220, 220, 230);
        private readonly Color light_ForeColor = Color.Black;
        private readonly Color light_HoverColor = Color.FromArgb(190, 190, 200);
        // --- Fin de cambios para el Tema ---

        public DateTime FechaCelda { get; set; }
        public int CantidadEventos { get; set; } = 0;

        public UcDias()
        {
            InitializeComponent();

            this.Width = 100; // Estos podrían ser valores por defecto
            this.Height = 80;
            this.Margin = new Padding(1);

            

            if (lblDia != null)
            {
                // lblDia.ForeColor = Color.White; // Se definirá en AplicarTema
                lblDia.BackColor = Color.Transparent; // Mantener transparente
            }

            // Los manejadores de eventos para Click, MouseMove, MouseLeave ya están en InitializeComponent por el diseñador.
           
            AplicarTema(isCurrentlyDark); // Aplicar tema oscuro por defecto al crear instancia
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
                // AplicarColores(); // Esto ahora se maneja indirectamente por Invalidate y OnPaint
                this.Invalidate(); // Redibujar si cambia el estado del evento
            }
        }

        public Color? ColorPersonalizado
        {
            get => _colorPersonalizado;
            set
            {
                _colorPersonalizado = value;
                // AplicarColores();
                this.Invalidate(); // Redibujar si cambia el color del evento
            }
        }

        // --- Inicio de cambios para el Tema ---
        public void AplicarTema(bool modoOscuro)
        {
            isCurrentlyDark = modoOscuro;
            if (isCurrentlyDark)
            {
                colorBaseActual = dark_BackColor;
                if (lblDia != null) lblDia.ForeColor = dark_ForeColor;
            }
            else
            {
                colorBaseActual = light_BackColor;
                if (lblDia != null) lblDia.ForeColor = light_ForeColor;
            }
            this.BackColor = colorBaseActual;
            if (lblDia != null) lblDia.BackColor = Color.Transparent; // Asegurar transparencia del label
            this.Invalidate(); // Redibujar el control
        }
        // --- Fin de cambios para el Tema ---

        public event EventHandler DiaClickeado;

        // Este evento se dispara cuando se hace clic en lblDia, que cubre todo el UserControl.
        private void lblDia_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Dia)) // Asegurar que es un día válido
            {
                DiaClickeado?.Invoke(this, e); 
            }
        }

        // Eventos de Hover en lblDia (que actúa como la superficie principal de UcDias)
        private void lblDia_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = isCurrentlyDark ? dark_HoverColor : light_HoverColor;
        }

        private void lblDia_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorBaseActual; // Restaurar al color base del tema actual
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (TieneEvento && ColorPersonalizado.HasValue)
            {
                int tamañoCirculo = 20;
                int margen = 6;
                Color colorCirculo = ColorPersonalizado.Value;

                int x = this.Width - tamañoCirculo - margen;
                int y = margen;

                using (SolidBrush brush = new SolidBrush(colorCirculo))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(brush, x, y, tamañoCirculo, tamañoCirculo);
                }

                if (CantidadEventos > 1)
                {
                    // --- Inicio de cambios para el Tema (visibilidad del texto en el círculo) ---
                    Color textColorOnCircle;
                    // Heurística simple para elegir color de texto (negro o blanco) basado en la luminosidad del color del círculo
                    double luminancia = (0.299 * colorCirculo.R + 0.587 * colorCirculo.G + 0.114 * colorCirculo.B) / 255;
                    textColorOnCircle = luminancia > 0.5 ? Color.White : Color.Black;
                    // --- Fin de cambios para el Tema ---

                    using (Font fuente = new Font("Segoe UI", 10, FontStyle.Bold))
                    using (Brush textoBrush = new SolidBrush(textColorOnCircle)) // Usar el color de texto calculado
                    {
                        string texto = CantidadEventos.ToString();
                        SizeF tamañoTexto = e.Graphics.MeasureString(texto, fuente);

                        float textoX = x + (tamañoCirculo - tamañoTexto.Width) / 2;
                        float textoY = y + (tamañoCirculo - tamañoTexto.Height) / 2;

                        e.Graphics.DrawString(texto, fuente, textoBrush, textoX, textoY);
                    }
                }
            }
        }
    }
}