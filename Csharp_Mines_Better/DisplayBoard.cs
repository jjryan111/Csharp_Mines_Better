using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class DisplayBoard
    {
        public DisplayBoard()
        {

        }

        public void PrintHeader(int[,] board) //Prints the line of numbers ont he top of the board
        {
            Console.Write("\t");
            for (int i = 1; i < (board.GetLength(1)-1); i++)
            {
                Console.Write("{0}\t",i);
            }
            Console.WriteLine();
            Console.Write("   "); // so that the spacing comes out right at the top left corner
            for (int j = 1; j < (board.GetLength(1)-1); j++)
            {
                Console.Write("________"); // Top border 
            }
            Console.WriteLine();
        }

        public void PrintFrontBoard(int[,] board) // Prints the board the user sees
        {
            PrintHeader(board); // Prints the numbers across the top and top border

            for (int i = 1; i < board.GetLength(0)-1; i++)
            {
                Console.Write("{0} |\t", (char)(65 + (i - 1))); // Prints the row letter designations, 
                                                                //starting with the ASCII character value for A
                for (int j = 1; j < board.GetLength(1)-1; j++)
                {
                    if (board[i, j] == 10) // A revealed blank space
                    {
                        Console.Write(" \t");
                    }
                    else if(board[i,j]> 10 && board[i,j] < 20) // A space with a number value for the mines adjacent
                    {
                        Console.Write("{0}\t", (board[i,j]-10));
                    }
                    else if (board[i, j] > 20 && board[i, j] < 100) // A flagged space that's NOT a mine
                    {
                        Console.Write("F\t");
                    }
                    else if (board[i, j] > 125 && board[i, j] < 200) // A flagged space that IS a m ine
                    {
                        Console.Write("F\t");
                    }
                    else
                    {
                        Console.Write("#\t"); // An unrevealed space
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintBackBoard(int[,] board)  // Prints the solution board
        {
            PrintHeader(board); // Prints the numbers across the top and top border
            for (int i = 1; i < (board.GetLength(0)-1); i++)
            {
                Console.Write("{0} |\t", (char)(65 + (i - 1))); // Prints the row letter designations
                for (int j = 1; j < (board.GetLength(1)-1); j++)
                {
                    if (board[i, j] == 0 || board[i,j] == 10)
                    {
                        Console.Write(" \t"); // Prints blank spaces
                    }
                    else if (board[i, j] < 10)
                    {
                        Console.Write("{0}\t", board[i, j]); //Prints unrevealed number spaces
                    }
                    else if ((board[i, j] > 10) && (board[i, j] < 20))
                    {
                        Console.Write("{0}\t", (board[i, j] - 10));  // Prints revealed number spaces
                    }
                    else if ((board[i, j] > 20) && (board[i, j] < 100)) 
                    {
                        Console.Write("X\t"); // Prints incorrectly placed flags
                    }
                    else if (board[i,j] >= 100 && board[i, j] < 150) 
                    {
                        Console.Write("*\t"); // Prints unflagged bombs
                    }
                    else if (board[i, j] >= 150 && board[i, j] < 200) 
                    {
                        Console.Write("(*)\t"); // Prints correctly flagged bombs
                    }
                    else if (board[i, j] == 1000)
                    {
                        Console.Write("BOOM\t"); // If you hit a mine prints location
                    }
                    else
                    {
                        Console.Write("Err\t", board[i,j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
