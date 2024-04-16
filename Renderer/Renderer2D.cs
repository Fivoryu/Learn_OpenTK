using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace Hello_OpenTK.Renderer
{
    
    public class Renderer2D
    {
        struct Storage2D
        {
            public VertexArray QuadVertexArray;
            public Shader TextureShader;
        }

        public Renderer2D()
        {
        }

        private Storage2D s_Data;
        public void Init()
        {

            s_Data = new Storage2D();
            s_Data.QuadVertexArray = new VertexArray();

            List<Vector3> squareVertices = new List<Vector3>()
            {
                new Vector3(-0.5f, -0.5f, 0.0f),
                new Vector3(-0.5f, 0.5f, 0.0f),
                new Vector3( 0.5f, 0.5f, 0.0f),
                new Vector3( 0.5f, -0.5f, 0.0f),
            };

            VertexBuffer squareVB = new VertexBuffer(squareVertices);
            s_Data.QuadVertexArray.AddVertexBuffer(0, 3, squareVB);
            List<uint> squareIndices= new List<uint>()
            {
                 0, 1, 2,
                 2, 3, 0
            };

            IndexBuffer squareIB = new IndexBuffer(squareIndices);
            s_Data.QuadVertexArray.SetIndexBuffer(squareIB);

            s_Data.TextureShader = new Shader("../../../shader.vert", "../../../shader.frag");
            s_Data.TextureShader.Use();
        }

        public void Delete()
        {
            s_Data.QuadVertexArray.Unbind();
            s_Data.TextureShader.Unbind();
        }

        public void DrawQuad(Vector2 position, Vector2 size, Vector4 color, Matrix4 viewProj)
        {
            Vector3 n_position = new Vector3(position.X, position.Y, 0.0f);
            DrawQuad(n_position, size, color, viewProj);
        }

        public void DrawQuad(Vector3 position, Vector2 size, Vector4 color, Matrix4 viewProj)
        {
            s_Data.TextureShader.SetVector4("u_Color", color);

            Matrix4 transform = Matrix4.CreateTranslation(position) * Matrix4.CreateScale(size.X, size.Y, 0);
            s_Data.TextureShader.SetMatrix4("viewprojection", transform * viewProj);
            s_Data.QuadVertexArray.Bind();

            GL.DrawElements(PrimitiveType.Triangles, s_Data.QuadVertexArray.GetIndexBufferCount(), DrawElementsType.UnsignedInt, 0);
        }

    }
}
