/* 功能:  用户申请访问后台管理实现
 * 创建人：Brian  创建时间：2016-12-08
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.userapply = (function () {
    var opt = {};
    var defaults = {
        listUrl: "/Admin/UserApply/List",
        disableUrl: "/Admin/UserApply/Apply",
        getUrlById: "/Admin/UserApply/GetById"
    };

    var columns = [{
        field: 'state',
        radio: true
    }, {
        title: '行号',
        field: 'number',
        hide: true,
        formatter: plscommon.tableNumber
    }, {
        title: '申请ID',
        field: 'apply_id'
    }, {
        title: '申请人邮箱',
        field: 'user_id'
    }, {
        title: '申请理由',
        field: 'apply_reason',
    }, {
        title: '是否同意',
        field: 'is_true',
        formatter: function (value, rows, index) {
            var val = value == false ? 1 : 0;
            return plscommon.extend.disable(val, rows.apply_id);
        }
    }, {
        title: '处理人名称',
        field: 'detail_id',
        formatter: function (value, rows, index) {
            value = !value ? "/" : value;
            return '<div id="detail_id_' + rows.apply_id + '">' + value + '</div>';
        }
    }, {
        title: '处理意见',
        field: 'apply_desc',
        formatter: function (value, rows, index) {
            value = !value ? "/" : value;
            return '<div id="apply_desc_' + rows.apply_id + '">' + value + '</div>';
        }
    }, {
        title: '申请时间',
        field: 'createtime'
    }]

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#userapplyinfo",
            url: defaults.listUrl,
            uniqueId: "apply_id",
            queryParams: queryParams,
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,                          //后台计算显示数据信息
            pagesize: params.limit,                         //每页显示多少行
            user_email: $("#user_email_search").val(),
            istrue: $("#istrue_status_search").val()
        };
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });    //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });            //清空文本框信息

        $("#btnStart").on("click", function () { btnStart() });             //同意弹出浮层
        $("#btnForbidden").on("click", function () { btnForbidden() });     //不同意弹出浮层
        $("#btnApply").on("click", function () { btnApply() });             //同意/不同意方法

        $("#btnDetail").on("click", function () { btnDetail() });           //详情  
    };

    var btnQueryList = function () {
        plscommon.refreshTable("userapplyinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    var btnStart = function () {
        opt.istrue = 0;
        var data = plscommon.dialogWaringDisable('userapplyinfo', 'applyOperation');
        if (data.detail_id) {
            plscommon.warningMessage("此数据您已经处理过，不允许在处理", 3000);
            return false;
        }
        $('#ApplyEditModal').modal();

        $("#applyName").text("申请入驻后台处理");
        $("#id").val(data.apply_id);
    }

    var btnForbidden = function () {
        opt.istrue = 1;
        var data = plscommon.dialogWaringDisable('userapplyinfo', 'applyOperation');
        if (data.detail_id) {
            plscommon.warningMessage("此数据您已经处理过，不允许在处理", 3000);
            return false;
        }
        $('#ApplyEditModal').modal();
        $("#applyName").text("申请入驻后台处理");
        $("#id").val(data.apply_id);
    }

    var btnApply = function () {
        var apply_desc = $("#apply_desc").val();
        var id = $("#id").val()
        if (!apply_desc || apply_desc.length > 200) {
            plscommon.warningMessage("描述不能为空或者不能超过200个字符，请您检查", 3000);
            return false;
        }

        $("#btnApply").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnApply",
            url: defaults.disableUrl,
            data: { apply_id: id, apply_desc: apply_desc, type: opt.istrue },
            type: 'POST',
            success: function () {
                $('#ApplyEditModal').modal('hide');
                $("#disable_status_" + id).attr("diable_status", opt.istrue);
                $("#disable_status_" + id).html(plscommon.extend.status_ok());
                $("#detail_id_" + id).html(this.data);
                $("#apply_desc_" + id).html(apply_desc);
                if (opt.istrue == 1) {
                    $("#disable_status_" + id).html(plscommon.extend.status_remove());
                }
            }
        });
    }

    var btnDetail = function () {
        //判断是否选择
        var data = plscommon.dialogWaring('userapplyinfo', 'DetailModal', 'applyDetail');
        if (!data.apply_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { apply_id: data.apply_id },
            success: function () {
                var data = this.data;
                $("#detail_apply_id").val(data.apply_id);
                $("#detail_user_id").val(data.user_id);
                $("#detail_apply_reason").val(data.apply_reason);
                $("#detail_is_true").val(getIsTrue(data.is_true));
                $("#detail_createtime").val(data.createtime);
                $("#detail_apply_desc").val(data.apply_desc);
                $("#detail_detail_id").val(data.detail_id);
            }
        });
    }

    var getIsTrue = function (istrue) {
        if (istrue == "0") {
            return "不同意";
        } else {
            return "同意";
        }
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();  //初始化Table表格
            clickEvent(); //触发事件
        }
    };
}());