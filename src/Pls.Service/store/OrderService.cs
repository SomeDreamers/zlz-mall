//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Service/OrderService 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/23 23:53:19
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using Pls.IRepository;
using Pls.IService;
using Pls.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pls.UnitOfWork;
using System.Text;
using Pls.Entity.response;

namespace Pls.Service
{
    /// <summary>
    /// 订单管理逻辑实现
    /// </summary>
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository { get; set; }
        private IOrderDetailRepository orderDetailRepository { get; set; }
        private IShopSkuRepository shopSkuRepository { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        private IUserRepository userRepository { get; set; }
        private IShopCouponRepository shopCouponRepository { get; set; }
        private IShopRepository shopRepository { get; set; }
        public OrderService(IOrderRepository _orderRepository, IShopSkuRepository _shopSkuRepository, IOrderDetailRepository _orderDetailRepository, IUnitOfWork _unitOfWork,
            IUserRepository _userRepository, IShopCouponRepository _shopCouponRepository, IShopRepository _shopRepository)
        {
            orderRepository = _orderRepository;
            shopSkuRepository = _shopSkuRepository;
            orderDetailRepository = _orderDetailRepository;
            unitOfWork = _unitOfWork;
            userRepository = _userRepository;
            shopCouponRepository = _shopCouponRepository;
            shopRepository = _shopRepository;
        }

        public async Task<Pager<IQueryable<UserOrderInfo>>> List(OrderInfo orderInfo)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<UserEntity, bool>> user_search = LinqUtil.True<UserEntity>();
            Expression<Func<OrderEntity, bool>> order_search = LinqUtil.True<OrderEntity>();

            user_search.AndAlso(c => c.disable == 0);
            if (!string.IsNullOrEmpty(orderInfo.user_email))
            {
                user_search = user_search.AndAlso(c => c.user_email.Contains(orderInfo.user_email));
            }
            if (!string.IsNullOrEmpty(orderInfo.order_number))
            {
                order_search = order_search.AndAlso(c => c.order_number.Contains(orderInfo.order_number));
            }
            if (orderInfo.order_paystatus != -1)
            {
                order_search = order_search.AndAlso(c => c.order_paystatus == orderInfo.order_paystatus);
            }
            if (orderInfo.disable != -1)
            {
                order_search = order_search.AndAlso(c => c.disable == orderInfo.disable);
            }
            int pageindex = orderInfo.pageindex;

            //异步读取总数
            int total = await orderRepository.CountAsync(order_search);

            IQueryable<UserOrderInfo> query = (from o in await orderRepository.GetAllAsync(order_search)
                                               join u in await userRepository.GetAllAsync(user_search) on o.user_id equals u.user_id
                                               orderby o.createtime descending
                                               select new UserOrderInfo()
                                               {
                                                   order_id = o.order_id,
                                                   order_number = o.order_number,
                                                   order_total = o.order_total,
                                                   order_privilege = o.order_privilege,
                                                   order_actualpay = o.order_actualpay,
                                                   order_paystatus = o.order_paystatus,
                                                   order_payway = o.order_payway,
                                                   order_goods = o.order_goods,
                                                   order_delete = o.order_delete,
                                                   createtime = o.createtime,
                                                   disable = o.disable,
                                                   user_email = u.user_email
                                               }).Skip((--pageindex * orderInfo.pagesize)).Take(orderInfo.pagesize);
            return new Pager<IQueryable<UserOrderInfo>>(total, query);
        }

