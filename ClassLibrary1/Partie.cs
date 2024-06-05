using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
  
        public class Partie
        {
            private static Random random = new Random();

            private void GenerationLab(int hauteur, int largeur, int[,] lab)
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
            private void CreerLab(int x, int y, int hauteur, int largeur, int[,] lab)
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
        }
    }
