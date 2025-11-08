using SudoSoup.Games;
using System;
using System.Text;
using System.Windows.Forms;

namespace SudoSoup
{
    public abstract class GameBase : IDisposable
    {
        #region Constants

        const string SUDOKU = "Sudoku";
        const string WORDSOUP = "Word Search";

        #endregion

        public string gameTitle;
        public string[,] gameGrid;
        public string[,] solutionGrid;
        public int randomSeed;
        protected Random random;
        protected EventManager eventMgr = EventManager.GetEventManager();
        public Form config;

        public static GameBase CreateGame(string gameName)
        {
            switch (gameName)
            {
                case SUDOKU:
                    return new SudokuGame();

                case WORDSOUP:
                    return new WordSoupGame();

                default:
                    throw new ArgumentException($"Name of game {gameName} is not supported");
            }
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
