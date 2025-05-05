namespace ProyectoFinal
{
    partial class registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_informacion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_registro = new System.Windows.Forms.Label();
            this.btn_registrarse = new System.Windows.Forms.Button();
            this.txt_telefono_registro = new System.Windows.Forms.TextBox();
            this.lbl_telefono_registro = new System.Windows.Forms.Label();
            this.txt_contraseña_registro = new System.Windows.Forms.TextBox();
            this.lbl_contrasenia_registro = new System.Windows.Forms.Label();
            this.txt_usuario_registro = new System.Windows.Forms.TextBox();
            this.lbl_usuario_registro = new System.Windows.Forms.Label();
            this.txt_nombre_registro = new System.Windows.Forms.TextBox();
            this.lbl_nombre_registro = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_ver_contraseña_registro = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.btn_ver_contraseña_registro);
            this.panel1.Controls.Add(this.lbl_informacion);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lbl_registro);
            this.panel1.Controls.Add(this.btn_registrarse);
            this.panel1.Controls.Add(this.txt_telefono_registro);
            this.panel1.Controls.Add(this.lbl_telefono_registro);
            this.panel1.Controls.Add(this.txt_contraseña_registro);
            this.panel1.Controls.Add(this.lbl_contrasenia_registro);
            this.panel1.Controls.Add(this.txt_usuario_registro);
            this.panel1.Controls.Add(this.lbl_usuario_registro);
            this.panel1.Controls.Add(this.txt_nombre_registro);
            this.panel1.Controls.Add(this.lbl_nombre_registro);
            this.panel1.Location = new System.Drawing.Point(345, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 453);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // lbl_informacion
            // 
            this.lbl_informacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_informacion.AutoSize = true;
            this.lbl_informacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_informacion.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.lbl_informacion.ForeColor = System.Drawing.Color.Red;
            this.lbl_informacion.Location = new System.Drawing.Point(140, 351);
            this.lbl_informacion.Name = "lbl_informacion";
            this.lbl_informacion.Size = new System.Drawing.Size(91, 18);
            this.lbl_informacion.TabIndex = 11;
            this.lbl_informacion.Text = "Informacion";
            this.lbl_informacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_informacion.Visible = false;
            this.lbl_informacion.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(49, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 1);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lbl_registro
            // 
            this.lbl_registro.AutoSize = true;
            this.lbl_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_registro.ForeColor = System.Drawing.Color.White;
            this.lbl_registro.Location = new System.Drawing.Point(109, 36);
            this.lbl_registro.Name = "lbl_registro";
            this.lbl_registro.Size = new System.Drawing.Size(158, 24);
            this.lbl_registro.TabIndex = 9;
            this.lbl_registro.Text = "REGISTRARSE";
            this.lbl_registro.Click += new System.EventHandler(this.lbl_registro_Click);
            // 
            // btn_registrarse
            // 
            this.btn_registrarse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(134)))), ((int)(((byte)(227)))));
            this.btn_registrarse.FlatAppearance.BorderSize = 0;
            this.btn_registrarse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_registrarse.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_registrarse.ForeColor = System.Drawing.Color.White;
            this.btn_registrarse.Location = new System.Drawing.Point(64, 380);
            this.btn_registrarse.Name = "btn_registrarse";
            this.btn_registrarse.Size = new System.Drawing.Size(250, 26);
            this.btn_registrarse.TabIndex = 8;
            this.btn_registrarse.Text = "Registrarse";
            this.btn_registrarse.UseVisualStyleBackColor = false;
            this.btn_registrarse.Click += new System.EventHandler(this.btn_registrarse_Click);
            // 
            // txt_telefono_registro
            // 
            this.txt_telefono_registro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.txt_telefono_registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_telefono_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txt_telefono_registro.ForeColor = System.Drawing.Color.White;
            this.txt_telefono_registro.Location = new System.Drawing.Point(64, 314);
            this.txt_telefono_registro.Name = "txt_telefono_registro";
            this.txt_telefono_registro.Size = new System.Drawing.Size(250, 26);
            this.txt_telefono_registro.TabIndex = 7;
            this.txt_telefono_registro.TextChanged += new System.EventHandler(this.txt_telefono_registro_TextChanged);
            // 
            // lbl_telefono_registro
            // 
            this.lbl_telefono_registro.AutoSize = true;
            this.lbl_telefono_registro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_telefono_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.lbl_telefono_registro.ForeColor = System.Drawing.Color.White;
            this.lbl_telefono_registro.Location = new System.Drawing.Point(60, 292);
            this.lbl_telefono_registro.Name = "lbl_telefono_registro";
            this.lbl_telefono_registro.Size = new System.Drawing.Size(73, 19);
            this.lbl_telefono_registro.TabIndex = 6;
            this.lbl_telefono_registro.Text = "Telefono";
            this.lbl_telefono_registro.Click += new System.EventHandler(this.lbl_telefono_registro_Click);
            // 
            // txt_contraseña_registro
            // 
            this.txt_contraseña_registro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.txt_contraseña_registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contraseña_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txt_contraseña_registro.ForeColor = System.Drawing.Color.White;
            this.txt_contraseña_registro.Location = new System.Drawing.Point(64, 249);
            this.txt_contraseña_registro.Name = "txt_contraseña_registro";
            this.txt_contraseña_registro.Size = new System.Drawing.Size(224, 26);
            this.txt_contraseña_registro.TabIndex = 5;
            this.txt_contraseña_registro.UseSystemPasswordChar = true;
            this.txt_contraseña_registro.TextChanged += new System.EventHandler(this.txt_contrasenia_registro_TextChanged);
            // 
            // lbl_contrasenia_registro
            // 
            this.lbl_contrasenia_registro.AutoSize = true;
            this.lbl_contrasenia_registro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_contrasenia_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.lbl_contrasenia_registro.ForeColor = System.Drawing.Color.White;
            this.lbl_contrasenia_registro.Location = new System.Drawing.Point(60, 224);
            this.lbl_contrasenia_registro.Name = "lbl_contrasenia_registro";
            this.lbl_contrasenia_registro.Size = new System.Drawing.Size(95, 19);
            this.lbl_contrasenia_registro.TabIndex = 4;
            this.lbl_contrasenia_registro.Text = "Contraseña";
            this.lbl_contrasenia_registro.Click += new System.EventHandler(this.lbl_contrasenia_registro_Click);
            // 
            // txt_usuario_registro
            // 
            this.txt_usuario_registro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.txt_usuario_registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usuario_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txt_usuario_registro.ForeColor = System.Drawing.Color.White;
            this.txt_usuario_registro.Location = new System.Drawing.Point(64, 188);
            this.txt_usuario_registro.Name = "txt_usuario_registro";
            this.txt_usuario_registro.Size = new System.Drawing.Size(250, 26);
            this.txt_usuario_registro.TabIndex = 3;
            this.txt_usuario_registro.TextChanged += new System.EventHandler(this.txt_usuario_registro_TextChanged);
            // 
            // lbl_usuario_registro
            // 
            this.lbl_usuario_registro.AutoSize = true;
            this.lbl_usuario_registro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_usuario_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.lbl_usuario_registro.ForeColor = System.Drawing.Color.White;
            this.lbl_usuario_registro.Location = new System.Drawing.Point(60, 163);
            this.lbl_usuario_registro.Name = "lbl_usuario_registro";
            this.lbl_usuario_registro.Size = new System.Drawing.Size(65, 19);
            this.lbl_usuario_registro.TabIndex = 2;
            this.lbl_usuario_registro.Text = "Usuario";
            this.lbl_usuario_registro.Click += new System.EventHandler(this.lbl_usuario_registro_Click);
            // 
            // txt_nombre_registro
            // 
            this.txt_nombre_registro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.txt_nombre_registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txt_nombre_registro.ForeColor = System.Drawing.Color.White;
            this.txt_nombre_registro.Location = new System.Drawing.Point(64, 128);
            this.txt_nombre_registro.Name = "txt_nombre_registro";
            this.txt_nombre_registro.Size = new System.Drawing.Size(250, 26);
            this.txt_nombre_registro.TabIndex = 1;
            this.txt_nombre_registro.TextChanged += new System.EventHandler(this.txt_nombre_registro_TextChanged);
            // 
            // lbl_nombre_registro
            // 
            this.lbl_nombre_registro.AutoSize = true;
            this.lbl_nombre_registro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nombre_registro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.lbl_nombre_registro.ForeColor = System.Drawing.Color.White;
            this.lbl_nombre_registro.Location = new System.Drawing.Point(60, 101);
            this.lbl_nombre_registro.Name = "lbl_nombre_registro";
            this.lbl_nombre_registro.Size = new System.Drawing.Size(143, 19);
            this.lbl_nombre_registro.TabIndex = 0;
            this.lbl_nombre_registro.Text = "Nombre y apellido";
            this.lbl_nombre_registro.Click += new System.EventHandler(this.lbl_nombre_registro_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_ver_contraseña_registro
            // 
            this.btn_ver_contraseña_registro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btn_ver_contraseña_registro.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_ver_contraseña_registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ver_contraseña_registro.ForeColor = System.Drawing.Color.White;
            this.btn_ver_contraseña_registro.Image = ((System.Drawing.Image)(resources.GetObject("btn_ver_contraseña_registro.Image")));
            this.btn_ver_contraseña_registro.Location = new System.Drawing.Point(284, 249);
            this.btn_ver_contraseña_registro.Name = "btn_ver_contraseña_registro";
            this.btn_ver_contraseña_registro.Size = new System.Drawing.Size(30, 26);
            this.btn_ver_contraseña_registro.TabIndex = 12;
            this.btn_ver_contraseña_registro.UseVisualStyleBackColor = false;
            this.btn_ver_contraseña_registro.Click += new System.EventHandler(this.btn_ver_contraseña_Click);
            // 
            // registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(728, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_nombre_registro;
        private System.Windows.Forms.TextBox txt_nombre_registro;
        private System.Windows.Forms.TextBox txt_usuario_registro;
        private System.Windows.Forms.Label lbl_usuario_registro;
        private System.Windows.Forms.TextBox txt_contraseña_registro;
        private System.Windows.Forms.Label lbl_contrasenia_registro;
        private System.Windows.Forms.TextBox txt_telefono_registro;
        private System.Windows.Forms.Label lbl_telefono_registro;
        private System.Windows.Forms.Button btn_registrarse;
        private System.Windows.Forms.Label lbl_registro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_informacion;
        private System.Windows.Forms.Button btn_ver_contraseña_registro;
    }
}