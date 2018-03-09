using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using MT.Models;
using MT.Dal;

namespace MT.Common
{
    #region List的拓展
    public static class ListExtend
    {
        /// <summary>
        /// 可以将List<T>泛型转换为DataTable
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            DataTable dt = new DataTable();

            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                DataColumn column = new DataColumn()
                {
                    ColumnName = propertyInfo.Name
                };
                dt.Columns.Add(column);
            }

            foreach (T t in list)
            {
                DataRow dr = dt.NewRow();
                propertyInfos = t.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    object obj = propertyInfo.GetValue(t, null);
                    dr[propertyInfo.Name] = obj;
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
    #endregion

    #region object的拓展
    public static class ObjectExtend
    {
        public static DateTime ToDateTime(this object value)
        {
            DateTime dt;
            bool iRes = DateTime.TryParse(value.ToString(), out dt);
            if (!iRes)
            {
                dt = new DateTime();
            }
            return dt;
        }

        public static int ToInt(this object value)
        {
            int iTemp;
            if (null == value)
            {
                return 0;
            }
            bool iRes = int.TryParse(value.ToString(), out iTemp);
            if (!iRes)
            {
                iTemp = 0;
            }
            return iTemp;
        }

        public static long ToLong(this object value)
        {
            long lTemp;
            if (null == value)
            {
                return 0;
            }
            bool bRes = long.TryParse(value.ToString(), out lTemp);
            if (!bRes)
            {
                lTemp = 0;
            }
            return lTemp;
        }

        public static float ToFloat(this object value)
        {
            float fTemp;
            if (null == value)
            {
                return 0;
            }
            bool iRes = float.TryParse(value.ToString(), out fTemp);
            if (!iRes)
            {
                fTemp = 0;
            }
            return fTemp;
        }

        public static double ToDouble(this object value)
        {
            double dTemp;
            if (null == value)
            {
                return 0;
            }
            bool bRes = double.TryParse(value.ToString(), out dTemp);
            if (!bRes)
            {
                dTemp = 0;
            }
            return dTemp;
        }

        public static decimal ToDecimal(this object value)
        {
            decimal dTemp;
            if (null == value)
            {
                return 0;
            }
            bool bRes = decimal.TryParse(value.ToString(), out dTemp);
            if (!bRes)
            {
                dTemp = 0;
            }
            return dTemp;
        }

        public static bool ToBool(this object value)
        {
            bool dTemp;
            if (null == value)
            {
                return false;
            }
            bool bRes = bool.TryParse(value.ToString(), out dTemp);
            if (!bRes)
            {
                dTemp = false;
            }
            return dTemp;
        }

        /// <summary>
        /// 如果equalsObj为null或string.empty，直接返回true，否则执行Equals判断
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="equalsObj"></param>
        /// <returns></returns>
        public static bool EqualsBySelect(this object obj, object equalsObj)
        {
            if (equalsObj == null || equalsObj.Equals(string.Empty))
            {
                return true;
            }
            return (obj.Equals(equalsObj));
        }

        /// <summary>
        /// 如果equalsObj为null或string.empty，直接返回true，否则执行Contains判断
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="equalsObj"></param>
        /// <returns></returns>
        public static bool ContainsBySelect(this string obj, string equalsObj)
        {
            if (equalsObj == null || equalsObj.Equals(string.Empty))
            {
                return true;
            }
            return (obj.Contains(equalsObj));
        }
        /// <summary>
        /// IList.Add()拥有bool类型返回值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool AddReturnBool(this IList list, object obj)
        {
            list.Add(obj);
            return true;
        }

        /// <summary>
        /// 对DataRow的一个字段赋值，返回赋值后的DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cname"></param>
        /// <param name="cvalue"></param>
        /// <returns></returns>
        public static DataRow HandleSelf(this DataRow row, string cname, object cvalue)
        {
            row[cname] = cvalue;
            return row;
        }
    }
    #endregion

    #region String的拓展
    public static class StringExtend
    {
        public static Regex SafeRegex = new Regex("delete|truncate|drop|<|>|'|--|&nbsp;|insert|update|&nbsp", RegexOptions.Compiled);

        /// <summary>
        /// 将bool类型转换成Oracle Char(1)形式
        /// </summary>
        /// <returns></returns>
        public static string ToOraBit(this bool value)
        {
            if (value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 将Oracle Char(1)形式转为bool
        /// </summary>
        /// <returns></returns>
        public static bool ToOraBool(this string value)
        {
            if (value.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime ToDateTime(this string value)
        {
            DateTime dt;
            bool iRes = DateTime.TryParse(value, out dt);
            if (!iRes)
            {
                dt = new DateTime();
            }
            return dt;
        }

        public static int ToInt(this string value)
        {
            int iTemp;
            bool iRes = int.TryParse(value, out iTemp);
            if (!iRes)
            {
                iTemp = 0;
            }
            return iTemp;
        }

        public static long ToLong(this string value)
        {
            long lTemp;
            bool bRes = long.TryParse(value, out lTemp);
            if (!bRes)
            {
                lTemp = 0;
            }
            return lTemp;
        }

        public static float ToFloat(this string value)
        {
            float fTemp;
            bool iRes = float.TryParse(value, out fTemp);
            if (!iRes)
            {
                fTemp = 0;
            }
            return fTemp;
        }

        public static double ToDouble(this string value)
        {
            double dTemp;
            bool bRes = double.TryParse(value, out dTemp);
            if (!bRes)
            {
                dTemp = 0;
            }
            return dTemp;
        }

        /// <summary>
        /// 去掉非法字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToSafe(this string parameter)
        {
            //if (parameter != null)
            //{
            //    parameter = parameter.Trim();
            //    parameter = parameter.Replace("'", "");
            //    parameter = parameter.Replace("--", "");
            //    parameter = parameter.Replace("%", "");
            //}
            if (string.IsNullOrEmpty(parameter))
            {
                return string.Empty;
            }
            return SafeRegex.Replace(parameter, string.Empty).Trim().Replace("undefined", "");
        }

        /// <summary>
        /// 获得字符的ASCII长度 jiangzhengwu 2012-8-9 10:22:10
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int AsciiLength(this string value)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] b = encoding.GetBytes(value);
            int l = 0; // l 为字符串之实际长度
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63) //判断是否为汉字或全脚符号
                {
                    l += 2;
                }
                l++;
            }
            return l;
        }

        /// <summary>
        /// 对字符串进行截取，超出部分加… jiangzhengwu 2012-8-9 10:25:05
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubEctStr(this string value, int length)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > length)
            {
                value = value.Substring(0, length) + "…";
            }
            return value;
        }

