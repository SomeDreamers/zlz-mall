//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	ProgrammersLiveShow/MenuInfoViewComponent 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/11 15:26:49
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammersLiveShow
{
    /// <summary>
    /// 按钮菜单实现，使其每个用户对应每个页面访问的权限不一致
    /// </summary>
    public class MenuInfoViewComponent : ViewComponent
    {
        public IUserService userService { get; private set; }
        private RedisHelp redisHelp { get; set; }
        public MenuInfoViewComponent(IUserService _userService, RedisHelp _redisHelp)
        {
            userService = _userService;
            redisHelp = _redisHelp;
        }

        /// <summary>
        /// 根据用户Id和路径查询按钮集合并且返回(使用redis实现)
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(HttpContext.Session.GetString(KeyUtil.user_info));

            List<MenuActionInfo> result = null;
            if (redisHelp._conn != null)
            {
                string key = string.Format(RedisKeyUtil.login_admin_menu, userSession.user_id);
                if (redisHelp.KeyExists(key))
                {
                    result = JsonNetHelper.DeserializeObject<List<MenuActionInfo>>(await redisHelp.StringGetAsync(key));
                }
                else
                {
                    result = await userService.GetMenuInfo(userSession.user_id);
                    await redisHelp.StringSetAsync(key, JsonNetHelper.SerializeObject(result), new TimeSpan(30, 12, 60));
                }
            }
            else
            {
                result = await userService.GetMenuInfo(userSession.user_id);
            }
            return View("MenuInfo", result);
        }
    }
}