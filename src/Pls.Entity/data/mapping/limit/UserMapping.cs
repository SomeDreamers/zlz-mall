//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/UserMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 用户表映射表对应创建的表关系
    /// </summary>
    public sealed class UserMapping
    {
        public static void MapInfo(EntityTypeBuilder<UserEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_User");
            builder.HasKey(c => c.user_id);

            //设置表规则
            builder.Property(c => c.user_name).HasMaxLength(32);
            builder.Property(c => c.full_name).HasMaxLength(32);
            builder.Property(c => c.user_pwd).HasMaxLength(32).IsRequired();
            builder.Property(c => c.user_code).IsRequired().HasMaxLength(10);
            builder.Property(c => c.user_email).HasMaxLength(64);
            builder.Property(c => c.user_phone).HasMaxLength(32);
            builder.Property(c => c.user_gender).IsRequired().HasDefaultValue((int)GenderStatus.mystery);
            builder.Property(c => c.user_ip).HasMaxLength(32);
            builder.Property(c => c.source_type).IsRequired().HasDefaultValue((int)SourceStatus.front);
            builder.Property(c => c.user_image);
            builder.Property(c => c.user_activation).IsRequired().HasDefaultValue((int)DisableStatus.disable_true);
            builder.Property(c => c.user_visit).IsRequired().HasDefaultValue((int)DisableStatus.disable_true);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.last_time).IsRequired();
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}