        /// <summary>
        /// 生成32位MD5值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LongMD5(this string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// 生成变异MD5
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>加密后的MD5串</returns>
        public static String VariationMd5(this string password)
        {
            password = password.LongMD5();
            password = password.Substring(0, 14).LongMD5() + password.Substring(14);
            return password;
        }

        /// 验证身份证号码
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard(this string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIDCard18(this string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }
        private static bool CheckIDCard15(this string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        /// <summary>
        /// 验证邮箱格式
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckEmail(this string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        }

        /// <summary>
        /// 获取GBK编码的字符串长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static int GetStringLenByGBK(this string str)
        {
            int retLen = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Convert.ToInt32(str.ToCharArray()[i]) > 255)
                    retLen += 3;
                else
                    retLen++;
            }
            return retLen;
        }

        /// <summary>
        /// 累加分钟
        /// </summary>
        /// <param name="beginTime">开始时间（格式：HH：MM）</param>
        /// <param name="Times">累加时长（单位：分钟）</param>
        /// <returns></returns>
        public static string AddStringTime(string beginTime, Int32 Times)
        {
            decimal dHourTime = Convert.ToDecimal(beginTime.Substring(0, 2));
            decimal dMinTime = Convert.ToDecimal(beginTime.Substring(3, 2));

            decimal dEndMinTime = (dMinTime + Times) % 60;
            decimal dEndHourTime = dHourTime + (int)((dMinTime + Times) / 60);
            if (dEndHourTime > 23 && dEndMinTime != 0)
            {
                dEndHourTime = (int)dEndHourTime / 24 - 1;
            }
            string sEndHourTime;
            string sEndMinTime;
            if (dEndHourTime < 10) { sEndHourTime = "0" + dEndHourTime.ToString(); }
            else { sEndHourTime = dEndHourTime.ToString(); }
            if (dEndMinTime < 10) { sEndMinTime = "0" + dEndMinTime.ToString(); }
            else { sEndMinTime = dEndMinTime.ToString(); }

            return sEndHourTime + ":" + sEndMinTime;
        }

