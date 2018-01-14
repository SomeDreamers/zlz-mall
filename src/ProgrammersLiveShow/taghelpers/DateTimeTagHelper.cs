//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	ProgrammersLiveShow/DateTimeTagHelper 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/19 10:14:35
//  网站：				  		http://www.chuxinm.com
//==============================================================

using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProgrammersLiveShow
{
    /// <summary>
    /// 封装时间处理的DateTime
    /// You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    /// </summary>
    [HtmlTargetElement("datetime")]
    public class DateTimeTagHelper : TagHelper
    {
        [HtmlAttributeName("date")]
        public DateTime? Date { get; set; }

        [HtmlAttributeName("friendly")]
        public bool Friendly { get; set; }

        [HtmlAttributeName("format")]
        public string Format { get; set; }

        public DateTimeTagHelper()
        {
            this.Friendly = true;
            this.Format = "yyyy-MM-dd HH:mm:ss";
        }

        public override void Init(TagHelperContext context)
        {
            if (!this.Date.HasValue)
            {
                throw new ArgumentNullException("Date");
            }

            base.Init(context);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            string content = null;

            if (!this.Friendly)
            {
                if (this.Format != null)
                {
                    content = this.Date.Value.ToString(this.Format);
                }
                else
                {
                    content = this.Date.Value.ToString();
                }
            }
            else
            {
                var ts = DateTime.Now - this.Date.Value;

                if (ts.TotalDays > 365)
                {
                    int years = Convert.ToInt32(ts.TotalDays / 365);
                    content = $"{years}年前";
                }
                else if (ts.TotalDays > 1)
                {
                    int days = Convert.ToInt32(ts.TotalDays);
                    content = $"{days}天前";
                }
                else if (ts.TotalHours > 1)
                {
                    int hours = Convert.ToInt32(ts.TotalHours);
                    content = $"{hours}小时前";
                }
                else if (ts.TotalMinutes > 1)
                {
                    int minutes = Convert.ToInt32(ts.TotalMinutes);
                    content = $"{minutes}分钟前";
                }
                else
                {
                    content = "刚刚";
                }
            }

            output.Content.SetContent(content);
        }
    }
}