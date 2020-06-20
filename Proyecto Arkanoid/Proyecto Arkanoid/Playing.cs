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

            //Oculta el user 
            game1.finishGame = () =>
            {
                Dispose();
            };

            game1.winningGame = () =>
            {
                PlayerController.CreateNewScore();
                Dispose();
            };
        }
    }
}