using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Form1 : Form
    {
        private UserControl user = new Login();
        //private Login user = new Login();
        
        
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //user.Controls.Add(user);
            //Controls.Add(user);
            user.Hide();
            user.Controls.Add(user);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}