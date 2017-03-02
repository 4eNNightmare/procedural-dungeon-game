using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour {
	[HideInInspector]
	public MapSystem.Grid grid;
	public float gridScale;
	public Vector2 gridSize;
	[Header("Vertex")]
	public float vertexSize = 1;
	public Color vertexColor = Color.white;
	public Sprite vertexSprite;
	public Material vertexMaterial;
	[Header("Edge")]
	public float edgeWidth = 0.05f;
	public Color edgeColor = Color.black;
	public Material edgeMaterial;
	[Header("Cell")]
	public float cellSize = 1;
	public Color cellColor = Color.red;
	public Sprite cellSprite;
	public Material cellMaterial;
	[Header("Room")]
	public Color roomVertexColor = Color.black;
	public Color roomEdgeColor = Color.white;
	public Color roomCellColor = Color.blue;

	void Start()
	{
		this.grid = new MapSystem.Grid (this.gridSize, this.gridScale);
		this.DrawVertices ();
		this.DrawCells ();
		this.DrawEdges ();
		this.DrawRooms ();
	}

	private void DrawVertices()
	{
		GameObject vertexGroup = new GameObject ("Vertices");
		vertexGroup.transform.parent = this.gameObject.transform;
		foreach (MapSystem.Vertex vertex in grid.vertices)
		{
			MapSystem.Renderer.Vertex vertexRenderer = new MapSystem.Renderer.Vertex (vertex, this.gridScale);
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
		foreach (MapSystem.Cell cell in grid.cells)
		{
			MapSystem.Renderer.Cell cellRenderer = new MapSystem.Renderer.Cell (cell, this.gridScale);
			cellRenderer.material = this.cellMaterial;
			cellRenderer.color = this.cellColor;
			cellRenderer.size = this.cellSize;
			cellRenderer.sprite = this.cellSprite;
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

		foreach (MapSystem.Edge edge in grid.edges["horizontal"])
		{
			MapSystem.Renderer.Edge edgeRenderer = new MapSystem.Renderer.Edge (edge, this.gridScale);
			edgeRenderer.gameObject.transform.parent = edgeHorizontalGroup.transform;
			edgeRenderer.width = this.edgeWidth;
			edgeRenderer.color = this.edgeColor;
			edgeRenderer.material = this.edgeMaterial;
		}

		foreach (MapSystem.Edge edge in grid.edges["vertical"])
		{
			MapSystem.Renderer.Edge edgeRenderer = new MapSystem.Renderer.Edge (edge, this.gridScale);
			edgeRenderer.gameObject.transform.parent = edgeVerticalGroup.transform;
			edgeRenderer.width = this.edgeWidth;
			edgeRenderer.color = this.edgeColor;
			edgeRenderer.material = this.edgeMaterial;

		}
	}

	public void DrawRooms()
	{
        this.grid.roomList.Add(new MapSystem.Room(this.grid.cells[1, 1], new Vector2(2, 2)));
        this.grid.roomList.Add(new MapSystem.Room(this.grid.cells[0, 0], new Vector2(1, 2)));
        foreach (MapSystem.Room room in this.grid.roomList)
		{
            Color rColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            foreach (MapSystem.Cell cell in room.cells)
			{
				cell.renderer.color = rColor;//this.roomCellColor;
                foreach (MapSystem.Vertex vertex in cell.vertices) 
				{
					vertex.renderer.color = this.roomVertexColor;
				}
				foreach(MapSystem.Edge edge in cell.edges.Values)
				{
					edge.renderer.color = this.roomEdgeColor;
				}
			}
            MapSystem.Procedural.Room floor = new MapSystem.Procedural.Room(room);
            floor.Fill(15);
            floor.cornersQuad["topLeft"].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            floor.cornersQuad["bottomLeft"].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            floor.cornersQuad["topRight"].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            floor.cornersQuad["bottomRight"].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            floor.edgesQuadCenter["top"].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            floor.edgesQuadCenter["right"].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            floor.edgesQuadCenter["left"].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            floor.edgesQuadCenter["bottom"].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;


        }

    }
}