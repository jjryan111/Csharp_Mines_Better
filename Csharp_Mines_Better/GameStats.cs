using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class GameStats
    {
        public int maxRows = 12;
        public int maxCols = 12;
        public int flagsOnBombs = 0;
        public int rows = 0;
        public int cols = 0;
        public int mines = 0;
        public int backBoardRows = 0;
        public int backBoardCols = 0;
        public GameStats()
        {
            
        }
    }
}
