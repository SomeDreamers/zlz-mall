using Aliyun.OSS;
using Aliyun.OSS.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pls.Utils.oss
{
    /// <summary>
    /// 阿里云oss操作类
    /// </summary>
    public static class OssOptionUtil
    {
        public static OssClient client = new OssClient(OssConfig.endpoint, OssConfig.accessKeyId, OssConfig.accessKeySecret);

        static OssOptionUtil()
        {
//#if DEBUG
//            client = new OssClient(OssConfig.endpoint, OssConfig.accessKeyId, OssConfig.accessKeySecret);
//#endif
        }

        /// <summary>
        /// 封装上传图片插件(阿里云上传)
        /// </summary>
        /// <param name="files">上传文件的流信息</param>
        /// <param name="absolutely_address">存放的绝对路径</param>
        /// <param name="webRootPath">系统初始化路径</param>
        /// <param name="result_number">返回执行失败的错误码</param>
        /// <returns></returns>
        public static string UploadAliYunImage(IFormFileCollection files, string absolutely_address, string webRootPath, out int result_number)
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

            //上传图片到阿里云
            file_name = CommonUtil.ReadDateTime() + "_" + file.Length + extension;
            var fileToUpload = webRootPath + absolutely_address;
            string return_url = OssPutObject(fileToUpload, extension);
            if (string.IsNullOrEmpty(return_url))
            {
                result_number = 902;
                return "";
            }
            File.Delete(fileToUpload);

            result_number = 200;
            return return_url;
        }

        public static string OssPutObject(string fileToUpload, string extension)
        {
            string md5;
            using (var fs = File.Open(fileToUpload, FileMode.Open))
            {
                md5 = OssUtils.ComputeContentMd5(fs, fs.Length);
            }
            var key = md5 + "." + extension;
            var result = client.PutObject(OssConfig.bucket, key, fileToUpload);
            return OssConfig.OssHostUrl + key;
        }
    }
}
