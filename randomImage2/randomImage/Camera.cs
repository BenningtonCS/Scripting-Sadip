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

            // getting the color of the sphere
            int a = scene.sphere.color.GetAlphaColor(); 
            int r = scene.sphere.color.GetRedColor();
            int g = scene.sphere.color.GetGreenColor();
            int b = scene.sphere.color.GetBlueColor();

            // getting the color of the plane
            /*int a = scene.plane.color.GetAlphaColor();
            int r = scene.plane.color.GetRedColor();
            int g = scene.plane.color.GetGreenColor();
            int b = scene.plane.color.GetBlueColor();*/

            // getting the color of the disk
            /*int a = scene.disk.color.GetAlphaColor();
            int r = scene.disk.color.GetRedColor();
            int g = scene.disk.color.GetGreenColor();
            int b = scene.disk.color.GetBlueColor();*/

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Vector coordinate = new Vector((-width/2), (height/2), 0) + new Vector(0.5, -0.5, 0) + new Vector(i, -j, position.z); // changing the basis i.e. in terms of i and j of the image

                    if (scene.sphere.DoesIntersect(coordinate, direction)) // checking whether the ray hits the sphere or not
                    {
                
                        bmp.SetPixel(i, j, Color.FromArgb(a, r, g, b));
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
