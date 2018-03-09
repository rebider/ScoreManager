
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Web;

namespace MT.Common
{
    public class LTCPClient
    {
        /// <summary>
        /// 当前客户端名称
        /// </summary>
        private string _Name = "未定义";
        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public void SetName()
        {
            if (_NetWork.Connected)
            {
                //IPEndPoint iepR = (IPEndPoint)_NetWork.Client.RemoteEndPoint;
                //IPEndPoint iepL = (IPEndPoint)_NetWork.Client.LocalEndPoint;
                //_Name = iepL.Port + "->" + iepR.ToString();
            }
        }

        /// <summary>
        /// TCP客户端
        /// </summary>
        private TcpClient _NetWork = null;
        public TcpClient NetWork
        {
            get
            {
                return _NetWork;
            }
            set
            {
                _NetWork = value;
                SetName();
            }
        }


        /// <summary>
        /// 数据接收缓存区
        /// </summary>
        public byte[] buffer = new byte[2048];

        /// <summary>
        /// 断开客户端连接
        /// </summary>
        public void DisConnect()
        {
            try
            {
                if (_NetWork != null && _NetWork.Connected)
                {
                    NetworkStream ns = _NetWork.GetStream();
                    ns.Close();
                    _NetWork.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    public class MyTCPClient
    {
        public int code = -1;
        public string msg = "";
        public string result = "";
        public LTCPClient client = new LTCPClient();
        public string ip;
        public int port;
        public int outtime = 15;
        public MyTCPClient(string IP, int Port)
        {
            ip = IP;
            port = Port;
        }
        public bool Content(int time = 15)
        {
            try
            {
                this.outtime = time;
                client.NetWork = new System.Net.Sockets.TcpClient();
                client.NetWork.Connect(ip, port);//连接服务端
                client.SetName();
                client.NetWork.ReceiveTimeout = outtime * 1000;
                client.NetWork.GetStream().BeginRead(client.buffer, 0, client.buffer.Length, new AsyncCallback(TCPCallBack), client);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取返回数据
        /// </summary>
        /// <returns></returns>
        public int GetResult()
        {
            int temptime = this.outtime * 10;
            //超时判断
            int time = 1;
            while (code == -1 && time < temptime)
            {
                Thread.Sleep(100);
                time++;
            }
            if (time == temptime)
            {
                code = 500;
                msg = "操作失败!";
            }

            return code;
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SendData(string info)
        {
            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(info);
                client.NetWork.GetStream().Write(data, 0, data.Length); return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void TCPCallBack(IAsyncResult ar)
        {
            LTCPClient client = (LTCPClient)ar.AsyncState;
            if (client.NetWork.Connected)
            {
                NetworkStream ns = client.NetWork.GetStream();
                try
                {
                    byte[] recdata = new byte[ns.EndRead(ar)];
                    Array.Copy(client.buffer, recdata, recdata.Length);
                    if (recdata.Length > 0)
                    {
                        string str = System.Text.Encoding.UTF8.GetString(recdata).Replace("\r\n", ""); //new ASCIIEncoding().GetString(recdata); 
                        result = str;
                        code = 0;

                    }
                    else
                    {
                        code = 1;
                        client.DisConnect();
                    }
                }
                catch
                {
                    client.DisConnect();
                }
            }
        }
        public void DisConnect()
        {

            if (client.NetWork.Connected)
            {
                client.NetWork.Close();
                client.DisConnect();
            }
        }

    }
}