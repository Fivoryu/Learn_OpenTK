using Hello_OpenTK.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace Hello_OpenTK.Objects
{
    public class TV
    {
        private readonly float[] Screen =
        {
            -0.5f, -0.5f, -0.125f,  0.0f, 0.0f, // Bottom left
             0.5f, -0.5f, -0.125f,  1.0f, 0.0f, // Bottom right
             0.5f,  0.5f, -0.125f,  1.0f, 1.0f, // Top right
             0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.125f,  0.0f, 1.0f, // Top left
            -0.5f, -0.5f, -0.125f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.125f,  0.0f, 0.0f, // Bottom left
             0.5f, -0.5f,  0.125f,  1.0f, 0.0f, // Bottom right
             0.5f,  0.5f,  0.125f,  1.0f, 1.0f, // Top right
             0.5f,  0.5f,  0.125f,  1.0f, 1.0f,
            -0.5f,  0.5f,  0.125f,  0.0f, 1.0f, // Top left
            -0.5f, -0.5f,  0.125f,  0.0f, 0.0f,

            -0.5f,  0.5f,  0.125f,  1.0f, 0.0f,
            -0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
            -0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.125f,  0.0f, 0.0f,
            -0.5f,  0.5f,  0.125f,  1.0f, 0.0f,

             0.5f,  0.5f,  0.125f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
             0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
             0.5f, -0.5f,  0.125f,  0.0f, 0.0f,
             0.5f,  0.5f,  0.125f,  1.0f, 0.0f,

            -0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.125f,  1.0f, 1.0f,
             0.5f, -0.5f,  0.125f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.125f,  1.0f, 0.0f,
            -0.5f, -0.5f,  0.125f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.125f,  0.0f, 1.0f,

            -0.5f,  0.5f, -0.125f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.125f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.125f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.125f,  0.0f, 0.0f,
            -0.5f,  0.5f, -0.125f,  0.0f, 1.0f
        };

        private readonly float[] UpEdge =
        {
            -0.5625f, 0.5f,    -0.125f,  0.0f, 0.0f, // Bottom left
             0.5625f, 0.5f,    -0.125f,  1.0f, 0.0f, // Bottom right
             0.5625f, 0.5625f, -0.125f,  1.0f, 1.0f, // Top right
             0.5625f, 0.5625f, -0.125f,  1.0f, 1.0f,
            -0.5625f, 0.5625f, -0.125f,  0.0f, 1.0f, // Top left
            -0.5625f, 0.5f,    -0.125f,  0.0f, 0.0f,

            -0.5625f, 0.5f,     0.125f,  0.0f, 0.0f, // Bottom left
             0.5625f, 0.5f,     0.125f,  1.0f, 0.0f, // Bottom right
             0.5625f, 0.5625f,  0.125f,  1.0f, 1.0f, // Top right
             0.5625f, 0.5625f,  0.125f,  1.0f, 1.0f,
            -0.5625f, 0.5625f,  0.125f,  0.0f, 1.0f, // Top left
            -0.5625f, 0.5f,  0.125f,     0.0f, 0.0f,

            -0.5625f, 0.5625f,  0.125f,  1.0f, 0.0f, // Bottom left
            -0.5625f, 0.5625f, -0.125f,  1.0f, 1.0f, // Bottom right
            -0.5625f, 0.5f,    -0.125f,  0.0f, 1.0f, // Top right
            -0.5625f, 0.5f,    -0.125f,  0.0f, 1.0f,
            -0.5625f, 0.5f,     0.125f,  0.0f, 0.0f, // Top left
            -0.5625f, 0.5625f,  0.125f,  1.0f, 0.0f,

             0.5625f, 0.5625f,  0.125f,  1.0f, 0.0f,
             0.5625f, 0.5625f, -0.125f,  1.0f, 1.0f,
             0.5625f, 0.5f,    -0.125f,  0.0f, 1.0f,
             0.5625f, 0.5f,    -0.125f,  0.0f, 1.0f,
             0.5625f, 0.5f,     0.125f,  0.0f, 0.0f,
             0.5625f, 0.5625f,  0.125f,  1.0f, 0.0f,

            -0.5625f, 0.5f,    -0.125f,  0.0f, 1.0f,
             0.5625f, 0.5f,    -0.125f,  1.0f, 1.0f,
             0.5625f, 0.5f,     0.125f,  1.0f, 0.0f,
             0.5625f, 0.5f,     0.125f,  1.0f, 0.0f,
            -0.5625f, 0.5f,     0.125f,  0.0f, 0.0f,
            -0.5625f, 0.5f,    -0.125f,  0.0f, 1.0f,

            -0.5625f, 0.5625f, -0.125f,  0.0f, 1.0f,
             0.5625f, 0.5625f, -0.125f,  1.0f, 1.0f,
             0.5625f, 0.5625f,  0.125f,  1.0f, 0.0f,
             0.5625f, 0.5625f,  0.125f,  1.0f, 0.0f,
            -0.5625f, 0.5625f,  0.125f,  0.0f, 0.0f,
            -0.5625f, 0.5625f, -0.125f,  0.0f, 1.0f
        };

        private readonly float[] LeftEdge =
        {
            -0.5625f, -0.5f, -0.125f,  0.0f, 0.0f,  // Bottom left
            -0.5f,    -0.5f, -0.125f,  1.0f, 0.0f,  // Bottom right
            -0.5f,     0.5f, -0.125f,  1.0f, 1.0f,  // Top right
            -0.5f,     0.5f, -0.125f,  1.0f, 1.0f,
            -0.5625f,  0.5f,  -0.125f,  0.0f, 1.0f, // Top left
            -0.5625f, -0.5f,  -0.125f,  0.0f, 0.0f,

            -0.5625f, -0.5f, 0.125f,  0.0f, 0.0f,   // Bottom left
            -0.5f,    -0.5f, 0.125f,  1.0f, 0.0f,   // Bottom right
            -0.5f,     0.5f, 0.125f,  1.0f, 1.0f,   // Top right
            -0.5f,     0.5f, 0.125f,  1.0f, 1.0f,
            -0.5625f,  0.5f, 0.125f,  0.0f, 1.0f,   // Top left
            -0.5625f, -0.5f, 0.125f,  0.0f, 0.0f,

            -0.5625f,  0.5f,  0.125f,  1.0f, 0.0f,
            -0.5625f,  0.5f, -0.125f,  1.0f, 1.0f,
            -0.5625f, -0.5f, -0.125f,  0.0f, 1.0f,
            -0.5625f, -0.5f, -0.125f,  0.0f, 1.0f,
            -0.5625f, -0.5f,  0.125f,  0.0f, 0.0f,
            -0.5625f,  0.5f,  0.125f,  1.0f, 0.0f,

             -0.5f,  0.5f,  0.125f,  1.0f, 0.0f,
             -0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
             -0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
             -0.5f, -0.5f, -0.125f,  0.0f, 1.0f,
             -0.5f, -0.5f,  0.125f,  0.0f, 0.0f,
             -0.5f,  0.5f,  0.125f,  1.0f, 0.0f,

            -0.5625f, -0.5f, -0.125f,  0.0f, 1.0f,
             -0.5f,   -0.5f, -0.125f,  1.0f, 1.0f,
             -0.5f,   -0.5f,  0.125f,  1.0f, 0.0f,
             -0.5f,   -0.5f,  0.125f,  1.0f, 0.0f,
             -0.5625f,   -0.5f,  0.125f,  0.0f, 0.0f,
            -0.5625f, -0.5f, -0.125f,  0.0f, 1.0f,

            -0.5625f, 0.5f, -0.125f,  0.0f, 1.0f,
            -0.5f,    0.5f, -0.125f,  1.0f, 1.0f,
            -0.5f,    0.5f,  0.125f,  1.0f, 0.0f,
            -0.5f,    0.5f,  0.125f,  1.0f, 0.0f,
            -0.5625f, 0.5f,  0.125f,  0.0f, 0.0f,
            -0.5625f, 0.5f, -0.125f,  0.0f, 1.0f
        };

        private readonly float[] Support =
        {
            -0.0625f, -0.75f,   -0.125f,  0.0f, 0.0f,   // Bottom left
             0.0625f, -0.75f,   -0.125f,  1.0f, 0.0f,   // Bottom right
             0.0625f, -0.5625f, -0.125f,   1.0f, 1.0f,  // Top right
             0.0625f, -0.5625f, -0.125f,   1.0f, 1.0f,
            -0.0625f, -0.5625f, -0.125f,   0.0f, 1.0f,  // Top left
            -0.0625f, -0.75f,   -0.125f,  0.0f, 0.0f,

            -0.0625f, -0.75f,    0.125f, 0.0f, 0.0f,    // Bottom left
             0.0625f, -0.75f,    0.125f, 1.0f, 0.0f,    // Bottom right
             0.0625f, -0.5625f,  0.125f,   1.0f, 1.0f,  // Top right
             0.0625f, -0.5625f,  0.125f,   1.0f, 1.0f,
            -0.0625f, -0.5625f,  0.125f,   0.0f, 1.0f,  // Top left
            -0.0625f, -0.75f,    0.125f, 0.0f, 0.0f,

            -0.0625f, -0.5625f,  0.125f,   1.0f, 0.0f,  // Bottom left
            -0.0625f, -0.5625f, -0.125f,   1.0f, 1.0f,  // Bottom right
            -0.0625f, -0.75f,   -0.125f,   0.0f, 1.0f,  // Top right
            -0.0625f, -0.75f,   -0.125f,   0.0f, 1.0f,
            -0.0625f, -0.75f,    0.125f,  0.0f, 0.0f,   // Top left
            -0.0625f, -0.75f,    0.125f,  1.0f, 0.0f,

             0.0625f, -0.5625f,  0.125f,   1.0f, 0.0f,  // Bottom left
             0.0625f, -0.5625f, -0.125f,   1.0f, 1.0f,  // Bottom right
             0.0625f, -0.75f,   -0.125f,  0.0f, 1.0f,   // Top right
             0.0625f, -0.75f,   -0.125f,  0.0f, 1.0f,
             0.0625f, -0.75f,    0.125f, 0.0f, 0.0f,    // Top left
             0.0625f, -0.5625f,  0.125f,   1.0f, 0.0f,

            -0.0625f, -0.75f,   -0.125f,  0.0f, 1.0f,   // Bottom left
             0.0625f, -0.75f,   -0.125f,  1.0f, 1.0f,   // Bottom right
             0.0625f, -0.75f,    0.125f,  1.0f, 0.0f,   // Top right
             0.0625f, -0.75f,    0.125f,  1.0f, 0.0f,
            -0.0625f, -0.75f,    0.125f,  0.0f, 0.0f,   // Top left
            -0.0625f, -0.75f,   -0.125f,  0.0f, 1.0f,

            -0.0625f, -0.5625f, -0.125f,  0.0f, 1.0f,   // Bottom left
             0.0625f, -0.5625f, -0.125f,  1.0f, 1.0f,   // Bottom right
             0.0625f, -0.5625f,  0.125f,  1.0f, 0.0f,   // Top right
             0.0625f, -0.5625f,  0.125f,  1.0f, 0.0f,
            -0.0625f, -0.5625f,  0.125f,  0.0f, 0.0f,   // Top left
            -0.0625f, -0.5625f, -0.125f,  0.0f, 1.0f
        };

        private readonly float[] Support2 =
        {
            -0.25f, -0.875f, -0.125f,  0.0f, 0.0f,  // Bottom left
             0.25f, -0.875f, -0.125f,  1.0f, 0.0f,  // Bottom right
             0.25f,  -0.75f, -0.125f,  1.0f, 1.0f,  // Top right
             0.25f,  -0.75f, -0.125f,  1.0f, 1.0f,
            -0.25f,  -0.75f, -0.125f,  0.0f, 1.0f,  // Top left
            -0.25f, -0.875f, -0.125f,  0.0f, 0.0f,

            -0.25f, -0.875f,  0.125f,  0.0f, 0.0f,  // Bottom left
             0.25f, -0.875f,  0.125f,  1.0f, 0.0f,  // Bottom right
             0.25f, -0.75f,   0.125f, 1.0f, 1.0f,   // Top right
             0.25f, -0.75f,   0.125f, 1.0f, 1.0f,
            -0.25f, -0.75f,   0.125f, 0.0f, 1.0f,   // Top left
            -0.25f, -0.875f,  0.125f,  0.0f, 0.0f,

            -0.25f, -0.75f,   0.125f,  1.0f, 0.0f,  // Bottom left
            -0.25f, -0.75f,  -0.125f,  1.0f, 1.0f,  // Bottom right
            -0.25f, -0.875f, -0.125f,  0.0f, 1.0f,  // Top right
            -0.25f, -0.875f, -0.125f,  0.0f, 1.0f,
            -0.25f, -0.875f,  0.125f,  0.0f, 0.0f,  // Top left
            -0.25f, -0.75f,   0.125f,  1.0f, 0.0f,

             0.25f, -0.75f,   0.125f,  1.0f, 0.0f,  // Bottom left
             0.25f, -0.75f,  -0.125f,  1.0f, 1.0f,  // Bottom right
             0.25f, -0.875f, -0.125f,  0.0f, 1.0f,  // Top right
             0.25f, -0.875f, -0.125f,  0.0f, 1.0f,
             0.25f, -0.875f,  0.125f,  0.0f, 0.0f,  // Top left
             0.25f, -0.75f,   0.125f,  1.0f, 0.0f,

            -0.25f, -0.875f, -0.125f,  0.0f, 1.0f,
             0.25f, -0.875f, -0.125f,  1.0f, 1.0f,
             0.25f, -0.875f,  0.125f,  1.0f, 0.0f,
             0.25f, -0.875f,  0.125f,  1.0f, 0.0f,
            -0.25f, -0.875f,  0.125f,  0.0f, 0.0f,
            -0.25f, -0.875f, -0.125f,  0.0f, 1.0f,

            -0.25f, -0.75f,  -0.125f,  0.0f, 1.0f,
             0.25f, -0.75f,  -0.125f,  1.0f, 1.0f,
             0.25f, -0.75f,   0.125f,  1.0f, 0.0f,
             0.25f, -0.75f,   0.125f,  1.0f, 0.0f,
            -0.25f, -0.75f,   0.125f,  0.0f, 0.0f,
            -0.25f, -0.75f,  -0.125f,  0.0f, 1.0f
        };

        uint[] indices = { // Note that we start from 0!        
            0, 1, 3,    // First triangle 
            1, 2, 3     // Second triangle
        };

        public TV()
        {
        }

        private int rvao;                       
        private int uevao, levao, devao, revao;
        private int suvao, su2vao;
        private int bvao;

        private Shader shaderScreen; 
        private Shader UpShader;
        private Shader LeftShader;
        private Shader DownShader;
        private Shader RightShader;
        private Shader SupportShader;
        private Shader Support2Shader;
        private Shader BackShader;

        private void GenVertex2(ref int VAO,ref Shader shader, float[] vertices, uint[] indices, string vertFilePath, string fragFilePath)
        {
            int vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            shader = new Shader(vertFilePath, fragFilePath);

            var vertexLocation = shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            int ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        }

        public void Load()
        {
            GenVertex2(ref rvao, ref shaderScreen, Screen, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref uevao, ref UpShader, UpEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref devao, ref DownShader, UpEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref levao, ref LeftShader, LeftEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref revao, ref RightShader, LeftEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref suvao, ref SupportShader, Support, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref su2vao, ref Support2Shader, Support2, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref bvao, ref BackShader, Screen, indices, "../../../shader.vert", "../../../shader.frag");

            shaderScreen.SetVector4("u_Color", new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
            UpShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            DownShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            LeftShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            RightShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            SupportShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            Support2Shader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            BackShader.SetVector4("u_Color", new Vector4(0.18f, 0.18f, 0.18f, 1.0f));
        }
        
        public void Render(Matrix4 viewprojectionMatrix = default)
        {

            GL.BindVertexArray(rvao);

            shaderScreen.Use();
            shaderScreen.SetMatrix4("viewprojection", viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(uevao);

            UpShader.Use();
            UpShader.SetMatrix4("viewprojection", viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(devao);

            DownShader.Use();
            DownShader.SetMatrix4("viewprojection", Matrix4.Identity * Matrix4.CreateTranslation(0.0f, -1.0625f, 0.0f) * viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(levao);

            LeftShader.Use();
            LeftShader.SetMatrix4("viewprojection", viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(revao);

            RightShader.Use();
            RightShader.SetMatrix4("viewprojection", Matrix4.Identity * Matrix4.CreateTranslation(1.0625f, 0.0f, 0.0f) 
                                                    * viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(suvao);

            SupportShader.Use();
            SupportShader.SetMatrix4("viewprojection", viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(su2vao);

            Support2Shader.Use();
            Support2Shader.SetMatrix4("viewprojection", viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(bvao);

            BackShader.Use();
            BackShader.SetMatrix4("viewprojection", Matrix4.Identity * Matrix4.CreateTranslation(0.0f, 0.0f, 0.125f) * viewprojectionMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
        }

        public void UnBind()
        {
            GL.DeleteVertexArray(rvao);
            GL.DeleteVertexArray(uevao);
            GL.DeleteVertexArray(levao);
            GL.DeleteVertexArray(devao);
            GL.DeleteVertexArray(revao);
            GL.DeleteVertexArray(suvao);
            GL.DeleteVertexArray(su2vao);

            shaderScreen.Unbind();
            UpShader.Unbind();
            LeftShader.Unbind();
            DownShader.Unbind();
            RightShader.Unbind();
            SupportShader.Unbind();
            Support2Shader.Unbind();
            BackShader.Unbind();

        }
    }
}
