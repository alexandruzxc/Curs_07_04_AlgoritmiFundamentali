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

        private void FilterBanalExample_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = Ts.R;
                    int g = 55;
                    int b = 55;
                    Td = Color.FromArgb(r, g, b);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void myVersion_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int a = Ts.A;
                    int r = Ts.R;
                    int g = Ts.G;
                    int b = Ts.B;
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }
                    //bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    Td = Color.FromArgb(a, r, g, b);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnComplement_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = 255 - Ts.R;
                    int g = 255 - Ts.G;
                    int b = 255 - Ts.B;
                    Td = Color.FromArgb(r, g, b);
                    destination.SetPixel(i, j, Td);
                    Color t = Color.Cyan;
                }
            }
            pictureBox2.Image = destination;
        }

        private void BtnCyan_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = 0;
                    int g = 0;
                    int b = Ts.B;
                    Td = Color.FromArgb(r, g, b);
                    destination.SetPixel(i, j, Td);
                    Color t = Color.Cyan;
                }
            }
            pictureBox2.Image = destination;
        }

        private void button1_Click(object sender, EventArgs e)
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
                    if (r > 60 && r < 160)
                        Td = Color.FromArgb(r, 0, 0);
                    else
                        Td = Color.FromArgb(255, 255, 255);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void myFilterV2_Click(object sender, EventArgs e)
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
                    if (g > 60 && g < 160)
                        Td = Color.FromArgb(0, g, 0);
                    else
                        Td = Color.FromArgb(255, 255, 0);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void myFilterV3_Click(object sender, EventArgs e)
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
                    if (b > 60 && b < 160)
                        Td = Color.FromArgb(0, 0, b);
                    else
                        Td = Color.FromArgb(255, 255, 255);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td = Color.Black;
                    int r = Ts.R;
                    int g = Ts.G;
                    int b = Ts.B;
                   if (r >= g && r >= b)
                        Td = Color.FromArgb(200, 0, 0);
                   if (g >= b && g >= r)
                        Td = Color.FromArgb(0, 200, 0);
                    if (b >= r && b >= g)
                        Td = Color.FromArgb(255, 200, 0);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }
        private void btnFirstGradiant_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    int r = min((Ts.R + j), 255);
                    int g = min((Ts.G + j), 255);
                    int b = min((Ts.B + j), 255);
                    Td = Color.FromArgb(r, g, b);
                    destination.SetPixel(i, j, Td);
                }
            }
            pictureBox2.Image = destination;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int k = 5;
            Color bs = Color.Black;
            for (int i = 0; i < source.Width; i+= k)
            {
                for (int j = 0; j < source.Height; j += k)
                {
                    Color Ts = source.GetPixel(i, j);
                    Color Td;
                    for (int l = 0; l < k; l++)
                    {
                        for (int m = 0; m < k; m++)
                        {
                            destination.SetPixel((i + l) % source.Width, (j + m) % source.Height, Ts);
                        }
                    }                                     
                }
            }
            pictureBox2.Image = destination;
        }
    }
}
