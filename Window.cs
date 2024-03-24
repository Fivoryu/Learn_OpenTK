using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Learn_OpenTK.Renderer;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using StbImageSharp;

namespace Learn_OpenTK
{   
    internal class Game : GameWindow
    {

        private readonly float[] vertices =
        {
            // Position         Texture coordinates
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // top left
        };

        private readonly float[] Screen =
        {
            -0.5f, -0.5f, -0.125f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.125f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.125f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.125f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.125f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.125f,  0.0f, 0.0f,
             0.5f, -0.5f,  0.125f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.125f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.125f,  1.0f, 1.0f,
            -0.5f,  0.5f,  0.125f,  0.0f, 1.0f,
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
            -0.5f, 0.0f, -0.125f,  0.0f, 0.0f,
             0.5f, 0.0f, -0.125f,  1.0f, 0.0f,
             0.5f,  0.0625f, -0.125f,  1.0f, 1.0f,
             0.5f,  0.0625f, -0.125f,  1.0f, 1.0f,
            -0.5f,  0.0625f, -0.125f,  0.0f, 1.0f,
            -0.5f, 0.0f, -0.125f,  0.0f, 0.0f,

            -0.5f, 0.0f,  0.125f,  0.0f, 0.0f,
             0.5f, 0.0f,  0.125f,  1.0f, 0.0f,
             0.5f,  0.0625f,  0.125f,  1.0f, 1.0f,
             0.5f,  0.0625f,  0.125f,  1.0f, 1.0f,
            -0.5f,  0.0625f,  0.125f,  0.0f, 1.0f,
            -0.5f, 0.0f,  0.125f,  0.0f, 0.0f,

            -0.5f,  0.0625f,  0.125f,  1.0f, 0.0f,
            -0.5f,  0.0625f, -0.125f,  1.0f, 1.0f,
            -0.5f, 0.0f, -0.125f,  0.0f, 1.0f,
            -0.5f, 0.0f, -0.125f,  0.0f, 1.0f,
            -0.5f, 0.0f,  0.125f,  0.0f, 0.0f,
            -0.5f,  0.0625f,  0.125f,  1.0f, 0.0f,

             0.5f,  0.0625f,  0.125f,  1.0f, 0.0f,
             0.5f,  0.0625f, -0.125f,  1.0f, 1.0f,
             0.5f, 0.0f, -0.125f,  0.0f, 1.0f,
             0.5f, 0.0f, -0.125f,  0.0f, 1.0f,
             0.5f, 0.0f,  0.125f,  0.0f, 0.0f,
             0.5f,  0.0625f,  0.125f,  1.0f, 0.0f,

            -0.5f, 0.0f, -0.125f,  0.0f, 1.0f,
             0.5f, 0.0f, -0.125f,  1.0f, 1.0f,
             0.5f, 0.0f,  0.125f,  1.0f, 0.0f,
             0.5f, 0.0f,  0.125f,  1.0f, 0.0f,
            -0.5f, 0.0f,  0.125f,  0.0f, 0.0f,
            -0.5f, 0.0f, -0.125f,  0.0f, 1.0f,

            -0.5f,  0.0625f, -0.125f,  0.0f, 1.0f,
             0.5f,  0.0625f, -0.125f,  1.0f, 1.0f,
             0.5f,  0.0625f,  0.125f,  1.0f, 0.0f,
             0.5f,  0.0625f,  0.125f,  1.0f, 0.0f,
            -0.5f,  0.0625f,  0.125f,  0.0f, 0.0f,
            -0.5f,  0.0625f, -0.125f,  0.0f, 1.0f
        };

