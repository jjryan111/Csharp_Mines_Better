using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class WinLose
    {//GIT YOU'RE A GIT
        public bool done = false; // This determines when the game is over.
        private DisplayBoard db = new DisplayBoard();

        public WinLose()
        {

        }

        public void GameOver(string message, int[,] gameBoard)
        {
            done = true;
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine();
            db.PrintBackBoard(gameBoard);
        }
    }
}
