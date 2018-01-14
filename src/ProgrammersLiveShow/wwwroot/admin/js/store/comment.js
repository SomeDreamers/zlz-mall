/* 功能:  评论管理
 * 创建人：ShangWW  创建时间：2016-11-14
 * 修改人：Kencery  创建时间：2016-11-29  修改内容：从原始的版本管理迁移到商品管理
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.comment = (function () {

    var defaults = {
        listUrl: "/Admin/Comment/List",
        replyUrl: "/Admin/Comment/Reply",
        disableUrl: "/Admin/Comment/Disable",
        getUrlById: "/Admin/Comment/GetCommentById",
    };
    var opt = {};

    var columns = [{
        field: 'state',
        radio: true
    }, {
        title: '行号',
        field: 'number',
        align: 'center',
        hide: true,
        formatter: plscommon.tableNumber
    }, {
        title: '用户邮箱',
        field: 'user_email',
    }, {
        title: '商品名称',
        field: 'shop_name',
    }, {
        title: '评价级别',
        field: 'comment_star',
    }, {
        title: '评论内容',
        field: 'comment_desc',
    }, {
        title: '管理员回复',
        field: 'comment_reply',
        formatter: function (value, rows, index) {
            if (value) {
                return '<div id="comment_reply_' + rows.comment_id + '">' + value + '</div>';
            }
        }
    }, {
        title: '评论时间',
        field: 'createtime',
    }, {
        title: '启用状态',
        field: 'disable',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.comment_id);
        }
    }]

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#commentinfo",
            url: defaults.listUrl,
            queryParams: queryParams,
            uniqueId: "comment_id",
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,                          //后台计算显示数据信息
            pagesize: params.limit,                         //每页显示多少行
            user_email: $("#user_email_search").val(),
            shop_name: $("#shop_name_search").val(),
            status: $("#distable_status").val()
        };
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });            //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });                    //清空文本框信息

        $("#btnReply").on("click", function () { btnReply(); });                    //回复弹出浮层
        $("#btnReplyData").on("click", function () { btnReplyData(); });            //修改方法

        $("#btnStart").on("click", function () { btnStart() });                     //启用弹出浮层
        $("#btnForbidden").on("click", function () { btnForbidden() });             //禁用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable() });                 //启用禁用方法

        $("#btnDetail").on("click", function () { btnDetail() });                   //详情

        $("#btnDeleteDialog").on("click", function () { btnDeleteDialog() });       //删除弹出浮层
        $("#btnDeleteComment").on("click", function () { btnDeleteComment() });     //删除方法
    };

    var btnQueryList = function () {
        plscommon.refreshTable("commentinfo");
    };

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    };

    var btnReply = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaring('commentinfo', 'ReplyModal', 'commentOperation');
        if (!data.comment_id) {
            return false;
        }
        $("#HeadTitle").text("(" + data.shop_name + ")评论信息回复");
        $("#comment_id").val(data.comment_id);
        $("#shop_name").val(data.shop_name);
        $("#comment_reply").val(data.comment_reply);
    }

    var btnReplyData = function () {
        //读取form表单中的值并且进行验证
        var comment_id = $("#comment_id").val(), comment_reply = $("#comment_reply").val();
        if (!comment_id || !comment_reply) {
            plscommon.warningMessage("请您输入回复内容", 3000);
            return false;
        }

        $("#btnReplyData").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnReplyData",
            url: defaults.replyUrl,
            type: "PUT",
            data: { comment_id: comment_id, comment_reply: comment_reply },
            success: function () {
                $('#ReplyModal').modal('hide');
                $("#comment_reply_" + comment_id).html(comment_reply);
            }
        });
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('commentinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.comment_id, "DisableEditModal", 0);
        opt.disable = 0;
        $("#id").val(data.comment_id)
        $("#disableName").text(data.user_name);
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('commentinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.comment_id, "DisableEditModal", 1);
        opt.disable = 1;
        $("#id").val(data.comment_id)
        $("#disableName").text(data.user_name);
    }

    var btnDisable = function () {
        var disable_desc = $("#disable_desc").val();
        if (disable_desc == "" || disable_desc == null || disable_desc.length > 200) {
            plscommon.warningMessage("描述不能为空或者不能超过200个字符，请您检查", 3000);
            return false;
        }

        $("#btnDisable").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDisable",
            url: defaults.disableUrl,
            type: "PUT",
            data: { comment_id: $("#id").val(), disable_desc: $("#disable_desc").val(), type: opt.disable },
            success: function () {
                $('#DisableEditModal').modal('hide');
                $("#disable_status_" + $("#id").val()).attr("diable_status", opt.disable);
                $("#disable_status_" + $("#id").val()).html(plscommon.extend.status_ok());
                if (opt.disable == 1) {
                    $("#disable_status_" + $("#id").val()).html(plscommon.extend.status_remove());
                }
            }
        });
    }

    var btnDetail = function () {
        var data = plscommon.dialogWaring('commentinfo', 'DetailModal', 'commentDetail');
        if (!data.comment_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.comment_id },
            success: function () {
                var data = this.data;
                $("#detail_user_email").val(data.user_email);
                $("#detail_shop_name").val(data.shop_name);
                $("#detail_comment_star").val(data.comment_star);
                $("#detail_comment_desc").val(data.comment_desc);
                $("#detail_comment_reply").val(data.comment_reply);
                $("#detail_comment_createtime").val(data.createtime);
                $("#detail_comment_disable").val(data.disable == 0 ? "未禁用" : "已禁用");
                $("#detail_comment_disabledesc").val(data.disabledesc);

                $("#imageCommentShow").html("");
                var imageInfo = data.commentImage;
                var str_image = "";
                $.each(imageInfo, function (i, image) {
                    str_image += '<img src="' + image + '" style="width:100px;height:100px" />&nbsp;&nbsp;&nbsp;';
                });
                $("#imageCommentShow").html(str_image);
            }
        });
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();  //初始化Table表格
            clickEvent(); //触发事件
        }
    };
}());