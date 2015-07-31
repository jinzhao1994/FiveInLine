using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FiveInLine
{
    class Cell : Panel
    {
        public int kind = 0;
        public PictureBox pic = new PictureBox();
        SizeAnimation anim;
        public void Draw()
        {
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintEvent);

            this.pic.Image = null;
            this.pic.Location = new System.Drawing.Point(1, 1);
            this.pic.Size = new System.Drawing.Size(30, 30);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickEvent);
            this.pic.MouseEnter += new System.EventHandler(this.MouseEnterEvent);
            this.pic.MouseLeave += new System.EventHandler(this.MouseLeaveEvent);
            
            this.Controls.Add(this.pic);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
        }
        public void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(0, 31));
            g.DrawLine(new Pen(Color.Black, 1), new Point(0, 0), new Point(31, 0));
        }
        public void MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (Program.state != 0) return;
            int j = ((PictureBox)sender).Parent.Location.X / 31;
            int i = ((PictureBox)sender).Parent.Location.Y / 31;
            if (j > 8) return;
            if (Program.startX == -1)
            {
                if (Program.cell[i, j].kind == 0) return;
                Program.cell[i,j].Choose();
            }
            else
            {
                if ((i == Program.startX && j == Program.startY)
                    || (Program.dis[i, j] == -1))
                {
                    Program.cell[Program.startX, Program.startY].Unchoose();
                    return;
                }
                Board.ClearEffect();
                Program.MoveTo(i,j);
            }
        }
        private void MouseEnterEvent(object sender, EventArgs e)
        {
            if (Program.state != 0) return;
            int j = ((PictureBox)sender).Parent.Location.X / 31;
            int i = ((PictureBox)sender).Parent.Location.Y / 31;
            if (j > 8) return;
            if (Program.startX == -1) return;
            if (Program.dis[i, j] == -1) return;
            
            while (Program.dis[i, j] != 0)
            {
                Program.cell[i,j].BackColor = System.Drawing.Color.Azure;
                if (i > 0 && Program.dis[i - 1, j] + 1 == Program.dis[i, j]) i--;
                else if (i < 8 && Program.dis[i + 1, j] + 1 == Program.dis[i, j]) i++;
                else if (j > 0 && Program.dis[i, j - 1] + 1 == Program.dis[i, j]) j--;
                else j++;
            }

        }
        private void MouseLeaveEvent(object sender, EventArgs e)
        {
            if (Program.state != 0) return;
            int j = ((PictureBox)sender).Parent.Location.X / 31;
            int i = ((PictureBox)sender).Parent.Location.Y / 31;
            if (j > 8) return;
            if (Program.startX == -1) return;
            Board.ClearEffect();
        }
        public void Appear(int kind)
        {
            this.kind = kind;
            Program.n++;
            AppearAnimation();
        }
        public void Disappear()
        {
            this.kind = 0;
            Program.n--;
            DisappearAnimation();
        }
        public void Choose()
        {
            this.pic.Location = new System.Drawing.Point(6, 6);
            this.pic.Size = new System.Drawing.Size(20, 20);
            Program.startX = this.Location.Y / 31;
            Program.startY = this.Location.X / 31;
            Program.CalculateDistance();
        }
        public void Unchoose()
        {
            this.pic.Location = new System.Drawing.Point(1, 1);
            this.pic.Size = new System.Drawing.Size(30, 30);
            Program.startX = -1;
            Program.startY = -1;
        }
        private void AppearAnimation()
        {
            Program.state++;
            this.pic.Image = Program.GetPic(kind);
            anim = new SizeAnimation(0, 200, 0, 30, this, AppearFinished);
        }
        public void AppearFinished(Cell x)
        {
            Program.state--;
            if (Program.state == 0)
            {
                Program.PlusScore(Board.Check());
                Board.CheckGameOver();
            }
        }
        public void DisappearAnimation()
        {
            Program.state++;
            anim = new SizeAnimation(0, 300, 30, 0, this, DisappearFinished);
        }
        public void DisappearFinished(Cell x)
        {
            this.pic.Image = null;
            Program.state--;
        }
        public void MoveAnimation(int startDelay,bool target,int kind)
        {
            Program.state++;
            this.pic.Image = Program.GetPic(kind);
            if (target)
            {
                this.kind = kind;
                anim = new SizeAnimation(startDelay, 0, 30, 30, this, TargetMoveFinished);
            } else
                anim = new SizeAnimation(startDelay, 200, 20, 0, this, MoveFinished);
        }
        public void MoveFinished(Cell x)
        {
            this.pic.Image = null;
            this.kind = 0;
            Program.state--;
            if (Program.state == 0)
            {
                int plusScore = Board.Check();
                Program.PlusScore(plusScore);
                if (plusScore == 0)
                {
                    Board.PutNext();
                    Program.GetNext();
                }
            }
        }
        public void TargetMoveFinished(Cell x)
        {
            Program.state--;
            if (Program.state == 0)
            {
                int plusScore = Board.Check();
                Program.PlusScore(plusScore);
                if (plusScore == 0)
                {
                    Board.PutNext();
                    Program.GetNext();
                }
            }
        }
        public void Clear()
        {
            kind = 0;
            this.pic.Image = null;
        }
    }
}
