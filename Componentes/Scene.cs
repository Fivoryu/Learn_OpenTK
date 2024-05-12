using OpenTK.Mathematics;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hello_OpenTK.Componentes
{
    public class Scene : ITriangle
    {
        [JsonPropertyName("Objeto")]
        public Dictionary<string, Objeto> m_Objeto { get; set; }
        [JsonPropertyName("Posicion")]
        public Vector m_Position { get; set; }
        [JsonPropertyName("Rotation")]
        public Vector m_Rotation { get; set; }
        [JsonPropertyName("Scale")]
        public Vector m_Scale { get; set; }
        private Matrix4 Rotation, Position, Scale;
        [JsonPropertyName("InitialPosition")]
        public Vector FirstPosition { get; set; }

        public Scene()
        {
            this.m_Position = new Vector();
            this.m_Rotation = new Vector();
            this.m_Scale = new Vector(1.0f);
            this.Position = this.Rotation = Matrix4.Identity;
            Scale = Matrix4.Identity;
            m_Objeto = new Dictionary<string, Objeto>();
        }

        public Scene(Vector Position = default)
        {
            m_Objeto = new Dictionary<string, Objeto>();
            this.m_Position = FirstPosition = Position;
            this.Position = Matrix4.CreateTranslation(m_Position.X, m_Position.Y, m_Position.Z);
            this.m_Rotation = new Vector();
            this.m_Scale = new Vector(1.0f);
            this.Scale = Matrix4.CreateScale(1.0f);
            this.Rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.0f))
                   * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.0f));
        }

        public void SetTranslation(Vector Translation)
        {
            Position = Matrix4.CreateTranslation(Translation.X, Translation.Y, Translation.Z);
            m_Position = Translation;
        }

        public void SetRotation(Vector Rotation)
        {
            this.Rotation = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation.Z))
                   * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotation.Y)) * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotation.X));
            m_Rotation = Rotation;
        }

        public void SetScale(Vector Scale)
        {
            this.Scale = Matrix4.CreateScale(Scale.X, Scale.Y, Scale.Z);
            m_Scale = Scale;
        }

        public void Load()
        {
            this.Position = Matrix4.CreateTranslation(m_Position.X, m_Position.Y, m_Position.Z);
            this.Scale = Matrix4.CreateScale(1.0f);
            this.Rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.0f))
                   * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0.0f));
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
                m_Objeto[kvp.Key].Draw(Rotation * Scale * this.Position * ViewProjection, Position + position, xRot, yRot, zRot);
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
