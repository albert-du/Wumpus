
namespace WumpusJones
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonArrow = new System.Windows.Forms.Button();
            this.triviaControl1 = new WumpusJones.TriviaControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wumpus Jones";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.labelMessage.ForeColor = System.Drawing.Color.Yellow;
            this.labelMessage.Location = new System.Drawing.Point(79, 84);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(79, 26);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "label2";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(668, 10);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(96, 38);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(580, 67);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Show High Scores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Location = new System.Drawing.Point(69, 121);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 700);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // buttonArrow
            // 
            this.buttonArrow.Location = new System.Drawing.Point(652, 757);
            this.buttonArrow.Name = "buttonArrow";
            this.buttonArrow.Size = new System.Drawing.Size(96, 45);
            this.buttonArrow.TabIndex = 8;
            this.buttonArrow.Text = "Shoot Arrow";
            this.buttonArrow.UseVisualStyleBackColor = true;
            this.buttonArrow.Click += new System.EventHandler(this.buttonArrow_Click);
            // 
            // triviaControl1
            // 
            this.triviaControl1.BackColor = System.Drawing.SystemColors.Control;
            this.triviaControl1.Location = new System.Drawing.Point(137, 257);
            this.triviaControl1.Name = "triviaControl1";
            this.triviaControl1.Size = new System.Drawing.Size(557, 350);
            this.triviaControl1.TabIndex = 7;
            this.triviaControl1.Trivia = null;
            this.triviaControl1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(822, 855);
            this.Controls.Add(this.buttonArrow);
            this.Controls.Add(this.triviaControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Hunt the Wumpus";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private TriviaControl triviaControl1;
        private System.Windows.Forms.Button buttonArrow;
    }
}

