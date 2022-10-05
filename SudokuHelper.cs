using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup
{
    class SudokuHelper : Game
    {
        public SudokuHelper()
        {
            GenerateSudokuGrid();
        }

        private void GenerateSudokuGrid()
        {
            for (int i = 0; i < this.gameGrid.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameGrid.GetLength(1); j++)
                {
                    this.gameGrid[j,i] = Convert.ToString(j + 1);
                }
            }
        }

    }
}
