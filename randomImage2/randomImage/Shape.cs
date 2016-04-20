using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    public class Shape
    {
        public Vector position;
        public Material material;
        //public SColor color;

        public Shape(Vector position, Material material)
        {
            this.position = position;
            this.material = material;
            //this.color = color;  
        }


        public virtual double DoesIntersect(Vector origin, Vector direction)
        {
            return -1;
        }

        public virtual Vector NormalAtPoint(Vector point)
        {
            return new Vector(0, 0, 0);
        }

        /* Matrix ConvertToTranformationMatrix(Vector scale) {
             return new Matrix4By4(, scale);
         }*/
    }
}
