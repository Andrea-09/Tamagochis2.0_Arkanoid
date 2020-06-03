using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Form1 : Form
    {
        //private UserControl user = new Login();
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
            login1.Show();
            login1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Top10 top = new Top10();
            top.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}