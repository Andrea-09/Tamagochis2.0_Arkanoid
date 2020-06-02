using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Login : UserControl
    {
        private string name = "";
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            MessageBox.Show(name);
        }
    }
}