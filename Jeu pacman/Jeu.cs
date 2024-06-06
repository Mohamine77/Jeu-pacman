using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using ClassLibrary1;
using System.Runtime.CompilerServices;

namespace Jeu_pacman
{
    public partial class Jeu : Form

    {
        
        private static Random random = new Random();
        public bool humain = true;
        private int compteurseconde = 0;
        private int JoueurVie = 3;
        private const int largeur = 57; // largeur du labyrinthe
        private const int hauteur = 34; // hauteur du labyrinthe
        private static int[,] lab = new int[hauteur, largeur]; // tableau qui représente le labyrinthe
        private int joueurX = 2; // position initiale du joueur (x)
        private int joueurY = 2; // position initiale du joueur (y)
        private Bitmap joueurImage; // image du joueur
        private Bitmap ennemiImage; // image de l'ennemi
        string hurlementloup = "C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\Jeu pacman\\bin\\Debug\\aou.wav";
        private Ennemi ennemi; // ennemi du jeu
        private System.Windows.Forms.Timer ennemiTimer; // Timer pour le déplacement de l'ennemi
        private bool premierDeplacement = false; // Indicateur pour le premier déplacement du joueur
        int[,] lob;
        public Jeu()
        {
            InitializeComponent();
            Partiee.GenerationLab(hauteur, largeur, lab);
            Partiee.ConnectChemin(hauteur,largeur,lab);
            InitGameComponents();
        }

        private void InitGameComponents()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Jeu_KeyDown);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Jeu_PreviewKeyDown);
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel1.Invalidate();

            joueurImage = new Bitmap("C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\images\\humain.png");
            ennemiImage = new Bitmap("C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\images\\ennemi.png");
            ennemi = new Ennemi(random.Next(largeur - 1), random.Next(hauteur), 1.0);

            ennemiTimer = new System.Windows.Forms.Timer();
            ennemiTimer.Interval = 500; // Intervalle en millisecondes (500ms = 0.5s)
            ennemiTimer.Tick += new EventHandler(EnnemiTimer_Tick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mainForm = new Main();
            mainForm.Show();
        }
        private void GameOver()
        {
            ResetPositions();

            MessageBox.Show("Game Over! You've lost all your lives.");
            ennemiTimer.Stop();
            Main mainform = new Main();

            mainform.Show();
            JoueurVie = 3;
            this.Hide();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.Focus();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            DessinerLabyrinthe(e.Graphics);
         
            DessinerEnnemi(e.Graphics);
           
        }

        private void DessinerLabyrinthe(Graphics graphics)
        {
            const int cellSize = 20; // taille de chaque cellule du labyrinthe
            Brush murBrush = Brushes.Black;
            Brush cheminBrush = Brushes.White;

            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    Brush brush = (lab[y, x] == 1) ? murBrush : cheminBrush;
                    graphics.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }

            graphics.DrawImage(joueurImage, joueurX * cellSize, joueurY * cellSize, cellSize, cellSize);
        }

        private void DessinerEnnemi(Graphics graphics)
        {
            if (ennemi != null)
            {
                const int cellSize = 20; // taille de chaque cellule du labyrinthe
                graphics.DrawImage(ennemiImage, ennemi.X * cellSize, ennemi.Y * cellSize, cellSize, cellSize);
            }
        }

        private void Jeu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        

        private void Jeu_KeyDown(object sender, KeyEventArgs e)
        {
            int newX = joueurX;
            int newY = joueurY;
            if (humain == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                    case Keys.Up:
                        newY = newY - 1; // Aller en haut
                        break;
                    case Keys.Q:
                    case Keys.Left:
                        newX--; // Aller à gauche
                        break;
                    case Keys.S:
                    case Keys.Down:
                        newY++; // Aller en bas
                        break;
                    case Keys.D:
                    case Keys.Right:
                        newX++; // Aller à droite
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                    case Keys.Up:
                        newY--; // Aller en haut
                        if (lab[newY - 1, newX] == 0 && lab[newY, newX] == 0)
                        {
                            newY--;
                        }
                        break;
                    case Keys.Q:
                    case Keys.Left:
                        newX--; // Aller à gauche
                        if (lab[newY, newX - 1] == 0 && lab[newY, newX] == 0)
                        {
                            newX--;
                        }
                        break;
                    case Keys.S:
                    case Keys.Down:
                        newY++; // Aller en bas
                        if (lab[newY + 1, newX] == 0 && lab[newY, newX] == 0)
                        {
                            newY++;
                        }
                        break;
                    case Keys.D:
                    case Keys.Right:
                        newX++; // Aller à droite
                        if (lab[newY, newX + 1] == 0 && lab[newY, newX] == 0)
                        {
                            newX++;
                        }
                        break;
                }

            }

            if (newX >= 0 && newX < largeur && newY >= 0 && newY < hauteur && lab[newY, newX] == 0)
            {
                joueurX = newX;
                joueurY = newY;
                panel1.SuspendLayout();
                this.panel1.Invalidate(); // Redessiner le panel
            }
            if (!premierDeplacement)
            {
                premierDeplacement = true;
                ennemiTimer.Start(); // Démarrer le Timer au premier déplacement du joueur
            }


            Collision();
            panel1.ResumeLayout();

        }

        private void EnnemiTimer_Tick(object sender, EventArgs e)
        {
            Partiee.DeplacerEnnemi(ennemi,hauteur,largeur,lab);
            this.panel1.Invalidate(); // Redessiner le panel
            Collision();


        }

       

        private void Collision()
        {
            if (ennemi != null)
                if (joueurX == ennemi.X && joueurY == ennemi.Y && humain == true)
                {
                    JoueurVie--;
                    SoundPlayer degats = new SoundPlayer();
                    degats.SoundLocation = "C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav";
                    degats.Play();
                    if (JoueurVie <= 0)
                    {

                        GameOver();

                    }
                    else
                    {
                        ResetPositions();
                    }
                }
                else if (joueurX == ennemi.X && joueurY == ennemi.Y && !humain)
                {
                    ennemiTimer.Stop();
                    ennemi = null;
                    panel1.Invalidate();
                    MessageBox.Show("Le loup a visiblement frappé ce soir");


                }
        }
        private void ResetPositions()
        {

            joueurX = 2;
            joueurY = 2;
            this.panel1.Invalidate();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer_JourNuit_Tick(object sender, EventArgs e)
        {
            compteurseconde++;

            if (compteurseconde >= 30)
            {

                if (humain)
                {
                    humain = false;
                    Partiee.bruitage(hurlementloup);
                    joueurImage = new Bitmap("C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\images\\loup.png");

                }
                else
                {
                    humain = true;
                    joueurImage = new Bitmap("C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\images\\humain.png");

                }
                compteurseconde = 0;
            }

            TimeSpan timeSpan = TimeSpan.FromSeconds(compteurseconde);
            this.compteurr.Text = timeSpan.ToString(@"mm\:ss");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Jeu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }

    
}