        private readonly float[] LeftEdge =
        {
            -0.5625f, 0.0f, -0.125f,  0.0f, 0.0f,
             0.5625f, 0.0f, -0.125f,  1.0f, 0.0f,
             0.5625f,  0.0625f, -0.125f,  1.0f, 1.0f,
             0.5625f,  0.0625f, -0.125f,  1.0f, 1.0f,
            -0.5625f,  0.0625f, -0.125f,  0.0f, 1.0f,
            -0.5625f, 0.0f, -0.125f,  0.0f, 0.0f,

            -0.5625f, 0.0f,  0.125f,  0.0f, 0.0f,
             0.5625f, 0.0f,  0.125f,  1.0f, 0.0f,
             0.5625f,  0.0625f,  0.125f,  1.0f, 1.0f,
             0.5625f,  0.0625f,  0.125f,  1.0f, 1.0f,
            -0.5625f,  0.0625f,  0.125f,  0.0f, 1.0f,
            -0.5625f, 0.0f,  0.125f,  0.0f, 0.0f,

            -0.5625f,  0.0625f,  0.125f,  1.0f, 0.0f,
            -0.5625f,  0.0625f, -0.125f,  1.0f, 1.0f,
            -0.5625f, 0.0f, -0.125f,  0.0f, 1.0f,
            -0.5625f, 0.0f, -0.125f,  0.0f, 1.0f,
            -0.5625f, 0.0f,  0.125f,  0.0f, 0.0f,
            -0.5625f,  0.0625f,  0.125f,  1.0f, 0.0f,

             0.5625f,  0.0625f,  0.125f,  1.0f, 0.0f,
             0.5625f,  0.0625f, -0.125f,  1.0f, 1.0f,
             0.5625f, 0.0f, -0.125f,  0.0f, 1.0f,
             0.5625f, 0.0f, -0.125f,  0.0f, 1.0f,
             0.5625f, 0.0f,  0.125f,  0.0f, 0.0f,
             0.5625f,  0.0625f,  0.125f,  1.0f, 0.0f,

            -0.5625f, 0.0f, -0.125f,  0.0f, 1.0f,
             0.5625f, 0.0f, -0.125f,  1.0f, 1.0f,
             0.5625f, 0.0f,  0.125f,  1.0f, 0.0f,
             0.5625f, 0.0f,  0.125f,  1.0f, 0.0f,
            -0.5625f, 0.0f,  0.125f,  0.0f, 0.0f,
            -0.5625f, 0.0f, -0.125f,  0.0f, 1.0f,

            -0.5625f,  0.0625f, -0.125f,  0.0f, 1.0f,
             0.5625f,  0.0625f, -0.125f,  1.0f, 1.0f,
             0.5625f,  0.0625f,  0.125f,  1.0f, 0.0f,
             0.5625f,  0.0625f,  0.125f,  1.0f, 0.0f,
            -0.5625f,  0.0625f,  0.125f,  0.0f, 0.0f,
            -0.5625f,  0.0625f, -0.125f,  0.0f, 1.0f
        };

        float[] texCoords =
        {
            0.0f, 1.0f,
            1.0f, 1.0f,
            1.0f, 0.0f,
            0.0f, 0.0f,

            0.0f, 1.0f,
            1.0f, 1.0f,
            1.0f, 0.0f,
            0.0f, 0.0f,

            0.0f, 1.0f,
            1.0f, 1.0f,
            1.0f, 0.0f,
            0.0f, 0.0f,

            0.0f, 1.0f,
            1.0f, 1.0f,
            1.0f, 0.0f,
            0.0f, 0.0f,

            0.0f, 1.0f,
            1.0f, 1.0f,
            1.0f, 0.0f,
            0.0f, 0.0f,

            0.0f, 1.0f,
            1.0f, 1.0f,
            1.0f, 0.0f,
            0.0f, 0.0f,
        };

