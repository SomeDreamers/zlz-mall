//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/UserInfoMapping 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pls.Entity
{
    /// <summary>
    /// 用户表映射表对应创建的表关系
    /// </summary>
    public sealed class UserInfoMapping
    {
        public static void MapInfo(EntityTypeBuilder<UserInfoEntity> builder)
        {
            //设置表名，主键
            builder.ForMySqlToTable("Pls_UserInfo");
            builder.HasKey(c => c.userinfo_id);

            //设置表规则
            builder.Property(c => c.user_id).HasMaxLength(64).IsRequired();

            builder.Property(c => c.country);
            builder.Property(c => c.province);
            builder.Property(c => c.city);
            builder.Property(c => c.address).HasMaxLength(640);
            builder.Property(c => c.birthday);
            builder.Property(c => c.zodiac).HasMaxLength(8);
            builder.Property(c => c.direction_id);
            builder.Property(c => c.row_number).IsConcurrencyToken();
        }
    }
}