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

        // setting a default vector
        public Vector()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        // constructing a vector
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // operation overloading for addtion of any two vector using + sign
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        // operation overloading for subtraction of any two vector using - sign
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - a.z);
        }

        // operation overloading for dot product of any two vectors using * sign
        public static double operator *(Vector a, Vector b)
        {
            return (double)(a.x * b.x + a.y * b.y + a.z * a.z);
        }

        // operation overloading for product of any scalar and any vector
        public static Vector operator *(Vector a, double b) {
            return new Vector(a.x * b, a.y * b, a.z * b);
        }

        // operation overloading for cross product of any two vectors
        public static Vector operator %(Vector a, Vector b)
        {
            return new Vector((a.y * b.z - a.z * b.y), (a.z * b.x - a.x * b.z), (a.x * b.y - a.y * b.x));
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        // defining function to find magnitude of any given vector
        public static double magnitude(Vector a) {
            return Math.Sqrt(Math.Pow(a.x, 2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
        }

        // defining function to normalize the any given vector
        public static Vector unitVector(Vector a) {
            return new Vector(a.x * (1/magnitude(a)), a.y * (1/magnitude(a)), a.z * (1/magnitude(a)));
        }


    }
}
