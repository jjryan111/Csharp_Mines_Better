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
            GetSetupInput inp = new GetSetupInput();
            DisplayBoard db = new DisplayBoard();
            WinLose wonLost = new WinLose();
            GetGameInput ginp = new GetGameInput();

            int[,] gameBoard = new int [0,0];
            gameBoard = inp.GetBoard(gameBoard);
            GameStats gstats = new GameStats(1,1,inp.ReturnMines());
            PlayGame1 game = new PlayGame1(wonLost, gstats, ginp);
            while (!wonLost.done)
            {
                Console.Clear();
                db.PrintBackBoard(gameBoard);
                Console.WriteLine();
                db.PrintFrontBoard(gameBoard);
                Console.WriteLine();
                Console.WriteLine(gstats.mines);
                List<int> myPlay = new List<int>();
                myPlay = ginp.GetPlay((gameBoard.GetLength(0) - 2), (gameBoard.GetLength(1) - 2));
                gameBoard = game.MakePlay(myPlay, gameBoard);
            }
            db.PrintBackBoard(gameBoard);
            Console.ReadLine();
        }
    }
}
