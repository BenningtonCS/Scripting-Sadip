using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Ambient
    {
        public double ambient;

        // setting default ambient value
        public Ambient() {
            ambient = 1;
        }

        public Ambient(double ambient) {
            this.ambient = ambient;
        }
    }
}
