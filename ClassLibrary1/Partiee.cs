using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassLibrary1.Partiee;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ClassLibrary1
{

    public class Partiee
    {
        private static Random random = new Random();

        public static void GenerationLab(int hauteur, int largeur, int[,] lab)
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    lab[i, j] = 1; // remplir toutes les cellules avec un mur
                }
            }
            CreerLab(2, 2, hauteur, largeur, lab); // commencer le labyrinthe à partir de la cellule (2, 2)
        }
        public static void CreerLab(int x, int y, int hauteur, int largeur, int[,] lab)
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
                    CreerLab(nx, ny, hauteur, largeur, lab);
                }
            }
        }
        public static List<T> Shuffle<T>(List<T> list)
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


        private void CreerLab(int x, int y, int[,] lab, int hauteur, int largeur)
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
                    CreerLab(nx, ny, hauteur, largeur, lab);
                }
            }
        }
        public static void bruitage(string locationsong)
        {
            SoundPlayer aouhh = new SoundPlayer();
            aouhh.SoundLocation = locationsong;
            aouhh.Play();


        }
        public static List<Tuple<int, int>> TrouveVoisins(int x, int y, int largeur, int hauteur, int[,] lab)
        {
            List<Tuple<int, int>> voisins = new List<Tuple<int, int>>();
            if (x > 1 && lab[y, x - 2] == 0) voisins.Add(Tuple.Create(x - 2, y));
            if (x < largeur - 2 && lab[y, x + 2] == 0) voisins.Add(Tuple.Create(x + 2, y));
            if (y > 1 && lab[y - 2, x] == 0) voisins.Add(Tuple.Create(x, y - 2));
            if (y < hauteur - 2 && lab[y + 2, x] == 0) voisins.Add(Tuple.Create(x, y + 2));
            return voisins;
        }
        public static void ConnectChemin(int hauteur, int largeur, int[,] lab)
        {
            for (int y = 1; y < hauteur; y += 2)
            {
                for (int x = 1; x < largeur; x += 2)
                {
                    if (lab[y, x] == 0)
                    {
                        List<Tuple<int, int>> voisins = TrouveVoisins(x, y, hauteur, largeur, lab);
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
        //déplacement de l'ennemi de manière général sans implémentation de système de difficulté
        public static void DeplacerEnnemi(Ennemi ennemi, int hauteur, int largeur, int[,] lab)
        {
            bool deplacementValide = false;
            while (!deplacementValide)
            {
                int deplacementX = random.Next(-1, 2);
                int deplacementY = random.Next(-1, 2);

                int nouveauX = ennemi.X + deplacementX;
                int nouveauY = ennemi.Y + deplacementY;

                if (nouveauX >= 0 && nouveauX < largeur && nouveauY >= 0 && nouveauY < hauteur && lab[nouveauY, nouveauX] == 0 && (nouveauX != ennemi.X || nouveauY != ennemi.Y))
                {
                    ennemi.X = nouveauX;
                    ennemi.Y = nouveauY;
                    deplacementValide = true;

                }
            }
        }
        public static void degats()
        {

        }

        public static void DessinerEnnemi(Graphics graphics, Ennemi ennemi, Bitmap chasseurImage)
        {
            if (ennemi != null)
            {
                const int cellSize = 20; // taille de chaque cellule du labyrinthe
                graphics.DrawImage(chasseurImage, ennemi.X * cellSize, ennemi.Y * cellSize, cellSize, cellSize);
            }
        }
        public static void DessinerPotion(Graphics graphics, Potion potion, Bitmap chasseurImage, int hauteur, int largeur, int[,] lab, int joueurx, int joueury)
        {

            int emplacementX = 0;
            int emplacementY = 0;
            const int cellSize = 20; // taille de chaque cellule du labyrinthe
            Random random = new Random();

            // Trouver un emplacement valide pour la potion
            bool emplacementTrouve = false;
            while (!emplacementTrouve)
            {
                emplacementX = random.Next(2, largeur);
                emplacementY = random.Next(2, hauteur);

                if (lab[emplacementY, emplacementX] == 0 && (emplacementX != joueurx || emplacementY != joueury))
                {
                    emplacementTrouve = true;
                }
            }

            // Dessiner l'image de la potion à l'emplacement trouvé
            graphics.DrawImage(chasseurImage, emplacementX * cellSize, emplacementY * cellSize, cellSize, cellSize);

        }
        public static void DessinerLabyrinthe(Graphics graphics, int hauteur, int largeur, int[,] lab, Bitmap joueurImage, int joueurX, int joueurY)
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
        public static void ResetPositions(ref int joueurX, ref int joueurY)
        {

            joueurX = 2;
            joueurY = 2;

        }
        public static void DessinerPotion(Graphics graphics, Potion potion, Bitmap potionImage, int cellSize)
        {
            if (potion != null)
            {
                // Dessiner l'image de la potion à l'emplacement stocké
                graphics.DrawImage(potionImage, potion.EmplacementX * cellSize, potion.EmplacementY * cellSize, cellSize, cellSize);
            }
        }
        public static void Nextlvl(Bitmap chasseurImage,Bitmap potionImage, int hauteur,int largeur, int [,] lab,int joueurX,int joueurY,Potion potion,ref Ennemi ennemi,ref Ennemi chasseur,Timer ennemiTimer,Panel panel1,bool passagelvl,ref int niveau)
        {
            niveau++;
            Partiee.GenerationLab(hauteur, largeur, lab);
            Partiee.ConnectChemin(hauteur, largeur, lab);

            // Réinitialiser les positions du joueur et de l'ennemi
            Partiee.ResetPositions(ref joueurX, ref joueurY);
            ennemi = GenererEnnemiValide(hauteur,largeur,lab,passagelvl); // Utilisation de random.Next(largeur) pour éviter les problèmes de débordement
            chasseur = GenererEnnemiValide(hauteur, largeur, lab, passagelvl);

            // Réinitialiser les potions
            potion.Initialiser(hauteur, largeur, lab, joueurX, joueurY);

            // Redémarrer le timer de l'ennemi
            ennemiTimer.Start();

            // Redessiner le panneau
            panel1.Invalidate();
        }
        public static Ennemi GenererEnnemiValide(int hauteur,int largeur,int[,] lab,bool passagelvl)
        {
            int x, y;
            do
            {
                x = random.Next(largeur);
                y = random.Next(hauteur);
                passagelvl = false;
            }
            while (lab[y, x] != 0 && passagelvl==true); // Répétez jusqu'à ce que l'on trouve une position valide (non mur)

            return new Ennemi(x, y, 1.0);
        }
        public static void Collision(int joueurX, int joueurY, Ennemi ennemi, bool humain, int JoueurVie,PictureBox coeur2,PictureBox coeur1, PictureBox coeur3, Form jeu, Panel panel1, Timer ennemiTimer, string sonmort, string MsgGameOver,string son)
        {
            if (ennemi != null)
                if (joueurX == ennemi.X && joueurY == ennemi.Y && humain == true)
                {
                    JoueurVie--;
                    if (JoueurVie == 2)
                    {
                        coeur3.Visible = false;
                    }
                    else if (JoueurVie == 1)
                    {
                        coeur2.Visible = true;
                    }
                    else if(JoueurVie == 0) { coeur1.Visible = true; }

                    bruitage(son);
                    if (JoueurVie <= 0)
                    {

                        MessageBox.Show(MsgGameOver);
                        ennemiTimer.Stop();
                    }
                    else
                    {
                        Partiee.ResetPositions(ref joueurX, ref joueurY);

                        panel1.Invalidate();

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
      

        public class Ennemi
        {
            public int X { get; set; }
            public int Y { get; set; }
            public double Vitesse { get; set; }

            public Ennemi(int x, int y, double vitesse)
            {
                X = x;
                Y = y;
                Vitesse = vitesse * 2;
            }

        }
        public class Potion
        {
            public int EmplacementX { get; set; }
            public int EmplacementY { get; set; }

            public void Initialiser(int hauteur, int largeur, int[,] lab, int joueurx, int joueury)
            {
                Random random = new Random();
                bool emplacementTrouve = false;

                while (!emplacementTrouve)
                {
                    int x = random.Next(2, largeur);
                    int y = random.Next(2, hauteur);

                    if (lab[y, x] == 0 && (x != joueurx || y != joueury))
                    {
                        EmplacementX = x;
                        EmplacementY = y;
                        emplacementTrouve = true;
                    }
                }
            }
        }
    }
}
