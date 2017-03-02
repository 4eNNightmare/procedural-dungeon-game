using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{
	public class Room 
	{
		public Cell[,] cells;

		public Room(Cell origin, Vector2 size)
		{
            this.cells = new Cell[(int)size.x, (int)size.y];
			origin.room = this;
            for(int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    this.cells[x, y] = origin.grid.cells[(int)origin.gridPosition.x + x, (int)origin.gridPosition.y + y];
                }
            }

		}
	}
}
