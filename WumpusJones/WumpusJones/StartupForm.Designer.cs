﻿
namespace WumpusJones
{
    partial class StartupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wumpus Jones";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WumpusJones.Properties.Resource1.indiana_jones_raiders_lost_ark_1024x503;
            this.pictureBox1.Location = new System.Drawing.Point(112, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(696, 339);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.Black;
            this.textBoxName.ForeColor = System.Drawing.Color.White;
            this.textBoxName.Location = new System.Drawing.Point(165, 509);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(274, 27);
            this.textBoxName.TabIndex = 2;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.ForeColor = System.Drawing.Color.Black;
            this.buttonStart.Location = new System.Drawing.Point(485, 503);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(181, 39);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(898, 574);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Orange;
            this.Name = "StartupForm";
            this.Text = "StartupForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
    }
}