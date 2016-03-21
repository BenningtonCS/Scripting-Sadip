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
        public Material material;

        public Shape(Vector position, SColor color) {
            this.position = position;
            this.material = new Material(color);
           //this.color = color;  
        }

        public virtual bool DoesIntersect(Vector origin, Vector direction) {
            return false;
        }
    }
}
