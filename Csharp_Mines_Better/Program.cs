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
            GameStats gameStats = new GameStats();
            GetSetupInput inp = new GetSetupInput(gameStats);
            int[,] gameBoard = new int [0,0];
            PlayGame game = new PlayGame(gameStats);

            gameBoard = inp.GetBoard(gameBoard);
            game.Game(gameBoard);
            Console.ReadLine();
        }
    }
}
