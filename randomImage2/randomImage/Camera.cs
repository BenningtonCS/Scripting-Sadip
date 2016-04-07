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
            Vector y = new Vector(0, 1, 0);
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



        public void Render(Scene scene, Bitmap bmp, Light[] lights)
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
                    if (closestShape.DoesIntersect(position, rayDirection) >= 0 ) // checking whether the ray hits the sphere or not
                    {
                        SColor color = closestShape.material.color;
                        double ambient = closestShape.material.ambient;

                        SColor lightContribution = new SColor();

                        Vector point = position + (rayDirection * closestT); // point of intersection
                        Vector normal = closestShape.NormalAtPoint(point);

                        // for multiple lighting
                        foreach (Light light in lights)
                        {
                            // for also checking shadows
                            Vector shadowRayDirection = (light.location - point).Normalize(); // calculating the direction of the ray of the shadow

                            // at first assigning inShadow variable boolean value false so that we can check whether any shape is in shadow or not
                            bool inShadow = false; 

                            foreach (Shape shape in scene.shapes)
                            {
                                //checking whether each shape is in shadow or not
                                // also checking whether the distance from the point of intersection and the direction of the ray is greater than the ray intersection distance
                                if (shape.DoesIntersect(point + (normal * 0.5), shadowRayDirection) >= 0 && Math.Abs((light.location - point).Magnitude()) > shape.DoesIntersect(position, rayDirection))
                                {
                                    inShadow = true; 
                                    break; // giving break point if it's in in shadow
                                }
                            }
                            if (inShadow)
                            {
                                continue; // if it's in shadow than continuing that is casting a shadow
                            }

                            Vector lightToPoint = point - light.location; // position vector from light to point of intersection
                            Vector lightDriection = lightToPoint.Normalize(); // and then normalizing it to get the direction of that vector
                            double cosineAngle = -(lightDriection * normal); // finding the scalar value which gives the light intensity

                            if (cosineAngle >= 0) 
                            {
                                lightContribution = lightContribution + (light.lightColor * color * cosineAngle * light.Intensity);
                            }
                        }

                        // calculating diffuse reflectance 
                        double diffuseReflectance = 1 - ambient;

                        //calculating color of the shape
                        SColor shapeColor = lightContribution * diffuseReflectance + (color * ambient);
                        bmp.SetPixel(j, i, Color.FromArgb(shapeColor.GetAlphaColor(), shapeColor.GetRedColor(), shapeColor.GetGreenColor(), shapeColor.GetBlueColor()));
                    }
                }
            }
        }

    }
}  



