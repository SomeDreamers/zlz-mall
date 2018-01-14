//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/ZtreeInfo 
//  创建人:                     kencery     
//  创建时间:                   2016/10/6 10:56:01
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// Ztree加载返回的实体
    /// </summary>
    public class ZtreeInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public string pId { get; set; }

        /// <summary>
        /// 按钮名称
        /// </summary>
        public string name { get; set; }
    }
}