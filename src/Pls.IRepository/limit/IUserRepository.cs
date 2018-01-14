//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IUserRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 用户基础操作类接口
    /// </summary>
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        /// <summary>
        /// 用户-角色-部门关联表查询返回结果
        /// </summary>
        /// <param name="where_search">查询条件</param>
        /// <param name="pageIndex">当前多少页</param>
        /// <param name="pageSize"><每页显示多少行/param>
        /// <param name="total">返回总数</param>
        /// <returns></returns>
        Task<IQueryable<UserDepartRoleInfo>> getLeftJoinDepRole(Expression<Func<UserDepartRoleInfo, bool>> where_search,
            int pageIndex, int pageSize, out int total);
    }
}