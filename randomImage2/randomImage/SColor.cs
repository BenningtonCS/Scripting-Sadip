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

        // operator overloading * sign for color and scalar number
        public static SColor operator *(SColor color, double s) {
            return new SColor(color.r * s, color.g * s, color.b * s, color.a); // double not multiplying the alpha of a color
        }

        // operator overloading + sign for addition of two color
        public static SColor operator +(SColor x, SColor y) {
            return new SColor(x.r + y.r, x.g + y.g, x.b + y.b, x.a); // for addition of two colors only alpha of the first color is returned rather than additing those two
        }

        // operator overloading * sign for dot product of two color
        public static SColor operator *(SColor x, SColor y) {
            return new SColor(x.r * y.r, x.g * y.g, x.b * y.b, x.a);
        }
        

        // giving each r, g, b and a gamma values 
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
