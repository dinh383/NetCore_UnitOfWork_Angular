using App.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public interface IServiceCommon<TEntity>
        where TEntity : class 
    {
        //GET LIST
        Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll(string[] includes = null);

        //ADD
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        //UPDATE
        Task<TEntity> UpdateAsync(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //DELETE
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> DeleteByIdAsync(dynamic id);
        Task DeleteMultiByConditionAsync(Expression<Func<TEntity, bool>> where);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        //GET SINGLE BY ID
        Task<TEntity> GetSingleByIdAsync(dynamic id);
        TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        //SAVE
        void SaveChanges();
        void SaveChangesAsync();
    }
}
