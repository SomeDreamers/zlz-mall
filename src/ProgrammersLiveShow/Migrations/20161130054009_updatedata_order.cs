using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class updatedata_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shop_actualmoney",
                table: "Pls_OrderDetail");

            migrationBuilder.DropColumn(
                name: "shopcoupon_money",
                table: "Pls_OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "order_payway",
                table: "Pls_Order",
                nullable: false,
                defaultValue: 1)
                .Annotation("MySql:ValueGeneratedOnAdd", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_payway",
                table: "Pls_Order");

            migrationBuilder.AddColumn<double>(
                name: "shop_actualmoney",
                table: "Pls_OrderDetail",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "shopcoupon_money",
                table: "Pls_OrderDetail",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
