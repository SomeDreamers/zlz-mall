//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IBaseRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/9 10:19:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pls.IRepository
{

    /// <summary>
    /// 数据库基础操作类
    /// </summary>
    /// <typeparam name="T">泛型限制，限制泛型类型只能类</typeparam>
    public interface IBaseRepository<T> where T : class
    {

        #region ======================＝＝＝＝＝增加＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        bool Add(T entity, bool isCommit = true);

        /// <summary>
        /// 增加一条记录(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> AddAsync(T entity, bool isCommit = true);

        /// <summary>
        /// 增加或者更新一条数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSave">是否增加</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        bool AddOrUpdate(T entity, bool isSave, bool isCommit = true);

        /// <summary>
        /// 增加或者更新一条数据(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSave">是否增加</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> AddOrUpdateAsync(T entity, bool isSave, bool isCommit = true);

        /// <summary>
        /// 增加多条数据，同一模型
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        bool AddList(List<T> lists, bool isCommit = true);

        /// <summary>
        /// 增加多条数据，同一模型(异步方式)
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> AddListAsync(List<T> lists, bool isCommit = true);

        #endregion

        #region ======================＝＝＝＝＝修改＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交(默认提交)</param>
        /// <param name="isUpdate">更新方式(默认true),如果传递true，则后面传递的参数更新，如果传递false，则后面传递的参数不更新</param>
        /// <param name="propertiesToUpdate">更新字段</param>
        bool Update(T entity, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate);

        /// <summary>
        /// 修改一条数据(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交(默认提交)</param>
        /// <param name="isUpdate">更新方式(默认true),如果传递true，则后面传递的参数更新，如果传递false，则后面传递的参数不更新</param>
        /// <param name="propertiesToUpdate">更新字段</param>
        Task<bool> UpdateAsync(T entity, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate);

        /// <summary>
        /// 更新多条记录，同一模型(不建议使用)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交(默认提交)</param>
        /// <param name="isUpdate">更新方式(默认true),如果传递true，则后面传递的参数更新，如果传递false，则后面传递的参数不更新</param>
        /// <param name="propertiesToUpdate">更新字段</param>
        bool UpdateList(List<T> lists, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate);


        /// <summary>
        /// 更新多条记录，同一模型(异步方式)(不建议使用)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交(默认提交)</param>
        /// <param name="isUpdate">更新方式(默认true),如果传递true，则后面传递的参数更新，如果传递false，则后面传递的参数不更新</param>
        /// <param name="propertiesToUpdate">更新字段</param>
        Task<bool> UpdateListAsync(List<T> lists, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate);


        #endregion

        #region ======================＝＝＝＝＝删除＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        bool Delete(T entity, bool isCommit = true);

        /// <summary>
        /// 删除一条数据(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity, bool isCommit = true);

        /// <summary>
        /// 删除多条数据，同一模型
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool DeleteList(List<T> lists, bool isCommit = true);

        /// <summary>
        /// 删除多条数据，同一模型（异步方式）
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> DeleteListAsync(List<T> lists, bool isCommit = true);

        /// <summary>
        /// 通过Lambda表达式，删除一条或多条数据（不传递条件则直接清空库）
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> query, bool isCommit = true);

        /// <summary>
        /// 通过Lamda表达式，删除一条或多条数据（不传递条件则直接清空库）（异步方式）
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> query, bool isCommit = true);

        #endregion

        #region ======================＝＝＝＝＝单查询＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        /// <summary>
        /// 通过Lambda表达式查询实体
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 通过Lambda表达式查询实体(异步方式)
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 通过Lambda表达式查询实体总数
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 通过Lambda表达式查询实体总数(异步方式)
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 验证当前条件数据库是否存在数据
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 验证当前条件数据库是否存在数据(异步方式)
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 返回IQueryable集合，延时加载数据
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 返回IQueryable集合，延时加载数据（异步方式）
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 返回IQueryable集合，延时加载数据（异步方式） 
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="isAsc">排序方式</param>
        /// <returns></returns>
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, DateTime>> orderby, bool isAsc = true, Expression<Func<T, bool>> where = null);

        /// <summary>
        /// 不建议使用，会造成全表扫描，将数据全部查询到内存中：返回List集合,不采用延时加载
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        List<T> GetListAll(Expression<Func<T, bool>> query = null);

        /// <summary>
        /// 不建议使用，会造成全表扫描，将数据全部查询到内存中：返回List集合,不采用延时加载（异步方式）
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <returns></returns>
        Task<List<T>> GetListAllAsync(Expression<Func<T, bool>> query = null);

        #endregion

        #region ========================＝＝＝T-Sql查询＝＝=＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        /// <summary>
        /// 验证当前条件数据库是否存在数据(T-Sql方式)(不建议使用，业务层不允许出现SQL)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        bool IsExist(string sql, params DbParameter[] parameter);

        /// <summary>
        /// 验证当前条件数据库是否存在数据(T-Sql方式)(不建议使用，业务层不允许出现SQL)(异步方式)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        Task<bool> IsExistAsync(string sql, params DbParameter[] parameter);

        /// <summary>
        /// 返回IQueryable集合(T-Sql方式)(不建议使用，业务层不允许出现SQL)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        IQueryable<T> GetAllBySql(string sql, params DbParameter[] parameter);

        /// <summary>
        /// 返回IQueryable集合( T-Sql方式)（异步方式）(不建议使用，业务层不允许出现SQL)
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        Task<IQueryable<T>> GetAllBySqlAsync(string sql, params DbParameter[] parameter);

        /// <summary>
        /// 返回List集合(T-Sl方式)(不建议使用，业务层不允许出现Sql)
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        List<T> GetListAllBySql(string sql, params DbParameter[] parameter);

        /// <summary>
        /// 返回List集合(T-Sl方式)（异步方式）(不建议使用，业务层不允许出现Sql)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<List<T>> GetListAllBySqlAsync(string sql, params DbParameter[] parameter);

        #endregion

        #region ====================＝＝＝＝＝分页查询＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        /// <summary>
        /// 分页查询，返回IQueryable集合，延迟加载数据
        /// </summary>
        /// <typeparam name="TEntity">查询条件</typeparam>
        /// <typeparam name="TOrderBy">排序条件</typeparam>
        /// <typeparam name="TResult">返回的实体(给前台相应)</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="selector">查询结果</param>
        /// <param name="total">总数</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        IQueryable<TResult> GetPageAll<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector,
            out int total, bool isAsc = true) where TEntity : class where TResult : class;

        /// <summary>
        /// 分页查询，返回IQueryable集合，延迟加载数据(异步加载)，异步加载不能使用out,ref
        /// </summary>
        /// <typeparam name="TEntity">查询条件</typeparam>
        /// <typeparam name="TOrderBy">排序条件</typeparam>
        /// <typeparam name="TResult">返回的实体(给前台相应)</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="selector">查询结果</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        Task<IQueryable<TResult>> GetPageAllAsync<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool isAsc = true)
            where TEntity : class where TResult : class;

        /// <summary>
        /// 不建议使用，会造成全表扫描，将数据全部查询到内存中：分页查询，返回List集合,不采用延迟加载
        /// </summary>
        /// <typeparam name="TEntity">查询条件</typeparam>
        /// <typeparam name="TOrderBy">排序条件</typeparam>
        /// <typeparam name="TResult">返回的实体(给前台相应)</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="selector">查询结果</param>
        /// <param name="total">总数</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        List<TResult> GetPageAllList<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where,
           Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector,
           out int total, bool isAsc = true) where TEntity : class where TResult : class;

        /// <summary>
        /// 不建议使用，会造成全表扫描，将数据全部查询到内存中：分页查询，返回IQueryable集合，不采用延迟加载(异步加载)，异步加载不能使用out,ref
        /// </summary>
        /// <typeparam name="TEntity">查询条件</typeparam>
        /// <typeparam name="TOrderBy">排序条件</typeparam>
        /// <typeparam name="TResult">返回的实体(给前台相应)</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="selector">查询结果</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        Task<List<TResult>> GetPageAllListAsync<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where,
           Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool isAsc = true)
           where TEntity : class where TResult : class;

        #endregion

    }
}