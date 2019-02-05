using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Blow_Me_up
{
    class GetSetupInput
    {
        MakeBoard mb = new MakeBoard();
        int maxRows = 12;
        int maxCols = 12;
        int numBombs = 0;

        public GetSetupInput()
        {
          
        }
        public int ReturnMines()
        {
            return numBombs;
        }
        public int[,] GetBoard (int[,] board)
        {        
            int maxBombs = 0;
            board = GetBoardSize(maxRows, maxCols);
            maxBombs = MaxNumBombs(board);
            numBombs = NumOfBombs(maxBombs);
            board = mb.Setup(board, numBombs);
            return board;
        }
        private int [,] GetBoardSize(int maxRows, int maxCols)
        {
            int row = GetBoardRows(maxRows);
            int col = GetBoardCols(maxCols);

            int[,] gameBoard = new int[(row+2), (col+2)];

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
                isNum = int.TryParse(Console.ReadLine(), out numBombs);
                if (!isNum || (numBombs > maxBombs))
                {
                    Console.WriteLine("Invalid input.");
                    isNum = false;
                }
            }
            return numBombs;
        }
    }
}
