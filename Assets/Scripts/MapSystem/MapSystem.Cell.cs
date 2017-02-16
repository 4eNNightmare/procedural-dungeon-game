using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapSystem{

	public class Cell
	{
		public Dictionary<string, Edge> edges;
		public Vertex[,] vertices;

		public float width
		{
			get{ return this.edges["right"].start.position.x - this.edges["left"].end.position.x; }
		}

		public float height
		{
			get{ return this.edges["top"].start.position.y - this.edges["bottom"].end.position.y; }
		}

		public Vector2 center
		{
			get
			{
				return vertices[0,0].position + new Vector2(width, height)/2;
			}
		}


		public Cell(Dictionary<string, Edge> edges){
			this.edges = edges;
			this.vertices = new Vertex[2,2]{ {edges["bottom"].start, edges["bottom"].end}, {edges["top"].start, edges["top"].end} };
		}
	}
		
	public class Cells{
		public Cell[,] cellList;

		public Cells(Edges edges)
		{
			this.cellList = new Cell[edges.edgeList["horizontal"].GetLength (0), edges.edgeList["vertical"].GetLength (1)];
			for(int y = 0; y < edges.edgeList["vertical"].GetLength (1); y++)
			{
				for(int x = 0; x < edges.edgeList["horizontal"].GetLength (0); x++)
				{
					Dictionary<string, Edge> e = new Dictionary<string, Edge> {
						{ "bottom",	new Edge (edges.edgeList ["horizontal"] [x, y].start, edges.edgeList ["horizontal"] [x, y].end) },
						{ "left",	new Edge (edges.edgeList ["vertical"]   [x, y].start, edges.edgeList ["vertical"]   [x, y].end) },
						{ "top",	new Edge (edges.edgeList ["horizontal"] [x, y + 1].start, edges.edgeList ["horizontal"] [x, y + 1].end) },
						{ "right",	new Edge (edges.edgeList ["vertical"]   [x + 1, y].start, edges.edgeList ["vertical"]   [x + 1, y].end) }
					};
					cellList[x, y] = new Cell (e);
				}
			}
		}
	}
}
