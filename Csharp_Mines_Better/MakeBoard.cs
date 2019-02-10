using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class MakeBoard
    {
        private Random n = new Random();
        public MakeBoard()
        {// GIT YOU'RE A GIT
        
        }

        public int[,] MakeGameBoard(int[,] initialBoard, int mines)
        {
            initialBoard = AddEdges(initialBoard); // Add user inaccessible around the board
            initialBoard = AddMines(initialBoard, mines); // Adds mines to the user board
            initialBoard = AddNumbers(initialBoard); // Add numbers around the mines signifying how many adjacent mines
            return initialBoard;
        }

        public int[,] AddEdges(int[,] board) // Adds borders around the board the user selects
        {                                    // This insures that the user input will never run beyond the board array
            for (int i = 0; i < board.GetLength(1); i++)
            {
                board[0, i] = 20; // Border cell values > 18  and < 50 insure they can't be mistaken for game cells
                board[(board.GetLength(0) - 1), i] = 20;
            }
            for (int j = 0; j < board.GetLength(0); j++)
            {
                board[j, 0] = 20;
                board[j, (board.GetLength(1) - 1)] = 20;
            }
            return board;
        }

        public int[,] AddMines(int[,] board, int numMines)
        {
            int x = (board.GetLength(0) - 1);
            int y = (board.GetLength(1) - 1);
            while (numMines != 0) //While there are mines left to place
            {// go to a random spot on the board
                int index1 = n.Next(1, x);
                int index2 = n.Next(1, y);
                if (board[index1, index2] == 0)
                {/* and put a mine there. Because of the indices used to generate the random numbers
                 * you will never put a mine in an edge or a corner of the back end board
                 * Since the user only sees the interior of the board that means none
                 * of the things we do next will run over an edge or a corner
                 */
                    board[index1, index2] = 100; // Any cell value >= 100 is a mine
                    numMines--;
                }
            }
            return board;
        }

        public int[,] AddNumbers(int[,] board) // Puts numbers in the squares surrounding the mines
        {
            for (int i = 1; i < (board.GetLength(0) - 1); i++)
            {
                for (int j = 1; j < (board.GetLength(1) - 1); j++)
                {
                    if ((board[i, j] >= 100)) // If the cell is a mine
                    {
                        for (int k = -1; k < 2; k++)
                        {
                            for (int l = -1; l < 2; l++)
                            {
                                board[i + k, j + l]++;  // Add 1 to each of the surrounding squares
                            }                           // Adding 1 to mines or borders doesn't change anything
                        }
                    }
                }
            }
            return board;
        }
    }
}