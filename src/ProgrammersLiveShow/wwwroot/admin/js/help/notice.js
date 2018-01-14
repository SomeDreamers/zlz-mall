/* 功能:  公告管理实现
 * 创建人：MartyZane  创建时间：2016-11-28
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.notice = (function () {

    var defaults = {
        listUrl: "/Admin/Notice/List",
        addUrl: "/Admin/Notice/Add",
        updateUrl: "/Admin/Notice/Update",
        disableUrl: "/Admin/Notice/Disable",
        getUrlById: "/Admin/Notice/GetById"
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
        title: '公告ID',
        field: 'notice_id',
        align: 'center'
    }, {
        title: '公告内容',
        field: 'notice_desc',
        formatter: function (value, rows, index) {
            return '<div id="notice_desc_' + rows.notice_id + '">' + value + '</div>';
        }
    }, {
        title: '创建时间',
        field: 'createtime',
    }, {
        title: '启用状态',
        field: 'disable',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.notice_id);
        }
    }]

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#noticeinfo",
            url: defaults.listUrl,
            queryParams: queryParams,
            uniqueId: "notice_id",
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,    //后台计算显示数据信息
            pagesize: params.limit,   //每页显示多少行
            notice_desc: $("#notice_desc_search").val(),
            disable: $("#distable_status").val()
        };
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });    //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });            //清空文本框信息

        $("#btnAddNotice").on("click", function () { btnAddNotice(); });    //添加弹出浮层
        $("#btnEditNotice").on("click", function () { btnEditNotice(); });  //修改弹出浮层
        $("#btnAddData").on("click", function () { btnAddData(); });        //添加修改方法

        $("#btnForbidden").on("click", function () { btnForbidden() });     //禁用弹出浮层
        $("#btnStart").on("click", function () { btnStart() });             //启用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable() });         //启用禁用方法

        $("#btnDetail").on("click", function () { btnDetail() });           //详情
    };

    var btnQueryList = function () {
        plscommon.refreshTable("noticeinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    var btnAddNotice = function () {
        $('#AddEditModal').modal();
        plscommon.resetFrom("noticeOperation");
        $("#HeadTitle").text("公告信息添加");
        opt.type = 1;
    }

    var btnEditNotice = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaring('noticeinfo', 'AddEditModal', 'noticeOperation');
        if (!data.notice_id) {
            return false;
        }
        $("#HeadTitle").text("公告信息修改");

        //赋值
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.notice_id },
            success: function () {
                $("#notice_id").val(this.data.notice_id);
                $("#notice_desc").val(this.data.notice_desc);
            }
        });
        opt.type = 2;
    }

    var btnAddData = function () {
        //读取form表单中的值并且进行验证
        var data = plscommon.deleteByValue($("#noticeOperation").serializeArray(), "notice_id")
        data = plscommon.transitionArray(data);
        if (!checkData(data)) {
            return false;
        }

        //对数据库进行操作
        $("#btnAddData").prop("disabled", true);
        if (opt.type === 1) {
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.addUrl,
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#noticeinfo").bootstrapTable('refresh');
                }
            });
        } else {
            data.notice_id = $("#notice_id").val();
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.updateUrl,
                type: "PUT",
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#notice_desc_" + data.notice_id).html(data.notice_desc);
                }
            });
        }
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('noticeinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.notice_id, "DisableEditModal", 1);

        opt.disable = 1;
        $("#id").val(data.notice_id)
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('noticeinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.notice_id, "DisableEditModal", 0);

        opt.disable = 0;
        $("#id").val(data.notice_id)
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
            data: { notice_id: $("#id").val(), disable_desc: $("#disable_desc").val(), type: opt.disable },
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
        var data = plscommon.dialogWaring('noticeinfo', 'DetailModal', 'noticeDetail');
        if (!data.notice_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.notice_id },
            success: function () {
                $("#detail_notice_id").val(this.data.notice_id);
                $("#detail_notice_desc").val(this.data.notice_desc);
                $("#detail_notice_createtime").val(this.data.createtime);
                $("#detail_notice_disable").val(this.data.disable == 0 ? "不禁用" : "已禁用");
                $("#detail_notice_disabledesc").val(this.data.disabledesc);
            }
        });
    }

    var checkData = function (data) {
        if (!data.notice_desc) {
            plscommon.warningMessage("公告名称和描述不能为空，请您检查", 3000);
            return false;
        }
        if (data.notice_desc.length > 200) {
            plscommon.warningMessage("公告描述只能输入1-200位", 3000);
            return false;
        }
        return true;
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();  //初始化Table表格
            clickEvent(); //触发事件
        }
    };
}());