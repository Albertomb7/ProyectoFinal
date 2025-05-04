namespace ProyectoFinal
{
    partial class login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.lbl_inicio = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contrasenia = new System.Windows.Forms.TextBox();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_contrasenia = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ver_contraseña = new System.Windows.Forms.Button();
            this.linklbl_registrarse = new System.Windows.Forms.LinkLabel();
            this.lbl_pregunta = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_iniciar_sesion = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_inicio
            // 
            this.lbl_inicio.AutoSize = true;
            this.lbl_inicio.BackColor = System.Drawing.Color.Transparent;
            this.lbl_inicio.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_inicio.ForeColor = System.Drawing.Color.White;
            this.lbl_inicio.Location = new System.Drawing.Point(78, 75);
            this.lbl_inicio.Name = "lbl_inicio";
            this.lbl_inicio.Size = new System.Drawing.Size(183, 24);
            this.lbl_inicio.TabIndex = 0;
            this.lbl_inicio.Text = "INICIAR SESION";
            this.lbl_inicio.Click += new System.EventHandler(this.lbl_inicio_Click);
            // 
            // txt_usuario
            // 
            this.txt_usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usuario.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_usuario.ForeColor = System.Drawing.Color.White;
            this.txt_usuario.Location = new System.Drawing.Point(38, 165);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(250, 26);
            this.txt_usuario.TabIndex = 1;
            this.txt_usuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_contrasenia
            // 
            this.txt_contrasenia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.txt_contrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contrasenia.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txt_contrasenia.ForeColor = System.Drawing.Color.White;
            this.txt_contrasenia.Location = new System.Drawing.Point(38, 234);
            this.txt_contrasenia.Name = "txt_contrasenia";
            this.txt_contrasenia.Size = new System.Drawing.Size(223, 26);
            this.txt_contrasenia.TabIndex = 2;
            this.txt_contrasenia.UseSystemPasswordChar = true;
            this.txt_contrasenia.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lbl_usuario.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuario.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_usuario.Location = new System.Drawing.Point(34, 137);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(65, 19);
            this.lbl_usuario.TabIndex = 3;
            this.lbl_usuario.Text = "Usuario";
            this.lbl_usuario.Click += new System.EventHandler(this.lbl_user_Click);
            // 
            // lbl_contrasenia
            // 
            this.lbl_contrasenia.AutoSize = true;
            this.lbl_contrasenia.BackColor = System.Drawing.Color.Transparent;
            this.lbl_contrasenia.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_contrasenia.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_contrasenia.Location = new System.Drawing.Point(34, 207);
            this.lbl_contrasenia.Name = "lbl_contrasenia";
            this.lbl_contrasenia.Size = new System.Drawing.Size(95, 19);
            this.lbl_contrasenia.TabIndex = 4;
            this.lbl_contrasenia.Text = "Contraseña";
            this.lbl_contrasenia.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.btn_ver_contraseña);
            this.panel2.Controls.Add(this.linklbl_registrarse);
            this.panel2.Controls.Add(this.lbl_pregunta);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_iniciar_sesion);
            this.panel2.Controls.Add(this.lbl_inicio);
            this.panel2.Controls.Add(this.txt_contrasenia);
            this.panel2.Controls.Add(this.lbl_contrasenia);
            this.panel2.Controls.Add(this.txt_usuario);
            this.panel2.Controls.Add(this.lbl_usuario);
            this.panel2.Location = new System.Drawing.Point(161, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 388);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btn_ver_contraseña
            // 
            this.btn_ver_contraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.btn_ver_contraseña.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_ver_contraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ver_contraseña.ForeColor = System.Drawing.Color.White;
            this.btn_ver_contraseña.Image = ((System.Drawing.Image)(resources.GetObject("btn_ver_contraseña.Image")));
            this.btn_ver_contraseña.Location = new System.Drawing.Point(258, 234);
            this.btn_ver_contraseña.Name = "btn_ver_contraseña";
            this.btn_ver_contraseña.Size = new System.Drawing.Size(30, 26);
            this.btn_ver_contraseña.TabIndex = 11;
            this.btn_ver_contraseña.UseVisualStyleBackColor = false;
            this.btn_ver_contraseña.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // linklbl_registrarse
            // 
            this.linklbl_registrarse.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.linklbl_registrarse.AutoSize = true;
            this.linklbl_registrarse.BackColor = System.Drawing.Color.Transparent;
            this.linklbl_registrarse.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbl_registrarse.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklbl_registrarse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(134)))), ((int)(((byte)(227)))));
            this.linklbl_registrarse.Location = new System.Drawing.Point(195, 342);
            this.linklbl_registrarse.Name = "linklbl_registrarse";
            this.linklbl_registrarse.Size = new System.Drawing.Size(108, 15);
            this.linklbl_registrarse.TabIndex = 10;
            this.linklbl_registrarse.TabStop = true;
            this.linklbl_registrarse.Text = "Registrate aquí";
            this.linklbl_registrarse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbl_pregunta
            // 
            this.lbl_pregunta.AutoSize = true;
            this.lbl_pregunta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pregunta.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.lbl_pregunta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_pregunta.Location = new System.Drawing.Point(22, 344);
            this.lbl_pregunta.Name = "lbl_pregunta";
            this.lbl_pregunta.Size = new System.Drawing.Size(182, 13);
            this.lbl_pregunta.TabIndex = 9;
            this.lbl_pregunta.Text = "¿Aun no estas registrado? ";
            this.lbl_pregunta.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(25, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 1);
            this.panel4.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(121, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_iniciar_sesion
            // 
            this.btn_iniciar_sesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(134)))), ((int)(((byte)(227)))));
            this.btn_iniciar_sesion.FlatAppearance.BorderSize = 0;
            this.btn_iniciar_sesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_iniciar_sesion.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_iniciar_sesion.ForeColor = System.Drawing.Color.White;
            this.btn_iniciar_sesion.Location = new System.Drawing.Point(38, 288);
            this.btn_iniciar_sesion.Name = "btn_iniciar_sesion";
            this.btn_iniciar_sesion.Size = new System.Drawing.Size(250, 26);
            this.btn_iniciar_sesion.TabIndex = 7;
            this.btn_iniciar_sesion.Text = "Iniciar sesión ";
            this.btn_iniciar_sesion.UseVisualStyleBackColor = false;
            this.btn_iniciar_sesion.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(657, 429);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_inicio;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contrasenia;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label lbl_contrasenia;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_iniciar_sesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_pregunta;
        private System.Windows.Forms.LinkLabel linklbl_registrarse;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btn_ver_contraseña;
    }
}

