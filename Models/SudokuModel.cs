using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup.Models
{
    public class SudokuModel
    {
        public string[,] puzzle { get; set; }
        public string[,] solution { get; set; }
    }
}
