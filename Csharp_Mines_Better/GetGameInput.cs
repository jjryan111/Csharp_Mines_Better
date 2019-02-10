using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class GetGameInput
    {
        private Validator isValid = new Validator();  

        public GetGameInput()
        {

        }

        public int[] GetPlay(int rows, int cols) //Gets a 3 character array with row, column, and (play or flag)
        {
            char endRow = (char)(65 + (rows - 1)); //Gets letter value of the end row. ASCII 65 is 'A'
            char endCol = (char)(((cols - 1) + 49)); //Gets a character value of the end column. ASCII 49 is '1'
            int[] play = new int[3];
            play[0] = Convert.ToInt16((isValid.ValidateInput("Enter Row: ", 'A', endRow, true)) - 64);
            play[1] = Convert.ToInt16((isValid.ValidateInput("Enter Column: ", '1', endCol, true)) - 48);
            play[2] = GetCellPlay();
            return play;
        }

        private int GetCellPlay() // Get the play type made, either Play (reveal the cell) or Flag (Mark it as a mine)
        {
            int playTypeInt = 0;
            char playType = isValid.ValidateInput("(P)lay or (F)lag? ", 'P', 'F', false); // Validates input, Returns a P or an F
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
