/* 功能:封装个人中心订单管理实现
 * 创建人：Kencery  创建时间：2016-12-6
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.evaluate = (function () {
    var opt = {
        star: 5,
        number: 1,
    };
    var defaults = {
        orderdetail_id: "",
        shop_id: "",
        shopsku_id: "",
        uploadEvaluateImageUrl: "/Personal/UploadEvaluateImage",
        addCommentUrl: "/Personal/AddComment"
    };

    var initRefreshClick = function () {
        initStar();                                                                             //初始化星级图标评论
        $("#uploadImage").on("change", function () { uploadImage(); });                         //上传评论图片
        $("#btnAddEvaluate").on("click", function () { btnAddEvaluate(); });                    //提交评价信息
    };

    var initStar = function () {
        $('#input-2ba').rating('update', opt.star);
        $('#input-2ba').on('rating.change', function (event, value, caption) {
            opt.star = value
        });
    }

    var uploadImage = function () {
        $("#image_error").html("");
        //首先判断是否已经上传了四张图片，如果上传了则不允许在上传
        if ($(".uploadpic li").length > 4) {
            return false;
        }
        var files = $("#uploadImage").get(0).files;
        if (files.length <= 0) {
            $("#image_error").show().html("请您选择您需要上传的图片");
            return false;
        }
        var file_name = files[0].name, file_size = files[0].size;
        if (!plscommon.extend.image().test(file_name.toLocaleLowerCase())) {
            $("#image_error").show().html("图片类型必须是.gif,jpeg,jpg,png中的一种");
            return false;
        }
        if (file_size / 1024 > 1024) {
            $("#image_error").show().html("图片大小限制只能上传1M一下，请您处理图");
            return false;
        }
        //调用请求并且发送到后台进行查询返回,读取选择的商品SKuId和商品Id，同步添加数据库并且返回商品SKuid和商品图片路径
        var data = new FormData();
        data.append(file_name, files[0]);
        plscommon.ajax_image({
            disableId: "",
            url: defaults.uploadEvaluateImageUrl,
            data: data,
            success: function () {
                if (this.status_code === 200) {
                    $(".uploadpic").prepend("<li><img src='" + this.data + "'></li>");
                    let number = opt.number++
                    if (number == 4) {
                        $("#image_error").show().html("您的图片上传已上传了四张图片，不允许在上传");
                        $("#uploadImage").attr("disabled", true);
                    }
                    $(".current").text(number);

                }
            }
        });
    }

    var btnAddEvaluate = function () {
        var comment_content = $("#comment_content").val();
        if (!comment_content) {
            $("#image_error").show().html("评价内容不能为空，请您填写");
            return false;
        }

        //组装参数进行评论管理
        var image_url = new Array();
        for (var i = 0; i < $(".uploadpic li").length; i++) {
            image_url.push($(".uploadpic li").eq(i).children().attr('src'));
        }
        var data = {};
        data.orderdetail_id = defaults.orderdetail_id;
        data.shop_id = defaults.shop_id;
        data.shopsku_id = defaults.shopsku_id;
        data.comment_star = opt.star;
        data.comment_desc = comment_content;
        data.image_url = image_url;

        $("#btnAddEvaluate").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnAddEvaluate",
            url: defaults.addCommentUrl,
            data: data,
            success: function () {
                if (this.status_code === 200) {
                    //跳转个人中心
                    window.location.href = "/Personal/Index";
                } else {
                    $("#image_error").show().html("评论未成功，请您联系管理员");
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