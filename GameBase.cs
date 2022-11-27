using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup
{
    public class GameBase
    {
        public string[,] gameGrid;
        public int randomSeed;
        protected Random random;
        protected EventManager eventMgr = EventManager.GetEventManager();

        protected GameBase()
        {
            gameGrid = new string[9,9];
        }

        protected GameBase(int gridSize)
        {
            gameGrid = new string[gridSize, gridSize];
        }

        public void InitializeRandomizer(int? seed)
        {
            if (seed != null)
                this.randomSeed = (int)seed;
            else
                this.randomSeed = Environment.TickCount;

            this.random = new Random(this.randomSeed);
        }

        public virtual void GenerateGridValues()
        {
            throw new Exception("Method was not implemented");
        }

        public virtual void ClearGridValues()
        {
            throw new Exception("Method was not implemented");
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
