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
    public static class Kernels_Scharra
    {
        public static Bitmap ScharraFilter(this Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = convolution_two_matrix.ConvolutionFilter(sourceBitmap, Kernels_Scharra.Scharr_X, Kernels_Scharra.Scharr_Y, 1.0, 0, grayscale);
            return resultBitmap;
        }

        public static double[,] Scharr_X
        {
            get
            {
                return new double[,]
                {  { -3,   0,  3,  },
                   { -10,  0,  10, },
                   { -3,   0,  3,  },
                };
            }
        }

        public static double[,] Scharr_Y
        {
            get
            {
                return new double[,]
                { {  -3,  -10,  -3, },
                  {   0,    0,   0, },
                  {   3,   10,   3, },
                };
            }
        }
    }
}
