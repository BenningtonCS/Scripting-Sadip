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
            

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Vector coordinate = new Vector((-width / 2), (height / 2), 0) + new Vector(0.5, -0.5, 0) + new Vector(i, -j, position.z); // changing the basis i.e. in terms of i and j of the image
                    bmp.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));

                    Shape closestShape = scene.shapes[0];

                    double closestT = double.MaxValue;

                    foreach (Shape shape in scene.shapes)
                    {
                        double t = shape.DoesIntersect(coordinate, direction);
                        if (t < closestT && t >=0) {
                            closestT = t;
                            closestShape = shape;
                        }
                    }
                    if (closestShape.DoesIntersect(coordinate, direction) >= 0) // checking whether the ray hits the sphere or not
                    {
                        int a = closestShape.material.color.GetAlphaColor();
                        int r = closestShape.material.color.GetRedColor();
                        int g = closestShape.material.color.GetGreenColor();
                        int b = closestShape.material.color.GetBlueColor();
                        bmp.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                    }
                }
                }
            }

            //pictureBox1.Image = bmp; // setting the image into pictureBox1

           

    }
}

