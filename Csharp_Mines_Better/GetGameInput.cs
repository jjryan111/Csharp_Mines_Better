using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class GetGameInput
    {
        public GetGameInput() { }

        public List<int> GetPlay(int rows, int cols)
        {
            int playRowInt = GetRowPlay(rows);
            int playCol = GetColPlay(cols);
            int playType = GetCellPlay();
            List<int> play = new List<int>();
            
            play.Add(playRowInt);
            play.Add(playCol);
            play.Add(playType);
            return play;
        }

        private int GetRowPlay(int rows)
        {
            char rowMaxLetter = (char)(65 + (rows - 1));
            bool done = false;
            int playRowInt = 0;
            string playRow = "";
            while (!done)
            {
                Console.Write("Enter the row (A - {0}): ", rowMaxLetter);
                playRow = Console.ReadLine().ToUpper();
                if (playRow.Length == 1)
                {
                    playRowInt = Convert.ToInt16(Convert.ToChar(playRow));
                    if (playRowInt >= 65 && playRowInt <= rowMaxLetter)
                    {
                        done = true;
                    }
                    else
                    {
                        done = false;
                        Console.WriteLine("Enter a letter between A and {0}. Try again.", rowMaxLetter);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Must be exactly one character between A and {0}. Try again.", rowMaxLetter);
                }
            }
            return playRowInt;
        }
        private int GetColPlay(int cols)
        {
            bool done = false;
            bool isNum = false;
            int playCol = 0;
            while (!done)
            {
                Console.Write("Enter the column (1 - {0}): ", cols);
                isNum = int.TryParse(Console.ReadLine(), out playCol);
                if (playCol > 0 && playCol <= cols)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid column. Try again.");
                }
            }
            return playCol;
        }

        private int GetCellPlay()
        {
            int playTypeInt = 0;
            
            char playType = ' ';
            
            playType = ValInput("(P)lay or (F)lag? ", 'P', 'F');
            if (playType == 'P')
            {
                playTypeInt = 1;
            }
            else
            {
                playTypeInt = 2;
            }
            return playTypeInt;
        }

        public char ValInput(string message, char charLow, char charHigh)
        {
            string inp = "";
            char charInp = ' ';
            bool done = false;
            Console.Write(message);
            while (!done)
            {
                inp = Console.ReadLine().ToUpper();
                if (inp.Length == 1)
                {
                    charInp = Convert.ToChar(inp);
                    if (charInp  == charLow || charInp == charHigh)
                    {
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Must be exactly {0} or {1}. Try again.", charLow, charHigh);
                        Console.Write(message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Must be exactly one character, {0} or {1}. Try again.", charLow, charHigh);
                    Console.Write(message);
                }
            }
            return charInp;
        }
    }
}
