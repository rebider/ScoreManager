
//*****************************************************************
//
// File Name:   LogDal.cs
//
// Description:  LogDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using System;
using System.Diagnostics;
using MT.Models;
using MT.Common;
using PetaPoco.Internal;
using System.IO;
using System.Data;

namespace MT.Dal
{
    public class LogDAL : BaseDAL<LogModel>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">当前用户ID</param>
        /// <param name="tableName">主表名</param>
        public static void AppendSQLLog(string userid, string tableName, params string[] sql)
        {
            if (MTConfig.IsLog)
            {
                if (null == sql || 0 == sql.Length)
                {
                    string tmp_sql = LogModel.repo.LastCommand.Trim();
                    PrepareLog(userid, tableName, tmp_sql);
                    Debug.Write(tmp_sql);
                }
                else
                {
                    foreach (string item in sql)
                    {
                        PrepareLog(userid, tableName, item);
                        Debug.Write(item);
                    }
                }
            }
        }

        private static void PrepareLog(string userid, string tableName, string sql)
        {
            LogModel log = new LogModel();
            log.UserID = userid.ToInt();
            log.TableName = tableName;
            log.SQLInfo = sql;
            log.LogType = log.SQLInfo.Substring(0, log.SQLInfo.IndexOf(" ")).ToUpper();
            log.CreateMan = log.UserID;
            log.CreateTime = DateTime.Now;
            log.Insert();
        }

        public static void AppendSQLLog(string userid, Type modelType, params string[] sql)
        {
            var pd = PocoData.ForType(modelType);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, pd.TableInfo.TableName);
        }

        public static void AppendSQLLog(string userid, string logType, string SqlInfo)
        {
            LogModel log = new LogModel();
            log.UserID = userid.ToInt();
            log.TableName = "";
            log.LogType = logType;
            log.SQLInfo = SqlInfo;
            log.Insert();
        }


        public string GetBaCitySize(int num)
        {
            string sql = @"SELECT  
                           code,name,[max],[min]
                           FROM Ba_City_Size where [min] <= " + num + " and [MAX] > " + num + " ";


            return "";
        }


        public static void WriteLog(string strLog)
        {
            string sFilePath = "C:\\Web\\Log" + DateTime.Now.ToString("yyyyMM");
            string sFileName = "Log_" + DateTime.Now.ToString("dd") + ".log";
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "   ---   " + strLog);
            sw.Close();
            fs.Close();
        }


    }
}
