using UnityEngine;
using System.Collections;

namespace MapSystem.Renderer{
	public class Vertex  : Generic
	{
		public Vertex(MapSystem.Vertex vertex)
		{
			this.gameObject = new GameObject(string.Format("Vertex {0}", vertex.position), typeof(SpriteRenderer));
			this.gameObject.transform.position = vertex.position;
		}

	}
}

