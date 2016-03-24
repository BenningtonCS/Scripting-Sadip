using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    public class Scene
    {
        public Shape shape;

        public Shape[] shapes;

        public Scene(Shape shape) {
            this.shape = shape;
        }

        public Scene(Shape[] shapes)
        {
            this.shapes = shapes;
        }

    }
}
