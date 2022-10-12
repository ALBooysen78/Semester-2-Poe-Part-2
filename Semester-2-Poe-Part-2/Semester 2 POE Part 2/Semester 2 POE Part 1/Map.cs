using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
    internal class Map
    {
        private Tile[,] map;    //declarations for the Map class
        private int mapHeight;  
        private int mapWidth;   
        private Enemy[] enemies;    
        private Hero hero;
        private Random random = new Random();
        private Item[] items;

        public int GetMapHeight()   //getter for the map's height
        {
            return mapHeight;
        }

        public int GetMapWidth()    //getter for the map's width
        {
            return mapWidth;
        }

        public string GetSymbol(int X, int Y)   //getter mthod to get the symbols on the map
        {
            return map[X, Y].Symbol;
        }

        public Tile[,] GetMap()     //getter for the map
        {
            return map;
        }

        public Enemy[] GetEnemies()     //getter for the enemies array
        {
            return enemies;
        }

        public void SetEnemies(Enemy[] e)       //sets enemy array
        {
            enemies = e;

        }

        public Hero Heroprop { get { return hero; } set { hero = value; } }     

        public Map(int minHeight, int maxHeight, int minWidth, int maxWidth, int enemyNumber, int goldAmount)   //map constructor
        {
            this.mapHeight = random.Next(minHeight,maxHeight);
            this.mapWidth = random.Next(minWidth,maxWidth);
            map = new Tile[mapHeight,mapWidth];
            enemies = new Enemy[enemyNumber];
            items = new Item[goldAmount];

            for (int i = 0; i < mapHeight; i++)     //sets the obstacles around the entire map
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (i == 0 || i == mapHeight - 1 || j == 0 || j == mapWidth - 1)
                    {
                        map[i, j] = new Obstacle(i, j, "X");
                    }
                    
                }
            }

            for (int i = 0; i < enemies.Length; i++)    //creates and fills the enemies array
            {
                enemies[i] = (Enemy)Create(Tile.tileType.Enemy);
                map[enemies[i].X, enemies[i].Y] = enemies[i];
            }

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = (Item)Create(Tile.tileType.Gold);
                map[items[i].X, items[i].Y] = items[i];
            }

            hero = (Hero)Create(Tile.tileType.Hero);    //creates hero object

            map[hero.X, hero.Y] = hero;
            
            MapFill();

            UpdateVision(hero);
            
            for (int i = 0; i < enemies.Length; i++)
            {
                UpdateVision(enemies[i]);
            }

        }

        public void UpdateVision(Character character)   //updates vision array for entered character
        {
           

            //up
            character.VISION[0] = map[character.X - 1, character.Y];
            //down
            character.VISION[1] = map[character.X+ 1, character.Y];
            //left
            character.VISION[2] = map[character.X, character.Y-1];
            //right
            character.VISION[3] = map[character.X, character.Y+1];


        }

        private Tile Create(Tile.tileType type) //create method for creating hero and enemies
        {
            int X;
            int Y;
            bool validPosition = false;
            do   //loops to find an open spot on the map based on random coordinates
            {
                X = random.Next(mapHeight);
                Y = random.Next(mapWidth);

                if (map[X,Y] == null)
                {
                    validPosition = true;
                }

            } while (validPosition == false);

            switch (type)   //switch to create the right object based on type entered
            {
                case Tile.tileType.Hero:
                    return new Hero(X, Y, 2, 10, 10, "H");
                case Tile.tileType.Enemy:
                    int i = random.Next(0, 2);
                    if (i == 0)
                    {
                        return new SwampCreature(X, Y);
                    }
                    else if (i == 1)
                    {
                        return new Mage(X,Y);
                    }
                    else
                    {
                        return null;
                    }
                case Tile.tileType.Gold:
                    return new Gold(X,Y,3,"G");                //these return null because we have not implemented gold or weapons in the game yet
                case Tile.tileType.weapon:
                    return null;                //these return null because we have not implemented gold or weapons in the game yet
                default:
                    return null;
            }
        }

        public void MapFill()   //fills all the empty spaces on the map with empty tiles
        {
            for (int x = 0; x < mapHeight; x++)
            {
                for (int y = 0; y < mapWidth; y++)
                {
                    if (map[x,y] == null)
                    {
                        map[x,y] = new EmptyTile(x,y," . ");
                    }
                }
            }
        }

        public Item GetItemAtPosition(int x, int y)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if ((items[i].X == x) && (items[i].Y == y))
                {
                    return items[i];
                }
            }
            return null;
        }
    }
}
