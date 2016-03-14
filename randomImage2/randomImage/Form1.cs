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
            SColor color = new SColor(0,0,1,1);
            Vector center = new Vector(0,0,0);
            Sphere sphere1 = new Sphere(30, color, center);
            Camera camera = new Camera(new Vector(0, 0, 50), new Vector(0, 0, -1));
            Scene scene = new Scene(sphere1);

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
