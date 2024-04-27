using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using Hello_OpenTK.Renderer;

using System.Text.Json.Serialization;

namespace Hello_OpenTK.Componentes
{
    public struct Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(float x)
        {
            X = x;
            Y = x;
            Z = x;
        }

        public static Vector operator *(Vector vec, Vector scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            return vec;
        }

        public static Vector operator +(Vector vec, Vector scale)
        {
            vec.X += scale.X;
            vec.Y += scale.Y;
            vec.Z += scale.Z;
            return vec;
        }

        public bool Equals(Vector other)
        {
            if (X == other.X && Y == other.Y)
            {
                return Z == other.Z;
            }

            return false;
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }

    }
    public struct VertexP
    {
        [JsonPropertyName("Posicion")]
        public Vector Position { get; set; }
        [JsonPropertyName("Color")]
        public Vector Color { get; set; }
        public VertexP()
        {
            Position = new Vector();
            Color = new Vector();
        }
        public VertexP(Vector position, Vector color)
        {
            Position = position;
            Color = color;
        }
    }

    public interface ITriangle
    {
        void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f);
        void Load();
        void Unbind();
    }
    public class Triangle : ITriangle
    {
        [JsonPropertyName("Vertices")]
        public List<VertexP> m_Vertices { get; set; }
        private Shader shader;
        private int VAO, VBO;
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }

        public Triangle()
        {
            m_Vertices = new List<VertexP>();
            m_Position = new Vector(0.0f, 0.0f, 0.0f);
            shader = new Shader("../../../shader.vert", "../../../FlatColor.frag");
        }

        public Triangle(List<Vector> vertices, Vector Color, Vector Position = default, float xRot = 0, float yRot = 0, float zRot = 0, Vector Scale = default)
        {
            this.m_Position = Position;

            if (Scale == default)
            {
                Scale = new Vector(1.0f);
            }

            for (int i = 0; i < 3; i++)
            {
                vertices[i] += Position;
                vertices[i] *= Scale;
                float x = vertices[i].X;
                float y = vertices[i].Y;
                float z = vertices[i].Z;
                Vector xrot = new Vector(x, MathF.Cos(xRot) * y - MathF.Sin(xRot) * z, MathF.Sin(xRot) * y + MathF.Cos(xRot) * z);
                vertices[i] = xrot;
                Vector yrot = new Vector(MathF.Cos(yRot) * x + MathF.Sin(yRot) * z, y, -MathF.Sin(yRot) * x + MathF.Cos(yRot) * z);
                vertices[i] = yrot;
                Vector zrot = new Vector(MathF.Cos(zRot) * x - MathF.Sin(zRot) * y, MathF.Sin(zRot) * x + MathF.Cos(zRot) * y, z);
                vertices[i] = zrot;
            }

            m_Vertices = new List<VertexP>
            {
                new VertexP(vertices[0], Color),
                new VertexP(vertices[1], Color),
                new VertexP(vertices[2], Color),
            };

            shader = new Shader("../../../shader.vert", "../../../FlatColor.frag");

            Load();
        }

        public void Load()
        {
            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, m_Vertices.Count * Vector3.SizeInBytes * 2, m_Vertices.ToArray(), BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2, 0);

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2, Vector3.SizeInBytes);

            GL.BindVertexArray(0);

        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f)
        {
            shader.Use();
            GL.BindVertexArray(VAO);
            Matrix4 matrix4 = Matrix4.Identity * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(xRot))
                        * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(yRot))
                        * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(zRot)) *
                        Matrix4.CreateTranslation(Position) * ViewProjection;
            shader.SetMatrix4("viewprojection", matrix4);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void Unbind()
        {
            shader.Unbind();
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.DeleteVertexArray(VAO);
        }
    }

    public class TriangleDTO
    {
        [JsonPropertyName("Vertices")]
        public List<VertexP> Vertices { get; set; }
        [JsonPropertyName("Posicion")]
        public Vector Position { get; set; }

        public TriangleDTO()
        {
            Vertices = new List<VertexP>();
            Position = new Vector(0.0f, 0.0f, 0.0f);
        }

            public TriangleDTO(List<Vector> vertices, Vector Color, Vector Position = default)
        {
            this.Position = Position;

            Vertices = new List<VertexP>
            {
                new VertexP(vertices[0], Color),
                new VertexP(vertices[1], Color),
                new VertexP(vertices[2], Color),
            };

        }
    }
}
