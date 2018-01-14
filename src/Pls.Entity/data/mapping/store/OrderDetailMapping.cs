//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/OrderDetailMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 11:54:58
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 订单子表表对应创建的表关系
    /// </summary>
    public sealed class OrderDetailMapping
    {
        public static void MapInfo(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_OrderDetail");
            builder.HasKey(c => c.orderdetail_id);

            //设置表规则
            builder.Property(c => c.shop_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopsku_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shop_currentprice);
            builder.Property(c => c.shopcoupon_id).HasMaxLength(64).IsRequired().HasDefaultValue("0");
            builder.Property(c => c.shop_count).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.orderdetail_delete).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.orderdetail_evaluate).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}