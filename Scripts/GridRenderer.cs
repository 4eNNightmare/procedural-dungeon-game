using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour {
	public MapSystem.Grid grid;
	public float vertexSize = 1;
	public Sprite vertexSprite;
	public Material vertexMaterial;

	void Start()
	{
		this.grid = new MapSystem.Grid();
		StartCoroutine(DrawVertices ());
	}

	private IEnumerator DrawVertices()
	{
		foreach (MapSystem.Vertex vertex in grid.vertexMap)
		{
			GameObject v = new GameObject(string.Format("Vertex {0}", vertex.position), typeof(SpriteRenderer));
			SpriteRenderer renderer = v.GetComponent<SpriteRenderer> ();
			renderer.sprite = vertexSprite;
			renderer.material = vertexMaterial;
			v.transform.position = vertex.position;
			v.transform.localScale = new Vector3 (vertexSize, vertexSize, vertexSize);
			yield return null;
		}
	}
}

namespace MapSystem
{
	public class Grid
	{
		public Vertex[,] vertexMap;

		public Grid(){
			this.vertexMap = new Vertex[3,3];
			for (int x = 0; x <= 2; x++) {
				for (int y = 0; y <= 2; y++) {
					this.vertexMap [x, y] = new Vertex (new Vector2 (x, y));
				}
			}
		}
	}

	public class Vertex
	{
		public Vector2 position;

		public Vertex(Vector2 position)
		{
			this.position = position;
		}
	}

	public class VertexRenderer
	{

	}
}
