using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem{
	public class Room 
	{
		public List<Cell> cells;

		public Room(Cell origin)
		{
			this.cells = new List<Cell> ();
			this.cells.Add (origin);
			origin.room = this;
		}
		
	}
}