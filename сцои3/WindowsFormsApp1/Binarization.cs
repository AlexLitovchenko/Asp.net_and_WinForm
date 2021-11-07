using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Gavrilov
    {
        //1 - пограничный белый, 2 - черный
        public static (Image bmp, double time) Binarization(Image image, int Color = 0)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            Bitmap bmp = new Bitmap(image);

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            float[] I_pixel = new float[rgb.Length / 3];
            Parallel.For(0, rgb.Length / 3, i =>
            {
                I_pixel[i] = 0.2125f * rgb[i * 3] + 0.7154f * rgb[i * 3 + 1] + 0.0721f * rgb[i * 3 + 2];
            });

            float I_sum = I_pixel.Sum();
            float t = I_sum / (bmp.Width * bmp.Height);

            //выбор изменения пограничного пикселя <= t или < t
            switch (Color)
            {
                case 0:
                    //формируем выходное изображение
                    Parallel.For(0, rgb.Length / 3, i =>
                    {
                        if (I_pixel[i] <= t)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
                case 255:
                    //формируем выходное изображение
                    Parallel.For(0, rgb.Length / 3, i =>
                    {
                        if (I_pixel[i] < t)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }
    }

    public class Otsu
    {
        //1 - пограничный белый, 2 - черный
        public static (Image bmp, double time) Binarization(Image image, int Color = 0)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            Bitmap bmp = new Bitmap(image);

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            //строим гистограмму
            int[] n = new int[256];
            float[] I_pixel = new float[rgb.Length / 3];
            Parallel.For(0, rgb.Length / 3, i =>
            {
                I_pixel[i] = 0.2125f * rgb[i * 3] + 0.7154f * rgb[i * 3 + 1] + 0.0721f * rgb[i * 3 + 2];
                Interlocked.Increment(ref n[(int)((double)((int)rgb[i * 3] + (int)rgb[i * 3 + 1] + (int)rgb[i * 3 + 2]) / 3.0)]);
            });

            int wh = bmp.Width * bmp.Height;
            double[] N = new double[256];
            double mt = 0;
            for (int i = 0; i < 256; ++i)
            {
                N[i] = n[i] / (double)wh;
                mt += i * N[i];
            }

            double ob = 0;
            int T = 0;
            for (int t = 0; t < 256; ++t)
            {
                double w1 = 0;
                for (int i = 0; i < t; ++i) w1 += N[i];

                double w2 = 1.0 - w1;

                double m1 = 0;
                for (int i = 0; i < t; i++) m1 += i * N[i];
                m1 = m1 / w1;

                double m2 = (mt - m1 * w1) / w2;

                double m = m1 - m2;

                double ob_ = w1 * w2 * m * m;
                if (ob_ > ob)
                {
                    ob = ob_;
                    T = t;
                }
            }

            //выбор изменения пограничного пикселя <= t или < t
            switch (Color)
            {
                case 0:
                    //формируем выходное изображение
                    Parallel.For(0, rgb.Length / 3, i =>
                    {
                        if (I_pixel[i] <= T)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
                case 255:
                    //формируем выходное изображение
                    Parallel.For(0, rgb.Length / 3, i =>
                    {
                        if (I_pixel[i] < T)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }
    }

    public class Nibleck
    {
        //1 - пограничный белый, 2 - черный
        public static (Image bmp, double time) Binarization(Image image, int a, double k, int Color = 0)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            Bitmap bmp = new Bitmap(image);
            int width = bmp.Width;
            int height = bmp.Height; // +1 ограничение <

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            //получаем интегральную матрицу, а также изображение в градиентах серого
            (double[,] matrix, double[,] square, double[] I) = GetIntegralMatrix(rgb, width, height);

            //шаг в сторону от центра
            int h = (a - 1) / 2;

            //выбор изменения пограничного пикселя <= t или < t
            switch (Color)
            {
                case 0:
                    //в параллельном режиме пробегаем по каждой строке и редачим пиксели
                    Parallel.For(0, height, i =>
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            //комбинация позиций для вычисления Sum(P)
                            int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                            int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                            int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                            int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                            //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                            double M = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1));

                            //вычисляем дисперсию D[X] = M[X^2] - (M[X])^2
                            //M[X^2] = [ Square(x2, y2) + Square(x1 - 1, y1 - 1) - Square(x1 - 1, y2) - Square(x2, y1 - 1) ] / размер окна
                            //(M[X])^2 = Sum(P) * Sum(P)
                            double D = (square[i_2, j_2] - square[i_1, j_2] - square[i_2, j_1] + square[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) - M * M;

                            //t = M + k * o
                            //страндартное отклонение o = sqrt(D[X])
                            double t = M + k * Math.Sqrt(D);

                            int pos = (i * width + j);
                            if (I[pos] <= t)
                            {
                                rgb[pos * 3] = 0;
                                rgb[pos * 3 + 1] = 0;
                                rgb[pos * 3 + 2] = 0;
                            }
                            else
                            {
                                rgb[pos * 3] = 255;
                                rgb[pos * 3 + 1] = 255;
                                rgb[pos * 3 + 2] = 255;
                            }
                        }
                    });
                    break;
                case 255:
                    //в параллельном режиме пробегаем по каждой строке и редачим пиксели
                    Parallel.For(0, height, i =>
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            //комбинация позиций для вычисления Sum(P)
                            int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                            int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                            int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                            int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                            //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                            double M = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1));

                            //вычисляем дисперсию D[X] = M[X^2] - (M[X])^2
                            //M[X^2] = [ Square(x2, y2) + Square(x1 - 1, y1 - 1) - Square(x1 - 1, y2) - Square(x2, y1 - 1) ] / размер окна
                            //(M[X])^2 = Sum(P) * Sum(P)
                            double D = (square[i_2, j_2] - square[i_1, j_2] - square[i_2, j_1] + square[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) - M * M;

                            //t = M + k * o
                            //страндартное отклонение o = sqrt(D[X])
                            double t = M + k * Math.Sqrt(D);

                            int pos = (i * width + j);
                            if (I[pos] < t)
                            {
                                rgb[pos * 3] = 0;
                                rgb[pos * 3 + 1] = 0;
                                rgb[pos * 3 + 2] = 0;
                            }
                            else
                            {
                                rgb[pos * 3] = 255;
                                rgb[pos * 3 + 1] = 255;
                                rgb[pos * 3 + 2] = 255;
                            }
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }

        //составляем интегральную матрицу
        private static (double[,], double[,], double[]) GetIntegralMatrix(byte[] rgb, int width, int heigth)
        {
            double[,] matrix = new double[heigth, width];
            double[,] square = new double[heigth, width];
            double[] I = new double[width * heigth];

            //интегральная матрица строится по формуле  
            //S(i, j) = I(i, j) + S(i - 1, j) + S(i, j - 1) - S(i - 1, j - 1)
            //где I = 0.2125R + 0.7154G + 0.0721B,
            for (int i = 0; i < heigth; ++i)
            {
                for (int j = 0; j < width; j++)
                {
                    //позиция пикселя в одномерном массиве
                    int pos = i * width + j;
                    //позиция пикселя в одномерном массиве, учитывая rgb
                    int p = pos * 3;
                    I[pos] = 0.2125 * rgb[p] + 0.7154 * rgb[p + 1] + 0.0721 * rgb[p + 2];
                    //квадрат величины I[pos] для вычисления дисперсии в последующем
                    double I2 = I[pos] * I[pos];

                    //S(i - 1, j)
                    double m1 = 0, s1 = 0;
                    if (i - 1 >= 0)
                    {
                        m1 = matrix[i - 1, j];
                        s1 = square[i - 1, j];
                    }

                    //S((i, j - 1)
                    double m2 = 0, s2 = 0;
                    if (j - 1 >= 0)
                    {
                        m2 = matrix[i, j - 1];
                        s2 = square[i, j - 1];
                    }

                    //S(i - 1, j - 1)
                    double m3 = 0, s3 = 0;
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        m3 = matrix[i - 1, j - 1];
                        s3 = square[i - 1, j - 1];
                    }

                    matrix[i, j] = I[pos] + m1 + m2 - m3;
                    square[i, j] = I2 + s1 + s2 - s3;
                }
            }

            //возвращаем интегральную матрицу
            return (matrix, square, I);
        }
    }

    public class Sauwolas
    {
        public static double min { get; } = 0.2;
        public static double max { get; } = 0.5;
        //1 - пограничный белый, 2 - черный
        public static (Image bmp, double time) Binarization(Image image, int a, double k, int Color = 0)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            //ограничения на k
            if (k > max) k = max;
            if (k < min) k = min;

            Bitmap bmp = new Bitmap(image);
            int width = bmp.Width;
            int height = bmp.Height; // +1 ограничение <

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            //получаем интегральную матрицу, а также изображение в градиентах серого
            (double[,] matrix, double[,] square, double[] I) = GetIntegralMatrix(rgb, width, height);

            //шаг в сторону от центра
            int h = (a - 1) / 2;

            //выбор изменения пограничного пикселя <= t или < t
            switch (Color)
            {
                case 0:
                    //в параллельном режиме пробегаем по каждой строке и редачим пиксели
                    Parallel.For(0, height, i =>
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            //комбинация позиций для вычисления Sum(P)
                            int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                            int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                            int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                            int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                            //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                            double M = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1));

                            //вычисляем дисперсию D[X] = M[X^2] - (M[X])^2
                            //M[X^2] = [ Square(x2, y2) + Square(x1 - 1, y1 - 1) - Square(x1 - 1, y2) - Square(x2, y1 - 1) ] / размер окна
                            //(M[X])^2 = Sum(P) * Sum(P)
                            double D = (square[i_2, j_2] - square[i_1, j_2] - square[i_2, j_1] + square[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) - M * M;

                            //t = M * [1 + k * (o / R - 1)]
                            //страндартное отклонение o = sqrt(D[X])
                            //R = 128
                            double t = M * (1 + k * (Math.Sqrt(D) / 128.0 - 1.0));

                            int pos = (i * width + j);
                            if (I[pos] <= t)
                            {
                                rgb[pos * 3] = 0;
                                rgb[pos * 3 + 1] = 0;
                                rgb[pos * 3 + 2] = 0;
                            }
                            else
                            {
                                rgb[pos * 3] = 255;
                                rgb[pos * 3 + 1] = 255;
                                rgb[pos * 3 + 2] = 255;
                            }
                        }
                    });
                    break;
                case 255:
                    //в параллельном режиме пробегаем по каждой строке и редачим пиксели
                    Parallel.For(0, height, i =>
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            //комбинация позиций для вычисления Sum(P)
                            int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                            int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                            int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                            int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                            //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                            double M = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1));

                            //вычисляем дисперсию D[X] = M[X^2] - (M[X])^2
                            //M[X^2] = [ Square(x2, y2) + Square(x1 - 1, y1 - 1) - Square(x1 - 1, y2) - Square(x2, y1 - 1) ] / размер окна
                            //(M[X])^2 = Sum(P) * Sum(P)
                            double D = (square[i_2, j_2] - square[i_1, j_2] - square[i_2, j_1] + square[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) - M * M;

                            //t = M * [1 + k * (o / R - 1)]
                            //страндартное отклонение o = sqrt(D[X])
                            //R = 128
                            double t = M * (1 + k * (Math.Sqrt(D) / 128.0 - 1.0));

                            int pos = (i * width + j);
                            if (I[pos] < t)
                            {
                                rgb[pos * 3] = 0;
                                rgb[pos * 3 + 1] = 0;
                                rgb[pos * 3 + 2] = 0;
                            }
                            else
                            {
                                rgb[pos * 3] = 255;
                                rgb[pos * 3 + 1] = 255;
                                rgb[pos * 3 + 2] = 255;
                            }
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }

        //составляем интегральную матрицу
        private static (double[,], double[,], double[]) GetIntegralMatrix(byte[] rgb, int width, int heigth)
        {
            double[,] matrix = new double[heigth, width];
            double[,] square = new double[heigth, width];
            double[] I = new double[width * heigth];

            //интегральная матрица строится по формуле  
            //S(i, j) = I(i, j) + S(i - 1, j) + S(i, j - 1) - S(i - 1, j - 1)
            //где I = 0.2125R + 0.7154G + 0.0721B,
            for (int i = 0; i < heigth; ++i)
            {
                for (int j = 0; j < width; j++)
                {
                    //позиция пикселя в одномерном массиве
                    int pos = i * width + j;
                    //позиция пикселя в одномерном массиве, учитывая rgb
                    int p = pos * 3;
                    I[pos] = 0.2125 * rgb[p] + 0.7154 * rgb[p + 1] + 0.0721 * rgb[p + 2];
                    //квадрат величины I[pos] для вычисления дисперсии в последующем
                    double I2 = I[pos] * I[pos];

                    //S(i - 1, j)
                    double m1 = 0, s1 = 0;
                    if (i - 1 >= 0)
                    {
                        m1 = matrix[i - 1, j];
                        s1 = square[i - 1, j];
                    }

                    //S((i, j - 1)
                    double m2 = 0, s2 = 0;
                    if (j - 1 >= 0)
                    {
                        m2 = matrix[i, j - 1];
                        s2 = square[i, j - 1];
                    }

                    //S(i - 1, j - 1)
                    double m3 = 0, s3 = 0;
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        m3 = matrix[i - 1, j - 1];
                        s3 = square[i - 1, j - 1];
                    }

                    matrix[i, j] = I[pos] + m1 + m2 - m3;
                    square[i, j] = I2 + s1 + s2 - s3;
                }
            }

            //возвращаем интегральную матрицу
            return (matrix, square, I);
        }
    }

    public class ChristianWolfe
    {
        public static double min { get; } = 0;
        public static double max { get; } = 1;
        //1 - пограничный белый, 2 - черный
        public static (Image bmp, double time) Binarization(Image image, int a, double k, int color = 0)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            //ограничения на k
            if (k > max) k = max;
            if (k < min) k = min;

            Bitmap bmp = new Bitmap(image);
            int height = bmp.Height;
            int width = bmp.Width;

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            //получаем интегральную матрицу, а также изображение в градиентах серого
            (double[,] matrix, double[,] square, double[] I) = GetIntegralMatrix(rgb, width, height);
            //самый тусклый пиксель изображения m = min(I)
            double m = I.Min();
            //максимальное стандартное отклонение по всем окнам изображения


            //шаг в сторону от центра
            int h = (a - 1) / 2;

            //массив мат ожиданий
            double[] M = new double[width * height];
            //массив средних стандартных отклонений o = sqrt(D)
            double[] o = new double[width * height];
            //максимальное стандартное отклонение по всем окнам R = max(o)
            double R = 0;

            //бежим по картинки и заполняем наши массивы
            int index = 0;
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    //комбинация позиций для вычисления Sum(P)
                    int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                    int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                    int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                    int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                    //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                    M[index] = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1));

                    //вычисляем дисперсию D[X] = M[X^2] - (M[X])^2
                    //M[X^2] = [ Square(x2, y2) + Square(x1 - 1, y1 - 1) - Square(x1 - 1, y2) - Square(x2, y1 - 1) ] / размер окна
                    //(M[X])^2 = Sum(P) * Sum(P)
                    double D = (square[i_2, j_2] - square[i_1, j_2] - square[i_2, j_1] + square[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) - M[index] * M[index];

                    //страндартное отклонение o = sqrt(D[X])
                    o[index] = Math.Sqrt(D);
                    if (o[index] > R) R = o[index];

                    //увеличиваем счетчик массива
                    ++index;
                }
            }

            //выбор изменения пограничного пикселя <= t или < t
            switch (color)
            {
                case 0:
                    Parallel.For(0, width * height, i =>
                    {
                        //t = (1 - k) * M[i] + k * m + k * o[i] / R * (M[i] - m)
                        //m = min(I), R = max(o)
                        double t = (1.0 - k) * M[i] + k * m + k * o[i] / R * (M[i] - m);

                        if (I[i] <= t)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
                case 255:
                    Parallel.For(0, width * height, i =>
                    {
                        //t = (1 - k) * M[i] + k * m + k * o[i] / R * (M[i] - m)
                        //m = min(I), R = max(o)
                        double t = (1.0 - k) * M[i] + k * m + k * o[i] / R * (M[i] - m);

                        if (I[i] < t)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }

        //составляем интегральную матрицу
        private static (double[,], double[,], double[]) GetIntegralMatrix(byte[] rgb, int width, int heigth)
        {
            double[,] matrix = new double[heigth, width];
            double[,] square = new double[heigth, width];
            double[] I = new double[width * heigth];

            //интегральная матрица строится по формуле  
            //S(i, j) = I(i, j) + S(i - 1, j) + S(i, j - 1) - S(i - 1, j - 1)
            //где I = 0.2125R + 0.7154G + 0.0721B,
            for (int i = 0; i < heigth; ++i)
            {
                for (int j = 0; j < width; j++)
                {
                    //позиция пикселя в одномерном массиве
                    int pos = i * width + j;
                    //позиция пикселя в одномерном массиве, учитывая rgb
                    int p = pos * 3;
                    I[pos] = 0.2125 * rgb[p] + 0.7154 * rgb[p + 1] + 0.0721 * rgb[p + 2];
                    //квадрат величины I[pos] для вычисления дисперсии в последующем
                    double I2 = I[pos] * I[pos];

                    //S(i - 1, j)
                    double m1 = 0, s1 = 0;
                    if (i - 1 >= 0)
                    {
                        m1 = matrix[i - 1, j];
                        s1 = square[i - 1, j];
                    }

                    //S((i, j - 1)
                    double m2 = 0, s2 = 0;
                    if (j - 1 >= 0)
                    {
                        m2 = matrix[i, j - 1];
                        s2 = square[i, j - 1];
                    }

                    //S(i - 1, j - 1)
                    double m3 = 0, s3 = 0;
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        m3 = matrix[i - 1, j - 1];
                        s3 = square[i - 1, j - 1];
                    }

                    matrix[i, j] = I[pos] + m1 + m2 - m3;
                    square[i, j] = I2 + s1 + s2 - s3;
                }
            }

            //возвращаем интегральную матрицу
            return (matrix, square, I);
        }
    }

    public class BradleyRota
    {
        public static double min { get; } = 0;
        public static double max { get; } = 1;
        //1 - пограничный белый, 2 - черный
        public static (Image bmp, double time) Binarization(Image image, int a, double k, int color = 0)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            //ограничения на k
            if (k > max) k = max;
            if (k < min) k = min;

            Bitmap bmp = new Bitmap(image);
            int height = bmp.Height;
            int width = bmp.Width;

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            //получаем интегральную матрицу, а также изображение в градиентах серого
            (double[,] matrix, double[] I) = GetIntegralMatrix(rgb, width, height);

            //шаг в сторону от центра
            int h = (a - 1) / 2;

            //выбор изменения пограничного пикселя <= t или < t
            switch (color)
            {
                case 0:
                    //в параллельном режиме пробегаем по каждой строке и редачим пиксели
                    Parallel.For(0, height, i =>
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            //комбинация позиций для вычисления Sum(P)
                            int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                            int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                            int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                            int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                            //t = Sum(P) / кол-во пикселей в окне * (1 - k)
                            //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                            double t = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) * (1 - k);

                            int pos = (i * width + j);
                            if (I[pos] <= t)
                            {
                                rgb[pos * 3] = 0;
                                rgb[pos * 3 + 1] = 0;
                                rgb[pos * 3 + 2] = 0;
                            }
                            else
                            {
                                rgb[pos * 3] = 255;
                                rgb[pos * 3 + 1] = 255;
                                rgb[pos * 3 + 2] = 255;
                            }
                        }
                    });
                    break;
                case 255:
                    //в параллельном режиме пробегаем по каждой строке и редачим пиксели
                    Parallel.For(0, height, i =>
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            //комбинация позиций для вычисления Sum(P)
                            int i_1 = (i - h - 1 < 0) ? 0 : (i - h - 1);
                            int j_1 = (j - h - 1 < 0) ? 0 : (j - h - 1);
                            int i_2 = (i + h > height - 1) ? (height - 1) : (i + h);
                            int j_2 = (j + h > width - 1) ? (width - 1) : (j + h);

                            //t = Sum(P) / кол-во пикселей в окне * (1 - k)
                            //Sum(P) = matrix(x2, y2) + matrix(x1 - 1, y1 - 1) - matrix(x1 - 1, y2) - matrix(x2, y1 - 1)
                            double t = (matrix[i_2, j_2] - matrix[i_1, j_2] - matrix[i_2, j_1] + matrix[i_1, j_1]) / ((i_2 - i_1) * (j_2 - j_1)) * (1 - k);

                            int pos = (i * width + j);
                            if (I[pos] < t)
                            {
                                rgb[pos * 3] = 0;
                                rgb[pos * 3 + 1] = 0;
                                rgb[pos * 3 + 2] = 0;
                            }
                            else
                            {
                                rgb[pos * 3] = 255;
                                rgb[pos * 3 + 1] = 255;
                                rgb[pos * 3 + 2] = 255;
                            }
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }

        //составляем интегральную матрицуЫ
        private static (double[,], double[]) GetIntegralMatrix(byte[] rgb, int width, int heigth)
        {
            double[,] matrix = new double[heigth, width];
            double[] I = new double[width * heigth];
            //интегральная матрица строится по формуле  
            //S(i, j) = I(i, j) + S(i - 1, j) + S(i, j - 1) - S(i - 1, j - 1)
            //где I = 0.2125R + 0.7154G + 0.0721B,
            for (int i = 0; i < heigth; ++i)
            {
                for (int j = 0; j < width; j++)
                {
                    //позиция пикселя в одномерном массиве
                    int pos = i * width + j;
                    //позиция пикселя в одномерном массиве, учитывая rgb
                    int p = pos * 3;
                    I[pos] = 0.2125 * rgb[p] + 0.7154 * rgb[p + 1] + 0.0721 * rgb[p + 2];
                    //S(i - 1, j)
                    var s1 = (i - 1 >= 0) ? matrix[i - 1, j] : 0;
                    //S((i, j - 1)
                    var s2 = (j - 1 >= 0) ? matrix[i, j - 1] : 0;
                    //S(i - 1, j - 1)
                    var s3 = (i - 1 >= 0 && j - 1 >= 0) ? matrix[i - 1, j - 1] : 0;
                    matrix[i, j] = I[pos] + s1 + s2 - s3;
                }
            }

            //возвращаем интегральную матрицу
            return (matrix, I);
        }
    }
}
