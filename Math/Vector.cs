using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_OpenTK.Math
{
    public struct Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Length => MathF.Sqrt(X * X + Y * Y + Z * Z);

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(float x)
        {
            X = x;
            Y = x;
            Z = x;
        }

        public static Vector operator *(Vector vec, Vector scale)
        {
            vec.X *= scale.X;
            vec.Y *= scale.Y;
            vec.Z *= scale.Z;
            return vec;
        }

        public static Vector operator *(Vector vec, float mul)
        {
            vec.X *= mul;
            vec.Y *= mul;
            vec.Z *= mul;
            return vec;
        }

        public static Vector operator +(Vector vec, Vector scale)
        {
            vec.X += scale.X;
            vec.Y += scale.Y;
            vec.Z += scale.Z;
            return vec;
        }

        public static Vector operator -(Vector vec, Vector scale)
        {
            vec.X -= scale.X;
            vec.Y -= scale.Y;
            vec.Z -= scale.Z;
            return vec;
        }

        public static Vector operator /(Vector vec, float div)
        {
            vec.X /= div;
            vec.Y /= div;
            vec.Z /= div;
            return vec;
        }

        public bool Equals(Vector other)
        {
            if (X == other.X && Y == other.Y)
            {
                return Z == other.Z;
            }

            return false;
        }

        public Vector Normalized()
        {
            Vector result = this;
            result.Normalize();
            return result;
        }

        public void Normalize()
        {
            float num = 1f / Length;
            X *= num;
            Y *= num;
            Z *= num;
        }

        public static Vector Normalize(Vector vec)
        {
            float num = 1f / vec.Length;
            vec.X *= num;
            vec.Y *= num;
            vec.Z *= num;
            return vec;
        }


        public static void Distance(in Vector vec1, in Vector vec2, out float result)
        {
            result = MathF.Sqrt((vec2.X - vec1.X) * (vec2.X - vec1.X) + (vec2.Y - vec1.Y) * (vec2.Y - vec1.Y) + (vec2.Z - vec1.Z) * (vec2.Z - vec1.Z));
        }

        public static float Distance(Vector vec1, Vector vec2)
        {
            Distance(in vec1, in vec2, out var result);
            return result;
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }

    }
}
