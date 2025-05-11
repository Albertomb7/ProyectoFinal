using System.Windows.Forms;

namespace ProyectoFinal
{
    partial class CalendarioForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMesActual;
        private System.Windows.Forms.TableLayoutPanel tableCalendario;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel leftLayout;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMesActual = new System.Windows.Forms.Label();
            this.tableCalendario = new System.Windows.Forms.TableLayoutPanel();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.leftLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainLayout.SuspendLayout();
            this.leftLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMesActual
            // 
            this.lblMesActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMesActual.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMesActual.Location = new System.Drawing.Point(3, 0);
            this.lblMesActual.Name = "lblMesActual";
            this.lblMesActual.Size = new System.Drawing.Size(744, 40);
            this.lblMesActual.TabIndex = 0;
            this.lblMesActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableCalendario
            // 
            this.tableCalendario.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableCalendario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCalendario.Location = new System.Drawing.Point(3, 43);
            this.tableCalendario.Name = "tableCalendario";
            this.tableCalendario.Size = new System.Drawing.Size(744, 513);
            this.tableCalendario.TabIndex = 1;
            // 
            // txtNota
            // 
            this.txtNota.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNota.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNota.Location = new System.Drawing.Point(759, 3);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(319, 599);
            this.txtNota.TabIndex = 1;
            this.txtNota.TextChanged += new System.EventHandler(this.txtNota_TextChanged);
            // 
            // btnAnterior
            // 
            this.btnAnterior.AutoSize = true;
            this.btnAnterior.Location = new System.Drawing.Point(577, 3);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 26);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "« Anterior";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.AutoSize = true;
            this.btnSiguiente.Location = new System.Drawing.Point(658, 3);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(83, 26);
            this.btnSiguiente.TabIndex = 0;
            this.btnSiguiente.Text = "Siguiente »";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainLayout.Controls.Add(this.leftLayout, 0, 0);
            this.mainLayout.Controls.Add(this.txtNota, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1081, 605);
            this.mainLayout.TabIndex = 0;
            // 
            // leftLayout
            // 
            this.leftLayout.ColumnCount = 1;
            this.leftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftLayout.Controls.Add(this.lblMesActual, 0, 0);
            this.leftLayout.Controls.Add(this.tableCalendario, 0, 1);
            this.leftLayout.Controls.Add(this.buttonPanel, 0, 2);
            this.leftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftLayout.Location = new System.Drawing.Point(3, 3);
            this.leftLayout.Name = "leftLayout";
            this.leftLayout.RowCount = 3;
            this.leftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.leftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.leftLayout.Size = new System.Drawing.Size(750, 599);
            this.leftLayout.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.btnSiguiente);
            this.buttonPanel.Controls.Add(this.btnAnterior);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonPanel.Location = new System.Drawing.Point(3, 562);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(744, 34);
            this.buttonPanel.TabIndex = 2;
            // 
            // CalendarioForm
            // 
            this.ClientSize = new System.Drawing.Size(1081, 605);
            this.Controls.Add(this.mainLayout);
            this.Name = "CalendarioForm";
            this.Text = "Calendario";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.leftLayout.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
