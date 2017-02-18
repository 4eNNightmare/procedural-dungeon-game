using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapSystem{

	public class Cell
	{
		public Renderer.Cell renderer;
		public Room room;
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
			foreach (Edge edge in this.edges.Values) 
			{
				edge.cells.Add (this);
			}
			this.vertices = new Vertex[2,2]{ {edges["bottom"].start, edges["bottom"].end}, {edges["top"].start, edges["top"].end} };
		}
	}
		
	public class Cells{
		public Cell[,] list;

		public Cells(Edges edges)
		{
			this.list = new Cell[edges.list["horizontal"].GetLength (0), edges.list["vertical"].GetLength (1)];
			for(int y = 0; y < edges.list["vertical"].GetLength (1); y++)
			{
				for(int x = 0; x < edges.list["horizontal"].GetLength (0); x++)
				{
					Dictionary<string, Edge> e = new Dictionary<string, Edge> 
					{
						{ "bottom",	 edges.list["horizontal"] [x, y]},
						{ "left",	 edges.list["vertical"]   [x, y]},
						{ "top",	 edges.list["horizontal"] [x, y + 1]},
						{ "right",	 edges.list["vertical"]   [x + 1, y]}
					};
					list[x, y] = new Cell (e);
				}
			}
		}
	}
}
