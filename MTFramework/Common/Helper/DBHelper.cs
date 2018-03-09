using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.OracleClient;

namespace MT.Common.Helper
{
    using System.Data;

    public class DBHelper
    {

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public static string GenCode(string prefix, int length)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();
                
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "gencode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("s_prefix", prefix);
                    OracleParameter parameter = new OracleParameter("n_count", OracleType.Number){ Direction = ParameterDirection.Output };
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                    return string.Format("{0}{1}", prefix, parameter.Value.ToString().PadLeft(length, '0'));
                }
            }
        }

    }
}