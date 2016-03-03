using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    public class SColor
    {
        double r, g, b, a;
        public SColor(double r, double g, double b, double a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public int GetRedColor()
        {
            return (int)(Math.Pow(this.r, (1 / 2.2)) * 255);
        }

        public int GetGreenColor() {
            return (int)(Math.Pow(this.g, (1 / 2.2)) * 255);
        }

        public int GetBlueColor() {
            return (int)(Math.Pow(this.b, (1 / 2.2) * 255) * 255);
        }

        public int GetAlphaColor() {
            return (int)(Math.Pow(this.a, (1 / 2.2) *255) * 255);
        }


        /*public static void Main() {
            Color newColor = new Color(r,g,b,a);
            int height = 500;
            int width = 500;
            for (int j = 1; j < height, j++) {
                for (int i = 1; i < width; i++) {

                }
            }
        }*/
    }
}
