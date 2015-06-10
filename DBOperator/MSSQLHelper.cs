using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JLib.DBOperator
{
    public class MSSQLHelper
    {
        public string ConnStr;
        SqlConnection _conn;

        private static MSSQLHelper _mInstance = null;
        private MSSQLHelper()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }
        public static MSSQLHelper GetInstance()
        {
            return _mInstance ?? (_mInstance = new MSSQLHelper());
        }

        /// <summary>
        /// 执行无返回值的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public void ExeSql(string sql)
        {
            /*Using:当创建 SqlCommand 的实例时，读/写属性将被设置为它们的初始值。
             您可以重置 CommandText 属性并重复使用 SqlCommand 对象。但是，
            * 在执行新的命令或先前命令之前，必须关闭 SqlDataReader。如果执行 
            * SqlCommand 的方法生成 SqlException，那么当严重级别小于等于 19 时，
            * SqlConnection 将仍保持打开状态。当严重级别大于等于 20 时，
            * 服务器通常会关闭 SqlConnection。但是，用户可以重新打开连接并继续*/
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                using (var cmd = new SqlCommand(sql, _conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExeReader(string sql)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                using (var cmd = new SqlCommand(sql, _conn))
                {
                    var myReader = cmd.ExecuteReader();
                    return myReader;
                }
            }
        }

        /// <summary>
        /// 执行sql查询语句，返回记录条数
        /// </summary>
        /// <param name="sql">带有count(*)的sql语句</param>
        /// <returns>记录条数</returns>
        public int ExeScr(string sql)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                using (var cmd = new SqlCommand(sql, _conn))
                {
                    var scr = (int)cmd.ExecuteScalar();
                    return scr;
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExeDS(string sql)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                var ds = new DataSet();
                try
                {
                    var command = new SqlDataAdapter(sql, _conn);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataTable</returns>
        public DataTable ExeDt(string sql)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                var dt = new DataTable();
                try
                {
                    var command = new SqlDataAdapter(sql, _conn);
                    command.Fill(dt);
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }
        }

        /// <summary>
        /// 存储过程查询
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>DataTable</returns>
        public DataTable ExeProcWithNonParam(string procName)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                var cmd = new SqlCommand(procName, _conn) {CommandType = CommandType.StoredProcedure};
                var ds = new DataSet();
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 带参数的存储过程执行
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="param">参数列表</param>
        /// <returns>影响行数</returns>
        public int ExeProcWithParams(string procName, Dictionary<string, string> param)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                var cmd = new SqlCommand(procName, _conn) {CommandType = CommandType.StoredProcedure};
                foreach (var item in param)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, item.Value));
                }

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 带参数的存储过程执行,并返回数据
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="param">参数列表</param>
        /// <returns>查询数据</returns>
        public DataTable ExeProcWithParamsAndReturns(string procName, Dictionary<string, string> param)
        {
            using (_conn = new SqlConnection(ConnStr))
            {
                _conn.Open();
                var cmd = new SqlCommand(procName, _conn) {CommandType = CommandType.StoredProcedure};
                foreach (var item in param)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, item.Value));
                }

                var ds = new DataSet();
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

    }
}
