namespace Jeu_pacman
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pictureBox1 = new PictureBox();
            bntQuitter = new Button();
            btnParametres = new Button();
            btnContinuer = new Button();
            btnNouvellePartie = new Button();
            lblMeilleure = new Label();
            lblScore = new Label();
            lblNiveau = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1592, 887);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // bntQuitter
            // 
            bntQuitter.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bntQuitter.ForeColor = Color.FromArgb(255, 224, 192);
            bntQuitter.Image = (Image)resources.GetObject("bntQuitter.Image");
            bntQuitter.Location = new Point(103, 640);
            bntQuitter.Name = "bntQuitter";
            bntQuitter.Size = new Size(334, 92);
            bntQuitter.TabIndex = 9;
            bntQuitter.Text = "Quitter";
            bntQuitter.UseVisualStyleBackColor = true;
            bntQuitter.Click += button4_Click;
            // 
            // btnParametres
            // 
            btnParametres.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnParametres.ForeColor = Color.FromArgb(255, 224, 192);
            btnParametres.Image = (Image)resources.GetObject("btnParametres.Image");
            btnParametres.Location = new Point(103, 520);
            btnParametres.Name = "btnParametres";
            btnParametres.Size = new Size(334, 92);
            btnParametres.TabIndex = 8;
            btnParametres.Text = "Paramètres";
            btnParametres.UseVisualStyleBackColor = true;
            btnParametres.Click += button3_Click;
            // 
            // btnContinuer
            // 
            btnContinuer.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContinuer.ForeColor = Color.FromArgb(255, 224, 192);
            btnContinuer.Image = (Image)resources.GetObject("btnContinuer.Image");
            btnContinuer.Location = new Point(103, 400);
            btnContinuer.Name = "btnContinuer";
            btnContinuer.Size = new Size(334, 92);
            btnContinuer.TabIndex = 7;
            btnContinuer.Text = "Continuer";
            btnContinuer.UseVisualStyleBackColor = true;
            btnContinuer.Click += button2_Click;
            // 
            // btnNouvellePartie
            // 
            btnNouvellePartie.BackColor = Color.FromArgb(192, 64, 0);
            btnNouvellePartie.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNouvellePartie.ForeColor = Color.FromArgb(255, 224, 192);
            btnNouvellePartie.Image = (Image)resources.GetObject("btnNouvellePartie.Image");
            btnNouvellePartie.Location = new Point(103, 279);
            btnNouvellePartie.Name = "btnNouvellePartie";
            btnNouvellePartie.Size = new Size(334, 91);
            btnNouvellePartie.TabIndex = 6;
            btnNouvellePartie.Text = "Nouvelle Partie";
            btnNouvellePartie.UseVisualStyleBackColor = false;
            btnNouvellePartie.Click += button1_Click;
            // 
            // lblMeilleure
            // 
            lblMeilleure.AutoSize = true;
            lblMeilleure.BackColor = Color.Sienna;
            lblMeilleure.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMeilleure.ForeColor = Color.FromArgb(255, 255, 192);
            lblMeilleure.Image = (Image)resources.GetObject("lblMeilleure.Image");
            lblMeilleure.Location = new Point(1150, 63);
            lblMeilleure.Name = "lblMeilleure";
            lblMeilleure.Size = new Size(228, 32);
            lblMeilleure.TabIndex = 10;
            lblMeilleure.Text = "Meilleure Partie :";
            lblMeilleure.Click += label1_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Sienna;
            lblScore.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.FromArgb(255, 255, 192);
            lblScore.Image = (Image)resources.GetObject("lblScore.Image");
            lblScore.Location = new Point(1150, 137);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(103, 32);
            lblScore.TabIndex = 11;
            lblScore.Text = "Score :";
            lblScore.Click += label2_Click;
            // 
            // lblNiveau
            // 
            lblNiveau.AutoSize = true;
            lblNiveau.BackColor = Color.Sienna;
            lblNiveau.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNiveau.ForeColor = Color.FromArgb(255, 255, 192);
            lblNiveau.Image = (Image)resources.GetObject("lblNiveau.Image");
            lblNiveau.Location = new Point(1150, 208);
            lblNiveau.Name = "lblNiveau";
            lblNiveau.Size = new Size(118, 32);
            lblNiveau.TabIndex = 12;
            lblNiveau.Text = "Niveau :";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1590, 878);
            Controls.Add(lblNiveau);
            Controls.Add(lblScore);
            Controls.Add(lblMeilleure);
            Controls.Add(bntQuitter);
            Controls.Add(btnParametres);
            Controls.Add(btnContinuer);
            Controls.Add(btnNouvellePartie);
            Controls.Add(pictureBox1);
            Name = "Main";
            Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button bntQuitter;
        private Button btnParametres;
        private Button btnContinuer;
        private Button btnNouvellePartie;
        private Label lblMeilleure;
        private Label lblScore;
        private Label lblNiveau;
    }
}
