//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IRoleButtonActionRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 角色按钮页面表操作类接口
    /// </summary>
    public interface IRoleButtonActionRepository : IBaseRepository<RoleButtonActionEntity>
    {
        /// <summary>
        /// 根据role_id删除角色权限表中的所有角色信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        Task<int> DeleteByRoleId(string role_id);
    }
}