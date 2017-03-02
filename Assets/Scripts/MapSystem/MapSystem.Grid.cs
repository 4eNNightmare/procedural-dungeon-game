using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{ 
	
	public class Grid
	{
		public float scale;
		public Vector2 size;
		public Vertex[,] vertices;
		public Cell[,] cells;
		public Dictionary<string, Edge[,]> edges;
		public List<Room> roomList;

		public Grid(Vector2 size, float scale)
		{
			this.scale = scale;
			this.size = size;
			Vertices vertices = new Vertices(size, scale);
			Edges edges = new Edges(vertices);
			Cells cells = new Cells(edges);
			this.vertices = vertices.list;
			this.cells = cells.list;
			this.edges = edges.list;
			this.roomList = new List<Room> ();
			for (int y = 0; y < this.cells.GetLength(1); y++) 
			{
				for (int x = 0; x < this.cells.GetLength(0); x++) 
				{
                    this.cells[x, y].grid = this;
                    this.cells[x, y].gridPosition = new Vector2(x, y);
					try {this.cells [x, y].adjacent ["top"]    = this.cells [x, y + 1];} catch (System.IndexOutOfRangeException) {}
					try {this.cells [x, y].adjacent ["left"]   = this.cells [x - 1, y];} catch (System.IndexOutOfRangeException) {}
					try {this.cells [x, y].adjacent ["bottom"] = this.cells [x, y - 1];} catch (System.IndexOutOfRangeException) {}
					try {this.cells [x, y].adjacent ["right"]  = this.cells [x + 1, y];} catch (System.IndexOutOfRangeException) {}
				}
			}
		}
	}
}
