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
                    Vector coordinate = new Vector((-width / 2), (height / 2), 0) + new Vector(0.5, -0.5, 0) + new Vector(j, -i, position.z); // changing the basis i.e. in terms of i and j of the image

                    bmp.SetPixel(j, i, Color.FromArgb(255, 0, 0, 0));

                    Shape closestShape = scene.shapes[0]; // rendering multiple objects so searching for the closest shape to render

                    double closestT = double.MaxValue; // shape which has closest T need to be rendered at first

                    foreach (Shape shape in scene.shapes)
                    {
                        double t = shape.DoesIntersect(coordinate, direction);
                        if ((t < closestT) && (t >= 0))
                        {
                            closestT = t;
                            closestShape = shape;
                        }
                    }
                    if (closestShape.DoesIntersect(coordinate, direction) >= 0) // checking whether the ray hits the sphere or not
                    {
                        // for ligting
                        Vector point = position + (direction * closestT); // point of intersection 
                        Vector normal = closestShape.NormalAtPoint(point);

                        Vector lightPositionToPoint = point - light.location;

                        Vector lightUnitVector = lightPositionToPoint.Normalize(); //normalizing another vector

    
                        double cosineAngle = -(lightUnitVector * normal); // finding the scalar value which gives the light intensity
                        //double ambient = closestShape.material.ambient;
                        //double ambient = 0.5;
                        //double ambient = closestShape.material.ambient;
                        

                        // diffuse reflectance
                        double diffuseReflectance = 1 - closestShape.material.ambient;

                        // if cosineAngle will be greater than 0 then only lighting
                        if (cosineAngle >= 0)
                        {
                            //creating new color factor variable
                            //double colorFactor = (diffuseReflectance * light.Intensity * cosineAngle) * light.lightColor;

                            /*double r = closestShape.material.color.r * colorFactor * ambient;
                            double g = closestShape.material.color.g * colorFactor * ambient;
                            double b = closestShape.material.color.b * colorFactor * ambient;
                            double a = closestShape.material.color.a;*/

                            SColor newColor = (closestShape.material.color/*light.lightColor*/ * light.Intensity * cosineAngle) * diffuseReflectance + (closestShape.material.color * closestShape.material.ambient);
                            bmp.SetPixel(j, i, Color.FromArgb(newColor.GetAlphaColor(), newColor.GetRedColor(), newColor.GetGreenColor(), newColor.GetBlueColor()));
                        }  else
                        {
                            SColor newColor = closestShape.material.color * closestShape.material.ambient;
                            bmp.SetPixel(j, i, Color.FromArgb(newColor.GetAlphaColor(), newColor.GetRedColor(), newColor.GetGreenColor(), newColor.GetBlueColor()));
                        }
                  }
                    }
                }
            }
        }

        //pictureBox1.Image = bmp; // setting the image into pictureBox1

    }    



