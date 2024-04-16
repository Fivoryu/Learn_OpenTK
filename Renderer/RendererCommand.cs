using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Hello_OpenTK.Renderer
{
    
    public class RendererCommand
    {
        public RendererCommand() { }
        public void Init()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.DepthTest);
        }

        public void SetViewport(UInt32 x, UInt32 y, UInt32 width, UInt32 height) 
        {
            GL.Viewport((int)x, (int)y, (int)width, (int)height);
        }

        public void SetClearColor(ref Vector4 color)
        {
            GL.ClearColor(color.X, color.Y, color.Z, color.W);
        }

        public void DrawIndexed(VertexArray vertexArray)
        {
            //GL.DrawElements(PrimitiveType.Triangles, vertexArray.GetIndexBufferCount(), DrawElementsType.UnsignedInt, 0);
        }
    }
}
