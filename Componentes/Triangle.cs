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

        public static Vector operator -(Vector vec, Vector scale)
        {
            vec.X -= scale.X;
            vec.Y -= scale.Y;
            vec.Z -= scale.Z;
            return vec;
        }

        public static Vector operator /(Vector vec, float div)
        {
            vec.X /= div;
            vec.Y /= div;
            vec.Z /= div;
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

    public struct TransformComponent
    {
        [JsonPropertyName("Translation")]
        public Vector Translation { get; set; }
        [JsonPropertyName("Rotation")]
        public Vector Rotation { get; set; }
        [JsonPropertyName("Scale")]
        public Vector Scale { get; set; }

        public TransformComponent()
        {
            Translation = new Vector();
            Rotation = new Vector();
            Scale = new Vector(1.0f);
        }

        public void SetTranslation(Vector translation)
        {
            Translation = translation;
        }

        public void SetRotation(Vector rotation)
        {
            Rotation = rotation;
        }

        public void SetScale(Vector scale)
        {
            Scale = scale;
        }

        public Vector GetTranslation() { return Translation; }
        public Vector GetRotation() { return Rotation; }
        public Vector GetScale() { return Scale; }

        public Matrix4 GetTransform()
        {
            Vector3 rot = new Vector3(Rotation.X, Rotation.Y, Rotation.Z);
            Vector3 translation = new Vector3(Translation.X, Translation.Y, Translation.Z);
            Vector3 scale = new Vector3(Scale.X, Scale.Y, Scale.Z);

            return Matrix4.CreateTranslation(translation) * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rot.X))
                   * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rot.Y)) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rot.Z))
                   * Matrix4.CreateScale(scale);
        }
    }

    public interface ITriangle
    {
        public Vector FirstPosition { get; set; }
        public Vector m_Position { get; set; }
        public Vector m_Rotation {  get; set; }
        public Vector m_Scale { get; set; }
        void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f);
        void Load();
        void Unbind();
        public void SetTranslation(Vector Translation);
        public void SetRotation(Vector Rotation);
        public void SetScale(Vector Scale);
    }
    public class Triangle : ITriangle
    {
        [JsonPropertyName("Vertices")]
        public List<VertexP> m_Vertices { get; set; }
        private Shader shader;
        private int VAO, VBO;
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }
        [JsonPropertyName("Rotation")]
        public Vector m_Rotation { get; set; }
        [JsonPropertyName("Scale")]
        public Vector m_Scale { get; set; }
        private Matrix4 Rotation, Position, Scale;
        [JsonPropertyName("InitialPosition")]
        public Vector FirstPosition { get; set; }

        public Triangle()
        {
            this.m_Position = new Vector();
            this.m_Rotation = new Vector();
            this.m_Scale = new Vector(1.0f);
            this.Position = this.Rotation = Matrix4.Identity;
            Scale = Matrix4.Identity;
            m_Vertices = new List<VertexP>();
            m_Position = new Vector(0.0f, 0.0f, 0.0f);
            shader = new Shader("../../../shader.vert", "../../../FlatColor.frag");
        }

        public Triangle(List<Vector> vertices, Vector Color, Vector Position = default, float xRot = 0, float yRot = 0, float zRot = 0, Vector Scale = default)
        {
            this.m_Position = FirstPosition = Position;
            this.m_Rotation = new Vector();
            this.m_Scale = new Vector(1.0f);
            this.Position = this.Rotation = Matrix4.Identity;
            this.Scale = Matrix4.Identity;

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
        }

        public void SetTranslation(Vector Translation)
        {
            Position = Matrix4.CreateTranslation(Translation.X, Translation.Y, Translation.Z);
            m_Position = Translation;
        }

        public void SetRotation(Vector Rotation)
        {
            this.Rotation = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation.Z))
                   * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotation.Y)) * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotation.X));
            m_Rotation = Rotation;
        }

        public void SetScale(Vector Scale)
        {
            this.Scale = Matrix4.CreateScale(Scale.X, Scale.Y, Scale.Z);
            m_Scale = Scale;
        }

        public void Load()
        {
            this.Position = Matrix4.CreateTranslation(m_Position.X, m_Position.Y, m_Position.Z);
            this.Scale = Matrix4.CreateScale(1.0f);
            this.Rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.0f))
                   * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.0f));

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
            Matrix4 matrix = Rotation * Scale * this.Position * ViewProjection;
            shader.SetMatrix4("viewprojection", matrix);
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
