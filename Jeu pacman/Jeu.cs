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
        private const int largeur = 40; // largeur du labyrinthe
        private const int hauteur = 30; // hauteur du labyrinthe
        private static int[,] lab = new int[hauteur, largeur]; // tableau qui représente le labyrinthe
        private int joueurX = 2; // position initiale du joueur (x)
        private int joueurY = 2; // position initiale du joueur (y)
        private Bitmap joueurImage; // image du joueur
        private Bitmap ennemiImage; // image de l'ennemi
        private Bitmap potionImage; // image de l'ennemi
        private Potion potion = new Potion();
        
        string hurlementloup = "C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\Jeu pacman\\bin\\Debug\\aou.wav";
        private Ennemi ennemi; // ennemi du jeu
        private Ennemi shooter;
        private Potion Potion;
        private System.Windows.Forms.Timer ennemiTimer; // Timer pour le déplacement de l'ennemi
        private bool premierDeplacement = false; // Indicateur pour le premier déplacement du joueur
        public static bool jeuEnPause = false; 
        private int timerInterval;
        public static Jeu instance;
        public Jeu()
        {
            InitializeComponent();
            instance = this;
            JoueurVie = 3;

            Partiee.GenerationLab(hauteur, largeur, lab);
            Partiee.ConnectChemin(hauteur,largeur,lab);

            InitGameComponents();
            potion.Initialiser(hauteur, largeur, lab, joueurX, joueurY);

            pictureBox3.Parent = pictureBox1;
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
            potionImage = new Bitmap("C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\images\\potion.png");
            ennemi = new Ennemi(random.Next(largeur - 1), random.Next(hauteur), 1.0);
            shooter = new Ennemi(random.Next(largeur), random.Next(hauteur), 1.0);

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
            ennemiTimer.Stop();
            timer_JourNuit.Stop();
            this.Hide();

            Pause pause = new Pause();
            pause.Show();
        }
        private void GameOver()
        {
            Partiee.ResetPositions(ref joueurX,ref joueurY);
            this.panel1.Invalidate();



            MessageBox.Show("Game Over! le loup est mort ce soir...");
            ennemiTimer.Stop();
            Main mainform = new Main();

            mainform.Show();
            this.Hide();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.Focus();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Partiee.DessinerLabyrinthe(e.Graphics,hauteur,largeur,lab,joueurImage,joueurX,joueurY);
            Partiee.DessinerPotion(e.Graphics, potion, potionImage, 20);
            Partiee.DessinerEnnemi(e.Graphics,ennemi,ennemiImage);



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
        public void TogglePause()
        {
            jeuEnPause = !jeuEnPause;
            Pause pause = new Pause();
            if (jeuEnPause)
            {
                ennemiTimer.Stop();
                timer_JourNuit.Stop();
                this.Hide();

                pause.Show();
               
            

            }
            else
            {
                Reprendre();
                Pause.instancepause.Close();

            }

            panel1.Invalidate(); // Redessiner le panel pour afficher/marquer la pause
        }
        public void Reprendre()
        {
            jeuEnPause = false;
            ennemiTimer.Start();
            timer_JourNuit.Start();
            this.Show();
        }

        private void Jeu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TogglePause();
                return;
            }

            if (jeuEnPause)
            {
                return; // Ne pas traiter d'autres touches si le jeu est en pause
            }
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
            if (!jeuEnPause)
            {
                Partiee.DeplacerEnnemi(ennemi, hauteur, largeur, lab);
                this.panel1.Invalidate(); // Redessiner le panel
                Collision();
            }

        }

       

        private void Collision()
        {
            if (ennemi != null)
                if (joueurX == ennemi.X && joueurY == ennemi.Y && humain == true)
                {
                    JoueurVie--;
                    pictureBox2.Visible = false;

                    SoundPlayer degats = new SoundPlayer();
                    degats.SoundLocation = "C:\\Users\\jessy\\OneDrive\\Bureau\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav";
                    degats.Play();
                    if (JoueurVie <= 0)
                    {

                        GameOver();

                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX,ref joueurY);

                        this.panel1.Invalidate();

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
     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer_JourNuit_Tick(object sender, EventArgs e)
        {
            compteurseconde++;

            if (compteurseconde >= 30)
            {

                if (humain&&JoueurVie!=0)
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
