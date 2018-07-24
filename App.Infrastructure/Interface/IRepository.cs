﻿using App.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Data;

namespace App.Infrastructure.Interface
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// GET LIST
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        #region GET LIST
        IEnumerable<TEntity> GetAll(string[] includes = null);
        Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<PaginatedItems<TEntity>> ListAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);
        Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);
        IEnumerable<TEntity> GetMultiPaging(Expression<Func<TEntity, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null);
        #endregion GET LIST

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        #region ADD ENTITY
        EntityEntry<TEntity> Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        #endregion ADD ENTITY

        /// <summary>
        ///  UPDATE ENTITY
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        #region UPDATE ENTITY
        EntityEntry<TEntity> Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        #endregion UPDATE ENTITY

        /// <summary>
        /// DELETE ENTITY
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        #region DELETE ENTITY
        TEntity DeleteById(dynamic id);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> DeleteByIdAsync(dynamic id);
        void DeleteMultiByCondition(Expression<Func<TEntity, bool>> where);
        Task DeleteMultiByConditionAsync(Expression<Func<TEntity, bool>> where);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        #endregion DELETE ENTITY

        /// <summary>
        /// GetSingleById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #region GET SINGLE BY ID
        TEntity GetSingleById(dynamic id);
        Task<TEntity> GetSingleByIdAsync(dynamic id);
        Task<TEntity> GetByIdAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetByIdAsync(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);
        TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        #endregion GET SINGLE BY ID

        /// <summary>
        /// ExecuteStoreScalar
        /// </summary>
        /// <param name="sqlName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        #region ExecuteStore
        DataSet ExecuteStoreScalar(string sqlName, object[] parameterValues);
        #endregion ExecuteStore

        /// <summary>
        /// SAVE CHANGES
        /// </summary>
        #region SAVE CHANGES
        void SaveChanges();
        void SaveChangesAsync();
        #endregion SAVE CHANGES
    }
}
