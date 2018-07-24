using App.Data.Entities;
using App.Data.IRepositories;
using App.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public Task<Category> AddAsync(Category entity)
        {
            return _categoryRepository.AddAsync(entity);
        }
        public Task<Category> UpdateAsync(Category entity)
        {
            return _categoryRepository.UpdateAsync(entity);
        }
        public Task<Category> DeleteAsync(Category entity)
        {
            return _categoryRepository.DeleteAsync(entity);
        }
        public Task<IReadOnlyList<Category>> ListAsync(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            return _categoryRepository.ListAsync(filter, orderBy, includeProperties);
        }

        public Task<Category> GetSingleByIdAsync(dynamic id)
        {
            return _categoryRepository.GetSingleByIdAsync(id);
        }

        public IEnumerable<Category> GetAll(string[] includes = null)
        {
            return _categoryRepository.GetAll(includes);
        }

        public void AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Category> DeleteByIdAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMultiByConditionAsync(Expression<Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category GetSingleByCondition(Expression<Func<Category, bool>> expression, string[] includes = null)
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
