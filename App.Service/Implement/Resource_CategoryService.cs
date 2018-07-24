using App.Data.Entities;
using App.Data.IRepositories;
using App.Model.ViewModel;
using App.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace App.Service.Implement
{
    public class Resource_CategoryService : IResource_CategoryService
    {
        private readonly IResource_CategoryRepository _categoryRepository;
        public Resource_CategoryService(IResource_CategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public Task<Resource_Category> AddAsync(Resource_Category entity)
        {
            return _categoryRepository.AddAsync(entity);
        }
        public Task<Resource_Category> UpdateAsync(Resource_Category entity)
        {
            return _categoryRepository.UpdateAsync(entity);
        }
        public Task<Resource_Category> DeleteAsync(Resource_Category entity)
        {
            return _categoryRepository.DeleteAsync(entity);
        }
        public Task<IReadOnlyList<Resource_Category>> ListAsync(Expression<Func<Resource_Category, bool>> filter = null, Func<IQueryable<Resource_Category>, IOrderedQueryable<Resource_Category>> orderBy = null, params Expression<Func<Resource_Category, object>>[] includeProperties)
        {
            return _categoryRepository.ListAsync(filter, orderBy, includeProperties);
        }

        public Task<Resource_Category> GetSingleByIdAsync(dynamic id)
        {
            return _categoryRepository.GetSingleByIdAsync(id);
        }

        public IEnumerable<Resource_Category> GetAll(string[] includes = null)
        {
            return _categoryRepository.GetAll(includes);
        }

        public void AddRange(IEnumerable<Resource_Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Resource_Category> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Resource_Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Resource_Category> DeleteByIdAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMultiByConditionAsync(Expression<Func<Resource_Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Resource_Category> entities)
        {
            throw new NotImplementedException();
        }

        public Resource_Category GetSingleByCondition(Expression<Func<Resource_Category, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