        private readonly float[] Support =
        {
            -2.0f, -0.5f, -0.5f,  0.0f, 0.0f,
             2.0f, -0.5f, -0.5f,  1.0f, 0.0f,
             2.0f,  0.5f, -0.5f,  1.0f, 1.0f,
             2.0f,  0.5f, -0.5f,  1.0f, 1.0f,
            -2.0f,  0.5f, -0.5f,  0.0f, 1.0f,
            -2.0f, -0.5f, -0.5f,  0.0f, 0.0f,

            -2.0f, -0.5f,  0.5f,  0.0f, 0.0f,
             2.0f, -0.5f,  0.5f,  1.0f, 0.0f,
             2.0f,  0.5f,  0.5f,  1.0f, 1.0f,
             2.0f,  0.5f,  0.5f,  1.0f, 1.0f,
            -2.0f,  0.5f,  0.5f,  0.0f, 1.0f,
            -2.0f, -0.5f,  0.5f,  0.0f, 0.0f,

            -2.0f,  0.5f,  0.5f,  1.0f, 0.0f,
            -2.0f,  0.5f, -0.5f,  1.0f, 1.0f,
            -2.0f, -0.5f, -0.5f,  0.0f, 1.0f,
            -2.0f, -0.5f, -0.5f,  0.0f, 1.0f,
            -2.0f, -0.5f,  0.5f,  0.0f, 0.0f,
            -2.0f,  0.5f,  0.5f,  1.0f, 0.0f,

             2.0f,  0.5f,  0.5f,  1.0f, 0.0f,
             2.0f,  0.5f, -0.5f,  1.0f, 1.0f,
             2.0f, -0.5f, -0.5f,  0.0f, 1.0f,
             2.0f, -0.5f, -0.5f,  0.0f, 1.0f,
             2.0f, -0.5f,  0.5f,  0.0f, 0.0f,
             2.0f,  0.5f,  0.5f,  1.0f, 0.0f,

            -2.0f, -0.5f, -0.5f,  0.0f, 1.0f,
             2.0f, -0.5f, -0.5f,  1.0f, 1.0f,
             2.0f, -0.5f,  0.5f,  1.0f, 0.0f,
             2.0f, -0.5f,  0.5f,  1.0f, 0.0f,
            -2.0f, -0.5f,  0.5f,  0.0f, 0.0f,
            -2.0f, -0.5f, -0.5f,  0.0f, 1.0f,

            -2.0f,  0.5f, -0.5f,  0.0f, 1.0f,
             2.0f,  0.5f, -0.5f,  1.0f, 1.0f,
             2.0f,  0.5f,  0.5f,  1.0f, 0.0f,
             2.0f,  0.5f,  0.5f,  1.0f, 0.0f,
            -2.0f,  0.5f,  0.5f,  0.0f, 0.0f,
            -2.0f,  0.5f, -0.5f,  0.0f, 1.0f
        };

        private readonly float[] Support2 =
        {
            -2.5f, -0.125f, -1.0f,  0.0f, 0.0f,
             2.5f, -0.125f, -1.0f,  1.0f, 0.0f,
             2.5f,  0.125f, -1.0f,  1.0f, 1.0f,
             2.5f,  0.125f, -1.0f,  1.0f, 1.0f,
            -2.5f,  0.125f, -1.0f,  0.0f, 1.0f,
            -2.5f, -0.125f, -1.0f,  0.0f, 0.0f,

            -2.5f, -0.125f,  1.0f,  0.0f, 0.0f,
             2.5f, -0.125f,  1.0f,  1.0f, 0.0f,
             2.5f,  0.125f,  1.0f,  1.0f, 1.0f,
             2.5f,  0.125f,  1.0f,  1.0f, 1.0f,
            -2.5f,  0.125f,  1.0f,  0.0f, 1.0f,
            -2.5f, -0.125f,  1.0f,  0.0f, 0.0f,

            -2.5f,  0.125f,  1.0f,  1.0f, 0.0f,
            -2.5f,  0.125f, -1.0f,  1.0f, 1.0f,
            -2.5f, -0.125f, -1.0f,  0.0f, 1.0f,
            -2.5f, -0.125f, -1.0f,  0.0f, 1.0f,
            -2.5f, -0.125f,  1.0f,  0.0f, 0.0f,
            -2.5f,  0.125f,  1.0f,  1.0f, 0.0f,

             2.5f,  0.125f,  1.0f,  1.0f, 0.0f,
             2.5f,  0.125f, -1.0f,  1.0f, 1.0f,
             2.5f, -0.125f, -1.0f,  0.0f, 1.0f,
             2.5f, -0.125f, -1.0f,  0.0f, 1.0f,
             2.5f, -0.125f,  1.0f,  0.0f, 0.0f,
             2.5f,  0.125f,  1.0f,  1.0f, 0.0f,

            -2.5f, -0.125f, -1.0f,  0.0f, 1.0f,
             2.5f, -0.125f, -1.0f,  1.0f, 1.0f,
             2.5f, -0.125f,  1.0f,  1.0f, 0.0f,
             2.5f, -0.125f,  1.0f,  1.0f, 0.0f,
            -2.5f, -0.125f,  1.0f,  0.0f, 0.0f,
            -2.5f, -0.125f, -1.0f,  0.0f, 1.0f,

            -2.5f,  0.125f, -1.0f,  0.0f, 1.0f,
             2.5f,  0.125f, -1.0f,  1.0f, 1.0f,
             2.5f,  0.125f,  1.0f,  1.0f, 0.0f,
             2.5f,  0.125f,  1.0f,  1.0f, 0.0f,
            -2.5f,  0.125f,  1.0f,  0.0f, 0.0f,
            -2.5f,  0.125f, -1.0f,  0.0f, 1.0f
        };

