using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
     abstract class Gold : Item
    {
        private int goldAmount;

        private void createGoldAmountRandom()
        {
            Random rnd = new Random();
            int goldAmount = rnd.Next(0, 6);
            
        }

        public int GoldAmount { get { return goldAmount; } set { goldAmount = value; } }

        public abstract override string ToString();

        public Gold(int X, int Y,int goldAmount,string symbol) : base(X, Y, symbol)
        {
            this.x = X;
            this.y = Y;
            this.goldAmount = GoldAmount;
            this.symbol = "G";
        }

    }
}
