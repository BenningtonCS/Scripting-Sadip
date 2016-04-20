using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Matrix4By4
    {
        Matrix m; // this is 3 by 3 matrix
        Vector v1; // this is another 3 by 3 4th vector 
        Vector zeroVector = new Vector(); // this is another 3 by 3 vector which will always be (0,0,0)
        double n = 1; // this is for the last 4 by 4 element of the transformation matrix which will always be 1

        // making default
        public Matrix4By4()
        {
            Matrix m = new Matrix();
            Vector v1 = new Vector(); 
        }

        // 
        public Matrix4By4(Matrix m, Vector v1) {
            this.m = m;
            this.v1 = v1;
        }

        public static Matrix4By4 operator +(Matrix4By4 firstMatrix, Matrix4By4 secondMatrix) {
            return new Matrix4By4(firstMatrix.m + secondMatrix.m, firstMatrix.v1 + secondMatrix.v1);
        }

       public static Matrix4By4 operator *(Matrix4By4 firstMatrix, Matrix4By4 secondMatrix) {
            return new Matrix4By4(firstMatrix.m * secondMatrix.m, firstMatrix.m * secondMatrix.v1 + firstMatrix.v1);
        }

    }
}
