using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Vector
    {
        public double x, y, z;

        public Vector()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - a.z);
        }

        public static double operator *(Vector a, Vector b)
        {
            return (double)(a.x * b.x + a.y * b.y + a.z * a.z);
        }

        public static Vector operator *(Vector a, double b) {
            return new Vector(a.x * b, a.y * b, a.z * b);
        }

        public static Vector operator %(Vector a, Vector b)
        {
            return new Vector((a.y * b.z - a.z * b.y), (a.z * b.x - a.x * b.z), (a.x * b.y - a.y * b.x));
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        public static double magnitude(Vector a) {
            return Math.Sqrt(Math.Pow(a.x, 2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
        }

        public static double recMagnitude(Vector a) {
            return (1 / magnitude(a));
        }

        public static Vector unitVector(Vector a) {
            return new Vector(a.x * recMagnitude(a), a.y * recMagnitude(a), a.z * recMagnitude(a));
        }
    }
}
