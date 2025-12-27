using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace BasicProgrammingLab6
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathGameForm form1 = new MathGameForm();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowAuthorForm form2 = new ShowAuthorForm();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateAndSortArrayForm form3 = new CreateAndSortArrayForm();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectFourGameForm form4 = new ConnectFourGameForm();
            form4.Show();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

    }
}