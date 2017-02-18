using UnityEngine;
using System.Collections;

namespace MapSystem.Renderer{
	
	public class Vertex  : Generic
	{
		public MapSystem.Vertex vertex;

		public Vertex(MapSystem.Vertex vertex, float scale)
		{
			this.vertex = vertex;
			this.vertex.renderer = this;
			this.scale = scale;
			this.gameObject = new GameObject(string.Format("Vertex {0}", vertex.position), typeof(SpriteRenderer));
			this.gameObject.transform.position = vertex.position;
		}

	}
}

