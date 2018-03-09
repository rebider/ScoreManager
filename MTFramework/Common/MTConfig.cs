//*****************************************************************
//
// File Name:   StyleReference
//
// Description: 获取样式项目地址
//
// Coder:       Liujianglin
//
// Date:        2013-06-26
//
// History:     1、2013-06-26 Create by Liujianglin
//   
//*****************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MT.Models;
using System.Web.Mvc;


namespace MT.Common
{
    public class MTConfig
    {
        //订单类型常量
        public enum OrderTypes
        {
            未知 = 0,
            充值 = 1,
            提现 = 2,
            配资 = 3,
            入金 = 4,
            出金 = 5
        }

        //
        // 摘要:交易订单的类型
        //    
        public enum TradeCommand
        {
            //
            // 摘要:
            //     Buy
            Buy = 0,
            //
            // 摘要:
            //     Sell
            Sell = 1,
            //
            // 摘要:
            //     Buy limit
            BuyLimit = 2,
            //
            // 摘要:
            //     Sell limit
            SellLimit = 3,
            //
            // 摘要:
            //     Buy stop
            BuyStop = 4,
            //
            // 摘要:
            //     Sell stop
            SellStop = 5,
            //
            // 摘要:
            //     Balance
            Balance = 6,
            //
            // 摘要:
            //     Credit
            Credit = 7
        }

        /// <summary>
        /// Exp
        /// </summary>
        public static string Exp = ConfigurationManager.AppSettings["Exp"];
        public static string SaveBasePath = ConfigurationManager.AppSettings["SaveBasePath"];
        public static string CssAddress = ConfigurationManager.AppSettings["StyleReference"];

        public static string ScriptAddress = ConfigurationManager.AppSettings["ScriptReference"];

        public static string MT4DefaultGroupName = ConfigurationManager.AppSettings["MT4DefaultGroupName"];

        public static int ItemsPerPage = int.Parse(ConfigurationManager.AppSettings["ItemsPerPage"]);

        public static int DialogPerPage = int.Parse(ConfigurationManager.AppSettings["DialogPerPage"]);

        public static bool IsLog = bool.Parse(ConfigurationManager.AppSettings["IsLog"]);

        public static string ResourceServer = ConfigurationManager.AppSettings["ResourceServer"];

        public static string ImageServer = ConfigurationManager.AppSettings["ImageServer"];

        public static string AdminToken = ConfigurationManager.AppSettings["AdminToken"];

        public static string TitleSuffix = ConfigurationManager.AppSettings["TitleSuffix"];

        public static string AppId = ConfigurationManager.AppSettings["AppId"];

        public static string Token = ConfigurationManager.AppSettings["Token"];

        public static string AppSecret = ConfigurationManager.AppSettings["AppSecret"];

        public static string MapKey = ConfigurationManager.AppSettings["MapKey"];

        public static string MapTableId = ConfigurationManager.AppSettings["MapTableId"];
        //韦德web url
        public static string WestWebUrl = ConfigurationManager.AppSettings["WestWebUrl"];
       //韦德web url
        public static string CRMUrl = ConfigurationManager.AppSettings["CRMUrl"];

        //公司中文名称
        public static string CompanyNameCn = ConfigurationManager.AppSettings["CompanyNameCn"];
        //公司英文名称 
        public static string CompanyNameEn = ConfigurationManager.AppSettings["CompanyNameEn"];
        //代理登录地址
        public static string IBLoginUrl = ConfigurationManager.AppSettings["IBLoginUrl"];
        //客户登录地址
        public static string CusLoginUrl = ConfigurationManager.AppSettings["CusLoginUrl"];
        //邮件模板背景图地址
        public static string BackPicUrl = ConfigurationManager.AppSettings["BackPicUrl"];
        //网站Title
        public static string WebTitle= ConfigurationManager.AppSettings["WebTitle"];
        /// <summary>
        /// 环信id
        /// </summary>
        public static string ClientId = ConfigurationManager.AppSettings["ClientId"];

        /// <summary>
        /// 环信Secret
        /// </summary>
        public static string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];

        public static string OpenAppId = "wxc419afed4cf80b8e";

        public static string OpenAppSecret = "2ad6cc6cb607130ae476ad452144e02c";

        public static string XiuxiuUploadServer = ConfigurationManager.AppSettings["XiuxiuUploadServer"];

