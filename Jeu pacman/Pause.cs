namespace Jeu_pacman
{
    public partial class Pause : Form
    {
        public Pause()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Jeu JeuForm = new Jeu();
            JeuForm.Show();
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
    }
}
