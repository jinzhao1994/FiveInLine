using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FiveInLine
{
    class Board : Panel
    {
        public void Draw()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    Program.cell[i, j] = new Cell();
                    Program.cell[i, j].Location = new System.Drawing.Point(j * 31, i * 31);
                    Program.cell[i, j].Size = new System.Drawing.Size(31, 31);
                    this.Controls.Add(Program.cell[i, j]);
                    Program.cell[i, j].Draw();
                }
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
        }
        public void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.Black, 1), new Point(0, 279), new Point(279, 279));
            g.DrawLine(new Pen(Color.Black, 1), new Point(279, 0), new Point(279, 279));
        }
        public static void PutNext()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Program.n == 81) return;
                Program.RandomLocation().Appear(Program.next[i].kind);
            }
        }
        public void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                int kind = 2 << Program.random.Next(7);
                Program.RandomLocation().Appear(kind);
            }
        }
        public static int Check()
        {
            int plusScore = 0;
            bool[,] del = new bool[9, 9];
            bool[] bomb = new bool[256];
            for(int i=0;i<9;i++)
                for (int j = 0; j < 9; j++)
                {
                    if (i < 5)
                    {
                        int kind = Program.cell[i, j].kind;
                        bool haveBomb = Program.cell[i, j].kind % 2 != 0;
                        for (int k = 1; k < 5; k++) 
                        {
                            kind &= Program.cell[i + k, j].kind;
                            if (Program.cell[i + k, j].kind % 2 != 0)
                                haveBomb = true;
                        }
                        if (kind != 0)
                        {
                            plusScore += 1;
                            for (int k = 0; k < 5; k++)
                                del[i + k, j] = true;
                            if (haveBomb) bomb[kind] = true;
                        }
                    }
                    if (j < 5)
                    {
                        int kind = Program.cell[i, j].kind;
                        bool haveBomb = Program.cell[i, j].kind % 2 != 0;
                        for (int k = 1; k < 5; k++)
                        {
                            kind &= Program.cell[i, j + k].kind;
                            if (Program.cell[i, j + k].kind % 2 != 0)
                                haveBomb = true;
                        }
                        if (kind != 0)
                        {
                            plusScore += 1;
                            for (int k = 0; k < 5; k++)
                                del[i, j + k] = true;
                            if (haveBomb) bomb[kind] = true;
                        }
                    }
                    if (i < 5 && j < 5)
                    {
                        int kind = Program.cell[i, j].kind;
                        bool haveBomb = Program.cell[i, j].kind % 2 != 0;
                        for (int k = 1; k < 5; k++)
                        {
                            kind &= Program.cell[i + k, j + k].kind;
                            if (Program.cell[i + k, j + k].kind % 2 != 0)
                                haveBomb = true;
                        }
                        if (kind != 0)
                        {
                            plusScore += 1;
                            for (int k = 0; k < 5; k++)
                                del[i + k, j + k] = true;
                            if (haveBomb) bomb[kind] = true;
                        }
                    }
                    if (i > 3 && j < 5)
                    {
                        int kind = Program.cell[i, j].kind;
                        bool haveBomb = Program.cell[i, j].kind % 2 != 0;
                        for (int k = 1; k < 5; k++)
                        {
                            kind &= Program.cell[i - k, j + k].kind;
                            if (Program.cell[i - k, j + k].kind % 2 != 0)
                                haveBomb = true;
                        }
                        if (kind != 0)
                        {
                            plusScore += 1;
                            for (int k = 0; k < 5; k++)
                                del[i - k, j + k] = true;
                            if (haveBomb) bomb[kind] = true;
                        }
                    }
                }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (del[i, j]) Program.cell[i, j].Disappear();
            for (int k = 0; k < 256; k++)
            {
                if (bomb[k])
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            if ((Program.cell[i, j].kind & k) != 0) Program.cell[i, j].Disappear();
            }
            return plusScore * plusScore;
        }
        public static bool CheckGameOver()
        {
            if (Program.n == 81)
            {
                MessageBox.Show("Game Over");
                return true;
            }
            return false;
        }
        public void Clear()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    Program.cell[i, j].Clear();
            Program.n = 0;
            Init();
        }
        public static void ClearEffect()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    Program.cell[i, j].BackColor = System.Drawing.Color.Transparent;
        }
    }
}
