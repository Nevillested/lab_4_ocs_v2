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
    public static class Kernels_Prewitt
    {
        public static Bitmap PrewittFilter(this Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = convolution_two_matrix.ConvolutionFilter(sourceBitmap, Kernels_Prewitt.Prewitt3x3Horizontal, Kernels_Prewitt.Prewitt3x3Vertical, 1.0, 0, grayscale);
            return resultBitmap;
        }

        public static double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -1,  0,  1, },
                  { -1,  0,  1, },
                };
            }
        }

        public static double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, },
                };
            }
        }
    }
}
