//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/OrderMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 11:54:12
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 订单主表对应创建的表关系
    /// </summary>
    public sealed class OrderMapping
    {
        public static void MapInfo(EntityTypeBuilder<OrderEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Order");
            builder.HasKey(c => c.order_id);

            //设置表规则
            builder.Property(c => c.order_number).HasMaxLength(32).IsRequired();
            builder.Property(c => c.order_total).IsRequired();
            builder.Property(c => c.order_privilege);
            builder.Property(c => c.order_actualpay).IsRequired();
            builder.Property(c => c.order_total).IsRequired();
            builder.Property(c => c.order_total).IsRequired();
            builder.Property(c => c.order_paystatus).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.order_payway).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.order_goods).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.order_delete).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.order_memo).HasMaxLength(200);
            builder.Property(c => c.user_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}