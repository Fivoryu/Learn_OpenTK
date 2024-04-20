using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Hello_OpenTK.Renderer;

namespace Hello_OpenTK.Componentes
{
    public struct VertexP
    {
        public Vector3 Position;
        public Vector3 Color;
        public VertexP(Vector3 position, Vector3 color)
        {
            Position = position;
            Color = color;
        }
    }

    public interface ITriangle
    {
        void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f);
        void Unbind();
    }
    public class Triangle : ITriangle
    {
        private List<VertexP> m_Vertices { get; set; }
        private Shader shader;
        private int VAO, VBO;
        public Vector3 m_Position { get; set; }

        public Triangle(List<Vector3> vertices, Vector3 Color, Vector3 Position = default)
        {
            this.m_Position = Position;

            m_Vertices = new List<VertexP>
            {
                new VertexP(vertices[2], Color),
                new VertexP(vertices[0], Color),
                new VertexP(vertices[1], Color),
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
}
