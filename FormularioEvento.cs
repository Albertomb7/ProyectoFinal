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
            _eventosExistentesEnElDia = eventosDelDia;

            
            if (lblFechaSeleccionada != null) lblFechaSeleccionada.Text = fecha.ToString("D");
            if (dtpHoraEvento != null)
            {
                dtpHoraEvento.Format = DateTimePickerFormat.Time;
                dtpHoraEvento.ShowUpDown = true;
                dtpHoraEvento.Value = DateTime.Now;
                if (chkUsarHora != null) dtpHoraEvento.Enabled = chkUsarHora.Checked;   
            }

            CargarEventosEnLista();
        }

        private void CargarEventosEnLista()
        {
            if (lstEventosDelDia == null) return; // Seguridad por si el control no está listo
            lstEventosDelDia.Items.Clear();
            if (_eventosExistentesEnElDia != null && _eventosExistentesEnElDia.Any())
            {
                foreach (var ev in _eventosExistentesEnElDia.OrderBy(e => e.Hora ?? TimeSpan.MaxValue).ThenBy(e => e.Descripcion))
                {
                    lstEventosDelDia.Items.Add(ev);
                }
            }
            else
            {
                lstEventosDelDia.Items.Add("No hay eventos para este día.");
                lstEventosDelDia.ClearSelected();

            }
            LimpiarCamposNuevaEntrada();
        }

        private void LimpiarCamposNuevaEntrada()
        {
            if (txtDescripcionEvento != null) txtDescripcionEvento.Clear();
            if (chkUsarHora != null) chkUsarHora.Checked = false;
            if (dtpHoraEvento != null) dtpHoraEvento.Value = DateTime.Now;
            _eventoSeleccionadoEnLista = null;
            if (btnGuardar != null) btnGuardar.Text = "Guardar Nuevo";
            if (btnEliminar != null) btnEliminar.Enabled = false;
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

            if (_eventoSeleccionadoEnLista != null)
            {
                _eventoSeleccionadoEnLista.Descripcion = txtDescripcionEvento.Text;
                _eventoSeleccionadoEnLista.Hora = hora;
                _eventoSeleccionadoEnLista.ColorPersonalizado = _colorSeleccionado; // nuevo
                EventoCreadoOModificado = _eventoSeleccionadoEnLista;
            }
            else
            {
                EventoCreadoOModificado = new Evento(_fechaActual, txtDescripcionEvento.Text, hora, _colorSeleccionado);
                // evento color 
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
                        dtpHoraEvento.Value = _fechaActual.Date + evento.Hora.Value;
                    }
                    else
                    {
                        dtpHoraEvento.Value = DateTime.Now;
                    }
                }

                _colorSeleccionado = evento.ColorPersonalizado; // <<< Agregado
                PanelColor.BackColor = evento.ColorPersonalizado ?? SystemColors.Control; // <<< Agregado

                if (btnGuardar != null) btnGuardar.Text = "Actualizar";
                if (btnEliminar != null) btnEliminar.Enabled = true;
                if (PanelColor != null)
                {
                    PanelColor.BackColor = evento.ColorPersonalizado ?? SystemColors.Control;
                }

            }
            else
            {
                LimpiarCamposNuevaEntrada();
            }
        }


        private Color? _colorSeleccionado = null; // agrege una funcion para la vista del color

        private void btnSeleccionarColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _colorSeleccionado = colorDialog.Color;
                    PanelColor.BackColor = colorDialog.Color;
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
