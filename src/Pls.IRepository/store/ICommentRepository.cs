//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/ICommentRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 15:50:17
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 商品评论操作类接口
    /// </summary>
    public interface ICommentRepository : IBaseRepository<CommentEntity>
    {
        /// <summary>
        /// 根据商品Id和评论级别查询商品评论内容
        /// </summary>
        /// <param name="where_search">查询条件</param>
        /// <returns></returns>
        Task<IQueryable<ShopCommentInfo>> GetShopCommentInfo(Expression<Func<ShopCommentInfo, bool>> where_search);
    }
}