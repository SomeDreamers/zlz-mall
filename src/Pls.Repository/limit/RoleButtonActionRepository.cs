//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/RoleButtonActionRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using Pls.IRepository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pls.Repository
{
    /// <summary>
    /// 角色按钮页面表操作类实现
    /// </summary>
    public class RoleButtonActionRepository : BaseRepository<RoleButtonActionEntity>, IRoleButtonActionRepository
    {
        public RoleButtonActionRepository(DataContext context) : base(context)
        {

        }

        /// <summary>
        /// 根据role_id删除角色权限表中的所有角色信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public async Task<int> DeleteByRoleId(string role_id)
        {
            string sql = @"DELETE FROM Pls_Role_ButtonAction WHERE role_id ={0}";
            return await Task.Run(() => ctx.Database.ExecuteSqlCommand(sql, role_id));
        }
    }
}