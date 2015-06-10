using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JLib.API
{
    public class PaginationDTO<TData>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public IList<TData> Rows { get; set; }
        /// <summary>
        /// 扩展数据
        /// </summary>
        public object ExtData { get; set; }
    }
}
