using UnityEngine;
using System.Collections;

namespace MapSystem.Renderer{
	public class Edge
	{
		public GameObject gameObject;

		public LineRenderer renderer
		{
			get
			{
				return this.gameObject.GetComponent<LineRenderer> ();
			}
		}

		private float _width
		{
			get
			{
				return renderer.widthMultiplier;
			}
		}

		public float width
		{
			get
			{
				return _width;
			}
			set
			{
				renderer.widthMultiplier = value;
			}
		}

		public Material material
		{
			get
			{
				return renderer.material;
			}
			set
			{
				renderer.material = value;
			}
		}

		public Color color
		{
			get
			{
				return renderer.startColor;
			}
			set
			{
				renderer.startColor = renderer.endColor = value;
			}
		}

		public Edge(MapSystem.Edge edge)
		{
			this.gameObject = new GameObject(string.Format("Edge {0}", edge.start.position), typeof(LineRenderer));
			this.renderer.SetPosition (0, edge.start.position);
			this.renderer.SetPosition (1, edge.end.position);
			this.renderer.receiveShadows = false;
			this.renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			this.gameObject.transform.position = edge.center;
		}

	}
}