        public static string TruncateString(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            if (str.Length >= length)
            {
                string temp = str.Substring(0, length) + "...";
                return temp;
            }
            else
            {
                return str;
            }
        }

        public static string ToContentType(this string str)
        {
            string fileExt = Path.GetExtension(str);
            string ContentType = "";
            switch (fileExt)
            {
                case ".asf":
                    ContentType = "video/x-ms-asf"; break;
                case ".avi":
                    ContentType = "video/avi"; break;
                case ".doc":
                    ContentType = "application/msword"; break;
                case ".zip":
                    ContentType = "application/zip"; break;
                case ".xls":
                    ContentType = "application/vnd.ms-excel"; break;
                case ".gif":
                    ContentType = "image/gif"; break;
                case ".jpg":
                    ContentType = "image/jpeg"; break;
                case ".jpeg":
                    ContentType = "image/jpeg"; break;
                case ".wav":
                    ContentType = "audio/wav"; break;
                case ".mp3":
                    ContentType = "audio/mpeg3"; break;
                case ".mpg":
                    ContentType = "video/mpeg"; break;
                case ".mepg":
                    ContentType = "video/mpeg"; break;
                case ".rtf":
                    ContentType = "application/rtf"; break;
                case ".html":
                    ContentType = "text/html"; break;
                case ".htm":
                    ContentType = "text/html"; break;
                case ".txt":
                    ContentType = "text/plain"; break;
                default:
                    ContentType = "application/octet-stream";
                    break;
            }
            return ContentType;
        }

        /// <summary>
        /// 去掉html中标签和空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StripStr(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }
            string input = str;
            //去html标签
            input = Regex.Replace(input, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"-->", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"<!--.*", "", RegexOptions.IgnoreCase);

            input = Regex.Replace(input, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            input.Replace("<", "");
            input.Replace(">", "");
            input.Replace("\r\n", "");
            //去两端空格，中间多余空格
            input = Regex.Replace(input.Trim(), "\\s+", " ");
            return input;
        }