        /// <summary>
        /// 平台id
        /// </summary>
        public static string PlatformId = ConfigurationManager.AppSettings["PlatformId"];

        /// <summary>
        /// 是否使用静态页面
        /// </summary>
        public static string IsStatic = ConfigurationManager.AppSettings["IsStatic"];

        /// <summary>
        /// 权限节点信息
        /// </summary>
        public const string AuthInfoKey = "AuthInfoKey";

        /// <summary>
        /// 验证码key
        /// </summary>
        public const string VerifCodeKey = "VerifCode";


        /// <summary>
        /// 极验证秘钥
        /// </summary>
        public static string GeetestPrivateKey = ConfigurationManager.AppSettings["GeetestPrivateKey"];

        /// <summary>
        /// 一级节点信息
        /// </summary>
        public const string AuthInfoKey1 = "AuthInfoKey1";

        /// <summary>
        /// 二级节点信息
        /// </summary>
        public const string AuthInfoKey2 = "AuthInfoKey2";

        /// <summary>
        /// 三级节点信息
        /// </summary>
        public const string AuthInfoKey3 = "AuthInfoKey3";

        /// <summary>
        /// session存放用户信息的key
        /// </summary>
        public const string UserInfoKey = "UserInfoKey";

        /// <summary>
        /// session存放用户信息的key
        /// </summary>
        public const string XUserInfoKey = "XUserInfoKey";

        /// <summary>
        /// session用户语言key
        /// </summary>
        public const string UserLangKey = "UserLangKey";
        /// <summary>
        /// 普通用户角色
        /// </summary>
        public const int CommonRoleId = 4;

        /// <summary>
        /// 列表页面没有数据的提示信息
        /// </summary>
        public const string ListNoData = "暂无数据";

        /// <summary>
        /// 删除确认提示
        /// </summary>
        public const string DeleteConfirm = "return confirm('您确定要删除该数据吗？');";

        /// <summary>
        /// 角色信息
        /// </summary>
        public const string RoleInfoKey = "RoleInfoKey";
        /// <summary>
        /// 邮箱激活码
        /// </summary>
        public const string ActiveCodeKey = "ActiveCodeKey";
       

        #region Cookie相关

        public const string LoginRememberCookie = "pk_l";

        public const string LoginTimeCookie = "time_c";

        #endregion

