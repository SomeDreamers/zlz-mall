//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/FileUtil 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/1 17:46:00
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace Pls.Utils
{
    /// <summary>
    /// 文件路劲的存放(本地上传\七牛云上传())
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// 上传图片的Demo路径(本地上传路径)
        /// </summary>
        public static string localhost_image = Path.DirectorySeparatorChar + "upload" + Path.DirectorySeparatorChar + "demo" + Path.DirectorySeparatorChar;

        /// <summary>
        /// 封装上传图片插件(本地上传)、废弃
        /// </summary>
        /// <param name="files">上传文件的流信息</param>
        /// <param name="absolutely_address">存放的绝对路径</param>
        /// <param name="webRootPath">系统初始化路径</param>
        /// <param name="result_number">返回执行失败的错误码</param>
        /// <returns></returns>
        public static string UploadImage(IFormFileCollection files, string absolutely_address, string webRootPath, out int result_number)
        {
            if (files.Count < 1)
            {
                result_number = 902;
                return "";
            }
            //读取图片名称和图片后缀，判断图片后缀是否符合默认的几个格式，如果不符合则直接报错。
            IFormFile file = files[0];
            var file_name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string extension = new FileInfo(file_name).Extension.ToLower();

            //判断图片格式以及图片大小是否合适(大小限制为1兆)
            if (!RegexUtil.Image(extension))
            {
                result_number = 3001;
                return "";
            }

            long lenth = file.Length / 1024;
            if (lenth > 1024)
            {
                result_number = 3000;
                return "";
            }

            //构造新的图片名称、读取上传之后的图片路径  写入流上传并且释放资源
            file_name = CommonUtil.ReadDateTime() + "_" + file.Length + extension;
            var url = absolutely_address + file_name;

            using (FileStream fs = File.Create(webRootPath + url))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            result_number = 200;
            return url;
        }

        /// <summary>
        /// 封装上传图片插件(七牛云上传)
        /// </summary>
        /// <param name="files">上传文件的流信息</param>
        /// <param name="absolutely_address">存放的绝对路径</param>
        /// <param name="webRootPath">系统初始化路径</param>
        /// <param name="prefix">存放七牛云的前缀</param>
        /// <param name="result_number">返回执行失败的错误码</param>
        /// <returns></returns>
        public static string UploadQiniuImage(IFormFileCollection files, string absolutely_address, string webRootPath, string prefix, out int result_number)
        {
            if (files.Count < 1)
            {
                result_number = 902;
                return "";
            }
            //读取图片名称和图片后缀，判断图片后缀是否符合默认的几个格式，如果不符合则直接报错。
            IFormFile file = files[0];
            var file_name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string extension = new FileInfo(file_name).Extension.ToLower();

            //判断图片格式以及图片大小是否合适(大小限制为1兆)
            if (!RegexUtil.Image(extension))
            {
                result_number = 3001;
                return "";
            }

            long lenth = file.Length / 1024;
            if (lenth > 1024)
            {
                result_number = 3000;
                return "";
            }

            //上传图片到七牛云下并且返回七牛云的地址  (Linux下上传含有问题,等修复完成在上线linux)
            file_name = CommonUtil.ReadDateTime() + "_" + file.Length + extension;
            var url = webRootPath + absolutely_address + file_name;
            using (FileStream fs = File.Create(url))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            string return_url = UploadDownloadUtil.uploadFile(url, prefix, file_name);
            if (string.IsNullOrEmpty(return_url))
            {
                result_number = 902;
                return "";
            }
            File.Delete(url);

            result_number = 200;
            return return_url;
        }
    }
}