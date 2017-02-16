using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapSystem{
	
	public class Edge
	{
		public Vertex start;
		public Vertex end;
		public Vector2 center;

		public Edge(Vertex start, Vertex end)
		{
			this.start = start;
			this.end = end;
			this.center = Vector2.Lerp (this.start.position, this.end.position, 0.5f);
		}
	}
		
	public class Edges
	{
		public Dictionary<string, Edge[,]> edgeList;

		public Edges(Vertices vertices)
		{
			this.edgeList = new Dictionary<string, Edge[,]>
			{
				{
					"horizontal",
					new Edge[vertices.vertexList.GetLength(0) - 1, vertices.vertexList.GetLength(1)]
				}, 
				{
					"vertical",
					new Edge[vertices.vertexList.GetLength(0), vertices.vertexList.GetLength(1) - 1]
				}
			};

			for(int y = 0; y < edgeList["horizontal"].GetLength(1); y++)
			{
				for(int x = 0; x < edgeList["horizontal"].GetLength(0); x++)
				{
					Edge edge = new Edge (vertices.vertexList[x,y], vertices.vertexList[x + 1, y]);
					edgeList ["horizontal"] [x, y] = edge;

				}
			}

			for(int y = 0; y < edgeList["vertical"].GetLength(1); y++)
			{
				for(int x = 0; x < edgeList["vertical"].GetLength(0); x++)
				{
					Edge edge = new Edge (vertices.vertexList[x,y], vertices.vertexList[x, y + 1]);
					edgeList ["vertical"] [x, y] = edge;
				}
			}

		}
	}
}
