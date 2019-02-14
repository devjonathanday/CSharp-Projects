using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float x, y;

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public Vector2 Sum(Vector2 rhs)
        {
            return new Vector2(x + rhs.x, y + rhs.y);
        }
        public Vector2 Difference(Vector2 rhs)
        {
            return new Vector2(x - rhs.x, y - rhs.y);
        }
        public double magnitude
        {
            get { return Math.Sqrt((x * x) + (y * y)); }
        }
        public Vector2 normalized
        {
            get { return new Vector2(x / (float)magnitude, y / (float)magnitude); }
        }
        public bool Equals(Vector2 other)
        {
            return (Math.Abs(x - other.x) < float.Epsilon && Math.Abs(y - other.y) < float.Epsilon);
        }
        public override bool Equals(Object obj)
        {
            Vector2 vecObj = (Vector2)obj;
            return Equals(vecObj);
        }
        public static bool operator == (Vector2 vec, Vector2 other)
        {
            return vec.Equals(other);
        }
        public static bool operator != (Vector2 vec, Vector2 other)
        {
            return !(vec.Equals(other));
        }
        public override int GetHashCode()
        {
            return (int)((x * x + y) + (y * y + x));
        }
    }
}
