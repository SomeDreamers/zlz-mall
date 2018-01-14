//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Utils/EmailKeyUtil 
//  创建人:                     kencery     
//  创建时间:                   2016/10/30 17:20:53
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Utils
{
    /// <summary>
    /// 邮箱发送模板统计(这里是所有邮箱发送的模板设置封装类)
    /// </summary>
    public static class EmailKeyUtil
    {
        /// <summary>
        /// 用户注册模块激活用户发送邮件的标题内容
        /// </summary>
        public static string send_user_activation_title = "用户：{0}激活信息";
        public static string send_user_activation_content = @"<head><meta charset='utf-8' /></head>
            <body style='font-size: 14px;color:#666666;background:#efefef;margin-top:20px;'>
                <div style='text-align: center;'><img src='http://www.chuxinm.com/img/logo/logo.png'></div>
                <div style='width:600px !important;margin:0 auto; border-radius:5px;'>
                    <div style=' font-size:18px;padding-left: 0px;margin-left: -40px;margin-bottom: 10px;'>尊敬的{0}用户，您好：</div>
                    <div>
                        <p>感谢您使用初心服务</p>
                        <p>请点击以下链接进行邮箱验证</p>
                        <p style='background: #1989fa;width:200px;border-radius:5px;line-height:35px;text-align: center;font-size: 14px;'><a href='{1}'>马上激活</a></p>
                        <p>如果您无法点击以上链接，请复制一下网址到浏览器直接打开:</p>
                        <p><a href='{2}'>{3}</a><p>
                        <p>如果您未申请初心服务账户，可能是其他用户误输入了您的邮箱地址。请忽略此邮件，或者<a href='http://www.chuxinm.com'>联系我们</a><p>
                    </div>
                </div>
            </body>";

        /// <summary>
        /// 订单模块发送邮件的标题内容
        /// </summary>
        public static string send_order_title = "用户{0}的购买信息";
        public static string send_order_content = @"<head><meta charset='utf-8' />
        </head>
        <body style='font-size: 14px;color:#666666;margin-top:20px;'>
            <div style='text-align: center;'><img src='http://www.chuxinm.com/img/logo/logo.png'></div>
            <div style='width:1000px !important;margin:0 auto; border-radius:5px;'>
                <div style='font-size:16;padding-left: 0px;margin-bottom: 10px;'>尊敬的用户{0}，您好：</div>
                <div>
                    <p>您购买的商品下载信息如下</p>            
                    <table border='1' cellspacing='0' cellpadding='0' style='border:1px solid #E9EAEC !important;border-collapse: collapse;box-shadow:5px 5px 5px #E9EAEC;'>
                        <thead>
                            <tr style = 'background:#F6F6F6'>
                            <th style= 'font-weight:normal !important;padding-top:5px;padding-bottom:5px;'> 商品名称 </th>
                            <th style= 'font-weight:normal !important;padding-top:5px;padding-bottom:5px;'> 版本 </th>
                            <th style= 'font-weight:normal !important;padding-top:5px;padding-bottom:5px;'> 下载链接 </th>
                            <th style= 'font-weight:normal !important;padding-top:5px;padding-bottom:5px;'> 下载码 </th>
                            </tr>
                        </thead>
                        <tbody>{1}</tbody>
                    </table>
                    <p>欢迎加入初心文化服务中心群，群号是：（596284087），如有问题请在群里咨询</p>
                    <p>如果您未购买商品，可能是其他用户误输入了您的邮箱地址。请忽略此邮件，或者<a href='http://www.chuxinm.com'> 联系我们</a><p>
                </div>
            </div>
        </body>";
    }
}