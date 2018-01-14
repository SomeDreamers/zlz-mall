//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentImage 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 13:10:05
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品评论表对应的图片实体(Pls_CommentImage)
    /// </summary>
    public class CommentImageEntity
    {
        /// <summary>
        ///  主键-GUID()
        /// </summary>
        public string commentiamge_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 商品评论表Id
        /// </summary>
        public string comment_id { get; set; }

        /// <summary>
        ///  商品评论表图片地址
        /// </summary>
        public string comment_address { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}