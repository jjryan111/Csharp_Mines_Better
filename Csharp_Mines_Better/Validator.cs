using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class Validator
    {
       
        public Validator()
        {
          
        }
        
        public char ValidateInput(string message, char charLow, char charHigh, bool between)
        {
            string inp = "";
            char charInp = ' ';
            int intLow = Convert.ToInt16(charLow);
            int intHigh = Convert.ToInt16(charHigh);
            int charInputInt = 0;
            bool done = false;

            while (!done)
            {
                Console.Write(message);
                inp = Console.ReadLine().ToUpper();
                if (inp.Length == 1)
                {
                    charInp = Convert.ToChar(inp);
                    charInputInt = Convert.ToInt16(charInp);
                    if (between)
                    {
                        if (charInputInt > 0 && (charInputInt >= intLow && charInputInt <= intHigh))
                        {
                            done = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Must be between {0} and {1}. Try again.", charLow, charHigh);
                        }
                    }
                    else if (charInp == charLow || charInp == charHigh)
                    {
                        done = true;
                    }
                    else
                    {
                        if (between)
                        {
                            Console.WriteLine("Invalid input. Must be exactly one character between {0} and {1}.", charLow, charHigh);
                        }

                        else
                        {
                            Console.WriteLine("Invalid input. Must be exactly {0} or {1}. Try again.", charLow, charHigh);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Must be exactly one character, {0} or {1}. Try again.", charLow, charHigh);
                }
            }
            return charInp;
        }
    }
}