        /// <summary>
        /// 当前登录用户的信息
        /// </summary>
        public static UserModel CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[MTConfig.UserInfoKey] != null)
                {
                    return HttpContext.Current.Session[MTConfig.UserInfoKey] as UserModel;
                }
                return null;
            }
            set { HttpContext.Current.Session[MTConfig.UserInfoKey] = value; }
        }

        public static UserInfoModel CurrentUserInfo
        {
            get
            {
                if (HttpContext.Current.Session[MTConfig.XUserInfoKey] != null)
                {
                    return HttpContext.Current.Session[MTConfig.XUserInfoKey] as UserInfoModel;
                }
                return null;
            }
            set { HttpContext.Current.Session[MTConfig.XUserInfoKey] = value; }
        }

        /// <summary>
        /// 设置用户语言
        /// </summary>
        public static string UserLang
        {
            get
            {
                if (HttpContext.Current.Session[MTConfig.UserLangKey] != null)
                {
                    return HttpContext.Current.Session[MTConfig.UserLangKey]+"";
                }
                return null;
            }
            set { HttpContext.Current.Session[MTConfig.UserLangKey] = value; }
        }

        /// <summary>
        /// 设置结算佣金缓存
        /// </summary>
        public static string AgentBonus
        {
            get
            {
                if (HttpContext.Current.Session["AgentBonus"] != null)
                {
                    return HttpContext.Current.Session["AgentBonus"] + "";
                }
                return null;
            }
            set { HttpContext.Current.Session["AgentBonus"] = value; }
        }
        /// <summary>
        /// 设置注册邮件激活码
        /// </summary>
        public static string ActiveCode
        {
            get
            {
                if (HttpContext.Current.Session[MTConfig.ActiveCodeKey] != null)
                {
                    return HttpContext.Current.Session[MTConfig.ActiveCodeKey] + "";
                }
                return null;
            }
            set { HttpContext.Current.Session[MTConfig.ActiveCodeKey] = value; }
        }
        /// <summary>
        /// 当前登录用户的信息
        /// </summary>
        //public static UserModel CurrentXUser
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[XUserInfoKey] != null)
        //        {
        //            return HttpContext.Current.Session[XUserInfoKey] as XUserModel;
        //        }
        //        return null;
        //    }
        //    set { HttpContext.Current.Session[XUserInfoKey] = value; }
        //}

        public const string SystemUserName = "";

        /// <summary>
        /// 当前用户的姓名
        /// </summary>
        public static string CurrentUserName
        {
            get
            {
                if (CurrentUser == null)
                {
                    return SystemUserName;
                }
                else
                {
                    return CurrentUser.Name;
                }
            }
        }

        /// <summary>
        /// 当前用户ID
        /// </summary>
        public static string CurrentUserID
        {
            get
            {
                if (CurrentUser == null)
                {
                    return "0";
                }
                else
                {
                    return CurrentUser.ID;
                }
            }
        }

        public static List<NodeModel> AuthInfo
        {
            get
            {
                return HttpContext.Current.Session[AuthInfoKey] == null ? null : (HttpContext.Current.Session[AuthInfoKey] as List<NodeModel>);
            }
            set
            {
                HttpContext.Current.Session[AuthInfoKey1] = value.Where(s => s.NodeLevel == 1).ToList();
                HttpContext.Current.Session[AuthInfoKey2] = value.Where(s => s.NodeLevel == 2).ToList();
                HttpContext.Current.Session[AuthInfoKey3] = value.Where(s => s.NodeLevel == 3).ToList();
                HttpContext.Current.Session[AuthInfoKey] = value;
            }
        }

        /// <summary>
        /// 一级访问节点信息
        /// </summary>
        public static List<NodeModel> AuthInfo1
        {
            get
            {
                return HttpContext.Current.Session[AuthInfoKey1] == null ? null : (HttpContext.Current.Session[AuthInfoKey1] as List<NodeModel>);
            }
        }

        /// <summary>
        /// 二级访问节点信息
        /// </summary>
        public static List<NodeModel> AuthInfo2
        {
            get
            {
                return HttpContext.Current.Session[AuthInfoKey2] == null ? null : (HttpContext.Current.Session[AuthInfoKey2] as List<NodeModel>);
            }
        }

        /// <summary>
        /// 三级访问节点信息
        /// </summary>
        public static List<NodeModel> AuthInfo3
        {
            get
            {
                return HttpContext.Current.Session[AuthInfoKey3] == null ? null : (HttpContext.Current.Session[AuthInfoKey3] as List<NodeModel>);
            }
        }

        /// <summary>
        /// 当前角色信息
        /// </summary>
        public static List<RoleModel> CurrentRole
        {
            set
            {
                HttpContext.Current.Session[RoleInfoKey] = value;
            }
            get
            {
                var obj = HttpContext.Current.Session[RoleInfoKey];
                return obj == null ? (new List<RoleModel>()) : ((List<RoleModel>)obj);
            }
        }

        /// <summary>
        /// 上传文件路径
        /// </summary>
        public static string UploadPath = "~/Uploads/";

        /// <summary>
        /// KindEditor上传路径
        /// </summary>
        public static string KindEditorPath = "~/Attached/";

        /// <summary>
        /// 发送邮件类型
        /// </summary>
        public struct Language
        {

            /// <summary>
            /// 中文
            /// </summary>
            public const string Cn = "Cn";

            /// <summary>
            /// 英文
            /// </summary>
            public const string En = "En";
        }
        /// <summary>
        /// 发送邮件类型返回类型
        /// </summary>
        public struct SendEmailResultType
        {
            /// <summary>
            /// 发送失败
            /// </summary>
            public const string SendError = "发送失败";

            /// <summary>
            /// 发送成功
            /// </summary>
            public const string SendSuccess = "发送成功";

            /// <summary>
            /// 无此用户或者邮箱
            /// </summary>
            public const string NotEmaulOrUser = "无此用户或者邮箱";

            /// <summary>
            /// 邮箱地址为空
            /// </summary>
            public const string EmptyEmail = "邮箱地址为空";

            /// <summary>
            /// 电子邮箱格式错误
            /// </summary>
            public const string EmailError = "电子邮箱格式错误";

            /// <summary>
            /// 用户id或者email为空
            /// </summary>
            public const string EmptyEmailOrUser = "用户id或者email为空";

            /// <summary>
            /// 更新失败
            /// </summary>
            public const string UpdateError = "更新失败";


            /// <summary>
            /// 更新失败
            /// </summary>
            public const string EmptyaAccount = "账户id为空";


        }

        /// <summary>
        /// 发送邮件类型
        /// </summary>
        public struct SendEmailType
        {
            /// <summary>
            /// 创建账户(中文)
            /// </summary>
            public const string CreateAccountCn = "1";

            /// <summary>
            /// 创建账户(英文)
            /// </summary>
            public const string CreateAccountEn = "2";


            /// <summary>
            /// 修改密码(中文)
            /// </summary>
            public const string ForgetPasswordCn = "3";


            /// <summary>
            /// 修改密码(英文)
            /// </summary>
            public const string ForgetPasswordEn = "4";

            /// <summary>
            /// 空白模板
            /// </summary>
            public const string Default = "5";
        }

        /// <summary>
        /// 流水类型
        /// </summary>
        public struct MoneyStreamType
        {
            /// <summary>
            /// 入金
            /// </summary>
            public const string In = "1";

            /// <summary>
            /// 出金
            /// </summary>
            public const string Out = "2";

            /// <summary>
            /// 钱包转交易账户
            /// </summary>
            public const string WalletToAccount = "3";

            /// <summary>
            /// 交易账户转钱包
            /// </summary>
            public const string AccountToWallet = "4";

            ///<summary>
            /// 交易账户转交易账户
            /// </summary>
            public const string WalletToWallet = "7";

        }

        /// <summary>
        /// 金额流水操作返回结果
        /// </summary>
        public struct MoneyStreamResultType
        {
            /// <summary>
            /// 执行成功
            /// </summary>
            public const string Success = "1";

            /// <summary>
            /// 余额不足
            /// </summary>
            public const string BalanceNotEnough = "4";

            /// <summary>
            /// 用户更新失败
            /// </summary>
            public const string UserUpdateError = "2";
            /// <summary>
            /// 流水添加失败，在流水操作失败时，用户肯定没有操作
            /// </summary>
            public const string MoneyStreamInsError = "3";


        }

        /// <summary>
        /// 流水状态
        /// </summary>
        public struct MoneyStreamStatusType
        {
            /// <summary>
            /// 成功
            /// </summary>
            public const int Success = 1;

            /// <summary>
            /// 失败
            /// </summary>
            public const int Error = 2;

            /// <summary>
            /// 失败
            /// </summary>
            public const int Outing =3;

        }

        #region 以前配置

        /// <summary>
        /// 角色类型
        /// </summary>
        public struct RoleType
        {
            /// <summary>
            /// 管理员
            /// </summary>
            public const string Administrator = "管理员";

            /// <summary>
            /// 公司高层
            /// </summary>
            public const string GeneralManager = "公司高层";

            /// <summary>
            /// 主管
            /// </summary>
            public const string Manager = "主管";

            /// <summary>
            /// 员工
            /// </summary>
            public const string Staff = "员工";

        }

        /// <summary>
        /// 用户类型
        /// </summary>
        public struct UserType
        {
            /// <summary>
            /// 一般用户
            /// </summary>
            public const string NormalUser = "用户";

            /// <summary>
            /// 管理员
            /// </summary>
            public const string Administrator = "管理员";

            /// <summary>
            /// 商家
            /// </summary>
            public const string CompanyUser = "商家";

            /// <summary>
            /// 学员
            /// </summary>
            public const string Student = "学员";

            /// <summary>
            /// 教师
            /// </summary>
            public const string Teacher = "教师";

            /// <summary>
            /// 一般用户
            /// </summary>
            public const string User = "一般用户";
        }

        /// <summary>
        /// 支付状态
        /// </summary>
        public struct PayStatus
        {

            /// <summary>
            /// 未支付
            /// </summary>
            public const string NotPay = "未支付";

            /// <summary>
            /// 已支付
            /// </summary>
            public const string Payed = "已支付";

        }

        /// <summary>
        /// 评论状态
        /// </summary>
        public struct CommentStatus
        {
            /// <summary>
            /// 未评价
            /// </summary>
            public const string NotComment = "未评价";

            /// <summary>
            /// 已评价
            /// </summary>
            public const string Commented = "已评价";
        }

        /// <summary>
        /// 活动状态
        /// </summary>
        public struct ActivityStatus
        {
            /// <summary>
            /// 未开始
            /// </summary>
            public const string NotStart = "未开始";

            /// <summary>
            /// 进行中
            /// </summary>
            public const string Starting = "进行中";

            /// <summary>
            /// 已结束
            /// </summary>
            public const string End = "已结束";

        }

        /// <summary>
        /// 支付方式
        /// </summary>
        public struct PayMethod
        {

            /// <summary>
            /// 余额支付
            /// </summary>
            public const string Balance = "余额支付";

            /// <summary>
            /// 支付宝
            /// </summary>
            public const string Alipay = "支付宝";

            /// <summary>
            /// 财付通
            /// </summary>
            public const string Tenpay = "财付通";

        }

        /// <summary>
        /// 退款状态
        /// </summary>
        public struct RefundStatus
        {

            /// <summary>
            /// 待审核
            /// </summary>
            public const string WaitAudit = "待审核";

            /// <summary>
            /// 退款中
            /// </summary>
            public const string Refunding = "退款中";

            /// <summary>
            /// 已退款
            /// </summary>
            public const string Refunded = "已退款";

            /// <summary>
            /// 拒绝退款
            /// </summary>
            public const string RefuseRefund = "拒绝退款";

        }

        /// <summary>
        /// 参与状态
        /// </summary>
        public struct ParticipateStatus
        {
            /// <summary>
            /// 未参加
            /// </summary>
            public const string No = "未参加";

            /// <summary>
            /// 已参加
            /// </summary>
            public const string Yes = "已参加";

        }

        

        /// <summary>
        /// 需求状态
        /// </summary>
        public struct DemandStatus
        {
            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessed = "未开始";

            /// <summary>
            /// 1-未开始-学生发起拼单
            /// </summary>
            public const string UnProcessedStudentPubDemand = "1-未开始-学生发起拼单";

            /// <summary>
            /// 进行中
            /// </summary>
            public const string Processing = "进行中";

            /// <summary>
            /// 进行中-教师申请接单
            /// </summary>
            public const string ProcessingTeacherApplying = "2-进行中-教师申请接单";

            /// <summary>
            /// 进行中-学生选择教师
            /// </summary>
            public const string ProcessingTeacherSelect = "3-进行中-学生选择教师";

            /// <summary>
            /// 进行中-教师已出发
            /// </summary>
            public const string TheTeacherHasStarted = "进行中-教师已出发";


            /// <summary>
            /// 进行中-教师已到达
            /// </summary>
            public const string TheTeacherHasArrived = "进行中-教师已到达";

            /// <summary>
            /// 进行中-教师结束上课
            /// </summary>
            public const string ProcessingTeacherEndClass = "4-进行中-教师结束上课";

            /// <summary>
            /// 已完成
            /// </summary>
            public const string Processed = "已完成";

            /// <summary>
            /// 5-已完成-学生确认
            /// </summary>
            public const string ProcessedStudentConfirm = "5-已完成-学生确认";
        }

        /// <summary>
        /// 拼单状态
        /// </summary>
        public struct PinStatus
        {
            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessed = "未开始";

            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessedStudentJoin = "1-未开始-学生加入";

            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessedTeacherApplying = "2-未开始-教师申请接单";

            /// <summary>
            /// 进行中
            /// </summary>
            public const string Processing = "进行中";

            /// <summary>
            /// 进行中-学生选择教师 等待付款
            /// </summary>
            public const string ProcessingTeacherSelect = "3-进行中-学生选择教师";


            /// <summary>
            /// 进行中-教师已出发
            /// </summary>
            public const string TheTeacherHasStarted = "进行中-教师已出发";


            /// <summary>
            /// 进行中-教师已到达
            /// </summary>
            public const string TheTeacherHasArrived = "进行中-教师已到达";

            /// <summary>
            /// 进行中-学生付款完成
            /// </summary>
            public const string ProcessingPayComplete = "4-进行中-学生付款完成";

            /// <summary>
            /// 进行中-教师结束上课
            /// </summary>
            public const string ProcessingTeacherEndClass = "5-进行中-教师结束上课";

            /// <summary>
            /// 已完成
            /// </summary>
            public const string Processed = "已完成";

            /// <summary>
            /// 已完成
            /// </summary>
            public const string ProcessedStudentConfirm = "6-已完成-学生确认";
        }

          /// <summary>
        /// 需求状态
        /// </summary>
        public struct ClassRecord
        {
            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessed = "未开始";

            /// <summary>
            /// 进行中
            /// </summary>
            public const string Processing = "进行中";

            /// <summary>
            /// 已完成
            /// </summary>
            public const string Processed = "已完成";

        }

        

        /// <summary>
        /// 需求状态
        /// </summary>
        public struct BelongType
        {
            /// <summary>
            /// 需求单
            /// </summary>
            public const string Demand = "需求单";

            /// <summary>
            /// 拼单
            /// </summary>
            public const string FightAlone = "拼单";
        }

        /// <summary>
        /// 教师需求单申请状态
        /// </summary>
        public struct DemandDetailStatus
        {
            /// <summary>
            /// 已拒绝
            /// </summary>
            public const string Refuse = "已拒绝";

            /// <summary>
            /// 申请中
            /// </summary>
            public const string Processing = "申请中";

            /// <summary>
            /// 已接受
            /// </summary>
            public const string Accept = "已接受";

        }

        /// <summary>
        /// 需求单项类型
        /// </summary>
        public struct NeedItemType
        {
            /// <summary>
            /// 文本
            /// </summary>
            public const string Text = "文本";

            /// <summary>
            /// 单选
            /// </summary>
            public const string Select = "单选";

            /// <summary>
            /// 文本域
            /// </summary>
            public const string TextArea = "文本域";

            /// <summary>
            /// 地图
            /// </summary>
            public const string Map = "地图";

            /// <summary>
            /// 日期
            /// </summary>
            public const string Date = "日期";

            /// <summary>
            /// 时间
            /// </summary>
            public const string Time = "时间";
        }

        /// <summary>
        /// 排序类型
        /// </summary>
        public struct OrderType
        {
            /// <summary>
            /// 价格
            /// </summary>
            public const string PricePerHour = "价格";

            /// <summary>
            /// 距离
            /// </summary>
            public const string Distance = "距离";

            /// <summary>
            /// 性别
            /// </summary>
            public const string Sex = "性别";
        }

        /// <summary>
        /// 教师教学时间类型
        /// </summary>
        public struct TeacherTimeType
        {

            /// <summary>
            /// 预约
            /// </summary>
            public const string Yuyue = "预约";

            /// <summary>
            /// 需求单
            /// </summary>
            public const string Demand = "需求单";

            /// <summary>
            /// 拼单
            /// </summary>
            public const string Pin = "拼单";

        }

        /// <summary>
        /// 需求单预约提示信息
        /// </summary>
        public struct AppointmentDemandMsg
        {
            /// <summary>
            /// 余额不足
            /// </summary>
            public const string 余额不足 = "余额不足，请进行充值！";

        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public struct OrderStatus
        {
            /// <summary>
            /// 未付款
            /// </summary>
            public const string 未付款 = "未付款";

            /// <summary>
            /// 已付款
            /// </summary>
            public const string 已付款 = "已付款";

            /// <summary>
            /// 教师已上课
            /// </summary>
            public const string 教师已上课 = "教师已上课";

            /// <summary>
            /// 学生已确认
            /// </summary>
            public const string 学生已确认 = "学生已确认";

            /// <summary>
            /// 已取消
            /// </summary>
            public const string 已取消 = "已取消";

        }

        /// <summary>
        /// 课程状态
        /// </summary>
        public struct ClassStatus
        {

            /// <summary>
            /// 已上课
            /// </summary>
            public const string 已上课 = "已上课";

            /// <summary>
            /// 未上课
            /// </summary>
            public const string 未上课 = "未上课";

        }

        /// <summary>
        /// 课程表状态
        /// </summary>
        public struct CourseTableStatus
        {
            /// <summary>
            /// 未预约
            /// </summary>
            public static string 未预约 = "未预约";

            /// <summary>
            /// 已排课
            /// </summary>
            public static string 已排课 = "已排课";

            /// <summary>
            /// 无法预约
            /// </summary>
            public static string 无法预约 = "无法预约";

            /// <summary>
            /// 请选择该时段
            /// </summary>
            public static string 请选择该时段 = "请选择该时段";

        }

        /// <summary>
        /// 预约状态
        /// </summary>
        public struct AppointmentStatus
        {

            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessed = "未开始";

            /// <summary>
            /// 未开始
            /// </summary>
            public const string UnProcessedStudentPubDemand = "1-未开始-学生预约教师";

            /// <summary>
            /// 进行中
            /// </summary>
            public const string Processing = "进行中";

            /// <summary>
            /// 进行中-教师申请接单
            /// </summary>
            public const string ProcessingTeacherApplying = "2-进行中-教师同意预约";

            /// <summary>
            /// 进行中-教师结束上课
            /// </summary>
            public const string ProcessingTeacherSelect = "3-进行中-教师结束上课";

            /// <summary>
            /// 已完成
            /// </summary>
            public const string Processed = "已完成";

            /// <summary>
            /// 已完成
            /// </summary>
            public const string ProcessedStudentConfirm = "4-已完成-学生确认付款";

        }

        /// <summary>
        /// 充值状态
        /// </summary>
        public struct RechargeStatus
        {
            /// <summary>
            /// 已完成
            /// </summary>
            public const string Finished = "已完成";

            /// <summary>
            /// 未完成
            /// </summary>
            public const string UnFinished = "未完成";

        }
        /// <summary>
        /// 删除操作类型
        /// </summary>
        public struct OsType
        {
            /// <summary>
            /// 清空
            /// </summary>
            public const string Empty = "清空";

            /// <summary>
            /// 停用
            /// </summary>
            public const string Stop = "停用";

            /// <summary>
            /// 启用
            /// </summary>
            public const string Start = "启用";

            /// <summary>
            /// 删除
            /// </summary>
            public const string Delete = "删除";
        }
        /// <summary>
        /// 删除操作类型
        /// </summary>
        public struct OsReason
        {
            /// <summary>
            /// 离职
            /// </summary>
            public const string Dimission = "离职";

            /// <summary>
            /// 休息
            /// </summary>
            public const string Rest = "休息";

          
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        public struct WithdrawalsState
        {
            /// <summary>
            /// 审核中
            /// </summary>
            public const string Audit = "审核中";

            /// <summary>
            /// 通过
            /// </summary>
            public const string Through = "通过";

            /// <summary>
            /// 未通过
            /// </summary>
            public const string NoThrough = "未通过";

                 /// <summary>
            ///   通过,不予汇款
            /// </summary>
            public const string ThroughNoRemittance = "通过,不予汇款";
          
        }
        /// <summary>
        /// Activity名称
        /// </summary>
        public static class ActivityName
        {
            /// <summary>
            /// 学生需求单未开始
            /// </summary>
            public const string 学生需求单未开始 = "学生需求单未开始";

            /// <summary>
            /// 学生需求单进行中
            /// </summary>
            public const string 学生需求单进行中 = "学生需求单进行中";

            /// <summary>
            /// 学生需求单已结束
            /// </summary>
            public const string 学生需求单已结束 = "学生需求单已结束";

            /// <summary>
            /// 学生拼单未开始
            /// </summary>
            public const string 学生拼单未开始 = "学生拼单未开始";

            /// <summary>
            /// 学生拼单进行中
            /// </summary>
            public const string 学生拼单进行中 = "学生拼单进行中";

            /// <summary>
            /// 学生拼单已结束
            /// </summary>
            public const string 学生拼单已结束 = "学生拼单已结束";

            /// <summary>
            /// 教师需求单未开始
            /// </summary>
            public const string 教师需求单未开始 = "教师需求单未开始";

            /// <summary>
            /// 教师需求单进行中
            /// </summary>
            public const string 教师需求单进行中 = "教师需求单进行中";

            /// <summary>
            /// 教师需求单已结束
            /// </summary>
            public const string 教师需求单已结束 = "教师需求单已结束";

            /// <summary>
            /// 教师拼单未开始
            /// </summary>
            public const string 教师拼单未开始 = "教师拼单未开始";

            /// <summary>
            /// 教师拼单进行中
            /// </summary>
            public const string 教师拼单进行中 = "教师拼单进行中";

            /// <summary>
            /// 教师拼单已结束
            /// </summary>
            public const string 教师拼单已结束 = "教师拼单已结束";

        }

        /// <summary>
        /// 红包来源
        /// </summary>
        public struct VoucherSource
        {
            /// <summary>
            /// 系统推送
            /// </summary>
            public const string  系统 = "系统推送";

            /// <summary>
            /// 充值赠送
            /// </summary>
            public const string 充值 = "充值赠送";

            /// <summary>
            /// 邀请赠送(是否开启邀请赠送功能时使用,当新用户注册时，填写邀请码时获得)
            /// </summary>
            public const string 邀请 = "邀请赠送";


            /// <summary>
            /// 受邀赠送
            /// </summary>
            public const string 受邀赠送 = "受邀赠送";

            /// <summary>
            /// 邀请获得(当被邀请人填写邀请人的邀请码注册，并完成首次充值后，赠送给邀请人)
            /// </summary>
            public const string 邀请获得 = "邀请获得";

            /// <summary>
            /// 注册赠送
            /// </summary>
            public const string 注册 = "注册赠送";
          
        }

        /// <summary>
        /// 红包使用记录
        /// </summary>
        public struct VoucherUsageRecord
        {
            /// <summary>
            /// 拼单
            /// </summary>
            public const string 拼单 = "拼单";

            /// <summary>
            /// 需求单
            /// </summary>
            public const string 需求单 = "需求单";


            /// <summary>
            /// 充值
            /// </summary>
            public const string 充值 = "充值";

            /// <summary>
            /// 定点课堂
            /// </summary>
            public const string 定点课堂 = "定点课堂";

          

        }


        /// <summary>
        /// 微信教师申请状态
        /// </summary>
        public struct WxStatus
        {
            /// <summary>
            /// 申请中
            /// </summary>
            public const string Application = "申请中";

            /// <summary>
            /// 已接受
            /// </summary>
            public const string Accepted = "已接受";

        }

        /// <summary>
        /// 微信回调类型
        /// </summary>
        public struct WxRedirectType
        {
            /// <summary>
            /// 发起拼单
            /// </summary>
            public const string AddPin = "AddPin";

            /// <summary>
            /// 发起需求单
            /// </summary>
            public const string AddDemand = "AddDemand";

            /// <summary>
            /// 查看需求单列表
            /// </summary>
            public const string SelectDemand = "SelectDemand";

            /// <summary>
            /// 查看拼单列表
            /// </summary>
            public const string SelectPin = "SelectPin";

            /// <summary>
            /// 拼单支付
            /// </summary>
            public const string PinPay = "PinPay";

            /// <summary>
            /// 需求单支付
            /// </summary>
            public const string DemandPay = "DemandPay";

            /// <summary>
            /// 一元课堂
            /// </summary>
            public const string OneClass = "OneClass";

            /// <summary>
            /// 一元课堂
            /// </summary>
            public const string OneClassList = "OneClassList";
                 /// <summary>
            /// 一元课堂填写信息
            /// </summary>
            public const string OneClassAdd = "OneClassAdd";


            /// <summary>
            /// 一元课堂学生添加
            /// </summary>
            public const string OneClassAddStudent = "OneClassAddStudent";


            /// <summary>
            /// 暑期课程列表
            /// </summary>
            public const string SummerClass = "SummerClass";

            /// <summary>
            /// 暑期课程年级列表
            /// </summary>
            public const string SummerList = "SummerList";
            /// <summary>
            /// 填写暑期课程信息
            /// </summary>
            public const string SummerAdd = "SummerAdd";


            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string SummerAddStudent = "SummerAddStudent";

            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string SummerPay = "SummerPay";

            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string SummerPayReady = "SummerPayReady";

               /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string SummerValdStudent = "SummerValdStudent";

            /// <summary>
            /// 暑期课程列表
            /// </summary>
            public const string PoweractClass = "PoweractClass";

            /// <summary>
            /// 暑期课程年级列表
            /// </summary>
            public const string PoweractList = "PoweractList";
            /// <summary>
            /// 填写暑期课程信息
            /// </summary>
            public const string PoweractAdd = "PoweractAdd";


            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string PoweractAddStudent = "PoweractAddStudent";

            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string PoweractPay = "PoweractPay";

            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string PoweractPayReady = "PoweractPayReady";

            /// <summary>
            /// 暑期课程学生添加
            /// </summary>
            public const string PoweractValdStudent = "PoweractValdStudent";
            
        }

        /// <summary>
        /// 学生邀请教师加入订单
        /// </summary>
        public struct InviteTeacher
        {
            /// <summary>
            /// 申请中
            /// </summary>
            public const string Application = "4";

            /// <summary>
            /// 已接受
            /// </summary>
            public const string Accepted = "2";

            /// <summary>
            /// 已拒绝
            /// </summary>
            public const string Refuse = "1";

        }
 #endregion
    }
}