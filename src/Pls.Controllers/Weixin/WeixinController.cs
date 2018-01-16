using System;
using System.Collections.Generic;
using System.Text;
using Pls.Utils;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using Pls.Plug.Weixin;
using Senparc.Weixin.MP.Containers;

namespace Pls.Controllers.Weixin
{
    [Area("Weixin")]
    public class WeixinController : BaseController
    {
        public WeixinController(ApplicationConfigServices _applicationConfigServices) : base(_applicationConfigServices)
        {
        }

        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        public IActionResult Index(PostModel postModel, string echostr)
        {
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, WeixinConfig.Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + postModel.Signature + "," + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, WeixinConfig.Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        /// <summary>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// PS：此方法为简化方法，效果与OldPost一致。
        /// v0.8之后的版本可以结合Senparc.Weixin.MP.MvcExtension扩展包，使用WeixinResult，见MiniPost方法。
        /// </summary>
        [HttpPost]
        public ActionResult Index(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, WeixinConfig.Token))
            {
                return Content("参数错误！");
            }

            postModel.Token = WeixinConfig.Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = WeixinConfig.EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = WeixinConfig.AppId;//根据自己后台的设置保持一致

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new CustomMessageHandler(Request.Body, postModel);//接收消息

            messageHandler.OmitRepeatedMessage = true;//启用消息去重功能
            
            messageHandler.Execute();//执行微信处理过程
            return Content(messageHandler.FinalResponseDocument.ToString());//返回结果
            
        }
    }
}
