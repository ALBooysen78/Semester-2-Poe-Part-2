using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    class Gold : Item
    {
        private int goldAmount;
        private static Random rnd = new Random();
        
        public int GetGoldAmount()
        {
            return goldAmount;
        }

        public int GoldAmount { get { return goldAmount; } set { goldAmount = value; } }

        public override string ToString()
        {
            return "Gold";
        }

        public Gold(int X, int Y,string symbol) : base(X, Y, "G ")
        {
            this.x = X;
            this.y = Y;
            goldAmount = rnd.Next(1, 6);
            this.symbol = "G ";
        }

    }
}
