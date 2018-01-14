/*
    Kencery   公共类   2016-9-12  
    修改1  2016-9-12  Kencery   添加Ajax、添加浏览器Cookie
*/
var plscommon = function () { };
plscommon = {
    //封装Ajax请求，所有的AJAX请求必须调用此接口实现
    ajax: function (options) {
        var defaults = {
            async: true,
            cache: true,
            type: 'POST',
            data: '',
            disableId: "hiddentId"
        };
        defaults = $.extend(defaults, options);
        jQuery.ajax({
            url: defaults.url,
            type: defaults.type,
            cache: defaults.cache,
            async: defaults.async,
            data: defaults.data,
            dataType: "JSON",
            onwait: "数据正在加载中，请您稍候...",
            success: function (result) {
                $("#" + defaults.disableId).prop("disabled", false);
                if (result.status_code === 200) {
                    if (defaults.success) {
                        defaults.success.call(result);
                    }
                    return result;
                } else {
                    plscommon.errorMessage(result.status_message, 5000);
                    return false;
                }
            },
            error: function (result) {
                $("#" + defaults.disableId).prop("disabled", false);
                if (defaults.error) {
                    defaults.error.call(result);
                }
                return result;
            }
        });
    },

    //封装Ajax请求，在封装中不判断返回的格式
    ajax_status: function (options) {
        var defaults = {
            async: true,
            cache: true,
            type: 'POST',
            data: '',
            disableId: "hiddentId"
        };

        defaults = $.extend(defaults, options);

        jQuery.ajax({
            url: defaults.url,
            type: defaults.type,
            cache: defaults.cache,
            async: defaults.async,
            data: defaults.data,
            dataType: "JSON",
            onwait: "数据正在加载中，请您稍候...",
            success: function (result) {
                $("#" + defaults.disableId).prop("disabled", false);
                if (defaults.success) {
                    defaults.success.call(result);
                }
                return result;
            },
            error: function (result) {
                $("#" + defaults.disableId).prop("disabled", false);
                if (defaults.error) {
                    defaults.error.call(result);
                }
                return result;
            }
        });
    },

    //对图片封装Ajax请求，在封装中不判断返回的格式
    ajax_image: function (options) {
        var defaults = {
            contentType: false,
            processData: false,
            type: 'POST',
            data: '',
            disableId: "hiddentId"
        };
        defaults = $.extend(defaults, options);
        jQuery.ajax({
            type: defaults.type,
            url: defaults.url,
            contentType: defaults.contentType,
            processData: defaults.processData,
            data: defaults.data,
            success: function (result) {
                $("#" + defaults.disableId).prop("disabled", false);
                if (defaults.success) {
                    defaults.success.call(result);
                }
                return result;
            },
            error: function (result) {
                $("#" + defaults.disableId).prop("disabled", false);
                if (defaults.error) {
                    defaults.error.call(result);
                }
                return result;
            }
        });
    },

    //BootStraps封装显示插件（id、url、queryParams、columns不能为空）
    bootstraptable: function (options) {
        var defaults = {
            id: "",
            method: "GET",
            url: "",
            toolbar: "toolbar",
            striped: true,
            cache: false,
            pagination: true,
            sortable: false,
            sortOrder: "asc",
            sidePagination: "server",
            pageNumber: 1,
            pageSize: 20,
            pageList: [10, 20, 50, 100],
            clickToSelect: true,
            height: 0,
            uniqueId: "id",
            cardView: false,
            showToggle: true,
            detailView: false,
            showHeader: true,
            showFooter: false,
            showColumns: true,
            showRefresh: true,
            showToggle: true,
            queryParams: {},
            ajaxOptions: {},
            columns: []
        };

        defaults = $.extend(defaults, options);
        $(defaults.id).bootstrapTable({
            method: defaults.method,                     //请求方式（*）
            url: defaults.url,                           //请求后台的URL（*）
            toolbar: '#' + defaults.toolbar,             //工具按钮用哪个容器
            striped: defaults.striped,                   //是否显示行间隔色
            cache: defaults.cache,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: defaults.pagination,             //是否显示分页（*）
            sortable: defaults.sortable,                 //是否启用排序
            sortOrder: defaults.sortOrder,               //排序方式
            sidePagination: defaults.sidePagination,     //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: defaults.pageNumber,             //初始化加载第一页，默认第一页
            pageSize: defaults.pageSize,                 //每页的记录行数（*）
            pageList: defaults.pageList,                 //可供选择的每页的行数（*）
            clickToSelect: defaults.clickToSelect,       //是否启用点击选中行
            height: defaults.height,                     //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: defaults.uniqueId,                 //每一行的唯一标识，一般为主键列
            cardView: defaults.cardView,                 //是否显示详细视图
            detailView: defaults.detailView,             //是否显示父子表
            showHeader: defaults.showHeader,             //是否显示列头
            showFooter: defaults.showFooter,             //是否显示列尾
            showColumns: defaults.showColumns,           //是否显示 内容列下拉框
            showRefresh: defaults.showRefresh,           //是否显示 刷新按钮
            showToggle: defaults.showToggle,             //是否显示 切换试图（table/card）按钮
            minimumCountColumns: 2,
            queryParams: defaults.queryParams,           //传递参数（*）
            ajaxOptions: defaults.ajaxOptions,
            columns: defaults.columns,
            onExpandRow: function (index, row, $detail) {
                if (defaults.onExpandRow) {
                    defaults.onExpandRow.apply({
                        index: index,
                        row: row,
                        detail: $detail
                    });
                }
            },
            onCheck: function (row) {
                if (defaults.onCheck) {
                    defaults.onCheck.call(row);
                }
                return row;
            }
        });

        $(defaults.id).bootstrapTable('hideColumn', defaults.uniqueId);
    },

    //Table加载行号
    tableNumber: function (value, row, index) {
        return index + 1;
    },

    //刷新Table列表
    refreshTable: function (departmentinfo) {
        $("#" + departmentinfo).bootstrapTable('refresh');
    },

    //友情提示信息
    warningMessage: function (txt, time) {
        plscommon.extend.errorMessage("友情提示：" + txt, "yellow", time);
    },

    //错误提示信息
    errorMessage: function (txt, time) {
        plscommon.extend.errorMessage("错误信息是：" + txt, "red", time, 'icon-question-sign');
    },

    //转换数据成为对象,form表单需要转换
    transitionArray: function (opt) {
        var v = {};
        for (var i in opt) {
            if (opt[i].name != "__VIEWSTATE") {
                if (typeof (v[opt[i].name]) == 'undefined')
                    v[opt[i].name] = opt[i].value;
                else
                    v[opt[i].name] += "," + opt[i].value;
            }
        }
        return v;
    },

    //Jquery根据属性删除不需要的元素字段
    deleteByValue: function (arr, deleteTxt) {
        var ret = $.grep(arr, function (value, i) {
            return value.name != deleteTxt;
        });
        return ret;
    },

    //弹出浮层的初始化动作(tableId:Table的Id、dialogId:浮层的Id、formId:表单的Id)
    dialogWaring: function (tableId, dialogId, formId) {
        var data = $("#" + tableId).bootstrapTable('getSelections')[0];
        if (!data) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        $('#' + dialogId).modal();
        plscommon.resetFrom(formId);
        return data;
    },

    //弹出启用禁用浮层的初始化动作(tableId:Table的Id、formId:表单的Id
    dialogWaringDisable: function (tableId, formId) {
        var data = $("#" + tableId).bootstrapTable('getSelections')[0];
        if (!data) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return data;
        }
        plscommon.resetFrom(formId);
        return data;
    },

    //弹出启用禁用浮层判断是否含有权限(discount_id:主键Id,disable 状态,dialog,Id:浮层Id,type:启用禁用标识)
    dialogStatusLimit: function (discount_id, dialogId, type, version) {
        if (!discount_id) {
            return false;
        }
        var status_code = $("#disable_status_" + discount_id).attr("diable_status");
        var context = type == 0 ? "状态已经是启用状态，不允许再启用！" : "状态已经是禁用状态，不允许再禁用！"
        if (version == 1) {
            context = "此用户信息已经被激活，不允许再次激活";
        }
        if (version == 2) {
            context = "此用户信息已经被开启访问，不允许再次开启访问";
        }
        if (status_code == type) {
            plscommon.warningMessage(context, 3000);
            return false;
        } else {
            $('#' + dialogId).modal();
        }
        return true;
    },

    //清空form表单的数据
    resetFrom: function (formSearch) {
        $("#" + formSearch)[0].reset();
    },

    //下拉列表框实例化内容
    dropDownList: function (dropdownId, url) {
        $(dropdownId).selectpicker({});
        url = $.trim(url);
        if (url) {
            var drop_html = "";
            plscommon.ajax({
                url: url,
                type: "GET",
                success: function () {
                    var data = this.data;
                    $(dropdownId).empty();
                    $.each(data, function (i, n) {
                        drop_html += "<option value='" + n.value + "'>" + n.name + "</option>";
                    });
                    $(dropdownId).append(drop_html);
                    //更新内容刷新到相应的位置
                    $(dropdownId).selectpicker('render');
                    $(dropdownId).selectpicker('refresh');
                }
            });
        }

    },

    //富文本编辑器设置
    initEditor: function (id, url) {
        // 阻止输出log
        wangEditor.config.printLog = false;
        var editor = new wangEditor(id);
        // 对其进行自定义菜单
        editor.config.menus = ['source', 'lineheight', 'indent', '|',
        'bold', 'underline', 'italic', 'strikethrough', 'eraser', 'forecolor', 'bgcolor', '|',
        'quote', 'fontfamily', 'fontsize', 'head', 'unorderlist', 'orderlist', '|',
        'alignleft', 'aligncenter', 'alignright', '|', 'link', 'unlink', 'table', 'emotion', '|',
        'img', 'location', 'insertcode', '|', 'undo', 'redo'];
        // 配置自定义表情
        editor.config.emotions = {
            'default': {
                title: '默认',
                data: ' http://www.wangeditor.com/wangEditor/test/emotions.data'
            }
        };
        // 为当前的editor配置密钥
        editor.config.mapAk = '2QTiEWDG3XYtEqNgbomE4mdY3b4uzwqZ';
        // 上传图片
        editor.config.uploadImgUrl = url;
        editor.create();
        return editor;
    },

    //checkbox多选取值
    getIdSelections: function (tableId, formId) {
        //获取checkbox的多选Id
        var data = $.map($("#" + tableId).bootstrapTable('getSelections'), function (row) {
            return row;
        });
        if (data.length <= 0) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        plscommon.resetFrom(formId);
        return data;
    },

    //弹出浮层的初始化动作(tableId:Table的Id、dialogId:浮层的Id、formId:表单的Id)
    dialogSelectsWaring: function (tableId, dialogId, formId) {
        var data = $.map($("#" + tableId).bootstrapTable('getSelections'), function (row) {
            return row;
        });
        if (data.length <= 0) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        }
        //$('#' + dialogId).modal();
        plscommon.resetFrom(formId);
        return data;
    },

    //弹出启用禁用浮层判断是否含有权限(discount_id:主键Id,disable 状态,dialog,Id:浮层Id,type:启用禁用标识)
    selectionStatusLimit: function (tableId, formId, dialogId, type, version) {
        var rowstatus = 0;
        var context = type == 0 ? "状态已经是启用状态，不允许再启用！" : "状态已经是禁用状态，不允许再禁用！"
        var data = $.map($("#" + tableId).bootstrapTable('getSelections'), function (row) {
            var status_code = $("#disable_status_" + row.message_id).attr("diable_status");
            if (status_code != type) {
                return row.message_id;
            } else {
                rowstatus++;
            }
        });
        if (data.length <= 0 && rowstatus == 0) {
            plscommon.warningMessage("请您选择需要修改的数据", 3000);
            return false;
        } else if ((rowstatus != 0 && data.length == 0) || data.length == 0) {
            plscommon.warningMessage(context, 3000);
            return false;
        }else {
            $('#' + dialogId).modal();
        }
        plscommon.resetFrom(formId);
        return data;
    },
};

