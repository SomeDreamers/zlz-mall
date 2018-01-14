//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Utils/SystemUtil 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils.resource;

namespace Pls.Utils
{
    /// <summary>
    /// 封装Messages_CN资源文件,使其改动就能够处理语言信息
    /// </summary>
    public static class SystemUtil
    {
        /// <summary>
        /// 根据statuscode返回查询到的汉字信息并且提交给前台
        /// </summary>
        /// <param name="statuscode">标识符</param>
        /// <returns></returns>
        public static string getMessage(int statuscode)
        {
            string result = Messages_CN.OK;
            switch (statuscode)
            {
                //系统错误(1000以内)
                case 200:
                    result = Messages_CN.OK;
                    break;
                case 201:
                    result = Messages_CN.Error;
                    break;
                case 202:
                    result = Messages_CN.Empty;
                    break;
                case 400:
                    result = Messages_CN.NoAddress;
                    break;
                case 500:
                    result = Messages_CN.ServerData;
                    break;
                case 301:
                    result = Messages_CN.NoLogin;
                    break;
                case 800:
                    result = Messages_CN.ParaError;
                    break;
                case 801:
                    result = Messages_CN.PortError;
                    break;
                case 802:
                    result = Messages_CN.ReadError;
                    break;
                case 803:
                    result = Messages_CN.NoError;
                    break;
                case 808:
                    result = Messages_CN.ParaEmpty;
                    break;
                case 900:
                    result = Messages_CN.AlreadyExists;
                    break;
                case 901:
                    result = Messages_CN.ExistsRelation;
                    break;
                case 902:
                    result = Messages_CN.ImageNo;
                    break;
                case 903:
                    result = Messages_CN.AlreadyDisable;
                    break;


                //用户管理(1000-2000以内)
                case 1000:
                    result = Messages_CN.UserPwdNoError;
                    break;
                case 1001:
                    result = Messages_CN.TypeAlreadyExists;
                    break;
                case 1002:
                    result = Messages_CN.OldPwdError;
                    break;
                case 1003:
                    result = Messages_CN.LoginNameEmailPhoneYes;
                    break;
                case 1004:
                    result = Messages_CN.NoDisable;
                    break;
                case 1005:
                    result = Messages_CN.NoActivation;
                    break;
                case 1006:
                    result = Messages_CN.NoVisit;
                    break;
                case 1007:
                    result = Messages_CN.NoAdmin;
                    break;
                case 1008:
                    result = Messages_CN.DeleteAdmin;
                    break;
                case 1009:
                    result = Messages_CN.ActivationOvertime;
                    break;
                case 1010:
                    result = Messages_CN.KeyNoError;
                    break;
                case 1011:
                    result = Messages_CN.EmailActivation;
                    break;
                case 1012:
                    result = Messages_CN.YesHandle;
                    break;

                //商品管理(3000-4000以内)
                case 3000:
                    result = Messages_CN.ShopImageMax;
                    break;
                case 3001:
                    result = Messages_CN.ShopImageExtion;
                    break;
                case 3002:
                    result = Messages_CN.YesSetAttrForShop;
                    break;
                case 3003:
                    result = Messages_CN.CouponYesOne;
                    break;
                case 3004:
                    result = Messages_CN.ShopSkuImageYesThree;
                    break;
                case 3005:
                    result = Messages_CN.ShopCurrentMaxOriginal;
                    break;
                case 3006:
                    result = Messages_CN.NoSetShopSku;
                    break;
                case 3007:
                    result = Messages_CN.ShopCouponMaxCurrentMoney;
                    break;

                //订单管理5000-5999
                case 5000:
                    result = Messages_CN.OrderAlreadyDisable;
                    break;
                case 5001:
                    result = Messages_CN.OrderAlreadyDelete;
                    break;
                case 5002:
                    result = Messages_CN.OrderAlreadyPay;
                    break;
                case 5003:
                    result = Messages_CN.OrderAlreadySend;
                    break;
                case 5004:
                    result = Messages_CN.UpgradeError;
                    break;
                default:
                    result = Messages_CN.NoError;
                    break;


            }
            return result;
        }
    }
}