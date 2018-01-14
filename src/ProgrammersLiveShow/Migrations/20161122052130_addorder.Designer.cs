using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pls.Entity;

namespace ProgrammersLiveShow.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20161122052130_addorder")]
    partial class addorder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Pls.Entity.ButtonActionEntity", b =>
                {
                    b.Property<string>("action_id");

                    b.Property<string>("action_event")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("action_icon")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("action_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<bool>("action_newaction");

                    b.Property<string>("action_parentid")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int>("action_sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<int>("action_type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(2);

                    b.Property<string>("action_url")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("action_id");

                    b.ToTable("ButtonActions");

                    b.HasAnnotation("MySql:TableName", "Pls_ButtonAction");
                });

            modelBuilder.Entity("Pls.Entity.BuyEntity", b =>
                {
                    b.Property<string>("buy_id");

                    b.Property<string>("buy_desc");

                    b.Property<double>("buy_discount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0.0);

                    b.Property<bool>("buy_isgive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<double>("buy_total")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("version_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("buy_id");

                    b.ToTable("Bugs");

                    b.HasAnnotation("MySql:TableName", "Pls_Buy");
                });

            modelBuilder.Entity("Pls.Entity.CarouselEntity", b =>
                {
                    b.Property<string>("carousel_id");

                    b.Property<string>("carousel_conent")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("carousel_href")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("carousel_image")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("carousel_sort")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("carousel_titie")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("carousel_id");

                    b.ToTable("Carousels");

                    b.HasAnnotation("MySql:TableName", "Pls_Carousel");
                });

            modelBuilder.Entity("Pls.Entity.CommentEntity", b =>
                {
                    b.Property<string>("comment_id");

                    b.Property<string>("comment_desc");

                    b.Property<string>("comment_reply");

                    b.Property<int>("comment_star")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(5);

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<string>("parant_userid")
                        .IsRequired();

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("shop_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("comment_id");

                    b.ToTable("Comments");

                    b.HasAnnotation("MySql:TableName", "Pls_Comment");
                });

            modelBuilder.Entity("Pls.Entity.CommentImageEntity", b =>
                {
                    b.Property<string>("commentiamge_id");

                    b.Property<string>("comment_address")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("comment_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("commentiamge_id");

                    b.ToTable("CommentImages");

                    b.HasAnnotation("MySql:TableName", "Pls_CommentImage");
                });

            modelBuilder.Entity("Pls.Entity.DepartmentEntity", b =>
                {
                    b.Property<string>("department_id");

                    b.Property<DateTime>("createtime");

                    b.Property<string>("department_desc");

                    b.Property<string>("department_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("department_id");

                    b.ToTable("Departments");

                    b.HasAnnotation("MySql:TableName", "Pls_Department");
                });

            modelBuilder.Entity("Pls.Entity.MessageEntity", b =>
                {
                    b.Property<string>("message_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<string>("message_desc");

                    b.Property<int>("message_read")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("message_solve")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("message_type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("message_id");

                    b.ToTable("Messages");

                    b.HasAnnotation("MySql:TableName", "Pls_Message");
                });

            modelBuilder.Entity("Pls.Entity.NoticeEntity", b =>
                {
                    b.Property<string>("notice_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<string>("notice_desc")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("notice_id");

                    b.ToTable("Notices");

                    b.HasAnnotation("MySql:TableName", "Pls_Notice");
                });

            modelBuilder.Entity("Pls.Entity.OrderDetailEntity", b =>
                {
                    b.Property<string>("orderdetail_id");

                    b.Property<string>("order_id");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<double>("shop_actualmoney");

                    b.Property<double>("shop_currentprice");

                    b.Property<string>("shop_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopcoupon_id")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("0")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<double>("shopcoupon_money");

                    b.Property<string>("shopsku_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("orderdetail_id");

                    b.ToTable("OrderDetails");

                    b.HasAnnotation("MySql:TableName", "Pls_OrderDetail");
                });

            modelBuilder.Entity("Pls.Entity.OrderEntity", b =>
                {
                    b.Property<string>("order_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<double>("order_actualpay");

                    b.Property<int>("order_delete")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<int>("order_goods")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("order_memo")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("order_number")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("order_paystatus")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<double>("order_privilege");

                    b.Property<double>("order_total");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("order_id");

                    b.ToTable("Orders");

                    b.HasAnnotation("MySql:TableName", "Pls_Order");
                });

            modelBuilder.Entity("Pls.Entity.RoleButtonActionEntity", b =>
                {
                    b.Property<string>("rolebutton_id");

                    b.Property<string>("action_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("role_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("rolebutton_id");

                    b.ToTable("RoleButtonActions");

                    b.HasAnnotation("MySql:TableName", "Pls_Role_ButtonAction");
                });

            modelBuilder.Entity("Pls.Entity.RoleEntity", b =>
                {
                    b.Property<string>("role_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<string>("role_desc");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int>("role_type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(2);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("role_id");

                    b.ToTable("Roles");

                    b.HasAnnotation("MySql:TableName", "Pls_Role");
                });

            modelBuilder.Entity("Pls.Entity.ShopAttrEntity", b =>
                {
                    b.Property<string>("shopattr_id");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("shop_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_author")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_blogaddress")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_condition")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_database")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_framework")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<bool>("shopattr_isopensource")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("shopattr_language")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_manage")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_memo")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_opensource")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int>("shopattr_size");

                    b.Property<string>("shopattr_utf")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopattr_weburl")
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("shopattr_id");

                    b.ToTable("ShopAttrs");

                    b.HasAnnotation("MySql:TableName", "Pls_ShopAttr");
                });

            modelBuilder.Entity("Pls.Entity.ShopCouponEntity", b =>
                {
                    b.Property<string>("shopcoupon_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("endtime");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("shop_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<double>("shopcoupon_money");

                    b.Property<string>("shopcoupon_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("shopcoupon_type")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("shopcoupon_id");

                    b.ToTable("ShopCoupons");

                    b.HasAnnotation("MySql:TableName", "Pls_ShopCoupon");
                });

            modelBuilder.Entity("Pls.Entity.ShopEntity", b =>
                {
                    b.Property<string>("shop_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("shop_defaultimg");

                    b.Property<string>("shop_desc");

                    b.Property<bool>("shop_isdiscount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("shop_memo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shop_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("shop_number")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("shop_id");

                    b.ToTable("Shops");

                    b.HasAnnotation("MySql:TableName", "Pls_Shop");
                });

            modelBuilder.Entity("Pls.Entity.ShopImageEntity", b =>
                {
                    b.Property<string>("shopimage_id");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("shop_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopimage_address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<bool>("shopimage_default")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("shopsku_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("shopimage_id");

                    b.ToTable("ShopImages");

                    b.HasAnnotation("MySql:TableName", "Pls_ShopImage");
                });

            modelBuilder.Entity("Pls.Entity.ShopSkuEntity", b =>
                {
                    b.Property<string>("shopsku_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("shop_code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("shop_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("shopsku_code")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("shopsku_currentprice")
                        .IsRequired();

                    b.Property<string>("shopsku_originalprice")
                        .IsRequired();

                    b.Property<string>("shopsku_url")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("shopsku_id");

                    b.ToTable("ShopSkus");

                    b.HasAnnotation("MySql:TableName", "Pls_ShopSku");
                });

            modelBuilder.Entity("Pls.Entity.UserButtonActionEntity", b =>
                {
                    b.Property<string>("userbutton_id");

                    b.Property<string>("action_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("userbutton_id");

                    b.ToTable("UserButtonActions");

                    b.HasAnnotation("MySql:TableName", "Pls_User_ButtonAction");
                });

            modelBuilder.Entity("Pls.Entity.UserDepartmentEntity", b =>
                {
                    b.Property<string>("userdepartment_id");

                    b.Property<string>("department_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("userdepartment_id");

                    b.ToTable("UserDepartments");

                    b.HasAnnotation("MySql:TableName", "Pls_User_Department");
                });

            modelBuilder.Entity("Pls.Entity.UserEntity", b =>
                {
                    b.Property<string>("user_id");

                    b.Property<DateTime>("createtime");

                    b.Property<int>("disable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("disabledesc");

                    b.Property<DateTime>("last_time");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("source_type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<int>("user_activation")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("user_code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("user_email")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int>("user_gender")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("user_image");

                    b.Property<string>("user_ip")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("user_name")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("user_phone")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("user_pwd")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("user_visit")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("user_id");

                    b.ToTable("Users");

                    b.HasAnnotation("MySql:TableName", "Pls_User");
                });

            modelBuilder.Entity("Pls.Entity.UserInfoEntity", b =>
                {
                    b.Property<string>("userinfo_id");

                    b.Property<string>("address")
                        .HasAnnotation("MaxLength", 640);

                    b.Property<DateTime?>("birthday");

                    b.Property<int?>("city");

                    b.Property<int?>("country");

                    b.Property<int?>("direction_id");

                    b.Property<int?>("province");

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("zodiac")
                        .HasAnnotation("MaxLength", 8);

                    b.HasKey("userinfo_id");

                    b.ToTable("UserInfos");

                    b.HasAnnotation("MySql:TableName", "Pls_UserInfo");
                });

            modelBuilder.Entity("Pls.Entity.UserRoleEntity", b =>
                {
                    b.Property<string>("userrole_id");

                    b.Property<string>("role_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 54);

                    b.Property<byte[]>("row_number")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 54);

                    b.HasKey("userrole_id");

                    b.ToTable("UserRoles");

                    b.HasAnnotation("MySql:TableName", "Pls_User_Role");
                });
        }
    }
}
