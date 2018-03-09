using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Common.Helper
{
    public class WeChatConstant
    {
        public static string WechatConstant(string c = "")
        {
            string weekstr = "";
            switch (c)
            {
                case "-1": weekstr = "系统繁忙"; break;
                case "0": weekstr = "发布成功"; break;
                case "40001": weekstr = "验证失败"; break;
                case "40002": weekstr = "不合法的凭证类型"; break;
                case "40003": weekstr = "不合法的OpenID"; break;
                case "40004": weekstr = "不合法的媒体文件类型"; break;
                case "40005": weekstr = "不合法的文件类型"; break;
                case "40006": weekstr = "不合法的文件大小"; break;
                case "40007": weekstr = "不合法的媒体文件id"; break;
                case "40008": weekstr = "不合法的消息类型"; break;
                case "40009": weekstr = "不合法的图片文件大小"; break;
                case "40010": weekstr = "不合法的语音文件大小"; break;
                case "40011": weekstr = "不合法的视频文件大小"; break;
                case "40012": weekstr = "不合法的缩略图文件大小"; break;
                case "40013": weekstr = "不合法的APPID"; break;
                case "40014": weekstr = "不合法的access_token"; break;
                case "40015": weekstr = "不合法的菜单类型"; break;
                case "40016": weekstr = "不合法的按钮个数"; break;
                case "40017": weekstr = "不合法的按钮个数"; break;
                case "40018": weekstr = "不合法的按钮名字长度"; break;
                case "40019": weekstr = "不合法的按钮KEY长度"; break;
                case "40020": weekstr = "不合法的按钮URL长度"; break;
                case "40021": weekstr = "不合法的菜单版本号"; break;
                case "40022": weekstr = "不合法的子菜单级数"; break;
                case "40023": weekstr = "不合法的子菜单按钮个数"; break;
                case "40024": weekstr = "不合法的子菜单按钮类型"; break;
                case "40025": weekstr = "不合法的子菜单按钮名字长度"; break;
                case "40026": weekstr = "不合法的子菜单按钮KEY长度"; break;
                case "40027": weekstr = "不合法的子菜单按钮URL长度"; break;
                case "40028": weekstr = "不合法的自定义菜单使用用户"; break;
                case "41001": weekstr = "缺少access_token参数"; break;
                case "41002": weekstr = "缺少appid参数"; break;
                case "41003": weekstr = "缺少refresh_token参数"; break;
                case "41004": weekstr = "缺少secret参数"; break;
                case "41005": weekstr = "缺少多媒体文件数据"; break;
                case "41006": weekstr = "缺少media_id参数"; break;
                case "41007": weekstr = "缺少子菜单数据"; break;
                case "42001": weekstr = "access_token超时"; break;
                case "43001": weekstr = "需要GET请求"; break;
                case "43002": weekstr = "需要POST请求"; break;
                case "43003": weekstr = "需要HTTPS请求"; break;
                case "44001": weekstr = "多媒体文件为空"; break;
                case "44002": weekstr = "POST的数据包为空"; break;
                case "44003": weekstr = "图文消息内容为空"; break;
                case "45001": weekstr = "多媒体文件大小超过限制"; break;
                case "45002": weekstr = "消息内容超过限制"; break;
                case "45003": weekstr = "标题字段超过限制"; break;
                case "45004": weekstr = "描述字段超过限制"; break;
                case "45005": weekstr = "链接字段超过限制"; break;
                case "45006": weekstr = "图片链接字段超过限制"; break;
                case "45007": weekstr = "语音播放时间超过限制"; break;
                case "45008": weekstr = "图文消息超过限制"; break;
                case "45009": weekstr = "创建菜单个数超过限制"; break;
                case "45010": weekstr = "描述字段超过限制"; break;
                case "46001": weekstr = "不存在媒体数据"; break;
                case "46002": weekstr = "不存在的菜单版本"; break;
                case "46003": weekstr = "不存在的菜单数据"; break;
                case "47001": weekstr = "解析JSON/XML内容错误"; break;
            }

            return weekstr;
        }

    }
}