using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

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
        public static List<Tuple<int, int>> TrouveVoisins(int x, int y,int largeur,int hauteur,int [,]lab)
        {
            List<Tuple<int, int>> voisins = new List<Tuple<int, int>>();
            if (x > 1 && lab[y, x - 2] == 0) voisins.Add(Tuple.Create(x - 2, y));
            if (x < largeur - 2 && lab[y, x + 2] == 0) voisins.Add(Tuple.Create(x + 2, y));
            if (y > 1 && lab[y - 2, x] == 0) voisins.Add(Tuple.Create(x, y - 2));
            if (y < hauteur - 2 && lab[y + 2, x] == 0) voisins.Add(Tuple.Create(x, y + 2));
            return voisins;
        }
       public static void ConnectChemin(int hauteur,int largeur,int[,]lab)
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

        public static void DeplacerEnnemi(Ennemi ennemi,int hauteur,int largeur,int[,]lab)
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
            Vitesse = vitesse * 2;
        }

    }
}
