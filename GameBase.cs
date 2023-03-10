using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudoSoup
{
    public abstract class GameBase : IDisposable
    {
        public string gameTitle;
        public string[,] gameGrid;
        public int randomSeed;
        protected Random random;
        protected EventManager eventMgr = EventManager.GetEventManager();
        public Form config;

        protected GameBase()
        {
            gameGrid = new string[9,9];
        }

        protected GameBase(int gridSize)
        {
            gameGrid = new string[gridSize, gridSize];
        }

        protected void InitializeRandomizer(int? seed)
        {
            if (seed != null)
                this.randomSeed = (int)seed;
            else
                this.randomSeed = Environment.TickCount;

            this.random = new Random(this.randomSeed);
        }

        public abstract void GenerateGridValues();

        public abstract void ClearGridValues();

        public abstract void SetConfiguration();

        public abstract Control GetGridCellControl(string cellValue);

        public abstract void GeneratePDF(string filename);

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

        public abstract void Dispose();
    }
}
