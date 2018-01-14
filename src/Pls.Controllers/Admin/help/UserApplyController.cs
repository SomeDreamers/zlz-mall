//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers.Admin/UserApplyController
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/20 14:23:29
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pls.Utils;
using Pls.IService;
using Pls.Entity;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 入驻管理实现页面
    /// </summary>
    [Area("Admin")]
    [Route("Admin/UserApply")]
    [Login]
    [AjaxOnly]
    public class UserApplyController : BaseController
    {
        private IUserApplyService userApplyService;
        public UserApplyController(ApplicationConfigServices _applicationConfigServices, IUserApplyService _userApplyService)
            : base(_applicationConfigServices)
        {
            userApplyService = _userApplyService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  根据查询条件异步查询申请列表
        /// </summary>
        /// <param name="userApplyInfo">申请实体</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(UserApplyInfo userApplyInfo)
        {
            var data = await userApplyService.List(userApplyInfo);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 根据留言Id查询申请详情信息
        /// </summary>
        /// <param name="version_id">版本Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string apply_id)
        {
            var data = await userApplyService.GetById(apply_id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 审核通过/不通过
        /// </summary>
        /// <param name="apply_id">主键Id</param>
        /// <param name="apply_desc">处理理由</param>
        /// <param name="type">(0:同意，1:不同意)</param>
        /// <returns></returns>
        [HttpPost("Apply")]
        public async Task<IActionResult> Apply(string apply_id, string apply_desc, int type)
        {
            var userSession = GetUserSession();
            var data = await userApplyService.Apply(apply_id, apply_desc, type, userSession.user_id, userSession.full_name);
            return Json(data);
        }
    }
}