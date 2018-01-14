/* 功能:  用户管理
 * 创建人：Kencery  创建时间：2016-10-01
 */
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.user = (function () {

    var defaults = {
        listUrl: "/Admin/User/List",
        getUrlById: "/Admin/User/getInnerById",
        departmentlistNoDisable: "/Admin/Department/listNoDisable",
        roleListNoDisable: "/Admin/Role/listNoDisable",
        checkDataUrl: "/Admin/Login/checkData",
        addUrl: "/Admin/User/AddAdmin",
        updateUrl: "/Admin/User/UpdateAdmin",
        disableUrl: "/Admin/User/Disable",
        updateSetRole: "/Admin/User/UpdateSetRole",
        getZtree: "/Admin/ButtonAction/GetZtree",
        getZtreeById: "/Admin/ButtonAction/GetZtreeById",
        addUserAction: "/Admin/ButtonAction/AddUserAction",
        deleteUser: "/Admin/User/Delete",
        activateUrl: "/Admin/User/Activate",
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
        title: '用户ID',
        field: 'user_id',
    }, {
        title: '用户名',
        field: 'user_name',
        formatter: function (value, rows, index) {
            value = value || "";
            return '<div id="user_name_' + rows.user_id + '">' + value + '</div>';
        }
    }, {
        title: '编号',
        field: 'user_code',
    }, {
        title: '真实名称',
        field: 'full_name',
        formatter: function (value, rows, index) {
            value = value || "";
            return '<div id="full_name_' + rows.user_id + '">' + value + '</div>';
        }
    }, {
        title: '邮箱',
        field: 'user_email',
        formatter: function (value, rows, index) {
            return '<div id="user_email_' + rows.user_id + '">' + value + '</div>';
        }
    }, {
        title: '电话',
        field: 'user_phone',
        formatter: function (value, rows, index) {
            return '<div id="user_phone_' + rows.user_id + '">' + value + '</div>';
        }
    }, {
        title: '性别',
        field: 'user_gender',
        formatter: function (value, rows, index) {
            return '<div id="user_gender_' + rows.user_id + '">' + bankGender(value) + '</div>';
        }
    }, {
        title: '来源',
        field: 'source_type',
        formatter: function (value, rows, index) {
            return value == 1 ? "前端" : "后端";
        }
    }, {
        title: '创建时间',
        field: 'createtime',
    }, {
        title: '登录时间',
        field: 'last_time',
    }, {
        title: '启用',
        field: 'disable',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.user_id);
        }
    }, {
        title: '激活',
        field: 'user_activation',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, "activation_" + rows.user_id);
        }
    }, {
        title: '入驻',
        field: 'user_visit',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, "visit_" + rows.user_id);
        }
    }, {
        title: '所属部门',
        field: 'department_name',
        align: 'center',
        formatter: function (value, rows, index) {
            return '<div id="department_name_' + rows.user_id + '">' + value + '</div>';
        }
    }, {
        title: '所属角色',
        field: 'role_name',
        align: 'center',
        formatter: function (value, rows, index) {
            return '<div id="role_name_' + rows.user_id + '">' + value + '</div>';
        }
    }]
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

    //判断用户是否包含权限  0表示不包含任何权限，1表示包含权限
    opt.isUserAction = 0;
    //判断用户是否包含角色  0表示不包含任何角色，1表示包含角色
    opt.isUserRole = 0;

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#userinfo",
            url: defaults.listUrl,
            queryParams: queryParams,
            uniqueId: "user_id",
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,             //后台计算显示数据信息
            pagesize: params.limit,            //每页显示多少行
            name: $("#user_search").val(),
            gender: $("#user_gender_search").val(),
            source: $("#source_type_search").val(),
            status: $("#distable_status").val()
        };
    };

    var initDropDownList = function () {
        plscommon.dropDownList("#departmnet_name", defaults.departmentlistNoDisable);
        plscommon.dropDownList("#role_name", defaults.roleListNoDisable);
    }

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });                //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });                        //清空文本框信息

        $("#user_email").on("blur", function () { checkUser_Email(); });                 //检查邮箱是否存在
        $("#user_phone").on("blur", function () { checkUser_Phone(); });                 //检查电话是否存在

        $("#btnAddUser").on("click", function () { btnAddUser(); });                     //添加弹出浮层
        $("#btnEditUser").on("click", function () { btnEditUser(); });                   //修改弹出浮层
        $("#btnAddData").on("click", function () { btnAddData(); });                     //添加修改方法

        $("#btnForbidden").on("click", function () { btnForbidden(); });                 //禁用弹出浮层
        $("#btnStart").on("click", function () { btnStart(); });                         //启用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable(); });                     //启用禁用方法

        $("#btnSetRole").on("click", function () { btnSetRole(); });                     //弹出配置角色浮层
        $("#btnSetRoleData").on("click", function () { btnSetRoleData(); });             //配置角色方法

        $("#btnSetAction").on("click", function () { btnSetAction(); });                 //弹出配置临时权限浮层
        $("#btnSetActionData").on("click", function () { btnSetActionData() });          //配置临时权限

        $("#btnDeleteUserDialog").on("click", function () { btnDeleteUserDialog() });    //弹出删除的弹层
        $("#btnDeleteUser").on("click", function () { btnDeleteUser() });                //删除实现方法

        $("#btnActivate").on("click", function () { btnActivate(); });                   //弹出激活用户浮层
        $("#btnActivateUser").on("click", function () { btnActivateUser(); });           //激活用户

        $("#btnDetail").on("click", function () { btnDetail(); });                       //详情
    };

    var initZtree = function () {
        plscommon.ajax({
            url: defaults.getZtree,
            type: "GET",
            success: function () {
                $.fn.zTree.init($("#tree_user_action"), setting, this.data);
            }
        });
    }

    function onCheck(e, treeId, treeNode) {
        var treeObj = $.fn.zTree.getZTreeObj("tree_user_action"),
        nodes = treeObj.getCheckedNodes(true), value = "";
        for (var i = 0; i < nodes.length; i++) {
            value += nodes[i].id + ",";
        }
        $("#action_id").val(value.substr(0, value.length - 1));
    };

    var btnQueryList = function () {
        plscommon.refreshTable("userinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    //邮箱和电话号码判断不能重复
    var checkUser_Email = function () {
        //异步请求判断是否符合条件
        var user_email = $.trim($("#user_email").val());
        if (!user_email) {
            return false;
        }
        var user_id = $("#user_id").val() == "" ? "0" : $("#user_id").val();
        if (user_email != "" || user_email != null) {
            plscommon.ajax_status({
                type: "GET",
                url: defaults.checkDataUrl,
                data: { user_id: user_id, content: user_email },
                success: function () {
                    if (this.data == true && this.status_code == 900) {
                        plscommon.errorMessage("邮箱已被注册，请您重新输入", 5000);
                        $("#user_email").val("");
                        return false;
                    }
                }
            });
        }
    }
    var checkUser_Phone = function () {
        //异步请求判断是否符合条件
        var user_phone = $.trim($("#user_phone").val());
        if (!user_phone) {
            return false;
        }
        var user_id = $("#user_id").val() == "" ? "0" : $("#user_id").val();
        if (user_phone != "" || user_phone != null) {
            plscommon.ajax_status({
                type: "GET",
                url: defaults.checkDataUrl,
                data: { user_id: user_id, content: user_phone },
                success: function () {
                    if (this.data == true && this.status_code == 900) {
                        plscommon.errorMessage("电话已被注册，请您重新输入", 5000);
                        $("#user_phone").val("");
                        return false;
                    }
                }
            });
        }
    }

    var btnAddUser = function () {
        $('#AddEditModal').modal();
        plscommon.resetFrom("userOperation");
        $("#HeadTitle").text("用户信息添加");

        $("#user_pwd").removeAttr("readonly");
        $('#departmnet_name').selectpicker('val', "");
        $("input[name='user_gender']").removeAttr("checked");
        opt.type = 1;
    }

    var btnEditUser = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaring('userinfo', 'AddEditModal', 'userOperation');
        if (!data.user_id) {
            return false;
        }
        $("#HeadTitle").text("用户信息修改");

        //调用请求并且进行将查询返回的值传入控件
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.user_id },
            success: function () {
                var data = this.data;
                $("#user_id").val(data.user_id);
                $("#user_name").val(data.user_name);
                $("#full_name").val(data.full_name);
                $("#user_email").val(data.user_email);
                $("#user_phone").val(data.user_phone);
                $("#user_pwd").val("密码不可在此更新");
                $("#user_pwd").attr("readonly", "readonly");
                $("input[type=radio][name='user_gender'][value='" + data.user_gender + "']").prop("checked", "checked");
                if (data.department_id != null) {
                    var arr = data.department_id.split(',');
                    $('#departmnet_name').selectpicker('val', arr);
                }
            }
        });
        opt.type = 2;
    }

    var btnAddData = function () {
        //读取form表单中的值并且进行验证
        var data = plscommon.deleteByValue($("#userOperation").serializeArray(), "user_id");
        data = plscommon.transitionArray(data);
        if (!checkData(data)) {
            return false;
        }

        $("#btnAddData").prop("disabled", true);
        data.department_id = $("#departmnet_name").val();
        data.user_pwd = $.md5(data.user_pwd);
        //对数据库进行操作
        if (opt.type === 1) {
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.addUrl,
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#userinfo").bootstrapTable('refresh');
                }
            });
        } else {
            data.user_id = $("#user_id").val();
            plscommon.ajax({
                disableId: "btnAddData",
                url: defaults.updateUrl,
                type: "PUT",
                data: data,
                success: function () {
                    $('#AddEditModal').modal('hide');
                    $("#user_name_" + data.user_id).html(data.user_name);
                    $("#full_name_" + data.user_id).html(data.full_name);
                    $("#user_email_" + data.user_id).html(data.user_email);
                    $("#user_phone_" + data.user_id).html(data.user_phone);
                    $("#user_gender_" + data.user_id).html(bankGender(data.user_gender));
                    $("#department_name_" + data.user_id).html($('button[data-id="departmnet_name"]').attr("title"));
                }
            });
        }
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('userinfo', 'disableOperation');
        if (!data.user_id) {
            return false;
        }
        var istrue = plscommon.dialogStatusLimit(data.user_id, "DisableEditModal", 1);

        opt.disable = 1;
        $("#id").val(data.user_id);
        $("#disableName").text(data.user_email);
    }

    var btnStart = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('userinfo', 'disableOperation');
        if (!data.user_id) {
            return false;
        }
        var istrue = plscommon.dialogStatusLimit(data.user_id, "DisableEditModal", 0);

        opt.disable = 0;
        $("#id").val(data.user_id);
        $("#disableName").text(data.user_email);
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
            data: { user_id: $("#id").val(), disable_desc: disable_desc, type: opt.disable },
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

    var btnSetRole = function () {
        var data = plscommon.dialogWaring('userinfo', 'SetRoleModal', 'user_role_Operation');
        if (!data.user_id) {
            return false;
        }
        $("#role_user_id").val(data.user_id);
        $("#Role_Head_Title").text(data.user_email);
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.user_id },
            success: function () {
                var role_id = $.trim(this.data.role_id);
                if (role_id != null) {
                    var arr = role_id.split(',');
                    opt.isUserRole = 1;
                    $('#role_name').selectpicker('val', arr);
                } else {
                    opt.isUserRole = 0;
                }
            }
        });
    }

    var btnSetRoleData = function () {
        var role_id = $("#role_name").val() == null ? "" : $("#role_name").val();
        if (opt.isUserRole == 0 && role_id == "") {
            $('#SetRoleModal').modal('hide');
            opt.isUserRole = 0;
            return false;
        }

        $("#btnSetRoleData").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnSetRoleData",
            url: defaults.updateSetRole,
            type: "POST",
            data: { user_id: $("#role_user_id").val(), role_ids: role_id },
            success: function () {
                $('#SetRoleModal').modal('hide');
                $("#role_name_" + $("#role_user_id").val()).html($('button[data-id="role_name"]').attr("title"));
                opt.isUserRole = 1;
            }
        });
    }

    var btnSetAction = function () {
        var data = plscommon.dialogWaring('userinfo', 'SetActionModal', 'user_action_Operation');
        if (!data.user_id) {
            return false;
        }
        $("#action_user_id").val(data.user_id);
        $("#Action_Head_Title").text(data.user_email);

        //配置ZTree
        var treeObj = $.fn.zTree.getZTreeObj("tree_user_action");
        treeObj.checkAllNodes(false);
        treeObj.expandAll(false);

        plscommon.ajax({
            url: defaults.getZtreeById,
            type: "GET",
            data: { user_id: data.user_id },
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
            url: defaults.addUserAction,
            type: "POST",
            data: { user_id: $("#action_user_id").val(), action_id: $("#action_id").val() },
            success: function () {
                $('#SetActionModal').modal('hide');
                opt.isUserAction = 1;
            }
        });
    }

    var btnDeleteUserDialog = function () {
        var data = plscommon.dialogWaring('userinfo', 'DeleteEditModal', 'user_Delete');
        if (!data.user_id) {
            return false;
        }
        $("#delete_user_id").val(data.user_id);
        $("#Delete_Head_Title").text(data.user_email);
        $("#Delete_Head_Title_OK").text(data.user_email);
    }

    var btnDeleteUser = function () {
        if ($("#delete_user_id").val() == "") {
            plscommon.warningMessage("请您选择需要删除的数据", 4000);
            return false;
        }

        $("#btnDeleteUser").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnDeleteUser",
            url: defaults.deleteUser,
            type: "POST",
            data: { user_id: $("#delete_user_id").val() },
            success: function () {
                $('#DeleteEditModal').modal('hide');
                $("#userinfo").bootstrapTable('refresh');
            }
        });
    }

    var btnActivate = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('userinfo', 'user_Activate');
        if (!data.user_id) {
            return false;
        }
        var istrue = plscommon.dialogStatusLimit("activation_" + data.user_id, "ActivateEditModal", 0, 1);


        $("#activate_user_id").val(data.user_id);
        $("#Activate_Head_Title").text(data.user_email);
        $("#Activate_Head_Title_OK").text(data.user_email);
    }

    var btnActivateUser = function () {
        if ($("#activate_user_id").val() == "") {
            plscommon.warningMessage("请您选择需要激活的数据", 4000);
            return false;
        }
        $("#btnActivateUser").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnActivateUser",
            url: defaults.activateUrl,
            type: "PUT",
            data: { user_id: $("#activate_user_id").val() },
            success: function () {
                $('#ActivateEditModal').modal('hide');
                $("#disable_status_activation_" + $("#activate_user_id").val()).attr("diable_status", 0);
                $("#disable_status_activation_" + $("#activate_user_id").val()).html(plscommon.extend.status_ok());
            }
        });
    }

    var btnDetail = function () {
        var data = plscommon.dialogWaring('userinfo', 'DetailModal', 'userDetail');
        if (!data.user_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { id: data.user_id },
            success: function () {
                var data = this.data;
                $("#detail_user_id").val(data.user_id);
                $("#detail_user_name").val(data.user_name);
                $("#detail_user_code").val(data.user_code);
                $("#detail_user_gender").val(data.user_gender == 1 ? "男" : "女");
                $("#detail_user_email").val(data.user_email);
                $("#detail_user_phone").val(data.user_phone);
                $("#detail_source_type").val(data.source_type == 1 ? "前端" : "后端");
                $("#detail_user_ip").val(data.user_ip);
                $("#detail_user_createtime").val(data.createtime);
                $("#detail_last_time").val(data.last_time);
                $("#detail_user_activation").val(data.user_activation == 0 ? "已激活" : "未激活");
                $("#detail_user_visit").val(data.user_visit == 0 ? "已入驻" : "未入驻");
                $("#detail_user_disable").val(data.disable == 0 ? "未禁用" : "已禁用");
                $("#detail_user_disabledesc").val(data.disabledesc);
                $("#detail_user_department").val(data.department_name);
                $("#detail_user_role").val(data.role_name);
            }
        });
    }

    var checkData = function (data) {
        if (!data.user_name || !data.user_email || !data.user_phone || !data.user_pwd || !data.user_gender) {
            plscommon.warningMessage("用户名、邮箱、电话、密码、性别字段不能为空，请您检查", 4000);
            return false;
        }
        if (data.user_name.length > 20) {
            plscommon.warningMessage("用户名只能输入1-20位", 4000);
            return false;
        }
        if (!plscommon.extend.email().test(data.user_email)) {
            plscommon.warningMessage("邮箱格式不正确，请您输入正确的邮箱格式", 4000);
            return false;
        }
        if (!plscommon.extend.phone().test(data.user_phone)) {
            plscommon.warningMessage("电话格式不正确，请您输入正确的邮箱格式", 4000);
            return false;
        }
        if (data.user_pwd.length < 6 || data.user_pwd.length > 20) {
            plscommon.warningMessage("密码只能输入6-20位", 4000);
            return false;
        }
        return true;
    }

    var bankGender = function (value) {
        var gender = "男";
        if (value == 0) {
            gender = "保密";
        } else if (value == 2) {
            gender = "女";
        }
        return gender;
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