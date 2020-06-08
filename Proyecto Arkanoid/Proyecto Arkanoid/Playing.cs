using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Playing : Form
    {
        public Playing()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
    }
}