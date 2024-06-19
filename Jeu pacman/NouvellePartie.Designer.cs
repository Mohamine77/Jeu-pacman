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
            fondnouvellepartie = new PictureBox();
            btnjouer = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtb_Nompartie = new TextBox();
            chkfacile = new CheckBox();
            chknormal = new CheckBox();
            chkdifficile = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)fondnouvellepartie).BeginInit();
            SuspendLayout();
            // 
            // fondnouvellepartie
            // 
            fondnouvellepartie.Image = (Image)resources.GetObject("fondnouvellepartie.Image");
            fondnouvellepartie.Location = new Point(-1, 0);
            fondnouvellepartie.Margin = new Padding(3, 2, 3, 2);
            fondnouvellepartie.Name = "fondnouvellepartie";
            fondnouvellepartie.Size = new Size(1476, 790);
            fondnouvellepartie.TabIndex = 0;
            fondnouvellepartie.TabStop = false;
            fondnouvellepartie.Click += pictureBox1_Click;
            // 
            // btnjouer
            // 
            btnjouer.BackColor = Color.Transparent;
            btnjouer.Cursor = Cursors.Cross;
            btnjouer.FlatStyle = FlatStyle.Popup;
            btnjouer.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnjouer.ForeColor = Color.FromArgb(255, 224, 192);
            btnjouer.Image = (Image)resources.GetObject("btnjouer.Image");
            btnjouer.Location = new Point(561, 561);
            btnjouer.Margin = new Padding(3, 2, 3, 2);
            btnjouer.Name = "btnjouer";
            btnjouer.Size = new Size(384, 59);
            btnjouer.TabIndex = 1;
            btnjouer.Text = "Jouer";
            btnjouer.UseMnemonic = false;
            btnjouer.UseVisualStyleBackColor = false;
            btnjouer.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(944, 218);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(64, 49);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Sienna;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 224, 192);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(537, 497);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 3;
            label1.Text = "Facile";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 224, 192);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(670, 497);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 4;
            label2.Text = "Normal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 224, 192);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(808, 497);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 5;
            label3.Text = "Difficile";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Sienna;
            label4.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 224, 192);
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.Location = new Point(657, 222);
            label4.Name = "label4";
            label4.Size = new Size(161, 62);
            label4.TabIndex = 6;
            label4.Text = "Création de \r\n     partie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Sienna;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(255, 224, 192);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(486, 314);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 7;
            label5.Text = "Nom de la partie :";
            // 
            // txtb_Nompartie
            // 
            txtb_Nompartie.BackColor = SystemColors.InactiveCaptionText;
            txtb_Nompartie.BorderStyle = BorderStyle.None;
            txtb_Nompartie.Font = new Font("SimSun-ExtB", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtb_Nompartie.ForeColor = Color.IndianRed;
            txtb_Nompartie.Location = new Point(598, 371);
            txtb_Nompartie.Name = "txtb_Nompartie";
            txtb_Nompartie.Size = new Size(321, 27);
            txtb_Nompartie.TabIndex = 8;
            txtb_Nompartie.TextChanged += textBox1_TextChanged;
            // 
            // chkfacile
            // 
            chkfacile.AutoSize = true;
            chkfacile.BackColor = Color.Transparent;
            chkfacile.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkfacile.Location = new Point(617, 499);
            chkfacile.Name = "chkfacile";
            chkfacile.Size = new Size(15, 14);
            chkfacile.TabIndex = 9;
            chkfacile.UseVisualStyleBackColor = false;
            chkfacile.CheckedChanged += chkfacile_CheckedChanged;
            // 
            // chknormal
            // 
            chknormal.AutoSize = true;
            chknormal.BackColor = Color.Transparent;
            chknormal.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chknormal.Location = new Point(746, 497);
            chknormal.Name = "chknormal";
            chknormal.Size = new Size(15, 14);
            chknormal.TabIndex = 10;
            chknormal.UseVisualStyleBackColor = false;
            // 
            // chkdifficile
            // 
            chkdifficile.AutoSize = true;
            chkdifficile.BackColor = Color.Transparent;
            chkdifficile.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkdifficile.Location = new Point(885, 497);
            chkdifficile.Name = "chkdifficile";
            chkdifficile.Size = new Size(15, 14);
            chkdifficile.TabIndex = 11;
            chkdifficile.UseVisualStyleBackColor = false;
            // 
            // NouvellePartie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1473, 790);
            Controls.Add(chkdifficile);
            Controls.Add(chknormal);
            Controls.Add(chkfacile);
            Controls.Add(txtb_Nompartie);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(btnjouer);
            Controls.Add(fondnouvellepartie);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NouvellePartie";
            Text = "NouvellePartie";
            FormClosed += NouvellePartie_FormClosed;
            ((System.ComponentModel.ISupportInitialize)fondnouvellepartie).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox fondnouvellepartie;
        private Button btnjouer;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtb_Nompartie;
        private CheckBox chkfacile;
        private CheckBox chknormal;
        private CheckBox chkdifficile;
    }
}
