using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Componentes
{
    public class Objeto : ITriangle
    {
        [JsonPropertyName("Componente")]
        public Dictionary<string, Components> m_Componentes { get; set; }
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }
        public Objeto()
        {
            m_Position = new Vector();
            m_Componentes = new Dictionary<string, Components>();
        }
        public Objeto(Vector Position = default)
        {
            m_Componentes = new Dictionary<string, Components>();
            m_Position = Position;
        }

        public void Load()
        {
            foreach (KeyValuePair<string, Components> kvp in m_Componentes)
            {
                m_Componentes[kvp.Key].Load();
            }
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0, float yRot = 0, float zRot = 0)
        {
            Vector3 position = new Vector3(m_Position.X, m_Position.Y, m_Position.Z);
            foreach (KeyValuePair<string, Components> kvp in m_Componentes)
            {
                m_Componentes[kvp.Key].Draw(ViewProjection, Position + position, xRot, yRot, zRot);
            }
        }

        public void Unbind()
        {
            foreach (KeyValuePair<string, Components> kvp in m_Componentes)
            {
                m_Componentes[kvp.Key].Unbind();
            }
        }
    }
}
