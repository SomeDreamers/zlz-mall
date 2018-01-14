/* 功能:封装订单支付业务逻辑
 * 创建人：Kencery  创建时间：2016-11-28
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.pay = (function () {

    var opt = {};
    var defaults = {
        updateOrderUrl: "/Home/PayOrder"
    };

    var initRefreshClick = function () {
        $("[data-toggle='tooltip']").tooltip();                                                     //初始化弹出优惠金额信息

        $("#btnPay").on("click", function () { btnPay() });                                         //支付实现
        $("input:checkbox").on("click", function () { checkboxPay($(this)) });                       //选择优惠信息
        $("#btnPayAdd").on("click", function () { btnPayAdd(); });                                  //支付完成
    };

    var btnPay = function () {
        var hidden_order_id = $("#hidden_order_id").val();  //实际的订单号
        if (!hidden_order_id) {
            alert("请您不要手动修改订单号,确认后在提交");
            return false;
        }

        var data = {};
        data.order_id = hidden_order_id;
        data.order_memo = $("#order_memo").val();
        data.isprivilege = $("input:checkbox").is(':checked');    //是否优惠

        //发送异步请求更新数据库添加优惠信息,返回成功之后跳转个人中心详情页面
        $("#btnPay").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnPay",
            url: defaults.updateOrderUrl,
            data: data,
            success: function () {
                if (this.status_code == 200) {
                    $("#payModel").modal('show');
                } else {
                    alert("订单立即支付出现问题，请刷新之后重新单击立即支付");
                }
            }
        });
        $("#payMoney").html($("#shop_actualprice").text());
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
        var order_id = $("#hidden_order_id").val();         //实际的订单号
        var order_number = $("#hidden_order_number").val(); //订单号，生成的随机数
        var money = $("#payMoney").text();                  //实际支付的金额

        window.location.href = "/Home/PaySuccess?order_id=" + order_id + "&order_number=" + order_number + "&money=" + money;
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initRefreshClick();             //初始化页面并且触发事件
        }
    };
}());