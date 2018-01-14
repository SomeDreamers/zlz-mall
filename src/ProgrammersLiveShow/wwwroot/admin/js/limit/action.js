/* 功能:  权限(菜单/按钮)管理实现
 * 创建人：Kencery  创建时间：2016-10-8
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.action = (function () {

    var defaults = {
        listUrl: "/Admin/ButtonAction/List",
        getZtree: "/Admin/ButtonAction/GetZtree",
        getUrlById: "/Admin/ButtonAction/GetActionById",
        addUrl: "/Admin/ButtonAction/Add",
        updateUrl: "/Admin/ButtonAction/Update",
        new_wornUrl: "/Admin/ButtonAction/NewWorn",
        disableUrl: "/Admin/ButtonAction/Disable",
    };

    var opt = {};
    var columns = [{
        field: 'state',
        radio: true
    }, {
        title: '行号',
        field: 'number',
        hide: true,
        formatter: plscommon.tableNumber
    }, {
        title: '权限ID',
        field: 'action_id',
    }, {
        title: '权限名称',
        field: 'action_name',
        formatter: function (value, rows, index) {
            return '<div id="action_name_' + rows.action_id + '">' + value + '</div>';
        }
    }, {
        title: '权限URL',
        field: 'action_url',
        formatter: function (value, rows, index) {
            value = value || "/";
            return '<div id="action_url_' + rows.action_id + '">' + value + '</div>';
        }
    }, {
        title: '事件/Id',
        field: 'action_event',
        formatter: function (value, rows, index) {
            value = value || "/";
            return '<div id="action_event_' + rows.action_id + '">' + value + '</div>';
        }
    }, {
        title: '图标',
        field: 'action_icon',
        formatter: function (value, rows, index) {
            value = value || "/";
            return '<div id="action_icon_' + rows.action_id + '">' + value + '</div>';
        }
    }, {
        title: '排序',
        field: 'action_sort',
        formatter: function (value, rows, index) {
            return '<div id="action_sort_' + rows.action_id + '">' + value + '</div>';
        }
    }, {
        title: '权限类型',
        field: 'action_type',
        formatter: function (value, rows, index) {
            return '<div id="action_type_' + rows.action_id + '">' + actionType(value) + '</div>';
        }
    }, {
        title: '新功能',
        field: 'action_newaction',
        formatter: function (value, rows, index) {
            if (value) {
                return '<div id=action_' + rows.action_id + '><span class="badge badge-danger">new</span></div>';
            } else {
                return '<div id=action_' + rows.action_id + '></div>';
            }
        }
    }, {
        title: '创建时间',
        field: 'createtime',
    }, {
        title: '启用状态',
        field: 'disable',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.action_id);
        }
    }]
    var setting = {
        view: {
            selectedMulti: false
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        callback: {
            onClick: onClick
        }
    };

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#actioninfo",
            url: defaults.listUrl,
            pagination: false,
            detailView: true,
            uniqueId: "action_id",
            columns: columns,
            onExpandRow: function () {  //注册主子表的事件
                initSubTable(this.index, this.row, this.detail);
            },
            onCheck: function () {
                opt.actionId = this.action_id;
                opt.actionName = this.action_name;
            }
        });
    }
    var initSubTable = function (index, row, $detail) {
        var bootstrap_table = $detail.html('<table></table>').find('table');
        plscommon.bootstraptable({
            id: bootstrap_table,
            url: defaults.listUrl,
            queryParams: { parentId: row.action_id },
            uniqueId: "action_id",
            ajaxOptions: { parentId: row.action_id },
            toolbar: "",
            detailView: true,
            showHeader: false,
            showColumns: false,
            showRefresh: false,
            showToggle: false,
            pagination: false,
            columns: columns,
            onExpandRow: function () {
                initSubTable(this.index, this.row, this.detail);
            },
            onCheck: function () {
                opt.actionId = this.action_id;
                opt.actionName = this.action_name;
            }
        });
    }

    var initDropDownList = function () {
        plscommon.dropDownList("#action_type", '');
    }
    var initZtree = function () {
        plscommon.ajax({
            url: defaults.getZtree,
            type: "GET",
            success: function () {
                $.fn.zTree.init($("#action_parent_tree"), setting, this.data);
            }
        });
    }

    function onClick(e, treeId, treeNode) {
        $("#parent_id").val(treeNode.id);
        $("#action_parentid").val(treeNode.name);
    }

    var actionParentid = function () {
        var cityObj = $("#action_parentid");
        $("#action_menuContent").css({ top: cityObj.outerHeight() + "px" }).slideDown("fast");
        $("body").bind("mousedown", onBodyDown);
    }
    function hideMenu() {
        $("#action_menuContent").fadeOut("fast");
        $("body").unbind("mousedown", onBodyDown);
    }
    function onBodyDown(event) {
        if (!(event.target.id == "menuBtn" || event.target.id == "action_menuContent" || $(event.target).parents("#action_menuContent").length > 0)) {
            hideMenu();
        }
    }

    var clickEvent = function () {
        $("#action_parentid").on("click", function () { actionParentid() });       //获取下拉框

        $("#btnAddAction").on("click", function () { btnAddAction(); });            //添加弹出浮层
        $("#btnEditAction").on("click", function () { btnEditAction(); });          //修改弹出浮层
        $("#btnAddData").on("click", function () { btnAddData(); });                //添加修改方法

        $("#btnSetNew").on("click", function () { btnSetNew_Worn(1) });             //设置为新功能
        $("#btnSetWorn").on("click", function () { btnSetNew_Worn(0) });            //设置为旧功能

        $("#btnForbidden").on("click", function () { btnForbidden(); });            //禁用弹出浮层
        $("#btnStart").on("click", function () { btnStart(); });                    //启用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable(); });                //启用禁用方法

        $("#btnDetail").on("click", function () { btnDetail(); });                  //查看详情  
    };

    var btnAddAction = function () {
        $('#AddEditModal').modal();
        plscommon.resetFrom("actionOperation");
        $('#action_type').selectpicker('val', 2);
        $("#HeadTitle").text("权限信息添加");
        opt.type = 1;
    }

    var btnEditAction = function () {
        //必须选中一条才能弹出
        if (opt.actionId == "undefined" || opt.actionId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        $('#AddEditModal').modal();
        plscommon.resetFrom("actionOperation");
        $("#HeadTitle").text("权限信息修改");

        //配置ZTree
        var treeObj = $.fn.zTree.getZTreeObj("action_parent_tree");
        treeObj.checkAllNodes(false);
        treeObj.expandAll(false);
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: opt.actionId },
            success: function () {
                var data = this.data;
                //调用请求并且进行将查询返回的值传入控件
                $("#action_name").val(data.action_name);
                $("#action_url").val(data.action_url);
                //选中parentId的下拉框并且填写内容
                var checkInfo = treeObj.getNodeByParam("id", data.action_parentid);
                if (checkInfo != null) {
                    treeObj.selectNode(checkInfo, true);
                    $("#parent_id").val(checkInfo.id);
                    $("#action_parentid").val(checkInfo.name);
                }
                $("#action_icon").val(data.action_icon);
                $("#action_sort").val(data.action_sort);
                $("#action_event").val(data.action_event);
                $('#action_type').selectpicker('val', data.action_type);
            }
        });
        opt.type = 2;
    }

    var btnAddData = function () {
        //读取form表单中的值并且进行验证
        var data = plscommon.deleteByValue($("#actionOperation").serializeArray());
        data = plscommon.transitionArray(data);

        //处理一些特殊字段
        data.action_type = $("#action_type").val();  //类型选择和父Id等信息
        var data_parent_id = $("#action_parentid").val() == "" ? 0 : data.parent_id;
        data.action_parentid = data_parent_id;

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
                    $("#actioninfo").bootstrapTable('refresh');
                }
            });
        } else {
            data.action_id = opt.actionId;
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.updateUrl,
                type: "PUT",
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#action_name_" + data.action_id).html(data.action_name);
                    $("#action_url_" + data.action_id).html(data.action_url);
                    $("#action_event_" + data.action_id).html(data.action_event);
                    $("#action_icon_" + data.action_id).html(data.action_icon);
                    $("#action_sort_" + data.action_id).html(data.action_sort);
                    $("#action_type_" + data.action_id).html($('button[data-id="action_type"]').attr("title"));
                }
            });
        }
    }

    var btnSetNew_Worn = function (type) {
        //必须选中一条才能弹出
        if (opt.actionId == "undefined" || opt.actionId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        plscommon.ajax({
            url: defaults.new_wornUrl,
            type: "PUT",
            data: { id: opt.actionId, type: type },
            success: function () {
                //这里不需要刷新页面实现
                $("#action_" + opt.actionId).html("");
                if (type == 1) {
                    $("#action_" + opt.actionId).html('<span class="badge badge-danger">new</span>');
                }
            }
        });
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        if (opt.actionId == "undefined" || opt.actionId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        plscommon.resetFrom("disableOperation");
        var istrue = plscommon.dialogStatusLimit(opt.actionId, "DisableEditModal", 1);
        opt.disable = 1;
        $("#id").val(opt.actionId);
        $("#disableName").text(opt.actionName);
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        if (opt.actionId == "undefined" || opt.actionId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        plscommon.resetFrom("disableOperation");
        var istrue = plscommon.dialogStatusLimit(opt.actionId, "DisableEditModal", 0);
        opt.disable = 0;
        $("#id").val(opt.actionId);
        $("#disableName").text(opt.actionName);
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
            type: "PUT",
            data: { action_id: $("#id").val(), disable_desc: disable_desc, type: opt.disable },
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
        //必须选中一条才能弹出
        if (opt.actionId == "undefined" || opt.actionId == null) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        $('#DetailModal').modal();
        plscommon.resetFrom("actionDetail");

        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: opt.actionId },
            success: function () {
                var data = this.data;
                $("#detail_action_id").val(data.action_id);
                $("#detail_action_name").val(data.action_name);
                $("#detail_action_parentid").val(data.action_parentid);
                $("#detail_action_url").val(data.action_url);
                $("#detail_action_icon").val(data.action_icon);
                $("#detail_action_sort").val(data.action_sort);
                $("#detail_action_event").val(data.action_event);
                $("#detail_action_type").val(actionType(data.action_type));
                $("#detail_action_newaction").val(data.action_newaction ? "是" : "否");
                $("#detail_action_createtime").val(data.createtime);
                $("#detail_action_disable").val(data.disable == 0 ? "不禁用" : "已禁用");
                $("#detail_action_disabledesc").val(data.disabledesc);
            }
        });
    }

    var checkData = function (data) {
        if (!data.action_name || !data.action_sort || !data.action_type) {
            plscommon.warningMessage("字段不能为空，请您检查", 4000);
            return false;
        }
        if (data.action_name.length > 64) {
            plscommon.warningMessage("权限名称只能输入1-64位", 4000);
            return false;
        }
        if (data.action_url.length > 50) {
            plscommon.warningMessage("权限URL只能输入1-32位", 4000);
            return false;
        }
        if (data.action_icon.length > 40) {
            plscommon.warningMessage("权限Icon只能输入1-40位", 4000);
            return false;
        }
        if (!plscommon.extend.plastic().test(data.action_sort)) {
            plscommon.warningMessage("排序格式不正确，请您输入正确的排序格式(只能为正整数)", 4000);
            return false;
        }
        return true;
    }

    var actionType = function (action_type) {
        var result = "";
        if (action_type == 1) {
            result = "前台导航";
        } else if (action_type == 2) {
            result = "后台左侧导航"
        } else if (action_type == 4) {
            result = "后台查询"
        } else if (action_type == 5) {
            result = "普通按钮-不显示";
        } else {
            result = "普通按钮";
        }
        return result;
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();            //初始化Table表格
            clickEvent();           //触发事件
            initDropDownList();     //初始化下拉框，填写值信息
            initZtree();            //加载ZTree
        }
    };
}());