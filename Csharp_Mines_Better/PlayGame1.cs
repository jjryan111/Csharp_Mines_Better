using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Blow_Me_up
{
    class PlayGame1
    {

        private int flagsOnBombs = 0;
        private WinLose gameState = new WinLose();
        private GameStats gameStats = new GameStats(0,0,0);

        public PlayGame1(WinLose gameState, GameStats gameStats)
        {
            this.gameState = gameState;
            this.gameStats = gameStats;
        }

        public int[,] MakePlay(List<int> myPlay, int[,] gameBoard)
        {
            if (myPlay[2] == 1)
            {
                CellPlay(myPlay, gameBoard);
            }
            else if (myPlay[2]== 2)
            {
                FlagPlay(myPlay, gameBoard);
            }
            else
            {
                Console.WriteLine("Invalid Play. How did we get here?");
            }
            return gameBoard;
        }

        private int[,] FlagPlay(List <int> play, int [,] gameBoard)
        {
            int x = play[0] - 64;
            int y = play[1];
            gameBoard[x, y] += 50;
            if (gameBoard[x, y] > 99 && gameBoard[x, y] < 200)
            {
                flagsOnBombs++;
                Console.WriteLine(flagsOnBombs);
                if(flagsOnBombs == gameStats.mines)
                {
                    gameState.GameOver("You WIN!!!");
                }
            }
            return gameBoard;

        }

        private int[,] CellPlay(List <int> play, int[,] gameBoard)
        {
            int x = play[0] - 64;
            int y = play[1];
            int playFlag = play[2];
            if (gameBoard[x, y] >= 10 && gameBoard[x, y] < 20)
            {
                Console.WriteLine("Square already played.");
            }
            else if (gameBoard[x,y] == 0)
            {
                RevealZeroRec(gameBoard, x, y);
            }
            
            else if (gameBoard[x, y] > 0 && gameBoard[x, y] < 10)
            {
                gameBoard[x, y] += 10;
            }

            else if (gameBoard[x,y] > 99)
            {
                gameBoard[x, y] = 1000;
                gameState.GameOver("BOOM!");
            }
            return gameBoard;
        }

        private int[,] RevealZeroRec(int [,] board, int i, int j)
        {

            if (board[i, j] == 0)
            {
                board[i, j] += 10;
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        RevealZeroRec(board, (i + k), (j + l));
                    }
                }
            }
            else
            {
                if (board[i, j] < 10)
                {
                    board[i, j] += 10;
                }
            }
            return board;
        }

        
    }
}
