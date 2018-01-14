/* 功能:  商品管理
 * 创建人：Kencery  创建时间：2016-11-15
*/
var pls = window.pls || {};
pls.admin = pls.admin || {};

pls.admin.shop = (function () {
    var defaults = {
        listUrl: "/Admin/Shop/List",
        getUrlById: "/Admin/Shop/GetById",
        uploadEditorImgUrl: "/Admin/Shop/UploadEditor",
        addUrl: "/Admin/Shop/AddShop",
        addshopSkuUrl: "/Admin/Shop/AddShopSku",
        deleteshopSkuUrl: "/Admin/Shop/DeleteShopSku",
        addshopAttrUrl: "/Admin/Shop/AddShopAttr",
        listSkuDronDownUrl: "/Admin/Shop/GetShopSkuById",
        uploadShopImageUrl: "/Admin/Shop/UploadShopImage",
        deleteshopImageUrl: "/Admin/Shop/DeleteShopImage",
        defaultshopImageUrl: "/Admin/Shop/DefaultShopImage",
        updateUrl: "/Admin/Shop/UpdateShop",
        getShopSkuUrl: "/Admin/Shop/GetShopSkuList",
        disableShopSkuUrl: "/Admin/Shop/DisableShopSku",
        updateShopSkuUrl: "/Admin/Shop/UpdateShopSku",
        getShopAttrUrl: "/Admin/Shop/GetShopAttr",
        updateshopAttrUrl: "/Admin/Shop/UpdateShopAttr",
        getShopImageUrl: "/Admin/Shop/GetShopImageById",
        disableUrl: "/Admin/Shop/Disable",
        getShopCouponByIdUrl: "/Admin/Shop/GetShopCouponById",
        addShopCouponUrl: "/Admin/Shop/AddShopCoupon",
        updateShopCouponUrl: "/Admin/Shop/UpdateShopCoupon",
        deleteShopCouponUrl: "/Admin/Shop/DeleteShopCoupon"
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
        title: '名称',
        field: 'shop_name',
        align: 'center',
        formatter: function (value, rows, index) {
            return '<div id="shop_name_' + rows.shop_id + '">' + value + '</div>';
        }
    }, {
        title: '编号',
        field: 'shop_number',
        formatter: function (value, rows, index) {
            return '<div id="shop_number_' + rows.shop_id + '">' + value + '</div>';
        }
    }, {
        title: '图片',
        field: 'shop_defaultimg',
        formatter: function (value, rows, index) {
            var image = '<img id="shop_defaultimg_' + rows.shop_id + '" width=60px height=40px src="' + value + '" />';
            return image;
        }
    }, {
        title: '简介',
        field: 'shop_memo',
        formatter: function (value, rows, index) {
            return '<div id="shop_memo_' + rows.shop_id + '">' + value + '</div>';
        }
    }, {
        title: '创建时间',
        field: 'createtime'
    }, {
        title: '优惠状态',
        align: 'center',
        field: 'shop_isdiscount',
        formatter: function (value, rows, index) {
            var is_privilege = value ? 0 : 1;
            return plscommon.extend.disable(is_privilege, "isdicount_" + rows.shop_id);
        }
    }, {
        title: '启用状态',
        field: 'disable',
        align: 'center',
        formatter: function (value, rows, index) {
            return plscommon.extend.disable(value, rows.shop_id);
        }
    }]

    var initTable = function () {
        plscommon.bootstraptable({
            id: "#shopinfo",
            url: defaults.listUrl,
            queryParams: queryParams,
            uniqueId: "shop_id",
            columns: columns
        });
    }

    var queryParams = function (params) {
        return {
            offset: params.offset,             //后台计算显示数据信息
            pagesize: params.limit,            //每页显示多少行
            shop_name: $("#shop_name_search").val(),
            shop_number: $("#shop_number_search").val(),
            shop_isdiscount: $("#shop_isdiscount_search").val(),
            disable: $("#distable_status").val()
        };
    };

    var initWangEditor = function () {
        $('#shopattr_isopensource').selectpicker();
        $('#shopcoupon_disable').selectpicker();
        opt.editorEdit = plscommon.initEditor("shop_desc", defaults.uploadEditorImgUrl);
        opt.editorDetail = plscommon.initEditor("detail_shop_desc", defaults.uploadEditorImgUrl);
    }

    var clickEvent = function () {
        $("#btnQueryList").on("click", function () { btnQueryList(); });                        //按条件查询结果
        $("#btnReset").on("click", function () { btnReset(); });                                //清空文本框信息

        //添加商品实体信息
        $("#btnAddShop").on("click", function () { btnAddShop(); });                            //商品添加弹层
        $("#btnAddShopData").on("click", function () { btnAddShopData(); });                    //对商品进行添加
        $("#btnAddShopSkuData").on("click", function () { btnAddShopSkuData(); });              //对商品SKU进行多个添加
        $("#btnAddShopSkuSkip_Last").on("click", function () { btnAddShopSkuSkip_Last(); });    //商品SKU设置完成之后单击下一步跳转
        $("#btnAddShopAttrData").on("click", function () { btnAddShopAttrData(); });            //商品属性添加
        $("#btnShopImageManage_Skip").on("click", function () { btnShopImageManage_Skip(); });  //单击商品图片选项卡信息
        $("#btnUploadShopImageImg").on("click", function () { btnUploadShopImageImg() });       //图片上传实现并且录入数据库的实现
        $("#btnAddShopImageSkip_Last").on("click", function () { btnAddShopImageSkip_Last() }); //图片上传完成之后下一步

        //编辑商品实体信息
        $("#btnEditShop").on("click", function () { btnEditShop(); });                          //编辑商品弹出弹层
        $("#btnShopSkuManage_Skip").on("click", function () { btnShopSkuManage_Skip(); });      //单击处理商品SKU信息
        $("#btnUpdateShopSkuData").on("click", function () { btnUpdateShopSkuData(); });        //修改商品SKU信息
        $("#btnShopAttrManage_Skip").on("click", function () { btnShopAttrManage_Skip(); });    //单击处理商品属性信息

        $("#btnSetFavorable").on("click", function () { btnSetFavorable(); });                  //设置取消版本优惠信息
        $("#btnAddUpdateShopCoupon").on("click", function () { btnAddUpdateShopCoupon(); });    //添加版本优惠信息
        $("#btnDeleteShopCoupon").on("click", function () { btnDeleteShopCoupon(); });          //删除版本优惠信息

        $("#btnStart").on("click", function () { btnStart(); });                                //启用弹出浮层
        $("#btnForbidden").on("click", function () { btnForbidden(); });                        //禁用弹出浮层
        $("#btnDisable").on("click", function () { btnDisable(); });                            //启用禁用方法

        $("#btnDetail").on("click", function () { btnDetail(); });                              //详情
    };

    var btnQueryList = function () {
        plscommon.refreshTable("shopinfo");
    }

    var btnReset = function () {
        plscommon.resetFrom("formSearch");
    }

    var btnAddShop = function () {
        $('#AddEditModal').modal();
        $("#HeadTitle").text("商品信息管理");

        //单击添加的时候首先注入选中的样式，隐藏后面的三个按钮，并且状态全部置为正常格式,清空所有的格式、将按钮置为可用、标示状态
        $("#btnShopSkuManage_Skip").hide();
        $("#btnShopAttrManage_Skip").hide();
        $("#btnShopImageManage_Skip").hide();

        initModelOne();
        initClearContent()

        $("#btnAddShopData").prop("disabled", false);
        opt.type = 1;
    }

    var btnEditShop = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaring('shopinfo', 'AddEditModal', 'shopOperation');
        if (!data.shop_id) {
            return false;
        }

        //弹层、重置model并且清空内容、填充读取到的内容、显示所有的tab、添加按钮置为可用、标识
        $('#AddEditModal').modal();
        $("#HeadTitle").text("商品（" + data.shop_name + "）信息配置");

        initModelOne();
        initClearContent();
        $("#shop_id").val(data.shop_id);

        //调用后台方法返回读取得到内容填充第一页
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { shop_id: data.shop_id },
            success: function () {
                var data = this.data;
                $("#shop_name").val(data.shop_name);
                $("#shop_memo").val(data.shop_memo);
                opt.editorEdit.clear();
                opt.editorEdit.$txt.html(data.shop_desc);
            }
        });

        $("#btnShopSkuManage_Skip").show();
        $("#btnShopAttrManage_Skip").show();
        $("#btnShopImageManage_Skip").show();

        $("#btnAddShopData").prop("disabled", false);

        opt.type = 2;
    }

    var btnAddShopData = function () {
        //读取form表单中的值并且进行验证,验证之后根据opt.type进行操作(1:添加，2:修改)
        var data = plscommon.deleteByValue($("#shopOperation").serializeArray(), "shop_id");
        data = plscommon.transitionArray(data);
        if (!checkShopData(data)) {
            return false;
        }
        $("#btnAddShopData").prop("disabled", true);
        if (opt.type === 1) {
            plscommon.ajax({
                disableId: "",
                url: defaults.addUrl,
                data: data,
                success: function () {
                    //成功之后提示用户并且显示其它模块,清空添加模块的内容并且刷新table
                    plscommon.resetFrom("shopOperation");
                    opt.editorEdit.clear();

                    $("#btnShopSkuManage_Skip").show();
                    $("#btnShopAttrManage_Skip").show();
                    $("#btnShopImageManage_Skip").show();
                    $("#shop_id").val(this.data);
                    $("#HeadTitle").text("商品（" + data.shop_name + "）信息管理");

                    $("#btnShopManage_Skip").parent().removeClass("active");
                    $("#btnShopSkuManage_Skip").parent().addClass("active");
                    $("#shop_manage").removeClass("tab-pane fade in active").addClass("tab-pane fade");
                    $("#shopsku_manage").removeClass("tab-pane fade").addClass("tab-pane fade  in active");

                    plscommon.refreshTable("shopinfo");

                    $("#btnUpdateShopSkuData").hide();
                }
            });
        } else {
            data.shop_id = $("#shop_id").val();
            plscommon.ajax({
                disableId: "btnAddShopData",
                url: defaults.updateUrl,
                type: "PUT",
                data: data,
                success: function () {
                    $("#shop_name_" + data.shop_id).html(data.shop_name);
                    $("#shop_memo_" + data.shop_id).html(data.shop_memo);
                    alert("修改完成");
                }
            });
            $("#btnUpdateShopSkuData").show();
        }
    }

    var btnAddShopSkuData = function () {
        //读取form表单中的值并且进行验证,验证之后根据opt.type进行操作(1:添加，2:修改)
        var data = plscommon.deleteByValue($("#shopskuOperation").serializeArray(), "shop_id");
        data = plscommon.transitionArray(data);
        data.shop_id = $("#shop_id").val();
        if (!checkShopSkuData(data)) {
            return false;
        }

        $("#btnAddShopSkuData").prop("disabled", true);
        plscommon.ajax({
            disableId: "btnAddShopSkuData",
            url: defaults.addshopSkuUrl,
            data: data,
            success: function () {
                //添加成功之后则直接添加到table中并且清空下面内容，同步给table中添加的内容赋予事件
                plscommon.resetFrom("shopskuOperation");
                var tbody_tr = "<tr><td>" + data.shop_code + "</td><td>" + data.shopsku_originalprice + "</td><td>"
                    + data.shopsku_currentprice + "</td><td>" + data.shopsku_url + "</td><td>" + data.shopsku_code +
                    "</td><td>" + plscommon.extend.disable(0, "add") + "</td><td><a href='javascript:void(0)' class='btnDeleteShopSku' type_id='" + this.data + "'>删除</a></td></tr>";
                $("#shopsku_manage table tbody").append(tbody_tr);

                $(".btnDeleteShopSku").unbind('click').on('click', function () { btnDeleteShopSku($(this)); });       //商品SKU添加完成之后删除事件
            }
        });
    }

    var btnDeleteShopSku = function (obj) {
        plscommon.ajax({
            url: defaults.deleteshopSkuUrl,
            type: "DELETE",
            data: { shop_id: $("#shop_id").val(), shosku_id: obj.attr("type_id") },
            success: function () {
                //执行成功之后删除table行即可
                obj.parents('tr').remove();
            }
        });
    }

    var btnShopSkuManage_Skip = function () {
        //清空内容并且查询列表显示
        $("#shopsku_manage table tbody").html("");
        plscommon.resetFrom("shopskuOperation");
        if (opt.type == 2) {
            $("#btnUpdateShopSkuData").show();
            plscommon.ajax({
                url: defaults.getShopSkuUrl,
                type: "GET",
                data: { shop_id: $("#shop_id").val() },
                success: function () {
                    var data = this.data;
                    var tbody_tr = "";
                    $.each(data, function (i, item) {
                        var disable_buttion = item.disable == 0 ? "禁用" : "启用";
                        var disable_status = item.disable == 0 ? 1 : 0;
                        tbody_tr += "<tr><td >" + item.shop_code + "</td><td>" + item.shopsku_originalprice + "</td><td>"
                        + item.shopsku_currentprice + "</td><td>" + item.shopsku_url + "</td><td>" + item.shopsku_code + "</td><td>" + plscommon.extend.disable(item.disable, "update_" + item.shopsku_id)
                        + "</td><td><a href='javascript:void(0)' class='btnDisableShopSku' disablesku_id=" + item.shopsku_id + " disable_status=" + disable_status + ">" + disable_buttion + "</a>&nbsp;&nbsp;<a href='javascript:void(0)' class='btnUpdateShopSku' updatesku_id=" + item.shopsku_id + ">修改</a></td></tr>";
                    });
                    $("#shopsku_manage table tbody").append(tbody_tr);

                    $(".btnDisableShopSku").unbind('click').on('click', function () { btnDisableShopSku($(this)); });       //商品SKU添加完成之后禁用
                    $(".btnUpdateShopSku").unbind('click').on('click', function () { btnUpdateShopSku($(this)); });
                }
            });
        } else {
            $("#btnUpdateShopSkuData").hide();
        }
    }

    var btnDisableShopSku = function (obj) {
        //根据商品SKU_Id禁用其状态
        var shopsku_id = obj.attr("disablesku_id");
        var disable_status = obj.attr("disable_status");

        plscommon.ajax({
            url: defaults.disableShopSkuUrl,
            type: "PUT",
            data: { shopsku_id: shopsku_id, disable_status: disable_status },
            success: function () {
                //更新成功之后变化按钮文字，修改disable_status,修改显示的文字
                if (disable_status == 0) {  //启用
                    obj.text("禁用");
                    obj.attr("disable_status", 1);
                } else {
                    obj.text("启用");
                    obj.attr("disable_status", 0);
                }
                obj.parents("tr").find("td").eq(5).html(plscommon.extend.disable(disable_status, "disablesku_" + shopsku_id));
            }
        });
    }

    var btnUpdateShopSku = function (obj) {
        var shopsku_id = obj.attr("updatesku_id");
        opt.shopskuupdate_id = shopsku_id;
        opt.shopskuupdateobj = obj;

        //清除原始的所有的选择、并且选中当前单击行
        obj.parents("tbody").find("tr").removeClass('danger');
        obj.parents("tr").addClass('danger')

        //读取表格中的内容输入到下面的文本框中
        var html = obj.parents("tr").find("td");
        $("#shop_code").val(html.eq(0).text());
        $("#shopsku_originalprice").val(html.eq(1).text());
        $("#shopsku_currentprice").val(html.eq(2).text());
        $("#shopsku_url").val(html.eq(3).text());
        $("#shopsku_code").val(html.eq(4).text());
    }

    var btnUpdateShopSkuData = function () {
        //组装条件修改
        var data = plscommon.deleteByValue($("#shopskuOperation").serializeArray(), "shop_id");
        data = plscommon.transitionArray(data);
        data.shop_id = 1;
        data.shopsku_id = opt.shopskuupdate_id;

        if (!data.shopsku_id) {
            plscommon.warningMessage("请您操作您要修改的数据", 4000);
            return false;
        }
        if (!checkShopSkuData(data)) {
            return false;
        }

        plscommon.ajax({
            disableId: "",
            url: defaults.updateShopSkuUrl,
            type: "PUT",
            data: data,
            success: function () {
                //更新table、清空定义的变量、清空文本框
                var html = opt.shopskuupdateobj.parents("tr").find("td");
                html.eq(0).text(data.shop_code);
                html.eq(1).text(data.shopsku_originalprice);
                html.eq(2).text(data.shopsku_currentprice);
                html.eq(3).text(data.shopsku_url);
                html.eq(4).text(data.shopsku_code);

                //清空某些定义的变量
                opt.shopskuupdate_id = "";
                opt.shopskuupdateobj = "";

                plscommon.resetFrom("shopskuOperation");
                alert("修改成功");
            }
        });
    }

    var btnAddShopSkuSkip_Last = function () {
        $("#btnShopSkuManage_Skip").parent().removeClass("active");
        $("#btnShopAttrManage_Skip").parent().addClass("active");
        $("#shopsku_manage").removeClass("tab-pane fade in active").addClass("tab-pane fade");
        $("#shopattr_manage_active").removeClass("tab-pane fade").addClass("tab-pane fade  in active");

        initShopAttrInfo();
    }

    var btnShopAttrManage_Skip = function () {
        //调用方法加载返回
        initShopAttrInfo();
    }

    var initShopAttrInfo = function () {
        if (opt.type == 2) {
            plscommon.ajax_status({
                url: defaults.getShopAttrUrl,
                type: "GET",
                data: { shop_id: $("#shop_id").val() },
                success: function () {
                    if (this.status_code == 200) {
                        var data = this.data;
                        $("#shopattr_author").val(data.shopattr_author);
                        $("#shopattr_language").val(data.shopattr_language);
                        $("#shopattr_condition").val(data.shopattr_condition);
                        $("#shopattr_database").val(data.shopattr_database);
                        $("#shopattr_framework").val(data.shopattr_framework);
                        $("#shopattr_manage").val(data.shopattr_manage);
                        $("#shopattr_size").val(data.shopattr_size);
                        $("#shopattr_utf").val(data.shopattr_utf);
                        $("#shopattr_weburl").val(data.shopattr_weburl);
                        $('#shopattr_isopensource').selectpicker('val', [data.shopattr_isopensource]);
                        $("#shopattr_opensource").val(data.shopattr_opensource);
                        $("#shopattr_blogaddress").val(data.shopattr_blogaddress);
                        $("#shopattr_memo").val(data.shopattr_memo);
                        opt.shopattr_id = data.shopattr_id;
                    }
                }
            });
        }
    }

    var btnAddShopAttrData = function () {
        //读取form表单中的值并且进行验证,验证之后根据opt.type进行操作(1:添加，2:修改)
        var data = plscommon.deleteByValue($("#shopattrOperation").serializeArray(), "shop_id");
        data = plscommon.transitionArray(data);
        data.shop_id = $("#shop_id").val();
        data.shopattr_isopensource = $("#shopattr_isopensource").val();
        if (!checkShopAttrData(data)) {
            return false;
        }

        if (opt.type === 1) {
            $("#btnAddShopSkuData").prop("disabled", true);
            plscommon.ajax({
                disableId: "btnAddShopSkuData",
                url: defaults.addshopAttrUrl,
                data: data,
                success: function () {
                    //添加成功之后提示信息并且清空文本框内容之后跳转到下一个页面
                    plscommon.resetFrom("shopattrOperation");

                    $("#btnShopAttrManage_Skip").parent().removeClass("active");
                    $("#btnShopImageManage_Skip").parent().addClass("active");
                    $("#shopattr_manage_active").removeClass("tab-pane fade in active").addClass("tab-pane fade");
                    $("#shopimage_manage").removeClass("tab-pane fade").addClass("tab-pane fade  in active");

                    //加载图片选择页面的SKU信息
                    initSkuDropDownList();
                }
            });
        } else {
            data.shopattr_id = opt.shopattr_id;
            plscommon.ajax({
                disableId: "",
                url: defaults.updateshopAttrUrl,
                data: data,
                type: "PUT",
                success: function () {
                    //修改成功之后提示修改完成
                    alert("修改完成");
                }
            });
        }
    }

    var btnShopImageManage_Skip = function () {
        //加载图片选择页面的SKU信息
        initSkuDropDownList();
        $("#shopimage_manage table tbody").html("");
        if (opt.type == 2) {
            plscommon.ajax({
                url: defaults.getShopImageUrl,
                type: "GET",
                data: { shop_id: $("#shop_id").val() },
                success: function () {
                    var data = this.data;
                    var tbody_tr = "";
                    $.each(data, function (i, item) {
                        tbody_tr += "<tr><td>" + item.shopsku_name + "</td><td><img style='width: 40px;height: 30px;' src=" + item.shopimage_address + " alt='" + item.shopsku_name + "' /></td>"
                           + "<td class='default_image_no' id='default_" + item.shopimage_id + "'>"
                           + (item.shopimage_default ? plscommon.extend.disable(0, "init_image" + item.shopimage_id) : plscommon.extend.disable(1, "init_image" + item.shopimage_id)) + "</td>"
                           + "<td><a href='javascript:void(0)' class='btnDeleteShopImage' image_id='" + item.shopimage_id + "'>删除</a>&nbsp;&nbsp<a href='javascript:void(0)' class='btnSetShopDefault' default_id='" + item.shopimage_id + "'>默认</a></td></tr>";
                    });
                    $("#shopimage_manage table tbody").append(tbody_tr);
                    $(".btnDeleteShopImage").unbind('click').on('click', function () { btnDeleteShopImage($(this)); });       //商品图片添加完成之后删除事件
                    $(".btnSetShopDefault").unbind('click').on('click', function () { btnSetShopDefault($(this)); });       //商品图片添加完成之后删除事件
                }
            });
        }
    }

    var btnUploadShopImageImg = function () {
        var shopsku_id = $("#shopsku_id").val();
        if (!shopsku_id) {
            plscommon.warningMessage("请您选择商品SKU进行设置图片", 4000);
            return false;
        }
        var files = $("#shopimage_address").get(0).files;
        if (files.length <= 0) {
            plscommon.warningMessage("请您选择您需要上传的图片", 4000);
            return false;
        }
        var file_name = files[0].name, file_size = files[0].size;
        if (!plscommon.extend.image().test(file_name.toLocaleLowerCase())) {
            plscommon.warningMessage("图片类型必须是.gif,jpeg,jpg,png中的一种", 4000);
            return false;
        }
        if (file_size / 1024 > 1024) {
            plscommon.warningMessage("图片大小限制只能上传1M一下，请您处理图片", 4000);
            return false;
        }
        //调用请求并且发送到后台进行查询返回,读取选择的商品SKuId和商品Id，同步添加数据库并且返回商品SKuid和商品图片路径
        var data = new FormData();
        data.append(file_name, files[0]);
        plscommon.ajax_image({
            disableId: "",
            url: defaults.uploadShopImageUrl + "?shop_id=" + $("#shop_id").val() + "&shopsku_id=" + $("#shopsku_id").val(),
            data: data,
            success: function () {
                $("#image_show").html("");
                if (this.status_code === 200) {
                    var image_url = "<img width=120px height=80px src='" + this.data.value + "' imagUrul='" + this.data.value + "' />";
                    $("#image_show").append(image_url);

                    //写入table
                    var shopsku_name = $('button[data-id="shopsku_id"]').attr("title");
                    var tbody_tr = "<tr><td>" + shopsku_name + "</td><td><img style='width: 40px;height: 30px;' src=" + this.data.value + " alt='" + shopsku_name + "' /></td>"
                        + "<td class='default_image_no' id='default_" + this.data.name.split(',')[1] + "'>" + plscommon.extend.disable(1, "upload_image") + "</td>"
                        + "<td><a href='javascript:void(0)' class='btnDeleteShopImage' image_id='" + this.data.name.split(',')[1] + "'>删除</a>&nbsp;&nbsp<a href='javascript:void(0)' class='btnSetShopDefault' default_id='" + this.data.name.split(',')[1] + "'>默认</a></td></tr>";
                    $("#shopimage_manage table tbody").append(tbody_tr);

                    $(".btnDeleteShopImage").unbind('click').on('click', function () { btnDeleteShopImage($(this)); });       //商品图片添加完成之后删除事件
                    $(".btnSetShopDefault").unbind('click').on('click', function () { btnSetShopDefault($(this)); });       //商品图片添加完成之后删除事件

                    //清空上传的内容
                    clearShopImage();

                } else {
                    $("#image_show").append("<span style='color:red'>" + this.status_message + "</span>");
                }
            }
        });
    }

    var btnDeleteShopImage = function (obj) {
        plscommon.ajax({
            url: defaults.deleteshopImageUrl,
            type: "PUT",
            data: { shop_id: $("#shop_id").val(), shopimage_id: obj.attr("image_id") },
            success: function () {
                obj.parents('tr').remove(); //执行成功之后删除table行即可
            }
        });
    }

    var btnSetShopDefault = function (obj) {
        plscommon.ajax({
            url: defaults.defaultshopImageUrl,
            type: "PUT",
            data: { shop_id: $("#shop_id").val(), shopimage_id: obj.attr("default_id") },
            success: function () {
                var data = this.data;
                //执行成功之后修改是否状态(首先将所有的文字置为否，然后将某一个固定的设置为是)

                $(".default_image_no").html(plscommon.extend.disable(1, "disable_image_init"));
                $("#default_" + data.name).html(plscommon.extend.disable(0, "disable_image_no"));
                //更新底图
                $("#shop_defaultimg_" + $("#shop_id").val()).attr("src", data.value);
            }
        });
    }

    var btnSetFavorable = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaring('shopinfo', 'FavorableModal', 'FavorableOperation');
        if (!data.shop_id) {
            return false;
        }

        //弹层，查询数据库，如果含有数据则写入，否则直接为空(添加、修改、删除按钮)
        $('#FavorableModal').modal();
        $("#Head_Favorable_Title").text("商品（" + data.shop_name + "）优惠设置");
        $("#shop_favorable_id").val(data.shop_id);
        $('#endtime').datetimepicker({
            minView: "month",                       //选择日期后，不会再跳转去选择时分秒 
            format: 'yyyy-mm-dd',                   //格式化
            language: "zh-CN",                      //汉化
            todayBtn: true,                         //是否显示今天
            autoclose: true,                         //选择日期后自动关闭
            startDate: new Date()
        }).on('changeDate', function (ev) { changeDate(ev) });         //改变时间

        //调用后台方法返回读取得到内容填充第一页
        plscommon.ajax_status({
            url: defaults.getShopCouponByIdUrl,
            type: "GET",
            data: { shop_id: data.shop_id },
            success: function () {
                if (this.status_code === 200) {
                    var data = this.data;
                    opt.shopcoupon = 0
                    $("#shopcoupon_id").val(data.shopcoupon_id);
                    $("#shopcoupon_type").val(data.shopcoupon_type);
                    $("#shopcoupon_name").val(data.shopcoupon_name);
                    $("#shopcoupon_money").val(data.shopcoupon_money);
                    $("#endtime").val(data.endtime);
                    $('#shopcoupon_disable').selectpicker('val', [data.disable]);

                    //动态改变列表的展示
                    if (data.disable == 1) {
                        $("#disable_status_isdicount_" + data.shop_id).html(plscommon.extend.status_remove());
                    }
                } else {
                    opt.shopcoupon = 1
                }
            }
        });
    }

    var btnAddUpdateShopCoupon = function () {  //添加
        var data = plscommon.deleteByValue($("#FavorableOperation").serializeArray(), "shopcoupon_id");
        data = plscommon.transitionArray(data);
        data.shop_id = $("#shop_favorable_id").val();
        if (!checkCouponShopData(data)) {
            return false;
        }

        $("#btnAddUpdateShopCoupon").prop("disabled", true);
        if (opt.shopcoupon === 1) {
            plscommon.ajax({
                disableId: "btnAddUpdateShopCoupon",
                url: defaults.addShopCouponUrl,
                data: data,
                success: function () {
                    //添加完成之后提示用户并且响应下面的内容变为对号
                    $('#FavorableModal').modal('hide');
                    $("#disable_status_isdicount_" + $("#shop_favorable_id").val()).html(plscommon.extend.status_ok());
                }
            });
        } else {
            data.shopcoupon_id = $("#shopcoupon_id").val();
            data.disable = data.shopcoupon_disable;
            plscommon.ajax({
                disableId: "btnAddUpdateShopCoupon",
                url: defaults.updateShopCouponUrl,
                type: "PUT",
                data: data,
                success: function () {
                    alert("修改完成");
                    if (data.disable == 1) {
                        $("#disable_status_isdicount_" + $("#shop_favorable_id").val()).html(plscommon.extend.status_remove());
                    } else {
                        $("#disable_status_isdicount_" + $("#shop_favorable_id").val()).html(plscommon.extend.status_ok());
                    }
                }
            });
        }
    }

    var btnDeleteShopCoupon = function () {
        var shopcoupon_id = $("#shopcoupon_id").val();
        plscommon.ajax({
            disableId: "btnAddUpdateShopCoupon",
            url: defaults.deleteShopCouponUrl,
            type: "DELETE",
            data: { shopcoupon_id: shopcoupon_id, shop_id: $("#shop_favorable_id").val() },
            success: function () {
                //添加完成之后提示用户并且响应下面的内容变为对号
                $('#FavorableModal').modal('hide');
                $("#disable_status_isdicount_" + $("#shop_favorable_id").val()).html(plscommon.extend.status_remove());
            }
        });
    }

    var changeDate = function (ev) {
        if (ev.date > new Date()) {
            $('#shopcoupon_disable').selectpicker('val', [0]);
        } else {
            $('#shopcoupon_disable').selectpicker('val', [1]);
        }
    }

    var btnForbidden = function () {
        //必须选中一条才能弹出
        var data = plscommon.dialogWaringDisable('shopinfo', 'disableOperation');
        if (!data.shop_id) {
            return false;
        }
        var istrue = plscommon.dialogStatusLimit(data.shop_id, "DisableEditModal", 1);

        opt.disable = 1;
        $("#id").val(data.shop_id);
        $("#disableName").text(data.shop_name);
    }

    var btnStart = function () {
        //必须选中一条才能弹出,判断是否有权限操作
        var data = plscommon.dialogWaringDisable('shopinfo', 'disableOperation');
        if (!data.shop_id) {
            return false;
        }
        var istrue = plscommon.dialogStatusLimit(data.shop_id, "DisableEditModal", 0);

        opt.disable = 0;
        $("#id").val(data.shop_id);
        $("#disableName").text(data.shop_name);
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
            data: { shop_id: $("#id").val(), disable_desc: disable_desc, type: opt.disable },
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
        var data = plscommon.dialogWaring('shopinfo', 'DetailModal', 'shopDetail');
        if (!data.shop_id) {
            return false;
        }
        plscommon.ajax({
            url: defaults.getUrlById,
            type: "GET",
            data: { shop_id: data.shop_id },
            success: function () {
                var data = this.data;
                $("#detail_shop_name").val(data.shop_name);
                $("#detail_shop_memo").val(data.shop_memo);
                $("#detail_shop_number").val(data.shop_number);
                $("#detail_createtime").val(data.createtime);
                $("#detail_shop_isdiscount").val(data.shop_isdiscount ? "优惠" : "未优惠");
                $("#detail_diable").val(data.disable == 0 ? "未禁用" : "已禁用");
                $("#detail_disabledesc").val(data.disabledesc);

                //清空图片和编辑器并且给其重新赋值显示
                $("#detail_shop_defaultimg").empty();
                $("#detail_shop_defaultimg").append("<img width=180px height=100px src='" + data.shop_defaultimg + "' imagUrul='" + data.shop_defaultimg + "' />");
                opt.editorDetail.clear();
                opt.editorDetail.$txt.html(data.shop_desc);
                opt.editorDetail.disable();
            }
        });
    }

    //以下为封装的方法，提供给类使用
    var initSkuDropDownList = function () {
        plscommon.dropDownList("#shopsku_id", defaults.listSkuDronDownUrl + "?shop_id=" + $("#shop_id").val());
    }
    var clearShopImage = function () {
        var file = $("#shopimage_address");
        file.after(file.clone().val(""));
        file.remove();
    }
    var initModelOne = function () {
        $("#btnShopManage_Skip").parent().addClass("active");
        $("#btnShopSkuManage_Skip").parent().removeClass("active");
        $("#btnShopAttrManage_Skip").parent().removeClass("active");
        $("#btnShopImageManage_Skip").parent().removeClass("active");
        $("#shop_manage").removeClass("tab-pane fade").addClass("tab-pane fade  in active");
        $("#shopsku_manage").removeClass("tab-pane fade in active").addClass("tab-pane fade");
        $("#shopattr_manage_active").removeClass("tab-pane fade in active").addClass("tab-pane fade");
        $("#shopimage_manage").removeClass("tab-pane fade in active").addClass("tab-pane fade");
    }

    var initClearContent = function () {
        plscommon.resetFrom("shopOperation");
        opt.editorEdit.clear();

        plscommon.resetFrom("shopskuOperation");
        $("#shopsku_manage table tbody").html("");

        plscommon.resetFrom("shopattrOperation");

        plscommon.resetFrom("shopskuOperation");
        $("#shopimage_manage table tbody").html("");
        clearShopImage();
        $("#image_show").empty();
    }

    var checkShopData = function (data) {
        if (!data.shop_name || !data.shop_memo || !data.shop_desc || !data.shop_desc == "<p><br></p>") {
            plscommon.warningMessage("字段不能为空，请您检查", 4000);
            return false;
        }
        return true;
    }
    var checkShopSkuData = function (data) {
        if (!data.shop_id || !data.shop_code || !data.shopsku_currentprice || !data.shopsku_originalprice) {
            plscommon.warningMessage("字段不能为空，请您检查", 4000);
            return false;
        }
        if (!plscommon.extend.price().test(data.shopsku_originalprice)) {
            plscommon.warningMessage("请输入正确的原价", 4000);
            return false;
        }
        if (!plscommon.extend.price().test(data.shopsku_currentprice)) {
            plscommon.warningMessage("请输入正确的会员价,价格可为0，为0则直接免费", 4000);
            return false;
        }
        if (parseFloat(data.shopsku_currentprice) > parseFloat(data.shopsku_originalprice)) {
            plscommon.warningMessage("商品会员价不可以比商品的原价还高，请您检查修改", 4000);
            return false;
        }
        return true;
    }
    var checkShopAttrData = function (data) {
        if (!data.shopattr_author) {
            plscommon.warningMessage("字段不能为空，请您检查", 4000);
            return false;
        }
        return true;
    }
    var checkCouponShopData = function (data) {
        if (!data.shop_id || !data.shopcoupon_type || !data.shopcoupon_name || !data.shopcoupon_money || !data.shopcoupon_disable || !data.endtime) {
            plscommon.warningMessage("字段不能为空，请您检查", 4000);
            return false;
        }
        if (!plscommon.extend.price().test(data.shopcoupon_money) || data.shopcoupon_money <= 0) {
            plscommon.warningMessage("请输入正确的优惠额度并且优惠额度不能为0以下", 4000);
            return false;
        }
        return true;
    }

    return {
        init: function (options) {
            $.extend(defaults, options || {});
            initTable();            //初始化Table表格
            clickEvent();           //触发事件
            initWangEditor();       //初始化富文本编辑器
        }
    };
}());