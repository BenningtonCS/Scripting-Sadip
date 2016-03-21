﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Plane : Shape // inheritating shape class where point of plane is related to position of the shape class
    {
        public Vector normal; // this is the normal vector of the plane
        //public Vector point; // this is a point on a plane which is also a Vector coordinate

        // plane is defined here
        public Plane(Vector normal, Vector position, SColor color) : base(position, color){ 
            this.normal = normal;
        }

        // does the ray intersect the plane?
        public override bool DoesIntersect(Vector origin, Vector direction) {
            double t = 0; // setting the value of t as zero first
            double denominator = normal * direction; // from the formula t = ((point - Origin)*normal)/(direction * normal)
            if (denominator > 0) {
                Vector originToPoint = position - origin; // position vector from origin to point on the plane
                t = (originToPoint * normal) / denominator; // finding out the value of t from that formula
                return (t >= 0);
            }
            return false; // otherwise it returns false that is it doesnot intersect
        }
    }
}
