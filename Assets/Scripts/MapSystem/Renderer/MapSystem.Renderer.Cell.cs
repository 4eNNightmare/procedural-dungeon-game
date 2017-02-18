using UnityEngine;
using System.Collections;

namespace MapSystem.Renderer{
	public class Cell : Generic
	{
		public MapSystem.Cell cell;

		public Cell(MapSystem.Cell cell, float scale)
		{
			this.cell = cell;
			this.cell.renderer = this;
			this.scale = scale;
			this.gameObject = new GameObject(string.Format("Cell {0}", cell.vertices[0,0].position), typeof(SpriteRenderer));
			this.gameObject.transform.position = cell.center;
		}

	}
}

