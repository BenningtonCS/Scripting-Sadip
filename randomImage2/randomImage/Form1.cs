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
             SColor sphereColor = new SColor(0.2,0,.5,1);
             Vector sphereCenter = new Vector(0,20,0);
             Sphere sphere1 = new Sphere(60, sphereColor, sphereCenter);

            // making a plane by assigning it it's parameters
            SColor planeColor = new SColor(1,0,1,1);
            Vector planeNormal = new Vector(0,0,1); // this will give a plane which direction is towards the direction of camera.
            Vector planePoint = new Vector(0,0,0);
            Plane  plane1 = new Plane(planeNormal, planePoint, planeColor);

            // making a disk by assigning it it's parameters
            SColor diskColor = new SColor(1,1,0,1);
            Vector diskNormal = new Vector(0,0,1); // plane will be vertical  
            Vector diskCenter = new Vector(100,0,0);
            double diskRadius = 30;
            Disk disk1 = new Disk(diskNormal, diskCenter, diskRadius, diskColor);
            
            // setting our camera position and direction of the camera
            Camera camera = new Camera(new Vector(0, 0, 50), new Vector(0, 0, -1));

            // calling scene class for creating a sphere1
            //Scene scene1 = new Scene(sphere1);

            // calling scene class for creating a plane1
            //Scene scene2 = new Scene(plane1);

            // callling scene class for creating a disk
            //Scene scene3 = new Scene(disk1);

            Shape[] shapes = {sphere1, plane1, disk1};

            Bitmap bmp = new Bitmap(camera.width, camera.height);
            camera.Render(scene1, bmp);
            pictureBox1.Image = bmp;
            bmp.Save("image.jpeg");
        }

        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
