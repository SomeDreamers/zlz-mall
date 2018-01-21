using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pls.Entity.entity.store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Entity.data.mapping.store
{
    public sealed class ShopCategoryMapping
    {
        public static void MapInfo(EntityTypeBuilder<ShopCategoryEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("pls_shop_category");
            builder.HasKey(c => c.id);

            //设置表规则
            builder.Property(c => c.shop_id).IsRequired();
            builder.Property(c => c.category1st_id).IsRequired();
            builder.Property(c => c.category2rd_id).IsRequired();
            builder.Property(c => c.weight).IsRequired();
        }
    }
}
