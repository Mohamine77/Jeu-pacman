
using Jeu_pacman;


namespace Jeu_pacman

{
    public partial class Pause : Form
    {
        public static Pause instancepause;
        public Pause()
        {
            InitializeComponent();
            instancepause = this;
            lblnompartie.Text = NouvellePartie.nompartie;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jeu.jeuEnPause = false;
            Jeu.instance.Reprendre();
            this.Close();

        }
        public static void enleverpause(Jeu jeu)
        {
            jeu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mainForm = new Main();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
