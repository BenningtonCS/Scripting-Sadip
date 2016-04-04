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
            Sphere sphere1 = new Sphere(20, material1, sphereCenter);
          

            //SColor sphereColor1 = new SColor(1, 1, 0, 1);
            Vector sphereCenter1 = new Vector(0, 0, 0);
            Sphere sphere2 = new Sphere(20, new Material(new SColor(1,1,0,1), 0.25), sphereCenter1);

            // making a plane by assigning it it's parameters
            Vector planeNormal = new Vector(0,1,1); // this will give a plane which direction is towards the direction of camera.
            Vector planePoint = new Vector(-100,0,-100);
            Plane  plane1 = new Plane(planeNormal, planePoint, new Material(new SColor(1,1,1,1), 0.15));

            // making a disk by assigning it it's parameters
            Vector diskNormal = new Vector(0,1,1); // plane will be vertical  
            Vector diskCenter = new Vector(0,30,30);
            double diskRadius = 60;
            Disk disk1 = new Disk(diskNormal, diskCenter, diskRadius, new Material(new SColor(0,0,1,0), 0.29));


            //making a triangle
            Triangle triangle = new Triangle(new Vector(-100,20,0), new Vector(5,4,10), new Vector(8,2,10), new Material(new SColor(1,1,1,1), 0.25));

            // making a light i.e. a point light
            Light light = new Light(new Vector(0,400,300) , 0.75, new SColor(1,1,1,1));

            // making a box by assigning it it's parameters
            Box box1 = new Box(new Vector(100,0,0), new Vector(200,90,0), new Material(new SColor(1,1,1,1), 0.25));
            
            // setting our camera position and direction of the camera
            Camera camera = new Camera(new Vector(0, 0, 150), new Vector(0,0,0));

            Shape[] shapes = {sphere2};

            Scene scene = new Scene(shapes);

            Bitmap bmp = new Bitmap(camera.width, camera.height);
            camera.Render(scene, bmp, light);
            pictureBox1.Image = bmp;
            bmp.Save("image.jpeg");
        }

        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
