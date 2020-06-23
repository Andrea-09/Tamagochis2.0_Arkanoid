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
            try
            {
                Playing play = new Playing();
                name = textBox1.Text.ToLower();

                //Si el nickname es mayor que 15
                if (name.Length > 15)
                    throw new LongerNicknameException("Ingrese un nickname menor o igual 15 caracteres");

                //si no se ingresa ningun nickname
                else if (name.Trim().Length == 0)
                    throw new EmptyNicknameException("Ingrese un nickname para empezar el juego");
                else if (name.Equals(GameData.nickName))
                    throw new ExistingNicknameException("Este nombre ya está registrado");

                else
                {
                    string sql = $"INSERT INTO PLAYER(nickname) VALUES('{name}')";
                    ConnectionDB.ExecuteNonQuery(sql);
                    GameData.nickName = name;
                    textBox1.Text = "";
                    play.Show();
                    Dispose();
                }
            }
            catch (EmptyNicknameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (LongerNicknameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ExistingNicknameException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}