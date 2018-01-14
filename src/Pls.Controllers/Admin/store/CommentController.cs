//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers.Admin/CommentController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 16:09:32
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 商品评论控制器的实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Comment")]
    [Login]
    [AjaxOnly]
    public class CommentController : BaseController
    {
        //注入
        public ICommentService commentService { get; set; }
        public CommentController(ApplicationConfigServices _applicationConfigServices, ICommentService _commentService) : base(_applicationConfigServices)
        {
            commentService = _commentService;
        }

        /// <summary>
        /// 商品评论首页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 评论列表
        /// </summary>
        /// <param name="commentInfo">查询条件实体</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(CommentInfo commentInfo)
        {
            var data = await commentService.List(commentInfo);
            return JsonDate(data);
        }

        /// <summary>
        /// 根据评论id查询评论详情
        /// </summary>
        /// <param name="id">评论id</param>
        /// <returns></returns>
        [HttpGet("GetCommentById")]
        public async Task<IActionResult> GetCommentById(string id)
        {
            var data = await commentService.GetCommentById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 管理员回复评论信息
        /// </summary>
        /// <param name="comment_id">评论id</param>
        /// <param name="comment_reply">管理员回复内容</param>
        /// <returns></returns>
        [HttpPut("Reply")]
        public async Task<IActionResult> Reply(string comment_id, string comment_reply)
        {
            var data = await commentService.Reply(comment_id, comment_reply);
            return Json(data);
        }

        /// <summary>
        /// 评论启用禁用
        /// </summary>
        /// <param name="comment_id">评论id</param>
        /// <param name="disable_desc">启用禁用描述</param>
        /// <param name="type">启用禁用类型(1:禁用,0:启用)</param>
        /// <returns></returns>
        [HttpPut("Disable")]
        public async Task<IActionResult> Disable(string comment_id, string disable_desc, int type)
        {
            var data = await commentService.Disable(comment_id, disable_desc, type);
            return Json(data);
        }

    }
}