using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Common.Helper
{
    public static class DateTimeHelper
    {
        public static string CaculateWeekDay(int y, int m, int d)
        {
            if (m == 1) m = 13;
            if (m == 2) m = 14;
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7 + 1;
            string weekstr = "";
            switch (week)
            {
                case 1: weekstr = "一"; break;
                case 2: weekstr = "二"; break;
                case 3: weekstr = "三"; break;
                case 4: weekstr = "四"; break;
                case 5: weekstr = "五"; break;
                case 6: weekstr = "六"; break;
                case 7: weekstr = "日"; break;
            }

            return weekstr;
        }

        public static string showTime(DateTime? ctime)
        {
            //System.out.println("当前时间是："+new Timestamp(System.currentTimeMillis()));  
            //System.out.println("发布时间是："+df.format(ctime).toString());  
            String r = "";
            if (ctime == null) return r;


            TimeSpan span = DateTime.Now - ctime.Value;

            ;
            int result = (Math.Round(span.TotalSeconds)).ToInt();

            if (result < 60)
            {// 一分钟内  
                int seconds = result;
                if (seconds == 0)
                {
                    r = "刚刚";
                }
                else
                {
                    r = seconds + "秒前";
                }
            }
            else if (result >= 60 && result < 3600)
            {// 一小时内  
                int seconds = result / 60;
                r = seconds + "分钟前";
            }
            else if (result >= 3600 && result < 86400)
            {// 一天内  
                int seconds = result / 3600;
                r = seconds + "小时前";
            }
            else if (result >= 86400 && result < 2592000)
            {// 三十天内  
                int seconds = result / 86400;
                r = seconds + "天前";
            }
            else
            {// 日期格式  
                ;
            }
            return r;
        }
    }
}