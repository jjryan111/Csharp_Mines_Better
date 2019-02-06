using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class WinLose
    {
        public bool done = false;
        public WinLose() { }

        public void GameOver(string message)
        {

            done = true;
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
