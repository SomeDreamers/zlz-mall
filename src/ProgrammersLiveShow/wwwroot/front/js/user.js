/* 功能:封装订单支付业务逻辑
 * 创建人：Kencery  创建时间：2016-11-28
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.user = (function () {

    var opt = {
        type: 1,
    };
    var defaults = {
        updateUserFrontUrl: "/User/UpdateUserFront",
        uploadUserImageUrl: "/User/UploadUserImage",
        updateUserImageUrl: "/User/UpdateUserImage",
        updateApplyUserUrl: "/User/UpdateApplyUser"
    };

    var initRefreshClick = function () {
        $("#btnUpdateUser").on("click", function () { btnUpdateUser(); });              //修改用户
        $("#uploadImage").on("change", function () { uploadImage(); });                 //上传评论图片
        $("#btnUserUploadImage").on("click", function () { btnUserUploadImage(); });    //上传用户图片
        $("#btnApplyUser").on("click", function () { btnApplyUser(); });                //申请访问后台信息
    };

    var btnUpdateUser = function () {
        $("#user_errinfo").hide();
        var data = plscommon.transitionArray($("#formUpdate").serializeArray());
        if (!data.user_name) {
            $("#user_errinfo").show().text("用户昵称不能为空，请您填写");
            return false;
        }
        if (!plscommon.extend.phone().test(data.user_phone)) {
            $("#user_errinfo").show().text("电话格式不正确，请您输入正确的电话格式");
            return false;
        }

        //发送请求修改用户信息
        $("#btnUpdateUser").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnUpdateUser",
            url: defaults.updateUserFrontUrl,
            data: data,
            success: function () {
                if (this.status_code == 200) {
                    $("#user_errinfo").show().text("恭喜您、修改成功");
                } else {
                    $("#user_errinfo").show().text(this.status_message);

                }
            }
        });
    }

    var uploadImage = function () {
        $("#image_error").html("");
        var files = $("#uploadImage").get(0).files;
        if (files.length <= 0) {
            $("#user_image_errinfo").show().html("请您选择您需要上传的图片");
            return false;
        }
        var file_name = files[0].name, file_size = files[0].size;
        if (!plscommon.extend.image().test(file_name.toLocaleLowerCase())) {
            $("#user_image_errinfo").show().html("图片类型必须是.gif,jpeg,jpg,png中的一种");
            return false;
        }
        if (file_size / 1024 > 1024) {
            $("#user_image_errinfo").show().html("图片大小限制只能上传1M一下，请您处理图");
            return false;
        }

        //调用请求并且发送到后台进行查询返回,读取选择的商品SKuId和商品Id，同步添加数据库并且返回商品SKuid和商品图片路径
        var data = new FormData();
        data.append(file_name, files[0]);
        plscommon.ajax_image({
            disableId: "",
            url: defaults.uploadUserImageUrl,
            data: data,
            success: function () {
                if (this.status_code === 200) {
                    opt.type = 2
                    $(".uploadarea img").attr('src', this.data);
                } else {
                    $("#user_image_errinfo").show().html(this.status_message);
                }
            }
        });
    }

    var btnUserUploadImage = function () {
        if (opt.type == 1) {
            $("#user_image_errinfo").show().html("请您上传新的头像");
            return false;
        }

        $("#btnUserUploadImage").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnUserUploadImage",
            url: defaults.updateUserImageUrl,
            data: { image_url: $(".uploadarea img").attr('src') },
            success: function () {
                if (this.status_code == 200) {
                    $(".login_front_pic img").attr('src', $(".uploadarea img").attr('src'));
                    $("#user_image_errinfo").show().html("恭喜您，图片上传成功");
                } else {
                    $("#user_image_errinfo").show().html(this.status_message);
                }
            }
        });
    }

    var btnApplyUser = function () {
        var apply_reason = $("#apply_reason").val();
        if (!apply_reason) {
            $("#user_appaly_errinfo").show().html("申请理由不能为空");
            return false;
        }
        if (apply_reason.length > 100) {
            $("#user_appaly_errinfo").show().html("申请理由最多只能输入100字");
            return false;
        }

        $("#btnApplyUser").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "",
            url: defaults.updateApplyUserUrl,
            data: { apply_reason: apply_reason },
            success: function () {
                if (this.status_code == 200) {
                    $("#user_appaly_errinfo").show().html("申请已经发送，请等待！");
                } else {
                    $("#user_appaly_errinfo").show().html(this.status_message);
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