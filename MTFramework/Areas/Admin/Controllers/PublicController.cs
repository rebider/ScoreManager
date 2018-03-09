using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using GeetestSDK;
using MT.Areas.Admin.ViewModels;
using MT.Common.Helper;
using MT.Dal;
using MT.Models;
using MT.Common;
using System.IO;
using System;
using System.Collections;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using cn.jpush.api.util;
using MT.Models.ViewModels;


namespace MT.Areas.Admin.Controllers
{
    public class PublicController : System.Web.Mvc.Controller
    {
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Index(string token = "")
        {
           
            if (!string.IsNullOrEmpty(token))
            {
                if (token == MTConfig.AdminToken)
                {
                    MTConfig.CurrentUser = UserModel.FirstOrDefault("where Id = 1 ");
                }
            }

            if (MTConfig.CurrentUser == null)
            {
                return RedirectToAction("Login");
            }

            //List<NoticeModel> notmodels =
            //    NoticeModel.Fetch("select top 10 * from Notice where userid = @0 and ConfirmTime  is NULL",
            //        MTConfig.CurrentUserID);
            //foreach (var item in notmodels)
            //{
            //    item.SendDate = DateTimeHelper.showTime(item.SendTime);
            //}
            //ViewBag.notmodels = notmodels;
            //int notcount =
            //         NoticeModel.repo.ExecuteScalar<int>(
            //             "select count(*)  from Notice where userid = @0 and ConfirmTime  is NULL", MTConfig.CurrentUserID);
            //ViewBag.notcount = notcount;
            #region 刷新当前用户权限信息
            IndexViewModel model = new IndexViewModel();
            MTConfig.AuthInfo = NodeDAL.GetAccessNodeList(MTConfig.CurrentUserID);

            model.NodeList = MTConfig.AuthInfo;
            MTConfig.CurrentRole = RoleDAL.GetAllRoleByUserID(MTConfig.CurrentUserID);
            MTConfig.CurrentUser = UserModel.FirstOrDefault("where Id = @0", MTConfig.CurrentUserID);
            model.UserInfo = MTConfig.CurrentUser;
            model.GroupList = GroupDAL.GetAllGroup();

            #endregion
            return View(model);
        }

        public ActionResult Success(int time, string info, string jumpUrl)
        {
            ViewBag.time = time;
            ViewBag.info = info;
            ViewBag.jumpUrl = jumpUrl;
            return View("~/Areas/Admin/Views/Public/Success.cshtml");
        }

