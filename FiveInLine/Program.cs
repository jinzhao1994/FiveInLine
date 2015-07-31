using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FiveInLine
{
    static class Program
    {
        public static Random random = new Random();
        public static Cell[,] cell = new Cell[9, 9];
        public static Cell[] next = new Cell[3];
        public static int[,] dis = new int[9, 9];
        public static Label labScore;
        public static int n = 0;
        public static int state = 0;
        public static int startX = -1, startY = -1;
        public static int score = 0;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
        public static System.Drawing.Bitmap GetPic(int i)
        {
            if (i == -1) return global::FiveInLine.Properties.Resources.pic0;
            if (i == 2) return global::FiveInLine.Properties.Resources.pic2;
            if (i == 4) return global::FiveInLine.Properties.Resources.pic4;
            if (i == 6) return global::FiveInLine.Properties.Resources.pic6;
            if (i == 8) return global::FiveInLine.Properties.Resources.pic8;
            if (i == 16) return global::FiveInLine.Properties.Resources.pic16;
            if (i == 24) return global::FiveInLine.Properties.Resources.pic24;
            if (i == 32) return global::FiveInLine.Properties.Resources.pic32;
            if (i == 64) return global::FiveInLine.Properties.Resources.pic64;
            if (i == 96) return global::FiveInLine.Properties.Resources.pic96;
            if (i == 128) return global::FiveInLine.Properties.Resources.pic128;
            if (i == 254) return global::FiveInLine.Properties.Resources.pic254;
            if (i == 255) return global::FiveInLine.Properties.Resources.pic255;
            return null;
        }
        public static int RandomKind()
        {
            //随机产生一个球。有11%的概率产生单色球，5%双色，4%彩色或炸弹。
            //返回值转化为二进制后的每一位数代表一种颜色的有无。最低位代表有无炸弹效果。
            int x = random.Next(100);
            if (x < 11) return 2;
            if (x < 22) return 4;
            if (x < 33) return 8;
            if (x < 44) return 16;
            if (x < 55) return 32;
            if (x < 66) return 64;
            if (x < 77) return 128;
            if (x < 82) return 6;
            if (x < 87) return 24;
            if (x < 92) return 96;
            if (x < 96) return 254;
            return 255;
        }
        public static void GetNext()
        {
            for(int i=0;i<3;i++) {
                next[i].kind = RandomKind();
                next[i].pic.Image = GetPic(next[i].kind);
            }
        }
        public static Cell RandomLocation()
        {
            int k = random.Next(81 - n) + 1;
            int i=0,j=-1;
            while (k > 0)
            {
                k--;
                j++;
                if (j == 9)
                {
                    i++;
                    j = 0;
                }
                while (cell[i, j].kind != 0)
                {
                    j++;
                    if (j == 9)
                    {
                        i++;
                        j = 0;
                    }
                }
            }
            return cell[i, j];
        }
        public static void PlusScore(int x)
        {
            score += x;
            labScore.Text = "Score: " + Convert.ToString(score);
        }
        public static void CalculateDistance()
        {
            Point[] que = new Point[81];
            int p =0, q = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    dis[i, j] = -1;
            dis[startX, startY] = 0;
            que[q++] = new Point(startX, startY);
            while (p != q)
            {
                Point cur = que[p++];
                if (cur.X > 0 && dis[cur.X - 1, cur.Y] == -1 && cell[cur.X - 1, cur.Y].kind == 0)
                {
                    dis[cur.X - 1, cur.Y] = dis[cur.X, cur.Y] + 1;
                    que[q++] = new Point(cur.X - 1, cur.Y);
                }
                if (cur.X < 8 && dis[cur.X + 1, cur.Y] == -1 && cell[cur.X + 1, cur.Y].kind == 0)
                {
                    dis[cur.X + 1, cur.Y] = dis[cur.X, cur.Y] + 1;
                    que[q++] = new Point(cur.X + 1, cur.Y);
                }
                if (cur.Y > 0 && dis[cur.X, cur.Y - 1] == -1 && cell[cur.X, cur.Y - 1].kind == 0)
                {
                    dis[cur.X, cur.Y - 1] = dis[cur.X, cur.Y] + 1;
                    que[q++] = new Point(cur.X, cur.Y - 1);
                }
                if (cur.Y < 8 && dis[cur.X, cur.Y + 1] == -1 && cell[cur.X, cur.Y + 1].kind == 0)
                {
                    dis[cur.X, cur.Y + 1] = dis[cur.X, cur.Y] + 1;
                    que[q++] = new Point(cur.X, cur.Y + 1);
                }
            }
            /*
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(Convert.ToString(dis[i, j]).PadLeft(4));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
             * */
        }
        public static void MoveTo(int x, int y)
        {
            int kind = cell[startX, startY].kind;
            cell[startX, startY].Unchoose();
            int i = x, j = y;
            cell[i, j].MoveAnimation(dis[i, j] * 20, true, kind);
            while (Program.dis[i, j] != 0)
            {
                if (i > 0 && Program.dis[i - 1, j] + 1 == Program.dis[i, j]) i--;
                else if (i < 8 && Program.dis[i + 1, j] + 1 == Program.dis[i, j]) i++;
                else if (j > 0 && Program.dis[i, j - 1] + 1 == Program.dis[i, j]) j--;
                else j++;
                cell[i, j].MoveAnimation(dis[i, j] * 20, false, kind);
            }
        }

    }
}
