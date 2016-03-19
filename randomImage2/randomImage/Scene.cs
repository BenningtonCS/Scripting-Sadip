using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Scene
    {
        public Sphere sphere;
        public Plane plane;


        public Scene(Sphere sphere) {
            this.sphere = sphere;
        }

        public Scene(Plane plane) {
            this.plane = plane;
        }
    }
}
