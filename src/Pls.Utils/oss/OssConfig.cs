using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Utils.oss
{
    /// <summary>
    /// 阿里云配置
    /// </summary>
    public class OssConfig
    {
        public static string accessKeyId = "LTAIDxMUFDwQ6B9f";
        public static string accessKeySecret = "AVq0jRHV9s5l9oqnNHH66zzyk2Zedf";
        public static string internalendpoint = "oss-cn-shenzhen-internal.aliyuncs.com";
        public static string endpoint = "oss-cn-shenzhen.aliyuncs.com";
        public static string bucket = "zaolazi-mall";

        public static string OssHostUrl = $"http://{bucket}.{endpoint}/";
    }
}
