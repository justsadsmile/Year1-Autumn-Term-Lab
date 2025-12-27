using DotNetEnv;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasicProgrammingLab6
{
    public partial class ShowAuthorForm : Form
    {
        public ShowAuthorForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Font = new Font("Segoe UI", 9F);
            label1.Left = (ClientSize.Width - label1.Width) / 2;
        }

        private void ShowAuthorForm_Load(object sender, EventArgs e)
        {
            try
            {
                Env.Load();
                string name = Environment.GetEnvironmentVariable("AUTHOR_NAME") ?? "add .env file";
                string group = Environment.GetEnvironmentVariable("AUTHOR_GROUP_NUMBER") ?? "add .env file";

                label1.Text = $"AUTHOR: {name.ToUpper()}\n\n" +
                             $"GROUP: {group.ToUpper()}";

                label1.Left = (ClientSize.Width - label1.Width) / 2;
            }
            catch
            {
                label1.Text = "AUTHOR: add .env file\n\nGROUP: add .env file";
            }
        }

        private void ShowAuthorForm_Resize(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Left = (ClientSize.Width - label1.Width) / 2;
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(40, 40, 40, 40);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }
    }
}