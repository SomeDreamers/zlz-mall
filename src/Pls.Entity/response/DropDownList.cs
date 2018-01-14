//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/DropDownList 
//  创建人:                     kencery     
//  创建时间:                   2016/10/3 17:19:10
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 下拉列表的读取返回实体，所有下拉列表统一走这个类
    /// </summary>
    public class DropDownList
    {
        /// <summary>
        /// 下拉value
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 下拉值
        /// </summary>
        public string name { get; set; }
    }
}