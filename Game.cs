using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup
{
    public class Game
    {
        public string[,] gameGrid;
        public int randomSeed;
        protected Random random;

        protected Game()
        {
            gameGrid = new string[9,9];
            randomSeed = Environment.TickCount;
            random = new Random(randomSeed);
        }

        protected Game(int gridSize)
        {
            gameGrid = new string[gridSize, gridSize];
            randomSeed = Environment.TickCount;
            random = new Random(randomSeed);
        }

        public void PrintGridToConsole()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.gameGrid.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameGrid.GetLength(1); j++)
                {
                    if (j + 1 == this.gameGrid.GetLength(1))
                        sb.Append($"{this.gameGrid[i, j]}\n");
                    else
                        sb.Append($"{this.gameGrid[i, j]} ");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
