using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomImage
{
    class Camera
    {
        public Vector position;
        public int height = 500;
        public int width = 500;
        public double pixelSize = 1;
        public Vector direction;
   
        public Camera(Vector position, Vector direction) {
            this.position = position;
            this.direction = direction;
        }

        public void Render(Scene scene, Bitmap bmp) {

            // getting the color of the shape
            int a = scene.shape.material.color.GetAlphaColor();
            int r = scene.shape.material.color.GetRedColor();
            int g = scene.shape.material.color.GetGreenColor();
            int b = scene.shape.material.color.GetBlueColor();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Vector coordinate = new Vector((-width/2), (height/2), 0) + new Vector(0.5, -0.5, 0) + new Vector(i, -j, position.z); // changing the basis i.e. in terms of i and j of the image

                    if (scene.shape.DoesIntersect(coordinate, direction)) // checking whether the ray hits the sphere or not
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(a,r,g,b));
                        //bmp.SetPixel(i, j, Color.FromArgb((int)(a*0.5), (int)(r*0.5), (int)(g*0.5), (int)(b*0.5))); // checking by having 0.5 as the ambient of the shape
                        //Debug.WriteLine(i.ToString() + ", " + j.ToString());
                    }
                    else {
                        // it should return black as a default background color
                        bmp.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
                    }
                }
            }

            //pictureBox1.Image = bmp; // setting the image into pictureBox1

            bmp.Save("myImage.jpeg"); // it saves the random image 

    }
}
}
