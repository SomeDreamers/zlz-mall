//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/UserInfoEntity 
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
    /// 用户详情表实体
    /// </summary>
    public class UserInfoEntity
    {
        /// <summary>
        /// 用户详情表Id、主键
        /// </summary>
        public string userinfo_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 用户登陆表的主键Id（不可为空）
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 可空  国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 可空  省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 可空  城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Address String 可空  地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 可空  生日
        /// </summary>
        public DateTime? birthday { get; set; }

        /// <summary>
        /// 可空  生肖
        /// </summary>
        public string zodiac { get; set; }

        /// <summary>
        /// 方向Id
        /// </summary>
        public int? direction_id { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}