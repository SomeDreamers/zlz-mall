//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/PageEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    /// <summary>
    /// 封装分页的查询条件(从前台接收)
    /// </summary>
    public class PageEntity
    {
        /// <summary>
        /// 后台计算显示数据信息
        /// </summary>
        public int offset { get; set; } = int.MaxValue;

        /// <summary>
        /// 每页显示多少条数据
        /// </summary>
        public int pagesize { get; set; } = int.MaxValue;

        /// <summary>
        /// 当前第几页
        /// </summary>
        public int pageindex
        {
            get
            {
                if (this.offset != 0)
                {
                    return (this.offset / this.pagesize) + 1;
                }
                return 1;
            }
        }

        /// <summary>
        /// 排序规则(true:desc、false:asc)
        /// </summary>
        public bool orderby { get; set; } = true;

        /// <summary>
        /// 排序字段
        /// </summary>
        public string ordername { get; set; }

        /// <summary>
        /// 从第几条数据开始查询：不需要前台传递
        /// </summary>
        public int startIndex
        {
            get
            {
                return (this.pageindex - 1) * this.pagesize + 1;
            }
        }

        /// <summary>
        /// 查询到多好条数据：不需要前台传递
        /// </summary>
        public int startSize
        {
            get
            {
                return this.pageindex * this.pagesize;
            }
        }
    }
}