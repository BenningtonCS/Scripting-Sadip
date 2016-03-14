using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    public class SColor
    {
        public double r, g, b, a;
        public SColor(double r, double g, double b, double a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public int GetRedColor()
        {
            return (int)(Math.Pow(r, (1 / 2.2)) * 255);
        }

        public int GetGreenColor() {
            return (int)(Math.Pow(g, (1 / 2.2)) * 255);
        }

        public int GetBlueColor() {
            return (int)(Math.Pow(b, (1 / 2.2)) * 255);
        }

        public int GetAlphaColor() {
            return (int)(Math.Pow(a, (1 / 2.2)) *255);
        }

       
    }
}
