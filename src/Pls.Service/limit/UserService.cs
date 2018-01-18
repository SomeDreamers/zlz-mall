//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Service/UserService 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.IService;
using Pls.IRepository;
using System.Threading.Tasks;
using System.Linq;
using Pls.UnitOfWork;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using Pls.Utils;
using Pls.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Pls.Utils.oss;

namespace Pls.Service
{
    /// <summary>
    /// 用户表操作接口实现逻辑
    /// </summary>
    public class UserService : IUserService
    {
        //注入用户管理操作
        private IUserRepository userRepository { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        private IUserInfoRepository userInfoRepository { get; set; }
        private HttpContextUtil httpContextUtil { get; set; }
        private IUserDepartmentRepository userDepartmentRepository { get; set; }
        private IDepartmentRepository departmentRepository { get; set; }
        private IUserRoleRepository userRoleRepository { get; set; }
        private IRoleRepository roleRepository { get; set; }
        private IButtonActionRepository buttonActionRepository { get; set; }
        private IHostingEnvironment hostingEnv { get; set; }
        private RedisHelp redisHelp { get; set; }
        public UserService(IUserRepository _userRepository, IUnitOfWork _unitOfWork, IUserInfoRepository _userInfoRepository, HttpContextUtil _httpContextUtil,
            IUserDepartmentRepository _userDepartmentRepository, IDepartmentRepository _departmentRepository, IUserRoleRepository _userRoleRepository, IRoleRepository _roleRepository,
            IButtonActionRepository _buttonActionRepository, IHostingEnvironment _hostingEnv, RedisHelp _redisHelp)
        {
            userRepository = _userRepository;
            unitOfWork = _unitOfWork;
            userInfoRepository = _userInfoRepository;
            httpContextUtil = _httpContextUtil;
            userDepartmentRepository = _userDepartmentRepository;
            departmentRepository = _departmentRepository;
            userRoleRepository = _userRoleRepository;
            roleRepository = _roleRepository;
            buttonActionRepository = _buttonActionRepository;
            hostingEnv = _hostingEnv;
            redisHelp = _redisHelp;
        }

        public async Task<BaseResult<bool>> Login(string login_name_in, string user_pwd_in)
        {
            if (string.IsNullOrEmpty(login_name_in) || string.IsNullOrEmpty(user_pwd_in))
            {
                return new BaseResult<bool>(808, false);
            }

            //这里可以用邮箱和手机号登陆，需要判断使用什么方式登录，查询用户信息之后验证是否可以访问
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            where = RegexUtil.Email(login_name_in) ? where.AndAlso(c => c.user_email == login_name_in) :
                where.AndAlso(c => c.user_phone == login_name_in);
            where = where.AndAlso(c => c.user_pwd == CommonUtil.Md5(user_pwd_in));

            UserEntity userEntity = await userRepository.GetAsync(where);
            if (userEntity == null)
            {
                return new BaseResult<bool>(1000, false);
            }
            if (userEntity.disable == (int)DisableStatus.disable_true)
            {
                return new BaseResult<bool>(1004, false);
            }
            if (userEntity.user_activation == (int)DisableStatus.disable_true)
            {
                return new BaseResult<bool>(1005, false);
            }
            if (userEntity.user_visit == (int)DisableStatus.disable_true)
            {
                return new BaseResult<bool>(1006, false);
            }

            //用户登录正常，修改用户登录时间并且将登录的信息保存到Session中
            await userRepository.UpdateAsync(new UserEntity() { user_id = userEntity.user_id, last_time = DateTime.Now }, true, true, c => c.last_time);

            //处理信息，如果redis连接成功，则直接判断是否存在值，如果存在，则直接使用，否则直接查询并且保存   ，如果连接失败，则直接查询
            List<string> buttionActions = null;
            if (redisHelp._conn != null)
            {
                string key = string.Format(RedisKeyUtil.login_admin, userEntity.user_id);
                if (redisHelp.KeyExists(key))
                {
                    buttionActions = JsonNetHelper.DeserializeObject<List<string>>(await redisHelp.StringGetAsync(key));
                }
                else
                {
                    buttionActions = buttonActionRepository.GetMenuInfo(userEntity.user_id, c => c.action_type != (int)ActionType.front
                         && c.action_url != null && c.disable == (int)DisableStatus.disable_false).Select(c => c.action_url).ToList();
                    await redisHelp.StringSetAsync(key, JsonNetHelper.SerializeObject(buttionActions), new TimeSpan(30, 12, 60));
                }
            }
            else
            {
                buttionActions = buttonActionRepository.GetMenuInfo(userEntity.user_id,
                c => c.action_type != (int)ActionType.front && c.action_url != null && c.disable == (int)DisableStatus.disable_false).Select(c => c.action_url).ToList();
            }

            UserSession userSession = new UserSession
            {
                user_id = userEntity.user_id,
                user_name = userEntity.user_name + userEntity.user_code,
                user_image = userEntity.user_image,
                full_name = userEntity.full_name,
                action_url = buttionActions == null ? null : buttionActions
            };
            httpContextUtil.setObjectAsJson(KeyUtil.user_info, userSession);
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> LoginFront(string login_name_in, string user_pwd_in)
        {
            if (string.IsNullOrEmpty(login_name_in) || string.IsNullOrEmpty(user_pwd_in))
            {
                return new BaseResult<bool>(808, false);
            }

            //这里可以用邮箱和手机号登陆，需要判断使用什么方式登录，查询用户信息之后验证是否可以访问
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            where = RegexUtil.Email(login_name_in) ? where.AndAlso(c => c.user_email == login_name_in) :
                where.AndAlso(c => c.user_phone == login_name_in);
            where = where.AndAlso(c => c.user_pwd == CommonUtil.Md5(user_pwd_in));

            UserEntity userEntity = await userRepository.GetAsync(where);
            if (userEntity == null)
            {
                return new BaseResult<bool>(1000, false);
            }
            if (userEntity.disable == (int)DisableStatus.disable_true)
            {
                return new BaseResult<bool>(1004, false);
            }
            if (userEntity.user_activation == (int)DisableStatus.disable_true)
            {
                return new BaseResult<bool>(1005, false);
            }

            //修改用户当前时间为当前时间
            await userRepository.UpdateAsync(new UserEntity() { user_id = userEntity.user_id, last_time = DateTime.Now }, true, true, c => c.last_time);

            UserSession userSession = new UserSession
            {
                user_id = userEntity.user_id,
                user_name = userEntity.user_name + userEntity.user_code,
                user_image = userEntity.user_image
            };

            httpContextUtil.setObjectAsJson(KeyUtil.user_info_front, userSession);
            return new BaseResult<bool>(200, true);
        }

        public async Task<Pager<IQueryable<UserDepartRoleInfo>>> List(UserInfo userInfo)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<UserDepartRoleInfo, bool>> where_search = LinqUtil.True<UserDepartRoleInfo>();
            if (!string.IsNullOrEmpty(userInfo.name))
            {
                where_search = RegexUtil.Email(userInfo.name) ? where_search.AndAlso(c => c.user_email == userInfo.name)
                    : where_search.AndAlso(c => c.user_phone == userInfo.name);
            }
            if (userInfo.gender != -1)
            {
                where_search = where_search.AndAlso(c => c.user_gender == userInfo.gender);
            }
            if (userInfo.source != -1)
            {
                where_search = where_search.AndAlso(c => c.source_type == userInfo.source);
            }
            if (userInfo.status != -1)
            {
                where_search = where_search.AndAlso(c => c.disable == userInfo.status);
            }

            //根据条件查询用户表，部门表，用户部门表查询出来用户信息
            int total = 0;
            IQueryable<UserDepartRoleInfo> user_dep_role = await userRepository.getLeftJoinDepRole(where_search,
                userInfo.pageindex, userInfo.pagesize, out total);

            return new Pager<IQueryable<UserDepartRoleInfo>>(total, user_dep_role);
        }

        public async Task<BaseResult<UserEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<UserEntity>(808);
            }

