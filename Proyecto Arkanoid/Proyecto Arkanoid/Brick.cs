using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public class Brick: PictureBox
    {
        public int hits { get; set; }

        public Brick() : base() { }
    }
}