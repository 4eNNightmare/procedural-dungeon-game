using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour {
	public MapSystem.Grid grid;
	public float gridScale;
	public Vector2 gridSize;

	public float vertexSize = 1;
	public Color vertexColor = Color.white;
	public Sprite vertexSprite;
	public Material vertexMaterial;

	public float cellSize = 1;
	public Color cellColor = Color.red;
	public Sprite cellSprite;
	public Material cellMaterial;

	public float edgeWidth = 0.05f;
	public Color edgeColor = Color.black;
	public Material edgeMaterial;

	void Start()
	{
		this.grid = new MapSystem.Grid (this.gridSize, this.gridScale);
		this.DrawVertices ();
		this.DrawCells ();
		this.DrawEdges ();
	}

	private void DrawVertices()
	{
		GameObject vertexGroup = new GameObject ("Vertices");
		vertexGroup.transform.parent = this.gameObject.transform;
		foreach (MapSystem.Vertex vertex in grid.vertexList)
		{
			MapSystem.Renderer.Vertex vertexRenderer = new MapSystem.Renderer.Vertex (vertex);
			vertexRenderer.material = this.vertexMaterial;
			vertexRenderer.color = this.vertexColor;
			vertexRenderer.size = this.vertexSize;
			vertexRenderer.sprite = this.vertexSprite;
			vertexRenderer.gameObject.transform.parent = vertexGroup.transform;
		}
	}

	private void DrawCells()
	{
		GameObject cellGroup = new GameObject ("Cells");
		cellGroup.transform.parent = this.gameObject.transform;
		foreach (MapSystem.Cell cell in grid.cellList)
		{
			MapSystem.Renderer.Cell cellRenderer = new MapSystem.Renderer.Cell (cell);
			cellRenderer.material = this.cellMaterial;
			cellRenderer.color = this.cellColor;
			cellRenderer.size = this.cellSize;
			cellRenderer.setSprite(this.cellSprite, 1/this.gridScale);
			cellRenderer.gameObject.transform.parent = cellGroup.transform;
		}
	}

	private void DrawEdges()
	{
		GameObject edgeGroup = new GameObject ("Edges");
		edgeGroup.transform.parent = this.gameObject.transform;
		GameObject edgeHorizontalGroup = new GameObject ("Horizontal");
		edgeHorizontalGroup.transform.parent = edgeGroup.transform;
		GameObject edgeVerticalGroup = new GameObject ("Vertical");
		edgeVerticalGroup.transform.parent = edgeGroup.transform;
		foreach (MapSystem.Edge edge in grid.edgeList["horizontal"])
		{
			MapSystem.Renderer.Edge edgeRenderer = new MapSystem.Renderer.Edge (edge);
			edgeRenderer.gameObject.transform.parent = edgeHorizontalGroup.transform;
			edgeRenderer.width = this.edgeWidth;
			edgeRenderer.color = this.edgeColor;
			edgeRenderer.material = this.edgeMaterial;
		}

		foreach (MapSystem.Edge edge in grid.edgeList["vertical"])
		{
			MapSystem.Renderer.Edge edgeRenderer = new MapSystem.Renderer.Edge (edge);
			edgeRenderer.gameObject.transform.parent = edgeVerticalGroup.transform;
			edgeRenderer.width = this.edgeWidth;
			edgeRenderer.color = this.edgeColor;
			edgeRenderer.material = this.edgeMaterial;
		}
	}

}