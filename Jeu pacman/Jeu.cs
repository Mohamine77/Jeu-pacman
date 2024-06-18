using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using ClassLibrary1;
using System.Runtime.CompilerServices;
using static ClassLibrary1.Partiee;


namespace Jeu_pacman
{
    public partial class Jeu : Form

    {

        private static Random random = new Random();
        public bool humain = true;
        private int compteurseconde = 0;
        private int JoueurVie = 3;
        private const int largeur = 21; // largeur du labyrinthe
        private const int hauteur = 18; // hauteur du labyrinthe
        private static int[,] lab = new int[hauteur, largeur]; // tableau qui représente le labyrinthe
        private int joueurX = 2; // position initiale du joueur (x)
        private int joueurY = 2; // position initiale du joueur (y)
        private Bitmap joueurImage; // image du joueur
        private Bitmap chasseurImage; // image de l'ennemi
        private Bitmap villageoisImage;
        private Bitmap bucheronImage;
        private Bitmap potionImage; // image de l'ennemi
        private Potion potion = new Potion();
       
        string hurlementloup = "C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aou.wav";
        private Ennemi villageois;
        private Ennemi bucheron;                         // ennemi du jeu
        private Ennemi chasseur;
        private Potion Potion;
        private System.Windows.Forms.Timer ennemiTimer; // Timer pour le déplacement de l'ennemi
        private bool premierDeplacement = false; // Indicateur pour le premier déplacement du joueur
        public static bool jeuEnPause = false;
        private int timerInterval;
        public static Jeu instance;
        private bool passagelvl = false;
        private int niveau = 0;
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
            } else if ((NouvellePartie.difficulte == 2)){
                villageois = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);
                bucheron = Partiee.GenererEnnemiValide(hauteur,largeur, lab, passagelvl);  
            }
            else
            {
                villageois = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);
                chasseur = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);
                bucheron = Partiee.GenererEnnemiValide(hauteur, largeur, lab, passagelvl);


            }


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
            Partiee.ResetPositions(ref joueurX, ref joueurY);
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

            Partiee.DessinerLabyrinthe(e.Graphics, hauteur, largeur, lab, joueurImage, joueurX, joueurY);
            Partiee.DessinerPotion(e.Graphics, potion, potionImage, 20);
            if (NouvellePartie.difficulte == 1)
            {
                Partiee.DessinerEnnemi(e.Graphics, villageois, villageoisImage);
            }
            else if (NouvellePartie.difficulte == 2)
            {
                Partiee.DessinerEnnemi(e.Graphics, bucheron, bucheronImage);
                Partiee.DessinerEnnemi(e.Graphics, villageois, villageoisImage);


            }
            else
            {

                Partiee.DessinerEnnemi(e.Graphics,chasseur, chasseurImage);
                Partiee.DessinerEnnemi(e.Graphics, villageois, villageoisImage);
                Partiee.DessinerEnnemi(e.Graphics, bucheron, bucheronImage);


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
                ennemiTimer.Start(); // Démarrer le Timer au premier déplacement du joueur
            }


            Collision();
            panel1.ResumeLayout();

        }


        private void EnnemiTimer_Tick(object sender, EventArgs e)
        {
            if (!jeuEnPause)
            {
                if (villageois != null)
                {
                    Partiee.DeplacerEnnemi(villageois, hauteur, largeur, lab);
                }

                if (chasseur != null)
                {
                    Partiee.DeplacerEnnemi(chasseur, hauteur, largeur, lab);
                }
                if(bucheron != null)
                {
                    Partiee.DeplacerEnnemi(bucheron, hauteur, largeur, lab);

                }

                this.panel1.Invalidate(); // Redessiner le panel
                Collision();
            }

        }



        private void Collision()
        {
            // Vérifiez si les ennemis sont null avant de vérifier leurs coordonnées
            if ((villageois != null && joueurX == villageois.X && joueurY == villageois.Y) ||
                (bucheron != null && joueurX == bucheron.X && joueurY == bucheron.Y) ||
                (chasseur != null && joueurX == chasseur.X && joueurY == chasseur.Y))
            {
                if (humain)
                {
                    JoueurVie--;
                    if (JoueurVie == 2)
                    {
                        coeur3.Visible = false;
                    }
                    else if (JoueurVie == 1)
                    {
                        coeur2.Visible = false;
                    }
                    else if (JoueurVie == 0)
                    {
                        coeur1.Visible = false;
                    }

                    SoundPlayer degats = new SoundPlayer();
                    degats.SoundLocation = "C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav";
                    degats.Play();

                    if (JoueurVie <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);
                        this.panel1.Invalidate();
                    }
                }
                else if (villageois != null && joueurX == villageois.X && joueurY == villageois.Y)
                {
                    ennemiTimer.Stop();
                    villageois = null;
                    panel1.Invalidate();
                    MessageBox.Show("Le loup a visiblement frappé ce soir");
                    passagelvl = true;
                    Partiee.Nextlvl(joueurImage, potionImage, hauteur, largeur, lab, joueurX, joueurY, potion, ref villageois, ref chasseur, ennemiTimer, panel1, passagelvl, ref niveau);
                }
            }
        }
        private void MAJcoeur()
        {
            if (JoueurVie == 2)
            {
                coeur3.Visible = false;
            }
            else if (JoueurVie == 1)
            {
                coeur2.Visible = false;
            }
            else if (JoueurVie == 0)
            {
                coeur1.Visible = false;
            }
        }

        private void collisionhumain()
        {
            JoueurVie--;
            MAJcoeur();
            bruitage("C:\\Users\\jessy\\Desktop\\codegit\\Jeu pacman\\bin\\Debug\\aie.wav");
            if (JoueurVie <= 0)
            {
                GameOver();
            }
            else
            {
                Partiee.ResetPositions(ref joueurX, ref joueurY);
                this.panel1.Invalidate();
            }
        }
        private void collisionloup()
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer_JourNuit_Tick(object sender, EventArgs e)
        {
            compteurseconde++;

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }


}
