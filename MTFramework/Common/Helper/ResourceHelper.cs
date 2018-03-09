using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Text;
using System.Web.Mvc;

namespace MT.Common
{
    public enum CourseImageSizeEnum
    {
        big, small
    }
    public class ResourceHelper
    {
        /// <summary>
        /// 生成插件资源地址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CreatePluginsResourceUrl(string name)
        {
            return string.Format("{0}/Plugins/{1}", MTConfig.ResourceServer, name);
        }

        /// <summary>
        /// 生成脚本资源地址
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static HtmlString CreateScriptResourceUrl(string[] path)
        {
            StringBuilder script = new StringBuilder();
            foreach (string item in path)
            {
                script.AppendFormat("<script language=\"JavaScript\" src=\"{0}/{1}/{2}\" type=\"text/javascript\"></script>", MTConfig.ResourceServer, MTConfig.ScriptAddress, item);
            }
            return new HtmlString(script.ToString());
        }

        /// <summary>
        /// 生成脚本资源带ID
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static HtmlString CreateScriptResource(string[] path)
        {
            StringBuilder script = new StringBuilder();
            foreach (string item in path)
            {
                script.AppendFormat("<script id=\"gd\", language=\"JavaScript\" src=\"{0}/{1}/{2}\" type=\"text/javascript\"></script>", MTConfig.ResourceServer, MTConfig.ScriptAddress, item);
            }
            return new HtmlString(script.ToString());
        }



        /// <summary>
        /// 生成样式资源地址
        /// </summary>
        /// <param name="areaname"></param>
        /// <param name="styles"></param>
        /// <param name="skin"></param>
        /// <returns></returns>
        public static HtmlString CreateStyleResourceUrl(string areaname, string[] styles, string skin = "base")
        {
            StringBuilder link = new StringBuilder();
            foreach (string style in styles)
            {
                link.AppendFormat("<link href=\"{0}/{1}/{2}/Themes/{3}/{4}.css\" type=\"text/css\" rel=\"stylesheet\" />", MTConfig.ResourceServer, MTConfig.CssAddress, areaname, skin, style);
            }
            return new HtmlString(link.ToString());
        }

