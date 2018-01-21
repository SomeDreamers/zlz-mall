//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Plug/RegestAutoFac 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Autofac;
using Pls.IRepository;
using Pls.IRepository.store;
using Pls.IService;
using Pls.IService.store;
using Pls.Repository;
using Pls.Repository.store;
using Pls.Service;
using Pls.Service.store;
using Pls.Utils;

namespace Pls.Plug
{
    /// <summary>
    /// AutoFac注入，对每个接口和对应的实现类在这里进行注入
    /// </summary>
    public class RegestAutoFac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //UnitWork接口注入
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>();

            //公共方法注入
            builder.RegisterType<RedisHelp>().As<RedisHelp>();
            builder.RegisterType<HttpContextUtil>().As<HttpContextUtil>();
            builder.RegisterType<ApplicationConfigServices>().As<ApplicationConfigServices>();

            //Repository接口注入
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UserDepartmentRepository>().As<IUserDepartmentRepository>();
            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>();
            builder.RegisterType<ButtonActionRepository>().As<IButtonActionRepository>();
            builder.RegisterType<UserButtonActionRepository>().As<IUserButtonActionRepository>();
            builder.RegisterType<RoleButtonActionRepository>().As<IRoleButtonActionRepository>();

            builder.RegisterType<ShopRepository>().As<IShopRepository>();
            builder.RegisterType<ShopSkuRepository>().As<IShopSkuRepository>();
            builder.RegisterType<ShopAttrRepository>().As<IShopAttrRepository>();
            builder.RegisterType<ShopImageRepository>().As<IShopImageRepository>();
            builder.RegisterType<ShopCouponRepository>().As<IShopCouponRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<CommentImageRepository>().As<ICommentImageRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ShopCategoryRepository>().As<IShopCategoryRepository>();

            builder.RegisterType<MessageRepository>().As<IMessageRepository>();
            builder.RegisterType<NoticeRepository>().As<INoticeRepository>();
            builder.RegisterType<CarouselRepository>().As<ICarouselRepository>();
            builder.RegisterType<UserApplyRepository>().As<IUserApplyRepository>();

            //Service接口注入
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<ButtonActionService>().As<IButtonActionService>();
            builder.RegisterType<ShopService>().As<IShopService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<NoticeService>().As<INoticeService>();
            builder.RegisterType<UserApplyService>().As<IUserApplyService>();
            builder.RegisterType<CarouselService>().As<ICarouselService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
        }
    }
}