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
        public Vector position, u, v, w, lookAt;
        public double fov;
        public int height = 500;
        public int width = 500;
        public double pixelSize = 1;
        //public Vector direction;
        //public double fov;

        public Camera(Vector position, Vector lookAt) // for the perspective camera
        {
            this.position = position; // this is the location of the camera
            this.lookAt = lookAt; // this is the looking point of the perspective camera
            this.fov = 52; // setting fov as 52 degree angle
            //Calculate u, v, w from position and lookAt
            Vector y = new Vector(0,1,0);
            w = (lookAt - position).Normalize(); // calculating w which is the unit position vector from position to look at point of the camera
            u = y % w; // calculating u which is the cross product of y and w
            v = w % u; // calculating v which is the cross product of w and u

        }

        public Camera(Vector position, Vector lookAt, double fov) : this(position, lookAt)
        {
            this.fov = fov; // setting fov as optional parameter for defining the camera
        }

        public Vector convertCameraToWorldCoordinates(Vector point)
        {
            return (u * point.x + v * point.y + w * point.z); // converting into world coordinates
        }
        
        

        public void Render(Scene scene, Bitmap bmp, Light light)
        {

            // getting the color of the 
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    //Vector coordinate = new Vector((-width / 2), (height / 2), 0) + new Vector(0.5, -0.5, 0) + new Vector(j, -i, position.z); // changing the basis i.e. in terms of i and j of the image
                    double dx = (j - (width / 2) + 0.5); // calculating dx
                    double dy = ((height / 2) - i) + 0.5; // calculating dy
                    double dz = (height / 2) / (Math.Tan(Algebra.convertToRad(fov * 0.5))); // calculating dz
                    Vector rayDirection = convertCameraToWorldCoordinates(new Vector(dx, dy, dz)).Normalize(); // so vector (dx, dy, dz) will be the direction of the ray which is normalized
                    bmp.SetPixel(j, i, Color.FromArgb(255, 0, 0, 0));

                    Shape closestShape = scene.shapes[0]; // rendering multiple objects so searching for the closest shape to render

                    double closestT = double.MaxValue; // shape which has closest T need to be rendered at first

                    foreach (Shape shape in scene.shapes)
                    {
                        double t = shape.DoesIntersect(this.position, rayDirection);
                        if ((t < closestT) && (t >= 0))
                        {
                            closestT = t;
                            closestShape = shape;
                        }
                    }
                    if (closestShape.DoesIntersect(position, rayDirection) >= 0) // checking whether the ray hits the sphere or not
                    {
                        // for lighting
                        Vector point = position + (rayDirection * closestT); // point of intersection 
                        Vector normal = closestShape.NormalAtPoint(point);

                        Vector lightPositionToPoint = point - light.location;

                        Vector lightUnitVector = lightPositionToPoint.Normalize(); //normalizing another vector

    
                        double cosineAngle = -(lightUnitVector * normal); // finding the scalar value which gives the light intensity
                       
                        

                        // diffuse reflectance
                        double diffuseReflectance = 1 - closestShape.material.ambient;

                        // if cosineAngle will be greater than or equal to 0 then only lighting
                        if (cosineAngle >= 0)
                        {
                           

                            /*double r = closestShape.material.color.r * colorFactor * ambient;
                            double g = closestShape.material.color.g * colorFactor * ambient;
                            double b = closestShape.material.color.b * colorFactor * ambient;
                            double a = closestShape.material.color.a;*/

                            SColor newColor = (closestShape.material.color * light.lightColor * light.Intensity * cosineAngle) * diffuseReflectance + (closestShape.material.color * closestShape.material.ambient);
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

    }    



