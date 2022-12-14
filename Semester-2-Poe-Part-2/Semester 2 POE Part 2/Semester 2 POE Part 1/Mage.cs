using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    class Mage : Enemy
    {
        public Mage(int X, int Y) : base(X, Y, 5, 5, 5, "M ")
        {
            //Mage constructor
        }
        public Mage(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol) : base(X, Y, 5, HP, 5, "M ")
        {
            //Mage constructor
        }

        public override movement ReturnMove(movement enemyMovementMage)
        {
            return 0;
        }

        public override bool CheckRange(Character target)
        {

            if (DistanceTo(target) <= 1 && DistanceTo(target) > 0)
            {
                return true;
            }
            if(     (target.X == this.X + 1 && target.Y == this.Y + 1) ||
                    (target.X == this.X + 1 && target.Y == this.Y - 1) ||
                    (target.X == this.X - 1 && target.Y == this.Y - 1)|| 
                    (target.X == this.X - 1 && target.Y == this.Y + 1)     )
            {
                return true;
            }
                return false;
        }

        private int DistanceTo(Character Target)
        {   //calculations for distance to 
            int distX;
            int distY;

            distX = Math.Abs(Target.X - this.X);
            distY = Math.Abs(Target.Y - this.Y);



            return distX + distY;
        }

       

    }//class
} // namespace
//private int InRange()
//{
//    int[] positionOne = new int[2];
//    positionOne[0] = this.X + 0;
//    positionOne[1] = this.Y + 1;

//    int[] positionTwo = new int[2];
//    positionTwo[0] = this.X + 1;
//    positionTwo[1] = this.Y + 1;


//    int[] positionThree = new int[2];
//    positionThree[0] = this.X + 1;
//    positionThree[1] = this.Y + 0;

//    int[] positionFour = new int[2];
//    positionFour[0] = this.X + 0;
//    positionFour[1] = this.Y - 1;

//    int[] positionFive = new int[2];
//    positionFive[0] = this.X + 0;
//    positionFive[1] = this.Y - 1;

//    int[] positionSix = new int[2];
//    positionSix[0] = this.X - 0;
//    positionSix[1] = this.Y - 1;

//    int[] positionSeven = new int[2];
//    positionSeven[0] = this.X - 1;
//    positionSeven[1] = this.Y + 0;

//    int[] positionEight = new int[2];
//    positionEight[0] = this.X - 1;
//    positionEight[1] = this.Y + 1;

//    return positionOne[0] + positionOne[1] +
//            positionTwo[0] + positionTwo[1] +
//            positionThree[0] + positionThree[1] +
//            positionFour[0] + positionFour[1] +
//            positionFive[0] + positionFive[1] +
//            positionSix[0] + positionSix[1] +
//            positionSeven[0] + positionSeven[1] +
//            positionEight[0] + positionEight[1];

//}