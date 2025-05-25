// {{Nombre del archivo: albertomb7/proyectofinal/ProyectoFinal-da20101d38e16f72249e912a01f958d7214d6f9a/FormularioEvento.cs}}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFinal.Calendario // Asegúrate que este namespace coincida con el de tu proyecto
{
    public partial class FormularioEvento : Form
    {
        public Evento EventoCreadoOModificado { get; private set; }
        public Evento EventoAEliminar { get; private set; } // Para notificar a Inicio.cs si se eliminó un evento
        private DateTime _fechaActual;
        private List<Evento> _eventosExistentesEnElDia; // Lista de eventos para el día actual mostrada en el ListBox
        private Evento _eventoSeleccionadoEnLista; // El evento que se está editando o el seleccionado en la lista
        private Color? _colorSeleccionado = null; // Color seleccionado para el evento

        // Constructor original (para agregar nuevo evento o simplemente ver la lista del día)
        public FormularioEvento(DateTime fecha, List<Evento> eventosDelDia)
        {
            InitializeComponent();
            _fechaActual = fecha;
            // La lista 'eventosDelDia' que se pasa aquí es la que se cargó en Inicio.cs desde la BD.
            // La usaremos para poblar el ListBox del FormularioEvento.
            // También obtenemos una copia fresca de la BD para asegurar consistencia interna si es necesario.
            _eventosExistentesEnElDia = Evento.ObtenerEventosExistentes(_fechaActual.Date); //

            if (lblFechaSeleccionada != null) lblFechaSeleccionada.Text = fecha.ToString("D");
            if (dtpHoraEvento != null)
            {
                dtpHoraEvento.Format = DateTimePickerFormat.Time;
                dtpHoraEvento.ShowUpDown = true;
                // Establecer la hora a la actual del día seleccionado
                dtpHoraEvento.Value = _fechaActual.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                if (chkUsarHora != null) dtpHoraEvento.Enabled = chkUsarHora.Checked;
            }

            CargarEventosEnLista(); // Carga los eventos en lstEventosDelDia
            LimpiarCamposNuevaEntrada(); // Configura el formulario para una nueva entrada por defecto
        }

        // NUEVO CONSTRUCTOR para editar un evento específico
        public FormularioEvento(DateTime fecha, List<Evento> eventosDelDia, Evento eventoAEditar)
            : this(fecha, eventosDelDia) // Llama al constructor anterior para la inicialización base
        {
            // El constructor base ya inicializó componentes, fecha, _eventosExistentesEnElDia, etc.
            // y llamó a CargarEventosEnLista y LimpiarCamposNuevaEntrada.
            // Ahora, cargamos el evento específico que se va a editar.
            if (eventoAEditar != null)
            {
                CargarEventoParaEdicion(eventoAEditar);
            }
        }

        private void CargarEventosEnLista()
        {
            if (lstEventosDelDia == null) return;

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
            }
            lstEventosDelDia.ClearSelected();
        }

        // MÉTODO MODIFICADO
        private void LimpiarCamposNuevaEntrada()
        {
            if (txtDescripcionEvento != null) txtDescripcionEvento.Clear();
            if (chkUsarHora != null) chkUsarHora.Checked = false; // Esto también afectará dtpHoraEvento.Enabled

            if (dtpHoraEvento != null)
            {
                // Establecer la hora a mediodía o la hora actual, como prefieras para un nuevo evento
                dtpHoraEvento.Value = _fechaActual.Date.AddHours(12); // Mediodía por defecto
                // dtpHoraEvento.Enabled se maneja por el evento CheckedChanged de chkUsarHora
            }

            _eventoSeleccionadoEnLista = null;

            _colorSeleccionado = null;
            if (PanelColor != null) PanelColor.BackColor = SystemColors.Control;

            if (btnGuardar != null) // Botón para "Guardar Nuevo"
            {
                btnGuardar.Text = "Guardar Nuevo";
                btnGuardar.Visible = true;
            }
            if (btn_actuzalizar != null) // Botón para "Actualizar" o "Guardar Cambios"
            {
                btn_actuzalizar.Visible = false;
            }
            if (btnEliminar != null)
            {
                btnEliminar.Enabled = false;
            }

            if (lstEventosDelDia != null) lstEventosDelDia.ClearSelected();
        }

        private void chkUsarHora_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpHoraEvento != null && chkUsarHora != null)
                dtpHoraEvento.Enabled = chkUsarHora.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Botón "Guardar Nuevo"
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

            // Creando nuevo Evento
            // El IdEvento se asignará automáticamente por la base de datos (si es autoincremental)
            // o se puede manejar de otra forma si es necesario. Aquí pasamos 0 o un valor por defecto.
            EventoCreadoOModificado = new Evento(0, _fechaActual.Date, txtDescripcionEvento.Text, hora, _colorSeleccionado);
            int resultadoCreacion = Evento.CrearEvento(EventoCreadoOModificado); //

            if (resultadoCreacion > 0)
            {
                MessageBox.Show("Evento creado con éxito.", "Evento Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // MÉTODO MODIFICADO
        private void lstEventosDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEventosDelDia != null && lstEventosDelDia.SelectedItem is Evento evento)
            {
                // Solo cargar para edición si no es el mismo que ya se está editando (evitar recargas innecesarias si ya está cargado)
                // o si _eventoSeleccionadoEnLista es null (es la primera vez que se selecciona algo).
                if (_eventoSeleccionadoEnLista == null || !_eventoSeleccionadoEnLista.Equals(evento))
                {
                    CargarEventoParaEdicion(evento);
                }
            }
            // No limpiamos los campos aquí para permitir al usuario ver la lista y luego decidir.
            // Si se deselecciona explícitamente (SelectedItem es null), se podría llamar a LimpiarCamposNuevaEntrada.
        }

        // NUEVO MÉTODO
        private void CargarEventoParaEdicion(Evento evento)
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
                    dtpHoraEvento.Value = _fechaActual.Date.AddHours(12); // Mediodía por defecto
                }
                // dtpHoraEvento.Enabled se actualiza con chkUsarHora_CheckedChanged
            }

            _colorSeleccionado = evento.ColorPersonalizado;
            if (PanelColor != null)
            {
                PanelColor.BackColor = evento.ColorPersonalizado ?? SystemColors.Control;
            }

            // Configurar botones para el modo edición
            if (btnGuardar != null) // Botón "Guardar Nuevo"
            {
                btnGuardar.Visible = false;
            }
            if (btn_actuzalizar != null) // Botón "Actualizar" o "Guardar Cambios"
            {
                btn_actuzalizar.Visible = true;
                btn_actuzalizar.Text = "Guardar Cambios";
            }
            if (btnEliminar != null)
            {
                btnEliminar.Enabled = true;
            }

            // No es necesario seleccionar en lstEventosDelDia aquí, porque este método
            // usualmente se llama *desde* la selección en lstEventosDelDia.
        }

        private void btnSeleccionarColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
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
                    int resultadoEliminacion = Evento.EliminarEvento(_eventoSeleccionadoEnLista); //
                    if (resultadoEliminacion > 0)
                    {
                        MessageBox.Show("Evento eliminado con exito.", "Evento eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EventoAEliminar = _eventoSeleccionadoEnLista; // Para que Inicio.cs sepa cuál se eliminó
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el evento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtDescripcionEvento_TextChanged(object sender, EventArgs e)
        {
            // Puedes agregar validaciones o lógica aquí si es necesario
        }

        // MÉTODO btn_actuzalizar_Click (ASEGÚRATE DE QUE ACTUALIZA _eventoSeleccionadoEnLista)
        private void btn_actuzalizar_Click(object sender, EventArgs e) // Botón "Actualizar" o "Guardar Cambios"
        {
            if (_eventoSeleccionadoEnLista == null)
            {
                MessageBox.Show("No hay un evento seleccionado para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcionEvento.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar antes de actualizar
            // if (MessageBox.Show($"¿Seguro que quieres actualizar el evento: '{_eventoSeleccionadoEnLista.Descripcion}'?", //
            //                     "Confirmar Actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            // {
            TimeSpan? hora = null;
            if (chkUsarHora != null && chkUsarHora.Checked && dtpHoraEvento != null)
            {
                hora = dtpHoraEvento.Value.TimeOfDay;
            }

            // Actualizar las propiedades del objeto _eventoSeleccionadoEnLista CON LOS DATOS DE LOS CAMPOS DEL FORMULARIO
            _eventoSeleccionadoEnLista.Descripcion = txtDescripcionEvento.Text;
            _eventoSeleccionadoEnLista.Hora = hora;
            _eventoSeleccionadoEnLista.ColorPersonalizado = _colorSeleccionado; // _colorSeleccionado se actualiza con btnSeleccionarColor_Click

            int resultadoActualizacion = Evento.ActualizarEvento(_eventoSeleccionadoEnLista); //

            if (resultadoActualizacion > 0)
            {
                MessageBox.Show("Evento actualizado con exito.", "Evento actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EventoCreadoOModificado = _eventoSeleccionadoEnLista; // Para que Inicio.cs sepa cuál se modificó
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el evento o no se realizaron cambios.", "Error/Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // } // Fin del MessageBox de confirmación (opcional)
        }

        private void dtpHoraEvento_ValueChanged(object sender, EventArgs e)
        {
            // Lógica si es necesaria cuando cambia la hora
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PanelColor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}