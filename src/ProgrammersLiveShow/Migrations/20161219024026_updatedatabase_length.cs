using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class updatedatabase_length : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shopattr_weburl",
                table: "Pls_ShopAttr",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shopattr_memo",
                table: "Pls_ShopAttr",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shopattr_blogaddress",
                table: "Pls_ShopAttr",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shopattr_weburl",
                table: "Pls_ShopAttr",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shopattr_memo",
                table: "Pls_ShopAttr",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shopattr_blogaddress",
                table: "Pls_ShopAttr",
                maxLength: 64,
                nullable: true);
        }
    }
}
