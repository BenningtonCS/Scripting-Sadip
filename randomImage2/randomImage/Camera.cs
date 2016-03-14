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
        public int height = 400;
        public int width = 400;
        public double pixelSize = 1;
        public Vector direction;
   
        public Camera(Vector position, Vector direction) {
            this.position = position;
            this.direction = direction;
        }

        public void Render(Scene scene, Bitmap bmp) {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Vector coordinate = new Vector((-width/2), (height/2), 0) + new Vector(0.5, -0.5, 0) + new Vector(i, -j, position.z);
                    if (scene.sphere.DoesIntersect(coordinate, direction))
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(255, 255, 0, 0));
                        Debug.WriteLine(i.ToString() + ", " + j.ToString());
                    }
                    else {
                        bmp.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
                    }
                }
            }

            //pictureBox1.Image = bmp; // setting the image into pictureBox1

            bmp.Save("myImage.jpeg"); // it saves the random image 

    }
}
}
