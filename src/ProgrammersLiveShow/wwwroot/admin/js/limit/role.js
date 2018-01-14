/* 功能:  部门管理实现
 * 创建人：Brian  创建时间：2016-9-17
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.role = (function () {

    var defaults = {
        listUrl: "/Admin/Role/List",
        addUrl: "/Admin/Role/Add",
        updateUrl: "/Admin/Role/Update",
        disableUrl: "/Admin/Role/Disable",
        getUrlById: "/Admin/Role/GetById",
        getZtree: "/Admin/ButtonAction/GetZtree",
        getZtreeByRoleId: "/Admin/ButtonAction/GetZtreeByRoleId",
        addRoleAction: "/Admin/ButtonAction/AddRoleAction"
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
        title: '角色ID',
        field: 'role_id',
    }, {
        title: '角色类型',
        field: 'role_type',
        formatter: function (value, rows, index) {
            return '<div id="role_type_' + rows.role_id + '">' + getRoleName(value) + '</div>';
        }
    }, {
        title: '角色名称',
        field: 'role_name',
        formatter: function (value, rows, index) {
            return '<div id="role_name_' + rows.role_id + '">' + value + '</div>';
        }
    }, {
        title: '角色描述',
        field: 'role_desc',
        formatter: function (value, rows, index) {
            return '<div id="role_desc_' + rows.role_id + '">' + value + '</div>';
        }
    }, {
        title: '创建时间',
        field: 'createtime',
    }, {
        title: '启用状态',
        field: 'disable',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.role_id);
        }
    }]

    //Ztree配置
    var setting = {
        check: {
            enable: true
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        callback: {
            onCheck: onCheck
        }
    };

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#roleinfo",
            url: defaults.listUrl,
            uniqueId: "role_id",
            queryParams: queryParams,
            columns: columns,
            onCheck: function () {
                opt.roleId = this.role_id;
            }
        });
    }

    //判断用户是否包含权限  0表示不包含任何权限，1表示包含权限
    opt.isUserAction = 0;

    //初始化Ztree
    var initZtree = function () {
        plscommon.ajax({
            url: defaults.getZtree,
            type: "GET",
            success: function () {
                $.fn.zTree.init($("#tree_role_action"), setting, this.data);
            }
        });
    }

    //Ztree的回调事件
    function onCheck(e, treeId, treeNode) {
        var treeObj = $.fn.zTree.getZTreeObj("tree_role_action"),
        nodes = treeObj.getCheckedNodes(true), value = "";
        for (var i = 0; i < nodes.length; i++) {
            value += nodes[i].id + ",";
        }
        $("#action_id").val(value.substr(0, value.length - 1));
    };

    var queryParams = function (params) {
        return {
            offset: params.offset,    //后台计算显示数据信息
            pagesize: params.limit,   //每页显示多少行
            name: $("#role_name_search").val(),
            status: $("#distable_status").val()
        };
    };

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });    //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });            //清空文本框信息

        $("#btnAddRole").on("click", function () { btnAddRole(); });    //添加弹出浮层
        $("#btnEditRole").on("click", function () { btnEditRole(); });  //修改弹出浮层
        $("#btnAddData").on("click", function () { btnAddData(); });        //添加修改方法

        $("#btnForbidden").on("click", function () { btnForbidden() });     //禁用弹出浮层
        $("#btnStart").on("click", function () { btnStart() });             //启用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable() });         //启用禁用方法

        $("#btnSetAction").on("click", function () { btnSetAction(); });        //弹出配置临时权限浮层
        $("#btnSetActionData").on("click", function () { btnSetActionData() }); //配置临时权限

        $("#btnDetail").on("click", function () { btnDetail() });//详情

    };

    var btnQueryList = function () {
        plscommon.refreshTable("roleinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    document.onkeydown = function (e) {
        //回车查询
        var ev = document.all ? window.event : e;
        if (ev.keyCode == 13) {
            ev.preventDefault();
            plscommon.refreshTable("roleinfo");
        }
    }

    var btnAddRole = function () {
        $('#AddEditModal').modal();
        plscommon.resetFrom("roleOperation");
        $("#HeadTitle").text("角色信息添加");
        opt.type = 1;
    }

    var btnEditRole = function () {
        //必须选中一条才能弹出
        if (opt.roleId == "undefined" || opt.roleId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        var data = plscommon.dialogWaring('roleinfo', 'AddEditModal', 'roleOperation');
        if (!data.role_id) {
            return false;
        }
        $("#HeadTitle").text("角色信息修改");

        //赋值
        $("#role_id").val(data.role_id);
        $("#role_name").val(data.role_name);
        $("#role_desc").val(data.role_desc);
        if (data.role_type != null) {
            $('#role_type').selectpicker('val', data.role_type);
        }
        opt.type = 2;
        $("#id").val(opt.roleId);
    }

    var initDropDownList = function () {
        plscommon.dropDownList("#role_type", '');
    }

    var btnAddData = function () {
        //读取form表单中的值并且进行验证
        var data = plscommon.deleteByValue($("#roleOperation").serializeArray(), "role_id")
        data = plscommon.transitionArray(data);
        data.role_type = $("#role_type").val();
        if (!checkData(data)) {
            return false;
        }

        $("#btnAddData").prop("disabled", true);
        if (opt.type === 1) {
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.addUrl,
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#roleinfo").bootstrapTable('refresh');
                }
            });
        } else {
            data.role_id = $("#role_id").val();
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.updateUrl,
                data: data,
                type: "PUT",
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#role_type_" + data.role_id).html($('button[data-id="role_type"]').attr("title"));
                    $("#role_name_" + data.role_id).html(data.role_name);
                    $("#role_desc_" + data.role_id).html(data.role_desc);
                    opt.actionId = null;
                }
            });
        }
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        if (opt.roleId == "undefined" || opt.roleId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }

        var data = plscommon.dialogWaringDisable('roleinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.role_id, "DisableEditModal", 1);

        opt.disable = 1;
        $("#role_id").val(data.role_id)
        $("#disableName").text(data.role_name);
        $("#id").val(opt.roleId);
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('roleinfo', 'disableOperation');
        var istrue = plscommon.dialogStatusLimit(data.role_id, "DisableEditModal", 0);

        opt.disable = 0;
        $("#role_id").val(data.role_id)
        $("#disableName").text(data.role_name);
        if (data.role_type != null) {
            $('#role_type').selectpicker('val', data.role_type);
        }
        $("#id").val(opt.roleId);
    }

    var btnDisable = function () {
        var disable_desc = $("#disable_desc").val();
        if (!disable_desc || disable_desc.length > 200) {
            plscommon.warningMessage("描述不能为空或者不能超过200个字符，请您检查", 3000);
            return false;
        }

        $("#btnDisable").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDisable",
            url: defaults.disableUrl,
            data: { role_id: $("#role_id").val(), disable_desc: disable_desc, type: opt.disable },
            type: 'POST',
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
        var data = plscommon.dialogWaring('roleinfo', 'DetailModal', 'roleDetail');
        if (!data.role_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.role_id },
            success: function () {
                $("#detail_role_id").val(this.data.role_id);
                $("#detail_role_name").val(this.data.role_name);
                $("#detail_role_type").val(getRoleName(this.data.role_type));
                $("#detail_role_desc").val(this.data.role_desc);
                $("#detail_role_createtime").val(this.data.createtime);
                $("#detail_role_disable").val(this.data.disable == 0 ? "不禁用" : "已禁用");
                $("#detail_role_disabledesc").val(this.data.disabledesc);
            }
        });
    }

    var btnSetAction = function () {
        var data = plscommon.dialogWaring('roleinfo', 'SetActionModal', 'role_action_Operation');
        if (!data.role_id) {
            return false;
        }
        $("#action_role_id").val(data.role_id);
        $("#Action_Head_Title").text(data.role_name);

        //配置ZTree
        var treeObj = $.fn.zTree.getZTreeObj("tree_role_action");
        treeObj.checkAllNodes(false);
        treeObj.expandAll(false);
        plscommon.ajax({
            url: defaults.getZtreeByRoleId,
            type: "GET",
            data: { role_id: data.role_id },
            success: function () {
                var data = this.data, i = 0;
                if (data.length > 0) {
                    for (; i < data.length; i++) {
                        treeObj.checkNode(treeObj.getNodeByParam("id", data[i]), true);
                    }
                    opt.isUserAction = 1;
                } else {
                    opt.isUserAction = 0;
                }
            }
        });
    }

    var btnSetActionData = function () {
        if ($("#action_id").val() == "" && opt.isUserAction == "0") {
            $('#SetActionModal').modal('hide');
            opt.isUserAction = 0;
            return false;
        }

        $("#btnSetActionData").prop("disabled", true);

        plscommon.ajax({
            disableId: "btnSetActionData",
            url: defaults.addRoleAction,
            type: "POST",
            data: { role_id: $("#action_role_id").val(), action_id: $("#action_id").val() },
            success: function () {
                $('#SetActionModal').modal('hide');
                opt.isUserAction = 1;
            }
        });
    }

    var checkData = function (data) {
        if (!data.role_name || !data.role_desc) {
            plscommon.warningMessage("角色名称和描述不能为空，请您检查", 3000);
            return false;
        }
        if (data.role_name.length > 18) {
            plscommon.warningMessage("角色名称只能输入1-18位", 3000);
            return false;
        }
        if (data.role_desc.length > 200) {
            plscommon.warningMessage("角色描述只能输入1-200位", 3000);
            return false;
        }
        if (!data.role_type.length) {
            plscommon.warningMessage("角色类型不能为空", 3000);
            return false;
        }
        return true;
    }

    var getRoleName = function (roleId) {
        if (roleId == "1") {
            return "前端";
        } else {
            return "后端";
        }
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();  //初始化Table表格
            initDropDownList();
            clickEvent(); //触发事件
            initZtree();            //加载ZTree
        }
    };
}());