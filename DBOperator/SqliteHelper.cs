using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace JLib.DBOperator
{
    public class SqliteHelper
    {
        SQLiteConnection conn;
        public SqliteHelper(string conStr)
        {
            conn = new SQLiteConnection(conStr);
            conn.Open();
        }

        //执行无返回的sql
        public void ExeSql(string sql)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception getDrError)
            {
                throw new Exception(getDrError.Message);
            }
        }

        //执行查询返回一个DataReader
        public SQLiteDataReader getDR(string sql)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                return cmd.ExecuteReader();
            }
            catch (Exception getDrError)
            {
                throw new Exception(getDrError.Message);
            }
        }
    }
}
