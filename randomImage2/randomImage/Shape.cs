using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Shape
    {
        public Vector position;
        public SColor color;

        public Shape(Vector position, SColor color) {
            this.position = position;
            this.color = color;  
        }

        public bool DoesIntersect() {
            return false;
        }
    }
}
