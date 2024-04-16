using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hello_OpenTK.Renderer;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace Hello_OpenTK.Objects
{
   public struct Television
    {
        public Dictionary<string, Face> Components = new Dictionary<string, Face>();
        public List<string> Parts = new List<string>
        { "Screen", "UpEdge", "DownEdge", "LeftEdge", "RightEdge", "Support1", "Support2", "Back" };

        public List<Vector4> Colors = new List<Vector4>
        {
            new Vector4(0.5f, 0.5f, 0.5f, 1.0f),
            new Vector4(0.2f, 0.2f, 0.2f, 1.0f),
            new Vector4(0.18f, 0.18f, 0.18f, 1.0f)
        };
        public Television()
        {
            Components["Screen"] = new Face(new Vector3(0.5f, 0.5f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
            Components["UpEdge"] = new Face(new Vector3(0.5625f, 0.0625f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), 0.0f, 0.5f);
            Components["DownEdge"] = new Face(new Vector3(0.5625f, 0.0625f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), 0.0f, -0.5f);
            Components["LeftEdge"] = new Face(new Vector3(0.0625f, 0.5f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), - 0.5625f);
            Components["RightEdge"] = new Face(new Vector3(0.0625f, 0.5f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), 0.5625f);
            Components["Support1"] = new Face(new Vector3(0.0625f, 0.1875f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), 0.0f, -0.75f);
            Components["Support2"] = new Face(new Vector3(0.375f, 0.150f, 0.175f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), 0.0f, -0.875f);
            Components["Back"] = new Face(new Vector3(0.5f, 0.5f, 0.125f), new Vector4(0.5f, 0.5f, 0.5f, 1.0f), 0.0f, 0.0f, -0.125f);

            // Components["Screen"].Quad3D["Front"]["Vertices"][1] = new Vector3(1.0f);
            // List<Vector3> Accumulator = new List<Vector3>();
            // Accumulator.AddRange(Components["Screen"].Quad3D["Front"]["Vertices"]);
        }
        
    }

    

    public class Objeto
    {
        private Dictionary<uint, Television> TV = new Dictionary<uint, Television>();
        private List<VertexArray> VArray;
        private List<VertexBuffer> VBuffer;
        private List<Shader> VShader;
        private List<IndexBuffer> indexBuffers;
        private Dictionary<uint, List<uint>> Indice;
        public List<uint> Indices;
        private int shaderCount = 0;
        private uint indexCount = 0;
        private int VArrayCount = 0;

        public List<Vector3> Vertices;

        private string vertFilePath = "../../../shader.vert";
        private string fragFilePath = "../../../shader.frag";

        public Objeto()
        {
            VArray = new List<VertexArray>();
            VBuffer = new List<VertexBuffer>();
            indexBuffers = new List<IndexBuffer>();
            Indice = new Dictionary<uint, List<uint>>();
            VShader = new List<Shader>();
            Vertices = new List<Vector3>();
            Indices = new List<uint>();
            TV[0] = new Television();
        }

        public void Load()
        {
            int i = 0;
            foreach (KeyValuePair<uint, Television> kvp in TV)
            {
                foreach (KeyValuePair<string, Face> pair in TV[kvp.Key].Components)
                {                                                                  
                    VShader[i] = new Shader(vertFilePath, fragFilePath);
                    int FaceCount = 0;

                    Vertices.AddRange(TV[kvp.Key].Components[pair.Key].Quad3D["Front"]["Vertices"]);
                    Vertices.AddRange(TV[kvp.Key].Components[pair.Key].Quad3D["Back"]["Vertices"]);
                    Vertices.AddRange(TV[kvp.Key].Components[pair.Key].Quad3D["Left"]["Vertices"]);
                    Vertices.AddRange(TV[kvp.Key].Components[pair.Key].Quad3D["Rigt"]["Vertices"]);
                    Vertices.AddRange(TV[kvp.Key].Components[pair.Key].Quad3D["Top"]["Vertices"]);
                    Vertices.AddRange(TV[kvp.Key].Components[pair.Key].Quad3D["Bottom"]["Vertices"]);

                   FaceCount += 6;

                   AddIndices(FaceCount, (uint)i);

                   VArray.Add(new VertexArray());
                   VArray[i].Bind();

                   VBuffer.Add(new VertexBuffer(Vertices));
                   VBuffer[i].Bind();
                   VArray[i].AddVertexBuffer(0, 3, VBuffer[i]);

                   indexBuffers[i] = new IndexBuffer(Indices);

                    i++;
                    VShader[i].SetVector4("u_Color", TV[kvp.Key].Components[pair.Key].Color);
                }
            }
            VArrayCount = i;
            shaderCount = i;
        }

        public void AddIndices(int amtFaces, uint j)
        {
            for (int i = 0; i < amtFaces; i++)
            {
                Indice[j].Add(0 + indexCount);
                Indice[j].Add(1 + indexCount);
                Indice[j].Add(2 + indexCount);
                Indice[j].Add(2 + indexCount);
                Indice[j].Add(3 + indexCount);
                Indice[j].Add(0 + indexCount);

                indexCount += 4;
            }
        }

        public void Render(Matrix4 viewprojection)
        {
            int i = 0;
            foreach (KeyValuePair<uint, Television> kvp in TV)
            {
                foreach (KeyValuePair<string, Face> pair in TV[kvp.Key].Components)
                {
                    VShader[i].Use();
                    VArray[i].Bind();
                    indexBuffers[i].Bind();
                    VShader[i].SetMatrix4("viewprojection", viewprojection);
                    GL.DrawElements(PrimitiveType.Triangles, Indice[(uint)i].Count, DrawElementsType.UnsignedInt, 0);
                    i++;
                }
            }
        }

        public void Unload()
        {
            int i = 0;
            foreach (KeyValuePair<uint, Television> kvp in TV)
            {
                foreach (KeyValuePair<string, Face> pair in TV[kvp.Key].Components)
                {
                    VShader[i].Unbind();
                    VArray[i].Delete();
                    indexBuffers[i].Delete();
                    i++;
                }
            }
        }
    }
}
