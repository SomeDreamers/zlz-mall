//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/UserRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System;
using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pls.Repository
{
    /// <summary>
    /// 用户基础操作类实现
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext Context) : base(Context)
        {
        }

        public Task<IQueryable<UserDepartRoleInfo>> getLeftJoinDepRole(Expression<Func<UserDepartRoleInfo, bool>> where_search,
            int pageIndex, int pageSize, out int total)
        {
            const string sql = "select * from Pls_ViewLeftJoinDepRole";
            IQueryable<UserDepartRoleInfo> userdepartroles = ctx.userDepartRole.FromSql(sql).Where(where_search);

            //查询之后分组并且返回汇总的信息
            IQueryable<UserDepartRoleInfo> userDepartRoleInfo = userdepartroles.GroupBy(c => new { c.user_id })
                .Select(g => new UserDepartRoleInfo()
                {
                    user_id = g.Key.user_id,
                    user_name = g.Max(c => c.user_name),
                    user_code = g.Max(c => c.user_code),
                    full_name = g.Max(c => c.full_name),
                    user_email = g.Max(c => c.user_email),
                    user_phone = g.Max(c => c.user_phone),
                    user_gender = g.Max(c => c.user_gender),
                    user_ip = g.Max(c => c.user_ip),
                    source_type = g.Max(c => c.source_type),
                    user_image = g.Max(c => c.user_image),
                    createtime = g.Max(c => c.createtime),
                    last_time = g.Max(c => c.last_time),
                    disable = g.Max(c => c.disable),
                    disabledesc = g.Max(c => c.disabledesc),
                    user_activation = g.Max(c => c.user_activation),
                    user_visit = g.Max(c => c.user_visit),
                    department_id = string.Join(",", g.Select(c => c.department_id).Distinct().ToArray()),
                    department_name = string.Join(",", g.Select(c => c.department_name).Distinct().ToArray()),
                    role_id = string.Join(",", g.Select(c => c.role_id).Distinct().ToArray()),
                    role_name = string.Join(",", g.Select(c => c.role_name).Distinct().ToArray())
                });

            total = userDepartRoleInfo.Count();
            userDepartRoleInfo = userDepartRoleInfo.OrderByDescending(c => c.createtime).Skip((--pageIndex * pageSize)).Take(pageSize);

            return Task.Run(() => userDepartRoleInfo.AsNoTracking());
        }
    }
}