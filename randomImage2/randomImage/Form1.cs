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
            Vector sphereCenter = new Vector(10,0,0);
            Material material1 = new Material(new SColor(1,0,1,1), 0.5);
            Sphere sphere1 = new Sphere(5, material1, sphereCenter);
          

            // making a sphere by assigning it it's parameters
            Vector sphereCenter1 = new Vector(0, 0, 0);
            Sphere sphere2 = new Sphere(10, new Material(new SColor(1,1,0,1), 0.25), sphereCenter1);

            // making a plane by assigning it it's parameters
            Vector planeNormal = new Vector(0,1,1); // this will give a plane which direction is towards the direction of camera.
            Vector planePoint = new Vector(-100,0,-100);
            Plane  plane1 = new Plane(planeNormal, planePoint, new Material(new SColor(1,1,1,1), 0.15));

            // making a disk by assigning it it's parameters
            Vector diskNormal = new Vector(0,1,1); // plane will be vertical  
            Vector diskCenter = new Vector(0,-50,0);
            double diskRadius = 30;
            Disk disk1 = new Disk(diskNormal, diskCenter, diskRadius, new Material(new SColor(0,0,1,0), 0.29));


            //making a triangle
            Triangle triangle = new Triangle(new Vector(0,0,0), new Vector(0,8,0), new Vector(6,0,0), new Material(new SColor(1,0,0,1), 0.25));

            // making a light i.e. a point light
            Light light = new Light(new Vector(0,300,-300) , 0.75, new SColor(1,1,1,1));

            // making a box by assigning it it's parameters
            Box box1 = new Box(new Vector(-20,-20,-20), new Vector(20,20,20), new Material(new SColor(1,1,1,1), 0.25));
            
            // setting our camera position and direction of the camera
            Camera camera = new Camera(new Vector(0, 0, -100), new Vector(0,0,0));

            Shape[] shapes = {sphere1, sphere2};

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
