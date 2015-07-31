using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveInLine
{
    class SizeAnimation : Timer
    {
        int startDelay, keepTime, curTime;
        int fromSize, toSize;
        Cell x;
        public delegate void OnFinished(Cell x);
        OnFinished onFinished;
        public SizeAnimation(int startDelay, int keepTime, int fromSize, int toSize, Cell x, OnFinished onFinished)
        {
            this.startDelay = startDelay;
            this.keepTime = keepTime;
            this.curTime = 0;
            this.fromSize = fromSize;
            this.toSize = toSize;
            this.x = x;
            this.onFinished = onFinished;
            this.Interval = 20;
            this.Tick += new System.EventHandler(this.Update);
            this.Enabled = true;
            x.pic.Size = new System.Drawing.Size(0, 0);
        }
        private void Update(object sender, EventArgs e)
        {
            if (this.startDelay > 0)
            {
                startDelay -= 20;
                return;
            }
            this.curTime += 20;
            if (this.curTime >= this.keepTime)
            {
                this.Enabled = false;
                x.pic.Size = new System.Drawing.Size(30, 30);
                x.pic.Location = new System.Drawing.Point(1, 1);
                this.onFinished(x);
                return;
            }
            int curSize=fromSize+(int)((toSize-fromSize)*(double)curTime/keepTime);
            x.pic.Size = new System.Drawing.Size(curSize, curSize);
            int curX=(30-curSize)/2+1;
            x.pic.Location = new System.Drawing.Point(curX, curX);
        }
    }
}
