
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jeu_pacman
{
    public partial class Jeu : Form
    {
        private static Random random = new Random();
        private static int largeur = 52; // largeur du labyrinthe
        private static int hauteur = 38; // hauteur du labyrinthe
        private static int[,] lab = new int[hauteur, largeur]; // tableau qui représente le labyrinthe
        private int joueurX = 2; // position initiale du joueur (x)
        private int joueurY = 2; // position initiale du joueur (y)
        private Bitmap joueurImage; // image du joueur

        public Jeu()
        {
            InitializeComponent();
            GenerationLab();
            ConnectChemin();

            this.KeyPreview = true; // Permet au formulaire de capturer les événements de touches
            this.KeyDown += new KeyEventHandler(Jeu_KeyDown); // Abonnez-vous à l'événement KeyDown
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel1.Invalidate();

            // Charger l'image du joueur
            joueurImage = new Bitmap("C:\\Users\\Amine\\Desktop\\Jeu-pacman-master\\images\\jeu.png"); // Assurez-vous que l'image est dans le bon emplacement
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mainForm = new Main();
            mainForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Dessiner le labyrinthe
            DessinerLabyrinthe(e.Graphics);
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
            // définir l'ordre aléatoire des directions à explorer
            List<Tuple<int, int>> directions = new List<Tuple<int, int>>()
            {
                Tuple.Create(1, 0), Tuple.Create(-1, 0), Tuple.Create(0, 1), Tuple.Create(0, -1)
            };
            directions = Shuffle(directions); // mélanger les directions pour explorer aléatoirement

            // explorer chaque direction
            foreach (var direction in directions)
            {
                int dx = direction.Item1;
                int dy = direction.Item2;
                int nx = x + 2 * dx;
                int ny = y + 2 * dy;

                // vérif si la prochaine cellule est valide et non visitée
                if (nx > 0 && nx < largeur && ny > 0 && ny < hauteur && lab[ny, nx] == 1)
                {
                    // casser le mur entre la cellule actuelle et la prochaine cellule
                    lab[y + dy, x + dx] = 0;
                    CreerLab(nx, ny); // explorer récursivement à partir de la prochaine cellule
                }
            }
        }

        private void ConnectChemin()
        {
            for (int y = 1; y < hauteur; y += 2)
            {
                for (int x = 1; x < largeur; x += 2)
                {
                    if (lab[y, x] == 0) // si la cellule est visitée
                    {
                        List<Tuple<int, int>> voisins = TrouveVoisins(x, y); // obtenir les cellules voisines non visitées
                        if (voisins.Count > 0)
                        {
                            Tuple<int, int> neighbor = voisins[random.Next(voisins.Count)]; // prendre une cellule voisine aléatoire
                            int nx = neighbor.Item1;
                            int ny = neighbor.Item2;
                            lab[(y + ny) / 2, (x + nx) / 2] = 0; // casser le mur entre la cellule actuelle et le voisin choisi
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
            int cellSize = 20; // taille de chaque cellule du labyrinthe
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

            // Dessiner le joueur
            graphics.DrawImage(joueurImage, joueurX * cellSize, joueurY * cellSize, cellSize, cellSize);
        }

        private void Jeu_KeyDown(object sender, KeyEventArgs e)
        {
            int newX = joueurX;
            int newY = joueurY;

            switch (e.KeyCode)
            {
                case Keys.Z:
                    newY--; // Aller en haut
                    break;
                case Keys.Q:
                    newX--; // Aller à gauche
                    break;
                case Keys.S:
                    newY++; // Aller en bas
                    break;
                case Keys.D:
                    newX++; // Aller à droite
                    break;
            }

            if (newX >= 0 && newX < largeur && newY >= 0 && newY < hauteur && lab[newY, newX] == 0)
            {
                joueurX = newX;
                joueurY = newY;
                this.panel1.Invalidate(); // Redessiner le panel
            }
        }
    }
}
