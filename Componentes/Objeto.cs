using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Componentes
{
    public class Objeto : ITriangle
    {
        public Dictionary<string, Components> m_Componentes { get; set; }
        public Vector3 m_Position { get; set; }

        public Objeto(Vector3 Position = default)
        {
            m_Componentes = new Dictionary<string, Components>();
            m_Position = Position;
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0, float yRot = 0, float zRot = 0)
        {
            foreach (KeyValuePair<string, Components> kvp in m_Componentes)
            {
                m_Componentes[kvp.Key].Draw(ViewProjection, Position + m_Position, xRot, yRot, zRot);
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
