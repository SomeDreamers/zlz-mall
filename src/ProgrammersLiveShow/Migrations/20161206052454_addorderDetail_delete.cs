using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class addorderDetail_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderdetail_delete",
                table: "Pls_OrderDetail",
                nullable: false,
                defaultValue: 1)
                .Annotation("MySql:ValueGeneratedOnAdd", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderdetail_delete",
                table: "Pls_OrderDetail");
        }
    }
}
