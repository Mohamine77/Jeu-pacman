﻿namespace Jeu_pacman
{
    partial class Jeu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jeu));
            pictureBox1 = new PictureBox();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1563, 882);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(748, 3);
            button2.Name = "button2";
            button2.Size = new Size(74, 70);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Symtext", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 224, 192);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(443, 18);
            label2.Name = "label2";
            label2.Size = new Size(151, 44);
            label2.TabIndex = 4;
            label2.Text = "Score :";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Symtext", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 224, 192);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(869, 18);
            label3.Name = "label3";
            label3.Size = new Size(160, 44);
            label3.TabIndex = 5;
            label3.Text = "Niveau :";
            // 
            // panel1
            // 
            panel1.Location = new Point(262, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 761);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // Jeu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 876);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Name = "Jeu";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Panel panel1;
    }
}
