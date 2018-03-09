using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace MT.Common
{
    public class ImageUtil
    {

        #region GetPicThumbnail

        public static Size CalculateSize(int height, int width, Size sourceSize)
        {
            Size newSize = new Size();
            double rate = 1;
            //指定高度,原比例计算宽度
            if (width == 0 && height == 0)
            {
                return sourceSize;
            }
            if (width == 0)
            {
                rate = (double)sourceSize.Width / sourceSize.Height;
                newSize.Height = height;
                newSize.Width = (int)Math.Ceiling(height * rate);
            }
            else if (height == 0) //指定宽度,原比例计算高度
            {
                rate = (double)sourceSize.Height / sourceSize.Width;
                newSize.Width = width;
                newSize.Height = (int)Math.Ceiling(width * rate);
            }
            else//使用指定高宽
            {
                if (sourceSize.Width > height || sourceSize.Width > width)
                {
                    if ((sourceSize.Width * height) > (sourceSize.Height * newSize.Width))
                    {
                        newSize.Width = width;
                        newSize.Height = (width * sourceSize.Height) / sourceSize.Width;
                    }
                    else
                    {
                        newSize.Height = height;
                        newSize.Width = (sourceSize.Width * height) / sourceSize.Height;
                    }
                }
                else
                {
                    newSize.Width = sourceSize.Width;
                    newSize.Height = sourceSize.Height;
                }
            }
            return newSize;
        }

        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片</param>
        /// <param name="dFile">压缩后保存位置</param>
        /// <param name="dHeight">高度</param>
        /// <param name="dWidth"></param>
        /// <param name="flag">压缩质量 1-100</param>
        /// <returns></returns>
        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag = 100)
        {
            Image iSource = Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;

            //计算高宽
            int sW = 0, sH = 0;
            Size tem_size = new Size(iSource.Width, iSource.Height);
            Size newSize = CalculateSize(dHeight, dWidth, tem_size);
            sW = newSize.Width;
            sH = newSize.Height;
            if (dHeight == 0)
            {
                dHeight = newSize.Height;
            }
            if (dWidth == 0)
            {
                dWidth = newSize.Width;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.White);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
        #endregion
    }
}