using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Drawing;
using Emgu.CV;
using OpenCvSharp.Extensions;

namespace lab_4_ocs_v2
{
    public static class Kernels_Laplacian
    {
        public static OpenCvSharp.Mat GaussianBlur(OpenCvSharp.Mat src, OpenCvSharp.Size ksize, double sigmaX, double sigmaY = 0, BorderTypes borderType = BorderTypes.Default)
        {
            var dst = new OpenCvSharp.Mat();
            Cv2.GaussianBlur(src, dst, ksize, sigmaX, sigmaY, borderType);
            return dst;
        }

        public static Bitmap Laplacian_Gaussian_Filter(this OpenCvSharp.Mat source_mat)
        {
            Bitmap resultBitmap = convolution_one_matrix.ConvolutionFilter(source_mat.ToBitmap(), Kernels_Laplacian.Laplacian, 1.0, 0, false);
            
            return resultBitmap;
        }

        public static double[,] Laplacian
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, },
                  { -1,  8, -1, },
                  { -1, -1, -1, },
                };
            }
        }
    }
}
