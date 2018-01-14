//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopAttrMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:32:32
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 商品属性表对应创建的表关系
    /// </summary>
    public sealed class ShopAttrMapping
    {
        public static void MapInfo(EntityTypeBuilder<ShopAttrEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_ShopAttr");
            builder.HasKey(c => c.shopattr_id);

            //设置表规则
            builder.Property(c => c.shop_id).HasMaxLength(64).IsRequired();
            builder.Property(c => c.shopattr_author).HasMaxLength(64);
            builder.Property(c => c.shopattr_language).HasMaxLength(64);
            builder.Property(c => c.shopattr_condition).HasMaxLength(64);
            builder.Property(c => c.shopattr_database).HasMaxLength(64);
            builder.Property(c => c.shopattr_framework).HasMaxLength(64);
            builder.Property(c => c.shopattr_manage).HasMaxLength(64);
            builder.Property(c => c.shopattr_size);
            builder.Property(c => c.shopattr_utf).HasMaxLength(64);
            builder.Property(c => c.shopattr_weburl).HasMaxLength(128);
            builder.Property(c => c.shopattr_blogaddress).HasMaxLength(128);
            builder.Property(c => c.shopattr_isopensource).HasDefaultValue(false);
            builder.Property(c => c.shopattr_opensource).HasMaxLength(64);
            builder.Property(c => c.shopattr_memo).HasMaxLength(256);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}