using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class CalendarioForm : Form
    {
        // Fecha del mes actualmente visible
        private DateTime mesActual;

        // Diccionario para guardar notas asociadas a fechas específicas
        private Dictionary<DateTime, string> notas = new Dictionary<DateTime, string>();

        // Referencia al botón del día actualmente seleccionado
        private Button diaSeleccionado;

        public CalendarioForm()
        {
            InitializeComponent(); // Inicializa los controles del formulario
            mesActual = DateTime.Today; // Establece el mes actual como el mes visible
            MostrarCalendario(); // Genera el calendario
            MessageBox.Show("Se llamó a MostrarCalendario()"); // Mensaje de depuración
        }

        /// <summary>
        /// Genera dinámicamente el calendario del mes actual en una tabla (TableLayoutPanel).
        /// </summary>
        private void MostrarCalendario()
        {
            // Actualiza el texto de la etiqueta con el mes y año actual
            lblMesActual.Text = mesActual.ToString("MMMM yyyy").ToUpper();

            // Limpia controles previos del calendario
            tableCalendario.Controls.Clear();

            // Configura las filas y columnas del calendario
            tableCalendario.ColumnCount = 7;
            tableCalendario.RowCount = 7;
            tableCalendario.ColumnStyles.Clear();
            tableCalendario.RowStyles.Clear();

            // Define que cada columna y fila ocupa el mismo porcentaje del espacio
            for (int i = 0; i < 7; i++)
                tableCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            for (int i = 0; i < 7; i++)
                tableCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 7));

            // Agrega nombres de los días de la semana en la primera fila
            string[] dias = { "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom" };
            for (int i = 0; i < 7; i++)
            {
                var lbl = new Label
                {
                    Text = dias[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                tableCalendario.Controls.Add(lbl, i, 0);
            }

            // Determina el primer día del mes y su posición en la cuadrícula
            DateTime primerDiaMes = new DateTime(mesActual.Year, mesActual.Month, 1);
            int offset = ((int)primerDiaMes.DayOfWeek + 6) % 7; // Ajuste para que lunes sea 0
            int diasEnMes = DateTime.DaysInMonth(mesActual.Year, mesActual.Month);

            int fila = 1, columna = offset;

            // Crea un botón para cada día del mes
            for (int dia = 1; dia <= diasEnMes; dia++)
            {
                var fecha = new DateTime(mesActual.Year, mesActual.Month, dia);
                var btn = new Button
                {
                    Text = dia.ToString(),
                    Dock = DockStyle.Fill,
                    Tag = fecha, // Almacena la fecha en el Tag
                    BackColor = notas.ContainsKey(fecha) ? Color.LightYellow : Color.White
                };
                btn.Click += Dia_Click;
                tableCalendario.Controls.Add(btn, columna, fila);

                // Avanza columna; si llega al final, pasa a la siguiente fila
                columna++;
                if (columna == 7)
                {
                    columna = 0;
                    fila++;
                }
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic sobre un botón de día.
        /// </summary>
        private void Dia_Click(object sender, EventArgs e)
        {
            // Restaura el color del día previamente seleccionado
            if (diaSeleccionado != null)
                diaSeleccionado.BackColor = notas.ContainsKey((DateTime)diaSeleccionado.Tag) ? Color.LightYellow : Color.White;

            // Establece el nuevo día seleccionado
            diaSeleccionado = sender as Button;
            diaSeleccionado.BackColor = Color.LightBlue;

            // Carga la nota correspondiente al día seleccionado (si existe)
            DateTime fecha = (DateTime)diaSeleccionado.Tag;
            txtNota.Text = notas.ContainsKey(fecha) ? notas[fecha] : "";
            txtNota.Tag = fecha; // Guarda la fecha para el control txtNota
        }

        /// <summary>
        /// Evento que se dispara cuando el texto de la nota cambia.
        /// </summary>
        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            if (txtNota.Tag is DateTime fecha)
            {
                // Guarda o elimina la nota según su contenido
                if (string.IsNullOrWhiteSpace(txtNota.Text))
                    notas.Remove(fecha);
                else
                    notas[fecha] = txtNota.Text;

                // Actualiza el color del botón del día
                foreach (Control c in tableCalendario.Controls)
                {
                    if (c is Button btn && btn.Tag is DateTime f && f == fecha)
                    {
                        btn.BackColor = Color.LightYellow;
                        if (btn == diaSeleccionado)
                            btn.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        /// <summary>
        /// Muestra el mes anterior al actual.
        /// </summary>
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            mesActual = mesActual.AddMonths(-1);
            MostrarCalendario();
            txtNota.Clear();
        }

        /// <summary>
        /// Muestra el mes siguiente al actual.
        /// </summary>
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            mesActual = mesActual.AddMonths(1);
            MostrarCalendario();
            txtNota.Clear();
        }
    }
}