        uint[] indices2 =
        {
            0, 1, 2,
            2, 3, 0,

            4, 5, 6,
            6, 7, 4,

            8, 9, 10,
            10, 11, 8,

            12, 13, 14,
            14, 15, 12,

            16, 17, 18,
            18, 19, 16,

            20, 21, 22,
            22, 23, 20
        };

        uint[] indices = { // Note that we start from 0!        
            0, 1, 3,    // First triangle 
            1, 2, 3     // Second triangle
        };

        private int vao;
        private int rvao;
        private int uevao, levao, devao, revao;
        private int suvao, su2vao;

        private Shader shader;
        private Shader shaderScreen;
        private Shader UpShader;
        private Shader LeftShader;
        private Shader DownShader;
        private Shader RightShader;
        private Shader SupportShader;
        private Shader Support2Shader;

        private Textures texture;
        private Textures texture2;
        private Textures WhiteTexture;

        private double time = 0;

        private Camera camera;
        private bool firstMove = true;

        private Vector2 lastPos;

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
             : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            if (!IsFocused)
            {
                return;
            }

            var input = KeyboardState;

            const float cameraSpeed = 2.0f;
            const float sensitivity = 0.2f;

            if (input.IsKeyDown(Keys.W))
            {
                //camera.Position.X += camera.Front.X * cameraSpeed * (float)e.Time; // Forward
                //camera.Position.Z += camera.Front.Z * cameraSpeed * (float)e.Time;
                camera.Position += camera.Front * cameraSpeed * (float)e.Time;
            }
            if (input.IsKeyDown(Keys.S))
            {
                //camera.Position.X -= camera.Front.X * cameraSpeed * (float)e.Time; // Backwards 
                //camera.Position.Z -= camera.Front.Z * cameraSpeed * (float)e.Time;
                camera.Position -= camera.Front * cameraSpeed * (float)e.Time;
            }
            if (input.IsKeyDown(Keys.A))
            {
                //camera.Position.Z -= camera.Right.Z * cameraSpeed * (float)e.Time; // Left
                //camera.Position.X -= camera.Right.X * cameraSpeed * (float)e.Time;
                camera.Position -= camera.Right * cameraSpeed * (float)e.Time;
            }
            if (input.IsKeyDown(Keys.D))
            {
                //camera.Position.Z += camera.Right.Z * cameraSpeed * (float)e.Time; // Right
                //camera.Position.X += camera.Right.X * cameraSpeed * (float)e.Time;
                camera.Position += camera.Right * cameraSpeed * (float)e.Time;
            }
            
            if (input.IsKeyDown(Keys.Space))
            {
                camera.Position += camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                camera.Position -= camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            var mouse = MouseState;

            if (firstMove)
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - lastPos.X;
                var deltaY = mouse.Y - lastPos.Y;
                lastPos = new Vector2(mouse.X, mouse.Y);

                camera.Yaw += deltaX * sensitivity;
                camera.Pitch -= deltaY * sensitivity;
            }

        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            camera.Fov -= e.OffsetY;
        }

        private void GenVertex(ref int VAO, ref Shader shader, float[] vertices, uint[] indices, string vertFilePath, string fragFilePath)
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

