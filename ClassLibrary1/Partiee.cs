using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Controls.Primitives;
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

                if (nx > 0 && nx < largeur && ny > 0 && ny < hauteur && lab[ny, nx] == 1 )
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
        public static void Affichageniveaureussi(int difficulte,ref bool verifdifficultetermine)
        {
            if(difficulte == 0) return;
            if (difficulte == 1)
            {
                MessageBox.Show("Vous avez réussi le mode facile bon c'est normal après tout.");
                verifdifficultetermine = true;
            }
            else if (difficulte == 2)
            {
                MessageBox.Show("Bravo vous avez réussi le mode normal.");
                verifdifficultetermine = true;

            }
            else if (difficulte == 3)
            {
                MessageBox.Show("Quelle talent vous avez réussi le mode difficile !!!!!");  
                verifdifficultetermine = true;

            }
        }
        public static void tuerEnnemi(ref Ennemi ennemi, Timer ennemiTimer,Panel panel1)
        {
            if (ennemi == null || ennemiTimer == null || panel1 == null)
            {
                throw new ArgumentNullException("Un des paramètres est null.");
            }

            ennemi.Visible = false;
            ennemiTimer.Stop();
            ennemi = null;
            panel1.Invalidate();

        }
        public static void reussiteniveau1(Timer ennemiTimer,Timer ennemitimer2,Ennemi ennemi,Panel panel1,bool passagelvl,string messagestagetermine,ref bool stagereussi)
        {
            ennemiTimer.Stop();
            ennemitimer2.Stop();
            ennemi = null;
            panel1.Invalidate();
            passagelvl = true;
            stagereussi = true;

            MessageBox.Show(messagestagetermine);

        }

        public static void niveaureussitverif(ref int stagelevelencours, Timer ennemiTimer, ref bool verifdifficultetermin, Timer ennemiTimer2, ref Ennemi ennemi, ref Ennemi ennemi2, Panel panel1, bool passagelvl, ref bool stagereussi, int joueurX, int joueurY, Bitmap ennemiimage, Bitmap bonusimage, int hauteur, int largeur, int[,] lab, Potion potion, int niveau, int difficulte)
        {
            if (ennemiTimer == null || panel1 == null)
            {
                throw new ArgumentNullException("ennemiTimer ou panel1 doivent être définis.");
            }

            if (stagelevelencours == 1)
            {
                tuerEnnemi(ref ennemi, ennemiTimer, panel1);

                // Vérification si le deuxième ennemi est présent et tué
                if (ennemi2 != null && joueurX == ennemi2.X && joueurY == ennemi2.Y)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);
                }
                else if (ennemi2 == null && ennemi == null)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);

                }
            }
           
            else if (stagelevelencours == 2 || stagelevelencours == 3)
            {
                tuerEnnemi(ref ennemi, ennemiTimer, panel1);
                panel1.Invalidate();

                // Vérification si le deuxième ennemi est présent et tué
                if (ennemi2 != null && joueurX == ennemi2.X && joueurY == ennemi2.Y)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);
                }
                else if (ennemi2 == null && ennemi == null)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);

                }
            }

            // Si le niveau en cours est inférieur à 3 et que le niveau est réussi
            if (stagelevelencours < 3 && stagereussi)
            {
                Partiee.Nextlvl1(ennemiimage, bonusimage, hauteur, largeur, lab, joueurX, joueurY, potion, ref ennemi, ennemiTimer, ennemiTimer2, panel1, passagelvl, niveau, ref stagelevelencours);
            }
            else if (stagereussi)
            {
                Affichageniveaureussi(difficulte, ref verifdifficultetermin);
            }
        }
        public static void niveaureussitverifalternatif(ref int stagelevelencours, Timer ennemiTimer, ref bool verifdifficultetermin, Timer ennemiTimer2, ref Ennemi ennemi, ref Ennemi ennemi2, Panel panel1, bool passagelvl, ref bool stagereussi, int joueurX, int joueurY, Bitmap ennemiimage, Bitmap bonusimage, int hauteur, int largeur, int[,] lab, Potion potion, int niveau, int difficulte)
        {
            if (ennemiTimer == null || panel1 == null)
            {
                throw new ArgumentNullException("ennemiTimer ou panel1 doivent être définis.");
            }

            if (stagelevelencours == 1)
            {
                tuerEnnemi(ref ennemi, ennemiTimer, panel1);

                // Vérification si le deuxième ennemi est présent et tué
                if (ennemi2 != null && joueurX == ennemi2.X && joueurY == ennemi2.Y)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);
                }
                else if (ennemi2 == null&&ennemi==null)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);

                }
            }
            else if (stagelevelencours == 2 || stagelevelencours == 3)
            {
                tuerEnnemi(ref ennemi, ennemiTimer, panel1);
                panel1.Invalidate();

                // Vérification si le deuxième ennemi est présent et tué
                if (ennemi2 != null && joueurX == ennemi2.X && joueurY == ennemi2.Y)
                {
                    reussiteniveau1(ennemiTimer, ennemiTimer2, ennemi2, panel1, passagelvl, "Le loup a visiblement frappé ce soir", ref stagereussi);
                }
            }
      

            // Si le niveau en cours est inférieur à 3 et que le niveau est réussi
            if (stagelevelencours < 3 && stagereussi)
            {
                Partiee.Nextlvl1(ennemiimage, bonusimage, hauteur, largeur, lab, joueurX, joueurY, potion, ref ennemi, ennemiTimer, ennemiTimer2, panel1, passagelvl, niveau, ref stagelevelencours);
            }
            else if (stagereussi)
            {
                Affichageniveaureussi(difficulte, ref verifdifficultetermin);
            }
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
            if (ennemi != null)
            {
                bool deplacementValide = false;
                Random random = new Random();
                while (!deplacementValide)
                {
                    int deplacementX = random.Next(-1, 2);
                    int deplacementY = random.Next(-1, 2);

                    int nouveauX = ennemi.X + deplacementX;
                    int nouveauY = ennemi.Y + deplacementY;

                    if (nouveauX >= 0 && nouveauX < largeur && nouveauY >= 0 && nouveauY < hauteur && lab[nouveauY, nouveauX] == 0 && (nouveauX != ennemi.X || nouveauY != ennemi.Y))
                    {
                        if (deplacementX == -1 && deplacementY == 0)
                        {
                            ennemi.Direction = "left";
                        }
                        else if (deplacementX == 1 && deplacementY == 0)
                        {
                            ennemi.Direction = "right";
                        }
                        else if (deplacementX == 0 && deplacementY == -1)
                        {
                            ennemi.Direction = "up";
                        }
                        else if (deplacementX == 0 && deplacementY == 1)
                        {
                            ennemi.Direction = "down";
                        }
                        else
                        {
                            ennemi.Direction = "none"; // En cas de mouvement diagonal ou pas de mouvement
                        }

                        ennemi.X = nouveauX;
                        ennemi.Y = nouveauY;
                        deplacementValide = true;
                    }
                }
            }
        }
        public static void degats()
        {

        }
        public static void Enlevervie(ref int joueurvie, PictureBox coeur1, PictureBox coeur2, PictureBox coeur3,int nbvieaperdre)
        {
            if(nbvieaperdre > 3)
            {
                throw new Exception("Le nombre de vie a enlever est incorrect");
            }
                joueurvie = joueurvie - nbvieaperdre;
      
                if (joueurvie == 2)
                {
                    coeur3.Visible = false;
                }
                else if (joueurvie == 1)
                {
                    coeur2.Visible = false;
                    coeur3.Visible = false;

            }
            else if (joueurvie == 0)
                {
                    coeur1.Visible = false;
                    coeur2.Visible = false;
                    coeur3.Visible = false;

            }



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
        public static void Nextlvl1(Bitmap chasseurImage,Bitmap potionImage, int hauteur,int largeur, int [,] lab,int joueurX,int joueurY,Potion potion,ref Ennemi ennemi,Timer ennemiTimer,Timer ennemiTimer2,Panel panel1,bool passagelvl,int niveau,ref int stageniveauactuel)
        {
            
                niveau++;
                Partiee.GenerationLab(hauteur, largeur, lab);
                Partiee.ConnectChemin(hauteur, largeur, lab);

                // Réinitialiser les positions du joueur et de l'ennemi
                Partiee.ResetPositions(ref joueurX, ref joueurY);
                ennemi = GenererEnnemiValide(hauteur, largeur, lab, passagelvl); // Utilisation de random.Next(largeur) pour éviter les problèmes de débordement
                Ennemi ennemi2 = GenererEnnemiValide(hauteur, largeur, lab, passagelvl);
                // Réinitialiser les potions
                potion.Initialiser(hauteur, largeur, lab, joueurX, joueurY);

                // Redémarrer le timer de l'ennemi
                ennemiTimer.Start();
                ennemiTimer2.Start();

            // Redessiner le panneau
            stageniveauactuel = stageniveauactuel + 1;

            panel1.Invalidate();
                
            
        }
        public static  Ennemi GenererEnnemiValide(int hauteur,int largeur,int[,] lab,bool passagelvl)
        {
            int x, y;
            do
            {
                x = random.Next(largeur);
                y = random.Next(hauteur);
                passagelvl = false;
            }
            while (lab[y, x] != 0 && passagelvl==true && y<hauteur-2 && x< largeur-2 &&x >= 2 && y >= 2); // Répétez jusqu'à ce que l'on trouve une position valide (non mur)

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
          
            public int ennemiLeft
            {
                get { return X * 20; } // Calculez la position en pixels basée sur la taille de la cellule du labyrinthe
            }

            public int ennemiTop
            {
                get { return Y * 20; } // Calculez la position en pixels basée sur la taille de la cellule du labyrinthe
            }
            public string Direction
            {
                get; set;
            }
            public bool Visible { get; set; } = true;


            public double Vitesse { get; set; }

            public Ennemi(int x, int y, double vitesse)
            {
                X = x;
                Y = y;
                Vitesse = vitesse * 2;
            }
            public static void TirerBalle(Panel panel, Ennemi ennemi)
            {
                Balle balle = new Balle(ennemi.ennemiLeft + (20 / 2), ennemi.ennemiTop + (20 / 2), ennemi.Direction);
                balle.CreerBalle(panel);
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

        
            public class Balle
            {
                public string Direction { get; set; }
                public int Left { get; set; }
                public int Top { get; set; }
                public int Speed { get; set; } = 5; // Réduire cette valeur pour ralentir les balles
                public bool IsDisposed { get; private set; } = false;

                private PictureBox pictureBox = new PictureBox();
                private Timer timer = new Timer();
                private Stopwatch stopwatch = new Stopwatch();
                private const int MaxDurationMilliseconds = 3000; // Durée de vie maximale de la balle en millisecondes

                public static int joueurX;
                public static int joueurY;
                private int joueurvie;
                public static Action OnPlayerHit; // Delegate for player hit event

                public Balle(int left, int top, string direction)
                {
                    Left = left;
                    Top = top;
                    Direction = direction;
                }

                public void CreerBalle(Panel panel)
                {
                    pictureBox.BackColor = Color.Black;
                    pictureBox.Size = new Size(5, 5);
                    pictureBox.Tag = "balle";
                    pictureBox.Left = Left;
                    pictureBox.Top = Top;
                    pictureBox.BringToFront();
                    panel.Controls.Add(pictureBox);

                    timer.Interval = 50; // Intervalle de temps pour le timer, ajustez si nécessaire
                    timer.Tick += Timer_Tick;
                    stopwatch.Start();
                    timer.Start();
                }

                public void Timer_Tick(object sender, EventArgs e)
                {
                    if (stopwatch.ElapsedMilliseconds > MaxDurationMilliseconds)
                    {
                        Dispose();
                        return;
                    }

                    Move();

                    // Vérification de la collision avec le joueur
                    if (pictureBox.Bounds.IntersectsWith(new Rectangle(joueurX, joueurY, 20, 20)))
                    {
                        OnPlayerHit?.Invoke(); // Trigger the player hit event
                        Dispose();
                    }

                    // Vérification des limites de l'écran ou d'autres conditions de disparition
                    if (pictureBox.Left < 10 || pictureBox.Left > 300 || pictureBox.Top < 10 || pictureBox.Top > 300)
                    {
                        Dispose();
                    }
                }

                private void Move()
                {
                    switch (Direction)
                    {
                        case "left":
                            pictureBox.Left -= Speed;
                            break;
                        case "right":
                            pictureBox.Left += Speed;
                            break;
                        case "up":
                            pictureBox.Top -= Speed;
                            break;
                        case "down":
                            pictureBox.Top += Speed;
                            break;
                    }
                }

                private void Dispose()
                {
                    timer.Stop();
                    timer.Dispose();
                    pictureBox.Dispose();
                    IsDisposed = true;
                }

               
            }
        }
}
