using System;
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
                
                gameMap.Mapprop[gameMap.Heroprop.X, gameMap.Heroprop.Y] = new EmptyTile(gameMap.Heroprop.X, gameMap.Heroprop.Y, " . ");    //replace the hero's current poition on the map with an empty tile
                gameMap.Heroprop.Move(move);    //move hero
                if(gameMap.Mapprop[gameMap.Heroprop.X, gameMap.Heroprop.Y].Symbol == "G ") //allows the hero to pickup gold
                {
                    Item i = gameMap.GetItemAtPosition(gameMap.Heroprop.X, gameMap.Heroprop.Y);
                    gameMap.Heroprop.Pickup(i);
                }
                gameMap.Mapprop[gameMap.Heroprop.X, gameMap.Heroprop.Y] = gameMap.Heroprop;    //replace the empty tile on the map with new hero position
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
                           
                gameMap.Mapprop[enemy.X, enemy.Y] = new EmptyTile(enemy.X, enemy.Y, " . ");    //replace the enemy's current poition on the map with an empty tile
                enemy.Move(move);    //move enemy
                if (gameMap.Mapprop[enemy.X, enemy.Y].Symbol == "G ")  
                {
                    Item i = gameMap.GetItemAtPosition(enemy.X, enemy.Y);
                    enemy.Pickup(i);
                }
                gameMap.Mapprop[enemy.X, enemy.Y] = enemy;    //replace the empty tile on the map with new enemy position
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
                                gameMap.Mapprop[gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y] = new EmptyTile(gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, ". ");     //removes dead enemies from the map 
                                
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

        public void SaveGame()
        {
            DataSet dataSet = new DataSet();                //make new dataset and datatable
            DataTable dataTable = new DataTable();

            dataSet.Tables.Add(dataTable);                  //add columns to the datatable which stores relevant information

            dataTable.Columns.Add(new DataColumn("ObjectType", typeof(string)));
            dataTable.Columns.Add(new DataColumn("X", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Y", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Health", typeof(int)));
            dataTable.Columns.Add(new DataColumn("MaxHealth", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Gold", typeof(int)));

            //add the dimensions of the map to the datatable
            dataTable.Rows.Add("MapDimensions", gameMap.GetMapHeight(), gameMap.GetMapWidth(), -1, -1, -1); //since the map doesn't have all of the values, irrelevent ones are set to -1
            //add the hero to the datatable
            dataTable.Rows.Add("Hero", gameMap.Heroprop.X, gameMap.Heroprop.Y, gameMap.Heroprop.HP, gameMap.Heroprop.MaxHp, gameMap.Heroprop.GoldPurse);
            //add the enemies to the datatable
            for (int i = 0; i < gameMap.GetEnemies().Length; i++)
            {
                if (gameMap.GetEnemies()[i] is SwampCreature)
                {
                    dataTable.Rows.Add("Swamp Creature", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse);
                }
                else if (gameMap.GetEnemies()[i] is Mage)
                {
                    dataTable.Rows.Add("Mage", gameMap.GetEnemies()[i].X, gameMap.GetEnemies()[i].Y, gameMap.GetEnemies()[i].HP, gameMap.GetEnemies()[i].MaxHp, gameMap.GetEnemies()[i].GoldPurse);
                }
            }
            //add the items to the datatable
            for (int i = 0; i < gameMap.Items.Length; i++)
            {
                if (gameMap.Items[i] is Gold)
                {
                    dataTable.Rows.Add("Gold", gameMap.Items[i].X, gameMap.Items[i].Y, -1, -1, ((Gold)gameMap.Items[i]).GoldAmount); //since gold does not have all of the values, irrelevant ones are set to -1
                }
            }
            //save dataset
            dataSet.WriteXml("Data.xml");
        }

        public void LoadGame()
        {
            DataSet loadSet = new DataSet();        //load dataset from saved file
            loadSet.ReadXml("Data.xml");

            foreach (DataRow row in loadSet.Tables[0].Rows)     //loop for each row in dataset
            {
                string objectType = (string)row["ObjectType"];      //set variables for each corresponding value in the dataset
                int xPos = Convert.ToInt32(row["X"]);
                int yPos = Convert.ToInt32(row["Y"]);
                int hp = Convert.ToInt32(row["Health"]);
                int maxHp = Convert.ToInt32(row["MaxHealth"]);
                int gold = Convert.ToInt32(row["Gold"]);

                switch (objectType)
                {
                    case "MapDimensions":
                        gameMap = new Map(xPos, xPos, yPos, yPos, gameMap.GetEnemies().Length, gameMap.Items.Length);   //makes a new map according to the dimensions given from the savefile
                        gameMap.Items = new Item[gameMap.Items.Length];     //make new item array
                        Enemy[] tmp = new Enemy[gameMap.GetEnemies().Length];   //make new empty enemy array
                        gameMap.SetEnemies(tmp);
                        for (int x = 0; x < xPos; x++)      //creates obstacles on the edges of the map, as well as filling it with empty tiles
                        {
                            for (int y = 0; y < yPos; y++)
                            {
                                if (x == 0 || x == xPos - 1 || y == 0 || y == yPos - 1)
                                {
                                    gameMap.Mapprop[x, y] = new Obstacle(x, y, "X");
                                }
                                else
                                {
                                gameMap.Mapprop[x, y] = new EmptyTile(x, y, ". ");                                
                                }
                            }
                        }
                        break;
                    case "Hero":
                        Hero hero = new Hero(xPos, yPos,2, hp, maxHp, "H ") { GoldPurse = gold };   //makes a new hero from the savefile data
                        gameMap.Heroprop = hero;
                        gameMap.Mapprop[xPos, yPos] = hero;     //places new hero on the map
                        break;
                    case "Mage":
                        for (int i = 0; i < gameMap.GetEnemies().Length; i++)   //loops through enemies array and adds a new mage from the savefile data if there is an open space in the enemy array
                        {
                            if (gameMap.GetEnemies()[i] is null)    
                            {
                                Mage mage = new Mage(xPos, yPos,5, hp, 5, "M ") { GoldPurse = gold };
                                gameMap.GetEnemies()[i] = mage;
                                gameMap.Mapprop[xPos, yPos] = mage;     //places new mage on the map
                                break;
                            }
                        }
                        break;
                    case "Swamp Creature":
                        for (int i = 0; i < gameMap.GetEnemies().Length; i++)       //loops through enemies array and adds a swampcreature from the savefile data to an open space in the enemy array
                        {
                            if (gameMap.GetEnemies()[i] is null)
                            {
                                SwampCreature swampCreature = new SwampCreature(xPos, yPos, 1, hp, 10, "SC") {  GoldPurse = gold };
                                gameMap.GetEnemies()[i] = swampCreature;
                                gameMap.Mapprop[xPos, yPos] = swampCreature;    //places new swampcreature on the map
                                break;
                            }
                        }
                        break;
                    case "Gold":        
                        Gold _gold = new Gold(xPos, yPos, "G ") { GoldAmount = gold };      //creates gold from the savefile data and adds it to an open space in the item array
                        for (int i = 0; i < gameMap.Items.Length; i++)
                        {
                            if (gameMap.Items[i] is null)
                            {
                                gameMap.Items[i] = _gold;
                                break;
                            }
                        }
                        gameMap.Mapprop[xPos, yPos] = _gold;    //places new gold on the map
                        break;
                    default:
                        break;
                }
            }

            for(int i = 0; i < gameMap.GetEnemies().Length; i++)    //loop to check if there are any null values in the enemies array 
            {
                if (gameMap.GetEnemies()[i] == null)        //if there is a null value, creates a new array that is sorter and sets the enemy array to the new one
                {
                    Enemy[] aliveEnemies = new Enemy[i];

                    for (int j = 0; j < aliveEnemies.Length; j++)
                    {
                        aliveEnemies[j] = gameMap.GetEnemies()[j];
                    }

                    gameMap.SetEnemies(aliveEnemies);

                    break;
                }
            }

            for (int i = 0; i < gameMap.GetEnemies().Length; i++)       //updates vision of all enemies
            {
                gameMap.UpdateVision(gameMap.GetEnemies()[i]);
            }

            gameMap.UpdateVision(gameMap.Heroprop);     //updates vision for hero
        }






    }//class
}
