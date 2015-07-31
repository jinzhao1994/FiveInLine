namespace FiveInLine
{
    partial class MyForm 
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labScore = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.nextCell2 = new FiveInLine.Cell();
            this.nextCell3 = new FiveInLine.Cell();
            this.nextCell1 = new FiveInLine.Cell();
            this.board = new FiveInLine.Board();
            this.SuspendLayout();
            // 
            // labScore
            // 
            this.labScore.AutoSize = true;
            this.labScore.BackColor = System.Drawing.Color.Transparent;
            this.labScore.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScore.Location = new System.Drawing.Point(323, 31);
            this.labScore.Name = "labScore";
            this.labScore.Size = new System.Drawing.Size(96, 29);
            this.labScore.TabIndex = 1;
            this.labScore.Text = "Score: 0";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(353, 83);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(353, 204);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(353, 254);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // nextCell2
            // 
            this.nextCell2.BackColor = System.Drawing.Color.Transparent;
            this.nextCell2.Location = new System.Drawing.Point(377, 130);
            this.nextCell2.Name = "nextCell2";
            this.nextCell2.Size = new System.Drawing.Size(31, 31);
            this.nextCell2.TabIndex = 6;
            // 
            // nextCell3
            // 
            this.nextCell3.BackColor = System.Drawing.Color.Transparent;
            this.nextCell3.Location = new System.Drawing.Point(417, 130);
            this.nextCell3.Name = "nextCell3";
            this.nextCell3.Size = new System.Drawing.Size(31, 31);
            this.nextCell3.TabIndex = 6;
            // 
            // nextCell1
            // 
            this.nextCell1.BackColor = System.Drawing.Color.Transparent;
            this.nextCell1.Location = new System.Drawing.Point(337, 130);
            this.nextCell1.Name = "nextCell1";
            this.nextCell1.Size = new System.Drawing.Size(31, 31);
            this.nextCell1.TabIndex = 5;
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Transparent;
            this.board.Location = new System.Drawing.Point(21, 21);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(280, 280);
            this.board.TabIndex = 0;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FiveInLine.Properties.Resources.云;
            this.ClientSize = new System.Drawing.Size(476, 324);
            this.Controls.Add(this.nextCell2);
            this.Controls.Add(this.nextCell3);
            this.Controls.Add(this.nextCell1);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.labScore);
            this.Controls.Add(this.board);
            this.MaximumSize = new System.Drawing.Size(492, 363);
            this.MinimumSize = new System.Drawing.Size(492, 363);
            this.Name = "MyForm";
            this.Text = "Five in Line";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Board board;
        private System.Windows.Forms.Label labScore;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnRestart;
        private Cell nextCell1;
        private Cell nextCell2;
        private Cell nextCell3;
    }
}

