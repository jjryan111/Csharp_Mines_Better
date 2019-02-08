using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class GetSetupInput
    {
        private GameStats gameStats = new GameStats();
        
        public GetSetupInput(GameStats gameStats)
        {
            this.gameStats = gameStats;
  
        }
        
        public int[,] GetBoard (int[,] board)
        {
            MakeBoard mb = new MakeBoard(gameStats);
            int maxBombs = 0;
            board = GetBoardSize();
            maxBombs = MaxNumBombs(board);
            gameStats.mines = NumOfBombs(maxBombs);
            board = mb.Setup(board);
            return board;
        }
        private int [,] GetBoardSize()
        {
            int row = GetBoardRows(gameStats.maxRows);
            int col = GetBoardCols(gameStats.maxCols);
            gameStats.backBoardRows = row + 2;
            gameStats.backBoardCols = col + 2;
            int[,] gameBoard = new int[gameStats.backBoardRows, gameStats.backBoardCols];
            return gameBoard;
        }
        
        private int GetBoardRows(int maxRows)
        {
            int row = 0;
            bool isNum = false;
            while (!isNum)
            {
                Console.Write("Please enter the number of rows: ");
                isNum = int.TryParse(Console.ReadLine(), out row);
                if (!isNum || (row > maxRows))
                {
                    isNum = false;
                    Console.WriteLine("Invalid input. Try again.");
                }
                
            }
            return row;
        }

        private int GetBoardCols(int maxCols)
        {
            int col = 0;
            bool isNum = false;
            while (!isNum)
            {
                Console.Write("Please enter the number of columns: ");
                isNum = int.TryParse(Console.ReadLine(), out col);
                if (!isNum || (col > maxCols))
                {
                    isNum = false;
                    Console.WriteLine("Invalid input. Try again.");
                }

            }
            return col;
        }

        public int MaxNumBombs(int[,] blankboard)
        {
            int maxBombs = ((blankboard.GetLength(0)-2) * (blankboard.GetLength(1)-2))/3;
            return maxBombs;
        }

        public int NumOfBombs(int maxBombs)
        {

            bool isNum = false;
            while (!isNum)
            {
                Console.Write("Please enter the number of bombs (max {0}): ", maxBombs);
                isNum = int.TryParse(Console.ReadLine(), out gameStats.mines);
                if (!isNum || (gameStats.mines > maxBombs))
                {
                    Console.WriteLine("Invalid input.");
                    isNum = false;
                }
            }
            return gameStats.mines;
        }
    }
}
