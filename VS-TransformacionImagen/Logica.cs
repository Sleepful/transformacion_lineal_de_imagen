using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;


namespace VS_TransformacionImagen
{
    class Logica
    {


        public static Bitmap Diff(String path, int orX, int orY, int[] matrix)
        {
            //Image baseImg = Image.FromFile(path);
            //baseImg.Save("test.bmp", ImageFormat.Bmp);
            //Bitmap baseBM = new Bitmap("test.bmp");
            Bitmap baseBM = new Bitmap(path);


            int[] maxX = new int[4];
            maxX[0] = ((0 - orX) * matrix[0]) + ((0 - orY) * matrix[1]);
            maxX[1] = ((baseBM.Width - orX) * matrix[0]) + ((0 - orY) * matrix[1]);
            maxX[2] = ((baseBM.Width - orX) * matrix[0]) + ((baseBM.Height - orY) * matrix[1]);
            maxX[3] = ((0 - orX) * matrix[0]) + ((baseBM.Height - orY) * matrix[1]);
            int maxWidth = maxX.Max();
            if (maxX.Min() < 0)
                maxWidth += -maxX.Min();


            int[] maxY = new int[4];
            maxY[0] = ((0 - orX) * matrix[2]) + ((0 - orY) * matrix[3]);
            maxY[1] = ((baseBM.Width - orX) * matrix[2]) + ((0 - orY) * matrix[3]);
            maxY[2] = ((baseBM.Width - orX) * matrix[2]) + ((baseBM.Height - orY) * matrix[3]);
            maxY[3] = ((0 - orX) * matrix[2]) + ((baseBM.Height - orY) * matrix[3]);
            int maxHeight = maxY.Max();
            if (maxY.Min() < 0)
                maxHeight += -maxY.Min();


            Bitmap res = new Bitmap(maxWidth, maxHeight, PixelFormat.Format24bppRgb);


            for (int y = 0; y < baseBM.Height; y++)
            {
                for (int x = 0; x < baseBM.Width; x++)
                {
                    Color col = baseBM.GetPixel(x,y);
                    int newX, newY;
                    newX = Math.Abs(((x - orX) * matrix[0]) + ((y - orY) * matrix[1]));
                    newY = Math.Abs(((x - orX) * matrix[2]) + ((y - orY) * matrix[3]));

                    res.SetPixel(newX, newY, col);


                }
            }
            
            return res;
        }


        public static int con_Y(int pY, int max)
        {
            return Math.Abs(max-pY);
        }
    }
}