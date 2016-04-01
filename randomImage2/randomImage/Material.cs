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

        public Material(SColor color, double ambient)
        {
            this.color = color;
            this.ambient = ambient;
        }
    }
}
