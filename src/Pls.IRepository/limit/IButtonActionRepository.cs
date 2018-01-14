//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IButtonActionRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/17 10:19:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pls.IRepository
{
    /// <summary>
    /// 页面或者按钮表操作类接口
    /// </summary>
    public interface IButtonActionRepository : IBaseRepository<ButtonActionEntity>
    {
        /// <summary>
        /// 根据用户Id以及其它组装的查询条件查询返回的权限信息
        /// </summary>
        /// <param name="user_Id">用户Id</param>
        /// <param name="where_search">组装查询条件</param>
        /// <returns></returns>
        IQueryable<ButtionActionInfo> GetMenuInfo(string user_Id, Expression<Func<ButtonActionEntity, bool>> where_search);
    }
}