        public static string CountDown(this DateTime d)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = d - now;
            int dd = (int)(timeSpan.TotalSeconds / 60 / 60 / 24);
            int hh = (int)(timeSpan.TotalSeconds / 60 / 60 % 24);
            int mm = (int)(timeSpan.TotalSeconds / 60 % 60);
            int ss = (int)(timeSpan.TotalSeconds % 60);
            if (dd <= 0 && hh <= 0 && mm <= 0 && ss <= 0)
            {
                return "已结束";
            }
            return "还剩：" + dd + "天" + hh + "时" + mm + "分" + ss + "秒";
        }
    }
    #endregion

    #region Controller的拓展

    public static class ControllerExtend
    {
         /// <summary>
        /// 使用在列表页面 首页等位置 生成头部的title keywords description
        /// </summary>
        /// <param name="controller"></param>
        public static void GetHeadMeta(this Controller controller)
        {
            List<NodeModel> nodeList = NodeDAL.GetNodeByArea(HtmlExtend.GetArea());
            RouteValueDictionary vd = controller.RouteData.Values;
            string actionName = vd["action"].ToString().ToLower();
            string controllerName = vd["controller"].ToString().ToLower();
            string link = "/" + string.Join("/", new[] {HtmlExtend.GetArea(), controllerName, actionName});
            var actionObj = nodeList.FirstOrDefault(s => !string.IsNullOrEmpty(s.Link) && s.Link.ToLower() == link);

            controller.ViewBag.Title = "";
            controller.ViewBag.Keywords = "";
            controller.ViewBag.Description = "";

            if (actionObj != null)
            {
                controller.ViewBag.Title = actionObj.HeadTitle;
                controller.ViewBag.Keywords = actionObj.HeadKeywords;
                controller.ViewBag.Description = actionObj.HeadDescription;
            }
        }

        /// <summary>
        /// 使用在列表页面 首页等位置 生成头部的title keywords description
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="areaName"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        public static void GetHeadMeta(this Controller controller, string areaName, string controllerName,
                                       string actionName)
        {
            List<NodeModel> nodeList = NodeDAL.GetNodeByArea(areaName);
            string link = "/" + string.Join("/", new[] {areaName, controllerName, actionName});
            var actionObj =
                nodeList.FirstOrDefault(s => !string.IsNullOrEmpty(s.Link) && s.Link.ToLower() == link.ToLower());

            controller.ViewBag.Title = "";
            controller.ViewBag.Keywords = "";
            controller.ViewBag.Description = "";

            if (actionObj != null)
            {
                controller.ViewBag.Title = actionObj.HeadTitle;
                controller.ViewBag.Keywords = actionObj.HeadKeywords;
                controller.ViewBag.Description = actionObj.HeadDescription;
            }
        }

    }


    #endregion

    #region 将datatable转换为list的方法
    public class DtConverToList<T> where T : new()
    {
        public static List<T> DtToList(DataTable dt)
        {
            //定义集合
            List<T> ListCollection = new List<T>(dt.Rows.Count);
            //获得 T 模型类型
            Type T_type = typeof(T);
            //获得 T 模型类型公共属性
            PropertyInfo[] Proper = T_type.GetProperties();
            //临时变量，存储变量模型公共属性Name
            string Tempname = "";
            //遍历参数 DataTable的每行
            foreach (DataRow Dr in dt.Rows)
            {
                //实例化 T 模版类
                T t = new T();
                //遍历T 模版类各个属性
                #region
                foreach (PropertyInfo P in Proper)
                {
                    //取出类属性之一
                    Tempname = P.Name;
                    //判断DataTable中是否有此列
                    if (dt.Columns.Contains(Tempname))
                    {
                        //判断属性是否可写属性
                        if (!P.CanWrite)
                        {
                            continue;
                        }
                        try
                        {
                            //得到Datable单元格中的值
                            object value = Dr[Tempname];
                            //得到 T 属性类型
                            Type ProType = value.GetType();
                            //判断类型赋值
                            if (value != DBNull.Value)
                            {
                                if (value.GetType() == ProType)
                                {
                                    P.SetValue(t, value, null);
                                }
                                else
                                {
                                    if (ProType == typeof(string))
                                    {
                                        string Temp = value.ToString();
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(decimal))
                                    {
                                        decimal Temp = Convert.ToDecimal(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(byte))
                                    {
                                        byte Temp = Convert.ToByte(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(short))
                                    {
                                        short Temp = short.Parse(value.ToString());
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(long))
                                    {
                                        long Temp = long.Parse(value.ToString());
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(Int64))
                                    {
                                        Int64 Temp = Convert.ToInt64(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(Int32))
                                    {
                                        Int32 Temp = Convert.ToInt32(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(Int16))
                                    {
                                        Int16 Temp = Convert.ToInt16(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else
                                    {
                                        object Temp = Convert.ChangeType(value, ProType);
                                        P.SetValue(t, Temp, null);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                #endregion
                ListCollection.Add(t);
            }
            return ListCollection;
        }
    }
    #endregion


    #region Controller拓展 支持Jsonp

    public class JsonpResult : JsonResult
    {
        private static readonly string JsonpCallbackName = "callback";
        private static readonly string CallbackApplicationType = "application/json";

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="context"/> parameter is null.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet) &&
                  String.Equals(context.HttpContext.Request.HttpMethod, "GET"))
            {
                throw new InvalidOperationException();
            }
            var response = context.HttpContext.Response;
            if (!String.IsNullOrEmpty(ContentType))
                response.ContentType = ContentType;
            else
                response.ContentType = CallbackApplicationType;
            if (ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (Data != null)
            {
                String buffer;
                var request = context.HttpContext.Request;
                var serializer = new JavaScriptSerializer();
                if (request[JsonpCallbackName] != null)
                    buffer = String.Format("{0}({1})", request[JsonpCallbackName], serializer.Serialize(Data));
                else
                    buffer = serializer.Serialize(Data);
                response.Write(buffer);
            }
        }
    }

    public static class ContollerExtensions
    {
        /// <summary>
        /// Extension methods for the controller to allow jsonp.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static JsonpResult Jsonp(this Controller controller, object data)
        {
            JsonpResult result = new JsonpResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            return result;
        }
    } 

    #endregion
}