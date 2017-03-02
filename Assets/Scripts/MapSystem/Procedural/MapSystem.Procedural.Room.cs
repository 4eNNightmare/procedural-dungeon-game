using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem.Procedural
{ 
    public class Room
    {
        public GameObject gameObject;
        public Quad[,] quads;
        public MapSystem.Room room;
        public Dictionary<string, Quad> cornersQuad;
        public Dictionary<string, List<Quad>> edgesQuad;
        public Dictionary<string, Quad> edgesQuadCenter;

        public Room(MapSystem.Room room)
        {
            this.gameObject = new GameObject("Room");
            this.gameObject.transform.parent = room.cells[0, 0].renderer.gameObject.transform.parent.parent;
            this.room = room;
        }

        public void Fill(int scale)
        {
            edgesQuad = new Dictionary<string, List<Quad>>();
            edgesQuad["left"] = new List<Quad>();
            edgesQuad["right"] = new List<Quad>();
            edgesQuad["top"] = new List<Quad>();
            edgesQuad["bottom"] = new List<Quad>();
            int lengthX = this.room.cells.GetLength(0) * scale;
            int lengthY = this.room.cells.GetLength(1) * scale;
            quads = new Quad[lengthX, lengthY];
            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    Vector3 size = this.room.cells[0, 0].renderer.gameObject.transform.localScale / scale;
                    Vector3 position = new Vector2((this.room.cells[0, 0].vertexPosition[0, 0].x + size.x / 2) + x * size.x, (this.room.cells[0, 0].vertexPosition[0, 0].y + size.y / 2) + y * size.y);
                    Quad quad = new Quad(position, size);
                    quad.gameObject.transform.parent = this.gameObject.transform;
                    quad.gameObject.name = string.Format("Quad ({0}, {1})", x, y);
                    quad.room = this.room;
                    quads[x, y] = quad;
                    if (x == 0) edgesQuad["left"].Add(quad);
                    if (x == (lengthX - 1))edgesQuad["right"].Add(quad);
                    if (y == 0) edgesQuad["bottom"].Add(quad);
                    if (y == (lengthY - 1)) edgesQuad["top"].Add(quad);
                }
            }
            cornersQuad = new Dictionary<string, Quad>();
            cornersQuad["bottomLeft"]  = quads[0           , 0          ];
            cornersQuad["bottomRight"] = quads[lengthX - 1 , 0          ];
            cornersQuad["topLeft"]     = quads[0           , lengthY - 1];
            cornersQuad["topRight"]    = quads[lengthX - 1 , lengthY - 1];
            edgesQuadCenter = new Dictionary<string, Quad>();
            edgesQuadCenter["top"]     = quads[Mathf.FloorToInt(lengthX / 2) , lengthY - 1];
            edgesQuadCenter["bottom"]  = quads[Mathf.FloorToInt(lengthX / 2) , 0          ];
            edgesQuadCenter["left"]    = quads[0 ,           Mathf.FloorToInt(lengthY / 2)];
            edgesQuadCenter["right"]   = quads[lengthX - 1 , Mathf.FloorToInt(lengthY / 2)];

        }
    }
}
