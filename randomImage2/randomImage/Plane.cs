using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Plane
    {
        public Vector normal; // this is the normal vector of the plane
        public Vector point; // this is a point on a plane which is also a Vector coordinate
        public SColor planeColor; // this is the color assigned to plane

        // plane is defined here
        public Plane(Vector normal, Vector point, SColor planeColor) { 
            this.normal = normal;
            this.point = point;
            this.planeColor = planeColor;
        }

        // does the ray intersect the plane?
        public bool DoesIntersect(Vector origin, Vector direction) {
            double t = 0; // setting the value of t as zero first
            double denominator = normal * direction; // from the formula t = ((point - Origin)*normal)/(direction * normal)
            if (denominator > 0) {
                Vector originToPoint = point - origin; // position vector from origin to point on the plane
                t = (originToPoint * normal) / denominator; // finding out the value of t from that formula
                return (t >= 0);
            }
            return false; // otherwise it returns false that is it doesnot intersect
        }
    }
}
