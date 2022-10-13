using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup
{
    public class SudokuHelper : Game
    {
        public SudokuHelper()
        {
            GenerateSudokuGrid();
        }

        private void GenerateSudokuGrid()
        {
            Random random = new Random();

            //Fills the diagonals inner boxes of the Sudoku grid
            for (int i = 0; i < 3; i++)
            {
                int index = i * 3;
                FillDiagonalBox(random, index);
            }

            IterateGrid(0, 0);
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

        private void FillDiagonalBox(Random random, int startingIndex)
        {
            List<string> availableNumbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int endingIndex = startingIndex + 3;

            for (int i = startingIndex; i < endingIndex; i++)
            {
                for (int j = startingIndex; j < endingIndex; j++)
                {
                    int index = random.Next(0, availableNumbers.Count);
                    this.gameGrid[i, j] = availableNumbers[index];
                    availableNumbers.RemoveAt(index);
                }
            }
        }
    }
}
