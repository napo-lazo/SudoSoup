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

        private EventManager()
        {

        }

        public static EventManager GetEventManager()
        {
            if (current == null)
                current = new EventManager();

            return current;
        }

        public void FilledSudokuCell(int cellIndex, string cellValue)
        {
            OnFilledSudokuCell?.Invoke(cellIndex, cellValue);
        }

        public void GameCompleted()
        {
            OnGameCompleted?.Invoke();
        }
    }
}
