using Hello_OpenTK.Renderer;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_OpenTK.Componentes
{
    public class Face : ITriangle
    {
        public Dictionary<string, Triangle> m_Triangles { get; set; }
        public Vector3 m_Position { get; set; }
        public Face(Vector3 Position = default)
        {
            m_Position = Position;
            m_Triangles = new Dictionary<string, Triangle>();
            
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f)
        {
            foreach (KeyValuePair<string, Triangle> kvp in m_Triangles)
            {
                m_Triangles[kvp.Key].Draw(ViewProjection, Position + m_Position, xRot, yRot, zRot);
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
