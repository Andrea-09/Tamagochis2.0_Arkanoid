using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void game_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Left = e.X;
        }
    }
}