        public ActionResult Error(int time, string info, string jumpUrl)
        {
            ViewBag.time = time;
            ViewBag.info = info;
            ViewBag.jumpUrl = jumpUrl;
            return View("~/Areas/Admin/Views/Public/Error.cshtml");
        }

        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetProvince(string pcode)
        {
            List<AreaModel> area = new List<AreaModel>();
            if (string.IsNullOrEmpty(pcode))
            {
                area = AreaModel.Fetch(" where ParentCode = 000000");
            }
            else
            {
                area = AreaModel.Fetch(" where ParentCode = @0", pcode);

            }
            return Json(new { data = area }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            HttpCookie clientCookie = Request.Cookies[MTConfig.LoginRememberCookie];
            UserModel model = new UserModel();
            if (clientCookie != null)
            {
                model = UserDAL.GetUser(clientCookie.Values[MTConfig.UserInfoKey].ToInt());
                if (model != null)
                {
                    MTConfig.CurrentUser = model;
                    return RedirectToAction("Index");
                }
            }
            ViewData["EditFlag"] = true;
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserModel model, string verify, string remember)
        {

            UserAuthModel auth = null;
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return Json(new { status = 0, msg = "请输入用户名" }, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                return Json(new { status = 0, msg = "请输入密码" }, JsonRequestBehavior.AllowGet);
                //return Content("tipreadurl('请输入密码','/Admin/Public/Login');", "application/x-javascript");
            }
            if (verify.ToLower() != Session[MTConfig.VerifCodeKey].ToString().ToLower())
            {
                return Json(new { status = 2, msg = "验证码错误" }, JsonRequestBehavior.AllowGet);
            }
            model.Name = model.Name.Replace("@", "@@");
            model.Password = model.Password.Replace("@", "@@");
            model.Password = PwdThreeEncrypt.PasswordThreeMd5Encrypt(model.Password);
            MTConfig.CurrentUser = UserDAL.Login(model.Name, model.Password);

            if (MTConfig.CurrentUser != null && !string.IsNullOrEmpty(MTConfig.CurrentUser.ID))
            {
                auth = UserDAL.GetAuth(MTConfig.CurrentUser.ID.ToInt());
                if (auth.RoleList == null || auth.RoleList.Count < 1)
                {
                    return Json(new { status = 3, msg = "该账号不存在" }, JsonRequestBehavior.AllowGet);
                    //return Content("tipreadurl('该账号不存在','/Admin/Public/Login');", "application/x-javascript");
                }

                #region 获取用户登录信息并保存 IP地址与地理位置

                //IpToAddress ipadd = new IpToAddress();
                //LoginInfoModel logininfo = new LoginInfoModel();
                //string ip = ipadd.GetRealIP();
                //if (ip == "::1")
                //{
                //    logininfo.Address = "开发地址登录";
                //    logininfo.Ip = "127.0.0.1";
                //}
                //else
                //{
                //    logininfo.Ip = ip;
                //    //根据ip地址获取ip归属地
                //    string address = ipadd.GetIpAddress(ip);
                //    logininfo.Address = address;
                //}

                //logininfo.UserId = MTConfig.CurrentUser.Id.ToInt();
                //logininfo.LoginTime = DateTime.Now;
                //logininfo.Insert();

                #endregion

                if (!string.IsNullOrEmpty(remember))
                {
                    HttpCookie cookie = new HttpCookie(MTConfig.LoginRememberCookie);
                    cookie.Values[MTConfig.UserInfoKey] = model.ID;
                    cookie.Expires = DateTime.MaxValue;
                    Response.Cookies.Add(cookie);
                }
                return Json(new { status = 1, msg = "成功" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 3, msg = "用户名或密码错误" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie cookie = new HttpCookie(MTConfig.LoginRememberCookie);
            cookie.Values[MTConfig.UserInfoKey] = "0";
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return Redirect("/Admin/public/Login");
        }

        public ActionResult ReLogin()
        {
            ViewData["time"] = 3;
            return View();
        }

        public ActionResult NoAuth()
        {
            ViewData["time"] = 3;
            return View();
        }

        ///// <summary>
        ///// 根据手机号码获取用户信息
        ///// </summary>
        ///// <param name="phone"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult GetCustomerForPhone(string phone)
        //{
        //    if (!phone.Contains("设备"))
        //    {
        //        CustomerModel model = CustomerModel.FirstOrDefault(" where Mobile=@0 ", phone);

        //        CallRecordModel callRecord = new CallRecordModel();
        //        callRecord.CreateMan = MTConfig.CurrentUserID;
        //        callRecord.CreateTime = DateTime.Now;
        //        callRecord.Phone = phone;
        //        callRecord.DelFlag = 0;

        //        if (model == null)
        //        {
        //            callRecord.Info = "新的来电：" + phone;
        //            callRecord.Insert();
        //            return Json(new { status = 0, id = 0, msg = "新" }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            callRecord.Info = model.Name + "的来电：" + phone;
        //            callRecord.Insert();
        //            return Json(new { status = 1, id = model.Id, msg = model.Name }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //return Json(new { status = 2 }, JsonRequestBehavior.AllowGet);
        //}

        ///// 根据手机号码获取用户信息
        ///// </summary>
        ///// <param name="phone"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult GetCallResult()
        //{
        //    List<CallRecordModel> model = CallRecordModel.Fetch(" select Top 8 * from Us_Call_Record where Create_Man = @0  and convert(varchar,create_Time, 111) =@1  order by Create_Time desc", MTConfig.CurrentUserID, DateTime.Now.ToString("yyyy/MM/dd"));
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}


        /// <summary>
        /// 编译后台页面
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ActionResult Run(string token = "")
        {
            UserAuthModel auth = null;

            if (!string.IsNullOrEmpty(token))
            {
                if (token == MTConfig.AdminToken)
                {
                    auth = UserDAL.TokenLogin(token);
                    if (auth != null && auth.User != null)
                    {
                        MTConfig.CurrentUser = auth.User;
                    }
                }
            }

            if (MTConfig.CurrentUser == null)
            {
                return RedirectToAction("Login");
            }

            #region 刷新当前用户权限信息
            IndexViewModel model = new IndexViewModel();
            if (auth == null)
                auth = UserDAL.GetAuth(MTConfig.CurrentUserID.ToInt());

            MTConfig.AuthInfo = auth.NodeList.ToList();
            model.NodeList = MTConfig.AuthInfo;
            MTConfig.CurrentRole = auth.RoleList.ToList();
            MTConfig.CurrentUser = auth.User;
            model.UserInfo = MTConfig.CurrentUser;
            model.GroupList = auth.GroupList.ToList();

            #endregion
            return View(model);
        }

        [HttpGet]
        public ActionResult VerifyCode()
        {
            string verifCode = ResourceHelper.GetRandomCharNumberString(4);
            Session[MTConfig.VerifCodeKey] = verifCode;
            MemoryStream ms = ResourceHelper.CreateImage(verifCode);
            return File(ms.GetBuffer(), "image/jpeg");
        }
      

        #region 公用上传文件

        //[HttpGet]
        //public ActionResult Upload(string id, string name, string callback, string suffix, string showName, string maxlength)
        //{
        //    ViewBag.id = id;
        //    ViewBag.name = name;
        //    ViewBag.callback = callback;
        //    ViewBag.suffix = suffix;
        //    ViewBag.showName = showName;
        //    ViewBag.maxlength = maxlength;
        //    return View();
        //}

        [HttpPost]
        public ActionResult Upload(string id, FormCollection form)
        {
            
            ViewBag.id = id;
            ViewBag.msg = "上传失败";
            if (Request.Files.Count <= 0)
            {
                return Json(new { status = 2, msg = "文件不能为空" }, JsonRequestBehavior.AllowGet);

            }

            if (Request.Files[0] == null)
            {
                return Json(new { status = 2, msg = "文件不能为空" }, JsonRequestBehavior.AllowGet);

            }

            if (Request.Files[0].ContentLength <= 0)
            {
                return Json(new { status = 2, msg = "文件不能为空" }, JsonRequestBehavior.AllowGet);

            }
            //if (!string.IsNullOrEmpty(Request["maxlength"])
            //    && Request["maxlength"].ToInt() * 1024 < Request.Files[0].ContentLength)
            //{
            //    string msgstr = "请上传" + Request["maxlength"] + "kb以内的文件";
            //    return Json(new { status = 2, msg = msgstr }, JsonRequestBehavior.AllowGet);

            //}
            
            if (string.IsNullOrEmpty(Request["maxlength"])
                && Request.Files[0].ContentLength > 2000 * 1024)
            {
              
                return Json(new { status = 2, msg = "请上传2M以内的文件" }, JsonRequestBehavior.AllowGet);
            }



            byte[] imgbyte = new byte[Request.Files[0].InputStream.Length];
            Request.Files[0].InputStream.Read(imgbyte, 0, imgbyte.Length);
            string str = ImgHelper.UploadImage(imgbyte, form["showName"], Request.Files[0].FileName);


 


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            FileModel fileModel = serializer.Deserialize<FileModel>(str);
            ViewBag.id = id;
            ViewBag.fileId = fileModel.ID;
            ViewBag.fileName = fileModel.ShowName;

            if (!IsAllowedExtension(MTConfig.SaveBasePath + fileModel.PathName))//验证木马文件
            {
                return Json(new { status = 2, msg = "文件格式错误" }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { status = 1, id = fileModel.ID, name = fileModel.ShowName }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 验证木马
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static bool IsAllowedExtension(string filePath)
        {
            bool result = false;
            try
            {
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
                string strContent = sr.ReadToEnd();
                sr.Close();
                string str = "request|.getfolder|.createfolder|.deletefolder|.createdirectory|.deletedirectory|.saveas";
                str += "|eval|wscript.shell|script.encode|server.|.createobject|execute|activexobject|language=";
                foreach (string s in str.Split('|'))
                {
                    if (strContent.IndexOf(s) != -1)
                    {
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                            fi.Delete();
                        }
                        return false;
                    }
                }
                result = true;
            }
            catch(Exception e)
            {
                return false;
            }
            return result;
        }
        #endregion



        #region 导出EXCEL

        public ActionResult EmpExcel(string table, string excelname)
        {
            string sbHtml = Server.HtmlDecode(table);
            byte[] fileContents = Encoding.GetEncoding("UTF-8").GetBytes(sbHtml);
            return File(fileContents, "application/ms-excel", excelname + ".xls");
        }

        #endregion
        #region KindEditor上传

        public ActionResult KindEditorUploadJson()
        {
            //String aspxUrl = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1);

            //文件保存目录路径
            String savePath = MTConfig.KindEditorPath;

            //文件保存目录URL
            String saveUrl = MTConfig.KindEditorPath.Replace("~", "");

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            //最大文件大小
            int maxSize = 1000000;

            var imgFile = Request.Files["imgFile"];
            if (imgFile == null)
            {
                return showError("请选择文件。");
            }

            String dirPath = Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                return showError("上传目录不存在。");
            }

            String dirName = Request.QueryString["dir"];
            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                return showError("目录名不正确。");
            }

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                return showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                return showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }

            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath + newFileName;

            imgFile.SaveAs(filePath);

            String fileUrl = saveUrl + newFileName;

            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = fileUrl;
            return Json(hash, JsonRequestBehavior.AllowGet);
        }

        public ActionResult showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            return Json(hash, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FileManagerJson()
        {
            //String aspxUrl = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1);

            //根目录路径，相对路径
            String rootPath = MTConfig.KindEditorPath;
            //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
            String rootUrl = MTConfig.KindEditorPath.Replace("~", "");
            //图片扩展名
            String fileTypes = "gif,jpg,jpeg,png,bmp";

            String currentPath = "";
            String currentUrl = "";
            String currentDirPath = "";
            String moveupDirPath = "";

            String dirPath = Server.MapPath(rootPath);
            String dirName = Request.QueryString["dir"];
            if (!String.IsNullOrEmpty(dirName))
            {
                if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1)
                {
                    Response.Write("Invalid Directory name.");
                    Response.End();
                }
                dirPath += dirName + "/";
                rootUrl += dirName + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }

            //根据path参数，设置各路径和URL
            String path = Request.QueryString["path"];
            path = String.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            String order = Request.QueryString["order"];
            order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                Response.Write("Access is not allowed.");
                Response.End();
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                Response.Write("Parameter is not valid.");
                Response.End();
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                Response.Write("Directory does not exist.");
                Response.End();
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = new FileInfo(fileList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Convert()
        {
            //try
            //{
            //    string swftools = Server.MapPath("~/Tools/swftools.exe");
            //    Process pc = new Process();
            //    ProcessStartInfo psi = new ProcessStartInfo(swftools, @"E:\资料\Flash资料\flexpaper\FlexPaper_2.2.4\pdf\Paper.pdf E:\资料\Flash资料\flexpaper\FlexPaper_2.2.4\pdf\Paper.swf");
            //    psi.CreateNoWindow = true;
            //    pc.StartInfo = psi;
            //    pc.Start();
            //    pc.WaitForExit();

            //    return Content("convert success");
            //}
            //catch (Exception)
            //{
            //    return Content("convert error");
            //}
            return View();
        }

        #endregion

    }

    #region 上传文件管理排序

    public class NameSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.FullName.CompareTo(yInfo.FullName);
        }
    }

    public class SizeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Length.CompareTo(yInfo.Length);
        }
    }

    public class TypeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Extension.CompareTo(yInfo.Extension);
        }
    }

    #endregion
}
