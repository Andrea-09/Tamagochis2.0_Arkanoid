using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void game_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Left = e.X;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            pictureBox1.Top = (Height - pictureBox1.Height) - 90;
        }
    }
}