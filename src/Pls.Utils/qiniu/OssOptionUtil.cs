using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Utils.qiniu
{
    public class OssOptionUtil
    {
        public static OssClient client = new OssClient(endpoint, accessKeyId, accessKeySecret);
    }
}
