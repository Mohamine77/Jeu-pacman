using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jeu_pacman
{
    public partial class Jeu : Form
    {
        private static Random random = new Random();
        private const int largeur = 52; // largeur du labyrinthe
        private const int hauteur = 38; // hauteur du labyrinthe
        private static int[,] lab = new int[hauteur, largeur]; // tableau qui représente le labyrinthe
        private int joueurX = 2; // position initiale du joueur (x)
        private int joueurY = 2; // position initiale du joueur (y)
        private Bitmap joueurImage; // image du joueur
        private Bitmap ennemiImage; // image de l'ennemi
        private Ennemi ennemi; // ennemi du jeu
        private System.Windows.Forms.Timer ennemiTimer; // Timer pour le déplacement de l'ennemi
        private bool premierDeplacement = false; // Indicateur pour le premier déplacement du joueur

        public Jeu()
        {
            InitializeComponent();
            GenerationLab();
            ConnectChemin();
            InitGameComponents();
        }

        private void InitGameComponents()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Jeu_KeyDown);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Jeu_PreviewKeyDown);
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel1.Invalidate();

            joueurImage = new Bitmap("C:\\Users\\Amine\\Desktop\\Jeu-pacman-master\\images\\jeu.png");
            ennemiImage = new Bitmap("C:\\Users\\Amine\\Desktop\\Jeu-pacman-master\\images\\ennemi.png");

            ennemi = new Ennemi(random.Next(largeur), random.Next(hauteur), 1.0);

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

        private void label2_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DessinerLabyrinthe(e.Graphics);
            DessinerEnnemi(e.Graphics);
        }

        private void GenerationLab()
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    lab[i, j] = 1; // remplir toutes les cellules avec un mur
                }
            }
            CreerLab(2, 2); // commencer le labyrinthe à partir de la cellule (2, 2)
        }

        private void CreerLab(int x, int y)
        {
            lab[y, x] = 0; // dire que cette cellule est visitée
            List<Tuple<int, int>> directions = new List<Tuple<int, int>>()
            {
                Tuple.Create(1, 0), Tuple.Create(-1, 0), Tuple.Create(0, 1), Tuple.Create(0, -1)
            };
            directions = Shuffle(directions); // mélanger les directions pour explorer aléatoirement

            foreach (var direction in directions)
            {
                int dx = direction.Item1;
                int dy = direction.Item2;
                int nx = x + 2 * dx;
                int ny = y + 2 * dy;

                if (nx > 0 && nx < largeur && ny > 0 && ny < hauteur && lab[ny, nx] == 1)
                {
                    lab[y + dy, x + dx] = 0;
                    CreerLab(nx, ny);
                }
            }
        }

        private void ConnectChemin()
        {
            for (int y = 1; y < hauteur; y += 2)
            {
                for (int x = 1; x < largeur; x += 2)
                {
                    if (lab[y, x] == 0)
                    {
                        List<Tuple<int, int>> voisins = TrouveVoisins(x, y);
                        if (voisins.Count > 0)
                        {
                            Tuple<int, int> neighbor = voisins[random.Next(voisins.Count)];
                            int nx = neighbor.Item1;
                            int ny = neighbor.Item2;
                            lab[(y + ny) / 2, (x + nx) / 2] = 0;
                        }
                    }
                }
            }
        }

        private List<Tuple<int, int>> TrouveVoisins(int x, int y)
        {
            List<Tuple<int, int>> voisins = new List<Tuple<int, int>>();
            if (x > 1 && lab[y, x - 2] == 0) voisins.Add(Tuple.Create(x - 2, y));
            if (x < largeur - 2 && lab[y, x + 2] == 0) voisins.Add(Tuple.Create(x + 2, y));
            if (y > 1 && lab[y - 2, x] == 0) voisins.Add(Tuple.Create(x, y - 2));
            if (y < hauteur - 2 && lab[y + 2, x] == 0) voisins.Add(Tuple.Create(x, y + 2));
            return voisins;
        }

        private List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
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
            const int cellSize = 20; // taille de chaque cellule du labyrinthe
            graphics.DrawImage(ennemiImage, ennemi.X * cellSize, ennemi.Y * cellSize, cellSize, cellSize);
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

            switch (e.KeyCode)
            {
                case Keys.Z:
                case Keys.Up:
                    newY--; // Aller en haut    
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

            if (newX >= 0 && newX < largeur && newY >= 0 && newY < hauteur && lab[newY, newX] == 0)
            {
                joueurX = newX;
                joueurY = newY;
                this.panel1.Invalidate(); // Redessiner le panel
            }
            if (!premierDeplacement)
            {
                premierDeplacement = true;
                ennemiTimer.Start(); // Démarrer le Timer au premier déplacement du joueur
            }
        }

        private void EnnemiTimer_Tick(object sender, EventArgs e)
        {
            DeplacerEnnemi();
            this.panel1.Invalidate(); // Redessiner le panel
        }

        private void DeplacerEnnemi()
        {
            bool deplacementValide = false;
            while (!deplacementValide)
            {
                int deplacementX = random.Next(-1, 2);
                int deplacementY = random.Next(-1, 2);

                int nouveauX = ennemi.X + deplacementX;
                int nouveauY = ennemi.Y + deplacementY;

                if (nouveauX >= 0 && nouveauX < largeur && nouveauY >= 0 && nouveauY < hauteur && lab[nouveauY, nouveauX] == 0)
                {
                    ennemi.X = nouveauX;
                    ennemi.Y = nouveauY;
                    deplacementValide = true;
                }
            }
        }
    }

    public class Ennemi
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Vitesse { get; set; }

        public Ennemi(int x, int y, double vitesse)
        {
            X = x;
            Y = y;
            Vitesse = vitesse*2;
        }
    }
}
