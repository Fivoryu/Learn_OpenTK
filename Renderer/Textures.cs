using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StbImageSharp;
using OpenTK.Graphics.OpenGL4;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Hello_OpenTK.Renderer
{
    internal class Textures
    {
        int Handle;
        public static Textures LoadFromFile(string filepath)
        {
            int handle;
            handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, handle);

            StbImage.stbi_set_flip_vertically_on_load(1);
            using (Stream stream = File.OpenRead(filepath))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                    image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            return new Textures(handle);
        }

        PixelInternalFormat m_InternalFormat;
        PixelFormat m_DataFormat;

        public Textures(int width = 1, int height = 1)
        {
            m_InternalFormat = PixelInternalFormat.Rgba8;
            m_DataFormat = PixelFormat.Rgba;

            GL.CreateTextures(TextureTarget.Texture2D, 1, out Handle);
            GL.TextureStorage2D(Handle, 1, (SizedInternalFormat)m_InternalFormat, width, height);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        }

        public void SetData(IntPtr data, uint size)
        {
            int bpp = m_DataFormat == PixelFormat.Rgba ? 4 : 3;
            GL.BindTexture(TextureTarget.Texture2D, Handle);
            GL.TextureSubImage2D(Handle, 0, 0, 0, 1, 1, m_DataFormat, PixelType.UnsignedByte, data);
        }

        public Textures(int glHandle)
        {
            Handle = glHandle;
        }

        public void Use(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }

        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}
