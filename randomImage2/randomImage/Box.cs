using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Box : Shape // inheriting shape class where minPosition of the box is related to position of the shape class
    {
        public Vector maxPosition; // this is the another position of the box

        public Box(Vector position, Vector maxPosition, SColor color) : base(position, color){
            this.maxPosition = maxPosition;
        }

        public override bool DoesIntersect(Vector origin, Vector direction) {
            
            return true;
        }

    }
}
