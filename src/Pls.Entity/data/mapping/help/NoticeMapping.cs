//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/NoticeMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 15:01:52
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 通知公告表表对应创建的表关系
    /// </summary>
    public sealed class NoticeMapping
    {
        public static void MapInfo(EntityTypeBuilder<NoticeEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Notice");
            builder.HasKey(c => c.notice_id);

            //设置表规则
            builder.Property(c => c.notice_desc).HasMaxLength(100);
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}