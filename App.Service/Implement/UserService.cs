﻿using App.Data.Entities;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public Task<AppUser> AddAsync(AppUser entity)
        {
            return _userRepository.AddAsync(entity);
        }
        public Task<AppUser> UpdateAsync(AppUser entity)
        {
            return _userRepository.UpdateAsync(entity);
        }
        public Task<AppUser> DeleteAsync(AppUser entity)
        {
            return _userRepository.DeleteAsync(entity);
        }
        public Task<IReadOnlyList<AppUser>> ListAsync(Expression<Func<AppUser, bool>> filter = null, Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = null, params Expression<Func<AppUser, object>>[] includeProperties)
        {
            return _userRepository.ListAsync(filter, orderBy, includeProperties);
        }

        public Task<AppUser> GetSingleByIdAsync(dynamic id)
        {
            return _userRepository.GetSingleByIdAsync(id);
        }

        public IEnumerable<AppUser> GetAll(string[] includes = null)
        {
            return _userRepository.GetAll();
        }

        public void AddRange(IEnumerable<AppUser> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<AppUser> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<AppUser> entities)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> DeleteByIdAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMultiByConditionAsync(Expression<Func<AppUser, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<AppUser> entities)
        {
            throw new NotImplementedException();
        }

        public AppUser GetSingleByCondition(Expression<Func<AppUser, bool>> expression, string[] includes = null)
        {
            return _userRepository.GetSingleByCondition(expression, includes);
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
