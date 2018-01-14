/* 功能:  前台登录页面的的实现
 * 创建人：Kencery  创建时间：2016-11-12
 */
var pls = window.pls || {};
pls.front = pls.front || {};

pls.front.login = (function () {

    var opt = {};
    var defaults = {
        return_url: '/',
        type_show: 0,
        loginUrl: "/Login/Login",
        addUrl: "/Login/Add",
        updateUserNameUrl: "/Login/UpdateUserName",
        checkDataUrl: "/Admin/Login/checkData",
    };

    var initclickRefresh = function () {
        if (defaults.type_show == 1) {
            RegisterInitClass();
        } else {
            loginInitClass();
        }

        initbootStrapValidator();                                                   //初始化加载bootstrapvalidator事件
        $("#checkRemember").on("change", function () { checkRemember() });          //单击选中记住我
        $("#btnLoginSkip").on("click", function () { btnLoginSkip(); });            //登录跳转模态框
        $("#btnRegisterSkip").on("click", function () { btnRegisterSkip(); });      //注册跳转模态框

        $("#choiseItem li").on("click", function () { choiseItem($(this)); });      //选择用户名并且填充用户名信息
        $("#btnAddUsernName").on("click", function () { btnAddUsernName(); });      //修改用户名   
    };

    var initbootStrapValidator = function () {
        $('#login').bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                login_name_in: {
                    validators: {
                        notEmpty: {
                            message: '请输入邮箱/手机号'
                        },
                    }
                },
                user_pwd_in: {
                    validators: {
                        notEmpty: {
                            message: '请输入密码'
                        }
                    }
                }
            }
        }).on('success.form.bv', function (e) {
            // 阻止默认事件提交并且触发请求去后台验证
            e.preventDefault();
            var login_name_in = $("#login_name_in").val(), user_pwd_in = $("#user_pwd_in").val();
            $("#btnLogin").prop("disabled", true);
            plscommon.ajax_status({
                disableId: "btnLogin",
                url: defaults.loginUrl,
                data: { login_name_in: login_name_in, user_pwd_in: $.md5(user_pwd_in) },
                success: function () {
                    if (this.status_code == 200) {
                        if (defaults.return_url.indexOf("Login/Activation") > 0 || defaults.return_url == null || defaults.return_url == "" || defaults.return_url == undefined) {
                            window.location.href = "/Home/Index";
                        } else {
                            window.location.href = defaults.return_url;
                        }
                    } else {
                        alert("出错了，错误信息：" + this.status_message);
                        return false;
                    }
                }
            });
        });

        $('#regist').bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                user_email: {
                    validators: {
                        notEmpty: {
                            message: '请填写邮箱'
                        },
                        regexp: {
                            regexp: plscommon.extend.email(),
                            message: '邮箱地址格式有误'
                        },
                        remote: {
                            url: '/Admin/Login/checkEmail',
                            message: '该邮箱已经存在',
                            delay: 2000,
                            type: 'POST',
                        },
                    }
                },
                user_phone: {
                    validators: {
                        notEmpty: {
                            message: '请填写手机'
                        },
                        regexp: {
                            regexp: plscommon.extend.phone(),
                            message: '手机格式不正确'
                        },
                        threshold: 11,
                        remote: {
                            url: '/Admin/Login/checkMobie',
                            message: '手机号已被注册',
                            delay: 2000,
                            type: 'POST',
                        },
                    },
                },
                user_pwd: {
                    validators: {
                        notEmpty: {
                            message: '请输入登陆密码'
                        },
                        stringLength: {
                            min: 6,
                            max: 16,
                            message: '密码范围为6-16位'
                        }
                    }
                },
                user_pwd_ok: {
                    validators: {
                        notEmpty: {
                            message: '请输入确认密码'
                        },
                        identical: {
                            field: 'user_pwd',
                            message: '与登陆密码不一致'
                        },

                    }
                },
            }
        }).on('success.form.bv', function (e) {
            // 阻止默认事件提交并且触发请求去后台验证
            e.preventDefault();
            var data = plscommon.transitionArray($("#regist").serializeArray());
            data.user_pwd = $.md5(data.user_pwd);

            $("#btnRegister").prop("disabled", true);
            plscommon.ajax_status({
                disableId: "btnRegister",
                url: defaults.addUrl,
                data: data,
                success: function () {
                    if (this.status_code == 200) {
                        //注册成功之后读取邮箱和用户Id保存并且弹出设置用户名称的页面，设置用户名称
                        $("#usernamechoise").modal('show');
                        opt.user_id = this.data.name, opt.user_email = this.data.value;
                    } else {
                        alert("出错了，错误信息：" + this.status_message);
                        return false;
                    }
                }
            });
        });
    }

    var checkRemember = function () {
        if ($("#checkRemember").is(":checked")) {
            $(".warning").show();
        } else {
            $(".warning").hide();
        }
    }

    var btnLoginSkip = function () {
        loginInitClass();
    }

    var btnRegisterSkip = function () {
        RegisterInitClass();
    }

    var choiseItem = function (obj) {
        $("#user_name").val(obj.text());
    }

    var btnAddUsernName = function () {
        var user_name = $("#user_name").val(), user_id = opt.user_id, user_email = opt.user_email;
        if (!user_name || !user_id || !user_email) {
            alert("请填写您的用户名或者您的用户信息已被篡改，请联系管理员");
            return false;
        }

        $("#btnAddUsernName").prop("disabled", true);
        plscommon.ajax_status({
            disableId: "btnAddUsernName",
            url: defaults.updateUserNameUrl,
            data: { user_name: user_name, user_id: user_id, user_email: user_email },
            success: function () {
                if (this.status_code == 200) {
                    //添加成功之后跳转激活邮件页面
                    window.location.href = "/Login/RegisterOK";
                } else {
                    alert("添加用户失败了，请联系管理员");
                }
            }
        });
    }

    var loginInitClass = function () {
        $("#btnLoginSkip").tab('show');

        $("#btnLoginSkip").removeClass("regestSkip");
        $("#btnLoginSkip").addClass("loginSkip");
        $("#btnRegisterSkip").removeClass("loginSkip");
        $("#btnRegisterSkip").addClass("regestSkip");
    }

    var RegisterInitClass = function () {
        $("#btnRegisterSkip").tab('show');

        $("#btnRegisterSkip").removeClass("regestSkip");
        $("#btnRegisterSkip").addClass("loginSkip");
        $("#btnLoginSkip").removeClass("loginSkip");
        $("#btnLoginSkip").addClass("regestSkip");
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initclickRefresh();          //初始化页面并且触发事件
        }
    };
}());