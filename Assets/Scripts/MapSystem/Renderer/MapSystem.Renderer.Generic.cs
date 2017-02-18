using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem.Renderer
{
	public abstract class Generic
	{
		public GameObject _gameOject;
		public GameObject gameObject
		{
			get
			{
				return _gameOject;
			}
			set
			{
				_gameOject = value;
				_gameOject.isStatic = true;
			}
		}

		public SpriteRenderer renderer
		{
			get
			{
				return this.gameObject.GetComponent<SpriteRenderer> ();;
			}
		}

		public float scale = 1;

		private float _size;
		public float size
		{
			get
			{ 
				return _size;
			}
			set
			{
				_size = value * scale;
				this.gameObject.transform.localScale = new Vector3 (_size, _size, _size);
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

		public void setSprite(Sprite sprite, float pixelsPerUnit)
		{
			Texture2D t = sprite.texture;
			this.sprite = Sprite.Create (t, new Rect (0.0f, 0.0f, t.width, t.height), new Vector2 (0.5f, 0.5f), pixelsPerUnit);
		}
	}

}
