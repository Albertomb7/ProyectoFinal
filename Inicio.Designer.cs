



namespace ProyectoFinal.Calendario
{
    partial class Inicio
    {
       
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       
        /// <param name="disposing"
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // <summary> CODIGO GENERADO POR EL DISEÑADOR DE WINDOWS FORMS. NO LO MODIFIQUEN CON EL EDITOR DE CÓDIGO. XD </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.lblFecha = new System.Windows.Forms.Label();
            this.pbAnterior = new System.Windows.Forms.PictureBox();
            this.pbSiguiente = new System.Windows.Forms.PictureBox();
            this.lblLunes = new System.Windows.Forms.Label();
            this.lblMartes = new System.Windows.Forms.Label();
            this.lblViernes = new System.Windows.Forms.Label();
            this.lblMiercoles = new System.Windows.Forms.Label();
            this.lblJueves = new System.Windows.Forms.Label();
            this.lblSabado = new System.Windows.Forms.Label();
            this.lblDomingo = new System.Windows.Forms.Label();
            this.flDays = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFechaDelEvento = new System.Windows.Forms.Label();
            this.btnGestionarEventosDia = new System.Windows.Forms.Button();
            this.lstMostrarEventosInicio = new System.Windows.Forms.ListBox();
            this.btnAjustes = new System.Windows.Forms.Button();
            this.pnConfiguracion = new System.Windows.Forms.Panel();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_idInformacion = new System.Windows.Forms.Label();
            this.lbl_usuarioInformacion = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnCambioDeColorFondo = new System.Windows.Forms.Button();
            this.lblUsuarioInicial = new System.Windows.Forms.Label();
            this.btnEditarEvento = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSiguiente)).BeginInit();
            this.pnConfiguracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(44, 31);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 54);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbAnterior
            // 
            this.pbAnterior.BackColor = System.Drawing.Color.Transparent;
            this.pbAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("pbAnterior.Image")));
            this.pbAnterior.Location = new System.Drawing.Point(877, 31);
            this.pbAnterior.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbAnterior.Name = "pbAnterior";
            this.pbAnterior.Size = new System.Drawing.Size(45, 46);
            this.pbAnterior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnterior.TabIndex = 2;
            this.pbAnterior.TabStop = false;
            this.pbAnterior.Click += new System.EventHandler(this.pbAnterior_Click);
            // 
            // pbSiguiente
            // 
            this.pbSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.pbSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("pbSiguiente.Image")));
            this.pbSiguiente.Location = new System.Drawing.Point(931, 31);
            this.pbSiguiente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbSiguiente.Name = "pbSiguiente";
            this.pbSiguiente.Size = new System.Drawing.Size(45, 46);
            this.pbSiguiente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSiguiente.TabIndex = 3;
            this.pbSiguiente.TabStop = false;
            this.pbSiguiente.Click += new System.EventHandler(this.pbSiguiente_Click);
            // 
            // lblLunes
            // 
            this.lblLunes.AutoSize = true;
            this.lblLunes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunes.Location = new System.Drawing.Point(62, 129);
            this.lblLunes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLunes.Name = "lblLunes";
            this.lblLunes.Size = new System.Drawing.Size(99, 29);
            this.lblLunes.TabIndex = 4;
            this.lblLunes.Text = "LUNES ";
            this.lblLunes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMartes
            // 
            this.lblMartes.AutoSize = true;
            this.lblMartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMartes.Location = new System.Drawing.Point(192, 129);
            this.lblMartes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMartes.Name = "lblMartes";
            this.lblMartes.Size = new System.Drawing.Size(113, 29);
            this.lblMartes.TabIndex = 5;
            this.lblMartes.Text = "MARTES";
            this.lblMartes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMartes.Click += new System.EventHandler(this.lblMartes_Click);
            // 
            // lblViernes
            // 
            this.lblViernes.AutoSize = true;
            this.lblViernes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViernes.Location = new System.Drawing.Point(605, 129);
            this.lblViernes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblViernes.Name = "lblViernes";
            this.lblViernes.Size = new System.Drawing.Size(117, 29);
            this.lblViernes.TabIndex = 6;
            this.lblViernes.Text = "VIERNES";
            this.lblViernes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiercoles
            // 
            this.lblMiercoles.AutoSize = true;
            this.lblMiercoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiercoles.Location = new System.Drawing.Point(317, 129);
            this.lblMiercoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiercoles.Name = "lblMiercoles";
            this.lblMiercoles.Size = new System.Drawing.Size(153, 29);
            this.lblMiercoles.TabIndex = 6;
            this.lblMiercoles.Text = "MIERCOLES";
            this.lblMiercoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMiercoles.Click += new System.EventHandler(this.lblMiercoles_Click);
            // 
            // lblJueves
            // 
            this.lblJueves.AutoSize = true;
            this.lblJueves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJueves.Location = new System.Drawing.Point(470, 129);
            this.lblJueves.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJueves.Name = "lblJueves";
            this.lblJueves.Size = new System.Drawing.Size(105, 29);
            this.lblJueves.TabIndex = 7;
            this.lblJueves.Text = "JUEVES";
            this.lblJueves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJueves.Click += new System.EventHandler(this.lblJueves_Click);
            // 
            // lblSabado
            // 
            this.lblSabado.AutoSize = true;
            this.lblSabado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSabado.Location = new System.Drawing.Point(741, 129);
            this.lblSabado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSabado.Name = "lblSabado";
            this.lblSabado.Size = new System.Drawing.Size(111, 29);
            this.lblSabado.TabIndex = 6;
            this.lblSabado.Text = "SABADO";
            this.lblSabado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDomingo
            // 
            this.lblDomingo.AutoSize = true;
            this.lblDomingo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomingo.Location = new System.Drawing.Point(873, 129);
            this.lblDomingo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDomingo.Name = "lblDomingo";
            this.lblDomingo.Size = new System.Drawing.Size(130, 29);
            this.lblDomingo.TabIndex = 6;
            this.lblDomingo.Text = "DOMINGO";
            this.lblDomingo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flDays
            // 
            this.flDays.AutoScroll = true;
            this.flDays.Location = new System.Drawing.Point(32, 170);
            this.flDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flDays.Name = "flDays";
            this.flDays.Size = new System.Drawing.Size(960, 565);
            this.flDays.TabIndex = 1;
            this.flDays.Paint += new System.Windows.Forms.PaintEventHandler(this.flDays_Paint);
            // 
            // lblFechaDelEvento
            // 
            this.lblFechaDelEvento.AutoSize = true;
            this.lblFechaDelEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDelEvento.Location = new System.Drawing.Point(1014, 127);
            this.lblFechaDelEvento.Name = "lblFechaDelEvento";
            this.lblFechaDelEvento.Size = new System.Drawing.Size(480, 58);
            this.lblFechaDelEvento.TabIndex = 8;
            this.lblFechaDelEvento.Text = "20 de Mayo de 2025";
            this.lblFechaDelEvento.Click += new System.EventHandler(this.lblFechaDelEvento_Click);
            // 
            // btnGestionarEventosDia
            // 
            this.btnGestionarEventosDia.BackColor = System.Drawing.Color.Transparent;
            this.btnGestionarEventosDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarEventosDia.FlatAppearance.BorderSize = 0;
            this.btnGestionarEventosDia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGestionarEventosDia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGestionarEventosDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarEventosDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGestionarEventosDia.ForeColor = System.Drawing.Color.White;
            this.btnGestionarEventosDia.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionarEventosDia.Image")));
            this.btnGestionarEventosDia.Location = new System.Drawing.Point(1219, 693);
            this.btnGestionarEventosDia.Name = "btnGestionarEventosDia";
            this.btnGestionarEventosDia.Size = new System.Drawing.Size(47, 48);
            this.btnGestionarEventosDia.TabIndex = 10;
            this.btnGestionarEventosDia.UseVisualStyleBackColor = false;
            this.btnGestionarEventosDia.Click += new System.EventHandler(this.btnGestionarEventosDia_Click);
            // 
            // lstMostrarEventosInicio
            // 
            this.lstMostrarEventosInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.lstMostrarEventosInicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMostrarEventosInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMostrarEventosInicio.ForeColor = System.Drawing.Color.Transparent;
            this.lstMostrarEventosInicio.FormattingEnabled = true;
            this.lstMostrarEventosInicio.HorizontalScrollbar = true;
            this.lstMostrarEventosInicio.ItemHeight = 29;
            this.lstMostrarEventosInicio.Location = new System.Drawing.Point(1022, 190);
            this.lstMostrarEventosInicio.Name = "lstMostrarEventosInicio";
            this.lstMostrarEventosInicio.Size = new System.Drawing.Size(333, 493);
            this.lstMostrarEventosInicio.TabIndex = 11;
           // this.lstMostrarEventosInicio.Click += new System.EventHandler(this.lblDescripcionDelEvento_Click);
            this.lstMostrarEventosInicio.SelectedIndexChanged += new System.EventHandler(this.lstMostrarEventosInicio_SelectedIndexChanged);
            // 
            // btnAjustes
            // 
            this.btnAjustes.BackColor = System.Drawing.Color.Transparent;
            this.btnAjustes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAjustes.BackgroundImage")));
            this.btnAjustes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAjustes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjustes.FlatAppearance.BorderSize = 0;
            this.btnAjustes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAjustes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustes.ForeColor = System.Drawing.Color.White;
            this.btnAjustes.Location = new System.Drawing.Point(1386, 12);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(42, 45);
            this.btnAjustes.TabIndex = 12;
            this.btnAjustes.UseVisualStyleBackColor = false;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            // 
            // pnConfiguracion
            // 
            this.pnConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnConfiguracion.Controls.Add(this.lbl_id);
            this.pnConfiguracion.Controls.Add(this.lbl_idInformacion);
            this.pnConfiguracion.Controls.Add(this.lbl_usuarioInformacion);
            this.pnConfiguracion.Controls.Add(this.btnCerrarSesion);
            this.pnConfiguracion.Controls.Add(this.btnCambioDeColorFondo);
            this.pnConfiguracion.Controls.Add(this.lblUsuarioInicial);
            this.pnConfiguracion.Location = new System.Drawing.Point(1138, 12);
            this.pnConfiguracion.Name = "pnConfiguracion";
            this.pnConfiguracion.Size = new System.Drawing.Size(238, 231);
            this.pnConfiguracion.TabIndex = 13;
            this.pnConfiguracion.Visible = false;
            this.pnConfiguracion.Paint += new System.Windows.Forms.PaintEventHandler(this.pnConfiguracion_Paint);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(39, 45);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(153, 25);
            this.lbl_id.TabIndex = 5;
            this.lbl_id.Text = "Nombre Usuario";
            // 
            // lbl_idInformacion
            // 
            this.lbl_idInformacion.AutoSize = true;
            this.lbl_idInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idInformacion.Location = new System.Drawing.Point(3, 45);
            this.lbl_idInformacion.Name = "lbl_idInformacion";
            this.lbl_idInformacion.Size = new System.Drawing.Size(40, 25);
            this.lbl_idInformacion.TabIndex = 4;
            this.lbl_idInformacion.Text = "ID:";
            // 
            // lbl_usuarioInformacion
            // 
            this.lbl_usuarioInformacion.AutoSize = true;
            this.lbl_usuarioInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuarioInformacion.Location = new System.Drawing.Point(3, 12);
            this.lbl_usuarioInformacion.Name = "lbl_usuarioInformacion";
            this.lbl_usuarioInformacion.Size = new System.Drawing.Size(93, 25);
            this.lbl_usuarioInformacion.TabIndex = 3;
            this.lbl_usuarioInformacion.Text = "Usuario:";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(65, 139);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(112, 33);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnCambioDeColorFondo
            // 
            this.btnCambioDeColorFondo.BackColor = System.Drawing.Color.DimGray;
            this.btnCambioDeColorFondo.FlatAppearance.BorderSize = 0;
            this.btnCambioDeColorFondo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambioDeColorFondo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCambioDeColorFondo.Location = new System.Drawing.Point(65, 85);
            this.btnCambioDeColorFondo.Name = "btnCambioDeColorFondo";
            this.btnCambioDeColorFondo.Size = new System.Drawing.Size(112, 38);
            this.btnCambioDeColorFondo.TabIndex = 1;
            this.btnCambioDeColorFondo.Text = "Modo: Oscuro";
            this.btnCambioDeColorFondo.UseVisualStyleBackColor = false;
            this.btnCambioDeColorFondo.Click += new System.EventHandler(this.btnCambioDeColorFondo_Click);
            // 
            // lblUsuarioInicial
            // 
            this.lblUsuarioInicial.AutoSize = true;
            this.lblUsuarioInicial.Location = new System.Drawing.Point(77, 12);
            this.lblUsuarioInicial.Name = "lblUsuarioInicial";
            this.lblUsuarioInicial.Size = new System.Drawing.Size(153, 25);
            this.lblUsuarioInicial.TabIndex = 0;
            this.lblUsuarioInicial.Text = "Nombre Usuario";
            this.lblUsuarioInicial.Click += new System.EventHandler(this.lblUsuarioInicial_Click);
            // 
            // btnEditarEvento
            // 
            this.btnEditarEvento.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarEvento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarEvento.FlatAppearance.BorderSize = 0;
            this.btnEditarEvento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditarEvento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditarEvento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEditarEvento.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarEvento.Image")));
            this.btnEditarEvento.Location = new System.Drawing.Point(1262, 689);
            this.btnEditarEvento.Name = "btnEditarEvento";
            this.btnEditarEvento.Size = new System.Drawing.Size(44, 56);
            this.btnEditarEvento.TabIndex = 14;
            this.btnEditarEvento.UseVisualStyleBackColor = false;
            this.btnEditarEvento.Click += new System.EventHandler(this.btnEditarEvento_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(1312, 696);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(43, 41);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1504, 749);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditarEvento);
            this.Controls.Add(this.pnConfiguracion);
            this.Controls.Add(this.btnAjustes);
            this.Controls.Add(this.lstMostrarEventosInicio);
            this.Controls.Add(this.btnGestionarEventosDia);
            this.Controls.Add(this.lblFechaDelEvento);
            this.Controls.Add(this.lblJueves);
            this.Controls.Add(this.lblMiercoles);
            this.Controls.Add(this.lblDomingo);
            this.Controls.Add(this.lblSabado);
            this.Controls.Add(this.lblViernes);
            this.Controls.Add(this.lblMartes);
            this.Controls.Add(this.lblLunes);
            this.Controls.Add(this.pbSiguiente);
            this.Controls.Add(this.pbAnterior);
            this.Controls.Add(this.flDays);
            this.Controls.Add(this.lblFecha);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.Text = "Calendario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inicio_FormClosed);
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSiguiente)).EndInit();
            this.pnConfiguracion.ResumeLayout(false);
            this.pnConfiguracion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pbAnterior;
        private System.Windows.Forms.PictureBox pbSiguiente;
        private System.Windows.Forms.Label lblLunes;
        private System.Windows.Forms.Label lblMartes;
        private System.Windows.Forms.Label lblViernes;
        private System.Windows.Forms.Label lblMiercoles;
        private System.Windows.Forms.Label lblJueves;
        private System.Windows.Forms.Label lblSabado;
        private System.Windows.Forms.Label lblDomingo;
        private System.Windows.Forms.FlowLayoutPanel flDays;
        private System.Windows.Forms.Label lblFechaDelEvento;
        private System.Windows.Forms.Button btnGestionarEventosDia;
        private System.Windows.Forms.ListBox lstMostrarEventosInicio;
        private System.Windows.Forms.Button btnAjustes;
        private System.Windows.Forms.Panel pnConfiguracion;
        private System.Windows.Forms.Label lblUsuarioInicial;
        private System.Windows.Forms.Button btnCambioDeColorFondo;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnEditarEvento;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lbl_usuarioInformacion;
        private System.Windows.Forms.Label lbl_idInformacion;
        private System.Windows.Forms.Label lbl_id;
    }
}