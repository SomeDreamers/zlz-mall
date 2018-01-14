//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/UserInfoRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pls.Repository
{
    /// <summary>
    /// 用户详情操作类实现
    /// </summary>
    public class UserInfoRepository : BaseRepository<UserInfoEntity>, IUserInfoRepository
    {
        public UserInfoRepository(DataContext context) : base(context)
        {
        }

        public async Task<int> DeleteByUserId(string user_id)
        {
            string sql = @"DELETE FROM Pls_UserInfo where user_id ={0}";
            return await Task.Run(() => ctx.Database.ExecuteSqlCommand(sql, user_id));
        }
    }
}