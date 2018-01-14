//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IUserButtonActionRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 用户按钮页面表操作类接口-给用户配置临时权限
    /// </summary>
    public interface IUserButtonActionRepository : IBaseRepository<UserButtonActionEntity>
    {
        /// <summary>
        /// 根据user_id删除用户权限表中的所有用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        Task<int> DeleteByUserId(string user_id);
    }
}