//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Utils/PredicateBuilder 
//  创建人:                     kencery     
//  创建时间:                   2016/9/25 15:16:02
//  网站:                       http://www.chuxinm.com
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Pls.Utils
{
    /// <summary>
    /// 封装组装查询条件的表达式
    /// </summary>
    public static class LinqUtil
    {
        /// <summary>
        /// 机关函数应用True时：单个AND有效，多个AND有效；单个OR无效，多个OR无效；混应时写在AND后的OR有效 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        /// <summary>
        /// 机关函数应用False时：单个AND无效，多个AND无效；单个OR有效，多个OR有效；混应时写在OR后面的AND有效 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// 不建议使用，会造成全表扫描
        /// </summary>
        /// <typeparam name="T">需要返回的实体数据</typeparam>
        /// <param name="expr1">扩展方法：lambda表达式信息</param>
        /// <param name="expr2">参数：lambda表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
            (Expression.Or(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// 不建议使用，会造成全表扫描
        /// </summary>
        /// <typeparam name="T">需要返回的实体数据</typeparam>
        /// <param name="expr1">扩展方法：lambda表达式信息</param>
        /// <param name="expr2">参数：lambda表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
            (Expression.And(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// 建议使用，不会造成全表扫描，只会拼装sql语句最后统一发送请求
        /// </summary>
        /// <typeparam name="T">需要返回的实体数据</typeparam>
        /// <param name="expr1">扩展方法：lambda表达式信息</param>
        /// <param name="expr2">参数：lambda表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        /// <summary>
        /// 提供给上面的方法进行查询
        /// </summary>
        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }

        /// <summary>
        /// 扩展Linq的OrderBy方法，实现根据属性和顺序(倒序)进行排序，调用和linq的方法一致
        /// </summary>
        /// <typeparam name="TEntity">需要排序的实体对象</typeparam>
        /// <param name="source">结果集信息</param>
        /// <param name="propertyStr">动态排序的属性名(从前台获取)</param>
        /// <param name="isDesc">排序方式，不传递表示顺序，默认true，false表示倒序</param>
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string propertyStr,
            bool isDesc = true) where TEntity : class
        {
            //以下四句用来建立c>c.propertyStr的Expression对象，实现Lambda表达式的状态
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "c");
            PropertyInfo propertyInfo = typeof(TEntity).GetProperty(propertyStr);
            Expression expression = Expression.MakeMemberAccess(parameterExpression, propertyInfo);
            LambdaExpression lambdaExpression = Expression.Lambda(expression, parameterExpression);
            Type type = typeof(TEntity);

            //读取排序的顺序信息，如果传递的参数(isDesc)是true，则为顺序排序，否则为倒序排序
            string ascDesc = isDesc ? "OrderBy" : "OrderByDescending";

            //Expression.Call跟上面的信息一样，这里采用重载的形式，上面的GetCurrentMethod结果也是ascDesc
            //Expression.Call方法会利用typeof(Queryable),ascDesc,new Type[]{type,property,PropertyType}三个参数
            //合成跟MethodInfo等同的消息
            MethodCallExpression methodCallExpression = Expression.Call(typeof(Queryable), ascDesc,
                new Type[] { type, propertyInfo.PropertyType }, source.Expression, Expression.Quote(lambdaExpression));

            //返回成功
            return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(methodCallExpression);

        }

        /// <summary>
        /// 扩展linq的Join方法，使其传递的集合或者数组调用Join方法可以转换成按照规定格式转换的字符串
        /// 使用：string[] strJoin={"kencery","liuxiaoji"};
        ///       strJoin.Join("需要分隔的格式，不传递默认按照，分隔")
        /// </summary>
        /// <param name="source">需要转换成字符串格式的集合信息</param>
        /// <param name="separator">以某种格式分隔集合的信息，不传递默认则是,</param>
        public static string Join(this IEnumerable<string> source, string separator = ",")
        {
            if (source == null)
            {
                throw new Exception("source is null,but source is not null");
            }
            return source.Aggregate((x, y) => x + separator + y);
        }

    }
}