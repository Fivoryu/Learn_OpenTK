using OpenTK.Graphics.OpenGL4;
using System.Windows.Forms;

using ImGuiNET;
using Zenseless.OpenTK.GUI;
using OpenTK.Windowing.Desktop;
using Hello_OpenTK.Componentes;
using Microsoft.VisualBasic;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace Hello_OpenTK.ImGuiLayer
{
    /*
    public class ImGuilayer : Overlay
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        Scene scene = new Scene();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        System.Numerics.Vector4 selectedColor = new System.Numerics.Vector4(1.0f, 1.0f, 1.0f, 1.0f);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public Camera camera;

        public ImGuilayer() : base(1366, 768)
        {
            scene = new Scene();
        }

        public ImGuilayer(ref Scene scene, ref Camera camera) : base(1366, 768)
        {
            this.scene = scene;
            this.camera = camera;
        }

        bool checkBocValue = false;
        int loveMeter = 0;
        string input = "";
        string input2 = "";
        bool showWIndow = true;

        public void Update()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            ImGuilayer program = new ImGuilayer(ref scene, ref camera);
            program.Start().Wait();
        }

        protected override void Render()
        {
            
            if (GetAsyncKeyState(0x20) < 0)
            {
                showWIndow = !showWIndow;
                Thread.Sleep(200);
            }

            if (showWIndow)
            {
                OnImGuiRender();
            }
        }

        private bool is_selected = false;

        public Matrix4 viewproj = new Matrix4();

        public void GetView(Matrix4 viewProjection)
        {
            viewproj = viewProjection; 
        }

        private void OnImGuiRender()
        {

            ImGui.Begin("Scene");
            var viewprojectionMatrix = camera.GetViewMatrix() * camera.GetProjectionMatrix();
            if (ImGui.Button("Exit"))
            {
                Environment.Exit(0);
            }

            if (ImGui.TreeNode("Objects"))
            {
                Object obj = new object();
                string text = "";
                ImGuiTreeNodeFlags base_flags = ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.SpanAvailWidth;
                foreach (KeyValuePair<string, Objeto> kvp in scene.m_Objeto)
                {
                    text = kvp.Key;
                    bool node_open = ImGui.TreeNodeEx(text, base_flags);

                    if (is_selected)
                        base_flags |= ImGuiTreeNodeFlags.Selected;

                    if (node_open)
                    {
                        foreach (KeyValuePair<string, Components> cvp in kvp.Value.m_Componentes)
                        {
                            text = cvp.Key;
                            node_open = ImGui.TreeNodeEx(text, base_flags);

                            if (is_selected)
                                base_flags |= ImGuiTreeNodeFlags.Selected;

                            if (node_open)
                            {
                                foreach (KeyValuePair<string, Face> fvp in cvp.Value.m_Faces)
                                {
                                    text = fvp.Key;

                                    Face face = fvp.Value;
                                    if (ImGui.TreeNodeEx(text, base_flags))
                                    { 
                                        if (ImGui.TreeNode("Control"))
                                        {
                                            Vector Translation = fvp.Value.transform.GetTranslation();
                                            Vector Rotation = fvp.Value.transform.GetRotation();
                                            Vector Scale = fvp.Value.transform.GetScale();
                                            DrawVec3Control("Translation", ref face, ref Translation);
                                            DrawVec3Control("Rotation", ref face, ref Rotation);
                                            DrawVec3Control("Scale", ref face, ref Scale, 1.0f);
                                            TransformComponent transform = new TransformComponent();
                                            transform.SetTranslation(Translation);
                                            transform.SetScale(Scale);
                                            transform.SetRotation(Rotation);
                                            fvp.Value.transform = transform;
                                            // fvp.Value.SetViewMatrix(fvp.Value.transform, viewprojectionMatrix);
                                            ImGui.TreePop();
                                        }
                                        ImGui.TreePop();
                                    }

                                }
                                ImGui.TreePop();
                            }
                        }
                        ImGui.TreePop();
                    }
                }
                    
            }

            ImGui.Text("Bye");

            ImGui.End();

            ImGui.Begin("Sceen Herarchy");

            ImGui.Text("Hellojkasdfasdf");

            ImGui.End();

        }

        private void DrawVec3Control(string label, ref Face face, ref Vector value, float resetValue = 0.0f, float columnWidth = 100.0f)
        {
            ImGuiIOPtr io = ImGui.GetIO();

            ImGui.PushID(label);

            ImGui.Columns(2);
            ImGui.SetColumnWidth(0, columnWidth);
            ImGui.Text(label);
            ImGui.NextColumn();

            ImGui.PushItemWidth(50.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, 0);

            if (ImGui.Button("X"))
                value.X = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            System.Numerics.Vector4 vec = new System.Numerics.Vector4(value.X, 0.1f, 0.0f, 0.0f);
            float X = value.X;
            ImGui.DragFloat("##X", ref X, 0.1f, 0.0f, 0.0f);
            value.X = X;
            
            ImGui.PopItemWidth();
            ImGui.SameLine();

            ImGui.PushItemWidth(50.0f);
            if (ImGui.Button("Y"))
                value.Y = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            vec = new System.Numerics.Vector4(value.X, 0.1f, 0.0f, 0.0f);
            var Y = value.Y;

            ImGui.DragFloat("##Y", ref Y, 0.1f, 0.0f, 0.0f);
            value.Y = Y;
            ImGui.PopItemWidth();
            ImGui.SameLine();

            ImGui.PushItemWidth(50.0f);
            if (ImGui.Button("Z"))
                value.Y = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            vec = new System.Numerics.Vector4(value.X, 0.1f, 0.0f, 0.0f);
            var Z = value.Z;
            ImGui.SameLine();
            ImGui.DragFloat("##Z", ref Z, 0.1f, 0.0f, 0.0f);
            value.Z = Z;
            ImGui.PopItemWidth();

            ImGui.PopStyleVar();
            ImGui.Columns(1);
            ImGui.PopID();
        }

        static void DrawVec3Control(string label, ref Object obj, ref Vector value, float resetValue = 0.0f, float columnWidth = 100.0f)
        {
            ImGuiIOPtr io = ImGui.GetIO();

            ImGui.PushID(label);

            ImGui.Columns(2);
            ImGui.SetColumnWidth(0, columnWidth);
            ImGui.Text(label);
            ImGui.NextColumn();

            ImGui.PushItemWidth(ImGui.CalcItemWidth());
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, 0);

            if (ImGui.Button("X"))
                value.X = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            System.Numerics.Vector4 vec = new System.Numerics.Vector4(value.X, 0.1f, 0.0f, 0.0f);
            ImGui.DragFloat4("##X", ref vec, 0.2f);
            value.X = vec.X;
            ImGui.PopItemWidth();
            ImGui.SameLine();

            if (ImGui.Button("Y"))
                value.Y = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            vec = new System.Numerics.Vector4(value.X, 0.1f, 0.0f, 0.0f);
            ImGui.DragFloat4("##Y", ref vec, 0.2f);
            value.Y = vec.Y;
            ImGui.PopItemWidth();
            ImGui.SameLine();

            if (ImGui.Button("Z"))
                value.Y = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            vec = new System.Numerics.Vector4(value.X, 0.1f, 0.0f, 0.0f);
            ImGui.DragFloat4("##Z", ref vec, 0.2f);
            value.Z = vec.Z;
            ImGui.PopItemWidth();
            ImGui.SameLine();
        }
    }*/


    public class ImGuILayer
    {
        Game Game;
        Vector Position = new Vector();
        Vector Rotation = new Vector();
        Vector Scale = new Vector();
        Vector InitPos = new Vector();

        double t;

        private const string file = "../../../assets/";

        CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();

        public ImGuILayer()
        {
            Game = new Game(GameWindowSettings.Default, NativeWindowSettings.Default);
        }

        public ImGuILayer(Game game)
        {
            Game = game;
            ImGuiIOPtr io = ImGui.GetIO();
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        }

        string[] SelectedNode = { "", "", "", "", "" };
        int ItemValue = -1;

        public void Render()
        {
            ImGui.NewFrame();

            ImGui.Begin("Menu", ImGuiWindowFlags.MenuBar);
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New scene"))
                    {
                        //Game.scene3 = ObjectSerializer.Deserialize<Scene>(Interaction.InputBox("Name of the new scene", "New Scene", "New Scene", 0, 0));
                    }
                    if (ImGui.MenuItem("Load Scene"))
                    {
                        // openFileDialog.Title = "Seleccionar archivo";
                        // openFileDialog.Filters.Add(new CommonFileDialogFilter("Scene", "*.json"));
                        // openFileDialog.Multiselect = false;
                        // 
                        // CommonFileDialogResult result = openFileDialog.ShowDialog();
                        // if (result == CommonFileDialogResult.Ok)
                        // {
                        //     string Route = openFileDialog.FileName;
                        //     Game.scene3 = ObjectSerializer.Deserialize<Scene>(Route);
                        // }
                        // Game.scene3.m_Objeto["TV"] = Carga.CargarTV();
                        // Game.scene3.m_Objeto["Florero"] = Carga.CargarFlorero();
                        // Game.scene3.m_Objeto["Parlante"] = Carga.CargarParlante();
                        // Game.scene3.Load();
                        // ObjectSerializer.Serialize<Scene>(Game.scene3, file + "Scene1.json");
                        Game.scene3 = ObjectSerializer.Deserialize<Scene>(file + "Scene1.json");
                        Game.scene3.Load();
                    }
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }
            

            ImGuiTreeNodeFlags Scene = ImGuiTreeNodeFlags.DefaultOpen;
            ImGuiTreeNodeFlags Objeto = ImGuiTreeNodeFlags.DefaultOpen;
            ImGuiTreeNodeFlags Component = ImGuiTreeNodeFlags.DefaultOpen;
            ImGuiTreeNodeFlags Face = ImGuiTreeNodeFlags.DefaultOpen;
            ImGuiTreeNodeFlags Triangle = ImGuiTreeNodeFlags.DefaultOpen;

            Scene |= ImGuiTreeNodeFlags.OpenOnArrow;
            Objeto |= ImGuiTreeNodeFlags.OpenOnArrow;
            Component |= ImGuiTreeNodeFlags.OpenOnArrow;
            Face |= ImGuiTreeNodeFlags.OpenOnArrow;
            Triangle |= ImGuiTreeNodeFlags.OpenOnArrow;

            if (Game.scene3 != new Scene())
            {
                if (ImGui.TreeNodeEx("Scene", Scene))
                {
                    if (ImGui.IsItemClicked())
                    {
                        SelectedNode = new string[] { "Scene", "", "", "", "" };
                        ItemValue = 0;
                    }
                    foreach (string objeto in Game.scene3.m_Objeto.Keys)
                    {
                        if (ImGui.TreeNodeEx(objeto, Objeto))
                        {
                            if (ImGui.IsItemClicked())
                            {
                                SelectedNode = new string[] { objeto, "Scene", "", "", "" };
                                ItemValue = 1;
                            }
                            foreach (string component in Game.scene3.m_Objeto[objeto].m_Componentes.Keys)
                            {
                                if (ImGui.TreeNodeEx(component, Component))
                                {
                                    if (ImGui.IsItemClicked())
                                    {
                                        SelectedNode = new string[] { component, objeto, "Scene", "", "" };
                                        ItemValue = 2;
                                    }
                                    foreach (string face in Game.scene3.m_Objeto[objeto].m_Componentes[component].m_Faces.Keys)
                                    {
                                        if (ImGui.TreeNodeEx(face, Face))
                                        {
                                            if (ImGui.IsItemClicked())
                                            {
                                                SelectedNode = new string[] { face, component, objeto, "Scene", "" };
                                                ItemValue = 3;
                                            }
                                        }
                                        ImGui.TreePop();
                                    }
                                    ImGui.TreePop();
                                }
                            }
                            ImGui.TreePop();
                        }
                    }
                }
                ImGui.TreePop();

                switch (ItemValue)
                {
                    case 0:
                    {
                        Position = Game.scene3.m_Position;
                        Rotation = Game.scene3.m_Rotation;
                        Scale = Game.scene3.m_Scale;
                        InitPos = Game.scene3.FirstPosition;
                        break;
                    }
                    case 1:
                    {
                        Position = Game.scene3.m_Objeto[SelectedNode[0]].m_Position;
                        Rotation = Game.scene3.m_Objeto[SelectedNode[0]].m_Rotation;
                        Scale = Game.scene3.m_Objeto[SelectedNode[0]].m_Scale;
                        InitPos = Game.scene3.m_Objeto[SelectedNode[0]].FirstPosition;
                        break;
                    }
                    case 2:
                    {
                        Position = Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].m_Position;
                        Rotation = Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].m_Rotation;
                        Scale = Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].m_Scale;
                        InitPos = Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].FirstPosition;
                        break;
                    }
                    case 3:
                    {
                        Position = Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].m_Position;
                        Rotation = Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].m_Rotation;
                        Scale = Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].m_Scale;
                        InitPos = Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].FirstPosition;
                        break;
                    }
                }

                ImGui.End();

                ImGui.Begin("Editor");

                ImGui.Text(SelectedNode[0]);
                DrawVec3Control("Translation", ref Position, 0.0f, InitPos);
                DrawVec3Control("Rotation", ref Rotation);
                DrawVec3Control("Scale", ref Scale, 1.0f);

                if (Rotation.X > 360.0f) Rotation.X -= 360.0f;
                if (Rotation.Y > 360.0f) Rotation.Y -= 360.0f;
                if (Rotation.Z > 360.0f) Rotation.Z -= 360.0f;
                if (Rotation.X < 0.0f) Rotation.X += 360.0f;
                if (Rotation.Y < 0.0f) Rotation.Y += 360.0f;
                if (Rotation.Z < 0.0f) Rotation.Z += 360.0f;

                switch (ItemValue)
                {
                    case 0:
                    {
                        Game.scene3.SetTranslation(Position);
                        Game.scene3.SetRotation(Rotation);
                        Game.scene3.SetScale(Scale);
                        break;
                    }
                    case 1:
                    { 
                        Game.scene3.m_Objeto[SelectedNode[0]].SetTranslation(Position);
                        Game.scene3.m_Objeto[SelectedNode[0]].SetRotation(Rotation);
                        Game.scene3.m_Objeto[SelectedNode[0]].SetScale(Scale);
                        break;
                    }
                    case 2:
                    {
                        Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].SetTranslation(Position);
                        Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].SetRotation(Rotation);
                        Game.scene3.m_Objeto[SelectedNode[1]].m_Componentes[SelectedNode[0]].SetScale(Scale);
                        break;
                    }
                    case 3:
                    {
                        Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].SetTranslation(Position);
                        Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].SetRotation(Rotation);
                        Game.scene3.m_Objeto[SelectedNode[2]].m_Componentes[SelectedNode[1]].m_Faces[SelectedNode[0]].SetScale(Scale);
                        break;
                    }
                }
                ImGui.End();

                t = Game.TimeSinceLastUpdate();
                
            }
        }

        static void DrawVec3Control(string label, ref Vector value, float resetValue = 0.0f, Vector initpos = default, float columnWidth = 150.0f)
        {
            float v_min = 0.01f;
            if (label == "Rotation")
                v_min = 1.0f;
            else if (label == "Translation")
                v_min = 0.1f;
            ImGui.PushID(label);

            ImGui.Columns(2);
            ImGui.SetColumnWidth(0, columnWidth);
            ImGui.Text(label);
            ImGui.NextColumn();

            ImGui.PushItemWidth(50.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, 0);

            if (label == "Translation") resetValue = initpos.X;
            if (ImGui.Button("X"))
                value.X = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            float X = value.X;
            ImGui.DragFloat("##X", ref X, v_min, 0.0f, 0.0f);
            value.X = X;

            ImGui.PopItemWidth();
            ImGui.SameLine();

            ImGui.PushItemWidth(50.0f);
            if (label == "Translation") resetValue = initpos.Y;
            if (ImGui.Button("Y"))
                value.Y = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            var Y = value.Y;

            ImGui.DragFloat("##Y", ref Y, v_min, 0.0f, 0.0f);
            value.Y = Y;
            ImGui.PopItemWidth();
            ImGui.SameLine();

            ImGui.PushItemWidth(50.0f);
            if (label == "Translation") resetValue = initpos.Z;
            if (ImGui.Button("Z"))
                value.Z = resetValue;
            ImGui.PopStyleColor(3);

            ImGui.SameLine();
            var Z = value.Z;
            ImGui.SameLine();
            ImGui.DragFloat("##Z", ref Z, v_min, 0.0f, 0.0f);
            value.Z = Z;
            ImGui.PopItemWidth();

            ImGui.PopStyleVar();
            ImGui.Columns(1);
            ImGui.PopID();
        }

    }
}
