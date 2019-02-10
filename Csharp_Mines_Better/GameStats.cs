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
        private Validator isValid = new Validator();
        private int minRows = 3; // Minimum size of the board (rows)
        private int minCols = 3; // Minimum size of the board (columns)
        private int maxRows = 9; // Maximum size of the board (rows). 9 chosen because the ASCII works out for the Validator
        private int maxCols = 9; // Maximum size of the board (columns)
        public int rows = 0; // Will hold the size of the board (rows)
        public int cols = 0; // Will hold the size of the board (columns)
        public int mines = 0; // Will hold the number of mines in the game
        private int backBoardRows = 0; // Size of the board + borders (rows)
        private int backBoardCols = 0; // Size of the board + borders (columns) 
        public int flagsOnBombs = 0; // When a flag is played will keep track of how many are on mines
        public int usedFlags = 0; // Holds how many non-bomb cells are flagged

        public GameStats()
        {

        }
        
        public int[,] GetBoard()
        {
            char minRowChar = (char)(((minRows) + 48)); // Gets the ASCII values for the integers
            char minColChar = (char)(((minCols) + 48));
            char maxRowChar = (char)(((maxRows) + 49));
            char maxColChar = (char)(((maxCols) + 49));
            rows = Convert.ToInt16((isValid.ValidateInput("Enter number of rows: ", minRowChar, maxRowChar, true)) - 48);
            cols = Convert.ToInt16((isValid.ValidateInput("Enter number of columns: ", minColChar, maxColChar, true)) - 48);
            backBoardRows = rows + 2; // The total game area has a border along all 4 sides of the board
            backBoardCols = cols + 2; // This prevents overruns on the board array
            int[,] gameBoard = new int[backBoardRows, backBoardCols];
            int maxBombs = MaxNumBombs(rows, cols);
            mines = NumOfBombs(maxBombs);
            gameBoard = mb.MakeGameBoard(gameBoard, mines);
            return gameBoard;
        }

        public int MaxNumBombs(int rows, int cols)
        { // This is pretty arbitrary but 1/3 of the board area for mines seems reasonable
            return ((rows) * (cols)) / 3;
        }

        public int NumOfBombs(int maxBombs)
        { // Not using the Validator because needs an integer value > 9
            bool isNum = false;
            while (!isNum)
            {
                Console.Write("Please enter the number of bombs (max {0}): ", maxBombs);
                isNum = int.TryParse(Console.ReadLine(), out mines);
                if (!isNum || (mines > maxBombs) || (mines < 1))
                {
                    Console.WriteLine("Invalid input.");
                    isNum = false;
                }
            }
            return mines;
        }
    }
}