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
        //public double alpha, beta, gamma;

        public Triangle(Vector position, Vector secondPoint, Vector thirdPoint, Material material) : base(position, material){
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
        }

        public override double DoesIntersect(Vector origin, Vector direction)
        {

            return 0;
        }

        // to find the normal of a triangle
        public override Vector NormalAtPoint(Vector point)
        {
            Vector onePointToAnother = (secondPoint - position);
            Vector anotherPointToAnother = (thirdPoint - position);
            Vector normal = (onePointToAnother % anotherPointToAnother).Normalize();
            return normal;
        }



    }
}
