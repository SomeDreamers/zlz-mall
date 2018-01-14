//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/Settings 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2017/1/10 11:40:50
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Utils
{
    /// <summary>
    /// 初始化七牛配置，读取配置文件
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// 图片访问地址
        /// </summary>
        public static string HostAddress = "http://images.chuxinm.com/";

        /// <summary>
        /// AccessKey  密钥
        /// </summary>
        public static string AccessKey = "************";

        /// <summary>
        /// SecretKey  密钥
        /// </summary>
        public static string SecretKey = "*******************";

        /// <summary>
        /// Bucket 命名空间(放在哪个下面)
        /// </summary>
        public static string Bucket = "chuxinm";

        /// <summary>
        /// 上传商品的前缀展示
        /// </summary>
        public static string ShopImagePrefix = "shop";

        /// <summary>
        /// 上传用户头像的前缀展示
        /// </summary>
        public static string UserImagePrefix = "user";

        /// <summary>
        /// 其它的上传路径
        /// </summary>
        public static string ChuxinmImagePrefix = "chuxinm";

        /// <summary>
        /// 上传开发人员测试的前缀展示
        /// </summary>
        public static string TestImagePrefix = "test";
    }
}