            var userEntity = await userRepository.GetAsync(c => c.user_id.Equals(id));
            if (userEntity == null)
            {
                return new BaseResult<UserEntity>(202);
            }
            return new BaseResult<UserEntity>(200, userEntity);
        }

        public async Task<BaseResult<UserDepartRoleInfo>> getInnerById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<UserDepartRoleInfo>(808);
            }

            int total = 0;
            IQueryable<UserDepartRoleInfo> user_dept_role = await userRepository.getLeftJoinDepRole(c => c.user_id.Equals(id),
              0, 1, out total);
            return new BaseResult<UserDepartRoleInfo>(200, user_dept_role.FirstOrDefault());
        }

        public async Task<IQueryable<UserEntity>> GetTeamUserInfo()
        {
            var userEntity = (from n in await userRepository.GetAllAsync(c => c.source_type == 2 && c.full_name != "admin")
                              select new UserEntity
                              {
                                  user_image = n.user_image,
                                  user_name = n.user_name,
                                  full_name = n.full_name,
                                  user_code = n.user_code,
                                  createtime = n.createtime
                              }).OrderBy(c => c.createtime);
            return userEntity;
        }

        public async Task<BaseResult<bool>> checkData(string user_id, string content)
        {
            //这里可以用手机号以及电话号码和邮箱登录，判断是否重复
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            where = RegexUtil.Email(content) ? where.AndAlso(c => c.user_email == content)
                : where.AndAlso(c => c.user_phone == content);

            where = where.AndAlso(c => c.user_id != user_id);

            int count = await userRepository.CountAsync(where);
            if (count > 0)
            {
                return new BaseResult<bool>(900, true);
            }
            return new BaseResult<bool>(200, false);
        }

        public async Task<BaseResult<bool>> AddAdmin(UserAdminInfo userAdminInfo)
        {
            //判断数据库中有没有邮箱(user_email)和电话(user_phone)，如果存在则不能添加，提示错误
            int count = await userRepository.CountAsync(c => c.user_email == userAdminInfo.user_email || c.user_phone == userAdminInfo.user_phone);
            if (count >= 1)
            {
                return new BaseResult<bool>(1003, false);
            }

            //同步添加三个数据库 User和UserInfo和部门表
            UserEntity userEntity = new UserEntity();
            userEntity.user_pwd = CommonUtil.Md5(userAdminInfo.user_pwd);
            userEntity.user_name = userAdminInfo.user_name;
            userEntity.full_name = userAdminInfo.full_name;
            userEntity.user_code = CommonUtil.ReadRandom("#", 4, 9);
            userEntity.user_email = userAdminInfo.user_email;
            userEntity.user_phone = userAdminInfo.user_phone;
            userEntity.user_gender = userAdminInfo.user_gender;
            userEntity.user_ip = httpContextUtil.getRemoteIp();
            userEntity.source_type = (int)SourceStatus.admin;
            //todo 不知道为什么访问始终有问题，不能添加新的
            userEntity.user_activation = (int)DisableStatus.disable_false;
            userEntity.user_visit = (int)DisableStatus.disable_false;

            UserInfoEntity userInfoEntity = new UserInfoEntity();
            userInfoEntity.user_id = userEntity.user_id;

            var isUserTrue = await userRepository.AddAsync(userEntity, false);
            var isUserInfoTrue = await userInfoRepository.AddAsync(userInfoEntity, false);
            if (userAdminInfo.department_id.Count > 0)
            {
                List<UserDepartmentEntity> userDepartmentEntitys = new List<UserDepartmentEntity>();
                foreach (string deparmentId in userAdminInfo.department_id)
                {
                    if (deparmentId != null)
                    {
                        UserDepartmentEntity userDepartmentEntity = new UserDepartmentEntity();
                        userDepartmentEntity.user_id = userEntity.user_id;
                        userDepartmentEntity.department_id = deparmentId;
                        userDepartmentEntitys.Add(userDepartmentEntity);
                    }
                }
                var isUserDepartmentTrue = await userDepartmentRepository.AddListAsync(userDepartmentEntitys, false);
            }
            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        /// <summary>
        /// 添加微信用户
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public async Task<BaseResult<DropDownList>> AddWexinUser(UserEntity userEntity, UserInfoEntity userInfoEntity)
        {
            //判断数据库中有没有微信用户注册信息
            var user = await userRepository.GetAsync(c => c.user_code == userEntity.user_code);
            if (user != null && !string.IsNullOrEmpty(user.user_id))
            {
                //增加cookie
                //用户登录正常，修改用户登录时间并且将登录的信息保存到Session中
                await userRepository.UpdateAsync(new UserEntity() { user_id = userEntity.user_id, last_time = DateTime.Now }, false, true, c => c.last_time);

                //处理信息，如果redis连接成功，则直接判断是否存在值，如果存在，则直接使用，否则直接查询并且保存，如果连接失败，则直接查询
                UserSession userSession = new UserSession
                {
                    user_id = userEntity.user_id,
                    user_name = userEntity.user_name + userEntity.user_code,
                    user_image = userEntity.user_image,
                    full_name = userEntity.full_name,
                    action_url = null
                };
                httpContextUtil.setObjectAsJson(KeyUtil.user_info_front, userSession);
                return new BaseResult<DropDownList>(200, null);
            }
            //同步添加三个数据库 User和UserInfo以及角色用户表--完善用户信息
            userEntity.user_ip = httpContextUtil.getRemoteIp();
            userEntity.source_type = (int)SourceStatus.front;

            var userRole = await roleRepository.GetAsync(c => c.role_type == (int)RoleType.Front);
            if (userRole != null)
            {
                var isUserRoleTrue = await userRoleRepository.AddAsync(new UserRoleEntity()
                {
                    user_id = userEntity.user_id,
                    role_id = userRole.role_id
                }, false);
            }
            var isUserTrue = await userRepository.AddAsync(userEntity, false);
            var isUserInfoTrue = await userInfoRepository.AddAsync(userInfoEntity, false);
            if (unitOfWork.SaveCommit())
            {
                //增加cookie
                //用户登录正常，修改用户登录时间并且将登录的信息保存到Session中
                await userRepository.UpdateAsync(new UserEntity() { user_id = userEntity.user_id, last_time = DateTime.Now }, false, true, c => c.last_time);

                //处理信息，如果redis连接成功，则直接判断是否存在值，如果存在，则直接使用，否则直接查询并且保存，如果连接失败，则直接查询
                UserSession userSession = new UserSession
                {
                    user_id = userEntity.user_id,
                    user_name = userEntity.user_name + userEntity.user_code,
                    user_image = userEntity.user_image,
                    full_name = userEntity.full_name,
                    action_url = null
                };
                httpContextUtil.setObjectAsJson(KeyUtil.user_info_front, userSession);
                return new BaseResult<DropDownList>(200, null);
            }
            return new BaseResult<DropDownList>(201, null);
        }

        public async Task<BaseResult<DropDownList>> Add(UserEntity userEntity)
        {
            //判断数据库中有没有邮箱(user_email)和电话(user_phone)，如果存在则不能添加，提示错误
            int count = await userRepository.CountAsync(c => c.user_email == userEntity.user_email || c.user_phone == userEntity.user_phone);
            if (count >= 1)
            {
                return new BaseResult<DropDownList>(1003, null);
            }

            //同步添加三个数据库 User和UserInfo以及角色用户表--完善用户信息
            userEntity.user_pwd = CommonUtil.Md5(userEntity.user_pwd);
            userEntity.user_name = CommonUtil.AZReadRandom(6);
            userEntity.user_code = CommonUtil.ReadRandom("#", 4, 9);
            userEntity.user_ip = httpContextUtil.getRemoteIp();
            userEntity.source_type = (int)SourceStatus.front;
            userEntity.user_gender = (int)GenderStatus.mystery;

            UserInfoEntity userInfoEntity = new UserInfoEntity();
            userInfoEntity.user_id = userEntity.user_id;

            var userRole = await roleRepository.GetAsync(c => c.role_type == (int)RoleType.Front);
            if (userRole != null)
            {
                var isUserRoleTrue = await userRoleRepository.AddAsync(new UserRoleEntity()
                {
                    user_id = userEntity.user_id,
                    role_id = userRole.role_id
                }, false);
            }
            var isUserTrue = await userRepository.AddAsync(userEntity, false);
            var isUserInfoTrue = await userInfoRepository.AddAsync(userInfoEntity, false);
            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<DropDownList>(200, new DropDownList()
                {
                    name = userEntity.user_id,
                    value = userEntity.user_email
                });
            }
            return new BaseResult<DropDownList>(201, null);
        }

        public async Task<BaseResult<bool>> UpdateUserName(string user_id, string user_name, string user_email, SendMailConfig sendMailConfig, string host_url)
        {
            if (string.IsNullOrEmpty(user_id) || string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(user_email))
            {
                return new BaseResult<bool>(808, false);
            }
            string md5 = CommonUtil.Md5(user_id + user_email);
            string http_url = "http://" + host_url + "/Login/Activation?key=" + md5 + "&user_id=" + user_id;

            var isEmailTrue = await EmailUtil.SendEmailAsync(user_email, string.Format(EmailKeyUtil.send_user_activation_title, user_email),
                 string.Format(EmailKeyUtil.send_user_activation_content, user_email, http_url, http_url, http_url),
             sendMailConfig, "h");
            if (isEmailTrue)
            {
                var isTrue = await userRepository.UpdateAsync(new UserEntity() { user_id = user_id, user_name = user_name }, true, true, c => c.user_name);
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> Activation(string user_id, string key)
        {
            //首先根据传递的用户id查询用户信息，如果没有查询到则直接报错
            var userEntity = await userRepository.GetAsync(c => c.user_id.Equals(user_id));

            //验证是否为空、激活不允许在激活、对比时间不能超过2日天、邮箱key对比
            if (userEntity == null)
            {
                return new BaseResult<bool>(202);
            }
            if (userEntity.user_activation == (int)DisableStatus.disable_false)
            {
                return new BaseResult<bool>(1011);
            }
            TimeSpan ts = DateTime.Now - userEntity.createtime;
            if (ts.Days > 2)
            {
                return new BaseResult<bool>(1009);
            }
            if (key != CommonUtil.Md5(user_id + userEntity.user_email))
            {
                return new BaseResult<bool>(1010);
            }

            //发送请求激活
            var isTrue = await userRepository.UpdateAsync(new UserEntity() { user_id = user_id, user_activation = (int)DisableStatus.disable_false }, true, true, c => c.user_activation);
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> UpdateAdmin(UserAdminInfo userAdminInfo, string user_id)
        {
            //逻辑：登录的用户如果=admin，则可以修改admin，否则不能修改admin
            if (userAdminInfo.user_id.Equals("66dbea2b41dd47a1a81eef2e5dc2af0e"))
            {
                if (!user_id.Equals("66dbea2b41dd47a1a81eef2e5dc2af0e"))
                {
                    return new BaseResult<bool>(1007, false);
                }
            }

            //判断数据库中有没有用户名(login_name)邮箱(user_email)和电话(user_phone)，如果存在则不能添加，提示错误
            int count = await userRepository.CountAsync(c => c.user_id != userAdminInfo.user_id && (c.user_email == userAdminInfo.user_email || c.user_phone == userAdminInfo.user_phone));
            if (count >= 1)
            {
                return new BaseResult<bool>(1003, false);
            }

            //同步修改两个数据库，用户表和用户部门表
            UserEntity userEntity = new UserEntity();
            userEntity.user_id = userAdminInfo.user_id;
            userEntity.user_name = userAdminInfo.user_name;
            userEntity.full_name = userAdminInfo.full_name;
            userEntity.user_email = userAdminInfo.user_email;
            userEntity.user_phone = userAdminInfo.user_phone;
            userEntity.user_gender = userAdminInfo.user_gender;
            var isTrue = await userRepository.UpdateAsync(userEntity, false, true, c => c.user_name, c => c.full_name, c => c.user_email, c => c.user_phone, c => c.user_gender);

            //先根据用户Id删除用户部门表里面所有的用户信息然后再添加
            var isDeleteUserDetrue = await userDepartmentRepository.DeleteByUserId(userAdminInfo.user_id);
            if (userAdminInfo.department_id.Count > 0)
            {
                List<UserDepartmentEntity> userDepartmentEntitys = new List<UserDepartmentEntity>();
                foreach (string deparmentId in userAdminInfo.department_id)
                {
                    if (deparmentId != null)
                    {
                        UserDepartmentEntity userDepartmentEntity = new UserDepartmentEntity();
                        userDepartmentEntity.user_id = userEntity.user_id;
                        userDepartmentEntity.department_id = deparmentId;
                        userDepartmentEntitys.Add(userDepartmentEntity);
                    }
                }
                var isUserDepartmentTrue = await userDepartmentRepository.AddListAsync(userDepartmentEntitys, false);
            }
            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> UpdateUserFront(UserEntity userEntity)
        {
            //判断数据库中有没有用户名(login_name)邮箱(user_email)和电话(user_phone)，如果存在则不能添加，提示错误
            int count = await userRepository.CountAsync(c => c.user_id != userEntity.user_id && c.user_phone == userEntity.user_phone);
            if (count >= 1)
            {
                return new BaseResult<bool>(1003, false);
            }
            var isTrue = await userRepository.UpdateAsync(userEntity, true, true, c => c.user_name, c => c.user_phone, c => c.user_gender, c => c.full_name);
            return new BaseResult<bool>(200, true);
        }

        public BaseResult<string> UploadUserImage(IFormFileCollection files)
        {
            int result_number = 0;
            //var return_result = FileUtil.UploadQiniuImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, Settings.UserImagePrefix, out result_number);
            //阿里云
            var return_result = OssOptionUtil.UploadAliYunImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, out result_number);
            if (string.IsNullOrEmpty(return_result))
            {
                return new BaseResult<string>(result_number);
            }
            return new BaseResult<string>(return_result);
        }

        public async Task<BaseResult<bool>> UpdateUserImage(string user_id, string image_url)
        {
            var isTrue = await userRepository.UpdateAsync(new UserEntity() { user_id = user_id, user_image = image_url }, true, true, c => c.user_image);
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string user_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(user_id))
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            UserEntity userEntity = await userRepository.GetAsync(c => c.user_id.Equals(user_id));
            if (string.IsNullOrEmpty(userEntity.disabledesc))
            {
                str = "{'disable':'" + userEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = userEntity.disabledesc + ",{'disable':'" + userEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            UserEntity department = new UserEntity()
            {
                user_id = user_id,
                disabledesc = str,
                disable = type
            };
            var isTrue = await userRepository.UpdateAsync(department, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> UpdateSetRole(string user_id, List<string> role_ids)
        {
            try
            {
                //首先删除掉所有用户的角色信息然后再添加
                var isDeleteUserDetrue = await userRoleRepository.DeleteByUserId(user_id);
                if (role_ids.Count > 0)
                {
                    List<UserRoleEntity> userRoleEntitys = new List<UserRoleEntity>();
                    foreach (string role_id in role_ids)
                    {
                        UserRoleEntity userRoleEntity = new UserRoleEntity();
                        userRoleEntity.user_id = user_id;
                        userRoleEntity.role_id = role_id;
                        userRoleEntitys.Add(userRoleEntity);
                    }
                    var isUserDepartmentTrue = await userRoleRepository.AddListAsync(userRoleEntitys, false);
                    if (unitOfWork.SaveCommit())
                    {
                        return new BaseResult<bool>(200, true);
                    }
                }
                return new BaseResult<bool>(200, true);
            }
            catch (Exception)
            {
                return new BaseResult<bool>(201, false);
            }

        }

        public async Task<BaseResult<bool>> Delete(string user_id)
        {
            //admin用户不能删除
            if (user_id.Equals("66dbea2b41dd47a1a81eef2e5dc2af0e"))
            {
                return new BaseResult<bool>(1008, false);
            }

            //删除：删除用户表、用户详情表、用户权限表、用户角色表
            try
            {
                await userRepository.DeleteAsync(new UserEntity { user_id = user_id }, false);
                await userInfoRepository.DeleteByUserId(user_id);
                await userRoleRepository.DeleteByUserId(user_id);
                await userDepartmentRepository.DeleteByUserId(user_id);

                if (unitOfWork.SaveCommit())
                {
                    return new BaseResult<bool>(200, true);
                }
                return new BaseResult<bool>(200, false);
            }
            catch (Exception)
            {
                return new BaseResult<bool>(201, false);
            }
        }

        public async Task<BaseResult<bool>> Activate(string user_id)
        {
            if (string.IsNullOrEmpty(user_id))
            {
                return new BaseResult<bool>(808);
            }
            var isTrue = await userRepository.UpdateAsync(new UserEntity { user_id = user_id, user_activation = 0 }, true, true, c => c.user_activation);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Visit(string user_id)
        {
            if (string.IsNullOrEmpty(user_id))
            {
                return new BaseResult<bool>(808);
            }
            var isTrue = await userRepository.UpdateAsync(new UserEntity { user_id = user_id, user_visit = 0 }, true, true, c => c.user_visit);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<Pager<IQueryable<UserSession>>> GetUserInfo()
        {
            //查询当天所有的用户信息
            var count = await userRepository.CountAsync(c => c.disable == 0);
            var userinfo = (from n in await userRepository.GetAllAsync(c => c.disable == 0 && c.createtime > DateTime.Now.Date)
                            select new UserSession
                            {
                                user_id = n.user_id,
                                user_name = n.user_name + n.user_code,
                                create_time = n.createtime
                            }).OrderByDescending(c => c.create_time);

            return new Pager<IQueryable<UserSession>>(count, userinfo);
        }

        public Task<List<MenuActionInfo>> GetMenuInfo(string user_id)
        {
            //第一步：查询所有为0的左边菜单栏
            List<ButtionActionInfo> left_side_parents = buttonActionRepository.GetMenuInfo(user_id,
                c => c.action_type == (int)ActionType.adminleft && c.disable == (int)DisableStatus.disable_false && c.action_parentid == "0").ToList();

            //第二步：处理第一步的结果并且返回集合
            List<MenuActionInfo> result_bank = left_side_parents.Select(c => new MenuActionInfo()
            {
                action_id = c.action_id,
                action_name = c.action_name,
                action_url = c.action_url,
                action_icon = c.action_icon,
                action_newaction = c.action_newaction,
                menuActionInfo = GetMenuInfoChild(user_id, c.action_id)
            }).ToList();

            return Task.Run(() => result_bank.ToList());
        }

        public List<MenuActionInfo> GetMenuInfoChild(string user_id, string action_id)
        {
            //第一步：查询所有为含有父Id的左边菜单栏
            List<ButtionActionInfo> left_side_childrens = buttonActionRepository.GetMenuInfo(user_id,
                c => c.action_type == (int)ActionType.adminleft && c.disable == (int)DisableStatus.disable_false && c.action_parentid == action_id).ToList();

            //第二步：处理第一步的结果并且返回集合
            List<MenuActionInfo> result_bank_child = null;
            if (left_side_childrens.Any())
            {
                result_bank_child = left_side_childrens.Select(c => new MenuActionInfo()
                {
                    action_id = c.action_id,
                    action_name = c.action_name,
                    action_url = c.action_url,
                    action_icon = c.action_icon,
                    action_newaction = c.action_newaction,
                    menuActionInfo = GetMenuInfoChild(user_id, c.action_id)
                }).ToList();
            }
            return result_bank_child == null ? null : result_bank_child.ToList();
        }

        public Task<IQueryable<ButtionActionInfo>> getButtionInfo(string user_id, string current_url)
        {
            //TODO 根据current_url查询父Id存放 这里可以优化
            string parentId = buttonActionRepository.GetAsync(c => c.action_url.ToLower() == current_url.ToLower()).Result.action_id;
            IQueryable<ButtionActionInfo> buttionAction = buttonActionRepository.GetMenuInfo(user_id,
                c => c.action_type == (int)ActionType.general && c.action_parentid == parentId && c.disable == (int)DisableStatus.disable_false);

            return Task.Run(() => buttionAction);
        }

        public async Task<BaseResult<bool>> UpdatePassword(string user_id, string passwordOld, string passwordNew)
        {
            if (string.IsNullOrEmpty(user_id))
            {
                return new BaseResult<bool>(808);
            }

            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            where = where.AndAlso(c => c.user_id == user_id);
            where = where.AndAlso(c => c.user_pwd == CommonUtil.Md5(passwordOld) && c.disable != 1);

            UserEntity userEntity = await userRepository.GetAsync(where);
            if (userEntity == null)
            {
                return new BaseResult<bool>(1002, false);
            }

            UserEntity userEntityUpdate = new UserEntity()
            {
                user_id = user_id,
                user_pwd = CommonUtil.Md5(passwordNew)
            };
            var isTrue = await userRepository.UpdateAsync(userEntityUpdate, true, true, u => u.user_pwd);
            if (isTrue)
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }
    }
}