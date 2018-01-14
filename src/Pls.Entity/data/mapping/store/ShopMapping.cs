//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 10:49:15
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 商品表对应创建的表关系
    /// </summary>
    public sealed class ShopMapping
    {
        public static void MapInfo(EntityTypeBuilder<ShopEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Shop");
            builder.HasKey(c => c.shop_id);

            //设置表规则
            builder.Property(c => c.shop_name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.shop_memo).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shop_number).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shop_desc);
            builder.Property(c => c.shop_defaultimg);
            builder.Property(c => c.shop_isdiscount).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.user_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}