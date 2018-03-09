using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Web;

namespace RennDotSDK.APIUtility
{
    public class SyncHttp
    {
        /// <summary>
        /// 同步方式发起http请求
        /// </summary>
        /// <param name="method">请求类型</param>
        /// <param name="url">请求URL</param>
        /// <param name="parameters">请求参数列表</param>
        /// <returns>请求返回值</returns>
        public string HttpRequest(string method, string url, List<APIParameter> parameters)
        {
            string queryString = HttpUtil.GetQueryFromParams(parameters);
            Stream responseStream = null;
            StreamReader responseReader = null;
            string responseData = null;
            if (!string.IsNullOrEmpty(queryString))
            {
                url += "?" + queryString;
            }

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method;
            webRequest.Timeout = 20000;
            try
            {
                responseStream = webRequest.GetResponse().GetResponseStream();
                responseReader = new StreamReader(responseStream);
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream = null;
                }
                responseReader.Close();
                responseReader = null;
                webRequest = null;
            }
            return responseData;
        }

        /// <summary>
        /// 同步方式发起http post请求，同时上传文件
        /// </summary>
        /// <param name="method">请求类型</param>
        /// <param name="url">请求URL</param>
        /// <param name="parameters">请求参数列表</param>
        /// <param name="file">上传文件</param>
        /// <returns>请求返回值</returns>
        public string HttpRequest(string method, string url, List<APIParameter> parameters, APIParameter file)
        {
            string queryString = HttpUtil.GetQueryFromParams(parameters);
            Stream requestStream = null;
            Stream responseStream = null;
            StreamReader responseReader = null;
            string responseData = null;

            string boundary = DateTime.Now.Ticks.ToString("x");

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method;
            webRequest.Timeout = 20000;
            try
            {
                Stream memStream = new MemoryStream();

                byte[] boundaryStart = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] boundaryEnd = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                string paramTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (APIParameter param in parameters)
                {
                    memStream.Write(boundaryStart, 0, boundaryStart.Length);
                    string formitem = string.Format(paramTemplate, param.Name, param.Value);
                    byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }

                memStream.Write(boundaryStart, 0, boundaryStart.Length);
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"{2}\"\r\n\r\n";
                string filePath = file.Value;
                string fileName = Path.GetFileName(filePath);
                string fileType = HttpUtil.GetContentType(fileName);
                string header = string.Format(headerTemplate, file.Name, fileName, fileType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                memStream.Write(headerbytes, 0, headerbytes.Length);

                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
                memStream.Write(boundaryEnd, 0, boundaryEnd.Length);
                fileStream.Close();

                webRequest.ContentType = "multipart/form-data; charset=utf-8; boundary=" + boundary;
                webRequest.ContentLength = memStream.Length;
                requestStream = webRequest.GetRequestStream();
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();
                requestStream = null;

                responseStream = webRequest.GetResponse().GetResponseStream();
                responseReader = new StreamReader(responseStream);
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                    requestStream = null;
                }

                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream = null;
                }

                if (responseReader != null)
                {
                    responseReader.Close();
                    responseReader = null;
                }

                webRequest = null;
            }

            return responseData;
        }
    }
}
