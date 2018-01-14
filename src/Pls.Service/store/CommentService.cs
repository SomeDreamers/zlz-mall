//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Service/CommentService 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/3 23:01:38
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using Pls.IService;
using System.Threading.Tasks;
using System;
using Pls.IRepository;
using System.Linq;
using System.Linq.Expressions;
using Pls.Utils;
using System.Collections.Generic;
using Pls.UnitOfWork;

namespace Pls.Service
{
    /// <summary>
    /// 评论管理逻辑实现
    /// </summary>
    public class CommentService : ICommentService
    {
        /// <summary>
        /// 注入评论管理操作
        /// </summary>
        private ICommentRepository commentRepository { get; set; }
        private IUserRepository userRepository { get; set; }
        private IShopRepository shopRepository { get; set; }
        private ICommentImageRepository commentImageRepository { get; set; }
        private IOrderDetailRepository orderDetailRepository { get; set; }
        private IUnitOfWork unitOfWork { get; set; }

        public CommentService(ICommentRepository _commentRepository, IUserRepository _userRepository, IShopRepository _shopRepository,
            ICommentImageRepository _commentImageRepository, IOrderDetailRepository _orderDetailRepository, IUnitOfWork _unitOfWork)
        {
            commentRepository = _commentRepository;
            userRepository = _userRepository;
            shopRepository = _shopRepository;
            commentImageRepository = _commentImageRepository;
            unitOfWork = _unitOfWork;
            orderDetailRepository = _orderDetailRepository;
        }

        public async Task<Pager<IQueryable<CommentShopInfo>>> List(CommentInfo commentInfo)
        {
            //使用linq join关联三张表查询评论信息(Pls_Comment、Pls_User、Pls_Shop)
            Expression<Func<UserEntity, bool>> user_serach = LinqUtil.True<UserEntity>();
            Expression<Func<ShopEntity, bool>> shop_serach = LinqUtil.True<ShopEntity>();
            Expression<Func<CommentEntity, bool>> comment_serach = LinqUtil.True<CommentEntity>();

            user_serach.AndAlso(c => c.disable == 0);
            shop_serach.AndAlso(c => c.disable == 0);
            if (!string.IsNullOrEmpty(commentInfo.user_email))
            {
                user_serach = user_serach.AndAlso(b => b.user_email.Contains(commentInfo.user_email));
            }
            if (!string.IsNullOrEmpty(commentInfo.shop_name))
            {
                shop_serach = shop_serach.AndAlso(b => b.shop_name.Contains(commentInfo.shop_name));
            }
            if ((commentInfo.status) != -1)
            {
                comment_serach = comment_serach.AndAlso(b => b.disable == commentInfo.status);
            }

            int pageindex = commentInfo.pageindex;      //页码，因为没有set，所以就重新定义一个变量
            //异步读取总数
            int total = await commentRepository.CountAsync(comment_serach);

            //调用仓储方法查询分页并且响应给前台
            IQueryable<CommentShopInfo> query = (from c in await commentRepository.GetAllAsync(comment_serach)
                                                 join d in await userRepository.GetAllAsync(user_serach)
                                                     on c.user_id equals d.user_id
                                                 join e in await shopRepository.GetAllAsync(shop_serach)
                                                     on c.shop_id equals e.shop_id
                                                 orderby c.createtime descending
                                                 select new CommentShopInfo
                                                 {
                                                     comment_id = c.comment_id,
                                                     user_email = d.user_email,
                                                     shop_name = e.shop_name,
                                                     comment_star = c.comment_star,
                                                     comment_desc = c.comment_desc,
                                                     comment_reply = c.comment_reply,
                                                     createtime = c.createtime,
                                                     disable = c.disable,
                                                     disabledesc = null,
                                                     commentImage = null
                                                 }).Skip((--pageindex * commentInfo.pagesize)).Take(commentInfo.pagesize);

            return new Pager<IQueryable<CommentShopInfo>>(total, query);
        }

        public async Task<BaseResult<CommentShopInfo>> GetCommentById(string comment_id)
        {
            CommentShopInfo query = (from c in await commentRepository.GetAllAsync(c => c.comment_id == comment_id)
                                     join d in await userRepository.GetAllAsync()
                                         on c.user_id equals d.user_id
                                     join e in await shopRepository.GetAllAsync()
                                         on c.shop_id equals e.shop_id
                                     select new CommentShopInfo
                                     {
                                         comment_id = c.comment_id,
                                         user_email = d.user_email,
                                         shop_name = e.shop_name,
                                         comment_star = c.comment_star,
                                         comment_desc = c.comment_desc,
                                         comment_reply = c.comment_reply,
                                         createtime = c.createtime,
                                         disable = c.disable,
                                         disabledesc = c.disabledesc
                                     }).FirstOrDefault();
            var commentImage = await commentImageRepository.GetAllAsync(c => c.comment_id == comment_id);
            query.commentImage = commentImage.Select(c => c.comment_address);

            return new BaseResult<CommentShopInfo>(200, query);
        }

