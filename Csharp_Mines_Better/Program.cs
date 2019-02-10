using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class Program
    {//GIT YOU'RE A GIT
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
