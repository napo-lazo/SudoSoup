using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SudoSoup.Games;

namespace SudoSoup
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
        }

        private void SudokuBtn_Click(object sender, EventArgs e) {
            this.Hide();
            GameForm gameForm = new GameForm(this, new SudokuGame());
            if (!gameForm.IsDisposed)
            {
                gameForm.Text = ((Button)sender).Text;
                gameForm.Show();
            }
        }

        private void WordSearchBtn_Click(object sender, EventArgs e) {
            this.Hide();
            GameForm gameForm = new GameForm(this, new WordSoupGame());
            if (!gameForm.IsDisposed)
            {
                gameForm.Text = ((Button)sender).Text;
                gameForm.Show();
            }
        }
    }
}
