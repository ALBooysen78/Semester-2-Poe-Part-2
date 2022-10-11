using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    class SwampCreature : Enemy
    {
        public SwampCreature(int X, int Y) : base(X, Y, 1, 10, 10, "SC")
        {
            //swamp creature constructor
        }
        public override movement ReturnMove(movement enemyMovementSwampCreature)
        {   //creating random enemy movement
            Random rnd = new Random();
            int randomEnemyMovementDirection = rnd.Next(5);

            switch (randomEnemyMovementDirection)   //allowing enemies to move if they are unobstructed
            {
                case 0:
                    if ((this.VISION[0] is Obstacle) || (this.VISION[0] is Hero))            // !Hero and !Obstacle do not work
                    {
                        //how do I make it loop?
                        break;
                    }
                    else { enemyMovementSwampCreature = movement.up; }
                    break;
                case 1:
                    if ((this.VISION[1] is Obstacle) || (this.VISION[1] is Hero))            // !Hero and !Obstacle do not work
                    {
                        break;
                    }
                    else { enemyMovementSwampCreature = movement.down; }

                    break;
                case 2:
                    if ((this.VISION[2] is Obstacle) || (this.VISION[2] is Hero))            // !Hero and !Obstacle do not work
                    {
                        break;
                    }
                    else { enemyMovementSwampCreature = movement.left; }

                    break;
                case 3:
                    if ((this.VISION[3] is Obstacle) || (this.VISION[3] is Hero))            // !Hero and !Obstacle do not work
                    {
                        break;
                    }
                    else { enemyMovementSwampCreature = movement.right; }

                    break;
                case 4:
                    if ((this.VISION[4] is Obstacle) || (this.VISION[4] is Hero))            // !Hero and !Obstacle do not work
                    {
                        break;
                    }
                    else { enemyMovementSwampCreature = movement.NoMovement; }

                    break;
            }
            return enemyMovementSwampCreature;
        }
    }
}
