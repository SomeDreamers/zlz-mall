//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/RoleButtonActionMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 角色按钮页面映射表对应创建的表关系
    /// </summary>
    public sealed class RoleButtonActionMapping
    {
        public static void MapInfo(EntityTypeBuilder<RoleButtonActionEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Role_ButtonAction");
            builder.HasKey(c => c.rolebutton_id);

            //设置表规则
            builder.Property(c => c.role_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.action_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}