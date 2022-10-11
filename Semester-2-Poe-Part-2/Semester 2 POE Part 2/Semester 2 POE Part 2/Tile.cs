using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_2_POE_Part_1
{
	public abstract class Tile
	{
		protected int x;
		protected int y;			//creating the protected variables
		protected string symbol;
		protected tileType type;

		public int X { get { return x; } set { x = value; } }
		public int Y { get { return y; } set { y = value; } }					//creating the public variables
		public string Symbol { get { return symbol; } set { symbol = value; } }

		public enum tileType { Hero, Enemy, Gold, weapon }; //public enums for tile types

		public Tile(int X, int Y, string symbol)
		{
			this.x = X;
			this.y = Y;										//Tile constructor 1
			this.symbol = symbol;
		}

		public Tile(int X, int Y, tileType type)
		{
			this.x = X;
			this.y = Y;										//Tile constructor 2
			this.type = type;
		}

		public Tile(int X, int Y, string symbol, tileType type)
		{
			this.x = X;
			this.y = Y;                                     //Tile constructor 3
			this.symbol = symbol;
		}

		protected Tile(int x, int y)
        {
            this.x = x;
            this.y = y;                                      //Tile constructor 4
		}

		protected Tile()
        {
															//Tile constructor 5
		}

		//Tile tile = new Tile(5, 7, tileType.Hero);
	}
}
