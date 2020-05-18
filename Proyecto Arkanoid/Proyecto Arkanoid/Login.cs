using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Login : UserControl
    {
        private string name = "";
        public Login()
        {
            InitializeComponent();
            name = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = name;
        }
    }
}