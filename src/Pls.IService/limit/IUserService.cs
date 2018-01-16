//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IService/IUserService 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Pls.Entity;
using Pls.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    /// 用户管理业务接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 后台登录逻辑实现(根据用户名和密码)
        /// </summary>
        /// <param name="login_name_in">用户名</param>
        /// <param name="user_pwd_in">密码</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Login(string login_name_in, string user_pwd_in);

        /// <summary>
        /// 根据用户名密码登录前端购物商城
        /// </summary>
        /// <param name="login_name_in">用户名</param>
        /// <param name="user_pwd_in">密码</param>
        /// <returns></returns>
        Task<BaseResult<bool>> LoginFront(string login_name_in, string user_pwd_in);

        /// <summary>
        /// 异步查询人员列表
        /// </summary>
        /// <param name="userInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<UserDepartRoleInfo>>> List(UserInfo userInfo);

        /// <summary>
        /// 根据主键Id查询人员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<UserEntity>> GetById(string id);

        /// <summary>
        /// 根据主键Id查询人员-部门-角色表信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        Task<BaseResult<UserDepartRoleInfo>> getInnerById(string id);

        /// <summary>
        /// 查询团队信息
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<UserEntity>> GetTeamUserInfo();

        /// <summary>
        /// 根据用户Id和输入的内容判断是否存在数据
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="content">输入的内容</param>
        /// <returns></returns>
        Task<BaseResult<bool>> checkData(string user_id, string content);

        /// <summary>
        /// 添加微信用户
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        Task<BaseResult<DropDownList>> AddWexinUser(UserEntity userEntity, UserInfoEntity userInfoEntity);

        /// <summary>
        /// 注册用户信息，不能受权限控制，前台
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        Task<BaseResult<DropDownList>> Add(UserEntity userEntity);

        /// <summary>
        /// 根据用户Id修改用户名称,并且发送激活邮件。
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="user_name">用户名称</param>
        /// <param name="user_email">用户Email</param>
        /// <param name="sendMailConfig">发送邮件的中间件</param>
        /// <param name="host_url">域名地址</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateUserName(string user_id, string user_name, string user_email, SendMailConfig sendMailConfig, string host_url);

        /// <summary>
        /// 用户激活：根据用户邮箱传递的内容进行邮件激活
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="key">用户key（用户名称和邮件生成的Key）</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Activation(string user_id, string key);

        /// <summary>
        /// 人员添加（从后台添加，数据来源于后台）
        /// </summary>
        /// <param name="userAdminInfo">人员实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddAdmin(UserAdminInfo userAdminInfo);

        /// <summary>
        ///  人员修改(从后台对人员进行修改)(admin用户只能对admin用户进行修改，不可做其它修改)
        /// </summary>
        /// <param name="userAdminInfo">用户实体</param>
        /// <param name="user_id">登录用户的userId</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateAdmin(UserAdminInfo userAdminInfo, string user_id);

        /// <summary>
        /// 前台用户修改用户信息
        /// </summary>
        /// <param name="userEntity">传递的用户实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateUserFront(UserEntity userEntity);

        /// <summary>
        /// 上传用户头像
        /// </summary>
        /// <param name="files">上传的文件</param>
        /// <returns></returns>
        BaseResult<string> UploadUserImage(IFormFileCollection files);

        /// <summary>
        /// 修改用户上传图片
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="image_url">用户ImageUrl</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateUserImage(string user_id, string image_url);

        /// <summary>
        /// 人员禁用
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="disable_desc">用户禁用详情</param>
        /// <param name="type">启用禁用类型(1:禁用,0:启用)</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string user_id, string disable_desc, int type);

        /// <summary>
        /// 为用户设置角色
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="role_id">角色集合</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateSetRole(string user_id, List<string> role_ids);

        /// <summary>
        /// 删除用户，物理删除
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Delete(string user_id);

        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Activate(string user_id);

        /// <summary>
        /// 访问开启
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Visit(string user_id);

        /// <summary>
        /// 首页读取用户信息
        /// </summary>
        /// <returns></returns>
        Task<Pager<IQueryable<UserSession>>> GetUserInfo();

        /// <summary>
        /// 根据读取的SessionId读取菜单信息
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<List<MenuActionInfo>> GetMenuInfo(string user_id);

        /// <summary>
        /// 根据用户Id和路径查询按钮集合并且返回
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="current_url">当前请求Url</param>
        /// <returns></returns>
        Task<IQueryable<ButtionActionInfo>> getButtionInfo(string user_id, string current_url);

        /// <summary>
        /// 根据用户id修改密码
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdatePassword(string user_id, string passwordOld, string passwordNew);
    }
}