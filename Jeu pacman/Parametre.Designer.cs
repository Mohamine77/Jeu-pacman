namespace Jeu_pacman
{
    partial class Paramètres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paramètres));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1454, 758);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(255, 224, 192);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(596, 532);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(319, 64);
            button1.TabIndex = 1;
            button1.Text = "Enregistrer";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(944, 223);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(56, 46);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Sienna;
            label1.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 224, 192);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(509, 233);
            label1.Name = "label1";
            label1.Size = new Size(165, 36);
            label1.TabIndex = 3;
            label1.Text = "Paramètres";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 224, 192);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(509, 327);
            label2.Name = "label2";
            label2.Size = new Size(107, 29);
            label2.TabIndex = 4;
            label2.Text = "Volume :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 224, 192);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(509, 423);
            label3.Name = "label3";
            label3.Size = new Size(105, 29);
            label3.TabIndex = 5;
            label3.Text = "Langue :";
            // 
            // Paramètres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1454, 753);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Paramètres";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
