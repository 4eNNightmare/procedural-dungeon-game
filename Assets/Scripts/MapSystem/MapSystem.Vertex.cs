using UnityEngine;
using System.Collections;

namespace MapSystem{
	
	public class Vertex
	{
		public Vector2 position;


		public Vertex(Vector2 position)
		{
			this.position = position;   
		}
	}
		
	public class Vertices
	{
		public Vertex[,] vertexList;
		public Vector2 center;

		public Vertices(Vector2 size){
			this.vertexList = new Vertex[(int)size.x+1, (int)size.y+1];
			this.center = new Vector2 (size.x / 2, size.y / 2);
			for(int y = 0; y <= size.y; y++)
			{
				for(int x = 0; x <= size.x; x++)
				{
					vertexList[x, y] = new Vertex (new Vector2 (x, y));
				}
			}
		}
	}
}
