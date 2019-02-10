using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class Program
    {//GIT YOU'RE A GIT
        /* Users choose to flag or reveal cells on a gameboard to simulate finding mines on a minefield
         * Easy enough. From a back end perspective you need to know the following:
         *  - The board is a 2D integer array
         *  - The board has a border around it which is inaccessible to the player
         *      This prevents users from going outside the boundaries of the array
         *  - Back end board values are as follows:
         *      0           Blank cell. Unrevealed
         *      1-8         Number indicates how many mines are adjacent to this cell. Unrevealed
         *      10          Blank Cell. Revealed
         *      11-18       Number indicates how many mines are adjacent to this cell. Revealed
         *      20          Array border cell
         *      50-59       Flagged cell (not on a mine)
         *      100 - 108   Mine. For ease in adding the adjacent numbers (1-8 & 11-18 above)
         *                    mines are incremented to reflect adjacent mines
         *      150 - 158   Flagged cell (on a mine)
         *      1000        End game case where the user played a mine cell (loss)
         */
        static void Main(string[] args)
        {
            int[,] gameBoard = new int[0, 0];
            GameStats gameStats = new GameStats();
            PlayGame game = new PlayGame(gameStats);

            gameBoard = gameStats.GetBoard();
            game.Game(gameBoard);
            Console.ReadLine();
        }
    }
}
