using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pls.Entity.entity.store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Entity.data.mapping.store
{
    public sealed class CategoryMapping
    {
        public static void MapInfo(EntityTypeBuilder<CategoryEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("pls_category");
            builder.HasKey(c => c.id);

            //设置表规则
            builder.Property(c => c.parent_id).IsRequired();
            builder.Property(c => c.name);
            builder.Property(c => c.type).IsRequired();
            builder.Property(c => c.weight).IsRequired();
            builder.Property(c => c.is_del).IsRequired();
        }
    }
}
