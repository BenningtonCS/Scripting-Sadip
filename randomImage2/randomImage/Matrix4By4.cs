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

        // making default 4 by 4 matrix as identity matrix
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

        public static Matrix4By4 XRotation(double rotationAngleThroughXAxis)
        {
            return new Matrix4By4(new Matrix(new Vector(1, 0, 0), new Vector(0, Math.Cos(Algebra.convertToRad(rotationAngleThroughXAxis)), Math.Sin(Algebra.convertToRad(rotationAngleThroughXAxis))), new Vector(0, (-1) * Math.Sin(Algebra.convertToRad(rotationAngleThroughXAxis)), Math.Cos(Algebra.convertToRad(rotationAngleThroughXAxis)))), new Vector());
        }


        public static Matrix4By4 YRotation(double rotationAngleThroughYAxis) {
            return new Matrix4By4(new Matrix(new Vector(Math.Cos(Algebra.convertToRad(rotationAngleThroughYAxis)), 0, (-1) * Math.Sin(Algebra.convertToRad(rotationAngleThroughYAxis))), new Vector(0, 1, 0), new Vector(Math.Sin(Algebra.convertToRad(rotationAngleThroughYAxis)),0,Math.Cos(Algebra.convertToRad(rotationAngleThroughYAxis)))), new Vector());
        }


        public static Matrix4By4 ZRotation(double rotationAngleThroughZAxis) {
            return new Matrix4By4(new Matrix(new Vector(Math.Cos(Algebra.convertToRad(rotationAngleThroughZAxis)), Math.Sin(Algebra.convertToRad(rotationAngleThroughZAxis)),0), new Vector(Math.Sin(Algebra.convertToRad(rotationAngleThroughZAxis)),Math.Cos(Algebra.convertToRad(rotationAngleThroughZAxis)),0), new Vector()), new Vector());
        }


        public static Matrix4By4 operator +(Matrix4By4 firstMatrix, Matrix4By4 secondMatrix) {
            return new Matrix4By4(firstMatrix.m + secondMatrix.m, firstMatrix.v1 + secondMatrix.v1);
        }

       public static Matrix4By4 operator *(Matrix4By4 firstMatrix, Matrix4By4 secondMatrix) {
            return new Matrix4By4(firstMatrix.m * secondMatrix.m, firstMatrix.m * secondMatrix.v1 + firstMatrix.v1);
        }



    }
}
