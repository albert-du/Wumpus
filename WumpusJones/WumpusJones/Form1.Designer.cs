
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHighScores = new System.Windows.Forms.Button();
            this.buttonArrow = new System.Windows.Forms.Button();
            this.buttonMap = new System.Windows.Forms.Button();
            this.labelArrows = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelCoins = new System.Windows.Forms.Label();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonBuyArrows = new System.Windows.Forms.Button();
            this.buttonBuySecret = new System.Windows.Forms.Button();
            this.mapControl1 = new WumpusJones.MapControl();
            this.triviaControl1 = new WumpusJones.TriviaControl();
            this.gameEndControl1 = new WumpusJones.GameEndControl();
            this.labelTurns = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wumpus Jones";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // buttonHighScores
            // 
            this.buttonHighScores.Location = new System.Drawing.Point(468, 29);
            this.buttonHighScores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonHighScores.Name = "buttonHighScores";
            this.buttonHighScores.Size = new System.Drawing.Size(147, 30);
            this.buttonHighScores.TabIndex = 5;
            this.buttonHighScores.Text = "Show High Scores";
            this.buttonHighScores.UseVisualStyleBackColor = true;
            this.buttonHighScores.Click += new System.EventHandler(this.buttonHighScores_Click);
            // 
            // buttonArrow
            // 
            this.buttonArrow.Location = new System.Drawing.Point(520, 664);
            this.buttonArrow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonArrow.Name = "buttonArrow";
            this.buttonArrow.Size = new System.Drawing.Size(77, 36);
            this.buttonArrow.TabIndex = 8;
            this.buttonArrow.Text = "Shoot Arrow";
            this.buttonArrow.UseVisualStyleBackColor = true;
            this.buttonArrow.Click += new System.EventHandler(this.buttonArrow_Click);
            // 
            // buttonMap
            // 
            this.buttonMap.Location = new System.Drawing.Point(520, 163);
            this.buttonMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(68, 26);
            this.buttonMap.TabIndex = 10;
            this.buttonMap.Text = "Map";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // labelArrows
            // 
            this.labelArrows.AutoSize = true;
            this.labelArrows.BackColor = System.Drawing.Color.Gray;
            this.labelArrows.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArrows.Location = new System.Drawing.Point(63, 163);
            this.labelArrows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelArrows.Name = "labelArrows";
            this.labelArrows.Size = new System.Drawing.Size(62, 19);
            this.labelArrows.TabIndex = 12;
            this.labelArrows.Text = "Arrows:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Gray;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gold;
            this.richTextBox1.Location = new System.Drawing.Point(54, 74);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.ShortcutsEnabled = false;
            this.richTextBox1.Size = new System.Drawing.Size(561, 78);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // labelCoins
            // 
            this.labelCoins.AutoSize = true;
            this.labelCoins.BackColor = System.Drawing.Color.Gray;
            this.labelCoins.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoins.Location = new System.Drawing.Point(63, 182);
            this.labelCoins.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCoins.Name = "labelCoins";
            this.labelCoins.Size = new System.Drawing.Size(62, 19);
            this.labelCoins.TabIndex = 14;
            this.labelCoins.Text = "Arrows:";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxImage.Image")));
            this.pictureBoxImage.Location = new System.Drawing.Point(94, 109);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(494, 278);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 15;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(54, 155);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(560, 560);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // buttonBuyArrows
            // 
            this.buttonBuyArrows.Location = new System.Drawing.Point(75, 664);
            this.buttonBuyArrows.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBuyArrows.Name = "buttonBuyArrows";
            this.buttonBuyArrows.Size = new System.Drawing.Size(74, 36);
            this.buttonBuyArrows.TabIndex = 16;
            this.buttonBuyArrows.Text = "Buy Arrows";
            this.buttonBuyArrows.UseVisualStyleBackColor = true;
            this.buttonBuyArrows.Click += new System.EventHandler(this.buttonBuyArrows_Click);
            // 
            // buttonBuySecret
            // 
            this.buttonBuySecret.Location = new System.Drawing.Point(75, 616);
            this.buttonBuySecret.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBuySecret.Name = "buttonBuySecret";
            this.buttonBuySecret.Size = new System.Drawing.Size(74, 36);
            this.buttonBuySecret.TabIndex = 17;
            this.buttonBuySecret.Text = "Buy Secret";
            this.buttonBuySecret.UseVisualStyleBackColor = true;
            this.buttonBuySecret.Click += new System.EventHandler(this.buttonBuySecret_Click);
            // 
            // mapControl1
            // 
            this.mapControl1.Cave = null;
            this.mapControl1.GameLocations = null;
            this.mapControl1.Location = new System.Drawing.Point(94, 179);
            this.mapControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(480, 480);
            this.mapControl1.TabIndex = 11;
            this.mapControl1.Visible = false;
            // 
            // triviaControl1
            // 
            this.triviaControl1.BackColor = System.Drawing.SystemColors.Control;
            this.triviaControl1.Location = new System.Drawing.Point(115, 380);
            this.triviaControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.triviaControl1.Name = "triviaControl1";
            this.triviaControl1.Size = new System.Drawing.Size(440, 287);
            this.triviaControl1.TabIndex = 7;
            this.triviaControl1.Trivia = null;
            this.triviaControl1.Visible = false;
            // 
            // gameEndControl1
            // 
            this.gameEndControl1.BackColor = System.Drawing.SystemColors.Control;
            this.gameEndControl1.Location = new System.Drawing.Point(115, 124);
            this.gameEndControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gameEndControl1.Name = "gameEndControl1";
            this.gameEndControl1.Size = new System.Drawing.Size(442, 494);
            this.gameEndControl1.TabIndex = 18;
            this.gameEndControl1.Visible = false;
            // 
            // labelTurns
            // 
            this.labelTurns.AutoSize = true;
            this.labelTurns.BackColor = System.Drawing.Color.Gray;
            this.labelTurns.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurns.Location = new System.Drawing.Point(63, 200);
            this.labelTurns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTurns.Name = "labelTurns";
            this.labelTurns.Size = new System.Drawing.Size(52, 19);
            this.labelTurns.TabIndex = 19;
            this.labelTurns.Text = "Turns:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Gray;
            this.labelScore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(63, 218);
            this.labelScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(85, 19);
            this.labelScore.TabIndex = 20;
            this.labelScore.Text = "TurnsScore";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(654, 733);
            this.Controls.Add(this.triviaControl1);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.mapControl1);
            this.Controls.Add(this.gameEndControl1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelTurns);
            this.Controls.Add(this.buttonBuySecret);
            this.Controls.Add(this.buttonBuyArrows);
            this.Controls.Add(this.labelCoins);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelArrows);
            this.Controls.Add(this.buttonMap);
            this.Controls.Add(this.buttonArrow);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonHighScores);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hunt the Wumpus";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHighScores;
        private System.Windows.Forms.PictureBox pictureBox1;
        private TriviaControl triviaControl1;
        private System.Windows.Forms.Button buttonArrow;
        private System.Windows.Forms.Button buttonMap;
        private MapControl mapControl1;
        private System.Windows.Forms.Label labelArrows;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelCoins;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonBuyArrows;
        private System.Windows.Forms.Button buttonBuySecret;
        private GameEndControl gameEndControl1;
        private System.Windows.Forms.Label labelTurns;
        private System.Windows.Forms.Label labelScore;
    }
}

