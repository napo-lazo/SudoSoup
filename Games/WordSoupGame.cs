using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;
using SudoSoup.ConfigurationForms;
using SudoSoup.Controllers;
using SudoSoup.DataSource;
using SudoSoup.Models;
using SudoSoup.PDFs;

namespace SudoSoup.Games
{
    public class WordSoupGame : GameBase
    {

        private readonly struct ValidStartingCell
        {

            public readonly int row;
            public readonly int column;
            public readonly int orientation;

            public ValidStartingCell(int row, int column, int orientation)
            {
                this.row = row;
                this.column = column;
                this.orientation = orientation;
            }
        }

        public string[] wordList;
        public string[,] solutionGrid;

        public WordSoupGame()
        {
            this.gameTitle = "Wordsoup";
            this.solutionGrid = new string[9, 9];
            this.config = new WordSoupConfiguration();
        }

        public override void ClearGridValues()
        {
            this.gameGrid = new string[9, 9];
            this.solutionGrid = new string[9, 9];
        }

        public override void GeneratePDF(string filename)
        {
            WordsoupModel wordsoupModel = WordsoupDataSource.GetWordsoupModel(this);
            WordsoupPDF document = new WordsoupPDF(wordsoupModel);
            document.GeneratePdf(filename);
        }

        public override void GenerateGridValues()
        {
            IterateWordList(0);

            Array.Copy(this.gameGrid, this.solutionGrid, 81);

            Dictionary<char, HashSet<char>> lettersToCheck = new Dictionary<char, HashSet<char>>();

            foreach (string word in this.wordList)
            {
                if (!lettersToCheck.ContainsKey(word[0]))
                    lettersToCheck.Add(word[0], new HashSet<char> { word[1] });
                else
                    lettersToCheck[word[0]].Add(word[1]);

                if (!lettersToCheck.ContainsKey(word[word.Length-1]))
                    lettersToCheck.Add(word[word.Length - 1], new HashSet<char> { word[word.Length - 2] });
                else
                    lettersToCheck[word[word.Length - 1]].Add(word[word.Length - 2]);
            }

            HashSet<char> alphabet = new HashSet<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int gridHeight = this.gameGrid.GetLength(0);
            int gridWidth = this.gameGrid.GetLength(1);

            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    if (string.IsNullOrWhiteSpace(this.gameGrid[i, j]))
                    {
                        HashSet<char> lettersToExclude = new HashSet<char>();
                        GetExcludedLetters(lettersToExclude, lettersToCheck, i, j, gridHeight - 1, gridWidth - 1);

                        alphabet.RemoveWhere(letter => lettersToExclude.Contains(letter));

                        this.gameGrid[i, j] = Convert.ToString(alphabet.ElementAt(this.random.Next(0, alphabet.Count)));

                        alphabet.UnionWith(lettersToExclude);
                    }
                }
            }
        }

        private void GetExcludedLetters(HashSet<char> lettersToExclude, Dictionary<char, HashSet<char>> lettersToCheck, int row, int col, int gridHeight, int gridWidth)
        {
            if (row > 0)
            {
                string letter = GetNextCellValue(row, col, 1, 1);
                if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                    lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);

                if (col < gridWidth)
                {
                    letter = GetNextCellValue(row, col, 2, 1);
                    if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                        lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);
                }
            }

            if (col < gridWidth)
            {
                string letter = GetNextCellValue(row, col, 3, 1);
                if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                    lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);

                if (row < gridHeight)
                {
                    letter = GetNextCellValue(row, col, 4, 1);
                    if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                        lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);
                }
            }

            if (row < gridHeight)
            {
                string letter = GetNextCellValue(row, col, 5, 1);
                if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                    lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);

                if (col > 0)
                {
                    letter = GetNextCellValue(row, col, 6, 1);
                    if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                        lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);
                }
            }

            if (col > 0)
            {
                string letter = GetNextCellValue(row, col, 7, 1);
                if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                    lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);

                if (row > 0)
                {
                    letter = GetNextCellValue(row, col, 8, 1);
                    if (!string.IsNullOrWhiteSpace(letter) && lettersToCheck.ContainsKey(Convert.ToChar(letter)))
                        lettersToExclude.UnionWith(lettersToCheck[Convert.ToChar(letter)]);
                }
            }
        }

        private bool IterateWordList(int index)
        {
            if (this.wordList.Length <= index)
                return false;

            string currentWord = this.wordList[index];
            List<ValidStartingCell> validCells;
            int currentWordSize = currentWord.Length;

            validCells = GenerateValidCells(currentWord, currentWordSize);

            if (validCells.Count == 0)
                return true;

            List<int> previouslyUsedIndexes = new List<int>();
            Nullable<ValidStartingCell> cellToTry = null;

            //Adding explicit casts cellToTry will only be null the first it enters the loop
            do
            {
                if (cellToTry != null)
                    RemoveWordFromGrid(currentWordSize, (ValidStartingCell)cellToTry, previouslyUsedIndexes);

                if (validCells.Count == 0)
                    return true;

                int indexToTry = this.random.Next(0, validCells.Count);
                cellToTry = validCells[indexToTry];
                validCells.RemoveAt(indexToTry);

                previouslyUsedIndexes = AddWordToGrid(currentWord, currentWordSize, (ValidStartingCell)cellToTry);

            } while (IterateWordList(index + 1));

            return false;
        }

        private List<ValidStartingCell> GenerateValidCells(string currentWord, int currentWordSize)
        {
            List<ValidStartingCell> validCells = new List<ValidStartingCell>();
            int gridHeight = this.gameGrid.GetLength(0);
            int gridWidth = this.gameGrid.GetLength(1);

            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    bool canMoveUpwards = currentWordSize <= i + 1;
                    bool canMoveRight = currentWordSize <= gridWidth - j;
                    bool canMoveDownwards = currentWordSize <= gridHeight - i;
                    bool canMoveLeft = currentWordSize <= j + 1;

                    if (canMoveUpwards && CheckWordPlacement(currentWord, currentWordSize, i, j, 1))
                        validCells.Add(new ValidStartingCell(i, j, 1));

                    if (canMoveUpwards && canMoveRight && CheckWordPlacement(currentWord, currentWordSize, i, j, 2))
                        validCells.Add(new ValidStartingCell(i, j, 2));

                    if (canMoveRight && CheckWordPlacement(currentWord, currentWordSize, i, j, 3))
                        validCells.Add(new ValidStartingCell(i, j, 3));

                    if (canMoveRight && canMoveDownwards && CheckWordPlacement(currentWord, currentWordSize, i, j, 4))
                        validCells.Add(new ValidStartingCell(i, j, 4));

                    if (canMoveDownwards && CheckWordPlacement(currentWord, currentWordSize, i, j, 5))
                        validCells.Add(new ValidStartingCell(i, j, 5));

                    if (canMoveDownwards && canMoveLeft && CheckWordPlacement(currentWord, currentWordSize, i, j, 6))
                        validCells.Add(new ValidStartingCell(i, j, 6));

                    if (canMoveLeft && CheckWordPlacement(currentWord, currentWordSize, i, j, 7))
                        validCells.Add(new ValidStartingCell(i, j, 7));

                    if (canMoveLeft && canMoveUpwards && CheckWordPlacement(currentWord, currentWordSize, i, j, 8))
                        validCells.Add(new ValidStartingCell(i, j, 8));
                }
            }

            return validCells;
        }

        private string GetNextCellValue(int startingRow, int startingColumn, int orientation, int offset)
        {
            switch (orientation)
            {
                case 1:
                    return this.gameGrid[startingRow - offset, startingColumn];
                case 2:
                    return this.gameGrid[startingRow - offset, startingColumn + offset];
                case 3:
                    return this.gameGrid[startingRow, startingColumn + offset];
                case 4:
                    return this.gameGrid[startingRow + offset, startingColumn + offset];
                case 5:
                    return this.gameGrid[startingRow + offset, startingColumn];
                case 6:
                    return this.gameGrid[startingRow + offset, startingColumn - offset];
                case 7:
                    return this.gameGrid[startingRow, startingColumn - offset];
                case 8:
                    return this.gameGrid[startingRow - offset, startingColumn - offset];
                default:
                    return string.Empty;
            }
        }

        private void SetNextCellValue(ValidStartingCell startingCell, int offset, string value)
        {
            switch (startingCell.orientation)
            {
                case 1:
                    this.gameGrid[startingCell.row - offset, startingCell.column] = value;
                    break;
                case 2:
                    this.gameGrid[startingCell.row - offset, startingCell.column + offset] = value;
                    break;
                case 3:
                    this.gameGrid[startingCell.row, startingCell.column + offset] = value;
                    break;
                case 4:
                    this.gameGrid[startingCell.row + offset, startingCell.column + offset] = value;
                    break;
                case 5:
                    this.gameGrid[startingCell.row + offset, startingCell.column] = value;
                    break;
                case 6:
                    this.gameGrid[startingCell.row + offset, startingCell.column - offset] = value;
                    break;
                case 7:
                    this.gameGrid[startingCell.row, startingCell.column - offset] = value;
                    break;
                case 8:
                    this.gameGrid[startingCell.row - offset, startingCell.column - offset] = value;
                    break;
            }
        }

        private bool CheckWordPlacement(string currentWord, int currentWordSize, int startingRow, int startingColumn, int orientation)
        {
            int repeatedLetters = 0;

            for (int i = 0; i < currentWordSize; i++)
            {
                string cellValue = GetNextCellValue(startingRow, startingColumn, orientation, i);

                if (!string.IsNullOrWhiteSpace(cellValue))
                    if (Convert.ToString(currentWord[i]) != cellValue)
                        return false;
                    else
                        repeatedLetters++;
            }

            if (repeatedLetters == currentWordSize)
                return false;

            return true;
        }

        private List<int> AddWordToGrid(string currentWord, int currentWordSize, ValidStartingCell cellToTry)
        {
            List<int> previouslyUsedIndexes = new List<int>();

            for (int i = 0; i < currentWordSize; i++)
            {
                if (GetNextCellValue(cellToTry.row, cellToTry.column, cellToTry.orientation, i) == null)
                    SetNextCellValue(cellToTry, i, Convert.ToString(currentWord[i]));
                else
                    previouslyUsedIndexes.Add(i);
            }

            return previouslyUsedIndexes;
        }

        private void RemoveWordFromGrid(int currentWordSize, ValidStartingCell cellToRemove, List<int> previouslyUsedIndexes)
        {
            for (int i = 0; i < currentWordSize; i++)
            {
                if (previouslyUsedIndexes.Count > 0 && previouslyUsedIndexes[0] == i)
                    previouslyUsedIndexes.RemoveAt(0);
                else
                    SetNextCellValue(cellToRemove, i, null);
                
            }
        }

        public override Control GetGridCellControl(string cellValue)
        {
            return new SudokuTextBox(cellValue);
        }

        public override void SetConfiguration()
        {
            InitializeRandomizer(((WordSoupConfiguration)config).seedValue);

            HashSet<string> uniqueWords = new HashSet<string>(((WordSoupConfiguration)config).wordList);
            this.wordList = uniqueWords.ToArray();
        }
    }
}
