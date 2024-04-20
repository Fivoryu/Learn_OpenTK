using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Componentes
{
    public class Components : ITriangle
    {
        public Dictionary<string, Face> m_Faces { get; set; }
        public Vector3 m_Position { get; set; }

        public Components(Vector3 position = default)
        {
            
            this.m_Position = position;
            m_Faces = new Dictionary<string, Face>();
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0, float yRot = 0, float zRot = 0)
        {
            foreach (KeyValuePair<string, Face> kvp in m_Faces)
            {
                m_Faces[kvp.Key].Draw(ViewProjection, Position + m_Position, xRot, yRot, zRot);
            }
        }

        public void Unbind()
        {
            foreach (KeyValuePair<string, Face> kvp in m_Faces)
            {
                m_Faces[kvp.Key].Unbind();
            }
        }
    }
}
