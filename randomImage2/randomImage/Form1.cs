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
            int width = 1000;    
            int height = 1000;
            Bitmap bmp = new Bitmap(height, width); // creating bitmap
            Random randomNumber = new Random(); //to get random number for ARGB value

            
            for (int j = 0; j < height; j ++) {
                for (int i = 0; i < width; i++) {
                    int r = pixel.GetRedColor(); // getting random number from 0 to 255 
                    int g = pixel.GetGreenColor();
                    int b = pixel.GetBlueColor();
                    int a = pixel.GetAlphaColor();

                    bmp.SetPixel(i,j,Color.FromArgb(a,r,g,b)); //creation of each pixel and filling it with each random argba value
                }
            }

            pictureBox1.Image = bmp; // setting the image into pictureBox1

            bmp.Save("myImage.jpeg"); // it saves the random image 

        }
    }
}
