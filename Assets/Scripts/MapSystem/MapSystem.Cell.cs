using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapSystem{
	[System.Serializable]
	public class Cell
	{
		public Dictionary<string, Edge> edges;
		public Vertex[,] vertices;
		public Vector2 center;


		public Cell(Vertex[,] vertices){
			this.vertices = vertices;
			this.center = new Vector2 (vertices[1,0].position.x/2, vertices[0,1].position.y/2);
			this.edges = new Dictionary<string, Edge>();

			this.edges["bottom"] = new Edge(this.vertices[1,0], this.vertices[0,0]);
			this.edges["left"] = new Edge(this.vertices[0,0], this.vertices[0,1]);
			this.edges["top"] = new Edge(this.vertices[0,1], this.vertices[1,1]);
			this.edges["right"] = new Edge(this.vertices[1,1], this.vertices[1,0]);
		}
	}

	[System.Serializable]
	public class Cells{
		public Cell[,] cellList;
		public Vector2 center;

		public Cells(Vertices vertices)
		{
			this.center = vertices.center;
			this.cellList = new Cell[vertices.vertexList.GetLength (0) - 1, vertices.vertexList.GetLength (1) - 1];
			for(int y = 0; y < cellList.GetLength(1); y++)
			{
				for(int x = 0; x < cellList.GetLength(0); x++)
				{
					Vertex[,] v = new Vertex[2, 2];
					v[0, 0] = vertices.vertexList[x    , y    ];
					v[0, 1] = vertices.vertexList[x    , y + 1];
					v[1, 0] = vertices.vertexList[x + 1, y    ];
					v[1, 1] = vertices.vertexList[x + 1, y + 1];
					cellList[x, y] = new Cell (v);
				}
			}
		}
	}
}
