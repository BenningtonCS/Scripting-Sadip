using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Sphere : Shape // inheritating shape class where center of the sphere is related to position of shape
    {
        public double radius;

        // defining a sphere with it's parameters
        public Sphere(double radius, SColor color, Vector position) : base(position, color){
            this.radius = radius;
        }

        // knowing whether the ray intersect the sphere or not
        // strictly using geometric approach for efficient ray tracing 
        public bool DoesIntersect(Vector origin, Vector direction) {
            Vector p = position - origin; // position vector from center of the sphere to origin of the ray
            double d = direction * p; // projection onto the ray
            double q = (p * p) - (d * d); // distance from the center to the ray hitting the sphere
            // finding 'x' distance inside the sphere
            double x = (radius * radius) - q; // here q is a squared term itself
            double t1 = 0;
            double t2 = 0;

            if (x < 0) {
                return false;
            } else if (x > 0) {
                t1 = d - Math.Sqrt(x); // x is a squared term so need to find its square root
                t2 = d + Math.Sqrt(x); 
            }

            if ((t1 <0) && (t2 < 0)) {
                return false;
            }
            if ((t1 > 0) | (t2 > 0)) {
                if (t2 > t1) { // need to take the nearest point i.e. small t value greater than zero
                    t1 = t2;
                }
            }

            return true;
        }
    }
}
