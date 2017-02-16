using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem.Renderer
{
	public abstract class Generic
	{
		public GameObject gameObject;

		public SpriteRenderer renderer
		{
			get
			{
				return this.gameObject.GetComponent<SpriteRenderer> ();;
			}
		}

		private float _size;
		public float size
		{
			get
			{ 
				return _size;
			}
			set
			{
				_size = value;
				this.gameObject.transform.localScale = new Vector3 (value, value, value);
			}
		}

		public Sprite _sprite;
		public Sprite sprite
		{
			get
			{ 
				return _sprite;
			}
			set
			{
				this.renderer.sprite = _sprite = value;
			}
		}

		private Material _material;
		public Material material
		{
			get
			{ 
				return _material;
			}
			set
			{
				this.renderer.material = _material = value;
			}
		}

		private Color _color;
		public Color color
		{
			get
			{ 
				return _color;
			}
			set
			{
				this.renderer.material.color = _color = value;
			}
		}
	}

}
