using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapSystem{
	
	public class Vertex
	{
		public Renderer.Vertex renderer;
		public List<Room> rooms
		{
			get
			{
				List<Room> _rooms = new List<Room> ();
				foreach (Cell cell in this.cells)
				{
					_rooms.Add (cell.room);
				}
				return _rooms;
			}
		}
		public List<Cell> cells;
		public Vector2 position;

		public Vertex(Vector2 position)
		{
			this.cells = new List<Cell>();
			this.position = position;   
		}
	}
		
	public class Vertices
	{
		public Vertex[,] list;
		public Vector2 center;

		public Vertices(Vector2 size, float scale){
			this.list = new Vertex[(int)size.x+1, (int)size.y+1];
			this.center = new Vector2 (size.x / 2, size.y / 2);
			for(int y = 0; y <= size.y; y++)
			{
				for(int x = 0; x <= size.x; x++)
				{
					list[x, y] = new Vertex (new Vector2 (x, y) * scale);
				}
			}
		}
	}
}
