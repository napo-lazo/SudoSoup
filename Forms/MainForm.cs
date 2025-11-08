using System;
using System.Windows.Forms;

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

        public MainForm() 
        {
            InitializeComponent();
        }

        private void GameBtn_OnClick(object sender, EventArgs e) 
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                GameBase game = GameBase.CreateGame(btn.Text);
                this.GoToGameForm(sender, game);
            }
        }
    }
}
