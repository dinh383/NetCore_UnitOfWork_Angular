using App.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Data.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        protected IDbContextTransaction Transaction;

        public EfUnitOfWork(DbContext context)
        {
            _context = context;
        }
        public async Task BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (_context.Database.GetDbConnection().State != ConnectionState.Open)
            {
                await _context.Database.OpenConnectionAsync();
            }
            Transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
        }

        public bool CommitTransaction()
        {
            Transaction.Commit();
            return true;
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
