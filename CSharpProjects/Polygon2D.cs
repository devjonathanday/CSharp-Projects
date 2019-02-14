using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public struct Polygon2D : IEquatable<Polygon2D>
    {
        public Vector2[] vertices;
        public int vertexCount { get { return vertices.Length; } }

        public Polygon2D(Vector2[] _vertices)
        {
            vertices = _vertices;
        }

        public bool Equals(Polygon2D other)
        {
            if (vertexCount != other.vertexCount) return false;
            for(int i = 0; i < vertexCount; i++)
            {
                if (vertices[i] != other.vertices[i])
                    return false;
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            Polygon2D polygonObj = (Polygon2D)obj;
            return Equals(polygonObj);
        }
        public static bool operator ==(Polygon2D poly, Polygon2D other)
        {
            return poly.Equals(other);
        }
        public static bool operator !=(Polygon2D poly, Polygon2D other)
        {
            return !(poly.Equals(other));
        }
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < vertexCount; i++)
                hash += vertices[i].GetHashCode();
            return hash;
        }
    }
}

//Vector and Polygon testing
/*
Vector2 testVecA = new Vector2(0, 3);
Vector2 testVecB = new Vector2(0, 3);

Vector2 testVecC = new Vector2(0, 4);
Vector2 testVecD = new Vector2(1, 3);

Polygon2D testPolyA = new Polygon2D( new Vector2[] {
    new Vector2(1, 2),
    new Vector2(5, 6),
    new Vector2(7, 10) });
Polygon2D testPolyB = new Polygon2D(new Vector2[] {
    new Vector2(1, 2),
    new Vector2(5, 6),
    new Vector2(7, 10) });

Polygon2D testPolyC = new Polygon2D(new Vector2[] {
    new Vector2(3, 2),
    new Vector2(5, 6),
    new Vector2(7, 10) });
Polygon2D testPolyD = new Polygon2D(new Vector2[] {
    new Vector2(1, 2),
    new Vector2(5, 6),
    new Vector2(7, 9) });

Console.WriteLine("testVecA " + (testVecA == testVecB ? "=" : "!=") + " testVecB");
Console.WriteLine("testVecC " + (testVecC == testVecD ? "=" : "!=") + " testVecD\n");
Console.WriteLine("testPolyA " + (testPolyA == testPolyB ? "=" : "!=") + " testPolyB");
Console.WriteLine("testPolyC " + (testPolyC == testPolyD ? "=" : "!=") + " testPolyD");

Console.ReadKey();
*/
