using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    internal class Hero : Character
    {

        public Hero(int X, int Y, int DAMAGE, int HP, int MaxHP, string symbol) : base(X, Y, DAMAGE, HP, MaxHP, "H ")
        {
            //hero contructor
        }
        public override string ToString()
        {
            //takes an displays the players information
            string heroInfo = "The heros stats: \n";
            heroInfo += "Hp: " + HP.ToString() +"/"+ maxHp.ToString() + "\n";
            heroInfo += "Damage is: " + Damage.ToString() + "\n";                       // heros to string
            heroInfo += "Coordinates: [" + X.ToString() + "," + Y.ToString() + "]";

            return heroInfo;
        }
        public override movement ReturnMove(movement heroMovement)
        { //heros return moveemthod overriding the original one
            //only allows movement if not obstructed by an enemy or obstacle
            if(heroMovement == movement.right)
            {
                if (!(this.VISION[3] is Enemy) && !(this.VISION[3] is Obstacle))
                {
                    heroMovement = movement.right;
                }
                else heroMovement = movement.NoMovement;
            }
            else if(heroMovement == movement.left)
            {
                if (!(this.VISION[2] is Enemy) && !(this.VISION[2] is Obstacle))
                {
                    heroMovement = movement.left;
                }
                else heroMovement = movement.NoMovement;

            }
            else if (heroMovement == movement.up)
            {
                if (!(this.VISION[0] is Enemy) && !(this.VISION[0] is Obstacle))
                {
                    heroMovement = movement.up;
                }
                else heroMovement = movement.NoMovement;

            }
            else if (heroMovement == movement.down)
            {
                if (!(this.VISION[1] is Enemy) && !(this.VISION[1] is Obstacle))
                {
                    heroMovement = movement.down;
                }
                else heroMovement = movement.NoMovement;

            }
            else if (heroMovement == movement.NoMovement)
            {
                heroMovement = movement.NoMovement;
            }

            return heroMovement;
        }
    }
}
