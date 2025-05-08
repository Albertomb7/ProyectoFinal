namespace ProyectoFinal
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.FlowLayoutPanel fLDias;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.btnNext = new System.Windows.Forms.Button();
            this.fLDias = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnNext.Location = new System.Drawing.Point(500, 20);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // 
            // fLDias
            // 
            this.fLDias.Location = new System.Drawing.Point(30, 80);
            this.fLDias.Name = "fLDias";
            this.fLDias.Size = new System.Drawing.Size(600, 500);
            this.fLDias.TabIndex = 1;

            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.fLDias);
            this.Controls.Add(this.btnNext);
            this.Name = "Inicio";
            this.Text = "Calendario";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
