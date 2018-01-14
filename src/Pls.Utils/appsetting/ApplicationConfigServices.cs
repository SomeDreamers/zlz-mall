//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/ApplicationConfigService 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/18 17:45:05
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.Extensions.Options;

namespace Pls.Utils
{
    /// <summary>
    /// 读取配置文件appsetting文件
    /// </summary>
    public class ApplicationConfigServices
    {
        private readonly IOptions<ApplicationConfig> _appConfiguration;

        private readonly IOptions<SendMailConfig> _mailConfiguration;
        public ApplicationConfigServices(IOptions<ApplicationConfig> appConfiguration, IOptions<SendMailConfig> mailConfiguation)
        {
            _appConfiguration = appConfiguration;
            _mailConfiguration = mailConfiguation;
        }

        public ApplicationConfig AppConfigurations
        {
            get
            {
                return _appConfiguration.Value;
            }
        }

        public SendMailConfig MailConfigurations
        {
            get
            {
                return _mailConfiguration.Value;
            }
        }
    }
}