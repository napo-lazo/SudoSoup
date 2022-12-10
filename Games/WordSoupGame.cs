using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SudoSoup.ConfigurationForms;
using SudoSoup.Controllers;

namespace SudoSoup.Games
{
    public class WordSoupGame : GameBase
    {
        public WordSoupGame()
        {
            this.config = new WordSoupConfiguration();
        }

        public override void ClearGridValues()
        {
            throw new NotImplementedException();
        }

        public override void GenerateGridValues()
        {
            Console.WriteLine("Placeholder for Wordsoup GenerateGridValues implementation");
        }

        public override Control GetGridCellControl(string cellValue)
        {
            return new SudokuTextBox(cellValue);
        }

        public override void SetConfiguration()
        {
            Console.WriteLine("Placeholder for Wordsoup SetConfiguration implementation");
        }
    }
}
