//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 13:44:57
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 评论产品表表对应创建的表关系
    /// </summary>
    public sealed class CommentMapping
    {
        public static void MapInfo(EntityTypeBuilder<CommentEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Comment");
            builder.HasKey(c => c.comment_id);

            //设置表规则
            builder.Property(c => c.user_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shop_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopsku_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.comment_star).IsRequired().HasDefaultValue(5);
            builder.Property(c => c.comment_desc);
            builder.Property(c => c.parant_userid).IsRequired();
            builder.Property(c => c.comment_reply);
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}