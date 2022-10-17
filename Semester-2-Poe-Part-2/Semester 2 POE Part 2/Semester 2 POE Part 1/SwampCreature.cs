using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    class SwampCreature : Enemy
    {
        private static Random rndm = new Random();
        public SwampCreature(int X, int Y) : base(X, Y, 1, 10, 10, "SC")
        {
            //swamp creature constructor
        }

        public SwampCreature(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol) : base(X, Y, 1, HP, 10, "SC")
        {

        }
        public override movement ReturnMove(movement enemyMovementSwampCreature)
        {   //creating random enemy movement

            do
            {
                int randomVal;
                randomVal = rndm.Next(1, 5);
                enemyMovementSwampCreature = (Character.movement)randomVal;

                if (enemyMovementSwampCreature == movement.right)
                {
                    if (!(this.VISION[3] is Enemy) && !(this.VISION[3] is Hero) && !(this.VISION[3] is Obstacle))
                    {
                        enemyMovementSwampCreature = movement.right;
                    }
                    else enemyMovementSwampCreature = movement.NoMovement;
                }
                else if (enemyMovementSwampCreature == movement.left)
                {
                    if (!(this.VISION[2] is Enemy) && !(this.VISION[2] is Hero) && !(this.VISION[2] is Obstacle))
                    {
                        enemyMovementSwampCreature = movement.left;
                    }
                    else enemyMovementSwampCreature = movement.NoMovement;

                }
                else if (enemyMovementSwampCreature == movement.up)
                {
                    if (!(this.VISION[0] is Enemy) && !(this.VISION[0] is Hero) && !(this.VISION[0] is Obstacle))
                    {
                        enemyMovementSwampCreature = movement.up;
                    }
                    else enemyMovementSwampCreature = movement.NoMovement;

                }
                else if (enemyMovementSwampCreature == movement.down)
                {
                    if (!(this.VISION[1] is Enemy) && !(this.VISION[1] is Hero) && !(this.VISION[1] is Obstacle))
                    {
                        enemyMovementSwampCreature = movement.down;
                    }
                    else enemyMovementSwampCreature = movement.NoMovement;

                }
                else if (enemyMovementSwampCreature == movement.NoMovement)
                {
                    enemyMovementSwampCreature = movement.NoMovement;
                }

                
            } while (enemyMovementSwampCreature == movement.NoMovement);
            

            return enemyMovementSwampCreature;
        }
    }
    
}
