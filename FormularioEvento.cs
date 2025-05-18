// FormularioEvento.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFinal.Calendario // AJUSTA EL NAMESPACE UWU
{
    public partial class FormularioEvento : Form
    {
        public Evento EventoCreadoOModificado { get; private set; }
        public Evento EventoAEliminar { get; private set; }
        private DateTime _fechaActual;
        private List<Evento> _eventosExistentesEnElDia;
        private Evento _eventoSeleccionadoEnLista;

        public FormularioEvento(DateTime fecha, List<Evento> eventosDelDia)
        {
            InitializeComponent(); // Esta línea llama al código en FormularioEvento.Designer.cs
            _fechaActual = fecha;
           
            _eventosExistentesEnElDia = eventosDelDia ?? new List<Evento>();


            if (lblFechaSeleccionada != null) lblFechaSeleccionada.Text = fecha.ToString("D");
            if (dtpHoraEvento != null)
            {
                dtpHoraEvento.Format = DateTimePickerFormat.Time;
                dtpHoraEvento.ShowUpDown = true;
                dtpHoraEvento.Value = DateTime.Now; 
                if (chkUsarHora != null) dtpHoraEvento.Enabled = chkUsarHora.Checked;
            }
            // El if (dtpHoraEvento == null) {} es un bloque vacío, no afecta.

            CargarEventosEnLista();
        }

        private void CargarEventosEnLista()
        {
            if (lstEventosDelDia == null) return;

            lstEventosDelDia.Items.Clear();

            // nuevo _eventosExistentesEnElDia
            if (_eventosExistentesEnElDia != null && _eventosExistentesEnElDia.Any())
            {
                

                foreach (var ev in _eventosExistentesEnElDia.OrderBy(e => e.Hora ?? TimeSpan.MaxValue).ThenBy(e => e.Descripcion))
                {
                    lstEventosDelDia.Items.Add(ev);
                }
            }
            else
            {
                // System.Diagnostics.Debug.WriteLine($"No hay eventos para cargar en el ListBox para {_fechaActual.ToShortDateString()}");
                lstEventosDelDia.Items.Add("No hay eventos para este día.");
                lstEventosDelDia.ClearSelected(); 
            }

            // MODIFICACIÓN: Forzar un refresco visual del ListBox
            
            // El LimpiarCamposNuevaEntrada() al final está bien resetea los campos para una nueva entrada o estado por defecto.
            LimpiarCamposNuevaEntrada();
        }

        private void LimpiarCamposNuevaEntrada()
        {
            if (txtDescripcionEvento != null) txtDescripcionEvento.Clear();
            if (chkUsarHora != null) chkUsarHora.Checked = false;
            if (dtpHoraEvento != null)
            {
                // Resetea la hora al mediodía de la fecha actual
                dtpHoraEvento.Value = _fechaActual.Date.AddHours(12);
               
            }
            _eventoSeleccionadoEnLista = null;
            if (btnGuardar != null) btnGuardar.Text = "Guardar Nuevo";
            if (btnEliminar != null) btnEliminar.Enabled = false;
            if (PanelColor != null) PanelColor.BackColor = SystemColors.Control; // Resetear el color del panel
            _colorSeleccionado = null; // Resetear el color seleccionado
        }

        private void chkUsarHora_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpHoraEvento != null && chkUsarHora != null)
                dtpHoraEvento.Enabled = chkUsarHora.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcionEvento == null || string.IsNullOrWhiteSpace(txtDescripcionEvento.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan? hora = null;
            if (chkUsarHora != null && chkUsarHora.Checked && dtpHoraEvento != null)
            {
                hora = dtpHoraEvento.Value.TimeOfDay;
            }

            if (_eventoSeleccionadoEnLista != null) // Modificando
            {
                _eventoSeleccionadoEnLista.Descripcion = txtDescripcionEvento.Text;
                _eventoSeleccionadoEnLista.Hora = hora;
                _eventoSeleccionadoEnLista.ColorPersonalizado = _colorSeleccionado;
                EventoCreadoOModificado = _eventoSeleccionadoEnLista;
            }
            else // Creando nuevo Evento
            {
                // _fechaActual ya tiene la fecha correcta con hora 00:00:00 del día seleccionado.
                EventoCreadoOModificado = new Evento(_fechaActual.Date, txtDescripcionEvento.Text, hora, _colorSeleccionado);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lstEventosDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEventosDelDia != null && lstEventosDelDia.SelectedItem is Evento evento)
            {
                _eventoSeleccionadoEnLista = evento;
                if (txtDescripcionEvento != null) txtDescripcionEvento.Text = evento.Descripcion;
                if (chkUsarHora != null) chkUsarHora.Checked = evento.Hora.HasValue;

                if (dtpHoraEvento != null)
                {
                    if (evento.Hora.HasValue)
                    {
                        // Asegura que la fecha base del DateTimePicker sea la fecha del evento actual, no la fecha de hoy.
                        dtpHoraEvento.Value = _fechaActual.Date + evento.Hora.Value;
                    }
                    else
                    {
                        // Si no hay hora resetea al mediodía de la fecha actual del formulario.
                        dtpHoraEvento.Value = _fechaActual.Date.AddHours(12);
                    }
                }

                _colorSeleccionado = evento.ColorPersonalizado;
                if (PanelColor != null)
                {
                    PanelColor.BackColor = evento.ColorPersonalizado ?? SystemColors.Control;
                }


                if (btnGuardar != null) btnGuardar.Text = "Actualizar";
                if (btnEliminar != null) btnEliminar.Enabled = true;
            }
            else
            {
                // Si se deselecciona o el ítem no es un Evento (ej. "No hay eventos..."), limpiar campos.
                LimpiarCamposNuevaEntrada();
            }
        }

        private Color? _colorSeleccionado = null;

        private void btnSeleccionarColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Opcional: establecer el color actual si ya hay uno seleccionado
                if (_colorSeleccionado.HasValue)
                {
                    colorDialog.Color = _colorSeleccionado.Value;
                }

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _colorSeleccionado = colorDialog.Color;
                    if (PanelColor != null) PanelColor.BackColor = colorDialog.Color;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_eventoSeleccionadoEnLista != null)
            {
                if (MessageBox.Show($"¿Seguro que quieres eliminar el evento: '{_eventoSeleccionadoEnLista.Descripcion}'?",
                                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EventoAEliminar = _eventoSeleccionadoEnLista;
                    this.DialogResult = DialogResult.OK; // Indica que la operación fue "exitosa" para que Inicio.cs procese la eliminación.
                    this.Close();
                }
            }
        }
        //Esta de mas si van agrear el evento en el designer lo borran
        private void txtDescripcionEvento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}