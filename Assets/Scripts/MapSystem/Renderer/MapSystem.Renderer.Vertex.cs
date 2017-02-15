using UnityEngine;
using System.Collections;

namespace MapSystem.Renderer{
	public class Vertex
	{
		public float size;
		public Sprite sprite;
		public Material material;
		public SpriteRenderer renderer;
		public GameObject gameObject;

		public Vertex(MapSystem.Vertex vertex, Sprite sprite, Material material, float size){
			this.gameObject = new GameObject(string.Format("Vertex {0}", vertex.position), typeof(SpriteRenderer));
			this.renderer = this.gameObject.GetComponent<SpriteRenderer> ();
			this.renderer.sprite = this.sprite = sprite;
			this.renderer.material = this.material = material;
			this.gameObject.transform.position = vertex.position;
			this.size = size;
			this.gameObject.transform.localScale = new Vector3 (this.size, this.size, this.size);
		}

	}
}

