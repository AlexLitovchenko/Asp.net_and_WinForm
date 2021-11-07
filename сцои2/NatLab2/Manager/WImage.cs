using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NatLab2.Manager
{
    public class WImage
    {
        private static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        internal static (Image img, DataTable table) GradationTransform(Image image, List<int> factorValues, string xValueMember, string yValueMembers)
        {
            //создаем таблицу для построения гистограммы
            DataTable table = new DataTable("BarGraph");
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));

            Bitmap bmp = new Bitmap(image);
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            Parallel.For(0, rgb.Length, (Action<int>)(i => rgb[i] = (byte)Clamp(factorValues[rgb[i]], 0, 255)));

            int[] mas = new int[256];
            Parallel.For(0, rgb.Length / 3, (Action<int>)(i => Interlocked.Increment(ref mas[(int)((double)((int)rgb[i * 3] + (int)rgb[i * 3 + 1] + (int)rgb[i * 3 + 2]) / 3.0)])));

            for (int i = 0; i < 256; i++)
            {
                DataRow row = table.NewRow();
                row[0] = i;
                row[1] = mas[i];
                table.Rows.Add(row);
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            return (bmp, table);
        }
    }
}
