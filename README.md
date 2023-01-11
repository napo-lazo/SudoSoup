# SudoSoup
 A simple window forms application that can generate puzzle games. Each game is randomly generated (a seed can be provided when creating the puzzle) using backtracking.
 
# Feautres
- Each can be played inside of the progam itself and configured to an extent depending of the game.
- The games can generate a PDF file containing the puzzle, their appendixes (if any), and the solution to the puzzle.
- Currently there are two puzzle games implemented:
  - Sudoku
  - Wordsoup 

# Plans for the future of the project
- A refactor of the structure of the code might be needed since currently some parts of it are tightly coupled and might bring some issues when trying to implement new games in the future.
- Alongside the changes to the design, a design doc will be created to document the project more thoroughly.
- The next game I'm planning on implementing is a crossword puzzle.
- I want to increase the amount of configurability when creating each game, adding more options like grid size or some sort of difficulty selector.
