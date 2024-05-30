namespace Jeu_pacman
{
    partial class Pause
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pause));
            pictureBox1 = new PictureBox();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            button2.Location = new Point(743, 9);
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
            label2.Location = new Point(443, 21);
            label2.Name = "label2";
            label2.Size = new Size(151, 44);
            label2.TabIndex = 4;
            label2.Text = "Score :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Symtext", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 224, 192);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(869, 21);
            label3.Name = "label3";
            label3.Size = new Size(160, 44);
            label3.TabIndex = 5;
            label3.Text = "Niveau :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Symtext", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 224, 192);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(630, 168);
            label1.Name = "label1";
            label1.Size = new Size(320, 54);
            label1.TabIndex = 6;
            label1.Text = "Sauvegarder";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Symtext", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 224, 192);
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.Location = new Point(549, 275);
            label4.Name = "label4";
            label4.Size = new Size(289, 36);
            label4.TabIndex = 7;
            label4.Text = "Meilleure score :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Symtext", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 224, 192);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(549, 381);
            label5.Name = "label5";
            label5.Size = new Size(296, 36);
            label5.TabIndex = 8;
            label5.Text = "Meilleure niveau :";
            // 
            // button1
            // 
            button1.Font = new Font("Symtext", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(255, 224, 192);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(604, 471);
            button1.Name = "button1";
            button1.Size = new Size(357, 88);
            button1.TabIndex = 9;
            button1.Text = "Paramètre";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Symtext", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(255, 224, 192);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(604, 579);
            button3.Name = "button3";
            button3.Size = new Size(357, 88);
            button3.TabIndex = 10;
            button3.Text = "Sauvegarder";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Symtext", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(255, 224, 192);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(604, 687);
            button4.Name = "button4";
            button4.Size = new Size(357, 88);
            button4.TabIndex = 11;
            button4.Text = "Menu principal";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Pause
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 876);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Name = "Pause";
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
        private Label label1;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button3;
        private Button button4;
    }
}
