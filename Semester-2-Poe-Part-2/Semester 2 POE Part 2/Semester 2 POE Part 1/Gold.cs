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

        private void createGoldAmountRandom()
        {
            Random rnd = new Random();
            goldAmount = rnd.Next(0, 6);
            
        }

        public int GetGoldAmount()
        {
            return goldAmount;
        }

        public int GoldAmount { get { return goldAmount; } set { goldAmount = value; } }

        public override string ToString()
        {
            return "Gold";
        }

        public Gold(int X, int Y,string symbol) : base(X, Y, symbol)
        {
            this.x = X;
            this.y = Y;
            createGoldAmountRandom();
            this.symbol = "G";
        }

    }
}
