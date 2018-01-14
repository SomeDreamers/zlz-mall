/* 功能:  部门管理实现
 * 创建人：Brian  创建时间：2016-9-17
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.message = (function () {
    var opt = {};
    var defaults = {
        listUrl: "/Admin/Message/List",
        disableUrl: "/Admin/Message/Disable",
        getUrlById: "/Admin/Message/GetById",
        updateRead: "/Admin/Message/UpdateRead",
        setResolve: "/Admin/Message/SetResolve",
        getMessageTypeNameByMsgType: "/Admin/Message/GetMessageTypeNameByMsgType",
        deleteMessageUrl: "/Admin/Message/Delete"
    };

    var columns = [{
        field: 'state',
        checkbox: true
    }, {
        title: '行号',
        field: 'number',
        hide: true,
        formatter: plscommon.tableNumber
    }, {
        title: '留言ID',
        field: 'message_id'
    }, {
        title: '用户邮箱',
        field: 'user_email',
        formatter: function (value, rows, index) {
            if (!value) {
                return "未知用户";
            }
            return value;
        }
    }, {
        title: '留言内容',
        field: 'message_desc',
    }, {
        title: '留言类别',
        field: 'message_type',
        formatter: function (value, rows, index) {
            return getMessageType(rows.message_type);
        }
    }, {
        title: '创建时间',
        field: 'createtime',
    }, {
        title: '是否已读',
        field: 'message_read',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, "read_" + rows.message_id);
        }
    }, {
        title: '是否解决',
        field: 'message_solve',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, "resolve_" + rows.message_id);
        }
    }, {
        title: '禁用状态',
        field: 'disable',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.message_id);
        }
    }]

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#messageinfo",
            url: defaults.listUrl,
            uniqueId: "message_id",
            queryParams: queryParams,
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,    //后台计算显示数据信息
            pagesize: params.limit,   //每页显示多少行
            user_email: $("#user_email_search").val(),
            disable_status: $("#distable_status_search").val()
        };
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });                //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });                        //清空文本框信息

        $("#btnForbidden").on("click", function () { btnForbidden() });                 //禁用弹出浮层
        $("#btnStart").on("click", function () { btnStart() });                         //启用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable() });                     //启用禁用方法
        $("#btnUpdateRead").on("click", function () { btnUpdateRead() });               //标为已读
        $("#btnSetResolve").on("click", function () { btnSetResolve() });               //标为已解决

        $("#btnDetail").on("click", function () { btnDetail() });                       //详情  

        $("#btnDelDialog").on("click", function () { btnDelDialog(); });                //删除弹出浮层
        $("#btnDeleteMessage").on("click", function () { btnDeleteMessage(); });        //删除方法
    };

    var btnQueryList = function () {
        plscommon.refreshTable("messageinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        opt.disable = 1;
        var rows = plscommon.selectionStatusLimit('messageinfo', 'disableOperation', "DisableEditModal", 1);
        if (!rows) {
            return false;
        }
        $("#disableName").text("留言管理");
        $("#id").val(rows);
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        opt.disable = 0;
        var rows = plscommon.selectionStatusLimit('messageinfo', 'disableOperation', "DisableEditModal", 0);
        if (!rows) {
            return false;
        }
        $("#disableName").text("留言管理");
        $("#id").val(rows);
    }

    var btnDisable = function () {
        var disable_desc = $("#disable_desc").val();
        var ids = $("#id").val().split(',');
        if (!disable_desc || disable_desc.length > 200) {
            plscommon.warningMessage("描述不能为空或者不能超过200个字符，请您检查", 3000);
            return false;
        }

        $("#btnDisable").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDisable",
            url: defaults.disableUrl,
            data: { message_id: ids, disable_desc: disable_desc, type: opt.disable },
            type: 'POST',
            success: function () {
                $('#DisableEditModal').modal('hide');
                $.each(ids, function (index, item) {
                    $("#disable_status_" + item).attr("diable_status", opt.disable);
                    $("#disable_status_" + item).html(plscommon.extend.status_ok());
                    if (opt.disable == 1) {
                        $("#disable_status_" + item).html(plscommon.extend.status_remove());
                    }
                });
            }
        });
    }

    //设置为已读
    opt.message_read = 1;   //未读
    var btnUpdateRead = function () {
        //必须选中一条才能弹出
        var rows = plscommon.getIdSelections('messageinfo', 'disableOperation');
        if (!rows) {
            return false;
        }
        var ids = [];
        $.each(rows, function (index, item) {
            ids.push(item.message_id);
        });
        opt.message_read = 0;
        plscommon.ajax({
            url: defaults.updateRead,
            data: { idList: ids },
            type: 'POST',
            success: function () {
                $.each(ids, function (index, item) {
                    $("#disable_status_read_" + item).attr("message_read", opt.message_read);
                    $("#disable_status_read_" + item).html(plscommon.extend.status_ok());
                });
            }
        });
    }

    //设置为已解决
    opt.message_solve = 1;  //未解决
    var btnSetResolve = function () {
        //必须选中一条才能弹出
        var rows = plscommon.getIdSelections('messageinfo', 'disableOperation');
        if (!rows) {
            return false;
        }
        var ids = [];
        $.each(rows, function (index, item) {
            ids.push(item.message_id);
        });
        opt.message_solve = 0;//解决
        plscommon.ajax({
            url: defaults.setResolve,
            data: { idList: ids },
            type: 'POST',
            success: function () {
                $.each(ids, function (index, item) {
                    $("#disable_status_resolve_" + item).attr("message_solve", opt.message_solve);
                    $("#disable_status_resolve_" + item).html(plscommon.extend.status_ok());
                });
            }
        });
    }

    var getMessageType = function (message_type) {
        if (message_type == "1") {
            return "网站意见";
        }
    }

    var btnDetail = function () {
        //判断是否多选
        var rows = plscommon.getIdSelections('messageinfo', 'disableOperation');
        if (rows.length > 1) {
            plscommon.warningMessage("查看详情只能选择一行，请您检查", 3000);
            return false;
        }
        var data = plscommon.dialogWaring('messageinfo', 'DetailModal', 'messageDetail');
        if (!data.message_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { message_id: data.message_id },
            success: function () {
                $("#detail_message_id").val(this.data.message_id);
                $("#detail_user_email").val(this.data.user_email);
                $("#detail_message_type").val(getMessageType(this.data.message_type));
                $("#detail_message_desc").val(this.data.message_desc);
                $("#detail_message_createtime").val(this.data.createtime);
                $("#detail_message_disable").val(this.data.disable == 0 ? "不禁用" : "已禁用");
                $("#detail_message_solve").val(this.data.message_solve == 0 ? "已处理" : "未处理");
                $("#detail_message_read").val(this.data.message_read == 0 ? "已读" : "未读");
            }
        });
    }

    var btnDelDialog = function () {
        var data = plscommon.dialogWaring('messageinfo', 'DeleteModal', 'message_Detele');
        //必须选中一条才能弹出
        var rows = plscommon.getIdSelections('messageinfo', 'disableOperation');
        if (!rows) {
            return false;
        }
        var ids = [];
        $.each(rows, function (index, item) {
            ids.push(item.message_id);
        });
        $("#delete_messge_id").val(ids);
        $("#Messge_Head_Title").text(!data.user_email ? "未知用户" : data.user_email);
        $("#Messge_Head_Title_OK").text(!data.user_email ? "未知用户" : data.user_email);
    }

    var btnDeleteMessage = function () {
        if (!$("#delete_messge_id").val()) {
            plscommon.warningMessage("请您选择需要删除的数据", 4000);
            return false;
        }

        $("#btnDeleteMessage").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDeleteMessage",
            url: defaults.deleteMessageUrl,
            type: "PUT",
            data: { messge_id: $("#delete_messge_id").val() },
            success: function () {
                $('#DeleteModal').modal('hide');
                $("#messageinfo").bootstrapTable('refresh');
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