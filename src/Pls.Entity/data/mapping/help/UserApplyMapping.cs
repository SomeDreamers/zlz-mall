//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/UserApplyMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/6 13:51:47
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 用户申请访问后台表表对应创建的表关系
    /// </summary>
    public sealed class UserApplyMapping
    {
        public static void MapInfo(EntityTypeBuilder<UserApplyEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_User_Apply");
            builder.HasKey(c => c.apply_id);

            //设置表规则
            builder.Property(c => c.user_id).HasMaxLength(64);
            builder.Property(c => c.apply_reason).HasMaxLength(100);
            builder.Property(c => c.is_true).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.apply_desc).HasMaxLength(100);
            builder.Property(c => c.detail_id).HasMaxLength(64);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}