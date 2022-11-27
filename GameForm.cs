using QuestPDF.Fluent;
using SudoSoup.Controllers;
using SudoSoup.DataSource;
using SudoSoup.Models;
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
        private GameBase game;
        private EventManager eventMgr = EventManager.GetEventManager();

        public GameForm(GameBase game) {
            InitializeComponent();
            this.Hide();

            eventMgr.OnGameCompleted += DisplayCompletedMessage;
            this.game = game;

            using (SudokuConfiguration config = new SudokuConfiguration())
            {
                config.ShowDialog();
                if (config.DialogResult == DialogResult.OK)
                {
                    this.game.InitializeRandomizer(config.seedValue);
                    this.game.GenerateGridValues();
                    ResizeGameGrid();
                    PopulateGameGrid();
                }
            }
        }

        private void GeneratePDF()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Sudoku";
                dialog.FileName = "Sudoku";
                dialog.DefaultExt = "pdf";
                dialog.Filter = "PDF files (*.pdf)|*.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SudokuModel sudokuModel = SudokuDataSource.GetSudokuModel(this.game as SudokuGame);
                    SudokuPDF document = new SudokuPDF(sudokuModel);
                    document.GeneratePdf(dialog.FileName);
                }   
            }
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
                    this.GameGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, newSize));
            }
        }

        private void PopulateGameGrid()
        {
            if (this.GameGrid.Controls.Count != 0)
                this.GameGrid.Controls.Clear();

            for (int i = 0; i < this.game.gameGrid.GetLength(0); i++)
            {
                for (int j = 0; j < this.game.gameGrid.GetLength(1); j++)
                {
                    string textValue = this.game.gameGrid[i, j];

                    this.GameGrid.Controls.Add(new SudokuTextBox(textValue), j, i);
                }
            }
        }

        private void DisplayCompletedMessage()
        {
            string message = "You successfully completed the Sudoku";
            string caption = "Puzzle completed";

            MessageBox.Show(message, caption, MessageBoxButtons.OK);
            Application.Exit();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void saveAsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratePDF();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();

            this.game.ClearGridValues();
            this.game.GenerateGridValues();
            ResizeGameGrid();
            PopulateGameGrid();

            this.ResumeLayout();
        }
    }
}
