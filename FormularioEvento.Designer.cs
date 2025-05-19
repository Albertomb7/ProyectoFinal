namespace ProyectoFinal.Calendario
{
    partial class FormularioEvento
    {
        private System.ComponentModel.IContainer components = null;

        // Declaraciones de los controles (DEBEN ESTAR AQUÍ)
        private System.Windows.Forms.Label lblFechaSeleccionada;
        private System.Windows.Forms.TextBox txtDescripcionEvento;
        private System.Windows.Forms.CheckBox chkUsarHora;
        private System.Windows.Forms.DateTimePicker dtpHoraEvento;
        private System.Windows.Forms.ListBox lstEventosDelDia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1; // Para "Eventos del día:"
        private System.Windows.Forms.Label label2; // Para "Descripción:"

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.lblFechaSeleccionada = new System.Windows.Forms.Label();
            this.txtDescripcionEvento = new System.Windows.Forms.TextBox();
            this.chkUsarHora = new System.Windows.Forms.CheckBox();
            this.dtpHoraEvento = new System.Windows.Forms.DateTimePicker();
            this.lstEventosDelDia = new System.Windows.Forms.ListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeleccionarColor = new System.Windows.Forms.Button();
            this.PanelColor = new System.Windows.Forms.Panel();
            this.btn_actuzalizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFechaSeleccionada
            // 
            this.lblFechaSeleccionada.AutoSize = true;
            this.lblFechaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSeleccionada.ForeColor = System.Drawing.Color.White;
            this.lblFechaSeleccionada.Location = new System.Drawing.Point(12, 9);
            this.lblFechaSeleccionada.Name = "lblFechaSeleccionada";
            this.lblFechaSeleccionada.Size = new System.Drawing.Size(117, 20);
            this.lblFechaSeleccionada.TabIndex = 0;
            this.lblFechaSeleccionada.Text = "Fecha del día";
            // 
            // txtDescripcionEvento
            // 
            this.txtDescripcionEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.txtDescripcionEvento.CausesValidation = false;
            this.txtDescripcionEvento.ForeColor = System.Drawing.Color.White;
            this.txtDescripcionEvento.Location = new System.Drawing.Point(16, 210);
            this.txtDescripcionEvento.Multiline = true;
            this.txtDescripcionEvento.Name = "txtDescripcionEvento";
            this.txtDescripcionEvento.Size = new System.Drawing.Size(356, 60);
            this.txtDescripcionEvento.TabIndex = 4;
            this.txtDescripcionEvento.TextChanged += new System.EventHandler(this.txtDescripcionEvento_TextChanged);
            // 
            // chkUsarHora
            // 
            this.chkUsarHora.AutoSize = true;
            this.chkUsarHora.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkUsarHora.Location = new System.Drawing.Point(16, 280);
            this.chkUsarHora.Name = "chkUsarHora";
            this.chkUsarHora.Size = new System.Drawing.Size(101, 21);
            this.chkUsarHora.TabIndex = 5;
            this.chkUsarHora.Text = "Añadir hora";
            this.chkUsarHora.UseVisualStyleBackColor = true;
            this.chkUsarHora.CheckedChanged += new System.EventHandler(this.chkUsarHora_CheckedChanged);
            // 
            // dtpHoraEvento
            // 
            this.dtpHoraEvento.CalendarForeColor = System.Drawing.Color.White;
            this.dtpHoraEvento.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.dtpHoraEvento.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpHoraEvento.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpHoraEvento.Enabled = false;
            this.dtpHoraEvento.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEvento.Location = new System.Drawing.Point(115, 278);
            this.dtpHoraEvento.Name = "dtpHoraEvento";
            this.dtpHoraEvento.ShowUpDown = true;
            this.dtpHoraEvento.Size = new System.Drawing.Size(100, 23);
            this.dtpHoraEvento.TabIndex = 6;
            this.dtpHoraEvento.ValueChanged += new System.EventHandler(this.dtpHoraEvento_ValueChanged);
            // 
            // lstEventosDelDia
            // 
            this.lstEventosDelDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lstEventosDelDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstEventosDelDia.ForeColor = System.Drawing.Color.White;
            this.lstEventosDelDia.FormattingEnabled = true;
            this.lstEventosDelDia.ItemHeight = 16;
            this.lstEventosDelDia.Location = new System.Drawing.Point(16, 60);
            this.lstEventosDelDia.Name = "lstEventosDelDia";
            this.lstEventosDelDia.Size = new System.Drawing.Size(356, 100);
            this.lstEventosDelDia.TabIndex = 2;
            this.lstEventosDelDia.SelectedIndexChanged += new System.EventHandler(this.lstEventosDelDia_SelectedIndexChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(16, 320);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Nuevo";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(142, 320);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(272, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eventos del día:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(13, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción:";
            // 
            // btnSeleccionarColor
            // 
            this.btnSeleccionarColor.ForeColor = System.Drawing.Color.Black;
            this.btnSeleccionarColor.Location = new System.Drawing.Point(242, 280);
            this.btnSeleccionarColor.Name = "btnSeleccionarColor";
            this.btnSeleccionarColor.Size = new System.Drawing.Size(75, 24);
            this.btnSeleccionarColor.TabIndex = 10;
            this.btnSeleccionarColor.Text = "Color";
            this.btnSeleccionarColor.UseVisualStyleBackColor = true;
            this.btnSeleccionarColor.Click += new System.EventHandler(this.btnSeleccionarColor_Click);
            // 
            // PanelColor
            // 
            this.PanelColor.Location = new System.Drawing.Point(332, 280);
            this.PanelColor.Name = "PanelColor";
            this.PanelColor.Size = new System.Drawing.Size(28, 24);
            this.PanelColor.TabIndex = 11;
            // 
            // btn_actuzalizar
            // 
            this.btn_actuzalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_actuzalizar.FlatAppearance.BorderSize = 0;
            this.btn_actuzalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actuzalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actuzalizar.ForeColor = System.Drawing.Color.White;
            this.btn_actuzalizar.Location = new System.Drawing.Point(16, 319);
            this.btn_actuzalizar.Name = "btn_actuzalizar";
            this.btn_actuzalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_actuzalizar.Size = new System.Drawing.Size(120, 30);
            this.btn_actuzalizar.TabIndex = 12;
            this.btn_actuzalizar.Text = "Actualizar";
            this.btn_actuzalizar.UseVisualStyleBackColor = false;
            this.btn_actuzalizar.Visible = false;
            this.btn_actuzalizar.Click += new System.EventHandler(this.btn_actuzalizar_Click);
            // 
            // FormularioEvento
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btn_actuzalizar);
            this.Controls.Add(this.PanelColor);
            this.Controls.Add(this.btnSeleccionarColor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpHoraEvento);
            this.Controls.Add(this.chkUsarHora);
            this.Controls.Add(this.txtDescripcionEvento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstEventosDelDia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFechaSeleccionada);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionar Evento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnSeleccionarColor;
        private System.Windows.Forms.Panel PanelColor;
        private System.Windows.Forms.Button btn_actuzalizar;
    }
}