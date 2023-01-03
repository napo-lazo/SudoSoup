using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;
using SudoSoup.ConfigurationForms;
using SudoSoup.Controllers;
using SudoSoup.DataSource;
using SudoSoup.Models;
using SudoSoup.PDFs;

namespace SudoSoup.Games
{
    public class SudokuGame : GameBase
    {
        public string[,] solutionGrid;
        private int qtyToRemove = 51;
        private int filledCells = 0;
        private HashSet<int> invalidCellIndexes = new HashSet<int>();

        public SudokuGame()
        {
            this.gameTitle = "Sudoku";
            this.solutionGrid = new string[9, 9];
            eventMgr.OnFilledSudokuCell += UpdateSudokuState;
            this.config = new SudokuConfiguration();
        }

        private void UpdateSudokuState(int cellIndex, string cellValue)
        {
            //Only increment the cell counter when initializing the game form
            if (filledCells <  81 - qtyToRemove) 
            {
                this.filledCells++;
                return;
            }

            int row = cellIndex / 9;
            int column = cellIndex % 9;

            if (!string.IsNullOrWhiteSpace(cellValue))
            {
                if (!CheckNumberAvailability(row, column, cellValue))
                    this.invalidCellIndexes.Add(cellIndex);

                this.filledCells++;
            }
            else
            {
                if (invalidCellIndexes.Contains(cellIndex))
                    invalidCellIndexes.Remove(cellIndex);
                
                filledCells--;
            }

            this.gameGrid[row, column] = cellValue;

            if (filledCells == 81 && invalidCellIndexes.Count == 0)
                eventMgr.GameCompleted();
        }

        public override void SetConfiguration()
        {
            InitializeRandomizer(((SudokuConfiguration)config).seedValue);
        }

        public override Control GetGridCellControl(string cellValue)
        {
            return new SudokuTextBox(cellValue);
        }

        public override void ClearGridValues()
        {
            this.gameGrid = new string[9, 9];
            this.solutionGrid = new string[9, 9];
        }

        public override void GeneratePDF(string filename)
        {
            SudokuModel sudokuModel = SudokuDataSource.GetSudokuModel(this);
            SudokuPDF document = new SudokuPDF(sudokuModel);
            document.GeneratePdf(filename);
        }

        public override void GenerateGridValues()
        {
            //Fills the diagonals inner boxes of the Sudoku grid
            for (int i = 0; i < 3; i++)
            {
                int index = i * 3;
                FillDiagonalBox(index);
            }

            IterateGrid(0, 0);
            Array.Copy(this.gameGrid, this.solutionGrid, 81);
            RemoveNumbersFromGrid();
        }

        private void RemoveNumbersFromGrid()
        {
            int remainingQtyToRemove = this.qtyToRemove;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int minVal = remainingQtyToRemove / ((3 - i) * 3 - j);
                    int maxVal = 9;

                    if (remainingQtyToRemove < 8)
                        maxVal = remainingQtyToRemove + 1;

                    int numbersToRemove = this.random.Next(minVal, maxVal);
                    RemoveNumbersFromInnerBox(i, j, numbersToRemove);
                    remainingQtyToRemove -= numbersToRemove;
                }
            }

            Console.WriteLine(remainingQtyToRemove);
        }

        private void RemoveNumbersFromInnerBox(int row, int column, int numbersToRemove)
        {
            List<int> validCells = new List<int>(); 

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    validCells.Add(27 * row + 3 * column + 9 * i + j);
                }
            }

            for (int i = 0; i < numbersToRemove; i++)
            {
                int indexToRemove = this.random.Next(0, validCells.Count);
                int gridIndex = validCells[indexToRemove];
                validCells.RemoveAt(indexToRemove);

                this.gameGrid[gridIndex / 9, gridIndex % 9] = "";

            }
        }

        private bool IterateGrid(int row, int column)
        {
            if (string.IsNullOrEmpty(this.gameGrid[row, column]))
            {
                int proposedNumber = 1;

                while (!TryProposedNumber(row, column, Convert.ToString(proposedNumber)))
                {
                    proposedNumber++;

                    this.gameGrid[row, column] = "";

                    if (proposedNumber >= 10)
                        return false;
                }

                return true;
            }

            return MoveToNextCell(row, column);
        }

        private bool TryProposedNumber(int row, int column, string number)
        {
            if (CheckNumberAvailability(row, column, number))
            {
                this.gameGrid[row, column] = number;

                return MoveToNextCell(row, column);
            }

            return false;
        } 

        private bool MoveToNextCell(int row, int column)
        {
            if (row == 8 && column == 8)
                return true;

            if (column < 8)
                return IterateGrid(row, column + 1);
            else
                return IterateGrid(row + 1, 0);
        }

        private bool CheckNumberAvailability(int row, int column, string number)
        {
            //checks current entire row and column
            for (int i = 0; i < 9; i++)
            {
                if (this.gameGrid[row, i] == number || this.gameGrid[i, column] == number)
                    return false;
            }

            //checks in corresponding inner box
            int x = column / 3;
            int y = row / 3;

            for (int i = y * 3; i < (y + 1) * 3; i++)
            {
                for (int j = x * 3; j < (x + 1) * 3; j++)
                {
                    if (this.gameGrid[i, j] == number)
                        return false;
                }
            }

            return true;
        }

        private void FillDiagonalBox(int startingIndex)
        {
            List<string> availableNumbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int endingIndex = startingIndex + 3;

            for (int i = startingIndex; i < endingIndex; i++)
            {
                for (int j = startingIndex; j < endingIndex; j++)
                {
                    int index = this.random.Next(0, availableNumbers.Count);
                    this.gameGrid[i, j] = availableNumbers[index];
                    availableNumbers.RemoveAt(index);
                }
            }
        }

        public override void Dispose()
        {
            eventMgr.OnFilledSudokuCell -= UpdateSudokuState;
        }
    }
}
