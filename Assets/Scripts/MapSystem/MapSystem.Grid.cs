using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{ 
	[System.Serializable]
	public class Grid
	{
		public Vector2 size;
		public Vertex[,] vertexList;
		public Cell[,] cellList;

		public Grid(Vector2 size)
		{
			this.size = size;
			Vertices vertices = new Vertices(size);
			Cells cells = new Cells(vertices);
			this.vertexList = vertices.vertexList;
			this.cellList = cells.cellList;
		}
	}
}
