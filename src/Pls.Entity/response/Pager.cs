//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:         Pls.Entity/Pager 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    /// <summary>
    /// 返回分页的信息的公共类
    /// </summary>
    public class Pager<T> where T : class
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 返回分页的实体集合
        /// </summary>
        public T rows { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="total"></param>
        /// <param name="rows"></param>
        public Pager(int total, T rows)
        {
            this.total = total;
            this.rows = rows;
        }
    }
}