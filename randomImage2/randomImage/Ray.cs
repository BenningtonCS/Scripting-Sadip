using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Ray
    {
        public static Vector direction;

        public static double findingT (){


            // to compute -d.(o - c) +- sqrt((d * (o - c))^2 - ((o - c)(o - c) - r^2)) which is equal to t

            // first find out (o - c)
            
            Vector originToPosition = (Camera.position - Sphere.center);
            double directionTimesOToC = direction * originToPosition;

            double t1 = -directionTimesOToC + Math.Sqrt((directionTimesOToC * directionTimesOToC) - (originToPosition * originToPosition) - Math.Pow(radius, 2));

            double t2 = -directionTimesOToC - Math.Sqrt((directionTimesOToC * directionTimesOToC) - (originToPosition * originToPosition) - Math.Pow(radius, 2));
            if (t1 > 0 & t2 > 0 ) {
                return Math.Min(t1, t2);
            }
            return 0;
        }
    }
}
