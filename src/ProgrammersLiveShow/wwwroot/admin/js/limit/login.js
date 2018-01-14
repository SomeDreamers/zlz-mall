/* 功能:  登录实现
 * 创建人：Kencery  创建时间：2016-9-29 
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.login = (function () {

    var defaults = {
        url: "/Admin/Login/Login",
        homeUrl: "/Admin/Home/Index"
    };
    var image_address = [
        "http://images.chuxinm.com/chuxinm/back2.jpg",
        "http://images.chuxinm.com/chuxinm/back.jpg",
        "http://images.chuxinm.com/chuxinm/back1.jpg"
    ];

    var initPage = function () {
        $.backstretch(image_address, { fade: 2000, duration: 10000 });
    };
    var clickEvent = function () {
        $("#btnLogin").on("click", function () { btnLogin(); });                //登录
    };

    var btnLogin = function () {
        var login_name_in = $("#login_name_in").val(), user_pwd_in = $("#user_pwd_in").val();
        if (login_name_in === "" || user_pwd_in === "") {
            plscommon.warningMessage("登录信息不能为空", 3000);
            return false;
        }
        plscommon.ajax({
            url: defaults.url,
            data: { login_name_in: login_name_in, user_pwd_in: $.md5(user_pwd_in) },
            success: function () {
                window.location.href = defaults.homeUrl;
            }
        });
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initPage();  //初始化页面
            clickEvent(); //触发事件
        }
    };
}());