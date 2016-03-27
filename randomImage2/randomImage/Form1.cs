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
            SColor sphereColor = new SColor(1,1,0,1);
            Vector sphereCenter = new Vector(0,0,-110);
            Sphere sphere1 = new Sphere(100, sphereColor, sphereCenter);
            Material Material1 = new Material(0.1);

            SColor sphereColor1 = new SColor(1, 1, 1, 1);
            Vector sphereCenter1 = new Vector(0, 0, 0);
            Sphere sphere2 = new Sphere(50, sphereColor1, sphereCenter1);

            // making a plane by assigning it it's parameters
            SColor planeColor = new SColor(.5,1,.5,1);
            Vector planeNormal = new Vector(0,1,1); // this will give a plane which direction is towards the direction of camera.
            Vector planePoint = new Vector(0,0,-100);
            Plane  plane1 = new Plane(planeNormal, planePoint, planeColor);

            // making a disk by assigning it it's parameters
            SColor diskColor = new SColor(.5,0.5,0.5,0.5);
            Vector diskNormal = new Vector(0,1,0.5); // plane will be vertical  
            Vector diskCenter = new Vector(0,0,0);
            double diskRadius = 100;
            Disk disk1 = new Disk(diskNormal, diskCenter, diskRadius, diskColor);

            // making a light
            Light light = new Light(new Vector(0,0,100) , new SColor(1,1,0,1));

            // making a box by assigning it it's parameters
            Box box1 = new Box(new Vector(-100,200,100), new Vector(100,400,-100), new SColor(1,0,1,1));
            
            // setting our camera position and direction of the camera
            Camera camera = new Camera(new Vector(10, 10, 500), new Vector(0, 0, -1));

            Shape[] shapes = {box1};

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
