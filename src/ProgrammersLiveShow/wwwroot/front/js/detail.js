/* 功能: 详情页面功能JS封装实现
 * 创建人：Kencery  创建时间：2016-11-24
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.detail = (function () {
    var opt = {
        cartLogin: '您还没有登录，登录后才能下订单，请您登录<a href="/Login/Index?type=0" class="btnlogin">立即登录</a>'
    };
    var defaults = {
        shop_id: "",
        shop_name: "",
        shopcoupon_id: "",
        shopcoupon_type: "",
        shopcoupon_name: "",
        getShopskuImageUrl: "/Home/GetShopskuImage",
        addOrderUrl: "/Home/AddOrder",
        getShopCommentUrl: "/Home/GetShopCommentInfo"
    };

    var initRefreshClick = function () {
        $("[data-toggle='tooltip']").tooltip();                                                     //初始化弹出优惠金额信息 
        magnifyingShowInit();                                                                       //初始化放大镜信息
        showmoreInit();                                                                             //初始化加载显示更多更少信息

        $("#add").on("click", function () { add(); });                                              //给购物车中添加数量
        $("#reduce").on("click", function () { reduce(); });                                        //给购物车中减少数量

        $(".product_versionn li").on("click", function () { productVersionImage($(this)) });        //选择版本的时候触发请求读取版本图片信息
        $("#btnAddCart").on("click", function () { btnAddCart(); });                                //添加购物车 localStorage
        $("#btnImmediatelyPay").on("click", function () { btnImmediatelyPay(); });                  //立即下单

        $("#btnCommentShop").on("click", function () { btnCommentShop(); });                        //商品评价-全部
        $("#btnGoodReputation").on("click", function () { btnGoodReputation() });                   //商品评价-好评
        $("#btnCenterReputation").on("click", function () { btnCenterReputation() });               //商品评价-中评
        $("#btnBadReputation").on("click", function () { btnBadReputation() });                     //商品评价-差评
    };

    var magnifyingShowInit = function () {
        $.fn.magnifying = function () {
            var that = $(this),
            $imgCon = that.find('.con-fangDaIMg'),//正常图片容器
            $Img = $imgCon.find('img'),//正常图片，还有放大图片集合
            $Drag = that.find('.magnifyingBegin'),//拖动滑动容器
            $show = that.find('.magnifyingShow'),//放大镜显示区域
            $showIMg = $show.find('img'),//放大镜图片
            $ImgList = that.find('.con-FangDa-ImgList > li >img'),
            multiple = $show.width() / $Drag.width();//450/150=3
            // multiple=2;
            $imgCon.mousemove(function (e) {
                $Drag.css('display', 'block');
                $show.css('display', 'block');
                //获取坐标的两种方法
                // var iX = e.clientX - this.offsetLeft - $Drag.width()/2,
                //  iY = e.clientY - this.offsetTop - $Drag.height()/2,
                var iX = e.pageX - $(this).offset().left - $Drag.width() / 2,
                    iY = e.pageY - $(this).offset().top - $Drag.height() / 2,
                    MaxX = $imgCon.width() - $Drag.width(),
                    MaxY = $imgCon.height() - $Drag.height();
                /*这一部分可代替下面部分，判断最大最小值
                var DX = iX < MaxX ? iX > 0 ? iX : 0 : MaxX,
                    DY = iY < MaxY ? iY > 0 ? iY : 0 : MaxY;
                $Drag.css({left:DX+'px',top:DY+'px'});
                $showIMg.css({marginLeft:-3*DX+'px',marginTop:-3*DY+'px'});*/
                iX = iX > 0 ? iX : 0;
                iX = iX < MaxX ? iX : MaxX;
                iY = iY > 0 ? iY : 0;
                iY = iY < MaxY ? iY : MaxY;
                $Drag.css({ left: iX + 'px', top: iY + 'px' });
                $showIMg.css({ marginLeft: -multiple * iX + 'px', marginTop: -multiple * iY + 'px' });
                //return false;
            });
            $imgCon.mouseout(function () {
                $Drag.css('display', 'none');
                $show.css('display', 'none');
            });
            $ImgList.click(function () {
                var NowSrc = $(this).data('bigimg');
                $Img.attr('src', NowSrc);
                $(this).parent().addClass('active').siblings().removeClass('active');
            });
        }
        $("#fangdajing").magnifying();
    }
    var showmoreInit = function () {
        var $params = $(".product_elaborate>li:gt(7):not(:last)");
        $params.hide();
        var $toggleBtn = $("div.showmore>a");
        $toggleBtn.click(function () {
            if ($params.is(":visible")) {
                $params.hide();
                $(this).text("+显示全部参数");
            }
            else {
                $params.show();
                $(".product_elaborate>li:gt(7):not(:last)").css("overflow", "inherit");
                $(this).text("-显示局部参数");
            }
            return false;
        });
    }

    var add = function () {
        var $add = $("#count").val();
        $("#count").val(++$add);
    }

    var reduce = function () {
        var $reduce = $("#count").val();
        if ($reduce === 0) {
            $("#count").attr("disabled", "disabled");
        }
        else {
            $("#count").val(--$reduce);
        }
    }

    var productVersionImage = function (obj) {
        //变化样式，清除以前的样式，给当前添加样式并且存放shopsku_id
        $(".product_versionn li").removeClass();
        obj.addClass("product_version_color");

        var shopsku_id = obj.attr("shopsku_id");
        $("#shopsku_id").val(shopsku_id);
        $("#shop_code").val(obj.text());

        $("#cartYesNumber").hide();

        //发送请求读取结果
        plscommon.ajax({
            disableId: "",
            url: defaults.getShopskuImageUrl,
            type: "GET",
            data: { shop_id: defaults.shop_id, shopsku_id: shopsku_id },
            success: function () {
                var data = this.data;
                $("#shopsku_originalprice").text("¥" + data.shopSkuEntity.shopsku_originalprice);
                $("#shopsku_currentprice").text("¥" + data.shopSkuEntity.shopsku_currentprice)


                //组装图片信息
                $(".con-FangDa-ImgList").html("");
                $(".con-fangDaIMg").html("");
                var strhtml = "";
                var daiImage = "";
                $.each(data.shopImageEntitys, function (i, item) {
                    if (i === 0) {
                        daiImage = '<img src="' + item.shopimage_address + '" /><div class="magnifyingBegin"></div><div class="magnifyingShow"><img src="' + item.shopimage_address + '" /></div>';
                    }
                    strhtml += '<li><img src="' + item.shopimage_address + '" data-bigimg="' + item.shopimage_address + '" class="img-thumbnail"></li>';
                });
                $(".con-FangDa-ImgList").html(strhtml);
                $(".con-fangDaIMg").html(daiImage);

                $("#fangdajing").magnifying();
            }
        });
    }

    var btnAddCart = function () {
        //组装参数，构造json串
        var array = [];
        var carts = {};
        carts.shop_id = defaults.shop_id;
        carts.shopsku_id = $("#shopsku_id").val();
        carts.shopcoupon_id = defaults.shopcoupon_id;
        carts.shopcoupon_type = defaults.shopcoupon_type;
        carts.shopcoupon_name = defaults.shopcoupon_name;
        carts.shop_defaultimg = $("#shop_defaultimg").val();
        carts.shop_name = defaults.shop_name;
        carts.shop_code = $("#shop_code").val();
        carts.shopsku_currentprice = $("#shopsku_currentprice").text().substring(1, $("#shopsku_currentprice").text().length);
        carts.number = 1;
        array.push(carts);

        if (!carts.shopsku_id) {
            $("#cartYesNumber").show();
            $("#cartYesNumber").html('商品配置信息不全,无法购买，请您联系管理员，邮箱：hyl934532778@live.cn');
            return false;
        }

        //添加购物车localStorage,如果是第一次则直接添加，否则处理业务
        var first = localStorage.getItem('carts') == null ? true : false;   //判断是否有cookie进行添加
        var same = true;//可以购买
        if (first) {
            localStorage.setItem('carts', JSON.stringify(array));
            $("#cartModel").modal();
        } else {
            var str = localStorage.getItem('carts');

            //遍历所有对象。如果商品Id和商品SKUId相同，购物车中已存在此商品，请直接支付
            var arr = JSON.parse(str);
            $.each(arr, function (i, item) {
                if (item.shop_id == carts.shop_id && item.shopsku_id == carts.shopsku_id) {
                    $("#cartYesNumber").show();
                    same = false;
                    return false;
                }
            });
            if (same) {
                arr.push(carts);
                var cookieStr = JSON.stringify(arr);
                localStorage.setItem('carts', cookieStr);
                $("#cartModel").modal();
            }
        }
    }

    var btnImmediatelyPay = function () {
        if ($("#login_front_name").text() == "" || $("#login_front_name").text() == undefined) {
            $("#cartYesNumber").show();
            $("#cartYesNumber").html(opt.cartLogin);
            return false;
        }

        //组装信息添加购物车
        var data = new Array();
        var addCarts = {};
        addCarts.shop_id = defaults.shop_id;
        addCarts.shopsku_id = $("#shopsku_id").val();
        addCarts.shop_count = 0;
        data.push(addCarts);

        if (!addCarts.shopsku_id) {
            $("#cartYesNumber").show();
            $("#cartYesNumber").html('商品配置信息不全,无法购买，请您联系管理员，邮箱：hyl934532778@live.cn');
            return false;
        }

        $("#btnImmediatelyPay").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnImmediatelyPay",
            url: defaults.addOrderUrl,
            data: { orders: data },
            success: function () {
                if (this.status_code == 200) {
                    //成功之后跳转页面
                    window.location.href = "/Home/Pay?id=" + this.data;
                } else if (this.status_code == 301) {
                    $("#cartYesNumber").show();
                    $("#cartYesNumber").html(opt.cartLogin);
                } else {
                    $("#cartYesNumber").show();
                    $("#cartYesNumber").html('您下订单失败了，请您联系管理员，邮箱：hyl934532778@live.cn');
                }
            }
        });
    }

    var btnCommentShop = function () {
        //解除绑定事件并且调用商品评价查询全部内容
        $("#btnCommentShop").unbind("click");
        plscommon.ajax_status({
            disableId: "",
            type: "GET",
            url: defaults.getShopCommentUrl,
            data: { shop_id: defaults.shop_id, type: 0 },
            success: function () {
                //组装拼接HTML并且初始化展示插件
                var data = this.data;;
                $("#allEvaluation .evaluitem").html("");

                var html = packageHtml(data);
                $("#allEvaluation .evaluitem").html(html);

                $('input.rating').rating();
            }
        });
    }

    var btnGoodReputation = function () {
        //解除绑定事件并且调用商品评价查询全部内容
        $("#btnGoodReputation").unbind("click");
        plscommon.ajax_status({
            disableId: "",
            type: "GET",
            url: defaults.getShopCommentUrl,
            data: { shop_id: defaults.shop_id, type: 1 },
            success: function () {
                //组装拼接HTML并且初始化展示插件
                var data = this.data;;
                $("#showPraise .evaluitem").html("");

                var html = packageHtml(data);
                $("#showPraise .evaluitem").html(html);

                $('input.rating').rating();
            }
        });
    }

    var btnCenterReputation = function () {
        //解除绑定事件并且调用商品评价查询全部内容
        $("#btnCenterReputation").unbind("click");
        plscommon.ajax_status({
            disableId: "",
            type: "GET",
            url: defaults.getShopCommentUrl,
            data: { shop_id: defaults.shop_id, type: 2 },
            success: function () {
                //组装拼接HTML并且初始化展示插件
                var data = this.data;;
                $("#showNeutral .evaluitem").html("");

                var html = packageHtml(data);
                $("#showNeutral .evaluitem").html(html);

                $('input.rating').rating();
            }
        });
    }

    var btnBadReputation = function () {
        //解除绑定事件并且调用商品评价查询全部内容
        $("#btnBadReputation").unbind("click");
        plscommon.ajax_status({
            disableId: "",
            type: "GET",
            url: defaults.getShopCommentUrl,
            data: { shop_id: defaults.shop_id, type: 3 },
            success: function () {
                //组装拼接HTML并且初始化展示插件
                var data = this.data;;
                $("#showbad .evaluitem").html("");

                var html = packageHtml(data);
                $("#showbad .evaluitem").html(html);

                $('input.rating').rating();
            }
        });
    }

    var packageHtml = function (data) {
        var strHtml = "";
        $.each(data, function (i, item) {
            //循环图片
            var userUrl = item.user_image || "/img/default.jpg";
            var imageUrl = "";
            $.each(item.image_address, function (i, image) {
                if (image) {
                    imageUrl += ' <li class="col-xs-6 col-sm-6 col-md-3 col-lg-3"><img src="' + image + '" class="img-thumbnail img-responsive"></li>';
                }
            });

            var comment_reply = !item.comment_reply ? "暂未回复" : item.comment_reply
            var star_length = star_info(item.comment_star);
            strHtml += '<li><ul class="evaluitem"><li class="evaluateleft col-xs-12 col-sm-12 col-md-2 col-lg-2"><dl><dd>'
                + '<div class="rating-container rating-gly" data-content=""><div class="rating-stars" data-content="" style="width: ' + star_length + '%;"></div></div>'
                + '</dd><dd>' + item.createtime + '</dd><dd>' + item.shop_code + '</dd></dl></li>'
                + '<li class="evaluatemiddle col-xs-12 col-sm-12 col-md-7 col-lg-7"><div class="commenttext">' + item.comment_desc + '</div>'
                + '<div class="commentimg"><ul>' + imageUrl + '</ul></div></li>'
                + '<li class="evaluateright col-xs-12 col-sm-12 col-md-3 col-lg-3" style="margin-top:18px;"><dl class="custumer">'
                + '<dd><img src="' + userUrl + '" class="img-responsive  img-circle">' + item.user_name + '</dd><dd>来自：WEB客户端</dd></dl></li></ul></li>'
                + '<li style="display:block;clear:both;"><ul class="reply"><li class="col-xs-12 col-sm-12 col-md-2 col-lg-2"></li>'
                + '<li class="col-xs-12 col-sm-12 col-md-7 col-lg-7"><div class="reply">初心回复：' + comment_reply + '</div>'
                + '</li></ul></li><hr style="color:#ccc;height:1px;width:100%;">'
        })
        return strHtml;
    }

    var star_info = function (star) {
        var star_length = 0;
        switch (star) {
            case 5:
                star_length = 100;
                break;
            case 4:
                star_length = 80;
                break;
            case 3:
                star_length = 60;
                break;
            case 2:
                star_length = 40;
                break;
            default:
                star_length = 20;
                break;
        }
        return star_length;
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initRefreshClick();          //初始化页面并且触发事件
        }
    };
}());