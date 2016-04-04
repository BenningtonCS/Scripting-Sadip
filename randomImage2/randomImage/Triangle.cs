using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Triangle : Shape
    {
        public Vector secondPoint, thirdPoint;

        public Triangle(Vector position, Vector secondPoint, Vector thirdPoint, Material material) : base(position, material){
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
        }

        public override double DoesIntersect(Vector origin, Vector direction)
        {
            // compute plane's normal
            Vector firstPointToSecondPoint = secondPoint - position;
            Vector secondPointToThirdPoint = thirdPoint - secondPoint;

            // no need to normalize
            Vector N = firstPointToSecondPoint % secondPointToThirdPoint;
            double area2 = N.Magnitude();

            // step 1 : finding P

            // check if ray and plane are parallel ?

            double NDotRayDirection = N * direction;
            if (Math.Abs(NDotRayDirection) < float.Epsilon)
                return -1;
            

            // compute d parameter using equation 2
            double d = N * position;

            // compute t(equation 3)
            double t = (N * origin + d) / NDotRayDirection;

            //check if the triangle is in behind the ray
            if (t < 0)
                return -1; // the triangle is behind the ray
      

            // compute the intersection point using equation 1
            Vector p = origin + direction * t;

            // step2 inside outside test
            Vector C;

            //edge 0
            Vector edge0 = firstPointToSecondPoint;
            Vector vp0 = p - position;
            C = edge0 % vp0;
            if ((N * C) < 0)
                return -1; // p is on the right side
            


            //edge 1
            Vector edge1 = secondPointToThirdPoint;
            Vector vp1 = p - secondPoint;
            C = edge1 % vp1;
            if ((N * C) < 0)
                return -1; // p is on the right side
            

            //edge 2
            Vector edge2 = position - thirdPoint;
            Vector vp2 = p - thirdPoint;
            C = edge2 % vp2;
            if ((N * C) < 0)
                return -1; // p is on the right side

            return t;
        }

        // to find the normal of a triangle
        public override Vector NormalAtPoint(Vector point)
        {
            Vector onePointToAnother = (secondPoint - position);
            Vector anotherPointToAnother = (thirdPoint - position);
            Vector normal = onePointToAnother % anotherPointToAnother;
            return normal;
        }



    }
}
