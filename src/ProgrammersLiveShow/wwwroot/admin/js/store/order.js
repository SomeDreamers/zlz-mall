/* 功能:  订单管理
 * 创建人：ShangW  创建时间：2016-11-26
*/
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.order = (function () {
    var opt = {
        selectchange: 0
    };
    var defaults = {
        listUrl: "/Admin/Order/List",
        detailUrl: "/Admin/Order/GetOrderById",
        payUrl: "/Admin/Order/Pay",
        disableUrl: "/Admin/Order/Disable",
        deleteUrl: "/Admin/Order/Delete",
        updradeOrderUrl: "/Admin/Order/UpgradeOrder",
        shopskuListUrl: "/Admin/Order/ShopskuList",
        shopMoneybyShopSkuId: "/Admin/Order/ShopMoneyBySkuId"
    };

    var columns = [{
        field: 'state',
        radio: true
    }, {
        title: '行号',
        field: 'number',
        align: 'center',
        hide: true,
        formatter: plscommon.tableNumber
    }, {
        title: '用户邮箱',
        field: 'user_email'
    }, {
        title: '订单编号',
        field: 'order_number'
    }, {
        title: '应付',
        field: 'order_total',
        formatter: function (value, rows, index) {
            if (value == 0) {
                return value;
            } else {
                return plscommon.extend.priceParse(value, "");
            }
        }
    }, {
        title: '优惠',
        field: 'order_privilege',
        formatter: function (value, rows, index) {
            if (value == 0) {
                return value;
            } else {
                return plscommon.extend.priceParse(value, "");
            }
        }
    }, {
        title: '实付',
        field: 'order_actualpay',
        formatter: function (value, rows, index) {
            if (value == 0) {
                return value;
            } else {
                return plscommon.extend.priceParse(value, "");
            }
        }
    }, {
        title: '支付状态',
        field: 'order_paystatus',
        formatter: function (value, rows, index) {
            var re = "";
            if (value == 1) {
                re = '<div id="order_paystatus_' + rows.order_id + '">' + plscommon.extend.is_no("未支付") + '</div>'
            } else {
                re = '<div id="order_paystatus_' + rows.order_id + '">' + plscommon.extend.is_yes("已支付") + '</div>'
            }
            return re;
        }
    }, {
        title: '支付方式',
        field: 'order_payway',
        formatter: function (value, rows, index) {
            var re = "";
            if (value == 1) {
                re = '<div id="order_payway_' + rows.order_id + '">支付宝支付</div>'
            } else {
                re = '<div id="order_payway_' + rows.order_id + '">微信支付</div>'
            }
            return re;
        }
    }, {
        title: '发货状态',
        field: 'order_goods',
        formatter: function (value, rows, index) {
            var re = "";
            if (value == 1) {
                re = '<div id="order_goods_' + rows.order_id + '">' + plscommon.extend.is_no("未发货") + '</div>'
            } else if (value == 2) {
                re = '<div id="order_goods_' + rows.order_id + '">' + plscommon.extend.is_yes("已发货") + '</div>'
            } else {
                re = '<div id="order_goods_' + rows.order_id + '">' + plscommon.extend.is_yes("确认收货") + '</div>'
            }
            return re;
        }
    }, {
        title: '删除状态',
        field: 'order_delete',
        formatter: function (value, rows, index) {
            var re = "";
            if (value == 1) {
                re = '<div id="order_delete_' + rows.order_id + '">' + plscommon.extend.is_yes("未删除") + '</div>'
            } else if (value == 2) {
                re = '<div id="order_delete_' + rows.order_id + '">' + plscommon.extend.is_no("已删除") + '</div>'
            } else {
                re = '<div id="order_delete_' + rows.order_id + '">' + plscommon.extend.is_no("彻底删除") + '</div>'
            }
            return re;
        }
    }, {
        title: '创建时间',
        field: 'createtime'
    }, {
        title: '启用状态',
        field: 'disable',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.order_id);
        }
    }];

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#orderInfo",
            url: defaults.listUrl,
            queryParams: queryParams,
            uniqueId: "order_id",
            columns: columns
        });
    };

    var queryParams = function (params) {
        return {
            offset: params.offset,
            pagesize: params.limit,
            user_email: $('#user_email_search').val(),
            order_number: $('#order_number_search').val(),
            order_paystatus: $('#order_paystatus_search').val(),
            disable: $('#distable_status').val()
        }
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });                        //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });                                //清空文本框信息

        $("#btnPayDialog").on("click", function () { btnPayDialog(); });                        //设置支付状态弹出浮层
        $("#btnPay").on("click", function () { btnPay(); });                                    //设置支付状态方法

        $("#btnUpgradeOrderDialog").on("click", function () { btnUpgradeOrderDialog(); });      //订单升级弹层
        $("#upgrade_name").on("change", function () { UpgradeNameChange() });                   //调用后台读取价钱，返回价钱信息
        $("#btnUpgradeOrder").on("click", function () { btnUpgradeOrder() });                   //升级订单按钮

        $("#btnStart").on("click", function () { btnStart() });                                 //启用弹出浮层
        $("#btnForbidden").on("click", function () { btnForbidden() });                         //禁用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable() });                             //启用禁用方法
        $("#btnDeleteDialog").on("click", function () { btnDeleteDialog(); });                  //删除弹出浮层
        $("#btnDelete").on("click", function () { btnDelete(); });                              //删除方法

        $('#btnDetail').on("click", function () { btnDetail() });                               //弹出详情浮层

    };

    var btnQueryList = function () {
        plscommon.refreshTable("orderInfo");
    };

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    };

    var btnPayDialog = function () {
        var data = $("#orderInfo").bootstrapTable('getSelections')[0];
        if (!data) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        if ($("#order_paystatus_" + data.order_id + " span").text() == "已支付") {
            plscommon.warningMessage("此订单已支付，不允许再此操作", 3000);
            return;
        }
        $('#PayModal').modal();
        plscommon.resetFrom('order_Pay');
        if (!data.order_id) {
            return false;
        }
        $("#pay_order_id").val(data.order_id);
        $(".order_Head_Title").text(data.order_number);
    }

    var btnPay = function () {
        if ($("#pay_order_id").val() == "") {
            plscommon.warningMessage("您选择的信息有误，请您重新选择", 4000);
            return false;
        }

        //禁用按钮并且发送请求
        $("#btnPay").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnPay",
            url: defaults.payUrl,
            type: "PUT",
            data: { order_id: $("#pay_order_id").val(), payway: $("#pay_type").val() },
            success: function () {
                $('#PayModal').modal('hide');
                $("#order_paystatus_" + $("#pay_order_id").val()).html(plscommon.extend.is_yes("已支付"));
                $("#order_goods_" + $("#pay_order_id").val()).html(plscommon.extend.is_yes("已发货"));
                if ($("#pay_type").val() == 1) {
                    $("#order_payway_" + $("#pay_order_id").val()).html("支付宝支付");
                } else {
                    $("#order_payway_" + $("#pay_order_id").val()).html("微信支付");
                }
            }
        });
    }

    var btnUpgradeOrderDialog = function () {
        //必须选中一条才能弹出
        var data = $("#orderInfo").bootstrapTable('getSelections')[0];
        if (!data.order_id) {
            return false;
        }
        if (data.order_paystatus == 1 || data.order_goods == 1) {
            plscommon.warningMessage("您的订单未支付或者未发货，不能升级", 3000);
            return false;
        }
        if (data.order_delete != 1) {
            plscommon.warningMessage("您的订单已被删除,不能进行升级", 3000);
            return false;
        }

        //弹出浮层并且添加调用方法填充
        $('#UpgradeOrder').modal();
        plscommon.resetFrom('UpgradeOrderOperation');
        $("#order_Head_Title").text(data.order_number)
        $("#order_Head_Title_OK").text(data.order_number)
        $("#upgrade_order_id").val(data.order_id);
        $("#upgrade_name").html("");
        $("#warning_tip").html("");

        plscommon.ajax({
            url: defaults.detailUrl,
            type: "GET",
            data: { id: data.order_id },
            success: function () {
                var data = this.data.orderdetailinfo;
                var html = "";
                for (var i = 0; i < data.length; i++) {
                    html += '<tr><td>' + data[i].shop_name + '</td><td>' + data[i].shop_code + '</td>'
                        + '<td>¥' + data[i].shop_currentprice + '</td><td>'
                        + '<a href="javascript:void(0)" class="btnUpgradeOrderByShop" shopsku_id=' + data[i].shopsku_id + ' shop_id=' + data[i].shop_id + '>升级</a></td>';
                }
                $('#tbody_upgrade').html(html);
                $(".btnUpgradeOrderByShop").unbind('click').on('click', function () { btnUpgradeOrderByShop($(this)); });            //升级完成
            }
        });
    }

    var btnUpgradeOrderByShop = function (obj) {
        //清除原始的所有的选择、并且选中当前单击行
        obj.parents("tbody").find("tr").removeClass('danger');
        obj.parents("tr").addClass('danger')
        $("#warning_tip").html("");

        //调用方法读取该商品下的商品Code
        var shop_id = obj.attr("shop_id");
        var shopsku_id = obj.attr("shopsku_id");
        $("#upgrade_shopsku_id").val(shopsku_id);
        plscommon.ajax({
            url: defaults.shopskuListUrl,
            type: "GET",
            data: { shop_id: shop_id },
            success: function () {
                var data = this.data;
                var html = "";
                for (var i = 0; i < data.length; i++) {
                    if (data[i].value == shopsku_id) {
                        html += '<option value="' + data[i].value + '" selected="selected">' + data[i].name + '</option>';
                    } else {
                        html += '<option value="' + data[i].value + '">' + data[i].name + '</option>';
                    }
                }
                $("#upgrade_name").html(html);
                return false;
            }
        });
    }

    var UpgradeNameChange = function () {
        opt.selectchange = 1;
        var shopsku_id = $("#upgrade_shopsku_id").val();
        var check_shopsku_id = $("#upgrade_name option:selected").val();
        plscommon.ajax({
            url: defaults.shopMoneybyShopSkuId,
            type: "GET",
            data: { shopsku_id: shopsku_id, check_shopsku_id: check_shopsku_id },
            success: function () {
                var data = this.data;
                if (parseFloat(data) < 0) {
                    opt.check_shopsku_id = 0;
                    $("#warning_tip").html("您选择的版本低于你现在所拥有的版本，无法升级，请选择高于现在的版本");
                    return false;
                }
                if (shopsku_id != check_shopsku_id) {
                    opt.check_shopsku_id = check_shopsku_id;
                    opt.money = data;
                    $("#warning_tip").html("您选择的商品SKU是：" + $("#upgrade_name option:selected").text() + "，您还需要在加" + data + "元，请您确认收钱后在单击升级按钮！");
                } else {
                    opt.check_shopsku_id = 0;
                    $("#warning_tip").html("您已经购买了此版本，不需要升级");
                }
                return false;
            }
        });
    }

    var btnUpgradeOrder = function () {
        if (opt.selectchange == 0 || opt.check_shopsku_id == 0) {
            plscommon.warningMessage("您已经购买了此版本或者您选择的版本低于您所购买的版本，不需要升级", 4000);
            return false;
        }
        var data = {};
        data.order_id = $("#upgrade_order_id").val();
        data.check_shopsku_id = opt.check_shopsku_id;
        data.shopsku_id = $("#upgrade_shopsku_id").val();

        $("#btnUpgradeOrder").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnUpgradeOrder",
            url: defaults.updradeOrderUrl,
            data: data,
            success: function () {
                $('#UpgradeOrder').modal('hide');
                $("#orderInfo").bootstrapTable('refresh');
            }
        });
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('orderInfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.order_id, "DisableEditModal", 0);
        opt.disable = 0;
        $("#id").val(data.order_id)
        $("#disableName").text(data.order_number);
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('orderInfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.order_id, "DisableEditModal", 1);
        opt.disable = 1;
        $("#id").val(data.order_id)
        $("#disableName").text(data.order_number);
    }

    var btnDisable = function () {
        var disable_desc = $("#disable_desc").val();
        if (disable_desc == "" || disable_desc == null || disable_desc.length > 200) {
            plscommon.warningMessage("描述不能为空或者不能超过200个字符，请您检查", 3000);
            return false;
        }

        $("#btnDisable").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDisable",
            url: defaults.disableUrl,
            type: "PUT",
            data: { order_id: $("#id").val(), disable_desc: $("#disable_desc").val(), type: opt.disable },
            success: function () {
                $('#DisableEditModal').modal('hide');
                $("#disable_status_" + $("#id").val()).attr("diable_status", opt.disable);
                $("#disable_status_" + $("#id").val()).html(plscommon.extend.status_ok());
                if (opt.disable == 1) {
                    $("#disable_status_" + $("#id").val()).html(plscommon.extend.status_remove());
                }
            }
        });
    }

    var btnDetail = function () {
        var data = plscommon.dialogWaring('orderInfo', 'DetailModal', 'orderDetail');
        if (!data.order_id) {
            return false;
        }
        $('#tbody').empty();
        plscommon.ajax({
            url: defaults.detailUrl,
            type: "GET",
            data: { id: data.order_id },
            success: function () {
                var data = this.data;
                $("#detail_order_id").val(data.order_id);
                $("#detail_order_number").val(data.order_number);
                $("#detail_user_email").val(data.user_email);
                $("#detail_order_total").val(plscommon.extend.priceParse(data.order_total));
                $("#detail_order_privilege").val(plscommon.extend.priceParse(data.order_privilege));
                $("#detail_order_actualpay").val(plscommon.extend.priceParse(data.order_actualpay));
                $("#detail_order_paystatus").val(data.order_paystatus == 1 ? "未支付" : "已支付");
                $("#detail_order_payway").val(data.order_payway == 1 ? "支付宝支付" : "微信支付");
                if (data.order_goods == 1) {
                    $("#detail_order_goods").val("未发货");
                } else if (data.order_goods == 2) {
                    $("#detail_order_goods").val("已发货");
                } else {
                    $("#detail_order_goods").val("确认收货");
                }
                if (data.order_delete == 1) {
                    $("#detail_order_delete").val("未删除");
                } else if (data.order_delete == 2) {
                    $("#detail_order_delete").val("删除回收站");
                } else {
                    $("#detail_order_delete").val("彻底删除");
                }
                $("#detail_order_memo").val(data.order_memo);
                $("#detail_order_createtime").val(data.createtime);
                $("#detail_order_disable").val(data.disable == 0 ? "未禁用" : "已禁用");
                $("#detail_order_disabledesc").val(data.disabledesc);
                var html = "";
                for (var i = 0; i < data.orderdetailinfo.length; i++) {
                    html += '<tr><td>' + data.orderdetailinfo[i].shop_name + '</td><td>' + data.orderdetailinfo[i].shop_number + '</td>'
                        + '<td>' + data.orderdetailinfo[i].shop_code + '</td><td>' + data.orderdetailinfo[i].shop_count + '</td>'
                        + '<td>¥' + data.orderdetailinfo[i].shop_currentprice + '</td><td>¥' + data.orderdetailinfo[i].shopsku_originalprice + '</td></tr>';
                }
                $('#tbody').append(html);
            }
        });
    }

    var btnDeleteDialog = function () {
        var data = $("#orderInfo").bootstrapTable('getSelections')[0];
        if (!data) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        if ($("#order_paystatus_" + data.order_id + " span").text() == "已支付") {
            plscommon.warningMessage("此订单已支付，不允许再此操作", 3000);
            return;
        }
        $('#DeleteModal').modal();
        plscommon.resetFrom('order_Detele');
        if (!data.order_id) {
            return false;
        }
        $("#delete_order_id").val(data.order_id);
        $(".order_Head_Title").text(data.order_number);
    }

    var btnDelete = function () {
        if ($("#delete_order_id").val() == "") {
            plscommon.warningMessage("您选择的信息有误，请您重新选择", 4000);
            return false;
        }

        //禁用按钮并且发送请求
        $("#btnDelete").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDelete",
            url: defaults.deleteUrl,
            type: "PUT",
            data: { order_id: $("#delete_order_id").val() },
            success: function () {
                $('#DeleteModal').modal('hide');
                $("#orderInfo").bootstrapTable('refresh');
            }
        });
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();            //初始化Table表格
            clickEvent();           //触发事件
        }
    };
}());