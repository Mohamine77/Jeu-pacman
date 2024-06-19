using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using ClassLibrary1;
using System.Runtime.CompilerServices;
using static ClassLibrary1.Partiee;
using System.Diagnostics;


namespace Jeu_pacman
{
    public partial class Jeu : Form

    {

        private static Random random = new Random();
        public bool humain = true;
        private int compteurseconde = 0;
        public int JoueurVie = 3;
        private const int largeur = 10; // largeur du labyrinthe
        private const int hauteur = 10; // hauteur du labyrinthe
        private static int[,] lab = new int[hauteur, largeur]; // tableau qui représente le labyrinthe
        private int joueurX = 2; // position initiale du joueur (x)
        private int joueurY = 2; // position initiale du joueur (y)
        private Bitmap joueurImage; // image du joueur
        private Graphics panel1graphics;
        private Bitmap chasseurImage; // image de l'ennemi
        private Bitmap villageoisImage;
        private const int MaxDurationMilliseconds = 3000;
        private Bitmap bucheronImage;
        private Bitmap potionImage; // image de l'ennemi
        private Potion potion = new Potion();

        string hurlementloup = "C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aou.wav";
        private Ennemi villageois;
        private Ennemi villageois2;

        private Ennemi bucheron;
        private Ennemi bucheron2;// ennemi du jeu
        private Ennemi chasseur;
        private Ennemi chasseur2;

        private Potion Potion;
        private System.Windows.Forms.Timer ennemiTimera;
        private System.Windows.Forms.Timer ennemiTimerb; // Timer pour le déplacement de l'ennemi
        private bool premierDeplacement = false; // Indicateur pour le premier déplacement du joueur
        public static bool jeuEnPause = false;
        private int timerInterval;
        public static Jeu instance;
        private bool passagelvl = false;
        private int niveau = 0;
        private int stagelevelencours = 1;
        private bool invincibilite=false;
        private bool stagereussi = false;
        private bool verifdifficultetermine = false;
        int iterationjeu = 0;
        int scorejeu = 0;
        public Jeu()
        {
            InitializeComponent();
            instance = this;
            JoueurVie = 3;
            coeur1.Parent = fond;
            coeur2.Parent = fond;
            coeur3.Parent = fond;
            compteurr.Parent = fond;

            Partiee.GenerationLab(hauteur, largeur, lab);
            Partiee.ConnectChemin(hauteur, largeur, lab);

            InitGameComponents();
            potion.Initialiser(hauteur, largeur, lab, joueurX, joueurY);



        }
       
