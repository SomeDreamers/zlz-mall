using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Entity.enumeration
{
    /// <summary>
    /// 分类类型
    /// </summary>
    public enum ECategoryType
    {
        /// <summary>
        /// 热销
        /// </summary>
        Hot = 1,
        /// <summary>
        /// 推荐
        /// </summary>
        recommend = 2,
        /// <summary>
        /// 新品
        /// </summary>
        New = 3,
        /// <summary>
        /// 自建
        /// </summary>
        Create = 4
    }

    public class ECategoryTypeExtension
    {
        public static string GetDescription(this ECategoryType type)
        {
            switch (type)
            {
                case ECategoryType.Hot:
                    return "热销";
                case ECategoryType.recommend:
                    return "推荐";
                case ECategoryType.New:
                    return "新品";
                case ECategoryType.Create:
                    return "自建";
                default:
                    return "";
            }
        }
    }
}
