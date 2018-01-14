using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class update_shopsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userrole_id",
                table: "Pls_User_Role",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "userinfo_id",
                table: "Pls_UserInfo",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Pls_User",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "userdepartment_id",
                table: "Pls_User_Department",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "userbutton_id",
                table: "Pls_User_ButtonAction",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "apply_id",
                table: "Pls_User_Apply",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "shopsku_id",
                table: "Pls_ShopSku",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "shopimage_id",
                table: "Pls_ShopImage",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "shop_id",
                table: "Pls_Shop",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "shopcoupon_id",
                table: "Pls_ShopCoupon",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<double>(
                name: "shopattr_size",
                table: "Pls_ShopAttr",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shopattr_id",
                table: "Pls_ShopAttr",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "role_id",
                table: "Pls_Role",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "rolebutton_id",
                table: "Pls_Role_ButtonAction",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "order_id",
                table: "Pls_Order",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "orderdetail_id",
                table: "Pls_OrderDetail",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "notice_id",
                table: "Pls_Notice",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "message_id",
                table: "Pls_Message",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "department_id",
                table: "Pls_Department",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "commentiamge_id",
                table: "Pls_CommentImage",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "comment_id",
                table: "Pls_Comment",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "carousel_id",
                table: "Pls_Carousel",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "action_id",
                table: "Pls_ButtonAction",
                nullable: false)
                .Annotation("MySql:ValueGeneratedOnAdd", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userrole_id",
                table: "Pls_User_Role",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "userinfo_id",
                table: "Pls_UserInfo",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Pls_User",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "userdepartment_id",
                table: "Pls_User_Department",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "userbutton_id",
                table: "Pls_User_ButtonAction",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "apply_id",
                table: "Pls_User_Apply",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shopsku_id",
                table: "Pls_ShopSku",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shopimage_id",
                table: "Pls_ShopImage",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shop_id",
                table: "Pls_Shop",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shopcoupon_id",
                table: "Pls_ShopCoupon",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "shopattr_size",
                table: "Pls_ShopAttr",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shopattr_id",
                table: "Pls_ShopAttr",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "role_id",
                table: "Pls_Role",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "rolebutton_id",
                table: "Pls_Role_ButtonAction",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "order_id",
                table: "Pls_Order",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "orderdetail_id",
                table: "Pls_OrderDetail",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "notice_id",
                table: "Pls_Notice",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "message_id",
                table: "Pls_Message",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "department_id",
                table: "Pls_Department",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "commentiamge_id",
                table: "Pls_CommentImage",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "comment_id",
                table: "Pls_Comment",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "carousel_id",
                table: "Pls_Carousel",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "action_id",
                table: "Pls_ButtonAction",
                nullable: false);
        }
    }
}
