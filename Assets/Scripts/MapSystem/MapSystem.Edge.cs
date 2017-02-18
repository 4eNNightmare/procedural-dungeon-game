using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapSystem{
	
	public class Edge
	{
		public Renderer.Edge renderer;
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
		public Vertex start;
		public Vertex end;
		public Vector2 center;

		public Edge(Vertex start, Vertex end)
		{
			this.cells = new List<Cell>();
			this.start = start;
			this.end = end;
			this.center = Vector2.Lerp (this.start.position, this.end.position, 0.5f);
		}
	}
		
	public class Edges
	{
		public Dictionary<string, Edge[,]> list;

		public Edges(Vertices vertices)
		{
			this.list = new Dictionary<string, Edge[,]>
			{
				{
					"horizontal",
					new Edge[vertices.list.GetLength(0) - 1, vertices.list.GetLength(1)]
				}, 
				{
					"vertical",
					new Edge[vertices.list.GetLength(0), vertices.list.GetLength(1) - 1]
				}
			};

			for(int y = 0; y < list["horizontal"].GetLength(1); y++)
			{
				for(int x = 0; x < list["horizontal"].GetLength(0); x++)
				{
					Edge edge = new Edge (vertices.list[x,y], vertices.list[x + 1, y]);
					list ["horizontal"] [x, y] = edge;

				}
			}

			for(int y = 0; y < list["vertical"].GetLength(1); y++)
			{
				for(int x = 0; x < list["vertical"].GetLength(0); x++)
				{
					Edge edge = new Edge (vertices.list[x,y], vertices.list[x, y + 1]);
					list ["vertical"] [x, y] = edge;
				}
			}

		}
	}
}
