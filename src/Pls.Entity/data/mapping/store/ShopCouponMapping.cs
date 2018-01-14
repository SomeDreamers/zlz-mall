//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopCouponMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:52:58
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 商品优惠表对应创建的表关系
    /// </summary>
    public sealed class ShopCouponMapping
    {
        public static void MapInfo(EntityTypeBuilder<ShopCouponEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_ShopCoupon");
            builder.HasKey(c => c.shopcoupon_id);

            //设置表规则
            builder.Property(c => c.shop_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopcoupon_type).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopcoupon_name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.shopcoupon_money).IsRequired();
            builder.Property(c => c.createtime);
            builder.Property(c => c.endtime);
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}