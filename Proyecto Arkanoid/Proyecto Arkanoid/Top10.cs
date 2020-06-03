using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Top10 : Form
    {
        Form1 p = new Form1();
        public Top10()
        {
            InitializeComponent();
        }
        
        private void Top10_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            p.Show();
        }
    }
}