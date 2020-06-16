using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class User : Form
    {
        Form1 p = new Form1();
        private string name = "";
        public User()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
        
        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Playing play = new Playing();
            name = textBox1.Text;
            string sql = $"INSERT INTO PLAYER(nickname) VALUES('{name}')";
            ConnectionDB.ExecuteNonQuery(sql);
            textBox1.Text = "";
            play.Show();
            this.Hide();
        }
    }
}