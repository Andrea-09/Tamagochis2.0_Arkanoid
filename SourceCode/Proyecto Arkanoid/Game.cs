﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Game : UserControl
    {
        private Brick [,] cpb;
        private PictureBox ball;
        private Panel scores;
        private Label remainingLives, score1;
        private int remainingBlocks = 0;
        //Action para dispose de formularios
        public Action finishGame, winningGame;
        private PictureBox heart;
     
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
            //Se reinician los valores del puntaje y las vidas
            GameData.initializeGame();
            
            panelScore();
            
            //Carcgando imagen desde archivo
            pictureBox1.BackgroundImage = Image.FromFile("../../Sprites/Player.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            
            //Setteando top y left para la plataforma
            pictureBox1.Top = (Height - pictureBox1.Height) - 80;
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            
            //Carga y setteo de top y left para la pelota
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Sprites/Ball.png");
            ball.BackColor = Color.Transparent;
            ball.BackgroundImageLayout = ImageLayout.Stretch;
            
            
            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
            
            Controls.Add(ball);
            
            loadTiles();
            
        }
        private void loadTiles()
        {
            int xAxis = 7;
            int yAxis = 11;
            remainingBlocks = xAxis * yAxis;
            int pbHeight = (int)(Height * 0.3) / yAxis;
            int pbWidth = (Width - xAxis) / xAxis;

            //Instancia de matriz
            cpb = new Brick[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i , j] = new Brick();

                    if (i == 10)
                    {
                        cpb[i, j].hits = 2;
                    }
                    else
                    {
                        cpb[i, j].hits = 1;
                    }
                    
                    //Setteando tamaño
                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    
                    //posicion de left y top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + scores.Height + 1;
                    

                    //Carga los sprites de bloques blindados en la fila 11
                    if (i == 10)
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Sprites/tb1.png");
                        cpb[i, j].Tag = "blinded";
                    }
                    
                    //Se colocan el resto de los bloques numerados en el resto de las filas
                    else
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Sprites/" + (i + 1) + ".png");
                        cpb[i, j].Tag = "tileTag";
                    }
                    
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    
                    Controls.Add(cpb[i, j]);

                }
            }

        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
                //Verificacion por si el jugador presiona otra tecla al iniciar el juego
                switch (e.KeyCode)
                {
                    case Keys.Space:
                     
                        GameData.gameOn = true;
                        timer1.Start();
                        break;
                 
                    default:
                        throw new WrongKeyPressedException("Presione Space para comezar el juego");
                }
            }
            catch (WrongKeyPressedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!GameData.gameOn){return;}

            try
            {
                ball.Left += GameData.dirX;
                ball.Top += GameData.dirY;

                GameData.ticksRealize += 0.1;
                BounceBall();

            }
            catch (OutOfBoundsException ex)
            {
                try
                {
                    GameData.life--;
                    GameData.gameOn = false;
                    timer1.Stop();
                
                    repositionElements();
                    refreshElement();

                    if (GameData.life == 0)
                    {
                        throw new NoRemainingLivesException("");
                    }
                }
                catch (NoRemainingLivesException ex2)
                {
                    timer1.Stop();
                    MessageBox.Show("Has perdido :(\n¡Suerte a la próxima!");
                    finishGame?.Invoke();
                }
            }


        }

        //Fisicas para el rebote de la pelota
        private void BounceBall()
        {
            if (ball.Top < scores.Height)
            {
                GameData.dirY = -GameData.dirY;
                return;
            }

                if (ball.Bottom > Height)
                throw new OutOfBoundsException("");
            
            else if (ball.Left < 0 || ball.Right > Width)
            {
                GameData.dirX = -GameData.dirX;
                return;
            }else if (ball.Bottom < scores.Height)
            {
                GameData.dirY = -GameData.dirY;
            }

            if (ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                GameData.dirY = -GameData.dirY;
                return;
            }
            
            for (int i = 10; i >= 0; i--)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        
                        GameData.Score += (int)(cpb[i, j].hits * GameData.ticksRealize);
                        cpb[i, j].hits--;

                        if (cpb[i, j].hits == 0)
                        {
                            
                            Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;
                            remainingBlocks--;
                        }
                        
                        //Cambio de sprite de blindado a agrietado
                        else if(cpb[i, j].Tag.Equals("blinded"))
                           cpb[i, j].BackgroundImage = Image.FromFile("../../Sprites/tb2.png");
                        
                        GameData.dirY = -GameData.dirY;

                        score1.Text = GameData.Score.ToString();

                        if (remainingBlocks == 0)
                        {
                            timer1.Stop();
                            MessageBox.Show("¡Felicidades, ganaste! ¡Gracias por jugar, eres increible!");
                            winningGame.Invoke();
                        }
                        
                        return;
                    }
                }
            }
        }

        private void panelScore()
        {
            //Instancia panel
            scores = new Panel();
            
            //Setear elementos del panel
            scores.Width = Width;
            scores.Height = (int) (Height * 0.07);

            scores.Top = scores.Left = 0;
            
            scores.BackColor = Color.CornflowerBlue;
            
            #region Label + PictureBox
            //Instanciar pb 
            heart = new PictureBox();

            heart.Height = heart.Width = scores.Height;

            heart.Left = 20;
            
            heart.BackgroundImage = Image.FromFile("../../Sprites/Heart.png");
            heart.BackgroundImageLayout = ImageLayout.Stretch;

            #endregion
            
            //Instanciar labels
            remainingLives = new Label();
            score1 = new Label();

            //Setear elementos de los labels
            remainingLives.ForeColor = score1.ForeColor = Color.White;
            
            remainingLives.Text = "X " + GameData.life.ToString();
            score1.Text =  "♕ " + GameData.Score.ToString();

            remainingLives.Font = score1.Font = new Font("Showcard Gothic", 24F);
            remainingLives.TextAlign = score1.TextAlign = ContentAlignment.MiddleCenter;
            
            remainingLives.Left = heart.Right + 5;
            score1.Left = Width - 100;

            remainingLives.Height = score1.Height = scores.Height;

            scores.Controls.Add(heart);
            scores.Controls.Add(remainingLives);
            scores.Controls.Add(score1);
            
            Controls.Add(scores);
        }

        private void repositionElements()
        {
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);

        }

        private void refreshElement()
        {
            remainingLives.Text = "X " + GameData.life.ToString();
            score1.Text = "♕ " + GameData.Score.ToString();
        }
        
    }
}