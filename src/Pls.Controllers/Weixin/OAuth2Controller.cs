using System;
using System.Collections.Generic;
using System.Text;
using Pls.Utils;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using Pls.Controllers.filter;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin;
using Pls.IService;
using Pls.Entity;
using System.Threading.Tasks;

namespace Pls.Controllers.Weixin
{
    [Area("Weixin")]
    public class OAuth2Controller : BaseController
    {
        public IUserService userService { get; private set; }
        public OAuth2Controller(ApplicationConfigServices _applicationConfigServices, IUserService _userService) : base(_applicationConfigServices)
        {
            userService = _userService;
        }

        /// <summary>
        /// 认证授权
        /// </summary>
        /// <param name="returnUrl">用户尝试进入的需要登录的页面</param>
        /// <returns></returns>
        public ActionResult Index(string returnUrl)
        {
            var state = "JeffreySu-" + DateTime.Now.Millisecond;//随机数，用于识别请求可靠性
            HttpContext.Session.Set("state", state) ;//储存随机数到Session

            ViewData["returnUrl"] = returnUrl;

            //此页面引导用户点击授权
            ViewData["UrlUserInfo"] =
                OAuthApi.GetAuthorizeUrl(WeixinConfig.AppId,
                "http://sdk.weixin.senparc.com/oauth2/UserInfoCallback?returnUrl=" + returnUrl.UrlEncode(),
                state, OAuthScope.snsapi_userinfo);
            ViewData["UrlBase"] =
                OAuthApi.GetAuthorizeUrl(WeixinConfig.AppId,
                "http://sdk.weixin.senparc.com/oauth2/BaseCallback?returnUrl=" + returnUrl.UrlEncode(),
                state, OAuthScope.snsapi_base);
            return View();
        }

        /// <summary>
        /// OAuthScope.snsapi_userinfo方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl">用户最初尝试进入的页面</param>
        /// <returns></returns>
        public async Task<ActionResult> UserInfoCallbackAsync(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != HttpContext.Session.Get<string>("state"))
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                //建议用完之后就清空，将其一次性使用
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            OAuthAccessTokenResult result = null;

            //通过，用code换取access_token
            try
            {
                result = OAuthApi.GetAccessToken(WeixinConfig.AppId, WeixinConfig.AppSecret, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }
            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            //Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            //Session["OAuthAccessToken"] = result;

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
            try
            {
                OAuthUserInfo wxUserInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                //验证通过注册用户信息
                UserEntity user = new UserEntity
                {
                    user_code = wxUserInfo.openid,
                    user_name = wxUserInfo.nickname,
                    user_gender = wxUserInfo.sex,
                    user_image = wxUserInfo.headimgurl
                };

                UserInfoEntity userInfo = new UserInfoEntity
                {
                    user_id = user.user_id,
                    country = wxUserInfo.country,
                    province = wxUserInfo.province,
                    city = wxUserInfo.city,

                };
                await userService.AddWexinUser(user, userInfo);

                //跳转连接
                return Redirect(string.IsNullOrEmpty(returnUrl) ? WeixinConfig.WeixinHomeUrl : returnUrl);
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// OAuthScope.snsapi_base方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl">用户最初尝试进入的页面</param>
        /// <returns></returns>
        public async Task<ActionResult> BaseCallback(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != HttpContext.Session.Get<string>("State"))
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                //建议用完之后就清空，将其一次性使用
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            //通过，用code换取access_token
            var result = OAuthApi.GetAccessToken(WeixinConfig.AppId, WeixinConfig.AppSecret, code);
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            //Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            //Session["OAuthAccessToken"] = result;

            //因为这里还不确定用户是否关注本微信，所以只能试探性地获取一下
            OAuthUserInfo wxUserInfo = null;
            try
            {
                //已关注，可以得到详细信息
                wxUserInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);

                //验证通过注册用户信息
                UserEntity user = new UserEntity
                {
                    user_code = wxUserInfo.openid,
                    user_name = wxUserInfo.nickname,
                    user_gender = wxUserInfo.sex,
                    user_image = wxUserInfo.headimgurl
                };

                UserInfoEntity userInfo = new UserInfoEntity
                {
                    user_id = user.user_id,
                    country = wxUserInfo.country,
                    province = wxUserInfo.province,
                    city = wxUserInfo.city,
                    
                };
                await userService.AddWexinUser(user, userInfo);

                //跳转连接
                return Redirect(string.IsNullOrEmpty(returnUrl)? WeixinConfig.WeixinHomeUrl: returnUrl);

            }
            catch (ErrorJsonResultException ex)
            {
                //未关注，只能授权，无法得到详细信息
                //这里的 ex.JsonResult 可能为："{\"errcode\":40003,\"errmsg\":\"invalid openid\"}"
                return Content("用户已授权，授权Token：" + result);
            }
        }
    }
}
