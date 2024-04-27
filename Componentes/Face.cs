using Hello_OpenTK.Renderer;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hello_OpenTK.Componentes
{
    public class Face : ITriangle
    {
        [JsonPropertyName("Triangulo")]
        public Dictionary<string, Triangle> m_Triangles { get; set; }
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }
        public Face()
        {
            m_Position = new Vector(0.0f, 0.0f, 0.0f);
            m_Triangles = new Dictionary<string, Triangle>();
        }
        public Face(Vector Position = default)
        {
            m_Position = Position;
            m_Triangles = new Dictionary<string, Triangle>();
            
        }

        public void Load()
        {
            foreach (KeyValuePair<string, Triangle> kvp in m_Triangles)
            {
                m_Triangles[kvp.Key].Load();
            }
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f)
        {
            Vector3 position = new Vector3(m_Position.X, m_Position.Y, m_Position.Z);
            foreach (KeyValuePair<string, Triangle> kvp in m_Triangles)
            {
                m_Triangles[kvp.Key].Draw(ViewProjection, Position + position, xRot, yRot, zRot);
            }
        }

        public void Unbind()
        {
            foreach (KeyValuePair<string, Triangle> kvp in m_Triangles)
            {
                m_Triangles[kvp.Key].Unbind();
            }
        }
    }
}
