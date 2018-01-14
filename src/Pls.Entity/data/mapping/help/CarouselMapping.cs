//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CarouselMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 15:11:08
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 图片轮播表表对应创建的表关系
    /// </summary>
    public sealed class CarouselMapping
    {
        public static void MapInfo(EntityTypeBuilder<CarouselEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_Carousel");
            builder.HasKey(c => c.carousel_id);

            //设置表规则
            builder.Property(c => c.carousel_titie).IsRequired().HasMaxLength(40);
            builder.Property(c => c.carousel_conent).IsRequired().HasMaxLength(100);
            builder.Property(c => c.carousel_image).IsRequired().HasMaxLength(255);
            builder.Property(c => c.carousel_href).HasMaxLength(100);
            builder.Property(c => c.carousel_sort).IsRequired().HasDefaultValue(1);
            builder.Property(c => c.disable).IsRequired().HasDefaultValue((int)DisableStatus.disable_false);
            builder.Property(c => c.disabledesc);
            builder.Property(c => c.createtime).IsRequired();
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}