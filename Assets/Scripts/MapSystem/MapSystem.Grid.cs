using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{ 
	
	public class Grid
	{
		public float scale;
		public Vector2 size;
		public Vertex[,] vertexList;
		public Cell[,] cellList;
		public Dictionary<string, Edge[,]> edgeList;

		public Grid(Vector2 size, float scale)
		{
			this.scale = scale;
			this.size = size;
			Vertices vertices = new Vertices(size, scale);
			Edges edges = new Edges(vertices);
			Cells cells = new Cells(edges);
			this.vertexList = vertices.vertexList;
			this.cellList = cells.cellList;
			this.edgeList = edges.edgeList;
		}
	}
}
