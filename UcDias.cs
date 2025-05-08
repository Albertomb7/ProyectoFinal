using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class UcDias : UserControl
    {
        public UcDias()
        {
            InitializeComponent();
        }

        public string Dia
        {
            get => lblDia.Text;
            set => lblDia.Text = value;
        }
    }
}
