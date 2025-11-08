using QuestPDF.Fluent;
using SudoSoup.Controllers;
using SudoSoup.DataSource;
using SudoSoup.Games;
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
        private MainForm mainForm;
        private AppendixForm appendix;

        public GameForm(MainForm mainForm, GameBase game) {
            InitializeComponent();
            this.Hide();

            eventMgr.OnGameCompleted += DisplayCompletedMessage;
            eventMgr.OnUpdateCellColor += ChangeCellColor;
            eventMgr.OnMarkCellAsUsed += MarkCellAsUsed;
            eventMgr.OnAppendixFormClosed += ToggleAppendixFormState;
            eventMgr.OnWordsoupWordCompleted += CrossOutWordAppendix;

            this.game = game;
            this.mainForm = mainForm;

            using (Form config = this.game.config)
            {
                config.ShowDialog();
                if (config.DialogResult == DialogResult.OK)
                {
                    this.game.SetConfiguration();
                    this.game.GenerateGridValues();
                    ResizeGameGrid();
                    PopulateGameGrid();

                    if (this.game is IAppendix)
                    {
                        this.viewToolStripMenuItem.Visible = true;
                        this.appendix = (this.game as IAppendix).FormatAppendix();
                        appendix.Show();
                    }
                }
                else
                {
                    this.ManualCloseForm();
                }
            }
        }

        private void ToggleAppendixFormState()
        {
            if (this.appendixToolStripMenuItem.CheckState == CheckState.Checked)
                this.appendixToolStripMenuItem.CheckState = CheckState.Unchecked;
            else
                this.appendixToolStripMenuItem.CheckState = CheckState.Checked;
        }

        private void GeneratePDF()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = $"Save {this.game.gameTitle}";
                dialog.FileName = this.game.gameTitle;
                dialog.DefaultExt = "pdf";
                dialog.Filter = "PDF files (*.pdf)|*.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.game.GeneratePDF(dialog.FileName);
                }   
            }
        }

        private void ManualCloseForm()
        {
            this.ClearEvents();
            this.game.Dispose();
            this.mainForm.Show();
            this.Close();
        }

        private void ClearEvents()
        {
            eventMgr.OnGameCompleted -= DisplayCompletedMessage;
            eventMgr.OnUpdateCellColor -= ChangeCellColor;
            eventMgr.OnMarkCellAsUsed -= MarkCellAsUsed;
            eventMgr.OnAppendixFormClosed -= ToggleAppendixFormState;
            eventMgr.OnWordsoupWordCompleted -= CrossOutWordAppendix;
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

                    this.GameGrid.Controls.Add(this.game.GetGridCellControl(textValue), j, i);
                }
            }
        }

        private void DisplayCompletedMessage()
        {
            string message = $"You successfully completed the {game.gameTitle}";
            string caption = "Puzzle completed";

            MessageBox.Show(message, caption, MessageBoxButtons.OK);
            this.ManualCloseForm();
        }

        private void MarkCellAsUsed(List<int> cellIndexes)
        {
            for (int i = 0; i < cellIndexes.Count; i++)
            {
                Control control = this.GameGrid.Controls[cellIndexes[i]];
                if (control is WordsoupLabel)
                    ((WordsoupLabel)control).isPartOfCompletedWord = true;

                if (i == 0)
                    ChangeCellColor(cellIndexes[i], true);
                else
                    ChangeCellColor(cellIndexes[i], false);
            }
        }

        private void ChangeCellColor(int cellIndex, bool toggleBold)
        {
            Control control = this.GameGrid.Controls[cellIndex];

            if (control is WordsoupLabel) 
            {
                if (control.ForeColor != Color.Red || ((WordsoupLabel)control).isPartOfCompletedWord)
                    control.ForeColor = Color.Red;
                else
                    control.ForeColor = Color.Black;

                if (toggleBold)
                {
                    if (control.Font.Bold)
                        control.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                    else
                        control.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                }
            }
        }

        private void CrossOutWordAppendix(string word)
        {
            GroupBox groupBox = (GroupBox)appendix.tableLayout.Controls[0];
            TableLayoutPanel tableLayout = (TableLayoutPanel)groupBox.Controls[0];

            foreach (Control control in tableLayout.Controls)
            {
                Label label = (control as Label);

                if (label.Text == word)
                {
                    label.Font = label.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
                    break;
                }
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) {
            this.ClearEvents();
            this.game.Dispose();

            if (this.game is IAppendix)
                this.appendix.Close();

            this.mainForm.Show();
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

        private void appendixToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.appendix.IsDisposed)
                this.appendix = (this.game as IAppendix).FormatAppendix();
            
            if (((ToolStripMenuItem)sender).Checked)
                this.appendix.Show();
            else
                this.appendix.Hide();
        }
    }
}
