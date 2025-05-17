namespace ProyectoFinal.Calendario
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSiguiente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(64, 14);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 42);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbAnterior
            // 
            this.pbAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("pbAnterior.Image")));
            this.pbAnterior.Location = new System.Drawing.Point(921, 31);
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
            this.pbSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("pbSiguiente.Image")));
            this.pbSiguiente.Location = new System.Drawing.Point(975, 31);
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
            this.lblLunes.Location = new System.Drawing.Point(106, 129);
            this.lblLunes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLunes.Name = "lblLunes";
            this.lblLunes.Size = new System.Drawing.Size(77, 24);
            this.lblLunes.TabIndex = 4;
            this.lblLunes.Text = "LUNES ";
            this.lblLunes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMartes
            // 
            this.lblMartes.AutoSize = true;
            this.lblMartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMartes.Location = new System.Drawing.Point(236, 129);
            this.lblMartes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMartes.Name = "lblMartes";
            this.lblMartes.Size = new System.Drawing.Size(89, 24);
            this.lblMartes.TabIndex = 5;
            this.lblMartes.Text = "MARTES";
            this.lblMartes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMartes.Click += new System.EventHandler(this.lblMartes_Click);
            // 
            // lblViernes
            // 
            this.lblViernes.AutoSize = true;
            this.lblViernes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViernes.Location = new System.Drawing.Point(649, 129);
            this.lblViernes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblViernes.Name = "lblViernes";
            this.lblViernes.Size = new System.Drawing.Size(92, 24);
            this.lblViernes.TabIndex = 6;
            this.lblViernes.Text = "VIERNES";
            this.lblViernes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiercoles
            // 
            this.lblMiercoles.AutoSize = true;
            this.lblMiercoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiercoles.Location = new System.Drawing.Point(361, 129);
            this.lblMiercoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiercoles.Name = "lblMiercoles";
            this.lblMiercoles.Size = new System.Drawing.Size(119, 24);
            this.lblMiercoles.TabIndex = 6;
            this.lblMiercoles.Text = "MIERCOLES";
            this.lblMiercoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMiercoles.Click += new System.EventHandler(this.lblMiercoles_Click);
            // 
            // lblJueves
            // 
            this.lblJueves.AutoSize = true;
            this.lblJueves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJueves.Location = new System.Drawing.Point(514, 129);
            this.lblJueves.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJueves.Name = "lblJueves";
            this.lblJueves.Size = new System.Drawing.Size(83, 24);
            this.lblJueves.TabIndex = 7;
            this.lblJueves.Text = "JUEVES";
            this.lblJueves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJueves.Click += new System.EventHandler(this.lblJueves_Click);
            // 
            // lblSabado
            // 
            this.lblSabado.AutoSize = true;
            this.lblSabado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSabado.Location = new System.Drawing.Point(785, 129);
            this.lblSabado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSabado.Name = "lblSabado";
            this.lblSabado.Size = new System.Drawing.Size(88, 24);
            this.lblSabado.TabIndex = 6;
            this.lblSabado.Text = "SABADO";
            this.lblSabado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDomingo
            // 
            this.lblDomingo.AutoSize = true;
            this.lblDomingo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomingo.Location = new System.Drawing.Point(917, 129);
            this.lblDomingo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDomingo.Name = "lblDomingo";
            this.lblDomingo.Size = new System.Drawing.Size(101, 24);
            this.lblDomingo.TabIndex = 6;
            this.lblDomingo.Text = "DOMINGO";
            this.lblDomingo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flDays
            // 
            this.flDays.AutoScroll = true;
            this.flDays.Location = new System.Drawing.Point(76, 170);
            this.flDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flDays.Name = "flDays";
            this.flDays.Size = new System.Drawing.Size(960, 565);
            this.flDays.TabIndex = 1;
            this.flDays.Paint += new System.Windows.Forms.PaintEventHandler(this.flDays_Paint);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1370, 749);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Inicio";
            this.Text = "Calendario";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSiguiente)).EndInit();
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
    }
}