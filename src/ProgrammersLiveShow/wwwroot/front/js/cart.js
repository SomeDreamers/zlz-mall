/* 功能: 购物车JS封装功能
 * 创建人：Kencery  创建时间：2016-11-25
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.cart = (function () {
    var opt = {
        orderLogin: '您还没有登录，登录后才能下订单，请您登录<a href="/Login/Index?type=0" class="btnlogin">立即登录</a>',
        checkorder: 0,
        orderall: 0
    };

    var defaults = {
        addOrderUrl: "/Home/AddOrder",
    };

    var initRefreshClick = function () {
        initCartInfos();                                                                         //加载购物车中的信息

        $("#checkedAllTop").on("click", function () { checkedAll("checkedAllTop") });           //单击顶端全选选中所有的内容
        $("#checkedAllButton").on("click", function () { checkedAll("checkedAllButton") });     //单击底部全选选中所有的内容
        $(".deleteCarts").on("click", function () { deleteCarts($(this)) });                    //单击删除商品
        $(".supplyCheckout").on("click", function () { Supply($(this)) });                      //任意单击的时候触发事件 
        $("#btnAddOrder").on("click", function () { btnAddOrder(); });                          //提交订单实现
    };

    var initCartInfos = function () {
        //读取localStorage的信息并且循环显示购物车
        var carts = JSON.parse(localStorage.getItem('carts'));
        if (carts == null) {
            $(".cart").hide();
            $(".cartNotNull").show();
        } else {
            //循环组装购物车的信息
            var str_html = "";
            $.each(carts, function (i, item) {
                var ishtml = "";
                if (item.shopcoupon_type != "") {
                    ishtml = '<div class="actiondis"><b>' + item.shopcoupon_type + '</b>' + item.shopcoupon_name + '</div>'
                }
                str_html += '<div class="cartdetail"><div class="supply"><input type="checkbox" class="supplyCheckout" name="supply' + i + '"><label for="supply">初心商城</label></div><div class="supplydetail">'
                   + ishtml
                    + '<div class="brand col-xs-12 col-sm-6 col-md-6 col-lg-6">'
                        + '<div class="img col-xs-12 col-sm-4 col-md-4 col-lg-4"><img src="' + item.shop_defaultimg + '" class="img-responsive"></div>'
                        + '<div class="des col-xs-12 col-sm-8 col-md-8 col-lg-8"><p><a href="/Home/Detail?id=' + item.shop_id + '" shop_id_add=' + item.shop_id + '>' + item.shop_name + '</a></p>'
                        + '<p><span shop_skuid_add=' + item.shopsku_id + '></span>' + item.shop_code + '</p></div>'
                        + '</div>'
                        + '<div class="col-xs-12 col-sm-1 col-md-1 col-lg-1"><em class="unitprice">' + item.shopsku_currentprice + '</em><span class="money">元</span></div>'
                        + '<div class="maincount col-xs-12 col-sm-3 col-md-3 col-lg-3"><div class="countcombine"><div class="btn-group">'
                            + '<button class="reduce btn btn-default" disabled type="button">-</button>'
                            + '<input class="count btn btn-default" disabled type="text" value="1">'
                            + '<button class="add btn btn-default" disabled type="button">+</button>'
                        + '</div></div></div>'
                        + '<div class="col-xs-12 col-sm-1 col-md-1 col-lg-1"><em class="total">' + item.shopsku_currentprice + '</em><span class="money">元</span></div>'
                        + '<div class="col-xs-12 col-sm-1 col-md-1 col-lg-1"><a href="javascript:void(0)" class="deleteCarts" shop_id="' + item.shop_id + '" shopsku_id="' + item.shopsku_id + '">删除</a></div>'
                        + '<div style="clear:both;"></div></div></div>'
                        + '<div style="clear:both;"></div>';
            });
            $("#tableCarts").html(str_html);

            //初始化全部选中
            $("input[type='checkbox']").prop("checked", true);
            var sum = 0, number = 0;
            var $total = $(".total")
            for (var i = 0; i < $(".total").length; i++) {
                var partialprice = parseFloat($($(".total").get(i)).text());
                sum += partialprice;
                number++
            }
            $(".sumPrice").children("em").html(sum.toFixed(2));
            $(".amount-sum").children("em").html(number)

        }
    }

    var checkedAll = function (checkAll) {
        if ($('#' + checkAll).is(':checked')) {
            $("input[type='checkbox']").prop("checked", true);
            //单击完成之后需要计算总数
            var sum = 0, number = 0;
            var $total = $(".total")
            for (var i = 0; i < $(".total").length; i++) {
                var partialprice = parseFloat($($(".total").get(i)).text());
                sum = sum + partialprice;
                number++
            }

            $(".sumPrice").children("em").html(sum.toFixed(2));
            $(".amount-sum").children("em").html(number)
        }
        else {
            $("input[type='checkbox']").prop("checked", false);

            $(".sumPrice").children("em").html("00.00");
            $(".amount-sum").children("em").html(0);
        }
    }

    var deleteCarts = function (obj) {
        var shop_id = obj.attr("shop_id"), shopsku_id = obj.attr("shopsku_id");
        if (confirm("您确定要从购物车中删除掉这条记录吗？")) {
            //从localStorage中删除这条语句并且删除这一行，第一个变量存放获取到的值，第二个删除掉获取的值,遍历所有对象，重新构造购物车
            var arr = JSON.parse(localStorage.getItem("carts"));
            var arr2 = [];
            $.each(arr, function (i, item) {
                if (item.shopsku_id != undefined && shopsku_id != undefined && item.shopsku_id != shopsku_id) {
                    arr2.push(item);
                }
            });

            if (arr2.length > 0) {
                localStorage.setItem('carts', JSON.stringify(arr2));
            } else {
                localStorage.removeItem("carts");
                $(".cart").hide();
                $(".cartNotNull").show();
            }
            obj.parents(".cartdetail").remove();

            //删除完成之后重新计算总数
            var sum = 0, number = 0;
            var $total = $(".total")
            for (var i = 0; i < $(".total").length; i++) {
                var partialprice = parseInt($($(".total").get(i)).text());
                sum += partialprice;
                number++
            }
            $(".sumPrice").children("em").html(sum);
            $(".amount-sum").children("em").html(number)
        }
    }

    var Supply = function (obj) {
        $("#checkedAllTop").prop("checked", false);
        $("#checkedAllButton").prop("checked", false);

        var number = parseFloat($(".sumPrice").children("em").text());
        var curr_number = parseFloat(obj.parents('.cartdetail').find('.total').text());

        var count = 0
        //单击当前对象读取选中与否(true:选中 +钱，false :不选中 -钱)
        if (obj.is(':checked')) {
            number = number + curr_number;
        } else {
            number = number - curr_number;
        }

        //读取选中的总数
        var cartdetail = $(".cartdetail");
        for (var i = 0; i < cartdetail.length ; i++) {
            //首先判断多选框是否选中，如果选中，则添加，如果取消则减少
            if ($("input[type='checkbox'][name='supply" + i + "']").is(':checked')) {
                count++
            }
        }
        if (cartdetail.length == count) {  //相同则全部按钮选中
            $("#checkedAllTop").prop("checked", true);
            $("#checkedAllButton").prop("checked", true);
        }

        $(".sumPrice").children("em").html(number.toFixed(2));
        $(".amount-sum").children("em").html(count);
    }

    var btnAddOrder = function () {
        var count = $(".amount-sum").children("em").text(), number = parseInt($(".sumPrice").children("em").text());
        if (count == 0 || number == 0 || isNaN(number)) {
            $("#error_cart_message").show();
            $("#error_cart_message").html("请选择您要购买的商品之后在下单...");
            return false;
        }
        if ($("#login_front_name").text() == "" || $("#login_front_name").text() == undefined) {
            $("#error_cart_message").show();
            $("#error_cart_message").html(opt.orderLogin);
            return false;
        }

        //循环读取选中的数据，得到shop_id和以及数量，组装成集合插入数据库
        var cartdetail = $(".cartdetail"), data = new Array();

        for (var i = 0; i < cartdetail.length ; i++) {
            opt.orderall++;
            if ($("input[type='checkbox'][name='supply" + i + "']").is(':checked')) {
                //读取选中的shop_id和shopsku_id,进行组装成实体对象
                opt.checkorder++;
                var addCarts = {};
                addCarts.shop_id = $($(".cartdetail ").get(i)).find('a').attr('shop_id_add');
                addCarts.shopsku_id = $($(".cartdetail ").get(i)).find('span').attr('shop_skuid_add');
                addCarts.shop_count = 0;
                data.push(addCarts);
            }
        }

        $("#btnAddOrder").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnAddOrder",
            url: defaults.addOrderUrl,
            data: { orders: data },
            success: function () {
                if (this.status_code == 200) {
                    //成功之后首先执行删除购物车中的某些内容，然后跳转页面
                    if (opt.orderall == opt.checkorder) {
                        localStorage.removeItem("carts");
                    } else {
                        deleteCartBySkuId(data);
                    }
                    window.location.href = "/Home/Pay?id=" + this.data;
                } else if (this.status_code == 301) {
                    $("#error_cart_message").show();
                    $("#error_cart_message").html(opt.orderLogin);
                } else {
                    $("#error_cart_message").show();
                    $("#error_cart_message").html('您下订单失败了，请您联系管理员，邮箱：hyl934532778@live.cn');
                }
            }
        });
    }

    var deleteCartBySkuId = function (data) {
        //组装条件，删除购物车中的某些内容,传递的内容
        var arr = JSON.parse(localStorage.getItem("carts"));
        var arr2 = [];
        $.each(arr, function (i, item) {
            $.each(data, function (i, item1) {
                if (item.shopsku_id != undefined && item1.shopsku_id != undefined && item.shopsku_id != item1.shopsku_id) {
                    arr2.push(item);
                }
            });
        });
        localStorage.setItem('carts', JSON.stringify(arr2));
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initRefreshClick();          //初始化页面并且触发事件
        }
    };
}());