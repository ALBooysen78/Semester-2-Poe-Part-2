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
            gameMap = new Map(10, 17, 10, 13, 5,5);
        }

        public bool MovePlayer(Character.movement move) //checks if the attapted movement is valid, and if so, moves the hero in that direction and updates vision array for hero and enemies
        {
            if (move == Character.movement.NoMovement) return false;

            Character.movement dir = gameMap.Heroprop.ReturnMove(move);
            if (dir == move)
            {
                
                gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y] = new EmptyTile(gameMap.Heroprop.X, gameMap.Heroprop.Y, " . ");    //replace the hero's current poition on the map with an empty tile
                gameMap.Heroprop.Move(move);    //move hero
                if(gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y].Symbol == "G ")
                {
                    Item i = gameMap.GetItemAtPosition(gameMap.Heroprop.X, gameMap.Heroprop.Y);
                    gameMap.Heroprop.Pickup(i);
                }
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

        public void MoveEnemies()
        {


            foreach (var enemy in gameMap.GetEnemies())
            {           
                Character.movement move = (Character.movement)enemy.ReturnMove(Character.movement.NoMovement);  //Since the ReturnMove method requires a parameter, no movement is passed in as a placeholder. This value is changed in the swamp creature class when a random movement is calculated
                           
                gameMap.GetMap()[enemy.X, enemy.Y] = new EmptyTile(enemy.X, enemy.Y, " . ");    //replace the enemy's current poition on the map with an empty tile
                enemy.Move(move);    //move enemy
                if (gameMap.GetMap()[enemy.X, enemy.Y].Symbol == "G ")
                {
                    Item i = gameMap.GetItemAtPosition(enemy.X, enemy.Y);
                    enemy.Pickup(i);
                }
                gameMap.GetMap()[enemy.X, enemy.Y] = enemy;    //replace the empty tile on the map with new enemy position
                gameMap.UpdateVision(gameMap.Heroprop);


                for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                {
                    gameMap.UpdateVision(gameMap.GetEnemies()[i]);
                }
                    
                
                
            }
        }

        public void EnemyAttacks()
        { 
            foreach (var enemy in gameMap.GetEnemies())
            {
                if (enemy is SwampCreature)
                {
                    for(int i = 0; i < enemy.VISION.Length; i++)
                    {
                        if (enemy.VISION[i] is Hero)
                        {
                            enemy.Attack(gameMap.Heroprop);
                            break;
                        }
                    }
                }
                else if (enemy is Mage)
                {
                    for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                    {
                        if (enemy.CheckRange(gameMap.GetEnemies()[i]))
                        {
                            enemy.Attack(gameMap.GetEnemies()[i]);
                            
                            if (gameMap.GetEnemies()[i].isDead() == true)
                            {
                                gameMap.GetMap()[gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y] = new EmptyTile(gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, ". ");
                                
                            }
                            
                        }
                    }

                    if (enemy.CheckRange(gameMap.Heroprop))
                    {
                        enemy.Attack(gameMap.Heroprop);
                    }
                }
            }
        }

    }
}