        private void InitGameComponents()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Jeu_KeyDown);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Jeu_PreviewKeyDown);
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel1.Invalidate();

            joueurImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\humain.png");
            villageoisImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\villageois.png");
            bucheronImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\bucheron.png");
            chasseurImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\chasseur.png");
            potionImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\potion.png");
            if (NouvellePartie.difficulte == 1)
            {
                villageois = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);
                villageois2 = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);

            }
            else if ((NouvellePartie.difficulte == 2)) {
                bucheron = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);

            }
            else
            {
                bucheron2 = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);
                bucheron = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);


            }


            ennemiTimera = new System.Windows.Forms.Timer();
            ennemiTimera.Interval = 500; // Intervalle en millisecondes (500ms = 0.5s)
            ennemiTimera.Tick += new EventHandler(EnnemiTimera_Tick);
            ennemiTimerb = new System.Windows.Forms.Timer();
            ennemiTimerb.Interval = 500; // Intervalle en millisecondes (500ms = 0.5s)
            ennemiTimerb.Tick += new EventHandler(EnnemiTimerb_Tick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ennemiTimera.Stop();
            timer_JourNuit.Stop();
            this.Hide();

            Pause pause = new Pause();
            pause.Show();
        }
        private void GameOver()
        {
            Partiee.ResetPositions(ref joueurX, ref joueurY);
            this.panel1.Invalidate();



            MessageBox.Show("Game Over! le loup est mort ce soir...");
            ennemiTimera.Stop();
            ennemiTimerb .Stop();
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
    Partiee.DessinerLabyrinthe(e.Graphics, hauteur, largeur, lab, joueurImage, joueurX, joueurY);
    Partiee.DessinerPotion(e.Graphics, potion, potionImage, 20);

    if (NouvellePartie.difficulte == 1)
    {
        if (villageois != null && villageois.Visible)
        {
            Partiee.DessinerEnnemi(e.Graphics, villageois, villageoisImage);
        }

        if (stagelevelencours == 2 && villageois2 != null && villageois2.Visible)
        {
            DeplacerEnnemi(villageois2, hauteur, largeur, lab);
            Partiee.DessinerEnnemi(e.Graphics, villageois2, villageoisImage);
        }
    }
    else if (NouvellePartie.difficulte == 2)
    {
        if (bucheron != null && bucheron.Visible)
        {
            Partiee.DessinerEnnemi(e.Graphics, bucheron, bucheronImage);
        }
    }
    else
    {
        if (bucheron2 != null && bucheron2.Visible)
        {
            Partiee.DessinerEnnemi(e.Graphics, bucheron2, bucheronImage);
        }

        if (bucheron != null && bucheron.Visible)
        {
            Partiee.DessinerEnnemi(e.Graphics, bucheron, bucheronImage);
        }
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
        public void TogglePause()
        {
            jeuEnPause = !jeuEnPause;
            Pause pause = new Pause();
            if (jeuEnPause)
            {
                ennemiTimera.Stop();
                ennemiTimerb.Stop();

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
            ennemiTimera.Start();
            ennemiTimerb.Start();
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
                        if (newY - 1 >= 0 && lab[newY - 1, newX] == 0 && lab[newY, newX] == 0)
                        {
                            newY--;
                        }
                        break;
                    case Keys.Q:
                    case Keys.Left:
                        newX--; // Aller à gauche
                        if (newX - 1 >= 0 && lab[newY, newX - 1] == 0 && lab[newY, newX] == 0)
                        {
                            newX--;
                        }
                        break;
                    case Keys.S:
                    case Keys.Down:
                        newY++; // Aller en bas
                        if (newY + 1 < hauteur && lab[newY + 1, newX] == 0 && lab[newY, newX] == 0)
                        {
                            newY++;
                        }
                        break;
                    case Keys.D:
                    case Keys.Right:
                        newX++; // Aller à droite
                        if (newX + 1 < largeur && lab[newY, newX + 1] == 0 && lab[newY, newX] == 0)
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
                ennemiTimera.Start();
                ennemiTimerb.Start();
                // Démarrer le Timer au premier déplacement du joueur
            }


            Collision();
            panel1.ResumeLayout();

        }


        private void EnnemiTimera_Tick(object sender, EventArgs e)
        {
            if (!jeuEnPause&&premierDeplacement)
            {
                if (villageois != null)
                {
                    Partiee.DeplacerEnnemi(villageois, hauteur, largeur, lab);
                }

                if (chasseur != null)
                {
                    Partiee.DeplacerEnnemi(chasseur, hauteur, largeur, lab);
                    Ennemi.TirerBalle(panel1, chasseur);


                }
                if (bucheron != null)
                {
                    Partiee.DeplacerEnnemi(bucheron, hauteur, largeur, lab);


                }

                this.panel1.Invalidate(); // Redessiner le panel
                Collision();
            }

        }
        private void EnnemiTimerb_Tick(object sender, EventArgs e)
        {
            if (!jeuEnPause && premierDeplacement)
            {
                if (villageois2 != null)
                {
                    Partiee.DeplacerEnnemi(villageois2, hauteur, largeur, lab);
                }

                if (chasseur2 != null)
                {
                    Partiee.DeplacerEnnemi(chasseur2, hauteur, largeur, lab);
                    Ennemi.TirerBalle(panel1, chasseur);


                }
                if (bucheron2 != null)
                {
                    Partiee.DeplacerEnnemi(bucheron2, hauteur, largeur, lab);


                }

                this.panel1.Invalidate(); // Redessiner le panel
                Collision();
            }

        }




        private void Collision()
        {
            if (NouvellePartie.difficulte == 1)
            {
                // Vérification pour le villageois
                if (villageois != null && joueurX == villageois.X && joueurY == villageois.Y && humain)
                {
                    Partiee.Enlevervie(ref JoueurVie, coeur1, coeur2, coeur3, 1);
                    if (JoueurVie <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);
                        this.panel1.Invalidate();
                    }
                    bruitage("C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav");
                }

                // Vérification pour le deuxième villageois dans le niveau 2
                if (stagelevelencours >= 2 && villageois2 != null && joueurX == villageois2.X && joueurY == villageois2.Y && humain)
                {
                    Partiee.Enlevervie(ref JoueurVie, coeur1, coeur2, coeur3, 1);
                    if (JoueurVie <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);
                        this.panel1.Invalidate();
                    }
                    bruitage("C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav");
                }
            }
            else if (NouvellePartie.difficulte == 2)
            {
                // Vérification pour le bucheron dans le niveau 2
                if (bucheron != null && joueurX == bucheron.X && joueurY == bucheron.Y && humain)
                {
                    Partiee.Enlevervie(ref JoueurVie, coeur1, coeur2, coeur3, 2);
                    if (JoueurVie <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);
                        this.panel1.Invalidate();
                    }
                    bruitage("C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav");
                }
            }
            else // Difficulté 3
            {
                // Vérification pour le premier bucheron dans le niveau 3
                if (bucheron != null && joueurX == bucheron.X && joueurY == bucheron.Y && humain)
                {
                    Partiee.Enlevervie(ref JoueurVie, coeur1, coeur2, coeur3, 2);
                    if (JoueurVie <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);
                        this.panel1.Invalidate();
                    }
                    bruitage("C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav");
                }

                // Vérification pour le deuxième bucheron dans le niveau 3
                if (bucheron2 != null && joueurX == bucheron2.X && joueurY == bucheron2.Y && humain)
                {
                    Partiee.Enlevervie(ref JoueurVie, coeur1, coeur2, coeur3, 2);
                    if (JoueurVie <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);
                        this.panel1.Invalidate();
                    }
                    bruitage("C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav");
                }
            }

            // Vérification de réussite du niveau pour les villageois
            if (villageois != null && joueurX == villageois.X && joueurY == villageois.Y && !humain)
            {
                if (villageois2 != null)
                {
                    
                    niveaureussitverif(ref stagelevelencours, ennemiTimera, ref verifdifficultetermine, ennemiTimerb, ref villageois, ref villageois2, panel1, passagelvl, ref stagereussi, joueurX, joueurY, villageoisImage, potionImage, hauteur, largeur, lab, potion, niveau, NouvellePartie.difficulte);
                    if (verifdifficultetermine)
                    {
                        Main mainform = new Main();
                        mainform.Show();
                        this.Hide();
                    }
                }
            }
            else if (villageois2 != null && joueurX == villageois2.X && joueurY == villageois2.Y && !humain && stagelevelencours == 2)
            {
                if (villageois != null)
                {
                    niveaureussitverif(ref stagelevelencours, ennemiTimera, ref verifdifficultetermine, ennemiTimerb, ref villageois2, ref villageois, panel1, passagelvl, ref stagereussi, joueurX, joueurY, villageoisImage, potionImage, hauteur, largeur, lab, potion, niveau, NouvellePartie.difficulte);
                    if (verifdifficultetermine)
                    {
                        Main mainform = new Main();
                        mainform.Show();
                        this.Hide();
                    }
                }
            }
            else if (bucheron != null && joueurX == bucheron.X && joueurY == bucheron.Y && !humain)
            {
                if (NouvellePartie.difficulte==2)
                {
                    bucheron2 = null;
                    
                }

                niveaureussitverifalternatif(ref stagelevelencours, ennemiTimera, ref verifdifficultetermine, ennemiTimerb, ref bucheron, ref bucheron2, panel1, passagelvl, ref stagereussi, joueurX, joueurY, villageoisImage, potionImage, hauteur, largeur, lab, potion, niveau, NouvellePartie.difficulte);
                if (verifdifficultetermine)
                {
                    Main mainform = new Main();
                    mainform.Show();
                    this.Hide();
                }
            }
            else if (bucheron2 != null && joueurX == bucheron2.X && joueurY == bucheron2.Y && !humain )
            {
                if (bucheron != null)
                {
                    niveaureussitverif(ref stagelevelencours, ennemiTimerb, ref verifdifficultetermine, ennemiTimera, ref bucheron2, ref bucheron, panel1, passagelvl, ref stagereussi, joueurX, joueurY, villageoisImage, potionImage, hauteur, largeur, lab, potion, niveau, NouvellePartie.difficulte);
                    if (verifdifficultetermine)
                    {
                        Main mainform = new Main();
                        mainform.Show();
                        this.Hide();
                    }
                }
            }

        }


        private void label1_Click(object sender, EventArgs e)
            {

            }



        private void timer_JourNuit_Tick(object sender, EventArgs e)
        {
            if (premierDeplacement)
            {



                compteurseconde++; // Démarrer le Timer au premier déplacement du joueur

                if (compteurseconde >= 30)
                {

                    if (humain && JoueurVie != 0)
                    {
                        humain = false;
                        Partiee.bruitage(hurlementloup);
                        joueurImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\loup.png");

                    }
                    else
                    {
                        humain = true;
                        joueurImage = new Bitmap("C:\\Users\\jessy\\Desktop\\codegit\\images\\humain.png");

                    }
                    compteurseconde = 0;
                }

                TimeSpan timeSpan = TimeSpan.FromSeconds(compteurseconde);
                this.compteurr.Text = timeSpan.ToString(@"mm\:ss");

            }
        }

            private void button1_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }
            private void UpdatePlayerPosition(int x, int y)
            {
                Balle.joueurX = x;
                Balle.joueurY = y;
            }

            private void Jeu_FormClosing(object sender, FormClosingEventArgs e)
            {

                this.Close();
            }

            private void pictureBox3_Click(object sender, EventArgs e)
            {

            }
        }

    }

