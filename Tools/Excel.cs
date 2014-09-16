using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace JLib.Tools
{
    public class Excel
    {
        #region Excell转成DataTable
        /// <summary>
        /// 将Excel文件导出至DataTable(第一行作为表头)
        /// </summary>
        /// <param name="excelFilePath">Excel文件路径</param>
        /// <param name="tableName">数据表名，如果数据表名错误，默认为第一个数据表名,如：sheet1</param>
        public static DataTable InputFromExcel(string excelFilePath, string tableName)
        {
            if (!File.Exists(excelFilePath))
            {
                throw new Exception("Excel文件不存在！");
            }

            //如果数据表名不存在，则数据表名为Excel文件的第一个数据表
            var tableList = GetExcelTables(excelFilePath);

            if (tableName.IndexOf(tableName, System.StringComparison.Ordinal) < 0)
            {
                tableName = tableList[0].ToString().Trim();
            }


            var dbcon = new OleDbConnection();
            var table = new DataTable();
            try
            {
                dbcon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0");
                var cmd = new OleDbCommand("select * from [" + tableName + "$]", dbcon);
                var adapter = new OleDbDataAdapter(cmd);

                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                dbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';data source=" + excelFilePath);
                var cmd = new OleDbCommand("select * from [" + tableName + "$]", dbcon);
                var adapter = new OleDbDataAdapter(cmd);

                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                adapter.Fill(table);
            }
            finally
            {
                if (dbcon.State == ConnectionState.Open)
                {
                    dbcon.Close();
                }
            }
            return table;
        }

        /// <summary>
        /// 获取Excel文件数据表列表
        /// </summary>
        private static ArrayList GetExcelTables(string excelFileName)
        {
            var tablesList = new ArrayList();
            DataTable dt;

            if (File.Exists(excelFileName))
            {
                var conn =
                    new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" +excelFileName);
                using (conn)
                {
                    try
                    {
                        conn.Open();
                        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    }
                    catch (Exception exp)
                    {
                        conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';data source=" + excelFileName);
                        conn.Open();
                        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    }

                    //获取数据表个数
                    if (dt != null)
                    {
                        var tablecount = dt.Rows.Count;
                        for (var i = 0; i < tablecount; i++)
                        {
                            var tablename = dt.Rows[i][2].ToString().Trim().TrimEnd('$');
                            if (tablesList.IndexOf(tablename) < 0)
                            {
                                tablesList.Add(tablename);
                            }
                        }
                    }
                }
            }
            return tablesList;
        }
        #endregion
    }
}
