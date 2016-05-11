using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace randomImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                       

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // making a sphere by assigning it it's parameters
            Vector sphereCenter = new Vector(0,0,0);
            Material material1 = new Material(new SColor(1,0,1,1), 0.5);
            Sphere sphere1 = new Sphere(5, material1, sphereCenter);
            sphere1.AddScaleToTransformationMatrix(new Vector(2,1,1));
            //sphere1.AddTranslationToTranformationMatrix(new Vector(-30,10,0));
            //sphere1.AddRotationThroughAllAxisToTransformationMatrix(0,0,0);
            //sphere1.AddRotationThroughXAxisToTransformationMatrix(90);
            //sphere1.AddRotationThroughZAxisToTransformationMatrix(90);
          

            // making a sphere by assigning it it's parameters
            Vector sphereCenter1 = new Vector(30, 0, -10);
            Sphere sphere2 = new Sphere(4, new Material(new SColor(1,1,0,1), 0.25), sphereCenter1);

            //making a sphere by assigning it it's parameters
            Sphere sphere3 = new Sphere(1, new Material(new SColor(1,0,0,1)), new Vector(5,40,-60));

            // making a plane by assigning it it's parameters
            Vector planeNormal = new Vector(0,1,0); // this will give a plane which direction is towards the direction of camera.
            Vector planePoint = new Vector(0,-50,0);
            Plane  plane1 = new Plane(planeNormal, planePoint, new Material(new SColor(1,1,1,1), 0.25));

            // making a disk by assigning it it's parameters
            Vector diskNormal = new Vector(0,1,0); // plane will be vertical  
            Vector diskCenter = new Vector(0,-10,0);
            double diskRadius = 20;
            Disk disk1 = new Disk(diskNormal, diskCenter, diskRadius, new Material(new SColor(0,1,1,1), 0.29));


            //making a triangle
            Triangle triangle = new Triangle(new Vector(-10,0,0), new Vector(10,0,0), new Vector(0,10,0), new Material(new SColor(1,0,0,1), 0.25));
            //triangle.AddScaleToTransformationMatrix(new Vector(2,2,2));
            //triangle.AddRotationThroughYAxisToTransformationMatrix(180);
            // making a light i.e. a point light
            Light light1 = new Light(new Vector(-20,30,2) , 0.75, new SColor(1,1,1,1));

            // making another light 
            Light light2 = new Light(new Vector(100, 200, -200), 0.75, new SColor(1, 1, 1, 1));

            // making a box by assigning it it's parameters
            Box box1 = new Box(new Vector(5,5,5), new Vector(15,15,15), new Material(new SColor(1,1,0,1)));
            
            // setting our camera position and direction of the camera
            Camera camera = new Camera(new Vector(0,0,-100), new Vector(0,0,0));
            camera.numberOfSamples = 4;
            //camera.numberOfJittered = 4;
            //camera.useDOF(0.2, 5);
     
            // array for multiple shapes
            Shape[] shapes = {sphere1, triangle};

            // array for multiple lights
            Light[] lights = {light1, light2};

            
            Scene scene = new Scene(shapes);


            Bitmap bmp = new Bitmap(camera.width, camera.height);
            camera.Render(scene, bmp, lights);
            pictureBox1.Image = bmp;
            bmp.Save("image.jpeg");
        }

        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
