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
    public class RegisterConsultativeService : IRegisterConsultativeService
    {
        private readonly IRegisterConsultativeRepository _registerConsultativeRepository;
        public RegisterConsultativeService(IRegisterConsultativeRepository registerConsultativeRepository)
        {
            this._registerConsultativeRepository = registerConsultativeRepository;
        }
        public Task<RegisterConsultative> AddAsync(RegisterConsultative entity)
        {
            return _registerConsultativeRepository.AddAsync(entity);
        }
        public Task<RegisterConsultative> UpdateAsync(RegisterConsultative entity)
        {
            return _registerConsultativeRepository.UpdateAsync(entity);
        }
        public Task<RegisterConsultative> DeleteAsync(RegisterConsultative entity)
        {
            return _registerConsultativeRepository.DeleteAsync(entity);
        }

        //public Task<RegisterConsultative> GetByIdAsync(int id, params Expression<Func<RegisterConsultative, object>>[] includeProperties)
        //{
        //    return _registerConsultativeRepository.GetByIdAsync(id, includeProperties);
        //}

        public Task<IReadOnlyList<RegisterConsultative>> ListAsync(Expression<Func<RegisterConsultative, bool>> filter = null, Func<IQueryable<RegisterConsultative>, IOrderedQueryable<RegisterConsultative>> orderBy = null, params Expression<Func<RegisterConsultative, object>>[] includeProperties)
        {
            return _registerConsultativeRepository.ListAsync(filter, orderBy, includeProperties);
        }

        public Task<RegisterConsultative> GetSingleByIdAsync(dynamic id)
        {
            return _registerConsultativeRepository.GetSingleByIdAsync(id);
        }

        public IEnumerable<RegisterConsultative> GetAll(string[] includes = null)
        {
            return _registerConsultativeRepository.GetAll();
        }

        public void AddRange(IEnumerable<RegisterConsultative> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<RegisterConsultative> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<RegisterConsultative> entities)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterConsultative> DeleteByIdAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMultiByConditionAsync(Expression<Func<RegisterConsultative, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<RegisterConsultative> entities)
        {
            throw new NotImplementedException();
        }

        public RegisterConsultative GetSingleByCondition(Expression<Func<RegisterConsultative, bool>> expression, string[] includes = null)
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
