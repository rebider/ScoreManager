//*****************************************************************
//
// File Name:   PagingHelper
//
// Description: 分页
//
// Coder:       Liujianglin
//
// Date:        2013-06-21
//
// History:     1、2013-06-20 Create by Liujianglin
//   
//*****************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Common
{
    public class PagingHelper<T>
    {
        //数据源
        public IEnumerable<T> DataSource { get; set; }
        //每页显示的数量
        public int PageSize { get; set; }
        //当前页数
        public int PageIndex { get; set; }
        //总页数
        public int PageCount { get; set; }
        //是否有前一页
        public bool HasPrev { get { return PageIndex > 1; } }
        //是否有后一页
        public bool HasNext { get { return PageIndex < PageCount; } }
        //初始化分页器
        public PagingHelper(int pageSize,IEnumerable<T> dataSource)
        {
            this.PageSize = pageSize;
            this.DataSource = dataSource;
            PageCount = (int)Math.Ceiling((dataSource.Count()/ (double)PageSize));
        }
        //获取当前页数据
        public IEnumerable<T> GetPagingData()
        {
            return DataSource.Skip((PageIndex - 1) * PageSize).Take(PageSize);
        }
    }
}