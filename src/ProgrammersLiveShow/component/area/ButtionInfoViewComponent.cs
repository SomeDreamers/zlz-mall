//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	ProgrammersLiveShow.component/ButtionInfoComponent 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/11 15:26:49
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace ProgrammersLiveShow
{
    /// <summary>
    /// 按钮控制实现，使其每个用户对应每个页面访问的权限不一致
    /// </summary>
    public class ButtionInfoViewComponent : ViewComponent
    {
        public IUserService userService { get; private set; }
        public ButtionInfoViewComponent(IUserService _userService)
        {
            userService = _userService;
        }

        /// <summary>
        /// 根据用户Id和路径查询按钮集合并且返回
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(HttpContext.Session.GetString(KeyUtil.user_info));
            string current_url = HttpContext.Request.Path;

            var result = await userService.getButtionInfo(userSession.user_id, current_url);
            return View("ButtionInfo", result);
        }
    }
}