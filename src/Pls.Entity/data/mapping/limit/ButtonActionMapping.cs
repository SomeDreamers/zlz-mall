//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/ButtonActionMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 页面或者按钮表映射表对应创建的表关系
    /// </summary>
    public sealed class ButtonActionMapping
    {
        public static void MapInfo(EntityTypeBuilder<ButtonActionEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_ButtonAction");
            builder.HasKey(c => c.action_id);

            //设置表规则
            builder.Property(c => c.action_name).HasMaxLength(128).IsRequired();

            builder.Property(c => c.action_url).HasMaxLength(128);
            builder.Property(c => c.action_parentid).HasMaxLength(64);
            builder.Property(c => c.action_icon).HasMaxLength(64);
            builder.Property(c => c.action_sort).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.action_event).HasMaxLength(64);
            builder.Property(c => c.action_type).IsRequired().HasDefaultValue((int)ActionType.adminleft);
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}