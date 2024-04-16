using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Objects
{
    public struct FaceData
    {
        public List<Vector3> vertices;
        public List<uint> uv;
    }
    public struct Vertex
    {
        public Dictionary<string, List<Vector3>> Quad = new Dictionary<string, List<Vector3>>();
        public Vertex()
        {
            Quad["Vertices"] = new List<Vector3>();
            Quad["Vertices"].Add(new Vector3(-0.5f, -0.5f, 0.5f));
            Quad["Vertices"].Add(new Vector3(-0.5f, 0.5f,  0.5f));
            Quad["Vertices"].Add(new Vector3( 0.5f, 0.5f,  0.5f));
            Quad["Vertices"].Add(new Vector3( 0.5f, -0.5f, 0.5f));
        }
    }

    // Vector3 Sidesize = default, Vector3 Topsize = default, 

    public struct Face
    {
        public Dictionary<string, Dictionary<string, List<Vector3>>> Quad3D = new Dictionary<string, Dictionary<string, List<Vector3>>>();
        public Vector4 Color;
        public Vertex vertices = new Vertex();
        public Face (Vector3 Frontsize = default, Vector4 color = default, float Xdiff = 0, float Ydiff = 0, float Zdiff = 0)
        {
            float X = -Frontsize.X;
            float Y = -Frontsize.Y;
            float Z = -Frontsize.Z;
            if (Xdiff != 0)
            {
                X = Xdiff;
            }
            else if (Ydiff != 0)
            {
                Y = Ydiff;
            }
            else if (Zdiff != 0)
            {
                Z = Zdiff;
            }

            Quad3D["Front"]["Vertices"] = new List<Vector3>();
            Quad3D["Front"]["Vertices"].Add(new Vector3(X,                   Y,                    Zdiff + Frontsize.Z));
            Quad3D["Front"]["Vertices"].Add(new Vector3(X,                   Ydiff + Frontsize.Y,  Zdiff + Frontsize.Z));
            Quad3D["Front"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Ydiff + Frontsize.Y,  Zdiff + Frontsize.Z));
            Quad3D["Front"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Y,                    Zdiff + Frontsize.Z));

            Quad3D["Back"]["Vertices"] = new List<Vector3>();
            Quad3D["Back"]["Vertices"].Add(new Vector3(X,                   Y,                   Z));
            Quad3D["Back"]["Vertices"].Add(new Vector3(X,                   Ydiff + Frontsize.Y, Z));
            Quad3D["Back"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Ydiff + Frontsize.Y, Z));
            Quad3D["Back"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Y,                   Z));

            Quad3D["Left"]["Vertices"] = new List<Vector3>();
            Quad3D["Left"]["Vertices"].Add(new Vector3(X, Y,                   Zdiff + Frontsize.Z));
            Quad3D["Left"]["Vertices"].Add(new Vector3(X, Ydiff + Frontsize.Y, Zdiff + Frontsize.Z));
            Quad3D["Left"]["Vertices"].Add(new Vector3(X, Ydiff + Frontsize.Y, Z                  ));
            Quad3D["Left"]["Vertices"].Add(new Vector3(X, Y,                   Z                  ));

            Quad3D["Right"]["Vertices"] = new List<Vector3>();
            Quad3D["Right"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Y,                   Zdiff + Frontsize.Z));
            Quad3D["Right"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Ydiff + Frontsize.Y, Zdiff + Frontsize.Z));
            Quad3D["Right"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Ydiff + Frontsize.Y, Z                  ));
            Quad3D["Right"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Y,                   Z                  ));

            Quad3D["Top"]["Vertices"] = new List<Vector3>();
            Quad3D["Top"]["Vertices"].Add(new Vector3(X,                   Ydiff + Frontsize.Y, Zdiff + Frontsize.Z));
            Quad3D["Top"]["Vertices"].Add(new Vector3(X,                   Ydiff + Frontsize.Y, Z                  ));
            Quad3D["Top"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Ydiff + Frontsize.Y, Z                  ));
            Quad3D["Top"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X, Ydiff + Frontsize.Y, Zdiff + Frontsize.Z));

            Quad3D["Bottom"]["Vertices"] = new List<Vector3>();
            Quad3D["Bottom"]["Vertices"].Add(new Vector3(X,                  Y, Zdiff + Frontsize.Z));
            Quad3D["Bottom"]["Vertices"].Add(new Vector3(X,                  Y, Z                  ));
            Quad3D["Bottom"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X,Y, Z                  ));
            Quad3D["Bottom"]["Vertices"].Add(new Vector3(Xdiff + Frontsize.X,Y, Zdiff + Frontsize.Z));

            Color = color;
        }
    }

}
