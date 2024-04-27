using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hello_OpenTK.Componentes
{
    public class Scene : ITriangle
    {
        [JsonPropertyName("Objeto")]
        public Dictionary<string, Objeto> m_Objeto { get; set; }
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }

        public Scene()
        {
            this.m_Position = new Vector();
            m_Objeto = new Dictionary<string, Objeto>();
        }

        public Scene(Vector Position = default)
        {
            this.m_Position = Position;
            m_Objeto = new Dictionary<string, Objeto>();
        }

        public void Load()
        {
            foreach (KeyValuePair<string, Objeto> kvp in m_Objeto)
            {
                m_Objeto[kvp.Key].Load();
            }
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0, float yRot = 0, float zRot = 0)
        {
            Vector3 position = new Vector3(m_Position.X, m_Position.Y, m_Position.Z);
            foreach (KeyValuePair<string, Objeto> kvp in m_Objeto)
            {
                m_Objeto[kvp.Key].Draw(ViewProjection, Position + position, xRot, yRot, zRot);
            }
        }

        public void Unbind()
        {
            foreach (KeyValuePair<string, Objeto> kvp in m_Objeto)
            {
                m_Objeto[kvp.Key].Unbind();
            }
        }
    }
}
