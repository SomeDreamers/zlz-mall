//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/DataContext 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Pls.Entity.data.mapping.store;
using Pls.Entity.entity.store;

namespace Pls.Entity
{
    /// <summary>
    /// 构造生成数据库实体
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        //映射数据库对数据库进行生成
        //权限模块实体映射
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserInfoEntity> UserInfos { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<ButtonActionEntity> ButtonActions { get; set; }
        public DbSet<RoleButtonActionEntity> RoleButtonActions { get; set; }
        public DbSet<UserButtonActionEntity> UserButtonActions { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<UserDepartmentEntity> UserDepartments { get; set; }

        //商品管理模块实体映射
        public DbSet<ShopEntity> Shops { get; set; }
        public DbSet<ShopSkuEntity> ShopSkus { get; set; }
        public DbSet<ShopAttrEntity> ShopAttrs { get; set; }
        public DbSet<ShopImageEntity> ShopImages { get; set; }
        public DbSet<ShopCouponEntity> ShopCoupons { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CommentImageEntity> CommentImages { get; set; }
        public DbSet<CategoryEntity> Categorys { get; set; }
        public DbSet<ShopCategoryEntity> ShopCategorys { get; set; }

        //系统管理模块实体映射
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<NoticeEntity> Notices { get; set; }
        public DbSet<CarouselEntity> Carousels { get; set; }
        public DbSet<UserApplyEntity> UserApply { get; set; }


        //(以下查询为使用sql语句查询的实体，只限三个表以上的查询可在这里设置)以下数据标示在生成数据库的时候去掉get,set属性，生成完成之后在加上
        public DbSet<ShopHomeInfo> shopHomeInfos { get; set; }
        public DbSet<UserDepartRoleInfo> userDepartRole { get; set; }
        public DbSet<OrderPay> OrderPays { get; set; }
        public DbSet<ShopCommentInfo> shopCommentInfos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(UserMapping.MapInfo);
            modelBuilder.Entity<UserInfoEntity>(UserInfoMapping.MapInfo);
            modelBuilder.Entity<RoleEntity>(RoleMapping.MapInfo);
            modelBuilder.Entity<UserRoleEntity>(UserRoleMapping.MapInfo);
            modelBuilder.Entity<ButtonActionEntity>(ButtonActionMapping.MapInfo);
            modelBuilder.Entity<RoleButtonActionEntity>(RoleButtonActionMapping.MapInfo);
            modelBuilder.Entity<UserButtonActionEntity>(UserButtonActionMapping.MapInfo);
            modelBuilder.Entity<DepartmentEntity>(DepartmentMapping.MapInfo);
            modelBuilder.Entity<UserDepartmentEntity>(UserDepartmentMapping.MapInfo);
            modelBuilder.Entity<MessageEntity>(MessageMapping.MapInfo);
            modelBuilder.Entity<CommentEntity>(CommentMapping.MapInfo);
            modelBuilder.Entity<NoticeEntity>(NoticeMapping.MapInfo);
            modelBuilder.Entity<CarouselEntity>(CarouselMapping.MapInfo);
            modelBuilder.Entity<ShopEntity>(ShopMapping.MapInfo);
            modelBuilder.Entity<ShopSkuEntity>(ShopSkuMapping.MapInfo);
            modelBuilder.Entity<ShopAttrEntity>(ShopAttrMapping.MapInfo);
            modelBuilder.Entity<ShopImageEntity>(ShopImageMapping.MapInfo);
            modelBuilder.Entity<ShopCouponEntity>(ShopCouponMapping.MapInfo);
            modelBuilder.Entity<OrderEntity>(OrderMapping.MapInfo);
            modelBuilder.Entity<OrderDetailEntity>(OrderDetailMapping.MapInfo);
            modelBuilder.Entity<CommentImageEntity>(CommentImageMapping.MapInfo);
            modelBuilder.Entity<UserApplyEntity>(UserApplyMapping.MapInfo);
            modelBuilder.Entity<CategoryEntity>(CategoryMapping.MapInfo);
            modelBuilder.Entity<ShopCategoryEntity>(ShopCategoryMapping.MapInfo);

            base.OnModelCreating(modelBuilder);
        }
    }
}