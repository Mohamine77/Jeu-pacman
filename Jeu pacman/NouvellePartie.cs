using System;
using System.Windows.Forms;


namespace Jeu_pacman
{
    public partial class NouvellePartie : Form
    {
        public static int difficulte = 0;
        public static string nompartie;
        public NouvellePartie()
        {
            InitializeComponent();
            chkdifficile.Parent = fondnouvellepartie;
            chkfacile.Parent = fondnouvellepartie;
            chknormal.Parent = fondnouvellepartie;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mainForm = new Main();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtb_Nompartie.Text))
            {
                if (chkdifficile.Checked)
                {
                    difficulte = 3;
                    nompartie=txtb_Nompartie.Text;
                    Jeu secondWindow = new Jeu();
                    secondWindow.Show();
                    this.Hide();
                }
                else if (chknormal.Checked)
                {
                    difficulte = 2;
                    nompartie= txtb_Nompartie.Text;
                    Jeu secondWindow = new Jeu();
                    secondWindow.Show();
                    this.Hide();
                }
                else if (chkfacile.Checked)
                {
                    difficulte = 1;
                    nompartie = txtb_Nompartie.Text;
                    Jeu secondWindow = new Jeu();
                    secondWindow.Show();
                    this.Hide();
                }
                else { throw new Exception("Veuillez sélectionner une difficulté."); }
            }
            else
            {
                throw new Exception("veuillez selectionner le nom de la partie.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NouvellePartie_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void chkfacile_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
