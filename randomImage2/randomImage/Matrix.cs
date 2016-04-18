using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Matrix
    {
        public Vector v1, v2, v3; //it is 3 by 3 matrix where it takes three column vectors 

        // making default
        public Matrix() {
            v1 = new Vector();
            v2 = new Vector();
            v3 = new Vector();
        }

        public Matrix(Vector v1, Vector v2, Vector v3) {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Matrix IdentityMatrix() {
             Vector a = new Vector(1,0,0);
             Vector b = new Vector(0,1,0);
             Vector c = new Vector(0,0,1);
             return new Matrix(a, b, c);
         }

        // operation overloading for addition of any two matrices using + sign
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return new Matrix(a.v1 + b.v1, a.v2 + b.v2, a.v3 + b.v3);
        }

        public static Matrix operator -(Matrix a, Matrix b) {
            return new Matrix(a.v1 - b.v1, a.v2 - b.v2, a.v3 - b.v3);
        }


        public double Determinant()
        {
            return ((v1.x * v2.y * v3.z) + (v2.x * v3.y *v1.z) + (v3.x * v1.y * v2.z) - (v3.x * v2.y * v1.z) - (v2.x * v1.y * v3.z) - (v1.x * v3.y * v2.z));
        }

        
        /*public static Matrix operator *(Matrix a, Matrix b) {
            Vector x = new Vector(a.v1.x, a.v2.x, a.v3.x);
            return new Matrix( x * b.v1, new Vector(a.v1.y, a.v2.y, a.v3.y) * b.v2, new Vector(a.v1.z, a.v2.z, a.v3.z) * b.v3);
        }*/
    }
}
