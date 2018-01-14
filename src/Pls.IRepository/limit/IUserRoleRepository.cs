//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IUserRoleRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 用户角色操作类接口
    /// </summary>
    public interface IUserRoleRepository : IBaseRepository<UserRoleEntity>
    {
        /// <summary>
        /// 根据user_id删除用户角色表中的所有用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        Task<int> DeleteByUserId(string user_id);
    }
}