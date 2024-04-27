﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Componentes
{
    public class Components : ITriangle
    {
        [JsonPropertyName("Cara")]
        public Dictionary<string, Face> m_Faces { get; set; }
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }
        public Components()
        {
            this.m_Position = new Vector();
            m_Faces = new Dictionary<string, Face>();
        }

        public Components(Vector position = default)
        {
            
            this.m_Position = position;
            m_Faces = new Dictionary<string, Face>();
        }

        public void Load()
        {
            foreach (KeyValuePair<string, Face> kvp in m_Faces)
            {
                m_Faces[kvp.Key].Load();
            }
        }

        public void Draw(Matrix4 ViewProjection, Vector3 Position = default, float xRot = 0, float yRot = 0, float zRot = 0)
        {
            Vector3 position = new Vector3(m_Position.X, m_Position.Y, m_Position.Z);
            foreach (KeyValuePair<string, Face> kvp in m_Faces)
            {
                m_Faces[kvp.Key].Draw(ViewProjection, Position + position, xRot, yRot, zRot);
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
