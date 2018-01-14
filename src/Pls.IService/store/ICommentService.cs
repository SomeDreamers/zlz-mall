//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.IService/ICommentService 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/3 22:21:00
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    /// 商品评论业务接口
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// 异步查询评论列表
        /// </summary>
        /// <param name="commentInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<CommentShopInfo>>> List(CommentInfo commentInfo);

        /// <summary>
        /// 根据评论id查询用户-评论-版本信息
        /// </summary>
        /// <param name="comment_id">评论id</param>
        /// <returns></returns>
        Task<BaseResult<CommentShopInfo>> GetCommentById(string comment_id);

        /// <summary>
        /// 查询商品评论信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="type">评论级别</param>
        /// <returns></returns>
        Task<BaseResult<List<ShopCommentView>>> GetShopCommentInfo(string shop_id, int type);

        /// <summary>
        /// 为商品添加评论信息
        /// </summary>
        /// <param name="CommentShop">商品评论实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddComment(CommentShop CommentShop);

        /// <summary>
        /// 管理员回复评论信息
        /// </summary>
        /// <param name="comment_id">评论id</param>
        /// <param name="comment_reply">管理员回复内容</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Reply(string comment_id, string comment_reply);

        /// <summary>
        /// 评论启用禁用
        /// </summary>
        /// <param name="comment_id">评论id</param>
        /// <param name="disable_desc">启用禁用描述</param>
        /// <param name="type">启用禁用类型（0：启用，1：禁用）</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string comment_id, string disable_desc, int type);

    }
}