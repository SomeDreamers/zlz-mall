//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/RedisConnectionHelper 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/23 10:45:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;

namespace Pls.Utils
{
    /// <summary>
    /// 封装StackExchange.Redis 的ConnectionMultiplexer对象管理帮助类
    /// </summary>
    public class RedisConnectionHelp
    {
        //redis的键和连接字符串,现在配置在后台，后面扩展到配置文件中
        public static readonly string SysCustomKey = "pls_";
        private static readonly string RedisConnectionString = "127.0.0.1:6379,allowadmin=true,password=*******";

        //单例锁和redis初始化对象
        private static readonly object Locker = new object();
        private static ConnectionMultiplexer _instance;
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionCache = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 单例获取Redis的ConnectionMultiplexer对象
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                        {
                            _instance = GetManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 缓存获取，返回静态ConnectionMultiplexer对象
        /// </summary>
        /// <param name="connectionString">redis连接字符串</param>
        /// <returns></returns>
        public static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString)
        {
            if (!ConnectionCache.ContainsKey(connectionString))
            {
                ConnectionCache[connectionString] = GetManager(connectionString);
            }
            return ConnectionCache[connectionString];
        }

        /// <summary>
        /// 连接redis方法并且返回ConnectionMultiplexer对象
        /// </summary>
        /// <param name="connectionString">redis连接字符串</param>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            connectionString = connectionString ?? RedisConnectionString;
            try
            {
                var connect = ConnectionMultiplexer.Connect(connectionString);

                //注册如下事件,事件方法内部需要写入日志
                connect.ConnectionFailed += MuxerConnectionFailed;
                connect.ConnectionRestored += MuxerConnectionRestored;
                connect.ErrorMessage += MuxerErrorMessage;
                connect.ConfigurationChanged += MuxerConfigurationChanged;
                connect.HashSlotMoved += MuxerHashSlotMoved;
                connect.InternalError += MuxerInternalError;

                return connect;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            Console.WriteLine("Configuration changed: " + e.EndPoint);
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            Console.WriteLine("ErrorMessage: " + e.Message);
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine("ConnectionRestored: " + e.EndPoint);
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine("重新连接：Endpoint failed: " + e.EndPoint + ", " + e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)));
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            Console.WriteLine("HashSlotMoved:NewEndPoint" + e.NewEndPoint + ", OldEndPoint" + e.OldEndPoint);
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            Console.WriteLine("InternalError:Message" + e.Exception.Message);
        }
    }
}