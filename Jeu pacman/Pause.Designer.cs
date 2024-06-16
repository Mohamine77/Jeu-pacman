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
            lblnompartie = new Label();
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
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1601, 879);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(748, 11);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(65, 63);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 224, 192);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(437, 30);
            label2.Name = "label2";
            label2.Size = new Size(89, 29);
            label2.TabIndex = 4;
            label2.Text = "Score :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 224, 192);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(867, 30);
            label3.Name = "label3";
            label3.Size = new Size(100, 29);
            label3.TabIndex = 5;
            label3.Text = "Niveau :";
            // 
            // lblnompartie
            // 
            lblnompartie.AutoSize = true;
            lblnompartie.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblnompartie.ForeColor = Color.FromArgb(255, 224, 192);
            lblnompartie.Image = (Image)resources.GetObject("lblnompartie.Image");
            lblnompartie.Location = new Point(658, 150);
            lblnompartie.Name = "lblnompartie";
            lblnompartie.Size = new Size(154, 36);
            lblnompartie.TabIndex = 6;
            lblnompartie.Text = "NomPartie";
            lblnompartie.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 224, 192);
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.Location = new Point(658, 285);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 7;
            label4.Text = "Meilleure score :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 224, 192);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(658, 384);
            label5.Name = "label5";
            label5.Size = new Size(165, 25);
            label5.TabIndex = 8;
            label5.Text = "Meilleure niveau :";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(255, 224, 192);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(625, 482);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(312, 66);
            button1.TabIndex = 9;
            button1.Text = "Paramètre";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(255, 224, 192);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(625, 592);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(312, 66);
            button3.TabIndex = 10;
            button3.Text = "Sauvegarder";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(255, 224, 192);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(625, 701);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(312, 66);
            button4.TabIndex = 11;
            button4.Text = "Menu principal";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Pause
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 854);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblnompartie);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Label lblnompartie;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button3;
        private Button button4;
    }
}
