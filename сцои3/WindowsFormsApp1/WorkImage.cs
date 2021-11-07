using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class WorkImage
    {
        //приводим изображение к градациям серого
        public static Image ConvertToGrayscale(Image img)
        {
            Bitmap image = new Bitmap(img);
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics gfxPic = Graphics.FromImage(bmp);
            ColorMatrix cmxPic = new ColorMatrix();
            cmxPic.Matrix00 = 0.2125f;
            cmxPic.Matrix01 = 0.2125f;
            cmxPic.Matrix02 = 0.2125f;

            cmxPic.Matrix10 = 0.7154f;
            cmxPic.Matrix11 = 0.7154f;
            cmxPic.Matrix12 = 0.7154f;

            cmxPic.Matrix20 = 0.0721f;
            cmxPic.Matrix21 = 0.0721f;
            cmxPic.Matrix22 = 0.0721f;

            ImageAttributes iaPic = new ImageAttributes();
            iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            gfxPic.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, iaPic);
            gfxPic.Dispose();
            iaPic.Dispose();
            image.Dispose();
            return bmp;
        }
    }
}
