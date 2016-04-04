using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Algebra
    {
        // method to convert angle in degree into radian angle
        public static double convertToRad(double angleInDegrees)
        {
            return (Math.PI / 180) * angleInDegrees;
        }
    }
}
