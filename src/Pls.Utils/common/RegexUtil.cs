//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Utils/RegexUtil 
//  创建人:                     kencery     
//  创建时间:                   2016/9/30 20:36:35
//  网站:                       http://www.chuxinm.com
//==============================================================
using System.Text.RegularExpressions;

namespace Pls.Utils
{
    /// <summary>
    /// 所有正则表达式验证规则
    /// </summary>
    public class RegexUtil
    {
        private const string email = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        private const string phone = @"^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$";
        private const string image = @"^.*.(?:png|jpg|bmp|gif|jpeg)$";

        /// <summary>
        /// 正则表达式判断邮箱
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Email(string str)
        {
            Regex regex = new Regex(email);
            if (regex.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 正则表达式判断电话
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Phone(string str)
        {
            Regex regex = new Regex(phone);
            if (regex.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 正则表达式判断 图片后缀
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Image(string str)
        {
            Regex regex = new Regex(image);
            if (regex.IsMatch(str))
            {
                return true;
            }
            return false;
        }
    }
}