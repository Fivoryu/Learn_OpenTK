using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hello_OpenTK.Objects;
using Hello_OpenTK.Renderer;
using Hello_OpenTK.Componentes;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using StbImageSharp;

using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Hello_OpenTK
{   
    internal class Game : GameWindow
    {

        private Objetos mesh;

        private Scena scene1 = new Scena(new Vector3(2.0f, 1.0f, 0.0f));
        private Scena scene2 = new Scena(new Vector3(-2.0f, 1.0f, 0.0f));
        private Scene scene3 = new Scene();
        private Scene scene4 = new Scene(new Vector3(1.0f));

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

        Objeto eas;
        Objeto refa;

        protected override void OnLoad()
        {
            base.OnLoad();

            // scene1.Objetos["Television1"] = new Objetos(Vertices2.TV, Vertices2.TVIndices);
            // 
            // scene1.Objetos["Florero1"] = new Objetos(Vertices2.Florero, Vertices2.FloreroIndices);
            // 
            // scene1.Objetos["Altavoz1"] = new Objetos(Vertices2.Altavoz, Vertices2.AltavozIndices);
            // 
            // scene2.Objetos["Television2"] = new Objetos(Vertices2.TV, Vertices2.TVIndices);
            // 
            // scene2.Objetos["Florero2"] = new Objetos(Vertices2.Florero, Vertices2.FloreroIndices);
            // 
            // scene2.Objetos["Altavoz2"] = new Objetos(Vertices2.Altavoz, Vertices2.AltavozIndices);

            eas = Carga.CargarTV(new Vector3(0.0f, -1.0f, 0.0f));

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(eas, options);


            scene3.m_Objeto["TV"] = Carga.CargarTV(scene3.m_Position);
            scene3.m_Objeto["Florero"] = Carga.CargarFlorero(scene3.m_Position);
            scene3.m_Objeto["Altavoz"] = Carga.CargarParlante(scene3.m_Position);
            //scene3.m_Objeto["TV2"] = refa;

            scene4.m_Objeto["TV"] = Carga.CargarTV(scene4.m_Position + new Vector3(1.0f));
            scene4.m_Objeto["Florero"] = Carga.CargarFlorero(scene4.m_Position + new Vector3(1.0f));
            scene4.m_Objeto["Altavoz"] = Carga.CargarParlante(scene4.m_Position + new Vector3(-2.0f));

            scene4.m_Objeto["TV2"] = Carga.CargarTV(scene4.m_Position);
            scene4.m_Objeto["Florero2"] = Carga.CargarFlorero(scene4.m_Position);
            scene4.m_Objeto["Altavoz2"] = Carga.CargarParlante(scene4.m_Position);

            camera = new Camera(new Vector3(0.0f, 0.0f, -2.0f), Size.X / (float)Size.Y);

            CursorState = CursorState.Grabbed;

            GL.Enable(EnableCap.DepthTest);
        }

        public double zRot = 0.0f;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            var viewprojectionMatrix = camera.GetViewMatrix() * camera.GetProjectionMatrix();

            // time += 15.0f * e.Time;
            zRot += 0.2f;  

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);

            var Model = Matrix4.CreateRotationY((float)0) * Matrix4.CreateScale(4.0f) * viewprojectionMatrix;

            // scene1.Render(Model);
            // scene2.Render(Model);

            scene3.Draw(Matrix4.CreateScale(1.0f) * viewprojectionMatrix, new Vector3(0.0f), 0.0f, (float)zRot, 0.0f);

            scene4.Draw(Matrix4.CreateScale(1.0f) * viewprojectionMatrix, new Vector3(0.0f), 0.0f, (float)zRot, 0.0f);
            //scene4.m_Objeto["TV"].Draw(Matrix4.CreateScale(1.0f) * viewprojectionMatrix, new Vector3(0.0f), (float)zRot, 0.0f, 0.0f);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            

            camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUnload()
        {
            scene3.Unbind();
            scene4.Unbind();

            base.OnUnload();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
