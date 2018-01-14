//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Plug/OrderDeleteJob 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2017/1/22 11:41:44
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pomelo.AspNetCore.TimedJob;
using System;

namespace Pls.Plug
{
    /// <summary>
    /// 订单删除定时器(删除7天内未支付的订单)
    /// 说明: 1.根据时间和未支付的状态查询出来需要删除的订单、2.循环删除的订单
    /// </summary>
    public class OrderJob : Job
    {
        // Begin 起始时间；Interval执行时间间隔，单位是毫秒，建议使用以下格式，此处为3小时；
        //SkipWhileExecuting是否等待上一个执行完成，true为等待；
        //[Invoke(Begin = "2017-01-22 11:55", Interval = 1000 * 3600 * 24, SkipWhileExecuting = true)]
        public void Run()
        {
            //Job要执行的逻辑代码
            Console.WriteLine("执行完成");
        }
    }
}