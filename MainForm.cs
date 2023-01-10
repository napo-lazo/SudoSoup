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

        private void GoToGameForm(object sender, GameBase game)
        {
            this.Hide();
            GameForm gameForm = new GameForm(this, game);
            if (!gameForm.IsDisposed)
            {
                gameForm.Text = ((Button)sender).Text;
                gameForm.Show();
            }
        }

        public MainForm() {
            InitializeComponent();
        }

        private void SudokuBtn_Click(object sender, EventArgs e) {
            GameBase sudoku = new SudokuGame();

            this.GoToGameForm(sender, sudoku);
        }

        private void WordSearchBtn_Click(object sender, EventArgs e) {
            GameBase wordsoup = new WordSoupGame();

            this.GoToGameForm(sender, wordsoup);
        }
    }
}
