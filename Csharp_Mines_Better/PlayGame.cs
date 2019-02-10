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
        private Validator setupInput = new Validator();
        private GetGameInput ginp = new GetGameInput();
        private DisplayBoard db = new DisplayBoard();

        public PlayGame(GameStats gameStats)
        {
            this.gameStats = gameStats;
        }

        public void Game(int[,] gameBoard)
        {
            while (!gameState.done)
            {
                Console.Clear();
                db.PrintFrontBoard(gameBoard);
                int[] myPlay = new int[3];
                myPlay = ginp.GetPlay((gameBoard.GetLength(0) - 2), (gameBoard.GetLength(1) - 2));
                gameBoard = MakePlay(myPlay, gameBoard);
            }
        }

        public int[,] MakePlay(int[] myPlay, int[,] playGameBoard)
        {
            if (myPlay[2] == 1)
            {
                CellPlay(myPlay, playGameBoard);
            }
            else if (myPlay[2]== 2)
            {
                FlagPlay(myPlay, playGameBoard);
            }
            else
            {
                gameState.GameOver("Invalid code in MakePlay", playGameBoard);
            }
            return playGameBoard;
        }

        private int[,] FlagPlay(int[] play, int [,] flagGameBoard)
        {
            int x = play[0] - 64;
            int y = play[1];
            if ((flagGameBoard[x, y] > 20 && flagGameBoard[x, y] < 100) || (flagGameBoard[x, y] >= 150 && flagGameBoard[x, y] < 200))
            {
                flagGameBoard = RemoveFlag(flagGameBoard, x, y);

            }
            else
            {
                flagGameBoard[x, y] += 50;
                if (flagGameBoard[x, y] > 99 && flagGameBoard[x, y] < 120)
                {
                    gameStats.flagsOnBombs++;
                    Console.WriteLine(gameStats.flagsOnBombs);
                    if (gameStats.flagsOnBombs == gameStats.mines)
                    {
                        gameState.GameOver("You WIN!!!", flagGameBoard);
                    }
                }
            }
            return flagGameBoard;

        }

        private int[,] RemoveFlag (int[,] rfGameBoard, int x, int y)
        {
           
            char rFlag = setupInput.ValidateInput("Remove Flag? ", 'Y', 'N', false);
            if (rFlag == 'Y')
            {
                rfGameBoard[x, y] -= 50;
                if (rfGameBoard[x, y] > 150)
                {
                    gameStats.flagsOnBombs--;
                }
            }
            else if (rFlag == 'N')
            {
                Console.WriteLine("Canceled.");
            }
            else
            {
                Console.WriteLine("Invalid code in RemoveFlag2", rfGameBoard);
            }
           
            return rfGameBoard;
        }

        private int[,] CellPlay(int[] play, int[,] cpGameBoard)
        {
            int x = play[0];
            int y = play[1];
            int playFlag = play[2];
            if (cpGameBoard[x, y] >= 10 && cpGameBoard[x, y] < 20)
            {
                Console.WriteLine("Square already played.");
            }
            else if (cpGameBoard[x,y] == 0)
            {
                RevealZeroRec(cpGameBoard, x, y);
            }
            
            else if (cpGameBoard[x, y] > 0 && cpGameBoard[x, y] < 10)
            {
                cpGameBoard[x, y] += 10;
            }

            else if (cpGameBoard[x,y] > 99)
            {
                cpGameBoard[x, y] = 1000;
                gameState.GameOver("BOOM!", cpGameBoard);
            }
            else
            {
                gameState.GameOver("Invalid code in CellPlay.", cpGameBoard);
            }
            return cpGameBoard;
        }

        private int[,] RevealZeroRec(int [,] rzGameBoard, int i, int j)
        {

            if (rzGameBoard[i, j] == 0)
            {
                rzGameBoard[i, j] += 10;
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        RevealZeroRec(rzGameBoard, (i + k), (j + l));
                    }
                }
            }
            else
            {
                if (rzGameBoard[i, j] < 10)
                {
                    rzGameBoard[i, j] += 10;
                }
                if (rzGameBoard[i, j] > 200)
                {
                    gameState.GameOver("Invalid code in RevealZeroRec.", rzGameBoard);
                }
            }
            return rzGameBoard;
        }
    }
}
