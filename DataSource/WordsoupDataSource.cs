using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudoSoup.Games;
using SudoSoup.Models;

namespace SudoSoup.DataSource
{
    public static class WordsoupDataSource
    {
        public static WordsoupModel GetWordsoupModel(WordSoupGame wordSoup)
        {
            return new WordsoupModel
            {
                puzzle = wordSoup.gameGrid,
                randomSeed = wordSoup.randomSeed.ToString(),
                wordList = wordSoup.wordList,
                puzzleSolution = wordSoup.solutionGrid
            };
        }
    }
}
