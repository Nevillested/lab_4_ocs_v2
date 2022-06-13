using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace lab_4_ocs_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_image = Directory.GetCurrentDirectory() + "/data/mechanism.bmp";
            string path_image_binarized = Directory.GetCurrentDirectory() + "/data/binarized_mechanism.bmp";
            Image<Gray, Byte> temp = new Image<Gray, byte>(path_image);
            CvInvoke.Threshold(temp, temp, 200, 256, ThresholdType.Binary);
            temp.Save(path_image_binarized);

            //Canny
            Bitmap mechanism_canny;
            Image<Gray, Byte> cannyimg = new Image<Gray, Byte>(path_image);
            cannyimg = cannyimg.Canny(13, 45);
            mechanism_canny = cannyimg.ToBitmap();
            mechanism_canny.Save("data/bmp_mechanism_canny.bmp");

            //Sobel
            Image mechanism_Sobel = Image.FromFile(path_image_binarized);
            Bitmap bmp_mechanism_Sobel = (Bitmap)mechanism_Sobel;
            bmp_mechanism_Sobel = Kernels_Sobel.Sobel3x3Filter(bmp_mechanism_Sobel,true);
            bmp_mechanism_Sobel.Save("data/bmp_mechanism_Sobel.bmp");

            //Prewitt
            Image mechanism_Prewitt = Image.FromFile(path_image_binarized);
            Bitmap bmp_mechanism_Prewitt = (Bitmap)mechanism_Prewitt;
            bmp_mechanism_Prewitt = Kernels_Prewitt.PrewittFilter(bmp_mechanism_Prewitt, true);
            bmp_mechanism_Prewitt.Save("data/bmp_mechanism_Prewitt.bmp");

            //Scharra
            Image mechanism_Scharra = Image.FromFile(path_image_binarized);
            Bitmap bmp_mechanism_Scharra = (Bitmap)mechanism_Scharra;
            bmp_mechanism_Scharra = Kernels_Scharra.ScharraFilter(bmp_mechanism_Scharra, true);
            bmp_mechanism_Scharra.Save("data/bmp_mechanism_Scharra.bmp");

            //Roberts
            Image mechanism_Roberts = Image.FromFile(path_image_binarized);
            Bitmap bmp_mechanism_Roberts = (Bitmap)mechanism_Roberts;
            bmp_mechanism_Roberts = Kernels_Roberts.Roberts_Filter2(bmp_mechanism_Roberts);
            bmp_mechanism_Roberts.Save("data/bmp_mechanism_Roberts.bmp");

            //Laplacian
            Image mechanism_Laplacian_input = Image.FromFile(path_image);
            Bitmap bmp_mechanism_Laplacian = (Bitmap)mechanism_Laplacian_input;
            OpenCvSharp.Mat mechanism_Laplacian = new OpenCvSharp.Mat(path_image);
            OpenCvSharp.Mat gray_mechanism_Laplacian = mechanism_Laplacian.CvtColor(ColorConversionCodes.BGR2GRAY);
            OpenCvSharp.Size this_size = new OpenCvSharp.Size(15, 15);
            OpenCvSharp.Mat blur_gray_mechanism_Laplacian = Kernels_Laplacian.GaussianBlur(gray_mechanism_Laplacian, this_size, 1d);
            bmp_mechanism_Laplacian = Kernels_Laplacian.Laplacian_Gaussian_Filter(blur_gray_mechanism_Laplacian);
            bmp_mechanism_Laplacian.Save("data/bmp_mechanism_Laplacian.bmp");

            
        }

    }
}
