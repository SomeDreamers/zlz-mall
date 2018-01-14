using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersLiveShow.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pls_ButtonAction",
                columns: table => new
                {
                    action_id = table.Column<string>(nullable: false),
                    action_event = table.Column<string>(maxLength: 64, nullable: true),
                    action_icon = table.Column<string>(maxLength: 64, nullable: true),
                    action_name = table.Column<string>(maxLength: 128, nullable: false),
                    action_newaction = table.Column<bool>(nullable: false),
                    action_parentid = table.Column<string>(maxLength: 64, nullable: true),
                    action_sort = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    action_type = table.Column<int>(nullable: false, defaultValue: 2)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    action_url = table.Column<string>(maxLength: 128, nullable: true),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_ButtonAction", x => x.action_id);
                });

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
                name: "Pls_Carousel",
                columns: table => new
                {
                    carousel_id = table.Column<string>(nullable: false),
                    carousel_conent = table.Column<string>(maxLength: 100, nullable: false),
                    carousel_href = table.Column<string>(maxLength: 100, nullable: true),
                    carousel_image = table.Column<string>(maxLength: 255, nullable: false),
                    carousel_sort = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    carousel_titie = table.Column<string>(maxLength: 40, nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Carousel", x => x.carousel_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Comment",
                columns: table => new
                {
                    comment_id = table.Column<string>(nullable: false),
                    comment_desc = table.Column<string>(nullable: true),
                    comment_read = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    comment_reply = table.Column<string>(nullable: true),
                    comment_star = table.Column<int>(nullable: false, defaultValue: 5)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    parant_userid = table.Column<string>(nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: true),
                    version_id = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Comment", x => x.comment_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Department",
                columns: table => new
                {
                    department_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    department_desc = table.Column<string>(nullable: true),
                    department_name = table.Column<string>(maxLength: 128, nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Discount",
                columns: table => new
                {
                    discount_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    discount_list = table.Column<string>(maxLength: 500, nullable: false),
                    discount_money = table.Column<double>(nullable: false, defaultValue: 0.0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    endtime = table.Column<DateTime>(nullable: false),
                    is_use = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: false),
                    version_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Discount", x => x.discount_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Message",
                columns: table => new
                {
                    message_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    message_desc = table.Column<string>(nullable: true),
                    message_read = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    message_solve = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    message_type = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Message", x => x.message_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Notice",
                columns: table => new
                {
                    notice_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    notice_desc = table.Column<string>(maxLength: 100, nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Notice", x => x.notice_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Role_ButtonAction",
                columns: table => new
                {
                    rolebutton_id = table.Column<string>(nullable: false),
                    action_id = table.Column<string>(maxLength: 64, nullable: false),
                    role_id = table.Column<string>(maxLength: 64, nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Role_ButtonAction", x => x.rolebutton_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Role",
                columns: table => new
                {
                    role_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    role_desc = table.Column<string>(nullable: true),
                    role_name = table.Column<string>(maxLength: 64, nullable: false),
                    role_type = table.Column<int>(nullable: false, defaultValue: 2)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_ShopAttr",
                columns: table => new
                {
                    shopattr_id = table.Column<string>(nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    shop_id = table.Column<string>(maxLength: 64, nullable: false),
                    shopattr_author = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_blogaddress = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_condition = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_database = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_framework = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_isopensource = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    shopattr_language = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_manage = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_memo = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_opensource = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_size = table.Column<int>(nullable: false),
                    shopattr_utf = table.Column<string>(maxLength: 64, nullable: true),
                    shopattr_weburl = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_ShopAttr", x => x.shopattr_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_ShopCoupon",
                columns: table => new
                {
                    shopcoupon_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    endtime = table.Column<DateTime>(nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    shop_id = table.Column<string>(maxLength: 64, nullable: false),
                    shopcoupon_money = table.Column<double>(nullable: false),
                    shopcoupon_name = table.Column<string>(maxLength: 128, nullable: false),
                    shopcoupon_type = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_ShopCoupon", x => x.shopcoupon_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Shop",
                columns: table => new
                {
                    shop_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    shop_defaultimg = table.Column<string>(nullable: true),
                    shop_desc = table.Column<string>(nullable: true),
                    shop_isdiscount = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    shop_memo = table.Column<string>(maxLength: 64, nullable: false),
                    shop_name = table.Column<string>(maxLength: 128, nullable: false),
                    shop_number = table.Column<string>(maxLength: 64, nullable: false),
                    user_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Shop", x => x.shop_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_ShopImage",
                columns: table => new
                {
                    shopimage_id = table.Column<string>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    shop_id = table.Column<string>(maxLength: 64, nullable: false),
                    shopimage_address = table.Column<string>(maxLength: 128, nullable: false),
                    shopimage_default = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    shopsku_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_ShopImage", x => x.shopimage_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_ShopSku",
                columns: table => new
                {
                    shopsku_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    shop_code = table.Column<string>(maxLength: 128, nullable: false),
                    shop_id = table.Column<string>(maxLength: 64, nullable: false),
                    shopsku_code = table.Column<string>(maxLength: 128, nullable: true),
                    shopsku_currentprice = table.Column<string>(nullable: false),
                    shopsku_originalprice = table.Column<string>(nullable: false),
                    shopsku_url = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_ShopSku", x => x.shopsku_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_User_ButtonAction",
                columns: table => new
                {
                    userbutton_id = table.Column<string>(nullable: false),
                    action_id = table.Column<string>(maxLength: 64, nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_User_ButtonAction", x => x.userbutton_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_User_Department",
                columns: table => new
                {
                    userdepartment_id = table.Column<string>(nullable: false),
                    department_id = table.Column<string>(maxLength: 64, nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_User_Department", x => x.userdepartment_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_User",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    last_time = table.Column<DateTime>(nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    source_type = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    user_activation = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    user_code = table.Column<string>(maxLength: 10, nullable: false),
                    user_email = table.Column<string>(maxLength: 64, nullable: true),
                    user_gender = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    user_image = table.Column<string>(nullable: true),
                    user_ip = table.Column<string>(maxLength: 32, nullable: true),
                    user_name = table.Column<string>(maxLength: 32, nullable: true),
                    user_phone = table.Column<string>(maxLength: 32, nullable: true),
                    user_pwd = table.Column<string>(maxLength: 32, nullable: false),
                    user_visit = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("MySql:ValueGeneratedOnAdd", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_UserInfo",
                columns: table => new
                {
                    userinfo_id = table.Column<string>(nullable: false),
                    address = table.Column<string>(maxLength: 640, nullable: true),
                    birthday = table.Column<DateTime>(nullable: true),
                    city = table.Column<int>(nullable: true),
                    country = table.Column<int>(nullable: true),
                    direction_id = table.Column<int>(nullable: true),
                    province = table.Column<int>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 64, nullable: false),
                    zodiac = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_UserInfo", x => x.userinfo_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_User_Role",
                columns: table => new
                {
                    userrole_id = table.Column<string>(nullable: false),
                    role_id = table.Column<string>(maxLength: 54, nullable: false),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    user_id = table.Column<string>(maxLength: 54, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_User_Role", x => x.userrole_id);
                });

            migrationBuilder.CreateTable(
                name: "Pls_Version",
                columns: table => new
                {
                    version_id = table.Column<string>(nullable: false),
                    createtime = table.Column<DateTime>(nullable: false),
                    disable = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    disabledesc = table.Column<string>(nullable: true),
                    row_number = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGeneratedOnAddOrUpdate", true),
                    version_code = table.Column<string>(maxLength: 128, nullable: false),
                    version_desc = table.Column<string>(nullable: true),
                    version_image = table.Column<string>(nullable: true),
                    version_isdiscount = table.Column<bool>(nullable: false, defaultValue: true)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    version_name = table.Column<string>(maxLength: 128, nullable: false),
                    version_price = table.Column<double>(nullable: false),
                    version_remark = table.Column<string>(maxLength: 100, nullable: true),
                    version_url = table.Column<string>(maxLength: 255, nullable: true),
                    version_url_code = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pls_Version", x => x.version_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pls_ButtonAction");

            migrationBuilder.DropTable(
                name: "Pls_Buy");

            migrationBuilder.DropTable(
                name: "Pls_Carousel");

            migrationBuilder.DropTable(
                name: "Pls_Comment");

            migrationBuilder.DropTable(
                name: "Pls_Department");

            migrationBuilder.DropTable(
                name: "Pls_Discount");

            migrationBuilder.DropTable(
                name: "Pls_Message");

            migrationBuilder.DropTable(
                name: "Pls_Notice");

            migrationBuilder.DropTable(
                name: "Pls_Role_ButtonAction");

            migrationBuilder.DropTable(
                name: "Pls_Role");

            migrationBuilder.DropTable(
                name: "Pls_ShopAttr");

            migrationBuilder.DropTable(
                name: "Pls_ShopCoupon");

            migrationBuilder.DropTable(
                name: "Pls_Shop");

            migrationBuilder.DropTable(
                name: "Pls_ShopImage");

            migrationBuilder.DropTable(
                name: "Pls_ShopSku");

            migrationBuilder.DropTable(
                name: "Pls_User_ButtonAction");

            migrationBuilder.DropTable(
                name: "Pls_User_Department");

            migrationBuilder.DropTable(
                name: "Pls_User");

            migrationBuilder.DropTable(
                name: "Pls_UserInfo");

            migrationBuilder.DropTable(
                name: "Pls_User_Role");

            migrationBuilder.DropTable(
                name: "Pls_Version");
        }
    }
}
