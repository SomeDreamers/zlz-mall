/* 功能:封装订单支付业务逻辑
 * 创建人：Kencery  创建时间：2016-11-28
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.message = (function () {

    var opt = {};
    var defaults = {
        addMessageUrl: "/System/AddMessage"
    };

    var initRefreshClick = function () {
        $("#btnAddMessage").on("click", function () { btnAddMessage() });                          //添加意见
    };

    var btnAddMessage = function () {
        var message_desc = $("#message_desc").val();
        if (!message_desc) {
            $("#message_error").show().html("系统建议留言不能为空");
            return false;
        }
        if (message_desc.length < 10) {
            $("#message_error").show().html("系统建议留言字数太少了，请您详细输入");
            return false;
        }

        //发送异步请求执行添加
        $("#btnAddMessage").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnAddMessage",
            url: defaults.addMessageUrl,
            data: { message_desc: message_desc },
            success: function () {
                if (this.status_code == 200) {
                    $("#message_desc").val("");
                    $("#message_error").show().html("添加成功");
                    
                    var login_front_pic = $(".login_front_pic img").attr("src") == undefined ? "/img/default.jpg" : $(".login_front_pic img").attr("src");
                    var login_front_name = !$("#login_front_name").text() ? "好心人" : $("#login_front_name").text();

                    var str_html = '<div class="item"><p class="col-xs-12 col-sm-12 col-md-8 col-lg-12">' + message_desc + '</p><div class="clr"></div>'
                    + '<div class="toolbar col-xs-12 col-sm-12 col-md-8 col-lg-12"><ul><li>'
                    + '<i><img src="' + login_front_pic + '" class="img img-circle" style=""></i>' + login_front_name + ''
                    + '</li><li><i class="glyphicon glyphicon-dashboard"></i>' + plscommon.extend.dataNow(new Date()) + '</li>'
                    + '<li><i class="glyphicon glyphicon-remove"></i>未处理</li></ul></div></div>';

                    $("#content").prepend(str_html);
                } else {
                    $("#message_error").show().html("添加失败，请您联系管理员");
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