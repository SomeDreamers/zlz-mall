/* 功能:  部门管理实现
 * 创建人：Kencery  创建时间：2016-9-17
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.department = (function () {

    var defaults = {
        listUrl: "/Admin/Department/List",
        addUrl: "/Admin/Department/Add",
        updateUrl: "/Admin/Department/Update",
        disableUrl: "/Admin/Department/Disable",
        getUrlById: "/Admin/Department/GetById"
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
        title: '部门ID',
        field: 'department_id',
        align: 'center'
    }, {
        title: '部门名称',
        field: 'department_name',
        formatter: function (value, rows, index) {
            return '<div id="department_name_' + rows.department_id + '">' + value + '</div>';
        }
    }, {
        title: '部门描述',
        field: 'department_desc',
        formatter: function (value, rows, index) {
            return '<div id="department_desc_' + rows.department_id + '">' + value + '</div>';
        }
    }, {
        title: '创建时间',
        field: 'createtime',
    }, {
        title: '启用状态',
        field: 'disable',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.department_id);
        }
    }]

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#departmentinfo",
            url: defaults.listUrl,
            queryParams: queryParams,
            uniqueId: "department_id",
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,    //后台计算显示数据信息
            pagesize: params.limit,   //每页显示多少行
            name: $("#department_name_search").val(),
            status: $("#distable_status").val()
        };
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });    //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });            //清空文本框信息

        $("#btnAddDepart").on("click", function () { btnAddDepart(); });    //添加弹出浮层
        $("#btnEditDepart").on("click", function () { btnEditDepart(); });  //修改弹出浮层
        $("#btnAddData").on("click", function () { btnAddData(); });        //添加修改方法

        $("#btnForbidden").on("click", function () { btnForbidden() });     //禁用弹出浮层
        $("#btnStart").on("click", function () { btnStart() });             //启用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable() });         //启用禁用方法

        $("#btnDetail").on("click", function () { btnDetail() });           //详情
    };

    var btnQueryList = function () {
        plscommon.refreshTable("departmentinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    var btnAddDepart = function () {
        $('#AddEditModal').modal();
        plscommon.resetFrom("departmentOperation");
        $("#HeadTitle").text("部门信息添加");
        opt.type = 1;
    }

    var btnEditDepart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaring('departmentinfo', 'AddEditModal', 'departmentOperation');
        if (!data.department_id) {
            return false;
        }
        $("#HeadTitle").text("部门信息修改");

        //赋值
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.department_id },
            success: function () {
                $("#department_id").val(this.data.department_id);
                $("#department_name").val(this.data.department_name);
                $("#department_desc").val(this.data.department_desc);
            }
        });
        opt.type = 2;
    }

    var btnAddData = function () {
        //读取form表单中的值并且进行验证
        var data = plscommon.deleteByValue($("#departmentOperation").serializeArray(), "department_id")
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
                    $("#departmentinfo").bootstrapTable('refresh');
                }
            });
        } else {
            data.department_id = $("#department_id").val();
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.updateUrl,
                type: "PUT",
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');

                    $("#department_name_" + data.department_id).html(data.department_name);
                    $("#department_desc_" + data.department_id).html(data.department_desc);
                }
            });
        }
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('departmentinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.department_id, "DisableEditModal", 1);

        opt.disable = 1;
        $("#id").val(data.department_id)
        $("#disableName").text(data.department_name);
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('departmentinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.department_id, "DisableEditModal", 0);

        opt.disable = 0;
        $("#id").val(data.department_id)
        $("#disableName").text(data.department_name);
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
            data: { department_id: $("#id").val(), disable_desc: $("#disable_desc").val(), type: opt.disable },
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
        var data = plscommon.dialogWaring('departmentinfo', 'DetailModal', 'departmentDetail');
        if (!data.department_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.department_id },
            success: function () {
                $("#detail_department_id").val(this.data.department_id);
                $("#detail_department_name").val(this.data.department_name);
                $("#detail_department_desc").val(this.data.department_desc);
                $("#detail_department_createtime").val(this.data.createtime);
                $("#detail_department_disable").val(this.data.disable == 0 ? "不禁用" : "已禁用");
                $("#detail_department_disabledesc").val(this.data.disabledesc);
            }
        });
    }

    var checkData = function (data) {
        if (!data.department_name || !data.department_desc) {
            plscommon.warningMessage("部门名称和描述不能为空，请您检查", 3000);
            return false;
        }
        if (data.department_name.length > 18) {
            plscommon.warningMessage("部门名称只能输入1-18位", 3000);
            return false;
        }
        if (data.department_desc.length > 200) {
            plscommon.warningMessage("部门描述只能输入1-200位", 3000);
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