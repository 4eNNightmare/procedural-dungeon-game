using System;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem.Procedural
{
    public class Quad
    {
        public MapSystem.Room room;
        public Vector2 position;
        public GameObject gameObject;

        public Quad(Vector3 position, Vector3 size)
        {
            this.gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
            this.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Materials/test") as Material;
            this.gameObject.transform.localScale = size;
            this.gameObject.transform.position = position;
        }
    }
}
