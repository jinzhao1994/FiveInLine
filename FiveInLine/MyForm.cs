using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveInLine
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            Program.next[0] = nextCell1;
            Program.next[1] = nextCell2;
            Program.next[2] = nextCell3;
            Program.labScore = this.labScore;
            for (int i = 0; i < 3; i++)
                Program.next[i].Draw();
            board.Draw();
            board.Init();
            Program.GetNext();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string s = "";
            s += "~Help~\n\n";
            s += "This is a PC game. You will play with some colorful balls.\n\n";
            s += "Some ball will appear after each step, except you eliminate balls at this step. When five or more balls with same color stand in a line, they will disappear. If you eliminate more than one line at one step, you will get higher score.\n\n";
            s += "Enjoy yourself~\n\n";
            s += "Programming By Cs\n";
            MessageBox.Show(s);
        }

        public void MyForm_Paint(object sender, PaintEventArgs e)
        {
            //337,377,417  130   
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.Black, 1), new Point(337, 161), new Point(368, 161));
            g.DrawLine(new Pen(Color.Black, 1), new Point(368, 130), new Point(368, 161));
            g.DrawLine(new Pen(Color.Black, 1), new Point(377, 161), new Point(408, 161));
            g.DrawLine(new Pen(Color.Black, 1), new Point(408, 130), new Point(408, 161));
            g.DrawLine(new Pen(Color.Black, 1), new Point(417, 161), new Point(448, 161));
            g.DrawLine(new Pen(Color.Black, 1), new Point(448, 130), new Point(448, 161));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Program.state != 0) return;
            Board.PutNext();
            Program.GetNext();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (Program.state != 0) return;
            board.Clear();
            Program.PlusScore(-Program.score);
            Program.GetNext();
        }
    }
}
