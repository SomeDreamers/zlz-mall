using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class addtable_userapply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pls_User_Apply",
                columns: table => new
                {
                    apply_id = table.Column<string>(nullable: false),
                    apply_desc = table.Column<string>(maxLength: 100, nullable: true),
                    apply_reason = table.Column<string>(maxLength: 100, nullable: true),
                    createtime = table.Column<DateTime>(nullable: false),
                    detail_id = table.Column<string>(maxLength: 64, nullable: true),
                    is_true = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_User_Apply", x => x.apply_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pls_User_Apply");
        }
    }
}
