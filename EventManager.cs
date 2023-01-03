using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoSoup
{
    public class EventManager
    {
        private static EventManager current;
        public event Action<int, string> OnFilledSudokuCell;
        public event Action OnGameCompleted;
        public event Action<int, string, bool> OnClickedWordsoupCell;
        public event Action<int, bool> OnUpdateCellColor;
        public event Action<List<int>> OnMarkCellAsUsed;

        private EventManager()
        {

        }

        public static EventManager GetEventManager()
        {
            if (current == null)
                current = new EventManager();

            return current;
        }

        public void ClickedWordsoupLabel(int cellIndex, string cellValue, bool isPartOfCompletedWord)
        {
            OnClickedWordsoupCell?.Invoke(cellIndex, cellValue, isPartOfCompletedWord);
        }

        public void FilledSudokuCell(int cellIndex, string cellValue)
        {
            OnFilledSudokuCell?.Invoke(cellIndex, cellValue);
        }

        public void MarkCellAsUsed(List<int> cellIndexes)
        {
            OnMarkCellAsUsed?.Invoke(cellIndexes);
        }

        public void UpdateCellColor(int cellIndex, bool toggleBold)
        {
            OnUpdateCellColor?.Invoke(cellIndex, toggleBold);
        }

        public void GameCompleted()
        {
            OnGameCompleted?.Invoke();
        } 
    }
}
