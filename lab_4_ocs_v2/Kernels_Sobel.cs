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
    public static class Kernels_Sobel
    {
        public static Bitmap Sobel3x3Filter(this Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = convolution_two_matrix.ConvolutionFilter(sourceBitmap, Kernels_Sobel.Sobel_X, Kernels_Sobel.Sobel_Y, 1.0, 0, grayscale);
            return resultBitmap;
        }

        public static double[,] Sobel_X
        {
            get
            {
                return new double[,]
                {  { -1,  0,  1, },
                   { -2,  0,  2, },
                   { -1,  0,  1, },
                };
            }
        }

        public static double[,] Sobel_Y
        {
            get
            {
                return new double[,]
                { {  1,  2,  1, },
                  {  0,  0,  0, },
                  { -1, -2, -1, },
                };
            }
        }

    }
}
