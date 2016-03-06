using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Ray
    {
        Vector origin, direction;

        public void findingPoint(Vector origin, Vector direction, double radius, Vector position) {
          

            // to compute -d.(o - c) +- sqrt((d * (o - c))^2 - ((o - c)(o - c) - r^2)) which is equal to t

            // first find out (o - c)
            Vector originToPosition = (this.origin - position);
            double directionTimesOToC = direction * originToPosition;

            double firstValueOfT = -directionTimesOToC + Math.Sqrt((directionTimesOToC * directionTimesOToC) - (originToPosition * originToPosition) - Math.Pow(radius, 2)); 

            double secondValueOfT = -directionTimesOToC - Math.Sqrt((directionTimesOToC * directionTimesOToC) - (originToPosition * originToPosition) - Math.Pow(radius, 2));

            if (firstValueOfT >= 0) {
                 Console.WriteLine (firstValueOfT);
                if (secondValueOfT >= 0) {
                    Console.WriteLine(secondValueOfT);
                }
            }
            else {
                Console.WriteLine("Ray doesn't hit the sphere");
            }
        }
    }
}
