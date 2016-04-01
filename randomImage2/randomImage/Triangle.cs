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

       

    }
}
