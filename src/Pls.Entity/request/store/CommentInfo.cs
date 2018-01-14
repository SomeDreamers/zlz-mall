//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentInfo 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/3 22:16:40
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 评论查询实体
    /// </summary>
    public class CommentInfo : PageEntity
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 启用状态
        /// </summary>
        public int status { get; set; }
    }
}