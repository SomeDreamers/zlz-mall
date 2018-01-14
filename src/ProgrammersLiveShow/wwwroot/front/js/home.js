/* 功能:  前台首页实现
 * 创建人：Kencery  创建时间：2016-10-27
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.home = (function () {
    var opt = {};
    var defaults = {
        layoutUrl: "/Login/Layout",
        homeDescription: "",
        homeDescriptionStatus: ""
    };

    var initRefreshClick = function () {
        versionupgradeInfo();               //版本展示实现

        $("#btncloseClick").on("click", function () { btncloseClick(); });           //关闭顶端浮层提示
        $("#btnLayout").on("click", function () { btnLayout(); });                   //退出注册用户
    };

    var versionupgradeInfo = function () {
        if (!defaults.homeDescription) {
            return false;
        }
        $("#versionupgrade").insertBefore(".container");
        $('#versionupgrade').show();

        if (defaults.homeDescriptionStatus) {
            opt.wait = defaults.homeDescriptionStatus;
            close_version_time();
        } else {
            $("#countdown").html(defaults.homeDescription);
        }
    };

    var close_version_time = function () {
        if (opt.wait != 0) {
            opt.wait--;
            $("#countdown").html(defaults.homeDescription + "窗口将在" + opt.wait + "秒后自动关闭");
            setTimeout(function () {
                close_version_time();
            }, 1000);
        } else {
            opt.wait = 5;
            $('#versionupgrade').hide(500);
        }
    };

    var btncloseClick = function () {
        $('#versionupgrade').hide(500);
    }

    var btnLayout = function () {
        plscommon.ajax_status({
            url: defaults.layoutUrl,
            data: {},
            success: function () {
                $("#login_info_show").html('<li><a data-toggle="modal" href="#loginmodel">请登录</a></li><li><a data-toggle="modal" href="#registermodel">注册</a></li>');
            }
        });
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initRefreshClick();          //初始化页面并且触发事件
        }
    };
}());