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