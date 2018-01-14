//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        ProgrammersLiveShow/Startup 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Pls.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Pls.Utils;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using NLog.Extensions.Logging;
using Pls.Plug;

namespace ProgrammersLiveShow
{
    /// <summary>
    /// 项目启动的时候执行下面所有的配置方法
    /// </summary>
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //初始化数据库
            services.AddDbContext<DataContext>(options => options.UseMySql(Configuration.GetConnectionString("MySql"),
                b => { b.MigrationsAssembly("ProgrammersLiveShow"); }));

            //注册路由
            services.AddMvc();

            //注册定时任务
            services.AddTimedJob();

            //注册Session
            services.AddSession(c => { c.IdleTimeout = TimeSpan.FromMinutes(30); });

            //注入读取配置文件
            services.AddOptions();
            services.Configure<ApplicationConfig>(Configuration.GetSection("ApplicationConfig"));
            services.Configure<SendMailConfig>(Configuration.GetSection("SendMailConfig"));

            //解决界面显示HTML编码问题
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            //注册AutoFac
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<RegestAutoFac>();
            containerBuilder.Populate(services);
            return containerBuilder.Build().Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();    //日志

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  //开发环境异常抛出
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");  //生产环境异常抛出
            }

            app.UseTimedJob();  //使用TimedJob
            app.UseSession();  //启用Session
            app.UseStaticFiles();   //启用使用静态文件来自本系统的(Jquery和bootstrap等的设置)


            //手动设置MVC路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}