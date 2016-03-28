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
        //public double fov;


        public Camera(Vector position, Vector direction)
        {
            this.position = position;
            this.direction = direction;
            //this.fov = fov;
        }


        public void Render(Scene scene, Bitmap bmp, Light light)
        {

            // getting the color of the shape


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Vector coordinate = new Vector((-width / 2), (height / 2), 0) + new Vector(0.5, -0.5, 0) + new Vector(i, -j, position.z); // changing the basis i.e. in terms of i and j of the image

                    bmp.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));

                    Shape closestShape = scene.shapes[0]; // rendering multiple objects so searching for the closest shape to render

                    double closestT = double.MaxValue; // shape which has closest T need to be rendered at first

                    foreach (Shape shape in scene.shapes)
                    {
                        double t = shape.DoesIntersect(coordinate, direction);
                        if (t < closestT && t >= 0)
                        {
                            closestT = t;
                            closestShape = shape;
                        }
                    }
                    if (closestShape.DoesIntersect(coordinate, direction) >= 0) // checking whether the ray hits the sphere or not
                    {
                        // for ligting 
                        Vector point = position + direction * closestT; // point of intersection 
                        Vector positionToPoint = point - closestShape.position;

                        // checking whether my unit vector works or not
                        Vector normal = Vector.unitVector(positionToPoint);
      
                        //double d = Math.Sqrt(Math.Pow(positionToPoint.x, 2) + Math.Pow(positionToPoint.y, 2) + Math.Pow(positionToPoint.z, 2));
                        //Vector normal = positionToPoint.Normalize(d); // normalizing position to point vector
                        Vector lightPositionToPoint = light.location - point;

                        Vector lightUnitVector = Vector.unitVector(lightPositionToPoint);

                        //double e = Math.Sqrt(Math.Pow(lightPositionToPoint.x, 2) + Math.Pow(lightPositionToPoint.y, 2) + Math.Pow(lightPositionToPoint.z, 2));
                        //Vector lightUnitVector = lightPositionToPoint.Normalize(e);
                        double n = -(lightUnitVector * normal); // finding the scalar value which gives the light intensity
                        double ambient = closestShape.material.ambient;

                        // if n will be greater than 0 then only lighting
                        if (n >= 0) { 
                        double r = closestShape.material.color.r * n * light.Intensity * light.lightColor.r;
                        double g = closestShape.material.color.g * n * light.Intensity * light.lightColor.g;
                        double b = closestShape.material.color.b * n * light.Intensity * light.lightColor.b;
                        double a = closestShape.material.color.a;

                        SColor newColor = new SColor(r, g, b, a);
                        bmp.SetPixel(i, j, Color.FromArgb(newColor.GetAlphaColor(), newColor.GetRedColor(), newColor.GetGreenColor(), newColor.GetBlueColor()));
                        }
                  
                    }
                }
            }
        }

        //pictureBox1.Image = bmp; // setting the image into pictureBox1

    }    

    }


