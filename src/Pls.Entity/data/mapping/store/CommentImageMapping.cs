//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentImageMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 13:12:20
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 商品评论表对应的图片表创建的映射关系
    /// </summary>
    public sealed class CommentImageMapping
    {
        public static void MapInfo(EntityTypeBuilder<CommentImageEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_CommentImage");
            builder.HasKey(c => c.commentiamge_id);

            //设置表规则
            builder.Property(c => c.comment_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.comment_address).HasMaxLength(200);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}