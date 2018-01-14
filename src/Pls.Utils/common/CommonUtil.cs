//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Utils/CommonUtil 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Pls.Utils
{
    /// <summary>
    /// 公共类，封装公共方法
    /// </summary>
    /// 修改记录：Brian 新增枚举方法
    public static class CommonUtil
    {
        /// <summary>
        /// 返回处理后的GUID，将
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 读取时间戳
        /// </summary>
        /// <returns></returns>
        public static long TimeSpan()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>返回加密后的字符串信息</returns>
        public static string Md5(string str)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 读取当前时间的时间字符串
        /// </summary>
        /// <returns></returns>
        public static string ReadDateTime()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 按照传递的参数生成需要的随机数
        /// </summary>
        /// <param name="length">多少位随机数</param>
        /// <param name="rand_next">1-多少位随机数</param>
        /// <returns></returns>
        public static List<int> GetRandom(int length = 5, int rand_next = 100)
        {
            List<int> list = new List<int>(length);
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int random_num = random.Next(rand_next) + 1;
                if (!list.Contains(random_num))
                {
                    list.Add(random_num);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据传递的信息生成随机数
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="rand_next">1-100之间</param>
        /// <param name="start">开始字符</param>
        /// <returns></returns>
        public static string ReadRandom(string start, int length = 4, int rand_next = 9)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(rand_next));
            }
            return string.IsNullOrEmpty(start) ? sb.ToString() : start + sb.ToString();
        }

        /// <summary>
        /// 读取字母的随机数
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="rand_next">1-100之间</param>
        /// <returns></returns>
        public static string AZReadRandom(int length = 4)
        {
            char[] allcheckRandom = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            StringBuilder newRandom = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(allcheckRandom[rd.Next(allcheckRandom.Length)]);
            }
            return newRandom.ToString();
        }
    }
}