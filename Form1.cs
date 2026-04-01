using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Flappy_Birdy
{
    public partial class Form1 : Form
    {
        int extraPipeTimer = 0;
        List<PictureBox> extraPipesTop = new List<PictureBox>();
        List<PictureBox> extraPipesBottom = new List<PictureBox>();
        Random rand = new Random();
 

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Focus();
            gameTimer.Start();
        }
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (isGameOver)
            {
                Application.Restart(); 
            }

            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }
 
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            isGameOver = true;
            scoreText.Text += "  Game over! Press any key to restart";
        }
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                endGame();
                return;
            }

            if (score > 5) pipeSpeed = 10;
            if (score > 10) pipeSpeed = 12;
            if (score > 20) pipeSpeed = 14;
            if (score > 30) pipeSpeed = 16;
            if (score > 50) pipeSpeed = 18;

            int gap = 150;

            extraPipeTimer++;

            int pipeSpawnRate = Math.Max(40, 200 - score * 5);

            if (extraPipeTimer > pipeSpawnRate)
            {
                extraPipeTimer = 0;

                int pipeWidth = 100;
                int topHeight = rand.Next(100, 350);
                int bottomY = topHeight + gap;
                int bottomHeight = this.ClientSize.Height - bottomY - ground.Height + 100;

                PictureBox newTop = new PictureBox
                {
                    Size = new Size(pipeWidth, topHeight),
                    Location = new Point(this.ClientSize.Width, 0),
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "pipedown.png")),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent
                };

                PictureBox newBottom = new PictureBox
                {
                    Size = new Size(pipeWidth, bottomHeight),
                    Location = new Point(this.ClientSize.Width, bottomY),
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "pipe.png")),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent
                };

                this.Controls.Add(newTop);
                this.Controls.Add(newBottom);

                newTop.SendToBack();
                newBottom.SendToBack();
                ground.BringToFront();
                flappyBird.BringToFront();
                scoreText.BringToFront();

                extraPipesTop.Add(newTop);
                extraPipesBottom.Add(newBottom);
            }

            for (int i = 0; i < extraPipesTop.Count; i++)
            {
                extraPipesTop[i].Left -= pipeSpeed;
                extraPipesBottom[i].Left -= pipeSpeed;

                if (flappyBird.Bounds.IntersectsWith(extraPipesTop[i].Bounds) ||
                    flappyBird.Bounds.IntersectsWith(extraPipesBottom[i].Bounds))
                {
                    endGame();
                    return;
                }

                if (extraPipesTop[i].Left < -100)
                {
                    this.Controls.Remove(extraPipesTop[i]);
                    this.Controls.Remove(extraPipesBottom[i]);
                    extraPipesTop.RemoveAt(i);
                    extraPipesBottom.RemoveAt(i);
                    score++;
                    break;
                }
            }
        }
  
    }
}
