using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JLib.Extension
{
    public static class  DataTableExtension
    {
        /// <summary>
        /// 将dt2合并到dt1中
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns>返回dt1</returns>
        public static DataTable AppendDT(this DataTable dt,DataTable dt2)
        {
            object[] obj = new object[dt.Columns.Count];
            foreach (DataRow dr in dt2.Rows)
            {
                dr.ItemArray.CopyTo(obj, 0);
                dt.Rows.Add(obj);
            }
            return dt;
        }
    }
}
