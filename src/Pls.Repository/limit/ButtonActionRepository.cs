//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/ButtonActionRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Linq;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;
using Pls.IRepository;
using Pls.Entity;

namespace Pls.Repository
{
    /// <summary>
    /// 页面或者按钮表操作类实现
    /// </summary>
    public class ButtonActionRepository : BaseRepository<ButtonActionEntity>, IButtonActionRepository
    {
        public ButtonActionRepository(DataContext context) : base(context)
        {
        }

        //读取用户临时权限
        private const string user_action = "SELECT * from Pls_ButtonAction where action_id in(SELECT action_id from Pls_User_ButtonAction where user_id ='{0}')";
        //读取角色权限
        private const string user_role_action = "SELECT * from Pls_ButtonAction where action_id in(select action_id from Pls_Role_ButtonAction where role_id in(select role_id from Pls_User_Role where user_id = '{0}'))";

        public IQueryable<ButtionActionInfo> GetMenuInfo(string user_Id, Expression<Func<ButtonActionEntity, bool>> where_search)
        {
            //第一步：构造两个查询的sql语句
            string user_action_url = string.Format(user_action, user_Id);
            string user_role_action_url = string.Format(user_role_action, user_Id);

            IQueryable<ButtionActionInfo> buttionActionUser = ctx.ButtonActions.FromSql(user_action_url).Where(where_search).OrderBy(c => c.action_sort).Select(c => new ButtionActionInfo
            {
                action_id = c.action_id,
                action_name = c.action_name,
                action_url = c.action_url.ToLower(),
                action_event = c.action_event,
                action_icon = c.action_icon,
                action_newaction = c.action_newaction
            });
            IQueryable<ButtionActionInfo> buttionActionRole = ctx.ButtonActions.FromSql(user_role_action_url).Where(where_search).OrderBy(c => c.action_sort).Select(c => new ButtionActionInfo
            {
                action_id = c.action_id,
                action_name = c.action_name,
                action_url = c.action_url.ToLower(),
                action_event = c.action_event,
                action_icon = c.action_icon,
                action_newaction = c.action_newaction
            });

            //组装判断并且返回
            IQueryable<ButtionActionInfo> result = null;
            if (!buttionActionRole.Any() && !buttionActionUser.Any())
            {
                result = null;
            }
            if (buttionActionRole.Any() && buttionActionUser.Any())
            {
                result = buttionActionRole.Concat(buttionActionUser).Distinct();
            }
            if (!buttionActionRole.Any())
            {
                result = buttionActionUser;
            }
            if (!buttionActionUser.Any())
            {
                result = buttionActionRole;
            }
            return result == null ? null : result.AsNoTracking();
        }
    }
}