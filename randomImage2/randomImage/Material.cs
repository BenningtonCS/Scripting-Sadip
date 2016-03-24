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

        public Material(SColor color)
        {
            this.color = color;
        }

        // setting default ambient value
        public Material()
        {
            ambient = 1;
        }

        public Material(double ambient)
        {
            this.ambient = ambient;
        }
    }
}
