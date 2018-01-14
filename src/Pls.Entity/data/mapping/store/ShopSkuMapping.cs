//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopSkuMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:14:24
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    ///  商品SKU表对应创建的表关系
    /// </summary>
    public sealed class ShopSkuMapping
    {

        public static void MapInfo(EntityTypeBuilder<ShopSkuEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_ShopSku");
            builder.HasKey(c => c.shopsku_id);

            //设置表规则
            builder.Property(c => c.shop_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shop_code).HasMaxLength(128).IsRequired();
            builder.Property(c => c.shopsku_originalprice).IsRequired();
            builder.Property(c => c.shopsku_currentprice).IsRequired();
            builder.Property(c => c.shopsku_url).HasMaxLength(255);
            builder.Property(c => c.shopsku_code).HasMaxLength(128);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}