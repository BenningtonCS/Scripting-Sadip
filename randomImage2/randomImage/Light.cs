using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Light
    {
        public Vector direction;
        public SColor lightColor;

        public Light(Vector direction, SColor lightColor) {
            this.direction = direction;
            this.lightColor = lightColor;
        } 

    }
}
