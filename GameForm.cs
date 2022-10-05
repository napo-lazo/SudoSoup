using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudoSoup
{
    public partial class GameForm : Form
    {
        Game game;

        public GameForm(Game game) {
            InitializeComponent();
            this.game = game;
            ResizeGameGrid();
            PopulateGameGrid();
        }

        private void ResizeGameGrid()
        {
            int rowCount = this.game.gameGrid.GetLength(0);
            int columnCount = this.game.gameGrid.GetLength(1);
            this.GameGrid.RowCount = rowCount;
            this.GameGrid.ColumnCount = columnCount;
            float newSize = 100 / rowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (this.GameGrid.RowStyles.Count > i)
                    this.GameGrid.RowStyles[i].Height = newSize;
                else
                    this.GameGrid.RowStyles.Add(new RowStyle(SizeType.Percent, newSize));
            }

            for (int i = 0; i < columnCount; i++)
            {
                if (this.GameGrid.ColumnStyles.Count > i)
                    this.GameGrid.ColumnStyles[i].Width = newSize;
                else
                    this.GameGrid.ColumnStyles.Add(new RowStyle(SizeType.Percent, newSize));
            }
        }

        private void PopulateGameGrid()
        {
            for (int i = 0; i < this.game.gameGrid.GetLength(0); i++)
            {
                for (int j = 0; j < this.game.gameGrid.GetLength(1); j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = this.game.gameGrid[i, j];

                    this.GameGrid.Controls.Add(textBox, j, i);
                }
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
