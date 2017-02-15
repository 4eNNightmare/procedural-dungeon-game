using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour {
	private MapSystem.Grid grid;
	public float vertexSize = 1;
	public Sprite vertexSprite;
	public Material vertexMaterial;

	void Start()
	{
		this.grid = new MapSystem.Grid (new Vector2 (100, 100));
		DrawVertices ();
	}

	private void DrawVertices()
	{
		foreach (MapSystem.Vertex vertex in grid.vertexList)
		{
			new MapSystem.Renderer.Vertex (vertex, this.vertexSprite, this.vertexMaterial, this.vertexSize);
		}
	}
}