using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    public class Obstacle : Tile
    { 
        public Obstacle(int X, int Y) : base(X,Y)
        {
            //obstacle constructor 1
        }

        public Obstacle(int X, int Y, string symbol) : base(X, Y, "X ")
        {
            //obstacle constructor 2
        }

        public Obstacle(int X, int Y, string symbol, tileType tile) : base(X, Y, "X", tile)
        {
            //obstacle constructor 3
        }
    }
}
