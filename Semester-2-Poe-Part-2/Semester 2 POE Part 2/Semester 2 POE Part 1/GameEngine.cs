﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Semester_2_POE_Part_1
{
    internal class GameEngine
    {
        private Map gameMap;    //delcarations
        public Map getMap() { return gameMap; }

        public GameEngine()     //makes new map object
        {
            gameMap = new Map(8,20,8,15,5,5);
        }

        public bool MovePlayer(Character.movement move) //checks if the attapted movement is valid, and if so, moves the hero in that direction and updates vision array for hero and enemies
        {
            if (move == Character.movement.NoMovement) return false;

            Character.movement dir = gameMap.Heroprop.ReturnMove(move);
            if (dir == move)
            {
                
                gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y] = new EmptyTile(gameMap.Heroprop.X, gameMap.Heroprop.Y, " . ");    //replace the hero's current poition on the map with an empty tile
                gameMap.Heroprop.Move(move);    //move hero
                if(gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y].Symbol == "G ") //allows the hero to pickup gold
                {
                    Item i = gameMap.GetItemAtPosition(gameMap.Heroprop.X, gameMap.Heroprop.Y);
                    gameMap.Heroprop.Pickup(i);
                }
                gameMap.GetMap()[gameMap.Heroprop.X, gameMap.Heroprop.Y] = gameMap.Heroprop;    //replace the empty tile on the map with new hero position
                gameMap.UpdateVision(gameMap.Heroprop);


                for (int i = 0; i < gameMap.GetEnemies().Length; i++)   //updates enemy visions
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

        public void MoveEnemies()   //method to move enemies
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

        public void EnemyAttacks()  //method for enemy attacks
        { 
            foreach (var enemy in gameMap.GetEnemies())
            {
                if (enemy.isDead() == true) //checks if the enemy is dead, so that they can't attack if so
                {
                    continue;
                }
                if (enemy is SwampCreature)     //attacks if enemy is a swampcreature
                {
                    for(int i = 0; i < enemy.VISION.Length; i++)
                    {
                        if (enemy.VISION[i] is Hero)    //attacks hero if he is close enough
                        {
                            enemy.Attack(gameMap.Heroprop);
                            break;
                        }
                    }
                }
                else if (enemy is Mage)     //attacks if enemy is a mage
                {
                    for (int i = 0; i < gameMap.GetEnemies().Length; i++)
                    {
                        if (enemy.CheckRange(gameMap.GetEnemies()[i]))      //mage attacks enemies ass well
                        {
                            enemy.Attack(gameMap.GetEnemies()[i]);
                            
                            if (gameMap.GetEnemies()[i].isDead() == true)
                            {
                                gameMap.GetMap()[gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y] = new EmptyTile(gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, ". ");     //removes dead enemies from the map 
                                
                            }
                            
                        }
                    }

                    if (enemy.CheckRange(gameMap.Heroprop))     //attacks hero
                    {
                        enemy.Attack(gameMap.Heroprop);
                    }
                }
            }
        }

         public void SaveGame(string filepath)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            dataSet.Tables.Add(dataTable);

            dataTable.Columns.Add(new DataColumn("ObjectType", typeof(string)));
            dataTable.Columns.Add(new DataColumn("X", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Y", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Health", typeof(int)));
            dataTable.Columns.Add(new DataColumn("MaxHealth", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Gold", typeof(int)));

            //hero
            dataTable.Rows.Add("Hero", gameMap.Heroprop.X, gameMap.Heroprop.Y, gameMap.Heroprop.HP, gameMap.Heroprop.MaxHp, gameMap.Heroprop.GoldPurse);
            //enemies
            for (int i = 0; i < gameMap.GetEnemies().Length; i++)
            {
                if (gameMap.GetEnemies()[i] is SwampCreature)
                {
                    dataTable.Rows.Add("SwampCreature", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse);
                }
                else if (gameMap.GetEnemies()[i] is Mage)
                {
                    dataTable.Rows.Add("Mage", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse);
                }
            }
            //Items
            for (int i = 0; i < gameMap.Items.Length; i++)
            {
                if (gameMap.Items[i] is Gold)
                {
                    dataTable.Rows.Add("Gold", gameMap.Items[i].X, gameMap.Items[i].Y, -1, -1, ((Gold)gameMap.Items[i]).GoldAmount);
                }
            }

            dataSet.WriteXml("Data.xml");
        }

       public void LoadGame()
        {
            
        }






    }//class
}
