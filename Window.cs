using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hello_OpenTK.Objects;
using Hello_OpenTK.Renderer;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using StbImageSharp;

namespace Hello_OpenTK
{   
    internal class Game : GameWindow
    {

        private Mesh mesh;

        private Scene scene1 = new Scene();

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

        protected override void OnLoad()
        {
            base.OnLoad();
            mesh = new Mesh(Vertices2.TV, Vertices2.TVIndices);

            List<Vertex2> aux = new List<Vertex2>(Vertices2.TV);

            aux = Operador.Translation(aux, 4.0f, 0.0f);

            scene1.Objetos["Television1"] = new Mesh(aux, Vertices2.TVIndices);

            aux = new List<Vertex2>(Vertices2.Florero);

            aux = Operador.Translation(aux, 4.0f, 0.0f);

            scene1.Objetos["Florero1"] = new Mesh(aux, Vertices2.FloreroIndices);

            aux = new List<Vertex2>(Vertices2.Altavoz);

            aux = Operador.Translation(aux, 4.0f, 0.0f);

            scene1.Objetos["Altavoz1"] = new Mesh(aux, Vertices2.AltavozIndices);

            aux = new List<Vertex2>(Vertices2.TV);

            aux = Operador.Translation(aux, -2.0f, 0.0f);

            scene1.Objetos["Television2"] = new Mesh(aux, Vertices2.TVIndices);

            aux = new List<Vertex2>(Vertices2.Florero);

            aux = Operador.Translation(aux, -2.0f, 0.0f);

            scene1.Objetos["Florero2"] = new Mesh(aux, Vertices2.FloreroIndices);

            aux = new List<Vertex2>(Vertices2.Altavoz);

            aux = Operador.Translation(aux, -2.0f, 0.0f);

            scene1.Objetos["Altavoz2"] = new Mesh(aux, Vertices2.AltavozIndices);

            camera = new Camera(new Vector3(0.0f, 0.0f, -2.0f), Size.X / (float)Size.Y);


            CursorState = CursorState.Grabbed;

            // Tres clases, un televisor, un florero arriba del televisor, equipo de sonido
            // Instancias que contenga una clase generica
            // Lista de objetos, lista de caras, lista de puntos
            // Escenario lista de objetos, objeto lista de caras, caras lista de puntos
            // Lista hash, Dictionary
            // Centro de masa en la clase
            // Crear una interfaz
            // Instruccion OpenGL, nop

            GL.Enable(EnableCap.DepthTest);
        }

        public double zRot = 0.0f;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            var viewprojectionMatrix = camera.GetViewMatrix() * camera.GetProjectionMatrix();

            // time += 15.0f * e.Time;
            zRot += 0.0005f;  

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);

            var Model = Matrix4.CreateRotationY((float)0) * Matrix4.CreateScale(2.0f) * viewprojectionMatrix;

            scene1.Render(Model);

            Matrix4 model2 = Matrix4.CreateTranslation(2.0f, 0.0f, 0.0f) * Matrix4.CreateRotationY((float)0) * Matrix4.CreateScale(2.0f) * viewprojectionMatrix;
            mesh.Draw(model2);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            

            camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }
    }
}
