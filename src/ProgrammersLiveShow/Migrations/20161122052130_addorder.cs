using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class addorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment_read",
                table: "Pls_Comment");

            migrationBuilder.DropColumn(
                name: "version_id",
                table: "Pls_Comment");

            migrationBuilder.CreateTable(
                name: "Pls_CommentImage",
                columns: table => new
                {
                    commentiamge_id = table.Column<string>(nullable: false),
                    comment_address = table.Column<string>(maxLength: 200, nullable: true),
                    comment_id = table.Column<string>(maxLength: 64, nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_CommentImage", x => x.commentiamge_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_OrderDetail",
                columns: table => new
                {
                    orderdetail_id = table.Column<string>(nullable: false),
                    order_id = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    shop_actualmoney = table.Column<double>(nullable: false),
                    shop_currentprice = table.Column<double>(nullable: false),
                    shop_id = table.Column<string>(maxLength: 64, nullable: false),
                    shopcoupon_id = table.Column<string>(maxLength: 64, nullable: false, defaultValue: "0")
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    shopcoupon_money = table.Column<double>(nullable: false),
                    shopsku_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_OrderDetail", x => x.orderdetail_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Order",
                columns: table => new
                {
                    order_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    order_actualpay = table.Column<double>(nullable: false),
                    order_delete = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    order_goods = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    order_memo = table.Column<string>(maxLength: 200, nullable: true),
                    order_number = table.Column<string>(maxLength: 32, nullable: false),
                    order_paystatus = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    order_privilege = table.Column<double>(nullable: false),
                    order_total = table.Column<double>(nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Order", x => x.order_id);
                });

            migrationBuilder.AddColumn<string>(
                name: "shop_id",
                table: "Pls_Comment",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Pls_Comment",
                maxLength: 64,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shop_id",
                table: "Pls_Comment");

            migrationBuilder.DropTable(
                name: "Pls_CommentImage");

            migrationBuilder.DropTable(
                name: "Pls_OrderDetail");

            migrationBuilder.DropTable(
                name: "Pls_Order");

            migrationBuilder.AddColumn<int>(
                name: "comment_read",
                table: "Pls_Comment",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddColumn<string>(
                name: "version_id",
                table: "Pls_Comment",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Pls_Comment",
                maxLength: 64,
                nullable: true);
        }
    }
}
