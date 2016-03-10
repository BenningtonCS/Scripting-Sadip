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
            Vector firstVector = new Vector(1, 1, 1);
            Vector secondVector = new Vector(1, 1, 1);
            Vector add = firstVector + secondVector;
            Vector sub = firstVector - secondVector;
            double dot = firstVector * secondVector;
            Vector cross = firstVector % secondVector;
            Console.WriteLine(add.ToString());//, sub, dot, cross);

            SColor newColor = new SColor(1,1,0,1);
            MakePic(newColor);
    
        }

        private void MakePic(SColor pixel) {
            //double width = 40;    
            //double height = 40;
            Vector point = Camera.position + Ray.direction * Ray.findingT();
            Bitmap bmp = new Bitmap((int)(Camera.height), (int) (Camera.width)); // creating bitmap
            Random randomNumber = new Random(); //to get random number for ARGB value
            double j = Camera.position.y + Camera.height / 2 - .5;
            double i = Camera.position.x + Camera.width / 2  - .5;   
            for (j =  0; j <= Camera.height; j ++) {
                for (i = 0; i <= Camera.width; i++) {
                    int r = pixel.GetRedColor(); // getting random number from 0 to 255 
                    int g = pixel.GetGreenColor();
                    int b = pixel.GetBlueColor();
                    int a = pixel.GetAlphaColor();

                    
                    if (Math.Abs((point - Sphere.center) * (point - Sphere.center)) < Math.Pow(Sphere.radius, 2)) {
                        bmp.SetPixel((int) i, (int) j, Color.FromArgb(r, g, b, a)); //coloring each pixel where x^2 + y^2 <= r^2 works. But it colors pixel of only circumference.
                    }
                       
                    
                }
            }

            pictureBox1.Image = bmp; // setting the image into pictureBox1

            bmp.Save("myImage.jpeg"); // it saves the random image 

        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
