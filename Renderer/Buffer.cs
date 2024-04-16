using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace Hello_OpenTK.Renderer
{
    public class VertexBuffer
    {
        private int ID;

        public VertexBuffer(List<Vector3> data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector3.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public VertexBuffer(List<Vector2> data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector3.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Delete() { GL.DeleteBuffer(ID); }
    }

    public class IndexBuffer
    {
        public int ID;
        private int m_Count;

        public IndexBuffer(List<uint> data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
            m_Count = data.Count;
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Count * sizeof(uint), data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public int GetCount()
        {
            return m_Count;
        }

        public void Bind() { GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID); }
        public void Unbind() { GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0); }
        public void Delete() { GL.DeleteBuffer(ID); }

    }
}