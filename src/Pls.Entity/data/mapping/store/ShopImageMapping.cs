//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopImageMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:45:36
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 商品图片表对应创建的表关系
    /// </summary>
    public sealed class ShopImageMapping
    {
        public static void MapInfo(EntityTypeBuilder<ShopImageEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_ShopImage");
            builder.HasKey(c => c.shopimage_id);

            //设置表规则
            builder.Property(c => c.shop_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopsku_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopimage_address).HasMaxLength(128).IsRequired();
            builder.Property(c => c.shopimage_default).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}