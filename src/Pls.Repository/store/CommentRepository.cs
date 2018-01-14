//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/CommentRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 15:52:47
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pls.Repository
{
    /// <summary>
    /// 商品评论操作类实现
    /// </summary>
    public class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context)
        {
        }

        public Task<IQueryable<ShopCommentInfo>> GetShopCommentInfo(Expression<Func<ShopCommentInfo, bool>> where_search)
        {
            const string sql = @"SELECT pcomment.comment_id,pcomment.shop_id,puser.user_name,puser.user_image,shopsku.shop_code,pcomment.comment_desc,pcomment.comment_reply,
	            pcomment.comment_star,pcomment.createtime,commentImage.comment_address from Pls_Comment as pcomment
	                INNER JOIN Pls_User as puser on pcomment.user_id=puser.user_id
	                INNER JOIN Pls_ShopSku as shopsku on shopsku.shopsku_id=pcomment.shopsku_id
	                LEFT JOIN Pls_CommentImage as commentImage on commentImage.comment_id=pcomment.comment_id
                    WHERE pcomment.`disable`=0";
            IQueryable<ShopCommentInfo> shopCommentInfos = ctx.shopCommentInfos.FromSql(sql).Where(where_search);

            return Task.Run(() => shopCommentInfos.OrderByDescending(c => c.createtime).AsNoTracking());
        }
    }
}