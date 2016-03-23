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
            /* SColor color = new SColor(0.2,0,.5,1);
             Vector center = new Vector(0,20,0);
             Sphere sphere1 = new Sphere(60, color, center);*/

            // making a plane by assigning it it's parameters
            /*SColor color = new SColor(1,0,1,1);
            Vector normal = new Vector(0,0,1); // this will give a plane which direction is towards the direction of camera.
            Vector point = new Vector(0,0,0);
            Plane plane1 = new Plane(normal, point, color);*/

            // making a disk by assigning it it's parameters
            SColor color = new SColor(1,1,0,1);
            Vector normal = new Vector(0,0,1); // plane will be vertical  
            Vector center = new Vector(100,0,0);
            double radius = 30;
            Disk disk1 = new Disk(normal, center, radius, color);
            
            // setting our camera position and direction of the camera
            Camera camera = new Camera(new Vector(0, 0, 50), new Vector(0, 0, -1));

            // calling scene class for creating a sphere1
            Scene scene = new Scene(disk1);

            // calling scene class for creating a plane1
            //Scene scene = new Scene(plane1);

            // callling scene class for creating a disk
           // Scene scene = new Disk(disk1);

            Bitmap bmp = new Bitmap(camera.width, camera.height);
            camera.Render(scene, bmp);
            pictureBox1.Image = bmp;
            bmp.Save("image.jpeg");
        }

        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
