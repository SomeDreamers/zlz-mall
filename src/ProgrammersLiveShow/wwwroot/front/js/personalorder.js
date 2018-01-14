/* 功能:封装个人中心订单管理实现
 * 创建人：Kencery  创建时间：2016-12-6
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.personalorder = (function () {
    var opt = {};
    var defaults = {
        deleteOrderDetailUrl: "/Personal/DeleteOrderDetail",
        updateOkGoodsUrl: "/Personal/UpdateOkGoods",
        orderListByUserIdUrl: "/Personal/OrderListByUserId"
    };

    var initRefreshClick = function () {
        $("#btnWaitforpayment").on("click", function () { btnWaitforpayment() });                 //待付款实现                           
        $("#btnWaitforreceiving").on("click", function () { btnWaitforreceiving() });             //待收货实现

        $(".btnDeleteOrderDetail").on("click", function () { btnDeleteOrderDetail($(this)) });    //删除订单详情信息
        $("#btnDeleteOk").on("click", function () { btnDeleteOk() });                             //删除订单方法

        $(".btnPayDialog").on("click", function () { btnPayDialog($(this)) });                    //订单支付确认页面
        $("#btnPayAdd").on("click", function () { btnPayAdd() });                                 //订单确认支付方法

        $(".btnGoodsOk").on("click", function () { btnGoodsOk($(this)) });                        //确认收货的实现
    };

    //待付款、待收款的HTML实现
    var btnWaitforpayment = function () {
        //解除绑定事件并且调用商品接口查询全部内容
        $("#btnWaitforpayment").unbind("click");
        plscommon.ajax_status({
            disableId: "",
            type: "GET",
            url: defaults.orderListByUserIdUrl,
            data: { type: 2 },
            success: function () {
                $("#countWaitforpayment").show().text(this.total);

                var html = packageHtml(this.rows);
                $("#waitforpayment .tbody").html(html);
                //重新给其生成的标签绑定所有事件
                $(".btnDeleteOrderDetail").unbind('click').on("click", function () { btnDeleteOrderDetail($(this)) });    //删除订单详情信息
                $(".btnPayDialog").unbind('click').on("click", function () { btnPayDialog($(this)) });                    //订单支付确认页面
                $(".btnGoodsOk").unbind('click').on("click", function () { btnGoodsOk($(this)) });                        //确认收货的实现
            }
        });
        return false;
    }
    var btnWaitforreceiving = function () {
        //解除绑定事件并且调用商品接口查询全部内容
        $("#btnWaitforreceiving").unbind("click");
        plscommon.ajax_status({
            disableId: "",
            type: "GET",
            url: defaults.orderListByUserIdUrl,
            data: { type: 3 },
            success: function () {
                $("#countWaitforreceiving").show().text(this.total);

                var html = packageHtml(this.rows);
                $("#waitforreceiving .tbody").html(html);
                //重新给其生成的标签绑定所有事件
                $(".btnDeleteOrderDetail").unbind('click').on("click", function () { btnDeleteOrderDetail($(this)) });    //删除订单详情信息
                $(".btnPayDialog").unbind('click').on("click", function () { btnPayDialog($(this)) });                    //订单支付确认页面
                $(".btnGoodsOk").unbind('click').on("click", function () { btnGoodsOk($(this)) });                        //确认收货的实现
            }
        });
        return false;
    }

    var packageHtml = function (data) {
        var strHtml = "";
        $.each(data, function (i, item) {
            var shopcoupon = "", pay_way = "", pay_status = "", pay_goods = "", buttion_click = "";
            if (item.shopcoupon_type) {
                shopcoupon = '<div class="onsaletag"><em>' + item.shopcoupon_type + '</em>' + item.shopcoupon_name + '</div>';
            }
            pay_way = item.order_payway == 1 ? "支付宝" : "微信支付";
            pay_status = item.order_paystatus == 1 ? "未支付" : "已支付";

            if (item.order_goods == 1) {
                pay_goods = '<span>未发货</span>';
            } else if (item.order_goods == 2) {
                pay_goods = '<span>已发货</span>';
            } else if (item.order_goods == 3) {
                pay_goods = '<span>已完成</span>';
            } else {
                pay_goods = '<span>已完成</span>';
            }

            if (item.order_paystatus == 1) {
                buttion_click += '<button class="btn btn-warning btnPayDialog" shop_money="' + item.order_total + '">支付订单</button>';
            }
            if (item.order_goods == 2 && item.order_paystatus == 2) {
                buttion_click += '<button class="btn btn-warning btnGoodsOk" order_id="' + item.order_id + '" shopsku_id="' + item.shopsku_id + '">确认收货</button>';
            }
            if (item.order_goods == 3 && item.orderdetail_evaluate == 1) {
                buttion_click += ' <a href="/Personal/EvaluateIndex?order_id=' + item.order_id + '&shopsku_id=' + item.shopsku_id + '">评价晒单</a>';
            }
            if (item.order_goods == 3 && item.orderdetail_evaluate == 2) {
                buttion_click += '<a href="/Personal/EvaluateIndex?order_id=' + item.order_id + '&shopsku_id=' + item.shopsku_id + '">追加评价</a>';
            }

            strHtml += '<div class="box">'
                + '<div class="boxhead"><div><em>日期:</em><em style="font-style:normal;">' + item.createtime + '</em><span style="margin-left:20px;"><em>订单编号:</em><b>' + item.order_number + '</b></span>'
                + '<i class="glyphicon glyphicon-trash btnDeleteOrderDetail" style="cursor:pointer" delete_orderid="' + item.order_id + '" delete_orderdetailId="' + item.orderdetail_id + '"></i>'
                + '</div></div>'
                + '<div style="clear:both;"></div><div class="boxbody">'

                    + '<div class="col-xs-4 col-sm-5 col-md-5 col-lg-7">'
                    + '<a href="/Home/Detail?id=' + item.shop_id + '">'
                       + '<div class="col-xs-12 col-sm-12 col-md-3 col-lg-3" style="text-align:center;">'
                            + '<img src="' + item.shop_defaultimg + '" class="img img-responsive orderimg"></div>'
                    + '<div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 orderdesc"><p>' + item.shop_name + '</p><p style="margin-left:40px;">' + item.shop_code + '</p></div></a>'
                        + '<div class="clr"></div>' + shopcoupon + '</div>'

                    + '<div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 amount"><div>总额:<span>¥</span><em>' + item.order_total + '</em><hr><em>' + pay_way + '</em></div></div>'
                    + '<div class="col-xs-2 col-sm-2 col-md-2 col-lg-1 orderstate">' + pay_status + '<br />' + pay_goods + ' </div>'
                    + '<div class="col-xs-2 col-sm-1 col-md-2 col-lg-2 orderopr">' + buttion_click
                    + '<a href="/Personal/OrderDetail?order_id=' + item.order_id + '">订单详情</a>'

                + '</div></div><div style="clear:both;"></div></div>';
        });
        return strHtml;
    }

    var btnDeleteOrderDetail = function (obj) {
        $("#deleteorderModel").modal('show');
        opt.deleteObj = obj;
        opt.orderdetail_id = obj.attr("delete_orderdetailId");
        opt.order_id = obj.attr("delete_orderid");
    }

    var btnDeleteOk = function () {
        var obj = opt.deleteObj;
        plscommon.ajax_status({
            disableId: "",
            url: defaults.deleteOrderDetailUrl,
            data: { orderdetail_id: opt.orderdetail_id, order_id: opt.order_id },
            success: function () {
                if (this.status_code == 200) {
                    $("#deleteorderModel").modal('hide');
                    obj.parents('.box').remove();
                } else {
                    alert("订单删除出现问题，请刷新之后重新单击删除标志");
                }
            }
        });
    }

    var btnPayDialog = function (obj) {
        //弹出浮层并且提示用户支付，加载显示金额
        $("#payModel").modal('show');
        $("#payMoney").html(obj.attr("shop_money"));
    }

    var checkboxPay = function (obj) {
        var shop_currentprice = parseFloat($("#shop_currentprice").text());  //当前总额
        var shopcoupon_money = parseFloat($("#shopcoupon_money").text());    //优惠额度

        if (obj.is(':checked')) {
            $("#shop_actualprice").text(shop_currentprice - shopcoupon_money);
            $("#payMoney").text(shop_currentprice - shopcoupon_money);
        } else {
            $("#shop_actualprice").text(shop_currentprice);
            $("#payMoney").text(shop_currentprice);
        }
    }

    var btnPayAdd = function () {
        $("#payModel").modal('hide');
    }

    var btnGoodsOk = function (obj) {
        //确认收货的业务逻辑是：当用户确认收货之后修改主表收货信息并且展示评价晒单
        var order_id = obj.attr("order_id");
        var shopsku_id = obj.attr("shopsku_id");
        $(".btnGoodsOk").hide();
        plscommon.ajax_status({
            disableId: "btnGoodsOk",
            url: defaults.updateOkGoodsUrl,
            data: { order_id: order_id },
            success: function () {
                if (this.status_code == 200) {
                    obj.parents('.orderopr').append('<a href="/Personal/EvaluateIndex?order_id=' + order_id + '&shopsku_id=' + shopsku_id + '">评价晒单</a>');
                } else {
                    alert("订单确认收货出现问题，请刷新之后重新单击确认收货标志");
                }
            }
        });
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initRefreshClick();             //初始化页面并且触发事件
        }
    };
}());