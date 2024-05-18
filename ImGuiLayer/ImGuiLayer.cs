using ImGuiNET;
using Zenseless.OpenTK.GUI;
using OpenTK.Windowing.Desktop;
using Hello_OpenTK.Componentes;
using Microsoft.VisualBasic;
using Microsoft.WindowsAPICodePack.Dialogs;
using Hello_OpenTK.Math;
using Hello_OpenTK.Renderer;


namespace Hello_OpenTK.ImGuiLayer
{
    public class ImGuILayer
    {
        Game Game;
        Vector Position = new Vector();
        Vector Rotation = new Vector();
        Vector Scale = new Vector();
        Vector InitPos = new Vector();

        float t = 0;

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

        public void SetAllActions()
        {
            Game.actions.Add(SetActions.Ac1());
            Game.actions.Add(SetActions.Ac2());
            Game.actions.Add(SetActions.Ac3());

            Game.actions.Add(SetActions.RightUpAct());
            Game.actions.Add(SetActions.RightDownAct());
            Game.actions.Add(SetActions.LeftUpAct());
            Game.actions.Add(SetActions.LeftDownAct());

            Game.actions.Add(SetActions.RightUpAct());
            Game.actions.Add(SetActions.RightDownAct());
            Game.actions.Add(SetActions.LeftUpAct());
            Game.actions.Add(SetActions.LeftDownAct());

            Game.actions.Add(SetActions.RightScreenAct());
            Game.actions.Add(SetActions.LeftScreenAct());
            Game.actions.Add(SetActions.RightBackAct());
            Game.actions.Add(SetActions.LeftBackAct());
            List<ITriangle> objets = new List<ITriangle>
            {
                Game.scene3.m_Objeto["Pelota"],
                Game.scene3.m_Objeto["Pelota"],
                Game.scene3.m_Objeto["Pelota"],
                Game.scene3.m_Objeto["TV"].m_Componentes["RightEdge"].m_Faces["Right"].m_Triangles["Trian1"],
                Game.scene3.m_Objeto["TV"].m_Componentes["RightEdge"].m_Faces["Right"].m_Triangles["Trian2"],
                Game.scene3.m_Objeto["TV"].m_Componentes["LeftEdge"].m_Faces["Left"].m_Triangles["Trian1"],
                Game.scene3.m_Objeto["TV"].m_Componentes["LeftEdge"].m_Faces["Left"].m_Triangles["Trian2"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Back"].m_Faces["Right"].m_Triangles["Trian1"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Back"].m_Faces["Right"].m_Triangles["Trian2"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Back"].m_Faces["Left"].m_Triangles["Trian1"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Back"].m_Faces["Left"].m_Triangles["Trian2"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Screen"].m_Faces["Front"].m_Triangles["Trian1"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Screen"].m_Faces["Front"].m_Triangles["Trian2"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Back"].m_Faces["Back"].m_Triangles["Trian1"],
                Game.scene3.m_Objeto["TV"].m_Componentes["Back"].m_Faces["Back"].m_Triangles["Trian2"],
            };
            Game.animation = new Animation(Game.actions, objets);
        }

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
                        // Game.scene3.m_Objeto["TV"] = Carga.CargarTV();
                        // Game.scene3.m_Objeto["Florero"] = Carga.CargarFlorero();
                        // Game.scene3.m_Objeto["Parlante"] = Carga.CargarParlante();
                        // Game.scene3.m_Objeto["Pelota"] = Carga.CargarPelota();
                        // Game.scene3.Load();
                        // ObjectSerializer.Serialize<Scene>(Game.scene3, file + "Scene1.json");
                        Game.scene3 = ObjectSerializer.Deserialize<Scene>(file + "Scene1.json");
                        Game.scene3.Load();
                        SetAllActions();

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
                

                Controller();
                
            }
        }

        bool isButtonPressed = false;

        void Controller()
        {
            
            ImGui.Begin("Controller");
            if (ImGui.Button("Play"))
            {
                t = 0.0f;
                isButtonPressed = true;
                Game.animation.Reset();
                Game.scene3.ResetAllPositions();
            }
            if (isButtonPressed)
            {
                t += (float)Game.UpdateTime;
                Game.animation.Start(t);
            }
            ImGui.PopStyleColor(3);
            ImGui.SameLine();
            if (ImGui.Button("Resume"))
            {
                Game.animation.Resume();
            }
            ImGui.PopStyleColor(3);
            ImGui.SameLine();
            if (ImGui.Button("Pause"))
            {
                Game.animation.Pause();
            }
            ImGui.End();
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
