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

        public void PrintHeader(int[,] board)
        {
            Console.Write("\t");
            for (int i = 1; i < (board.GetLength(1)-1); i++)
            {
                Console.Write("{0}\t",i);
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int j = 1; j < (board.GetLength(1)-1); j++)
            {
                Console.Write("________");
            }
            Console.WriteLine();
        }

        public void PrintFrontBoard(int[,] board)
        {
            PrintHeader(board);

            for (int i = 1; i < board.GetLength(0)-1; i++)
            {
                Console.Write("{0} |\t", (char)(65 + (i - 1)));
                for (int j = 1; j < board.GetLength(1)-1; j++)
                {
                    if (board[i, j] == 10)
                    {
                        Console.Write(" \t");
                    }
                    else if(board[i,j]> 10 && board[i,j] < 20)
                    {
                        Console.Write("{0}\t", (board[i,j]-10));
                    }
                    else if (board[i, j] > 20 && board[i, j] < 100)
                    {
                        Console.Write("F\t");
                    }
                    else if (board[i, j] > 125 && board[i, j] < 200)
                    {
                        Console.Write("F\t");
                    }
                    else
                    {
                        Console.Write("#\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintBackBoard(int[,] board)
        {
            PrintHeader(board);
            for (int i = 1; i < (board.GetLength(0)-1); i++)
            {
                Console.Write("{0} |\t", (char)(65 + (i - 1)));
                for (int j = 1; j < (board.GetLength(1)-1); j++)
                {
                    if (board[i, j] == 0 || board[i,j] == 10)
                    {
                        Console.Write(" \t");
                    }
                    else if (board[i, j] < 10)
                    {
                        Console.Write("{0}\t", board[i, j]);
                    }
                    else if ((board[i, j] > 10) && (board[i, j] < 20))
                    {
                        Console.Write("{0}\t", (board[i, j] - 10));
                    }
                    else if ((board[i, j] > 20) && (board[i, j] < 100))
                    {
                        Console.Write("X\t");
                    }
                    else if (board[i,j] >= 100 && board[i, j] < 150)
                    {
                        Console.Write("*\t");
                    }
                    else if (board[i, j] >= 150 && board[i, j] < 200)
                    {
                        Console.Write("(*)\t");
                    }
                    else if (board[i, j] == 1000)
                    {
                        Console.Write("BOOM\t");
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
