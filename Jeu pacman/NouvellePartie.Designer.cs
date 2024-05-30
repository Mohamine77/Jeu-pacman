namespace Jeu_pacman
{
    partial class NouvellePartie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NouvellePartie));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1594, 853);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Cursor = Cursors.Cross;
            button1.Font = new Font("Symtext", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(255, 224, 192);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(555, 549);
            button1.Name = "button1";
            button1.Size = new Size(398, 85);
            button1.TabIndex = 1;
            button1.Text = "Jouer";
            button1.UseMnemonic = false;
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(940, 207);
            button2.Name = "button2";
            button2.Size = new Size(70, 65);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Sienna;
            label1.Font = new Font("Symtext", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 224, 192);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(575, 446);
            label1.Name = "label1";
            label1.Size = new Size(94, 29);
            label1.TabIndex = 3;
            label1.Text = "Facile";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Symtext", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 224, 192);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(700, 446);
            label2.Name = "label2";
            label2.Size = new Size(106, 29);
            label2.TabIndex = 4;
            label2.Text = "Normal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Symtext", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 224, 192);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(832, 446);
            label3.Name = "label3";
            label3.Size = new Size(121, 29);
            label3.TabIndex = 5;
            label3.Text = "Difficile";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Sienna;
            label4.Font = new Font("Symtext", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 224, 192);
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.Location = new Point(602, 191);
            label4.Name = "label4";
            label4.Size = new Size(292, 100);
            label4.TabIndex = 6;
            label4.Text = "Création de \r\n     partie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Sienna;
            label5.Font = new Font("Symtext", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 224, 192);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(621, 309);
            label5.Name = "label5";
            label5.Size = new Size(247, 29);
            label5.TabIndex = 7;
            label5.Text = "Nom de la partie :";
            // 
            // NouvellePartie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 851);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "NouvellePartie";
            Text = "NouvellePartie";
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
        private Label label4;
        private Label label5;
    }
}
