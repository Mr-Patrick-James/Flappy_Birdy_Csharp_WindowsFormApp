using System.Drawing;
using System.Windows.Forms;

namespace Flappy_Birdy
{
    public class Pipe
    {
        public PictureBox TopPipe { get; set; }
        public PictureBox BottomPipe { get; set; }

        public Pipe(int x, int gapHeight, int speed, Control container)
        {
            int gapSize = 130;
            int pipeWidth = 60;

            int topHeight = gapHeight;
            int bottomY = gapHeight + gapSize;
            int bottomHeight = container.Height - bottomY - 100;

            TopPipe = new PictureBox
            {
                Size = new Size(pipeWidth, topHeight),
                Location = new Point(x, 0),
                BackColor = Color.Green
            };

            BottomPipe = new PictureBox
            {
                Size = new Size(pipeWidth, bottomHeight),
                Location = new Point(x, bottomY),
                BackColor = Color.Green
            };

            container.Controls.Add(TopPipe);
            container.Controls.Add(BottomPipe);
        }

        public void Move(int speed)
        {
            TopPipe.Left -= speed;
            BottomPipe.Left -= speed;
        }

        public bool IsOffScreen()
        {
            return TopPipe.Right < 0;
        }

        public void Remove(Control container)
        {
            container.Controls.Remove(TopPipe);
            container.Controls.Remove(BottomPipe);
        }

        public bool CollidesWith(PictureBox flappy)
        {
            return flappy.Bounds.IntersectsWith(TopPipe.Bounds) || flappy.Bounds.IntersectsWith(BottomPipe.Bounds);
        }
    }
}
