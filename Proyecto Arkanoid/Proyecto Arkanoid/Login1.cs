using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Login1 : Form
    {
        Form1 p = new Form1();
        private string name = "";
        
        public Login1()
        {
            InitializeComponent();
            
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

        private void Login1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            p.Show();
        }

        
    }
}