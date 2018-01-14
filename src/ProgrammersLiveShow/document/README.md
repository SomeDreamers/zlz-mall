###1.项目初始化数据库(mysql)
* 打开cmd,跳转到项目路径下:(../src/项目名称下)执行下面的两条命令
	* dotnet ef database drop(此命令此后不允许使用)
	* dotnet ef migrations add 功能名称
	* dotnet ef database update

	* ASP.NET Core环境下载地址：https://www.microsoft.com/net/core#windows
	* 学习博客：
		* https://github.com/scheshan/DotNetClub
		* 封装分页插件：http://www.jb51.net/article/89266.htm

###3.VisualStudio 2017模板实现(未实现)
	* 如何设置：http://www.cnblogs.com/Schme/p/4947453.html
	* 模板内容
		//=============================================================
		//  Copyright (C) 2016-2100
		//  CLR版本:                	$clrversion$
		//  机器名称:               	$machinename$
		//  命名空间名称/文件名:    	$rootnamespace$/$safeitemname$ 
		//  创建人:			   	  		$username$     
		//  创建时间:     		  		$time$
		//  网站：				  		http://www.chuxinm.com
		//==============================================================

###4.任务/Bug平台管理
	* https://www.bugclose.com/

### 5. 发布网站
	* VS发布到本地
		* 第一步在vs下发布：切换到src的根目录下(../src/项目名称下)，运行命令dotnet publish，运行不报错则本地发布成功
		* 跳转到发布的路径下(/publish下/),运行命令：dotnet ProgrammersLiveShow.dll ，根据提示访问地址,可本地测试。
	* 备份服务器上面的源码
		①：备份线上的源代码，每次的都必须进行备份一份(必须做)
			* tar zcvf /var/www/default/remark/(日期)publish.tar.gz /var/www/default/publish/
		②：删除掉refs和runtimes文件夹
		③：删除掉wwwroot下的upload文件夹，然后统一上传替换
	* Jexus部署Asp.NET MVC Core
		* 参考网站：http://www.linuxidc.com/Linux/2016-08/133941.htm
		* Linux下进程在后台运行：nohup dotnet ProgrammersLiveShow.dll &
		* 后台运行之后如何关闭：(1):ps -ef | grep ProgrammersLiveShow.dll  (2):kill -9 PID
	* Centos7开放端口
		* Centos升级到7之后，发现无法使用iptables控制Linuxs的端口，google之后发现Centos 7使用firewalld代替了原来的iptables。下面记录如何使用firewalld开放Linux端口：
		* 开启端口: firewall-cmd --zone=public --add-port=80/tcp --permanent   --zone #作用域  --add-port=80/tcp #添加端口，格式为：端口/通讯协议 --permanent #永久生效，没有此参数重启后失效 
		* 重启防火墙 firewall-cmd --reload 
		* 开启防火墙： systemctl start firewalld

### 6. redis安装
	* 安装tcl8.6.3，安装目录是：usr/tcl中
	* 安装redis2.3.5,安装目录是：usr/redis
	* 安装完成之后启动redis命令
		① src/redis-server &      启动redis，加上&表示使redis以后台程序方式运行
		② redis-server  /usr/redis/redis.conf  启动redis
		③ 启动redis测试环境 src/redis-cli
		④ 关闭redis  src/redis-cli shutdown  

### 7.七牛用使用
	* http://www.cnblogs.com/starcrm/p/5126702.html
	* 源码地址：https://github.com/fengyhack/csharp-sdk-shared
	* 源码地址：https://github.com/qiniu/csharp-sdk/issues