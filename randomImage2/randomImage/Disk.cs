using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Disk
    {
        public Vector normal;
        public Vector center;
        public double radius;
        public SColor color;

        public Disk(Vector normal, Vector center, double radius, SColor color) {
            this.normal = normal;
            this.center = center;
            this.radius = radius;
            this.color = color;
        }

        // knowing whether the ray intersect the disk or not 
        public bool DoesIntersect(Vector origin, Vector direction) { 
            double t = 0;
            if (Plane.DoesIntersect(origin, direction)) // at first let's find whether the ray intersect the plane or not 
            {                                           // if so then 
                Vector p = origin + direction * t;      // point of intersection in the plane
                Vector q = p - center;                  // position vector from point to center of the disk
                double d = Vector.magnitude(q);         // magnitude of the vector which gives the distance inside the disk
                return (d <= radius);                   // then that distance should be smaller than that of radius of the disk according to geometric approach.
            }

            return false;
        }
    }
}