//扩展方法：提供给上面的封装类使用
plscommon.extend = {
    //错误提示信息，暂时限制为5中颜色：red、green、blue、yellow、orange
    errorMessage: function (text, color, time, icon) {
        var icon_span = "", html_element, $cont = $('#error-message');
        color = color ? color : 'red';
        time = time ? time : 5000;
        icon_span = icon ? "<i class='icon-warning-sign'></i> " : "<span class='icon-warning-sign'></span> ";

        //创建HTML并且添加到给定的内容中
        html_element = $('<div class="error-message-calss error-message-' + color + '">' + icon_span + text + '</div>').fadeIn('fast');
        $cont.append(html_element);

        //单击或者过时间限制则隐藏
        html_element.on('click', function () {
            plscommon.extend.error_message_close($(this));
        });
        setTimeout(function () {
            plscommon.extend.error_message_close($cont.children('.error-message-calss').first());
        }, time);

    },
    error_message_close: function (elem) {
        if (typeof elem !== "undefined") {
            elem.fadeOut('fast', function () {
                $(this).remove();
            });
        } else {
            $('.alert').fadeOut('fast', function () {
                $(this).remove();
            });
        }
    },

    //jquery时间/金钱转换
    dateParse: function (date_time) {
        //时间规范
        var minute = 1000 * 60, hour = minute * 60, day = hour * 24, halfamonth = day * 15, month = day * 30;
        var begin_time = new Date();                                        //结束时间
        var millions = begin_time.getTime() - Date.parse(date_time);        //时间差的毫秒数
        var monthC = millions / month, weekC = millions / (7 * day), dayC = millions / day,
            hourC = millions / hour, minC = millions / minute;

        if (monthC >= 1) {
            result = parseInt(monthC) + "个月前";
        }
        else if (weekC >= 1) {
            result = parseInt(weekC) + "周前";
        }
        else if (dayC >= 1) {
            result = parseInt(dayC) + "天前";
        }
        else if (hourC >= 1) {
            result = parseInt(hourC) + "小时前";
        }
        else if (minC >= 1) {
            result = parseInt(minC) + "分钟前";
        } else {
            result = "刚刚";
        }
        return result;
    },
    dataNow: function (data) {
        var year = data.getFullYear();
        var month = data.getMonth() + 1;
        var date = data.getDate();
        var h = data.getHours();
        var m = data.getMinutes();
        var s = data.getSeconds();
        return year + "-" + month + "-" + date + "-" + h + "-" + m + "-" + s;

    },
    priceParse: function (input, type) {
        if (type == undefined || type == "" || type == null) {
            type = "¥";
        }
        input = input.toString().replace(/\$|\,/g, '');
        if (isNaN(input)) { input = "0"; }
        sign = (input == (input = Math.abs(input)));
        input = Math.floor(input * 100 + 0.50000000001);
        cents = input % 100;
        input = Math.floor(input / 100).toString();
        if (cents < 10)
            cents = "0" + cents;
        for (var i = 0; i < Math.floor((input.length - (1 + i)) / 3) ; i++)
            input = input.substring(0, input.length - (4 * i + 3)) + ',' +
            input.substring(input.length - (4 * i + 3));
        return (type + " " + ((sign) ? '' : '-') + input + '.' + cents);
    },

    //禁用启用状态修改封装
    disable: function (value, id) {
        var re = "";
        if (value == 0) {
            re = '<div id="disable_status_' + id + '" diable_status=' + value + '>' + plscommon.extend.status_ok() + '</div>';
        } else {
            re = '<div id="disable_status_' + id + '" diable_status=' + value + '>' + plscommon.extend.status_remove() + '</div>';
        }
        return re;
    },
    enumdisable: function (value, id) {
        var re = "";
        if (!value) {
            re = '<div id="enum_' + id + '">' + plscommon.extend.is_no("否") + '</div>'
        } else {
            re = '<div id="enum_' + id + '">' + plscommon.extend.is_yes("是") + '</div>'
        }
        return re;
    },

    //禁用启用状态HMTL
    status_ok: function () {
        return '<span style="color:#2bd82b"><i class="icon-ok"></i></span>';
    },
    status_remove: function () {
        return '<span style="color:red"><i class="icon-remove"></i></span>'
    },

    //订单发送状态HTML
    is_yes: function (txt) {
        if (txt == undefined || txt == "" || txt == null) {
            txt = "是";
        }
        return '<span style="color:#2bd82b">' + txt + '</span>';
    },
    is_no: function (txt) {
        if (txt == undefined || txt == "" || txt == null) {
            txt = "否";
        }
        return '<span style="color:red">' + txt + '</span>';
    },

    //正则表达式
    email: function () {           //邮箱
        return /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
    },
    phone: function () {          //电话
        return /^(((13[0-9]{1})|(14[0-9]{1})|(17[0-9]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;
    },
    plastic: function () {       //正整数
        return /^[0-9]*[1-9][0-9]*$/;
    },
    image: function () {        //图片      
        return /^.*.(?:png|jpg|bmp|gif|jpeg)$/;
    },
    price: function () {        //金钱
        return /(^[1-9]([0-9]+)?(\.[0-9]{1,2})?$)|(^(0){1}$)|(^[0-9]\.[0-9]([0-9])?$)/;
    },
};