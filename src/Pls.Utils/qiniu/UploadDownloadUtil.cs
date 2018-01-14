//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/UploadDownloadUtil 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2017/1/10 14:30:18
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;

namespace Pls.Utils
{
    /// <summary>
    /// 上传下载实现(文件上传、文件下载实现)
    /// 源码地址：https://github.com/qiniu/csharp-sdk
    /// Demo实现：http://oiy037d6a.bkt.clouddn.com/csharp-sdk-man-v7.2.5/Qiniu-IO.html
    /// </summary>
    public class UploadDownloadUtil
    {
        /// <summary>
        ///  简单上传-上传小文件 （根据路径上传图片）
        /// </summary>
        /// <param name="localFile">本地文件</param>
        /// <param name="prefix">前缀</param>
        /// <param name="saveKey">保存路径</param>
        /// <returns></returns>
        public static string uploadFile(string localFile, string prefix, string saveKey)
        {
            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独提供了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(Settings.AccessKey, Settings.SecretKey);

            // 上传策略，参见 
            // http://developer.qiniu.com/article/developer/security/put-policy.html
            PutPolicy putPolicy = new PutPolicy();

            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            putPolicy.Scope = Settings.Bucket;

            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.setExpires(3600);

            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认）则不删除
            //putPolicy.DeleteAfterDays = 1;

            // 生成上传凭证，参见
            // http://developer.qiniu.com/article/developer/security/upload-token.html  
            string token = Auth.createUploadToken(mac, putPolicy.ToJsonString());

            FormUploader su = new FormUploader();
            HttpResult result = su.uploadFile(localFile, prefix + "/" + saveKey, token);

            //判断是否上传成功，上传成功，返回路径，否则返回空值
            if (result.Code != 200)
            {
                return "";
            }
            return Settings.HostAddress + prefix + "/" + saveKey;
        }
    }
}