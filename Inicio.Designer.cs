namespace ProyectoFinal
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.MensajeBienveneida = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(7, 139);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.RightToLeftLayout = true;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // MensajeBienveneida
            // 
            this.MensajeBienveneida.AutoSize = true;
            this.MensajeBienveneida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MensajeBienveneida.Location = new System.Drawing.Point(157, 18);
            this.MensajeBienveneida.Name = "MensajeBienveneida";
            this.MensajeBienveneida.Size = new System.Drawing.Size(210, 13);
            this.MensajeBienveneida.TabIndex = 1;
            this.MensajeBienveneida.Text = "BIENVENIDO A TU AGENDA PERSONAL";
            this.MensajeBienveneida.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 563);
            this.Controls.Add(this.MensajeBienveneida);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label MensajeBienveneida;
    }
}