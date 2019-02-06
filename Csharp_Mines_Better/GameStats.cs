using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Mines_Better
{
    class GameStats
    {
        private int maxRows = 12;
        private int maxCols = 12;
        public int rows = 0;
        public int cols = 0;
        public int mines = 0;
        public GameStats(int rows, int cols, int mines)
        {
            this.rows = rows;
            this.cols = cols;
            this.mines = mines;
        }
    }
}
