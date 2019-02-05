using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Blow_Me_up
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
            bool done = false;
            char playType = ' ';
            while (!done)
            {
            Console.Write("(P)lay or (F)lag? ");
                        playType = Convert.ToChar(Console.ReadLine().ToUpper());
                if (playType == 'F' || playType == 'P')
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid play. Try again.");
                }
            }
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
    }
}
