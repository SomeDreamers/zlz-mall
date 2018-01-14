//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/ButtonActionEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 页面或者按钮表实体
    /// </summary>
    public class ButtonActionEntity
    {
        /// <summary>
        /// 主键-GUID()
        /// </summary>
        public string action_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 页面或者按钮名称
        /// </summary>
        public string action_name { get; set; }

        /// <summary>
        /// 可空  页面或者按钮请求路径
        /// </summary>
        public string action_url { get; set; }

        /// <summary>
        /// 可空  页面父级别，父级别Id
        /// </summary>
        public string action_parentid { get; set; } = "0";

        /// <summary>
        /// 可空  页面，按钮图标
        /// </summary>
        public string action_icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int action_sort { get; set; } = 1;

        /// <summary>
        /// 可空 JS响应的事件或者按钮Id
        /// </summary>
        public string action_event { get; set; }

        /// <summary>
        /// 菜单类型来源(默认2) 1：前台页面  2，后台左侧导航  3，普通按钮
        /// </summary>
        public int action_type { get; set; } = (int)ActionType.adminleft;

        /// <summary>
        /// 是否禁用(管理员设置，只可禁用，不能删除)
        /// </summary>
        public int disable { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        /// 可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 非空，是否为新功能 默认为新 true
        /// </summary>
        public bool action_newaction { get; set; } = true;

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}