using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace Hello_OpenTK.Renderer
{
    public class VertexArray
    {
        private int ID;
        private IndexBuffer m_IndexBuffer;

        public VertexArray()
        {
            ID = GL.GenVertexArray();
            GL.BindVertexArray(ID);
        }

        public void AddVertexBuffer(int location, int size, VertexBuffer vertexBuffer)
        {
            Bind();
            vertexBuffer.Bind();

            GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(location);
        }

        public void SetIndexBuffer(IndexBuffer indexBuffer)
        {
            Bind();
            indexBuffer.Bind();
            m_IndexBuffer = indexBuffer;
        }

        public int GetIndexBufferCount()
        {
            return m_IndexBuffer.GetCount();
        }

        public void Bind() { GL.BindVertexArray(ID); }
        public void Unbind() { GL.BindVertexArray(0); }
        public void Delete() { GL.DeleteVertexArray(ID); }
    }
}
