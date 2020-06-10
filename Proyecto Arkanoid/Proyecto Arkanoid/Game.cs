using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Game : UserControl
    {
        private Brick [,] cpb;
        private PictureBox ball;

        public Game()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void game_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameData.gameOn)
            {
                if (e.X < (Width - pictureBox1.Width))
                {
                    pictureBox1.Left = e.X;
                    ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
                }
            }
            else
            {
                if(e.X < (Width - pictureBox1.Width))
                    pictureBox1.Left = e.X;
            }
            
        }

        private void Game_Load(object sender, EventArgs e)
        {
            pictureBox1.Top = (Height - pictureBox1.Height) - 80;
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Sprites/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;
            
            
            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
            
            Controls.Add(ball);
            
            loadTiles();
        }
        private void loadTiles()
        {
            int xAxis = 7;
            int yAxis = 12; 
            
            int pbHeight = (int)(Height * 0.3) / yAxis;
            int pbWidth = (Width - xAxis) / xAxis;

            //Instancia de matriz
            cpb = new Brick[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i , j] = new Brick();
                    
                    if(i == 0)
                        cpb[i, j].hits = 3;
                    else
                    
                        cpb[i, j].hits = 2;
                    

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    
                    //posicion de left y top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;

                    cpb[i, j].BackgroundImage = Image.FromFile("../../Sprites/" + (i + 1) + ".png");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tileTag";
                    Controls.Add(cpb[i, j]);

                }
            }

        }
        
       //Esto es por si queremos que los bloques aparezcan de manera random
       //Tendría que ponerse en lugar de (i + 1) 
        private int genRanNumber()
        {
            return new Random().Next(1, 12);
        }
    }
}