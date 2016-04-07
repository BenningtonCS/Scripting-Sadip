using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Algebra // this is general algebra class for computing certain mathematical operations
    {
        // method to convert angle in degree into radian angle
        public static double convertToRad(double angleInDegrees)
        {
            return (Math.PI / 180) * angleInDegrees;
        }

        // making a swap method for interchanging the two variables values
        public static void swap(double a, double b)
        {
            double t = a;
            a = b;
            b = t;
        }

        //making a function to find the determinant of the given 3*3 matrix
       /* public static double det2(double[,] arr) {

            if (arr.Length > 2)
            {

            }

            return determinant;
        };*/

    }
}
