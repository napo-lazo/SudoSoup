﻿using SudoSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup.DataSource
{
    public static class SudokuDataSource
    {
        public static SudokuModel GetSudokuModel(SudokuHelper sudoku)
        {
            return new SudokuModel
            {
                puzzle = sudoku.gameGrid
            };
        }
    }
}