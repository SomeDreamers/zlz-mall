//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/TestController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2017/1/9 17:19:53
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc;
using Pls.Utils;
using Pls.Utils.oss;

namespace Pls.Controllers
{
    /// <summary>
    /// 测试控制器(对系统中所有内容的测试实现)
    /// </summary>
    public class TestController : BaseController
    {
        private RedisHelp redisHelp { get; set; }
        public TestController(ApplicationConfigServices _applicationConfigServices, RedisHelp _redisHelp)
            : base(_applicationConfigServices)
        {
            redisHelp = _redisHelp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var redis = redisHelp.StringGet("login_admin_66dbea2b41dd47a1a81eef2e5dc2af0e");
            return View();
        }

        public IActionResult QiniuIndex()
        {
            UploadDownloadUtil.uploadFile(@"E:\project\kencery_lyzj\code\ProgrammersLiveShow\src\ProgrammersLiveShow\wwwroot\img\bg.png", Settings.TestImagePrefix, "123asdsada12.png");
            return View();
        }

        public IActionResult AliyunIndex()
        {
            OssOptionUtil.OssPutObject(@"C:\Users\82069\Desktop\QQ图片20180117231453.png", "png");
            return View();
        }
    }
}