            var texCoordLocation = shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

            int ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        }

        private void GenVertex2(ref int VAO, ref Shader shader, float[] vertices, uint[] indices, string vertFilePath, string fragFilePath)
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

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.8f, 0.8f, 0.8f, 1.0f);

            GenVertex2(ref rvao, ref shaderScreen, Screen, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref uevao, ref UpShader, UpEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref devao, ref DownShader, UpEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref levao, ref LeftShader, LeftEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref revao, ref RightShader, LeftEdge, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref suvao, ref SupportShader, Support, indices, "../../../shader.vert", "../../../shader.frag");

            GenVertex2(ref su2vao, ref Support2Shader, Support2, indices, "../../../shader.vert", "../../../shader.frag");

            // -----    Texture     ----- //

            shaderScreen.SetVector4("u_Color", new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
            UpShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            DownShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            LeftShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            RightShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            SupportShader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
            Support2Shader.SetVector4("u_Color", new Vector4(0.2f, 0.2f, 0.2f, 1.0f));

            camera = new Camera(Vector3.UnitX *3, Size.X / (float)Size.Y);

            CursorState = CursorState.Grabbed;

            GL.Enable(EnableCap.DepthTest);
        }

        public double zRot = 0.0f;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            time += 15.0f * e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(rvao);
            shaderScreen.Use();
            var model2 = Matrix4.Identity;
            model2 *= Matrix4.CreateScale(2.0f) * Matrix4.CreateTranslation(2.0f, 2.0f, 0.0f);

            shaderScreen.SetMatrix4("model", model2);
            shaderScreen.SetMatrix4("view", camera.GetViewMatrix());
            shaderScreen.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            
            GL.BindVertexArray(uevao);
            
            UpShader.Use();
            var model3 = Matrix4.Identity *  
                Matrix4.CreateScale(2.0f) * Matrix4.CreateTranslation(2.0f, 3.0f, 0.0f);

            UpShader.SetMatrix4("model", model3);
            UpShader.SetMatrix4("view", camera.GetViewMatrix());
            UpShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(devao);

            DownShader.Use();
            var model4 = Matrix4.Identity *  
                Matrix4.CreateScale(2.0f) * Matrix4.CreateTranslation(2.0f, 0.875f, 0.0f);

            DownShader.SetMatrix4("model", model4);
            DownShader.SetMatrix4("view", camera.GetViewMatrix());
            DownShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(levao);

            LeftShader.Use();
            var model5 = Matrix4.Identity 
                * Matrix4.CreateScale(2.0f) * Matrix4.CreateTranslation(2.0f, -1.0f, 0.0f);
            zRot += 0.5f;
            model5 *= Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(90.0f));

            LeftShader.SetMatrix4("model", model5);
            LeftShader.SetMatrix4("view", camera.GetViewMatrix());
            LeftShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(revao);

            RightShader.Use();
            var model6 = Matrix4.Identity * Matrix4.CreateScale(2.0f) * Matrix4.CreateTranslation(2.0f, -3.125f, 0.0f);
            model6 *= Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(90.0f));

            RightShader.SetMatrix4("model", model6);
            RightShader.SetMatrix4("view", camera.GetViewMatrix());
            RightShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(suvao);

            SupportShader.Use();
            var model7 = Matrix4.Identity * Matrix4.CreateScale(0.25f) * Matrix4.CreateTranslation(2.0f, 0.75f, 0.0f);

            SupportShader.SetMatrix4("model", model7);
            SupportShader.SetMatrix4("view", camera.GetViewMatrix());
            SupportShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(su2vao);

            Support2Shader.Use();
            model7 = Matrix4.Identity * Matrix4.CreateScale(0.375f) * Matrix4.CreateTranslation(2.0f, 0.625f, 0.0f);

            Support2Shader.SetMatrix4("model", model7);
            Support2Shader.SetMatrix4("view", camera.GetViewMatrix());
            Support2Shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
            camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            GL.DeleteVertexArray(vao);

           // GL.DeleteProgram(shader.Handle);

            base.OnUnload();
        }
    }
}
