using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProyectoFinal
{
    public partial class UC_DIAS : UserControl
    {
        string _day;
        private System.Windows.Forms.CheckBox checkBox1; // Changed type from object to CheckBox  
        private object label1;

        private void panel1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                this.BackColor = Color.FromArgb(255, 150, 79);
            }
            else
            {
                checkBox1.Checked = false;
                this.BackColor = Color.LightBlue; // Restauramos color de prueba  
            }
        }

        public UC_DIAS(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = _day;
            checkBox1 = new CheckBox(); // Initialize checkBox1  
            checkBox1.Hide();

            // 🧪 PRUEBA VISUAL  
            this.Size = new Size(60, 60);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.LightBlue;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}