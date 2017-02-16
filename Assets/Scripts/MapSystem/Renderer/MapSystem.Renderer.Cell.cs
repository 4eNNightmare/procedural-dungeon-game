using UnityEngine;
using System.Collections;

namespace MapSystem.Renderer{
	public class Cell : Generic
	{
		public Cell(MapSystem.Cell cell)
		{
			this.gameObject = new GameObject(string.Format("Cell {0}", cell.vertices[0,0].position), typeof(SpriteRenderer));
			this.gameObject.transform.position = cell.center;
		}

	}
}

