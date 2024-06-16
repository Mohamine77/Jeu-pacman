using System.Reflection;

namespace Jeu_pacman
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jeu));
            fond = new PictureBox();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            typeof(Panel).InvokeMember("DoubleBuffered",
    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
    null, panel1, new object[] { true });
            coeur1 = new PictureBox();
            coeur2 = new PictureBox();
            coeur3 = new PictureBox();
            compteurr = new Label();
            timer_JourNuit = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)fond).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coeur1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coeur2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coeur3).BeginInit();
            SuspendLayout();
            // 
            // fond
            // 
            fond.Image = (Image)resources.GetObject("fond.Image");
            fond.Location = new Point(0, -2);
            fond.Margin = new Padding(3, 2, 3, 2);
            fond.Name = "fond";
            fond.Size = new Size(1436, 783);
            fond.TabIndex = 0;
            fond.TabStop = false;
            fond.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(751, 13);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(64, 53);
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
            label2.Location = new Point(443, 26);
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
            label3.Location = new Point(872, 26);
            label3.Name = "label3";
            label3.Size = new Size(100, 29);
            label3.TabIndex = 5;
            label3.Text = "Niveau :";
            // 
            // panel1
            // 
            panel1.Location = new Point(269, 98);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1033, 683);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // coeur1
            // 
            coeur1.BackColor = Color.Transparent;
            coeur1.BackgroundImageLayout = ImageLayout.None;
            coeur1.Image = (Image)resources.GetObject("coeur1.Image");
            coeur1.Location = new Point(92, 13);
            coeur1.Margin = new Padding(3, 2, 3, 2);
            coeur1.Name = "coeur1";
            coeur1.Size = new Size(85, 67);
            coeur1.TabIndex = 8;
            coeur1.TabStop = false;
            coeur1.Click += pictureBox3_Click;
            // 
            // coeur2
            // 
            coeur2.BackColor = Color.Transparent;
            coeur2.Image = (Image)resources.GetObject("coeur2.Image");
            coeur2.Location = new Point(50, 78);
            coeur2.Margin = new Padding(3, 2, 3, 2);
            coeur2.Name = "coeur2";
            coeur2.Size = new Size(85, 67);
            coeur2.SizeMode = PictureBoxSizeMode.CenterImage;
            coeur2.TabIndex = 9;
            coeur2.TabStop = false;
            // 
            // coeur3
            // 
            coeur3.BackColor = Color.Transparent;
            coeur3.Image = (Image)resources.GetObject("coeur3.Image");
            coeur3.Location = new Point(10, 13);
            coeur3.Margin = new Padding(3, 2, 3, 2);
            coeur3.Name = "coeur3";
            coeur3.Size = new Size(85, 67);
            coeur3.TabIndex = 7;
            coeur3.TabStop = false;
            // 
            // compteurr
            // 
            compteurr.AutoSize = true;
            compteurr.BackColor = Color.Transparent;
            compteurr.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            compteurr.Location = new Point(32, 147);
            compteurr.Margin = new Padding(2, 0, 2, 0);
            compteurr.MinimumSize = new Size(111, 47);
            compteurr.Name = "compteurr";
            compteurr.Size = new Size(111, 47);
            compteurr.TabIndex = 0;
            compteurr.Text = "00:00";
            // 
            // timer_JourNuit
            // 
            timer_JourNuit.Enabled = true;
            timer_JourNuit.Interval = 1000;
            timer_JourNuit.Tick += timer_JourNuit_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Jeu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1429, 773);
            Controls.Add(compteurr);
            Controls.Add(coeur2);
            Controls.Add(coeur1);
            Controls.Add(coeur3);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(fond);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Jeu";
            Text = "Form1";
            FormClosing += Jeu_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)fond).EndInit();
            ((System.ComponentModel.ISupportInitialize)coeur1).EndInit();
            ((System.ComponentModel.ISupportInitialize)coeur2).EndInit();
            ((System.ComponentModel.ISupportInitialize)coeur3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox fond;
        private Button button2;
        private Label label2;
        private Label label3;
        public Panel panel1;

        private PictureBox coeur1;
        private PictureBox coeur2;
        private PictureBox coeur3;
        private Label compteurr;
        private System.Windows.Forms.Timer timer_JourNuit;
        private ContextMenuStrip contextMenuStrip1;
    }
}