        /// <summary>
        /// 生成bootstrap的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateBootStrapScriptUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/bootstrap-3.3.5-dist/js/bootstrap.min.js\"></script>", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成bootstrap的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateBootStrapStyleUrl()
        {
            return new HtmlString(string.Format("<link rel=\"StyleSheet\" href=\"{0}/{1}/bootstrap-3.3.5-dist/css/bootstrap.min.css\" type=\"text/css\" />", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成bootstrapDATE的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateBootStrapdateScriptUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/bootstrap-datetimepicker-master/js/bootstrap-datetimepicker.js\"></script>", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成bootstrapDATE的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateBootStrapdateLessUrl()
        {
            return new HtmlString(string.Format("<link rel=\"StyleSheet/less\" href=\"{0}/{1}/bootstrap-datetimepicker-master/css/datetimepicker.less\" type=\"text/css\" />", MTConfig.ResourceServer, "Plugins"));
        }
        /// <summary>
        /// 生成bootstrapDATE的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateBootStrapdateStyleUrl()
        {
            return new HtmlString(string.Format("<link rel=\"StyleSheet\" href=\"{0}/{1}/bootstrap-datetimepicker-master/css/bootstrap-datetimepicker.css\" type=\"text/css\" />", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成LayuiStyl的地址 并引入公用的提示信息 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateLayuiStyleUrl()
        {

            return new HtmlString(string.Format("<link rel=\"StyleSheet\" href=\"{0}/{1}/layui/css/layui.css\" type=\"text/css\" />", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成LayuiStyl的地址 并引入公用的提示信息 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateLayuiScriptUrl()
        {

            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/layui/lay/dest/layui.all.js\">", MTConfig.ResourceServer, "Plugins"));
        }


        /// <summary>
        /// 生成artDialog的地址 并引入公用的提示信息 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateArtDialogUrl(string themes = "")
        {
            if (string.IsNullOrEmpty(themes))
            {
                switch (HtmlExtend.GetArea())
                {
                    case "admin":
                        themes = "admin";
                        break;
                    default:
                        themes = "blue";
                        break;
                }
            }

            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/artDialog/jquery.artDialog.source.js?skin={2}\"></script><script type=\"text/javascript\" src=\"{0}/{1}/artDialog/plugins/iframeTools.js\"></script>", MTConfig.ResourceServer, "Plugins", themes));
        }

        /// <summary>
        /// 生成artDialog的地址 并引入公用的提示信息 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateFrontArtDialogUrl(string themes = "")
        {
            if (string.IsNullOrEmpty(themes))
            {
                switch (HtmlExtend.GetArea())
                {
                    case "admin":
                        themes = "admin";
                        break;
                    default:
                        themes = "blue";
                        break;
                }
            }

            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/artDialog/jquery.artDialog.source.js?skin={2}\"></script><script type=\"text/javascript\" src=\"{0}/{1}/artDialog/plugins/iframeOrangeTools.source.js\"></script>", MTConfig.ResourceServer, "Plugins", themes));
        }


        /// <summary>
        /// 生成jQueryUI的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateUIScriptUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/UI/js/jquery-ui-1.10.4.custom.js\"></script>", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成jQueryUI的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateUIStyleUrl()
        {
            return new HtmlString(string.Format("<link rel=\"StyleSheet\" href=\"{0}/{1}/UI/css/redmond/jquery-ui-1.10.4.custom.css\" type=\"text/css\" />", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成日历控件的地址 by张俊栋
        /// </summary>
        /// <returns></returns>
        public static HtmlString CreateDatePickerUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/Common/My97DatePicker/WdatePicker.js\"></script>", MTConfig.ResourceServer, MTConfig.ScriptAddress));
        }

        /// <summary>
        /// 生成artDialog的地址 并引入公用的提示信息 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateCommonDialogUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/artDialog/CommonDialog.js\"></script>", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成KindEditor的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateKindEditorScriptUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/kindeditor/kindeditor-all-min.js\"></script>", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成KindEditor的地址 by张俊栋
        /// </summary>
        /// <param name="themes">主题</param>
        /// <returns></returns>
        public static HtmlString CreateKindEditorStyleUrl()
        {
            return new HtmlString(string.Format("<link rel=\"StyleSheet\" href=\"{0}/{1}/kindeditor/themes/default/default.css\" type=\"text/css\" />", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 生成在\Content_V1.0\Home\Themes\Base\Images\ 下的图片地址 by张俊栋
        /// </summary>
        /// <param name="imgName"></param>
        /// <param name="themes"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string CreateThemesImgUrl(string imgName, string themes = "Base", string area = "Home")
        {
            return string.Format("{0}/{1}/{2}/Themes/{3}/Images/{4}", MTConfig.ResourceServer, MTConfig.CssAddress, area, themes, imgName);
        }

        /// <summary>
        /// 生成在\Content_V1.0\H5\Themes\Base\Images\ 下的图片地址 by张俊栋
        /// </summary>
        /// <param name="imgName"></param>
        /// <param name="themes"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string CreateThemesImgUrlForH5(string imgName, string themes = "Base", string area = "H5")
        {
            return string.Format("{0}/{1}/{2}/Themes/{3}/Images/{4}", MTConfig.ResourceServer, MTConfig.CssAddress, area, themes, imgName);
        }


        public static string CreateCourseImage(CourseImageSizeEnum size = CourseImageSizeEnum.big, int seed = 0)
        {
            const string style = " style=background-image:url({0})";
            Random ran = null;
            if (0 == seed)
            {
                seed = 1;
            }
            string fileName = "bgCoursesCover" + seed;
            if (CourseImageSizeEnum.small == size)
            {
                fileName += "s";
            }
            fileName += ".jpg";
            return string.Format(style, CreateImageResourceUrl(fileName));
        }
        public static string CreateImageResourceUrl(string name)
        {
            return string.Format("{0}/image/{1}", MTConfig.ResourceServer, name);
        }

        /// <summary>
        /// 生成下载图片的url地址 by张俊栋
        /// </summary>
        /// <param name="imgId">图片id</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static string CreateUploadImgUrl(int? imgId, int? width = null, int?  height = null)
        {
            string url = MTConfig.ImageServer + "/Home/Img?id=" + imgId;
            if (width.HasValue)
            {
                url += "&width=" + width;
            }
            else
            {
                url += "&width=0";
            }
            if (height.HasValue)
            {
                url += "&height=" + height;
            }
            else
            {
                url += "&height=0";
            }
            if (!width.HasValue && !height.HasValue)
            {
                return MTConfig.ImageServer + "/Home/Img?id=" + imgId;
            }
            return url;
        }

        /// <summary>
        /// 预览图片地址 by张俊栋
        /// </summary>
        /// <param name="imgId">图片id</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static string CreateUploadViewUrl(int? imgId)
        {
            return string.Format(MTConfig.ImageServer + "/Home/ViewFile?id=" + imgId);
        }

        /// <summary>
        /// 下载文件地址
        /// </summary>
        /// <param name="imgId">图片id</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static string CreateDownLoadUrl(int? imgId)
        {
            return string.Format(MTConfig.ImageServer + "/Home/DownloadFile?id=" + imgId);
        }

        #region 验证码相关

        #region 获取验证码

        /// <summary>
        /// 获取随机英文字符数字验证码
        /// </summary>
        /// <param name="validateLength"></param>
        /// <returns></returns>
        public static string GetRandomCharNumberString(int validateLength)
        {
            string vchar = "23456789ABCDFGHJKMNPPQRSTUVWXYZ";
            string vnum = "";
            System.Random rand = new Random();
            for (int i = 0; i < validateLength; i++)
            {
                int t = rand.Next(vchar.Length);
                vnum += vchar[t];
            }
            return vnum;

        }

        /// <summary>
        /// 获取随机英文字符数字验证码
        /// </summary>
        /// <param name="validateLength"></param>
        /// <returns></returns>
        public static string GetRandomNumber(int validateLength)
        {
            string vchar = "0123456789";
            string vnum = "";
            System.Random rand = new Random();
            for (int i = 0; i < validateLength; i++)
            {
                int t = rand.Next(vchar.Length);
                vnum += vchar[t];
            }
            return vnum;

        }

        /// <summary>
        /// 获取随机中文字符验证码
        /// </summary>
        /// <param name="validateLength">验证长度</param>
        /// <returns></returns>
        private string GetRandomChineseString(int validateLength)
        {
            //获取GB2312编码页（表） 
            Encoding gb = Encoding.GetEncoding("gb2312");

            //调用函数产生4个随机中文汉字编码 
            object[] bytes = CreateRegionCode(3);

            //根据汉字编码的字节数组解码出中文汉字 
            string str1 = gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[])));
            string str2 = gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[])));
            string str3 = gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[])));
            return str1 + str2 + str3;
        }

        public static object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素 
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            //定义一个object数组用来 
            object[] bytes = new object[strlength];

            /**/
            /*每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bject数组中 
         每个汉字有四个区位码组成 
         区位码第1位和区位码第2位作为字节数组第一个元素 
         区位码第3位和区位码第4位作为字节数组第二个元素 
        */
            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位 
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位 
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机数发生器的种子避免产生重复值 
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位 
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位 
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                //定义两个字节变量存储产生的随机汉字区位码 
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //将两个字节变量存储在字节数组中 
                byte[] str_r = new byte[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中 
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }

        #endregion

        #region 生成验证码图像

        /// <summary>
        /// 生成随机颜色
        /// </summary>
        /// <returns></returns>
        private static Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  对于C#的随机数
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            //  为了在白色背景上显示，尽量生成深色
            int iRed = RandomNum_First.Next(256);
            int iGreen = RandomNum_Sencond.Next(256);
            int iBlue = (iRed + iGreen > 400) ? 0 : 400 - iRed - iGreen;
            iRed = (iRed > 120) ? 120 : iRed;
            iGreen = (iGreen > 120) ? 120 : iGreen;
            iBlue = (iBlue > 120) ? 120 : iBlue;
            return Color.FromArgb(iRed, iGreen, iBlue);
        }

        /// <summary>
        /// 根据验证字符串生成图象
        /// </summary>
        /// <param name="strValidateCode"></param>
        public static MemoryStream CreateImage(string strValidateCode)
        {
            int iImageWidth = strValidateCode.Length * 14;
            Random newRandom = new Random();
            //  图高20px
            Bitmap theBitmap = new Bitmap(iImageWidth, 20);
            Graphics theGraphics = Graphics.FromImage(theBitmap);
            //  白色背景
            theGraphics.Clear(Color.AliceBlue);

            //画图片的背景噪音线5条
            for (int i = 0; i < 5; i++)
            {
                int x1 = newRandom.Next(theBitmap.Width);
                int x2 = newRandom.Next(theBitmap.Width);
                int y1 = newRandom.Next(theBitmap.Height);
                int y2 = newRandom.Next(theBitmap.Height);
                //用银色画出噪音线
                theGraphics.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            //画图片的前景噪音点10个
            for (int i = 0; i < 10; i++)
            {
                int x = newRandom.Next(theBitmap.Width);
                int y = newRandom.Next(theBitmap.Height);
                theBitmap.SetPixel(x, y, Color.FromArgb(newRandom.Next()));
            }
            //画图片的框线
            theGraphics.DrawRectangle(new Pen(Color.SaddleBrown), 0, 0, theBitmap.Width - 1, theBitmap.Height - 1);
            ////获取系统已经安装的字体
            //InstalledFontCollection MyFont = new InstalledFontCollection();
            //FontFamily[] MyFontFamilies = MyFont.Families;
            //Font theFont = null;//new Font() //new Font("Arial", 10);
            //if (MyFontFamilies.Length > 0)
            //{
            //    FontFamily ff = MyFontFamilies[new Random().Next(MyFontFamilies.Length)];
            //    theFont = new Font(ff, 12);
            //}
            //else
            //{
            Font theFont = new Font("Arial", 12);
            // }
            for (int iindex = 0; iindex < strValidateCode.Length; iindex++)
            {
                string strchar = strValidateCode.Substring(iindex, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point(iindex * 13 + 1 + newRandom.Next(3), 1 + newRandom.Next(3));
                theGraphics.DrawString(strchar, theFont, newBrush, thePos);
            }

            //  将生成的图片发回客户端
            MemoryStream ms = new MemoryStream();
            theBitmap.Save(ms, ImageFormat.Png);
            return ms;
        }

        #endregion

        #endregion

        /// <summary>
        /// 引入异步加载图片脚本
        /// </summary>
        /// <returns></returns>
        public static HtmlString CreateImgLoadingUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/{1}/ImgLoading/jquery.scrollLoading.js\"></script>", MTConfig.ResourceServer, "Plugins"));
        }

        /// <summary>
        /// 引入highchart的脚本
        /// </summary>
        /// <returns></returns>
        public static HtmlString CreateHighChartUrl()
        {
            return new HtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}/Plugins/Highchart/highcharts.js\"></script><script type=\"text/javascript\" src=\"{0}/Plugins/Highchart/modules/exporting.js\"></script>", MTConfig.ResourceServer));
        }

        /// <summary>
        /// 新浪微博引用地址
        /// </summary>
        /// <returns></returns>
        public static HtmlString CreateWeiboUrl()
        {
            return new HtmlString("<script type=\"text/javascript\"  src=\"http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=113381298\" charset=\"utf-8\"></script>");
        }
    }
}