using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class DirectionalLight : Light
    {
        public DirectionalLight(Vector direction, SColor color) : base(direction, color){
            this.direction = direction;
        }

        /*public double LightIntensity(Vector origin, Vector direction, double t, Vector position) {
            double i = 0;
            Vector p = origin + direction * t;
            Vector positionToPoint = p - position;
            Vector normal = unitVector(positionToPoint);
            i = -(Light.direction * normal);
            if () { };
            return i;
        }*/

    }
}
