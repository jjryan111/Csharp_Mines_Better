using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Blow_Me_up
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
            PlayGame1 game = new PlayGame1(wonLost, gstats);
            while (!wonLost.done)
            {
             //   Console.Clear();
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

            // board.GameBoard()
            //PlayGameOld newGame = new PlayGameOld();
            //int size = newGame.GetSize();
            //int bomb = newGame.GetBomb();
            //int[,] arr1 = new int[size + 2, size + 2];
            //arr1 = board.AddEdges(arr1);
            //arr1 = board.AddMines(arr1, bomb);
            //int[,] backBoard = board.GameBoard(arr1);
            //int[,] originalboard = arr1;
            //bool cont = true;

            //string[,] playerBoard = newGame.MakeBoard();
            //while (cont)
            //{
            //    int[] choices = newGame.GetChoice();
            //    playerBoard = newGame.UpdateBoard(backBoard, playerBoard, choices, bomb);

            //    newGame.PrintBoard(playerBoard);

            //    Console.WriteLine();
            //    if (playerBoard[0, 0] == "1")
            //    {
            //        cont = false;

            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("\n");
            //newGame.PrintFinalBoard(backBoard);
            //Console.ReadLine();
        }
    }
}
