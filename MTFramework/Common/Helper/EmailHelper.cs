using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;
using HtmlAgilityPack;
using MT.Models;
using System.Web;
using System.Web.Mail;


namespace MT.Common
{
    /// <summary>  
    /// Description : 邮件发送辅助类  
    /// </summary>  
    public class EmailHelper
    {
        #region [ 属性(发送Email相关) ]  
        /// <summary>  
        /// smtp 服务器   
        /// </summary>  
        private string SmtpHost
        {
            get; set;
        }
        /// <summary>  
        /// smtp 服务器端口  默认为25  
        /// </summary>  
        private string SmtpPort
        {
            get; set;
        }
        /// <summary>  
        /// 发送者 Eamil 地址  
        /// </summary>  
        private string FromEmailAddress
        {
            get; set;
        }

        /// <summary>  
        /// 发送者 Eamil 密码  
        /// </summary>  
        private string FormEmailPassword
        {
            get; set;
        }

        /// <summary>  
        /// 是否启用ssl
        /// </summary>  
        private bool EnableSsl
        {
            get; set;
        }
        #endregion

        #region [ 属性(邮件相关) ]  
        /// <summary>  
        /// 收件人 Email 列表，多个邮件地址之间用 半角逗号 分开  
        /// </summary>  
        public string ToList { get; set; }
        /// <summary>  
        /// 邮件的抄送者，支持群发，多个邮件地址之间用 半角逗号 分开  
        /// </summary>  
        public string CCList { get; set; }
        /// <summary>  
        /// 邮件的密送者，支持群发，多个邮件地址之间用 半角逗号 分开  
        /// </summary>  
        public string BccList { get; set; }
        /// <summary>  
        /// 邮件标题  
        /// </summary>  
        public string Subject { get; set; }
        /// <summary>  
        /// 邮件正文  
        /// </summary>  
        public string Body { get; set; }

        private bool _IsBodyHtml = true;
        /// <summary>  
        /// 邮件正文是否为Html格式  
        /// </summary>  
        public bool IsBodyHtml
        {
            get { return _IsBodyHtml; }
            set { _IsBodyHtml = value; }
        }
        /// <summary>  
        /// 附件列表  
        /// </summary>  
        public List<Attachment> AttachmentList { get; set; }
        #endregion

        #region [ 构造函数 ]  
        /// <summary>  
        /// 构造函数 (body默认为html格式)  
        /// </summary>  
        /// <param name="sendEmailAddress">发件人邮箱地址</param>  
        /// <param name="sendEmailPassword">发件人密码</param>  
        /// <param name="smtpHost">smtp地址</param>  
        /// <param name="smtpPort">smtp端口</param>  
        /// <param name="enableSsl">是否启用ssl</param>  
        /// <param name="toList">收件人列表</param>  
        /// <param name="subject">邮件标题</param>  
        /// <param name="body">邮件正文</param>  
        public EmailHelper(string sendEmailAddress, string sendEmailPassword, string smtpHost, string smtpPort, bool enableSsl, string toList, string subject, string body)
        {
            this.FromEmailAddress = sendEmailAddress;
            this.FormEmailPassword = sendEmailPassword;
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.EnableSsl = enableSsl;

            this.ToList = toList;
            this.Subject = subject;
            this.Body = body;
        }
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="sendEmailAddress">发件人邮箱地址</param>  
        /// <param name="sendEmailPassword">发件人密码</param>  
        /// <param name="smtpHost">smtp地址</param>  
        /// <param name="smtpPort">smtp端口</param>  
        /// <param name="enableSsl">是否启用ssl</param>  
        /// <param name="toList">收件人列表</param>  
        /// <param name="subject">邮件标题</param>  
        /// <param name="isBodyHtml">邮件正文是否为Html格式</param>  
        /// <param name="body">邮件正文</param>  
        public EmailHelper(string sendEmailAddress, string sendEmailPassword, string smtpHost, string smtpPort, bool enableSsl, string toList, string subject, bool isBodyHtml, string body)
        {
            this.FromEmailAddress = sendEmailAddress;
            this.FormEmailPassword = sendEmailPassword;
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.EnableSsl = enableSsl;

            this.ToList = toList;
            this.Subject = subject;
            this.IsBodyHtml = isBodyHtml;
            this.Body = body;
        }
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="sendEmailAddress">发件人邮箱地址</param>  
        /// <param name="sendEmailPassword">发件人密码</param>  
        /// <param name="smtpHost">smtp地址</param>  
        /// <param name="smtpPort">smtp端口</param>  
        /// <param name="enableSsl">是否启用ssl</param>  
        /// <param name="toList">收件人列表</param>  
        /// <param name="ccList">抄送人列表</param>  
        /// <param name="bccList">密送人列表</param>  
        /// <param name="subject">邮件标题</param>  
        /// <param name="isBodyHtml">邮件正文是否为Html格式</param>  
        /// <param name="body">邮件正文</param>  
        public EmailHelper(string sendEmailAddress, string sendEmailPassword, string smtpHost, string smtpPort, bool enableSsl, string toList, string ccList, string bccList, string subject, bool isBodyHtml, string body)
        {
            this.FromEmailAddress = sendEmailAddress;
            this.FormEmailPassword = sendEmailPassword;
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.EnableSsl = enableSsl;

            this.ToList = toList;
            this.CCList = ccList;
            this.BccList = bccList;
            this.Subject = subject;
            this.IsBodyHtml = isBodyHtml;
            this.Body = body;
        }
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="sendEmailAddress">发件人邮箱地址</param>  
        /// <param name="sendEmailPassword">发件人密码</param>  
        /// <param name="smtpHost">smtp地址</param>  
        /// <param name="smtpPort">smtp端口</param>  
        /// <param name="enableSsl">是否启用ssl</param> 
        /// <param name="toList">收件人列表</param>  
        /// <param name="ccList">抄送人列表</param>  
        /// <param name="bccList">密送人列表</param>  
        /// <param name="subject">邮件标题</param>  
        /// <param name="isBodyHtml">邮件正文是否为Html格式</param>  
        /// <param name="body">邮件正文</param>  
        /// <param name="attachmentList">附件列表</param>  
        public EmailHelper(string sendEmailAddress, string sendEmailPassword, string smtpHost, string smtpPort, bool enableSsl, string toList, string ccList, string bccList, string subject, bool isBodyHtml, string body, List<Attachment> attachmentList)
        {
            this.FromEmailAddress = sendEmailAddress;
            this.FormEmailPassword = sendEmailPassword;
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.EnableSsl = enableSsl;

            this.ToList = toList;
            this.CCList = ccList;
            this.BccList = bccList;
            this.Subject = subject;
            this.IsBodyHtml = isBodyHtml;
            this.Body = body;
            this.AttachmentList = attachmentList;
        }
        #endregion

