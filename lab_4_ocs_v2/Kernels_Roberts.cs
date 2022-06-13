using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace lab_4_ocs_v2
{
    public static class Kernels_Roberts
    {
        public static Bitmap Roberts_Filter2(Bitmap bm)
        {
            int iw = bm.Width;
            int ih = bm.Height;
            int r, r0, r1, r2, r3, g, g0, g1, g2, g3, b, b0, b1, b2, b3;
            Bitmap result = new Bitmap(bm);
            
            for (int j = 1; j < ih - 1; j++)
            {
                for (int i = 1; i < iw - 1; i++)
                {
                    r0 = (bm.GetPixel(i, j)).R;
                    r1 = (bm.GetPixel(i, j + 1)).R;
                    r2 = (bm.GetPixel(i + 1, j)).R;
                    r3 = (bm.GetPixel(i + 1, j + 1)).R;

                    r = (int)Math.Sqrt((r0 - r3) * (r0 - r3) + (r1 - r2) * (r1 - r2));
                    g0 = (bm.GetPixel(i, j)).G;
                    g1 = (bm.GetPixel(i, j + 1)).G;
                    g2 = (bm.GetPixel(i + 1, j)).G;
                    g3 = (bm.GetPixel(i + 1, j + 1)).G;
                    g = (int)Math.Sqrt((g0 - g3) * (g0 - g3) + (g1 - g2) * (g1 - g2));
                    b0 = (bm.GetPixel(i, j)).B;
                    b1 = (bm.GetPixel(i, j + 1)).B;
                    b2 = (bm.GetPixel(i + 1, j)).B;
                    b3 = (bm.GetPixel(i + 1, j + 1)).B;
                    b = (int)Math.Sqrt((b0 - b3) * (b0 - b3) + (b1 - b2) * (b1 - b2));
                    if (r < 0)
                    {
                        r = 0;
                    }
                    if (r > 255)
                    {
                        r = 255;
                    }
                    result.SetPixel(i, j, Color.FromArgb(r, r, r));
                }
            }
            return result;
        }

        public static Bitmap Roberts_Filter(this Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = convolution_two_matrix.ConvolutionFilter(sourceBitmap, Kernels_Roberts.Roberts_Horizontal, Kernels_Roberts.Roberts_Vertical, 1.0, 0, grayscale);
            return resultBitmap;
        }

        public static double[,] Roberts_Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0, },
                  {  0, -1, },
                };
            }
        }

        public static double[,] Roberts_Vertical
        {
            get
            {
                return new double[,]
                { {  0, -1, },
                  {  1,  0, },
                };
            }
        }
    }
}
