using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class PlayGame
    {
        private WinLose gameState = new WinLose();
        private GameStats gameStats = new GameStats();
        private Validator isValid = new Validator();
        private GetGameInput gInput = new GetGameInput();
        private DisplayBoard db = new DisplayBoard();

        public PlayGame(GameStats gameStats)
        {
            this.gameStats = gameStats;
        }

        public void Game(int[,] gameBoard) // This is the actual game. Gets input and makes play
        {
            while (!gameState.done)
            {
                Console.Clear();
                db.PrintFrontBoard(gameBoard);
                int[] myPlay = new int[3]; // myPlay contains 3 elements, the row, column and the play type (play or flag)
                myPlay = gInput.GetPlay((gameStats.rows), (gameStats.cols));
                gameBoard = MakePlay(myPlay, gameBoard);
                
            }
        }

        public int[,] MakePlay(int[] myPlay, int[,] playGameBoard)
        {
            if (myPlay[2] == 1)  // If the 3rd element in myPlay is a 1, reveal the cell
            {
                CellPlay(myPlay, playGameBoard);
            }
            else if (myPlay[2]== 2) // If 2, flag the cell
            {
                FlagPlay(myPlay, playGameBoard);
            }
            else // Should never be anything else. For debugging
            {
                gameState.GameOver("Invalid code in MakePlay", playGameBoard);
            }
            return playGameBoard;
        }

        private int[,] FlagPlay(int[] play, int [,] flagGameBoard)
        {
            int x = play[0]; // The row to be played
            int y = play[1]; // the column to be played
            if ((flagGameBoard[x, y] > 20 && flagGameBoard[x, y] < 100) || (flagGameBoard[x, y] >= 150 && flagGameBoard[x, y] < 200))
            { // There's already a flag there.
                flagGameBoard = RemoveFlag(flagGameBoard, x, y);

            }
            else
            { // Add a flag
                gameStats.usedFlags++;
                flagGameBoard[x, y] += 50; 
                if (flagGameBoard[x, y] > 149 && flagGameBoard[x, y] < 200) // The cell has a bomb in it
                {
                    gameStats.flagsOnBombs++;
                    if (gameStats.flagsOnBombs == gameStats.mines) // Are there unflagged bombs left?
                    {
                        gameState.GameOver("You WIN!!!", flagGameBoard);
                    }
                }
            }
            if (gameStats.usedFlags == gameStats.mines) // If not a victory and you used all your flags
            {
                gameState.GameOver("You lose. No flags left and there are still mines.", flagGameBoard);
            }
            return flagGameBoard;
        }

        private int[,] RemoveFlag (int[,] rfGameBoard, int x, int y)
        {
           
            char rFlag = isValid.ValidateInput("Remove Flag? ", 'Y', 'N', false);
            if (rFlag == 'Y')
            { // If user wants to  remove a flag
                gameStats.usedFlags--;
                rfGameBoard[x, y] -= 50;
                if (rfGameBoard[x, y] > 150)
                {
                    gameStats.flagsOnBombs--;
                }
            }
            // Else do nothing
            return rfGameBoard;
        }

        private int[,] CellPlay(int[] play, int[,] cpGameBoard)
        { // Reveal what's in the cell
            int x = play[0]; // Row to be played
            int y = play[1]; // Column to be played
            if (cpGameBoard[x,y] == 0) // Blank cell revelaed. Check the surrounding cells for blank cells
            {
                RevealZeroRec(cpGameBoard, x, y);
            }
            else if (cpGameBoard[x, y] > 0 && cpGameBoard[x, y] < 10) // Number cell revealed
            {
                cpGameBoard[x, y] += 10;
            }
            else if (cpGameBoard[x,y] > 99) // Bomb revealed
            {
                cpGameBoard[x, y] = 1000;
                gameState.GameOver("BOOM!", cpGameBoard);
            }
            // Otherwise the cell has already been revealed. Do nothing
            return cpGameBoard;
        }

        private int[,] RevealZeroRec(int [,] rzGameBoard, int i, int j)
        { // Recursive function that will reveal the blank cells adjacent to a revealed blank cell
            if (rzGameBoard[i, j] == 0) // If the current cell is blank
            {
                rzGameBoard[i, j] += 10; // Reveal it
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    { // Look at all of the surrounding cells and call RevealZeroRec on them
                        RevealZeroRec(rzGameBoard, (i + k), (j + l));
                    }
                }
            }
            else // End condition. Cell has a number or has already been revealed
            {
                if (rzGameBoard[i, j] < 10)
                {
                    rzGameBoard[i, j] += 10;
                }
            }
            return rzGameBoard;
        }
    }
}