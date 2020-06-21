using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Top10 : Form
    {
        Form1 p = new Form1();

        private Label[,] players;
        public Top10()
        {
            InitializeComponent();
            //Height = ClientSize.Height;
            //Width = ClientSize.Width;
            //WindowState = FormWindowState.Maximized;
        }

        private void Top10_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            p.Show();
        }

        private void Top10_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void LoadPlayers()
        { 
            var playerList = PlayerController.ObtainTopPlayer();
            players = new Label[10, 2];

            int listTop = 125, listLeft = 40;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    players[i, j] = new Label();

                    if (j == 0)
                    {
                        players[i, j].Text = playerList[i].Nickname;
                        players[i, j].Left = listLeft;
                    }
                    else
                    {
                            players[i, j].Text = playerList[i].Score.ToString();
                            players[i, j].Left = Width / 2 + listLeft;
                    }

                    players[i, j].Top = listTop + (listTop - 73) * i;
                    players[i, j].Height += 15;
                    players[i, j].Width += 25;
                    players[i, j].Font = new Font("Showcard Gothic", 24F);
                    players[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    players[i, j].ForeColor = Color.White;
                    players[i, j].BackColor = Color.Transparent;

                    Controls.Add(players[i, j]);
                }
            }
        }
    }
}