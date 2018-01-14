/* 功能:  主页管理实现
 * 创建人：Kencery  创建时间：2016-9-17
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.home = (function () {

    var defaults = {
        getUserInfo: "/Admin/Home/GetUserInfo",
        updatePassword: "/Admin/Home/UpdatePassword",
        loginUrl: "/Admin/Login/Index",
        incomeMoneyUrl: "/Admin/Order/IncomeMoney",
        expendMoney: 0,
    };

    var initHomeShow = function () {
        clickInitShow();                        //菜单信息，设置菜单样式信息
        clickEvent();                           //触发事件
        setTimeout(initMessage, 3000);          //等待5秒钟加载用户提示的消息
    }

    var clickInitShow = function () {
        $(".sub-menu>li>a").click(function () {
            //控制样式
            $(this).parent().parent().parent().siblings().last().find("ul").children(".active").removeClass("active");
            $(this).parent().parent().parent().parent().children().removeClass("start active open");
            $(this).parent().parent().children().removeClass("active");
            $(this).parent().parent().parent().addClass("start active open");
            $(this).parent().addClass("active");


            //控制连接打开
            var url = $(this).attr("url");
            if (url == ("/Admin/Home/Index").toLowerCase()) {
                window.location.reload()
                return false;
            }
            var one = $(this).parent().parent().parent().find("a").html();
            var two;
            var len = $(this).children().length;
            if (len >= 2) {
                $(this).children().last().remove();
                two = $(this).parent().html();
                $("<span class='badge badge-danger'>new</span>").appendTo(this);
            } else {
                two = $(this).parent().html();
            }
            $("#content_page").load($(this).attr("url"), function () {
                $(".panel-heading").html(one + "/" + two);
            });
        });
    }

    var clickEvent = function () {
        $("#btnUserTotal").click(function () { btnUserTotal(); });              //查看全部
        $("#btnSetUser").click(function () { btnSetUser() });                   //账号设置
        $("#btnSetUserImage").click(function () { btnSetUserImage(); });        //设置头像
        $("#updatePassword").click(function () { updatePassword(); });          //修改密码弹出浮层
        $("#btnUpdatePassword").click(function () { btnUpdatePassword(); });    //修改密码
    }

    var initMessage = function () {
        plscommon.ajax_status({
            url: defaults.getUserInfo,
            type: "GET",
            success: function () {
                var rows = this.rows;
                var user_count = 0;
                if (rows.length > 0) {
                    var messgae_li = "";
                    $.each(rows, function (name, row) {
                        user_count++;
                        messgae_li += '<li><a href="javascript:void(0);"><span class="time">' + plscommon.extend.dateParse(row.create_time) +
                            '</span><span class="details"><span class="label label-sm label-icon label-info">' +
                            '<i class="icon-beaker"></i></span>用户(' + row.user_name + ')已注册!</span></a></li>';
                    });
                    $("#userMessgaeUL").html(messgae_li)
                }

                $("#user_total").text(user_count);
                $("#user_total1").text(user_count);
                $("#user_count").text(this.total + "/" + user_count);
            }
        });
        plscommon.ajax_status({
            url: defaults.incomeMoneyUrl,
            type: "GET",
            success: function () {
                console.log(this);
                $("#revenues_desc").text("支出:" + defaults.expendMoney + "/收入:" + this + "");
                $("#revenues_number").text((this - defaults.expendMoney).toFixed(2));
            }
        });
    }

    var btnUserTotal = function () {
        $("#content_page").load("/Admin/User/Index");
    }

    var btnSetUser = function () {
        alert("二期开发,敬请期待中.......");
    }

    var btnSetUserImage = function () {
        alert("二期开发,敬请期待中......");
    }

    var updatePassword = function () {
        //弹出浮层并且情况两个文本框
        $("#UpdatePasswordModal").modal();
        $('#password_old').val("");
        $("#password_new").val("");
        $("#password_ok").val("");
    }

    var btnUpdatePassword = function () {
        //读取密码和确认密码
        var password_old = $('#password_old').val(), password_new = $("#password_new").val(), password_ok = $("#password_ok").val();
        if (!password_old || !password_new || !password_ok) {
            plscommon.warningMessage("原始密码,新密码和确认密码不能为空，请您检查", 4000);
            return false;
        }
        if (password_old.length < 6 || password_old.length > 20) {
            plscommon.warningMessage("原始密码只能输入6-20位", 4000);
            return false;
        }
        if (password_new.length < 6 || password_new.length > 20) {
            plscommon.warningMessage("新密码只能输入6-20位", 4000);
            return false;
        }
        if (password_old == password_new) {
            plscommon.warningMessage("原始密码和新密码不能相同", 4000);
            return false;
        }
        if (password_new != password_ok) {
            plscommon.warningMessage("密码和确认密码必须一致", 4000);
            return false;
        }

        $("#btnUpdatePassword").prop("disabled", true);
        var md5Password_old = $.md5(password_old), md5Password_new = $.md5(password_new);
        //发送请求进行修改密码
        plscommon.ajax({
            disableId: "btnUpdatePassword",
            url: defaults.updatePassword,
            type: "POST",
            data: { passwordOld: md5Password_old, passwordNew: md5Password_new },
            success: function () {
                $('#UpdatePasswordModal').modal('hide');
                window.location.href = defaults.loginUrl;
            }
        });
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initHomeShow();    //设置初始化信息
        }
    };
}());