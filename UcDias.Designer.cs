using System.Windows.Forms;
using System.Drawing;

namespace ProyectoFinal
{
    partial class UcDias
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDia;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDia
            // 
            this.lblDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDia.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDia.Location = new System.Drawing.Point(0, 0);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(100, 80);
            this.lblDia.TabIndex = 0;
            this.lblDia.Text = "1";
            this.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDia);
            this.Name = "UcDias";
            this.Size = new System.Drawing.Size(100, 80);
            this.ResumeLayout(false);
        }
    }
}
