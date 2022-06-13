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
using Emgu.CV.Structure;

namespace lab_4_ocs_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_image = Directory.GetCurrentDirectory();
            path_image = path_image + "/data/cat.bmp";

            //Canny
            Bitmap cat_canny;
            Image<Gray, Byte> cannyimg = new Image<Gray, Byte>(path_image);
            cannyimg = cannyimg.Canny(13, 45);
            cat_canny = cannyimg.ToBitmap();
            cat_canny.Save("data/bmp_cat_canny.bmp");

            //Sobel
            Image cat_Sobel = Image.FromFile(path_image);
            Bitmap bmp_cat_Sobel = (Bitmap)cat_Sobel;
            bmp_cat_Sobel = Kernels_Sobel.Sobel3x3Filter(bmp_cat_Sobel,true);
            bmp_cat_Sobel.Save("data/bmp_cat_Sobel.bmp");

            //Prewitt
            Image cat_Prewitt = Image.FromFile(path_image);
            Bitmap bmp_cat_Prewitt = (Bitmap)cat_Prewitt;
            bmp_cat_Prewitt = Kernels_Prewitt.PrewittFilter(bmp_cat_Prewitt, true);
            bmp_cat_Prewitt.Save("data/bmp_cat_Prewitt.bmp");

            //Scharra
            Image cat_Scharra = Image.FromFile(path_image);
            Bitmap bmp_cat_Scharra = (Bitmap)cat_Scharra;
            bmp_cat_Scharra = Kernels_Scharra.ScharraFilter(bmp_cat_Scharra, true);
            bmp_cat_Scharra.Save("data/bmp_cat_Scharra.bmp");

            //Roberts
            Image cat_Roberts = Image.FromFile(path_image);
            Bitmap bmp_cat_Roberts = (Bitmap)cat_Roberts;
            bmp_cat_Roberts = Kernels_Roberts.Roberts_Filter2(bmp_cat_Roberts);
            bmp_cat_Roberts.Save("data/bmp_cat_Roberts.bmp");

            //Laplacian
            Image cat_Laplacian_input = Image.FromFile(path_image);
            Bitmap bmp_cat_Laplacian = (Bitmap)cat_Laplacian_input;
            OpenCvSharp.Mat cat_Laplacian = new OpenCvSharp.Mat(path_image);
            OpenCvSharp.Mat gray_cat_Laplacian = cat_Laplacian.CvtColor(ColorConversionCodes.BGR2GRAY);
            OpenCvSharp.Size new_size = new OpenCvSharp.Size(15, 15);
            OpenCvSharp.Mat blur_gray_cat_Laplacian = Kernels_Laplacian.GaussianBlur(gray_cat_Laplacian, new_size, 1d);
            bmp_cat_Laplacian = Kernels_Laplacian.Laplacian_Gaussian_Filter(blur_gray_cat_Laplacian);
            bmp_cat_Laplacian.Save("data/bmp_cat_Laplacian.bmp");




        }

    }
}
