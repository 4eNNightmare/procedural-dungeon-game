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

			#region TEMPORARIO
			try{
				this.roomList.Add (new Room (this.cells [0, 0]));
				this.roomList.Add (new Room (this.cells [1, 0]));
				this.roomList.Add (new Room (this.cells [0, 1]));
				this.roomList.Add (new Room (this.cells [1, 1]));
			}catch(System.Exception){}
			#endregion

		}
	}
}