        public async Task<BaseResult<List<ShopCommentView>>> GetShopCommentInfo(string shop_id, int type)
        {
            //判断查询参数（组装查询条件）  1表示好评（5）  2表示中评(2,3,4) 3表示差评(1)
            Expression<Func<ShopCommentInfo, bool>> where_search = LinqUtil.True<ShopCommentInfo>();
            where_search = where_search.AndAlso(c => c.shop_id == shop_id);

            if (type != 0)
            {
                switch (type)
                {
                    case 3:
                        where_search = where_search.AndAlso(c => c.comment_star == 1);
                        break;
                    case 2:
                        where_search = where_search.AndAlso(c => c.comment_star == 2 || c.comment_star == 3 || c.comment_star == 4);
                        break;
                    default:
                        where_search = where_search.AndAlso(c => c.comment_star == 5);
                        break;
                }
            }
            IQueryable<ShopCommentInfo> shopCommentInfos = await commentRepository.GetShopCommentInfo(where_search);

            List<ShopCommentView> shopCommentViews = new List<ShopCommentView>();
            ShopCommentView shopCommentView = null;

            //查询到结果之后进行处理，如果已经含有相通版本的，则直接累加图片
            foreach (var shopCommentInfo in shopCommentInfos)
            {
                shopCommentView = shopCommentViews.FirstOrDefault(c => c.comment_id.Equals(shopCommentInfo.comment_id));
                if (shopCommentView == null)
                {
                    shopCommentView = new ShopCommentView();
                    shopCommentView.comment_id = shopCommentInfo.comment_id;
                    shopCommentView.user_name = shopCommentInfo.user_name;
                    shopCommentView.user_image = shopCommentInfo.user_image;
                    shopCommentView.shop_code = shopCommentInfo.shop_code;
                    shopCommentView.comment_desc = shopCommentInfo.comment_desc;
                    shopCommentView.comment_reply = shopCommentInfo.comment_reply;
                    shopCommentView.comment_star = shopCommentInfo.comment_star;
                    shopCommentView.createtime = shopCommentInfo.createtime;
                    shopCommentView.image_address.Add(shopCommentInfo.comment_address);
                    shopCommentViews.Add(shopCommentView);
                }
                else
                {
                    shopCommentView.image_address.Add(shopCommentInfo.comment_address);
                }
            }
            return new BaseResult<List<ShopCommentView>>(200, shopCommentViews);
        }

        public async Task<BaseResult<bool>> AddComment(CommentShop CommentShop)
        {
            //首先修改订单子表中的评论状态为已评论，添加评论表并且添加图片表信息
            var isOrderDetail = await orderDetailRepository.UpdateAsync(new OrderDetailEntity() { orderdetail_id = CommentShop.orderdetail_id, orderdetail_evaluate = 2 }, false, true, c => c.orderdetail_evaluate);

            CommentEntity commentEntity = new CommentEntity()
            {
                user_id = CommentShop.user_id,
                shop_id = CommentShop.shop_id,
                shopsku_id = CommentShop.shopsku_id,
                comment_star = CommentShop.comment_star,
                comment_desc = CommentShop.comment_desc,
                createtime = DateTime.Now,
                disable = (int)DisableStatus.disable_false
            };
            var isComment = await commentRepository.AddAsync(commentEntity, false);

            if (CommentShop.image_url != null && CommentShop.image_url.Count > 0)
            {
                List<CommentImageEntity> commentImages = new List<CommentImageEntity>();
                CommentImageEntity commentImageEntity = null;
                foreach (var image_url in CommentShop.image_url)
                {
                    commentImageEntity = new CommentImageEntity();
                    commentImageEntity.comment_id = commentEntity.comment_id;
                    commentImageEntity.comment_address = image_url;
                    commentImages.Add(commentImageEntity);
                }
                var isCommentImage = await commentImageRepository.AddListAsync(commentImages, false);
            }

            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> Reply(string comment_id, string comment_reply)
        {
            if (string.IsNullOrEmpty(comment_id) || string.IsNullOrEmpty(comment_reply))
            {
                return new BaseResult<bool>(808);
            }

            var isTrue = await commentRepository.UpdateAsync(new CommentEntity() { comment_id = comment_id, comment_reply = comment_reply },
                true, true, c => c.comment_reply);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string comment_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(comment_id))
            {
                return new BaseResult<bool>(808);
            }
            var str = "";
            CommentEntity commentEntity = await commentRepository.GetAsync(c => c.comment_id.Equals(comment_id));
            if (string.IsNullOrEmpty(commentEntity.disabledesc))
            {
                str = "{'disable':'" + commentEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = commentEntity.disabledesc + ",{'disable':'" + commentEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            CommentEntity comment = new CommentEntity()
            {
                comment_id = comment_id,
                disabledesc = str,
                disable = type
            };

            var isTrue = await commentRepository.UpdateAsync(comment, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

    }
}