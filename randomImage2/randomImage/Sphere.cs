using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Sphere
    {
        public double radius;
        public SColor color;
        public Vector center;
        public Sphere(double radius, SColor color, Vector center) {
            this.radius = radius;
            this.color = color;
            this.center = center; 
        }

        public bool DoesIntersect(Vector origin, Vector direction) {
            Vector p = center - origin;
            double d = direction * p;
            double q = (p * p) - (d * d);
            double x = (radius * radius) - q;
            double t1 = 0;
            double t2 = 0;

            if (x < 0) {
                return false;
            } else if (x > 0) {
                t1 = d - Math.Sqrt(x);
                t2 = d + Math.Sqrt(x);
            }

            if ((t1 <0) && (t2 < 0)) {
                return false;
            }
            if ((t1 > 0) | (t2 > 0)) {
                if (t2 > t1) {
                    t1 = t2;
                }
            }

            return true;
        }
    }
}
