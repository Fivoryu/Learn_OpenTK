using Hello_OpenTK.Renderer;
using Hello_OpenTK.Componentes;
using Hello_OpenTK.ImGuiLayer;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Zenseless.OpenTK;
using Zenseless.OpenTK.GUI;
using ImGuiNET;

namespace Hello_OpenTK
{   
    public class Game : GameWindow
    {

        private const string file = "../../../assets/";

        public ImGuILayer imgui;
        public ImGuiFacade GUI;

        public Scene scene3;
        
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
                firstMove = true;
            }

            if (input.IsKeyDown(Keys.LeftControl) && input.IsKeyDown(Keys.G) && input.IsKeyDown(Keys.T))
            {
                float x, y, z;

                Console.WriteLine("X: ");
                float.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Y: ");
                float.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Z: ");
                float.TryParse(Console.ReadLine(), out z);

                Vector vector = new Vector(x, y, z);
                Objeto objeto = Carga.CargarTV(vector);

                Console.WriteLine("Ingrese el nombre del archivo:");
                string fileName = file + Console.ReadLine() + ".json";

                ObjectSerializer.Serialize<Objeto>(objeto, fileName);
            }

            if (input.IsKeyDown(Keys.LeftControl) && input.IsKeyDown(Keys.G) && input.IsKeyDown(Keys.F))
            {
                float x, y, z;

                Console.WriteLine("X: ");
                float.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Y: ");
                float.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Z: ");
                float.TryParse(Console.ReadLine(), out z);

                Vector vector = new Vector(x, y, z);
                Objeto objeto = Carga.CargarFlorero(vector);

                Console.WriteLine("Ingrese el nombre del archivo:");
                string fileName = file + Console.ReadLine() + ".json";

                ObjectSerializer.Serialize<Objeto>(objeto, fileName);
            }

            if (input.IsKeyDown(Keys.LeftControl) && input.IsKeyDown(Keys.G) && input.IsKeyDown(Keys.P))
            {
                float x, y, z;

                Console.WriteLine("X: ");
                float.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Y: ");
                float.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Z: ");
                float.TryParse(Console.ReadLine(), out z);

                Vector vector = new Vector(x, y, z);
                Objeto objeto = Carga.CargarParlante(vector);

                Console.WriteLine("Ingrese el nombre del archivo:");
                string fileName = file + Console.ReadLine() + ".json";

                ObjectSerializer.Serialize<Objeto>(objeto, fileName);
            }

            if (input.IsKeyDown(Keys.LeftControl) && input.IsKeyDown(Keys.O))
            {

                Console.WriteLine("Ingrese el nombre del archivo:");
                string fileName = file + Console.ReadLine() + ".json";
                Console.WriteLine("Ingrese el nombre del objeto:");
                string name = Console.ReadLine();

                scene3.m_Objeto[name] = ObjectSerializer.Deserialize<Objeto>(fileName);

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

            scene3 = new Scene();

            //scene3 = ObjectSerializer.Deserialize<Scene>(file + "Scene1.json");


            //scene3.Load();

            camera = new Camera(new Vector3(0.0f, 0.0f, -2.0f), Size.X / (float)Size.Y);

            GUI = new ImGuiFacade(this);
            imgui = new(this);

            GUI.LoadFontDroidSans(15);

            //imgui = new ImGuilayer(ref scene3, ref camera);

            //imgui.Update();

            // CursorState = CursorState.Grabbed;
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

            scene3.Draw(viewprojectionMatrix);

            imgui.Render();
            GUI.Render(this.ClientSize);
            GL.Enable(EnableCap.DepthTest);

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

            base.OnUnload();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
