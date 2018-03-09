/* * * * *****************************************************************************************************
 * 人人网开放平台的客户端调用类，主要的操作可以通过调用这个类来获得各种数据
 * 1：GetAuthorizationCode()使用这个方法后，如果执行成功，
 *    服务器会把你的页面地址转到你callback上并附加code参数，code即为你要获得的Authorization code
 * 2：调用接口方法，使用CallMethod，如果有文件上传，调用CallMethodWithFile。
 * 3：API Key、Secre Key、各个请求URI，Format都是在Web.config中配置的
 *    (对应web开发，如果是客户端开发，自行配置APP.config).然后通过APIConfig类进行获取。
 * 4：本SDK的http请求功能有异步和同步两个方面的，但是本类中只对应同步请求的，
 *    如果想使用异步，请自行使用AsyncHttp.cs这个类。
 * 5：此SDK是从腾讯微博开放平台上搬过来的，原作者是vincent，由于腾讯没有具体给出vincent的联系方式，
 *    所以在此也只能给出作者的名字，如果知道原作者的联系方式，请告知。
 *    有问题大家可以互相讨论，我的联系方式：qdkll1985@163.com。
 * * *********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using RennDotSDK.APIUtility;
using Newtonsoft.Json.Linq;

namespace RennDotSDK
{
    public class RennClient
    {
        /// <summary>
        /// 获取 Authorization code
        /// 执行此方法后，将会访问callback地址，
        /// 返回需要访问的URL地址，形式如：http://www.exaple.com?code=xxxx
        /// code就为需要获得的Authorization code。
        /// </summary>
        public string GetAuthorizationCode()
        {
            string authorizationUrl = APIConfig.AuthorizationURL;
            List<APIParameter> parameters = new List<APIParameter>() { 
                new APIParameter("client_id",APIConfig.ApiKey),
                new APIParameter("response_type","code"),
                new APIParameter("redirect_uri",APIConfig.CallBackURL)
            };
            return HttpUtil.AddParametersToURL(authorizationUrl, parameters);
        }

        /// <summary>
        /// 执行接口方法
        /// 传入参数列表，比如接口名称，参宿，文件等
        /// 还可以上传文件
        /// </summary>
        /// <param name="path">接口名称</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="file">文件</param>
        /// <returns>服务器响应数据</returns>
        public string RequestWithFile(string path, List<APIParameter> parameters, APIParameter file)
        {
            string responseData = "";
            APIValidation av = new APIValidation();
            parameters.Add(new APIParameter("access_token", av.GetAccessToken()));
            string url = APIConfig.RennAPIURL + path;
            responseData = new SyncHttp().HttpRequest("POST", url, parameters, file);
            return responseData;
        }
        /// <summary>
        /// 执行API接口请求方法
        /// 传入参数列表，比如接口名称，参数等
        /// </summary>
        /// <param name="method">请求类型</param>
        /// <param name="path">接口名称</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>服务器响应数据</returns>
        public string Request(string method, string path, List<APIParameter> parameters)
        {
            string responseData = "";
            APIValidation av = new APIValidation();
            parameters.Add(new APIParameter("access_token", av.GetAccessToken()));
            string url = APIConfig.RennAPIURL + path;
            responseData = new SyncHttp().HttpRequest(method, url, parameters);
            return responseData;
        }
    }
}