        #region [ 发送邮件 ]  
        ///// <summary>  
        ///// 发送邮件  
        ///// </summary>  
        ///// <returns></returns>  
        //public bool Send()
        //{
        //    try
        //    {
        //        SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient  
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network  
        //        smtp.EnableSsl = this.EnableSsl; //smtp服务器是否启用SSL加密  
        //        smtp.Host = this.SmtpHost; //指定 smtp 服务器地址  
        //        smtp.Port = Convert.ToInt32(this.SmtpPort); //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去  
        //        smtp.UseDefaultCredentials = true; //如果你的SMTP服务器不需要身份认证，则使用下面的方式，不过，目前基本没有不需要认证的了  
        //        smtp.Credentials = new NetworkCredential(this.FromEmailAddress, this.FormEmailPassword);
        //        //如果需要认证，则用下面的方式  

        //        MailMessage mm = new MailMessage(); //实例化一个邮件类  
        //        mm.Priority = MailPriority.Normal; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可  
        //        mm.From = new MailAddress(this.FromEmailAddress, "邮件", Encoding.GetEncoding(936));

        //        //收件人  
        //        if (!string.IsNullOrEmpty(this.ToList))
        //            mm.To.Add(this.ToList);
        //        //抄送人  
        //        if (!string.IsNullOrEmpty(this.CCList))
        //            mm.CC.Add(this.CCList);
        //        //密送人  
        //        if (!string.IsNullOrEmpty(this.BccList))
        //            mm.Bcc.Add(this.BccList);

        //        mm.Subject = this.Subject; //邮件标题  
        //        mm.SubjectEncoding = Encoding.GetEncoding(936); //这里非常重要，如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。  
        //        mm.IsBodyHtml = true; //邮件正文是否是HTML格式  
        //        mm.BodyEncoding = Encoding.GetEncoding(936); //邮件正文的编码， 设置不正确， 接收者会收到乱码  
        //        mm.Body = this.Body; //邮件正文  
        //        //邮件附件  
        //        if (this.AttachmentList != null && this.AttachmentList.Count > 0)
        //        {
        //            foreach (Attachment attachment in this.AttachmentList)
        //            {
        //                mm.Attachments.Add(attachment);
        //            }
        //        }
        //        //发送邮件，如果不返回异常， 则大功告成了。  
        //        smtp.Send(mm);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        /// <summary>  
        /// 发送邮件  
        /// </summary>  
        /// <returns></returns>  
        public bool Send()
        {
            try
            {
                System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
                mail.Priority = System.Web.Mail.MailPriority.Normal; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可  
                mail.From = this.FromEmailAddress;
                mail.Subject = this.Subject; //邮件标题  
                //收件人  
                if (!string.IsNullOrEmpty(this.ToList))
                    mail.To = this.ToList;
                //抄送人  
                if (!string.IsNullOrEmpty(this.CCList))
                    mail.Cc = this.CCList;
                //密送人  
                if (!string.IsNullOrEmpty(this.BccList))
                    mail.Bcc = this.BccList;

                mail.BodyFormat = System.Web.Mail.MailFormat.Html;
                mail.BodyEncoding = Encoding.GetEncoding(936); //邮件正文的编码， 设置不正确， 接收者会收到乱码  

                mail.Body = this.Body; //邮件正文  

                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //要使用的验证类型   1是基本验证
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", this.FromEmailAddress); //set your username here
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", this.FormEmailPassword); //set your password here
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", Convert.ToInt32(this.SmtpPort));//set port
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", this.EnableSsl == true ? "true" : "false");//set is ssl               
                SmtpMail.SmtpServer = this.SmtpHost;
                SmtpMail.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion



    }
}