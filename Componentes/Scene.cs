using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_OpenTK.Componentes
{
    public class Scene : ITriangle
    {
        public Dictionary<string, Objeto> m_Objeto { get; set; }
        public Vector3 m_Position { get; set; }

        public Scene(Vector3 Position = default)
        {
            this.m_Position = Position;
            m_Objeto = new Dictionary<string, Objeto>();
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0, float yRot = 0, float zRot = 0)
        {
            foreach(KeyValuePair<string, Objeto> kvp in m_Objeto)
            {
                m_Objeto[kvp.Key].Draw(ViewProjection, Position + m_Position, xRot, yRot, zRot);
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
