//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/UserButtonActionRepository 
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
    /// 用户按钮页面表操作类实现
    /// </summary>
    public class UserButtonActionRepository : BaseRepository<UserButtonActionEntity>, IUserButtonActionRepository
    {
        public UserButtonActionRepository(DataContext context) : base(context)
        {
        }

        public async Task<int> DeleteByUserId(string user_id)
        {
            string sql = @"DELETE FROM Pls_User_ButtonAction where user_id ={0}";
            return await Task.Run(() => ctx.Database.ExecuteSqlCommand(sql, user_id));
        }
    }
}