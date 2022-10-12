using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    public abstract class Item : Tile
    {
        public Item(int X, int Y, string symbol) : base(X, Y, symbol)
        {
            //item  constructor
        }

        public abstract override string ToString();



    }
}