        public async Task<BaseResult<UserOrderInfo>> GetOrderById(string id)
        {
            UserOrderInfo query = (from o in await orderRepository.GetAllAsync(c => c.order_id == id)
                                   join u in await userRepository.GetAllAsync() on o.user_id equals u.user_id
                                   select new UserOrderInfo()
                                   {
                                       order_id = o.order_id,
                                       order_number = o.order_number,
                                       order_total = o.order_total,
                                       order_privilege = o.order_privilege,
                                       order_actualpay = o.order_actualpay,
                                       order_paystatus = o.order_paystatus,
                                       order_goods = o.order_goods,
                                       order_payway = o.order_payway,
                                       order_delete = o.order_delete,
                                       createtime = o.createtime,
                                       disable = o.disable,
                                       user_email = u.user_email,
                                       order_memo = o.order_memo,
                                       disabledesc = o.disabledesc,
                                   }).FirstOrDefault();
            var orderdetailinfo = from o in await orderDetailRepository.GetAllAsync(c => c.order_id == id)
                                  join s in await shopRepository.GetAllAsync() on o.shop_id equals s.shop_id
                                  join k in await shopSkuRepository.GetAllAsync() on o.shopsku_id equals k.shopsku_id
                                  select new OrderDetailInfo()
                                  {
                                      orderdetail_id = o.orderdetail_id,
                                      shop_id = s.shop_id,
                                      shopsku_id = k.shopsku_id,
                                      shop_currentprice = o.shop_currentprice,
                                      shop_count = o.shop_count,
                                      shop_name = s.shop_name,
                                      shop_number = s.shop_number,
                                      shop_code = k.shop_code,
                                      shopsku_originalprice = k.shopsku_originalprice,
                                      shop_defaultimg = s.shop_defaultimg
                                  };
            query.orderdetailinfo = orderdetailinfo;

            return new BaseResult<UserOrderInfo>(200, query);
        }

