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

        public Triangle(Vector position, Vector secondPoint, Vector thirdPoint, SColor color) : base(position, color){
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
        }

       

    }
}
