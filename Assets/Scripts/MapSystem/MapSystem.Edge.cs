using UnityEngine;
using System.Collections;

namespace MapSystem{
	[System.Serializable]
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
}
