using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using cn.jpush.api;
using cn.jpush.api.push;
using cn.jpush.api.report;
using cn.jpush.api.common;
using cn.jpush.api.util;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using cn.jpush.api.common.resp;
using MT.Models;
namespace MT.Common.JPush
{
    class JPushApiExample
    {
        //public static String TITLE = "Test from C# v3 sdk";
        //public static String ALERT = "Test from  C# v3 sdk - alert";
        //public static String MSG_CONTENT = "Test from C# v3 sdk - msgContent";
        //public static String REGISTRATION_ID = "0900e8d85ef";
        //public static String TAG = "tag_api";
        //public static String app_key = "17a5eb963edcbd8ef0d954e4";
        //public static String master_secret = "4b6d3a888eba4ab44c12af36";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="alert">标题</param>
        /// <param name="msgcontent">内容</param>
        /// <param name="tag">tag 多条“,”隔开</param>
        /// <param name="alias">alias 多条“,”隔开</param>
        /// <param name="type">推送类型</param>
        public static int Main(string title, string alert, string alias, string activity = "", string app_key = "", string master_secret="")
        {
            string REGISTRATION_ID = "0900e8d85ef";
            //string app_key = "17a5eb963edcbd8ef0d954e4";
            //string master_secret = "4b6d3a888eba4ab44c12af36";

           //if(activity == MTConfig.ActivityName.教师拼单未开始)
           //{
           //    List<XUserModel> list = UserModel.Fetch("where User_Type = @0", MTConfig.UserType.Teacher);
           //    alias = string.Join(",", list.Select(s => s.Id));
           //    if(string.IsNullOrEmpty(alias))
           //    {
           //        alias = "0";
           //    }
           //}

           //if (activity == MTConfig.ActivityName.教师需求单未开始)
           //{
           //    List<XUserModel> list = UserModel.Fetch("where User_Type = @0", MTConfig.UserType.Teacher);
           //    alias = string.Join(",", list.Select(s => s.Id));
           //    if (string.IsNullOrEmpty(alias))
           //    {
           //        alias = "0";
           //    }
           //}

            JPushClient client = new JPushClient(app_key, master_secret);
            PushPayload payload = new PushPayload();
            if (string.IsNullOrEmpty(alias))
            {
                payload = PushObject_All_All_Alert(alert,title,  "", activity);
            }
            else
            {
                  payload = PushObject_All_All_Alert(alert,title, alias, activity);
            }
          
            try
            {
                var result = client.SendPush(payload);
                //由于统计数据并非非是即时的,所以等待一小段时间再执行下面的获取结果方法
                System.Threading.Thread.Sleep(10000);
                /*如需查询上次推送结果执行下面的代码*/
                var apiResult = client.getReceivedApi(result.msg_id.ToString());
                var apiResultv3 = client.getReceivedApi_v3(result.msg_id.ToString());
                /*如需查询某个messageid的推送结果执行下面的代码*/
                var queryResultWithV2 = client.getReceivedApi("1739302794"); 
                var querResultWithV3 = client.getReceivedApi_v3("1739302794");
                return 1;

            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorCode);
                return e.ErrorCode;
            }
          
        }
        public static PushPayload PushObject_All_All_Alert(string alert,string title,string alias, string activity = "")
        {
            string[] aliass = alias.Split(',');

            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();
            if (alias == "")
            {
                pushPayload.audience = Audience.all();
            }
            else
            {
                pushPayload.audience = Audience.s_alias(aliass);
            }

            pushPayload.notification = Notification.android(alert, title);
            pushPayload.notification.AndroidNotification.AddExtra("activity", activity);
            pushPayload.notification.AndroidNotification.setBuilderID(2);
            return pushPayload;
        }
        public static PushPayload PushObject_all_alias_alert(string alert,string alias)
        {

            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.android();
            pushPayload.audience = Audience.s_alias(alias);
            pushPayload.notification = new Notification().setAlert(alert);
            return pushPayload;
           
        }
        public static PushPayload PushObject_Android_Tag_AlertWithTitle(string title,string alert, string tag)
        {
            PushPayload pushPayload = new PushPayload();

            pushPayload.platform = Platform.android();
            pushPayload.audience = Audience.s_tag(tag);
            pushPayload.notification = Notification.android(alert, title);

            return pushPayload;
        }
        public static PushPayload PushObject_android_and_ios(string tag)
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.android_ios();
            var audience = Audience.s_tag(tag);
            pushPayload.audience = audience;
            var notification = new Notification().setAlert("alert content");
            notification.AndroidNotification = new AndroidNotification().setTitle("Android Title");
            notification.IosNotification = new IosNotification();
            notification.IosNotification.incrBadge(1);
            notification.IosNotification.AddExtra("extra_key", "extra_value");

            pushPayload.notification = notification.Check(); 
      

            return pushPayload;
        }
        public static PushPayload PushObject_ios_tagAnd_alertWithExtrasAndMessage(string title, string alert, string tag,string content)
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.android_ios();
            pushPayload.audience = Audience.s_tag_and(tag, "tag_all");
            var notification = new Notification();
            notification.IosNotification = new IosNotification().setAlert(alert).setBadge(5).setSound("happy").AddExtra("from", "JPush");

            pushPayload.notification = notification;
            pushPayload.message = Message.content(content);
            return pushPayload;

        }
        public static PushPayload PushObject_ios_audienceMore_messageWithExtras( string tag, string content)
        {
            
            var pushPayload = new PushPayload();
            pushPayload.platform = Platform.android_ios();
            pushPayload.audience = Audience.all();
            pushPayload.message = Message.content(content).AddExtras("from", "JPush");
            return pushPayload;

        }

    }
}
