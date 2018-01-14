using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class deletebug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pls_Buy");

            migrationBuilder.DropTable(
                name: "shopHomeInfos");

            migrationBuilder.DropTable(
                name: "userBuyVersion");

            migrationBuilder.DropTable(
                name: "userCommentVersion");

            migrationBuilder.DropTable(
                name: "userDepartRole");

            migrationBuilder.AlterColumn<int>(
                name: "message_solve",
                table: "Pls_Message",
                nullable: false,
                defaultValue: 1)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<int>(
                name: "message_read",
                table: "Pls_Message",
                nullable: false,
                defaultValue: 1)
                .Annotation("MySql:ValueGeneratedOnAdd", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pls_Buy",
                columns: table => new
                {
                    buy_id = table.Column<string>(nullable: false),
                    buy_desc = table.Column<string>(nullable: true),
                    buy_discount = table.Column<double>(nullable: false, defaultValue: 0.0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    buy_isgive = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    buy_total = table.Column<double>(nullable: false, defaultValue: 0.0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: false),
                    version_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Buy", x => x.buy_id);
                });

            migrationBuilder.CreateTable(
                name: "shopHomeInfos",
                columns: table => new
                {
                    shop_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    shop_defaultimg = table.Column<string>(nullable: true),
                    shop_isdiscount = table.Column<bool>(nullable: false),
                    shop_money = table.Column<string>(nullable: true),
                    shop_name = table.Column<string>(nullable: true),
                    shop_paycount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopHomeInfos", x => x.shop_id);
                });

            migrationBuilder.CreateTable(
                name: "userBuyVersion",
                columns: table => new
                {
                    buy_id = table.Column<string>(nullable: false),
                    buy_actualmoney = table.Column<double>(nullable: false),
                    buy_desc = table.Column<string>(nullable: true),
                    buy_discount = table.Column<double>(nullable: false),
                    buy_isgive = table.Column<bool>(nullable: false),
                    buy_total = table.Column<double>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false),
                    disabledesc = table.Column<string>(nullable: true),
                    user_email = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    version_code = table.Column<string>(nullable: true),
                    version_id = table.Column<string>(nullable: true),
                    version_name = table.Column<string>(nullable: true),
                    version_url = table.Column<string>(nullable: true),
                    version_url_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBuyVersion", x => x.buy_id);
                });

            migrationBuilder.CreateTable(
                name: "userCommentVersion",
                columns: table => new
                {
                    comment_id = table.Column<string>(nullable: false),
                    comment_desc = table.Column<string>(nullable: true),
                    comment_read = table.Column<int>(nullable: false),
                    comment_reply = table.Column<string>(nullable: true),
                    comment_star = table.Column<int>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false),
                    disabledesc = table.Column<string>(nullable: true),
                    parant_userid = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    version_id = table.Column<string>(nullable: true),
                    version_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCommentVersion", x => x.comment_id);
                });

            migrationBuilder.CreateTable(
                name: "userDepartRole",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    department_id = table.Column<string>(nullable: true),
                    department_name = table.Column<string>(nullable: true),
                    disable = table.Column<int>(nullable: false),
                    disabledesc = table.Column<string>(nullable: true),
                    last_time = table.Column<DateTime>(nullable: false),
                    role_id = table.Column<string>(nullable: true),
                    role_name = table.Column<string>(nullable: true),
                    source_type = table.Column<int>(nullable: false),
                    user_activation = table.Column<int>(nullable: false),
                    user_code = table.Column<string>(nullable: true),
                    user_email = table.Column<string>(nullable: true),
                    user_gender = table.Column<int>(nullable: false),
                    user_image = table.Column<string>(nullable: true),
                    user_ip = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    user_phone = table.Column<string>(nullable: true),
                    user_visit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDepartRole", x => x.user_id);
                });

            migrationBuilder.AlterColumn<int>(
                name: "message_solve",
                table: "Pls_Message",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<int>(
                name: "message_read",
                table: "Pls_Message",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGeneratedOnAdd", true);
        }
    }
}
