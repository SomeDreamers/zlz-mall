//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/RoleMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 角色表映射表对应创建的表关系
    /// </summary>
    public sealed class RoleMapping
    {
        public static void MapInfo(EntityTypeBuilder<RoleEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Role");
            builder.HasKey(c => c.role_id);

            //设置表规则
            builder.Property(c => c.role_name).HasMaxLength(64).IsRequired();
            builder.Property(c => c.role_desc);
            builder.Property(c => c.role_type).IsRequired().HasDefaultValue((int)SourceStatus.admin);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}