//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/ApplicationAdminConfig 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/18 17:43:15
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Utils
{
    /// <summary>
    /// 加载配置文件的信息
    /// </summary>
    public class ApplicationConfig
    {
        /// <summary>
        /// 网站管理平台标题
        /// </summary>
        public string AdminTitle { get; set; }

        /// <summary>
        /// 网站版权
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// 网站后台meta的KeyWords
        /// </summary>
        public string AdminKeyWords { get; set; }

        /// <summary>
        /// 网站后台meta的Description
        /// </summary>
        public string AdminDescription { get; set; }

        /// <summary>
        /// 网站后台的meta的Author
        /// </summary>
        public string AdminAuthor { get; set; }

        /// <summary>
        /// 首页描述，如果没有的话则直接为空即可
        /// </summary>
        public string HomeDescription { get; set; }

        /// <summary>
        /// 首页描述需要显示多长时间(如果没有则一直显示)
        /// </summary>
        public string HomeDescriptionStatus { get; set; }

        /// <summary>
        /// 系统所支出的金额统计
        /// </summary>
        public string ExpendMoney { get; set; }
    }
}