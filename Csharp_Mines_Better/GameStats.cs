using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class GameStats
    {
        private MakeBoard mb = new MakeBoard();
        private Validator setupInput = new Validator();
        public int maxRows = 9; // Maximum size of the board (rows)
        public int maxCols = 9; // Maximum size of the board (columns)
        public int flagsOnBombs = 0; // When a flag is played keep track of how many are on mines
        public int rows = 0; // Will hold the size of the board (rows)
        public int cols = 0; // Will hold the size of the board (columns)
        public int mines = 0; // The number of mines in the game
        public int backBoardRows = 0; // Size of the board + borders (rows)
        public int backBoardCols = 0; // Size of the board + borders (columns) 

        public GameStats()
        {

        }

        public int MaxNumBombs(int[,] blankboard)
        {
            int maxBombs = ((blankboard.GetLength(0) - 2) * (blankboard.GetLength(1) - 2)) / 3;
            return maxBombs;
        }

        public int[,] GetBoard()
        {
            char endRowChar = (char)(((maxRows) + 49));
            char endColChar = (char)(((maxCols) + 49));
            rows = Convert.ToInt16((setupInput.ValidateInput("Enter number of rows: ", '1', endRowChar, true)) - 49);
            cols = Convert.ToInt16((setupInput.ValidateInput("Enter number of columns: ", '1', endColChar, true)) - 49);
            backBoardRows = rows + 2;
            backBoardCols = cols + 2;
            int[,] gameBoard = new int[backBoardRows, backBoardCols];
            int maxBombs = MaxNumBombs(gameBoard);
            mines = NumOfBombs(maxBombs);
            gameBoard = mb.AddStuff(gameBoard, mines);
            return gameBoard;
        }

        public int NumOfBombs(int maxBombs)
        {

            bool isNum = false;
            while (!isNum)
            {
                Console.Write("Please enter the number of bombs (max {0}): ", maxBombs);
                isNum = int.TryParse(Console.ReadLine(), out mines);
                if (!isNum || (mines > maxBombs))
                {
                    Console.WriteLine("Invalid input.");
                    isNum = false;
                }
            }
            return mines;
        }
    }
}
