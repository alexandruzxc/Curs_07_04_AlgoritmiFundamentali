using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_07_04_AlgoritmiFundamentali
{
    //create windowsformapp
    public partial class Form1 : Form
    {
        Bitmap source;
        Bitmap destination;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string d = @"../../Resurse/Test.jpg";
            //MessageBox.Show(d);
            source = new Bitmap(Image.FromFile(@"../../Test.jpg"));
            destination = new Bitmap(source.Width, source.Height);
            pictureBox1.Image = source;

        }

        private void btnDirect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = Ts.R;
                    int g = Ts.G;
                    int b = Ts.B;
                    Td = Color.FromArgb(r, g, b);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnGrayScalle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = Ts.R;
                    int g = Ts.G;
                    int b = Ts.B;
                    int t = (r + g + b) / 3;
                    Td = Color.FromArgb(t, t, t);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnBlackAndWhite_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = Ts.R;
                    int g = Ts.G;
                    int b = Ts.B;
                    int t = (r + g + b) / 3;
                    if (t < 128)
                        Td = Color.FromArgb(0, 0, 0);
                    else
                        Td = Color.FromArgb(255, 255, 255);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnUnknowName_Click(object sender, EventArgs e)
        {
            int k = 50;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = (Ts.R + k) % 256;
                    int g = (Ts.G + k) % 256;
                    int b = (Ts.B + k) % 256;
                    Td = Color.FromArgb(r, g, b);
                    
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;         
        }
        public int min(int a, int b)
        {
            if (a > b)
                return b;
            else 
                return a; // a<b:a?b
        }
        public int max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        public Color mA(Color A, Color B)
        {
            Color tor;
            int r, g, b;
            r = (A.R + B.R) / 2;
            g = (A.G + B.G) / 2;
            b = (A.B + B.B) / 2;
            tor = Color.FromArgb(r, g, b);
            return tor;
            //media aritmetica a 2 pixel
        }
        public Color mG(Color A, Color B)
        {
            Color tor;
            int r, g, b;
            
            r = (int)Math.Sqrt(A.R * B.R);
            g = (int)Math.Sqrt(A.G * B.G);
            b = (int)Math.Sqrt(A.B * B.B);
            tor = Color.FromArgb(r, g, b);
            return tor;
            //media geometrica a 2 pixel
        }
        private void btnUnknowNameV2_Click(object sender, EventArgs e)
        {
            int k = 20;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = min(Ts.R + k, 255);
                    int g = min(Ts.G + k, 255);
                    int b = min(Ts.B + k, 255);
                    Td = Color.FromArgb(r, g, b);

                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnDarkness_Click(object sender, EventArgs e)
        {
            int k = 20;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = max(Ts.R - k, 0);
                    int g = max(Ts.G - k, 0);
                    int b = max(Ts.B - k, 0);
                    Td = Color.FromArgb(r, g, b);

                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            int k = 20;
            int t;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = Ts.R;
                    int g = Ts.G;
                    int b = Ts.B;
                    t = (r + g + b) / 3;
                    if ( t < 128)
                    {
                         r = max(Ts.R - k, 0);
                         g = max(Ts.G - k, 0);
                         b = max(Ts.B - k, 0);
                    }
                    else
                    {
                         r = min(Ts.R + k, 255);
                         g = min(Ts.G + k, 255);
                         b = min(Ts.B + k, 255);
                    }
                    Td = Color.FromArgb(r, g, b);

                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            destination = new Bitmap(2 * source.Width - 1, 2 * source.Height - 1);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    destination.SetPixel(i * 2, j * 2, source.GetPixel(i, j));
                }
            }
            for (int i = 0; i < 2 * source.Width - 1; i += 2)
            {
                for (int j = 1; j < 2 * source.Height - 1; j += 2)
                {
                    Color t1 = destination.GetPixel(i, j - 1);
                    Color t2 = destination.GetPixel(i, j + 1);
                    Color t3 = mA(t1, t2);
                    destination.SetPixel(i, j, t3); 
                }
            }
            for (int i = 1; i < 2 * source.Width - 1; i += 2)
            {
                for (int j = 0; j < 2 * source.Height - 1; j++)
                {
                    Color t1 = destination.GetPixel(i - 1 , j);
                    Color t2 = destination.GetPixel(i + 1 , j);
                    Color t3 = mA(t1, t2);
                    destination.SetPixel(i, j, t3);                  
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnZoomV1_Click(object sender, EventArgs e)
        {
            destination = new Bitmap(2 * source.Width - 1, 2 * source.Height - 1);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    destination.SetPixel(i * 2, j * 2, source.GetPixel(i, j));
                }
            }
            for (int i = 0; i < 2 * source.Width - 1; i += 2)
            {
                for (int j = 1; j < 2 * source.Height - 1; j += 2)
                {
                    Color t1 = destination.GetPixel(i, j - 1);
                    Color t2 = destination.GetPixel(i, j + 1);
                    Color t3 = mA(t1, t2);
                    destination.SetPixel(i, j, t3);
                }
            }
            for (int i = 1; i < 2 * source.Width - 1; i += 2)
            {
                for (int j = 0; j < 2 * source.Height - 1; j++)
                {
                    Color t1 = destination.GetPixel(i - 1, j);
                    Color t2 = destination.GetPixel(i + 1, j);
                    Color t3 = mG(t1, t2);
                    destination.SetPixel(i, j, t3);
                }
            }
            pictureBox2.Image = destination;

        }
    }
}
