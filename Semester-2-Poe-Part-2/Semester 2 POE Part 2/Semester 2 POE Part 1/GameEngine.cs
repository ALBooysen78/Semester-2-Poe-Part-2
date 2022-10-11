using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    internal class GameEngine
    {
        private Map gameMap;    //delcarations
        public Map getMap() { return gameMap; }

        public GameEngine()     //makes new map object
        {
            gameMap = new Map(5, 17, 5, 13, 5);
        }

        public bool MovePlayer(Character.movement move) //checks if the attapted movement is valid, and if so, moves the hero in that direction and updates vision array for hero and enemies
        {
            if (move == Character.movement.NoMovement) return false;

            Character.movement dir = gameMap.Heroprop.ReturnMove(move);
            if (dir == move)
            {
                gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y] = new EmptyTile(gameMap.Heroprop.X, gameMap.Heroprop.Y, " . ");    //replace the hero's current poition on the map with an empty tile
                gameMap.Heroprop.Move(move);    //move hero
                gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y] = gameMap.Heroprop;    //replace the empty tile on the map with new hero position
                gameMap.UpdateVision(gameMap.Heroprop);

                for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                {
                    gameMap.UpdateVision(gameMap.GetEnemies()[i]);
                }
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
