using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup.Models
{
    public class WordsoupModel
    {
        public string[,] puzzle { get; set; }
        public string randomSeed { get; set; }
        public string[] wordList { get; set; }
    }
}
