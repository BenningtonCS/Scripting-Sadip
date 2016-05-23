using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    public class Material
    {
        public double ambient;
        public SColor color;
        public double reflectionCoefficient;

        public Material(SColor color)
        {
            this.color = color;
            this.ambient = 1; // making default ambient value to be 1
            this.reflectionCoefficient = 1;
        }

        //constructor initializer list
        public Material(SColor color, double ambient) : this(color) {
            this.ambient = ambient; // making ambient to be optional and assigning it's default value
        }

        public Material(SColor color, double ambient, double reflectionCoefficient) : this(color)
        {
            this.ambient = ambient; // making ambient to be optional and assigning it's default value
            this.reflectionCoefficient = reflectionCoefficient;
        }

        /*//implementing the reflection and refraction of the light
        public Ray ReflectedColor(Vector origin, Vector direction, Shape shape) {
           // SColor reflectedColor = new SColor();
            Vector point = origin + direction * shape.DoesIntersect(origin, direction);
            Vector eye = origin - point;
            Vector normal = shape.NormalAtPoint(point);
            Vector reflectedRay = (-1) * eye + 2.0 * (normal * eye) * normal;

            Ray ray = new Ray(point,reflectedRay);
            return ray;

        }*/
    }
}
