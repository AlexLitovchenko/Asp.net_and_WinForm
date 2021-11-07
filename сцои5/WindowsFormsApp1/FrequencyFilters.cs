using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FrequencyFilters
    {
        public static (Image result, Image fourierImage) ApplyFilter(Image img, List<Filter> param, double Brightness, int checkTrue = 1, int checkFalse = 0)
        {
            BMP bmp = new BMP(img);

            //добавляем симметричные точки
            AddParam(img.Width, img.Height, param);

            //получение цветовых каналов
            var result = GetChannels(bmp);
            List<double[]> rgb = new List<double[]>() { result.r, result.g, result.b };

            double[][] ResultRGB = new double[3][];
            Complex[][] FurImg = new Complex[3][];
            //обрабатываем каждый канал
            Parallel.For(0, rgb.Count(), color =>
            {
                //выполняем преобразование Фурье
                Complex[] fourier = TwoFourierTransform.DFT(rgb[color], bmp.Width, bmp.Height);

                //копируем для создание фурье-образа
                FurImg[color] = (Complex[])fourier.Clone();

                //выполняем заданный фильтр
                Parallel.For(0, fourier.Length, index =>
                {
                    //проходим по каждому критерию
                    foreach (var part in param)
                    {
                        //координата пикселя
                        int i = index / bmp.Width;
                        int j = index % bmp.Width;

                        int x = i - part.x;
                        int y = j - part.y;
                        int value = x * x + y * y;

                        if (value >= part.r1 * part.r1 && value <= part.r2 * part.r2)
                        {
                            fourier[index] = FurImg[color][index] * checkTrue;
                        }
                        else
                        {
                            fourier[index] = FurImg[color][index] * checkFalse;
                        }
                    }
                });

                //выполняем обратное преобразование Фурье
                ResultRGB[color] = TwoFourierTransform.DFT_Inverse(fourier, bmp.Width, bmp.Height);
            });

            //изменяе картинку
            SetChannels(bmp, ResultRGB[0], ResultRGB[1], ResultRGB[2]);
            bmp.Save();
            //поворачиваем картинку на 180
            bmp.bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            //картинка с фурье-образом
            Image fourierImage = GetImage((FurImg[0], FurImg[1], FurImg[2]), bmp.Width, bmp.Height, Brightness);
            //наложение на картинку фильтра
            fourierImage = AddFilter(fourierImage, param);

            return (bmp.bmp, fourierImage);
        }

        //получение цветовых каналов
        private static (double[] r, double[] g, double[] b) GetChannels(BMP bmp)
        {
            double[] r = new double[bmp.Height * bmp.Width];
            double[] g = new double[bmp.Height * bmp.Width];
            double[] b = new double[bmp.Height * bmp.Width];

            Parallel.For(0, bmp.bytes / bmp.Сhannels, index =>
            {
                //координата пикселя
                int real = index * bmp.Сhannels;
                b[index] = bmp.argb[real];
                g[index] = bmp.argb[real + 1];
                r[index] = bmp.argb[real + 2];
            });
            return (r, g, b);
        }

        //установка цветовых каналов
        private static void SetChannels(BMP bmp, double[] r, double[] g, double[] b)
        {
            Parallel.For(0, bmp.bytes / bmp.Сhannels, index =>
            {
                //координата пикселя
                int real = index * bmp.Сhannels;
                bmp.argb[real] = (byte)Clamp(b[index], 0, 255);
                bmp.argb[real + 1] = (byte)Clamp(g[index], 0, 255);
                bmp.argb[real + 2] = (byte)Clamp(r[index], 0, 255);
            });
        }

        //добавление симметричных областей, если их нет
        private static void AddParam(int width, int heigth, List<Filter> param)
        {
            List<Filter> addParam = new List<Filter>();
            int x = width / 2;
            int y = heigth / 2;
            foreach (var value in param)
            {
                if (x != value.x || y != value.y)
                {
                    int newX = x, newY = y;
                    if (value.x < x) newX = x + (x - value.x);
                    if (value.x > x) newX = x - (value.x - x);
                    if (value.y < y) newY = y + (y - value.y);
                    if (value.y > y) newY = y - (value.y - y);

                    addParam.Add(new Filter(newX, newY, value.r1, value.r2));
                }
            }
            param.AddRange(addParam);
        }
        protected static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        //<-- Визуализация фурье-образа -->
        //Визуализация Фурье-образа и фильтра на нем 
        public static Image GetImage((Complex[] r, Complex[] g, Complex[] b) rgb, int Width, int Height, double Brightness)
        {
            Bitmap bmp = new Bitmap(Width, Height);

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] argb = new byte[bytes];

            Parallel.For(0, Width * Height, index =>
            {
                int real = index * 4;
                argb[real] = (byte)Clamp(rgb.b[index].Magnitude * Brightness, 0, 255);
                argb[real + 1] = (byte)Clamp(rgb.g[index].Magnitude * Brightness, 0, 255);
                argb[real + 2] = (byte)Clamp(rgb.r[index].Magnitude * Brightness, 0, 255);
                argb[real + 3] = 255;
            });

            System.Runtime.InteropServices.Marshal.Copy(argb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            return bmp;
        }
        //наложение фильтров на фурье-образ
        public static Image AddFilter(Image image, List<Filter> filters)
        {
            using (Graphics gr = Graphics.FromImage(image))
            {
                foreach (var it in filters)
                {
                    int x1 = it.x - it.r1 / 2;
                    int y1 = it.y - it.r1 / 2;

                    gr.DrawEllipse(Pens.Red, new RectangleF(x1, y1, it.r1, it.r1));

                    int x2 = it.x - it.r2 / 2;
                    int y2 = it.y - it.r2 / 2;

                    gr.DrawEllipse(Pens.Red, new RectangleF(x2, y2, it.r2, it.r2));
                }
            }
            return image;
        }
    }
}
