using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using Hello_OpenTK.Renderer;


namespace Hello_OpenTK.Objects
{

    public class Cara
    {
        public List<Vector3> Puntos { get; set; }

        public Cara(Vector3 puntos = default, float Xdiff = 0, float Ydiff = 0, float Zdiff = 0)
        {
            float X = -puntos.X;
            float Y = -puntos.Y;
            float Z = -puntos.Z;
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
            Puntos = new List<Vector3>()
            {
                new Vector3(X, Y, Zdiff + puntos.Z),
                new Vector3(X, Ydiff + puntos.Y, Zdiff + puntos.Z),
                new Vector3(Xdiff + puntos.X, Ydiff + puntos.Y, Zdiff + puntos.Z),
                new Vector3(Xdiff + puntos.X, Y, Zdiff + puntos.Z)
            };
        }
    }

    public class ObjetoD
    {
        public Dictionary<string, Cara> Caras {  get; set; }

        public ObjetoD()
        {
            Caras = new Dictionary<string, Cara>();
        }
    }

    public struct Vertex2
    {
        public Vector3 Position;
        public Vector3 Color;
        public Vertex2(Vector3 position, Vector3 color)
        {
            Position = position;
            Color = color;
        }
    }

    public class Operador
    {
        public static List<Vertex2> Translation(List<Vertex2> Vertices, float x  = 0, float y = 0, float z = 0)
        {
            for (int i = 0; i <  Vertices.Count; i++) 
            {
                Vertex2 NewVertex = new Vertex2(Vertices[i].Position + new Vector3(x, y, z), Vertices[i].Color);
                Vertices[i] = NewVertex;
            }
            return Vertices;
        }

        public static List<Vertex2> Translation(List<Vertex2> Vertices, float x = 0)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex2 NewVertex = new Vertex2(Vertices[i].Position + new Vector3(x), Vertices[i].Color);
                Vertices[i] = NewVertex;
            }
            return Vertices;
        }

        public static List<Vertex2> Scale(List<Vertex2> Vertices, float x = 1, float y = 1, float z = 1)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex2 NewVertex = new Vertex2(new Vector3(Vertices[i].Position.X * x, Vertices[i].Position.Y * y, Vertices[i].Position.Z * z), Vertices[i].Color);
                Vertices[i] = NewVertex;
            }
            return Vertices;
        }

        public static List<Vertex2> Scale(List<Vertex2> Vertices, float x = 1)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex2 NewVertex = new Vertex2(new Vector3(Vertices[i].Position.X * x, Vertices[i].Position.Y * x, Vertices[i].Position.Z * x), Vertices[i].Color);
                Vertices[i] = NewVertex;
            }
            return Vertices;
        }
    }

    public class Mesh
    {
        private List<Vertex2> vertices;
        private List<uint> indices;
        private Shader shader;

        private int VAO, VBO, EBO;

        private void setupMesh()
        {
            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes * 2, vertices.ToArray(), BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Count * sizeof(uint), indices.ToArray(), BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2, 0);

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2, Vector3.SizeInBytes);

            GL.BindVertexArray(0);
        }

        public Mesh(List<Vertex2> vertices, List<uint> indices)
        {
            this.vertices = vertices;
            this.indices = indices;
            shader = new Shader("../../../shader.vert", "../../../FlatColor.frag");

            setupMesh();
        }

        public void Draw(Matrix4 viewprojection)
        {
            shader.Use();
            GL.BindVertexArray(VAO);
            shader.SetMatrix4("viewprojection", viewprojection);
            GL.DrawElements(BeginMode.Triangles, indices.Count(), DrawElementsType.UnsignedInt, 0);
        }
    }

    public class Scene
    {
        public Dictionary<string, Mesh> Objetos;

        public Scene()
        {
            Objetos = new Dictionary<string, Mesh>();
        }

        public void Render(Matrix4 viewprojection)
        {
            foreach(KeyValuePair<string, Mesh> kvp in Objetos)
            {
                Objetos[kvp.Key].Draw(viewprojection);
            }
        }
    }
}
