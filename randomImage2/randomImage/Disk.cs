using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Disk : Shape // inheritating shape class where the center of the disk is related to the position of the shape class
    {
        public Vector normal; // this is the normal of the plane containing the disk
        public double radius; // radius of the disk

        public Disk(Vector normal, Vector position, double radius, SColor color) : base(position, color){
            this.normal = normal;
            this.radius = radius;
        }

        // creating a function to check whether the ray intersect the plane or not containing disk on it
        bool DoesIntersectDiskPlane(Vector origin, Vector direction) {
            Plane diskPlane = new Plane(normal, position, material.color); // checking whether the ray intersect the plane containing the disk
            return diskPlane.DoesIntersect(origin, direction);
        }

        // knowing whether the ray intersect the disk or not 
        public override bool DoesIntersect(Vector origin, Vector direction) { 
            double t = 0;
            if (DoesIntersectDiskPlane(origin, direction)) // at first let's find whether the ray intersect the plane or not 
            {                                           // if so then 
                Vector p = origin + direction * t;      // point of intersection in the plane
                Vector q = p - position;                // position vector from point to center of the disk
                double d = Vector.magnitude(q);         // magnitude of the vector which gives the distance inside the disk
                return (d <= radius);                   // then that distance should be smaller than that of radius of the disk according to geometric approach.
            }

            return false;
        }

    }
}
