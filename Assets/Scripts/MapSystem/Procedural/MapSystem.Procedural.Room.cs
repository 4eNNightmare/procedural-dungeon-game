using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem.Procedural
{ 
    public class Room
    {
        public GameObject gameObject;
        public GameObject[,] quads;
        public MapSystem.Room room;

        public Room(MapSystem.Room room)
        {
            this.gameObject = new GameObject("Room");
            this.gameObject.transform.parent = room.cells[0, 0].renderer.gameObject.transform.parent.parent;
            this.room = room;
        }

        public void Fill(int scale)
        {
            int roomCellsX = this.room.cells.GetLength(0) * scale;
            int roomCellsY = this.room.cells.GetLength(1) * scale;
            quads = new GameObject[roomCellsX, roomCellsY];
            for (int y = 0; y < roomCellsY; y++)
            {
                for (int x = 0; x < roomCellsX; x++)
                {
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.GetComponent<MeshRenderer>().material = Resources.Load("Materials/test") as Material;
                    Vector3 quad_size = this.room.cells[0, 0].renderer.gameObject.transform.localScale / scale;
                    quad.transform.localScale = quad_size;
                    quad.transform.position = new Vector2((this.room.cells[0, 0].vertexPosition[0,0].x + quad_size.x / 2) + x * quad_size.x, (this.room.cells[0, 0].vertexPosition[0, 0].y + quad_size.y / 2) + y * quad_size.y);
                    quad.transform.parent = this.gameObject.transform;
                    quad.name = string.Format("Quad ({0}, {1})", x, y);
                }
            }

        }

    }
}
