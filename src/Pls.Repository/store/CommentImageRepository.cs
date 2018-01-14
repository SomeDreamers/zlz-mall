//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/CommentImageRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/29 16:45:39
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using Pls.IRepository;

namespace Pls.Repository
{
    /// <summary>
    /// 商品评论图片操作类实现
    /// </summary>
    public class CommentImageRepository : BaseRepository<CommentImageEntity>, ICommentImageRepository
    {
        public CommentImageRepository(DataContext context) : base(context)
        {
        }
    }
}