        public async Task<IQueryable<OrderPay>> getOrderPay(string id, string user_id)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<OrderPay, bool>> where_search = LinqUtil.True<OrderPay>();
            if (!string.IsNullOrEmpty(id))
            {
                where_search = where_search.AndAlso(c => c.order_id == id).AndAlso(c => c.user_id == user_id).AndAlso(c => c.order_delete == 1)
                    .AndAlso(c => c.order_goods == 1).AndAlso(c => c.order_paystatus == 1);
            }
            var data = await orderRepository.GetOrderPay(where_search);
            return data;
        }

        public async Task<Pager<IQueryable<OrderPay>>> OrderListByUserId(string user_id, int type, string order_id = "0")
        {
            //判断查询参数（组装查询条件）
            Expression<Func<OrderPay, bool>> where_search = LinqUtil.True<OrderPay>();
            where_search = where_search.AndAlso(c => c.user_id == user_id);
            if (type == 1)
            {
                where_search = where_search.AndAlso(c => c.order_delete == 1).AndAlso(c => c.orderdetail_delete == 1);
            }
            if (type == 2)
            {
                where_search = where_search.AndAlso(c => c.order_delete == 1).AndAlso(c => c.orderdetail_delete == 1).AndAlso(c => c.order_paystatus == 1);
            }
            if (type == 3)
            {
                where_search = where_search.AndAlso(c => c.order_delete == 1).AndAlso(c => c.orderdetail_delete == 1).AndAlso(c => c.order_goods == 2);
            }
            if (type == 4)
            {
                where_search = where_search.AndAlso(c => c.order_delete == 1).AndAlso(c => c.orderdetail_delete == 1).AndAlso(c => c.order_id == order_id);
            }
            var data = await orderRepository.OrderListInfo(where_search);
            return new Pager<IQueryable<OrderPay>>(data.Count(), data);
        }

        public async Task<OrderPay> OrderInfoByShopSkuId(string user_id, string order_id, string shopsku_id)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<OrderPay, bool>> where_search = LinqUtil.True<OrderPay>();
            where_search = where_search.AndAlso(c => c.user_id == user_id).AndAlso(c => c.order_delete == 1).AndAlso(c => c.orderdetail_delete == 1)
                .AndAlso(c => c.order_id == order_id).AndAlso(c => c.shopsku_id == shopsku_id);

            var data = await orderRepository.OrderListInfo(where_search);
            return data.FirstOrDefault();
        }

        public async Task<BaseResult<IQueryable<DropDownList>>> ShopskuList(string shop_id)
        {
            if (string.IsNullOrEmpty(shop_id))
            {
                return new BaseResult<IQueryable<DropDownList>>(808, null);
            }

            IQueryable<DropDownList> dropdownlist = (from shop in await shopSkuRepository.GetAllAsync(c => c.shop_id == shop_id)
                                                     orderby shop.createtime
                                                     select new DropDownList()
                                                     {
                                                         name = shop.shop_code,
                                                         value = shop.shopsku_id
                                                     });
            return new BaseResult<IQueryable<DropDownList>>(200, dropdownlist);
        }

        public async Task<BaseResult<string>> ShopMoneyBySkuId(string shopsku_id, string check_shopsku_id)
        {
            if (string.IsNullOrEmpty(shopsku_id) || string.IsNullOrEmpty(check_shopsku_id))
            {
                return new BaseResult<string>(808, null);
            }
            var check_data = await shopSkuRepository.GetAsync(c => c.shopsku_id == check_shopsku_id);   //新选择的价钱
            var data = await shopSkuRepository.GetAsync(c => c.shopsku_id == shopsku_id);  //原始的商品价钱

            decimal money = Convert.ToDecimal(check_data.shopsku_currentprice) - Convert.ToDecimal(data.shopsku_currentprice);
            return new BaseResult<string>(200, money.ToString());
        }

        public async Task<BaseResult<string>> AddOrder(List<CartOrders> orders, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new BaseResult<string>(301);
            }

            //组装订单主子表实体
            OrderEntity orderEntity = new OrderEntity();
            List<OrderDetailEntity> orderDetails = new List<OrderDetailEntity>();
            OrderDetailEntity orderDetail = null;

            foreach (var order in orders)
            {
                orderDetail = new OrderDetailEntity();
                //首先根据商品Id和商品SKU_Id查询出来当前价格
                string shop_currentprice = (from n in await shopSkuRepository.GetAllAsync(c => c.shop_id == order.shop_id && c.shopsku_id == order.shopsku_id)
                                            select n.shopsku_currentprice).FirstOrDefault();
                orderDetail.order_id = orderEntity.order_id;
                orderDetail.shop_id = order.shop_id;
                orderDetail.shopsku_id = order.shopsku_id;
                orderDetail.shop_count = order.shop_count;
                orderDetail.shop_currentprice = string.IsNullOrEmpty(shop_currentprice) ? 0 : Convert.ToDouble(shop_currentprice);
                orderDetail.shopcoupon_id = "0";
                orderDetail.orderdetail_delete = 1;
                orderDetails.Add(orderDetail);
            }

            double detail_price = orderDetails.Sum(c => c.shop_currentprice);
            orderEntity.order_total = detail_price;
            orderEntity.order_privilege = 0;
            orderEntity.order_actualpay = detail_price;
            orderEntity.order_paystatus = 1;
            orderEntity.order_goods = 1;
            orderEntity.order_delete = 1;
            orderEntity.user_id = userId;

            //添加订单主子表-事务
            var isOrder = await orderRepository.AddAsync(orderEntity, false);
            var isOrderDetail = await orderDetailRepository.AddListAsync(orderDetails, false);

            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<string>(200, orderEntity.order_id);
            }
            return new BaseResult<string>(201);
        }

        public async Task<BaseResult<bool>> Pay(string order_id, int payway, SendMailConfig sendMailConfig)
        {
            if (string.IsNullOrEmpty(order_id))
            {
                return new BaseResult<bool>(808);
            }
            //第一步：查询订单信息，如果订单有问题，则不允许用户修改支付状态
            UserOrderInfo query = (from o in await orderRepository.GetAllAsync(c => c.order_id == order_id)
                                   join u in await userRepository.GetAllAsync() on o.user_id equals u.user_id
                                   select new UserOrderInfo()
                                   {
                                       order_id = o.order_id,
                                       order_number = o.order_number,
                                       order_goods = o.order_goods,
                                       order_delete = o.order_delete,
                                       disable = o.disable,
                                       user_email = u.user_email,
                                   }).FirstOrDefault();
            //已支付，已禁用，已删除 不允许操作
            if (query.order_paystatus == 2)
            {
                return new BaseResult<bool>(5002);
            }
            if (query.disable == 1)
            {
                return new BaseResult<bool>(5000);
            }
            if (query.order_delete != 1)
            {
                return new BaseResult<bool>(5001);
            }

            var orderdetail = await orderDetailRepository.GetAllAsync(c => c.order_id == order_id);
            query.orderdetail = orderdetail;

            //首先查询信息并且发送邮件，如果邮件发送成功同步修改订单信息，否则不修改订单信息

            //根据订单详情查询对应的商品信息(商品名称，商品编码 商品code 商品下载地址 对应下载码)，然后拼接发送的信息发送邮件
            IList<ShopDetailInfo> shopDetailList = (from s in await shopRepository.GetAllAsync(s => (from o in orderdetail select o.shop_id).Contains(s.shop_id))
                                                    join k in await shopSkuRepository.GetAllAsync(k => (from o in orderdetail select o.shopsku_id).Contains(k.shopsku_id)) on s.shop_id equals k.shop_id
                                                    select new ShopDetailInfo()
                                                    {
                                                        shopEntity = s,
                                                        shopSkuEntity = k
                                                    }).ToList();
            StringBuilder sbHtmlEmail = new StringBuilder();
            for (int i = 0; i < shopDetailList.Count; i++)
            {
                sbHtmlEmail.AppendFormat(@"<tr>
                    <td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>{0}</td>
                    <td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>{1}</td>
                    <td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>
                        <a href='{2}'>{2}</a></td><td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>{3}</td></tr>",
                        shopDetailList[i].shopEntity.shop_name, shopDetailList[i].shopSkuEntity.shop_code, shopDetailList[i].shopSkuEntity.shopsku_url, shopDetailList[i].shopSkuEntity.shopsku_code);
            }
            var isEmailTrue = await EmailUtil.SendEmailAsync(query.user_email, string.Format(EmailKeyUtil.send_order_title, query.user_email),
                    string.Format(EmailKeyUtil.send_order_content, query.user_email, sbHtmlEmail.ToString()), sendMailConfig, "h");
            if (isEmailTrue)
            {
                OrderEntity order = new OrderEntity()
                {
                    order_id = order_id,
                    order_paystatus = 2,
                    order_payway = payway,
                    order_goods = 2
                };
                var isTrue = await orderRepository.UpdateAsync(order, true, true, o => o.order_paystatus, o => o.order_payway, o => o.order_goods);
                if (isTrue)
                {
                    return new BaseResult<bool>(200);
                }
            }
            return new BaseResult<bool>(201);
        }

        public async Task<BaseResult<bool>> UpgradeOrder(string order_id, string check_shopsku_id, string shopsku_id, SendMailConfig sendMailConfig)
        {
            if (string.IsNullOrEmpty(order_id) || string.IsNullOrEmpty(shopsku_id) || string.IsNullOrEmpty(check_shopsku_id))
            {
                return new BaseResult<bool>(808, false);
            }
            var check_data = await shopSkuRepository.GetAsync(c => c.shopsku_id == check_shopsku_id);   //新选择的价钱
            var data = await shopSkuRepository.GetAsync(c => c.shopsku_id == shopsku_id);               //原始的商品价钱
            double money = Convert.ToDouble(check_data.shopsku_currentprice) - Convert.ToDouble(data.shopsku_currentprice);
            if (money < 0)
            {
                return new BaseResult<bool>(5004, false);
            }

            var userOrderInfo = (from o in await orderRepository.GetAllAsync(c => c.order_id == order_id)
                                 join od in await orderDetailRepository.GetAllAsync(c => c.shopsku_id == shopsku_id) on o.order_id equals od.order_id
                                 join u in await userRepository.GetAllAsync() on o.user_id equals u.user_id
                                 select new
                                 {
                                     u.user_email,
                                     o.order_total,
                                     o.order_actualpay,
                                     od.orderdetail_id
                                 }).FirstOrDefault();
            //首先发送邮件，邮件发送成功之后发修改数据库结构
            var emailSend = (from shop in await shopRepository.GetAllAsync()
                             join shopsku in await shopSkuRepository.GetAllAsync(c => c.shopsku_id == check_shopsku_id) on shop.shop_id equals shopsku.shop_id
                             select new
                             {
                                 shop.shop_name,
                                 shopsku.shop_code,
                                 shopsku.shopsku_url,
                                 shopsku.shopsku_code,
                                 shopsku.shopsku_currentprice
                             }).FirstOrDefault();
            string sbHtmlEmail = string.Format(@"<tr>
                    <td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>{0}</td>
                    <td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>{1}</td>
                    <td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>
                        <a href='{2}'>{2}</a></td><td style='padding - left:10px; padding - right:10px; padding - top:5px; padding - bottom:5px; '>{3}</td></tr>",
                    emailSend.shop_name, emailSend.shop_code, emailSend.shopsku_url, emailSend.shopsku_code);

            var isEmailTrue = await EmailUtil.SendEmailAsync(userOrderInfo.user_email, string.Format(EmailKeyUtil.send_order_title, userOrderInfo.user_email),
                   string.Format(EmailKeyUtil.send_order_content, userOrderInfo.user_email, sbHtmlEmail.ToString()), sendMailConfig, "h");
            if (isEmailTrue)
            {
                var orderEntity = new OrderEntity()
                {
                    order_id = order_id,
                    order_total = Convert.ToDouble(userOrderInfo.order_total) + money,
                    order_actualpay = Convert.ToDouble(userOrderInfo.order_actualpay) + money,
                };
                var orderDetailEntity = new OrderDetailEntity
                {
                    orderdetail_id = userOrderInfo.orderdetail_id,
                    shopsku_id = check_shopsku_id,
                    shop_currentprice = Convert.ToDouble(emailSend.shopsku_currentprice),
                };

                var isOrder = await orderRepository.UpdateAsync(orderEntity, false, true, c => c.order_total, c => c.order_actualpay);
                var isOrderDetail = await orderDetailRepository.UpdateAsync(orderDetailEntity, false, true, c => c.shopsku_id, c => c.shop_currentprice);
                if (unitOfWork.SaveCommit())
                {
                    return new BaseResult<bool>(200, true);
                }
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> PayOrder(string order_id, string order_memo, bool isprivilege)
        {
            //选择优惠则进行订单的详细更新，不选择优惠的话则直接修改主表备注状态即可
            if (isprivilege)
            {
                //首先很据订单Id查询订单详情信息,查询到订单信息之后循环修改子表
                IQueryable<OrderDetailEntity> orderDetails = await orderDetailRepository.GetAllAsync(c => c.order_id == order_id);
                string shop_ids = string.Join(",", orderDetails.Select(c => c.shop_id).Distinct());

                //根据商品Ids集合查询到商品SKU信息，返回商品SKU集合和商品Id信息
                List<ShopCouponEntity> shopCoupons = (from n in shopCouponRepository.GetAll(c => c.shop_id.Contains(shop_ids))
                                                      select new ShopCouponEntity()
                                                      {
                                                          shop_id = n.shop_id,
                                                          shopcoupon_id = n.shopcoupon_id,
                                                          shopcoupon_money = n.shopcoupon_money
                                                      }).ToList();

                List<OrderDetailEntity> orderDetailEntitys = new List<OrderDetailEntity>();
                double order_privilege = 0;
                foreach (var orderDetail in orderDetails)
                {
                    var shopCoupon = shopCoupons.FirstOrDefault(c => c.shop_id.Equals(orderDetail.shop_id));
                    order_privilege += shopCoupon.shopcoupon_money;
                    orderDetail.shopcoupon_id = shopCoupon.shopcoupon_id;
                    orderDetailEntitys.Add(orderDetail);
                }

                var orderEntity = new OrderEntity()
                {
                    order_id = order_id,
                    order_memo = order_memo,
                    order_privilege = order_privilege,
                    order_actualpay = orderDetailEntitys.Sum(c => c.shop_currentprice) - order_privilege
                };
                var isOrderDetail = await orderDetailRepository.UpdateListAsync(orderDetailEntitys, false, true, c => c.shopcoupon_id);
                var isDetail = await orderRepository.UpdateAsync(orderEntity, false, true, c => c.order_memo, c => c.order_privilege, c => c.order_actualpay);
            }
            else
            {
                var isDetail = await orderRepository.UpdateAsync(new OrderEntity { order_id = order_id, order_memo = order_memo }, false, true, c => c.order_memo);
            }

            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> Disable(string order_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(order_id))
            {
                return new BaseResult<bool>(808);
            }
            var str = "";
            OrderEntity orderEntity = await orderRepository.GetAsync(c => c.order_id.Equals(order_id));

            if (orderEntity.order_paystatus == 2)
            {
                return new BaseResult<bool>(5002);
            }
            if (orderEntity.order_goods != 1)
            {
                return new BaseResult<bool>(5003);
            }

            if (string.IsNullOrEmpty(orderEntity.disabledesc))
            {
                str = "{'disable':'" + orderEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = orderEntity.disabledesc + ",{'disable':'" + orderEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            OrderEntity order = new OrderEntity()
            {
                order_id = order_id,
                disabledesc = str,
                disable = type
            };

            var isTrue = await orderRepository.UpdateAsync(order, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> DeleteOrderDetail(string orderdetail_id, string order_id)
        {
            //查询子表中删除的状态数据含有几个，如果只有1条则主表同步也置为删除状态，否则主表不修改
            if (string.IsNullOrEmpty(orderdetail_id))
            {
                return new BaseResult<bool>(808);
            }
            var orderDetails = await orderDetailRepository.GetAllAsync(c => c.order_id == order_id && c.orderdetail_delete == 2);
            if (orderDetails.Count() < 2)
            {
                var isOrder = await orderRepository.UpdateAsync(new OrderEntity() { order_id = order_id, order_delete = 2 }, false, true, c => c.order_delete);
            }
            var isTrue = await orderDetailRepository.UpdateAsync(new OrderDetailEntity { orderdetail_id = orderdetail_id, orderdetail_delete = 2 }, false, true, c => c.orderdetail_delete);

            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> UpdateOkGoods(string order_id)
        {
            if (string.IsNullOrEmpty(order_id))
            {
                return new BaseResult<bool>(808);
            }
            var isTrue = await orderRepository.UpdateAsync(new OrderEntity { order_id = order_id, order_goods = 3 }, true, true, c => c.order_goods);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Delete(string order_id)
        {
            if (string.IsNullOrEmpty(order_id))
            {
                return new BaseResult<bool>(808);
            }

            var isOrder = await orderRepository.DeleteAsync(o => o.order_id.Equals(order_id), false);
            var isDetail = await orderDetailRepository.DeleteAsync(d => d.order_id.Equals(order_id), false);
            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<string> IncomeMoney()
        {
            var data = (from n in await orderRepository.GetAllAsync(c => c.disable == 0 && c.order_delete == 1 && c.order_paystatus == 2)
                        select n.order_actualpay).Sum().ToString("f2");
            return data;
        }
    }
}